#!/bin/sh
clear

slnfile=$(ls *.sln | tail -n 1)
projname=${slnfile%.*}

vslink="/Applications/Visual Studio.app"

dotnet build $slnfile

"$vslink/Contents/MacOS/vstool" setup pack $PWD/$projname/bin/$projname.dll -d:$PWD 
