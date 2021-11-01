Namespace Maintenance.Media.Presentation

    Public Class CanadaUniverseSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.CanadaUniverseSetupController = Nothing

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

            DataGridViewRightSection_CanadaUniverseDetails.Enabled = _ViewModel.HasASelectedCanadaUniverse

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewLeftSection_CanadaUniverse.OptionsBehavior.Editable = False
            DataGridViewLeftSection_CanadaUniverse.OptionsSelection.MultiSelect = False

            DataGridViewLeftSection_CanadaUniverse.ItemDescription = "Universe(s)"

            DataGridViewRightSection_CanadaUniverseDetails.OptionsCustomization.AllowColumnMoving = False
            DataGridViewRightSection_CanadaUniverseDetails.OptionsCustomization.AllowFilter = False
            DataGridViewRightSection_CanadaUniverseDetails.OptionsCustomization.AllowGroup = False
            DataGridViewRightSection_CanadaUniverseDetails.OptionsCustomization.AllowSort = False
            DataGridViewRightSection_CanadaUniverseDetails.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewRightSection_CanadaUniverseDetails.OptionsMenu.EnableColumnMenu = False

            DataGridViewRightSection_CanadaUniverseDetails.ItemDescription = "Segment(s)"

        End Sub
        Private Sub SetControlDataSources()



        End Sub
        Private Sub LoadGrid()

            DataGridViewLeftSection_CanadaUniverse.DataSource = _ViewModel.CanadaUniverses

        End Sub
        Private Sub FormatGrid()

            DataGridViewLeftSection_CanadaUniverse.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadGrid_Details()

            DataGridViewRightSection_CanadaUniverseDetails.DataSource = _ViewModel.SelectedCanadaUniverseDetails

        End Sub
        Private Sub FormatGrid_Details()

            If DataGridViewRightSection_CanadaUniverseDetails.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail.Properties.Segment.ToString) IsNot Nothing Then

                DataGridViewRightSection_CanadaUniverseDetails.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail.Properties.Segment.ToString).OptionsColumn.AllowFocus = False

            End If

            DataGridViewRightSection_CanadaUniverseDetails.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CanadaUniverseSetupForm As AdvantageFramework.Maintenance.Media.Presentation.CanadaUniverseSetupForm = Nothing

            CanadaUniverseSetupForm = New AdvantageFramework.Maintenance.Media.Presentation.CanadaUniverseSetupForm

            CanadaUniverseSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CanadaUniverseSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.CanadaUniverseSetupController(Me.Session)

            _ViewModel = _Controller.Load()

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()
            FormatGrid_Details()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub CanadaUniverseSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

            Me.ClearChanged()

            DataGridViewLeftSection_CanadaUniverse.GridViewSelectionChanged()

        End Sub
        Private Sub CanadaUniverseSetupForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub CanadaUniverseSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

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
            Dim CanadaUniverseID As Integer = 0

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

                If AdvantageFramework.Maintenance.Media.Presentation.CanadaUniverseEditDialog.ShowFormDialog(CanadaUniverseID) = Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    _Controller.RefreshCanadaUniverses(_ViewModel)

                    LoadGrid()

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_CanadaUniverse.SelectRow(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse.Properties.ID.ToString, CanadaUniverseID, True)

                    DataGridViewLeftSection_CanadaUniverse.GridViewSelectionChanged()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    If _Controller.Save(_ViewModel, ErrorMessage) Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        If DataGridViewLeftSection_CanadaUniverse.CurrentView.GetFocusedRow Is Nothing Then

                            DataGridViewLeftSection_CanadaUniverse.GridViewSelectionChanged()

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

                _Controller.CanadaUniverseSelectionChanged(_ViewModel, DataGridViewLeftSection_CanadaUniverse.GetFirstSelectedRowDataBoundItem())

                LoadGrid_Details()

                RefreshViewModel()

                Me.ClearChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete universe data for the selected market?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    If _Controller.Delete(_ViewModel, ErrorMessage) Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        _Controller.RefreshCanadaUniverses(_ViewModel)

                        LoadGrid()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        DataGridViewLeftSection_CanadaUniverse.GridViewSelectionChanged()

                        RefreshViewModel()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_CanadaUniverse_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_CanadaUniverse.ColumnFilterChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                DataGridViewLeftSection_CanadaUniverse.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_CanadaUniverse_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_CanadaUniverse.FocusedRowChangedEvent

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

                            DataGridViewLeftSection_CanadaUniverse.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                        End If

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        DataGridViewLeftSection_CanadaUniverse.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    _Controller.CanadaUniverseSelectionChanged(_ViewModel, DataGridViewLeftSection_CanadaUniverse.GetFirstSelectedRowDataBoundItem())

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
