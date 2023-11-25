SET BuildFolder=..\src\LivePictureViewer\bin\Debug\net8.0-windows
SET DestFolder=C:\Users\scott\Documents\important\apps\LivePictureViewer

rmdir /q/s %BuildFolder%
dotnet build ..\src
robocopy %BuildFolder% %DestFolder% /E /Z /R:5 /W:5 /TBD /NP /V /XF *.html
pause