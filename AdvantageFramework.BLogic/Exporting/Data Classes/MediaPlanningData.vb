Namespace Exporting.DataClasses

    <Serializable()>
    Public Class MediaPlanningData
        Inherits BaseClasses.BaseClass
        Implements AdvantageFramework.Exporting.Interfaces.IExportData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RowIndex
            MediaPlanDetailLevelLineDataID
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            PlanID
            PlanDescription
            ClientContact
			PlanStartDate
			PlanEndDate
            Budget
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
            EstimateID
            MediaTypeCode
            MediaType
            SalesClassCode
            SalesClassDescription
            CampaignCode
			CampaignName
			'StartDate
			'EndDate
			Month
            Quarter
            Year
            VendorCode
            VendorName
            LineStartDate
            LineEndDate
            Demo1
            Demo2
            Units
            Impressions
            Clicks
            Columns
            InchesLines
            Rate
            Dollars
            AgencyFee
            BillAmount
            OrderID
            OrderLineID
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            Sunday
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _RowIndex As Integer = Nothing
        Private _MediaPlanDetailLevelLineDataID As Integer = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _PlanID As Integer = Nothing
        Private _PlanDescription As String = Nothing
        Private _ClientContact As String = Nothing
		Private _PlanStartDate As Date = Nothing
		Private _PlanEndDate As Date = Nothing
        Private _Budget As Nullable(Of Decimal) = Nothing
        Private _CreatedByUserCode As String = Nothing
        Private _CreatedDate As Date = Nothing
        Private _ModifiedByUserCode As String = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing
        Private _EstimateID As String = Nothing
        Private _MediaTypeCode As String = Nothing
        Private _MediaType As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _StartDate As Date = Nothing
        Private _EndDate As Date = Nothing
        Private _Month As Nullable(Of Integer) = Nothing
        Private _Quarter As Nullable(Of Integer) = Nothing
        Private _Year As Nullable(Of Integer) = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _LineStartDate As Nullable(Of Date) = Nothing
        Private _LineEndDate As Nullable(Of Date) = Nothing
        Private _Demo1 As Nullable(Of Decimal) = Nothing
        Private _Demo2 As Nullable(Of Decimal) = Nothing
        Private _Units As Nullable(Of Decimal) = Nothing
        Private _Impressions As Nullable(Of Decimal) = Nothing
        Private _Clicks As Nullable(Of Decimal) = Nothing
        Private _Columns As Nullable(Of Decimal) = Nothing
        Private _InchesLines As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Dollars As Nullable(Of Decimal) = Nothing
        Private _NetCharge As Nullable(Of Decimal) = Nothing
        Private _AgencyFee As Nullable(Of Decimal) = Nothing
        Private _BillAmount As Nullable(Of Decimal) = Nothing
        Private _OrderID As Nullable(Of Integer) = Nothing
        Private _OrderLineID As Nullable(Of Integer) = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderLineNumber As Nullable(Of Integer) = Nothing
        Private _Monday As Boolean
        Private _Tuesday As Boolean
        Private _Wednesday As Boolean
        Private _Thursday As Boolean
        Private _Friday As Boolean
        Private _Saturday As Boolean
        Private _Sunday As Boolean

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(value As System.Guid)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property RowIndex() As Integer
            Get
                RowIndex = _RowIndex
            End Get
            Set(value As Integer)
                _RowIndex = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailLevelLineDataID() As Integer
            Get
                MediaPlanDetailLevelLineDataID = _MediaPlanDetailLevelLineDataID
            End Get
            Set(value As Integer)
                _MediaPlanDetailLevelLineDataID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, PropertyType:=BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.OfficeName)>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ClientName)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.DivisionName)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ProductName)>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PlanID() As Integer
            Get
                PlanID = _PlanID
            End Get
            Set(value As Integer)
                _PlanID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PlanDescription() As String
            Get
                PlanDescription = _PlanDescription
            End Get
            Set(value As String)
                _PlanDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientContact() As String
            Get
                ClientContact = _ClientContact
            End Get
            Set(value As String)
                _ClientContact = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PlanStartDate() As Date
            Get
                PlanStartDate = _PlanStartDate
            End Get
            Set(value As Date)
                _StartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PlanEndDate() As Date
            Get
                PlanEndDate = _PlanEndDate
            End Get
            Set(value As Date)
                _PlanEndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Budget() As Nullable(Of Decimal)
            Get
                Budget = _Budget
            End Get
            Set(value As Nullable(Of Decimal))
                _Budget = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CreatedByUserCode() As String
            Get
                CreatedByUserCode = _CreatedByUserCode
            End Get
            Set(value As String)
                _CreatedByUserCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CreatedDate() As Date
            Get
                CreatedDate = _CreatedDate
            End Get
            Set(value As Date)
                _CreatedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ModifiedByUserCode() As String
            Get
                ModifiedByUserCode = _ModifiedByUserCode
            End Get
            Set(value As String)
                _ModifiedByUserCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(value As Nullable(Of Date))
                _ModifiedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EstimateID() As String
            Get
                EstimateID = _EstimateID
            End Get
            Set(value As String)
                _EstimateID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MediaTypeCode() As String
            Get
                MediaTypeCode = _MediaTypeCode
            End Get
            Set(value As String)
                _MediaTypeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property StartDate() As Date
            Get
                StartDate = _StartDate
            End Get
            Set(value As Date)
                _StartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EndDate() As Date
            Get
                EndDate = _EndDate
            End Get
            Set(value As Date)
                _EndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Month() As Nullable(Of Integer)
            Get
                Month = _Month
            End Get
            Set(value As Nullable(Of Integer))
                _Month = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Quarter() As Nullable(Of Integer)
            Get
                Quarter = _Quarter
            End Get
            Set(value As Nullable(Of Integer))
                _Quarter = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Year() As Nullable(Of Integer)
            Get
                Year = _Year
            End Get
            Set(value As Nullable(Of Integer))
                _Year = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.VendorCode)>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.VendorName)>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineStartDate() As Nullable(Of Date)
            Get
                LineStartDate = _LineStartDate
            End Get
            Set(value As Nullable(Of Date))
                _LineStartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineEndDate() As Nullable(Of Date)
            Get
                LineEndDate = _LineEndDate
            End Get
            Set(value As Nullable(Of Date))
                _LineEndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f1", IsReadOnlyColumn:=True)>
        Public Property Demo1() As Nullable(Of Decimal)
            Get
                Demo1 = _Demo1
            End Get
            Set(value As Nullable(Of Decimal))
                _Demo1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f1", IsReadOnlyColumn:=True)>
        Public Property Demo2() As Nullable(Of Decimal)
            Get
                Demo2 = _Demo2
            End Get
            Set(value As Nullable(Of Decimal))
                _Demo2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f1", IsReadOnlyColumn:=True)>
        Public Property Units() As Nullable(Of Decimal)
            Get
                Units = _Units
            End Get
            Set(value As Nullable(Of Decimal))
                _Units = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", IsReadOnlyColumn:=True)>
        Public Property Impressions() As Nullable(Of Decimal)
            Get
                Impressions = _Impressions
            End Get
            Set(value As Nullable(Of Decimal))
                _Impressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", IsReadOnlyColumn:=True)>
        Public Property Clicks() As Nullable(Of Decimal)
            Get
                Clicks = _Clicks
            End Get
            Set(value As Nullable(Of Decimal))
                _Clicks = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2", IsReadOnlyColumn:=True)>
        Public Property Columns() As Nullable(Of Decimal)
            Get
                Columns = _Columns
            End Get
            Set(value As Nullable(Of Decimal))
                _Columns = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2", IsReadOnlyColumn:=True)>
        Public Property InchesLines() As Nullable(Of Decimal)
            Get
                InchesLines = _InchesLines
            End Get
            Set(value As Nullable(Of Decimal))
                _InchesLines = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f4", IsReadOnlyColumn:=True)>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2", IsReadOnlyColumn:=True)>
        Public Property Dollars() As Nullable(Of Decimal)
            Get
                Dollars = _Dollars
            End Get
            Set(value As Nullable(Of Decimal))
                _Dollars = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2", IsReadOnlyColumn:=True)>
        Public Property NetCharge() As Nullable(Of Decimal)
            Get
                NetCharge = _NetCharge
            End Get
            Set(value As Nullable(Of Decimal))
                _NetCharge = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2", IsReadOnlyColumn:=True)>
        Public Property AgencyFee() As Nullable(Of Decimal)
            Get
                AgencyFee = _AgencyFee
            End Get
            Set(value As Nullable(Of Decimal))
                _AgencyFee = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2", IsReadOnlyColumn:=True)>
        Public Property BillAmount() As Nullable(Of Decimal)
            Get
                BillAmount = _BillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BillAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property OrderID() As Nullable(Of Integer)
            Get
                OrderID = _OrderID
            End Get
            Set(value As Nullable(Of Integer))
                _OrderID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property OrderLineID() As Nullable(Of Integer)
            Get
                OrderLineID = _OrderLineID
            End Get
            Set(value As Nullable(Of Integer))
                _OrderLineID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Monday() As Boolean
            Get
                Monday = _Monday
            End Get
            Set(value As Boolean)
                _Monday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Tuesday() As Boolean
            Get
                Tuesday = _Tuesday
            End Get
            Set(value As Boolean)
                _Tuesday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Wednesday() As Boolean
            Get
                Wednesday = _Wednesday
            End Get
            Set(value As Boolean)
                _Wednesday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Thursday() As Boolean
            Get
                Thursday = _Thursday
            End Get
            Set(value As Boolean)
                _Thursday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Friday() As Boolean
            Get
                Friday = _Friday
            End Get
            Set(value As Boolean)
                _Friday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Saturday() As Boolean
            Get
                Saturday = _Saturday
            End Get
            Set(value As Boolean)
                _Saturday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Sunday() As Boolean
            Get
                Sunday = _Sunday
            End Get
            Set(value As Boolean)
                _Sunday = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderLineNumber() As Nullable(Of Integer)
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderLineNumber = value
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
