Namespace Email.Classes

    <Serializable>
    Public Class RecipientEmailAddress

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmailAddress
        End Enum

#End Region

#Region " Variables "

        Private _EmailAddress As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmailAddress() As String
            Get
                EmailAddress = _EmailAddress
            End Get
            Set(value As String)
                _EmailAddress = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(EmailAddress As String)

            _EmailAddress = EmailAddress

        End Sub

#End Region

    End Class

End Namespace
