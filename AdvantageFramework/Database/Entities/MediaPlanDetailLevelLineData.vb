Namespace Database.Entities

	<Table("MEDIA_PLAN_DTL_LEVEL_LINE_DATA")>
	Public Class MediaPlanDetailLevelLineData
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaPlanDetailID
			MediaPlanID
			StartDate
			Demo1
			Demo2
			Dollars
			Units
			Rate
			Note
			Color
			RowIndex
			Impressions
			Clicks
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
			ModifiedDate
			AgencyFee
			BillAmount
			OrderID
			OrderLineID
			OrderNumber
			OrderLineNumber
			Sunday
			Monday
			Tuesday
			Wednesday
			Thursday
			Friday
			Saturday
			HasPendingOrders
            EndDate
            NetCharge
            Columns
            InchesLines
            IsActualized
            MediaPlan
            MediaPlanDetail
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_PLAN_DTL_LEVEL_LINE_DATA_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<Column("MEDIA_PLAN_DTL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property MediaPlanDetailID() As Integer
		<Required>
		<Column("MEDIA_PLAN_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property MediaPlanID() As Integer
		<Required>
		<Column("START_DATE")>
		<System.ComponentModel.DisplayName("Start Date")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="d", CustomColumnCaption:="Start Date")>
		Public Property StartDate() As Date
		<Column("DEMO1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n1")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
		Public Property Demo1() As Nullable(Of Decimal)
		<Column("DEMO2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n1")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
		Public Property Demo2() As Nullable(Of Decimal)
		<Column("DOLLARS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property Dollars() As Nullable(Of Decimal)
		<Column("UNITS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
		Public Property Units() As Nullable(Of Decimal)
		<Column("RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c4")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 4)>
		Public Property Rate() As Nullable(Of Decimal)
		<MaxLength(100)>
		<Column("NOTE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Note() As String
		<Required>
		<Column("COLOR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ColorPicker)>
		Public Property Color() As Integer
		<Required>
		<Column("ROW_INDEX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property RowIndex() As Integer
		<Column("IMPRESSIONS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
		Public Property Impressions() As Nullable(Of Decimal)
		<Column("CLICKS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
		Public Property Clicks() As Nullable(Of Decimal)
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<MaxLength(100)>
		<Column("USER_MODIFIED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<Column("AGENCY_FEE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property AgencyFee() As Nullable(Of Decimal)
		<Column("BILL_AMOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property BillAmount() As Nullable(Of Decimal)
        <Column("ORDER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <System.ComponentModel.DataAnnotations.ConcurrencyCheck()>
        Public Property OrderID() As Nullable(Of Integer)
		<Column("ORDER_LINE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <System.ComponentModel.DataAnnotations.ConcurrencyCheck()>
        Public Property OrderLineID() As Nullable(Of Integer)
		<Column("ORDER_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <System.ComponentModel.DataAnnotations.ConcurrencyCheck()>
        Public Property OrderNumber() As Nullable(Of Integer)
		<Column("ORDER_LINE_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <System.ComponentModel.DataAnnotations.ConcurrencyCheck()>
        Public Property OrderLineNumber() As Nullable(Of Integer)
		<Required>
		<Column("SUNDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Sunday() As Boolean
		<Required>
		<Column("MONDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Monday() As Boolean
		<Required>
		<Column("TUESDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Tuesday() As Boolean
		<Required>
		<Column("WEDNESDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Wednesday() As Boolean
		<Required>
		<Column("THURSDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Thursday() As Boolean
		<Required>
		<Column("FRIDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Friday() As Boolean
		<Required>
		<Column("SATURDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Saturday() As Boolean
		<Required>
		<Column("HAS_PENDING_ORDERS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HasPendingOrders() As Boolean
		<Column("END_DATE")>
		<System.ComponentModel.DisplayName("End Date")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d", CustomColumnCaption:="End Date")>
        Public Property EndDate() As Date
        <Column("NET_CHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property NetCharge() As Nullable(Of Decimal)
        <Column("COLUMNS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property Columns() As Nullable(Of Decimal)
        <Column("INCHES_LINES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property InchesLines() As Nullable(Of Decimal)
        <Required>
        <Column("IS_ACTUALIZED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActualized() As Boolean
        <NotMapped>
		Public Property OrderLineChanged As Boolean

		Public Overridable Property MediaPlan As Database.Entities.MediaPlan
        Public Overridable Property MediaPlanDetail As Database.Entities.MediaPlanDetail

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
