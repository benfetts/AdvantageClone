Namespace Database.Procedures.ExpenseSummary

    <HideModuleName()> _
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

        Public Function LoadForSupervisorApproval(ByVal DbContext As Database.DbContext, ByVal SupervisorCode As String, ByVal Pending As Boolean,
                                                  ByVal Denied As Boolean, ByVal Approved As Boolean, ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.ExpenseSummary)

            'objects
            Dim ExpenseReportInvoiceNumbers As Integer() = Nothing
            Dim EmployeeCodes As String() = Nothing
            Dim Status As Short() = Nothing
            Dim Statuses As System.Collections.Generic.List(Of Short) = Nothing

            Try

                EmployeeCodes = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                 Where Entity.SupervisorApprovalRequired = 1 AndAlso
                                       ((Entity.SupervisorEmployeeCode = SupervisorCode AndAlso Entity.AlternateApproverCode Is Nothing) OrElse
                                       Entity.AlternateApproverCode = SupervisorCode)
                                 Select Entity.Code).ToArray

                If Approved AndAlso Denied AndAlso Pending Then

                    LoadForSupervisorApproval = From Entity In Load(DbContext)
                                                Where Entity.IsSubmitted = 1 AndAlso
                                                      Entity.InvoiceDate >= StartDate AndAlso
                                                      Entity.InvoiceDate <= EndDate AndAlso
                                                      ((Entity.SubmittedTo Is Nothing AndAlso EmployeeCodes.Contains(Entity.EmployeeCode)) OrElse
                                                        Entity.SubmittedTo = SupervisorCode)
                                                Select Entity

                Else

                    Statuses = New System.Collections.Generic.List(Of Short)

                    If Pending Then

                        Statuses.Add(0)

                    End If

                    If Denied Then

                        Statuses.Add(1)

                    End If

                    If Approved Then

                        Statuses.Add(2)

                    End If

                    LoadForSupervisorApproval = From Entity In Load(DbContext)
                                                Where Entity.IsSubmitted = 1 AndAlso
                                                      Entity.InvoiceDate >= StartDate AndAlso
                                                      Entity.InvoiceDate <= EndDate AndAlso
                                                      ((Entity.SubmittedTo Is Nothing AndAlso EmployeeCodes.Contains(Entity.EmployeeCode)) OrElse
                                                        Entity.SubmittedTo = SupervisorCode) AndAlso
                                                      Statuses.Contains(Entity.IsApproved)
                                                Select Entity

                End If

            Catch ex As Exception
                LoadForSupervisorApproval = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ExpenseSummary)

            Load = From ExpenseSummary In DbContext.GetQuery(Of Database.Views.ExpenseSummary)
                   Select ExpenseSummary

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseSummary As AdvantageFramework.Database.Views.ExpenseSummary, ByVal ApproverEmployeeCode As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Query As String = ""

            Try

                If ExpenseSummary.IsApproved = AdvantageFramework.Database.Entities.ExpenseReportStatus.Approved Then

                    Query = String.Format("UPDATE dbo.EXPENSE_HEADER SET APPR_NOTES = '{0}' , APPROVED_FLAG = {1} , APPROVED_BY = '{2}' , APPROVED_DATE = '{3}' WHERE INV_NBR = {4}",
                                           If(ExpenseSummary.ApproverNotes IsNot Nothing, ExpenseSummary.ApproverNotes.ToString.Replace("'", "''"), ""), ExpenseSummary.IsApproved, ApproverEmployeeCode, Now.ToString("MM/dd/yyyy"), ExpenseSummary.InvoiceNumber)

                Else

                    Query = String.Format("UPDATE dbo.EXPENSE_HEADER SET APPR_NOTES = '{0}' , APPROVED_FLAG = {1} , APPROVED_BY = NULL , APPROVED_DATE = NULL WHERE INV_NBR = {2}",
                                          If(ExpenseSummary.ApproverNotes IsNot Nothing, ExpenseSummary.ApproverNotes.ToString.Replace("'", "''"), ""), ExpenseSummary.IsApproved, ExpenseSummary.InvoiceNumber)

                End If

                DbContext.Database.ExecuteSqlCommand(Query)

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

#End Region

    End Module

End Namespace
