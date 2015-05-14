# Disable Windows User Account Control Service
Windows Service in C# written to disable UAC in the registry on a timer.

Because sometimes Group Policy can get in the way..

##Installation

1. Make sure you are logged in with an administrative account

2. Disable UAC in Control Panel\All Control Panel Items\User Accounts\Change User Account Control settings

3. Pull the repo `git clone https://github.com/zleight1/DisableUAC.git`

4. Place `DisableUAC.exe` in an accessible folder (i.e. C:\DisableUAC)
	- You can either build the project yourself and use the one in the bin\debug folder or use the current version in Binaries in the root directory.

5. Register the service
	1. In an elevated command prompt (i.e. right click and run as admin), `cd` to the directory of the executable.
	2. Type `InstallUtil.exe “DisableUAC.exe”` and hit enter, which will register the service.

6. Start the service in Control Panel\All Control Panel Items\Administrative Tools\Services

7. Get coffee, preferably dark and with a lot of caffeine. *No* milk and sugar allowed.

8. Enjoy all your new found free time not spent typing in your credentials every 2 minutes!

##Notes

- The solution is VS2013 which may not be reverse compatible, also you may want to make sure this truly works on your specific configuration as there are other GP settings that could get in the way.
- I have only tested this in Windows 7 x64
- You need to run this as administrator, and I claim NO responsibility if you violate company policy, etc.
- The timer hits every 5 minutes so there is a window where UAC might turn on, this is all dependent on how your GP is set up.

##Thanks

Thanks to @SharpProgrammer for his help with this.