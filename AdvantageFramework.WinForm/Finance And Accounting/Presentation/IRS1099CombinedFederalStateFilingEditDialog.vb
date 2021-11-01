Namespace FinanceAndAccounting.Presentation

    Public Class IRS1099CombinedFederalStateFilingEditDialog

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

            Dim IRS1099FederalStateCodeList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode) = Nothing
            Dim States As Generic.List(Of AdvantageFramework.Database.Entities.State) = Nothing

            IRS1099FederalStateCodeList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                States = DbContext.States.ToList

                IRS1099FederalStateCodeList.AddRange(From Entity In AdvantageFramework.Database.Procedures.IRS1099FederalStateCode.Load(DbContext).ToList
                                                     Select New AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode(Entity, States))

            End Using

            DataGridViewForm_FederalStateCodes.DataSource = IRS1099FederalStateCodeList

            If DataGridViewForm_FederalStateCodes.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode.Properties.StateName.ToString) IsNot Nothing Then

                DataGridViewForm_FederalStateCodes.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode.Properties.StateName.ToString).OptionsColumn.AllowFocus = False

            End If

            DataGridViewForm_FederalStateCodes.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_FederalStateCodes.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_FederalStateCodes.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowFormDialog()

            'objects
            Dim IRS1099CombinedFederalStateFilingEditDialog As AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099CombinedFederalStateFilingEditDialog = Nothing

            IRS1099CombinedFederalStateFilingEditDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099CombinedFederalStateFilingEditDialog()

            IRS1099CombinedFederalStateFilingEditDialog.ShowDialog()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub IRS1099CombinedFederalStateFilingEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub IRS1099CombinedFederalStateFilingEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            EnableOrDisableActions()

        End Sub
        Private Sub IRS1099CombinedFederalStateFilingEditDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_FederalStateCodes.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("EditDialog", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim IRS1099FederalStateCodes As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode) = Nothing

            If DataGridViewForm_FederalStateCodes.HasRows Then

                DataGridViewForm_FederalStateCodes.CurrentView.CloseEditorForUpdating()

                IRS1099FederalStateCodes = DataGridViewForm_FederalStateCodes.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each IRS1099FederalStateCode In IRS1099FederalStateCodes

                            AdvantageFramework.Database.Procedures.IRS1099FederalStateCode.Update(DbContext, IRS1099FederalStateCode.IRS1099FederalStateCode, Nothing)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_FederalStateCodes.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim IRS1099FederalStateCode As AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_FederalStateCodes.HasASelectedRow Then

                DataGridViewForm_FederalStateCodes.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_FederalStateCodes.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    IRS1099FederalStateCode = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    IRS1099FederalStateCode = Nothing
                                End Try

                                If IRS1099FederalStateCode IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.IRS1099FederalStateCode.Delete(DbContext, IRS1099FederalStateCode.IRS1099FederalStateCode, Nothing) Then

                                        DataGridViewForm_FederalStateCodes.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.Cursor = Windows.Forms.Cursors.Default
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    If DataGridViewForm_FederalStateCodes.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_FederalStateCodes.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_FederalStateCodes_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_FederalStateCodes.AddNewRowEvent

            'objects
            Dim IRS1099FederalStateCode As AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode = Nothing

            If TypeOf RowObject Is AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode Then

                Me.Cursor = Windows.Forms.Cursors.WaitCursor

                IRS1099FederalStateCode = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    IRS1099FederalStateCode.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.IRS1099FederalStateCode.Insert(DbContext, IRS1099FederalStateCode.IRS1099FederalStateCode, Nothing)

                End Using

                Me.Cursor = Windows.Forms.Cursors.Default

            End If

        End Sub
        Private Sub DataGridViewForm_FederalStateCodes_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_FederalStateCodes.CellValueChangedEvent

            Dim State As AdvantageFramework.Database.Entities.State = Nothing

            If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode.Properties.StateCode.ToString Then

                If e.Value IsNot Nothing Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        State = DbContext.States.Where(Function(Entity) Entity.StateCode = CStr(e.Value)).SingleOrDefault

                        If State IsNot Nothing Then

                            DataGridViewForm_FederalStateCodes.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode.Properties.StateName.ToString, State.StateName)

                        End If

                    End Using

                Else

                    DataGridViewForm_FederalStateCodes.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode.Properties.StateName.ToString, Nothing)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_FederalStateCodes_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_FederalStateCodes.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_FederalStateCodes_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_FederalStateCodes.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode.Properties.StateCode.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = (From State In DbContext.States
                                  Where State.Country = "USA"
                                  Select State).ToList

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_FederalStateCodes_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_FederalStateCodes.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_FederalStateCodes_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_FederalStateCodes.ShowingEditorEvent

            If Not DataGridViewForm_FederalStateCodes.IsNewItemOrAutoFilterRow(DataGridViewForm_FederalStateCodes.CurrentView.FocusedRowHandle) AndAlso
                    DataGridViewForm_FederalStateCodes.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode.Properties.StateCode.ToString Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace