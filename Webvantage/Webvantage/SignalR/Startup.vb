Imports Owin
Imports Microsoft.Owin
Imports Microsoft.AspNet.SignalR
Imports Microsoft.AspNet.SignalR.SqlServer
Imports Microsoft.Win32

<Assembly: OwinStartup(GetType(SignalR.Classes.Startup))>
Namespace SignalR.Classes

    Public Class Startup

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ConnectionString As String = String.Empty

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Public Sub Configuration(app As IAppBuilder)

            _ConnectionString = SignalR.Classes.BaseHub.GetAdminConnectionString()

            If String.IsNullOrWhiteSpace(_ConnectionString) = False Then

                'GlobalHost.Configuration.KeepAlive = TimeSpan.FromMinutes(60)
                GlobalHost.Configuration.DisconnectTimeout = New TimeSpan(2, 0, 0)
                GlobalHost.Configuration.KeepAlive = New TimeSpan(0, 30, 0)
                GlobalHost.DependencyResolver.UseSqlServer(_ConnectionString)

            End If

            ' Any connection or hub wire up and configuration should go here
            app.MapSignalR()

        End Sub

#End Region

    End Class

End Namespace
