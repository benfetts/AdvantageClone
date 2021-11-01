Namespace Database.Procedures.AccountPayableGLDistribution

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableGLDistribution)

            Load = From AccountPayableGLDistribution In DbContext.GetQuery(Of Database.Entities.AccountPayableGLDistribution)
                   Select AccountPayableGLDistribution

        End Function
        Public Function LoadActiveByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableGLDistribution)

            LoadActiveByAccountPayableID = From AccountPayableGLDistribution In DbContext.GetQuery(Of Database.Entities.AccountPayableGLDistribution)
                                           Where AccountPayableGLDistribution.AccountPayableID = AccountPayableID AndAlso
                                                 (AccountPayableGLDistribution.ModifyDelete Is Nothing OrElse
                                                  AccountPayableGLDistribution.ModifyDelete = 0)
                                           Select AccountPayableGLDistribution

        End Function
        Public Function LoadAllByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableGLDistribution)

            LoadAllByAccountPayableID = From AccountPayableGLDistribution In DbContext.GetQuery(Of Database.Entities.AccountPayableGLDistribution)
                                        Where AccountPayableGLDistribution.AccountPayableID = AccountPayableID
                                        Select AccountPayableGLDistribution

        End Function
        Public Function LoadByAccountPayableIDAndTransaction(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal Transaction As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableGLDistribution)

            LoadByAccountPayableIDAndTransaction = From AccountPayableGLDistribution In DbContext.GetQuery(Of Database.Entities.AccountPayableGLDistribution)
                                                   Where AccountPayableGLDistribution.AccountPayableID = AccountPayableID AndAlso
                                                         AccountPayableGLDistribution.GLTransaction = Transaction
                                                   Select AccountPayableGLDistribution

        End Function
        Public Function LoadAllActiveByPONumberAndPODetailLineNumber(ByVal DbContext As Database.DbContext, ByVal PONumber As Integer, ByVal PODetailLineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableGLDistribution)

            LoadAllActiveByPONumberAndPODetailLineNumber = From AccountPayableGLDistribution In DbContext.GetQuery(Of Database.Entities.AccountPayableGLDistribution)
                                                           Where AccountPayableGLDistribution.PONumber = PONumber AndAlso
                                                                 AccountPayableGLDistribution.PODetailLineNumber = PODetailLineNumber AndAlso
                                                                 (AccountPayableGLDistribution.ModifyDelete Is Nothing OrElse AccountPayableGLDistribution.ModifyDelete = 0)
                                                           Select AccountPayableGLDistribution

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableGLDistribution As AdvantageFramework.Database.Entities.AccountPayableGLDistribution) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableGLDistributions.Add(AccountPayableGLDistribution)

                ErrorText = AccountPayableGLDistribution.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        AccountPayableGLDistribution.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableGLDistribution.Load(DbContext)
                                                                   Where Entity.AccountPayableID = AccountPayableGLDistribution.AccountPayableID AndAlso
                                                                         Entity.AccountPayableSequenceNumber = AccountPayableGLDistribution.AccountPayableSequenceNumber
                                                                   Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        AccountPayableGLDistribution.LineNumber = 1
                    End Try

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
        Public Function InsertWithoutValidate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableGLDistribution As AdvantageFramework.Database.Entities.AccountPayableGLDistribution) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DbContext.AccountPayableGLDistributions.Add(AccountPayableGLDistribution)

                Try

                    AccountPayableGLDistribution.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableGLDistribution.Load(DbContext)
                                                               Where Entity.AccountPayableID = AccountPayableGLDistribution.AccountPayableID AndAlso
                                                                     Entity.AccountPayableSequenceNumber = AccountPayableGLDistribution.AccountPayableSequenceNumber
                                                               Select Entity.LineNumber).Max + 1

                Catch ex As Exception
                    AccountPayableGLDistribution.LineNumber = 1
                End Try

                DbContext.SaveChanges()

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                InsertWithoutValidate = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableGLDistribution As AdvantageFramework.Database.Entities.AccountPayableGLDistribution) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountPayableGLDistribution)

                ErrorText = AccountPayableGLDistribution.ValidateEntity(IsValid)

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
