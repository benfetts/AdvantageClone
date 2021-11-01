Namespace Maintenance.Media.Presentation

    Public Class PartnerEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PartnerCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property PartnerCode As String
            Get
                PartnerCode = _PartnerCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef PartnerCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _PartnerCode = PartnerCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef PartnerCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim PartnerEditDialog As AdvantageFramework.Maintenance.Media.Presentation.PartnerEditDialog = Nothing

            PartnerEditDialog = New AdvantageFramework.Maintenance.Media.Presentation.PartnerEditDialog(PartnerCode)

            ShowFormDialog = PartnerEditDialog.ShowDialog()

            PartnerCode = PartnerEditDialog.PartnerCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PartnerEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemSpelling_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            If _PartnerCode <> "" Then

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            End If

            If PartnerControlForm_Partner.LoadControl(_PartnerCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The partner you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub PartnerEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                PartnerControlForm_Partner.TextBoxForm_Code.Focus()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim PartnerCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                Try

                    If PartnerControlForm_Partner.Insert(PartnerCode) Then

                        _PartnerCode = PartnerCode

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.ShowWaitForm("Saving...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                Try

                    If PartnerControlForm_Partner.Save() Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemSpelling_CheckSpelling_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSpelling_CheckSpelling.Click

            PartnerControlForm_Partner.SpellCheck()

        End Sub

#End Region

#End Region

    End Class

End Namespace