Imports Owin
'Imports Microsoft.Owin
'Imports Microsoft.AspNet.SignalR
'Imports Microsoft.Win32

<Assembly: Microsoft.Owin.OwinStartup(GetType(NielsenDataStore.Classes.Startup))>
Namespace NielsenDataStore.Classes

    Public Class Startup

        Public Sub Configuration(app As IAppBuilder)

            'app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll)
            app.MapSignalR()

        End Sub

    End Class

End Namespace