Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("MEDIA_MGR_GENERATED_REPORT")>
    Public Class MediaManagerGeneratedReport
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OrderNumber
            MediaFrom
            CreatedByUserCode
            CreatedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.Column("MEDIA_MGR_GENERATED_REPORT_ID"),
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("ORDER_NBR"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property OrderNumber() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("MEDIA_FROM"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaFrom() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("USER_CREATED"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.MaxLength(100),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CreatedByUserCode() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("CREATED_DATE", TypeName:="smalldatetime"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CreatedDate() As Date

        <System.ComponentModel.DataAnnotations.Schema.Column("LAST_GENERATED_DATE", TypeName:="smalldatetime"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property LastGeneratedDate() As Date

        <System.ComponentModel.DataAnnotations.Schema.Column("IS_QUOTE"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsQuote() As Boolean

        Public Property MediaManagerGeneratedReportDetails As ICollection(Of MediaManagerGeneratedReportDetail)
        Public Property MediaManagerGeneratedReportSentInfos As ICollection(Of MediaManagerGeneratedReportSentInfo)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
