Namespace Maintenance.Accounting.Presentation

    Public Class CopyOfficeFunctionGLAccountsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CopyToOfficeCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal CopyToOfficeCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _CopyToOfficeCode = CopyToOfficeCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal CopyToOfficeCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim CopyOfficeFunctionGLAccountsDialog As AdvantageFramework.Maintenance.Accounting.Presentation.CopyOfficeFunctionGLAccountsDialog = Nothing

            CopyOfficeFunctionGLAccountsDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.CopyOfficeFunctionGLAccountsDialog(CopyToOfficeCode)

            ShowFormDialog = CopyOfficeFunctionGLAccountsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CopyOfficeFunctionGLAccountsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            ComboBoxForm_Office.SetRequired(True)

            DataGridViewFunctionGLAccounts_GLAccounts.UseEmbeddedNavigator = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_Office.DataSource = AdvantageFramework.Database.Procedures.Office.Load(DbContext)

                GeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).ToList

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_Office_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Office.SelectedValueChanged

            If ComboBoxForm_Office.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewFunctionGLAccounts_GLAccounts.DataSource = AdvantageFramework.Database.Procedures.OfficeFunctionAccount.LoadByOfficeCode(DbContext, ComboBoxForm_Office.GetSelectedValue).ToList

                    DataGridViewFunctionGLAccounts_GLAccounts.CurrentView.BestFitColumns()

                End Using

            End If

        End Sub
        Private Sub ButtonForm_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Copy.Click

            Dim OfficeFunctionAccountList As Generic.List(Of AdvantageFramework.Database.Entities.OfficeFunctionAccount) = Nothing
            Dim OfficeFunctionAccountNew As AdvantageFramework.Database.Entities.OfficeFunctionAccount = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim ErrorMessage As String = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing

            DataGridViewFunctionGLAccounts_GLAccounts.CurrentView.CloseEditorForUpdating()

            If Me.Validator Then

                If DataGridViewFunctionGLAccounts_GLAccounts.HasRows Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            If DataGridViewFunctionGLAccounts_GLAccounts.HasRows Then

                                OfficeFunctionAccountList = DataGridViewFunctionGLAccounts_GLAccounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.OfficeFunctionAccount)().ToList

                                For Each OfficeFunctionAccount In OfficeFunctionAccountList

                                    If (From OFA In AdvantageFramework.Database.Procedures.OfficeFunctionAccount.LoadByOfficeCode(DbContext, _CopyToOfficeCode)
                                        Where OFA.FunctionCode = OfficeFunctionAccount.FunctionCode).Any = False Then

                                        OfficeFunctionAccountNew = New AdvantageFramework.Database.Entities.OfficeFunctionAccount

                                        OfficeFunctionAccountNew.DbContext = DbContext

                                        OfficeFunctionAccountNew.OfficeCode = _CopyToOfficeCode
                                        OfficeFunctionAccountNew.FunctionCode = OfficeFunctionAccount.FunctionCode
                                        OfficeFunctionAccountNew.ProductionSalesGLACode = OfficeFunctionAccount.ProductionSalesGLACode
                                        OfficeFunctionAccountNew.ProductionCostOfSalesGLACode = OfficeFunctionAccount.ProductionCostOfSalesGLACode

                                        If CheckBoxForm_ReplaceOfficeSegment.Checked Then

                                            GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, _CopyToOfficeCode)

                                            If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                                GeneralLedger.ReplaceOfficeSegment(DbContext, OfficeFunctionAccountNew.ProductionSalesGLACode, GeneralLedgerOfficeCrossReference.Code)
                                                GeneralLedger.ReplaceOfficeSegment(DbContext, OfficeFunctionAccountNew.ProductionCostOfSalesGLACode, GeneralLedgerOfficeCrossReference.Code)

                                            End If

                                        End If

                                        DbContext.OfficeFunctionAccounts.Add(OfficeFunctionAccountNew)

                                    End If

                                Next

                                DbContext.SaveChanges()

                            End If

                            DbTransaction.Commit()

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    End Using

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Nothing to create.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

            End If

            If ErrorMessage <> "" Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        End Sub
        Private Sub DataGridViewFunctionGLAccounts_GLAccounts_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewFunctionGLAccounts_GLAccounts.CellValueChangedEvent

            If TypeOf DataGridViewFunctionGLAccounts_GLAccounts.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.OfficeFunctionAccount Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.OfficeFunctionAccount.Properties.FunctionCode.ToString Then

                    For Each OfficeFunctionAccount In DataGridViewFunctionGLAccounts_GLAccounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.OfficeFunctionAccount).ToList

                        If OfficeFunctionAccount.FunctionCode.ToUpper = e.Value.ToString.ToUpper Then

                            AdvantageFramework.WinForm.MessageBox.Show("Duplicate function code.")

                            DataGridViewFunctionGLAccounts_GLAccounts.CurrentView.SetRowCellValue(e.RowHandle, DataGridViewFunctionGLAccounts_GLAccounts.CurrentView.Columns(AdvantageFramework.Database.Entities.OfficeFunctionAccount.Properties.FunctionCode.ToString), "")

                        End If

                    Next

                End If

            End If

        End Sub
        Private Sub DataGridViewFunctionGLAccounts_GLAccounts_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewFunctionGLAccounts_GLAccounts.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewFunctionGLAccounts_GLAccounts.CancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DataGridViewFunctionGLAccounts_GLAccounts.CurrentView.DeleteSelectedRows()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewFunctionGLAccounts_GLAccounts_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewFunctionGLAccounts_GLAccounts.InitNewRowEvent

            If TypeOf DataGridViewFunctionGLAccounts_GLAccounts.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.OfficeFunctionAccount Then

                DirectCast(DataGridViewFunctionGLAccounts_GLAccounts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.OfficeFunctionAccount).OfficeCode = _CopyToOfficeCode

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace