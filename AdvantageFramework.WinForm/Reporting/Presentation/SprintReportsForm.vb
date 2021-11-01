Namespace Reporting.Presentation

    Public Class SprintReportsForm

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

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim UserDefinedReportCategoryID As Integer = 0

            Try

                UserDefinedReportCategoryID = ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.SelectedValue

            Catch ex As Exception
                UserDefinedReportCategoryID = 0
            End Try

            If UserDefinedReportCategoryID > 0 Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DataGridViewForm_Reports.DataSource = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList.Where(Function(Entity) Entity.UserDefinedReportCategoryID.GetValueOrDefault(0) = UserDefinedReportCategoryID AndAlso (Entity.Type = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek)).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                    End Using

                End Using

            Else

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DataGridViewForm_Reports.DataSource = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList.Where(Function(Entity) (Entity.Type = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek)).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                    End Using

                End Using

            End If

            DataGridViewForm_Reports.CurrentView.BestFitColumns()

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Add.Enabled = True

            ButtonItemActions_View.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow
            ButtonItemActions_UpdateInfo.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow
            ButtonItemActions_EditReport.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow
            ButtonItemActions_Delete.Enabled = DataGridViewForm_Reports.HasASelectedRow
            ButtonItemActions_Copy.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow

            ButtonItemActions_Refresh.Enabled = True

        End Sub
        Private Sub ViewDynamicReport()

            'objects
            Dim UDReport As AdvantageFramework.Database.Classes.UDReport = Nothing
            Dim SprintUDReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

            If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        UDReport = DataGridViewForm_Reports.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        UDReport = Nothing
                    End Try

                    If UDReport IsNot Nothing Then

                        SprintUDReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, UDReport.ID)

                        AdvantageFramework.Reporting.Presentation.SprintReportEditForm.ShowForm(UDReport.ID)

                    End If

                End Using

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a report to view.")

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim SprintReportsForm As SprintReportsForm = Nothing

            SprintReportsForm = New SprintReportsForm

            SprintReportsForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub SprintReportsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim UserDefinedReportCategoryBindingSource As System.Windows.Forms.BindingSource = Nothing

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_View.Image = My.Resources.DynamicReportImage
            ButtonItemActions_Add.Image = My.Resources.AddImage
            ButtonItemActions_UpdateInfo.Image = My.Resources.UpdateReportInfoImage
            ButtonItemActions_EditReport.Image = My.Resources.ReportEditImage
            ButtonItemActions_Delete.Image = My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = My.Resources.CopyImage
            ButtonItemActions_Refresh.Image = My.Resources.RefreshImage

            DataGridViewForm_Reports.MultiSelect = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DisplayMember = "Description"
                    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.ValueMember = "ID"

                    UserDefinedReportCategoryBindingSource = New System.Windows.Forms.BindingSource

                    UserDefinedReportCategoryBindingSource.DataSource = (From UserDefinedReportCategory In AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext)
                                                                         Select New With {.ID = UserDefinedReportCategory.ID,
                                                                                          .Description = UserDefinedReportCategory.Description}).ToList.OrderBy(Function(UserDefinedReportCategory) UserDefinedReportCategory.Description).ToList

                    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(UserDefinedReportCategoryBindingSource, ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DisplayMember,
                                                                                                      ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.ValueMember,
                                                                                                      "[All]", -1, True, True)

                    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DataSource = UserDefinedReportCategoryBindingSource

                    ComboBoxItemReportCategory_ReportCategory.SelectedIndex = 0

                End Using

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxItemReportCategory_ReportCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemReportCategory_ReportCategory.SelectedIndexChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_View.Click

            If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

                ViewDynamicReport()

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            AdvantageFramework.Reporting.Presentation.SprintReportEditForm.ShowForm(0)

        End Sub
        Private Sub ButtonItemActions_EditReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_EditReport.Click

            'objects
            Dim ReportID As Integer = 0
            Dim SprintUDReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

            Try

                ReportID = DataGridViewForm_Reports.GetFirstSelectedRowBookmarkValue(0)

            Catch ex As Exception
                ReportID = 0
            End Try

            If ReportID > 0 Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                    SprintUDReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, ReportID)

                End Using

                AdvantageFramework.Reporting.Presentation.SprintReportEditForm.ShowForm(ReportID)

            End If

        End Sub
        Private Sub ButtonItemActions_UpdateInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_UpdateInfo.Click

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim ReportID As Integer = 0
            Dim ReloadGrid As Boolean = False

            Try

                ReportID = DataGridViewForm_Reports.GetFirstSelectedRowBookmarkValue(0)

            Catch ex As Exception
                ReportID = 0
            End Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, ReportID)

                If DynamicReport IsNot Nothing Then

                End If

            End Using

            If DynamicReport IsNot Nothing Then

                If AdvantageFramework.Reporting.Presentation.SprintReportUpdateDialog.ShowFormDialog(DynamicReport.ID, DynamicReport.Description, DynamicReport.UserDefinedReportCategoryID, False) = Windows.Forms.DialogResult.OK Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DynamicReport.UpdatedByUserCode = Me.Session.UserCode
                        DynamicReport.UpdatedDate = Now

                        ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport)

                    End Using

                End If

            End If

            If ReloadGrid Then

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim ReportID As Integer = 0
            Dim ReloadGrid As Boolean = False

            If DataGridViewForm_Reports.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this report?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm()

                    Try

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                For Each ReportID In DataGridViewForm_Reports.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                                    Try

                                        DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, ReportID)

                                    Catch ex As Exception
                                        DynamicReport = Nothing
                                    End Try

                                    If DynamicReport IsNot Nothing Then

                                        ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Delete(ReportingDbContext, DataContext, DynamicReport)

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
        Private Sub DataGridViewForm_Reports_RowDoubleClickEvent() Handles DataGridViewForm_Reports.RowDoubleClickEvent

            If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

                ViewDynamicReport()

            End If

        End Sub
        Private Sub DataGridViewForm_Reports_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Reports.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
