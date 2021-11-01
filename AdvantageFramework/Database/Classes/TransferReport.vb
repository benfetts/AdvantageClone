Namespace Database.Classes

    <Serializable()>
    Public Class TransferReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            RecordSource
            RecordID
            RecordSequence
            VendorEmployeeCode
            VendorEmployeeName
            VoucherNumber
            VoucherDate
            WIPPostPeriod
            LineNumber
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            FunctionCode
            Quantity
            BillRate
            NetAmount
            VendorTaxAmount
            MarkupAmount
            StateTaxAmount
            CountyTaxAmount
            CityTaxAmount
            LineTotal
            NonBillableFlag
            BillHoldFlag
            InvoiceNumber
            InvoiceSequence
            InvoiceType
            InvoiceDate
            AdvanceBillingFlag
            ModifyDeleteFlag
            DeleteFlag
            TransferFromClient
            TransferFromClientName
            TransferFromDivision
            TransferFromDivisionName
            TransferFromProduct
            TransferFromProductDescription
            TransferFromJobNumber
            TransferFromJobDescription
            TransferFromJobComponentNumber
            TransferFromJobComponentDescription
            TransferFromFunctionCode
            TransferFromRecordID
            TransferFromRecordSequence
            TransferFromLineNumber
            TransferAdjustedUserID
            TransferAdjustedDate

        End Enum

#End Region

#Region " Variables "

        Private _RecordSource As String = Nothing
        Private _RecordID As Nullable(Of Integer) = Nothing
        Private _RecordSequence As Nullable(Of Short) = Nothing
        Private _VendorEmployeeCode As String = Nothing
        Private _VendorEmployeeName As String = Nothing
        Private _VoucherNumber As String = Nothing
        Private _VoucherDate As Nullable(Of Date) = Nothing
        Private _WIPPostPeriod As String = Nothing
        Private _LineNumber As Nullable(Of Integer) = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _BillRate As Nullable(Of Decimal) = Nothing
        Private _NetAmount As Nullable(Of Decimal) = Nothing
        Private _VendorTaxAmount As Nullable(Of Decimal) = Nothing
        Private _MarkupAmount As Nullable(Of Decimal) = Nothing
        Private _StateTaxAmount As Nullable(Of Decimal) = Nothing
        Private _CountyTaxAmount As Nullable(Of Decimal) = Nothing
        Private _CityTaxAmount As Nullable(Of Decimal) = Nothing
        Private _LineTotal As Nullable(Of Decimal) = Nothing
        Private _NonBillableFlag As Nullable(Of Byte) = Nothing
        Private _BillHoldFlag As Nullable(Of Byte) = Nothing
        Private _InvoiceNumber As Nullable(Of Integer) = Nothing
        Private _InvoiceSequence As Nullable(Of Short) = Nothing
        Private _InvoiceType As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _AdvanceBillingFlag As Nullable(Of Byte) = Nothing
        Private _ModifyDeleteFlag As Nullable(Of Byte) = Nothing
        Private _DeleteFlag As Nullable(Of Byte) = Nothing
        Private _TransferFromClient As String = Nothing
        Private _TransferFromClientName As String = Nothing
        Private _TransferFromDivision As String = Nothing
        Private _TransferFromDivisionName As String = Nothing
        Private _TransferFromProduct As String = Nothing
        Private _TransferFromProductDescription As String = Nothing
        Private _TransferFromJobNumber As Nullable(Of Integer) = Nothing
        Private _TransferFromJobDescription As String = Nothing
        Private _TransferFromJobComponentNumber As Nullable(Of Short) = Nothing
        Private _TransferFromJobComponentDescription As String = Nothing
        Private _TransferFromFunctionCode As String = Nothing
        Private _TransferFromRecordID As Nullable(Of Integer) = Nothing
        Private _TransferFromLineNumber As Nullable(Of Short) = Nothing
        Private _TransferAdjustedUserID As String = Nothing
        Private _TransferAdjustedDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RecordSource() As String
            Get
                RecordSource = _RecordSource
            End Get
            Set(ByVal value As String)
                _RecordSource = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property RecordID() As Nullable(Of Integer)
            Get
                RecordID = _RecordID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _RecordID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Record Seq")>
        Public Property RecordSequence() As Nullable(Of Short)
            Get
                RecordSequence = _RecordSequence
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RecordSequence = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Supplier Code")>
        Public Property VendorEmployeeCode() As String
            Get
                VendorEmployeeCode = _VendorEmployeeCode
            End Get
            Set(ByVal value As String)
                _VendorEmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Supplier Name")>
        Public Property VendorEmployeeName() As String
            Get
                VendorEmployeeName = _VendorEmployeeName
            End Get
            Set(ByVal value As String)
                _VendorEmployeeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="AP Invoice Number")>
        Public Property VoucherNumber() As String
            Get
                VoucherNumber = _VoucherNumber
            End Get
            Set(ByVal value As String)
                _VoucherNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="AP Invoice Date")>
        Public Property VoucherDate() As Nullable(Of Date)
            Get
                VoucherDate = _VoucherDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _VoucherDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Detail GL Period")>
        Public Property WIPPostPeriod() As String
            Get
                WIPPostPeriod = _WIPPostPeriod
            End Get
            Set(ByVal value As String)
                _WIPPostPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Record Line")>
        Public Property LineNumber() As Nullable(Of Integer)
            Get
                LineNumber = _LineNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _LineNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(ByVal value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Job Component Number")>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Quantity/Hours")>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BillRate() As Nullable(Of Decimal)
            Get
                BillRate = _BillRate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BillRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VendorTaxAmount() As Nullable(Of Decimal)
            Get
                VendorTaxAmount = _VendorTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _VendorTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MarkupAmount() As Nullable(Of Decimal)
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property StateTaxAmount() As Nullable(Of Decimal)
            Get
                StateTaxAmount = _StateTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CountyTaxAmount() As Nullable(Of Decimal)
            Get
                CountyTaxAmount = _CountyTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CityTaxAmount() As Nullable(Of Decimal)
            Get
                CityTaxAmount = _CityTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Total Amount")>
        Public Property LineTotal() As Nullable(Of Decimal)
            Get
                LineTotal = _LineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _LineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Non Billable", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property NonBillableFlag() As Nullable(Of Byte)
            Get
                NonBillableFlag = _NonBillableFlag
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _NonBillableFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Bill Hold", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property BillHoldFlag() As Nullable(Of Byte)
            Get
                BillHoldFlag = _BillHoldFlag
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _BillHoldFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="AR Invoice Number")>
        Public Property InvoiceNumber() As Nullable(Of Integer)
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _InvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="AR Invoice Seq")>
        Public Property InvoiceSequence() As Nullable(Of Short)
            Get
                InvoiceSequence = _InvoiceSequence
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InvoiceSequence = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="AR Type")>
        Public Property InvoiceType() As String
            Get
                InvoiceType = _InvoiceType
            End Get
            Set(ByVal value As String)
                _InvoiceType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="AR Invoice Date")>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Advance Bill", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property AdvanceBillingFlag() As Nullable(Of Byte)
            Get
                AdvanceBillingFlag = _AdvanceBillingFlag
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _AdvanceBillingFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Modified", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property ModifyDeleteFlag() As Nullable(Of Byte)
            Get
                ModifyDeleteFlag = _ModifyDeleteFlag
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _ModifyDeleteFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Deleted", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property DeleteFlag() As Nullable(Of Byte)
            Get
                DeleteFlag = _DeleteFlag
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _DeleteFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="From Client")>
        Public Property TransferFromClient() As String
            Get
                TransferFromClient = _TransferFromClient
            End Get
            Set(ByVal value As String)
                _TransferFromClient = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="From Client Name")>
        Public Property TransferFromClientName() As String
            Get
                TransferFromClientName = _TransferFromClientName
            End Get
            Set(ByVal value As String)
                _TransferFromClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="From Division")>
        Public Property TransferFromDivision() As String
            Get
                TransferFromDivision = _TransferFromDivision
            End Get
            Set(ByVal value As String)
                _TransferFromDivision = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="From Division Name")>
        Public Property TransferFromDivisionName() As String
            Get
                TransferFromDivisionName = _TransferFromDivisionName
            End Get
            Set(ByVal value As String)
                _TransferFromDivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="From Product")>
        Public Property TransferFromProduct() As String
            Get
                TransferFromProduct = _TransferFromProduct
            End Get
            Set(ByVal value As String)
                _TransferFromProduct = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="From Product Description")>
        Public Property TransferFromProductDescription() As String
            Get
                TransferFromProductDescription = _TransferFromProductDescription
            End Get
            Set(ByVal value As String)
                _TransferFromProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="From Job Number")>
        Public Property TransferFromJobNumber() As Nullable(Of Integer)
            Get
                TransferFromJobNumber = _TransferFromJobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _TransferFromJobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="From Job Description")>
        Public Property TransferFromJobDescription() As String
            Get
                TransferFromJobDescription = _TransferFromJobDescription
            End Get
            Set(ByVal value As String)
                _TransferFromJobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="From Job Component Number")>
        Public Property TransferFromJobComponentNumber() As Nullable(Of Short)
            Get
                TransferFromJobComponentNumber = _TransferFromJobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TransferFromJobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="From Job Component Description")>
        Public Property TransferFromJobComponentDescription() As String
            Get
                TransferFromJobComponentDescription = _TransferFromJobComponentDescription
            End Get
            Set(ByVal value As String)
                _TransferFromJobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="From Function")>
        Public Property TransferFromFunctionCode() As String
            Get
                TransferFromFunctionCode = _TransferFromFunctionCode
            End Get
            Set(ByVal value As String)
                _TransferFromFunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="From Record ID")>
        Public Property TransferFromRecordID() As Nullable(Of Integer)
            Get
                TransferFromRecordID = _TransferFromRecordID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _TransferFromRecordID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="From Line Number")>
        Public Property TransferFromLineNumber() As Nullable(Of Short)
            Get
                TransferFromLineNumber = _TransferFromLineNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TransferFromLineNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Transfer User ID")>
        Public Property TransferAdjustedUserID() As String
            Get
                TransferAdjustedUserID = _TransferAdjustedUserID
            End Get
            Set(ByVal value As String)
                _TransferAdjustedUserID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Transfer Date")>
        Public Property TransferAdjustedDate() As Nullable(Of Date)
            Get
                TransferAdjustedDate = _TransferAdjustedDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _TransferAdjustedDate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode

        End Function

#End Region

    End Class

End Namespace
