Namespace WinForm.Presentation.Controls

    Public Class BandedGridView
        Inherits DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView

        Public Event IsExistAnyRowFooterCellEvent(ByVal RowHandle As Integer, ByRef Exists As Boolean)
        Public Event ColumnAddedEvent(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)
        Public Event LoadGridColumnComboBoxEvent(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)
        'Public Event RowUpdatedEvent(ByVal RowHandle As Integer)
        Public Event AddNewRowEvent(ByVal RowObject As Object)
        Public Event BeforeAddNewRowEvent(ByVal RowObject As Object, ByRef Cancel As Boolean)
        Public Event SubItemTextBoxButtonClickEvent(ByVal RowObject As Object)
        Public Event ColumnEditValueChangedEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Public Event RepositoryDataSourceLoadingEvent(ByVal FieldName As String, ByRef Cancel As Boolean)
        Public Event QueryPopupNeedDatasource(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)
        Public Event OnEditUnboundColumnClickEvent(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)
        Public Event CanAutoFillValueEvent(ByRef CanAutoFillValue As Boolean, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum ImageIndexes
            DeleteImage = 0
        End Enum

#End Region

#Region " Variables "

        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ControlType As AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView.Type = AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView.Type.Default
        Protected _ObjectType As System.Type = Nothing
        Protected _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Protected _EnableDisabledRows As Boolean = False
        Protected _DisabledRows As List(Of AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow) = Nothing
        Protected _UpdatingFilterData As Boolean = False
        Protected _FilterPopupMode As DevExpress.XtraGrid.Columns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Default
        Protected _ChangedRows As Generic.List(Of Object) = Nothing
        Protected _AutoloadRepositoryDatasource As Boolean = True
        Protected _AutoFilterLookupColumns As Boolean = False
        Protected _DataSourceClearing As Boolean = False
        Protected _IsInGridLookupEditControl As Boolean = False
        Protected _IsAutoFilling As Boolean = False
        Protected _RunStandardValidation As Boolean = True
        Protected _AllowExtraItemsInGridLookupEdits As Boolean = True
        Protected _IntegerUnboundColumnFieldName As String = Nothing
        Protected _IntegerUnboundColumnValues As Generic.Dictionary(Of Integer, Integer) = Nothing
        Protected _RestoredLayoutNonVisibleGridColumnList As Generic.List(Of DevExpress.XtraGrid.Columns.GridColumn) = Nothing

#End Region

#Region " Properties "

        Public Property AllowExtraItemsInGridLookupEdits As Boolean
            Get
                AllowExtraItemsInGridLookupEdits = _AllowExtraItemsInGridLookupEdits
            End Get
            Set(value As Boolean)
                _AllowExtraItemsInGridLookupEdits = value
            End Set
        End Property
        Friend Property FilterPopupMode As DevExpress.XtraGrid.Columns.FilterPopupMode
            Get
                FilterPopupMode = _FilterPopupMode
            End Get
            Set(ByVal value As DevExpress.XtraGrid.Columns.FilterPopupMode)
                _FilterPopupMode = value
            End Set
        End Property
        Friend Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Friend Property ControlType() As AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView.Type)
                _ControlType = value
                SetupGridViewControl()
            End Set
        End Property
        Friend Property ObjectType As System.Type
            Get
                ObjectType = _ObjectType
            End Get
            Set(ByVal value As System.Type)

                _ObjectType = value

                If _ObjectType IsNot Nothing Then

                    _ObjectTypePropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(_ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                End If

            End Set
        End Property
        Public Property AFActiveFilterString As String
            Get
                AFActiveFilterString = MyBase.ActiveFilterString
            End Get
            Set(ByVal value As String)

                MyBase.ActiveFilterString = value

                GridViewSelectionChanged()

            End Set
        End Property
        Public Property EnableDisabledRows As Boolean
            Get
                EnableDisabledRows = _EnableDisabledRows
            End Get
            Set(ByVal value As Boolean)
                _EnableDisabledRows = value

                If value Then

                    UnSubscribeEvents()

                    Me.IndicatorWidth = 30

                    SubscribeEvents()

                End If

            End Set
        End Property
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)>
        Public ReadOnly Property DisabledRows() As List(Of AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow)
            Get
                DisabledRows = _DisabledRows
            End Get
        End Property
        Public ReadOnly Property UpdatingFilterData As Boolean
            Get
                UpdatingFilterData = _UpdatingFilterData
            End Get
        End Property
        Public Property AutoloadRepositoryDatasource As Boolean
            Get
                AutoloadRepositoryDatasource = _AutoloadRepositoryDatasource
            End Get
            Set(ByVal value As Boolean)
                _AutoloadRepositoryDatasource = value
            End Set
        End Property
        Public Property AutoFilterLookupColumns As Boolean
            Get
                AutoFilterLookupColumns = _AutoFilterLookupColumns
            End Get
            Set(ByVal value As Boolean)
                _AutoFilterLookupColumns = value
            End Set
        End Property
        Public Property DataSourceClearing As Boolean
            Get
                DataSourceClearing = _DataSourceClearing
            End Get
            Set(ByVal value As Boolean)
                _DataSourceClearing = value
            End Set
        End Property
        Public WriteOnly Property IsInGridLookupEditControl As Boolean
            Set(value As Boolean)
                _IsInGridLookupEditControl = value
            End Set
        End Property
        Public Property RunStandardValidation As Boolean
            Get
                RunStandardValidation = _RunStandardValidation
            End Get
            Set(value As Boolean)
                _RunStandardValidation = value
            End Set
        End Property
        Public Property RestoredLayoutNonVisibleGridColumnList As Generic.List(Of DevExpress.XtraGrid.Columns.GridColumn)
            Get
                RestoredLayoutNonVisibleGridColumnList = _RestoredLayoutNonVisibleGridColumnList
            End Get
            Set(value As Generic.List(Of DevExpress.XtraGrid.Columns.GridColumn))
                _RestoredLayoutNonVisibleGridColumnList = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal IsInGridLookupEditControl As Boolean)

            Me.New()

            _IsInGridLookupEditControl = IsInGridLookupEditControl

        End Sub
        Protected Overrides Sub Dispose(disposing As Boolean)
            MyBase.DisposeHandler()
            MyBase.Dispose(disposing)
        End Sub
        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False
            Me.ViewCaption = ""
            Me.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.OptionsNavigation.AutoFocusNewRow = True

            Me.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8)
            Me.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8)
            Me.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8)
            Me.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8)
            Me.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8)
            Me.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8)
            Me.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8)
            Me.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8)
            Me.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8)
            Me.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8)

            Me.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.Row.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8)

            Me.OptionsPrint.AutoResetPrintDocument = True

            _DisabledRows = New List(Of AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow)()

            _ChangedRows = New Generic.List(Of Object)

            Me.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False
            Me.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Classic

        End Sub
        Public Function IsNewItemOrAutoFilterRow(ByVal RowHandle As Integer) As Boolean

            'objects
            Dim NewItemOrAutoFilterRowSelected As Boolean = False

            NewItemOrAutoFilterRowSelected = Me.IsNewItemRow(RowHandle)

            If NewItemOrAutoFilterRowSelected = False Then

                NewItemOrAutoFilterRowSelected = Me.IsFilterRow(RowHandle)

            End If

            IsNewItemOrAutoFilterRow = NewItemOrAutoFilterRowSelected

        End Function
        Public Function IsNewItemOrAutoFilterRow() As Boolean

            'objects
            Dim NewItemOrAutoFilterRowSelected As Boolean = False

            NewItemOrAutoFilterRowSelected = Me.IsNewItemRow(Me.FocusedRowHandle)

            If NewItemOrAutoFilterRowSelected = False Then

                NewItemOrAutoFilterRowSelected = Me.IsFilterRow(Me.FocusedRowHandle)

            End If

            IsNewItemOrAutoFilterRow = NewItemOrAutoFilterRowSelected

        End Function
        Public Function CheckForModifiedRows() As Boolean

            'objects
            Dim HasModifiedRows As Boolean = False

            Try

                HasModifiedRows = _ChangedRows.Any

            Catch ex As Exception
                HasModifiedRows = False
            End Try

            CheckForModifiedRows = HasModifiedRows

        End Function
        Public Function RemoveFromModifiedRows(ByVal DataBoundObject As Object) As Boolean

            'objects
            Dim Removed As Boolean = False

            Try

                If _ChangedRows.Contains(DataBoundObject) Then

                    Removed = _ChangedRows.Remove(DataBoundObject)

                End If

            Catch ex As Exception
                Removed = False
            End Try

            RemoveFromModifiedRows = Removed

        End Function
        Public Function AddToModifiedRows(ByVal RowHandle As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim DataBoundObject As Object = Nothing

            Try

                DataBoundObject = Me.GetRow(RowHandle)

                If DataBoundObject IsNot Nothing Then

                    If _ChangedRows.Contains(DataBoundObject) = False Then

                        _ChangedRows.Add(DataBoundObject)

                        Added = True

                    End If

                End If

            Catch ex As Exception
                Added = False
            End Try

            AddToModifiedRows = Added

        End Function
        Public Function AddToModifiedRows(ByVal DataBoundObject As Object) As Boolean

            'objects
            Dim Added As Boolean = False

            Try

                If DataBoundObject IsNot Nothing Then

                    If _ObjectType.Equals(DataBoundObject.GetType) = True Then

                        If _ChangedRows.Contains(DataBoundObject) = False Then

                            _ChangedRows.Add(DataBoundObject)

                            Added = True

                        End If

                    End If

                End If

            Catch ex As Exception
                Added = False
            End Try

            AddToModifiedRows = Added

        End Function
        Public Function GetAllModifiedRows() As Generic.List(Of Object)

            GetAllModifiedRows = _ChangedRows

        End Function
        Public Sub ClearChanged()

            Try

                _ChangedRows.Clear()

            Catch ex As Exception

            End Try

        End Sub
        Public Sub ResetColumnOrderByObjectType()

            'objects
            Dim VisibleIndex As Integer = 0

            If _ObjectType IsNot Nothing Then

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(_ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)()

                    If Me.Columns(PropertyDescriptor.Name) IsNot Nothing Then

                        If Me.Columns(PropertyDescriptor.Name).Visible Then

                            Me.Columns(PropertyDescriptor.Name).VisibleIndex = VisibleIndex
                            VisibleIndex = VisibleIndex + 1

                        End If

                    End If

                Next

            End If

        End Sub
        Public Function DeleteFromDataSource(ByVal DataBoundObject As Object) As Boolean

            'objects
            Dim Deleted As Boolean = False

            If TypeOf Me.DataSource Is System.Windows.Forms.BindingSource Then

                If DirectCast(Me.DataSource, System.Windows.Forms.BindingSource).AllowRemove Then

                    Try

                        DirectCast(Me.DataSource, System.Windows.Forms.BindingSource).Remove(DataBoundObject)

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try

                End If

            End If

            If Deleted Then

                RemoveFromModifiedRows(DataBoundObject)

            End If

            DeleteFromDataSource = Deleted

        End Function
        Protected Overrides Sub OnDataController_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If sender IsNot Nothing AndAlso TypeOf sender Is DevExpress.Data.DataController Then

                If DirectCast(sender, DevExpress.Data.DataController).Columns.Count > 0 Then

                    For Each DataColumnInfo In DirectCast(sender, DevExpress.Data.DataController).Columns.OfType(Of DevExpress.Data.DataColumnInfo)().ToList

                        PropertyDescriptor = DataColumnInfo.PropertyDescriptor

                        If PropertyDescriptor.PropertyType.Name.Contains("ICollection") OrElse (PropertyDescriptor.PropertyType.BaseType IsNot Nothing AndAlso PropertyDescriptor.PropertyType.BaseType.Name.Contains("Entity")) Then

                            DirectCast(sender, DevExpress.Data.DataController).Columns.RemoveAt(DataColumnInfo.Index)

                        End If

                    Next

                End If

            End If

            MyBase.OnDataController_DataSourceChanged(sender, e)

        End Sub
        Protected Overrides Sub OnColumnsCollectionChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)

            'If e.Action = ComponentModel.CollectionChangeAction.Add Then

            '    e.Element.VisibleIndex = e.Element.AbsoluteIndex

            '    ModifyColumn(e.Element)

            '    MyBase.OnColumnsCollectionChanged(sender, e)

            '    RaiseEvent ColumnAddedEvent(e.Element)

            'End If

        End Sub
        Protected Sub ColumnEditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim Saved As Boolean = False
            Dim EditValue As Object = Nothing
            Dim CellValueChangedEventArgs As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs = Nothing

            Try

                If CType(sender, DevExpress.XtraEditors.BaseEdit).Tag.Tag = False Then

                    CType(sender, DevExpress.XtraEditors.BaseEdit).Tag.Tag = True

                    EditValue = CType(sender, DevExpress.XtraEditors.BaseEdit).EditValue

                    CellValueChangedEventArgs = New DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(Me.FocusedRowHandle, Me.FocusedColumn, EditValue)

                End If

            Catch ex As Exception
                CellValueChangedEventArgs = Nothing
            End Try

            If CellValueChangedEventArgs IsNot Nothing Then

                RaiseEvent ColumnEditValueChangedEvent(Saved, CellValueChangedEventArgs)

            End If

        End Sub
        Public Sub ValidateAllRows()

            For RowHandle = 0 To Me.RowCount - 1

                If Me.IsDataRow(RowHandle) Then

                    RaiseValidateRow(New DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs(RowHandle, Me.GetRow(RowHandle)))

                End If

            Next

            Me.LayoutChanged()

        End Sub
        Public Function HasAnyInvalidRows() As Boolean

            'objects
            Dim HasInvalidRows As Boolean = False
            Dim ValidatingClass As AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase = Nothing

            Try

                For RowHandle = 0 To Me.RowCount - 1

                    If Me.IsDataRow(RowHandle) Then

                        Try

                            ValidatingClass = DirectCast(Me.DataSource, System.Windows.Forms.BindingSource).Item(Me.GetDataSourceRowIndex(RowHandle))

                        Catch ex As Exception
                            ValidatingClass = Nothing
                        End Try

                        If ValidatingClass IsNot Nothing Then

                            If ValidatingClass.HasError Then

                                HasInvalidRows = True
                                Exit For

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception
                HasInvalidRows = False
            End Try

            HasAnyInvalidRows = HasInvalidRows

        End Function
        Protected Sub AddSubItemComboBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemComboBoxType As Presentation.Controls.SubItemComboBox.Type)

            Dim SubItemComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemComboBox = Nothing

            SubItemComboBox = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemComboBox(_Session, SubItemComboBoxType)

            If SubItemComboBox IsNot Nothing Then

                AddSubItemComboBox(GridColumn, SubItemComboBox)

            End If

        End Sub
        Protected Sub AddSubItemComboBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemComboBox)

            Me.GridControl.RepositoryItems.Add(SubItemComboBox)

            GridColumn.ColumnEdit = SubItemComboBox

        End Sub
        Protected Sub AddSubItemGridLookupEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemComboBoxType As Presentation.Controls.SubItemGridLookUpEditControl.Type, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            SubItemGridLookUpEditControl = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Session, SubItemComboBoxType, GridColumn.FieldName, EntityAttribute, PropertyDescriptor, Nothing, _AllowExtraItemsInGridLookupEdits)

            If SubItemGridLookUpEditControl IsNot Nothing Then

                AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl, DbContext, DataContext)

            End If

        End Sub
        Protected Sub AddSubItemPopupEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemPopupEditControlType As Presentation.Controls.SubItemPopupEditControl.Type, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            'objects
            Dim SubItemPopupEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemPopupEditControl = Nothing

            SubItemPopupEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemPopupEditControl
            SubItemPopupEditControl.Session = Session
            SubItemPopupEditControl.ControlType = SubItemPopupEditControlType

            If SubItemPopupEditControl IsNot Nothing Then

                Me.GridControl.RepositoryItems.Add(SubItemPopupEditControl)

                GridColumn.ColumnEdit = SubItemPopupEditControl

                AddHandler SubItemPopupEditControl.QueryPopupNeedAvailableCodes, AddressOf SubItemPopupEditControl_QueryPopupNeedAvailableCodes

            End If

        End Sub
        Protected Sub AddSubItemGridLookupEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            'objects
            Dim Cancel As Boolean = False

            If SubItemGridLookUpEditControl IsNot Nothing Then

                If AllowExtraItemsInGridLookupEdits = False Then

                    SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                End If

                If Me.AutoloadRepositoryDatasource Then

                    RaiseEvent RepositoryDataSourceLoadingEvent(GridColumn.FieldName, Cancel)

                    If Cancel = False Then

                        SubItemGridLookUpEditControl.LoadDefaultDataSourceView(DbContext, DataContext)

                    End If

                End If

                Me.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                GridColumn.ColumnEdit = SubItemGridLookUpEditControl

                AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControl_QueryPopup
                AddHandler SubItemGridLookUpEditControl.EditValueChanged, AddressOf SubItemGridLookUpEditControl_EditValueChanged

            End If

        End Sub
        Protected Sub SubItemGridLookUpEditControl_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim ControlType As SubItemGridLookUpEditControl.Type = SubItemGridLookUpEditControl.Type.Default
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim Index As Integer = -1
            Dim Value As Object = Nothing
            Dim DefaultColumnTypeValues As Generic.Dictionary(Of BaseClasses.DefaultColumnTypes, Object) = Nothing
            Dim PropertyTypeValues As Generic.Dictionary(Of BaseClasses.PropertyTypes, Object) = Nothing

            _IsAutoFilling = True

            Try

                Try

                    GridLookUpEdit = sender

                    ControlType = CType(Me.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).ControlType

                Catch ex As Exception
                    GridLookUpEdit = Nothing
                    ControlType = SubItemGridLookUpEditControl.Type.Default
                End Try

                If GridLookUpEdit IsNot Nothing AndAlso ControlType <> SubItemGridLookUpEditControl.Type.Default Then

                    DefaultColumnTypeValues = New Generic.Dictionary(Of BaseClasses.DefaultColumnTypes, Object)
                    PropertyTypeValues = New Generic.Dictionary(Of BaseClasses.PropertyTypes, Object)

                    Select Case ControlType

                        Case SubItemGridLookUpEditControl.Type.Client

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Client.Properties.Name.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.ClientName, Value)

                        Case SubItemGridLookUpEditControl.Type.Division

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Division.Properties.Name.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.DivisionName, Value)

                        Case SubItemGridLookUpEditControl.Type.Product

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.Name.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.ProductName, Value)

                        Case SubItemGridLookUpEditControl.Type.SalesClass

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.SalesClass.Properties.Description.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.SalesClassDescription, Value)

                        Case SubItemGridLookUpEditControl.Type.Function, SubItemGridLookUpEditControl.Type.VendorFunction, SubItemGridLookUpEditControl.Type.EmployeeFunction

                            Value = GetGridLookUpEditColumnValue(GridLookUpEdit, AdvantageFramework.Database.Entities.Function.Properties.Description.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.FunctionDescription, Value)

                        Case SubItemGridLookUpEditControl.Type.Employee

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, "Name")

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.EmployeeName, Value)

                        Case SubItemGridLookUpEditControl.Type.Office

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Office.Properties.Name.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.OfficeName, Value)

                        Case SubItemGridLookUpEditControl.Type.Job

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Core.Job.Properties.Description.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.JobDescription, Value)

                        Case SubItemGridLookUpEditControl.Type.JobComponent, SubItemGridLookUpEditControl.Type.JobComponentID

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Core.JobComponent.Properties.Description.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.JobComponentDescription, Value)

                        Case SubItemGridLookUpEditControl.Type.AccountReceivable

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.AccountReceivableSequenceNumber, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.AccountReceivable.Properties.SequenceNumber.ToString))
                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.AccountReceivableType, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.AccountReceivable.Properties.Type.ToString))
                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.AccountReceivableClientCode, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.AccountReceivable.Properties.ClientCode.ToString))

                        Case SubItemGridLookUpEditControl.Type.DepartmentTeam

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.DepartmentTeam.Properties.Description.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.DepartmentTeamName, Value)

                        Case SubItemGridLookUpEditControl.Type.Vendor

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Vendor.Properties.Name.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.VendorName, Value)

                        Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccount

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.GeneralLedgerAccount.Properties.Description.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription, Value)

                        Case SubItemGridLookUpEditControl.Type.ClientContact

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, "Description")

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.ClientContactName, Value)

                        Case SubItemGridLookUpEditControl.Type.Campaign

                            PropertyTypeValues.Add(BaseClasses.PropertyTypes.CampaignID, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Campaign.Properties.ID.ToString))
                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.CampaignName, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Campaign.Properties.Name.ToString))
                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.CampaignCode, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Campaign.Properties.Code.ToString))

                        Case SubItemGridLookUpEditControl.Type.CampaignID

                            PropertyTypeValues.Add(BaseClasses.PropertyTypes.CampaignCode, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Campaign.Properties.Code.ToString))
                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.CampaignName, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Campaign.Properties.Name.ToString))
                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.CampaignCode, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Campaign.Properties.Code.ToString))

                        Case SubItemGridLookUpEditControl.Type.AdNumber

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.AdNumberDescription, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Ad.Properties.Description.ToString))

                        Case SubItemGridLookUpEditControl.Type.Market

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.MarketDescription, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Market.Properties.Description.ToString))

                        Case SubItemGridLookUpEditControl.Type.AdSize

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.AdSizeDescription, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.AdSize.Properties.Description.ToString))

                        Case SubItemGridLookUpEditControl.Type.StateCode

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.State.Properties.StateName.ToString)

                            DefaultColumnTypeValues.Add(BaseClasses.DefaultColumnTypes.StateName, Value)

                    End Select

                    If IsNothing(GridLookUpEdit.EditValue) OrElse IsDBNull(GridLookUpEdit.EditValue) Then

                        For Each KeyValuePair In DefaultColumnTypeValues

                            SetRowCellValueByDefaultColumnType(Me.FocusedRowHandle, KeyValuePair.Key, Nothing)

                        Next

                        For Each KeyValuePair In PropertyTypeValues

                            SetRowCellValueByPropertyType(Me.FocusedRowHandle, KeyValuePair.Key, Nothing)

                        Next

                    Else

                        For Each KeyValuePair In DefaultColumnTypeValues

                            SetRowCellValueByDefaultColumnType(Me.FocusedRowHandle, KeyValuePair.Key, KeyValuePair.Value)

                        Next

                        For Each KeyValuePair In PropertyTypeValues

                            SetRowCellValueByPropertyType(Me.FocusedRowHandle, KeyValuePair.Key, KeyValuePair.Value)

                        Next

                    End If

                End If

            Catch ex As Exception

            End Try

            _IsAutoFilling = False

            ColumnEditValueChanged(sender, e)

        End Sub
        Protected Sub SubItemGridLookUpEditControl_QueryPopup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""
            Dim ProductCode As String = ""
            Dim JobComponentID As String = ""
            Dim JobNumber As String = ""
            Dim DataSource As Object = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
            Dim Jobs As Generic.List(Of AdvantageFramework.Database.Entities.Job) = Nothing
            Dim JobNumbers As Integer() = Nothing
            Dim Entity As Object = Nothing
            Dim ProductCodes As String() = Nothing
            Dim OverrideDefaultDatasource As Boolean = False
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = BaseClasses.PropertyTypes.Default
            Dim ContinueLoad As Boolean = True

            If _ControlType = BandedDataGridView.Type.EditableGrid AndAlso TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = Me.ActiveEditor

                If e.Cancel = True Then

                    If String.IsNullOrWhiteSpace(GridLookUpEdit.Text) = False Then

                        ContinueLoad = False

                    End If

                End If

                If ContinueLoad Then

                    Try

                        PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(_ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = Me.FocusedColumn.FieldName).SingleOrDefault

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If PropertyDescriptor IsNot Nothing Then

                        Try

                            EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                        Catch ex As Exception
                            EntityAttribute = Nothing
                        End Try

                        If EntityAttribute IsNot Nothing Then

                            PropertyType = EntityAttribute.PropertyType

                        End If

                    End If

                    If _Session IsNot Nothing AndAlso _AutoFilterLookupColumns Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Select Case PropertyType

                                    Case BaseClasses.PropertyTypes.ClientCode

                                        RaiseEvent QueryPopupNeedDatasource(Me.FocusedColumn.FieldName, OverrideDefaultDatasource, DataSource)

                                        If OverrideDefaultDatasource = False Then

                                            DataSource = From Client In AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                         Where Client.IsActive = 1
                                                         Select Client

                                        End If

                                    Case BaseClasses.PropertyTypes.DivisionCode

                                        ClientCode = GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.ClientCode)

                                        If ClientCode <> "" Then

                                            RaiseEvent QueryPopupNeedDatasource(Me.FocusedColumn.FieldName, OverrideDefaultDatasource, DataSource)

                                            If OverrideDefaultDatasource = False Then

                                                DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                             Where Division.ClientCode = ClientCode AndAlso
                                                                    Division.IsActive = 1
                                                             Select Division

                                            End If

                                        Else

                                            Me.CloseEditor()

                                        End If

                                    Case BaseClasses.PropertyTypes.ProductCode

                                        ClientCode = GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.ClientCode)
                                        DivisionCode = GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.DivisionCode)

                                        If ClientCode <> "" AndAlso DivisionCode <> "" Then

                                            RaiseEvent QueryPopupNeedDatasource(Me.FocusedColumn.FieldName, OverrideDefaultDatasource, DataSource)

                                            If OverrideDefaultDatasource = False Then

                                                Try

                                                    ProductCodes = (From UserClientDivisionProductAccess In AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, _Session.UserCode)
                                                                    Where UserClientDivisionProductAccess.ClientCode = ClientCode AndAlso
                                                                            UserClientDivisionProductAccess.DivisionCode = DivisionCode
                                                                    Select [PrdCode] = UserClientDivisionProductAccess.ProductCode).ToList.Select(Function(PrdCode) PrdCode).ToArray

                                                    If ProductCodes.Any Then

                                                        DataSource = From Product In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)
                                                                     Where ProductCodes.Contains(Product.Code) AndAlso
                                                                            Product.IsActive = 1
                                                                     Select Product

                                                    Else

                                                        DataSource = From Product In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)
                                                                     Where Product.IsActive = 1
                                                                     Select Product

                                                    End If

                                                Catch ex As Exception

                                                End Try

                                            End If

                                        Else

                                            Me.CloseEditor()

                                        End If

                                    Case BaseClasses.PropertyTypes.JobNumber

                                        RaiseEvent QueryPopupNeedDatasource(Me.FocusedColumn.FieldName, OverrideDefaultDatasource, DataSource)

                                        If OverrideDefaultDatasource = False Then

                                            ClientCode = GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.ClientCode)
                                            DivisionCode = GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.DivisionCode)
                                            ProductCode = GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.ProductCode)

                                            If ClientCode IsNot Nothing AndAlso DivisionCode IsNot Nothing AndAlso ProductCode IsNot Nothing Then

                                                DataSource = From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                             Where Job.ClientCode = ClientCode AndAlso
                                                                    Job.DivisionCode = DivisionCode AndAlso
                                                                    Job.ProductCode = ProductCode
                                                             Select Job

                                            ElseIf ClientCode IsNot Nothing AndAlso DivisionCode IsNot Nothing Then

                                                DataSource = From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                             Where Job.ClientCode = ClientCode AndAlso
                                                                    Job.DivisionCode = DivisionCode
                                                             Select Job

                                            ElseIf ClientCode IsNot Nothing Then

                                                DataSource = From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                             Where Job.ClientCode = ClientCode
                                                             Select Job

                                            Else

                                                DataSource = AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)

                                            End If

                                        End If

                                    Case BaseClasses.PropertyTypes.JobComponent, BaseClasses.PropertyTypes.JobComponentID

                                        JobNumber = GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.JobNumber)

                                        RaiseEvent QueryPopupNeedDatasource(Me.FocusedColumn.FieldName, OverrideDefaultDatasource, DataSource)

                                        If OverrideDefaultDatasource = False Then

                                            ClientCode = GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.ClientCode)
                                            DivisionCode = GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.DivisionCode)
                                            ProductCode = GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.ProductCode)

                                            If JobNumber IsNot Nothing Then

                                                DataSource = (From JobComponent In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext)
                                                              Where JobComponent.JobNumber = JobNumber
                                                              Select JobComponent).ToList

                                            Else

                                                If ClientCode IsNot Nothing Then

                                                    If DivisionCode IsNot Nothing AndAlso ProductCode IsNot Nothing Then

                                                        JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                      Where Job.ClientCode = ClientCode AndAlso
                                                                            Job.DivisionCode = DivisionCode AndAlso
                                                                            Job.ProductCode = ProductCode AndAlso
                                                                            Job.IsOpen = 1
                                                                      Select Job.Number).ToArray

                                                    ElseIf DivisionCode IsNot Nothing Then

                                                        JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                      Where Job.ClientCode = ClientCode AndAlso
                                                                            Job.DivisionCode = DivisionCode AndAlso
                                                                            Job.IsOpen = 1
                                                                      Select Job.Number).ToArray

                                                    Else

                                                        JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                      Where Job.ClientCode = ClientCode AndAlso
                                                                            Job.IsOpen = 1
                                                                      Select Job.Number).ToArray

                                                    End If

                                                Else

                                                    JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                  Select Job.Number).ToArray

                                                End If

                                                DataSource = (From JobComponent In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext)
                                                              Where JobNumbers.Contains(JobComponent.JobNumber)
                                                              Select JobComponent).ToList

                                            End If

                                        End If

                                        If JobNumber IsNot Nothing Then

                                            If GridLookUpEdit.Properties.View.Columns("JobNumber") IsNot Nothing Then

                                                GridLookUpEdit.Properties.View.Columns("JobNumber").Visible = False

                                            End If

                                        Else

                                            If GridLookUpEdit.Properties.View.Columns("JobNumber") IsNot Nothing Then

                                                GridLookUpEdit.Properties.View.Columns("JobNumber").Visible = True

                                            End If

                                        End If

                                    Case Else

                                        RaiseEvent QueryPopupNeedDatasource(Me.FocusedColumn.FieldName, OverrideDefaultDatasource, DataSource)

                                        If OverrideDefaultDatasource = False Then

                                            DataSource = Nothing

                                        End If

                                End Select

                                If DataSource IsNot Nothing Then

                                    Try

                                        DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(DataSource)

                                    Catch ex As Exception
                                        DataSource = Nothing
                                    End Try

                                End If

                            End Using

                        End Using

                    Else

                        RaiseEvent QueryPopupNeedDatasource(Me.FocusedColumn.FieldName, OverrideDefaultDatasource, DataSource)

                        If OverrideDefaultDatasource = False Then

                            DataSource = Nothing

                        End If

                        If DataSource IsNot Nothing Then

                            Try

                                DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(DataSource)

                            Catch ex As Exception
                                DataSource = Nothing
                            End Try

                        End If

                    End If

                    If DataSource IsNot Nothing Then

                        BindingSource = New System.Windows.Forms.BindingSource

                        BindingSource.DataSource = DataSource

                        GridLookUpEdit.Properties.DataSource = BindingSource

                        If TypeOf Me.FocusedColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                            SubItemGridLookUpEditControl = DirectCast(Me.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                            If _AllowExtraItemsInGridLookupEdits = False Then

                                SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                            End If

                            If SubItemGridLookUpEditControl.AddExtraComboBoxItem Then

                                If SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.NullValue Then

                                    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(GridLookUpEdit.Properties.DataSource, SubItemGridLookUpEditControl.DisplayMember, SubItemGridLookUpEditControl.ValueMember,
                                                                                                                        "[None]", -3, True, True, Nothing)

                                Else

                                    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(GridLookUpEdit.Properties.DataSource, SubItemGridLookUpEditControl.DisplayMember, SubItemGridLookUpEditControl.ValueMember,
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
        Protected Sub SubItemPopupEditControl_QueryPopupNeedAvailableCodes(ByRef AvailableObjects As Object, ByRef OverrideDefault As Boolean)

            If _ControlType = BandedDataGridView.Type.EditableGrid AndAlso TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.PopupContainerEdit Then

                RaiseEvent QueryPopupNeedDatasource(Me.FocusedColumn.FieldName, OverrideDefault, AvailableObjects)

            End If

        End Sub
        Protected Sub AddSubItemMemoEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            Dim SubItemMemoEdit As AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit = Nothing

            SubItemMemoEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemMemoEdit(Session, GridColumn.FieldName, _ObjectType)

            If SubItemMemoEdit IsNot Nothing Then

                AddSubItemMemoEdit(GridColumn, SubItemMemoEdit)

            End If

        End Sub
        Protected Sub AddSubItemMemoEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemMemoEdit As AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit)

            Me.GridControl.RepositoryItems.Add(SubItemMemoEdit)

            GridColumn.ColumnEdit = SubItemMemoEdit

            AddHandler SubItemMemoEdit.Closed, AddressOf SubItemMemoEdit_Closed

        End Sub
        Private Sub SubItemMemoEdit_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If e.CloseMode = DevExpress.XtraEditors.PopupCloseMode.CloseUpKey Then

                Try

                    GridColumn = (From GridCol In Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()
                                  Where GridCol.VisibleIndex > Me.FocusedColumn.VisibleIndex
                                  Order By GridCol.VisibleIndex Ascending
                                  Select GridCol).FirstOrDefault

                Catch ex As Exception
                    GridColumn = Nothing
                End Try

                If GridColumn IsNot Nothing Then

                    Me.FocusedColumn = GridColumn

                Else

                    If Me.IsNewItemRow(Me.FocusedRowHandle) Then

                        Me.FocusedRowHandle = Nothing

                    ElseIf Me.IsLastRow = False Then

                        Try

                            Me.FocusedRowHandle = Me.FocusedRowHandle + 1

                            Try

                                Me.FocusedColumn = (From GridCol In Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()
                                                    Where GridCol.VisibleIndex >= 0
                                                    Order By GridCol.VisibleIndex Ascending
                                                    Select GridCol).FirstOrDefault

                            Catch ex As Exception
                                Me.FocusedColumn = Me.Columns(0)
                            End Try

                        Catch ex As Exception

                        End Try

                    End If

                End If

            End If

        End Sub
        Protected Sub AddSubItemTextBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemTextBoxType As Presentation.Controls.SubItemTextBox.Type)

            'objects
            Dim SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox = Nothing

            SubItemTextBox = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemTextBox(Session, SubItemTextBoxType, GridColumn.FieldName, _ObjectType)

            If SubItemTextBox IsNot Nothing Then

                AddSubItemTextBox(GridColumn, SubItemTextBox)

            End If

        End Sub
        Protected Sub AddSubItemTextBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox)

            Me.GridControl.RepositoryItems.Add(SubItemTextBox)

            GridColumn.ColumnEdit = SubItemTextBox

            AddHandler SubItemTextBox.ButtonClick, AddressOf SubItemTextBox_ButtonClick
            AddHandler SubItemTextBox.EditValueChanged, AddressOf ColumnEditValueChanged

        End Sub
        Protected Sub AddSubItemProgressBar(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim RepositoryItemProgressBar As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar = Nothing

            RepositoryItemProgressBar = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemProgressBar()

            If RepositoryItemProgressBar IsNot Nothing Then

                AddSubItemProgressBar(GridColumn, RepositoryItemProgressBar)

            End If

        End Sub
        Protected Sub AddSubItemProgressBar(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItemProgressBar As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar)

            Me.GridControl.RepositoryItems.Add(RepositoryItemProgressBar)

            GridColumn.ColumnEdit = RepositoryItemProgressBar

        End Sub
        Protected Sub AddSubItemTimeEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim SubItemTimeInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemTimeInput = Nothing

            SubItemTimeInput = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemTimeEdit(SubItemTimeInput.Type.Default)

            If SubItemTimeInput IsNot Nothing Then

                AddSubItemTimeEdit(GridColumn, SubItemTimeInput)

            End If

        End Sub
        Protected Sub AddSubItemTimeEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItemTimeEdit As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit)

            Me.GridControl.RepositoryItems.Add(RepositoryItemTimeEdit)

            GridColumn.ColumnEdit = RepositoryItemTimeEdit

        End Sub
        Protected Sub AddSubItemDateEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim SubItemDateInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput = Nothing

            SubItemDateInput = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemDateEdit()

            If SubItemDateInput IsNot Nothing Then

                AddSubItemDateEdit(GridColumn, SubItemDateInput)

            End If

        End Sub
        Protected Sub AddSubItemDateEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemDateInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput)

            Me.GridControl.RepositoryItems.Add(SubItemDateInput)

            GridColumn.ColumnEdit = SubItemDateInput

        End Sub
        Protected Sub AddSubItemImageComboBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemImageComboBoxType As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox.Type)

            Dim SubItemImageComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox = Nothing

            SubItemImageComboBox = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemImageComboBox(SubItemImageComboBoxType)

            If SubItemImageComboBox IsNot Nothing Then

                AddSubItemImageComboBox(GridColumn, SubItemImageComboBox)

            End If

        End Sub
        Protected Sub AddSubItemImageComboBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemImageComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox)

            Me.GridControl.RepositoryItems.Add(SubItemImageComboBox)

            GridColumn.ColumnEdit = SubItemImageComboBox

        End Sub
        Protected Sub AddSubItemHyperLink(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim RepositoryItemHyperLinkEdit As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit = Nothing

            RepositoryItemHyperLinkEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemHyperLinkEdit()

            If RepositoryItemHyperLinkEdit IsNot Nothing Then

                AddSubItemHyperLink(GridColumn, RepositoryItemHyperLinkEdit)

            End If

        End Sub
        Protected Sub AddSubItemHyperLink(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItemHyperLinkEdit As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit)

            Me.GridControl.RepositoryItems.Add(RepositoryItemHyperLinkEdit)

            GridColumn.ColumnEdit = RepositoryItemHyperLinkEdit

        End Sub
        Protected Sub AddSubItemColorPicker(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim RepositoryItemColorEdit As DevExpress.XtraEditors.Repository.RepositoryItemColorEdit = Nothing

            RepositoryItemColorEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemColorPicker()

            If RepositoryItemColorEdit IsNot Nothing Then

                AddSubItemColorPicker(GridColumn, RepositoryItemColorEdit)

            End If

        End Sub
        Protected Sub AddSubItemColorPicker(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItemColorEdit As DevExpress.XtraEditors.Repository.RepositoryItemColorEdit)

            Me.GridControl.RepositoryItems.Add(RepositoryItemColorEdit)

            GridColumn.ColumnEdit = RepositoryItemColorEdit

        End Sub
        Protected Sub AddSubItemImageCheckBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal IsReadOnly As Boolean, ByVal SubItemImageCheckEditControlType As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl.Type)

            Dim SubItemImageCheckEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl = Nothing

            SubItemImageCheckEditControl = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemImageCheckBox(IsReadOnly, SubItemImageCheckEditControlType, _ObjectType, GridColumn.FieldName)

            If SubItemImageCheckEditControl IsNot Nothing Then

                AddSubItemImageCheckBox(GridColumn, SubItemImageCheckEditControl)

            End If

        End Sub
        Protected Sub AddSubItemImageCheckBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemImageCheckEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl)

            Me.GridControl.RepositoryItems.Add(SubItemImageCheckEditControl)

            GridColumn.ColumnEdit = SubItemImageCheckEditControl

        End Sub
        Protected Sub AddSubItemCheckBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal IsReversedCheckBox As Boolean, ByVal PropertyType As System.Type)

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            RepositoryItemCheckEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(IsReversedCheckBox, PropertyType)

            If RepositoryItemCheckEdit IsNot Nothing Then

                AddSubItemCheckBox(GridColumn, RepositoryItemCheckEdit)

            End If

        End Sub
        Protected Sub AddSubItemCheckBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit)

            Me.GridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

            GridColumn.ColumnEdit = RepositoryItemCheckEdit

        End Sub
        Protected Sub AddSubItemNumericInput(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemNumericInputType As Presentation.Controls.SubItemNumericInput.Type, ByVal IsNullable As Boolean, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

            'objects
            Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing
            Dim FormatString As String = ""

            If GridColumn.DisplayFormat IsNot Nothing Then

                FormatString = GridColumn.DisplayFormat.FormatString

            End If

            SubItemNumericInput = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemNumericInput(Session, SubItemNumericInputType, GridColumn.FieldName, FormatString, IsNullable, _ObjectType, EntityAttribute)

            If SubItemNumericInput IsNot Nothing Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput)

            End If

        End Sub
        Protected Sub AddSubItemNumericInput(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput)

            Me.GridControl.RepositoryItems.Add(SubItemNumericInput)

            GridColumn.ColumnEdit = SubItemNumericInput

        End Sub
        Protected Function AddCustomSubItem(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn,
                                            ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes,
                                            ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                            ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute) As Boolean

            'Objects
            Dim Added As Boolean = False

            Try



            Catch ex As Exception
                Added = True
            Finally
                AddCustomSubItem = False
            End Try

        End Function
        Protected Sub AddSubItemByPropertyTypeAttribute(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim FormatString As String = ""

            If AddCustomSubItem(GridColumn, PropertyType, PropertyDescriptor, EntityAttribute) = False Then

                If GridColumn.DisplayFormat IsNot Nothing Then

                    FormatString = GridColumn.DisplayFormat.FormatString

                End If

                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemByPropertyTypeAttribute(_Session, GridColumn.FieldName, PropertyType, PropertyDescriptor, EntityAttribute, _ObjectType, FormatString, _AllowExtraItemsInGridLookupEdits)

                If RepositoryItem IsNot Nothing Then

                    AddSubItemToGridColumn(GridColumn, RepositoryItem, DbContext, DataContext)

                End If

            End If

        End Sub
        Protected Sub AddSubItemToGridColumn(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                AddSubItemGridLookupEdit(GridColumn, RepositoryItem, DbContext, DataContext)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemComboBox Then

                AddSubItemComboBox(GridColumn, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox Then

                AddSubItemTextBox(GridColumn, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput Then

                AddSubItemDateEdit(GridColumn, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox Then

                AddSubItemImageComboBox(GridColumn, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                AddSubItemNumericInput(GridColumn, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit Then

                AddSubItemMemoEdit(GridColumn, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit Then

                AddSubItemTimeEdit(GridColumn, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemColorEdit Then

                AddSubItemColorPicker(GridColumn, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Then

                AddSubItemCheckBox(GridColumn, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit Then

                AddSubItemHyperLink(GridColumn, RepositoryItem)

            Else

                Me.GridControl.RepositoryItems.Add(RepositoryItem)
                GridColumn.ColumnEdit = RepositoryItem

            End If

        End Sub
        Protected Sub AddSubItemByDefaultColumnTypeAttribute(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim FormatString As String = ""

            Select Case DefaultColumnType

                Case BaseClasses.DefaultColumnTypes.JobComponentDescription,
                        BaseClasses.DefaultColumnTypes.JobDescription,
                        BaseClasses.DefaultColumnTypes.OfficeName,
                        BaseClasses.DefaultColumnTypes.DepartmentTeamName,
                        BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription,
                        BaseClasses.DefaultColumnTypes.Memo,
                        BaseClasses.DefaultColumnTypes.StateName

                    If GridColumn.DisplayFormat IsNot Nothing Then

                        FormatString = GridColumn.DisplayFormat.FormatString

                    End If

                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemByDefaultColumnTypeAttribute(Session, DefaultColumnType, GridColumn.FieldName, FormatString, PropertyDescriptor, EntityAttribute, _ObjectType)

                    If RepositoryItem IsNot Nothing Then

                        AddSubItemToGridColumn(GridColumn, RepositoryItem, DbContext, DataContext)

                    End If

                Case Else

                    AddSubItemByDefaultColumnTypeAttribute(GridColumn, DefaultColumnType, PropertyDescriptor.PropertyType, DbContext, DataContext)

            End Select

        End Sub
        Protected Sub AddSubItemByDefaultColumnTypeAttribute(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes, ByVal ValueType As System.Type, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim FormatString As String = ""

            If GridColumn.DisplayFormat IsNot Nothing Then

                FormatString = GridColumn.DisplayFormat.FormatString

            End If

            RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemByDefaultColumnTypeAttribute(_Session, DefaultColumnType, GridColumn.FieldName, FormatString, ValueType, _ObjectType)

            If RepositoryItem IsNot Nothing Then

                AddSubItemToGridColumn(GridColumn, RepositoryItem, DbContext, DataContext)

            End If

        End Sub
        Protected Sub AddSubItem(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            'objects
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = Nothing
            Dim DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes = Nothing

            If EntityAttribute IsNot Nothing Then

                Try

                    PropertyType = EntityAttribute.PropertyType

                Catch ex As Exception
                    PropertyType = BaseClasses.PropertyTypes.Default
                End Try

                Try

                    DefaultColumnType = EntityAttribute.DefaultColumnType

                Catch ex As Exception
                    DefaultColumnType = BaseClasses.DefaultColumnTypes.None
                End Try

            End If

            If Me.OptionsBehavior.Editable AndAlso GridColumn.OptionsColumn.ReadOnly = False Then

				If PropertyType <> BaseClasses.PropertyTypes.Default Then

					AddSubItemByPropertyTypeAttribute(GridColumn, PropertyType, PropertyDescriptor, EntityAttribute, DbContext, DataContext)

				ElseIf DefaultColumnType <> BaseClasses.DefaultColumnTypes.None Then

					AddSubItemByDefaultColumnTypeAttribute(GridColumn, DefaultColumnType, PropertyDescriptor, EntityAttribute, DbContext, DataContext)

				ElseIf GridColumn.FieldName Like "*DepartmentTeamCode*" Then

					AddSubItemTextBox(GridColumn, Presentation.Controls.SubItemTextBox.Type.DepartmentTeam)

				ElseIf GridColumn.FieldName Like "*OfficeCode*" Then

					AddSubItemTextBox(GridColumn, Presentation.Controls.SubItemTextBox.Type.Office)

				ElseIf GridColumn.FieldName Like "*EmployeeCode*" Then

					If Me.RowCount > 0 AndAlso TypeOf Me.GetRow(0) Is AdvantageFramework.Database.Entities.ImportEmployeeStaging AndAlso
							GridColumn.FieldName = "EmployeeCode" Then

						AddSubItemTextBox(GridColumn, Presentation.Controls.SubItemTextBox.Type.Default)

					ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ContractContact) OrElse
						_ObjectType Is GetType(AdvantageFramework.Database.Classes.ContractReportDetail) Then

						AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.Employee, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

					ElseIf _ObjectType Is GetType(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) Then

						AddSubItemPopupEdit(GridColumn, SubItemPopupEditControl.Type.EmployeeSelection, DbContext, DataContext)

					Else

						AddSubItemTextBox(GridColumn, Presentation.Controls.SubItemTextBox.Type.Employee)

					End If

				ElseIf GridColumn.FieldName Like "*FunctionCode*" Then

					If Me.RowCount > 0 AndAlso TypeOf Me.GetRow(0) Is AdvantageFramework.Database.Entities.ImportEmployeeStaging Then

						AddSubItemTextBox(GridColumn, Presentation.Controls.SubItemTextBox.Type.EmployeeFunction)

					ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Task) Then

						AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.EstimateFunction, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

					Else

						AddSubItemTextBox(GridColumn, Presentation.Controls.SubItemTextBox.Type.Function)

					End If

				ElseIf GridColumn.FieldName Like "*RoleCode*" Then

					AddSubItemTextBox(GridColumn, Presentation.Controls.SubItemTextBox.Type.Role)

				ElseIf GridColumn.FieldName Like "*PurchaseOrderApprovalRule*" Then

					AddSubItemTextBox(GridColumn, Presentation.Controls.SubItemTextBox.Type.PurchaseOrderApprovalRule)

				ElseIf GridColumn.FieldName Like "*Title*" Then

					If Me.RowCount > 0 AndAlso TypeOf Me.GetRow(0) Is AdvantageFramework.Database.Entities.ImportEmployeeStaging Then

						AddSubItemTextBox(GridColumn, Presentation.Controls.SubItemTextBox.Type.EmployeeTitle)

					End If

				ElseIf GridColumn.FieldName = "ServiceFeeTypeCode" Then

					If _ObjectType Is GetType(AdvantageFramework.Database.Entities.DepartmentTeam) Then

						AddSubItemTextBox(GridColumn, SubItemTextBox.Type.ServiceFeeType)

					End If

				ElseIf GridColumn.FieldName = "ExceedOption" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.EstimateProcessingOption) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ExceedOption, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = "MediaType" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.AdSize) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MediaType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = "PostPeriodCode" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.CampaignDetail) Then

					AddSubItemTextBox(GridColumn, SubItemTextBox.Type.PostPeriod)

				ElseIf GridColumn.FieldName = "SalesClassCode" Then

					If _ObjectType Is GetType(AdvantageFramework.Database.Entities.CampaignDetail) Then

						AddSubItemTextBox(GridColumn, SubItemTextBox.Type.SalesClass)

					End If

				ElseIf GridColumn.FieldName = "JobTypeCode" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.VendorPricing) Then

					AddSubItemTextBox(GridColumn, SubItemTextBox.Type.JobType)

				ElseIf GridColumn.FieldName = "BeforeAfter" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.ResourceTask) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.BeforeAfter, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = "Condition" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.ResourceTask) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ResourceTaskCondition, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = "CampaignDetailType" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.CampaignDetail) Then

					AddSubItemTextBox(GridColumn, SubItemTextBox.Type.CampaignDetailType)

				ElseIf GridColumn.FieldName = "DefaultFunction" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.ImportVendorStaging) Then

					AddSubItemTextBox(GridColumn, SubItemTextBox.Type.Function)

				ElseIf GridColumn.FieldName = "VendorTermCode" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.ImportVendorStaging) Then

					AddSubItemTextBox(GridColumn, SubItemTextBox.Type.VendorTerm)

				ElseIf GridColumn.FieldName = "VendorCategory" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.ImportVendorStaging) Then

					AddSubItemTextBox(GridColumn, SubItemTextBox.Type.VendorCategory)

				ElseIf (GridColumn.FieldName = "FromGLACode" OrElse GridColumn.FieldName = "ToGLACode") AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Classes.OverheadAccountDetail) Then

					AddSubItemTextBox(GridColumn, SubItemTextBox.Type.GeneralLedgerAccount)

				ElseIf GridColumn.FieldName = "EmployeeCategoryID" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.EmployeeTitle) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.EmployeeCategory, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = "SuppliedBy" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.EstimateTemplateDetail) Then

					AddSubItemTextBox(GridColumn, SubItemTextBox.Type.EstimateTemplate)

				ElseIf GridColumn.FieldName = "AdNumber" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.Blackplate) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.AdNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = "SalesClassTypeCode" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.SalesClass) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.SalesClassMediaType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = "StatusCode" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.Task) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.Status, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = "UseAddress" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ClientARAddressLookup, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = "UseAddress" AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ProductARAddressLookup, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.EmployeeSetting.Properties.WeeklyTimeType.ToString AndAlso
						_ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeSetting) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ReportMissingTime, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.EmployeeHRInformation.Properties.Status.ToString AndAlso
						_ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeHRInformation) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.EmployeeHRStatus, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.EmployeeHRInformation.Properties.EmployeeVendorCode.ToString AndAlso
						_ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeHRInformation) Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.EmployeeVendor, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.EmployeeNotes.Properties.Comments.ToString AndAlso
						_ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeNotes) Then

					AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

				ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.EstimateTemplateDetail.Properties.Hours.ToString AndAlso
						_ObjectType Is GetType(AdvantageFramework.Database.Entities.EstimateTemplateDetail) Then

					AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, True, EntityAttribute)

				ElseIf (GridColumn.FieldName = AdvantageFramework.Database.Entities.SalesTax.Properties.StatePercent.ToString OrElse
						GridColumn.FieldName = AdvantageFramework.Database.Entities.SalesTax.Properties.CountyPercent.ToString OrElse
						GridColumn.FieldName = AdvantageFramework.Database.Entities.SalesTax.Properties.CityPercent.ToString) AndAlso
						_ObjectType Is GetType(AdvantageFramework.Database.Entities.SalesTax) Then

					AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, True, EntityAttribute)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeStandardTime) AndAlso
						(GridColumn.FieldName = AdvantageFramework.Database.Classes.EmployeeStandardTime.Properties.StartTime.ToString OrElse
						GridColumn.FieldName = AdvantageFramework.Database.Classes.EmployeeStandardTime.Properties.EndTime.ToString) Then

					AddSubItemTimeEdit(GridColumn)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeAlertGroup) AndAlso
					GridColumn.FieldName = AdvantageFramework.Database.Classes.EmployeeAlertGroup.Properties.AlertGroupCode.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.AlertGroup, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) AndAlso
						GridColumn.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsFeeTime.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.FeeTime, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) AndAlso
						GridColumn.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTaxCommission.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MarkupTaxFlags, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) AndAlso
						GridColumn.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsNonBillable.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.YesNoSkip, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) AndAlso
						GridColumn.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTax.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.YesNoSkip, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Views.BillingRateDetailView) AndAlso
					GridColumn.FieldName = AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsFeeTime.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.FeeTime, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Views.BillingRateDetailView) AndAlso
						GridColumn.FieldName = AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsTaxCommission.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MarkupTaxFlags, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Views.BillingRateDetailView) AndAlso
						GridColumn.FieldName = AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsNonBillable.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.YesNoSkip, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Views.BillingRateDetailView) AndAlso
						GridColumn.FieldName = AdvantageFramework.Database.Views.BillingRateDetailView.Properties.TaxFlag.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.YesNoSkip, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Function) AndAlso
						GridColumn.FieldName = AdvantageFramework.Database.Entities.Function.Properties.Type.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.FunctionType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Function) AndAlso
						(GridColumn.FieldName = AdvantageFramework.Database.Entities.Function.Properties.TaxFlag.ToString OrElse
						GridColumn.FieldName = AdvantageFramework.Database.Entities.Function.Properties.CommissionFlag.ToString OrElse
						GridColumn.FieldName = AdvantageFramework.Database.Entities.Function.Properties.TaxCommissionFlag.ToString OrElse
						GridColumn.FieldName = AdvantageFramework.Database.Entities.Function.Properties.TaxCommissionOnlyFlag.ToString OrElse
						GridColumn.FieldName = AdvantageFramework.Database.Entities.Function.Properties.NonBillableFlag.ToString) Then

					AddSubItemImageCheckBox(GridColumn, True, SubItemImageCheckEditControl.Type.YesNoSkip)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Views.FunctionView) AndAlso
						GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.Type.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.FunctionType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Views.FunctionView) AndAlso
					  (GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.TaxFlag.ToString OrElse
					   GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.CommissionFlag.ToString OrElse
					   GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.TaxCommissionFlag.ToString OrElse
					   GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.TaxCommissionOnlyFlag.ToString OrElse
					   GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.NonBillableFlag.ToString) Then

					AddSubItemImageCheckBox(GridColumn, True, SubItemImageCheckEditControl.Type.YesNoSkip)

				ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.Function) AndAlso
						GridColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.Type.ToString Then

					AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.FunctionType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.Function) AndAlso
                      (GridColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.TaxFlag.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.CommissionFlag.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.TaxCommissionFlag.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.TaxCommissionOnlyFlag.ToString OrElse
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.NonBillableFlag.ToString) Then

                    AddSubItemImageCheckBox(GridColumn, True, SubItemImageCheckEditControl.Type.YesNoSkip)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.ExpenseReportItem) AndAlso
                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.PaymentType.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ExpenseItemPayment, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingCoop) AndAlso
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.BillingCoop.Properties.Percent.ToString Then

                    AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail) AndAlso
                        (GridColumn.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.ApprovalMinimum.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.ApprovalMaximum.ToString) Then

                    AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                    GridColumn.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee) AndAlso
                        GridColumn.FieldName = AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.Order.ToString Then

                    AddDefaultSubItem(GridColumn, PropertyDescriptor)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.RateCardDetail.Properties.ContractQuantity.ToString AndAlso
                        _ObjectType Is GetType(AdvantageFramework.Database.Entities.RateCardDetail) Then

                    AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.RateCardDetail.Properties.By.ToString AndAlso
                        _ObjectType Is GetType(AdvantageFramework.Database.Entities.RateCardDetail) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.RateBy, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.RateCardDetail.Properties.Type.ToString AndAlso
                        _ObjectType Is GetType(AdvantageFramework.Database.Entities.RateCardDetail) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.RateType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.RateCardDetail.Properties.Notes.ToString AndAlso
                        _ObjectType Is GetType(AdvantageFramework.Database.Entities.RateCardDetail) Then

                    AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.RateCardColorCharge.Properties.Charge.ToString AndAlso
                        _ObjectType Is GetType(AdvantageFramework.Database.Entities.RateCardColorCharge) Then

                    AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString AndAlso
                        _ObjectType Is GetType(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ImportTemplateProperty, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.FieldName.ToString AndAlso
                        _ObjectType Is GetType(AdvantageFramework.Database.Classes.ImportTemplateDetailFixed) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ImportTemplateProperty, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.Comment.ToString AndAlso
                    _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail) Then

                    AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ContractReportDetail.Properties.CycleCode.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.Cycle, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.PONumber.ToString AndAlso
                    _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.PONumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.PODetailLineNumber.ToString AndAlso
                    _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.POLineNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) Then

                    If GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PONumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.PONumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PODetailLineNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.POLineNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.Quantity.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.Rate.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ExtendedAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ExtendedMarkupAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.LineTotal.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.CommissionPercent.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ExtendedNonResaleTax.ToString Then

                        AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.Comment.ToString Then

                        AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail) Then

                    If GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.OrderNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MagazineOrderNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.OrderLineNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MagazineOrderLineNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.NewApprovalStatus.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MediaApprovalStatusPendingOnly, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.NewApprovalComments.ToString Then

                        AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.GrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.BleedGrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.PositionGrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.PremiumGrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.ColorGrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.NetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.BleedNetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.PositionNetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.PremiumNetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.ColorNetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.DiscountLN.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.NetCharges.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.VendorTax.ToString Then

                        AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail) Then

                    If GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.OrderNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.NewspaperOrderNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.OrderLineNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.NewspaperOrderLineNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.NewApprovalStatus.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MediaApprovalStatusPendingOnly, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.NewApprovalComments.ToString Then

                        AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.PrintLines.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.Rate.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.GrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.NetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.DiscountLN.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.NetCharges.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.VendorTax.ToString Then

                        AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail) Then

                    If GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.InternetOrderNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.InternetOrderNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.InternetDetailLineNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.InternetOrderLineNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.NewApprovalStatus.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MediaApprovalStatusPendingOnly, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.NewApprovalComments.ToString Then

                        AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.Impressions.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.Rate.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.GrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.NetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.DiscountAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.NetCharges.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.VendorTax.ToString Then

                        AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail) Then

                    If GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.OutdoorOrderNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.OutOfHomeOrderNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.OutdoorDetailLineNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.OutOfHomeOrderLineNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.NewApprovalStatus.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MediaApprovalStatusPendingOnly, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.NewApprovalComments.ToString Then

                        AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.GrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.NetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.DiscountAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.NetCharges.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.VendorTax.ToString Then

                        AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail) Then

                    If GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.RadioOrderNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderLineNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.RadioOrderLineNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.BroadcastMonth.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.RadioOrderLegacyMonth, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.BroadcastYear.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.RadioOrderLegacyMonth, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.NewApprovalStatus.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MediaApprovalStatusPendingOnly, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.NewApprovalComments.ToString Then

                        AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.GrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.ExtendedNetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.DiscountAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.NetCharges.ToString Then

                        AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.TotalSpots.ToString Then

                        AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Integer, False, EntityAttribute)

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail) Then

                    If GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.TVOrderNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderLineNumber.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.TVOrderLineNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.BroadcastMonth.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.TVOrderLegacyMonth, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.BroadcastYear.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.TVOrderLegacyYear, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.NewApprovalStatus.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.MediaApprovalStatusPendingOnly, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.NewApprovalComments.ToString Then

                        AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.GrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.ExtendedNetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.DiscountAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.NetCharges.ToString Then

                        AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                    ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.TotalSpots.ToString Then

                        AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Integer, False, EntityAttribute)

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.CompanyProfileAffiliation) AndAlso
                    GridColumn.FieldName = AdvantageFramework.Database.Entities.CompanyProfileAffiliation.Properties.AffiliationID.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.Affiliation, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ActivityCompetition) AndAlso
                    GridColumn.FieldName = AdvantageFramework.Database.Entities.ActivityCompetition.Properties.CompetitionID.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.Competition, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.AccountExecutive) Then

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.AccountExecutive.Properties.ManagementLevel.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ManagementLevel, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.Comment.ToString AndAlso
                    _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail) Then

                    AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Views.ExpenseSummary.Properties.IsApproved.ToString AndAlso
                        _ObjectType Is GetType(AdvantageFramework.Database.Views.ExpenseSummary) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ExpenseReportApprovedFlag, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.ContractFeeItem) Then

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.ContractFeeItem.Properties.ServiceFeeTypeID.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ServiceFeeTypeID, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Hours.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Amount.ToString Then

                        AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaType.ToString AndAlso _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.AccountPayableImportMediaType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString AndAlso _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString AndAlso _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderLineNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.POLine.ToString AndAlso _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.POLineNumber, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.CRMActivitySummary) AndAlso GridColumn.FieldName = AdvantageFramework.Database.Classes.CRMActivitySummary.Properties.Body.ToString Then

                    AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV) Then

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.DateFormat.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.DateFormat, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.ImportTemplateDetailFixed) Then

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.DateFormat.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.DateFormat, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Media.Classes.ImportOrder) AndAlso
                        GridColumn.FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.NetGross.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.RateType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Media.Classes.ImportOrder) AndAlso
                        GridColumn.FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.CostType.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.CostType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.NonbilledEmployeeTime) AndAlso
                       GridColumn.FieldName = AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.FeeTimeFlag.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.FeeTime, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.NonbilledEmployeeTime) AndAlso
                   GridColumn.FieldName = AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.EmployeeTimeFlag.ToString Then

                    AddSubItemImageComboBox(GridColumn, AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox.Type.EmployeeTimeFlag)

                ElseIf _ObjectType Is GetType(AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) AndAlso
                        GridColumn.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.CollectionNote.ToString Then

                    AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                ElseIf _ObjectType Is GetType(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry) AndAlso
                    GridColumn.FieldName.Contains("Day") AndAlso GridColumn.FieldName.Contains("Hours") Then

                    AddSubItemTextBox(GridColumn, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox.Type.TimesheetHourEntry)

                ElseIf _ObjectType Is GetType(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry) AndAlso
                      GridColumn.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Progress.ToString Then

                    For Each ProgressType In [Enum].GetValues(GetType(AdvantageFramework.EmployeeTimesheet.ProgressTypes))

                        AddSubItemProgressBar(GridColumn, CreateSubItemProgressBar())

                        If GridColumn.ColumnEdit IsNot Nothing AndAlso TypeOf GridColumn.ColumnEdit Is DevExpress.XtraEditors.Repository.RepositoryItemProgressBar Then

                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).LookAndFeel.UseDefaultLookAndFeel = False
                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).Step = 1
                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).Maximum = 100
                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).Minimum = 0
                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).StartColor = AdvantageFramework.EmployeeTimesheet.GetProgressColor(ProgressType)
                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).EndColor = AdvantageFramework.EmployeeTimesheet.GetProgressColor(ProgressType)
                            CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).Tag = ProgressType

                        End If

                    Next

                ElseIf _ObjectType Is GetType(AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging) Then

                    If GridColumn.FieldName = AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.RecordType.ToString Then

                        AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.AccountReceivableRecordType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) AndAlso GridColumn.FieldName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStatus.ToString Then

                    AddSubItemImageComboBox(GridColumn, AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox.Type.TaskStatus)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ImportProductStaging) AndAlso
                        GridColumn.FieldName = AdvantageFramework.Database.Entities.ImportProductStaging.Properties.ProductionAlertGroup.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.AlertGroup, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) AndAlso
                       GridColumn.FieldName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.ClientContact.ToString Then

                    AddSubItemPopupEdit(GridColumn, SubItemPopupEditControl.Type.ClientContactSelection, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoice) AndAlso
                        (GridColumn.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.CollectionNotes.ToString OrElse
                         GridColumn.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.VoidComment.ToString) Then

                    AddSubItemMemoEdit(GridColumn, PropertyDescriptor)

                ElseIf _ObjectType Is GetType(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) AndAlso GridColumn.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.BalanceType.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.GeneralLedgerBalanceTypes, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) AndAlso GridColumn.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Type.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.GeneralLedgerAccountTypes, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold) AndAlso GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.NewBillHoldStatus.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ProductionBillHoldStatus, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl) AndAlso
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.NewProcessControl.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.JobProcess, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) AndAlso
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.FeeTimeType.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.FeeTime, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) AndAlso
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsBillOnHold.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ProductionBillHoldStatus, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) AndAlso
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsBillOnHold.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ProductionBillHoldStatus, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) AndAlso
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsBillOnHold.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ProductionBillHoldStatus, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) AndAlso
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.ReconcileStatus.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.ProductionReconcileStatus, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf _ObjectType Is GetType(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) AndAlso
                        GridColumn.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.Frequency.ToString Then

                    AddSubItemGridLookupEdit(GridColumn, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.ServiceFeeFrequency, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Entities.VendorServiceTax.Properties.Type.ToString AndAlso _ObjectType Is GetType(AdvantageFramework.Database.Entities.VendorServiceTax) Then

                    AddSubItemGridLookupEdit(GridColumn, SubItemGridLookUpEditControl.Type.VendorServiceTaxType, EntityAttribute, PropertyDescriptor, DbContext, DataContext)

                Else

                    AddDefaultSubItem(GridColumn, PropertyDescriptor.PropertyType, EntityAttribute)

                End If

            ElseIf Me.OptionsBehavior.Editable = False Then

                If PropertyType <> BaseClasses.PropertyTypes.Default Then

                    If _ObjectType Is GetType(AdvantageFramework.Database.Views.BillingRateDetailView) Then

                        'AddSubItemByPropertyTypeAttribute(GridColumn, PropertyType, PropertyDescriptor, EntityAttribute)

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobVersionTemplateDetail) Then

                        AddSubItemByPropertyTypeAttribute(GridColumn, PropertyType, PropertyDescriptor, EntityAttribute, DbContext, DataContext)

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.EstimateRevisionDetail) Then

                        AddSubItemByPropertyTypeAttribute(GridColumn, PropertyType, PropertyDescriptor, EntityAttribute, DbContext, DataContext)

                    End If

                ElseIf DefaultColumnType <> BaseClasses.DefaultColumnTypes.None Then

                    If _ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Database.Views.BillingRateDetailView) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Database.Views.VendorInvoiceAlert) OrElse
                            _ObjectType Is GetType(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) Then

                        AddSubItemByDefaultColumnTypeAttribute(GridColumn, DefaultColumnType, PropertyDescriptor, EntityAttribute, DbContext, DataContext)

                    Else

                        AddSubItemByDefaultColumnTypeAttribute(GridColumn, DefaultColumnType, GetType(Boolean), DbContext, DataContext)

                    End If

                ElseIf GridColumn.FieldName = "FileType" AndAlso
                        (_ObjectType Is GetType(AdvantageFramework.Database.Entities.Document) OrElse
                        _ObjectType Is GetType(AdvantageFramework.Database.Classes.DetailDocument) OrElse
                        _ObjectType Is GetType(AdvantageFramework.DocumentManager.Classes.Document)) Then

                    AddSubItemImageComboBox(GridColumn, SubItemImageComboBox.Type.DocumentType)

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.GeneralLedgerTransaction) AndAlso
                        (GridColumn.FieldName = AdvantageFramework.Database.Classes.GeneralLedgerTransaction.Properties.DebitAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.GeneralLedgerTransaction.Properties.CreditAmount.ToString) Then

                    AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Currency, True, EntityAttribute)

                End If

            ElseIf Me.OptionsBehavior.Editable AndAlso GridColumn.OptionsColumn.ReadOnly Then

                If PropertyType <> BaseClasses.PropertyTypes.Default Then

                    AddSubItemByPropertyTypeAttribute(GridColumn, PropertyType, PropertyDescriptor, EntityAttribute, DbContext, DataContext)

                ElseIf DefaultColumnType <> BaseClasses.DefaultColumnTypes.None Then

                    AddSubItemByDefaultColumnTypeAttribute(GridColumn, DefaultColumnType, PropertyDescriptor, EntityAttribute, DbContext, DataContext)

                Else

                    AddDefaultSubItem(GridColumn, PropertyDescriptor.PropertyType, EntityAttribute)

                End If

            End If

        End Sub
        Private Sub AddDefaultSubItem(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Try

                EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

            Catch ex As Exception
                EntityAttribute = Nothing
            End Try

            AddDefaultSubItem(GridColumn, PropertyDescriptor.PropertyType, EntityAttribute)

        End Sub
        Private Sub AddDefaultSubItem(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal PropertyType As System.Type,
                                        Optional ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing)

            If PropertyType Is GetType(String) Then

                AddSubItemTextBox(GridColumn, Presentation.Controls.SubItemTextBox.Type.Default)

            ElseIf PropertyType Is GetType(Decimal) Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Decimal)) Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Decimal, True, EntityAttribute)

            ElseIf PropertyType Is GetType(Double) Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Double, True, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Double)) Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Double, True, EntityAttribute)

            ElseIf PropertyType Is GetType(Long) Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Long, False, EntityAttribute)

            ElseIf PropertyType Is GetType(Integer) Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Integer, False, EntityAttribute)

            ElseIf PropertyType Is GetType(Short) Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Short, False, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Long)) Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Long, True, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Integer)) Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Integer, True, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Short)) Then

                AddSubItemNumericInput(GridColumn, SubItemNumericInput.Type.Short, True, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Boolean)) OrElse
                    PropertyType Is GetType(Boolean) Then

                AddSubItemCheckBox(GridColumn, False, GetType(Boolean))

            ElseIf PropertyType Is GetType(System.Nullable(Of Date)) OrElse
                PropertyType Is GetType(Date) Then

                AddSubItemDateEdit(GridColumn)

            End If

        End Sub
        Protected Sub ModifyColumn(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim CanAddGridColumnRepositoryItem As Boolean = True

            Try

                GridColumn.OptionsFilter.FilterPopupMode = _FilterPopupMode

            Catch ex As Exception

            End Try

            If _ObjectTypePropertyDescriptors IsNot Nothing Then

                Try

                    PropertyDescriptor = (From [Property] In _ObjectTypePropertyDescriptors
                                          Where [Property].Name = GridColumn.FieldName
                                          Select [Property]).SingleOrDefault

                Catch ex As Exception
                    PropertyDescriptor = Nothing
                End Try

            End If

            SetGridColumnAppearanceDefaults(GridColumn)

            If PropertyDescriptor IsNot Nothing Then

                If PropertyDescriptor.PropertyType Is GetType(System.Int16) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of System.Int16)) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Int32) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of System.Int32)) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Int64) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of System.Int64)) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Decimal) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of System.Decimal)) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Double) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of System.Double)) Then

                    GridColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals

                End If

                If PropertyDescriptor.PropertyType Is GetType(System.DateTime) OrElse
                        PropertyDescriptor.PropertyType Is GetType(Date) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of System.DateTime)) OrElse
                        PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of Date)) Then

                    GridColumn.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value

                End If

                GridColumn.OptionsColumn.AllowEdit = Not PropertyDescriptor.IsReadOnly

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                Finally

                    If EntityAttribute IsNot Nothing Then

                        If EntityAttribute.DisplayFormat <> "" Then

                            If EntityAttribute.DisplayFormat.StartsWith("c") OrElse EntityAttribute.DisplayFormat.StartsWith("n") Then

                                GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                            ElseIf EntityAttribute.DisplayFormat.StartsWith("d") Then

                                GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                            End If

                            GridColumn.DisplayFormat.FormatString = EntityAttribute.DisplayFormat

                        End If

                        If EntityAttribute.CustomColumnCaption <> "" Then

                            GridColumn.Caption = EntityAttribute.CustomColumnCaption

                        ElseIf EntityAttribute.PropertyType <> BaseClasses.PropertyTypes.Default Then

                            Select Case EntityAttribute.PropertyType

                                Case BaseClasses.PropertyTypes.ClientCode, BaseClasses.PropertyTypes.DivisionCode,
                                        BaseClasses.PropertyTypes.ProductCode, BaseClasses.PropertyTypes.FunctionCode

                                    If _ControlType = BandedDataGridView.Type.EditableGrid Then

                                        GridColumn.Caption = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.BaseClasses.PropertyTypes), CLng(EntityAttribute.PropertyType)).Replace("Code", "")

                                    End If

                            End Select

                        End If

                        GridColumn.OptionsColumn.ReadOnly = EntityAttribute.IsReadOnlyColumn
                        GridColumn.Visible = EntityAttribute.ShowColumnInGrid
                        GridColumn.OptionsColumn.AllowShowHide = EntityAttribute.ShowColumnInGrid
                        GridColumn.OptionsColumn.ShowInCustomizationForm = EntityAttribute.ShowColumnInGrid
                        GridColumn.OptionsColumn.ShowInExpressionEditor = EntityAttribute.ShowColumnInGrid
                        CanAddGridColumnRepositoryItem = EntityAttribute.ShowColumnInGrid

                    End If

                End Try

                If _ControlType = BandedDataGridView.Type.DynamicReport Then

                    If EntityAttribute Is Nothing OrElse (EntityAttribute IsNot Nothing AndAlso String.IsNullOrWhiteSpace(EntityAttribute.DisplayFormat)) Then

                        If PropertyDescriptor.PropertyType Is GetType(Nullable(Of Decimal)) OrElse
                                PropertyDescriptor.PropertyType Is GetType(Decimal) OrElse
                                PropertyDescriptor.PropertyType Is GetType(Nullable(Of Double)) OrElse
                                PropertyDescriptor.PropertyType Is GetType(Double) Then

                            GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf PropertyDescriptor.PropertyType Is GetType(Nullable(Of Short)) OrElse
                                    PropertyDescriptor.PropertyType Is GetType(Short) OrElse
                                    PropertyDescriptor.PropertyType Is GetType(Nullable(Of Integer)) OrElse
                                    PropertyDescriptor.PropertyType Is GetType(Integer) OrElse
                                    PropertyDescriptor.PropertyType Is GetType(Nullable(Of Long)) OrElse
                                    PropertyDescriptor.PropertyType Is GetType(Long) Then

                            GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            GridColumn.DisplayFormat.FormatString = "n0"

                        End If

                    End If

                    If _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.ProjectScheduleReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.JobSummaryReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.JobProjectScheduleSummaryReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.JobDetailBillMonthReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.JobDetailFunctionReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.JobDetailReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.ProjectHoursUsedReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.DirectTimeReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.DirectTimeCostReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.DirectIndirectTimeReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.DirectIndirectTimeCostReport) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Database.Classes.EstimateForm) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.JobDetailFeesOOPFunction) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.JobDetailFeesOOPJob) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Reporting.Database.Classes.JobDetailFeesOOPJobComponent) Then

                        If GridColumn.FieldName.StartsWith("LabelAssign") OrElse
                                GridColumn.FieldName.StartsWith("LabelFromUDFTable") OrElse
                                GridColumn.FieldName.StartsWith("CompLabelFromUDFTable") Then

                            GridColumn.Visible = AdvantageFramework.Reporting.LoadDynamicColumnHeader(DbContext, GridColumn.FieldName, GridColumn.Caption, GridColumn.OptionsColumn.AllowShowHide, GridColumn.OptionsColumn.ShowInCustomizationForm, GridColumn.OptionsColumn.ShowInExpressionEditor, 0, 0)

                        End If

                    End If

                End If

                If GridColumn.ColumnEdit Is Nothing AndAlso CanAddGridColumnRepositoryItem Then

                    AddSubItem(GridColumn, PropertyDescriptor, EntityAttribute, DbContext, DataContext)

                End If

            Else

                If Me.OptionsBehavior.Editable = False Then

                    If (_ObjectType Is GetType(AdvantageFramework.Database.Entities.Client) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Database.Entities.Division) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Database.Entities.Product) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Database.Entities.AlertGroup) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Database.Views.ProductView) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Database.Views.DivisionView) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Database.Entities.Vendor)) AndAlso GridColumn.FieldName = "IsInactive" Then

                        AddDefaultSubItem(GridColumn, GetType(Boolean))

                    End If

                End If

            End If

        End Sub
        Protected Sub AddSalesTaxUnboundColumn()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridColumn = Me.Columns.AddField("TotalPercent")

            GridColumn.Caption = "Total Percent"

            GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            GridColumn.OptionsColumn.AllowEdit = False

            GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridColumn.DisplayFormat.FormatString = "f4"

            GridColumn.UnboundExpression = "IsNull([CityPercent], 0) + IsNull([CountyPercent], 0) + IsNull([StatePercent], 0)"

            GridColumn.VisibleIndex = 5

        End Sub
        Protected Sub AddIntegerUnboundColumn(ByVal FieldName As String, ByVal Caption As String, ByVal VisibleIndex As Integer)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            _IntegerUnboundColumnFieldName = FieldName

            GridColumn = Me.Columns.AddField(_IntegerUnboundColumnFieldName)

            GridColumn.Caption = Caption

            GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Integer
            GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            SetGridColumnAppearanceDefaults(GridColumn)

            If _ControlType = BandedDataGridView.Type.EditableGrid Then

                _IntegerUnboundColumnValues = New Generic.Dictionary(Of Integer, Integer)

                AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput.Type.Integer, True, Nothing)

            End If

            GridColumn.VisibleIndex = VisibleIndex

        End Sub
        Protected Sub AddCustomGroupByKeyColumn()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridColumn = Me.Columns.AddField("CustomGroupByKey")

            GridColumn.Caption = ""

            GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.String
            GridColumn.OptionsColumn.AllowEdit = False
            GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None

            GridColumn.VisibleIndex = -1

        End Sub
        Private Sub OnChangeHeaderTextClick(ByVal sender As Object, ByVal e As EventArgs)

            'objects
            Dim Caption As String = ""

            If TypeOf sender Is DevExpress.Utils.Menu.DXMenuItem AndAlso
                    DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag IsNot Nothing AndAlso
                    TypeOf DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag Is DevExpress.XtraGrid.Columns.GridColumn Then

                If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Change Header Text", "Enter Header Text", DirectCast(sender.Tag, DevExpress.XtraGrid.Columns.GridColumn).Caption, Caption, AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn.Properties.HeaderText) = Windows.Forms.DialogResult.OK Then

                    DirectCast(sender.Tag, DevExpress.XtraGrid.Columns.GridColumn).Caption = Caption

                End If

            End If

        End Sub
        Private Sub OnDeleteClick(ByVal sender As Object, ByVal e As EventArgs)

            If TypeOf sender Is DevExpress.Utils.Menu.DXMenuItem AndAlso
                    DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag IsNot Nothing AndAlso
                    TypeOf DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag Is DevExpress.XtraGrid.Columns.GridColumn Then

                Me.Columns.Remove(DirectCast(sender.Tag, DevExpress.XtraGrid.Columns.GridColumn))

                Try

                    Me.BestFitColumns()

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub OnEditClick(ByVal sender As Object, ByVal e As EventArgs)

            If TypeOf sender Is DevExpress.Utils.Menu.DXMenuItem AndAlso
                    DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag IsNot Nothing AndAlso
                    TypeOf DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag Is DevExpress.XtraGrid.Columns.GridColumn Then

                RaiseEvent OnEditUnboundColumnClickEvent(DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag)

            End If

        End Sub
        Public Overrides Function IsExistAnyRowFooterCell(ByVal rowHandle As Integer) As Boolean

            'objects
            Dim Exists As Boolean = False

            Exists = MyBase.IsExistAnyRowFooterCell(rowHandle)

            RaiseEvent IsExistAnyRowFooterCellEvent(rowHandle, Exists)

            IsExistAnyRowFooterCell = Exists

        End Function
        Private Sub SetNearestCanFocusColumn(ByVal Column As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If _ControlType = BandedDataGridView.Type.EditableGrid Then

                If Column IsNot Nothing Then

                    Try

                        If _ObjectTypePropertyDescriptors IsNot Nothing Then

                            PropertyDescriptor = _ObjectTypePropertyDescriptors.Where(Function(Prop) Prop.Name = Column.FieldName).SingleOrDefault

                            If PropertyDescriptor IsNot Nothing Then

                                Try

                                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                                Catch ex As Exception
                                    EntityAttribute = Nothing
                                End Try

                                If EntityAttribute IsNot Nothing Then

                                    DefaultColumnType = EntityAttribute.DefaultColumnType

                                End If

                            End If

                        End If

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If Column.FieldName = "Code" Then

						If _ObjectType Is GetType(AdvantageFramework.Database.Entities.Status) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.Role) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.DepartmentTeam) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.ServiceFeeType) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.ProductCategory) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.InvoiceCategory) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.IndirectCategory) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.FiscalPeriod) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.InternetType) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.OutOfHomeType) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.Market) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.AlertGroup) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.Complexity) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.Destination) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.Blackplate) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.SalesClass) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.Task) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobType) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.PrintSpecStatus) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.PrintSpecRegion) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.PromotionType) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.ResourceType) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobUserDefinedValue1) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.JobUserDefinedValue2) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobUserDefinedValue3) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.JobUserDefinedValue4) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobUserDefinedValue5) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.WebsiteType) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.ClientWebsite) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.Function) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Classes.OfficeInterCompanyDetail) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.DestinationContact) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.Affiliation) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.Competition) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.Industry) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.Specialty) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.Source) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.Rating) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.Cycle) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.PostPeriod) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Classes.PostPeriod) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Entities.InvoiceCategory) OrElse _ObjectType Is GetType(AdvantageFramework.Database.Entities.VendorServiceTax) OrElse
								_ObjectType Is GetType(AdvantageFramework.Database.Classes.Function) Then

							If Me.IsNewItemOrAutoFilterRow() = False Then

								Me.FocusedColumn = Me.GetNearestCanFocusedColumn(Column)

							End If

						ElseIf _ObjectType Is GetType(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) Then

							Me.FocusedColumn = Me.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Description.ToString)

                        End If

                    ElseIf Column.FieldName = "Number" Then

                        If _ObjectType Is GetType(AdvantageFramework.Database.Entities.Account) OrElse
                            _ObjectType Is GetType(AdvantageFramework.Database.Entities.Ad) Then

                            If Me.IsNewItemOrAutoFilterRow() = False Then

                                Me.FocusedColumn = Me.GetNearestCanFocusedColumn(Column)

                            End If

                        ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.BillingRateLevel) Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsClientIncluded.ToString)

                        End If

                    ElseIf Column.FieldName = "FieldName" Then

                        If _ObjectType Is GetType(AdvantageFramework.Database.Entities.GeneralDescription) Then

                            If Me.IsNewItemOrAutoFilterRow() = False Then

                                Me.FocusedColumn = Me.GetNearestCanFocusedColumn(Column)

                            End If

                        End If

                    ElseIf Column.FieldName = "FunctionCode" Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If _ObjectType Is GetType(AdvantageFramework.Database.Entities.EstimateTemplateDetail) Then

                                Me.FocusedColumn = Me.GetNearestCanFocusedColumn(Column)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ExpenseReportDetail) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.Quantity.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount.Properties.ProductionSalesGLACode.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.OfficeFunctionAccount) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.OfficeFunctionAccount.Properties.ProductionSalesGLACode.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem) AndAlso
                                    GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobNumber.ToString) Is Nothing Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.GLACode.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.QuantityHours.ToString)

                            End If

                        End If

                        If _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) AndAlso
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PONumber.ToString) IsNot Nothing AndAlso
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PODetailLineNumber.ToString) IsNot Nothing Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.FunctionCode.ToString)

                        End If

                    ElseIf Column.FieldName = "ClientCode" Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If _ObjectType Is GetType(AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.DistributeViaEmail.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.DistributeViaEmail.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ExpenseReportDetail) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.Quantity.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Media.Classes.ImportOrder) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Media.Classes.ImportOrder.Properties.OrderID.ToString)

                            End If

                        End If

                        If _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) AndAlso
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PONumber.ToString) IsNot Nothing AndAlso
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PODetailLineNumber.ToString) IsNot Nothing Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.FunctionCode.ToString)

                        End If

                    ElseIf Column.FieldName = "DivisionCode" Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If _ObjectType Is GetType(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.DistributeViaEmail.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ExpenseReportDetail) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.Quantity.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Media.Classes.ImportOrder) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Media.Classes.ImportOrder.Properties.OrderID.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.CollectionNote.ToString)

                            End If

                        End If

                        If _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) AndAlso
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PONumber.ToString) IsNot Nothing AndAlso
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PODetailLineNumber.ToString) IsNot Nothing Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.FunctionCode.ToString)

                        End If

                    ElseIf Column.FieldName = "ProductCode" Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If _ObjectType Is GetType(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.DistributeViaEmail.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ExpenseReportDetail) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.Quantity.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Media.Classes.ImportOrder) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Media.Classes.ImportOrder.Properties.OrderID.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.CollectionNote.ToString)

                            End If

                        End If

                        If _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) AndAlso
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PONumber.ToString) IsNot Nothing AndAlso
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PODetailLineNumber.ToString) IsNot Nothing Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.FunctionCode.ToString)

                        End If

                    ElseIf Column.FieldName = "ClientContactID" Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If _ObjectType Is GetType(AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.DistributeViaEmail.ToString)

                            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.DistributeViaEmail.ToString)

                            End If

                        End If

                    ElseIf Column.FieldName = "WebsiteTypeCode" Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If _ObjectType Is GetType(AdvantageFramework.Database.Entities.ClientWebsite) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.ClientWebsite.Properties.WebsiteAddress.ToString)

                            End If

                        End If

                    ElseIf Column.FieldName = "DepartmentTeamCode" Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If _ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeDepartmentTeam) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.EmployeeDepartmentTeam.Properties.Default.ToString)

                            End If

                        End If

                    ElseIf Column.FieldName = "TaxCode" Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If _ObjectType Is GetType(AdvantageFramework.Database.Entities.SalesTax) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.SalesTax.Properties.Description.ToString)

                            End If

                        End If

                    ElseIf Column.FieldName = "AlertGroupCode" Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If _ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeAlertGroup) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.EmployeeAlertGroup.Properties.IncludeOnSchedule.ToString)

                            End If

                        End If

                    ElseIf Column.FieldName = "RoleCode" Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If _ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeRole) Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.EmployeeRole.Properties.Default.ToString)

                            End If

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Media.Classes.ImportOrder) AndAlso
                                Column.FieldName <> AdvantageFramework.Media.Classes.ImportOrder.Properties.OrderID.ToString AndAlso
                                Column.FieldName <> AdvantageFramework.Media.Classes.ImportOrder.Properties.LineNumber.ToString Then

                        If (Me.GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaType.ToString) = "I" OrElse
                                Me.GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaType.ToString) = "N") AndAlso
                                Column.FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.CostType.ToString AndAlso
                                Me.GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.Media.Classes.ImportOrder.Properties.ImportSource.ToString) <> AdvantageFramework.Media.ImportSource.MediaPlanning Then

                            Me.FocusedColumn = Column

                        Else

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Media.Classes.ImportOrder.Properties.OrderID.ToString)

                        End If

                    ElseIf Column.FieldName = AdvantageFramework.Database.Classes.ContractValueAdded.Properties.HasDocument.ToString AndAlso
                        _ObjectType Is GetType(AdvantageFramework.Database.Classes.ContractValueAdded) Then

                        Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ContractValueAdded.Properties.Amount.ToString)

                    ElseIf Column.FieldName = AdvantageFramework.Database.Classes.ContractReportDetail.Properties.HasDocuments.ToString AndAlso
                        _ObjectType Is GetType(AdvantageFramework.Database.Classes.ContractReportDetail) Then

                        Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ContractReportDetail.Properties.SendAlertUponCompletion.ToString)

                    ElseIf (Column.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.Number.ToString OrElse
                            Column.FieldName = AdvantageFramework.Database.Entities.BillingRateLevel.Properties.Description.ToString) AndAlso
                            _ObjectType Is GetType(AdvantageFramework.Database.Entities.BillingRateLevel) Then

                        Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.BillingRateLevel.Properties.IsClientIncluded.ToString)

                    ElseIf Column.FieldName = AdvantageFramework.Database.Entities.Function.Properties.BillingRate.ToString AndAlso
                            _ObjectType Is GetType(AdvantageFramework.Database.Entities.Function) Then

                        Me.FocusedColumn = Me.GetNearestCanFocusedColumn(Column)

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ExpenseReportDetail) Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If Column.FieldName = "JobNumber" OrElse Column.FieldName = "JobComponentNumber" Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.ExpenseReportDetail.Properties.Quantity.ToString)

                            End If

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionType.ToString Then

                            Try

                                Me.FocusedColumn = Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(GridCol) GridCol.VisibleIndex > Column.VisibleIndex).OrderBy(Function(GridCol) GridCol.VisibleIndex).FirstOrDefault

                            Catch ex As Exception
                                Me.FocusedColumn = Column
                            End Try

                        ElseIf Column.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.CurrentEmployeeTitleID.ToString Then

                            Try

                                Me.FocusedColumn = Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(GridCol) GridCol.VisibleIndex > Column.VisibleIndex).OrderBy(Function(GridCol) GridCol.VisibleIndex).FirstOrDefault

                            Catch ex As Exception
                                Me.FocusedColumn = Column
                            End Try

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Views.BillingRateDetailView) Then

                        If Column.FieldName = AdvantageFramework.Database.Views.BillingRateDetailView.Properties.FunctionType.ToString Then

                            Try

                                Me.FocusedColumn = Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(GridCol) GridCol.VisibleIndex > Column.VisibleIndex).OrderBy(Function(GridCol) GridCol.VisibleIndex).FirstOrDefault

                            Catch ex As Exception
                                Me.FocusedColumn = Column
                            End Try

                        ElseIf Column.FieldName = AdvantageFramework.Database.Views.BillingRateDetailView.Properties.EmployeeTitleID.ToString Then

                            Try

                                Me.FocusedColumn = Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(GridCol) GridCol.VisibleIndex > Column.VisibleIndex).OrderBy(Function(GridCol) GridCol.VisibleIndex).FirstOrDefault

                            Catch ex As Exception
                                Me.FocusedColumn = Column
                            End Try

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.OverheadAccountDetail) Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToGLACode.ToString)

                        Else

                            If Column.FieldName = AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromDescription.ToString Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToGLACode.ToString)

                            ElseIf Column.FieldName = AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToDescription.ToString Then

                                Me.FocusedColumn = Me.GetNearestCanFocusedColumn(Column)

                            End If

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee) Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.IsInactive.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.Order.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.IsInactive.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail) Then

                        If Me.IsNewItemOrAutoFilterRow() = False AndAlso Column.FieldName.StartsWith(AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName.ToString) Then

                            If Me.GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.SequenceNumber.ToString) <> 0 Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.IsInactive.ToString)

                            End If

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.OfficeInterCompanyDetail) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.Code.ToString OrElse
                            Column.FieldName = AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.GeneralLedgerCrossReferenceCode.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.DueFromGLACode.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.OfficeSalesTaxAccount) Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            If Column.FieldName = AdvantageFramework.Database.Entities.OfficeSalesTaxAccount.Properties.SalesTaxCode.ToString Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.OfficeSalesTaxAccount.Properties.StateTaxGLACode.ToString)

                            End If

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail) Then

                        If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.GLADescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.Amount.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail) Then

                        If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.POAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.POBalance.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.Comment.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.POComplete.ToString Then

                            If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.PODetailLineNumber.ToString) Is Nothing Then

                                If Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.OfficeCode.ToString).Visible Then

                                    Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.OfficeCode.ToString)

                                Else

                                    Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.GLACode.ToString)

                                End If

                            End If

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.GLADescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.Amount.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) Then

                        If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PONumber.ToString) IsNot Nothing AndAlso
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PODetailLineNumber.ToString) IsNot Nothing Then

                            If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ClientCode.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.DivisionCode.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ProductCode.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.JobNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.JobDescription.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.JobComponentNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.JobCompDescription.ToString Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.FunctionCode.ToString)

                            End If

                        ElseIf GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PONumber.ToString) Is Nothing AndAlso
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.POComplete.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ClientCode.ToString)

                        End If

                        If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.LineTotal.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.Disbursed.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.POAmount.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.POBalance.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.IsNonBillable.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.OfficeCode.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.GLACode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ResaleTax.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.CommissionPercent.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ExtendedNonResaleTax.ToString AndAlso
                                (GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.SalesTaxCode.ToString) Is Nothing OrElse
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.IsResaleTax.ToString) = 1) Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.CommissionPercent.ToString)

                        ElseIf (Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.GLACode.ToString AndAlso
                                    GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.IsNonBillable.ToString) = 0) OrElse
                                    Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.GLADescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.Comment.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.JobDescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.JobComponentNumber.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.JobCompDescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.FunctionCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.IsResaleTax.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ExtendedNonResaleTax.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail) Then

                        If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.InsertionDate.ToString Then

                            If Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.GrossAmount.ToString).Visible Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.GrossAmount.ToString)

                            Else

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.NetAmount.ToString)

                            End If

                        ElseIf GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.SalesTaxCode.ToString) Is Nothing AndAlso
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.VendorTax.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.DisbursedAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.PreviouslyPosted.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.OrderNetAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.OrderNetBalance.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.OfficeCode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.GLACode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.Status.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.Comments.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.NewApprovalStatus.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail) Then

                        If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.InsertionDate.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.CostType.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.PrintLines.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.PrintLines.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.Rate.ToString Then

                            If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.CostTypeFromOrderDetail.ToString) = "CPI" OrElse
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.CostTypeFromOrderDetail.ToString) = "NA" Then

                                If Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.GrossAmount.ToString).Visible Then

                                    Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.GrossAmount.ToString)

                                Else

                                    Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.NetAmount.ToString)

                                End If

                            End If

                        ElseIf GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.SalesTaxCode.ToString) Is Nothing AndAlso
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.VendorTax.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.DisbursedAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.PreviouslyPosted.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.OrderNetAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.OrderNetBalance.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.OfficeCode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.GLACode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.Status.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.Comments.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.NewApprovalStatus.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail) Then

                        If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.StartDate.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.EndDate.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.CostType.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.Impressions.ToString)

                        ElseIf GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.SalesTaxCode.ToString) Is Nothing AndAlso
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.VendorTax.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.DisbursedAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.PreviouslyPosted.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.OrderNetBalance.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.OrderNetAmount.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.OfficeCode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.Status.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.Comments.ToString OrElse
                                                        Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.GLACode.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.NewApprovalStatus.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail) Then

                        If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.PostDate.ToString Then

                            If Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.GrossAmount.ToString).Visible Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.GrossAmount.ToString)

                            Else

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.NetAmount.ToString)

                            End If

                        ElseIf GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.SalesTaxCode.ToString) Is Nothing AndAlso
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.VendorTax.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.DisbursedAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.PreviouslyPosted.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.OrderNetAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.OrderNetBalance.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.OfficeCode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.GLACode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.Status.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.Comments.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.NewApprovalStatus.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail) Then

                        If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.RewriteFlag.ToString) = 1 Then

                            If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderDate.ToString Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.TotalSpots.ToString)

                            ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.BroadcastMonth.ToString OrElse
                                    Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.BroadcastYear.ToString Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderNumber.ToString)

                            End If

                        Else

                            If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderLineNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.TotalSpots.ToString Then

                                If Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.GrossAmount.ToString).Visible Then

                                    Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.GrossAmount.ToString)

                                Else

                                    Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.ExtendedNetAmount.ToString)

                                End If

                            ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.NewApprovalStatus.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.NewApprovalComments.ToString Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.SalesTaxCode.ToString)

                            End If

                        End If

                        If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.SalesTaxCode.ToString) Is Nothing AndAlso
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.VendorTax.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.DisbursedAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.PreviouslyPosted.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderNetAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderNetBalance.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OfficeCode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.GLACode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.Status.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.Comments.ToString Then

                            If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.RewriteFlag.ToString) = 1 Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.NewApprovalStatus.ToString)

                            Else

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.SalesTaxCode.ToString)

                            End If

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail) Then

                        If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.RewriteFlag.ToString) = 1 Then

                            If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderDate.ToString Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.TotalSpots.ToString)

                            ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.BroadcastMonth.ToString OrElse
                                    Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.BroadcastYear.ToString Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderNumber.ToString)

                            End If

                        Else

                            If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderLineNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.TotalSpots.ToString Then

                                If Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.GrossAmount.ToString).Visible Then

                                    Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.GrossAmount.ToString)

                                Else

                                    Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.ExtendedNetAmount.ToString)

                                End If

                            ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.NewApprovalStatus.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.NewApprovalComments.ToString Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.SalesTaxCode.ToString)

                            End If

                        End If

                        If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.SalesTaxCode.ToString) Is Nothing AndAlso
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.VendorTax.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.DisbursedAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.PreviouslyPosted.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderNetAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderNetBalance.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OfficeCode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.GLACode.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.Status.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.Comments.ToString Then

                            If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.RewriteFlag.ToString) = 1 Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.NewApprovalStatus.ToString)

                            Else

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.SalesTaxCode.ToString)

                            End If

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.JobTemplateDetail) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.JobTemplateDetail.Properties.OriginalLabel.ToString Then

                            Try

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.JobTemplateDetail.Properties.Label.ToString)

                            Catch ex As Exception
                                Me.FocusedColumn = Column
                            End Try

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.JobSpecificationField) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.JobSpecificationField.Properties.FieldDataType.ToString Then

                            Try

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.JobSpecificationField.Properties.SeparatorLine.ToString)

                            Catch ex As Exception
                                Me.FocusedColumn = Column
                            End Try

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur) Then

                        If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.InvoiceAmount.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.NumberRemaining.ToString OrElse
                            Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.UnlimitedPostings.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.CreateAP.ToString)

                        ElseIf Column.FieldName <> AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.InvoiceNumber.ToString AndAlso
                            Column.FieldName <> AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.CreateAP.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.InvoiceNumber.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.PartnerAllocationDetail) Then

                        If Column.FieldName = AdvantageFramework.Database.Entities.PartnerAllocationDetail.Properties.PartnerCode.ToString Then

                            If Me.IsNewItemOrAutoFilterRow() = False Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.PartnerAllocationDetail.Properties.PercentAllocation.ToString)

                            End If

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingCoop) Then

                        If Column.FieldName <> AdvantageFramework.Database.Classes.BillingCoop.Properties.Percent.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.BillingCoop.Properties.Percent.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.ExpenseReportItem) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobDescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobComponentRowID.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobComponentDescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.FunctionCode.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging) Then

                        If Column.FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.AccountNumber.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.EmployeeCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.EmployeeFirstName.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.EmployeeLastName.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.ExpenseReportDate.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.ContractFeeItem) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.ContractFeeItem.Properties.ServiceFeeTypeID.ToString And Not IsNewItemOrAutoFilterRow() OrElse
                            Column.FieldName = AdvantageFramework.Database.Classes.ContractFeeItem.Properties.ServiceFeeDescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Hours.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ContractContact) Then

                        If Column.FieldName = AdvantageFramework.Database.Entities.ContractContact.Properties.EmployeeCode.ToString And Not IsNewItemOrAutoFilterRow() Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.ContractContact.Properties.IncludeInAlert.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.TimeCategoryType) Then

                        If Column.FieldName = AdvantageFramework.Database.Entities.TimeCategoryType.Properties.DefaultUse.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.TimeCategoryType.Properties.Description.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.MyObjectDefinition) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.MyObjectDefinition.Properties.DefinitionDescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.MyObjectDefinition.Properties.Checked.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.Code.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.OfficeCode.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.Code.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.DepartmentCode.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ClientCrossReference) Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.ClientCrossReference.Properties.ClientCode.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.GeneralLedgerCrossReference) Then

                        If Me.IsNewItemOrAutoFilterRow() = False Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Entities.GeneralLedgerCrossReference.Properties.GLACode.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.GLATrailer) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.GLATrailer.Properties.GLADescription.ToString OrElse
                            Column.FieldName = AdvantageFramework.Database.Classes.GLATrailer.Properties.CDPRequired.ToString Then

                            Try

                                If Me.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltValue.ToString).Visible Then

                                    Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltValue.ToString)

                                Else

                                    Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString)

                                End If

                            Catch ex As Exception

                            End Try

                        ElseIf Column.FieldName = AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltCode.ToString Then

                            If Me.IsNewItemOrAutoFilterRow() = False Then

                                Try

                                    If Me.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltValue.ToString).Visible Then

                                        Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltValue.ToString)

                                    Else

                                        Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString)

                                    End If

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.PurchaseOrderDetail) Then

                        If Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineNumber.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineDescription.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.CommissionPercent.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ExtendedMarkupAmount.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.LineTotal.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsComplete.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.BalanceNet.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.EstimateBudgetNet.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.POUsed.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsAttachedToAP.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ClientName.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.DivisionName.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.ProductDescription.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobDescription.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.JobComponentDescription.ToString OrElse
                                Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.FunctionDescription.ToString Then

                            Column.OptionsColumn.AllowFocus = False

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) Then

                        If Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.ARInvoiceNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.ARInvoiceSequenceNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.ARDescription.ToString OrElse
                                Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.Category.ToString OrElse
                                Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.InvoiceDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.CurrentBalance.ToString OrElse
                                Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.OriginalInvoiceAmount.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.PaymentAmount.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.GLACodeAdjustmentDescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.AdjustmentAmount.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.OfficeCode.ToString OrElse
                                Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.SalesClassCode.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.CollectionNote.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoice) Then

                        If Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.InvoiceNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.SequenceNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.Description.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.Category.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.InvoiceDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.IsVoided.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.IsManualInvoice.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.DueDate.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.Amount.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.AmountPaid.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.BalanceDue.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.DaysPast.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.CollectionNotes.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) Then

                        If Me.IsNewItemOrAutoFilterRow() = False AndAlso (Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.GeneralLedgerOfficeCrossReferenceCode.ToString OrElse
                                Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.BaseCode.ToString OrElse
                                Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.DepartmentCode.ToString OrElse
                                Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.OtherCode.ToString OrElse
                                Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Code.ToString) Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Description.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Code.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Description.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Payroll.ToString AndAlso
                                GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Type.ToString) <> AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.ExpenseOperating Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.PurchaseOrder.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.EnteredDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.ModifiedDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.UserCode.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.IsInactive.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem) Then

                        If Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.Status.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.Delete.ToString)

                        ElseIf GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.IsSystemGenerated.ToString) = True AndAlso
                                (Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobNumber.ToString OrElse
                                 Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobComponentNumber.ToString) Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.GLACode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.ItemDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.APComment.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.InvoiceTotalNet.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.EmployeeOfficeCode.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.DepartmentCode.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.ClientName.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobNumber.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.Quantity.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.Rate.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.Amount.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.GLACode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.GLACodeDescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.HasDocuments.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoice) Then

                        If Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.InvoiceNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.SequenceNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.RecType.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.Description.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.Category.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.InvoiceDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.IsManualInvoice.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.DueDate.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.Amount.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.AmountPaid.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.BalanceDue.ToString OrElse
                                Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.DaysPast.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.CollectionNotes.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) Then

                        If Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.EmployeeTimeID.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.EmployeeTimeDetailID.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.EmployeeName.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.EmployeeDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Hours.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.BillableRate.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TotalBill.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CommissionPercentage.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.Total.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.LineTotal.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxStatePercentage.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCountyPercentage.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCityPercentage.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TaxCommission.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.TaxCommissionOnly.ToString Then

                            If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCode.ToString) IsNot Nothing Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.StateResaleAmount.ToString)

                            Else

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString)

                            End If

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.StateResaleAmount.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CountyResaleAmount.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CityResaleAmount.ToString Then

                            If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCode.ToString) Is Nothing Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString)

                            End If

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.ResaleTax.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.IsNonBillable.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) Then

                        If Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.VendorName.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.InvoiceDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.InvoiceNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedAmount.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.LineNumber.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Quantity.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Rate.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CommissionPercent.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.Total.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.StateTaxPercent.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CountyTaxPercent.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CityTaxPercent.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.TaxCommissions.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.TaxCommissionsOnly.ToString Then

                            If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.SalesTaxCode.ToString) IsNot Nothing Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedStateResale.ToString)

                            Else

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsBillOnHold.ToString)

                            End If

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedStateResale.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCountyResale.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCityResale.ToString Then

                            If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.SalesTaxCode.ToString) Is Nothing Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsBillOnHold.ToString)

                            End If

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ResaleTax.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedNonResaleTax.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.LineTotal.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsNonBillable.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsBillOnHold.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) Then

                        If Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.SequenceNumber.ToString OrElse
                            Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.InvoiceDate.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.InvoiceNumber.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Quantity.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Rate.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Total.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.SalesTaxCode.ToString)

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateTaxPercent.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyTaxPercent.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityTaxPercent.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.TaxCommission.ToString OrElse
                                    Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.TaxCommissionOnly.ToString Then

                            If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.SalesTaxCode.ToString) IsNot Nothing Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateResaleTaxAmount.ToString)

                            Else

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsBillOnHold.ToString)

                            End If

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateResaleTaxAmount.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyResaleTaxAmount.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityResaleTaxAmount.ToString Then

                            If GetRowCellValue(Me.FocusedRowHandle, AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.SalesTaxCode.ToString) Is Nothing Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsBillOnHold.ToString)

                            End If

                        ElseIf Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.TotalTax.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.LineTotal.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsNonBillable.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.IsBillOnHold.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.IncomeOnly.Classes.IncomeOnly) Then

                        If Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ID.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.BillingUser.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.IsBilled.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.NonBillable.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientName.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionName.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductName.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobDescription.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentDescription.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionDescription.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Taxes.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.IsServiceFee.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.SequenceNumber.ToString OrElse
                            Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.TotalAmount.ToString Then

                            Column.OptionsColumn.AllowFocus = False

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) Then

                        If Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ID.ToString Then

                            If Me.IsNewItemOrAutoFilterRow() Then

                                Me.FocusedColumn = Me.Columns(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeDescription.ToString)

                            End If

                        ElseIf Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.MaxAmount.ToString Then

                            Column.OptionsColumn.AllowFocus = False

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail) Then

                        If Column.FieldName = AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail.Properties.GLACodeDescription.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail.Properties.Amount.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) Then

                        If Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionDescription.ToString OrElse
                                Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionType.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.QuantityHours.ToString)

                        End If

                    ElseIf _ObjectType Is GetType(AdvantageFramework.AvaTax.Classes.OfficeCompanyCode) Then

                        If Column.FieldName = AdvantageFramework.AvaTax.Classes.OfficeCompanyCode.Properties.OfficeCode.ToString Then

                            Me.FocusedColumn = Me.Columns(AdvantageFramework.AvaTax.Classes.OfficeCompanyCode.Properties.AvaTaxCompanyCode.ToString)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub SetCustomRowCellEdit(ByVal RowHandle As Integer)

            If _ControlType = BandedDataGridView.Type.EditableGrid Then

                _UpdatingFilterData = True

                If _ObjectType Is GetType(AdvantageFramework.Database.Entities.Account) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Account).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 1)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Status) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Status).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.SalesTax) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If Me.Columns("IsInactive") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.SalesTax).IsInactive Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                            End If

                        End If

                        If Me.Columns("Resale") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.SalesTax).Resale Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("Resale"), 0)

                            End If

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ProductCategory) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.ProductCategory).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.InvoiceCategory) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.InvoiceCategory).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.IndirectCategory) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.IndirectCategory).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.InvoiceCategory) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.InvoiceCategory).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.DepartmentTeam) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.DepartmentTeam).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.VendorTerm) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.VendorTerm).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.EmployeeCategory) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.EmployeeCategory).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.EmployeeTitle) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.EmployeeTitle).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.FunctionHeading) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.FunctionHeading).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.FiscalPeriod) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.FiscalPeriod).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.AdSize) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.AdSize).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Market) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Market).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.AlertGroup) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.AlertGroup).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.EstimateTemplate) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.EstimateTemplate).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Complexity) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsActive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Complexity).IsActive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsActive"), 1)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.PrintSpecRegion) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsActive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.PrintSpecRegion).IsActive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsActive"), 1)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.PromotionType) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsActive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.PromotionType).IsActive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsActive"), 1)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.PrintSpecStatus) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsActive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.PrintSpecStatus).IsActive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsActive"), 1)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Destination) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Destination).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Blackplate) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Blackplate).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobType) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobType).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ResourceType) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.ResourceType).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.SalesClass) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.SalesClass).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Task) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Task).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.AdSizeLabel) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.AdSizeLabel).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobUserDefinedValue1) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobUserDefinedValue1).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobUserDefinedValue2) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobUserDefinedValue2).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobUserDefinedValue3) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobUserDefinedValue3).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobUserDefinedValue4) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobUserDefinedValue4).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobUserDefinedValue5) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.JobUserDefinedValue5).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeAlertGroup) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IncludeOnSchedule") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Classes.EmployeeAlertGroup).IncludeOnSchedule Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IncludeOnSchedule"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.SalesClassFormat) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.SalesClassFormat).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 1)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Ad) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Ad).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 1)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.BillingRateLevel) Then

                    If Me.GetRow(RowHandle) IsNot Nothing Then

                        If Me.Columns("IsClientIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsClientIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsClientIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsDivisionIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsDivisionIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsDivisionIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsProductIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsProductIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsProductIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsSalesClassIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsSalesClassIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsSalesClassIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsFunctionIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsFunctionIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsFunctionIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsEmployeeTitleIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsEmployeeTitleIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsEmployeeTitleIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsEmployeeIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsEmployeeIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsEmployeeIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsEffectiveDateIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsEffectiveDateIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsEffectiveDateIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsBillingRateDetailIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsBillingRateDetailIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsBillingRateDetailIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsNonBillableIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsNonBillableIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsNonBillableIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsCommissionIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsCommissionIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsCommissionIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsTaxIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsTaxIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsTaxIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsTaxCommissionIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsTaxCommissionIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsTaxCommissionIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsFeeTimeIncluded") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsFeeTimeIncluded Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsFeeTimeIncluded"), 0)

                            End If

                        End If

                        If Me.Columns("IsInactive") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.BillingRateLevel).IsInactive Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                            End If

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Function) Then

                    If Me.GetRow(RowHandle) IsNot Nothing Then

                        If Me.Columns("CPMFlag") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Function).CPMFlag Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("CPMFlag"), 0)

                            End If

                        End If

                        If Me.Columns("EmployeeExpenseFlag") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Function).EmployeeExpenseFlag Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("EmployeeExpenseFlag"), 0)

                            End If

                        End If

                        If Me.Columns("IsInactive") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Function).IsInactive Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                            End If

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.Function) Then

                    If Me.GetRow(RowHandle) IsNot Nothing Then

                        If Me.Columns("CPMFlag") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Classes.Function).CPMFlag Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("CPMFlag"), 0)

                            End If

                        End If

                        If Me.Columns("EmployeeExpenseFlag") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Classes.Function).EmployeeExpenseFlag Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("EmployeeExpenseFlag"), 0)

                            End If

                        End If

                        If Me.Columns("IsInactive") IsNot Nothing Then

                            If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Classes.Function).IsInactive Is Nothing Then

                                Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                            End If

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.ImportVendorStaging) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("ActiveFlag") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.ImportVendorStaging).ActiveFlag Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("ActiveFlag"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Classes.BillingRateDetail).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.DestinationContact) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.DestinationContact).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Cycle) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns("IsInactive") IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Entities.Cycle).IsInactive Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsInactive"), 0)

                        End If

                    End If

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.PurchaseOrderDetail) Then

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsAttachedToAP.ToString) IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Classes.PurchaseOrderDetail).IsAttachedToAP Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsAttachedToAP"), 0)

                        End If

                    End If

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.UseCPM.ToString) IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Classes.PurchaseOrderDetail).UseCPM Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("UseCPM"), 0)

                        End If

                    End If

                    If Me.GetRow(RowHandle) IsNot Nothing AndAlso Me.Columns(AdvantageFramework.Database.Classes.PurchaseOrderDetail.Properties.IsComplete.ToString) IsNot Nothing Then

                        If DirectCast(Me.GetRow(RowHandle), AdvantageFramework.Database.Classes.PurchaseOrderDetail).IsComplete Is Nothing Then

                            Me.SetRowCellValue(RowHandle, Me.Columns("IsComplete"), 0)

                        End If

                    End If

                End If

                _UpdatingFilterData = False

            End If

        End Sub
        Public Sub CloseEditorForUpdating()

            Me.CloseEditor()

            Me.CancelNewItemRow()

        End Sub
        Public Sub CancelNewItemRow()

            If Me.IsNewItemRow(Me.FocusedRowHandle) Then

                Me.DeleteRow(Me.FocusedRowHandle)

                Me.RefreshData()

                Me.MoveFirst()

            End If

            Me.NewItemRowText = ""

        End Sub
        Protected Sub ModifyBehaviorOptions()

            Select Case _ControlType

                Case BandedDataGridView.Type.Default, BandedDataGridView.Type.DynamicReport, BandedDataGridView.Type.NonEditableGrid

                    Me.OptionsBehavior.AutoPopulateColumns = True

                    Me.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
                    Me.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
                    Me.OptionsBehavior.Editable = False

                Case BandedDataGridView.Type.DatabaseProfile

                    Me.OptionsBehavior.AutoPopulateColumns = False

                    Me.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
                    Me.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
                    Me.OptionsBehavior.Editable = True

                Case BandedDataGridView.Type.EditableGrid

                    Me.OptionsBehavior.AutoPopulateColumns = True

                    Me.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
                    Me.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
                    Me.OptionsBehavior.Editable = True

            End Select

        End Sub
        Protected Sub ModifyViewOptions()

            Select Case _ControlType

                Case BandedDataGridView.Type.Default, BandedDataGridView.Type.DatabaseProfile, BandedDataGridView.Type.DynamicReport, BandedDataGridView.Type.EditableGrid, BandedDataGridView.Type.NonEditableGrid

                    Me.OptionsView.ColumnAutoWidth = False
                    Me.OptionsView.ShowFooter = False
                    Me.OptionsView.ShowGroupPanel = False
                    Me.OptionsView.ShowViewCaption = True

            End Select

        End Sub
        Protected Sub ModifySelectionOptions()

            Select Case _ControlType

                Case BandedDataGridView.Type.Default, BandedDataGridView.Type.DatabaseProfile, BandedDataGridView.Type.DynamicReport, BandedDataGridView.Type.EditableGrid, BandedDataGridView.Type.NonEditableGrid

                    Me.OptionsSelection.MultiSelect = True

            End Select

        End Sub
        Protected Sub ModifyCustomizationOptions()

            Select Case _ControlType

                Case BandedDataGridView.Type.Default, BandedDataGridView.Type.DatabaseProfile, BandedDataGridView.Type.NonEditableGrid

                    Me.OptionsCustomization.AllowGroup = True
                    Me.OptionsCustomization.AllowSort = True
                    Me.OptionsCustomization.AllowFilter = True
                    Me.OptionsCustomization.AllowColumnMoving = True
                    Me.OptionsCustomization.AllowQuickHideColumns = False

                Case BandedDataGridView.Type.EditableGrid

                    Me.OptionsCustomization.AllowGroup = False
                    Me.OptionsCustomization.AllowSort = True
                    Me.OptionsCustomization.AllowFilter = True
                    Me.OptionsCustomization.AllowColumnMoving = False
                    Me.OptionsCustomization.AllowQuickHideColumns = False

                Case BandedDataGridView.Type.DynamicReport

                    Me.OptionsCustomization.AllowGroup = True
                    Me.OptionsCustomization.AllowSort = True
                    Me.OptionsCustomization.AllowFilter = True
                    Me.OptionsCustomization.AllowColumnMoving = True
                    Me.OptionsCustomization.AllowQuickHideColumns = True

            End Select

        End Sub
        Protected Sub ModifyMenuOptions()

            Select Case _ControlType

                Case BandedDataGridView.Type.Default, BandedDataGridView.Type.DatabaseProfile, BandedDataGridView.Type.NonEditableGrid

                    Me.OptionsMenu.ShowGroupSummaryEditorItem = False
                    Me.OptionsMenu.EnableColumnMenu = True

                Case BandedDataGridView.Type.DynamicReport

                    Me.OptionsMenu.ShowGroupSummaryEditorItem = True
                    Me.OptionsMenu.EnableColumnMenu = True

                Case BandedDataGridView.Type.EditableGrid

                    Me.OptionsMenu.ShowGroupSummaryEditorItem = False
                    Me.OptionsMenu.EnableColumnMenu = False

            End Select

        End Sub
        Protected Sub ModifyNavigationOptions()

            Select Case _ControlType

                Case BandedDataGridView.Type.Default, BandedDataGridView.Type.DatabaseProfile, BandedDataGridView.Type.NonEditableGrid, BandedDataGridView.Type.DynamicReport

                    Me.OptionsNavigation.EnterMoveNextColumn = False

                Case BandedDataGridView.Type.EditableGrid

                    Me.OptionsNavigation.EnterMoveNextColumn = True

            End Select

        End Sub
        Protected Sub ModifyFilterOptions()

            Select Case _ControlType

                Case BandedDataGridView.Type.Default, BandedDataGridView.Type.DatabaseProfile, BandedDataGridView.Type.EditableGrid, BandedDataGridView.Type.NonEditableGrid

                    Me.OptionsFilter.ShowAllTableValuesInFilterPopup = False

                Case BandedDataGridView.Type.DynamicReport

                    Me.OptionsFilter.ShowAllTableValuesInFilterPopup = True

            End Select

        End Sub
        Protected Sub ModifyLayoutOptions()

            Select Case _ControlType

                Case BandedDataGridView.Type.Default, BandedDataGridView.Type.DatabaseProfile, BandedDataGridView.Type.EditableGrid, BandedDataGridView.Type.NonEditableGrid

                    Me.OptionsLayout.StoreAllOptions = False
                    Me.OptionsLayout.StoreAppearance = False
                    Me.OptionsLayout.Columns.StoreAllOptions = False
                    Me.OptionsLayout.Columns.StoreAppearance = False

                Case BandedDataGridView.Type.DynamicReport

                    Me.OptionsLayout.StoreAllOptions = True
                    Me.OptionsLayout.StoreAppearance = True
                    Me.OptionsLayout.Columns.StoreAllOptions = True
                    Me.OptionsLayout.Columns.StoreAppearance = True

            End Select

        End Sub
        Protected Sub SetupGridViewControl()

            Me.Columns.Clear()

            ModifyBehaviorOptions()
            ModifyCustomizationOptions()
            ModifyFilterOptions()
            ModifyLayoutOptions()
            ModifyMenuOptions()
            ModifySelectionOptions()
            ModifyViewOptions()
            ModifyNavigationOptions()

        End Sub
        Protected Overrides Sub DoMoveFocusedRow(delta As Integer, e As Windows.Forms.KeyEventArgs)

            If e.KeyCode = Windows.Forms.Keys.None Then

                e.Handled = True

            Else

                MyBase.DoMoveFocusedRow(delta, e)

            End If

        End Sub
        'Protected Overrides Sub DoMoveFocusedRow(ByVal delta As Integer, ByVal byKey As System.Windows.Forms.Keys, ByVal e As System.Windows.Forms.KeyEventArgs)

        '    If byKey = Windows.Forms.Keys.None Then

        '        e.Handled = True

        '    Else

        '        MyBase.DoMoveFocusedRow(delta, byKey, e)

        '    End If

        'End Sub
        Public Sub CreateColumnsBasedOnObjectType()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            Me.Columns.Clear()

            For Each PropertyDescriptor In _ObjectTypePropertyDescriptors

                If PropertyDescriptor.IsBrowsable Then

                    Me.Columns.AddField(PropertyDescriptor.Name)

                End If

            Next

        End Sub
        Public Sub CreateColumnsBasedOnObjectType(ByVal AddRepositoryItems As Boolean)

            CreateColumnsBasedOnObjectType()

            If AddRepositoryItems Then

                Me.RaiseDataSourceChanged()

            End If

        End Sub
        Public Sub GridViewSelectionChanged()

            If Me.IsMultiSelect Then

                RaiseSelectionChanged(New DevExpress.Data.SelectionChangedEventArgs(System.ComponentModel.CollectionChangeAction.Refresh, Me.FocusedRowHandle))

            Else

                RaiseFocusedRowChanged(Me.PrevTopRowIndex, Me.FocusedRowHandle)

            End If

        End Sub
        Public Overrides Sub RefreshData()

            'objects
            Dim FocusedRowHandle As Integer = 0

            FocusedRowHandle = Me.FocusedRowHandle

            MyBase.RefreshData()

            If Me.IsValidRowHandle(FocusedRowHandle) = False Then

                FocusedRowHandle = 0

            End If

            If Me.IsValidRowHandle(FocusedRowHandle) AndAlso Me.SelectedRowsCount = 0 Then

                If Me.RowCount > 0 Then

                    Me.FocusedRowHandle = FocusedRowHandle
                    Me.SelectRow(FocusedRowHandle)

                    If Me.FocusedColumn IsNot Nothing Then

                        Me.SelectCell(FocusedRowHandle, Me.FocusedColumn)

                    End If

                End If

            End If

        End Sub
        Private Function GetRowCellValueByPropertyType(ByVal RowHandle As Integer, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes) As Object

            'objects
            Dim RowCellValue As Object = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim NonNullableType As System.Type = Nothing

            Try

                PropertyDescriptor = (From [Property] In _ObjectTypePropertyDescriptors
                                      Where [Property].Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Where(Function(Attribute) Attribute.PropertyType = PropertyType).Any
                                      Select [Property]).SingleOrDefault

                If PropertyDescriptor IsNot Nothing Then

                    If Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

                        NonNullableType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

                    Else

                        NonNullableType = PropertyDescriptor.PropertyType

                    End If

                    Try

                        If Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name) IsNot Nothing Then

                            RowCellValue = Convert.ChangeType(Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name), NonNullableType)

                        Else

                            RowCellValue = Nothing

                        End If

                    Catch ex As Exception
                        RowCellValue = Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name)
                    End Try

                End If

            Catch ex As Exception
                RowCellValue = Nothing
            Finally
                GetRowCellValueByPropertyType = RowCellValue
            End Try

        End Function
        Private Sub SetRowCellValueByPropertyType(ByVal RowHandle As Integer, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByVal Value As Object)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim NonNullableType As System.Type = Nothing
            Dim ClearValue As Object = Nothing
            Dim CanAutoFillValue As Boolean = True

            Try

                PropertyDescriptor = (From [Property] In _ObjectTypePropertyDescriptors
                                      Where [Property].Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Where(Function(Attribute) Attribute.PropertyType = PropertyType).Any
                                      Select [Property]).SingleOrDefault

                If PropertyDescriptor IsNot Nothing Then

                    RaiseEvent CanAutoFillValueEvent(CanAutoFillValue, PropertyDescriptor)

                    If CanAutoFillValue Then

                        If Me.Columns(PropertyDescriptor.Name) IsNot Nothing Then

                            If Value IsNot Nothing Then

                                If [Nullable].GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

                                    NonNullableType = [Nullable].GetUnderlyingType(PropertyDescriptor.PropertyType)

                                Else

                                    NonNullableType = PropertyDescriptor.PropertyType

                                End If

                                If IsNothing(Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name)) OrElse IsDBNull(Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name)) OrElse
                                        Convert.ChangeType(Value, NonNullableType) <> Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name) Then

                                    Me.SetRowCellValue(RowHandle, PropertyDescriptor.Name, Convert.ChangeType(Value, NonNullableType))

                                End If

                            Else

                                If AdvantageFramework.BaseClasses.Entity.LoadPropertyIsNullable(PropertyDescriptor) Then

                                    ClearValue = ""

                                End If

                                If IsNothing(Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name)) = False AndAlso IsDBNull(Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name)) = False Then

                                    Me.SetRowCellValue(RowHandle, PropertyDescriptor.Name, ClearValue)

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SetRowCellValueByDefaultColumnType(ByVal RowHandle As Integer, ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes, ByVal Value As Object)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim NonNullableType As System.Type = Nothing
            Dim CanAutoFillValue As Boolean = True

            Try

                PropertyDescriptor = (From [Property] In _ObjectTypePropertyDescriptors
                                      Where [Property].Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Where(Function(Attribute) Attribute.DefaultColumnType = DefaultColumnType).Any
                                      Select [Property]).SingleOrDefault

                If PropertyDescriptor IsNot Nothing Then

                    RaiseEvent CanAutoFillValueEvent(CanAutoFillValue, PropertyDescriptor)

                    If CanAutoFillValue Then

                        If Value IsNot Nothing Then

                            If [Nullable].GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

                                NonNullableType = [Nullable].GetUnderlyingType(PropertyDescriptor.PropertyType)

                            Else

                                NonNullableType = PropertyDescriptor.PropertyType

                            End If

                            If Convert.ChangeType(Value, NonNullableType) <> If(Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name) Is System.DBNull.Value, Nothing, Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name)) Then

                                Me.SetRowCellValue(RowHandle, PropertyDescriptor.Name, Convert.ChangeType(Value, NonNullableType))

                            End If

                        Else

                            If Me.GetRowCellValue(RowHandle, PropertyDescriptor.Name) IsNot Nothing Then

                                Me.SetRowCellValue(RowHandle, PropertyDescriptor.Name, Nothing)

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub AutoFillPropertyValues(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RowHandle As Integer, ByVal Entity As Object)

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobCore As AdvantageFramework.Database.Core.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobComponentCore As AdvantageFramework.Database.Core.JobComponent = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim DivisionCore As AdvantageFramework.Database.Core.Division = Nothing
            Dim ProductCore As AdvantageFramework.Database.Core.Product = Nothing
            Dim JobNumber As Nullable(Of Integer) = Nothing
            Dim JobComponentID As Nullable(Of Integer) = Nothing
            Dim JobComponentNumber As Nullable(Of Integer) = Nothing
            Dim JobComponentDescription As String = Nothing
            Dim IsValid As Boolean
            Dim ProductView As AdvantageFramework.Database.Views.ProductView = Nothing

            _IsAutoFilling = True

            Try

                If TypeOf Entity Is AdvantageFramework.Database.Entities.Job Then

                    Job = DirectCast(Entity, AdvantageFramework.Database.Entities.Job)

                    Try

                        ProductView = (From Prod In AdvantageFramework.Database.Procedures.ProductView.Load(DbContext)
                                       Where Prod.ClientCode = Job.ClientCode AndAlso
                                                Prod.DivisionCode = Job.DivisionCode AndAlso
                                                Prod.ProductCode = Job.ProductCode
                                       Select Prod).SingleOrDefault

                    Catch ex As Exception
                        ProductView = Nothing
                    End Try

                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ClientCode, Job.ClientCode)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ClientName, If(ProductView IsNot Nothing, ProductView.ClientName, ""))
                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.DivisionCode, Job.DivisionCode)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.DivisionName, If(ProductView IsNot Nothing, ProductView.DivisionName, ""))
                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode, Job.ProductCode)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, If(ProductView IsNot Nothing, ProductView.ProductDescription, ""))
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.JobDescription, Job.Description)

                    Try

                        JobComponentCore = (From JobComp In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext))
                                            Where JobComp.JobNumber = Job.Number
                                            Select JobComp).SingleOrDefault

                        JobComponentNumber = JobComponentCore.Number
                        JobComponentID = JobComponentCore.ID
                        JobComponentDescription = JobComponentCore.Description

                    Catch ex As Exception
                        JobComponentNumber = Nothing
                        JobComponentID = Nothing
                    End Try

                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.JobComponent, JobComponentNumber)
                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.JobComponentID, JobComponentID)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.JobComponentDescription, JobComponentDescription)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.JobComponent Then

                    JobComponent = DirectCast(Entity, AdvantageFramework.Database.Entities.JobComponent)

                    'Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobComponent.JobNumber)
                    JobCore = AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext).SingleOrDefault(Function(EntityCore) EntityCore.Number = JobComponent.JobNumber)

                    Try

                        ProductView = (From Prod In AdvantageFramework.Database.Procedures.ProductView.Load(DbContext)
                                       Where Prod.ClientCode = JobCore.ClientCode AndAlso
                                                Prod.DivisionCode = JobCore.DivisionCode AndAlso
                                                Prod.ProductCode = JobCore.ProductCode
                                       Select Prod).SingleOrDefault

                    Catch ex As Exception
                        ProductView = Nothing
                    End Try

                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ClientCode, JobCore.ClientCode)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ClientName, If(ProductView IsNot Nothing, ProductView.ClientName, ""))
                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.DivisionCode, JobCore.DivisionCode)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.DivisionName, If(ProductView IsNot Nothing, ProductView.DivisionName, ""))
                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode, JobCore.ProductCode)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, If(ProductView IsNot Nothing, ProductView.ProductDescription, ""))
                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.JobNumber, JobCore.Number)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.JobDescription, JobCore.Description)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.JobComponentDescription, JobComponent.Description)
                    'PLEASE SEE TYLER IF NEXT 2 ROWS CAUSE AN ISSUE!!!
                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.JobComponent, JobComponent.Number)
                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.JobComponentID, JobComponent.ID)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Client Then

                    Client = DirectCast(Entity, AdvantageFramework.Database.Entities.Client)
                    DivisionCode = GetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.DivisionCode)
                    ProductCode = GetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode)

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ClientName, Client.Name)

                    If String.IsNullOrEmpty(DivisionCode) = False Then

                        IsValid = True

                        AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.DivisionCode, DivisionCode, IsValid, Client.Code)

                        If IsValid = False Then

                            DivisionCode = Nothing
                            ProductCode = Nothing

                        End If

                    End If

                    If String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                        IsValid = True

                        AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.ProductCode, ProductCode, IsValid, Client.Code, DivisionCode)

                        If IsValid = False Then

                            ProductCode = Nothing

                        End If

                    End If

                    If String.IsNullOrEmpty(DivisionCode) Then

                        Try

                            DivisionCore = (From Div In AdvantageFramework.Database.Procedures.Division.LoadCore(AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext))
                                            Where Div.ClientCode = Client.Code
                                            Select Div).SingleOrDefault

                        Catch ex As Exception
                            DivisionCore = Nothing
                        End Try

                    End If

                    If DivisionCore IsNot Nothing AndAlso String.IsNullOrEmpty(ProductCode) = True Then

                        Try

                            ProductCore = (From Prod In AdvantageFramework.Database.Procedures.Product.LoadCore(AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext))
                                           Where Prod.ClientCode = Client.Code AndAlso
                                                    Prod.DivisionCode = DivisionCore.Code
                                           Select Prod).SingleOrDefault

                        Catch ex As Exception
                            ProductCore = Nothing
                        End Try

                    End If

                    If TypeOf Me.GetRow(RowHandle) Is AdvantageFramework.Database.Classes.BillingRateDetail Then

                        If Me.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString) IsNot Nothing AndAlso
                                Me.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString).Visible Then

                            If DivisionCore IsNot Nothing Then

                                SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.DivisionCode, DivisionCore.Code)
                                SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.DivisionName, DivisionCore.Name)

                            Else

                                SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.DivisionCode, Nothing)
                                SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.DivisionName, Nothing)

                            End If

                        End If

                        If Me.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductCode.ToString) IsNot Nothing AndAlso
                                Me.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductCode.ToString).Visible Then

                            If ProductCore IsNot Nothing Then

                                SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode, ProductCore.Code)
                                SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, ProductCore.Name)

                            Else

                                SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode, Nothing)
                                SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, Nothing)

                            End If

                        End If

                    Else

                        If DivisionCore IsNot Nothing Then

                            SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.DivisionCode, DivisionCore.Code)
                            SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.DivisionName, DivisionCore.Name)

                        Else

                            SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.DivisionCode, Nothing)
                            SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.DivisionName, Nothing)

                        End If

                        If ProductCore IsNot Nothing Then

                            SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode, ProductCore.Code)
                            SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, ProductCore.Name)

                        Else

                            SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode, Nothing)
                            SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, Nothing)

                        End If

                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCategory, Nothing)
                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductCategoryDescription, Nothing)

                    End If

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Division Then

                    Division = DirectCast(Entity, AdvantageFramework.Database.Entities.Division)
                    ProductCode = GetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode)

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.DivisionName, Division.Name)

                    If String.IsNullOrEmpty(ProductCode) = False Then

                        IsValid = True

                        AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.ProductCode, ProductCode, IsValid, Division.ClientCode, Division.Code)

                        If IsValid = False Then

                            ProductCode = Nothing

                        End If

                    End If

                    If String.IsNullOrEmpty(ProductCode) Then

                        Try

                            ProductCore = (From Prod In AdvantageFramework.Database.Procedures.Product.LoadCore(AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext))
                                           Where Prod.ClientCode = Division.ClientCode AndAlso
                                                    Prod.DivisionCode = Division.Code
                                           Select Prod).SingleOrDefault

                        Catch ex As Exception
                            ProductCore = Nothing
                        End Try

                    End If

                    If ProductCore IsNot Nothing Then

                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode, ProductCore.Code)
                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, ProductCore.Name)

                    Else

                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode, Nothing)
                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, Nothing)

                    End If

                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCategory, Nothing)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductCategoryDescription, Nothing)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Core.Product Then

                    ProductCore = DirectCast(Entity, AdvantageFramework.Database.Core.Product)

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, ProductCore.Name)
                    SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCategory, Nothing)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductCategoryDescription, Nothing)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.AccountReceivable Then

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.AccountReceivableSequenceNumber, DirectCast(Entity, AdvantageFramework.Database.Entities.AccountReceivable).SequenceNumber)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.AccountReceivableType, DirectCast(Entity, AdvantageFramework.Database.Entities.AccountReceivable).Type)
                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.AccountReceivableClientCode, DirectCast(Entity, AdvantageFramework.Database.Entities.AccountReceivable).ClientCode)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Office Then

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.OfficeName, DirectCast(Entity, AdvantageFramework.Database.Entities.Office).Code)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.DepartmentTeam Then

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.DepartmentTeamName, DirectCast(Entity, AdvantageFramework.Database.Entities.DepartmentTeam).Code)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Function Then

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.FunctionDescription, DirectCast(Entity, AdvantageFramework.Database.Entities.Function).Description)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Core.Vendor Then

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.VendorName, DirectCast(Entity, AdvantageFramework.Database.Core.Vendor).Name)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.ProductCategory Then

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductCategoryDescription, DirectCast(Entity, AdvantageFramework.Database.Entities.ProductCategory).Description)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Core.GeneralLedgerAccount Then

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription, DirectCast(Entity, AdvantageFramework.Database.Core.GeneralLedgerAccount).Description)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.SalesClass Then

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.SalesClassDescription, DirectCast(Entity, AdvantageFramework.Database.Entities.SalesClass).Description)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.State Then

                    SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.StateName, DirectCast(Entity, AdvantageFramework.Database.Entities.State).StateName)

                End If

            Catch ex As Exception

            End Try

            _IsAutoFilling = False

        End Sub
        Protected Overrides Function CreateFindPanel(ByVal FindPanelProperties As Object) As DevExpress.XtraGrid.Controls.FindControl

            CreateFindPanel = New AdvantageFramework.WinForm.Presentation.Controls.FindPanel(Me, FindPanelProperties)

        End Function
        Private Sub UnSubscribeEvents()

            RemoveHandler Me.RowCellStyle, AddressOf GridView_RowCellStyle
            RemoveHandler Me.ShowingEditor, AddressOf GridView_ShowingEditor

        End Sub
        Private Sub SubscribeEvents()

            AddHandler Me.RowCellStyle, AddressOf GridView_RowCellStyle
            AddHandler Me.ShowingEditor, AddressOf GridView_ShowingEditor

        End Sub
        Public Sub DisableRow(ByVal DataSourceRowIndex As Integer, Optional ByVal RowType As AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow.RowType = AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow.RowType.Deleted)

            Dim DisabledRow As AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow = Nothing

            If _EnableDisabledRows Then

                EnableRow(DataSourceRowIndex)

                DisabledRow = New AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow(DataSourceRowIndex, RowType)
                DisabledRows.Add(DisabledRow)

            End If

        End Sub
        Public Function IsRowDisabled(ByVal DataSourceRowIndex As Integer) As Boolean

            If _EnableDisabledRows Then

                IsRowDisabled = DisabledRows.Where(Function(dr) dr.DataSourceRowIndex = DataSourceRowIndex).Any

            Else

                IsRowDisabled = False

            End If

        End Function
        Public Function IsRowDisabledAsDeleted(ByVal DataSourceRowIndex As Integer) As Boolean

            If _EnableDisabledRows Then

                IsRowDisabledAsDeleted = DisabledRows.Where(Function(dr) dr.DataSourceRowIndex = DataSourceRowIndex AndAlso dr.DisabledRowType = Classes.DisabledRow.RowType.Deleted).Any

            Else

                IsRowDisabledAsDeleted = False

            End If

        End Function
        Public Function IsRowDisabledAsReadonly(ByVal DataSourceRowIndex As Integer) As Boolean

            If _EnableDisabledRows Then

                IsRowDisabledAsReadonly = DisabledRows.Where(Function(dr) dr.DataSourceRowIndex = DataSourceRowIndex AndAlso dr.DisabledRowType = Classes.DisabledRow.RowType.Readonly).Any

            Else

                IsRowDisabledAsReadonly = False

            End If

        End Function
        Public Sub EnableRow(ByVal DataSourceRowIndex As Integer)

            If _EnableDisabledRows Then

                Do While IsRowDisabled(DataSourceRowIndex)

                    DisabledRows.Remove(DisabledRows.Where(Function(dr) dr.DataSourceRowIndex = DataSourceRowIndex).SingleOrDefault())

                Loop

            End If

        End Sub
        Public Sub ClearDisabledRows()

            If _EnableDisabledRows Then

                DisabledRows.Clear()

            End If

        End Sub
        Private Sub ClearValuesByPropertyType(ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByVal RowHandle As Integer)

            Try

                Select Case PropertyType

                    Case BaseClasses.PropertyTypes.ClientCode

                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.DivisionCode, Nothing)
                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode, Nothing)
                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCategory, Nothing)

                        ClearColumnValuesByPropertyType(PropertyType, RowHandle)

                    Case BaseClasses.PropertyTypes.DivisionCode

                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCode, Nothing)
                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCategory, Nothing)

                        ClearColumnValuesByPropertyType(PropertyType, RowHandle)

                    Case BaseClasses.PropertyTypes.ProductCode, BaseClasses.PropertyTypes.JobNumber,
                            BaseClasses.PropertyTypes.JobComponent, BaseClasses.PropertyTypes.JobComponentID

                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.ProductCategory, Nothing)

                        ClearColumnValuesByPropertyType(PropertyType, RowHandle)

                    Case BaseClasses.PropertyTypes.OfficeCode

                        ClearColumnValuesByPropertyType(PropertyType, RowHandle)

                    Case BaseClasses.PropertyTypes.DepartmentTeamCode

                        ClearColumnValuesByPropertyType(PropertyType, RowHandle)

                    Case BaseClasses.PropertyTypes.FunctionCode, BaseClasses.PropertyTypes.VendorFunctionCode

                        ClearColumnValuesByPropertyType(PropertyType, RowHandle)

                End Select

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ClearColumnValuesByPropertyType(ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByVal RowHandle As Integer)

            Try

                Select Case PropertyType

                    Case BaseClasses.PropertyTypes.JobNumber

                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.JobDescription, Nothing)
                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.JobComponentID, Nothing)
                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.JobComponent, Nothing)
                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.JobComponentDescription, Nothing)

                    Case BaseClasses.PropertyTypes.JobComponent, BaseClasses.PropertyTypes.JobComponentID

                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.JobComponentDescription, Nothing)

                    Case BaseClasses.PropertyTypes.ClientCode, BaseClasses.PropertyTypes.DivisionCode, BaseClasses.PropertyTypes.ProductCode

                        If PropertyType = BaseClasses.PropertyTypes.ClientCode Then

                            SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.DivisionName, Nothing)
                            SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, Nothing)

                        ElseIf PropertyType = BaseClasses.PropertyTypes.DivisionCode Then

                            SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductName, Nothing)

                        End If

                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.JobNumber, Nothing)
                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.JobDescription, Nothing)
                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.JobComponentID, Nothing)
                        SetRowCellValueByPropertyType(RowHandle, BaseClasses.PropertyTypes.JobComponent, Nothing)
                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.JobComponentDescription, Nothing)

                    Case BaseClasses.PropertyTypes.FunctionCode

                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.FunctionDescription, Nothing)

                    Case BaseClasses.PropertyTypes.ProductCategory

                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.ProductCategoryDescription, Nothing)

                    Case BaseClasses.PropertyTypes.SalesClassCode

                        SetRowCellValueByDefaultColumnType(RowHandle, BaseClasses.DefaultColumnTypes.SalesClassDescription, Nothing)

                End Select

            Catch ex As Exception

            End Try

        End Sub
        Private Function GetGridLookUpEditColumnValue(ByVal GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit, ByVal FieldName As String) As Object

            'objects
            Dim ColumnValue As Object = Nothing

            Try

                If GridLookUpEdit.EditValue IsNot Nothing Then

                    ColumnValue = GridLookUpEdit.Properties.View.GetFocusedRowCellValue(FieldName)

                End If

            Catch ex As Exception
                ColumnValue = Nothing
            Finally
                GetGridLookUpEditColumnValue = ColumnValue
            End Try

        End Function
        Public Sub RaiseBeforeLeaveRowEvent()

            Me.RaiseBeforeLeaveRow(New DevExpress.XtraGrid.Views.Base.RowAllowEventArgs(Me.FocusedRowHandle, True))

        End Sub
        Protected Sub SetGridColumnAppearanceDefaults(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            GridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
            GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

        End Sub
        Public Overrides Sub BestFitColumns()

            'objects
            Dim GridColumnList As Generic.Dictionary(Of DevExpress.XtraGrid.Columns.GridColumn, DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum) = Nothing

            If _ControlType = BandedDataGridView.Type.EditableGrid Then

                GridColumnList = New Generic.Dictionary(Of DevExpress.XtraGrid.Columns.GridColumn, DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum)

                For Each GridColumn In Me.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    If GridColumn.ColumnEdit IsNot Nothing Then

                        If TypeOf GridColumn.ColumnEdit Is DevExpress.XtraEditors.Repository.RepositoryItemDateEdit Then

                            GridColumnList.Add(GridColumn, GridColumn.ShowButtonMode)

                            GridColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways

                        End If

                    End If

                Next

            End If

            MyBase.BestFitColumns()

            If _ControlType = BandedDataGridView.Type.EditableGrid Then

                For Each KeyValue In GridColumnList

                    KeyValue.Key.ShowButtonMode = KeyValue.Value

                Next

            End If

        End Sub

#Region "  Control Event Handlers "

        Private Sub GridView_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Me.CellValueChanged

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Entity As Object = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As Integer = Nothing
            Dim DoClear As Boolean = True
            Dim SequenceNumber As Short = Nothing
            Dim Type As String = Nothing

            If _IsAutoFilling = False AndAlso Me.AutoFilterLookupColumns AndAlso _ControlType = BandedDataGridView.Type.EditableGrid Then

                Try

                    PropertyDescriptor = _ObjectTypePropertyDescriptors.Where(Function(Prop) Prop.Name = e.Column.FieldName).SingleOrDefault

                    If PropertyDescriptor IsNot Nothing Then

                        Try

                            EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                            If EntityAttribute IsNot Nothing Then

                                If e.Value IsNot Nothing Then

                                    If EntityAttribute.PropertyType <> BaseClasses.PropertyTypes.Default Then

                                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                                Select Case EntityAttribute.PropertyType

                                                    Case BaseClasses.PropertyTypes.JobNumber

                                                        ClearColumnValuesByPropertyType(EntityAttribute.PropertyType, e.RowHandle)

                                                        Entity = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, e.Value)

                                                    Case BaseClasses.PropertyTypes.JobComponent

                                                        ClearColumnValuesByPropertyType(EntityAttribute.PropertyType, e.RowHandle)

                                                        JobNumber = Me.GetRowCellValueByPropertyType(e.RowHandle, BaseClasses.PropertyTypes.JobNumber)

                                                        If Me.GetRowCellValueByPropertyType(e.RowHandle, BaseClasses.PropertyTypes.JobComponentID) Is Nothing Then

                                                            Entity = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, e.Value)

                                                        Else

                                                            Entity = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

                                                        End If

                                                    Case BaseClasses.PropertyTypes.JobComponentID

                                                        ClearColumnValuesByPropertyType(EntityAttribute.PropertyType, e.RowHandle)

                                                        'PLEASE SEE TYLER BEFORE UNCOMMENTING NEXT LINE
                                                        'SetRowCellValueByPropertyType(e.RowHandle, BaseClasses.PropertyTypes.JobComponent, DirectCast(Me.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.GetRowCellValue(DirectCast(Me.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.FocusedRowHandle, "Number"))

                                                        Entity = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobComponentID(DbContext, e.Value)

                                                    Case BaseClasses.PropertyTypes.ClientCode

                                                        ClearColumnValuesByPropertyType(EntityAttribute.PropertyType, e.RowHandle)

                                                        Entity = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, e.Value)

                                                    Case BaseClasses.PropertyTypes.DivisionCode

                                                        ClearColumnValuesByPropertyType(EntityAttribute.PropertyType, e.RowHandle)

                                                        ClientCode = GetRowCellValueByPropertyType(e.RowHandle, BaseClasses.PropertyTypes.ClientCode)

                                                        Entity = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, ClientCode, e.Value)

                                                    Case BaseClasses.PropertyTypes.ProductCode

                                                        ClearColumnValuesByPropertyType(EntityAttribute.PropertyType, e.RowHandle)

                                                        ClientCode = GetRowCellValueByPropertyType(e.RowHandle, BaseClasses.PropertyTypes.ClientCode)
                                                        DivisionCode = GetRowCellValueByPropertyType(e.RowHandle, BaseClasses.PropertyTypes.DivisionCode)

                                                        Try

                                                            Entity = AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext).SingleOrDefault(Function(ECO) ECO.ClientCode = ClientCode AndAlso ECO.DivisionCode = DivisionCode AndAlso ECO.Code = e.Value)

                                                        Catch ex As Exception
                                                            Entity = Nothing
                                                        End Try

                                                    Case BaseClasses.PropertyTypes.FunctionCode, BaseClasses.PropertyTypes.VendorFunctionCode

                                                        ClearColumnValuesByPropertyType(BaseClasses.PropertyTypes.FunctionCode, e.RowHandle)

                                                        Entity = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, e.Value)

                                                    Case BaseClasses.PropertyTypes.DepartmentTeamCode

                                                        ClearColumnValuesByPropertyType(BaseClasses.PropertyTypes.DepartmentTeamCode, e.RowHandle)

                                                        Entity = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, e.Value)

                                                    Case BaseClasses.PropertyTypes.VendorCode

                                                        ClearColumnValuesByPropertyType(BaseClasses.PropertyTypes.VendorCode, e.RowHandle)

                                                        Entity = AdvantageFramework.Database.Procedures.Vendor.LoadCore(DbContext).SingleOrDefault(Function(ECO) ECO.Code = e.Value)

                                                    Case BaseClasses.PropertyTypes.ProductCategory

                                                        ClearColumnValuesByPropertyType(BaseClasses.PropertyTypes.ProductCategory, e.RowHandle)

                                                        ClientCode = GetRowCellValueByPropertyType(e.RowHandle, BaseClasses.PropertyTypes.ClientCode)
                                                        DivisionCode = GetRowCellValueByPropertyType(e.RowHandle, BaseClasses.PropertyTypes.DivisionCode)
                                                        ProductCode = GetRowCellValueByPropertyType(e.RowHandle, BaseClasses.PropertyTypes.ProductCode)

                                                        Entity = AdvantageFramework.Database.Procedures.ProductCategory.LoadByClientAndDivisionAndProductAndProductCategoryCode(DbContext, ClientCode, DivisionCode, ProductCode, e.Value)

                                                    Case BaseClasses.PropertyTypes.GeneralLedgerAccountCode

                                                        ClearColumnValuesByPropertyType(BaseClasses.PropertyTypes.GeneralLedgerAccountCode, e.RowHandle)

                                                        Entity = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).SingleOrDefault(Function(ECO) ECO.Code = e.Value)

                                                    Case BaseClasses.PropertyTypes.SalesClassCode

                                                        ClearColumnValuesByPropertyType(BaseClasses.PropertyTypes.SalesClassCode, e.RowHandle)

                                                        Entity = AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(DbContext, e.Value)

                                                End Select

                                                If Entity IsNot Nothing Then

                                                    AutoFillPropertyValues(DbContext, DataContext, e.RowHandle, Entity)

                                                    DoClear = False

                                                End If

                                            End Using

                                        End Using

                                    End If

                                End If

                                If DoClear Then

                                    ClearValuesByPropertyType(EntityAttribute.PropertyType, e.RowHandle)

                                End If

                            End If

                        Catch ex As Exception
                            EntityAttribute = Nothing
                        End Try

                    End If

                Catch ex As Exception

                End Try

            End If

            If Me.ActiveEditor IsNot Nothing Then

                ColumnEditValueChanged(Me.ActiveEditor, e)

            End If

        End Sub
        Private Sub GridView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Me.CellValueChanging

            Try

                Me.ActiveEditor.Tag.Tag = False

            Catch ex As Exception

            End Try

        End Sub
        Private Sub GridView_CustomColumnDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles Me.CustomColumnDisplayText

            'objects
            Dim EnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
            Dim Entity As Object = Nothing

            If _ObjectType Is GetType(AdvantageFramework.Database.Entities.EstimateProcessingOption) Then

                If e.Column.FieldName = "ExceedOption" Then

                    Try

                        e.DisplayText = IIf(e.Value IsNot Nothing, DirectCast(CInt(e.Value), AdvantageFramework.Database.Entities.ExceedEstimateOptions).ToString, "")

                    Catch ex As Exception
                        e.DisplayText = e.DisplayText
                    End Try

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.EmployeeTitle) Then

                If e.Column.FieldName = "EmployeeCategoryID" Then

                    If e.Value <> 0 Then

                        If _Session IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Entity = AdvantageFramework.Database.Procedures.EmployeeCategory.LoadByEmployeeCategoryID(DbContext, e.Value)

                                If Entity IsNot Nothing Then

                                    e.DisplayText = DirectCast(Entity, AdvantageFramework.Database.Entities.EmployeeCategory).Description

                                End If

                            End Using

                        Else

                            e.DisplayText = ""

                        End If

                    Else

                        e.DisplayText = ""

                    End If

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) Then

                If Me.OptionsBehavior.Editable Then

                    If e.Column.FieldName = "IsCommission" Then

                        If e.Value Is Nothing Then

                            e.DisplayText = "[Skip]"

                        End If

                    End If

                    If e.Column.FieldName = "RateAmount" Then

                        If e.Value Is Nothing Then

                            e.DisplayText = "[Skip]"

                        End If

                    End If

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Views.BillingRateDetailView) Then

                If Me.OptionsBehavior.Editable Then

                    If e.Column.FieldName = AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsCommission.ToString Then

                        If e.Value Is Nothing Then

                            e.DisplayText = "[Skip]"

                        End If

                    End If

                    If e.Column.FieldName = AdvantageFramework.Database.Views.BillingRateDetailView.Properties.BillingRate.ToString Then

                        If e.Value Is Nothing Then

                            e.DisplayText = "[Skip]"

                        End If

                    End If

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.Associate) Then

                If Me.OptionsBehavior.Editable = False Then

                    If e.Column.FieldName = AdvantageFramework.Database.Entities.Associate.Properties.MediaType.ToString Then

                        If e.Value IsNot Nothing Then

                            Try

                                e.DisplayText = (From KeyValuePair In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AssociateMediaType)).ToList
                                                 Where KeyValuePair.Code.ToUpper = e.Value.ToString.ToUpper
                                                 Select KeyValuePair.Description).FirstOrDefault

                            Catch ex As Exception
                                e.DisplayText = ""
                            End Try

                        End If

                    End If

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee) Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.Order.ToString Then

                    If e.Value IsNot Nothing Then

                        Try

                            e.DisplayText = (From KeyValuePair In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.POApprovalRuleEmployeeOrder)).ToList
                                             Where KeyValuePair.Code = e.Value.ToString
                                             Select KeyValuePair.Description).FirstOrDefault

                        Catch ex As Exception
                            e.DisplayText = ""
                        End Try

                    End If

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.DocumentManager.Classes.Document) Then

                If e.Column.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.FileSize.ToString Then

                    If e.Value IsNot Nothing Then

                        Try

                            e.DisplayText = AdvantageFramework.FileSystem.GetFileSizeWithNotation(CDbl(e.Value))

                        Catch ex As Exception
                            e.DisplayText = e.Value
                        End Try

                    End If

                End If

                If e.Column.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.DocumentTypeID.ToString Then

                    If e.Value IsNot Nothing Then

                        If _Session IsNot Nothing Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                Try

                                    Entity = (From DocumentType In AdvantageFramework.Database.Procedures.DocumentType.Load(DataContext).ToList
                                              Where DocumentType.ID = e.Value
                                              Select DocumentType).SingleOrDefault

                                    If Entity IsNot Nothing Then

                                        e.DisplayText = DirectCast(Entity, AdvantageFramework.Database.Entities.DataContextDocumentType).Name

                                    End If

                                Catch ex As Exception
                                    e.DisplayText = e.Value
                                End Try

                            End Using

                        End If

                    End If

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.DetailDocument) Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.DetailDocument.Properties.FILE_SIZE.ToString Then

                    If e.Value IsNot Nothing Then

                        Try

                            e.DisplayText = AdvantageFramework.FileSystem.GetFileSizeWithNotation(CDbl(e.Value))

                        Catch ex As Exception
                            e.DisplayText = e.Value
                        End Try

                    End If

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeTimeOff) Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeTimeOff.Properties.TimeRule.ToString Then

                    Try

                        If e.Value Is Nothing OrElse e.Value <= 0 Then

                            e.DisplayText = "[None]"

                        End If

                    Catch ex As Exception
                        e.DisplayText = e.Value
                    End Try

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.JobVersionTemplateDetail) Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.DatabaseTypeID.ToString Then

                    Try

                        If e.Value Is Nothing OrElse e.Value = 0 Then

                            e.DisplayText = " "

                        End If

                    Catch ex As Exception
                        e.DisplayText = e.Value
                    End Try

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement) Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientContactID.ToString Then

                    Try

                        If e.Value Is Nothing OrElse e.Value = 0 Then

                            e.DisplayText = " "

                        End If

                    Catch ex As Exception
                        e.DisplayText = e.Value
                    End Try

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement) Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientContactID.ToString Then

                    Try

                        If e.Value Is Nothing OrElse e.Value = 0 Then

                            e.DisplayText = " "

                        End If

                    Catch ex As Exception
                        e.DisplayText = e.Value
                    End Try

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.PostPeriod) OrElse
                    _ObjectType Is GetType(AdvantageFramework.Database.Classes.PostPeriod) Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.PostPeriod.Properties.GLStatus.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Database.Entities.PostPeriod.Properties.ARStatus.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Database.Entities.PostPeriod.Properties.APStatus.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Database.Entities.PostPeriod.Properties.EmployeeTimeStatus.ToString Then

                    Try

                        If e.Value Is Nothing OrElse e.Value = "" Then

                            e.DisplayText = "Open"

                        End If

                    Catch ex As Exception
                        e.DisplayText = e.Value
                    End Try

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Entities.GLReportTemplate) Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.GLReportTemplate.Properties.ReportType.ToString Then

                    Try

                        e.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

                        e.DisplayText = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.GeneralLedger.ReportWriter.ReportTypes), e.Value)

                    Catch ex As Exception
                        e.DisplayText = ""
                    End Try

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.Security.Database.Entities.Report) Then

                If e.Column.FieldName = AdvantageFramework.Security.Database.Entities.Report.Properties.Type.ToString Then

                    Try

                        e.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                        e.DisplayText = AdvantageFramework.Security.Database.Procedures.Report.LoadApplicationModuleByType(CShort(e.Value))

                    Catch ex As Exception
                        e.DisplayText = ""
                    End Try

                End If

            ElseIf _ObjectType Is GetType(AdvantageFramework.EmployeeTimesheet.Classes.DayStatus) Then

                If e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.DayStatus.Properties.Status.ToString Then

                    Try

                        e.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                        e.DisplayText = AdvantageFramework.StringUtilities.GetNameAsWords([Enum].GetName(GetType(AdvantageFramework.EmployeeTimesheet.DayApprovalType), CInt(e.Value)))

                    Catch ex As Exception
                        e.DisplayText = ""
                    End Try

                End If

            End If

            If _IsInGridLookupEditControl Then

                Try

                    If IsNumeric(e.DisplayText) AndAlso CDec(e.DisplayText) < 0 AndAlso e.DisplayText.StartsWith("-") = True Then

                        e.DisplayText = ""

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub GridView_CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles Me.CustomDrawRowIndicator

            If _EnableDisabledRows Then

                If e.Info.IsRowIndicator AndAlso e.RowHandle >= 0 Then

                    For DataSourceRowIndex As Integer = 0 To _DisabledRows.Count - 1

                        If GetDataSourceRowIndex(e.RowHandle) = _DisabledRows(DataSourceRowIndex).DataSourceRowIndex AndAlso _DisabledRows(DataSourceRowIndex).DisabledRowType = Classes.DisabledRow.RowType.Deleted Then

                            e.Painter.DrawObject(e.Info)
                            e.Graphics.DrawImageUnscaled(AdvantageFramework.My.Resources.SmallDetailDeleteImage, e.Bounds)

                            e.Handled = True

                        End If

                    Next

                End If

            End If

        End Sub
        Private Sub GridView_CustomRowFilter(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles Me.CustomRowFilter

            SetCustomRowCellEdit(e.ListSourceRow)

        End Sub
        Private Sub GridView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles Me.CustomUnboundColumnData

            If e.Column.FieldName = _IntegerUnboundColumnFieldName Then

                Try

                    If e.IsGetData Then

                        If _IntegerUnboundColumnValues.ContainsKey(e.ListSourceRowIndex) Then

                            e.Value = _IntegerUnboundColumnValues(e.ListSourceRowIndex)

                        Else

                            e.Value = Nothing

                        End If

                    ElseIf e.IsSetData Then

                        If _IntegerUnboundColumnValues.ContainsKey(e.ListSourceRowIndex) Then

                            _IntegerUnboundColumnValues(e.ListSourceRowIndex) = e.Value

                        Else

                            _IntegerUnboundColumnValues.Add(e.ListSourceRowIndex, e.Value)

                        End If

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub GridView_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataSourceChanged

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        DbContext.Database.Connection.Open()

                        For Each Column In Me.Columns

                            ModifyColumn(Column, DbContext, DataContext)

                            RaiseEvent ColumnAddedEvent(Column)

                        Next

                        DbContext.Database.Connection.Close()

                    End Using

                End Using

            Else

                For Each Column In Me.Columns

                    ModifyColumn(Column, Nothing, Nothing)

                    RaiseEvent ColumnAddedEvent(Column)

                Next

            End If

            SetNearestCanFocusColumn(Me.FocusedColumn)

            If Me.OptionsBehavior.Editable Then

                If _ObjectType Is GetType(AdvantageFramework.Database.Entities.SalesTax) AndAlso Me.Columns.ColumnByFieldName("TotalPercent") Is Nothing Then

                    AddSalesTaxUnboundColumn()

                ElseIf _ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeTimeTemplate) AndAlso Me.Columns.ColumnByFieldName("CustomGroupByKey") Is Nothing Then

                    AddCustomGroupByKeyColumn()

                ElseIf _ObjectType Is GetType(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry) AndAlso Me.Columns.ColumnByFieldName("CustomGroupByKey") Is Nothing Then

                    AddCustomGroupByKeyColumn()

                ElseIf _ObjectType Is GetType(AdvantageFramework.ProjectSchedule.Classes.TaskDetail) AndAlso Me.Columns.ColumnByFieldName("Quantity") Is Nothing Then

                    AddIntegerUnboundColumn("Quantity", "Quantity", 0)

                End If

                If _IntegerUnboundColumnValues IsNot Nothing Then

                    _IntegerUnboundColumnValues.Clear()

                End If

            End If

        End Sub
        Private Sub GridView_FocusedColumnChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles Me.FocusedColumnChanged

            SetNearestCanFocusColumn(Me.FocusedColumn)

        End Sub
        Private Sub GridView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles Me.InitNewRow

            If _Session IsNot Nothing Then

                If TypeOf Me.GetRow(e.RowHandle) Is AdvantageFramework.BaseClasses.Entity Then

                    DirectCast(Me.GetRow(e.RowHandle), AdvantageFramework.BaseClasses.Entity).DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ElseIf TypeOf Me.GetRow(e.RowHandle) Is AdvantageFramework.BaseClasses.EntityBase Then

                    DirectCast(Me.GetRow(e.RowHandle), AdvantageFramework.BaseClasses.EntityBase).DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    DirectCast(Me.GetRow(e.RowHandle), AdvantageFramework.BaseClasses.EntityBase).DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                End If

            End If

        End Sub
        Private Sub GridView_MainView_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles Me.InvalidRowException

            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction

        End Sub
        Private Sub GridView_MainView_InvalidValueException(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles Me.InvalidValueException

            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction

        End Sub
        Private Sub GridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

            If e.Control Then

                If Me.FocusedColumn IsNot Nothing AndAlso Me.FocusedColumn.VisibleIndex = -1 Then

                    e.Handled = True
                    e.SuppressKeyPress = True

                End If

            Else

                If _ControlType = BandedDataGridView.Type.EditableGrid Then

                    If Me.IsEditing = False Then

                        Me.ShowEditor()

                    End If

                    If e.KeyCode = Windows.Forms.Keys.Enter Then

                        If TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                            If DirectCast(Me.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).IsPopupOpen = False Then

                                DirectCast(Me.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).ShowPopup()

                                e.Handled = True

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub GridView_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles Me.PopupMenuShowing

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim GridViewFooterMenu As DevExpress.XtraGrid.Menu.GridViewFooterMenu = Nothing

            If _ControlType = BandedDataGridView.Type.DynamicReport Then

                If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                    DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem("Change Header Text", New EventHandler(AddressOf OnChangeHeaderTextClick))

                    DXMenuItem.BeginGroup = True
                    DXMenuItem.Tag = DirectCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu).Column

                    e.Menu.Items.Add(DXMenuItem)

                    If e.HitInfo IsNot Nothing AndAlso e.HitInfo.Column IsNot Nothing AndAlso e.HitInfo.Column.UnboundType <> DevExpress.Data.UnboundColumnType.Bound Then

                        DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem("Edit", New EventHandler(AddressOf OnEditClick))

                        DXMenuItem.BeginGroup = True
                        DXMenuItem.Tag = DirectCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu).Column

                        e.Menu.Items.Add(DXMenuItem)

                        DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem("Delete", New EventHandler(AddressOf OnDeleteClick))

                        DXMenuItem.BeginGroup = False
                        DXMenuItem.Tag = DirectCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu).Column

                        e.Menu.Items.Add(DXMenuItem)

                    End If

                End If

            End If

        End Sub
        Private Sub GridView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Me.RowCellStyle

            If _EnableDisabledRows Then

                If IsRowDisabled(Me.GetDataSourceRowIndex(e.RowHandle)) Then

                    e.Appearance.BackColor = Drawing.Color.LightGray

                End If

            End If

        End Sub
        Private Sub GridView_ShowFilterPopupListBox(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs) Handles Me.ShowFilterPopupListBox

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim FilterItemsToRemove As IEnumerable(Of DevExpress.XtraGrid.Views.Grid.FilterItem) = Nothing
            Dim Values As Generic.List(Of Object) = Nothing

            If _ControlType = BandedDataGridView.Type.EditableGrid Then

                If e.Column.ColumnEdit IsNot Nothing Then

                    If TypeOf e.Column.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                        SubItemGridLookUpEditControl = DirectCast(e.Column.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                        If SubItemGridLookUpEditControl.ControlType = Controls.SubItemGridLookUpEditControl.Type.JobComponentID Then

                            If e.Column.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText Then

                                e.ComboBox.BeginUpdate()

                                FilterItemsToRemove = (From FilterItem In e.ComboBox.Items.OfType(Of DevExpress.XtraGrid.Views.Grid.FilterItem)()
                                                       Where FilterItem.Text <> DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.PopupFilterAll) AndAlso
                                                             FilterItem.Text <> DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.PopupFilterBlanks) AndAlso
                                                             FilterItem.Text <> DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.PopupFilterCustom) AndAlso
                                                             FilterItem.Text <> DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.PopupFilterNonBlanks)
                                                       Select FilterItem).ToList

                                For Each FilterItem In FilterItemsToRemove

                                    Try

                                        e.ComboBox.Items.Remove(FilterItem)

                                    Catch ex As Exception

                                    End Try

                                Next

                                Values = New Generic.List(Of Object)

                                For RowHandle = 0 To Me.RowCount - 1

                                    Values.Add(CShort(GetRowCellDisplayText(RowHandle, e.Column)))

                                Next

                                For Each JobComp In (From JobCompNbr In Values
                                                     Select [JobCompNbr] = CShort(JobCompNbr)
                                                     Order By JobCompNbr Ascending).Distinct.ToList

                                    e.ComboBox.Items.Insert(e.ComboBox.Items.Count, New DevExpress.XtraGrid.Views.Grid.FilterItem(JobComp.ToString, JobComp.ToString))

                                Next

                                e.ComboBox.EndUpdate()

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub GridView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.ShowingEditor

            SetNearestCanFocusColumn(Me.FocusedColumn)

            If _EnableDisabledRows Then

                e.Cancel = IsRowDisabled(Me.GetDataSourceRowIndex(Me.FocusedRowHandle))

            End If

        End Sub
        Private Sub GridView_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ShownEditor

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If Me.AutoFilterLookupColumns AndAlso _ControlType = BandedDataGridView.Type.EditableGrid Then

                Try

                    PropertyDescriptor = _ObjectTypePropertyDescriptors.Where(Function(Prop) Prop.Name = Me.FocusedColumn.FieldName).SingleOrDefault

                Catch ex As Exception
                    PropertyDescriptor = Nothing
                End Try

                If PropertyDescriptor IsNot Nothing Then

                    Try

                        EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                    Catch ex As Exception
                        EntityAttribute = Nothing
                    End Try

                    If EntityAttribute IsNot Nothing Then

                        If EntityAttribute.PropertyType <> BaseClasses.PropertyTypes.Default Then

                            Select Case EntityAttribute.PropertyType

                                Case BaseClasses.PropertyTypes.DivisionCode

                                    If TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                                        If GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.ClientCode) Is Nothing Then

                                            Me.CloseEditor()

                                        End If

                                    End If

                                Case BaseClasses.PropertyTypes.ProductCode

                                    If TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                                        If GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.ClientCode) Is Nothing OrElse
                                            GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.DivisionCode) Is Nothing Then

                                            Me.CloseEditor()

                                        End If

                                    End If

                                Case BaseClasses.PropertyTypes.JobComponent, BaseClasses.PropertyTypes.JobComponentID

                                    If TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                                        Try

                                            GridLookUpEdit = DirectCast(Me.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                                        Catch ex As Exception
                                            GridLookUpEdit = Nothing
                                        End Try

                                        If GridLookUpEdit IsNot Nothing Then

                                            If GetRowCellValueByPropertyType(Me.FocusedRowHandle, BaseClasses.PropertyTypes.JobNumber) IsNot Nothing Then

                                                If GridLookUpEdit.Properties.View.Columns("JobNumber") IsNot Nothing Then

                                                    GridLookUpEdit.Properties.View.Columns("JobNumber").Visible = False

                                                End If

                                            Else

                                                If GridLookUpEdit.Properties.View.Columns("JobNumber") IsNot Nothing Then

                                                    GridLookUpEdit.Properties.View.Columns("JobNumber").Visible = True

                                                End If

                                            End If

                                        End If

                                    End If

                            End Select

                        End If

                    End If

                End If

            End If

            Try

                If Me.ActiveEditor IsNot Nothing Then

                    If Me.ActiveEditor.Tag IsNot Nothing Then

                        Me.ActiveEditor.Tag.Tag = False

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub GridView_MainView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles Me.ValidateRow

            'objects 
            Dim CancelNewRow As Boolean = False

            If _RunStandardValidation Then

                If TypeOf e.Row Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                    If TypeOf e.Row Is AdvantageFramework.BaseClasses.Entity AndAlso _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).DbContext = DbContext

                            e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).ValidateEntity(e.Valid)

                        End Using

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.EntityBase AndAlso _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DataContext = DataContext
                                DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DbContext = DbContext

                                e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).ValidateEntity(e.Valid)

                            End Using

                        End Using

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.BaseClass AndAlso _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).DbContext = DbContext

                            e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).ValidateEntity(e.Valid)

                        End Using

                    Else

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntity(e.Valid)

                    End If

                    If Me.IsNewItemRow(e.RowHandle) = False Then

                        e.Valid = True

                    Else

                        Me.NewItemRowText = e.ErrorText

                        If e.Valid Then

                            RaiseEvent BeforeAddNewRowEvent(e.Row, CancelNewRow)

                            If CancelNewRow = False Then

                                RaiseEvent AddNewRowEvent(e.Row)

                            Else

                                e.Valid = False

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub GridView_MainView_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles Me.ValidatingEditor

            Dim FocusedRow As Object = Nothing

            FocusedRow = Me.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                If _RunStandardValidation Then

                    If TypeOf FocusedRow Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                        If TypeOf FocusedRow Is AdvantageFramework.BaseClasses.Entity AndAlso _Session IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                DirectCast(FocusedRow, AdvantageFramework.BaseClasses.Entity).DbContext = DbContext

                                e.ErrorText = DirectCast(FocusedRow, AdvantageFramework.BaseClasses.Entity).ValidateEntityProperty(Me.FocusedColumn.FieldName, e.Valid, e.Value)

                                e.Valid = True

                            End Using

                        ElseIf TypeOf FocusedRow Is AdvantageFramework.BaseClasses.EntityBase Then

                            e.ErrorText = DirectCast(FocusedRow, AdvantageFramework.BaseClasses.EntityBase).ValidateEntityProperty(Me.FocusedColumn.FieldName, e.Valid, e.Value)

                            e.Valid = True

                        ElseIf TypeOf FocusedRow Is AdvantageFramework.BaseClasses.BaseClass AndAlso _Session IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                DirectCast(FocusedRow, AdvantageFramework.BaseClasses.BaseClass).DbContext = DbContext

                                e.ErrorText = DirectCast(FocusedRow, AdvantageFramework.BaseClasses.BaseClass).ValidateEntityProperty(Me.FocusedColumn.FieldName, e.Valid, e.Value)

                                e.Valid = True

                            End Using

                        Else

                            e.ErrorText = DirectCast(FocusedRow, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntityProperty(Me.FocusedColumn.FieldName, e.Valid, e.Value)

                            e.Valid = True

                        End If

                    End If

                End If

            Else

                Try

                    FocusedRow = DirectCast(sender, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView).GetFocusedRow()

                Catch ex As Exception
                    FocusedRow = Nothing
                End Try

                If FocusedRow IsNot Nothing Then

                    If _RunStandardValidation Then

                        If TypeOf FocusedRow Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                            If TypeOf FocusedRow Is AdvantageFramework.BaseClasses.BaseClass Then

                                e.ErrorText = DirectCast(FocusedRow, AdvantageFramework.BaseClasses.BaseClass).ValidateEntityProperty(sender.FocusedColumn.FieldName, e.Valid, e.Value)

                                DirectCast(sender, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView).SetColumnError(sender.FocusedColumn, e.ErrorText)

                                e.Valid = True

                            End If

                        End If

                    End If

                End If

            End If

            If TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                If TypeOf Me.ActiveEditor.Tag Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                    If DirectCast(Me.ActiveEditor.Tag, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).IsNewValue Then

                        e.Valid = False
                        DirectCast(Me.ActiveEditor.Tag, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).IsNewValue = False
                        DirectCast(Me.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).ShowPopup()

                    End If

                End If

            End If

            If FocusedRow IsNot Nothing Then

                Try

                    AddToModifiedRows(Me.FocusedRowHandle)

                Catch ex As Exception

                End Try

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Protected Sub SubItemTextBox_ButtonClick()

            Dim RowObject As Object = Nothing

            If Me.OptionsBehavior.Editable Then

                RowObject = Me.GetFocusedRow

                If _ObjectType Is GetType(AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement) OrElse
                    _ObjectType Is GetType(AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement) Then

                    RaiseEvent SubItemTextBoxButtonClickEvent(RowObject)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
