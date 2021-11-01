Namespace Security.Setup.Presentation

    Public Class CDPSecurityGroupSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupSetupController = Nothing
        Protected _HaveSetFilters As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            DataGridViewLeftSection_CDPSecurityGroups.DataSource = _ViewModel.CDPSecurityGroups

        End Sub
        Private Sub FormatGrid()

            DataGridViewLeftSection_CDPSecurityGroups.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadViewModel()

            If _ViewModel.SelectedCDPSecurityGroupViewModel IsNot Nothing Then

                TextBoxRightSection_Name.Text = _ViewModel.SelectedCDPSecurityGroupViewModel.CDPSecurityGroup.Name

            Else

                TextBoxRightSection_Name.Text = String.Empty

            End If

            LoadViewModelGrids()

            DataGridViewCDPs_AvailableCDPs.CurrentView.BestFitColumns()
            DataGridViewCDPs_SelectedCDPs.CurrentView.BestFitColumns()

            DataGridViewEmployees_AvailableEmployees.CurrentView.BestFitColumns()
            DataGridViewEmployees_SelectedEmployees.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadViewModelGrids()

            If _ViewModel.SelectedCDPSecurityGroupViewModel IsNot Nothing Then

                DataGridViewEmployees_AvailableEmployees.DataSource = _ViewModel.SelectedCDPSecurityGroupViewModel.AvailableEmployees.ToList
                DataGridViewEmployees_SelectedEmployees.DataSource = _ViewModel.SelectedCDPSecurityGroupViewModel.GroupEmployees.ToList

                DataGridViewCDPs_AvailableCDPs.DataSource = _ViewModel.SelectedCDPSecurityGroupViewModel.AvailableCDPs.ToList
                DataGridViewCDPs_SelectedCDPs.DataSource = _ViewModel.SelectedCDPSecurityGroupViewModel.GroupCDPs.ToList

            Else

                DataGridViewEmployees_AvailableEmployees.DataSource = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)
                DataGridViewEmployees_SelectedEmployees.DataSource = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee)

                DataGridViewCDPs_AvailableCDPs.DataSource = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)
                DataGridViewCDPs_SelectedCDPs.DataSource = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)

            End If

            If _HaveSetFilters = False Then

                DataGridViewCDPs_AvailableCDPs.CurrentView.AFActiveFilterString = "[IsActive] = True"
                DataGridViewEmployees_AvailableEmployees.CurrentView.AFActiveFilterString = "[Terminated] = False"

                _HaveSetFilters = True

            End If

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.SelectedCDPSecurityGroupViewModel.CDPSecurityGroup.Name = TextBoxRightSection_Name.Text
            _ViewModel.SelectedCDPSecurityGroup.Name = TextBoxRightSection_Name.Text

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Refresh.Enabled = _ViewModel.RefreshEnabled

            TabControlRightSection_CDPsAndEmployees.Enabled = _ViewModel.HasASelectedCDPSecurityGroup

            TextBoxRightSection_Name.Enabled = _ViewModel.HasASelectedCDPSecurityGroup

            ButtonCDPs_AddCDPs.Enabled = (_ViewModel.HasASelectedCDPSecurityGroup AndAlso _ViewModel.SelectedCDPSecurityGroupViewModel.HasASelectedAvailableCDP)
            ButtonCDPs_RemoveCDPs.Enabled = (_ViewModel.HasASelectedCDPSecurityGroup AndAlso _ViewModel.SelectedCDPSecurityGroupViewModel.HasASelectedGroupCDP)

            ButtonEmployees_AddEmployees.Enabled = (_ViewModel.HasASelectedCDPSecurityGroup AndAlso _ViewModel.SelectedCDPSecurityGroupViewModel.HasASelectedAvailableEmployee)
            ButtonEmployees_RemoveEmployees.Enabled = (_ViewModel.HasASelectedCDPSecurityGroup AndAlso _ViewModel.SelectedCDPSecurityGroupViewModel.HasASelectedGroupEmployee)

        End Sub
        Private Sub SetControlPropertySettings()

            TextBoxRightSection_Name.SetPropertySettings(AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup.Properties.Name)

            DataGridViewLeftSection_CDPSecurityGroups.ByPassUserEntryChanged = True
            DataGridViewLeftSection_CDPSecurityGroups.OptionsBehavior.Editable = False
            DataGridViewLeftSection_CDPSecurityGroups.OptionsSelection.MultiSelect = False
            DataGridViewLeftSection_CDPSecurityGroups.ItemDescription = "CDP Group(s)"

            DataGridViewCDPs_AvailableCDPs.ShowSelectDeselectAllButtons = True
            DataGridViewCDPs_AvailableCDPs.OptionsBehavior.Editable = False
            DataGridViewCDPs_AvailableCDPs.ItemDescription = "Available CDP(s)"

            DataGridViewCDPs_SelectedCDPs.ShowSelectDeselectAllButtons = True
            DataGridViewCDPs_SelectedCDPs.OptionsBehavior.Editable = False
            DataGridViewCDPs_SelectedCDPs.ItemDescription = "Selected CDP(s)"

            DataGridViewEmployees_AvailableEmployees.ShowSelectDeselectAllButtons = True
            DataGridViewEmployees_AvailableEmployees.OptionsBehavior.Editable = False
            DataGridViewEmployees_AvailableEmployees.ItemDescription = "Available Employee(s)"

            DataGridViewEmployees_SelectedEmployees.ShowSelectDeselectAllButtons = True
            DataGridViewEmployees_SelectedEmployees.OptionsBehavior.Editable = False
            DataGridViewEmployees_SelectedEmployees.ItemDescription = "Selected Employee(s)"

        End Sub
        Private Sub RefreshUserSetupForm()

            Try

                For Each MdiChild In Me.ParentForm.MdiChildren

                    If TypeOf MdiChild Is AdvantageFramework.Security.Setup.Presentation.UserSetupForm Then

                        DirectCast(MdiChild, AdvantageFramework.Security.Setup.Presentation.UserSetupForm).RefreshData()
                        Exit For

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CDPSecurityGroupSetupForm As AdvantageFramework.Security.Setup.Presentation.CDPSecurityGroupSetupForm = Nothing

            CDPSecurityGroupSetupForm = New AdvantageFramework.Security.Setup.Presentation.CDPSecurityGroupSetupForm()

            CDPSecurityGroupSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CDPSecurityGroupSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupSetupController(Me.Session)

            _ViewModel = _Controller.Load()

            LoadGrid()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub CDPSecurityGroupSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

            DataGridViewLeftSection_CDPSecurityGroups.GridViewSelectionChanged()

        End Sub
        Private Sub CDPSecurityGroupSetupForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub CDPSecurityGroupSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ClearChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim CDPSecurityGroupName As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim [Continue] As Boolean = False

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        SaveViewModel()

                        If _Controller.Save(_ViewModel, ErrorMessage) Then

                            [Continue] = True

                            DataGridViewLeftSection_CDPSecurityGroups.CurrentView.RefreshData()
                            DataGridViewLeftSection_CDPSecurityGroups.CurrentView.BestFitColumns()

                            RefreshViewModel()

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

                If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("New CDP Group", "Please enter a new CDP Group Name", "",
                                                                                       CDPSecurityGroupName, AdvantageFramework.Database.Entities.CDPSecurityGroup.Properties.Name) = System.Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                    If _Controller.Add(_ViewModel, CDPSecurityGroupName, ErrorMessage) Then

                        _Controller.LoadCDPSecurityGroups(_ViewModel)

                        LoadGrid()

                        DataGridViewLeftSection_CDPSecurityGroups.GridViewSelectionChanged()

                        _Controller.SelectedCDPSecurityGroupsChanged(_ViewModel, DataGridViewLeftSection_CDPSecurityGroups.GetFirstSelectedRowDataBoundItem)

                        LoadViewModel()

                        RefreshViewModel()

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            AdvantageFramework.WinForm.MessageBox.Show("Failed to add new CDP Group.")

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Failed to add new CDP Group." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    SaveViewModel()

                    If _Controller.Save(_ViewModel, ErrorMessage) Then

                        DataGridViewLeftSection_CDPSecurityGroups.CurrentView.RefreshData()
                        DataGridViewLeftSection_CDPSecurityGroups.CurrentView.BestFitColumns()

                        RefreshViewModel()

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                        RefreshUserSetupForm()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            AdvantageFramework.WinForm.MessageBox.Show("Failed to save CDP Group.")

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Failed to save CDP Group." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                        End If

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

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                DataGridViewLeftSection_CDPSecurityGroups.GridViewSelectionChanged()

                _Controller.SelectedCDPSecurityGroupsChanged(_ViewModel, DataGridViewLeftSection_CDPSecurityGroups.GetFirstSelectedRowDataBoundItem)

                LoadViewModel()

                RefreshViewModel()

                Me.ClearChanged()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.RaiseClearChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If _Controller.Delete(_ViewModel, ErrorMessage) Then

                        _Controller.LoadCDPSecurityGroups(_ViewModel)

                        LoadGrid()

                        DataGridViewLeftSection_CDPSecurityGroups.GridViewSelectionChanged()

                        _Controller.SelectedCDPSecurityGroupsChanged(_ViewModel, DataGridViewLeftSection_CDPSecurityGroups.GetFirstSelectedRowDataBoundItem)

                        LoadViewModel()

                        RefreshViewModel()

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                        RefreshUserSetupForm()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            AdvantageFramework.WinForm.MessageBox.Show("Failed to deleted CDP Group.")

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Failed to deleted CDP Group." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_CDPSecurityGroups_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_CDPSecurityGroups.ColumnFilterChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                DataGridViewLeftSection_CDPSecurityGroups.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_CDPSecurityGroups_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_CDPSecurityGroups.FocusedRowChangedEvent

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        SaveViewModel()

                        If _Controller.Save(_ViewModel, ErrorMessage) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                            DataGridViewLeftSection_CDPSecurityGroups.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                        End If

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        DataGridViewLeftSection_CDPSecurityGroups.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    _Controller.SelectedCDPSecurityGroupsChanged(_ViewModel, DataGridViewLeftSection_CDPSecurityGroups.GetFirstSelectedRowDataBoundItem)

                    LoadViewModel()

                    RefreshViewModel()

                    Me.ClearChanged()

                End If

            End If

        End Sub
        'Private Sub DataGridViewLeftSection_CDPSecurityGroups_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_CDPSecurityGroups.SelectionChangedEvent

        '    If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

        '        _Controller.SelectedCDPSecurityGroupsChanged(_ViewModel, DataGridViewLeftSection_CDPSecurityGroups.GetFirstSelectedRowDataBoundItem)

        '        LoadViewModel()

        '        RefreshViewModel()

        '    End If

        'End Sub
        Private Sub DataGridViewEmployees_AvailableEmployees_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEmployees_AvailableEmployees.ColumnFilterChangedEvent

            DataGridViewEmployees_AvailableEmployees.GridViewSelectionChanged()

        End Sub
        Private Sub DataGridViewEmployees_AvailableEmployees_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEmployees_AvailableEmployees.SelectionChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.SelectedAvailableEmployeesChanged(_ViewModel, DataGridViewEmployees_AvailableEmployees.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee).ToList)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewEmployees_SelectedEmployees_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEmployees_SelectedEmployees.ColumnFilterChangedEvent

            DataGridViewEmployees_AvailableEmployees.GridViewSelectionChanged()

        End Sub
        Private Sub DataGridViewEmployees_SelectedEmployees_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEmployees_SelectedEmployees.SelectionChangedEvent

            _Controller.SelectedGroupEmployeesChanged(_ViewModel, DataGridViewEmployees_SelectedEmployees.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee).ToList)

            RefreshViewModel()

        End Sub
        Private Sub DataGridViewCDPs_AvailableCDPs_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCDPs_AvailableCDPs.ColumnFilterChangedEvent

            DataGridViewCDPs_AvailableCDPs.GridViewSelectionChanged()

        End Sub
        Private Sub DataGridViewCDPs_AvailableCDPs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCDPs_AvailableCDPs.SelectionChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.SelectedAvailableCDPsChanged(_ViewModel, DataGridViewCDPs_AvailableCDPs.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP).ToList)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewCDPs_SelectedCDPs_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCDPs_SelectedCDPs.ColumnFilterChangedEvent

            DataGridViewCDPs_AvailableCDPs.GridViewSelectionChanged()

        End Sub
        Private Sub DataGridViewCDPs_SelectedCDPs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCDPs_SelectedCDPs.SelectionChangedEvent

            _Controller.SelectedGroupCDPsChanged(_ViewModel, DataGridViewCDPs_SelectedCDPs.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP).ToList)

            RefreshViewModel()

        End Sub
        Private Sub ButtonEmployees_AddEmployees_Click(sender As Object, e As EventArgs) Handles ButtonEmployees_AddEmployees.Click

            _Controller.AddEmployees(_ViewModel)

            LoadViewModelGrids()

            DataGridViewEmployees_AvailableEmployees.SetUserEntryChanged()

            RefreshViewModel()

        End Sub
        Private Sub ButtonEmployees_RemoveEmployees_Click(sender As Object, e As EventArgs) Handles ButtonEmployees_RemoveEmployees.Click

            _Controller.RemoveEmployees(_ViewModel)

            LoadViewModelGrids()

            DataGridViewEmployees_SelectedEmployees.SetUserEntryChanged()

            RefreshViewModel()

        End Sub
        Private Sub ButtonCDPs_AddCDPs_Click(sender As Object, e As EventArgs) Handles ButtonCDPs_AddCDPs.Click

            _Controller.AddCDPs(_ViewModel)

            LoadViewModelGrids()

            DataGridViewCDPs_AvailableCDPs.SetUserEntryChanged()

            RefreshViewModel()

        End Sub
        Private Sub ButtonCDPs_RemoveCDPs_Click(sender As Object, e As EventArgs) Handles ButtonCDPs_RemoveCDPs.Click

            _Controller.RemoveCDPs(_ViewModel)

            LoadViewModelGrids()

            DataGridViewCDPs_SelectedCDPs.SetUserEntryChanged()

            RefreshViewModel()

        End Sub

#End Region

#End Region

    End Class

End Namespace
