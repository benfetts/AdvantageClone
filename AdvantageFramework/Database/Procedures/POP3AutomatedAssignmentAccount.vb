Namespace Database.Procedures.POP3AutomatedAssignmentAccount

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

        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.POP3AutomatedAssignmentAccount)

            Load = From POP3AutomatedAssignmentAccount In DbContext.GetQuery(Of Database.Entities.POP3AutomatedAssignmentAccount)
                   Select POP3AutomatedAssignmentAccount

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, POP3AutomatedAssignmentAccount As AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.POP3AutomatedAssignmentAccounts.Add(POP3AutomatedAssignmentAccount)

                ErrorText = POP3AutomatedAssignmentAccount.ValidateEntity(IsValid)

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, POP3AutomatedAssignmentAccount As AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(POP3AutomatedAssignmentAccount)

                ErrorText = POP3AutomatedAssignmentAccount.ValidateEntity(IsValid)

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, POP3AutomatedAssignmentAccount As AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(POP3AutomatedAssignmentAccount)

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
