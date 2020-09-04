@ECHO OFF
setlocal enabledelayedexpansion
FOR  %%G IN (.\1.0.0\*.sql) DO (
sqlcmd -S %1 -d %2 -E -h-1 -w255 -i "%%G" -b
echo   %%G  -  !ERRORLEVEL!
IF !ERRORLEVEL! NEQ 0 EXIT /B !ERRORLEVEL!
)

FOR  %%G IN (.\1.1.0\*.sql) DO (
sqlcmd -S %1 -d %2 -E -h-1 -w255 -i "%%G" -b
echo   %%G  -  !ERRORLEVEL!
IF !ERRORLEVEL! NEQ 0 EXIT /B !ERRORLEVEL!
)