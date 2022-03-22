Namespace Maintenance.Accounting.Presentation

    Public Class VendorEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _VendorCode As String = Nothing
        Private _LockVendorSelection As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef VendorCode As String, LockVendorSelection As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _VendorCode = VendorCode
            _LockVendorSelection = LockVendorSelection

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            RibbonBarOptions_Contacts.Visible = VendorControlForm_Vendor.IsContactsTabSelected
            RibbonBarOptions_Pricings.Visible = VendorControlForm_Vendor.IsPricingsTabSelected
            ButtonItemContacts_Delete.Enabled = VendorControlForm_Vendor.VendorContactsGrid.HasOnlyOneSelectedRow
            ButtonItemContacts_Edit.Enabled = VendorControlForm_Vendor.VendorContactsGrid.HasOnlyOneSelectedRow
            RibbonBarOptions_Representatives.Visible = VendorControlForm_Vendor.IsRepresentativesTabSelected
            ButtonItemRepresentatives_Delete.Enabled = VendorControlForm_Vendor.VendorRepresentativesGrid.HasOnlyOneSelectedRow
            ButtonItemRepresentatives_Edit.Enabled = VendorControlForm_Vendor.VendorRepresentativesGrid.HasOnlyOneSelectedRow
            RibbonBarOptions_MediaSpecs.Visible = VendorControlForm_Vendor.IsMediaSpecsTabSelected
            ButtonItemMediaSpecs_Add.Enabled = VendorControlForm_Vendor.CanAddNewMediaSpec
            ButtonItemMediaSpecs_Delete.Enabled = If(VendorControlForm_Vendor.TreeListControlMediaSpecs_MediaSpecs.Selection.Count = 1, True, False)
            ButtonItemPricings_Cancel.Enabled = VendorControlForm_Vendor.VendorPricingControlPricings_VendorPricings.IsNewItemRow
            ButtonItemPricings_Delete.Enabled = VendorControlForm_Vendor.VendorPricingControlPricings_VendorPricings.HasASelectedPricing

            RibbonBarOptions_Documents.Visible = VendorControlForm_Vendor.IsDocumentsTabSelected

            If RibbonBarOptions_Documents.Visible Then

                ButtonItemDocuments_Delete.Enabled = VendorControlForm_Vendor.DocumentManagerControlDocuments_VendorDocuments.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(VendorControlForm_Vendor.DocumentManagerControlDocuments_VendorDocuments.HasOnlyOneSelectedDocument, Not VendorControlForm_Vendor.DocumentManagerControlDocuments_VendorDocuments.IsSelectedDocumentAURL, VendorControlForm_Vendor.DocumentManagerControlDocuments_VendorDocuments.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(VendorControlForm_Vendor.DocumentManagerControlDocuments_VendorDocuments.HasOnlyOneSelectedDocument, VendorControlForm_Vendor.DocumentManagerControlDocuments_VendorDocuments.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = VendorControlForm_Vendor.DocumentManagerControlDocuments_VendorDocuments.CanUpload

            Else

                ButtonItemDocuments_Upload.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            If VendorControlForm_Vendor.IsDefaultsNotesTabSelected OrElse
                    VendorControlForm_Vendor.IsMediaInfoTabSelected OrElse
                    VendorControlForm_Vendor.IsMediaDeliveryTabSelected OrElse
                    VendorControlForm_Vendor.IsDefaultCommentsTabSelected Then

                RibbonBarOptions_CheckSpelling.Visible = True

            Else

                RibbonBarOptions_CheckSpelling.Visible = False

            End If

            RibbonBarOptions_ComboStations.Visible = VendorControlForm_Vendor.ShowManageComboRadioStations

        End Sub
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            VendorControlForm_Vendor.LoadRequiredNonGridControlsForValidation()

            If Me.Validator Then

                Me.ShowWaitForm("Saving...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                Try

                    If VendorControlForm_Vendor.Save() Then

                        Me.ClearChanged()

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                If ErrorMessage = "" Then

                    Saved = True

                End If

            Else

                For Each LastFailedValidationResult In SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef VendorCode As String = Nothing, Optional LockVendorSelection As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim VendorEditDialog As AdvantageFramework.Maintenance.Accounting.Presentation.VendorEditDialog = Nothing

            VendorEditDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.VendorEditDialog(VendorCode, LockVendorSelection)

            ShowFormDialog = VendorEditDialog.ShowDialog()

            VendorCode = VendorEditDialog.VendorCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_PrintFiltered.Image = AdvantageFramework.My.Resources.PrinterViewImage

            ButtonItemContacts_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemContacts_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemContacts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemRepresentatives_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemRepresentatives_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemRepresentatives_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemMediaSpecs_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemMediaSpecs_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemPricings_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemPricings_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemSpelling_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            ButtonItemComboStations_Manage.Image = AdvantageFramework.My.Resources.QuickManageImage

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                    ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                    ButtonItemDocuments_Upload.SplitButton = False

                End If

            End Using

            If _VendorCode <> "" Then

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True
                ButtonItemActions_Delete.Visible = True
                ButtonItemActions_Print.Visible = True

                ButtonItemActions_Save.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate
                ButtonItemActions_Delete.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate
                ButtonItemSpelling_CheckSpelling.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate
                ButtonItemContacts_Add.SecurityEnabled = VendorControlForm_Vendor.CanUserAddInVendorContact
                ButtonItemContacts_Delete.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdateInVendorContact
                ButtonItemRepresentatives_Add.SecurityEnabled = VendorControlForm_Vendor.CanUserAddInVendorRep
                ButtonItemRepresentatives_Delete.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdateInVendorRep
                ButtonItemMediaSpecs_Add.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate
                ButtonItemMediaSpecs_Delete.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate
                ButtonItemPricings_Cancel.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate
                ButtonItemPricings_Delete.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate
                ButtonItemDocuments_Delete.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate
                ButtonItemDocuments_Download.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate
                ButtonItemDocuments_OpenURL.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate
                ButtonItemDocuments_Upload.SecurityEnabled = VendorControlForm_Vendor.CanUserUpdate

                ButtonItemActions_Print.SecurityEnabled = VendorControlForm_Vendor.CanUserPrint
                ButtonItemActions_PrintFiltered.SecurityEnabled = VendorControlForm_Vendor.CanUserPrint

                Me.ShowUnsavedChangesOnFormClosing = VendorControlForm_Vendor.CanUserUpdate

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Delete.Visible = False
                ButtonItemActions_Print.Visible = False

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemDocuments_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            If VendorControlForm_Vendor.LoadControl(_VendorCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The vendor you are trying to edit does not exist anymore.")
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub VendorEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                VendorControlForm_Vendor.TextBoxMain_Code.Focus()

            End If

        End Sub
        Private Sub VendorEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            Dim VendorCode As String = Nothing
            Dim ErrorMessage As String = Nothing

            VendorControlForm_Vendor.UpdatePayToVendorCode()

            If Me.Validator Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                Try

                    If VendorControlForm_Vendor.Insert(VendorCode) Then

                        _VendorCode = VendorCode

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Else

                For Each LastFailedValidationResult In SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Deleting...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting

                Try

                    If VendorControlForm_Vendor.Delete Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            VendorControlForm_Vendor.LoadRequiredNonGridControlsForValidation()

            If Me.Validator Then

                Me.ShowWaitForm("Saving...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                Try

                    If VendorControlForm_Vendor.Save() Then

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
        Private Sub ButtonItemActions_Print_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Print.Click

            ' objects
            Dim SelectedVendorCodes() As String = Nothing

            If VendorControlForm_Vendor.Enabled Then

                SelectedVendorCodes = {VendorCode}

            End If

            AdvantageFramework.Maintenance.Accounting.Presentation.VendorReportsDialog.ShowFormDialog(Nothing, SelectedVendorCodes)

        End Sub
        'Private Sub ButtonItemActions_PrintFiltered_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintFiltered.Click

        '    'objects
        '    Dim SelectedAndAvailableVendorCodes() As String = Nothing

        '    Try

        '        SelectedAndAvailableVendorCodes = (From Entity In DataGridViewLeftSection_Vendors.GetAllRowsBookmarkValues.OfType(Of String)() _
        '                                           Select Entity).ToArray

        '    Catch ex As Exception
        '        SelectedAndAvailableVendorCodes = Nothing
        '    End Try

        '    AdvantageFramework.Maintenance.Accounting.Presentation.VendorReportsDialog.ShowFormDialog(SelectedAndAvailableVendorCodes, SelectedAndAvailableVendorCodes)

        'End Sub
        Private Sub ButtonItemContacts_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemContacts_Add.Click

            VendorControlForm_Vendor.AddVendorContact()

        End Sub
        Private Sub ButtonItemContacts_Edit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemContacts_Edit.Click

            VendorControlForm_Vendor.EditVendorContact()

        End Sub
        Private Sub ButtonItemContacts_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemContacts_Delete.Click

            VendorControlForm_Vendor.DeleteVendorContact()

        End Sub
        Private Sub ButtonItemRepresentatives_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemRepresentatives_Add.Click

            VendorControlForm_Vendor.AddVendorRepresentative(_LockVendorSelection)

        End Sub
        Private Sub ButtonItemRepresentatives_Edit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemRepresentatives_Edit.Click

            VendorControlForm_Vendor.EditVendorRepresentative(_LockVendorSelection)

        End Sub
        Private Sub ButtonItemRepresentatives_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemRepresentatives_Delete.Click

            VendorControlForm_Vendor.DeleteVendorRepresentative()

        End Sub
        Private Sub ButtonItemSpelling_CheckSpelling_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSpelling_CheckSpelling.Click

            VendorControlForm_Vendor.SpellCheckSelectedTab()

        End Sub
        Private Sub ButtonItemMediaSpecs_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemMediaSpecs_Delete.Click

            VendorControlForm_Vendor.DeleteSelectedMediaSpec()

        End Sub
        Private Sub ButtonItemMediaSpecs_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemMediaSpecs_Add.Click

            VendorControlForm_Vendor.AddMediaSpec()

        End Sub
        Private Sub VendorControlForm_Vendor_MediaSpecsChangedEvent() Handles VendorControlForm_Vendor.MediaSpecsChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub VendorControlForm_Vendor_SelectedDocumentChanged() Handles VendorControlForm_Vendor.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub VendorControlForm_Vendor_SelectedTabChanged() Handles VendorControlForm_Vendor.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub VendorControlForm_Vendor_VendorPricingsSelectionChangedEvent() Handles VendorControlForm_Vendor.VendorPricingsSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemPricings_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemPricings_Cancel.Click

            VendorControlForm_Vendor.CancelAddVendorPricing()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemPricings_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemPricings_Delete.Click

            VendorControlForm_Vendor.DeleteVendorPricing()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            VendorControlForm_Vendor.UploadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            VendorControlForm_Vendor.SendASPUploadEmail()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            VendorControlForm_Vendor.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            VendorControlForm_Vendor.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            VendorControlForm_Vendor.DeletedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub VendorControlForm_Vendor_ComboStationChangedEvent() Handles VendorControlForm_Vendor.ComboStationChangedEvent

            RibbonBarOptions_ComboStations.Visible = VendorControlForm_Vendor.ShowManageComboRadioStations

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemComboStations_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemComboStations_Manage.Click

            VendorControlForm_Vendor.ManageComboRadioStations()

        End Sub

#End Region

#End Region

    End Class

End Namespace
