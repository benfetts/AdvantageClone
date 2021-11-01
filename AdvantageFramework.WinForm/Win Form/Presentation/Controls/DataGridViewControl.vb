Namespace WinForm.Presentation.Controls

    Public Class DataGridView
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

        Public Event SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event BeforeSelectionChangedEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Public Event LoadGridColumnComboBoxEvent(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)
        Public Event CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Public Event CellValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Public Event RowDoubleClickEvent()
        'Public Event RowUpdatedEvent(ByVal RowHandle As Integer)
        Public Event ColumnAddedEvent(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)
        Public Event ColumnChangedEvent(sender As Object, e As System.EventArgs)
        Public Event ColumnPositionChangedEvent(sender As Object, e As System.EventArgs)
        Public Event AsyncCompletedEvent(sender As Object, e As System.EventArgs)
        Public Event CustomRowFilterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs)
        Public Event ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs)
        Public Event InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event CreateReportHeaderAreaEvent(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs)
        Public Event CreateMarginalHeaderAreaEvent(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs)
        Public Event AddNewRowEvent(ByVal RowObject As Object)
        Public Event BeforeAddNewRowEvent(ByVal RowObject As Object, ByRef Cancel As Boolean)
        Public Event MasterRowGetChildListEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs)
        Public Event MasterRowGetRelationNameEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs)
        Public Event MasterRowGetRelationCountEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs)
        Public Event MasterRowEmptyEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs)
        Public Event MasterRowGetRelationDisplayCaptionEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs)
        Public Event MasterRowGetLevelDefaultViewEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs)
        Public Event MasterRowExpandedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs)
        Public Event ShownEditorEvent(sender As Object, e As System.EventArgs)
        Public Event HiddenEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event SubItemTextBoxButtonClickEvent(ByVal RowObject As Object)
        Public Event MasterRowCollapsingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs)
        Public Event MasterRowCollapsedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs)
        Public Event EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Public Event LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs)
        Public Event CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs)
        Public Event TopRowChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event ColumnFilterChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CustomColumnSortEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs)
        Public Event RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Public Event CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs)
        Public Event NewItemRowCellValueChangingEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Public Event NewItemRowCellValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        'Public Event ColumnEditValueChangedEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Public Event ShowingEditorEvent(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Public Event CustomDrawCellEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
        Public Event CustomColumnDisplayTextEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        Public Event RowClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)
        Public Event NewItemRowCanceledEvent()
        Public Event RowCountChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event DataSourceChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event NeedQueryableDataSourceEvent(ByRef DbContext As AdvantageFramework.Database.DbContext, ByRef DataSource As Object)
        Public Event PopupMenuShowingEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Public Event RepositoryDataSourceLoading(ByVal FieldName As String, ByRef Cancel As Boolean)
        Public Event QueryPopupNeedDatasourceEvent(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)
        Public Event ColumnValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ByVal ViaCellValueChangedEvent As Boolean)
        Public Event CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs)
        Public Event LoadingDataSourceView(ByRef CustomViewNumber As Short)
        Public Event RowCellClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs)
        Public Event RowCellDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs)
        Public Event CustomUnboundColumnDataEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        Public Event CustomDrawRowIndicatorEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs)
        Public Event ColumnWidthChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs)
        Public Event ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs)
        Public Event DataSourceAddNewRowEvent(ByVal RowObject As Object)
        Public Event CustomDrawColumnHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs)
        Public Event GridViewMouseDownEvent(sender As Object, e As Windows.Forms.MouseEventArgs)
        Public Event CellMergeEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs)
        Public Event SelectAllEvent()
        Public Event DeselectAllEvent()
        Public Event ShowCustomizationFormEvent(sender As Object, e As EventArgs)
        Public Event HideCustomizationFormEvent(sender As Object, e As EventArgs)
        Public Event CanAutoFillValueEvent(ByRef CanAutoFillValue As Boolean, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)
        Public Event GotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event LostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CustomDrawFooterCellEvent(ByVal e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs)
        Public Event PopupMenuClosing()
        Public Event FocusedColumnChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs)
        Public Event DragAndDropRowsEvent(ByVal TargetRowHandle As Object, ByVal RowHandles() As Integer)
        Public Event GridViewKeyDownEvent(sender As Object, e As Windows.Forms.KeyEventArgs)
        Public Event DragObjectOverEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs)
        Public Event CustomDrawFooterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            DatabaseProfile
            DynamicReport
            EditableGrid
            NonEditableGrid
        End Enum

        Public Enum DataSourceViewOptions
            [Default]
            Job_CodeAndDescriptionCombined
            JobComp_CodeAndDescriptionCombined
            AccountPayable_CodeAndDescriptionCombined
            Ad_CodeAndDescriptionCombined
            VendorContact_WithExtraContactInfo
            GeneralLedgerAccount_CodeAndDescriptionSeparated
            Division_ExcludeClient
            Product_ExcludeClientDivision
            StandardComment_ExportInfo
            Employee_WithTerminatedColumn
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.Default
        Protected _BookmarkColumnIndex As Integer = -1
        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _CurrentBookmark As Object = Nothing
        Protected _NextBookmark As Object = Nothing
        Protected _ItemDescription As String = ""
        Protected _CustomDeleteButton As DevExpress.XtraEditors.NavigatorCustomButton = Nothing
        Protected _CustomCancelEditButton As DevExpress.XtraEditors.NavigatorCustomButton = Nothing
        Protected _UseEmbeddedNavigator As Boolean = False
        Protected WithEvents _BindingSource As System.Windows.Forms.BindingSource = Nothing
        Protected _BindingSourcePositionChanged As Boolean = False
        Protected _IsFirstLoad As Boolean = True
        Protected _PreviousPosition As Integer = -1
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _InstantFeedbackSource As Object = Nothing
        Protected _SuspendedForLoading As Boolean = False
        Protected _AllowSelectGroupHeaderRow As Boolean = True
        Protected _AlwaysForceShowRowSelectionOnUserInput As Boolean = True
        Protected _DataSourceViewOption As AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions = DataSourceViewOptions.Default
        Protected _AutoUpdateViewCaption As Boolean = True
        Protected _ShowColumnMenuOnRightClick As Boolean = False
        Protected _ChangesAutoSaved As Boolean = False
        Protected _AddFixedColumnCheckItemsToGridMenu As Boolean = False
        Protected _AllowDragAndDrop As Boolean = False
        Protected _DragAndDropGridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

#End Region

#Region " Properties "

        Public Property AutoUpdateViewCaption As Boolean
            Get
                AutoUpdateViewCaption = _AutoUpdateViewCaption
            End Get
            Set(value As Boolean)
                _AutoUpdateViewCaption = value
            End Set
        End Property
        Public Property AllowExtraItemsInGridLookupEdits As Boolean
            Get
                AllowExtraItemsInGridLookupEdits = GridViewGridControl_MainView.AllowExtraItemsInGridLookupEdits
            End Get
            Set(value As Boolean)
                GridViewGridControl_MainView.AllowExtraItemsInGridLookupEdits = value
            End Set
        End Property
        Public Property RunStandardValidation As Boolean
            Get
                RunStandardValidation = GridViewGridControl_MainView.RunStandardValidation
            End Get
            Set(value As Boolean)
                GridViewGridControl_MainView.RunStandardValidation = value
            End Set
        End Property
        Public Property AlwaysForceShowRowSelectionOnUserInput As Boolean
            Get
                AlwaysForceShowRowSelectionOnUserInput = _AlwaysForceShowRowSelectionOnUserInput
            End Get
            Set(value As Boolean)
                _AlwaysForceShowRowSelectionOnUserInput = value
            End Set
        End Property
        Public Property AutoFilterLookupColumns As Boolean
            Get
                AutoFilterLookupColumns = GridViewGridControl_MainView.AutoFilterLookupColumns
            End Get
            Set(value As Boolean)
                GridViewGridControl_MainView.AutoFilterLookupColumns = value
            End Set
        End Property
        Public Property AutoloadRepositoryDatasource As Boolean
            Get
                AutoloadRepositoryDatasource = GridViewGridControl_MainView.AutoloadRepositoryDatasource
            End Get
            Set(value As Boolean)
                GridViewGridControl_MainView.AutoloadRepositoryDatasource = value
            End Set
        End Property
        Public Property FilterPopupMode As DevExpress.XtraGrid.Columns.FilterPopupMode
            Get
                FilterPopupMode = GridViewGridControl_MainView.FilterPopupMode
            End Get
            Set(ByVal value As DevExpress.XtraGrid.Columns.FilterPopupMode)
                GridViewGridControl_MainView.FilterPopupMode = value
            End Set
        End Property
        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get
                UserEntryChanged = _UserEntryChanged
            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)
                _ByPassUserEntryChanged = value
            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
            End Set
        End Property
        Public Property ViewCaptionHeight() As Integer
            Get
                ViewCaptionHeight = GridViewGridControl_MainView.ViewCaptionHeight
            End Get
            Set(ByVal value As Integer)
                GridViewGridControl_MainView.ViewCaptionHeight = value
            End Set
        End Property
        Public Property ShowSelectDeselectAllButtons() As Boolean
            Get
                ShowSelectDeselectAllButtons = PanelControl_BottomPanel.Visible
            End Get
            Set(ByVal value As Boolean)
                PanelControl_BottomPanel.Visible = value
            End Set
        End Property
        Public Property ItemDescription() As String
            Get
                ItemDescription = _ItemDescription
            End Get
            Set(ByVal value As String)
                _ItemDescription = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public ReadOnly Property Columns() As DevExpress.XtraGrid.Columns.GridColumnCollection
            Get
                Columns = GridViewGridControl_MainView.Columns
            End Get
        End Property
        Public Property ControlType() As AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type)
                _ControlType = value
                SetupDataGrid()
            End Set
        End Property
        Public Property MultiSelect() As Boolean
            Get
                MultiSelect = GridViewGridControl_MainView.OptionsSelection.MultiSelect
            End Get
            Set(ByVal value As Boolean)
                GridViewGridControl_MainView.OptionsSelection.MultiSelect = value
            End Set
        End Property
        Public Property NewItemRowPosition() As DevExpress.XtraGrid.Views.Grid.NewItemRowPosition
            Get
                NewItemRowPosition = GridViewGridControl_MainView.OptionsView.NewItemRowPosition
            End Get
            Set(ByVal value As DevExpress.XtraGrid.Views.Grid.NewItemRowPosition)
                GridViewGridControl_MainView.OptionsView.NewItemRowPosition = value
            End Set
        End Property
        Public ReadOnly Property HasOnlyOneSelectedRow(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get

                HasOnlyOneSelectedRow = (GridViewGridControl_MainView.SelectedRowsCount = 1)

                If ExcludeNonDataRows AndAlso HasOnlyOneSelectedRow Then

                    HasOnlyOneSelectedRow = GridViewGridControl_MainView.IsDataRow(GridViewGridControl_MainView.FocusedRowHandle)

                End If

            End Get
        End Property
        Public ReadOnly Property HasOnlyNewItemRowSelected() As Boolean
            Get
                HasOnlyNewItemRowSelected = (GridViewGridControl_MainView.IsNewItemRow(GridViewGridControl_MainView.FocusedRowHandle) AndAlso
                                                GridViewGridControl_MainView.SelectedRowsCount = 1)
            End Get
        End Property
        Public ReadOnly Property HasOnlyAutoFilterSelectedRow() As Boolean
            Get
                HasOnlyAutoFilterSelectedRow = (GridViewGridControl_MainView.IsFilterRow(GridViewGridControl_MainView.FocusedRowHandle) AndAlso
                                                GridViewGridControl_MainView.SelectedRowsCount = 1)
            End Get
        End Property
        Public ReadOnly Property HasMultipleSelectedRows(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get

                'objects
                Dim SelectedRowsList As Generic.List(Of Integer) = Nothing

                HasMultipleSelectedRows = (GridViewGridControl_MainView.SelectedRowsCount > 1)

                If ExcludeNonDataRows AndAlso HasMultipleSelectedRows Then

                    SelectedRowsList = New Generic.List(Of Integer)

                    For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                        If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                            SelectedRowsList.Add(RowHandle)

                        End If

                    Next

                    HasMultipleSelectedRows = (SelectedRowsList.Count > 1)

                End If

            End Get
        End Property
        Public ReadOnly Property HasASelectedRow(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get

                'objects
                Dim SelectedRowsList As Generic.List(Of Integer) = Nothing

                HasASelectedRow = (GridViewGridControl_MainView.SelectedRowsCount > 0)

                If ExcludeNonDataRows AndAlso HasASelectedRow Then

                    SelectedRowsList = New Generic.List(Of Integer)

                    For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                        If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                            SelectedRowsList.Add(RowHandle)

                        End If

                    Next

                    HasASelectedRow = SelectedRowsList.Any

                End If

            End Get
        End Property
        Public ReadOnly Property HasRows() As Boolean
            Get
                HasRows = (GridViewGridControl_MainView.DataRowCount > 0)
            End Get
        End Property
        Public Property DataSource() As Object
            Get
                DataSource = DataGridView_GridControl.DataSource
            End Get
            Set(ByVal value As Object)
                LoadDataSource(value)
            End Set
        End Property
        Public ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                BindingSource = DirectCast(DataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource)
            End Get
        End Property
        Public ReadOnly Property OptionsBehavior As DevExpress.XtraGrid.Views.Grid.GridOptionsBehavior
            Get
                OptionsBehavior = Me.GridViewGridControl_MainView.OptionsBehavior
            End Get
        End Property
        Public ReadOnly Property OptionsCustomization As DevExpress.XtraGrid.Views.Grid.GridOptionsCustomization
            Get
                OptionsCustomization = Me.GridViewGridControl_MainView.OptionsCustomization
            End Get
        End Property
        Public ReadOnly Property OptionsDetail As DevExpress.XtraGrid.Views.Grid.GridOptionsDetail
            Get
                OptionsDetail = Me.GridViewGridControl_MainView.OptionsDetail
            End Get
        End Property
        Public ReadOnly Property OptionsFilter As DevExpress.XtraGrid.Views.Base.ColumnViewOptionsFilter
            Get
                OptionsFilter = Me.GridViewGridControl_MainView.OptionsFilter
            End Get
        End Property
        Public ReadOnly Property OptionsFind As DevExpress.XtraGrid.Views.Base.ColumnViewOptionsFind
            Get
                OptionsFind = Me.GridViewGridControl_MainView.OptionsFind
            End Get
        End Property
        Public ReadOnly Property OptionsLayout As DevExpress.Utils.OptionsLayoutGrid
            Get
                OptionsLayout = Me.GridViewGridControl_MainView.OptionsLayout
            End Get
        End Property
        Public ReadOnly Property OptionsHint As DevExpress.XtraGrid.Views.Grid.GridOptionsHint
            Get
                OptionsHint = Me.GridViewGridControl_MainView.OptionsHint
            End Get
        End Property
        Public ReadOnly Property OptionsMenu As DevExpress.XtraGrid.Views.Grid.GridOptionsMenu
            Get
                OptionsMenu = Me.GridViewGridControl_MainView.OptionsMenu
            End Get
        End Property
        Public ReadOnly Property OptionsNavigation As DevExpress.XtraGrid.Views.Grid.GridOptionsNavigation
            Get
                OptionsNavigation = Me.GridViewGridControl_MainView.OptionsNavigation
            End Get
        End Property
        Public ReadOnly Property OptionsPrint As DevExpress.XtraGrid.Views.Grid.GridOptionsPrint
            Get
                OptionsPrint = Me.GridViewGridControl_MainView.OptionsPrint
            End Get
        End Property
        Public ReadOnly Property OptionsSelection As DevExpress.XtraGrid.Views.Grid.GridOptionsSelection
            Get
                OptionsSelection = Me.GridViewGridControl_MainView.OptionsSelection
            End Get
        End Property
        Public ReadOnly Property OptionsView As DevExpress.XtraGrid.Views.Grid.GridOptionsView
            Get
                OptionsView = Me.GridViewGridControl_MainView.OptionsView
            End Get
        End Property
        Public ReadOnly Property GridControl As AdvantageFramework.WinForm.Presentation.Controls.GridControl
            Get
                GridControl = Me.DataGridView_GridControl
            End Get
        End Property
        Public ReadOnly Property CurrentView As AdvantageFramework.WinForm.Presentation.Controls.GridView
            Get
                CurrentView = Me.GridViewGridControl_MainView
            End Get
        End Property
        Public Property UseEmbeddedNavigator As Boolean
            Get
                UseEmbeddedNavigator = _UseEmbeddedNavigator
            End Get
            Set(ByVal value As Boolean)
                _UseEmbeddedNavigator = UseEmbeddedNavigator
                SetupEmbeddedNavigator(value)
            End Set
        End Property
        Public ReadOnly Property EmbeddedNavigator As DevExpress.XtraEditors.ControlNavigator
            Get
                EmbeddedNavigator = Me.GridControl.EmbeddedNavigator
            End Get
        End Property
        Public ReadOnly Property CustomDeleteButton As DevExpress.XtraEditors.NavigatorCustomButton
            Get
                CustomDeleteButton = _CustomDeleteButton
            End Get
        End Property
        Public ReadOnly Property CustomCancelEditButton As DevExpress.XtraEditors.NavigatorCustomButton
            Get
                CustomCancelEditButton = _CustomCancelEditButton
            End Get
        End Property
        Public Property AllowSelectGroupHeaderRow As Boolean
            Get
                AllowSelectGroupHeaderRow = _AllowSelectGroupHeaderRow
            End Get
            Set(value As Boolean)
                _AllowSelectGroupHeaderRow = value
            End Set
        End Property
        Public Property DataSourceViewOption As AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions
            Get
                DataSourceViewOption = _DataSourceViewOption
            End Get
            Set(value As AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions)
                _DataSourceViewOption = value
            End Set
        End Property
        Public Property ShowColumnMenuOnRightClick As Boolean
            Get
                ShowColumnMenuOnRightClick = _ShowColumnMenuOnRightClick
            End Get
            Set(value As Boolean)
                _ShowColumnMenuOnRightClick = value
            End Set
        End Property
        Public Property AddFixedColumnCheckItemsToGridMenu As Boolean
            Get
                AddFixedColumnCheckItemsToGridMenu = _AddFixedColumnCheckItemsToGridMenu
            End Get
            Set(value As Boolean)
                _AddFixedColumnCheckItemsToGridMenu = value
            End Set
        End Property
        Public Property AllowDragAndDrop As Boolean
            Get
                AllowDragAndDrop = _AllowDragAndDrop
            End Get
            Set(value As Boolean)
                _AllowDragAndDrop = value

                If _AllowDragAndDrop Then

                    Me.AllowDrop = True
                    Me.GridControl.AllowDrop = True

                Else

                    Me.AllowDrop = False
                    Me.GridControl.AllowDrop = False

                End If

            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DoubleBuffered = True

            _ItemDescription = "Item(s)"

            SetHeaderText()

            GridViewGridControl_MainView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always

        End Sub
        Public Shadows Sub SetStyle(ByVal Style As System.Windows.Forms.ControlStyles, value As Boolean)

            MyBase.SetStyle(Style, value)

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

            Try

                GridViewGridControl_MainView.ClearChanged()

            Catch ex As Exception

            End Try

        End Sub
        Public Function IsNewItemOrAutoFilterRow(ByVal RowHandle As Integer) As Boolean

            IsNewItemOrAutoFilterRow = GridViewGridControl_MainView.IsNewItemOrAutoFilterRow(RowHandle)

        End Function
        Public Function IsNewItemOrAutoFilterRow() As Boolean

            IsNewItemOrAutoFilterRow = GridViewGridControl_MainView.IsNewItemOrAutoFilterRow()

        End Function
        Public Function IsNewItemRow(ByVal RowHandle As Integer) As Boolean

            IsNewItemRow = GridViewGridControl_MainView.IsNewItemRow(RowHandle)

        End Function
        Public Function IsNewItemRow() As Boolean

            IsNewItemRow = GridViewGridControl_MainView.IsNewItemRow(GridViewGridControl_MainView.FocusedRowHandle)

        End Function
        Public Sub ClearDatasource(Optional ByVal DefaultList As Object = Nothing)

            GridViewGridControl_MainView.DataSourceClearing = True

            If _ControlType = Type.EditableGrid AndAlso Me.NewItemRowPosition <> DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None Then

                Me.CancelNewItemRow()

            End If

            Me.DataSource = DefaultList

            GridViewGridControl_MainView.DataSourceClearing = False

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                GridViewGridControl_MainView.Session = _Session

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Friend Function CustomValidate(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try

                IsValid = Not Me.HasAnyInvalidRows

                If IsValid = False Then

                    ErrorMessage = "Please fix invalid rows"

                End If

            Catch ex As Exception
                IsValid = True
            Finally
                CustomValidate = IsValid
            End Try

        End Function
        Protected Sub SetupEmbeddedNavigator(ByVal UseEmbeddedNavigator As Boolean)

            Dim DeleteCustomButton As DevExpress.XtraEditors.NavigatorCustomButton = Nothing
            Dim CancelEditCustomButton As DevExpress.XtraEditors.NavigatorCustomButton = Nothing

            DataGridView_GridControl.UseEmbeddedNavigator = UseEmbeddedNavigator

            AddHandler DataGridView_GridControl.EmbeddedNavigator.ButtonClick, AddressOf GridViewGridControl_EmbeddedNavigator_ButtonClick

            DataGridView_GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
            DataGridView_GridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
            DataGridView_GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
            DataGridView_GridControl.EmbeddedNavigator.Buttons.PrevPage.Visible = False
            DataGridView_GridControl.EmbeddedNavigator.Buttons.Prev.Visible = False
            DataGridView_GridControl.EmbeddedNavigator.Buttons.NextPage.Visible = False
            DataGridView_GridControl.EmbeddedNavigator.Buttons.Next.Visible = False
            DataGridView_GridControl.EmbeddedNavigator.Buttons.Last.Visible = False
            DataGridView_GridControl.EmbeddedNavigator.Buttons.First.Visible = False
            DataGridView_GridControl.EmbeddedNavigator.Buttons.Append.Visible = False
            DataGridView_GridControl.EmbeddedNavigator.Buttons.Remove.Visible = False

            DataGridView_GridControl.EmbeddedNavigator.Buttons.CustomButtons.Clear()

            DeleteCustomButton = DataGridView_GridControl.EmbeddedNavigator.Buttons.CustomButtons.Add()

            DeleteCustomButton.Tag = DevExpress.XtraEditors.NavigatorButtonType.Remove
            DeleteCustomButton.Enabled = Me.HasASelectedRow
            DeleteCustomButton.Hint = "Delete"
            DeleteCustomButton.ImageIndex = CInt(DevExpress.XtraEditors.NavigatorButtonType.CancelEdit - 1)

            _CustomDeleteButton = DeleteCustomButton

            CancelEditCustomButton = DataGridView_GridControl.EmbeddedNavigator.Buttons.CustomButtons.Add()

            CancelEditCustomButton.Tag = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit
            CancelEditCustomButton.Enabled = False
            CancelEditCustomButton.Hint = "Cancel"
            CancelEditCustomButton.ImageIndex = CInt(DevExpress.XtraEditors.NavigatorButtonType.Remove - 1)

            _CustomCancelEditButton = CancelEditCustomButton

            DataGridView_GridControl.EmbeddedNavigator.TextStringFormat = ""

        End Sub
        Protected Overridable Sub SetupDataGrid()

            GridViewGridControl_MainView.ControlType = _ControlType

            Select Case _ControlType

                Case Type.Default

                    _BookmarkColumnIndex = -1
                    _ByPassUserEntryChanged = True

                Case Type.DatabaseProfile

                    _BookmarkColumnIndex = 0

                    AdvantageFramework.WinForm.Presentation.Controls.AddColumn(AdvantageFramework.Database.DatabaseProfile.Properties.DatabaseServer, Me)
                    AdvantageFramework.WinForm.Presentation.Controls.AddColumn(AdvantageFramework.Database.DatabaseProfile.Properties.DatabaseName, Me)
                    AdvantageFramework.WinForm.Presentation.Controls.AddColumn(AdvantageFramework.Database.DatabaseProfile.Properties.DatabaseUserName, Me)
                    AdvantageFramework.WinForm.Presentation.Controls.AddColumn(AdvantageFramework.Database.DatabaseProfile.Properties.EnableServices, Me)

                    Me.CurrentView.Columns(AdvantageFramework.Database.DatabaseProfile.Properties.DatabaseServer.ToString).OptionsColumn.ReadOnly = True
                    Me.CurrentView.Columns(AdvantageFramework.Database.DatabaseProfile.Properties.DatabaseName.ToString).OptionsColumn.ReadOnly = True
                    Me.CurrentView.Columns(AdvantageFramework.Database.DatabaseProfile.Properties.DatabaseUserName.ToString).OptionsColumn.ReadOnly = True

                    _ByPassUserEntryChanged = True

                Case Type.DynamicReport

                    _BookmarkColumnIndex = -1
                    GridViewGridControl_MainView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded
                    _ByPassUserEntryChanged = True

                Case Type.EditableGrid

                    _BookmarkColumnIndex = 0
                    GridViewGridControl_MainView.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled

                Case Type.NonEditableGrid

                    _BookmarkColumnIndex = 0
                    _ByPassUserEntryChanged = True

            End Select

        End Sub
        Protected Function LoadDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent)) As Object

            LoadDataSourceView = (From JobComponent In JobComponents.ToList
                                  Select JobComponent.ID,
                                         JobComponent.JobNumber,
                                         JobComponent.JobDescription,
                                         [JobComponentNumber] = AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.JobComponentNumber.ToString, 2, "0", True, False),
                                         JobComponent.JobComponentDescription,
                                         JobComponent.SalesClassCode,
                                         JobComponent.SalesClassDescription,
                                         [ServiceFeeFlag] = CBool(JobComponent.ServiceFeeFlag.GetValueOrDefault(0)),
                                         JobComponent.ServiceFeeTypeCode,
                                         JobComponent.ServiceFeeTypeDescription,
                                         JobComponent.OfficeCode,
                                         JobComponent.OfficeName,
                                         JobComponent.ClientCode,
                                         JobComponent.ClientName,
                                         JobComponent.DivisionCode,
                                         JobComponent.DivisionName,
                                         JobComponent.ProductCode,
                                         JobComponent.ProductName).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal PurchaseOrders As IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrder)) As Object

            LoadDataSourceView = (From PurchaseOrder In PurchaseOrders
                                  Select New With {.Number = PurchaseOrder.Number,
                                                   .Description = PurchaseOrder.Description,
                                                   .IsVoid = CBool(PurchaseOrder.IsVoid.GetValueOrDefault(0)),
                                                   .IsComplete = CBool(PurchaseOrder.IsComplete.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal PurchaseOrders As IEnumerable(Of AdvantageFramework.Database.Classes.PurchaseOrderComplex)) As Object

            LoadDataSourceView = (From PurchaseOrder In PurchaseOrders
                                  Select New With {.Number = PurchaseOrder.Number,
                                                   .DisplayPONumber = PurchaseOrder.DisplayPONumber,
                                                   .Description = PurchaseOrder.Description,
                                                   .EmployeeCode = PurchaseOrder.EmployeeCode,
                                                   .VendorCode = PurchaseOrder.VendorCode,
                                                   .PODate = PurchaseOrder.PODate,
                                                   .PODueDate = PurchaseOrder.PODueDate,
                                                   .IsVoid = CBool(PurchaseOrder.IsVoid.GetValueOrDefault(0)),
                                                   .IsComplete = CBool(PurchaseOrder.IsComplete.GetValueOrDefault(0)),
                                                   .SortOrder = PurchaseOrder.SortOrder}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal PurchaseOrderDetails As IEnumerable(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailsComplex)) As Object

            LoadDataSourceView = (From PurchaseOrderDetail In PurchaseOrderDetails
                                  Select New With {.PONumber = PurchaseOrderDetail.PONumber,
                                                   .DisplayPONumber = PurchaseOrderDetail.DisplayPONumber,
                                                   .PODescription = PurchaseOrderDetail.PODescription,
                                                   .ClientCode = PurchaseOrderDetail.ClientCode,
                                                   .DivisionCode = PurchaseOrderDetail.DivisionCode,
                                                   .ProductCode = PurchaseOrderDetail.ProductCode,
                                                   .JobNumber = PurchaseOrderDetail.JobNumber,
                                                   .JobComponentNumber = PurchaseOrderDetail.JobComponentNumber,
                                                   .LineTotal = PurchaseOrderDetail.LineTotal,
                                                   .IsAttachedToAP = PurchaseOrderDetail.IsAttachedToAP.GetValueOrDefault(False),
                                                   .VoidFlag = CBool(PurchaseOrderDetail.VoidFlag.GetValueOrDefault(0)),
                                                   .POComplete = CBool(PurchaseOrderDetail.POComplete.GetValueOrDefault(0)),
                                                   .SortOrder = PurchaseOrderDetail.SortOrder}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal GLAllocations As IEnumerable(Of AdvantageFramework.Database.Classes.GLAllocation)) As Object

            LoadDataSourceView = (From GLAllocation In GLAllocations
                                  Select New With {.GLAccountCode = GLAllocation.GLAccountCode,
                                                   .GLAccountDescription = GLAllocation.GLAccountDescription,
                                                   .Status = GLAllocation.Status,
                                                   .Comment = GLAllocation.Comment}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal AccountGroups As IEnumerable(Of AdvantageFramework.Database.Entities.AccountGroup)) As Object

            LoadDataSourceView = (From AccountGroup In AccountGroups
                                  Select New With {.Code = AccountGroup.Code,
                                                   .Description = AccountGroup.Description,
                                                   .Type = AccountGroup.Type}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ServiceFeeTypes As IEnumerable(Of AdvantageFramework.Database.Entities.ServiceFeeType)) As Object

            LoadDataSourceView = (From ServiceFeeType In ServiceFeeTypes.ToList
                                  Select ServiceFeeType.ID,
                                         ServiceFeeType.Code,
                                         ServiceFeeType.Description,
                                         ServiceFeeType.IsInactive).ToList

            _BookmarkColumnIndex = 1

        End Function
        Protected Function LoadDataSourceView(ByVal PostPeriods As IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)) As Object

            LoadDataSourceView = (From PostPeriod In PostPeriods
                                  Select New With {.Code = PostPeriod.Code,
                                                   .Description = PostPeriod.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee)) As Object

            If DataSourceViewOption = DataSourceViewOptions.Employee_WithTerminatedColumn Then

                LoadDataSourceView = (From Employee In Employees
                                      Select Employee.Code,
                                             Employee.FirstName,
                                             Employee.MiddleInitial,
                                             Employee.LastName,
                                             Employee.TerminationDate).ToList.Select(Function(Entity) New With {.[Code] = Entity.Code,
                                                                                                                .[Name] = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                                .[Terminated] = If(Entity.TerminationDate Is Nothing, False, True)}).ToList

                _BookmarkColumnIndex = 0

            Else

                LoadDataSourceView = (From Employee In Employees
                                      Select Employee.Code,
                                             Employee.FirstName,
                                             Employee.MiddleInitial,
                                             Employee.LastName,
                                             OfficeName = If(Employee.Office IsNot Nothing, Employee.Office.Name, Nothing),
                                             Employee.OfficeCode).ToList.Select(Function(Entity) New With {.[Code] = Entity.Code,
                                                                                                           .[Name] = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                           .[OfficeCode] = Entity.OfficeCode,
                                                                                                           .[OfficeName] = Entity.OfficeName}).ToList

                _BookmarkColumnIndex = 0

            End If

        End Function
        Protected Function LoadDataSourceView(ByVal AccountPayableInvoiceFromRecurs As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur)) As Object

            LoadDataSourceView = (From AccountPayableInvoiceFromRecur In AccountPayableInvoiceFromRecurs
                                  Select AccountPayableInvoiceFromRecur.AccountPayableRecurID,
                                         AccountPayableInvoiceFromRecur.VendorCode,
                                         AccountPayableInvoiceFromRecur.VendorName,
                                         AccountPayableInvoiceFromRecur.InvoiceNumber,
                                         AccountPayableInvoiceFromRecur.InvoiceAmount,
                                         AccountPayableInvoiceFromRecur.NumberRemaining,
                                         AccountPayableInvoiceFromRecur.UnlimitedPostings,
                                         AccountPayableInvoiceFromRecur.CreateAP,
                                         AccountPayableInvoiceFromRecur.APCreatedForPostPeriod,
                                         AccountPayableInvoiceFromRecur.InvoiceDate,
                                         AccountPayableInvoiceFromRecur.DatePosted,
                                         AccountPayableInvoiceFromRecur.StartPostPeriod,
                                         AccountPayableInvoiceFromRecur.CycleCode,
                                         AccountPayableInvoiceFromRecur.LastLogPostPeriod).ToList.Select(Function(Entity) New With {.AccountPayableRecurID = Entity.AccountPayableRecurID,
                                                                                                                                    .VendorCode = Entity.VendorCode,
                                                                                                                                    .VendorName = Entity.VendorName,
                                                                                                                                    .InvoiceNumber = Entity.InvoiceNumber,
                                                                                                                                    .InvoiceAmount = Entity.InvoiceAmount,
                                                                                                                                    .NumberRemaining = Entity.NumberRemaining,
                                                                                                                                    .UnlimitedPostings = CBool(Entity.UnlimitedPostings),
                                                                                                                                    .CreateAP = CBool(Entity.CreateAP),
                                                                                                                                    .APCreatedForPostPeriod = CBool(Entity.APCreatedForPostPeriod),
                                                                                                                                    .InvoiceDate = Entity.InvoiceDate,
                                                                                                                                    .DatePosted = Entity.DatePosted,
                                                                                                                                    .StartPostPeriod = Entity.StartPostPeriod,
                                                                                                                                    .CycleCode = Entity.CycleCode,
                                                                                                                                    .LastLogPostPeriod = Entity.LastLogPostPeriod}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Entities.Office)) As Object

            LoadDataSourceView = (From Office In Offices
                                  Select Office.Code,
                                         Office.Name,
                                         Office.IsInactive).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                     .Name = Entity.Name,
                                                                                                     .[IsInactive] = CBool(Entity.IsInactive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Functions As IEnumerable(Of AdvantageFramework.Database.Entities.Function)) As Object

            LoadDataSourceView = (From [Function] In Functions.ToList
                                  Select [Function].Code,
                                         [Function].Description,
                                         [Function].Type,
                                         [IsInactive] = CBool([Function].IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Functions As IEnumerable(Of AdvantageFramework.Database.Views.FunctionView)) As Object

            LoadDataSourceView = (From [Function] In Functions.ToList
                                  Select [Function].Code,
                                         [Function].Description,
                                         [Function].Type,
                                         [IsInactive] = CBool([Function].IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Departments As IEnumerable(Of AdvantageFramework.Database.Entities.DepartmentTeam)) As Object

            LoadDataSourceView = (From Department In Departments.ToList
                                  Select Department.Code,
                                         Department.Description,
                                         [IsInactive] = CBool(Department.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Roles As IEnumerable(Of AdvantageFramework.Database.Entities.Role)) As Object

            LoadDataSourceView = (From Role In Roles.ToList
                                  Select Role.Code,
                                         Role.Description,
                                         [IsInactive] = CBool(Role.IsInactive)).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal DynamicReports As IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.DynamicReport)) As Object

            LoadDataSourceView = (From DynamicReport In DynamicReports.ToList
                                  Select DynamicReport.ID,
                                         DynamicReport.UserDefinedReportCategoryID,
                                         [ReportCategory] = If(DynamicReport.UserDefinedReportCategory IsNot Nothing, DynamicReport.UserDefinedReportCategory.Description, ""),
                                         DynamicReport.Description,
                                         [Type] = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Reporting.DynamicReports), DynamicReport.Type),
                                         [CreatedBy] = DynamicReport.CreatedByUserCode,
                                         DynamicReport.CreatedDate,
                                         [UpdatedBy] = DynamicReport.UpdatedByUserCode,
                                         DynamicReport.UpdatedDate).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.Type).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Groups As IEnumerable(Of AdvantageFramework.Security.Database.Entities.Group)) As Object

            LoadDataSourceView = (From Group In Groups
                                  Select New With {.ID = Group.ID,
                                                   .Name = Group.Name,
                                                   .Description = Group.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Users As IEnumerable(Of AdvantageFramework.Security.Database.Entities.User)) As Object

            LoadDataSourceView = (From User In Users.ToList
                                  Select User.ID,
                                         User.UserCode,
                                         User.UserName,
                                         User.IsInactive,
                                         User.EmployeeCode,
                                         User.Employee,
                                         User.Employee.Department,
                                         User.Employee.Office).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                        .UserCode = Entity.UserCode,
                                                                                                        .UserName = Entity.UserName,
                                                                                                        .Inactive = Entity.IsInactive,
                                                                                                        .EmployeeCode = Entity.EmployeeCode,
                                                                                                        .EmployeeName = Entity.Employee.ToString,
                                                                                                        .IsEmployeeTerminated = If(Entity.Employee.TerminationDate Is Nothing, False, True),
                                                                                                        .OfficeCode = If(Entity.Office Is Nothing, Nothing, Entity.Office.Code),
                                                                                                        .OfficeName = If(Entity.Office Is Nothing, Nothing, Entity.Office.Name),
                                                                                                        .DepartmentCode = If(Entity.Department Is Nothing, Nothing, If(Convert.ToString(Entity.Department) = System.String.Empty, Nothing, Entity.Department.Code)),
                                                                                                        .DepartmentName = If(Entity.Department Is Nothing, Nothing, If(Convert.ToString(Entity.Department) = System.String.Empty, Nothing, Entity.Department.Description))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal PurchaseOrderApprovalRules As IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule)) As Object

            LoadDataSourceView = (From PurchaseOrderApprovalRule In PurchaseOrderApprovalRules.ToList
                                  Select PurchaseOrderApprovalRule.Code,
                                         PurchaseOrderApprovalRule.Description,
                                         [IsInactive] = CBool(PurchaseOrderApprovalRule.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal EmployeeTitles As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle)) As Object

            LoadDataSourceView = (From EmployeeTitle In EmployeeTitles.ToList
                                  Select EmployeeTitle.ID,
                                         EmployeeTitle.Description,
                                         [IsInactive] = CBool(EmployeeTitle.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Entities.Client)) As Object

            LoadDataSourceView = (From Client In Clients
                                  Select Client.Code,
                                         Client.Name,
                                         Client.IsNewBusiness,
                                         Client.IsActive).ToList.Select(Function(Client) New With {.Code = Client.Code,
                                                                                                   .Name = Client.Name,
                                                                                                   .IsNewBusiness = CBool(Client.IsNewBusiness.GetValueOrDefault(0)),
                                                                                                   .IsInactive = Not CBool(Client.IsActive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Campaigns As IEnumerable(Of AdvantageFramework.Database.Entities.Campaign)) As Object

            LoadDataSourceView = (From Campaign In Campaigns
                                  Select New With {.ID = Campaign.ID,
                                                   .Code = If(Campaign.Code Is Nothing, "", Campaign.Code),
                                                   .Name = If(Campaign Is Nothing, "", Campaign.Name),
                                                   .OfficeCode = If(Campaign.OfficeCode Is Nothing, "", Campaign.OfficeCode),
                                                   .Office = If(Campaign.Office Is Nothing, "", Campaign.Office.Name),
                                                   .ClientCode = If(Campaign.ClientCode Is Nothing, "", Campaign.ClientCode),
                                                   .Client = If(Campaign.Client Is Nothing, "", Campaign.Client.Name),
                                                   .DivisionCode = If(Campaign.DivisionCode Is Nothing, "", Campaign.DivisionCode),
                                                   .Division = If(Campaign.Division Is Nothing, "", Campaign.Division.Name),
                                                   .ProductCode = If(Campaign.ProductCode Is Nothing, "", Campaign.ProductCode),
                                                   .Product = If(Campaign.Product Is Nothing, "", Campaign.Product.Name),
                                                   .IsClosed = CBool(Campaign.IsClosed.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal CampaignViews As IEnumerable(Of AdvantageFramework.Database.Views.CampaignView)) As Object

            LoadDataSourceView = (From CampaignView In CampaignViews
                                  Select New With {.ID = CampaignView.ID,
                                                   .CampaignCode = CampaignView.CampaignCode,
                                                   .CampaignName = CampaignView.CampaignName,
                                                   .OfficeCode = CampaignView.OfficeCode,
                                                   .OfficeName = CampaignView.OfficeName,
                                                   .ClientCode = CampaignView.ClientCode,
                                                   .ClientName = CampaignView.ClientName,
                                                   .DivisionCode = CampaignView.DivisionCode,
                                                   .DivisionName = CampaignView.DivisionName,
                                                   .ProductCode = CampaignView.ProductCode,
                                                   .ProductDescription = CampaignView.ProductDescription,
                                                   .IsClosed = CBool(CampaignView.IsClosed.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Campaigns As IEnumerable(Of AdvantageFramework.Database.Core.Campaign)) As Object

            LoadDataSourceView = (From Campaign In Campaigns
                                  Select New With {.ID = Campaign.ID,
                                                   .ClientCode = Campaign.ClientCode,
                                                   .DivisionCode = Campaign.DivisionCode,
                                                   .ProductCode = Campaign.ProductCode,
                                                   .Code = Campaign.Code,
                                                   .Name = Campaign.Name,
                                                   .IsClosed = CBool(Campaign.IsClosed.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Database.Core.Vendor)) As Object

            LoadDataSourceView = (From Vendor In Vendors
                                  Select New With {.Code = Vendor.Code,
                                                   .Name = Vendor.Name,
                                                   .VendorCategory = Vendor.VendorCategory,
                                                   .IsInactive = Not CBool(Vendor.ActiveFlag.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Core.Office)) As Object

            LoadDataSourceView = (From Office In Offices
                                  Select New With {.Code = Office.Code,
                                                   .Name = Office.Name,
                                                   .IsInactive = CBool(Office.IsInactive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal GLReportUserDefReports As IEnumerable(Of AdvantageFramework.Database.Entities.GLReportUserDefReport)) As Object

            LoadDataSourceView = (From GLReportUserDefReport In GLReportUserDefReports
                                  Select New With {.ID = GLReportUserDefReport.ID,
                                                   .Description = GLReportUserDefReport.Description,
                                                   .CreatedBy = GLReportUserDefReport.CreatedByUserCode,
                                                   .CreatedDate = GLReportUserDefReport.CreatedDate,
                                                   .ModifiedBy = GLReportUserDefReport.ModifiedByUserCode,
                                                   .ModifiedDate = GLReportUserDefReport.ModifiedDate}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal DepartmentTeams As IEnumerable(Of AdvantageFramework.Database.Core.DepartmentTeam)) As Object

            LoadDataSourceView = (From DepartmentTeam In DepartmentTeams
                                  Select New With {.Code = DepartmentTeam.Code,
                                                   .Description = DepartmentTeam.Description,
                                                   .IsInactive = CBool(DepartmentTeam.IsInactive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ExpenseReportDetails As IEnumerable(Of AdvantageFramework.Database.Entities.ExpenseReportDetail)) As Object

            LoadDataSourceView = (From ExpenseReportDetail In ExpenseReportDetails
                                  Select New With {.ID = ExpenseReportDetail.ID,
                                                   .ItemDate = ExpenseReportDetail.ItemDate,
                                                   .Description = ExpenseReportDetail.Description,
                                                   .ClientCode = ExpenseReportDetail.ClientCode,
                                                   .DivisionCode = ExpenseReportDetail.DivisionCode,
                                                   .ProductCode = ExpenseReportDetail.ProductCode,
                                                   .JobNumber = ExpenseReportDetail.JobNumber,
                                                   .JobComponentNumber = ExpenseReportDetail.JobComponentNumber,
                                                   .FunctionCode = ExpenseReportDetail.FunctionCode,
                                                   .Quantity = ExpenseReportDetail.Quantity,
                                                   .Rate = ExpenseReportDetail.Rate,
                                                   .Amount = ExpenseReportDetail.Amount}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Products As IEnumerable(Of AdvantageFramework.Security.Database.Entities.Product)) As Object

            LoadDataSourceView = (From Product In Products.ToList
                                  Select [OfficeCode] = Product.OfficeCode,
                                         [OfficeName] = Product.Office.Name,
                                         [ClientCode] = Product.ClientCode,
                                         [ClientName] = Product.Client.Name,
                                         [DivisionCode] = Product.DivisionCode,
                                         [DivisionName] = Product.Division.Name,
                                         [Code] = Product.Code,
                                         [ProductName] = Product.Name).ToList

            _BookmarkColumnIndex = 6

        End Function
        Protected Function LoadDataSourceView(ByVal UserClientDivisionProductAccesses As IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess)) As Object

            LoadDataSourceView = (From UserClientDivisionProductAccess In UserClientDivisionProductAccesses.ToList
                                  Select [Office] = UserClientDivisionProductAccess.Product.Office.ToString,
                                         [Client] = UserClientDivisionProductAccess.Product.Client.ToString,
                                         [Division] = UserClientDivisionProductAccess.Product.Division.ToString,
                                         [Product] = UserClientDivisionProductAccess.Product.ToString,
                                         [AllowTimeEntryOnly] = CBool(UserClientDivisionProductAccess.AllowTimeEntryOnly.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 3

        End Function
        Protected Function LoadDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Security.Database.Views.Employee)) As Object

            LoadDataSourceView = (From Employee In Employees
                                  Select Employee.Code,
                                         Employee.FirstName,
                                         Employee.MiddleInitial,
                                         Employee.LastName).ToList.Select(Function(Entity) New With {.[Code] = Entity.Code,
                                                                                                     .[Name] = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName)}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal UserEmployeeAccesses As IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserEmployeeAccess)) As Object

            LoadDataSourceView = (From UserEmployeeAccess In UserEmployeeAccesses.ToList
                                  Select [EmployeeCode] = UserEmployeeAccess.EmployeeCode,
                                         [EmployeeName] = UserEmployeeAccess.Employee.ToString).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal UserDefinedReports As IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReport)) As Object

            LoadDataSourceView = (From UserDefinedReport In UserDefinedReports.ToList
                                  Select UserDefinedReport.ID,
                                         [ReportCategory] = If(UserDefinedReport.UserDefinedReportCategory IsNot Nothing, UserDefinedReport.UserDefinedReportCategory.Description, ""),
                                         UserDefinedReport.Description,
                                         [AdvancedReportWriterType] = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Reporting.AdvancedReportWriterReports), UserDefinedReport.AdvancedReportWriterType),
                                         [CreatedBy] = UserDefinedReport.CreatedByUserCode,
                                         UserDefinedReport.CreatedDate,
                                         [UpdatedBy] = UserDefinedReport.UpdatedByUserCode,
                                         UserDefinedReport.UpdatedDate).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Tasks As IEnumerable(Of AdvantageFramework.Database.Entities.Task)) As Object

            LoadDataSourceView = (From Task In Tasks.ToList
                                  Select Task.Code,
                                         Task.Description,
                                         IsInactive = CBool(Task.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal TaskTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.TaskTemplate)) As Object

            LoadDataSourceView = (From TaskTemplate In TaskTemplates
                                  Select TaskTemplate.Code,
                                         TaskTemplate.Description,
                                         TaskTemplate.IsInactive).ToList _
                                 .Select(Function(Entity) New With {.Code = Entity.Code,
                                                                    .Description = Entity.Description,
                                                                    .IsInactive = CBool(Entity.IsInactive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Entities.Product)) As Object

            LoadDataSourceView = (From Product In Products
                                  Select Product.ID,
                                         Product.OfficeCode,
                                         Product.ClientCode,
                                         Product.DivisionCode,
                                         Product.Code,
                                         [OfficeName] = If(Product.Office Is Nothing, "", Product.Office.Name),
                                         [ClientName] = If(Product.Client Is Nothing, "", Product.Client.Name),
                                         [DivisionName] = If(Product.Division Is Nothing, "", Product.Division.Name),
                                         Product.Name,
                                         Product.IsActive).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                    .OfficeCode = Entity.OfficeCode,
                                                                                                    .OfficeName = Entity.OfficeName,
                                                                                                    .ClientCode = Entity.ClientCode,
                                                                                                    .ClientName = Entity.ClientName,
                                                                                                    .DivisionCode = Entity.DivisionCode,
                                                                                                    .DivisionName = Entity.DivisionName,
                                                                                                    .Code = Entity.Code,
                                                                                                    .Name = Entity.Name,
                                                                                                    .[IsInactive] = Not CBool(Entity.IsActive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 7

        End Function
        Protected Function LoadDataSourceView(ByVal ProductViews As IEnumerable(Of AdvantageFramework.Database.Views.ProductView)) As Object

            LoadDataSourceView = (From ProductView In ProductViews
                                  Select New With {.OfficeCode = ProductView.OfficeCode,
                                                   .OfficeName = ProductView.OfficeName,
                                                   .ClientCode = ProductView.ClientCode,
                                                   .ClientName = ProductView.ClientName,
                                                   .DivisionCode = ProductView.DivisionCode,
                                                   .DivisionName = ProductView.DivisionName,
                                                   .ProductCode = ProductView.ProductCode,
                                                   .ProductDescription = ProductView.ProductDescription,
                                                   .IsInactive = Not CBool(ProductView.IsActive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 6

        End Function
        Protected Function LoadDataSourceView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Entities.Division)) As Object

            LoadDataSourceView = (From Division In Divisions
                                  Select Division.ID,
                                         Division.ClientCode,
                                         [ClientName] = If(Division.Client Is Nothing, "", Division.Client.Name),
                                         Division.Code,
                                         Division.Name,
                                         Division.IsActive).ToList.Select(Function(Division) New With {.ID = Division.ID,
                                                                                                       .ClientCode = Division.ClientCode,
                                                                                                       .ClientName = Division.ClientName,
                                                                                                       .Code = Division.Code,
                                                                                                       .Name = Division.Name,
                                                                                                       .IsInactive = Not CBool(Division.IsActive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 3

        End Function
        Protected Function LoadDataSourceView(ByVal DivisionViews As IEnumerable(Of AdvantageFramework.Database.Views.DivisionView)) As Object

            LoadDataSourceView = (From DivisionView In DivisionViews
                                  Select DivisionView.ClientCode,
                                         DivisionView.DivisionCode,
                                         DivisionView.ClientName,
                                         DivisionView.DivisionName,
                                         DivisionView.IsActive).ToList.Select(Function(DivisionView) New With {.ClientCode = DivisionView.ClientCode,
                                                                                                               .ClientName = DivisionView.ClientName,
                                                                                                               .Code = DivisionView.DivisionCode,
                                                                                                               .Name = DivisionView.DivisionName,
                                                                                                               .IsInactive = Not CBool(DivisionView.IsActive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 2

        End Function
        Protected Function LoadDataSourceView(ByVal ClientPortalUsers As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser)) As Object

            LoadDataSourceView = (From ClientPortalUser In ClientPortalUsers.ToList
                                  Select ClientPortalUser.ID,
                                         ClientPortalUser.UserName,
                                         [UserCode] = ClientPortalUser.ClientContact.ContactCode,
                                         ClientPortalUser.FullName,
                                         ClientPortalUser.ClientContact.EmailAddress,
                                         [Client] = ClientPortalUser.ClientContact.Client.ToString).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Applications As IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application)) As Object

            LoadDataSourceView = (From Application In Applications.ToList
                                  Select Application.ID,
                                         Application.Name,
                                         Application.Description).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal SalesClasses As IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass)) As Object

            LoadDataSourceView = (From SalesClass In SalesClasses.ToList
                                  Select SalesClass.Code,
                                         SalesClass.Description,
                                         [IsInactive] = CBool(SalesClass.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal SalesClassFormats As IEnumerable(Of AdvantageFramework.Database.Entities.SalesClassFormat)) As Object

            LoadDataSourceView = (From SalesClassFormat In SalesClassFormats.ToList
                                  Select SalesClassFormat.Code,
                                         SalesClassFormat.Description,
                                         [IsInactive] = CBool(SalesClassFormat.IsInactive.GetValueOrDefault(1))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ServiceFeeReconciliationReports As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport)) As Object

            LoadDataSourceView = (From ServiceFeeReconciliationReport In ServiceFeeReconciliationReports.ToList
                                  Select ServiceFeeReconciliationReport.ID,
                                         ServiceFeeReconciliationReport.Description,
                                         [CreatedBy] = ServiceFeeReconciliationReport.CreatedByUserCode,
                                         ServiceFeeReconciliationReport.CreatedDate,
                                         [UpdatedBy] = ServiceFeeReconciliationReport.UpdatedByUserCode,
                                         ServiceFeeReconciliationReport.UpdatedDate).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ClientContacts As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact)) As Object

            LoadDataSourceView = (From ClientContact In ClientContacts.ToList
                                  Select ClientContact.ContactID,
                                         ClientContact.ContactCode,
                                         [Client] = ClientContact.Client.ToString,
                                         ClientContact.EmailAddress,
                                         ClientContact.FirstName,
                                         ClientContact.LastName,
                                         ClientContact.MiddleInitial,
                                         ClientContact.Title,
                                         ClientContact.Address,
                                         ClientContact.Address2,
                                         ClientContact.City,
                                         ClientContact.County,
                                         ClientContact.State,
                                         ClientContact.Country,
                                         ClientContact.Zip,
                                         ClientContact.PhoneNumber,
                                         ClientContact.PhoneNumberExtention,
                                         ClientContact.FaxNumber,
                                         ClientContact.FaxNumberExtention,
                                         ClientContact.CellPhoneNumber,
                                         [ScheduleUser] = CBool(ClientContact.ScheduleUser.GetValueOrDefault(0)),
                                         [ClientPortalUser] = CBool(ClientContact.IsClientPortalUser.GetValueOrDefault(0)),
                                         [GetsAlerts] = CBool(ClientContact.RecievesAlerts.GetValueOrDefault(0)),
                                         [EmailRecipient] = CBool(ClientContact.IsEmailRecipient.GetValueOrDefault(0)),
                                         [IsInactive] = CBool(ClientContact.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ClientContacts As IEnumerable(Of AdvantageFramework.Database.Entities.ClientContact)) As Object

            LoadDataSourceView = (From ClientContact In ClientContacts.ToList
                                  Select ClientContact.ContactID,
                                         ClientContact.ContactCode,
                                         ClientContact.ClientCode,
                                         [ClientName] = ClientContact.Client.Name,
                                         ClientContact.EmailAddress,
                                         ClientContact.FirstName,
                                         ClientContact.LastName,
                                         ClientContact.MiddleInitial,
                                         ClientContact.Title,
                                         ClientContact.Address,
                                         ClientContact.Address2,
                                         ClientContact.City,
                                         ClientContact.County,
                                         ClientContact.State,
                                         ClientContact.Country,
                                         ClientContact.Zip,
                                         ClientContact.Telephone,
                                         ClientContact.TelephoneExtension,
                                         ClientContact.Fax,
                                         ClientContact.FaxExtension,
                                         ClientContact.CellPhone,
                                         [ScheduleUser] = CBool(ClientContact.ScheduleUser.GetValueOrDefault(0)),
                                         [IsClientPortalUser] = CBool(ClientContact.IsClientPortalUser.GetValueOrDefault(0)),
                                         [GetAlerts] = CBool(ClientContact.GetAlerts.GetValueOrDefault(0)),
                                         [GetEmails] = CBool(ClientContact.GetEmails.GetValueOrDefault(0)),
                                         [IsInactive] = CBool(ClientContact.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ClientContacts As IEnumerable(Of AdvantageFramework.Database.Classes.ClientContact)) As Object

            LoadDataSourceView = (From ClientContact In ClientContacts.ToList
                                  Select ClientContact.ContactID,
                                         ClientContact.ContactCode,
                                         ClientContact.ClientCode,
                                         ClientContact.ClientName,
                                         ClientContact.ContactType,
                                         ClientContact.EmailAddress,
                                         ClientContact.FirstName,
                                         ClientContact.LastName,
                                         ClientContact.MiddleInitial,
                                         ClientContact.Title,
                                         ClientContact.Address,
                                         ClientContact.Address2,
                                         ClientContact.City,
                                         ClientContact.County,
                                         ClientContact.State,
                                         ClientContact.Country,
                                         ClientContact.Zip,
                                         ClientContact.Telephone,
                                         ClientContact.TelephoneExtension,
                                         ClientContact.Fax,
                                         ClientContact.FaxExtension,
                                         ClientContact.CellPhone,
                                         ClientContact.ScheduleUser,
                                         ClientContact.IsClientPortalUser,
                                         ClientContact.GetAlerts,
                                         ClientContact.GetEmails,
                                         ClientContact.IsInactive,
                                         ClientContact.IsClientInactive).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal LicenseKeyHistories As IEnumerable(Of AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory)) As Object

            LoadDataSourceView = (From LicenseKeyHistory In LicenseKeyHistories.ToList
                                  Select LicenseKeyHistory).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal StandardComments As IEnumerable(Of AdvantageFramework.Database.Entities.StandardComment)) As Object

            If _DataSourceViewOption = DataSourceViewOptions.StandardComment_ExportInfo Then

                LoadDataSourceView = (From StandardComment In StandardComments.ToList
                                      Select StandardComment.ID,
                                             StandardComment.ApplicationCode,
                                             StandardComment.CommentType,
                                                 StandardComment.FontSize,
                                             [Office] = If(StandardComment.Office IsNot Nothing, StandardComment.Office.ToString, ""),
                                             [Client] = If(StandardComment.Client IsNot Nothing, StandardComment.Client.ToString, ""),
                                             [Division] = If(StandardComment.Division IsNot Nothing, StandardComment.Division.ToString, ""),
                                             [Product] = If(StandardComment.Product IsNot Nothing, StandardComment.Product.ToString, ""),
                                                 [Vendor] = If(StandardComment.Vendor IsNot Nothing, StandardComment.Vendor.ToString, ""),
                                                 StandardComment.Comment).ToList

            Else

                LoadDataSourceView = (From StandardComment In StandardComments.ToList
                                      Select StandardComment.ID,
                                             StandardComment.ApplicationCode,
                                             StandardComment.CommentType,
                                             [Office] = If(StandardComment.Office IsNot Nothing, StandardComment.Office.ToString, ""),
                                             [Client] = If(StandardComment.Client IsNot Nothing, StandardComment.Client.ToString, ""),
                                             [Division] = If(StandardComment.Division IsNot Nothing, StandardComment.Division.ToString, ""),
                                             [Product] = If(StandardComment.Product IsNot Nothing, StandardComment.Product.ToString, ""),
                                         [Vendor] = If(StandardComment.Vendor IsNot Nothing, StandardComment.Vendor.ToString, "")).ToList

            End If

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal AgencyClients As IEnumerable(Of AdvantageFramework.Database.Entities.AgencyClient)) As Object

            LoadDataSourceView = (From AgencyClient In AgencyClients.ToList
                                  Select AgencyClient.ClientCode).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Locations As IEnumerable(Of AdvantageFramework.Database.Entities.Location)) As Object

            LoadDataSourceView = (From Location In Locations.ToList
                                  Select Location.ID,
                                         Location.Name,
                                         Location.Address,
                                         [POBox] = Location.Address2,
                                         Location.City,
                                         Location.State,
                                         Location.Zip,
                                         Location.Email,
                                         Location.Phone,
                                         Location.Fax).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ProductCategories As IEnumerable(Of AdvantageFramework.Database.Entities.ProductCategory)) As Object

            LoadDataSourceView = (From ProductCategory In ProductCategories.ToList
                                  Select ProductCategory.Code,
                                         ProductCategory.Description,
                                         [ClientCode] = ProductCategory.ClientCode,
                                         [DivisionCode] = ProductCategory.DivisionCode,
                                         [ProductCode] = ProductCategory.ProductCode,
                                         [Client] = ProductCategory.Product.Client.ToString,
                                         [Division] = ProductCategory.Product.Division.ToString,
                                         [Product] = ProductCategory.Product.ToString,
                                         [Inactive] = CBool(ProductCategory.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal VendorContacts As IEnumerable(Of AdvantageFramework.Database.Entities.VendorContact)) As Object

            If _DataSourceViewOption = DataSourceViewOptions.VendorContact_WithExtraContactInfo Then

                LoadDataSourceView = (From VendorContact In VendorContacts.ToList
                                      Select VendorContact.ID,
                                             VendorContact.Code,
                                             VendorContact.VendorCode,
                                             [Vendor] = VendorContact.Vendor.ToString,
                                             VendorContact.FirstName,
                                             VendorContact.MiddleInitial,
                                             VendorContact.LastName,
                                             VendorContact.Email,
                                             VendorContact.Phone,
                                             VendorContact.PhoneExt,
                                             VendorContact.Fax,
                                             VendorContact.FaxExt,
                                             VendorContact.Cell,
                                             [IsInactive] = CBool(VendorContact.IsInactive.GetValueOrDefault(0))).ToList

            Else

                LoadDataSourceView = (From VendorContact In VendorContacts.ToList
                                      Select VendorContact.ID,
                                             VendorContact.Code,
                                             VendorContact.VendorCode,
                                             [Vendor] = VendorContact.Vendor.ToString,
                                             VendorContact.FirstName,
                                             VendorContact.MiddleInitial,
                                             VendorContact.LastName,
                                             [IsInactive] = CBool(VendorContact.IsInactive.GetValueOrDefault(0))).ToList

            End If

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal VendorRepresentatives As IEnumerable(Of AdvantageFramework.Database.Entities.VendorRepresentative)) As Object

            LoadDataSourceView = (From VendorRepresentative In VendorRepresentatives.ToList
                                  Select VendorRepresentative.ID,
                                         VendorRepresentative.VendorCode,
                                         VendorRepresentative.Code,
                                         VendorRepresentative.FirstName,
                                         VendorRepresentative.MiddleInitial,
                                         VendorRepresentative.LastName,
                                         [IsInactive] = CBool(VendorRepresentative.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal BillingCoops As IEnumerable(Of AdvantageFramework.Database.Entities.BillingCoop)) As Object

            LoadDataSourceView = (From BillingCoop In BillingCoops.ToList
                                  Select BillingCoop.Code,
                                         BillingCoop.Description,
                                         [IsInactive] = CBool(BillingCoop.IsInactive.GetValueOrDefault(0))
                                  Distinct).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal AccountExecutives As IEnumerable(Of AdvantageFramework.Database.Entities.AccountExecutive)) As Object

            LoadDataSourceView = (From AccountExecutive In AccountExecutives.ToList
                                  Select [Client] = AccountExecutive.Product.Client.ToString,
                                         [Division] = AccountExecutive.Product.Division.ToString,
                                         [Product] = AccountExecutive.Product.ToString,
                                         [EmployeeCode] = AccountExecutive.EmployeeCode,
                                         [Employee] = AccountExecutive.Employee.ToString,
                                         [IsDefault] = CBool(AccountExecutive.IsDefaultAccountExecutive.GetValueOrDefault(0)),
                                         [IsInactive] = CBool(AccountExecutive.IsInactive.GetValueOrDefault(0)),
                                         [Terminated] = CBool(AccountExecutive.Employee.TerminationDate IsNot Nothing),
                                         [MgmtLevel] = AccountExecutive.ManagementLevel.Description).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal EstimateProcessingOptions As IEnumerable(Of AdvantageFramework.Database.Entities.EstimateProcessingOption)) As Object

            LoadDataSourceView = (From EstimateProcessingOption In EstimateProcessingOptions.ToList
                                  Select EstimateProcessingOption.OptionID,
                                         EstimateProcessingOption.Description,
                                         EstimateProcessingOption.AllowProcessing,
                                         EstimateProcessingOption.ExceedOption,
                                         EstimateProcessingOption.DisplayMessage).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal EmployeeCategories As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeCategory)) As Object

            LoadDataSourceView = (From EmployeeCategory In EmployeeCategories.ToList
                                  Select EmployeeCategory.ID,
                                         EmployeeCategory.Description,
                                         [Inactive] = CBool(EmployeeCategory.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal EstimateTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.EstimateTemplate)) As Object

            LoadDataSourceView = (From EstimateTemplate In EstimateTemplates.ToList
                                  Select EstimateTemplate.Code,
                                         EstimateTemplate.Description,
                                         [IsInactive] = CBool(EstimateTemplate.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Currencies As IEnumerable(Of AdvantageFramework.Database.Entities.Currency)) As Object

            LoadDataSourceView = (From Currency In Currencies.ToList
                                  Select [CurrencyCode] = Currency.CurrencyCode,
                                         [IsInactive] = CBool(Currency.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Partners As IEnumerable(Of AdvantageFramework.Database.Entities.Partner)) As Object

            LoadDataSourceView = (From Partner In Partners.ToList
                                  Select Partner.Code,
                                         Partner.Name,
                                         Partner.PartnerPercent,
                                         Partner.Address1,
                                         Partner.Address2,
                                         Partner.City,
                                         Partner.State,
                                         Partner.Zip,
                                         Partner.Country,
                                         Partner.Phone,
                                         Partner.PhoneExt,
                                         Partner.Fax,
                                         Partner.FaxExt,
                                         Partner.Email,
                                         [IsInactive] = CBool(Partner.IsInactive)).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal AlertGroups As IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup)) As Object

            LoadDataSourceView = (From AlertGroup In AlertGroups.ToList
                                  Select [Code] = AlertGroup.Code,
                                         [IsInactive] = CBool(AlertGroup.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)) As Object

            If _Session.HasLimitedOfficeCodes Then

                LoadDataSourceView = (From Vendor In Vendors
                                      Select Vendor.Code,
                                             Vendor.Name,
                                             Vendor.VendorCategory,
                                             Vendor.ActiveFlag,
                                             Vendor.OfficeCode).ToList.Where(Function(Ven) _Session.AccessibleOfficeCodes.Contains(Ven.OfficeCode)) _
                                  .Select(Function(Entity) New With {.Code = Entity.Code,
                                                                     .Name = Entity.Name,
                                                                     .VendorCategory = Entity.VendorCategory,
                                                                     .IsInactive = Not CBool(Entity.ActiveFlag.GetValueOrDefault(0))}).ToList

            Else

                LoadDataSourceView = (From Vendor In Vendors
                                      Select Vendor.Code,
                                             Vendor.Name,
                                             Vendor.VendorCategory,
                                             Vendor.ActiveFlag) _
                                  .Select(Function(Entity) New With {.Code = Entity.Code,
                                                                     .Name = Entity.Name,
                                                                     .VendorCategory = Entity.VendorCategory,
                                                                     .IsInactive = Not CBool(Entity.ActiveFlag.GetValueOrDefault(0))}).ToList

            End If



            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Banks As IEnumerable(Of AdvantageFramework.Database.Entities.Bank)) As Object

            LoadDataSourceView = (From Bank In Banks
                                  Select Bank.Code,
                                         Bank.Description,
                                         Bank.IsInactive).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                   .Description = Entity.Description,
                                                                                                   .[IsInactive] = CBool(Entity.IsInactive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        'Protected Function LoadDataSourceView(ByVal BillingRateDetails As IEnumerable(Of AdvantageFramework.Database.Classes.BillingRateDetail)) As Object

        '    LoadDataSourceView = (From BillingRateDetail In BillingRateDetails.ToList _
        '                          Select [ID] = BillingRateDetail.ID, _
        '                                 [BillingRateLevelID] = BillingRateDetail.BillingRateLevelID, _
        '                                 [Order] = BillingRateDetail.GetBillingRateDetail.BillingRateLevel.Number, _
        '                                 [Description] = BillingRateDetail.GetBillingRateDetail.BillingRateLevel.Description, _
        '                                 [ClientCode] = If(BillingRateDetail.GetBillingRateDetail.Client IsNot Nothing, BillingRateDetail.GetBillingRateDetail.Client.ToString, Nothing), _
        '                                 [DivisionCode] = If(BillingRateDetail.GetBillingRateDetail.Division IsNot Nothing, BillingRateDetail.GetBillingRateDetail.Division.ToString, Nothing), _
        '                                 [ProductCode] = If(BillingRateDetail.GetBillingRateDetail.Product IsNot Nothing, BillingRateDetail.GetBillingRateDetail.Product.ToString, Nothing), _
        '                                 [SalesClassCode] = If(BillingRateDetail.GetBillingRateDetail.SalesClass IsNot Nothing, BillingRateDetail.GetBillingRateDetail.SalesClass.ToString, Nothing), _
        '                                 [EmployeeTitleID] = If(BillingRateDetail.GetBillingRateDetail.EmployeeTitle IsNot Nothing, BillingRateDetail.GetBillingRateDetail.EmployeeTitle.Description, Nothing), _
        '                                 [EmployeeCode] = If(BillingRateDetail.GetBillingRateDetail.Employee IsNot Nothing, BillingRateDetail.GetBillingRateDetail.Employee.ToString, Nothing), _
        '                                 [FunctionCode] = If(BillingRateDetail.GetBillingRateDetail.Function IsNot Nothing, BillingRateDetail.GetBillingRateDetail.Function.ToString, Nothing), _
        '                                 [FunctionType] = If(BillingRateDetail.GetBillingRateDetail.Function IsNot Nothing, BillingRateDetail.GetBillingRateDetail.Function.Type, Nothing), _
        '                                 [EffectiveDate] = BillingRateDetail.EffectiveDate, _
        '                                 [RateAmount] = BillingRateDetail.RateAmount, _
        '                                 [IsNonBillable] = BillingRateDetail.IsNonBillable, _
        '                                 [IsCommission] = BillingRateDetail.IsCommission, _
        '                                 [TaxCommission] = BillingRateDetail.TaxCommission, _
        '                                 [TaxCommissionOnly] = BillingRateDetail.TaxCommissionOnly, _
        '                                 [IsTax] = BillingRateDetail.IsTax, _
        '                                 [TaxCode] = BillingRateDetail.TaxCode, _
        '                                 [IsFeeTime] = BillingRateDetail.IsFeeTime, _
        '                                 [IsInactive] = CBool(BillingRateDetail.IsInactive.GetValueOrDefault(0))).ToList

        '    _BookmarkColumnIndex = 0

        'End Function
        Protected Function LoadDataSourceView(ByVal Blackplates As IEnumerable(Of AdvantageFramework.Database.Entities.Blackplate)) As Object

            LoadDataSourceView = (From Blackplate In Blackplates.ToList
                                  Select Blackplate.Code,
                                         Blackplate.Description,
                                         [IsInactive] = CBool(Blackplate.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Resources As IEnumerable(Of AdvantageFramework.Database.Entities.Resource)) As Object

            LoadDataSourceView = (From Resource In Resources.ToList
                                  Select Resource.Code,
                                         Resource.Description,
                                         [IsInactive] = CBool(Resource.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal OverheadAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.OverheadAccount)) As Object

            LoadDataSourceView = (From OverheadAccount In OverheadAccounts.ToList
                                  Select OverheadAccount.Code,
                                         OverheadAccount.Description).ToList

            _BookmarkColumnIndex = 0

        End Function
        'Protected Function LoadDataSourceView(ByVal ExpenseReports As IEnumerable(Of AdvantageFramework.Database.Classes.ExpenseReport)) As Object

        '    LoadDataSourceView = (From ExpenseReport In ExpenseReports.ToList _
        '                          Select ExpenseReport.InvoiceNumber, _
        '                                 ExpenseReport.InvoiceDate, _
        '                                 ExpenseReport.Description, _
        '                                 ExpenseReport.DetailStatus, _
        '                                 ExpenseReport.TotalBillable, _
        '                                 ExpenseReport.TotalNonBillable, _
        '                                 ExpenseReport.TotalAmount).ToList

        '    _BookmarkColumnIndex = 0

        'End Function
        Protected Function LoadDataSourceView(ByVal ExpenseReports As IEnumerable(Of AdvantageFramework.Database.Entities.ExpenseReport)) As Object

            LoadDataSourceView = (From ExpenseReport In ExpenseReports.ToList
                                  Select ExpenseReport.InvoiceNumber,
                                         ExpenseReport.InvoiceDate,
                                         ExpenseReport.Description,
                                         ExpenseReport.EmployeeCode).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal RateCards As IEnumerable(Of AdvantageFramework.Database.Entities.RateCard)) As Object

            LoadDataSourceView = (From RateCard In RateCards.ToList
                                  Select RateCard.ID,
                                         [RateCard] = RateCard.Code,
                                         RateCard.Description,
                                         [Vendor] = If(RateCard.Vendor IsNot Nothing, RateCard.Vendor.ToString, ""),
                                         [IsInactive] = Not CBool(RateCard.IsInactive)).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal AccountPayables As IEnumerable(Of AdvantageFramework.Database.Entities.AccountPayable)) As Object

            Select Case _DataSourceViewOption

                Case DataSourceViewOptions.AccountPayable_CodeAndDescriptionCombined

                    LoadDataSourceView = (From AccountPayable In AccountPayables.ToList
                                          Select AccountPayable.ID,
                                                 [Vendor] = If(AccountPayable.Vendor IsNot Nothing, AccountPayable.Vendor.ToString, AccountPayable.VendorCode),
                                                 AccountPayable.InvoiceNumber,
                                                 AccountPayable.InvoiceDescription,
                                                 AccountPayable.InvoiceDate,
                                                 [Office] = If(AccountPayable.Office IsNot Nothing, AccountPayable.Office.ToString, AccountPayable.OfficeCode)).ToList

                    _BookmarkColumnIndex = 0

                Case Else

                    LoadDataSourceView = (From AccountPayable In AccountPayables.ToList
                                          Select AccountPayable.ID,
                                                 [Vendor] = If(AccountPayable.Vendor IsNot Nothing, AccountPayable.Vendor.ToString, AccountPayable.VendorCode),
                                                 AccountPayable.InvoiceNumber,
                                                 AccountPayable.InvoiceDescription,
                                                 AccountPayable.OfficeCode).ToList

                    _BookmarkColumnIndex = 0

            End Select

        End Function
        Protected Function LoadDataSourceView(ByVal AccountPayableViews As IEnumerable(Of AdvantageFramework.Database.Views.AccountPayableView)) As Object

            LoadDataSourceView = (From AccountPayableView In AccountPayableViews
                                  Select New With {.ID = AccountPayableView.ID,
                                                   .VendorCode = AccountPayableView.VendorCode,
                                                   .VendorName = AccountPayableView.VendorName,
                                                   .InvoiceNumber = AccountPayableView.InvoiceNumber,
                                                   .InvoiceDescription = AccountPayableView.InvoiceDescription,
                                                   .InvoiceDate = AccountPayableView.InvoiceDate,
                                                   .OfficeCode = AccountPayableView.OfficeCode,
                                                   .OfficeName = AccountPayableView.OfficeName}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal AccountPayableRecurs As IEnumerable(Of AdvantageFramework.Database.Entities.AccountPayableRecur)) As Object

            LoadDataSourceView = (From AccountPayableRecur In AccountPayableRecurs
                                  Select AccountPayableRecur.ID,
                                         AccountPayableRecur.VendorCode,
                                         AccountPayableRecur.InvoiceNumber,
                                         AccountPayableRecur.Description,
                                         AccountPayableRecur.IsInactive).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                  .VendorCode = Entity.VendorCode,
                                                                                                                  .InvoiceNumber = Entity.InvoiceNumber,
                                                                                                                  .Description = Entity.Description,
                                                                                                                  .[IsInactive] = CBool(Entity.IsInactive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal CreativeBriefTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.CreativeBriefTemplate)) As Object

            LoadDataSourceView = (From CreativeBriefTemplate In CreativeBriefTemplates
                                  Select CreativeBriefTemplate.ID,
                                         CreativeBriefTemplate.Code,
                                         CreativeBriefTemplate.Description,
                                         CreativeBriefTemplate.IsInactive).Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                           .Code = Entity.Code,
                                                                                                           .Description = Entity.Description,
                                                                                                           .[IsInactive] = CBool(Entity.IsInactive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal AccountReceivables As IEnumerable(Of AdvantageFramework.Database.Entities.AccountReceivable)) As Object

            LoadDataSourceView = (From AccountReceivable In AccountReceivables.ToList
                                  Select AccountReceivable.ClientCode,
                                         [Client] = AccountReceivable.Client.Name,
                                         AccountReceivable.InvoiceNumber,
                                         AccountReceivable.SequenceNumber,
                                         AccountReceivable.Type,
                                         AccountReceivable.Description,
                                         AccountReceivable.InvoiceDate).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal AccountReceivableViews As IEnumerable(Of AdvantageFramework.Database.Views.AccountReceivableView)) As Object

            LoadDataSourceView = (From AccountReceivableView In AccountReceivableViews
                                  Select New With {.ClientCode = AccountReceivableView.ClientCode,
                                                   .ClientName = AccountReceivableView.ClientName,
                                                    .InvoiceNumber = AccountReceivableView.InvoiceNumber,
                                                    .SequenceNumber = AccountReceivableView.SequenceNumber,
                                                    .Type = AccountReceivableView.Type,
                                                    .Description = AccountReceivableView.Description,
                                                    .InvoiceDate = AccountReceivableView.InvoiceDate}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Documents As IEnumerable(Of AdvantageFramework.Database.Entities.Document)) As Object

            LoadDataSourceView = (From Document In Documents.ToList
                                  Select Document.ID,
                                         Document.FileType,
                                         Document.FileName,
                                         Document.Description,
                                         Document.Keywords,
                                         Document.DocumentTypeID,
                                         Document.FileSize,
                                         Document.UserCode,
                                         [UploadedDate] = Document.UploadedDate.ToString,
                                         [IsPrivate] = CBool(Document.IsPrivate.GetValueOrDefault(0)),
                                         [ProofHQUrl] = Document.ProofHQUrl).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal DetailDocuments As IEnumerable(Of AdvantageFramework.Database.Classes.DetailDocument)) As Object

            LoadDataSourceView = (From DetailDocument In DetailDocuments.ToList
                                  Select DetailDocument.DOCUMENT_ID,
                                         DetailDocument.FileType,
                                         DetailDocument.FILENAME,
                                         DetailDocument.DESCRIPTION,
                                         DetailDocument.KEYWORDS,
                                         DetailDocument.FILE_SIZE,
                                         DetailDocument.UPLOADED_DATE,
                                         DetailDocument.MIME_TYPE,
                                         DetailDocument.USER_CODE,
                                         DetailDocument.CMP_CODE,
                                         DetailDocument.OFFICE_CODE,
                                         DetailDocument.CL_CODE,
                                         DetailDocument.DIV_CODE,
                                         DetailDocument.PRD_CODE,
                                         DetailDocument.JOB_NUMBER,
                                         DetailDocument.JOB_COMPONENT_NBR,
                                         DetailDocument.LEVEL,
                                         DetailDocument.OFFICE_NAME,
                                         DetailDocument.CAMPAIGN_NAME,
                                         DetailDocument.CLIENT_NAME,
                                         DetailDocument.DIVISION_NAME,
                                         DetailDocument.PRODUCT_DESCRIPTION,
                                         DetailDocument.JOB_DESCRIPTION,
                                         DetailDocument.JOB_COMP_DESCRIPTION,
                                         DetailDocument.REPOSITORY_FILENAME,
                                         DetailDocument.VENDOR_CODE,
                                         DetailDocument.AP_INVOICE,
                                         DetailDocument.VENDOR_NAME,
                                         DetailDocument.AP_INVOICE_DESC,
                                         DetailDocument.AP_ID,
                                         DetailDocument.AD_NBR,
                                         DetailDocument.AD_NBR_DESC).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)) As Object

            LoadDataSourceView = (From JobComponent In JobComponents.ToList
                                  Select [ID] = JobComponent.ID,
                                         [OfficeCode] = If(JobComponent.Job IsNot Nothing, JobComponent.Job.OfficeCode, ""),
                                         [OfficeName] = If(JobComponent.Job IsNot Nothing AndAlso JobComponent.Job.Office IsNot Nothing, JobComponent.Job.Office.Name, Nothing),
                                         [ClientCode] = If(JobComponent.Job IsNot Nothing, JobComponent.Job.ClientCode, ""),
                                         [ClientName] = If(JobComponent.Job IsNot Nothing AndAlso JobComponent.Job.Client IsNot Nothing, JobComponent.Job.Client.Name, Nothing),
                                         [DivisionCode] = If(JobComponent.Job IsNot Nothing, JobComponent.Job.DivisionCode, ""),
                                         [DivisionName] = If(JobComponent.Job IsNot Nothing AndAlso JobComponent.Job.Division IsNot Nothing, JobComponent.Job.Division.Name, Nothing),
                                         [ProductCode] = If(JobComponent.Job IsNot Nothing, JobComponent.Job.ProductCode, ""),
                                         [ProductName] = If(JobComponent.Job IsNot Nothing AndAlso JobComponent.Job.Product IsNot Nothing, JobComponent.Job.Product.Name, Nothing),
                                         [JobNumber] = JobComponent.JobNumber,
                                         [Number] = JobComponent.ToString(False, False),
                                         [Description] = JobComponent.Description).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal JobComponentViews As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)) As Object

            LoadDataSourceView = (From JobComponentView In JobComponentViews.ToList
                                  Select JobComponentView.ID,
                                         JobComponentView.OfficeCode,
                                         JobComponentView.OfficeName,
                                         JobComponentView.ClientCode,
                                         JobComponentView.ClientName,
                                         JobComponentView.DivisionCode,
                                         JobComponentView.DivisionName,
                                         JobComponentView.ProductCode,
                                         JobComponentView.ProductDescription,
                                         JobComponentView.JobNumber,
                                         JobComponentView.JobDescription,
                                         [JobComponentNumber] = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(JobComponentView.JobComponentNumber, 2, "0", True, True)),
                                         JobComponentView.JobComponentDescription,
                                         [IsOpen] = CBool(JobComponentView.IsOpen)).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Entities.Job)) As Object

            Select Case _DataSourceViewOption

                Case DataSourceViewOptions.Job_CodeAndDescriptionCombined

                    LoadDataSourceView = (From Job In Jobs
                                          Select Job.Number,
                                                 Job.Description,
                                                 Job.OfficeCode,
                                                 Job.ClientCode,
                                                 Job.DivisionCode,
                                                 Job.ProductCode,
                                                 [OfficeName] = Job.Office.Name,
                                                 [ClientName] = Job.Client.Name,
                                                 [DivisionName] = Job.Division.Name,
                                                 [ProductName] = Job.Product.Name,
                                                 [IsOpen] = CBool(Job.IsOpen.GetValueOrDefault(0))).ToList.Select(Function(Job) New With {.Number = Job.Number,
                                                                                                                                          .Office = Job.OfficeCode & " - " & Job.OfficeName,
                                                                                                                                          .Client = Job.ClientCode & " - " & Job.ClientName,
                                                                                                                                          .Division = Job.DivisionCode & " - " & Job.DivisionName,
                                                                                                                                          .Product = Job.ProductCode & " - " & Job.ProductName,
                                                                                                                                          .Job = Job.Number & " - " & Job.Description,
                                                                                                                                          .IsOpen = Job.IsOpen}).ToList

                    _BookmarkColumnIndex = 0

                Case Else

                    LoadDataSourceView = (From Job In Jobs.ToList
                                          Select Job.Number,
                                                 Job.OfficeCode,
                                                 Job.ClientCode,
                                                 Job.DivisionCode,
                                                 Job.ProductCode,
                                                 [IsOpen] = CBool(Job.IsOpen.GetValueOrDefault(0))).ToList

                    _BookmarkColumnIndex = 0

            End Select

        End Function
        Protected Function LoadDataSourceView(ByVal JobViews As IEnumerable(Of AdvantageFramework.Database.Views.JobView)) As Object

            LoadDataSourceView = (From JobView In JobViews
                                  Select JobView.JobNumber,
                                         JobView.JobDescription,
                                         JobView.OfficeCode,
                                         JobView.OfficeName,
                                         JobView.ClientCode,
                                         JobView.ClientName,
                                         JobView.DivisionCode,
                                         JobView.DivisionName,
                                         JobView.ProductCode,
                                         JobView.ProductDescription,
                                         [IsOpen] = JobView.IsOpen).ToList.Select(Function(JobView) New With {.OfficeCode = JobView.OfficeCode,
                                                                                                              .OfficeName = JobView.OfficeName,
                                                                                                                                   .ClientCode = JobView.ClientCode,
                                                                                                              .ClientName = JobView.ClientName,
                                                                                                                                   .DivisionCode = JobView.DivisionCode,
                                                                                                              .DivisionName = JobView.DivisionName,
                                                                                                                                   .ProductCode = JobView.ProductCode,
                                                                                                              .ProductDescription = JobView.ProductDescription,
                                                                                                              .JobNumber = JobView.JobNumber,
                                                                                                              .JobDescription = JobView.JobDescription,
                                                                                                                                   .IsOpen = CBool(JobView.IsOpen)}).ToList

            _BookmarkColumnIndex = 8

        End Function
        Protected Function LoadDataSourceView(ByVal EmployeeTimeForecastOfficeDetailAlternateEmployees As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)) As Object

            LoadDataSourceView = (From EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetailAlternateEmployees.ToList
                                  Select [ID] = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID,
                                         [Description] = EmployeeTimeForecastOfficeDetailAlternateEmployee.ToString()).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal PTORules As IEnumerable(Of AdvantageFramework.Database.Entities.PTORule)) As Object

            LoadDataSourceView = (From PTORule In PTORules.ToList
                                  Select PTORule.ID,
                                         PTORule.Name,
                                         PTORule.IsInactive).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal IndirectCategories As IEnumerable(Of AdvantageFramework.Database.Entities.IndirectCategory)) As Object

            LoadDataSourceView = (From IndirectCategory In IndirectCategories.ToList
                                  Select [Code] = IndirectCategory.Code,
                                         [Description] = IndirectCategory.Description,
                                         [IsInactive] = CBool(IndirectCategory.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal InvoiceCategories As IEnumerable(Of AdvantageFramework.Database.Entities.InvoiceCategory)) As Object

            LoadDataSourceView = (From InvoiceCategory In InvoiceCategories.ToList
                                  Select [Code] = InvoiceCategory.Code,
                                         [Description] = InvoiceCategory.Description,
                                         [IsInactive] = CBool(InvoiceCategory.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ImportTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate)) As Object

            LoadDataSourceView = (From ImportTemplate In ImportTemplates.ToList
                                  Select [ID] = ImportTemplate.ID,
                                         [Name] = ImportTemplate.Name,
                                         [IsSystemTemplate] = ImportTemplate.IsSystemTemplate,
                                         [DefaultDirectory] = ImportTemplate.DefaultDirectory,
                                         [CreatedBy] = ImportTemplate.CreatedBy,
                                         [CreatedDate] = ImportTemplate.CreatedDate,
                                         [ModifiedBy] = ImportTemplate.ModifiedBy,
                                         [ModifiedDate] = ImportTemplate.ModifiedDate).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ExportTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.ExportTemplate)) As Object

            LoadDataSourceView = (From ExportTemplate In ExportTemplates
                                  Select [ID] = ExportTemplate.ID,
                                         [Name] = ExportTemplate.Name,
                                         [IsSystemTemplate] = ExportTemplate.IsSystemTemplate.GetValueOrDefault(False),
                                         [DefaultDirectory] = ExportTemplate.DefaultDirectory,
                                         [CreatedBy] = ExportTemplate.CreatedByUserCode,
                                         [CreatedDate] = ExportTemplate.CreatedDate,
                                         [ModifiedBy] = ExportTemplate.ModifiedByUserCode,
                                         [ModifiedDate] = ExportTemplate.ModifiedDate).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)) As Object

            If _DataSourceViewOption = DataSourceViewOptions.GeneralLedgerAccount_CodeAndDescriptionSeparated Then

                LoadDataSourceView = (From GeneralLedgerAccount In GeneralLedgerAccounts.ToList
                                      Select [Code] = GeneralLedgerAccount.Code,
                                             [Description] = GeneralLedgerAccount.Description).ToList

            Else

                LoadDataSourceView = (From GeneralLedgerAccount In GeneralLedgerAccounts.ToList
                                      Select [Code] = GeneralLedgerAccount.Code,
                                             [Description] = GeneralLedgerAccount.ToString).ToList

            End If

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal JobSpecificationTypes As IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationType)) As Object

            LoadDataSourceView = (From JobSpecificationType In JobSpecificationTypes.ToList
                                  Select [Code] = JobSpecificationType.Code,
                                         [Description] = JobSpecificationType.Description,
                                         [IsInactive] = CBool(JobSpecificationType.IsInactive)).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal JobSpecificationCategorys As IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationCategory)) As Object

            LoadDataSourceView = (From JobSpecificationCategory In JobSpecificationCategorys
                                  Select [ID] = JobSpecificationCategory.ID,
                                         [Description] = JobSpecificationCategory.Description,
                                         [IsInactive] = JobSpecificationCategory.IsInactive).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal JobTemplateItems As IEnumerable(Of AdvantageFramework.Database.Entities.JobTemplateItem)) As Object

            LoadDataSourceView = (From JobTemplateItem In JobTemplateItems.ToList
                                  Select JobTemplateItem.Description,
                                         JobTemplateItem.Code).ToList

            _BookmarkColumnIndex = 1

        End Function
        Protected Function LoadDataSourceView(ByVal JobTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.JobTemplate)) As Object

            LoadDataSourceView = (From JobTemplate In JobTemplates.ToList
                                  Select JobTemplate.Code,
                                         JobTemplate.Description,
                                         [IsInactive] = CBool(JobTemplate.IsInactive.GetValueOrDefault(0))).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Ads As IEnumerable(Of AdvantageFramework.Database.Entities.Ad)) As Object

            LoadDataSourceView = (From Ad In Ads
                                  Select New With {.[Number] = Ad.Number,
                                                   .[Description] = Ad.Description,
                                                   .[ClientCode] = Ad.ClientCode,
                                                   .[ClientName] = If(Ad.Client IsNot Nothing, Ad.Client.Name, Nothing),
                                                   .[IsInactive] = Ad.IsInactive}).ToList.Select(Function(Entity) New With {.[Number] = Entity.Number,
                                                                                                                            .[Description] = Entity.Description,
                                                                                                                            .[ClientCode] = Entity.ClientCode,
                                                                                                                            .[ClientName] = Entity.ClientName,
                                                                                                                            .[IsInactive] = CBool(Entity.IsInactive.GetValueOrDefault(0))})

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Dayparts As IEnumerable(Of AdvantageFramework.Database.Entities.Daypart)) As Object

            LoadDataSourceView = (From Daypart In Dayparts
                                  Select New With {.[ID] = Daypart.ID,
                                                   .[Code] = Daypart.Code,
                                                   .[Description] = Daypart.Description,
                                                   .[DaypartType] = Daypart.DaypartType.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal AdSizes As IEnumerable(Of AdvantageFramework.Database.Entities.AdSize)) As Object

            LoadDataSourceView = (From AdSize In AdSizes.ToList
                                  Select New With {.ID = AdSize.ID,
                                                   .Code = AdSize.Code,
                                                   .MediaType = AdSize.MediaType,
                                                   .Description = AdSize.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal MediaOrders As IEnumerable(Of AdvantageFramework.Database.Views.MediaOrder)) As Object

            LoadDataSourceView = (From MediaOrder In MediaOrders
                                  Select New With {.OrderNumber = MediaOrder.OrderNumber,
                                                   .Description = MediaOrder.Description,
                                                   .MediaType = MediaOrder.MediaType}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal InternetOrders As IEnumerable(Of AdvantageFramework.Database.Entities.InternetOrder)) As Object

            LoadDataSourceView = (From InternetOrder In InternetOrders
                                  Select New With {.OrderNumber = InternetOrder.OrderNumber,
                                                   .Description = InternetOrder.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal TVOrders As IEnumerable(Of AdvantageFramework.Database.Entities.TVOrder)) As Object

            LoadDataSourceView = (From TVOrder In TVOrders
                                  Select New With {.OrderNumber = TVOrder.OrderNumber,
                                                   .Description = TVOrder.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal RadioOrders As IEnumerable(Of AdvantageFramework.Database.Entities.RadioOrder)) As Object

            LoadDataSourceView = (From RadioOrder In RadioOrders
                                  Select New With {.OrderNumber = RadioOrder.OrderNumber,
                                                   .Description = RadioOrder.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal MagazineOrders As IEnumerable(Of AdvantageFramework.Database.Entities.MagazineOrder)) As Object

            LoadDataSourceView = (From MagazineOrder In MagazineOrders
                                  Select New With {.OrderNumber = MagazineOrder.OrderNumber,
                                                   .Description = MagazineOrder.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal MagazineOrders As IEnumerable(Of AdvantageFramework.Database.Views.Magazine)) As Object

            LoadDataSourceView = (From MagazineOrder In MagazineOrders
                                  Select New With {.OrderNumber = MagazineOrder.OrderNumber,
                                                   .Description = MagazineOrder.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal NewspaperOrders As IEnumerable(Of AdvantageFramework.Database.Entities.NewspaperOrder)) As Object

            LoadDataSourceView = (From NewspaperOrder In NewspaperOrders
                                  Select New With {.OrderNumber = NewspaperOrder.OrderNumber,
                                                   .Description = NewspaperOrder.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal NewspaperOrders As IEnumerable(Of AdvantageFramework.Database.Views.NewspaperHeader)) As Object

            LoadDataSourceView = (From NewspaperOrder In NewspaperOrders
                                  Select New With {.OrderNumber = NewspaperOrder.OrderNumber,
                                                   .Description = NewspaperOrder.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal OutOfHomeOrders As IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeOrder)) As Object

            LoadDataSourceView = (From OutOfHomeOrder In OutOfHomeOrders
                                  Select New With {.OrderNumber = OutOfHomeOrder.OrderNumber,
                                                   .Description = OutOfHomeOrder.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal OutOfHomeTypes As IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeType)) As Object

            LoadDataSourceView = (From OutOfHomeType In OutOfHomeTypes
                                  Select New With {.[Code] = OutOfHomeType.Code,
                                                   .[Description] = OutOfHomeType.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal InternetTypes As IEnumerable(Of AdvantageFramework.Database.Entities.InternetType)) As Object

            LoadDataSourceView = (From InternetType In InternetTypes
                                  Select New With {.[Code] = InternetType.Code,
                                                   .[Description] = InternetType.Description}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Destinations As IEnumerable(Of AdvantageFramework.Database.Entities.Destination)) As Object

            LoadDataSourceView = (From Destination In Destinations
                                  Select New With {.Code = Destination.Code,
                                                   .Name = Destination.Name,
                                                   .IsInactive = CBool(Destination.IsInactive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal MediaPlans As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlan)) As Object

            LoadDataSourceView = (From MediaPlan In MediaPlans.ToList
                                  Select New With {.[ID] = MediaPlan.ID,
                                                   .[Description] = MediaPlan.Description,
                                                   .[ClientCode] = MediaPlan.ClientCode,
                                                   .[ClientName] = MediaPlan.Client.Name,
                                                   .[StartDate] = MediaPlan.StartDate.ToShortDateString,
                                                   .[EndDate] = MediaPlan.EndDate.ToShortDateString,
                                                   .[IsApproved] = MediaPlan.MediaPlanDetails.Where(Function(Detail) Detail.IsApproved = False).Any = False,
                                                   .[IsInactive] = MediaPlan.IsInactive}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal MediaPlanDetails As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetail)) As Object

            LoadDataSourceView = (From MediaPlanDetail In MediaPlanDetails.ToList
                                  Select New With {.[ID] = MediaPlanDetail.ID,
                                                   .[MediaPlanID] = MediaPlanDetail.MediaPlanID,
                                                   .[MediaPlan] = MediaPlanDetail.MediaPlan.Description,
                                                   .[SalesClassType] = MediaPlanDetail.SalesClassType,
                                                   .[SalesClass] = If(MediaPlanDetail.SalesClass IsNot Nothing, MediaPlanDetail.SalesClass.ToString, Nothing)}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal JobVersionTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplate)) As Object

            LoadDataSourceView = (From JobVersionTemplate In JobVersionTemplates
                                  Select JobVersionTemplate.Code,
                                         JobVersionTemplate.Description,
                                         JobVersionTemplate.IsInactive
                                  Distinct).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                            .Description = Entity.Description,
                                                                                            .IsInactive = CBool(Entity.IsInactive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal JobVersionTemplateDetails As IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail)) As Object

            LoadDataSourceView = (From JobVersionTemplateDetail In JobVersionTemplateDetails
                                  Select JobVersionTemplateDetail.ID,
                                         JobVersionTemplateDetail.JobVersionTemplateCode,
                                         JobVersionTemplateDetail.Label,
                                         JobVersionTemplateDetail.JobVersionDatabaseType.Description,
                                         JobVersionTemplateDetail.OrderNumber,
                                         JobVersionTemplateDetail.IsInactive,
                                         JobVersionTemplateDetail.IsRequired,
                                         JobVersionTemplateDetail.Instructions).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                         .JobVersionTemplateCode = Entity.JobVersionTemplateCode,
                                                                                                                         .Label = Entity.Label,
                                                                                                                         .DatabaseType = Entity.Description,
                                                                                                                         .OrderNumber = Entity.OrderNumber,
                                                                                                                         .IsInactive = CBool(Entity.IsInactive.GetValueOrDefault(0)),
                                                                                                                         .IsRequired = CBool(Entity.IsRequired),
                                                                                                                         .Instructions = Entity.Instructions}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal GLReportTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.GLReportTemplate)) As Object

            LoadDataSourceView = (From GLReportTemplate In GLReportTemplates
                                  Select New With {.ID = GLReportTemplate.ID,
                                                   .ReportType = GLReportTemplate.ReportType,
                                                   .Description = GLReportTemplate.Description,
                                                   .CreatedBy = GLReportTemplate.CreatedByUserCode,
                                                   .CreatedDate = GLReportTemplate.CreatedDate,
                                                   .ModifiedBy = GLReportTemplate.ModifiedByUserCode,
                                                   .ModifiedDate = GLReportTemplate.ModifiedDate}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Database.Classes.Vendor)) As Object

            LoadDataSourceView = (From Vendor In Vendors
                                  Select New With {.Code = Vendor.Code,
                                                   .Name = Vendor.Name,
                                                   .VendorType = Vendor.VendorType,
                                                   .Office = Vendor.Office,
                                                   .DefaultAPAccount = Vendor.DefaultAPAccount,
                                                   .Market = Vendor.Market,
                                                   .VendorCity = Vendor.VendorCity,
                                                   .VendorState = Vendor.VendorState,
                                                   .IsCableSystem = Vendor.IsCableSystem,
                                                   .[CallLetters] = Vendor.CallLetters,
                                                   .IsInactive = Vendor.IsInactive}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Classes.Employee)) As Object

            LoadDataSourceView = (From Employee In Employees
                                  Select New With {.Code = Employee.Code,
                                                   .Name = Employee.Name,
                                                   .OfficeCode = Employee.OfficeCode,
                                                   .OfficeName = Employee.OfficeName,
                                                   .DepartmentTeamCode = Employee.DepartmentTeamCode,
                                                   .DepartmentTeamName = Employee.DepartmentTeamName,
                                                   .Freelance = Employee.Freelance,
                                                   .IsActiveFreelance = Employee.IsActiveFreelance,
                                                   .Terminated = Employee.Terminated}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Markets As IEnumerable(Of AdvantageFramework.Database.Entities.Market)) As Object

            LoadDataSourceView = (From Market In Markets
                                  Select Market.Code,
                                         Market.Description,
                                         Market.IsInactive).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                     .Description = Entity.Description,
                                                                                                     .IsInactive = CBool(Entity.IsInactive.GetValueOrDefault(0))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal MyObjectDefaultObjects As IEnumerable(Of AdvantageFramework.Database.Entities.MyObjectDefinitionObject)) As Object

            LoadDataSourceView = (From MyObjectDefaultObject In MyObjectDefaultObjects
                                  Select MyObjectDefaultObject.ID,
                                         MyObjectDefaultObject.Description,
                                         MyObjectDefaultObject.Type,
                                         MyObjectDefaultObject.IsInactive).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                    .Description = Entity.Description,
                                                                                                                    .Type = Entity.Type,
                                                                                                                    .IsInactive = CBool(Entity.IsInactive.GetValueOrDefault(False))}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ScheduleHeaderComplexes As IEnumerable(Of AdvantageFramework.Database.Classes.ScheduleHeaderComplex)) As Object

            LoadDataSourceView = (From ScheduleHeaderComplex In ScheduleHeaderComplexes
                                  Select New With {.ScheduleID = ScheduleHeaderComplex.ScheduleID,
                                                   .OfficeCode = ScheduleHeaderComplex.OfficeCode,
                                                   .OfficeName = ScheduleHeaderComplex.OfficeName,
                                                   .ClientCode = ScheduleHeaderComplex.ClientCode,
                                                   .ClientName = ScheduleHeaderComplex.ClientName,
                                                   .DivisionCode = ScheduleHeaderComplex.DivisionCode,
                                                   .DivisionName = ScheduleHeaderComplex.DivisionName,
                                                   .ProductCode = ScheduleHeaderComplex.ProductCode,
                                                   .ProductDescription = ScheduleHeaderComplex.ProductDescription,
                                                   .JobNumber = ScheduleHeaderComplex.JobNumber,
                                                   .JobDescription = ScheduleHeaderComplex.JobDescription,
                                                   .JobComponentNumber = ScheduleHeaderComplex.JobComponentNumber,
                                                   .JobComponentDescription = ScheduleHeaderComplex.JobComponentDescription,
                                                   .CampaignCode = ScheduleHeaderComplex.CampaignCode,
                                                   .CampaignName = ScheduleHeaderComplex.CampaignName,
                                                   .SalesClassCode = ScheduleHeaderComplex.SalesClassCode,
                                                   .SalesClassDescription = ScheduleHeaderComplex.SalesClassDescription,
                                                   .AccountExecutiveEmployeeCode = ScheduleHeaderComplex.AccountExecutiveEmployeeCode,
                                                   .AccountExecutiveEmployeeName = ScheduleHeaderComplex.AccountExecutiveEmployeeName,
                                                   .ManagerEmployeeCode = ScheduleHeaderComplex.ManagerEmployeeCode,
                                                   .ManagerEmployeeName = ScheduleHeaderComplex.ManagerEmployeeName,
                                                   .StatusCode = ScheduleHeaderComplex.StatusCode,
                                                   .StatusDescription = ScheduleHeaderComplex.StatusDescription,
                                                   .Completed = If(ScheduleHeaderComplex.CompletedDate Is Nothing, False, True)}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal EmployeeRateHistorys As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeRateHistory)) As Object

            LoadDataSourceView = (From EmployeeRateHistory In EmployeeRateHistorys
                                  Select New With {.ID = EmployeeRateHistory.ID,
                                                   .EmployeeCode = EmployeeRateHistory.EmployeeCode,
                                                   .StartDate = EmployeeRateHistory.StartDate,
                                                   .EndDate = EmployeeRateHistory.EndDate,
                                                   .DepartmentTeamCode = EmployeeRateHistory.DepartmentTeamCode,
                                                   .DepartmentTeam = If(EmployeeRateHistory.DepartmentTeam Is Nothing, Nothing, EmployeeRateHistory.DepartmentTeam.Description),
                                                   .EmployeeTitle = If(EmployeeRateHistory.EmployeeTitle Is Nothing, Nothing, EmployeeRateHistory.EmployeeTitle.ToString),
                                                   .AnnualSalary = EmployeeRateHistory.AnnualSalary,
                                                   .MonthlySalary = EmployeeRateHistory.MonthlySalary,
                                                   .CostRate = EmployeeRateHistory.CostRate}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Documents As IEnumerable(Of AdvantageFramework.DocumentManager.Classes.Document)) As Object

            LoadDataSourceView = (From Document In Documents
                                  Select Document.ID,
                                         Document.FileType,
                                         Document.DocumentLevelName,
                                         Document.FileName,
                                         Document.FileSystemFileName,
                                         Document.MIMEType,
                                         Document.Description,
                                         Document.Keywords,
                                         Document.DocumentTypeID,
                                         Document.FileSize,
                                         Document.UserCode,
                                         [UploadedDate] = Document.UploadedDate.ToString,
                                         [IsPrivate] = CBool(Document.IsPrivate.GetValueOrDefault(0)),
                                         Document.ProofHQUrl,
                                         Document.DocumentLevel).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal ClientPOs As IEnumerable(Of AdvantageFramework.Database.Entities.ClientPO)) As Object

            LoadDataSourceView = (From ClientPO In ClientPOs
                                  Select New With {.ClientPONumber = ClientPO.ClientPONumber,
                                                   .ClientPODescription = ClientPO.ClientPODescription}).ToList

            _BookmarkColumnIndex = 0

        End Function
        Protected Function LoadDataSourceView(ByVal Value As Object) As Object

            'objects
            Dim View As Object = Nothing

            If TypeOf Value Is IEnumerable Then

                Try

                    Me.CurrentView.ObjectType = DirectCast(Value, IEnumerable).AsQueryable.ElementType

                Catch ex As Exception

                End Try

                If Me.ControlType <> Type.EditableGrid Then

                    If TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.Employee) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.Employee)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Office) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Office)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Function) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Function)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.FunctionView) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.FunctionView)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.DepartmentTeam) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.DepartmentTeam)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Role) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Role)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.DynamicReport) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.DynamicReport)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.Group) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.Group)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.User) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.User)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Client) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Client)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Campaign) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Campaign)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.CampaignView) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.CampaignView)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Campaign) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Campaign)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.Product) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.Product)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Views.Employee) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Views.Employee)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserEmployeeAccess) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserEmployeeAccess)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReport) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReport)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Task) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Task)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.TaskTemplate) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.TaskTemplate)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Product) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Product)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.ProductView) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.ProductView)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Division) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Division)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.DivisionView) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.DivisionView)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.StandardComment) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.StandardComment)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AgencyClient) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AgencyClient)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Location) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Location)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ProductCategory) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ProductCategory)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.VendorContact) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.VendorContact)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.BillingCoop) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.BillingCoop)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AccountExecutive) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AccountExecutive)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientContact) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientContact)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.ClientContact) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.ClientContact)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EstimateProcessingOption) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EstimateProcessingOption)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ServiceFeeType) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ServiceFeeType)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeCategory) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeCategory)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EstimateTemplate) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EstimateTemplate)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Currency) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Currency)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Partner) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Partner)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Vendor) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Bank) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Bank)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.SalesClassFormat) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.SalesClassFormat)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Blackplate) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Blackplate)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Resource) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Resource)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.OverheadAccount) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.OverheadAccount)))

                        'ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.ExpenseReport) Then

                        '    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.ExpenseReport)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ExpenseReport) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ExpenseReport)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.VendorRepresentative) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.VendorRepresentative)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.RateCard) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.RateCard)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AccountPayable) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AccountPayable)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.AccountPayableView) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.AccountPayableView)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Document) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Document)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.DetailDocument) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.DetailDocument)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)))

                        'ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.BillingRateDetail) Then

                        '    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.BillingRateDetail)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PTORule) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PTORule)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.IndirectCategory) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.IndirectCategory)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.InvoiceCategory) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.InvoiceCategory)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobTemplateItem) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobTemplateItem)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobTemplate) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobTemplate)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationType) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationType)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Ad) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Ad)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Job) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Job)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.JobView) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.JobView)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlan) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlan)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplate) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplate)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AccountPayableRecur) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AccountPayableRecur)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.CreativeBriefTemplate) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.CreativeBriefTemplate)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.InternetType) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.InternetType)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AdSize) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AdSize)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.MediaOrder) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.MediaOrder)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.InternetOrder) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.InternetOrder)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.TVOrder) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.TVOrder)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.RadioOrder) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.RadioOrder)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.MagazineOrder) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.MagazineOrder)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.Magazine) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.Magazine)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.NewspaperHeader) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.NewspaperHeader)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.NewspaperOrder) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.NewspaperOrder)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeOrder) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeOrder)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Destination) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Destination)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetail) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetail)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.GLReportTemplate) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.GLReportTemplate)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.Vendor) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.Vendor)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Vendor) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Vendor)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ExpenseReportDetail) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ExpenseReportDetail)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Daypart) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Daypart)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Office) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Office)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.DepartmentTeam) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.DepartmentTeam)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.GLReportUserDefReport) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.GLReportUserDefReport)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Market) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Market)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.Employee) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.Employee)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.MyObjectDefinitionObject) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.MyObjectDefinitionObject)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AccountReceivable) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AccountReceivable)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.AccountReceivableView) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.AccountReceivableView)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AccountGroup) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AccountGroup)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.GLAllocation) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.GLAllocation)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrder) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrder)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.PurchaseOrderComplex) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.PurchaseOrderComplex)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailsComplex) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailsComplex)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ExportTemplate) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ExportTemplate)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationCategory) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationCategory)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeType) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeType)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeRateHistory) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeRateHistory)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.ScheduleHeaderComplex) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.ScheduleHeaderComplex)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.DocumentManager.Classes.Document) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.DocumentManager.Classes.Document)))

                    ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientPO) Then

                        View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientPO)))

                    Else

                        View = Value

                    End If

                Else

                    View = Value

                End If

            Else

                View = Value

            End If

            LoadDataSourceView = View

        End Function
        Protected Sub InstantFeedbackSource_DismissQueryable(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

            If _InstantFeedbackSource IsNot Nothing Then

                Try

                    If TypeOf _InstantFeedbackSource Is DevExpress.Data.Linq.EntityInstantFeedbackSource OrElse
                       TypeOf _InstantFeedbackSource Is DevExpress.Data.Linq.LinqInstantFeedbackSource Then

                        CType(e.Tag, AdvantageFramework.Database.DbContext).Dispose()

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Protected Sub InstantFeedbackSource_GetQueryable(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.GetQueryableEventArgs)

            Dim DbContext As AdvantageFramework.Database.DbContext = Nothing
            Dim DataSource As Object = Nothing

            If _InstantFeedbackSource IsNot Nothing Then

                Try

                    DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RaiseEvent NeedQueryableDataSourceEvent(DbContext, DataSource)

                    e.QueryableSource = DataSource
                    e.Tag = DbContext

                Catch ex As Exception

                End Try

            End If

        End Sub
        Protected Sub LoadDataSource(ByRef Value As Object)

            DataGridView_GridControl.BeginUpdate()
            GridViewGridControl_MainView.BeginUpdate()

            LoadBookmarks()

            If TypeOf Value Is DevExpress.Data.Linq.LinqInstantFeedbackSource Then

                _InstantFeedbackSource = Value

                Try

                    Me.CurrentView.ObjectType = DirectCast(Value, DevExpress.Data.Linq.LinqInstantFeedbackSource).DesignTimeElementType

                Catch ex As Exception

                End Try

                AddHandler CType(_InstantFeedbackSource, DevExpress.Data.Linq.EntityInstantFeedbackSource).DismissQueryable, AddressOf InstantFeedbackSource_DismissQueryable
                AddHandler CType(_InstantFeedbackSource, DevExpress.Data.Linq.EntityInstantFeedbackSource).GetQueryable, AddressOf InstantFeedbackSource_GetQueryable

                DataGridView_GridControl.DataSource = Value

            ElseIf TypeOf Value Is DevExpress.Data.Linq.EntityInstantFeedbackSource Then

                _InstantFeedbackSource = Value

                Try

                    Me.CurrentView.ObjectType = DirectCast(Value, DevExpress.Data.Linq.EntityInstantFeedbackSource).DesignTimeElementType

                Catch ex As Exception

                End Try

                AddHandler CType(_InstantFeedbackSource, DevExpress.Data.Linq.EntityInstantFeedbackSource).DismissQueryable, AddressOf InstantFeedbackSource_DismissQueryable
                AddHandler CType(_InstantFeedbackSource, DevExpress.Data.Linq.EntityInstantFeedbackSource).GetQueryable, AddressOf InstantFeedbackSource_GetQueryable

                DataGridView_GridControl.DataSource = Value

            ElseIf TypeOf Value Is DevExpress.Data.Linq.EntityServerModeSource Then

                Try

                    Me.CurrentView.ObjectType = DirectCast(Value, DevExpress.Data.Linq.EntityServerModeSource).ElementType

                Catch ex As Exception

                End Try

                DataGridView_GridControl.DataSource = Value

            ElseIf TypeOf Value Is DevExpress.Data.Linq.LinqServerModeSource Then

                Try

                    Me.CurrentView.ObjectType = DirectCast(Value, DevExpress.Data.Linq.LinqServerModeSource).ElementType

                Catch ex As Exception

                End Try

                DataGridView_GridControl.DataSource = Value

            Else

                If TypeOf Value Is IEnumerable Then

                    Try

                        Me.CurrentView.ObjectType = DirectCast(Value, IEnumerable).AsQueryable.ElementType

                    Catch ex As Exception

                    End Try

                Else

                    Me.CurrentView.ObjectType = GetType(Object)

                End If

                'If _BindingSource IsNot Nothing Then

                'GridViewGridControl_MainView.ObjectType = GetType(Object)

                '    Try

                '        _BindingSource.DataSource = Nothing

                '    Catch ex As Exception

                '    End Try

                '    Try

                '        _BindingSource.Dispose()

                '        _BindingSource = Nothing

                '    Catch ex As Exception

                '    End Try

                'End If

                '_BindingSource = New System.Windows.Forms.BindingSource

                If _BindingSource Is Nothing Then

                    _BindingSource = New System.Windows.Forms.BindingSource

                End If

                _BindingSource.DataSource = LoadDataSourceView(Value)

                DataGridView_GridControl.DataSource = _BindingSource

                If GridViewGridControl_MainView.RestoredLayoutNonVisibleGridColumnList IsNot Nothing Then

                    For Each GridColumn In GridViewGridControl_MainView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridViewGridControl_MainView.RestoredLayoutNonVisibleGridColumnList.Contains(GridColumn) Then

                            GridColumn.Visible = False

                        End If

                    Next

                End If

            End If

            Me.ClearChanged()

            If _PreviousPosition = 0 AndAlso _BindingSource.Position = 0 AndAlso _IsFirstLoad = False Then

                GridViewGridControl_MainView.GridViewSelectionChanged()

            ElseIf GridViewGridControl_MainView.FocusedRowHandle = 0 AndAlso _BindingSource.Position = 1 AndAlso _IsFirstLoad = False Then

                GridViewGridControl_MainView.GridViewSelectionChanged()

            End If

            If _ItemDescription = "" OrElse _ItemDescription = "Item(s)" Then

                _ItemDescription = AdvantageFramework.WinForm.Presentation.Controls.LoadDefaultGridViewItemDescription(Me.CurrentView.ObjectType)

            End If

            If _DataSourceViewOption <> DataSourceViewOptions.Default Then

                LoadDataSourceViewOptions()

            End If

            SetHeaderText()

            SetBookmarks()

            If Me.ParentForm IsNot Nothing Then

                _IsFirstLoad = False

            End If

            DataGridView_GridControl.EndUpdate()
            GridViewGridControl_MainView.EndUpdate()

        End Sub
        Protected Sub LoadDataSourceViewOptions()

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            Select Case _DataSourceViewOption

                Case DataSourceViewOptions.VendorContact_WithExtraContactInfo, DataSourceViewOptions.StandardComment_ExportInfo

                Case Else

                    For Each GridColumn In Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.Visible = False

                    Next

            End Select

            Select Case _DataSourceViewOption

                Case DataSourceViewOptions.Job_CodeAndDescriptionCombined

                    ModifyColumn("Number", False)
                    ModifyColumn("Office", True, "Office")
                    ModifyColumn("Client", True, "Client")
                    ModifyColumn("Division", True, "Division")
                    ModifyColumn("Product", True, "Product")
                    ModifyColumn("Job", True, "Job")
                    ModifyColumn("IsOpen", True, "Is Open")

                Case DataSourceViewOptions.JobComp_CodeAndDescriptionCombined

                    ModifyColumn("ID", False)
                    ModifyColumn("Number", False)
                    ModifyColumn("Office", True, "Office")
                    ModifyColumn("Client", True, "Client")
                    ModifyColumn("Division", True, "Division")
                    ModifyColumn("Product", True, "Product")
                    ModifyColumn("JobNumber", False)
                    ModifyColumn("JobDescription", True, "Job")
                    ModifyColumn("JobComponent", True, "Job Component")
                    ModifyColumn("IsOpen", True, "Is Open")

                    RepositoryItemCheckEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

                    GridViewGridControl_MainView.GridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

                    Me.Columns("IsOpen").ColumnEdit = RepositoryItemCheckEdit

                Case DataSourceViewOptions.AccountPayable_CodeAndDescriptionCombined

                    ModifyColumn("ID", False)
                    ModifyColumn("Vendor", True, "Vendor")
                    ModifyColumn("InvoiceNumber", True, "Invoice Number")
                    ModifyColumn("InvoiceDescription", True, "Description")
                    ModifyColumn("InvoiceDate", True, "Invoice Date")
                    ModifyColumn("Office", True, "Office")

                Case DataSourceViewOptions.GeneralLedgerAccount_CodeAndDescriptionSeparated

                    ModifyColumn("Code", True)
                    ModifyColumn("Description", True)

                Case DataSourceViewOptions.Product_ExcludeClientDivision

                    For Each Column In Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                        If Column.FieldName = AdvantageFramework.Database.Entities.Product.Properties.Code.ToString OrElse
                           Column.FieldName = AdvantageFramework.Database.Entities.Product.Properties.Name.ToString OrElse
                           Column.FieldName = AdvantageFramework.Database.Entities.Product.Properties.OfficeCode.ToString OrElse
                           Column.FieldName = "OfficeName" OrElse
                           Column.FieldName = "IsInactive" Then

                            ModifyColumn(Column.FieldName, True)

                        Else

                            ModifyColumn(Column.FieldName, False)

                        End If

                    Next

                Case DataSourceViewOptions.Division_ExcludeClient

                    For Each Column In Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                        If Column.FieldName = AdvantageFramework.Database.Entities.Division.Properties.Code.ToString OrElse
                           Column.FieldName = AdvantageFramework.Database.Entities.Division.Properties.Name.ToString OrElse
                           Column.FieldName = "IsInactive" Then

                            ModifyColumn(Column.FieldName, True)

                        Else

                            ModifyColumn(Column.FieldName, False)

                        End If

                    Next

                Case DataSourceViewOptions.Employee_WithTerminatedColumn

                    ModifyColumn("Code", True)
                    ModifyColumn("Name", True)
                    ModifyColumn("Terminated", True)

                    RepositoryItemCheckEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

                    GridViewGridControl_MainView.GridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

                    Me.Columns("Terminated").ColumnEdit = RepositoryItemCheckEdit

            End Select

        End Sub
        Public Sub ModifyColumn(ByVal FieldName As String, Optional ByVal Visible As Boolean = True, Optional ByVal Caption As String = Nothing)

            'objects
            Dim VisibleIndex As Integer = Nothing

            Try

                If Me.Columns(FieldName) IsNot Nothing Then

                    If Visible Then

                        Try

                            VisibleIndex = (From Column In Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()
                                            Select [VI] = Column.VisibleIndex).Max + 1

                        Catch ex As Exception
                            VisibleIndex = 0
                        End Try

                        Me.Columns(FieldName).VisibleIndex = VisibleIndex

                    Else

                        Me.Columns(FieldName).Visible = False

                    End If

                    If String.IsNullOrEmpty(Caption) = False Then

                        Me.Columns(FieldName).Caption = Caption

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Protected Sub SetHeaderText()

            If _AutoUpdateViewCaption Then

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If CType(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).IsFormClosing = False Then

                        GridViewGridControl_MainView.ViewCaption = GridViewGridControl_MainView.DataRowCount.ToString("N0") & " " & _ItemDescription

                    End If

                Else

                    GridViewGridControl_MainView.ViewCaption = GridViewGridControl_MainView.DataRowCount.ToString("N0") & " " & _ItemDescription

                End If

            End If

        End Sub
        Public Function GetAllSelectedRowsDataBoundItems() As IEnumerable

            GetAllSelectedRowsDataBoundItems = GridViewGridControl_MainView.GetSelectedRows.Where(Function(RowHandle) GridViewGridControl_MainView.IsDataRow(RowHandle) = True).Select(Function(RowHandle) DirectCast(DataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(GridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle)))

        End Function
        Public Function GetAllSelectedRowsRowHandlesAndDataBoundItems() As Generic.Dictionary(Of Integer, Object)

            'objects
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            RowHandlesAndDataBoundItems = New Generic.Dictionary(Of Integer, Object)

            For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                    Try

                        RowHandlesAndDataBoundItems(RowHandle) = DirectCast(DataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(GridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle))

                    Catch ex As Exception
                        RowHandlesAndDataBoundItems(RowHandle) = Nothing
                    End Try

                End If

            Next

            GetAllSelectedRowsRowHandlesAndDataBoundItems = RowHandlesAndDataBoundItems

        End Function
        Public Function GetAllRowsRowHandlesAndDataBoundItems() As Generic.Dictionary(Of Integer, Object)

            'objects
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            RowHandlesAndDataBoundItems = New Generic.Dictionary(Of Integer, Object)

            For RowHandle = 0 To GridViewGridControl_MainView.RowCount - 1

                If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                    Try

                        RowHandlesAndDataBoundItems(RowHandle) = DirectCast(DataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(GridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle))

                    Catch ex As Exception
                        RowHandlesAndDataBoundItems(RowHandle) = Nothing
                    End Try

                End If

            Next

            GetAllRowsRowHandlesAndDataBoundItems = RowHandlesAndDataBoundItems

        End Function
        Public Function CheckForModifiedRows() As Boolean

            CheckForModifiedRows = GridViewGridControl_MainView.CheckForModifiedRows

        End Function
        Public Function RemoveFromModifiedRows(ByVal DataBoundObject As Object) As Boolean

            RemoveFromModifiedRows = GridViewGridControl_MainView.RemoveFromModifiedRows(DataBoundObject)

        End Function
        Public Function AddToModifiedRows(ByVal RowHandle As Integer) As Boolean

            AddToModifiedRows = GridViewGridControl_MainView.AddToModifiedRows(RowHandle)

        End Function
        Public Function AddToModifiedRows(DataBoundObject As Object) As Boolean

            AddToModifiedRows = GridViewGridControl_MainView.AddToModifiedRows(DataBoundObject)

        End Function
        Public Function GetAllModifiedRows() As Generic.List(Of Object)

            GetAllModifiedRows = GridViewGridControl_MainView.GetAllModifiedRows

        End Function
        Public Function HasAnyInvalidRows() As Boolean

            HasAnyInvalidRows = GridViewGridControl_MainView.HasAnyInvalidRows

        End Function
        Public Function GetAllEnabledRowsDataBoundItems() As IEnumerable

            'objects
            Dim DataBoundItems As Generic.List(Of Object) = Nothing
            Dim DisabledDataSourceRowIndexes As IEnumerable(Of Integer) = Nothing

            DataBoundItems = New Generic.List(Of Object)

            DisabledDataSourceRowIndexes = (From Entity In GridViewGridControl_MainView.DisabledRows
                                            Select Entity.DataSourceRowIndex).ToArray

            For RowHandle = 0 To GridViewGridControl_MainView.RowCount - 1

                If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                    If Not DisabledDataSourceRowIndexes.Contains(GridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle)) Then

                        DataBoundItems.Add(DirectCast(DataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(GridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle)))

                    End If

                End If

            Next

            GetAllEnabledRowsDataBoundItems = DataBoundItems

        End Function
        Public Function GetAllEnabledRowsRowHandlesAndDataBoundItems() As Generic.Dictionary(Of Integer, Object)

            'objects
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim DisabledDataSourceRowIndexes As IEnumerable(Of Integer) = Nothing

            RowHandlesAndDataBoundItems = New Generic.Dictionary(Of Integer, Object)

            DisabledDataSourceRowIndexes = (From Entity In GridViewGridControl_MainView.DisabledRows
                                            Select Entity.DataSourceRowIndex).ToArray

            For RowHandle = 0 To GridViewGridControl_MainView.RowCount - 1

                If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                    If Not DisabledDataSourceRowIndexes.Contains(GridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle)) Then

                        Try

                            RowHandlesAndDataBoundItems(RowHandle) = DirectCast(DataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(GridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle))

                        Catch ex As Exception
                            RowHandlesAndDataBoundItems(RowHandle) = Nothing
                        End Try

                    End If

                End If

            Next

            GetAllEnabledRowsRowHandlesAndDataBoundItems = RowHandlesAndDataBoundItems

        End Function
        Public Function GetAllRowsDataBoundItems() As IEnumerable

            'objects
            Dim DataBoundItems As Generic.List(Of Object) = Nothing

            DataBoundItems = New Generic.List(Of Object)

            For RowHandle = 0 To GridViewGridControl_MainView.RowCount - 1

                If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                    DataBoundItems.Add(DirectCast(DataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(GridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle)))

                End If

            Next

            GetAllRowsDataBoundItems = DataBoundItems

        End Function
        Public Function GetAllRowsCellValues(ByVal BookmarkColumnIndex As Integer) As IEnumerable

            'objects
            Dim CellValues As Generic.List(Of Object) = Nothing

            CellValues = New Generic.List(Of Object)

            If BookmarkColumnIndex > -1 AndAlso GridViewGridControl_MainView.Columns(BookmarkColumnIndex) IsNot Nothing Then

                For RowHandle = 0 To GridViewGridControl_MainView.RowCount - 1

                    If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        CellValues.Add(GridViewGridControl_MainView.GetRowCellValue(RowHandle, GridViewGridControl_MainView.Columns(BookmarkColumnIndex)))

                    End If

                Next

            End If

            GetAllRowsCellValues = CellValues

        End Function
        Public Function GetAllSelectedRowsCellValues(ByVal BookmarkColumnIndex As Integer) As IEnumerable

            'objects
            Dim CellValues As Generic.List(Of Object) = Nothing

            CellValues = New Generic.List(Of Object)

            If BookmarkColumnIndex > -1 AndAlso GridViewGridControl_MainView.Columns(BookmarkColumnIndex) IsNot Nothing Then

                For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                    If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        CellValues.Add(GridViewGridControl_MainView.GetRowCellValue(RowHandle, GridViewGridControl_MainView.Columns(BookmarkColumnIndex)))

                    End If

                Next

            End If

            GetAllSelectedRowsCellValues = CellValues

        End Function
        Public Function GetAllSelectedRowsCellValues(FieldName As String) As IEnumerable

            'objects
            Dim CellValues As Generic.List(Of Object) = Nothing

            CellValues = New Generic.List(Of Object)

            If Me.HasASelectedRow AndAlso GridViewGridControl_MainView.Columns IsNot Nothing AndAlso GridViewGridControl_MainView.Columns.ColumnByFieldName(FieldName) IsNot Nothing Then

                For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                    If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        CellValues.Add(GridViewGridControl_MainView.GetRowCellValue(RowHandle, GridViewGridControl_MainView.Columns(FieldName)))

                    End If

                Next

            End If

            GetAllSelectedRowsCellValues = CellValues

        End Function
        Public Function GetAllRowsBookmarkValues(ByVal BookmarkColumnIndex As Integer) As IEnumerable

            'objects
            Dim BookmarkValues As Generic.List(Of Object) = Nothing

            BookmarkValues = New Generic.List(Of Object)

            If BookmarkColumnIndex > -1 AndAlso GridViewGridControl_MainView.Columns(BookmarkColumnIndex) IsNot Nothing Then

                For RowHandle = 0 To GridViewGridControl_MainView.RowCount - 1

                    If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        BookmarkValues.Add(GridViewGridControl_MainView.GetRowCellValue(RowHandle, GridViewGridControl_MainView.Columns(BookmarkColumnIndex)))

                    End If

                Next

            End If

            GetAllRowsBookmarkValues = BookmarkValues

        End Function
        Public Function GetAllRowsBookmarkValues() As IEnumerable

            GetAllRowsBookmarkValues = GetAllRowsBookmarkValues(_BookmarkColumnIndex)

        End Function
        Public Function GetAllSelectedRowsBookmarkValues() As IEnumerable

            GetAllSelectedRowsBookmarkValues = GetAllSelectedRowsBookmarkValues(_BookmarkColumnIndex)

        End Function
        Public Function GetAllSelectedRowsBookmarkValues(ByVal BookmarkColumnIndex As Integer) As IEnumerable

            'objects
            Dim BookmarkValues As Generic.List(Of Object) = Nothing

            BookmarkValues = New Generic.List(Of Object)

            If BookmarkColumnIndex > -1 AndAlso GridViewGridControl_MainView.Columns(BookmarkColumnIndex) IsNot Nothing Then

                For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                    If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        BookmarkValues.Add(GridViewGridControl_MainView.GetRowCellValue(RowHandle, GridViewGridControl_MainView.Columns(BookmarkColumnIndex)))

                    End If

                Next

            End If

            GetAllSelectedRowsBookmarkValues = BookmarkValues

        End Function
        Public Function GetFirstSelectedRowBookmarkValue() As Object

            GetFirstSelectedRowBookmarkValue = GetFirstSelectedRowBookmarkValue(_BookmarkColumnIndex)

        End Function
        Public Function GetFirstSelectedRowBookmarkValue(ByVal BookmarkColumnIndex As Integer) As Object

            'objects
            Dim BookmarkValue As Object = Nothing

            If Me.HasASelectedRow AndAlso BookmarkColumnIndex > -1 AndAlso GridViewGridControl_MainView.Columns IsNot Nothing AndAlso
                    BookmarkColumnIndex < GridViewGridControl_MainView.Columns.Count AndAlso GridViewGridControl_MainView.Columns(BookmarkColumnIndex) IsNot Nothing Then

                For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                    If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        BookmarkValue = GridViewGridControl_MainView.GetRowCellValue(RowHandle, GridViewGridControl_MainView.Columns(BookmarkColumnIndex))
                        Exit For

                    End If

                Next

            End If

            GetFirstSelectedRowBookmarkValue = BookmarkValue

        End Function
        Public Function GetFirstSelectedRowCellValue(ByVal FieldName As String) As Object

            'objects
            Dim BookmarkValue As Object = Nothing

            If Me.HasASelectedRow AndAlso GridViewGridControl_MainView.Columns IsNot Nothing AndAlso GridViewGridControl_MainView.Columns.ColumnByFieldName(FieldName) IsNot Nothing Then

                For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                    If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        BookmarkValue = GridViewGridControl_MainView.GetRowCellValue(RowHandle, GridViewGridControl_MainView.Columns.ColumnByFieldName(FieldName))
                        Exit For

                    End If

                Next

            End If

            GetFirstSelectedRowCellValue = BookmarkValue

        End Function
        Public Function GetFirstSelectedRowDataBoundItem() As Object

            'objects
            Dim DataBoundItem As Object = Nothing

            If Me.HasASelectedRow Then

                For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                    If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        DataBoundItem = DirectCast(DataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(GridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle))
                        Exit For

                    End If

                Next

            End If

            GetFirstSelectedRowDataBoundItem = DataBoundItem

        End Function
        Public Function GetRowDataBoundItem(ByVal RowHandle As Integer) As Object

            'objects
            Dim DataBoundItem As Object = Nothing

            If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                Try

                    DataBoundItem = DirectCast(DataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(GridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle))

                Catch ex As Exception
                    DataBoundItem = Nothing
                End Try

            End If

            GetRowDataBoundItem = DataBoundItem

        End Function
        Public Function GetRowBookmarkValue(ByVal RowHandle As Integer) As Object

            'objects
            Dim BookmarkValue As Object = Nothing

            If _BookmarkColumnIndex > -1 AndAlso GridViewGridControl_MainView.Columns(_BookmarkColumnIndex) IsNot Nothing Then

                If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                    Try

                        BookmarkValue = GridViewGridControl_MainView.GetRowCellValue(RowHandle, GridViewGridControl_MainView.Columns(_BookmarkColumnIndex))

                    Catch ex As Exception
                        BookmarkValue = Nothing
                    End Try

                End If

            End If

            GetRowBookmarkValue = BookmarkValue

        End Function
        Public Function SaveLayout() As Boolean

            'objects
            Dim LayoutSaved As Boolean = False
            Dim FileStream As System.IO.FileStream = Nothing

            FileStream = New System.IO.FileStream(System.Windows.Forms.Application.StartupPath & "\Dynamic Report Files\Layout1.xml", IO.FileMode.Create)

            GridViewGridControl_MainView.SaveLayoutToStream(FileStream, GridViewGridControl_MainView.OptionsLayout)

            FileStream.Close()
            FileStream.Dispose()

            LayoutSaved = True

            SaveLayout = LayoutSaved

        End Function
        Public Function LoadLayout() As Boolean

            'objects
            Dim LayoutLoaded As Boolean = False

            GridViewGridControl_MainView.RestoreLayoutFromXml(My.Application.Info.DirectoryPath & "\Dynamic Report Files\Layout1.xml", GridViewGridControl_MainView.OptionsLayout)

            LayoutLoaded = True

            LoadLayout = LayoutLoaded

        End Function
        Public Sub HideOrShowColumn(ByVal FieldName As String, ByVal Visible As Boolean)

            If GridViewGridControl_MainView.Columns(FieldName) IsNot Nothing Then

                GridViewGridControl_MainView.Columns(FieldName).Visible = Visible

            End If

        End Sub
        Public Sub HideOrShowColumn(ByVal FieldName As String, ByVal Visible As Boolean, ByRef VisibleIndex As Integer)

            If GridViewGridControl_MainView.Columns(FieldName) IsNot Nothing Then

                GridViewGridControl_MainView.Columns(FieldName).VisibleIndex = VisibleIndex
                GridViewGridControl_MainView.Columns(FieldName).Visible = Visible

                VisibleIndex = VisibleIndex + 1

            End If

        End Sub
        Public Sub ResetColumnOrderByObjectType()

            GridViewGridControl_MainView.ResetColumnOrderByObjectType()

        End Sub
        Protected Sub LoadBookmarks()

            If Me.HasASelectedRow AndAlso
                    _BookmarkColumnIndex > -1 AndAlso
                    Me.CurrentView.Columns.Count > 0 Then

                _CurrentBookmark = Me.GetFirstSelectedRowBookmarkValue
                _NextBookmark = Nothing

                For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                    If RowHandle + 1 < Me.CurrentView.RowCount Then

                        If GridViewGridControl_MainView.IsDataRow(RowHandle + 1) Then

                            _NextBookmark = Me.CurrentView.GetRowCellValue(RowHandle + 1, Me.CurrentView.Columns(_BookmarkColumnIndex))
                            Exit For

                        End If

                    Else

                        Exit For

                    End If

                Next

                If _NextBookmark IsNot Nothing Then

                    For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                        If RowHandle - 1 >= 0 Then

                            If GridViewGridControl_MainView.IsDataRow(RowHandle - 1) Then

                                _NextBookmark = Me.CurrentView.GetRowCellValue(RowHandle - 1, Me.CurrentView.Columns(_BookmarkColumnIndex))
                                Exit For

                            End If

                        Else

                            Exit For

                        End If

                    Next

                End If

                'If Me.CurrentView.GetSelectedRows(0) + 1 < Me.CurrentView.RowCount Then

                '    '_NextBookmark = Me.CurrentView.GetRowCellValue(Me.CurrentView.GetSelectedRows(0) + 1, Me.CurrentView.Columns(_BookmarkColumnIndex))

                '    For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                '        If GridViewGridControl_MainView.IsDataRow(RowHandle + 1) Then

                '            _NextBookmark = Me.CurrentView.GetRowCellValue(RowHandle + 1, Me.CurrentView.Columns(_BookmarkColumnIndex))
                '            Exit For

                '        End If

                '    Next

                'ElseIf Me.CurrentView.GetSelectedRows(0) - 1 >= 0 Then

                '    '_NextBookmark = Me.CurrentView.GetRowCellValue(Me.CurrentView.GetSelectedRows(0) - 1, Me.CurrentView.Columns(_BookmarkColumnIndex))

                '    For Each RowHandle In GridViewGridControl_MainView.GetSelectedRows

                '        If GridViewGridControl_MainView.IsDataRow(RowHandle - 1) Then

                '            _NextBookmark = Me.CurrentView.GetRowCellValue(RowHandle - 1, Me.CurrentView.Columns(_BookmarkColumnIndex))
                '            Exit For

                '        End If

                '    Next

                'Else

                '    _NextBookmark = Nothing

                'End If

            Else

                _CurrentBookmark = Nothing
                _NextBookmark = Nothing

            End If

        End Sub
        Public Sub SetBookmarks()

            If Me.HasRows Then

                If _CurrentBookmark IsNot Nothing AndAlso
                        _BookmarkColumnIndex > -1 Then

                    SelectRow(_CurrentBookmark)

                End If

                If Me.HasASelectedRow = False AndAlso
                        _NextBookmark IsNot Nothing AndAlso
                        _BookmarkColumnIndex > -1 Then

                    SelectRow(_NextBookmark)

                End If

                If Me.CurrentView.SelectedRowsCount = 0 Then

                    For RowHandle = 0 To Me.CurrentView.RowCount - 1

                        If GridViewGridControl_MainView.IsDataRow(RowHandle) Then

                            Try

                                GridViewGridControl_MainView.SelectRow(RowHandle)
                                GridViewGridControl_MainView.FocusedRowHandle = RowHandle

                            Catch ex As Exception

                            End Try

                            Exit For

                        End If

                    Next

                End If

            End If

        End Sub
        Public Sub GridViewSelectionChanged()

            GridViewGridControl_MainView.GridViewSelectionChanged()

        End Sub
        Public Sub FocusToFindPanel(ByVal DeselectAllRows As Boolean)

            If GridViewGridControl_MainView.OptionsFind.AllowFindPanel = False Then

                GridViewGridControl_MainView.OptionsFind.AllowFindPanel = True

            End If

            GridViewGridControl_MainView.ShowFindPanel()

            GridViewGridControl_MainView.OptionsFind.AlwaysVisible = True
            GridViewGridControl_MainView.OptionsFind.ShowFindButton = False
            GridViewGridControl_MainView.OptionsFind.ShowCloseButton = False
            GridViewGridControl_MainView.OptionsFind.SearchInPreview = False

            If DeselectAllRows Then

                HideRowSelection()

            End If

        End Sub
        Public Sub SelectRow(ByVal BookmarkValue As Object)

            SelectRow(_BookmarkColumnIndex, BookmarkValue)

        End Sub
        Public Sub SelectRow(ByVal BookmarkValue As Object, ByVal DeselectRows As Boolean)

            SelectRow(_BookmarkColumnIndex, BookmarkValue, DeselectRows)

        End Sub
        Public Sub SelectRow(ByVal BookmarkColumnIndex As Integer, ByVal BookmarkValue As Object)

            SelectRow(BookmarkColumnIndex, BookmarkValue, True)

        End Sub
        Public Sub SelectRow(ByVal BookmarkColumnIndex As Integer, ByVal BookmarkValue As Object, ByVal DeselectRows As Boolean)

            Dim e As DevExpress.Data.SelectionChangedEventArgs = Nothing

            If BookmarkValue IsNot Nothing AndAlso
                    BookmarkColumnIndex > -1 Then

                Me.CurrentView.BeginSelection()

                If DeselectRows Then

                    Me.CurrentView.ClearSelection()

                End If

                For RowHandle = 0 To Me.CurrentView.RowCount - 1

                    If Me.CurrentView.GetRowCellValue(RowHandle, Me.CurrentView.Columns(BookmarkColumnIndex)) = BookmarkValue Then

                        Me.CurrentView.SelectRow(RowHandle)

                        If RowHandle = 0 AndAlso Me.CurrentView.FocusedRowHandle = 0 Then

                            DeselectGroupHeaderRows()

                            RaiseEvent SelectionChangedEvent(GridViewGridControl_MainView, e)

                        Else

                            Me.CurrentView.FocusedRowHandle = RowHandle

                        End If

                        Exit For

                    End If

                Next

                Me.CurrentView.EndSelection()

            End If

        End Sub
        Public Sub SelectRow(ByVal ColumnName As String, ByVal ColumnValue As Object, ByVal DeselectRows As Boolean)

            Dim e As DevExpress.Data.SelectionChangedEventArgs = Nothing

            Me.CurrentView.BeginSelection()

            If DeselectRows Then

                Me.CurrentView.ClearSelection()

            End If

            For RowHandle = 0 To Me.CurrentView.RowCount - 1

                If Me.CurrentView.GetRowCellValue(RowHandle, Me.CurrentView.Columns(ColumnName)) = ColumnValue Then

                    Me.CurrentView.SelectRow(RowHandle)

                    If RowHandle = 0 AndAlso Me.CurrentView.FocusedRowHandle = 0 Then

                        DeselectGroupHeaderRows()

                        RaiseEvent SelectionChangedEvent(GridViewGridControl_MainView, e)

                    Else

                        Me.CurrentView.FocusedRowHandle = RowHandle

                    End If

                    Exit For

                End If

            Next

            Me.CurrentView.EndSelection()

        End Sub
        Public Sub SelectAllRowsByValue(ByVal BookmarkColumnIndex As Integer, ByVal BookmarkValue As Object, ByVal DeselectRows As Boolean)

            Dim e As DevExpress.Data.SelectionChangedEventArgs = Nothing

            If BookmarkValue IsNot Nothing AndAlso
                    BookmarkColumnIndex > -1 Then

                Me.CurrentView.BeginSelection()

                If DeselectRows Then

                    Me.CurrentView.ClearSelection()

                End If

                For RowHandle = 0 To Me.CurrentView.RowCount - 1

                    If Me.CurrentView.GetRowCellValue(RowHandle, Me.CurrentView.Columns(BookmarkColumnIndex)) = BookmarkValue Then

                        Me.CurrentView.SelectRow(RowHandle)

                        If RowHandle = 0 AndAlso Me.CurrentView.FocusedRowHandle = 0 Then

                            DeselectGroupHeaderRows()

                            RaiseEvent SelectionChangedEvent(GridViewGridControl_MainView, e)

                        Else

                            Me.CurrentView.FocusedRowHandle = RowHandle

                        End If

                    End If

                Next

                Me.CurrentView.EndSelection()

            End If

        End Sub
        Public Sub ClearColumns()

            If GridViewGridControl_MainView.Columns.Count > 0 Then

                GridViewGridControl_MainView.Columns.Clear()

                Try

                    GridViewGridControl_MainView.FocusedColumn = Nothing

                Catch ex As Exception

                End Try

            End If

        End Sub
        Public Sub Print(ByVal Session As AdvantageFramework.Security.Session, ByVal LookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel, ByVal DocumentDescription As String, Optional ByVal Images() As System.Drawing.Image = Nothing,
                         Optional ByVal UseLandscape As Boolean = False)

            _Session = Session

            Print(LookAndFeel, DocumentDescription, Images, UseLandscape)

        End Sub
        Public Sub Print(ByVal LookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel, ByVal DocumentDescription As String, Optional ByVal Images() As System.Drawing.Image = Nothing,
                         Optional ByVal UseLandscape As Boolean = False, Optional ByVal IsScheduledReportService As Boolean = False, Optional SaveToFilename As String = Nothing,
                         Optional AdvantageServiceReportScheduleExportType As Database.Entities.Methods.AdvantageServiceReportScheduleExportType = Nothing)

            'objects
            Dim CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink = Nothing
            Dim ComponentResourceManager As System.ComponentModel.ComponentResourceManager = Nothing
            Dim PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
            Dim ReportHeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim PrintableComponentLink As DevExpress.XtraPrinting.PrintableComponentLink = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim KeepLoading As Boolean = True

            ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageFramework.Desktop.Presentation.DynamicReportEditForm))

            PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem
            CompositeLink = New DevExpress.XtraPrintingLinks.CompositeLink(PrintingSystem)

            ReportHeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

            If IsScheduledReportService Then

                ReportHeaderLink.Tag = Me

            End If

            PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DocumentDescription

            If _Session IsNot Nothing AndAlso Not IsScheduledReportService Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If Agency.IsASP = 1 Then

                            If My.Computer.FileSystem.DirectoryExists(Agency.ImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")

                                End If

                            End If

                            PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DocumentDescription & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
                            PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")
                            PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                            PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                            PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(_Session, If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\"), DocumentDescription))

                            'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                            PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                        End If

                    End If

                End Using

            End If

            If KeepLoading Then

                AddHandler ReportHeaderLink.CreateDetailArea, AddressOf ReportHeaderLink_CreateDetailArea

                CompositeLink.Links.Add(ReportHeaderLink)

                PrintableComponentLink = New DevExpress.XtraPrinting.PrintableComponentLink(PrintingSystem)

                PrintableComponentLink.Component = Me.GridControl

                If UseLandscape Then

                    PrintableComponentLink.Landscape = True
                    PrintingSystem.PageSettings.Landscape = True
                    CompositeLink.Landscape = True

                End If

                AddHandler PrintableComponentLink.CreateMarginalHeaderArea, AddressOf PrintableComponentLink_CreateMarginalHeaderArea

                CompositeLink.Links.Add(PrintableComponentLink)

                CompositeLink.ImageCollection.ImageStream = CType(ComponentResourceManager.GetObject("PrintableComponentLink.ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)

                CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultSendFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
                CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultExportFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
                CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DocumentDescription

                If Images IsNot Nothing Then

                    For Each Image In Images

                        CompositeLink.Images.Add(Image)

                    Next

                End If

                CompositeLink.CreateDocument()

                If IsScheduledReportService Then

                    If AdvantageServiceReportScheduleExportType = Database.Entities.Methods.AdvantageServiceReportScheduleExportType.CSV Then

                        PrintingSystem.ExportToCsv(SaveToFilename)

                    ElseIf AdvantageServiceReportScheduleExportType = Database.Entities.Methods.AdvantageServiceReportScheduleExportType.XLS Then

                        PrintingSystem.ExportToXls(SaveToFilename)

                    ElseIf AdvantageServiceReportScheduleExportType = Database.Entities.Methods.AdvantageServiceReportScheduleExportType.XLSX Then

                        PrintingSystem.ExportToXlsx(SaveToFilename)

                    End If

                Else

                    CompositeLink.ShowRibbonPreviewDialog(LookAndFeel)

                End If

                RemoveHandler ReportHeaderLink.CreateDetailArea, AddressOf ReportHeaderLink_CreateDetailArea
                RemoveHandler PrintableComponentLink.CreateMarginalHeaderArea, AddressOf PrintableComponentLink_CreateMarginalHeaderArea

            End If

        End Sub
        Public Sub CancelNewItemRow()

            Me.CurrentView.CancelNewItemRow()

            RaiseEvent NewItemRowCanceledEvent()

        End Sub
        Public Sub EnabledDisableNavigatorButtons()

            If _CustomDeleteButton IsNot Nothing Then

                _CustomDeleteButton.Enabled = (Me.IsNewItemOrAutoFilterRow() = False AndAlso Me.HasASelectedRow(False))

            End If

            If _CustomCancelEditButton IsNot Nothing Then

                _CustomCancelEditButton.Enabled = GridViewGridControl_MainView.IsNewItemRow(GridViewGridControl_MainView.FocusedRowHandle)

            End If

        End Sub
        Public Sub RemoveColumnFromUser(ColumnFieldName As String)

            If GridViewGridControl_MainView.Columns(ColumnFieldName) IsNot Nothing Then

                GridViewGridControl_MainView.Columns(ColumnFieldName).Visible = False
                GridViewGridControl_MainView.Columns(ColumnFieldName).OptionsColumn.AllowShowHide = False
                GridViewGridControl_MainView.Columns(ColumnFieldName).OptionsColumn.ShowInCustomizationForm = False
                GridViewGridControl_MainView.Columns(ColumnFieldName).OptionsColumn.ShowInExpressionEditor = False

            End If

        End Sub
        Public Sub MakeColumnNotVisible(ByVal ColumnFieldName As String)

            If GridViewGridControl_MainView.Columns(ColumnFieldName) IsNot Nothing Then

                If GridViewGridControl_MainView.Columns(ColumnFieldName).Visible Then

                    GridViewGridControl_MainView.Columns(ColumnFieldName).Visible = False

                End If

            End If

        End Sub
        Public Sub MakeColumnVisible(ByVal ColumnFieldName As String)

            If GridViewGridControl_MainView.Columns(ColumnFieldName) IsNot Nothing Then

                If GridViewGridControl_MainView.Columns(ColumnFieldName).Visible = False Then

                    GridViewGridControl_MainView.Columns(ColumnFieldName).VisibleIndex = GridViewGridControl_MainView.VisibleColumns.Count
                    GridViewGridControl_MainView.Columns(ColumnFieldName).Visible = True

                End If

            End If

        End Sub
        Public Sub MakeIsInactiveColumnNotVisible()

            MakeColumnNotVisible("IsInactive")

        End Sub
        Public Sub ClearGridCustomization()

            GridViewGridControl_MainView.ClearSorting()
            GridViewGridControl_MainView.ClearColumnsFilter()
            GridViewGridControl_MainView.ClearGrouping()
            GridViewGridControl_MainView.GroupSummary.Clear()
            GridViewGridControl_MainView.RestoredLayoutNonVisibleGridColumnList = Nothing

            Me.DataSourceViewOption = DataSourceViewOptions.Default
            Me.DataSource = Nothing
            Me.ItemDescription = ""

            Me.ClearColumns()

            Me.GridControl.RepositoryItems.Clear()

        End Sub
        Public Sub ValidateAllRows()

            GridViewGridControl_MainView.ValidateAllRows()

        End Sub
        Public Sub ValidateAllRowsAndClearChanged(Optional ByVal RaiseFormClearChanged As Boolean = False)

            GridViewGridControl_MainView.ValidateAllRows()

            Me.ClearChanged()

            If RaiseFormClearChanged Then

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ClearChanged()

                End If

            End If

        End Sub
        Public Sub SetUserEntryChanged()

            _UserEntryChanged = True

            AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

        End Sub
        Public Sub ShowRowSelection(ByVal RaiseGridViewSelectionChanged As Boolean)

            If GridViewGridControl_MainView.OptionsView.ShowIndicator = False Then

                GridViewGridControl_MainView.OptionsView.ShowIndicator = True
                GridViewGridControl_MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
                GridViewGridControl_MainView.OptionsSelection.EnableAppearanceFocusedCell = True
                GridViewGridControl_MainView.OptionsSelection.EnableAppearanceFocusedRow = True
                GridViewGridControl_MainView.OptionsSelection.EnableAppearanceHideSelection = True

                If RaiseGridViewSelectionChanged Then

                    GridViewGridControl_MainView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Public Sub HideRowSelection()

            If GridViewGridControl_MainView.OptionsView.ShowIndicator Then

                GridViewGridControl_MainView.OptionsView.ShowIndicator = False
                GridViewGridControl_MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
                GridViewGridControl_MainView.OptionsSelection.EnableAppearanceFocusedCell = False
                GridViewGridControl_MainView.OptionsSelection.EnableAppearanceFocusedRow = False
                GridViewGridControl_MainView.OptionsSelection.EnableAppearanceHideSelection = False

            End If

        End Sub
        Public Sub DeselectAll()

            GridViewGridControl_MainView.ClearSelection()

        End Sub
        Public Sub SelectAll()

            GridViewGridControl_MainView.SelectAll()

        End Sub
        Private Sub DeselectGroupHeaderRows()

            Try

                If Me.CurrentView.GroupCount > 0 AndAlso _AllowSelectGroupHeaderRow = False Then

                    For Each RowHandle In Me.CurrentView.GetSelectedRows

                        If Me.CurrentView.IsGroupRow(RowHandle) Then

                            Me.CurrentView.UnselectRow(RowHandle)

                        End If

                    Next

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Sub SetBookmarkColumnIndex(BookmarkColumnIndex As Integer)

            _BookmarkColumnIndex = BookmarkColumnIndex

        End Sub
        Public Sub HideAllColumns()

            For Each GridColumn In Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                GridColumn.VisibleIndex = -1
                GridColumn.Visible = False

            Next

        End Sub
        Public Sub ShowColumnSelectionMenu()

            'objects
            Dim BarCheckItem As DevExpress.XtraBars.BarCheckItem = Nothing

            BarSubItemPopup_Columns.ItemLinks.Clear()

            For Each GridColumn In Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                If GridColumn.OptionsColumn.AllowShowHide AndAlso GridColumn.OptionsColumn.ShowInCustomizationForm Then

                    BarCheckItem = New DevExpress.XtraBars.BarCheckItem

                    If String.IsNullOrWhiteSpace(GridColumn.Caption) = False Then

                        BarCheckItem.Caption = GridColumn.Caption

                    Else

                        BarCheckItem.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(GridColumn.FieldName)

                    End If

                    BarCheckItem.Tag = GridColumn
                    BarCheckItem.CloseSubMenuOnClick = False
                    BarCheckItem.Checked = GridColumn.Visible

                    BarSubItemPopup_Columns.AddItem(BarCheckItem)

                    AddHandler BarCheckItem.CheckedChanged, AddressOf BarCheckItem_CheckChanged

                End If

            Next

            PopupMenuGrid_Popup.ShowPopup(System.Windows.Forms.Control.MousePosition)

        End Sub
        Private Sub BarCheckItem_CheckChanged(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim BarCheckItem As DevExpress.XtraBars.BarCheckItem = Nothing

            BarCheckItem = DirectCast(e.Item, DevExpress.XtraBars.BarCheckItem)

            If BarCheckItem.Tag IsNot Nothing AndAlso TypeOf BarCheckItem.Tag Is DevExpress.XtraGrid.Columns.GridColumn Then

                GridColumn = DirectCast(BarCheckItem.Tag, DevExpress.XtraGrid.Columns.GridColumn)

                GridColumn.Visible = BarCheckItem.Checked

            End If

        End Sub
        Protected Function CreateCheckItem(ByVal Caption As String, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal FixedStyle As DevExpress.XtraGrid.Columns.FixedStyle, Optional ByVal Image As System.Drawing.Image = Nothing) As DevExpress.Utils.Menu.DXMenuCheckItem

            'objects
            Dim DXMenuCheckItem As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing

            DXMenuCheckItem = New DevExpress.Utils.Menu.DXMenuCheckItem(Caption, False, Image, New EventHandler(AddressOf OnFixedClick))

            DXMenuCheckItem.Tag = New AdvantageFramework.WinForm.Presentation.Controls.Classes.MenuInfo(GridColumn, FixedStyle)

            CreateCheckItem = DXMenuCheckItem

        End Function
        Protected Sub OnFixedClick(ByVal sender As Object, ByVal e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim MenuInfo As AdvantageFramework.WinForm.Presentation.Controls.Classes.MenuInfo = Nothing

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            MenuInfo = DXMenuItem.Tag

            If MenuInfo IsNot Nothing Then

                MenuInfo.GridColumn.Fixed = MenuInfo.FixedStyle

            End If

        End Sub
        Public Function GetBindingSourceDataBoundItems() As IEnumerable

            'objects
            Dim DataBoundItems As Generic.List(Of Object) = Nothing

            DataBoundItems = New Generic.List(Of Object)

            If Me.BindingSource IsNot Nothing Then

                For Item = 0 To Me.BindingSource.Count - 1

                    DataBoundItems.Add(DirectCast(DataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(Item))

                Next

            End If

            GetBindingSourceDataBoundItems = DataBoundItems

        End Function

#Region "  Control Event Handlers "

        Private Sub GridViewGridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

            RaiseEvent EmbeddedNavigatorButtonClick(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_AddNewRowEvent(ByVal RowObject As Object) Handles GridViewGridControl_MainView.AddNewRowEvent

            RaiseEvent AddNewRowEvent(RowObject)

        End Sub
        Private Sub GridViewGridControl_MainView_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles GridViewGridControl_MainView.BeforeAddNewRowEvent

            RaiseEvent BeforeAddNewRowEvent(RowObject, Cancel)

        End Sub
        Private Sub GridViewGridControl_MainView_CustomDrawColumnHeader(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles GridViewGridControl_MainView.CustomDrawColumnHeader

            RaiseEvent CustomDrawColumnHeaderEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridViewGridControl_MainView.CellValueChanging

            _ChangesAutoSaved = False

            RaiseEvent CellValueChangingEvent(_ChangesAutoSaved, e)

            If _ChangesAutoSaved = False AndAlso GridViewGridControl_MainView.UpdatingFilterData = False AndAlso
                    Me.IsNewItemOrAutoFilterRow(e.RowHandle) = False AndAlso _ByPassUserEntryChanged = False AndAlso
                    _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

            If Me.GridViewGridControl_MainView.IsNewItemRow(e.RowHandle) Then

                RaiseEvent NewItemRowCellValueChangingEvent(e)

            End If

        End Sub
        Private Sub GridViewGridControl_MainView_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridViewGridControl_MainView.CellValueChanged

            RaiseEvent CellValueChangedEvent(e)

            If _ChangesAutoSaved = False AndAlso GridViewGridControl_MainView.UpdatingFilterData = False AndAlso
                    Me.IsNewItemOrAutoFilterRow(e.RowHandle) = False AndAlso _ByPassUserEntryChanged = False AndAlso
                    _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

            If Me.GridViewGridControl_MainView.IsNewItemRow(e.RowHandle) Then

                RaiseEvent NewItemRowCellValueChangedEvent(e)

            End If

            RaiseEvent ColumnValueChangedEvent(e, True)

        End Sub
        Private Sub GridViewGridControl_MainView_LoadGridColumnComboBoxEvent(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn) Handles GridViewGridControl_MainView.LoadGridColumnComboBoxEvent

            RaiseEvent LoadGridColumnComboBoxEvent(GridColumn)

        End Sub
        Private Sub GridViewGridControl_MainView_RowClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridViewGridControl_MainView.RowClick

            If e.Button = Windows.Forms.MouseButtons.Left Then

                If e.Clicks = 2 Then

                    RaiseEvent RowDoubleClickEvent()

                ElseIf e.Clicks = 1 Then

                    RaiseEvent RowClick(sender, e)

                End If

            End If

            If _AlwaysForceShowRowSelectionOnUserInput Then

                ShowRowSelection(True)

            End If

        End Sub
        Private Sub GridViewGridControl_MainView_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewGridControl_MainView.RowCountChanged

            SetHeaderText()

            RaiseEvent RowCountChangedEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewGridControl_MainView.DataSourceChanged

            RaiseEvent DataSourceChangedEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewGridControl_MainView.FocusedRowChanged

            RaiseEvent BeforeSelectionChangedEvent(sender, e)

            If GridViewGridControl_MainView.OptionsSelection.MultiSelect = False Then

                DeselectGroupHeaderRows()

                RaiseEvent SelectionChangedEvent(sender, e)

                If _AlwaysForceShowRowSelectionOnUserInput Then

                    ShowRowSelection(False)

                End If

            End If

            EnabledDisableNavigatorButtons()

        End Sub
        Private Sub GridViewGridControl_MainView_SelectionChanged(ByVal sender As System.Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs) Handles GridViewGridControl_MainView.SelectionChanged

            If Me.HasASelectedRow = False AndAlso GridViewGridControl_MainView.FocusedRowHandle >= 0 Then

                GridViewGridControl_MainView.SelectRow(GridViewGridControl_MainView.FocusedRowHandle)

            End If

            If GridViewGridControl_MainView.OptionsSelection.MultiSelect Then

                DeselectGroupHeaderRows()

                RaiseEvent SelectionChangedEvent(sender, e)

                If _AlwaysForceShowRowSelectionOnUserInput Then

                    ShowRowSelection(True)

                End If

            End If

            EnabledDisableNavigatorButtons()

        End Sub
        Private Sub GridViewGridControl_MainView_IsExistAnyRowFooterCellEvent(ByVal RowHandle As Integer, ByRef Exists As Boolean) Handles GridViewGridControl_MainView.IsExistAnyRowFooterCellEvent

            Select Case _ControlType

                Case Type.DynamicReport

                    Exists = True

            End Select

        End Sub
        Private Sub GridViewGridControl_MainView_ColumnAddedEvent(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn) Handles GridViewGridControl_MainView.ColumnAddedEvent

            RaiseEvent ColumnAddedEvent(GridColumn)

        End Sub
        Private Sub GridViewGridControl_MainView_ColumnChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewGridControl_MainView.ColumnChanged

            RaiseEvent ColumnChangedEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_ColumnPositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewGridControl_MainView.ColumnPositionChanged

            RaiseEvent ColumnPositionChangedEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_CustomColumnDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridViewGridControl_MainView.CustomColumnDisplayText

            RaiseEvent CustomColumnDisplayTextEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_AsyncCompleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewGridControl_MainView.AsyncCompleted

            RaiseEvent AsyncCompletedEvent(sender, e)

        End Sub
        Private Sub ButtonBottomPanel_DeselectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBottomPanel_DeselectAll.Click

            GridViewGridControl_MainView.ClearSelection()

            RaiseEvent DeselectAllEvent()

        End Sub
        Private Sub ButtonBottomPanel_SelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBottomPanel_SelectAll.Click

            GridViewGridControl_MainView.SelectAll()

            RaiseEvent SelectAllEvent()

        End Sub
        Private Sub DataGridView_GridControl_ProcessGridKey(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView_GridControl.ProcessGridKey

            If e.KeyData = Windows.Forms.Keys.Escape Then

                If _ControlType = DataGridView.Type.EditableGrid Then

                    If GridViewGridControl_MainView.IsNewItemRow(GridViewGridControl_MainView.FocusedRowHandle) Then

                        If GridViewGridControl_MainView.GetRow(GridViewGridControl_MainView.FocusedRowHandle) IsNot Nothing Then

                            GridViewGridControl_MainView.CancelUpdateCurrentRow()
                            GridViewGridControl_MainView.NewItemRowText = ""

                        End If

                    End If

                End If

            ElseIf e.KeyData = Windows.Forms.Keys.Enter Then

                If _ControlType = DataGridView.Type.EditableGrid Then

                    If TypeOf GridViewGridControl_MainView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                        If DirectCast(GridViewGridControl_MainView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).IsPopupOpen = False Then

                            e.Handled = True
                            e.SuppressKeyPress = True

                            DirectCast(GridViewGridControl_MainView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).SendKey(New Windows.Forms.KeyEventArgs(Windows.Forms.Keys.Tab))

                        End If

                    End If

                End If

            ElseIf e.KeyData = Windows.Forms.Keys.Up OrElse e.KeyData = Windows.Forms.Keys.Down Then

                If _ControlType = Type.EditableGrid Then

                    If TypeOf GridViewGridControl_MainView.ActiveEditor Is DevExpress.XtraEditors.BaseSpinEdit Then

                        If e.KeyData = Windows.Forms.Keys.Up AndAlso GridViewGridControl_MainView.FocusedRowHandle <> 0 Then

                            GridViewGridControl_MainView.MovePrev()

                        ElseIf e.KeyData = Windows.Forms.Keys.Down AndAlso GridViewGridControl_MainView.FocusedRowHandle <> GridViewGridControl_MainView.RowCount - 1 Then

                            GridViewGridControl_MainView.MoveNext()

                        End If

                    End If

                End If

            ElseIf e.KeyData = Windows.Forms.Keys.Tab Then

                If _ControlType = Type.EditableGrid Then

                    If Not GridViewGridControl_MainView.IsNewItemOrAutoFilterRow() Then

                        If GridViewGridControl_MainView.FocusedRowHandle = GridViewGridControl_MainView.RowCount - 1 AndAlso
                                GridViewGridControl_MainView.FocusedColumn.Equals(GridViewGridControl_MainView.VisibleColumns.Last) Then

                            e.Handled = True
                            e.SuppressKeyPress = True

                            GridViewGridControl_MainView.CloseEditorForUpdating()
                            GridViewGridControl_MainView.ShowEditor()

                            If GridViewGridControl_MainView.ActiveEditor IsNot Nothing Then

                                GridViewGridControl_MainView.ActiveEditor.SelectAll()

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub GridViewGridControl_MainView_CustomRowFilter(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles GridViewGridControl_MainView.CustomRowFilter

            RaiseEvent CustomRowFilterEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridViewGridControl_MainView.ValidateRow

            RaiseEvent ValidateRowEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridViewGridControl_MainView.ValidatingEditor

            RaiseEvent ValidatingEditorEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridViewGridControl_MainView.InitNewRow

            RaiseEvent InitNewRowEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_MasterRowGetChildList(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles GridViewGridControl_MainView.MasterRowGetChildList

            RaiseEvent MasterRowGetChildListEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_MasterRowEmpty(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles GridViewGridControl_MainView.MasterRowEmpty

            RaiseEvent MasterRowEmptyEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_MasterRowGetRelationCount(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles GridViewGridControl_MainView.MasterRowGetRelationCount

            RaiseEvent MasterRowGetRelationCountEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_MasterRowGetRelationName(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles GridViewGridControl_MainView.MasterRowGetRelationName

            RaiseEvent MasterRowGetRelationNameEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_MasterRowGetRelationDisplayCaption(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles GridViewGridControl_MainView.MasterRowGetRelationDisplayCaption

            RaiseEvent MasterRowGetRelationDisplayCaptionEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_MasterRowGetLevelDefaultView(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles GridViewGridControl_MainView.MasterRowGetLevelDefaultView

            RaiseEvent MasterRowGetLevelDefaultViewEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_MasterRowExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles GridViewGridControl_MainView.MasterRowExpanded

            RaiseEvent MasterRowExpandedEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewGridControl_MainView.ShownEditor

            RaiseEvent ShownEditorEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_QueryPopupNeedDatasource(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles GridViewGridControl_MainView.QueryPopupNeedDatasource

            RaiseEvent QueryPopupNeedDatasourceEvent(FieldName, OverrideDefaultDatasource, Datasource)

        End Sub
        Private Sub GridViewGridControl_MainView_HiddenEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewGridControl_MainView.HiddenEditor

            RaiseEvent HiddenEditorEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_SubItemTextBoxButtonClickEvent(ByVal RowObject As Object) Handles GridViewGridControl_MainView.SubItemTextBoxButtonClickEvent

            RaiseEvent SubItemTextBoxButtonClickEvent(RowObject)

        End Sub
        Private Sub GridViewGridControl_MainView_MasterRowCollapsing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs) Handles GridViewGridControl_MainView.MasterRowCollapsing

            RaiseEvent MasterRowCollapsingEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_MasterRowCollapsed(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles GridViewGridControl_MainView.MasterRowCollapsed

            RaiseEvent MasterRowCollapsedEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_BeforeLeaveRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GridViewGridControl_MainView.BeforeLeaveRow

            If GridViewGridControl_MainView.IsValidRowHandle(e.RowHandle) Then

                RaiseEvent LeavingRowEvent(e)

                If GridViewGridControl_MainView.IsNewItemRow(e.RowHandle) Then

                    GridViewGridControl_MainView.RefreshData()

                End If

            End If

        End Sub
        Private Sub GridViewGridControl_MainView_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GridViewGridControl_MainView.CustomSummaryCalculate

            RaiseEvent CustomSummaryCalculateEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewGridControl_MainView.ColumnFilterChanged

            RaiseEvent ColumnFilterChangedEvent(sender, e)

            If _BindingSourcePositionChanged Then

                GridViewGridControl_MainView.GridViewSelectionChanged()

            End If

            If _AlwaysForceShowRowSelectionOnUserInput Then

                ShowRowSelection(Not _BindingSourcePositionChanged)

            End If

            _BindingSourcePositionChanged = False

        End Sub
        Private Sub GridViewGridControl_MainView_CustomColumnSort(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles GridViewGridControl_MainView.CustomColumnSort

            RaiseEvent CustomColumnSortEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_TopRowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewGridControl_MainView.TopRowChanged

            RaiseEvent TopRowChangedEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridViewGridControl_MainView.RowCellStyle

            RaiseEvent RowCellStyleEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_CustomRowCellEdit(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridViewGridControl_MainView.CustomRowCellEdit

            RaiseEvent CustomRowCellEditEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_ColumnEditValueChangedEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridViewGridControl_MainView.ColumnEditValueChangedEvent

            'RaiseEvent ColumnEditValueChangedEvent(Saved, e)

            'If Saved = False AndAlso GridViewGridControl_MainView.UpdatingFilterData = False AndAlso _
            '        Me.IsNewItemOrAutoFilterRow(e.RowHandle) = False AndAlso _ByPassUserEntryChanged = False AndAlso
            '        _SuspendedForLoading = False Then

            '    _UserEntryChanged = True

            '    AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            'End If

            RaiseEvent ColumnValueChangedEvent(e, False)

        End Sub
        Private Sub GridViewGridControl_MainView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridViewGridControl_MainView.ShowingEditor

            RaiseEvent ShowingEditorEvent(sender, e)

            If Me.HasRows = False AndAlso Me.IsNewItemRow(Me.CurrentView.FocusedRowHandle) Then

                GridViewGridControl_MainView.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub GridViewGridControl_MainView_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridViewGridControl_MainView.CustomDrawCell

            RaiseEvent CustomDrawCellEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridViewGridControl_MainView.PopupMenuShowing

            'objects
            Dim GridViewColumnMenu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = Nothing
            Dim DXMenuCheckItemFixedNone As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing
            Dim DXMenuCheckItemFixedLeft As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing

            If _AddFixedColumnCheckItemsToGridMenu Then

                If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                    GridViewColumnMenu = DirectCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu)

                    If GridViewColumnMenu.Column IsNot Nothing Then

                        DXMenuCheckItemFixedNone = CreateCheckItem("Fixed None", GridViewColumnMenu.Column, DevExpress.XtraGrid.Columns.FixedStyle.None)
                        DXMenuCheckItemFixedLeft = CreateCheckItem("Fixed Left", GridViewColumnMenu.Column, DevExpress.XtraGrid.Columns.FixedStyle.Left)

                        DXMenuCheckItemFixedNone.BeginGroup = True

                        GridViewColumnMenu.Items.Add(DXMenuCheckItemFixedNone)
                        GridViewColumnMenu.Items.Add(DXMenuCheckItemFixedLeft)

                        If GridViewColumnMenu.Column.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left Then

                            DXMenuCheckItemFixedLeft.Checked = True
                            DXMenuCheckItemFixedNone.Checked = False

                        Else

                            DXMenuCheckItemFixedLeft.Checked = False
                            DXMenuCheckItemFixedNone.Checked = True

                        End If

                    End If

                End If

            End If

            RaiseEvent PopupMenuShowingEvent(sender, e)

        End Sub
        Private Sub _BindingSource_AddingNew(sender As Object, e As ComponentModel.AddingNewEventArgs) Handles _BindingSource.AddingNew

            RaiseEvent DataSourceAddNewRowEvent(e.NewObject)

        End Sub
        Private Sub _BindingSource_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _BindingSource.PositionChanged

            _BindingSourcePositionChanged = True

            _PreviousPosition = _BindingSource.Position

        End Sub
        Private Sub GridViewGridControl_MainView_RepositoryDataSourceLoadingEvent(ByVal FieldName As String, ByRef Cancel As Boolean) Handles GridViewGridControl_MainView.RepositoryDataSourceLoadingEvent

            RaiseEvent RepositoryDataSourceLoading(FieldName, Cancel)

        End Sub
        Private Sub GridViewGridControl_MainView_ShowFilterPopupListBox(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs) Handles GridViewGridControl_MainView.ShowFilterPopupListBox

            e.ComboBox.BeginUpdate()

            Try

                For Each FilterItem In e.ComboBox.Items.OfType(Of DevExpress.XtraGrid.Views.Grid.FilterItem).ToList

                    If String.IsNullOrEmpty(FilterItem.Text) AndAlso String.IsNullOrEmpty(FilterItem.Value) Then

                        e.ComboBox.Items.Remove(FilterItem)

                    End If

                Next

            Catch ex As Exception

            End Try

            e.ComboBox.EndUpdate()

        End Sub
        Private Sub GridViewGridControl_MainView_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GridViewGridControl_MainView.CustomDrawGroupRow

            RaiseEvent CustomDrawGroupRowEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridViewGridControl_MainView.RowCellClick

            If e.Clicks = 2 Then

                RaiseEvent RowCellDoubleClickEvent(sender, e)

            Else

                RaiseEvent RowCellClickEvent(sender, e)

            End If

        End Sub
        Private Sub GridViewGridControl_MainView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GridViewGridControl_MainView.CustomUnboundColumnData

            RaiseEvent CustomUnboundColumnDataEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GridViewGridControl_MainView.CustomDrawRowIndicator

            RaiseEvent CustomDrawRowIndicatorEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_ColumnWidthChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles GridViewGridControl_MainView.ColumnWidthChanged

            RaiseEvent ColumnWidthChangedEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles GridViewGridControl_MainView.KeyDown

            RaiseEvent GridViewKeyDownEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_OnEditUnboundColumnClickEvent(GridColumn As DevExpress.XtraGrid.Columns.GridColumn) Handles GridViewGridControl_MainView.OnEditUnboundColumnClickEvent

            If GridColumn IsNot Nothing Then

                If AdvantageFramework.WinForm.Presentation.ComplexExpressionEditorDialog.ShowFormDialog("Edit Unbound Column", Me.CurrentView, GridColumn, AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn.Properties.HeaderText) = Windows.Forms.DialogResult.OK Then

                    If TypeOf Me.DataSource Is System.Windows.Forms.BindingSource Then

                        If DirectCast(Me.DataSource, System.Windows.Forms.BindingSource).Count > 0 Then

                            Me.DataSource = DirectCast(Me.DataSource, System.Windows.Forms.BindingSource).DataSource

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub GridViewGridControl_MainView_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles GridViewGridControl_MainView.MouseDown

            'objects
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

            If e.Button = Windows.Forms.MouseButtons.Right Then

                If _ShowColumnMenuOnRightClick Then

                    If GridViewGridControl_MainView.CalcHitInfo(e.X, e.Y).HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Column Then

                        ShowColumnSelectionMenu()

                    End If

                End If

            End If

            RaiseEvent GridViewMouseDownEvent(sender, e)

            _DragAndDropGridHitInfo = Nothing

            If Me.AllowDragAndDrop Then

                If System.Windows.Forms.Control.ModifierKeys = System.Windows.Forms.Keys.None Then

                    GridHitInfo = GridViewGridControl_MainView.CalcHitInfo(New System.Drawing.Point(e.X, e.Y))

                    If e.Button = System.Windows.Forms.MouseButtons.Left AndAlso GridHitInfo.InRow AndAlso GridHitInfo.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then

                        _DragAndDropGridHitInfo = GridHitInfo

                    End If

                End If

            End If

        End Sub
        Private Sub GridViewGridControl_MainView_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles GridViewGridControl_MainView.MouseMove

            'objects
            Dim DragSize As System.Drawing.Size = Nothing
            Dim DragRectangle As System.Drawing.Rectangle = Nothing

            If Me.AllowDragAndDrop AndAlso e.Button = System.Windows.Forms.MouseButtons.Left AndAlso _DragAndDropGridHitInfo IsNot Nothing Then

                DragSize = System.Windows.Forms.SystemInformation.DragSize
                DragRectangle = New System.Drawing.Rectangle(New System.Drawing.Point(_DragAndDropGridHitInfo.HitPoint.X - DragSize.Width \ 2, _DragAndDropGridHitInfo.HitPoint.Y - DragSize.Height \ 2), DragSize)

                If DragRectangle.Contains(New System.Drawing.Point(e.X, e.Y)) = False Then

                    DataGridView_GridControl.DoDragDrop(_DragAndDropGridHitInfo, System.Windows.Forms.DragDropEffects.All)
                    _DragAndDropGridHitInfo = Nothing

                End If

            End If

        End Sub
        Private Sub DataGridView_GridControl_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles DataGridView_GridControl.DragDrop

            'objects
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim DragHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

            Try

                GridHitInfo = TryCast(e.Data.GetData(GetType(DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)

            Catch ex As Exception
                GridHitInfo = Nothing
            End Try

            Try

                DragHitInfo = GridViewGridControl_MainView.CalcHitInfo(DataGridView_GridControl.PointToClient(New System.Drawing.Point(e.X, e.Y)))

            Catch ex As Exception
                DragHitInfo = Nothing
            End Try

            If GridHitInfo IsNot Nothing AndAlso DragHitInfo IsNot Nothing Then

                RaiseEvent DragAndDropRowsEvent(DragHitInfo.RowHandle, GridViewGridControl_MainView.GetSelectedRows)

            End If

        End Sub
        Private Sub DataGridView_GridControl_DragOver(sender As Object, e As Windows.Forms.DragEventArgs) Handles DataGridView_GridControl.DragOver

            'objects
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim DragHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

            If e.Data.GetDataPresent(GetType(DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)) Then

                GridHitInfo = TryCast(e.Data.GetData(GetType(DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)

                If GridHitInfo IsNot Nothing Then

                    DragHitInfo = GridViewGridControl_MainView.CalcHitInfo(DataGridView_GridControl.PointToClient(New System.Drawing.Point(e.X, e.Y)))

                    If DragHitInfo.InRow AndAlso DragHitInfo.RowHandle <> GridHitInfo.RowHandle AndAlso DragHitInfo.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then

                        e.Effect = System.Windows.Forms.DragDropEffects.Move

                    Else

                        e.Effect = System.Windows.Forms.DragDropEffects.None

                    End If

                End If

            End If

        End Sub
        Private Sub GridViewGridControl_MainView_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GridViewGridControl_MainView.CellMerge

            RaiseEvent CellMergeEvent(sender, e)

        End Sub
        Private Sub DataGridView_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Private Sub DataGridView_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

            'RemoveHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings
            RemoveHandler DataGridView_GridControl.EmbeddedNavigator.ButtonClick, AddressOf GridViewGridControl_EmbeddedNavigator_ButtonClick

            If _InstantFeedbackSource IsNot Nothing Then

                RemoveHandler CType(_InstantFeedbackSource, DevExpress.Data.Linq.EntityInstantFeedbackSource).DismissQueryable, AddressOf InstantFeedbackSource_DismissQueryable
                RemoveHandler CType(_InstantFeedbackSource, DevExpress.Data.Linq.EntityInstantFeedbackSource).GetQueryable, AddressOf InstantFeedbackSource_GetQueryable
                RemoveHandler CType(_InstantFeedbackSource, DevExpress.Data.Linq.EntityInstantFeedbackSource).DismissQueryable, AddressOf InstantFeedbackSource_DismissQueryable
                RemoveHandler CType(_InstantFeedbackSource, DevExpress.Data.Linq.EntityInstantFeedbackSource).GetQueryable, AddressOf InstantFeedbackSource_GetQueryable

            End If

            If _BindingSource IsNot Nothing Then

                Try

                    _BindingSource.DataSource = Nothing

                Catch ex As Exception

                End Try

                Try

                    _BindingSource.Dispose()

                    _BindingSource = Nothing

                Catch ex As Exception

                End Try

                Try

                    For Each GridColumn In GridViewGridControl_MainView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.ColumnEdit IsNot Nothing AndAlso GridColumn.ColumnEdit.GetType.Equals(GetType(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)) Then

                            DirectCast(DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).DataSource, Windows.Forms.BindingSource).Dispose()

                            DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).DataSource = Nothing

                        ElseIf GridColumn.ColumnEdit IsNot Nothing Then

                            GridColumn.ColumnEdit = Nothing

                        End If

                        GridViewGridControl_MainView.Columns.Remove(GridColumn)

                    Next

                Catch ex As Exception

                End Try

                Try

                    DataGridView_GridControl.RepositoryItems.Clear()

                Catch ex As Exception

                End Try

            End If

            Try

                DataGridView_GridControl.MainView = Nothing

            Catch ex As Exception

            End Try

            Try

                GridViewGridControl_MainView.Dispose()

            Catch ex As Exception

            End Try

            Try

                DataGridView_GridControl.Dispose()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub GridViewGridControl_MainView_ShowCustomizationForm(sender As Object, e As EventArgs) Handles GridViewGridControl_MainView.ShowCustomizationForm

            RaiseEvent ShowCustomizationFormEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_HideCustomizationForm(sender As Object, e As EventArgs) Handles GridViewGridControl_MainView.HideCustomizationForm

            RaiseEvent HideCustomizationFormEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_CanAutoFillValueEvent(ByRef CanAutoFillValue As Boolean, PropertyDescriptor As ComponentModel.PropertyDescriptor) Handles GridViewGridControl_MainView.CanAutoFillValueEvent

            RaiseEvent CanAutoFillValueEvent(CanAutoFillValue, PropertyDescriptor)

        End Sub
        Private Sub GridViewGridControl_MainView_GotFocus(sender As Object, e As EventArgs) Handles GridViewGridControl_MainView.GotFocus

            RaiseEvent GotFocusEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_LostFocus(sender As Object, e As EventArgs) Handles GridViewGridControl_MainView.LostFocus

            RaiseEvent LostFocusEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_CustomDrawFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles GridViewGridControl_MainView.CustomDrawFooterCell

            RaiseEvent CustomDrawFooterCellEvent(e)

        End Sub
        Private Sub GridViewGridControl_MainView_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridViewGridControl_MainView.FocusedColumnChanged

            RaiseEvent FocusedColumnChangedEvent(e)

        End Sub
        Private Sub GridViewGridControl_MainView_DragObjectOver(sender As Object, e As DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs) Handles GridViewGridControl_MainView.DragObjectOver

            RaiseEvent DragObjectOverEvent(sender, e)

        End Sub
        Private Sub GridViewGridControl_MainView_CustomDrawFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GridViewGridControl_MainView.CustomDrawFooter

            RaiseEvent CustomDrawFooterEvent(sender, e)

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ReportHeaderLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            RaiseEvent CreateReportHeaderAreaEvent(sender, e)

        End Sub
        Private Sub PrintableComponentLink_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            RaiseEvent CreateMarginalHeaderAreaEvent(sender, e)

        End Sub
        Private Sub PopupMenuGrid_Popup_CloseUp(sender As Object, e As EventArgs) Handles PopupMenuGrid_Popup.CloseUp

            RaiseEvent PopupMenuClosing()

        End Sub

#End Region

#End Region

    End Class

End Namespace
