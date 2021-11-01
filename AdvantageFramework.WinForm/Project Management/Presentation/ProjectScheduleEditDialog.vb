Namespace ProjectManagement.Presentation

    Public Class ProjectScheduleEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobTrafficID As Integer = Nothing
        Private _IsCopy As Boolean = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property JobTrafficID As Integer
            Get
                JobTrafficID = _JobTrafficID
            End Get
        End Property
        Private ReadOnly Property IsCopy As Boolean
            Get
                IsCopy = _IsCopy
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef JobTrafficID As Integer, ByRef IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _JobTrafficID = JobTrafficID
            _IsCopy = IsCopy

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef JobTrafficID As Integer = Nothing, Optional ByRef IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim ProjectScheduleEditDialog As AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleEditDialog = Nothing

            ProjectScheduleEditDialog = New AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleEditDialog(JobTrafficID, IsCopy)

            ShowFormDialog = ProjectScheduleEditDialog.ShowDialog()

            JobTrafficID = ProjectScheduleEditDialog.JobTrafficID
            IsCopy = ProjectScheduleEditDialog.IsCopy

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectScheduleEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage

            If _JobTrafficID > 0 Then

                If _IsCopy Then

                    ItemContainerActions_CopyOptions.Visible = True
                    ButtonItemActions_Add.Visible = True
                    ButtonItemActions_Save.Visible = False

                Else

                    ItemContainerActions_CopyOptions.Visible = False
                    ButtonItemActions_Add.Visible = False
                    ButtonItemActions_Save.Visible = True

                End If

            Else

                ItemContainerActions_CopyOptions.Visible = False
                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ResetRibbonBar(RibbonBarOptions_Actions)

            If ProjectScheduleControlForm_ProjectSchedule.LoadControl(_JobTrafficID, _IsCopy) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There was a problem loading the project schedule.")
                Me.Close()

            End If

        End Sub
        Private Sub ProjectScheduleEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ProjectScheduleEditDialog_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim JobTrafficID As Integer = Nothing
            Dim ParentControl As Object = Nothing
            Dim FailedControl As Object = Nothing
            Dim ErrorMessage As String = ""
            Dim InsertedOrCopied As Boolean = False

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If _IsCopy Then

                        InsertedOrCopied = ProjectScheduleControlForm_ProjectSchedule.Copy(JobTrafficID, CheckBoxItemCopyOptions_CopyDates.Checked)

                    Else

                        InsertedOrCopied = ProjectScheduleControlForm_ProjectSchedule.Insert(JobTrafficID)

                    End If

                    If InsertedOrCopied Then

                        _JobTrafficID = JobTrafficID

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

                FailedControl = (Me.SuperValidator.LastFailedValidationResults.ToList.FirstOrDefault).Control

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim FailedControl As Object = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If ProjectScheduleControlForm_ProjectSchedule.Save() Then

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

                FailedControl = (Me.SuperValidator.LastFailedValidationResults.ToList.FirstOrDefault).Control

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace