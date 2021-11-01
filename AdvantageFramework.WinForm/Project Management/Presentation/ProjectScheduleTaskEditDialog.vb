Namespace ProjectManagement.Presentation

    Public Class ProjectScheduleTaskEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _SequenceNumber As Short = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property JobNumber As Integer
            Get
                JobNumber = _JobNumber
            End Get
        End Property
        Public ReadOnly Property JobComponentNumber As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
        End Property
        Public ReadOnly Property SequenceNumber As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef JobNumber As Integer, ByRef JobComponentNumber As Short, ByRef SequenceNumber As Short)

            ' This call is required by the designer.
            InitializeComponent()

            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber
            _SequenceNumber = SequenceNumber

        End Sub
        Private Sub EnableOrDisableActions()

            RibbonBarOptions_Employees.Visible = JobComponentTaskControlForm_Task.IsEmployeesTabSelected

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef JobNumber As Integer, ByRef JobComponentNumber As Short, ByRef SequenceNumber As Short) As System.Windows.Forms.DialogResult

            'objects
            Dim ProjectScheduleTaskEditDialog As AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskEditDialog = Nothing

            ProjectScheduleTaskEditDialog = New AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskEditDialog(JobNumber, JobComponentNumber, SequenceNumber)

            ShowFormDialog = ProjectScheduleTaskEditDialog.ShowDialog()

            JobNumber = ProjectScheduleTaskEditDialog.JobNumber
            JobComponentNumber = ProjectScheduleTaskEditDialog.JobComponentNumber
            SequenceNumber = ProjectScheduleTaskEditDialog.SequenceNumber

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectScheduleTaskEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_MarkCompleted.Image = AdvantageFramework.My.Resources.CheckImage
            ButtonItemActions_AddTime.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemActions_NewAlert.Image = AdvantageFramework.My.Resources.NewAlertImage
            ButtonItemActions_NewAssignment.Image = AdvantageFramework.My.Resources.NewAlertAssignmentImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemEmployees_Details.Image = AdvantageFramework.My.Resources.EmployeesImage

            If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

                

            Else

                

            End If

            If JobComponentTaskControlForm_Task.LoadControl(_JobNumber, _JobComponentNumber, _SequenceNumber) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There was a problem loading the task.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemEmployees_Details_Click(sender As Object, e As EventArgs) Handles ButtonItemEmployees_Details.Click

            JobComponentTaskControlForm_Task.AddEmployees()

            EnableOrDisableActions()

        End Sub
        Private Sub JobComponentTaskControlForm_Task_SelectedTabChanged() Handles JobComponentTaskControlForm_Task.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_MarkCompleted_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_MarkCompleted.Click

            JobComponentTaskControlForm_Task.MarkCompleted()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_AddTime_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AddTime.Click

            JobComponentTaskControlForm_Task.AddTimeToTask()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_NewAlert_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_NewAlert.Click

            JobComponentTaskControlForm_Task.CreateAlert()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_NewAssignment_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_NewAssignment.Click

            JobComponentTaskControlForm_Task.AddAssignment()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            JobComponentTaskControlForm_Task.Print()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemEmployees_ShowQuotedHours_Click(sender As Object, e As EventArgs) Handles ButtonItemEmployees_ShowQuotedHours.CheckedChanged

            JobComponentTaskControlForm_Task.HideOrShowQuotedHours(ButtonItemEmployees_ShowQuotedHours.Checked)

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace