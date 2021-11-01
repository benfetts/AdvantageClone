Namespace ViewModels.UserAccount

    <Serializable()>
    Public Class PasswordIndexViewModel

#Region " Constants "



#End Region

#Region " Enum "
        Public Enum Properties

            IsExpired
            FullName
            FirstName
            LastName
            EmailAddress
            IsValid
            Message
            HasPassword

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property IsExpired As Boolean = False
        Public Property FullName As String = String.Empty
        Public Property FirstName As String = String.Empty
        Public Property LastName As String = String.Empty
        Public Property EmailAddress As String = String.Empty
        Public Property IsValid As Boolean = False
        Public Property Message As String = String.Empty
        Public Property HasPassword As Boolean = False

#End Region

#Region " Methods "

        Sub New()

            IsValid = True

        End Sub

#End Region

    End Class

End Namespace
