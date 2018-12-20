﻿using Device.Net;
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.HumanInterfaceDevice;
using Windows.Devices.Usb;

namespace Usb.Net.UWP
{
    public class UWPUsbDevice : DeviceBase, IDevice
    {
        #region Events
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        #endregion

        #region Fields
        private UsbDevice _UsbDevice;
        #endregion

        #region Public Properties
        public int VendorId { get; set; }
        public int ProductId { get; set; }
        public string DeviceId { get; set; }
        #endregion

        #region Event Handlers

        private byte[] InputReportToBytes(HidInputReportReceivedEventArgs args)
        {
            byte[] bytes;
            using (var stream = args.Report.Data.AsStream())
            {
                bytes = new byte[args.Report.Data.Length];
                stream.Read(bytes, 0, (int)args.Report.Data.Length);
            }

            return bytes;
        }
        #endregion

        #region Constructors
        public UWPUsbDevice()
        {
        }

        public UWPUsbDevice(string deviceId)
        {
            DeviceId = deviceId;
        }
        #endregion

        #region Private Methods
        public async Task InitializeAsync()
        {
            _UsbDevice = await GetDevice(DeviceId);

            if (_UsbDevice != null)
            {
                Connected?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new Exception($"Could not connect to device with Device Id {DeviceId}. Check that the package manifest has been configured to allow this device.");
            }
        }

        private static async Task<UsbDevice> GetDevice(string id)
        {
            var hidDeviceOperation = UsbDevice.FromIdAsync(id);
            var task = hidDeviceOperation.AsTask();
            var hidDevice = await task;
            return hidDevice;
        }
        #endregion

        #region Public Methods
        public async Task<bool> GetIsConnectedAsync()
        {
            return _UsbDevice != null;
        }

        public void Dispose()
        {
            _UsbDevice.Dispose();
        }

        public async Task<byte[]> ReadAsync()
        {
            //if (_LastReadData == null)
            //{
            //    throw new Exception("No data has been read");
            //}
            //var retVal = new byte[64];
            //_LastReadData.CopyTo(0, retVal, 0, 64);

            //_LastReadData = null;

            //_UsbDevice.SendControlOutTransferAsync()

            return null;
        }

        public async Task WriteAsync(byte[] bytes)
        {
            var buffer = bytes.AsBuffer();

            try
            {

                var setupPacket = new UsbSetupPacket()
                {
                    RequestType = new UsbControlRequestType()
                    {
                        Recipient = UsbControlRecipient.Endpoint,

                    }
                };

                await _UsbDevice.SendControlOutTransferAsync(setupPacket, buffer);
            }
            catch (ArgumentException ex)
            {
                //TODO: Check the string is nasty. Validation on the size of the array being sent should be done earlier anyway
                if (ex.Message == "Value does not fall within the expected range.")
                {
                    throw new Exception("It seems that the data being sent to the device does not match the accepted size. Have you checked DataHasExtraByte?", ex);
                }
            }

            Tracer?.Trace(false, bytes);
        }
        #endregion
    }
}
