Namespace Desktop.Presentation

    Public Class CalendarForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                'SchedulerStorage.Appointments.DataSource = AdvantageFramework.Database.Procedures.CalendarItemComplexTy.Load(DbContext, Me.Session.UserCode, Me.Session.User.EmployeeCode, "", "", "",
                '                                                                                                               "", "", "", "", CDate(SchedulerForm_Calendar.Start.Month & "/01/" & SchedulerForm_Calendar.Start.Year),
                '                                                                                                               CDate(SchedulerForm_Calendar.Start.Month & "/" & Date.DaysInMonth(SchedulerForm_Calendar.Start.Year, SchedulerForm_Calendar.Start.Month) & "/" & SchedulerForm_Calendar.Start.Year),
                '                                                                                                               "", "", "", "", "", "", 1, 1, 1, 1, "", "")

            End Using

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CalendarForm As CalendarForm = Nothing

            CalendarForm = New CalendarForm

            CalendarForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CalendarForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub SchedulerStorage_FetchAppointments(sender As Object, e As DevExpress.XtraScheduler.FetchAppointmentsEventArgs) Handles SchedulerStorage.FetchAppointments

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadGrid()

                    e.ForceReloadAppointments = True

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
