# Disable Windows User Account Control
Windows Service in C# written to disable UAC in the registry on a timer.

Because sometimes Group Policy can get in the way..

##Installation

1. Make sure you are logged in with an administrative account

2. Disable UAC in Control Panel\All Control Panel Items\User Accounts\Change User Account Control settings

3. Pull the repo `git clone https://github.com/zleight1/DisableUAC.git`

4. Place `Disable.exe` in an accessible folder (i.e. C:\DisableUAC)
	a. You can either build the project yourself and use the one in the bin\debug folder or use the current version in Binaries in the root directory.

5. Register the service

6. Start the service, and set to auto start

7. Get coffee, preferably dark and with a lot of caffeine. *No* milk and sugar allowed.

8. Enjoy all your new found free time not spent typing in your credentials every 2 minutes!

##Notes

- The solution is VS2013 which may not be reverse compatible, also you may want to make sure this truly works on your specific configuration as there are other GP settings that could get in the way.
- I have only tested this in Windows 7 x64

##Thanks

Thanks to @SharpProgrammer for his help with this.