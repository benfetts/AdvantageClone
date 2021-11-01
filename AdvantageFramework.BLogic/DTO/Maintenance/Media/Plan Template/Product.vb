Namespace DTO.Maintenance.Media.PlanTemplate

    Public Class Product
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            MediaPlanTemplateHeaderID
            TemplateDescription
            IsDefault
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DivisionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DivisionName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ProductCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ProductName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MediaPlanTemplateHeaderID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Description")>
        Public Property TemplateDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsDefault() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.DivisionCode = String.Empty
            Me.DivisionName = String.Empty
            Me.ProductCode = String.Empty
            Me.ProductName = String.Empty
            Me.MediaPlanTemplateHeaderID = 0
            Me.TemplateDescription = String.Empty
            Me.IsDefault = False

        End Sub
        Public Sub New(MediaPlanTemplateProduct As AdvantageFramework.Database.Entities.MediaPlanTemplateProduct)

            Me.ID = MediaPlanTemplateProduct.ID
            Me.ClientCode = MediaPlanTemplateProduct.ClientCode
            Me.ClientName = MediaPlanTemplateProduct.Product.Client.Name
            Me.DivisionCode = MediaPlanTemplateProduct.DivisionCode
            Me.DivisionName = MediaPlanTemplateProduct.Product.Division.Name
            Me.ProductCode = MediaPlanTemplateProduct.ProductCode
            Me.ProductName = MediaPlanTemplateProduct.Product.Name
            Me.MediaPlanTemplateHeaderID = MediaPlanTemplateProduct.MediaPlanTemplateHeaderID
            Me.TemplateDescription = MediaPlanTemplateProduct.MediaPlanTemplateHeader.Description
            Me.IsDefault = MediaPlanTemplateProduct.IsDefault

        End Sub
        Public Sub SaveToEntity(MediaPlanTemplateProduct As AdvantageFramework.Database.Entities.MediaPlanTemplateProduct)

            MediaPlanTemplateProduct.ClientCode = Me.ClientCode
            MediaPlanTemplateProduct.DivisionCode = Me.DivisionCode
            MediaPlanTemplateProduct.ProductCode = Me.ProductCode
            MediaPlanTemplateProduct.MediaPlanTemplateHeaderID = Me.MediaPlanTemplateHeaderID
            MediaPlanTemplateProduct.IsDefault = Me.IsDefault

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
