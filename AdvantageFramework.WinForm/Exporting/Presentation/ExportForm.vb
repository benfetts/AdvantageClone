Namespace Exporting.Presentation

    Public Class ExportForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ExportType As AdvantageFramework.Exporting.ExportTypes = Nothing
        Private _DataTable As System.Data.DataTable = Nothing
        Private _DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter = Nothing
        Private _ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
        'Private _SelectedRows() As Integer = Nothing
        'Private _UpdatingMultipleRows As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property ExportType As AdvantageFramework.Exporting.ExportTypes
            Get
                ExportType = _ExportType
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ExportType As AdvantageFramework.Exporting.ExportTypes, ByVal AllowExportTypeChange As Boolean, ByVal AllowFilterChange As Boolean, ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ExportType = ExportType
            ComboBoxExportType_ExportType.Enabled = AllowExportTypeChange
            ButtonItemActions_Filter.SecurityEnabled = AllowFilterChange
            ButtonItemActions_Clear.SecurityEnabled = AllowFilterChange
            _DataFilter = DataFilter

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim ExportType As AdvantageFramework.Exporting.ExportTypes = Nothing

            Try

                Try

                    ExportType = ComboBoxExportType_ExportType.GetSelectedValue

                Catch ex As Exception
                    ExportType = Nothing
                End Try

                If ExportType <> Nothing Then

                    If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(Me.Session, ExportType, ComboBoxTemplate_Template.GetSelectedValue, _DataFilter, _DataTable) Then

                        DataGridViewForm_ExportData.CurrentView.BeginUpdate()

                        DataGridViewForm_ExportData.ClearGridCustomization()

                        DataGridViewForm_ExportData.CurrentView.ObjectType = AdvantageFramework.Exporting.LoadClassTypeByExportTemplateType(ExportType, _ExportTemplate)

                        DataGridViewForm_ExportData.DataSource = _DataTable

                        SetCustomColumnSettings()

                        SetCustomViewCaption()

                        DataGridViewForm_ExportData.CurrentView.BestFitColumns()

                        DataGridViewForm_ExportData.CurrentView.EndUpdate()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadExportDefaults(ByVal ExportType As AdvantageFramework.Exporting.ExportTypes)

            Select Case ExportType

                Case AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceDetails

                    Me.Text = "YayPay Invoice Details"
                    RibbonBarOptions_Mappings.Visible = False
                    ButtonItemMappings_GeneralLedger.Visible = False
                    ButtonItemActions_AutoFill.Visible = False

                Case AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations

                    Me.Text = "YayPay Invoice Transaction Allocations"
                    RibbonBarOptions_Mappings.Visible = False
                    ButtonItemMappings_GeneralLedger.Visible = False
                    ButtonItemActions_AutoFill.Visible = False

                Case AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments

                    Me.Text = "YayPay Invoice With Payments"
                    RibbonBarOptions_Mappings.Visible = False
                    ButtonItemMappings_GeneralLedger.Visible = False
                    ButtonItemActions_AutoFill.Visible = False

                Case AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions

                    Me.Text = "YayPay Invoice Transaction"
                    RibbonBarOptions_Mappings.Visible = False
                    ButtonItemMappings_GeneralLedger.Visible = False
                    ButtonItemActions_AutoFill.Visible = False

                Case AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceCustomers

                    Me.Text = "YayPay Invoice Customers"
                    RibbonBarOptions_Mappings.Visible = False
                    ButtonItemMappings_GeneralLedger.Visible = False
                    ButtonItemActions_AutoFill.Visible = False

                Case AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceContacts

                    Me.Text = "YayPay Invoice Contacts"
                    RibbonBarOptions_Mappings.Visible = False
                    ButtonItemMappings_GeneralLedger.Visible = False
                    ButtonItemActions_AutoFill.Visible = False

                Case AdvantageFramework.Exporting.ExportTypes.MediaPlanData

                    Me.Text = "Media Plan Data Export"
                    RibbonBarOptions_Mappings.Visible = False
                    ButtonItemMappings_GeneralLedger.Visible = False

                Case AdvantageFramework.Exporting.ExportTypes.GeneralLedgerDetail

                    Me.Text = "GL Detail Export"
                    RibbonBarOptions_Mappings.Visible = True
                    ButtonItemMappings_GeneralLedger.Visible = True

                Case AdvantageFramework.Exporting.ExportTypes.AccountPayable

                    Me.Text = "Accounts Payable Data Export"
                    RibbonBarOptions_Mappings.Visible = True
                    ButtonItemMappings_GeneralLedger.Visible = True
                    ButtonItemActions_AutoFill.Visible = False

                Case AdvantageFramework.Exporting.ExportTypes.PurchaseOrder

                    Me.Text = "Purchase Order Data Export"
                    RibbonBarOptions_Mappings.Visible = False
                    ButtonItemMappings_GeneralLedger.Visible = False
                    ButtonItemActions_AutoFill.Visible = False

            End Select

        End Sub
        Private Sub LoadExportTypeTemplates()

            'objects
            Dim ExportType As AdvantageFramework.Exporting.ExportTypes = Nothing

            If ComboBoxExportType_ExportType.HasASelectedValue Then

                Try

                    ExportType = ComboBoxExportType_ExportType.GetSelectedValue

                Catch ex As Exception
                    ExportType = Nothing
                End Try

                If ExportType <> Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxTemplate_Template.DataSource = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, CShort(ExportType)).OrderBy(Function(Entity) Entity.Name)

                    End Using

                Else

                    ComboBoxTemplate_Template.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.ExportTemplate)

                End If

            Else

                ComboBoxTemplate_Template.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.ExportTemplate)

            End If

        End Sub
        Private Sub CreateDefaultColumnsForSelectedTemplate()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ComboBoxTemplate_Template.HasASelectedValue Then

                    _ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, ComboBoxTemplate_Template.GetSelectedValue)

                    _DataTable = AdvantageFramework.Exporting.CreateDataTableFromTemplate(DbContext, ComboBoxExportType_ExportType.GetSelectedValue, AdvantageFramework.Database.Procedures.ExportTemplateDetail.LoadByExportTemplateID(DbContext, ComboBoxTemplate_Template.GetSelectedValue).ToList)

                Else

                    _DataTable = AdvantageFramework.Exporting.CreateDataTableFromTemplate(DbContext, ComboBoxExportType_ExportType.GetSelectedValue, Nothing)

                End If

                If _ExportType = ExportTypes.AccountPayable Then

                    _DataFilter = Nothing

                End If

                DataGridViewForm_ExportData.CurrentView.BeginUpdate()

                DataGridViewForm_ExportData.ClearGridCustomization()

                DataGridViewForm_ExportData.CurrentView.ObjectType = AdvantageFramework.Exporting.LoadClassTypeByExportTemplateType(ExportType, _ExportTemplate)

                DataGridViewForm_ExportData.DataSource = _DataTable

                SetCustomViewCaption()

                DataGridViewForm_ExportData.CurrentView.BestFitColumns()

                DataGridViewForm_ExportData.CurrentView.EndUpdate()

            End Using

        End Sub
        Private Sub SetColumnOptions()

            For Each GridColumn In DataGridViewForm_ExportData.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsColumn.AllowGroup = False

            Next

        End Sub
        Private Sub EnableOrDisableActions()

            If _ExportType = ExportTypes.AccountPayable Then

                ButtonItemActions_Filter.Enabled = ComboBoxTemplate_Template.HasASelectedValue
                ButtonItemActions_Preview.Enabled = (_ExportType = ExportTypes.AccountPayable AndAlso ComboBoxTemplate_Template.HasASelectedValue AndAlso _DataFilter IsNot Nothing)
                ButtonItemActions_Export.Enabled = (_ExportType = ExportTypes.AccountPayable AndAlso ComboBoxTemplate_Template.HasASelectedValue AndAlso _DataFilter IsNot Nothing)
                RibbonBarOptions_Mappings.Enabled = (ComboBoxExportType_ExportType.HasASelectedValue AndAlso ComboBoxTemplate_Template.HasASelectedValue AndAlso _DataFilter IsNot Nothing AndAlso DataGridViewForm_ExportData.HasRows)
                ButtonItemActions_Refresh.Enabled = Me.UserEntryChanged

            ElseIf _ExportType = ExportTypes.PurchaseOrder Then

                ButtonItemActions_Filter.Enabled = ComboBoxTemplate_Template.HasASelectedValue
                ButtonItemActions_Preview.Enabled = (_ExportType = ExportTypes.PurchaseOrder AndAlso ComboBoxTemplate_Template.HasASelectedValue AndAlso _DataFilter IsNot Nothing)
                ButtonItemActions_Export.Enabled = (_ExportType = ExportTypes.PurchaseOrder AndAlso ComboBoxTemplate_Template.HasASelectedValue AndAlso _DataFilter IsNot Nothing)
                ButtonItemActions_Refresh.Enabled = Me.UserEntryChanged

            Else

                ButtonItemActions_Preview.Enabled = (ComboBoxExportType_ExportType.HasASelectedValue AndAlso ComboBoxTemplate_Template.SelectedIndex > -1 AndAlso _DataFilter IsNot Nothing)
                ButtonItemActions_Export.Enabled = (ComboBoxExportType_ExportType.HasASelectedValue AndAlso ComboBoxTemplate_Template.SelectedIndex > -1 AndAlso _DataFilter IsNot Nothing)
                ButtonItemActions_AutoFill.Enabled = DataGridViewForm_ExportData.HasASelectedRow
                RibbonBarOptions_Mappings.Enabled = (ComboBoxExportType_ExportType.HasASelectedValue AndAlso ComboBoxTemplate_Template.SelectedIndex > -1 AndAlso _DataFilter IsNot Nothing AndAlso DataGridViewForm_ExportData.HasRows)

            End If

        End Sub
        Private Sub HideAPAnswersOnDemandColumns()

            If DataGridViewForm_ExportData.CurrentView.Columns(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.AccountPayableID.ToString) IsNot Nothing Then

                DataGridViewForm_ExportData.CurrentView.Columns(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.AccountPayableID.ToString).Visible = False

            End If

            If DataGridViewForm_ExportData.CurrentView.Columns(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.ClientCode.ToString) IsNot Nothing Then

                DataGridViewForm_ExportData.CurrentView.Columns(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.ClientCode.ToString).Visible = False

            End If

            If DataGridViewForm_ExportData.CurrentView.Columns(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DivisionCode.ToString) IsNot Nothing Then

                DataGridViewForm_ExportData.CurrentView.Columns(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DivisionCode.ToString).Visible = False

            End If

            If DataGridViewForm_ExportData.CurrentView.Columns(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.ProductCode.ToString) IsNot Nothing Then

                DataGridViewForm_ExportData.CurrentView.Columns(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.ProductCode.ToString).Visible = False

            End If

        End Sub
        Private Sub SetCustomViewCaption()

            If ExportType = ExportTypes.AccountPayable AndAlso _ExportTemplate IsNot Nothing Then

                DataGridViewForm_ExportData.CurrentView.ViewCaption = DataGridViewForm_ExportData.CurrentView.RowCount & " Account Payable Record(s)"

                If _ExportTemplate.Name.ToUpper = AP_GENERIC_1 Then

                    HideAPAnswersOnDemandColumns()

                End If

            ElseIf ExportType = ExportTypes.PurchaseOrder AndAlso _ExportTemplate IsNot Nothing Then

                DataGridViewForm_ExportData.CurrentView.ViewCaption = DataGridViewForm_ExportData.CurrentView.RowCount & " Purchase Order Record(s)"

            End If

        End Sub
        Private Sub SetCustomColumnSettings()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If ExportType = ExportTypes.GeneralLedgerDetail Then

                For Each GridColumn In DataGridViewForm_ExportData.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridColumn.OptionsColumn.AllowEdit = False

                Next

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal ExportType As AdvantageFramework.Exporting.ExportTypes, ByVal AllowExportTypeChange As Boolean, ByVal AllowFilterChange As Boolean, Optional ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter = Nothing)

            'objects
            Dim ExportForm As AdvantageFramework.Exporting.Presentation.ExportForm = Nothing

            ExportForm = New AdvantageFramework.Exporting.Presentation.ExportForm(ExportType, AllowExportTypeChange, AllowFilterChange, DataFilter)

            ExportForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ExportForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Refresh.Enabled = False

        End Sub
        Private Sub ExportForm_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Refresh.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ExportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Filter.Image = AdvantageFramework.My.Resources.FilterImage
            ButtonItemActions_Preview.Image = AdvantageFramework.My.Resources.PrintPreviewImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemActions_Clear.Image = AdvantageFramework.My.Resources.ClearImage
            ButtonItemActions_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage

            ButtonItemManage_Templates.Image = AdvantageFramework.My.Resources.TemplateImage

            ButtonItemMappings_GeneralLedger.Image = AdvantageFramework.My.Resources.GeneralLedgerReplaceImage

            ButtonItemActions_AutoFill.Visible = AdvantageFramework.Exporting.DoesExportTypeHaveAutoFillOption(_ExportType)

            DataGridViewForm_ExportData.AutoFilterLookupColumns = True
            DataGridViewForm_ExportData.ShowSelectDeselectAllButtons = True
            DataGridViewForm_ExportData.OptionsMenu.EnableColumnMenu = True
            DataGridViewForm_ExportData.OptionsView.ShowFooter = True

            ComboBoxExportType_ExportType.SetPropertySettings(AdvantageFramework.Database.Entities.ExportTemplate.Properties.Type)

            ComboBoxExportType_ExportType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Exporting.ExportTypes))
            ComboBoxExportType_ExportType.ByPassUserEntryChanged = True
            ComboBoxExportType_ExportType.DisableMouseWheel = True

            ComboBoxTemplate_Template.ByPassUserEntryChanged = True
            ComboBoxTemplate_Template.DisableMouseWheel = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            If _ExportType <> Nothing Then

                Try

                    ComboBoxExportType_ExportType.SelectedValue = CShort(_ExportType).ToString

                    LoadExportDefaults(_ExportType)

                Catch ex As Exception

                End Try

            End If

            Try

                LoadExportTypeTemplates()

            Catch ex As Exception

            End Try

            Try

                CreateDefaultColumnsForSelectedTemplate()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub ExportForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

            Me.ClearChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_ExportData_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_ExportData.PopupMenuShowingEvent

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each DXMenuItem In e.Menu.Items

                    If DXMenuItem.Tag IsNot Nothing AndAlso DXMenuItem.Tag.GetType Is GetType(DevExpress.XtraGrid.Localization.GridStringId) Then

                        If CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup OrElse
                                CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox Then

                            DXMenuItem.Enabled = False

                        End If

                    End If

                Next

            End If

        End Sub
        'Private Sub DataGridViewForm_ExportData_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ExportData.CellValueChangedEvent

        '    If DataGridViewForm_ExportData.CurrentView.SelectedRowsCount > 1 Then

        '        If _UpdatingMultipleRows = False Then

        '            _UpdatingMultipleRows = True

        '            DataGridViewForm_ExportData.CurrentView.BeginUpdate()

        '            Try

        '                For Each RowHandle As Integer In DataGridViewForm_ExportData.CurrentView.GetSelectedRows

        '                    DataGridViewForm_ExportData.CurrentView.SetRowCellValue(RowHandle, e.Column, e.Value)

        '                Next

        '            Catch ex As Exception

        '            Finally
        '                DataGridViewForm_ExportData.CurrentView.EndUpdate()
        '            End Try

        '            _UpdatingMultipleRows = False

        '        End If

        '    End If

        'End Sub
        'Private Sub DataGridViewForm_ExportData_GridViewMouseDownEvent(sender As Object, e As Windows.Forms.MouseEventArgs) Handles DataGridViewForm_ExportData.GridViewMouseDownEvent

        '    _SelectedRows = DataGridViewForm_ExportData.CurrentView.GetSelectedRows

        'End Sub
        Private Sub DataGridViewForm_ExportData_RowCountChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ExportData.RowCountChangedEvent

            EnableOrDisableActions()

        End Sub
        'Private Sub DataGridViewForm_ExportData_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ExportData.ShownEditorEvent

        '    'objects
        '    Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing

        '    If TypeOf DataGridViewForm_ExportData.CurrentView.ActiveEditor Is DevExpress.XtraEditors.DateEdit AndAlso _
        '            _ExportType = ExportTypes.MediaPlanData Then

        '        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '            Try

        '                MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, DataGridViewForm_ExportData.CurrentView.GetRowCellValue(DataGridViewForm_ExportData.CurrentView.FocusedRowHandle, AdvantageFramework.Exporting.DataClasses.MediaPlanningData.Properties.PlanID.ToString))

        '            Catch ex As Exception
        '                MediaPlan = Nothing
        '            End Try

        '            If MediaPlan IsNot Nothing Then

        '                CType(DataGridViewForm_ExportData.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).Properties.MinValue = MediaPlan.StartDate
        '                CType(DataGridViewForm_ExportData.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).Properties.MaxValue = MediaPlan.EndDate

        '            End If

        '        End Using

        '    End If

        'End Sub
        Private Sub DataGridViewForm_ExportData_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ExportData.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        'Private Sub DataGridViewForm_ExportData_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ExportData.ShownEditorEvent

        '    If DataGridViewForm_ExportData.CurrentView.FocusedColumn.RealColumnEdit IsNot Nothing Then

        '        If _SelectedRows IsNot Nothing Then

        '            For Each RowHandle As Integer In _SelectedRows

        '                DataGridViewForm_ExportData.CurrentView.SelectRow(RowHandle)

        '            Next

        '            _SelectedRows = Nothing

        '        End If

        '    End If

        'End Sub
        Private Sub ComboBoxExportType_ExportType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxExportType_ExportType.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadExportDefaults(ComboBoxExportType_ExportType.SelectedValue)

                LoadExportTypeTemplates()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ComboBoxTemplate_Template_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxTemplate_Template.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    CreateDefaultColumnsForSelectedTemplate()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Preview_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Preview.Click

            'objects
            Dim ExportType As AdvantageFramework.Exporting.ExportTypes = Nothing

            If ComboBoxExportType_ExportType.HasASelectedValue Then

                Try

                    ExportType = ComboBoxExportType_ExportType.GetSelectedValue

                Catch ex As Exception
                    ExportType = Nothing
                End Try

                If ExportType <> Nothing AndAlso _DataFilter IsNot Nothing Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        LoadGrid()

                        Me.ClearChanged()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Filter_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Filter.Click

            'objects
            Dim ExportType As AdvantageFramework.Exporting.ExportTypes = Nothing

            If ComboBoxExportType_ExportType.HasASelectedValue Then

                Try

                    ExportType = ComboBoxExportType_ExportType.GetSelectedValue

                Catch ex As Exception
                    ExportType = Nothing
                End Try

                If ExportType <> Nothing AndAlso _DataFilter Is Nothing Then

                    _DataFilter = AdvantageFramework.Exporting.CreateDataFilterByExportTemplateType(Me.Session, ExportType, _ExportTemplate)

                End If

                If _DataFilter IsNot Nothing Then

                    If AdvantageFramework.Exporting.Presentation.ExportInitialLoadingDialog.ShowFormDialog("Export Data Filter", _DataFilter) = Windows.Forms.DialogResult.Cancel Then

                        _DataFilter = Nothing

                    End If

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim ExportType As AdvantageFramework.Exporting.ExportTypes = Nothing
            Dim Folder As String = ""
            Dim ProcessExportFile As Boolean = False
            Dim ExportFileCreated As Boolean = False
            Dim FullFileName As String = ""
            Dim IsAgencyASP As Boolean = False
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing

            If ComboBoxExportType_ExportType.HasASelectedValue Then

                Try

                    ExportType = ComboBoxExportType_ExportType.GetSelectedValue

                Catch ex As Exception
                    ExportType = Nothing
                End Try

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, ComboBoxTemplate_Template.GetSelectedValue)

                    End Using

                Catch ex As Exception
                    ExportTemplate = Nothing
                End Try

                If ExportType <> Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                        If IsAgencyASP Then

                            Folder = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                        End If

                    End Using

                    If IsAgencyASP Then

                        Folder = Folder.Trim

                        If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder.Trim, "\")) Then

                            Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder.Trim, "\") & "Reports\"

                            If My.Computer.FileSystem.DirectoryExists(Folder) = False Then

                                My.Computer.FileSystem.CreateDirectory(Folder)

                            End If

                            ProcessExportFile = My.Computer.FileSystem.DirectoryExists(Folder)

                        Else

                            ProcessExportFile = False

                        End If

                    Else

                        If ExportTemplate IsNot Nothing AndAlso My.Computer.FileSystem.DirectoryExists(ExportTemplate.DefaultDirectory) Then

                            Folder = ExportTemplate.DefaultDirectory
                            ProcessExportFile = True

                        Else

                            ProcessExportFile = AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder)

                        End If

                    End If

                    If ProcessExportFile Then

                        Me.FormAction = WinForm.Presentation.FormActions.Adding
                        Me.ShowWaitForm("Creating Export File...")

                        Try

                            If _DataTable IsNot Nothing Then

                                DataTable = _DataTable.Clone

                                For Each DataRow In DataGridViewForm_ExportData.GetAllRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                                    DataTable.ImportRow(DataRow)

                                Next

                            End If

                            ExportFileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(Me.Session, ExportType, ComboBoxTemplate_Template.GetSelectedValue, Folder, _DataFilter, DataTable, FullFileName)

                        Catch ex As Exception
                            ExportFileCreated = False
                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If ExportFileCreated Then

                            If IsAgencyASP Then

                                If AdvantageFramework.WinForm.Presentation.SendASPReportDownloadEmail(Session, FullFileName) Then

                                    AdvantageFramework.WinForm.MessageBox.Show("Export file email link has been sent to your email.")

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Export file created successfully!")

                                End If

                            Else

                                If AdvantageFramework.WinForm.MessageBox.Show("Export file created successfully. " & vbNewLine & vbNewLine & "Do you want to open this file now?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    System.Diagnostics.Process.Start(FullFileName)

                                End If

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Failed creating export file.")

                        End If

                    End If

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                LoadGrid()

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemManage_Templates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemManage_Templates.Click

            'objects
            Dim ExportType As AdvantageFramework.Exporting.ExportTypes = Nothing
            Dim ExportTemplateID As Short = 0
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            Try

                ExportType = ComboBoxExportType_ExportType.GetSelectedValue

            Catch ex As Exception
                ExportType = Nothing
            End Try

            If ExportType <> Nothing Then

                ParameterDictionary = New Generic.Dictionary(Of String, Object)

                ParameterDictionary("ExportType") = ExportType

                AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ExportTemplate, False, False, ParameterDictionary:=ParameterDictionary)

                If ComboBoxTemplate_Template.HasASelectedValue Then

                    Try

                        ExportTemplateID = ComboBoxTemplate_Template.GetSelectedValue

                    Catch ex As Exception
                        ExportTemplateID = 0
                    End Try

                End If

                LoadExportTypeTemplates()

                If ExportTemplateID <> 0 Then

                    Try

                        ComboBoxTemplate_Template.SelectedValue = ExportTemplateID

                    Catch ex As Exception
                        ComboBoxTemplate_Template.SelectedIndex = 0
                    End Try

                End If

                If ComboBoxTemplate_Template.SelectedIndex = -1 Then

                    ComboBoxTemplate_Template.SelectedIndex = 0

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Clear_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Clear.Click

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                CreateDefaultColumnsForSelectedTemplate()

                _DataFilter = Nothing

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_AutoFill_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AutoFill.Click

            'objects
            Dim ExportDataSourceRows As Generic.List(Of System.Data.DataRow) = Nothing
            Dim ExportItem As AdvantageFramework.Exporting.Interfaces.IExportData = Nothing
            Dim ExportItems As IEnumerable(Of AdvantageFramework.Exporting.Interfaces.IExportData) = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim ExportItemValue As Object = Nothing
            Dim CurrentExportItemValue As Object = Nothing
            Dim HasChanged As Boolean = False

            ExportDataSourceRows = DataGridViewForm_ExportData.GetAllSelectedRowsDataBoundItems().OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

            ExportItems = AdvantageFramework.Exporting.ConvertExportDataSourceToIEnumerable(Of AdvantageFramework.Exporting.Interfaces.IExportData)(_ExportType, ExportDataSourceRows.ToArray)

            If AdvantageFramework.Exporting.Presentation.ExportAutoFillDialog.ShowFormDialog(ExportItems) = Windows.Forms.DialogResult.OK Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying
                Me.ShowWaitForm("Filling...")

                Try

                    For Each DataRow In ExportDataSourceRows

                        ExportItem = Nothing

                        Try

                            ExportItem = ExportItems(ExportDataSourceRows.IndexOf(DataRow))

                        Catch ex As Exception
                            ExportItem = Nothing
                        End Try

                        If ExportItem IsNot Nothing Then

                            For Each DataColumn In _DataTable.Columns.OfType(Of System.Data.DataColumn)()

                                ExportItemValue = Nothing
                                PropertyDescriptor = Nothing

                                Try

                                    PropertyDescriptor = DataColumn.ExtendedProperties(DataColumnExtendedProperties.PropertyDescriptor.ToString)

                                Catch ex As Exception
                                    PropertyDescriptor = Nothing
                                End Try

                                If PropertyDescriptor IsNot Nothing Then

                                    If PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Any(Function(EA) EA.IsReadOnlyColumn = False) Then

                                        Try

                                            ExportItemValue = PropertyDescriptor.GetValue(ExportItem)

                                        Catch ex As Exception
                                            ExportItemValue = Nothing
                                        End Try

                                        If HasChanged = False Then

                                            Try

                                                CurrentExportItemValue = DataGridViewForm_ExportData.CurrentView.GetRowCellValue(_DataTable.Rows.IndexOf(DataRow), DataColumn.ColumnName)

                                            Catch ex As Exception
                                                CurrentExportItemValue = Nothing
                                            End Try

                                            If ExportItemValue <> CurrentExportItemValue Then

                                                HasChanged = True

                                            End If

                                        End If

                                        DataGridViewForm_ExportData.CurrentView.SetRowCellValue(_DataTable.Rows.IndexOf(DataRow), DataColumn.ColumnName, ExportItemValue)

                                    End If

                                End If

                            Next

                        End If

                    Next

                    DataGridViewForm_ExportData.CurrentView.RefreshData()

                    If HasChanged Then

                        DataGridViewForm_ExportData.SetUserEntryChanged()

                    End If

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemMappings_GeneralLedger_Click(sender As Object, e As EventArgs) Handles ButtonItemMappings_GeneralLedger.Click

            'objects
            Dim RecordSourceID As Integer = 0
            Dim GeneralLedgerCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerCrossReference) = Nothing
            Dim DistinctGLACodes As Generic.List(Of String) = Nothing
            Dim DataRows As Generic.List(Of System.Data.DataRow) = Nothing

            If AdvantageFramework.Exporting.Presentation.ExportMappingRecordTypeSelectDialog.ShowFormDialog(ExportMappingRecordTypeSelectDialog.MappingTypes.GeneralLedger, RecordSourceID) = Windows.Forms.DialogResult.OK Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying
                Me.ShowWaitForm("Replacing...")

                DataGridViewForm_ExportData.CurrentView.BeginUpdate()

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        GeneralLedgerCrossReferences = AdvantageFramework.Database.Procedures.GeneralLedgerCrossReference.LoadByRecordSourceID(DbContext, RecordSourceID).ToList

                        DataRows = DataGridViewForm_ExportData.GetAllRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(DRV) DRV.Row).ToList

                        Select Case _ExportType

                            Case AdvantageFramework.Exporting.ExportTypes.GeneralLedgerDetail

                                DistinctGLACodes = DataRows.Select(Function(DR) CStr(DR(AdvantageFramework.Exporting.DataClasses.GeneralLedgerDetail.Properties.AccountCode.ToString))).Distinct.ToList

                                For Each GeneralLedgerCrossReference In GeneralLedgerCrossReferences.Where(Function(Entity) DistinctGLACodes.Contains(Entity.GLACode)).ToList

                                    For Each DataRow In DataRows.Where(Function(DR) DR(AdvantageFramework.Exporting.DataClasses.GeneralLedgerDetail.Properties.AccountCode.ToString) = GeneralLedgerCrossReference.GLACode).ToList

                                        DataRow(AdvantageFramework.Exporting.DataClasses.GeneralLedgerDetail.Properties.AccountCode.ToString) = GeneralLedgerCrossReference.SourceGLACode

                                    Next

                                Next

                            Case AdvantageFramework.Exporting.ExportTypes.AccountPayable

                                If _ExportTemplate IsNot Nothing AndAlso _ExportTemplate.Name.ToUpper = AP_GENERIC_1 Then

                                    DistinctGLACodes = DataRows.Select(Function(DR) CStr(DR(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DistributedGLAccount.ToString))).Distinct.ToList

                                    'OrderByDescending ClientCode to ensure choosing the XREF where CDP match first
                                    For Each GeneralLedgerCrossReference In GeneralLedgerCrossReferences.Where(Function(Entity) DistinctGLACodes.Contains(Entity.GLACode)).OrderByDescending(Function(GLCR) GLCR.ClientCode).ToList

                                        For Each DataRow In DataRows.Where(Function(DR) DR(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DistributedGLAccount.ToString) = GeneralLedgerCrossReference.GLACode).ToList

                                            If IsDBNull(DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.ClientCode.ToString)) = False AndAlso
                                                    IsDBNull(DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DivisionCode.ToString)) = False AndAlso
                                                    IsDBNull(DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.ProductCode.ToString)) = False AndAlso
                                                    GeneralLedgerCrossReference.ClientCode IsNot Nothing AndAlso
                                                    GeneralLedgerCrossReference.DivisionCode IsNot Nothing AndAlso
                                                    GeneralLedgerCrossReference.ProductCode IsNot Nothing Then

                                                If GeneralLedgerCrossReference.ClientCode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.ClientCode.ToString) AndAlso
                                                        GeneralLedgerCrossReference.DivisionCode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DivisionCode.ToString) AndAlso
                                                        GeneralLedgerCrossReference.ProductCode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.ProductCode.ToString) AndAlso
                                                        GeneralLedgerCrossReference.GLACode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DistributedGLAccount.ToString) Then

                                                    DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DistributedGLAccount.ToString) = GeneralLedgerCrossReference.SourceGLACode

                                                    DataGridViewForm_ExportData.SetUserEntryChanged()

                                                End If

                                            ElseIf GeneralLedgerCrossReference.GLACode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DistributedGLAccount.ToString) Then

                                                DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DistributedGLAccount.ToString) = GeneralLedgerCrossReference.SourceGLACode

                                                DataGridViewForm_ExportData.SetUserEntryChanged()

                                            End If

                                        Next

                                    Next

                                ElseIf _ExportTemplate IsNot Nothing Then

                                    DistinctGLACodes = DataRows.Select(Function(DR) CStr(DR(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.GLACode.ToString))).Distinct.ToList

                                    For Each GeneralLedgerCrossReference In GeneralLedgerCrossReferences.Where(Function(Entity) DistinctGLACodes.Contains(Entity.GLACode)).ToList

                                        For Each DataRow In DataRows.Where(Function(DR) DR(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.GLACode.ToString) = GeneralLedgerCrossReference.GLACode).ToList

                                            DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.GLACode.ToString) = GeneralLedgerCrossReference.SourceGLACode

                                            DataGridViewForm_ExportData.SetUserEntryChanged()

                                        Next

                                    Next

                                    DistinctGLACodes = (From DR In DataRows
                                                        Where IsDBNull(DR(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACode.ToString)) = False
                                                        Select CStr(DR(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACode.ToString))).Distinct.ToList

                                    'OrderByDescending ClientCode to ensure choosing the XREF where CDP match first
                                    For Each GeneralLedgerCrossReference In GeneralLedgerCrossReferences.Where(Function(Entity) DistinctGLACodes.Contains(Entity.GLACode)).OrderByDescending(Function(GLCR) GLCR.ClientCode).ToList

                                        For Each DataRow In DataRows.Where(Function(DR) IsDBNull(DR(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACode.ToString)) = False AndAlso DR(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACode.ToString) = GeneralLedgerCrossReference.GLACode).ToList

                                            If IsDBNull(DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailClientCode.ToString)) = False AndAlso
                                                    IsDBNull(DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailDivisionCode.ToString)) = False AndAlso
                                                    IsDBNull(DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailProductCode.ToString)) = False AndAlso
                                                    GeneralLedgerCrossReference.ClientCode IsNot Nothing AndAlso
                                                    GeneralLedgerCrossReference.DivisionCode IsNot Nothing AndAlso
                                                    GeneralLedgerCrossReference.ProductCode IsNot Nothing Then

                                                If GeneralLedgerCrossReference.ClientCode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailClientCode.ToString) AndAlso
                                                        GeneralLedgerCrossReference.DivisionCode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailDivisionCode.ToString) AndAlso
                                                        GeneralLedgerCrossReference.ProductCode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailProductCode.ToString) AndAlso
                                                        GeneralLedgerCrossReference.GLACode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACode.ToString) Then

                                                    DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACode.ToString) = GeneralLedgerCrossReference.SourceGLACode

                                                    DataGridViewForm_ExportData.SetUserEntryChanged()

                                                End If

                                            ElseIf GeneralLedgerCrossReference.GLACode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACode.ToString) Then

                                                DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACode.ToString) = GeneralLedgerCrossReference.SourceGLACode

                                                DataGridViewForm_ExportData.SetUserEntryChanged()

                                            End If

                                        Next

                                    Next

                                    DistinctGLACodes = (From DR In DataRows
                                                        Where IsDBNull(DR(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACodeBilling.ToString)) = False
                                                        Select CStr(DR(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACodeBilling.ToString))).Distinct.ToList

                                    'OrderByDescending ClientCode to ensure choosing the XREF where CDP match first
                                    For Each GeneralLedgerCrossReference In GeneralLedgerCrossReferences.Where(Function(Entity) DistinctGLACodes.Contains(Entity.GLACode)).OrderByDescending(Function(GLCR) GLCR.ClientCode).ToList

                                        For Each DataRow In DataRows.Where(Function(DR) IsDBNull(DR(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACodeBilling.ToString)) = False AndAlso DR(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACodeBilling.ToString) = GeneralLedgerCrossReference.GLACode).ToList

                                            If IsDBNull(DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailClientCode.ToString)) = False AndAlso
                                                    IsDBNull(DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailDivisionCode.ToString)) = False AndAlso
                                                    IsDBNull(DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailProductCode.ToString)) = False AndAlso
                                                    GeneralLedgerCrossReference.ClientCode IsNot Nothing AndAlso
                                                    GeneralLedgerCrossReference.DivisionCode IsNot Nothing AndAlso
                                                    GeneralLedgerCrossReference.ProductCode IsNot Nothing Then

                                                If GeneralLedgerCrossReference.ClientCode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailClientCode.ToString) AndAlso
                                                        GeneralLedgerCrossReference.DivisionCode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailDivisionCode.ToString) AndAlso
                                                        GeneralLedgerCrossReference.ProductCode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailProductCode.ToString) AndAlso
                                                        GeneralLedgerCrossReference.GLACode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACodeBilling.ToString) Then

                                                    DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACodeBilling.ToString) = GeneralLedgerCrossReference.SourceGLACode

                                                    DataGridViewForm_ExportData.SetUserEntryChanged()

                                                End If

                                            ElseIf GeneralLedgerCrossReference.GLACode = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACodeBilling.ToString) Then

                                                DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayable.Properties.DetailGLACodeBilling.ToString) = GeneralLedgerCrossReference.SourceGLACode

                                                DataGridViewForm_ExportData.SetUserEntryChanged()

                                            End If

                                        Next

                                    Next

                                End If

                                EnableOrDisableActions()

                        End Select

                        DataGridViewForm_ExportData.CurrentView.RefreshData()

                    End Using

                Catch ex As Exception

                End Try

                DataGridViewForm_ExportData.CurrentView.EndUpdate()

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_ExportData_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_ExportData.ShowingEditorEvent

            e.Cancel = True

        End Sub

#End Region

#End Region

    End Class

End Namespace
