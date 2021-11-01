Namespace GeneralLedger.Maintenance.Presentation

    Public Class ChartOfAccountsSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _HomeCurrencyCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Function LoadGrid() As Boolean

            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing
            Dim ChartOfAccountList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) = Nothing
            Dim HasOfficeSegment As Boolean = False
            Dim HideCurrencyColumn As Boolean = True
            Dim Loaded As Boolean = True

            ChartOfAccountList = New Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ChartOfAccount)

            DataGridViewForm_GeneralLedgerAccounts.SuspendLayout()

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

                If GeneralLedgerConfig IsNot Nothing Then

                    If GeneralLedgerConfig.Segment1Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office Then

                        HasOfficeSegment = True

                    ElseIf GeneralLedgerConfig.Segment2Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office Then

                        HasOfficeSegment = True

                    ElseIf GeneralLedgerConfig.Segment3Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office Then

                        HasOfficeSegment = True

                    ElseIf GeneralLedgerConfig.Segment4Type.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office Then

                        HasOfficeSegment = True

                    End If

                    If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

                        _HomeCurrencyCode = AdvantageFramework.Database.Procedures.Agency.GetHomeCurrency(DbContext)

                        HideCurrencyColumn = False

                    End If

                    If HasOfficeSegment = False OrElse Me.Session.HasLimitedOfficeCodes = False Then

                        ChartOfAccountList.AddRange(From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext).ToList
                                                    Select New AdvantageFramework.GeneralLedger.Classes.ChartOfAccount(Entity, GeneralLedgerConfig))

                    Else

                        ChartOfAccountList.AddRange(From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Me.Session).ToList
                                                    Select New AdvantageFramework.GeneralLedger.Classes.ChartOfAccount(Entity, GeneralLedgerConfig))

                    End If

                    DataGridViewForm_GeneralLedgerAccounts.DataSource = ChartOfAccountList


                    OrderColumnsBasedOnConfiguration(GeneralLedgerConfig, Me.DataGridViewForm_GeneralLedgerAccounts)

                    'If HideCurrencyColumn AndAlso DataGridViewForm_GeneralLedgerAccounts.CurrentView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.CurrencyCode.ToString) IsNot Nothing Then

                    '    DataGridViewForm_GeneralLedgerAccounts.CurrentView.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.CurrencyCode.ToString).Visible = False

                    'End If

                    DataGridViewForm_GeneralLedgerAccounts.CurrentView.BestFitColumns()

                    DataGridViewForm_GeneralLedgerAccounts.ResumeLayout()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("GL Configuration has not been created.")

                    Loaded = False

                End If

            End Using

            LoadGrid = Loaded

        End Function
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_GeneralLedgerAccounts.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged AndAlso DataGridViewForm_GeneralLedgerAccounts.HasAnyInvalidRows = False
                ButtonItemActions_Delete.Enabled = DataGridViewForm_GeneralLedgerAccounts.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ChartOfAccountsSetupForm As AdvantageFramework.GeneralLedger.Maintenance.Presentation.ChartOfAccountsSetupForm = Nothing

            ChartOfAccountsSetupForm = New AdvantageFramework.GeneralLedger.Maintenance.Presentation.ChartOfAccountsSetupForm()

            ChartOfAccountsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ChartOfAccountsSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

        End Sub
        Private Sub ChartOfAccountsSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If LoadGrid() Then

                DataGridViewForm_GeneralLedgerAccounts.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Else

                Me.Close()

            End If

        End Sub
        Private Sub ChartOfAccountsSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ChartOfAccountsSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_GeneralLedgerAccounts.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            If AdvantageFramework.GeneralLedger.Maintenance.Presentation.CreateChartOfAccountWizardDialog.ShowWizardDialog() = Windows.Forms.DialogResult.OK Then

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ChartOfAccounts As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) = Nothing

            DataGridViewForm_GeneralLedgerAccounts.CurrentView.CloseEditorForUpdating()

            If DataGridViewForm_GeneralLedgerAccounts.HasRows AndAlso DataGridViewForm_GeneralLedgerAccounts.HasAnyInvalidRows = False Then

                ChartOfAccounts = DataGridViewForm_GeneralLedgerAccounts.GetAllModifiedRows.OfType(Of AdvantageFramework.GeneralLedger.Classes.ChartOfAccount)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ChartOfAccount In ChartOfAccounts

                            DbContext.UpdateObject(ChartOfAccount.GeneralLedgerAccount)

                        Next

                        DbContext.SaveChanges()

                    End Using

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

                EnableOrDisableActions()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows.")

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ChartOfAccount As AdvantageFramework.GeneralLedger.Classes.ChartOfAccount = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim Failed As Boolean = False

            If DataGridViewForm_GeneralLedgerAccounts.HasASelectedRow Then

                DataGridViewForm_GeneralLedgerAccounts.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_GeneralLedgerAccounts.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    ChartOfAccount = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    ChartOfAccount = Nothing
                                End Try

                                If ChartOfAccount IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Delete(DbContext, ChartOfAccount.GeneralLedgerAccount) Then

                                        DataGridViewForm_GeneralLedgerAccounts.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    Else

                                        Failed = True

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_GeneralLedgerAccounts.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                    If Failed Then

                        AdvantageFramework.WinForm.MessageBox.Show("One or more account(s) is in use and cannot be deleted.")

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_GeneralLedgerAccounts.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.CellValueChangedEvent

            DataGridView_GeneralLedgerAccounts_CellValueChanged(DataGridViewForm_GeneralLedgerAccounts, e)

            If Not DataGridViewForm_GeneralLedgerAccounts.CurrentView.IsNewItemRow(DataGridViewForm_GeneralLedgerAccounts.CurrentView.FocusedRowHandle) Then

                DirectCast(DataGridViewForm_GeneralLedgerAccounts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.GeneralLedger.Classes.ChartOfAccount).UserCode = Session.UserCode
                DirectCast(DataGridViewForm_GeneralLedgerAccounts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.GeneralLedger.Classes.ChartOfAccount).ModifiedDate = Now.ToShortDateString

            End If

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.InitNewRowEvent

            If TypeOf DataGridViewForm_GeneralLedgerAccounts.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.GeneralLedger.Classes.ChartOfAccount Then

                DirectCast(DataGridViewForm_GeneralLedgerAccounts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.GeneralLedger.Classes.ChartOfAccount).DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
                DirectCast(DataGridViewForm_GeneralLedgerAccounts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.GeneralLedger.Classes.ChartOfAccount).GeneralLedgerAccount.Active = "A"
                'DirectCast(DataGridViewForm_GeneralLedgerAccounts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.GeneralLedger.Classes.ChartOfAccount).CurrencyCode = _HomeCurrencyCode

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_GeneralLedgerAccounts.AddNewRowEvent

            'objects
            Dim ChartOfAccount As AdvantageFramework.GeneralLedger.Classes.ChartOfAccount = Nothing

            If TypeOf RowObject Is AdvantageFramework.GeneralLedger.Classes.ChartOfAccount Then

                Me.ShowWaitForm("Processing...")

                ChartOfAccount = RowObject
                ChartOfAccount.UserCode = Session.UserCode
                ChartOfAccount.EnteredDate = Now.ToShortDateString

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ChartOfAccount.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Insert(DbContext, ChartOfAccount.GeneralLedgerAccount)

                End Using

                DataGridViewForm_GeneralLedgerAccounts.CurrentView.BeginSort()

                Try

                    DataGridViewForm_GeneralLedgerAccounts.CurrentView.ClearSorting()
                    DataGridViewForm_GeneralLedgerAccounts.Columns(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Code.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                Finally

                    DataGridViewForm_GeneralLedgerAccounts.CurrentView.EndSort()

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.CellValueChangingEvent

            'objects
            Dim ChartOfAccount As AdvantageFramework.GeneralLedger.Classes.ChartOfAccount = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.IsInactive.ToString Then

                Try

                    ChartOfAccount = DataGridViewForm_GeneralLedgerAccounts.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ChartOfAccount = Nothing
                End Try

                If ChartOfAccount IsNot Nothing Then

                    ChartOfAccount.IsInactive = e.Value
                    ChartOfAccount.ModifiedDate = Now.ToShortTimeString
                    ChartOfAccount.UserCode = Me.Session.UserCode

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Update(DbContext, ChartOfAccount.GeneralLedgerAccount)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.CustomDrawCellEvent

            If e.Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.BalanceType.ToString  Then

                If e.CellValue <> 1 Then

                    e.Appearance.ForeColor = Drawing.Color.Red

                Else

                    e.Appearance.ForeColor = Drawing.Color.Black

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.Type.ToString Then

                If e.CellValue IsNot Nothing AndAlso IsNumeric(e.CellValue) Then

                    Select Case CInt(e.CellValue)

                        Case AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.CurrentLiability, AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.NonCurrentLiability

                            e.Appearance.ForeColor = Drawing.Color.DarkRed

                        Case AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.CurrentAsset, AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.FixedAsset, _
                                AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.NonCurrentAsset

                            e.Appearance.ForeColor = Drawing.Color.Blue

                        Case AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.Equity

                            e.Appearance.ForeColor = Drawing.Color.Green

                        Case AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.Income, AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.IncomeOther

                            e.Appearance.ForeColor = Drawing.Color.DarkGreen

                        Case AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseCOS, AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseOperating,
                                AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseOther, AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseTaxes

                            e.Appearance.ForeColor = Drawing.Color.Red

                        Case Else

                            e.Appearance.ForeColor = Drawing.Color.Black

                    End Select

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.ShowingEditorEvent

            DataGridView_GeneralLedgerAccounts_ShowingEditorEvent(DataGridViewForm_GeneralLedgerAccounts, sender, e, Session)

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_GeneralLedgerAccounts.QueryPopupNeedDatasourceEvent

            DataGridView_GeneralLedgerAccounts_QueryPopupNeedDatasourceEvent(FieldName, OverrideDefaultDatasource, Datasource, Me.Session)

        End Sub

#End Region

#End Region

    End Class

End Namespace