Namespace Maintenance.Client.Presentation

    Public Class AffiliationSetupForm

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

                DataGridViewForm_Affiliation.DataSource = AdvantageFramework.Database.Procedures.Affiliation.Load(DbContext).ToList

            End Using

            DataGridViewForm_Affiliation.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_Affiliation.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_Affiliation.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AffiliationSetupForm As Presentation.AffiliationSetupForm = Nothing

            AffiliationSetupForm = New Presentation.AffiliationSetupForm()

            AffiliationSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AffiliationSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            LoadGrid()

            DataGridViewForm_Affiliation.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub AffiliationSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub AffiliationSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_Affiliation.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim Affiliations As Generic.List(Of AdvantageFramework.Database.Entities.Affiliation) = Nothing

            If DataGridViewForm_Affiliation.HasRows Then

                DataGridViewForm_Affiliation.CurrentView.CloseEditorForUpdating()

                Affiliations = DataGridViewForm_Affiliation.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Affiliation)().ToList

                Me.ShowWaitForm("Processing...")

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each Affiliation In Affiliations

                        AdvantageFramework.Database.Procedures.Affiliation.Update(DbContext, Affiliation)

                    Next

                End Using

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Me.CloseWaitForm()

                DataGridViewForm_Affiliation.ValidateAllRowsAndClearChanged(True)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Affiliation As AdvantageFramework.Database.Entities.Affiliation = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_Affiliation.HasASelectedRow Then

                DataGridViewForm_Affiliation.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_Affiliation.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    Affiliation = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    Affiliation = Nothing
                                End Try

                                If Affiliation IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.Affiliation.Delete(DbContext, Affiliation) Then

                                        DataGridViewForm_Affiliation.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_Affiliation.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Affiliation.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Affiliation_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Affiliation.CellValueChangingEvent

            Dim Affiliation As AdvantageFramework.Database.Entities.Affiliation = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.Affiliation.Properties.IsInactive.ToString Then

                Try

                    Affiliation = DataGridViewForm_Affiliation.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    Affiliation = Nothing
                End Try

                If Affiliation IsNot Nothing Then

                    Try

                        Affiliation.IsInactive = e.Value

                    Catch ex As Exception
                        Affiliation.IsInactive = Affiliation.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.Affiliation.Update(DbContext, Affiliation)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Affiliation_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Affiliation.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Affiliation_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_Affiliation.AddNewRowEvent

            'objects
            Dim Affiliation As AdvantageFramework.Database.Entities.Affiliation = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.Affiliation Then

                Me.ShowWaitForm("Processing...")

                Affiliation = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Affiliation.IsEntityBeingAdded() Then

                        Affiliation.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.Affiliation.Insert(DbContext, Affiliation)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Affiliation_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Affiliation.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace