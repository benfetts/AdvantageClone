Public Class WizardInputs

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property ServerName As String
    Public Property Database As String
    Public Property UserName As String
    Public Property Password As String

    Public ReadOnly Property ConnectionString As String
        Get
            ConnectionString = AdvantageFramework.Database.CreateConnectionString(Me.ServerName, Me.Database, False, Me.UserName, Me.Password)
        End Get
    End Property

    Public Property DatabaseHasAlreadyBeenConverted As Boolean
    Public Property AdvantageUserSelected As Boolean
    Public Property AdvantageUserName As String
    Public Property AdvantagePassword As String
    Public Property IsAdvantageUserInDB As Boolean

    Public Property AdvantageConnectionFolder As String

    Public Property WebvantageURL As String

#End Region

#Region " Methods "



#End Region

End Class
