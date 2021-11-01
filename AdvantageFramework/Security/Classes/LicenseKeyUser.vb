Namespace Security.Classes

    Public Class LicenseKeyUser

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            IsInactive
            IsPowerUser
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID() As Integer
        Public Property UserCode() As String
        Public Property IsInactive() As Boolean
        Public Property IsPowerUser() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.UserCode = String.Empty
            Me.IsInactive = False
            Me.IsPowerUser = False

        End Sub

#End Region

    End Class

End Namespace