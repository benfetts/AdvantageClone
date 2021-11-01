Namespace Reporting.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ReportingObjectContext", Name:="DigitalResultReport")>
    <Serializable()>
    Public Class DigitalResultReport
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanID
            MediaPlanDescription
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            EstimateID
            EstimateDescription
            MediaType
            SalesClassCode
            SalesClassDescription
            CampaignID
            CampaignCode
            CampaignName
            VendorCode
            VendorName
            MarketCode
            MarketDescription
            AdSizeCode
            AdSizeDescription
            AdNumber
            AdNumberDescription
            InternetTypeCode
            InternetTypeDescription
            Placement
            PlacementPixelSize
            PlacementURL
            Creative
            Tactic
            PagePositioning
            StartDate
            EndDate
            NetGrossRate
            Units
            Impressions
            ImpressionsViewable
            ImpressionsMeasurable
            Clicks
            ClickRate
            TotalConversions
            TotalConversionsB
            TotalConversionsC
            ConversionRate
            ConversionRateB
            ConversionRateC
            Rate
            NetDollars
            GrossDollars
            TargetAudience
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _MediaPlanID As Nullable(Of Integer) = Nothing
        Private _MediaPlanDescription As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _EstimateID As Nullable(Of Integer) = Nothing
        Private _EstimateDescription As String = Nothing
        Private _MediaType As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _AdSizeCode As String = Nothing
        Private _AdSizeDescription As String = Nothing
        Private _AdNumber As String = Nothing
        Private _AdNumberDescription As String = Nothing
        Private _InternetTypeCode As String = Nothing
        Private _InternetTypeDescription As String = Nothing
        Private _Placement As String = Nothing
        Private _PlacementPixelSize As String = Nothing
        Private _PlacementURL As String = Nothing
        Private _Creative As String = Nothing
        Private _Tactic As String = Nothing
        Private _PagePositioning As String = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _NetGrossRate As String = Nothing
        Private _Units As Nullable(Of Decimal) = Nothing
        Private _Impressions As Nullable(Of Integer) = Nothing
        Private _Clicks As Nullable(Of Decimal) = Nothing
        Private _ClickRate As Nullable(Of Decimal) = Nothing
        Private _TotalConversions As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _NetDollars As Nullable(Of Decimal) = Nothing
        Private _GrossDollars As Nullable(Of Decimal) = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _ImpressionsViewable As Nullable(Of Decimal) = Nothing
        Private _ImpressionsMeasurable As Nullable(Of Decimal) = Nothing
        Private _TotalConversionsB As Nullable(Of Decimal) = Nothing
        Private _TotalConversionsC As Nullable(Of Decimal) = Nothing
        Private _TargetAudience As String = Nothing
        Private _ConversionRate As Nullable(Of Decimal) = Nothing
        Private _ConversionRateB As Nullable(Of Decimal) = Nothing
        Private _ConversionRateC As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)
            Get
                ID = _ID
            End Get
            Set(value As Nullable(Of System.Guid))
                _ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaPlanID() As Nullable(Of Integer)
            Get
                MediaPlanID = _MediaPlanID
            End Get
            Set(value As Nullable(Of Integer))
                _MediaPlanID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaPlanDescription() As String
            Get
                MediaPlanDescription = _MediaPlanDescription
            End Get
            Set(value As String)
                _MediaPlanDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Nullable(Of Integer)
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
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set
                _JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set
                _JobComponentDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateID() As Nullable(Of Integer)
            Get
                EstimateID = _EstimateID
            End Get
            Set(value As Nullable(Of Integer))
                _EstimateID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateDescription() As String
            Get
                EstimateDescription = _EstimateDescription
            End Get
            Set(value As String)
                _EstimateDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(value As String)
                _MarketCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(value As String)
                _MarketDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdSizeCode() As String
            Get
                AdSizeCode = _AdSizeCode
            End Get
            Set(value As String)
                _AdSizeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdSizeDescription() As String
            Get
                AdSizeDescription = _AdSizeDescription
            End Get
            Set(value As String)
                _AdSizeDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(value As String)
                _AdNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumberDescription() As String
            Get
                AdNumberDescription = _AdNumberDescription
            End Get
            Set(value As String)
                _AdNumberDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetTypeCode() As String
            Get
                InternetTypeCode = _InternetTypeCode
            End Get
            Set(value As String)
                _InternetTypeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetTypeDescription() As String
            Get
                InternetTypeDescription = _InternetTypeDescription
            End Get
            Set(value As String)
                _InternetTypeDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TargetAudience() As String
            Get
                TargetAudience = _TargetAudience
            End Get
            Set
                _TargetAudience = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Placement() As String
            Get
                Placement = _Placement
            End Get
            Set(value As String)
                _Placement = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PlacementPixelSize() As String
            Get
                PlacementPixelSize = _PlacementPixelSize
            End Get
            Set(value As String)
                _PlacementPixelSize = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PlacementURL() As String
            Get
                PlacementURL = _PlacementURL
            End Get
            Set(value As String)
                _PlacementURL = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Creative() As String
            Get
                Creative = _Creative
            End Get
            Set(value As String)
                _Creative = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Tactic() As String
            Get
                Tactic = _Tactic
            End Get
            Set(value As String)
                _Tactic = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PagePositioning() As String
            Get
                PagePositioning = _PagePositioning
            End Get
            Set(value As String)
                _PagePositioning = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(value As Nullable(Of Date))
                _StartDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndDate() As Nullable(Of Date)
            Get
                EndDate = _EndDate
            End Get
            Set(value As Nullable(Of Date))
                _EndDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Net / Gross Rate")>
        Public Property NetGrossRate() As String
            Get
                NetGrossRate = _NetGrossRate
            End Get
            Set(value As String)
                _NetGrossRate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Units() As Nullable(Of Decimal)
            Get
                Units = _Units
            End Get
            Set(value As Nullable(Of Decimal))
                _Units = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Impressions() As Nullable(Of Integer)
            Get
                Impressions = _Impressions
            End Get
            Set(value As Nullable(Of Integer))
                _Impressions = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
    AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property ImpressionsViewable() As Nullable(Of Decimal)
            Get
                ImpressionsViewable = _ImpressionsViewable
            End Get
            Set
                _ImpressionsViewable = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
    AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property ImpressionsMeasurable() As Nullable(Of Decimal)
            Get
                ImpressionsMeasurable = _ImpressionsMeasurable
            End Get
            Set
                _ImpressionsMeasurable = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Clicks() As Nullable(Of Decimal)
            Get
                Clicks = _Clicks
            End Get
            Set(value As Nullable(Of Decimal))
                _Clicks = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClickRate() As Nullable(Of Decimal)
            Get
                ClickRate = _ClickRate
            End Get
            Set(value As Nullable(Of Decimal))
                _ClickRate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property TotalConversions() As Nullable(Of Decimal)
            Get
                TotalConversions = _TotalConversions
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalConversions = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property TotalConversionsB() As Nullable(Of Decimal)
            Get
                TotalConversionsB = _TotalConversionsB
            End Get
            Set
                _TotalConversionsB = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property TotalConversionsC() As Nullable(Of Decimal)
            Get
                TotalConversionsC = _TotalConversionsC
            End Get
            Set
                _TotalConversionsC = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ConversionRate() As Nullable(Of Decimal)
            Get
                ConversionRate = _ConversionRate
            End Get
            Set
                _ConversionRate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ConversionRateB() As Nullable(Of Decimal)
            Get
                ConversionRateB = _ConversionRateB
            End Get
            Set
                _ConversionRateB = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ConversionRateC() As Nullable(Of Decimal)
            Get
                ConversionRateC = _ConversionRateC
            End Get
            Set
                _ConversionRateC = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetDollars() As Nullable(Of Decimal)
            Get
                NetDollars = _NetDollars
            End Get
            Set(value As Nullable(Of Decimal))
                _NetDollars = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GrossDollars() As Nullable(Of Decimal)
            Get
                GrossDollars = _GrossDollars
            End Get
            Set(value As Nullable(Of Decimal))
                _GrossDollars = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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