Namespace Maintenance.Accounting.Presentation

    Public Class FunctionHeadingSetupForm

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

                DataGridViewForm_FunctionHeading.DataSource = AdvantageFramework.Database.Procedures.FunctionHeading.Load(DbContext).ToList

            End Using

            DataGridViewForm_FunctionHeading.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_FunctionHeading.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_FunctionHeading.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim FunctionHeadingSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.FunctionHeadingSetupForm = Nothing

            FunctionHeadingSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.FunctionHeadingSetupForm()

            FunctionHeadingSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub FunctionHeadingSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_FunctionHeading.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

            If DataGridViewForm_FunctionHeading.CurrentView.Columns("OrderNumber") IsNot Nothing Then

                DataGridViewForm_FunctionHeading.CurrentView.Columns("OrderNumber").Caption = "Order"

            End If

        End Sub
        Private Sub FunctionHeadingSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub FunctionHeadingSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_FunctionHeading.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim FunctionHeadings As Generic.List(Of AdvantageFramework.Database.Entities.FunctionHeading) = Nothing

            If DataGridViewForm_FunctionHeading.HasRows Then

                DataGridViewForm_FunctionHeading.CurrentView.CloseEditorForUpdating()

                FunctionHeadings = DataGridViewForm_FunctionHeading.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.FunctionHeading)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each FunctionHeading In FunctionHeadings

                            AdvantageFramework.Database.Procedures.FunctionHeading.Update(DbContext, FunctionHeading)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_FunctionHeading.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim FunctionHeading As AdvantageFramework.Database.Entities.FunctionHeading = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_FunctionHeading.HasASelectedRow Then

                DataGridViewForm_FunctionHeading.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_FunctionHeading.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    FunctionHeading = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    FunctionHeading = Nothing
                                End Try

                                If FunctionHeading IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.FunctionHeading.Delete(DbContext, FunctionHeading) Then

                                        DataGridViewForm_FunctionHeading.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_FunctionHeading.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_FunctionHeading.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_FunctionHeading_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_FunctionHeading.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_FunctionHeading_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_FunctionHeading.AddNewRowEvent

            'objects
            Dim FunctionHeading As AdvantageFramework.Database.Entities.FunctionHeading = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.FunctionHeading Then

                Me.ShowWaitForm("Processing...")

                FunctionHeading = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If FunctionHeading.IsEntityBeingAdded() Then

                        FunctionHeading.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.FunctionHeading.Insert(DbContext, FunctionHeading)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_FunctionHeading_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_FunctionHeading.CellValueChangingEvent

            'objects
            Dim FunctionHeading As AdvantageFramework.Database.Entities.FunctionHeading = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.FunctionHeading.Properties.IsInactive.ToString Then

                Try

                    FunctionHeading = DataGridViewForm_FunctionHeading.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    FunctionHeading = Nothing
                End Try

                If FunctionHeading IsNot Nothing Then

                    Try

                        FunctionHeading.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        FunctionHeading.IsInactive = FunctionHeading.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.FunctionHeading.Update(DbContext, FunctionHeading)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_FunctionHeading_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_FunctionHeading.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace