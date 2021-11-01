Namespace ViewModels.Maintenance.Media

    Public Class MediaPlanEstimateTemplateDataEntryViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property TemplateTypeName As String

        Public Property PlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate

        Public Property Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)

        Public Property PivotFields As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PivotField)

        Public Property IsSystemTemplate As Boolean

        Public Property DaypartsSetupByMarket As Boolean
        Public Property DaypartsSetup As Boolean
        Public Property ShowInternetRates As Boolean
        Public Property ShowPercents As Boolean
        Public Property IncludeMarket As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.TemplateTypeName = String.Empty

            Me.PlanEstimateTemplate = Nothing

            Me.Datas = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)

            Me.PivotFields = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PivotField)

            Me.IsSystemTemplate = False

            Me.DaypartsSetupByMarket = False
            Me.DaypartsSetup = False
            Me.ShowInternetRates = False
            Me.ShowPercents = False
            Me.IncludeMarket = False

        End Sub

#End Region

    End Class

End Namespace
