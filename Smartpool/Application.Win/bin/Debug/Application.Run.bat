@echo off
start ..\..\..\Connection.Server\bin\Debug\Connection.Server.exe
set ip_address_string="IPv4 Address"
for /f "usebackq tokens=2 delims=:" %%f in (`ipconfig ^| findstr /c:%ip_address_string%`) do ( <nul set /p ".=%%f" > IpTextFile.txt
goto next
)
:next
start Application.Win.exe
exit