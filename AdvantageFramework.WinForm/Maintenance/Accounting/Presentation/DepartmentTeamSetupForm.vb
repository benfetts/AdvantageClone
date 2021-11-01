Namespace Maintenance.Accounting.Presentation

    Public Class DepartmentTeamSetupForm

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

                DataGridViewForm_DepartmentTeam.DataSource = AdvantageFramework.Database.Procedures.DepartmentTeam.Load(DbContext).ToList

            End Using

            DataGridViewForm_DepartmentTeam.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_DepartmentTeam.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_DepartmentTeam.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim DepartmentTeamSetupForm As Presentation.DepartmentTeamSetupForm = Nothing

            DepartmentTeamSetupForm = New Presentation.DepartmentTeamSetupForm()

            DepartmentTeamSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DepartmentTeamSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_DepartmentTeam.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub DepartmentTeamSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DepartmentTeamSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_DepartmentTeam.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim DepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam) = Nothing

            If DataGridViewForm_DepartmentTeam.HasRows Then

                DataGridViewForm_DepartmentTeam.CurrentView.CloseEditorForUpdating()

                DepartmentTeams = DataGridViewForm_DepartmentTeam.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.DepartmentTeam)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each DepartmentTeam In DepartmentTeams

                            AdvantageFramework.Database.Procedures.DepartmentTeam.Update(DbContext, DepartmentTeam)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_DepartmentTeam.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_DepartmentTeam.HasASelectedRow Then

                DataGridViewForm_DepartmentTeam.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_DepartmentTeam.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    DepartmentTeam = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    DepartmentTeam = Nothing
                                End Try

                                If DepartmentTeam IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.DepartmentTeam.Delete(DbContext, DepartmentTeam) Then

                                        DataGridViewForm_DepartmentTeam.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_DepartmentTeam.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_DepartmentTeam.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_DepartmentTeam_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_DepartmentTeam.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_DepartmentTeam_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_DepartmentTeam.AddNewRowEvent

            'objects
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.DepartmentTeam Then

                Me.ShowWaitForm("Processing...")

                DepartmentTeam = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If DepartmentTeam.IsEntityBeingAdded() Then

                        DepartmentTeam.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.DepartmentTeam.Insert(DbContext, DepartmentTeam)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_DepartmentTeam_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_DepartmentTeam.CellValueChangingEvent

            'objects
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.DepartmentTeam.Properties.IsInactive.ToString Then

                Try

                    DepartmentTeam = DataGridViewForm_DepartmentTeam.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    DepartmentTeam = Nothing
                End Try

                If DepartmentTeam IsNot Nothing Then

                    Try

                        DepartmentTeam.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        DepartmentTeam.IsInactive = DepartmentTeam.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.DepartmentTeam.Update(DbContext, DepartmentTeam)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_DepartmentTeam_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_DepartmentTeam.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace