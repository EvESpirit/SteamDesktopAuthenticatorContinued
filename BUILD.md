# How to Build Steam Desktop Authenticator from Source

Instructions were verified with Visual Studio 2026. The solution itself targets .NET 8 and Windows.

## Prerequisites

- **Visual Studio 2022** (or later) with the **.NET desktop development** workload
- **.NET 8 SDK** (install via [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or through Visual Studio Installer)
- **Git** (required if you use the clone method below)

## Option A: Clone with Git (recommended)

The project uses a modified submodule for the SteamAuth library.

1. **Clone the repository and its submodule**
   ```bash
   git clone --recurse-submodules https://github.com/Jessecar96/SteamDesktopAuthenticator.git
   cd SteamDesktopAuthenticator
   ```
   If you already cloned without submodules:
   ```bash
   git submodule update --init --recursive
   ```

2. **Open and build**
   - Open `SteamDesktopAuthenticator.sln` in Visual Studio 2026.
   - In Visual Studio: **Build → Build Solution** (or press Ctrl+Shift+B).
   - The solution will build the **SteamAuth** project first (dependency), then **Steam Desktop Authenticator**.

3. **Run**
   - Set **Steam Desktop Authenticator** as the startup project (right‑click → **Set as Startup Project**), then press F5 or use **Debug → Start Debugging**.

---

## Option B: Manual setup (ZIP + manual SteamAuth)

If you don't wanna use Git, this is your next best method.

1. **Get the SDA source**
   - Download the source of SDA (i.e. “Download ZIP” from GitHub in this repository).
   - Extract it into a folder (e.g. `C:\SDA`). This folder is now your **project root**.

   - Final layout must look like this:
   ```
   <project root>\
       SteamDesktopAuthenticator.sln
       SDA\
       lib\
           SteamAuth\
               SteamAuth\
                   SteamAuth.csproj
                   ... (other SteamAuth source files)
               TestBed\
               README.md
               ...
   ```
    Our modified SteamAuth.csproj must exist in `lib\SteamAuth\SteamAuth\SteamAuth.csproj`.

4. **Open and build**
   - Open `SteamDesktopAuthenticator.sln` in Visual Studio.
   - Build **SteamAuth** first: In Solution Explorer, right‑click **SteamAuth** → **Build**.
   - Then build **Steam Desktop Authenticator**: right‑click **Steam Desktop Authenticator** → **Build**, or use **Build → Build Solution**.

   - Set **Steam Desktop Authenticator** as the startup project, then run (F5 or **Debug → Start Debugging**).

---

## Build output

- **Debug:** `SDA\bin\Debug\net8.0-windows\`
- **Release:** `SDA\bin\Release\net8.0-windows\`

The executable is **Steam Desktop Authenticator.exe**.

## Troubleshooting

- **SteamAuth project missing or path errors**  
  Confirm `lib\SteamAuth\SteamAuth\SteamAuth.csproj` exists. If you used Option B, re-extract SteamAuth so the folder structure matches the layout above.

- **.NET 8 not found**  
  Install the [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) and/or the “.NET desktop development” workload in Visual Studio Installer.

- **Build order**  
  Always build **SteamAuth** before **Steam Desktop Authenticator**. Using **Build Solution** does this automatically.
