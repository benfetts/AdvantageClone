Imports System.Data
Imports System.Data.SqlClient
Imports MyGeneration.dOOdads
Imports Webvantage.cGlobals
Public Class Document
    Inherits _DOCUMENTS
    Private oSQL As SqlHelper
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString

    End Sub
    Public Function Add(ByVal filename As String, ByVal mimeType As String, ByVal repositoryFilename As String, ByVal fileSize As Integer, _
                        ByVal userCode As String, ByVal description As String, ByVal keywords As String, _
                        Optional ByVal private_flag As Integer = 0, Optional ByVal type As Integer = 2) As Integer
        Try
            Dim arP(11) As SqlParameter

            Dim pDocumentId As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
            'pDocumentId.Value = adnumber
            pDocumentId.Direction = ParameterDirection.Output
            arP(0) = pDocumentId

            Dim pFileName As New SqlParameter("@FILENAME", SqlDbType.VarChar, 300)
            pFileName.Value = filename
            arP(1) = pFileName

            Dim pRepositoryName As New SqlParameter("@REPOSITORY_FILENAME", SqlDbType.VarChar, 200)
            pRepositoryName.Value = repositoryFilename
            arP(2) = pRepositoryName

            Dim pMimeType As New SqlParameter("@MIME_TYPE", SqlDbType.VarChar, 50)
            If mimeType Is Nothing OrElse mimeType = "" Then
                Dim m As New MimeTypes
                mimeType = m.GetContentType(filename)
            End If
            pMimeType.Value = mimeType
            arP(3) = pMimeType

            Dim pDescription As New SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 200)
            pDescription.Value = description
            arP(4) = pDescription

            Dim pKeywords As New SqlParameter("@KEYWORDS", SqlDbType.VarChar, 255)
            pKeywords.Value = keywords
            arP(5) = pKeywords

            Dim pUploadedDate As New SqlParameter("@UPLOADED_DATE", SqlDbType.DateTime)
            pUploadedDate.Value = Date.Now
            arP(6) = pUploadedDate

            Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUserCode.Value = userCode
            arP(7) = pUserCode

            Dim pFileSize As New SqlParameter("@FILE_SIZE", SqlDbType.Int)
            pFileSize.Value = fileSize
            arP(8) = pFileSize

            Dim pPrivateFlag As New SqlParameter("@PRIVATE_FLAG", SqlDbType.Int)
            If private_flag = 0 Then
                pPrivateFlag.Value = System.DBNull.Value
            Else
                pPrivateFlag.Value = 1
            End If
            arP(9) = pPrivateFlag

            Dim pDocumentTypeId As New SqlParameter("@DOCUMENT_TYPE_ID", SqlDbType.Int)
            pDocumentTypeId.Value = type
            arP(10) = pDocumentTypeId

            SqlHelper.ExecuteScalar(HttpContext.Current.Session("ConnString"), CommandType.StoredProcedure, "proc_DOCUMENTSInsert", arP)

            Return CType(pDocumentId.Value, Integer)

        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function AddAdNumberDocument(ByVal adnumber As String, ByVal documentid As Integer)
        Try
            Dim arParams(2) As SqlParameter

            Dim paramAD_NBR As New SqlParameter("@AD_NBR", SqlDbType.VarChar)
            paramAD_NBR.Value = adnumber
            arParams(0) = paramAD_NBR

            Dim paramDOCUMENT_ID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
            If documentid = 0 Then
                paramDOCUMENT_ID.Value = DBNull.Value
            Else
                paramDOCUMENT_ID.Value = documentid
            End If
            arParams(1) = paramDOCUMENT_ID


            oSQL.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_AddAdNumberDocument", arParams)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddContractDocument(ByVal DocumentID As Integer, ByVal ContractID As Integer, UserCode As String) As Boolean

        Dim Added As Boolean = False
        Dim ContractDocument As AdvantageFramework.Database.Entities.ContractDocument = Nothing

        Try

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.ConnectionString, UserCode)

                ContractDocument = New AdvantageFramework.Database.Entities.ContractDocument

                ContractDocument.DocumentID = DocumentID
                ContractDocument.ContractID = ContractID

                Added = AdvantageFramework.Database.Procedures.ContractDocument.Insert(DbContext, ContractDocument)

            End Using

        Catch ex As Exception
            Added = False
        End Try

        AddContractDocument = Added

    End Function

    Public Function AddContractReportDocument(ByVal DocumentID As Integer, ByVal ContractReportID As Integer, UserCode As String) As Boolean

        Dim Added As Boolean = False
        Dim ContractReportDocument As AdvantageFramework.Database.Entities.ContractReportDocument = Nothing

        Try

            ContractReportDocument = New AdvantageFramework.Database.Entities.ContractReportDocument

            ContractReportDocument.DocumentID = DocumentID
            ContractReportDocument.ContractReportID = ContractReportID

            Using DataContext As New AdvantageFramework.Database.DataContext(Me.ConnectionString, UserCode)

                Added = AdvantageFramework.Database.Procedures.ContractReportDocument.Insert(DataContext, ContractReportDocument)

            End Using

        Catch ex As Exception
            Added = False
        Finally
            AddContractReportDocument = Added
        End Try

    End Function
    Public Function AddTaskDocument(ByVal DocumentID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, UserCode As String) As Boolean

        Dim Added As Boolean = False
        Dim JobComponentTaskDocument As AdvantageFramework.Database.Entities.JobComponentTaskDocument = Nothing

        Try

            JobComponentTaskDocument = New AdvantageFramework.Database.Entities.JobComponentTaskDocument

            JobComponentTaskDocument.DocumentID = DocumentID
            JobComponentTaskDocument.JobNumber = JobNumber
            JobComponentTaskDocument.JobComponentNumber = JobComponentNumber
            JobComponentTaskDocument.SequenceNumber = SequenceNumber

            Using DataContext As New AdvantageFramework.Database.DataContext(Me.ConnectionString, UserCode)

                Added = AdvantageFramework.Database.Procedures.JobComponentTaskDocument.Insert(DataContext, JobComponentTaskDocument)

            End Using

        Catch ex As Exception
            Added = False
        Finally
            AddTaskDocument = Added
        End Try

    End Function

    Public Function AddContractValueAddedDocument(ByVal DocumentID As Integer, ByVal ValueAddedID As Integer, UserCode As String) As Boolean

        Dim Added As Boolean = False
        Dim ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing

        Try

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.ConnectionString, UserCode)

                ContractValueAdded = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, ValueAddedID)

                If ContractValueAdded IsNot Nothing Then

                    ContractValueAdded.DocumentID = DocumentID
                    Added = AdvantageFramework.Database.Procedures.ContractValueAdded.Update(DbContext, ContractValueAdded)

                End If

            End Using

        Catch ex As Exception
            Added = False
        Finally
            AddContractValueAddedDocument = Added
        End Try

    End Function

    Public Function AddExpenseDocument(ByVal documentid As Integer, ByVal inv_nbr As Integer)
        Try
            Dim arParams(2) As SqlParameter

            Dim paramDOCUMENT_ID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
            If documentid = 0 Then
                paramDOCUMENT_ID.Value = DBNull.Value
            Else
                paramDOCUMENT_ID.Value = documentid
            End If
            arParams(0) = paramDOCUMENT_ID

            Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.Int)
            paramINV_NBR.Value = inv_nbr
            arParams(1) = paramINV_NBR

            oSQL.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_AddExpenseDocument", arParams)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteExpenseDocument(ByVal documentid As Integer, ByVal inv_nbr As Integer)
        Try
            Dim arParams(2) As SqlParameter

            Dim paramDOCUMENT_ID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
            If documentid = 0 Then
                paramDOCUMENT_ID.Value = DBNull.Value
            Else
                paramDOCUMENT_ID.Value = documentid
            End If
            arParams(0) = paramDOCUMENT_ID

            Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.Int)
            paramINV_NBR.Value = inv_nbr
            arParams(1) = paramINV_NBR

            oSQL.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_DeleteExpenseDocument", arParams)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetCurrentAdNumberDocument(ByVal adnumber As String, ByVal clcode As String, ByVal priv As Integer)
        Try
            Dim dt As DataTable
            Dim arParams(2) As SqlParameter

            Dim paramAD_NBR As New SqlParameter("@AD_NBR", SqlDbType.VarChar)
            paramAD_NBR.Value = adnumber
            arParams(0) = paramAD_NBR

            Dim paramCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar)
            paramCL_CODE.Value = clcode
            arParams(1) = paramCL_CODE

            Dim paramPRIVATE As New SqlParameter("@Private", SqlDbType.SmallInt)
            paramPRIVATE.Value = priv
            arParams(2) = paramPRIVATE

            'Dim paramDOCUMENT_ID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
            'paramDOCUMENT_ID.Value = documentid
            'arParams(1) = paramDOCUMENT_ID


            dt = oSQL.ExecuteDataTable(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_GetCurrentAdNumberDocument", "dt", arParams)
            Return dt
        Catch ex As Exception
            'Return False
        End Try
    End Function

    Public Function GetCurrentExpenseDocument(ByVal inv As String, ByVal emp As String, ByVal criteria As String, ByVal history As Int16, ByVal priv As Integer)
        Try
            Dim dt As DataTable
            Dim arParams(5) As SqlParameter

            Dim paramINV_NBR As New SqlParameter("@INV_NBR", SqlDbType.VarChar)
            paramINV_NBR.Value = inv
            arParams(0) = paramINV_NBR

            Dim paramEMP As New SqlParameter("@EMP", SqlDbType.VarChar)
            paramEMP.Value = emp
            arParams(1) = paramEMP

            'Dim paramDATE As New SqlParameter("@INVDATE", SqlDbType.VarChar)
            'paramDATE.Value = invdate
            'arParams(2) = paramDATE

            Dim paramFILTER As New SqlParameter("@Filter", SqlDbType.VarChar)
            paramFILTER.Value = criteria.ToLower
            arParams(2) = paramFILTER

            Dim paramHISTORY As New SqlParameter("@History", SqlDbType.SmallInt)
            paramHISTORY.Value = history
            arParams(3) = paramHISTORY

            Dim paramPRIVATE As New SqlParameter("@Private", SqlDbType.SmallInt)
            paramPRIVATE.Value = priv
            arParams(4) = paramPRIVATE

            dt = oSQL.ExecuteDataTable(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_GetCurrentExpenseDocument", "dt", arParams)
            Return dt
        Catch ex As Exception
        End Try
    End Function

    Public Function GetCampaignDocuments(ByVal cmpID As Integer, ByVal priv As Integer, ByVal userid As String)
        Try
            Dim dt As DataTable
            Dim arParams(2) As SqlParameter

            Dim paramCMP_ID As New SqlParameter("@CMP_ID", SqlDbType.Int)
            paramCMP_ID.Value = cmpID
            arParams(0) = paramCMP_ID

            Dim paramPRIVATE As New SqlParameter("@Private", SqlDbType.SmallInt)
            paramPRIVATE.Value = priv
            arParams(1) = paramPRIVATE

            Dim paramUSER As New SqlParameter("@User", SqlDbType.VarChar, 100)
            paramUSER.Value = userid
            arParams(2) = paramUSER

            dt = oSQL.ExecuteDataTable(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_GetCampaignDocuments", "dt", arParams)
            Return dt
        Catch ex As Exception
        End Try
    End Function

End Class



Public Class ClientDocuments
    Inherits _CLIENT_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
    Public Function Add(ByVal clientCode As String, ByVal filename As String, ByVal mimeType As String, ByVal repositoryFileName As String, ByVal fileSize As Integer, ByVal userCode As String, ByVal description As String, ByVal keywords As String, ByVal private_flag As Integer, ByVal type As Integer) As Integer
        Try
            Dim DocumentId As Integer
            Dim Document As New Document(Me.ConnectionString)
            DocumentId = Document.Add(filename, mimeType, repositoryFileName, fileSize, userCode, description, keywords, private_flag, type)

            Dim newDocument As New ClientDocuments(Me.ConnectionString)
            newDocument.AddNew()
            newDocument.CL_CODE = clientCode
            newDocument.DOCUMENT_ID = DocumentId
            newDocument.Save()

            Return DocumentId
        Catch ex As Exception
            Return -1
        End Try

    End Function
End Class

Public Class DivisionDocuments
    Inherits _DIVISION_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
    Public Function Add(ByVal clientCode As String, ByVal divisionCode As String, ByVal filename As String, ByVal mimeType As String, ByVal repositoryFileName As String, ByVal fileSize As Integer, ByVal userCode As String, ByVal description As String, ByVal keywords As String, ByVal private_flag As Integer, ByVal type As Integer) As Integer
        Dim Document As New Document(Me.ConnectionString)
        Dim DocumentId As Integer

        DocumentId = Document.Add(filename, mimeType, repositoryFileName, fileSize, userCode, description, keywords, private_flag, type)

        Dim newDocument As New DivisionDocuments(Me.ConnectionString)
        newDocument.AddNew()
        newDocument.CL_CODE = clientCode
        newDocument.DIV_CODE = divisionCode
        newDocument.DOCUMENT_ID = DocumentId
        newDocument.Save()

        Return DocumentId

    End Function
End Class

Public Class ProductDocuments
    Inherits _PRODUCT_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
    Public Function Add(ByVal clientCode As String, ByVal divisionCode As String, ByVal productCode As String, ByVal filename As String, ByVal mimeType As String, ByVal repositoryFileName As String, ByVal fileSize As Integer, ByVal userCode As String, ByVal description As String, ByVal keywords As String, ByVal private_flag As Integer, ByVal type As Integer) As Integer
        Dim Document As New Document(Me.ConnectionString)
        Dim DocumentId As Integer

        DocumentId = Document.Add(filename, mimeType, repositoryFileName, fileSize, userCode, description, keywords, private_flag, type)

        Dim newDocument As New ProductDocuments(Me.ConnectionString)
        newDocument.AddNew()
        newDocument.CL_CODE = clientCode
        newDocument.DIV_CODE = divisionCode
        newDocument.PRD_CODE = productCode
        newDocument.DOCUMENT_ID = DocumentId
        newDocument.Save()

        Return DocumentId

    End Function
End Class

Public Class JobDocument
    Inherits _JOB_DOCUMENTS

    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
    Public Overloads Function Add(ByVal jobNumber As Integer, ByVal filename As String, ByVal mimeType As String, ByVal repositoryFileName As String, ByVal fileSize As Integer, ByVal userCode As String,
                                  ByVal description As String, ByVal keywords As String, ByVal private_flag As Integer, ByVal type As Integer,
                                  Optional ByVal DocumentID As Integer = 0) As Integer
        Try

            If DocumentID = 0 Then

                Dim Document As New Document(Me.ConnectionString)
                DocumentID = Document.Add(filename, mimeType, repositoryFileName, fileSize, userCode, description, keywords, private_flag, type)

            End If
            If DocumentID > 0 Then

                Dim newDocument As New JobDocument(Me.ConnectionString)

                newDocument.AddNew()

                newDocument.JOB_NUMBER = jobNumber
                newDocument.DOCUMENT_ID = DocumentID

                newDocument.Save()

            End If

            Return DocumentID
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Overloads Function Add(ByVal DocumentId As Integer, ByVal jobNumber As Integer)
        Dim newDocument As New JobDocument(Me.ConnectionString)
        newDocument.AddNew()
        newDocument.JOB_NUMBER = jobNumber
        newDocument.DOCUMENT_ID = DocumentId
        newDocument.Save()
        Return DocumentId
    End Function

End Class

Public Class JobComponentDocuments
    Inherits _JOB_COMPONENT_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
    Public Overloads Function Add(ByVal jobNumber As Integer, ByVal jobComponentNumber As Integer, ByVal filename As String, ByVal mimeType As String, ByVal repositoryFileName As String,
                                  ByVal fileSize As Integer, ByVal userCode As String, ByVal description As String, ByVal keywords As String, ByVal private_flag As Integer, ByVal type As Integer,
                                  Optional ByVal DocumentID As Integer = 0) As Integer
        Try

            If DocumentID = 0 Then

                Dim Document As New Document(Me.ConnectionString)
                DocumentID = Document.Add(filename, mimeType, repositoryFileName, fileSize, userCode, description, keywords, private_flag, type)

            End If
            If DocumentID > 0 Then

                Dim newDocument As New JobComponentDocuments(Me.ConnectionString)

                newDocument.AddNew()

                newDocument.JOB_NUMBER = jobNumber
                newDocument.JOB_COMPONENT_NUMBER = jobComponentNumber
                newDocument.DOCUMENT_ID = DocumentID

                newDocument.Save()

            End If

            Return DocumentID

        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Overloads Function Add(ByVal DocumentId As Integer, ByVal jobNumber As Integer, ByVal jobComponentNumber As Integer)
        Dim newDocument As New JobComponentDocuments(Me.ConnectionString)
        newDocument.AddNew()
        newDocument.JOB_NUMBER = jobNumber
        newDocument.JOB_COMPONENT_NUMBER = jobComponentNumber
        newDocument.DOCUMENT_ID = DocumentId
        newDocument.Save()
        Return DocumentId
    End Function
End Class

Public Class OfficeDocuments
    Inherits _OFFICE_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
    Public Function Add(ByVal officeCode As String, ByVal filename As String, ByVal mimeType As String, ByVal repositoryFileName As String, ByVal fileSize As Integer, ByVal userCode As String, ByVal description As String, ByVal keywords As String, ByVal private_flag As Integer, ByVal type As Integer) As Integer
        Dim Document As New Document(Me.ConnectionString)
        Dim DocumentId As Integer

        DocumentId = Document.Add(filename, mimeType, repositoryFileName, fileSize, userCode, description, keywords, private_flag, type)

        Dim newDocument As New OfficeDocuments(Me.ConnectionString)
        newDocument.AddNew()
        newDocument.OFFICE_CODE = officeCode
        newDocument.DOCUMENT_ID = DocumentId
        newDocument.Save()

        Return DocumentId

    End Function
End Class

Public Class CampaignDocument
    Inherits _CAMPAIGN_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
    Public Function Add(ByVal campaignIdentifier As Integer, ByVal filename As String, ByVal mimeType As String, ByVal repositoryFileName As String, ByVal fileSize As Integer, ByVal userCode As String, ByVal description As String, ByVal keywords As String, ByVal value As String, ByVal private_flag As Integer, ByVal type As Integer) As Integer
        Dim Document As New Document(Me.ConnectionString)
        Dim DocumentId As Integer

        DocumentId = Document.Add(filename, mimeType, repositoryFileName, fileSize, userCode, description, keywords, private_flag, type)

        Dim newDocument As New CampaignDocument(Me.ConnectionString)
        newDocument.AddNew()
        newDocument.CMP_IDENTIFIER = campaignIdentifier
        'newDocument.CMP_CODE = value
        newDocument.DOCUMENT_ID = DocumentId
        newDocument.Save()

        Return DocumentId

    End Function
End Class

Public Class APDocument
    Inherits _AP_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
    Public Function Add(ByVal APID As Integer, ByVal filename As String, ByVal mimeType As String, ByVal repositoryFileName As String, ByVal fileSize As Integer, ByVal userCode As String, ByVal description As String, ByVal keywords As String, ByVal private_flag As Integer, ByVal type As Integer) As Integer
        Dim Document As New Document(Me.ConnectionString)
        Dim DocumentId As Integer

        DocumentId = Document.Add(filename, mimeType, repositoryFileName, fileSize, userCode, description, keywords, private_flag, type)

        Dim newDocument As New APDocument(Me.ConnectionString)
        newDocument.AddNew()
        newDocument.AP_ID = APID
        newDocument.DOCUMENT_ID = DocumentId
        newDocument.Save()

        Return DocumentId

    End Function
End Class

Public Class AgencyDesktopDocument
    Inherits _AGENCY_DESKTOP_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
    Public Function Add(ByVal officecode As String, ByVal deptcode As String, ByVal filename As String, ByVal mimeType As String, ByVal repositoryFileName As String, ByVal fileSize As Integer, ByVal userCode As String, ByVal description As String, ByVal keywords As String, ByVal private_flag As Integer, ByVal type As Integer) As Integer
        Dim Document As New Document(Me.ConnectionString)
        Dim DocumentId As Integer

        DocumentId = Document.Add(filename, mimeType, repositoryFileName, fileSize, userCode, description, keywords, private_flag, type)

        Dim newDocument As New AgencyDesktopDocument(Me.ConnectionString)
        newDocument.AddNew()
        newDocument.OFFICE_CODE = officecode
        newDocument.DP_TM_CODE = deptcode
        newDocument.DOCUMENT_ID = DocumentId
        newDocument.Save()

        Return DocumentId

    End Function
End Class

Public Class ExecutiveDesktopDocument
    Inherits _EXEC_DESKTOP_DOCUMENTS
    Public Sub New(ByVal connectionString As String)
        Me.ConnectionString = connectionString
    End Sub
    Public Function Add(ByVal officecode As String, ByVal filename As String, ByVal mimeType As String, ByVal repositoryFileName As String, ByVal fileSize As Integer, ByVal userCode As String, ByVal description As String, ByVal keywords As String, ByVal private_flag As Integer, ByVal type As Integer) As Integer
        Dim Document As New Document(Me.ConnectionString)
        Dim DocumentId As Integer

        DocumentId = Document.Add(filename, mimeType, repositoryFileName, fileSize, userCode, description, keywords, private_flag, type)

        Dim newDocument As New ExecutiveDesktopDocument(Me.ConnectionString)
        newDocument.AddNew()
        newDocument.OFFICE_CODE = officecode
        newDocument.DOCUMENT_ID = DocumentId
        newDocument.Save()

        Return DocumentId

    End Function
End Class


