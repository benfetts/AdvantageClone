Namespace Maintenance.Accounting.Presentation

    Public Class IndirectCategorySetupForm

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

                DataGridViewForm_IndirectCategory.DataSource = AdvantageFramework.Database.Procedures.IndirectCategory.Load(DbContext).ToList

            End Using

            DataGridViewForm_IndirectCategory.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_IndirectCategory.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_IndirectCategory.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim IndirectCategorySetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.IndirectCategorySetupForm = Nothing

            IndirectCategorySetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.IndirectCategorySetupForm()

            IndirectCategorySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub IndirectCategorySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_IndirectCategory.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub IndirectCategorySetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub IndirectCategorySetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_IndirectCategory.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim IndirectCategorys As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory) = Nothing

            If DataGridViewForm_IndirectCategory.HasRows Then

                DataGridViewForm_IndirectCategory.CurrentView.CloseEditorForUpdating()

                IndirectCategorys = DataGridViewForm_IndirectCategory.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.IndirectCategory)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each IndirectCategory In IndirectCategorys

                            AdvantageFramework.Database.Procedures.IndirectCategory.Update(DbContext, IndirectCategory)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_IndirectCategory.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_IndirectCategory.HasASelectedRow Then

                DataGridViewForm_IndirectCategory.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_IndirectCategory.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    IndirectCategory = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    IndirectCategory = Nothing
                                End Try

                                If IndirectCategory IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.IndirectCategory.Delete(DbContext, IndirectCategory) Then

                                        DataGridViewForm_IndirectCategory.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_IndirectCategory.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_IndirectCategory.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_IndirectCategory_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_IndirectCategory.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_IndirectCategory_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_IndirectCategory.AddNewRowEvent

            'objects
            Dim IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.IndirectCategory Then

                Me.ShowWaitForm("Processing...")

                IndirectCategory = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If IndirectCategory.IsEntityBeingAdded() Then

                        IndirectCategory.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.IndirectCategory.Insert(DbContext, IndirectCategory)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_IndirectCategory_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_IndirectCategory.CellValueChangingEvent

            'objects
            Dim IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.IndirectCategory.Properties.IsInactive.ToString Then

                Try

                    IndirectCategory = DataGridViewForm_IndirectCategory.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    IndirectCategory = Nothing
                End Try

                If IndirectCategory IsNot Nothing Then

                    Try

                        IndirectCategory.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        IndirectCategory.IsInactive = IndirectCategory.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.IndirectCategory.Update(DbContext, IndirectCategory)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_IndirectCategory_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_IndirectCategory.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace