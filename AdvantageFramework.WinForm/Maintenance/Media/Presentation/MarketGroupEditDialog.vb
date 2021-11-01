Namespace Maintenance.Media.Presentation

    Public Class MarketGroupEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _MarketGroupID As Integer = 0
        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupEditViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.MarketGroupEditController = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property MarketGroupID As Integer
            Get
                MarketGroupID = _MarketGroupID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef MarketGroupID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MarketGroupID = MarketGroupID

        End Sub
        Private Sub LoadViewModel()

            ComboBoxForm_MediaType.SelectedValue = _ViewModel.MarketGroup.MediaType
            ComboBoxForm_Country.SelectedValue = _ViewModel.MarketGroup.CountryID
            TextBoxForm_Name.Text = _ViewModel.MarketGroup.Name

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.MarketGroup.MediaType = ComboBoxForm_MediaType.GetSelectedValue
            _ViewModel.MarketGroup.CountryID = ComboBoxForm_Country.GetSelectedValue
            _ViewModel.MarketGroup.Name = TextBoxForm_Name.Text

        End Sub
        Private Sub RefreshViewModel()

            ButtonForm_Add.Visible = _ViewModel.AddEnabled
            ButtonForm_Update.Visible = _ViewModel.UpdateEnabled
            ButtonForm_Cancel.Enabled = _ViewModel.CancelEnabled

            ComboBoxForm_Country.Enabled = _ViewModel.AddEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            ComboBoxForm_MediaType.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup.Properties.MediaType)
            ComboBoxForm_MediaType.DisplayMember = "Display"
            ComboBoxForm_MediaType.ValueMember = "Value"

            ComboBoxForm_Country.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup.Properties.CountryID)
            ComboBoxForm_Country.DisplayName = "Country"
            ComboBoxForm_Country.DisplayMember = "Name"
            ComboBoxForm_Country.ValueMember = "ID"

            TextBoxForm_Name.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup.Properties.Name)

        End Sub
        Private Sub SetControlDataSources()

            ComboBoxForm_MediaType.DataSource = _ViewModel.MediaTypes.ToList
            ComboBoxForm_Country.DataSource = _ViewModel.Countries.ToList

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MarketGroupID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MarketGroupEditDialog As AdvantageFramework.Maintenance.Media.Presentation.MarketGroupEditDialog = Nothing

            MarketGroupEditDialog = New AdvantageFramework.Maintenance.Media.Presentation.MarketGroupEditDialog(MarketGroupID)

            ShowFormDialog = MarketGroupEditDialog.ShowDialog()

            MarketGroupID = MarketGroupEditDialog.MarketGroupID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MarketGroupEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.MarketGroupEditController(Me.Session)

            _ViewModel = _Controller.Load(_MarketGroupID)

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

                    _MarketGroupID = _ViewModel.MarketGroup.ID

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