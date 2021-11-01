Imports AdvantageFramework.WinForm.Presentation
Imports AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces
Imports DevExpress.XtraBars

Namespace ProjectManagement.Reports.Presentation

    Public Class EstimateViewingForm2
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
        Private _EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
        Private _EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
        Private _EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
        Private _EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
        Private _EstimateSetting As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
        Private _UserDefinedReportID As Integer = 0
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage
        Private _EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes
        Private _DateToPrint As DateTime = Nothing
        Private _MultiSelect As Boolean = False
        Private _IsASP As Boolean = False

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

        Private Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, ByVal EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote),
                        ByVal EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting), ByVal EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting,
                        ByVal UserDefinedReportID As Integer, ByVal EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats, ByVal DateToPrint As DateTime)

            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Session = Session
            _EstimateFormatType = EstimateFormatType
            _EstimateQuotes = EstimateQuotes
            _EstimatePrintingSettings = EstimatePrintingSettings
            _EstimatePrintingSetting = EstimatePrintingSetting
            _UserDefinedReportID = UserDefinedReportID
            _EstimateFormat = EstimateFormat
            _DateToPrint = DateToPrint
            SetupValidatorAndHighlighControls()
            SetupSpellCheckerControl()
            Me.DoubleBuffered = True

        End Sub
        Private Function LoadEstimates(Optional ByVal ClientCode As String = Nothing) As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)

            LoadEstimates = _EstimateQuotes

            If String.IsNullOrWhiteSpace(ClientCode) Then

                LoadEstimates = _EstimateQuotes.OrderBy(Function(Entity) Entity.ClientCode).ThenByDescending(Function(Entity) Entity.EstimateNumber).ToList

            Else

                LoadEstimates = _EstimateQuotes.Where(Function(Entity) Entity.ClientCode = ClientCode).OrderBy(Function(Entity) Entity.ClientCode).ThenByDescending(Function(Entity) Entity.EstimateNumber).ToList

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

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            If DataGridViewEstimates.HasASelectedRow Then

                Dim quotes As String = ""
                Dim qtedesc As String = ""
                Dim qtedescs As String = ""
                Dim comps As String = ""
                Dim qte As Integer = 0
                Dim comp As Integer = 0
                Dim count As Integer = 0
                Dim est As Integer = 0
                Dim estcomp As String = ""

                Dim estCount As Integer = 0

                EstimateQuotes = DataGridViewEstimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                For Each EstimateQuote In EstimateQuotes

                    If _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                        _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                        If _EstimatePrintingSetting Is Nothing Then
                            _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                        End If
                        If _EstimatePrintingSetting Is Nothing Then
                            _EstimatePrintingSetting = _EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                        End If
                    ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                        _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                    Else
                        _EstimatePrintingSetting = _EstimatePrintingSettings.FirstOrDefault
                    End If

                    If _EstimatePrintingSetting IsNot Nothing Then
                        If _EstimatePrintingSetting.SummaryLevel = 2 Then
                            If (est <> 0 And est <> EstimateQuote.EstimateNumber) Then
                                If _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                    _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                    If _EstimatePrintingSetting Is Nothing Then
                                        _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                    End If
                                    If _EstimatePrintingSetting Is Nothing Then
                                        _EstimatePrintingSetting = _EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                    End If
                                ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                    _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                Else
                                    _EstimatePrintingSetting = _EstimatePrintingSettings.FirstOrDefault
                                End If

                                If count > 4 And _EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                    AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If

                                _EstimateQuote = EstimateQuotes(estCount - 1)

                                CreateInvoice(comps, quotes, qtedescs, _EstimatePrintingSetting.SummaryLevel)

                                quotes = ""
                                qtedescs = ""
                                count = 0
                            End If
                        Else
                            If (estcomp <> "" And estcomp <> EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber) Then
                                If _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                    _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                    If _EstimatePrintingSetting Is Nothing Then
                                        _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                    End If
                                    If _EstimatePrintingSetting Is Nothing Then
                                        _EstimatePrintingSetting = _EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                    End If
                                ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                    _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                Else
                                    _EstimatePrintingSetting = _EstimatePrintingSettings.FirstOrDefault
                                End If

                                If count > 4 And _EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                    AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If

                                _EstimateQuote = EstimateQuotes(estCount - 1)

                                CreateInvoice(comps, quotes, qtedescs, _EstimatePrintingSetting.SummaryLevel)

                                quotes = ""
                                qtedescs = ""
                                count = 0
                            End If
                        End If

                        Try
                            est = EstimateQuote.EstimateNumber
                            comp = EstimateQuote.EstimateComponentNumber
                            estcomp = EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber
                            qte = EstimateQuote.QuoteNumber
                            If EstimateQuote.QuoteDesc IsNot Nothing Then
                                qtedesc = EstimateQuote.QuoteDesc.Replace("&nbsp;", "").Replace(",", "_")
                            End If
                        Catch ex As Exception
                            qte = 0
                            qtedesc = ""
                        End Try
                        quotes &= qte & ","
                        qtedescs &= qtedesc & ","
                        comps &= comp & ","
                        count += 1
                        estCount += 1

                        If estCount = EstimateQuotes.Count Then

                            If _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                If _EstimatePrintingSetting Is Nothing Then
                                    _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                End If
                                If _EstimatePrintingSetting Is Nothing Then
                                    _EstimatePrintingSetting = _EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                End If
                            ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                            Else
                                _EstimatePrintingSetting = _EstimatePrintingSettings.FirstOrDefault
                            End If

                            If count > 4 And _EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                Exit Sub
                            End If

                            _EstimateQuote = EstimateQuote

                            CreateInvoice(comps, quotes, qtedescs, _EstimatePrintingSetting.SummaryLevel)

                        End If
                    Else

                        _EstimateQuote = DataGridViewEstimates.GetFirstSelectedRowDataBoundItem

                        CreateInvoice()

                    End If

                Next

                BarButtonItemPrintOptionsSetup.Enabled = True

            End If


        End Sub

        Private Sub CreateInvoice(Optional ByVal Comps As String = "", Optional ByVal Quotes As String = "", Optional ByVal QuoteDescriptions As String = "", Optional ByVal Combine As Integer = 0)

            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
            Dim EstimatePrintingDefault As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Try
                If _EstimatePrintingSetting Is Nothing Then

                    EstimatePrintingDefault = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting()

                    Report = AdvantageFramework.Reporting.Reports.CreateEstimate(_Session, _EstimateQuote, EstimatePrintingDefault, _EstimateFormat, _EstimateQuote.EstimateComponentNumber.ToString & ",", _EstimateQuote.QuoteNumber.ToString & ",")

                Else

                    'Report = AdvantageFramework.Reporting.Reports.CreateEstimate(_Session, _EstimateQuote, _EstimatePrintingSetting, _EstimateFormat, _EstimateQuote.EstimateComponentNumber.ToString & ",", _EstimateQuote.QuoteNumber.ToString & ",")
                    Report = AdvantageFramework.Reporting.Reports.CreateEstimate(_Session, _EstimateQuote, _EstimatePrintingSetting, _EstimateFormat, Comps, Quotes, QuoteDescriptions, Combine, _DateToPrint)

                End If

                If Report IsNot Nothing Then

                    DocumentViewer.PrintingSystem = Report.PrintingSystem

                    Report.CreateDocument(True)

                End If
            Catch ex As Exception

            End Try
        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If DataGridViewEstimates.UserEntryChanged AndAlso BarButtonItemActionsSave.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    DataGridViewEstimates.CurrentView.CloseEditorForUpdating()

                    IsOkay = DataGridViewEstimates.Validate

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

                        DataGridViewEstimates.ClearChanged()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            If DataGridViewEstimates.HasRows Then

                Saved = True

                DataGridViewEstimates.CurrentView.CloseEditorForUpdating()

                AccountReceivableInvoices = DataGridViewEstimates.GetAllModifiedRows.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

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

                        DataGridViewEstimates.ValidateAllRowsAndClearChanged(True)

                    Catch ex As Exception

                    End Try

                End If

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

            Save = Saved

        End Function
        Private Sub EnableOrDisableActions()

            BarButtonItemPrintOptionsSetup.Enabled = DataGridViewEstimates.HasASelectedRow
            BarButtonItemCommentsJob.Enabled = DataGridViewEstimates.HasASelectedRow
            BarButtonItemCommentsFunction.Enabled = DataGridViewEstimates.HasASelectedRow
            BarButtonItemPrint.Enabled = DataGridViewEstimates.HasASelectedRow
            BarButtonItemQuickPrint.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemExportTo.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemExportToImage.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemExportToPDF.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemExportToRTF.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemExportToXLS.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemExportToXLSX.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemEmailAs.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemEmailAsImage.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemEmailAsPDF.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemEmailAsRTF.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemEmailAsXLS.Enabled = DataGridViewEstimates.HasASelectedRow
            PrintPreviewBarItemEmailAsXLSX.Enabled = DataGridViewEstimates.HasASelectedRow

            BarButtonItemQuickEmail.Enabled = (DataGridViewEstimates.HasOnlyOneSelectedRow = True AndAlso _IsASP = False)

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
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            If CheckForUnsavedChanges() Then

                If DataGridViewEstimates.HasASelectedRow Then

                    EstimateQuotes = DataGridViewEstimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                    Try

                        AdvantageFramework.ProjectManagement.Reports.Presentation.SendEstimateEmails(Me, Me.Session, EstimateQuotes, _EstimateFormatType, ToFileOption)

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
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            If CheckForUnsavedChanges() Then

                If DataGridViewEstimates.HasASelectedRow Then

                    EstimateQuotes = DataGridViewEstimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                    Try

                        AdvantageFramework.ProjectManagement.Reports.Presentation.PrintToFile(Me, Me.Session, EstimateQuotes, _EstimateFormatType, False, ToFileOption)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Session As AdvantageFramework.Security.Session, ByVal EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, ByVal EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote),
                                              ByVal EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting), ByVal EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting,
                                              ByVal UserDefinedReportID As Integer, ByVal EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats, ByVal DateToPrint As DateTime) As Windows.Forms.DialogResult

            'objects
            Dim EstimateViewingForm2 As EstimateViewingForm2 = Nothing

            EstimateViewingForm2 = New EstimateViewingForm2(Session, EstimateFormatType, EstimateQuotes, EstimatePrintingSettings, EstimatePrintingSetting, UserDefinedReportID, EstimateFormat, DateToPrint)

            ShowFormDialog = EstimateViewingForm2.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EstimateViewingForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Clients As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing

            BarButtonItemActionsSave.LargeGlyph = AdvantageFramework.My.Resources.SaveImage
            BarButtonItemPrintOptionsSetup.LargeGlyph = AdvantageFramework.My.Resources.InvoicePropertiesImage
            BarButtonItemCommentsJob.Glyph = AdvantageFramework.My.Resources.InvoicePropertiesImage
            BarButtonItemCommentsFunction.Glyph = AdvantageFramework.My.Resources.InvoicePropertiesImage

            Me.WindowState = Windows.Forms.FormWindowState.Maximized

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _IsASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            DataGridViewEstimates.DataSource = LoadEstimates()

            'DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DueDate.ToString)
            'DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceComment.ToString)
            'DataGridViewInvoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceCategoryCode.ToString)

            DataGridViewEstimates.CurrentView.BestFitColumns()

            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComment.ToString).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComponentComment.ToString).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateQuoteComment.ToString).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True

            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobNumber.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobDesc.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobComponentNumber.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobCompDesc.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.JobComponent.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.CampaignName.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.CampaignCode.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.Estimate.ToString).OptionsColumn.TabStop = False
            'DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateDate.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateNumber.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstDesc.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateComponentNumber.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstCompDesc.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.QuoteNumber.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.QuoteDesc.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.ClientCode.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.ClientName.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.DivisionCode.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.DivisionName.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.ProductCode.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.ProductName.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.OfficeCode.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.OfficeName.ToString).OptionsColumn.TabStop = False
            DataGridViewEstimates.CurrentView.Columns(AdvantageFramework.Estimate.Printing.Classes.EstimateQuote.Properties.EstimateContactName.ToString).OptionsColumn.TabStop = False

            Dim EstNum As Integer = 0
            Dim EstCompNum As Integer = 0
            Dim quoteCount As Integer = 1
            If _EstimateQuotes.Count > 1 Then
                For Each EstimateQuote In _EstimateQuotes
                    If EstNum = 0 And EstCompNum = 0 Then
                        EstNum = EstimateQuote.EstimateNumber
                        EstCompNum = EstimateQuote.EstimateComponentNumber
                    ElseIf EstNum = EstimateQuote.EstimateNumber And EstCompNum = EstimateQuote.EstimateComponentNumber Then
                        _MultiSelect = True
                        quoteCount += 1
                    Else
                        _MultiSelect = False
                    End If
                Next
            End If

            _EstimateQuote = _EstimateQuotes.FirstOrDefault
            If _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = _EstimateQuote.CDP AndAlso Entity.Type = 3)
                If _EstimatePrintingSetting Is Nothing Then
                    _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = _EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                End If
                If _EstimatePrintingSetting Is Nothing Then
                    _EstimatePrintingSetting = _EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = _EstimateQuote.ClientCode)
                End If
            ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                _EstimatePrintingSetting = _EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
            Else
                _EstimatePrintingSetting = _EstimatePrintingSettings.FirstOrDefault
            End If

            If _MultiSelect = True And _EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                If quoteCount < 5 Then
                    DataGridViewEstimates.SelectAll()
                Else
                    DataGridViewEstimates.CurrentView.SelectRows(0, 3)
                End If

            End If

            Try

                Clients = (From Entity In _EstimateQuotes
                           Select Entity.ClientCode,
                                  Entity.ClientName).Distinct.ToList.Select(Function(Entity) New AdvantageFramework.Database.Core.Client With {.Code = Entity.ClientCode,
                                                                                                                                                           .Name = Entity.ClientName,
                                                                                                                                                           .IsActive = 1}).OrderBy(Function(Entity) Entity.Code).ToList

            Catch ex As Exception
                Clients = Nothing
            End Try

            ComboBoxClient.DataSource = Clients

            Try

                Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName)

            Catch ex As Exception

                Me.Icon = AdvantageFramework.My.Resources.AdvantageIcon

            End Try

            _HasLoaded = True

            Me.ClearChanged()

        End Sub
        Private Sub EstimateViewingForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

            If DataGridViewEstimates.HasASelectedRow Then

                _EstimateQuote = DataGridViewEstimates.GetFirstSelectedRowDataBoundItem

                ViewInvoice()

            Else

                BarButtonItemPrintOptionsSetup.Enabled = False

            End If

            _FormShown = True

            Me.ClearChanged()

        End Sub
        Private Sub EstimateViewingForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            BarButtonItemActionsSave.Enabled = False

        End Sub
        Private Sub EstimateViewingForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            BarButtonItemActionsSave.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewEstimates_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewEstimates.CellValueChangingEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewEstimates_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewEstimates.LeavingRowEvent

            e.Allow = CheckForUnsavedChanges()

        End Sub
        Private Sub DataGridViewEstimates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEstimates.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ViewInvoice()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub BarButtonItemPrintOptionsSetup_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemPrintOptionsSetup.ItemClick

            'objects
            Dim ClientCodes As Generic.List(Of String) = Nothing
            Dim ShowEstimateOptions As Boolean = False
            Dim ClientLevel As String = ""
            Dim EstimatePrintingDefault As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

            If _EstimateQuote IsNot Nothing Then

                ShowEstimateOptions = True

                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.Type = 2 Then
                        ClientLevel = "Client"
                    End If
                    If _EstimatePrintingSetting.Type = 3 Then
                        ClientLevel = "Product"
                    End If
                Else

                End If

                If EstimatePrintingOptionsDialog.ShowFormDialog(_EstimateFormatType, _EstimatePrintingSetting, New Generic.List(Of String)({_EstimateQuote.ClientCode}), New Generic.List(Of String)({_EstimateQuote.CDP}), ShowEstimateOptions, ClientLevel) = Windows.Forms.DialogResult.OK Then

                    'Dim datePrint As DateTime = _EstimatePrintingSetting.DatePrint
                    'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                    '    ' _EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWV(DbContext, False, Me.Session.UserCode).FirstOrDefault
                    'End Using
                    '_EstimatePrintingSetting.DatePrint = datePrint
                    ViewInvoice()

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
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            If DataGridViewEstimates.HasASelectedRow Then

                Try

                    EstimateQuotes = DataGridViewEstimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                Catch ex As Exception
                    EstimateQuotes = Nothing
                End Try

                If EstimateQuotes IsNot Nothing AndAlso EstimateQuotes.Count > 0 Then

                    EstimatePrintingCommentsDialog.ShowFormDialog(EstimatePrintingCommentsDialog.Type.EstimateComment, EstimateQuotes)

                End If

            End If

        End Sub
        Private Sub BarButtonItemCommentsFunction_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemCommentsFunction.ItemClick

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            If DataGridViewEstimates.HasASelectedRow Then

                Try

                    EstimateQuotes = DataGridViewEstimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                Catch ex As Exception
                    EstimateQuotes = Nothing
                End Try

                If EstimateQuotes IsNot Nothing AndAlso EstimateQuotes.Count > 0 Then

                    EstimatePrintingCommentsDialog.ShowFormDialog(EstimatePrintingCommentsDialog.Type.EstimateFunctionComment, EstimateQuotes)

                End If

            End If

        End Sub
        Private Sub ComboBoxClient_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxClient.SelectedValueChanged

            If Me.FormShown Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                If ComboBoxClient.HasASelectedValue Then

                    DataGridViewEstimates.DataSource = LoadEstimates(ComboBoxClient.GetSelectedValue)

                Else

                    DataGridViewEstimates.DataSource = LoadEstimates()

                End If

                Me.FormAction = WinForm.Presentation.FormActions.None

                DataGridViewEstimates.CurrentView.BestFitColumns()

                ViewInvoice()

            End If

        End Sub
        Private Sub BarButtonItemClosePrintPreview_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemClosePrintPreview.ItemClick

            Me.Close()

        End Sub

        Private Sub BarButtonItemPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemPrint.ItemClick

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            If CheckForUnsavedChanges() Then

                If DataGridViewEstimates.HasASelectedRow Then

                    EstimateQuotes = DataGridViewEstimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                    Try

                        AdvantageFramework.ProjectManagement.Reports.Presentation.PrintEstimates(Me, Me.Session, EstimateQuotes, _EstimateFormatType, Me.DefaultLookAndFeel.LookAndFeel)

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
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            If CheckForUnsavedChanges() Then

                If DataGridViewEstimates.HasASelectedRow Then

                    EstimateQuotes = DataGridViewEstimates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)().ToList

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                    Try

                        AdvantageFramework.ProjectManagement.Reports.Presentation.QuickPrintEstimates(Me, Me.Session, EstimateQuotes, _EstimateFormatType, Me.DefaultLookAndFeel.LookAndFeel)

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

        Private Sub BarButtonItemQuickEmail_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItemQuickEmail.ItemClick
            If DataGridViewEstimates.HasOnlyOneSelectedRow Then

                CreateEstimateAndOpenEmailClient(Me, Me.Session, DataGridViewEstimates.GetAllSelectedRowsDataBoundItems().OfType(Of Estimate.Printing.Classes.EstimateQuote).ToList, _EstimateFormatType, InvoicePrinting.ToFileOptions.PDF)

            End If
        End Sub

#End Region

#End Region

    End Class

End Namespace