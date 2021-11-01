Namespace Desktop.Presentation

    Public Class DocumentUploadDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
        Private _DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Nothing
        Private _DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
        Private _DefaultDescription As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting
            Get
                DocumentLevelSetting = _DocumentLevelSetting
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
                        ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting,
                        ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel,
                        ByVal DefaultDescription As String)

            ' This call is required by the designer.
            InitializeComponent()

            _DocumentLevel = DocumentLevel
            _DocumentSubLevel = DocumentSubLevel
            _DocumentLevelSetting = DocumentLevelSetting
            _DefaultDescription = DefaultDescription

        End Sub
        Private Sub CreateTreeListColumns()

            'objects
            Dim CodeTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing
            Dim DescriptionTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing

            TreeListControlAlertOptions_Recepients.BeginUpdate()

            TreeListControlAlertOptions_Recepients.Columns.Clear()
            TreeListControlAlertOptions_Recepients.OptionsView.ShowColumns = False

            CodeTreeListColumn = TreeListControlAlertOptions_Recepients.Columns.Add()
            CodeTreeListColumn.Caption = "Code"
            CodeTreeListColumn.FieldName = "Code"
            CodeTreeListColumn.VisibleIndex = -1
            CodeTreeListColumn.Visible = False
            DescriptionTreeListColumn = TreeListControlAlertOptions_Recepients.Columns.Add()
            DescriptionTreeListColumn.Caption = "Description"
            DescriptionTreeListColumn.FieldName = "Description"
            DescriptionTreeListColumn.VisibleIndex = 0
            DescriptionTreeListColumn.Visible = True

            TreeListControlAlertOptions_Recepients.OptionsView.ShowCheckBoxes = True

            TreeListControlAlertOptions_Recepients.EndUpdate()

        End Sub
        Private Sub LoadAlertGroups()

            Dim AlertGroups As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup) = Nothing
            Dim AlertGroupEmployee As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlertGroupNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim EmployeeNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim ParentTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing

            TreeListControlAlertOptions_Recepients.BeginUnboundLoad()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Session.UserCode)

                Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList
                AlertGroups = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActiveDistinctAlertGroups(DbContext).ToList

                For Each AlertGroup In AlertGroups

                    AlertGroupNode = TreeListControlAlertOptions_Recepients.AppendNode(New Object() {AlertGroup.Code, AlertGroup.Code}, ParentTreeListNode)
                    AlertGroupNode.Tag = AlertGroup

                    For Each AlertGroupEmployee In AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, AlertGroup.Code).ToList

                        Try

                            Employee = (From Entity In Employees
                                        Where Entity.Code = AlertGroupEmployee.EmployeeCode
                                        Select Entity).SingleOrDefault

                        Catch ex As Exception
                            Employee = Nothing
                        End Try

                        If Employee IsNot Nothing Then

                            EmployeeNode = TreeListControlAlertOptions_Recepients.AppendNode(New Object() {Employee.Code, Employee.ToString}, AlertGroupNode)

                            EmployeeNode.Tag = Employee

                        End If

                    Next

                Next

            End Using

            TreeListControlAlertOptions_Recepients.EndUnboundLoad()

        End Sub
        Private Sub EnableOrDisableActions()

            Dim DocumentUploadType As AdvantageFramework.Database.Entities.DocumentUploadType = Nothing

            Select Case ComboBoxGeneral_LinkOrDocument.GetSelectedValue

                Case "L"

                    DocumentUploadType = Database.Entities.DocumentUploadType.Link

                Case "D"

                    DocumentUploadType = Database.Entities.DocumentUploadType.Document

            End Select

            LabelGeneral_FilesLargerMessage.Visible = If(DocumentUploadType = Database.Entities.DocumentUploadType.Document, True, False)
            LabelGeneral_FileDetails.Visible = If(DocumentUploadType = Database.Entities.DocumentUploadType.Document, True, False)
            TextBoxGeneral_FileDetails.Visible = If(DocumentUploadType = Database.Entities.DocumentUploadType.Document, True, False)
            LabelGeneral_OnlyOneFile.Visible = If(DocumentUploadType = Database.Entities.DocumentUploadType.Document, True, False)
            LabelGeneral_LinkName.Visible = If(DocumentUploadType = Database.Entities.DocumentUploadType.Document, False, True)
            TextBoxGeneral_LinkName.Visible = If(DocumentUploadType = Database.Entities.DocumentUploadType.Document, False, True)
            LabelGeneral_LinkURL.Visible = If(DocumentUploadType = Database.Entities.DocumentUploadType.Document, False, True)
            TextBoxGeneral_LinkURL.Visible = If(DocumentUploadType = Database.Entities.DocumentUploadType.Document, False, True)

            TabItemDocumentGeneral_ExpenseItemsTab.Visible = CheckBoxGeneral_AssociateToExpenseItems.Checked
            TabItemDocumentGeneral_AlertOptionsTab.Visible = CheckBoxGeneral_SendAlert.Checked

        End Sub
        Private Function GetFinalLevelDescription() As String

            'objects
            Dim FinalLevelDescription As String = ""

            Try

                If _DocumentLevelSetting IsNot Nothing Then

                    Select Case _DocumentLevel

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                            FinalLevelDescription = _DocumentLevel.ToString & " : " & _DocumentLevelSetting.AccountPayableID

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AdNumber

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.AdNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Campaign

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.CampaignID

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Client

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.ClientCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.ClientCode & "," & _DocumentLevelSetting.DivisionCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.ExpenseReportInvoiceNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Job

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.JobNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.JobComponent

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.JobNumber & "," & _DocumentLevelSetting.JobComponentNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Office

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.OfficeCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.ClientCode & "," & _DocumentLevelSetting.DivisionCode & "," & _DocumentLevelSetting.ProductCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Employee

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.EmployeeCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Vendor

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.VendorCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.AccountReceivableInvoiceNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.OrderNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.MediaTrafficDetail

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.MediaTrafficDetailID

                        Case AdvantageFramework.Database.Entities.DocumentLevel.JournalEntry

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.GLTransaction

                        Case AdvantageFramework.Database.Entities.DocumentLevel.MediaPlan

                            FinalLevelDescription = _DocumentLevel.ToString & ":" & _DocumentLevelSetting.MediaPlanID

                    End Select

                End If

            Catch ex As Exception
                FinalLevelDescription = ""
            Finally
                GetFinalLevelDescription = FinalLevelDescription
            End Try

        End Function
        Private Function AddLevelDocument(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal DataContext As AdvantageFramework.Database.DataContext,
                                          ByVal Document As AdvantageFramework.Database.Entities.Document) As Boolean

            'objects
            Dim Added As Boolean = False

            Select Case _DocumentLevel

                Case Database.Entities.DocumentLevel.AccountPayableInvoice

                    Added = AddLevelDocument_AccountPayableInvoice(DataContext, Document.ID)

                Case Database.Entities.DocumentLevel.AdNumber

                    Added = AddLevelDocument_AdNumber(DbContext, Document.ID)

                Case Database.Entities.DocumentLevel.Campaign

                    Added = AddLevelDocument_Campaign(DataContext, Document.ID)

                Case Database.Entities.DocumentLevel.Client

                    Added = AddLevelDocument_Client(DataContext, Document.ID)

                Case Database.Entities.DocumentLevel.Division

                    Added = AddLevelDocument_Division(DataContext, Document.ID)

                Case Database.Entities.DocumentLevel.ExpenseReceipts

                    Added = AddLevelDocument_ExpenseReceipts(DbContext, Document.ID)

                Case Database.Entities.DocumentLevel.Job

                    Added = AddLevelDocument_Job(DataContext, Document.ID)

                Case Database.Entities.DocumentLevel.JobComponent

                    Added = AddLevelDocument_JobComponent(DataContext, Document.ID)

                Case Database.Entities.DocumentLevel.Office

                    Added = AddLevelDocument_Office(DbContext, Document.ID)

                Case Database.Entities.DocumentLevel.Product

                    Added = AddLevelDocument_Product(DataContext, Document.ID)

                Case Database.Entities.DocumentLevel.Employee

                    Added = AddLevelDocument_Employee(DataContext, Document.ID)

                Case Database.Entities.DocumentLevel.Vendor

                    Added = AddLevelDocument_Vendor(DataContext, Document.ID)

                Case Database.Entities.DocumentLevel.Contract

                    Added = AddLevelDocument_Contract(DbContext, Document.ID)

                Case Database.Entities.DocumentLevel.ContractValueAdded

                    Added = AddLevelDocument_ContractValueAdded(DbContext, Document.ID)

                Case Database.Entities.DocumentLevel.ContractReport

                    Added = AddLevelDocument_ContractReport(DataContext, Document.ID)

                Case Database.Entities.DocumentLevel.AccountReceivableInvoice

                    Added = AddLevelDocument_AccountReceivableInvoice(DbContext, Document.ID)

                Case Database.Entities.DocumentLevel.VendorContract

                    Added = AddLevelDocument_VendorContract(DbContext, Document.ID)

                Case Database.Entities.DocumentLevel.AgencyDesktop

                    Added = AddLevelDocument_AgencyDesktop(DbContext, Document.ID)

                Case Database.Entities.DocumentLevel.ExecutiveDesktop

                    Added = AddLevelDocument_ExecutiveDesktop(DbContext, Document.ID)

                Case AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder

                    Added = AddLevelDocument_MediaOrder(DbContext, Document.ID)

                Case AdvantageFramework.Database.Entities.DocumentLevel.MediaTrafficDetail

                    Added = AddLevelDocument_MediaTrafficDetail(DbContext, Document.ID)

                Case AdvantageFramework.Database.Entities.DocumentLevel.JournalEntry

                    Added = AddLevelDocument_JournalEntry(DbContext, Document.ID)

                Case AdvantageFramework.Database.Entities.DocumentLevel.MediaPlan

                    Added = AddLevelDocument_MediaPlan(DbContext, Document.ID)

            End Select

            AddLevelDocument = Added

        End Function
        Private Function LoadAlertEmployees() As Generic.List(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim ChildTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing

            Try

                Employees = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

                For Each TreeListNode In TreeListControlAlertOptions_Recepients.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)()

                    For Each ChildTreeListNode In TreeListNode.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)()

                        If ChildTreeListNode.Checked Then

                            Try

                                If Employees.Where(Function(Emp) Emp.Code = DirectCast(ChildTreeListNode.Tag, AdvantageFramework.Database.Views.Employee).Code).Any = False Then

                                    Employees.Add(DirectCast(ChildTreeListNode.Tag, AdvantageFramework.Database.Views.Employee))

                                End If

                            Catch ex As Exception

                            End Try

                        End If

                    Next

                Next

            Catch ex As Exception
                Employees = Nothing
            Finally
                LoadAlertEmployees = Employees
            End Try

        End Function
        Private Function UploadDocumentByDocumentType(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                                      ByVal DocumentUploadType As Database.Entities.DocumentUploadType,
                                                      ByRef Document As AdvantageFramework.Database.Entities.Document) As Boolean
            'objects
            Dim Uploaded As Boolean = False

            Select Case DocumentUploadType

                Case Database.Entities.DocumentUploadType.Document

                    Uploaded = UploadDocument(DbContext, Agency, Document)

                Case Database.Entities.DocumentUploadType.Link

                    Uploaded = UploadLink(DbContext, Document)

            End Select

            UploadDocumentByDocumentType = Uploaded

        End Function
        Private Function UploadLink(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByRef Document As AdvantageFramework.Database.Entities.Document) As Boolean

            'objects
            Dim Uploaded As Boolean = False

            Try

                Document = New AdvantageFramework.Database.Entities.Document

                Document.DbContext = DbContext
                Document.FileName = TextBoxGeneral_LinkName.Text
                Document.FileSystemFileName = TextBoxGeneral_LinkURL.Text
                Document.MIMEType = "URL"
                Document.Description = TextBoxGeneral_Description.Text
                Document.Keywords = TextBoxGeneral_Keywords.Text
                Document.UserCode = Me.Session.UserCode
                Document.FileSize = 0
                Document.UploadedDate = System.DateTime.Now
                Document.DocumentTypeID = CInt(ComboBoxGeneral_FileType.GetSelectedValue)
                Document.IsPrivate = CInt(CheckBoxGeneral_Private.CheckValue)

                Uploaded = AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document)

            Catch ex As Exception
                Uploaded = False
            Finally
                UploadLink = Uploaded
            End Try

        End Function
        Private Function UploadDocument(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                        ByRef Document As AdvantageFramework.Database.Entities.Document) As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim FileName As String = Nothing
            Dim FileSystemFile As String = Nothing
            Dim FileSystemFileName As String = Nothing
            Dim FileSize As Integer = Nothing
            Dim MimeType As String = Nothing
            Dim FinalLevelDescription As String = Nothing
            Dim FinalLevel As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                FileName = AdvantageFramework.FileSystem.GetFileName(TextBoxGeneral_FileDetails.Text)
                MimeType = AdvantageFramework.FileSystem.GetMIMEType(TextBoxGeneral_FileDetails.Text)
                FileSize = AdvantageFramework.FileSystem.GetFileSize(TextBoxGeneral_FileDetails.Text)
                FinalLevelDescription = GetFinalLevelDescription()
                FinalLevel = _DocumentLevel.ToString

                If Me.Session.User IsNot Nothing Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                End If

                If AdvantageFramework.FileSystem.Add(Agency, TextBoxGeneral_FileDetails.Text, TextBoxGeneral_Description.Text, TextBoxGeneral_Keywords.Text, If(Employee IsNot Nothing, Employee.ToString, Me.Session.UserCode), FinalLevel, FinalLevelDescription, FileSystem.DocumentSource.DocumentUpload, FileSystemFile, Nothing, FileSystemFileName) Then

                    Document = New AdvantageFramework.Database.Entities.Document

                    Document.DbContext = DbContext
                    Document.FileName = FileName
                    Document.FileSystemFileName = FileSystemFileName
                    Document.MIMEType = MimeType
                    Document.Description = TextBoxGeneral_Description.Text
                    Document.Keywords = TextBoxGeneral_Keywords.Text
                    Document.UploadedDate = System.DateTime.Now
                    Document.UserCode = Me.Session.UserCode
                    Document.FileSize = FileSize
                    Document.DocumentTypeID = CInt(ComboBoxGeneral_FileType.GetSelectedValue)
                    Document.IsPrivate = CInt(CheckBoxGeneral_Private.CheckValue)

                    Uploaded = AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document)

                End If

            Catch ex As Exception
                Uploaded = False
            Finally
                UploadDocument = Uploaded
            End Try

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
                                              ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting,
                                              Optional ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Database.Entities.DocumentSubLevel.Default,
                                              Optional ByVal DefaultDescription As String = "") As System.Windows.Forms.DialogResult

            'objects
            Dim DocumentUploadDialog As AdvantageFramework.Desktop.Presentation.DocumentUploadDialog = Nothing

            DocumentUploadDialog = New AdvantageFramework.Desktop.Presentation.DocumentUploadDialog(DocumentLevel, DocumentLevelSetting, DocumentSubLevel, DefaultDescription)

            ShowFormDialog = DocumentUploadDialog.ShowDialog()

            DocumentLevelSetting = DocumentUploadDialog.DocumentLevelSetting

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DocumentUploadDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MaxFileSize As Long = Nothing
            Dim DataContextDocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType = Nothing

            TreeListControlAlertOptions_Recepients.Nodes.Clear()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Session.UserCode)

                    TextBoxGeneral_Description.Text = _DefaultDescription

                    MaxFileSize = AdvantageFramework.FileSystem.GetDocumentRepositoryFileSizeLimit(DbContext)

                    If MaxFileSize >= 0 Then

                        TextBoxGeneral_FileDetails.MaxFileSize = MaxFileSize
                        LabelGeneral_FilesLargerMessage.Text = "Files larger than " & Math.Round((MaxFileSize / 1024) / 1024, 0).ToString & "MB will automatically be excluded."

                    Else

                        LabelGeneral_FilesLargerMessage.Text = ""

                    End If

                    TreeListControlAlertOptions_Recepients.ByPassUserEntryChanged = True

                    ComboBoxGeneral_LinkOrDocument.SetPropertySettings(AdvantageFramework.Database.Entities.Document.Properties.DocumentTypeID)
                    TextBoxGeneral_FileDetails.SetPropertySettings(AdvantageFramework.Database.Entities.Document.Properties.FileName)
                    ComboBoxGeneral_FileType.SetPropertySettings(AdvantageFramework.Database.Entities.Document.Properties.DocumentTypeID)
                    TextBoxGeneral_Description.SetPropertySettings(AdvantageFramework.Database.Entities.Document.Properties.Description)
                    TextBoxGeneral_Keywords.SetPropertySettings(AdvantageFramework.Database.Entities.Document.Properties.Keywords)

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        TextBoxGeneral_FileDetails.SetAgencyImportPath(AdvantageFramework.FileSystem.LoadHostedClientUploadLocation(DbContext), False)

                    End If

                    ComboBoxGeneral_LinkOrDocument.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.DocumentUploadType)).ToList
                                                                 Select [Name] = EnumObject.Description,
                                                                    [Value] = EnumObject.Code).ToList

                    ComboBoxAlertOptions_Category.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeID(DbContext, 6)
                                                                Where Entity.ID < 28
                                                                Select Entity
                                                                Order By Entity.Description Ascending).ToList

                    Try

                        ComboBoxAlertOptions_Category.SelectedValue = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, 6, "Action").ID

                    Catch ex As Exception

                    End Try

                    ComboBoxGeneral_FileType.DataSource = AdvantageFramework.Database.Procedures.DocumentType.LoadActive(DataContext).ToList

                    DataContextDocumentType = (From DT In AdvantageFramework.Database.Procedures.DocumentType.Load(DataContext).ToList
                                               Where DT.IsInactive.GetValueOrDefault(False) = False AndAlso
                                                     DT.IsDefault = True
                                               Select DT).FirstOrDefault

                    If DataContextDocumentType IsNot Nothing Then

                        ComboBoxGeneral_FileType.SelectedValue = DataContextDocumentType.ID

                    End If

                    ComboBoxAlertOptions_Priority.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.AlertPriority)).ToList
                                                                Select [Name] = EnumObject.Value,
                                                                   [Value] = EnumObject.Key).ToList

                    ComboBoxAlertOptions_Priority.SelectedValue = CLng(AdvantageFramework.Database.Entities.AlertPriority.Normal)

                    If _DocumentLevel = Database.Entities.DocumentLevel.ExpenseReceipts Then

                        CheckBoxGeneral_SendAlert.Visible = False
                        CheckBoxGeneral_AssociateToExpenseItems.Visible = True

                        DataGridViewExpenseItems_ExpenseItems.MultiSelect = True

                        DataGridViewExpenseItems_ExpenseItems.DataSource = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, _DocumentLevelSetting.ExpenseReportInvoiceNumber, False)
                        DataGridViewExpenseItems_ExpenseItems.CurrentView.BestFitColumns()

                        If String.IsNullOrEmpty(_DocumentLevelSetting.ExpenseDetailID) = False Then

                            DataGridViewExpenseItems_ExpenseItems.SelectRow(_DocumentLevelSetting.ExpenseDetailID)

                            CheckBoxGeneral_AssociateToExpenseItems.Checked = True

                        End If

                        DataGridViewExpenseItems_ExpenseItems.ItemDescription = "Expense Report Item(s)"

                    ElseIf _DocumentLevel = Database.Entities.DocumentLevel.JournalEntry Then

                        CheckBoxGeneral_SendAlert.Checked = False
                        CheckBoxGeneral_SendAlert.Visible = False
                        CheckBoxGeneral_AssociateToExpenseItems.Checked = False
                        CheckBoxGeneral_AssociateToExpenseItems.Visible = False

                    Else

                        TabItemDocumentGeneral_ExpenseItemsTab.Visible = False
                        CheckBoxGeneral_SendAlert.Visible = True
                        CheckBoxGeneral_AssociateToExpenseItems.Visible = False

                    End If

                End Using

            End Using

            CreateTreeListColumns()
            LoadAlertGroups()
            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Upload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Upload.Click

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AlertEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim DocumentUploadType As AdvantageFramework.Database.Entities.DocumentUploadType = Nothing
            Dim SendAlert As Boolean = Nothing
            Dim Body As String = Nothing
            Dim EmailBody As String = Nothing
            Dim PriorityLevel As Short = Nothing
            Dim Subject As String = Nothing
            Dim AlertCategoryID As Integer = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            If Me.Validator Then

                Me.ShowWaitForm("Uploading...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Select Case ComboBoxGeneral_LinkOrDocument.GetSelectedValue

                            Case "L"

                                DocumentUploadType = Database.Entities.DocumentUploadType.Link

                            Case "D"

                                DocumentUploadType = Database.Entities.DocumentUploadType.Document

                                AdvantageFramework.FileSystem.CheckRepositoryConstraints(DbContext, TextBoxGeneral_FileDetails.Text, IsValid, ErrorMessage)

                        End Select

                        If CheckBoxGeneral_SendAlert.Checked Then

                            SendAlert = True

                            AlertEmployees = LoadAlertEmployees()

                            If AlertEmployees Is Nothing OrElse AlertEmployees.Count = 0 Then

                                ErrorMessage = "Please select at least one recipient."
                                IsValid = False

                            End If

                        End If

                        If IsValid Then

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            If Agency IsNot Nothing Then

                                If UploadDocumentByDocumentType(DbContext, Agency, DocumentUploadType, Document) Then

                                    If AddLevelDocument(DbContext, DataContext, Document) Then

                                        Inserted = True

                                        If SendAlert Then

                                            Subject = TextBoxAlertOptions_Subject.Text
                                            Body = TextBoxGeneral_Description.Text & vbNewLine & vbNewLine & "Keywords: " & TextBoxGeneral_Keywords.Text
                                            EmailBody = TextBoxGeneral_Description.Text & "<br/><br/>Keywords: " & TextBoxGeneral_Keywords.Text
                                            PriorityLevel = CShort(ComboBoxAlertOptions_Priority.GetSelectedValue)
                                            AlertCategoryID = CInt(ComboBoxAlertOptions_Category.GetSelectedValue)

                                            AdvantageFramework.AlertSystem.CreateAndSendDocumentManagerAlert(Me.Session, Document, _DocumentLevel, _DocumentLevelSetting, Subject, AlertCategoryID, PriorityLevel, AlertEmployees)

                                        End If

                                    End If

                                End If

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                    End Using

                End Using

                If Inserted Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

                Me.CloseWaitForm()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub CheckBoxGeneral_SendAlert_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxGeneral_SendAlert.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxGeneral_LinkOrDocument_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxGeneral_LinkOrDocument.SelectedValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TreeListControlAlertOptions_Recepients_NodeChanged(sender As Object, e As DevExpress.XtraTreeList.NodeChangedEventArgs) Handles TreeListControlAlertOptions_Recepients.NodeChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If e.ChangeType = DevExpress.XtraTreeList.NodeChangeTypeEnum.CheckedState Then

                    Me.FormAction = WinForm.Presentation.FormActions.Modifying

                    If e.Node.Nodes.Count > 0 Then

                        If e.Node.Checked Then

                            e.Node.ExpandAll()

                        End If

                        For Each TreeListNode In e.Node.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)()

                            TreeListNode.Checked = e.Node.Checked

                        Next

                    ElseIf e.Node.ParentNode IsNot Nothing Then

                        If e.Node.Checked = False Then

                            If e.Node.ParentNode.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).Where(Function(TreeListNode) TreeListNode.Checked = True).Any = False Then

                                e.Node.ParentNode.Checked = False

                            End If

                        Else

                            e.Node.ParentNode.Checked = True

                        End If

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub CheckBoxGeneral_AssociateToExpenseItems_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxGeneral_AssociateToExpenseItems.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#Region "  Account Payable Invoice "

        Private Function AddLevelDocument_AccountPayableInvoice(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim AccountPayableDocument As AdvantageFramework.Database.Entities.AccountPayableDocument = Nothing

            Try

                AccountPayableDocument = New AdvantageFramework.Database.Entities.AccountPayableDocument

                AccountPayableDocument.DocumentID = DocumentID
                AccountPayableDocument.AccountPayableID = _DocumentLevelSetting.AccountPayableID

                Added = AdvantageFramework.Database.Procedures.AccountPayableDocument.Insert(DataContext, AccountPayableDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_AccountPayableInvoice = Added
            End Try

        End Function

#End Region

#Region "  Ad Number "

        Private Function AddLevelDocument_AdNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing

            Try

                Ad = AdvantageFramework.Database.Procedures.Ad.LoadByAdNumber(DbContext, _DocumentLevelSetting.AdNumber)

                If Ad IsNot Nothing Then

                    Ad.DocumentID = DocumentID
                    Added = AdvantageFramework.Database.Procedures.Ad.Update(DbContext, Ad)

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_AdNumber = Added
            End Try

        End Function

#End Region

#Region "  Campaign "

        Private Function AddLevelDocument_Campaign(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim CampaignDocument As AdvantageFramework.Database.Entities.CampaignDocument = Nothing

            Try

                CampaignDocument = New AdvantageFramework.Database.Entities.CampaignDocument

                CampaignDocument.DocumentID = DocumentID
                CampaignDocument.CampaignID = _DocumentLevelSetting.CampaignID

                Added = AdvantageFramework.Database.Procedures.CampaignDocument.Insert(DataContext, CampaignDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Campaign = Added
            End Try

        End Function

#End Region

#Region "  Client "

        Private Function AddLevelDocument_Client(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ClientDocument As AdvantageFramework.Database.Entities.ClientDocument = Nothing

            Try

                ClientDocument = New AdvantageFramework.Database.Entities.ClientDocument

                ClientDocument.DocumentID = DocumentID
                ClientDocument.ClientCode = _DocumentLevelSetting.ClientCode

                Added = AdvantageFramework.Database.Procedures.ClientDocument.Insert(DataContext, ClientDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Client = Added
            End Try

        End Function

#End Region

#Region "  Division "

        Private Function AddLevelDocument_Division(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim DivisionDocument As AdvantageFramework.Database.Entities.DivisionDocument = Nothing

            Try

                DivisionDocument = New AdvantageFramework.Database.Entities.DivisionDocument

                DivisionDocument.DocumentID = DocumentID
                DivisionDocument.ClientCode = _DocumentLevelSetting.ClientCode
                DivisionDocument.DivisionCode = _DocumentLevelSetting.DivisionCode

                Added = AdvantageFramework.Database.Procedures.DivisionDocument.Insert(DataContext, DivisionDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Division = Added
            End Try

        End Function

#End Region

#Region "  Expense Receipts "

        Private Function AddLevelDocument_ExpenseReceipts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument = Nothing
            Dim ExpenseDetailDocument As AdvantageFramework.Database.Entities.ExpenseDetailDocument = Nothing

            Try

                ExpenseReportDocument = New AdvantageFramework.Database.Entities.ExpenseReportDocument

                ExpenseReportDocument.DocumentID = DocumentID
                ExpenseReportDocument.InvoiceNumber = _DocumentLevelSetting.ExpenseReportInvoiceNumber

                Added = AdvantageFramework.Database.Procedures.ExpenseReportDocument.Insert(DbContext, ExpenseReportDocument)

                If Added Then

                    If CheckBoxGeneral_AssociateToExpenseItems.Checked Then

                        Try

                            For Each ExpenseDetailID In DataGridViewExpenseItems_ExpenseItems.GetAllSelectedRowsBookmarkValues().OfType(Of Integer)()

                                ExpenseDetailDocument = New AdvantageFramework.Database.Entities.ExpenseDetailDocument

                                ExpenseDetailDocument.DocumentID = ExpenseReportDocument.DocumentID
                                ExpenseDetailDocument.ExpenseDetailID = ExpenseDetailID
                                ExpenseDetailDocument.DbContext = DbContext

                                AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Insert(DbContext, ExpenseDetailDocument)

                            Next

                        Catch ex As Exception

                        End Try

                    End If

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_ExpenseReceipts = Added
            End Try

        End Function

#End Region

#Region "  Job "

        Private Function AddLevelDocument_Job(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim JobDocument As AdvantageFramework.Database.Entities.JobDocument = Nothing

            Try

                JobDocument = New AdvantageFramework.Database.Entities.JobDocument

                JobDocument.DocumentID = DocumentID
                JobDocument.JobNumber = _DocumentLevelSetting.JobNumber

                Added = AdvantageFramework.Database.Procedures.JobDocument.Insert(DataContext, JobDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Job = Added
            End Try

        End Function

#End Region

#Region "  Job Component "

        Private Function AddLevelDocument_JobComponent(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim JobComponentDocument As AdvantageFramework.Database.Entities.JobComponentDocument = Nothing

            Try

                JobComponentDocument = New AdvantageFramework.Database.Entities.JobComponentDocument

                JobComponentDocument.DocumentID = DocumentID
                JobComponentDocument.JobNumber = _DocumentLevelSetting.JobNumber
                JobComponentDocument.JobComponentNumber = _DocumentLevelSetting.JobComponentNumber

                Added = AdvantageFramework.Database.Procedures.JobComponentDocument.Insert(DataContext, JobComponentDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_JobComponent = Added
            End Try

        End Function

#End Region

#Region "  Office "

        Private Function AddLevelDocument_Office(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim OfficeDocument As AdvantageFramework.Database.Entities.OfficeDocument = Nothing

            Try

                OfficeDocument = New AdvantageFramework.Database.Entities.OfficeDocument

                OfficeDocument.DocumentID = DocumentID
                OfficeDocument.OfficeCode = _DocumentLevelSetting.OfficeCode

                Added = AdvantageFramework.Database.Procedures.OfficeDocument.Insert(DbContext, OfficeDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Office = Added
            End Try

        End Function

#End Region

#Region "  Product "

        Private Function AddLevelDocument_Product(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ProductDocument As AdvantageFramework.Database.Entities.ProductDocument = Nothing

            Try

                ProductDocument = New AdvantageFramework.Database.Entities.ProductDocument

                ProductDocument.DocumentID = DocumentID
                ProductDocument.ClientCode = _DocumentLevelSetting.ClientCode
                ProductDocument.DivisionCode = _DocumentLevelSetting.DivisionCode
                ProductDocument.ProductCode = _DocumentLevelSetting.ProductCode

                Added = AdvantageFramework.Database.Procedures.ProductDocument.Insert(DataContext, ProductDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Product = Added
            End Try

        End Function

#End Region

#Region "  Employee "

        Private Function AddLevelDocument_Employee(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim EmployeeDocument As AdvantageFramework.Database.Entities.EmployeeDocument = Nothing

            Try

                EmployeeDocument = New AdvantageFramework.Database.Entities.EmployeeDocument

                EmployeeDocument.DocumentID = DocumentID
                EmployeeDocument.EmployeeCode = _DocumentLevelSetting.EmployeeCode

                Added = AdvantageFramework.Database.Procedures.EmployeeDocument.Insert(DataContext, EmployeeDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Employee = Added
            End Try

        End Function

#End Region

#Region "  Vendor "

        Private Function AddLevelDocument_Vendor(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim VendorDocument As AdvantageFramework.Database.Entities.VendorDocument = Nothing

            Try

                VendorDocument = New AdvantageFramework.Database.Entities.VendorDocument

                VendorDocument.DocumentID = DocumentID
                VendorDocument.VendorCode = _DocumentLevelSetting.VendorCode

                Added = AdvantageFramework.Database.Procedures.VendorDocument.Insert(DataContext, VendorDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Vendor = Added
            End Try

        End Function

#End Region

#Region "  Contract "

        Private Function AddLevelDocument_Contract(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ContractDocument As AdvantageFramework.Database.Entities.ContractDocument = Nothing

            Try

                ContractDocument = New AdvantageFramework.Database.Entities.ContractDocument

                ContractDocument.DocumentID = DocumentID
                ContractDocument.ContractID = _DocumentLevelSetting.ContractID

                Added = AdvantageFramework.Database.Procedures.ContractDocument.Insert(DbContext, ContractDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Contract = Added
            End Try

        End Function

#End Region

#Region "  Contract Value Added "

        Private Function AddLevelDocument_ContractValueAdded(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing

            Try

                ContractValueAdded = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, _DocumentLevelSetting.ValueAddedID)

                If ContractValueAdded IsNot Nothing Then

                    ContractValueAdded.DocumentID = DocumentID
                    Added = AdvantageFramework.Database.Procedures.ContractValueAdded.Update(DbContext, ContractValueAdded)

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_ContractValueAdded = Added
            End Try

        End Function

#End Region

#Region "  Contract Report "

        Private Function AddLevelDocument_ContractReport(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ContractReportDocument As AdvantageFramework.Database.Entities.ContractReportDocument = Nothing

            Try

                ContractReportDocument = New AdvantageFramework.Database.Entities.ContractReportDocument

                ContractReportDocument.DocumentID = DocumentID
                ContractReportDocument.ContractReportID = _DocumentLevelSetting.ContractReportID

                Added = AdvantageFramework.Database.Procedures.ContractReportDocument.Insert(DataContext, ContractReportDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_ContractReport = Added
            End Try

        End Function

#End Region

#Region "  Account Receivable Invoice "

        Private Function AddLevelDocument_AccountReceivableInvoice(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim AccountReceivableDocument As AdvantageFramework.Database.Entities.AccountReceivableDocument = Nothing

            Try

                AccountReceivableDocument = New AdvantageFramework.Database.Entities.AccountReceivableDocument

                AccountReceivableDocument.DocumentID = DocumentID
                AccountReceivableDocument.InvoiceNumber = _DocumentLevelSetting.AccountReceivableInvoiceNumber
                AccountReceivableDocument.SequenceNumber = _DocumentLevelSetting.AccountReceivableSequenceNumber
                AccountReceivableDocument.Type = _DocumentLevelSetting.AccountReceivableType

                Added = AdvantageFramework.Database.Procedures.AccountReceivableDocument.Insert(DbContext, AccountReceivableDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_AccountReceivableInvoice = Added
            End Try

        End Function

#End Region

#Region "  Vendor Contract "

        Private Function AddLevelDocument_VendorContract(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim VendorContractDocument As AdvantageFramework.Database.Entities.VendorContractDocument = Nothing

            Try

                VendorContractDocument = New AdvantageFramework.Database.Entities.VendorContractDocument

                VendorContractDocument.DocumentID = DocumentID
                VendorContractDocument.ContractID = _DocumentLevelSetting.VendorContractID

                Added = AdvantageFramework.Database.Procedures.VendorContractDocument.Insert(DbContext, VendorContractDocument, "")

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_VendorContract = Added
            End Try

        End Function

#End Region

#Region "  Agency Desktop "

        Private Function AddLevelDocument_AgencyDesktop(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim AgencyDesktopDocument As AdvantageFramework.Database.Entities.AgencyDesktopDocument = Nothing

            Try

                AgencyDesktopDocument = New AdvantageFramework.Database.Entities.AgencyDesktopDocument

                AgencyDesktopDocument.DocumentID = DocumentID
                AgencyDesktopDocument.OfficeCode = _DocumentLevelSetting.OfficeCode
                AgencyDesktopDocument.DepartmentTeamCode = _DocumentLevelSetting.DepartmentCode

                Added = AdvantageFramework.Database.Procedures.AgencyDesktopDocument.Insert(DbContext, AgencyDesktopDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_AgencyDesktop = Added
            End Try

        End Function

#End Region

#Region "  Executive Desktop "

        Private Function AddLevelDocument_ExecutiveDesktop(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ExecutiveDesktopDocument As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument = Nothing

            Try

                ExecutiveDesktopDocument = New AdvantageFramework.Database.Entities.ExecutiveDesktopDocument

                ExecutiveDesktopDocument.DocumentID = DocumentID
                ExecutiveDesktopDocument.OfficeCode = _DocumentLevelSetting.OfficeCode
                ExecutiveDesktopDocument.EmployeeCode = _DocumentLevelSetting.EmployeeCode

                Added = AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.Insert(DbContext, ExecutiveDesktopDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_ExecutiveDesktop = Added
            End Try

        End Function

#End Region

#Region "  Media Order "

        Private Function AddLevelDocument_MediaOrder(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MagazineDocument As AdvantageFramework.Database.Entities.MagazineDocument = Nothing
            Dim NewspaperDocument As AdvantageFramework.Database.Entities.NewspaperDocument = Nothing
            Dim InternetDocument As AdvantageFramework.Database.Entities.InternetDocument = Nothing
            Dim OutOfHomeDocument As AdvantageFramework.Database.Entities.OutOfHomeDocument = Nothing
            Dim RadioDocument As AdvantageFramework.Database.Entities.RadioDocument = Nothing
            Dim TVDocument As AdvantageFramework.Database.Entities.TVDocument = Nothing

            Try

                If _DocumentLevelSetting.MediaType = "M" Then

                    MagazineDocument = New AdvantageFramework.Database.Entities.MagazineDocument

                    MagazineDocument.DocumentID = DocumentID
                    MagazineDocument.OrderNumber = _DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.MagazineDocument.Insert(DbContext, MagazineDocument)

                ElseIf _DocumentLevelSetting.MediaType = "N" Then

                    NewspaperDocument = New AdvantageFramework.Database.Entities.NewspaperDocument

                    NewspaperDocument.DocumentID = DocumentID
                    NewspaperDocument.OrderNumber = _DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.NewspaperDocument.Insert(DbContext, NewspaperDocument)

                ElseIf _DocumentLevelSetting.MediaType = "I" Then

                    InternetDocument = New AdvantageFramework.Database.Entities.InternetDocument

                    InternetDocument.DocumentID = DocumentID
                    InternetDocument.OrderNumber = _DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.InternetDocument.Insert(DbContext, InternetDocument)

                ElseIf _DocumentLevelSetting.MediaType = "O" Then

                    OutOfHomeDocument = New AdvantageFramework.Database.Entities.OutOfHomeDocument

                    OutOfHomeDocument.DocumentID = DocumentID
                    OutOfHomeDocument.OrderNumber = _DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.OutOfHomeDocument.Insert(DbContext, OutOfHomeDocument)

                ElseIf _DocumentLevelSetting.MediaType = "R" Then

                    RadioDocument = New AdvantageFramework.Database.Entities.RadioDocument

                    RadioDocument.DocumentID = DocumentID
                    RadioDocument.OrderNumber = _DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.RadioDocument.Insert(DbContext, RadioDocument)

                ElseIf _DocumentLevelSetting.MediaType = "T" Then

                    TVDocument = New AdvantageFramework.Database.Entities.TVDocument

                    TVDocument.DocumentID = DocumentID
                    TVDocument.OrderNumber = _DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.TVDocument.Insert(DbContext, TVDocument)

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_MediaOrder = Added
            End Try

        End Function

#End Region

#Region "  Media Traffic Detail "

        Private Function AddLevelDocument_MediaTrafficDetail(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MediaTrafficDetailDocument As AdvantageFramework.Database.Entities.MediaTrafficDetailDocument = Nothing
            Dim ErrorText As String = Nothing

            Try

                MediaTrafficDetailDocument = New AdvantageFramework.Database.Entities.MediaTrafficDetailDocument

                MediaTrafficDetailDocument.DocumentID = DocumentID
                MediaTrafficDetailDocument.MediaTrafficDetailID = _DocumentLevelSetting.MediaTrafficDetailID

                Added = AdvantageFramework.Database.Procedures.MediaTrafficDetailDocument.Insert(DbContext, MediaTrafficDetailDocument, ErrorText)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_MediaTrafficDetail = Added
            End Try

        End Function

#End Region

#Region "  Journal Entry "

        Private Function AddLevelDocument_JournalEntry(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim GeneralLedgerDocument As AdvantageFramework.Database.Entities.GeneralLedgerDocument = Nothing
            Dim ErrorText As String = Nothing

            Try

                GeneralLedgerDocument = New AdvantageFramework.Database.Entities.GeneralLedgerDocument

                GeneralLedgerDocument.DocumentID = DocumentID
                GeneralLedgerDocument.GLTransaction = _DocumentLevelSetting.GLTransaction

                Added = AdvantageFramework.Database.Procedures.GeneralLedgerDocument.Insert(DbContext, GeneralLedgerDocument, ErrorText)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_JournalEntry = Added
            End Try

        End Function

#End Region

#Region "  Media Plan "

        Private Function AddLevelDocument_MediaPlan(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MediaPlanDocument As AdvantageFramework.Database.Entities.MediaPlanDocument = Nothing
            Dim ErrorText As String = Nothing

            Try

                MediaPlanDocument = New AdvantageFramework.Database.Entities.MediaPlanDocument

                MediaPlanDocument.DocumentID = DocumentID
                MediaPlanDocument.MediaPlanID = _DocumentLevelSetting.MediaPlanID

                Added = AdvantageFramework.Database.Procedures.MediaPlanDocument.Insert(DbContext, MediaPlanDocument, ErrorText)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_MediaPlan = Added
            End Try

        End Function

#End Region

#End Region

    End Class

End Namespace
