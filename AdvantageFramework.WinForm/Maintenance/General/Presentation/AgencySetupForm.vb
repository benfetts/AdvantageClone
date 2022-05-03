Namespace Maintenance.General.Presentation

    Public Class AgencySetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Private _LimitAPTransactionsOptionEnabled As Boolean = False
        'Private _CreateInterCompanyTransactionOptionEnabled As Boolean = False
        Private _Agency As AdvantageFramework.Database.Entities.Agency = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadAgency(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            If TabItem Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    _Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                End Using

                For Each TabItem In TabControlForm_AgencySetup.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                    TabItem.Tag = False

                Next

                TabItem = TabControlForm_AgencySetup.SelectedTab

            End If

            If TabItem.Tag = False Then

                If TabItem Is TabItemAgencySetup_InformationTab Then

                    LoadInformationTab(_Agency)

                End If

                If TabItem Is TabItemAgencySetup_SystemAndAlertOptions Then

                    LoadSystemAndAlertsTab(_Agency)

                End If

                If TabItem Is TabItemAgencySetup_ProductionOptionsTab Then

                    LoadProductionOptionsTab(_Agency)

                End If

                If TabItem Is TabItemAgencySetup_AccountingOptionsTab Then

                    LoadAccountingOptionsTab(_Agency)

                End If

                If TabItem Is TabItemAgencySetup_TimesheetOptionsTab Then

                    LoadTimesheetOptionsTab(_Agency)

                End If

                If TabItem Is TabItemAgencySetup_MediaOptionsTab Then

                    LoadMediaOptionsTab(_Agency)

                End If

                If TabItem Is TabItemAgencySetup_RequiredFieldsTab Then

                    LoadRequiredFieldsTab(_Agency)

                End If

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub LoadInformationTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            Dim Location As System.Drawing.Point = Nothing
            Dim PhoneLabelLocation As System.Drawing.Point = Nothing
            Dim PhoneInputLocation As System.Drawing.Point = Nothing

            If Agency IsNot Nothing Then

                TextBoxAgencyInformation_Name.Text = Agency.Name
                TextBoxAgencyInformation_Phone.Text = Agency.Phone
                AddressControlAgencyInformation_Address.Address = Agency.Address
                AddressControlAgencyInformation_Address.Address2 = Agency.Address2
                AddressControlAgencyInformation_Address.City = Agency.City
                AddressControlAgencyInformation_Address.County = Agency.County
                AddressControlAgencyInformation_Address.State = Agency.State
                AddressControlAgencyInformation_Address.Zip = Agency.Zip
                AddressControlAgencyInformation_Address.Country = Agency.Country

                TabItemAgencySetup_InformationTab.Tag = True

            End If

        End Sub
        Private Sub LoadSystemAndAlertsTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            Dim AccessReportPath As String = Nothing
            Dim AccessReportTempPath As String = Nothing
            Dim WebvantageURL As String = Nothing
            Dim ClientPortalURL As String = Nothing
            Dim ProofingURL As String = Nothing
            Dim DotNetPath As String = Nothing
            Dim AgencyDotNetPath As String = Nothing
            Dim POP3EmailListenerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.POP3EmailListenerAccount) = Nothing
            Dim POP3AutomatedAssignmentAccounts As Generic.List(Of AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount) = Nothing
            Dim RepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit = Nothing

            If Agency IsNot Nothing Then

                ' Alert Options
                CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.CheckValue = Agency.ActivateSystemAlerts.GetValueOrDefault(0)
                CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.CheckValue = Agency.IncludeAlertGroups.GetValueOrDefault(0)
                CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.CheckValue = Agency.IncludeAttachmentsWithAlerts.GetValueOrDefault(0)
                CheckBoxAlertOptions_ExcludeAttachmentByDefault.CheckValue = Agency.ExcludeAttachmentByDefault.GetValueOrDefault(0)
                CheckBoxAlertOptions_EnableAlertNotification.CheckValue = Agency.EnableAlertNotification.GetValueOrDefault(0)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    AgencyDotNetPath = AdvantageFramework.Agency.GetDotNetFolder(DataContext)

                End Using

                Try

                    AccessReportPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessRptPath)

                Catch ex As Exception
                    AccessReportPath = Nothing
                End Try

                Try

                    AccessReportTempPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath)

                Catch ex As Exception
                    AccessReportTempPath = Nothing
                End Try

                Try

                    WebvantageURL = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.WebvantageURL)

                Catch ex As Exception
                    WebvantageURL = Nothing
                End Try

                Try

                    ClientPortalURL = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.ClientPortalURL)

                Catch ex As Exception
                    ClientPortalURL = Nothing
                End Try

                Try

                    DotNetPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.DotNetPath)

                Catch ex As Exception
                    DotNetPath = Nothing
                End Try

                Try

                    ProofingURL = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.ProofingURL)

                Catch ex As Exception
                    ProofingURL = Nothing
                End Try

                'Webvantage URL
                RadioButtonControlWebvantageURL_UseGlobal.Checked = If(WebvantageURL = "" OrElse WebvantageURL Is Nothing, True, False)
                RadioButtonControlWebvantageURL_UseGlobal.Tag = Agency.WebvantageURL
                RadioButtonControlWebvantageURL_WorkstationOnly.Checked = Not RadioButtonControlWebvantageURL_UseGlobal.Checked
                RadioButtonControlWebvantageURL_WorkstationOnly.Tag = WebvantageURL
                TextBoxWebvantageURL_URL.Text = If(RadioButtonControlWebvantageURL_UseGlobal.Checked, Agency.WebvantageURL, WebvantageURL)

                'Client Portal URL
                RadioButtonControlClientPortalURL_UseGlobal.Checked = If(ClientPortalURL = "" OrElse ClientPortalURL Is Nothing, True, False)
                RadioButtonControlClientPortalURL_UseGlobal.Tag = Agency.ClientPortalURL
                RadioButtonControlClientPortalURL_WorkstationOnly.Checked = Not RadioButtonControlClientPortalURL_UseGlobal.Checked
                RadioButtonControlClientPortalURL_WorkstationOnly.Tag = ClientPortalURL
                TextBoxClientPortalURL_URL.Text = If(RadioButtonControlClientPortalURL_UseGlobal.Checked, Agency.ClientPortalURL, ClientPortalURL)

                'Proofing URL
                RadioButtonControlProofingURL_UseGlobal.Checked = If(ProofingURL = "" OrElse ProofingURL Is Nothing, True, False)
                RadioButtonControlProofingURL_UseGlobal.Tag = Agency.ProofingURL
                RadioButtonControlProofingURL_WorkstationOnly.Checked = Not RadioButtonControlProofingURL_UseGlobal.Checked
                RadioButtonControlProofingURL_WorkstationOnly.Tag = ProofingURL
                TextBoxProofingURL_URL.Text = If(RadioButtonControlProofingURL_UseGlobal.Checked, Agency.ProofingURL, ProofingURL)

                'Access Report Source Folder
                RadioButtonControlAccessReportSourceFolder_UseGlobal.Checked = If(AccessReportPath = "" OrElse AccessReportPath Is Nothing, True, False)
                RadioButtonControlAccessReportSourceFolder_UseGlobal.Tag = Agency.AccessReportPath
                RadioButtonControlAccessReportSourceFolder_WorkstationOnly.Checked = Not RadioButtonControlAccessReportSourceFolder_UseGlobal.Checked
                RadioButtonControlAccessReportSourceFolder_WorkstationOnly.Tag = AccessReportPath
                TextBoxAccessReportSourceFolder_Path.Text = If(RadioButtonControlAccessReportSourceFolder_UseGlobal.Checked, Agency.AccessReportPath, AccessReportPath)

                'Access Report Temporary Folder
                RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Checked = If(AccessReportPath = "" OrElse AccessReportPath Is Nothing, True, False)
                RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Tag = Agency.AccessReportTemporaryPath
                RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.Checked = Not RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Checked
                RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.Tag = AccessReportTempPath
                TextBoxAccessReportTemporaryFolder_Path.Text = If(RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Checked, Agency.AccessReportTemporaryPath, AccessReportTempPath)

                'Access Report Source Folder
                RadioButtonControlDotNetFolder_UseGlobal.Checked = If(DotNetPath = "" OrElse DotNetPath Is Nothing, True, False)
                RadioButtonControlDotNetFolder_UseGlobal.Tag = AgencyDotNetPath
                RadioButtonControlDotNetFolder_WorkstationOnly.Checked = Not RadioButtonControlDotNetFolder_UseGlobal.Checked
                RadioButtonControlDotNetFolder_WorkstationOnly.Tag = DotNetPath
                TextBoxDotNetFolder_Path.Text = If(RadioButtonControlDotNetFolder_UseGlobal.Checked, AgencyDotNetPath, DotNetPath)

                ' SMTP E-Mail Setup
                ComboBoxSMTPEmailSetup_AuthenticationMethod.SelectedValue = CLng(Agency.SMTPAuthenticationMethodType.GetValueOrDefault(0))

                If Agency.SMTPPortNumber.HasValue Then
                    NumericInputSMTPEmailSetup_PortNumber.Value = Agency.SMTPPortNumber
                End If

                Select Case Agency.SMTPSecurityType
                    Case 0
                        RadioButtonControlSMTPEmailSetup_NoSecureProtocol.Checked = True
                    Case 1
                        RadioButtonControlSMTPEmailSetup_UseSSL.Checked = True
                    Case 2
                        RadioButtonControlSMTPEmailSetup_UseTLS.Checked = True
                End Select

                TextBoxSMTPEmailSetup_OutgoingServerAddress.Text = Agency.SMTPServer
                TextBoxSMTPEmailSetup_SenderAddress.Text = Agency.SMTPUserName
                TextBoxSMTPEmailSetup_DefaultUserName.Text = Agency.EmailUserName

                If String.IsNullOrWhiteSpace(Agency.EmailPassword) = False Then

                    TextBoxSMTPEmailSetup_DefaultPassword.Text = AdvantageFramework.Security.Encryption.Decrypt(Agency.EmailPassword)

                Else

                    TextBoxSMTPEmailSetup_DefaultPassword.Text = Agency.EmailPassword

                End If

                TextBoxSMTPEmailSetup_ReplyToAddress.Text = Agency.ReplyToEmail
                CheckBoxSMTPEmailSetup_EnablePDFAttachments.CheckValue = Agency.UseSMTPToSendPDF.GetValueOrDefault(0)
                CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.CheckValue = Agency.UseEmployeeLogin.GetValueOrDefault(0)

                ' POP3 / E-Mail Listener Settings
                ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.SelectedValue = CLng(Agency.POP3AuthenticationMethod.GetValueOrDefault(0))

                If Agency.POP3PortNumber.HasValue Then
                    NumericInputPOP3EmailListenerSettings_PortNumber.Value = Agency.POP3PortNumber
                End If

                Select Case Agency.POP3SecureType
                    Case 0
                        RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.Checked = True
                    Case 1
                        RadioButtonControlPOP3EmailListenerSettings_UseSSL.Checked = True
                    Case 2
                        RadioButtonControlPOP3EmailListenerSettings_UseTLS.Checked = True
                End Select

                TextBoxPOP3EmailListenerSettings_ServerAddress.Text = Agency.POP3Server
                'TextBoxPOP3EmailListenerSettings_UserName.Text = Agency.POP3UserName
                'TextBoxPOP3EmailListenerSettings_Password.Text = Agency.POP3Password
                'TextBoxPOP3EmailListenerSettings_ReplyToAddress.Text = Agency.POP3DefaultReplyToEmail
                'CheckBoxPOP3EMailListenerSettings_DeleteProcessedEmail.CheckValue = Agency.POP3DeleteMessages.GetValueOrDefault(0)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    POP3EmailListenerAccounts = AdvantageFramework.Database.Procedures.POP3EmailListenerAccount.LoadAndIncludeAgencyDefault(DbContext, _Agency)

                End Using

                For Each POP3EmailListenerAccount In POP3EmailListenerAccounts

                    If String.IsNullOrWhiteSpace(POP3EmailListenerAccount.Password) = False Then

                        POP3EmailListenerAccount.Password = AdvantageFramework.Security.Encryption.Decrypt(POP3EmailListenerAccount.Password)

                    End If

                Next

                DataGridViewSystemAndAlertOptions_POP3EmailAccounts.ItemDescription = "POP3 Email Listener Account(s)"
                DataGridViewSystemAndAlertOptions_POP3EmailAccounts.DataSource = POP3EmailListenerAccounts
                DataGridViewSystemAndAlertOptions_POP3EmailAccounts.CurrentView.BestFitColumns()

                If DataGridViewSystemAndAlertOptions_POP3EmailAccounts.Columns(Database.Entities.POP3EmailListenerAccount.Properties.Password.ToString) IsNot Nothing Then

                    Try

                        RepositoryItemTextEdit = DirectCast(DataGridViewSystemAndAlertOptions_POP3EmailAccounts.Columns(Database.Entities.POP3EmailListenerAccount.Properties.Password.ToString).ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)

                        RepositoryItemTextEdit.PasswordChar = Char.ConvertFromUtf32(9679)

                    Catch ex As Exception

                    End Try

                End If

                If DataGridViewSystemAndAlertOptions_POP3EmailAccounts.Columns(Database.Entities.POP3EmailListenerAccount.Properties.Description.ToString) IsNot Nothing Then

                    DataGridViewSystemAndAlertOptions_POP3EmailAccounts.Columns(Database.Entities.POP3EmailListenerAccount.Properties.Description.ToString).OptionsColumn.AllowFocus = False

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    POP3AutomatedAssignmentAccounts = AdvantageFramework.Database.Procedures.POP3AutomatedAssignmentAccount.Load(DbContext).ToList

                End Using

                For Each POP3AutomatedAssignmentAccount In POP3AutomatedAssignmentAccounts

                    If String.IsNullOrWhiteSpace(POP3AutomatedAssignmentAccount.Password) = False Then

                        POP3AutomatedAssignmentAccount.Password = AdvantageFramework.Security.Encryption.Decrypt(POP3AutomatedAssignmentAccount.Password)

                    End If

                Next

                DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.ItemDescription = "POP3 Automated Assignment Account(s)"
                DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.DataSource = POP3AutomatedAssignmentAccounts
                DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.BestFitColumns()

                If DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.Columns(Database.Entities.POP3AutomatedAssignmentAccount.Properties.Password.ToString) IsNot Nothing Then

                    Try

                        RepositoryItemTextEdit = DirectCast(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.Columns(Database.Entities.POP3AutomatedAssignmentAccount.Properties.Password.ToString).ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)

                        RepositoryItemTextEdit.PasswordChar = Char.ConvertFromUtf32(9679)

                    Catch ex As Exception

                    End Try

                End If

                TabItemAgencySetup_SystemAndAlertOptions.Tag = True

                EnableOrDisableEmailOptions()

                EnableOrDisableAutomatedAssignments()

            End If

        End Sub
        Private Sub LoadProductionOptionsTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            If Agency IsNot Nothing Then

                'Production options
                CheckBoxJobJacketOptions_AllowOfficeCodeOverride.CheckValue = Agency.OfficeCodeOverride.GetValueOrDefault(0)
                CheckBoxJobJacketOptions_AllowCDPOverride.CheckValue = Agency.CDPOverride.GetValueOrDefault(0)
                'CheckBoxJobJacketOptions_RequireUniqueClientReference.Tag = Convert.ToBoolean(Agency.UniqueClientReference.GetValueOrDefault(0))
                'CheckBoxJobJacketOptions_RequireUniqueClientReference.CheckValue = Agency.UniqueClientReference.GetValueOrDefault(0)
                CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Tag = Convert.ToBoolean(Agency.JobComponentTaxable.GetValueOrDefault(0))
                CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.CheckValue = Agency.JobComponentTaxable.GetValueOrDefault(0)
                CheckBoxJobJacketOptions_EnableFileAttachments.Checked = If(Agency.EnableAttachmentsInJobJacket.GetValueOrDefault(0) > 0, True, False)
                CheckBoxJobJacketOptions_EnableFileAttachmentDialog.Checked = If(Agency.EnableAttachmentsInJobJacket.GetValueOrDefault(0) = 2, True, False)
                CheckBoxJobJacketOptions_EnableFileAttachmentDialog.Enabled = CheckBoxJobJacketOptions_EnableFileAttachments.Checked
                CheckBoxJobJacketOptions_HideNonBillableFlag.CheckValue = Agency.HideNonBillableFlag.GetValueOrDefault(0)
                CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.CheckValue = Agency.EditJobRequiredEstimate.GetValueOrDefault(0)

                CheckBoxEstimateOptions_ApprovedEstimateRequired.CheckValue = Agency.ApprovedEstimateRequired.GetValueOrDefault(0)
                CheckBoxEstimateOptions_NewRevisionsRequired.CheckValue = Agency.RequireNewRevisions.GetValueOrDefault(0)
                CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.CheckValue = Agency.QuoteApprovalPasswordRequired.GetValueOrDefault(0)

                CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.CheckValue = Agency.POAmountRequired.GetValueOrDefault(0)
                CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.CheckValue = If(Agency.DefaultAlertGroup IsNot Nothing, True, False)
                SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Enabled = CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.Checked
                CheckBoxAllowProofHQ.CheckValue = Agency.AllowProofHQ.GetValueOrDefault(0)

                Try

                    SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.SelectedValue = Agency.DefaultAlertGroup

                Catch ex As Exception
                    SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.SelectedValue = Nothing
                End Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewEstimateProcessingExceedOptions_Options.DataSource = AdvantageFramework.Database.Procedures.EstimateProcessingOption.Load(DbContext).ToList
                    DataGridViewEstimateProcessingExceedOptions_Options.CurrentView.BestFitColumns()

                End Using

                TextBoxEstimateDefaultComments_Comments.Text = Agency.EstimateDefaultComments
                TextBoxPurchaseOrderDefaultFooterComments_Comments.Text = Agency.POFooterComments

                TabItemAgencySetup_ProductionOptionsTab.Tag = True

            End If

        End Sub
        Private Sub LoadAccountingOptionsTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim GLCrossReferenceOfficeCodes As Generic.List(Of String) = Nothing
            Dim InterOfficeAcccountOfficeCodes As Generic.List(Of String) = Nothing

            PictureEditCurrency_Image.Image = AdvantageFramework.My.Resources.HelpImage

            If Agency IsNot Nothing Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ' Accounts Payable
                        CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.CheckValue = Agency.APViewDeletedInvoices.GetValueOrDefault(0)
                        CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.CheckValue = Agency.APFlagVendor1099.GetValueOrDefault(0)
                        CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.CheckValue = Agency.APLockGLAccountCode.GetValueOrDefault(0)
                        CheckBoxAccountsPayableHeader_DisplayPayToInformation.CheckValue = Agency.APShowPayToInformation.GetValueOrDefault(0)

                        CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.CheckValue = AdvantageFramework.Agency.GetOptionServiceTaxEnabled(DataContext)

                        CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.CheckValue = AdvantageFramework.Agency.GetOptionDefaultAPDescriptionFromVendorAccount(DataContext)

                        CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.Checked = CBool(Agency.AllowCostOfSaleEntry)
                        CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.CheckValue = Agency.APLimitByOffice.GetValueOrDefault(0)
                        CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.CheckValue = Agency.InterCompanyTransactions.GetValueOrDefault(0)

                        'CheckBoxAccountsPayableDisbursement_EnterBalanceOfPOLine.CheckValue = Agency.APCalculatePOBalance.GetValueOrDefault(0)
                        CheckBoxAccountsPayableDisbursement_PopupMessageInAP.CheckValue = Agency.APPOMessage.GetValueOrDefault(0)
                        TextBoxAccountsPayableDisbursement_PopupMessageInAP.Text = Agency.APPOMessageText
                        TextBoxAccountsPayableDisbursement_PopupMessageInAP.Enabled = CheckBoxAccountsPayableDisbursement_PopupMessageInAP.Checked
                        CheckBoxAccountsPayableDisbursement_RejectAPEntry.CheckValue = Agency.APPOReject.GetValueOrDefault(0)
                        TextBoxAccountsPayableDisbursement_RejectAPEntry.Text = Agency.APPORejectText
                        TextBoxAccountsPayableDisbursement_RejectAPEntry.Enabled = CheckBoxAccountsPayableDisbursement_RejectAPEntry.Checked

                        ' Check Writing
                        CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.CheckValue = Agency.PrintVendorAccountNumber.GetValueOrDefault(0)

                        CheckBoxCheckFormatSettings_CheckAmountInWords.CheckValue = Agency.CheckAmountInWords.GetValueOrDefault(0)
                        ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.SelectedValue = Agency.AdjustCheckBodyLinesDown.GetValueOrDefault(0)
                        ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.SelectedValue = Agency.AdjustCheckStubLinesUp.GetValueOrDefault(0)

                        Try

                            SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.SelectedValue = Agency.APComputerCheckFormat

                        Catch ex As Exception
                            SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.SelectedValue = Nothing
                        End Try

                        If Agency.CurrencySymbol IsNot Nothing AndAlso Agency.CurrencySymbol <> "" Then

                            Try

                                ComboBoxCheckCurrecny_CurrencySymbols.SelectedItem = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.DefaultCurrencySymbols))
                                                                                      Where Entity.Description = Agency.CurrencySymbol
                                                                                      Select Entity.Code, Entity.Description).FirstOrDefault

                            Catch ex As Exception
                                ComboBoxCheckCurrecny_CurrencySymbols.SelectedIndex = 0
                            End Try

                        End If
                        'TextBoxCheckCurrency_Symbol.Text = Agency.CurrencySymbol
                        If Agency.CoinText IsNot Nothing Then

                            TextBoxCheckCurrency_CoinText.Text = Agency.CoinText

                        End If

                        If Agency.CurrencyText IsNot Nothing Then

                            TextBoxCheckCurrency_CurrencyText.Text = Agency.CurrencyText

                        End If

                        ' Billing and Accounts Receivable

                        CheckBoxBilling_RequireProductSetupComplete.CheckValue = Agency.RequireProductSetupComplete.GetValueOrDefault(0)

                        MediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadAgencyDefault(DbContext)
                        ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadAgencyDefault(DbContext)

                        LoadAPImportDefaultInvoiceDescription(DbContext)

                        If ProductionInvoiceDefault IsNot Nothing Then

                            If ProductionInvoiceDefault.CustomFormatName IsNot Nothing Then

                                SearchableComboBoxCustomInvoiceFormats_Production.SelectedValue = ProductionInvoiceDefault.CustomFormatName

                            End If

                        End If

                        If MediaInvoiceDefault IsNot Nothing Then

                            If MediaInvoiceDefault.TVCustomFormat IsNot Nothing Then

                                SearchableComboBoxCustomInvoiceFormats_Television.SelectedValue = MediaInvoiceDefault.TVCustomFormat

                            End If

                            If MediaInvoiceDefault.RadioCustomFormat IsNot Nothing Then

                                SearchableComboBoxCustomInvoiceFormats_Radio.SelectedValue = MediaInvoiceDefault.RadioCustomFormat

                            End If

                            If MediaInvoiceDefault.NewspaperCustomFormat IsNot Nothing Then

                                SearchableComboBoxCustomInvoiceFormats_Newspaper.SelectedValue = MediaInvoiceDefault.NewspaperCustomFormat

                            End If

                            If MediaInvoiceDefault.MagazineCustomFormat IsNot Nothing Then

                                SearchableComboBoxCustomInvoiceFormats_Magazine.SelectedValue = MediaInvoiceDefault.MagazineCustomFormat

                            End If

                            If MediaInvoiceDefault.OutOfHomeCustomFormat IsNot Nothing Then

                                SearchableComboBoxCustomInvoiceFormats_OutOfHome.SelectedValue = MediaInvoiceDefault.OutOfHomeCustomFormat

                            End If

                            If MediaInvoiceDefault.InternetCustomFormat IsNot Nothing Then

                                SearchableComboBoxCustomInvoiceFormats_Internet.SelectedValue = MediaInvoiceDefault.InternetCustomFormat

                            End If

                        End If

                        SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)

                        CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.CheckValue = AdvantageFramework.Agency.GetOptionClientCashReceiptsPartialPaymentEnabled(DataContext)
                        CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.CheckValue = AdvantageFramework.Agency.GetOptionClientCashReceiptsPartialPaymentRequired(DataContext)
                        SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.SelectedValue = AdvantageFramework.Agency.GetOptionClientCashReceiptsDefaultWriteoffGL(DataContext)

                        LoadAvaTaxOptionsTab(DbContext)

                        TextBoxCurrency_APIKey.Text = AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.CURRENCY_API_KEY)

                        CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.Enabled = CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.Checked

                        'GL
                        CheckBoxGL_UseFilter.CheckValue = Agency.UseGLFilter.GetValueOrDefault(0)

                        ' Media and Production
                        CheckBoxMedia_ActivateApprovals.CheckValue = Agency.ActivateApprovals.GetValueOrDefault(0)

                        NumericInputAPPromptsOptions_TelevisionMediaPercentOver.EditValue = Agency.TelevisionPercent
                        NumericInputAPPromptsOptions_RadioMediaPercentOver.EditValue = Agency.RadioPercent
                        NumericInputAPPromptsOptions_PrintMediaPercentOver.EditValue = Agency.PrintMediaPercent
                        NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.EditValue = Agency.OutOfHomePercent
                        NumericInputAPPromptsOptions_InternetMediaPercentOver.EditValue = Agency.InternetPercent

                        ToggleMediaApprovalOptions()

                        CheckBoxAPMediaImportOptions_PendingApprovalTV.Checked = CBool(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.IMP_PENDING_TV))
                        CheckBoxAPMediaImportOptions_PendingApprovalRadio.Checked = CBool(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.IMP_PENDING_RAD))
                        CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.Checked = CBool(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.IMP_PENDING_PRI))
                        CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.Checked = CBool(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.IMP_PENDING_OUT))
                        CheckBoxAPMediaImportOptions_PendingApprovalInternet.Checked = CBool(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.IMP_PENDING_INT))

                        CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.Checked = CBool(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.IMP_PAYMENT_HOLD))
                        CheckBoxMedia_AutomaticallyRemovePaymentHold.Checked = CBool(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.AP_REMOVE_PMT_HOLD))

                        CheckBoxMediaApprovalAlert_AlertBuyer.Checked = AdvantageFramework.Agency.GetOptionAPMediaImportAlertBuyer(DbContext)
                        CheckBoxMediaApprovalAlert_AlertAP.Checked = AdvantageFramework.Agency.GetOptionAPMediaApprovalAlertAP(DbContext)

                        ToggleMediaApprovalAlertOptions()

                        Select Case AdvantageFramework.Agency.GetOptionAPMediaApprovalAlertAPUser(DbContext)

                            Case 0

                                RadioButtonControlMediaApprovalAlert_AlertAPUser.Checked = True

                            Case 1

                                RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.Checked = True

                            Case Else

                                RadioButtonControlMediaApprovalAlert_AlertAPUser.Checked = True

                        End Select

                        CheckBoxProduction_ValidateClosedArchivedJobs.CheckValue = Agency.ValidateJobClose.GetValueOrDefault(0)

                        ' Currency

                        CheckBoxCurrency_ActivateMultipleCurrencies.CheckValue = Agency.UseMultipleCurrencies.GetValueOrDefault(0)
                        CheckBoxCurrency_ActivateMultipleCurrencies.AutoCheck = Not CBool(Agency.UseMultipleCurrencies.GetValueOrDefault(0))

                        SearchableComboBoxCurrency_HomeCurrency.ReadOnly = (Agency.UseMultipleCurrencies.GetValueOrDefault(0) = 1)

                        If Not String.IsNullOrWhiteSpace(Agency.HomeCurrency) Then

                            SearchableComboBoxCurrency_HomeCurrency.SelectedValue = Agency.HomeCurrency

                        Else

                            SearchableComboBoxCurrency_HomeCurrency.SelectedValue = "USD"

                        End If

                        ' Import

                        If Agency.IncomeOnlyImportType IsNot Nothing Then

                            ComboBoxImportSettings_IncomeOnlyImportFileType.SelectedValue = Agency.IncomeOnlyImportType

                        End If

                        If Agency.CurrencyRateImportType IsNot Nothing Then

                            ComboBoxImportSettings_CurrencyRateImportFileType.SelectedValue = Agency.CurrencyRateImportType

                        End If

                        TextBoxImportSettings_CSIClearedChecksImportPath.Text = AdvantageFramework.CSIPreferredPartner.LoadClearedChecksImportPath(DataContext)

                        CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked = Agency.InvoiceTaxFlag

                        SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.SelectedValue = AdvantageFramework.Agency.GetOptionAPApprovalAlertDefaultTemplate(DbContext)
                        SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.SelectedValue = AdvantageFramework.Agency.GetOptionAPApprovalAlertDefaultState(DbContext)
                        SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.SelectedValue = AdvantageFramework.Agency.GetOptionAPDefaultAlertGroup(DbContext)

                        TabItemAgencySetup_AccountingOptionsTab.Tag = True

                    End Using

                End Using

            End If

        End Sub
        Private Sub LoadAvaTaxOptionsTab(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim AddressValidationCountryList As Generic.List(Of AvaTax.Classes.AddressValidationCountry) = Nothing
            Dim SavedCountries As Generic.List(Of String) = Nothing
            Dim OfficeCompanyCodeList As Generic.List(Of AvaTax.Classes.OfficeCompanyCode) = Nothing

            TextBoxAvaTax_AccountNumber.Text = AdvantageFramework.Agency.GetOptionAvaTaxAccountNumber(DbContext)
            TextBoxAvaTax_LicenseKey.Text = AdvantageFramework.Agency.GetOptionAvaTaxLicenseKey(DbContext)
            TextBoxAvaTax_URL.Text = AdvantageFramework.Agency.GetOptionAvaTaxURL(DbContext)

            OfficeCompanyCodeList = New Generic.List(Of AdvantageFramework.AvaTax.Classes.OfficeCompanyCode)

            OfficeCompanyCodeList.AddRange(From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
                                           Select New AdvantageFramework.AvaTax.Classes.OfficeCompanyCode(Entity.Code, Entity.AvaTaxCompanyCode))

            DataGridViewAvaTaxOfficeCompanyCode_Mappings.DataSource = OfficeCompanyCodeList

            DataGridViewAvaTaxOfficeCompanyCode_Mappings.CurrentView.BestFitColumns()

            CheckBoxAvaTax_EnableAvaTaxCalculation.Checked = AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext)
            RadioButtonAddressOption_ClientAddress.Checked = AdvantageFramework.Agency.GetOptionAvaTaxUseClientStreetAddress(DbContext)
            RadioButtonAddressOption_JobContactAddress.Checked = AdvantageFramework.Agency.GetOptionAvaTaxUseJobContactAddress(DbContext)
            CheckBoxAvaTaxAddressValidation_Enabled.Checked = AdvantageFramework.Agency.GetOptionAvaTaxAddressValidationEnabled(DbContext)
            CheckBoxAvaTax_UseJobSalesClass.Checked = AdvantageFramework.Agency.GetOptionAvaTaxUseJobSalesClass(DbContext)

            AddressValidationCountryList = DataGridViewAvaTaxAddressValidation_Countries.GetAllRowsDataBoundItems().OfType(Of AvaTax.Classes.AddressValidationCountry).ToList()

            SavedCountries = AdvantageFramework.Agency.GetOptionAvaTaxEnableAddressValidationForCountries(DbContext)

            If SavedCountries IsNot Nothing Then

                For Each Country In SavedCountries

                    For Each Address In AddressValidationCountryList

                        If Address.Name = Country Then

                            Address.Validate = True

                            Exit For

                        End If

                    Next

                Next

            End If

            DataGridViewAvaTaxAddressValidation_Countries.DataSource = AddressValidationCountryList

            DataGridViewAvaTaxAddressValidation_Countries.CurrentView.BestFitColumns()

        End Sub
        Private Sub SaveAvaTaxOptionsTab(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim AddressValidationCountryList As Generic.List(Of AvaTax.Classes.AddressValidationCountry) = Nothing
            Dim OfficeCompanyCodeList As Generic.List(Of AvaTax.Classes.OfficeCompanyCode) = Nothing
            Dim Offices As IEnumerable(Of AdvantageFramework.Database.Entities.Office) = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", TextBoxAvaTax_AccountNumber.GetText, AdvantageFramework.Agency.Settings.AVATAX_ACCT_NUMBER.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", TextBoxAvaTax_LicenseKey.GetText, AdvantageFramework.Agency.Settings.AVATAX_LICENSE_KEY.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", TextBoxAvaTax_URL.GetText, AdvantageFramework.Agency.Settings.AVATAX_URL.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxAvaTaxAddressValidation_Enabled.Checked, 1, 0), AdvantageFramework.Agency.Settings.AVATAX_ADR_ENABLED.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(RadioButtonAddressOption_ClientAddress.Checked, 1, 0), AdvantageFramework.Agency.Settings.AVATAX_USE_CL_ADDR.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(RadioButtonAddressOption_JobContactAddress.Checked, 1, 0), AdvantageFramework.Agency.Settings.AVATAX_USE_JC_ADDR.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxAvaTax_UseJobSalesClass.Checked, 1, 0), AdvantageFramework.Agency.Settings.AVATAX_USE_JOB_SC.ToString))

                AddressValidationCountryList = DataGridViewAvaTaxAddressValidation_Countries.GetAllRowsDataBoundItems().OfType(Of AvaTax.Classes.AddressValidationCountry).Where(Function(AVC) AVC.Validate = True).ToList()

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", String.Join(",", AddressValidationCountryList), AdvantageFramework.Agency.Settings.AVATAX_ADR_COUNTRIES.ToString))

                OfficeCompanyCodeList = DataGridViewAvaTaxOfficeCompanyCode_Mappings.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.AvaTax.Classes.OfficeCompanyCode).ToList

                Offices = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList

                For Each OfficeCompanyCode In OfficeCompanyCodeList

                    Office = Offices.Where(Function(O) O.Code = OfficeCompanyCode.OfficeCode).SingleOrDefault

                    If Office IsNot Nothing Then

                        Office.AvaTaxCompanyCode = If(String.IsNullOrWhiteSpace(OfficeCompanyCode.AvaTaxCompanyCode), Nothing, OfficeCompanyCode.AvaTaxCompanyCode)

                        DbContext.UpdateObject(Office)

                    End If

                Next

                DbContext.SaveChanges()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadTimesheetOptionsTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            If Agency IsNot Nothing Then

                'Timesheet Options
                CheckBoxTimesheetOptions_UseBatchMethod.CheckValue = Agency.UseBatchMethod.GetValueOrDefault(0)
                CheckBoxTimesheetOptions_UseCopyTimesheet.CheckValue = Agency.CopyTimesheetFeature.GetValueOrDefault(0)
                CheckBoxTimesheetOptions_CheckClosedPostingPeriods.CheckValue = Agency.CheckClosedPeriods.GetValueOrDefault(0)
                CheckBoxTimesheetOptions_RequireTimeComments.CheckValue = Agency.TimeCommentsRequired.GetValueOrDefault(0)
                ' CheckBoxTimesheetOptions_EnableProductCategoryEntry.CheckValue = Agency.EnableProductCategory.GetValueOrDefault(0)
                CheckBoxTimesheetOptions_SupervisorApprovalActive.CheckValue = Agency.SupervisorApprovalActive.GetValueOrDefault(0)
                CheckBoxTimesheetOptions_SupervisiorCanEditTime.CheckValue = Agency.SupervisorCanEditTime.GetValueOrDefault(0)
                CheckBoxTimesheetOptions_SupervisiorCanEditTime.Enabled = CheckBoxTimesheetOptions_SupervisorApprovalActive.Checked
                CheckBoxTimesheetOptions_AutoAlertSupervisor.CheckValue = Agency.AutoAlertSupervisor.GetValueOrDefault(0)
                CheckBoxTimesheetOptions_AutoAlertSupervisor.Enabled = CheckBoxTimesheetOptions_SupervisorApprovalActive.Checked
                ComboBoxTimesheetOptions_DefaultDisplayDays.SelectedValue = Agency.DefaultDisplayDays.GetValueOrDefault(5)
                CheckBoxTimesheetOptions_AllowDrillDownTimesheet.CheckValue = Agency.QVAQuery.GetValueOrDefault(0)
                CheckBoxTimesheetOptions_AllowCopyHours.Enabled = CheckBoxTimesheetOptions_UseCopyTimesheet.Checked
                CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.CheckValue = Agency.TimesheetAddUniqueRowWhenComment.GetValueOrDefault(0)

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    CheckBoxTimesheetOptions_AllowCopyHours.Checked = AdvantageFramework.Database.Procedures.Agency.TimesheetCopyHours(DbContext)

                End Using

                'Missing Time Options
                CheckBoxMissingTimeOptions_NotifySupervisor.CheckValue = Agency.EmailSupervisor.GetValueOrDefault(0)
                TextBoxMissingTimeOptions_ITEMail.Text = Agency.ITContactEmail

                Select Case Agency.WeeklyTimeType

                    Case 0

                        RadioButtonMissingTimeOptions_ByDay.Checked = True

                    Case 1

                        RadioButtonMissingTimeOptions_ByWeek.Checked = True

                End Select

                TabItemAgencySetup_TimesheetOptionsTab.Tag = True

            End If

        End Sub
        Private Sub LoadMediaOptionsTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If Agency IsNot Nothing Then

                'Settings
                If Agency.MediaImportDefault IsNot Nothing Then
                    ComboBoxSettings_MediaImportDefault.SelectedValue = Agency.MediaImportDefault
                End If
                'TextBoxSettings_NFusionDatasourceName.Text = Agency.NFusionDatasourceName
                TextBoxSettings_StrataConnectPath.Text = Agency.StrataConnectPath
                TextBoxSettings_ImportPath.Text = Agency.ImportPath
                CheckBoxSettings_RenameFinanceFile.CheckValue = Agency.RenameFinanceFile.GetValueOrDefault(0)
                CheckBoxSettings_UseAPAccountOnImport.CheckValue = Agency.UseAPAccountOnImport.GetValueOrDefault(0)

                'Media Planning
                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    ComboBoxMediaPlanning_DefaultGroupingTypeInternet.SelectedValue = AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_INT)
                    ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.SelectedValue = AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_MAG)
                    ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.SelectedValue = AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_NEW)
                    ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.SelectedValue = AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_OUT)
                    ComboBoxMediaPlanning_DefaultGroupingTypeRadio.SelectedValue = AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_RAD)
                    ComboBoxMediaPlanning_DefaultGroupingTypeTV.SelectedValue = AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_TV)

                    CheckBoxMediaPlanning_AddLinesToExistingOrder.Checked = AdvantageFramework.Agency.LoadMediaPlanningAddLinesToExistingOrder(DataContext)

                End Using

                'Media Footer Comments
                TextBoxTelevision_FooterComments.Text = Agency.TelevisionFooterComments
                TextBoxRadio_FooterComments.Text = Agency.RadioFooterComments
                TextBoxNewspaper_FooterComments.Text = Agency.NewspaperFooterComments
                TextBoxMagazine_FooterComments.Text = Agency.MagazineFooterComments
                TextBoxOutOfHome_FooterComments.Text = Agency.OutOfHomeFooterComments
                TextBoxInternet_FooterComments.Text = Agency.InternetFooterComments

                DataGridViewRightSection_AdServingFields.CurrentView.OptionsMenu.EnableColumnMenu = False
                DataGridViewRightSection_AdServingFields.CurrentView.OptionsCustomization.AllowFilter = False
                DataGridViewRightSection_AdServingFields.CurrentView.OptionsCustomization.AllowSort = False

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    TextBoxExportMediaOrders_APPath.Text = AdvantageFramework.Agency.GetOptionOrderExportFromAPPath(DbContext)
                    TextBoxExportMediaOrders_MediaPlanPath.Text = AdvantageFramework.Agency.GetOptionOrderExportFromMediaPlanPath(DbContext)

                    LoadAdServingFields(DbContext)

                End Using

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    TextBoxSettingsForWebFormTerms_WebFormTerms.Text = AdvantageFramework.Agency.GetWebFormTerms(DataContext)

                    'CheckBoxSettings_MediaOrderLineInIncomeOnly.Checked = AdvantageFramework.Agency.LoadMediaOrderLineSelectionInIncomeOnly(DataContext)

                    CheckBoxSettings_MediaExcludeOrderPDFWithEmail.Checked = AdvantageFramework.Agency.LoadMediaExcludeOrderPDFWithEmail(DataContext)

                    If AdvantageFramework.Agency.LoadBroadcastWorksheetDefaultRateType(DataContext) Then

                        RadioButtonMediaOrders_Gross.Checked = False
                        RadioButtonMediaOrders_Net.Checked = True

                    Else

                        RadioButtonMediaOrders_Gross.Checked = True
                        RadioButtonMediaOrders_Net.Checked = False

                    End If

                    CheckBoxMediaOrders_UseVendorsRateType.Checked = AdvantageFramework.Agency.LoadVendorsRateTypeSetting(DataContext)

                    CheckBoxMediaGeneral_MediaRequireCampaign.Checked = AdvantageFramework.Agency.LoadMediaRequireCampaign(DataContext)
                    CheckBoxMediaGeneral_MediaAutoBuyer.Checked = AdvantageFramework.Agency.LoadMediaAutoBuyer(DataContext)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MEDIATRAFFIC_STARTDT.ToString)

                    If Setting IsNot Nothing AndAlso Setting.Value IsNot Nothing Then

                        DateTimePickerSettings_MediaTrafficStartDate.ValueObject = AdvantageFramework.DateUtilities.ConvertStringToShortDateString(Setting.Value)

                    Else

                        DateTimePickerSettings_MediaTrafficStartDate.ValueObject = Nothing

                    End If

                    ComboBoxMediaOrders_Country.SelectedValue = AdvantageFramework.Agency.LoadCountry(DataContext)

                End Using

                TabItemAgencySetup_MediaOptionsTab.Tag = True

            End If

        End Sub
        Private Sub LoadAdServingFields(DbContext As AdvantageFramework.Database.DbContext)

            Dim SelectedCodeList As IEnumerable(Of String) = Nothing

            DataGridViewRightSection_AdServingFields.DataSource = AdvantageFramework.Database.Procedures.AdServerPlacementField.Load(DbContext).OrderBy(Function(Entity) Entity.FieldOrder).ToList
            DataGridViewRightSection_AdServingFields.CurrentView.BestFitColumns()

            SelectedCodeList = (From Entity In DataGridViewRightSection_AdServingFields.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.AdServerPlacementField)
                                Select Entity.FieldCode).ToArray

            DataGridViewLeftSection_AvailableFields.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AdServerPlacementNameFields)).ToList
                                                                  Where SelectedCodeList.Contains(EnumObject.Code) = False
                                                                  Select [Code] = EnumObject.Code,
                                                                         [Description] = EnumObject.Description).ToList

            DataGridViewLeftSection_AvailableFields.SetBookmarkColumnIndex(0)

            If DataGridViewLeftSection_AvailableFields.CurrentView.Columns("Code") IsNot Nothing Then

                DataGridViewLeftSection_AvailableFields.CurrentView.Columns("Code").Visible = False

            End If

        End Sub
        Private Sub SetAdServingFieldOrder(DbContext As AdvantageFramework.Database.DbContext)

            'objects
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim AdServerPlacementFieldList As Generic.List(Of AdvantageFramework.Database.Entities.AdServerPlacementField) = Nothing
            Dim AdServerPlacementField As AdvantageFramework.Database.Entities.AdServerPlacementField = Nothing
            Dim FieldOrder As Integer = 1

            Try

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction

                DbContext.Database.ExecuteSqlCommand("DELETE dbo.AD_SERVER_PLACEMENT_FIELD")

                AdServerPlacementFieldList = DataGridViewRightSection_AdServingFields.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.AdServerPlacementField).ToList

                For Each Obj In AdServerPlacementFieldList

                    AdServerPlacementField = New AdvantageFramework.Database.Entities.AdServerPlacementField
                    AdServerPlacementField.DbContext = DbContext

                    AdServerPlacementField.FieldOrder = FieldOrder
                    AdServerPlacementField.FieldCode = Obj.FieldCode
                    AdServerPlacementField.FieldName = Obj.FieldName

                    AdvantageFramework.Database.Procedures.AdServerPlacementField.Insert(DbContext, AdServerPlacementField)

                    FieldOrder += 1

                Next

                DbTransaction.Commit()

            Catch ex As Exception

            Finally

                If DbContext.Database.Connection.State = ConnectionState.Open Then

                    DbContext.Database.Connection.Close()

                End If

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End Try

        End Sub
        Private Sub MoveAdServerField(AdServerPlacementField As AdvantageFramework.Database.Entities.AdServerPlacementField, ByVal MoveUp As Boolean)

            'objects
            Dim AdServerPlacementFieldAboveOrBelow As AdvantageFramework.Database.Entities.AdServerPlacementField = Nothing
            Dim AllAdServerPlacementFields As Generic.List(Of AdvantageFramework.Database.Entities.AdServerPlacementField) = Nothing

            If AdServerPlacementField IsNot Nothing Then

                AllAdServerPlacementFields = DataGridViewRightSection_AdServingFields.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.AdServerPlacementField).ToList

                If MoveUp Then

                    Try

                        AdServerPlacementFieldAboveOrBelow = (From Entity In AllAdServerPlacementFields
                                                              Where Entity.FieldOrder < AdServerPlacementField.FieldOrder
                                                              Order By Entity.FieldOrder Descending
                                                              Select Entity).FirstOrDefault

                    Catch ex As Exception
                        AdServerPlacementFieldAboveOrBelow = Nothing
                    End Try

                    If AdServerPlacementFieldAboveOrBelow IsNot Nothing Then

                        AdServerPlacementFieldAboveOrBelow.FieldOrder = AdServerPlacementFieldAboveOrBelow.FieldOrder + 1

                        AdServerPlacementField.FieldOrder = AdServerPlacementField.FieldOrder - 1

                    End If

                Else

                    Try

                        AdServerPlacementFieldAboveOrBelow = (From Entity In AllAdServerPlacementFields
                                                              Where Entity.FieldOrder > AdServerPlacementField.FieldOrder
                                                              Order By Entity.FieldOrder Ascending
                                                              Select Entity).FirstOrDefault

                    Catch ex As Exception
                        AdServerPlacementFieldAboveOrBelow = Nothing
                    End Try

                    If AdServerPlacementFieldAboveOrBelow IsNot Nothing Then

                        AdServerPlacementFieldAboveOrBelow.FieldOrder = AdServerPlacementFieldAboveOrBelow.FieldOrder - 1

                        AdServerPlacementField.FieldOrder = AdServerPlacementField.FieldOrder + 1

                    End If

                End If

                DataGridViewRightSection_AdServingFields.DataSource = AllAdServerPlacementFields.OrderBy(Function(Entity) Entity.FieldOrder)

                DataGridViewRightSection_AdServingFields.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub LoadRequiredFieldsTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            If Agency IsNot Nothing Then

                CheckBoxLeftColumn_AccountNumber.CheckValue = Agency.AccountNumberRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_Complexity.CheckValue = Agency.ComplexityCodeRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_AlertGroup.CheckValue = Agency.AlertGroupRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_CoopBilling.CheckValue = Agency.CoopBillingCodeRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_AdNumber.CheckValue = Agency.AdNumberRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_ClientReference.CheckValue = Agency.ClientReferenceRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_DateOpened.CheckValue = Agency.DateOpenedRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_Blackplate1.CheckValue = Agency.Blackplate1Required.GetValueOrDefault(0)
                CheckBoxLeftColumn_Blackplate2.CheckValue = Agency.Blackplate2Required.GetValueOrDefault(0)
                CheckBoxLeftColumn_Budget.CheckValue = Agency.ComponentBudgetRequired.GetValueOrDefault(0)

                CheckBoxMiddleColumn_JobType.CheckValue = Agency.JobTypeRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_Promotion.CheckValue = Agency.PromotionRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_DueDate.CheckValue = Agency.DueDateRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_SalesClassFormat.CheckValue = Agency.SCFormatRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_DeptTeam.CheckValue = Agency.DepartmentTeamRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_Market.CheckValue = Agency.MarketCodeRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_ServiceFeeType.CheckValue = Agency.ServiceFeeTypeRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_Format.CheckValue = Agency.FormatAdSizeRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_Contact.CheckValue = Agency.ProductContactRequired.GetValueOrDefault(0)

                CheckBoxRightColumn_JobLogCustom1.CheckValue = Agency.JobLogCustom1.GetValueOrDefault(0)
                CheckBoxRightColumn_JobLogCustom2.CheckValue = Agency.JobLogCustom2.GetValueOrDefault(0)
                CheckBoxRightColumn_JobLogCustom3.CheckValue = Agency.JobLogCustom3.GetValueOrDefault(0)
                CheckBoxRightColumn_JobLogCustom4.CheckValue = Agency.JobLogCustom4.GetValueOrDefault(0)
                CheckBoxRightColumn_JobLogCustom5.CheckValue = Agency.JobLogCustom5.GetValueOrDefault(0)
                CheckBoxRightColumn_JobComponentCustom1.CheckValue = Agency.JobComponentCustom1.GetValueOrDefault(0)
                CheckBoxRightColumn_JobComponentCustom2.CheckValue = Agency.JobComponentCustom2.GetValueOrDefault(0)
                CheckBoxRightColumn_JobComponentCustom3.CheckValue = Agency.JobComponentCustom3.GetValueOrDefault(0)
                CheckBoxRightColumn_JobComponentCustom4.CheckValue = Agency.JobComponentCustom4.GetValueOrDefault(0)
                CheckBoxRightColumn_JobComponentCustom5.CheckValue = Agency.JobComponentCustom5.GetValueOrDefault(0)

                CheckBoxJobsAndMedia_Campaign.CheckValue = Agency.CampaignCodeRequired.GetValueOrDefault(0)
                CheckBoxJobsAndMedia_FiscalPeriod.CheckValue = Agency.FiscalPeriodRequired.GetValueOrDefault(0)

                TabItemAgencySetup_RequiredFieldsTab.Tag = True

            End If

        End Sub
        Private Sub SaveInformationTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            If Agency IsNot Nothing Then

                Agency.Name = TextBoxAgencyInformation_Name.Text
                Agency.Phone = TextBoxAgencyInformation_Phone.Text
                Agency.Address = AddressControlAgencyInformation_Address.Address
                Agency.Address2 = AddressControlAgencyInformation_Address.Address2
                Agency.City = AddressControlAgencyInformation_Address.City
                Agency.County = AddressControlAgencyInformation_Address.County
                Agency.State = AddressControlAgencyInformation_Address.State
                Agency.Zip = AddressControlAgencyInformation_Address.Zip
                Agency.Country = AddressControlAgencyInformation_Address.Country

            End If

        End Sub
        Private Sub SaveSystemAndAlertsTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByRef SavedRegistrySettings As Boolean)

            If Agency IsNot Nothing Then

                Agency.ActivateSystemAlerts = CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.GetValue
                Agency.IncludeAlertGroups = CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.GetValue
                Agency.IncludeAttachmentsWithAlerts = CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.GetValue
                Agency.ExcludeAttachmentByDefault = CheckBoxAlertOptions_ExcludeAttachmentByDefault.GetValue
                Agency.EnableAlertNotification = CheckBoxAlertOptions_EnableAlertNotification.GetValue

                If String.IsNullOrWhiteSpace(TextBoxWebvantageURL_URL.Text) = False Then

                    TextBoxWebvantageURL_URL.Text = TextBoxWebvantageURL_URL.Text.Trim

                    If AdvantageFramework.StringUtilities.IsValidURL(TextBoxWebvantageURL_URL.Text) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Invalid Webvantage URL")
                        Exit Sub

                    End If

                    'Else

                    '    Agency.WebvantageURL = Nothing

                End If

                If String.IsNullOrWhiteSpace(TextBoxClientPortalURL_URL.Text) = False Then

                    TextBoxClientPortalURL_URL.Text = TextBoxClientPortalURL_URL.Text.Trim

                    If AdvantageFramework.StringUtilities.IsValidURL(TextBoxClientPortalURL_URL.Text) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Invalid Client Portal URL")
                        Exit Sub

                    End If

                    'Else

                    '    Agency.ClientPortalURL = Nothing

                End If

                If String.IsNullOrWhiteSpace(TextBoxProofingURL_URL.Text) = False Then

                    TextBoxProofingURL_URL.Text = TextBoxProofingURL_URL.Text.Trim

                    If AdvantageFramework.StringUtilities.IsValidURL(TextBoxProofingURL_URL.Text) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Invalid Proofing URL")
                        Exit Sub

                    End If

                    'Else

                    '    Agency.ProofingURL = Nothing

                End If

                If RadioButtonControlWebvantageURL_UseGlobal.Checked Then

                    Agency.WebvantageURL = TextBoxWebvantageURL_URL.Text

                    If TextBoxWebvantageURL_URL.UserEntryChanged Then

                        If AdvantageFramework.Agency.DeleteMachineAccessSetting(AdvantageFramework.Agency.LocalMachineAccess.WebvantageURL) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                ElseIf RadioButtonControlWebvantageURL_WorkstationOnly.Checked Then

                    If TextBoxWebvantageURL_URL.UserEntryChanged Then

                        If AdvantageFramework.Agency.UpdateMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.WebvantageURL, TextBoxWebvantageURL_URL.Text) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                    RadioButtonControlWebvantageURL_WorkstationOnly.Tag = TextBoxWebvantageURL_URL.Text

                End If

                If RadioButtonControlClientPortalURL_UseGlobal.Checked Then

                    Agency.ClientPortalURL = TextBoxClientPortalURL_URL.Text

                    If TextBoxClientPortalURL_URL.UserEntryChanged Then

                        If AdvantageFramework.Agency.DeleteMachineAccessSetting(AdvantageFramework.Agency.LocalMachineAccess.ClientPortalURL) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                ElseIf RadioButtonControlClientPortalURL_WorkstationOnly.Checked Then

                    If TextBoxClientPortalURL_URL.UserEntryChanged Then

                        If AdvantageFramework.Agency.UpdateMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.ClientPortalURL, TextBoxClientPortalURL_URL.Text) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                    RadioButtonControlClientPortalURL_WorkstationOnly.Tag = TextBoxClientPortalURL_URL.Text

                End If

                If RadioButtonControlProofingURL_UseGlobal.Checked Then

                    Agency.ProofingURL = TextBoxProofingURL_URL.Text

                    If TextBoxProofingURL_URL.UserEntryChanged Then

                        If AdvantageFramework.Agency.DeleteMachineAccessSetting(AdvantageFramework.Agency.LocalMachineAccess.ProofingURL) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                ElseIf RadioButtonControlProofingURL_WorkstationOnly.Checked Then

                    If TextBoxProofingURL_URL.UserEntryChanged Then

                        If AdvantageFramework.Agency.UpdateMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.ProofingURL, TextBoxProofingURL_URL.Text) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                    RadioButtonControlProofingURL_WorkstationOnly.Tag = TextBoxProofingURL_URL.Text

                End If

                If RadioButtonControlAccessReportSourceFolder_UseGlobal.Checked Then

                    Agency.AccessReportPath = TextBoxAccessReportSourceFolder_Path.Text

                    If TextBoxAccessReportSourceFolder_Path.UserEntryChanged Then

                        If AdvantageFramework.Agency.DeleteMachineAccessSetting(AdvantageFramework.Agency.LocalMachineAccess.AccessRptPath) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                ElseIf RadioButtonControlAccessReportSourceFolder_WorkstationOnly.Checked Then

                    If TextBoxAccessReportSourceFolder_Path.UserEntryChanged Then

                        If AdvantageFramework.Agency.UpdateMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessRptPath, TextBoxAccessReportSourceFolder_Path.Text) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                    RadioButtonControlAccessReportSourceFolder_WorkstationOnly.Tag = TextBoxAccessReportSourceFolder_Path.Text

                End If

                If RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Checked Then

                    Agency.AccessReportTemporaryPath = TextBoxAccessReportTemporaryFolder_Path.Text

                    If TextBoxAccessReportTemporaryFolder_Path.UserEntryChanged Then

                        If AdvantageFramework.Agency.DeleteMachineAccessSetting(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                ElseIf RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.Checked Then

                    If TextBoxAccessReportTemporaryFolder_Path.UserEntryChanged Then

                        If AdvantageFramework.Agency.UpdateMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath, TextBoxAccessReportTemporaryFolder_Path.Text) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                    RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.Tag = TextBoxAccessReportTemporaryFolder_Path.Text

                End If

                If RadioButtonControlDotNetFolder_UseGlobal.Checked Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        AdvantageFramework.Agency.SaveDotNetFolder(DataContext, TextBoxDotNetFolder_Path.Text)

                    End Using

                    If TextBoxDotNetFolder_Path.UserEntryChanged Then

                        If AdvantageFramework.Agency.DeleteMachineAccessSetting(AdvantageFramework.Agency.LocalMachineAccess.DotNetPath) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                ElseIf RadioButtonControlDotNetFolder_WorkstationOnly.Checked Then

                    If TextBoxDotNetFolder_Path.UserEntryChanged Then

                        If AdvantageFramework.Agency.UpdateMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.DotNetPath, TextBoxDotNetFolder_Path.Text) = False Then

                            SavedRegistrySettings = False

                        End If

                    End If

                    RadioButtonControlDotNetFolder_WorkstationOnly.Tag = TextBoxDotNetFolder_Path.Text

                End If

                Agency.SMTPAuthenticationMethodType = Convert.ToInt16(ComboBoxSMTPEmailSetup_AuthenticationMethod.GetSelectedValue)
                Agency.SMTPPortNumber = NumericInputSMTPEmailSetup_PortNumber.Value

                If RadioButtonControlSMTPEmailSetup_NoSecureProtocol.Checked Then
                    Agency.SMTPSecurityType = 0
                ElseIf RadioButtonControlSMTPEmailSetup_UseSSL.Checked Then
                    Agency.SMTPSecurityType = 1
                ElseIf RadioButtonControlSMTPEmailSetup_UseTLS.Checked Then
                    Agency.SMTPSecurityType = 2
                End If

                Agency.SMTPServer = TextBoxSMTPEmailSetup_OutgoingServerAddress.Text
                Agency.SMTPUserName = TextBoxSMTPEmailSetup_SenderAddress.Text
                Agency.EmailUserName = TextBoxSMTPEmailSetup_DefaultUserName.Text

                Agency.EmailPassword = TextBoxSMTPEmailSetup_DefaultPassword.Text

                If String.IsNullOrWhiteSpace(Agency.EmailPassword) = False Then

                    Agency.EmailPassword = AdvantageFramework.Security.Encryption.Encrypt(Agency.EmailPassword)

                End If

                Agency.ReplyToEmail = TextBoxSMTPEmailSetup_ReplyToAddress.Text
                Agency.UseSMTPToSendPDF = CheckBoxSMTPEmailSetup_EnablePDFAttachments.GetValue
                Agency.UseEmployeeLogin = CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.GetValue

                Agency.POP3AuthenticationMethod = Convert.ToInt16(ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.GetSelectedValue)
                Agency.POP3PortNumber = NumericInputPOP3EmailListenerSettings_PortNumber.Value

                If RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.Checked Then
                    Agency.POP3SecureType = 0
                ElseIf RadioButtonControlPOP3EmailListenerSettings_UseSSL.Checked Then
                    Agency.POP3SecureType = 1
                ElseIf RadioButtonControlPOP3EmailListenerSettings_UseTLS.Checked Then
                    Agency.POP3SecureType = 2
                End If

                Agency.POP3Server = TextBoxPOP3EmailListenerSettings_ServerAddress.Text
                'Agency.POP3UserName = TextBoxPOP3EmailListenerSettings_UserName.Text
                'Agency.POP3Password = TextBoxPOP3EmailListenerSettings_Password.Text
                'Agency.POP3DefaultReplyToEmail = TextBoxPOP3EmailListenerSettings_ReplyToAddress.Text
                'Agency.POP3DeleteMessages = CheckBoxPOP3EMailListenerSettings_DeleteProcessedEmail.GetValue

            End If

        End Sub
        Private Sub SaveMaxEmailSize(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = 'MAX_EMAIL_SIZE'", NumericInputEmailAttachments_MaxFileSize.Value))

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SaveAPImportDefaultInvoiceDescription(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = 'AP_IMP_DEF_INV_DESC'", ComboBoxImportSettings_DefaultInvoiceDescription.GetSelectedValue))

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SaveMediaOrderExportPathFromAP(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = 'ORDER_AP_OUTPATH'", TextBoxExportMediaOrders_APPath.Text))

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SaveMediaOrderExportPathFromMediaPlan(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = 'ORDER_MP_OUTPATH'", TextBoxExportMediaOrders_MediaPlanPath.Text))

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SaveAPOrderNotMatchingVendor(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = 'AP_NON_VENDOR_ORDER'", CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.Checked))

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SaveProductionOptionsTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            If Agency IsNot Nothing Then

                Agency.OfficeCodeOverride = CheckBoxJobJacketOptions_AllowOfficeCodeOverride.GetValue
                Agency.CDPOverride = CheckBoxJobJacketOptions_AllowCDPOverride.GetValue
                'Agency.UniqueClientReference = CheckBoxJobJacketOptions_RequireUniqueClientReference.GetValue
                Agency.JobComponentTaxable = CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.GetValue

                If CheckBoxJobJacketOptions_EnableFileAttachments.Checked Then

                    If CheckBoxJobJacketOptions_EnableFileAttachmentDialog.Checked Then
                        Agency.EnableAttachmentsInJobJacket = 2
                    Else
                        Agency.EnableAttachmentsInJobJacket = 1
                    End If

                Else
                    Agency.EnableAttachmentsInJobJacket = 0
                End If

                Agency.EditJobRequiredEstimate = CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.GetValue
                Agency.HideNonBillableFlag = CheckBoxJobJacketOptions_HideNonBillableFlag.GetValue

                Agency.ApprovedEstimateRequired = CheckBoxEstimateOptions_ApprovedEstimateRequired.GetValue
                Agency.RequireNewRevisions = CheckBoxEstimateOptions_NewRevisionsRequired.GetValue
                Agency.QuoteApprovalPasswordRequired = CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.GetValue

                Agency.POAmountRequired = CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.GetValue

                If CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.Checked AndAlso
                    SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.HasASelectedValue Then

                    Agency.DefaultAlertGroup = SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.GetSelectedValue

                Else

                    Agency.DefaultAlertGroup = Nothing

                End If

                ' **ESTIMATE PROCESSING / EXCEED OPTIONS HANDLED IN SaveEstimateProcessAndExceedOptions()

                Agency.EstimateDefaultComments = TextBoxEstimateDefaultComments_Comments.Text
                Agency.POFooterComments = TextBoxPurchaseOrderDefaultFooterComments_Comments.Text

                Agency.AllowProofHQ = CheckBoxAllowProofHQ.Checked

                'Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                '    AdvantageFramework.Database.Procedures.Agency.UpdateAllowProofHQ(DbContext, CheckBoxAllowProofHQ.Checked)

                'End Using

            End If

        End Sub
        Private Sub SaveAccountingOptionsTab(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            If Agency IsNot Nothing Then

                Agency.APViewDeletedInvoices = CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.GetValue
                Agency.ValidateJobClose = CheckBoxProduction_ValidateClosedArchivedJobs.GetValue
                Agency.APLimitByOffice = CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.GetValue
                Agency.InterCompanyTransactions = CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.GetValue
                Agency.APFlagVendor1099 = CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.GetValue
                Agency.APLockGLAccountCode = CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.GetValue
                Agency.PrintVendorAccountNumber = CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.GetValue
                Agency.APShowPayToInformation = CheckBoxAccountsPayableHeader_DisplayPayToInformation.GetValue

                SaveServiceTaxEnabled(DbContext)

                SaveDefaultAPDescriptionFromVendorAccount(DbContext)

                'Agency.APCalculatePOBalance = CheckBoxAccountsPayableDisbursement_EnterBalanceOfPOLine.GetValue
                Agency.RequireProductSetupComplete = CheckBoxBilling_RequireProductSetupComplete.GetValue
                Agency.APPOMessage = CheckBoxAccountsPayableDisbursement_PopupMessageInAP.GetValue
                Agency.APPOMessageText = TextBoxAccountsPayableDisbursement_PopupMessageInAP.Text
                Agency.APPOReject = CheckBoxAccountsPayableDisbursement_RejectAPEntry.GetValue
                Agency.APPORejectText = TextBoxAccountsPayableDisbursement_RejectAPEntry.Text
                Agency.AllowCostOfSaleEntry = CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.GetValue

                Agency.ActivateApprovals = CheckBoxMedia_ActivateApprovals.GetValue
                'Agency.UseMultipleCurrencies = CheckBoxCurrency_ActivateMultipleCurrencies.GetValue
                'If SearchableComboBoxCurrency_HomeCurrency.HasASelectedValue Then
                '    Agency.HomeCurrency = SearchableComboBoxCurrency_HomeCurrency.GetSelectedValue
                'Else
                '    Agency.HomeCurrency = Nothing
                'End If

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", TextBoxCurrency_APIKey.GetText, AdvantageFramework.Agency.Settings.CURRENCY_API_KEY.ToString))

                ' **CUSTOM INVOICE FORMATS HANDLED IN SaveMediaInvoiceDefault()

                Agency.APComputerCheckFormat = SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.GetSelectedValue
                Agency.CheckAmountInWords = CheckBoxCheckFormatSettings_CheckAmountInWords.GetValue
                Agency.AdjustCheckBodyLinesDown = ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.GetSelectedValue
                Agency.AdjustCheckStubLinesUp = ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.GetSelectedValue

                If ComboBoxCheckCurrecny_CurrencySymbols.HasASelectedValue Then

                    Agency.CurrencySymbol = ComboBoxCheckCurrecny_CurrencySymbols.SelectedItem.Description

                Else

                    Agency.CurrencySymbol = Nothing

                End If

                Agency.CoinText = TextBoxCheckCurrency_CoinText.Text
                Agency.CurrencyText = TextBoxCheckCurrency_CurrencyText.Text

                Agency.InternetPercent = NumericInputAPPromptsOptions_InternetMediaPercentOver.GetValue
                Agency.OutOfHomePercent = NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.GetValue
                Agency.PrintMediaPercent = NumericInputAPPromptsOptions_PrintMediaPercentOver.GetValue
                Agency.RadioPercent = NumericInputAPPromptsOptions_RadioMediaPercentOver.GetValue
                Agency.TelevisionPercent = NumericInputAPPromptsOptions_TelevisionMediaPercentOver.GetValue

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxAPMediaImportOptions_PendingApprovalTV.Checked, 1, 0), AdvantageFramework.Agency.Settings.IMP_PENDING_TV.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxAPMediaImportOptions_PendingApprovalRadio.Checked, 1, 0), AdvantageFramework.Agency.Settings.IMP_PENDING_RAD.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.Checked, 1, 0), AdvantageFramework.Agency.Settings.IMP_PENDING_PRI.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.Checked, 1, 0), AdvantageFramework.Agency.Settings.IMP_PENDING_OUT.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxAPMediaImportOptions_PendingApprovalInternet.Checked, 1, 0), AdvantageFramework.Agency.Settings.IMP_PENDING_INT.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.Checked, 1, 0), AdvantageFramework.Agency.Settings.IMP_PAYMENT_HOLD.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = {0} WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxMedia_AutomaticallyRemovePaymentHold.Checked, 1, 0), AdvantageFramework.Agency.Settings.AP_REMOVE_PMT_HOLD.ToString))

                SaveAPMediaImportApprovalAlertOptions(DbContext)

                Agency.CurrencyRateImportType = ComboBoxImportSettings_CurrencyRateImportFileType.GetSelectedValue
                Agency.IncomeOnlyImportType = ComboBoxImportSettings_IncomeOnlyImportFileType.GetSelectedValue

                Agency.UseGLFilter = CheckBoxGL_UseFilter.GetValue

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AdvantageFramework.CSIPreferredPartner.SaveClearedChecksImportPath(DataContext, TextBoxImportSettings_CSIClearedChecksImportPath.Text)

                End Using

                Agency.InvoiceTaxFlag = CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked

                SaveClientCashReceiptsPartialPaymentEnabled(DbContext)
                SaveClientCashReceiptsPartialPaymentRequired(DbContext)
                SaveClientCashReceiptsDefaultWriteOffGL(DbContext)

                SaveAvaTaxOptionsTab(DbContext)
                SaveAPApprovalAlertOptions(DbContext)

            End If

        End Sub
        Private Sub SaveTimesheetOptionsTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            If Agency IsNot Nothing Then

                Agency.UseBatchMethod = CheckBoxTimesheetOptions_UseBatchMethod.GetValue
                Agency.CopyTimesheetFeature = CheckBoxTimesheetOptions_UseCopyTimesheet.GetValue
                Agency.CheckClosedPeriods = CheckBoxTimesheetOptions_CheckClosedPostingPeriods.GetValue
                Agency.TimeCommentsRequired = CheckBoxTimesheetOptions_RequireTimeComments.GetValue
                'Agency.EnableProductCategory = CheckBoxTimesheetOptions_EnableProductCategoryEntry.GetValue
                Agency.SupervisorApprovalActive = CheckBoxTimesheetOptions_SupervisorApprovalActive.GetValue
                Agency.SupervisorCanEditTime = CheckBoxTimesheetOptions_SupervisiorCanEditTime.GetValue
                Agency.AutoAlertSupervisor = CheckBoxTimesheetOptions_AutoAlertSupervisor.GetValue
                Agency.DefaultDisplayDays = Convert.ToInt16(ComboBoxTimesheetOptions_DefaultDisplayDays.GetSelectedValue)
                Agency.QVAQuery = CheckBoxTimesheetOptions_AllowDrillDownTimesheet.GetValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    AdvantageFramework.Database.Procedures.Agency.UpdateTimesheetCopyHours(DbContext, CheckBoxTimesheetOptions_AllowCopyHours.Checked)

                End Using

                Agency.EmailSupervisor = CheckBoxMissingTimeOptions_NotifySupervisor.GetValue
                Agency.ITContactEmail = TextBoxMissingTimeOptions_ITEMail.Text

                If RadioButtonMissingTimeOptions_ByDay.Checked Then

                    Agency.WeeklyTimeType = 0

                ElseIf RadioButtonMissingTimeOptions_ByWeek.Checked Then

                    Agency.WeeklyTimeType = 1

                End If

                Agency.TimesheetAddUniqueRowWhenComment = CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.Checked

            End If

        End Sub
        Private Sub SaveMediaOptionsTab(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If Agency IsNot Nothing Then

                Agency.MediaImportDefault = ComboBoxSettings_MediaImportDefault.GetSelectedValue

                'Agency.NFusionDatasourceName = TextBoxSettings_NFusionDatasourceName.Text
                Agency.StrataConnectPath = TextBoxSettings_StrataConnectPath.Text
                Agency.ImportPath = TextBoxSettings_ImportPath.Text
                Agency.RenameFinanceFile = CheckBoxSettings_RenameFinanceFile.GetValue
                Agency.UseAPAccountOnImport = CheckBoxSettings_UseAPAccountOnImport.GetValue

                'Media Planning
                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    AdvantageFramework.Agency.SaveDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_INT, ComboBoxMediaPlanning_DefaultGroupingTypeInternet.GetSelectedValue)
                    AdvantageFramework.Agency.SaveDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_MAG, ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.GetSelectedValue)
                    AdvantageFramework.Agency.SaveDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_NEW, ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.GetSelectedValue)
                    AdvantageFramework.Agency.SaveDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_OUT, ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.GetSelectedValue)
                    AdvantageFramework.Agency.SaveDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_RAD, ComboBoxMediaPlanning_DefaultGroupingTypeRadio.GetSelectedValue)
                    AdvantageFramework.Agency.SaveDefaultGroupingType(DataContext, AdvantageFramework.Agency.Methods.Settings.DEF_GRP_TYPE_TV, ComboBoxMediaPlanning_DefaultGroupingTypeTV.GetSelectedValue)

                    AdvantageFramework.Agency.SaveMediaPlanningAddLinesToExistingOrder(DataContext, CheckBoxMediaPlanning_AddLinesToExistingOrder.Checked)

                End Using

                Agency.TelevisionFooterComments = TextBoxTelevision_FooterComments.Text
                Agency.RadioFooterComments = TextBoxRadio_FooterComments.Text
                Agency.NewspaperFooterComments = TextBoxNewspaper_FooterComments.Text
                Agency.MagazineFooterComments = TextBoxMagazine_FooterComments.Text
                Agency.OutOfHomeFooterComments = TextBoxOutOfHome_FooterComments.Text
                Agency.InternetFooterComments = TextBoxInternet_FooterComments.Text

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    AdvantageFramework.Agency.SaveWebFormTerms(DataContext, TextBoxSettingsForWebFormTerms_WebFormTerms.Text)

                    'AdvantageFramework.Agency.SaveMediaOrderLineSelectionInIncomeOnly(DataContext, CheckBoxSettings_MediaOrderLineInIncomeOnly.Checked)

                    AdvantageFramework.Agency.SaveMediaExcludeOrderPDFWithEmail(DataContext, CheckBoxSettings_MediaExcludeOrderPDFWithEmail.Checked)

                    AdvantageFramework.Agency.SaveBroadcastWorksheetDefaultRateType(DataContext, RadioButtonMediaOrders_Net.Checked)

                    AdvantageFramework.Agency.SaveVendorsRateTypeSetting(DataContext, CheckBoxMediaOrders_UseVendorsRateType.Checked)

                    AdvantageFramework.Agency.SaveMediaRequireCampaign(DataContext, CheckBoxMediaGeneral_MediaRequireCampaign.Checked)
                    AdvantageFramework.Agency.SaveMediaAutoBuyer(DataContext, CheckBoxMediaGeneral_MediaAutoBuyer.Checked)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MEDIATRAFFIC_STARTDT.ToString)

                    If Setting IsNot Nothing Then

                        Setting.Value = DateTimePickerSettings_MediaTrafficStartDate.GetValue

                        AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                    End If

                    AdvantageFramework.Agency.SaveCountry(DataContext, ComboBoxMediaOrders_Country.GetSelectedValue)

                End Using

                SaveMediaOrderExportPathFromAP(DbContext)
                SaveMediaOrderExportPathFromMediaPlan(DbContext)

            End If

        End Sub
        Private Sub SaveRequiredFieldsTab(ByVal Agency As AdvantageFramework.Database.Entities.Agency)

            If Agency IsNot Nothing Then

                Agency.AccountNumberRequired = CheckBoxLeftColumn_AccountNumber.GetValue
                Agency.ComplexityCodeRequired = CheckBoxLeftColumn_Complexity.GetValue
                Agency.AlertGroupRequired = CheckBoxLeftColumn_AlertGroup.GetValue
                Agency.CoopBillingCodeRequired = CheckBoxLeftColumn_CoopBilling.GetValue
                Agency.AdNumberRequired = CheckBoxLeftColumn_AdNumber.GetValue
                Agency.ClientReferenceRequired = CheckBoxLeftColumn_ClientReference.GetValue
                Agency.DateOpenedRequired = CheckBoxLeftColumn_DateOpened.GetValue
                Agency.Blackplate1Required = CheckBoxLeftColumn_Blackplate1.GetValue
                Agency.Blackplate2Required = CheckBoxLeftColumn_Blackplate2.GetValue
                Agency.ComponentBudgetRequired = CheckBoxLeftColumn_Budget.GetValue

                Agency.JobTypeRequired = CheckBoxMiddleColumn_JobType.GetValue
                Agency.PromotionRequired = CheckBoxMiddleColumn_Promotion.GetValue
                Agency.DueDateRequired = CheckBoxMiddleColumn_DueDate.GetValue
                Agency.SCFormatRequired = CheckBoxMiddleColumn_SalesClassFormat.GetValue
                Agency.DepartmentTeamRequired = CheckBoxMiddleColumn_DeptTeam.GetValue
                Agency.MarketCodeRequired = CheckBoxMiddleColumn_Market.GetValue
                Agency.ServiceFeeTypeRequired = CheckBoxMiddleColumn_ServiceFeeType.GetValue
                Agency.FormatAdSizeRequired = CheckBoxMiddleColumn_Format.GetValue
                Agency.ProductContactRequired = CheckBoxMiddleColumn_Contact.GetValue

                Agency.JobLogCustom1 = CheckBoxRightColumn_JobLogCustom1.GetValue
                Agency.JobLogCustom2 = CheckBoxRightColumn_JobLogCustom2.GetValue
                Agency.JobLogCustom3 = CheckBoxRightColumn_JobLogCustom3.GetValue
                Agency.JobLogCustom4 = CheckBoxRightColumn_JobLogCustom4.GetValue
                Agency.JobLogCustom5 = CheckBoxRightColumn_JobLogCustom5.GetValue
                Agency.JobComponentCustom1 = CheckBoxRightColumn_JobComponentCustom1.GetValue
                Agency.JobComponentCustom2 = CheckBoxRightColumn_JobComponentCustom2.GetValue
                Agency.JobComponentCustom3 = CheckBoxRightColumn_JobComponentCustom3.GetValue
                Agency.JobComponentCustom4 = CheckBoxRightColumn_JobComponentCustom4.GetValue
                Agency.JobComponentCustom5 = CheckBoxRightColumn_JobComponentCustom5.GetValue

                Agency.CampaignCodeRequired = CheckBoxJobsAndMedia_Campaign.GetValue
                Agency.FiscalPeriodRequired = CheckBoxJobsAndMedia_FiscalPeriod.GetValue

            End If

        End Sub
        Private Sub SaveMediaInvoiceDefault(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            If MediaInvoiceDefault IsNot Nothing Then

                MediaInvoiceDefault.InternetCustomFormat = SearchableComboBoxCustomInvoiceFormats_Internet.GetSelectedValue
                MediaInvoiceDefault.MagazineCustomFormat = SearchableComboBoxCustomInvoiceFormats_Magazine.GetSelectedValue
                MediaInvoiceDefault.NewspaperCustomFormat = SearchableComboBoxCustomInvoiceFormats_Newspaper.GetSelectedValue
                MediaInvoiceDefault.OutOfHomeCustomFormat = SearchableComboBoxCustomInvoiceFormats_OutOfHome.GetSelectedValue
                MediaInvoiceDefault.RadioCustomFormat = SearchableComboBoxCustomInvoiceFormats_Radio.GetSelectedValue
                MediaInvoiceDefault.TVCustomFormat = SearchableComboBoxCustomInvoiceFormats_Television.GetSelectedValue

            End If

        End Sub
        Private Sub SaveProductionInvoiceDefault(ByVal ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault)

            If ProductionInvoiceDefault IsNot Nothing Then

                ProductionInvoiceDefault.CustomFormatName = SearchableComboBoxCustomInvoiceFormats_Production.GetSelectedValue

            End If

        End Sub
        Private Sub SaveEstimateProcessAndExceedOptions()

            Dim EstimateProcessingOption As AdvantageFramework.Database.Entities.EstimateProcessingOption = Nothing
            Dim EstimateProcessingOptionID As Int16 = Nothing

            If DataGridViewEstimateProcessingExceedOptions_Options.HasRows Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For RowHandle = 0 To DataGridViewEstimateProcessingExceedOptions_Options.CurrentView.RowCount - 1

                        EstimateProcessingOptionID = DataGridViewEstimateProcessingExceedOptions_Options.CurrentView.GetRowCellValue(DataGridViewEstimateProcessingExceedOptions_Options.CurrentView.GetRowHandle(RowHandle), AdvantageFramework.Database.Entities.EstimateProcessingOption.Properties.OptionID.ToString)

                        EstimateProcessingOption = AdvantageFramework.Database.Procedures.EstimateProcessingOption.LoadByOptionID(DbContext, EstimateProcessingOptionID)

                        If EstimateProcessingOption IsNot Nothing Then

                            EstimateProcessingOption.ExceedOption = DataGridViewEstimateProcessingExceedOptions_Options.CurrentView.GetRowCellValue(DataGridViewEstimateProcessingExceedOptions_Options.CurrentView.GetRowHandle(RowHandle), AdvantageFramework.Database.Entities.EstimateProcessingOption.Properties.ExceedOption.ToString)
                            EstimateProcessingOption.AllowProcessing = DataGridViewEstimateProcessingExceedOptions_Options.CurrentView.GetRowCellValue(DataGridViewEstimateProcessingExceedOptions_Options.CurrentView.GetRowHandle(RowHandle), AdvantageFramework.Database.Entities.EstimateProcessingOption.Properties.AllowProcessing.ToString)
                            EstimateProcessingOption.DisplayMessage = DataGridViewEstimateProcessingExceedOptions_Options.CurrentView.GetRowCellValue(DataGridViewEstimateProcessingExceedOptions_Options.CurrentView.GetRowHandle(RowHandle), AdvantageFramework.Database.Entities.EstimateProcessingOption.Properties.DisplayMessage.ToString)

                            AdvantageFramework.Database.Procedures.EstimateProcessingOption.Update(DbContext, EstimateProcessingOption)

                        End If

                    Next

                End Using

            End If

        End Sub
        Private Sub LoadCustomReports(ByVal DbContext As AdvantageFramework.Database.DbContext)

            SearchableComboBoxCustomInvoiceFormats_Internet.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveInternetReports(DbContext)

            SearchableComboBoxCustomInvoiceFormats_Magazine.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveMagazineReports(DbContext)

            SearchableComboBoxCustomInvoiceFormats_Newspaper.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveNewspaperReports(DbContext)

            SearchableComboBoxCustomInvoiceFormats_OutOfHome.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveOutOfHomeReports(DbContext)

            SearchableComboBoxCustomInvoiceFormats_Production.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveProductionReports(DbContext)

            SearchableComboBoxCustomInvoiceFormats_Radio.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveRadioReports(DbContext)

            SearchableComboBoxCustomInvoiceFormats_Television.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveTVReports(DbContext)

        End Sub
        Private Sub LoadMaxEmailSize(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    NumericInputEmailAttachments_MaxFileSize.EditValue = DbContext.Database.SqlQuery(Of Long)("SELECT CAST(ISNULL([AGY_SETTINGS_VALUE], 0) AS bigint) FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'MAX_EMAIL_SIZE'").SingleOrDefault

                Catch ex As Exception
                    NumericInputEmailAttachments_MaxFileSize.EditValue = 0
                End Try

            End If

        End Sub
        Private Sub LoadAPOrderNotMatchingVendor(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.Checked = AdvantageFramework.Agency.GetOptionAPAllowOrderNotMatchingVendor(DbContext)

            End If

        End Sub
        Private Sub LoadAPImportDefaultInvoiceDescription(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                ComboBoxImportSettings_DefaultInvoiceDescription.SelectedValue = AdvantageFramework.Agency.GetOptionAPImportDefaultInvoiceDescription(DbContext)

            End If

        End Sub
        Private Sub SaveClientCashReceiptsDefaultWriteOffGL(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.GetSelectedValue, AdvantageFramework.Agency.Settings.CCR_DEF_WRITEOFF_GL.ToString))

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SaveClientCashReceiptsPartialPaymentEnabled(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = 'CCR_PART_PMT_ENABLE'", If(CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.Checked, 1, 0)))

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SaveClientCashReceiptsPartialPaymentRequired(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = 'CCR_PART_PMT_REQ'", If(CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.Checked, 1, 0)))

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SaveServiceTaxEnabled(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = 'SERVICE_TAX_ENABLED'", If(CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.Checked, 1, 0)))

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SaveDefaultAPDescriptionFromVendorAccount(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If DbContext IsNot Nothing Then

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.Checked, 1, 0), AdvantageFramework.Agency.Settings.AP_DEF_DESC_VEN_ACCT.ToString))

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SaveAPApprovalAlertOptions(ByVal DbContext As AdvantageFramework.Database.DbContext)

            'objects
            Dim DefaultTemplateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DefaultStateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DefaultAlertGroupSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            DefaultTemplateSqlParameter = New SqlClient.SqlParameter With {.ParameterName = "@Value"}
            DefaultStateSqlParameter = New SqlClient.SqlParameter With {.ParameterName = "@Value"}
            DefaultAlertGroupSqlParameter = New SqlClient.SqlParameter With {.ParameterName = "@Value"}

            If SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.HasASelectedValue Then

                DefaultTemplateSqlParameter.Value = SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.GetSelectedValue

            Else

                DefaultTemplateSqlParameter.Value = DBNull.Value

            End If

            If SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.HasASelectedValue Then

                DefaultStateSqlParameter.Value = SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.GetSelectedValue

            Else

                DefaultStateSqlParameter.Value = DBNull.Value

            End If

            If SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.HasASelectedValue Then

                DefaultAlertGroupSqlParameter.Value = SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.GetSelectedValue

            Else

                DefaultAlertGroupSqlParameter.Value = DBNull.Value

            End If

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = @Value WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AP_APPR_DFLT_TMPLT.ToString), DefaultTemplateSqlParameter)
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = @Value WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AP_APPR_DFLT_STATE.ToString), DefaultStateSqlParameter)
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = @Value WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AP_APPR_ALERT_GROUP.ToString), DefaultAlertGroupSqlParameter)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SaveAPMediaImportApprovalAlertOptions(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxMediaApprovalAlert_AlertBuyer.Checked, 1, 0), AdvantageFramework.Agency.Settings.IMP_ALERT_BUYER.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(CheckBoxMediaApprovalAlert_AlertAP.Checked, 1, 0), AdvantageFramework.Agency.Settings.AP_APPR_ALERT_AP.ToString))
                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.Checked, 1, 0), AdvantageFramework.Agency.Settings.AP_APPR_ALERT_USER.ToString))

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ToggleApplyTaxUponBilling()

            'objects
            Dim DialogResult As WinForm.MessageBox.DialogResults = WinForm.MessageBox.DialogResults.No

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.BILLING").FirstOrDefault = 0 Then

                    If CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked Then

                        DialogResult = AdvantageFramework.WinForm.MessageBox.Show("Selecting this option will permanently clear all unbilled resale tax amounts from production records.  This process cannot be reversed.  Media records will not be affected by this process. " & vbNewLine & vbNewLine &
                                                                                  "Resale tax will be calculated at the time of billing and will be applied to the invoice at the function level only (not at the item level) for production records that are marked taxable based on the system settings.  Using this method, resale tax will not be included at the item level on reports but can be reported on after billing by job, function or invoice. " & vbNewLine & vbNewLine &
                                                                                  "Are you sure you want to continue? ",
                                                                                  WinForm.MessageBox.MessageBoxButtons.YesNo, "WARNING", Windows.Forms.MessageBoxIcon.Warning)

                    Else

                        DialogResult = AdvantageFramework.WinForm.MessageBox.Show("Resale tax will be calculated and stored at the time of data entry. " &
                                                                                  "Data entered prior to deselecting this option will need to be modified in order for resale tax to be added. " & vbNewLine & vbNewLine &
                                                                                  "Do you want to continue? ", WinForm.MessageBox.MessageBoxButtons.YesNo)

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Cannot change this option when billing is selected.")

                End If

                If DialogResult = WinForm.MessageBox.DialogResults.Yes Then

                    If AdvantageFramework.Database.Procedures.Agency.ClearDetailTax(DbContext, CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked) = False Then

                        CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked = Not CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked

                        AdvantageFramework.WinForm.MessageBox.Show("Option failed!", WinForm.MessageBox.MessageBoxButtons.OK)

                    End If

                Else

                    CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked = Not CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked

                End If

            End Using

        End Sub
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.DataSource = AdvantageFramework.Database.Procedures.AlertGroup.Load(DbContext).Distinct

                SearchableComboBoxCurrency_HomeCurrency.DataSource = AdvantageFramework.Database.Procedures.CurrencyCode.LoadAllActive(DbContext).ToList

                SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.DataSource = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext).OrderBy(Function(Entity) Entity.Name)

                SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.DataSource = AdvantageFramework.Database.Procedures.AlertGroup.Load(DbContext).Distinct

                LoadCustomReports(DbContext)

                DbContext.Database.Connection.Close()

            End Using

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.DataSource = AdvantageFramework.Security.Database.Procedures.Report.LoadByReportType(SecurityDbContext, 94).OrderBy(Function(Report) Report.Number).ThenBy(Function(Report) Report.Name)

            End Using

        End Sub
        Private Sub LoadAlertAssignmentStates(ByVal TemplateID As Integer, ByVal SearchableComboBox As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox)

            'objects
            Dim CompletedAlertStateID As Integer = 0
            Dim AlertAssignmentTemplateStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateState) = Nothing
            Dim AlertAssignmentTemplateState As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing

            SearchableComboBox.SelectedValue = Nothing
            SearchableComboBox.Enabled = (TemplateID > 0)

            If SearchableComboBox.Enabled Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AlertAssignmentTemplateStates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, TemplateID).Include("AlertState").OrderBy(Function(Entity) Entity.SortOrder).ToList

                    Try

                        AlertAssignmentTemplateState = AlertAssignmentTemplateStates.SingleOrDefault(Function(Entity) Entity.IsCompleted.GetValueOrDefault(False) = True)

                        If AlertAssignmentTemplateState IsNot Nothing Then

                            CompletedAlertStateID = AlertAssignmentTemplateState.AlertStateID

                        End If

                    Catch ex As Exception
                        CompletedAlertStateID = 0
                    End Try

                    SearchableComboBox.DataSource = From AlertState In AlertAssignmentTemplateStates.Select(Function(Entity) Entity.AlertState)
                                                    Select New With {.ID = AlertState.ID,
                                                                     .Name = If(AlertState.ID = CompletedAlertStateID, AlertState.Name & "*", AlertState.Name)}

                End Using

            Else

                SearchableComboBox.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.AlertState)

            End If

            'EnableOrDisableActions()

        End Sub
        Private Function MustSaveUnsavedChanges() As Boolean

            ''objects
            Dim IsOkay As Boolean = False

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        IsOkay = Save()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Me.ClearValidations()

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Must save changes to continue.")

                End If

            Else

                IsOkay = True

            End If

            MustSaveUnsavedChanges = IsOkay

        End Function
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Saving...")
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                    Try

                        IsOkay = Save()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        IsOkay = False
                    End Try

                    If IsOkay = False Then

                        If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            IsOkay = True

                        End If

                    End If

                    Me.CloseWaitForm()
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    Me.ClearValidations()

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim ParentControl As Object = Nothing
            Dim FailedControl As Object = Nothing
            Dim ErrorMessage As String = ""
            Dim TabControl As AdvantageFramework.WinForm.Presentation.Controls.TabControl = Nothing
            Dim TabItem As DevComponents.DotNetBar.TabItem = Nothing
            Dim SavedRegistrySettings As Boolean = True
            Dim Saved As Boolean = False

            Me.SuspendedForLoading = True

            For Each TabItem In TabControlForm_AgencySetup.Tabs.OfType(Of DevComponents.DotNetBar.TabItem).ToList

                LoadAgency(TabItem)

            Next

            Me.SuspendedForLoading = False

            If Me.Validator AndAlso DataGridViewEstimateProcessingExceedOptions_Options.HasAnyInvalidRows = False AndAlso
                    DataGridViewAvaTaxOfficeCompanyCode_Mappings.HasAnyInvalidRows = False AndAlso
                    DataGridViewSystemAndAlertOptions_POP3EmailAccounts.HasAnyInvalidRows = False AndAlso
                    DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.HasAnyInvalidRows = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadAgencyDefault(DbContext)
                    ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadAgencyDefault(DbContext)

                    If _Agency IsNot Nothing Then

                        SaveInformationTab(_Agency)
                        SaveSystemAndAlertsTab(_Agency, SavedRegistrySettings)
                        SaveProductionOptionsTab(_Agency)
                        SaveAccountingOptionsTab(DbContext, _Agency)
                        SaveTimesheetOptionsTab(_Agency)
                        SaveMediaOptionsTab(DbContext, _Agency)
                        SaveRequiredFieldsTab(_Agency)
                        SaveMaxEmailSize(DbContext)
                        SaveAPOrderNotMatchingVendor(DbContext)

                        SaveEstimateProcessAndExceedOptions()

                        SaveAPImportDefaultInvoiceDescription(DbContext)

                        If MediaInvoiceDefault Is Nothing Then

                            MediaInvoiceDefault = New AdvantageFramework.Database.Entities.MediaInvoiceDefault

                            SaveMediaInvoiceDefault(MediaInvoiceDefault)

                            If MediaInvoiceDefault IsNot Nothing Then

                                MediaInvoiceDefault.DbContext = DbContext
                                MediaInvoiceDefault.ClientOrDefault = 1
                                AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Insert(DbContext, MediaInvoiceDefault)

                            End If

                        Else

                            SaveMediaInvoiceDefault(MediaInvoiceDefault)

                            If MediaInvoiceDefault IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Update(DbContext, MediaInvoiceDefault)

                            End If

                        End If

                        If ProductionInvoiceDefault Is Nothing Then

                            ProductionInvoiceDefault = New AdvantageFramework.Database.Entities.ProductionInvoiceDefault

                            SaveProductionInvoiceDefault(ProductionInvoiceDefault)

                            If ProductionInvoiceDefault IsNot Nothing Then

                                ProductionInvoiceDefault.DbContext = DbContext
                                ProductionInvoiceDefault.ClientOrDefault = 1
                                AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Insert(DbContext, ProductionInvoiceDefault)

                            End If

                        Else

                            SaveProductionInvoiceDefault(ProductionInvoiceDefault)

                            If ProductionInvoiceDefault IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Update(DbContext, ProductionInvoiceDefault)

                            End If

                        End If

                        For Each POP3EmailListenerAccount In DataGridViewSystemAndAlertOptions_POP3EmailAccounts.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Entities.POP3EmailListenerAccount).ToList

                            If String.IsNullOrWhiteSpace(POP3EmailListenerAccount.Password) = False Then

                                POP3EmailListenerAccount.Password = AdvantageFramework.Security.Encryption.Encrypt(POP3EmailListenerAccount.Password)

                            End If

                            If POP3EmailListenerAccount.AccountType = AdvantageFramework.Database.Entities.POP3EmailListenerAccountTypes.Default Then

                                _Agency.POP3UserName = POP3EmailListenerAccount.UserName
                                _Agency.POP3Password = POP3EmailListenerAccount.Password
                                _Agency.POP3DefaultReplyToEmail = POP3EmailListenerAccount.ReplyTo
                                _Agency.POP3DeleteMessages = POP3EmailListenerAccount.DeleteProcessed

                            Else

                                AdvantageFramework.Database.Procedures.POP3EmailListenerAccount.Update(DbContext, POP3EmailListenerAccount)

                            End If

                        Next

                        For Each POP3AutomatedAssignmentAccount In DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount).ToList

                            If String.IsNullOrWhiteSpace(POP3AutomatedAssignmentAccount.Password) = False Then

                                POP3AutomatedAssignmentAccount.Password = AdvantageFramework.Security.Encryption.Encrypt(POP3AutomatedAssignmentAccount.Password)

                            End If

                            AdvantageFramework.Database.Procedures.POP3AutomatedAssignmentAccount.Update(DbContext, POP3AutomatedAssignmentAccount)

                        Next

                        If AdvantageFramework.Database.Procedures.Agency.Update(DbContext, _Agency) Then

                            Saved = True

                            LoadAgency(TabControlForm_AgencySetup.SelectedTab)

                            If SavedRegistrySettings = False Then

                                AdvantageFramework.WinForm.MessageBox.Show("Failed to save Webvantage URL, Access Report Source Folder, and Access Report Temporary Folder.  Please make sure that you are running Advantage as ""Administrator"".")

                            End If

                            Me.ClearChanged()

                        End If

                    End If

                End Using

            Else

                If DataGridViewEstimateProcessingExceedOptions_Options.HasAnyInvalidRows Then

                    ErrorMessage = "Please fix invalid row(s)"
                    TabControlForm_AgencySetup.SelectedTab = TabItemAgencySetup_ProductionOptionsTab

                ElseIf DataGridViewAvaTaxOfficeCompanyCode_Mappings.HasAnyInvalidRows Then

                    ErrorMessage = "Please fix invalid row(s)"
                    TabControlForm_AgencySetup.SelectedTab = TabItemAgencySetup_AccountingOptionsTab
                    TabControlAccountingOptions_AccountingOptions.SelectedTab = TabItemAccountingOptions_AvaTaxTab

                ElseIf DataGridViewSystemAndAlertOptions_POP3EmailAccounts.HasAnyInvalidRows Then

                    ErrorMessage = "Please fix invalid row(s)"
                    TabControlForm_AgencySetup.SelectedTab = TabItemAgencySetup_SystemAndAlertOptions
                    TabControlSystemAndAlertOptions_SystemAndAlertOptions.SelectedTab = TabItemSystemAndAlertOptions_EmailSettingsTab

                ElseIf DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.HasAnyInvalidRows Then

                    ErrorMessage = "Please fix invalid row(s)"
                    TabControlForm_AgencySetup.SelectedTab = TabItemAgencySetup_SystemAndAlertOptions
                    TabControlSystemAndAlertOptions_SystemAndAlertOptions.SelectedTab = TabItemSystemAndAlertOptions_EmailSettingsTab

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    FailedControl = (Me.SuperValidator.LastFailedValidationResults.ToList.FirstOrDefault).Control

                    If FailedControl IsNot Nothing Then

                        ParentControl = FailedControl.Parent

                        Do While True

                            Try

                                If ParentControl Is Nothing Then

                                    Exit Do

                                ElseIf TypeOf ParentControl Is System.Windows.Forms.Form Then

                                    Exit Do

                                ElseIf TypeOf ParentControl.Parent Is System.Windows.Forms.Form Then

                                    Exit Do

                                End If

                            Catch ex As Exception
                                'ParentControl = Nothing
                            End Try

                            Try

                                If TypeOf ParentControl Is DevComponents.DotNetBar.TabControlPanel Then

                                    TabControl = DirectCast(ParentControl, DevComponents.DotNetBar.TabControlPanel).Parent
                                    TabControl.SelectedTab = DirectCast(ParentControl, DevComponents.DotNetBar.TabControlPanel).TabItem

                                    ParentControl = ParentControl.Parent

                                Else

                                    ParentControl = ParentControl.Parent

                                End If

                            Catch ex As Exception
                                ParentControl = Nothing
                            End Try

                        Loop

                        FailedControl.Focus()

                    End If

                End If

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Save = Saved

        End Function
        Private Sub EnableOrDisableAutomatedAssignments()

            If DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.IsNewItemRow Then

                ButtonItemAutomatedAssignments_Cancel.Enabled = True
                ButtonItemAutomatedAssignments_Delete.Enabled = False

            Else

                ButtonItemAutomatedAssignments_Cancel.Enabled = False
                ButtonItemAutomatedAssignments_Delete.Enabled = DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.HasOnlyOneSelectedRow

            End If

        End Sub
        Private Sub EnableOrDisableEmailOptions()

            'objects
            Dim IsOAuth2 As Boolean = False
            Dim LabelText As String = ""
            Dim LinkText As String = ""
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Token As String = Nothing

            If ComboBoxSMTPEmailSetup_AuthenticationMethod.SelectedValue = AdvantageFramework.Email.SmtpAuthenticationMethods.OAuth2 Then

                IsOAuth2 = True

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SMTP_OAUTH2_TOKEN.ToString)

                    If Setting IsNot Nothing Then

                        Token = Setting.Value

                    End If

                End Using

                LabelText = "Account is " & If(String.IsNullOrWhiteSpace(Token), "not ", "") & "authorized. "
                LinkText = String.Format("<a name=""{0}"">{0}</a>", If(String.IsNullOrWhiteSpace(Token), "Authorize", "Deauthorize"))

            End If

            If _Agency.IsASP = 1 Then

                LabelSMTPEmailSetup_OAuth2.Text = LabelText & "  Please use Webvantage to modify this setting."

            Else

                LabelSMTPEmailSetup_OAuth2.Text = LabelText & LinkText

            End If

            LabelSMTPEmailSetup_OAuth2.Visible = IsOAuth2
            TextBoxSMTPEmailSetup_DefaultPassword.Visible = Not IsOAuth2
            TextBoxSMTPEmailSetup_DefaultUserName.ReadOnly = IsOAuth2

        End Sub
        Private Sub ShowOrHideAdServingRibbon()

            RibbonBarOptions_AdServerFields.Visible = TabControlForm_AgencySetup.SelectedTab.Equals(TabItemAgencySetup_MediaOptionsTab) AndAlso TabControlMediaOptions_MediaOptions.SelectedTab.Equals(TabItemMediaOptions_AdServing)

        End Sub
        Private Sub ShowOrHideAutomatedAssignmentsRibbon()

            RibbonBarOptions_AutomatedAssignments.Visible = TabControlForm_AgencySetup.SelectedTab.Equals(TabItemAgencySetup_SystemAndAlertOptions) AndAlso TabControlSystemAndAlertOptions_SystemAndAlertOptions.SelectedTab.Equals(TabItemSystemAndAlertOptions_EmailSettingsTab)

        End Sub
        Private Sub ShowOrHideEmailRibbon()

            RibbonBarOptions_Email.Visible = TabControlForm_AgencySetup.SelectedTab.Equals(TabItemAgencySetup_SystemAndAlertOptions) AndAlso TabControlSystemAndAlertOptions_SystemAndAlertOptions.SelectedTab.Equals(TabItemSystemAndAlertOptions_EmailSettingsTab)

        End Sub
        Private Sub ToggleMediaApprovalOptions()

            GroupBoxMediaAndProduction_APMediaImportOptions.Enabled = CheckBoxMedia_ActivateApprovals.Checked
            CheckBoxMedia_AutomaticallyRemovePaymentHold.Enabled = CheckBoxMedia_ActivateApprovals.Checked

        End Sub
        Private Sub ToggleMediaApprovalAlertOptions()

            RadioButtonControlMediaApprovalAlert_AlertAPUser.Enabled = CheckBoxMediaApprovalAlert_AlertAP.Checked
            RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.Enabled = CheckBoxMediaApprovalAlert_AlertAP.Checked

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AgencySetupForm As AdvantageFramework.Maintenance.General.Presentation.AgencySetupForm = Nothing

            AgencySetupForm = New AdvantageFramework.Maintenance.General.Presentation.AgencySetupForm()

            AgencySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AgencySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim UserDefinedLabelList As Generic.List(Of AdvantageFramework.Database.Entities.UserDefinedLabel) = Nothing
            Dim UserDefinedLabel As AdvantageFramework.Database.Entities.UserDefinedLabel = Nothing
            Dim CheckWritingInProgress As Boolean = Nothing
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim EnumObjects As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            DataGridViewAvaTaxAddressValidation_Countries.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AvaTaxAddressValidationCountries)).ToList
                                                                        Select New AdvantageFramework.AvaTax.Classes.AddressValidationCountry(EnumObject.Description)).ToList

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.Agency)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
                ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
                ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

                ButtonItemFields_MoveUp.Image = AdvantageFramework.My.Resources.UpImage
                ButtonItemFields_MoveDown.Image = AdvantageFramework.My.Resources.DownImage

                ButtonItemAutomatedAssignments_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
                ButtonItemAutomatedAssignments_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

                ButtonItemEmail_TestSending.Image = AdvantageFramework.My.Resources.EmailSendImage
                ButtonItemEmail_TestReceiving.Image = AdvantageFramework.My.Resources.EmailPersonImage
                ButtonItemEmail_TestReceiving.Visible = False

                NumericInputEmailAttachments_MaxFileSize.Properties.Buttons.Clear()

                TextBoxAgencyInformation_Name.Enabled = False

                TabControlForm_AgencySetup.SelectedTab = TabItemAgencySetup_InformationTab
                TabControlSystemAndAlertOptions_SystemAndAlertOptions.SelectedTab = TabItemSystemAndAlertOptions_OptionsTab
                TabControlAccountingOptions_AccountingOptions.SelectedTab = TabItemAccountingOptions_AccountsPayableTab
                TabControlMediaOptions_MediaOptions.SelectedTab = TabItemMediaOptions_FooterCommentsTab
                TabControlFooterComments_FooterComments.SelectedTab = TabItemFooterComments_NewspaperTab

                TabControlForm_AgencySetup.Tag = Nothing

                ' input properties
                ' information tab
                TextBoxAgencyInformation_Name.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.Name)
                AddressControlAgencyInformation_Address.SetStreetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.Address)
                AddressControlAgencyInformation_Address.SetAddress2PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.Address2)
                AddressControlAgencyInformation_Address.SetCityPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.City)
                AddressControlAgencyInformation_Address.SetCountyPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.County)
                AddressControlAgencyInformation_Address.SetStatePropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.State)
                AddressControlAgencyInformation_Address.SetZipPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.Zip)
                AddressControlAgencyInformation_Address.SetCountryPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.Country)
                TextBoxAgencyInformation_Phone.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.Phone)

                ' system & alert options tab
                TextBoxWebvantageURL_URL.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.WebvantageURL)
                TextBoxClientPortalURL_URL.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.ClientPortalURL)
                TextBoxAccessReportSourceFolder_Path.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.AccessReportPath)
                TextBoxAccessReportTemporaryFolder_Path.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.AccessReportTemporaryPath)
                TextBoxDotNetFolder_Path.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.AccessReportPath)
                TextBoxSMTPEmailSetup_OutgoingServerAddress.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.SMTPServer)
                TextBoxSMTPEmailSetup_SenderAddress.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.SMTPUserName)
                TextBoxSMTPEmailSetup_DefaultUserName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.EmailUserName)
                TextBoxSMTPEmailSetup_DefaultPassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.EmailPassword)
                TextBoxSMTPEmailSetup_ReplyToAddress.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.ReplyToEmail)
                TextBoxPOP3EmailListenerSettings_ServerAddress.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.POP3Server)
                'TextBoxPOP3EmailListenerSettings_UserName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.POP3UserName)
                'TextBoxPOP3EmailListenerSettings_Password.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.POP3Password)
                'TextBoxPOP3EmailListenerSettings_ReplyToAddress.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.POP3DefaultReplyToEmail)
                NumericInputPOP3EmailListenerSettings_PortNumber.Properties.MaxValue = 99999
                NumericInputSMTPEmailSetup_PortNumber.Properties.MaxValue = 99999
                NumericInputPOP3EmailListenerSettings_PortNumber.Properties.MinValue = 0
                NumericInputSMTPEmailSetup_PortNumber.Properties.MinValue = 0
                'Production Options
                TextBoxEstimateDefaultComments_Comments.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.EstimateDefaultComments)
                TextBoxPurchaseOrderDefaultFooterComments_Comments.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.POFooterComments)

                DataGridViewEstimateProcessingExceedOptions_Options.OptionsView.ShowFooter = False

                'Accounting Options
                CheckBoxInvoiceTaxing_ApplyTaxUponBilling.ByPassUserEntryChanged = True
                TextBoxAccountsPayableDisbursement_PopupMessageInAP.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.APPOMessageText)
                TextBoxAccountsPayableDisbursement_RejectAPEntry.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.APPORejectText)
                NumericInputAPPromptsOptions_TelevisionMediaPercentOver.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.TelevisionPercent)
                NumericInputAPPromptsOptions_RadioMediaPercentOver.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.RadioPercent)
                NumericInputAPPromptsOptions_PrintMediaPercentOver.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.PrintMediaPercent)
                NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.OutOfHomePercent)
                NumericInputAPPromptsOptions_InternetMediaPercentOver.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.InternetPercent)

                CheckBoxAvaTax_EnableAvaTaxCalculation.ByPassUserEntryChanged = True

                'TextBoxCheckCurrency_Symbol.SetPropertySettings( PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.CurrencySymbol)
                TextBoxCheckCurrency_CurrencyText.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.CurrencyText)
                TextBoxCheckCurrency_CoinText.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.CoinText)
                ' timesheet options
                TextBoxMissingTimeOptions_ITEMail.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.ITContactEmail)
                ' media options
                'TextBoxSettings_NFusionDatasourceName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.NFusionDatasourceName)
                TextBoxSettings_StrataConnectPath.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.StrataConnectPath)
                TextBoxSettings_ImportPath.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.ImportPath)
                TextBoxTelevision_FooterComments.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.TelevisionFooterComments)
                TextBoxRadio_FooterComments.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.RadioFooterComments)
                TextBoxNewspaper_FooterComments.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.NewspaperFooterComments)
                TextBoxMagazine_FooterComments.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.MagazineFooterComments)
                TextBoxOutOfHome_FooterComments.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.OutOfHomeFooterComments)
                TextBoxInternet_FooterComments.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Agency.Properties.InternetFooterComments)
                TextBoxSettingsForWebFormTerms_WebFormTerms.MaxLength = 8000

                EnumObjects = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Exporting.MediaPlanOrderGroupings))

                ComboBoxMediaPlanning_DefaultGroupingTypeInternet.DataSource = EnumObjects.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                                  Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                  Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.FullFlight OrElse
                                                                                                                  Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList

                ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.DataSource = EnumObjects.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                  Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek).ToList

                ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.DataSource = EnumObjects.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                                   Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                   Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList

                ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.DataSource = EnumObjects.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                   Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                   Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList

                ComboBoxMediaPlanning_DefaultGroupingTypeRadio.DataSource = EnumObjects.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                               Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                               Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList

                ComboBoxMediaPlanning_DefaultGroupingTypeTV.DataSource = EnumObjects.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList

                ComboBoxMediaOrders_Country.SetPropertySettings("Country", GetType(Nullable(Of Integer)), False)

                ComboBoxMediaOrders_Country.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.DTO.Countries), False)

                ' Required Fields Custom Labels
                UserDefinedLabelList = AdvantageFramework.Database.Procedures.UserDefinedLabel.Load(DbContext).ToList

                CheckBoxRightColumn_JobComponentCustom1.Tag = "JOB_CMP_UDV1"
                CheckBoxRightColumn_JobComponentCustom2.Tag = "JOB_CMP_UDV2"
                CheckBoxRightColumn_JobComponentCustom3.Tag = "JOB_CMP_UDV3"
                CheckBoxRightColumn_JobComponentCustom4.Tag = "JOB_CMP_UDV4"
                CheckBoxRightColumn_JobComponentCustom5.Tag = "JOB_CMP_UDV5"
                CheckBoxRightColumn_JobLogCustom1.Tag = "JOB_LOG_UDV1"
                CheckBoxRightColumn_JobLogCustom2.Tag = "JOB_LOG_UDV2"
                CheckBoxRightColumn_JobLogCustom3.Tag = "JOB_LOG_UDV3"
                CheckBoxRightColumn_JobLogCustom4.Tag = "JOB_LOG_UDV4"
                CheckBoxRightColumn_JobLogCustom5.Tag = "JOB_LOG_UDV5"

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    NumericInputEmailAttachments_MaxFileSize.SecurityEnabled = False
                    TextBoxWebvantageURL_URL.SecurityEnabled = False
                    TextBoxClientPortalURL_URL.SecurityEnabled = False
                    TextBoxExportMediaOrders_MediaPlanPath.SecurityEnabled = False
                    TextBoxExportMediaOrders_APPath.SecurityEnabled = False
                    TextBoxSettings_ImportPath.SecurityEnabled = False
                    TextBoxSettings_StrataConnectPath.SecurityEnabled = False
                    TextBoxAccessReportTemporaryFolder_Path.SecurityEnabled = False
                    TextBoxAccessReportSourceFolder_Path.SecurityEnabled = False
                    TextBoxImportSettings_CSIClearedChecksImportPath.SecurityEnabled = False
                    TextBoxDotNetFolder_Path.SecurityEnabled = False
                    TextBoxProofingURL_URL.SecurityEnabled = False

                End If

                For Each UserDefinedLabel In UserDefinedLabelList.Where(Function(UDL) UDL.Label <> "" And UDL.Label IsNot Nothing)

                    For Each CheckBox In PanelUserSelectedRequiredFields_RightColumn.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)().Where(Function(CB) CB.Tag IsNot Nothing AndAlso CB.Tag.ToString.ToUpper = UserDefinedLabel.AssociatedTable.ToUpper)

                        CheckBox.Text = UserDefinedLabel.Label

                    Next

                Next

                Try

                    ComboBoxSMTPEmailSetup_AuthenticationMethod.DataSource = From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Email.SmtpAuthenticationMethods))
                                                                             Select [Code] = KeyValuePair.Key,
                                                                                    [Description] = KeyValuePair.Value

                    ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.DataSource = From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Email.POP3AuthenticationMethods))
                                                                                        Select [Code] = KeyValuePair.Key,
                                                                                               [Description] = KeyValuePair.Value

                Catch ex As Exception

                End Try

                ComboBoxCheckCurrecny_CurrencySymbols.DisplayMember = "Description"
                ComboBoxCheckCurrecny_CurrencySymbols.ValueMember = "Code"
                ComboBoxCheckCurrecny_CurrencySymbols.DataSource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.DefaultCurrencySymbols))
                                                                   Select Entity.Code, Entity.Description

                ComboBoxImportSettings_CurrencyRateImportFileType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ImportFileTypes))
                ComboBoxImportSettings_IncomeOnlyImportFileType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ImportFileTypes))
                ComboBoxImportSettings_DefaultInvoiceDescription.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Importing.APImportDefaultInvoiceDescription))

                ComboBoxSettings_MediaImportDefault.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaImportOptions))

                ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DataSource = AdvantageFramework.Agency.LoadAdjustCheckBodyLinesDownList()
                ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DataSource = AdvantageFramework.Agency.LoadAdjustCheckStubLinesUpList()
                ComboBoxTimesheetOptions_DefaultDisplayDays.DataSource = AdvantageFramework.Agency.LoadDefaultDisplayDaysList()

                ' Checkbox Controls sibling & child control settings
                CheckBoxAlertOptions_ExcludeAttachmentByDefault.SiblingControls.Add(CheckBoxAlertOptions_IncludeAttachmentsWithAlerts)
                CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.OldestSibling = CheckBoxAlertOptions_ExcludeAttachmentByDefault

                CheckBoxJobJacketOptions_EnableFileAttachments.ChildControls.Add(CheckBoxJobJacketOptions_EnableFileAttachmentDialog)

                CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.ChildControls.Add(SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup)

                CheckBoxAccountsPayableDisbursement_PopupMessageInAP.ChildControls.Add(TextBoxAccountsPayableDisbursement_PopupMessageInAP)
                CheckBoxAccountsPayableDisbursement_PopupMessageInAP.SiblingControls.Add(CheckBoxAccountsPayableDisbursement_RejectAPEntry)
                CheckBoxAccountsPayableDisbursement_RejectAPEntry.ChildControls.Add(TextBoxAccountsPayableDisbursement_RejectAPEntry)
                CheckBoxAccountsPayableDisbursement_RejectAPEntry.OldestSibling = CheckBoxAccountsPayableDisbursement_PopupMessageInAP

                CheckBoxTimesheetOptions_SupervisorApprovalActive.ChildControls.Add(CheckBoxTimesheetOptions_SupervisiorCanEditTime)
                CheckBoxTimesheetOptions_SupervisorApprovalActive.ChildControls.Add(CheckBoxTimesheetOptions_AutoAlertSupervisor)

                'CheckBoxTimesheetOptions_UseBatchMethod.SiblingControls.Add(CheckBoxTimesheetOptions_EnableProductCategoryEntry)
                'CheckBoxTimesheetOptions_EnableProductCategoryEntry.OldestSibling = CheckBoxTimesheetOptions_UseBatchMethod

                Try

                    CheckWritingInProgress = CBool(DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.CHECKWRITING").FirstOrDefault)

                Catch ex As Exception
                    CheckWritingInProgress = False
                End Try

                GroupBoxCheckWriting_CheckFormatSettings.Enabled = Not CheckWritingInProgress
                LabelAccountingOptions_CheckWritingInProgress.Visible = CheckWritingInProgress

                LoadMaxEmailSize(DbContext)

                LoadDropDownDataSources()

                LoadAPOrderNotMatchingVendor(DbContext)

                DbContext.Database.Connection.Close()

            End Using

            CheckBoxCurrency_ActivateMultipleCurrencies.ByPassUserEntryChanged = True
            SearchableComboBoxCurrency_HomeCurrency.ByPassUserEntryChanged = True

            Me.FormAction = WinForm.Presentation.FormActions.None

            LoadAgency(Nothing)

            'CheckBoxSettings_MediaOrderLineInIncomeOnly.Visible = False

            TabItemAccountingOptions_CurrencyTab.Visible = False

        End Sub
        Private Sub AgencySetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub AgencySetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub TabControlForm_AgencySetup_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_AgencySetup.SelectedTabChanging

            Me.SuspendedForLoading = True

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadAgency(e.NewTab)

            End If

        End Sub
        Private Sub TabControlForm_AgencySetup_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_AgencySetup.SelectedTabChanged

            Me.SuspendedForLoading = False

            ShowOrHideAdServingRibbon()

            ShowOrHideAutomatedAssignmentsRibbon()

            ShowOrHideEmailRibbon()

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ParentChild_SiblingCheckbox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxAccountsPayableDisbursement_PopupMessageInAP.CheckedChanged, CheckBoxAccountsPayableDisbursement_RejectAPEntry.CheckedChanged,
                                                                                                                            CheckBoxAccountsPayableDisbursement_RejectAPEntry.EnabledChanged, CheckBoxAccountsPayableDisbursement_PopupMessageInAP.EnabledChanged,
                                                                                                                            CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.CheckedChanged, CheckBoxAlertOptions_ExcludeAttachmentByDefault.CheckedChanged,
                                                                                                                            CheckBoxJobJacketOptions_EnableFileAttachments.CheckedChanged, CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.CheckedChanged,
                                                                                                                            CheckBoxTimesheetOptions_UseBatchMethod.CheckedChanged

            If TypeOf sender Is AdvantageFramework.WinForm.Presentation.Controls.CheckBox Then

                sender.HandleAllControls()

            End If

        End Sub
        Private Sub CheckBoxTimesheetOptions_SupervisorApprovalActive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxTimesheetOptions_SupervisorApprovalActive.CheckedChanged

            If sender Is CheckBoxTimesheetOptions_SupervisorApprovalActive Then

                CheckBoxTimesheetOptions_SupervisorApprovalActive.HandleAllControls()

                For Each CheckBox In CheckBoxTimesheetOptions_SupervisorApprovalActive.ChildControls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                    CheckBox.Checked = CheckBoxTimesheetOptions_SupervisorApprovalActive.Checked

                Next

            End If
        End Sub
        Private Sub CheckBoxJobJacketOptions_MarkJobComponentAsTaxable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.CheckedChanged

            Dim AlertMessage As String = ""
            Dim ShowAlert As Boolean = False
            Dim Updated As Boolean = False

            If sender Is CheckBoxJobJacketOptions_MarkJobComponentAsTaxable Then

                If CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Checked AndAlso Not CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Tag Then

                    AlertMessage = "All exisiting job/components will be changed to taxable and the product's tax code will be added to it. Do you want to continue?"
                    ShowAlert = True

                ElseIf Not CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Checked AndAlso CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Tag Then

                    AlertMessage = "All tax flags and tax codes will be removed from existing job/components. The tax structure will follow the function setup. Do you want to continue?"
                    ShowAlert = True

                End If

                If ShowAlert AndAlso AdvantageFramework.WinForm.MessageBox.Show(AlertMessage, WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Processing...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If AdvantageFramework.Agency.UpdateJobComponentTaxOption(DbContext, CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Checked) Then

                                CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Tag = CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Checked
                                Updated = True

                                If _Agency IsNot Nothing Then

                                    Try

                                        _Agency.JobComponentTaxable = Convert.ToInt16(CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Checked)

                                    Catch ex As Exception
                                        _Agency.JobComponentTaxable = _Agency.JobComponentTaxable
                                    End Try

                                    AdvantageFramework.Database.Procedures.Agency.Update(DbContext, _Agency)

                                End If

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                    If Not Updated Then

                        AdvantageFramework.WinForm.MessageBox.Show("There was a problem.")

                        CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Checked = CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Tag

                    End If

                Else

                    CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Checked = CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Tag

                End If

            End If

        End Sub
        'Private Sub CheckBoxJobJacketOptions_RequireUniqueClientReference_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        '    If sender Is CheckBoxJobJacketOptions_RequireUniqueClientReference Then

        '        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '            If CheckBoxJobJacketOptions_RequireUniqueClientReference.Checked AndAlso Not CheckBoxJobJacketOptions_RequireUniqueClientReference.Tag Then

        '                If AdvantageFramework.WinForm.MessageBox.Show("You have indicated you want your Job Client Reference to be unique. The client reference table will now be built. Do you want to continue? If no, the client reference options will be set to false.", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

        '                    AdvantageFramework.Agency.UpdateClientReference(DbContext, True)

        '                Else

        '                    CheckBoxJobJacketOptions_RequireUniqueClientReference.Checked = False

        '                End If

        '            Else

        '                AdvantageFramework.Agency.UpdateClientReference(DbContext, False)

        '            End If

        '        End Using

        '    End If

        'End Sub
        Private Sub ComboBoxSettings_MediaImportDefault_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxSettings_MediaImportDefault.SelectedValueChanged

            If ComboBoxSettings_MediaImportDefault.GetSelectedValue = "MM" Then

                CheckBoxSettings_RenameFinanceFile.Enabled = True

            Else

                CheckBoxSettings_RenameFinanceFile.Checked = False
                CheckBoxSettings_RenameFinanceFile.Enabled = False

            End If

        End Sub
        Private Sub RadioButtonControlAccessReportSourceFolder_UseGlobal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonControlWebvantageURL_UseGlobal.CheckedChanged, RadioButtonControlWebvantageURL_WorkstationOnly.CheckedChanged,
                                                                                                                                                     RadioButtonControlClientPortalURL_UseGlobal.CheckedChanged, RadioButtonControlClientPortalURL_WorkstationOnly.CheckedChanged,
                                                                                                                                                     RadioButtonControlAccessReportSourceFolder_UseGlobal.CheckedChanged, RadioButtonControlAccessReportSourceFolder_WorkstationOnly.CheckedChanged,
                                                                                                                                                     RadioButtonControlAccessReportTemporaryFolder_UseGlobal.CheckedChanged, RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.CheckedChanged,
                                                                                                                                                     RadioButtonControlDotNetFolder_UseGlobal.CheckedChanged, RadioButtonControlDotNetFolder_WorkstationOnly.CheckedChanged


            If sender.Checked Then

                If sender Is RadioButtonControlAccessReportSourceFolder_UseGlobal OrElse sender Is RadioButtonControlAccessReportSourceFolder_WorkstationOnly Then

                    TextBoxAccessReportSourceFolder_Path.Text = sender.Tag

                ElseIf sender Is RadioButtonControlAccessReportTemporaryFolder_UseGlobal OrElse sender Is RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly Then

                    TextBoxAccessReportTemporaryFolder_Path.Text = sender.Tag

                ElseIf sender Is RadioButtonControlWebvantageURL_UseGlobal OrElse sender Is RadioButtonControlWebvantageURL_WorkstationOnly Then

                    TextBoxWebvantageURL_URL.Text = sender.Tag

                ElseIf sender Is RadioButtonControlClientPortalURL_UseGlobal OrElse sender Is RadioButtonControlClientPortalURL_WorkstationOnly Then

                    TextBoxClientPortalURL_URL.Text = sender.Tag

                ElseIf sender Is RadioButtonControlDotNetFolder_UseGlobal OrElse sender Is RadioButtonControlDotNetFolder_WorkstationOnly Then

                    TextBoxDotNetFolder_Path.Text = sender.Tag

                End If

            End If

        End Sub
        Private Sub SetCurrencyText(ByRef CoinText As String, ByRef CurrencyText As String, ByVal DefaultCurrencyCoinText As AdvantageFramework.Database.Entities.DefaultCurrencyCoinText, ByVal DefaultCurrencyText As AdvantageFramework.Database.Entities.DefaultCurrencyText)

            Try

                CoinText = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.DefaultCurrencyCoinText))
                            Where Entity.Code = DefaultCurrencyCoinText.ToString
                            Select Entity.Description).FirstOrDefault

                CurrencyText = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.DefaultCurrencyText))
                                Where Entity.Code = DefaultCurrencyText.ToString
                                Select Entity.Description).FirstOrDefault

            Catch ex As Exception
                CoinText = ""
                CurrencyText = ""
            End Try

        End Sub
        Private Sub ComboBoxCheckCurrecny_CurrencySymbols_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxCheckCurrecny_CurrencySymbols.SelectedValueChanged

            Dim SelectedCurrency As AdvantageFramework.Database.Entities.DefaultCurrencySymbols = Nothing
            Dim CoinText As String = Nothing
            Dim CurrencyText As String = Nothing

            CoinText = TextBoxCheckCurrency_CurrencyText.Text
            CurrencyText = TextBoxCheckCurrency_CoinText.Text

            Select Case ComboBoxCheckCurrecny_CurrencySymbols.GetSelectedValue

                Case AdvantageFramework.Database.Entities.DefaultCurrencySymbols.BRL.ToString

                    SetCurrencyText(CoinText, CurrencyText, Database.Entities.DefaultCurrencyCoinText.BRL, Database.Entities.DefaultCurrencyText.BRL)

                Case AdvantageFramework.Database.Entities.DefaultCurrencySymbols.EUR.ToString

                    SetCurrencyText(CoinText, CurrencyText, Database.Entities.DefaultCurrencyCoinText.EUR, Database.Entities.DefaultCurrencyText.EUR)

                Case AdvantageFramework.Database.Entities.DefaultCurrencySymbols.GBP.ToString

                    SetCurrencyText(CoinText, CurrencyText, Database.Entities.DefaultCurrencyCoinText.GBP, Database.Entities.DefaultCurrencyText.GBP)

                Case AdvantageFramework.Database.Entities.DefaultCurrencySymbols.JPY.ToString

                    SetCurrencyText(CoinText, CurrencyText, Database.Entities.DefaultCurrencyCoinText.JPY, Database.Entities.DefaultCurrencyText.JPY)

                Case AdvantageFramework.Database.Entities.DefaultCurrencySymbols.USD.ToString

                    SetCurrencyText(CoinText, CurrencyText, Database.Entities.DefaultCurrencyCoinText.USD, Database.Entities.DefaultCurrencyText.USD)

            End Select

            TextBoxCheckCurrency_CurrencyText.Text = CurrencyText.ToUpper
            TextBoxCheckCurrency_CoinText.Text = CoinText.ToUpper

        End Sub
        Private Sub TextBoxComments_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxEstimateDefaultComments_Comments.GotFocus, TextBoxPurchaseOrderDefaultFooterComments_Comments.GotFocus,
                                                                                                          TextBoxMagazine_FooterComments.GotFocus, TextBoxNewspaper_FooterComments.GotFocus,
                                                                                                          TextBoxOutOfHome_FooterComments.GotFocus, TextBoxInternet_FooterComments.GotFocus,
                                                                                                          TextBoxRadio_FooterComments.GotFocus, TextBoxTelevision_FooterComments.GotFocus,
                                                                                                          TextBoxSettingsForWebFormTerms_WebFormTerms.GotFocus

            If Me.FormShown AndAlso TabControlFooterComments_FooterComments.IsSelectedTabChanging = False Then

                RibbonBarOptions_Text.Visible = True

                RibbonBarOptions_Text.Refresh()

            End If

        End Sub
        Private Sub TextBoxComments_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxEstimateDefaultComments_Comments.LostFocus, TextBoxPurchaseOrderDefaultFooterComments_Comments.LostFocus,
                                                                                                           TextBoxMagazine_FooterComments.LostFocus, TextBoxNewspaper_FooterComments.LostFocus,
                                                                                                           TextBoxOutOfHome_FooterComments.LostFocus, TextBoxInternet_FooterComments.LostFocus,
                                                                                                           TextBoxRadio_FooterComments.LostFocus, TextBoxTelevision_FooterComments.LostFocus,
                                                                                                           TextBoxSettingsForWebFormTerms_WebFormTerms.LostFocus

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = False

                RibbonBarOptions_Text.Refresh()

            End If

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf Me.ActiveControl Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

                DirectCast(Me.ActiveControl, AdvantageFramework.WinForm.Presentation.Controls.TextBox).CheckSpelling()

            End If

        End Sub
        Private Sub CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.CheckedChangedEx

            CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.Enabled = Not CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.Checked

            If CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.Checked Then

                CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.Checked = False

            End If

        End Sub
        Private Sub CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.CheckedChangedEx

            CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.Enabled = Not CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.Checked

            If CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.Checked Then

                CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.Checked = False

            End If

        End Sub
        Private Sub SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup_EnabledChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.EnabledChanged

            SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.SetRequired(SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Enabled)

            If SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Enabled = False Then

                Try

                    SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.SelectedValue = Nothing

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.Controls.ValidateControl(Me.FindForm, SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup)

            End If

        End Sub
        Private Sub CheckBoxInvoiceTaxing_ApplyTaxUponBilling_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxInvoiceTaxing_ApplyTaxUponBilling.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                ToggleApplyTaxUponBilling()

            End If

        End Sub
        Private Sub CheckBoxClientCashReceipts_EnablePartialPaymentDistribution_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.CheckedChanged

            CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.Enabled = CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.Checked

            If Not CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.Checked Then

                CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.Checked = False

            End If

        End Sub
        Private Sub ButtonAvaTax_TestConnection_Click(sender As Object, e As EventArgs) Handles ButtonAvaTax_TestConnection.Click

            Dim Result As String = Nothing

            If TextBoxAvaTax_AccountNumber.GetText IsNot Nothing AndAlso TextBoxAvaTax_LicenseKey.GetText IsNot Nothing AndAlso TextBoxAvaTax_URL.GetText IsNot Nothing Then

                If AdvantageFramework.AvaTax.PingTest(Me.TextBoxAvaTax_AccountNumber.GetText, Me.TextBoxAvaTax_LicenseKey.GetText, Me.TextBoxAvaTax_URL.GetText, Result) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Incorrect values supplied for Account Number, License Key, URL and/or AvaTax Company Code.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Result: " & Result)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Incorrect values supplied for Account Number, License Key, URL and/or AvaTax Company Code.")

            End If

        End Sub
        Private Sub CheckBoxAvaTax_EnableAvaTaxCalculation_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxAvaTax_EnableAvaTaxCalculation.CheckedChangedEx

            Dim Result As String = Nothing
            Dim Failed As Boolean = False
            Dim OfficeCompanyCodeList As Generic.List(Of AdvantageFramework.AvaTax.Classes.OfficeCompanyCode) = Nothing

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If e.NewChecked.Checked Then

                    If TextBoxAvaTax_AccountNumber.GetText IsNot Nothing AndAlso TextBoxAvaTax_LicenseKey.GetText IsNot Nothing AndAlso TextBoxAvaTax_URL.GetText IsNot Nothing Then

                        If AdvantageFramework.AvaTax.PingTest(Me.TextBoxAvaTax_AccountNumber.GetText, Me.TextBoxAvaTax_LicenseKey.GetText, Me.TextBoxAvaTax_URL.GetText, Result) Then

                            If CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked = False Then

                                CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked = True

                                ToggleApplyTaxUponBilling()

                                CheckBoxAvaTax_EnableAvaTaxCalculation.Checked = CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Checked

                            End If

                            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                Failed = Not AdvantageFramework.Database.Procedures.Agency.UpdateAvaTaxEnabled(DbContext, CheckBoxAvaTax_EnableAvaTaxCalculation.Checked)

                            End Using

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Cannot enable AvaTax.  Incorrect values supplied for Account Number, License Key, and/or URL.")

                            Failed = True

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Cannot enable AvaTax.  Incorrect values supplied for Account Number, License Key, and/or URL.")

                        Failed = True

                    End If

                Else

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Failed = Not AdvantageFramework.Database.Procedures.Agency.UpdateAvaTaxEnabled(DbContext, CheckBoxAvaTax_EnableAvaTaxCalculation.Checked)

                    End Using

                End If

                If Failed Then

                    CheckBoxAvaTax_EnableAvaTaxCalculation.Checked = Not CheckBoxAvaTax_EnableAvaTaxCalculation.Checked

                End If

            End If

            CheckBoxInvoiceTaxing_ApplyTaxUponBilling.AutoCheck = Not CheckBoxAvaTax_EnableAvaTaxCalculation.Checked

            OfficeCompanyCodeList = DataGridViewAvaTaxOfficeCompanyCode_Mappings.GetAllRowsDataBoundItems().OfType(Of AvaTax.Classes.OfficeCompanyCode).ToList()

            For Each OfficeCompanyCode In OfficeCompanyCodeList

                OfficeCompanyCode.SetRequired(AdvantageFramework.AvaTax.Classes.OfficeCompanyCode.Properties.AvaTaxCompanyCode.ToString, CheckBoxAvaTax_EnableAvaTaxCalculation.Checked)

            Next

            DataGridViewAvaTaxOfficeCompanyCode_Mappings.ValidateAllRows()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If Me.CheckForUnsavedChanges() Then

                SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Refreshing)

                Try

                    LoadAgency(Nothing)

                Catch ex As Exception

                End Try

                SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ComboBoxSMTPEmailSetup_AuthenticationMethod_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBoxSMTPEmailSetup_AuthenticationMethod.SelectionChangeCommitted

            EnableOrDisableEmailOptions()

        End Sub
        Private Sub LabelSMTPEmailSetup_OAuth2_MarkupLinkClick(sender As Object, e As DevComponents.DotNetBar.MarkupLinkClickEventArgs) Handles LabelSMTPEmailSetup_OAuth2.MarkupLinkClick

            'objects
            Dim AuthorizationCode As String = Nothing
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

            If String.IsNullOrWhiteSpace(TextBoxSMTPEmailSetup_SenderAddress.Text) Then

                AdvantageFramework.Navigation.ShowMessageBox("Please enter an email address.")

            Else

                If MustSaveUnsavedChanges() Then

                    Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Loading, "Launching Authorization window..." & System.Environment.NewLine & "(will time out after 2 mins)")

                    Try

                        Service = AdvantageFramework.GoogleServices.Service.Initialize(GoogleServices.Service.ServiceTypes.Gmail, Me.Session, Nothing, False)

                        If Service IsNot Nothing Then

                            If e.Name = "Authorize" Then

                                Service.Authorize()

                            ElseIf e.Name = "Deauthorize" Then

                                Service.Deauthorize()

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

                    EnableOrDisableEmailOptions()

                End If

            End If

        End Sub
        Private Sub CheckBoxCurrency_ActivateMultipleCurrencies_CheckedChanging(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxCurrency_ActivateMultipleCurrencies.CheckedChanging

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If Not SearchableComboBoxCurrency_HomeCurrency.HasASelectedValue Then

                    e.Cancel = True

                    AdvantageFramework.WinForm.MessageBox.Show("Please select HOME currency first.")

                ElseIf Not e.NewChecked.Checked Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Once the multi currency feature is activated, it cannot be de-activated.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, "", Windows.Forms.MessageBoxIcon.Warning, Windows.Forms.MessageBoxDefaultButton.Button2) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        If AdvantageFramework.WinForm.MessageBox.Show("Once activated, the selected HOME currency cannot be changed.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, "", Windows.Forms.MessageBoxIcon.Warning, Windows.Forms.MessageBoxDefaultButton.Button2) = AdvantageFramework.WinForm.MessageBox.DialogResults.No Then

                            e.Cancel = True

                        End If

                    Else

                        e.Cancel = True

                    End If

                    If Not e.Cancel Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DbContext.Database.ExecuteSqlCommand(String.Format("IF NOT EXISTS(SELECT 1 FROM dbo.CURRENCY_HEADER WHERE CURRENCY_CODE = '{0}') INSERT dbo.CURRENCY_HEADER (CURRENCY_CODE, INACTIVE_FLAG) VALUES ('{0}', 0)", SearchableComboBoxCurrency_HomeCurrency.GetSelectedValue))
                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGENCY] SET [MULTI_CRNCY] = 1, [HOME_CRNCY] = '{0}'", SearchableComboBoxCurrency_HomeCurrency.GetSelectedValue))
                            DbContext.Database.ExecuteSqlCommand("UPDATE [dbo].[PROD_INV_DEF] SET COL_OPT_XCHGE_AMTS = 1, COL_OPT_XCHGE_DEF = 1")
                            DbContext.Database.ExecuteSqlCommand("UPDATE [dbo].[MEDIA_INV_DEF] SET COL_OPT_XCHGE_AMTS = 1, COL_OPT_XCHGE_DEF = 1")
                            DbContext.Database.ExecuteSqlCommand("UPDATE [dbo].[COMBO_INV_DEF] SET COL_OPT_XCHGE_AMTS = 1, COL_OPT_XCHGE_DEF = 1")

                            SearchableComboBoxCurrency_HomeCurrency.ClearChanged()
                            SearchableComboBoxCurrency_HomeCurrency.ReadOnly = True

                            CheckBoxCurrency_ActivateMultipleCurrencies.AutoCheck = False

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub PictureEditCurrency_Image_Click(sender As Object, e As EventArgs) Handles PictureEditCurrency_Image.Click

            Dim WebAddress As String = Nothing

            WebAddress = "https://currencylayer.com/"

            Try

                Process.Start(WebAddress)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonCurrency_TestConnection_Click(sender As Object, e As EventArgs) Handles ButtonCurrency_TestConnection.Click

            Dim ErrorMessage As String = ""

            If String.IsNullOrWhiteSpace(TextBoxCurrency_APIKey.GetText) Then

                AdvantageFramework.WinForm.MessageBox.Show("Please enter an API Key.")

            Else

                If AdvantageFramework.Currency.TestConnection(TextBoxCurrency_APIKey.GetText, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Test connection was successful!")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Test connection failed." & System.Environment.NewLine & ErrorMessage)

                End If

            End If

        End Sub
        Private Sub CheckBoxTimesheetOptions_UseCopyTimesheet_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTimesheetOptions_UseCopyTimesheet.CheckedChanged

            CheckBoxTimesheetOptions_AllowCopyHours.Enabled = CheckBoxTimesheetOptions_UseCopyTimesheet.Checked

            If CheckBoxTimesheetOptions_UseCopyTimesheet.Checked = False Then

                CheckBoxTimesheetOptions_AllowCopyHours.Checked = False

            End If

        End Sub
        Private Sub ButtonRightSection_AddToAdServingFields_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_AddToAdServingFields.Click

            'objects
            Dim ObjectList As IEnumerable(Of Object) = Nothing
            Dim AdServerPlacementFieldList As Generic.List(Of AdvantageFramework.Database.Entities.AdServerPlacementField) = Nothing
            Dim AdServerPlacementField As AdvantageFramework.Database.Entities.AdServerPlacementField = Nothing
            Dim Counter As Integer = 0

            If DataGridViewLeftSection_AvailableFields.HasASelectedRow Then

                AdServerPlacementFieldList = DataGridViewRightSection_AdServingFields.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.AdServerPlacementField).ToList

                Counter = AdServerPlacementFieldList.Count

                ObjectList = DataGridViewLeftSection_AvailableFields.GetAllSelectedRowsDataBoundItems

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each Obj In ObjectList

                            AdServerPlacementField = New AdvantageFramework.Database.Entities.AdServerPlacementField
                            AdServerPlacementField.DbContext = DbContext

                            AdServerPlacementField.FieldOrder = Counter + 1
                            AdServerPlacementField.FieldCode = Obj.Code
                            AdServerPlacementField.FieldName = Obj.Description

                            AdvantageFramework.Database.Procedures.AdServerPlacementField.Insert(DbContext, AdServerPlacementField)

                            Counter += 1

                        Next

                        LoadAdServingFields(DbContext)

                    End Using

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveFromAdServingFields_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_RemoveFromAdServingFields.Click

            'objects
            Dim AdServerPlacementFieldList As Generic.List(Of AdvantageFramework.Database.Entities.AdServerPlacementField) = Nothing

            If DataGridViewRightSection_AdServingFields.HasASelectedRow Then

                AdServerPlacementFieldList = DataGridViewRightSection_AdServingFields.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.AdServerPlacementField).ToList

                Try

                    Me.ShowWaitForm("Deleting...")

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each AdServerPlacementField In AdServerPlacementFieldList

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.AD_SERVER_PLACEMENT_FIELD WHERE FIELD_CODE = '{0}'", AdServerPlacementField.FieldCode))

                        Next

                        LoadAdServingFields(DbContext)

                        SetAdServingFieldOrder(DbContext)

                    End Using

                Catch ex As Exception

                Finally
                    Me.CloseWaitForm()
                End Try

            End If

        End Sub
        Private Sub TabControlMediaOptions_MediaOptions_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlMediaOptions_MediaOptions.SelectedTabChanged

            ShowOrHideAdServingRibbon()

        End Sub
        Private Sub ButtonItemFields_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonItemFields_MoveDown.Click

            'objects
            Dim AdServerPlacementField As AdvantageFramework.Database.Entities.AdServerPlacementField = Nothing

            AdServerPlacementField = DataGridViewRightSection_AdServingFields.GetFirstSelectedRowDataBoundItem

            If AdServerPlacementField IsNot Nothing Then

                MoveAdServerField(AdServerPlacementField, False)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SetAdServingFieldOrder(DbContext)

                    LoadAdServingFields(DbContext)

                End Using

            End If

        End Sub
        Private Sub ButtonItemFields_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonItemFields_MoveUp.Click

            'objects
            Dim AdServerPlacementField As AdvantageFramework.Database.Entities.AdServerPlacementField = Nothing

            AdServerPlacementField = DataGridViewRightSection_AdServingFields.GetFirstSelectedRowDataBoundItem

            If AdServerPlacementField IsNot Nothing Then

                MoveAdServerField(AdServerPlacementField, True)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SetAdServingFieldOrder(DbContext)

                    LoadAdServingFields(DbContext)

                End Using

            End If

        End Sub
        Private Sub DataGridViewRightSection_AdServingFields_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_AdServingFields.SelectionChangedEvent

            ButtonItemFields_MoveUp.Enabled = If(DataGridViewRightSection_AdServingFields.HasOnlyOneSelectedRow, Not DataGridViewRightSection_AdServingFields.CurrentView.IsFirstRow, False)
            ButtonItemFields_MoveDown.Enabled = If(DataGridViewRightSection_AdServingFields.HasOnlyOneSelectedRow, Not DataGridViewRightSection_AdServingFields.CurrentView.IsLastRow, False)

        End Sub
        Private Sub DataGridViewSystemAndAlertOptions_POP3EmailAccounts_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewSystemAndAlertOptions_POP3EmailAccounts.ValidateRowEvent

            'objects
            Dim POP3EmailListenerAccount As AdvantageFramework.Database.Entities.POP3EmailListenerAccount = Nothing

            POP3EmailListenerAccount = DirectCast(DataGridViewSystemAndAlertOptions_POP3EmailAccounts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.POP3EmailListenerAccount)

            If Not String.IsNullOrWhiteSpace(POP3EmailListenerAccount.UserName) Then

                If DataGridViewSystemAndAlertOptions_POP3EmailAccounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.POP3EmailListenerAccount).Any(Function(acct) Not String.IsNullOrWhiteSpace(acct.UserName) AndAlso acct.UserName.ToUpper = POP3EmailListenerAccount.UserName.ToString.ToUpper AndAlso acct.ID <> POP3EmailListenerAccount.ID) Then

                    POP3EmailListenerAccount.ValidateUserName(False)
                    e.ErrorText = POP3EmailListenerAccount.Error

                End If

            End If

        End Sub
        Private Sub DataGridViewSystemAndAlertOptions_POP3EmailAccounts_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewSystemAndAlertOptions_POP3EmailAccounts.ValidatingEditorEvent

            'objects
            Dim CurrentPOP3EmailListenerAccount As AdvantageFramework.Database.Entities.POP3EmailListenerAccount = Nothing
            Dim POP3EmailListenerAccount As AdvantageFramework.Database.Entities.POP3EmailListenerAccount = Nothing
            Dim POP3EmailListenerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.POP3EmailListenerAccount) = Nothing

            If DataGridViewSystemAndAlertOptions_POP3EmailAccounts.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.POP3EmailListenerAccount.Properties.UserName.ToString Then

                POP3EmailListenerAccounts = DataGridViewSystemAndAlertOptions_POP3EmailAccounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.POP3EmailListenerAccount).ToList
                CurrentPOP3EmailListenerAccount = DataGridViewSystemAndAlertOptions_POP3EmailAccounts.CurrentView.GetFocusedRow

                If Not String.IsNullOrWhiteSpace(e.Value) Then

                    If POP3EmailListenerAccounts.Any(Function(acct) acct.ID <> CurrentPOP3EmailListenerAccount.ID AndAlso Not String.IsNullOrWhiteSpace(acct.UserName) AndAlso acct.UserName.ToUpper = e.Value.ToString.ToUpper) Then

                        CurrentPOP3EmailListenerAccount.ValidateUserName(False)

                    End If

                End If

                CurrentPOP3EmailListenerAccount = POP3EmailListenerAccounts.Where(Function(acct) acct.ID = CurrentPOP3EmailListenerAccount.ID).SingleOrDefault
                CurrentPOP3EmailListenerAccount.UserName = e.Value

                For Each POP3EmailListenerAccount In POP3EmailListenerAccounts

                    If POP3EmailListenerAccount.ID <> CurrentPOP3EmailListenerAccount.ID Then

                        If POP3EmailListenerAccount.UserName IsNot Nothing Then

                            If POP3EmailListenerAccounts.Where(Function(acct) acct.UserName = POP3EmailListenerAccount.UserName.ToString).Count > 1 Then

                                POP3EmailListenerAccount.ValidateUserName(False)

                            Else

                                POP3EmailListenerAccount.ValidateUserName(True)

                            End If

                        End If

                    End If

                Next

                DataGridViewSystemAndAlertOptions_POP3EmailAccounts.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub CheckBoxMedia_ActivateApprovals_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMedia_ActivateApprovals.CheckedChanged

            ToggleMediaApprovalOptions()

        End Sub
        Private Sub SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.EditValueChanged

            LoadAlertAssignmentStates(SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.GetSelectedValue, SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState)

        End Sub
        Private Sub CheckBoxMediaApprovalAlert_AlertAP_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMediaApprovalAlert_AlertAP.CheckedChanged

            ToggleMediaApprovalAlertOptions()

        End Sub
        Private Sub DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.QueryPopupNeedDatasourceEvent

            'objects
            Dim JobNumber As Nullable(Of Integer) = 0
            Dim AlertTemplateID As Nullable(Of Integer) = 0

            If FieldName = AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobComponentNumber.ToString Then

                JobNumber = DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.GetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobNumber.ToString)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext)
                                  Where Entity.JobNumber = JobNumber
                                  Select Entity).ToList

                    OverrideDefaultDatasource = True

                End Using

            ElseIf FieldName = AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString Then

                AlertTemplateID = DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.GetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertTemplateID.ToString)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, AlertTemplateID.Value).Include("AlertState")
                                  Select New With {.Name = Entity.AlertState.Name,
                                                   .ID = Entity.AlertState.ID}).ToList

                    OverrideDefaultDatasource = True

                End Using

            ElseIf FieldName = AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertTemplateID.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext)
                                  Select New With {.Name = Entity.Name,
                                                   .ID = Entity.ID}).ToList

                    OverrideDefaultDatasource = True

                End Using

            End If

        End Sub
        Private Sub DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.ShowingEditorEvent

            If DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobComponentNumber.ToString Then

                If DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.GetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobNumber.ToString) Is Nothing OrElse
                        DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.GetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobNumber.ToString) = 0 Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString Then

                If DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.GetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertTemplateID.ToString) Is Nothing OrElse
                        DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.GetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertTemplateID.ToString) = 0 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CellValueChangedEvent

            'objects
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim AlertTemplateID As Integer = 0
            Dim AlertStateID As Integer = 0
            Dim AlertAssignmentTemplateState As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing
            Dim POP3AutomatedAssignmentAccount As AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobNumber.ToString Then

                Try

                    JobNumber = e.Value

                Catch ex As Exception
                    JobNumber = 0
                End Try

                If JobNumber > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If AdvantageFramework.Database.Procedures.JobComponent.LoadAllByJobNumber(DbContext, JobNumber).Count = 1 Then

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadAllByJobNumber(DbContext, JobNumber).FirstOrDefault

                            If JobComponent IsNot Nothing Then

                                DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobComponentNumber.ToString, JobComponent.Number)

                            Else

                                DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobComponentNumber.ToString, Nothing)

                            End If

                        Else

                            DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobComponentNumber.ToString, Nothing)

                        End If

                    End Using

                Else

                    DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobComponentNumber.ToString, Nothing)

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobComponentNumber.ToString Then

                JobNumber = DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.JobNumber.ToString)

                Try

                    JobComponentNumber = e.Value

                Catch ex As Exception
                    JobComponentNumber = 0
                End Try

                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                        If JobComponent IsNot Nothing Then

                            If JobComponent.AlertAssignmentTemplateID.HasValue AndAlso JobComponent.AlertAssignmentTemplateID.Value > 0 Then

                                DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertTemplateID.ToString, JobComponent.AlertAssignmentTemplateID.Value)

                            End If

                        End If

                    End Using

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertTemplateID.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        AlertTemplateID = e.Value

                    Catch ex As Exception
                        AlertTemplateID = 0
                    End Try

                    If AlertTemplateID > 0 Then

                        If AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, AlertTemplateID).Any Then

                            AlertAssignmentTemplateState = (From Entity In AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, AlertTemplateID)
                                                            Order By Entity.SortOrder
                                                            Select Entity).FirstOrDefault

                            If AlertAssignmentTemplateState IsNot Nothing Then

                                DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString, AlertAssignmentTemplateState.AlertStateID)

                            Else

                                DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString, Nothing)

                            End If

                        Else

                            DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString, Nothing)

                        End If

                    Else

                        DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString, Nothing)

                    End If

                    POP3AutomatedAssignmentAccount = DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.GetFocusedRow

                    POP3AutomatedAssignmentAccount.ValidateEntityProperty(AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString, True, POP3AutomatedAssignmentAccount.AlertStateID)

                    DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.RefreshData()

                End Using

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AlertTemplateID = DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertTemplateID.ToString)

                    Try

                        AlertStateID = e.Value

                    Catch ex As Exception
                        AlertStateID = 0
                    End Try

                    If AlertTemplateID > 0 AndAlso AlertStateID > 0 Then

                        AlertAssignmentTemplateState = (From Entity In AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, AlertTemplateID)
                                                        Where Entity.AlertStateID = AlertStateID
                                                        Order By Entity.SortOrder
                                                        Select Entity).FirstOrDefault

                        If AlertAssignmentTemplateState IsNot Nothing AndAlso String.IsNullOrEmpty(AlertAssignmentTemplateState.DefaultEmployeeCode) = False Then

                            DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.EmployeeCode.ToString, AlertAssignmentTemplateState.DefaultEmployeeCode)

                        Else

                            DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.EmployeeCode.ToString, Nothing)

                        End If

                    Else

                        DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.SetRowCellValue(DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.EmployeeCode.ToString, Nothing)

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts_AddNewRowEvent(RowObject As Object) Handles DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.AddNewRowEvent

            'objects
            Dim POP3AutomatedAssignmentAccount As AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount Then

                Me.ShowWaitForm("Processing...")

                POP3AutomatedAssignmentAccount = RowObject

                If POP3AutomatedAssignmentAccount.SuccessMessage = Nothing Then

                    POP3AutomatedAssignmentAccount.SuccessMessage = String.Empty

                End If

                If POP3AutomatedAssignmentAccount.FailureMessage = Nothing Then

                    POP3AutomatedAssignmentAccount.FailureMessage = String.Empty

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If POP3AutomatedAssignmentAccount.IsEntityBeingAdded() Then

                        POP3AutomatedAssignmentAccount.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.POP3AutomatedAssignmentAccount.Insert(DbContext, POP3AutomatedAssignmentAccount)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.SelectionChangedEvent

            EnableOrDisableAutomatedAssignments()

        End Sub
        Private Sub DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.InitNewRowEvent

            EnableOrDisableAutomatedAssignments()

        End Sub
        Private Sub DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.ValidatingEditorEvent

            'objects
            Dim POP3AutomatedAssignmentAccount As AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount = Nothing

            If DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertTemplateID.ToString Then

                POP3AutomatedAssignmentAccount = DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.GetFocusedRow

                If e.Value <> Nothing AndAlso e.Value > 0 Then

                    POP3AutomatedAssignmentAccount.SetRequired(AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString, True)

                Else

                    POP3AutomatedAssignmentAccount.SetRequired(AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString, False)

                End If

                POP3AutomatedAssignmentAccount.ValidateEntityProperty(AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount.Properties.AlertStateID.ToString, True, POP3AutomatedAssignmentAccount.AlertStateID)

                DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub TabControlSystemAndAlertOptions_SystemAndAlertOptions_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlSystemAndAlertOptions_SystemAndAlertOptions.SelectedTabChanged

            ShowOrHideAutomatedAssignmentsRibbon()

            ShowOrHideEmailRibbon()

        End Sub
        Private Sub ButtonItemAutomatedAssignments_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemAutomatedAssignments_Cancel.Click

            DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CancelNewItemRow()

            EnableOrDisableAutomatedAssignments()

        End Sub
        Private Sub ButtonItemAutomatedAssignments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemAutomatedAssignments_Delete.Click

            'objects
            Dim POP3AutomatedAssignmentAccount As AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.HasASelectedRow Then

                DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    POP3AutomatedAssignmentAccount = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    POP3AutomatedAssignmentAccount = Nothing
                                End Try

                                If POP3AutomatedAssignmentAccount IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.POP3AutomatedAssignmentAccount.Delete(DbContext, POP3AutomatedAssignmentAccount) Then

                                        DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

            EnableOrDisableAutomatedAssignments()

        End Sub
        Private Sub ButtonItemEmail_TestSending_Click(sender As Object, e As EventArgs) Handles ButtonItemEmail_TestSending.Click

            AdvantageFramework.Maintenance.General.Presentation.AgencyTestEmailDialog.ShowFormDialog(_Agency)

        End Sub

#End Region

#End Region

    End Class

End Namespace
