Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplateRowCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _RowsDataTable As System.Data.DataTable = Nothing
        Private _SelectedTemplateRowsDataTable As System.Data.DataTable = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal RowsDataTable As System.Data.DataTable)

            ' This call is required by the designer.
            InitializeComponent()

            _RowsDataTable = RowsDataTable

        End Sub
        Private Sub LoadGLReportTemplates()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_GLReportTemplates.DataSource = AdvantageFramework.Database.Procedures.GLReportTemplate.Load(DbContext)

            End Using

            DataGridViewForm_GLReportTemplates.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadGLReportTemplateRows()

            If DataGridViewForm_GLReportTemplates.HasOnlyOneSelectedRow Then

                DataGridViewForm_GLReportTemplateRows.CurrentView.BeginUpdate()

                _SelectedTemplateRowsDataTable.Rows.Clear()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    LoadRowsDataTable(DbContext, DataGridViewForm_GLReportTemplates.GetFirstSelectedRowBookmarkValue, _SelectedTemplateRowsDataTable)

                End Using

                DataGridViewForm_GLReportTemplateRows.CurrentView.EndUpdate()

                DataGridViewForm_GLReportTemplateRows.CurrentView.BestFitColumns()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal RowsDataTable As System.Data.DataTable) As System.Windows.Forms.DialogResult

            'objects
            Dim GLReportTemplateRowCopyDialog As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateRowCopyDialog = Nothing

            GLReportTemplateRowCopyDialog = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateRowCopyDialog(RowsDataTable)

            ShowFormDialog = GLReportTemplateRowCopyDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplateRowCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_GLReportTemplates.MultiSelect = False
            DataGridViewForm_GLReportTemplates.OptionsView.ShowFooter = False

            DataGridViewForm_GLReportTemplateRows.MultiSelect = True
            DataGridViewForm_GLReportTemplateRows.OptionsView.ShowFooter = False

            DataGridViewForm_GLReportTemplateRows.ItemDescription = "Row(s)"

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                BuildRowsDataTable(_SelectedTemplateRowsDataTable)

                DataGridViewForm_GLReportTemplateRows.DataSource = _SelectedTemplateRowsDataTable

                For Each GridColumn In DataGridViewForm_GLReportTemplateRows.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    If GridColumn.FieldName = RowFields.RowIndex.ToString Then

                        GridColumn.Visible = True
                        GridColumn.OptionsColumn.ReadOnly = True

                    ElseIf GridColumn.FieldName = RowFields.Description.ToString Then

                        GridColumn.Visible = True
                        GridColumn.OptionsColumn.ReadOnly = True

                    ElseIf GridColumn.FieldName = RowFields.Type.ToString Then

                        GridColumn.Caption = "Row Type"
                        GridColumn.Visible = True
                        GridColumn.OptionsColumn.ReadOnly = True
                        GridColumn.OptionsColumn.AllowEdit = False

                    Else

                        GridColumn.Visible = False
                        GridColumn.OptionsColumn.ReadOnly = True

                    End If

                Next

                For Each GridColumn In DataGridViewForm_GLReportTemplateRows.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    If GridColumn.FieldName = RowFields.RowIndex.ToString Then

                        GridColumn.VisibleIndex = 0

                    ElseIf GridColumn.FieldName = RowFields.Description.ToString Then

                        GridColumn.VisibleIndex = 1

                    ElseIf GridColumn.FieldName = RowFields.Type.ToString Then

                        GridColumn.VisibleIndex = 2

                    End If

                Next

                LoadGLReportTemplates()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub GLReportTemplateRowCopyDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            LoadGLReportTemplateRows()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim Copied As Boolean = False
            Dim NewDataRow As System.Data.DataRow = Nothing
            Dim NewID As Integer = 0

            If DataGridViewForm_GLReportTemplateRows.HasASelectedRow Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()
                Me.ShowWaitForm("Copying...")

                Try

                    For Each DataRow In DataGridViewForm_GLReportTemplateRows.GetAllSelectedRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                        NewDataRow = _RowsDataTable.NewRow()

                        NewID = NewDataRow(RowFields.ID.ToString)

                        NewDataRow.ItemArray = DataRow.ItemArray

                        NewDataRow(RowFields.ID.ToString) = NewID

                        _RowsDataTable.Rows.Add(NewDataRow)

                    Next

                    For Each RowDataRow In _RowsDataTable.Select()

                        RowDataRow(RowFields.RowIndex.ToString) = _RowsDataTable.Rows.IndexOf(RowDataRow)

                    Next

                    Copied = True

                Catch ex As Exception
                    Copied = False
                End Try

                If Copied Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Failed copying column. Please contact Software Support.")

                End If

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a report template column.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_MediaPlanDetails_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_GLReportTemplates.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadGLReportTemplateRows()

            End If

        End Sub
        Private Sub DataGridViewForm_GLReportTemplateRows_CustomColumnDisplayTextEvent(ByVal sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_GLReportTemplateRows.CustomColumnDisplayTextEvent

            If e.Column IsNot Nothing AndAlso e.Column.FieldName = RowFields.Type.ToString Then

                If IsNumeric(e.DisplayText) Then

                    e.DisplayText = CType(e.Value, RowTypes).ToString

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
