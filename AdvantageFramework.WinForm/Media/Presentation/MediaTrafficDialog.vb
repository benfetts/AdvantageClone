Namespace Media.Presentation

    Public Class MediaTrafficDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaTrafficController = Nothing
        Protected _MediaBroadcastWorksheetMarketID As Integer = 0
        Protected _ReloadGrid As Boolean = False
        Private WithEvents _GridViewVendorDetailsLevel1Tab1 As AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView = Nothing
        Private _IsLoadingRevisionNumbers As Boolean = False

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

            If _ViewModel.IsAgencyASP = False AndAlso ButtonItemDocuments_Upload.SplitButton = True Then

                ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                ButtonItemDocuments_Upload.SplitButton = False

            End If

            RichEditGuidelines_Guidelines.HtmlText = _ViewModel.TrafficGuidelines

            RibbonBarFilePanel_Creative.Visible = _ViewModel.DoesUserHaveAccessToAdNumberMaintenance

        End Sub
        Private Sub SaveViewModel()

            If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines) Then

                _ViewModel.TrafficGuidelines = RichEditGuidelines_Guidelines.HtmlBodyOnly

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Revisions) Then

                DataGridViewRevision_Revisions.CurrentView.CloseEditorForUpdating()

                DataGridViewRevision_Revisions.ValidateAllRows()

                _ViewModel.Revisions = DataGridViewRevision_Revisions.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Revision).ToList

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_CreativeGroups) Then

                DataGridViewCreativeGroup_CreativeGroups.CurrentView.CloseEditorForUpdating()

                DataGridViewCreativeGroup_CreativeGroups.ValidateAllRows()

                _ViewModel.CreativeGroups = DataGridViewCreativeGroup_CreativeGroups.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.CreativeGroup).ToList

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Details) Then

                DataGridViewDetails_Details.CurrentView.CloseEditorForUpdating()

                DataGridViewDetails_Details.ValidateAllRows()

                _ViewModel.Details = DataGridViewDetails_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Detail).ToList

            End If

        End Sub
        Private Sub ShowHideBookendColumns()

            Dim ShowBookendColumns As Boolean = False

            If _ViewModel.Details IsNot Nothing AndAlso _ViewModel.Details.Any(Function(D) D.IsBookend = True) Then

                ShowBookendColumns = True

            End If

            If DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.IsBookend.ToString) IsNot Nothing Then

                DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.IsBookend.ToString).Visible = ShowBookendColumns

            End If

            If DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.BookendName.ToString) IsNot Nothing Then

                DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.BookendName.ToString).Visible = ShowBookendColumns

            End If

            If DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Position.ToString) IsNot Nothing Then

                DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Position.ToString).Visible = ShowBookendColumns

            End If

            DataGridViewDetails_Details.CurrentView.BestFitColumns()

            If DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.CreativeTitle.ToString) IsNot Nothing Then

                DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.CreativeTitle.ToString).Width = 225

            End If

            If DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Location.ToString) IsNot Nothing Then

                DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Location.ToString).Width = 225

            End If

            If DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Comment.ToString) IsNot Nothing Then

                DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Comment.ToString).Width = 225

            End If

        End Sub
        'Private Sub LoadRevisionNumbers()

        '    'objects
        '    Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

        '    _IsLoadingRevisionNumbers = True

        '    BindingSource = New System.Windows.Forms.BindingSource

        '    BindingSource.DataSource = (From RevisionNumber In _ViewModel.SelectedRevisionRevisionNumbers
        '                                Select RevisionNumberText = Format(RevisionNumber, "000"),
        '                                       RevisionNumber = RevisionNumber).ToList

        '    ComboBoxItemRevisions_Revisions.ComboBoxEx.DataSource = BindingSource

        '    ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue = _ViewModel.SelectedRevision.RevisionNumber

        '    _IsLoadingRevisionNumbers = False

        'End Sub
        Private Sub RefreshViewModel()

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                Me.RibbonPanelFile_FilePanel.SuspendLayout()

                RibbonBarFilePanel_Documents.Visible = False
                RibbonBarFilePanel_Instruction.Visible = False
                RibbonBarFilePanel_View.Visible = False
                RibbonBarFilePanel_Revisions.Visible = False
                RibbonBarFilePanel_Actions.Visible = False

                If _ViewModel.SelectedRevision IsNot Nothing Then

                    LabelCreativeGroups_TrafficStartEndDescription.Text = "Instruction # " & _ViewModel.SelectedRevision.MediaTrafficID & " Rev " & _ViewModel.SelectedRevision.RevisionNumber & ": " & _ViewModel.SelectedRevision.StartDate.ToString("MM/dd/yy") & " - " & _ViewModel.SelectedRevision.EndDate.ToString("MM/dd/yy") & " [" & _ViewModel.SelectedRevision.Description & "]"

                Else

                    LabelCreativeGroups_TrafficStartEndDescription.Text = String.Empty

                End If

                RibbonBarFilePanel_Revisions.Enabled = (_ViewModel.SelectedRevision IsNot Nothing)

                If _ViewModel.SelectedRevision IsNot Nothing AndAlso _ViewModel.SelectedCreativeGroup IsNot Nothing Then

                    LabelDetails_CreativeGroup.Text = "Instruction # " & _ViewModel.SelectedRevision.MediaTrafficID & " Rev " & _ViewModel.SelectedRevision.RevisionNumber & ": " & _ViewModel.SelectedRevision.StartDate.ToString("MM/dd/yy") & " - " & _ViewModel.SelectedRevision.EndDate.ToString("MM/dd/yy") & If(ButtonItemView_CreativeGroups.Checked, " | " & _ViewModel.SelectedCreativeGroup.Name, "") & " [" & _ViewModel.SelectedRevision.Description & "]"

                Else

                    LabelDetails_CreativeGroup.Text = String.Empty

                End If

                If _ViewModel.SelectedRevision IsNot Nothing AndAlso _ViewModel.SelectedCreativeGroup IsNot Nothing AndAlso _ViewModel.SelectedDetails IsNot Nothing AndAlso _ViewModel.SelectedDetails.Count = 1 Then

                    LabelDocuments_CreativeGroupTitle.Text = "Instruction # " & _ViewModel.SelectedRevision.MediaTrafficID & " Rev " & _ViewModel.SelectedRevision.RevisionNumber & ": " & _ViewModel.SelectedRevision.StartDate.ToString("MM/dd/yy") & " - " & _ViewModel.SelectedRevision.EndDate.ToString("MM/dd/yy") & If(ButtonItemView_CreativeGroups.Checked, " | " & _ViewModel.SelectedCreativeGroup.Name & " | " & _ViewModel.SelectedDetails(0).CreativeTitle, "") & " [" & _ViewModel.SelectedRevision.Description & "]"

                Else

                    LabelDocuments_CreativeGroupTitle.Text = String.Empty

                End If

                For Each KeyPair In DataGridViewDetails_Details.GetAllRowsRowHandlesAndDataBoundItems

                    If DirectCast(KeyPair.Value, AdvantageFramework.DTO.Media.Traffic.Detail).IsDeleted Then

                        DataGridViewDetails_Details.CurrentView.DisableRow(DataGridViewDetails_Details.CurrentView.GetDataSourceRowIndex(KeyPair.Key))

                    Else

                        DataGridViewDetails_Details.CurrentView.EnableRow(DataGridViewDetails_Details.CurrentView.GetDataSourceRowIndex(KeyPair.Key))

                    End If

                Next

                DataGridViewVendors_Vendors.OptionsDetail.EnableMasterViewMode = _ViewModel.IsAnyVendorCableSystem

                DataGridViewDetails_Details.OptionsBehavior.Editable = _ViewModel.SelectedRevision IsNot Nothing

                ButtonItemActions_Default.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines)

                ButtonItemActions_CopyTo.Visible = (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Revisions) AndAlso _ViewModel.SelectedRevision IsNot Nothing)

                ButtonItemActions_Cancel.Enabled = (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Revisions) AndAlso DataGridViewRevision_Revisions.IsNewItemRow) OrElse
                        (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_CreativeGroups) AndAlso DataGridViewCreativeGroup_CreativeGroups.IsNewItemRow) OrElse
                        (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Details) AndAlso DataGridViewDetails_Details.IsNewItemRow) OrElse
                        (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors) AndAlso DataGridViewVendors_Vendors.IsNewItemRow)

                ButtonItemActions_Save.Enabled = (ButtonItemActions_Cancel.Enabled = False AndAlso _ViewModel.SaveEnabled) OrElse RichEditGuidelines_Guidelines.Tag = True

                ButtonItemActions_Delete.Enabled = (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Revisions) AndAlso _ViewModel.SelectedRevision IsNot Nothing) OrElse
                        (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_CreativeGroups) AndAlso _ViewModel.SelectedCreativeGroup IsNot Nothing AndAlso _ViewModel.SelectedCreativeGroup.IsDefault = False) OrElse
                        (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Details) AndAlso _ViewModel.SelectedDetails IsNot Nothing) OrElse
                        (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors) AndAlso _ViewModel.SelectedVendor IsNot Nothing)

                ButtonItemActions_AddToAllVendors.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Revisions) AndAlso _ViewModel.SelectedRevision IsNot Nothing
                ButtonItemActions_RemoveFromAllVendors.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Revisions) AndAlso _ViewModel.SelectedRevision IsNot Nothing

                ButtonItemActions_AddBookend.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Details) AndAlso _ViewModel.SelectedRevision IsNot Nothing

                ButtonItemActions_Generate.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors)
                ButtonItemActions_Generate.Enabled = Not ButtonItemActions_Save.Enabled

                ButtonItemInstruction_Preview.Enabled = _ViewModel.SelectedVendor IsNot Nothing

                TabItemTabs_Details.Visible = (_ViewModel.SelectedCreativeGroup IsNot Nothing)

                TabItemTabs_Status.Visible = (_ViewModel.SelectedVendor IsNot Nothing)

                TabItemTabs_Documents.Visible = (_ViewModel.SelectedDetails IsNot Nothing AndAlso _ViewModel.SelectedDetails.Count = 1)

                ButtonItemView_Responses.Enabled = _ViewModel.Vendors.Where(Function(Entity) Entity.AlertID.HasValue).Any

                ButtonItemRevisions_Create.Enabled = (_ViewModel.SelectedRevision IsNot Nothing AndAlso _ViewModel.SelectedRevision.RevisionNumber = _ViewModel.SelectedRevision.MaxRevisionNumber)
                ButtonItemRevisions_Delete.Enabled = _ViewModel.SelectedRevision IsNot Nothing AndAlso _ViewModel.SelectedRevision.RevisionNumber > 0 AndAlso (_ViewModel.SelectedRevision.RevisionNumber = _ViewModel.SelectedRevision.MaxRevisionNumber) AndAlso _ViewModel.SelectedRevision.GeneratedToOneOrMoreVendors = False

                ButtonItemDocuments_Delete.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Documents)
                ButtonItemDocuments_Download.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Documents)
                ButtonItemDocuments_OpenURL.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Documents)

                ButtonItemView_CreativeGroups.Visible = _ViewModel.WorksheetMarketVendors.Any(Function(V) V.IsCableSystem)

                TabItemTabs_CreativeGroups.Visible = ButtonItemView_CreativeGroups.Checked

                RibbonBarFilePanel_Actions.Visible = True
                RibbonBarFilePanel_Revisions.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Revisions)
                RibbonBarFilePanel_View.Visible = True
                RibbonBarFilePanel_Instruction.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors)
                RibbonBarFilePanel_Documents.Visible = TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Documents) OrElse TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Details)

                RibbonBarFilePanel_Actions.ResetCachedContentSize()
                RibbonBarFilePanel_Actions.Refresh()
                RibbonBarFilePanel_Actions.Width = RibbonBarFilePanel_Actions.GetAutoSizeWidth
                RibbonBarFilePanel_Actions.Refresh()

                RibbonBarFilePanel_View.ResetCachedContentSize()
                RibbonBarFilePanel_View.Refresh()
                RibbonBarFilePanel_View.Width = RibbonBarFilePanel_View.GetAutoSizeWidth
                RibbonBarFilePanel_View.Refresh()

                If RibbonBarFilePanel_Documents.Visible Then

                    ButtonItemDocuments_Delete.Enabled = DocumentManagerControlDocuments_DetailDocuments.HasOnlyOneSelectedDocument
                    ButtonItemDocuments_Download.Enabled = If(DocumentManagerControlDocuments_DetailDocuments.HasOnlyOneSelectedDocument, Not DocumentManagerControlDocuments_DetailDocuments.IsSelectedDocumentAURL, DocumentManagerControlDocuments_DetailDocuments.HasASelectedDocument)
                    ButtonItemDocuments_OpenURL.Enabled = If(DocumentManagerControlDocuments_DetailDocuments.HasOnlyOneSelectedDocument, DocumentManagerControlDocuments_DetailDocuments.IsSelectedDocumentAURL, False)
                    ButtonItemDocuments_Upload.Enabled = DocumentManagerControlDocuments_DetailDocuments.CanUpload AndAlso _ViewModel.SelectedDetails IsNot Nothing AndAlso _ViewModel.SelectedDetails.Count = 1 AndAlso _ViewModel.SelectedDetails(0).ID <> 0

                Else

                    ButtonItemDocuments_Upload.Enabled = False
                    ButtonItemDocuments_Delete.Enabled = False
                    ButtonItemDocuments_Download.Enabled = False
                    ButtonItemDocuments_OpenURL.Enabled = False

                End If

                RibbonBarFilePanel_Documents.ResetCachedContentSize()
                RibbonBarFilePanel_Documents.Refresh()
                RibbonBarFilePanel_Documents.Width = RibbonBarFilePanel_Documents.GetAutoSizeWidth
                RibbonBarFilePanel_Documents.Refresh()

                If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors) Then

                    If _ViewModel.SelectedVendor Is Nothing Then

                        DataGridViewVendors_Vendors.CurrentView.OptionsBehavior.Editable = True

                    Else

                        DataGridViewVendors_Vendors.CurrentView.OptionsBehavior.Editable = (_ViewModel.SelectedVendor IsNot Nothing AndAlso _ViewModel.SelectedVendor.AcceptedStatusDate Is Nothing)

                    End If

                    ButtonItemActions_Delete.Enabled = (_ViewModel.SelectedVendor IsNot Nothing AndAlso _ViewModel.SelectedVendor.AcceptedStatusDate Is Nothing)

                Else

                    If _ViewModel.SelectedRevision IsNot Nothing AndAlso (_ViewModel.SelectedRevision.RevisionNumber <> _ViewModel.SelectedRevision.MaxRevisionNumber OrElse _ViewModel.SelectedRevision.GeneratedToOneOrMoreVendors = True) Then

                        ButtonItemActions_Save.Enabled = False
                        ButtonItemActions_Delete.Enabled = False
                        ButtonItemActions_Cancel.Enabled = False
                        ButtonItemActions_AddToAllVendors.Enabled = False
                        ButtonItemActions_RemoveFromAllVendors.Enabled = False
                        ButtonItemActions_AddBookend.Enabled = False

                        DataGridViewRevision_Revisions.CurrentView.OptionsBehavior.Editable = False
                        DataGridViewCreativeGroup_CreativeGroups.CurrentView.OptionsBehavior.Editable = False
                        DataGridViewDetails_Details.CurrentView.OptionsBehavior.Editable = False

                    Else

                        ButtonItemActions_AddToAllVendors.Enabled = True
                        ButtonItemActions_RemoveFromAllVendors.Enabled = True
                        ButtonItemActions_AddBookend.Enabled = (TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Details) AndAlso _ViewModel.SelectedRevision IsNot Nothing AndAlso DataGridViewDetails_Details.CurrentView.IsEditing = False)

                        DataGridViewRevision_Revisions.CurrentView.OptionsBehavior.Editable = True
                        DataGridViewCreativeGroup_CreativeGroups.CurrentView.OptionsBehavior.Editable = True
                        DataGridViewDetails_Details.CurrentView.OptionsBehavior.Editable = True

                    End If

                End If

                Me.RibbonPanelFile_FilePanel.ResumeLayout()

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub AddCreativeGroup(CreativeGroup As AdvantageFramework.DTO.Media.Traffic.CreativeGroup)

            Dim ErrorMessage As String = Nothing

            If CreativeGroup IsNot Nothing Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

                If _Controller.AddCreativeGroup(_ViewModel, CreativeGroup, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewCreativeGroup_CreativeGroups.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewCreativeGroup_CreativeGroups.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel()

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub
        Private Sub AddRevision(Revision As AdvantageFramework.DTO.Media.Traffic.Revision)

            Dim ErrorMessage As String = Nothing

            If Revision IsNot Nothing Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

                If _Controller.AddToMediaBroadcastWorksheetMarket(_ViewModel, Revision, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewRevision_Revisions.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewRevision_Revisions.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel()

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub
        Private Sub AddVendor(Vendor As AdvantageFramework.DTO.Media.Traffic.Vendor)

            Dim ErrorMessage As String = Nothing

            If Vendor IsNot Nothing Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

                If _Controller.AddVendor(_ViewModel, Vendor, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    LoadMediaTrafficVendors()

                    DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewVendors_Vendors.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel()

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub
        Private Sub AddVendorCreativeGroup(VendorCreativeGroup As AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup)

            Dim ErrorMessage As String = Nothing

            If VendorCreativeGroup IsNot Nothing Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

                If _Controller.AddVendorCreativeGroup(_ViewModel, VendorCreativeGroup, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    _GridViewVendorDetailsLevel1Tab1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    _GridViewVendorDetailsLevel1Tab1.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel()

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewVendors_Vendors.MultiSelect = True
            DataGridViewVendors_Vendors.OptionsView.ShowDetailButtons = True
            DataGridViewVendors_Vendors.OptionsDetail.EnableMasterViewMode = True
            DataGridViewVendors_Vendors.OptionsDetail.AllowExpandEmptyDetails = True
            DataGridViewVendors_Vendors.OptionsDetail.ShowDetailTabs = True
            DataGridViewVendors_Vendors.CurrentView.ObjectType = GetType(AdvantageFramework.DTO.Media.Traffic.Vendor)

            DataGridViewRevision_Revisions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            DataGridViewRevision_Revisions.OptionsBehavior.Editable = True
            DataGridViewRevision_Revisions.MultiSelect = False

            DataGridViewStatus_Statuses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewStatus_Statuses.OptionsBehavior.Editable = False
            DataGridViewStatus_Statuses.MultiSelect = False

            ComboBoxItemRevisions_Revisions.ComboBoxEx.DisplayMember = "RevisionNumberText"
            ComboBoxItemRevisions_Revisions.ComboBoxEx.ValueMember = "RevisionNumber"

            DataGridViewDetails_Details.CurrentView.EnableDisabledRows = True

            RichEditGuidelines_Guidelines.RichEditControl.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF")
            RichEditGuidelines_Guidelines.RestrictFontNameSize = True

        End Sub
        Private Sub LoadMediaTrafficRevisions()

            _Controller.LoadMediaTrafficRevisions(_ViewModel)

            DataGridViewRevision_Revisions.ClearDatasource()
            DataGridViewRevision_Revisions.DataSource = _ViewModel.Revisions
            DataGridViewRevision_Revisions.CurrentView.BestFitColumns()

            If DataGridViewRevision_Revisions.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Revision.Properties.ID.ToString) IsNot Nothing Then

                DataGridViewRevision_Revisions.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Revision.Properties.ID.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewRevision_Revisions.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Revision.Properties.RevisionNumber.ToString) IsNot Nothing Then

                DataGridViewRevision_Revisions.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Revision.Properties.RevisionNumber.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewRevision_Revisions.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Revision.Properties.Description.ToString) IsNot Nothing Then

                DataGridViewRevision_Revisions.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Revision.Properties.Description.ToString).MinWidth = 400

            End If

        End Sub
        Private Sub LoadMediaTrafficDetail()

            Dim Details As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Detail) = Nothing

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadMediaTrafficDetail(_ViewModel)

            DataGridViewDetails_Details.ClearDatasource()
            DataGridViewDetails_Details.DataSource = _ViewModel.Details

            ShowHideBookendColumns()

            DataGridViewDetails_Details.CurrentView.BeginSelection()

            DataGridViewDetails_Details.CurrentView.ClearSelection()

            If _ViewModel.SelectedDetails IsNot Nothing AndAlso _ViewModel.SelectedDetails.Count > 0 Then

                For Each KeyPair In DataGridViewDetails_Details.GetAllRowsRowHandlesAndDataBoundItems

                    If _ViewModel.SelectedDetails.Any(Function(SD) SD.ID = DirectCast(KeyPair.Value, AdvantageFramework.DTO.Media.Traffic.Detail).ID) = True Then

                        DataGridViewDetails_Details.CurrentView.SelectRow(KeyPair.Key)
                        DataGridViewDetails_Details.CurrentView.FocusedRowHandle = KeyPair.Key

                    End If

                Next

            Else

                If DataGridViewDetails_Details.GetAllRowsRowHandlesAndDataBoundItems.Count > 0 Then

                    DataGridViewDetails_Details.CurrentView.SelectRow(0)
                    DataGridViewDetails_Details.CurrentView.FocusedRowHandle = 0

                End If

                Details = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.DTO.Media.Traffic.Detail).ToList

                _Controller.SetSelectedDetail(_ViewModel, Details)

            End If

            DataGridViewDetails_Details.CurrentView.EndSelection()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewDetails_Details.GridViewSelectionChanged()

            DataGridViewDetails_Details.ValidateAllRows()

        End Sub
        Private Sub LoadMediaTrafficVendors()

            _Controller.LoadMediaTrafficVendors(_ViewModel)

            DataGridViewVendors_Vendors.ClearDatasource()
            DataGridViewVendors_Vendors.DataSource = _ViewModel.Vendors.OrderBy(Function(V) V.MediaTrafficID).ToList
            DataGridViewVendors_Vendors.CurrentView.BestFitColumns()

            If DataGridViewVendors_Vendors.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.MediaTrafficRevisionID.ToString) IsNot Nothing Then

                DataGridViewVendors_Vendors.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.MediaTrafficRevisionID.ToString).Width = 225

            End If

            DataGridViewVendors_Vendors.OptionsDetail.ShowDetailTabs = False

            LoadDetailViews()

        End Sub
        Private Sub AddSubItemGridLookUpEdit(ByVal FieldName As String, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim RepositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = Nothing

            If FieldName = AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup.Properties.MediaTrafficCreativeGroupID.ToString Then

                RepositoryItemGridLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit

                RepositoryItemGridLookUpEdit.NullText = ""
                RepositoryItemGridLookUpEdit.DisplayMember = "Name"
                RepositoryItemGridLookUpEdit.ValueMember = "ID"

                RepositoryItemGridLookUpEdit.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                RepositoryItemGridLookUpEdit.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                RepositoryItemGridLookUpEdit.DataSource = _ViewModel.RepositoryMediaTrafficCreativeGroupList

                _GridViewVendorDetailsLevel1Tab1.GridControl.RepositoryItems.Add(RepositoryItemGridLookUpEdit)

                AddHandler RepositoryItemGridLookUpEdit.QueryPopUp, AddressOf SubItemGridLookUpEditControl_QueryPopup

                GridColumn.ColumnEdit = RepositoryItemGridLookUpEdit

            End If

        End Sub
        Private Sub AddSubItemTextBox(ByVal Session As AdvantageFramework.Security.Session, ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView,
                                      ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal MaxLength As Long)

            'objects
            Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

            RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            RepositoryItemButtonEdit.ReadOnly = True

            If CheckForExistingButton(RepositoryItemButtonEdit, DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) = False Then

                RepositoryItemButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis))

            Else

                For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                    If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                        EditorButton.Visible = True
                        Exit For

                    End If

                Next

            End If

            If MaxLength <> -1 Then

                RepositoryItemButtonEdit.MaxLength = MaxLength

            End If

            GridView.GridControl.RepositoryItems.Add(RepositoryItemButtonEdit)

            GridColumn.ColumnEdit = RepositoryItemButtonEdit

            AddHandler RepositoryItemButtonEdit.ButtonClick, AddressOf RepositoryItemButtonEdit_ButtonClick

        End Sub
        Private Sub RepositoryItemButtonEdit_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim VendorCreativeGroup As AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup = Nothing
            Dim Vendor As AdvantageFramework.DTO.Media.Traffic.Vendor = Nothing
            Dim CableNetworkStationList As Generic.List(Of AdvantageFramework.Database.Entities.CableNetworkStation) = Nothing
            Dim NewSelectedCableNetworks As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                BaseView = DataGridViewVendors_Vendors.CurrentView.GetDetailView(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle, 0)

                If BaseView IsNot Nothing Then

                    VendorCreativeGroup = DirectCast(BaseView.GetRow(BaseView.FocusedRowHandle), AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup)

                    If VendorCreativeGroup IsNot Nothing Then

                        Vendor = DataGridViewVendors_Vendors.CurrentView.GetRow(BaseView.SourceRowHandle)

                        CableNetworkStationList = _Controller.GetCableNetworksByVendor(_ViewModel.MediaBroadcastWorksheetMarketID, Vendor, VendorCreativeGroup)

                        If AdvantageFramework.Media.Presentation.MediaTrafficCableNetworkSelectDialog.ShowFormDialog(CableNetworkStationList, VendorCreativeGroup.CableNetworkStationCodes, (BaseView.FocusedRowHandle >= 0), NewSelectedCableNetworks) = System.Windows.Forms.DialogResult.OK Then

                            BaseView.SetRowCellValue(BaseView.FocusedRowHandle, BaseView.FocusedColumn, NewSelectedCableNetworks)

                            VendorCreativeGroup.CableNetworkStationCodes = NewSelectedCableNetworks

                            _Controller.UpdateVendorCreativeGroup(VendorCreativeGroup)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Function CheckForExistingButton(ByVal RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit, ByVal ButtonPredefines As DevExpress.XtraEditors.Controls.ButtonPredefines) As Boolean

            'objects
            Dim ButtonExists As Boolean = False

            For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                If EditorButton.Kind = ButtonPredefines Then

                    ButtonExists = True
                    Exit For

                End If

            Next

            CheckForExistingButton = ButtonExists

        End Function
        Public Sub LoadMediaTrafficCreativeGroups()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadMediaTrafficCreativeGroups(_ViewModel)

            DataGridViewCreativeGroup_CreativeGroups.ClearDatasource()
            DataGridViewCreativeGroup_CreativeGroups.DataSource = _ViewModel.CreativeGroups
            DataGridViewCreativeGroup_CreativeGroups.CurrentView.BestFitColumns()

            If DataGridViewCreativeGroup_CreativeGroups.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.CreativeGroup.Properties.Name.ToString) IsNot Nothing Then

                DataGridViewCreativeGroup_CreativeGroups.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.CreativeGroup.Properties.Name.ToString).MinWidth = 400

            End If

            If DataGridViewCreativeGroup_CreativeGroups.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.CreativeGroup.Properties.IsDefault.ToString) IsNot Nothing Then

                DataGridViewCreativeGroup_CreativeGroups.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.CreativeGroup.Properties.IsDefault.ToString).OptionsColumn.AllowFocus = False

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewCreativeGroup_CreativeGroups.GridViewSelectionChanged()

        End Sub
        Private Sub LoadStatuses()

            _Controller.LoadMediaTrafficStatuses(_ViewModel)

            DataGridViewStatus_Statuses.ClearDatasource()

            DataGridViewStatus_Statuses.DataSource = _ViewModel.VendorStatuses
            DataGridViewStatus_Statuses.CurrentView.BestFitColumns()

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim Saved As Boolean = True

            If _ViewModel.SaveEnabled OrElse RichEditGuidelines_Guidelines.Tag = True Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Saved = Save()

                ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines) Then

                    RichEditGuidelines_Guidelines.Tag = False

                End If

            End If

            CheckForUnsavedChanges = Saved

        End Function
        Private Function Save() As Boolean

            'objects
            Dim FocusedRowHandle As Integer = 0
            Dim Saved As Boolean = False

            If _Controller.HasTrafficInstructionBeenGenerated(_ViewModel) Then

                AdvantageFramework.WinForm.MessageBox.Show("Cannot save changes as associated instruction has already been generated.")

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                Me.TabControlPanel_Tabs.SelectedTab = TabItemTabs_Revisions

                LoadMediaTrafficRevisions()

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                DataGridViewRevision_Revisions.GridViewSelectionChanged()

            Else

                SaveViewModel()

                If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Revisions) Then

                    If _ViewModel.Revisions.Any(Function(Entity) Entity.HasError) = False Then

                        FocusedRowHandle = DataGridViewRevision_Revisions.CurrentView.FocusedRowHandle

                        _Controller.SaveTraffic(_ViewModel)

                        DataGridViewRevision_Revisions.CurrentView.SelectRow(FocusedRowHandle)

                        DataGridViewRevision_Revisions.CurrentView.MakeRowVisible(FocusedRowHandle)

                        DataGridViewRevision_Revisions.GridViewSelectionChanged()

                        RefreshViewModel()

                        Saved = True

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please fix errors in grid.")

                    End If

                ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_CreativeGroups) Then

                    If _ViewModel.CreativeGroups.Any(Function(Entity) Entity.HasError) = False Then

                        _Controller.SaveCreativeGroups(_ViewModel)

                        RefreshViewModel()

                        Saved = True

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please fix errors in grid.")

                    End If

                ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Details) Then

                    If _ViewModel.Details.Any(Function(Entity) Entity.IsDeleted = False AndAlso Entity.HasError) = False Then

                        Me.FormAction = WinForm.Presentation.Methods.FormActions.Saving

                        _Controller.SaveDetails(_ViewModel)

                        LoadMediaTrafficDetail()

                        Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                        DataGridViewDetails_Details.GridViewSelectionChanged()

                        Saved = True

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please fix errors in grid.")

                    End If

                ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines) Then

                    If _Controller.SaveMediaBroadcastWorksheetMarketTrafficGuidelines(_ViewModel) Then

                        RichEditGuidelines_Guidelines.Tag = False

                        RefreshViewModel()

                        Saved = True

                    End If

                End If

            End If

            Save = Saved

        End Function
        Private Sub LoadDetailViews()

            DataGridViewVendors_Vendors.CurrentView.BeginUpdate()

            _GridViewVendorDetailsLevel1Tab1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()

            DataGridViewVendors_Vendors.GridControl.LevelTree.Nodes.Add("VendorDetailsLevel1Tab1", _GridViewVendorDetailsLevel1Tab1)

            _GridViewVendorDetailsLevel1Tab1.LevelIndent = 1

            _GridViewVendorDetailsLevel1Tab1.ChildGridLevelName = "VendorDetailsLevel1Tab1"
            _GridViewVendorDetailsLevel1Tab1.GridControl = DataGridViewVendors_Vendors.GridControl
            _GridViewVendorDetailsLevel1Tab1.Name = "_GridViewVendorDetailsLevel1Tab1"

            _GridViewVendorDetailsLevel1Tab1.ObjectType = GetType(AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup)

            _GridViewVendorDetailsLevel1Tab1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True

            _GridViewVendorDetailsLevel1Tab1.OptionsDetail.ShowDetailTabs = False
            _GridViewVendorDetailsLevel1Tab1.OptionsSelection.MultiSelect = False
            _GridViewVendorDetailsLevel1Tab1.OptionsView.ShowViewCaption = False

            _GridViewVendorDetailsLevel1Tab1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            _GridViewVendorDetailsLevel1Tab1.OptionsView.ShowGroupPanel = False
            _GridViewVendorDetailsLevel1Tab1.OptionsView.ShowFooter = False
            _GridViewVendorDetailsLevel1Tab1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

            DataGridViewVendors_Vendors.CurrentView.EndUpdate()

        End Sub
        Private Function LoadDetailLevel(ByVal RowHandle As Integer, ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView) As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup)

            Dim CreativeGroups As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup) = Nothing
            Dim MediaTrafficVendorID As Integer = 0

            MediaTrafficVendorID = GridView.GetRowCellValue(RowHandle, AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.ID.ToString)

            CreativeGroups = _Controller.GetVendorCreativeGroups(_ViewModel, MediaTrafficVendorID)

            LoadDetailLevel = CreativeGroups

        End Function
        Protected Sub SubItemGridLookUpEditControl_QueryPopup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim DataSource As Object = Nothing
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim ContinueLoad As Boolean = True

            If TypeOf sender Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = sender

                If e.Cancel = True Then

                    If String.IsNullOrWhiteSpace(GridLookUpEdit.Text) = False Then

                        ContinueLoad = False

                    End If

                End If

                If ContinueLoad Then

                    DataSource = _Controller.GetCreativeGroups(_ViewModel)

                    If DataSource IsNot Nothing Then

                        Try

                            DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(DataSource)

                        Catch ex As Exception
                            DataSource = Nothing
                        End Try

                    End If

                    If DataSource IsNot Nothing Then

                        BindingSource = New System.Windows.Forms.BindingSource

                        BindingSource.DataSource = DataSource

                        GridLookUpEdit.Properties.DataSource = BindingSource

                        BaseView = DataGridViewVendors_Vendors.CurrentView.GetDetailView(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle, 0)

                        If TypeOf BaseView.FocusedColumn.ColumnEdit Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl Then

                            SubItemGridLookUpEditControl = DirectCast(BaseView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl)

                            If SubItemGridLookUpEditControl.AddExtraComboBoxItem Then

                                If SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.NullValue Then

                                    AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(GridLookUpEdit.Properties.DataSource, SubItemGridLookUpEditControl.DisplayMember, SubItemGridLookUpEditControl.ValueMember,
                                                                                                                    "[None]", -3, True, True, Nothing)

                                Else

                                    AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(GridLookUpEdit.Properties.DataSource, SubItemGridLookUpEditControl.DisplayMember, SubItemGridLookUpEditControl.ValueMember,
                                                                                                                    "[" & AdvantageFramework.StringUtilities.GetNameAsWords(SubItemGridLookUpEditControl.ExtraComboBoxItem.ToString) & "]",
                                                                                                                    AdvantageFramework.EnumUtilities.GetValue(SubItemGridLookUpEditControl.ExtraComboBoxItem.GetType, SubItemGridLookUpEditControl.ExtraComboBoxItem.ToString),
                                                                                                                    True, True, Nothing)

                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub EnableDisableNavigationButtons()

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewVendors_Vendors.CurrentView.GetDetailView(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle, 0)

            If BaseView IsNot Nothing AndAlso BaseView.GridControl.EmbeddedNavigator.Buttons.CustomButtons.Count = 2 Then

                BaseView.GridControl.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Enabled = BaseView.IsNewItemRow(BaseView.FocusedRowHandle)

            End If

            If BaseView IsNot Nothing AndAlso BaseView.GridControl.EmbeddedNavigator.Buttons.CustomButtons.Count = 2 Then

                BaseView.GridControl.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Enabled = BaseView.IsNewItemRow(BaseView.FocusedRowHandle) = False AndAlso BaseView.SelectedRowsCount > 0

            End If

        End Sub
        Private Sub SetupEmbeddedNavigator(ByRef BaseView As DevExpress.XtraGrid.Views.Grid.GridView)

            Dim DeleteCustomButton As DevExpress.XtraEditors.NavigatorCustomButton = Nothing
            Dim CancelEditCustomButton As DevExpress.XtraEditors.NavigatorCustomButton = Nothing

            If BaseView.GridControl.UseEmbeddedNavigator = False Then

                BaseView.GridControl.UseEmbeddedNavigator = True

                AddHandler BaseView.GridControl.EmbeddedNavigator.ButtonClick, AddressOf GridViewGridControl_EmbeddedNavigator_ButtonClick

                BaseView.GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
                BaseView.GridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
                BaseView.GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
                BaseView.GridControl.EmbeddedNavigator.Buttons.PrevPage.Visible = False
                BaseView.GridControl.EmbeddedNavigator.Buttons.Prev.Visible = False
                BaseView.GridControl.EmbeddedNavigator.Buttons.NextPage.Visible = False
                BaseView.GridControl.EmbeddedNavigator.Buttons.Next.Visible = False
                BaseView.GridControl.EmbeddedNavigator.Buttons.Last.Visible = False
                BaseView.GridControl.EmbeddedNavigator.Buttons.First.Visible = False
                BaseView.GridControl.EmbeddedNavigator.Buttons.Append.Visible = False
                BaseView.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = False

                BaseView.GridControl.EmbeddedNavigator.Buttons.CustomButtons.Clear()

                DeleteCustomButton = BaseView.GridControl.EmbeddedNavigator.Buttons.CustomButtons.Add()

                DeleteCustomButton.Tag = DevExpress.XtraEditors.NavigatorButtonType.Remove
                DeleteCustomButton.Enabled = BaseView.SelectedRowsCount > 0
                DeleteCustomButton.Hint = "Delete"
                DeleteCustomButton.ImageIndex = CInt(DevExpress.XtraEditors.NavigatorButtonType.CancelEdit - 1)

                CancelEditCustomButton = BaseView.GridControl.EmbeddedNavigator.Buttons.CustomButtons.Add()

                CancelEditCustomButton.Tag = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit
                CancelEditCustomButton.Enabled = False
                CancelEditCustomButton.Hint = "Cancel"
                CancelEditCustomButton.ImageIndex = CInt(DevExpress.XtraEditors.NavigatorButtonType.Remove - 1)

                BaseView.GridControl.EmbeddedNavigator.TextStringFormat = ""

            End If

        End Sub
        Private Sub LoadDetailDocuments()

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            DocumentManagerControlDocuments_DetailDocuments.ClearControl()

            If _ViewModel.SelectedDetails IsNot Nothing AndAlso _ViewModel.SelectedDetails.Count = 1 Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaTrafficDetail) With {.MediaTrafficDetailID = _ViewModel.SelectedDetails(0).ID}

                DocumentManagerControlDocuments_DetailDocuments.Enabled = DocumentManagerControlDocuments_DetailDocuments.LoadControl(Database.Entities.DocumentLevel.MediaTrafficDetail, DocumentLevelSetting, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

            End If

        End Sub
        Private Sub LoadMissingInstructions()

            DataGridViewMTI_MissingTrafficInstructions.ClearDatasource()
            DataGridViewMTI_MissingTrafficInstructions.DataSource = (From Entity In _Controller.LoadMissingInstructions({_ViewModel.MediaBroadcastWorksheetID}, _ViewModel.MediaBroadcastWorksheetMarketID)
                                                                     Select Entity.VendorCode, Entity.VendorName, Entity.SpotDate).ToList

            DataGridViewMTI_MissingTrafficInstructions.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetMarketID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTrafficDialog As MediaTrafficDialog = Nothing

            MediaTrafficDialog = New MediaTrafficDialog(MediaBroadcastWorksheetMarketID)

            ShowFormDialog = MediaTrafficDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTrafficDialog_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed



        End Sub
        Private Sub MediaTrafficDialog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            e.Cancel = Not CheckForUnsavedChanges()

            If Not e.Cancel Then

                If _ReloadGrid Then

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                Else

                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

                End If

            End If

        End Sub
        Private Sub MediaTrafficDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_CopyTo.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Generate.Image = AdvantageFramework.My.Resources.MediaAddImage

            ButtonItemActions_AddToAllVendors.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_RemoveFromAllVendors.Image = AdvantageFramework.My.Resources.DeleteImage

            ButtonItemActions_Default.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemActions_AddBookend.Image = AdvantageFramework.My.Resources.NielsenBookImage

            ButtonItemView_CreativeGroups.Image = AdvantageFramework.My.Resources.CreativeGroupImage
            ButtonItemView_Responses.Image = AdvantageFramework.My.Resources.MailOpenImage

            ButtonItemInstruction_Preview.Image = AdvantageFramework.My.Resources.PrintPreviewImage
            ButtonItemInstruction_Settings.Image = AdvantageFramework.My.Resources.LogAndSettingsImage

            ButtonItemRevisions_Create.Image = AdvantageFramework.My.Resources.RevisionViewImage
            ButtonItemRevisions_Delete.Image = AdvantageFramework.My.Resources.RevisionDeleteImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            ButtonItemEdit_AdNumbers.Image = AdvantageFramework.My.Resources.EditImage

            DataGridViewMTI_MissingTrafficInstructions.OptionsBehavior.Editable = False

            _Controller = New AdvantageFramework.Controller.Media.MediaTrafficController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaTrafficDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadMediaTrafficRevisions()

            LoadMediaTrafficVendors()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

            DataGridViewRevision_Revisions.GridViewSelectionChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_AddBookend_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AddBookend.Click

            _Controller.AddBookend(_ViewModel)

            ShowHideBookendColumns()

            DataGridViewDetails_Details.CurrentView.RefreshData()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            If TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Revisions) Then

                DataGridViewRevision_Revisions.CurrentView.CancelNewItemRow()

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_CreativeGroups) Then

                DataGridViewCreativeGroup_CreativeGroups.CurrentView.CancelNewItemRow()

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Details) Then

                DataGridViewDetails_Details.CurrentView.CancelNewItemRow()

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors) Then

                DataGridViewVendors_Vendors.CurrentView.CancelNewItemRow()

            End If

        End Sub
        Private Sub ButtonItemInstruction_CopyTo_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CopyTo.Click

            If _ViewModel.SelectedRevision IsNot Nothing AndAlso _ViewModel.SelectedRevision.ID Then

                If AdvantageFramework.Media.Presentation.MediaTrafficInstructionCopyDialog.ShowFormDialog(_ViewModel.SelectedRevision.ID) = Windows.Forms.DialogResult.OK Then

                    AdvantageFramework.WinForm.MessageBox.Show("Instruction copied.")

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Default_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Default.Click

            If Not RichEditGuidelines_Guidelines.Text.Equals(_Controller.LoadGuidelines(_ViewModel)) Then

                RichEditGuidelines_Guidelines.HtmlText = _Controller.LoadGuidelines(_ViewModel)
                RichEditGuidelines_Guidelines.Tag = True

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            Dim ErrorText As String = Nothing
            Dim Details As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Detail) = Nothing

            If _Controller.HasTrafficInstructionBeenGenerated(_ViewModel) Then

                AdvantageFramework.WinForm.MessageBox.Show("Cannot delete as associated instruction has already been generated.")

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                Me.TabControlPanel_Tabs.SelectedTab = TabItemTabs_Revisions

                LoadMediaTrafficRevisions()

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                DataGridViewRevision_Revisions.GridViewSelectionChanged()

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Revisions) Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete the selected instruction revision?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxIcon:=Windows.Forms.MessageBoxIcon.Hand, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.Deleting

                    If _Controller.DeleteTraffic(_ViewModel, ErrorText) Then

                        LoadMediaTrafficRevisions()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorText)

                    End If

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                    DataGridViewRevision_Revisions.GridViewSelectionChanged()

                End If

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_CreativeGroups) Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete the selected creative group?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxIcon:=Windows.Forms.MessageBoxIcon.Hand, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.Deleting

                    If _Controller.DeleteCreativeGroup(_ViewModel, ErrorText) Then

                        DataGridViewCreativeGroup_CreativeGroups.CurrentView.RefreshData()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorText)

                    End If

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                    DataGridViewCreativeGroup_CreativeGroups.GridViewSelectionChanged()

                End If

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Details) Then

                If _Controller.DeleteDetail(_ViewModel) Then

                    ShowHideBookendColumns()

                    DataGridViewDetails_Details.CurrentView.RefreshData()

                    Details = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.DTO.Media.Traffic.Detail).ToList

                    _Controller.SetSelectedDetail(_ViewModel, Details)

                    RefreshViewModel()

                End If

            ElseIf TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Vendors) Then

                If _Controller.HasVendorInstructionBeenGenerated(_ViewModel, ErrorText) = False Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to remove this vendor from the selected instructions?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxIcon:=Windows.Forms.MessageBoxIcon.Hand, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.FormAction = WinForm.Presentation.Methods.FormActions.Deleting

                        If _Controller.DeleteVendor(_ViewModel, ErrorText) Then

                            DataGridViewVendors_Vendors.DataSource = _ViewModel.Vendors.OrderBy(Function(V) V.MediaTrafficID).ToList

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorText)

                        End If

                        Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                        DataGridViewVendors_Vendors.GridViewSelectionChanged()

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorText)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_GenerateOrders_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Generate.Click

            If AdvantageFramework.Media.Presentation.MediaTrafficGenerateDialog.ShowFormDialog(DataGridViewVendors_Vendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Vendor).ToList) = Windows.Forms.DialogResult.OK Then

                LoadMediaTrafficVendors()

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemEdit_AdNumbers_Click(sender As Object, e As EventArgs) Handles ButtonItemEdit_AdNumbers.Click

            AdvantageFramework.Maintenance.ProjectManagement.Presentation.AdNumberEditDialog.ShowFormDialog(_ViewModel.ClientCode)

            DataGridViewDetails_Details.ValidateAllRows()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            If DocumentManagerControlDocuments_DetailDocuments.DeleteSelectedDocument() Then

                _Controller.UpdateSelectedDetailHasDocuments(_ViewModel)

                DataGridViewDetails_Details.CurrentView.RefreshRow(DataGridViewDetails_Details.CurrentView.FocusedRowHandle)

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            DocumentManagerControlDocuments_DetailDocuments.DownloadSelectedDocument()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            DocumentManagerControlDocuments_DetailDocuments.DownloadSelectedDocument()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            If DocumentManagerControlDocuments_DetailDocuments.UploadNewDocument() Then

                _Controller.UpdateSelectedDetailHasDocuments(_ViewModel)

                DataGridViewDetails_Details.CurrentView.RefreshRow(DataGridViewDetails_Details.CurrentView.FocusedRowHandle)

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click_1(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            DocumentManagerControlDocuments_DetailDocuments.SendASPUploadEmail()

        End Sub
        Private Sub ButtonItemInstruction_Preview_Click(sender As Object, e As EventArgs) Handles ButtonItemInstruction_Preview.Click

            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler = Nothing

            Report = AdvantageFramework.Reporting.Reports.CreateMediaTrafficReport(Me.Session, _ViewModel.SelectedVendor.ID, _ViewModel.Location, If(_ViewModel.IncludeGuidelines, _ViewModel.TrafficGuidelines, Nothing))

            If Report IsNot Nothing Then

                Report.CreateDocument()

                If _ViewModel.IsAgencyASP Then

                    If My.Computer.FileSystem.DirectoryExists(_ViewModel.AgencyImportPath) Then

                        If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(_ViewModel.AgencyImportPath.Trim, "\") & "Reports\") = False Then

                            My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(_ViewModel.AgencyImportPath.Trim, "\") & "Reports\")

                        End If

                    End If

                    Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = _ViewModel.InstructionFilename
                    Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(_ViewModel.AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(_ViewModel.AgencyImportPath.Trim, "\") & "Reports\")
                    Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                    Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                    PrintingSystemCommandHandler = New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(_ViewModel.AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(_ViewModel.AgencyImportPath.Trim, "\") & "Reports\"), _ViewModel.InstructionFilename, False)

                    Report.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                Else

                    Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = _ViewModel.InstructionFilename

                End If

                AdvantageFramework.Media.Presentation.MediaManagerOrderViewingForm.ShowFormDialog(Report, PrintingSystemCommandHandler)

            End If

        End Sub
        Private Sub ButtonItemInstruction_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItemInstruction_Settings.Click

            AdvantageFramework.Media.Presentation.MediaTrafficPrintingOptionsDialog.ShowFormDialog(_ViewModel.MediaType)

            _Controller.RefreshLocation(_ViewModel)

        End Sub
        Private Sub ButtonItemActions_AddToAllVendors_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AddToAllVendors.Click

            _Controller.AddAllVendorsToMediaTrafficRevision(_ViewModel, DataGridViewRevision_Revisions.GetFirstSelectedRowDataBoundItem)

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemActions_RemoveFromAllVendors_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_RemoveFromAllVendors.Click

            Dim Revision As AdvantageFramework.DTO.Media.Traffic.Revision = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor) = Nothing

            Revision = DataGridViewRevision_Revisions.GetFirstSelectedRowDataBoundItem

            Vendors = DataGridViewVendors_Vendors.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Vendor).ToList

            Vendors = Vendors.Where(Function(V) V.MediaTrafficRevisionID = Revision.ID AndAlso V.AlertID Is Nothing).ToList

            Vendors = _Controller.RemoveGeneratedVendors(Vendors)

            If Vendors.Count > 0 Then

                If AdvantageFramework.WinForm.MessageBox.Show("Remove all pending (un-generated) instructions from all vendors?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxIcon:=Windows.Forms.MessageBoxIcon.Question, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                    _Controller.DeleteVendors(_ViewModel, Vendors)

                End If

            End If

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemRevisions_Create_Click(sender As Object, e As EventArgs) Handles ButtonItemRevisions_Create.Click

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Recalculating

            _Controller.CreateRevision(_ViewModel)

            TabControlPanel_Tabs.SelectedTab = Me.TabItemTabs_Revisions

            'LoadRevisionNumbers()

            LoadMediaTrafficRevisions()

            '_Controller.ChangeRevisionNumber(_ViewModel, _ViewModel.SelectedRevision.RevisionNumber)

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewRevision_Revisions.GridViewSelectionChanged()

        End Sub
        Private Sub ButtonItemRevisions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemRevisions_Delete.Click

            Dim ErrorText As String = Nothing

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this revision?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Deleting

                If _Controller.DeleteRevision(_ViewModel, ErrorText) Then

                    TabControlPanel_Tabs.SelectedTab = Me.TabItemTabs_Revisions

                    'LoadRevisionNumbers()

                    LoadMediaTrafficRevisions()

                    '_Controller.ChangeRevisionNumber(_ViewModel, _ViewModel.SelectedRevision.RevisionNumber)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorText)

                End If

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                DataGridViewRevision_Revisions.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonItemView_CreativeGroups_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_CreativeGroups.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemView_CreativeGroups.Checked = False AndAlso _ViewModel.SelectedRevision IsNot Nothing AndAlso _ViewModel.SelectedRevision.CreativeGroupCount > 1 Then

                    ButtonItemView_CreativeGroups.Checked = True

                End If

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemView_Responses_Click(sender As Object, e As EventArgs) Handles ButtonItemView_Responses.Click

            AdvantageFramework.Media.Presentation.MediaTrafficResponseDialog.ShowFormDialog(_ViewModel.Vendors.Where(Function(Entity) Entity.AlertID.HasValue).ToList, (_ViewModel.SelectedRevision.RevisionNumber = _ViewModel.SelectedRevision.MaxRevisionNumber))

        End Sub
        Private Sub ComboBoxItemRevisions_Revisions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemRevisions_Revisions.SelectedIndexChanged

            'If _IsLoadingRevisionNumbers = False AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

            '    If _ViewModel.SaveEnabled Then

            '        If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before switching.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

            '            If Save() Then

            '                _Controller.ChangeRevisionNumber(_ViewModel, ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue)

            '                RefreshViewModel()

            '            End If

            '        End If

            '    Else

            '        _Controller.ChangeRevisionNumber(_ViewModel, ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue)

            '        RefreshViewModel()

            '    End If

            'End If

        End Sub
        Private Sub DataGridViewCreativeGroup_CreativeGroups_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewCreativeGroup_CreativeGroups.CellValueChangingEvent

            If e.RowHandle >= 0 Then

                _Controller.SetCreativeGroupModified(_ViewModel, DataGridViewCreativeGroup_CreativeGroups.GetFirstSelectedRowDataBoundItem)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewCreativeGroup_CreativeGroups_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewCreativeGroup_CreativeGroups.FocusedRowChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If DataGridViewCreativeGroup_CreativeGroups.CurrentView.FocusedRowHandle < 0 Then

                    _Controller.SetSelectedCreativeGroup(_ViewModel, Nothing)

                Else

                    _Controller.SetSelectedCreativeGroup(_ViewModel, DataGridViewCreativeGroup_CreativeGroups.GetFirstSelectedRowDataBoundItem)

                End If

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewCreativeGroup_CreativeGroups_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewCreativeGroup_CreativeGroups.InitNewRowEvent

            If TypeOf DataGridViewCreativeGroup_CreativeGroups.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.DTO.Media.Traffic.CreativeGroup Then

                DirectCast(DataGridViewCreativeGroup_CreativeGroups.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.Traffic.CreativeGroup).MediaTrafficRevisionID = _ViewModel.SelectedRevision.ID

            End If

        End Sub
        Private Sub DataGridViewCreativeGroup_CreativeGroups_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewCreativeGroup_CreativeGroups.ValidateRowEvent

            If e.Row IsNot Nothing Then

                'If (From Entity In DataGridViewCreativeGroup_CreativeGroups.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.CreativeGroup)
                '    Where Entity.Name.ToUpper.Trim = e.Row.Name.ToString.ToUpper.Trim).Any Then

                '    e.ErrorText = "Create Group exists."
                '    e.Valid = False

                'Else

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                'End If

                If DataGridViewCreativeGroup_CreativeGroups.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewCreativeGroup_CreativeGroups.CurrentView.NewItemRowText = e.ErrorText
                    DataGridViewCreativeGroup_CreativeGroups.CurrentView.SetColumnError(DataGridViewCreativeGroup_CreativeGroups.CurrentView.Columns("Name"), e.ErrorText)

                    If e.Valid Then

                        AddCreativeGroup(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewDetails_Details_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDetails_Details.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.BookendName.ToString Then

                _Controller.UpdateBookends(_ViewModel, DataGridViewDetails_Details.CurrentView.GetRow(e.RowHandle), e.Value)

                RefreshViewModel()

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.AdNumber.ToString Then

                _Controller.UpdateAdNumber(_ViewModel, DataGridViewDetails_Details.CurrentView.GetRow(e.RowHandle), e.Value)

                RefreshViewModel()

            End If

            DataGridViewDetails_Details.CurrentView.RefreshData()

        End Sub
        Private Sub DataGridViewDetails_Details_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDetails_Details.CellValueChangingEvent

            If e.RowHandle >= 0 Then

                _Controller.SetDetailModified(_ViewModel, DataGridViewDetails_Details.GetFirstSelectedRowDataBoundItem)

                DataGridViewDetails_Details.CurrentView.RefreshData()

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewDetails_Details_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewDetails_Details.InitNewRowEvent

            Dim Detail As AdvantageFramework.DTO.Media.Traffic.Detail = Nothing

            Detail = DirectCast(DataGridViewDetails_Details.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.Traffic.Detail)

            Detail.Rotation = 100
            Detail.Length = _ViewModel.DefaultLength
            Detail.IsBookend = False
            Detail.Modified = True

        End Sub
        Private Sub DataGridViewDetails_Details_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewDetails_Details.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.DayPartID.ToString Then

                OverrideDefaultDatasource = True

                Datasource = _Controller.GetDayparts(_ViewModel)

            ElseIf FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.AdNumber.ToString Then

                OverrideDefaultDatasource = True

                Datasource = _Controller.GetAdNumbers(_ViewModel)

            End If

        End Sub
        Private Sub DataGridViewDetails_Details_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewDetails_Details.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.DayPartID.ToString Then

                Datasource = _ViewModel.RepositoryDaypartList

            ElseIf FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.AdNumber.ToString Then

                Datasource = _ViewModel.RepositoryAdNumberList

            End If

        End Sub
        Private Sub DataGridViewDetails_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDetails_Details.SelectionChangedEvent

            Dim Details As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Detail) = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If DataGridViewDetails_Details.CurrentView.FocusedRowHandle < 0 Then

                    _Controller.SetSelectedDetail(_ViewModel, Nothing)

                Else

                    Details = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.DTO.Media.Traffic.Detail).ToList

                    _Controller.SetSelectedDetail(_ViewModel, Details)

                End If

                LoadDetailDocuments()

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewDetails_Details_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewDetails_Details.ShowingEditorEvent

            If DataGridViewDetails_Details.CurrentView.FocusedRowHandle < 0 Then

                If (DataGridViewDetails_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.BookendName.ToString OrElse
                       DataGridViewDetails_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Position.ToString OrElse
                       DataGridViewDetails_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.IsBookend.ToString) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewDetails_Details.CurrentView.FocusedRowHandle >= 0 Then

                If (DataGridViewDetails_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.BookendName.ToString OrElse
                        DataGridViewDetails_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Position.ToString) AndAlso
                        DirectCast(DataGridViewDetails_Details.CurrentView.GetRow(DataGridViewDetails_Details.CurrentView.FocusedRowHandle), DTO.Media.Traffic.Detail).IsBookend = False Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewDetails_Details_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewDetails_Details.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateDetailEntity(e.Row, _ViewModel, e.Valid)

                e.Valid = True 'this is by design instead of code below

                'If DataGridViewDetails_Details.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                '    e.Valid = True

                'Else

                '    DataGridViewDetails_Details.CurrentView.NewItemRowText = e.ErrorText

                'End If

            End If

        End Sub
        Private Sub DataGridViewDetails_Details_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewDetails_Details.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.Traffic.Detail = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewDetails_Details.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, _ViewModel, DataGridViewDetails_Details.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewDetails_Details.CurrentView.SetColumnError(DataGridViewDetails_Details.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewRevision_Revisions_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRevision_Revisions.CellValueChangingEvent

            If e.RowHandle >= 0 Then

                _Controller.SetRevisionModified(_ViewModel, DataGridViewRevision_Revisions.GetFirstSelectedRowDataBoundItem)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewRevision_Revisions_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewRevision_Revisions.FocusedRowChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If DataGridViewRevision_Revisions.CurrentView.FocusedRowHandle < 0 Then

                    _Controller.SetSelectedRevision(_ViewModel, Nothing)

                Else

                    _Controller.SetSelectedRevision(_ViewModel, DataGridViewRevision_Revisions.GetFirstSelectedRowDataBoundItem)

                End If

                'LoadRevisionNumbers()

                If _ViewModel.SelectedRevision IsNot Nothing AndAlso _ViewModel.SelectedRevision.CreativeGroupCount > 1 Then

                    ButtonItemView_CreativeGroups.Checked = True

                Else

                    ButtonItemView_CreativeGroups.Checked = False

                End If

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewRevision_Revisions_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewRevision_Revisions.InitNewRowEvent

            If TypeOf DataGridViewRevision_Revisions.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.DTO.Media.Traffic.Revision Then

                DirectCast(DataGridViewRevision_Revisions.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.Traffic.Revision).StartDate = _ViewModel.MediaBroadcastWorksheetStartDate
                DirectCast(DataGridViewRevision_Revisions.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.Traffic.Revision).EndDate = _ViewModel.MediaBroadcastWorksheetEndDate

                DirectCast(DataGridViewRevision_Revisions.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.Traffic.Revision).BroadcastWorksheetStartDate = _ViewModel.MediaBroadcastWorksheetStartDate
                DirectCast(DataGridViewRevision_Revisions.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.Traffic.Revision).BroadcastWorksheetEndDate = _ViewModel.MediaBroadcastWorksheetEndDate

            End If

        End Sub
        Private Sub DataGridViewRevision_Revisions_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewRevision_Revisions.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewRevision_Revisions.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewRevision_Revisions.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddRevision(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewRevision_Revisions_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewRevision_Revisions.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.Traffic.Revision = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewRevision_Revisions.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, _ViewModel, DataGridViewRevision_Revisions.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewRevision_Revisions.CurrentView.SetColumnError(DataGridViewRevision_Revisions.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_ColumnValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewVendors_Vendors.ColumnValueChangedEvent

            Dim Vendor As AdvantageFramework.DTO.Media.Traffic.Vendor = Nothing
            Dim Revision As AdvantageFramework.DTO.Media.Traffic.Revision = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.MediaTrafficRevisionID.ToString Then

                Vendor = DirectCast(DataGridViewVendors_Vendors.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.Traffic.Vendor)

                Revision = _ViewModel.Revisions.Where(Function(R) R.ID = e.Value).SingleOrDefault

                If Revision IsNot Nothing Then

                    Vendor.StartDate = Revision.StartDate
                    Vendor.EndDate = Revision.EndDate

                End If

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewVendors_Vendors.CustomDrawCellEvent

            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            GridView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If e.Column.VisibleIndex = 0 And GridView.IsMasterRowEmpty(e.RowHandle) Then

                TryCast(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo).CellButtonRect = System.Drawing.Rectangle.Empty

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_MasterRowEmptyEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewVendors_Vendors.MasterRowEmptyEvent

            If e.RowHandle >= 0 AndAlso DirectCast(DataGridViewVendors_Vendors.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.Traffic.Vendor) IsNot Nothing AndAlso
                    DirectCast(DataGridViewVendors_Vendors.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.Traffic.Vendor).IsCableSystem Then

                e.IsEmpty = False

            Else

                e.IsEmpty = True

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_MasterRowExpandedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewVendors_Vendors.MasterRowExpandedEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewVendors_Vendors.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                SetupEmbeddedNavigator(BaseView)

                BaseView.ClearSelection()

                BaseView.SelectRow(BaseView.SourceRowHandle)

                If BaseView.ChildGridLevelName = "VendorDetailsLevel1Tab1" Then

                    Select Case e.RelationIndex

                        Case 0

                            AddHandler BaseView.ShowingEditor, AddressOf _GridViewVendorDetailsLevel1Tab1_ShowingEditor
                            AddHandler BaseView.FocusedRowChanged, AddressOf _GridViewVendorDetailsLevel1Tab1_FocusedRowChanged
                            AddHandler BaseView.SelectionChanged, AddressOf _GridViewVendorDetailsLevel1Tab1_SelectionChanged

                    End Select

                    If BaseView.RowCount > 0 Then

                        BaseView.SelectRow(0)

                    End If

                End If

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_MasterRowGetChildListEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewVendors_Vendors.MasterRowGetChildListEvent

            e.ChildList = New System.Windows.Forms.BindingSource(LoadDetailLevel(e.RowHandle, DataGridViewVendors_Vendors.CurrentView), String.Empty)

        End Sub
        Private Sub DataGridViewVendors_Vendors_MasterRowGetRelationCountEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewVendors_Vendors.MasterRowGetRelationCountEvent

            e.RelationCount = 1

        End Sub
        Private Sub DataGridViewVendors_Vendors_MasterRowGetRelationDisplayCaptionEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewVendors_Vendors.MasterRowGetRelationDisplayCaptionEvent

            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RowCount As Integer = 0

            BaseView = DataGridViewVendors_Vendors.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            'DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GridControl.FocusedView = Nothing

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                For Each GridColumn In BaseView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup.Properties.MediaTrafficCreativeGroupID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup.Properties.CableNetworkStationCodes.ToString Then

                        GridColumn.Visible = True

                        If GridColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup.Properties.MediaTrafficCreativeGroupID.ToString Then

                            GridColumn.Caption = "Creative Group"

                            AddSubItemGridLookUpEdit(GridColumn.FieldName, GridColumn)

                        ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup.Properties.CableNetworkStationCodes.ToString Then

                            GridColumn.Caption = "Cable Network Station Codes"

                            AddSubItemTextBox(Me.Session, BaseView, GridColumn, 8000)

                        End If

                    Else

                        GridColumn.Visible = False
                        GridColumn.OptionsColumn.AllowShowHide = False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False
                        GridColumn.OptionsColumn.ShowInExpressionEditor = False

                    End If

                Next

                RowCount = BaseView.RowCount

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = RowCount & " Creative Group(s)"

                End Select

            Else

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = " Creative Group(s)"

                End Select

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_MasterRowGetRelationNameEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewVendors_Vendors.MasterRowGetRelationNameEvent

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "VendorDetailsLevel1Tab1"

            End Select

        End Sub
        Private Sub DataGridViewVendors_Vendors_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewVendors_Vendors.QueryPopupNeedDatasourceEvent

            Dim Vendor As AdvantageFramework.DTO.Media.Traffic.Vendor = Nothing

            If FieldName = AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.MediaTrafficRevisionID.ToString Then

                OverrideDefaultDatasource = True

                Datasource = _ViewModel.Revisions

            ElseIf FieldName = AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.VendorCode.ToString Then

                Vendor = DirectCast(DataGridViewVendors_Vendors.CurrentView.GetRow(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.Traffic.Vendor)

                If Vendor IsNot Nothing Then

                    OverrideDefaultDatasource = True

                    Datasource = (From Entity In _Controller.GetVendors(_ViewModel, Vendor.MediaTrafficRevisionID)
                                  Select New With {.Code = Entity.Code,
                                                   .Name = Entity.Name,
                                                   .Category = Entity.VendorCategory}).ToList

                End If

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewVendors_Vendors.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.MediaTrafficRevisionID.ToString Then

                Datasource = _ViewModel.Revisions

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewVendors_Vendors.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If DataGridViewVendors_Vendors.HasOnlyOneSelectedRow Then

                    _Controller.SetSelectedVendor(_ViewModel, DataGridViewVendors_Vendors.GetFirstSelectedRowDataBoundItem)

                Else

                    _Controller.SetSelectedVendor(_ViewModel, Nothing)

                End If

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewVendors_Vendors.ShowingEditorEvent

            If DataGridViewVendors_Vendors.IsNewItemRow() Then

                If DataGridViewVendors_Vendors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.VendorCode.ToString Then

                    e.Cancel = DataGridViewVendors_Vendors.CurrentView.GetRow(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle) Is Nothing OrElse
                        DirectCast(DataGridViewVendors_Vendors.CurrentView.GetRow(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.Traffic.Vendor).MediaTrafficRevisionID.HasValue = False

                ElseIf (DataGridViewVendors_Vendors.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.VendorCode.ToString AndAlso
                        DataGridViewVendors_Vendors.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.MediaTrafficRevisionID.ToString) Then

                    e.Cancel = True

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewVendors_Vendors.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewVendors_Vendors.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewVendors_Vendors.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddVendor(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DocumentManagerControlDocuments_DetailDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_DetailDocuments.SelectedDocumentChanged

            RefreshViewModel()

        End Sub
        Private Sub RichEditGuidelines_Guidelines_TextChangedEvent(sender As Object, e As EventArgs) Handles RichEditGuidelines_Guidelines.TextChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso Me.TabControlPanel_Tabs.SelectedTab.Equals(TabItemTabs_Guidelines) AndAlso
                    DirectCast(sender, DevExpress.XtraRichEdit.RichEditControl).Modified Then

                RichEditGuidelines_Guidelines.Tag = True

                RefreshViewModel()

            End If

        End Sub
        Private Sub TabControlPanel_Tabs_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlPanel_Tabs.SelectedTabChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If e.NewTab.Equals(TabItemTabs_CreativeGroups) AndAlso _ViewModel.SelectedRevision IsNot Nothing Then

                    LoadMediaTrafficCreativeGroups()

                ElseIf e.NewTab.Equals(TabItemTabs_Details) AndAlso _ViewModel.SelectedCreativeGroup IsNot Nothing Then

                    LoadMediaTrafficDetail()

                ElseIf e.NewTab.Equals(TabItemTabs_Documents) Then

                    LoadDetailDocuments()

                ElseIf e.NewTab.Equals(TabItemTabs_Vendors) Then

                    LoadMediaTrafficVendors()

                ElseIf e.NewTab.Equals(TabItemTabs_Status) Then

                    LoadStatuses()

                ElseIf e.NewTab.Equals(TabItemTabs_MissingInstructions) Then

                    LoadMissingInstructions()

                ElseIf e.NewTab.Equals(TabItemTabs_Revisions) Then

                    LoadMediaTrafficRevisions()

                End If

                RefreshViewModel()

            End If

        End Sub
        Private Sub TabControlPanel_Tabs_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlPanel_Tabs.SelectedTabChanging

            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                DataGridViewRevision_Revisions.CurrentView.CloseEditorForUpdating()
                DataGridViewCreativeGroup_CreativeGroups.CurrentView.CloseEditorForUpdating()
                DataGridViewDetails_Details.CurrentView.CloseEditorForUpdating()

                e.Cancel = Not CheckForUnsavedChanges()

                If e.Cancel = False Then

                    If _ViewModel.SaveEnabled Then

                        If e.OldTab.Equals(TabItemTabs_Revisions) Then

                            LoadMediaTrafficRevisions()

                        ElseIf e.OldTab.Equals(TabItemTabs_CreativeGroups) Then

                            LoadMediaTrafficCreativeGroups()

                        ElseIf e.OldTab.Equals(TabItemTabs_Details) Then

                            LoadMediaTrafficDetail()

                        End If

                    End If

                    If e.NewTab.Equals(TabItemTabs_Vendors) Then

                        If DataGridViewVendors_Vendors.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.MediaTrafficRevisionID.ToString) IsNot Nothing Then

                            SubItemGridLookUpEditControl = DataGridViewVendors_Vendors.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Vendor.Properties.MediaTrafficRevisionID.ToString).ColumnEdit
                            SubItemGridLookUpEditControl.DataSource = _ViewModel.Revisions

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub _GridViewVendorDetailsLevel1Tab1_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles _GridViewVendorDetailsLevel1Tab1.ValidateRow

            Dim Vendor As AdvantageFramework.DTO.Media.Traffic.Vendor = Nothing

            If e.Row IsNot Nothing Then

                Vendor = DataGridViewVendors_Vendors.GetRowDataBoundItem(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle)

                If Vendor IsNot Nothing Then

                    DirectCast(e.Row, AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup).MediaTrafficVendorID = Vendor.ID
                    DirectCast(e.Row, AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup).VendorCode = Vendor.VendorCode

                End If

                e.Valid = True

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If _GridViewVendorDetailsLevel1Tab1.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    _GridViewVendorDetailsLevel1Tab1.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddVendorCreativeGroup(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub _GridViewVendorDetailsLevel1Tab1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)

            EnableDisableNavigationButtons()

        End Sub
        Private Sub _GridViewVendorDetailsLevel1Tab1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs)

            EnableDisableNavigationButtons()

        End Sub
        Private Sub _GridViewVendorDetailsLevel1Tab1_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If BaseView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup.Properties.MediaTrafficCreativeGroupID.ToString AndAlso BaseView.FocusedRowHandle >= 0 Then

                e.Cancel = True

            ElseIf DirectCast(BaseView.SourceRow, AdvantageFramework.DTO.Media.Traffic.Vendor).AcceptedStatusDate.HasValue Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GridViewGridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim ID As Integer = 0
            Dim ErrorText As String = Nothing

            If Not e.Handled AndAlso _ViewModel.SelectedVendor IsNot Nothing AndAlso _ViewModel.SelectedVendor.AcceptedStatusDate Is Nothing Then

                BaseView = DataGridViewVendors_Vendors.CurrentView.GetDetailView(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle, 0)

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        If BaseView IsNot Nothing Then

                            BaseView.CancelUpdateCurrentRow()

                            e.Handled = True

                        End If

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        If BaseView IsNot Nothing Then

                            ID = BaseView.GetRowCellValue(BaseView.FocusedRowHandle, AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup.Properties.ID.ToString)

                            If ID <> 0 Then

                                If _Controller.DeleteVendorCreativeGroup(_ViewModel, ID, ErrorText) = False Then

                                    AdvantageFramework.WinForm.MessageBox.Show(ErrorText)

                                Else

                                    DataGridViewVendors_Vendors.CurrentView.CollapseMasterRow(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle)
                                    DataGridViewVendors_Vendors.CurrentView.ExpandMasterRow(DataGridViewVendors_Vendors.CurrentView.FocusedRowHandle)

                                End If

                                e.Handled = True

                            End If

                        End If

                End Select

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
