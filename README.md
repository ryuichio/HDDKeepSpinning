# HDDKeepSpinning
A simple Windows service that keeps spinning your external HDDs

External HDDs connected with USB will spin down very shortly after Windows 8 era. It causes frequently repeated spinning-up and down in short time while using a PC. This makes me (and probably you) worry about it reduces life expectancy of the HDDs. This tool enables to keep spinning up external HDDs with accessing them periodically. Yes, it's simple. Um, if you know smarter way to keep spininng, tell me about it or ignore this repository and use just a simple Windows service sample code :-P

[![Build status](https://ryuichioana.visualstudio.com/HDDKeepSpinning/_apis/build/status/HDDKeepSpinning-.NET%20Desktop-CI)](https://ryuichioana.visualstudio.com/HDDKeepSpinning/_build/latest?definitionId=1)

## How to install

1. Extract zip to an appropriate folder such as `C:\tools\HDDKeepSpinning`
2. Open `HDDKeepSpinning.exe.config` with the notepad or something and specifiy target drives on `<add key="Targets" value="<<Drive Letter(s)>>" />`
  * i.e. if you have 1 external drive named `D:`
  ```xml
  <add key="Targets" value="D">
  ```  
  * i.e. if you have 3 external drives named `X:`, `Y:` and `Z:`
  ```xml
  <add key="Targets" value="XYZ">
  ```
3. Run `install.bat` with administrative privileges

## How to uninstall

Run `uninstall.bat` with administrative privileges
To uninstall completely, remove all files (this doesn't modify registries or something)

## How to build and debug

1. Open `HDDKeepSpinning.sln` from VS2015 or VS2017 running with administrative privileges
1. Build it
1. Run `debug_tool\install.bat` to install
1. Run `debug_tool\run.bat` to start the service
1. Attach the Visual Studio as a debugger and debug
1. Run `debug_tool\stop.bat` to stop
1. Run `debug_tool\uninstall.bat` to uninstall the service

## Release Note

|Date|Ver.|Description|
|----|----|-----------|
|2019 Jan 3|v.0.1.0|First release|
|2019 Jan 9|v.0.1.1|update readme|
