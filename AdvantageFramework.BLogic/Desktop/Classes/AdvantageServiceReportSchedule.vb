Namespace Desktop.Classes

    <Serializable()>
    Public Class AdvantageServiceReportSchedule
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ReportScheduleType
            ReportName
            EmployeeCode
            ReportID
            ExportType
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

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ReportScheduleType() As AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleType
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ReportName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EmployeeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ReportID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ExportType() As AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleExportType
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Frequency() As AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleFrequency
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Sunday() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Monday() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Tuesday() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Wednesday() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Thursday() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Friday() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Saturday() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", MinValue:=1, UseMinValue:=True, MaxValue:=28, UseMaxValue:=True)>
        Public Property DayOfMonth() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="g")>
        Public Property ScheduleStartTime() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="g")>
        Public Property ScheduleEndDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmailAddress() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="g")>
        Public Property LastRan() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ParameterDictionary() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsAgencyASP() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Criteria As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FilterString As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FromDate As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ToDate As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowJobsWithNoDetails As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DynamicReportType As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.FromDate = Now.ToShortDateString
            Me.ToDate = Now.ToShortDateString

        End Sub
        Public Sub New(AdvantageServiceReportSchedule As AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule, IsAgencyASP As Boolean,
                       DynamicReports As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.DynamicReport))

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

            Me.ID = AdvantageServiceReportSchedule.ID
            Me.ReportScheduleType = AdvantageServiceReportSchedule.ReportScheduleType
            Me.EmployeeCode = AdvantageServiceReportSchedule.EmployeeCode
            Me.ReportID = AdvantageServiceReportSchedule.ReportID
            Me.ExportType = AdvantageServiceReportSchedule.ExportType
            Me.Frequency = AdvantageServiceReportSchedule.Frequency
            Me.Sunday = AdvantageServiceReportSchedule.Sunday
            Me.Monday = AdvantageServiceReportSchedule.Monday
            Me.Tuesday = AdvantageServiceReportSchedule.Tuesday
            Me.Wednesday = AdvantageServiceReportSchedule.Wednesday
            Me.Thursday = AdvantageServiceReportSchedule.Thursday
            Me.Friday = AdvantageServiceReportSchedule.Friday
            Me.Saturday = AdvantageServiceReportSchedule.Saturday
            Me.DayOfMonth = AdvantageServiceReportSchedule.DayOfMonth
            Me.ScheduleStartTime = AdvantageServiceReportSchedule.ScheduleStartTime
            Me.ScheduleEndDate = AdvantageServiceReportSchedule.ScheduleEndDate
            Me.LastRan = AdvantageServiceReportSchedule.LastRan
            Me.ParameterDictionary = AdvantageServiceReportSchedule.ParameterDictionary
            Me.EmailAddress = AdvantageServiceReportSchedule.EmailAddress

            Me.IsAgencyASP = IsAgencyASP
            Me.Criteria = AdvantageServiceReportSchedule.Criteria.GetValueOrDefault(0)
            Me.FilterString = AdvantageServiceReportSchedule.FilterString
            Me.FromDate = AdvantageServiceReportSchedule.FromDate.GetValueOrDefault(Now.ToShortDateString)
            Me.ToDate = AdvantageServiceReportSchedule.ToDate.GetValueOrDefault(Now.ToShortDateString)
            Me.ShowJobsWithNoDetails = AdvantageServiceReportSchedule.ShowJobsWithNoDetails

            DynamicReport = DynamicReports.Where(Function(DR) DR.ID = Me.ReportID).FirstOrDefault

            If DynamicReport IsNot Nothing Then

                Me.DynamicReportType = DynamicReport.Type
                Me.ReportName = DynamicReport.Description

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Sub SetFrequency(Frequency As AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleFrequency)

            If Frequency = AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleFrequency.Daily OrElse
                    Frequency = AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleFrequency.Monthly Then

                Me.Sunday = False
                Me.Monday = False
                Me.Tuesday = False
                Me.Wednesday = False
                Me.Thursday = False
                Me.Friday = False
                Me.Saturday = False

                If Frequency = AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleFrequency.Daily Then

                    Me.DayOfMonth = Nothing

                End If

            ElseIf Frequency = AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleFrequency.Weekly Then

                Me.DayOfMonth = Nothing

            End If

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.DayOfMonth.ToString

                        If Me.Frequency = Database.Entities.Methods.AdvantageServiceReportScheduleFrequency.Monthly Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.ParameterDictionary.ToString

                        If (Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerDetail OrElse
                                Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                                Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                                Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                                Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth) Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.Criteria.ToString

                        If Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim ParameterDictionary As Dictionary(Of String, Object) = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.ReportID.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        ErrorText = "Report ID is required."
                        IsValid = False

                    End If

                Case AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.ExportType.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        ErrorText = "Export type is required."
                        IsValid = False

                    End If

                Case AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.Frequency.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        ErrorText = "Frequency is required."
                        IsValid = False

                    ElseIf PropertyValue = Database.Entities.Methods.AdvantageServiceReportScheduleFrequency.Weekly Then

                        If (Me.Sunday OrElse Me.Monday OrElse Me.Tuesday OrElse Me.Wednesday OrElse Me.Thursday OrElse Me.Friday OrElse Me.Saturday) = False Then

                            ErrorText = "Please check at least one day of the week."
                            IsValid = False

                        End If

                    End If

                Case AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.ScheduleEndDate.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If PropertyValue < Me.ScheduleStartTime Then

                            ErrorText = "Schedule end date must be after schedule start time."
                            IsValid = False

                        End If

                    End If

                Case AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.ParameterDictionary.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso
                            (Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerDetail OrElse
                             Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                             Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                             Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                             Me.DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth) Then

                        ParameterDictionary = AdvantageFramework.ClassUtilities.ReadObjectContentInDocument(DirectCast(PropertyValue, System.String))

                        If ParameterDictionary Is Nothing OrElse ParameterDictionary.Count = 0 Then

                            ErrorText = "Invalid criteria."
                            IsValid = False

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
