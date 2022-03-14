# FREB
Converts an XML from the Failed Request logs (IIS) to an HTML


You can convert all XML files from the logging to HTML files (in the same directory, using: 

```
C:\inetpub\logs\FailedReqLogFiles\W3SVC1>for /f "usebackq" %f in (`dir /b *.xml`) do FREB.exe %f
``` 


Currently this tool only converts the XML to HTML. The same functionality be achieved by adding a virtual directory in IIS, to the dorectory: "C:\inetpub\logs\FailedReqLogFiles\W3SVC1".  The user "IUSR" needs to be given read rights in that directory.

TODO:
- Current solution makes "Compact View" visible. The tabs "Request Summary" and "Request Details" should be visible too.
- ?

