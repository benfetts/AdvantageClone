Namespace Maintenance.Media.Presentation

    Public Class OutOfHomeTypeSetupForm

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

                DataGridViewForm_OutOfHomeType.DataSource = AdvantageFramework.Database.Procedures.OutOfHomeType.Load(DbContext).ToList

            End Using

            DataGridViewForm_OutOfHomeType.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_OutOfHomeType.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_OutOfHomeType.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim OutOfHomeTypeSetupForm As Presentation.OutOfHomeTypeSetupForm = Nothing

            OutOfHomeTypeSetupForm = New Presentation.OutOfHomeTypeSetupForm()

            OutOfHomeTypeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub OutOfHomeTypeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_OutOfHomeType.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub OutOfHomeTypeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub OutOfHomeTypeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_OutOfHomeType.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim OutOfHomeTypes As Generic.List(Of AdvantageFramework.Database.Entities.OutOfHomeType) = Nothing

            If DataGridViewForm_OutOfHomeType.HasRows Then

                DataGridViewForm_OutOfHomeType.CurrentView.CloseEditorForUpdating()

                OutOfHomeTypes = DataGridViewForm_OutOfHomeType.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.OutOfHomeType)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each OutOfHomeType In OutOfHomeTypes

                            AdvantageFramework.Database.Procedures.OutOfHomeType.Update(DbContext, OutOfHomeType)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_OutOfHomeType.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim OutOfHomeType As AdvantageFramework.Database.Entities.OutOfHomeType = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_OutOfHomeType.HasASelectedRow Then

                DataGridViewForm_OutOfHomeType.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_OutOfHomeType.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    OutOfHomeType = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    OutOfHomeType = Nothing
                                End Try

                                If OutOfHomeType IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.OutOfHomeType.Delete(DbContext, OutOfHomeType) Then

                                        DataGridViewForm_OutOfHomeType.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_OutOfHomeType.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_OutOfHomeType.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_OutOfHomeType_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_OutOfHomeType.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_OutOfHomeType_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_OutOfHomeType.AddNewRowEvent

            'objects
            Dim OutOfHomeType As AdvantageFramework.Database.Entities.OutOfHomeType = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.OutOfHomeType Then

                Me.ShowWaitForm("Processing...")

                OutOfHomeType = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If OutOfHomeType.IsEntityBeingAdded() Then

                        OutOfHomeType.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.OutOfHomeType.Insert(DbContext, OutOfHomeType)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_OutOfHomeType_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_OutOfHomeType.CellValueChangingEvent

            'objects
            Dim OutOfHomeType As AdvantageFramework.Database.Entities.OutOfHomeType = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.OutOfHomeType.Properties.IsInactive.ToString Then

                Try

                    OutOfHomeType = DataGridViewForm_OutOfHomeType.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    OutOfHomeType = Nothing
                End Try

                If OutOfHomeType IsNot Nothing Then

                    Try

                        OutOfHomeType.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        OutOfHomeType.IsInactive = OutOfHomeType.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.OutOfHomeType.Update(DbContext, OutOfHomeType)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_OutOfHomeType_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_OutOfHomeType.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace