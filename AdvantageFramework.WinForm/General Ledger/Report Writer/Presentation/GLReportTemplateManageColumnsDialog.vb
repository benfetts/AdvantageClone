Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplateManageColumnsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private WithEvents _ColumnsDataTable As System.Data.DataTable = Nothing
        Private _RowsDataTable As System.Data.DataTable = Nothing
        Private _PercentOfRowColumnDataTable As System.Data.DataTable = Nothing
        Private _ReportType As ReportTypes = ReportTypes.IncomeStatement
        Private _GLReportTemplateColumnDescriptionMaxLength As Integer = -1
        Private _GLReportTemplateColumnNameMaxLength As Integer = -1

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ColumnsDataTable As System.Data.DataTable, ByVal RowsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable, ByVal ReportType As ReportTypes)

            ' This call is required by the designer.
            InitializeComponent()

            _ColumnsDataTable = ColumnsDataTable
            _RowsDataTable = RowsDataTable
            _PercentOfRowColumnDataTable = PercentOfRowColumnDataTable
            _ReportType = ReportType

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            DataGridViewForm_Columns.ClearGridCustomization()

            DataGridViewForm_Columns.DataSource = _ColumnsDataTable

            For Each GridColumn In DataGridViewForm_Columns.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = ColumnFields.Name.ToString Then

                    GridColumn.Visible = True
                    AddSubItemTextBox(Me.Session, DataGridViewForm_Columns, GridColumn, _GLReportTemplateColumnNameMaxLength)

                ElseIf GridColumn.FieldName = ColumnFields.Description.ToString Then

                    GridColumn.Visible = True
                    AddSubItemTextBox(Me.Session, DataGridViewForm_Columns, GridColumn, _GLReportTemplateColumnDescriptionMaxLength)

                ElseIf GridColumn.FieldName = ColumnFields.Type.ToString Then

                    GridColumn.Caption = "Column Type"
                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ReadOnly = True
                    GridColumn.OptionsColumn.AllowEdit = False

                ElseIf GridColumn.FieldName = ColumnFields.IsVisible.ToString Then

                    GridColumn.Visible = True

                ElseIf GridColumn.FieldName = ColumnFields.UnderlineColumnHeader.ToString Then

                    GridColumn.Caption = "Underline Column Header"
                    GridColumn.Visible = True

                ElseIf GridColumn.FieldName = ColumnFields.UseCurrencyFormat.ToString Then

                    GridColumn.Caption = "Use Currency Format"
                    GridColumn.Visible = True

                ElseIf GridColumn.FieldName = ColumnFields.NumberOfDecimalPlaces.ToString Then

                    GridColumn.Caption = "Number Of Decimal Places"
                    GridColumn.Visible = True
                    AddSubItemNumericInput(Me.Session, DataGridViewForm_Columns, GridColumn, WinForm.Presentation.Controls.SubItemNumericInput.Type.Integer, 6, 0)

                Else

                    GridColumn.Visible = False

                End If

            Next

            For Each GridColumn In DataGridViewForm_Columns.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = ColumnFields.Name.ToString Then

                    GridColumn.VisibleIndex = 0

                ElseIf GridColumn.FieldName = ColumnFields.Description.ToString Then

                    GridColumn.VisibleIndex = 1

                ElseIf GridColumn.FieldName = ColumnFields.Type.ToString Then

                    GridColumn.VisibleIndex = 2

                ElseIf GridColumn.FieldName = ColumnFields.IsVisible.ToString Then

                    GridColumn.VisibleIndex = 3

                ElseIf GridColumn.FieldName = ColumnFields.UnderlineColumnHeader.ToString Then

                    GridColumn.VisibleIndex = 4

                ElseIf GridColumn.FieldName = ColumnFields.UseCurrencyFormat.ToString Then

                    GridColumn.VisibleIndex = 5

                ElseIf GridColumn.FieldName = ColumnFields.NumberOfDecimalPlaces.ToString Then

                    GridColumn.VisibleIndex = 6

                End If

            Next

            DataGridViewForm_Columns.CurrentView.BestFitColumns()

        End Sub
        Public Sub AddSubItemTextBox(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal MaxLength As Long)

            'objects
            Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

            RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            RepositoryItemButtonEdit.ValidateOnEnterKey = True

            If MaxLength <> -1 Then

                RepositoryItemButtonEdit.MaxLength = MaxLength

            End If

            For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                    EditorButton.Visible = False
                    Exit For

                End If

            Next

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemButtonEdit)

            GridColumn.ColumnEdit = RepositoryItemButtonEdit

        End Sub
        Public Sub AddSubItemNumericInput(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, _
                                          ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn,
                                          ByVal SubItemNumericInputType As WinForm.Presentation.Controls.SubItemNumericInput.Type, _
                                          ByVal MaxValue As Decimal, ByVal MinValue As Decimal)

            'objects
            Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing
            Dim MaxLength As Integer = 0

            Try

                SubItemNumericInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput

                SubItemNumericInput.ControlType = SubItemNumericInputType

                SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                SubItemNumericInput.MaxValue = MaxValue
                SubItemNumericInput.MinValue = MinValue

                If MaxValue > 0 Then

                    MaxLength = MaxValue.ToString.Length

                End If

                If MaxLength > 0 Then

                    SubItemNumericInput.MaxLength = MaxLength

                End If

                SubItemNumericInput.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Vertical
                SubItemNumericInput.ShowSpinButton = True

            Catch ex As Exception
                SubItemNumericInput = Nothing
            End Try

            If SubItemNumericInput IsNot Nothing Then

                DataGridView.GridControl.RepositoryItems.Add(SubItemNumericInput)

                GridColumn.ColumnEdit = SubItemNumericInput

            End If

        End Sub
        Private Sub UpdateRowIndexes()

            For Each ColumnDataRow In _ColumnsDataTable.Select()

                ColumnDataRow(ColumnFields.ColumnIndex.ToString) = _ColumnsDataTable.Rows.IndexOf(ColumnDataRow)

            Next

        End Sub
        Private Sub MoveRowUp(ByVal DataRow As System.Data.DataRow, ByVal Index As Integer)

            'objects
            Dim NewDataRow As System.Data.DataRow = Nothing

            If Index > 0 Then

                NewDataRow = _ColumnsDataTable.NewRow()

                NewDataRow.ItemArray = DataRow.ItemArray

                _ColumnsDataTable.Rows.Remove(DataRow)
                _ColumnsDataTable.Rows.InsertAt(NewDataRow, Index)

                UpdateRowIndexes()

            End If

        End Sub
        Private Sub MoveRowDown(ByVal DataRow As System.Data.DataRow, ByVal Index As Integer)

            'objects
            Dim NewDataRow As System.Data.DataRow = Nothing

            If Index < _ColumnsDataTable.Rows.Count - 1 Then

                NewDataRow = _ColumnsDataTable.NewRow()

                NewDataRow.ItemArray = DataRow.ItemArray

                _ColumnsDataTable.Rows.Remove(DataRow)
                _ColumnsDataTable.Rows.InsertAt(NewDataRow, Index)

                UpdateRowIndexes()

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonForm_Add.Enabled = True
            ButtonForm_Edit.Enabled = DataGridViewForm_Columns.HasOnlyOneSelectedRow
            ButtonForm_Delete.Enabled = DataGridViewForm_Columns.HasASelectedRow

            ButtonForm_MoveUp.Enabled = DataGridViewForm_Columns.HasOnlyOneSelectedRow
            ButtonForm_MoveDown.Enabled = DataGridViewForm_Columns.HasOnlyOneSelectedRow

            ButtonItemCopy_SelectedRow.Enabled = DataGridViewForm_Columns.HasOnlyOneSelectedRow
            ButtonItemCopy_FromTemplate.Enabled = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ColumnsDataTable As System.Data.DataTable, ByVal RowsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable, ByVal ReportType As ReportTypes) As System.Windows.Forms.DialogResult

            'objects
            Dim GLReportTemplateManageColumnsDialog As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateManageColumnsDialog = Nothing

            GLReportTemplateManageColumnsDialog = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateManageColumnsDialog(ColumnsDataTable, RowsDataTable, PercentOfRowColumnDataTable, ReportType)

            ShowFormDialog = GLReportTemplateManageColumnsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplateManageColumnsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_Columns.ItemDescription = "Column(s)"
            DataGridViewForm_Columns.OptionsView.ShowFooter = False

            DataGridViewForm_Columns.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_Columns.OptionsCustomization.AllowSort = False
            DataGridViewForm_Columns.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_Columns.OptionsCustomization.AllowGroup = False
            DataGridViewForm_Columns.OptionsCustomization.AllowFilter = False
            DataGridViewForm_Columns.OptionsCustomization.AllowRowSizing = False
            DataGridViewForm_Columns.OptionsCustomization.AllowColumnResizing = True

            DataGridViewForm_Columns.OptionsMenu.EnableColumnMenu = False

            DataGridViewForm_Columns.AllowDragAndDrop = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        _GLReportTemplateColumnDescriptionMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.GLReportTemplateColumn), ColumnFields.Description.ToString))

                    Catch ex As Exception
                        _GLReportTemplateColumnDescriptionMaxLength = -1
                    End Try

                End Using

            Catch ex As Exception
                _GLReportTemplateColumnDescriptionMaxLength = -1
            End Try

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        _GLReportTemplateColumnNameMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.GLReportTemplateColumn), ColumnFields.Name.ToString))

                    Catch ex As Exception
                        _GLReportTemplateColumnNameMaxLength = -1
                    End Try

                End Using

            Catch ex As Exception
                _GLReportTemplateColumnNameMaxLength = -1
            End Try

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub GLReportTemplateManageColumnsDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Add_Click(sender As Object, e As EventArgs) Handles ButtonForm_Add.Click

            If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateColumnEditDialog.ShowFormDialog(_ColumnsDataTable, _RowsDataTable, _PercentOfRowColumnDataTable, Nothing, _ReportType) = Windows.Forms.DialogResult.OK Then

                LoadGrid()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonForm_Edit_Click(sender As Object, e As EventArgs) Handles ButtonForm_Edit.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataRowID As Integer = -1

            If DataGridViewForm_Columns.HasOnlyOneSelectedRow Then

                Try

                    DataRowID = DataGridViewForm_Columns.GetFirstSelectedRowBookmarkValue(0)

                Catch ex As Exception
                    DataRowID = -1
                End Try

                Try

                    DataRow = _ColumnsDataTable.Rows.Find(DataRowID)

                Catch ex As Exception
                    DataRow = Nothing
                End Try

                If DataRow IsNot Nothing Then

                    If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateColumnEditDialog.ShowFormDialog(_ColumnsDataTable, _RowsDataTable, _PercentOfRowColumnDataTable, DataRow, _ReportType) = Windows.Forms.DialogResult.OK Then

                        LoadGrid()
                        EnableOrDisableActions()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonForm_Delete_Click(sender As Object, e As EventArgs) Handles ButtonForm_Delete.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataRowID As Integer = -1

            If DataGridViewForm_Columns.HasASelectedRow Then

                For Each DataRowID In DataGridViewForm_Columns.GetAllSelectedRowsBookmarkValues(0).OfType(Of Integer).ToList

                    Try

                        DataRow = _ColumnsDataTable.Rows.Find(DataRowID)

                    Catch ex As Exception
                        DataRow = Nothing
                    End Try

                    If DataRow IsNot Nothing Then

                        For Each PORCDataRow In _PercentOfRowColumnDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(PercentOfRowColumnFields.ColumnID.ToString) = DataRow(ColumnFields.ID.ToString)).ToList

                            _PercentOfRowColumnDataTable.Rows.Remove(PORCDataRow)

                        Next

                        _ColumnsDataTable.Rows.Remove(DataRow)

                    End If

                Next

                For Each ColumnDataRow In _ColumnsDataTable.Select()

                    ColumnDataRow(ColumnFields.ColumnIndex.ToString) = _ColumnsDataTable.Rows.IndexOf(ColumnDataRow)

                Next

                LoadGrid()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonForm_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonForm_MoveUp.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Index As Integer = 0

            If DataGridViewForm_Columns.HasOnlyOneSelectedRow Then

                DataRow = DirectCast(DataGridViewForm_Columns.GetFirstSelectedRowDataBoundItem, System.Data.DataRowView).Row

                Index = _ColumnsDataTable.Rows.IndexOf(DataRow)

                If Index > 0 Then

                    MoveRowUp(DataRow, Index - 1)

                End If

            End If

        End Sub
        Private Sub ButtonForm_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonForm_MoveDown.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Index As Integer = 0

            If DataGridViewForm_Columns.HasOnlyOneSelectedRow Then

                DataRow = DirectCast(DataGridViewForm_Columns.GetFirstSelectedRowDataBoundItem, System.Data.DataRowView).Row

                Index = _ColumnsDataTable.Rows.IndexOf(DataRow)

                If Index < _ColumnsDataTable.Rows.Count - 1 Then

                    MoveRowDown(DataRow, Index + 1)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Columns_DragAndDropRowsEvent(TargetRowHandle As Object, RowHandles() As Integer) Handles DataGridViewForm_Columns.DragAndDropRowsEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If RowHandles IsNot Nothing Then

                For Each RowHandle In RowHandles

                    Try

                        DataRow = DirectCast(DataGridViewForm_Columns.GetRowDataBoundItem(RowHandle), System.Data.DataRowView).Row

                    Catch ex As Exception
                        DataRow = Nothing
                    End Try

                    If DataRow IsNot Nothing Then

                        If RowHandle > TargetRowHandle Then

                            If TargetRowHandle < _ColumnsDataTable.Rows.Count - 1 Then

                                MoveRowUp(DataRow, TargetRowHandle)

                            End If

                        ElseIf RowHandle < TargetRowHandle Then

                            If TargetRowHandle > 0 Then

                                MoveRowDown(DataRow, TargetRowHandle)

                            End If

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub ButtonItemCopy_SelectedRow_Click(sender As Object, e As EventArgs) Handles ButtonItemCopy_SelectedRow.Click

            'objects
            Dim NewDataRow As System.Data.DataRow = Nothing
            Dim NewID As Integer = 0
            Dim ColumnCount As Integer = 1

            If DataGridViewForm_Columns.HasOnlyOneSelectedRow Then

                NewDataRow = _ColumnsDataTable.NewRow()

                NewID = NewDataRow(ColumnFields.ID.ToString)

                NewDataRow.ItemArray = DirectCast(DataGridViewForm_Columns.GetFirstSelectedRowDataBoundItem, System.Data.DataRowView).Row.ItemArray

                NewDataRow(ColumnFields.ID.ToString) = NewID

                Do While True

                    If _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(ColumnFields.Name.ToString) = "Column" & ColumnCount) = False Then

                        NewDataRow(ColumnFields.Name.ToString) = "Column" & ColumnCount
                        Exit Do

                    End If

                    ColumnCount += 1

                Loop

                _ColumnsDataTable.Rows.Add(NewDataRow)

                For Each ColumnDataRow In _ColumnsDataTable.Select()

                    ColumnDataRow(ColumnFields.ColumnIndex.ToString) = _ColumnsDataTable.Rows.IndexOf(ColumnDataRow)

                Next

            End If

        End Sub
        Private Sub ButtonItemCopy_FromTemplate_Click(sender As Object, e As EventArgs) Handles ButtonItemCopy_FromTemplate.Click

            AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateColumnCopyDialog.ShowFormDialog(_ColumnsDataTable)

        End Sub
        Private Sub _ColumnsDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles _ColumnsDataTable.ColumnChanging

            'objects
            Dim IsValid As Boolean = True

            If e.Column IsNot Nothing AndAlso e.Column.ColumnName = ColumnFields.Name.ToString Then

                If IsNothing(e.ProposedValue) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please enter a column name.")
                    IsValid = False

                End If

                If IsValid Then

                    If String.IsNullOrEmpty(e.ProposedValue.ToString.Trim) Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please enter a column name.")
                        IsValid = False

                    End If

                End If

                If IsValid Then

                    If _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(ColumnFields.ID.ToString) <> e.Row(ColumnFields.ID.ToString) AndAlso DR(ColumnFields.Name.ToString).ToString.ToUpper = e.ProposedValue.ToString.ToUpper) Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please enter a unqiue column name.")
                        IsValid = False

                    End If

                End If

                If IsValid Then

                    If AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(StatementFields), False).Any(Function(FieldName) FieldName.ToUpper = e.ProposedValue.ToString.ToUpper) Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please enter a different column name. This column name is reserved for internal use.")
                        IsValid = False

                    End If

                End If

                If IsValid = False Then

                    e.ProposedValue = e.Row(ColumnFields.Name.ToString)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Columns_RowDoubleClickEvent() Handles DataGridViewForm_Columns.RowDoubleClickEvent

            ButtonForm_Edit.PerformClick()

        End Sub
        Private Sub DataGridViewForm_Columns_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Columns.SelectionChangedEvent

            If Me.FormShown Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_Columns_CustomColumnDisplayTextEvent(ByVal sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_Columns.CustomColumnDisplayTextEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If e.Column IsNot Nothing Then

                If e.Column.FieldName = ColumnFields.Type.ToString Then

                    If IsNumeric(e.DisplayText) Then

                        e.DisplayText = CType(e.Value, ColumnTypes).ToString

                    End If

                Else

                    Try

                        DataRow = CType(DataGridViewForm_Columns.CurrentView.GetRow(DataGridViewForm_Columns.CurrentView.GetRowHandle(e.ListSourceRowIndex)), System.Data.DataRowView).Row

                    Catch ex As Exception
                        DataRow = Nothing
                    End Try

                    If DataRow IsNot Nothing Then

                        If DataRow(ColumnFields.Type.ToString) = ColumnTypes.Blank OrElse _
                            DataRow(ColumnFields.Type.ToString) = ColumnTypes.PercentOfRow OrElse _
                            DataRow(ColumnFields.Type.ToString) = ColumnTypes.PercentVariance Then

                            If e.Column.FieldName = ColumnFields.UseCurrencyFormat.ToString OrElse _
                                    e.Column.FieldName = ColumnFields.NumberOfDecimalPlaces.ToString Then

                                e.DisplayText = ""

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Columns_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_Columns.ShowingEditorEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            Try

                DataRow = CType(DataGridViewForm_Columns.CurrentView.GetRow(DataGridViewForm_Columns.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

            Catch ex As Exception
                DataRow = Nothing
            End Try

            If DataRow IsNot Nothing AndAlso DataGridViewForm_Columns.CurrentView.FocusedColumn IsNot Nothing Then

                If DataRow(ColumnFields.Type.ToString) = ColumnTypes.Blank OrElse _
                    DataRow(ColumnFields.Type.ToString) = ColumnTypes.PercentOfRow OrElse _
                    DataRow(ColumnFields.Type.ToString) = ColumnTypes.PercentVariance Then

                    If DataGridViewForm_Columns.CurrentView.FocusedColumn.FieldName = ColumnFields.UseCurrencyFormat.ToString OrElse _
                            DataGridViewForm_Columns.CurrentView.FocusedColumn.FieldName = ColumnFields.NumberOfDecimalPlaces.ToString Then

                        e.Cancel = True

                    End If

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub ButtonItemAdd_AllMonths_Click(sender As Object, e As EventArgs) Handles ButtonItemAdd_AllMonths.Click

            'objects
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim NameCounter As Integer = 1
            Dim FinalColumnName As String = ""
            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing
            Dim StartDate As Date = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

                If GeneralLedgerConfig IsNot Nothing Then

                    StartDate = New Date(Now.Year, CInt(GeneralLedgerConfig.FiscalYearStartMonth.GetValueOrDefault(1)), 1)

                Else

                    StartDate = New Date(Now.Year, 1, 1)

                End If

            End Using

            For MonthCounter As Integer = 1 To 12

                If MonthCounter <> 1 Then

                    StartDate = DateAdd(DateInterval.Month, 1, StartDate)

                End If

                ColumnDataRow = _ColumnsDataTable.NewRow

                FinalColumnName = MonthName(StartDate.Month)
                NameCounter = 1

                If _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(ColumnFields.Name.ToString).ToString.ToUpper = FinalColumnName.ToUpper) OrElse _
                        AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(StatementFields), False).Any(Function(FieldName) FieldName.ToUpper = FinalColumnName.ToUpper) Then

                    Do While True

                        FinalColumnName = MonthName(StartDate.Month) & NameCounter

                        If _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(ColumnFields.Name.ToString).ToString.ToUpper = FinalColumnName.ToUpper) = False AndAlso _
                                AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(StatementFields), False).Any(Function(FieldName) FieldName.ToUpper = FinalColumnName.ToUpper) = False Then

                            Exit Do

                        End If

                        NameCounter += 1

                    Loop

                End If

                ColumnDataRow(ColumnFields.Name.ToString) = FinalColumnName
                ColumnDataRow(ColumnFields.Description.ToString) = MonthName(StartDate.Month)
                ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Data
                ColumnDataRow(ColumnFields.ColumnIndex.ToString) = _ColumnsDataTable.Rows.Count
                ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Actual
                ColumnDataRow(ColumnFields.PreviousYears.ToString) = 0
                ColumnDataRow(ColumnFields.PeriodOption.ToString) = AdvantageFramework.EnumUtilities.GetValue(GetType(PeriodOptions), "Month" & MonthCounter)
                ColumnDataRow(ColumnFields.IsVisible.ToString) = True
                ColumnDataRow(ColumnFields.UnderlineColumnHeader.ToString) = False
                ColumnDataRow(ColumnFields.Expression.ToString) = ""
                ColumnDataRow(ColumnFields.UseCurrencyFormat.ToString) = False
                ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString) = 0
                ColumnDataRow(ColumnFields.Column1Name.ToString) = System.DBNull.Value
                ColumnDataRow(ColumnFields.Column2Name.ToString) = System.DBNull.Value
                ColumnDataRow(ColumnFields.PctOfRowColumnName.ToString) = System.DBNull.Value
                ColumnDataRow(ColumnFields.OfficeCode.ToString) = System.DBNull.Value
                ColumnDataRow(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString) = True
                ColumnDataRow(ColumnFields.DataCalculation.ToString) = CInt(DataCalculations.SelectedPeriod)
                ColumnDataRow(ColumnFields.DataOption.ToString) = CInt(DataOptions.EndingBalance)

                _ColumnsDataTable.Rows.Add(ColumnDataRow)

            Next MonthCounter

        End Sub
        Private Sub ButtonItemAdd_AllQuarters_Click(sender As Object, e As EventArgs) Handles ButtonItemAdd_AllQuarters.Click

            'objects
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim ColumnDescription As String = ""
            Dim NameCounter As Integer = 1
            Dim FinalColumnName As String = ""

            For QuarterCounter As Integer = 1 To 4

                ColumnDataRow = _ColumnsDataTable.NewRow

                ColumnDescription = "Quarter " & QuarterCounter
                FinalColumnName = ColumnDescription.Replace(" ", "")
                NameCounter = 1

                If _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(ColumnFields.Name.ToString).ToString.ToUpper = FinalColumnName.ToUpper) OrElse _
                        AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(StatementFields), False).Any(Function(FieldName) FieldName.ToUpper = FinalColumnName.ToUpper) Then

                    Do While True

                        FinalColumnName = FinalColumnName & NameCounter

                        If _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(ColumnFields.Name.ToString).ToString.ToUpper = FinalColumnName.ToUpper) = False AndAlso _
                                AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(StatementFields), False).Any(Function(FieldName) FieldName.ToUpper = FinalColumnName.ToUpper) = False Then

                            Exit Do

                        End If

                        NameCounter += 1

                    Loop

                End If

                ColumnDataRow(ColumnFields.Name.ToString) = FinalColumnName
                ColumnDataRow(ColumnFields.Description.ToString) = ColumnDescription
                ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Data
                ColumnDataRow(ColumnFields.ColumnIndex.ToString) = _ColumnsDataTable.Rows.Count
                ColumnDataRow(ColumnFields.DataType.ToString) = ColumnDataTypes.Actual
                ColumnDataRow(ColumnFields.PreviousYears.ToString) = 0
                ColumnDataRow(ColumnFields.PeriodOption.ToString) = AdvantageFramework.EnumUtilities.GetValue(GetType(PeriodOptions), "Quarter" & QuarterCounter)
                ColumnDataRow(ColumnFields.IsVisible.ToString) = True
                ColumnDataRow(ColumnFields.UnderlineColumnHeader.ToString) = False
                ColumnDataRow(ColumnFields.Expression.ToString) = ""
                ColumnDataRow(ColumnFields.UseCurrencyFormat.ToString) = False
                ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString) = 0
                ColumnDataRow(ColumnFields.Column1Name.ToString) = System.DBNull.Value
                ColumnDataRow(ColumnFields.Column2Name.ToString) = System.DBNull.Value
                ColumnDataRow(ColumnFields.PctOfRowColumnName.ToString) = System.DBNull.Value
                ColumnDataRow(ColumnFields.OfficeCode.ToString) = System.DBNull.Value
                ColumnDataRow(ColumnFields.OverrideRowDataOptionsAndCalculations.ToString) = True
                ColumnDataRow(ColumnFields.DataCalculation.ToString) = CInt(DataCalculations.SelectedPeriod)
                ColumnDataRow(ColumnFields.DataOption.ToString) = CInt(DataOptions.EndingBalance)

                _ColumnsDataTable.Rows.Add(ColumnDataRow)

            Next QuarterCounter

        End Sub

#End Region

#End Region

    End Class

End Namespace
