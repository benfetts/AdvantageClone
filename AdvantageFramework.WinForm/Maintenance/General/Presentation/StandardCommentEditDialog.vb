Namespace Maintenance.General.Presentation

    Public Class StandardCommentEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _StandardCommentID As Integer = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property StandardCommentID As Integer
            Get
                StandardCommentID = _StandardCommentID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef StandardCommentID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _StandardCommentID = StandardCommentID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef StandardCommentID As Integer = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim StandardCommentEditDialog As AdvantageFramework.Maintenance.General.Presentation.StandardCommentEditDialog = Nothing

            StandardCommentEditDialog = New AdvantageFramework.Maintenance.General.Presentation.StandardCommentEditDialog(StandardCommentID)

            ShowFormDialog = StandardCommentEditDialog.ShowDialog()

            StandardCommentID = StandardCommentEditDialog.StandardCommentID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub StandardCommentEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _StandardCommentID <> 0 Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

                If StandardCommentControlForm_StandardComment.LoadControl(_StandardCommentID) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("The comment you are trying to edit does not exist anymore.")
                    Me.Close()

                End If

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

                If StandardCommentControlForm_StandardComment.LoadControl(_StandardCommentID) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("There was an error loading the standard comment dialog..")
                    Me.Close()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim StandardCommentID As Integer = 0
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If StandardCommentControlForm_StandardComment.Insert(StandardCommentID) Then

                        _StandardCommentID = StandardCommentID

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
        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If StandardCommentControlForm_StandardComment.Save() Then

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