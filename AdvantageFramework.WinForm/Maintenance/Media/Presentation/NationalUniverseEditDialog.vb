Namespace Maintenance.Media.Presentation

    Public Class NationalUniverseEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _NationalUniverseID As Integer = 0
        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseEditViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.NationalUniverseEditController = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property NationalUniverseID As Integer
            Get
                NationalUniverseID = _NationalUniverseID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef NationalUniverseID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _NationalUniverseID = NationalUniverseID

        End Sub
        Private Sub LoadViewModel()

            NumericInputForm_Year.EditValue = _ViewModel.NationalUniverse.Year
            SearchableComboBoxForm_MarketBreak.SelectedValue = _ViewModel.NationalUniverse.MarketBreakID

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.NationalUniverse.Year = NumericInputForm_Year.GetValue
            _ViewModel.NationalUniverse.MarketBreakID = SearchableComboBoxForm_MarketBreak.GetSelectedValue
            _ViewModel.NationalUniverse.IsHispanic = CheckBoxForm_IsHispanic.Checked

        End Sub
        Private Sub RefreshViewModel()

            ButtonForm_Add.Visible = _ViewModel.AddEnabled
            ButtonForm_Update.Visible = _ViewModel.UpdateEnabled
            ButtonForm_Cancel.Enabled = _ViewModel.CancelEnabled

            NumericInputForm_Year.Enabled = _ViewModel.AddEnabled
            SearchableComboBoxForm_MarketBreak.Enabled = _ViewModel.AddEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            NumericInputForm_Year.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Year)
            NumericInputForm_Year.Properties.MaxValue = 2100
            NumericInputForm_Year.Properties.MinValue = 2000

            SearchableComboBoxForm_MarketBreak.SetRequired(True)

        End Sub
        Private Sub SetControlDataSources()

            SearchableComboBoxForm_MarketBreak.DataSource = _ViewModel.MarketBreaks.ToList

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef NationalUniverseID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim NationalUniverseEditDialog As AdvantageFramework.Maintenance.Media.Presentation.NationalUniverseEditDialog = Nothing

            NationalUniverseEditDialog = New AdvantageFramework.Maintenance.Media.Presentation.NationalUniverseEditDialog(NationalUniverseID)

            ShowFormDialog = NationalUniverseEditDialog.ShowDialog()

            NationalUniverseID = NationalUniverseEditDialog.NationalUniverseID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub NationalUniverseEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.NationalUniverseEditController(Me.Session)

            _ViewModel = _Controller.Load(_NationalUniverseID)

            SetControlDataSources()

            LoadViewModel()

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                SaveViewModel()

                If _Controller.Add(_ViewModel, ErrorMessage) Then

                    _NationalUniverseID = _ViewModel.NationalUniverse.ID

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                SaveViewModel()

                If _Controller.Update(_ViewModel, ErrorMessage) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace