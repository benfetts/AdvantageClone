Namespace Database.Entities

    <Table("MEDIA_SPOT_RADIO_RESEARCH")>
    Public Class MediaSpotRadioResearch
        Inherits BaseClasses.Entity

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
            OutputType
            Geography
            ListeningType
            Ethnicity
            IncludeTotalListening
            ShowSpill
            ShowFormat
            ShowFrequency
            Source
            MaxRank
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_RADIO_RESEARCH_ID")>
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
        <Column("MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaDemoID() As Nullable(Of Integer)
        <Required>
        <Column("NIELSEN_RADIO_QUALITATIVE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property NielsenRadioQualitativeID() As Integer
        <Required>
        <Column("OUTPUT_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property OutputType() As Short
        <Required>
        <Column("GEOGRAPHY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Geography() As Short
        <Required>
        <Column("LISTENING_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ListeningType() As Short
        <Required>
        <Column("ETHNICITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Ethnicity() As Short
        <Required>
        <Column("INCLUDE_TOTAL_LISTENING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IncludeTotalListening() As Boolean
        <Required>
        <Column("SHOW_SPILL")>
        Public Property ShowSpill() As Boolean
        <Required>
        <Column("SHOW_FORMAT")>
        Public Property ShowFormat() As Boolean
        <Required>
        <Column("SHOW_FREQUENCY")>
        Public Property ShowFrequency() As Boolean
        <Required>
        <Column("SOURCE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Source() As AdvantageFramework.Nielsen.Database.Entities.RadioSource
        <Column("MAX_RANK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(MinValue:=1, UseMinValue:=True, MaxValue:=32767, UseMaxValue:=True)>
        Public Property MaxRank() As Nullable(Of Short)

        <ForeignKey("MarketCode")>
        Public Overridable Property Market As Database.Entities.Market

        Public Overridable Property MediaSpotRadioResearchBooks As ICollection(Of Database.Entities.MediaSpotRadioResearchBook)
        Public Overridable Property MediaSpotRadioResearchDayparts As ICollection(Of Database.Entities.MediaSpotRadioResearchDaypart)
        Public Overridable Property MediaSpotRadioResearchMetrics As ICollection(Of Database.Entities.MediaSpotRadioResearchMetric)
        Public Overridable Property MediaSpotRadioResearchStations As ICollection(Of Database.Entities.MediaSpotRadioResearchStation)

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

            SetRequired(AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.MarketCode.ToString, Not Me.IsEntityBeingAdded)
            SetRequired(AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.MediaDemoID.ToString, Not Me.IsEntityBeingAdded)

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.CriteriaName.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded AndAlso (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.LoadByUserCode(DbContext, Me.UserCode)
                                                      Where Entity.CriteriaName.ToUpper = DirectCast(PropertyValue, String).Trim.ToUpper).Any Then

                        IsValid = False

                        ErrorText = "A report with this name exists."

                    ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.LoadByUserCode(DbContext, Me.UserCode)
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
