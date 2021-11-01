Namespace Maintenance.General.Presentation

    Public Class CycleSetupForm

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

                DataGridViewForm_Cycle.DataSource = AdvantageFramework.Database.Procedures.Cycle.Load(DbContext).ToList

            End Using

            DataGridViewForm_Cycle.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_Cycle.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_Cycle.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CycleSetupForm As Presentation.CycleSetupForm = Nothing

            CycleSetupForm = New Presentation.CycleSetupForm()

            CycleSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CycleSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            LoadGrid()

            DataGridViewForm_Cycle.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub CycleSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CycleSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_Cycle.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim Cycles As Generic.List(Of AdvantageFramework.Database.Entities.Cycle) = Nothing

            If DataGridViewForm_Cycle.HasRows Then

                DataGridViewForm_Cycle.CurrentView.CloseEditorForUpdating()

                Cycles = DataGridViewForm_Cycle.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Cycle)().ToList

                Me.ShowWaitForm("Processing...")

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each Cycle In Cycles

                        AdvantageFramework.Database.Procedures.Cycle.Update(DbContext, Cycle)

                    Next

                End Using

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Me.CloseWaitForm()

                DataGridViewForm_Cycle.ValidateAllRowsAndClearChanged(True)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Cycle As AdvantageFramework.Database.Entities.Cycle = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_Cycle.HasASelectedRow Then

                DataGridViewForm_Cycle.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_Cycle.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    Cycle = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    Cycle = Nothing
                                End Try

                                If Cycle IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.Cycle.Delete(DbContext, Cycle) Then

                                        DataGridViewForm_Cycle.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The cycle '" & Cycle.Code & "' is in use and cannot be deleted.")

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_Cycle.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Cycle.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Cycle_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Cycle.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Cycle_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_Cycle.AddNewRowEvent

            'objects
            Dim Cycle As AdvantageFramework.Database.Entities.Cycle = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.Cycle Then

                Me.ShowWaitForm("Processing...")

                Cycle = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Cycle.IsEntityBeingAdded() Then

                        Cycle.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.Cycle.Insert(DbContext, Cycle)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Cycle_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Cycle.CellValueChangingEvent

            'objects
            Dim Cycle As AdvantageFramework.Database.Entities.Cycle = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.Cycle.Properties.IsInactive.ToString Then

                Try

                    Cycle = DataGridViewForm_Cycle.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    Cycle = Nothing
                End Try

                If Cycle IsNot Nothing Then

                    Try

                        Cycle.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        Cycle.IsInactive = Cycle.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.Cycle.Update(DbContext, Cycle)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Cycle_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_Cycle.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace