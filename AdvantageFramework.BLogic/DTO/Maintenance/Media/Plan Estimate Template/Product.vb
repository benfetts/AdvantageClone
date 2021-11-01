Namespace DTO.Maintenance.Media.PlanEstimateTemplate

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
            MediaPlanEstimateTemplateID
            MediaType
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
        Public Property MediaPlanEstimateTemplateID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaType() As String
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
            Me.MediaPlanEstimateTemplateID = 0
            Me.MediaType = String.Empty
            Me.TemplateDescription = String.Empty
            Me.IsDefault = False

        End Sub
        Public Sub New(MediaPlanEstimateTemplateProduct As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateProduct)

            Me.ID = MediaPlanEstimateTemplateProduct.ID
            Me.ClientCode = MediaPlanEstimateTemplateProduct.ClientCode
            Me.ClientName = MediaPlanEstimateTemplateProduct.Product.Client.Name
            Me.DivisionCode = MediaPlanEstimateTemplateProduct.DivisionCode
            Me.DivisionName = MediaPlanEstimateTemplateProduct.Product.Division.Name
            Me.ProductCode = MediaPlanEstimateTemplateProduct.ProductCode
            Me.ProductName = MediaPlanEstimateTemplateProduct.Product.Name
            Me.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateProduct.MediaPlanEstimateTemplateID

            Select Case MediaPlanEstimateTemplateProduct.MediaPlanEstimateTemplate.Type
                Case "I"
                    Me.MediaType = "Internet"
                Case "M"
                    Me.MediaType = "Magazine"
                Case "N"
                    Me.MediaType = "Newspaper"
                Case "O"
                    Me.MediaType = "Out of Home"
                Case "R"
                    Me.MediaType = "Radio"
                Case "T"
                    Me.MediaType = "Television"
            End Select

            Me.TemplateDescription = MediaPlanEstimateTemplateProduct.MediaPlanEstimateTemplate.Description
            Me.IsDefault = MediaPlanEstimateTemplateProduct.IsDefault

        End Sub
        Public Sub SaveToEntity(MediaPlanEstimateTemplateProduct As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateProduct)

            MediaPlanEstimateTemplateProduct.ClientCode = Me.ClientCode
            MediaPlanEstimateTemplateProduct.DivisionCode = Me.DivisionCode
            MediaPlanEstimateTemplateProduct.ProductCode = Me.ProductCode
            MediaPlanEstimateTemplateProduct.MediaPlanEstimateTemplateID = Me.MediaPlanEstimateTemplateID
            MediaPlanEstimateTemplateProduct.IsDefault = Me.IsDefault

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
