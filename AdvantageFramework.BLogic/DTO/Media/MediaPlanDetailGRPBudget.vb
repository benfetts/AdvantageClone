Namespace DTO.Media

    Public Class MediaPlanDetailGRPBudget
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanDetailID
            MarketCode
            MarketDescription
            SpotLength
            EntryDate
            GRPBudget
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MarketCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SpotLength() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EntryDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", CustomColumnCaption:="GRP's")>
        Public Property GRPBudget() As Decimal

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(MediaPlanDetailGRPBudget As AdvantageFramework.Database.Entities.MediaPlanDetailGRPBudget)

            Me.ID = MediaPlanDetailGRPBudget.ID
            Me.MediaPlanDetailID = MediaPlanDetailGRPBudget.MediaPlanDetailID
            Me.MarketCode = MediaPlanDetailGRPBudget.MarketCode
            Me.SpotLength = MediaPlanDetailGRPBudget.SpotLength
            Me.EntryDate = MediaPlanDetailGRPBudget.EntryDate
            Me.GRPBudget = MediaPlanDetailGRPBudget.GRPBudget

        End Sub
        Public Sub SaveToEntity(MediaPlanDetailGRPBudget As AdvantageFramework.Database.Entities.MediaPlanDetailGRPBudget)

            MediaPlanDetailGRPBudget.ID = Me.ID
            MediaPlanDetailGRPBudget.MediaPlanDetailID = Me.MediaPlanDetailID
            MediaPlanDetailGRPBudget.MarketCode = Me.MarketCode
            MediaPlanDetailGRPBudget.SpotLength = Me.SpotLength
            MediaPlanDetailGRPBudget.EntryDate = Me.EntryDate
            MediaPlanDetailGRPBudget.GRPBudget = Me.GRPBudget

        End Sub

#End Region

    End Class

End Namespace
