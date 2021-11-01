Namespace Maintenance.ProjectManagement.Presentation

    Public Class ResourceEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ResourceCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ResourceCode As String
            Get
                ResourceCode = _ResourceCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef ResourceCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _ResourceCode = ResourceCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef ResourceCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim ResourceEditDialog As AdvantageFramework.Maintenance.ProjectManagement.Presentation.ResourceEditDialog = Nothing

            ResourceEditDialog = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.ResourceEditDialog(ResourceCode)

            ShowFormDialog = ResourceEditDialog.ShowDialog()

            ResourceCode = ResourceEditDialog.ResourceCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ResourceEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _ResourceCode <> "" Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If ResourceControlForm_Resource.LoadControl(_ResourceCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The Resource you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            Dim ResourceCode As String = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If ResourceControlForm_Resource.Insert(ResourceCode) Then

                        _ResourceCode = ResourceCode

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
            Dim Resource As AdvantageFramework.Database.Entities.Resource = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If ResourceControlForm_Resource.Save() Then

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
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace