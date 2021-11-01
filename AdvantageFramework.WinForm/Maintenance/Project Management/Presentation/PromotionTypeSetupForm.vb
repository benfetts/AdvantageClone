Namespace Maintenance.ProjectManagement.Presentation

    Public Class PromotionTypeSetupForm

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

                DataGridViewForm_PromotionType.DataSource = AdvantageFramework.Database.Procedures.PromotionType.Load(DbContext).ToList

            End Using

            DataGridViewForm_PromotionType.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_PromotionType.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_PromotionType.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim PromotionTypeSetupForm As Presentation.PromotionTypeSetupForm = Nothing

            PromotionTypeSetupForm = New Presentation.PromotionTypeSetupForm()

            PromotionTypeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub PromotionTypeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_PromotionType.CurrentView.AFActiveFilterString = "[IsActive] = 1"

            If DataGridViewForm_PromotionType.Columns("IsActive") IsNot Nothing Then

                DataGridViewForm_PromotionType.Columns("IsActive").Caption = "Is Inactive"

            End If

        End Sub
        Private Sub PromotionTypeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PromotionTypeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_PromotionType.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim PromotionTypes As Generic.List(Of AdvantageFramework.Database.Entities.PromotionType) = Nothing

            If DataGridViewForm_PromotionType.HasRows Then

                DataGridViewForm_PromotionType.CurrentView.CloseEditorForUpdating()

                PromotionTypes = DataGridViewForm_PromotionType.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.PromotionType)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each PromotionType In PromotionTypes

                            AdvantageFramework.Database.Procedures.PromotionType.Update(DbContext, PromotionType)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_PromotionType.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim PromotionType As AdvantageFramework.Database.Entities.PromotionType = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_PromotionType.HasASelectedRow Then

                DataGridViewForm_PromotionType.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_PromotionType.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    PromotionType = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    PromotionType = Nothing
                                End Try

                                If PromotionType IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.PromotionType.Delete(DbContext, PromotionType) Then

                                        DataGridViewForm_PromotionType.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_PromotionType.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_PromotionType.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_PromotionType_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_PromotionType.InitNewRowEvent

            DataGridViewForm_PromotionType.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.PromotionType.Properties.IsActive.ToString, CShort(1))

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_PromotionType_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_PromotionType.AddNewRowEvent

            'objects
            Dim PromotionType As AdvantageFramework.Database.Entities.PromotionType = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.PromotionType Then

                Me.ShowWaitForm("Processing...")

                PromotionType = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If PromotionType.IsEntityBeingAdded() Then

                        PromotionType.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.PromotionType.Insert(DbContext, PromotionType)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_PromotionType_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_PromotionType.CellValueChangingEvent

            'objects
            Dim PromotionType As AdvantageFramework.Database.Entities.PromotionType = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.PromotionType.Properties.IsActive.ToString Then

                Try

                    PromotionType = DataGridViewForm_PromotionType.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    PromotionType = Nothing
                End Try

                If PromotionType IsNot Nothing Then

                    Try

                        PromotionType.IsActive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        PromotionType.IsActive = PromotionType.IsActive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.PromotionType.Update(DbContext, PromotionType)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_PromotionType_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_PromotionType.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace