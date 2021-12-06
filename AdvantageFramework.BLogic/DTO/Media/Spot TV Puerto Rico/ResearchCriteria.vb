Namespace DTO.Media.SpotTVPuertoRico

    Public Class ResearchCriteria
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            CriteriaName
            UserCode
            ReportType
            MaxRank
            ShowProgramName
            GroupByDaysTimes
            SubtotalByWeekdayWeekend
            ShareStartDate
            ShareEndDate
            HPUTStartDate
            HPUTEndDate
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
        Public Property ReportType() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MaxRank() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowProgramName() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property GroupByDaysTimes() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SubtotalByWeekdayWeekend() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShareStartDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShareEndDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HPUTStartDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HPUTEndDate() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = Nothing
            Me.CriteriaName = Nothing

        End Sub
        Public Sub New(MediaSpotTVPuertoRicoResearch As AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearch)

            Me.ID = MediaSpotTVPuertoRicoResearch.ID
            Me.UserCode = MediaSpotTVPuertoRicoResearch.UserCode
            Me.CriteriaName = MediaSpotTVPuertoRicoResearch.CriteriaName
            Me.ReportType = MediaSpotTVPuertoRicoResearch.ReportType
            Me.MaxRank = MediaSpotTVPuertoRicoResearch.MaxRank
            Me.ShowProgramName = MediaSpotTVPuertoRicoResearch.ShowProgramName
            Me.GroupByDaysTimes = MediaSpotTVPuertoRicoResearch.GroupByDaysTimes
            Me.SubtotalByWeekdayWeekend = MediaSpotTVPuertoRicoResearch.SubtotalByWeekdayWeekend
            Me.ShareStartDate = MediaSpotTVPuertoRicoResearch.ShareStartDate
            Me.ShareEndDate = MediaSpotTVPuertoRicoResearch.ShareEndDate
            Me.HPUTStartDate = MediaSpotTVPuertoRicoResearch.HPUTStartDate
            Me.HPUTEndDate = MediaSpotTVPuertoRicoResearch.HPUTEndDate

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotTVPuertoRicoResearch As AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearch)

            MediaSpotTVPuertoRicoResearch.ID = Me.ID
            MediaSpotTVPuertoRicoResearch.UserCode = Me.UserCode
            MediaSpotTVPuertoRicoResearch.CriteriaName = Me.CriteriaName
            MediaSpotTVPuertoRicoResearch.ReportType = Me.ReportType
            MediaSpotTVPuertoRicoResearch.MaxRank = Me.MaxRank
            MediaSpotTVPuertoRicoResearch.ShowProgramName = Me.ShowProgramName
            MediaSpotTVPuertoRicoResearch.GroupByDaysTimes = Me.GroupByDaysTimes
            MediaSpotTVPuertoRicoResearch.SubtotalByWeekdayWeekend = Me.SubtotalByWeekdayWeekend
            MediaSpotTVPuertoRicoResearch.ShareStartDate = Me.ShareStartDate
            MediaSpotTVPuertoRicoResearch.ShareEndDate = Me.ShareEndDate
            MediaSpotTVPuertoRicoResearch.HPUTStartDate = Me.HPUTStartDate
            MediaSpotTVPuertoRicoResearch.HPUTEndDate = Me.HPUTEndDate

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
