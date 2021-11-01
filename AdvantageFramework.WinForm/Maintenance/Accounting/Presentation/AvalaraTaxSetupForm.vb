Namespace Maintenance.Accounting.Presentation

    Public Class AvalaraTaxSetupForm

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

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_AvalaraTax.DataSource = AdvantageFramework.Database.Procedures.AvalaraTax.Load(DataContext).ToList

            End Using

            DataGridViewForm_AvalaraTax.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_AvalaraTax.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_AvalaraTax.HasASelectedRow

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.ShowWaitForm("Saving...")
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.CloseWaitForm()
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim AvalaraTaxes As Generic.List(Of AdvantageFramework.Database.Entities.AvalaraTax) = Nothing
            Dim AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax = Nothing
            Dim Saved As Boolean = True

            DataGridViewForm_AvalaraTax.CurrentView.CloseEditorForUpdating()

            DataGridViewForm_AvalaraTax.ValidateAllRows()

            If DataGridViewForm_AvalaraTax.HasAnyInvalidRows Then

                AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows.")

            ElseIf DataGridViewForm_AvalaraTax.HasRows Then

                AvalaraTaxes = DataGridViewForm_AvalaraTax.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Entities.AvalaraTax)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each AT In AvalaraTaxes

                            AvalaraTax = AdvantageFramework.Database.Procedures.AvalaraTax.LoadByID(DataContext, AT.ID)

                            If AvalaraTax IsNot Nothing Then

                                AvalaraTax.Code = AT.Code
                                AvalaraTax.Description = AT.Description
                                AvalaraTax.LongDescription = AT.LongDescription
                                AvalaraTax.IsInactive = AT.IsInactive

                                If AdvantageFramework.Database.Procedures.AvalaraTax.Update(DataContext, AvalaraTax) = False Then

                                    Saved = False

                                End If

                            End If

                        Next

                    End Using

                Catch ex As Exception
                    Saved = False
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_AvalaraTax.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AvalaraTaxSetupForm As Presentation.AvalaraTaxSetupForm = Nothing

            AvalaraTaxSetupForm = New Presentation.AvalaraTaxSetupForm()

            AvalaraTaxSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AvalaraTaxSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            LoadGrid()

            DataGridViewForm_AvalaraTax.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub AvalaraTaxSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub AvalaraTaxSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_AvalaraTax.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Import.Click

            AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.AvalaraTaxCode)

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_AvalaraTax.HasASelectedRow Then

                DataGridViewForm_AvalaraTax.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_AvalaraTax.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    AvalaraTax = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    AvalaraTax = Nothing
                                End Try

                                If AvalaraTax IsNot Nothing Then

                                    DataContext.AvalaraTaxes.Attach(AvalaraTax)

                                    If AdvantageFramework.Database.Procedures.AvalaraTax.Delete(DataContext, AvalaraTax) Then

                                        DataGridViewForm_AvalaraTax.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The code is in use and cannot be deleted.")

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_AvalaraTax.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_AvalaraTax.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_AvalaraTax_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_AvalaraTax.CellValueChangingEvent

            Dim AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.AvalaraTax.Properties.IsInactive.ToString Then

                Try

                    AvalaraTax = DataGridViewForm_AvalaraTax.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    AvalaraTax = Nothing
                End Try

                If AvalaraTax IsNot Nothing Then

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            AvalaraTax = AdvantageFramework.Database.Procedures.AvalaraTax.LoadByID(DataContext, AvalaraTax.ID)

                            AvalaraTax.IsInactive = e.Value

                            Saved = AdvantageFramework.Database.Procedures.AvalaraTax.Update(DataContext, AvalaraTax)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_AvalaraTax_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_AvalaraTax.InitNewRowEvent

            DirectCast(DataGridViewForm_AvalaraTax.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.AvalaraTax).DatabaseAction = Database.Action.Inserting

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_AvalaraTax_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_AvalaraTax.AddNewRowEvent

            'objects
            Dim AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.AvalaraTax Then

                Me.ShowWaitForm("Processing...")

                AvalaraTax = RowObject

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AvalaraTax.DataContext = DataContext

                    AdvantageFramework.Database.Procedures.AvalaraTax.Insert(DataContext, AvalaraTax)

                    AvalaraTax.DatabaseAction = Database.Action.Updating

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_AvalaraTax_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_AvalaraTax.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace