Namespace Maintenance.Accounting.Presentation

    Public Class ServiceFeeTypeSetupForm

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

                DataGridViewForm_ServiceFeeType.DataSource = AdvantageFramework.Database.Procedures.ServiceFeeType.Load(DbContext).ToList

            End Using

            DataGridViewForm_ServiceFeeType.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_ServiceFeeType.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_ServiceFeeType.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ServiceFeeTypeSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.ServiceFeeTypeSetupForm = Nothing

            ServiceFeeTypeSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.ServiceFeeTypeSetupForm()

            ServiceFeeTypeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceFeeTypeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_ServiceFeeType.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub ServiceFeeTypeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ServiceFeeTypeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_ServiceFeeType.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ServiceFeeTypes As Generic.List(Of AdvantageFramework.Database.Entities.ServiceFeeType) = Nothing

            If DataGridViewForm_ServiceFeeType.HasRows Then

                DataGridViewForm_ServiceFeeType.CurrentView.CloseEditorForUpdating()

                ServiceFeeTypes = DataGridViewForm_ServiceFeeType.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ServiceFeeType)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ServiceFeeType In ServiceFeeTypes

                            AdvantageFramework.Database.Procedures.ServiceFeeType.Update(DbContext, ServiceFeeType)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_ServiceFeeType.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ServiceFeeType As AdvantageFramework.Database.Entities.ServiceFeeType = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_ServiceFeeType.HasASelectedRow Then

                DataGridViewForm_ServiceFeeType.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_ServiceFeeType.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    ServiceFeeType = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    ServiceFeeType = Nothing
                                End Try

                                If ServiceFeeType IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.ServiceFeeType.Delete(DbContext, ServiceFeeType) Then

                                        DataGridViewForm_ServiceFeeType.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_ServiceFeeType.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_ServiceFeeType.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ServiceFeeType_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_ServiceFeeType.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ServiceFeeType_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_ServiceFeeType.AddNewRowEvent

            'objects
            Dim ServiceFeeType As AdvantageFramework.Database.Entities.ServiceFeeType = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ServiceFeeType Then

                Me.ShowWaitForm("Processing...")

                ServiceFeeType = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ServiceFeeType.IsEntityBeingAdded() Then

                        ServiceFeeType.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.ServiceFeeType.Insert(DbContext, ServiceFeeType)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_ServiceFeeType_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ServiceFeeType.CellValueChangingEvent

            'objects
            Dim ServiceFeeType As AdvantageFramework.Database.Entities.ServiceFeeType = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.ServiceFeeType.Properties.IsInactive.ToString Then

                Try

                    ServiceFeeType = DataGridViewForm_ServiceFeeType.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ServiceFeeType = Nothing
                End Try

                If ServiceFeeType IsNot Nothing Then

                    Try

                        ServiceFeeType.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        ServiceFeeType.IsInactive = ServiceFeeType.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.ServiceFeeType.Update(DbContext, ServiceFeeType)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ServiceFeeType_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_ServiceFeeType.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace