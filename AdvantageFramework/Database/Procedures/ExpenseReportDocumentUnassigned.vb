Namespace Database.Procedures.ExpenseReportDocumentUnassigned

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

        Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Long) As Database.Entities.ExpenseReportDocumentUnassigned

            Try

                LoadByDocumentID = (From ExpenseReportDocumentUnassigned In DbContext.GetQuery(Of Database.Entities.ExpenseReportDocumentUnassigned)
                                    Where ExpenseReportDocumentUnassigned.DocumentID = DocumentID
                                    Select ExpenseReportDocumentUnassigned).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseReportDocumentUnassigned)

            LoadByEmployeeCode = From ExpenseReportDocumentUnassigned In DbContext.GetQuery(Of Database.Entities.ExpenseReportDocumentUnassigned)
                                 Where ExpenseReportDocumentUnassigned.EmployeeCode = EmployeeCode
                                 Select ExpenseReportDocumentUnassigned

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExpenseReportDocumentUnassigned)

            Load = From ExpenseReportDocumentUnassigned In DbContext.GetQuery(Of Database.Entities.ExpenseReportDocumentUnassigned)
                   Select ExpenseReportDocumentUnassigned

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDocumentUnassigned As AdvantageFramework.Database.Entities.ExpenseReportDocumentUnassigned) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ExpenseReportDocumentUnassigneds.Add(ExpenseReportDocumentUnassigned)

                ErrorText = ExpenseReportDocumentUnassigned.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDocumentUnassigned As AdvantageFramework.Database.Entities.ExpenseReportDocumentUnassigned) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ExpenseReportDocumentUnassigned)

                ErrorText = ExpenseReportDocumentUnassigned.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As Database.DbContext, ByVal ExpenseReportDocumentUnassigned As AdvantageFramework.Database.Entities.ExpenseReportDocumentUnassigned) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each DetailDocument In AdvantageFramework.Database.Procedures.ExpenseDetailDocument.LoadByDocumentID(DbContext, ExpenseReportDocumentUnassigned.DocumentID).ToList

                        DbContext.DeleteEntityObject(DetailDocument)

                    Next

                    DbContext.DeleteEntityObject(ExpenseReportDocumentUnassigned)

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
        Public Function Delete(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM EXPENSE_DOCS_UNASSND WITH(ROWLOCK) WHERE DOCUMENT_ID = {0};", DocumentID))

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
