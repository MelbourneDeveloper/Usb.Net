﻿using Android.Content;
using Android.Hardware.Usb;
using Device.Net;

namespace Hid.Net.Android
{
    public class UsbDeviceAttachedReceiver : BroadcastReceiver
    {
        #region Fields
        readonly AndroidHidDevice _AndroidHidDevice;
        #endregion

        #region Constructor
        public UsbDeviceAttachedReceiver(AndroidHidDevice androidHidDevice)
        {
            _AndroidHidDevice = androidHidDevice;
        }
        #endregion

        #region Overrides
        public override async void OnReceive(Context context, Intent intent)
        {
            var device = intent.GetParcelableExtra(UsbManager.ExtraDevice) as UsbDevice;

            if (_AndroidHidDevice == null || device == null || device.VendorId != _AndroidHidDevice.VendorId || device.ProductId != _AndroidHidDevice.ProductId) return;

            await _AndroidHidDevice.UsbDeviceAttached();
            Logger.Log("Device connected", null, AndroidHidDevice.LogSection);
        }
        #endregion
    }
}