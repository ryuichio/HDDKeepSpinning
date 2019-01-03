@echo off
openfiles > NUL 2>&1
if NOT %ERRORLEVEL% EQU 0 goto NotAdmin
%windir%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe HDDKeepSpinning.exe
sc config HDDKeepSpinning start=delayed-auto
net start HDDKeepSpinning
goto End
:NotAdmin 
echo [ERROR] Needed to run as Administrator
:End