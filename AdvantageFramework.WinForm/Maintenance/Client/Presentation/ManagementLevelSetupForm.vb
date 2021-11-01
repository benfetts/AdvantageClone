Namespace Maintenance.Client.Presentation

    Public Class ManagementLevelSetupForm

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

                DataGridViewForm_ManagementLevel.DataSource = AdvantageFramework.Database.Procedures.ManagementLevel.Load(DbContext).ToList

            End Using

            DataGridViewForm_ManagementLevel.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_ManagementLevel.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_ManagementLevel.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ManagementLevelSetupForm As Presentation.ManagementLevelSetupForm = Nothing

            ManagementLevelSetupForm = New Presentation.ManagementLevelSetupForm()

            ManagementLevelSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ManagementLevelSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_ManagementLevel.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub ManagementLevelSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ManagementLevelSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_ManagementLevel.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ManagementLevels As Generic.List(Of AdvantageFramework.Database.Entities.ManagementLevel) = Nothing

            If DataGridViewForm_ManagementLevel.HasRows Then

                DataGridViewForm_ManagementLevel.CurrentView.CloseEditorForUpdating()

                ManagementLevels = DataGridViewForm_ManagementLevel.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ManagementLevel)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ManagementLevel In ManagementLevels

                            AdvantageFramework.Database.Procedures.ManagementLevel.Update(DbContext, ManagementLevel)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_ManagementLevel.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ManagementLevel As AdvantageFramework.Database.Entities.ManagementLevel = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_ManagementLevel.HasASelectedRow Then

                DataGridViewForm_ManagementLevel.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_ManagementLevel.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    ManagementLevel = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    ManagementLevel = Nothing
                                End Try

                                If ManagementLevel IsNot Nothing Then

                                    If ManagementLevel.ID = 1 Then

                                        AdvantageFramework.WinForm.MessageBox.Show("Management Level '" & ManagementLevel.Description & "' is a default level and cannot be deleted.")

                                    ElseIf AdvantageFramework.Database.Procedures.AccountExecutive.Load(DbContext).Where(Function(AE) AE.ManagementLevelID = ManagementLevel.ID).Any Then

                                        AdvantageFramework.WinForm.MessageBox.Show("Management Level '" & ManagementLevel.Description & "' is in use cannot be deleted.")

                                    Else

                                        If AdvantageFramework.Database.Procedures.ManagementLevel.Delete(DbContext, ManagementLevel) Then

                                            DataGridViewForm_ManagementLevel.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                        End If

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_ManagementLevel.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_ManagementLevel.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ManagementLevel_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ManagementLevel.CellValueChangingEvent

            Dim ManagementLevel As AdvantageFramework.Database.Entities.ManagementLevel = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.ManagementLevel.Properties.IsInactive.ToString Then

                Try

                    ManagementLevel = DataGridViewForm_ManagementLevel.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ManagementLevel = Nothing
                End Try

                If ManagementLevel IsNot Nothing Then

                    Try

                        ManagementLevel.IsInactive = e.Value

                    Catch ex As Exception
                        ManagementLevel.IsInactive = ManagementLevel.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.ManagementLevel.Update(DbContext, ManagementLevel)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ManagementLevel_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_ManagementLevel.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ManagementLevel_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_ManagementLevel.AddNewRowEvent

            'objects
            Dim ManagementLevel As AdvantageFramework.Database.Entities.ManagementLevel = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ManagementLevel Then

                Me.ShowWaitForm("Processing...")

                ManagementLevel = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ManagementLevel.IsEntityBeingAdded() Then

                        ManagementLevel.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.ManagementLevel.Insert(DbContext, ManagementLevel)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_ManagementLevel_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_ManagementLevel.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ManagementLevel_ShowingEditorEvent(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_ManagementLevel.ShowingEditorEvent

            If DataGridViewForm_ManagementLevel.CurrentView.GetRowCellValue(DataGridViewForm_ManagementLevel.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ManagementLevel.Properties.ID.ToString) = 1 Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace