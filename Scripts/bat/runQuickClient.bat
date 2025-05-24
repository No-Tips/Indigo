@echo off
cd ../../

start pklEval.bat %*
call dotnet run --project Content.Client --no-build %*

pause
