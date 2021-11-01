Namespace Maintenance.General.Presentation

    Public Class UserDefinedReportCategorySetupForm

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

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_UserDefinedReportCategory.DataSource = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).ToList

            End Using

            DataGridViewForm_UserDefinedReportCategory.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_UserDefinedReportCategory.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_UserDefinedReportCategory.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim UserDefinedReportCategorySetupForm As Presentation.UserDefinedReportCategorySetupForm = Nothing

            UserDefinedReportCategorySetupForm = New Presentation.UserDefinedReportCategorySetupForm()

            UserDefinedReportCategorySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub UserDefinedReportCategorySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

        End Sub
        Private Sub UserDefinedReportCategorySetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub UserDefinedReportCategorySetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_UserDefinedReportCategory.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim UserDefinedReportCategorys As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory) = Nothing

            If DataGridViewForm_UserDefinedReportCategory.HasRows Then

                DataGridViewForm_UserDefinedReportCategory.CurrentView.CloseEditorForUpdating()

                UserDefinedReportCategorys = DataGridViewForm_UserDefinedReportCategory.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each UserDefinedReportCategory In UserDefinedReportCategorys

                            AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Update(ReportingDbContext, UserDefinedReportCategory)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_UserDefinedReportCategory.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim UserDefinedReportCategory As AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_UserDefinedReportCategory.HasASelectedRow Then

                DataGridViewForm_UserDefinedReportCategory.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_UserDefinedReportCategory.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    UserDefinedReportCategory = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    UserDefinedReportCategory = Nothing
                                End Try

                                If UserDefinedReportCategory IsNot Nothing Then

                                    If AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Delete(ReportingDbContext, UserDefinedReportCategory) Then

                                        DataGridViewForm_UserDefinedReportCategory.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_UserDefinedReportCategory.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_UserDefinedReportCategory.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_UserDefinedReportCategory_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_UserDefinedReportCategory.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_UserDefinedReportCategory_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_UserDefinedReportCategory.AddNewRowEvent

            'objects
            Dim UserDefinedReportCategory As AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory = Nothing

            If TypeOf RowObject Is AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory Then

                Me.ShowWaitForm("Processing...")

                UserDefinedReportCategory = RowObject

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If UserDefinedReportCategory.IsEntityBeingAdded() Then

                        UserDefinedReportCategory.DbContext = ReportingDbContext

                        AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Insert(ReportingDbContext, UserDefinedReportCategory)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_UserDefinedReportCategory_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_UserDefinedReportCategory.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace