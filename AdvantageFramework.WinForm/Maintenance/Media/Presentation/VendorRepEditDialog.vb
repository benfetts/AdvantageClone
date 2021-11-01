Namespace Maintenance.Media.Presentation

    Public Class VendorRepEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _VendorCode As String = Nothing
        Private _VendorRepCode As String = Nothing
        Private _LockVendorSelection As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property
        Private ReadOnly Property VendorRepCode As String
            Get
                VendorRepCode = _VendorRepCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef VendorCode As String, ByRef VendorRepCode As String, LockVendorSelection As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _VendorCode = VendorCode
            _VendorRepCode = VendorRepCode
            _LockVendorSelection = LockVendorSelection

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef VendorCode As String = Nothing, Optional ByRef VendorRepCode As String = Nothing, Optional LockVendorSelection As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim VendorRepEditDialog As AdvantageFramework.Maintenance.Media.Presentation.VendorRepEditDialog = Nothing

            VendorRepEditDialog = New AdvantageFramework.Maintenance.Media.Presentation.VendorRepEditDialog(VendorCode, VendorRepCode, LockVendorSelection)

            ShowFormDialog = VendorRepEditDialog.ShowDialog()

            VendorCode = VendorRepEditDialog.VendorCode
            VendorRepCode = VendorRepEditDialog.VendorRepCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorRepEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            If _VendorCode <> "" AndAlso _VendorRepCode <> "" Then

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True

                ButtonItemActions_Save.SecurityEnabled = VendorRepresentativeControlForm_VendorRep.CanUserUpdate

                Me.ShowUnsavedChangesOnFormClosing = VendorRepresentativeControlForm_VendorRep.CanUserUpdate

            ElseIf _VendorCode <> "" AndAlso _VendorRepCode Is Nothing Then

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False

            End If

            If VendorRepresentativeControlForm_VendorRep.LoadControl(_VendorCode, _VendorRepCode, _LockVendorSelection) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The vendor rep you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub VendorRepEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorRepEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorRepEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                If _VendorCode <> "" AndAlso _VendorRepCode <> "" Then

                    VendorRepresentativeControlForm_VendorRep.TextBoxSetup_FirmName.Focus()

                ElseIf _VendorCode <> "" AndAlso _VendorRepCode Is Nothing Then

                    VendorRepresentativeControlForm_VendorRep.TextBoxSetup_Code.Focus()

                Else

                    VendorRepresentativeControlForm_VendorRep.SearchableComboBoxSetup_Vendor.Focus()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim VendorCode As String = ""
            Dim VendorRepCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    VendorRepresentativeControlForm_VendorRep.Insert(VendorCode, VendorRepCode)

                    _VendorCode = VendorCode
                    _VendorRepCode = VendorRepCode

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    VendorRepresentativeControlForm_VendorRep.Save()

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace