Namespace Maintenance.Accounting.Presentation

    Public Class CopyOfficeSalesClassGLAccountsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CopyToOfficeCode As String = Nothing
        Private _CopyToSalesClassCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal CopyToOfficeCode As String, ByVal CopyToSalesClassCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _CopyToOfficeCode = CopyToOfficeCode
            _CopyToSalesClassCode = CopyToSalesClassCode

        End Sub
        Private Sub EnableOrDisableActions()

            If SearchableComboBoxGLSalesClassAccounts_ProductionSales.GetSelectedValue IsNot Nothing OrElse SearchableComboBoxGLSalesClassAccounts_ProductionCOS.GetSelectedValue IsNot Nothing Then

                SearchableComboBoxGLSalesClassAccounts_ProductionSales.SetRequired(True)
                SearchableComboBoxGLSalesClassAccounts_ProductionCOS.SetRequired(True)

            Else

                SearchableComboBoxGLSalesClassAccounts_ProductionSales.SetRequired(False)
                SearchableComboBoxGLSalesClassAccounts_ProductionCOS.SetRequired(False)

            End If

            If SearchableComboBoxGLSalesClassAccounts_MediaSales.GetSelectedValue IsNot Nothing OrElse SearchableComboBoxGLSalesClassAccounts_MediaCOS.GetSelectedValue IsNot Nothing Then

                SearchableComboBoxGLSalesClassAccounts_MediaSales.SetRequired(True)
                SearchableComboBoxGLSalesClassAccounts_MediaCOS.SetRequired(True)

            Else

                SearchableComboBoxGLSalesClassAccounts_MediaSales.SetRequired(False)
                SearchableComboBoxGLSalesClassAccounts_MediaCOS.SetRequired(False)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal CopyToOfficeCode As String, ByVal CopyToSalesClassCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim CopyOfficeSalesClassGLAccountsDialog As AdvantageFramework.Maintenance.Accounting.Presentation.CopyOfficeSalesClassGLAccountsDialog = Nothing

            CopyOfficeSalesClassGLAccountsDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.CopyOfficeSalesClassGLAccountsDialog(CopyToOfficeCode, CopyToSalesClassCode)

            ShowFormDialog = CopyOfficeSalesClassGLAccountsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CopyOfficeSalesClassGLAccountsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            ComboBoxForm_Office.SetRequired(True)
            ComboBoxForm_SalesClass.SetRequired(True)

            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.UseEmbeddedNavigator = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_Office.DataSource = AdvantageFramework.Database.Procedures.Office.Load(DbContext)

                GeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).ToList

                SearchableComboBoxGLSalesClassAccounts_MediaCOS.DataSource = GeneralLedgerAccounts
                SearchableComboBoxGLSalesClassAccounts_MediaSales.DataSource = GeneralLedgerAccounts
                SearchableComboBoxGLSalesClassAccounts_ProductionCOS.DataSource = GeneralLedgerAccounts
                SearchableComboBoxGLSalesClassAccounts_ProductionSales.DataSource = GeneralLedgerAccounts

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_Office_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Office.SelectedValueChanged

            Dim SalesClassCodes As Generic.List(Of String) = Nothing

            If ComboBoxForm_Office.GetSelectedValue IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SalesClassCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT DISTINCT SC_CODE FROM dbo.OFF_SC_ACCTS WHERE OFFICE_CODE='{0}'", ComboBoxForm_Office.GetSelectedValue)).ToList

                    ComboBoxForm_SalesClass.DataSource = SalesClassCodes

                End Using

            End If

        End Sub
        Private Sub ComboBoxForm_SalesClass_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_SalesClass.SelectedValueChanged

            Dim OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount = Nothing
            Dim OfficeSalesClassFunctionAccountDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount) = Nothing

            OfficeSalesClassFunctionAccountDetailsList = New Generic.List(Of AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount)

            If ComboBoxForm_Office.GetSelectedValue IsNot Nothing AndAlso ComboBoxForm_SalesClass.GetSelectedValue IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    OfficeSalesClassAccount = AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.LoadBySalesClassCodeOfficeCode(DbContext, ComboBoxForm_SalesClass.GetSelectedValue, ComboBoxForm_Office.GetSelectedValue)

                    If OfficeSalesClassAccount IsNot Nothing Then

                        SearchableComboBoxGLSalesClassAccounts_MediaCOS.SelectedValue = OfficeSalesClassAccount.MediaCostOfSalesGLACode

                        SearchableComboBoxGLSalesClassAccounts_MediaSales.SelectedValue = OfficeSalesClassAccount.MediaSalesGLACode

                        SearchableComboBoxGLSalesClassAccounts_ProductionCOS.SelectedValue = OfficeSalesClassAccount.ProductionCostOfSalesGLACode

                        SearchableComboBoxGLSalesClassAccounts_ProductionSales.SelectedValue = OfficeSalesClassAccount.ProductionSalesGLACode

                        OfficeSalesClassFunctionAccountDetailsList.AddRange(From OfficeSalesClassFunctionAccount In AdvantageFramework.Database.Procedures.OfficeSalesClassFunctionAccount.LoadBySalesClassCodeOfficeCode(DbContext, ComboBoxForm_SalesClass.GetSelectedValue, ComboBoxForm_Office.GetSelectedValue).ToList
                                                                            Select OfficeSalesClassFunctionAccount)

                    Else

                        SearchableComboBoxGLSalesClassAccounts_MediaCOS.SelectedValue = Nothing

                        SearchableComboBoxGLSalesClassAccounts_MediaSales.SelectedValue = Nothing

                        SearchableComboBoxGLSalesClassAccounts_ProductionCOS.SelectedValue = Nothing

                        SearchableComboBoxGLSalesClassAccounts_ProductionSales.SelectedValue = Nothing

                    End If

                End Using

            End If

            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.DataSource = OfficeSalesClassFunctionAccountDetailsList

            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.BestFitColumns()

        End Sub
        Private Sub ButtonForm_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Copy.Click

            Dim OfficeSalesClassAccountCopyFrom As AdvantageFramework.Database.Entities.OfficeSalesClassAccount = Nothing
            Dim OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount = Nothing
            Dim OfficeSalesClassFunctionAccountsList As Generic.List(Of AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount) = Nothing
            Dim OfficeSalesClassFunctionAccountNew As AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim ErrorMessage As String = Nothing
            Dim UpdateExistingOfficeSalesClassAccount As Boolean = True
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing

            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.CloseEditorForUpdating()

            If Me.Validator Then

                If DataGridViewGLSalesClassFunctionAccounts_GLSCFA.HasRows OrElse
                        SearchableComboBoxGLSalesClassAccounts_MediaCOS.GetSelectedValue IsNot Nothing OrElse
                        SearchableComboBoxGLSalesClassAccounts_MediaSales.GetSelectedValue IsNot Nothing OrElse
                        SearchableComboBoxGLSalesClassAccounts_ProductionCOS.GetSelectedValue IsNot Nothing OrElse
                        SearchableComboBoxGLSalesClassAccounts_ProductionSales.GetSelectedValue IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        OfficeSalesClassAccountCopyFrom = AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.LoadBySalesClassCodeOfficeCode(DbContext, ComboBoxForm_SalesClass.GetSelectedValue, ComboBoxForm_Office.GetSelectedValue)

                        OfficeSalesClassAccount = AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.LoadBySalesClassCodeOfficeCode(DbContext, _CopyToSalesClassCode, _CopyToOfficeCode)

                        If OfficeSalesClassAccountCopyFrom IsNot Nothing Then

                            If OfficeSalesClassAccount Is Nothing Then

                                OfficeSalesClassAccount = New AdvantageFramework.Database.Entities.OfficeSalesClassAccount
                                OfficeSalesClassAccount.OfficeCode = _CopyToOfficeCode
                                OfficeSalesClassAccount.SalesClassCode = _CopyToSalesClassCode
                                UpdateExistingOfficeSalesClassAccount = False

                            End If

                            OfficeSalesClassAccount.MediaSalesGLACode = SearchableComboBoxGLSalesClassAccounts_MediaSales.GetSelectedValue
                            OfficeSalesClassAccount.MediaCostOfSalesGLACode = SearchableComboBoxGLSalesClassAccounts_MediaCOS.GetSelectedValue
                            OfficeSalesClassAccount.ProductionSalesGLACode = SearchableComboBoxGLSalesClassAccounts_ProductionSales.GetSelectedValue
                            OfficeSalesClassAccount.ProductionCostOfSalesGLACode = SearchableComboBoxGLSalesClassAccounts_ProductionCOS.GetSelectedValue

                            If CheckBoxForm_ReplaceOfficeSegment.Checked Then

                                GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, _CopyToOfficeCode)

                                If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                    GeneralLedger.ReplaceOfficeSegment(DbContext, OfficeSalesClassAccount.MediaSalesGLACode, GeneralLedgerOfficeCrossReference.Code)
                                    GeneralLedger.ReplaceOfficeSegment(DbContext, OfficeSalesClassAccount.MediaCostOfSalesGLACode, GeneralLedgerOfficeCrossReference.Code)
                                    GeneralLedger.ReplaceOfficeSegment(DbContext, OfficeSalesClassAccount.ProductionSalesGLACode, GeneralLedgerOfficeCrossReference.Code)
                                    GeneralLedger.ReplaceOfficeSegment(DbContext, OfficeSalesClassAccount.ProductionCostOfSalesGLACode, GeneralLedgerOfficeCrossReference.Code)

                                End If

                            End If

                            Try

                                DbContext.Database.Connection.Open()

                                DbTransaction = DbContext.Database.BeginTransaction

                                If UpdateExistingOfficeSalesClassAccount Then

                                    If AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.Update(DbContext, OfficeSalesClassAccount) = False Then

                                        Throw New Exception("Failed to update Office Sales Class Account")

                                    End If

                                ElseIf AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.Insert(DbContext, OfficeSalesClassAccount) = False Then

                                    Throw New Exception("Failed to insert Office Sales Class Account")

                                End If

                                If DataGridViewGLSalesClassFunctionAccounts_GLSCFA.HasRows Then

                                    OfficeSalesClassFunctionAccountsList = DataGridViewGLSalesClassFunctionAccounts_GLSCFA.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount)().ToList

                                    For Each OfficeSalesClassFunctionAccount In OfficeSalesClassFunctionAccountsList

                                        OfficeSalesClassFunctionAccountNew = New AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount

                                        OfficeSalesClassFunctionAccountNew.DbContext = DbContext

                                        OfficeSalesClassFunctionAccountNew.OfficeCode = _CopyToOfficeCode
                                        OfficeSalesClassFunctionAccountNew.SalesClassCode = _CopyToSalesClassCode
                                        OfficeSalesClassFunctionAccountNew.FunctionCode = OfficeSalesClassFunctionAccount.FunctionCode
                                        OfficeSalesClassFunctionAccountNew.ProductionSalesGLACode = OfficeSalesClassFunctionAccount.ProductionSalesGLACode
                                        OfficeSalesClassFunctionAccountNew.ProductionCostOfSalesGLACode = OfficeSalesClassFunctionAccount.ProductionCostOfSalesGLACode

                                        If CheckBoxForm_ReplaceOfficeSegment.Checked AndAlso GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                            GeneralLedger.ReplaceOfficeSegment(DbContext, OfficeSalesClassFunctionAccountNew.ProductionSalesGLACode, GeneralLedgerOfficeCrossReference.Code)
                                            GeneralLedger.ReplaceOfficeSegment(DbContext, OfficeSalesClassFunctionAccountNew.ProductionCostOfSalesGLACode, GeneralLedgerOfficeCrossReference.Code)

                                        End If

                                        DbContext.OfficeSalesClassFunctionAccounts.Add(OfficeSalesClassFunctionAccountNew)

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

                        End If

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
        Private Sub SearchableComboBoxGLSalesClassAccounts_MediaCOS_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxGLSalesClassAccounts_MediaCOS.EditValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxGLSalesClassAccounts_MediaSales_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxGLSalesClassAccounts_MediaSales.EditValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxGLSalesClassAccounts_ProductionCOS_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxGLSalesClassAccounts_ProductionCOS.EditValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxGLSalesClassAccounts_ProductionSales_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxGLSalesClassAccounts_ProductionSales.EditValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewGLSalesClassFunctionAccounts_GLSCFA_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CellValueChangedEvent

            If TypeOf DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount.Properties.FunctionCode.ToString Then

                    For Each OfficeSalesClassFunctionAccountDetail In DataGridViewGLSalesClassFunctionAccounts_GLSCFA.GetAllRowsDataBoundItems()

                        If OfficeSalesClassFunctionAccountDetail.FunctionCode.ToString.ToUpper = e.Value.ToString.ToUpper Then

                            AdvantageFramework.WinForm.MessageBox.Show("Duplicate function code.")

                            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.SetRowCellValue(e.RowHandle, DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.Columns(AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount.Properties.FunctionCode.ToString), "")

                        End If

                    Next

                End If

            End If

        End Sub
        Private Sub DataGridViewGLSalesClassFunctionAccounts_GLSCFA_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewGLSalesClassFunctionAccounts_GLSCFA.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.DeleteSelectedRows()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewGLSalesClassFunctionAccounts_GLSCFA_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewGLSalesClassFunctionAccounts_GLSCFA.InitNewRowEvent

            If TypeOf DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount Then

                DirectCast(DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount).OfficeCode = _CopyToOfficeCode
                DirectCast(DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount).SalesClassCode = _CopyToSalesClassCode

            End If

        End Sub
        Private Sub DataGridViewGLSalesClassFunctionAccounts_GLSCFA_ValidatingEditorEvent(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ValidatingEditorEvent

            If DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount.Properties.ProductionSalesGLACode.ToString OrElse
                    DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount.Properties.ProductionCostOfSalesGLACode.ToString OrElse
                    DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount.Properties.FunctionCode.ToString Then

                If e.Value Is Nothing Then

                    e.Valid = False

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace