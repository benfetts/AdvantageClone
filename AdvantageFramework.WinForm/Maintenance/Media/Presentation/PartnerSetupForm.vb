Namespace Maintenance.Media.Presentation

    Public Class PartnerSetupForm

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

                DataGridViewLeftSection_Partners.DataSource = AdvantageFramework.Database.Procedures.Partner.Load(DbContext)

            End Using

            DataGridViewLeftSection_Partners.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadExportGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_ExportPartners.DataSource = AdvantageFramework.Database.Procedures.Partner.Load(DbContext)

            End Using

            DataGridViewLeftSection_ExportPartners.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            PartnerControlRightSection_Partner.ClearControl()

            PartnerControlRightSection_Partner.Enabled = DataGridViewLeftSection_Partners.HasOnlyOneSelectedRow

            If PartnerControlRightSection_Partner.Enabled Then

                PartnerControlRightSection_Partner.Enabled = PartnerControlRightSection_Partner.LoadControl(DataGridViewLeftSection_Partners.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub ExportGrid(ByVal FilterString As String, ByVal FindFilterText As String)

            Try

                LoadExportGrid()

                DataGridViewLeftSection_ExportPartners.CurrentView.AFActiveFilterString = FilterString

                If String.IsNullOrEmpty(FindFilterText) = False Then

                    DataGridViewLeftSection_ExportPartners.CurrentView.ApplyFindFilter(FindFilterText)

                End If

                DataGridViewLeftSection_ExportPartners.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            Catch ex As Exception

            End Try

        End Sub
        Private Sub EnableOrDisableActions()

            PartnerControlRightSection_Partner.Enabled = (DataGridViewLeftSection_Partners.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemSpelling_CheckSpelling.Enabled = PartnerControlRightSection_Partner.Enabled

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

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

                            IsOkay = PartnerControlRightSection_Partner.Save()

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

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim PartnerSetupForm As AdvantageFramework.Maintenance.Media.Presentation.PartnerSetupForm = Nothing

            PartnerSetupForm = New AdvantageFramework.Maintenance.Media.Presentation.PartnerSetupForm()

            PartnerSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub PartnerSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemSpelling_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            DataGridViewLeftSection_Partners.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Partners.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub PartnerSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PartnerSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PartnerSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Partners.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Partners_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Partners.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Partners_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Partners.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_Partners.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If PartnerControlRightSection_Partner.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_Partners.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a partner to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim PartnerCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Partners.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Media.Presentation.PartnerEditDialog.ShowFormDialog(PartnerCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Partners.SelectRow(PartnerCode)

                End If

            End If

        End Sub
        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            Try

                If DataGridViewLeftSection_Partners.CurrentView.ActiveFilterEnabled Then

                    ExportGrid(DataGridViewLeftSection_Partners.CurrentView.AFActiveFilterString, DataGridViewLeftSection_Partners.CurrentView.FindFilterText)

                Else

                    ExportGrid("", DataGridViewLeftSection_Partners.CurrentView.FindFilterText)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            Try

                If DataGridViewLeftSection_Partners.HasOnlyOneSelectedRow Then

                    ExportGrid("[Code] = '" & DataGridViewLeftSection_Partners.GetFirstSelectedRowBookmarkValue & "'", Nothing)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemSpelling_CheckSpelling_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSpelling_CheckSpelling.Click

            PartnerControlRightSection_Partner.SpellCheck()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Refreshing)

                Try

                    PartnerControlRightSection_Partner.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_Partners.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace