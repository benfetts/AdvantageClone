Namespace Database.Procedures.AccountPayableTV

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableTV)

            Load = From AccountPayableTV In DbContext.GetQuery(Of Database.Entities.AccountPayableTV)
                   Select AccountPayableTV

        End Function
        Public Function LoadActiveByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableTV)

            LoadActiveByAccountPayableID = From AccountPayableTV In DbContext.GetQuery(Of Database.Entities.AccountPayableTV)
                                           Where AccountPayableTV.AccountPayableID = AccountPayableID AndAlso
                                                 (AccountPayableTV.ModifyDelete Is Nothing OrElse
                                                  AccountPayableTV.ModifyDelete = 0)
                                           Select AccountPayableTV

        End Function
        Public Function LoadAllByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableTV)

            LoadAllByAccountPayableID = From AccountPayableTV In DbContext.GetQuery(Of Database.Entities.AccountPayableTV)
                                        Where AccountPayableTV.AccountPayableID = AccountPayableID
                                        Select AccountPayableTV

        End Function
        Public Function LoadByAccountPayableIDAndTransaction(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal Transaction As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableTV)

            LoadByAccountPayableIDAndTransaction = From AccountPayableTV In DbContext.GetQuery(Of Database.Entities.AccountPayableTV)
                                                   Where AccountPayableTV.AccountPayableID = AccountPayableID AndAlso
                                                         AccountPayableTV.GLTransaction = Transaction
                                                   Select AccountPayableTV

        End Function
        Public Function LoadActiveByOrderNumberAndLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal OrderLineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableTV)

            LoadActiveByOrderNumberAndLineNumber = From AccountPayableTV In DbContext.GetQuery(Of Database.Entities.AccountPayableTV)
                                                   Where AccountPayableTV.OrderNumber = OrderNumber AndAlso
                                                         AccountPayableTV.OrderLineNumber = OrderLineNumber AndAlso
                                                         (AccountPayableTV.ModifyDelete Is Nothing OrElse
                                                          AccountPayableTV.ModifyDelete = 0)
                                                   Select AccountPayableTV

        End Function
        Public Function LoadActiveByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableTV)

            LoadActiveByOrderNumber = From AccountPayableTV In DbContext.GetQuery(Of Database.Entities.AccountPayableTV)
                                      Where AccountPayableTV.OrderNumber = OrderNumber AndAlso
                                            (AccountPayableTV.ModifyDelete Is Nothing OrElse
                                             AccountPayableTV.ModifyDelete = 0)
                                      Select AccountPayableTV

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableTV As AdvantageFramework.Database.Entities.AccountPayableTV) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableTVs.Add(AccountPayableTV)

                ErrorText = AccountPayableTV.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        AccountPayableTV.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableTV.Load(DbContext)
                                                       Where Entity.AccountPayableID = AccountPayableTV.AccountPayableID AndAlso
                                                                Entity.AccountPayableSequenceNumber = AccountPayableTV.AccountPayableSequenceNumber
                                                       Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        AccountPayableTV.LineNumber = 1
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
        Public Function InsertWithoutValidate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableTV As AdvantageFramework.Database.Entities.AccountPayableTV) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DbContext.AccountPayableTVs.Add(AccountPayableTV)

                Try

                    AccountPayableTV.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableTV.Load(DbContext) _
                                                   Where Entity.AccountPayableID = AccountPayableTV.AccountPayableID AndAlso _
                                                         Entity.AccountPayableSequenceNumber = AccountPayableTV.AccountPayableSequenceNumber
                                                   Select Entity.LineNumber).Max + 1

                Catch ex As Exception
                    AccountPayableTV.LineNumber = 1
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
