Namespace Reporting.Database.Entities

    <Table("DYNAMIC_REPORT_UB_COL")>
    Public Class DynamicReportUnboundColumn
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            DynamicReportID
            FieldName
            HeaderText
            IsVisible
            SortOrder
            SortIndex
            GroupIndex
            Width
            VisibleIndex
            UnboundType
            Expression
            Format
            DynamicReport

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("DYNAMIC_REPORT_UB_COL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("DYNAMIC_REPORT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DynamicReportID() As Integer
        <Required>
        <MaxLength(50)>
        <Column("FIELD_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FieldName() As String
        <Required>
        <MaxLength(50)>
        <Column("HEADER_TEXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HeaderText() As String
        <Required>
        <Column("IS_VISIBLE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsVisible() As Boolean
        <Required>
        <Column("SORT_ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortOrder() As Integer
        <Required>
        <Column("SORT_INDEX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortIndex() As Integer
        <Required>
        <Column("GROUP_INDEX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupIndex() As Integer
        <Required>
        <Column("WIDTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Width() As Integer
        <Required>
        <Column("VISIBLE_INDEX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VisibleIndex() As Integer
        <Required>
        <Column("UB_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UnboundType() As Integer
        <Required>
        <MaxLength(2000)>
        <Column("EXPRESSION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Expression() As String
        <MaxLength(20)>
        <Column("FORMAT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Format() As String

        Public Overridable Property DynamicReport() As Database.Entities.DynamicReport

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
