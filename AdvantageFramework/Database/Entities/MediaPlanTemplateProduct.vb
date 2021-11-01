Namespace Database.Entities

    <Table("MEDIA_PLAN_TEMPLATE_PRODUCT")>
    Public Class MediaPlanTemplateProduct
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            DivisionCode
            ProductCode
            MediaPlanTemplateHeaderID
            IsDefault
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_TEMPLATE_PRODUCT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ClientCode() As String
        <Required>
        <MaxLength(6)>
        <Column("DIV_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DivisionCode() As String
        <Required>
        <MaxLength(6)>
        <Column("PRD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ProductCode() As String
        <Required>
        <Column("MEDIA_PLAN_TEMPLATE_HEADER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaPlanTemplateHeaderID() As Integer
        <Required>
        <Column("IS_DEFAULT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsDefault() As Boolean

        <NotMapped>
        Public ReadOnly Property CDP As String
            Get
                CDP = Me.ClientCode & "|" & Me.DivisionCode & "|" & Me.ProductCode
            End Get
        End Property

        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        <ForeignKey("MediaPlanTemplateHeaderID")>
        Public Overridable Property MediaPlanTemplateHeader As Database.Entities.MediaPlanTemplateHeader

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
