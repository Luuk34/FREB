# FREB
Converts an XML from the Failed Request logs (IIS) to an HTML


you can convert all XML files from the logging to HTML files (in the same directory, using: 

```
C:\inetpub\logs\FailedReqLogFiles\W3SVC1>for /f "usebackq" %f in (`dir /b *.xml`) do FREB.exe %f
``` 

