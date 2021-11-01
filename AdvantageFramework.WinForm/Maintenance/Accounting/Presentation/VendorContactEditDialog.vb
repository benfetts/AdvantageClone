Namespace Maintenance.Accounting.Presentation

    Public Class VendorContactEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _VendorCode As String = Nothing
        Private _VendorContactCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property VendorContactCode As String
            Get
                VendorContactCode = _VendorContactCode
            End Get
        End Property
        Private ReadOnly Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef VendorCode As String, ByRef VendorContactCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _VendorContactCode = VendorContactCode
            _VendorCode = VendorCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef VendorCode As String = Nothing, Optional ByRef VendorContactCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim VendorContactEditDialog As AdvantageFramework.Maintenance.Accounting.Presentation.VendorContactEditDialog = Nothing

            VendorContactEditDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.VendorContactEditDialog(VendorCode, VendorContactCode)

            ShowFormDialog = VendorContactEditDialog.ShowDialog()

            VendorContactCode = VendorContactEditDialog.VendorContactCode
            VendorCode = VendorContactEditDialog.VendorCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorContactEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            If _VendorCode <> "" AndAlso _VendorContactCode <> "" Then

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True

                ButtonItemActions_Save.SecurityEnabled = VendorContactControlForm_VendorContact.CanUserUpdate

                Me.ShowUnsavedChangesOnFormClosing = VendorContactControlForm_VendorContact.CanUserUpdate

            ElseIf _VendorCode <> "" Then

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            End If

            If VendorContactControlForm_VendorContact.LoadControl(_VendorCode, _VendorContactCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The vendor contact you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub VendorContactEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorContactEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorContactEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                If _VendorCode <> "" AndAlso _VendorContactCode <> "" Then

                    VendorContactControlForm_VendorContact.TextBoxControl_Title.Focus()

                ElseIf _VendorCode <> "" Then

                    VendorContactControlForm_VendorContact.TextBoxControl_Code.Focus()

                Else

                    VendorContactControlForm_VendorContact.SearchableComboBoxControl_ContactType.Focus()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim VendorContactCode As String = ""
            Dim VendorCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                Try

                    VendorContactControlForm_VendorContact.Insert(VendorCode, VendorContactCode)

                    _VendorCode = VendorCode
                    _VendorContactCode = VendorContactCode

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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

                    VendorContactControlForm_VendorContact.Save()

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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

#End Region

#End Region

    End Class

End Namespace