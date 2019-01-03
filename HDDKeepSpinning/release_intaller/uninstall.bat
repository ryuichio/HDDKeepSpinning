@echo off
openfiles > NUL 2>&1
if NOT %ERRORLEVEL% EQU 0 goto NotAdmin
cd /d %~dp0
net stop HDDKeepSpinning
%windir%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u HDDKeepSpinning.exe
goto End
:NotAdmin 
echo [ERROR] Needed to run as Administrator
:End
pause