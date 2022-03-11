Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketEditViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.MarketEdit_Load(_MediaBroadcastWorksheetID)

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            DataGridViewForm_Markets.DataSource = _ViewModel.WorksheetMarkets

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
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.Length.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodStart.ToString)
            DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodEnd.ToString)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

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

                    SubItemGridLookUpEditControl.DataSource = _Controller.MarketEdit_GetRepositoryMarketTVGeography(_ViewModel, String.Empty)

                    AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControlTVGeography_QueryPopup
                    AddHandler SubItemGridLookUpEditControl.EditValueChanging, AddressOf DataGridViewForm_Markets_SubItemGridLookUpEditControlEditValueChanging

                    DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                    DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString).ColumnEdit = SubItemGridLookUpEditControl

                End If

                If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString) IsNot Nothing Then

                    RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                    RepositoryItemCheckEdit.AllowGrayed = False

                    AddHandler RepositoryItemCheckEdit.EditValueChanging, AddressOf RepositoryItemIsCable_EditValueChanging

                    DataGridViewForm_Markets.GridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

                    DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString).ColumnEdit = RepositoryItemCheckEdit

                End If

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

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

                    SubItemGridLookUpEditControl.DataSource = _Controller.MarketEdit_GetRepositoryExternalRadioSource(_ViewModel, String.Empty)

                    AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControlExternalRadioSource_QueryPopup
                    AddHandler SubItemGridLookUpEditControl.EditValueChanging, AddressOf DataGridViewForm_Markets_SubItemGridLookUpEditControlEditValueChanging

                    DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                    DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString).ColumnEdit = SubItemGridLookUpEditControl

                End If

                If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString) IsNot Nothing Then

                    SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                    SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                    SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing
                    SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                    SubItemGridLookUpEditControl.NullText = ""
                    SubItemGridLookUpEditControl.DisplayMember = "Name"
                    SubItemGridLookUpEditControl.ValueMember = "Value"

                    SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                    SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    SubItemGridLookUpEditControl.DataSource = _Controller.MarketEdit_GetRepositoryMarketRadioGeography(_ViewModel, AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen)

                    AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControlRadioGeography_QueryPopup
                    AddHandler SubItemGridLookUpEditControl.EditValueChanging, AddressOf DataGridViewForm_Markets_SubItemGridLookUpEditControlEditValueChanging

                    DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                    DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString).ColumnEdit = SubItemGridLookUpEditControl

                End If

                If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString) IsNot Nothing Then

                    SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                    SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                    SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing
                    SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                    SubItemGridLookUpEditControl.NullText = ""
                    SubItemGridLookUpEditControl.DisplayMember = "Name"
                    SubItemGridLookUpEditControl.ValueMember = "Value"

                    SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                    SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    SubItemGridLookUpEditControl.DataSource = _Controller.MarketEdit_GetRepositoryMarketRadioEthnicity(_ViewModel, AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen)

                    AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControlRadioEthnicity_QueryPopup
                    AddHandler SubItemGridLookUpEditControl.CustomDisplayText, AddressOf SubItemGridLookUpEditControlRadioEthnicity_CustomDisplayText
                    AddHandler SubItemGridLookUpEditControl.EditValueChanging, AddressOf DataGridViewForm_Markets_SubItemGridLookUpEditControlEditValueChanging

                    DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                    DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString).ColumnEdit = SubItemGridLookUpEditControl

                End If

            End If

            If _ViewModel.Worksheet.IsCanadianWorksheet Then

                'DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            Else

                If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodStart.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodEnd.ToString)

                    If _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico Then

                        DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                        DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                        DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                        DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
                        DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodStart.ToString)
                        DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodEnd.ToString)

                    End If

                ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodStart.ToString)
                    DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodEnd.ToString)

                    If Me.Session.IsNielsenSetup Then

                        DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)

                    Else

                        DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)

                    End If

                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
                    DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)

                    'ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.NetworkTV Then

                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
                    '	DataGridViewForm_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)

                End If

                DataGridViewForm_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.Length.ToString)

            End If

        End Sub
        Private Sub AddNewRow(WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)

            Dim ErrorMessage As String = Nothing

            If WorksheetMarket IsNot Nothing Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                If _Controller.MarketEdit_Add(_ViewModel, WorksheetMarket, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewForm_Markets.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewForm_Markets.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel(True)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_Markets.CurrentView.RefreshData()

            End If

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

            ButtonItemMediaPlan_LoadMarkets.Enabled = _ViewModel.MediaPlan_LoadMarketsEnabled

            ButtonItemBooks_Add.Enabled = _ViewModel.Books_AddEnabled
            ButtonItemBooks_CopyTo.Enabled = _ViewModel.Books_CopyToEnabled

            ButtonItemSubmarkets_Manage.Enabled = (_ViewModel.SelectedWorksheetMarket IsNot Nothing)

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            DataGridViewForm_Markets.SetupForEditableGrid()

            DataGridViewForm_Markets.GridControl.ToolTipController = Me.ToolTipController

        End Sub
        Protected Sub SubItemGridLookUpEditControlTVGeography_QueryPopup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim DataSource As Object = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If TypeOf DataGridViewForm_Markets.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_Markets.CurrentView.ActiveEditor

                DataSource = _Controller.MarketEdit_GetRepositoryMarketTVGeography(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString))

                Try

                    DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(DataSource)

                Catch ex As Exception
                    DataSource = Nothing
                End Try

                If DataSource IsNot Nothing Then

                    BindingSource = New System.Windows.Forms.BindingSource

                    BindingSource.DataSource = DataSource

                    GridLookUpEdit.Properties.DataSource = BindingSource

                End If

            End If

        End Sub
        Protected Sub SubItemGridLookUpEditControlRadioEthnicity_QueryPopup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim DataSource As Object = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If TypeOf DataGridViewForm_Markets.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_Markets.CurrentView.ActiveEditor

                DataSource = _Controller.MarketEdit_GetRepositoryMarketRadioEthnicity(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString))

                Try

                    DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(DataSource)

                Catch ex As Exception
                    DataSource = Nothing
                End Try

                If DataSource IsNot Nothing Then

                    BindingSource = New System.Windows.Forms.BindingSource

                    BindingSource.DataSource = DataSource

                    GridLookUpEdit.Properties.DataSource = BindingSource

                End If

            End If

        End Sub
        Protected Sub SubItemGridLookUpEditControlRadioGeography_QueryPopup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim DataSource As Object = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If TypeOf DataGridViewForm_Markets.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_Markets.CurrentView.ActiveEditor

                DataSource = _Controller.MarketEdit_GetRepositoryMarketRadioGeography(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString))

                Try

                    DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(DataSource)

                Catch ex As Exception
                    DataSource = Nothing
                End Try

                If DataSource IsNot Nothing Then

                    BindingSource = New System.Windows.Forms.BindingSource

                    BindingSource.DataSource = DataSource

                    GridLookUpEdit.Properties.DataSource = BindingSource

                End If

            End If

        End Sub
        Protected Sub SubItemGridLookUpEditControlExternalRadioSource_QueryPopup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim DataSource As Object = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If TypeOf DataGridViewForm_Markets.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_Markets.CurrentView.ActiveEditor

                DataSource = _Controller.MarketEdit_GetRepositoryExternalRadioSource(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString))

                Try

                    DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(DataSource)

                Catch ex As Exception
                    DataSource = Nothing
                End Try

                If DataSource IsNot Nothing Then

                    BindingSource = New System.Windows.Forms.BindingSource

                    BindingSource.DataSource = DataSource

                    GridLookUpEdit.Properties.DataSource = BindingSource

                End If

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControlRadioEthnicity_CustomDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs)

            If e.Value = 0 Then

                e.DisplayText = String.Empty

            Else

                e.DisplayText = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RadioEthnicities), CInt(e.Value))

            End If

        End Sub
        Private Sub RepositoryItemIsCable_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            If e.NewValue = False Then

                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).MediaBroadcastWorksheetMarketTVGeographyID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies.DMA

                DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle, DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString))

            End If

        End Sub
        Private Sub FormatGrid()

            'If _ViewModel.Worksheet.IsCanadianWorksheet Then

            '    DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            'Else

            DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

            'End If

        End Sub
        Private Sub FormatRibbon()

            If _ViewModel.Worksheet.IsCanadianWorksheet Then

                RibbonBarFile_MediaPlan.Visible = False
                RibbonBarFile_Books.Visible = False
                RibbonBarFile_Submarkets.Visible = _ViewModel.DoesWorksheetAllowSubmarkets

            Else

                RibbonBarFile_MediaPlan.Visible = True
                RibbonBarFile_Books.Visible = True
                RibbonBarFile_Submarkets.Visible = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketEditDialog As MediaBroadcastWorksheetMarketEditDialog = Nothing

            MediaBroadcastWorksheetMarketEditDialog = New MediaBroadcastWorksheetMarketEditDialog(MediaBroadcastWorksheetID)

            ShowFormDialog = MediaBroadcastWorksheetMarketEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketEditDialog_BeforeFormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.BeforeFormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing AndAlso Me.UserEntryChanged = False AndAlso _ViewModel IsNot Nothing AndAlso _ViewModel.HasMarketsModified Then

                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemMediaPlan_LoadMarkets.Image = AdvantageFramework.My.Resources.HideFieldImage

            ButtonItemBooks_Add.Image = AdvantageFramework.My.Resources.NielsenBookImage
            ButtonItemBooks_CopyTo.Image = AdvantageFramework.My.Resources.NielsenBookCopyToImage

            ButtonItemSubmarkets_Manage.Image = AdvantageFramework.My.Resources.QuickManageImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            FormatGrid()

            FormatRibbon()

            RefreshViewModel(False)

            RibbonBarFilePanel_Actions.ResetCachedContentSize()

            RibbonBarFilePanel_Actions.Refresh()

            RibbonBarFilePanel_Actions.Width = RibbonBarFilePanel_Actions.GetAutoSizeWidth

            RibbonBarFilePanel_Actions.Refresh()

            Me.ClearChanged()

            DataGridViewForm_Markets.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.MarketEdit_ClearChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketEditDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.MarketEdit_UserEntryChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            If DataGridViewForm_Markets.HasASelectedRow Then

                DataGridViewForm_Markets.CurrentView.CloseEditorForUpdating()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                _Controller.MarketEdit_Save(_ViewModel)

                DataGridViewForm_Markets.ValidateAllRowsAndClearChanged(True)

                RefreshViewModel(True)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                _Controller.MarketEdit_MarketSelectionChanged(_ViewModel, DataGridViewForm_Markets.IsNewItemRow, DataGridViewForm_Markets.GetFirstSelectedRowDataBoundItem)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim ContinueDelete As Boolean = False

            If DataGridViewForm_Markets.HasASelectedRow Then

                DataGridViewForm_Markets.CurrentView.CloseEditorForUpdating()

                If _Controller.MarketEdit_HasMediaRFPAvailLines(_ViewModel) Then

                    If AdvantageFramework.WinForm.MessageBox.Show("There are avails attached to the market!  Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        ContinueDelete = True

                    End If

                ElseIf AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    ContinueDelete = True

                End If

                If ContinueDelete Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If _Controller.MarketEdit_Delete(_ViewModel, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    RefreshViewModel(True)

                    _Controller.MarketEdit_MarketSelectionChanged(_ViewModel, DataGridViewForm_Markets.IsNewItemRow, DataGridViewForm_Markets.GetFirstSelectedRowDataBoundItem)

                    RefreshViewModel(False)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Markets.CancelNewItemRow()

            _Controller.MarketEdit_CancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemSystem_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemMediaPlan_LoadMarkets_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaPlan_LoadMarkets.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty

            DataGridViewForm_Markets.CurrentView.CloseEditorForUpdating()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketEdit_Save(_ViewModel)

                        DataGridViewForm_Markets.ValidateAllRowsAndClearChanged(True)

                        RefreshViewModel(True)

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    _Controller.MarketEdit_LoadMarketsFromMediaPlan(_ViewModel, ErrorMessage)

                    RefreshViewModel(True)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemBooks_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemBooks_Add.Click

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                Media.Presentation.MediaBroadcastWorksheetMarketNielsenTVBooksDialog.ShowFormDialog(_ViewModel.MediaBroadcastWorksheetID, _ViewModel.SelectedWorksheetMarket.ID)

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                Media.Presentation.MediaBroadcastWorksheetMarketNielsenRadioPeriodsDialog.ShowFormDialog(_ViewModel.MediaBroadcastWorksheetID, _ViewModel.SelectedWorksheetMarket.ID)

            End If

        End Sub
        Private Sub ButtonItemBooks_CopyTo_Click(sender As Object, e As EventArgs) Handles ButtonItemBooks_CopyTo.Click

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                Media.Presentation.MediaBroadcastWorksheetMarketNielsenTVBooksCopyToDialog.ShowFormDialog(_ViewModel.MediaBroadcastWorksheetID, _ViewModel.SelectedWorksheetMarket.ID)

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                Media.Presentation.MediaBroadcastWorksheetMarketNielsenRadioPeriodsCopyToDialog.ShowFormDialog(_ViewModel.MediaBroadcastWorksheetID, _ViewModel.SelectedWorksheetMarket.ID)

            End If

        End Sub
        Private Sub ButtonItemSubmarkets_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemSubmarkets_Manage.Click

            AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketSubmarketsDialog.ShowFormDialog(_ViewModel.SelectedWorksheetMarket.ID)

        End Sub
        Private Sub DataGridViewForm_Markets_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Markets.CellValueChangedEvent

            'objects
            Dim ExternalRadioSource As AdvantageFramework.Nielsen.Database.Entities.RadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString Then

                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).MarketDescription = _Controller.MarketEdit_GetRepositoryMarketDescription(_ViewModel, e.Value)

                _Controller.MarketEdit_LoadMarketNielsenData(_ViewModel, e.Value, DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle))

                If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                    If _Controller.MarketEdit_CheckForMarketCode(_ViewModel, e.Value) Then

                        If _Controller.MarketEdit_CheckForMarketCodeAndCable(_ViewModel, e.Value, True) Then

                            DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).IsCable = False

                        Else

                            DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).IsCable = True

                        End If

                    End If

                    If _ViewModel.Worksheet.DefaultToLatestSharebook Then

                        DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).SharebookNielsenTVBookID = _Controller.MarketEdit_GetRepositoryDefaultShareBook(_ViewModel, e.Value,
                                                                                                                                                                                                                                                   DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).IsCable,
                                                                                                                                                                                                                                                   AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies.DMA)

                    Else

                        DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).SharebookNielsenTVBookID = Nothing

                    End If

                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).HUTPUTNielsenTVBookID = Nothing

                ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).MediaBroadcastWorksheetMarketRadioGeographyID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RadioGeographies.Metro
                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).MediaBroadcastWorksheetMarketRadioEthnicityID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RadioEthnicities.All

                    ExternalRadioSource = _Controller.MarketEdit_GetRepositoryExternalRadioSource(_ViewModel, DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).MarketCode).Rows(0)(1)

                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).ExternalRadioSource = ExternalRadioSource

                    _Controller.MarketEdit_SelectNielsenRadioMarket(_ViewModel, DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).MarketCode, AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen)

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.BuyerEmployeeCode.ToString Then

                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).BuyerEmployeeName = _Controller.MarketEdit_GetRepositoryBuyerEmployeeName(_ViewModel, e.Value)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString Then

                _Controller.MarketEdit_SharebookChanged(_ViewModel, e.Value, DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket))

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString Then

                If e.Value = False Then

                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).MediaBroadcastWorksheetMarketTVGeographyID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies.DMA

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString Then

                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).SharebookNielsenTVBookID = Nothing
                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).HUTPUTNielsenTVBookID = Nothing

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString Then

                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID1 = Nothing
                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID2 = Nothing
                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID3 = Nothing
                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID4 = Nothing
                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID5 = Nothing

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString Then

                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID1 = Nothing
                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID2 = Nothing
                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID3 = Nothing
                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID4 = Nothing
                DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID5 = Nothing

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString Then

                If e.Value = 0 OrElse e.Value = Nothing Then

                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID2 = Nothing
                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID3 = Nothing
                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID4 = Nothing
                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID5 = Nothing

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString Then

                If e.Value = 0 OrElse e.Value = Nothing Then

                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID3 = Nothing
                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID4 = Nothing
                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID5 = Nothing

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString Then

                If e.Value = 0 OrElse e.Value = Nothing Then

                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID4 = Nothing
                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID5 = Nothing

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString Then

                If e.Value = 0 OrElse e.Value = Nothing Then

                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID5 = Nothing

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_Markets.FocusedRowChangedEvent

            _Controller.MarketEdit_MarketSelectionChanged(_ViewModel, DataGridViewForm_Markets.IsNewItemRow, DataGridViewForm_Markets.CurrentView.GetFocusedRow)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_Markets_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Markets.InitNewRowEvent

            'objects
            Dim WorksheetSecondaryDemo As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo = Nothing
            Dim SetBuyer As Boolean = False

            _Controller.MarketEdit_InitNewRowEvent(_ViewModel)

            DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetID.ToString, _MediaBroadcastWorksheetID)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                If _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                    DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies.DMA)

                ElseIf _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                    DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies.DMA)

                ElseIf _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico AndAlso _ViewModel.Worksheet.NPRPrepopulateDates Then

                    DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).PeriodEnd = _Controller.MarketEdit_GetRepositoryPeriodEnd()

                    If DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).PeriodEnd.HasValue Then

                        DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).PeriodStart = DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).PeriodEnd.Value.AddDays(-27)

                    End If

                End If

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RadioGeographies.Metro)
                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RadioEthnicities.All)

            End If

            DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.CreatedByUserCode.ToString, Me.Session.UserCode)
            DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.CreatedDate.ToString, Now)
            DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.Length.ToString, _ViewModel.Worksheet.Length)

            If _ViewModel.WorksheetSecondaryDemos IsNot Nothing AndAlso _ViewModel.WorksheetSecondaryDemos.Count = 1 Then

                WorksheetSecondaryDemo = _ViewModel.WorksheetSecondaryDemos.FirstOrDefault

                If WorksheetSecondaryDemo IsNot Nothing Then

                    DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SecondaryMediaDemographicID.ToString, WorksheetSecondaryDemo.MediaDemographicID)

                End If

            End If

            If _ViewModel.AutoPlaceBuyerOnMarket Then

                If DataGridViewForm_Markets.CurrentView.FocusedColumn Is Nothing Then

                    SetBuyer = True

                Else

                    If DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.BuyerEmployeeCode.ToString Then

                        SetBuyer = (DataGridViewForm_Markets.CurrentView.ActiveEditor IsNot Nothing AndAlso DataGridViewForm_Markets.CurrentView.ActiveEditor.EditValue <> Me.Session.User.EmployeeCode)

                    Else

                        SetBuyer = (DataGridViewForm_Markets.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.BuyerEmployeeCode.ToString) Is Nothing)

                    End If

                End If

                If SetBuyer Then

                    DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.BuyerEmployeeCode.ToString, Me.Session.User.EmployeeCode)

                End If

            End If

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_Markets_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_Markets.QueryPopupNeedDatasourceEvent

            'objects
            Dim ExcludeNielsenRadioPeriodIDs As Generic.List(Of Integer) = Nothing
            Dim Ethnicity As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RadioEthnicities = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RadioEthnicities.All

            If FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString Then

                Datasource = _Controller.MarketEdit_GetRepositoryMarkets(_ViewModel)
                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.BuyerEmployeeCode.ToString Then

                Datasource = (From BuyerEmployee In _ViewModel.BuyerEmployees
                              Select New With {.Code = BuyerEmployee.Code,
                                               .Name = BuyerEmployee.Name})

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString Then

                Datasource = _Controller.MarketEdit_GetRepositorySharebooks(_ViewModel,
                                                                            DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString),
                                                                            DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString),
                                                                            DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString))

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString Then

                Datasource = _Controller.MarketEdit_GetRepositoryHUTPUTBooks(_ViewModel,
                                                                             DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString),
                                                                             DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString),
                                                                             DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString),
                                                                             DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString))

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString Then

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString))

                Datasource = _Controller.MarketEdit_GetRepositoryNielsenRadioPeriods(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString),
                                                                                     ExcludeNielsenRadioPeriodIDs)

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString Then

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString))

                Datasource = _Controller.MarketEdit_GetRepositoryNielsenRadioPeriods(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString),
                                                                                     ExcludeNielsenRadioPeriodIDs)

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString Then

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString))

                Datasource = _Controller.MarketEdit_GetRepositoryNielsenRadioPeriods(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString),
                                                                                     ExcludeNielsenRadioPeriodIDs)

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString Then

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString))

                Datasource = _Controller.MarketEdit_GetRepositoryNielsenRadioPeriods(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString),
                                                                                     ExcludeNielsenRadioPeriodIDs)

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString Then

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString))

                Datasource = _Controller.MarketEdit_GetRepositoryNielsenRadioPeriods(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString),
                                                                                     DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString),
                                                                                     ExcludeNielsenRadioPeriodIDs)

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Markets.ShowingEditorEvent

            If DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ID.ToString OrElse
                    DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.LockedByUserCode.ToString Then

                e.Cancel = True

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString Then

                e.Cancel = (DataGridViewForm_Markets.IsNewItemRow = False)

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString Then

                e.Cancel = (_Controller.MarketEdit_CheckForMarketCode(_ViewModel, DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString)))

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString Then

                e.Cancel = (DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString) = False)

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString Then

                If _ViewModel.SelectedNielsenRadioMarket IsNot Nothing Then

                    If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString) = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                        e.Cancel = (_ViewModel.SelectedNielsenRadioMarket.IsNielsenPMM = True)

                    ElseIf DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString) = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                        e.Cancel = (_ViewModel.SelectedNielsenRadioMarket.IsEastlanPMM = True)

                    Else

                        e.Cancel = True

                    End If

                Else

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString Then

                If _ViewModel.SelectedNielsenRadioMarket IsNot Nothing Then

                    If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString) = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                        e.Cancel = (_ViewModel.SelectedNielsenRadioMarket.HasNielsenBlackMarketBooks = False AndAlso _ViewModel.SelectedNielsenRadioMarket.HasNielsenHispanicMarketBooks = False)

                    ElseIf DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString) = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                        e.Cancel = (_ViewModel.SelectedNielsenRadioMarket.HasEastlanBlackMarketBooks = False AndAlso _ViewModel.SelectedNielsenRadioMarket.HasEastlanHispanicMarketBooks = False)

                    Else

                        e.Cancel = True

                    End If

                Else

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString Then

                If (_ViewModel IsNot Nothing AndAlso _ViewModel.HasPrimaryDemographic = False) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString Then

                If (_ViewModel IsNot Nothing AndAlso _ViewModel.HasPrimaryDemographic = False) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString Then

                If (_ViewModel IsNot Nothing AndAlso _ViewModel.HasPrimaryDemographic = False) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString Then

                If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString) = Nothing OrElse
                        DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString) = 0 OrElse
                        (_ViewModel IsNot Nothing AndAlso _ViewModel.HasPrimaryDemographic = False) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString Then

                If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString) = Nothing OrElse
                        DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString) = 0 OrElse
                        (_ViewModel IsNot Nothing AndAlso _ViewModel.HasPrimaryDemographic = False) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString Then

                If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString) = Nothing OrElse
                        DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString) = 0 OrElse
                        (_ViewModel IsNot Nothing AndAlso _ViewModel.HasPrimaryDemographic = False) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString Then

                If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString) = Nothing OrElse
                        DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString) = 0 OrElse
                        (_ViewModel IsNot Nothing AndAlso _ViewModel.HasPrimaryDemographic = False) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.Length.ToString Then

                If _ViewModel.SelectedWorksheetMarket IsNot Nothing AndAlso _ViewModel.SelectedWorksheetMarket.HasData Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodStart.ToString OrElse
                    DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodEnd.ToString Then

                If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString) = Nothing Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_Markets.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.MarketEdit_ValidateEntity(_ViewModel, e.Row, e.Valid)

                If DataGridViewForm_Markets.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewForm_Markets.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        'Private Sub DataGridViewForm_Markets_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_Markets.ValidatingEditorEvent

        '    'objects
        '    Dim FocusedRow As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing
        '    Dim ErrorText As String = String.Empty

        '    FocusedRow = DataGridViewForm_Markets.CurrentView.GetFocusedRow

        '    If FocusedRow IsNot Nothing Then

        '        ErrorText = _Controller.MarketEdit_ValidateProperty(FocusedRow, DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

        '        DataGridViewForm_Markets.CurrentView.SetColumnError(DataGridViewForm_Markets.CurrentView.FocusedColumn, ErrorText)

        '        e.Valid = True

        '    End If

        'End Sub
        Private Sub DataGridViewForm_Markets_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_Markets.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString Then

                Datasource = _Controller.MarketEdit_GetRepositoryTVBooks(_ViewModel)

            ElseIf FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString Then

                Datasource = _Controller.MarketEdit_GetRepositoryAllNielsenRadioPeriods(_ViewModel)

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_AlterSubItemGridLookupEditPropertiesEvent(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn,
                                                                                       ByRef SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl) Handles DataGridViewForm_Markets.AlterSubItemGridLookupEditPropertiesEvent

            If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString Then

                If SubItemGridLookUpEditControl.View.Columns("ID") IsNot Nothing Then

                    SubItemGridLookUpEditControl.View.Columns("ID").Visible = False

                End If

            ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString OrElse
                    GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString Then

                If SubItemGridLookUpEditControl.View.Columns("ID") IsNot Nothing Then

                    SubItemGridLookUpEditControl.View.Columns("ID").Visible = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_Markets.CustomColumnDisplayTextEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ID.ToString Then

                e.DisplayText = If(e.Value = 0, String.Empty, e.DisplayText)

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_SubItemGridLookUpEditControlEditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DataGridViewForm_Markets.SubItemGridLookUpEditControlEditValueChanging

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If DataGridViewForm_Markets.IsNewItemRow() = False AndAlso e.NewValue <> e.OldValue AndAlso
                    _ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.SelectedWorksheetMarket.HasData Then

                GridColumn = DataGridViewForm_Markets.CurrentView.FocusedColumn

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString Then

                    If _ViewModel.ShowWarningForChangingNielsenData Then

                        If AdvantageFramework.WinForm.MessageBox.Show("WARNING: By changing survey criteria for a market, all market schedule data will be recalculated." &
                                                                      vbNewLine & vbNewLine & "Are you sure you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                            _ViewModel.ShowWarningForChangingNielsenData = False

                        Else

                            e.Cancel = True

                        End If

                    End If

                    If _ViewModel.ShowWarningForChangingNielsenData = False Then

                        If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString Then

                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).SharebookNielsenTVBookID = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).HUTPUTNielsenTVBookID = Nothing

                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString))

                        ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString Then

                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).MediaBroadcastWorksheetMarketRadioEthnicityID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RadioEthnicities.All
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID1 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID2 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID3 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID4 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID5 = Nothing

                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString))

                        ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString Then

                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID1 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID2 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID3 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID4 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID5 = Nothing

                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString))

                        ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString Then

                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID1 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID2 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID3 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID4 = Nothing
                            DirectCast(DataGridViewForm_Markets.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket).NeilsenRadioPeriodID5 = Nothing

                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString))
                            DataGridViewForm_Markets.CurrentView.RefreshRowCell(DataGridViewForm_Markets.CurrentView.FocusedRowHandle,
                                                                                DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString))

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Markets.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.Length.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f0"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f0"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f0"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f0"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = False
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 999
                RepositoryItemSpinEdit.MaxLength = 3
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf (e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString) Then

                If TypeOf e.RepositoryItem Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl AndAlso _ViewModel IsNot Nothing AndAlso
                        (_ViewModel.HasPrimaryDemographic = False OrElse (_ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.SelectedWorksheetMarket.OrderStatus <> AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered)) Then

                    CType(e.RepositoryItem, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).Buttons(0).Visible = False
                    CType(e.RepositoryItem, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False
                    CType(e.RepositoryItem, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ReadOnly = True

                ElseIf TypeOf e.RepositoryItem Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl Then

                    CType(e.RepositoryItem, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).Buttons(0).Visible = True
                    CType(e.RepositoryItem, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True
                    CType(e.RepositoryItem, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ReadOnly = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DataGridViewForm_Markets.RowCellStyleEvent

            If _ViewModel IsNot Nothing AndAlso _ViewModel.HasPrimaryDemographic = False Then

                If (e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString) Then

                    e.Appearance.BackColor = System.Drawing.Color.Gray

                End If

            End If

        End Sub
        Private Sub ToolTipController_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim CellText As String = String.Empty

            If e.Info Is Nothing AndAlso e.SelectedControl Is DataGridViewForm_Markets.GridControl AndAlso
                    _ViewModel IsNot Nothing AndAlso _ViewModel.HasPrimaryDemographic = False Then

                GridHitInfo = DataGridViewForm_Markets.CurrentView.CalcHitInfo(e.ControlMousePosition)

                If GridHitInfo IsNot Nothing AndAlso GridHitInfo.InRowCell AndAlso
                        (GridHitInfo.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString OrElse
                         GridHitInfo.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString OrElse
                         GridHitInfo.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString OrElse
                         GridHitInfo.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString OrElse
                         GridHitInfo.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString OrElse
                         GridHitInfo.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString OrElse
                         GridHitInfo.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString) Then

                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), _ViewModel.BookTooltip)

                    e.Info = ToolTipControlInfo

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_SubItemDateInputEditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DataGridViewForm_Markets.SubItemDateInputEditValueChanging

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If DataGridViewForm_Markets.IsNewItemRow() = False AndAlso e.NewValue <> e.OldValue AndAlso
                    _ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.SelectedWorksheetMarket.HasData Then

                GridColumn = DataGridViewForm_Markets.CurrentView.FocusedColumn

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodStart.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodEnd.ToString Then

                    If _ViewModel.ShowWarningForChangingNielsenData Then

                        If AdvantageFramework.WinForm.MessageBox.Show("WARNING: By changing survey criteria for a market, all market schedule data will be recalculated." &
                                                                      vbNewLine & vbNewLine & "Are you sure you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                            _ViewModel.ShowWarningForChangingNielsenData = False

                        Else

                            e.Cancel = True

                        End If

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
