Namespace Maintenance.Accounting.Presentation

    Public Class SalesTaxSetupForm

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

                DataGridViewForm_SalesTax.DataSource = AdvantageFramework.Database.Procedures.SalesTax.Load(DbContext).ToList

            End Using

            DataGridViewForm_SalesTax.CurrentView.BestFitColumns()

            DataGridViewForm_SalesTax.HideOrShowColumn("ID", False)

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_SalesTax.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_SalesTax.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim SalesTaxSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.SalesTaxSetupForm = Nothing

            SalesTaxSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.SalesTaxSetupForm()

            SalesTaxSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub SalesTaxSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_SalesTax.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub SalesTaxSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub SalesTaxSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_SalesTax.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim SalesTaxs As Generic.List(Of AdvantageFramework.Database.Entities.SalesTax) = Nothing

            If DataGridViewForm_SalesTax.HasRows Then

                DataGridViewForm_SalesTax.CurrentView.CloseEditorForUpdating()

                SalesTaxs = DataGridViewForm_SalesTax.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.SalesTax)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each SalesTax In SalesTaxs

                            AdvantageFramework.Database.Procedures.SalesTax.Update(DbContext, SalesTax)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_SalesTax.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_SalesTax.HasASelectedRow Then

                DataGridViewForm_SalesTax.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_SalesTax.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    SalesTax = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    SalesTax = Nothing
                                End Try

                                If SalesTax IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.SalesTax.Delete(DbContext, SalesTax) Then

                                        DataGridViewForm_SalesTax.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)
                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_SalesTax.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_SalesTax.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_SalesTax_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_SalesTax.InitNewRowEvent

            'objects
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            If TypeOf DataGridViewForm_SalesTax.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.SalesTax Then

                SalesTax = DataGridViewForm_SalesTax.CurrentView.GetRow(e.RowHandle)

                SalesTax.CityPercent = 0
                SalesTax.CountyPercent = 0
                SalesTax.StatePercent = 0

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_SalesTax_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_SalesTax.AddNewRowEvent

            'objects
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.SalesTax Then

                Me.ShowWaitForm("Processing...")

                SalesTax = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If SalesTax.IsEntityBeingAdded() Then

                        SalesTax.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.SalesTax.Insert(DbContext, SalesTax)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_SalesTax_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_SalesTax.CellValueChangingEvent

            'objects
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.SalesTax.Properties.IsInactive.ToString Then

                Try

                    SalesTax = DataGridViewForm_SalesTax.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    SalesTax = Nothing
                End Try

                If SalesTax IsNot Nothing Then

                    Try

                        SalesTax.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        SalesTax.IsInactive = SalesTax.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.SalesTax.Update(DbContext, SalesTax)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_SalesTax_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_SalesTax.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace