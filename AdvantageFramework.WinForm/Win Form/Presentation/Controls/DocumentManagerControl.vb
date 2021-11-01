Namespace WinForm.Presentation.Controls

    Public Class DocumentManagerControl

        Public Event SelectedDocumentChanged()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Type
            [Default]
            ViewOnly
            HideHistoryEnableActions
        End Enum

#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
        Private _DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Nothing
        Private _AllowPrivateAccess As Boolean = Nothing
        Private _DetailDocuments As Generic.List(Of AdvantageFramework.Database.Classes.DetailDocument) = Nothing
        Private _DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing
        Private WithEvents _GridViewDocumentHistory As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private _ShowDocumentHistory As Boolean = Nothing
        Private _IsSelectedDocumentAURL As Boolean = Nothing
        Private _OpenDocumentProcesses As Generic.List(Of System.Diagnostics.Process) = Nothing
        Private _DisableGridActions As Boolean = False
        Private _CanUpload As Boolean = False
        Private _IsProofHQEnabled As Boolean = False
        Private _ShowDocumentLevel As Boolean = False
        Private _ShowMultipleDocumentLevels As Boolean = False
        Private _IsEditable As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property DocumentsDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                DocumentsDataGridView = DataGridViewForm_Documents
            End Get
        End Property
        Public ReadOnly Property HasASelectedDocument As Boolean
            Get
                HasASelectedDocument = DataGridViewForm_Documents.HasASelectedRow
            End Get
        End Property
        Public ReadOnly Property HasOnlyOneSelectedDocument As Boolean
            Get
                HasOnlyOneSelectedDocument = DataGridViewForm_Documents.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property IsSelectedDocumentAURL As Boolean
            Get
                IsSelectedDocumentAURL = _IsSelectedDocumentAURL
            End Get
        End Property
        Public ReadOnly Property CanUpload As Boolean
            Get
                CanUpload = _CanUpload
            End Get
        End Property
        Public ReadOnly Property IsProofHQEnabled As Boolean
            Get
                IsProofHQEnabled = _IsProofHQEnabled
            End Get
        End Property
        Public ReadOnly Property CanDelete As Boolean
            Get
                CanDelete = DataGridViewForm_Documents.HasOnlyOneSelectedRow AndAlso (_DocumentLevel = DataGridViewForm_Documents.CurrentView.GetRowCellValue(DataGridViewForm_Documents.CurrentView.FocusedRowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.DocumentLevel.ToString))
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    DataGridViewForm_Documents.MultiSelect = True

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                _IsProofHQEnabled = AdvantageFramework.ProofHQ.IsProofHQEnabled(DataContext)

                                Try

                                    _AllowPrivateAccess = AdvantageFramework.Security.LoadUserGroupSetting(_Session, Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Where(Function(Setting) Setting = True).Any

                                Catch ex As Exception
                                    _AllowPrivateAccess = False
                                End Try

                                Try

                                    _CanUpload = AdvantageFramework.Security.LoadUserGroupSetting(_Session, Security.GroupSettings.DocumentManager_CanUpload).Where(Function(Setting) Setting = True).Any

                                Catch ex As Exception
                                    _CanUpload = False
                                End Try

                            End Using

                        End Using

                    End If

                End If

                'RemoveHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub EnableOrDisableActions()


        End Sub
        Private Function LoadDocuments(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
                                       Optional DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Nothing) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects 
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            Select Case DocumentLevel

                Case AdvantageFramework.Database.Entities.DocumentLevel.Office

                    DocumentList = AdvantageFramework.DocumentManager.LoadOfficeDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Client

                    DocumentList = AdvantageFramework.DocumentManager.LoadClientDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                    DocumentList = AdvantageFramework.DocumentManager.LoadDivisionDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                    DocumentList = AdvantageFramework.DocumentManager.LoadProductDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Campaign

                    DocumentList = AdvantageFramework.DocumentManager.LoadCampaignDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Job

                    DocumentList = AdvantageFramework.DocumentManager.LoadJobDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.JobComponent

                    DocumentList = AdvantageFramework.DocumentManager.LoadJobComponentDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                    DocumentList = AdvantageFramework.DocumentManager.LoadAccountPayableInvoiceDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts

                    If _DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument OrElse DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument Then

                        DocumentList = AdvantageFramework.DocumentManager.LoadExpenseDetailDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                    Else

                        DocumentList = AdvantageFramework.DocumentManager.LoadExpenseDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                    End If

                Case AdvantageFramework.Database.Entities.DocumentLevel.AdNumber

                    DocumentList = AdvantageFramework.DocumentManager.LoadAdNumberDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Employee

                    DocumentList = AdvantageFramework.DocumentManager.LoadEmployeeDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Vendor

                    DocumentList = AdvantageFramework.DocumentManager.LoadVendorDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Contract

                    DocumentList = AdvantageFramework.DocumentManager.LoadContractDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                    DocumentList = AdvantageFramework.DocumentManager.LoadAccountReceivableInvoiceDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.ContractReport

                    DocumentList = AdvantageFramework.DocumentManager.LoadContractReportDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.VendorContract

                    DocumentList = AdvantageFramework.DocumentManager.LoadVendorContractDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case Database.Entities.DocumentLevel.AgencyDesktop

                    DocumentList = AdvantageFramework.DocumentManager.LoadAgencyDesktopDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case Database.Entities.DocumentLevel.ExecutiveDesktop

                    DocumentList = AdvantageFramework.DocumentManager.LoadExecutiveDesktopDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder

                    DocumentList = AdvantageFramework.DocumentManager.LoadMediaOrderDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.AlertAttachment

                    DocumentList = AdvantageFramework.DocumentManager.LoadAlertDocuments(_Session, _DocumentLevelSettings, False)

                Case AdvantageFramework.Database.Entities.DocumentLevel.MediaTrafficDetail

                    DocumentList = AdvantageFramework.DocumentManager.LoadMediaTrafficDetailDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.JournalEntry

                    DocumentList = AdvantageFramework.DocumentManager.LoadJournalEntryDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

                Case AdvantageFramework.Database.Entities.DocumentLevel.MediaPlan

                    DocumentList = AdvantageFramework.DocumentManager.LoadMediaPlanDocuments(_Session, _DocumentLevelSettings, _AllowPrivateAccess)

            End Select

            LoadDocuments = DocumentList

        End Function
        Private Sub LoadDocuments()

            'objects 
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs As IEnumerable(Of Integer) = Nothing
            Dim NewDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

                If _ShowMultipleDocumentLevels Then

                    For Each EntityObject In (From DocumentLevelSetting In _DocumentLevelSettings
                                              Select DocumentLevelSetting.DocumentLevel, DocumentLevelSetting.DocumentSubLevel).Distinct.ToList

                        DocumentIDs = DocumentList.Select(Function(E) E.ID).ToArray

                        NewDocumentList = (From Entity In LoadDocuments(EntityObject.DocumentLevel, EntityObject.DocumentSubLevel)
                                           Where DocumentIDs.Contains(Entity.ID) = False
                                           Select Entity).ToList

                        If NewDocumentList IsNot Nothing AndAlso NewDocumentList.Count > 0 Then

                            DocumentList.AddRange(NewDocumentList)

                        End If

                    Next

                Else

                    DocumentList.AddRange(LoadDocuments(_DocumentLevel))

                End If

                DataGridViewForm_Documents.DataSource = DocumentList.OrderByDescending(Function(Document) Document.UploadedDate).ToList

                If DataGridViewForm_Documents.Columns(AdvantageFramework.DocumentManager.Classes.Document.Properties.DocumentLevelName.ToString) IsNot Nothing Then

                    DataGridViewForm_Documents.Columns(AdvantageFramework.DocumentManager.Classes.Document.Properties.DocumentLevelName.ToString).Visible = _ShowDocumentLevel

                End If

                If _IsProofHQEnabled Then

                    DataGridViewForm_Documents.OptionsBehavior.Editable = True

                    For Each GridColumn In DataGridViewForm_Documents.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString Then

                            GridColumn.OptionsColumn.AllowEdit = True
                            GridColumn.Visible = True

                        Else

                            GridColumn.OptionsColumn.AllowEdit = False

                        End If

                    Next

                Else

                    DataGridViewForm_Documents.OptionsBehavior.Editable = False

                    If DataGridViewForm_Documents.Columns(AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString) IsNot Nothing Then

                        DataGridViewForm_Documents.Columns(AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString).Visible = False

                    End If

                End If

                If _IsEditable Then

                    For Each GridColumn In DataGridViewForm_Documents.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.Description.ToString OrElse
                                 GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.DocumentTypeID.ToString Then

                            GridColumn.OptionsColumn.AllowEdit = True

                        Else

                            GridColumn.OptionsColumn.AllowEdit = False

                        End If

                    Next

                End If

                DataGridViewForm_Documents.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Function LoadRelatedDocuments(ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim Documents As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = -1

            'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            '    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            '        DocumentLevel = DataGridViewForm_Documents.CurrentView.GetRowCellValue(DataGridViewForm_Documents.CurrentView.FocusedRowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.DocumentLevel.ToString)

            '        Select Case DocumentLevel

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.Office

            '                Documents = LoadRelatedOfficeDocuments(DbContext, DocumentID, FileName)

            '            Case Database.Entities.DocumentLevel.Client

            '                Documents = LoadRelatedClientDocuments(DbContext, DataContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.Division

            '                Documents = LoadRelatedDivisionDocuments(DbContext, DataContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.Product

            '                Documents = LoadRelatedProductDocuments(DbContext, DataContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.Campaign

            '                Documents = LoadRelatedCampaignDocuments(DbContext, DataContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.Job

            '                Documents = LoadRelatedJobDocuments(DbContext, DataContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.JobComponent

            '                Documents = LoadRelatedJobComponentDocuments(DbContext, DataContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

            '                Documents = LoadRelatedAccountPayableDocuments(DbContext, DataContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.Employee

            '                Documents = LoadRelatedEmployeeDocuments(DbContext, DataContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.Vendor

            '                Documents = LoadRelatedVendorDocuments(DbContext, DataContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts

            '                'Documents = LoadRelatedExpenseReportDocuments(DbContext, DocumentID, FileName)

            '                Documents = Nothing

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.Contract

            '                Documents = LoadRelatedContractDocuments(DbContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

            '                Documents = LoadRelatedAccountReceivableInvoiceDocuments(DbContext, DocumentID, FileName)

            '            Case AdvantageFramework.Database.Entities.DocumentLevel.ContractReport

            '                Documents = LoadRelatedContractReportDocuments(DbContext, DataContext, DocumentID, FileName)

            '            Case Else

            '                Documents = Nothing

            '        End Select

            '    End Using

            'End Using

            DocumentLevel = DataGridViewForm_Documents.CurrentView.GetRowCellValue(DataGridViewForm_Documents.CurrentView.FocusedRowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.DocumentLevel.ToString)

            LoadRelatedDocuments = AdvantageFramework.DocumentManager.LoadRelatedDocuments(_Session, DocumentID, FileName, DocumentLevel)

        End Function
        Private Sub LoadDetailView()

            DataGridViewForm_Documents.CurrentView.BeginUpdate()

            _GridViewDocumentHistory = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            DataGridViewForm_Documents.GridControl.LevelTree.Nodes.Add("DocumentHistory", _GridViewDocumentHistory)

            _GridViewDocumentHistory.LevelIndent = 1

            _GridViewDocumentHistory.ChildGridLevelName = "DocumentHistory"
            _GridViewDocumentHistory.GridControl = DataGridViewForm_Documents.GridControl
            _GridViewDocumentHistory.Name = "_GridViewDocumentHistory"

            _GridViewDocumentHistory.Session = _Session

            _GridViewDocumentHistory.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

            _GridViewDocumentHistory.ObjectType = GetType(AdvantageFramework.DocumentManager.Classes.Document)

            _GridViewDocumentHistory.OptionsDetail.ShowDetailTabs = False
            _GridViewDocumentHistory.OptionsSelection.MultiSelect = True
            _GridViewDocumentHistory.OptionsView.ShowViewCaption = False

            _GridViewDocumentHistory.OptionsBehavior.Editable = _IsProofHQEnabled

            _GridViewDocumentHistory.CreateColumnsBasedOnObjectType()

            _GridViewDocumentHistory.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            _GridViewDocumentHistory.OptionsView.ShowFooter = False

            HideOrShowGridColumns()

            DataGridViewForm_Documents.CurrentView.EndUpdate()

        End Sub
        Private Sub HideOrShowGridColumns()

            'objects
            Dim VisibleIndex As Integer = 0

            For Each GridColumn In _GridViewDocumentHistory.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

                If GridColumn.FieldName <> AdvantageFramework.DocumentManager.Classes.Document.Properties.FileName.ToString AndAlso
                   GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.Description.ToString AndAlso
                   GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.Keywords.ToString AndAlso
                   GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.FileSize.ToString AndAlso
                   GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.UserCode.ToString AndAlso
                   GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.UploadedDate.ToString AndAlso
                   GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString Then

                    GridColumn.OptionsColumn.AllowShowHide = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False
                    GridColumn.OptionsColumn.ShowInExpressionEditor = False
                    GridColumn.OptionsColumn.AllowEdit = False

                End If

            Next

            'If _ShowDocumentLevel AndAlso _GridViewDocumentHistory.Columns("DocumentLevel") IsNot Nothing Then

            '    VisibleIndex += 1
            '    _GridViewDocumentHistory.Columns("DocumentLevel").Visible = True
            '    _GridViewDocumentHistory.Columns("DocumentLevel").VisibleIndex = VisibleIndex

            'End If

            If _GridViewDocumentHistory.Columns("FileName") IsNot Nothing Then

                VisibleIndex += 1
                _GridViewDocumentHistory.Columns("FileName").Visible = True
                _GridViewDocumentHistory.Columns("FileName").VisibleIndex = VisibleIndex

            End If

            If _GridViewDocumentHistory.Columns("Description") IsNot Nothing Then

                VisibleIndex += 1
                _GridViewDocumentHistory.Columns("Description").Visible = True
                _GridViewDocumentHistory.Columns("Description").VisibleIndex = VisibleIndex

            End If

            If _GridViewDocumentHistory.Columns("Keywords") IsNot Nothing Then

                VisibleIndex += 1
                _GridViewDocumentHistory.Columns("Keywords").Visible = True
                _GridViewDocumentHistory.Columns("Keywords").VisibleIndex = VisibleIndex

            End If

            If _GridViewDocumentHistory.Columns("FileSize") IsNot Nothing Then

                VisibleIndex += 1
                _GridViewDocumentHistory.Columns("FileSize").Visible = True
                _GridViewDocumentHistory.Columns("FileSize").VisibleIndex = VisibleIndex

            End If

            If _GridViewDocumentHistory.Columns("UserCode") IsNot Nothing Then

                VisibleIndex += 1
                _GridViewDocumentHistory.Columns("UserCode").Visible = True
                _GridViewDocumentHistory.Columns("UserCode").VisibleIndex = VisibleIndex
                _GridViewDocumentHistory.Columns("UserCode").Caption = "Uploaded By"

            End If

            If _GridViewDocumentHistory.Columns("UploadedDate") IsNot Nothing Then

                VisibleIndex += 1
                _GridViewDocumentHistory.Columns("UploadedDate").Visible = True
                _GridViewDocumentHistory.Columns("UploadedDate").VisibleIndex = VisibleIndex

            End If

            If _GridViewDocumentHistory.Columns("ProofHQUrl") IsNot Nothing Then

                VisibleIndex += 1
                _GridViewDocumentHistory.Columns("ProofHQUrl").Caption = "Proof HQ Url"

                If _IsProofHQEnabled Then

                    _GridViewDocumentHistory.Columns("ProofHQUrl").Visible = True
                    _GridViewDocumentHistory.Columns("ProofHQUrl").VisibleIndex = VisibleIndex
                    _GridViewDocumentHistory.Columns("ProofHQUrl").OptionsColumn.AllowEdit = True

                Else

                    _GridViewDocumentHistory.Columns("ProofHQUrl").Visible = False
                    _GridViewDocumentHistory.Columns("ProofHQUrl").OptionsColumn.AllowEdit = False

                End If

            End If

        End Sub
        Private Function GetSelectedDocumentID() As Long

            'objects
            Dim SelectedDocumentID As Long = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            For RowHandle = 0 To DataGridViewForm_Documents.CurrentView.RowCount - 1

                GridView = DataGridViewForm_Documents.CurrentView.GetDetailView(RowHandle, 0)

                If DataGridViewForm_Documents.CurrentView.IsRowSelected(RowHandle) OrElse (GridView IsNot Nothing AndAlso GridView.SelectedRowsCount > 0) Then

                    If GridView IsNot Nothing AndAlso GridView.SelectedRowsCount > 0 Then

                        For DetailRowHandle = 0 To GridView.RowCount - 1

                            If GridView.IsRowSelected(DetailRowHandle) Then

                                SelectedDocumentID = GridView.GetRowCellValue(DetailRowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.ID.ToString)

                            End If

                        Next

                    Else

                        If DataGridViewForm_Documents.CurrentView.Columns(AdvantageFramework.Database.Classes.DetailDocument.Properties.DOCUMENT_ID.ToString) IsNot Nothing Then

                            SelectedDocumentID = DataGridViewForm_Documents.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.DetailDocument.Properties.DOCUMENT_ID.ToString)

                        Else

                            SelectedDocumentID = DataGridViewForm_Documents.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.ID.ToString)

                        End If

                    End If

                End If

                If SelectedDocumentID > 0 Then

                    Exit For

                End If

            Next

            GetSelectedDocumentID = SelectedDocumentID

        End Function
        Private Function GetSelectedDocumentFileName() As String

            'objects
            Dim SelectedDocumentFileName As String = ""
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            If DataGridViewForm_Documents.CurrentView.IsFocusedView Then

                SelectedDocumentFileName = CStr(DataGridViewForm_Documents.GetFirstSelectedRowCellValue(AdvantageFramework.DocumentManager.Classes.Document.Properties.FileName.ToString))

            Else

                For RowHandle = 0 To DataGridViewForm_Documents.CurrentView.RowCount - 1

                    If DataGridViewForm_Documents.CurrentView.GetMasterRowExpanded(RowHandle) Then

                        Try

                            GridView = DataGridViewForm_Documents.CurrentView.GetDetailView(RowHandle, 0)

                        Catch ex As Exception
                            GridView = Nothing
                        End Try

                        If GridView IsNot Nothing AndAlso GridView.IsFocusedView Then

                            SelectedDocumentFileName = CStr(GridView.GetRowCellValue(GridView.FocusedRowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.FileName.ToString))
                            Exit For

                        End If

                    End If

                Next

            End If

            GetSelectedDocumentFileName = SelectedDocumentFileName

        End Function
        Private Function DeleteLevelDocument(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal DataContext As AdvantageFramework.Database.DataContext,
                                             ByVal Document As AdvantageFramework.Database.Entities.Document,
                                             ByVal DeleteExpenseDetailDocumentOnly As Boolean) As Boolean

            'Objects
            Dim Deleted As Boolean = False

            Try

                Select Case _DocumentLevel

                    Case Database.Entities.DocumentLevel.AccountPayableInvoice

                        Deleted = AdvantageFramework.DocumentManager.DeleteAccountPayableInvoiceDocument(DataContext, Document.ID)

                    Case Database.Entities.DocumentLevel.AdNumber

                        Deleted = AdvantageFramework.DocumentManager.DeleteAdDocument(DbContext, Document.ID)

                    Case Database.Entities.DocumentLevel.Campaign

                        Deleted = AdvantageFramework.DocumentManager.DeleteCampaignDocument(DataContext, Document.ID)

                    Case Database.Entities.DocumentLevel.Client

                        Deleted = AdvantageFramework.DocumentManager.DeleteClientDocument(DataContext, Document.ID)

                    Case Database.Entities.DocumentLevel.Division

                        Deleted = AdvantageFramework.DocumentManager.DeleteDivisionDocument(DataContext, Document.ID)

                    Case Database.Entities.DocumentLevel.Product

                        Deleted = AdvantageFramework.DocumentManager.DeleteProductDocument(DataContext, Document.ID)

                    Case Database.Entities.DocumentLevel.ExpenseReceipts

                        Deleted = AdvantageFramework.DocumentManager.DeleteExpenseDocument(DbContext, Document.ID, DeleteExpenseDetailDocumentOnly, _DocumentLevelSettings.FirstOrDefault.ExpenseDetailID)

                    Case Database.Entities.DocumentLevel.Job

                        Deleted = AdvantageFramework.DocumentManager.DeleteJobDocument(DataContext, Document.ID)

                    Case Database.Entities.DocumentLevel.JobComponent

                        Deleted = AdvantageFramework.DocumentManager.DeleteJobComponentDocument(DataContext, Document.ID)

                    Case Database.Entities.DocumentLevel.Office

                        Deleted = AdvantageFramework.DocumentManager.DeleteOfficeDocument(DbContext, Document.ID)

                    Case Database.Entities.DocumentLevel.Employee

                        Deleted = AdvantageFramework.DocumentManager.DeleteEmployeeDocument(DataContext, Document.ID)

                    Case Database.Entities.DocumentLevel.Vendor

                        Deleted = AdvantageFramework.DocumentManager.DeleteVendorDocument(DataContext, Document.ID)

                    Case Database.Entities.DocumentLevel.Contract

                        Deleted = AdvantageFramework.DocumentManager.DeleteContractDocument(DbContext, Document.ID)

                    Case Database.Entities.DocumentLevel.AccountReceivableInvoice

                        Deleted = AdvantageFramework.DocumentManager.DeleteAccountReceivableInvoiceDocument(DbContext, Document.ID)

                    Case Database.Entities.DocumentLevel.ContractReport

                        Deleted = AdvantageFramework.DocumentManager.DeleteContractReportDocument(DataContext, Document.ID)

                    Case Database.Entities.DocumentLevel.VendorContract

                        Deleted = AdvantageFramework.DocumentManager.DeleteVendorContractDocument(DbContext, Document.ID)

                    Case Database.Entities.DocumentLevel.AgencyDesktop

                        Deleted = AdvantageFramework.DocumentManager.DeleteAgencyDesktopDocument(DbContext, Document.ID)

                    Case Database.Entities.DocumentLevel.ExecutiveDesktop

                        Deleted = AdvantageFramework.DocumentManager.DeleteExecutiveDesktopDocument(DbContext, Document.ID)

                    Case AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder

                        Deleted = AdvantageFramework.DocumentManager.DeleteMediaOrderDocument(DbContext, Document.ID)

                    Case Database.Entities.DocumentLevel.MediaTrafficDetail

                        Deleted = AdvantageFramework.DocumentManager.DeleteMediaTrafficDetailDocument(DbContext, Document.ID, _DocumentLevelSettings.FirstOrDefault.MediaTrafficDetailID)

                    Case Database.Entities.DocumentLevel.JournalEntry

                        Deleted = AdvantageFramework.DocumentManager.DeleteJournalEntryDocument(DbContext, Document.ID)

                    Case Database.Entities.DocumentLevel.MediaPlan

                        Deleted = AdvantageFramework.DocumentManager.DeleteMediaPlanDocument(DbContext, Document.ID, _DocumentLevelSettings.FirstOrDefault.MediaPlanID)

                End Select

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteLevelDocument = Deleted
            End Try

        End Function
        Private Function GetDefaultDescription() As String

            Dim Description As String = ""
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim AccountPayableID As Integer = 0

            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Select Case _DocumentLevel

                        Case Database.Entities.DocumentLevel.AccountPayableInvoice

                            AccountPayableID = If(IsNumeric(_DocumentLevelSettings.FirstOrDefault.AccountPayableID), _DocumentLevelSettings.FirstOrDefault.AccountPayableID, 0)

                            AccountPayable = (From Entity In AdvantageFramework.Database.Procedures.AccountPayable.Load(DbContext)
                                              Where Entity.ID = AccountPayableID
                                              Select Entity).OrderByDescending(Function(Entity) Entity.SequenceNumber).FirstOrDefault

                            If AccountPayable IsNot Nothing Then

                                Description = AccountPayable.VendorCode & " - " & AccountPayable.Vendor.Name & ", " & AccountPayable.InvoiceNumber & " - Inv #: " & AccountPayable.InvoiceDescription & " - " & AccountPayable.InvoiceDate.ToShortDateString

                            End If

                    End Select

                End Using

            End If

            GetDefaultDescription = Description

        End Function
        Private Function GetDocumentLevelSetting() As AdvantageFramework.Database.Classes.DocumentLevelSetting

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            Try

                If _DocumentLevelSettings IsNot Nothing Then

                    Select Case _DocumentLevel

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Office

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.OfficeCode) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Client

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.ClientCode) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DS.DivisionCode) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DS.DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(DS.ProductCode) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Campaign

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.CampaignID) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Job

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.JobNumber) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.JobComponent

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.JobNumber) = False AndAlso String.IsNullOrWhiteSpace(DS.JobComponentNumber) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.AccountPayableID) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AdNumber

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.AdNumber) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.ExpenseReportInvoiceNumber) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Employee

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.EmployeeCode) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Vendor

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.VendorCode) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Contract

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.ContractID) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.ContractValueAdded

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.ValueAddedID) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.ContractReport

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.ContractReportID) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) DS.AccountReceivableInvoiceNumber <> 0).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.VendorContract

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.VendorContractID) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.OrderNumber) = False).FirstOrDefault

                        Case AdvantageFramework.Database.Entities.DocumentLevel.MediaPlan

                            DocumentLevelSetting = _DocumentLevelSettings.Where(Function(DS) String.IsNullOrWhiteSpace(DS.MediaPlanID) = False).FirstOrDefault

                    End Select

                End If

            Catch ex As Exception
                DocumentLevelSetting = Nothing
            Finally
                GetDocumentLevelSetting = DocumentLevelSetting
            End Try

        End Function

#Region "  Public "

        Public Function LoadControl(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
                                    ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                    Optional ByVal DocumentManagerType As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl.Type = Type.Default,
                                    Optional ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Database.Entities.DocumentSubLevel.Default,
                                    Optional ByVal ShowDocumentLevel As Boolean = False,
                                    Optional ByVal ShowMultipleDocumentLevels As Boolean = False,
                                    Optional ByVal IsEditable As Boolean = False)

            'objects
            Dim Loaded As Boolean = True

            _DocumentLevel = DocumentLevel
            _DocumentSubLevel = DocumentSubLevel
            _DocumentLevelSettings = DocumentLevelSettings
            _ShowDocumentLevel = ShowDocumentLevel
            _ShowMultipleDocumentLevels = ShowMultipleDocumentLevels
            _IsEditable = IsEditable

            If IsEditable Then

                DataGridViewForm_Documents.ControlType = DataGridView.Type.EditableGrid
                DataGridViewForm_Documents.ByPassUserEntryChanged = False

            End If

            Select Case DocumentManagerType

                Case Type.Default

                    _ShowDocumentHistory = True
                    _DisableGridActions = False

                Case Type.ViewOnly

                    _ShowDocumentHistory = False
                    _DisableGridActions = True

                Case Type.HideHistoryEnableActions

                    _ShowDocumentHistory = False
                    _DisableGridActions = False

            End Select

            'If _DocumentLevel = Database.Entities.DocumentLevel.ExpenseReceipts Then

            '    _ShowDocumentHistory = False

            'End If

            LoadDetailView()

            LoadDocuments()

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function LoadControl(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
                                    ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting,
                                    Optional ByVal DocumentManagerType As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl.Type = Type.Default,
                                    Optional ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Database.Entities.DocumentSubLevel.Default,
                                    Optional ByVal ShowDocumentLevel As Boolean = False)

            'objects
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            _ShowDocumentLevel = ShowDocumentLevel

            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

            DocumentLevelSettings.Add(DocumentLevelSetting)

            LoadControl = LoadControl(DocumentLevel, DocumentLevelSettings, DocumentManagerType, DocumentSubLevel, ShowDocumentLevel)

        End Function
        Public Function LoadControlForAdvancedDocumentSearch() As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim DetailDocuments As Generic.List(Of AdvantageFramework.Database.Classes.DetailDocument) = Nothing

            _ShowDocumentHistory = False

            DataGridViewForm_Documents.CurrentView.BeginUpdate()

            DataGridViewForm_Documents.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.DetailDocument)

            For Each GridColumn In DataGridViewForm_Documents.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

            Next

            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.FILENAME.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.FileType.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.FILE_SIZE.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.DESCRIPTION.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.KEYWORDS.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.USER_CODE.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.UPLOADED_DATE.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.LEVEL.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.OFFICE_CODE.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.OFFICE_NAME.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.CL_CODE.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.CLIENT_NAME.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.DIV_CODE.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.DIVISION_NAME.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.PRD_CODE.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.PRODUCT_DESCRIPTION.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.CMP_CODE.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.CAMPAIGN_NAME.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.JOB_NUMBER.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.JOB_DESCRIPTION.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.JOB_COMPONENT_NBR.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.JOB_COMP_DESCRIPTION.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.VENDOR_CODE.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.VENDOR_NAME.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.AP_INVOICE.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.AP_INVOICE_DESC.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.AD_NBR.ToString)
            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.Database.Classes.DetailDocument.Properties.AD_NBR_DESC.ToString)

            DataGridViewForm_Documents.CurrentView.BestFitColumns()

            DataGridViewForm_Documents.CurrentView.EndUpdate()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControlForAdvancedDocumentSearch = Loaded

        End Function
        Public Sub AdvancedFilterDocuments(ByVal FilterString As String)

            Dim DetailDocuments As Generic.List(Of AdvantageFramework.Database.Classes.DetailDocument) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    DetailDocuments = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.DetailDocument)(String.Format("exec proc_AdvancedDocumentSearch '{0}', '{1}', {2}", FilterString, _Session.UserCode, If(_AllowPrivateAccess, 1, 0))).ToList

                Catch ex As Exception

                End Try

                DataGridViewForm_Documents.CurrentView.BeginUpdate()

                DataGridViewForm_Documents.DataSource = DetailDocuments

                DataGridViewForm_Documents.CurrentView.BestFitColumns()

                DataGridViewForm_Documents.CurrentView.EndUpdate()

            End Using

        End Sub
        Public Sub DownloadSelectedDocument(Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document))

            SaveDocument(_Session, Documents)

        End Sub
        Public Sub DownloadAndPrintSelectedDocuments()

            DownloadSelectedDocument(True)

        End Sub
        Public Sub DownloadSelectedDocument(Optional ByVal Print As Boolean = False)

            'objects
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentIDs As Generic.List(Of Integer) = Nothing

            If DataGridViewForm_Documents.HasASelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DocumentIDs = New Generic.List(Of Integer)

                    For RowHandle = 0 To DataGridViewForm_Documents.CurrentView.RowCount - 1

                        GridView = DataGridViewForm_Documents.CurrentView.GetDetailView(RowHandle, 0)

                        If DataGridViewForm_Documents.CurrentView.IsRowSelected(RowHandle) OrElse (GridView IsNot Nothing AndAlso GridView.SelectedRowsCount > 0) Then

                            If GridView IsNot Nothing AndAlso GridView.SelectedRowsCount > 0 Then

                                For DetailRowHandle = 0 To GridView.RowCount - 1

                                    If GridView.IsRowSelected(DetailRowHandle) Then

                                        DocumentIDs.Add(GridView.GetRowCellValue(DetailRowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.ID.ToString))

                                    End If

                                Next

                            Else

                                If DataGridViewForm_Documents.CurrentView.Columns(AdvantageFramework.Database.Classes.DetailDocument.Properties.DOCUMENT_ID.ToString) IsNot Nothing Then

                                    DocumentIDs.Add(DataGridViewForm_Documents.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.DetailDocument.Properties.DOCUMENT_ID.ToString))

                                Else

                                    DocumentIDs.Add(DataGridViewForm_Documents.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.ID.ToString))

                                End If

                            End If

                        End If

                    Next

                    Try

                        Documents = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                     Where DocumentIDs.Contains(Entity.ID)
                                     Select Entity).ToList

                    Catch ex As Exception

                    End Try

                    If Documents IsNot Nothing Then

                        SaveDocument(_Session, Documents, Print, Me.WebBrowserForm_Print)

                    End If

                End Using

            End If

        End Sub
        Public Function DeleteSelectedDocument(Optional ByVal DeleteExpenseDetailDocumentOnly As Boolean = False) As Boolean

            'objects
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Deleted As Boolean = False
            Dim Message As String = ""
            Dim DeleteDocument As Boolean = True

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Deleting...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, GetSelectedDocumentID())

                            If Document IsNot Nothing Then

                                If DeleteLevelDocument(DbContext, DataContext, Document, DeleteExpenseDetailDocumentOnly) Then

                                    If _DocumentLevel = Database.Entities.DocumentLevel.MediaTrafficDetail Then

                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT count(1) FROM dbo.MEDIA_TRAFFIC_DETAIL_DOCUMENT WHERE DOCUMENT_ID = {0}", Document.ID)).First > 0 Then

                                            DeleteDocument = False

                                        End If

                                    End If

                                    If DeleteExpenseDetailDocumentOnly = False AndAlso DeleteDocument Then

                                        If AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document) Then

                                            'Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                            'If Document.MIMEType = "URL" OrElse AdvantageFramework.FileSystem.Delete(Agency, Document.FileSystemFileName) Then

                                            Deleted = True

                                            'End If

                                        End If

                                    Else

                                        Deleted = True

                                    End If

                                    LoadDocuments()

                                End If

                            End If

                        End Using

                    End Using

                Catch ex As Exception
                    Deleted = False
                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

            DeleteSelectedDocument = Deleted

        End Function
		Public Function UploadNewDocument(Optional ByVal DefaultDescription As String = "") As Boolean

			'objects
			Dim Uploaded As Boolean = False

			If _CanUpload Then

				If DefaultDescription = "" AndAlso _DocumentLevel = Database.Entities.DocumentLevel.AccountPayableInvoice Then

					DefaultDescription = GetDefaultDescription()

				End If

				If AdvantageFramework.Desktop.Presentation.DocumentUploadDialog.ShowFormDialog(_DocumentLevel, _DocumentLevelSettings.FirstOrDefault, _DocumentSubLevel, DefaultDescription) = Windows.Forms.DialogResult.OK Then

					Uploaded = True

					LoadDocuments()

				End If

			End If

			UploadNewDocument = Uploaded

		End Function
		Public Function SendASPUploadEmail(Optional ByVal DefaultDescription As String = "") As Boolean

			'objects
			Dim EmailSent As Boolean = False

			If _CanUpload Then

				If DefaultDescription = "" AndAlso _DocumentLevel = Database.Entities.DocumentLevel.AccountPayableInvoice Then

					DefaultDescription = GetDefaultDescription()

				End If

				If AdvantageFramework.WinForm.Presentation.SendASPUploadEmail(_Session, _DocumentLevel, _DocumentSubLevel, _DocumentLevelSettings.FirstOrDefault) Then

					EmailSent = True

					AdvantageFramework.WinForm.MessageBox.Show("Upload email sent!")

				End If

			End If

			SendASPUploadEmail = EmailSent

		End Function
		Public Function UploadNewDocument(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
										  Optional ByVal DocumentSublevel As AdvantageFramework.Database.Entities.DocumentSubLevel = AdvantageFramework.Database.Entities.DocumentSubLevel.Default,
										  Optional ByVal DefaultDescription As String = "") As Boolean

			'objects
			Dim Uploaded As Boolean = False
			Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

			If _CanUpload Then

				If DefaultDescription = "" AndAlso DocumentLevel = Database.Entities.DocumentLevel.AccountPayableInvoice Then

					DefaultDescription = GetDefaultDescription()

				End If

				_DocumentLevel = DocumentLevel

				DocumentLevelSetting = GetDocumentLevelSetting()

				If AdvantageFramework.Desktop.Presentation.DocumentUploadDialog.ShowFormDialog(DocumentLevel, DocumentLevelSetting, DocumentSublevel, DefaultDescription) = Windows.Forms.DialogResult.OK Then

					Uploaded = True

					LoadDocuments()

				End If

			End If

			UploadNewDocument = Uploaded

		End Function
		Public Function SendASPUploadEmail(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
										   Optional ByVal DocumentSublevel As AdvantageFramework.Database.Entities.DocumentSubLevel = AdvantageFramework.Database.Entities.DocumentSubLevel.Default,
										   Optional ByVal DefaultDescription As String = "") As Boolean

			'objects
			Dim EmailSent As Boolean = False
			Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

			If _CanUpload Then

				If DefaultDescription = "" AndAlso DocumentLevel = Database.Entities.DocumentLevel.AccountPayableInvoice Then

					DefaultDescription = GetDefaultDescription()

				End If

				_DocumentLevel = DocumentLevel

				DocumentLevelSetting = GetDocumentLevelSetting()

				If AdvantageFramework.WinForm.Presentation.SendASPUploadEmail(_Session, DocumentLevel, DocumentSublevel, DocumentLevelSetting) Then

					EmailSent = True

					AdvantageFramework.WinForm.MessageBox.Show("Upload email sent!")

				End If

			End If

			SendASPUploadEmail = EmailSent

		End Function
		Public Sub ClearControl()

            DataGridViewForm_Documents.ClearDatasource(New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        'Public Sub OpenDocument()

        '    'objects
        '    Dim SelectedDocumentID As Long = Nothing
        '    Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        '    Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        '    Dim TempFileLocation As String = ""
        '    Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        '    Dim NewFileName As String = ""
        '    Dim Process As System.Diagnostics.Process = Nothing

        '    If DataGridViewForm_Documents.HasOnlyOneSelectedRow AndAlso _IsSelectedDocumentAURL = False Then

        '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

        '            GridView = DataGridViewForm_Documents.CurrentView.GetDetailView(DataGridViewForm_Documents.CurrentView.FocusedRowHandle, 0)

        '            If GridView IsNot Nothing AndAlso GridView.IsFocusedView Then

        '                SelectedDocumentID = CLng(GridView.GetRowCellValue(GridView.FocusedRowHandle, AdvantageFramework.Database.Entities.Document.Properties.ID.ToString))

        '            Else

        '                SelectedDocumentID = CLng(DataGridViewForm_Documents.GetFirstSelectedRowBookmarkValue)

        '            End If

        '            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, SelectedDocumentID)

        '            If Document IsNot Nothing Then

        '                TempFileLocation = My.Computer.FileSystem.CurrentDirectory & "\" & System.Guid.NewGuid.ToString

        '                My.Computer.FileSystem.CreateDirectory(TempFileLocation)

        '                AdvantageFramework.FileSystem.Download(Agency, Document, TempFileLocation, NewFileName)

        '                If My.Computer.FileSystem.FileExists(NewFileName) Then

        '                    Process = New System.Diagnostics.Process

        '                    Process.StartInfo.FileName = NewFileName

        '                    Process.StartInfo.Arguments = "/r"

        '                    Process.Start()

        '                    Process.WaitForExit()

        '                    My.Computer.FileSystem.DeleteDirectory(TempFileLocation, FileIO.DeleteDirectoryOption.DeleteAllContents)

        '                End If

        '            End If

        '        End Using

        '    End If

        'End Sub        
        Public Function UploadToProofHQ() As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim DocumentID As Integer = 0
            Dim ProofHQFileID As Integer = 0
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim Document As AdvantageFramework.DocumentManager.Classes.Document = Nothing

            If Me.HasOnlyOneSelectedDocument Then

                DocumentID = GetSelectedDocumentID()

                DocumentList = LoadRelatedDocuments(DocumentID, GetSelectedDocumentFileName())

                Try

                    Document = DocumentList.Where(Function(Entity) Entity.ProofHQFileID.GetValueOrDefault(0) > 0).OrderBy(Function(Entity) Entity.ID).FirstOrDefault

                Catch ex As Exception
                    Document = Nothing
                End Try

                If Document IsNot Nothing Then

                    ProofHQFileID = Document.ProofHQFileID.GetValueOrDefault(0)

                End If

                If AdvantageFramework.Desktop.Presentation.ProofHQUploadDocumentDialog.ShowFormDialog(GetSelectedDocumentID(), _DocumentLevel, _DocumentLevelSettings.FirstOrDefault, _DocumentSubLevel, ProofHQFileID) = Windows.Forms.DialogResult.OK Then

                    Uploaded = True

                End If

            End If

            UploadToProofHQ = Uploaded

        End Function
        Public Function DownloadFromProofHQ() As Boolean

            'objects
            Dim Downloaded As Boolean = False
            Dim DocumentID As Integer = 0

            If AdvantageFramework.Desktop.Presentation.ProofHQDownloadDocumentDialog.ShowFormDialog(DocumentID, _DocumentLevel, _DocumentLevelSettings.FirstOrDefault, _DocumentSubLevel) = Windows.Forms.DialogResult.OK Then

                LoadDocuments()

                Downloaded = True

            End If

            DownloadFromProofHQ = Downloaded

        End Function
        Public Function Save(ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs As IEnumerable(Of Integer) = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing

            DocumentList = DataGridViewForm_Documents.GetAllModifiedRows.OfType(Of AdvantageFramework.DocumentManager.Classes.Document)().ToList

            DocumentIDs = DocumentList.Select(Function(D) D.ID).ToArray

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Documents = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                             Where DocumentIDs.Contains(Entity.ID)
                             Select Entity).ToList

                Try

                    For Each Document In Documents

                        Document.Description = DocumentList.Where(Function(D) D.ID = Document.ID).FirstOrDefault.Description
                        Document.DocumentTypeID = DocumentList.Where(Function(D) D.ID = Document.ID).FirstOrDefault.DocumentTypeID

                        If AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document) = False Then

                            Throw New Exception("One or more documents failed to save.")

                        End If

                    Next

                    Saved = True

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

            End Using

            Save = Saved

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub DocumentManagerControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewForm_Documents_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewForm_Documents.CustomDrawCellEvent

            'objects
            Dim FileType As AdvantageFramework.FileSystem.FileTypes = Nothing

            If e.Column.VisibleIndex = 0 Then

                FileType = DataGridViewForm_Documents.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.FileType.ToString)

                If FileType = FileSystem.FileTypes.URL Then

                    DirectCast(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo).CellButtonRect = System.Drawing.Rectangle.Empty

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Documents_RowDoubleClickEvent() Handles DataGridViewForm_Documents.RowDoubleClickEvent

            If _DisableGridActions = False Then

                DownloadSelectedDocument()

            End If

        End Sub
        Private Sub DataGridViewForm_Documents_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_Documents.SelectionChangedEvent

            'objects
            Dim FileType As AdvantageFramework.FileSystem.FileTypes = Nothing

            Try

                FileType = DirectCast(DataGridViewForm_Documents.CurrentView.GetRowCellValue(DataGridViewForm_Documents.CurrentView.FocusedRowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.FileType.ToString), AdvantageFramework.FileSystem.FileTypes)

                If FileType = FileSystem.FileTypes.URL Then

                    _IsSelectedDocumentAURL = True

                Else

                    _IsSelectedDocumentAURL = False

                End If

            Catch ex As Exception
                _IsSelectedDocumentAURL = False
            End Try

            RaiseEvent SelectedDocumentChanged()

        End Sub
        Private Sub DataGridViewForm_Documents_MasterRowEmptyEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewForm_Documents.MasterRowEmptyEvent

            If _ShowDocumentHistory Then

                e.IsEmpty = False

            End If

        End Sub
        Private Sub DataGridViewForm_Documents_MasterRowGetChildListEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewForm_Documents.MasterRowGetChildListEvent

            'objects
            Dim DocumentID As Integer = 0
            Dim DocFileName As String = ""
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If _ShowDocumentHistory Then

                If e.ChildList Is Nothing Then

                    Try
                        DocumentID = DataGridViewForm_Documents.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.ID.ToString)

                    Catch ex As Exception
                        DocumentID = 0
                    End Try

                    Try
                        DocFileName = DataGridViewForm_Documents.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.DocumentManager.Classes.Document.Properties.FileName.ToString)

                    Catch ex As Exception
                        DocFileName = ""
                    End Try

                    If DocumentID > 0 AndAlso DocFileName <> "" Then

                        DocumentList = LoadRelatedDocuments(DocumentID, DocFileName)

                        If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                            e.ChildList = (From Entity In DocumentList.ToList
                                           Order By Entity.UploadedDate Descending
                                           Select Entity.ID,
                                                  Entity.FileName,
                                                  Entity.Description,
                                                  Entity.Keywords,
                                                  Entity.DocumentTypeID,
                                                  Entity.FileSize,
                                                  Entity.UserCode,
                                                  [UploadedDate] = Entity.UploadedDate.ToString,
                                                  [IsPrivate] = CBool(Entity.IsPrivate.GetValueOrDefault(0)),
                                                  Entity.ProofHQUrl).ToList

                        Else

                            e.ChildList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Documents_MasterRowGetLevelDefaultViewEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles DataGridViewForm_Documents.MasterRowGetLevelDefaultViewEvent

            If _ShowDocumentHistory Then

                e.DefaultView = _GridViewDocumentHistory

            End If

        End Sub
        Private Sub DataGridViewForm_Documents_MasterRowGetRelationCountEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewForm_Documents.MasterRowGetRelationCountEvent

            If _ShowDocumentHistory Then

                e.RelationCount = 1

            End If

        End Sub
        Private Sub DataGridViewForm_Documents_MasterRowGetRelationNameEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewForm_Documents.MasterRowGetRelationNameEvent

            If _ShowDocumentHistory Then

                If e.RelationIndex = 0 Then

                    e.RelationName = "Document History"

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Documents_MasterRowExpandedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewForm_Documents.MasterRowExpandedEvent

            Try

                DirectCast(DataGridViewForm_Documents.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex), DevExpress.XtraGrid.Views.Grid.GridView).BestFitColumns()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub _GridViewDocumentHistory_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles _GridViewDocumentHistory.RowClick

            If _DisableGridActions = False Then

                If e.Clicks > 1 Then

                    DownloadSelectedDocument()

                    e.Handled = True

                End If

            End If

        End Sub
        Private Sub WebBrowserForm_Print_DocumentCompleted(sender As Object, e As Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowserForm_Print.DocumentCompleted

            WebBrowserForm_Print.Print()

            AdvantageFramework.WinForm.MessageBox.Show("Document printed.")

        End Sub
        Private Sub DataGridViewForm_Documents_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Documents.ShowingEditorEvent

            If _IsEditable Then

                If DataGridViewForm_Documents.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DocumentManager.Classes.Document.Properties.Description.ToString AndAlso
                        DataGridViewForm_Documents.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DocumentManager.Classes.Document.Properties.DocumentTypeID.ToString Then

                    e.Cancel = True

                End If

            End If

        End Sub

#End Region

        '#Region "  Document Levels "

        '#Region "  Client Documents "

        '        Private Function LoadClientDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim ClientDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ClientDocument) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim ClientCodes As IEnumerable(Of String) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '                        Try

        '                            ClientCodes = (From DLS In _DocumentLevelSettings _
        '                                           Where String.IsNullOrWhiteSpace(DLS.ClientCode) = False _
        '                                           Select DLS.ClientCode).ToArray

        '                            ClientDocuments = (From ClientDocument In AdvantageFramework.Database.Procedures.ClientDocument.LoadCurrentByClientCodes(DataContext, ClientCodes).ToList _
        '                                               Where _DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.ClientCode = ClientDocument.ClientCode).Any _
        '                                               Select ClientDocument).ToList

        '                            DocumentIDs = ClientDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                            If _AllowPrivateAccess = False Then

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) AndAlso
        '                                                      (Document.IsPrivate Is Nothing OrElse _
        '                                                       Document.IsPrivate = 0) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Client)).ToList

        '                            Else

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Client)).ToList

        '                            End If

        '                        Catch ex As Exception
        '                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                        End Try

        '                    End Using

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadClientDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedClientDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                                                    ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim ClientDocument As AdvantageFramework.Database.Entities.ClientDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ClientDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                ClientDocument = AdvantageFramework.Database.Procedures.ClientDocument.LoadByDocumentID(DataContext, DocumentID)

        '                If ClientDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.ClientDocument.LoadRelated(DataContext, ClientDocument.ClientCode, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Client)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedClientDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteClientDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteClientDocument = AdvantageFramework.Database.Procedures.ClientDocument.Delete(DataContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Division Documents "

        '        Private Function LoadDivisionDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim DivisionDocuments As Generic.List(Of AdvantageFramework.Database.Entities.DivisionDocument) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim ClientDivisionCodes As IEnumerable(Of String) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '                        Try

        '                            ClientDivisionCodes = (From DLS In _DocumentLevelSettings _
        '                                                   Where String.IsNullOrWhiteSpace(DLS.ClientCode) = False AndAlso _
        '                                                         String.IsNullOrWhiteSpace(DLS.DivisionCode) = False
        '                                                   Select [Code] = DLS.ClientCode & "|" & DLS.DivisionCode).ToArray

        '                            DivisionDocuments = (From DivisionDocument In AdvantageFramework.Database.Procedures.DivisionDocument.LoadCurrentByClientDivisionCodes(DataContext, ClientDivisionCodes).ToList _
        '                                                 Select DivisionDocument).ToList

        '                            DocumentIDs = DivisionDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                            If _AllowPrivateAccess = False Then

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) AndAlso
        '                                                      (Document.IsPrivate Is Nothing OrElse _
        '                                                       Document.IsPrivate = 0) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Division)).ToList

        '                            Else

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Division)).ToList

        '                            End If

        '                        Catch ex As Exception
        '                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                        End Try

        '                    End Using

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadDivisionDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedDivisionDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                                                      ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim DivisionDocument As AdvantageFramework.Database.Entities.DivisionDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.DivisionDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                DivisionDocument = AdvantageFramework.Database.Procedures.DivisionDocument.LoadByDocumentID(DataContext, DocumentID)

        '                If DivisionDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.DivisionDocument.LoadRelated(DataContext, DivisionDocument.ClientCode, DivisionDocument.DivisionCode, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Division)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedDivisionDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteDivisionDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteDivisionDocument = AdvantageFramework.Database.Procedures.DivisionDocument.Delete(DataContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Product Documents "

        '        Private Function LoadProductDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim ProductDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ProductDocument) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim ClientDivisionProductCodes As IEnumerable(Of String) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '                        Try

        '                            ClientDivisionProductCodes = (From DLS In _DocumentLevelSettings _
        '                                                          Where String.IsNullOrWhiteSpace(DLS.ClientCode) = False AndAlso _
        '                                                                String.IsNullOrWhiteSpace(DLS.DivisionCode) = False AndAlso _
        '                                                                String.IsNullOrWhiteSpace(DLS.ProductCode) = False
        '                                                          Select [Code] = DLS.ClientCode & "|" & DLS.DivisionCode & "|" & DLS.ProductCode).ToArray

        '                            ProductDocuments = (From ProductDocument In AdvantageFramework.Database.Procedures.ProductDocument.LoadCurrentByClientDivisionProductCodes(DataContext, ClientDivisionProductCodes).ToList _
        '                                                Select ProductDocument).ToList

        '                            DocumentIDs = ProductDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                            If _AllowPrivateAccess = False Then

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) AndAlso
        '                                                      (Document.IsPrivate Is Nothing OrElse _
        '                                                       Document.IsPrivate = 0) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Product)).ToList

        '                            Else

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Product)).ToList

        '                            End If

        '                        Catch ex As Exception
        '                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                        End Try

        '                    End Using

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadProductDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedProductDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                                                     ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim ProductDocument As AdvantageFramework.Database.Entities.ProductDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ProductDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                ProductDocument = AdvantageFramework.Database.Procedures.ProductDocument.LoadByDocumentID(DataContext, DocumentID)

        '                If ProductDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.ProductDocument.LoadRelated(DataContext, ProductDocument.ClientCode, ProductDocument.DivisionCode, ProductDocument.ProductCode, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Product)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedProductDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteProductDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteProductDocument = AdvantageFramework.Database.Procedures.ProductDocument.Delete(DataContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Campaign Documents "

        '        Private Function LoadCampaignDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim CampaignDocuments As Generic.List(Of AdvantageFramework.Database.Entities.CampaignDocument) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim CampaignIDs As IEnumerable(Of Integer) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '                        Try

        '                            CampaignIDs = (From DLS In _DocumentLevelSettings _
        '                                           Where String.IsNullOrWhiteSpace(DLS.CampaignID) = False _
        '                                           Select CInt(DLS.CampaignID)).ToArray

        '                            CampaignDocuments = (From CampaignDocument In AdvantageFramework.Database.Procedures.CampaignDocument.LoadCurrentByCampaignIDs(DataContext, CampaignIDs) _
        '                                                 Select CampaignDocument).ToList

        '                            DocumentIDs = CampaignDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                            If _AllowPrivateAccess = False Then

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) AndAlso
        '                                                      (Document.IsPrivate Is Nothing OrElse _
        '                                                       Document.IsPrivate = 0) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Campaign)).ToList

        '                            Else

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Campaign)).ToList

        '                            End If

        '                        Catch ex As Exception
        '                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                        End Try

        '                    End Using

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadCampaignDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedCampaignDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                                                      ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim CampaignDocument As AdvantageFramework.Database.Entities.CampaignDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.CampaignDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                CampaignDocument = AdvantageFramework.Database.Procedures.CampaignDocument.LoadByDocumentID(DataContext, DocumentID)

        '                If CampaignDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.CampaignDocument.LoadRelated(DataContext, CampaignDocument.CampaignID, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Campaign)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedCampaignDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteCampaignDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteCampaignDocument = AdvantageFramework.Database.Procedures.CampaignDocument.Delete(DataContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Employee Documents "

        '        Private Function LoadEmployeeDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim EmployeeDocuments As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeDocument) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim EmployeeCodes As IEnumerable(Of String) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '                        Try

        '                            EmployeeCodes = (From DLS In _DocumentLevelSettings _
        '                                             Where String.IsNullOrWhiteSpace(DLS.EmployeeCode) = False _
        '                                             Select DLS.EmployeeCode).ToArray

        '                            EmployeeDocuments = (From EmployeeDocument In AdvantageFramework.Database.Procedures.EmployeeDocument.LoadCurrentByEmployeeCodes(DataContext, EmployeeCodes).ToList _
        '                                                 Select EmployeeDocument).ToList

        '                            DocumentIDs = EmployeeDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                            If _AllowPrivateAccess = False Then

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                                         Where DocumentIDs.Contains(Document.ID) AndAlso
        '                                                                               (Document.IsPrivate Is Nothing OrElse _
        '                                                                                Document.IsPrivate = 0) _
        '                                                                         Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Employee)).ToList

        '                            Else

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                                         Where DocumentIDs.Contains(Document.ID) _
        '                                                                         Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Employee)).ToList

        '                            End If

        '                        Catch ex As Exception
        '                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                        End Try

        '                    End Using

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadEmployeeDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedEmployeeDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                                                      ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim EmployeeDocument As AdvantageFramework.Database.Entities.EmployeeDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                EmployeeDocument = AdvantageFramework.Database.Procedures.EmployeeDocument.LoadByDocumentID(DataContext, DocumentID)

        '                If EmployeeDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.EmployeeDocument.LoadRelated(DataContext, EmployeeDocument.EmployeeCode, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Employee)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedEmployeeDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteEmployeeDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteEmployeeDocument = AdvantageFramework.Database.Procedures.EmployeeDocument.Delete(DataContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Expense Documents "

        '        Private Function LoadExpenseDetailDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            LoadExpenseDetailDocuments = AdvantageFramework.DocumentManager.LoadExpenseDetailDocuments(_DocumentLevelSettings, _Session, _AllowPrivateAccess)

        '        End Function
        '        Private Function LoadExpenseDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim ExpenseInvoiceNumbers() As Integer = Nothing
        '            Dim DocumentIDs() As Integer = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Try

        '                        ExpenseInvoiceNumbers = (From DocLevelSetting In _DocumentLevelSettings _
        '                                                 Where DocLevelSetting.ExpenseReportInvoiceNumber IsNot Nothing _
        '                                                 Select CInt(DocLevelSetting.ExpenseReportInvoiceNumber)).ToArray

        '                        If _AllowPrivateAccess = False Then

        '                            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ED.DOCUMENT_ID FROM dbo.EXPENSE_DOCS ED " & _
        '                                                                                                    "INNER JOIN dbo.EXPENSE_HEADER EH ON ED.INV_NBR = EH.INV_NBR " & _
        '                                                                                                    "INNER JOIN dbo.DOCUMENTS D ON ED.DOCUMENT_ID = D.DOCUMENT_ID " & _
        '                                                                                                    "WHERE (EH.EMP_CODE = '{0}' OR D.PRIVATE_FLAG IS NULL OR D.PRIVATE_FLAG = 0) " & _
        '                                                                                                    "AND EH.INV_NBR IN ({2})", _Session.User.EmployeeCode, _Session.UserCode, String.Join(",", ExpenseInvoiceNumbers))).ToArray

        '                        Else

        '                            DocumentIDs = (From ExpenseReportDocument In AdvantageFramework.Database.Procedures.ExpenseReportDocument.Load(DbContext) _
        '                                           Where ExpenseInvoiceNumbers.Contains(ExpenseReportDocument.InvoiceNumber) = True _
        '                                           Select ExpenseReportDocument.DocumentID).ToArray

        '                        End If

        '                        DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                        Where DocumentIDs.Contains(Document.ID) = True _
        '                                        Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ExpenseReceipts)).ToList

        '                    Catch ex As Exception
        '                        DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                    End Try

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadExpenseDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedExpenseReportDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, _
        '                                                           ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                ExpenseReportDocument = AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadByDocumentID(DbContext, DocumentID)

        '                If ExpenseReportDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadRelated(DbContext, ExpenseReportDocument.InvoiceNumber, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ExpenseReceipts)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedExpenseReportDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteExpenseDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, _
        '                                               ByVal DeleteExpenseDetailDocumentOnly As Boolean, Optional ByVal ExpenseDetailID As String = Nothing) As Boolean

        '            'objects
        '            Dim Deleted As Boolean = False

        '            If DeleteExpenseDetailDocumentOnly Then

        '                Deleted = AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Delete(DbContext, DocumentID, ExpenseDetailID)

        '            Else

        '                Deleted = AdvantageFramework.Database.Procedures.ExpenseReportDocument.Delete(DbContext, DocumentID)

        '            End If

        '            DeleteExpenseDocument = Deleted

        '        End Function

        '#End Region

        '#Region "  Vendor Documents "

        '        Private Function LoadVendorDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim VendorDocuments As Generic.List(Of AdvantageFramework.Database.Entities.VendorDocument) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim VendorCodes As IEnumerable(Of String) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '                        Try

        '                            VendorCodes = (From DLS In _DocumentLevelSettings _
        '                                             Where String.IsNullOrWhiteSpace(DLS.VendorCode) = False _
        '                                             Select DLS.VendorCode).ToArray

        '                            VendorDocuments = (From VendorDocument In AdvantageFramework.Database.Procedures.VendorDocument.LoadCurrentByVendorCodes(DataContext, VendorCodes).ToList _
        '                                               Select VendorDocument).ToList

        '                            DocumentIDs = VendorDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                            If _AllowPrivateAccess = False Then

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) AndAlso
        '                                                      (Document.IsPrivate Is Nothing OrElse _
        '                                                       Document.IsPrivate = 0) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Vendor)).ToList

        '                            Else

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Vendor)).ToList

        '                            End If

        '                        Catch ex As Exception
        '                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                        End Try

        '                    End Using

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadVendorDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedVendorDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                                                    ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim VendorDocument As AdvantageFramework.Database.Entities.VendorDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.VendorDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                VendorDocument = AdvantageFramework.Database.Procedures.VendorDocument.LoadByDocumentID(DataContext, DocumentID)

        '                If VendorDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.VendorDocument.LoadRelated(DataContext, VendorDocument.VendorCode, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Vendor)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedVendorDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteVendorDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteVendorDocument = AdvantageFramework.Database.Procedures.VendorDocument.Delete(DataContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Job Documents "

        '        Private Function LoadJobDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim JobNumbers As IEnumerable(Of Integer) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '                        Try

        '                            JobNumbers = _DocumentLevelSettings.Where(Function(Entity) Entity.JobNumber <> "").Select(Function(Entity) CInt(Entity.JobNumber)).ToArray

        '                            DocumentIDs = (From JobDocument In AdvantageFramework.Database.Procedures.JobDocument.LoadCurrentByJobNumbers(DataContext, JobNumbers) _
        '                                           Select JobDocument.DocumentID).ToArray

        '                            If _AllowPrivateAccess Then

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Job)).ToList

        '                            Else

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) AndAlso _
        '                                                      (Document.IsPrivate Is Nothing OrElse _
        '                                                       Document.IsPrivate = 0) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Job)).ToList

        '                            End If

        '                        Catch ex As Exception
        '                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                        End Try

        '                    End Using

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadJobDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedJobDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                                                 ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim JobDocument As AdvantageFramework.Database.Entities.JobDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.JobDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                JobDocument = AdvantageFramework.Database.Procedures.JobDocument.LoadByDocumentID(DataContext, DocumentID)

        '                If JobDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.JobDocument.LoadRelated(DataContext, JobDocument.JobNumber, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Job)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedJobDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteJobDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteJobDocument = AdvantageFramework.Database.Procedures.JobDocument.Delete(DataContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Job Component Documents "

        '        Private Function LoadJobComponentDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim JobNumberComponents As IEnumerable(Of String) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '                        Try

        '                            JobNumberComponents = (From DLS In _DocumentLevelSettings _
        '                                                   Where String.IsNullOrWhiteSpace(DLS.JobNumber) = False AndAlso _
        '                                                         String.IsNullOrWhiteSpace(DLS.JobComponentNumber) = False
        '                                                   Select [Code] = DLS.JobNumber & "|" & DLS.JobComponentNumber).ToArray

        '                            DocumentIDs = (From JobComponentDocument In AdvantageFramework.Database.Procedures.JobComponentDocument.LoadCurrentByJobNumberComponents(DataContext, JobNumberComponents).ToList _
        '                                           Select JobComponentDocument.DocumentID).ToArray

        '                            If _AllowPrivateAccess Then

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.JobComponent)).ToList

        '                            Else

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) AndAlso _
        '                                                      (Document.IsPrivate Is Nothing OrElse _
        '                                                       Document.IsPrivate = 0) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.JobComponent)).ToList

        '                            End If

        '                        Catch ex As Exception
        '                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                        End Try

        '                    End Using

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadJobComponentDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedJobComponentDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                                                          ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim JobComponentDocument As AdvantageFramework.Database.Entities.JobComponentDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                JobComponentDocument = AdvantageFramework.Database.Procedures.JobComponentDocument.LoadByDocumentID(DataContext, DocumentID)

        '                If JobComponentDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.JobComponentDocument.LoadRelated(DataContext, JobComponentDocument.JobNumber, JobComponentDocument.JobComponentNumber, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.JobComponent)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedJobComponentDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteJobComponentDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteJobComponentDocument = AdvantageFramework.Database.Procedures.JobComponentDocument.Delete(DataContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Contract Documents "

        '        Private Function LoadContractDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim ContractDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractDocument) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim ContractIDs As IEnumerable(Of Integer) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Try

        '                        ContractIDs = (From DLS In _DocumentLevelSettings _
        '                                       Where String.IsNullOrWhiteSpace(DLS.ContractID) = False _
        '                                       Select CInt(DLS.ContractID)).ToArray

        '                        ContractDocuments = (From ContractDocument In AdvantageFramework.Database.Procedures.ContractDocument.LoadCurrentByContractIDs(DbContext, ContractIDs).ToList _
        '                                             Where _DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.ContractID = ContractDocument.ContractID).Any _
        '                                             Select ContractDocument).ToList

        '                        DocumentIDs = ContractDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

        '                        If _AllowPrivateAccess = False Then

        '                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                            Where DocumentIDs.Contains(Document.ID) AndAlso
        '                                                  (Document.IsPrivate Is Nothing OrElse _
        '                                                   Document.IsPrivate = 0) _
        '                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Contract)).ToList

        '                        Else

        '                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                            Where DocumentIDs.Contains(Document.ID) _
        '                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Contract)).ToList

        '                        End If

        '                    Catch ex As Exception
        '                        DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                    End Try

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadContractDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedContractDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, _
        '                                                      ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim ContractDocument As AdvantageFramework.Database.Entities.ContractDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                ContractDocument = AdvantageFramework.Database.Procedures.ContractDocument.LoadByDocumentID(DbContext, DocumentID)

        '                If ContractDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.ContractDocument.LoadRelated(DbContext, ContractDocument.ContractID, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Contract)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedContractDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteContractDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteContractDocument = AdvantageFramework.Database.Procedures.ContractDocument.Delete(DbContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Account Payable Documents "

        '        Private Function LoadAccountPayableInvoiceDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            LoadAccountPayableInvoiceDocuments = AdvantageFramework.DocumentManager.LoadAccountPayableInvoiceDocuments(_DocumentLevelSettings, _Session, _AllowPrivateAccess)

        '        End Function
        '        Private Function LoadRelatedAccountPayableDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                                                            ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim AccountPayableDocument As AdvantageFramework.Database.Entities.AccountPayableDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                AccountPayableDocument = AdvantageFramework.Database.Procedures.AccountPayableDocument.LoadByDocumentID(DataContext, DocumentID)

        '                If AccountPayableDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.AccountPayableDocument.LoadRelated(DataContext, AccountPayableDocument.AccountPayableID, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AccountPayableInvoice)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedAccountPayableDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteAccountPayableInvoiceDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteAccountPayableInvoiceDocument = AdvantageFramework.Database.Procedures.AccountPayableDocument.Delete(DataContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Office Documents "

        '        Private Function LoadOfficeDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim OfficeDocuments As Generic.List(Of AdvantageFramework.Database.Entities.OfficeDocument) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim OfficeCodes As IEnumerable(Of String) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Try

        '                        OfficeCodes = (From DLS In _DocumentLevelSettings _
        '                                         Where String.IsNullOrWhiteSpace(DLS.OfficeCode) = False _
        '                                         Select DLS.OfficeCode).ToArray

        '                        OfficeDocuments = (From OfficeDocument In AdvantageFramework.Database.Procedures.OfficeDocument.LoadCurrentByOfficeCodes(DbContext, OfficeCodes).ToList _
        '                                           Select OfficeDocument).ToList

        '                        DocumentIDs = OfficeDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

        '                        If _AllowPrivateAccess = False Then

        '                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                            Where DocumentIDs.Contains(Document.ID) AndAlso
        '                                                  (Document.IsPrivate Is Nothing OrElse _
        '                                                   Document.IsPrivate = 0) _
        '                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Office)).ToList

        '                        Else

        '                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                            Where DocumentIDs.Contains(Document.ID) _
        '                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Office)).ToList

        '                        End If

        '                    Catch ex As Exception
        '                        DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                    End Try

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadOfficeDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedOfficeDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, _
        '                                                    ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim OfficeDocument As AdvantageFramework.Database.Entities.OfficeDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.OfficeDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                OfficeDocument = AdvantageFramework.Database.Procedures.OfficeDocument.LoadByDocumentID(DbContext, DocumentID)

        '                If OfficeDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.OfficeDocument.LoadRelated(DbContext, OfficeDocument.OfficeCode, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Office)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedOfficeDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteOfficeDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteOfficeDocument = AdvantageFramework.Database.Procedures.OfficeDocument.Delete(DbContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Ad Number Documents "

        '        Private Function LoadAdNumberDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim Ads As Generic.List(Of AdvantageFramework.Database.Entities.Ad) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Try

        '                        Ads = (From Ad In AdvantageFramework.Database.Procedures.Ad.Load(DbContext).ToList _
        '                               Where _DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.AdNumber = Ad.Number).Any _
        '                               Select Ad).ToList

        '                        DocumentIDs = Ads.Where(Function(Entity) Entity.DocumentID.HasValue).Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

        '                        If _AllowPrivateAccess = False Then

        '                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                            Where DocumentIDs.Contains(Document.ID) AndAlso
        '                                                  (Document.IsPrivate Is Nothing OrElse _
        '                                                   Document.IsPrivate = 0) _
        '                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AdNumber)).ToList

        '                        Else

        '                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                            Where DocumentIDs.Contains(Document.ID) _
        '                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AdNumber)).ToList

        '                        End If

        '                    Catch ex As Exception
        '                        DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                    End Try

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadAdNumberDocuments = DocumentList

        '        End Function
        '        Private Function DeleteAdDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

        '            'objects
        '            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
        '            Dim Deleted As Boolean = False

        '            Try

        '                Ad = (From Entity In AdvantageFramework.Database.Procedures.Ad.Load(DbContext) _
        '                      Where Entity.DocumentID = DocumentID _
        '                      Select Entity).SingleOrDefault

        '            Catch ex As Exception
        '                Ad = Nothing
        '            End Try

        '            If Ad IsNot Nothing Then

        '                Ad.DocumentID = Nothing

        '                Deleted = AdvantageFramework.Database.Procedures.Ad.Update(DbContext, Ad)

        '            End If

        '            DeleteAdDocument = Deleted

        '        End Function

        '#End Region

        '#Region "  Account Receivable Documents "

        '        Private Function LoadAccountReceivableInvoiceDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            LoadAccountReceivableInvoiceDocuments = AdvantageFramework.DocumentManager.LoadAccountReceivableInvoiceDocuments(_DocumentLevelSettings, _Session, _AllowPrivateAccess)

        '        End Function
        '        Private Function LoadRelatedAccountReceivableInvoiceDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, _
        '                                                                      ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim AccountReceivableDocument As AdvantageFramework.Database.Entities.AccountReceivableDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.AccountReceivableDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                AccountReceivableDocument = AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadByDocumentID(DbContext, DocumentID)

        '                If AccountReceivableDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadRelated(DbContext, AccountReceivableDocument.InvoiceNumber, AccountReceivableDocument.SequenceNumber, AccountReceivableDocument.Type, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

        '                    DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Document.ID) _
        '                                    Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AccountReceivableInvoice)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedAccountReceivableInvoiceDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteAccountReceivableInvoiceDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteAccountReceivableInvoiceDocument = AdvantageFramework.Database.Procedures.AccountReceivableDocument.Delete(DbContext, DocumentID)

        '        End Function

        '#End Region

        '#Region "  Contract Report Documents "

        '        Private Function LoadContractReportDocuments() As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim ContractReportDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractReportDocument) = Nothing
        '            Dim DocumentIDs() As Long = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim ContractReportIDs As IEnumerable(Of Integer) = Nothing

        '            If _DocumentLevelSettings IsNot Nothing AndAlso _DocumentLevelSettings.Count > 0 Then

        '                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '                        Try

        '                            ContractReportIDs = (From DLS In _DocumentLevelSettings _
        '                                                 Where String.IsNullOrWhiteSpace(DLS.ContractReportID) = False _
        '                                                 Select CInt(DLS.ContractReportID)).ToArray

        '                            ContractReportDocuments = (From ContractReportDocument In AdvantageFramework.Database.Procedures.ContractReportDocument.LoadCurrentByContractReportIDs(DataContext, ContractReportIDs).ToList _
        '                                                       Where _DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.ContractReportID = ContractReportDocument.ContractReportID).Any _
        '                                                       Select ContractReportDocument).ToList

        '                            DocumentIDs = ContractReportDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

        '                            If _AllowPrivateAccess = False Then

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) AndAlso
        '                                                      (Document.IsPrivate Is Nothing OrElse _
        '                                                       Document.IsPrivate = 0) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ContractReport)).ToList

        '                            Else

        '                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                                Where DocumentIDs.Contains(Document.ID) _
        '                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ContractReport)).ToList

        '                            End If

        '                        Catch ex As Exception
        '                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
        '                        End Try

        '                    End Using

        '                End Using

        '            Else

        '                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            End If

        '            LoadContractReportDocuments = DocumentList

        '        End Function
        '        Private Function LoadRelatedContractReportDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                                                            ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

        '            'objects
        '            Dim ContractReportDocument As AdvantageFramework.Database.Entities.ContractReportDocument = Nothing
        '            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractReportDocument) = Nothing
        '            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        '            Dim DocumentIDs() As Long = Nothing

        '            Try

        '                ContractReportDocument = AdvantageFramework.Database.Procedures.ContractReportDocument.LoadByDocumentID(DataContext, DocumentID)

        '                If ContractReportDocument IsNot Nothing Then

        '                    RelatedDocuments = AdvantageFramework.Database.Procedures.ContractReportDocument.LoadRelated(DataContext, ContractReportDocument.ContractReportID, FileName).ToList

        '                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

        '                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext) _
        '                                    Where DocumentIDs.Contains(Entity.ID) _
        '                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ContractReport)).ToList

        '                End If

        '            Catch ex As Exception
        '                DocumentList = Nothing
        '            Finally
        '                LoadRelatedContractReportDocuments = DocumentList
        '            End Try

        '        End Function
        '        Private Function DeleteContractReportDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

        '            DeleteContractReportDocument = AdvantageFramework.Database.Procedures.ContractReportDocument.Delete(DataContext, DocumentID)

        '        End Function

        '#End Region

        '#End Region

#End Region

    End Class

End Namespace
