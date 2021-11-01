Namespace Maintenance.ProjectManagement.Presentation

    Public Class ComplexityTypeSetupForm

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

                DataGridViewForm_Complexity.DataSource = AdvantageFramework.Database.Procedures.Complexity.Load(DbContext).ToList

            End Using

            DataGridViewForm_Complexity.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_Complexity.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_Complexity.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ComplexityTypeSetupForm As Presentation.ComplexityTypeSetupForm = Nothing

            ComplexityTypeSetupForm = New Presentation.ComplexityTypeSetupForm()

            ComplexityTypeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ComplexityTypeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_Complexity.CurrentView.AFActiveFilterString = "[IsActive] = 1"

            If DataGridViewForm_Complexity.Columns("IsActive") IsNot Nothing Then

                DataGridViewForm_Complexity.Columns("IsActive").Caption = "Is Inactive"

            End If

        End Sub
        Private Sub ComplexityTypeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ComplexityTypeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_Complexity.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim Complexitys As Generic.List(Of AdvantageFramework.Database.Entities.Complexity) = Nothing

            If DataGridViewForm_Complexity.HasRows Then

                DataGridViewForm_Complexity.CurrentView.CloseEditorForUpdating()

                Complexitys = DataGridViewForm_Complexity.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Complexity)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each Complexity In Complexitys

                            AdvantageFramework.Database.Procedures.Complexity.Update(DbContext, Complexity)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_Complexity.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Complexity As AdvantageFramework.Database.Entities.Complexity = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_Complexity.HasASelectedRow Then

                DataGridViewForm_Complexity.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_Complexity.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    Complexity = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    Complexity = Nothing
                                End Try

                                If Complexity IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.Complexity.Delete(DbContext, Complexity) Then

                                        DataGridViewForm_Complexity.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_Complexity.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Complexity.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Complexity_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Complexity.InitNewRowEvent

            DataGridViewForm_Complexity.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.Complexity.Properties.IsActive.ToString, CShort(1))

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Complexity_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_Complexity.AddNewRowEvent

            'objects
            Dim Complexity As AdvantageFramework.Database.Entities.Complexity = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.Complexity Then

                Me.ShowWaitForm("Processing...")

                Complexity = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Complexity.IsEntityBeingAdded() Then

                        Complexity.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.Complexity.Insert(DbContext, Complexity)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Complexity_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Complexity.CellValueChangingEvent

            'objects
            Dim Complexity As AdvantageFramework.Database.Entities.Complexity = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.Complexity.Properties.IsActive.ToString Then

                Try

                    Complexity = DataGridViewForm_Complexity.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    Complexity = Nothing
                End Try

                If Complexity IsNot Nothing Then

                    Try

                        Complexity.IsActive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        Complexity.IsActive = Complexity.IsActive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.Complexity.Update(DbContext, Complexity)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Complexity_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Complexity.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
