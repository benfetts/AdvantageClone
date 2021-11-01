Namespace Maintenance.Accounting.Presentation

    Public Class EmployeeCategorySetupForm

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

                DataGridViewForm_EmployeeCategory.DataSource = AdvantageFramework.Database.Procedures.EmployeeCategory.Load(DbContext).ToList

            End Using

            DataGridViewForm_EmployeeCategory.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_EmployeeCategory.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_EmployeeCategory.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EmployeeCategorySetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeCategorySetupForm = Nothing

            EmployeeCategorySetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeCategorySetupForm()

            EmployeeCategorySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeCategorySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_EmployeeCategory.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub EmployeeCategorySetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeCategorySetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_EmployeeCategory.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim EmployeeCategorys As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeCategory) = Nothing

            If DataGridViewForm_EmployeeCategory.HasRows Then

                DataGridViewForm_EmployeeCategory.CurrentView.CloseEditorForUpdating()

                EmployeeCategorys = DataGridViewForm_EmployeeCategory.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.EmployeeCategory)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each EmployeeCategory In EmployeeCategorys

                            AdvantageFramework.Database.Procedures.EmployeeCategory.Update(DbContext, EmployeeCategory)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_EmployeeCategory.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim EmployeeCategory As AdvantageFramework.Database.Entities.EmployeeCategory = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_EmployeeCategory.HasASelectedRow Then

                DataGridViewForm_EmployeeCategory.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_EmployeeCategory.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    EmployeeCategory = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    EmployeeCategory = Nothing
                                End Try

                                If EmployeeCategory IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.EmployeeCategory.Delete(DbContext, EmployeeCategory) Then

                                        DataGridViewForm_EmployeeCategory.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_EmployeeCategory.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_EmployeeCategory.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_EmployeeCategory_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_EmployeeCategory.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_EmployeeCategory_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_EmployeeCategory.AddNewRowEvent

            'objects
            Dim EmployeeCategory As AdvantageFramework.Database.Entities.EmployeeCategory = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.EmployeeCategory Then

                Me.ShowWaitForm("Processing...")

                EmployeeCategory = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If EmployeeCategory.IsEntityBeingAdded() Then

                        EmployeeCategory.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.EmployeeCategory.Insert(DbContext, EmployeeCategory)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_EmployeeCategory_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_EmployeeCategory.CellValueChangingEvent

            'objects
            Dim EmployeeCategory As AdvantageFramework.Database.Entities.EmployeeCategory = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.EmployeeCategory.Properties.IsInactive.ToString Then

                Try

                    EmployeeCategory = DataGridViewForm_EmployeeCategory.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    EmployeeCategory = Nothing
                End Try

                If EmployeeCategory IsNot Nothing Then

                    Try

                        EmployeeCategory.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        EmployeeCategory.IsInactive = EmployeeCategory.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.EmployeeCategory.Update(DbContext, EmployeeCategory)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_EmployeeCategory_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_EmployeeCategory.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace