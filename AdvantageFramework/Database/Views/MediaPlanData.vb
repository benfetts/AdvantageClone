Namespace Database.Views

    <Table("V_MEDIA_PLAN")>
    Public Class MediaPlanData
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
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
			GrossBudget
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
            EstimateID
            EstimateName
            EstimateBudget
            MediaType
            SalesClassCode
            SalesClassDescription
            CampaignCode
            CampaignName
			StartDate
			EndDate
            Month
            MonthName
            Quarter
            Year
            Demo1
            Demo2
            Units
            Impressions
            Clicks
            Rate
            Dollars
            AgencyFee
            BillAmount
            PlanQuantity
            PlanNetAmount
            PlanCommission
            IsApproved
            ApprovedBy
            ApprovedDate
            MasterPlanID
            MasterPlanName
            OrderNumber
            LineNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Guid
        <MaxLength(4)>
        <Column("OfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <Column("OfficeName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.OfficeName)>
        Public Property OfficeName() As String
        <Required>
        <MaxLength(6)>
        <Column("ClientCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        <Column("ClientName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ClientName)>
        Public Property ClientName() As String
        <MaxLength(6)>
        <Column("DivisionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <Column("DivisionName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.DivisionName)>
        Public Property DivisionName() As String
        <MaxLength(6)>
        <Column("ProductCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
        <MaxLength(40)>
        <Column("ProductDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ProductName)>
        Public Property ProductDescription() As String
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("PlanID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", IsReadOnlyColumn:=True)>
        Public Property PlanID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("PlanDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PlanDescription() As String
        <MaxLength(64)>
        <Column("ClientContact", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientContact() As String
        <Required>
		<Column("PlanStartDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property PlanStartDate() As Date
		<Required>
		<Column("PlanEndDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property PlanEndDate() As Date
		<Column("GrossBudget")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property GrossBudget() As Nullable(Of Decimal)
		<Required>
		<MaxLength(100)>
		<Column("CreatedByUserCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CreatedDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property CreatedDate() As Date
		<MaxLength(100)>
		<Column("ModifiedByUserCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property ModifiedByUserCode() As String
		<Column("ModifiedDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property ModifiedDate() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("EstimateID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EstimateID() As String
        <MaxLength(50)>
        <Column("EstimateName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EstimateName() As String
        <Column("EstimateBudget")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property EstimateBudget() As Nullable(Of Decimal)
        <Required>
		<MaxLength(1)>
		<Column("MediaType", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaType() As String
		<MaxLength(6)>
		<Column("SalesClassCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property SalesClassCode() As String
		<MaxLength(30)>
		<Column("SalesClassDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property SalesClassDescription() As String
		<MaxLength(6)>
		<Column("CampaignCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property CampaignCode() As String
		<MaxLength(60)>
		<Column("CampaignName", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property CampaignName() As String
		<Required>
		<Column("StartDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property StartDate() As Date
		<Required>
		<Column("EndDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property EndDate() As Date
		<Column("Month")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Month() As Nullable(Of Integer)
        <Column("MonthName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property MonthName() As String
        <Column("Quarter")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property Quarter() As Nullable(Of Integer)
		<Column("Year")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property Year() As Nullable(Of Integer)
		<Column("Demo1")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f1")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property Demo1() As Nullable(Of Decimal)
		<Column("Demo2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f1")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property Demo2() As Nullable(Of Decimal)
		<Column("Units")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f1")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property Units() As Nullable(Of Decimal)
		<Column("Impressions")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property Impressions() As Nullable(Of Decimal)
		<Column("Clicks")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property Clicks() As Nullable(Of Decimal)
		<Column("Rate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f4")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 4)>
        Public Property Rate() As Nullable(Of Decimal)
		<Column("Dollars")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property Dollars() As Nullable(Of Decimal)
		<Column("AgencyFee")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property AgencyFee() As Nullable(Of Decimal)
		<Column("BillAmount")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property BillAmount() As Nullable(Of Decimal)
		<Column("PlanQuantity")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property PlanQuantity() As Nullable(Of Decimal)
		<Column("PlanNetAmount")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property PlanNetAmount() As Nullable(Of Decimal)
		<Column("PlanCommission")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property PlanCommission() As Nullable(Of Decimal)
		<Required>
		<Column("IsApproved")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsApproved() As Boolean
        <MaxLength(6)>
        <Column("ApprovedBy", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovedBy() As String
        <Column("ApprovedDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovedDate() As Nullable(Of Date)
        <Column("MasterPlanID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property MasterPlanID As Nullable(Of Integer)
        <Column("MasterPlanName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MasterPlanName As String
        <Column("OrderNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property OrderNumber As Nullable(Of Integer)
        <Column("LineNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property LineNumber As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
