Namespace Maintenance.ProjectManagement.Presentation

    Public Class PrintSpecStatusSetupForm

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

                DataGridViewForm_PrintSpecStatus.DataSource = AdvantageFramework.Database.Procedures.PrintSpecStatus.Load(DbContext).ToList

            End Using

            DataGridViewForm_PrintSpecStatus.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_PrintSpecStatus.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_PrintSpecStatus.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim PrintSpecStatusSetupForm As Presentation.PrintSpecStatusSetupForm = Nothing

            PrintSpecStatusSetupForm = New Presentation.PrintSpecStatusSetupForm()

            PrintSpecStatusSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub PrintSpecStatusSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_PrintSpecStatus.CurrentView.AFActiveFilterString = "[IsActive] = 1"

            If DataGridViewForm_PrintSpecStatus.Columns("IsActive") IsNot Nothing Then

                DataGridViewForm_PrintSpecStatus.Columns("IsActive").Caption = "Is Inactive"

            End If

        End Sub
        Private Sub PrintSpecStatusSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PrintSpecStatusSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_PrintSpecStatus.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim PrintSpecStatuss As Generic.List(Of AdvantageFramework.Database.Entities.PrintSpecStatus) = Nothing

            If DataGridViewForm_PrintSpecStatus.HasRows Then

                DataGridViewForm_PrintSpecStatus.CurrentView.CloseEditorForUpdating()

                PrintSpecStatuss = DataGridViewForm_PrintSpecStatus.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.PrintSpecStatus)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each PrintSpecStatus In PrintSpecStatuss

                            AdvantageFramework.Database.Procedures.PrintSpecStatus.Update(DbContext, PrintSpecStatus)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_PrintSpecStatus.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim PrintSpecStatus As AdvantageFramework.Database.Entities.PrintSpecStatus = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_PrintSpecStatus.HasASelectedRow Then

                DataGridViewForm_PrintSpecStatus.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_PrintSpecStatus.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    PrintSpecStatus = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    PrintSpecStatus = Nothing
                                End Try

                                If PrintSpecStatus IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.PrintSpecStatus.Delete(DbContext, PrintSpecStatus) Then

                                        DataGridViewForm_PrintSpecStatus.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_PrintSpecStatus.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_PrintSpecStatus.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_PrintSpecStatus_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_PrintSpecStatus.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_PrintSpecStatus_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_PrintSpecStatus.AddNewRowEvent

            'objects
            Dim PrintSpecStatus As AdvantageFramework.Database.Entities.PrintSpecStatus = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.PrintSpecStatus Then

                Me.ShowWaitForm("Processing...")

                PrintSpecStatus = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If PrintSpecStatus.IsEntityBeingAdded() Then

                        PrintSpecStatus.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.PrintSpecStatus.Insert(DbContext, PrintSpecStatus)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_PrintSpecStatus_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_PrintSpecStatus.CellValueChangingEvent

            'objects
            Dim PrintSpecStatus As AdvantageFramework.Database.Entities.PrintSpecStatus = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.PrintSpecStatus.Properties.IsActive.ToString Then

                Try

                    PrintSpecStatus = DataGridViewForm_PrintSpecStatus.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    PrintSpecStatus = Nothing
                End Try

                If PrintSpecStatus IsNot Nothing Then

                    Try

                        PrintSpecStatus.IsActive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        PrintSpecStatus.IsActive = PrintSpecStatus.IsActive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.PrintSpecStatus.Update(DbContext, PrintSpecStatus)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_PrintSpecStatus_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_PrintSpecStatus.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace