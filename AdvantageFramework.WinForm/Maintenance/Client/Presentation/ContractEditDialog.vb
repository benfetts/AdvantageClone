Namespace Maintenance.Client.Presentation

    Public Class ContractEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ContractID As Integer = 0
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _IsCopy As Boolean = Nothing

#End Region

#Region " Properties "

        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property IsCopy As Boolean
            Get
                IsCopy = _IsCopy
            End Get
            Set(value As Boolean)
                _IsCopy = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef ClientCode As String, ByRef DivisionCode As String, ByRef ProductCode As String, ByRef ContractID As Integer, ByRef IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ContractID = ContractID
            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _IsCopy = IsCopy

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If _ContractID = 0 Then

                ButtonItemActions_Copy.Visible = False

            End If

            RibbonBarOptions_Documents.Visible = If(ContractControlForm_Contract.SelectedTab Is ContractControlForm_Contract.TabItemContractSetup_DocumentsTab, True, False)

            If RibbonBarOptions_Documents.Visible Then

                ButtonItemDocuments_Delete.Enabled = ContractControlForm_Contract.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(ContractControlForm_Contract.DocumentManager.HasOnlyOneSelectedDocument, Not ContractControlForm_Contract.DocumentManager.IsSelectedDocumentAURL, ContractControlForm_Contract.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(ContractControlForm_Contract.DocumentManager.HasOnlyOneSelectedDocument, ContractControlForm_Contract.DocumentManager.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = ContractControlForm_Contract.DocumentManager.CanUpload

            End If

            RibbonBarOptions_Contacts.Visible = If(ContractControlForm_Contract.SelectedTab Is ContractControlForm_Contract.TabItemContractSetup_InternalContactsTab, True, False)

            If RibbonBarOptions_Contacts.Visible Then

                ButtonItemInternalContacts_Cancel.Enabled = ContractControlForm_Contract.DataGridViewInternalContacts_Contacts.IsNewItemRow
                ButtonItemInternalContacts_Delete.Enabled = ContractControlForm_Contract.DataGridViewInternalContacts_Contacts.HasOnlyOneSelectedRow

            End If

            RibbonBarOptions_ContractFees.Visible = If(ContractControlForm_Contract.SelectedTab Is ContractControlForm_Contract.TabItemContractSetup_RatesTermsTab, True, False)

            If RibbonBarOptions_ContractFees.Visible Then

                ButtonItemContractFees_Cancel.Enabled = ContractControlForm_Contract.DataGridViewRateTerm_ContractFees.IsNewItemRow
                ButtonItemContractFees_Delete.Enabled = ContractControlForm_Contract.DataGridViewRateTerm_ContractFees.HasOnlyOneSelectedRow

            End If

            RibbonBarOptions_ValueAdded.Visible = False
            RibbonBarOptions_ValueAddedDocument.Visible = False
            RibbonBarOptions_ValueAdded.Visible = If(ContractControlForm_Contract.SelectedTab Is ContractControlForm_Contract.TabItemContractSetup_ValueAddedTab, True, False)

            If RibbonBarOptions_ValueAdded.Visible Then

                ButtonItemValueAdded_Cancel.Enabled = ContractControlForm_Contract.DataGridViewValueAdded_ValueAdded.IsNewItemRow
                ButtonItemValueAdded_Delete.Enabled = ContractControlForm_Contract.DataGridViewValueAdded_ValueAdded.HasOnlyOneSelectedRow

                If _ContractID <> 0 Then

                    RibbonBarOptions_ValueAddedDocument.Visible = ContractControlForm_Contract.HasAccessToValueAddedDocuments

                    If ContractControlForm_Contract.DataGridViewValueAdded_ValueAdded.HasOnlyOneSelectedRow Then

                        ButtonItemValueAddedDocument_Upload.Enabled = If(ContractControlForm_Contract.DataGridViewValueAdded_HasDocument, False, True)
                        ButtonItemValueAddedDocument_Delete.Enabled = If(ContractControlForm_Contract.DataGridViewValueAdded_HasDocument, True, False)
                        ButtonItemValueAddedDocument_OpenURL.Enabled = If(ContractControlForm_Contract.DataGridViewValueAdded_DocumentIsAURL, True, False)
                        ButtonItemValueAddedDocument_Download.Enabled = If(ContractControlForm_Contract.DataGridViewValueAdded_HasDocument AndAlso Not ContractControlForm_Contract.DataGridViewValueAdded_DocumentIsAURL, True, False)

                    Else

                        ButtonItemValueAddedDocument_Upload.Enabled = False
                        ButtonItemValueAddedDocument_Delete.Enabled = False
                        ButtonItemValueAddedDocument_OpenURL.Enabled = False
                        ButtonItemValueAddedDocument_Download.Enabled = False

                    End If

                End If

            End If

            RibbonBarOptions_ReportsDocument.Visible = False
            RibbonBarOptions_Reports.Visible = If(ContractControlForm_Contract.SelectedTab Is ContractControlForm_Contract.TabItemContractSetup_ReportsTab, True, False)

            If _ContractID <> 0 Then

                RibbonBarOptions_Filter.Visible = ContractControlForm_Contract.HasAccessToReportDocuments AndAlso ContractControlForm_Contract.SelectedTab Is ContractControlForm_Contract.TabItemContractSetup_ReportsDocumentsTab
                RibbonBarOptions_ReportsDocument.Visible = ContractControlForm_Contract.HasAccessToReportDocuments AndAlso ContractControlForm_Contract.SelectedTab Is ContractControlForm_Contract.TabItemContractSetup_ReportsDocumentsTab

                If RibbonBarOptions_ReportsDocument.Visible Then

                    ButtonItemReportsDocument_Delete.Enabled = ContractControlForm_Contract.DocumentManagerReports.HasOnlyOneSelectedDocument
                    ButtonItemReportsDocument_Download.Enabled = If(ContractControlForm_Contract.DocumentManagerReports.HasOnlyOneSelectedDocument, Not ContractControlForm_Contract.DocumentManagerReports.IsSelectedDocumentAURL, ContractControlForm_Contract.DocumentManagerReports.HasASelectedDocument)
                    ButtonItemReportsDocument_OpenURL.Enabled = If(ContractControlForm_Contract.DocumentManagerReports.HasOnlyOneSelectedDocument, ContractControlForm_Contract.DocumentManagerReports.IsSelectedDocumentAURL, False)
                    ButtonItemReportsDocument_Upload.Enabled = ContractControlForm_Contract.DataGridViewReports_Reports.HasOnlyOneSelectedRow AndAlso ContractControlForm_Contract.DocumentManagerReports.CanUpload

                End If

            End If

            If RibbonBarOptions_Reports.Visible Then

                ButtonItemReports_Cancel.Enabled = ContractControlForm_Contract.DataGridViewReports_Reports.IsNewItemRow
                ButtonItemReports_Delete.Enabled = ContractControlForm_Contract.DataGridViewReports_Reports.HasOnlyOneSelectedRow

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = ContractControlForm_Contract.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If ContractControlForm_Contract.Save() Then

                        Me.ClearChanged()

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

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
        Private Sub ShowSpellChecker(Visible As Boolean)

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = Visible

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ClientCode As String, Optional ByRef DivisionCode As String = Nothing, Optional ByRef ProductCode As String = Nothing, Optional ByVal ContractID As Integer = 0, Optional ByVal IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim ContractEditDialog As AdvantageFramework.Maintenance.Client.Presentation.ContractEditDialog = Nothing

            ContractEditDialog = New AdvantageFramework.Maintenance.Client.Presentation.ContractEditDialog(ClientCode, DivisionCode, ProductCode, ContractID, IsCopy)

            ShowFormDialog = ContractEditDialog.ShowDialog()

            ClientCode = ContractEditDialog.ClientCode
            DivisionCode = ContractEditDialog.DivisionCode
            ProductCode = ContractEditDialog.ProductCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ContractEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ContractEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
			ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

			ButtonItemInternalContacts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemInternalContacts_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemContractFees_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemContractFees_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemValueAdded_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemValueAdded_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemValueAddedDocument_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemValueAddedDocument_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemValueAddedDocument_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemValueAddedDocumentUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
			ButtonItemValueAddedDocument_OpenURL.Image = AdvantageFramework.My.Resources.Link

			ButtonItemReports_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemReports_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemReports_Documents.Image = AdvantageFramework.My.Resources.DocumentManagerImage

            ButtonItemReportsDocument_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemReportsDocument_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemReportsDocument_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemReportsDocumentUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
			ButtonItemReportsDocument_OpenURL.Image = AdvantageFramework.My.Resources.Link

			ButtonItemFilter_All.Image = AdvantageFramework.My.Resources.TableSelectedAllImage
			ButtonItemFilter_SelectedLineItem.Image = AdvantageFramework.My.Resources.TableSelectedRowImage

			ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

					ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
					ButtonItemDocuments_Upload.SplitButton = False
					ButtonItemValueAddedDocument_Upload.SubItems.Remove(ButtonItemValueAddedDocumentUpload_EmailLink)
					ButtonItemValueAddedDocument_Upload.SplitButton = False
					ButtonItemReportsDocument_Upload.SubItems.Remove(ButtonItemReportsDocumentUpload_EmailLink)
					ButtonItemReportsDocument_Upload.SplitButton = False

				End If

			End Using

			If _IsCopy OrElse _ContractID = 0 Then

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Delete.Visible = False

            ElseIf _ContractID <> 0 Then

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True
                ButtonItemActions_Delete.Visible = True

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Delete.Visible = False

            End If

            ButtonItemActions_Add.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance
            ButtonItemActions_Save.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance
            ButtonItemActions_Delete.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance
            ButtonItemActions_Copy.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance

            ButtonItemDocuments_Delete.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance
            ButtonItemDocuments_Upload.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance

            ButtonItemInternalContacts_Delete.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance

            ButtonItemContractFees_Delete.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance

            ButtonItemValueAdded_Delete.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance

            ButtonItemValueAddedDocument_Delete.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance
            ButtonItemValueAddedDocument_Upload.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance

            ButtonItemReports_Delete.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance

            ButtonItemReportsDocument_Delete.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance
            ButtonItemReportsDocument_Upload.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance

            ButtonItemText_CheckSpelling.SecurityEnabled = ContractControlForm_Contract.CanUserUpdateInClientMaintenance

            Me.ShowUnsavedChangesOnFormClosing = ContractControlForm_Contract.CanUserUpdateInClientMaintenance

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    ButtonItemDocuments_OpenURL.SecurityEnabled = False
                    ButtonItemValueAddedDocument_OpenURL.SecurityEnabled = False
                    ButtonItemReportsDocument_OpenURL.SecurityEnabled = False

                Else

                    ButtonItemDocuments_OpenURL.SecurityEnabled = True
                    ButtonItemValueAddedDocument_OpenURL.SecurityEnabled = True
                    ButtonItemReportsDocument_OpenURL.SecurityEnabled = True

                End If

            End Using

            ButtonItemFilter_All.Checked = False
            ButtonItemFilter_SelectedLineItem.Checked = True

            If ContractControlForm_Contract.LoadControl(_ClientCode, _DivisionCode, _ProductCode, _ContractID, _IsCopy) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The contract you are trying to edit does not exist anymore.")
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ContractEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If _ContractID = 0 Then

                ContractControlForm_Contract.TextBoxGeneral_Code.Focus()

            End If

        End Sub
        Private Sub ContractEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If ContractControlForm_Contract.Insert(ClientCode, DivisionCode, ProductCode) Then

                        _ClientCode = ClientCode
                        _DivisionCode = DivisionCode
                        _ProductCode = ProductCode

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
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            Dim ContractID As Integer = 0
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ContinueCopy As Boolean = Nothing

            ContinueCopy = CheckForUnsavedChanges()

            If ContinueCopy Then

                ClientCode = _ClientCode
                DivisionCode = _DivisionCode
                ProductCode = _ProductCode
                ContractID = _ContractID

                If AdvantageFramework.Maintenance.Client.Presentation.ContractEditDialog.ShowFormDialog(ClientCode, DivisionCode, ProductCode, ContractID, True) = Windows.Forms.DialogResult.OK Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                Try

                    If ContractControlForm_Contract.Delete Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            ContractControlForm_Contract.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            ContractControlForm_Contract.DownloadDocument()

            EnableOrDisableActions()

        End Sub
		Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

			ContractControlForm_Contract.UploadDocument()

			EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

			ContractControlForm_Contract.SendASPUploadEmail()

		End Sub
		Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            ContractControlForm_Contract.DeleteDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContractFees_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemContractFees_Cancel.Click

            ContractControlForm_Contract.CancelAddNewContractFee()

        End Sub
        Private Sub ButtonItemContractFees_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContractFees_Delete.Click

            ContractControlForm_Contract.DeleteSelectedContractFee()

        End Sub
        Private Sub ButtonItemReports_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemReports_Cancel.Click

            ContractControlForm_Contract.CancelAddNewReport()

        End Sub
        Private Sub ButtonItemReports_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemReports_Delete.Click

            ContractControlForm_Contract.DeleteSelectedReport()

        End Sub
        Private Sub ButtonItemReports_Documents_Click(sender As Object, e As EventArgs) Handles ButtonItemReports_Documents.Click

            ContractControlForm_Contract.LoadContractReportDocuments()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemValueAdded_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemValueAdded_Cancel.Click

            ContractControlForm_Contract.CancelAddNewValueAdded()

        End Sub
        Private Sub ButtonItemValueAdded_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemValueAdded_Delete.Click

            ContractControlForm_Contract.DeleteSelectedValueAdded()

        End Sub
        Private Sub ContractControlForm_Contract_BillingRateCommentGotFocusEvent(sender As Object, e As EventArgs) Handles ContractControlForm_Contract.BillingRateCommentGotFocusEvent

            ShowSpellChecker(True)

        End Sub
        Private Sub ContractControlForm_Contract_BillingRateCommentLostFocusEvent(sender As Object, e As EventArgs) Handles ContractControlForm_Contract.BillingRateCommentLostFocusEvent

            ShowSpellChecker(False)

        End Sub
        Private Sub ContractControlForm_Contract_BillingTermsGotFocusEvent(sender As Object, e As EventArgs) Handles ContractControlForm_Contract.BillingTermsGotFocusEvent

            ShowSpellChecker(True)

        End Sub
        Private Sub ContractControlForm_Contract_BillingTermsLostFocusEvent(sender As Object, e As EventArgs) Handles ContractControlForm_Contract.BillingTermsLostFocusEvent

            ShowSpellChecker(False)

        End Sub
        Private Sub ContractControlForm_Contract_ContractContactInitNewRowEvent() Handles ContractControlForm_Contract.ContractContactInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ContractControlForm_Contract_ContractContactSelectionChangedEvent() Handles ContractControlForm_Contract.ContractContactSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ContractControlForm_Contract_ContractFeesInitNewRowEvent() Handles ContractControlForm_Contract.ContractFeesInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ContractControlForm_Contract_ContractFeesSelectionChangedEvent() Handles ContractControlForm_Contract.ContractFeesSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ContractControlForm_Contract_ContractReportInitNewRowEvent() Handles ContractControlForm_Contract.ContractReportInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ContractControlForm_Contract_ContractReportSelectionChangedEvent() Handles ContractControlForm_Contract.ContractReportSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ContractControlForm_Contract_ContractValueAddedInitNewRowEvent() Handles ContractControlForm_Contract.ContractValueAddedInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ContractControlForm_Contract_ContractValueAddedSelectionChangedEvent() Handles ContractControlForm_Contract.ContractValueAddedSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ContractControlForm_Contract_EstimatingTermsGotFocusEvent(sender As Object, e As EventArgs) Handles ContractControlForm_Contract.EstimatingTermsGotFocusEvent

            ShowSpellChecker(True)

        End Sub
        Private Sub ContractControlForm_Contract_EstimatingTermsLostFocusEvent(sender As Object, e As EventArgs) Handles ContractControlForm_Contract.EstimatingTermsLostFocusEvent

            ShowSpellChecker(False)

        End Sub
        Private Sub ContractControlForm_Contract_InactiveChangedEvent(IsInactive As Boolean, ByRef Cancel As Boolean) Handles ContractControlForm_Contract.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso _ContractID <> 0 AndAlso Not _IsCopy Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub ContractControlForm_Contract_SelectedDocumentChanged() Handles ContractControlForm_Contract.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ContractControlForm_Contract_SelectedReportDocumentChanged() Handles ContractControlForm_Contract.SelectedReportDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ContractControlForm_Contract_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles ContractControlForm_Contract.SelectedTabChanging

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemInternalContacts_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemInternalContacts_Cancel.Click

            ContractControlForm_Contract.CancelAddNewContractContact()

        End Sub
        Private Sub ButtonItemInternalContacts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemInternalContacts_Delete.Click

            ContractControlForm_Contract.DeleteSelectedContractContact()

        End Sub
		Private Sub ButtonItemValueAddedDocument_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemValueAddedDocument_Upload.Click

			ContractControlForm_Contract.UploadValueAddedDocument()

			EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemValueAddedDocumentUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemValueAddedDocumentUpload_EmailLink.Click

			ContractControlForm_Contract.SendValueAddedDocumentASPUploadEmail()

		End Sub
		Private Sub ButtonItemValueAddedDocument_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemValueAddedDocument_Download.Click

            ContractControlForm_Contract.DownloadValueAddedDocument()

        End Sub

        Private Sub ButtonItemValueAddedDocument_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemValueAddedDocument_Delete.Click

            ContractControlForm_Contract.DeleteValueAddedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemValueAddedDocument_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemValueAddedDocument_OpenURL.Click

            ContractControlForm_Contract.DownloadValueAddedDocument()

        End Sub
		Private Sub ButtonItemReportsDocument_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemReportsDocument_Upload.Click

			'objects
			Dim DefaultDescription As String = ""

			If ContractControlForm_Contract.DataGridViewReports_Reports.HasASelectedRow Then

				DefaultDescription = DirectCast(ContractControlForm_Contract.DataGridViewReports_Reports.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Classes.ContractReportDetail).Description

			End If

			ContractControlForm_Contract.UploadReportDocument(DefaultDescription)

			EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemReportsDocumentUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemReportsDocumentUpload_EmailLink.Click

			'objects
			Dim DefaultDescription As String = ""

			If ContractControlForm_Contract.DataGridViewReports_Reports.HasASelectedRow Then

				DefaultDescription = DirectCast(ContractControlForm_Contract.DataGridViewReports_Reports.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Classes.ContractReportDetail).Description

			End If

			ContractControlForm_Contract.SendReportDocumentASPUploadEmail(DefaultDescription)

		End Sub
		Private Sub ButtonItemReportsDocument_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemReportsDocument_Download.Click

            ContractControlForm_Contract.DownloadReportDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemReportsDocument_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemReportsDocument_Delete.Click

            ContractControlForm_Contract.DeleteReportDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemReportsDocument_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemReportsDocument_OpenURL.Click

            ContractControlForm_Contract.DownloadReportDocument()

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf ContractControlForm_Contract.ActiveControl Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

                DirectCast(ContractControlForm_Contract.ActiveControl, AdvantageFramework.WinForm.Presentation.Controls.TextBox).CheckSpelling()

            End If

        End Sub
        Private Sub ButtonItemFilter_All_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_All.CheckedChanged

            If Me.FormShown AndAlso ButtonItemFilter_All.Checked Then

                ButtonItemFilter_SelectedLineItem.Checked = False

                ContractControlForm_Contract.FilterDocuments(True)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemFilter_SelectedLineItem_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_SelectedLineItem.CheckedChanged

            If Me.FormShown AndAlso ButtonItemFilter_SelectedLineItem.Checked Then

                ButtonItemFilter_All.Checked = False

                ContractControlForm_Contract.FilterDocuments(False)

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region
        
    End Class

End Namespace