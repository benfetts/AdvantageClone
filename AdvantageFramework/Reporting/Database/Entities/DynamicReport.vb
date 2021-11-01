Namespace Reporting.Database.Entities

    <Table("DYNAMIC_REPORT")>
    Public Class DynamicReport
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Type
            Description
            CreatedByUserCode
            CreatedDate
            AllowCellMerge
            AutoSizeColumnsWhenPrinting
            PrintHeader
            PrintFooter
            PrintGroupFooter
            PrintSelectedRowsOnly
            PrintFilterInformation
            ShowViewCaption
            ShowGroupByBox
            ShowAutoFilterRow
            UpdatedByUserCode
            UpdatedDate
            ActiveFilter
            UserDefinedReportCategoryID
            DashboardLayout
            TemplateCode
            DynamicReportSummaryItems
            DynamicReportColumns
            UserDefinedReportCategory
            DynamicReportUnboundColumns

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("DYNAMIC_REPORT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("DYNAMIC_REPORT_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Type() As Integer
        <Required>
        <MaxLength(50)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <Required>
        <MaxLength(100)>
        <Column("CREATED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
        <Required>
        <Column("CREATED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <Required>
        <Column("ALLOW_CELL_MERGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowCellMerge() As Boolean
        <Required>
        <Column("PRINT_AUTOSIZE_COL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AutoSizeColumnsWhenPrinting() As Boolean
        <Required>
        <Column("PRINT_HEADER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrintHeader() As Boolean
        <Required>
        <Column("PRINT_FOOTER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrintFooter() As Boolean
        <Required>
        <Column("PRINT_GROUP_FOOTER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrintGroupFooter() As Boolean
        <Required>
        <Column("PRINT_SEL_ROWS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrintSelectedRowsOnly() As Boolean
        <Required>
        <Column("PRINT_FILTER_INFO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrintFilterInformation() As Boolean
        <Required>
        <Column("SHOW_VIEW_CAPTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowViewCaption() As Boolean
        <Required>
        <Column("SHOW_GROUPBY_BOX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowGroupByBox() As Boolean
        <Required>
        <Column("SHOW_AUTOFILTER_ROW")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowAutoFilterRow() As Boolean
        <Required>
        <MaxLength(100)>
        <Column("UPDATED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UpdatedByUserCode() As String
        <Required>
        <Column("UPDATED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UpdatedDate() As Date
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(8000)>
        <Column("ACTIVE_FILTER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ActiveFilter() As String
        <Column("UDR_REPORT_CATEGORY_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserDefinedReportCategoryID() As Nullable(Of Integer)
        <Column("DASHBOARD_LAYOUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DashboardLayout() As Byte()
        <MaxLength(6)>
        <Column("JV_TMPLT_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TemplateCode() As String

        Public Overridable Property DynamicReportSummaryItems() As ICollection(Of Database.Entities.DynamicReportSummaryItem)
        Public Overridable Property DynamicReportColumns() As ICollection(Of Database.Entities.DynamicReportColumn)
        Public Overridable Property UserDefinedReportCategory() As Database.Entities.UserDefinedReportCategory
        Public Overridable Property DynamicReportUnboundColumns() As ICollection(Of Database.Entities.DynamicReportUnboundColumn)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
