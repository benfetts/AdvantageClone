Namespace DTO.Media.DigitalCampaignManager

    Public Class OpenPlanEstimate
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientName
            EstimateCampaign
            MediaPlanDetailID
            MediaPlanID
            EstimateName
            EstimateBuyer
            PlanDescription
            PlanStartDate
            PlanEndDate
            PlanCampaign
            ClientCode
            DivisionCode
            DivisionName
            ProductCode
            ProductName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ClientName As String
        Public Property EstimateCampaign As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Estimate Number")>
        Public Property MediaPlanDetailID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Plan Number")>
        Public Property MediaPlanID As Integer
        Public Property EstimateName As String
        Public Property EstimateBuyer As String
        Public Property PlanDescription As String
        Public Property PlanStartDate As Date
        Public Property PlanEndDate As Date
        Public Property PlanCampaign As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ClientCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DivisionCode As String
        Public Property DivisionName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ProductCode As String
        Public Property ProductName As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.MediaPlanDetailID.ToString

        End Function

#End Region

    End Class

End Namespace
