Namespace Maintenance.General.Presentation

    Public Class RegionSetupForm

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

                DataGridViewForm_Region.DataSource = AdvantageFramework.Database.Procedures.PrintSpecRegion.Load(DbContext).ToList

            End Using

            DataGridViewForm_Region.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_Region.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_Region.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim RegionSetupForm As Presentation.RegionSetupForm = Nothing

            RegionSetupForm = New Presentation.RegionSetupForm()

            RegionSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RegionSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_Region.CurrentView.AFActiveFilterString = "[IsActive] = 1"

            If DataGridViewForm_Region.Columns("IsActive") IsNot Nothing Then

                DataGridViewForm_Region.Columns("IsActive").Caption = "Is Inactive"

            End If

        End Sub
        Private Sub RegionSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub RegionSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_Region.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim PrintSpecRegions As Generic.List(Of AdvantageFramework.Database.Entities.PrintSpecRegion) = Nothing

            If DataGridViewForm_Region.HasRows Then

                DataGridViewForm_Region.CurrentView.CloseEditorForUpdating()

                PrintSpecRegions = DataGridViewForm_Region.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.PrintSpecRegion)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each PrintSpecRegion In PrintSpecRegions

                            AdvantageFramework.Database.Procedures.PrintSpecRegion.Update(DbContext, PrintSpecRegion)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_Region.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim PrintSpecRegion As AdvantageFramework.Database.Entities.PrintSpecRegion = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_Region.HasASelectedRow Then

                DataGridViewForm_Region.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_Region.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    PrintSpecRegion = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    PrintSpecRegion = Nothing
                                End Try

                                If PrintSpecRegion IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.PrintSpecRegion.Delete(DbContext, PrintSpecRegion) Then

                                        DataGridViewForm_Region.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_Region.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Region.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Region_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Region.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Region_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_Region.AddNewRowEvent

            'objects
            Dim PrintSpecRegion As AdvantageFramework.Database.Entities.PrintSpecRegion = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.PrintSpecRegion Then

                Me.ShowWaitForm("Processing...")

                PrintSpecRegion = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If PrintSpecRegion.IsEntityBeingAdded() Then

                        PrintSpecRegion.DbContext = DbContext

                        PrintSpecRegion.IsActive = If(PrintSpecRegion.IsActive Is Nothing, 1, 0)

                        AdvantageFramework.Database.Procedures.PrintSpecRegion.Insert(DbContext, PrintSpecRegion)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Region_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Region.CellValueChangingEvent

            'objects
            Dim PrintSpecRegion As AdvantageFramework.Database.Entities.PrintSpecRegion = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.PrintSpecRegion.Properties.IsActive.ToString Then

                Try

                    PrintSpecRegion = DataGridViewForm_Region.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    PrintSpecRegion = Nothing
                End Try

                If PrintSpecRegion IsNot Nothing Then

                    Try

                        PrintSpecRegion.IsActive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        PrintSpecRegion.IsActive = PrintSpecRegion.IsActive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.PrintSpecRegion.Update(DbContext, PrintSpecRegion)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Region_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Region.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace