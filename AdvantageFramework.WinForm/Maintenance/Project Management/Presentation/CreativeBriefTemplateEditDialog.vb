Namespace Maintenance.ProjectManagement.Presentation

    Public Class CreativeBriefTemplateEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CreativeBriefTemplateID As Integer = Nothing
        Private _IsCopy As Boolean = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property CreativeBriefTemplateID As Integer
            Get
                CreativeBriefTemplateID = _CreativeBriefTemplateID
            End Get
        End Property
        Private ReadOnly Property IsCopy As String
            Get
                IsCopy = _IsCopy
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef CreativeBriefTemplateID As Integer, ByVal IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _CreativeBriefTemplateID = CreativeBriefTemplateID
            _IsCopy = IsCopy

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef CreativeBriefTemplateID As Integer = Nothing, Optional ByVal IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim CreativeBriefTemplateEditDialog As AdvantageFramework.Maintenance.ProjectManagement.Presentation.CreativeBriefTemplateEditDialog = Nothing

            CreativeBriefTemplateEditDialog = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.CreativeBriefTemplateEditDialog(CreativeBriefTemplateID, IsCopy)

            ShowFormDialog = CreativeBriefTemplateEditDialog.ShowDialog()

            CreativeBriefTemplateID = CreativeBriefTemplateEditDialog.CreativeBriefTemplateID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CreativeBriefTemplateEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _CreativeBriefTemplateID <> Nothing Then

                If _IsCopy Then

                    ButtonForm_Add.Visible = True
                    ButtonForm_Update.Visible = False

                Else

                    ButtonForm_Add.Visible = False
                    ButtonForm_Update.Visible = True

                End If

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If CreativeBriefTemplateControlForm_CreativeBriefTemplate.LoadControl(_CreativeBriefTemplateID, _IsCopy) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The creative brief template you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub CreativeBriefTemplateEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                CreativeBriefTemplateControlForm_CreativeBriefTemplate.TextBoxHeader_Code.Focus()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim CreativeBriefTemplateID As Integer = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If CreativeBriefTemplateControlForm_CreativeBriefTemplate.Insert(CreativeBriefTemplateID) Then

                        _CreativeBriefTemplateID = CreativeBriefTemplateID

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

                    If CreativeBriefTemplateControlForm_CreativeBriefTemplate.Save() Then

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