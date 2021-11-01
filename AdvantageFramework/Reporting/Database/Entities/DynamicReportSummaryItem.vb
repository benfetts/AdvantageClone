Namespace Reporting.Database.Entities

    <Table("DYNAMIC_REPORT_SUM")>
    Public Class DynamicReportSummaryItem
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            DynamicReportID
            SummaryItemType
            FieldName
            OnFooter
            DisplayFormat
            ColumnName
            DynamicReport

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("DYNAMIC_REPORT_SUM_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("DYNAMIC_REPORT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DynamicReportID() As Integer
        <Required>
        <Column("SUM_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SummaryItemType() As Integer
        <Required>
        <MaxLength(100)>
        <Column("FIELD_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FieldName() As String
        <Required>
        <Column("ON_FOOTER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OnFooter() As Boolean
        <Required>
        <MaxLength(1000)>
        <Column("DISPLAY_FORMAT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DisplayFormat() As String
        <Required>
        <MaxLength(100)>
        <Column("COLUMN_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ColumnName() As String

        Public Overridable Property DynamicReport() As Database.Entities.DynamicReport

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
