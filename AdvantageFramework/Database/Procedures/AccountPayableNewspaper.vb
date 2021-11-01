Namespace Database.Procedures.AccountPayableNewspaper

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableNewspaper)

            Load = From AccountPayableNewspaper In DbContext.GetQuery(Of Database.Entities.AccountPayableNewspaper)
                   Select AccountPayableNewspaper

        End Function
        Public Function LoadActiveByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableNewspaper)

            LoadActiveByAccountPayableID = From AccountPayableNewspaper In DbContext.GetQuery(Of Database.Entities.AccountPayableNewspaper)
                                           Where AccountPayableNewspaper.AccountPayableID = AccountPayableID AndAlso
                                                 (AccountPayableNewspaper.ModifyDelete Is Nothing OrElse
                                                  AccountPayableNewspaper.ModifyDelete = 0)
                                           Select AccountPayableNewspaper

        End Function
        Public Function LoadAllByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableNewspaper)

            LoadAllByAccountPayableID = From AccountPayableNewspaper In DbContext.GetQuery(Of Database.Entities.AccountPayableNewspaper)
                                        Where AccountPayableNewspaper.AccountPayableID = AccountPayableID
                                        Select AccountPayableNewspaper

        End Function
        Public Function LoadByAccountPayableIDAndTransaction(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal Transaction As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableNewspaper)

            LoadByAccountPayableIDAndTransaction = From AccountPayableNewspaper In DbContext.GetQuery(Of Database.Entities.AccountPayableNewspaper)
                                                   Where AccountPayableNewspaper.AccountPayableID = AccountPayableID AndAlso
                                                         AccountPayableNewspaper.GLTransaction = Transaction
                                                   Select AccountPayableNewspaper

        End Function
        Public Function LoadActiveByOrderNumberAndLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal OrderLineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableNewspaper)

            LoadActiveByOrderNumberAndLineNumber = From AccountPayableNewspaper In DbContext.GetQuery(Of Database.Entities.AccountPayableNewspaper)
                                                   Where AccountPayableNewspaper.OrderNumber = OrderNumber AndAlso
                                                         AccountPayableNewspaper.OrderLineNumber = OrderLineNumber AndAlso
                                                         (AccountPayableNewspaper.ModifyDelete Is Nothing OrElse
                                                          AccountPayableNewspaper.ModifyDelete = 0)
                                                   Select AccountPayableNewspaper

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableNewspaper As AdvantageFramework.Database.Entities.AccountPayableNewspaper) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableNewspapers.Add(AccountPayableNewspaper)

                ErrorText = AccountPayableNewspaper.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        AccountPayableNewspaper.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableNewspaper.Load(DbContext)
                                                              Where Entity.AccountPayableID = AccountPayableNewspaper.AccountPayableID AndAlso
                                                                   Entity.AccountPayableSequenceNumber = AccountPayableNewspaper.AccountPayableSequenceNumber
                                                              Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        AccountPayableNewspaper.LineNumber = 1
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
        Public Function InsertWithoutValidate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableNewspaper As AdvantageFramework.Database.Entities.AccountPayableNewspaper) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DbContext.AccountPayableNewspapers.Add(AccountPayableNewspaper)

                Try

                    AccountPayableNewspaper.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableNewspaper.Load(DbContext) _
                                                         Where Entity.AccountPayableID = AccountPayableNewspaper.AccountPayableID AndAlso _
                                                               Entity.AccountPayableSequenceNumber = AccountPayableNewspaper.AccountPayableSequenceNumber
                                                         Select Entity.LineNumber).Max + 1

                Catch ex As Exception
                    AccountPayableNewspaper.LineNumber = 1
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
