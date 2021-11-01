Namespace Security.Presentation

    Public Class ReportSelectionSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim InvoiceFormatsModuleCodes As String() = Nothing
            Dim MediaOrderFormatModuleCodes As String() = Nothing

            InvoiceFormatsModuleCodes = {"PI", "MI", "NI", "II", "OI", "TI", "RI", "CI"}
            MediaOrderFormatModuleCodes = {"IO", "MO", "NO", "OO", "RO", "TO"}

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewInvoiceFormats_InvoiceFormats.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CustomReport.Load(DbContext)
                                                                        Where InvoiceFormatsModuleCodes.Contains(Entity.LegacyModuleCode)
                                                                        Select Entity
                                                                        Order By Entity.LegacyModuleCode, Entity.ReportCode, Entity.Name).ToList

                DataGridViewMediaOrderFormats_MediaOrderFormats.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CustomReport.Load(DbContext)
                                                                              Where MediaOrderFormatModuleCodes.Contains(Entity.LegacyModuleCode)
                                                                              Select Entity
                                                                              Order By Entity.LegacyModuleCode, Entity.ReportCode, Entity.Name).ToList

            End Using

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewReportFormats_ReportFormats.DataSource = (From Entity In AdvantageFramework.Security.Database.Procedures.Report.Load(SecurityDbContext)
                                                                      Where Entity.Type <> 93 AndAlso
                                                                            Entity.Type <> 94 AndAlso
                                                                            Entity.Type <> 1
                                                                      Select Entity
                                                                      Order By Entity.Type, Entity.Name, Entity.IsActive, Entity.Code).ToList

            End Using

            SetGridProperties()

            DataGridViewInvoiceFormats_InvoiceFormats.CurrentView.BestFitColumns()
            DataGridViewMediaOrderFormats_MediaOrderFormats.CurrentView.BestFitColumns()
            DataGridViewReportFormats_ReportFormats.CurrentView.BestFitColumns()

        End Sub
        Private Function SaveCustomReport(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            'objects
            Dim Saved As Boolean = False
            Dim CustomReport As AdvantageFramework.Database.Entities.CustomReport = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.CustomReport.Properties.IsInactive.ToString Then

                Try

                    CustomReport = DataGridView.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    CustomReport = Nothing
                End Try

                If CustomReport IsNot Nothing Then

                    Try

                        CustomReport.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        CustomReport.IsInactive = CustomReport.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.CustomReport.Update(DbContext, CustomReport)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

            SaveCustomReport = Saved

        End Function
        Private Sub SetGridProperties()

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If DataGridViewReportFormats_ReportFormats.Columns("Type") IsNot Nothing Then

                DataGridViewReportFormats_ReportFormats.CurrentView.Columns("Type").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewReportFormats_ReportFormats.CurrentView.Columns("Type").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText

            End If

            If DataGridViewReportFormats_ReportFormats.Columns("IsActive") IsNot Nothing Then

                Try

                    RepositoryItemCheckEdit = DataGridViewReportFormats_ReportFormats.Columns("IsActive").ColumnEdit

                Catch ex As Exception
                    RepositoryItemCheckEdit = Nothing
                End Try

                If RepositoryItemCheckEdit IsNot Nothing Then

                    RepositoryItemCheckEdit.ValueChecked = "N"
                    RepositoryItemCheckEdit.ValueUnchecked = "A"
                    RepositoryItemCheckEdit.ValueGrayed = "A"

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ReportSelectionSetupForm As Presentation.ReportSelectionSetupForm = Nothing

            ReportSelectionSetupForm = New Presentation.ReportSelectionSetupForm()

            ReportSelectionSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ReportSelectionSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            LoadGrid()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewInvoiceFormats_InvoiceFormats_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoiceFormats_InvoiceFormats.CellValueChangingEvent

            Saved = SaveCustomReport(DataGridViewInvoiceFormats_InvoiceFormats, e)

        End Sub
        Private Sub DataGridViewMediaOrderFormats_MediaOrderFormats_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewMediaOrderFormats_MediaOrderFormats.CellValueChangingEvent

            Saved = SaveCustomReport(DataGridViewMediaOrderFormats_MediaOrderFormats, e)

        End Sub
        Private Sub DataGridViewReportFormats_ReportFormats_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewReportFormats_ReportFormats.CellValueChangingEvent

            'objects
            Dim Report As AdvantageFramework.Security.Database.Entities.Report = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Security.Database.Entities.Report.Properties.IsActive.ToString Then

                Try

                    Report = DataGridViewReportFormats_ReportFormats.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    Report = Nothing
                End Try

                If Report IsNot Nothing Then

                    Try

                        Report.IsActive = Convert.ToString(e.Value)

                    Catch ex As Exception
                        Report.IsActive = Report.IsActive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Security.Database.Procedures.Report.Update(SecurityDbContext, Report)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoiceFormats_InvoiceFormats_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewInvoiceFormats_InvoiceFormats.ShowingEditorEvent

            If DataGridViewInvoiceFormats_InvoiceFormats.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.CustomReport.Properties.IsInactive.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewMediaOrderFormats_MediaOrderFormats_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewMediaOrderFormats_MediaOrderFormats.ShowingEditorEvent

            If DataGridViewMediaOrderFormats_MediaOrderFormats.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.CustomReport.Properties.IsInactive.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewReportFormats_ReportFormats_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewReportFormats_ReportFormats.ShowingEditorEvent

            If DataGridViewReportFormats_ReportFormats.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Security.Database.Entities.Report.Properties.IsActive.ToString Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region
        
    End Class

End Namespace