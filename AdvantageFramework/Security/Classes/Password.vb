Namespace Security.Classes

    <Serializable()>
    Public Class Password

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ServerName As String = String.Empty
        Public Property DatabaseName As String = String.Empty
        Public Property UserCode As String = String.Empty
        Public Property Key As String = String.Empty
        Public Property SentDateTime As DateTime? = Nothing
        Public Property CurrentPassword As String = String.Empty
        Public Property NewPassword As String = String.Empty
        Public Property IsValid As Boolean = False
        Public Property ConnectionString As String = String.Empty
        Public Property ConnectionUserName As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class
    <Serializable()> Public Class PasswordUser
        Public Property ID As Integer = 0
        Public Property UserCode As String = String.Empty
        Public Property EmployeeCode As String = String.Empty
        Public Property FirstName As String = String.Empty
        Public Property MiddleInitial As String = String.Empty
        Public Property LastName As String = String.Empty
        Public Property FullName As String = String.Empty
        Public Property Password As String = String.Empty
        Public Property IsLocked As Boolean = False
        Public Property LockDate As DateTime? = Nothing
        Public Property FailedAttempts As Integer = 0
        Public Property ConnectionString As String = String.Empty
        Sub New()

        End Sub
    End Class

End Namespace
