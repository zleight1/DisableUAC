# Disable Windows User Account Control Service
Windows Service in C# written to disable UAC in the registry on a timer.

Because sometimes Group Policy can get in the way..

##Installation

1. Make sure you are logged in with an administrative account

2. Disable UAC in Control Panel\All Control Panel Items\User Accounts\Change User Account Control settings

3. Download the latest release, currently vMediumRoast.

4. Unzip the release to a directory such as `C:\Temp`.

5. Open up powershell and make sure you have adminstrative rights. You may need to run `Set-ExecutionPolicy Unrestricted`, depending on your machine's settings.
	1. Navigate into the directory with `cd`.

6. Run `.\InstallUAC.ps1`, and everything should run for you. 
	1. There are 2 customizable parameters: `-ServiceName` (default: "DisableUAC") and `-InstallPath` (default: "C:\Utilities"). They should be self explantory what they do...

7. Get coffee, preferably dark and with a lot of caffeine. *No* milk and sugar allowed.

8. Enjoy all your new found free time not spent typing in your credentials every 2 minutes!

##Notes

- The solution is for VS2015 Update 3 which may not be reverse compatible, also you may want to make sure this truly works on your specific configuration as there are other GP settings that could get in the way.
- I have only tested this in Windows 7 x64
- You need to run this as administrator, and I claim NO responsibility if you violate company policy, damage your computer, or if anything happens whatsoever. *You claim ALL responsibility by using this and agree to not hold me liable in any way shape or form.*
- The timer hits every 30 seconds by default, so there is a window where UAC might turn on, this is all dependent on how your GP is set up, this is customizable by changing the `appSetting` called `TimerIntervalInSeconds`.

##Thanks

Thanks to @SharpProgrammer for his help with this.