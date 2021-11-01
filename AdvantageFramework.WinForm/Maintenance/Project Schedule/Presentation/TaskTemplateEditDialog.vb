Namespace Maintenance.ProjectSchedule.Presentation

    Public Class TaskTemplateEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _TaskTemplateCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property TaskTemplateCode As String
            Get
                TaskTemplateCode = _TaskTemplateCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef TaskTemplateCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _TaskTemplateCode = TaskTemplateCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef TaskTemplateCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim TaskTemplateEditDialog As AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateEditDialog = Nothing

            TaskTemplateEditDialog = New AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateEditDialog(TaskTemplateCode)

            ShowFormDialog = TaskTemplateEditDialog.ShowDialog()

            TaskTemplateCode = TaskTemplateEditDialog.TaskTemplateCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub TaskTemplateEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _TaskTemplateCode <> "" Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

                TaskTemplateControlForm_TaskTemplate.DataGridViewForm_TaskTemplateDetails.Enabled = False
                TaskTemplateControlForm_TaskTemplate.DataGridViewForm_TaskTemplateDetails.Visible = False
                TaskTemplateControlForm_TaskTemplate.GroupBoxForm_ScheduleCompletionDays.Visible = False

            End If

            If TaskTemplateControlForm_TaskTemplate.LoadControl(_TaskTemplateCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The task template you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub TaskTemplateEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If _TaskTemplateCode = "" Then

                Me.Size = New System.Drawing.Size(550, Me.Size.Height - TaskTemplateControlForm_TaskTemplate.DataGridViewForm_TaskTemplateDetails.Size.Height - TaskTemplateControlForm_TaskTemplate.GroupBoxForm_ScheduleCompletionDays.Height)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim TaskTemplateCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If TaskTemplateControlForm_TaskTemplate.Insert(TaskTemplateCode) Then

                        _TaskTemplateCode = TaskTemplateCode

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If TaskTemplateControlForm_TaskTemplate.Save() Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace