Namespace Database.Procedures.AccountPayableMagazine

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableMagazine)

            Load = From AccountPayableMagazine In DbContext.GetQuery(Of Database.Entities.AccountPayableMagazine)
                   Select AccountPayableMagazine

        End Function
        Public Function LoadActiveByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableMagazine)

            LoadActiveByAccountPayableID = From AccountPayableMagazine In DbContext.GetQuery(Of Database.Entities.AccountPayableMagazine)
                                           Where AccountPayableMagazine.AccountPayableID = AccountPayableID AndAlso
                                                 (AccountPayableMagazine.ModifyDelete Is Nothing OrElse
                                                  AccountPayableMagazine.ModifyDelete = 0)
                                           Select AccountPayableMagazine

        End Function
        Public Function LoadAllByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableMagazine)

            LoadAllByAccountPayableID = From AccountPayableMagazine In DbContext.GetQuery(Of Database.Entities.AccountPayableMagazine)
                                        Where AccountPayableMagazine.AccountPayableID = AccountPayableID
                                        Select AccountPayableMagazine

        End Function
        Public Function LoadByAccountPayableIDAndTransaction(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal Transaction As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableMagazine)

            LoadByAccountPayableIDAndTransaction = From AccountPayableMagazine In DbContext.GetQuery(Of Database.Entities.AccountPayableMagazine)
                                                   Where AccountPayableMagazine.AccountPayableID = AccountPayableID AndAlso
                                                         AccountPayableMagazine.GLTransaction = Transaction
                                                   Select AccountPayableMagazine

        End Function
        Public Function LoadActiveByOrderNumberAndLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal OrderLineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableMagazine)

            LoadActiveByOrderNumberAndLineNumber = From AccountPayableMagazine In DbContext.GetQuery(Of Database.Entities.AccountPayableMagazine)
                                                   Where AccountPayableMagazine.OrderNumber = OrderNumber AndAlso
                                                         AccountPayableMagazine.OrderLineNumber = OrderLineNumber AndAlso
                                                         (AccountPayableMagazine.ModifyDelete Is Nothing OrElse
                                                          AccountPayableMagazine.ModifyDelete = 0)
                                                   Select AccountPayableMagazine

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableMagazine As AdvantageFramework.Database.Entities.AccountPayableMagazine) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableMagazines.Add(AccountPayableMagazine)

                ErrorText = AccountPayableMagazine.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        AccountPayableMagazine.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableMagazine.Load(DbContext)
                                                             Where Entity.AccountPayableID = AccountPayableMagazine.AccountPayableID AndAlso
                                                                   Entity.AccountPayableSequenceNumber = AccountPayableMagazine.AccountPayableSequenceNumber
                                                             Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        AccountPayableMagazine.LineNumber = 1
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
        Public Function InsertWithoutValidate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableMagazine As AdvantageFramework.Database.Entities.AccountPayableMagazine) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DbContext.AccountPayableMagazines.Add(AccountPayableMagazine)

                Try

                    AccountPayableMagazine.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableMagazine.Load(DbContext) _
                                                         Where Entity.AccountPayableID = AccountPayableMagazine.AccountPayableID AndAlso _
                                                               Entity.AccountPayableSequenceNumber = AccountPayableMagazine.AccountPayableSequenceNumber
                                                         Select Entity.LineNumber).Max + 1

                Catch ex As Exception
                    AccountPayableMagazine.LineNumber = 1
                End Try

                DbContext.SaveChanges()

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                InsertWithoutValidate = Inserted
            End Try

        End Function

#End Region

    End Module

End Namespace
