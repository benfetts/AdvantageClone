Namespace Maintenance.Accounting.Presentation

    Public Class EmployeeTitleSetupForm

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

                DataGridViewForm_EmployeeTitle.DataSource = AdvantageFramework.Database.Procedures.EmployeeTitle.Load(DbContext).ToList

            End Using

            DataGridViewForm_EmployeeTitle.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_EmployeeTitle.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_EmployeeTitle.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EmployeeTitleSetupForm As Presentation.EmployeeTitleSetupForm = Nothing

            EmployeeTitleSetupForm = New Presentation.EmployeeTitleSetupForm()

            EmployeeTitleSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTitleSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_EmployeeTitle.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

            If DataGridViewForm_EmployeeTitle.CurrentView.Columns("EmployeeCategoryID") IsNot Nothing Then

                DataGridViewForm_EmployeeTitle.CurrentView.Columns("EmployeeCategoryID").Caption = "Employee Category"

            End If

            'Braxton

            If DataGridViewForm_EmployeeTitle.CurrentView.Columns("DepartmentTeamCode") IsNot Nothing Then

                DataGridViewForm_EmployeeTitle.CurrentView.Columns("DepartmentTeamCode").Caption = "Department Team"

            End If

        End Sub
        Private Sub EmployeeTitleSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeTitleSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_EmployeeTitle.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim EmployeeTitles As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTitle) = Nothing

            If DataGridViewForm_EmployeeTitle.HasRows Then

                DataGridViewForm_EmployeeTitle.CurrentView.CloseEditorForUpdating()

                EmployeeTitles = DataGridViewForm_EmployeeTitle.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.EmployeeTitle)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each EmployeeTitle In EmployeeTitles

                            AdvantageFramework.Database.Procedures.EmployeeTitle.Update(DbContext, EmployeeTitle)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_EmployeeTitle.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_EmployeeTitle.HasASelectedRow Then

                DataGridViewForm_EmployeeTitle.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_EmployeeTitle.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    EmployeeTitle = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    EmployeeTitle = Nothing
                                End Try

                                If EmployeeTitle IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.EmployeeTitle.Delete(DbContext, EmployeeTitle) Then

                                        DataGridViewForm_EmployeeTitle.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_EmployeeTitle.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_EmployeeTitle.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_EmployeeTitle_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_EmployeeTitle.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_EmployeeTitle_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_EmployeeTitle.AddNewRowEvent

            'objects
            Dim EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.EmployeeTitle Then

                Me.ShowWaitForm("Processing...")

                EmployeeTitle = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If EmployeeTitle.IsEntityBeingAdded() Then

                        EmployeeTitle.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.EmployeeTitle.Insert(DbContext, EmployeeTitle)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_EmployeeTitle_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_EmployeeTitle.CellValueChangingEvent

            'objects
            Dim EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.EmployeeTitle.Properties.IsInactive.ToString Then

                Try

                    EmployeeTitle = DataGridViewForm_EmployeeTitle.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    EmployeeTitle = Nothing
                End Try

                If EmployeeTitle IsNot Nothing Then

                    Try

                        EmployeeTitle.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        EmployeeTitle.IsInactive = EmployeeTitle.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.EmployeeTitle.Update(DbContext, EmployeeTitle)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_EmployeeTitle_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_EmployeeTitle.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace