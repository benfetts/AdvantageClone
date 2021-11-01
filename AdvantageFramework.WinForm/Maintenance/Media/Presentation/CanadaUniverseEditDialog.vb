Namespace Maintenance.Media.Presentation

    Public Class CanadaUniverseEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _CanadaUniverseID As Integer = 0
        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseEditViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.CanadaUniverseEditController = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property CanadaUniverseID As Integer
            Get
                CanadaUniverseID = _CanadaUniverseID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef CanadaUniverseID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _CanadaUniverseID = CanadaUniverseID

        End Sub
        Private Sub LoadViewModel()

            NumericInputForm_Year.EditValue = _ViewModel.CanadaUniverse.Year
            ComboBoxForm_Market.SelectedValue = _ViewModel.CanadaUniverse.MarketCode
            CheckBoxForm_AddAllMarkets.Checked = _ViewModel.AddAllMarkets

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.CanadaUniverse.Year = NumericInputForm_Year.GetValue
            _ViewModel.CanadaUniverse.MarketCode = ComboBoxForm_Market.GetSelectedValue
            _ViewModel.AddAllMarkets = CheckBoxForm_AddAllMarkets.Checked

        End Sub
        Private Sub RefreshViewModel()

            ButtonForm_Add.Visible = _ViewModel.AddEnabled
            ButtonForm_Update.Visible = _ViewModel.UpdateEnabled
            ButtonForm_Cancel.Enabled = _ViewModel.CancelEnabled

            NumericInputForm_Year.Enabled = _ViewModel.AddEnabled
            ComboBoxForm_Market.Enabled = (_ViewModel.AddEnabled AndAlso _ViewModel.AddAllMarkets = False)
            CheckBoxForm_AddAllMarkets.Enabled = _ViewModel.AddEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            NumericInputForm_Year.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse.Properties.Year)
            NumericInputForm_Year.Properties.MaxValue = 9999
            NumericInputForm_Year.Properties.MinValue = 1900

            ComboBoxForm_Market.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse.Properties.MarketCode)
            ComboBoxForm_Market.DisplayMember = "Description"
            ComboBoxForm_Market.ValueMember = "Code"

        End Sub
        Private Sub SetControlDataSources()

            ComboBoxForm_Market.DataSource = _ViewModel.Markets.ToList

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef CanadaUniverseID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim CanadaUniverseEditDialog As AdvantageFramework.Maintenance.Media.Presentation.CanadaUniverseEditDialog = Nothing

            CanadaUniverseEditDialog = New AdvantageFramework.Maintenance.Media.Presentation.CanadaUniverseEditDialog(CanadaUniverseID)

            ShowFormDialog = CanadaUniverseEditDialog.ShowDialog()

            CanadaUniverseID = CanadaUniverseEditDialog.CanadaUniverseID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CanadaUniverseEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.CanadaUniverseEditController(Me.Session)

            _ViewModel = _Controller.Load(_CanadaUniverseID)

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

                    _CanadaUniverseID = _ViewModel.CanadaUniverse.ID

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
        Private Sub CheckBoxForm_AddAllMarkets_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_AddAllMarkets.CheckedChanged

            If _ViewModel IsNot Nothing Then

                _ViewModel.AddAllMarkets = CheckBoxForm_AddAllMarkets.Checked

                RefreshViewModel()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace