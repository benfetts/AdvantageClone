Namespace WinForm.MVC.Presentation.Controls

    Public Class BandedDataGridView
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

        Public Event SelectionChangedEvent(sender As Object, e As System.EventArgs)
        Public Event CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Public Event CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Public Event ColumnValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Public Event ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs)
        Public Event ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs)
        Public Event InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event AddNewRowEvent(RowObject As Object)
        Public Event ShownEditorEvent(sender As Object, e As System.EventArgs)
        Public Event ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Public Event RowClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)
        Public Event RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)
        Public Event NewItemRowCellValueChangingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Public Event NewItemRowCellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Public Event FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Public Event BeforeLeaveRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs)
        Public Event RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object)
        Public Event QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)
        Public Event SelectAllEvent()
        Public Event DeselectAllEvent()
        Public Event DataSourceChangedEvent(sender As Object, e As System.EventArgs)
        Public Event EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Public Event CustomRowCellEditForEditingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs)
        Public Event PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Public Event CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs)
        Public Event CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs)
        Public Event RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Public Event CustomDrawRowFooterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs)
        Public Event CustomDrawRowFooterCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs)
        Public Event MouseDownEvent(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Public Event CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
        Public Event EndGroupingEvent(sender As Object, e As EventArgs)
        Public Event CustomDrawFooterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs)
        Public Event CustomDrawBandHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs)
        Public Event EndSortingEvent(sender As Object, e As EventArgs)
        Public Event DragObjectOverEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs)
        Public Event ColumnFilterChangedEvent(sender As Object, e As EventArgs)
        Public Event ColumnPositionChangedEvent(sender As Object, e As EventArgs)
        Public Event ColumnWidthChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs)
        Public Event BandWidthChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.BandedGrid.BandEventArgs)
        Public Event HideCustomizationFormEvent(sender As Object, e As EventArgs)
        Public Event ShowCustomizationFormEvent(sender As Object, e As EventArgs)
        Public Event CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs)
        Public Event CustomDrawColumnHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs)
        Public Event CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        Public Event CustomColumnGroupEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs)
        Public Event CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs)
        Public Event ProcessGridKeyEvent(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        Public Event FocusedColumnChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs)
        Public Event CustomUnboundColumnDataEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        Public Event ColumnEditValueChangingEvent(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        Public Event CreateReportFooterAreaEvent(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs)
        Public Event CreateMarginalFooterAreaEvent(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs)
        Public Event CreateReportHeaderAreaEvent(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs)
        Public Event AlterSubItemGridLookupEditPropertiesEvent(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl)
        Public Event CustomRowFilterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs)
        Public Event GridViewKeyDownEvent(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        Public Event CustomDrawFilterPanelEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomDrawObjectEventArgs)
        Public Event CustomDrawFooterCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs)
        Public Event SubItemGridLookUpEditControlEditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        Public Event MasterRowGetChildListEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs)
        Public Event MasterRowGetRelationNameEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs)
        Public Event MasterRowGetRelationCountEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs)
        Public Event MasterRowEmptyEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs)
        Public Event MasterRowGetRelationDisplayCaptionEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs)
        Public Event MasterRowGetLevelDefaultViewEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs)
        Public Event MasterRowExpandedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs)
        Public Event MasterRowCollapsingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs)
        Public Event MasterRowCollapsedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs)
        Public Event GroupRowCollapsedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs)
        Public Event GroupRowCollapsingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs)
        Public Event GroupRowExpandedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs)
        Public Event GroupRowExpandingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs)
        Public Event StartSortingEvent(sender As Object, e As EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _BookmarkColumnIndex As Integer = -1
        Protected _FormSettingsLoaded As Boolean = False
        Protected _CurrentBookmark As Object = Nothing
        Protected _NextBookmark As Object = Nothing
        Protected _ItemDescription As String = ""
        Protected WithEvents _BindingSource As System.Windows.Forms.BindingSource = Nothing
        Protected _BindingSourcePositionChanged As Boolean = False
        Protected _PreviousPosition As Integer = -1
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _AllowSelectGroupHeaderRow As Boolean = True
        Protected _ChangesAutoSaved As Boolean = False
        Protected _AutoUpdateViewCaption As Boolean = True
        Protected _UseEmbeddedNavigator As Boolean = False
        Protected _CustomDeleteButton As DevExpress.XtraEditors.NavigatorCustomButton = Nothing
        Protected _CustomCancelEditButton As DevExpress.XtraEditors.NavigatorCustomButton = Nothing
        Protected _ShowRowSelectionIfHidden As Boolean = True
        Protected _SelectRowsWhenSelectDeselectAllButtonClicked As Boolean = True

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
        Public Property ItemDescription() As String
            Get
                ItemDescription = _ItemDescription
            End Get
            Set(value As String)
                _ItemDescription = value
            End Set
        End Property
        Public Property FilterPopupMode As DevExpress.XtraGrid.Columns.FilterPopupMode
            Get
                FilterPopupMode = BandedGridViewGridControl_MainView.FilterPopupMode
            End Get
            Set(value As DevExpress.XtraGrid.Columns.FilterPopupMode)
                BandedGridViewGridControl_MainView.FilterPopupMode = value
            End Set
        End Property
        Public ReadOnly Property UserEntryChanged As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.UserEntryChanged
            Get
                UserEntryChanged = _UserEntryChanged
            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(value As Boolean)
                _ByPassUserEntryChanged = value
            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
            End Set
        End Property
        Public Property ViewCaptionHeight() As Integer
            Get
                ViewCaptionHeight = BandedGridViewGridControl_MainView.ViewCaptionHeight
            End Get
            Set(value As Integer)
                BandedGridViewGridControl_MainView.ViewCaptionHeight = value
            End Set
        End Property
        Public Property ShowSelectDeselectAllButtons() As Boolean
            Get
                ShowSelectDeselectAllButtons = PanelControl_BottomPanel.Visible
            End Get
            Set(value As Boolean)
                PanelControl_BottomPanel.Visible = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public ReadOnly Property Columns() As DevExpress.XtraGrid.Columns.GridColumnCollection
            Get
                Columns = BandedGridViewGridControl_MainView.Columns
            End Get
        End Property
        Public Property MultiSelect() As Boolean
            Get
                MultiSelect = BandedGridViewGridControl_MainView.OptionsSelection.MultiSelect
            End Get
            Set(value As Boolean)
                BandedGridViewGridControl_MainView.OptionsSelection.MultiSelect = value
            End Set
        End Property
        Public Property NewItemRowPosition() As DevExpress.XtraGrid.Views.Grid.NewItemRowPosition
            Get
                NewItemRowPosition = BandedGridViewGridControl_MainView.OptionsView.NewItemRowPosition
            End Get
            Set(value As DevExpress.XtraGrid.Views.Grid.NewItemRowPosition)
                BandedGridViewGridControl_MainView.OptionsView.NewItemRowPosition = value
            End Set
        End Property
        Public ReadOnly Property HasOnlyOneSelectedRow(Optional ExcludeNonDataRows As Boolean = True) As Boolean
            Get

                HasOnlyOneSelectedRow = (BandedGridViewGridControl_MainView.SelectedRowsCount = 1)

                If ExcludeNonDataRows AndAlso HasOnlyOneSelectedRow Then

                    HasOnlyOneSelectedRow = BandedGridViewGridControl_MainView.IsDataRow(BandedGridViewGridControl_MainView.FocusedRowHandle)

                End If

            End Get
        End Property
        Public ReadOnly Property HasOnlyNewItemRowSelected() As Boolean
            Get
                HasOnlyNewItemRowSelected = (BandedGridViewGridControl_MainView.IsNewItemRow(BandedGridViewGridControl_MainView.FocusedRowHandle) AndAlso
                                            BandedGridViewGridControl_MainView.SelectedRowsCount = 1)
            End Get
        End Property
        Public ReadOnly Property HasOnlyAutoFilterSelectedRow() As Boolean
            Get
                HasOnlyAutoFilterSelectedRow = (BandedGridViewGridControl_MainView.IsFilterRow(BandedGridViewGridControl_MainView.FocusedRowHandle) AndAlso
                                            BandedGridViewGridControl_MainView.SelectedRowsCount = 1)
            End Get
        End Property
        Public ReadOnly Property HasMultipleSelectedRows(Optional ExcludeNonDataRows As Boolean = True) As Boolean
            Get

                'objects
                Dim SelectedRowsList As Generic.List(Of Integer) = Nothing

                HasMultipleSelectedRows = (BandedGridViewGridControl_MainView.SelectedRowsCount > 1)

                If ExcludeNonDataRows AndAlso HasMultipleSelectedRows Then

                    SelectedRowsList = New Generic.List(Of Integer)

                    For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                        If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                            SelectedRowsList.Add(RowHandle)

                        End If

                    Next

                    HasMultipleSelectedRows = (SelectedRowsList.Count > 1)

                End If

            End Get
        End Property
        Public ReadOnly Property HasOnlyDataRowsSelected() As Boolean
            Get

                'objects
                Dim OnlyDataRowsSelected As Boolean = False

                If BandedGridViewGridControl_MainView.GetSelectedRows.Count > 1 Then

                    OnlyDataRowsSelected = True

                    For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                        If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) = False Then

                            OnlyDataRowsSelected = False

                        End If

                    Next

                End If

                HasOnlyDataRowsSelected = OnlyDataRowsSelected

            End Get
        End Property
        Public ReadOnly Property HasOnlyGroupRowsSelected() As Boolean
            Get

                'objects
                Dim OnlyGroupRowsSelected As Boolean = False

                If BandedGridViewGridControl_MainView.GetSelectedRows.Count > 1 Then

                    OnlyGroupRowsSelected = True

                    For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                        If BandedGridViewGridControl_MainView.IsGroupRow(RowHandle) = False Then

                            OnlyGroupRowsSelected = False

                        End If

                    Next

                End If

                HasOnlyGroupRowsSelected = OnlyGroupRowsSelected

            End Get
        End Property
        Public ReadOnly Property HasASelectedRow(Optional ExcludeNonDataRows As Boolean = True) As Boolean
            Get

                'objects
                Dim SelectedRowsList As Generic.List(Of Integer) = Nothing

                HasASelectedRow = (BandedGridViewGridControl_MainView.SelectedRowsCount > 0)

                If ExcludeNonDataRows AndAlso HasASelectedRow Then

                    SelectedRowsList = New Generic.List(Of Integer)

                    For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                        If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                            SelectedRowsList.Add(RowHandle)

                        End If

                    Next

                    HasASelectedRow = SelectedRowsList.Any

                End If

            End Get
        End Property
        Public ReadOnly Property HasRows() As Boolean
            Get
                HasRows = (BandedGridViewGridControl_MainView.DataRowCount > 0)
            End Get
        End Property
        <ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
        Public Property DataSource() As Object
            Get
                DataSource = BandedDataGridView_GridControl.DataSource
            End Get
            Set(value As Object)
                LoadDataSource(value)
            End Set
        End Property
        Public ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                BindingSource = DirectCast(BandedDataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource)
            End Get
        End Property
        Public ReadOnly Property OptionsBehavior As DevExpress.XtraGrid.Views.Grid.GridOptionsBehavior
            Get
                OptionsBehavior = Me.BandedGridViewGridControl_MainView.OptionsBehavior
            End Get
        End Property
        Public ReadOnly Property OptionsCustomization As DevExpress.XtraGrid.Views.Grid.GridOptionsCustomization
            Get
                OptionsCustomization = Me.BandedGridViewGridControl_MainView.OptionsCustomization
            End Get
        End Property
        Public ReadOnly Property OptionsDetail As DevExpress.XtraGrid.Views.Grid.GridOptionsDetail
            Get
                OptionsDetail = Me.BandedGridViewGridControl_MainView.OptionsDetail
            End Get
        End Property
        Public ReadOnly Property OptionsFilter As DevExpress.XtraGrid.Views.Base.ColumnViewOptionsFilter
            Get
                OptionsFilter = Me.BandedGridViewGridControl_MainView.OptionsFilter
            End Get
        End Property
        Public ReadOnly Property OptionsFind As DevExpress.XtraGrid.Views.Base.ColumnViewOptionsFind
            Get
                OptionsFind = Me.BandedGridViewGridControl_MainView.OptionsFind
            End Get
        End Property
        Public ReadOnly Property OptionsLayout As DevExpress.Utils.OptionsLayoutGrid
            Get
                OptionsLayout = Me.BandedGridViewGridControl_MainView.OptionsLayout
            End Get
        End Property
        Public ReadOnly Property OptionsHint As DevExpress.XtraGrid.Views.Grid.GridOptionsHint
            Get
                OptionsHint = Me.BandedGridViewGridControl_MainView.OptionsHint
            End Get
        End Property
        Public ReadOnly Property OptionsMenu As DevExpress.XtraGrid.Views.Grid.GridOptionsMenu
            Get
                OptionsMenu = Me.BandedGridViewGridControl_MainView.OptionsMenu
            End Get
        End Property
        Public ReadOnly Property OptionsNavigation As DevExpress.XtraGrid.Views.Grid.GridOptionsNavigation
            Get
                OptionsNavigation = Me.BandedGridViewGridControl_MainView.OptionsNavigation
            End Get
        End Property
        Public ReadOnly Property OptionsPrint As DevExpress.XtraGrid.Views.Grid.GridOptionsPrint
            Get
                OptionsPrint = Me.BandedGridViewGridControl_MainView.OptionsPrint
            End Get
        End Property
        Public ReadOnly Property OptionsSelection As DevExpress.XtraGrid.Views.Grid.GridOptionsSelection
            Get
                OptionsSelection = Me.BandedGridViewGridControl_MainView.OptionsSelection
            End Get
        End Property
        Public ReadOnly Property OptionsView As DevExpress.XtraGrid.Views.Grid.GridOptionsView
            Get
                OptionsView = Me.BandedGridViewGridControl_MainView.OptionsView
            End Get
        End Property
        Public ReadOnly Property GridControl As BandedGridControl
            Get
                GridControl = Me.BandedDataGridView_GridControl
            End Get
        End Property
        Public ReadOnly Property CurrentView As BandedGridView
            Get
                CurrentView = Me.BandedGridViewGridControl_MainView
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
        Public Property UseEmbeddedNavigator As Boolean
            Get
                UseEmbeddedNavigator = _UseEmbeddedNavigator
            End Get
            Set(ByVal value As Boolean)
                _UseEmbeddedNavigator = UseEmbeddedNavigator
                SetupEmbeddedNavigator(value)
            End Set
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
        Public Property ModifyGridRowHeight As Boolean
            Get
                ModifyGridRowHeight = BandedGridViewGridControl_MainView.ModifyGridRowHeight
            End Get
            Set(value As Boolean)
                BandedGridViewGridControl_MainView.ModifyGridRowHeight = value
            End Set
        End Property
        Public Property ModifyColumnSettingsOnEachDataSource As Boolean
            Get
                ModifyColumnSettingsOnEachDataSource = BandedGridViewGridControl_MainView.ModifyColumnSettingsOnEachDataSource
            End Get
            Set(value As Boolean)
                BandedGridViewGridControl_MainView.ModifyColumnSettingsOnEachDataSource = value
            End Set
        End Property
        Public Property ShowRowSelectionIfHidden As Boolean
            Get
                ShowRowSelectionIfHidden = _ShowRowSelectionIfHidden
            End Get
            Set(value As Boolean)
                _ShowRowSelectionIfHidden = value
            End Set
        End Property
        Public Property SelectRowsWhenSelectDeselectAllButtonClicked As Boolean
            Get
                SelectRowsWhenSelectDeselectAllButtonClicked = _SelectRowsWhenSelectDeselectAllButtonClicked
            End Get
            Set(value As Boolean)
                _SelectRowsWhenSelectDeselectAllButtonClicked = value
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

            BandedGridViewGridControl_MainView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always

        End Sub
        Public Sub ClearChanged() Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

            Try

                BandedGridViewGridControl_MainView.ClearChanged()

            Catch ex As Exception

            End Try

        End Sub
        Public Function IsNewItemOrAutoFilterRow(RowHandle As Integer) As Boolean

            IsNewItemOrAutoFilterRow = BandedGridViewGridControl_MainView.IsNewItemOrAutoFilterRow(RowHandle)

        End Function
        Public Function IsNewItemOrAutoFilterRow() As Boolean

            IsNewItemOrAutoFilterRow = BandedGridViewGridControl_MainView.IsNewItemOrAutoFilterRow()

        End Function
        Public Function IsNewItemRow(RowHandle As Integer) As Boolean

            IsNewItemRow = BandedGridViewGridControl_MainView.IsNewItemRow(RowHandle)

        End Function
        Public Function IsNewItemRow() As Boolean

            IsNewItemRow = BandedGridViewGridControl_MainView.IsNewItemRow(BandedGridViewGridControl_MainView.FocusedRowHandle)

        End Function
        Public Sub ClearDatasource(Optional DefaultList As Object = Nothing)

            If Me.NewItemRowPosition <> DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None Then

                Me.CancelNewItemRow()

            End If

            Me.DataSource = DefaultList

        End Sub
        Protected Overrides Sub LoadFormSettings(Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                Form.Controls.Find(Me.Name, True).Any Then

                'If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

                '	_Session = DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session

                'End If

                'BandedGridViewGridControl_MainView.Session = _Session

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
        Protected Overridable Sub SetupDataGrid()

            _BookmarkColumnIndex = -1
            _ByPassUserEntryChanged = True

        End Sub
        Protected Sub LoadDataSource(ByRef Value As Object)

            BandedDataGridView_GridControl.BeginUpdate()
            BandedGridViewGridControl_MainView.BeginUpdate()

            LoadBookmarks()

            If _BindingSource Is Nothing Then

                _BindingSource = New System.Windows.Forms.BindingSource

            End If

            If TypeOf Value Is IEnumerable Then

                Try

                    Me.CurrentView.ObjectType = DirectCast(Value, IEnumerable).AsQueryable.ElementType

                Catch ex As Exception

                End Try

            Else

                Me.CurrentView.ObjectType = GetType(Object)

            End If

            _BindingSource.DataSource = Value

            BandedDataGridView_GridControl.DataSource = _BindingSource

            If BandedGridViewGridControl_MainView.RestoredLayoutNonVisibleGridColumnList IsNot Nothing Then

                For Each GridColumn In BandedGridViewGridControl_MainView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    If BandedGridViewGridControl_MainView.RestoredLayoutNonVisibleGridColumnList.Contains(GridColumn) Then

                        GridColumn.Visible = False

                    End If

                Next

            End If

            Me.ClearChanged()

            If _PreviousPosition = 0 AndAlso _BindingSource.Position = 0 Then

                BandedGridViewGridControl_MainView.GridViewSelectionChanged()

            ElseIf BandedGridViewGridControl_MainView.FocusedRowHandle = 0 AndAlso _BindingSource.Position = 1 Then

                BandedGridViewGridControl_MainView.GridViewSelectionChanged()

            End If

            If _ItemDescription = "" OrElse _ItemDescription = "Item(s)" Then

                _ItemDescription = AdvantageFramework.WinForm.Presentation.Controls.LoadDefaultGridViewItemDescription(Me.CurrentView.ObjectType)

            End If

            SetHeaderText()

            SetBookmarks()

            BandedDataGridView_GridControl.EndUpdate()
            BandedGridViewGridControl_MainView.EndUpdate()

        End Sub
        Public Sub ModifyColumn(FieldName As String, Optional Visible As Boolean = True, Optional Caption As String = Nothing)

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

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If CType(Me.FindForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).IsFormClosing = False Then

                        BandedGridViewGridControl_MainView.ViewCaption = BandedGridViewGridControl_MainView.DataRowCount.ToString("N0") & " " & _ItemDescription

                    End If

                Else

                    BandedGridViewGridControl_MainView.ViewCaption = BandedGridViewGridControl_MainView.DataRowCount.ToString("N0") & " " & _ItemDescription

                End If

            End If

        End Sub
        Public Sub RefreshViewCaption()

            SetHeaderText()

        End Sub
        Public Function GetAllSelectedRowsDataBoundItems() As IEnumerable

            GetAllSelectedRowsDataBoundItems = BandedGridViewGridControl_MainView.GetSelectedRows.Where(Function(RowHandle) BandedGridViewGridControl_MainView.IsDataRow(RowHandle) = True).Select(Function(RowHandle) DirectCast(BandedDataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(BandedGridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle)))

        End Function
        Public Function GetAllSelectedRowsRowHandlesAndDataBoundItems() As Generic.Dictionary(Of Integer, Object)

            'objects
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            RowHandlesAndDataBoundItems = New Generic.Dictionary(Of Integer, Object)

            For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                    Try

                        RowHandlesAndDataBoundItems(RowHandle) = DirectCast(BandedDataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(BandedGridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle))

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

            For RowHandle = 0 To BandedGridViewGridControl_MainView.RowCount - 1

                If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                    Try

                        RowHandlesAndDataBoundItems(RowHandle) = DirectCast(BandedDataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(BandedGridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle))

                    Catch ex As Exception
                        RowHandlesAndDataBoundItems(RowHandle) = Nothing
                    End Try

                End If

            Next

            GetAllRowsRowHandlesAndDataBoundItems = RowHandlesAndDataBoundItems

        End Function
        Public Function CheckForModifiedRows() As Boolean

            CheckForModifiedRows = BandedGridViewGridControl_MainView.CheckForModifiedRows

        End Function
        Public Function RemoveFromModifiedRows(DataBoundObject As Object) As Boolean

            RemoveFromModifiedRows = BandedGridViewGridControl_MainView.RemoveFromModifiedRows(DataBoundObject)

        End Function
        Public Function AddToModifiedRows(RowHandle As Integer) As Boolean

            AddToModifiedRows = BandedGridViewGridControl_MainView.AddToModifiedRows(RowHandle)

        End Function
        Public Function GetAllModifiedRows() As Generic.List(Of Object)

            GetAllModifiedRows = BandedGridViewGridControl_MainView.GetAllModifiedRows

        End Function
        Public Function HasAnyInvalidRows() As Boolean

            HasAnyInvalidRows = BandedGridViewGridControl_MainView.HasAnyInvalidRows

        End Function
        Public Function GetAllRowsDataBoundItems() As IEnumerable

            'objects
            Dim DataBoundItems As Generic.List(Of Object) = Nothing

            DataBoundItems = New Generic.List(Of Object)

            For RowHandle = 0 To BandedGridViewGridControl_MainView.RowCount - 1

                If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                    DataBoundItems.Add(DirectCast(BandedDataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(BandedGridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle)))

                End If

            Next

            GetAllRowsDataBoundItems = DataBoundItems

        End Function
        Public Function GetAllRowsCellValues(BookmarkColumnIndex As Integer) As IEnumerable

            'objects
            Dim CellValues As Generic.List(Of Object) = Nothing

            CellValues = New Generic.List(Of Object)

            If BookmarkColumnIndex > -1 AndAlso BandedGridViewGridControl_MainView.Columns(BookmarkColumnIndex) IsNot Nothing Then

                For RowHandle = 0 To BandedGridViewGridControl_MainView.RowCount - 1

                    If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        CellValues.Add(BandedGridViewGridControl_MainView.GetRowCellValue(RowHandle, BandedGridViewGridControl_MainView.Columns(BookmarkColumnIndex)))

                    End If

                Next

            End If

            GetAllRowsCellValues = CellValues

        End Function
        Public Function GetAllSelectedRowsCellValues(BookmarkColumnIndex As Integer) As IEnumerable

            'objects
            Dim CellValues As Generic.List(Of Object) = Nothing

            CellValues = New Generic.List(Of Object)

            If BookmarkColumnIndex > -1 AndAlso BandedGridViewGridControl_MainView.Columns(BookmarkColumnIndex) IsNot Nothing Then

                For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                    If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        CellValues.Add(BandedGridViewGridControl_MainView.GetRowCellValue(RowHandle, BandedGridViewGridControl_MainView.Columns(BookmarkColumnIndex)))

                    End If

                Next

            End If

            GetAllSelectedRowsCellValues = CellValues

        End Function
        Public Function GetAllRowsBookmarkValues(BookmarkColumnIndex As Integer) As IEnumerable

            'objects
            Dim BookmarkValues As Generic.List(Of Object) = Nothing

            BookmarkValues = New Generic.List(Of Object)

            If BookmarkColumnIndex > -1 AndAlso BandedGridViewGridControl_MainView.Columns(BookmarkColumnIndex) IsNot Nothing Then

                For RowHandle = 0 To BandedGridViewGridControl_MainView.RowCount - 1

                    If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        BookmarkValues.Add(BandedGridViewGridControl_MainView.GetRowCellValue(RowHandle, BandedGridViewGridControl_MainView.Columns(BookmarkColumnIndex)))

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
        Public Function GetAllSelectedRowsBookmarkValues(BookmarkColumnIndex As Integer) As IEnumerable

            'objects
            Dim BookmarkValues As Generic.List(Of Object) = Nothing

            BookmarkValues = New Generic.List(Of Object)

            If BookmarkColumnIndex > -1 AndAlso BandedGridViewGridControl_MainView.Columns(BookmarkColumnIndex) IsNot Nothing Then

                For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                    If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        BookmarkValues.Add(BandedGridViewGridControl_MainView.GetRowCellValue(RowHandle, BandedGridViewGridControl_MainView.Columns(BookmarkColumnIndex)))

                    End If

                Next

            End If

            GetAllSelectedRowsBookmarkValues = BookmarkValues

        End Function
        Public Function GetFirstSelectedRowBookmarkValue() As Object

            GetFirstSelectedRowBookmarkValue = GetFirstSelectedRowBookmarkValue(_BookmarkColumnIndex)

        End Function
        Public Function GetFirstSelectedRowBookmarkValue(BookmarkColumnIndex As Integer) As Object

            'objects
            Dim BookmarkValue As Object = Nothing

            If Me.HasASelectedRow AndAlso BookmarkColumnIndex > -1 AndAlso BandedGridViewGridControl_MainView.Columns IsNot Nothing AndAlso
                BookmarkColumnIndex < BandedGridViewGridControl_MainView.Columns.Count AndAlso BandedGridViewGridControl_MainView.Columns(BookmarkColumnIndex) IsNot Nothing Then

                For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                    If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        BookmarkValue = BandedGridViewGridControl_MainView.GetRowCellValue(RowHandle, BandedGridViewGridControl_MainView.Columns(BookmarkColumnIndex))
                        Exit For

                    End If

                Next

            End If

            GetFirstSelectedRowBookmarkValue = BookmarkValue

        End Function
        Public Function GetFirstSelectedRowCellValue(FieldName As String) As Object

            'objects
            Dim BookmarkValue As Object = Nothing

            If Me.HasASelectedRow AndAlso BandedGridViewGridControl_MainView.Columns IsNot Nothing AndAlso BandedGridViewGridControl_MainView.Columns.ColumnByFieldName(FieldName) IsNot Nothing Then

                For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                    If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        BookmarkValue = BandedGridViewGridControl_MainView.GetRowCellValue(RowHandle, BandedGridViewGridControl_MainView.Columns.ColumnByFieldName(FieldName))
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

                For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                    If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                        DataBoundItem = DirectCast(BandedDataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(BandedGridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle))
                        Exit For

                    End If

                Next

            End If

            GetFirstSelectedRowDataBoundItem = DataBoundItem

        End Function
        Public Function GetRowDataBoundItem(RowHandle As Integer) As Object

            'objects
            Dim DataBoundItem As Object = Nothing

            If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                Try

                    DataBoundItem = DirectCast(BandedDataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(BandedGridViewGridControl_MainView.GetDataSourceRowIndex(RowHandle))

                Catch ex As Exception
                    DataBoundItem = Nothing
                End Try

            End If

            GetRowDataBoundItem = DataBoundItem

        End Function
        Public Function GetRowBookmarkValue(RowHandle As Integer) As Object

            'objects
            Dim BookmarkValue As Object = Nothing

            If _BookmarkColumnIndex > -1 AndAlso BandedGridViewGridControl_MainView.Columns(_BookmarkColumnIndex) IsNot Nothing Then

                If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                    Try

                        BookmarkValue = BandedGridViewGridControl_MainView.GetRowCellValue(RowHandle, BandedGridViewGridControl_MainView.Columns(_BookmarkColumnIndex))

                    Catch ex As Exception
                        BookmarkValue = Nothing
                    End Try

                End If

            End If

            GetRowBookmarkValue = BookmarkValue

        End Function
        Public Sub HideOrShowColumn(FieldName As String, Visible As Boolean)

            If BandedGridViewGridControl_MainView.Columns(FieldName) IsNot Nothing Then

                BandedGridViewGridControl_MainView.Columns(FieldName).Visible = Visible

            End If

        End Sub
        Public Sub HideOrShowColumn(FieldName As String, Visible As Boolean, ByRef VisibleIndex As Integer)

            If BandedGridViewGridControl_MainView.Columns(FieldName) IsNot Nothing Then

                BandedGridViewGridControl_MainView.Columns(FieldName).VisibleIndex = VisibleIndex
                BandedGridViewGridControl_MainView.Columns(FieldName).Visible = Visible

                VisibleIndex = VisibleIndex + 1

            End If

        End Sub
        Public Sub ResetColumnOrderByObjectType()

            BandedGridViewGridControl_MainView.ResetColumnOrderByObjectType()

        End Sub
        Protected Sub LoadBookmarks()

            If Me.HasASelectedRow AndAlso
                _BookmarkColumnIndex > -1 Then

                _CurrentBookmark = Me.GetFirstSelectedRowBookmarkValue
                _NextBookmark = Nothing

                For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                    If RowHandle + 1 < Me.CurrentView.RowCount Then

                        If BandedGridViewGridControl_MainView.IsDataRow(RowHandle + 1) Then

                            _NextBookmark = Me.CurrentView.GetRowCellValue(RowHandle + 1, Me.CurrentView.Columns(_BookmarkColumnIndex))
                            Exit For

                        End If

                    Else

                        Exit For

                    End If

                Next

                If _NextBookmark IsNot Nothing Then

                    For Each RowHandle In BandedGridViewGridControl_MainView.GetSelectedRows

                        If RowHandle - 1 >= 0 Then

                            If BandedGridViewGridControl_MainView.IsDataRow(RowHandle - 1) Then

                                _NextBookmark = Me.CurrentView.GetRowCellValue(RowHandle - 1, Me.CurrentView.Columns(_BookmarkColumnIndex))
                                Exit For

                            End If

                        Else

                            Exit For

                        End If

                    Next

                End If

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

                        If BandedGridViewGridControl_MainView.IsDataRow(RowHandle) Then

                            Try

                                BandedGridViewGridControl_MainView.SelectRow(RowHandle)
                                BandedGridViewGridControl_MainView.FocusedRowHandle = RowHandle

                            Catch ex As Exception

                            End Try

                            Exit For

                        End If

                    Next

                End If

            End If

        End Sub
        Public Sub GridViewSelectionChanged()

            BandedGridViewGridControl_MainView.GridViewSelectionChanged()

        End Sub
        Public Sub FocusToFindPanel(DeselectAllRows As Boolean)

            If BandedGridViewGridControl_MainView.OptionsFind.AllowFindPanel = False Then

                BandedGridViewGridControl_MainView.OptionsFind.AllowFindPanel = True

            End If

            BandedGridViewGridControl_MainView.ShowFindPanel()

            BandedGridViewGridControl_MainView.OptionsFind.AlwaysVisible = True
            BandedGridViewGridControl_MainView.OptionsFind.ShowFindButton = False
            BandedGridViewGridControl_MainView.OptionsFind.ShowCloseButton = False
            BandedGridViewGridControl_MainView.OptionsFind.SearchInPreview = False

            If DeselectAllRows Then

                HideRowSelection()

            End If

        End Sub
        Public Sub ShowRowSelection(RaiseGridViewSelectionChanged As Boolean)

            If BandedGridViewGridControl_MainView.OptionsView.ShowIndicator = False Then

                BandedGridViewGridControl_MainView.OptionsView.ShowIndicator = True
                BandedGridViewGridControl_MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
                BandedGridViewGridControl_MainView.OptionsSelection.EnableAppearanceFocusedCell = True
                BandedGridViewGridControl_MainView.OptionsSelection.EnableAppearanceFocusedRow = True
                BandedGridViewGridControl_MainView.OptionsSelection.EnableAppearanceHideSelection = True

                If RaiseGridViewSelectionChanged Then

                    BandedGridViewGridControl_MainView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Public Sub HideRowSelection()

            If BandedGridViewGridControl_MainView.OptionsView.ShowIndicator Then

                BandedGridViewGridControl_MainView.OptionsView.ShowIndicator = False
                BandedGridViewGridControl_MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
                BandedGridViewGridControl_MainView.OptionsSelection.EnableAppearanceFocusedCell = False
                BandedGridViewGridControl_MainView.OptionsSelection.EnableAppearanceFocusedRow = False
                BandedGridViewGridControl_MainView.OptionsSelection.EnableAppearanceHideSelection = False

            End If

        End Sub
        Public Sub SelectRow(BookmarkValue As Object)

            SelectRow(_BookmarkColumnIndex, BookmarkValue)

        End Sub
        Public Sub SelectRow(BookmarkValue As Object, DeselectRows As Boolean)

            SelectRow(_BookmarkColumnIndex, BookmarkValue, DeselectRows)

        End Sub
        Public Sub SelectRow(BookmarkColumnIndex As Integer, BookmarkValue As Object)

            SelectRow(BookmarkColumnIndex, BookmarkValue, True)

        End Sub
        Public Sub SelectRow(BookmarkColumnIndex As Integer, BookmarkValue As Object, DeselectRows As Boolean)

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

                            RaiseEvent SelectionChangedEvent(BandedGridViewGridControl_MainView, e)

                        Else

                            Me.CurrentView.FocusedRowHandle = RowHandle

                        End If

                        Exit For

                    End If

                Next

                Me.CurrentView.EndSelection()

            End If

        End Sub
        Public Sub SelectRow(ColumnName As String, ColumnValue As Object, DeselectRows As Boolean)

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

                        RaiseEvent SelectionChangedEvent(BandedGridViewGridControl_MainView, e)

                    Else

                        Me.CurrentView.FocusedRowHandle = RowHandle

                    End If

                    Exit For

                End If

            Next

            Me.CurrentView.EndSelection()

        End Sub
        Public Sub SelectAllRowsByValue(BookmarkColumnIndex As Integer, BookmarkValue As Object, DeselectRows As Boolean)

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

                            RaiseEvent SelectionChangedEvent(BandedGridViewGridControl_MainView, e)

                        Else

                            Me.CurrentView.FocusedRowHandle = RowHandle

                        End If

                    End If

                Next

                Me.CurrentView.EndSelection()

            End If

        End Sub
        Public Sub ClearColumns()

            If BandedGridViewGridControl_MainView.Columns.Count > 0 Then

                BandedGridViewGridControl_MainView.Columns.Clear()

                Try

                    BandedGridViewGridControl_MainView.FocusedColumn = Nothing

                Catch ex As Exception

                End Try

            End If

        End Sub
        Public Sub Print(LookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel, DocumentDescription As String,
                         Agency As AdvantageFramework.Database.Entities.Agency, Session As AdvantageFramework.Security.Session,
                         Optional Images() As System.Drawing.Image = Nothing,
                         Optional UseLandscape As Boolean = False)

            'objects
            Dim CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink = Nothing
            Dim ComponentResourceManager As System.ComponentModel.ComponentResourceManager = Nothing
            Dim PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
            Dim ReportHeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim PrintableComponentLink As DevExpress.XtraPrinting.PrintableComponentLink = Nothing
            Dim KeepLoading As Boolean = True

            ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageFramework.Desktop.Presentation.DynamicReportEditForm))

            PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem
            CompositeLink = New DevExpress.XtraPrintingLinks.CompositeLink(PrintingSystem)

            ReportHeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

            PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DocumentDescription

            If Agency IsNot Nothing AndAlso Agency.IsASP = 1 Then

                If My.Computer.FileSystem.DirectoryExists(Agency.ImportPath) Then

                    If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\") = False Then

                        My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")

                    End If

                End If

                PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DocumentDescription & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
                PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")
                PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Session, If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\"), DocumentDescription))

                PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

            End If

            If KeepLoading Then

                AddHandler ReportHeaderLink.CreateDetailArea, AddressOf ReportHeaderLink_CreateDetailArea

                CompositeLink.Links.Add(ReportHeaderLink)

                PrintableComponentLink = New DevExpress.XtraPrinting.PrintableComponentLink(PrintingSystem)

                AddHandler PrintableComponentLink.CreateReportFooterArea, AddressOf PrintableComponentLink_CreateReportFooterArea
                AddHandler PrintableComponentLink.CreateMarginalFooterArea, AddressOf PrintableComponentLink_CreateMarginalFooterArea

                PrintableComponentLink.Component = Me.GridControl

                If UseLandscape Then

                    PrintableComponentLink.Landscape = True
                    PrintingSystem.PageSettings.Landscape = True
                    CompositeLink.Landscape = True

                End If

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

                CompositeLink.ShowRibbonPreviewDialog(LookAndFeel)

                RemoveHandler ReportHeaderLink.CreateDetailArea, AddressOf ReportHeaderLink_CreateDetailArea
                RemoveHandler PrintableComponentLink.CreateReportFooterArea, AddressOf PrintableComponentLink_CreateReportFooterArea
                RemoveHandler PrintableComponentLink.CreateMarginalFooterArea, AddressOf PrintableComponentLink_CreateMarginalFooterArea

            End If

        End Sub
        Public Sub Print(Session As AdvantageFramework.Security.Session, LookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel, DocumentDescription As String, Optional Images() As System.Drawing.Image = Nothing,
                         Optional UseLandscape As Boolean = False)

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            End Using

            Print(LookAndFeel, DocumentDescription, Agency, Session, Images, UseLandscape)

        End Sub
        Public Sub CancelNewItemRow()

            Me.CurrentView.CancelNewItemRow()

        End Sub
        Public Sub MakeColumnNotVisible(ColumnFieldName As String)

            If BandedGridViewGridControl_MainView.Columns(ColumnFieldName) IsNot Nothing Then

                If BandedGridViewGridControl_MainView.Columns(ColumnFieldName).Visible Then

                    BandedGridViewGridControl_MainView.Columns(ColumnFieldName).Visible = False

                End If

            End If

        End Sub
        Public Sub MakeColumnNotVisible(ColumnFieldName As String, RemoveUserControl As Boolean)

            If BandedGridViewGridControl_MainView.Columns(ColumnFieldName) IsNot Nothing Then

                If BandedGridViewGridControl_MainView.Columns(ColumnFieldName).Visible Then

                    BandedGridViewGridControl_MainView.Columns(ColumnFieldName).Visible = False

                End If

                If RemoveUserControl Then

                    BandedGridViewGridControl_MainView.Columns(ColumnFieldName).OptionsColumn.AllowShowHide = False
                    BandedGridViewGridControl_MainView.Columns(ColumnFieldName).OptionsColumn.ShowInCustomizationForm = False
                    BandedGridViewGridControl_MainView.Columns(ColumnFieldName).OptionsColumn.ShowInExpressionEditor = False

                End If

            End If

        End Sub
        Public Sub MakeColumnVisible(ColumnFieldName As String)

            If BandedGridViewGridControl_MainView.Columns(ColumnFieldName) IsNot Nothing Then

                If BandedGridViewGridControl_MainView.Columns(ColumnFieldName).Visible = False Then

                    BandedGridViewGridControl_MainView.Columns(ColumnFieldName).VisibleIndex = BandedGridViewGridControl_MainView.VisibleColumns.Count
                    BandedGridViewGridControl_MainView.Columns(ColumnFieldName).Visible = True

                End If

            End If

        End Sub
        Public Sub MakeIsInactiveColumnNotVisible()

            MakeColumnNotVisible("IsInactive")

        End Sub
        Public Sub ClearGridCustomization()

            BandedGridViewGridControl_MainView.ClearSorting()
            BandedGridViewGridControl_MainView.ClearColumnsFilter()
            BandedGridViewGridControl_MainView.ClearGrouping()
            BandedGridViewGridControl_MainView.GroupSummary.Clear()

            If _BindingSource IsNot Nothing Then

                _BindingSource.DataSource = Nothing

            End If

            Me.ClearColumns()
            BandedGridViewGridControl_MainView.Bands.Clear()

            Me.GridControl.RepositoryItems.Clear()

        End Sub
        Public Sub ValidateAllRows()

            BandedGridViewGridControl_MainView.ValidateAllRows()

        End Sub
        Public Sub ValidateAllRowsAndClearChanged(Optional RaiseFormClearChanged As Boolean = False)

            BandedGridViewGridControl_MainView.ValidateAllRows()

            Me.ClearChanged()

            If RaiseFormClearChanged Then

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ClearChanged()

                End If

            End If

        End Sub
        Public Sub SetUserEntryChanged()

            _UserEntryChanged = True

            AdvantageFramework.WinForm.MVC.Presentation.Controls.UserEntryChanged(Me)

        End Sub
        Public Sub DeselectAll()

            BandedGridViewGridControl_MainView.ClearSelection()

        End Sub
        Public Sub SelectAll()

            BandedGridViewGridControl_MainView.SelectAll()

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
        Private Sub BarCheckItem_CheckChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim BarCheckItem As DevExpress.XtraBars.BarCheckItem = Nothing

            BarCheckItem = DirectCast(e.Item, DevExpress.XtraBars.BarCheckItem)

            If BarCheckItem.Tag IsNot Nothing AndAlso TypeOf BarCheckItem.Tag Is DevExpress.XtraGrid.Columns.GridColumn Then

                GridColumn = DirectCast(BarCheckItem.Tag, DevExpress.XtraGrid.Columns.GridColumn)

                GridColumn.Visible = BarCheckItem.Checked

            End If

        End Sub
        Protected Function CreateCheckItem(Caption As String, GridColumn As DevExpress.XtraGrid.Columns.GridColumn, FixedStyle As DevExpress.XtraGrid.Columns.FixedStyle, Optional Image As System.Drawing.Image = Nothing) As DevExpress.Utils.Menu.DXMenuCheckItem

            'objects
            Dim DXMenuCheckItem As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing

            DXMenuCheckItem = New DevExpress.Utils.Menu.DXMenuCheckItem(Caption, False, Image, New EventHandler(AddressOf OnFixedClick))

            DXMenuCheckItem.Tag = New AdvantageFramework.WinForm.Presentation.Controls.Classes.MenuInfo(GridColumn, FixedStyle)

            CreateCheckItem = DXMenuCheckItem

        End Function
        Protected Sub OnFixedClick(sender As Object, e As EventArgs)

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

                    DataBoundItems.Add(DirectCast(BandedDataGridView_GridControl.DataSource, System.Windows.Forms.BindingSource).Item(Item))

                Next

            End If

            GetBindingSourceDataBoundItems = DataBoundItems

        End Function
        Public Sub RefreshDataSource()

            Me.GridControl.RefreshDataSource()

        End Sub
        Public Sub SetupForEditableGrid()

            BandedGridViewGridControl_MainView.OptionsBehavior.Editable = True
            BandedGridViewGridControl_MainView.OptionsCustomization.AllowColumnMoving = False
            BandedGridViewGridControl_MainView.OptionsCustomization.AllowGroup = False
            BandedGridViewGridControl_MainView.OptionsCustomization.AllowQuickHideColumns = False

        End Sub
        Protected Sub SetupEmbeddedNavigator(ByVal UseEmbeddedNavigator As Boolean)

            Dim DeleteCustomButton As DevExpress.XtraEditors.NavigatorCustomButton = Nothing
            Dim CancelEditCustomButton As DevExpress.XtraEditors.NavigatorCustomButton = Nothing

            BandedDataGridView_GridControl.UseEmbeddedNavigator = UseEmbeddedNavigator

            AddHandler BandedDataGridView_GridControl.EmbeddedNavigator.ButtonClick, AddressOf GridViewGridControl_EmbeddedNavigator_ButtonClick

            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.PrevPage.Visible = False
            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.Prev.Visible = False
            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.NextPage.Visible = False
            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.Next.Visible = False
            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.Last.Visible = False
            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.First.Visible = False
            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.Append.Visible = False
            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.Remove.Visible = False

            BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.CustomButtons.Clear()

            DeleteCustomButton = BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.CustomButtons.Add()

            DeleteCustomButton.Tag = DevExpress.XtraEditors.NavigatorButtonType.Remove
            DeleteCustomButton.Enabled = Me.HasASelectedRow
            DeleteCustomButton.Hint = "Delete"
            DeleteCustomButton.ImageIndex = CInt(DevExpress.XtraEditors.NavigatorButtonType.CancelEdit - 1)

            _CustomDeleteButton = DeleteCustomButton

            CancelEditCustomButton = BandedDataGridView_GridControl.EmbeddedNavigator.Buttons.CustomButtons.Add()

            CancelEditCustomButton.Tag = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit
            CancelEditCustomButton.Enabled = False
            CancelEditCustomButton.Hint = "Cancel"
            CancelEditCustomButton.ImageIndex = CInt(DevExpress.XtraEditors.NavigatorButtonType.Remove - 1)

            _CustomCancelEditButton = CancelEditCustomButton

            BandedDataGridView_GridControl.EmbeddedNavigator.TextStringFormat = ""

        End Sub
        Public Sub EnabledDisableNavigatorButtons()

            If _CustomDeleteButton IsNot Nothing Then

                _CustomDeleteButton.Enabled = (Me.IsNewItemOrAutoFilterRow() = False AndAlso Me.HasASelectedRow(False))

            End If

            If _CustomCancelEditButton IsNot Nothing Then

                _CustomCancelEditButton.Enabled = BandedGridViewGridControl_MainView.IsNewItemRow(BandedGridViewGridControl_MainView.FocusedRowHandle)

            End If

        End Sub
        Public Sub SelectOnlyThisRow(RowHandle As Integer)

            Me.CurrentView.FocusedRowHandle = RowHandle
            Me.CurrentView.SelectRow(RowHandle)

            For Each SelectedRowHandle In Me.CurrentView.GetSelectedRows

                If SelectedRowHandle <> RowHandle Then

                    Me.CurrentView.UnselectRow(SelectedRowHandle)

                End If

            Next

        End Sub
        Public Sub CloseGridEditorAndSaveValueToDataSource()

            If Me.CurrentView.PostEditor() Then

                Me.CurrentView.UpdateCurrentRow()

            End If

        End Sub

#Region "  Control Event Handlers "

        Private Sub BandedGridViewGridControl_MainView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles BandedGridViewGridControl_MainView.BeforeLeaveRow

            If BandedGridViewGridControl_MainView.IsValidRowHandle(e.RowHandle) Then

                RaiseEvent BeforeLeaveRowEvent(sender, e)

            End If

        End Sub
        Private Sub BandedGridViewGridControl_MainView_AddNewRowEvent(RowObject As Object) Handles BandedGridViewGridControl_MainView.AddNewRowEvent

            RaiseEvent AddNewRowEvent(RowObject)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedGridViewGridControl_MainView.CellValueChanging

            _ChangesAutoSaved = False

            RaiseEvent CellValueChangingEvent(_ChangesAutoSaved, sender, e)

            If _ChangesAutoSaved = False AndAlso
                Me.IsNewItemOrAutoFilterRow(e.RowHandle) = False AndAlso _ByPassUserEntryChanged = False AndAlso
                _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.MVC.Presentation.Controls.UserEntryChanged(Me)

            End If

            If Me.BandedGridViewGridControl_MainView.IsNewItemRow(e.RowHandle) Then

                RaiseEvent NewItemRowCellValueChangingEvent(sender, e)

            End If

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedGridViewGridControl_MainView.CellValueChanged

            RaiseEvent CellValueChangedEvent(sender, e)

            If _ChangesAutoSaved = False AndAlso
                Me.IsNewItemOrAutoFilterRow(e.RowHandle) = False AndAlso _ByPassUserEntryChanged = False AndAlso
                _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.MVC.Presentation.Controls.UserEntryChanged(Me)

            End If

            If Me.BandedGridViewGridControl_MainView.IsNewItemRow(e.RowHandle) Then

                RaiseEvent NewItemRowCellValueChangedEvent(sender, e)

            End If

            RaiseEvent ColumnValueChangedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles BandedGridViewGridControl_MainView.CustomRowCellEdit

            RaiseEvent CustomRowCellEditEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomRowCellEditForEditing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles BandedGridViewGridControl_MainView.CustomRowCellEditForEditing

            RaiseEvent CustomRowCellEditForEditingEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles BandedGridViewGridControl_MainView.RowClick

            If e.Button = Windows.Forms.MouseButtons.Left Then

                If e.Clicks = 2 Then

                    RaiseEvent RowDoubleClickEvent(sender, e)

                ElseIf e.Clicks = 1 Then

                    RaiseEvent RowClickEvent(sender, e)

                End If

            End If

            If _ShowRowSelectionIfHidden Then

                ShowRowSelection(True)

            End If

        End Sub
        Private Sub BandedGridViewGridControl_MainView_RowCountChanged(sender As Object, e As System.EventArgs) Handles BandedGridViewGridControl_MainView.RowCountChanged

            SetHeaderText()

        End Sub
        Private Sub BandedGridViewGridControl_MainView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles BandedGridViewGridControl_MainView.FocusedRowChanged

            If BandedGridViewGridControl_MainView.OptionsSelection.MultiSelect = False Then

                DeselectGroupHeaderRows()

                RaiseEvent FocusedRowChangedEvent(sender, e)

                If _ShowRowSelectionIfHidden Then

                    ShowRowSelection(True)

                End If

            End If

            EnabledDisableNavigatorButtons()

        End Sub
        Private Sub BandedGridViewGridControl_MainView_SelectionChanged(sender As System.Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles BandedGridViewGridControl_MainView.SelectionChanged

            If BandedGridViewGridControl_MainView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect Then

                If Me.HasASelectedRow = False AndAlso BandedGridViewGridControl_MainView.FocusedRowHandle >= 0 Then

                    BandedGridViewGridControl_MainView.SelectRow(BandedGridViewGridControl_MainView.FocusedRowHandle)

                End If

                If BandedGridViewGridControl_MainView.OptionsSelection.MultiSelect Then

                    DeselectGroupHeaderRows()

                    RaiseEvent SelectionChangedEvent(sender, e)

                    If _ShowRowSelectionIfHidden Then

                        ShowRowSelection(True)

                    End If

                End If

                EnabledDisableNavigatorButtons()

            ElseIf BandedGridViewGridControl_MainView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect Then

                RaiseEvent SelectionChangedEvent(sender, e)

            End If

        End Sub
        Private Sub ButtonBottomPanel_DeselectAll_Click(sender As Object, e As System.EventArgs) Handles ButtonBottomPanel_DeselectAll.Click

            If _SelectRowsWhenSelectDeselectAllButtonClicked Then

                BandedGridViewGridControl_MainView.ClearSelection()

            End If

            RaiseEvent DeselectAllEvent()

        End Sub
        Private Sub ButtonBottomPanel_SelectAll_Click(sender As Object, e As System.EventArgs) Handles ButtonBottomPanel_SelectAll.Click

            If _SelectRowsWhenSelectDeselectAllButtonClicked Then

                BandedGridViewGridControl_MainView.SelectAll()

            End If

            RaiseEvent SelectAllEvent()

        End Sub
        Private Sub BandedDataGridView_GridControl_ProcessGridKey(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles BandedDataGridView_GridControl.ProcessGridKey

            If e.KeyData = Windows.Forms.Keys.Escape Then

                If BandedGridViewGridControl_MainView.IsNewItemRow(BandedGridViewGridControl_MainView.FocusedRowHandle) Then

                    If BandedGridViewGridControl_MainView.GetRow(BandedGridViewGridControl_MainView.FocusedRowHandle) IsNot Nothing Then

                        BandedGridViewGridControl_MainView.CancelUpdateCurrentRow()
                        BandedGridViewGridControl_MainView.NewItemRowText = ""

                    End If

                End If

            ElseIf e.KeyData = Windows.Forms.Keys.Enter Then

                If TypeOf BandedGridViewGridControl_MainView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    If DirectCast(BandedGridViewGridControl_MainView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).IsPopupOpen = False Then

                        e.Handled = True
                        e.SuppressKeyPress = True

                        DirectCast(BandedGridViewGridControl_MainView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).SendKey(New Windows.Forms.KeyEventArgs(Windows.Forms.Keys.Tab))

                    End If

                End If

            ElseIf e.KeyData = Windows.Forms.Keys.Up OrElse e.KeyData = Windows.Forms.Keys.Down Then

                If TypeOf BandedGridViewGridControl_MainView.ActiveEditor Is DevExpress.XtraEditors.BaseSpinEdit Then

                    If e.KeyData = Windows.Forms.Keys.Up AndAlso BandedGridViewGridControl_MainView.FocusedRowHandle <> 0 Then

                        BandedGridViewGridControl_MainView.MovePrev()

                    ElseIf e.KeyData = Windows.Forms.Keys.Down AndAlso BandedGridViewGridControl_MainView.FocusedRowHandle <> BandedGridViewGridControl_MainView.RowCount - 1 Then

                        BandedGridViewGridControl_MainView.MoveNext()

                    End If

                End If

            ElseIf e.KeyData = Windows.Forms.Keys.Tab Then

                If Not BandedGridViewGridControl_MainView.IsNewItemOrAutoFilterRow() Then

                    If BandedGridViewGridControl_MainView.FocusedRowHandle = BandedGridViewGridControl_MainView.RowCount - 1 AndAlso
                        BandedGridViewGridControl_MainView.FocusedColumn.Equals(BandedGridViewGridControl_MainView.VisibleColumns.Last) Then

                        e.Handled = True
                        e.SuppressKeyPress = True

                        BandedGridViewGridControl_MainView.CloseEditorForUpdating()
                        BandedGridViewGridControl_MainView.ShowEditor()

                        If BandedGridViewGridControl_MainView.ActiveEditor IsNot Nothing Then

                            BandedGridViewGridControl_MainView.ActiveEditor.SelectAll()

                        End If

                    End If

                End If

            Else

                RaiseEvent ProcessGridKeyEvent(sender, e)

            End If

        End Sub
        Private Sub BandedGridViewGridControl_MainView_DataSourceChanged(sender As Object, e As System.EventArgs) Handles BandedGridViewGridControl_MainView.DataSourceChanged

            RaiseEvent DataSourceChangedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles BandedGridViewGridControl_MainView.ValidateRow

            RaiseEvent ValidateRowEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles BandedGridViewGridControl_MainView.ValidatingEditor

            RaiseEvent ValidatingEditorEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles BandedGridViewGridControl_MainView.InitNewRow

            RaiseEvent InitNewRowEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_ShownEditor(sender As Object, e As System.EventArgs) Handles BandedGridViewGridControl_MainView.ShownEditor

            RaiseEvent ShownEditorEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_ColumnEditValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedGridViewGridControl_MainView.ColumnEditValueChangedEvent

            RaiseEvent ColumnValueChangedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles BandedGridViewGridControl_MainView.ShowingEditor

            RaiseEvent ShowingEditorEvent(sender, e)

            If Me.HasRows = False AndAlso Me.IsNewItemRow(Me.CurrentView.FocusedRowHandle) Then

                BandedGridViewGridControl_MainView.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub _BindingSource_PositionChanged(sender As Object, e As System.EventArgs) Handles _BindingSource.PositionChanged

            _BindingSourcePositionChanged = True

            _PreviousPosition = _BindingSource.Position

        End Sub
        Private Sub BandedGridViewGridControl_MainView_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles BandedGridViewGridControl_MainView.QueryPopupNeedDatasource

            RaiseEvent QueryPopupNeedDatasourceEvent(FieldName, OverrideDefaultDatasource, Datasource)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles BandedGridViewGridControl_MainView.RepositoryDataSourceLoadingEvent

            RaiseEvent RepositoryDataSourceLoadingEvent(FieldName, Datasource)

        End Sub
        Private Sub GridViewGridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

            RaiseEvent EmbeddedNavigatorButtonClick(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedGridViewGridControl_MainView.PopupMenuShowing

            RaiseEvent PopupMenuShowingEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles BandedGridViewGridControl_MainView.CustomDrawGroupRow

            RaiseEvent CustomDrawGroupRowEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedGridViewGridControl_MainView.RowCellStyle

            RaiseEvent RowCellStyleEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomDrawRowFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles BandedGridViewGridControl_MainView.CustomDrawRowFooter

            RaiseEvent CustomDrawRowFooterEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomDrawRowFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles BandedGridViewGridControl_MainView.CustomDrawRowFooterCell

            RaiseEvent CustomDrawRowFooterCellEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles BandedGridViewGridControl_MainView.MouseDown

            Dim BandedGridView As BandedGridView = Nothing
            Dim BandedGridHitInfo As DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitInfo = Nothing
            Dim OwnerBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            BandedGridView = TryCast(sender, BandedGridView)
            BandedGridHitInfo = BandedGridView.CalcHitInfo(e.Location)

            If BandedGridHitInfo.HitTest = DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitTest.ColumnEdge Then

                OwnerBand = BandedGridHitInfo.Column.OwnerBand

                If OwnerBand.Columns.VisibleColumnCount - 1 = BandedGridHitInfo.Column.ColVIndex Then

                    For Each GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BandedGridView.Bands

                        If GridBand.Equals(OwnerBand) = False Then

                            GridBand.OptionsBand.FixedWidth = True

                        Else

                            GridBand.OptionsBand.FixedWidth = False

                        End If

                    Next

                    For Each BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In OwnerBand.Columns

                        If BandedGridColumn.Equals(BandedGridHitInfo.Column) = False Then

                            BandedGridColumn.OptionsColumn.FixedWidth = True

                        Else

                            BandedGridColumn.OptionsColumn.FixedWidth = False

                        End If

                    Next

                Else

                    For Each GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BandedGridView.Bands

                        GridBand.OptionsBand.FixedWidth = False

                    Next

                    For Each BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In OwnerBand.Columns

                        BandedGridColumn.OptionsColumn.FixedWidth = False

                    Next

                End If

            ElseIf BandedGridHitInfo.HitTest = DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitTest.BandEdge Then

                OwnerBand = BandedGridHitInfo.Band

                For Each BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In OwnerBand.Columns

                    BandedGridColumn.OptionsColumn.FixedWidth = False

                Next

            End If

            RaiseEvent MouseDownEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles BandedGridViewGridControl_MainView.CustomDrawCell

            RaiseEvent CustomDrawCellEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_EndGrouping(sender As Object, e As EventArgs) Handles BandedGridViewGridControl_MainView.EndGrouping

            RaiseEvent EndGroupingEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomDrawFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles BandedGridViewGridControl_MainView.CustomDrawFooter

            RaiseEvent CustomDrawFooterEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomDrawBandHeader(sender As Object, e As DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs) Handles BandedGridViewGridControl_MainView.CustomDrawBandHeader

            RaiseEvent CustomDrawBandHeaderEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_EndSorting(sender As Object, e As EventArgs) Handles BandedGridViewGridControl_MainView.EndSorting

            RaiseEvent EndSortingEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_DragObjectOver(sender As Object, e As DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs) Handles BandedGridViewGridControl_MainView.DragObjectOver

            RaiseEvent DragObjectOverEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_ColumnFilterChanged(sender As Object, e As EventArgs) Handles BandedGridViewGridControl_MainView.ColumnFilterChanged

            RaiseEvent ColumnFilterChangedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_ColumnPositionChanged(sender As Object, e As EventArgs) Handles BandedGridViewGridControl_MainView.ColumnPositionChanged

            RaiseEvent ColumnPositionChangedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_ColumnWidthChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles BandedGridViewGridControl_MainView.ColumnWidthChanged

            RaiseEvent ColumnWidthChangedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_BandWidthChanged(sender As Object, e As DevExpress.XtraGrid.Views.BandedGrid.BandEventArgs) Handles BandedGridViewGridControl_MainView.BandWidthChanged

            RaiseEvent BandWidthChangedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_HideCustomizationForm(sender As Object, e As EventArgs) Handles BandedGridViewGridControl_MainView.HideCustomizationForm

            RaiseEvent HideCustomizationFormEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_ShowCustomizationForm(sender As Object, e As EventArgs) Handles BandedGridViewGridControl_MainView.ShowCustomizationForm

            RaiseEvent ShowCustomizationFormEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles BandedGridViewGridControl_MainView.CustomSummaryCalculate

            RaiseEvent CustomSummaryCalculateEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomDrawColumnHeader(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles BandedGridViewGridControl_MainView.CustomDrawColumnHeader

            RaiseEvent CustomDrawColumnHeaderEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedGridViewGridControl_MainView.CustomColumnDisplayText

            RaiseEvent CustomColumnDisplayTextEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomColumnGroup(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles BandedGridViewGridControl_MainView.CustomColumnGroup

            RaiseEvent CustomColumnGroupEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomColumnSort(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles BandedGridViewGridControl_MainView.CustomColumnSort

            RaiseEvent CustomColumnSortEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles BandedGridViewGridControl_MainView.FocusedColumnChanged

            RaiseEvent FocusedColumnChangedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles BandedGridViewGridControl_MainView.CustomUnboundColumnData

            RaiseEvent CustomUnboundColumnDataEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_ColumnEditValueChangingEvent(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles BandedGridViewGridControl_MainView.ColumnEditValueChangingEvent

            RaiseEvent ColumnEditValueChangingEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_AlterSubItemGridLookupEditPropertiesEvent(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemGridLookUpEditControl As SubItemGridLookUpEditControl) Handles BandedGridViewGridControl_MainView.AlterSubItemGridLookupEditPropertiesEvent

            RaiseEvent AlterSubItemGridLookupEditPropertiesEvent(GridColumn, SubItemGridLookUpEditControl)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomRowFilter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles BandedGridViewGridControl_MainView.CustomRowFilter

            RaiseEvent CustomRowFilterEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles BandedGridViewGridControl_MainView.KeyDown

            RaiseEvent GridViewKeyDownEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomDrawFilterPanel(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomDrawObjectEventArgs) Handles BandedGridViewGridControl_MainView.CustomDrawFilterPanel

            RaiseEvent CustomDrawFilterPanelEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_CustomDrawFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles BandedGridViewGridControl_MainView.CustomDrawFooterCell

            RaiseEvent CustomDrawFooterCellEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_SubItemGridLookUpEditControlEditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles BandedGridViewGridControl_MainView.SubItemGridLookUpEditControlEditValueChanging

            RaiseEvent SubItemGridLookUpEditControlEditValueChanging(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_MasterRowGetChildList(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles BandedGridViewGridControl_MainView.MasterRowGetChildList

            RaiseEvent MasterRowGetChildListEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_MasterRowEmpty(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles BandedGridViewGridControl_MainView.MasterRowEmpty

            RaiseEvent MasterRowEmptyEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_MasterRowGetRelationCount(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles BandedGridViewGridControl_MainView.MasterRowGetRelationCount

            RaiseEvent MasterRowGetRelationCountEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_MasterRowGetRelationName(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles BandedGridViewGridControl_MainView.MasterRowGetRelationName

            RaiseEvent MasterRowGetRelationNameEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_MasterRowGetRelationDisplayCaption(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles BandedGridViewGridControl_MainView.MasterRowGetRelationDisplayCaption

            RaiseEvent MasterRowGetRelationDisplayCaptionEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_MasterRowGetLevelDefaultView(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles BandedGridViewGridControl_MainView.MasterRowGetLevelDefaultView

            RaiseEvent MasterRowGetLevelDefaultViewEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_MasterRowExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles BandedGridViewGridControl_MainView.MasterRowExpanded

            RaiseEvent MasterRowExpandedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_MasterRowCollapsing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs) Handles BandedGridViewGridControl_MainView.MasterRowCollapsing

            RaiseEvent MasterRowCollapsingEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_MasterRowCollapsed(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles BandedGridViewGridControl_MainView.MasterRowCollapsed

            RaiseEvent MasterRowCollapsedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_GroupRowCollapsed(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs) Handles BandedGridViewGridControl_MainView.GroupRowCollapsed

            RaiseEvent GroupRowCollapsedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles BandedGridViewGridControl_MainView.GroupRowCollapsing

            RaiseEvent GroupRowCollapsingEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_GroupRowExpanded(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs) Handles BandedGridViewGridControl_MainView.GroupRowExpanded

            RaiseEvent GroupRowExpandedEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_GroupRowExpanding(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles BandedGridViewGridControl_MainView.GroupRowExpanding

            RaiseEvent GroupRowExpandingEvent(sender, e)

        End Sub
        Private Sub BandedGridViewGridControl_MainView_StartSorting(sender As Object, e As EventArgs) Handles BandedGridViewGridControl_MainView.StartSorting

            RaiseEvent StartSortingEvent(sender, e)

        End Sub


#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ReportHeaderLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            RaiseEvent CreateReportHeaderAreaEvent(sender, e)

        End Sub
        Private Sub PrintableComponentLink_CreateReportFooterArea(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            RaiseEvent CreateReportFooterAreaEvent(sender, e)

        End Sub
        Private Sub PrintableComponentLink_CreateMarginalFooterArea(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            RaiseEvent CreateMarginalFooterAreaEvent(sender, e)

        End Sub

#End Region

#End Region

    End Class

End Namespace
