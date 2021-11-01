Namespace Maintenance.ProjectManagement.Presentation

    Public Class JobVersionTemplateEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobVersionTemplateCode As String = Nothing
        Private _IsCopy As Boolean = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property JobVersionTemplateCode As String
            Get
                JobVersionTemplateCode = _JobVersionTemplateCode
            End Get
        End Property
        Private ReadOnly Property IsCopy As String
            Get
                IsCopy = _IsCopy
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef JobVersionTemplateCode As String, ByVal IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _JobVersionTemplateCode = JobVersionTemplateCode
            _IsCopy = IsCopy

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef JobVersionTemplateCode As String = Nothing, Optional ByVal IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim JobVersionTemplateEditDialog As AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionTemplateEditDialog = Nothing

            JobVersionTemplateEditDialog = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionTemplateEditDialog(JobVersionTemplateCode, IsCopy)

            ShowFormDialog = JobVersionTemplateEditDialog.ShowDialog()

            JobVersionTemplateCode = JobVersionTemplateEditDialog.JobVersionTemplateCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobVersionTemplateEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _JobVersionTemplateCode <> "" Then

                If _IsCopy Then

                    ButtonForm_Add.Visible = True
                    ButtonForm_Update.Visible = False

                Else

                    ButtonForm_Add.Visible = False
                    ButtonForm_Update.Visible = True

                End If

            Else

                ' hides grid
                Me.Size = New System.Drawing.Size(545, 137)

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If JobVersionTemplateControlForm_JobVersionTemplate.LoadControl(_JobVersionTemplateCode, _IsCopy) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The job version template you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim JobVersionTemplateCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If JobVersionTemplateControlForm_JobVersionTemplate.Insert(JobVersionTemplateCode) Then

                        _JobVersionTemplateCode = JobVersionTemplateCode

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

                    If JobVersionTemplateControlForm_JobVersionTemplate.Save() Then

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
