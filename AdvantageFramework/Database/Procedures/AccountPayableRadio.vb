Namespace Database.Procedures.AccountPayableRadio

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRadio)

            Load = From AccountPayableRadio In DbContext.GetQuery(Of Database.Entities.AccountPayableRadio)
                   Select AccountPayableRadio

        End Function
        Public Function LoadActiveByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRadio)

            LoadActiveByAccountPayableID = From AccountPayableRadio In DbContext.GetQuery(Of Database.Entities.AccountPayableRadio)
                                           Where AccountPayableRadio.AccountPayableID = AccountPayableID AndAlso
                                                 (AccountPayableRadio.ModifyDelete Is Nothing OrElse
                                                  AccountPayableRadio.ModifyDelete = 0)
                                           Select AccountPayableRadio

        End Function
        Public Function LoadAllByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRadio)

            LoadAllByAccountPayableID = From AccountPayableRadio In DbContext.GetQuery(Of Database.Entities.AccountPayableRadio)
                                        Where AccountPayableRadio.AccountPayableID = AccountPayableID
                                        Select AccountPayableRadio

        End Function
        Public Function LoadByAccountPayableIDAndTransaction(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal Transaction As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRadio)

            LoadByAccountPayableIDAndTransaction = From AccountPayableRadio In DbContext.GetQuery(Of Database.Entities.AccountPayableRadio)
                                                   Where AccountPayableRadio.AccountPayableID = AccountPayableID AndAlso
                                                         AccountPayableRadio.GLTransaction = Transaction
                                                   Select AccountPayableRadio

        End Function
        Public Function LoadActiveByOrderNumberAndLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal OrderLineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRadio)

            LoadActiveByOrderNumberAndLineNumber = From AccountPayableRadio In DbContext.GetQuery(Of Database.Entities.AccountPayableRadio)
                                                   Where AccountPayableRadio.OrderNumber = OrderNumber AndAlso
                                                         AccountPayableRadio.OrderLineNumber = OrderLineNumber AndAlso
                                                         (AccountPayableRadio.ModifyDelete Is Nothing OrElse
                                                          AccountPayableRadio.ModifyDelete = 0)
                                                   Select AccountPayableRadio

        End Function
        Public Function LoadActiveByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRadio)

            LoadActiveByOrderNumber = From AccountPayableRadio In DbContext.GetQuery(Of Database.Entities.AccountPayableRadio)
                                      Where AccountPayableRadio.OrderNumber = OrderNumber AndAlso
                                            (AccountPayableRadio.ModifyDelete Is Nothing OrElse
                                            AccountPayableRadio.ModifyDelete = 0)
                                      Select AccountPayableRadio

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableRadio As AdvantageFramework.Database.Entities.AccountPayableRadio) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableRadios.Add(AccountPayableRadio)

                ErrorText = AccountPayableRadio.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        AccountPayableRadio.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRadio.Load(DbContext)
                                                          Where Entity.AccountPayableID = AccountPayableRadio.AccountPayableID AndAlso
                                                                Entity.AccountPayableSequenceNumber = AccountPayableRadio.AccountPayableSequenceNumber
                                                          Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        AccountPayableRadio.LineNumber = 1
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
        Public Function InsertWithoutValidate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableRadio As AdvantageFramework.Database.Entities.AccountPayableRadio) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DbContext.AccountPayableRadios.Add(AccountPayableRadio)

                Try

                    AccountPayableRadio.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRadio.Load(DbContext) _
                                                      Where Entity.AccountPayableID = AccountPayableRadio.AccountPayableID AndAlso _
                                                            Entity.AccountPayableSequenceNumber = AccountPayableRadio.AccountPayableSequenceNumber
                                                      Select Entity.LineNumber).Max + 1

                Catch ex As Exception
                    AccountPayableRadio.LineNumber = 1
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
