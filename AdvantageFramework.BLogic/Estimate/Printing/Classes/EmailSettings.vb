Namespace Estimate.Printing.Classes

    <Serializable()>
    Public Class EmailSettings

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PackageType
            CCToSender
            SenderName
            FromEmail
            ReplyTo
            Subject
            Body
            ToRecipients
            CCRecipients
            BCCRecipients
            AutoEmailContacts
        End Enum

#End Region

#Region " Variables "

        Private _PackageType As AdvantageFramework.Estimate.Printing.PackageTypes = PackageTypes.None
        Private _CCToSender As Boolean = False
        Private _SenderName As String = ""
        Private _FromEmail As String = ""
        Private _ReplyTo As String = ""
        Private _Subject As String = ""
        Private _Body As String = ""
        Private _ToRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
        Private _CCRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
        Private _BCCRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing

#End Region

#Region " Properties "

        Public Property PackageType() As AdvantageFramework.InvoicePrinting.PackageTypes
            Get
                PackageType = _PackageType
            End Get
            Set(ByVal value As AdvantageFramework.InvoicePrinting.PackageTypes)
                _PackageType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CCToSender() As Boolean
            Get
                CCToSender = _CCToSender
            End Get
            Set(ByVal value As Boolean)
                _CCToSender = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SenderName As String
            Get
                SenderName = _SenderName
            End Get
            Set(ByVal value As String)
                _SenderName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FromEmail As String
            Get
                FromEmail = _FromEmail
            End Get
            Set(ByVal value As String)
                _FromEmail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReplyTo As String
            Get
                ReplyTo = _ReplyTo
            End Get
            Set(ByVal value As String)
                _ReplyTo = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Subject As String
            Get
                Subject = _Subject
            End Get
            Set(ByVal value As String)
                _Subject = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Body As String
            Get
                Body = _Body
            End Get
            Set(ByVal value As String)
                _Body = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ToRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)
            Get
                ToRecipients = _ToRecipients
            End Get
            Set(ByVal value As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress))
                _ToRecipients = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CCRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)
            Get
                CCRecipients = _CCRecipients
            End Get
            Set(ByVal value As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress))
                _CCRecipients = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BCCRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)
            Get
                BCCRecipients = _BCCRecipients
            End Get
            Set(ByVal value As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress))
                _BCCRecipients = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Body.ToString

        End Function

#End Region

    End Class

End Namespace
