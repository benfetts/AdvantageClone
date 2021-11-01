Namespace Media.Presentation

    Public Class MediaManagerProcessGeneratePurchaseOrdersDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerProcessGeneratePurchaseOrderViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaManagerProcessGeneratePurchaseOrderController = Nothing
        Protected _MediaManagerGeneratePurchaseOrders As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaManagerGeneratePurchaseOrders As Generic.List(Of DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaManagerGeneratePurchaseOrders = MediaManagerGeneratePurchaseOrders

        End Sub
        Private Sub SetColumnVisibility()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_VendorContacts.CurrentView.Columns

                Select Case GridColumn.FieldName

                    Case AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact.Properties.Process.ToString

                        GridColumn.VisibleIndex = 0

                    Case AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact.Properties.DefaultCorrespondenceMethod.ToString

                        GridColumn.VisibleIndex = 1

                    Case AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact.Properties.VendorName.ToString

                        GridColumn.VisibleIndex = 2

                    Case AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact.Properties.VendorContactName.ToString

                        GridColumn.VisibleIndex = 3

                    Case AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact.Properties.VendorContactEmail.ToString

                        GridColumn.VisibleIndex = 4

                    Case AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact.Properties.PONumber.ToString

                        GridColumn.VisibleIndex = 5

                    Case Else

                        GridColumn.Visible = False

                End Select

            Next

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load(_MediaManagerGeneratePurchaseOrders)

        End Sub
        Private Sub RefreshViewModel()

            DataGridViewForm_VendorContacts.DataSource = _ViewModel.MediaManagerGeneratePurchaseOrderVendorContacts

            DataGridViewForm_VendorContacts.CurrentView.ClearSorting()
            DataGridViewForm_VendorContacts.CurrentView.BeginSort()
            DataGridViewForm_VendorContacts.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact.Properties.PONumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            DataGridViewForm_VendorContacts.CurrentView.EndSort()

            DataGridViewForm_VendorContacts.CurrentView.BestFitColumns()

            SetColumnVisibility()

            TextBoxForm_Subject.Text = _ViewModel.DefaultEmailSubject
            TextBoxForm_Body.Text = _ViewModel.DefaultEmailBody
            CheckBoxForm_CCToSender.Checked = _ViewModel.DefaultCCSender
            ButtonItemOptions_SendToDocumentManager.Checked = _ViewModel.DefaultUploadDocumentManager
            ButtonItemOptions_UploadAndSignDocumentWhenSubmitted.Checked = _ViewModel.DefaultUploadAndSignDocumentWhenSubmitted
            ButtonItemOptions_EmailExecutedCopyToVendor.Checked = _ViewModel.DefaultEmailExecutedCopyToVendor

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.DefaultEmailSubject = TextBoxForm_Subject.Text
            _ViewModel.DefaultEmailBody = TextBoxForm_Body.Text
            _ViewModel.DefaultCCSender = CheckBoxForm_CCToSender.Checked
            _ViewModel.DefaultUploadDocumentManager = ButtonItemOptions_SendToDocumentManager.Checked
            _ViewModel.DefaultUploadAndSignDocumentWhenSubmitted = ButtonItemOptions_UploadAndSignDocumentWhenSubmitted.Checked
            _ViewModel.DefaultEmailExecutedCopyToVendor = ButtonItemOptions_EmailExecutedCopyToVendor.Checked

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaManagerGeneratePurchaseOrders As Generic.List(Of DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerProcessGeneratePurchaseOrdersDialog As MediaManagerProcessGeneratePurchaseOrdersDialog = Nothing

            MediaManagerProcessGeneratePurchaseOrdersDialog = New MediaManagerProcessGeneratePurchaseOrdersDialog(MediaManagerGeneratePurchaseOrders)

            ShowFormDialog = MediaManagerProcessGeneratePurchaseOrdersDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerProcessGeneratePurchaseOrdersDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDefaultEmailSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemDefaultEmailSettings_Save.Enabled = False

            ButtonItemOptions_SendToDocumentManager.Image = AdvantageFramework.My.Resources.DocumentManagerImage
            ButtonItemOptions_UploadAndSignDocumentWhenSubmitted.Image = AdvantageFramework.My.Resources.DocumentCheckImage
            ButtonItemOptions_EmailExecutedCopyToVendor.Image = AdvantageFramework.My.Resources.EmailPersonImage

            DataGridViewForm_VendorContacts.ItemDescription = "Vendor Contact(s)"
            DataGridViewForm_VendorContacts.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
            DataGridViewForm_VendorContacts.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact))

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            _Controller = New AdvantageFramework.Controller.Media.MediaManagerProcessGeneratePurchaseOrderController(Me.Session)

        End Sub
        Private Sub MediaManagerProcessGeneratePurchaseOrdersDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Process.Click

            'objects
            Dim Processed As Boolean = False
            Dim MediaManagerGeneratePurchaseOrderVendorContacts As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact) = Nothing
            Dim AtLeastOneEmailFailed As Boolean = False

            DataGridViewForm_VendorContacts.CurrentView.CloseEditorForUpdating()

            If ButtonItemDefaultEmailSettings_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("Would you like to save your email settings?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    SaveViewModel()

                    _Controller.Save(_ViewModel)

                End If

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Printing
            Me.ShowWaitForm("Processing...")

            MediaManagerGeneratePurchaseOrderVendorContacts = DataGridViewForm_VendorContacts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact).ToList

            Processed = AdvantageFramework.Reporting.Reports.ProcessGeneratePurchaseOrders(Me.Session, _ViewModel.MediaManagerGeneratePurchaseOrderVendorContacts, Me.DefaultLookAndFeel.LookAndFeel, TextBoxForm_Subject.GetText,
                                                                                           TextBoxForm_Body.GetText, CheckBoxForm_CCToSender.Checked, ButtonItemOptions_SendToDocumentManager.Checked, AtLeastOneEmailFailed)

            If Processed Then

                If AtLeastOneEmailFailed Then

                    AdvantageFramework.WinForm.MessageBox.Show("Generate Purchase Orders Successful - however one or more emails failed to send.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Generate Purchase Orders Successful.")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Generate Purchase Orders Cancelled.")

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None
            Me.CloseWaitForm()

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemDefaultEmailSettings_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemDefaultEmailSettings_Save.Click

            SaveViewModel()

            _Controller.Save(_ViewModel)

            ButtonItemDefaultEmailSettings_Save.Enabled = False

        End Sub
        Private Sub TextBoxForm_Subject_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_Subject.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub TextBoxForm_Body_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_Body.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub CheckBoxForm_CCToSender_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_CCToSender.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemOptions_EmailExecutedCopyToVendor_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_EmailExecutedCopyToVendor.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemOptions_SendToDocumentManager_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_SendToDocumentManager.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemOptions_UploadAndSignDocumentWhenSubmitted_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_UploadAndSignDocumentWhenSubmitted.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub DataGridViewForm_VendorContacts_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_VendorContacts.CustomColumnDisplayTextEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact.Properties.DefaultCorrespondenceMethod.ToString Then

                If e.Value = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email Then

                    e.DisplayText = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email.ToString

                ElseIf e.Value = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print Then

                    e.DisplayText = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print.ToString

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_VendorContacts_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_VendorContacts.ShowingEditorEvent

            If DataGridViewForm_VendorContacts.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact.Properties.Process.ToString Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace