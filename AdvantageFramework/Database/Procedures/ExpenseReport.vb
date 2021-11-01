Namespace Database.Procedures.ExpenseReport

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

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As Security.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseReport)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, SecurityDbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As Security.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseReport)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, SecurityDbContext, DbContext.ExpenseReports, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As Security.Database.DbContext, ByVal ExpenseReports As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExpenseReport), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseReport)

            'objects
            Dim DetailObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExpenseReportDetail) = Nothing

            DetailObjectQuery = From dtl In AdvantageFramework.Database.Procedures.ExpenseReportDetail.Load(DbContext, False)
                                Group Join prd In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(DbContext, SecurityDbContext, DbContext.UserCode, False, False, OfficeCodes, HasLimitedOfficeCodes)
                                On dtl.ClientCode Equals prd.ClientCode And
                                   dtl.DivisionCode Equals prd.DivisionCode And
                                   dtl.ProductCode Equals prd.Code Into PrdGroup = Group
                                Where dtl.ClientCode = Nothing OrElse dtl.ClientCode = "" OrElse
                                      PrdGroup.Count() > 0
                                Select dtl

            LoadWithOfficeLimits = From ExpenseReport In ExpenseReports
                                   Join Emp In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllEmployeesByUserWithOfficeLimits(DbContext, SecurityDbContext, DbContext.UserCode, OfficeCodes, HasLimitedOfficeCodes) On ExpenseReport.EmployeeCode Equals Emp.Code
                                   Group Join dtl In DetailObjectQuery On ExpenseReport.InvoiceNumber Equals dtl.InvoiceNumber Into dtlGroup = Group
                                   Group Join dtl2 In DbContext.ExpenseReportDetails On ExpenseReport.InvoiceNumber Equals dtl2.InvoiceNumber Into dtl2Group = Group
                                   Where dtlGroup.Count() > 0 OrElse dtl2Group.Count() = 0
                                   Select ExpenseReport

        End Function
        Public Function LoadForSupervisorApproval(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SupervisorCode As String, ByVal Pending As Boolean,
                                                  ByVal Denied As Boolean, ByVal Approved As Boolean, ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ExpenseReport)

            'objects
            Dim ExpenseReportInvoiceNumbers As Integer() = Nothing
            Dim EmployeeCodes As String() = Nothing
            Dim ApprovedFlag As Short() = Nothing

            Try

                EmployeeCodes = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                 Where Entity.SupervisorApprovalRequired = 1 AndAlso
                                       ((Entity.SupervisorEmployeeCode = SupervisorCode AndAlso Entity.AlternateApproverCode Is Nothing) OrElse
                                       Entity.AlternateApproverCode = SupervisorCode)
                                 Select Entity.Code).ToArray

                If Approved AndAlso Denied AndAlso Pending Then

                    LoadForSupervisorApproval = From Entity In Load(DbContext)
                                                Where Entity.InvoiceDate >= StartDate AndAlso
                                                      Entity.InvoiceDate <= EndDate AndAlso
                                                      ((Entity.SubmittedTo Is Nothing AndAlso EmployeeCodes.Contains(Entity.EmployeeCode)) OrElse
                                                        Entity.SubmittedTo = SupervisorCode)
                                                Select Entity

                Else

                    If Approved Then

                        If Denied Then

                            ApprovedFlag = {1, 2}

                        ElseIf Pending Then

                            ApprovedFlag = {0, 2}

                        Else

                            ApprovedFlag = {2}

                        End If

                    ElseIf Denied Then

                        If Pending Then

                            ApprovedFlag = {0, 1}

                        Else

                            ApprovedFlag = {1}

                        End If

                    ElseIf Pending Then

                        ApprovedFlag = {0}

                    End If

                    LoadForSupervisorApproval = From Entity In Load(DbContext)
                                                Where Entity.InvoiceDate >= StartDate AndAlso
                                                      Entity.InvoiceDate <= EndDate AndAlso
                                                      ((Entity.SubmittedTo Is Nothing AndAlso EmployeeCodes.Contains(Entity.EmployeeCode)) OrElse
                                                        Entity.SubmittedTo = SupervisorCode) AndAlso
                                                      ApprovedFlag.Contains(Entity.IsApproved)
                                                Select Entity

                End If

            Catch ex As Exception
                LoadForSupervisorApproval = Nothing
            End Try

        End Function
        Public Function LoadByInvoiceNumber(ByVal DbContext As Database.DbContext, ByVal InvoiceNumber As String) As Database.Entities.ExpenseReport

            Try

                LoadByInvoiceNumber = (From ExpenseReport In DbContext.GetQuery(Of Database.Entities.ExpenseReport)
                                       Where ExpenseReport.InvoiceNumber = InvoiceNumber
                                       Select ExpenseReport).SingleOrDefault

            Catch ex As Exception
                LoadByInvoiceNumber = Nothing
            End Try


        End Function
        Public Function LoadByEmployeeCodeAndDate(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String, ByVal [Date] As Date) As Database.Entities.ExpenseReport

            Try

                LoadByEmployeeCodeAndDate = (From ExpenseReport In DbContext.GetQuery(Of Database.Entities.ExpenseReport)
                                             Where ExpenseReport.EmployeeCode = EmployeeCode And ExpenseReport.InvoiceDate = [Date]
                                             Select ExpenseReport).FirstOrDefault

            Catch ex As Exception

                LoadByEmployeeCodeAndDate = Nothing

            End Try

        End Function
        Public Function LoadFirstForMonthByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String, ByVal [Date] As Date) As Database.Entities.ExpenseReport

            Try

                LoadFirstForMonthByEmployeeCode = (From ExpenseReport In DbContext.GetQuery(Of Database.Entities.ExpenseReport)
                                                   Where ExpenseReport.EmployeeCode = EmployeeCode And
                                             CType(ExpenseReport.InvoiceDate, Date).Month = [Date].Month And
                                             CType(ExpenseReport.InvoiceDate, Date).Year = [Date].Year
                                                   Order By ExpenseReport.InvoiceNumber Ascending
                                                   Select ExpenseReport).FirstOrDefault

            Catch ex As Exception

                LoadFirstForMonthByEmployeeCode = Nothing

            End Try

        End Function
        Public Function LoadFirstOpenForMonthByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String, ByVal [Date] As Date) As Database.Entities.ExpenseReport

            Try

                LoadFirstOpenForMonthByEmployeeCode = (From ExpenseReport In DbContext.GetQuery(Of Database.Entities.ExpenseReport)
                                                       Where ExpenseReport.EmployeeCode = EmployeeCode And
                                             CType(ExpenseReport.InvoiceDate, Date).Month = [Date].Month And
                                             CType(ExpenseReport.InvoiceDate, Date).Year = [Date].Year And
                                             ((ExpenseReport.Status Is Nothing Or ExpenseReport.Status = 0) And
                                             (ExpenseReport.IsApproved Is Nothing Or ExpenseReport.IsApproved = 0) And
                                             (ExpenseReport.IsSubmitted Is Nothing Or ExpenseReport.IsSubmitted = 0))
                                                       Order By ExpenseReport.InvoiceNumber Ascending
                                                       Select ExpenseReport).FirstOrDefault

            Catch ex As Exception

                LoadFirstOpenForMonthByEmployeeCode = Nothing

            End Try

        End Function

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseReport)

            Load = From ExpenseReport In DbContext.GetQuery(Of Database.Entities.ExpenseReport)
                   Select ExpenseReport

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ExpenseReport.CreatedBy = DbContext.UserCode
                ExpenseReport.CreatedDate = System.DateTime.Now

                DbContext.ExpenseReports.Add(ExpenseReport)

                ErrorText = ExpenseReport.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ExpenseReport.ModifiedBy = DbContext.UserCode
                ExpenseReport.ModifiedDate = System.DateTime.Now

                If ExpenseReport.InvoiceDate IsNot Nothing Then
                    ExpenseReport.InvoiceDate = CDate(CDate(ExpenseReport.InvoiceDate).ToShortDateString)
                End If

                DbContext.UpdateObject(ExpenseReport)

                ErrorText = ExpenseReport.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument = Nothing
            Dim ExpenseDetailDocument As AdvantageFramework.Database.Entities.ExpenseDetailDocument = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Documents As Collections.Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentID As Integer = Nothing

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ExpenseReport)

                    For Each ExpenseReportDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ExpenseReportDetail).Where(Function(ExpRptDtl) ExpRptDtl.InvoiceNumber = ExpenseReport.InvoiceNumber).ToList

                        For Each ExpenseDetailDocument In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ExpenseDetailDocument).Where(Function(ExpenseDoc) ExpenseDoc.ExpenseDetailID = ExpenseReportDetail.ID).ToList

                            DbContext.DeleteEntityObject(ExpenseDetailDocument)

                        Next

                        DbContext.DeleteEntityObject(ExpenseReportDetail)

                    Next

                    Documents = New Collections.Generic.List(Of AdvantageFramework.Database.Entities.Document)

                    For Each ExpenseReportDocument In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ExpenseReportDocument).Where(Function(ExpenseDoc) ExpenseDoc.InvoiceNumber = ExpenseReport.InvoiceNumber).ToList

                        DocumentID = ExpenseReportDocument.DocumentID

                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                        If Document IsNot Nothing Then

                            Documents.Add(Document)

                        End If

                        DbContext.DeleteEntityObject(ExpenseReportDocument)

                    Next

                    DbContext.SaveChanges()

                    Deleted = True

                    If Deleted Then

                        For Each Doc In Documents

                            AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Doc)

                        Next

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
