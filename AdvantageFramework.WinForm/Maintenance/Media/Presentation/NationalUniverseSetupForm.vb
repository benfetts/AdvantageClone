Namespace Maintenance.Media.Presentation

    Public Class NationalUniverseSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.NationalUniverseController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            LoadGrid()

            LoadGrid_Details()

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled

            DataGridViewRightSection_NationalUniverseDetails.Enabled = _ViewModel.HasASelectedNationalUniverse

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewLeftSection_NationalUniverses.OptionsBehavior.Editable = False
            DataGridViewLeftSection_NationalUniverses.OptionsSelection.MultiSelect = False

            DataGridViewLeftSection_NationalUniverses.ItemDescription = "Universe(s)"

            DataGridViewRightSection_NationalUniverseDetails.OptionsCustomization.AllowColumnMoving = False
            DataGridViewRightSection_NationalUniverseDetails.OptionsCustomization.AllowFilter = False
            DataGridViewRightSection_NationalUniverseDetails.OptionsCustomization.AllowGroup = False
            DataGridViewRightSection_NationalUniverseDetails.OptionsCustomization.AllowSort = False
            DataGridViewRightSection_NationalUniverseDetails.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewRightSection_NationalUniverseDetails.OptionsMenu.EnableColumnMenu = False

            DataGridViewRightSection_NationalUniverseDetails.ItemDescription = "Segment(s)"

        End Sub
        Private Sub SetControlDataSources()



        End Sub
        Private Sub LoadGrid()

            DataGridViewLeftSection_NationalUniverses.DataSource = _ViewModel.NationalUniverses

        End Sub
        Private Sub FormatGrid()

            DataGridViewLeftSection_NationalUniverses.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadGrid_Details()

            DataGridViewRightSection_NationalUniverseDetails.DataSource = _ViewModel.SelectedNationalUniverseDetails

        End Sub
        Private Sub FormatGrid_Details()

            DataGridViewRightSection_NationalUniverseDetails.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim NationalUniverseSetupForm As AdvantageFramework.Maintenance.Media.Presentation.NationalUniverseSetupForm = Nothing

            NationalUniverseSetupForm = New AdvantageFramework.Maintenance.Media.Presentation.NationalUniverseSetupForm()

            NationalUniverseSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub NationalUniverseSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.NationalUniverseController(Me.Session)

            _ViewModel = _Controller.Load()

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()
            FormatGrid_Details()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub NationalUniverseSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

            Me.ClearChanged()

            DataGridViewLeftSection_NationalUniverses.GridViewSelectionChanged()

        End Sub
        Private Sub NationalUniverseSetupForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub NationalUniverseSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ClearChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim NationalUniverseID As Integer = 0

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If _Controller.Save(_ViewModel, ErrorMessage) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                        End If

                    Else

                        For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                            ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                        Next

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Else

                    [Continue] = False

                End If

            Else

                [Continue] = True

            End If

            If [Continue] Then

                If AdvantageFramework.Maintenance.Media.Presentation.NationalUniverseEditDialog.ShowFormDialog(NationalUniverseID) = Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    _Controller.RefreshNationalUniverses(_ViewModel)

                    LoadGrid()

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_NationalUniverses.SelectRow(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.ID.ToString, NationalUniverseID, True)

                    DataGridViewLeftSection_NationalUniverses.GridViewSelectionChanged()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    If _Controller.Save(_ViewModel, ErrorMessage) Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        If DataGridViewLeftSection_NationalUniverses.CurrentView.GetFocusedRow Is Nothing Then

                            DataGridViewLeftSection_NationalUniverses.GridViewSelectionChanged()

                        End If

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to cancel all your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                _Controller.NationalUniverseSelectionChanged(_ViewModel, DataGridViewLeftSection_NationalUniverses.GetFirstSelectedRowDataBoundItem())

                LoadGrid_Details()

                RefreshViewModel()

                Me.ClearChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    If _Controller.Delete(_ViewModel, ErrorMessage) Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        _Controller.RefreshNationalUniverses(_ViewModel)

                        LoadGrid()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        DataGridViewLeftSection_NationalUniverses.GridViewSelectionChanged()

                        RefreshViewModel()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_NationalUniverses_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_NationalUniverses.ColumnFilterChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                DataGridViewLeftSection_NationalUniverses.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_NationalUniverses_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_NationalUniverses.FocusedRowChangedEvent

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If _Controller.Save(_ViewModel, ErrorMessage) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                            DataGridViewLeftSection_NationalUniverses.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                        End If

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        DataGridViewLeftSection_NationalUniverses.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    _Controller.NationalUniverseSelectionChanged(_ViewModel, DataGridViewLeftSection_NationalUniverses.GetFirstSelectedRowDataBoundItem())

                    LoadGrid_Details()

                    RefreshViewModel()

                    Me.ClearChanged()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace