Namespace Maintenance.Accounting.Presentation

    Public Class IndirectCategoryTypeSetupForm

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

                DataGridViewForm_IndirectCategoryType.DataSource = AdvantageFramework.Database.Procedures.TimeCategoryType.Load(DbContext).ToList

            End Using

            DataGridViewForm_IndirectCategoryType.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_IndirectCategoryType.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_IndirectCategoryType.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim IndirectCategoryTypeSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.IndirectCategoryTypeSetupForm = Nothing

            IndirectCategoryTypeSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.IndirectCategoryTypeSetupForm()

            IndirectCategoryTypeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub IndirectCategoryTypeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

        End Sub
        Private Sub IndirectCategoryTypeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub IndirectCategoryTypeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_IndirectCategoryType.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim TimeCategoryTypes As Generic.List(Of AdvantageFramework.Database.Entities.TimeCategoryType) = Nothing

            If DataGridViewForm_IndirectCategoryType.HasRows Then

                DataGridViewForm_IndirectCategoryType.CurrentView.CloseEditorForUpdating()

                TimeCategoryTypes = DataGridViewForm_IndirectCategoryType.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.TimeCategoryType)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each TimeCategoryType In TimeCategoryTypes

                            AdvantageFramework.Database.Procedures.TimeCategoryType.Update(DbContext, TimeCategoryType)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_IndirectCategoryType.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim TimeCategoryType As AdvantageFramework.Database.Entities.TimeCategoryType = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_IndirectCategoryType.HasASelectedRow Then

                DataGridViewForm_IndirectCategoryType.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_IndirectCategoryType.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    TimeCategoryType = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    TimeCategoryType = Nothing
                                End Try

                                If TimeCategoryType IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.TimeCategoryType.Delete(DbContext, TimeCategoryType) Then

                                        DataGridViewForm_IndirectCategoryType.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_IndirectCategoryType.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_IndirectCategoryType.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_IndirectCategoryType_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_IndirectCategoryType.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_IndirectCategoryType_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_IndirectCategoryType.AddNewRowEvent

            'objects
            Dim TimeCategoryType As AdvantageFramework.Database.Entities.TimeCategoryType = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.TimeCategoryType Then

                Me.ShowWaitForm("Processing...")

                TimeCategoryType = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If TimeCategoryType.IsEntityBeingAdded() Then

                        TimeCategoryType.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.TimeCategoryType.Insert(DbContext, TimeCategoryType)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_IndirectCategoryType_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_IndirectCategoryType.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace