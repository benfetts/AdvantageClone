Namespace Media.Presentation

    Public Class MediaRequestForProposalDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaRequestForProposalController = Nothing
        Protected _MediaBroadcastWorksheetMarketID As Integer = 0
        Protected _ReloadGrid As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetMarketID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load(_MediaBroadcastWorksheetMarketID)

            TabItemTabs_Markets.Visible = _ViewModel.IsCanadianWorksheet AndAlso _ViewModel.MediaTypeCode = "T"

        End Sub
        Private Sub SaveViewModel()

            If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_AvailLines) Then

                DataGridViewAvailLines_AvailLines.CurrentView.CloseEditorForUpdating()

                _ViewModel.MediaRFPAvailLines = DataGridViewAvailLines_AvailLines.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).ToList

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Demos) Then

                DataGridViewDemos_Demos.CurrentView.CloseEditorForUpdating()

                _ViewModel.MediaRFPDemos = DataGridViewDemos_Demos.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo).ToList

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines) Then

                _ViewModel.RFPGuidelines = RichEditGuidelines_Guidelines.HtmlBodyOnly

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors) Then

                DataGridViewVendors_Vendors.CurrentView.CloseEditorForUpdating()

                _ViewModel.MediaRFPHeaders = DataGridViewVendors_Vendors.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeader).ToList

            End If

        End Sub
        Private Sub RefreshViewModel(RefreshData As Boolean)

            If Me.FormShown Then

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                RichEditGuidelines_Guidelines.HtmlText = _ViewModel.RFPGuidelines

                If RefreshData Then

                    DataGridViewVendors_Vendors.DataSource = _ViewModel.MediaRFPHeaders
                    DataGridViewVendors_Vendors.CurrentView.BestFitColumns()

                End If

                DataGridViewAvailLines_AvailLines.RefreshDataSource()
                DataGridViewMarkets_Markets.RefreshDataSource()

                If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_AvailLines) Then

                    RibbonBarFilePanel_AvailLines.Visible = True
                    RibbonBarFilePanel_Dayparts.Visible = True

                Else

                    RibbonBarFilePanel_Dayparts.Visible = False
                    RibbonBarFilePanel_AvailLines.Visible = False

                End If

                If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Markets) Then

                    RibbonBarFilePanel_Markets.Visible = True

                Else

                    RibbonBarFilePanel_Markets.Visible = False

                End If

                ButtonItemActions_Default.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines)

                ButtonItemActions_Import.Enabled = (_ViewModel.SelectedMediaRFPHeader IsNot Nothing)

                ButtonItemActions_Upload.Visible = _ViewModel.IsAgencyASP

                ButtonItemActions_AutoFill.Enabled = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors)

                ButtonItemActions_Save.Enabled = (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_AvailLines) AndAlso _ViewModel.MediaRFPAvailLines.Where(Function(AL) AL.Modified = True).Any) OrElse
                        (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Demos) AndAlso _ViewModel.MediaRFPDemos.Where(Function(AL) AL.Modified = True).Any) OrElse
                        (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors) AndAlso _ViewModel.MediaRFPHeaders.Where(Function(AL) AL.Modified = True).Any) OrElse
                        (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines) AndAlso RichEditGuidelines_Guidelines.Tag = True) OrElse
                        (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Markets) AndAlso _ViewModel.MediaRFPMarkets.Where(Function(AL) AL.Modified = True).Any)

                ButtonItemActions_Generate.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors)
                ButtonItemActions_Generate.Enabled = Not ButtonItemActions_Save.Enabled

                RibbonBarFilePanel_Actions.ResetCachedContentSize()
                RibbonBarFilePanel_Actions.Refresh()
                RibbonBarFilePanel_Actions.Width = RibbonBarFilePanel_Actions.GetAutoSizeWidth
                RibbonBarFilePanel_Actions.Refresh()

                ButtonItemAvailLines_AddToWorksheet.Enabled = Not ButtonItemActions_Save.Enabled AndAlso _ViewModel.AddToWorksheetEnabled
                ButtonItemAvailLines_UpdateWorksheet.Enabled = False ' Not ButtonItemActions_Save.Enabled AndAlso DataGridViewAvailLines_AvailLines.HasASelectedRow
                ButtonItemAvailLines_AutoFill.Enabled = DataGridViewAvailLines_AvailLines.HasASelectedRow

                ButtonItemDayparts_Manage.Enabled = _ViewModel.SelectedMediaRFPHeader IsNot Nothing AndAlso TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_AvailLines)

                TabItemTabs_Status.Visible = (_ViewModel.SelectedMediaRFPHeader IsNot Nothing)
                TabItemTabs_AvailLines.Visible = (_ViewModel.SelectedMediaRFPHeader IsNot Nothing)
                TabItemTabs_Demos.Visible = (_ViewModel.SelectedMediaRFPHeader IsNot Nothing)

                ButtonItemView_Responses.Enabled = _ViewModel.MediaRFPHeaders.Where(Function(Entity) Entity.AlertID.HasValue).Any

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub SetControlDataSources()

            ComboBoxAvailLines_Status.DataSource = (From Entity In _ViewModel.RepositoryStatusList
                                                    Where Entity.Value <> AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.T.ToString)

        End Sub
        Private Sub SetControlPropertySettings()

            ComboBoxAvailLines_Status.DisableMouseWheel = True
            ComboBoxAvailLines_Status.ExtraComboBoxItem = WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.Nothing
            ComboBoxAvailLines_Status.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList

            DataGridViewVendors_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewVendors_Vendors.OptionsBehavior.Editable = True
            DataGridViewVendors_Vendors.MultiSelect = True

            DataGridViewStatus_Statuses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewStatus_Statuses.OptionsBehavior.Editable = False
            DataGridViewStatus_Statuses.MultiSelect = False

            DataGridViewAvailLines_AvailLines.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewAvailLines_AvailLines.OptionsBehavior.Editable = True
            DataGridViewAvailLines_AvailLines.MultiSelect = True
            DataGridViewAvailLines_AvailLines.ShowSelectDeselectAllButtons = True

            DataGridViewDemos_Demos.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewDemos_Demos.OptionsBehavior.Editable = True
            DataGridViewDemos_Demos.MultiSelect = True

            DataGridViewMarkets_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewMarkets_Markets.OptionsBehavior.Editable = False
            DataGridViewMarkets_Markets.MultiSelect = True

        End Sub
        Private Sub LoadAvailLines()

            'objects
            Dim SubItemDateInput As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput = Nothing

            _Controller.LoadAvailLines(_ViewModel)

            DataGridViewAvailLines_AvailLines.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine))

            DataGridViewAvailLines_AvailLines.DataSource = _ViewModel.MediaRFPAvailLines

            For Each GridColumn In DataGridViewAvailLines_AvailLines.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndDate.ToString Then

                    SubItemDateInput = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput
                    SubItemDateInput.BroadcastCalendarWeeks = _ViewModel.BroadcastCalendarWeeks
                    SubItemDateInput.ControlType = WinForm.MVC.Presentation.Controls.SubItemDateInput.Type.Broadcast

                    DataGridViewAvailLines_AvailLines.GridControl.RepositoryItems.Add(SubItemDateInput)

                    GridColumn.ColumnEdit = SubItemDateInput

                End If

            Next

            If _ViewModel.SelectedMediaRFPHeader.MediaTypeCode = "R" Then

                If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.NetworkName.ToString) IsNot Nothing Then

                    DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.NetworkName.ToString).Visible = False

                End If

                If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.CableNetworkStationCode.ToString) IsNot Nothing Then

                    DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.CableNetworkStationCode.ToString).Visible = False

                End If

                If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString) IsNot Nothing Then

                    DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString).Visible = False

                End If

            End If

            If _ViewModel.SelectedMediaRFPHeader.MediaTypeCode = "T" Then

                If _ViewModel.MediaBroadcastWorksheetRatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                    If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.CableNetworkStationCode.ToString) IsNot Nothing Then

                        DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.CableNetworkStationCode.ToString).Visible = False

                    End If

                    If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString) IsNot Nothing Then

                        DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString).Visible = True

                    End If

                Else

                    If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.CableNetworkStationCode.ToString) IsNot Nothing Then

                        DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.CableNetworkStationCode.ToString).Visible = True

                    End If

                    If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString) IsNot Nothing Then

                        DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString).Visible = False

                    End If

                End If

            End If

            If _ViewModel.IsCanadianWorksheet Then

                If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.NetworkName.ToString) IsNot Nothing Then

                    DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.NetworkName.ToString).Visible = False

                End If

                If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.CableNetworkStationCode.ToString) IsNot Nothing Then

                    DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.CableNetworkStationCode.ToString).Visible = False

                End If

                If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString) IsNot Nothing Then

                    DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString).Visible = False

                End If

            End If

            DataGridViewAvailLines_AvailLines.CurrentView.BestFitColumns()

            If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartTime.ToString) IsNot Nothing Then

                DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartTime.ToString).SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

            End If

            If DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndTime.ToString) IsNot Nothing Then

                DataGridViewAvailLines_AvailLines.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndTime.ToString).SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

            End If

        End Sub
        Private Sub LoadDemos()

            _Controller.LoadDemos(_ViewModel)

            DataGridViewDemos_Demos.ClearDatasource()

            DataGridViewDemos_Demos.DataSource = _ViewModel.MediaRFPDemos
            DataGridViewDemos_Demos.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadHeaderStatuses()

            _Controller.LoadHeaderStatuses(_ViewModel)

            DataGridViewStatus_Statuses.ClearDatasource()

            DataGridViewStatus_Statuses.DataSource = _ViewModel.MediaRFPHeaderStatuses
            DataGridViewStatus_Statuses.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadMarkets()

            _Controller.LoadMarkets(_ViewModel)

            DataGridViewMarkets_Markets.ClearDatasource()

            DataGridViewMarkets_Markets.DataSource = _ViewModel.MediaRFPMarkets
            DataGridViewMarkets_Markets.CurrentView.BestFitColumns()

        End Sub
        Private Sub Save()

            'objects
            Dim RefreshData As Boolean = False
            Dim FocusedRowHandle As Integer = 0

            SaveViewModel()

            If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_AvailLines) Then

                FocusedRowHandle = DataGridViewAvailLines_AvailLines.CurrentView.FocusedRowHandle

                _Controller.SaveAvailLines(_ViewModel)

                LoadAvailLines()

                DataGridViewAvailLines_AvailLines.CurrentView.SelectRow(FocusedRowHandle)

                DataGridViewAvailLines_AvailLines.CurrentView.MakeRowVisible(FocusedRowHandle)

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Demos) Then

                _Controller.SaveDemos(_ViewModel)

                LoadDemos()

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors) Then

                _Controller.SaveMediaRFPHeaders(_ViewModel)

                RefreshData = True

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines) Then

                If _Controller.SaveMediaBroadcastWorksheetMarketRFPGuidelines(_ViewModel) Then

                    RichEditGuidelines_Guidelines.Tag = False
                    ButtonItemActions_Save.Enabled = False

                End If

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Markets) Then

                _Controller.SaveMarkets(_ViewModel)

                LoadMarkets()

            End If

            RefreshViewModel(RefreshData)

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            If ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Save()

                ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines) Then

                    RichEditGuidelines_Guidelines.Tag = False

                End If

            End If

            CheckForUnsavedChanges = True

        End Function
        Private Sub AddToWorksheet(OmitSpots As Boolean)

            'objects 
            Dim AddLines As Boolean = True
            Dim ErrorMessage As String = Nothing

            If (From Entity In Me.DataGridViewAvailLines_AvailLines.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine)
                Where Entity.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.P.ToString AndAlso
                      Entity.HasDateOutsideOfWorksheet = True).Any Then

                If AdvantageFramework.WinForm.MessageBox.Show("Warning - scheduling outside of Worksheet dates will be omitted. Proceed?  Y/N", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxIcon:=Windows.Forms.MessageBoxIcon.Warning, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.No Then

                    AddLines = False

                End If

            End If

            If AddLines Then

                Me.ShowWaitForm("Adding...")

                SaveViewModel()

                If _Controller.AddToWorksheet(_ViewModel, ErrorMessage, OmitSpots) Then

                    _ReloadGrid = True

                    AdvantageFramework.WinForm.MessageBox.Show("Pending rows added to worksheet.")

                    LoadAvailLines()

                    RefreshViewModel(False)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("An error occurred adding to worksheet: " & ErrorMessage)

                End If

                Me.CloseWaitForm()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetMarketID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaRequestForProposalDialog As MediaRequestForProposalDialog = Nothing

            MediaRequestForProposalDialog = New MediaRequestForProposalDialog(MediaBroadcastWorksheetMarketID)

            ShowFormDialog = MediaRequestForProposalDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaRequestForProposalDialog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            e.Cancel = Not CheckForUnsavedChanges()

            If Not e.Cancel Then

                If _ReloadGrid Then

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                Else

                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

                End If

            End If

        End Sub
        Private Sub MediaRequestForProposalDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Generate.Image = AdvantageFramework.My.Resources.MediaAddImage
            ButtonItemActions_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage

            ButtonItemTemplates_Edit.Image = AdvantageFramework.My.Resources.TemplateImage

            ButtonItemAvailLines_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage
            ButtonItemAvailLines_AddToWorksheet.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemAvailLines_UpdateWorksheet.Image = AdvantageFramework.My.Resources.UpdateImage

            ButtonItemDayparts_Manage.Image = AdvantageFramework.My.Resources.MaintenanceImage

            ButtonItemMarkets_Manage.Image = AdvantageFramework.My.Resources.MaintenanceImage

            ButtonItemActions_Default.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemView_Responses.Image = AdvantageFramework.My.Resources.MailOpenImage

            _Controller = New AdvantageFramework.Controller.Media.MediaRequestForProposalController(Me.Session)

            SetControlPropertySettings()

            RichEditGuidelines_Guidelines.RichEditControl.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF")
            RichEditGuidelines_Guidelines.RestrictFontNameSize = True

        End Sub
        Private Sub MediaRequestForProposalDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            SetControlDataSources()

            RefreshViewModel(True)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Import.Click

            If DataGridViewVendors_Vendors.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Importing.Presentation.ImportWizardDialog.ShowWizardDialog(AdvantageFramework.Importing.ImportType.MediaRFP, AdvantageFramework.Importing.ImportTemplateTypes.MediaRFP_4As, Nothing,
                                                                                                 MediaRFPHeaderID:=DirectCast(DataGridViewVendors_Vendors.GetFirstSelectedRowDataBoundItem(), DTO.Media.RFP.MediaRFPHeader).ID,
                                                                                                 MediaBroadcastWorksheetMarketID:=DirectCast(DataGridViewVendors_Vendors.GetFirstSelectedRowDataBoundItem(), DTO.Media.RFP.MediaRFPHeader).MediaBroadcastWorksheetMarketID) = Windows.Forms.DialogResult.OK Then

                    _Controller.RefreshMediaRFPHeaders(_ViewModel)

                    If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_AvailLines) Then

                        LoadAvailLines()

                    End If

                    RefreshViewModel(True)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_GenerateOrders_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Generate.Click

            If AdvantageFramework.Media.Presentation.MediaRequestForProposalGenerateRFPDialog.ShowFormDialog(DataGridViewVendors_Vendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeader).ToList) = Windows.Forms.DialogResult.OK Then

                LoadViewModel()

                RefreshViewModel(True)

                LoadHeaderStatuses()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemAvailLines_AddToWorksheet_Click(sender As Object, e As EventArgs) Handles ButtonItemAvailLines_AddToWorksheet.Click

            AddToWorksheet(False)

        End Sub
        Private Sub ButtonItemAvailLines_OmitSpots_Click(sender As Object, e As EventArgs) Handles ButtonItemAvailLines_OmitSpots.Click

            AddToWorksheet(True)

        End Sub
        Private Sub ButtonItemAvailLines_AutoFill_Click(sender As Object, e As EventArgs) Handles ButtonItemAvailLines_AutoFill.Click

            'objects
            Dim SelectedItems As IEnumerable = Nothing
            Dim ModifiedDictonary As Generic.Dictionary(Of Integer, Object) = Nothing

            If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_AvailLines) Then

                DataGridViewAvailLines_AvailLines.CurrentView.CloseEditorForUpdating()

                SelectedItems = DataGridViewAvailLines_AvailLines.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).ToList

                ModifiedDictonary = DataGridViewAvailLines_AvailLines.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                If AdvantageFramework.WinForm.Presentation.AutoFillDialog.ShowFormDialog(SelectedItems) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm("Validating ...")

                    For Each KeyValuePair In ModifiedDictonary

                        _Controller.MediaRFPAvailLineValidateEntity(DirectCast(KeyValuePair.Value, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine), True)

                        DirectCast(KeyValuePair.Value, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).Modified = True

                    Next

                    Me.CloseWaitForm()

                End If

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub ButtonItemAvailLines_MarkSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemAvailLines_MarkSelected.Click

            Dim InfoMessage As String = Nothing

            DataGridViewAvailLines_AvailLines.CurrentView.CloseEditorForUpdating()

            _Controller.SetSelectedAvailLinesStatus(_ViewModel, ComboBoxAvailLines_Status.GetSelectedValue, DataGridViewAvailLines_AvailLines.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).ToList, InfoMessage)

            If String.IsNullOrWhiteSpace(InfoMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(InfoMessage)

            End If

            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemAvailLines_UpdateWorksheet_Click(sender As Object, e As EventArgs) Handles ButtonItemAvailLines_UpdateWorksheet.Click

            '_Controller.SaveToWorksheet(_ViewModel)

        End Sub
        Private Sub ButtonItemDayparts_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemDayparts_Manage.Click

            'objects
            Dim DaypartNames As IEnumerable(Of String) = Nothing

            If DataGridViewVendors_Vendors.HasOnlyOneSelectedRow Then

                DaypartNames = (From Entity In DataGridViewAvailLines_AvailLines.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine)
                                Where Entity.DaypartID Is Nothing
                                Select Entity.DaypartName).Distinct.ToList

                AdvantageFramework.Media.Presentation.MediaRFPVendorDaypartCrossReferenceDialog.ShowFormDialog(_ViewModel.SelectedMediaRFPHeader.VendorCode, _ViewModel.SelectedMediaRFPHeader.VendorName, _ViewModel.SelectedMediaRFPHeader.MediaTypeCode, DaypartNames)

                _Controller.UpdateDayparts(_ViewModel, DataGridViewAvailLines_AvailLines.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).ToList)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub ButtonItemMarkets_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_Manage.Click

            'objects
            Dim SourceMarketNames As IEnumerable(Of String) = Nothing

            If DataGridViewVendors_Vendors.HasOnlyOneSelectedRow Then

                SourceMarketNames = (From Entity In DataGridViewMarkets_Markets.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPMarket)
                                     Where Entity.MarketCode Is Nothing
                                     Select Entity.SourceMarketName).Distinct.ToList

                AdvantageFramework.Media.Presentation.MediaRFPMarketCrossReferenceDialog.ShowFormDialog(SourceMarketNames)

                _Controller.UpdateMarkets(_ViewModel, DataGridViewMarkets_Markets.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPMarket).ToList)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim WebvantageURL As String = String.Empty
            Dim EmployeeEmailAddress As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                    If Employee IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Employee.Email) Then

                        EmployeeEmailAddress = Employee.Email

                        WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

                        HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                        HtmlEmail.AddHeaderRow("Upload Link")
                        HtmlEmail.AddCustomRow(Nothing, 3, Nothing, "#FF0000", "<a href=""" & WebvantageURL & "Document/UploadAvail?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Date=" & Now.ToString("MM/dd/yyyy hh:mm:ss tt") &
                                                                                                                                                                                          "&DatabaseName=" & Session.DatabaseName &
                                                                                                                                                                                          "&UserCode=" & Session.UserCode) & "%7C"" > Click Here to upload your files</a>")

                        HtmlEmail.AddBlankRow()
                        HtmlEmail.AddBlankRow()

                        HtmlEmail.Finish()

                        If AdvantageFramework.Email.Send(DbContext, EmployeeEmailAddress, "", "", "Upload Link - Avails", HtmlEmail.ToString, 3, New Generic.List(Of AdvantageFramework.Email.Classes.Attachment), SendingEmailStatus) Then

                            AdvantageFramework.WinForm.MessageBox.Show("Upload email sent!")

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("You must have an email address setup to use this feature.")

                    End If

                End If

            End Using

        End Sub
        Private Sub DataGridViewAvailLines_AvailLines_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewAvailLines_AvailLines.CellValueChangedEvent

            If e.Value IsNot Nothing Then

                _Controller.SetSelectedAvailLineModified(_ViewModel, DirectCast(DataGridViewAvailLines_AvailLines.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine), e.Column.FieldName)

                If e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString Then

                    DataGridViewAvailLines_AvailLines.ValidateAllRows()

                End If

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub DataGridViewAvailLines_AvailLines_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles DataGridViewAvailLines_AvailLines.CustomColumnSortEvent

            Dim Value1 As Object = Nothing
            Dim Value2 As Object = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartTime.ToString Then

                Value1 = DataGridViewAvailLines_AvailLines.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex1, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartHour.ToString)
                Value2 = DataGridViewAvailLines_AvailLines.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex2, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartHour.ToString)

                e.Handled = True
                e.Result = System.Collections.Comparer.Default.Compare(Value1, Value2)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndTime.ToString Then

                Value1 = DataGridViewAvailLines_AvailLines.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex1, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndHour.ToString)
                Value2 = DataGridViewAvailLines_AvailLines.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex2, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndHour.ToString)

                e.Handled = True
                e.Result = System.Collections.Comparer.Default.Compare(Value1, Value2)

            End If

        End Sub
        Private Sub DataGridViewAvailLines_AvailLines_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewAvailLines_AvailLines.CustomDrawCellEvent

            'objects
            Dim MediaRFPAvailLine As AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine = Nothing
            'Dim GridCellInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo = Nothing
            Dim BaseEditViewInfo As DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.Rating.ToString Then

                If DirectCast(DataGridViewAvailLines_AvailLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).HasMultipleRatings Then

                    e.DisplayText = FormatNumber(e.CellValue, 2).ToString & "+"

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.Rate.ToString Then

                If DirectCast(DataGridViewAvailLines_AvailLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).HasMultipleLineRates Then

                    e.DisplayText = FormatNumber(e.CellValue, 2).ToString & "+"

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.Impressions.ToString Then

                e.DisplayText = FormatNumber((e.CellValue / 1000), 1, TriState.True, TriState.False, TriState.True)

                If DirectCast(DataGridViewAvailLines_AvailLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).HasMultipleImpressions Then

                    e.DisplayText = e.DisplayText & "+"

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.Spots.ToString Then

                If DirectCast(DataGridViewAvailLines_AvailLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).HasMultipleLineSpots Then

                    e.DisplayText = FormatNumber(e.CellValue, 0).ToString & "+"

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartDate.ToString Then

                BaseEditViewInfo = CType(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo).ViewInfo

                MediaRFPAvailLine = DirectCast(DataGridViewAvailLines_AvailLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine)

                If String.IsNullOrWhiteSpace(MediaRFPAvailLine.Item(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartDate.ToString)) Then

                    If MediaRFPAvailLine.StartDate.HasValue AndAlso MediaRFPAvailLine.StartDate.Value < MediaRFPAvailLine.MediaBroadcastWorksheetStartDate Then

                        BaseEditViewInfo.ErrorIconText = "Data prior to " & MediaRFPAvailLine.MediaBroadcastWorksheetStartDate.ToShortDateString & " will be truncated"
                        BaseEditViewInfo.ErrorIcon = DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider.GetErrorIconInternal(DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
                        BaseEditViewInfo.ShowErrorIcon = True

                    ElseIf MediaRFPAvailLine.HasDetailDatesBeforeStartDate Then

                        BaseEditViewInfo.ErrorIconText = "Detail dates exist that fall before start date."
                        BaseEditViewInfo.ErrorIcon = DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider.GetErrorIconInternal(DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
                        BaseEditViewInfo.ShowErrorIcon = True

                    End If

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndDate.ToString Then

                BaseEditViewInfo = CType(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo).ViewInfo

                MediaRFPAvailLine = DirectCast(DataGridViewAvailLines_AvailLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine)

                If String.IsNullOrWhiteSpace(MediaRFPAvailLine.Item(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndDate.ToString)) Then

                    If MediaRFPAvailLine.EndDate.HasValue AndAlso MediaRFPAvailLine.EndDate.Value > MediaRFPAvailLine.MediaBroadcastWorksheetEndDate Then

                        BaseEditViewInfo.ErrorIconText = "Data after " & MediaRFPAvailLine.MediaBroadcastWorksheetEndDate.ToShortDateString & " will be truncated"
                        BaseEditViewInfo.ErrorIcon = DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider.GetErrorIconInternal(DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
                        BaseEditViewInfo.ShowErrorIcon = True

                    ElseIf MediaRFPAvailLine.HasDetailDatesAfterEndDate Then

                        BaseEditViewInfo.ErrorIconText = "Detail dates exist that fall after end date."
                        BaseEditViewInfo.ErrorIcon = DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider.GetErrorIconInternal(DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
                        BaseEditViewInfo.ShowErrorIcon = True

                    End If

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.DaypartID.ToString Then

                BaseEditViewInfo = CType(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo).ViewInfo

                MediaRFPAvailLine = DirectCast(DataGridViewAvailLines_AvailLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine)

                If Not MediaRFPAvailLine.DaypartID.HasValue Then

                    BaseEditViewInfo.ErrorIconText = "Map Daypart codes in Manage or select from drop down"
                    BaseEditViewInfo.ErrorIcon = DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider.GetErrorIconInternal(DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
                    BaseEditViewInfo.ShowErrorIcon = True

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.MediaDemoID.ToString Then

                BaseEditViewInfo = CType(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo).ViewInfo

                If _ViewModel.MediaRFPDemos.Any(Function(D) D.MediaDemoID Is Nothing) Then

                    BaseEditViewInfo.ErrorIconText = "One or more demographics on the Demos tab is not mapped and may prevent ratings and/or impressions being added to the worksheet."
                    BaseEditViewInfo.ErrorIcon = DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider.GetErrorIconInternal(DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
                    BaseEditViewInfo.ShowErrorIcon = True

                End If

            End If

        End Sub
        Private Sub DataGridViewAvailLines_AvailLines_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewAvailLines_AvailLines.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.Status.ToString AndAlso DirectCast(DataGridViewAvailLines_AvailLines.CurrentView.GetRow(DataGridViewAvailLines_AvailLines.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).HasError Then

                OverrideDefaultDatasource = True

                Datasource = _Controller.GetRepositoryStatusList()

            ElseIf FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString Then

                OverrideDefaultDatasource = True

                Datasource = _Controller.GetRepositoryComscoreTVStationCallLetters(_ViewModel)

            End If

        End Sub
        Private Sub DataGridViewAvailLines_AvailLines_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewAvailLines_AvailLines.RepositoryDataSourceLoadingEvent

            If FieldName = DTO.Media.RFP.MediaRFPAvailLine.Properties.Status.ToString Then

                Datasource = _ViewModel.RepositoryStatusList

            ElseIf FieldName = DTO.Media.RFP.MediaRFPAvailLine.Properties.DaypartID.ToString Then

                Datasource = _ViewModel.RepositoryDaypartList

            ElseIf FieldName = DTO.Media.RFP.MediaRFPAvailLine.Properties.MediaDemoID.ToString Then

                Datasource = _ViewModel.RepositoryMediaDemographicList.OrderBy(Function(DL) DL.Description).ToList

            ElseIf FieldName = DTO.Media.RFP.MediaRFPAvailLine.Properties.CableNetworkStationCode.ToString Then

                Datasource = _ViewModel.RepositoryCableNetworkStations

            ElseIf FieldName = DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString Then

                Datasource = _ViewModel.RepositoryCableNetworkStations

            End If

        End Sub
        Private Sub DataGridViewAvailLines_AvailLines_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewAvailLines_AvailLines.ShowingEditorEvent

            'objects
            Dim MediaRFPAvailLine As AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine = Nothing

            If DataGridViewAvailLines_AvailLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.Status.ToString Then

                MediaRFPAvailLine = DirectCast(DataGridViewAvailLines_AvailLines.CurrentView.GetRow(DataGridViewAvailLines_AvailLines.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine)

                If MediaRFPAvailLine.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.T.ToString AndAlso MediaRFPAvailLine.MediaBroadcastWorksheetMarketDetailID.HasValue Then

                    e.Cancel = True

                End If

            ElseIf Not (DataGridViewAvailLines_AvailLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.DaypartID.ToString OrElse
                    DataGridViewAvailLines_AvailLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartDate.ToString OrElse
                    DataGridViewAvailLines_AvailLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndDate.ToString OrElse
                    DataGridViewAvailLines_AvailLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewAvailLines_AvailLines_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewAvailLines_AvailLines.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.MediaRFPAvailLineValidateEntity(e.Row, e.Valid)

                If DataGridViewAvailLines_AvailLines.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                End If

            End If

        End Sub
        Private Sub DataGridViewAvailLines_AvailLines_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewAvailLines_AvailLines.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewAvailLines_AvailLines.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.MediaRFPAvailLineValidateEntityProperty(FocusedRow, DataGridViewAvailLines_AvailLines.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewAvailLines_AvailLines.CurrentView.SetColumnError(DataGridViewAvailLines_AvailLines.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewDemos_Demos_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDemos_Demos.CellValueChangedEvent

            If e.Value IsNot Nothing Then

                _Controller.SetSelectedDemoModified(_ViewModel, DirectCast(DataGridViewDemos_Demos.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPDemo))

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub DataGridViewDemos_Demos_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewDemos_Demos.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPDemo.Properties.MediaDemoID.ToString Then

                Datasource = _Controller.GetValidWorksheetDemographics(DirectCast(DataGridViewDemos_Demos.CurrentView.GetRow(DataGridViewDemos_Demos.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPDemo).MediaRFPHeaderID)

                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewDemos_Demos_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewDemos_Demos.RepositoryDataSourceLoadingEvent

            If FieldName = DTO.Media.RFP.MediaRFPDemo.Properties.MediaDemoID.ToString Then

                Datasource = _ViewModel.RepositoryMediaDemographicList.OrderBy(Function(DL) DL.Description).ToList

            End If

        End Sub
        Private Sub DataGridViewDemos_Demos_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewDemos_Demos.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.MediaRFPDemoValidateEntity(e.Row, e.Valid)

                If DataGridViewDemos_Demos.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                End If

            End If

        End Sub
        Private Sub DataGridViewDemos_Demos_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewDemos_Demos.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewDemos_Demos.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.MediaRFPDemoValidateEntityProperty(FocusedRow, DataGridViewDemos_Demos.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewDemos_Demos.CurrentView.SetColumnError(DataGridViewDemos_Demos.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewVendors_Vendors.CellValueChangedEvent

            _Controller.SetSelectedMediaRFPHeaderModified(_ViewModel, DirectCast(DataGridViewVendors_Vendors.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPHeader))

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewVendors_Vendors_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewVendors_Vendors.SelectionChangedEvent

            If DataGridViewVendors_Vendors.HasOnlyOneSelectedRow Then

                _Controller.SetSelectedMediaRFPHeader(_ViewModel, DirectCast(DataGridViewVendors_Vendors.GetRowDataBoundItem(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPHeader))

            Else

                _Controller.ClearSelectedMediaRFPHeader(_ViewModel)

            End If

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewVendors_Vendors_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewVendors_Vendors.ShowingEditorEvent

            If Not (DataGridViewVendors_Vendors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPHeader.Properties.CommentToVendor.ToString OrElse
                    DataGridViewVendors_Vendors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPHeader.Properties.DueDate.ToString OrElse
                    DataGridViewVendors_Vendors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPHeader.Properties.TimeDue.ToString OrElse
                    DataGridViewVendors_Vendors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPHeader.Properties.RequestDate.ToString) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TabControlPanel_Tabs_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlPanel_Tabs.SelectedTabChanged

            If Me.FormShown Then

                If e.NewTab.Equals(TabItemTabs_AvailLines) Then

                    LoadAvailLines()

                ElseIf e.NewTab.Equals(TabItemTabs_Demos) Then

                    LoadDemos()

                ElseIf e.NewTab.Equals(TabItemTabs_Status) Then

                    LoadHeaderStatuses()

                ElseIf e.NewTab.Equals(TabItemTabs_Markets) Then

                    LoadMarkets()

                End If

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub TabControlPanel_Tabs_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlPanel_Tabs.SelectedTabChanging

            If Me.FormShown Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub ButtonItemActions_Default_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Default.Click

            If Not RichEditGuidelines_Guidelines.Text.Equals(_Controller.LoadGuidelines(_ViewModel)) Then

                RichEditGuidelines_Guidelines.HtmlText = _Controller.LoadGuidelines(_ViewModel)
                RichEditGuidelines_Guidelines.Tag = True
                ButtonItemActions_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemTemplates_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemTemplates_Edit.Click

            AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ImportMediaRFPTemplate, False, False, AllowMultiSelect:=False)

        End Sub
        Private Sub ButtonItemView_Responses_Click(sender As Object, e As EventArgs) Handles ButtonItemView_Responses.Click

            AdvantageFramework.Media.Presentation.MediaRequestForProposalResponseDialog.ShowFormDialog(_ViewModel.MediaRFPHeaders.Where(Function(Entity) Entity.AlertID.HasValue).ToList)

        End Sub
        Private Sub RichEditGuidelines_Guidelines_TextChangedEvent(sender As Object, e As EventArgs) Handles RichEditGuidelines_Guidelines.TextChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso Me.TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines) AndAlso
                    DirectCast(sender, DevExpress.XtraRichEdit.RichEditControl).Modified Then

                RichEditGuidelines_Guidelines.Tag = True

                ButtonItemActions_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemActions_AutoFill_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AutoFill.Click

            'objects
            Dim SelectedItems As IEnumerable = Nothing
            Dim ModifiedDictonary As Generic.Dictionary(Of Integer, Object) = Nothing

            If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors) Then

                DataGridViewVendors_Vendors.CurrentView.CloseEditorForUpdating()

                SelectedItems = DataGridViewVendors_Vendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeader).ToList

                ModifiedDictonary = DataGridViewVendors_Vendors.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                If AdvantageFramework.WinForm.Presentation.AutoFillDialog.ShowFormDialog(SelectedItems) = Windows.Forms.DialogResult.OK Then

                    For Each KeyValuePair In ModifiedDictonary

                        DirectCast(KeyValuePair.Value, AdvantageFramework.DTO.Media.RFP.MediaRFPHeader).Modified = True

                    Next

                End If

                RefreshViewModel(True)

            End If

        End Sub
        Private Sub DataGridViewMarkets_Markets_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewMarkets_Markets.CellValueChangedEvent

            If e.Value IsNot Nothing Then

                _Controller.SetSelectedMarketModified(_ViewModel, DirectCast(DataGridViewMarkets_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPMarket))

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub DataGridViewMarkets_Markets_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewMarkets_Markets.QueryPopupNeedDatasourceEvent

            'If FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPMarket.Properties.MarketCode.ToString Then

            '    Datasource = _Controller.GetValidWorksheetDemographics(DirectCast(DataGridViewMarkets_Markets.CurrentView.GetRow(DataGridViewMarkets_Markets.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPMarket).MediaRFPHeaderID)

            '    OverrideDefaultDatasource = True

            'End If

        End Sub
        Private Sub DataGridViewMarkets_Markets_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewMarkets_Markets.RepositoryDataSourceLoadingEvent

            If FieldName = DTO.Media.RFP.MediaRFPMarket.Properties.MarketCode.ToString Then

                Datasource = _ViewModel.RepositoryMarketList.OrderBy(Function(Entity) Entity.Code).ToList

            End If

        End Sub
        Private Sub DataGridViewMarkets_Markets_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewMarkets_Markets.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.MediaRFPMarketValidateEntity(e.Row, e.Valid)

                If DataGridViewMarkets_Markets.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                End If

            End If

        End Sub
        Private Sub DataGridViewMarkets_Markets_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewMarkets_Markets.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.RFP.MediaRFPMarket = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewMarkets_Markets.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.MediaRFPMarketValidateEntityProperty(FocusedRow, DataGridViewMarkets_Markets.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewMarkets_Markets.CurrentView.SetColumnError(DataGridViewMarkets_Markets.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
