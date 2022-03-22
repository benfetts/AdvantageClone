Namespace Reporting.Database.Classes

    <Serializable>
    Public Class CheckRegister

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            VendorName
            VendorAddress1
            VendorAddress2
            VendorAddress3
            VendorCity
            VendorCounty
            VendorState
            VendorCountry
            VendorZip
            VendorPayToName
            VendorPayToAddress1
            VendorPayToAddress2
            VendorPayToAddress3
            VendorPayToCity
            VendorPayToCounty
            VendorPayToState
            VendorPayToCountry
            VendorPayToZip
            VendorEmailAddress
            VendorActiveFlag
            VendorCategory
            VendorTaxID
            VendorAccountNumber
            VendorNotes
            'InvoiceNumber
            'InvoiceDate
            'InvoiceAmount
            CheckNumber
            CheckDate
            CheckPostPeriod
            CheckAmount
            DiscountAmount
            CheckVoided
            VoidedCheckAmount
            VoidComments
            CheckManualFlag
            'DebitGLAccount
            'CreditGLAccount
            CheckCleared
            BankCode
            BankDescription
            BankInactiveFlag
            BankAccountNumber
            BankRoutingNumber
            ACHCompanyID
            BankOfficeCode
            ARCashAccount
            APCashAccount
            APDiscountAccount
            ServiceChargeAccount
            InterestEarnedAccount
            VendorPayToCode
            VoidPostPeriod
            'DebitGLDescription
            'CreditGLDescription
            ARCashDescription
            APCashDescription
            APDiscountDescription
            ServiceChargeDescription
            InterestEarnedDescription

        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _VendorAddress1 As String = Nothing
        Private _VendorAddress2 As String = Nothing
        Private _VendorAddress3 As String = Nothing
        Private _VendorCity As String = Nothing
        Private _VendorCounty As String = Nothing
        Private _VendorState As String = Nothing
        Private _VendorCountry As String = Nothing
        Private _VendorZip As String = Nothing
        Private _VendorPayToName As String = Nothing
        Private _VendorPayToAddress1 As String = Nothing
        Private _VendorPayToAddress2 As String = Nothing
        Private _VendorPayToAddress3 As String = Nothing
        Private _VendorPayToCity As String = Nothing
        Private _VendorPayToCounty As String = Nothing
        Private _VendorPayToState As String = Nothing
        Private _VendorPayToCountry As String = Nothing
        Private _VendorPayToZip As String = Nothing
        Private _VendorEmailAddress As String = Nothing
        Private _VendorActiveFlag As String = Nothing
        Private _VendorCategory As String = Nothing
        Private _VendorTaxID As String = Nothing
        Private _VendorAccountNumber As String = Nothing
        Private _VendorNotes As String = Nothing
        'Private _InvoiceNumber As String = Nothing
        'Private _InvoiceDate As Nullable(Of Date) = Nothing
        'Private _InvoiceAmount As Nullable(Of Decimal) = Nothing
        Private _CheckNumber As Nullable(Of Integer) = Nothing
        Private _CheckDate As Nullable(Of Date) = Nothing
        Private _CheckPostPeriod As String = Nothing
        Private _CheckAmount As Nullable(Of Decimal) = Nothing
        Private _DiscountAmount As Nullable(Of Decimal) = Nothing
        Private _CheckVoided As String = Nothing
        Private _VoidedCheckAmount As Nullable(Of Decimal) = Nothing
        Private _VoidComments As String = Nothing
        Private _CheckManualFlag As String = Nothing
        'Private _DebitGLAccount As String = Nothing
        'Private _CreditGLAccount As String = Nothing
        Private _CheckCleared As String = Nothing
        Private _BankCode As String = Nothing
        Private _BankDescription As String = Nothing
        Private _BankInactiveFlag As String = Nothing
        Private _BankAccountNumber As String = Nothing
        Private _BankRoutingNumber As Nullable(Of Long) = Nothing
        Private _ACHCompanyID As String = Nothing
        Private _BankOfficeCode As String = Nothing
        Private _ARCashAccount As String = Nothing
        Private _APCashAccount As String = Nothing
        Private _APDiscountAccount As String = Nothing
        Private _ServiceChargeAccount As String = Nothing
        Private _InterestEarnedAccount As String = Nothing

        Private _VendorPayToCode As String = Nothing
        Private _VoidPostPeriod As String = Nothing
        'Private _DebitGLDescription As String = Nothing
        'Private _CreditGLDescription As String = Nothing
        Private _ARCashDescription As String = Nothing
        Private _APCashDescription As String = Nothing
        Private _APDiscountDescription As String = Nothing
        Private _ServiceChargeDescription As String = Nothing
        Private _InterestEarnedDescription As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(ByVal value As String)
                _VendorName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorAddress1() As String
            Get
                VendorAddress1 = _VendorAddress1
            End Get
            Set(ByVal value As String)
                _VendorAddress1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorAddress2() As String
            Get
                VendorAddress2 = _VendorAddress2
            End Get
            Set(ByVal value As String)
                _VendorAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorAddress3() As String
            Get
                VendorAddress3 = _VendorAddress3
            End Get
            Set(ByVal value As String)
                _VendorAddress3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCity() As String
            Get
                VendorCity = _VendorCity
            End Get
            Set(ByVal value As String)
                _VendorCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCounty() As String
            Get
                VendorCounty = _VendorCounty
            End Get
            Set(ByVal value As String)
                _VendorCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorState() As String
            Get
                VendorState = _VendorState
            End Get
            Set(ByVal value As String)
                _VendorState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCountry() As String
            Get
                VendorCountry = _VendorCountry
            End Get
            Set(ByVal value As String)
                _VendorCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorZip() As String
            Get
                VendorZip = _VendorZip
            End Get
            Set(ByVal value As String)
                _VendorZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToName() As String
            Get
                VendorPayToName = _VendorPayToName
            End Get
            Set(ByVal value As String)
                _VendorPayToName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToAddress1() As String
            Get
                VendorPayToAddress1 = _VendorPayToAddress1
            End Get
            Set(ByVal value As String)
                _VendorPayToAddress1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToAddress2() As String
            Get
                VendorPayToAddress2 = _VendorPayToAddress2
            End Get
            Set(ByVal value As String)
                _VendorPayToAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToAddress3() As String
            Get
                VendorPayToAddress3 = _VendorPayToAddress3
            End Get
            Set(ByVal value As String)
                _VendorPayToAddress3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToCity() As String
            Get
                VendorPayToCity = _VendorPayToCity
            End Get
            Set(ByVal value As String)
                _VendorPayToCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToCounty() As String
            Get
                VendorPayToCounty = _VendorPayToCounty
            End Get
            Set(ByVal value As String)
                _VendorPayToCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToState() As String
            Get
                VendorPayToState = _VendorPayToState
            End Get
            Set(ByVal value As String)
                _VendorPayToState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToCountry() As String
            Get
                VendorPayToCountry = _VendorPayToCountry
            End Get
            Set(ByVal value As String)
                _VendorPayToCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToZip() As String
            Get
                VendorPayToZip = _VendorPayToZip
            End Get
            Set(ByVal value As String)
                _VendorPayToZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorEmailAddress() As String
            Get
                VendorEmailAddress = _VendorEmailAddress
            End Get
            Set(ByVal value As String)
                _VendorEmailAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorActiveFlag() As String
            Get
                VendorActiveFlag = _VendorActiveFlag
            End Get
            Set(ByVal value As String)
                _VendorActiveFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCategory() As String
            Get
                VendorCategory = _VendorCategory
            End Get
            Set(ByVal value As String)
                _VendorCategory = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorTaxID() As String
            Get
                VendorTaxID = _VendorTaxID
            End Get
            Set(ByVal value As String)
                _VendorTaxID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorAccountNumber() As String
            Get
                VendorAccountNumber = _VendorAccountNumber
            End Get
            Set(ByVal value As String)
                _VendorAccountNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorNotes() As String
            Get
                VendorNotes = _VendorNotes
            End Get
            Set(ByVal value As String)
                _VendorNotes = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CheckNumber() As Nullable(Of Integer)
            Get
                CheckNumber = _CheckNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CheckNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckDate() As Nullable(Of Date)
            Get
                CheckDate = _CheckDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _CheckDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckPostPeriod() As String
            Get
                CheckPostPeriod = _CheckPostPeriod
            End Get
            Set(ByVal value As String)
                _CheckPostPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CheckAmount() As Nullable(Of Decimal)
            Get
                CheckAmount = _CheckAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CheckAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DiscountAmount() As Nullable(Of Decimal)
            Get
                DiscountAmount = _DiscountAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _DiscountAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckVoided() As String
            Get
                CheckVoided = _CheckVoided
            End Get
            Set(ByVal value As String)
                _CheckVoided = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VoidedCheckAmount() As Nullable(Of Decimal)
            Get
                VoidedCheckAmount = _VoidedCheckAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _VoidedCheckAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VoidComments() As String
            Get
                VoidComments = _VoidComments
            End Get
            Set(ByVal value As String)
                _VoidComments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckManualFlag() As String
            Get
                CheckManualFlag = _CheckManualFlag
            End Get
            Set(ByVal value As String)
                _CheckManualFlag = value
            End Set
        End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property DebitGLAccount() As String
        '    Get
        '        DebitGLAccount = _DebitGLAccount
        '    End Get
        '    Set(ByVal value As String)
        '        _DebitGLAccount = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property CreditGLAccount() As String
        '    Get
        '        CreditGLAccount = _CreditGLAccount
        '    End Get
        '    Set(ByVal value As String)
        '        _CreditGLAccount = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckCleared() As String
            Get
                CheckCleared = _CheckCleared
            End Get
            Set(ByVal value As String)
                _CheckCleared = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BankCode() As String
            Get
                BankCode = _BankCode
            End Get
            Set(ByVal value As String)
                _BankCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BankDescription() As String
            Get
                BankDescription = _BankDescription
            End Get
            Set(ByVal value As String)
                _BankDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BankInactiveFlag() As String
            Get
                BankInactiveFlag = _BankInactiveFlag
            End Get
            Set(ByVal value As String)
                _BankInactiveFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BankAccountNumber() As String
            Get
                BankAccountNumber = _BankAccountNumber
            End Get
            Set(ByVal value As String)
                _BankAccountNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property BankRoutingNumber() As Nullable(Of Long)
            Get
                BankRoutingNumber = _BankRoutingNumber
            End Get
            Set(ByVal value As Nullable(Of Long))
                _BankRoutingNumber = value
            End Set
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ACHCompanyID() As String
            Get
                ACHCompanyID = _ACHCompanyID
            End Get
            Set(ByVal value As String)
                _ACHCompanyID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BankOfficeCode() As String
            Get
                BankOfficeCode = _BankOfficeCode
            End Get
            Set(ByVal value As String)
                _BankOfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARCashAccount() As String
            Get
                ARCashAccount = _ARCashAccount
            End Get
            Set(ByVal value As String)
                _ARCashAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property APCashAccount() As String
            Get
                APCashAccount = _APCashAccount
            End Get
            Set(ByVal value As String)
                _APCashAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property APDiscountAccount() As String
            Get
                APDiscountAccount = _APDiscountAccount
            End Get
            Set(ByVal value As String)
                _APDiscountAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceChargeAccount() As String
            Get
                ServiceChargeAccount = _ServiceChargeAccount
            End Get
            Set(ByVal value As String)
                _ServiceChargeAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InterestEarnedAccount() As String
            Get
                InterestEarnedAccount = _InterestEarnedAccount
            End Get
            Set(ByVal value As String)
                _InterestEarnedAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToCode() As String
            Get
                VendorPayToCode = _VendorPayToCode
            End Get
            Set(ByVal value As String)
                _VendorPayToCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VoidPostPeriod() As String
            Get
                VoidPostPeriod = _VoidPostPeriod
            End Get
            Set(ByVal value As String)
                _VoidPostPeriod = value
            End Set
        End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property DebitGLDescription() As String
        '    Get
        '        DebitGLDescription = _DebitGLDescription
        '    End Get
        '    Set(ByVal value As String)
        '        _DebitGLDescription = value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property CreditGLDescription() As String
        '    Get
        '        CreditGLDescription = _CreditGLDescription
        '    End Get
        '    Set(ByVal value As String)
        '        _CreditGLDescription = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARCashDescription() As String
            Get
                ARCashDescription = _ARCashDescription
            End Get
            Set(ByVal value As String)
                _ARCashDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property APCashDescription() As String
            Get
                APCashDescription = _APCashDescription
            End Get
            Set(ByVal value As String)
                _APCashDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property APDiscountDescription() As String
            Get
                APDiscountDescription = _APDiscountDescription
            End Get
            Set(ByVal value As String)
                _APDiscountDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceChargeDescription() As String
            Get
                ServiceChargeDescription = _ServiceChargeDescription
            End Get
            Set(ByVal value As String)
                _ServiceChargeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InterestEarnedDescription() As String
            Get
                InterestEarnedDescription = _InterestEarnedDescription
            End Get
            Set(ByVal value As String)
                _InterestEarnedDescription = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.VendorCode.ToString

        End Function

#End Region

    End Class

End Namespace
