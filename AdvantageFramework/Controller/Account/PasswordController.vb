Namespace Controller.Account

    Public Class PasswordController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Password "
        Public Function Validate(SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                 UserCode As String,
                                 Password As String,
                                 ByRef ErrorMessages As Generic.List(Of String)) As Boolean

            Return AdvantageFramework.Security.ValidatePassword(SecurityDbContext, UserCode, Password, ErrorMessages)

        End Function
        Public Function IsPasswordExpired(SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                          UserCode As String,
                                          ByRef ErrorMessage As String) As Boolean

            Return AdvantageFramework.Security.IsPasswordExpired(SecurityDbContext, UserCode, ErrorMessage)

        End Function

#End Region
        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Sub New()

            MyBase.New(Nothing)

        End Sub

#End Region

    End Class

End Namespace


