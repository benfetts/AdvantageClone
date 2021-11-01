Namespace Database.Procedures.AccountPayableOutOfHome

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableOutOfHome)

            Load = From AccountPayableOutOfHome In DbContext.GetQuery(Of Database.Entities.AccountPayableOutOfHome)
                   Select AccountPayableOutOfHome

        End Function
        Public Function LoadActiveByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableOutOfHome)

            LoadActiveByAccountPayableID = From AccountPayableOutOfHome In DbContext.GetQuery(Of Database.Entities.AccountPayableOutOfHome)
                                           Where AccountPayableOutOfHome.AccountPayableID = AccountPayableID AndAlso
                                                 (AccountPayableOutOfHome.ModifyDelete Is Nothing OrElse
                                                  AccountPayableOutOfHome.ModifyDelete = 0)
                                           Select AccountPayableOutOfHome

        End Function
        Public Function LoadAllByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableOutOfHome)

            LoadAllByAccountPayableID = From AccountPayableOutOfHome In DbContext.GetQuery(Of Database.Entities.AccountPayableOutOfHome)
                                        Where AccountPayableOutOfHome.AccountPayableID = AccountPayableID
                                        Select AccountPayableOutOfHome

        End Function
        Public Function LoadByAccountPayableIDAndTransaction(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal Transaction As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableOutOfHome)

            LoadByAccountPayableIDAndTransaction = From AccountPayableOutOfHome In DbContext.GetQuery(Of Database.Entities.AccountPayableOutOfHome)
                                                   Where AccountPayableOutOfHome.AccountPayableID = AccountPayableID AndAlso
                                                         AccountPayableOutOfHome.GLTransaction = Transaction
                                                   Select AccountPayableOutOfHome

        End Function
        Public Function LoadActiveByOrderNumberAndLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal OrderLineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableOutOfHome)

            LoadActiveByOrderNumberAndLineNumber = From AccountPayableOutOfHome In DbContext.GetQuery(Of Database.Entities.AccountPayableOutOfHome)
                                                   Where AccountPayableOutOfHome.OutdoorOrderNumber = OrderNumber AndAlso
                                                         AccountPayableOutOfHome.OutdoorDetailLineNumber = OrderLineNumber AndAlso
                                                         (AccountPayableOutOfHome.ModifyDelete Is Nothing OrElse
                                                          AccountPayableOutOfHome.ModifyDelete = 0)
                                                   Select AccountPayableOutOfHome

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableOutOfHome As AdvantageFramework.Database.Entities.AccountPayableOutOfHome) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableOutOfHomes.Add(AccountPayableOutOfHome)

                ErrorText = AccountPayableOutOfHome.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        AccountPayableOutOfHome.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.Load(DbContext)
                                                              Where Entity.AccountPayableID = AccountPayableOutOfHome.AccountPayableID AndAlso
                                                                    Entity.AccountPayableSequenceNumber = AccountPayableOutOfHome.AccountPayableSequenceNumber
                                                              Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        AccountPayableOutOfHome.LineNumber = 1
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
        Public Function InsertWithoutValidate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableOutOfHome As AdvantageFramework.Database.Entities.AccountPayableOutOfHome) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DbContext.AccountPayableOutOfHomes.Add(AccountPayableOutOfHome)

                Try

                    AccountPayableOutOfHome.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.Load(DbContext) _
                                                          Where Entity.AccountPayableID = AccountPayableOutOfHome.AccountPayableID AndAlso _
                                                                Entity.AccountPayableSequenceNumber = AccountPayableOutOfHome.AccountPayableSequenceNumber
                                                          Select Entity.LineNumber).Max + 1

                Catch ex As Exception
                    AccountPayableOutOfHome.LineNumber = 1
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
