Namespace Maintenance.Accounting.Presentation

    Public Class VendorServiceTaxSetupForm

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

                DataGridViewForm_VendorServiceTax.DataSource = AdvantageFramework.Database.Procedures.VendorServiceTax.Load(DataContext).ToList

            End Using

            DataGridViewForm_VendorServiceTax.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_VendorServiceTax.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_VendorServiceTax.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim VendorServiceTaxSetupForm As Presentation.VendorServiceTaxSetupForm = Nothing

            VendorServiceTaxSetupForm = New Presentation.VendorServiceTaxSetupForm()

            VendorServiceTaxSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorServiceTaxSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_VendorServiceTax.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub VendorServiceTaxSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorServiceTaxSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_VendorServiceTax.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim VendorServiceTaxes As Generic.List(Of AdvantageFramework.Database.Entities.VendorServiceTax) = Nothing
            Dim VendorServiceTax As AdvantageFramework.Database.Entities.VendorServiceTax = Nothing

            If DataGridViewForm_VendorServiceTax.HasRows Then

                DataGridViewForm_VendorServiceTax.CurrentView.CloseEditorForUpdating()

                VendorServiceTaxes = DataGridViewForm_VendorServiceTax.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.VendorServiceTax)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each VST In VendorServiceTaxes

                                VendorServiceTax = AdvantageFramework.Database.Procedures.VendorServiceTax.LoadByVendorServiceTaxID(DataContext, VST.ID)

                                If VendorServiceTax IsNot Nothing Then

                                    VendorServiceTax.DbContext = DbContext

                                    VendorServiceTax.Code = VST.Code
                                    VendorServiceTax.Description = VST.Description
                                    VendorServiceTax.Type = VST.Type
                                    VendorServiceTax.Rate = VST.Rate
                                    VendorServiceTax.Threshold = VST.Threshold
                                    VendorServiceTax.GLACode = VST.GLACode

                                    AdvantageFramework.Database.Procedures.VendorServiceTax.Update(DataContext, VendorServiceTax)

                                End If

                            Next

                        End Using

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_VendorServiceTax.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim VendorServiceTax As AdvantageFramework.Database.Entities.VendorServiceTax = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_VendorServiceTax.HasASelectedRow Then

                DataGridViewForm_VendorServiceTax.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_VendorServiceTax.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    VendorServiceTax = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    VendorServiceTax = Nothing
                                End Try

                                If VendorServiceTax IsNot Nothing Then

                                    DataContext.VendorServiceTaxes.Attach(VendorServiceTax)

                                    If AdvantageFramework.Database.Procedures.VendorServiceTax.Delete(DataContext, VendorServiceTax) Then

                                        DataGridViewForm_VendorServiceTax.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("Vendor service tax '" & VendorServiceTax.Code & "' is in use and cannot be deleted.")

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_VendorServiceTax.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_VendorServiceTax.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_VendorServiceTax_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_VendorServiceTax.CellValueChangingEvent

            Dim VendorServiceTax As AdvantageFramework.Database.Entities.VendorServiceTax = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.VendorServiceTax.Properties.IsInactive.ToString Then

                Try

                    VendorServiceTax = DataGridViewForm_VendorServiceTax.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    VendorServiceTax = Nothing
                End Try

                If VendorServiceTax IsNot Nothing Then

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            VendorServiceTax = AdvantageFramework.Database.Procedures.VendorServiceTax.LoadByVendorServiceTaxID(DataContext, VendorServiceTax.ID)

                            VendorServiceTax.IsInactive = e.Value

                            Saved = AdvantageFramework.Database.Procedures.VendorServiceTax.Update(DataContext, VendorServiceTax)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_VendorServiceTax_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_VendorServiceTax.InitNewRowEvent

            DirectCast(DataGridViewForm_VendorServiceTax.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.VendorServiceTax).DatabaseAction = Database.Action.Inserting

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_VendorServiceTax_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_VendorServiceTax.AddNewRowEvent

            'objects
            Dim VendorServiceTax As AdvantageFramework.Database.Entities.VendorServiceTax = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.VendorServiceTax Then

                Me.ShowWaitForm("Processing...")

                VendorServiceTax = RowObject

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    VendorServiceTax.DataContext = DataContext

                    AdvantageFramework.Database.Procedures.VendorServiceTax.Insert(DataContext, VendorServiceTax)

                    VendorServiceTax.DatabaseAction = Database.Action.Updating

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_VendorServiceTax_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_VendorServiceTax.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_VendorServiceTax_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_VendorServiceTax.QueryPopupNeedDatasourceEvent

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityObjectContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If FieldName = AdvantageFramework.Database.Entities.VendorServiceTax.Properties.GLACode.ToString Then

                        OverrideDefaultDatasource = True
                        Datasource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Me.Session).ToList

                    End If

                End Using

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace