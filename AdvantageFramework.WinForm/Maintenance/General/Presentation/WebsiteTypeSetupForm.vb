Namespace Maintenance.General.Presentation

    Public Class WebsiteTypeSetupForm

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

                DataGridViewForm_WebsiteType.DataSource = AdvantageFramework.Database.Procedures.WebsiteType.Load(DbContext).ToList

            End Using

            DataGridViewForm_WebsiteType.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_WebsiteType.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_WebsiteType.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim WebsiteTypeSetupForm As AdvantageFramework.Maintenance.General.Presentation.WebsiteTypeSetupForm = Nothing

            WebsiteTypeSetupForm = New AdvantageFramework.Maintenance.General.Presentation.WebsiteTypeSetupForm()

            WebsiteTypeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub WebsiteTypeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_WebsiteType.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub WebsiteTypeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub WebsiteTypeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_WebsiteType.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim WebsiteTypes As Generic.List(Of AdvantageFramework.Database.Entities.WebsiteType) = Nothing

            If DataGridViewForm_WebsiteType.HasRows Then

                DataGridViewForm_WebsiteType.CurrentView.CloseEditorForUpdating()

                WebsiteTypes = DataGridViewForm_WebsiteType.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.WebsiteType)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each WebsiteType In WebsiteTypes

                            AdvantageFramework.Database.Procedures.WebsiteType.Update(DbContext, WebsiteType)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_WebsiteType.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim WebsiteType As AdvantageFramework.Database.Entities.WebsiteType = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_WebsiteType.HasASelectedRow Then

                DataGridViewForm_WebsiteType.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_WebsiteType.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    WebsiteType = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    WebsiteType = Nothing
                                End Try

                                If WebsiteType IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.WebsiteType.Delete(DbContext, WebsiteType) Then

                                        DataGridViewForm_WebsiteType.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_WebsiteType.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_WebsiteType.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_WebsiteType_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_WebsiteType.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_WebsiteType_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_WebsiteType.AddNewRowEvent

            'objects
            Dim WebsiteType As AdvantageFramework.Database.Entities.WebsiteType = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.WebsiteType Then

                Me.ShowWaitForm("Processing...")

                WebsiteType = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If WebsiteType.IsEntityBeingAdded() Then

                        WebsiteType.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.WebsiteType.Insert(DbContext, WebsiteType)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_WebsiteType_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_WebsiteType.CellValueChangingEvent

            'objects
            Dim WebsiteType As AdvantageFramework.Database.Entities.WebsiteType = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.WebsiteType.Properties.IsInactive.ToString Then

                Try

                    WebsiteType = DataGridViewForm_WebsiteType.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    WebsiteType = Nothing
                End Try

                If WebsiteType IsNot Nothing Then

                    Try

                        WebsiteType.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        WebsiteType.IsInactive = WebsiteType.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.WebsiteType.Update(DbContext, WebsiteType)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_WebsiteType_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_WebsiteType.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace