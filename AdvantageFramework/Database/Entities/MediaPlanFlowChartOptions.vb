Namespace Database.Entities

    <Table("MEDIA_PLAN_FLOW_CHART_OPTIONS")>
    Public Class MediaPlanFlowChartOptions
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            LocationID
            DateHeaderOption
            DateHeaderColor
            PrintYear
            PrintQuarter
            PrintMonth
            PrintMonthName
            PrintWeek
            PrintDate
            PrintDay
            WeekDisplayType
            DateOverrideOption
            FieldAreaColor
            PrintEstimateColumnTotals
            EstimateColumnTotalsType
            EstimateColumnTotalsAreaColor
            PrintGrandTotals
            GrandTotalsType
            GrandTotalsAreaColor
            GrandTotalsDisplayValue
            SummaryOption
            ImageID
            RoundToNearestDollar
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_FLOW_CHART_OPTIONS_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("USER_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
        <MaxLength(100)>
        <Column("LOCATION_ID", TypeName:="varchar")>
        Public Property LocationID() As String
        <Required>
        <Column("DATE_HEADER_OPTION")>
        Public Property DateHeaderOption() As Integer
        <Required>
        <Column("DATE_HEADER_COLOR")>
        Public Property DateHeaderColor() As Integer
        <Required>
        <Column("PRINT_YEAR")>
        Public Property PrintYear() As Boolean
        <Required>
        <Column("PRINT_QUARTER")>
        Public Property PrintQuarter() As Boolean
        <Required>
        <Column("PRINT_MONTH")>
        Public Property PrintMonth() As Boolean
        <Required>
        <Column("PRINT_MONTH_NAME")>
        Public Property PrintMonthName() As Boolean
        <Required>
        <Column("PRINT_WEEK")>
        Public Property PrintWeek() As Boolean
        <Required>
        <Column("PRINT_DATE")>
        Public Property PrintDate() As Boolean
        <Required>
        <Column("PRINT_DAY")>
        Public Property PrintDay() As Boolean
        <Required>
        <Column("WEEK_DISPLAY_TYPE")>
        Public Property WeekDisplayType() As Integer
        <Required>
        <Column("DATE_OVERRIDE_OPTION")>
        Public Property DateOverrideOption() As Integer
        <Required>
        <Column("FIELD_AREA_COLOR")>
        Public Property FieldAreaColor() As Integer
        <Required>
        <Column("PRINT_ESTIMATE_COLUMN_TOTALS")>
        Public Property PrintEstimateColumnTotals As Boolean
        <Required>
        <Column("ESTIMATE_COLUMN_TOTALS_TYPE")>
        Public Property EstimateColumnTotalsType As Integer
        <Required>
        <Column("ESTIMATE_COLUMN_TOTALS_AREA_COLOR")>
        Public Property EstimateColumnTotalsAreaColor As Integer
        <Required>
        <Column("PRINT_GRAND_TOTALS")>
        Public Property PrintGrandTotals() As Boolean
        <Required>
        <Column("GRAND_TOTALS_TYPE")>
        Public Property GrandTotalsType As Integer
        <Required>
        <Column("GRAND_TOTALS_AREA_COLOR")>
        Public Property GrandTotalsAreaColor() As Integer
        <Required>
        <Column("GRAND_TOTALS_DISPLAY_VALUE")>
        Public Property GrandTotalsDisplayValue() As Integer
        <Required>
        <Column("SUMMARY_OPTION")>
        Public Property SummaryOption() As Integer
        <Column("IMAGE_ID")>
        Public Property ImageID() As System.Nullable(Of Integer)
        <Required>
        <Column("ROUND_TO_NEAREST_DOLLAR")>
        Public Property RoundToNearestDollar() As Boolean

        Public Overridable Property Image As Database.Entities.Image

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.UserCode

        End Function

#End Region

    End Class

End Namespace
