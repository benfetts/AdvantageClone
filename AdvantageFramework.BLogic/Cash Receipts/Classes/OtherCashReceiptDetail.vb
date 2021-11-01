Namespace CashReceipts.Classes

    <Serializable()>
    Public Class OtherCashReceiptDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLACode
            GLACodeDescription
            Amount
            Comment
        End Enum

#End Region

#Region " Variables "

        Private _OtherCashReceiptDetail As AdvantageFramework.Database.Entities.OtherCashReceiptDetail = Nothing
        Private _GLACodeDescription As String = Nothing
        Private _IsDeleted As Boolean = False
        Private _OriginalGLACode As String = Nothing
        Private _OriginalAmount As Decimal = Nothing

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.OtherCashReceiptDetail)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property OtherCashReceiptDetail As AdvantageFramework.Database.Entities.OtherCashReceiptDetail
            Get
                OtherCashReceiptDetail = _OtherCashReceiptDetail
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode, CustomColumnCaption:="GL Account")>
        Public Property GLACode() As String
            Get
                GLACode = _OtherCashReceiptDetail.GLACode
            End Get
            Set(value As String)
                _OtherCashReceiptDetail.GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="GL Account Description", DefaultColumnType:=BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription)>
        Public Property GLACodeDescription() As String
            Get
                GLACodeDescription = _GLACodeDescription
            End Get
            Set(value As String)
                _GLACodeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property Amount() As Decimal
            Get
                Amount = _OtherCashReceiptDetail.Amount.GetValueOrDefault(0)
            End Get
            Set(value As Decimal)
                _OtherCashReceiptDetail.Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Comment() As String
            Get
                Comment = _OtherCashReceiptDetail.Comment
            End Get
            Set(value As String)
                _OtherCashReceiptDetail.Comment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsDeleted() As Boolean
            Get
                IsDeleted = _IsDeleted
            End Get
            Set(ByVal value As Boolean)
                _IsDeleted = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OriginalGLACode() As String
            Get
                OriginalGLACode = _OriginalGLACode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OriginalAmount() As Decimal
            Get
                OriginalAmount = _OriginalAmount
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _OtherCashReceiptDetail = New AdvantageFramework.Database.Entities.OtherCashReceiptDetail

        End Sub
        Public Sub New(ByVal OtherCashReceiptDetail As AdvantageFramework.Database.Entities.OtherCashReceiptDetail)

            _OtherCashReceiptDetail = OtherCashReceiptDetail
            _GLACodeDescription = _OtherCashReceiptDetail.GeneralLedgerAccount.Description
            _OriginalGLACode = _OtherCashReceiptDetail.GLACode
            _OriginalAmount = _OtherCashReceiptDetail.Amount.GetValueOrDefault(0)

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.CashReceipts.Classes.OtherCashReceipt.Properties.GLACode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If (From Entity In AdvantageFramework.CashReceipts.GetGLAccountListExcludeBankARAPCashAccounts(DbContext)
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Invalid GL Account."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

