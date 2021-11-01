Imports DevExpress.XtraGrid.Views.Grid

Namespace Media.Presentation

    Public Class DigitalResultsForm

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _StartDate As Date = Nothing
        Private _EndDate As Date = Nothing
        Private _IsFirstLoad As Boolean = True

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub SetInitialCriteria()

            'objects
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing

            StartDate = _StartDate
            EndDate = _EndDate

            If AdvantageFramework.WinForm.Presentation.SelectDateRangeDialog.ShowFormDialog(StartDate, EndDate) = Windows.Forms.DialogResult.OK Then

                _StartDate = StartDate
                _EndDate = EndDate

                Me.ShowWaitForm()

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                LoadGrid()

                Me.ClearChanged()

                EnableOrDisableActions()

                Me.FormAction = WinForm.Presentation.FormActions.None

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim LayoutLoaded As Boolean = False

            Me.ShowWaitForm()

            BindingSource = DataGridViewForm_DigitalResults.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing AndAlso Not _IsFirstLoad Then

                SaveGridLayout()

            End If

            DataGridViewForm_DigitalResults.SetBookmarkColumnIndex(-1)
            DataGridViewForm_DigitalResults.ClearGridCustomization()
            DataGridViewForm_DigitalResults.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.DigitalResultsView))
            DataGridViewForm_DigitalResults.ItemDescription = "Media Result(s)"

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_DigitalResults, Database.Entities.GridAdvantageType.MediaResults)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_DigitalResults.DataSource = AdvantageFramework.DigitalResults.LoadDigitalResultViews(DbContext, _StartDate, _EndDate, True)

            End Using

            _IsFirstLoad = False

            DataGridViewForm_DigitalResults.CurrentView.ViewCaption = DataGridViewForm_DigitalResults.CurrentView.RowCount & " Media Result(s)"

            If LayoutLoaded Then

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_DigitalResults)

            Else

                DataGridViewForm_DigitalResults.CurrentView.BestFitColumns()

                If DataGridViewForm_DigitalResults.CurrentView.Columns(AdvantageFramework.Database.Entities.DigitalResultsView.Properties.Note.ToString) IsNot Nothing Then

                    DataGridViewForm_DigitalResults.CurrentView.Columns(AdvantageFramework.Database.Entities.DigitalResultsView.Properties.Note.ToString).Width = 200

                End If

            End If

            ValidateRows(False)

            Me.CloseWaitForm()

        End Sub
        Private Sub SaveGridLayout()

            Dim AFActiveFilterString As String = Nothing

            AFActiveFilterString = DataGridViewForm_DigitalResults.CurrentView.AFActiveFilterString

            AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_DigitalResults, AdvantageFramework.Database.Entities.GridAdvantageType.MediaResults)

            DataGridViewForm_DigitalResults.CurrentView.AFActiveFilterString = AFActiveFilterString

        End Sub
        Private Sub ValidateRows(ByVal ModifiedOnly As Boolean)

            DataGridViewForm_DigitalResults.RunStandardValidation = False

            Try

                If ModifiedOnly Then

                    For Each DigitalResultsView In DataGridViewForm_DigitalResults.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Entities.DigitalResultsView)()

                        DigitalResultsView.ValidateUsingErrorObject()

                    Next

                Else

                    For Each DigitalResultsView In DataGridViewForm_DigitalResults.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.DigitalResultsView)()

                        DigitalResultsView.ValidateUsingErrorObject()

                    Next

                End If

            Catch ex As Exception

            End Try

            DataGridViewForm_DigitalResults.RunStandardValidation = True

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            ButtonItemActions_Delete.Enabled = DataGridViewForm_DigitalResults.HasASelectedRow

            ButtonItemActions_AutoFill.Enabled = DataGridViewForm_DigitalResults.HasASelectedRow

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Public Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim DigitalResultsViews As Generic.List(Of AdvantageFramework.Database.Entities.DigitalResultsView) = Nothing

            Try

                DataGridViewForm_DigitalResults.CurrentView.CloseEditorForUpdating()

                DigitalResultsViews = DataGridViewForm_DigitalResults.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Entities.DigitalResultsView).ToList

                DigitalResultsRefreshValidation(DigitalResultsViews)

                ValidateRows(True)

                If DataGridViewForm_DigitalResults.HasAnyInvalidRows = False Then

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Saving...")
                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each DigitalResultsView In DigitalResultsViews

                            AdvantageFramework.Database.Procedures.DigitalResult.Update(DbContext, DigitalResultsView.GetDigitalResultEntity(DbContext))

                        Next

                    End Using

                    Saved = True

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    Try

                        DataGridViewForm_DigitalResults.ClearChanged()

                        Me.ClearChanged()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid row(s).")

                End If

            Catch ex As Exception
                Saved = False
            Finally
                Save = Saved
            End Try

        End Function
        Private Sub SetDigitalResultsAutoFillDependentProperties(ByVal SelectedItems As IEnumerable)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AdvantageFramework.DigitalResults.SetDigitalResultsAutoFillDependentProperties(DbContext, SelectedItems)

            End Using

            DataGridViewForm_DigitalResults.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DigitalResultsRefreshValidation(ByVal SelectedItems As IEnumerable)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AdvantageFramework.DigitalResults.LoadValidationObjects(DbContext, SelectedItems.OfType(Of AdvantageFramework.Database.Entities.DigitalResultsView).ToList)

                End Using

            Catch ex As Exception

            End Try

            DataGridViewForm_DigitalResults.CurrentView.RefreshData()

        End Sub
        Private Sub ValidateAllRowsAndClearChanged()

            Try

                DataGridViewForm_DigitalResults.RunStandardValidation = False

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each DigitalResultsView In DataGridViewForm_DigitalResults.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.DigitalResultsView)()

                            DigitalResultsView.ValidateUsingErrorObject()

                        Next

                    End Using

                Catch ex As Exception

                End Try

                DataGridViewForm_DigitalResults.RunStandardValidation = True

            Catch ex As Exception

            End Try

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim DigitalResultsForm As AdvantageFramework.Media.Presentation.DigitalResultsForm = Nothing

            DigitalResultsForm = New AdvantageFramework.Media.Presentation.DigitalResultsForm

            DigitalResultsForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DigitalResultsForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                SaveGridLayout()

            End If

        End Sub
        Private Sub DigitalResultsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            _StartDate = System.DateTime.Today
            _EndDate = System.DateTime.Today

            DataGridViewForm_DigitalResults.AutoFilterLookupColumns = True
            DataGridViewForm_DigitalResults.AutoloadRepositoryDatasource = True

            DataGridViewForm_DigitalResults.CurrentView.OptionsLayout.StoreDataSettings = True
            DataGridViewForm_DigitalResults.CurrentView.OptionsLayout.StoreAppearance = True
            DataGridViewForm_DigitalResults.CurrentView.OptionsLayout.StoreVisualOptions = True

            DataGridViewForm_DigitalResults.AddFixedColumnCheckItemsToGridMenu = True
            DataGridViewForm_DigitalResults.OptionsCustomization.AllowColumnMoving = True
            DataGridViewForm_DigitalResults.OptionsMenu.EnableColumnMenu = True

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage

            ButtonItemGridOptions_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemData_Load.Image = AdvantageFramework.My.Resources.DatabaseLoadImage

            DataGridViewForm_DigitalResults.ClearGridCustomization()
            DataGridViewForm_DigitalResults.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.DigitalResultsView))
            AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_DigitalResults, Database.Entities.GridAdvantageType.MediaResults)

            DataGridViewForm_DigitalResults.CurrentView.ViewCaption = DataGridViewForm_DigitalResults.CurrentView.RowCount & " Media Result(s)"

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub DigitalResultsForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DigitalResultsForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DigitalResultsForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Try

                SetInitialCriteria()

            Catch ex As Exception

            End Try

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim DigitalResultsViewList As Generic.List(Of AdvantageFramework.Database.Entities.DigitalResultsView) = Nothing
            Dim LayoutLoaded As Boolean = False

            DigitalResultsViewList = DataGridViewForm_DigitalResults.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.DigitalResultsView)().ToList

            SaveGridLayout()

            DataGridViewForm_Export.ClearGridCustomization()
            DataGridViewForm_Export.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.DigitalResultsView))

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_Export, Database.Entities.GridAdvantageType.MediaResults)

            Try

                DataGridViewForm_Export.DataSource = DigitalResultsViewList

            Catch ex As Exception

            End Try

            If LayoutLoaded Then

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_Export)

            End If

            'https://www.devexpress.com/Support/Center/Question/Details/Q383062
            DataGridViewForm_Export.CurrentView.ClearDocument()
            DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint()
            DataGridViewForm_Export.CurrentView.OptionsView.ColumnAutoWidth = False
            DataGridViewForm_Export.CurrentView.BestFitColumns()
            DataGridViewForm_Export.CurrentView.OptionsPrint.AutoWidth = False
            DevExpress.Utils.Paint.XPaint.ForceAPIPaint()

            DataGridViewForm_Export.Print(DefaultLookAndFeel.LookAndFeel, "Media Result(s)", UseLandscape:=True)

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim DigitalResultsView As AdvantageFramework.Database.Entities.DigitalResultsView = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_DigitalResults.HasASelectedRow Then

                DataGridViewForm_DigitalResults.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_DigitalResults.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    DigitalResultsView = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    DigitalResultsView = Nothing
                                End Try

                                If DigitalResultsView IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.DigitalResult.Delete(DbContext, DigitalResultsView.GetDigitalResultEntity(DbContext)) Then

                                        DataGridViewForm_DigitalResults.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_DigitalResults.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemGridOptions_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGridOptions_ChooseColumns.Checked Then

                    If DataGridViewForm_DigitalResults.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewForm_DigitalResults.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewForm_DigitalResults.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewForm_DigitalResults.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptions_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_RestoreDefaults.Click

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.MediaResults, Session.UserCode)

            End Using

            DataGridViewForm_DigitalResults.ClearDatasource()

            LoadGrid()

        End Sub
        Private Sub DataGridViewForm_DigitalResults_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_DigitalResults.CellValueChangedEvent

            'objects
            Dim DigitalResultsView As AdvantageFramework.Database.Entities.DigitalResultsView = Nothing
            Dim RefreshGrid As Boolean = False

            Try

                DigitalResultsView = DataGridViewForm_DigitalResults.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                DigitalResultsView = Nothing
            End Try

            If DigitalResultsView IsNot Nothing Then

                AdvantageFramework.DigitalResults.ProcessCellValueChanged(Me.Session, e.Column.FieldName, e.Value, RefreshGrid, DigitalResultsView)

                If RefreshGrid Then

                    DataGridViewForm_DigitalResults.CurrentView.RefreshRow(e.RowHandle)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_DigitalResults_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_DigitalResults.HideCustomizationFormEvent

            If ButtonItemGridOptions_ChooseColumns.Checked Then

                ButtonItemGridOptions_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewForm_DigitalResults_PopupMenuShowingEvent(sender As Object, e As PopupMenuShowingEventArgs) Handles DataGridViewForm_DigitalResults.PopupMenuShowingEvent

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each DXMenuItem In e.Menu.Items

                    If DXMenuItem.Tag IsNot Nothing AndAlso DXMenuItem.Tag.GetType Is GetType(DevExpress.XtraGrid.Localization.GridStringId) Then

                        If CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup OrElse
                                CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox Then

                            DXMenuItem.Visible = False

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewForm_DigitalResults_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_DigitalResults.QueryPopupNeedDatasourceEvent

            'objects
            Dim DigitalResultsView As AdvantageFramework.Database.Entities.DigitalResultsView = Nothing

            Try

                DigitalResultsView = DataGridViewForm_DigitalResults.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                DigitalResultsView = Nothing
            End Try

            If DigitalResultsView IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AdvantageFramework.DigitalResults.LoadColumnEditorDatasouce(DbContext, DigitalResultsView, FieldName, OverrideDefaultDatasource, Datasource)

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_DigitalResults_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_DigitalResults.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_DigitalResults_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_DigitalResults.ShowingEditorEvent

            'objects
            Dim DigitalResultsView As AdvantageFramework.Database.Entities.DigitalResultsView = Nothing

            Try

                DigitalResultsView = DataGridViewForm_DigitalResults.CurrentView.GetRow(DataGridViewForm_DigitalResults.CurrentView.FocusedRowHandle)

            Catch ex As Exception
                DigitalResultsView = Nothing
            End Try

            If DigitalResultsView IsNot Nothing Then

                e.Cancel = AdvantageFramework.DigitalResults.ProcessShowingEditor(DataGridViewForm_DigitalResults.CurrentView.FocusedColumn.FieldName, DigitalResultsView)

            End If

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Import.Click

            AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.DigitalResults)

        End Sub
        Private Sub ButtonItemActions_AutoFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_AutoFill.Click

            'objects
            Dim ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
            Dim SelectedItems As IEnumerable = Nothing

            DataGridViewForm_DigitalResults.CurrentView.CloseEditorForUpdating()

            ImportTemplateType = Importing.ImportTemplateTypes.DigitalResults_Default

            SelectedItems = DataGridViewForm_DigitalResults.GetAllSelectedRowsDataBoundItems

            If AdvantageFramework.Importing.Presentation.ImportDefaultsDialog.ShowFormDialog(ImportTemplateType, SelectedItems) = Windows.Forms.DialogResult.OK Then

                For Each RowHandle In DataGridViewForm_DigitalResults.CurrentView.GetSelectedRows

                    DataGridViewForm_DigitalResults.AddToModifiedRows(RowHandle)

                Next

                SetDigitalResultsAutoFillDependentProperties(SelectedItems)

                DigitalResultsRefreshValidation(SelectedItems)

                ValidateAllRowsAndClearChanged()

                DataGridViewForm_DigitalResults.CurrentView.RefreshData()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemData_Load_Click(sender As Object, e As EventArgs) Handles ButtonItemData_Load.Click

            If CheckForUnsavedChanges() Then

                SetInitialCriteria()

            End If

        End Sub
        Private Sub DataGridViewForm_DigitalResults_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_DigitalResults.ShownEditorEvent

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim DigitalResultsView As AdvantageFramework.Database.Entities.DigitalResultsView = Nothing

            If DataGridViewForm_DigitalResults.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.DigitalResultsView.Properties.EstimateID.ToString Then

                If TypeOf DataGridViewForm_DigitalResults.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DirectCast(DataGridViewForm_DigitalResults.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                    If GridLookUpEdit.Properties.View.Columns("ID") IsNot Nothing Then

                        GridLookUpEdit.Properties.View.Columns("ID").VisibleIndex = 0
                        GridLookUpEdit.Properties.View.Columns("ID").Visible = True

                    End If

                End If

            ElseIf DataGridViewForm_DigitalResults.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.DigitalResultsView.Properties.VendorCode.ToString Then

                DigitalResultsView = DirectCast(DataGridViewForm_DigitalResults.CurrentView.GetRow(DataGridViewForm_DigitalResults.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.DigitalResultsView)

                If DigitalResultsView IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(DigitalResultsView.MediaType) AndAlso TypeOf DataGridViewForm_DigitalResults.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DirectCast(DataGridViewForm_DigitalResults.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                    GridLookUpEdit.Properties.View.ActiveFilterString = "Category = '" & DigitalResultsView.MediaType & "'"

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
