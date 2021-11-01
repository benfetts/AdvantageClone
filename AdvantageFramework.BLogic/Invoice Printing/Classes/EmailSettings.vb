Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class EmailSettings

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IncludeAPDocuments
            IncludeExpenseReportReceipts
			PackageType
			SendToDocumentManager
            IncludeCoverSheet
            CCToSender
            SendSingleEmail
            SenderName
            FromEmail
            ReplyTo
            Subject
            Body
            ToRecipients
            CCRecipients
            BCCRecipients
			AutoEmailContacts
			SinglePDF
		End Enum

#End Region

#Region " Variables "

        Private _IncludeAPDocuments As Boolean = False
		Private _IncludeExpenseReportReceipts As Boolean = False
		Private _PackageType As AdvantageFramework.InvoicePrinting.PackageTypes = PackageTypes.None
		Private _SendToDocumentManager As Boolean = False
        Private _IncludeCoverSheet As Boolean = False
        Private _CCToSender As Boolean = False
        Private _SendSingleEmail As Boolean = False
        Private _SenderName As String = ""
        Private _FromEmail As String = ""
        Private _ReplyTo As String = ""
        Private _Subject As String = ""
        Private _Body As String = ""
        Private _ToRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
        Private _CCRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
        Private _BCCRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
		Private _AutoEmailContacts As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact) = Nothing
		Private _SinglePDF As Boolean = False

#End Region

#Region " Properties "

		<System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeAPDocuments() As Boolean
            Get
                IncludeAPDocuments = _IncludeAPDocuments
            End Get
            Set(ByVal value As Boolean)
                _IncludeAPDocuments = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property IncludeExpenseReportReceipts() As Boolean
			Get
				IncludeExpenseReportReceipts = _IncludeExpenseReportReceipts
			End Get
			Set(ByVal value As Boolean)
				_IncludeExpenseReportReceipts = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property PackageType() As AdvantageFramework.InvoicePrinting.PackageTypes
			Get
				PackageType = _PackageType
			End Get
			Set(ByVal value As AdvantageFramework.InvoicePrinting.PackageTypes)
				_PackageType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SendToDocumentManager() As Boolean
            Get
                SendToDocumentManager = _SendToDocumentManager
            End Get
            Set(ByVal value As Boolean)
                _SendToDocumentManager = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeCoverSheet() As Boolean
            Get
                IncludeCoverSheet = _IncludeCoverSheet
            End Get
            Set(ByVal value As Boolean)
                _IncludeCoverSheet = value
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
        Public Property SendSingleEmail() As Boolean
            Get
                SendSingleEmail = _SendSingleEmail
            End Get
            Set(ByVal value As Boolean)
                _SendSingleEmail = value
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
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property AutoEmailContacts As IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact)
			Get
				AutoEmailContacts = _AutoEmailContacts
			End Get
			Set(ByVal value As IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact))
				_AutoEmailContacts = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property SinglePDF() As Boolean
			Get
				SinglePDF = _SinglePDF
			End Get
			Set(ByVal value As Boolean)
				_SinglePDF = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

            ToString = Me.IncludeAPDocuments.ToString

        End Function

#End Region

    End Class

End Namespace
