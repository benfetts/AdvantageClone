Namespace Database.Entities

    <Table("ADV_SERVICE_REPORT_SCHEDULE")>
    Public Class AdvantageServiceReportSchedule
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ReportScheduleType
            EmployeeCode
            ReportID
            Frequency
            Sunday
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            DayOfMonth
            ScheduleStartTime
            ScheduleEndDate
            LastRan
            ParameterDictionary
            EmailAddress
            Criteria
            FilterString
            FromDate
            ToDate
            ShowJobsWithNoDetails
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("ADV_SERVICE_REPORT_SCHEDULE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("REPORT_SCHEDULE_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ReportScheduleType() As AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleType
        <Required>
        <MaxLength(6)>
        <Column("EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EmployeeCode() As String
        <Required>
        <Column("REPORT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ReportID() As Integer
        <Required>
        <Column("EXPORT_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ExportType() As AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleExportType
        <Required>
        <Column("FREQUENCY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Frequency() As AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleFrequency
        <Required>
        <Column("SUNDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Sunday() As Boolean
        <Required>
        <Column("MONDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Monday() As Boolean
        <Required>
        <Column("TUESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Tuesday() As Boolean
        <Required>
        <Column("WEDNESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Wednesday() As Boolean
        <Required>
        <Column("THURSDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Thursday() As Boolean
        <Required>
        <Column("FRIDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Friday() As Boolean
        <Required>
        <Column("SATURDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Saturday() As Boolean
        <Column("DAY_OF_MONTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", MinValue:=1, UseMinValue:=True, MaxValue:=28, UseMaxValue:=True)>
        Public Property DayOfMonth() As Nullable(Of Short)
        <Required>
        <Column("SCHEDULE_START_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ScheduleStartTime() As Date
        <Column("SCHEDULE_END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ScheduleEndDate() As Nullable(Of Date)
        <Column("LAST_RAN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastRan() As Nullable(Of Date)
        <Required>
        <Column("PARAMETER_DICTIONARY", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ParameterDictionary() As String
        <MaxLength(50)>
        <Column("EMAIL_ADDRESS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmailAddress() As String
        <Column("CRITERIA")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Criteria As Nullable(Of Integer)
        <Column("FILTER_STRING", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FilterString As String
        <Column("FROM_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FromDate As Nullable(Of Date)
        <Column("TO_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ToDate As Nullable(Of Date)
        <Required>
        <Column("SHOW_JOBS_WITH_NO_DETAILS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ShowJobsWithNoDetails As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
