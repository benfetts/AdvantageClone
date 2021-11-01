Namespace WinForm.MVC.Presentation.Controls

	Public Class GridView
		Inherits DevExpress.XtraGrid.Views.Grid.GridView

		Public Event ColumnAddedEvent(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)
		Public Event AddNewRowEvent(ByVal RowObject As Object)
		Public Event ColumnEditValueChangedEvent(sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
		Public Event RepositoryDataSourceLoadingEvent(ByVal FieldName As String, ByRef Datasource As Object)
		Public Event QueryPopupNeedDatasource(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)
		Public Event AlterSubItemGridLookupEditPropertiesEvent(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl)
		Public Event ColumnEditValueChangingEvent(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
		Public Event SubItemGridLookUpEditControlEditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

#Region " Constants "



#End Region

#Region " Enum "

		Private Enum ImageIndexes
			DeleteImage = 0
		End Enum

#End Region

#Region " Variables "

		Protected _ObjectType As System.Type = Nothing
		Protected _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
		Protected _EnableDisabledRows As Boolean = False
		Protected _DisabledRows As List(Of AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow) = Nothing
		Protected _FilterPopupMode As DevExpress.XtraGrid.Columns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Default
		Protected _ChangedRows As Generic.List(Of Object) = Nothing
		Protected _IsInGridLookupEditControl As Boolean = False
		Protected _HasDataSourceBeenChanged As Boolean = False
        Protected _RestoredLayoutNonVisibleGridColumnList As Generic.List(Of DevExpress.XtraGrid.Columns.GridColumn) = Nothing

#End Region

#Region " Properties "

        Friend Property FilterPopupMode As DevExpress.XtraGrid.Columns.FilterPopupMode
			Get
				FilterPopupMode = _FilterPopupMode
			End Get
			Set(ByVal value As DevExpress.XtraGrid.Columns.FilterPopupMode)
				_FilterPopupMode = value
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

				Me.RefreshData()

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
		Public WriteOnly Property IsInGridLookupEditControl As Boolean
			Set(value As Boolean)
				_IsInGridLookupEditControl = value
			End Set
		End Property
		'Protected Overrides ReadOnly Property ViewName As String
		'	Get
		'		If _IsInGridLookupEditControl Then

		'			ViewName = MyBase.ViewName

		'		Else

		'			ViewName = "GridViewControl"

		'		End If
		'	End Get
		'End Property
		Public Property ModifyGridRowHeight As Boolean
		Public Property ModifyColumnSettingsOnEachDataSource As Boolean = True
        Public Property RestoredLayoutNonVisibleGridColumnList As Generic.List(Of DevExpress.XtraGrid.Columns.GridColumn)
            Get
                RestoredLayoutNonVisibleGridColumnList = _RestoredLayoutNonVisibleGridColumnList
            End Get
            Set(value As Generic.List(Of DevExpress.XtraGrid.Columns.GridColumn))
                _RestoredLayoutNonVisibleGridColumnList = value
            End Set
        End Property
        Public Property SkipAddingControlsOnModifyColumn As Boolean
        Public Property SkipSettingFontOnModifyColumn As Boolean

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

            Me.SkipAddingControlsOnModifyColumn = False
            Me.SkipSettingFontOnModifyColumn = False

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

			If Me.GridControl IsNot Nothing AndAlso TypeOf Me.GridControl.FindForm Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

				If CType(Me.GridControl.FindForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).IsFormClosing = False Then

					MyBase.OnDataController_DataSourceChanged(sender, e)

				End If

			Else

				MyBase.OnDataController_DataSourceChanged(sender, e)

			End If

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
		Protected Sub ColumnEditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

			RaiseEvent ColumnEditValueChangingEvent(sender, e)

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
		Protected Sub AddSubItemComboBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemComboBox As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemComboBox)

			Me.GridControl.RepositoryItems.Add(SubItemComboBox)

			GridColumn.ColumnEdit = SubItemComboBox

		End Sub
		Protected Sub AddSubItemGridLookupEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl)

			If SubItemGridLookUpEditControl IsNot Nothing Then

				RaiseEvent AlterSubItemGridLookupEditPropertiesEvent(GridColumn, SubItemGridLookUpEditControl)

				RaiseEvent RepositoryDataSourceLoadingEvent(GridColumn.FieldName, SubItemGridLookUpEditControl.DataSource)

				Me.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

				GridColumn.ColumnEdit = SubItemGridLookUpEditControl

				AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControl_QueryPopup
				AddHandler SubItemGridLookUpEditControl.EditValueChanging, AddressOf SubItemGridLookUpEditControl_EditValueChanging

			End If

		End Sub
		Protected Sub SubItemGridLookUpEditControl_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

			RaiseEvent SubItemGridLookUpEditControlEditValueChanging(sender, e)

		End Sub
		Protected Sub SubItemGridLookUpEditControl_QueryPopup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

			'objects
			Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
			Dim DataSource As Object = Nothing
			Dim OverrideDefaultDatasource As Boolean = False
			Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
			Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
			Dim ContinueLoad As Boolean = True

			If TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

				GridLookUpEdit = Me.ActiveEditor

				If e.Cancel = True Then

					If String.IsNullOrWhiteSpace(GridLookUpEdit.Text) = False Then

						ContinueLoad = False

					End If

				End If

				If ContinueLoad Then

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

					If DataSource IsNot Nothing Then

						BindingSource = New System.Windows.Forms.BindingSource

						BindingSource.DataSource = DataSource

						GridLookUpEdit.Properties.DataSource = BindingSource

						If TypeOf Me.FocusedColumn.ColumnEdit Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl Then

							SubItemGridLookUpEditControl = DirectCast(Me.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl)

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
		Protected Sub AddSubItemMemoEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemMemoEdit As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemMemoEdit)

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
		Protected Sub AddSubItemTextBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemTextBoxType As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemTextBox.Type)

			'objects
			Dim SubItemTextBox As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemTextBox = Nothing

			SubItemTextBox = AdvantageFramework.WinForm.MVC.Presentation.Controls.CreateSubItemTextBox(SubItemTextBoxType, GridColumn.FieldName, _ObjectType)

			If SubItemTextBox IsNot Nothing Then

				AddSubItemTextBox(GridColumn, SubItemTextBox)

			End If

		End Sub
		Protected Sub AddSubItemTextBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemTextBox As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemTextBox)

			Me.GridControl.RepositoryItems.Add(SubItemTextBox)

			GridColumn.ColumnEdit = SubItemTextBox

			AddHandler SubItemTextBox.EditValueChanged, AddressOf ColumnEditValueChanged

		End Sub
		Protected Sub AddSubItemTimeEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItemTimeEdit As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit)

			Me.GridControl.RepositoryItems.Add(RepositoryItemTimeEdit)

			GridColumn.ColumnEdit = RepositoryItemTimeEdit

		End Sub
		Protected Sub AddSubItemDateEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

			Dim SubItemDateInput As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput = Nothing

			SubItemDateInput = AdvantageFramework.WinForm.MVC.Presentation.Controls.CreateSubItemDateEdit()

			If SubItemDateInput IsNot Nothing Then

				SubItemDateInput.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput.Type.Default
				AddSubItemDateEdit(GridColumn, SubItemDateInput)

			End If

		End Sub
		Protected Sub AddSubItemDateEdit(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemDateInput As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput)

			Me.GridControl.RepositoryItems.Add(SubItemDateInput)

			GridColumn.ColumnEdit = SubItemDateInput

		End Sub
		Protected Sub AddSubItemImageComboBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef SubItemImageComboBox As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageComboBox)

			Me.GridControl.RepositoryItems.Add(SubItemImageComboBox)

			GridColumn.ColumnEdit = SubItemImageComboBox

		End Sub
		Protected Sub AddSubItemHyperLink(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItemHyperLinkEdit As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit)

			Me.GridControl.RepositoryItems.Add(RepositoryItemHyperLinkEdit)

			GridColumn.ColumnEdit = RepositoryItemHyperLinkEdit

		End Sub
		Protected Sub AddSubItemColorPicker(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItemColorEdit As DevExpress.XtraEditors.Repository.RepositoryItemColorEdit)

			Me.GridControl.RepositoryItems.Add(RepositoryItemColorEdit)

			GridColumn.ColumnEdit = RepositoryItemColorEdit

		End Sub
		Protected Sub AddSubItemCheckBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal IsReversedCheckBox As Boolean, ByVal PropertyType As System.Type)

			'objects
			Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

			RepositoryItemCheckEdit = AdvantageFramework.WinForm.MVC.Presentation.Controls.CreateSubItemCheckBox(IsReversedCheckBox, PropertyType)

			If RepositoryItemCheckEdit IsNot Nothing Then

				AddSubItemCheckBox(GridColumn, RepositoryItemCheckEdit)

			End If

		End Sub
		Protected Sub AddSubItemCheckBox(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit)

			Me.GridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

			GridColumn.ColumnEdit = RepositoryItemCheckEdit

			AddHandler RepositoryItemCheckEdit.EditValueChanging, AddressOf ColumnEditValueChanging

		End Sub
		Protected Sub AddSubItemNumericInput(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemNumericInputType As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type, ByVal IsNullable As Boolean, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

			'objects
			Dim SubItemNumericInput As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput = Nothing
			Dim FormatString As String = ""

			If GridColumn.DisplayFormat IsNot Nothing Then

				FormatString = GridColumn.DisplayFormat.FormatString

			End If

			SubItemNumericInput = AdvantageFramework.WinForm.MVC.Presentation.Controls.CreateSubItemNumericInput(SubItemNumericInputType, GridColumn.FieldName, FormatString, IsNullable, _ObjectType, EntityAttribute)

			If SubItemNumericInput IsNot Nothing Then

				AddSubItemNumericInput(GridColumn, SubItemNumericInput)

			End If

		End Sub
		Protected Sub AddSubItemNumericInput(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal SubItemNumericInput As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput)

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
		Protected Sub AddSubItemByPropertyTypeAttribute(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

			'objects
			Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
			Dim FormatString As String = ""

			If AddCustomSubItem(GridColumn, PropertyType, PropertyDescriptor, EntityAttribute) = False Then

				If GridColumn.DisplayFormat IsNot Nothing Then

					FormatString = GridColumn.DisplayFormat.FormatString

				End If

				RepositoryItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.CreateSubItemByPropertyTypeAttribute(GridColumn.FieldName, PropertyType, PropertyDescriptor, EntityAttribute, _ObjectType, FormatString, True)

				If RepositoryItem IsNot Nothing Then

					AddSubItemToGridColumn(GridColumn, RepositoryItem)

				End If

			End If

		End Sub
		Protected Sub AddSubItemToGridColumn(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByRef RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem)

			If TypeOf RepositoryItem Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl Then

				AddSubItemGridLookupEdit(GridColumn, RepositoryItem)

			ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemComboBox Then

				AddSubItemComboBox(GridColumn, RepositoryItem)

			ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemTextBox Then

				AddSubItemTextBox(GridColumn, RepositoryItem)

			ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput Then

				AddSubItemDateEdit(GridColumn, RepositoryItem)

			ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageComboBox Then

				AddSubItemImageComboBox(GridColumn, RepositoryItem)

			ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput Then

				AddSubItemNumericInput(GridColumn, RepositoryItem)

			ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemMemoEdit Then

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
		Protected Sub AddSubItemByDefaultColumnTypeAttribute(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

			'objects
			Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
			Dim FormatString As String = ""

			Select Case DefaultColumnType

				Case AdvantageFramework.BaseClasses.DefaultColumnTypes.JobComponentDescription,
					AdvantageFramework.BaseClasses.DefaultColumnTypes.JobDescription,
					AdvantageFramework.BaseClasses.DefaultColumnTypes.OfficeName,
					AdvantageFramework.BaseClasses.DefaultColumnTypes.DepartmentTeamName,
					AdvantageFramework.BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription,
					AdvantageFramework.BaseClasses.DefaultColumnTypes.Memo,
					AdvantageFramework.BaseClasses.DefaultColumnTypes.StateName

					If GridColumn.DisplayFormat IsNot Nothing Then

						FormatString = GridColumn.DisplayFormat.FormatString

					End If

					RepositoryItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.CreateSubItemByDefaultColumnTypeAttribute(DefaultColumnType, GridColumn.FieldName, FormatString, PropertyDescriptor, EntityAttribute, _ObjectType)

					If RepositoryItem IsNot Nothing Then

						AddSubItemToGridColumn(GridColumn, RepositoryItem)

					End If

				Case Else

					AddSubItemByDefaultColumnTypeAttribute(GridColumn, DefaultColumnType, PropertyDescriptor.PropertyType)

			End Select

		End Sub
		Protected Sub AddSubItemByDefaultColumnTypeAttribute(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes, ByVal ValueType As System.Type)

			'objects
			Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
			Dim FormatString As String = ""

			If GridColumn.DisplayFormat IsNot Nothing Then

				FormatString = GridColumn.DisplayFormat.FormatString

			End If

			RepositoryItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.CreateSubItemByDefaultColumnTypeAttribute(DefaultColumnType, GridColumn.FieldName, FormatString, ValueType, _ObjectType)

			If RepositoryItem IsNot Nothing Then

				AddSubItemToGridColumn(GridColumn, RepositoryItem)

			End If

		End Sub
		Protected Sub AddSubItem(ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

			'objects
			Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = Nothing
			Dim DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes = Nothing
			Dim RepositoryItemTimeEdit As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit = Nothing

			If EntityAttribute IsNot Nothing Then

				Try

					PropertyType = EntityAttribute.PropertyType

				Catch ex As Exception
					PropertyType = AdvantageFramework.BaseClasses.PropertyTypes.Default
				End Try

				Try

					DefaultColumnType = EntityAttribute.DefaultColumnType

				Catch ex As Exception
					DefaultColumnType = AdvantageFramework.BaseClasses.DefaultColumnTypes.None
				End Try

			End If

			If GridColumn.OptionsColumn.ReadOnly = False Then

				If PropertyType <> AdvantageFramework.BaseClasses.PropertyTypes.Default Then

					AddSubItemByPropertyTypeAttribute(GridColumn, PropertyType, PropertyDescriptor, EntityAttribute)

				ElseIf DefaultColumnType <> AdvantageFramework.BaseClasses.DefaultColumnTypes.None Then

					AddSubItemByDefaultColumnTypeAttribute(GridColumn, DefaultColumnType, PropertyDescriptor, EntityAttribute)

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

				AddSubItemTextBox(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemTextBox.Type.Default)

			ElseIf PropertyType Is GetType(Decimal) Then

				AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Decimal, False, EntityAttribute)

			ElseIf PropertyType Is GetType(System.Nullable(Of Decimal)) Then

				AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Decimal, True, EntityAttribute)

			ElseIf PropertyType Is GetType(Double) Then

				AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Double, True, EntityAttribute)

			ElseIf PropertyType Is GetType(System.Nullable(Of Double)) Then

				AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Double, True, EntityAttribute)

			ElseIf PropertyType Is GetType(Long) Then

				AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Long, False, EntityAttribute)

			ElseIf PropertyType Is GetType(Integer) Then

				AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Integer, False, EntityAttribute)

			ElseIf PropertyType Is GetType(Short) Then

				AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Short, False, EntityAttribute)

			ElseIf PropertyType Is GetType(System.Nullable(Of Long)) Then

				AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Long, True, EntityAttribute)

			ElseIf PropertyType Is GetType(System.Nullable(Of Integer)) Then

				AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Integer, True, EntityAttribute)

			ElseIf PropertyType Is GetType(System.Nullable(Of Short)) Then

				AddSubItemNumericInput(GridColumn, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Short, True, EntityAttribute)

			ElseIf PropertyType Is GetType(System.Nullable(Of Boolean)) OrElse
					PropertyType Is GetType(Boolean) Then

				AddSubItemCheckBox(GridColumn, False, GetType(Boolean))

			ElseIf PropertyType Is GetType(System.Nullable(Of Date)) OrElse
					PropertyType Is GetType(Date) Then

				AddSubItemDateEdit(GridColumn)

			End If

		End Sub
		Protected Sub ModifyColumn(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

			'objects
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
			Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
			Dim CanAddGridColumnRepositoryItem As Boolean = True

			GridColumn.Name = GridColumn.FieldName

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

            If Me.SkipSettingFontOnModifyColumn = False Then

                SetGridColumnAppearanceDefaults(GridColumn)

            End If

            If PropertyDescriptor IsNot Nothing AndAlso Me.SkipAddingControlsOnModifyColumn = False Then

                If PropertyDescriptor.PropertyType IsNot GetType(System.String) Then

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

                    Else

                        If PropertyDescriptor.PropertyType Is GetType(System.DateTime) OrElse
                                PropertyDescriptor.PropertyType Is GetType(Date) OrElse
                                PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of System.DateTime)) OrElse
                                PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of Date)) Then

                            GridColumn.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value

                        End If

                    End If

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

                            ElseIf EntityAttribute.DisplayFormat.StartsWith("t") Then

                                GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                            End If

							GridColumn.DisplayFormat.FormatString = EntityAttribute.DisplayFormat

						End If

						If EntityAttribute.CustomColumnCaption <> "" Then

							GridColumn.Caption = EntityAttribute.CustomColumnCaption

						ElseIf EntityAttribute.PropertyType <> AdvantageFramework.BaseClasses.PropertyTypes.Default Then

							Select Case EntityAttribute.PropertyType

								Case AdvantageFramework.BaseClasses.PropertyTypes.ClientCode, AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode,
										AdvantageFramework.BaseClasses.PropertyTypes.ProductCode, AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode

									GridColumn.Caption = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.BaseClasses.PropertyTypes), CLng(EntityAttribute.PropertyType)).Replace("Code", "")

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

				If GridColumn.ColumnEdit Is Nothing AndAlso CanAddGridColumnRepositoryItem Then

					AddSubItem(GridColumn, PropertyDescriptor, EntityAttribute)

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

			Me.OptionsBehavior.AutoPopulateColumns = True

			Me.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
			Me.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
			Me.OptionsBehavior.Editable = False

		End Sub
		Protected Sub ModifyViewOptions()

			Me.OptionsView.ColumnAutoWidth = False
			Me.OptionsView.ShowFooter = False
			Me.OptionsView.ShowGroupPanel = False
			Me.OptionsView.ShowViewCaption = True

		End Sub
		Protected Sub ModifySelectionOptions()

			Me.OptionsSelection.MultiSelect = True

		End Sub
		Protected Sub ModifyCustomizationOptions()

			Me.OptionsCustomization.AllowGroup = True
			Me.OptionsCustomization.AllowSort = True
			Me.OptionsCustomization.AllowFilter = True
			Me.OptionsCustomization.AllowColumnMoving = True
			Me.OptionsCustomization.AllowQuickHideColumns = False

		End Sub
		Protected Sub ModifyMenuOptions()

			Me.OptionsMenu.ShowGroupSummaryEditorItem = False
			Me.OptionsMenu.EnableColumnMenu = True

		End Sub
		Protected Sub ModifyNavigationOptions()

			Me.OptionsNavigation.EnterMoveNextColumn = True

		End Sub
		Protected Sub ModifyFilterOptions()

			Me.OptionsFilter.ShowAllTableValuesInFilterPopup = False

		End Sub
		Protected Sub ModifyLayoutOptions()

			Me.OptionsLayout.StoreAllOptions = False
			Me.OptionsLayout.StoreAppearance = False
			Me.OptionsLayout.Columns.StoreAllOptions = False
			Me.OptionsLayout.Columns.StoreAppearance = False

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
		Protected Overrides Function CreateFindPanel(ByVal FindPanelProperties As Object) As DevExpress.XtraGrid.Controls.FindControl

			CreateFindPanel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.FindPanel(Me, FindPanelProperties)

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

				IsRowDisabledAsDeleted = DisabledRows.Where(Function(dr) dr.DataSourceRowIndex = DataSourceRowIndex AndAlso dr.DisabledRowType = AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow.RowType.Deleted).Any

			Else

				IsRowDisabledAsDeleted = False

			End If

		End Function
		Public Function IsRowDisabledAsReadonly(ByVal DataSourceRowIndex As Integer) As Boolean

			If _EnableDisabledRows Then

				IsRowDisabledAsReadonly = DisabledRows.Where(Function(dr) dr.DataSourceRowIndex = DataSourceRowIndex AndAlso dr.DisabledRowType = AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow.RowType.Readonly).Any

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
		Public Sub RaiseBeforeLeaveRowEvent()

			Me.RaiseBeforeLeaveRow(New DevExpress.XtraGrid.Views.Base.RowAllowEventArgs(Me.FocusedRowHandle, True))

		End Sub
		Protected Sub SetGridColumnAppearanceDefaults(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

			GridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
			GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

		End Sub
		Public Sub ForceMoveNext()

			Me.DoMoveFocusedRow(1, New Windows.Forms.KeyEventArgs(Windows.Forms.Keys.Down))

		End Sub
		Public Sub ForceMovePrev()

			Me.DoMoveFocusedRow(-1, New Windows.Forms.KeyEventArgs(Windows.Forms.Keys.Up))

		End Sub

#Region "  Control Event Handlers "

		Private Sub GridView_CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles Me.CustomDrawRowIndicator

			If _EnableDisabledRows Then

				If e.Info.IsRowIndicator AndAlso e.RowHandle >= 0 Then

					For DataSourceRowIndex As Integer = 0 To _DisabledRows.Count - 1

						If GetDataSourceRowIndex(e.RowHandle) = _DisabledRows(DataSourceRowIndex).DataSourceRowIndex AndAlso _DisabledRows(DataSourceRowIndex).DisabledRowType = AdvantageFramework.WinForm.Presentation.Controls.Classes.DisabledRow.RowType.Deleted Then

							e.Painter.DrawObject(e.Info)
							e.Graphics.DrawImageUnscaled(AdvantageFramework.My.Resources.SmallDetailDeleteImage, e.Bounds)

							e.Handled = True

						End If

					Next

				End If

			End If

		End Sub
		Private Sub GridView_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataSourceChanged

			If _HasDataSourceBeenChanged = False OrElse Me.ModifyColumnSettingsOnEachDataSource = True Then

				For Each Column In Me.Columns

					ModifyColumn(Column)

					RaiseEvent ColumnAddedEvent(Column)

				Next

			End If

			_HasDataSourceBeenChanged = True

		End Sub
		Private Sub GridView_MainView_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles Me.InvalidRowException

			e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction

		End Sub
		Private Sub GridView_MainView_InvalidValueException(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles Me.InvalidValueException

			e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction

		End Sub
		Private Sub GridView_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles Me.CustomColumnDisplayText

			If _IsInGridLookupEditControl Then

				Try

					If IsNumeric(e.DisplayText) AndAlso Decimal.TryParse(e.DisplayText, 0) AndAlso CDec(e.DisplayText) < 0 AndAlso e.DisplayText.StartsWith("-") = True Then

						e.DisplayText = ""

					End If

				Catch ex As Exception

				End Try

			End If

		End Sub
		Private Sub GridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

			If e.Control Then

				If Me.FocusedColumn IsNot Nothing AndAlso Me.FocusedColumn.VisibleIndex = -1 Then

					e.Handled = True
					e.SuppressKeyPress = True

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
		Private Sub GridView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.ShowingEditor

			If _EnableDisabledRows AndAlso e.Cancel = False Then

				e.Cancel = IsRowDisabled(Me.GetDataSourceRowIndex(Me.FocusedRowHandle))

			End If

		End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

	End Class

End Namespace
