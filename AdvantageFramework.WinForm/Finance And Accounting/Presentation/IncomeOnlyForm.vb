Namespace FinanceAndAccounting.Presentation

    Public Class IncomeOnlyForm

#Region " Constants "



#End Region

#Region " Enum "

        Protected Enum IncomeOnlyViewLayout
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "By Client")>
            ByClient = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "By Division")>
            ByDivision = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "By Product")>
            ByProduct = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "By Job")>
            ByJob = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "By Job Component")>
            ByJobComponent = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "[All]")>
            All = 5
        End Enum

#End Region

#Region " Variables "

        Private _LastSelectedIndex As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property ViewLayout As IncomeOnlyViewLayout
            Get
                ViewLayout = DirectCast(ComboBoxItemSearch_Search.ComboBoxEx.SelectedValue, IncomeOnlyViewLayout)
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub SwitchView()

            'objects
            Dim ViewLayout As IncomeOnlyViewLayout = IncomeOnlyViewLayout.ByClient

            DataGridViewLeftSection_View.DataSource = Nothing
            DataGridViewLeftSection_View.ItemDescription = Nothing
            DataGridViewLeftSection_View.ClearGridCustomization()

            ViewLayout = Me.ViewLayout

            If ViewLayout = IncomeOnlyViewLayout.All Then

                ButtonItemSearch_SelectAll.Checked = True
                ButtonItemSearch_SelectBy.Checked = False
                ExpandableSplitterControlForm_LeftRight.Expanded = False
                ExpandableSplitterControlForm_LeftRight.Enabled = False
                DataGridViewLeftSection_View.Enabled = False

            Else

                ButtonItemSearch_SelectAll.Checked = False
                ButtonItemSearch_SelectBy.Checked = True
                ExpandableSplitterControlForm_LeftRight.Expanded = True
                ExpandableSplitterControlForm_LeftRight.Enabled = True
                DataGridViewLeftSection_View.Enabled = True

            End If

            LoadGrid()

            If DataGridViewLeftSection_View.Enabled Then

                DataGridViewLeftSection_View.FocusToFindPanel(True)

            End If

        End Sub
        Private Sub LoadGrid()

            If Me.ViewLayout = IncomeOnlyViewLayout.All Then

                LoadSelectedItemDetails()

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Select Case Me.ViewLayout

                            Case IncomeOnlyViewLayout.ByClient

                                DataGridViewLeftSection_View.ItemDescription = "Active Client(s)"
                                DataGridViewLeftSection_View.DataSource = From Entity In AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                                                          Where Entity.IsActive = 1
                                                                          Select Entity

                            Case IncomeOnlyViewLayout.ByDivision

                                DataGridViewLeftSection_View.ItemDescription = "Active Division(s)"
                                DataGridViewLeftSection_View.DataSource = From Entity In AdvantageFramework.Database.Procedures.DivisionView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                                                          Where Entity.IsActive = 1
                                                                          Select Entity

                            Case IncomeOnlyViewLayout.ByProduct

                                DataGridViewLeftSection_View.ItemDescription = "Active Product(s)"
                                DataGridViewLeftSection_View.DataSource = AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, True).ToList

                            Case IncomeOnlyViewLayout.ByJob

                                DataGridViewLeftSection_View.ItemDescription = "Open Job(s)"
                                DataGridViewLeftSection_View.DataSource = AdvantageFramework.IncomeOnly.LoadAvailableJobs(DbContext, Me.Session.UserCode).OrderByDescending(Function(item) item.JobNumber)

                            Case IncomeOnlyViewLayout.ByJobComponent

                                DataGridViewLeftSection_View.ItemDescription = "Open Job Component(s)"
                                DataGridViewLeftSection_View.DataSource = From Entity In AdvantageFramework.IncomeOnly.LoadJobComponentList(DbContext, Me.Session.UserCode)
                                                                          Order By Entity.JobNumber Descending, Entity.JobComponentNumber Ascending
                                                                          Select Entity

                        End Select

                    End Using

                End Using

                DataGridViewLeftSection_View.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub LoadViewKeys(ByRef ClientCode As String, ByRef DivisionCode As String, ByRef ProductCode As String, ByRef JobNumber As Integer?, ByRef JobComponentNumber As Integer?)

            If Me.ViewLayout <> IncomeOnlyViewLayout.All Then

                Select Case Me.ViewLayout

                    Case IncomeOnlyViewLayout.ByClient

                        ClientCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Entities.Client.Properties.Code.ToString)
                        DivisionCode = Nothing
                        ProductCode = Nothing
                        JobNumber = Nothing
                        JobComponentNumber = Nothing

                    Case IncomeOnlyViewLayout.ByDivision

                        ClientCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.DivisionView.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue("Code")
                        ProductCode = Nothing
                        JobNumber = Nothing
                        JobComponentNumber = Nothing

                    Case IncomeOnlyViewLayout.ByProduct

                        ClientCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.ProductView.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.ProductView.Properties.DivisionCode.ToString)
                        ProductCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.ProductView.Properties.ProductCode.ToString)
                        JobNumber = Nothing
                        JobComponentNumber = Nothing

                    Case IncomeOnlyViewLayout.ByJob

                        ClientCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.JobView.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.JobView.Properties.DivisionCode.ToString)
                        ProductCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.JobView.Properties.ProductCode.ToString)
                        JobNumber = CInt(DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.JobView.Properties.JobNumber.ToString))
                        JobComponentNumber = Nothing

                    Case IncomeOnlyViewLayout.ByJobComponent

                        ClientCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.DivisionCode.ToString)
                        ProductCode = DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.ProductCode.ToString)
                        JobNumber = CInt(DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.JobNumber.ToString))
                        JobComponentNumber = CInt(DataGridViewLeftSection_View.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.JobComponentNumber.ToString))

                End Select

            End If

        End Sub
        Private Sub LoadSelectedItemDetails()

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As Integer? = Nothing
            Dim JobComponentNumber As Integer? = Nothing
            Dim ServiceFeeContractID As Integer = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                If IncomeOnlyControlRightSection_IncomeOnly.Enabled Then

                    IncomeOnlyControlRightSection_IncomeOnly.ClearControl()

                End If

                IncomeOnlyControlRightSection_IncomeOnly.Enabled = DataGridViewLeftSection_View.HasOnlyOneSelectedRow OrElse Me.ViewLayout = IncomeOnlyViewLayout.All

                If IncomeOnlyControlRightSection_IncomeOnly.Enabled Then

                    If Me.ViewLayout <> IncomeOnlyViewLayout.All Then

                        LoadViewKeys(ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber)

                    End If

                    IncomeOnlyControlRightSection_IncomeOnly.LoadControl(ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            If Me.FormAction <> WinForm.Presentation.FormActions.Refreshing Then

                IncomeOnlyControlRightSection_IncomeOnly.Enabled = Me.FormShown AndAlso (DataGridViewLeftSection_View.HasOnlyOneSelectedRow OrElse Me.ViewLayout = IncomeOnlyViewLayout.All)

            Else

                IncomeOnlyControlRightSection_IncomeOnly.Enabled = False

            End If

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Print.Enabled = True

            RibbonBarOptions_IncomeOnly.Visible = IncomeOnlyControlRightSection_IncomeOnly.IsIncomeOnlyTabSeleted
            RibbonBarOptions_Contracts.Visible = IncomeOnlyControlRightSection_IncomeOnly.IsContractsTabSeleted
            RibbonBarOptions_ServiceFees.Visible = IncomeOnlyControlRightSection_IncomeOnly.IsContractsTabSeleted
            ButtonItemActions_Print.Visible = IncomeOnlyControlRightSection_IncomeOnly.IsIncomeOnlyTabSeleted
            ButtonItemActions_ShowAll.Visible = IncomeOnlyControlRightSection_IncomeOnly.IsIncomeOnlyTabSeleted

            If IncomeOnlyControlRightSection_IncomeOnly.Enabled Then

                RibbonBarOptions_IncomeOnly.Enabled = True
                RibbonBarOptions_Contracts.Enabled = True
                RibbonBarOptions_ServiceFees.Enabled = True
                ButtonItemActions_ShowDescriptions.Enabled = True
                ButtonItemActions_ShowAll.Enabled = True

            Else

                RibbonBarOptions_IncomeOnly.Enabled = False
                RibbonBarOptions_Contracts.Enabled = False
                RibbonBarOptions_ServiceFees.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_ShowDescriptions.Enabled = False
                ButtonItemActions_ShowAll.Enabled = False

            End If

            If RibbonBarOptions_IncomeOnly.Enabled AndAlso RibbonBarOptions_IncomeOnly.Visible Then

                ButtonItemIncomeOnly_Cancel.Enabled = IncomeOnlyControlRightSection_IncomeOnly.DetailsDataGridView.IsNewItemRow
                ButtonItemIncomeOnly_Delete.Enabled = IncomeOnlyControlRightSection_IncomeOnly.CanDeleteSelectedRows
                ButtonItemIncomeOnly_Copy.Enabled = IncomeOnlyControlRightSection_IncomeOnly.CanCopySelectedRows
                ButtonItemIncomeOnly_CopyTo.Enabled = IncomeOnlyControlRightSection_IncomeOnly.CanCopySelectedRows
                ButtonItemIncomeOnly_CopyFrom.Enabled = IncomeOnlyControlRightSection_IncomeOnly.AddAllowed AndAlso Not IncomeOnlyControlRightSection_IncomeOnly.DetailsDataGridView.IsNewItemRow
                ButtonItemIncomeOnly_ClearFilters.Enabled = True

            Else

                ButtonItemIncomeOnly_Cancel.Enabled = False
                ButtonItemIncomeOnly_Delete.Enabled = False
                ButtonItemIncomeOnly_Copy.Enabled = False
                ButtonItemIncomeOnly_CopyTo.Enabled = False
                ButtonItemIncomeOnly_CopyFrom.Enabled = False
                ButtonItemIncomeOnly_ClearFilters.Enabled = False

            End If

            If RibbonBarOptions_Contracts.Enabled AndAlso RibbonBarOptions_Contracts.Visible Then

                ButtonItemContracts_Add.Enabled = True
                ButtonItemContracts_Copy.Enabled = IncomeOnlyControlRightSection_IncomeOnly.ContractsDataGridView.HasOnlyOneSelectedRow
                ButtonItemContracts_Delete.Enabled = IncomeOnlyControlRightSection_IncomeOnly.ContractsDataGridView.HasASelectedRow

            End If

            If RibbonBarOptions_ServiceFees.Enabled AndAlso RibbonBarOptions_ServiceFees.Visible Then

                ButtonItemServiceFees_GenerateAll.Enabled = True
                ButtonItemServiceFees_Generate.Enabled = IncomeOnlyControlRightSection_IncomeOnly.ContractsDataGridView.HasASelectedRow
                ButtonItemServiceFees_View.Enabled = IncomeOnlyControlRightSection_IncomeOnly.ContractsDataGridView.HasASelectedRow

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ResetRibbonBar(RibbonBarOptions_Actions)
            AdvantageFramework.WinForm.Presentation.Controls.ResetRibbonBar(RibbonBarOptions_Contracts)
            AdvantageFramework.WinForm.Presentation.Controls.ResetRibbonBar(RibbonBarOptions_ServiceFees)

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

                            IsOkay = IncomeOnlyControlRightSection_IncomeOnly.Save()

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
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                If IncomeOnlyControlRightSection_IncomeOnly.Save() Then

                    Me.ClearChanged()

                    LoadGrid()

                    Saved = True

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If Saved Then

                    If Me.ViewLayout <> IncomeOnlyViewLayout.All Then

                        DataGridViewLeftSection_View.FocusToFindPanel(False)

                        DataGridViewLeftSection_View.CurrentView.GridViewSelectionChanged()

                    End If

                    IncomeOnlyControlRightSection_IncomeOnly.ApplyLastFilter()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Save = Saved

        End Function
        Private Sub ReloadJobComponents()

            'objects
            Dim JobNumber As Integer? = Nothing
            Dim JobComponentNumber As Integer? = Nothing

            If Me.ViewLayout = IncomeOnlyViewLayout.ByJobComponent Then

                LoadViewKeys(Nothing, Nothing, Nothing, JobNumber, JobComponentNumber)

                LoadGrid()

                For RowHandle = 0 To DataGridViewLeftSection_View.CurrentView.RowCount - 1

                    If CInt(DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.JobNumber.ToString)) = JobNumber.GetValueOrDefault(0) AndAlso
                        CInt(DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.JobComponentNumber.ToString)) = JobComponentNumber.GetValueOrDefault(0) Then

                        DataGridViewLeftSection_View.CurrentView.SelectRow(RowHandle)

                        Exit For

                    End If

                Next

            End If

        End Sub
        Private Sub ModifyColumn(ByVal FieldName As String, ByVal Visible As Boolean, ByVal VisibleIndex As Short)

            If DataGridViewLeftSection_View.Columns(FieldName) IsNot Nothing Then

                DataGridViewLeftSection_View.Columns(FieldName).Visible = Visible
                DataGridViewLeftSection_View.Columns(FieldName).VisibleIndex = VisibleIndex

            End If

        End Sub
        Private Sub RefreshForm(ByVal RefreshControl As Boolean)

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If CheckForUnsavedChanges() Then

                    Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                    SwitchView()

                    IncomeOnlyControlRightSection_IncomeOnly.RefreshControl()

                    If Me.ViewLayout <> IncomeOnlyViewLayout.All Then

                        IncomeOnlyControlRightSection_IncomeOnly.ClearControl()
                        IncomeOnlyControlRightSection_IncomeOnly.Enabled = False
                        DataGridViewLeftSection_View.FocusToFindPanel(True)

                    End If

                    _LastSelectedIndex = ComboBoxItemSearch_Search.SelectedIndex

                    EnableOrDisableActions()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                Else

                    Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                    ComboBoxItemSearch_Search.SelectedIndex = _LastSelectedIndex

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim IncomeOnlyForm As AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyForm = Nothing

            IncomeOnlyForm = New AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyForm()

            IncomeOnlyForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub IncomeOnlyForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewLeftSection_View.MultiSelect = False

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemIncomeOnly_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemIncomeOnly_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemIncomeOnly_CopyTo.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemIncomeOnly_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemIncomeOnly_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemIncomeOnly_ClearFilters.Image = AdvantageFramework.My.Resources.ClearImage
            ButtonItemActions_ShowAll.Image = AdvantageFramework.My.Resources.ShowExistingImage
            ButtonItemActions_ShowDescriptions.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemContracts_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemContracts_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemContracts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemServiceFees_Generate.Image = AdvantageFramework.My.Resources.FlagAsServiceFeeImage
            ButtonItemServiceFees_GenerateAll.Image = AdvantageFramework.My.Resources.FlagAsServiceFeeImage
            ButtonItemServiceFees_View.Image = AdvantageFramework.My.Resources.ViewImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ButtonItemActions_ShowDescriptions.Checked = AdvantageFramework.Security.LoadUserSetting(Me.Session, Me.Session.User.ID, Security.UserSettings.ShowDescriptionsInIncomeOnly)

            ComboBoxItemSearch_Search.ComboBoxEx.ValueMember = "Code"
            ComboBoxItemSearch_Search.ComboBoxEx.DisplayMember = "Description"

            ComboBoxItemSearch_Search.ComboBoxEx.DataSource = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(IncomeOnlyViewLayout))
                                                               Select [Code] = CInt(Entity.Code),
                                                                      [Description] = Entity.Description).ToList

            ButtonItemActions_Print.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.PrintAllowed
            ButtonItemActions_Save.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.UpdateAllowed
            ButtonItemIncomeOnly_Copy.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.AddAllowed
            ButtonItemIncomeOnly_CopyFrom.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.AddAllowed
            ButtonItemIncomeOnly_CopyTo.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.AddAllowed
            ButtonItemIncomeOnly_Delete.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.UpdateAllowed

            ButtonItemContracts_Add.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.ServiceFeeContractControl.SecurityAddAllowed
            ButtonItemContracts_Copy.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.ServiceFeeContractControl.SecurityAddAllowed
            ButtonItemContracts_Delete.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.ServiceFeeContractControl.SecurityUpdateAllowed

            ButtonItemServiceFees_Generate.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.AddAllowed
            ButtonItemServiceFees_GenerateAll.SecurityEnabled = IncomeOnlyControlRightSection_IncomeOnly.AddAllowed

            Try

                SwitchView()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub IncomeOnlyForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_View.FocusToFindPanel(True)

        End Sub
        Private Sub IncomeOnlyForm_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            EnableOrDisableActions()

        End Sub
        Private Sub IncomeOnlyForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemIncomeOnly_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemIncomeOnly_Cancel.Click

            IncomeOnlyControlRightSection_IncomeOnly.DetailsDataGridView.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemIncomeOnly_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemIncomeOnly_Delete.Click

            If IncomeOnlyControlRightSection_IncomeOnly.CanDeleteSelectedRows Then

                Try

                    IncomeOnlyControlRightSection_IncomeOnly.Delete()

                Catch ex As Exception

                End Try

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemIncomeOnly_Copy.Click

            'objects
            Dim ErrorMessage As String = ""

            If CheckForUnsavedChanges() Then

                Me.FormAction = WinForm.Presentation.FormActions.Copying

                Try

                    IncomeOnlyControlRightSection_IncomeOnly.Copy()

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemIncomeOnly_CopyFrom_Click(sender As Object, e As EventArgs) Handles ButtonItemIncomeOnly_CopyFrom.Click

            'objects
            Dim ErrorMessage As String = ""

            If CheckForUnsavedChanges() Then

                Me.FormAction = WinForm.Presentation.FormActions.Copying

                Try

                    IncomeOnlyControlRightSection_IncomeOnly.CopyFrom()

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemIncomeOnly_CopyTo_Click(sender As Object, e As EventArgs) Handles ButtonItemIncomeOnly_CopyTo.Click

            'objects
            Dim ErrorMessage As String = ""

            If CheckForUnsavedChanges() Then

                Me.FormAction = WinForm.Presentation.FormActions.Copying

                Try

                    IncomeOnlyControlRightSection_IncomeOnly.CopyTo()

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewLeftSection_View_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_View.DataSourceChangedEvent

            If DataGridViewLeftSection_View.Columns IsNot Nothing AndAlso DataGridViewLeftSection_View.Columns.Count > 0 Then

                Select Case Me.ViewLayout

                    Case IncomeOnlyViewLayout.ByClient

                        DataGridViewLeftSection_View.HideOrShowColumn(AdvantageFramework.Database.Entities.Client.Properties.IsNewBusiness.ToString, False)
                        DataGridViewLeftSection_View.MakeIsInactiveColumnNotVisible()

                    Case IncomeOnlyViewLayout.ByDivision

                        DataGridViewLeftSection_View.MakeIsInactiveColumnNotVisible()

                    Case IncomeOnlyViewLayout.ByProduct

                        DataGridViewLeftSection_View.MakeIsInactiveColumnNotVisible()

                    Case IncomeOnlyViewLayout.ByJob

                        For Each GridColumn In DataGridViewLeftSection_View.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                            GridColumn.Visible = False

                        Next

                        ModifyColumn(AdvantageFramework.Database.Views.JobView.Properties.JobNumber.ToString, True, 1)
                        ModifyColumn(AdvantageFramework.Database.Views.JobView.Properties.JobDescription.ToString, True, 2)
                        ModifyColumn(AdvantageFramework.Database.Views.JobView.Properties.OfficeCode.ToString, True, 3)
                        ModifyColumn(AdvantageFramework.Database.Views.JobView.Properties.OfficeName.ToString, True, 4)
                        ModifyColumn(AdvantageFramework.Database.Views.JobView.Properties.ClientCode.ToString, True, 5)
                        ModifyColumn(AdvantageFramework.Database.Views.JobView.Properties.ClientName.ToString, True, 6)
                        ModifyColumn(AdvantageFramework.Database.Views.JobView.Properties.DivisionCode.ToString, True, 7)
                        ModifyColumn(AdvantageFramework.Database.Views.JobView.Properties.DivisionName.ToString, True, 8)
                        ModifyColumn(AdvantageFramework.Database.Views.JobView.Properties.ProductCode.ToString, True, 9)
                        ModifyColumn(AdvantageFramework.Database.Views.JobView.Properties.ProductDescription.ToString, True, 10)

                    Case IncomeOnlyViewLayout.ByJobComponent



                End Select

            End If

        End Sub
        Private Sub DataGridViewLeftSection_View_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_View.LeavingRowEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_View_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_View.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub IncomeOnlyControlRightSection_IncomeOnly_OpeningContractEvent(ByRef Cancel As Boolean) Handles IncomeOnlyControlRightSection_IncomeOnly.OpeningContractEvent

            Cancel = Not CheckForUnsavedChanges()

        End Sub
        Private Sub IncomeOnlyControlRightSection_IncomeOnly_SelectedRowsChangedEvent() Handles IncomeOnlyControlRightSection_IncomeOnly.SelectedRowsChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            IncomeOnlyControlRightSection_IncomeOnly.PrintBatch()

        End Sub
        Private Sub ComboBoxItemActions_Search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemSearch_Search.SelectedIndexChanged

            RefreshForm(False)

        End Sub
        Private Sub ButtonItemActions_ShowDescriptions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowDescriptions.CheckedChanged

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                IncomeOnlyControlRightSection_IncomeOnly.ShowDescriptions = ButtonItemActions_ShowDescriptions.Checked

            End If

        End Sub
        Private Sub ButtonItemActions_ShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowAll.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If CheckForUnsavedChanges() Then

                    IncomeOnlyControlRightSection_IncomeOnly.ShowExistingIncomeOnlys(ButtonItemActions_ShowAll.Checked)

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_ShowDescriptions_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowDescriptions.EnabledChanged

            If Me.FormShown Then

                If ButtonItemActions_ShowDescriptions.Enabled Then

                    IncomeOnlyControlRightSection_IncomeOnly.ShowDescriptions = ButtonItemActions_ShowDescriptions.Checked

                End If

            End If

        End Sub
        Private Sub ButtonItemSearch_SelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSearch_SelectAll.CheckedChanged

            If Me.FormShown = True AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemSearch_SelectAll.Checked Then

                    If CheckForUnsavedChanges() Then

                        ComboBoxItemSearch_Search.ComboBoxEx.SelectedValue = CInt(IncomeOnlyViewLayout.All)

                    Else

                        Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                        ButtonItemSearch_SelectAll.Checked = False
                        ButtonItemSearch_SelectBy.Checked = True

                        Me.FormAction = WinForm.Presentation.FormActions.None

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemSearch_SelectBy_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSearch_SelectBy.CheckedChanged

            If Me.FormShown = True AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemSearch_SelectBy.Checked Then

                    If CheckForUnsavedChanges() Then

                        ComboBoxItemSearch_Search.ComboBoxEx.SelectedValue = CInt(IncomeOnlyViewLayout.ByClient)

                    Else

                        Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                        ButtonItemSearch_SelectAll.Checked = True
                        ButtonItemSearch_SelectBy.Checked = False

                        Me.FormAction = WinForm.Presentation.FormActions.None

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Refresh.Click

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As Integer? = Nothing
            Dim JobComponentNumber As Integer? = Nothing
            Dim RefreshSelection As Boolean = False

            If Me.ViewLayout <> IncomeOnlyViewLayout.All Then

                LoadViewKeys(ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber)

            End If

            RefreshForm(True)

            If Me.ViewLayout <> IncomeOnlyViewLayout.All Then

                For RowHandle = 0 To DataGridViewLeftSection_View.CurrentView.RowCount - 1

                    Select Case Me.ViewLayout

                        Case IncomeOnlyViewLayout.ByClient

                            If DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Client.Properties.Code.ToString) = ClientCode Then

                                If DataGridViewLeftSection_View.CurrentView.FocusedRowHandle = RowHandle Then

                                    RefreshSelection = True

                                End If

                                DataGridViewLeftSection_View.CurrentView.FocusedRowHandle = RowHandle

                                Exit For

                            End If

                        Case IncomeOnlyViewLayout.ByDivision

                            If DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.DivisionView.Properties.ClientCode.ToString) = ClientCode AndAlso
                                    DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.DivisionView.Properties.DivisionCode.ToString) = DivisionCode Then

                                If DataGridViewLeftSection_View.CurrentView.FocusedRowHandle = RowHandle Then

                                    RefreshSelection = True

                                End If

                                DataGridViewLeftSection_View.CurrentView.FocusedRowHandle = RowHandle

                                Exit For

                            End If

                        Case IncomeOnlyViewLayout.ByProduct

                            If DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ClientCode.ToString) = ClientCode AndAlso
                                    DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.ProductView.Properties.DivisionCode.ToString) = DivisionCode AndAlso
                                    DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ProductCode.ToString) = ProductCode Then

                                If DataGridViewLeftSection_View.CurrentView.FocusedRowHandle = RowHandle Then

                                    RefreshSelection = True

                                End If

                                DataGridViewLeftSection_View.CurrentView.FocusedRowHandle = RowHandle

                                Exit For

                            End If

                        Case IncomeOnlyViewLayout.ByJob

                            If DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobView.Properties.ClientCode.ToString) = ClientCode AndAlso
                                    DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobView.Properties.DivisionCode.ToString) = DivisionCode AndAlso
                                    DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobView.Properties.ProductCode.ToString) = ProductCode AndAlso
                                    CInt(DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobView.Properties.JobNumber.ToString)) = JobNumber.GetValueOrDefault(0) Then

                                If DataGridViewLeftSection_View.CurrentView.FocusedRowHandle = RowHandle Then

                                    RefreshSelection = True

                                End If

                                DataGridViewLeftSection_View.CurrentView.FocusedRowHandle = RowHandle

                                Exit For

                            End If

                        Case IncomeOnlyViewLayout.ByJobComponent

                            If DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.ClientCode.ToString) = ClientCode AndAlso
                                    DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.DivisionCode.ToString) = DivisionCode AndAlso
                                    DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.ProductCode.ToString) = ProductCode AndAlso
                                    CInt(DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.JobNumber.ToString)) = JobNumber.GetValueOrDefault(0) AndAlso
                                    CInt(DataGridViewLeftSection_View.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponent.Properties.JobComponentNumber.ToString)) = JobComponentNumber.GetValueOrDefault(0) Then

                                If DataGridViewLeftSection_View.CurrentView.FocusedRowHandle = RowHandle Then

                                    RefreshSelection = True

                                End If

                                DataGridViewLeftSection_View.CurrentView.FocusedRowHandle = RowHandle

                                Exit For

                            End If

                    End Select

                Next

                If RefreshSelection Then

                    DataGridViewLeftSection_View.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub

#Region " Contracts "

        Private Sub ButtonItemContracts_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Add.Click

            If CheckForUnsavedChanges() Then

                Try

                    If IncomeOnlyControlRightSection_IncomeOnly.AddContract() Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            ReloadJobComponents()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    End If

                Catch ex As Exception

                End Try

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemContracts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Delete.Click

            IncomeOnlyControlRightSection_IncomeOnly.DeleteSelectedContracts()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemServiceFees_Generate_Click(sender As Object, e As EventArgs) Handles ButtonItemServiceFees_Generate.Click

            If CheckForUnsavedChanges() Then

                IncomeOnlyControlRightSection_IncomeOnly.GenerateContractServiceFees()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemServiceFees_GenerateAll_Click(sender As Object, e As EventArgs) Handles ButtonItemServiceFees_GenerateAll.Click

            If CheckForUnsavedChanges() Then

                IncomeOnlyControlRightSection_IncomeOnly.GenerateAllContractServiceFees()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemIncomeOnly_ClearFilters_Click(sender As Object, e As EventArgs) Handles ButtonItemIncomeOnly_ClearFilters.Click

            IncomeOnlyControlRightSection_IncomeOnly.ResetFilters()

            EnableOrDisableActions()

        End Sub
        Private Sub IncomeOnlyControlRightSection_IncomeOnly_SelectedTabChangedEvent() Handles IncomeOnlyControlRightSection_IncomeOnly.SelectedTabChangedEvent

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Copy.Click

            If CheckForUnsavedChanges() Then

                Try

                    If IncomeOnlyControlRightSection_IncomeOnly.CopyContract() Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            ReloadJobComponents()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    End If

                Catch ex As Exception

                End Try

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemServiceFees_View_Click(sender As Object, e As EventArgs) Handles ButtonItemServiceFees_View.Click

            IncomeOnlyControlRightSection_IncomeOnly.ViewContractServiceFees()

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace