Namespace Maintenance.Accounting.Presentation

    Public Class VendorTermSetupForm

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

                DataGridViewForm_VendorTerm.DataSource = AdvantageFramework.Database.Procedures.VendorTerm.Load(DbContext).ToList

            End Using

            DataGridViewForm_VendorTerm.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_VendorTerm.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_VendorTerm.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim VendorTermSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.VendorTermSetupForm = Nothing

            VendorTermSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.VendorTermSetupForm()

            VendorTermSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorTermSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_VendorTerm.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub VendorTermSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorTermSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_VendorTerm.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim VendorTerms As Generic.List(Of AdvantageFramework.Database.Entities.VendorTerm) = Nothing

            If DataGridViewForm_VendorTerm.HasRows Then

                DataGridViewForm_VendorTerm.CurrentView.CloseEditorForUpdating()

                VendorTerms = DataGridViewForm_VendorTerm.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.VendorTerm)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each VendorTerm In VendorTerms

                            AdvantageFramework.Database.Procedures.VendorTerm.Update(DbContext, VendorTerm)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_VendorTerm.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim VendorTerm As AdvantageFramework.Database.Entities.VendorTerm = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_VendorTerm.HasASelectedRow Then

                DataGridViewForm_VendorTerm.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_VendorTerm.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    VendorTerm = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    VendorTerm = Nothing
                                End Try

                                If VendorTerm IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorTerm.Delete(DbContext, VendorTerm) Then

                                        DataGridViewForm_VendorTerm.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_VendorTerm.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_VendorTerm.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_VendorTerm_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_VendorTerm.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_VendorTerm_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_VendorTerm.AddNewRowEvent

            'objects
            Dim VendorTerm As AdvantageFramework.Database.Entities.VendorTerm = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.VendorTerm Then

                Me.ShowWaitForm("Processing...")

                VendorTerm = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If VendorTerm.IsEntityBeingAdded() Then

                        VendorTerm.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.VendorTerm.Insert(DbContext, VendorTerm)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_VendorTerm_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_VendorTerm.CellValueChangingEvent

            'objects
            Dim VendorTerm As AdvantageFramework.Database.Entities.VendorTerm = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.VendorTerm.Properties.IsInactive.ToString Then

                Try

                    VendorTerm = DataGridViewForm_VendorTerm.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    VendorTerm = Nothing
                End Try

                If VendorTerm IsNot Nothing Then

                    Try

                        VendorTerm.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        VendorTerm.IsInactive = VendorTerm.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.VendorTerm.Update(DbContext, VendorTerm)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_VendorTerm_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_VendorTerm.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace