Namespace Database.Procedures.AccountPayableInternet

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableInternet)

            Load = From AccountPayableInternet In DbContext.GetQuery(Of Database.Entities.AccountPayableInternet)
                   Select AccountPayableInternet

        End Function
        Public Function LoadActiveByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableInternet)

            LoadActiveByAccountPayableID = From AccountPayableInternet In DbContext.GetQuery(Of Database.Entities.AccountPayableInternet)
                                           Where AccountPayableInternet.AccountPayableID = AccountPayableID AndAlso
                                                 (AccountPayableInternet.ModifyDelete Is Nothing OrElse
                                                  AccountPayableInternet.ModifyDelete = 0)
                                           Select AccountPayableInternet

        End Function
        Public Function LoadAllByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableInternet)

            LoadAllByAccountPayableID = From AccountPayableInternet In DbContext.GetQuery(Of Database.Entities.AccountPayableInternet)
                                        Where AccountPayableInternet.AccountPayableID = AccountPayableID
                                        Select AccountPayableInternet

        End Function
        Public Function LoadByAccountPayableIDAndTransaction(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal Transaction As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableInternet)

            LoadByAccountPayableIDAndTransaction = From AccountPayableInternet In DbContext.GetQuery(Of Database.Entities.AccountPayableInternet)
                                                   Where AccountPayableInternet.AccountPayableID = AccountPayableID AndAlso
                                                         AccountPayableInternet.GLTransaction = Transaction
                                                   Select AccountPayableInternet

        End Function
        Public Function LoadActiveByOrderNumberAndLineNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer, ByVal OrderLineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableInternet)

            LoadActiveByOrderNumberAndLineNumber = From AccountPayableInternet In DbContext.GetQuery(Of Database.Entities.AccountPayableInternet)
                                                   Where AccountPayableInternet.InternetOrderNumber = OrderNumber AndAlso
                                                         AccountPayableInternet.InternetDetailLineNumber = OrderLineNumber AndAlso
                                                         (AccountPayableInternet.ModifyDelete Is Nothing OrElse
                                                          AccountPayableInternet.ModifyDelete = 0)
                                                   Select AccountPayableInternet

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableInternet As AdvantageFramework.Database.Entities.AccountPayableInternet) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableInternets.Add(AccountPayableInternet)

                ErrorText = AccountPayableInternet.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        AccountPayableInternet.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableInternet.Load(DbContext)
                                                             Where Entity.AccountPayableID = AccountPayableInternet.AccountPayableID AndAlso
                                                                   Entity.AccountPayableSequenceNumber = AccountPayableInternet.AccountPayableSequenceNumber
                                                             Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        AccountPayableInternet.LineNumber = 1
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
        Public Function InsertWithoutValidate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableInternet As AdvantageFramework.Database.Entities.AccountPayableInternet) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DbContext.AccountPayableInternets.Add(AccountPayableInternet)

                Try

                    AccountPayableInternet.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableInternet.Load(DbContext) _
                                                         Where Entity.AccountPayableID = AccountPayableInternet.AccountPayableID AndAlso _
                                                               Entity.AccountPayableSequenceNumber = AccountPayableInternet.AccountPayableSequenceNumber
                                                         Select Entity.LineNumber).Max + 1

                Catch ex As Exception
                    AccountPayableInternet.LineNumber = 1
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
