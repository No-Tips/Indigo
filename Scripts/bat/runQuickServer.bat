@echo off
cd ../../

start pklEval.bat %*
call dotnet run --project Content.Server --no-build %*

pause
