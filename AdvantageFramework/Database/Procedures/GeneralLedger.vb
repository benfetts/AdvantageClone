Namespace Database.Procedures.GeneralLedger

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

        Public Function LoadByPostPeriod(ByVal DbContext As Database.DbContext, PostPeriodCodeFrom As String, PostPeriodCodeTo As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedger)

            LoadByPostPeriod = From GeneralLedger In DbContext.GetQuery(Of Database.Entities.GeneralLedger)
                               Where GeneralLedger.PostPeriodCode >= PostPeriodCodeFrom AndAlso
                                     GeneralLedger.PostPeriodCode <= PostPeriodCodeTo
                               Select GeneralLedger

        End Function
        Public Function LoadNonVoidedByPostPeriod(ByVal DbContext As Database.DbContext, PostPeriodCodeFrom As String, PostPeriodCodeTo As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedger)

            LoadNonVoidedByPostPeriod = From GeneralLedger In DbContext.GetQuery(Of Database.Entities.GeneralLedger)
                                        Where (GeneralLedger.IsVoided Is Nothing OrElse GeneralLedger.IsVoided = 0) AndAlso
                                              GeneralLedger.PostPeriodCode >= PostPeriodCodeFrom AndAlso
                                              GeneralLedger.PostPeriodCode <= PostPeriodCodeTo
                                        Select GeneralLedger

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedger)

            Load = From GeneralLedger In DbContext.GetQuery(Of Database.Entities.GeneralLedger)
                   Select GeneralLedger

        End Function
        Public Function LoadBatchDatesByUser(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Collections.Generic.List(Of Date)

            Dim AfterDate As Date = Nothing

            Try

                AfterDate = DateAdd(DateInterval.Day, -30, CDate(Now.ToShortDateString))

                LoadBatchDatesByUser = (From GeneralLedger In DbContext.GetQuery(Of Database.Entities.GeneralLedger)
                                        Where GeneralLedger.UserCode.ToUpper = UserCode.ToUpper AndAlso
                                              GeneralLedger.GLSourceCode = "AP" AndAlso
                                              GeneralLedger.BatchDate IsNot Nothing AndAlso
                                              GeneralLedger.BatchDate >= AfterDate
                                        Select GeneralLedger.BatchDate.Value).Distinct.OrderByDescending(Function(GeneralLedger) GeneralLedger).ToList

            Catch ex As Exception
                LoadBatchDatesByUser = Nothing
            End Try

        End Function
        Public Function LoadCashReceiptBatchDatesByUser(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Collections.Generic.List(Of Date)

            Dim AfterDate As Date = Nothing

            Try

                AfterDate = DateAdd(DateInterval.Day, -30, CDate(Now.ToShortDateString))

                LoadCashReceiptBatchDatesByUser = (From GeneralLedger In DbContext.GetQuery(Of Database.Entities.GeneralLedger)
                                                   Where GeneralLedger.UserCode.ToUpper = UserCode.ToUpper AndAlso
                                                         GeneralLedger.GLSourceCode = "CR" AndAlso
                                                         GeneralLedger.BatchDate IsNot Nothing AndAlso
                                                         GeneralLedger.BatchDate >= AfterDate
                                                   Select GeneralLedger.BatchDate.Value).Distinct.OrderByDescending(Function(GeneralLedger) GeneralLedger).ToList

            Catch ex As Exception
                LoadCashReceiptBatchDatesByUser = Nothing
            End Try

        End Function
        Public Function LoadClientInvoiceBatchDatesByUser(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Collections.Generic.List(Of Date)

            Dim AfterDate As Date = Nothing

            Try

                AfterDate = DateAdd(DateInterval.Day, -30, CDate(Now.ToShortDateString))

                LoadClientInvoiceBatchDatesByUser = (From GeneralLedger In DbContext.GetQuery(Of Database.Entities.GeneralLedger)
                                                     Where GeneralLedger.UserCode.ToUpper = UserCode.ToUpper AndAlso
                                                           GeneralLedger.GLSourceCode = "MI" AndAlso
                                                           GeneralLedger.BatchDate IsNot Nothing AndAlso
                                                           GeneralLedger.BatchDate >= AfterDate AndAlso
                                                           GeneralLedger.Description.StartsWith("A/R Import") = False
                                                     Select GeneralLedger.BatchDate.Value).Distinct.OrderByDescending(Function(GeneralLedger) GeneralLedger).ToList

            Catch ex As Exception
                LoadClientInvoiceBatchDatesByUser = Nothing
            End Try

        End Function
        Public Function LoadGeneralLedgerImportBatchUsers(DbContext As Database.DbContext, GLSourceCodes As IEnumerable(Of String)) As System.Collections.Generic.List(Of String)

            LoadGeneralLedgerImportBatchUsers = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedger.Load(DbContext)
                                                 Where Entity.BatchDate IsNot Nothing AndAlso
                                                       GLSourceCodes.Contains(Entity.GLSourceCode)
                                                 Select Entity.UserCode.ToUpper).Distinct.ToList

        End Function
        Public Function LoadByTransaction(ByVal DbContext As Database.DbContext, ByVal Transaction As Integer) As AdvantageFramework.Database.Entities.GeneralLedger

            Try

                LoadByTransaction = (From GeneralLedger In DbContext.GetQuery(Of Database.Entities.GeneralLedger)
                                     Where GeneralLedger.Transaction = Transaction
                                     Select GeneralLedger).SingleOrDefault

            Catch ex As Exception
                LoadByTransaction = Nothing
            End Try

        End Function
        Public Function LoadRecurBatchDatesByUser(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Collections.Generic.List(Of Date)

            Dim AfterDate As Date = Nothing

            Try

                AfterDate = DateAdd(DateInterval.Day, -30, CDate(Now.ToShortDateString))

                LoadRecurBatchDatesByUser = (From GeneralLedger In DbContext.GetQuery(Of Database.Entities.GeneralLedger)
                                             Where GeneralLedger.UserCode.ToUpper = UserCode.ToUpper AndAlso
                                                   GeneralLedger.GLSourceCode = "RA" AndAlso
                                                   GeneralLedger.BatchDate IsNot Nothing AndAlso
                                                   GeneralLedger.BatchDate >= AfterDate
                                             Select GeneralLedger.BatchDate.Value).Distinct.OrderByDescending(Function(GeneralLedger) GeneralLedger).ToList

            Catch ex As Exception
                LoadRecurBatchDatesByUser = Nothing
            End Try

        End Function
        Public Function LoadExpenseImportBatchDatesByUser(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Collections.Generic.List(Of Date)

            Dim AfterDate As Date = Nothing

            Try

                AfterDate = DateAdd(DateInterval.Day, -30, CDate(Now.ToShortDateString))

                LoadExpenseImportBatchDatesByUser = (From GeneralLedger In DbContext.GetQuery(Of Database.Entities.GeneralLedger)
                                                     Where GeneralLedger.UserCode.ToUpper = UserCode.ToUpper AndAlso
                                                           GeneralLedger.GLSourceCode = "XR" AndAlso
                                                           GeneralLedger.BatchDate IsNot Nothing AndAlso
                                                           GeneralLedger.BatchDate >= AfterDate
                                                     Select GeneralLedger.BatchDate.Value).Distinct.OrderByDescending(Function(GeneralLedger) GeneralLedger).ToList

            Catch ex As Exception
                LoadExpenseImportBatchDatesByUser = Nothing
            End Try

        End Function
        Public Function LoadOtherReceiptBatchDatesByUser(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Collections.Generic.List(Of Date)

            Dim AfterDate As Date = Nothing

            Try

                AfterDate = DateAdd(DateInterval.Day, -30, CDate(Now.ToShortDateString))

                LoadOtherReceiptBatchDatesByUser = (From GeneralLedger In DbContext.GetQuery(Of Database.Entities.GeneralLedger)
                                                    Where GeneralLedger.UserCode.ToUpper = UserCode.ToUpper AndAlso
                                                          GeneralLedger.GLSourceCode = "OR" AndAlso
                                                          GeneralLedger.BatchDate IsNot Nothing AndAlso
                                                          GeneralLedger.BatchDate >= AfterDate
                                                    Select GeneralLedger.BatchDate.Value).Distinct.OrderByDescending(Function(GeneralLedger) GeneralLedger).ToList

            Catch ex As Exception
                LoadOtherReceiptBatchDatesByUser = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GeneralLedgers.Add(GeneralLedger)

                ErrorText = GeneralLedger.ValidateEntity(IsValid)

                If IsValid Then

                    GeneralLedger.Transaction = AdvantageFramework.Database.Procedures.ID.GetNextTransaction(DbContext, "GLENTHDR")

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

#End Region

    End Module

End Namespace
