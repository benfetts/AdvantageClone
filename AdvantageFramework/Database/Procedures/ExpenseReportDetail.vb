Namespace Database.Procedures.ExpenseReportDetail

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

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.ExpenseReportDetail

            Try

                LoadByID = (From ExpenseReportDetail In DbContext.GetQuery(Of Database.Entities.ExpenseReportDetail)
                            Where ExpenseReportDetail.ID = ID
                            Select ExpenseReportDetail).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByInvoiceNumber(ByVal DbContext As Database.DbContext, ByVal InvoiceNumber As String, ByVal IncludeSystemGenerated As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseReportDetail)

            If IncludeSystemGenerated Then

                LoadByInvoiceNumber = From ExpenseReportDetail In DbContext.GetQuery(Of Database.Entities.ExpenseReportDetail)
                                      Where ExpenseReportDetail.InvoiceNumber = InvoiceNumber
                                      Select ExpenseReportDetail

            Else

                LoadByInvoiceNumber = From ExpenseReportDetail In DbContext.GetQuery(Of Database.Entities.ExpenseReportDetail)
                                      Where ExpenseReportDetail.InvoiceNumber = InvoiceNumber AndAlso
                                            ExpenseReportDetail.LineNumber > 0
                                      Select ExpenseReportDetail

            End If

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext, ByVal IncludeSystemGenerated As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseReportDetail)

            If IncludeSystemGenerated Then

                Load = From ExpenseReportDetail In DbContext.GetQuery(Of Database.Entities.ExpenseReportDetail)
                       Select ExpenseReportDetail

            Else

                Load = From ExpenseReportDetail In DbContext.GetQuery(Of Database.Entities.ExpenseReportDetail)
                       Where ExpenseReportDetail.LineNumber > 0
                       Select ExpenseReportDetail

            End If

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If ExpenseReportDetail.LineNumber = 0 AndAlso ExpenseReportDetail.Description.Contains("System Generated") = False Then

                    Dim LineNumber As Integer = 0

                    Try

                        LineNumber = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(MAX(LINE_NBR), 0) FROM EXPENSE_DETAIL WHERE INV_NBR = {0};", ExpenseReportDetail.InvoiceNumber)).SingleOrDefault

                    Catch ex As Exception
                        LineNumber = 0
                    End Try

                    LineNumber += 1

                    ExpenseReportDetail.LineNumber = LineNumber

                End If

                DbContext.ExpenseReportDetails.Add(ExpenseReportDetail)

                ErrorText = ExpenseReportDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail) As Boolean

            Update = Update(DbContext, ExpenseReportDetail, "")

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail, ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.UpdateObject(ExpenseReportDetail)

                ErrorText = ExpenseReportDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ExpenseReportDetail)

                    DbContext.SaveChanges()

                    Deleted = True

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
