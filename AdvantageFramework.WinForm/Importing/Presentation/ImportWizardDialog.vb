Namespace Importing.Presentation

	Public Class ImportWizardDialog

		Private Delegate Sub SetMinimumDelegate(ByVal ProgressBar As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar, ByVal Minimum As Integer)
		Private Delegate Sub SetMaximumDelegate(ByVal ProgressBar As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar, ByVal Maximum As Integer)
		Private Delegate Sub SetValueDelegate(ByVal ProgressBar As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar, ByVal Value As Integer)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _ImportType As AdvantageFramework.Importing.ImportType = Nothing
		Private _ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
		Private _BatchName As String = Nothing
		Private _ImportTemplateID As Integer = 0
		Private _AutoTrimOverflowData As Boolean = False
		Private _ColumnHeaders As Boolean = False
		Private _BankCode As String = Nothing
		Private _CSIReconciliationTemplate As AdvantageFramework.Importing.CSIReconciliationTemplates = AdvantageFramework.Importing.CSIReconciliationTemplates.ComDataAC29File
		Private WithEvents _BackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing
		Private _AgencyImportPath As String = ""
        Private _IsAgencyASP As Boolean = False
        Private _FileFilter As AdvantageFramework.FileSystem.FileFilters = Nothing
        Private _DefaultDirectory As String = Nothing
		Private _IsCSIPreferredPartnerImport As Boolean = False
		Private WithEvents _CSIPreferredPartnerDownloadBackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing
		Private WithEvents _CSIPreferredPartnerImportBackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing
		Private _DownloadedFiles As Generic.List(Of String) = Nothing
		Private WithEvents _MediaVCCBackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing
		Private _TransactionStartDate As Date = Nothing
		Private _TransactionEndDate As Date = Nothing
        Private _MediaRFPHeaderID As Nullable(Of Integer) = Nothing
        Private _MediaBroadcastWorksheetMarketID As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ImportType As AdvantageFramework.Importing.ImportType
            Get
                ImportType = _ImportType
            End Get
        End Property
        Public ReadOnly Property ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes
            Get
                ImportTemplateType = _ImportTemplateType
            End Get
        End Property
        Public ReadOnly Property BatchName As String
            Get
                BatchName = _BatchName
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ImportType As AdvantageFramework.Importing.ImportType, ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, ByRef BatchName As String, ByVal IsCSIPreferredPartnerImport As Boolean,
                        ByVal MediaRFPHeaderID As Nullable(Of Integer), ByVal MediaBroadcastWorksheetMarketID As Nullable(Of Integer))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ImportType = ImportType
            _ImportTemplateType = ImportTemplateType
            _BatchName = BatchName
            _IsCSIPreferredPartnerImport = IsCSIPreferredPartnerImport
            _MediaRFPHeaderID = MediaRFPHeaderID
            _MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

        End Sub
        Private Sub ImportingProgressUpdate(ByVal ProgressValue As Integer)

            _BackgroundWorker.ReportProgress(ProgressValue)

        End Sub
        Private Sub SetupImportingProgress(ByVal MinValue As Integer, ByVal MaxValue As Integer, ByVal Value As Integer)

            SetMinimum(ProgressBarImportingPage_Progress, MinValue)
            SetMaximum(ProgressBarImportingPage_Progress, MaxValue)
            SetValue(ProgressBarImportingPage_Progress, Value)

        End Sub
        Private Sub OverallImportingProgressUpdate(ByVal ProgressValue As Integer)

            _BackgroundWorker.ReportProgress(ProgressValue, "Overall")

        End Sub
        Private Sub SetupOverallImportingProgress(ByVal MinValue As Integer, ByVal MaxValue As Integer, ByVal Value As Integer)

            SetMinimum(ProgressBarImportingPage_OverallProgress, MinValue)
            SetMaximum(ProgressBarImportingPage_OverallProgress, MaxValue)
            SetValue(ProgressBarImportingPage_OverallProgress, Value)

        End Sub
        Public Sub SetMinimum(ByVal ProgressBar As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar, ByVal Minimum As Integer)

            If ProgressBar.InvokeRequired Then

                ProgressBar.Invoke(New SetMinimumDelegate(AddressOf SetMinimum), New Object() {ProgressBar, Minimum})

            Else

                ProgressBar.Minimum = Minimum

            End If

        End Sub
        Public Sub SetMaximum(ByVal ProgressBar As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar, ByVal Maximum As Integer)

            If ProgressBar.InvokeRequired Then

                ProgressBar.Invoke(New SetMaximumDelegate(AddressOf SetMaximum), New Object() {ProgressBar, Maximum})

            Else

                ProgressBar.Maximum = Maximum

            End If

        End Sub
        Public Sub SetValue(ByVal ProgressBar As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar, ByVal Value As Integer)

            If ProgressBar.InvokeRequired Then

                ProgressBar.Invoke(New SetValueDelegate(AddressOf SetValue), New Object() {ProgressBar, Value})

            Else

                ProgressBar.Value = Value

            End If

        End Sub
        Private Sub LoadDefaults()

            WizardPageWizard_SelectBank.Visible = False
            WizardPageWizard_CSIPreferredPartnerTemplate.Visible = False
            WizardPageWizard_CSIPreferredPartnerDownload.Visible = False
            WizardPageWizard_SelectDateRange.Visible = False

            CheckBoxSelectImportOptions_AutoTrimOverflowData.Checked = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                If _IsAgencyASP Then

                    _AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\")

                    _AgencyImportPath = AdvantageFramework.Importing.GetHostedDirectory(_ImportTemplateType, _AgencyImportPath)

                    If _ImportTemplateType = ImportTemplateTypes.MediaRFP_4As Then

                        If My.Computer.FileSystem.DirectoryExists(System.IO.Path.Combine(_AgencyImportPath, Session.UserCode)) = False Then

                            My.Computer.FileSystem.CreateDirectory(System.IO.Path.Combine(_AgencyImportPath, Session.UserCode))

                        End If

                        _AgencyImportPath = System.IO.Path.Combine(_AgencyImportPath, Session.UserCode)

                    End If

                End If

                Select Case _ImportType

                    Case AdvantageFramework.Importing.ImportType.ExpenseReport

                        Me.Text = "Expense Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Expense Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Expense Import Wizard Completed"

                    Case AdvantageFramework.Importing.ImportType.ClearedChecks

                        Me.Text = "Cleared Checks Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Cleared Checks Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Cleared Checks Wizard Completed"
                        WizardPageWizard_SelectBank.Visible = True

                        If _IsCSIPreferredPartnerImport AndAlso _ImportTemplateType = ImportTemplateTypes.ClearedChecks_Default Then

                            WizardPageWizard_CSIPreferredPartnerTemplate.Visible = True
                            WizardPageWizard_CSIPreferredPartnerDownload.Visible = True
                            WizardPageWizard_SelectImportOptions.Visible = False
                            WizardPageWizard_SelectImportFiles.Visible = False

                            ComboBoxCSIPreferredPartnerTemplate_Template.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Importing.CSIReconciliationTemplates), False, True)
                            ComboBoxCSIPreferredPartnerTemplate_Template.SetRequired(True)
                            ComboBoxSelectBank_Bank.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext).Where(Function(Entity) (Entity.PaymentManagerType = "CSI" OrElse Entity.PaymentManagerType = "CSI2" OrElse Entity.PaymentManagerType = "CSI3") AndAlso
                                                                                                                                                             Entity.ComDataAccountCode IsNot Nothing AndAlso Entity.ComDataAccountCode <> "")
                            ComboBoxSelectBank_Bank.SetRequired(True)

                        Else

                            WizardPageWizard_CSIPreferredPartnerTemplate.Visible = False
                            WizardPageWizard_CSIPreferredPartnerDownload.Visible = False
                            WizardPageWizard_SelectImportOptions.Visible = True
                            WizardPageWizard_SelectImportFiles.Visible = True

                            ComboBoxSelectBank_Bank.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext)
                            ComboBoxSelectBank_Bank.SetRequired(True)

                        End If

                        If _ImportTemplateType = ImportTemplateTypes.ClearedChecks_MediaVCC Then

                            WizardPageWizard_SelectDateRange.Visible = True
                            WizardPageWizard_SelectImportFiles.Visible = False
                            WizardPageWizard_SelectImportOptions.Visible = False

                            DateTimePickerDateRange_FromDate.SetRequired(True)
                            DateTimePickerDateRange_ToDate.SetRequired(True)

                            LabelImportingPage_ImportingStatus.Visible = False
                            ProgressBarImportingPage_Progress.Visible = False

                        End If

                    Case AdvantageFramework.Importing.ImportType.AccountsPayable

                        Me.Text = "Accounts Payable Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Accounts Payable Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Accounts Payable Import Wizard Completed"

                        If _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast OrElse
                                _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedInternet OrElse
                                _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedPrint Then

                            WizardPageWizard_SelectImportOptions.Visible = False

                        End If

                    Case AdvantageFramework.Importing.ImportType.Client

                        Me.Text = "Client Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Client Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Client Import Wizard Completed"

                    Case AdvantageFramework.Importing.ImportType.Division

                        Me.Text = "Division Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Division Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Division Import Wizard Completed"

                    Case AdvantageFramework.Importing.ImportType.Product

                        Me.Text = "Product Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Product Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Product Import Wizard Completed"

                    Case AdvantageFramework.Importing.ImportType.DigitalResults

                        Me.Text = "Media Results Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Media Results Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Media Results Import Wizard Completed"

                    Case AdvantageFramework.Importing.ImportType.AvalaraTaxCode

                        Me.Text = "Avalara Tax Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Avalara Tax Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Avalara Tax Import Wizard Completed"

                    Case AdvantageFramework.Importing.ImportType.CashReceipt

                        Me.Text = "Cash Receipt Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Cash Receipt Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Cash Receipt Import Wizard Completed"

                    Case AdvantageFramework.Importing.ImportType.AccountsReceivable

                        Me.Text = "Accounts Receivable Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Accounts Receivable Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Accounts Receivable Import Wizard Completed"

                    Case AdvantageFramework.Importing.ImportType.ClientContact

                        Me.Text = "Client Contact Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Client Contact Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Client Contact Import Wizard Completed"

                    Case AdvantageFramework.Importing.ImportType.PTO

                        Me.Text = "PTO Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the PTO Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "PTO Import Wizard Completed"

                    Case AdvantageFramework.Importing.ImportType.MediaRFP

                        Me.Text = "Media RFP Import Wizard"
                        WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Media RFP Import Wizard"
                        CompletionWizardPageForm_CompletionPage.Text = "Media RFP Import Wizard Completed"

                        WizardPageWizard_SelectImportOptions.Visible = False

                End Select

                ComboBoxSelectImportOptions_Template.DataSource = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, _ImportTemplateType).
                        OrderByDescending(Function(Entity) Entity.IsSystemTemplate).ThenBy(Function(Entity) Entity.Name).ToList

                If _ImportTemplateType = ImportTemplateTypes.AccountsPayable_Generic Then

                    SetLastSelectedGenericAPTemplate()

                End If

            End Using

        End Sub
        Private Sub LoadCSIPreferredPartnerFTP(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                               ByVal Bank As AdvantageFramework.Database.Entities.Bank,
                                               ByVal AgencySetting As AdvantageFramework.Agency.Settings,
                                               ByRef FTPHost As String, ByRef FTPPort As Integer,
                                               ByRef ComDataAccountCode As String, ByRef ComDataPassword As String)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim FTPString As String = ""

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AgencySetting.ToString)

            If Setting IsNot Nothing Then

                FTPString = Setting.Value

                If FTPString.Contains(":") Then

                    FTPHost = FTPString.Split(":")(0)

                    If IsNumeric(FTPString.Split(":")(1)) Then

                        FTPPort = FTPString.Split(":")(1)

                    End If

                Else

                    FTPHost = FTPString

                End If

            End If

            If Bank IsNot Nothing Then

                ComDataAccountCode = Bank.ComDataAccountCode

                ComDataPassword = Bank.ComDataPassword

            End If

        End Sub
        Private Function GetImportPath() As String

            'objects
            Dim ImportPath As String = ""

            If _IsAgencyASP Then

                If String.IsNullOrWhiteSpace(_AgencyImportPath) Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        _AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\")

                        _AgencyImportPath = AdvantageFramework.Importing.GetHostedDirectory(_ImportTemplateType, _AgencyImportPath)

                        If _ImportTemplateType = ImportTemplateTypes.MediaRFP_4As Then

                            If My.Computer.FileSystem.DirectoryExists(System.IO.Path.Combine(_AgencyImportPath, Session.UserCode)) = False Then

                                My.Computer.FileSystem.CreateDirectory(System.IO.Path.Combine(_AgencyImportPath, Session.UserCode))

                            End If

                            _AgencyImportPath = System.IO.Path.Combine(_AgencyImportPath, Session.UserCode)

                        End If

                    End Using

                End If

                ImportPath = _AgencyImportPath

            Else

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ImportPath = AdvantageFramework.CSIPreferredPartner.LoadClearedChecksImportPath(DataContext)

                End Using

            End If

            GetImportPath = ImportPath

        End Function
        Private Sub SaveLastSelectedGenericAPTemplate()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.LastGenericAPImportTemplateID.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = _ImportTemplateID

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                Else

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.LastGenericAPImportTemplateID.ToString, _ImportTemplateID, Nothing, Nothing, UserSetting)

                End If

            End Using

        End Sub
        Private Sub SetLastSelectedGenericAPTemplate()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.LastGenericAPImportTemplateID.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing Then

                    For Each Item In ComboBoxSelectImportOptions_Template.Items

                        If IsNumeric(UserSetting.StringValue) AndAlso Item.ID = UserSetting.StringValue Then

                            ComboBoxSelectImportOptions_Template.SelectedItem = Item
                            Exit For

                        End If

                    Next

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowWizardDialog(ByVal ImportType As AdvantageFramework.Importing.ImportType, ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes,
                                                ByRef BatchName As String, Optional ByVal IsCSIPreferredPartnerImport As Boolean = False,
                                                Optional ByVal MediaRFPHeaderID As Nullable(Of Integer) = Nothing, Optional ByVal MediaBroadcastWorksheetMarketID As Nullable(Of Integer) = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim ImportWizardDialog As AdvantageFramework.Importing.Presentation.ImportWizardDialog = Nothing

            ImportWizardDialog = New AdvantageFramework.Importing.Presentation.ImportWizardDialog(ImportType, ImportTemplateType, BatchName, IsCSIPreferredPartnerImport, MediaRFPHeaderID, MediaBroadcastWorksheetMarketID)

            ShowWizardDialog = ImportWizardDialog.ShowDialog()

            ImportType = ImportWizardDialog.ImportType
            ImportTemplateType = ImportWizardDialog.ImportTemplateType
            BatchName = ImportWizardDialog.BatchName

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ImportWizardDialog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            RemoveHandler AdvantageFramework.Importing.ImportingProgressUpdateEvent, AddressOf ImportingProgressUpdate
            RemoveHandler AdvantageFramework.Importing.SetupImportingProgressEvent, AddressOf SetupImportingProgress

            RemoveHandler AdvantageFramework.Importing.OverallImportingProgressUpdateEvent, AddressOf OverallImportingProgressUpdate
            RemoveHandler AdvantageFramework.Importing.SetupOverallImportingProgressEvent, AddressOf SetupOverallImportingProgress

        End Sub
        Private Sub ImportWizardDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            AddHandler AdvantageFramework.Importing.ImportingProgressUpdateEvent, AddressOf ImportingProgressUpdate
            AddHandler AdvantageFramework.Importing.SetupImportingProgressEvent, AddressOf SetupImportingProgress

            AddHandler AdvantageFramework.Importing.OverallImportingProgressUpdateEvent, AddressOf OverallImportingProgressUpdate
            AddHandler AdvantageFramework.Importing.SetupOverallImportingProgressEvent, AddressOf SetupOverallImportingProgress

            DateTimePickerDateRange_FromDate.Value = DateAdd(DateInterval.Day, -31, Now)
            DateTimePickerDateRange_ToDate.Value = Now

            ComboBoxSelectImportOptions_Template.SetRequired(True)

            WizardControlForm_Wizard.Image = AdvantageFramework.My.Resources.AdvantageLogoImage

            ButtonSelectImportFiles_RemoveFiles.Enabled = False

            LoadDefaults()

        End Sub
        Private Sub ImportWizardDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewSelectImportFiles_Files.CurrentView.ViewCaption = "File(s) Chosen for Import"

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub WizardControlForm_Wizard_NextClick(ByVal sender As Object, ByVal e As DevExpress.XtraWizard.WizardCommandButtonClickEventArgs) Handles WizardControlForm_Wizard.NextClick

            'objects
            Dim CanContinue As Boolean = True
            Dim Message As String = ""

            If e.Page Is WizardPageWizard_SelectImportOptions Then

                If Me.Validator = False Then

                    CanContinue = False
                    ComboBoxSelectImportOptions_Template.Focus()

                End If

            ElseIf e.Page Is WizardPageWizard_SelectBank Then

                If AdvantageFramework.WinForm.Presentation.Controls.ValidateControl(Me.FindForm, ComboBoxSelectBank_Bank) = False Then

                    CanContinue = False
                    ComboBoxSelectBank_Bank.Focus()

                End If

            ElseIf e.Page Is WizardPageWizard_SelectImportFiles Then

                If DataGridViewSelectImportFiles_Files.HasRows = False Then

                    CanContinue = False
                    AdvantageFramework.WinForm.MessageBox.Show("Please select at least one file to continue.")

                End If

            ElseIf e.Page Is WizardPageWizard_CSIPreferredPartnerTemplate Then

                If AdvantageFramework.WinForm.Presentation.Controls.ValidateControl(Me.FindForm, ComboBoxCSIPreferredPartnerTemplate_Template) = False Then

                    CanContinue = False
                    ComboBoxCSIPreferredPartnerTemplate_Template.Focus()

                End If

            ElseIf e.Page Is WizardPageWizard_SelectDateRange Then

                If DateTimePickerDateRange_FromDate.GetValue Is Nothing OrElse
                        DateTimePickerDateRange_ToDate.GetValue Is Nothing OrElse
                        DateTimePickerDateRange_ToDate.GetValue < DateTimePickerDateRange_FromDate.GetValue OrElse
                        DateDiff(DateInterval.Day, DateTimePickerDateRange_FromDate.GetValue, DateTimePickerDateRange_ToDate.GetValue) > 31 Then

                    CanContinue = False
                    AdvantageFramework.WinForm.MessageBox.Show("Date range is required and cannot exceed 31 days.")

                End If

            End If

            e.Handled = Not CanContinue

        End Sub
        Private Sub WizardControlForm_Wizard_FinishClick(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.FinishClick

            If _ImportTemplateType = ImportTemplateTypes.AccountsPayable_Generic Then

                SaveLastSelectedGenericAPTemplate()

            End If

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub WizardControlForm_Wizard_CancelClick(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.CancelClick

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        End Sub
        Private Sub WizardControlForm_Wizard_SelectedPageChanged(ByVal sender As Object, ByVal e As DevExpress.XtraWizard.WizardPageChangedEventArgs) Handles WizardControlForm_Wizard.SelectedPageChanged

            If e.Direction = DevExpress.XtraWizard.Direction.Forward Then

                If e.Page Is WizardPageWizard_ImportingPage Then

                    WizardPageWizard_ImportingPage.AllowNext = False

                    If _IsCSIPreferredPartnerImport Then

                        _CSIPreferredPartnerImportBackgroundWorker = New System.ComponentModel.BackgroundWorker

                        _CSIPreferredPartnerImportBackgroundWorker.WorkerReportsProgress = True

                        _CSIPreferredPartnerImportBackgroundWorker.RunWorkerAsync()

                    ElseIf _ImportTemplateType = ImportTemplateTypes.ClearedChecks_MediaVCC Then

                        _BatchName = Importing.CreateBatchName("Media VCC")
                        _BankCode = ComboBoxSelectBank_Bank.GetSelectedValue
                        _TransactionStartDate = DateTimePickerDateRange_FromDate.GetValue
                        _TransactionEndDate = DateTimePickerDateRange_ToDate.GetValue

                        _MediaVCCBackgroundWorker = New System.ComponentModel.BackgroundWorker

                        _MediaVCCBackgroundWorker.WorkerReportsProgress = True

                        _MediaVCCBackgroundWorker.RunWorkerAsync()

                    Else

                        _ImportTemplateID = CInt(ComboBoxSelectImportOptions_Template.GetSelectedValue)
                        _AutoTrimOverflowData = CheckBoxSelectImportOptions_AutoTrimOverflowData.Checked
                        _ColumnHeaders = CheckBoxForm_ColumnHeaders.Checked
                        _BankCode = ComboBoxSelectBank_Bank.GetSelectedValue

                        _BackgroundWorker = New System.ComponentModel.BackgroundWorker

                        _BackgroundWorker.WorkerReportsProgress = True

                        _BackgroundWorker.RunWorkerAsync()

                    End If

                ElseIf e.Page Is WizardPageWizard_CSIPreferredPartnerDownload Then

                    WizardPageWizard_CSIPreferredPartnerDownload.AllowNext = False

                    _BankCode = ComboBoxSelectBank_Bank.GetSelectedValue
                    _CSIReconciliationTemplate = ComboBoxCSIPreferredPartnerTemplate_Template.GetSelectedValue

                    _CSIPreferredPartnerDownloadBackgroundWorker = New System.ComponentModel.BackgroundWorker

                    _CSIPreferredPartnerDownloadBackgroundWorker.WorkerReportsProgress = True

                    _CSIPreferredPartnerDownloadBackgroundWorker.RunWorkerAsync()

                ElseIf e.Page Is WizardPageWizard_SelectImportFiles Then

                    If _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast OrElse
                            _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedInternet OrElse
                            _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedPrint Then

                        If ButtonSelectImportFiles_LoadDefaultDirectory.Visible AndAlso ButtonSelectImportFiles_LoadDefaultDirectory.Enabled Then

                            ButtonSelectImportFiles_LoadDefaultDirectory.PerformClick()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ComboBoxSelectImportOptions_Template_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxSelectImportOptions_Template.SelectedValueChanged

            'objects
            Dim ImportTemplateID As Integer = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim MediaRequestForProposalController As AdvantageFramework.Controller.Media.MediaRequestForProposalController = Nothing

            If ComboBoxSelectImportOptions_Template.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ImportTemplateID = CInt(ComboBoxSelectImportOptions_Template.GetSelectedValue)

                    ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportTemplateID)

                    If ImportTemplate IsNot Nothing Then

                        If _IsAgencyASP Then

                            ButtonSelectImportFiles_LoadDefaultDirectory.Visible = True

                        ElseIf String.IsNullOrEmpty(ImportTemplate.DefaultDirectory) Then

                            _DefaultDirectory = Nothing
                            ButtonSelectImportFiles_LoadDefaultDirectory.Visible = False

                        Else

                            _DefaultDirectory = ImportTemplate.DefaultDirectory
                            ButtonSelectImportFiles_LoadDefaultDirectory.Visible = True

                        End If

                        If (_ImportTemplateType = ImportTemplateTypes.CashReceipt_Custom AndAlso ImportTemplate.IsSystemTemplate AndAlso ImportTemplate.Name = "Custom Fixed") OrElse
                                _ImportTemplateType = ImportTemplateTypes.MediaRFP_4As Then

                            CheckBoxForm_ColumnHeaders.Checked = False
                            CheckBoxForm_ColumnHeaders.Visible = False
                            CheckBoxSelectImportOptions_AutoTrimOverflowData.Checked = False
                            CheckBoxSelectImportOptions_AutoTrimOverflowData.Visible = False

                        Else

                            CheckBoxForm_ColumnHeaders.Visible = True
                            CheckBoxSelectImportOptions_AutoTrimOverflowData.Visible = True

                        End If

                        If _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedPrint OrElse _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedInternet Then

                            _FileFilter = FileSystem.FileFilters.INV

                        ElseIf _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast Then

                            _FileFilter = FileSystem.FileFilters.V51

                        ElseIf _ImportTemplateType = ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                            _FileFilter = FileSystem.FileFilters.BUYandDATandTXT

                        ElseIf _ImportTemplateType = ImportTemplateTypes.MediaRFP_4As Then

                            MediaRequestForProposalController = New AdvantageFramework.Controller.Media.MediaRequestForProposalController(Me.Session)

                            If MediaRequestForProposalController.GetMediaBroadcastWorksheetMediaType(_MediaRFPHeaderID) = "T" Then

                                _FileFilter = FileSystem.FileFilters.XMLandSCXandPRP

                            Else

                                _FileFilter = FileSystem.FileFilters.XML

                            End If

                        ElseIf ImportTemplate.FileType = AdvantageFramework.Importing.FileTypes.CSV Then

                            _FileFilter = FileSystem.FileFilters.CSV

                        Else

                            _FileFilter = FileSystem.FileFilters.TXT

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub _BackgroundWorker_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

            'objects
            Dim Imported As Boolean = False
            Dim BatchName As String = Nothing
            Dim FailedLines As Generic.Dictionary(Of Integer, String) = Nothing
            Dim FileList() As String = Nothing
            Dim InfoMessage As String = Nothing

            FileList = DataGridViewSelectImportFiles_Files.GetAllRowsCellValues(0).OfType(Of String).ToArray

            If _BatchName IsNot Nothing Then

                BatchName = _BatchName

            End If

            Select Case _ImportType

                Case AdvantageFramework.Importing.ImportType.ClearedChecks

                    Imported = AdvantageFramework.Importing.ImportFileByImportTemplate(Me.Session, _ImportTemplateID, FileList,
                                                                                       _AutoTrimOverflowData, _ColumnHeaders,
                                                                                       _BankCode, BatchName, FailedLines)

                Case AdvantageFramework.Importing.ImportType.MediaRFP

                    Imported = AdvantageFramework.Importing.ImportMediaRFPFile(Me.Session, FileList, _MediaBroadcastWorksheetMarketID, InfoMessage, _MediaRFPHeaderID)

                Case Else

					Imported = AdvantageFramework.Importing.ImportFileByImportTemplate(Me.Session, _ImportTemplateID, FileList,
																					   _AutoTrimOverflowData, _ColumnHeaders,
																					   Nothing, BatchName, FailedLines)

			End Select

			_BatchName = BatchName

            If Imported = False AndAlso _ImportType = AdvantageFramework.Importing.ImportType.MediaRFP AndAlso String.IsNullOrWhiteSpace(InfoMessage) = False Then

                e.Cancel = True
                e.Result = InfoMessage

            ElseIf Imported = False Then

                e.Cancel = True
                e.Result = Nothing

            Else

                e.Cancel = False

                If FailedLines IsNot Nothing Then

                    e.Result = FailedLines

                ElseIf Not String.IsNullOrWhiteSpace(InfoMessage) Then

                    e.Result = InfoMessage

                End If

            End If

		End Sub
		Private Sub _BackgroundWorker_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged

			If e.UserState IsNot Nothing AndAlso e.UserState.ToString = "Overall" Then

				ProgressBarImportingPage_OverallProgress.Value = e.ProgressPercentage

				If ProgressBarImportingPage_OverallProgress.Value <> ProgressBarImportingPage_OverallProgress.Maximum Then

					ProgressBarImportingPage_Progress.Value = 0
					ProgressBarImportingPage_Progress.Refresh()

				End If

			Else

				ProgressBarImportingPage_Progress.Value = e.ProgressPercentage

			End If

		End Sub
		Private Sub _BackgroundWorker_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

			'objects
			Dim ImportTemplateID As Integer = Nothing
			Dim Imported As Boolean = False
			Dim FailedLines As Generic.Dictionary(Of Integer, String) = Nothing
			Dim ImportingStatus As String = ""
            Dim InfoMessage As String = Nothing

            If e.Cancelled Then

				ImportingStatus = "Importing File(s) Failed... Click Next to continue..."

			Else

				ProgressBarImportingPage_Progress.Value = ProgressBarImportingPage_Progress.Maximum
				ProgressBarImportingPage_Progress.Refresh()

                If TypeOf e.Result Is String Then

                    InfoMessage = e.Result

                    If Not String.IsNullOrWhiteSpace(InfoMessage) Then

                        AdvantageFramework.WinForm.MessageBox.Show(InfoMessage)

                    End If

                    ImportingStatus = "Importing File(s) Completed... Click Next to continue..."

                Else

                    FailedLines = e.Result

                    If FailedLines IsNot Nothing AndAlso FailedLines.Count > 0 Then

                        ImportingStatus = "Importing File(s) Completed but with errors... Click Next to continue..."

                    Else

                        ImportingStatus = "Importing File(s) Completed... Click Next to continue..."

                    End If

                End If

            End If

            LabelImportingPage_ImportingStatus.Text = ImportingStatus

            WizardPageWizard_ImportingPage.AllowNext = True

		End Sub
		Private Sub ButtonSelectImportFiles_LoadDefaultDirectory_Click(sender As Object, e As EventArgs) Handles ButtonSelectImportFiles_LoadDefaultDirectory.Click

			Dim FileInfoList As Generic.List(Of System.IO.FileInfo) = Nothing
			Dim FileInfo As System.IO.FileInfo = Nothing
			Dim Files() As String = Nothing
			Dim DefaultDirectory As String = Nothing
			Dim ExcludeFileNamesBeginningWithList As Generic.List(Of String) = Nothing

			If _IsAgencyASP Then

				DefaultDirectory = _AgencyImportPath

			Else

				DefaultDirectory = _DefaultDirectory

			End If

			If DefaultDirectory Is Nothing Then

				AdvantageFramework.WinForm.MessageBox.Show("Default directory is not setup for this template.")

			Else

				If My.Computer.FileSystem.DirectoryExists(DefaultDirectory) Then

					FileInfoList = My.Computer.FileSystem.GetDirectoryInfo(DefaultDirectory).GetFiles().ToList

					For Each FileInfo In FileInfoList.ToList

                        If _FileFilter = FileSystem.FileFilters.CSV AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.CSV.ToString.ToUpper) = False Then

                            FileInfoList.Remove(FileInfo)

                        ElseIf _FileFilter = FileSystem.FileFilters.INV AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.INV.ToString.ToUpper) = False Then

                            FileInfoList.Remove(FileInfo)

                        ElseIf _FileFilter = FileSystem.FileFilters.V51 AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.V51.ToString.ToUpper) = False Then

                            FileInfoList.Remove(FileInfo)

                        ElseIf _FileFilter = FileSystem.FileFilters.DAT AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.DAT.ToString.ToUpper) = False Then

                            FileInfoList.Remove(FileInfo)

                        ElseIf _FileFilter = FileSystem.FileFilters.BUY AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.BUY.ToString.ToUpper) = False Then

                            FileInfoList.Remove(FileInfo)

                        ElseIf _FileFilter = FileSystem.FileFilters.BUYandDATandTXT AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.BUY.ToString.ToUpper) = False AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.DAT.ToString.ToUpper) = False AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.TXT.ToString.ToUpper) = False Then

                            FileInfoList.Remove(FileInfo)

                        ElseIf _FileFilter = FileSystem.FileFilters.TXT AndAlso FileInfo.Extension.ToUpper.EndsWith("TXT") = False AndAlso FileInfo.Extension.ToUpper.EndsWith("DAT") = False Then

                            FileInfoList.Remove(FileInfo)

                        ElseIf _FileFilter = FileSystem.FileFilters.XML AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.XML.ToString.ToUpper) = False Then

                            FileInfoList.Remove(FileInfo)

                        ElseIf _FileFilter = FileSystem.FileFilters.XMLandSCXandPRP AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.XML.ToString.ToUpper) = False AndAlso
                                FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.SCX.ToString.ToUpper) = False AndAlso FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.PRP.ToString.ToUpper) = False Then

                            FileInfoList.Remove(FileInfo)

                        End If

					Next

				End If

				If FileInfoList IsNot Nothing Then

                    If _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint Then

                        FileInfoList = FileInfoList.Where(Function(F) Mid(F.Name.ToString.ToUpper, 1, 3) <> "INT").ToList

                    ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet Then

                        FileInfoList = FileInfoList.Where(Function(F) Mid(F.Name.ToString.ToUpper, 1, 3) = "INT").ToList

                    ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic Then

                        ExcludeFileNamesBeginningWithList = New Generic.List(Of String)
                        ExcludeFileNamesBeginningWithList.Add("BC_ORD")
                        ExcludeFileNamesBeginningWithList.Add("MAGAZINE")
                        ExcludeFileNamesBeginningWithList.Add("NEWSPAPER")
                        ExcludeFileNamesBeginningWithList.Add("OUTDOOR")
                        ExcludeFileNamesBeginningWithList.Add("INTERNET")

                        For Each FileInfo In FileInfoList.ToList

                            For Each ExcludeFile In ExcludeFileNamesBeginningWithList

                                If FileInfo.ToString.ToUpper.StartsWith(ExcludeFile.ToUpper) Then

                                    FileInfoList.Remove(FileInfo)

                                End If

                            Next

                        Next

                    End If

					Files = FileInfoList.Select(Function(F) F.FullName).ToArray

				End If

				If Files IsNot Nothing AndAlso Files.Length > 0 Then

					FileInfoList = New Generic.List(Of System.IO.FileInfo)

					For FileCounter As Integer = 0 To Files.Length - 1

						If AdvantageFramework.FileSystem.IsFileInUse(Files(FileCounter)) Then

							AdvantageFramework.WinForm.MessageBox.Show("The file " & Files(FileCounter) & " is currently in use.  Please close the file and re-select.")

						Else

							FileInfo = New System.IO.FileInfo(Files(FileCounter))

							FileInfoList.Add(FileInfo)

						End If

					Next

					DataGridViewSelectImportFiles_Files.DataSource = (From File In FileInfoList
																	  Select New With {.FullName = File.FullName}).ToList

				End If

				DataGridViewSelectImportFiles_Files.CurrentView.BestFitColumns()

			End If

		End Sub
		Private Sub ButtonSelectImportFiles_SelectFiles_Click(sender As Object, e As EventArgs) Handles ButtonSelectImportFiles_SelectFiles.Click

			Dim FileInfoList As Generic.List(Of System.IO.FileInfo) = Nothing
			Dim FileInfo As System.IO.FileInfo = Nothing
			Dim Files() As String = Nothing
			Dim SelectedFiles As Generic.List(Of String) = Nothing
			Dim FileIsOkay As Boolean = True
			Dim ExcludeFileNamesBeginningWithList As Generic.List(Of String) = Nothing

			If _IsAgencyASP Then

				If _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedInternet Then

                    AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_AgencyImportPath, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({_FileFilter}), True, Files, "int")

                ElseIf _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedPrint Then

					ExcludeFileNamesBeginningWithList = New Generic.List(Of String)
					ExcludeFileNamesBeginningWithList.Add("int")

                    AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_AgencyImportPath, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({_FileFilter}), True, Files, Nothing, ExcludeFileNamesBeginningWithList)

                ElseIf _ImportTemplateType = ImportTemplateTypes.AccountsPayable_Generic Then

					ExcludeFileNamesBeginningWithList = New Generic.List(Of String)
					ExcludeFileNamesBeginningWithList.Add("BC_ORD")
					ExcludeFileNamesBeginningWithList.Add("MAGAZINE")
					ExcludeFileNamesBeginningWithList.Add("NEWSPAPER")
					ExcludeFileNamesBeginningWithList.Add("OUTDOOR")
					ExcludeFileNamesBeginningWithList.Add("INTERNET")

                    AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_AgencyImportPath, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({_FileFilter}), True, Files, Nothing, ExcludeFileNamesBeginningWithList)

                Else

                    AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_AgencyImportPath, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({_FileFilter}), True, Files)

                End If

			Else

                If _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedInternet Then

                    AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_DefaultDirectory, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({_FileFilter}), True, Files, "int", Nothing, True)

                ElseIf _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedPrint Then

                    ExcludeFileNamesBeginningWithList = New Generic.List(Of String)
                    ExcludeFileNamesBeginningWithList.Add("int")

                    AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_DefaultDirectory, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({_FileFilter}), True, Files, Nothing, ExcludeFileNamesBeginningWithList, True)

                ElseIf _ImportTemplateType = ImportTemplateTypes.AccountsPayable_Generic Then

                    ExcludeFileNamesBeginningWithList = New Generic.List(Of String)
                    ExcludeFileNamesBeginningWithList.Add("BC_ORD")
                    ExcludeFileNamesBeginningWithList.Add("MAGAZINE")
                    ExcludeFileNamesBeginningWithList.Add("NEWSPAPER")
                    ExcludeFileNamesBeginningWithList.Add("OUTDOOR")
                    ExcludeFileNamesBeginningWithList.Add("INTERNET")

                    AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_DefaultDirectory, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({_FileFilter}), True, Files, Nothing, ExcludeFileNamesBeginningWithList, True)

                ElseIf String.IsNullOrEmpty(_DefaultDirectory) = False AndAlso My.Computer.FileSystem.DirectoryExists(_DefaultDirectory) Then

                    Files = AdvantageFramework.WinForm.Presentation.SelectFilesToOpen(_DefaultDirectory, AdvantageFramework.FileSystem.LoadFileFilterString(_FileFilter), "Select Import Files...")

                Else

                    Files = AdvantageFramework.WinForm.Presentation.SelectFilesToOpen(, AdvantageFramework.FileSystem.LoadFileFilterString(_FileFilter), "Select Import Files...")

                End If

			End If

			SelectedFiles = New Generic.List(Of String)

			For Each File In DataGridViewSelectImportFiles_Files.GetAllRowsDataBoundItems

				SelectedFiles.Add(File.FullName.ToString)

			Next

			FileInfoList = New Generic.List(Of System.IO.FileInfo)

			For Each File In SelectedFiles

				If AdvantageFramework.FileSystem.IsFileInUse(File) Then

					AdvantageFramework.WinForm.MessageBox.Show("The file " & File & " is currently in use.  Please close the file and re-select.")

				Else

					FileInfo = New System.IO.FileInfo(File)

					FileInfoList.Add(FileInfo)

				End If

			Next

			If Files IsNot Nothing AndAlso Files.Length > 0 Then

				For FileCounter As Integer = 0 To Files.Length - 1

					FileIsOkay = True

					FileInfo = New System.IO.FileInfo(Files(FileCounter))

					If _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedInternet Then

						If FileInfo.Name.ToString.ToUpper.StartsWith("INT") = False Then

							FileIsOkay = False

						End If

					ElseIf _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedPrint Then

						If FileInfo.Name.ToString.ToUpper.StartsWith("INT") = True Then

							FileIsOkay = False

						End If

					End If

					If FileIsOkay Then

						If AdvantageFramework.FileSystem.IsFileInUse(Files(FileCounter)) Then

							AdvantageFramework.WinForm.MessageBox.Show("The file " & Files(FileCounter) & " is currently in use.  Please close the file and re-select.")

						ElseIf SelectedFiles.Contains(Files(FileCounter)) = False Then

							FileInfoList.Add(FileInfo)

						End If

					End If

				Next

			End If

			DataGridViewSelectImportFiles_Files.DataSource = (From File In FileInfoList
															  Select New With {.FullName = File.FullName}).ToList

			DataGridViewSelectImportFiles_Files.CurrentView.BestFitColumns()

		End Sub
		Private Sub ButtonSelectImportFiles_RemoveFiles_Click(sender As Object, e As EventArgs) Handles ButtonSelectImportFiles_RemoveFiles.Click

			DataGridViewSelectImportFiles_Files.CurrentView.DeleteSelectedRows()

		End Sub
		Private Sub DataGridViewSelectImportFiles_Files_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectImportFiles_Files.SelectionChangedEvent

			ButtonSelectImportFiles_RemoveFiles.Enabled = DataGridViewSelectImportFiles_Files.HasASelectedRow

		End Sub
		Private Sub _CSIPreferredPartnerDownloadBackgroundWorker_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles _CSIPreferredPartnerDownloadBackgroundWorker.DoWork

			'objects
			Dim Downloaded As Boolean = False
			Dim DownloadedFiles As Generic.List(Of String) = Nothing
			Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
			Dim FTPHost As String = ""
			Dim FTPPort As Integer = 0
			Dim FTPPath As String = ""
			Dim ComDataAccountCode As String = ""
			Dim ComDataPassword As String = ""
			Dim ImportPath As String = ""
			Dim SftpExceptionStatus As Rebex.Net.SftpExceptionStatus = Rebex.Net.SftpExceptionStatus.UnclassifiableError
			Dim SFtpExceptionMessage As String = ""

			DownloadedFiles = New Generic.List(Of String)

			ImportPath = GetImportPath()

			If My.Computer.FileSystem.DirectoryExists(ImportPath) Then

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

						Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, _BankCode)

						If Bank IsNot Nothing Then

							_CSIPreferredPartnerDownloadBackgroundWorker.ReportProgress(0, "Loading local files for processing...")

							For Each File In My.Computer.FileSystem.GetFiles(ImportPath)

								If File.ToUpper.EndsWith(".OLD") = False Then

									DownloadedFiles.Add(File)

								End If

							Next

							_CSIPreferredPartnerDownloadBackgroundWorker.ReportProgress(0, "All local files are loaded...")

							_CSIPreferredPartnerDownloadBackgroundWorker.ReportProgress(0, "Loading FTP information...")

							If _CSIReconciliationTemplate = CSIReconciliationTemplates.ComDataAC29File Then

								LoadCSIPreferredPartnerFTP(DataContext, Bank, Agency.Methods.Settings.CSI_COMDATA_FTP, FTPHost, FTPPort, ComDataAccountCode, ComDataPassword)
								FTPPath = "/"

							Else

								LoadCSIPreferredPartnerFTP(DataContext, Bank, Agency.Methods.Settings.CSI_CCDATA_FTP, FTPHost, FTPPort, ComDataAccountCode, ComDataPassword)
								FTPPath = "/Outbound"

							End If

							_CSIPreferredPartnerDownloadBackgroundWorker.ReportProgress(0, "Initial validation of FTP information...")

							If String.IsNullOrWhiteSpace(FTPHost) = False AndAlso String.IsNullOrWhiteSpace(ComDataAccountCode) = False AndAlso String.IsNullOrWhiteSpace(ComDataPassword) = False Then

								_CSIPreferredPartnerDownloadBackgroundWorker.ReportProgress(0, "Attempting to download files...")

								If AdvantageFramework.FTP.DownloadFilesFromSFTP(FTPHost, FTPPort, ComDataAccountCode, ComDataPassword, FTPPath, ImportPath, DownloadedFiles, SftpExceptionStatus, SftpExceptionMessage) = False Then

									_CSIPreferredPartnerDownloadBackgroundWorker.ReportProgress(0, AdvantageFramework.StringUtilities.GetNameAsWords(SftpExceptionStatus.ToString) & " - " & SFtpExceptionMessage)

								End If

							Else

								_CSIPreferredPartnerDownloadBackgroundWorker.ReportProgress(0, "Initial validation of FTP information failed...")

							End If

							Downloaded = True

						Else

							_CSIPreferredPartnerDownloadBackgroundWorker.ReportProgress(0, "Bank cannot be loaded...")

						End If

					End Using

				End Using

			Else

				_CSIPreferredPartnerDownloadBackgroundWorker.ReportProgress(0, "CSI Cleared Checks import path does not exist...")

			End If

			If Downloaded = False Then

				e.Cancel = True
				e.Result = Nothing

			Else

				e.Cancel = False
				e.Result = DownloadedFiles

			End If

		End Sub
		Private Sub _CSIPreferredPartnerDownloadBackgroundWorker_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles _CSIPreferredPartnerDownloadBackgroundWorker.ProgressChanged

			'objects
			Dim Message As String = ""

			If e.UserState IsNot Nothing AndAlso String.IsNullOrWhiteSpace(e.UserState.ToString) = False Then

				Message = e.UserState.ToString

				If TextBoxCSIPreferredPartnerDownload_Log.Text <> "" Then

					TextBoxCSIPreferredPartnerDownload_Log.Text = Message & Environment.NewLine & TextBoxCSIPreferredPartnerDownload_Log.Text

				Else

					TextBoxCSIPreferredPartnerDownload_Log.Text = Message

				End If

			End If

		End Sub
		Private Sub _CSIPreferredPartnerDownloadBackgroundWorker_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles _CSIPreferredPartnerDownloadBackgroundWorker.RunWorkerCompleted

			'objects
			Dim DownloadingStatus As String = ""

			ProgressBarCSIPreferredPartnerDownload_Progress.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard
			ProgressBarCSIPreferredPartnerDownload_Progress.Value = 100

			If e.Cancelled Then

				DownloadingStatus = "Downloading File(s) Failed... Click Cancel to continue..."
				WizardPageWizard_CSIPreferredPartnerDownload.AllowNext = False

			Else

				_DownloadedFiles = e.Result

				If _DownloadedFiles IsNot Nothing AndAlso _DownloadedFiles.Count > 0 Then

					DownloadingStatus = "Downloading File(s) Completed... Click Next to continue..."
					WizardPageWizard_CSIPreferredPartnerDownload.AllowNext = True

				Else

					DownloadingStatus = "No File(s) were downloaded... Click Cancel to continue..."
					WizardPageWizard_CSIPreferredPartnerDownload.AllowNext = False

				End If

			End If

			WizardPageWizard_CSIPreferredPartnerDownload.AllowCancel = True

			If TextBoxCSIPreferredPartnerDownload_Log.Text <> "" Then

				TextBoxCSIPreferredPartnerDownload_Log.Text = DownloadingStatus & Environment.NewLine & TextBoxCSIPreferredPartnerDownload_Log.Text

			Else

				TextBoxCSIPreferredPartnerDownload_Log.Text = DownloadingStatus

			End If

		End Sub
		Private Sub _CSIPreferredPartnerImportBackgroundWorker_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles _CSIPreferredPartnerImportBackgroundWorker.DoWork

			'objects
			Dim Imported As Boolean = False
			Dim BatchName As String = Nothing
			Dim FailedLines As Generic.Dictionary(Of Integer, String) = Nothing
			Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

			FailedLines = New Generic.Dictionary(Of Integer, String)

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				DbContext.Database.Connection.Open()

				DbTransaction = DbContext.Database.BeginTransaction

				AdvantageFramework.Importing.ImportCSIPreferredPartnerFiles(DbContext, _DownloadedFiles, BatchName, _BankCode, _CSIReconciliationTemplate, FailedLines)

				Imported = True

				DbTransaction.Commit()

				DbContext.Database.Connection.Close()

			End Using

			If FailedLines.Count > 0 Then

				CompletionWizardPageForm_CompletionPage.FinishText &= System.Environment.NewLine & System.Environment.NewLine & "The following files failed to import:" & System.Environment.NewLine & System.Environment.NewLine

				For Each FailedLine In FailedLines

					CompletionWizardPageForm_CompletionPage.FinishText &= FailedLine.Value & System.Environment.NewLine

				Next

			End If

			_BatchName = BatchName

			If Imported = False Then

				e.Cancel = True
				e.Result = Nothing

			Else

				e.Cancel = False
				e.Result = FailedLines

			End If

		End Sub
		Private Sub _CSIPreferredPartnerImportBackgroundWorker_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles _CSIPreferredPartnerImportBackgroundWorker.ProgressChanged

			If e.UserState IsNot Nothing AndAlso e.UserState.ToString = "Overall" Then

				ProgressBarImportingPage_OverallProgress.Value = e.ProgressPercentage

				If ProgressBarImportingPage_OverallProgress.Value <> ProgressBarImportingPage_OverallProgress.Maximum Then

					ProgressBarImportingPage_Progress.Value = 0
					ProgressBarImportingPage_Progress.Refresh()

				End If

			Else

				ProgressBarImportingPage_Progress.Value = e.ProgressPercentage

			End If

		End Sub
		Private Sub _CSIPreferredPartnerImportBackgroundWorker_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles _CSIPreferredPartnerImportBackgroundWorker.RunWorkerCompleted

			'objects
			Dim FailedLines As Generic.Dictionary(Of Integer, String) = Nothing
			Dim ImportingStatus As String = ""

			If e.Cancelled Then

				ImportingStatus = "Importing File(s) Failed... Click Next to continue..."

			Else

				FailedLines = e.Result

				If FailedLines IsNot Nothing AndAlso FailedLines.Count > 0 Then

					ImportingStatus = "Importing File(s) Completed but with some failed files imported... Click Next to continue..."

				Else

					ImportingStatus = "Importing File(s) Completed... Click Next to continue..."

				End If

			End If

			LabelImportingPage_ImportingStatus.Text = ImportingStatus

			WizardPageWizard_ImportingPage.AllowNext = True

		End Sub
		Private Sub _MediaVCCBackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _MediaVCCBackgroundWorker.DoWork

			Dim TransactionDeliveryClearedResponseTransactionEntities As IEnumerable(Of RTMCService.TransactionDeliveryClearedResponseTransactionEntity) = Nothing
			Dim Dictionary As System.Collections.Generic.Dictionary(Of String, AdvantageFramework.Database.Entities.ImportClearedCheckMediaVCCStaging) = Nothing
			Dim ImportClearedCheckMediaVCCStaging As AdvantageFramework.Database.Entities.ImportClearedCheckMediaVCCStaging = Nothing
			Dim ProcessDateTime As Date = Nothing
			Dim Count As Integer = 0
			Dim DataWasRetrieved As Boolean = True
			Dim ErrorMessage As String = ""
			Dim Imported As Boolean = False

			Try

				Dictionary = New System.Collections.Generic.Dictionary(Of String, AdvantageFramework.Database.Entities.ImportClearedCheckMediaVCCStaging)

				TransactionDeliveryClearedResponseTransactionEntities = VCC.GetClearedTransactionsDataForClearedCheckImport(Session, _TransactionStartDate, _TransactionEndDate)

				SetupOverallImportingProgress(0, If(TransactionDeliveryClearedResponseTransactionEntities.Count = 1, 1, TransactionDeliveryClearedResponseTransactionEntities.Count - 1), 0)

				Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

					For Each TransactionDeliveryClearedResponseTransactionEntity In TransactionDeliveryClearedResponseTransactionEntities

						Count += 1

						If TransactionDeliveryClearedResponseTransactionEntity.responseCodeField = 0 AndAlso TransactionDeliveryClearedResponseTransactionEntity.clearedSetField IsNot Nothing Then

							For Each SetField In TransactionDeliveryClearedResponseTransactionEntity.clearedSetField

								ProcessDateTime = DateTime.ParseExact(SetField.processDateField & " " & SetField.processTimeField, "yyyyMMdd HHmmssff", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None)

								If Dictionary.Count > 0 AndAlso Dictionary.ContainsKey(SetField.cardCTSField) Then

									ImportClearedCheckMediaVCCStaging = Dictionary.Item(SetField.cardCTSField)

									ImportClearedCheckMediaVCCStaging.BankAmount += SetField.transactionAmountField

								Else

									ImportClearedCheckMediaVCCStaging = New AdvantageFramework.Database.Entities.ImportClearedCheckMediaVCCStaging
									ImportClearedCheckMediaVCCStaging.DbContext = DbContext

									ImportClearedCheckMediaVCCStaging.BatchName = _BatchName
									ImportClearedCheckMediaVCCStaging.BankCode = _BankCode
									ImportClearedCheckMediaVCCStaging.BankReference = SetField.cardCTSField
									ImportClearedCheckMediaVCCStaging.BankAmount = SetField.transactionAmountField
									ImportClearedCheckMediaVCCStaging.MerchantName = SetField.merchantNameField
									ImportClearedCheckMediaVCCStaging.ClearedDate = ProcessDateTime

									Dictionary.Add(SetField.cardCTSField, ImportClearedCheckMediaVCCStaging)

								End If

								DbContext.Set(Of AdvantageFramework.Database.Entities.ImportClearedCheckMediaVCCStaging).Add(ImportClearedCheckMediaVCCStaging)

							Next

						Else

							Try

								ErrorMessage += TransactionDeliveryClearedResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

							Catch ex As Exception
								ErrorMessage = "Error retrieving cleared transactions."
							End Try

							If ErrorMessage <> "" Then

								Throw New Exception(ErrorMessage)

							End If

						End If

						_MediaVCCBackgroundWorker.ReportProgress(Count)

					Next

					DbContext.SaveChanges()

					Imported = True

				End Using

			Catch ex As Exception
				Imported = False
			End Try

			If Imported = False Then

				e.Cancel = True
				e.Result = Nothing

			Else

				e.Cancel = False
				e.Result = ErrorMessage

			End If

		End Sub
		Private Sub _MediaVCCBackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles _MediaVCCBackgroundWorker.ProgressChanged

			ProgressBarImportingPage_OverallProgress.Value = e.ProgressPercentage

		End Sub
		Private Sub _MediaVCCBackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles _MediaVCCBackgroundWorker.RunWorkerCompleted

			'objects
			Dim Imported As Boolean = False
			Dim ImportingStatus As String = ""
			Dim ErrorMessage As String = Nothing

			If e.Cancelled Then

				ImportingStatus = "Importing Failed... Click Next to continue..."

			Else

				ErrorMessage = e.Result

				If ErrorMessage IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(ErrorMessage) Then

					ImportingStatus = "Importing Completed with the following error... " & ErrorMessage & "... Click Next to continue..."

				Else

					ImportingStatus = "Importing Completed... Click Next to continue..."

				End If

			End If

			LabelImportingPage_OverallImportingStatus.Text = ImportingStatus

			WizardPageWizard_ImportingPage.AllowNext = True

		End Sub
		Private Sub DateTimePickerDateRange_FromDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerDateRange_FromDate.ValueChanged

			If Me.FormShown AndAlso DateTimePickerDateRange_FromDate.ValueObject IsNot Nothing Then

				If DateTimePickerDateRange_FromDate.ValueObject IsNot Nothing AndAlso (DateTimePickerDateRange_ToDate.ValueObject Is Nothing OrElse
						Math.Abs(DateDiff(DateInterval.Day, DateTimePickerDateRange_FromDate.GetValue, DateTimePickerDateRange_ToDate.GetValue)) > 31) Then

					DateTimePickerDateRange_ToDate.Value = DateAdd(DateInterval.Day, 31, DateTimePickerDateRange_FromDate.Value)

				End If

			End If

		End Sub
		Private Sub DateTimePickerDateRange_ToDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerDateRange_ToDate.ValueChanged

			If Me.FormShown AndAlso DateTimePickerDateRange_ToDate.ValueObject IsNot Nothing Then

				If DateTimePickerDateRange_ToDate.ValueObject IsNot Nothing AndAlso (DateTimePickerDateRange_FromDate.ValueObject Is Nothing OrElse
						Math.Abs(DateDiff(DateInterval.Day, DateTimePickerDateRange_FromDate.GetValue, DateTimePickerDateRange_ToDate.GetValue)) > 31) Then

					DateTimePickerDateRange_FromDate.Value = DateAdd(DateInterval.Day, -31, DateTimePickerDateRange_ToDate.Value)

				End If

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace
