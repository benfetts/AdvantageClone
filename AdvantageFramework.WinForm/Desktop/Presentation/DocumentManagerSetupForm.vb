Namespace Desktop.Presentation

    Public Class DocumentManagerSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SelectedLevel As Database.Entities.DocumentLevel = -1

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadSelectedDocumentLevel()

            'objects
            Dim DataSource As Object = Nothing
            Dim AFActiveFilterString As String = Nothing
            Dim DataSourceViewOption As AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions = WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.Default
            Dim ItemDescription As String = ""
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing
            Dim ClientCodes() As String = Nothing
            Dim CampaignIDs() As Integer = Nothing
            Dim JobNumbers() As Integer = Nothing
            Dim ExpenseReportInvoiceNumbers() As Integer = Nothing
            Dim EmployeeCodes() As String = Nothing
            Dim VendorCodes() As String = Nothing
            Dim ShowItemsWithDocuments As Boolean = False
            Dim ShowItemsWithoutDocuments As Boolean = False
            Dim ShowItemsOptions As Boolean() = Nothing
			Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Core.JobComponent) = Nothing
			Dim OrderNumbers() As Integer = Nothing

			If ComboBoxDocumentLevel_DocumentLevel.HasASelectedValue Then

                DataGridViewLeftSection_DocumentLevel.CurrentView.MRUFilters.Clear()
                DataGridViewLeftSection_DocumentLevel.ClearGridCustomization()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Select Case _SelectedLevel

                                Case Database.Entities.DocumentLevel.Office

                                    AFActiveFilterString = "[IsInactive] = False"

                                Case Database.Entities.DocumentLevel.Client

                                    AFActiveFilterString = "[IsInactive] = False"

                                Case Database.Entities.DocumentLevel.Division

                                    AFActiveFilterString = "[IsInactive] = False"
                                    ItemDescription = "Division(s)"

                                Case Database.Entities.DocumentLevel.Product

                                    AFActiveFilterString = "[IsInactive] = False"
                                    ItemDescription = "Product(s)"

                                Case Database.Entities.DocumentLevel.Campaign

                                    AFActiveFilterString = "[IsClosed] = False"
                                    ItemDescription = "Campaign(s)"

                                Case Database.Entities.DocumentLevel.Job

                                    ItemDescription = "Job(s)"
                                    AFActiveFilterString = "[IsOpen] = True"

                                Case Database.Entities.DocumentLevel.JobComponent

                                    ItemDescription = "Job Component(s)"
                                    AFActiveFilterString = "[IsOpen] = True"

                                Case Database.Entities.DocumentLevel.AccountPayableInvoice

                                    ItemDescription = "Account Payable(s)"

                                Case Database.Entities.DocumentLevel.AdNumber

                                    AFActiveFilterString = "[IsInactive] = True" ' IsInactive column is actually "Active" in database!!!

                                Case Database.Entities.DocumentLevel.ExpenseReceipts

                                    AFActiveFilterString = ""

                                Case Database.Entities.DocumentLevel.Employee

                                    DataSourceViewOption = WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.Employee_WithTerminatedColumn
                                    AFActiveFilterString = "[Terminated] = False"

                                Case Database.Entities.DocumentLevel.Vendor

                                    AFActiveFilterString = "[IsInactive] = False"

                                Case Database.Entities.DocumentLevel.AccountReceivableInvoice

                                    ItemDescription = "Account Receivable(s)"

								Case Database.Entities.DocumentLevel.MediaOrder

									ItemDescription = "Media Order(s)"
									AFActiveFilterString = ""

							End Select

                            If ButtonItemSearchFilter_ItemsWithDocuments.Checked Then

                                ShowItemsOptions = {True}
                                ShowItemsWithDocuments = True

                            ElseIf ButtonItemSearchFilter_ItemsWithoutDocuments.Checked Then

                                ShowItemsOptions = {False}
                                ShowItemsWithoutDocuments = True

                            Else

                                ShowItemsOptions = {True, False}
                                ShowItemsWithDocuments = True
                                ShowItemsWithoutDocuments = True

                            End If

                            Select Case _SelectedLevel

                                Case Database.Entities.DocumentLevel.Office

                                    DataSource = AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, Me.Session).ToList.Where(Function(Entity) ShowItemsOptions.Contains(Entity.OfficeDocuments.Any))

                                Case Database.Entities.DocumentLevel.Client

                                    ClientCodes = AdvantageFramework.Database.Procedures.ClientDocument.Load(DataContext).Select(Function(Entity) Entity.ClientCode).Distinct.ToArray

                                    DataSource = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList.Where(Function(Entity) ShowItemsOptions.Contains(ClientCodes.Contains(Entity.Code)))

                                Case Database.Entities.DocumentLevel.Division

                                    DocumentLevelSettings = AdvantageFramework.Database.Procedures.DivisionDocument.Load(DataContext).Select(Function(Entity) New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Division) With {.ClientCode = Entity.ClientCode,
                                                                                                                                                                                                                                                                                                  .DivisionCode = Entity.DivisionCode}).ToList

                                    DataSource = AdvantageFramework.Database.Procedures.DivisionView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList.Where(Function(Entity) ShowItemsOptions.Contains(DocumentLevelSettings.Any(Function(DLS) DLS.ClientCode = Entity.ClientCode AndAlso DLS.DivisionCode = Entity.DivisionCode)))

                                Case Database.Entities.DocumentLevel.Product

                                    DocumentLevelSettings = AdvantageFramework.Database.Procedures.ProductDocument.Load(DataContext).Select(Function(Entity) New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Product) With {.ClientCode = Entity.ClientCode,
                                                                                                                                                                                                                                                                                                .DivisionCode = Entity.DivisionCode,
                                                                                                                                                                                                                                                                                                .ProductCode = Entity.ProductCode}).ToList

                                    DataSource = AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList.Where(Function(Entity) ShowItemsOptions.Contains(DocumentLevelSettings.Any(Function(DLS) DLS.ClientCode = Entity.ClientCode AndAlso DLS.DivisionCode = Entity.DivisionCode AndAlso DLS.ProductCode = Entity.ProductCode)))

                                Case Database.Entities.DocumentLevel.Campaign

                                    CampaignIDs = AdvantageFramework.Database.Procedures.CampaignDocument.Load(DataContext).Select(Function(Entity) CInt(Entity.CampaignID.GetValueOrDefault(0))).Distinct.ToArray

                                    DataSource = AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, Me.Session.UserCode).OrderBy(Function(Campaign) Campaign.CampaignCode).ToList.Where(Function(Entity) ShowItemsOptions.Contains(CampaignIDs.Contains(Entity.ID)))

                                Case Database.Entities.DocumentLevel.Job

                                    JobNumbers = DbContext.Database.SqlQuery(Of Integer)("SELECT DISTINCT JOB_NUMBER FROM dbo.WV_CURRENT_JOB_DOCUMENTS WHERE JOB_NUMBER IS NOT NULL").ToArray

                                    DataSource = AdvantageFramework.Database.Procedures.JobView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, Me.Session.UserCode).ToList.Where(Function(Job) ShowItemsOptions.Contains(JobNumbers.Contains(Job.JobNumber)))

                                Case Database.Entities.DocumentLevel.JobComponent

                                    JobComponents = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Core.JobComponent)("SELECT DISTINCT [JobNumber] = JOB_NUMBER, [Number] = JOB_COMPONENT_NUMBER FROM dbo.WV_CURRENT_JOB_COMPONENT_DOCUMENTS WHERE JOB_NUMBER IS NOT NULL AND JOB_COMPONENT_NUMBER IS NOT NULL").ToList

                                    DocumentLevelSettings = JobComponents.Select(Function(Entity) New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = CStr(Entity.JobNumber),
                                                                                                                                                                                                                                      .JobComponentNumber = CStr(Entity.Number)}).ToList

                                    DataSource = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, Me.Session.UserCode).ToList.Where(Function(Entity) ShowItemsOptions.Contains(DocumentLevelSettings.Any(Function(DLS) DLS.JobNumber = CStr(Entity.JobNumber) AndAlso DLS.JobComponentNumber = CStr(Entity.JobComponentNumber))))

                                Case Database.Entities.DocumentLevel.AccountPayableInvoice

                                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.AccountPayableInvoice)(String.Format("EXEC advsp_document_manager_load_ap_invoices '{0}', {1}, {2}", DbContext.UserCode, If(ShowItemsWithDocuments, 1, 0), If(ShowItemsWithoutDocuments, 1, 0))).ToList

                                Case Database.Entities.DocumentLevel.AdNumber

                                    DataSource = AdvantageFramework.Database.Procedures.Ad.LoadWithOfficeLimits(DbContext, Me.Session).Include("Client").ToList.Where(Function(Entity) ShowItemsOptions.Contains(Entity.DocumentID IsNot Nothing)).ToList

                                Case Database.Entities.DocumentLevel.ExpenseReceipts

                                    ExpenseReportInvoiceNumbers = AdvantageFramework.Database.Procedures.ExpenseReportDocument.Load(DbContext).Select(Function(Entity) Entity.InvoiceNumber).Distinct.ToArray

                                    Try

                                        DataSource = AdvantageFramework.Database.Procedures.ExpenseReport.LoadWithOfficeLimits(DbContext, SecurityDbContext, Me.Session).OrderByDescending(Function(Entity) Entity.InvoiceNumber).ToList.Where(Function(Entity) ShowItemsOptions.Contains(ExpenseReportInvoiceNumbers.Contains(Entity.InvoiceNumber))).ToList

                                    Catch ex As Exception

                                    End Try

                                Case Database.Entities.DocumentLevel.Employee

                                    EmployeeCodes = AdvantageFramework.Database.Procedures.EmployeeDocument.Load(DataContext).Select(Function(Entity) Entity.EmployeeCode).Distinct.ToArray

                                    DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllEmployeesByUserWithOfficeLimits(DbContext, SecurityDbContext, Me.Session).ToList.Where(Function(Entity) ShowItemsOptions.Contains(EmployeeCodes.Contains(Entity.Code)))

                                Case Database.Entities.DocumentLevel.Vendor

                                    VendorCodes = AdvantageFramework.Database.Procedures.VendorDocument.Load(DataContext).Select(Function(Entity) Entity.VendorCode).Distinct.ToArray

                                    DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, Me.Session).ToList.Where(Function(Entity) ShowItemsOptions.Contains(VendorCodes.Contains(Entity.Code)))

                                Case Database.Entities.DocumentLevel.AccountReceivableInvoice

                                    DocumentLevelSettings = AdvantageFramework.Database.Procedures.AccountReceivableDocument.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = Entity.InvoiceNumber,
                                                                                                                                                                                                                                                                                                                             .AccountReceivableSequenceNumber = Entity.SequenceNumber,
                                                                                                                                                                                                                                                                                                                             .AccountReceivableType = Entity.Type}).ToList

                                    DataSource = AdvantageFramework.Database.Procedures.AccountReceivableView.LoadNonVoidedInvoicesWithOfficeLimitsAR(DbContext, SecurityDbContext, Me.Session).OrderByDescending(Function(Entity) Entity.InvoiceDate).ToList.Where(Function(Entity) ShowItemsOptions.Contains(DocumentLevelSettings.Any(Function(DLS) DLS.AccountReceivableInvoiceNumber = Entity.InvoiceNumber AndAlso DLS.AccountReceivableSequenceNumber = Entity.SequenceNumber AndAlso DLS.AccountReceivableType = Entity.Type)))

                                Case Database.Entities.DocumentLevel.MediaOrder

									OrderNumbers = AdvantageFramework.Database.Procedures.OrderDocument.Load(DbContext).Select(Function(Entity) Entity.OrderNumber).Distinct.ToArray

									DataSource = AdvantageFramework.Database.Procedures.Order.Load(DbContext).ToList.Where(Function(Order) ShowItemsOptions.Contains(OrderNumbers.Contains(Order.OrderNumber)))

							End Select

                            If _SelectedLevel <> Database.Entities.DocumentLevel.AgencyDesktop AndAlso _SelectedLevel <> Database.Entities.DocumentLevel.ExecutiveDesktop Then

                                Try

                                    If ItemDescription <> "" Then

                                        DataGridViewLeftSection_DocumentLevel.ItemDescription = ItemDescription

                                    End If

                                    DataGridViewLeftSection_DocumentLevel.DataSourceViewOption = DataSourceViewOption
                                    DataGridViewLeftSection_DocumentLevel.DataSource = DataSource
                                    DataGridViewLeftSection_DocumentLevel.CurrentView.AFActiveFilterString = AFActiveFilterString

                                Catch ex As Exception

                                End Try

                            End If

                        End Using

                    End Using

                End Using

                DataGridViewLeftSection_DocumentLevel.CurrentView.BestFitColumns()

            Else

                DataGridViewLeftSection_DocumentLevel.ClearGridCustomization()
                DataGridViewLeftSection_DocumentLevel.ItemDescription = "Item(s)"

            End If

        End Sub
        Private Sub LoadDocumentLevelSetting(ByRef DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting, ByVal RowHandle As Integer)

            Select Case _SelectedLevel

                Case Database.Entities.DocumentLevel.Office

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Office)
                    DocumentLevelSetting.OfficeCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Office.Properties.Code.ToString)

                Case Database.Entities.DocumentLevel.Client

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Client)
                    DocumentLevelSetting.ClientCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Client.Properties.Code.ToString)

                Case Database.Entities.DocumentLevel.Division

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Division)
                    DocumentLevelSetting.ClientCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.DivisionView.Properties.ClientCode.ToString)
                    DocumentLevelSetting.DivisionCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Division.Properties.Code.ToString)

                Case Database.Entities.DocumentLevel.Product

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Product)
                    DocumentLevelSetting.OfficeCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.ProductView.Properties.OfficeCode.ToString)
                    DocumentLevelSetting.ClientCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ClientCode.ToString)
                    DocumentLevelSetting.DivisionCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.ProductView.Properties.DivisionCode.ToString)
                    DocumentLevelSetting.ProductCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ProductCode.ToString)

                Case Database.Entities.DocumentLevel.Campaign

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Campaign)
                    DocumentLevelSetting.CampaignID = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.CampaignView.Properties.ID.ToString)

                Case Database.Entities.DocumentLevel.Job

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Job)
                    DocumentLevelSetting.OfficeCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobView.Properties.OfficeCode.ToString)
                    DocumentLevelSetting.ClientCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobView.Properties.ClientCode.ToString)
                    DocumentLevelSetting.DivisionCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobView.Properties.DivisionCode.ToString)
                    DocumentLevelSetting.ProductCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobView.Properties.ProductCode.ToString)
                    DocumentLevelSetting.JobNumber = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobView.Properties.JobNumber.ToString)

                Case Database.Entities.DocumentLevel.JobComponent

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent)
                    DocumentLevelSetting.OfficeCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobComponentView.Properties.OfficeCode.ToString)
                    DocumentLevelSetting.ClientCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobComponentView.Properties.ClientCode.ToString)
                    DocumentLevelSetting.DivisionCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobComponentView.Properties.DivisionCode.ToString)
                    DocumentLevelSetting.ProductCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobComponentView.Properties.ProductCode.ToString)
                    DocumentLevelSetting.JobNumber = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobComponentView.Properties.JobNumber.ToString)
                    DocumentLevelSetting.JobComponentNumber = CStr(CInt(DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.JobComponentView.Properties.JobComponentNumber.ToString)))

                Case Database.Entities.DocumentLevel.AccountPayableInvoice

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice)
                    DocumentLevelSetting.AccountPayableID = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.AccountPayable.Properties.ID.ToString)

                Case Database.Entities.DocumentLevel.AdNumber

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AdNumber)
                    DocumentLevelSetting.AdNumber = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Ad.Properties.Number.ToString)
                    DocumentLevelSetting.ClientCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Ad.Properties.ClientCode.ToString)

                Case Database.Entities.DocumentLevel.ExpenseReceipts

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts)
                    DocumentLevelSetting.ExpenseReportInvoiceNumber = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.ExpenseReport.Properties.InvoiceNumber.ToString)
                    DocumentLevelSetting.EmployeeCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.ExpenseReport.Properties.EmployeeCode.ToString)

                Case Database.Entities.DocumentLevel.Employee

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Employee)
                    DocumentLevelSetting.EmployeeCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.Employee.Properties.Code.ToString)

                Case Database.Entities.DocumentLevel.Vendor

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Vendor)
                    DocumentLevelSetting.VendorCode = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Vendor.Properties.Code.ToString)

                Case Database.Entities.DocumentLevel.AccountReceivableInvoice

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice)
                    DocumentLevelSetting.AccountReceivableInvoiceNumber = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.AccountReceivable.Properties.InvoiceNumber.ToString)
                    DocumentLevelSetting.AccountReceivableSequenceNumber = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.AccountReceivable.Properties.SequenceNumber.ToString)
                    DocumentLevelSetting.AccountReceivableType = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.AccountReceivable.Properties.Type.ToString)

                Case Database.Entities.DocumentLevel.AgencyDesktop

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AgencyDesktop)
                    DocumentLevelSetting.OfficeCode = SearchableComboBoxOffice_Office.GetSelectedValue
                    DocumentLevelSetting.DepartmentCode = SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.GetSelectedValue

                Case Database.Entities.DocumentLevel.ExecutiveDesktop

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExecutiveDesktop)
                    DocumentLevelSetting.OfficeCode = SearchableComboBoxOffice_Office.GetSelectedValue
                    DocumentLevelSetting.EmployeeCode = SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.GetSelectedValue

				Case Database.Entities.DocumentLevel.MediaOrder

					DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder)
					DocumentLevelSetting.OrderNumber = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.Order.Properties.OrderNumber.ToString)
					DocumentLevelSetting.MediaType = DataGridViewLeftSection_DocumentLevel.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.Order.Properties.MediaType.ToString)

			End Select

        End Sub
        Private Sub LoadLevelDocuments()

            'objects
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
            Dim ShowDocumentLevel As Boolean = False

            Try

                DocumentManagerControlRightSection_DocumentManager.ClearControl()

                If _SelectedLevel = Database.Entities.DocumentLevel.AgencyDesktop OrElse _SelectedLevel = Database.Entities.DocumentLevel.ExecutiveDesktop Then

                    DocumentManagerControlRightSection_DocumentManager.Enabled = True

                Else

                    DocumentManagerControlRightSection_DocumentManager.Enabled = DataGridViewLeftSection_DocumentLevel.HasASelectedRow

                End If

                If DocumentManagerControlRightSection_DocumentManager.Enabled Then

                    LoadDocumentLevelSetting(DocumentLevelSetting, DataGridViewLeftSection_DocumentLevel.CurrentView.FocusedRowHandle)

                    ' BELOW COMMENTED OUT HANDLES MULTI-SELECT

                    'DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                    'For Each RowHandle In DataGridViewLeftSection_DocumentLevel.CurrentView.GetSelectedRows

                    '    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting

                    '    LoadDocumentLevelSetting(DocumentLevelSetting, RowHandle)

                    '    DocumentLevelSettings.Add(DocumentLevelSetting)

                    'Next

                    If _SelectedLevel = Database.Entities.DocumentLevel.AgencyDesktop OrElse _SelectedLevel = Database.Entities.DocumentLevel.ExecutiveDesktop OrElse
                            _SelectedLevel = Database.Entities.DocumentLevel.Job OrElse _SelectedLevel = Database.Entities.DocumentLevel.JobComponent Then

                        ShowDocumentLevel = True

                    End If

                    DocumentManagerControlRightSection_DocumentManager.Enabled = DocumentManagerControlRightSection_DocumentManager.LoadControl(_SelectedLevel,
                                                                                                                                                DocumentLevelSetting,
                                                                                                                                                WinForm.Presentation.Controls.DocumentManagerControl.Type.Default,
                                                                                                                                                Database.Entities.DocumentSubLevel.Default,
                                                                                                                                                ShowDocumentLevel)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub EnableOrDisableActions()

            If _SelectedLevel = Database.Entities.DocumentLevel.AgencyDesktop OrElse _SelectedLevel = Database.Entities.DocumentLevel.ExecutiveDesktop Then

                DocumentManagerControlRightSection_DocumentManager.Enabled = Me.FormShown

            Else

                DocumentManagerControlRightSection_DocumentManager.Enabled = (DataGridViewLeftSection_DocumentLevel.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            End If

            If DocumentManagerControlRightSection_DocumentManager.Enabled Then

                'ButtonItemActions_Export.Enabled = True

                If _SelectedLevel = Database.Entities.DocumentLevel.AgencyDesktop OrElse _SelectedLevel = Database.Entities.DocumentLevel.ExecutiveDesktop Then

                    ButtonItemActions_Upload.Enabled = DocumentManagerControlRightSection_DocumentManager.CanUpload
                    ButtonItemProofHQ_Download.Enabled = DocumentManagerControlRightSection_DocumentManager.CanUpload

                Else

                    ButtonItemActions_Upload.Enabled = DocumentManagerControlRightSection_DocumentManager.CanUpload AndAlso DataGridViewLeftSection_DocumentLevel.HasOnlyOneSelectedRow
                    ButtonItemProofHQ_Download.Enabled = DocumentManagerControlRightSection_DocumentManager.CanUpload AndAlso DataGridViewLeftSection_DocumentLevel.HasOnlyOneSelectedRow

                End If

                If DocumentManagerControlRightSection_DocumentManager.HasASelectedDocument Then

                    ButtonItemActions_Download.Enabled = If(DocumentManagerControlRightSection_DocumentManager.HasOnlyOneSelectedDocument, Not DocumentManagerControlRightSection_DocumentManager.IsSelectedDocumentAURL, True)
                    ButtonItemActions_OpenURL.Enabled = If(DocumentManagerControlRightSection_DocumentManager.HasOnlyOneSelectedDocument, DocumentManagerControlRightSection_DocumentManager.IsSelectedDocumentAURL, False)
                    ButtonItemActions_Delete.Enabled = DocumentManagerControlRightSection_DocumentManager.CanDelete

                    If DocumentManagerControlRightSection_DocumentManager.HasOnlyOneSelectedDocument AndAlso DocumentManagerControlRightSection_DocumentManager.IsSelectedDocumentAURL = False Then

                        ButtonItemProofHQ_Upload.Enabled = True

                    Else

                        ButtonItemProofHQ_Upload.Enabled = False

                    End If

                Else

                    ButtonItemActions_Download.Enabled = False
                    ButtonItemActions_OpenURL.Enabled = False
                    ButtonItemActions_Delete.Enabled = False
                    ButtonItemProofHQ_Upload.Enabled = False

                End If

            Else

                ButtonItemActions_Upload.Enabled = False
                ButtonItemProofHQ_Download.Enabled = False
                ButtonItemActions_Download.Enabled = False
                ButtonItemActions_OpenURL.Enabled = False
                ButtonItemActions_Delete.Enabled = False
                ButtonItemProofHQ_Upload.Enabled = False
                'ButtonItemActions_Export.Enabled = False

            End If

            If _SelectedLevel <> -1 AndAlso _SelectedLevel <> Database.Entities.DocumentLevel.AgencyDesktop AndAlso _SelectedLevel <> Database.Entities.DocumentLevel.ExecutiveDesktop Then

                ButtonItemSearchFilter_All.Enabled = True
                ButtonItemSearchFilter_ItemsWithDocuments.Enabled = True
                ButtonItemSearchFilter_ItemsWithoutDocuments.Enabled = True
                ButtonItemActions_Export.Enabled = True

            Else

                ButtonItemSearchFilter_All.Enabled = False
                ButtonItemSearchFilter_ItemsWithDocuments.Enabled = False
                ButtonItemSearchFilter_ItemsWithoutDocuments.Enabled = False
                ButtonItemActions_Export.Enabled = False

            End If

        End Sub
        Private Sub EnableOrDisableCustomActions()

            If ComboBoxDocumentLevel_DocumentLevel.GetSelectedValue = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice Then

                RibbonBarOptions_CustomActions.Visible = True
                ButtonItemCustomActions_QuickImportARInvoiceDocuments.Visible = True
                ButtonItemCustomActions_QuickDownload.Visible = True

            ElseIf ComboBoxDocumentLevel_DocumentLevel.GetSelectedValue = AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice Then

                RibbonBarOptions_CustomActions.Visible = True
                ButtonItemCustomActions_QuickImportARInvoiceDocuments.Visible = False
                ButtonItemCustomActions_QuickDownload.Visible = True

            Else

                RibbonBarOptions_CustomActions.Visible = False
                ButtonItemCustomActions_QuickImportARInvoiceDocuments.Visible = False
                ButtonItemCustomActions_QuickDownload.Visible = False

            End If

            If Me.FormShown Then

                RibbonBarOptions_CustomActions.ResetCachedContentSize()

                RibbonBarOptions_CustomActions.Refresh()

                RibbonBarOptions_CustomActions.Width = RibbonBarOptions_CustomActions.GetAutoSizeWidth

                RibbonBarOptions_CustomActions.Refresh()

                If Me.MdiParent IsNot Nothing Then

                    Me.MdiParent.Refresh()

                End If

                Me.Refresh()

            End If

        End Sub
        Private Sub ModifyColumns()

            Select Case _SelectedLevel

                Case Database.Entities.DocumentLevel.Office


                Case Database.Entities.DocumentLevel.Client


                Case Database.Entities.DocumentLevel.Division


                Case Database.Entities.DocumentLevel.Product


                Case Database.Entities.DocumentLevel.Campaign


                Case Database.Entities.DocumentLevel.Job


                Case Database.Entities.DocumentLevel.JobComponent


                Case Database.Entities.DocumentLevel.AccountPayableInvoice


                Case Database.Entities.DocumentLevel.AdNumber

                    If DataGridViewLeftSection_DocumentLevel.CurrentView.Columns(AdvantageFramework.Database.Entities.Ad.Properties.ClientCode.ToString) IsNot Nothing Then

                        DataGridViewLeftSection_DocumentLevel.CurrentView.Columns(AdvantageFramework.Database.Entities.Ad.Properties.ClientCode.ToString).Caption = "Client Code"

                    End If

                Case Database.Entities.DocumentLevel.ExpenseReceipts


                Case Database.Entities.DocumentLevel.Employee


                Case Database.Entities.DocumentLevel.Vendor

                    DataGridViewLeftSection_DocumentLevel.HideOrShowColumn(AdvantageFramework.Database.Entities.Vendor.Properties.VendorCategory.ToString, False)

                Case Database.Entities.DocumentLevel.AccountReceivableInvoice


            End Select

        End Sub
        Private Sub EnableDisableSubDocumentLevels()

            'objects
            Dim SelectedLevel As Database.Entities.DocumentLevel = -1

            If ComboBoxDocumentLevel_DocumentLevel.HasASelectedValue Then

                SelectedLevel = ComboBoxDocumentLevel_DocumentLevel.SelectedValue

                Select Case SelectedLevel

                    Case Database.Entities.DocumentLevel.AgencyDesktop

                        LabelItemDepartmentOrEmployee_DepartmentOrEmployee.Text = "Department:"

                        ItemContainerSearch_Office.Visible = True
                        ItemContainerSearch_DepartmentOrEmployee.Visible = True
                        ControlContainerItemOffice_Office.Visible = True
                        ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Visible = True
                        SearchableComboBoxOffice_Office.Visible = True
                        SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Visible = True

                    Case Database.Entities.DocumentLevel.ExecutiveDesktop

                        LabelItemDepartmentOrEmployee_DepartmentOrEmployee.Text = "Employee:"

                        ItemContainerSearch_Office.Visible = True
                        ItemContainerSearch_DepartmentOrEmployee.Visible = True
                        ControlContainerItemOffice_Office.Visible = True
                        ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Visible = True
                        SearchableComboBoxOffice_Office.Visible = True
                        SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Visible = True

                    Case Else

                        ItemContainerSearch_Office.Visible = False
                        ItemContainerSearch_DepartmentOrEmployee.Visible = False
                        ControlContainerItemOffice_Office.Visible = False
                        ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Visible = False
                        SearchableComboBoxOffice_Office.Visible = False
                        SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Visible = False

                End Select

            Else

                ItemContainerSearch_Office.Visible = False
                ItemContainerSearch_DepartmentOrEmployee.Visible = False
                ControlContainerItemOffice_Office.Visible = False
                ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Visible = False
                SearchableComboBoxOffice_Office.Visible = False
                SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Visible = False

            End If

            If Me.FormShown Then

                RibbonBarOptions_Search.ResetCachedContentSize()

                RibbonBarOptions_Search.Refresh()

                RibbonBarOptions_Search.Width = RibbonBarOptions_Search.GetAutoSizeWidth

                RibbonBarOptions_Search.Refresh()

                If Me.MdiParent IsNot Nothing Then

                    Me.MdiParent.Refresh()

                End If

                Me.Refresh()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim DocumentManagerSetupForm As AdvantageFramework.Desktop.Presentation.DocumentManagerSetupForm = Nothing

            DocumentManagerSetupForm = New AdvantageFramework.Desktop.Presentation.DocumentManagerSetupForm()

            DocumentManagerSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DocumentManagerSetupForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated

            EnableDisableSubDocumentLevels()

        End Sub
        Private Sub DocumentManagerSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Info.Image = AdvantageFramework.My.Resources.DatabaseInformation
            ButtonItemSearch_Search.Image = AdvantageFramework.My.Resources.DashboardAndQueryImage
            ButtonItemActions_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
			ButtonItemSearch_Advanced.Image = AdvantageFramework.My.Resources.DocumentAdvancedSearch
			ButtonItemSearchFilter_All.Icon = AdvantageFramework.My.Resources.LinkIcon
            ButtonItemSearchFilter_ItemsWithDocuments.Icon = AdvantageFramework.My.Resources.LinkCheckIcon
            ButtonItemSearchFilter_ItemsWithoutDocuments.Icon = AdvantageFramework.My.Resources.LinkNewIcon
            ButtonItemActions_OpenURL.Image = AdvantageFramework.My.Resources.Link
            ButtonItemProofHQ_Download.Image = AdvantageFramework.My.Resources.ProofHQDownloadImage
            ButtonItemProofHQ_Upload.Image = AdvantageFramework.My.Resources.ProofHQUploadImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            ButtonItemCustomActions_QuickImportARInvoiceDocuments.Image = AdvantageFramework.My.Resources.InvoiceExecuteImage
            ButtonItemCustomActions_QuickDownload.Image = AdvantageFramework.My.Resources.DownloadDocument

            RibbonBarOptions_ProofHQ.Visible = False

            DataGridViewLeftSection_DocumentLevel.MultiSelect = False

            ItemContainerSearch_Search.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

					ButtonItemActions_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
					ButtonItemActions_Upload.SplitButton = False

				End If

			End Using

			ComboBoxDocumentLevel_DocumentLevel.DataSource = (From EnumObject In AdvantageFramework.FileSystem.LoadAvailableDocumentManagerLevels(Me.Session)
															  Where EnumObject.Code <> "12" AndAlso
																	EnumObject.Code <> "13" AndAlso
																	EnumObject.Code <> "14" AndAlso
																	EnumObject.Code <> "18" AndAlso
																	EnumObject.Code <> "19"
															  Select [Value] = EnumObject.Code, [Name] = EnumObject.Description).OrderBy(Function(Entity) Entity.Name).ToList

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SearchableComboBoxOffice_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, Me.Session)
                SearchableComboBoxViewOffice_Office.AFActiveFilterString = "[Inactive] = False"

            End Using

            LoadSelectedDocumentLevel()

            LoadLevelDocuments()

            DocumentManagerControlRightSection_DocumentManager.DocumentsDataGridView.CurrentView.ShowFindPanel()

            EnableOrDisableActions()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemActions_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            RibbonBarOptions_ProofHQ.Visible = DocumentManagerControlRightSection_DocumentManager.IsProofHQEnabled

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub DocumentManagerSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableCustomActions()

            DataGridViewLeftSection_DocumentLevel.CurrentView.ShowFindPanel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Download_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Download.Click

            DocumentManagerControlRightSection_DocumentManager.DownloadSelectedDocument()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            DocumentManagerControlRightSection_DocumentManager.DeleteSelectedDocument()

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewLeftSection_DocumentLevel.Print(Me.Session, Me.DefaultLookAndFeel.LookAndFeel, AdvantageFramework.StringUtilities.GetNameAsWords(_SelectedLevel.ToString))

        End Sub
        Private Sub ButtonItemSearch_Search_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSearch_Search.Click

            If ComboBoxDocumentLevel_DocumentLevel.HasASelectedValue Then

                _SelectedLevel = ComboBoxDocumentLevel_DocumentLevel.SelectedValue

            Else

                _SelectedLevel = -1

            End If

            Select Case _SelectedLevel

                Case Database.Entities.DocumentLevel.AgencyDesktop

                    ExpandableSplitterControlForm_LeftRight.Expandable = False
                    ExpandableSplitterControlForm_LeftRight.Expanded = False

                Case Database.Entities.DocumentLevel.ExecutiveDesktop

                    ExpandableSplitterControlForm_LeftRight.Expandable = False
                    ExpandableSplitterControlForm_LeftRight.Expanded = False

                Case Else

                    ExpandableSplitterControlForm_LeftRight.Expandable = True
                    ExpandableSplitterControlForm_LeftRight.Expanded = True

            End Select

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
            Me.ShowWaitForm()

            Try

                LoadSelectedDocumentLevel()
                LoadLevelDocuments()
                EnableOrDisableActions()

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()
            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub DataGridViewLeftSection_DocumentLevel_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_DocumentLevel.DataSourceChangedEvent

            If DataGridViewLeftSection_DocumentLevel.Columns IsNot Nothing AndAlso DataGridViewLeftSection_DocumentLevel.Columns.Count > 0 Then

                ModifyColumns()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_DocumentLevel_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_DocumentLevel.SelectionChangedEvent

            'objects
            Dim FirstChildRowHandle As Integer = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If DataGridViewLeftSection_DocumentLevel.CurrentView.IsGroupRow(DataGridViewLeftSection_DocumentLevel.CurrentView.FocusedRowHandle) Then

                    DataGridViewLeftSection_DocumentLevel.CurrentView.UnselectRow(DataGridViewLeftSection_DocumentLevel.CurrentView.FocusedRowHandle)

                    DataGridViewLeftSection_DocumentLevel.CurrentView.SetRowExpanded(DataGridViewLeftSection_DocumentLevel.CurrentView.FocusedRowHandle, True)

                    FirstChildRowHandle = DataGridViewLeftSection_DocumentLevel.CurrentView.GetDataRowHandleByGroupRowHandle(DataGridViewLeftSection_DocumentLevel.CurrentView.FocusedRowHandle)

                    DataGridViewLeftSection_DocumentLevel.CurrentView.SelectRow(FirstChildRowHandle)

                Else

                    Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                    Me.ShowWaitForm()

                    Try

                        LoadLevelDocuments()
                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
		Private Sub ButtonItemActions_Upload_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Upload.Click

			DocumentManagerControlRightSection_DocumentManager.UploadNewDocument()

		End Sub
		Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

			DocumentManagerControlRightSection_DocumentManager.SendASPUploadEmail()

		End Sub
		Private Sub DocumentManagerControlRightSection_DocumentManager_SelectedDocumentChanged() Handles DocumentManagerControlRightSection_DocumentManager.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSearch_Advanced_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSearch_Advanced.Click

            AdvantageFramework.Desktop.Presentation.AdvancedDocumentSearchDialog.ShowFormDialog()

        End Sub
        Private Sub ButtonItemActions_OpenURL_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_OpenURL.Click

            DocumentManagerControlRightSection_DocumentManager.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Info_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Info.MouseHover, ButtonItemActions_Info.Click

            'objects
            Dim UsedSpace As Long = Nothing
            Dim TotalSize As Long = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UsedSpace = AdvantageFramework.FileSystem.GetDocumentRepositorySize(DbContext)
                    TotalSize = AdvantageFramework.FileSystem.GetDocumentRepositoryLimit(DbContext)

                    ButtonItemActions_Info.Tooltip = "Using " & AdvantageFramework.FileSystem.GetFileSizeWithNotation(UsedSpace) & " of " &
                                                      AdvantageFramework.FileSystem.GetFileSizeWithNotation(TotalSize) & ". " &
                                                     "(" & Convert.ToInt16((UsedSpace * 100) / TotalSize).ToString & "%)"

                    ButtonItemActions_Info.ShowToolTip()

                Catch ex As Exception

                End Try

            End Using

        End Sub
        Private Sub ComboBoxDocumentLevel_DocumentLevel_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxDocumentLevel_DocumentLevel.SelectedValueChanged

            'objects
            Dim SelectedLevel As Database.Entities.DocumentLevel = -1

            If ComboBoxDocumentLevel_DocumentLevel.HasASelectedValue Then

                SelectedLevel = ComboBoxDocumentLevel_DocumentLevel.SelectedValue

                Select Case SelectedLevel

                    Case Database.Entities.DocumentLevel.AgencyDesktop

                        SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.DepartmentTeam

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.DataSource = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                            SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.AFActiveFilterString = "[Inactive] = False"

                        End Using

                        SearchableComboBoxOffice_Office.SelectedValue = Nothing
                        SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.SelectedValue = Nothing

                        LabelItemDepartmentOrEmployee_DepartmentOrEmployee.Text = "Department:"

                        ItemContainerSearch_Office.Visible = True
                        ItemContainerSearch_DepartmentOrEmployee.Visible = True
                        ControlContainerItemOffice_Office.Visible = True
                        ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Visible = True
                        SearchableComboBoxOffice_Office.Visible = True
                        SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Visible = True

                    Case Database.Entities.DocumentLevel.ExecutiveDesktop

                        SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Employee

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.AFActiveFilterString = "[Terminated] = False"

                            End Using

                        End Using

                        LabelItemDepartmentOrEmployee_DepartmentOrEmployee.Text = "Employee:"

                        ItemContainerSearch_Office.Visible = True
                        ItemContainerSearch_DepartmentOrEmployee.Visible = True
                        ControlContainerItemOffice_Office.Visible = True
                        ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Visible = True
                        SearchableComboBoxOffice_Office.Visible = True
                        SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Visible = True

                    Case Else

                        ItemContainerSearch_Office.Visible = False
                        ItemContainerSearch_DepartmentOrEmployee.Visible = False
                        ControlContainerItemOffice_Office.Visible = False
                        ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Visible = False
                        SearchableComboBoxOffice_Office.Visible = False
                        SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Visible = False

                End Select

            Else

                ItemContainerSearch_Office.Visible = False
                ItemContainerSearch_DepartmentOrEmployee.Visible = False
                ControlContainerItemOffice_Office.Visible = False
                ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Visible = False
                SearchableComboBoxOffice_Office.Visible = False
                SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Visible = False

            End If

            EnableDisableSubDocumentLevels()

            EnableOrDisableCustomActions()

        End Sub
        Private Sub ButtonItemCustomActions_QuickImportARInvoiceDocuments_Click(sender As Object, e As EventArgs) Handles ButtonItemCustomActions_QuickImportARInvoiceDocuments.Click

            AdvantageFramework.Desktop.Presentation.ImportARInvoiceDocumentSetupForm.ShowForm()

        End Sub
        Private Sub ButtonItemSearchFilter_All_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSearchFilter_All.CheckedChanged

            If ButtonItemSearchFilter_All.Checked Then

                Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                Me.ShowWaitForm()

                Try

                    LoadSelectedDocumentLevel()
                    LoadLevelDocuments()
                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemSearchFilter_ItemsWithDocuments_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSearchFilter_ItemsWithDocuments.CheckedChanged

            If ButtonItemSearchFilter_ItemsWithDocuments.Checked Then

                Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                Me.ShowWaitForm()

                Try

                    LoadSelectedDocumentLevel()
                    LoadLevelDocuments()
                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemSearchFilter_ItemsWithoutDocuments_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSearchFilter_ItemsWithoutDocuments.CheckedChanged

            If ButtonItemSearchFilter_ItemsWithoutDocuments.Checked Then

                Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem
                Me.ShowWaitForm()

                Try

                    LoadSelectedDocumentLevel()
                    LoadLevelDocuments()
                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemProofHQ_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemProofHQ_Upload.Click

            DocumentManagerControlRightSection_DocumentManager.UploadToProofHQ()

        End Sub
        Private Sub ButtonItemProofHQ_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemProofHQ_Download.Click

            DocumentManagerControlRightSection_DocumentManager.DownloadFromProofHQ()

        End Sub
        Private Sub ButtonItemCustomActions_QuickDownload_Click(sender As Object, e As EventArgs) Handles ButtonItemCustomActions_QuickDownload.Click

            If ComboBoxDocumentLevel_DocumentLevel.GetSelectedValue = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice Then

                AdvantageFramework.Desktop.Presentation.DocumentManagerInvoicesDialog.ShowFormDialog(DocumentManagerInvoicesDialog.InvoiceTypes.ARInvoices)

            ElseIf ComboBoxDocumentLevel_DocumentLevel.GetSelectedValue = AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice Then

                AdvantageFramework.Desktop.Presentation.DocumentManagerInvoicesDialog.ShowFormDialog(DocumentManagerInvoicesDialog.InvoiceTypes.APInvoices)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
