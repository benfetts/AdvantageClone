Namespace Maintenance.Accounting.Presentation

    Public Class FiscalPeriodSetupForm

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

                DataGridViewForm_FiscalPeriod.DataSource = AdvantageFramework.Database.Procedures.FiscalPeriod.Load(DbContext).ToList

            End Using

            DataGridViewForm_FiscalPeriod.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_FiscalPeriod.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_FiscalPeriod.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim FiscalPeriodSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.FiscalPeriodSetupForm = Nothing

            FiscalPeriodSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.FiscalPeriodSetupForm()

            FiscalPeriodSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub FiscalPeriodSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_FiscalPeriod.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

            If DataGridViewForm_FiscalPeriod.CurrentView.Columns("Code") IsNot Nothing Then

                DataGridViewForm_FiscalPeriod.CurrentView.Columns("Code").Caption = "Fiscal Period"

            End If

        End Sub
        Private Sub FiscalPeriodSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub FiscalPeriodSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_FiscalPeriod.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim FiscalPeriods As Generic.List(Of AdvantageFramework.Database.Entities.FiscalPeriod) = Nothing

            If DataGridViewForm_FiscalPeriod.HasRows Then

                DataGridViewForm_FiscalPeriod.CurrentView.CloseEditorForUpdating()

                FiscalPeriods = DataGridViewForm_FiscalPeriod.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.FiscalPeriod)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each FiscalPeriod In FiscalPeriods

                            AdvantageFramework.Database.Procedures.FiscalPeriod.Update(DbContext, FiscalPeriod)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_FiscalPeriod.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim FiscalPeriod As AdvantageFramework.Database.Entities.FiscalPeriod = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_FiscalPeriod.HasASelectedRow Then

                DataGridViewForm_FiscalPeriod.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_FiscalPeriod.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    FiscalPeriod = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    FiscalPeriod = Nothing
                                End Try

                                If FiscalPeriod IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.FiscalPeriod.Delete(DbContext, FiscalPeriod) Then

                                        DataGridViewForm_FiscalPeriod.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_FiscalPeriod.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_FiscalPeriod.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_FiscalPeriod_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_FiscalPeriod.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_FiscalPeriod_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_FiscalPeriod.AddNewRowEvent

            'objects
            Dim FiscalPeriod As AdvantageFramework.Database.Entities.FiscalPeriod = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.FiscalPeriod Then

                Me.ShowWaitForm("Processing...")

                FiscalPeriod = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If FiscalPeriod.IsEntityBeingAdded() Then

                        FiscalPeriod.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.FiscalPeriod.Insert(DbContext, FiscalPeriod)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_FiscalPeriod_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_FiscalPeriod.CellValueChangingEvent

            'objects
            Dim FiscalPeriod As AdvantageFramework.Database.Entities.FiscalPeriod = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.FiscalPeriod.Properties.IsInactive.ToString Then

                Try

                    FiscalPeriod = DataGridViewForm_FiscalPeriod.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    FiscalPeriod = Nothing
                End Try

                If FiscalPeriod IsNot Nothing Then

                    Try

                        FiscalPeriod.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        FiscalPeriod.IsInactive = FiscalPeriod.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.FiscalPeriod.Update(DbContext, FiscalPeriod)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_FiscalPeriod_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_FiscalPeriod.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace