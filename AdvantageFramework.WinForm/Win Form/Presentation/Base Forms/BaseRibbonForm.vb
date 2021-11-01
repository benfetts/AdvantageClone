Namespace WinForm.Presentation.BaseForms

    Public Class BaseRibbonForm
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm

        Public Event UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl)
        Public Event ClearChangedEvent()
        Public Event BeforeShowDialog()
        'Public Event BeforeShow()
        Public Event BeforeFormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        Public Event BaseFormParentFormClosedEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)

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
        Private _ShowUnsavedChangesOnFormClosing As Boolean = True
        Private _FormAction As FormActions = FormActions.None
        Private _ByPassUserEntryChanged As Boolean = False
        Private _SuspendedForLoading As Boolean = False
        Private _CloseButtonVisible As Boolean = True
        Private _BaseFormParent As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm = Nothing
        Private _ChildForms As Generic.List(Of System.Windows.Forms.Form) = Nothing
        Private _OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property IsFormModal As Boolean Implements BaseForms.Interfaces.IBaseForm.IsFormModal
            Get
                IsFormModal = Me.Modal
            End Get
        End Property
        Public ReadOnly Property SpellChecker As AdvantageFramework.WinForm.Presentation.Controls.SpellChecker Implements BaseForms.Interfaces.IBaseForm.SpellChecker
            Get
                SpellChecker = _SpellChecker
            End Get
        End Property
        Public ReadOnly Property DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel Implements BaseForms.Interfaces.IBaseForm.DefaultLookAndFeel
            Get
                DefaultLookAndFeel = _DefaultLookAndFeel
            End Get
        End Property
        Public ReadOnly Property IsFormClosing As Boolean Implements BaseForms.Interfaces.IBaseForm.IsFormClosing
            Get
                IsFormClosing = _IsFormClosing
            End Get
        End Property
        Protected Friend ReadOnly Property Session As AdvantageFramework.Security.Session Implements Interfaces.IBaseForm.Session
            Get
                Session = _Session
            End Get
        End Property
        Public ReadOnly Property HasLoaded As Boolean Implements BaseForms.Interfaces.IBaseForm.HasLoaded
            Get
                HasLoaded = _HasLoaded
            End Get
        End Property
        Public ReadOnly Property FormShown As Boolean Implements BaseForms.Interfaces.IBaseForm.FormShown
            Get
                FormShown = _FormShown
            End Get
        End Property
        Public ReadOnly Property UserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.UserEntryChanged
            Get
                UserEntryChanged = _UserEntryChanged
            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)
                _ByPassUserEntryChanged = value
            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Controls.Interfaces.IUserEntryControl.SuspendedForLoading, BaseForms.Interfaces.IBaseForm.SuspendedForLoading
            Set(value As Boolean)
                SetSuspendedForLoading(value)
            End Set
        End Property
        Public Property ShowUnsavedChangesOnFormClosing As Boolean Implements BaseForms.Interfaces.IBaseForm.ShowUnsavedChangesOnFormClosing
            Get
                ShowUnsavedChangesOnFormClosing = _ShowUnsavedChangesOnFormClosing
            End Get
            Set(ByVal value As Boolean)
                _ShowUnsavedChangesOnFormClosing = value
            End Set
        End Property
        Public Property FormAction As FormActions Implements BaseForms.Interfaces.IBaseForm.FormAction
            Get
                FormAction = _FormAction
            End Get
            Set(ByVal value As FormActions)
                _FormAction = value
            End Set
        End Property
        Public Property CloseButtonVisible As Boolean
            Get
                CloseButtonVisible = _CloseButtonVisible
            End Get
            Set(ByVal value As Boolean)
                _CloseButtonVisible = value
            End Set
        End Property
        Public ReadOnly Property SuperValidator As DevComponents.DotNetBar.Validator.SuperValidator Implements BaseForms.Interfaces.IBaseForm.SuperValidator
            Get
                SuperValidator = _SuperValidator
            End Get
        End Property
        Public ReadOnly Property ErrorProvider As System.Windows.Forms.ErrorProvider Implements BaseForms.Interfaces.IBaseForm.ErrorProvider
            Get
                ErrorProvider = _ErrorProvider
            End Get
        End Property
        Public ReadOnly Property Highlighter As DevComponents.DotNetBar.Validator.Highlighter Implements BaseForms.Interfaces.IBaseForm.Highlighter
            Get
                Highlighter = _Highlighter
            End Get
        End Property
        Public Property ShowProgressBar As Boolean
            Get
                ShowProgressBar = ProgressBarItemStatusBar_ProgressBar.Visible
            End Get
            Set(value As Boolean)
                ProgressBarItemStatusBar_ProgressBar.Visible = value
            End Set
        End Property
        Public Property ShowStatusBar As Boolean
            Get
                ShowStatusBar = LabelItemStatusBar_Status.Visible
            End Get
            Set(value As Boolean)
                LabelItemStatusBar_Status.Visible = value
            End Set
        End Property
        Public ReadOnly Property ChildForms As Generic.List(Of System.Windows.Forms.Form)
            Get
                ChildForms = _ChildForms
            End Get
        End Property

#End Region

#Region " Methods "

        Protected Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            SetupValidatorAndHighlighControls()
            SetupSpellCheckerControl()
            Me.DoubleBuffered = True

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

            If RibbonBarFilePanel_System.Items.Count = 1 Then

                RibbonBarFilePanel_System.Visible = _CloseButtonVisible

            Else

                ButtonItemSystem_Close.Visible = _CloseButtonVisible

            End If

            MyBase.OnLoad(e)

        End Sub
        Public Shadows Sub Show()

            If Not Me.IsDisposed Then

                Me.ControlBox = True
                Me.MinimizeBox = True
                Me.MaximizeBox = True
                'Me.WindowState = Windows.Forms.FormWindowState.Maximized
                Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                'Me.MdiParent = LoadParent()

                If _BaseFormParent IsNot Nothing Then

                    _Session = DirectCast(_BaseFormParent, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    EnableBaseFormParent(False)

                End If

                'RaiseEvent BeforeShow()

                MyBase.Show()

            Else

                Me.Close()

            End If

        End Sub
        Public Shadows Function ShowDialog() As Windows.Forms.DialogResult

            If Not Me.IsDisposed Then

                Me.WindowState = Windows.Forms.FormWindowState.Normal
                Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
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
        Protected Sub SetSuspendedForLoading(ByVal SuspendedForLoading As Boolean)

            If Me.FormShown Then

                _SuspendedForLoading = SuspendedForLoading

                AdvantageFramework.WinForm.Presentation.Controls.SetSuspendedForLoading(Me, SuspendedForLoading)

            End If

            _SuspendedForLoading = SuspendedForLoading

        End Sub
        Protected Friend Sub ClearValidations() Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.ClearValidations

            If _SuperValidator IsNot Nothing Then

                _SuperValidator.ClearFailedValidations()

            End If

        End Sub
        Protected Friend Function ValidateControl(ByVal Control As System.Windows.Forms.Control) As Boolean Implements BaseForms.Interfaces.IBaseForm.ValidateControl

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
        Public Sub ClearChanged() Implements Controls.Interfaces.IUserEntryControl.ClearChanged

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

                _OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)

            End If

        End Sub
        Protected Sub CloseOverlay()

            If Me.FormShown AndAlso _OverlaySplayScreenHandle IsNot Nothing Then

                DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(_OverlaySplayScreenHandle)

                _OverlaySplayScreenHandle = Nothing

            End If

        End Sub
        Protected Overrides Sub OnSizeChanged(e As EventArgs)

            If Me.IsHandleCreated AndAlso Me.IsDisposed = False Then

                Me.BeginInvoke(Sub()

                                   MyBase.OnSizeChanged(e)

                               End Sub)

            End If

        End Sub
        Public Sub AddChild(ByVal ChildForm As System.Windows.Forms.Form)

            If _ChildForms Is Nothing Then

                _ChildForms = New List(Of Windows.Forms.Form)

            End If

            _ChildForms.Add(ChildForm)

        End Sub
        Public Sub SetBaseFormParent(ByVal IBaseFormParent As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm, ByVal ChildForm As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm)

            _BaseFormParent = IBaseFormParent

            If TypeOf IBaseFormParent Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                DirectCast(IBaseFormParent, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).AddChild(ChildForm)

            ElseIf TypeOf IBaseFormParent Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm Then

                DirectCast(IBaseFormParent, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).AddChild(ChildForm)

            End If

        End Sub
        Public Sub OpenModuleOnBaseFormParent(ByVal [Module] As AdvantageFramework.Security.Modules)

            Dim MdiParent As System.Windows.Forms.Form = Nothing
            Dim BaseForm As System.Windows.Forms.Form = Nothing

            BaseForm = DirectCast(_BaseFormParent, System.Windows.Forms.Form)

            If BaseForm.MdiParent IsNot Nothing Then

                If TypeOf BaseForm.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                    With DirectCast(BaseForm.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm)

                        .OpenModule([Module])
                        .BringToFront()

                        For Each MdiChild In .MdiChildren

                            Try

                                RemoveHandler MdiChild.FormClosed, AddressOf BaseFormParentFormClosed
                                AddHandler MdiChild.FormClosed, AddressOf BaseFormParentFormClosed

                            Catch ex As Exception

                            End Try

                        Next

                    End With

                End If

            End If

        End Sub
        Private Sub EnableBaseFormParent(ByVal Enable As Boolean)

            Dim MdiParent As System.Windows.Forms.Form = Nothing
            Dim BaseForm As System.Windows.Forms.Form = Nothing

            BaseForm = DirectCast(_BaseFormParent, System.Windows.Forms.Form)

            For Each Control In BaseForm.Controls.OfType(Of DevComponents.DotNetBar.RibbonBarMergeContainer)()

                MdiParent = BaseForm.MdiParent

                If MdiParent IsNot Nothing Then

                    For Each MdiRibbonControl In MdiParent.Controls.OfType(Of DevComponents.DotNetBar.RibbonControl)()

                        For Each RibbonTabItem In MdiRibbonControl.Items.OfType(Of DevComponents.DotNetBar.RibbonTabItem)()

                            If RibbonTabItem.Name = BaseForm.Name & "." & Control.Name Then

                                RibbonTabItem.Panel.Enabled = Enable

                            End If

                        Next

                    Next

                End If

            Next

            BaseForm.Enabled = Enable

            If MdiParent Is Nothing Then

                BaseForm.Visible = Enable

            Else

                For Each TabStrip In MdiParent.Controls.OfType(Of DevComponents.DotNetBar.TabStrip)()

                    For TabCounter As Integer = 0 To TabStrip.Tabs.Count - 1

                        If TabStrip.Tabs(TabCounter).AttachedControl IsNot Nothing Then

                            If TabStrip.Tabs(TabCounter).AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm) Then

                                If BaseForm.Name = TabStrip.Tabs(TabCounter).AttachedControl.Name Then

                                    TabStrip.SelectedTab = TabStrip.Tabs(TabCounter)
                                    Exit For

                                End If

                            End If

                        End If

                    Next

                Next

            End If

        End Sub
        Public Sub ActivateEnabledChildForm()

            Dim Form As System.Windows.Forms.Form = Nothing
            Dim ChildFormActivated As Boolean = False

            If _ChildForms IsNot Nothing Then

                Form = _ChildForms.Where(Function(C) C.Enabled = True).FirstOrDefault

                If Form IsNot Nothing Then

                    If Form.WindowState = Windows.Forms.FormWindowState.Minimized Then

                        Form.WindowState = Windows.Forms.FormWindowState.Normal

                    End If

                    Form.Activate()

                Else

                    For Each Form In _ChildForms

                        If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                            For Each CF In DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ChildForms

                                If CF.Enabled Then

                                    If CF.WindowState = Windows.Forms.FormWindowState.Minimized Then

                                        CF.WindowState = Windows.Forms.FormWindowState.Normal

                                    End If

                                    CF.Activate()
                                    ChildFormActivated = True
                                    Exit For

                                End If

                            Next

                        ElseIf TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm Then

                            For Each CF In DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).ChildForms

                                If CF.Enabled Then

                                    If CF.WindowState = Windows.Forms.FormWindowState.Minimized Then

                                        CF.WindowState = Windows.Forms.FormWindowState.Normal

                                    End If

                                    CF.Activate()
                                    ChildFormActivated = True
                                    Exit For

                                End If

                            Next

                        End If

                        If ChildFormActivated Then

                            Exit For

                        End If

                    Next

                End If

            End If

        End Sub
        Public Sub SetFormActionAndShowWaitForm(ByVal FormAction As WinForm.Presentation.FormActions, Optional ByVal Message As String = Nothing) Implements AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm.SetFormActionAndShowWaitForm

            Me.FormAction = FormAction

            If FormAction = FormActions.None Then

                Me.CloseWaitForm()

            Else

                Me.ShowWaitForm(Message)

            End If

        End Sub
        Private Sub BaseFormParentFormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)

            RaiseEvent BaseFormParentFormClosedEvent(sender, e)

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub BaseRibbonForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            _IsFormClosing = True

            If _ChildForms IsNot Nothing Then

                While _ChildForms.Count > 0

                    _ChildForms(0).Close()
                    _ChildForms.RemoveAt(0)

                End While

                _ChildForms = Nothing

            End If

            If _BaseFormParent IsNot Nothing Then

                EnableBaseFormParent(True)

                If TypeOf _BaseFormParent Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                    DirectCast(_BaseFormParent, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ChildForms.Remove(Me)

                ElseIf TypeOf _BaseFormParent Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm Then

                    DirectCast(_BaseFormParent, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).ChildForms.Remove(Me)

                End If

            End If

            Me.Dispose()

        End Sub
        Private Sub BaseRibbonForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            'objects
            Dim ComboBoxList As Generic.List(Of AdvantageFramework.WinForm.Presentation.Controls.ComboBox) = Nothing
            Dim BindingSource As Windows.Forms.BindingSource = Nothing

            If Me.Enabled AndAlso (Me.ChildForms Is Nothing OrElse Me.ChildForms.Count = 0) AndAlso _ShowUnsavedChangesOnFormClosing AndAlso e.CloseReason = Windows.Forms.CloseReason.UserClosing AndAlso Me.DialogResult <> Windows.Forms.DialogResult.OK Then

                If Me.CheckUserEntryChangedSetting Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to exit without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                        e.Cancel = True

                    End If

                End If

            ElseIf Not Me.Enabled AndAlso Me.ChildForms IsNot Nothing AndAlso Me.ChildForms.Count > 0 Then

                e.Cancel = True

                ActivateEnabledChildForm()

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

                If _BaseFormParent IsNot Nothing Then

                    DirectCast(_BaseFormParent, Windows.Forms.Form).Activate()

                End If

            End If

        End Sub
        Private Sub BaseRibbonForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Try

                Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName)

            Catch ex As Exception

                Me.Icon = AdvantageFramework.My.Resources.AdvantageIcon

            End Try

            ButtonItemSystem_Close.Image = AdvantageFramework.My.Resources.ExitImage

            If _BaseFormParent IsNot Nothing Then

                _ChildForms = New Generic.List(Of System.Windows.Forms.Form)

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _HasLoaded = True

            Me.ClearChanged()

        End Sub
        Private Sub BaseRibbonForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            _FormShown = True

            Me.ClearChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
