Namespace Database.Entities

    <Table("MEDIA_SPOT_TV_RESEARCH")>
    Public Class MediaSpotTVResearch
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            CriteriaName
            MarketCode
            ReportType
            DominantProgramming
            ShowProgramName
            ShowSpill
            MaxRank
            RatingsServiceID
            GroupByDaysTimes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_TV_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("USER_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property UserCode() As String
        <Required>
        <MaxLength(30)>
        <Column("CRITERIA_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CriteriaName() As String
        <MaxLength(10)>
        <Column("MARKET_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MarketCode() As String
        <Required>
        <Column("REPORT_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ReportType() As Short
        <Required>
        <Column("DOMINANT_PROGRAMMING")>
        Public Property DominantProgramming() As Boolean
        <Required>
        <Column("SHOW_PROGRAM_NAME")>
        Public Property ShowProgramName() As Boolean
        <Required>
        <Column("SHOW_SPILL")>
        Public Property ShowSpill() As Boolean
        <Column("MAX_RANK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(MinValue:=1, UseMinValue:=True, MaxValue:=32767, UseMaxValue:=True)>
        Public Property MaxRank() As Nullable(Of Short)
        <Required>
        <Column("RATINGS_SERVICE_ID")>
        Public Property RatingsServiceID() As Integer
        <Required>
        <Column("GROUP_BY_DAYS_TIMES")>
        Public Property GroupByDaysTimes() As Boolean

        <ForeignKey("MarketCode")>
        Public Overridable Property Market As Database.Entities.Market

        Public Overridable Property MediaSpotTVResearchBooks As ICollection(Of Database.Entities.MediaSpotTVResearchBook)
        Public Overridable Property MediaSpotTVResearchDayTimes As ICollection(Of Database.Entities.MediaSpotTVResearchDayTime)
        Public Overridable Property MediaSpotTVResearchDemos As ICollection(Of Database.Entities.MediaSpotTVResearchDemo)
        Public Overridable Property MediaSpotTVResearchMetrics As ICollection(Of Database.Entities.MediaSpotTVResearchMetric)
        Public Overridable Property MediaSpotTVResearchStations As ICollection(Of Database.Entities.MediaSpotTVResearchStation)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            SetRequired(AdvantageFramework.Database.Entities.MediaSpotTVResearch.Properties.MarketCode.ToString, Not Me.IsEntityBeingAdded)

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.MediaSpotTVResearch.Properties.CriteriaName.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded AndAlso (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearch.LoadByUserCode(DbContext, Me.UserCode)
                                                      Where Entity.CriteriaName.ToUpper = DirectCast(PropertyValue, String).Trim.ToUpper).Any Then

                        IsValid = False

                        ErrorText = "A report with this name exists."

                    ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearch.LoadByUserCode(DbContext, Me.UserCode)
                            Where Entity.CriteriaName.ToUpper = DirectCast(PropertyValue, String).Trim.ToUpper AndAlso
                                  Entity.ID <> Me.ID).Any Then

                        IsValid = False

                        ErrorText = "A report with this name exists."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
