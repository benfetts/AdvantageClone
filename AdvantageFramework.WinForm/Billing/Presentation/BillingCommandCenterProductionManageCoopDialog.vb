Namespace Billing.Presentation

    Public Class BillingCommandCenterProductionManageCoopDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Jobs As IEnumerable(Of Integer) = Nothing
        Private _BillingCommandCenterID As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Jobs As IEnumerable(Of Integer), ByVal BillingCommandCenterID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Jobs = Jobs
            _BillingCommandCenterID = BillingCommandCenterID

        End Sub
        Private Sub LoadGrid()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DataGridViewPanel_Jobs.DataSource = (From Job In AdvantageFramework.Database.Procedures.Job.Load(DbContext).Include("Client").Include("Division").Include("Product")
                                                     Where _Jobs.Contains(Job.Number)
                                                     Select Job).ToList.Select(Function(Job) New AdvantageFramework.BillingCommandCenter.Classes.JobCoop(DbContext, Job)).ToList

            End Using

            ToggleColumnVisibility()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = DataGridViewPanel_Jobs.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = DataGridViewPanel_Jobs.UserEntryChanged

            ButtonItemEdit_CoopSplits.Enabled = DataGridViewPanel_Jobs.HasASelectedRow AndAlso
                    DataGridViewPanel_Jobs.CurrentView.GetRowCellValue(DataGridViewPanel_Jobs.CurrentView.FocusedRowHandle, AdvantageFramework.BillingCommandCenter.Classes.JobCoop.Properties.BillingCoopCode.ToString) <> ""

        End Sub
        Private Sub ToggleColumnVisibility()

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0
            Dim IsVisible As Boolean = False

            IsVisible = ButtonItemView_ShowDescriptions.Checked

            For Each GridColumn In DataGridViewPanel_Jobs.Columns

                If (GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobCoop.Properties.ClientName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobCoop.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.JobCoop.Properties.ProductDescription.ToString) AndAlso
                        Not IsVisible Then

                    GridColumn.VisibleIndex = -1
                    GridColumn.Visible = False

                Else

                    GridColumn.VisibleIndex = VisibleIndex
                    VisibleIndex += 1
                    GridColumn.Visible = True

                End If

            Next

            DataGridViewPanel_Jobs.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Overloads Shared Sub ShowDialog(ByVal Jobs As IEnumerable(Of Integer), ByVal BillingCommandCenterID As Integer)

            'objects
            Dim BillingCommandCenterProductionManageCoopDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionManageCoopDialog = Nothing

            BillingCommandCenterProductionManageCoopDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionManageCoopDialog(Jobs, BillingCommandCenterID)

            BillingCommandCenterProductionManageCoopDialog.ShowDialog()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterProductionManageCoopDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemEdit_CoopSplits.Image = AdvantageFramework.My.Resources.MaintenanceImage

            ButtonItemEdit_CoopSplits.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_BillingCoop)

            ButtonItemView_ShowDescriptions.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage

            DataGridViewPanel_Jobs.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            LoadGrid()

            EnableOrDisableActions()

        End Sub
        Private Sub RefreshBillingCoopDatasource()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            If DataGridViewPanel_Jobs.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobCoop.Properties.BillingCoopCode.ToString) IsNot Nothing Then

                GridColumn = DataGridViewPanel_Jobs.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.JobCoop.Properties.BillingCoopCode.ToString)

                Try

                    SubItemGridLookUpEditControl = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                Catch ex As Exception
                    SubItemGridLookUpEditControl = Nothing
                End Try

                If SubItemGridLookUpEditControl IsNot Nothing Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        SubItemGridLookUpEditControl.DataSource = AdvantageFramework.Database.Procedures.BillingCoop.LoadAllActive(DbContext)

                    End Using

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Dim JobCoop As AdvantageFramework.BillingCommandCenter.Classes.JobCoop = Nothing

            If DataGridViewPanel_Jobs.HasRows Then

                DataGridViewPanel_Jobs.CurrentView.CloseEditorForUpdating()

                Me.ShowWaitForm("Saving...")

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each JobCoop In DataGridViewPanel_Jobs.GetAllModifiedRows

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_LOG SET BILL_COOP_CODE = {0} WHERE JOB_NUMBER = {1}", If(String.IsNullOrWhiteSpace(JobCoop.BillingCoopCode), "NULL", "'" & JobCoop.BillingCoopCode & "'"), JobCoop.JobNumber))

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.BILLING SET INV_PROCESSED = 0 WHERE BILLING_USER = (SELECT BILLING_USER FROM dbo.BILLING_CMD_CENTER WHERE BCC_ID = {0})", _BillingCommandCenterID))

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                LoadGrid()

                Me.ClearChanged()

                EnableOrDisableActions()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemEdit_CoopSplits_Click(sender As Object, e As EventArgs) Handles ButtonItemEdit_CoopSplits.Click

            Dim JobCoop As AdvantageFramework.BillingCommandCenter.Classes.JobCoop = Nothing

            DataGridViewPanel_Jobs.CurrentView.CloseEditorForUpdating()

            If DataGridViewPanel_Jobs.HasOnlyOneSelectedRow Then

                JobCoop = DirectCast(DataGridViewPanel_Jobs.CurrentView.GetRow(DataGridViewPanel_Jobs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.JobCoop)

                'If String.IsNullOrWhiteSpace(JobCoop.BillingCoopCode) Then

                '    If AdvantageFramework.Maintenance.Accounting.Presentation.BillingCoopEditDialog.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                '        RefreshBillingCoopDatasource()

                '    End If

                'Else

                If JobCoop.BillingCoopCode IsNot Nothing Then

                    If AdvantageFramework.Maintenance.Accounting.Presentation.BillingCoopEditDialog.ShowFormDialog(JobCoop.BillingCoopCode) = Windows.Forms.DialogResult.OK Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.BILLING SET INV_PROCESSED = 0 WHERE BILLING_USER = (SELECT BILLING_USER FROM dbo.BILLING_CMD_CENTER WHERE BCC_ID = {0})", _BillingCommandCenterID))

                        End Using

                    End If

                End If
                
                'End If

            End If

        End Sub
        Private Sub DataGridViewPanel_Jobs_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewPanel_Jobs.ColumnValueChangedEvent

            DataGridViewPanel_Jobs.CurrentView.CloseEditor()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewPanel_Jobs_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewPanel_Jobs.PopupMenuShowingEvent

            AdvantageFramework.Billing.Presentation.HideGroupByMenuOptions(e)

        End Sub
        Private Sub DataGridViewPanel_Jobs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewPanel_Jobs.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemView_ShowDescriptions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_ShowDescriptions.CheckedChanged

            ToggleColumnVisibility()

        End Sub

#End Region

#End Region

    End Class

End Namespace