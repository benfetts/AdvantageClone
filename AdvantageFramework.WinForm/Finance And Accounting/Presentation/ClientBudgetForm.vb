Namespace FinanceAndAccounting.Presentation

    Public Class ClientBudgetForm

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

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_ClientBudgets.DataSource = AdvantageFramework.Database.Procedures.Budget.Load(DbContext).OrderBy(Function(Budget) Budget.EmployeeCode).ThenBy(Function(Budget) Budget.Code)

                End Using

            End Using

            DataGridViewLeftSection_ClientBudgets.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            RibbonBarMergeContainerForm_Options.SuspendLayout()

            PanelForm_RightSection.Enabled = (DataGridViewLeftSection_ClientBudgets.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            RibbonBarMergeContainerForm_Options.ResumeLayout()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ClientBudgetForm As AdvantageFramework.FinanceAndAccounting.Presentation.ClientBudgetForm = Nothing

            ClientBudgetForm = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientBudgetForm()

            ClientBudgetForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientBudgetForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Add.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_ClientBudgets)
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            DataGridViewLeftSection_ClientBudgets.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            End Using

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_ClientBudgets.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ClientBudgetForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_ClientBudgets.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            Dim ClientCode As String = Nothing

            If DataGridViewLeftSection_ClientBudgets.HasOnlyOneSelectedRow AndAlso DataGridViewLeftSection_ClientBudgets.GetFirstSelectedRowBookmarkValue IsNot Nothing Then

                ClientCode = DataGridViewLeftSection_ClientBudgets.GetFirstSelectedRowBookmarkValue

            End If

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ClientInvoiceBatchReportList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim [From] As Date = Nothing
            Dim [To] As Date = Nothing
            Dim UserCode As String = Nothing
            Dim IsBatch As Boolean = False
            Dim ReportRange As String = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFromDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterToDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsBatch As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
            SqlParameterFromDate = New SqlClient.SqlParameter("@from_date", SqlDbType.SmallDateTime)
            SqlParameterToDate = New SqlClient.SqlParameter("@to_date", SqlDbType.SmallDateTime)
            SqlParameterIsBatch = New SqlClient.SqlParameter("@is_batch", SqlDbType.Int)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserCode = Me.Session.UserCode

                If AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceBatchReportDialog.ShowFormDialog(ReportType, [From], [To], UserCode, IsBatch) = System.Windows.Forms.DialogResult.OK Then

                    SqlParameterUserCode.Value = UserCode
                    SqlParameterFromDate.Value = [From]

                    If IsBatch Then

                        SqlParameterToDate.Value = System.DBNull.Value
                        SqlParameterIsBatch.Value = 1
                        ReportRange = "Batch: " & [From].ToString

                    Else

                        SqlParameterToDate.Value = [To]
                        SqlParameterIsBatch.Value = 0
                        ReportRange = "Date Range: " & [From].ToShortDateString & " - " & [To].ToShortDateString

                    End If

                    ClientInvoiceBatchReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport)("exec advsp_clientinvoice_batch_report @user_code, @from_date, @to_date, @is_batch", SqlParameterUserCode, SqlParameterFromDate, SqlParameterToDate, SqlParameterIsBatch).ToList()

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    ParameterDictionary.Add("DataSource", ClientInvoiceBatchReportList)
                    ParameterDictionary.Add("ForUser", UserCode)
                    ParameterDictionary.Add("ReportRange", ReportRange)

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                End If

            End Using

        End Sub
        Private Sub DataGridViewLeftSection_Clients_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_ClientBudgets.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace