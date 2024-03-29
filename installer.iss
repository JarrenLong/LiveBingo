; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Live Bingo!"
#define MyAppVersion "1.5"
#define MyAppPublisher "Books N' Bytes, Inc."
#define MyAppURL "https://www.booksnbytes.net"
#define MyAppExeName "LiveBingo.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{591FFBC5-E9B5-4960-A249-15E908883D4C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableDirPage=yes
DisableProgramGroupPage=yes
OutputBaseFilename=setup-LiveBingo_{#MyAppVersion}
;SetupIconFile=.\necca.ico
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: ".\bin\Debug\NET45\LiveBingo.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bin\Debug\NET45\LongTech.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bin\Debug\NET45\LongTech.Portable.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bin\Debug\NET45\LongTech.UI.Controls.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bin\Debug\NET45\LongTech.UI.Theme.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bin\Debug\NET45\AForge.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bin\Debug\NET45\AForge.Imaging.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bin\Debug\NET45\AForge.Math.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bin\Debug\NET45\AForge.Video.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\bin\Debug\NET45\AForge.Video.DirectShow.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commonstartup}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

