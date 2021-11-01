Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("MEDIA_MGR_GENERATED_REPORT_DETAIL")>
    Public Class MediaManagerGeneratedReportDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaManagerGeneratedReportID
            LineNumber
            RevisionNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.Column("MEDIA_MGR_GENERATED_REPORT_DETAIL_ID"),
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("MEDIA_MGR_GENERATED_REPORT_ID"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute("MediaManagerGeneratedReport"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaManagerGeneratedReportID() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("LINE_NBR"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property LineNumber() As Short

        <System.ComponentModel.DataAnnotations.Schema.Column("REV_NBR"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevisionNumber() As Short

        <System.ComponentModel.DataAnnotations.Schema.Column("IS_CANCELLED"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsCancelled() As Boolean

        Public Property MediaManagerGeneratedReport As MediaManagerGeneratedReport

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
