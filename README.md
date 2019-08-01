UWP app targeting build 16299

This example has two buttons. 

One for handled (exception caught in the catch block by application code) and unhandled exceptions which crashes the app.

Both are correctly captured by the SDK and include stack traces.
UnhandledException are captured via the subscription to `App.UnhandledException` done in `App`'s constructor. The queue is flushed by disposing off of the SDK (`SentrySdk.Close()`)

Tested in Debug and Release builds, fired up from within Visual Studio and also _Deployed_ to Windows 10.
Default _Deploy_ method was used. No attempt to avoid publishing the PDBs with the app were done.

Example of handled error:
![Sample event in Sentry](UWP-CSharp-Windows10.png)
