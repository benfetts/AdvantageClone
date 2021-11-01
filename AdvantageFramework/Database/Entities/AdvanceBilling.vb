Namespace Database.Entities

    <Table("ADVANCE_BILLING")>
    Public Class AdvanceBilling
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SequenceNumber
            AdvanceBillFlag
            JobNumber
            JobComponentNumber
            FunctionCode
            FunctionType
            NetAmount
            MarkupPercent
            ARInvoiceNumber
            ARInvoiceSequence
            ARType
            ARInvoiceIsVoided
            CreateDate
            UserCode
            SalesTaxCode
            StateTaxPercent
            CountyTaxPercent
            CityTaxPercent
            IsResaleTax
            TaxCommission
            TaxCommissionOnly
            CalculateMethodFlag
            CalculatePercent
            BillingUserCode
            EstimateNumber
            EstimateComponentNumber
            EstimateQuoteNumber
            EstimateRevisionNumber
            GLACodeSales
            GLACodeCostOfSales
            GLACodeAccruedAP
            GLACodeState
            GLACodeCounty
            GLACodeCity
            GLTransaction
            GLSequenceNumberSales
            GLSequenceNumberCostOfSales
            GLSequenceNumberAccruedAP
            GLSequenceNumberState
            GLSequenceNumberCounty
            GLSequenceNumberCity
            FinalAdvanceBillFlag
            FinalDate
            FinalAdvanceBillingID
            FinalSequenceNumber
            FinalUserCode
            ExtendedMarkupAmount
            ExtendedNonResaleTax
            ExtendedStateResale
            ExtendedCountyResale
            ExtendedCityResale
            LineTotal
            PostPeriodCode
            MethodDescription
            BillDate
            UseContingency
            CampaignUpdatedInvoiceDate
            CampaignUpdatedPostPeriod
            BillingCommandCenterID
            QuantityHours
            Rate

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("AB_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Key>
        <Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Integer
        <Required>
        <Column("AB_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AdvanceBillFlag() As Short
        <Required>
        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber() As Integer
        <Required>
        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobComponent)>
        Public Property JobComponentNumber() As Short
        <Key>
        <Required>
        <MaxLength(6)>
        <Column("FNC_CODE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
        <MaxLength(1)>
        <Column("FNC_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property FunctionType() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("ADV_BILL_NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        <Column("COMMISSION_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
        <Column("AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
        <Column("AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceSequence() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARType() As String
        <Column("AR_INV_VOID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceIsVoided() As Nullable(Of Short)
        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateDate() As Nullable(Of Date)
        <MaxLength(100)>
        <Column("USER_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
        <MaxLength(4)>
        <Column("TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesTaxCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <Column("TAX_STATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTaxPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <Column("TAX_COUNTY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CountyTaxPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <Column("TAX_CITY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTaxPercent() As Nullable(Of Decimal)
        <Column("TAX_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsResaleTax() As Nullable(Of Short)
        <Column("TAX_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCommission() As Nullable(Of Short)
        <Column("TAX_COMM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCommissionOnly() As Nullable(Of Short)
        <Column("CALC_METHOD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalculateMethodFlag() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("CALC_PERCENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3", UseMaxValue:=True, MaxValue:=100, UseMinValue:=True, MinValue:=0)>
        Public Property CalculatePercent() As Nullable(Of Decimal)
        <MaxLength(100)>
        <Column("BILLING_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingUserCode() As String
        <Column("ESTIMATE_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateNumber() As Nullable(Of Integer)
        <Column("EST_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentNumber() As Nullable(Of Short)
        <Column("EST_QUOTE_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateQuoteNumber() As Nullable(Of Short)
        <Column("EST_REVISION_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateRevisionNumber() As Nullable(Of Short)
        <MaxLength(30)>
        <Column("GLACODE_SALES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeSales() As String
        <MaxLength(30)>
        <Column("GLACODE_COS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeCostOfSales() As String
        <MaxLength(30)>
        <Column("GLACODE_ACC_AP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeAccruedAP() As String
        <MaxLength(30)>
        <Column("GLACODE_STATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeState() As String
        <MaxLength(30)>
        <Column("GLACODE_CNTY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeCounty() As String
        <MaxLength(30)>
        <Column("GLACODE_CITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeCity() As String
        <Column("GLEXACT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLTransaction() As Nullable(Of Integer)
        <Column("GLESEQ_SALES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberSales() As Nullable(Of Short)
        <Column("GLESEQ_COS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberCostOfSales() As Nullable(Of Short)
        <Column("GLESEQ_ACC_AP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberAccruedAP() As Nullable(Of Short)
        <Column("GLESEQ_STATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberState() As Nullable(Of Short)
        <Column("GLESEQ_CNTY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberCounty() As Nullable(Of Short)
        <Column("GLESEQ_CITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberCity() As Nullable(Of Short)
        <Column("FINAL_AB_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FinalAdvanceBillFlag() As Nullable(Of Short)
        <Column("FINAL_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FinalDate() As Nullable(Of Date)
        <Column("FINAL_AB_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FinalAdvanceBillingID() As Nullable(Of Integer)
        <Column("FINAL_SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FinalSequenceNumber() As Nullable(Of Integer)
        <MaxLength(100)>
        <Column("FINAL_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FinalUserCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXT_MARKUP_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXT_NONRESALE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedNonResaleTax() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXT_STATE_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedStateResale() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXT_COUNTY_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedCountyResale() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXT_CITY_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedCityResale() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("LINE_TOTAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineTotal() As Nullable(Of Decimal)
        <MaxLength(8)>
        <Column("POST_PERIOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriodCode() As String
        <MaxLength(30)>
        <Column("METHOD_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MethodDescription() As String
        <Column("BILL_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillDate() As Nullable(Of Date)
        <Column("USE_CONTINGENCY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseContingency() As Nullable(Of Short)
        <Column("CMP_UPD_INV_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignUpdatedInvoiceDate() As Nullable(Of Short)
        <Column("CMP_UPD_PP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignUpdatedPostPeriod() As Nullable(Of Short)
        <Column("BCC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCommandCenterID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("QTY_HOURS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuantityHours() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Rate() As Nullable(Of Decimal)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.AdvanceBilling.Properties.FunctionCode.ToString

                    If Me.DatabaseAction = Database.Action.Inserting Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).AdvanceBillings
                            Where Entity.JobNumber = Me.JobNumber AndAlso
                                  Entity.JobComponentNumber = Me.JobComponentNumber AndAlso
                                  Entity.FunctionCode = DirectCast(PropertyValue, String) AndAlso
                                  Entity.ARInvoiceNumber Is Nothing AndAlso
                                  (Entity.AdvanceBillFlag = 1 OrElse Entity.AdvanceBillFlag = 2)
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Function exists."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function

#End Region

    End Class

End Namespace
