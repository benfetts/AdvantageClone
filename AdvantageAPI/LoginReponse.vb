<DataContract>
Public Class LoginReponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property LoggedIn As Boolean
    <DataMember>
    Public Property SessionID As String
    <DataMember>
    Public Property ErrorMessage As String

#End Region

#Region " Methods "

    Friend Sub New()



    End Sub
    Friend Sub New(ByVal LoggedIn As Boolean, ByVal SessionID As String, ByVal ErrorMessage As String)

        Me.LoggedIn = LoggedIn
        Me.SessionID = SessionID
        Me.ErrorMessage = ErrorMessage

    End Sub

#End Region

End Class
