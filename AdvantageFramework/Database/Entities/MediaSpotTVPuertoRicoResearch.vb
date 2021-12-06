Namespace Database.Entities

    <Table("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH")>
    Public Class MediaSpotTVPuertoRicoResearch
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            CriteriaName
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

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID")>
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
        <Column("MAX_RANK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(MinValue:=1, UseMinValue:=True, MaxValue:=32767, UseMaxValue:=True)>
        Public Property MaxRank() As Nullable(Of Short)
        <Required>
        <Column("SHOW_PROGRAM_NAME")>
        Public Property ShowProgramName() As Boolean
        <Required>
        <Column("GROUP_BY_DAYS_TIMES")>
        Public Property GroupByDaysTimes() As Boolean
        <Required>
        <Column("SUBTOTAL_BY_WEEKDAY_WEEKEND")>
        Public Property SubtotalByWeekdayWeekend() As Boolean
        <Column("SHARE_START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ShareStartDate() As Nullable(Of Date)
        <Column("SHARE_END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ShareEndDate() As Nullable(Of Date)
        <Column("HPUT_START_DATE")>
        Public Property HPUTStartDate() As Nullable(Of Date)
        <Column("HPUT_END_DATE")>
        Public Property HPUTEndDate() As Nullable(Of Date)

        Public Overridable Property MediaSpotTVPuertoRicoResearchDayTimes As ICollection(Of Database.Entities.MediaSpotTVPuertoRicoResearchDayTime)
        Public Overridable Property MediaSpotTVPuertoRicoResearchDemos As ICollection(Of Database.Entities.MediaSpotTVPuertoRicoResearchDemo)
        Public Overridable Property MediaSpotTVPuertoRicoResearchMetrics As ICollection(Of Database.Entities.MediaSpotTVPuertoRicoResearchMetric)
        Public Overridable Property MediaSpotTVPuertoRicoResearchStations As ICollection(Of Database.Entities.MediaSpotTVPuertoRicoResearchStation)

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

            If Me.IsEntityBeingAdded Then

                Me.SetRequired(AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearch.Properties.ShareStartDate.ToString, False)
                Me.SetRequired(AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearch.Properties.ShareEndDate.ToString, False)

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearch.Properties.CriteriaName.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded AndAlso (From Entity In DbContext.GetQuery(Of Database.Entities.MediaSpotTVPuertoRicoResearch)
                                                      Where Entity.UserCode.ToUpper = Me.UserCode.ToUpper AndAlso
                                                            Entity.CriteriaName.ToUpper = DirectCast(PropertyValue, String).Trim.ToUpper).Any Then

                        IsValid = False

                        ErrorText = "A report with this name exists."

                    ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearch.LoadByUserCode(DbContext, Me.UserCode)
                            Where Entity.CriteriaName.ToUpper = DirectCast(PropertyValue, String).Trim.ToUpper AndAlso
                                  Entity.ID <> Me.ID).Any Then

                        IsValid = False

                        ErrorText = "A report with this name exists."

                    End If

                Case AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearch.Properties.ShareStartDate.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded = False AndAlso PropertyValue IsNot Nothing AndAlso Me.ShareStartDate.HasValue AndAlso Me.ShareEndDate.HasValue Then

                        If Me.ShareStartDate.Value > Me.ShareEndDate.Value Then

                            IsValid = False

                            ErrorText = "Period start date must be before end date."

                        ElseIf (From Entity In DbContext.GetQuery(Of Database.Entities.NPRUniverse)
                                Where Entity.Date >= Me.ShareStartDate.Value AndAlso
                                      Entity.Date <= Me.ShareEndDate.Value
                                Select Entity).Count <> DateDiff(DateInterval.Day, Me.ShareStartDate.Value, Me.ShareEndDate.Value) + 1 Then

                            IsValid = False

                            ErrorText = "More than one universe record is missing for the Share date range specified."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String
            Return MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)
        End Function

#End Region

    End Class

End Namespace
