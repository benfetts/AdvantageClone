Public Class Documents_ProofHQDownload
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Caller As String = ""
    Private _DocumentLevelCode As String = ""
    Private _DocumentDOLevelCode As String = ""
    Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
    Private _DocumentLevelValue As String = ""
    Private _DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Short = 0

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

            Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                Added = AddLevelDocument_AccountPayableInvoice(DataContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.AdNumber

                Added = AddLevelDocument_AdNumber(DbContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.Campaign

                Added = AddLevelDocument_Campaign(DataContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.Client

                Added = AddLevelDocument_Client(DataContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                Added = AddLevelDocument_Division(DataContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts

                Added = AddLevelDocument_ExpenseReceipts(DbContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.Job

                Added = AddLevelDocument_Job(DataContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.JobComponent

                Added = AddLevelDocument_JobComponent(DataContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.Office

                Added = AddLevelDocument_Office(DbContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                Added = AddLevelDocument_Product(DataContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.Employee

                Added = AddLevelDocument_Employee(DataContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.Vendor

                Added = AddLevelDocument_Vendor(DataContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.Contract

                Added = AddLevelDocument_Contract(DbContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.ContractValueAdded

                Added = AddLevelDocument_ContractValueAdded(DbContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.ContractReport

                Added = AddLevelDocument_ContractReport(DataContext, Document.ID)

            Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                Added = AddLevelDocument_AccountReceivableInvoice(DbContext, Document.ID)

			Case AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder

				Added = AddLevelDocument_Order(DbContext, Document.ID)

		End Select

        AddLevelDocument = Added

    End Function

#Region "  Form Event Handlers "

    Private Sub Documents_ProofHQDownload_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        LoadQueryStringValues()

    End Sub
    Private Sub Documents_ProofHQDownload_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then


        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarSearch_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSearch.ButtonClick

        If e.Item IsNot Nothing AndAlso e.Item.Value = "Search" Then

            RadGridProofHQFiles.Rebind()

        End If

    End Sub
    Private Sub RadGridProofHQFiles_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridProofHQFiles.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim FileID As Integer = 0
        Dim ProofFileName As String = ""
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim Downloaded As Boolean = False
        Dim Bytes() As Byte = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim FileName As String = ""
        Dim FileSystemFileName As String = ""
        Dim FinalLevelDescription As String = ""
        Dim FinalLevel As String = ""
        Dim ErrorMessage As String = ""
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim DocumentID As Integer = 0
        Dim ProofHQUrl As String = ""

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridProofHQFiles.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "Download"

                If CurrentGridDataItem IsNot Nothing Then

                    Try

                        FileID = CurrentGridDataItem.GetDataKeyValue("FileID")

                    Catch ex As Exception
                        FileID = 0
                    End Try

                    Try

                        ProofFileName = CurrentGridDataItem("FileName").Text

                    Catch ex As Exception
                        ProofFileName = ""
                    End Try

                    If FileID > 0 AndAlso String.IsNullOrWhiteSpace(ProofFileName) = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                If Agency IsNot Nothing Then

                                    If AdvantageFramework.ProofHQ.DownloadFile(DbContext, DataContext, _Session.User.EmployeeCode, FileID, Bytes, ProofHQUrl, ErrorMessage) Then

                                        MemoryStream = New System.IO.MemoryStream(Bytes)

                                        FinalLevelDescription = GetFinalLevelDescription()
                                        FinalLevel = _DocumentLevel.ToString

                                        If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) Then

                                            If AdvantageFramework.FileSystem.Add(_Session, Agency, MemoryStream, ProofFileName, Nothing, Nothing, _Session.UserCode, FinalLevel, FinalLevelDescription, AdvantageFramework.FileSystem.DocumentSource.DocumentUpload, FileSystemFileName, FileName, False, DocumentID) Then

                                                Document = New AdvantageFramework.Database.Entities.Document

                                                Document.DbContext = DbContext
                                                Document.FileSystemFileName = FileName
                                                Document.FileName = ProofFileName
                                                Document.Description = Nothing
                                                Document.Keywords = Nothing
                                                Document.MIMEType = AdvantageFramework.FileSystem.GetMIMEType(ProofFileName)
                                                Document.UploadedDate = System.DateTime.Now
                                                Document.UserCode = _Session.UserCode
                                                Document.FileSize = Bytes.Length
                                                Document.IsPrivate = Nothing
                                                Document.DocumentTypeID = 2
                                                Document.ProofHQUrl = ProofHQUrl
                                                Document.ProofHQFileID = FileID

                                                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                                    If AddLevelDocument(DbContext, DataContext, Document) Then

                                                        Downloaded = True

                                                    End If

                                                End If

                                            Else

                                                ErrorMessage = "Failed adding document to document repository. Please contact Software Support."

                                            End If

                                        End If

                                    End If

                                End If

                            End Using

                        End Using

                        If Downloaded Then

                            Select Case _Caller

                                Case "Documents.aspx"

                                    Me.CloseThisWindowAndRefreshCaller(_Caller & "?cf=0", True)

                                Case "Documents_JobComponent.aspx"

                                    Me.CloseThisWindowAndRefreshCaller("Documents_JobComponent.aspx?m=D&JobNum=" & _JobNumber & "&JobCompNum=" & _JobComponentNumber, True)

                                Case Else

                                    Me.CloseThisWindowAndRefreshCaller(_Caller, False, False)

                            End Select

                        Else

                            If String.IsNullOrEmpty(ErrorMessage) = False Then

                                Me.ShowMessage(ErrorMessage)

                            End If

                        End If

                    End If

                End If

        End Select

    End Sub
    Private Sub RadGridProofHQFiles_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProofHQFiles.NeedDataSource

        'objects
        Dim Proofs As Generic.List(Of AdvantageFramework.FileSystem.Classes.Proof) = Nothing
        Dim TextBoxSearch As System.Web.UI.WebControls.TextBox = Nothing
        Dim SearchQuery As String = ""

        Proofs = New Generic.List(Of AdvantageFramework.FileSystem.Classes.Proof)

        If Me.IsPostBack OrElse Me.IsCallback Then

            If RadToolbarSearch.Items.Count > 1 AndAlso TypeOf RadToolbarSearch.Items(0).FindControl("TextBoxSearch") Is TextBox Then

                TextBoxSearch = CType(RadToolbarSearch.Items(0).FindControl("TextBoxSearch"), TextBox)

                SearchQuery = TextBoxSearch.Text

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    For Each SOAPFileObject In AdvantageFramework.ProofHQ.GetProofs(DbContext, DataContext, _Session.User.EmployeeCode, SearchQuery)

                        Proofs.Add(New AdvantageFramework.FileSystem.Classes.Proof(SOAPFileObject))

                    Next

                End Using

            End Using

        End If

        RadGridProofHQFiles.DataSource = Proofs

    End Sub

#End Region

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

#Region "  Order "

	Private Function AddLevelDocument_Order(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As Boolean

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
			AddLevelDocument_Order = Added
		End Try

	End Function

#End Region

End Class