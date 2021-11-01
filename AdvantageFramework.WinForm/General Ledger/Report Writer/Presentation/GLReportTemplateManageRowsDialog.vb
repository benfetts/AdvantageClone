Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplateManageRowsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _RowsDataTable As System.Data.DataTable = Nothing
        Private _RelatedRowsDataTable As System.Data.DataTable = Nothing
        Private _PercentOfRowColumnDataTable As System.Data.DataTable = Nothing
        Private _GLReportTemplateRowDescriptionMaxLength As Integer = -1
        Private _ReportType As ReportTypes = ReportTypes.IncomeStatement
        Private _DepartmentTeamPresetsDataTable As System.Data.DataTable = Nothing
        Private _OfficePresetsDataTable As System.Data.DataTable = Nothing
        Private _GLReportTemplateID As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal RowsDataTable As System.Data.DataTable, ByVal RelatedRowsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable, ByVal ReportType As ReportTypes,
                        DepartmentTeamPresetsDataTable As System.Data.DataTable, OfficePresetsDataTable As System.Data.DataTable, GLReportTemplateID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _RowsDataTable = RowsDataTable
            _RelatedRowsDataTable = RelatedRowsDataTable
            _PercentOfRowColumnDataTable = PercentOfRowColumnDataTable
            _ReportType = ReportType
            _DepartmentTeamPresetsDataTable = DepartmentTeamPresetsDataTable
            _OfficePresetsDataTable = OfficePresetsDataTable
            _GLReportTemplateID = GLReportTemplateID

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Rows.ClearGridCustomization()

            DataGridViewForm_Rows.DataSource = _RowsDataTable

            For Each GridColumn In DataGridViewForm_Rows.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

				If GridColumn.FieldName = RowFields.RowIndex.ToString Then

					GridColumn.Visible = True
					GridColumn.OptionsColumn.ReadOnly = True

				ElseIf GridColumn.FieldName = RowFields.Description.ToString Then

					GridColumn.Visible = True
					GridColumn.OptionsColumn.ReadOnly = False
					AddSubItemTextBox(Me.Session, DataGridViewForm_Rows, GridColumn, _GLReportTemplateRowDescriptionMaxLength)

				ElseIf GridColumn.FieldName = RowFields.IsVisible.ToString Then

					GridColumn.Caption = "Visible"
					GridColumn.Visible = True
					GridColumn.OptionsColumn.ReadOnly = False
					GridColumn.OptionsColumn.AllowEdit = True

				ElseIf GridColumn.FieldName = RowFields.Type.ToString Then

                    GridColumn.Caption = "Row Type"
                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ReadOnly = True
                    GridColumn.OptionsColumn.AllowEdit = False

                ElseIf GridColumn.FieldName = RowFields.BalanceType.ToString Then

                    GridColumn.Caption = "Balance"
                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ReadOnly = False
                    GridColumn.OptionsColumn.AllowEdit = True
                    AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_Rows, GridColumn, GetType(Integer), GetType(BalanceTypes))

                ElseIf GridColumn.FieldName = RowFields.DisplayType.ToString Then

                    GridColumn.Caption = "Display Type"
                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ReadOnly = False
                    GridColumn.OptionsColumn.AllowEdit = True
                    AddSubItemGridLookupEdit(Me.Session, DataGridViewForm_Rows, GridColumn, GetType(Integer), GetType(DisplayTypes))

                ElseIf GridColumn.FieldName = RowFields.IndentSpaces.ToString Then

                    GridColumn.Caption = "Indent Spaces"
                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ReadOnly = False
                    GridColumn.OptionsColumn.AllowEdit = True
                    AddSubItemNumericInput(Me.Session, DataGridViewForm_Rows, GridColumn, WinForm.Presentation.Controls.SubItemNumericInput.Type.Integer, 0, 0)

                ElseIf GridColumn.FieldName = RowFields.RollUp.ToString Then

                    GridColumn.Caption = "Roll Up"
                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ReadOnly = False
                    GridColumn.OptionsColumn.AllowEdit = True

                ElseIf GridColumn.FieldName = RowFields.IsBold.ToString Then

                    GridColumn.Caption = "Bold"
                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ReadOnly = False
                    GridColumn.OptionsColumn.AllowEdit = True

                ElseIf GridColumn.FieldName = RowFields.UnderlineAmount.ToString Then

                    GridColumn.Caption = "Underline Amount"
                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ReadOnly = False
                    GridColumn.OptionsColumn.AllowEdit = True

                ElseIf GridColumn.FieldName = RowFields.DoubleUnderlineAmount.ToString Then

                    GridColumn.Caption = "Double Underline Amount"
                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ReadOnly = False
                    GridColumn.OptionsColumn.AllowEdit = True

                ElseIf GridColumn.FieldName = RowFields.SuppressIfAllZeros.ToString Then

                    GridColumn.Caption = "Suppress If All Zeros"
                    GridColumn.Visible = True
                    GridColumn.OptionsColumn.ReadOnly = False
                    GridColumn.OptionsColumn.AllowEdit = True

                    'ElseIf GridColumn.FieldName = RowFields.UseCurrencyFormat.ToString Then

                    '    GridColumn.Caption = "Use Currency Format"
                    '    GridColumn.Visible = True
                    '    GridColumn.OptionsColumn.ReadOnly = False
                    '    GridColumn.OptionsColumn.AllowEdit = True

                    'ElseIf GridColumn.FieldName = RowFields.NumberOfDecimalPlaces.ToString Then

                    '    GridColumn.Caption = "Number Of Decimal Places"
                    '    GridColumn.Visible = True
                    '    GridColumn.OptionsColumn.ReadOnly = False
                    '    GridColumn.OptionsColumn.AllowEdit = True
                    '    AddSubItemNumericInput(Me.Session, DataGridViewForm_Rows, GridColumn, WinForm.Presentation.Controls.SubItemNumericInput.Type.Integer, 6, 0)

                Else

                    GridColumn.Visible = False
                    GridColumn.OptionsColumn.ReadOnly = True

                End If

            Next

            For Each GridColumn In DataGridViewForm_Rows.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

				If GridColumn.FieldName = RowFields.RowIndex.ToString Then

					GridColumn.VisibleIndex = 0

				ElseIf GridColumn.FieldName = RowFields.Description.ToString Then

					GridColumn.VisibleIndex = 1

				ElseIf GridColumn.FieldName = RowFields.IsVisible.ToString Then

					GridColumn.VisibleIndex = 2

				ElseIf GridColumn.FieldName = RowFields.Type.ToString Then

					GridColumn.VisibleIndex = 3

				ElseIf GridColumn.FieldName = RowFields.BalanceType.ToString Then

					GridColumn.VisibleIndex = 4

				ElseIf GridColumn.FieldName = RowFields.DisplayType.ToString Then

					GridColumn.VisibleIndex = 5

				ElseIf GridColumn.FieldName = RowFields.IndentSpaces.ToString Then

					GridColumn.VisibleIndex = 6

				ElseIf GridColumn.FieldName = RowFields.RollUp.ToString Then

					GridColumn.VisibleIndex = 7

				ElseIf GridColumn.FieldName = RowFields.IsBold.ToString Then

					GridColumn.VisibleIndex = 8

				ElseIf GridColumn.FieldName = RowFields.UnderlineAmount.ToString Then

					GridColumn.VisibleIndex = 9

				ElseIf GridColumn.FieldName = RowFields.DoubleUnderlineAmount.ToString Then

					GridColumn.VisibleIndex = 10

				ElseIf GridColumn.FieldName = RowFields.SuppressIfAllZeros.ToString Then

					GridColumn.VisibleIndex = 11

					'ElseIf GridColumn.FieldName = RowFields.UseCurrencyFormat.ToString Then

					'    GridColumn.VisibleIndex = 11

					'ElseIf GridColumn.FieldName = RowFields.NumberOfDecimalPlaces.ToString Then

					'    GridColumn.VisibleIndex = 12

				End If

            Next

            DataGridViewForm_Rows.CurrentView.BestFitColumns()

        End Sub
        Private Sub AddSubItemTextBox(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal MaxLength As Long)

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
        Public Sub AddSubItemGridLookupEdit(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal ValueType As System.Type, ByVal EnumType As System.Type)

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            Try

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ValueType = ValueType
                SubItemGridLookUpEditControl.EnumType = EnumType

                SubItemGridLookUpEditControl.Session = Session
                SubItemGridLookUpEditControl.ControlType = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable

            Catch ex As Exception
                SubItemGridLookUpEditControl = Nothing
            End Try

            If SubItemGridLookUpEditControl IsNot Nothing Then

                SubItemGridLookUpEditControl.LoadDefaultDataSourceView()

                DataGridView.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                GridColumn.ColumnEdit = SubItemGridLookUpEditControl

            End If

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

            For Each RowDataRow In _RowsDataTable.Select()

                RowDataRow(RowFields.RowIndex.ToString) = _RowsDataTable.Rows.IndexOf(RowDataRow)

            Next

            For Each RowDataRow In _RowsDataTable.Select()

                For Each RelatedRowDataRow In _RelatedRowsDataTable.Select(RelatedRowFields.RelatedRowID.ToString & " = " & RowDataRow(RowFields.ID.ToString))

                    RelatedRowDataRow(RelatedRowFields.RelatedRowIndex.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                Next

                For Each PercentOfRowColumnDataRow In _PercentOfRowColumnDataTable.Select(PercentOfRowColumnFields.RowID.ToString & " = " & RowDataRow(RowFields.ID.ToString))

                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.RowIndex.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                Next

                For Each PercentOfRowColumnDataRow In _PercentOfRowColumnDataTable.Select(PercentOfRowColumnFields.PercentOfRowID.ToString & " = " & RowDataRow(RowFields.ID.ToString))

                    PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowIndex.ToString) = RowDataRow(RowFields.RowIndex.ToString)

                Next

            Next

        End Sub
        Private Sub MoveRowUp(ByVal DataRow As System.Data.DataRow, ByVal Index As Integer)

            'objects
            Dim NewDataRow As System.Data.DataRow = Nothing

            If Index > 0 Then

                NewDataRow = _RowsDataTable.NewRow()

                NewDataRow.ItemArray = DataRow.ItemArray

                _RowsDataTable.Rows.Remove(DataRow)
                _RowsDataTable.Rows.InsertAt(NewDataRow, Index)

                UpdateRowIndexes()

            End If

        End Sub
        Private Sub MoveRowDown(ByVal DataRow As System.Data.DataRow, ByVal Index As Integer)

            'objects
            Dim NewDataRow As System.Data.DataRow = Nothing

            If Index < _RowsDataTable.Rows.Count - 1 Then

                NewDataRow = _RowsDataTable.NewRow()

                NewDataRow.ItemArray = DataRow.ItemArray

                _RowsDataTable.Rows.Remove(DataRow)
                _RowsDataTable.Rows.InsertAt(NewDataRow, Index)

                UpdateRowIndexes()

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonForm_Add.Enabled = True
            ButtonForm_Edit.Enabled = DataGridViewForm_Rows.HasASelectedRow
            ButtonForm_Delete.Enabled = DataGridViewForm_Rows.HasASelectedRow

            ButtonForm_MoveUp.Enabled = DataGridViewForm_Rows.HasOnlyOneSelectedRow
            ButtonForm_MoveDown.Enabled = DataGridViewForm_Rows.HasOnlyOneSelectedRow

            ButtonItemCopy_SelectedRow.Enabled = DataGridViewForm_Rows.HasOnlyOneSelectedRow
            ButtonItemCopy_FromTemplate.Enabled = True

        End Sub
        Private Sub PrintGLRowReport(PrintAll As Boolean)

            Dim SelectedRowIndexes As Generic.List(Of Integer) = Nothing
            Dim GLReportWriterGLRowFormatList As Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterGLRowFormatReport) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim ReportPrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing

            SelectedRowIndexes = New Generic.List(Of Integer)

            If PrintAll Then

                For Each RowHandlesAndDataBoundItem In DataGridViewForm_Rows.GetAllRowsRowHandlesAndDataBoundItems()

                    SelectedRowIndexes.Add(DirectCast(DataGridViewForm_Rows.CurrentView.GetRow(RowHandlesAndDataBoundItem.Key), DataRowView).Item(RowFields.RowIndex.ToString))

                Next

            Else

                For Each RowHandlesAndDataBoundItem In DataGridViewForm_Rows.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                    SelectedRowIndexes.Add(DirectCast(DataGridViewForm_Rows.CurrentView.GetRow(RowHandlesAndDataBoundItem.Key), DataRowView).Item(RowFields.RowIndex.ToString))

                Next

            End If

            GLReportWriterGLRowFormatList = New Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterGLRowFormatReport)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GLReportWriterGLRowFormatList.AddRange(From Entity In AdvantageFramework.Database.Procedures.GLReportTemplateRow.LoadByGLReportTemplateID(DbContext, _GLReportTemplateID).Include("GLReportTemplate").ToList
                                                       Where SelectedRowIndexes.Contains(Entity.RowIndex)
                                                       Select New AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterGLRowFormatReport(Entity))

                AdvantageFramework.GeneralLedger.ReportWriter.Presentation.UpdateGLReportWriterGLRowFormatGLAccountList(DbContext, GLReportWriterGLRowFormatList, _DepartmentTeamPresetsDataTable, _OfficePresetsDataTable, Me.Session.User.EmployeeCode)

            End Using

            Report = AdvantageFramework.Reporting.Reports.CreateGLReportWriterAccountReport(Me.Session, GLReportWriterGLRowFormatList)

            If Report IsNot Nothing Then

                Report.CreateDocument()

                ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                ReportPrintTool.ShowRibbonPreviewDialog()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal RowsDataTable As System.Data.DataTable, ByVal RelatedRowsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable, ByVal ReportType As ReportTypes,
                                              DepartmentTeamPresetsDataTable As System.Data.DataTable, OfficePresetsDataTable As System.Data.DataTable, GLReportTemplateID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim GLReportTemplateManageRowsDialog As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateManageRowsDialog = Nothing

            GLReportTemplateManageRowsDialog = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateManageRowsDialog(RowsDataTable, RelatedRowsDataTable, PercentOfRowColumnDataTable, ReportType,
                    DepartmentTeamPresetsDataTable, OfficePresetsDataTable, GLReportTemplateID)

            ShowFormDialog = GLReportTemplateManageRowsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplateManageRowsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_Rows.ItemDescription = "Row(s)"
            DataGridViewForm_Rows.OptionsView.ShowFooter = False

            DataGridViewForm_Rows.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_Rows.OptionsCustomization.AllowSort = False
            DataGridViewForm_Rows.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_Rows.OptionsCustomization.AllowGroup = False
            DataGridViewForm_Rows.OptionsCustomization.AllowFilter = False
            DataGridViewForm_Rows.OptionsCustomization.AllowRowSizing = False
            DataGridViewForm_Rows.OptionsCustomization.AllowColumnResizing = True

            DataGridViewForm_Rows.OptionsMenu.EnableColumnMenu = False

            DataGridViewForm_Rows.AllowDragAndDrop = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        _GLReportTemplateRowDescriptionMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.GLReportTemplateRow), RowFields.Description.ToString))

                    Catch ex As Exception
                        _GLReportTemplateRowDescriptionMaxLength = -1
                    End Try

                End Using

            Catch ex As Exception
                _GLReportTemplateRowDescriptionMaxLength = -1
            End Try

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub GLReportTemplateManageRowsDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If Me.Validator Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonForm_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonForm_MoveUp.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Index As Integer = 0

            If DataGridViewForm_Rows.HasOnlyOneSelectedRow Then

                DataRow = DirectCast(DataGridViewForm_Rows.GetFirstSelectedRowDataBoundItem, System.Data.DataRowView).Row

                Index = _RowsDataTable.Rows.IndexOf(DataRow)

                If Index > 0 Then

                    MoveRowUp(DataRow, Index - 1)

                    UpdateRowIndexes()

                End If

            End If

        End Sub
        Private Sub ButtonForm_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonForm_MoveDown.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Index As Integer = 0

            If DataGridViewForm_Rows.HasOnlyOneSelectedRow Then

                DataRow = DirectCast(DataGridViewForm_Rows.GetFirstSelectedRowDataBoundItem, System.Data.DataRowView).Row

                Index = _RowsDataTable.Rows.IndexOf(DataRow)

                If Index < _RowsDataTable.Rows.Count - 1 Then

                    MoveRowDown(DataRow, Index + 1)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Rows_DragAndDropRowsEvent(TargetRowHandle As Object, RowHandles() As Integer) Handles DataGridViewForm_Rows.DragAndDropRowsEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If RowHandles IsNot Nothing Then

                For Each RowHandle In RowHandles

                    Try

                        DataRow = DirectCast(DataGridViewForm_Rows.GetRowDataBoundItem(RowHandle), System.Data.DataRowView).Row

                    Catch ex As Exception
                        DataRow = Nothing
                    End Try

                    If DataRow IsNot Nothing Then

                        If RowHandle > TargetRowHandle Then

                            If TargetRowHandle < _RowsDataTable.Rows.Count - 1 Then

                                MoveRowUp(DataRow, TargetRowHandle)

                            End If

                        End If

                    ElseIf RowHandle < TargetRowHandle Then

                        If TargetRowHandle > 0 Then

                            MoveRowDown(DataRow, TargetRowHandle)

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateRowEditDialog.ShowFormDialog(_RowsDataTable, _RelatedRowsDataTable, Nothing, _ReportType) = Windows.Forms.DialogResult.OK Then

                LoadGrid()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonForm_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Edit.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataRowID As Integer = -1

            If DataGridViewForm_Rows.HasOnlyOneSelectedRow Then

                Try

                    DataRowID = DataGridViewForm_Rows.GetFirstSelectedRowBookmarkValue(0)

                Catch ex As Exception
                    DataRowID = -1
                End Try

                Try

                    DataRow = _RowsDataTable.Rows.Find(DataRowID)

                Catch ex As Exception
                    DataRow = Nothing
                End Try

                If DataRow IsNot Nothing Then

                    If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateRowEditDialog.ShowFormDialog(_RowsDataTable, _RelatedRowsDataTable, DataRow, _ReportType) = Windows.Forms.DialogResult.OK Then

                        LoadGrid()
                        EnableOrDisableActions()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonForm_Delete_Click(sender As Object, e As EventArgs) Handles ButtonForm_Delete.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowID As Integer = -1

            If DataGridViewForm_Rows.HasOnlyOneSelectedRow Then

                Try

                    RowID = DataGridViewForm_Rows.GetFirstSelectedRowBookmarkValue(0)

                Catch ex As Exception
                    RowID = -1
                End Try

                Try

                    DataRow = _RowsDataTable.Rows.Find(RowID)

                Catch ex As Exception
                    DataRow = Nothing
                End Try

                If DataRow IsNot Nothing Then

                    _RowsDataTable.Rows.Remove(DataRow)

                    For Each RelatedRowDataRow In _RelatedRowsDataTable.Select(RelatedRowFields.RelatedRowID.ToString & " = " & RowID)

                        _RelatedRowsDataTable.Rows.Remove(RelatedRowDataRow)

                    Next

                    UpdateRowIndexes()

                    DataGridViewForm_Rows.CurrentView.RefreshData()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub ButtonItemCopy_SelectedRow_Click(sender As Object, e As EventArgs) Handles ButtonItemCopy_SelectedRow.Click

            'objects
            Dim NewDataRow As System.Data.DataRow = Nothing
            Dim NewID As Integer = 0

            If DataGridViewForm_Rows.HasOnlyOneSelectedRow Then

                NewDataRow = _RowsDataTable.NewRow()

                NewID = NewDataRow(RowFields.ID.ToString)

                NewDataRow.ItemArray = DirectCast(DataGridViewForm_Rows.GetFirstSelectedRowDataBoundItem, System.Data.DataRowView).Row.ItemArray

                NewDataRow(RowFields.ID.ToString) = NewID

                _RowsDataTable.Rows.Add(NewDataRow)

                UpdateRowIndexes()

            End If

        End Sub
        Private Sub ButtonItemCopy_FromTemplate_Click(sender As Object, e As EventArgs) Handles ButtonItemCopy_FromTemplate.Click

            AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateRowCopyDialog.ShowFormDialog(_RowsDataTable)

        End Sub
        Private Sub ButtonItemPrint_All_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_All.Click

            PrintGLRowReport(True)

        End Sub
        Private Sub ButtonItemPrint_Selected_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_Selected.Click

            PrintGLRowReport(False)

        End Sub
        Private Sub DataGridViewForm_Rows_CustomColumnDisplayTextEvent(ByVal sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_Rows.CustomColumnDisplayTextEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If e.Column IsNot Nothing Then

                If e.Column.FieldName = RowFields.Type.ToString Then

                    If IsNumeric(e.DisplayText) Then

                        e.DisplayText = CType(e.Value, RowTypes).ToString

                    End If

                Else

                    Try

                        DataRow = CType(DataGridViewForm_Rows.CurrentView.GetRow(DataGridViewForm_Rows.CurrentView.GetRowHandle(e.ListSourceRowIndex)), System.Data.DataRowView).Row

                    Catch ex As Exception
                        DataRow = Nothing
                    End Try

                    If DataRow IsNot Nothing Then

                        If DataRow(RowFields.Type.ToString) = RowTypes.Other Then

							If e.Column.FieldName <> RowFields.Description.ToString AndAlso
									e.Column.FieldName <> RowFields.IndentSpaces.ToString AndAlso
									e.Column.FieldName <> RowFields.IsBold.ToString AndAlso
									e.Column.FieldName <> RowFields.RowIndex.ToString AndAlso
									e.Column.FieldName <> RowFields.IsVisible.ToString Then

								e.DisplayText = ""

							End If

						End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Rows_RowDoubleClickEvent() Handles DataGridViewForm_Rows.RowDoubleClickEvent

            ButtonForm_Edit.PerformClick()

        End Sub
        Private Sub DataGridViewForm_Rows_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Rows.SelectionChangedEvent

            If Me.FormShown Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_Rows_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_Rows.ShowingEditorEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            Try

                DataRow = CType(DataGridViewForm_Rows.CurrentView.GetRow(DataGridViewForm_Rows.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

            Catch ex As Exception
                DataRow = Nothing
            End Try

            If DataRow IsNot Nothing AndAlso DataGridViewForm_Rows.CurrentView.FocusedColumn IsNot Nothing Then

                If DataRow(RowFields.Type.ToString) = RowTypes.Other Then

					If DataGridViewForm_Rows.CurrentView.FocusedColumn.FieldName <> RowFields.Description.ToString AndAlso
							DataGridViewForm_Rows.CurrentView.FocusedColumn.FieldName <> RowFields.IndentSpaces.ToString AndAlso
							DataGridViewForm_Rows.CurrentView.FocusedColumn.FieldName <> RowFields.IsBold.ToString AndAlso
							DataGridViewForm_Rows.CurrentView.FocusedColumn.FieldName <> RowFields.IsVisible.ToString Then

						e.Cancel = True

					End If

				ElseIf DataRow(RowFields.Type.ToString) = RowTypes.Total Then

                    If DataGridViewForm_Rows.CurrentView.FocusedColumn.FieldName = RowFields.DisplayType.ToString OrElse _
                            DataGridViewForm_Rows.CurrentView.FocusedColumn.FieldName = RowFields.RollUp.ToString Then

                        e.Cancel = True

                    End If

                ElseIf DataRow(RowFields.Type.ToString) = RowTypes.Account Then

                    If DataGridViewForm_Rows.CurrentView.FocusedColumn.FieldName = RowFields.RollUp.ToString AndAlso _
                            DataRow(RowFields.DisplayType.ToString) <> DisplayTypes.AccountDescription Then

                        e.Cancel = True

                    End If

                End If

            Else

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
