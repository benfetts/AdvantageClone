Namespace Billing.Reports.Presentation

    Public Class InvoicePrintingAutoEmailDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Type
            JobComment
            JobFunctionComment
        End Enum

#End Region

#Region " Variables "

        Private _AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
		Private _EmailSettings As AdvantageFramework.InvoicePrinting.Classes.EmailSettings = Nothing
		Protected _ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions = InvoicePrinting.Methods.ToFileOptions.PDF

#End Region

#Region " Properties "

		Private ReadOnly Property EmailSettings As AdvantageFramework.InvoicePrinting.Classes.EmailSettings
            Get
                EmailSettings = _EmailSettings
            End Get
        End Property

#End Region

#Region " Methods "

		Private Sub New(AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
						ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions)

			' This call is required by the designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_AccountReceivableInvoices = AccountReceivableInvoices
			_ToFileOption = ToFileOption

		End Sub
		Private Sub SelectDeselectAllRows(IsEmail As Boolean, [Select] As Boolean)

            For Each AutoEmailContact In DataGridViewForm_Contacts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact).ToList

                If IsEmail Then

                    AutoEmailContact.Email = [Select]

                Else

                    AutoEmailContact.Print = [Select]

                End If

            Next

            DataGridViewForm_Contacts.CurrentView.RefreshData()

        End Sub
        Private Sub LoadAutoEmailContacts()

            'objects
            Dim AutoEmailContacts As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact) = Nothing
            Dim ClientAccountsReceivableStatements As Generic.List(Of AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement) = Nothing
            Dim ProductAccountsReceivableStatements As Generic.List(Of AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement) = Nothing
            Dim AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
            Dim ClientCodes() As String = Nothing

            Try

                For Each GridColumn In DataGridViewForm_Contacts.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridColumn.Visible = False

                Next

            Catch ex As Exception

            End Try

            Try

                If ButtonItemOptions_SendToProductContact.Checked = False Then

                    Try

                        ClientCodes = _AccountReceivableInvoices.Select(Function(ARI) ARI.ClientCode).Distinct.ToArray

                    Catch ex As Exception
                        ClientCodes = Nothing
                    End Try

                    If ClientCodes IsNot Nothing AndAlso ClientCodes.Count > 0 Then

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                ClientAccountsReceivableStatements = AdvantageFramework.Database.Procedures.ClientAccountsReceivableStatement.Load(DbContext).Include("ClientContact").Where(Function(Entity) ClientCodes.Contains(Entity.ClientCode)).ToList

                            End Using

                        Catch ex As Exception
                            ClientAccountsReceivableStatements = Nothing
                        End Try

                        If ClientAccountsReceivableStatements IsNot Nothing Then

                            AutoEmailContacts = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact)

                            For Each ClientAccountsReceivableStatement In ClientAccountsReceivableStatements

                                Try

                                    AccountReceivableInvoice = _AccountReceivableInvoices.FirstOrDefault(Function(Entity) Entity.ClientCode = ClientAccountsReceivableStatement.ClientCode AndAlso Entity.RecordType <> "P")

                                Catch ex As Exception
                                    AccountReceivableInvoice = Nothing
                                End Try

                                If AccountReceivableInvoice IsNot Nothing Then

                                    AutoEmailContacts.Add(New AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact(ClientAccountsReceivableStatement, AccountReceivableInvoice))

                                End If

                                Try

                                    AccountReceivableInvoice = _AccountReceivableInvoices.FirstOrDefault(Function(Entity) Entity.ClientCode = ClientAccountsReceivableStatement.ClientCode AndAlso Entity.RecordType = "P")

                                Catch ex As Exception
                                    AccountReceivableInvoice = Nothing
                                End Try

                                If AccountReceivableInvoice IsNot Nothing Then

                                    AutoEmailContacts.Add(New AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact(ClientAccountsReceivableStatement, AccountReceivableInvoice))

                                End If

                            Next

                        End If

                    End If

                Else

                    Try

                        ClientCodes = _AccountReceivableInvoices.Select(Function(ARI) ARI.ClientCode & "|" & ARI.DivisionCode & "|" & ARI.ProductCode).Distinct.ToArray

                    Catch ex As Exception
                        ClientCodes = Nothing
                    End Try

                    If ClientCodes IsNot Nothing AndAlso ClientCodes.Count > 0 Then

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                ProductAccountsReceivableStatements = AdvantageFramework.Database.Procedures.ProductAccountsReceivableStatement.Load(DbContext).Include("ClientContact").Where(Function(Entity) ClientCodes.Contains(Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode)).ToList

                            End Using

                        Catch ex As Exception
                            ProductAccountsReceivableStatements = Nothing
                        End Try

                        If ProductAccountsReceivableStatements IsNot Nothing Then

                            AutoEmailContacts = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact)

                            For Each ProductAccountsReceivableStatement In ProductAccountsReceivableStatements

                                Try

                                    AccountReceivableInvoice = _AccountReceivableInvoices.FirstOrDefault(Function(Entity) Entity.ClientCode = ProductAccountsReceivableStatement.ClientCode AndAlso
                                                                                                                          Entity.DivisionCode = ProductAccountsReceivableStatement.DivisionCode AndAlso
                                                                                                                          Entity.ProductCode = ProductAccountsReceivableStatement.ProductCode AndAlso
                                                                                                                          Entity.RecordType <> "P")

                                Catch ex As Exception
                                    AccountReceivableInvoice = Nothing
                                End Try

                                If AccountReceivableInvoice IsNot Nothing Then

                                    AutoEmailContacts.Add(New AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact(ProductAccountsReceivableStatement, AccountReceivableInvoice))

                                End If

                                Try

                                    AccountReceivableInvoice = _AccountReceivableInvoices.FirstOrDefault(Function(Entity) Entity.ClientCode = ProductAccountsReceivableStatement.ClientCode AndAlso
                                                                                                                          Entity.DivisionCode = ProductAccountsReceivableStatement.DivisionCode AndAlso
                                                                                                                          Entity.ProductCode = ProductAccountsReceivableStatement.ProductCode AndAlso
                                                                                                                          Entity.RecordType = "P")

                                Catch ex As Exception
                                    AccountReceivableInvoice = Nothing
                                End Try

                                If AccountReceivableInvoice IsNot Nothing Then

                                    AutoEmailContacts.Add(New AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact(ProductAccountsReceivableStatement, AccountReceivableInvoice))

                                End If

                            Next

                        End If

                    End If

                End If

            Catch ex As Exception
                AutoEmailContacts = Nothing
            End Try

            If AutoEmailContacts Is Nothing Then

                AutoEmailContacts = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact)

            End If

            DataGridViewForm_Contacts.DataSource = AutoEmailContacts.OrderBy(Function(Entity) Entity.ClientCode).ThenBy(Function(Entity) Entity.ClientContactCode).ToList

            Try

                For Each GridColumn In DataGridViewForm_Contacts.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridColumn.Visible = False

                Next

            Catch ex As Exception

            End Try

            DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.ClientCode.ToString)
            DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.ClientName.ToString)

            If ButtonItemOptions_SendToProductContact.Checked Then

                DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.DivisionCode.ToString)
                DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.DivisionName.ToString)
                DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.ProductCode.ToString)
                DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.ProductName.ToString)

            Else

                DataGridViewForm_Contacts.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.DivisionCode.ToString)
                DataGridViewForm_Contacts.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.DivisionName.ToString)
                DataGridViewForm_Contacts.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.ProductCode.ToString)
                DataGridViewForm_Contacts.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.ProductName.ToString)

            End If

            DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.ClientContactCode.ToString)
            DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.ClientContactName.ToString)
            DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.Type.ToString)
            DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.ContactTypeID.ToString)
            DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.Email.ToString)
            DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.Print.ToString)
            DataGridViewForm_Contacts.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact.Properties.EmailAddress.ToString)

            DataGridViewForm_Contacts.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
											  ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
											  ByRef EmailSettings As AdvantageFramework.InvoicePrinting.Classes.EmailSettings) As System.Windows.Forms.DialogResult

			'objects
			Dim InvoicePrintingAutoEmailDialog As InvoicePrintingAutoEmailDialog = Nothing

			InvoicePrintingAutoEmailDialog = New InvoicePrintingAutoEmailDialog(AccountReceivableInvoices, ToFileOption)

			ShowFormDialog = InvoicePrintingAutoEmailDialog.ShowDialog()

			If ShowFormDialog = Windows.Forms.DialogResult.OK Then

				EmailSettings = InvoicePrintingAutoEmailDialog.EmailSettings

			End If

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub InvoicePrintingAutoEmailDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim PackageType As AdvantageFramework.InvoicePrinting.PackageTypes = AdvantageFramework.InvoicePrinting.PackageTypes.None
            Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing

            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDefaultEmailSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemDefaultEmailSettings_Save.Enabled = False

            ButtonItemOptions_SendToDocumentManager.Image = AdvantageFramework.My.Resources.DocumentManagerImage
            ButtonItemOptions_IncludeCoverSheet.Image = AdvantageFramework.My.Resources.CoverSheetImage
            ButtonItemOptions_SendToProductContact.Image = AdvantageFramework.My.Resources.ProductImage
            ButtonItemOptions_SendSingleEmail.Image = AdvantageFramework.My.Resources.EmailSendImage

            DataGridViewForm_Contacts.ItemDescription = "Contact(s)"

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                DataContext.Connection.Open()

                TextBoxForm_Subject.Text = AdvantageFramework.InvoicePrinting.LoadDefaultEmailSubject(DataContext)
                TextBoxForm_Body.Text = AdvantageFramework.InvoicePrinting.LoadDefaultEmailBody(DataContext)
                ButtonItemOptions_SendToDocumentManager.Checked = AdvantageFramework.InvoicePrinting.LoadDefaultUploadDocumentManager(DataContext)
                ButtonItemOptions_IncludeCoverSheet.Checked = AdvantageFramework.InvoicePrinting.LoadDefaultIncludeCoverSheet(DataContext)
                ButtonItemOptions_SendToProductContact.Checked = AdvantageFramework.InvoicePrinting.LoadDefaultEmailProductContact(DataContext)
                CheckBoxForm_CCToSender.Checked = AdvantageFramework.InvoicePrinting.LoadDefaultCCSender(DataContext)
                ButtonItemOptions_SendSingleEmail.Checked = AdvantageFramework.InvoicePrinting.LoadDefaultSendSingleEmail(DataContext)

                PackageType = AdvantageFramework.InvoicePrinting.LoadDefaultPackageType(DataContext)

                If PackageType = InvoicePrinting.Methods.PackageTypes.OneZip Then

					ButtonItemPackageOptions_OneZip.Checked = True
                    ButtonItemPackageOptions_OneZipPerInvoice.Checked = False
                    ButtonItemPackageOptions_SinglePDF.Checked = AdvantageFramework.InvoicePrinting.LoadDefaultSinglePDF(DataContext)

				ElseIf PackageType = InvoicePrinting.Methods.PackageTypes.OneZipPerInvoice Then

					ButtonItemPackageOptions_OneZip.Checked = False
                    ButtonItemPackageOptions_OneZipPerInvoice.Checked = True
                    ButtonItemPackageOptions_SinglePDF.Checked = False

				ElseIf PackageType = InvoicePrinting.Methods.PackageTypes.None Then

					ButtonItemPackageOptions_OneZip.Checked = False
                    ButtonItemPackageOptions_OneZipPerInvoice.Checked = False
                    ButtonItemPackageOptions_SinglePDF.Checked = AdvantageFramework.InvoicePrinting.LoadDefaultSinglePDF(DataContext)

				End If

                If ButtonItemPackageOptions_SinglePDF.Checked Then

                    ButtonItemOptions_SendToDocumentManager.Checked = False
                    ButtonItemOptions_SendToDocumentManager.Enabled = False

                Else

                    ButtonItemOptions_SendToDocumentManager.Enabled = True

                End If

            End Using

			If _ToFileOption = InvoicePrinting.Methods.ToFileOptions.PDF Then

				ButtonItemPackageOptions_SinglePDF.Visible = True

			Else

				ButtonItemPackageOptions_SinglePDF.Visible = False

			End If

            LoadAutoEmailContacts()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub InvoicePrintingAutoEmailDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            RibbonBarOptions_Options.ResetCachedContentSize()
            RibbonBarOptions_Options.Refresh()
            RibbonBarOptions_Options.Width = RibbonBarOptions_Options.GetAutoSizeWidth
            RibbonBarOptions_Options.Refresh()

            If DataGridViewForm_Contacts.HasRows = False Then

                AdvantageFramework.WinForm.MessageBox.Show("No contacts available.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Process.Click

            'objects
            Dim Process As Boolean = True
            Dim AutoEmailContact As AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact = Nothing
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
            Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DefaultFileName As String = Nothing
            Dim DefaultBackupFileName As String = Nothing
            Dim ReportBytes() As Byte = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ErrorMessage As String = ""

            DataGridViewForm_Contacts.CurrentView.CloseEditorForUpdating()

            If ButtonItemDefaultEmailSettings_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("Would you like to save your email settings?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        AdvantageFramework.InvoicePrinting.SaveDefaultEmailSubject(DataContext, TextBoxForm_Subject.Text)
                        AdvantageFramework.InvoicePrinting.SaveDefaultEmailBody(DataContext, TextBoxForm_Body.Text)
                        AdvantageFramework.InvoicePrinting.SaveDefaultUploadDocumentManager(DataContext, ButtonItemOptions_SendToDocumentManager.Checked)
                        AdvantageFramework.InvoicePrinting.SaveDefaultIncludeCoverSheet(DataContext, ButtonItemOptions_IncludeCoverSheet.Checked)
                        AdvantageFramework.InvoicePrinting.SaveDefaultCCSender(DataContext, CheckBoxForm_CCToSender.Checked)
                        AdvantageFramework.InvoicePrinting.SaveDefaultSendSingleEmail(DataContext, ButtonItemOptions_SendSingleEmail.Checked)

                        If ButtonItemPackageOptions_OneZip.Checked Then

                            AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, InvoicePrinting.PackageTypes.OneZip)

                        ElseIf ButtonItemPackageOptions_OneZipPerInvoice.Checked Then

                            AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, InvoicePrinting.PackageTypes.OneZipPerInvoice)

                        Else

                            AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, InvoicePrinting.PackageTypes.None)

                        End If

						AdvantageFramework.InvoicePrinting.SaveDefaultSinglePDF(DataContext, ButtonItemPackageOptions_SinglePDF.Checked)

					End Using

                    ButtonItemDefaultEmailSettings_Save.Enabled = False

                End If

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ButtonItemOptions_SendToDocumentManager.Checked Then

                    If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) = False Then

                        Process = False

                    End If

                End If

            End Using

            If Process Then

                _EmailSettings = New AdvantageFramework.InvoicePrinting.Classes.EmailSettings

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    _EmailSettings.SenderName = AdvantageFramework.InvoicePrinting.LoadDefaultSenderName(DataContext)
                    _EmailSettings.FromEmail = AdvantageFramework.InvoicePrinting.LoadDefaultFromEmail(DataContext)
                    _EmailSettings.ReplyTo = AdvantageFramework.InvoicePrinting.LoadDefaultReplyTo(DataContext)

                End Using

                _EmailSettings.Subject = TextBoxForm_Subject.Text
                _EmailSettings.Body = TextBoxForm_Body.Text

                _EmailSettings.AutoEmailContacts = DataGridViewForm_Contacts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact).ToList
                _EmailSettings.SendToDocumentManager = ButtonItemOptions_SendToDocumentManager.Checked
                _EmailSettings.IncludeCoverSheet = ButtonItemOptions_IncludeCoverSheet.Checked
                _EmailSettings.IncludeAPDocuments = CheckBoxItemInclude_APDocuments.Checked
                _EmailSettings.IncludeExpenseReportReceipts = CheckBoxItemInclude_ExpenseDocuments.Checked

                If ButtonItemPackageOptions_OneZip.Checked Then

                    _EmailSettings.PackageType = InvoicePrinting.PackageTypes.OneZip

                ElseIf ButtonItemPackageOptions_OneZipPerInvoice.Checked Then

                    _EmailSettings.PackageType = InvoicePrinting.PackageTypes.OneZipPerInvoice

                Else

                    _EmailSettings.PackageType = InvoicePrinting.PackageTypes.None

                End If

				_EmailSettings.SinglePDF = ButtonItemPackageOptions_SinglePDF.Checked

				_EmailSettings.CCToSender = CheckBoxForm_CCToSender.Checked
                _EmailSettings.SendSingleEmail = ButtonItemOptions_SendSingleEmail.Checked

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage & " Uncheck Send to Document Repository and try again.")

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemDefaultEmailSettings_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemDefaultEmailSettings_Save.Click

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.InvoicePrinting.SaveDefaultEmailSubject(DataContext, TextBoxForm_Subject.Text)
                AdvantageFramework.InvoicePrinting.SaveDefaultEmailBody(DataContext, TextBoxForm_Body.Text)
                AdvantageFramework.InvoicePrinting.SaveDefaultUploadDocumentManager(DataContext, ButtonItemOptions_SendToDocumentManager.Checked)
                AdvantageFramework.InvoicePrinting.SaveDefaultIncludeCoverSheet(DataContext, ButtonItemOptions_IncludeCoverSheet.Checked)
                AdvantageFramework.InvoicePrinting.SaveDefaultCCSender(DataContext, CheckBoxForm_CCToSender.Checked)
                AdvantageFramework.InvoicePrinting.SaveDefaultSendSingleEmail(DataContext, ButtonItemOptions_SendSingleEmail.Checked)

                If ButtonItemPackageOptions_OneZip.Checked Then

                    AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, InvoicePrinting.PackageTypes.OneZip)

                ElseIf ButtonItemPackageOptions_OneZipPerInvoice.Checked Then

                    AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, InvoicePrinting.PackageTypes.OneZipPerInvoice)

                Else

                    AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, InvoicePrinting.PackageTypes.None)

                End If

				AdvantageFramework.InvoicePrinting.SaveDefaultSinglePDF(DataContext, ButtonItemPackageOptions_SinglePDF.Checked)

			End Using

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
        Private Sub ButtonItemOptions_SendToDocumentManager_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_SendToDocumentManager.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemOptions_IncludeCoverSheet_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_IncludeCoverSheet.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub CheckBoxForm_CCToSender_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_CCToSender.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemOptions_SendSingleEmail_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOptions_SendSingleEmail.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemPackageOptions_OneZip_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemPackageOptions_OneZip.CheckedChanged

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

				If ButtonItemPackageOptions_OneZip.Checked Then

                    ButtonItemPackageOptions_OneZipPerInvoice.Checked = False

                End If

				ButtonItemDefaultEmailSettings_Save.Enabled = True

			End If

		End Sub
		Private Sub ButtonItemPackageOptions_OneZipPerInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemPackageOptions_OneZipPerInvoice.CheckedChanged

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

				If ButtonItemPackageOptions_OneZipPerInvoice.Checked Then

                    ButtonItemPackageOptions_OneZip.Checked = False
                    ButtonItemPackageOptions_SinglePDF.Checked = False

                End If

				ButtonItemDefaultEmailSettings_Save.Enabled = True

			End If

		End Sub
		Private Sub ButtonItemPackageOptions_SinglePDF_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemPackageOptions_SinglePDF.CheckedChanged

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemPackageOptions_SinglePDF.Checked Then

                    ButtonItemPackageOptions_OneZipPerInvoice.Checked = False
                    ButtonItemOptions_SendToDocumentManager.Checked = False
                    ButtonItemOptions_SendToDocumentManager.Enabled = False

                Else

                    ButtonItemOptions_SendToDocumentManager.Enabled = True

                End If

                ButtonItemDefaultEmailSettings_Save.Enabled = True

			End If

		End Sub
		Private Sub ButtonItemQuickSelection_SelectAllEmail_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickSelection_SelectAllEmail.Click

			Me.FormAction = WinForm.Presentation.FormActions.Modifying
			Me.ShowWaitForm("Processing...")

			Try

				SelectDeselectAllRows(True, True)

			Catch ex As Exception

			End Try

			Me.FormAction = WinForm.Presentation.FormActions.None
			Me.CloseWaitForm()

		End Sub
		Private Sub ButtonItemQuickSelection_DeselectAllEmail_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickSelection_DeselectAllEmail.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying
            Me.ShowWaitForm("Processing...")

            Try

                SelectDeselectAllRows(True, False)

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemQuickSelection_SelectAllPrint_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickSelection_SelectAllPrint.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying
            Me.ShowWaitForm("Processing...")

            Try

                SelectDeselectAllRows(False, True)

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemQuickSelection_DeselectAllPrint_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickSelection_DeselectAllPrint.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying
            Me.ShowWaitForm("Processing...")

            Try

                SelectDeselectAllRows(False, False)

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemOptions_SendToProductContact_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOptions_SendToProductContact.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Loading)

                LoadAutoEmailContacts()

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace