<h1 align="center">
  <img src="https://raw.githubusercontent.com/Jessecar96/SteamDesktopAuthenticator/master/icon.png" height="64" width="64" />
  <br/>
  Steam Desktop Authenticator
</h1>
<p align="center">
  Continued development of the desktop implementation of Steam's mobile authenticator app.<br/>
  <sup><b>We are not affiliated with Steam or Scrap.TF in any way!</b> This project is maintained by EvESpirit. Credits for original source go to [Jessecar96](https://github.com/Jessecar96) (for Steam Desktop Authenticator) and [geel] (https://github.com/geel9) (for [SteamAuth](https://github.com/geel9/SteamAuth))
</p>
<h3 align="center">
  <p>WARNING: Recently there have been fake versions of SDA floating around that will steal your Steam account. Never download SDA from any place other than this github repo!</p>
</h3>
<h3 align="center" style="margin-bottom:0">
  <a href="https://github.com/EvESpirit/SteamDesktopAuthenticatorContinued/releases/latest">[Download Here]</a>
</h3>
<p align="center">Supports Windows 10 and up.</p>
<br>

**Clicking "Download ZIP" will not work!** This project use a git submodule called SteamAuth so you must use git to download it properly. Using [GitHub Desktop](https://desktop.github.com/) is an easy way to do that.

**DISCLAIMER: This project was made by community volunteers and is not affiliated with Steam or Scrap.TF. You use this program at your own risk, and accept the responsibility to make backups and prevent unauthorized access to your computer!**

**REMEMBER: Always make backups of your `maFiles` directory! If you lose your encryption key or delete `maFiles` by accident AND you didn't save your revocation code, your whole desktop authentication library is now irreversibly encrypted.**

**IF you lost your `maFiles` OR lost your encryption key, go [here](https://store.steampowered.com/twofactor/manage) and click "Remove Authenticator" then enter your revocation code that you wrote down when you first added your account to SDA.**


**FINALLY: Using this application is a bad idea, because it COMPLETELY DEFEATS THE PURPOSE of two-factor authentication! If your desktop is infected with a virus, it will be able to hijack the authenticator app and completely subvert the protection. THIS APPLICATION DOES NOT PROTECT YOUR ACCOUNT; IT ONLY ALLOWS YOU TO USE STEAM FEATURES THAT REQUIRE THE AUTHENTICATOR WITHOUT HAVING A PHONE. If you have a phone that supports the Mobile Authenticator, you really shouldn't use this application!**

If you did not follow the directions and did not write your revocation code down, you're well and truly screwed. The only option is beg to [Steam Support](https://support.steampowered.com/) and say you lost your mobile authenticator and the revocation code, and hope that somehow works (it probably won't).

## Detailed setup instructions
- Download & Install [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
- Visit [the releases page](https://github.com/EvESpirit/SteamDesktopAuthenticatorContinued/releases/latest) and download the latest .zip (not the source code one).
- Extract the files somewhere very safe on your computer. If you lose the files, you lose access to your Steam accounts.
- Run `Steam Desktop Authenticator.exe` and click the button to set up a new account.
- Login to Steam and follow the instructions to set it up. **Note: you still need a mobile phone that can receive SMS.**
- You may be asked to set up encryption, this is to make sure that if someone gains access to your computer they can't steal your Steam account from this program. This is optional, but don't come crying to issues if you didn't encrypt it and someone hijacked your account because your computer had a virus. We *will* laugh at you.
- Select your account from the list to view the current login code, and click `Trade Confirmations` to see pending trade confirmations.
- For your safety, remember to get Steam Guard backup codes! Follow [this link](https://store.steampowered.com/twofactor/manage) and click "Get Backup Codes," then print out that page and save it in a safe place.
**You can use these codes if you lose access to your authenticator.**

[How to update SDA.](https://github.com/EvESpirit/SteamDesktopAuthenticatorContinued/wiki/Updating)

[How to use SDA on multiple computers.](https://github.com/EvESpirit/SteamDesktopAuthenticatorContinued/wiki/Using-SDA-on-multiple-computers)


## Command line options
```
-k [encryption key]
  Set your encryption key when opened
-s
  Auto-minimize to tray when opened
```

## Troubleshooting
- **Trade confirmation list is just white or a blank screen**
 - First open the "Selected Account" menu, then click "Force session refresh". If it still doesn't work after that, open the "Selected Account" menu again, then click "Login again" and login to your Steam account.

If your problem doesn't appear on the list or none of the solutions worked, submit an issue on the issue tracker.
