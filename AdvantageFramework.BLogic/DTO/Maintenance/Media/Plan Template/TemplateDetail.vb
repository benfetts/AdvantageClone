Namespace DTO.Maintenance.Media.PlanTemplate

    Public Class TemplateDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanTemplateHeaderID
            MediaPlanEstimateTemplateID
            MediaType
            MediaTypeDescription
            Percentage
            SalesClassCode
            PeriodType
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MediaPlanTemplateHeaderID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.MediaPlanEstimateTemplate, CustomColumnCaption:="Estimate Template")>
        Public Property MediaPlanEstimateTemplateID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Media Type")>
        Public Property MediaTypeDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Percentage() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.SalesClassCode)>
        Public Property SalesClassCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.MediaPlanEstimateTemplateMediaType)>
        Public Property PeriodType() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.MediaPlanTemplateHeaderID = 0
            Me.MediaPlanEstimateTemplateID = Nothing
            Me.Percentage = 0
            Me.MediaType = String.Empty
            Me.MediaTypeDescription = String.Empty
            Me.SalesClassCode = Nothing
            Me.PeriodType = Nothing

        End Sub
        Public Sub New(MediaPlanTemplateDetail As AdvantageFramework.Database.Entities.MediaPlanTemplateDetail)

            Me.ID = MediaPlanTemplateDetail.ID
            Me.MediaPlanTemplateHeaderID = MediaPlanTemplateDetail.MediaPlanTemplateHeaderID
            Me.MediaPlanEstimateTemplateID = MediaPlanTemplateDetail.MediaPlanEstimateTemplateID
            Me.Percentage = MediaPlanTemplateDetail.Percentage
            Me.MediaType = MediaPlanTemplateDetail.MediaPlanEstimateTemplate.Type

            Select Case Me.MediaType
                Case "I"
                    Me.MediaTypeDescription = "Internet"
                Case "M"
                    Me.MediaTypeDescription = "Magazine"
                Case "N"
                    Me.MediaTypeDescription = "Newspaper"
                Case "O"
                    Me.MediaTypeDescription = "Out of Home"
                Case "R"
                    Me.MediaTypeDescription = "Radio"
                Case "T"
                    Me.MediaTypeDescription = "Television"
            End Select

            Me.SalesClassCode = MediaPlanTemplateDetail.SalesClassCode
            Me.PeriodType = MediaPlanTemplateDetail.PeriodType

        End Sub
        Public Sub SaveToEntity(MediaPlanTemplateDetail As AdvantageFramework.Database.Entities.MediaPlanTemplateDetail)

            MediaPlanTemplateDetail.MediaPlanTemplateHeaderID = Me.MediaPlanTemplateHeaderID
            MediaPlanTemplateDetail.MediaPlanEstimateTemplateID = Me.MediaPlanEstimateTemplateID
            MediaPlanTemplateDetail.Percentage = Me.Percentage
            MediaPlanTemplateDetail.SalesClassCode = Me.SalesClassCode
            MediaPlanTemplateDetail.PeriodType = Me.PeriodType

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
