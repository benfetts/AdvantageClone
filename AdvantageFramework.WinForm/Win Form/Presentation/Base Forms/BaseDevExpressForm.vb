Namespace WinForm.Presentation.BaseForms

    Public Class BaseDevExpressForm
        Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

        Public Event UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl)
        Public Event ClearChangedEvent()
        Public Event BeforeShowDialog()
        Public Event BeforeShow()
        Public Event BeforeFormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)

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
        Private _OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing

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

        Protected Sub New()
            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            SetupValidatorAndHighlighControls()
            SetupSpellCheckerControl()
            Me.DoubleBuffered = True

        End Sub
        Protected Sub SetSuspendedForLoading(ByVal SuspendedForLoading As Boolean)

            If Me.FormShown Then

                _SuspendedForLoading = SuspendedForLoading

                AdvantageFramework.WinForm.Presentation.Controls.SetSuspendedForLoading(Me, SuspendedForLoading)

            End If

            _SuspendedForLoading = SuspendedForLoading

        End Sub
        Public Sub BaseFormUserEntryChanged(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl)

            If Me.FormShown AndAlso _UserEntryChanged = False AndAlso _ByPassUserEntryChanged = False Then

                _UserEntryChanged = Control.UserEntryChanged

                If Control.UserEntryChanged AndAlso Me.FormAction = FormActions.None Then

                    RaiseEvent UserEntryChangedEvent(Control)

                End If

            End If

        End Sub
        Public Sub RaiseUserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl)

            RaiseEvent UserEntryChangedEvent(Control)

        End Sub
        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

            AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettings(Me)

            MyBase.OnLoad(e)

        End Sub
        Public Shadows Sub Show()

            If Not Me.IsDisposed Then

                Me.ControlBox = False
                Me.MinimizeBox = False
                Me.MaximizeBox = False
                Me.WindowState = Windows.Forms.FormWindowState.Maximized
                Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                Me.MdiParent = LoadParent()

                RaiseEvent BeforeShow()

                MyBase.Show()

            Else

                Me.Close()

            End If

        End Sub
        Public Shadows Function ShowDialog() As Windows.Forms.DialogResult

            If Not Me.IsDisposed Then

                Me.ControlBox = True
                Me.MinimizeBox = False
                Me.MaximizeBox = True
                Me.WindowState = Windows.Forms.FormWindowState.Normal
                Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                Me.ShowInTaskbar = False

                Me.Owner = Me.LoadParent

                RaiseEvent BeforeShowDialog()

                ShowDialog = MyBase.ShowDialog()

            Else

                ShowDialog = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Function
        Private Function LoadParent() As System.Windows.Forms.Form

            'objects
            Dim FormParent As System.Windows.Forms.Form = Nothing
            Dim FormOpenForm As System.Windows.Forms.Form = Nothing

            For Each FormOpenForm In System.Windows.Forms.Application.OpenForms

                If FormOpenForm.TopLevel Then

                    FormParent = FormOpenForm
                    Exit For

                End If

            Next

            If FormParent IsNot Nothing Then

                If TypeOf FormParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                    _Session = DirectCast(FormParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).Session

                End If

            End If

            LoadParent = FormParent

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
            Dim SpellCheckerCustomDictionary As DevExpress.XtraSpellChecker.SpellCheckerCustomDictionary = Nothing
            Dim FileStream As System.IO.FileStream = Nothing

            Me.SuspendLayout()

            _SpellChecker = New AdvantageFramework.WinForm.Presentation.Controls.SpellChecker

            _SpellChecker.ParentContainer = Me

            SpellCheckerISpellDictionary = New DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary

            SpellCheckerISpellDictionary.DictionaryPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\AmericanXLG.xlg"
            SpellCheckerISpellDictionary.AlphabetPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\EnglishAlphabet.txt"
            SpellCheckerISpellDictionary.GrammarPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\EnglishAFF.aff"

            SpellCheckerISpellDictionary.Culture = My.Application.Culture

            SpellCheckerISpellDictionary.Load()

            _SpellChecker.Dictionaries.Add(SpellCheckerISpellDictionary)

            Try

                If My.Computer.FileSystem.FileExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\CustomEnglish.dic") = False Then

                    FileStream = System.IO.File.Create(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\CustomEnglish.dic")

                    FileStream.Close()
                    FileStream.Dispose()

                    FileStream = Nothing

                End If

            Catch ex As Exception

            End Try

            If My.Computer.FileSystem.FileExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\CustomEnglish.dic") Then

                SpellCheckerCustomDictionary = New DevExpress.XtraSpellChecker.SpellCheckerCustomDictionary

                SpellCheckerCustomDictionary.AlphabetPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\EnglishAlphabet.txt"
                SpellCheckerCustomDictionary.DictionaryPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Resources\CustomEnglish.dic"

                SpellCheckerCustomDictionary.Culture = My.Application.Culture

                SpellCheckerCustomDictionary.Load()

                _SpellChecker.Dictionaries.Add(SpellCheckerCustomDictionary)

            End If

            Me.ResumeLayout(True)

        End Sub
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
        Protected Friend Function Validator() As Boolean

            'objects
            Dim IsValid As Boolean = True

            If _SuperValidator IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.CloseEditorsOnDataGridViews(Me)

                Me.Validate()

                IsValid = _SuperValidator.Validate()

            End If

            Validator = IsValid

        End Function
        Public Function CheckUserEntryChangedSetting() As Boolean

            'objects
            Dim UserEntryChanged As Boolean = False

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me)

            End If

            _UserEntryChanged = UserEntryChanged

            CheckUserEntryChangedSetting = UserEntryChanged

        End Function
        Public Sub ClearChanged() Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ClearChanged

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _UserEntryChanged = False

            ClearValidations()

            If Me.FormShown Then

                RaiseEvent ClearChangedEvent()

            End If

        End Sub
        Public Sub RaiseClearChanged()

            RaiseEvent ClearChangedEvent()

        End Sub
        Protected Sub SetSession(ByVal Session As AdvantageFramework.Security.Session)

            _Session = Session

        End Sub
        Protected Sub ShowWaitForm(Optional ByVal DisplayText As String = Nothing)

            If Me.FormShown Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm(DisplayText)

            End If

        End Sub
        Protected Sub CloseWaitForm()

            AdvantageFramework.WinForm.Presentation.CloseWaitForm()

        End Sub
        Protected Sub ShowOverlay()

            If Me.FormShown Then

                If Me.IsMdiChild Then

                    _OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me.MdiParent, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)

                Else

                    _OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)

                End If

            End If

        End Sub
        Protected Sub CloseOverlay()

            If Me.FormShown AndAlso _OverlaySplayScreenHandle IsNot Nothing Then

                DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(_OverlaySplayScreenHandle)

                _OverlaySplayScreenHandle = Nothing

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

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub BaseDevExpressForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            'objects
            Dim ComboBoxList As Generic.List(Of AdvantageFramework.WinForm.Presentation.Controls.ComboBox) = Nothing
            Dim BindingSource As Windows.Forms.BindingSource = Nothing

            If Me.Enabled AndAlso _ShowUnsavedChangesOnFormClosing AndAlso e.CloseReason = Windows.Forms.CloseReason.UserClosing AndAlso Me.DialogResult <> Windows.Forms.DialogResult.OK Then

                If Me.CheckUserEntryChangedSetting Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to exit without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                        e.Cancel = True

                    End If

                End If

            End If

            If e.Cancel = False AndAlso e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                RaiseEvent BeforeFormClosing(sender, e)

                ComboBoxList = GetComboBoxControls(Me.Controls)

                While ComboBoxList.Count > 0

                    If ComboBoxList(0).DataSource IsNot Nothing Then

                        BindingSource = ComboBoxList(0).DataSource

                        If BindingSource IsNot Nothing Then

                            BindingSource.Dispose()

                        End If

                    End If

                    ComboBoxList.RemoveAt(0)

                End While

                If Me.MdiParent IsNot Nothing Then

                    For Each MdiRibbonControl In Me.MdiParent.Controls.OfType(Of DevComponents.DotNetBar.RibbonControl)()

                        For Each RibbonBarMergeContainer In Me.Controls.OfType(Of DevComponents.DotNetBar.RibbonBarMergeContainer)()

                            RibbonBarMergeContainer.RemoveMergedRibbonBars(MdiRibbonControl)

                        Next

                        MdiRibbonControl.SelectFirstVisibleRibbonTab()

                    Next

                End If

            End If

        End Sub
        Private Sub BaseDevExpressForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Try

                Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName)

            Catch ex As Exception

                Me.Icon = AdvantageFramework.My.Resources.AdvantageIcon

            End Try

            _HasLoaded = True

            Me.ClearChanged()

        End Sub
        Private Sub BaseDevExpressForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            _FormShown = True

            Me.ClearChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "


#End Region

#End Region

    End Class

End Namespace
