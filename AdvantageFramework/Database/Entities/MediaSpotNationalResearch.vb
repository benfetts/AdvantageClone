Namespace Database.Entities

    <Table("MEDIA_SPOT_NATIONAL_RESEARCH")>
    Public Class MediaSpotNationalResearch
        Inherits BaseClasses.Entity

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
            Days
            Sunday
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            StartTime
            EndTime
            StartHour
            EndHour
            BreakoutFlag
            SpecialsFlag
            OvernightsFlag
            RepeatsFlag
            PremieresFlag
            CorrectionsFlag
            Stream
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_NATIONAL_RESEARCH_ID")>
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
        <Required>
        <Column("REPORT_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ReportType() As Short
        <Required>
        <Column("ETHNICITY", TypeName:="char")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Ethnicity() As String
        <Required>
        <Column("TIME_TYPE", TypeName:="char")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property TimeType() As String
        <Required>
        <Column("DATE_TYPE", TypeName:="char")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DateType() As String
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property StartDate() As Nullable(Of Date)
        <Column("END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property EndDate() As Nullable(Of Date)
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <Column("DAYS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Days() As String
        <Required>
        <Column("SUNDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Sunday() As Boolean
        <Required>
        <Column("MONDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Monday() As Boolean
        <Required>
        <Column("TUESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Tuesday() As Boolean
        <Required>
        <Column("WEDNESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Wednesday() As Boolean
        <Required>
        <Column("THURSDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Thursday() As Boolean
        <Required>
        <Column("FRIDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Friday() As Boolean
        <Required>
        <Column("SATURDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Saturday() As Boolean
        <MaxLength(10)>
        <Column("START_TIME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartTime() As String
        <MaxLength(10)>
        <Column("END_TIME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndTime() As String
        <Column("START_HOUR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property StartHour() As Nullable(Of Short)
        <Column("END_HOUR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property EndHour() As Nullable(Of Short)
        <Required>
        <Column("BREAKOUT_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property BreakoutFlag As String
        <Required>
        <Column("SPECIALS_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SpecialsFlag As String
        <Required>
        <Column("OVERNIGHTS_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property OvernightsFlag As String
        <Required>
        <Column("REPEATS_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RepeatsFlag As String
        <Required>
        <Column("PREMIERES_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PremieresFlag As String
        <Required>
        <Column("CORRECTIONS_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CorrectionsFlag As String
        <Required>
        <Column("STREAM", TypeName:="char")>
        <MaxLength(2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Stream() As String
        <Required>
        <Column("SHOW_PROGRAM_TYPES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ShowProgramTypes() As Boolean
        <Required>
        <Column("SHOW_AIRINGS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ShowAirings() As Boolean

        Public Overridable Property MediaSpotNationalResearchMediaDemos As ICollection(Of Database.Entities.MediaSpotNationalResearchMediaDemo)
        Public Overridable Property MediaSpotNationalResearchMetrics As ICollection(Of Database.Entities.MediaSpotNationalResearchMetric)
        Public Overridable Property MediaSpotNationalResearchNetworks As ICollection(Of Database.Entities.MediaSpotNationalResearchNetwork)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.MediaSpotNationalResearch.Properties.CriteriaName.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded AndAlso (From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.LoadByUserCode(DbContext, Me.UserCode)
                                                      Where Entity.CriteriaName.ToUpper = DirectCast(PropertyValue, String).Trim.ToUpper).Any Then

                        IsValid = False

                        ErrorText = "A report with this name exists."

                    ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.LoadByUserCode(DbContext, Me.UserCode)
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
