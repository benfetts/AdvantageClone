Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplateColumnCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ColumnsDataTable As System.Data.DataTable = Nothing
        Private _SelectedTemplateColumnsDataTable As System.Data.DataTable = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ColumnsDataTable As System.Data.DataTable)

            ' This call is required by the designer.
            InitializeComponent()

            _ColumnsDataTable = ColumnsDataTable
 
        End Sub
        Private Sub LoadGLReportTemplates()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_GLReportTemplates.DataSource = AdvantageFramework.Database.Procedures.GLReportTemplate.Load(DbContext)

            End Using

            DataGridViewForm_GLReportTemplates.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadGLReportTemplateColumns()

            If DataGridViewForm_GLReportTemplates.HasOnlyOneSelectedRow Then

                DataGridViewForm_GLReportTemplateColumns.CurrentView.BeginUpdate()

                _SelectedTemplateColumnsDataTable.Rows.Clear()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    LoadColumnsDataTable(DbContext, DataGridViewForm_GLReportTemplates.GetFirstSelectedRowBookmarkValue, _SelectedTemplateColumnsDataTable)

                End Using

                DataGridViewForm_GLReportTemplateColumns.CurrentView.EndUpdate()

                DataGridViewForm_GLReportTemplateColumns.CurrentView.BestFitColumns()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ColumnsDataTable As System.Data.DataTable) As System.Windows.Forms.DialogResult

            'objects
            Dim GLReportTemplateColumnCopyDialog As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateColumnCopyDialog = Nothing

            GLReportTemplateColumnCopyDialog = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateColumnCopyDialog(ColumnsDataTable)

            ShowFormDialog = GLReportTemplateColumnCopyDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplateColumnCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_GLReportTemplates.MultiSelect = False
            DataGridViewForm_GLReportTemplates.OptionsView.ShowFooter = False

            DataGridViewForm_GLReportTemplateColumns.MultiSelect = True
            DataGridViewForm_GLReportTemplateColumns.OptionsView.ShowFooter = False

            DataGridViewForm_GLReportTemplateColumns.ItemDescription = "Column(s)"

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                BuildColumnsDataTable(_SelectedTemplateColumnsDataTable)

                DataGridViewForm_GLReportTemplateColumns.DataSource = _SelectedTemplateColumnsDataTable

                For Each GridColumn In DataGridViewForm_GLReportTemplateColumns.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    If GridColumn.FieldName = ColumnFields.Name.ToString Then

                        GridColumn.Visible = True
                        GridColumn.OptionsColumn.ReadOnly = True

                    ElseIf GridColumn.FieldName = ColumnFields.Description.ToString Then

                        GridColumn.Visible = True
                        GridColumn.OptionsColumn.ReadOnly = True

                    Else

                        GridColumn.Visible = False

                    End If

                Next

                LoadGLReportTemplates()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub GLReportTemplateColumnCopyDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            LoadGLReportTemplateColumns()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim Copied As Boolean = False
            Dim NewDataRow As System.Data.DataRow = Nothing
            Dim NewID As Integer = 0
            Dim ColumnCount As Integer = 1

            If DataGridViewForm_GLReportTemplateColumns.HasASelectedRow Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()
                Me.ShowWaitForm("Copying...")

                Try

                    For Each DataRow In DataGridViewForm_GLReportTemplateColumns.GetAllSelectedRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                        NewDataRow = _ColumnsDataTable.NewRow()
                        
                        NewID = NewDataRow(ColumnFields.ID.ToString)

                        NewDataRow.ItemArray = DataRow.ItemArray

                        NewDataRow(ColumnFields.ID.ToString) = NewID

                        Do While True

                            If _ColumnsDataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(ColumnFields.Name.ToString) = "Column" & ColumnCount) = False Then

                                NewDataRow(ColumnFields.Name.ToString) = "Column" & ColumnCount
                                Exit Do

                            End If

                            ColumnCount += 1

                        Loop

                        _ColumnsDataTable.Rows.Add(NewDataRow)

                    Next
                    
                    For Each ColumnDataRow In _ColumnsDataTable.Select()

                        ColumnDataRow(ColumnFields.ColumnIndex.ToString) = _ColumnsDataTable.Rows.IndexOf(ColumnDataRow)

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

                LoadGLReportTemplateColumns()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
