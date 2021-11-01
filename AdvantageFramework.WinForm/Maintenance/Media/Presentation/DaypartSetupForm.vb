Namespace Maintenance.Media.Presentation

    Public Class DaypartSetupForm

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

                DataGridViewForm_Daypart.DataSource = AdvantageFramework.Database.Procedures.Daypart.Load(DbContext).ToList

            End Using

            DataGridViewForm_Daypart.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_Daypart.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_Daypart.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim DaypartSetupForm As Presentation.DaypartSetupForm = Nothing

            DaypartSetupForm = New Presentation.DaypartSetupForm()

            DaypartSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DaypartSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_Daypart.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub DaypartSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DaypartSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_Daypart.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim Dayparts As Generic.List(Of AdvantageFramework.Database.Entities.Daypart) = Nothing

            If DataGridViewForm_Daypart.HasRows Then

                DataGridViewForm_Daypart.CurrentView.CloseEditorForUpdating()

                Dayparts = DataGridViewForm_Daypart.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Daypart)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each Daypart In Dayparts

                            AdvantageFramework.Database.Procedures.Daypart.Update(DbContext, Daypart)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_Daypart.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_Daypart.HasASelectedRow Then

                DataGridViewForm_Daypart.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_Daypart.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    Daypart = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    Daypart = Nothing
                                End Try

                                If Daypart IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.Daypart.Delete(DbContext, Daypart) Then

                                        DataGridViewForm_Daypart.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_Daypart.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Daypart.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Daypart_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Daypart.InitNewRowEvent

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DirectCast(DataGridViewForm_Daypart.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.Daypart).DaypartTypeID = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.DaypartType).FirstOrDefault.ID

                End Using

            Catch ex As Exception

            End Try

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Daypart_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_Daypart.AddNewRowEvent

            'objects
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.Daypart Then

                Me.ShowWaitForm("Processing...")

                Daypart = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Daypart.IsEntityBeingAdded() Then

                        Daypart.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.Daypart.Insert(DbContext, Daypart)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Daypart_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Daypart.CellValueChangingEvent

            'objects
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.Daypart.Properties.IsInactive.ToString Then

                Try

                    Daypart = DataGridViewForm_Daypart.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    Daypart = Nothing
                End Try

                If Daypart IsNot Nothing Then

                    Try

                        Daypart.IsInactive = e.Value

                    Catch ex As Exception
                        Daypart.IsInactive = Daypart.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.Daypart.Update(DbContext, Daypart)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Daypart_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_Daypart.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace