Namespace Database.Procedures.AccountPayableProductionComment

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableProductionComment)

            Load = From AccountPayableProductionComment In DbContext.GetQuery(Of Database.Entities.AccountPayableProductionComment)
                   Select AccountPayableProductionComment

        End Function
        Public Function LoadByAccountPayableIDLineNumber(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal LineNumber As Short) As Database.Entities.AccountPayableProductionComment

            Try

                LoadByAccountPayableIDLineNumber = (From AccountPayableProductionComment In DbContext.GetQuery(Of Database.Entities.AccountPayableProductionComment)
                                                    Where AccountPayableProductionComment.AccountPayableID = AccountPayableID AndAlso
                                                          AccountPayableProductionComment.LineNumber = LineNumber
                                                    Select AccountPayableProductionComment).SingleOrDefault

            Catch ex As Exception
                LoadByAccountPayableIDLineNumber = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableProductionComment As AdvantageFramework.Database.Entities.AccountPayableProductionComment) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableProductionComments.Add(AccountPayableProductionComment)

                ErrorText = AccountPayableProductionComment.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableProductionComment As AdvantageFramework.Database.Entities.AccountPayableProductionComment) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountPayableProductionComment)

                ErrorText = AccountPayableProductionComment.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableProductionComment As AdvantageFramework.Database.Entities.AccountPayableProductionComment) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AccountPayableProductionComment)

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
