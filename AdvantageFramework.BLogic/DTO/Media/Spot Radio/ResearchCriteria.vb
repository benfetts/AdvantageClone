Namespace DTO.Media.SpotRadio

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
            MediaDemoID
            NielsenRadioQualitativeID
            ReportType
            Geography
            ListeningType
            Ethnicity
            IncludeTotalListening
            ShowFormat
            ShowFrequency
            ShowSpill
            NielsenRadioMarketNumber
            Source
            MaxRank
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
        Public Property MarketCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsRequired:=True)>
        Public Property MediaDemoID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property NielsenRadioQualitativeID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ReportType() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Geography() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ListeningType() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Ethnicity() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IncludeTotalListening() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowFormat() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowFrequency() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowSpill() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property NielsenRadioMarketNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DisplayByValue() As DisplayBy
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Source() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MaxRank() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = Nothing
            Me.CriteriaName = Nothing

        End Sub
        Public Sub New(MediaSpotRadioResearch As AdvantageFramework.Database.Entities.MediaSpotRadioResearch)

            Me.ID = MediaSpotRadioResearch.ID
            Me.UserCode = MediaSpotRadioResearch.UserCode
            Me.CriteriaName = MediaSpotRadioResearch.CriteriaName
            Me.MarketCode = MediaSpotRadioResearch.MarketCode
            Me.MediaDemoID = MediaSpotRadioResearch.MediaDemoID
            Me.NielsenRadioQualitativeID = MediaSpotRadioResearch.NielsenRadioQualitativeID
            Me.ReportType = MediaSpotRadioResearch.OutputType
            Me.Geography = MediaSpotRadioResearch.Geography
            Me.ListeningType = MediaSpotRadioResearch.ListeningType
            Me.Ethnicity = MediaSpotRadioResearch.Ethnicity
            Me.IncludeTotalListening = MediaSpotRadioResearch.IncludeTotalListening
            Me.ShowSpill = MediaSpotRadioResearch.ShowSpill
            Me.ShowFormat = MediaSpotRadioResearch.ShowFormat
            Me.ShowFrequency = MediaSpotRadioResearch.ShowFrequency
            Me.Source = MediaSpotRadioResearch.Source
            Me.MaxRank = MediaSpotRadioResearch.MaxRank

            SetNielsenRadioMarketNumber(MediaSpotRadioResearch.Market)

        End Sub
        Public Sub SetNielsenRadioMarketNumber(Market As AdvantageFramework.Database.Entities.Market)

            If Market IsNot Nothing Then

                If Me.Ethnicity = AdvantageFramework.Database.Entities.SpotRadioResearchEthnicity.All Then

                    If Me.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen AndAlso IsNumeric(Market.NielsenRadioCode) Then

                        Me.NielsenRadioMarketNumber = CInt(Market.NielsenRadioCode)

                    ElseIf Me.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan AndAlso IsNumeric(Market.EastlanRadioCode) Then

                        Me.NielsenRadioMarketNumber = CInt(Market.EastlanRadioCode)

                    End If

                ElseIf Me.Ethnicity = AdvantageFramework.Database.Entities.SpotRadioResearchEthnicity.Black Then

                    If Me.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen AndAlso IsNumeric(Market.NielsenBlackRadioCode) Then

                        Me.NielsenRadioMarketNumber = CInt(Market.NielsenBlackRadioCode)

                    ElseIf Me.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan AndAlso IsNumeric(Market.EastlanBlackRadioCode) Then

                        Me.NielsenRadioMarketNumber = CInt(Market.EastlanBlackRadioCode)

                    End If

                ElseIf Me.Ethnicity = AdvantageFramework.Database.Entities.SpotRadioResearchEthnicity.Hispanic Then

                    If Me.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen AndAlso IsNumeric(Market.NielsenHispanicRadioCode) Then

                        Me.NielsenRadioMarketNumber = CInt(Market.NielsenHispanicRadioCode)

                    ElseIf Me.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan AndAlso IsNumeric(Market.EastlanHispanicRadioCode) Then

                        Me.NielsenRadioMarketNumber = CInt(Market.EastlanHispanicRadioCode)

                    End If

                End If

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotRadioResearch As AdvantageFramework.Database.Entities.MediaSpotRadioResearch)

            MediaSpotRadioResearch.ID = Me.ID
            MediaSpotRadioResearch.UserCode = Me.UserCode
            MediaSpotRadioResearch.CriteriaName = Me.CriteriaName
            MediaSpotRadioResearch.MarketCode = Me.MarketCode
            MediaSpotRadioResearch.MediaDemoID = Me.MediaDemoID
            MediaSpotRadioResearch.NielsenRadioQualitativeID = Me.NielsenRadioQualitativeID
            MediaSpotRadioResearch.OutputType = Me.ReportType
            MediaSpotRadioResearch.Geography = Me.Geography
            MediaSpotRadioResearch.ListeningType = Me.ListeningType
            MediaSpotRadioResearch.Ethnicity = Me.Ethnicity
            MediaSpotRadioResearch.IncludeTotalListening = Me.IncludeTotalListening
            MediaSpotRadioResearch.ShowSpill = Me.ShowSpill
            MediaSpotRadioResearch.ShowFormat = Me.ShowFormat
            MediaSpotRadioResearch.ShowFrequency = Me.ShowFrequency
            MediaSpotRadioResearch.Source = Me.Source
            MediaSpotRadioResearch.MaxRank = Me.MaxRank

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
