Namespace Database.Classes

    <Serializable()>
    Public Class AccountsPayablePaymentHistory
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            APIdentifier
            APSequence
            BankCode
            CheckNumber
            CheckDate
            GLAccountCodeCash
            GLAccountCodeAP
            GLAccountCodeDiscount
            GLAccountCodeWithholding
            GLAccountCodeExchange
            APCheckAmount
            APDiscountAmount
            VendorServiceTaxAmount
            CurrencyExchangeAmount
            HomeCurrencyCode
            BankCurrencyCode
            APCurrencyCode
            PaymentPostingPeriod
            APGLXact
            APGLSeqCash
            APGLSeqAP
            APGLSeqDISC
            APGLSeqWithholding
            ManualCheck
            PaymentEntryDate
            APPaymentAmount
            ExchangeApplied
            CurrencyRate
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _APIdentifier As Integer = Nothing
        Private _APSequence As Int16 = Nothing
        Private _BankCode As String = Nothing
        Private _CheckNumber As Integer = Nothing
        Private _CheckDate As Nullable(Of Date) = Nothing
        Private _GLAccountCodeCash As String = Nothing
        Private _GLAccountCodeAP As String = Nothing
        Private _GLAccountCodeDiscount As String = Nothing
        Private _GLAccountCodeWithholding As String = Nothing
        Private _GLAccountCodeExchange As String = Nothing
        Private _APCheckAmount As Nullable(Of Decimal) = Nothing
        Private _APDiscountAmount As Nullable(Of Decimal) = Nothing
        Private _VendorServiceTaxAmount As Nullable(Of Decimal) = Nothing
        Private _CurrencyExchangeAmount As Nullable(Of Decimal) = Nothing
        Private _HomeCurrencyCode As String = Nothing
        Private _BankCurrencyCode As String = Nothing
        Private _APCurrencyCode As String = Nothing
        Private _PaymentPostingPeriod As String = Nothing
        Private _APGLXact As Integer = Nothing
        Private _APGLSeqCash As Nullable(Of Int16) = Nothing
        Private _APGLSeqAP As Nullable(Of Int16) = Nothing
        Private _APGLSeqDISC As Nullable(Of Int16) = Nothing
        Private _APGLSeqWithholding As Nullable(Of Int16) = Nothing
        Private _ManualCheck As Nullable(Of Int16) = Nothing
        Private _PaymentEntryDate As Nullable(Of Date) = Nothing
        Private _APPaymentAmount As Nullable(Of Decimal) = Nothing
        Private _ExchangeApplied As Nullable(Of Int32) = Nothing
        Private _CurrencyRate As Nullable(Of Decimal) = Nothing


#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Check Date")>
        Public Property CheckDate() As Date
            Get
                CheckDate = _CheckDate
            End Get
            Set(ByVal value As Date)
                _CheckDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="A/P Amount")>
        Public Property APPaymentAmount() As Decimal
            Get
                APPaymentAmount = _APPaymentAmount
            End Get
            Set(ByVal value As Decimal)
                _APPaymentAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="A/P Account")>
        Public Property GLAccountCodeAP() As String
            Get
                GLAccountCodeAP = _GLAccountCodeAP
            End Get
            Set(ByVal value As String)
                _GLAccountCodeAP = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Discount Amount")>
        Public Property APDiscountAmount() As Nullable(Of Decimal)
            Get
                APDiscountAmount = _APDiscountAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _APDiscountAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Currency Code")>
        Public Property HomeCurrencyCode() As String
            Get
                HomeCurrencyCode = _HomeCurrencyCode
            End Get
            Set(ByVal value As String)
                _HomeCurrencyCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n6", CustomColumnCaption:="Currency Rate")>
        Public Property CurrencyRate() As Nullable(Of Decimal)
            Get
                CurrencyRate = _CurrencyRate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrencyRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Currency Amount")>
        Public Property CurrencyExchangeAmount() As Nullable(Of Decimal)
            Get
                CurrencyExchangeAmount = _CurrencyExchangeAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrencyExchangeAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property APIdentifier() As Integer
            Get
                APIdentifier = _APIdentifier
            End Get
            Set(ByVal value As Integer)
                _APIdentifier = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property APSequence() As Int16
            Get
                APSequence = _APSequence
            End Get
            Set(ByVal value As Int16)
                _APSequence = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property BankCode() As String
            Get
                BankCode = _BankCode
            End Get
            Set(ByVal value As String)
                _BankCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CheckNumber() As Integer
            Get
                CheckNumber = _CheckNumber
            End Get
            Set(ByVal value As Integer)
                _CheckNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property GLAccountCodeCash() As String
            Get
                GLAccountCodeCash = _GLAccountCodeCash
            End Get
            Set(ByVal value As String)
                _GLAccountCodeCash = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property GLAccountCodeDiscount() As String
            Get
                GLAccountCodeDiscount = _GLAccountCodeDiscount
            End Get
            Set(ByVal value As String)
                _GLAccountCodeDiscount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="VST Account")>
        Public Property GLAccountCodeWithholding() As String
            Get
                GLAccountCodeWithholding = _GLAccountCodeWithholding
            End Get
            Set(ByVal value As String)
                _GLAccountCodeWithholding = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property GLAccountCodeExchange() As String
            Get
                GLAccountCodeExchange = _GLAccountCodeExchange
            End Get
            Set(ByVal value As String)
                _GLAccountCodeExchange = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property APCheckAmount() As Decimal
            Get
                APCheckAmount = _APCheckAmount
            End Get
            Set(ByVal value As Decimal)
                _APCheckAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="VST Amount")>
        Public Property VendorServiceTaxAmount() As Nullable(Of Decimal)
            Get
                VendorServiceTaxAmount = _VendorServiceTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _VendorServiceTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property BankCurrencyCode() As String
            Get
                BankCurrencyCode = _BankCurrencyCode
            End Get
            Set(ByVal value As String)
                _BankCurrencyCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property APCurrencyCode() As String
            Get
                APCurrencyCode = _APCurrencyCode
            End Get
            Set(ByVal value As String)
                _APCurrencyCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property PaymentPostingPeriod() As String
            Get
                PaymentPostingPeriod = _PaymentPostingPeriod
            End Get
            Set(ByVal value As String)
                _PaymentPostingPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property APGLXact() As Integer
            Get
                APGLXact = _APGLXact
            End Get
            Set(ByVal value As Integer)
                _APGLXact = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property APGLSeqCash() As Nullable(Of Int16)
            Get
                APGLSeqCash = _APGLSeqCash
            End Get
            Set(ByVal value As Nullable(Of Int16))
                _APGLSeqCash = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property APGLSeqAP() As Nullable(Of Int16)
            Get
                APGLSeqAP = _APGLSeqAP
            End Get
            Set(ByVal value As Nullable(Of Int16))
                _APGLSeqAP = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property APGLSeqDISC() As Nullable(Of Int16)
            Get
                APGLSeqDISC = _APGLSeqDISC
            End Get
            Set(ByVal value As Nullable(Of Int16))
                _APGLSeqDISC = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property APGLSeqWithholding() As Nullable(Of Int16)
            Get
                APGLSeqWithholding = _APGLSeqWithholding
            End Get
            Set(ByVal value As Nullable(Of Int16))
                _APGLSeqWithholding = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ManualCheck() As Nullable(Of Int16)
            Get
                ManualCheck = _ManualCheck
            End Get
            Set(ByVal value As Nullable(Of Int16))
                _ManualCheck = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property PaymentEntryDate() As Nullable(Of Date)
            Get
                PaymentEntryDate = _PaymentEntryDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _PaymentEntryDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ExchangeApplied() As Int32
            Get
                ExchangeApplied = _ExchangeApplied
            End Get
            Set(ByVal value As Int32)
                _ExchangeApplied = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
