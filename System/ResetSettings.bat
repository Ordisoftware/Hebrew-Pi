@echo off
taskkill /im Ordisoftware.Hebrew.Pi.exe
ping localhost -n 3 >NUL
start "" ..\Bin\Ordisoftware.Hebrew.Pi.exe --reset