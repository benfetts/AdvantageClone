Namespace Maintenance.Billing.Presentation

    Public Class InvoiceCategorySetupForm

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

                DataGridViewForm_InvoiceCategory.DataSource = (From InvoiceCategory In AdvantageFramework.Database.Procedures.InvoiceCategory.Load(DbContext)
                                                               Select InvoiceCategory
                                                               Order By InvoiceCategory.Code,
                                                                        InvoiceCategory.Description).ToList

            End Using

            DataGridViewForm_InvoiceCategory.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_InvoiceCategory.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_InvoiceCategory.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim InvoiceCategorySetupForm As AdvantageFramework.Maintenance.Billing.Presentation.InvoiceCategorySetupForm = Nothing

            InvoiceCategorySetupForm = New AdvantageFramework.Maintenance.Billing.Presentation.InvoiceCategorySetupForm()

            InvoiceCategorySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub InvoiceCategorySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_InvoiceCategory.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub InvoiceCategorySetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub InvoiceCategorySetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim InvoiceCategorys As Generic.List(Of AdvantageFramework.Database.Entities.InvoiceCategory) = Nothing

            If DataGridViewForm_InvoiceCategory.HasRows Then

                DataGridViewForm_InvoiceCategory.CurrentView.CloseEditorForUpdating()

                InvoiceCategorys = DataGridViewForm_InvoiceCategory.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.InvoiceCategory)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each InvoiceCategory In InvoiceCategorys

                            If AdvantageFramework.Database.Procedures.InvoiceCategory.Update(DbContext, InvoiceCategory) = False Then

                                DbContext.UndoChanges(InvoiceCategory)

                            End If

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_InvoiceCategory.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim InvoiceCategory As AdvantageFramework.Database.Entities.InvoiceCategory = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_InvoiceCategory.HasASelectedRow Then

                DataGridViewForm_InvoiceCategory.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting...")
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_InvoiceCategory.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                    Try

                                        InvoiceCategory = RowHandleAndDataBoundItem.Value

                                    Catch ex As Exception
                                        InvoiceCategory = Nothing
                                    End Try

                                    If InvoiceCategory IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.InvoiceCategory.Delete(DbContext, InvoiceCategory) Then

                                            DataGridViewForm_InvoiceCategory.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                        End If

                                    End If

                                Next

                            End Using

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    If DataGridViewForm_InvoiceCategory.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_InvoiceCategory.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub DataGridViewForm_InvoiceCategory_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_InvoiceCategory.AddNewRowEvent

            'objects
            Dim InvoiceCategory As AdvantageFramework.Database.Entities.InvoiceCategory = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.InvoiceCategory Then

                Me.ShowWaitForm("Adding...")

                Try

                    InvoiceCategory = RowObject

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If InvoiceCategory.IsEntityBeingAdded() Then

                            InvoiceCategory.DbContext = DbContext

                            AdvantageFramework.Database.Procedures.InvoiceCategory.Insert(DbContext, InvoiceCategory)

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_InvoiceCategory_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_InvoiceCategory.CellValueChangingEvent

            'objects
            Dim InvoiceCategory As AdvantageFramework.Database.Entities.InvoiceCategory = Nothing
            Dim RefreshInvoiceCategories As Boolean = False

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.InvoiceCategory.Properties.IsInactive.ToString Then

                Try

                    InvoiceCategory = DataGridViewForm_InvoiceCategory.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    InvoiceCategory = Nothing
                End Try

                If InvoiceCategory IsNot Nothing Then

                    Try

                        InvoiceCategory.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        InvoiceCategory.IsInactive = InvoiceCategory.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.InvoiceCategory.Update(DbContext, InvoiceCategory)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_InvoiceCategory_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_InvoiceCategory.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_InvoiceCategory_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_InvoiceCategory.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_InvoiceCategory.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace