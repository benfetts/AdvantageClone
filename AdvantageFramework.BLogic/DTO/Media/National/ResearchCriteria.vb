Namespace DTO.Media.National

    Public Class ResearchCriteria
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            CriteriaName
            ReportType

            Ethnicity
            TimeType
            DateType
            StartDate
            EndDate
            DaysAndTime

            BreakoutFlag
            SpecialsFlag
            OvernightsFlag
            RepeatsFlag
            PremieresFlag
            CorrectionsFlag
            Stream
            ShowProgramTypes
            ShowAirings
        End Enum

        Public Enum DisplayBy
            Age = 0
            Gender = 1
            AgeGender = 2
            GenderAge = 3
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer?
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Report Name")>
        <MaxLength(30)>
        Public Property CriteriaName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Created By User Code")>
        Public Property UserCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ReportType() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Ethnicity() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TimeType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DateType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property StartDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EndDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DaysAndTime() As AdvantageFramework.DTO.DaysAndTime

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BreakoutFlag() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SpecialsFlag() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OvernightsFlag() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property RepeatsFlag() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property PremieresFlag() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CorrectionsFlag() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Stream() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MaxRank As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowProgramTypes As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowAirings As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = Nothing
            Me.UserCode = Nothing
            Me.CriteriaName = Nothing
            Me.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramRanker

            Me.Ethnicity = AdvantageFramework.Database.Entities.NationalResearchReportEthnicity.G.ToString
            Me.TimeType = AdvantageFramework.Database.Entities.NationalResearchReportTimeType.P.ToString
            Me.DateType = AdvantageFramework.Database.Entities.NationalResearchReportDateType.D.ToString
            Me.StartDate = Nothing
            Me.EndDate = Nothing

            Me.DaysAndTime = New DTO.DaysAndTime

            Me.BreakoutFlag = AdvantageFramework.Database.Entities.NationalResearchReportFlags.I.ToString
            Me.SpecialsFlag = AdvantageFramework.Database.Entities.NationalResearchReportFlags.I.ToString
            Me.OvernightsFlag = AdvantageFramework.Database.Entities.NationalResearchReportFlags.I.ToString
            Me.RepeatsFlag = AdvantageFramework.Database.Entities.NationalResearchReportFlags.I.ToString
            Me.PremieresFlag = AdvantageFramework.Database.Entities.NationalResearchReportFlags.I.ToString
            Me.CorrectionsFlag = AdvantageFramework.Database.Entities.NationalResearchReportFlags.I.ToString
            Me.Stream = "LS"
            Me.ShowProgramTypes = False
            Me.ShowAirings = False

        End Sub
        Public Sub New(MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch)

            Me.ID = MediaSpotNationalResearch.ID
            Me.UserCode = MediaSpotNationalResearch.UserCode
            Me.CriteriaName = MediaSpotNationalResearch.CriteriaName
            Me.ReportType = MediaSpotNationalResearch.ReportType

            Me.Ethnicity = MediaSpotNationalResearch.Ethnicity
            Me.TimeType = MediaSpotNationalResearch.TimeType
            Me.DateType = MediaSpotNationalResearch.DateType
            Me.StartDate = MediaSpotNationalResearch.StartDate
            Me.EndDate = MediaSpotNationalResearch.EndDate

            Me.DaysAndTime = New DTO.DaysAndTime(DaysAndTime.BroadcastTypes.National, MediaSpotNationalResearch)

            Me.BreakoutFlag = MediaSpotNationalResearch.BreakoutFlag
            Me.SpecialsFlag = MediaSpotNationalResearch.SpecialsFlag
            Me.OvernightsFlag = MediaSpotNationalResearch.OvernightsFlag
            Me.RepeatsFlag = MediaSpotNationalResearch.RepeatsFlag
            Me.PremieresFlag = MediaSpotNationalResearch.PremieresFlag
            Me.CorrectionsFlag = MediaSpotNationalResearch.CorrectionsFlag
            Me.Stream = MediaSpotNationalResearch.Stream
            Me.ShowProgramTypes = MediaSpotNationalResearch.ShowProgramTypes
            Me.ShowAirings = MediaSpotNationalResearch.ShowAirings

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch)

            MediaSpotNationalResearch.UserCode = Me.UserCode
            MediaSpotNationalResearch.CriteriaName = Me.CriteriaName
            MediaSpotNationalResearch.ReportType = Me.ReportType

            MediaSpotNationalResearch.Ethnicity = Me.Ethnicity
            MediaSpotNationalResearch.TimeType = Me.TimeType
            MediaSpotNationalResearch.DateType = Me.DateType
            MediaSpotNationalResearch.StartDate = Me.StartDate
            MediaSpotNationalResearch.EndDate = Me.EndDate

            Me.DaysAndTime.SaveToEntity(MediaSpotNationalResearch)

            MediaSpotNationalResearch.BreakoutFlag = Me.BreakoutFlag
            MediaSpotNationalResearch.SpecialsFlag = Me.SpecialsFlag
            MediaSpotNationalResearch.OvernightsFlag = Me.OvernightsFlag
            MediaSpotNationalResearch.RepeatsFlag = Me.RepeatsFlag
            MediaSpotNationalResearch.PremieresFlag = Me.PremieresFlag
            MediaSpotNationalResearch.CorrectionsFlag = Me.CorrectionsFlag
            MediaSpotNationalResearch.Stream = Me.Stream
            MediaSpotNationalResearch.ShowProgramTypes = Me.ShowProgramTypes
            MediaSpotNationalResearch.ShowAirings = Me.ShowAirings

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
