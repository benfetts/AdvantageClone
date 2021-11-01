Namespace NielsenDataStore.Classes

    <Microsoft.AspNet.SignalR.Hubs.HubName("Nielsen")>
    Public Class NielsenHub
        Inherits Microsoft.AspNet.SignalR.Hub

        Public Sub NewDataReady()

            'objects
            Dim IHubContext As Microsoft.AspNet.SignalR.IHubContext = Nothing

            Try

                IHubContext = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext("Nielsen")

                If IHubContext IsNot Nothing Then

                    IHubContext.Clients.All.NewDataReady()

                End If

            Catch ex As Exception

            End Try

        End Sub

    End Class

End Namespace