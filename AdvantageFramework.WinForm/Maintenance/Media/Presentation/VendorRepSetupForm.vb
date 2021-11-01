Namespace Maintenance.Media.Presentation

    Public Class VendorRepSetupForm

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

            'objects
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim VendorRepresentatives As Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing
            Dim VendorReps As Generic.List(Of AdvantageFramework.Database.Classes.VendorRep) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Vendors = AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).Include("Market").ToList

                    VendorRepresentatives = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadWithOfficeLimits(DbContext, DataContext, Me.Session).ToList

                    VendorReps = (From VendorRepresentative In VendorRepresentatives
                                  Join Vendor In Vendors On Vendor.Code Equals VendorRepresentative.VendorCode
                                  Select New AdvantageFramework.Database.Classes.VendorRep(DbContext, VendorRepresentative, Vendor)).ToList

                End Using

            End Using

            DataGridViewLeftSection_VendorRepresentatives.DataSource = VendorReps
            DataGridViewLeftSection_ExportVendorRepresentatives.DataSource = VendorReps

            DataGridViewLeftSection_VendorRepresentatives.CurrentView.BestFitColumns()
            DataGridViewLeftSection_ExportVendorRepresentatives.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            'objects
            Dim VendorCode As String = Nothing
            Dim VendorRepCode As String = Nothing

            VendorRepresentativeControlRightSection_VendorRep.ClearControl()

            VendorRepresentativeControlRightSection_VendorRep.Enabled = DataGridViewLeftSection_VendorRepresentatives.HasOnlyOneSelectedRow

            If VendorRepresentativeControlRightSection_VendorRep.Enabled Then

                VendorCode = DataGridViewLeftSection_VendorRepresentatives.CurrentView.GetRowCellValue(DataGridViewLeftSection_VendorRepresentatives.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorRep.Properties.VendorCode.ToString)
                VendorRepCode = DataGridViewLeftSection_VendorRepresentatives.CurrentView.GetRowCellValue(DataGridViewLeftSection_VendorRepresentatives.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorRep.Properties.Code.ToString)

                VendorRepresentativeControlRightSection_VendorRep.Enabled = VendorRepresentativeControlRightSection_VendorRep.LoadControl(VendorCode, VendorRepCode, False)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            VendorRepresentativeControlRightSection_VendorRep.Enabled = (DataGridViewLeftSection_VendorRepresentatives.HasOnlyOneSelectedRow AndAlso Me.FormShown)
            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_VendorRepresentatives.HasOnlyOneSelectedRow AndAlso VendorRepresentativeControlRightSection_VendorRep.Enabled)
            ButtonItemActions_Export.Enabled = DataGridViewLeftSection_VendorRepresentatives.HasRows
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

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

                            VendorRepresentativeControlRightSection_VendorRep.Save()

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
            Dim VendorRepSetupForm As AdvantageFramework.Maintenance.Media.Presentation.VendorRepSetupForm = Nothing

            VendorRepSetupForm = New AdvantageFramework.Maintenance.Media.Presentation.VendorRepSetupForm()

            VendorRepSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorRepSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            DataGridViewLeftSection_VendorRepresentatives.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_VendorRepresentatives.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub VendorRepSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorRepSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorRepSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_VendorRepresentatives.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim VendorCode As String = Nothing
            Dim VendorRepCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_VendorRepresentatives.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

                VendorCode = DataGridViewLeftSection_VendorRepresentatives.CurrentView.GetRowCellValue(DataGridViewLeftSection_VendorRepresentatives.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorRep.Properties.VendorCode.ToString)

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Media.Presentation.VendorRepEditDialog.ShowFormDialog(VendorCode, VendorRepCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_VendorRepresentatives.SelectRow(0, VendorCode & "|" & VendorRepCode)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_VendorRepresentatives.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        VendorRepresentativeControlRightSection_VendorRep.Save()

                        Me.ClearChanged()

                        LoadGrid()

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_VendorRepresentatives.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a vendor rep to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_VendorRepresentatives.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        VendorRepresentativeControlRightSection_VendorRep.Delete()

                        LoadGrid()

                        LoadSelectedItemDetails()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a vendor rep to delete.")

            End If

        End Sub
        Private Sub DataGridViewLeftSection_VendorRepresentatives_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_VendorRepresentatives.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_VendorRepresentatives_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_VendorRepresentatives.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            If DataGridViewLeftSection_VendorRepresentatives.HasRows Then

                DataGridViewLeftSection_ExportVendorRepresentatives.CurrentView.AFActiveFilterString = DataGridViewLeftSection_VendorRepresentatives.CurrentView.AFActiveFilterString
                DataGridViewLeftSection_ExportVendorRepresentatives.CurrentView.ApplyFindFilter(DataGridViewLeftSection_VendorRepresentatives.CurrentView.FindFilterText)

                If DataGridViewLeftSection_ExportVendorRepresentatives.Columns(AdvantageFramework.Database.Classes.VendorRep.Properties.Email.ToString) IsNot Nothing AndAlso
                        DataGridViewLeftSection_ExportVendorRepresentatives.Columns(AdvantageFramework.Database.Classes.VendorRep.Properties.Email.ToString).Visible = False Then

                    DataGridViewLeftSection_ExportVendorRepresentatives.MakeColumnNotVisible(AdvantageFramework.Database.Classes.VendorRep.Properties.IsInactive.ToString)

                    DataGridViewLeftSection_ExportVendorRepresentatives.MakeColumnVisible(AdvantageFramework.Database.Classes.VendorRep.Properties.Email.ToString)
                    DataGridViewLeftSection_ExportVendorRepresentatives.MakeColumnVisible(AdvantageFramework.Database.Classes.VendorRep.Properties.Telephone.ToString)
                    DataGridViewLeftSection_ExportVendorRepresentatives.MakeColumnVisible(AdvantageFramework.Database.Classes.VendorRep.Properties.TelephoneExtension.ToString)
                    DataGridViewLeftSection_ExportVendorRepresentatives.MakeColumnVisible(AdvantageFramework.Database.Classes.VendorRep.Properties.Fax.ToString)
                    DataGridViewLeftSection_ExportVendorRepresentatives.MakeColumnVisible(AdvantageFramework.Database.Classes.VendorRep.Properties.FaxExtension.ToString)
                    DataGridViewLeftSection_ExportVendorRepresentatives.MakeColumnVisible(AdvantageFramework.Database.Classes.VendorRep.Properties.CellPhone.ToString)
                    DataGridViewLeftSection_ExportVendorRepresentatives.MakeColumnVisible(AdvantageFramework.Database.Classes.VendorRep.Properties.IsInactive.ToString)

                End If

                DataGridViewLeftSection_ExportVendorRepresentatives.CurrentView.BestFitColumns()

                DataGridViewLeftSection_ExportVendorRepresentatives.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If Me.CheckForUnsavedChanges() Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Refreshing)

                Try

                    VendorRepresentativeControlRightSection_VendorRep.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_VendorRepresentatives.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
