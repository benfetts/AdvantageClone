Namespace Database.Procedures.AccountReceivable

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

        Public Function LoadByInvoiceNumberAndSequenceNumber(ByVal DbContext As Database.DbContext, ByVal InvoiceNumber As Integer, ByVal SequenceNumber As Short) As Database.Entities.AccountReceivable

            Try

                LoadByInvoiceNumberAndSequenceNumber = (From AccountReceivable In DbContext.GetQuery(Of Database.Entities.AccountReceivable)
                                                        Where AccountReceivable.InvoiceNumber = InvoiceNumber AndAlso
                                                              AccountReceivable.SequenceNumber = SequenceNumber
                                                        Select AccountReceivable).SingleOrDefault

            Catch ex As Exception
                LoadByInvoiceNumberAndSequenceNumber = Nothing
            End Try

        End Function
        Public Function LoadAllByInvoiceNumberAndSequenceNumber(ByVal DbContext As Database.DbContext, ByVal InvoiceNumber As Integer, ByVal SequenceNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivable)

            LoadAllByInvoiceNumberAndSequenceNumber = From AccountReceivable In DbContext.GetQuery(Of Database.Entities.AccountReceivable)
                                                      Where AccountReceivable.InvoiceNumber = InvoiceNumber AndAlso
                                                            AccountReceivable.SequenceNumber = SequenceNumber
                                                      Select AccountReceivable

        End Function
        Public Function LoadByInvoiceNumberAndSequenceNumberAndType(ByVal DbContext As Database.DbContext, ByVal InvoiceNumber As Integer, ByVal SequenceNumber As Short, ByVal Type As String) As Database.Entities.AccountReceivable

            Try

                LoadByInvoiceNumberAndSequenceNumberAndType = (From AccountReceivable In DbContext.GetQuery(Of Database.Entities.AccountReceivable)
                                                               Where AccountReceivable.InvoiceNumber = InvoiceNumber AndAlso
                                                                     AccountReceivable.SequenceNumber = SequenceNumber AndAlso
                                                                     AccountReceivable.Type = Type
                                                               Select AccountReceivable).SingleOrDefault

            Catch ex As Exception
                LoadByInvoiceNumberAndSequenceNumberAndType = Nothing
            End Try

        End Function
        Public Function LoadByUserCodeAndBatchName(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivable)

            LoadByUserCodeAndBatchName = From AccountReceivable In DbContext.GetQuery(Of Database.Entities.AccountReceivable)
                                         Where AccountReceivable.UserCode.ToUpper = UserCode.ToUpper AndAlso
                                               AccountReceivable.BatchName = BatchName
                                         Select AccountReceivable

        End Function
        Public Function LoadNonVoidedCoopInvoices(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivable)

            LoadNonVoidedCoopInvoices = From AccountReceivable In DbContext.GetQuery(Of Database.Entities.AccountReceivable)
                                        Where (AccountReceivable.IsVoided Is Nothing OrElse
                                               AccountReceivable.IsVoided = 0) AndAlso
                                               AccountReceivable.SequenceNumber = 99
                                        Select AccountReceivable

        End Function
        Public Function LoadNonVoidedInvoices(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivable)

            LoadNonVoidedInvoices = From AccountReceivable In DbContext.GetQuery(Of Database.Entities.AccountReceivable)
                                    Where (AccountReceivable.IsVoided Is Nothing OrElse
                                           AccountReceivable.IsVoided = 0) AndAlso
                                          AccountReceivable.SequenceNumber <> 99
                                    Select AccountReceivable

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivable)

            Load = From AccountReceivable In DbContext.GetQuery(Of Database.Entities.AccountReceivable)
                   Select AccountReceivable

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountReceivables.Add(AccountReceivable)

                ErrorText = AccountReceivable.ValidateEntity(IsValid)

                If IsValid Then

                    If AccountReceivable.IsManualInvoice = 1 OrElse AccountReceivable.IsImportedInvoice = 1 Then

                        Try

                            AccountReceivable.InvoiceNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountReceivable.Load(DbContext) _
                                                               Where Entity.InvoiceNumber >= 900000
                                                               Select Entity.InvoiceNumber).Max + 1

                        Catch ex As Exception
                            AccountReceivable.InvoiceNumber = 900000
                        End Try

                    End If

                    AccountReceivable.SequenceNumber = 0

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountReceivable)

                ErrorText = AccountReceivable.ValidateEntity(IsValid)

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
