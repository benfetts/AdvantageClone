Namespace Desktop.Presentation

    Public Class ProofHQUploadDocumentDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DocumentID As Long = 0
        Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
        Private _DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Nothing
        Private _DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
        Private _ParentProofHQFileID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal DocumentID As Long, ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel, _
                        ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting, _
                        ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel, _
                        ByVal ParentProofHQFileID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _DocumentID = DocumentID
            _DocumentLevel = DocumentLevel
            _DocumentSubLevel = DocumentSubLevel
            _DocumentLevelSetting = DocumentLevelSetting
            _ParentProofHQFileID = ParentProofHQFileID

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
        Private Sub CreateAlert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee), ByVal ProofHQUrl As String)

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing

            AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, "Alert")

            Alert = New AdvantageFramework.Database.Entities.Alert

            Alert.DbContext = DbContext

            Alert.Subject = TextBoxAlertOptions_Subject.Text
            Alert.EmployeeCode = Session.User.EmployeeCode
            Alert.Body = TextBoxGeneral_Name.Text & vbNewLine & vbNewLine & "URL: " & ProofHQUrl
            Alert.EmailBody = TextBoxGeneral_Name.Text & "<br/><br/>URL: " & ProofHQUrl
            Alert.AlertCategoryID = CInt(ComboBoxAlertOptions_Category.GetSelectedValue)
            Alert.PriorityLevel = CShort(ComboBoxAlertOptions_Priority.GetSelectedValue)

            If AlertType IsNot Nothing Then

                Alert.AlertTypeID = AlertType.ID

            End If

            Alert.GeneratedDate = System.DateTime.Now
            Alert.UserCode = DbContext.UserCode

            AdvantageFramework.AlertSystem.SetAlertLevelByDocumentLevel(Alert, _DocumentLevel, _DocumentLevelSetting)

            If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                For Each AlertEmployee In AlertEmployees

                    If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotification(AlertEmployee) Then

                        AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                        AlertRecipient.AlertID = Alert.ID
                        AlertRecipient.EmployeeCode = AlertEmployee.Code
                        AlertRecipient.EmployeeEmail = AdvantageFramework.Email.LoadEmployeeEmail(AlertEmployee, True, False)
                        AlertRecipient.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                    End If

                Next

                AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment

                AlertAttachment.DbContext = DbContext
                AlertAttachment.AlertID = Alert.ID
                AlertAttachment.GeneratedDate = System.DateTime.Now
                AlertAttachment.DocumentID = _DocumentID
                AlertAttachment.HasEmailBeenSent = False
                AlertAttachment.UserCode = Me.Session.UserCode
                AlertAttachment.ClientContactID = Nothing

                AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

                AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[New Alert]", Nothing, Nothing, Nothing, Nothing, False, False, False)

            End If

        End Sub
        Private Sub CreateAlertAssignment(ByVal ProofHQUrl As String, ByRef EmailSent As Boolean, ByRef ErrorMessage As String)

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim OfficeCode As String = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim CampaignCode As String = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim EstimateNumber As Integer = Nothing
            Dim EstimateComponentNumber As Short = Nothing
            Dim EstimateQuoteNumber As Short = Nothing
            Dim EstimateRevisionNumber As Short = Nothing
            Dim VendorCode As String = Nothing
            Dim PONumber As Integer = Nothing
            Dim PORevisionNumber As Short = Nothing
            Dim AccountPayableID As Integer = Nothing
            Dim AccountPayableSequenceNumber As Short = Nothing
            Dim CampaignID As Integer = Nothing
            Dim ClientContactID As Integer = Nothing

            Alert = New AdvantageFramework.Database.Entities.Alert

            AdvantageFramework.AlertSystem.SetAlertLevelByDocumentLevel(Alert, _DocumentLevel, _DocumentLevelSetting)

            OfficeCode = If(String.IsNullOrWhiteSpace(Alert.OfficeCode), Nothing, Alert.OfficeCode)
            ClientCode = If(String.IsNullOrWhiteSpace(Alert.ClientCode), Nothing, Alert.ClientCode)
            DivisionCode = If(String.IsNullOrWhiteSpace(Alert.DivisionCode), Nothing, Alert.DivisionCode)
            ProductCode = If(String.IsNullOrWhiteSpace(Alert.ProductCode), Nothing, Alert.ProductCode)
            CampaignCode = If(String.IsNullOrWhiteSpace(Alert.CampaignCode), Nothing, Alert.CampaignCode)
            JobNumber = If(Alert.JobNumber.GetValueOrDefault(0) = 0, Nothing, Alert.JobNumber.Value)
            JobComponentNumber = If(Alert.JobComponentNumber.GetValueOrDefault(0) = 0, Nothing, Alert.JobComponentNumber.Value)
            EstimateNumber = If(Alert.EstimateNumber.GetValueOrDefault(0) = 0, Nothing, Alert.EstimateNumber.Value)
            EstimateComponentNumber = If(Alert.EstimateComponentNumber.GetValueOrDefault(0) = 0, Nothing, Alert.EstimateComponentNumber.Value)
            EstimateQuoteNumber = If(Alert.EstimateQuoteNumber.GetValueOrDefault(0) = 0, Nothing, Alert.EstimateQuoteNumber.Value)
            EstimateRevisionNumber = If(Alert.EstimateRevisionNumber.GetValueOrDefault(0) = 0, Nothing, Alert.EstimateRevisionNumber.Value)
            VendorCode = If(String.IsNullOrWhiteSpace(Alert.VendorCode), Nothing, Alert.VendorCode)
            PONumber = If(Alert.PONumber.GetValueOrDefault(0) = 0, Nothing, Alert.PONumber.Value)
            PORevisionNumber = If(Alert.PORevisionNumber.GetValueOrDefault(0) = 0, Nothing, Alert.PORevisionNumber.Value)
            AccountPayableID = If(Alert.AccountPayableID.GetValueOrDefault(0) = 0, Nothing, Alert.AccountPayableID.Value)
            AccountPayableSequenceNumber = If(Alert.AccountPayableSequenceNumber.GetValueOrDefault(0) = 0, Nothing, Alert.AccountPayableSequenceNumber.Value)
            CampaignID = If(Alert.CampaignID.GetValueOrDefault(0) = 0, Nothing, Alert.CampaignID.Value)
            ClientContactID = If(Alert.ClientContactID.GetValueOrDefault(0) = 0, Nothing, Alert.ClientContactID.Value)

            AdvantageFramework.AlertSystem.CreateAndSendAlertAssignment(Me.Session, 6, ComboBoxAlertOptions_Category.GetSelectedValue, Alert.AlertLevel,
                                                                        ComboBoxAlertAssignmentOptions_Template.GetSelectedValue, ComboBoxAlertAssignmentOptions_State.GetSelectedValue, ComboBoxAlertOptions_Priority.GetSelectedValue,
                                                                        TextBoxAlertOptions_Subject.Text, ProofHQUrl, ProofHQUrl, Me.Session.User.EmployeeCode, Me.Session.UserCode,
                                                                        ComboBoxAlertAssignmentOptions_AssignTo.GetSelectedValue, False, ErrorMessage, EmailSent,
                                                                        Nothing, Nothing, New Integer() {_DocumentID}, OfficeCode, ClientCode, DivisionCode, ProductCode, CampaignCode, JobNumber,
                                                                        JobComponentNumber, EstimateNumber, EstimateComponentNumber, EstimateQuoteNumber, EstimateRevisionNumber,
                                                                        VendorCode, PONumber, PORevisionNumber, AccountPayableID, AccountPayableSequenceNumber, CampaignID, ClientContactID, False)

        End Sub
        Private Sub LoadAlertAssignmentStates()

            'objects
            Dim CompletedAlertStateID As Integer = 0
            Dim AlertAssignmentTemplateStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateState) = Nothing
            Dim AlertAssignmentTemplateState As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing

            If ComboBoxAlertAssignmentOptions_Template.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AlertAssignmentTemplateStates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, ComboBoxAlertAssignmentOptions_Template.GetSelectedValue).Include("AlertState").OrderBy(Function(Entity) Entity.SortOrder).ToList

                    Try

                        AlertAssignmentTemplateState = AlertAssignmentTemplateStates.SingleOrDefault(Function(Entity) Entity.IsCompleted.GetValueOrDefault(False) = True)

                        If AlertAssignmentTemplateState IsNot Nothing Then

                            CompletedAlertStateID = AlertAssignmentTemplateState.AlertStateID

                        End If

                    Catch ex As Exception
                        CompletedAlertStateID = 0
                    End Try

                    ComboBoxAlertAssignmentOptions_State.DataSource = From AlertState In AlertAssignmentTemplateStates.Select(Function(Entity) Entity.AlertState)
                                                                      Select New With {.ID = AlertState.ID,
                                                                                       .Name = If(AlertState.ID = CompletedAlertStateID, AlertState.Name & "*", AlertState.Name)}

                End Using

            Else

                ComboBoxAlertAssignmentOptions_State.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.AlertState)

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub LoadAlertAssignmentEmployees()

            'objects
            Dim EmployeeCodes As Generic.List(Of String) = Nothing
            Dim DefaultEmployeeCode As String = ""

            If ComboBoxAlertAssignmentOptions_Template.HasASelectedValue AndAlso ComboBoxAlertAssignmentOptions_State.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        DefaultEmployeeCode = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, ComboBoxAlertAssignmentOptions_Template.GetSelectedValue, ComboBoxAlertAssignmentOptions_State.GetSelectedValue).DefaultEmployeeCode

                    Catch ex As Exception
                        DefaultEmployeeCode = ""
                    End Try

                    EmployeeCodes = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateEmployee.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, ComboBoxAlertAssignmentOptions_Template.GetSelectedValue, ComboBoxAlertAssignmentOptions_State.GetSelectedValue).Select(Function(Entity) Entity.EmployeeCode).ToList

                    If EmployeeCodes IsNot Nothing AndAlso EmployeeCodes.Count > 0 Then

                        ComboBoxAlertAssignmentOptions_AssignTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                                              Select Entity.Code,
                                                                                     Entity.FirstName,
                                                                                     Entity.LastName,
                                                                                     Entity.MiddleInitial).ToList.Where(Function(Employee) EmployeeCodes.Contains(Employee.Code)).Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                                                                                                                      .FullName = If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "", Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName, Employee.FirstName & " " & Employee.LastName) &
                                                                                                                                                                                                                                  If(Employee.Code = DefaultEmployeeCode, "*", "")})

                    Else

                        ComboBoxAlertAssignmentOptions_AssignTo.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

                    End If

                    ComboBoxAlertAssignmentOptions_AssignTo.AddComboItemToExistingDataSource("[Unassigned]", AdvantageFramework.AlertSystem.Unassigned, False, 1)

                    If String.IsNullOrEmpty(DefaultEmployeeCode) = False Then

                        ComboBoxAlertAssignmentOptions_AssignTo.SelectedValue = DefaultEmployeeCode

                    End If

                End Using

            Else

                ComboBoxAlertAssignmentOptions_AssignTo.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            ComboBoxAlertAssignmentOptions_State.Enabled = ComboBoxAlertAssignmentOptions_Template.HasASelectedValue
            ComboBoxAlertAssignmentOptions_AssignTo.Enabled = (ComboBoxAlertAssignmentOptions_Template.HasASelectedValue AndAlso ComboBoxAlertAssignmentOptions_State.HasASelectedValue)

            TabItemDocumentDetails_AlertOptionsTab.Visible = (CheckBoxGeneral_SendAlert.Checked OrElse CheckBoxGeneral_SendAlertAssignment.Checked)
            TabItemDocumentDetails_AlertAssignmentOptionsTab.Visible = CheckBoxGeneral_SendAlertAssignment.Checked

            ComboBoxAlertAssignmentOptions_Template.SetRequired(CheckBoxGeneral_SendAlertAssignment.Checked)
            ComboBoxAlertAssignmentOptions_State.SetRequired(CheckBoxGeneral_SendAlertAssignment.Checked)
            ComboBoxAlertAssignmentOptions_AssignTo.SetRequired(CheckBoxGeneral_SendAlertAssignment.Checked)

            TreeListControlAlertOptions_Recepients.Enabled = CheckBoxGeneral_SendAlert.Checked

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DocumentID As Long, ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
                                              ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting,
                                              ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel,
                                              ByVal ParentProofHQFileID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim ProofHQUploadDocumentDialog As AdvantageFramework.Desktop.Presentation.ProofHQUploadDocumentDialog = Nothing

            ProofHQUploadDocumentDialog = New AdvantageFramework.Desktop.Presentation.ProofHQUploadDocumentDialog(DocumentID, DocumentLevel, DocumentLevelSetting, DocumentSubLevel, ParentProofHQFileID)

            ShowFormDialog = ProofHQUploadDocumentDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProofHQUploadDocumentDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim EnumObjects As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            TreeListControlAlertOptions_Recepients.ByPassUserEntryChanged = True

            TextBoxGeneral_Name.SetRequired(True)

            If _DocumentID > 0 Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, _DocumentID)

                    If Document IsNot Nothing Then

                        ComboBoxAlertOptions_Category.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeID(DbContext, 6)
                                                                    Where Entity.ID < 28
                                                                    Select Entity
                                                                    Order By Entity.Description Ascending).ToList

                        ComboBoxAlertOptions_Priority.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.AlertPriority)).ToList
                                                                    Select [Name] = EnumObject.Value,
                                                                           [Value] = EnumObject.Key).ToList

                        ComboBoxAlertOptions_Priority.SelectedValue = CLng(AdvantageFramework.Database.Entities.AlertPriority.Normal)

                        EnumObjects = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

                        For Each Folder In AdvantageFramework.ProofHQ.GetFolders(Session)

                            EnumObjects.Add(New AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute(Folder.id, Folder.name))

                        Next

                        ComboBoxAlertAssignmentOptions_Template.DataSource = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext).OrderBy(Function(Entity) Entity.Name)

                        LabelGeneral_Document.Text = Document.FileName
                        TextBoxGeneral_Name.Text = Document.FileName
                        ComboBoxGeneral_Folder.DataSource = EnumObjects

                        If _DocumentLevel = Database.Entities.DocumentLevel.ExpenseReceipts Then

                            CheckBoxGeneral_SendAlert.Visible = False
                            CheckBoxGeneral_SendAlertAssignment.Visible = False

                        End If

                        TextBoxAlertOptions_Subject.Text = String.Format("Proof HQ Document {0} is available for review.", Document.FileName)

                        CreateTreeListColumns()
                        LoadAlertGroups()
                        EnableOrDisableActions()

                        If _ParentProofHQFileID > 0 Then

                            Me.Text &= " - (New Version)"

                        End If

                    Else

                        Me.FormAction = WinForm.Presentation.FormActions.None
                        AdvantageFramework.WinForm.MessageBox.Show("The document you are trying to upload does not exist anymore.")
                        Me.Close()

                    End If

                End Using

                Me.FormAction = WinForm.Presentation.FormActions.None

            Else

                AdvantageFramework.WinForm.MessageBox.Show("The document you are trying to upload does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Upload_Click(sender As Object, e As EventArgs) Handles ButtonForm_Upload.Click

            'objects
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim File As String = ""
            Dim FolderID As Integer = 0
            Dim ErrorMessage As String = ""
            Dim ErrorCode As String = ""
            Dim ProofHQUploaded As Boolean = False
            Dim Uploaded As Boolean = False
            Dim SaveToLocation As String = ""
            Dim ContinueSave As Boolean = False
            Dim NewFileName As String = ""
            Dim FileExists As Boolean = True
            Dim IsValid As Boolean = True
            Dim AlertEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim ProofHQUrl As String = ""
            Dim ProofHQFileID As Integer = 0
            Dim ParentControl As Object = Nothing
            Dim FailedControl As Object = Nothing
            Dim TabControl As AdvantageFramework.WinForm.Presentation.Controls.TabControl = Nothing
            Dim TabItem As DevComponents.DotNetBar.TabItem = Nothing
            Dim EmailSent As Boolean = False
            Dim ByteFile() As Byte = Nothing

            If Me.Validator Then

                If ComboBoxGeneral_Folder.HasASelectedValue Then

                    FolderID = ComboBoxGeneral_Folder.GetSelectedValue

                End If

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                Me.ShowWaitForm("Uploading...")

                Try

                    If CheckBoxGeneral_SendAlert.Checked Then

                        AlertEmployees = LoadAlertEmployees()

                        If AlertEmployees Is Nothing OrElse AlertEmployees.Count = 0 Then

                            ErrorMessage = "Please select at least one recipient."
                            IsValid = False

                        End If

                    End If

                    If IsValid Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                If Agency IsNot Nothing Then

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, _DocumentID)

                                    If Document IsNot Nothing Then

                                        If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile, FileExists) Then

                                            If _ParentProofHQFileID > 0 Then

                                                ProofHQUploaded = AdvantageFramework.ProofHQ.UploadNewVersion(DbContext, DataContext, Me.Session.User.EmployeeCode, ByteFile, _ParentProofHQFileID, Document.FileName, TextBoxGeneral_Name.Text, ErrorCode, ErrorMessage, FolderID, ProofHQUrl, ProofHQFileID)

                                            Else

                                                ProofHQUploaded = AdvantageFramework.ProofHQ.UploadFile(DbContext, DataContext, Me.Session.User.EmployeeCode, ByteFile, Document.FileName, TextBoxGeneral_Name.Text, ErrorCode, ErrorMessage, FolderID, ProofHQUrl, ProofHQFileID)

                                            End If

                                            If ProofHQUploaded Then

                                                Document.ProofHQUrl = ProofHQUrl
                                                Document.ProofHQFileID = ProofHQFileID

                                                AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                                                Uploaded = True

                                                If CheckBoxGeneral_SendAlert.Checked Then

                                                    CreateAlert(DbContext, AlertEmployees, ProofHQUrl)

                                                ElseIf CheckBoxGeneral_SendAlertAssignment.Checked Then

                                                    CreateAlertAssignment(ProofHQUrl, EmailSent, ErrorMessage)

                                                End If

                                            Else

                                                ErrorMessage = "The document failed to upload to Proof HQ. Please contact Software Support."
                                                ErrorCode = "ADV Msg"


                                            End If

                                        End If

                                    Else

                                        ErrorMessage = "The document you are trying to upload does not exist anymore."
                                        ErrorCode = "ADV Msg"

                                    End If

                                End If

                            End Using

                        End Using

                    Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

            If Uploaded Then

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                If String.IsNullOrEmpty(ErrorCode) = False AndAlso String.IsNullOrEmpty(ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorCode & " - " & ErrorMessage)

                End If

            End If

            Else

            For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

            Next

            FailedControl = (Me.SuperValidator.LastFailedValidationResults.ToList.FirstOrDefault).Control

            If FailedControl IsNot Nothing Then

                ParentControl = FailedControl.Parent

                Do While True

                    Try

                        If ParentControl Is Nothing Then

                            Exit Do

                        ElseIf TypeOf ParentControl Is System.Windows.Forms.Form Then

                            Exit Do

                        ElseIf TypeOf ParentControl.Parent Is System.Windows.Forms.Form Then

                            Exit Do

                        End If

                    Catch ex As Exception

                    End Try

                    Try

                        If TypeOf ParentControl Is DevComponents.DotNetBar.TabControlPanel Then

                            TabControl = DirectCast(ParentControl, DevComponents.DotNetBar.TabControlPanel).Parent
                            TabControl.SelectedTab = DirectCast(ParentControl, DevComponents.DotNetBar.TabControlPanel).TabItem

                            ParentControl = ParentControl.Parent

                        Else

                            ParentControl = ParentControl.Parent

                        End If

                    Catch ex As Exception
                        ParentControl = Nothing
                    End Try

                Loop

                FailedControl.Focus()

            End If

            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub CheckBoxGeneral_SendAlert_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxGeneral_SendAlert.CheckedChanged

            If CheckBoxGeneral_SendAlert.Checked Then

                CheckBoxGeneral_SendAlertAssignment.Checked = False

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxGeneral_SendAlertAssignment_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxGeneral_SendAlertAssignment.CheckedChanged

            If CheckBoxGeneral_SendAlertAssignment.Checked Then

                CheckBoxGeneral_SendAlert.Checked = False

            End If

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
        Private Sub ComboBoxAlertAssignmentOptions_Template_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAlertAssignmentOptions_Template.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadAlertAssignmentStates()

            End If

        End Sub
        Private Sub ComboBoxAlertAssignmentOptions_State_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAlertAssignmentOptions_State.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadAlertAssignmentEmployees()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
