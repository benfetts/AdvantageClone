Namespace Maintenance.Accounting.Presentation

    Public Class SalesClassSetupForm

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

                DataGridViewForm_SalesClass.DataSource = AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext).ToList

            End Using

            DataGridViewForm_SalesClass.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_SalesClass.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_SalesClass.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim SalesClassSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.SalesClassSetupForm = Nothing

            SalesClassSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.SalesClassSetupForm()

            SalesClassSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub SalesClassSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_SalesClass.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

            If DataGridViewForm_SalesClass.Columns("SalesClassTypeCode") IsNot Nothing Then

                DataGridViewForm_SalesClass.Columns("SalesClassTypeCode").Caption = "Media Type"

            End If

        End Sub
        Private Sub SalesClassSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub SalesClassSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_SalesClass.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim SalesClasss As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing

            If DataGridViewForm_SalesClass.HasRows Then

                DataGridViewForm_SalesClass.CurrentView.CloseEditorForUpdating()

                SalesClasss = DataGridViewForm_SalesClass.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.SalesClass)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each SalesClass In SalesClasss

                            AdvantageFramework.Database.Procedures.SalesClass.Update(DbContext, SalesClass)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_SalesClass.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim SalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_SalesClass.HasASelectedRow Then

                DataGridViewForm_SalesClass.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Loading...")
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_SalesClass.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    SalesClass = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    SalesClass = Nothing
                                End Try

                                If SalesClass IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.SalesClass.Delete(DbContext, SalesClass) Then

                                        DataGridViewForm_SalesClass.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_SalesClass.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_SalesClass.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_SalesClass_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_SalesClass.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_SalesClass_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_SalesClass.AddNewRowEvent

            'objects
            Dim SalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.SalesClass Then

                Me.ShowWaitForm("Processing...")

                SalesClass = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If SalesClass.IsEntityBeingAdded() Then

                        SalesClass.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.SalesClass.Insert(DbContext, SalesClass)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_SalesClass_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_SalesClass.CellValueChangingEvent

            'objects
            Dim SalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.SalesClass.Properties.IsInactive.ToString Then

                Try

                    SalesClass = DataGridViewForm_SalesClass.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    SalesClass = Nothing
                End Try

                If SalesClass IsNot Nothing Then

                    Try

                        SalesClass.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        SalesClass.IsInactive = SalesClass.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.SalesClass.Update(DbContext, SalesClass)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_SalesClass_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_SalesClass.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace