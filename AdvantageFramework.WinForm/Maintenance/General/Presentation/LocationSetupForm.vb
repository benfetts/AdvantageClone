Namespace Maintenance.General.Presentation

    Public Class LocationSetupForm

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

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_Locations.DataSource = AdvantageFramework.Database.Procedures.Location.Load(DataContext).ToList

                DataGridViewLeftSection_Locations.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            LocationControlRightSection_Location.ClearControl()

            LocationControlRightSection_Location.Enabled = DataGridViewLeftSection_Locations.HasOnlyOneSelectedRow

            If LocationControlRightSection_Location.Enabled Then

                LocationControlRightSection_Location.Enabled = LocationControlRightSection_Location.LoadControl(DataGridViewLeftSection_Locations.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_Locations.HasOnlyOneSelectedRow
            LocationControlRightSection_Location.Enabled = (DataGridViewLeftSection_Locations.HasOnlyOneSelectedRow AndAlso Me.FormShown)

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            LocationControlRightSection_Location.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim LocationSetupForm As AdvantageFramework.Maintenance.General.Presentation.LocationSetupForm = Nothing

            LocationSetupForm = New AdvantageFramework.Maintenance.General.Presentation.LocationSetupForm()

            LocationSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub LocationSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            DataGridViewLeftSection_Locations.MultiSelect = False

            LocationControlRightSection_Location.TextBoxFooterLogoSelection_Landscape.SetAgencyImportPathToLogoPath()
            LocationControlRightSection_Location.TextBoxFooterLogoSelection_Portrait.SetAgencyImportPathToLogoPath()
            LocationControlRightSection_Location.TextBoxHeaderLogoSelection_Landscape.SetAgencyImportPathToLogoPath()
            LocationControlRightSection_Location.TextBoxHeaderLogoSelection_Portrait.SetAgencyImportPathToLogoPath()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    LocationControlRightSection_Location.TextBoxFooterLogoSelection_Landscape.ReadOnly = True
                    LocationControlRightSection_Location.TextBoxFooterLogoSelection_Portrait.ReadOnly = True
                    LocationControlRightSection_Location.TextBoxHeaderLogoSelection_Landscape.ReadOnly = True
                    LocationControlRightSection_Location.TextBoxHeaderLogoSelection_Portrait.ReadOnly = True

                End If

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub LocationSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub LocationSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub LocationSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Locations.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Locations_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Locations.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Locations_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Locations.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_Locations.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        LocationControlRightSection_Location.Save()

                        Me.ClearChanged()

                        LoadGrid()
                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_Locations.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a location to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim LocationID As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Locations.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.General.Presentation.LocationEditDialog.ShowFormDialog(LocationID) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Locations.SelectRow(LocationID)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

            If DataGridViewLeftSection_Locations.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        LocationControlRightSection_Location.Delete()

                        LoadGrid()

                        LoadSelectedItemDetails()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a location to delete.")

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace