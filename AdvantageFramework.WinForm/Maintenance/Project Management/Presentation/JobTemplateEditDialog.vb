Namespace Maintenance.ProjectManagement.Presentation

    Public Class JobTemplateEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobTemplateCode As String = Nothing
        Private _IsCopy As Boolean = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property JobTemplateCode As String
            Get
                JobTemplateCode = _JobTemplateCode
            End Get
        End Property
        Private ReadOnly Property IsCopy As Boolean
            Get
                IsCopy = _IsCopy
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef JobTemplateCode As String, ByRef IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _JobTemplateCode = JobTemplateCode
            _IsCopy = IsCopy

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            ButtonItemTemplateItems_Delete.Enabled = JobTemplateControlForm_JobTemplate.JobTemplateDetailsGrid.HasASelectedRow
            ButtonItemTemplateItems_MoveDown.Enabled = JobTemplateControlForm_JobTemplate.CanMoveItemDown
            ButtonItemTemplateItems_MoveUp.Enabled = JobTemplateControlForm_JobTemplate.CanMoveItemUp
            ButtonItemTemplateItems_Add.Enabled = JobTemplateControlForm_JobTemplate.DataGridViewLeftSection_JobTemplateItems.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef JobTemplateCode As String = Nothing, Optional ByVal IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim JobTemplateEditDialog As AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobTemplateEditDialog = Nothing

            JobTemplateEditDialog = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobTemplateEditDialog(JobTemplateCode, IsCopy)

            ShowFormDialog = JobTemplateEditDialog.ShowDialog()

            JobTemplateCode = JobTemplateEditDialog.JobTemplateCode
            IsCopy = JobTemplateEditDialog.IsCopy

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobTemplateEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.CloseButtonVisible = False

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemTemplateItems_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemTemplateItems_MoveDown.Image = AdvantageFramework.My.Resources.DownImage
            ButtonItemTemplateItems_MoveUp.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemTemplateItems_Add.Image = AdvantageFramework.My.Resources.DetailAddImage

            If _IsCopy AndAlso _JobTemplateCode <> "" Then

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            ElseIf _JobTemplateCode <> "" Then

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            End If

            If JobTemplateControlForm_JobTemplate.LoadControl(_JobTemplateCode, _IsCopy) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The job template you are trying to edit does not exist anymore.")
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub JobTemplateEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub JobTemplateEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim JobTemplateCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If JobTemplateControlForm_JobTemplate.Insert(JobTemplateCode) Then

                        _JobTemplateCode = JobTemplateCode

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
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If JobTemplateControlForm_JobTemplate.Save() Then

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
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemTemplateItems_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemTemplateItems_Add.Click

            JobTemplateControlForm_JobTemplate.AddSelectedTemplateItems()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTemplateItems_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemTemplateItems_Delete.Click

            JobTemplateControlForm_JobTemplate.DeleteSelectedTemplateItems()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTemplateItems_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonItemTemplateItems_MoveDown.Click

            JobTemplateControlForm_JobTemplate.MoveDownSelectedItem()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTemplateItems_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonItemTemplateItems_MoveUp.Click

            JobTemplateControlForm_JobTemplate.MoveUpSelectedItem()

            EnableOrDisableActions()

        End Sub
        Private Sub JobTemplateControlForm_JobTemplate_SelectedJobTemplateDetailChanged() Handles JobTemplateControlForm_JobTemplate.SelectedJobTemplateDetailChanged

            EnableOrDisableActions()

        End Sub
        Private Sub JobTemplateControlForm_JobTemplate_SelectedJobTemplateItemChanged() Handles JobTemplateControlForm_JobTemplate.SelectedJobTemplateItemChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace