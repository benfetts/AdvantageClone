Namespace DTO.Media.SpotRadioCounty

    Public Class ResearchCriteria
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            CriteriaName
            MarketCode
            ReportType
            MediaDemoID
            MaxRank
            Ethnicity
            Daypart68
            Daypart84
            ShowFrequency
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
        Public Property CriteriaName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Created By User Code")>
        Public Property UserCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsRequired:=True)>
        Public Property CountyCode() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ReportType() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsRequired:=True)>
        Public Property MediaDemoID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MaxRank() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Ethnicity() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Daypart68() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Daypart84() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowFrequency() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property NielsenRadioMarketNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DisplayByValue() As DisplayBy

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = Nothing
            Me.CriteriaName = Nothing

        End Sub
        Public Sub New(MediaSpotRadioCountyResearch As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch)

            Me.ID = MediaSpotRadioCountyResearch.ID
            Me.UserCode = MediaSpotRadioCountyResearch.UserCode
            Me.CriteriaName = MediaSpotRadioCountyResearch.CriteriaName
            Me.CountyCode = MediaSpotRadioCountyResearch.CountyCode
            Me.ReportType = MediaSpotRadioCountyResearch.ReportType
            Me.MediaDemoID = MediaSpotRadioCountyResearch.MediaDemoID
            Me.MaxRank = MediaSpotRadioCountyResearch.MaxRank
            Me.Ethnicity = MediaSpotRadioCountyResearch.Ethnicity
            Me.Daypart68 = MediaSpotRadioCountyResearch.Daypart68
            Me.Daypart84 = MediaSpotRadioCountyResearch.Daypart84
            Me.ShowFrequency = MediaSpotRadioCountyResearch.ShowFrequency

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotRadioCountyResearch As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch)

            MediaSpotRadioCountyResearch.ID = Me.ID
            MediaSpotRadioCountyResearch.UserCode = Me.UserCode
            MediaSpotRadioCountyResearch.CriteriaName = Me.CriteriaName
            MediaSpotRadioCountyResearch.CountyCode = Me.CountyCode
            MediaSpotRadioCountyResearch.ReportType = Me.ReportType
            MediaSpotRadioCountyResearch.MediaDemoID = Me.MediaDemoID
            MediaSpotRadioCountyResearch.MaxRank = Me.MaxRank
            MediaSpotRadioCountyResearch.Ethnicity = Me.Ethnicity
            MediaSpotRadioCountyResearch.Daypart68 = Me.Daypart68
            MediaSpotRadioCountyResearch.Daypart84 = Me.Daypart84
            MediaSpotRadioCountyResearch.ShowFrequency = Me.ShowFrequency

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
