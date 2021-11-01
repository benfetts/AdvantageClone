Namespace Database.Classes

    <Serializable()>
    Public Class EstimateDetailApprovedReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            EstimateNumber
            EstimateDescription
            EstimateComment
            EstimateComponentNumber
            EstimateComponentDescription
            EstimateComponentComment
            EstimateContactID
            EstimateContactCode
            EstimateContactName
            QuoteNumber
            QuoteDescription
            QuoteComment
            RevisionNumber
            RevisionComment
            ApprovalType
            ApprovalTypeDescription
            ClientApprovalName
            ClientApprovalDate
            InternalApprovalName
            InternalApprovalDate
            JobNumber
            JobClientReference
            JobDescription
            CampaignID
            CampaignCode
            CampaignName
            SalesClassCode
            SalesClassDescription
            JobCreateDate
            JobDateOpened
            JobComponentNumber
            JobComponentDescription
            AccountExecutiveCode
            AccountExecutiveName
            JobClientPO
            ComponentDateOpened
            JobDueDate
            JobStartDate
            JobProcessingControl
            FunctionType
            FunctionHeading
            FunctionCode
            FunctionDescription
            DetailComments
            SuppliedByCode
            SuppliedByName
            SuppliedByNotes
            Billable
            FeeTime
            EstimateHours
            EstimateQuantity
            EstimateRate
            EstimateExtAmount
            EstimateNonResaleAmount
            EstimateNetAmount
            EstimateCostAmount
            TaxCode
            TaxCodeDescription
            EstimateStateAmount
            EstimateCountyAmount
            EstimateCityAmount
            EstimateResaleTaxAmount
            EstimateMarkupPercent
            EstimateMarkupAmount
            EstimateTotalAmount
            EstimateContingencyPercent
            EstimateContingencyAmount
            EstimateTotalWithContingency
        End Enum

#End Region

#Region " Variables "

        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _ProductUDF1 As String = Nothing
        Private _ProductUDF2 As String = Nothing
        Private _ProductUDF3 As String = Nothing
        Private _ProductUDF4 As String = Nothing
        Private _EstimateNumber As Integer = Nothing
        Private _EstimateDescription As String = Nothing
        Private _EstimateComment As String = Nothing
        Private _EstimateComponentNumber As Short = Nothing
        Private _EstimateComponentDescription As String = Nothing
        Private _EstimateComponentComment As String = Nothing
        Private _EstimateContactID As Nullable(Of Integer) = Nothing
        Private _EstimateContactCode As String = Nothing
        Private _EstimateContactName As String = Nothing
        Private _QuoteNumber As Short = Nothing
        Private _QuoteDescription As String = Nothing
        Private _QuoteComment As String = Nothing
        Private _RevisionNumber As Nullable(Of Short) = Nothing
        Private _RevisionComment As String = Nothing
        Private _ApprovalType As Integer = Nothing
        Private _ApprovalTypeDescription As String = Nothing
        Private _ClientApprovalName As String = Nothing
        Private _ClientApprovalDate As Nullable(Of Date) = Nothing
        Private _InternalApprovalName As String = Nothing
        Private _InternalApprovalDate As Nullable(Of Date) = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobClientReference As String = Nothing
        Private _JobDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _JobCreateDate As Nullable(Of Date) = Nothing
        Private _JobDateOpened As Nullable(Of Date) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutiveName As String = Nothing
        Private _JobClientPO As String = Nothing
        Private _ComponentDateOpened As Nullable(Of Date) = Nothing
        Private _JobDueDate As Nullable(Of Date) = Nothing
        Private _JobStartDate As Nullable(Of Date) = Nothing
        Private _JobProcessingControl As String = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionHeading As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _DetailComments As String = Nothing
        Private _SuppliedByCode As String = Nothing
        Private _SuppliedByName As String = Nothing
        Private _SuppliedByNotes As String = Nothing
        Private _Billable As String = Nothing
        Private _FeeTime As String = Nothing
        Private _EstimateHours As Nullable(Of Decimal) = Nothing
        Private _EstimateQuantity As Nullable(Of Decimal) = Nothing
        Private _EstimateRate As Nullable(Of Decimal) = Nothing
        Private _EstimateExtAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateNonResaleAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateNetAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateCostAmount As Nullable(Of Decimal) = Nothing
        Private _TaxCode As String = Nothing
        Private _TaxCodeDescription As String = Nothing
        Private _EstimateStateAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateCountyAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateCityAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkupPercent As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateTotalAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateContingencyPercent As Nullable(Of Decimal) = Nothing
        Private _EstimateContingencyAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateTotalWithContingency As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(ByVal value As String)
                _OfficeName = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(ByVal value As String)
                _ProductUDF1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(ByVal value As String)
                _ProductUDF2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(ByVal value As String)
                _ProductUDF3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(ByVal value As String)
                _ProductUDF4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property EstimateNumber() As Integer
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(value As Integer)
                _EstimateNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateDescription() As String
            Get
                EstimateDescription = _EstimateDescription
            End Get
            Set(ByVal value As String)
                _EstimateDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComment() As String
            Get
                EstimateComment = _EstimateComment
            End Get
            Set(ByVal value As String)
                _EstimateComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentNumber() As Short
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(value As Short)
                _EstimateComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentDescription() As String
            Get
                EstimateComponentDescription = _EstimateComponentDescription
            End Get
            Set(ByVal value As String)
                _EstimateComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentComment() As String
            Get
                EstimateComponentComment = _EstimateComponentComment
            End Get
            Set(ByVal value As String)
                _EstimateComponentComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactID() As Nullable(Of Integer)
            Get
                EstimateContactID = _EstimateContactID
            End Get
            Set(value As Nullable(Of Integer))
                _EstimateContactID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactCode() As String
            Get
                EstimateContactCode = _EstimateContactCode
            End Get
            Set(ByVal value As String)
                _EstimateContactCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactName() As String
            Get
                EstimateContactName = _EstimateContactName
            End Get
            Set(ByVal value As String)
                _EstimateContactName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuoteNumber() As Short
            Get
                QuoteNumber = _QuoteNumber
            End Get
            Set(value As Short)
                _QuoteNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuoteDescription() As String
            Get
                QuoteDescription = _QuoteDescription
            End Get
            Set(ByVal value As String)
                _QuoteDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuoteComment() As String
            Get
                QuoteComment = _QuoteComment
            End Get
            Set(ByVal value As String)
                _QuoteComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RevisionNumber() As Nullable(Of Short)
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RevisionNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RevisionComment() As String
            Get
                RevisionComment = _RevisionComment
            End Get
            Set(ByVal value As String)
                _RevisionComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalType() As Integer
            Get
                ApprovalType = _ApprovalType
            End Get
            Set(ByVal value As Integer)
                _ApprovalType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalTypeDescription() As String
            Get
                ApprovalTypeDescription = _ApprovalTypeDescription
            End Get
            Set(ByVal value As String)
                _ApprovalTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientApprovalName() As String
            Get
                ClientApprovalName = _ClientApprovalName
            End Get
            Set(ByVal value As String)
                _ClientApprovalName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientApprovalDate() As Nullable(Of Date)
            Get
                ClientApprovalDate = _ClientApprovalDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ClientApprovalDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternalApprovalName() As String
            Get
                InternalApprovalName = _InternalApprovalName
            End Get
            Set(ByVal value As String)
                _InternalApprovalName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternalApprovalDate() As Nullable(Of Date)
            Get
                InternalApprovalDate = _InternalApprovalDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InternalApprovalDate = value
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
        Public Property JobClientReference() As String
            Get
                JobClientReference = _JobClientReference
            End Get
            Set(ByVal value As String)
                _JobClientReference = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(ByVal value As String)
                _CampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(ByVal value As String)
                _CampaignName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCreateDate() As Nullable(Of Date)
            Get
                JobCreateDate = _JobCreateDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobCreateDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDateOpened() As Nullable(Of Date)
            Get
                JobDateOpened = _JobDateOpened
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobDateOpened = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
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
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveName() As String
            Get
                AccountExecutiveName = _AccountExecutiveName
            End Get
            Set(ByVal value As String)
                _AccountExecutiveName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobClientPO() As String
            Get
                JobClientPO = _JobClientPO
            End Get
            Set(ByVal value As String)
                _JobClientPO = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDateOpened() As Nullable(Of Date)
            Get
                ComponentDateOpened = _ComponentDateOpened
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ComponentDateOpened = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDueDate() As Nullable(Of Date)
            Get
                JobDueDate = _JobDueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobDueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobStartDate() As Nullable(Of Date)
            Get
                JobStartDate = _JobStartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobStartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobProcessingControl() As String
            Get
                JobProcessingControl = _JobProcessingControl
            End Get
            Set(ByVal value As String)
                _JobProcessingControl = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeading() As String
            Get
                FunctionHeading = _FunctionHeading
            End Get
            Set(ByVal value As String)
                _FunctionHeading = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DetailComments() As String
            Get
                DetailComments = _DetailComments
            End Get
            Set(ByVal value As String)
                _DetailComments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SuppliedByCode() As String
            Get
                SuppliedByCode = _SuppliedByCode
            End Get
            Set(ByVal value As String)
                _SuppliedByCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SuppliedByName() As String
            Get
                SuppliedByName = _SuppliedByName
            End Get
            Set(ByVal value As String)
                _SuppliedByName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SuppliedByNotes() As String
            Get
                SuppliedByNotes = _SuppliedByNotes
            End Get
            Set(ByVal value As String)
                _SuppliedByNotes = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Billable() As String
            Get
                Billable = _Billable
            End Get
            Set(ByVal value As String)
                _Billable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeTime() As String
            Get
                FeeTime = _FeeTime
            End Get
            Set(ByVal value As String)
                _FeeTime = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateHours() As Nullable(Of Decimal)
            Get
                EstimateHours = _EstimateHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateQuantity() As Nullable(Of Decimal)
            Get
                EstimateQuantity = _EstimateQuantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateRate() As Nullable(Of Decimal)
            Get
                EstimateRate = _EstimateRate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateExtAmount() As Nullable(Of Decimal)
            Get
                EstimateExtAmount = _EstimateExtAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateExtAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateNonResaleAmount() As Nullable(Of Decimal)
            Get
                EstimateNonResaleAmount = _EstimateNonResaleAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateNonResaleAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateNetAmount() As Nullable(Of Decimal)
            Get
                EstimateNetAmount = _EstimateNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateCostAmount() As Nullable(Of Decimal)
            Get
                EstimateCostAmount = _EstimateCostAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateCostAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(ByVal value As String)
                _TaxCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCodeDescription() As String
            Get
                TaxCodeDescription = _TaxCodeDescription
            End Get
            Set(ByVal value As String)
                _TaxCodeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateStateAmount() As Nullable(Of Decimal)
            Get
                EstimateStateAmount = _EstimateStateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateStateAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateCountyAmount() As Nullable(Of Decimal)
            Get
                EstimateCountyAmount = _EstimateCountyAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateCountyAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateCityAmount() As Nullable(Of Decimal)
            Get
                EstimateCityAmount = _EstimateCityAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateCityAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateResaleTaxAmount() As Nullable(Of Decimal)
            Get
                EstimateResaleTaxAmount = _EstimateResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateMarkupPercent() As Nullable(Of Decimal)
            Get
                EstimateMarkupPercent = _EstimateMarkupPercent
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateMarkupPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateMarkupAmount() As Nullable(Of Decimal)
            Get
                EstimateMarkupAmount = _EstimateMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateTotalAmount() As Nullable(Of Decimal)
            Get
                EstimateTotalAmount = _EstimateTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateContingencyPercent() As Nullable(Of Decimal)
            Get
                EstimateContingencyPercent = _EstimateContingencyPercent
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateContingencyPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateContingencyAmount() As Nullable(Of Decimal)
            Get
                EstimateContingencyAmount = _EstimateContingencyAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateContingencyAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateTotalWithContingency() As Nullable(Of Decimal)
            Get
                EstimateTotalWithContingency = _EstimateTotalWithContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTotalWithContingency = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
