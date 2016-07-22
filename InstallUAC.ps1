param(
    [string]$InstallPath = "C:\Utilities",
    [string]$ServiceName = "DisableUAC"
)

Copy-Item "DisableUAC*" $InstallPath -Force
New-Service -Name $ServiceName -BinaryPathName "$InstallPath\DisableUAC.exe" -StartupType Automatic
Start-Service -Name $ServiceName

Read-Host