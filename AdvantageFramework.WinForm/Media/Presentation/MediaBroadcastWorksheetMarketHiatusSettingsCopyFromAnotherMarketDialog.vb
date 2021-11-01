Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByRef MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel,
                        ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _ViewModel = MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel
            _MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetMarketDetailsViewModel

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Markets.DataSource = _ViewModel.WorksheetMarkets

        End Sub
        Private Sub FormatGrid()

            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.OrderStatus.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedByUserCode.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedDate.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.Length.ToString)

            If _ViewModel.Worksheet IsNot Nothing Then

                If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)

                    AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                    AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                    AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)

                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)

                ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                    If Me.Session.IsNielsenSetup Then

                        DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)

                    Else

                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)

                    End If

                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)

                    AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                    AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                    AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)

                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)

                End If

                DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedByUserCode.ToString)
                DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedDate.ToString)

            End If

            FormatGrid_WorksheetMarketsOneTimeOnly()

        End Sub
        Private Sub FormatGrid_WorksheetMarketsOneTimeOnly()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
            DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketDescription.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

            If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing
                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                SubItemGridLookUpEditControl.DataSource = _Controller.MarketHiatusSettingsCopyFromAnotherMarket_GetRepositoryMarketTVGeography(_ViewModel)

                DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing
                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                SubItemGridLookUpEditControl.DataSource = _Controller.MarketHiatusSettingsCopyFromAnotherMarket_GetRepositoryExternalRadioSource(_ViewModel)

                DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                SubItemGridLookUpEditControl.DataSource = _Controller.MarketHiatusSettingsCopyFromAnotherMarket_GetRepositoryMarketRadioGeography(_ViewModel)

                DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                SubItemGridLookUpEditControl.DataSource = _Controller.MarketHiatusSettingsCopyFromAnotherMarket_GetRepositoryMarketRadioEthnicity(_ViewModel)

                DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedByUserCode.ToString) IsNot Nothing Then

                DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedByUserCode.ToString).Caption = "Modified By"

            End If

        End Sub
        Private Sub RemoveColumnFromGridFunctions(ColumnFieldName As String)

            If DataGridViewForm_Markets.Columns(ColumnFieldName) IsNot Nothing Then

                DataGridViewForm_Markets.Columns(ColumnFieldName).OptionsColumn.ShowInCustomizationForm = False
                DataGridViewForm_Markets.Columns(ColumnFieldName).OptionsColumn.ShowInExpressionEditor = False
                DataGridViewForm_Markets.Columns(ColumnFieldName).OptionsColumn.AllowShowHide = False

            End If

        End Sub
        Private Sub AddColumnToGridFunctions(ColumnFieldName As String)

            If DataGridViewForm_Markets.Columns(ColumnFieldName) IsNot Nothing Then

                DataGridViewForm_Markets.Columns(ColumnFieldName).OptionsColumn.ShowInCustomizationForm = True
                DataGridViewForm_Markets.Columns(ColumnFieldName).OptionsColumn.ShowInExpressionEditor = True
                DataGridViewForm_Markets.Columns(ColumnFieldName).OptionsColumn.AllowShowHide = True

            End If

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Copy.Enabled = _ViewModel.CopyEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_Markets.OptionsBehavior.Editable = False

            DataGridViewForm_Markets.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_Markets.OptionsSelection.MultiSelect = False

            DataGridViewForm_Markets.ShowSelectDeselectAllButtons = False
            DataGridViewForm_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = False
            DataGridViewForm_Markets.FocusToFindPanel(False)

            DataGridViewForm_Markets.ItemDescription = "Market Schedule(s)"
            DataGridViewForm_Markets.ModifyColumnSettingsOnEachDataSource = False

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel,
                                              ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketDialog As MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketDialog = Nothing

            MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketDialog = New MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketDialog(MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel, MediaBroadcastWorksheetMarketDetailsViewModel)

            ShowFormDialog = MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadGrid()

            FormatGrid()

            RefreshViewModel()

            Me.ClearChanged()

            DataGridViewForm_Markets.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Copying Hiatus settings will delete all data in those ranges." & vbNewLine & vbNewLine & "Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Markets_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_Markets.FocusedRowChangedEvent

            _Controller.MarketHiatusSettingsCopyFromAnotherMarket_WorksheetMarketSelectionChanged(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRow)

            RefreshViewModel()

        End Sub
        Private Sub DataGridViewForm_Markets_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Markets.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox = Nothing
            Dim ImageCollection As DevExpress.Utils.ImageCollection = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString Then

                RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

                ImageCollection = New DevExpress.Utils.ImageCollection

                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallRedCircleImage)
                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueSemiCircleImage)
                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueCircleImage)
                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallPinkCircleImage)

                RepositoryItemImageComboBox.SmallImages = ImageCollection

                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered, 0))
                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial, 1))
                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered, 2))
                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified, 3))

                RepositoryItemImageComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center

                e.RepositoryItem = RepositoryItemImageComboBox

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace