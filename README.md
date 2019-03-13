### Adding to the righ click menu

Open regedit and go to HKEY_LOCAL_MACHINE\SOFTWARE\Classes\*\shell\ and create new Key, name it "Convert To Pdf"
then create another Key "command" for "Convert To Pdf" 

In "command" key update default value and set the path to "<Full path to git folder>/build/ImagesToPdf.exe %1"

So finally you should have the value set for the key:
\HKEY_LOCAL_MACHINE\SOFTWARE\Classes\*\shell\Convert To Pdf\command

Default value should be like: "D:\Work\ImagesToPdf\build\ImagesToPdf.exe %1"
