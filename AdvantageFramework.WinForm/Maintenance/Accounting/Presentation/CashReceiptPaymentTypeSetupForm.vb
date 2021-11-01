Namespace Maintenance.Accounting.Presentation

    Public Class CashReceiptPaymentTypeSetupForm

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

                DataGridViewForm_CashReceiptPaymentType.DataSource = AdvantageFramework.Database.Procedures.CashReceiptPaymentType.Load(DbContext).ToList

            End Using

            DataGridViewForm_CashReceiptPaymentType.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_CashReceiptPaymentType.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_CashReceiptPaymentType.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CashReceiptPaymentTypeSetupForm As Presentation.CashReceiptPaymentTypeSetupForm = Nothing

            CashReceiptPaymentTypeSetupForm = New Presentation.CashReceiptPaymentTypeSetupForm()

            CashReceiptPaymentTypeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CashReceiptPaymentTypeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_CashReceiptPaymentType.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub CashReceiptPaymentTypeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CashReceiptPaymentTypeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_CashReceiptPaymentType.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim CashReceiptPaymentTypes As Generic.List(Of AdvantageFramework.Database.Entities.CashReceiptPaymentType) = Nothing

            If DataGridViewForm_CashReceiptPaymentType.HasRows Then

                DataGridViewForm_CashReceiptPaymentType.CurrentView.CloseEditorForUpdating()

                CashReceiptPaymentTypes = DataGridViewForm_CashReceiptPaymentType.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.CashReceiptPaymentType)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each CashReceiptPaymentType In CashReceiptPaymentTypes

                            AdvantageFramework.Database.Procedures.CashReceiptPaymentType.Update(DbContext, CashReceiptPaymentType, Nothing)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_CashReceiptPaymentType.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim CashReceiptPaymentType As AdvantageFramework.Database.Entities.CashReceiptPaymentType = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_CashReceiptPaymentType.HasASelectedRow Then

                DataGridViewForm_CashReceiptPaymentType.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_CashReceiptPaymentType.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    CashReceiptPaymentType = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    CashReceiptPaymentType = Nothing
                                End Try

                                If CashReceiptPaymentType IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.CashReceiptPaymentType.Delete(DbContext, CashReceiptPaymentType) Then

                                        DataGridViewForm_CashReceiptPaymentType.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("This payment type is in use and cannot be deleted.")

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_CashReceiptPaymentType.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_CashReceiptPaymentType.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_CashReceiptPaymentType_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_CashReceiptPaymentType.CellValueChangingEvent

            Dim CashReceiptPaymentType As AdvantageFramework.Database.Entities.CashReceiptPaymentType = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.CashReceiptPaymentType.Properties.IsInactive.ToString Then

                Try

                    CashReceiptPaymentType = DataGridViewForm_CashReceiptPaymentType.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    CashReceiptPaymentType = Nothing
                End Try

                If CashReceiptPaymentType IsNot Nothing Then

                    Try

                        CashReceiptPaymentType.IsInactive = e.Value

                    Catch ex As Exception
                        CashReceiptPaymentType.IsInactive = CashReceiptPaymentType.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.CashReceiptPaymentType.Update(DbContext, CashReceiptPaymentType, Nothing)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_CashReceiptPaymentType_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_CashReceiptPaymentType.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_CashReceiptPaymentType_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_CashReceiptPaymentType.AddNewRowEvent

            'objects
            Dim CashReceiptPaymentType As AdvantageFramework.Database.Entities.CashReceiptPaymentType = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.CashReceiptPaymentType Then

                Me.ShowWaitForm("Processing...")

                CashReceiptPaymentType = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CashReceiptPaymentType.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.CashReceiptPaymentType.Insert(DbContext, CashReceiptPaymentType, Nothing)

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_CashReceiptPaymentType_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_CashReceiptPaymentType.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace