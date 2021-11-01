Namespace Maintenance.ProjectManagement.Presentation

    Public Class JobTypeSetupForm

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

                DataGridViewForm_JobType.DataSource = AdvantageFramework.Database.Procedures.JobType.Load(DbContext).ToList

            End Using

            DataGridViewForm_JobType.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_JobType.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_JobType.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim JobTypeSetupForm As Presentation.JobTypeSetupForm = Nothing

            JobTypeSetupForm = New Presentation.JobTypeSetupForm()

            JobTypeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub JobTypeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_JobType.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub JobTypeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub JobTypeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_JobType.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim JobTypes As Generic.List(Of AdvantageFramework.Database.Entities.JobType) = Nothing

            If DataGridViewForm_JobType.HasRows Then

                DataGridViewForm_JobType.CurrentView.CloseEditorForUpdating()

                JobTypes = DataGridViewForm_JobType.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobType)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each JobType In JobTypes

                            AdvantageFramework.Database.Procedures.JobType.Update(DbContext, JobType)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_JobType.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim JobType As AdvantageFramework.Database.Entities.JobType = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_JobType.HasASelectedRow Then

                DataGridViewForm_JobType.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_JobType.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    JobType = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    JobType = Nothing
                                End Try

                                If JobType IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.JobType.Delete(DbContext, JobType) Then

                                        DataGridViewForm_JobType.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_JobType.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_JobType.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_JobType_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_JobType.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_JobType_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_JobType.AddNewRowEvent

            'objects
            Dim JobType As AdvantageFramework.Database.Entities.JobType = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.JobType Then

                Me.ShowWaitForm("Processing...")

                JobType = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If JobType.IsEntityBeingAdded() Then

                        JobType.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.JobType.Insert(DbContext, JobType)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_JobType_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_JobType.CellValueChangingEvent

            'objects
            Dim JobType As AdvantageFramework.Database.Entities.JobType = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.JobType.Properties.IsInactive.ToString Then

                Try

                    JobType = DataGridViewForm_JobType.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    JobType = Nothing
                End Try

                If JobType IsNot Nothing Then

                    Try

                        JobType.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        JobType.IsInactive = JobType.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.JobType.Update(DbContext, JobType)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_JobType_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_JobType.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_JobType_QueryPopupNeedDatasourceEvent(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_JobType.QueryPopupNeedDatasourceEvent

            Dim SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SalesClasses = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList

            End Using

            OverrideDefaultDatasource = True
            Datasource = SalesClasses.FindAll(Function(Entity) Entity.SalesClassTypeCode Is Nothing OrElse Entity.SalesClassTypeCode.ToLower = "p")

        End Sub

#End Region

#End Region

    End Class

End Namespace