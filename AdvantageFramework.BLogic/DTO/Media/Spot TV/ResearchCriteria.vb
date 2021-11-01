Namespace DTO.Media.SpotTV

    Public Class ResearchCriteria
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            CriteriaName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer?
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Report Name")>
        Public Property CriteriaName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Created By User Code")>
        Public Property UserCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarketCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ReportType() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DominantProgramming() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowProgramName() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowSpill() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MaxRank() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarketNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property RatingsServiceID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarketDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property GroupByDaysTimes() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComscoreNewMarketNumber() As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = Nothing
            Me.CriteriaName = Nothing

        End Sub
        Public Sub New(MediaSpotTVResearch As AdvantageFramework.Database.Entities.MediaSpotTVResearch)

            Me.ID = MediaSpotTVResearch.ID
            Me.UserCode = MediaSpotTVResearch.UserCode
            Me.CriteriaName = MediaSpotTVResearch.CriteriaName
            Me.MarketCode = MediaSpotTVResearch.MarketCode
            Me.ReportType = MediaSpotTVResearch.ReportType
            Me.DominantProgramming = MediaSpotTVResearch.DominantProgramming
            Me.ShowProgramName = MediaSpotTVResearch.ShowProgramName
            Me.ShowSpill = MediaSpotTVResearch.ShowSpill
            Me.MaxRank = MediaSpotTVResearch.MaxRank
            Me.RatingsServiceID = MediaSpotTVResearch.RatingsServiceID
            Me.GroupByDaysTimes = MediaSpotTVResearch.GroupByDaysTimes

            If MediaSpotTVResearch.Market IsNot Nothing AndAlso Me.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen AndAlso IsNumeric(MediaSpotTVResearch.Market.NielsenTVCode) Then

                Me.MarketNumber = CInt(MediaSpotTVResearch.Market.NielsenTVCode)
                Me.MarketDescription = MediaSpotTVResearch.Market.Description

            ElseIf MediaSpotTVResearch.Market IsNot Nothing AndAlso Me.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore AndAlso IsNumeric(MediaSpotTVResearch.Market.ComscoreNewMarketNumber) Then

                Me.MarketNumber = CInt(MediaSpotTVResearch.Market.ComscoreMarketNumber)
                Me.MarketDescription = MediaSpotTVResearch.Market.Description
                Me.ComscoreNewMarketNumber = CInt(MediaSpotTVResearch.Market.ComscoreNewMarketNumber)

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotTVResearch As AdvantageFramework.Database.Entities.MediaSpotTVResearch)

            MediaSpotTVResearch.ID = Me.ID
            MediaSpotTVResearch.UserCode = Me.UserCode
            MediaSpotTVResearch.CriteriaName = Me.CriteriaName
            MediaSpotTVResearch.MarketCode = Me.MarketCode
            MediaSpotTVResearch.ReportType = Me.ReportType
            MediaSpotTVResearch.DominantProgramming = Me.DominantProgramming
            MediaSpotTVResearch.ShowProgramName = Me.ShowProgramName
            MediaSpotTVResearch.ShowSpill = Me.ShowSpill
            MediaSpotTVResearch.MaxRank = Me.MaxRank
            MediaSpotTVResearch.RatingsServiceID = Me.RatingsServiceID
            MediaSpotTVResearch.GroupByDaysTimes = Me.GroupByDaysTimes

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
