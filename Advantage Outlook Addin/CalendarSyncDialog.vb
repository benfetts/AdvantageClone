Public Class CalendarSyncDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Employee As AdvantageFramework.Database.Views.Employee = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Shared Sub SyncAppointments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                        ByVal EmployeeNonTasksList As List(Of AdvantageFramework.Database.Entities.EmployeeNonTask),
                                        ByVal AppointmentItems As List(Of Microsoft.Office.Interop.Outlook.AppointmentItem),
                                        ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                        ByRef ProgressBarValue As Integer, ByRef ErrorReport As String)

        'objects
        Dim OutlookCalendar As Microsoft.Office.Interop.Outlook.MAPIFolder = Nothing
        Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
        Dim AppointmentItem As Microsoft.Office.Interop.Outlook.AppointmentItem = Nothing
        Dim DayDifference As Integer = 0

        OutlookCalendar = Globals.AdvantageOutlookAddin.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar)

        AdvantageFramework.WinForm.Presentation.ProgressDialog.UpdateProgressAndStatus(0, "Syncing Outlook Appointments...")

        For Each AppointmentItem In AppointmentItems

            Try

                AdvantageFramework.WinForm.Presentation.ProgressDialog.UpdateProgressAndStatus(ProgressBarValue, "Syncing Outlook Appointment " & AppointmentItem.Subject & "...")

                If AppointmentItem.BillingInformation = "" Then

                    EmployeeNonTask = New AdvantageFramework.Database.Entities.EmployeeNonTask

                    EmployeeNonTask.Type = "A"
                    EmployeeNonTask.EmployeeCode = Employee.Code
                    EmployeeNonTask.Description = AppointmentItem.Subject
                    EmployeeNonTask.StartDate = CDate(AppointmentItem.Start.ToShortDateString)
                    EmployeeNonTask.EndDate = CDate(AppointmentItem.End.ToShortDateString)
                    EmployeeNonTask.StartDateAndTime = AppointmentItem.Start
                    EmployeeNonTask.EndDateAndTime = AppointmentItem.End

                    DayDifference = Math.Abs(DateDiff(DateInterval.Day, AppointmentItem.Start, AppointmentItem.End))

                    If AppointmentItem.AllDayEvent Then

                        EmployeeNonTask.IsAllDay = 1

                        If DayDifference = 0 Then

                            EmployeeNonTask.Hours = Agency.StandardHours.GetValueOrDefault(0)

                        Else

                            EmployeeNonTask.Hours = Agency.StandardHours.GetValueOrDefault(0) * DayDifference

                        End If

                    Else

                        EmployeeNonTask.IsAllDay = 0

                        If DayDifference = 0 Then

                            EmployeeNonTask.Hours = AppointmentItem.End.Subtract(AppointmentItem.Start).TotalHours

                            If EmployeeNonTask.Hours > Agency.StandardHours.GetValueOrDefault(0) Then

                                EmployeeNonTask.Hours = Agency.StandardHours.GetValueOrDefault(0)

                            End If

                        Else

                            EmployeeNonTask.Hours = AdvantageFramework.EmployeeUtilities.LoadTotalHoursWorked(Employee, AppointmentItem.Start, AppointmentItem.End)

                        End If

                    End If

                    If AdvantageFramework.Database.Procedures.EmployeeNonTask.Insert(DbContext, EmployeeNonTask) Then

                        Try

                            AppointmentItem.BillingInformation = EmployeeNonTask.Type & EmployeeNonTask.ID.ToString

                            AppointmentItem.Save()

                        Catch ex As Exception
                            ErrorReport &= vbCrLf & "Failed updating Outlook appointment into Advantage --> " & EmployeeNonTask.Description
                        End Try

                    Else

                        ErrorReport &= vbCrLf & "Failed inserting Outlook appointment into Advantage --> " & AppointmentItem.Subject

                    End If

                End If

            Catch ex As Exception
                ErrorReport &= vbCrLf & "Failed syncing Outlook appointment --> " & AppointmentItem.Subject
            End Try

            ProgressBarValue += 1

        Next

        EmployeeNonTask = Nothing
        AppointmentItem = Nothing

        AdvantageFramework.WinForm.Presentation.ProgressDialog.UpdateProgressAndStatus(ProgressBarValue, "Syncing Advantage Appointments...")

        For Each EmployeeNonTask In EmployeeNonTasksList

            Try

                If EmployeeNonTask.Type = "A" Then

                    AppointmentItem = OutlookCalendar.Items.Find("[BillingInformation]=" + EmployeeNonTask.Type & EmployeeNonTask.ID.ToString)

                    If AppointmentItem Is Nothing Then

                        AdvantageFramework.WinForm.Presentation.ProgressDialog.UpdateProgressAndStatus(ProgressBarValue, "Syncing Advantage Appointment " & EmployeeNonTask.Description & "...")

                        AppointmentItem = Advantage_Outlook_Addin.Globals.AdvantageOutlookAddin.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem)

                        AppointmentItem.BillingInformation = EmployeeNonTask.Type & EmployeeNonTask.ID.ToString

                        Boolean.TryParse(EmployeeNonTask.IsAllDay.GetValueOrDefault(0).ToString, AppointmentItem.AllDayEvent)

                        AppointmentItem.Start = EmployeeNonTask.StartDateAndTime.GetValueOrDefault(EmployeeNonTask.StartDate)
                        AppointmentItem.End = EmployeeNonTask.EndDateAndTime.GetValueOrDefault(EmployeeNonTask.EndDate)
                        AppointmentItem.Body = EmployeeNonTask.Description
                        AppointmentItem.Subject = EmployeeNonTask.Description
                        AppointmentItem.Location = ""

                        Try

                            AppointmentItem.Save()

                        Catch ex As Exception
                            ErrorReport &= vbCrLf & "Failed insert Advantage appointment into Outlook --> " & EmployeeNonTask.Description
                        End Try

                    End If

                End If

            Catch ex As Exception
                ErrorReport &= vbCrLf & "Failed syncing Advantage appointment --> " & EmployeeNonTask.Description
            End Try

            ProgressBarValue += 1

        Next

    End Sub
    Private Shared Sub SyncTasks(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                 ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                 ByVal JobComponentTasksList As List(Of AdvantageFramework.Database.Entities.JobComponentTask),
                                 ByRef ProgressBarValue As Integer, ByRef ErrorReport As String)

        'objects
        Dim OutlookCalendar As Microsoft.Office.Interop.Outlook.MAPIFolder = Nothing
        Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
        Dim TaskItem As Microsoft.Office.Interop.Outlook.TaskItem = Nothing
        Dim DayDifference As Integer = 0

        OutlookCalendar = Globals.AdvantageOutlookAddin.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderTasks)

        AdvantageFramework.WinForm.Presentation.ProgressDialog.UpdateProgressAndStatus(ProgressBarValue, "Syncing Advantage Tasks...")

        For Each JobComponentTask In JobComponentTasksList

            Try

                TaskItem = OutlookCalendar.Items.Find("[BillingInformation]=JobComponentTaskID" & JobComponentTask.ID)

                If TaskItem Is Nothing Then

                    AdvantageFramework.WinForm.Presentation.ProgressDialog.UpdateProgressAndStatus(ProgressBarValue, "Syncing Advantage Task " & JobComponentTask.Description & "...")

                    TaskItem = Advantage_Outlook_Addin.Globals.AdvantageOutlookAddin.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olTaskItem)

                    TaskItem.Start = JobComponentTask.StartDate
                    TaskItem.End = JobComponentTask.DueDate
                    TaskItem.DateCompleted = JobComponentTask.CompletedDate
                    TaskItem.Subject = JobComponentTask.Description
                    TaskItem.Body = JobComponentTask.Description
                    TaskItem.BillingInformation = "JobComponentTaskID" & JobComponentTask.ID

                    Try

                        TaskItem.Save()

                    Catch ex As Exception
                        ErrorReport &= vbCrLf & "Failed insert Advantage Task into Outlook --> " & JobComponentTask.Description
                    End Try

                End If

            Catch ex As Exception
                ErrorReport &= vbCrLf & "Failed syncing Advantage Task --> " & JobComponentTask.Description
            End Try

            ProgressBarValue += 1

        Next

    End Sub
    Private Shared Sub CalendarSync(ByVal Parameters() As Object)

        'objects
        Dim OutlookCalendar As Microsoft.Office.Interop.Outlook.MAPIFolder = Nothing
        Dim AppointmentItems As List(Of Microsoft.Office.Interop.Outlook.AppointmentItem) = Nothing
        Dim EmployeeNonTasksList As List(Of AdvantageFramework.Database.Entities.EmployeeNonTask) = Nothing
        Dim JobComponentTasksList As List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing
        Dim ProgressBarValue As Integer = 0
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim ErrorReport As String = ""
        Dim Appointments As Boolean = False
        Dim Tasks As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim TotalItems As Long = 0

        Try

            Employee = Parameters(0)
            Appointments = Parameters(1)
            Tasks = Parameters(2)

            AdvantageFramework.WinForm.Presentation.ProgressDialog.UpdateProgressAndStatus(0, "Loading Advantage and Outlook Appointments...")

            Using DbContext = New AdvantageFramework.Database.DbContext("", "SYSTEM")

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    If Appointments Then

                        OutlookCalendar = Globals.AdvantageOutlookAddin.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar)

                        AppointmentItems = OutlookCalendar.Items.OfType(Of Microsoft.Office.Interop.Outlook.AppointmentItem)().ToList
                        EmployeeNonTasksList = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeCode(DbContext, Employee.Code).ToList

                        TotalItems += (AppointmentItems.Count + EmployeeNonTasksList.Count)

                    End If

                    If Tasks Then

                        JobComponentTasksList = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByEmployeeCode(DbContext, Employee.Code).ToList

                        TotalItems += JobComponentTasksList.Count

                    End If

                    AdvantageFramework.WinForm.Presentation.ProgressDialog.SetupProgressBar(TotalItems, 0)

                    If Appointments Then

                        SyncAppointments(DbContext, Employee, EmployeeNonTasksList, AppointmentItems, Agency, ProgressBarValue, ErrorReport)

                    End If

                    If Tasks Then

                        SyncTasks(DbContext, Employee, JobComponentTasksList, ProgressBarValue, ErrorReport)

                    End If

                End If

            End Using

        Catch ex As Exception
            ErrorReport &= vbCrLf & "Failed syncing"
        End Try

        If ErrorReport = "" Then

            AdvantageFramework.Navigation.ShowMessageBox("Calendar Sync Successful!")

        Else

            AdvantageFramework.Navigation.ShowMessageBox("Calendar Sync finshed with errors..." & ErrorReport)

        End If

        AdvantageFramework.WinForm.Presentation.ProgressDialog.CloseProgressDialog()

        System.Threading.Thread.CurrentThread.Abort()

    End Sub

#Region "  Show Form Methods "

    Public Shared Function ShowFormDialog() As Windows.Forms.DialogResult

        'objects
        Dim CalendarSyncDialog As Advantage_Outlook_Addin.CalendarSyncDialog = Nothing

        CalendarSyncDialog = New Advantage_Outlook_Addin.CalendarSyncDialog()

        ShowFormDialog = CalendarSyncDialog.ShowDialog()

    End Function

#End Region

#Region "  Form Event Handlers "

    Private Sub CalendarSyncDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Using DbContext = New AdvantageFramework.Database.DbContext("", "SYSTEM")

            _Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

            If _Employee IsNot Nothing Then

                LabelForm_Employee.Text = "Employee: " & _Employee.FirstName & " " & _Employee.LastName & "      Email: " & _Employee.Email

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Could not find this email address in the system.")

                Me.Close()

            End If

        End Using

        CheckBoxForm_Appointments.Checked = True
        CheckBoxForm_Tasks.Checked = True

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonForm_Sync_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Sync.Click

        'objects
        Dim SyncCalendar As Boolean = True
        Dim Thread As System.Threading.Thread = Nothing
        Dim ParametersList As List(Of Object) = Nothing


        If CheckBoxForm_Appointments.Checked = False AndAlso _
                CheckBoxForm_Tasks.Checked = False Then

            AdvantageFramework.Navigation.ShowMessageBox("Please select a an item to sync.")
            SyncCalendar = False

        End If

        If SyncCalendar Then

            Thread = New System.Threading.Thread(AddressOf CalendarSync)

            ParametersList = New List(Of Object)

            ParametersList.Add(_Employee)
            ParametersList.Add(CheckBoxForm_Appointments.Checked)
            ParametersList.Add(CheckBoxForm_Tasks.Checked)

            AdvantageFramework.WinForm.Presentation.ProgressDialog.ShowFormDialog(Thread, ParametersList.ToArray, "Syncing Calendars for Employee: " & _Employee.FirstName & " " & _Employee.LastName & "      Email: " & _Employee.Email)

            Thread.Join()

        End If

    End Sub
    Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Close.Click

        Me.Close()

    End Sub

#End Region

#End Region

End Class