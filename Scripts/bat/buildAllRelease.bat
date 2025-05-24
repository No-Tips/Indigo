@echo off
cd ../../

call git submodule update --init --recursive
call dotnet build -c Release
start genTypings.bat %*

pause
