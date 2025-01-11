#define MyAppVersion "0.1"
#define MyAppName "Hebrew Pi"
#define MyAppNameNoSpace "HebrewPi"
#define MyAppExeName "Ordisoftware.Hebrew.Pi.exe"
#define MyAppPublisher "Ordisoftware"
#define MyAppURL "https://www.ordisoftware.com/projects/hebrew-pi"

[Setup]
MinVersion=0,6.1sp1
LicenseFile=..\Project\Licenses\MPL 2.0.rtf
AppCopyright=Copyright 2025 Olivier Rogier
AppId={{61CBB6A1-8EBC-4C9F-A517-D872F06C6983}
;AppMutex=68dc2d2f-143a-4d06-9b04-534539b6051d
#include "Scripts\Setup.iss"

[Languages]
#include "Scripts\Languages.iss"

[Dirs]

[InstallDelete]
#include "Scripts\InstallDelete.iss"

[Files]
#include "Scripts\Files.iss"
#include "Scripts\FilesHebrewFont.iss"

[Run]
#include "Scripts\Run.iss"

[Registry]

[Tasks]
#include "Scripts\Tasks.iss"

[Icons]
#include "Scripts\Icons.iss"

[CustomMessages]
#include "Scripts\Messages.iss"

[Code]
#include "Scripts\CheckDotNetFramework.iss"
