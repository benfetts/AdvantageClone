Namespace Billing.Reports.Presentation

    Public Class InvoiceViewingForm
        Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

        Public Event UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl)
        Public Event ClearChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _SuperValidator As DevComponents.DotNetBar.Validator.SuperValidator = Nothing
        Private _ErrorProvider As System.Windows.Forms.ErrorProvider = Nothing
        Private _Highlighter As DevComponents.DotNetBar.Validator.Highlighter = Nothing
        Private _SpellChecker As AdvantageFramework.WinForm.Presentation.Controls.SpellChecker = Nothing
        Private _IsFormClosing As Boolean = False
        Private _HasLoaded As Boolean = False
        Private _FormShown As Boolean = False
        Protected _UserEntryChanged As Boolean = False
        Private _ByPassUserEntryChanged As Boolean = False
        Private _SuspendedForLoading As Boolean = False
        Private _InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault
        Private _AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
        Private _CustomLegacyAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
        Private _StandardAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
        Private _InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
        Private _InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
        Private _InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting) = Nothing
        Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
        Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
        Private _InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
        Private _IsDraft As Boolean = True
        Private _IsASP As Boolean = False
        Private _AgencyImportPath As String = ""

#End Region

#Region " Properties "

        Public ReadOnly Property DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.DefaultLookAndFeel
            Get
				DefaultLookAndFeel = DefaultLookAndFeelOffice2010Blue
			End Get
		End Property
		Public ReadOnly Property ErrorProvider As System.Windows.Forms.ErrorProvider Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.ErrorProvider
			Get
				ErrorProvider = _ErrorProvider
			End Get
		End Property
		Public Property FormAction As AdvantageFramework.WinForm.Presentation.FormActions = WinForm.Presentation.FormActions.None Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.FormAction
		Public ReadOnly Property FormShown As Boolean Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.FormShown
			Get
				FormShown = _FormShown
			End Get
		End Property
		Public ReadOnly Property HasLoaded As Boolean Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.HasLoaded
			Get
				HasLoaded = _HasLoaded
			End Get
		End Property
		Public ReadOnly Property Highlighter As DevComponents.DotNetBar.Validator.Highlighter Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.Highlighter
			Get
				Highlighter = _Highlighter
			End Get
		End Property
		Public ReadOnly Property IsFormClosing As Boolean Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.IsFormClosing
			Get
				IsFormClosing = _IsFormClosing
			End Get
		End Property
		Public ReadOnly Property IsFormModal As Boolean Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.IsFormModal
			Get
				IsFormModal = True
			End Get
		End Property
		Public ReadOnly Property Session As AdvantageFramework.Security.Session Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.Session
			Get
				Session = _Session
			End Get
		End Property
		Public Property ShowUnsavedChangesOnFormClosing As Boolean Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.ShowUnsavedChangesOnFormClosing
		Public ReadOnly Property SpellChecker As AdvantageFramework.WinForm.Presentation.Controls.SpellChecker Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.SpellChecker
			Get
				SpellChecker = _SpellChecker
			End Get
		End Property
		Public ReadOnly Property SuperValidator As DevComponents.DotNetBar.Validator.SuperValidator Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.SuperValidator
			Get
				SuperValidator = _SuperValidator
			End Get
		End Property
		Public WriteOnly Property SuspendedForLoading As Boolean Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.SuspendedForLoading, AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.SuspendedForLoading
			Set(value As Boolean)
				_SuspendedForLoading = value
			End Set
		End Property
		Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
			Set(value As Boolean)
				_ByPassUserEntryChanged = value
			End Set
		End Property
		Public ReadOnly Property UserEntryChanged As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.UserEntryChanged
			Get
				UserEntryChanged = _UserEntryChanged
			End Get
		End Property

#End Region

#Region " Methods "

		Private Sub New(Session As AdvantageFramework.Security.Session, InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes,
						AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
						InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting),
						InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting),
						AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
						OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
						InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting), IsDraft As Boolean)

            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_Session = Session
			_InvoiceFormatType = InvoiceFormatType
			_AccountReceivableInvoices = AccountReceivableInvoices
			_InvoicePrintingSettings = InvoicePrintingSettings
			_InvoicePrintingMediaSettings = InvoicePrintingMediaSettings
			_AgencyInvoicePrintingMediaSetting = AgencyInvoicePrintingMediaSetting
			_OneTimeInvoicePrintingMediaSetting = OneTimeInvoicePrintingMediaSetting
			_InvoicePrintingComboSettings = InvoicePrintingComboSettings
			_IsDraft = IsDraft
			SetupValidatorAndHighlighControls()
			SetupSpellCheckerControl()
			Me.DoubleBuffered = True

		End Sub
		Private Function LoadInvoices(Optional ByVal ClientCode As String = Nothing) As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

			If String.IsNullOrWhiteSpace(ClientCode) Then

				LoadInvoices = _StandardAccountReceivableInvoices.OrderBy(Function(Entity) Entity.ClientCode).ThenByDescending(Function(Entity) Entity.InvoiceNumber).ToList

			Else

				LoadInvoices = _StandardAccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = ClientCode).OrderBy(Function(Entity) Entity.ClientCode).ThenByDescending(Function(Entity) Entity.InvoiceNumber).ToList

			End If

		End Function
		Protected Friend Sub ClearValidations() Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.ClearValidations

			If _SuperValidator IsNot Nothing Then

				_SuperValidator.ClearFailedValidations()

			End If

		End Sub
		Protected Friend Function ValidateControl(ByVal Control As System.Windows.Forms.Control) As Boolean Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.ValidateControl

			Dim IsValid As Boolean = True

			If _SuperValidator IsNot Nothing Then

				IsValid = _SuperValidator.Validate(Control)

			End If

			ValidateControl = IsValid

		End Function
		Private Sub SetupValidatorAndHighlighControls()

			Me.SuspendLayout()

			_SuperValidator = New DevComponents.DotNetBar.Validator.SuperValidator
			_ErrorProvider = New System.Windows.Forms.ErrorProvider
			_Highlighter = New DevComponents.DotNetBar.Validator.Highlighter

			_SuperValidator.CancelValidatingOnControl = False
			_SuperValidator.ContainerControl = Me
			_SuperValidator.Enabled = True
			_SuperValidator.ErrorProvider = _ErrorProvider
			_SuperValidator.Highlighter = _Highlighter
			_SuperValidator.SteppedValidation = True
			_SuperValidator.ValidationType = DevComponents.DotNetBar.Validator.eValidationType.ValidatingEventPerControl
			_SuperValidator.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"

			_ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
			_ErrorProvider.ContainerControl = Me

			_Highlighter.ContainerControl = Me
			_Highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"

			Me.ResumeLayout(True)

		End Sub
		Private Sub SetupSpellCheckerControl()

			Dim SpellCheckerISpellDictionary As DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary = Nothing

			Me.SuspendLayout()

			_SpellChecker = New AdvantageFramework.WinForm.Presentation.Controls.SpellChecker

			_SpellChecker.ParentContainer = Me

			SpellCheckerISpellDictionary = New DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary

			SpellCheckerISpellDictionary.DictionaryPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\AmericanXLG.xlg"
			SpellCheckerISpellDictionary.AlphabetPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\EnglishAlphabet.txt"
			SpellCheckerISpellDictionary.GrammarPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\EnglishAFF.aff"

			SpellCheckerISpellDictionary.Culture = My.Application.Culture

			_SpellChecker.Dictionaries.Add(SpellCheckerISpellDictionary)

			Me.ResumeLayout(True)

		End Sub
		Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

			AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettings(Me)

			MyBase.OnLoad(e)

		End Sub
		Public Sub ClearChanged() Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ClearChanged

			AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

			_UserEntryChanged = False

			ClearValidations()

			If Me.FormShown Then

				RaiseEvent ClearChangedEvent()

			End If

		End Sub
		Public Sub SetFormActionAndShowWaitForm(ByVal FormAction As WinForm.Presentation.FormActions, Optional ByVal Message As String = Nothing) Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.SetFormActionAndShowWaitForm

			Me.FormAction = FormAction

			If FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

				AdvantageFramework.WinForm.Presentation.CloseWaitForm()

			Else

				AdvantageFramework.WinForm.Presentation.ShowWaitForm(Message)

			End If

		End Sub
		Private Sub ViewInvoice()

			If DataGridViewInvoices.HasASelectedRow Then

				'CreateCoverSheet(DataGridViewInvoices.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice).ToList)

				_AccountReceivableInvoice = DataGridViewInvoices.GetFirstSelectedRowDataBoundItem

				If _AccountReceivableInvoice IsNot Nothing Then

					If _AccountReceivableInvoice.RecordType <> "P" AndAlso _AccountReceivableInvoice.RecordType <> "C" Then

						If _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                            _InvoicePrintingMediaSetting = _InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = _AccountReceivableInvoice.ClientCode)

                        Else

							_InvoicePrintingMediaSetting = _InvoicePrintingMediaSettings.FirstOrDefault

						End If

						If _InvoicePrintingMediaSetting IsNot Nothing Then

							Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

							BarButtonItemShowBackupReport.Enabled = False
							BarButtonItemShowBackupReport.Down = False

							Me.FormAction = WinForm.Presentation.FormActions.None

							CreateInvoice()

							BarButtonItemPrintOptionsSetup.Enabled = True

						End If

					ElseIf _AccountReceivableInvoice.RecordType = "P" Then

						If _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                            _InvoicePrintingSetting = _InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = _AccountReceivableInvoice.ClientCode)

                        Else

							_InvoicePrintingSetting = _InvoicePrintingSettings.FirstOrDefault

						End If

						If _InvoicePrintingSetting IsNot Nothing Then

							Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

							BarButtonItemShowBackupReport.Enabled = _InvoicePrintingSetting.IncludeBackupReport.GetValueOrDefault(False)

							If BarButtonItemShowBackupReport.Enabled = False Then

								BarButtonItemShowBackupReport.Down = False

							End If

							Me.FormAction = WinForm.Presentation.FormActions.None

							CreateInvoice()

							BarButtonItemPrintOptionsSetup.Enabled = True

						End If

					ElseIf _AccountReceivableInvoice.RecordType = "C" Then

						If _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                            _InvoicePrintingSetting = _InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = _AccountReceivableInvoice.ClientCode)
                            _InvoicePrintingMediaSetting = _InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = _AccountReceivableInvoice.ClientCode)
                            _InvoicePrintingComboSetting = _InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = _AccountReceivableInvoice.ClientCode)

                        Else

							_InvoicePrintingSetting = _InvoicePrintingSettings.FirstOrDefault
							_InvoicePrintingMediaSetting = _InvoicePrintingMediaSettings.FirstOrDefault
							_InvoicePrintingComboSetting = _InvoicePrintingComboSettings.FirstOrDefault

						End If

						If _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingMediaSetting IsNot Nothing AndAlso _InvoicePrintingComboSetting IsNot Nothing Then

							Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

							BarButtonItemShowBackupReport.Enabled = False
							BarButtonItemShowBackupReport.Down = False

							Me.FormAction = WinForm.Presentation.FormActions.None

							CreateInvoice()

							BarButtonItemPrintOptionsSetup.Enabled = True

						End If

					End If

				End If

			Else

				DocumentViewer.PrintingSystem = Nothing

			End If

		End Sub
		'Private Sub CreateCoverSheet(AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice))

		'    'objects
		'    Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

		'    Report = AdvantageFramework.Reporting.Reports.CreateCoverSheet(_Session, AccountReceivableInvoices, _IsDraft)

		'    If Report IsNot Nothing Then

		'        DocumentViewer.PrintingSystem = Report.PrintingSystem

		'        Report.CreateDocument(True)

		'    Else

		'        DocumentViewer.PrintingSystem = Nothing

		'    End If

		'End Sub
		Private Sub CreateInvoice()

			'objects
			Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
			Dim PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler = Nothing

			Report = AdvantageFramework.Reporting.Reports.CreateInvoice(_Session, _AccountReceivableInvoice, _InvoicePrintingSetting, _InvoicePrintingMediaSetting, _InvoicePrintingComboSetting, _AgencyInvoicePrintingMediaSetting, _OneTimeInvoicePrintingMediaSetting, BarButtonItemShowBackupReport.Down, _IsDraft, InvoicePrinting.InvoicePrintingTypes.Preview)

			If Report IsNot Nothing Then

				Report.DisplayName = AdvantageFramework.Billing.Reports.Presentation.CreateFileName(_AccountReceivableInvoice.InvoiceNumber, _AccountReceivableInvoice.InvoiceSequenceNumber, _AccountReceivableInvoice.ClientCode, BarButtonItemShowBackupReport.Down)

				If _IsASP Then

					If My.Computer.FileSystem.DirectoryExists(_AgencyImportPath) Then

						If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath.Trim, "\") & "Reports\") = False Then

							My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath.Trim, "\") & "Reports\")

						End If

					End If

					Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.Billing.Reports.Presentation.CreateFileName(_AccountReceivableInvoice.InvoiceNumber, _AccountReceivableInvoice.InvoiceSequenceNumber, _AccountReceivableInvoice.ClientCode, BarButtonItemShowBackupReport.Down)
					Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(_AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath.Trim, "\") & "Reports\")
					Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
					Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

					PrintingSystemCommandHandler = New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(_Session, If(String.IsNullOrWhiteSpace(_AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath.Trim, "\") & "Reports\"), AdvantageFramework.Billing.Reports.Presentation.CreateFileName(_AccountReceivableInvoice.InvoiceNumber, _AccountReceivableInvoice.InvoiceSequenceNumber, _AccountReceivableInvoice.ClientCode, BarButtonItemShowBackupReport.Down), False)

					'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
					Report.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

				Else

					Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.Billing.Reports.Presentation.CreateFileName(_AccountReceivableInvoice.InvoiceNumber, _AccountReceivableInvoice.InvoiceSequenceNumber, _AccountReceivableInvoice.ClientCode, BarButtonItemShowBackupReport.Down)

				End If

				DocumentViewer.PrintingSystem = Report.PrintingSystem

				If PrintingSystemCommandHandler IsNot Nothing Then

					DocumentViewer.PrintingSystem.AddCommandHandler(PrintingSystemCommandHandler)

				End If

				Report.CreateDocument(True)

			Else

				If _AccountReceivableInvoice IsNot Nothing Then

					If _AccountReceivableInvoice.RecordType <> "P" AndAlso _AccountReceivableInvoice.RecordType <> "C" Then

						If _InvoicePrintingMediaSetting IsNot Nothing Then

							If ((_AccountReceivableInvoice.RecordType = "M" AndAlso _InvoicePrintingMediaSetting.MagazineShowZeroLineAmounts = False) OrElse
								(_AccountReceivableInvoice.RecordType = "N" AndAlso _InvoicePrintingMediaSetting.NewspaperShowZeroLineAmounts = False) OrElse
								(_AccountReceivableInvoice.RecordType = "I" AndAlso _InvoicePrintingMediaSetting.InternetShowZeroLineAmounts = False) OrElse
								(_AccountReceivableInvoice.RecordType = "O" AndAlso _InvoicePrintingMediaSetting.OutdoorShowZeroLineAmounts = False) OrElse
								(_AccountReceivableInvoice.RecordType = "R" AndAlso _InvoicePrintingMediaSetting.RadioShowZeroLineAmounts = False) OrElse
								(_AccountReceivableInvoice.RecordType = "T" AndAlso _InvoicePrintingMediaSetting.TVShowZeroLineAmounts = False)) AndAlso _AccountReceivableInvoice.InvoiceAmount = 0 Then

								AdvantageFramework.WinForm.MessageBox.Show("There are no invoice billing amounts for client:  " & _AccountReceivableInvoice.ClientCode)

							End If

						End If

					ElseIf _AccountReceivableInvoice.RecordType = "P" Then

						If _InvoicePrintingSetting IsNot Nothing Then

							If _InvoicePrintingSetting.ShowZeroFunctionAmounts.GetValueOrDefault(False) = False AndAlso _AccountReceivableInvoice.RecordType = "P" AndAlso _AccountReceivableInvoice.InvoiceAmount = 0 Then

								AdvantageFramework.WinForm.MessageBox.Show("There are no invoice billing amounts for client:  " & _AccountReceivableInvoice.ClientCode)

							End If

						End If

					ElseIf _AccountReceivableInvoice.RecordType = "C" Then

						If _AccountReceivableInvoice.InvoiceAmount = 0 Then

							AdvantageFramework.WinForm.MessageBox.Show("There are no invoice billing amounts for client:  " & _AccountReceivableInvoice.ClientCode)

						End If

					End If

				End If

				DocumentViewer.PrintingSystem = Nothing

			End If

		End Sub
		Private Function CheckForUnsavedChanges() As Boolean

			'objects
			Dim IsOkay As Boolean = True

			If DataGridViewInvoices.UserEntryChanged AndAlso BarButtonItemActionsSave.Enabled Then

				If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

					DataGridViewInvoices.CurrentView.CloseEditorForUpdating()

					IsOkay = DataGridViewInvoices.Validate

					If IsOkay Then

						AdvantageFramework.WinForm.Presentation.ShowWaitForm("Saving...")

						Try

							IsOkay = Save()

						Catch ex As Exception
							AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
							IsOkay = False
						End Try

						If IsOkay = False Then

							If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

								IsOkay = True

							End If

						Else

							ViewInvoice()

						End If

						AdvantageFramework.WinForm.Presentation.CloseWaitForm()

						DataGridViewInvoices.ClearChanged()

					End If

				End If

			End If

			CheckForUnsavedChanges = IsOkay

		End Function
		Private Function Save() As Boolean

			'objects
			Dim Saved As Boolean = False
			Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

			If DataGridViewInvoices.HasRows Then

				Saved = True

				DataGridViewInvoices.CurrentView.CloseEditorForUpdating()

				AccountReceivableInvoices = DataGridViewInvoices.GetAllModifiedRows.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

				AdvantageFramework.WinForm.Presentation.ShowWaitForm("Saving...")
				AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

				Try

					Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

						For Each AccountReceivableInvoice In AccountReceivableInvoices

							AdvantageFramework.InvoicePrinting.SaveInvoice(DbContext, AccountReceivableInvoice)

						Next

					End Using

				Catch ex As Exception
					Saved = False
				End Try

				AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

				If Saved Then

					Try

						DataGridViewInvoices.ValidateAllRowsAndClearChanged(True)

					Catch ex As Exception

					End Try

				End If

				AdvantageFramework.WinForm.Presentation.CloseWaitForm()

			End If

			Save = Saved

		End Function
		Private Sub EnableOrDisableActions()

			BarButtonItemPrintOptionsSetup.Enabled = DataGridViewInvoices.HasASelectedRow
			BarButtonItemCommentsJob.Enabled = (_IsDraft = False AndAlso DataGridViewInvoices.HasASelectedRow AndAlso DataGridViewInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().Where(Function(Entity) Entity.RecordType = "P" OrElse Entity.RecordType = "C").Any)
			BarButtonItemCommentsFunction.Enabled = (_IsDraft = False AndAlso DataGridViewInvoices.HasASelectedRow AndAlso DataGridViewInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().Where(Function(Entity) Entity.RecordType = "P" OrElse Entity.RecordType = "C").Any)
			BarButtonItemPrint.Enabled = DataGridViewInvoices.HasASelectedRow
			BarButtonItemQuickPrint.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemExportTo.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemExportToImage.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemExportToPDF.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemExportToRTF.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemExportToXLS.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemExportToXLSX.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemEmailAs.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemEmailAsImage.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemEmailAsPDF.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemEmailAsRTF.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemEmailAsXLS.Enabled = DataGridViewInvoices.HasASelectedRow
			PrintPreviewBarItemEmailAsXLSX.Enabled = DataGridViewInvoices.HasASelectedRow

			BarButtonItemQuickEmail.Enabled = (DataGridViewInvoices.HasOnlyOneSelectedRow = True AndAlso _IsASP = False)

		End Sub
		Private Sub RefreshInvoicePrintingSettings()

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				_InvoicePrintingSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, _InvoiceFormatType).ToList
				_InvoicePrintingMediaSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, _InvoiceFormatType).ToList

			End Using

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				_InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, _InvoiceFormatType).ToList

			End Using

		End Sub
		Public Sub BaseFormUserEntryChanged(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl)

			If Me.FormShown AndAlso _UserEntryChanged = False AndAlso _ByPassUserEntryChanged = False Then

				_UserEntryChanged = Control.UserEntryChanged

				If Control.UserEntryChanged AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

					RaiseEvent UserEntryChangedEvent(Control)

				End If

			End If

		End Sub
		Private Sub SendEmails(ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions)

			'objects
			Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
			Dim InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting = Nothing

			If CheckForUnsavedChanges() Then

				If DataGridViewInvoices.HasASelectedRow Then

					AccountReceivableInvoices = DataGridViewInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

					InvoicePrintingPageSetting = New AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting

					InvoicePrintingPageSetting.SetSettings(DocumentViewer.PrintingSystem)

					Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

					Try

						AdvantageFramework.Billing.Reports.Presentation.SendInvoiceEmails(Me, Me.Session, AccountReceivableInvoices, _InvoiceFormatType, _IsDraft, ToFileOption, InvoicePrintingPageSetting)

					Catch ex As Exception

					End Try

					Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

				Else

					AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

				End If

			End If

		End Sub
		Private Sub ExportTo(ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions)

			'objects
			Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
			Dim InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting = Nothing

			If CheckForUnsavedChanges() Then

				If DataGridViewInvoices.HasASelectedRow Then

					AccountReceivableInvoices = DataGridViewInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

					InvoicePrintingPageSetting = New AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting

					InvoicePrintingPageSetting.SetSettings(DocumentViewer.PrintingSystem)

					Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

					Try

						AdvantageFramework.Billing.Reports.Presentation.PrintToFile(Me, Me.Session, AccountReceivableInvoices, _InvoiceFormatType, False, ToFileOption, _IsDraft, InvoicePrintingPageSetting)

					Catch ex As Exception

					End Try

					Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

				Else

					AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

				End If

			End If

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(Session As AdvantageFramework.Security.Session, InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes,
											  AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
											  InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting),
											  InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting),
											  AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
											  OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
											  InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting), IsDraft As Boolean) As Windows.Forms.DialogResult

			'objects
			Dim InvoiceViewingForm As InvoiceViewingForm = Nothing

			InvoiceViewingForm = New InvoiceViewingForm(Session, InvoiceFormatType, AccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSettings, IsDraft)

			ShowFormDialog = InvoiceViewingForm.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub InvoiceViewingForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			'objects
			Dim Clients As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing
			Dim AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
			Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
			Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
			Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
			Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
			Dim ReportExportPath As String = ""

			BarButtonItemActionsSave.LargeGlyph = AdvantageFramework.My.Resources.SaveImage
			BarButtonItemPrintOptionsSetup.LargeGlyph = AdvantageFramework.My.Resources.InvoicePropertiesImage
			BarButtonItemCommentsJob.Glyph = AdvantageFramework.My.Resources.InvoicePropertiesImage
			BarButtonItemCommentsFunction.Glyph = AdvantageFramework.My.Resources.InvoicePropertiesImage
			BarButtonItemShowBackupReport.LargeGlyph = AdvantageFramework.My.Resources.InvoicePrintImage

			ComboBoxClient.ByPassUserEntryChanged = True

			Me.WindowState = Windows.Forms.FormWindowState.Maximized

			Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

				_IsASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)
				_AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

				If _IsASP = False Then

					ReportExportPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath)

					If String.IsNullOrWhiteSpace(ReportExportPath) Then

						ReportExportPath = AdvantageFramework.Database.Procedures.Agency.LoadReportTempPath(DbContext)

					End If

					If My.Computer.FileSystem.DirectoryExists(ReportExportPath) Then

						_AgencyImportPath = ReportExportPath

					End If

				End If

			End Using

			_CustomLegacyAccountReceivableInvoices = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)
			_StandardAccountReceivableInvoices = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

			For Each AccountReceivableInvoice In _AccountReceivableInvoices

				If AccountReceivableInvoice IsNot Nothing Then

					If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

						If _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

							InvoicePrintingMediaSetting = _InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

						Else

							InvoicePrintingMediaSetting = _InvoicePrintingMediaSettings.FirstOrDefault

						End If

						If InvoicePrintingMediaSetting IsNot Nothing Then

							If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
									(AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
									(AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
									(AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
									(AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
									(AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

								_CustomLegacyAccountReceivableInvoices.Add(AccountReceivableInvoice)

							Else

								_StandardAccountReceivableInvoices.Add(AccountReceivableInvoice)

							End If

						End If

					ElseIf AccountReceivableInvoice.RecordType = "P" Then

						If _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

							InvoicePrintingSetting = _InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

						Else

							InvoicePrintingSetting = _InvoicePrintingSettings.FirstOrDefault

						End If

						If InvoicePrintingSetting IsNot Nothing Then

							If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

								_CustomLegacyAccountReceivableInvoices.Add(AccountReceivableInvoice)

							Else

								_StandardAccountReceivableInvoices.Add(AccountReceivableInvoice)

							End If

						End If

					ElseIf AccountReceivableInvoice.RecordType = "C" Then

						If _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

							InvoicePrintingComboSetting = _InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

						Else

							InvoicePrintingComboSetting = _InvoicePrintingComboSettings.FirstOrDefault

						End If

						If InvoicePrintingComboSetting IsNot Nothing Then

							'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

							'    _CustomLegacyAccountReceivableInvoices.Add(AccountReceivableInvoice)

							'Else

							_StandardAccountReceivableInvoices.Add(AccountReceivableInvoice)

							' End If

						End If

					End If

				End If

			Next

			Try

				Clients = (From Entity In _StandardAccountReceivableInvoices
						   Select Entity.ClientCode,
								  Entity.ClientName).Distinct.ToList.Select(Function(Entity) New AdvantageFramework.Database.Core.Client With {.Code = Entity.ClientCode,
																																			   .Name = Entity.ClientName,
																																			   .IsActive = 1}).OrderBy(Function(Entity) Entity.Code).ToList

			Catch ex As Exception
				Clients = Nothing
			End Try

			ComboBoxClient.DataSource = Clients

			DataGridViewInvoices.DataSource = LoadInvoices()

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

					DataGridViewInvoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyCode.ToString)
					DataGridViewInvoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyRate.ToString)
					DataGridViewInvoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyAmount.ToString)

				Else

					DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyCode.ToString)
					DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyRate.ToString)
					DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyAmount.ToString)

				End If

			End Using

			DataGridViewInvoices.CurrentView.BestFitColumns()

            Try

                Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName)

            Catch ex As Exception

                Me.Icon = AdvantageFramework.My.Resources.AdvantageIcon

            End Try

            _HasLoaded = True

			Me.ClearChanged()

			If _IsDraft Then

				DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DueDate.ToString)
				DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceComment.ToString)
				DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceCategoryCode.ToString)
				DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceContact.ToString)
				DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceContactName.ToString)

			End If

		End Sub
		Private Sub InvoiceViewingForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If _CustomLegacyAccountReceivableInvoices.Count > 0 Then

                AdvantageFramework.Reporting.Reports.CreateCustomInvoice(Session, _CustomLegacyAccountReceivableInvoices, _InvoicePrintingSettings, _InvoicePrintingMediaSettings, _IsDraft, AdvantageFramework.InvoicePrinting.InvoicePrintingTypes.Preview)

            End If

            If _StandardAccountReceivableInvoices.Count > 0 Then

                EnableOrDisableActions()

                If DataGridViewInvoices.HasASelectedRow Then

                    ViewInvoice()

                Else

                    BarButtonItemPrintOptionsSetup.Enabled = False

                End If

                _FormShown = True

                Me.ClearChanged()

            Else

                Me.Close()

            End If

        End Sub
        Private Sub InvoiceViewingForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            BarButtonItemActionsSave.Enabled = False

        End Sub
        Private Sub InvoiceViewingForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            BarButtonItemActionsSave.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxClient_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxClient.SelectedValueChanged

            If Me.FormShown Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                If ComboBoxClient.HasASelectedValue Then

                    DataGridViewInvoices.DataSource = LoadInvoices(ComboBoxClient.GetSelectedValue)

                Else

                    DataGridViewInvoices.DataSource = LoadInvoices()

                End If

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

						DataGridViewInvoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyCode.ToString)
						DataGridViewInvoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyRate.ToString)
						DataGridViewInvoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyAmount.ToString)

					Else

						DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyCode.ToString)
						DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyRate.ToString)
						DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyAmount.ToString)

					End If

				End Using

				Me.FormAction = WinForm.Presentation.FormActions.None

                DataGridViewInvoices.CurrentView.BestFitColumns()

                ViewInvoice()

            End If

        End Sub
        Private Sub DataGridViewInvoices_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoices.CellValueChangedEvent

            ViewInvoice()

        End Sub
        Private Sub DataGridViewInvoices_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoices.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceDate.ToString Then

                Saved = True

            End If

        End Sub
        Private Sub DataGridViewInvoices_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewInvoices.LeavingRowEvent

            e.Allow = CheckForUnsavedChanges()

        End Sub
        Private Sub DataGridViewInvoices_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoices.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ViewInvoice()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Invoices_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewInvoices.QueryPopupNeedDatasourceEvent

            'objects
            Dim AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing

            If FieldName = AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceContact.ToString Then

                Try

                    AccountReceivableInvoice = DataGridViewInvoices.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    AccountReceivableInvoice = Nothing
                End Try

                If AccountReceivableInvoice IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Datasource = AdvantageFramework.Database.Procedures.ClientContact.LoadAllActiveByClientCode(DbContext, AccountReceivableInvoice.ClientCode).ToList

                    End Using

                End If

                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub BarButtonItemPrintOptionsSetup_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemPrintOptionsSetup.ItemClick

            'objects
            Dim ClientCodes As Generic.List(Of String) = Nothing
            Dim ShowProductionOptions As Boolean = False
            Dim ShowMagazineOptions As Boolean = False
            Dim ShowNewspaperOptions As Boolean = False
            Dim ShowInternetOptions As Boolean = False
            Dim ShowOutdoorOptions As Boolean = False
            Dim ShowRadioOptions As Boolean = False
            Dim ShowTVOptions As Boolean = False
            Dim ShowComboOptions As Boolean = False
            Dim InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing

            InvoiceFormatType = _InvoiceFormatType

            If _AccountReceivableInvoice IsNot Nothing Then

                If _AccountReceivableInvoice.RecordType <> "P" AndAlso _AccountReceivableInvoice.RecordType <> "C" Then

                    Select Case _AccountReceivableInvoice.RecordType

                        Case "M"

                            ShowMagazineOptions = True

                        Case "N"

                            ShowNewspaperOptions = True

                        Case "I"

                            ShowInternetOptions = True

                        Case "O"

                            ShowOutdoorOptions = True

                        Case "R"

                            ShowRadioOptions = True

                        Case "T"

                            ShowTVOptions = True

                    End Select

                    If _InvoicePrintingMediaSetting IsNot Nothing Then

                        If _InvoiceFormatType = InvoicePrinting.InvoiceFormatTypes.ClientDefault Then

                            If (ShowMagazineOptions AndAlso _InvoicePrintingMediaSetting.MagazineUseAgencySetting) OrElse
                                    (ShowNewspaperOptions AndAlso _InvoicePrintingMediaSetting.NewspaperUseAgencySetting) OrElse
                                    (ShowInternetOptions AndAlso _InvoicePrintingMediaSetting.InternetUseAgencySetting) OrElse
                                    (ShowOutdoorOptions AndAlso _InvoicePrintingMediaSetting.OutdoorUseAgencySetting) OrElse
                                    (ShowRadioOptions AndAlso _InvoicePrintingMediaSetting.RadioUseAgencySetting) OrElse
                                    (ShowTVOptions AndAlso _InvoicePrintingMediaSetting.TVUseAgencySetting) Then

                                InvoiceFormatType = InvoicePrinting.InvoiceFormatTypes.Agency

                                _InvoicePrintingMediaSetting.AddressBlockType = _AgencyInvoicePrintingMediaSetting.AddressBlockType.GetValueOrDefault(_OneTimeInvoicePrintingMediaSetting.AddressBlockType.GetValueOrDefault(1))

                                If String.IsNullOrWhiteSpace(_AgencyInvoicePrintingMediaSetting.CustomFormatName) = True Then

                                    _InvoicePrintingMediaSetting.CustomFormatName = _OneTimeInvoicePrintingMediaSetting.CustomFormatName

                                Else

                                    _InvoicePrintingMediaSetting.CustomFormatName = _AgencyInvoicePrintingMediaSetting.CustomFormatName

                                End If

								_InvoicePrintingMediaSetting.MagazineCustomInvoiceID = If(_AgencyInvoicePrintingMediaSetting.MagazineCustomInvoiceID.HasValue, _AgencyInvoicePrintingMediaSetting.MagazineCustomInvoiceID, If(_OneTimeInvoicePrintingMediaSetting.MagazineCustomInvoiceID.HasValue, _OneTimeInvoicePrintingMediaSetting.MagazineCustomInvoiceID, Nothing))
								_InvoicePrintingMediaSetting.NewspaperCustomInvoiceID = If(_AgencyInvoicePrintingMediaSetting.NewspaperCustomInvoiceID.HasValue, _AgencyInvoicePrintingMediaSetting.NewspaperCustomInvoiceID, If(_OneTimeInvoicePrintingMediaSetting.NewspaperCustomInvoiceID.HasValue, _OneTimeInvoicePrintingMediaSetting.NewspaperCustomInvoiceID, Nothing))
								_InvoicePrintingMediaSetting.InternetCustomInvoiceID = If(_AgencyInvoicePrintingMediaSetting.InternetCustomInvoiceID.HasValue, _AgencyInvoicePrintingMediaSetting.InternetCustomInvoiceID, If(_OneTimeInvoicePrintingMediaSetting.InternetCustomInvoiceID.HasValue, _OneTimeInvoicePrintingMediaSetting.InternetCustomInvoiceID, Nothing))
								_InvoicePrintingMediaSetting.OutdoorCustomInvoiceID = If(_AgencyInvoicePrintingMediaSetting.OutdoorCustomInvoiceID.HasValue, _AgencyInvoicePrintingMediaSetting.OutdoorCustomInvoiceID, If(_OneTimeInvoicePrintingMediaSetting.OutdoorCustomInvoiceID.HasValue, _OneTimeInvoicePrintingMediaSetting.OutdoorCustomInvoiceID, Nothing))
								_InvoicePrintingMediaSetting.RadioCustomInvoiceID = If(_AgencyInvoicePrintingMediaSetting.RadioCustomInvoiceID.HasValue, _AgencyInvoicePrintingMediaSetting.RadioCustomInvoiceID, If(_OneTimeInvoicePrintingMediaSetting.RadioCustomInvoiceID.HasValue, _OneTimeInvoicePrintingMediaSetting.RadioCustomInvoiceID, Nothing))
								_InvoicePrintingMediaSetting.TVCustomInvoiceID = If(_AgencyInvoicePrintingMediaSetting.TVCustomInvoiceID.HasValue, _AgencyInvoicePrintingMediaSetting.TVCustomInvoiceID, If(_OneTimeInvoicePrintingMediaSetting.TVCustomInvoiceID.HasValue, _OneTimeInvoicePrintingMediaSetting.TVCustomInvoiceID, Nothing))
								_InvoicePrintingMediaSetting.PrintClientName = _AgencyInvoicePrintingMediaSetting.PrintClientName
								_InvoicePrintingMediaSetting.PrintDivisionName = _AgencyInvoicePrintingMediaSetting.PrintDivisionName.GetValueOrDefault(_OneTimeInvoicePrintingMediaSetting.PrintDivisionName.GetValueOrDefault(False))
                                _InvoicePrintingMediaSetting.PrintProductDescription = _AgencyInvoicePrintingMediaSetting.PrintProductDescription.GetValueOrDefault(_OneTimeInvoicePrintingMediaSetting.PrintProductDescription.GetValueOrDefault(False))
                                _InvoicePrintingMediaSetting.PrintContactAfterAddress = _AgencyInvoicePrintingMediaSetting.PrintContactAfterAddress.GetValueOrDefault(_OneTimeInvoicePrintingMediaSetting.PrintContactAfterAddress.GetValueOrDefault(False))
                                _InvoicePrintingMediaSetting.ShowCodes = _AgencyInvoicePrintingMediaSetting.ShowCodes
                                _InvoicePrintingMediaSetting.ContactType = _AgencyInvoicePrintingMediaSetting.ContactType
                                _InvoicePrintingMediaSetting.IncludeBillingComment = _AgencyInvoicePrintingMediaSetting.IncludeBillingComment.GetValueOrDefault(_OneTimeInvoicePrintingMediaSetting.IncludeBillingComment.GetValueOrDefault(False))
                                _InvoicePrintingMediaSetting.ApplyExchangeRate = _AgencyInvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(_OneTimeInvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(1))
                                _InvoicePrintingMediaSetting.ExchangeRateAmount = _AgencyInvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(_OneTimeInvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(1))
                                _InvoicePrintingMediaSetting.InvoiceFooterCommentType = _AgencyInvoicePrintingMediaSetting.InvoiceFooterCommentType.GetValueOrDefault(_OneTimeInvoicePrintingMediaSetting.InvoiceFooterCommentType.GetValueOrDefault(1))

                                If String.IsNullOrWhiteSpace(_AgencyInvoicePrintingMediaSetting.InvoiceFooterComment) = True Then

                                    _InvoicePrintingMediaSetting.InvoiceFooterComment = _OneTimeInvoicePrintingMediaSetting.InvoiceFooterComment

                                Else

                                    _InvoicePrintingMediaSetting.InvoiceFooterComment = _AgencyInvoicePrintingMediaSetting.InvoiceFooterComment

                                End If

                                If String.IsNullOrWhiteSpace(_AgencyInvoicePrintingMediaSetting.LocationCode) = True Then

                                    _InvoicePrintingMediaSetting.LocationCode = _OneTimeInvoicePrintingMediaSetting.LocationCode

                                Else

                                    _InvoicePrintingMediaSetting.LocationCode = _AgencyInvoicePrintingMediaSetting.LocationCode

                                End If

                                _InvoicePrintingMediaSetting.UseLocationPrintOptions = _AgencyInvoicePrintingMediaSetting.UseLocationPrintOptions.GetValueOrDefault(_OneTimeInvoicePrintingMediaSetting.UseLocationPrintOptions.GetValueOrDefault(False))

                            End If

                        End If

                        If InvoicePrintingOptionsDialog.ShowFormDialog(InvoiceFormatType, Nothing, _InvoicePrintingMediaSetting, Nothing, New Generic.List(Of String)({_AccountReceivableInvoice.ClientCode}), _IsDraft, ShowProductionOptions, ShowMagazineOptions, ShowNewspaperOptions, ShowInternetOptions, ShowOutdoorOptions, ShowRadioOptions, ShowTVOptions, ShowComboOptions, True) = Windows.Forms.DialogResult.OK Then

                            RefreshInvoicePrintingSettings()

                            ViewInvoice()

                        End If

                    End If

                ElseIf _AccountReceivableInvoice.RecordType = "P" Then

                    ShowProductionOptions = True

                    If _InvoicePrintingSetting IsNot Nothing Then

                        If _InvoiceFormatType = InvoicePrinting.InvoiceFormatTypes.ClientDefault Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadByClientCode(DbContext, _AccountReceivableInvoice.ClientCode)

                            End Using

                            If ProductionInvoiceDefault IsNot Nothing Then

                                If ProductionInvoiceDefault.UseAgencySetting Then

                                    InvoiceFormatType = InvoicePrinting.InvoiceFormatTypes.Agency

                                End If

                            End If

                        End If

                        If InvoicePrintingOptionsDialog.ShowFormDialog(InvoiceFormatType, _InvoicePrintingSetting, Nothing, Nothing, New Generic.List(Of String)({_AccountReceivableInvoice.ClientCode}), _IsDraft, ShowProductionOptions, ShowMagazineOptions, ShowNewspaperOptions, ShowInternetOptions, ShowOutdoorOptions, ShowRadioOptions, ShowTVOptions, ShowComboOptions, True) = Windows.Forms.DialogResult.OK Then

                            RefreshInvoicePrintingSettings()

                            ViewInvoice()

                        End If

                    End If

                ElseIf _AccountReceivableInvoice.RecordType = "C" Then

                    ShowComboOptions = True
                    ShowProductionOptions = True
                    ShowMagazineOptions = True
                    ShowNewspaperOptions = True
                    ShowInternetOptions = True
                    ShowOutdoorOptions = True
                    ShowRadioOptions = True
                    ShowTVOptions = True

                    If _InvoicePrintingComboSetting IsNot Nothing Then

                        If InvoicePrintingOptionsDialog.ShowFormDialog(_InvoiceFormatType, _InvoicePrintingSetting, _InvoicePrintingMediaSetting, _InvoicePrintingComboSetting, New Generic.List(Of String)({_AccountReceivableInvoice.ClientCode}), _IsDraft, ShowProductionOptions, ShowMagazineOptions, ShowNewspaperOptions, ShowInternetOptions, ShowOutdoorOptions, ShowRadioOptions, ShowTVOptions, ShowComboOptions, True) = Windows.Forms.DialogResult.OK Then

                            RefreshInvoicePrintingSettings()

                            ViewInvoice()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub BarButtonItemActionsSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemActionsSave.ItemClick

            If Save() Then

                EnableOrDisableActions()

                ViewInvoice()

            End If

        End Sub
        Private Sub BarButtonItemCommentsJob_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemCommentsJob.ItemClick

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            If DataGridViewInvoices.HasASelectedRow Then

                Try

                    AccountReceivableInvoices = DataGridViewInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().Where(Function(Entity) Entity.RecordType = "P" OrElse Entity.RecordType = "C").ToList

                Catch ex As Exception
                    AccountReceivableInvoices = Nothing
                End Try

                If AccountReceivableInvoices IsNot Nothing AndAlso AccountReceivableInvoices.Count > 0 Then

                    If InvoicePrintingCommentsDialog.ShowFormDialog(InvoicePrintingCommentsDialog.Type.JobComment, AccountReceivableInvoices) = Windows.Forms.DialogResult.OK Then

                        ViewInvoice()

                    End If

                End If

            End If

        End Sub
        Private Sub BarButtonItemCommentsFunction_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemCommentsFunction.ItemClick

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            If DataGridViewInvoices.HasASelectedRow Then

                Try

                    AccountReceivableInvoices = DataGridViewInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().Where(Function(Entity) Entity.RecordType = "P" OrElse Entity.RecordType = "C").ToList

                Catch ex As Exception
                    AccountReceivableInvoices = Nothing
                End Try

                If AccountReceivableInvoices IsNot Nothing AndAlso AccountReceivableInvoices.Count > 0 Then

                    If InvoicePrintingCommentsDialog.ShowFormDialog(InvoicePrintingCommentsDialog.Type.JobFunctionComment, AccountReceivableInvoices) = Windows.Forms.DialogResult.OK Then

                        ViewInvoice()

                    End If

                End If

            End If

        End Sub
        Private Sub BarButtonItemShowBackupReport_DownChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemShowBackupReport.DownChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ViewInvoice()

            End If

        End Sub
        Private Sub BarButtonItemClosePrintPreview_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemClosePrintPreview.ItemClick

            Me.Close()

        End Sub
        Private Sub BarButtonItemPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemPrint.ItemClick

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting = Nothing

            If CheckForUnsavedChanges() Then

                If DataGridViewInvoices.HasASelectedRow Then

                    InvoicePrintingPageSetting = New AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting

                    InvoicePrintingPageSetting.SetSettings(DocumentViewer.PrintingSystem)

                    AccountReceivableInvoices = DataGridViewInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                    Try

                        AdvantageFramework.Billing.Reports.Presentation.PrintInvoices(Me, Me.Session, AccountReceivableInvoices, _InvoiceFormatType, _IsDraft, Me.DefaultLookAndFeel.LookAndFeel, InvoicePrintingPageSetting)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

                End If

            End If

        End Sub
        Private Sub BarButtonItemQuickPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemQuickPrint.ItemClick

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting = Nothing

            If CheckForUnsavedChanges() Then

                If DataGridViewInvoices.HasASelectedRow Then

                    AccountReceivableInvoices = DataGridViewInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

                    InvoicePrintingPageSetting = New AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting

                    InvoicePrintingPageSetting.SetSettings(DocumentViewer.PrintingSystem)

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                    Try

                        AdvantageFramework.Billing.Reports.Presentation.QuickPrintInvoices(Me, Me.Session, AccountReceivableInvoices, _InvoiceFormatType, _IsDraft, Me.DefaultLookAndFeel.LookAndFeel, InvoicePrintingPageSetting)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

                End If

            End If

        End Sub
        Private Sub PrintPreviewBarItemEmailAs_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAs.ItemClick

            SendEmails(InvoicePrinting.ToFileOptions.PDF)

        End Sub
        Private Sub PrintPreviewBarItemEmailAsImage_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAsImage.ItemClick

            SendEmails(InvoicePrinting.ToFileOptions.Image)

        End Sub
        Private Sub PrintPreviewBarItemEmailAsPDF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAsPDF.ItemClick

            SendEmails(InvoicePrinting.ToFileOptions.PDF)

        End Sub
        Private Sub PrintPreviewBarItemEmailAsRTF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAsRTF.ItemClick

            SendEmails(InvoicePrinting.ToFileOptions.RTF)

        End Sub
        Private Sub PrintPreviewBarItemEmailAsXLS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAsXLS.ItemClick

            SendEmails(InvoicePrinting.ToFileOptions.XLS)

        End Sub
        Private Sub PrintPreviewBarItemEmailAsXLSX_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAsXLSX.ItemClick

            SendEmails(InvoicePrinting.ToFileOptions.XLSX)

        End Sub
        Private Sub PrintPreviewBarItemExportTo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemExportTo.ItemClick

            ExportTo(InvoicePrinting.ToFileOptions.PDF)

        End Sub
        Private Sub PrintPreviewBarItemExportToImage_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemExportToImage.ItemClick

            ExportTo(InvoicePrinting.ToFileOptions.Image)

        End Sub
        Private Sub PrintPreviewBarItemExportToPDF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemExportToPDF.ItemClick

            ExportTo(InvoicePrinting.ToFileOptions.PDF)

        End Sub
        Private Sub PrintPreviewBarItemExportToRTF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemExportToRTF.ItemClick

            ExportTo(InvoicePrinting.ToFileOptions.RTF)

        End Sub
        Private Sub PrintPreviewBarItemExportToXLS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemExportToXLS.ItemClick

            ExportTo(InvoicePrinting.ToFileOptions.XLS)

        End Sub
        Private Sub PrintPreviewBarItemExportToXLSX_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemExportToXLSX.ItemClick

            ExportTo(InvoicePrinting.ToFileOptions.XLSX)

        End Sub
        Private Sub BarButtonItemQuickEmail_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemQuickEmail.ItemClick

            'objects
            Dim InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting = Nothing

            If DataGridViewInvoices.HasOnlyOneSelectedRow Then

                InvoicePrintingPageSetting = New AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting

                InvoicePrintingPageSetting.SetSettings(DocumentViewer.PrintingSystem)

                CreateInvoiceAndOpenEmailClient(Me, Me.Session, DataGridViewInvoices.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice).ToList, _InvoiceFormatType, _IsDraft, InvoicePrintingPageSetting)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace