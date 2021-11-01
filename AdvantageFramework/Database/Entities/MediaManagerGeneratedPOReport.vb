Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("MEDIA_MGR_GENERATED_PO_REPORT")>
    Public Class MediaManagerGeneratedPOReport
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            PONumber
            PORevision
            VendorContactCode
            Email
            CreatedByUserCode
            CreatedDate
            LastGeneratedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.Column("MEDIA_MGR_GENERATED_PO_REPORT_ID"),
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("PO_NUMBER"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PONumber() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("PO_REVISION"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PORevision() As Nullable(Of Short)

        <System.ComponentModel.DataAnnotations.Schema.Column("VC_CODE"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property VendorContactCode() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("EMAIL"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Email() As String

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

        <ForeignKey("PONumber")>
        Public Property PurchaseOrder As PurchaseOrder

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
