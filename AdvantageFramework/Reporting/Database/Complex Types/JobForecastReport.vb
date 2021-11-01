Namespace Reporting.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ReportingObjectContext", Name:="JobForecastReport")>
    <Serializable()>
    Public Class JobForecastReport
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            OfficeCode
            OfficeName
            NewBusiness
            ProductUDV1
            ProductUDV2
            ProductUDV3
            ProductUDV4
            Industry
            Specialty
            Region
            NumberOfEmployees
            Source
            Probability
            Rating
            CurrentProvider
            LeadDate
            SoldDate
            LostDate
            JobNumber
            JobDescription
            JobTemplateCode
            SalesClassCode
            SalesClassDescription
            CampaignCode
            CampaignName
            ClientReference
            SalesClassFormatCode
            SalesClassFormatDescription
            ComplexityCode
            ComplexityDescription
            PromotionCode
            PromotionDescription
            JobUDF1
            JobUDF2
            JobUDF3
            JobUDF4
            JobUDF5
            JobCreateDate
            JobDateOpened
            AccountNumber
            JobComponentNumber
            JobComponent
            JobComponentDescription
            AccountExecutiveCode
            AccountExecutive
            AlertGroup
            ClientContactCode
            ClientContact
            JobTypeCode
            JobTypeDescription
            DepartmentCode
            DepartmentDescription
            ClientPO
            AdNumber
            AdNumberDescription
            MarketCode
            MarketDescription
            Format
            JobComponentUDV1
            JobComponentUDV2
            JobComponentUDV3
            JobComponentUDV4
            JobComponentUDV5
            FiscalPeriodCode
            FiscalPeriodDescription
            DateOpened
            JobProcessControlNumber
            JobProcessControlDescription
            NonBillable
            StatusCode
            StatusDescription
            ManagerCode
            Manager
            GutPercentComplete
            StartDate
            DueDate
            CompletedDate
            ForecastDescription
            PostPeriodStart
            PostPeriodEnd
            Budget
            AssignedToOfficeCode
            AssignedToOfficeName
            AssignedToUserCode
            AssignedToUserName
            ForecastComment
            ForecastJobComment
            ForecastCreatedDate
            ForecastModifiedDate
            ForecastApprovedDate
            ApprovedRevisionNumber
            HighestRevisionNumber
            Approved
            Forecast
            Actual
            Variance
            PostPeriod
            PostPeriodBillingAmount
            PostPeriodRevenueAmount
            TotalJobBillingAmount
            TotalJobRevenueAmount
            ActualJobBillingAmount
            ActualJobRevenueAmount
            TotalActualJobBillingAmount
            TotalActualJobRevenueAmount
            TotalOpenPurchaseOrderBillableAmount
            TotalOpenPurchaseOrderRevenueAmount
            EstimateNumber
            EstimateComponentNumber
            ApprovedEstimateBillingAmount
            ApprovedEstimateRevenueAmount
            JobForecastID
            JobForecastRevisionID
            JobForecastJobID
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _NewBusiness As String = Nothing
        Private _ProductUDV1 As String = Nothing
        Private _ProductUDV2 As String = Nothing
        Private _ProductUDV3 As String = Nothing
        Private _ProductUDV4 As String = Nothing
        Private _Industry As String = Nothing
        Private _Specialty As String = Nothing
        Private _Region As String = Nothing
        Private _NumberOfEmployees As Nullable(Of Integer) = Nothing
        Private _Source As String = Nothing
        Private _Probability As Nullable(Of Byte) = Nothing
        Private _Rating As String = Nothing
        Private _CurrentProvider As String = Nothing
        Private _LeadDate As Nullable(Of Date) = Nothing
        Private _SoldDate As Nullable(Of Date) = Nothing
        Private _LostDate As Nullable(Of Date) = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _JobTemplateCode As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _ClientReference As String = Nothing
        Private _SalesClassFormatCode As String = Nothing
        Private _SalesClassFormatDescription As String = Nothing
        Private _ComplexityCode As String = Nothing
        Private _ComplexityDescription As String = Nothing
        Private _PromotionCode As String = Nothing
        Private _PromotionDescription As String = Nothing
        Private _JobUDF1 As String = Nothing
        Private _JobUDF2 As String = Nothing
        Private _JobUDF3 As String = Nothing
        Private _JobUDF4 As String = Nothing
        Private _JobUDF5 As String = Nothing
        Private _JobCreateDate As Nullable(Of Date) = Nothing
        Private _JobDateOpened As Nullable(Of Date) = Nothing
        Private _AccountNumber As String = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobComponent As String = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _AlertGroup As String = Nothing
        Private _ClientContactCode As String = Nothing
        Private _ClientContact As String = Nothing
        Private _JobTypeCode As String = Nothing
        Private _JobTypeDescription As String = Nothing
        Private _DepartmentCode As String = Nothing
        Private _DepartmentDescription As String = Nothing
        Private _ClientPO As String = Nothing
        Private _AdNumber As String = Nothing
        Private _AdNumberDescription As String = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _Format As String = Nothing
        Private _JobComponentUDV1 As String = Nothing
        Private _JobComponentUDV2 As String = Nothing
        Private _JobComponentUDV3 As String = Nothing
        Private _JobComponentUDV4 As String = Nothing
        Private _JobComponentUDV5 As String = Nothing
        Private _FiscalPeriodCode As String = Nothing
        Private _FiscalPeriodDescription As String = Nothing
        Private _DateOpened As Nullable(Of Date) = Nothing
        Private _JobProcessControlNumber As Nullable(Of Short) = Nothing
        Private _JobProcessControlDescription As String = Nothing
        Private _NonBillable As String = Nothing
        Private _StatusCode As String = Nothing
        Private _StatusDescription As String = Nothing
        Private _ManagerCode As String = Nothing
        Private _Manager As String = Nothing
        Private _GutPercentComplete As Nullable(Of Decimal) = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _DueDate As Nullable(Of Date) = Nothing
        Private _CompletedDate As Nullable(Of Date) = Nothing
        Private _ForecastDescription As String = Nothing
        Private _PostPeriodStart As String = Nothing
        Private _PostPeriodEnd As String = Nothing
        Private _Budget As Nullable(Of Decimal) = Nothing
        Private _AssignedToOfficeCode As String = Nothing
        Private _AssignedToOfficeName As String = Nothing
        Private _AssignedToUserCode As String = Nothing
        Private _AssignedToUserName As String = Nothing
        Private _ForecastComment As String = Nothing
        Private _ForecastJobComment As String = Nothing
        Private _ForecastCreatedDate As Date = Nothing
        Private _ForecastModifiedDate As Nullable(Of Date) = Nothing
        Private _ForecastApprovedDate As Nullable(Of Date) = Nothing
        Private _ApprovedRevisionNumber As Nullable(Of Integer) = Nothing
        Private _HighestRevisionNumber As Nullable(Of Integer) = Nothing
        Private _Approved As String = Nothing
        Private _Forecast As Decimal = Nothing
        Private _Actual As Decimal = Nothing
        Private _Variance As Nullable(Of Decimal) = Nothing
        Private _PostPeriod As String = Nothing
        Private _PostPeriodBillingAmount As Nullable(Of Decimal) = Nothing
        Private _PostPeriodRevenueAmount As Nullable(Of Decimal) = Nothing
        Private _TotalJobBillingAmount As Nullable(Of Decimal) = Nothing
        Private _TotalJobRevenueAmount As Nullable(Of Decimal) = Nothing
        Private _ActualJobBillingAmount As Nullable(Of Decimal) = Nothing
        Private _ActualJobRevenueAmount As Nullable(Of Decimal) = Nothing
        Private _TotalActualJobBillingAmount As Nullable(Of Decimal) = Nothing
        Private _TotalActualJobRevenueAmount As Nullable(Of Decimal) = Nothing
        Private _TotalOpenPurchaseOrderBillableAmount As Nullable(Of Decimal) = Nothing
        Private _TotalOpenPurchaseOrderRevenueAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateNumber As Nullable(Of Integer) = Nothing
        Private _EstimateComponentNumber As Nullable(Of Short) = Nothing
        Private _ApprovedEstimateBillingAmount As Nullable(Of Decimal) = Nothing
        Private _ApprovedEstimateRevenueAmount As Nullable(Of Decimal) = Nothing
        Private _JobForecastID As Integer = Nothing
        Private _JobForecastRevisionID As Integer = Nothing
        Private _JobForecastJobID As Integer = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
    AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)
            Get
                ID = _ID
            End Get
            Set
                _ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set
                _ClientName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set
                _DivisionName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set
                _ProductName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set
                _OfficeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set
                _OfficeName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewBusiness() As String
            Get
                NewBusiness = _NewBusiness
            End Get
            Set
                _NewBusiness = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDV1() As String
            Get
                ProductUDV1 = _ProductUDV1
            End Get
            Set
                _ProductUDV1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDV2() As String
            Get
                ProductUDV2 = _ProductUDV2
            End Get
            Set
                _ProductUDV2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDV3() As String
            Get
                ProductUDV3 = _ProductUDV3
            End Get
            Set
                _ProductUDV3 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDV4() As String
            Get
                ProductUDV4 = _ProductUDV4
            End Get
            Set
                _ProductUDV4 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Industry() As String
            Get
                Industry = _Industry
            End Get
            Set
                _Industry = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Specialty() As String
            Get
                Specialty = _Specialty
            End Get
            Set
                _Specialty = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Region() As String
            Get
                Region = _Region
            End Get
            Set
                _Region = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NumberOfEmployees() As Nullable(Of Integer)
            Get
                NumberOfEmployees = _NumberOfEmployees
            End Get
            Set
                _NumberOfEmployees = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Source() As String
            Get
                Source = _Source
            End Get
            Set
                _Source = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Probability() As Nullable(Of Byte)
            Get
                Probability = _Probability
            End Get
            Set
                _Probability = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Rating() As String
            Get
                Rating = _Rating
            End Get
            Set
                _Rating = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CurrentProvider() As String
            Get
                CurrentProvider = _CurrentProvider
            End Get
            Set
                _CurrentProvider = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LeadDate() As Nullable(Of Date)
            Get
                LeadDate = _LeadDate
            End Get
            Set
                _LeadDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SoldDate() As Nullable(Of Date)
            Get
                SoldDate = _SoldDate
            End Get
            Set
                _SoldDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LostDate() As Nullable(Of Date)
            Get
                LostDate = _LostDate
            End Get
            Set
                _LostDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set
                _JobNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set
                _JobDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobTemplateCode() As String
            Get
                JobTemplateCode = _JobTemplateCode
            End Get
            Set
                _JobTemplateCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set
                _SalesClassCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set
                _SalesClassDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set
                _CampaignCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set
                _CampaignName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set
                _ClientReference = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassFormatCode() As String
            Get
                SalesClassFormatCode = _SalesClassFormatCode
            End Get
            Set
                _SalesClassFormatCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassFormatDescription() As String
            Get
                SalesClassFormatDescription = _SalesClassFormatDescription
            End Get
            Set
                _SalesClassFormatDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComplexityCode() As String
            Get
                ComplexityCode = _ComplexityCode
            End Get
            Set
                _ComplexityCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComplexityDescription() As String
            Get
                ComplexityDescription = _ComplexityDescription
            End Get
            Set
                _ComplexityDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PromotionCode() As String
            Get
                PromotionCode = _PromotionCode
            End Get
            Set
                _PromotionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PromotionDescription() As String
            Get
                PromotionDescription = _PromotionDescription
            End Get
            Set
                _PromotionDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobUDF1() As String
            Get
                JobUDF1 = _JobUDF1
            End Get
            Set
                _JobUDF1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobUDF2() As String
            Get
                JobUDF2 = _JobUDF2
            End Get
            Set
                _JobUDF2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobUDF3() As String
            Get
                JobUDF3 = _JobUDF3
            End Get
            Set
                _JobUDF3 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobUDF4() As String
            Get
                JobUDF4 = _JobUDF4
            End Get
            Set
                _JobUDF4 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobUDF5() As String
            Get
                JobUDF5 = _JobUDF5
            End Get
            Set
                _JobUDF5 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobCreateDate() As Nullable(Of Date)
            Get
                JobCreateDate = _JobCreateDate
            End Get
            Set
                _JobCreateDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDateOpened() As Nullable(Of Date)
            Get
                JobDateOpened = _JobDateOpened
            End Get
            Set
                _JobDateOpened = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set
                _JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set
                _JobComponent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set
                _JobComponentDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set
                _AccountExecutiveCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set
                _AccountExecutive = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AlertGroup() As String
            Get
                AlertGroup = _AlertGroup
            End Get
            Set
                _AlertGroup = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientContactCode() As String
            Get
                ClientContactCode = _ClientContactCode
            End Get
            Set
                _ClientContactCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientContact() As String
            Get
                ClientContact = _ClientContact
            End Get
            Set
                _ClientContact = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobTypeCode() As String
            Get
                JobTypeCode = _JobTypeCode
            End Get
            Set
                _JobTypeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobTypeDescription() As String
            Get
                JobTypeDescription = _JobTypeDescription
            End Get
            Set
                _JobTypeDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DepartmentCode() As String
            Get
                DepartmentCode = _DepartmentCode
            End Get
            Set
                _DepartmentCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DepartmentDescription() As String
            Get
                DepartmentDescription = _DepartmentDescription
            End Get
            Set
                _DepartmentDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set
                _ClientPO = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set
                _AdNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumberDescription() As String
            Get
                AdNumberDescription = _AdNumberDescription
            End Get
            Set
                _AdNumberDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set
                _MarketCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set
                _MarketDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Format() As String
            Get
                Format = _Format
            End Get
            Set
                _Format = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentUDV1() As String
            Get
                JobComponentUDV1 = _JobComponentUDV1
            End Get
            Set
                _JobComponentUDV1 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentUDV2() As String
            Get
                JobComponentUDV2 = _JobComponentUDV2
            End Get
            Set
                _JobComponentUDV2 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentUDV3() As String
            Get
                JobComponentUDV3 = _JobComponentUDV3
            End Get
            Set
                _JobComponentUDV3 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentUDV4() As String
            Get
                JobComponentUDV4 = _JobComponentUDV4
            End Get
            Set
                _JobComponentUDV4 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentUDV5() As String
            Get
                JobComponentUDV5 = _JobComponentUDV5
            End Get
            Set
                _JobComponentUDV5 = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountNumber() As String
            Get
                AccountNumber = _AccountNumber
            End Get
            Set
                _AccountNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FiscalPeriodCode() As String
            Get
                FiscalPeriodCode = _FiscalPeriodCode
            End Get
            Set
                _FiscalPeriodCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FiscalPeriodDescription() As String
            Get
                FiscalPeriodDescription = _FiscalPeriodDescription
            End Get
            Set
                _FiscalPeriodDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DateOpened() As Nullable(Of Date)
            Get
                DateOpened = _DateOpened
            End Get
            Set
                _DateOpened = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobProcessControlNumber() As Nullable(Of Short)
            Get
                JobProcessControlNumber = _JobProcessControlNumber
            End Get
            Set
                _JobProcessControlNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobProcessControlDescription() As String
            Get
                JobProcessControlDescription = _JobProcessControlDescription
            End Get
            Set
                _JobProcessControlDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillable() As String
            Get
                NonBillable = _NonBillable
            End Get
            Set
                _NonBillable = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StatusCode() As String
            Get
                StatusCode = _StatusCode
            End Get
            Set
                _StatusCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StatusDescription() As String
            Get
                StatusDescription = _StatusDescription
            End Get
            Set
                _StatusDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ManagerCode() As String
            Get
                ManagerCode = _ManagerCode
            End Get
            Set
                _ManagerCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Manager() As String
            Get
                Manager = _Manager
            End Get
            Set
                _Manager = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GutPercentComplete() As Nullable(Of Decimal)
            Get
                GutPercentComplete = _GutPercentComplete
            End Get
            Set
                _GutPercentComplete = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set
                _StartDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DueDate() As Nullable(Of Date)
            Get
                DueDate = _DueDate
            End Get
            Set
                _DueDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompletedDate() As Nullable(Of Date)
            Get
                CompletedDate = _CompletedDate
            End Get
            Set
                _CompletedDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastDescription() As String
            Get
                ForecastDescription = _ForecastDescription
            End Get
            Set
                _ForecastDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodStart() As String
            Get
                PostPeriodStart = _PostPeriodStart
            End Get
            Set
                _PostPeriodStart = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodEnd() As String
            Get
                PostPeriodEnd = _PostPeriodEnd
            End Get
            Set
                _PostPeriodEnd = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AssignedToOfficeCode() As String
            Get
                AssignedToOfficeCode = _AssignedToOfficeCode
            End Get
            Set
                _AssignedToOfficeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AssignedToOfficeName() As String
            Get
                AssignedToOfficeName = _AssignedToOfficeName
            End Get
            Set
                _AssignedToOfficeName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AssignedToUserCode() As String
            Get
                AssignedToUserCode = _AssignedToUserCode
            End Get
            Set
                _AssignedToUserCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AssignedToUserName() As String
            Get
                AssignedToUserName = _AssignedToUserName
            End Get
            Set
                _AssignedToUserName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastComment() As String
            Get
                ForecastComment = _ForecastComment
            End Get
            Set
                _ForecastComment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastJobComment() As String
            Get
                ForecastJobComment = _ForecastJobComment
            End Get
            Set
                _ForecastJobComment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastCreatedDate() As Date
            Get
                ForecastCreatedDate = _ForecastCreatedDate
            End Get
            Set
                _ForecastCreatedDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastModifiedDate() As Nullable(Of Date)
            Get
                ForecastModifiedDate = _ForecastModifiedDate
            End Get
            Set
                _ForecastModifiedDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastApprovedDate() As Nullable(Of Date)
            Get
                ForecastApprovedDate = _ForecastApprovedDate
            End Get
            Set
                _ForecastApprovedDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApprovedRevisionNumber() As Nullable(Of Integer)
            Get
                ApprovedRevisionNumber = _ApprovedRevisionNumber
            End Get
            Set
                _ApprovedRevisionNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HighestRevisionNumber() As Nullable(Of Integer)
            Get
                HighestRevisionNumber = _HighestRevisionNumber
            End Get
            Set
                _HighestRevisionNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Approved() As String
            Get
                Approved = _Approved
            End Get
            Set
                _Approved = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Budget() As Nullable(Of Decimal)
            Get
                Budget = _Budget
            End Get
            Set
                _Budget = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Forecast() As Decimal
            Get
                Forecast = _Forecast
            End Get
            Set
                _Forecast = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Actual() As Decimal
            Get
                Actual = _Actual
            End Get
            Set
                _Actual = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Variance() As Nullable(Of Decimal)
            Get
                Variance = _Variance
            End Get
            Set
                _Variance = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriod() As String
            Get
                PostPeriod = _PostPeriod
            End Get
            Set
                _PostPeriod = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodBillingAmount() As Nullable(Of Decimal)
            Get
                PostPeriodBillingAmount = _PostPeriodBillingAmount
            End Get
            Set
                _PostPeriodBillingAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodRevenueAmount() As Nullable(Of Decimal)
            Get
                PostPeriodRevenueAmount = _PostPeriodRevenueAmount
            End Get
            Set
                _PostPeriodRevenueAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalJobBillingAmount() As Nullable(Of Decimal)
            Get
                TotalJobBillingAmount = _TotalJobBillingAmount
            End Get
            Set
                _TotalJobBillingAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalJobRevenueAmount() As Nullable(Of Decimal)
            Get
                TotalJobRevenueAmount = _TotalJobRevenueAmount
            End Get
            Set
                _TotalJobRevenueAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualJobBillingAmount() As Nullable(Of Decimal)
            Get
                ActualJobBillingAmount = _ActualJobBillingAmount
            End Get
            Set
                _ActualJobBillingAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualJobRevenueAmount() As Nullable(Of Decimal)
            Get
                ActualJobRevenueAmount = _ActualJobRevenueAmount
            End Get
            Set
                _ActualJobRevenueAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalActualJobBillingAmount() As Nullable(Of Decimal)
            Get
                TotalActualJobBillingAmount = _TotalActualJobBillingAmount
            End Get
            Set
                _TotalActualJobBillingAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalActualJobRevenueAmount() As Nullable(Of Decimal)
            Get
                TotalActualJobRevenueAmount = _TotalActualJobRevenueAmount
            End Get
            Set
                _TotalActualJobRevenueAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalOpenPurchaseOrderBillableAmount() As Nullable(Of Decimal)
            Get
                TotalOpenPurchaseOrderBillableAmount = _TotalOpenPurchaseOrderBillableAmount
            End Get
            Set
                _TotalOpenPurchaseOrderBillableAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalOpenPurchaseOrderRevenueAmount() As Nullable(Of Decimal)
            Get
                TotalOpenPurchaseOrderRevenueAmount = _TotalOpenPurchaseOrderRevenueAmount
            End Get
            Set
                _TotalOpenPurchaseOrderRevenueAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateNumber() As Nullable(Of Integer)
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set
                _EstimateNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponentNumber() As Nullable(Of Short)
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set
                _EstimateComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApprovedEstimateBillingAmount() As Nullable(Of Decimal)
            Get
                ApprovedEstimateBillingAmount = _ApprovedEstimateBillingAmount
            End Get
            Set
                _ApprovedEstimateBillingAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApprovedEstimateRevenueAmount() As Nullable(Of Decimal)
            Get
                ApprovedEstimateRevenueAmount = _ApprovedEstimateRevenueAmount
            End Get
            Set
                _ApprovedEstimateRevenueAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute(),
    AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobForecastID() As Integer
            Get
                JobForecastID = _JobForecastID
            End Get
            Set
                _JobForecastID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute(),
    AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobForecastRevisionID() As Integer
            Get
                JobForecastRevisionID = _JobForecastRevisionID
            End Get
            Set
                _JobForecastRevisionID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
    System.Runtime.Serialization.DataMemberAttribute(),
    AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobForecastJobID() As Integer
            Get
                JobForecastJobID = _JobForecastJobID
            End Get
            Set
                _JobForecastJobID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
