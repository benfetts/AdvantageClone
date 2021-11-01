Namespace Reporting.Database.Classes

    <Serializable>
    Public Class AccountsReceivableBalanceByClient

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ARGLAccount
            ClientCode
            ClientDescription
            ClientStatementAddress1
            ClientStatementAddress2
            ClientStatementCityStateZip
            ClientStatementCountry
            ClientBillingAddress1
            ClientBillingAddress2
            ClientBillingCityStateZip
            ClientBillingCountry
            ClientBillingAttention
            ClientARComment
            TotalInvoiceAmount
            CashReceipts
            CRAdjustments
            TotalReceiptsAndAdjustments
            InvoiceBalance
            OnAccountBalance
            InvoiceBalanceWithOA
            MappedAccount
            TargetAccount
            AbsoluteAmount
            DebitOrCredit
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _ARGLAccount As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _ClientStatementAddress1 As String = Nothing
        Private _ClientStatementAddress2 As String = Nothing
        Private _ClientStatementCityStateZip As String = Nothing
        Private _ClientStatementCountry As String = Nothing
        Private _ClientBillingAddress1 As String = Nothing
        Private _ClientBillingAddress2 As String = Nothing
        Private _ClientBillingCityStateZip As String = Nothing
        Private _ClientBillingCountry As String = Nothing
        Private _ClientBillingAttention As String = Nothing
        Private _ClientARComment As String = Nothing
        Private _TotalInvoiceAmount As Nullable(Of Decimal) = Nothing
        Private _CashReceipts As Nullable(Of Decimal) = Nothing
        Private _CRAdjustments As Nullable(Of Decimal) = Nothing
        Private _TotalReceiptsAndAdjustments As Nullable(Of Decimal) = Nothing
        Private _InvoiceBalance As Nullable(Of Decimal) = Nothing
        Private _OnAccountBalance As Nullable(Of Decimal) = Nothing
        Private _InvoiceBalanceWithOA As Nullable(Of Decimal) = Nothing
        Private _MappedAccount As String = Nothing
        Private _TargetAccount As String = Nothing
        Private _DebitOrCredit As String = Nothing
        Private _AbsoluteAmount As Decimal? = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="AR GL Account")>
        Public Property ARGLAccount() As String
            Get
                ARGLAccount = _ARGLAccount
            End Get
            Set(value As String)
                _ARGLAccount = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(value As String)
                _ClientDescription = value
            End Set
        End Property
        Public Property ClientStatementAddress1() As String
            Get
                ClientStatementAddress1 = _ClientStatementAddress1
            End Get
            Set(value As String)
                _ClientStatementAddress1 = value
            End Set
        End Property
        Public Property ClientStatementAddress2() As String
            Get
                ClientStatementAddress2 = _ClientStatementAddress2
            End Get
            Set(value As String)
                _ClientStatementAddress2 = value
            End Set
        End Property
        Public Property ClientStatementCityStateZip() As String
            Get
                ClientStatementCityStateZip = _ClientStatementCityStateZip
            End Get
            Set(value As String)
                _ClientStatementCityStateZip = value
            End Set
        End Property
        Public Property ClientStatementCountry() As String
            Get
                ClientStatementCountry = _ClientStatementCountry
            End Get
            Set(value As String)
                _ClientStatementCountry = value
            End Set
        End Property
        Public Property ClientBillingAddress1() As String
            Get
                ClientBillingAddress1 = _ClientBillingAddress1
            End Get
            Set(value As String)
                _ClientBillingAddress1 = value
            End Set
        End Property
        Public Property ClientBillingAddress2() As String
            Get
                ClientBillingAddress2 = _ClientBillingAddress2
            End Get
            Set(value As String)
                _ClientBillingAddress2 = value
            End Set
        End Property
        Public Property ClientBillingCityStateZip() As String
            Get
                ClientBillingCityStateZip = _ClientBillingCityStateZip
            End Get
            Set(value As String)
                _ClientBillingCityStateZip = value
            End Set
        End Property
        Public Property ClientBillingCountry() As String
            Get
                ClientBillingCountry = _ClientBillingCountry
            End Get
            Set(value As String)
                _ClientBillingCountry = value
            End Set
        End Property
        Public Property ClientBillingAttention() As String
            Get
                ClientBillingAttention = _ClientBillingAttention
            End Get
            Set(value As String)
                _ClientBillingAttention = value
            End Set
        End Property
        Public Property ClientARComment() As String
            Get
                ClientARComment = _ClientARComment
            End Get
            Set(value As String)
                _ClientARComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property TotalInvoiceAmount() As Nullable(Of Decimal)
            Get
                TotalInvoiceAmount = _TotalInvoiceAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalInvoiceAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CashReceipts() As Nullable(Of Decimal)
            Get
                CashReceipts = _CashReceipts
            End Get
            Set(value As Nullable(Of Decimal))
                _CashReceipts = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CRAdjustments() As Nullable(Of Decimal)
            Get
                CRAdjustments = _CRAdjustments
            End Get
            Set(value As Nullable(Of Decimal))
                _CRAdjustments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property TotalReceiptsAndAdjustments() As Nullable(Of Decimal)
            Get
                TotalReceiptsAndAdjustments = _TotalReceiptsAndAdjustments
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalReceiptsAndAdjustments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property InvoiceBalance() As Nullable(Of Decimal)
            Get
                InvoiceBalance = _InvoiceBalance
            End Get
            Set(value As Nullable(Of Decimal))
                _InvoiceBalance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property OnAccountBalance() As Nullable(Of Decimal)
            Get
                OnAccountBalance = _OnAccountBalance
            End Get
            Set(value As Nullable(Of Decimal))
                _OnAccountBalance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property InvoiceBalanceWithOA() As Nullable(Of Decimal)
            Get
                InvoiceBalanceWithOA = _InvoiceBalanceWithOA
            End Get
            Set(value As Nullable(Of Decimal))
                _InvoiceBalanceWithOA = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AbsoluteAmount() As Nullable(Of Decimal)
            Get
                AbsoluteAmount = _AbsoluteAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AbsoluteAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property DebitOrCredit() As String
            Get
                DebitOrCredit = _DebitOrCredit
            End Get
            Set(value As String)
                _DebitOrCredit = value
            End Set
        End Property
        Public Property MappedAccount() As String
            Get
                MappedAccount = _MappedAccount
            End Get
            Set(value As String)
                _MappedAccount = value
            End Set
        End Property
        Public Property TargetAccount() As String
            Get
                TargetAccount = _TargetAccount
            End Get
            Set(value As String)
                _TargetAccount = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ARGLAccount.ToString

        End Function

#End Region

    End Class

End Namespace
