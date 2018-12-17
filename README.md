# Sub.Net

![diagram](https://github.com/MelbourneDeveloper/Device.Net/blob/master/Diagram.png)

Cross platform C# library for talking to Usb devices.

Join us on Slack:
https://hardwarewallets.slack.com

Twitter:
https://twitter.com/HardfolioApp

Blog:
https://christianfindlay.wordpress.com

For Hid devices on Windows and UWP, see [Hid.Net](https://github.com/MelbourneDeveloper/Hid.Net) which often overlap with Usb. Android doesn't have Hid support as far as I know. So, this library is for talking to Usb devices with the same interface IDevice so that dependency injection can be used.

Currently supports:
* .NET Framework - [Hid.Net](https://github.com/MelbourneDeveloper/Hid.Net)
* .NET Core - [Hid.Net](https://github.com/MelbourneDeveloper/Hid.Net)
* Android
* UWP - [Hid.Net](https://github.com/MelbourneDeveloper/Hid.Net)
* Linux* (With LibUsbDotNet Provider)

## Samples & Unit Tests

https://github.com/MelbourneDeveloper/Trezor.Net (UWP, Android, Console - .NET Framework)

https://github.com/MelbourneDeveloper/Ledger.Net (UWP, Console - .NET Core)

https://github.com/LedgerHQ/ledger-dotnet-api (Console - .NET Core)

https://github.com/MelbourneDeveloper/KeepKey.Net (UWP, .NET Framework)

## Store App Production Usage

https://play.google.com/store/apps/details?id=com.Hardfolio (Android)

https://www.microsoft.com/en-au/p/hardfolio/9p8xx70n5d2j (UWP)

## NuGet
Install-Package Usb.Net

## Contribution

I welcome feedback, and pull requests. If there's something that you need to change in the library, please log an issue, and explain the problem. If you have a proposed solution, please write it up and explain why you think it is the answer to the problem. The best way to highlight a bug is to submit a pull request with a unit test that fails so I can clearly see what the problem is in the first place.

### Pull Requests

Please break pull requests up in to their smallest possible parts. If you have a small feature of refactor that other code depends on, try submitting that first. Please try to reference an issue so that I understand the context of the pull request. If there is no issue, I don't know what the code is about. If you need help, please jump on Slack here: https://hardwarewallets.slack.com

## Donate

All Hardwarewallets.Net libraries are open source and free. Your donations will contribute to making sure that these libraries keep up with the latest hardwarewallet firmware, functions are implemented, and the quality is maintained.

Bitcoin: 33LrG1p81kdzNUHoCnsYGj6EHRprTKWu3U

Ethereum: 0x7ba0ea9975ac0efb5319886a287dcf5eecd3038e

Litecoin: MVAbLaNPq7meGXvZMU4TwypUsDEuU6stpY
