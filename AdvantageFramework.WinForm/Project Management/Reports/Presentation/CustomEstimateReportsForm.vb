Namespace ProjectManagement.Reports.Presentation

    Public Class CustomEstimateReportsForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EstimateTypes As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            'Dim UserDefinedReportCategoryID As Integer = 0

            'Try

            '    UserDefinedReportCategoryID = ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.SelectedValue

            'Catch ex As Exception
            '    UserDefinedReportCategoryID = 0
            'End Try

            'If UserDefinedReportCategoryID > 0 Then

            'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '            DataGridViewForm_Reports.DataSource = AdvantageFramework.Reporting.LoadAvailableCustomInvoices(SecurityDbContext, AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList, Session.Application, Session.User.ID).Where(Function(Entity) Entity.UserDefinedReportCategoryID.GetValueOrDefault(0) = UserDefinedReportCategoryID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

            '        End Using
            '
            '    End Using

            'End Using

            'Else

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_CustomEstimates.DataSource = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.Load(ReportingDbContext).ToList '.Select(Function(Entity) New AdvantageFramework.Estimate.Printing.Classes.CustomEstimateReport(Entity)).OrderBy(Function(Entity) Entity.Description).ToList

            End Using

            'End If

            DataGridViewForm_CustomEstimates.CurrentView.BestFitColumns()

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Add.Enabled = True

            ButtonItemActions_View.Enabled = DataGridViewForm_CustomEstimates.HasOnlyOneSelectedRow
            ButtonItemActions_UpdateInfo.Enabled = DataGridViewForm_CustomEstimates.HasOnlyOneSelectedRow
            ButtonItemActions_EditReport.Enabled = DataGridViewForm_CustomEstimates.HasOnlyOneSelectedRow
            ButtonItemActions_Delete.Enabled = DataGridViewForm_CustomEstimates.HasASelectedRow
            ButtonItemActions_Copy.Enabled = DataGridViewForm_CustomEstimates.HasOnlyOneSelectedRow

            ButtonItemActions_Refresh.Enabled = True

        End Sub
        'Private Sub ViewCustomInvoice()

        '    'objects
        '    Dim UDReport As AdvantageFramework.Database.Classes.UDReport = Nothing

        '    If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

        '        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '            Try

        '                UDReport = DataGridViewForm_Reports.GetFirstSelectedRowDataBoundItem

        '            Catch ex As Exception
        '                UDReport = Nothing
        '            End Try

        '            If UDReport IsNot Nothing Then

        '                AdvantageFramework.Desktop.Presentation.CustomInvoiceEditForm.ShowForm(False, UDReport.ID, True)

        '            End If

        '        End Using

        '    Else

        '        AdvantageFramework.WinForm.MessageBox.Show("Please select a report to view.")

        '    End If

        'End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CustomEstimateReportsForm As CustomEstimateReportsForm = Nothing

            CustomEstimateReportsForm = New CustomEstimateReportsForm

            CustomEstimateReportsForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CustomEstimateReportsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim UserDefinedReportCategoryBindingSource As System.Windows.Forms.BindingSource = Nothing

            Me.ShowUnsavedChangesOnFormClosing = False

            RibbonBarOptions_ReportCategory.Visible = False
            ButtonItemActions_View.Visible = False

            ButtonItemActions_View.Image = My.Resources.InvoicePrintImage
            ButtonItemActions_Add.Image = My.Resources.AddImage
            ButtonItemActions_UpdateInfo.Image = My.Resources.UpdateReportInfoImage
            ButtonItemActions_EditReport.Image = My.Resources.ReportEditImage
            ButtonItemActions_Delete.Image = My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = My.Resources.CopyImage
            ButtonItemActions_Refresh.Image = My.Resources.RefreshImage

            DataGridViewForm_CustomEstimates.MultiSelect = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                '_InvoiceTypes = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.InvoicePrinting.InvoiceTypes))

                'Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                '    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DisplayMember = "Description"
                '    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.ValueMember = "ID"

                '    UserDefinedReportCategoryBindingSource = New System.Windows.Forms.BindingSource

                '    UserDefinedReportCategoryBindingSource.DataSource = (From UserDefinedReportCategory In AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext) _
                '                                                         Select New With {.ID = UserDefinedReportCategory.ID, _
                '                                                                          .Description = UserDefinedReportCategory.Description}).ToList

                '    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(UserDefinedReportCategoryBindingSource, ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DisplayMember, _
                '                                                                                      ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.ValueMember, _
                '                                                                                      "[All]", -1, True, True)

                '    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DataSource = UserDefinedReportCategoryBindingSource

                '    ComboBoxItemReportCategory_ReportCategory.SelectedIndex = 0

                'End Using

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        'Private Sub ComboBoxItemReportCategory_ReportCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemReportCategory_ReportCategory.SelectedIndexChanged

        '    If Me.FormAction = WinForm.Presentation.FormActions.None Then

        '        Me.ShowWaitForm()

        '        Try

        '            LoadGrid()

        '        Catch ex As Exception

        '        End Try

        '        Me.CloseWaitForm()

        '    End If

        'End Sub
        'Private Sub ButtonItemActions_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_View.Click

        '    If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

        '        ViewCustomInvoice()

        '    End If

        'End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            AdvantageFramework.ProjectManagement.Reports.Presentation.CustomEstimateReportWriterEditForm.ShowFormDialog(Me.Session, 0)

        End Sub
        Private Sub ButtonItemActions_EditReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_EditReport.Click

            'objects
            Dim ReportID As Integer = 0

            Try

                ReportID = DataGridViewForm_CustomEstimates.GetFirstSelectedRowBookmarkValue(0)

            Catch ex As Exception
                ReportID = 0
            End Try

            If ReportID > 0 Then

                AdvantageFramework.ProjectManagement.Reports.Presentation.CustomEstimateReportWriterEditForm.ShowFormDialog(Me.Session, ReportID)

            End If

        End Sub
        Private Sub ButtonItemActions_UpdateInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_UpdateInfo.Click

            'objects
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
            Dim ReportID As Integer = 0
            Dim ReloadGrid As Boolean = False

            Try

                ReportID = DataGridViewForm_CustomEstimates.GetFirstSelectedRowBookmarkValue(0)

            Catch ex As Exception
                ReportID = 0
            End Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EstimateReport = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.LoadByEstimateReportID(ReportingDbContext, ReportID)

            End Using

            If EstimateReport IsNot Nothing Then

                If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Invoice, EstimateReport.ID, EstimateReport.EstimateReportType, EstimateReport.Description, 0, False) = Windows.Forms.DialogResult.OK Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        EstimateReport.UpdatedByUserCode = Me.Session.UserCode
                        EstimateReport.UpdatedDate = Now

                        ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.Update(ReportingDbContext, EstimateReport)

                    End Using

                End If

            End If

            If ReloadGrid Then

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
            Dim ReportID As Integer = 0
            Dim ReloadGrid As Boolean = False

            If DataGridViewForm_CustomEstimates.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this report?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm()

                    Try

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                For Each ReportID In DataGridViewForm_CustomEstimates.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                                    Try

                                        EstimateReport = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.LoadByEstimateReportID(ReportingDbContext, ReportID)

                                    Catch ex As Exception
                                        EstimateReport = Nothing
                                    End Try

                                    If EstimateReport IsNot Nothing Then

                                        ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.Delete(ReportingDbContext, EstimateReport)

                                    End If

                                Next

                            End Using

                        End Using

                        If ReloadGrid Then

                            LoadGrid()

                        End If

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_CustomInvoices_RowDoubleClickEvent() Handles DataGridViewForm_CustomEstimates.RowDoubleClickEvent

            If DataGridViewForm_CustomEstimates.HasOnlyOneSelectedRow Then

                ButtonItemActions_EditReport.RaiseClick()

            End If

        End Sub
        Private Sub DataGridViewForm_CustomInvoices_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_CustomEstimates.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
