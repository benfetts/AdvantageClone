Public Class Documents_ProofHQUpload
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Caller As String = ""
    Private _DocumentID As Long = 0
    Private _DocumentLevelCode As String = ""
    Private _DocumentDOLevelCode As String = ""
    Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
    Private _DocumentLevelValue As String = ""
    Private _DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Short = 0
    Private _ParentProofHQFileID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadQueryStringValues()

        Try

            If Request.QueryString("Caller") IsNot Nothing Then

                _Caller = CType(Request.QueryString("Caller"), String)

            End If

        Catch ex As Exception
            _Caller = ""
        End Try

        Try

            If Request.QueryString("DocumentID") IsNot Nothing Then

                _DocumentID = CType(Request.QueryString("DocumentID"), Long)

            End If

        Catch ex As Exception
            _DocumentID = 0
        End Try

        Try

            If Request.QueryString("DocumentLevelCode") IsNot Nothing Then

                _DocumentLevelCode = CType(Request.QueryString("DocumentLevelCode"), String)

            End If

        Catch ex As Exception
            _DocumentLevelCode = ""
        End Try

        Try

            If Request.QueryString("DocumentDOLevelCode") IsNot Nothing Then

                _DocumentDOLevelCode = CType(Request.QueryString("DocumentDOLevelCode"), String)

            End If

        Catch ex As Exception
            _DocumentDOLevelCode = ""
        End Try

        _DocumentLevel = AdvantageFramework.Web.FileSystem.GetDocumentLevelFromCode(_DocumentLevelCode, _DocumentDOLevelCode)

        Try

            If Request.QueryString("DocumentLevelValue") IsNot Nothing Then

                _DocumentLevelValue = CType(Request.QueryString("DocumentLevelValue"), String)

            End If

        Catch ex As Exception
            _DocumentLevelValue = ""
        End Try

        Try

            If Request.QueryString("JobNumber") IsNot Nothing Then

                _JobNumber = CType(Request.QueryString("JobNumber"), Integer)

            End If

        Catch ex As Exception
            _JobNumber = 0
        End Try

        Try

            If Request.QueryString("JobComponentNumber") IsNot Nothing Then

                _JobComponentNumber = CType(Request.QueryString("JobComponentNumber"), Short)

            End If

        Catch ex As Exception
            _JobComponentNumber = 0
        End Try

        _DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(_DocumentLevel)

        Try

            AdvantageFramework.Web.FileSystem.LoadDocumentLevelSetting(_DocumentLevel, _DocumentLevelSetting, _DocumentLevelValue, _JobNumber, _JobComponentNumber)

        Catch ex As Exception

        End Try

        If _DocumentLevelSetting IsNot Nothing Then

            If String.IsNullOrWhiteSpace(_DocumentLevelSetting.JobNumber) = False AndAlso IsNumeric(_DocumentLevelSetting.JobNumber) Then

                AutoCompleteAlertRecipient.JobNumber = CInt(_DocumentLevelSetting.JobNumber)

            End If

            AutoCompleteAlertRecipient.ClientCode = _DocumentLevelSetting.ClientCode

        End If

        If _DocumentLevelSetting IsNot Nothing Then

            If _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Job OrElse _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.JobComponent Then

                _DocumentLevelSetting.ClientCode = Session("DocClientValue")
                _DocumentLevelSetting.DivisionCode = Session("DocDivisionValue")
                _DocumentLevelSetting.ProductCode = Session("DocProductValue")

            End If

        End If

    End Sub
    Private Sub LoadAlertAssignmentStates()

        'objects
        Dim CompletedAlertStateID As Integer = 0
        Dim AlertAssignmentTemplateStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateState) = Nothing
        Dim AlertAssignmentTemplateState As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing

        If AdvantageFramework.Web.Presentation.DoesComboBoxHaveASelectedValue(RadComboBoxTemplate) Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AlertAssignmentTemplateStates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, RadComboBoxTemplate.SelectedValue).Include("AlertState").OrderBy(Function(Entity) Entity.SortOrder).ToList

                Try

                    AlertAssignmentTemplateState = AlertAssignmentTemplateStates.SingleOrDefault(Function(Entity) Entity.IsCompleted.GetValueOrDefault(False) = True)

                    If AlertAssignmentTemplateState IsNot Nothing Then

                        CompletedAlertStateID = AlertAssignmentTemplateState.AlertStateID

                    End If

                Catch ex As Exception
                    CompletedAlertStateID = 0
                End Try

                RadComboBoxState.DataSource = From AlertState In AlertAssignmentTemplateStates.Select(Function(Entity) Entity.AlertState)
                                              Select New With {.ID = AlertState.ID,
                                                               .Name = If(AlertState.ID = CompletedAlertStateID, AlertState.Name & "*", AlertState.Name)}

            End Using

        Else

            RadComboBoxState.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.AlertState)

        End If

        RadComboBoxState.DataBind()
        RadComboBoxState.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        RadComboBoxState.SelectedValue = ""

        EnableOrDisableActions()

    End Sub
    Private Sub LoadAlertAssignmentEmployees()

        'objects
        Dim EmployeeCodes As Generic.List(Of String) = Nothing
        Dim DefaultEmployeeCode As String = ""

        If AdvantageFramework.Web.Presentation.DoesComboBoxHaveASelectedValue(RadComboBoxTemplate) AndAlso AdvantageFramework.Web.Presentation.DoesComboBoxHaveASelectedValue(RadComboBoxState) Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    DefaultEmployeeCode = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, RadComboBoxTemplate.SelectedValue, RadComboBoxState.SelectedValue).DefaultEmployeeCode

                Catch ex As Exception
                    DefaultEmployeeCode = ""
                End Try

                EmployeeCodes = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateEmployee.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, RadComboBoxTemplate.SelectedValue, RadComboBoxState.SelectedValue).Select(Function(Entity) Entity.EmployeeCode).ToList

                If EmployeeCodes IsNot Nothing AndAlso EmployeeCodes.Count > 0 Then

                    RadComboBoxAssignTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                      Select Entity.Code,
                                                             Entity.FirstName,
                                                             Entity.LastName,
                                                             Entity.MiddleInitial).ToList.Where(Function(Employee) EmployeeCodes.Contains(Employee.Code)).Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                                                                                              .FullName = If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "", Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName, Employee.FirstName & " " & Employee.LastName) &
                                                                                                                                                                                                          If(Employee.Code = DefaultEmployeeCode, "*", "")})

                Else

                    RadComboBoxAssignTo.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

                End If

            End Using

        Else

            RadComboBoxAssignTo.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

        End If

        RadComboBoxAssignTo.DataBind()
        RadComboBoxAssignTo.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Unassigned]", AdvantageFramework.AlertSystem.Unassigned))
        RadComboBoxAssignTo.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        If String.IsNullOrEmpty(DefaultEmployeeCode) = False Then

            RadComboBoxAssignTo.SelectedValue = DefaultEmployeeCode

        Else

            RadComboBoxAssignTo.SelectedValue = ""

        End If

        EnableOrDisableActions()

    End Sub
    Private Function LoadAlertEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Views.Employee)

        'objects
        Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim AllEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim EmployeeCodes As String = ""

        Try

            Employees = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
            AllEmployees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList
            EmployeeCodes = AutoCompleteAlertRecipient.GetCommaDelimitedStringOfEmployeeCodes()

            If String.IsNullOrWhiteSpace(EmployeeCodes) = False Then

                For Each EmployeeCode In EmployeeCodes.Split(",")

                    Employee = Nothing

                    Try

                        Employee = AllEmployees.SingleOrDefault(Function(Entity) Entity.Code = EmployeeCode)

                    Catch ex As Exception
                        Employee = Nothing
                    End Try

                    If Employee IsNot Nothing AndAlso Employees.Any(Function(Entity) Entity.Code = Employee.Code) = False Then

                        Employees.Add(Employee)

                    End If

                Next

            End If

        Catch ex As Exception
            Employees = Nothing
        Finally
            LoadAlertEmployees = Employees
        End Try

    End Function
    Private Sub UploadDocument()

        'objects
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim File As String = ""
        Dim FolderID As Integer = 0
        Dim ErrorMessage As String = ""
        Dim ErrorCode As String = ""
        Dim ProofHQUploaded As Boolean = False
        Dim ProofHQFileID As Integer = 0
        Dim Uploaded As Boolean = False
        Dim IsValid As Boolean = True
        Dim AlertEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim ProofHQUrl As String = ""
        Dim EmailSent As Boolean = False
        Dim ByteFile() As Byte = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Web.Presentation.DoesComboBoxHaveASelectedValue(RadComboBoxFolder) AndAlso IsNumeric(RadComboBoxFolder.SelectedValue) Then

                    FolderID = RadComboBoxFolder.SelectedValue

                End If

                Try

                    If RadButtonSendAlert.Checked Then

                        AlertEmployees = LoadAlertEmployees(DbContext)

                        If AlertEmployees Is Nothing OrElse AlertEmployees.Count = 0 Then

                            ErrorMessage = "Please select at least one recipient."
                            IsValid = False

                        End If

                    End If

                    If RadButtonSendAlertAssignment.Checked Then

                        If AdvantageFramework.Web.Presentation.DoesComboBoxHaveASelectedValue(RadComboBoxTemplate) = False Then

                            ErrorMessage = "Please select an alert template."
                            IsValid = False

                        End If

                        If IsValid Then

                            If AdvantageFramework.Web.Presentation.DoesComboBoxHaveASelectedValue(RadComboBoxTemplate) = False Then

                                ErrorMessage = "Please select an alert state."
                                IsValid = False

                            End If

                        End If

                        If IsValid Then

                            If AdvantageFramework.Web.Presentation.DoesComboBoxHaveASelectedValue(RadComboBoxTemplate) = False Then

                                ErrorMessage = "Please select an employee for alert assignment."
                                IsValid = False

                            End If

                        End If

                    End If

                    If IsValid Then

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing Then

                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, _DocumentID)

                            If Document IsNot Nothing Then

                                If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile) Then

                                    If _ParentProofHQFileID > 0 Then

                                        ProofHQUploaded = AdvantageFramework.ProofHQ.UploadNewVersion(DbContext, DataContext, _Session.User.EmployeeCode, ByteFile, _ParentProofHQFileID, Document.FileName, TextBoxName.Text, ErrorCode, ErrorMessage, FolderID, ProofHQUrl, ProofHQFileID)

                                    Else

                                        ProofHQUploaded = AdvantageFramework.ProofHQ.UploadFile(DbContext, DataContext, _Session.User.EmployeeCode, ByteFile, Document.FileName, TextBoxName.Text, ErrorCode, ErrorMessage, FolderID, ProofHQUrl, ProofHQFileID)

                                    End If

                                    If ProofHQUploaded Then

                                        Document.ProofHQUrl = ProofHQUrl
                                        Document.ProofHQFileID = ProofHQFileID

                                        AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                                        Uploaded = True

                                        If RadButtonSendAlert.Checked Then

                                            CreateAlert(DbContext, AlertEmployees, ProofHQUrl)

                                        ElseIf RadButtonSendAlertAssignment.Checked Then

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

                    Else

                        Me.ShowMessage(ErrorMessage)

                    End If

                Catch ex As Exception

                End Try

            End Using

        End Using

        If Uploaded Then

            Select Case _Caller

                Case "Documents.aspx"

                    Me.CloseThisWindowAndRefreshCaller(_Caller & "?cf=0", True)

                Case "Documents_JobComponent.aspx"

                    Me.CloseThisWindowAndRefreshCaller("Documents_JobComponent.aspx?m=D&JobNum=" & _JobNumber & "&JobCompNum=" & _JobComponentNumber, True)

                Case Else

                    Me.CloseThisWindowAndRefreshCaller(_Caller, False, False)

            End Select

        Else

            If String.IsNullOrEmpty(ErrorCode) = False AndAlso String.IsNullOrEmpty(ErrorMessage) = False Then

                Me.ShowMessage(ErrorCode & " - " & ErrorMessage)

            End If

        End If

    End Sub
    Private Sub CreateAlert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee), ByVal ProofHQUrl As String)

        'objects
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
        Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
        Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing

        AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, "Alert")

        Alert = New AdvantageFramework.Database.Entities.Alert

        Alert.DbContext = DbContext

        Alert.Subject = TextBoxSubject.Text
        Alert.EmployeeCode = _Session.User.EmployeeCode
        Alert.Body = TextBoxName.Text & vbNewLine & vbNewLine & "URL: " & ProofHQUrl
        Alert.EmailBody = TextBoxName.Text & "<br/><br/>URL: " & ProofHQUrl
        Alert.AlertCategoryID = CInt(RadComboBoxCategory.SelectedValue)
        Alert.PriorityLevel = CShort(RadComboBoxPriority.SelectedValue)

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
            AlertAttachment.UserCode = _Session.UserCode
            AlertAttachment.ClientContactID = Nothing

            AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

            AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(_Session, Alert, "[New Alert]", Nothing, Nothing, Nothing, Nothing, False, False, False)

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

        AdvantageFramework.AlertSystem.CreateAndSendAlertAssignment(_Session, 6, RadComboBoxCategory.SelectedValue, Alert.AlertLevel,
                                                                    RadComboBoxTemplate.SelectedValue, RadComboBoxState.SelectedValue, RadComboBoxPriority.SelectedValue,
                                                                    TextBoxSubject.Text, ProofHQUrl, ProofHQUrl, _Session.User.EmployeeCode, _Session.UserCode,
                                                                    RadComboBoxAssignTo.SelectedValue, False, ErrorMessage, EmailSent,
                                                                    Nothing, Nothing, New Integer() {_DocumentID}, OfficeCode, ClientCode, DivisionCode, ProductCode, CampaignCode, JobNumber,
                                                                    JobComponentNumber, EstimateNumber, EstimateComponentNumber, EstimateQuoteNumber, EstimateRevisionNumber,
                                                                    VendorCode, PONumber, PORevisionNumber, AccountPayableID, AccountPayableSequenceNumber, CampaignID, ClientContactID, False)

    End Sub
    Private Sub EnableOrDisableActions()

        RadComboBoxState.Enabled = AdvantageFramework.Web.Presentation.DoesComboBoxHaveASelectedValue(RadComboBoxTemplate)
        RadComboBoxAssignTo.Enabled = (AdvantageFramework.Web.Presentation.DoesComboBoxHaveASelectedValue(RadComboBoxTemplate) AndAlso AdvantageFramework.Web.Presentation.DoesComboBoxHaveASelectedValue(RadComboBoxState))

        divSendAlert.Visible = (RadButtonSendAlert.Checked OrElse RadButtonSendAlertAssignment.Checked)
        divSendAlertAssignment.Visible = RadButtonSendAlertAssignment.Checked

        ButtonAddRecipients.Visible = RadButtonSendAlert.Checked
        ButtonClearRecipients.Visible = RadButtonSendAlert.Checked
        LabelRecipients.Visible = RadButtonSendAlert.Checked
        AutoCompleteAlertRecipient.Visible = RadButtonSendAlert.Checked

    End Sub

#Region "  Form Event Handlers "

    Private Sub Documents_ProofHQUpload_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'objects
        Dim Uploaded As Boolean = False
        Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
        Dim Document As AdvantageFramework.DocumentManager.Classes.Document = Nothing
        Dim DocumentEntity As AdvantageFramework.Database.Entities.Document = Nothing
        Dim DocumentFileName As String = ""

        LoadQueryStringValues()

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DocumentEntity = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, _DocumentID)

                If DocumentEntity IsNot Nothing Then

                    DocumentFileName = DocumentEntity.FileName

                End If

            End Using

        Catch ex As Exception

        End Try

        DocumentList = AdvantageFramework.DocumentManager.LoadRelatedDocuments(_Session, _DocumentID, DocumentFileName, _DocumentLevel)

        Try

            Document = DocumentList.Where(Function(Entity) Entity.ProofHQFileID.GetValueOrDefault(0) > 0).OrderBy(Function(Entity) Entity.ID).FirstOrDefault

        Catch ex As Exception
            Document = Nothing
        End Try

        If Document IsNot Nothing Then

            _ParentProofHQFileID = Document.ProofHQFileID.GetValueOrDefault(0)

        End If

    End Sub
    Private Sub Documents_ProofHQUpload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim EnumObjects As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If _DocumentID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, _DocumentID)

                    If Document IsNot Nothing Then

                        RadComboBoxCategory.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeID(DbContext, 6)
                                                          Where Entity.ID < 28
                                                          Select Entity
                                                          Order By Entity.Description Ascending).ToList
                        RadComboBoxCategory.DataBind()

                        RadComboBoxPriority.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.AlertPriority)).ToList
                                                          Select [Name] = EnumObject.Value,
                                                                 [Value] = EnumObject.Key).ToList
                        RadComboBoxPriority.DataBind()

                        RadComboBoxPriority.SelectedValue = CLng(AdvantageFramework.Database.Entities.AlertPriority.Normal)

						RadComboBoxTemplate.DataSource = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext).OrderBy(Function(Entity) Entity.Name).ToList

						RadComboBoxTemplate.DataBind()
                        RadComboBoxTemplate.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                        LabelDocument.Text = Document.FileName
                        TextBoxName.Text = Document.FileName

                        EnumObjects = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

                        For Each Folder In AdvantageFramework.ProofHQ.GetFolders(_Session)

                            EnumObjects.Add(New AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute(Folder.id, Folder.name))

                        Next

                        RadComboBoxFolder.DataSource = EnumObjects
                        RadComboBoxFolder.DataBind()
                        RadComboBoxFolder.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))

                        If _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts Then

                            RadButtonSendAlert.Visible = False
                            RadButtonSendAlertAssignment.Visible = False

                        End If

                        TextBoxSubject.Text = String.Format("Proof HQ Document {0} is available for review.", Document.FileName)

                        EnableOrDisableActions()

                        If _ParentProofHQFileID > 0 Then

                            Me.Title &= " - (New Version)"

                        End If

                    Else

                        Me.ShowMessage("The document you are trying to upload does not exist anymore.")
                        Me.CloseThisWindow()

                    End If

                End Using

            Else

                Me.ShowMessage("The document you are trying to upload does not exist anymore.")
                Me.CloseThisWindow()

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarDocumentUpload_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDocumentUpload.ButtonClick

        If e.Item IsNot Nothing Then

            If e.Item.Value = "Upload" Then

                UploadDocument()

            ElseIf e.Item.Value = "Cancel" Then

                Me.CloseThisWindow()

            End If

        End If

    End Sub
    Private Sub RadButtonSendAlert_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonSendAlert.CheckedChanged

        If RadButtonSendAlert.Checked Then

            RadButtonSendAlertAssignment.Checked = False

        End If

        EnableOrDisableActions()

    End Sub
    Private Sub RadButtonSendAlertAssignment_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonSendAlertAssignment.CheckedChanged

        If RadButtonSendAlertAssignment.Checked Then

            RadButtonSendAlert.Checked = False

        End If

        EnableOrDisableActions()

    End Sub
    Private Sub RadComboBoxTemplate_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxTemplate.SelectedIndexChanged

        LoadAlertAssignmentStates()

    End Sub
    Private Sub RadComboBoxState_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxState.SelectedIndexChanged

        LoadAlertAssignmentEmployees()

    End Sub
    Private Sub ButtonAddRecipients_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAddRecipients.Click

        'objects
        Dim AlertGroupCode As String = ""
        Dim JobNumber As Integer = 0
        Dim JobComponentNumber As Short = 0
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim ag As Integer = 0

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If _DocumentLevelSetting IsNot Nothing Then

                If _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Product Then

                    Try

                        AlertGroupCode = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _DocumentLevelSetting.ClientCode, _DocumentLevelSetting.DivisionCode, _DocumentLevelSetting.ProductCode).ProductionAlertGroup

                    Catch ex As Exception
                        AlertGroupCode = ""
                    End Try

                ElseIf _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.JobComponent Then

                    If String.IsNullOrWhiteSpace(_DocumentLevelSetting.JobNumber) = False AndAlso IsNumeric(_DocumentLevelSetting.JobNumber) Then

                        JobNumber = CInt(_DocumentLevelSetting.JobNumber)

                    End If

                    If String.IsNullOrWhiteSpace(_DocumentLevelSetting.JobComponentNumber) = False AndAlso IsNumeric(_DocumentLevelSetting.JobComponentNumber) Then

                        JobComponentNumber = CShort(_DocumentLevelSetting.JobComponentNumber)

                    End If

                    Try

                        AlertGroupCode = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber).AlertGroupCode

                    Catch ex As Exception
                        AlertGroupCode = ""
                    End Try

                End If

            End If

        End Using

        If String.IsNullOrWhiteSpace(AlertGroupCode) = False Then

            AlertGroupCode = AlertGroupCode.Replace("/", "-").Replace("&", "and").Replace(",", "_").Replace("'", "__")

        Else

            AlertGroupCode = ""

        End If

        QueryString = New AdvantageFramework.Web.QueryString

        If _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.JobComponent Then

            ag = 1

        End If

        QueryString.Page = "LookUp_Recipients.aspx"
        QueryString.JobNumber = JobNumber
        QueryString.JobComponentNumber = JobComponentNumber
        QueryString.EmailGroup = AlertGroupCode
        QueryString.Add("ag", ag)
        QueryString.Add("NewAlertLevel", _DocumentLevelCode)
        QueryString.Add("uac", "1")

        Me.OpenLookUpRecipients(QueryString.ToString(True))

    End Sub
    Private Sub ButtonClearRecipients_Click(sender As Object, e As EventArgs) Handles ButtonClearRecipients.Click

        AutoCompleteAlertRecipient.Clear()

    End Sub

#End Region

#End Region

End Class