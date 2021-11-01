Namespace Billing.Presentation

    Public Class BillingCommandCenterProductionVendorWriteoff

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _AccountPayableWriteoffs As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff) = Nothing
        Private _IsAPLimitByOfficeEnabled As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal AccountPayableWriteoffs As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _AccountPayableWriteoffs = AccountPayableWriteoffs

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_WriteOffs.DataSource = _AccountPayableWriteoffs
            DataGridViewForm_WriteOffs.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = DataGridViewForm_WriteOffs.UserEntryChanged

        End Sub
        Private Function WriteOffItems(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim AccountPayableWriteoff As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff = Nothing
            Dim Complete As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    Me.ShowWaitForm("Processing...")

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    For Each AccountPayableWriteoff In DataGridViewForm_WriteOffs.GetAllRowsDataBoundItems

                        AdvantageFramework.BillingCommandCenter.WriteOffAP(DbContext, AccountPayableWriteoff, Session)

                    Next

                    DbTransaction.Commit()

                    Complete = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += vbCrLf & ex.Message
                Finally

                    If DbContext.Database.Connection.State = ConnectionState.Open Then

                        DbContext.Database.Connection.Close()

                    End If

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    Me.CloseWaitForm()

                End Try

            End Using

            WriteOffItems = Complete

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal AccountPayableWriteoffs As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff)) As Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterProductionVendorWriteoff As AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionVendorWriteoff = Nothing

            BillingCommandCenterProductionVendorWriteoff = New AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionVendorWriteoff(AccountPayableWriteoffs)

            ShowFormDialog = BillingCommandCenterProductionVendorWriteoff.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorAccountPayableWriteOffDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_SetGLAccount.Image = AdvantageFramework.My.Resources.GeneralLedgerReplaceImage

            DataGridViewForm_WriteOffs.ShowSelectDeselectAllButtons = True

            If _AccountPayableWriteoffs.Count > 0 Then

                JobNumber = _AccountPayableWriteoffs.First.AccountPayableProductionDistributionDetail.JobNumber
                JobComponentNumber = _AccountPayableWriteoffs.First.AccountPayableProductionDistributionDetail.JobComponentNumber

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                    SearchableComboBoxForm_Job.DataSource = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                    SearchableComboBoxForm_JobComponent.DataSource = JobComponent

                    SearchableComboBoxForm_Job.SelectedValue = JobComponent.JobNumber
                    SearchableComboBoxForm_JobComponent.SelectedValue = JobComponent.Number

                    _IsAPLimitByOfficeEnabled = AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext)

                End Using

            End If

            LoadGrid()

            Me.ClearChanged()

            If _AccountPayableWriteoffs.Where(Function(APWO) String.IsNullOrWhiteSpace(APWO.GLACode) = False).Any Then

                DataGridViewForm_WriteOffs.SetUserEntryChanged()

                DataGridViewForm_WriteOffs.ValidateAllRows()

            End If

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_SetGLAccount_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_SetGLAccount.Click

            Dim AccountPayableWriteoffList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff) = Nothing
            Dim SelectedGeneralLedgerAccounts As IEnumerable = Nothing
            Dim GLACode As String = Nothing
            Dim GLADescription As String = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            DataGridViewForm_WriteOffs.CurrentView.CloseEditorForUpdating()

            If DataGridViewForm_WriteOffs.HasASelectedRow Then

                AccountPayableWriteoffList = DataGridViewForm_WriteOffs.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff)().ToList()

                ParameterDictionary = New Generic.Dictionary(Of String, Object)
                ParameterDictionary.Add("OfficeCode", DirectCast(DataGridViewForm_WriteOffs.CurrentView.GetRow(DataGridViewForm_WriteOffs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff).AccountPayableProductionDistributionDetail.OfficeCode)

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.GeneralLedgerAccount, True, True, SelectedGeneralLedgerAccounts, False, ParameterDictionary:=ParameterDictionary) = Windows.Forms.DialogResult.OK Then

                    If SelectedGeneralLedgerAccounts IsNot Nothing Then

                        Try

                            GLACode = (From Entity In SelectedGeneralLedgerAccounts
                                       Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            GLACode = Nothing
                        End Try

                        If Not String.IsNullOrEmpty(GLACode) Then

                            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                Try

                                    GLADescription = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GLACode).Description

                                Catch ex As Exception
                                    GLADescription = Nothing
                                End Try

                            End Using

                            For Each AccountPayableWriteoff In AccountPayableWriteoffList

                                AccountPayableWriteoff.GLACode = GLACode
                                AccountPayableWriteoff.GLAccountDescription = GLADescription

                            Next

                            DataGridViewForm_WriteOffs.SetUserEntryChanged()

                            EnableOrDisableActions()

                        End If

                    End If

                    DataGridViewForm_WriteOffs.ValidateAllRows()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Dim ErrorMessage As String = Nothing
            Dim WriteoffTotal As Decimal = Nothing

            DataGridViewForm_WriteOffs.CurrentView.CloseEditorForUpdating()
            DataGridViewForm_WriteOffs.ValidateAllRows()

            If Not DataGridViewForm_WriteOffs.HasAnyInvalidRows Then

                WriteoffTotal = DataGridViewForm_WriteOffs.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff).Sum(Function(WO) WO.NetAmount)

                If AdvantageFramework.WinForm.MessageBox.Show("You are about to write off " & WriteoffTotal.ToString("n2") & ".  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, Nothing, Windows.Forms.MessageBoxIcon.Question, Windows.Forms.MessageBoxDefaultButton.Button2) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If WriteOffItems(ErrorMessage) Then

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.ClearChanged()
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Fix errors in grid.")

            End If

        End Sub
        Private Sub DataGridViewForm_WriteOffs_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_WriteOffs.CellValueChangedEvent

            Dim AccountPayableProductionDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail = Nothing

            AccountPayableProductionDistributionDetail = DirectCast(DataGridViewForm_WriteOffs.CurrentView.GetRow(DataGridViewForm_WriteOffs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff).AccountPayableProductionDistributionDetail

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff.Properties.NetAmount.ToString Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If AccountPayableProductionDistributionDetail.Quantity IsNot Nothing Then

                        AccountPayableProductionDistributionDetail.Quantity = Nothing

                    End If

                    AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Amount, AccountPayableProductionDistributionDetail, DbContext)

                    AccountPayableProductionDistributionDetail.ExtendedMarkupAmount = FormatNumber(AccountPayableProductionDistributionDetail.ExtendedAmount.GetValueOrDefault(0) *
                                                                                                   AccountPayableProductionDistributionDetail.CommissionPercent.GetValueOrDefault(0) / 100, 2)

                    AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateTax(DbContext, AccountPayableProductionDistributionDetail.AccountPayableProduction)

                    AccountPayableProductionDistributionDetail.AccountPayableProduction.SetLineTotal()

                End Using

            ElseIf e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff.Properties.Quantity.ToString Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Quantity, AccountPayableProductionDistributionDetail, DbContext)

                    AccountPayableProductionDistributionDetail.ExtendedMarkupAmount = FormatNumber(AccountPayableProductionDistributionDetail.ExtendedAmount.GetValueOrDefault(0) *
                                                                                                   AccountPayableProductionDistributionDetail.CommissionPercent.GetValueOrDefault(0) / 100, 2)

                    AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateTax(DbContext, AccountPayableProductionDistributionDetail.AccountPayableProduction)

                    AccountPayableProductionDistributionDetail.AccountPayableProduction.SetLineTotal()

                End Using

            End If

            DataGridViewForm_WriteOffs.CurrentView.UpdateTotalSummary()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_WriteOffs_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_WriteOffs.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewForm_WriteOffs.CurrentView.OptionsView.ShowFooter = True

                DataGridViewForm_WriteOffs.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewForm_WriteOffs.CurrentView.Appearance.OddRow.BackColor = Drawing.Color.FromArgb(240, 240, 240)

                If DataGridViewForm_WriteOffs.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff.Properties.NetAmount.ToString) IsNot Nothing Then

                    GridColumn = DataGridViewForm_WriteOffs.Columns(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff.Properties.NetAmount.ToString)

                    SetColumnAsSumColumn(DataGridViewForm_WriteOffs, GridColumn.FieldName)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_WriteOffs_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_WriteOffs.QueryPopupNeedDatasourceEvent

            Dim OfficeCode As String = Nothing

            If FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff.Properties.PostPeriodCode.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveAPPostPeriods(DbContext)

                End Using

            ElseIf FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff.Properties.GLACode.ToString Then

                OverrideDefaultDatasource = True

                OfficeCode = DirectCast(DataGridViewForm_WriteOffs.CurrentView.GetRow(DataGridViewForm_WriteOffs.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff).AccountPayableProductionDistributionDetail.OfficeCode

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, OfficeCode, Session)

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_WriteOffs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_WriteOffs.SelectionChangedEvent

            Dim AccountPayableWriteoffs As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff) = Nothing

            If _IsAPLimitByOfficeEnabled Then

                AccountPayableWriteoffs = DataGridViewForm_WriteOffs.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff).ToList()

                If (From AP In AccountPayableWriteoffs
                    Select AP.AccountPayableProductionDistributionDetailOriginal.OfficeCode).Distinct.Count > 1 Then

                    ButtonItemActions_SetGLAccount.Enabled = False

                Else

                    ButtonItemActions_SetGLAccount.Enabled = True

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace