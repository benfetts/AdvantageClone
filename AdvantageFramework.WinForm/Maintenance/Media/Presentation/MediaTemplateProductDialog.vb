Namespace Maintenance.Media.Presentation

    Public Class MediaTemplateProductDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.Media.MediaPlanEstimateTemplateController = Nothing
        Private _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel = Nothing
        Private _TemplateLevel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(TemplateLevel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _TemplateLevel = TemplateLevel

        End Sub
        Private Sub RefreshViewModel()

            If _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate Then

                DataGridViewRightSection_ProductTemplates.DataSource = Nothing
                DataGridViewRightSection_ProductTemplates.DataSource = _ViewModel.ProductPlanEstimateTemplates

                If DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product.Properties.ClientName.ToString) IsNot Nothing Then

                    DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product.Properties.ClientName.ToString).Visible = False

                End If

                If DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product.Properties.DivisionName.ToString) IsNot Nothing Then

                    DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product.Properties.DivisionName.ToString).Visible = False

                End If

                If DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product.Properties.ProductName.ToString) IsNot Nothing Then

                    DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product.Properties.ProductName.ToString).Visible = False

                End If

                DataGridViewRightSection_ProductTemplates.CurrentView.BestFitColumns()

            ElseIf _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan Then

                DataGridViewRightSection_ProductTemplates.DataSource = Nothing
                DataGridViewRightSection_ProductTemplates.DataSource = _ViewModel.ProductPlanTemplates

                If DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product.Properties.ClientName.ToString) IsNot Nothing Then

                    DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product.Properties.ClientName.ToString).Visible = False

                End If

                If DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product.Properties.DivisionName.ToString) IsNot Nothing Then

                    DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product.Properties.DivisionName.ToString).Visible = False

                End If

                If DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product.Properties.ProductName.ToString) IsNot Nothing Then

                    DataGridViewRightSection_ProductTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product.Properties.ProductName.ToString).Visible = False

                End If

                DataGridViewRightSection_ProductTemplates.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub SaveViewModel()

            If _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate Then

                _ViewModel.SelectedPlanEstimateTemplates = DataGridViewMiddleSection_Templates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate).ToList
                _ViewModel.SelectedProductPlanEstimateTemplates = DataGridViewRightSection_ProductTemplates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product).ToList

            ElseIf _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan Then

                _ViewModel.SelectedPlanTemplates = DataGridViewMiddleSection_Templates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate).ToList
                _ViewModel.SelectedProductPlanTemplates = DataGridViewRightSection_ProductTemplates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product).ToList

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(TemplateLevel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTemplateProductDialog As AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateProductDialog = Nothing

            MediaTemplateProductDialog = New AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateProductDialog(TemplateLevel)

            ShowFormDialog = MediaTemplateProductDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTemplateProductDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewLeftSection_Products.OptionsBehavior.Editable = False
            DataGridViewLeftSection_Products.MultiSelect = True
            DataGridViewLeftSection_Products.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            DataGridViewMiddleSection_Templates.OptionsBehavior.Editable = False
            DataGridViewMiddleSection_Templates.MultiSelect = True

            DataGridViewRightSection_ProductTemplates.MultiSelect = True

        End Sub
        Private Sub MediaTemplateProductDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            _Controller = New Controller.Maintenance.Media.MediaPlanEstimateTemplateController(Me.Session)

            _ViewModel = _Controller.ProductTemplate_Load(_TemplateLevel)

            Me.Text = _ViewModel.FormCaption

            DataGridViewLeftSection_Products.DataSource = _ViewModel.Products
            DataGridViewLeftSection_Products.CurrentView.BestFitColumns()

            If _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate Then

                DataGridViewMiddleSection_Templates.DataSource = Nothing
                DataGridViewMiddleSection_Templates.DataSource = _ViewModel.PlanEstimateTemplates
                DataGridViewMiddleSection_Templates.CurrentView.BestFitColumns()

                If DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Type.ToString) IsNot Nothing Then

                    DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Type.ToString).Visible = False

                End If

                If DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Goals.ToString) IsNot Nothing Then

                    DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Goals.ToString).Visible = False

                End If

                If DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.IsInactive.ToString) IsNot Nothing Then

                    DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.IsInactive.ToString).Visible = False

                End If

                If DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.IsSystem.ToString) IsNot Nothing Then

                    DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.IsSystem.ToString).Visible = False

                End If

                If DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.MediaTypeDescription.ToString) IsNot Nothing Then

                    DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.MediaTypeDescription.ToString).Visible = True
                    DataGridViewMiddleSection_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.MediaTypeDescription.ToString).VisibleIndex = 0

                End If

            ElseIf _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan Then

                DataGridViewMiddleSection_Templates.DataSource = Nothing
                DataGridViewMiddleSection_Templates.DataSource = _ViewModel.PlanTemplates
                DataGridViewMiddleSection_Templates.CurrentView.BestFitColumns()

            End If

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonRightSection_AddTemplate_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_AddTemplate.Click

            SaveViewModel()

            _Controller.ClientTemplate_AddSelectedTemplate(_ViewModel)

            RefreshViewModel()

        End Sub
        Private Sub ButtonRightSection_RemoveTemplate_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_RemoveTemplate.Click

            SaveViewModel()

            _Controller.ClientTemplate_RemoveSelectedTemplate(_ViewModel)

            RefreshViewModel()

        End Sub
        Private Sub DataGridViewRightSection_ProductTemplates_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_ProductTemplates.CellValueChangingEvent

            If _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate AndAlso e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product.Properties.IsDefault.ToString Then

                If _Controller.ProductTemplate_SetDefaultProductPlanEstimateTemplate(DirectCast(DataGridViewRightSection_ProductTemplates.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product), e.Value, _ViewModel) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Default has already been set for this Client/Division/Product and Media Type.")

                    RefreshViewModel()

                End If

            ElseIf _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan AndAlso e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product.Properties.IsDefault.ToString Then

                If _Controller.ProductTemplate_SetDefaultProductPlanTemplate(DirectCast(DataGridViewRightSection_ProductTemplates.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product), e.Value, _ViewModel) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Default has already been set for this Client/Division/Product.")

                    RefreshViewModel()

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_ProductTemplates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_ProductTemplates.SelectionChangedEvent

            'objects
            Dim PlanEstimateTemplateProducts As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product) = Nothing
            Dim PlanTemplateProducts As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product) = Nothing

            If _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate Then

                PlanEstimateTemplateProducts = DataGridViewRightSection_ProductTemplates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product).ToList

                RibbonBarOptions_Default.Enabled = PlanEstimateTemplateProducts.Select(Function(P) P.MediaPlanEstimateTemplateID).Distinct.Count = 1

            ElseIf _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan Then

                PlanTemplateProducts = DataGridViewRightSection_ProductTemplates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product).ToList

                RibbonBarOptions_Default.Enabled = PlanTemplateProducts.Select(Function(P) P.MediaPlanTemplateHeaderID).Distinct.Count = 1

            End If

        End Sub
        Private Sub DataGridViewRightSection_ProductTemplates_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewRightSection_ProductTemplates.ShowingEditorEvent

            If _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan AndAlso DataGridViewRightSection_ProductTemplates.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product.Properties.IsDefault.ToString Then

                e.Cancel = True

            ElseIf _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate AndAlso DataGridViewRightSection_ProductTemplates.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product.Properties.IsDefault.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Products_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_Products.SelectionChangedEvent

            If DataGridViewLeftSection_Products.HasASelectedRow Then

                _ViewModel.SelectedProducts = DataGridViewLeftSection_Products.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Product).ToList

                _Controller.ProductTemplate_LoadTemplates(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemDefault_CheckAll_Click(sender As Object, e As EventArgs) Handles ButtonItemDefault_CheckAll.Click

            CheckDefault(True)

        End Sub
        Private Sub ButtonItemDefault_UncheckAll_Click(sender As Object, e As EventArgs) Handles ButtonItemDefault_UncheckAll.Click

            CheckDefault(False)

        End Sub
        Private Sub CheckDefault(Checked As Boolean)

            'objects
            Dim PlanEstimateTemplateProducts As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product) = Nothing
            Dim PlanTemplateProducts As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product) = Nothing

            If _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate Then

                PlanEstimateTemplateProducts = DataGridViewRightSection_ProductTemplates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product).ToList

                If _Controller.ProductTemplate_SetDefaultProductPlanEstimateTemplate(PlanEstimateTemplateProducts, Checked) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("One or more defaults could not be set because a default is already established for the selection.")

                End If

                DataGridViewRightSection_ProductTemplates.CurrentView.RefreshData()

            ElseIf _ViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan Then

                PlanTemplateProducts = DataGridViewRightSection_ProductTemplates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product).ToList

                If _Controller.ProductTemplate_SetDefaultProductPlanTemplate(PlanTemplateProducts, Checked) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("One or more defaults could not be set because a default is already established for the selection.")

                End If

                DataGridViewRightSection_ProductTemplates.CurrentView.RefreshData()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
