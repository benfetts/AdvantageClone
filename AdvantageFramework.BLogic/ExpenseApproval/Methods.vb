Imports System
Imports System.Collections.Specialized
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Web

Namespace ExpenseApproval

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function GetDocumentsByExpenseDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal ExpenseDetailID As Integer) As Generic.List(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel)

            Dim SQL As String = String.Empty
            Dim list As Generic.List(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel)

            SQL = "SELECT 
	                [ExpenseDetailID] = ED.EXPDETAILID,
	                [DocumentID] = D.DOCUMENT_ID,
	                [FileName] = D.[FILENAME],
	                [RepositoryFileName] = D.REPOSITORY_FILENAME,
	                [MimeType] = D.MIME_TYPE,
	                [Description] = D.[DESCRIPTION],
	                [UploadedDate] = D.UPLOADED_DATE,
	                [FileSize] = D.FILE_SIZE
                FROM 
	                EXPENSE_DETAIL_DOCS EDD WITH(NOLOCK)
	                INNER JOIN EXPENSE_DETAIL ED WITH(NOLOCK) ON EDD.EXPDETAILID = ED.EXPDETAILID
	                INNER JOIN DOCUMENTS D WITH(NOLOCK) ON D.DOCUMENT_ID = EDD.DOCUMENT_ID
                WHERE
	                ED.EXPDETAILID = {0};
                "

            list = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel)(String.Format(SQL, ExpenseDetailID)).ToList

            Return list

        End Function
        Public Function GetDocumentsByInvoiceNumber(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal InvoiceNumber As Integer) As Generic.List(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel)

            Dim SQL As String = String.Empty
            Dim list As Generic.List(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel)

            SQL = "
                    SELECT 
	                    [ExpenseDetailID] = ED.EXPDETAILID,
	                    [DocumentID] = D.DOCUMENT_ID,
	                    [FileName] = D.[FILENAME],
	                    [RepositoryFileName] = D.REPOSITORY_FILENAME,
	                    [MimeType] = D.MIME_TYPE,
	                    [Description] = D.[DESCRIPTION],
	                    [UploadedDate] = D.UPLOADED_DATE,
	                    [FileSize] = D.FILE_SIZE
                    FROM 
	                    EXPENSE_DETAIL_DOCS EDD WITH(NOLOCK)
	                    INNER JOIN EXPENSE_DETAIL ED WITH(NOLOCK) ON EDD.EXPDETAILID = ED.EXPDETAILID
	                    INNER JOIN DOCUMENTS D WITH(NOLOCK) ON D.DOCUMENT_ID = EDD.DOCUMENT_ID
                    WHERE
	                    ED.INV_NBR = {0}
                    UNION
                    SELECT 
	                    [ExpenseDetailID] = NULL,
	                    [DocumentID] = D.DOCUMENT_ID,
	                    [FileName] = D.[FILENAME],
	                    [RepositoryFileName] = D.REPOSITORY_FILENAME,
	                    [MimeType] = D.MIME_TYPE,
	                    [Description] = D.[DESCRIPTION],
	                    [UploadedDate] = D.UPLOADED_DATE,
	                    [FileSize] = D.FILE_SIZE
                    FROM 
	                    EXPENSE_DOCS ED WITH(NOLOCK)
	                    INNER JOIN DOCUMENTS D WITH(NOLOCK) ON D.DOCUMENT_ID = ED.DOCUMENT_ID
                    WHERE
	                    ED.INV_NBR = {0}
                "

            list = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel)(String.Format(SQL, InvoiceNumber)).ToList

            Return list

        End Function
        Public Function LoadExpenseReportByInvoiceNumber(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal InvoiceNumber As Integer) As AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseReportViewModel

            Dim ExpenseReport As New AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseReportViewModel
            Dim ExpenseReportEntity As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ExpenseDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail) = Nothing
            Dim ExpenseDetailDocumentList As Generic.List(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                ExpenseReportEntity = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

            Catch ex As Exception
                ExpenseReportEntity = Nothing
            End Try

            If ExpenseReportEntity IsNot Nothing Then

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReportEntity.EmployeeCode)

                If Employee IsNot Nothing Then

                    ExpenseReport.Header.InvoiceNumber = ExpenseReportEntity.InvoiceNumber
                    ExpenseReport.Header.EmployeeCode = ExpenseReportEntity.EmployeeCode
                    ExpenseReport.Header.EmployeeFullName = Employee.ToString
                    ExpenseReport.Header.VendorCode = ExpenseReportEntity.VendorCode
                    ExpenseReport.Header.InvoiceDate = ExpenseReportEntity.InvoiceDate
                    ExpenseReport.Header.Description = ExpenseReportEntity.Description
                    ExpenseReport.Header.Details = ExpenseReportEntity.Details
                    ExpenseReport.Header.DateFrom = ExpenseReportEntity.DateFrom
                    ExpenseReport.Header.DateTo = ExpenseReportEntity.DateTo
                    ExpenseReport.Header.InvoiceAmount = ExpenseReportEntity.InvoiceAmount
                    ExpenseReport.Header.CreatedBy = ExpenseReportEntity.CreatedBy
                    ExpenseReport.Header.CreatedDate = ExpenseReportEntity.CreatedDate
                    ExpenseReport.Header.ModifiedBy = ExpenseReportEntity.ModifiedBy
                    ExpenseReport.Header.ModifiedDate = ExpenseReportEntity.ModifiedDate
                    ExpenseReport.Header.BatchDate = ExpenseReportEntity.BatchDate

                    ExpenseReport.Header.SubmittedToEmployeeCode = ExpenseReportEntity.SubmittedTo
                    ExpenseReport.Header.Status = ExpenseReportEntity.Status

                    ExpenseReport.Header.ApprovedByEmployeeCode = ExpenseReportEntity.ApprovedBy
                    ExpenseReport.Header.ApprovedDate = ExpenseReportEntity.ApprovedDate
                    ExpenseReport.Header.ApproverNotes = ExpenseReportEntity.ApproverNotes
                    ExpenseReport.Header.ApprovedFlag = ExpenseReportEntity.IsApproved

                    ExpenseReport.Header.IsSubmitted = ExpenseReportEntity.IsSubmitted

                    ExpenseReport.ExpenseReportStatus = AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReportEntity)

                    Dim ApproverSubmittedTo As AdvantageFramework.Database.Views.Employee = Nothing

                    Try 'Get Approved By

                        If ExpenseReport.ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.DeniedByAccounting OrElse
                           ExpenseReport.ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.DeniedByApprover OrElse
                           ExpenseReport.ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.Approved OrElse
                           ExpenseReport.ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.ApprovedByApprover OrElse
                           ExpenseReport.ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.ApprovedInAccounting Then

                            If String.IsNullOrWhiteSpace(ExpenseReportEntity.ApprovedBy) = False Then

                                ApproverSubmittedTo = Nothing
                                ApproverSubmittedTo = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReportEntity.ApprovedBy)

                                If ApproverSubmittedTo IsNot Nothing Then

                                    ExpenseReport.Header.ApprovedByEmployeeCode = ExpenseReportEntity.ApprovedBy
                                    ExpenseReport.Header.ApprovedByFullname = ApproverSubmittedTo.ToString

                                End If

                            End If

                        End If

                    Catch ex As Exception
                    End Try
                    Try 'Get Submitted To

                        If String.IsNullOrWhiteSpace(ExpenseReportEntity.SubmittedTo) = False Then

                            ApproverSubmittedTo = Nothing
                            ApproverSubmittedTo = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReportEntity.SubmittedTo)

                            If ApproverSubmittedTo IsNot Nothing Then

                                ExpenseReport.Header.SubmittedToEmployeeCode = ExpenseReportEntity.SubmittedTo
                                ExpenseReport.Header.SubmittedToFullname = ApproverSubmittedTo.ToString

                            End If

                        End If

                    Catch ex As Exception
                    End Try

                    ExpenseReport.Items = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel)(String.Format("EXEC [dbo].[usp_wv_get_super_appr_expense_dtl] {0};", InvoiceNumber)).ToList
                    ExpenseReport.Documents = GetDocumentsByInvoiceNumber(DbContext, ExpenseReport.Header.InvoiceNumber)

                    ExpenseReport.ExpenseReportStatusDisplay = AdvantageFramework.StringUtilities.GetNameAsWords(ExpenseReport.ExpenseReportStatus.ToString)

                    If ExpenseReport.Documents IsNot Nothing AndAlso ExpenseReport.Documents.Count > 0 Then

                        Dim WebvantageURL As String = String.Empty

                        WebvantageURL = AdvantageFramework.Database.Procedures.Agency.Load(DbContext).WebvantageURL
                        WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(WebvantageURL, "/")

                        For Each Doc As AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel In ExpenseReport.Documents

                            Doc.Link = "<a href=""" & WebvantageURL & "Media/MediaTraffic/DownloadDetailDocument?QueryString=%7C" &
                                AdvantageFramework.Security.Encryption.Encrypt("Database=" & DbContext.Database.Connection.Database & "&DocumentID=" & Doc.DocumentID) & "%7C"" ><u><strong> Download</strong></u></a>"

                        Next

                    End If
                    'If ExpenseReport.Items IsNot Nothing AndAlso ExpenseReport.Items.Count > 0 Then

                    '    For Each Item As AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel In ExpenseReport.Items

                    '        Try

                    '            Item.Documents = GetDocumentsByExpenseDetailID(DbContext, Item.ExpenseDetailID)

                    '        Catch ex As Exception
                    '            Item.Documents = Nothing
                    '        End Try
                    '        If Item.Documents Is Nothing Then

                    '            Item.Documents = New List(Of ExpenseApproval.ExpenseItemDocumentViewModel)

                    '        End If

                    '    Next

                    'End If

                End If

            End If

            Return ExpenseReport

        End Function

#End Region

    End Module

End Namespace
