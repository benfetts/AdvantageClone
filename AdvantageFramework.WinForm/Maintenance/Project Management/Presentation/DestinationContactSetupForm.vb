Namespace Maintenance.ProjectManagement.Presentation

    Public Class DestinationContactSetupForm

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
        Private Sub LoadSelectedItemDetails()

            'objects
            Dim CurrentFilterString As String = Nothing

            With DataGridViewRightSection_DestinationContacts.CurrentView

                CurrentFilterString = .AFActiveFilterString
                .AFActiveFilterString = ""

            End With

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                DataGridViewRightSection_DestinationContacts.Enabled = DataGridViewLeftSection_Destinations.HasOnlyOneSelectedRow

                If DataGridViewRightSection_DestinationContacts.Enabled Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DataGridViewRightSection_DestinationContacts.DataSource = AdvantageFramework.Database.Procedures.DestinationContact.LoadByDestinationCode(DbContext, DataGridViewLeftSection_Destinations.GetFirstSelectedRowBookmarkValue).ToList

                    End Using

                Else

                    DataGridViewRightSection_DestinationContacts.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.DestinationContact))

                End If

                DataGridViewRightSection_DestinationContacts.CurrentView.BestFitColumns()

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Try

                DataGridViewRightSection_DestinationContacts.CurrentView.AFActiveFilterString = CurrentFilterString

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_Destinations.DataSource = AdvantageFramework.Database.Procedures.Destination.Load(DbContext)

            End Using

            DataGridViewLeftSection_Destinations.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            DataGridViewRightSection_DestinationContacts.Enabled = (DataGridViewLeftSection_Destinations.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            If DataGridViewRightSection_DestinationContacts.Enabled = False Then

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            ElseIf DataGridViewRightSection_DestinationContacts.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewRightSection_DestinationContacts.HasASelectedRow

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim DestinationContacts As Generic.List(Of AdvantageFramework.Database.Entities.DestinationContact) = Nothing
            Dim Saved As Boolean = False

            Try

                If DataGridViewRightSection_DestinationContacts.HasRows Then

                    DataGridViewRightSection_DestinationContacts.CurrentView.CloseEditorForUpdating()

                    DestinationContacts = DataGridViewRightSection_DestinationContacts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.DestinationContact)().ToList

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Saving...")
                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each DestinationContact In DestinationContacts

                                AdvantageFramework.Database.Procedures.DestinationContact.Update(DbContext, DestinationContact)

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    Try

                        DataGridViewLeftSection_Destinations.ValidateAllRowsAndClearChanged(True)

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                    Saved = True

                End If

            Catch ex As Exception
                Saved = False
            End Try

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim DestinationContactSetupForm As Presentation.DestinationContactSetupForm = Nothing

            DestinationContactSetupForm = New Presentation.DestinationContactSetupForm()

            DestinationContactSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DestinationContactSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            DataGridViewRightSection_DestinationContacts.AutoFilterLookupColumns = True

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Destinations.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Try

                DataGridViewRightSection_DestinationContacts.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.DestinationContact))
                DataGridViewRightSection_DestinationContacts.CurrentView.AFActiveFilterString = "[IsInactive] = 0s"

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub DestinationContactSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DestinationContactSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DestinationContactSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Destinations.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Destinations_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Destinations.LeavingRowEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Destinations_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_Destinations.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewRightSection_DestinationContacts.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim DestinationContact As AdvantageFramework.Database.Entities.DestinationContact = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewRightSection_DestinationContacts.HasASelectedRow Then

                DataGridViewRightSection_DestinationContacts.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewRightSection_DestinationContacts.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    DestinationContact = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    DestinationContact = Nothing
                                End Try

                                If DestinationContact IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.DestinationContact.Delete(DbContext, DestinationContact) Then

                                        DataGridViewRightSection_DestinationContacts.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewRightSection_DestinationContacts.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewRightSection_DestinationContacts.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_DestinationContacts_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewRightSection_DestinationContacts.InitNewRowEvent

            DataGridViewRightSection_DestinationContacts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.DestinationContact.Properties.DestinationCode.ToString, DataGridViewLeftSection_Destinations.GetFirstSelectedRowBookmarkValue)

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_DestinationContacts_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewRightSection_DestinationContacts.AddNewRowEvent

            'objects
            Dim DestinationContact As AdvantageFramework.Database.Entities.DestinationContact = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.DestinationContact Then

                Me.ShowWaitForm("Processing...")

                DestinationContact = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If DestinationContact.IsEntityBeingAdded() Then

                        DestinationContact.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.DestinationContact.Insert(DbContext, DestinationContact)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewRightSection_DestinationContacts_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_DestinationContacts.CellValueChangingEvent

            'objects
            Dim DestinationContact As AdvantageFramework.Database.Entities.DestinationContact = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.DestinationContact.Properties.IsInactive.ToString Then

                Try

                    DestinationContact = DataGridViewRightSection_DestinationContacts.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    DestinationContact = Nothing
                End Try

                If DestinationContact IsNot Nothing Then

                    Try

                        DestinationContact.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        DestinationContact.IsInactive = DestinationContact.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.DestinationContact.Update(DbContext, DestinationContact)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_DestinationContacts_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_DestinationContacts.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace