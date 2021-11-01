Imports Microsoft.AspNet.SignalR

Public Class CustomUserIdProvider
    Implements IUserIdProvider

    Public Function GetUserId(request As IRequest) As String Implements IUserIdProvider.GetUserId

        Return HttpContext.Current.Session("EmpCode")

    End Function

End Class
