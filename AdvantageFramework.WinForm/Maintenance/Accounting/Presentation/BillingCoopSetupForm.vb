Namespace Maintenance.Accounting.Presentation

    Public Class BillingCoopSetupForm

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
            Dim Products As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim BillingCoopCodes As Generic.List(Of String) = Nothing
            Dim BillingCoops As Generic.List(Of AdvantageFramework.Database.Entities.BillingCoop) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Products = AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, False, False).ToList

                    BillingCoops = AdvantageFramework.Database.Procedures.BillingCoop.Load(DbContext).ToList

                    BillingCoopCodes = BillingCoops.Select(Function(Entity) Entity.Code).Distinct.ToList

                    For Each BillingCoopCode In BillingCoopCodes.ToList

                        If BillingCoops.Where(Function(Entity) Entity.Code = BillingCoopCode).Any(Function(Entity) Products.Any(Function(Product) Product.ClientCode = Entity.ClientCode AndAlso
                                                                                                                                                  Product.DivisionCode = Entity.DivisionCode AndAlso
                                                                                                                                                  Product.Code = Entity.ProductCode)) = False Then

                            BillingCoopCodes.Remove(BillingCoopCode)

                        End If

                    Next

                    DataGridViewLeftSection_BillingCoops.DataSource = BillingCoops.Where(Function(Entity) BillingCoopCodes.Contains(Entity.Code)).ToList

                End Using

            End Using

            DataGridViewLeftSection_BillingCoops.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            BillingCoopControlRightSection_BillingCoop.ClearControl()

            BillingCoopControlRightSection_BillingCoop.Enabled = DataGridViewLeftSection_BillingCoops.HasOnlyOneSelectedRow

            If BillingCoopControlRightSection_BillingCoop.Enabled Then

                BillingCoopControlRightSection_BillingCoop.Enabled = BillingCoopControlRightSection_BillingCoop.LoadControl(DataGridViewLeftSection_BillingCoops.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            BillingCoopControlRightSection_BillingCoop.Enabled = (DataGridViewLeftSection_BillingCoops.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_BillingCoops.HasOnlyOneSelectedRow AndAlso BillingCoopControlRightSection_BillingCoop.Enabled)

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

                            IsOkay = BillingCoopControlRightSection_BillingCoop.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
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
            Dim BillingCoopSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.BillingCoopSetupForm = Nothing

            BillingCoopSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.BillingCoopSetupForm()

            BillingCoopSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCoopSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            DataGridViewLeftSection_BillingCoops.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_BillingCoops.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub BillingCoopSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub BillingCoopSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub BillingCoopSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_BillingCoops.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_BillingCoops_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_BillingCoops.LeavingRowEvent

            'objects
            Dim AllowLeaveRow As Boolean = True

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If BillingCoopControlRightSection_BillingCoop.Enabled AndAlso BillingCoopControlRightSection_BillingCoop.PercentTotal <> 100 Then

                    AllowLeaveRow = False

                    AdvantageFramework.WinForm.MessageBox.Show("Total must equal 100%.", WinForm.MessageBox.MessageBoxButtons.OK)

                End If

                If AllowLeaveRow Then

                    AllowLeaveRow = CheckForUnsavedChanges()

                End If

                e.Allow = AllowLeaveRow

            End If

        End Sub
        Private Sub DataGridViewLeftSection_BillingCoops_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_BillingCoops.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_BillingCoops.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If BillingCoopControlRightSection_BillingCoop.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_BillingCoops.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a billing coop to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_BillingCoops.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If BillingCoopControlRightSection_BillingCoop.Delete() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a billing coop to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim BillingCoopCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_BillingCoops.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Accounting.Presentation.BillingCoopEditDialog.ShowFormDialog(BillingCoopCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_BillingCoops.SelectRow(BillingCoopCode)

                End If

            End If

        End Sub
        Private Sub BillingCoopControlRightSection_BillingCoop_SelectedCodeDeletedEvent() Handles BillingCoopControlRightSection_BillingCoop.SelectedCodeDeletedEvent

            LoadGrid()

        End Sub
        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            'objects
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing
            Dim CodesList As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                CodesList = DataGridViewLeftSection_BillingCoops.GetAllRowsBookmarkValues.OfType(Of String).ToList

                DataGridViewLeftSection_ExportBillingCoops.DataSource = (From Entity In AdvantageFramework.Database.Procedures.BillingCoop.Load(DbContext).ToList.Where(Function(Entity) CodesList.Contains(Entity.Code) = True).ToList
                                                                         Join Prod In AdvantageFramework.Database.Procedures.ProductView.Load(DbContext) On Entity.ProductCode Equals Prod.ProductCode And Entity.DivisionCode Equals Prod.DivisionCode And Entity.ClientCode Equals Prod.ClientCode
                                                                         Select New AdvantageFramework.Database.Classes.BillingCoop(Entity) With {.ClientCode = Prod.ClientCode,
                                                                                                                                                  .ClientName = Prod.ClientName,
                                                                                                                                                  .DivisionCode = Prod.DivisionCode,
                                                                                                                                                  .DivisionName = Prod.DivisionName,
                                                                                                                                                  .ProductCode = Prod.ProductCode,
                                                                                                                                                  .ProductName = Prod.ProductDescription,
                                                                                                                                                  .OfficeCode = Prod.OfficeCode,
                                                                                                                                                  .OfficeName = Prod.OfficeName}).ToList

                If DataGridViewLeftSection_ExportBillingCoops.Columns(AdvantageFramework.Database.Classes.BillingCoop.Properties.BillCoop.ToString) IsNot Nothing Then

                    DataGridViewLeftSection_ExportBillingCoops.Columns(AdvantageFramework.Database.Classes.BillingCoop.Properties.BillCoop.ToString).Visible = True

                    DataGridViewLeftSection_ExportBillingCoops.Columns(AdvantageFramework.Database.Classes.BillingCoop.Properties.BillCoop.ToString).Group()

                End If

                If DataGridViewLeftSection_ExportBillingCoops.Columns(AdvantageFramework.Database.Classes.BillingCoop.Properties.Percent.ToString) IsNot Nothing AndAlso
                        DataGridViewLeftSection_ExportBillingCoops.CurrentView.GroupSummary.Count = 0 Then

                    GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                    GridGroupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    GridGroupSummaryItem.FieldName = AdvantageFramework.Database.Classes.BillingCoop.Properties.Percent.ToString

                    GridGroupSummaryItem.ShowInGroupColumnFooter = DataGridViewLeftSection_ExportBillingCoops.Columns(AdvantageFramework.Database.Classes.BillingCoop.Properties.Percent.ToString)

                    DataGridViewLeftSection_ExportBillingCoops.CurrentView.GroupSummary.Add(GridGroupSummaryItem)

                End If

                DataGridViewLeftSection_ExportBillingCoops.CurrentView.BestFitColumns()

                DataGridViewLeftSection_ExportBillingCoops.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End Using

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            BillingCoopControlRightSection_BillingCoop.ExportBillingCoopCodes()

        End Sub

#End Region

#End Region

    End Class

End Namespace
