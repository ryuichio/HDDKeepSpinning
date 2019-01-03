@echo off
openfiles > NUL 2>&1
if NOT %ERRORLEVEL% EQU 0 goto NotAdmin
net start HDDKeepSpinning
goto End
:NotAdmin 
echo [ERROR] Needed to run as Administrator
:End