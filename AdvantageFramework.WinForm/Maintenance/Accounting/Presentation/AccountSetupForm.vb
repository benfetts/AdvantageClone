Namespace Maintenance.Accounting.Presentation

    Public Class AccountSetupForm

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

                DataGridViewForm_Account.DataSource = AdvantageFramework.Database.Procedures.Account.Load(DbContext).ToList

            End Using

            DataGridViewForm_Account.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_Account.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_Account.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AccountSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.AccountSetupForm = Nothing

            AccountSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.AccountSetupForm()

            AccountSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_Account.CurrentView.AFActiveFilterString = "[IsInactive] = 1"

        End Sub
        Private Sub AccountSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub AccountSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_Account.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim Accounts As Generic.List(Of AdvantageFramework.Database.Entities.Account) = Nothing

            If DataGridViewForm_Account.HasRows Then

                DataGridViewForm_Account.CurrentView.CloseEditorForUpdating()

                Accounts = DataGridViewForm_Account.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Account)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each Account In Accounts

                            AdvantageFramework.Database.Procedures.Account.Update(DbContext, Account)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_Account.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Account As AdvantageFramework.Database.Entities.Account = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_Account.HasASelectedRow Then

                DataGridViewForm_Account.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_Account.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    Account = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    Account = Nothing
                                End Try

                                If Account IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.Account.Delete(DbContext, Account) Then

                                        DataGridViewForm_Account.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_Account.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Account.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Account_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Account.InitNewRowEvent

            If TypeOf DataGridViewForm_Account.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.Account Then

                DirectCast(DataGridViewForm_Account.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.Account).IsInactive = 1

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Account_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_Account.AddNewRowEvent

            'objects
            Dim Account As AdvantageFramework.Database.Entities.Account = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.Account Then

                Me.ShowWaitForm("Processing...")

                Account = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Account.IsEntityBeingAdded() Then

                        Account.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.Account.Insert(DbContext, Account)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Account_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Account.CellValueChangingEvent

            'objects
            Dim Account As AdvantageFramework.Database.Entities.Account = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.Account.Properties.IsInactive.ToString Then

                Try

                    Account = DataGridViewForm_Account.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    Account = Nothing
                End Try

                If Account IsNot Nothing Then

                    Try

                        Account.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        Account.IsInactive = Account.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.Account.Update(DbContext, Account)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Account_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Account.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace