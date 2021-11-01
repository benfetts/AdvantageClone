Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("MEDIA_MGR_GENERATED_REPORT_SENT_INFO")>
    Public Class MediaManagerGeneratedReportSentInfo
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaManagerGeneratedReportID
            VendorCode
            VendorRepresentativeCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.Column("MEDIA_MGR_GENERATED_REPORT_SENT_INFO_ID"),
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("MEDIA_MGR_GENERATED_REPORT_ID"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute("MediaManagerGeneratedReport"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaManagerGeneratedReportID() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("VN_CODE", TypeName:="varchar"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.MaxLength(6),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property VendorCode() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("VR_CODE", TypeName:="varchar"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.MaxLength(4),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property VendorRepresentativeCode() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("EMAIL", TypeName:="varchar"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Email() As String

        Public Property MediaManagerGeneratedReport As MediaManagerGeneratedReport

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
