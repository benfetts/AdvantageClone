Namespace Database.Entities

    <Table("MEDIA_SPOT_RADIO_COUNTY_RESEARCH")>
    Public Class MediaSpotRadioCountyResearch
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            CriteriaName
            CountyCode
            ReportType
            MediaDemoID
            MaxRank
            Ethnicity
            Daypart68
            Daypart84
            ShowFrequency
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_RADIO_COUNTY_RESEARCH_ID")>
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
        <Column("COUNTY_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CountyCode() As Nullable(Of Integer)
        <Required>
        <Column("REPORT_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ReportType() As Short
        <Column("MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaDemoID() As Nullable(Of Integer)
        <Column("MAX_RANK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(MinValue:=1, UseMinValue:=True, MaxValue:=32767, UseMaxValue:=True)>
        Public Property MaxRank() As Nullable(Of Short)
        <Required>
        <Column("ETHNICITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Ethnicity() As Short
        <Required>
        <Column("DAYPART68")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Daypart68() As Boolean
        <Required>
        <Column("DAYPART84")>
        Public Property Daypart84() As Boolean
        <Required>
        <Column("SHOW_FREQUENCY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ShowFrequency() As Boolean

        Public Overridable Property MediaSpotRadioCountyResearchMetrics As ICollection(Of Database.Entities.MediaSpotRadioCountyResearchMetric)
        Public Overridable Property MediaSpotRadioCountyResearchStations As ICollection(Of Database.Entities.MediaSpotRadioCountyResearchStation)
        Public Overridable Property MediaSpotRadioCountyResearchYears As ICollection(Of Database.Entities.MediaSpotRadioCountyResearchYear)

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

            SetRequired(AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch.Properties.CountyCode.ToString, Not Me.IsEntityBeingAdded)
            SetRequired(AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch.Properties.MediaDemoID.ToString, Not Me.IsEntityBeingAdded)

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch.Properties.CriteriaName.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded AndAlso (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.LoadByUserCode(DbContext, Me.UserCode)
                                                      Where Entity.CriteriaName.ToUpper = DirectCast(PropertyValue, String).Trim.ToUpper).Any Then

                        IsValid = False

                        ErrorText = "A report with this name exists."

                    ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.LoadByUserCode(DbContext, Me.UserCode)
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
