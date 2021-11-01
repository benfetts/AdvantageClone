Namespace CashReceipts

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum CheckState
            Add
            Modify
            Delete
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Client Cash Receipts "

        Public Function GetAllCashReceiptListByClient(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceipt)

            Dim ClientCashReceiptList As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceipt) = Nothing

            ClientCashReceiptList = New Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceipt)

            ClientCashReceiptList.AddRange(From ClientCashReceipt In AdvantageFramework.Database.Procedures.ClientCashReceipt.LoadByClient(DbContext, ClientCode)
                                           Where ClientCashReceipt.Status Is Nothing OrElse
                                                 ClientCashReceipt.Status <> "D"
                                           Select ClientCashReceipt)

            GetAllCashReceiptListByClient = ClientCashReceiptList

        End Function
        Private Function GetBankDescription(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BankCode As String) As String

            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing

            Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, BankCode)

            If Bank Is Nothing Then

                Throw New Exception("Failed to load bank.")

            End If

            GetBankDescription = Bank.Description

        End Function
        Private Sub SetGeneralLedgerDescriptionRemarkForClientCashReceipt(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                          ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt,
                                                                          ByVal CheckState As CheckState,
                                                                          ByRef GLDescription As String,
                                                                          ByRef Remark As String)

            Dim BankDescription As String = Nothing

            BankDescription = GetBankDescription(DbContext, ClientCashReceipt.BankCode)

            Select Case CheckState

                Case CheckState.Add

                    GLDescription = "Client: " & ClientCashReceipt.ClientCode & ", Check: " & ClientCashReceipt.CheckNumber & ", Bank: " & BankDescription

                    Remark = "Client: " & ClientCashReceipt.ClientCode & ", Check: " & ClientCashReceipt.CheckNumber & ", Bank: " & BankDescription

                Case CheckState.Modify

                    GLDescription = "Client: " & ClientCashReceipt.ClientCode & ", Modify Check: " & ClientCashReceipt.CheckNumber & ", Bank: " & BankDescription

                    Remark = "Client: " & ClientCashReceipt.ClientCode & ", Modify Check: " & ClientCashReceipt.CheckNumber & ", Bank: " & BankDescription

                Case CheckState.Delete

                    GLDescription = "Client: " & ClientCashReceipt.ClientCode & ", Reverse Check: " & ClientCashReceipt.CheckNumber & ", Bank: " & BankDescription

                    Remark = "Client: " & ClientCashReceipt.ClientCode & ", Reverse Check: " & ClientCashReceipt.CheckNumber & ", Bank: " & BankDescription

            End Select

        End Sub
        Public Sub InsertClientCashReceipt(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt,
                                           ByVal ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount,
                                           ByVal GLSourceCode As String,
                                           ByVal BatchDate As Nullable(Of Date),
                                           ByRef GLTransaction As Nullable(Of Integer),
                                           ByVal CheckStateAddModify As AdvantageFramework.CashReceipts.CheckState)

            'objects
            Dim IsInterCompanyTransactionsEnabled As Boolean = False
            Dim GLDescription As String = Nothing
            Dim Remark As String = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim IsNewCheck As Boolean = False

            SetGeneralLedgerDescriptionRemarkForClientCashReceipt(DbContext, ClientCashReceipt, CheckStateAddModify, GLDescription, Remark)

            IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

            If GLTransaction Is Nothing Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, ClientCashReceipt.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                    Throw New Exception("Failed trying to save data to General Ledger.")

                End If

                GLTransaction = GeneralLedger.Transaction

                IsNewCheck = True

            End If

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, ClientCashReceipt.GLACode, ClientCashReceipt.CheckAmount, Remark, GLSourceCode) = False Then

                Throw New Exception("Failed trying to save data to General Ledger Detail.")

            End If

            ClientCashReceipt.GLTransaction = GLTransaction
            ClientCashReceipt.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

            If AdvantageFramework.Database.Procedures.ClientCashReceipt.Insert(DbContext, ClientCashReceipt) = False Then

                Throw New Exception("Insert to client cash receipt table failed.")

            End If

            If ClientCashReceiptOnAccount IsNot Nothing Then

                AdvantageFramework.CashReceipts.InsertClientCashReceiptOnAccount(DbContext, ClientCashReceipt, GLTransaction, GLSourceCode, IsInterCompanyTransactionsEnabled, ClientCashReceiptOnAccount, IsNewCheck, BatchDate)

            End If

        End Sub
        Public Sub InsertClientCashReceipt(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt,
                                           ByVal ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount,
                                           ByVal ClientInvoiceDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail),
                                           ByVal GLSourceCode As String,
                                           ByVal BatchDate As Date,
                                           ByRef GLTransaction As Nullable(Of Integer),
                                           ByVal CheckStateAddModify As AdvantageFramework.CashReceipts.CheckState)

            InsertClientCashReceipt(DbContext, ClientCashReceipt, ClientCashReceiptOnAccount, GLSourceCode, BatchDate, GLTransaction, CheckStateAddModify)

            AdvantageFramework.CashReceipts.InsertClientCashReceiptDetail(DbContext, ClientCashReceipt, ClientInvoiceDetailList, GLSourceCode, GLTransaction)

        End Sub
        Private Sub InsertClientCashReceiptDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt,
                                                  ByVal ImportClientCashReceiptDetail As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail,
                                                  ByVal AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable,
                                                  ByVal GLTransaction As Integer,
                                                  ByVal GLSourceCode As String,
                                                  ByVal IsInterCompanyTransactionsEnabled As Boolean,
                                                  ByVal BankDescription As String)

            Dim ClientCashReceiptDetail As AdvantageFramework.Database.Entities.ClientCashReceiptDetail = Nothing
            Dim Remark As String = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing

            ClientCashReceiptDetail = New AdvantageFramework.Database.Entities.ClientCashReceiptDetail
            ClientCashReceiptDetail.DbContext = DbContext
            ClientCashReceiptDetail.ClientCashReceiptID = ClientCashReceipt.ID
            ClientCashReceiptDetail.ClientCashReceiptSequenceNumber = ClientCashReceipt.SequenceNumber

            ClientCashReceiptDetail.DivisionCode = AccountReceivable.DivisionCode
            ClientCashReceiptDetail.ProductCode = AccountReceivable.ProductCode
            ClientCashReceiptDetail.ARInvoiceNumber = AccountReceivable.InvoiceNumber
            ClientCashReceiptDetail.ARInvoiceSequenceNumber = AccountReceivable.SequenceNumber
            ClientCashReceiptDetail.ARType = AccountReceivable.Type

            ClientCashReceiptDetail.PaymentAmount = ImportClientCashReceiptDetail.PaymentAmount
            ClientCashReceiptDetail.AdjustmentAmount = Nothing

            ClientCashReceiptDetail.GLACodeAR = AccountReceivable.GLACodeAR
            ClientCashReceiptDetail.GLACodeAdjustment = Nothing
            ClientCashReceiptDetail.GLTransaction = GLTransaction
            ClientCashReceiptDetail.PostPeriodCode = ClientCashReceipt.PostPeriodCode

            Remark = "Client: " & ClientCashReceipt.ClientCode & ", Check: " & ClientCashReceipt.CheckNumber & ", Invoice: " & ClientCashReceiptDetail.ARInvoiceNumber.ToString.PadLeft(6, "0") & "-" & ClientCashReceiptDetail.ARInvoiceSequenceNumber.ToString.PadLeft(3, "0") & ", Bank: " & BankDescription

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, ClientCashReceiptDetail.GLACodeAR,
                    -(ClientCashReceiptDetail.PaymentAmount.GetValueOrDefault(0) + ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0)), Remark, GLSourceCode,
                    ClientCashReceipt.ClientCode, ClientCashReceiptDetail.DivisionCode, ClientCashReceiptDetail.ProductCode) = False Then

                Throw New Exception("Failed to insert into general ledger detail table.")

            Else

                ClientCashReceiptDetail.GLSequenceNumberAR = GeneralLedgerDetail.SequenceNumber

            End If

            If IsInterCompanyTransactionsEnabled Then

                AdvantageFramework.GeneralLedger.CreateIntercompanyTransactions(DbContext, ClientCashReceipt.GLACode, AccountReceivable.GLACodeAR, GLTransaction,
                                                                                ClientCashReceiptDetail.PaymentAmount.GetValueOrDefault(0) + ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0), Remark & " (IC)", GLSourceCode,
                                                                                ClientCashReceipt.ClientCode, ClientCashReceiptDetail.DivisionCode, ClientCashReceiptDetail.ProductCode,
                                                                                ClientCashReceiptDetail.GLACodeDueFrom, ClientCashReceiptDetail.GLACodeDueTo,
                                                                                ClientCashReceiptDetail.GLSequenceNumberDueFrom, ClientCashReceiptDetail.GLSequenceNumberDueTo)

            End If

            If AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.Insert(DbContext, ClientCashReceiptDetail) = False Then

                Throw New Exception("Failed to insert into client cash receipt detail table.")

            End If

        End Sub
        Private Sub InsertClientCashReceiptDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt,
                                                  ByVal ClientInvoiceDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail),
                                                  ByVal GLSourceCode As String,
                                                  ByVal GLTransaction As Integer)

            Dim ClientCashReceiptDetail As AdvantageFramework.Database.Entities.ClientCashReceiptDetail = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim Remark As String = Nothing
            Dim IsInterCompanyTransactionsEnabled As Boolean = False
            Dim BankDescription As String = Nothing

            BankDescription = GetBankDescription(DbContext, ClientCashReceipt.BankCode)

            IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

            For Each ClientInvoiceDetail In ClientInvoiceDetailList

                If ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0) <> 0 OrElse ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0) <> 0 Then

                    ClientCashReceiptDetail = New AdvantageFramework.Database.Entities.ClientCashReceiptDetail
                    ClientCashReceiptDetail.DbContext = DbContext
                    ClientCashReceiptDetail.ClientCashReceiptID = ClientCashReceipt.ID
                    ClientCashReceiptDetail.ClientCashReceiptSequenceNumber = ClientCashReceipt.SequenceNumber

                    ClientCashReceiptDetail.DivisionCode = ClientInvoiceDetail.DivisionCode
                    ClientCashReceiptDetail.ProductCode = ClientInvoiceDetail.ProductCode
                    ClientCashReceiptDetail.ARInvoiceNumber = ClientInvoiceDetail.ARInvoiceNumber
                    ClientCashReceiptDetail.ARInvoiceSequenceNumber = ClientInvoiceDetail.ARInvoiceSequenceNumber
                    ClientCashReceiptDetail.ARType = ClientInvoiceDetail.ARType

                    ClientCashReceiptDetail.PaymentAmount = ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0)
                    ClientCashReceiptDetail.AdjustmentAmount = ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0)

                    ClientCashReceiptDetail.GLACodeAR = ClientInvoiceDetail.GLACodeAR
                    ClientCashReceiptDetail.GLACodeAdjustment = ClientInvoiceDetail.GLACodeAdjustment
                    ClientCashReceiptDetail.GLTransaction = GLTransaction
                    ClientCashReceiptDetail.PostPeriodCode = ClientCashReceipt.PostPeriodCode

                    Remark = "Client: " & ClientCashReceipt.ClientCode & ", Check: " & ClientCashReceipt.CheckNumber & ", Invoice: " & ClientCashReceiptDetail.ARInvoiceNumber.ToString.PadLeft(6, "0") & "-" & ClientCashReceiptDetail.ARInvoiceSequenceNumber.ToString.PadLeft(3, "0") & ", Bank: " & BankDescription

                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, ClientInvoiceDetail.GLACodeAR,
                            -(ClientCashReceiptDetail.PaymentAmount.GetValueOrDefault(0) + ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0)), Remark, GLSourceCode,
                            ClientCashReceipt.ClientCode, ClientInvoiceDetail.DivisionCode, ClientInvoiceDetail.ProductCode) = False Then

                        Throw New Exception("Failed to insert into general ledger detail table.")

                    Else

                        ClientCashReceiptDetail.GLSequenceNumberAR = GeneralLedgerDetail.SequenceNumber

                    End If

                    If IsInterCompanyTransactionsEnabled Then

                        AdvantageFramework.GeneralLedger.CreateIntercompanyTransactions(DbContext, ClientCashReceipt.GLACode, ClientInvoiceDetail.GLACodeAR, GLTransaction,
                                                                                        ClientCashReceiptDetail.PaymentAmount.GetValueOrDefault(0) + ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0), Remark & " (IC)", GLSourceCode,
                                                                                        ClientCashReceipt.ClientCode, ClientInvoiceDetail.DivisionCode, ClientInvoiceDetail.ProductCode,
                                                                                        ClientCashReceiptDetail.GLACodeDueFrom, ClientCashReceiptDetail.GLACodeDueTo,
                                                                                        ClientCashReceiptDetail.GLSequenceNumberDueFrom, ClientCashReceiptDetail.GLSequenceNumberDueTo)

                    End If

                    If ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0) <> 0 Then

                        If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, ClientInvoiceDetail.GLACodeAdjustment,
                                    ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0), Remark, GLSourceCode,
                                    ClientCashReceipt.ClientCode, ClientInvoiceDetail.DivisionCode, ClientInvoiceDetail.ProductCode) = False Then

                            Throw New Exception("Failed to insert into general ledger detail table.")

                        Else

                            ClientCashReceiptDetail.GLSequenceNumberAdjustment = GeneralLedgerDetail.SequenceNumber

                            If IsInterCompanyTransactionsEnabled Then

                                AdvantageFramework.GeneralLedger.CreateIntercompanyTransactions(DbContext, ClientCashReceipt.GLACode,
                                                                                                ClientInvoiceDetail.GLACodeAdjustment, GLTransaction,
                                                                                                -ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0), Remark & " (IC)", GLSourceCode,
                                                                                                ClientCashReceipt.ClientCode, ClientInvoiceDetail.DivisionCode, ClientInvoiceDetail.ProductCode,
                                                                                                ClientCashReceiptDetail.GLACodeDueFromAdjustment, ClientCashReceiptDetail.GLACodeDueToAdjustment,
                                                                                                ClientCashReceiptDetail.GLSequenceNumberDueFromAdjustment, ClientCashReceiptDetail.GLSequenceNumberDueToAdjustment)

                            End If

                        End If

                    End If

                    If AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.Insert(DbContext, ClientCashReceiptDetail) = False Then

                        Throw New Exception("Failed to insert into client cash receipt detail table.")

                    End If

                    If ClientInvoiceDetail.CurrentBalance <> 0 OrElse (ClientInvoiceDetail.CurrentBalance = 0 AndAlso ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0) <> 0) Then

                        InsertClientCashReceiptDetailPayments(DbContext, ClientInvoiceDetail, ClientCashReceiptDetail)

                    End If

                End If

                SaveCollectionNote(DbContext, ClientInvoiceDetail)

            Next

        End Sub
        Private Sub InsertClientCashReceiptDetailPayments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail,
                                                          ByVal ClientCashReceiptDetail As AdvantageFramework.Database.Entities.ClientCashReceiptDetail)

            Dim ClientCashReceiptDetailPayment As AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment = Nothing

            If ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0) <> 0 AndAlso ClientInvoiceDetail.GetClientCashReceiptPaymentDetailList IsNot Nothing AndAlso
                    ClientInvoiceDetail.GetClientCashReceiptPaymentDetailList.Sum(Function(D) D.PaymentAmount.GetValueOrDefault(0)) = ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0) Then

                For Each ClientCashReceiptPaymentDetail In ClientInvoiceDetail.GetClientCashReceiptPaymentDetailList

                    If ClientCashReceiptPaymentDetail.PaymentAmount IsNot Nothing Then

                        ClientCashReceiptDetailPayment = New AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment

                        ClientCashReceiptDetailPayment.DbContext = DbContext
                        ClientCashReceiptDetailPayment.ClientCashReceiptID = ClientCashReceiptDetail.ClientCashReceiptID
                        ClientCashReceiptDetailPayment.ClientCashReceiptSequenceNumber = ClientCashReceiptDetail.ClientCashReceiptSequenceNumber
                        ClientCashReceiptDetailPayment.ClientCashReceiptDetailItemID = ClientCashReceiptDetail.ItemID

                        ClientCashReceiptDetailPayment.JobNumber = ClientCashReceiptPaymentDetail.JobNumber
                        ClientCashReceiptDetailPayment.JobComponentNumber = ClientCashReceiptPaymentDetail.JobComponentNumber
                        ClientCashReceiptDetailPayment.FunctionCode = ClientCashReceiptPaymentDetail.FunctionCode
                        ClientCashReceiptDetailPayment.OrderNumber = ClientCashReceiptPaymentDetail.OrderNumber
                        ClientCashReceiptDetailPayment.OrderLineNumber = ClientCashReceiptPaymentDetail.OrderLineNumber

                        ClientCashReceiptDetailPayment.PaymentAmount = ClientCashReceiptPaymentDetail.PaymentAmount

                        If AdvantageFramework.Database.Procedures.ClientCashReceiptDetailPayment.Insert(DbContext, ClientCashReceiptDetailPayment) = False Then

                            Throw New Exception("Failed to insert into client cash receipt detail payment table.")

                        End If

                    End If

                Next

            End If

        End Sub
        Public Sub UpdateClientCashReceiptDetailPayments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)

            Dim ClientCashReceiptDetailPayment As AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment = Nothing

            If ClientInvoiceDetail.GetClientCashReceiptPaymentDetailList IsNot Nothing Then

                For Each ClientCashReceiptPaymentDetail In ClientInvoiceDetail.GetClientCashReceiptPaymentDetailList

                    If ClientInvoiceDetail.ClientCashReceiptID IsNot Nothing AndAlso ClientInvoiceDetail.ClientCashReceiptSequenceNumber IsNot Nothing AndAlso ClientInvoiceDetail.ClientCashReceiptDetailItemID IsNot Nothing Then

                        If ClientCashReceiptPaymentDetail.JobNumber IsNot Nothing Then

                            ClientCashReceiptDetailPayment = (From CCRDP In AdvantageFramework.Database.Procedures.ClientCashReceiptDetailPayment.LoadByClientCashReceiptDetailIDandSeqandItemID(DbContext, ClientInvoiceDetail.ClientCashReceiptID, ClientInvoiceDetail.ClientCashReceiptSequenceNumber, ClientInvoiceDetail.ClientCashReceiptDetailItemID)
                                                              Where CCRDP.JobNumber = ClientCashReceiptPaymentDetail.JobNumber AndAlso
                                                                CCRDP.JobComponentNumber = ClientCashReceiptPaymentDetail.JobComponentNumber AndAlso
                                                                CCRDP.FunctionCode = ClientCashReceiptPaymentDetail.FunctionCode).SingleOrDefault

                        ElseIf ClientCashReceiptPaymentDetail.OrderNumber IsNot Nothing Then

                            ClientCashReceiptDetailPayment = (From CCRDP In AdvantageFramework.Database.Procedures.ClientCashReceiptDetailPayment.LoadByClientCashReceiptDetailIDandSeqandItemID(DbContext, ClientInvoiceDetail.ClientCashReceiptID, ClientInvoiceDetail.ClientCashReceiptSequenceNumber, ClientInvoiceDetail.ClientCashReceiptDetailItemID)
                                                              Where CCRDP.OrderNumber = ClientCashReceiptPaymentDetail.OrderNumber AndAlso
                                                                CCRDP.OrderLineNumber = ClientCashReceiptPaymentDetail.OrderLineNumber).SingleOrDefault

                        End If

                    End If

                    If ClientCashReceiptDetailPayment Is Nothing AndAlso ClientCashReceiptPaymentDetail.PaymentAmount IsNot Nothing Then

                        ClientCashReceiptDetailPayment = New AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment
                        ClientCashReceiptDetailPayment.DbContext = DbContext

                        ClientCashReceiptDetailPayment.ClientCashReceiptID = ClientInvoiceDetail.ClientCashReceiptID
                        ClientCashReceiptDetailPayment.ClientCashReceiptSequenceNumber = ClientInvoiceDetail.ClientCashReceiptSequenceNumber
                        ClientCashReceiptDetailPayment.ClientCashReceiptDetailItemID = ClientInvoiceDetail.ClientCashReceiptDetailItemID
                        ClientCashReceiptDetailPayment.JobNumber = ClientCashReceiptPaymentDetail.JobNumber
                        ClientCashReceiptDetailPayment.JobComponentNumber = ClientCashReceiptPaymentDetail.JobComponentNumber
                        ClientCashReceiptDetailPayment.FunctionCode = ClientCashReceiptPaymentDetail.FunctionCode
                        ClientCashReceiptDetailPayment.OrderNumber = ClientCashReceiptPaymentDetail.OrderNumber
                        ClientCashReceiptDetailPayment.OrderLineNumber = ClientCashReceiptPaymentDetail.OrderLineNumber
                        ClientCashReceiptDetailPayment.PaymentAmount = ClientCashReceiptPaymentDetail.PaymentAmount

                        If AdvantageFramework.Database.Procedures.ClientCashReceiptDetailPayment.Insert(DbContext, ClientCashReceiptDetailPayment) = False Then

                            Throw New Exception("Failed to insert into client cash receipt detail payment table.")

                        End If

                    ElseIf ClientCashReceiptDetailPayment IsNot Nothing Then

                        If ClientCashReceiptPaymentDetail.PaymentAmount IsNot Nothing Then

                            ClientCashReceiptDetailPayment.PaymentAmount = ClientCashReceiptPaymentDetail.PaymentAmount

                            If AdvantageFramework.Database.Procedures.ClientCashReceiptDetailPayment.Update(DbContext, ClientCashReceiptDetailPayment) = False Then

                                Throw New Exception("Failed to update client cash receipt detail payment table.")

                            End If

                        Else

                            If AdvantageFramework.Database.Procedures.ClientCashReceiptDetailPayment.Delete(DbContext, ClientCashReceiptDetailPayment) = False Then

                                Throw New Exception("Failed to delete client cash receipt detail payment table.")

                            End If

                        End If

                    End If

                Next

            End If

        End Sub
        Public Sub UpdateClientCashReceiptDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt,
                                                 ByVal ClientInvoiceDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail),
                                                 ByVal GLSourceCode As String,
                                                 ByVal IsInterCompanyTransactionsEnabled As Boolean,
                                                 ByVal PostPeriodCode As String,
                                                 ByVal BatchDate As Date,
                                                 ByRef GLTransaction As Nullable(Of Integer))

            Dim ClientCashReceiptDetail As AdvantageFramework.Database.Entities.ClientCashReceiptDetail = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim GLDescription As String = Nothing
            Dim Remark As String = Nothing
            Dim BankDescription As String = Nothing

            BankDescription = GetBankDescription(DbContext, ClientCashReceipt.BankCode)

            SetGeneralLedgerDescriptionRemarkForClientCashReceipt(DbContext, ClientCashReceipt, CheckState.Modify, GLDescription, Remark)

            For Each ClientInvoiceDetail In ClientInvoiceDetailList

                If ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0) <> ClientInvoiceDetail.PaymentAmountCopy.GetValueOrDefault(0) OrElse
                        ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0) <> ClientInvoiceDetail.AdjustmentAmountCopy.GetValueOrDefault(0) OrElse
                        ClientInvoiceDetail.GLACodeAdjustment <> ClientInvoiceDetail.GLACodeAdjustmentCopy Then

                    If GLTransaction Is Nothing Then

                        If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                            Throw New Exception("Failed trying to save data to General Ledger.")

                        End If

                        GLTransaction = GeneralLedger.Transaction

                    End If

                    Remark = "Client: " & ClientCashReceipt.ClientCode & ", Modify Check: " & ClientCashReceipt.CheckNumber & ", Invoice: " & ClientInvoiceDetail.ARInvoiceNumber.ToString.PadLeft(6, "0") & "-" & ClientInvoiceDetail.ARInvoiceSequenceNumber.ToString.PadLeft(3, "0") & ", Bank: " & BankDescription

                    If ClientInvoiceDetail.ClientCashReceiptID IsNot Nothing Then

                        ClientCashReceiptDetail = (From CCRD In AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.LoadByClientCashReceiptIDAndSequenceNumber(DbContext, ClientInvoiceDetail.ClientCashReceiptID, ClientInvoiceDetail.ClientCashReceiptSequenceNumber)
                                                   Where CCRD.ItemID = ClientInvoiceDetail.ClientCashReceiptDetailItemID
                                                   Select CCRD).SingleOrDefault

                        If ClientCashReceiptDetail IsNot Nothing Then

                            ReverseClientCashReceiptDetail(DbContext, ClientCashReceiptDetail, ClientCashReceipt, GLSourceCode, ClientCashReceipt.SequenceNumber, PostPeriodCode, GLTransaction, False)

                        Else

                            Throw New Exception("Cannot find cash receipt detail to reverse.")

                        End If

                    End If

                    If ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0) <> 0 OrElse ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0) <> 0 Then

                        ClientCashReceiptDetail = New AdvantageFramework.Database.Entities.ClientCashReceiptDetail
                        ClientCashReceiptDetail.DbContext = DbContext
                        ClientCashReceiptDetail.ClientCashReceiptID = ClientCashReceipt.ID
                        ClientCashReceiptDetail.ClientCashReceiptSequenceNumber = ClientCashReceipt.SequenceNumber

                        ClientCashReceiptDetail.DivisionCode = ClientInvoiceDetail.DivisionCode
                        ClientCashReceiptDetail.ProductCode = ClientInvoiceDetail.ProductCode
                        ClientCashReceiptDetail.ARInvoiceNumber = ClientInvoiceDetail.ARInvoiceNumber
                        ClientCashReceiptDetail.ARInvoiceSequenceNumber = ClientInvoiceDetail.ARInvoiceSequenceNumber
                        ClientCashReceiptDetail.ARType = ClientInvoiceDetail.ARType

                        ClientCashReceiptDetail.PaymentAmount = ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0)
                        ClientCashReceiptDetail.AdjustmentAmount = ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0)

                        ClientCashReceiptDetail.GLACodeAR = ClientInvoiceDetail.GLACodeAR
                        ClientCashReceiptDetail.GLACodeAdjustment = ClientInvoiceDetail.GLACodeAdjustment
                        ClientCashReceiptDetail.GLTransaction = GLTransaction
                        ClientCashReceiptDetail.PostPeriodCode = PostPeriodCode

                        If ClientCashReceiptDetail.PaymentAmount.GetValueOrDefault(0) + ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0) <> 0 Then

                            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, ClientInvoiceDetail.GLACodeAR,
                                    -(ClientCashReceiptDetail.PaymentAmount.GetValueOrDefault(0) + ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0)), Remark, GLSourceCode,
                                    ClientCashReceipt.ClientCode, ClientInvoiceDetail.DivisionCode, ClientInvoiceDetail.ProductCode) = False Then

                                Throw New Exception("Failed to insert into general ledger detail table.")

                            Else

                                ClientCashReceiptDetail.GLSequenceNumberAR = GeneralLedgerDetail.SequenceNumber

                            End If

                            If IsInterCompanyTransactionsEnabled Then

                                AdvantageFramework.GeneralLedger.CreateIntercompanyTransactions(DbContext, ClientCashReceipt.GLACode, ClientInvoiceDetail.GLACodeAR, GLTransaction,
                                                                                                ClientCashReceiptDetail.PaymentAmount.GetValueOrDefault(0) + ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0), Remark & " (IC)", GLSourceCode,
                                                                                                ClientCashReceipt.ClientCode, ClientInvoiceDetail.DivisionCode, ClientInvoiceDetail.ProductCode,
                                                                                                ClientCashReceiptDetail.GLACodeDueFrom, ClientCashReceiptDetail.GLACodeDueTo,
                                                                                                ClientCashReceiptDetail.GLSequenceNumberDueFrom, ClientCashReceiptDetail.GLSequenceNumberDueTo)

                            End If

                        End If

                        If ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0) <> 0 Then

                            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, ClientInvoiceDetail.GLACodeAdjustment,
                                        ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0), Remark, GLSourceCode,
                                        ClientCashReceipt.ClientCode, ClientInvoiceDetail.DivisionCode, ClientInvoiceDetail.ProductCode) = False Then

                                Throw New Exception("Failed to insert into general ledger detail table.")

                            Else

                                ClientCashReceiptDetail.GLSequenceNumberAdjustment = GeneralLedgerDetail.SequenceNumber

                                If IsInterCompanyTransactionsEnabled Then

                                    AdvantageFramework.GeneralLedger.CreateIntercompanyTransactions(DbContext, ClientCashReceipt.GLACode,
                                                                                                    ClientInvoiceDetail.GLACodeAdjustment, GLTransaction,
                                                                                                    -ClientCashReceiptDetail.AdjustmentAmount.GetValueOrDefault(0), Remark & " (IC)", GLSourceCode,
                                                                                                    ClientCashReceipt.ClientCode, ClientInvoiceDetail.DivisionCode, ClientInvoiceDetail.ProductCode,
                                                                                                    ClientCashReceiptDetail.GLACodeDueFromAdjustment, ClientCashReceiptDetail.GLACodeDueToAdjustment,
                                                                                                    ClientCashReceiptDetail.GLSequenceNumberDueFromAdjustment, ClientCashReceiptDetail.GLSequenceNumberDueToAdjustment)

                                End If

                            End If

                        End If

                        If AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.Insert(DbContext, ClientCashReceiptDetail) = False Then

                            Throw New Exception("Failed to insert into client cash receipt detail table.")

                        End If

                        If ClientInvoiceDetail.CurrentBalance <> 0 OrElse (ClientInvoiceDetail.CurrentBalance = 0 AndAlso ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0) <> 0) Then

                            InsertClientCashReceiptDetailPayments(DbContext, ClientInvoiceDetail, ClientCashReceiptDetail)

                        End If

                    End If

                Else

                    UpdateClientCashReceiptDetailPayments(DbContext, ClientInvoiceDetail)

                End If

                SaveCollectionNote(DbContext, ClientInvoiceDetail)

            Next

        End Sub
        Public Sub InsertClientCashReceiptOnAccount(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt,
                                                    ByRef GLTransaction As Nullable(Of Integer),
                                                    ByVal GLSourceCode As String,
                                                    ByVal IsInterCompanyTransactionsEnabled As Boolean,
                                                    ByRef ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount,
                                                    ByVal IsNewCheck As Boolean,
                                                    ByVal BatchDate As Nullable(Of Date))

            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim GLDescription As String = Nothing
            Dim Remark As String = Nothing
            Dim BankDescription As String = Nothing

            BankDescription = GetBankDescription(DbContext, ClientCashReceipt.BankCode)

            SetGeneralLedgerDescriptionRemarkForClientCashReceipt(DbContext, ClientCashReceipt, If(IsNewCheck, CheckState.Add, CheckState.Modify), GLDescription, Remark)

            If GLTransaction Is Nothing Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, ClientCashReceipt.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                    Throw New Exception("Problem inserting General Ledger.")

                End If

                GLTransaction = GeneralLedger.Transaction

            End If

            ClientCashReceiptOnAccount.DbContext = DbContext
            ClientCashReceiptOnAccount.ClientCashReceiptID = ClientCashReceipt.ID
            ClientCashReceiptOnAccount.ClientCashReceiptSequenceNumber = ClientCashReceipt.SequenceNumber

            ClientCashReceiptOnAccount.GLTransaction = GLTransaction
            ClientCashReceiptOnAccount.PostPeriodCode = ClientCashReceipt.PostPeriodCode

            If IsNewCheck Then

                Remark = "Client: " & ClientCashReceipt.ClientCode & ", Check: " & ClientCashReceipt.CheckNumber & ", On Account, Bank: " & BankDescription

            Else

                Remark = "Client: " & ClientCashReceipt.ClientCode & ", Modify Check: " & ClientCashReceipt.CheckNumber & ", On Account, Bank: " & BankDescription

            End If

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, ClientCashReceiptOnAccount.GLACodeOnAccount,
                    -ClientCashReceiptOnAccount.Amount, Remark, GLSourceCode, ClientCashReceipt.ClientCode, ClientCashReceiptOnAccount.DivisionCode, ClientCashReceiptOnAccount.ProductCode) = False Then

                Throw New Exception("Failed to insert into general ledger detail table.")

            Else

                ClientCashReceiptOnAccount.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

            End If

            If IsInterCompanyTransactionsEnabled Then

                AdvantageFramework.GeneralLedger.CreateIntercompanyTransactions(DbContext, ClientCashReceipt.GLACode, ClientCashReceiptOnAccount.GLACodeOnAccount, GLTransaction,
                                                                                ClientCashReceiptOnAccount.Amount, Remark & " (IC)", GLSourceCode, ClientCashReceipt.ClientCode,
                                                                                ClientCashReceiptOnAccount.DivisionCode, ClientCashReceiptOnAccount.ProductCode,
                                                                                ClientCashReceiptOnAccount.GLACodeDueFrom, ClientCashReceiptOnAccount.GLACodeDueTo,
                                                                                ClientCashReceiptOnAccount.GLSequenceNumberDueFrom, ClientCashReceiptOnAccount.GLSequenceNumberDueTo)

            End If

            If AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.Insert(DbContext, ClientCashReceiptOnAccount) = False Then

                Throw New Exception("Failed to insert into client cash receipt on account table.")

            End If

        End Sub
        Private Function ReverseClientCashReceiptHeader(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt,
                                                        ByVal PostPeriodCode As String,
                                                        ByVal GLSourceCode As String,
                                                        ByVal BatchDate As Date,
                                                        ByRef ReversalSequenceNumber As Short,
                                                        ByVal DeleteCheck As Boolean) As Integer

            Dim ClientCashReceiptNew As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim GLDescription As String = Nothing
            Dim Remark As String = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing

            SetGeneralLedgerDescriptionRemarkForClientCashReceipt(DbContext, ClientCashReceipt, If(DeleteCheck, CheckState.Delete, CheckState.Modify), GLDescription, Remark)

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.CR_CLIENT SET [STATUS] = 'D' WHERE REC_ID={0} AND SEQ_NBR={1}", ClientCashReceipt.ID, ClientCashReceipt.SequenceNumber))

            ClientCashReceiptNew = ClientCashReceipt.Copy
            ClientCashReceiptNew.Status = "D"
            ClientCashReceiptNew.CheckAmount = -ClientCashReceipt.CheckAmount
            ClientCashReceiptNew.PostPeriodCode = PostPeriodCode
            ClientCashReceiptNew.DbContext = DbContext

            If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                Throw New Exception("Problem inserting General Ledger.")

            Else

                ClientCashReceiptNew.GLTransaction = GeneralLedger.Transaction

            End If

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GeneralLedger.Transaction, ClientCashReceipt.GLACode, -ClientCashReceipt.CheckAmount, Remark, GLSourceCode) = False Then

                Throw New Exception("Problem inserting General Ledger Detail.")

            Else

                ClientCashReceiptNew.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

            End If

            If AdvantageFramework.Database.Procedures.ClientCashReceipt.Insert(DbContext, ClientCashReceiptNew) = False Then

                Throw New Exception("Problem inserting client cash receipt.")

            End If

            ReversalSequenceNumber = ClientCashReceiptNew.SequenceNumber

            ReverseClientCashReceiptHeader = GeneralLedger.Transaction

        End Function
        Public Function ReverseClientCashReceipt(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt,
                                                 ByVal PostPeriodCode As String,
                                                 ByVal BatchDate As Date,
                                                 ByVal GLSourceCode As String,
                                                 ByVal DeleteCheck As Boolean) As Integer

            Dim IsInterCompanyTransactionsEnabled As Boolean = False
            Dim GLDescription As String = Nothing
            Dim Remark As String = Nothing
            Dim ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount = Nothing
            Dim ClientCashReceiptDetailListAll As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetail) = Nothing
            Dim GLTransaction As Integer = 0
            Dim ReversalSequenceNumber As Short = Nothing

            SetGeneralLedgerDescriptionRemarkForClientCashReceipt(DbContext, ClientCashReceipt, If(DeleteCheck, CheckState.Delete, CheckState.Modify), GLDescription, Remark)

            IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

            GLTransaction = ReverseClientCashReceiptHeader(DbContext, ClientCashReceipt, PostPeriodCode, GLSourceCode, BatchDate, ReversalSequenceNumber, DeleteCheck)

            ClientCashReceiptOnAccount = AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.LoadActiveByClientCashReceiptID(DbContext, ClientCashReceipt.ID)

            If ClientCashReceiptOnAccount IsNot Nothing Then

                AdvantageFramework.CashReceipts.ReverseClientCashReceiptOnAccount(DbContext, ClientCashReceipt, GLTransaction, GLSourceCode, IsInterCompanyTransactionsEnabled, ClientCashReceiptOnAccount, DeleteCheck, ReversalSequenceNumber, BatchDate)

            End If

            ClientCashReceiptDetailListAll = AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.LoadByClientCashReceiptIDAndSequenceNumber(DbContext, ClientCashReceipt.ID, ClientCashReceipt.SequenceNumber).ToList

            For Each ClientCashReceiptDetail In ClientCashReceiptDetailListAll.OrderBy(Function(Entity) Entity.ARInvoiceNumber)

                ReverseClientCashReceiptDetail(DbContext, ClientCashReceiptDetail, ClientCashReceipt, GLSourceCode, ReversalSequenceNumber, PostPeriodCode, GLTransaction, DeleteCheck)

            Next

            ReverseClientCashReceipt = GLTransaction

        End Function
        Public Sub ReverseClientCashReceiptDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal ClientCashReceiptDetail As AdvantageFramework.Database.Entities.ClientCashReceiptDetail,
                                                  ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt, ByVal GLSourceCode As String,
                                                  ByVal ClientCashReceiptSequenceNumber As Short, ByVal PostPeriodCode As String, ByVal GLTransaction As Integer, ByVal DeleteCheck As Boolean)

            Dim ClientCashReceiptDetailNew As AdvantageFramework.Database.Entities.ClientCashReceiptDetail = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim Remark As String = Nothing
            Dim ClientCashReceiptDetailPaymentList As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment) = Nothing
            Dim ClientCashReceiptDetails As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetail) = Nothing

            ClientCashReceiptDetailNew = ClientCashReceiptDetail.Copy
            ClientCashReceiptDetailNew.DbContext = DbContext
            ClientCashReceiptDetailNew.ClientCashReceiptSequenceNumber = ClientCashReceiptSequenceNumber
            ClientCashReceiptDetailNew.ItemID = 0
            ClientCashReceiptDetailNew.GLSequenceNumberAR = Nothing
            ClientCashReceiptDetailNew.GLSequenceNumberAdjustment = Nothing

            ClientCashReceiptDetails = (From Entity In AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.LoadByClientCashReceiptIDAndSequenceNumber(DbContext, ClientCashReceipt.ID, ClientCashReceipt.SequenceNumber)
                                        Where Entity.ARInvoiceNumber = ClientCashReceiptDetailNew.ARInvoiceNumber AndAlso
                                              Entity.ARInvoiceSequenceNumber = ClientCashReceiptDetailNew.ARInvoiceSequenceNumber
                                        Select Entity).ToList

            ClientCashReceiptDetailNew.PaymentAmount = -ClientCashReceiptDetails.Sum(Function(C) C.PaymentAmount)
            ClientCashReceiptDetailNew.AdjustmentAmount = -ClientCashReceiptDetails.Sum(Function(C) C.AdjustmentAmount)

            ClientCashReceiptDetailNew.PostPeriodCode = PostPeriodCode
            ClientCashReceiptDetailNew.GLTransaction = GLTransaction

            ClientCashReceiptDetailNew.ModifyDelete = True

            If DeleteCheck Then

                Remark = "Client: " & ClientCashReceipt.ClientCode & ", Reverse Check: " & ClientCashReceipt.CheckNumber & ", Invoice: " &
                    ClientCashReceiptDetail.ARInvoiceNumber.ToString.PadLeft(6, "0") & "-" & ClientCashReceiptDetail.ARInvoiceSequenceNumber.ToString.PadLeft(3, "0") &
                    ", Bank: " & ClientCashReceipt.Bank.Description

            Else

                Remark = "Client: " & ClientCashReceipt.ClientCode & ", Modify Check: " & ClientCashReceipt.CheckNumber & ", Invoice: " &
                    ClientCashReceiptDetail.ARInvoiceNumber.ToString.PadLeft(6, "0") & "-" & ClientCashReceiptDetail.ARInvoiceSequenceNumber.ToString.PadLeft(3, "0") &
                    ", Bank: " & ClientCashReceipt.Bank.Description

            End If

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, ClientCashReceiptDetail.GLACodeAR,
                    -(ClientCashReceiptDetailNew.PaymentAmount.GetValueOrDefault(0) + ClientCashReceiptDetailNew.AdjustmentAmount.GetValueOrDefault(0)), Remark, GLSourceCode,
                    ClientCashReceiptDetail.ClientCashReceipt.ClientCode, ClientCashReceiptDetailNew.DivisionCode, ClientCashReceiptDetailNew.ProductCode) = False Then

                Throw New Exception("Problem inserting General Ledger Detail.")

            Else

                ClientCashReceiptDetailNew.GLSequenceNumberAR = GeneralLedgerDetail.SequenceNumber

            End If

            If ClientCashReceiptDetail.GLACodeDueFrom IsNot Nothing Then

                ClientCashReceiptDetailNew.GLACodeDueFrom = ClientCashReceiptDetail.GLACodeDueFrom
                ClientCashReceiptDetailNew.GLACodeDueTo = ClientCashReceiptDetail.GLACodeDueTo

                AdvantageFramework.GeneralLedger.ReverseInterCompanyTransaction(DbContext, GLTransaction, (ClientCashReceiptDetailNew.PaymentAmount.GetValueOrDefault(0) + ClientCashReceiptDetailNew.AdjustmentAmount.GetValueOrDefault(0)),
                        Remark & " (IC)", GLSourceCode, ClientCashReceipt.ClientCode, ClientCashReceiptDetail.DivisionCode, ClientCashReceiptDetail.ProductCode, ClientCashReceiptDetail.GLACodeDueFrom,
                        ClientCashReceiptDetail.GLACodeDueTo, ClientCashReceiptDetailNew.GLSequenceNumberDueFrom, ClientCashReceiptDetailNew.GLSequenceNumberDueTo)

            End If

            If ClientCashReceiptDetailNew.AdjustmentAmount.GetValueOrDefault(0) <> 0 Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, ClientCashReceiptDetail.GLACodeAdjustment,
                        ClientCashReceiptDetailNew.AdjustmentAmount.GetValueOrDefault(0), Remark, GLSourceCode,
                        ClientCashReceipt.ClientCode, ClientCashReceiptDetail.DivisionCode, ClientCashReceiptDetail.ProductCode) = False Then

                    Throw New Exception("Failed to insert into general ledger detail table.")

                Else

                    ClientCashReceiptDetailNew.GLSequenceNumberAdjustment = GeneralLedgerDetail.SequenceNumber

                End If

                If ClientCashReceiptDetail.GLACodeDueFromAdjustment IsNot Nothing Then

                    ClientCashReceiptDetailNew.GLACodeDueFromAdjustment = ClientCashReceiptDetail.GLACodeDueFromAdjustment
                    ClientCashReceiptDetailNew.GLACodeDueToAdjustment = ClientCashReceiptDetail.GLACodeDueToAdjustment

                    AdvantageFramework.GeneralLedger.ReverseInterCompanyTransaction(DbContext, GLTransaction, -ClientCashReceiptDetailNew.AdjustmentAmount.GetValueOrDefault(0), Remark & " (IC)", GLSourceCode,
                                                                                    ClientCashReceipt.ClientCode, ClientCashReceiptDetail.DivisionCode, ClientCashReceiptDetail.ProductCode,
                                                                                    ClientCashReceiptDetail.GLACodeDueFromAdjustment, ClientCashReceiptDetail.GLACodeDueToAdjustment,
                                                                                    ClientCashReceiptDetailNew.GLSequenceNumberDueFromAdjustment, ClientCashReceiptDetailNew.GLSequenceNumberDueToAdjustment)

                End If

            End If

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.CR_CLIENT_DTL SET MODIFY_DELETE=1 WHERE REC_ID={0} AND SEQ_NBR={1} AND AR_INV_NBR={2} AND AR_INV_SEQ={3} AND AR_TYPE='{4}' AND NULLIF(MODIFY_DELETE,0) IS NULL", ClientCashReceipt.ID, ClientCashReceipt.SequenceNumber, ClientCashReceiptDetail.ARInvoiceNumber, ClientCashReceiptDetail.ARInvoiceSequenceNumber, ClientCashReceiptDetail.ARType))

            If AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.Insert(DbContext, ClientCashReceiptDetailNew) = False Then

                Throw New Exception("Problem inserting client cash receipt detail.")

            End If

            ClientCashReceiptDetailPaymentList = AdvantageFramework.Database.Procedures.ClientCashReceiptDetailPayment.LoadByClientCashReceiptDetailIDandSeqandItemID(DbContext, ClientCashReceiptDetail.ClientCashReceiptID, ClientCashReceiptDetail.ClientCashReceiptSequenceNumber, ClientCashReceiptDetail.ItemID).ToList

            For Each ClientCashReceiptDetailPayment In ClientCashReceiptDetailPaymentList

                ReverseClientCashReceiptDetailPayment(DbContext, ClientCashReceiptDetailPayment, ClientCashReceiptDetailNew.ClientCashReceiptSequenceNumber, ClientCashReceiptDetailNew.ItemID)

            Next

        End Sub
        Private Sub ReverseClientCashReceiptDetailPayment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal ClientCashReceiptDetailPayment As AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment,
                                                          ByVal ClientCashReceiptSequenceNumber As Short,
                                                          ByVal ClientCashReceiptDetailItemID As Short)

            Dim ClientCashReceiptDetailPaymentReversal As AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment = Nothing

            ClientCashReceiptDetailPaymentReversal = ClientCashReceiptDetailPayment.Copy

            ClientCashReceiptDetailPaymentReversal.DbContext = DbContext
            ClientCashReceiptDetailPaymentReversal.ClientCashReceiptSequenceNumber = ClientCashReceiptSequenceNumber
            ClientCashReceiptDetailPaymentReversal.ClientCashReceiptDetailItemID = ClientCashReceiptDetailItemID

            ClientCashReceiptDetailPaymentReversal.PaymentAmount = -ClientCashReceiptDetailPaymentReversal.PaymentAmount

            If AdvantageFramework.Database.Procedures.ClientCashReceiptDetailPayment.Insert(DbContext, ClientCashReceiptDetailPaymentReversal) = False Then

                Throw New Exception("Failed to insert into client cash receipt detail payment table.")

            End If

        End Sub
        Public Sub ReverseClientCashReceiptOnAccount(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt,
                                                     ByRef GLTransaction As Nullable(Of Integer),
                                                     ByVal GLSourceCode As String,
                                                     ByVal IsInterCompanyTransactionsEnabled As Boolean,
                                                     ByRef ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount,
                                                     ByVal DeleteCheck As Boolean,
                                                     ByVal ReversalSequenceNumber As Nullable(Of Short),
                                                     ByVal BatchDate As Date)

            Dim GLDescription As String = Nothing
            Dim Remark As String = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim ClientCashReceiptOnAccountCopy As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount = Nothing
            Dim BankDescription As String = Nothing

            BankDescription = GetBankDescription(DbContext, ClientCashReceipt.BankCode)

            SetGeneralLedgerDescriptionRemarkForClientCashReceipt(DbContext, ClientCashReceipt, If(DeleteCheck, CheckState.Delete, CheckState.Modify), GLDescription, Remark)

            If GLTransaction Is Nothing Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, ClientCashReceipt.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                    Throw New Exception("Problem inserting General Ledger.")

                End If

                GLTransaction = GeneralLedger.Transaction

            End If

            ClientCashReceiptOnAccountCopy = New AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount

            ClientCashReceiptOnAccountCopy.ClientCashReceiptID = ClientCashReceiptOnAccount.ClientCashReceiptID
            ClientCashReceiptOnAccountCopy.ClientCashReceiptSequenceNumber = If(ReversalSequenceNumber Is Nothing, ClientCashReceiptOnAccount.ClientCashReceiptSequenceNumber, ReversalSequenceNumber)
            ClientCashReceiptOnAccountCopy.DivisionCode = ClientCashReceiptOnAccount.DivisionCode
            ClientCashReceiptOnAccountCopy.ProductCode = ClientCashReceiptOnAccount.ProductCode
            ClientCashReceiptOnAccountCopy.CampaignCode = ClientCashReceiptOnAccount.CampaignCode
            ClientCashReceiptOnAccountCopy.Amount = -ClientCashReceiptOnAccount.Amount
            ClientCashReceiptOnAccountCopy.GLACodeOnAccount = ClientCashReceiptOnAccount.GLACodeOnAccount
            ClientCashReceiptOnAccountCopy.Distributed = "X"
            ClientCashReceiptOnAccountCopy.PostPeriodCode = ClientCashReceipt.PostPeriodCode
            ClientCashReceiptOnAccountCopy.OfficeCode = ClientCashReceiptOnAccount.OfficeCode
            ClientCashReceiptOnAccountCopy.Comment = ClientCashReceiptOnAccount.Comment

            If DeleteCheck Then

                Remark = "Client: " & ClientCashReceipt.ClientCode & ", Reverse Check: " & ClientCashReceipt.CheckNumber & ", On Account, Bank: " & BankDescription

            Else

                Remark = "Client: " & ClientCashReceipt.ClientCode & ", Modify Check: " & ClientCashReceipt.CheckNumber & ", On Account, Bank: " & BankDescription

            End If

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, ClientCashReceiptOnAccount.GLACodeOnAccount,
                    ClientCashReceiptOnAccount.Amount, Remark, GLSourceCode, ClientCashReceipt.ClientCode, ClientCashReceiptOnAccount.DivisionCode, ClientCashReceiptOnAccount.ProductCode) = False Then

                Throw New Exception("Failed to insert into general ledger detail table.")

            Else

                ClientCashReceiptOnAccountCopy.GLTransaction = GLTransaction
                ClientCashReceiptOnAccountCopy.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

            End If

            If ClientCashReceiptOnAccount.GLACodeDueFrom IsNot Nothing Then

                ClientCashReceiptOnAccountCopy.GLACodeDueFrom = ClientCashReceiptOnAccount.GLACodeDueFrom
                ClientCashReceiptOnAccountCopy.GLACodeDueTo = ClientCashReceiptOnAccount.GLACodeDueTo

                AdvantageFramework.GeneralLedger.ReverseInterCompanyTransaction(DbContext, GLTransaction, -ClientCashReceiptOnAccount.Amount, Remark & " (IC)", GLSourceCode,
                                                                                ClientCashReceipt.ClientCode, ClientCashReceiptOnAccount.DivisionCode, ClientCashReceiptOnAccount.ProductCode,
                                                                                ClientCashReceiptOnAccount.GLACodeDueFrom, ClientCashReceiptOnAccount.GLACodeDueTo,
                                                                                ClientCashReceiptOnAccountCopy.GLSequenceNumberDueFrom, ClientCashReceiptOnAccountCopy.GLSequenceNumberDueTo)

            End If

            ClientCashReceiptOnAccount.Distributed = "X"

            If AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.Update(DbContext, ClientCashReceiptOnAccount) = False Then

                Throw New Exception("Failed to update client cash receipt on account table.")

            End If

            If AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.Insert(DbContext, ClientCashReceiptOnAccountCopy) = False Then

                Throw New Exception("Failed to insert into client cash receipt on account table.")

            End If

        End Sub
        Public Sub SaveCollectionNote(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)

            Dim AccountReceivableCollectionNote As AdvantageFramework.Database.Entities.AccountReceivableCollectionNote = Nothing

            If ClientInvoiceDetail.CollectionNote <> ClientInvoiceDetail.CollectionNoteCopy Then

                AccountReceivableCollectionNote = AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.LoadByARInvoiceNumberAndSequenceAndType(DbContext,
                                                                ClientInvoiceDetail.ARInvoiceNumber, ClientInvoiceDetail.ARInvoiceSequenceNumber, ClientInvoiceDetail.ARType)

                If String.IsNullOrWhiteSpace(ClientInvoiceDetail.CollectionNote) AndAlso AccountReceivableCollectionNote IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.Delete(DbContext, AccountReceivableCollectionNote) = False Then

                        Throw New Exception("Failed to delete collection note.")

                    End If

                ElseIf Not String.IsNullOrWhiteSpace(ClientInvoiceDetail.CollectionNote) Then

                    If AccountReceivableCollectionNote Is Nothing Then

                        AccountReceivableCollectionNote = New AdvantageFramework.Database.Entities.AccountReceivableCollectionNote

                        AccountReceivableCollectionNote.DbContext = DbContext
                        AccountReceivableCollectionNote.ARInvoiceNumber = ClientInvoiceDetail.ARInvoiceNumber
                        AccountReceivableCollectionNote.ARInvoiceSequenceNumber = ClientInvoiceDetail.ARInvoiceSequenceNumber
                        AccountReceivableCollectionNote.ARType = ClientInvoiceDetail.ARType
                        AccountReceivableCollectionNote.Note = ClientInvoiceDetail.CollectionNote

                        If AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.Insert(DbContext, AccountReceivableCollectionNote) = False Then

                            Throw New Exception("Failed to insert collection note.")

                        End If

                    Else

                        AccountReceivableCollectionNote.Note = ClientInvoiceDetail.CollectionNote

                        If AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.Update(DbContext, AccountReceivableCollectionNote) = False Then

                            Throw New Exception("Failed to update collection note.")

                        End If

                    End If

                End If

            End If

        End Sub
        Public Function GetGLAccountListExcludeBankARAPCashAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                    Optional Session As AdvantageFramework.Security.Session = Nothing) As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

            Dim GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing

            If Session IsNot Nothing Then

                GeneralLedgerAccountList = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Session, True)).ToList

            Else

                GeneralLedgerAccountList = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext, True)).ToList

            End If

            GetGLAccountListExcludeBankARAPCashAccounts = GeneralLedgerAccountList

        End Function
        Public Function GetGLAccountListExcludeBankARAPCashAccountsForAdjustments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                                  ByVal GeneralLedgerOfficeCrossReferenceCode As String) As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

            Dim GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing

            GeneralLedgerAccountList = (From GLA In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext, True))
                                        Where GLA.GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReferenceCode
                                        Select GLA).ToList

            GetGLAccountListExcludeBankARAPCashAccountsForAdjustments = GeneralLedgerAccountList

        End Function
        Private Function CreateClientCashReceipt(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal ImportClientCashReceipt As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt,
                                                 ByVal ImportClientCashReceiptPostPeriodBank As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank,
                                                 ByRef BankDescription As String) As AdvantageFramework.Database.Entities.ClientCashReceipt

            Dim ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
            Dim CashReceiptPaymentType As AdvantageFramework.Database.Entities.CashReceiptPaymentType = Nothing

            Try

                ClientCashReceipt = New AdvantageFramework.Database.Entities.ClientCashReceipt
                ClientCashReceipt.DbContext = DbContext

                ClientCashReceipt.ClientCode = ImportClientCashReceipt.ClientCode
                ClientCashReceipt.CheckNumber = ImportClientCashReceipt.CheckNumber
                ClientCashReceipt.DepositDate = ImportClientCashReceipt.DepositDate
                ClientCashReceipt.IsCleared = ImportClientCashReceipt.IsCleared
                ClientCashReceipt.CheckDate = ImportClientCashReceipt.CheckDate
                ClientCashReceipt.CheckAmount = ImportClientCashReceipt.CheckAmount

                ClientCashReceipt.BatchName = ImportClientCashReceipt.BatchName
                ClientCashReceipt.PostPeriodCode = ImportClientCashReceiptPostPeriodBank.PostPeriodCode
                ClientCashReceipt.BankCode = ImportClientCashReceiptPostPeriodBank.BankCode

                If Not String.IsNullOrWhiteSpace(ImportClientCashReceipt.PaymentTypeDescription) Then

                    CashReceiptPaymentType = AdvantageFramework.Database.Procedures.CashReceiptPaymentType.LoadAllActive(DbContext).Where(Function(PT) PT.Description = ImportClientCashReceipt.PaymentTypeDescription).SingleOrDefault

                    If CashReceiptPaymentType IsNot Nothing Then

                        ClientCashReceipt.CashReceiptPaymentTypeID = CashReceiptPaymentType.ID

                    End If

                End If

                Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, ClientCashReceipt.BankCode)

                If Bank IsNot Nothing Then

                    ClientCashReceipt.OfficeCode = Bank.OfficeCode
                    ClientCashReceipt.GLACode = Bank.ARCashAccount

                    BankDescription = Bank.Description

                Else

                    Throw New Exception("Cannot find Bank.")

                End If

            Catch ex As Exception
                ClientCashReceipt = Nothing
            Finally
                CreateClientCashReceipt = ClientCashReceipt
            End Try

        End Function
        Public Function CreateCashReceiptsFromImport(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal ImportClientCashReceiptPostPeriodBank As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank,
                                                     ByVal ImportClientCashReceipts As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt)) As Boolean

            'objects
            Dim Imported As Boolean = True
            Dim IsInterCompanyTransactionsEnabled As Boolean = False
            Dim ImportIDs As Generic.List(Of Integer) = Nothing
            Dim ImportClientCashReceipt As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt = Nothing
            Dim BankDescription As String = Nothing
            Dim ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim ImportClientCashReceiptDetails As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail) = Nothing
            Dim ImportClientCashReceiptList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt) = Nothing
            Dim GLTransaction As Nullable(Of Integer) = Nothing
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing
            Dim IsBalanced As Integer = 0
            Dim ErrorMessage As String = ""
            Dim IsValid As Boolean = True

            Try

                IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

                ImportIDs = ImportClientCashReceipts.Select(Function(ICCR) ICCR.ID).Distinct.ToList()

                For Each ImportID In ImportIDs

                    ImportClientCashReceipt = ImportClientCashReceipts.Where(Function(ICCR) ICCR.ID = ImportID).FirstOrDefault

                    ClientCashReceipt = CreateClientCashReceipt(DbContext, ImportClientCashReceipt, ImportClientCashReceiptPostPeriodBank, BankDescription)

                    If ClientCashReceipt IsNot Nothing Then

                        ClientCashReceipt.DbContext = DbContext

                        ClientCashReceipt.ValidateEntity(IsValid)

                    End If

                    If ClientCashReceipt IsNot Nothing AndAlso IsValid Then

                        ImportClientCashReceiptDetails = New Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail)

                        ImportClientCashReceiptList = ImportClientCashReceipts.Where(Function(ICCR) ICCR.ID = ImportID).ToList

                        For Each ImportClientCashReceipt In ImportClientCashReceiptList

                            ImportClientCashReceiptDetails.Add(ImportClientCashReceipt.ImportClientCashReceiptDetail)

                        Next

                        Try

                            Using TransactionScope As New System.Transactions.TransactionScope

                                ClientCashReceipt.DbContext = DbContext

                                GLTransaction = Nothing

                                AdvantageFramework.CashReceipts.InsertClientCashReceipt(DbContext, ClientCashReceipt, Nothing, "CR", Nothing, GLTransaction, CashReceipts.CheckState.Add)

                                For Each ImportClientCashReceiptDetail In ImportClientCashReceiptDetails

                                    AccountReceivable = AdvantageFramework.Database.Procedures.AccountReceivable.LoadByInvoiceNumberAndSequenceNumberAndType(DbContext, ImportClientCashReceiptDetail.ARInvoiceNumber, ImportClientCashReceiptDetail.ARInvoiceSequence, "IN")

                                    If AccountReceivable Is Nothing Then

                                        Throw New Exception("Cannot find account receivable record.")

                                    End If

                                    InsertClientCashReceiptDetail(DbContext, ClientCashReceipt, ImportClientCashReceiptDetail, AccountReceivable, GLTransaction, "CR", IsInterCompanyTransactionsEnabled, BankDescription)

                                Next

                                IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_clientcashreceipt_check_balanced] {0}, {1}", ClientCashReceipt.ID, GLTransaction)).FirstOrDefault

                                If IsBalanced = 1 Then

                                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_CR_DETAIL WHERE IMPORT_ID = {0}", ImportClientCashReceipt.ID))

                                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.IMP_CR_HEADER WHERE IMPORT_ID = {0}", ImportClientCashReceipt.ID))

                                    TransactionScope.Complete()

                                Else

                                    Throw New Exception("Cannot save.  Check out of balance.")

                                End If

                            End Using

                        Catch ex As Exception
                            Imported = False
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                            ErrorMessage += vbCrLf & ex.Message
                        End Try

                    Else

                        Imported = False

                    End If

                    If ErrorMessage <> "" Then

                        Throw New System.Exception(ErrorMessage)

                    End If

                Next

            Catch ex As Exception
                Imported = False
            End Try

            CreateCashReceiptsFromImport = Imported

        End Function
        Public Function GetAdjustmentGLAccountList(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeCode As String,
                                                   Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            Dim GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
            Dim GLAOfficeXREFCode As String = Nothing
            Dim BankARAPGLAccounts As IEnumerable(Of String) = Nothing

            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                Try

                    GLAOfficeXREFCode = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, OfficeCode).Code

                Catch ex As Exception
                    GLAOfficeXREFCode = Nothing
                End Try

                If GLAOfficeXREFCode IsNot Nothing Then

                    GeneralLedgerAccountList = (From Entity In AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, OfficeCode, True, Session)
                                                Where Entity.GeneralLedgerOfficeCrossReferenceCode = GLAOfficeXREFCode
                                                Select Entity).ToList

                Else

                    GeneralLedgerAccountList = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, OfficeCode, True, Session)

                End If

            Else

                GeneralLedgerAccountList = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, OfficeCode, True, Session)

            End If

            BankARAPGLAccounts = ((From Entity In AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext)
                                   Select Entity.ARCashAccount
                                   Distinct).ToArray).Union(
                                  (From Entity In AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext)
                                   Select Entity.APCashAccount
                                   Distinct).ToArray).ToArray

            GeneralLedgerAccountList = (From GL In GeneralLedgerAccountList
                                        Where BankARAPGLAccounts.Contains(GL.Code) = False
                                        Select GL).ToList

            GetAdjustmentGLAccountList = GeneralLedgerAccountList

        End Function

#End Region

#Region " Other Cash Receipts "

        Private Sub SetGeneralLedgerDescriptionRemarkForOtherCashReceipt(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                         ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt,
                                                                         ByVal OtherCheckState As CheckState,
                                                                         ByRef GLDescription As String,
                                                                         ByRef Remark As String)

            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing

            Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, OtherCashReceipt.BankCode)

            If Bank Is Nothing Then

                Throw New Exception("Failed to load bank.")

            End If

            Select Case OtherCheckState

                Case CheckState.Add

                    GLDescription = "Check: " & OtherCashReceipt.CheckNumber & " - " & OtherCashReceipt.CheckDate & ", Bank: " & Bank.Description & ", Office: " & Bank.OfficeCode & ", Desc: " & OtherCashReceipt.Description

                    Remark = "Check: " & OtherCashReceipt.CheckNumber & " - " & OtherCashReceipt.CheckDate & ", Bank: " & Bank.Description & ", Office: " & OtherCashReceipt.OfficeCode & ", Desc: " & OtherCashReceipt.Description

                Case CheckState.Modify

                    GLDescription = "Modify Check: " & OtherCashReceipt.CheckNumber & " - " & OtherCashReceipt.CheckDate & ", Bank: " & Bank.Description & ", Office: " & Bank.OfficeCode & ", Desc: " & OtherCashReceipt.Description

                    Remark = "Modify Check: " & OtherCashReceipt.CheckNumber & " - " & OtherCashReceipt.CheckDate & ", Bank: " & Bank.Description & ", Office: " & OtherCashReceipt.OfficeCode & ", Desc: " & OtherCashReceipt.Description

                Case CheckState.Delete

                    GLDescription = "Check Reversal: " & OtherCashReceipt.CheckNumber & " - " & OtherCashReceipt.CheckDate & ", Bank: " & Bank.Description & ", Office: " & OtherCashReceipt.OfficeCode & ", Desc: " & OtherCashReceipt.Description

                    Remark = "Check Reversal: " & OtherCashReceipt.CheckNumber & " - " & OtherCashReceipt.CheckDate & ", Bank: " & Bank.Description & ", Office: " & OtherCashReceipt.OfficeCode & ", Desc: " & OtherCashReceipt.Description

            End Select

        End Sub
        Public Sub InsertOtherCashReceipt(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt,
                                          ByVal OtherCashReceiptDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail),
                                          ByVal GLSourceCode As String,
                                          ByVal BatchDate As Date,
                                          ByRef GLTransaction As Nullable(Of Integer),
                                          ByVal CheckStateAddModify As AdvantageFramework.CashReceipts.CheckState)

            Dim GLDescription As String = Nothing
            Dim Remark As String = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing

            SetGeneralLedgerDescriptionRemarkForOtherCashReceipt(DbContext, OtherCashReceipt, CheckStateAddModify, GLDescription, Remark)

            If GLTransaction Is Nothing Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, OtherCashReceipt.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                    Throw New Exception("Failed trying to save data to General Ledger.")

                End If

                GLTransaction = GeneralLedger.Transaction

            End If

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OtherCashReceipt.GLACode, OtherCashReceipt.CheckAmount, GLDescription, GLSourceCode) = False Then

                Throw New Exception("Failed trying to save data to General Ledger Detail.")

            End If

            OtherCashReceipt.GLTransaction = GLTransaction
            OtherCashReceipt.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

            If AdvantageFramework.Database.Procedures.OtherCashReceipt.Insert(DbContext, OtherCashReceipt) = False Then

                Throw New Exception("Insert to other cash receipt table failed.")

            End If

            InsertOtherCashReceiptDetail(DbContext, OtherCashReceipt, OtherCashReceiptDetailList, Remark, GLSourceCode)

        End Sub
        Private Sub InsertOtherCashReceiptDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt,
                                                 ByVal OtherCashReceiptDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail),
                                                 ByVal Remark As String,
                                                 ByVal GLSourceCode As String)

            For Each Detail In OtherCashReceiptDetailList

                If Not Detail.IsDeleted Then

                    InsertOtherCashReceiptDetail(DbContext, OtherCashReceipt, Detail, Remark, GLSourceCode, OtherCashReceipt.GLTransaction)

                End If

            Next

        End Sub
        Private Sub InsertOtherCashReceiptDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt,
                                                 ByVal OtherCashReceiptDetailClass As AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail,
                                                 ByVal Remark As String,
                                                 ByVal GLSourceCode As String,
                                                 ByVal GLTransaction As Integer)

            Dim OtherCashReceiptDetail As AdvantageFramework.Database.Entities.OtherCashReceiptDetail = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing

            OtherCashReceiptDetail = New AdvantageFramework.Database.Entities.OtherCashReceiptDetail
            OtherCashReceiptDetail.DbContext = DbContext

            OtherCashReceiptDetail.OtherCashReceiptID = OtherCashReceipt.ID
            OtherCashReceiptDetail.OtherCashReceiptSequenceNumber = OtherCashReceipt.SequenceNumber
            OtherCashReceiptDetail.GLACode = OtherCashReceiptDetailClass.GLACode
            OtherCashReceiptDetail.Amount = OtherCashReceiptDetailClass.Amount
            OtherCashReceiptDetail.PostPeriodCode = OtherCashReceipt.PostPeriodCode
            OtherCashReceiptDetail.Comment = OtherCashReceiptDetailClass.Comment

            If Not String.IsNullOrWhiteSpace(OtherCashReceiptDetailClass.Comment) AndAlso InStr(Remark, ", Desc: ") > 0 Then

                Remark = Mid(Remark, 1, InStr(Remark, ", Desc: ") - 1) & ", Desc: " & OtherCashReceiptDetailClass.Comment

            End If

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OtherCashReceiptDetail.GLACode,
                    -OtherCashReceiptDetail.Amount.GetValueOrDefault(0), Remark, GLSourceCode) = False Then

                Throw New Exception("Failed to insert into general ledger detail table.")

            Else

                OtherCashReceiptDetail.GLTransaction = GeneralLedgerDetail.GLTransaction
                OtherCashReceiptDetail.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

            End If

            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                AdvantageFramework.GeneralLedger.CreateIntercompanyTransactions(DbContext, OtherCashReceipt.GLACode, OtherCashReceiptDetail.GLACode, GLTransaction,
                                                                                OtherCashReceiptDetail.Amount.GetValueOrDefault(0), Remark & " (IC)", GLSourceCode, Nothing, Nothing, Nothing,
                                                                                OtherCashReceiptDetail.GLACodeDueFrom, OtherCashReceiptDetail.GLACodeDueTo,
                                                                                OtherCashReceiptDetail.GLSequenceNumberDueFrom, OtherCashReceiptDetail.GLSequenceNumberDueTo)

            End If

            If AdvantageFramework.Database.Procedures.OtherCashReceiptDetail.Insert(DbContext, OtherCashReceiptDetail) = False Then

                Throw New Exception("Failed to insert into other cash receipt detail table.")

            End If

        End Sub
        Public Function ReverseOtherCashReceipt(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt,
                                                ByVal PostPeriodCode As String,
                                                ByVal BatchDate As Date,
                                                ByVal GLSourceCode As String,
                                                ByVal DeleteCheck As Boolean) As Integer

            Dim GLDescription As String = Nothing
            Dim Remark As String = Nothing
            Dim OtherCashReceiptDetailReversalList As Generic.List(Of AdvantageFramework.Database.Entities.OtherCashReceiptDetail) = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing

            SetGeneralLedgerDescriptionRemarkForOtherCashReceipt(DbContext, OtherCashReceipt, If(DeleteCheck, CheckState.Delete, CheckState.Modify), GLDescription, Remark)

            OtherCashReceiptDetailReversalList = AdvantageFramework.Database.Procedures.OtherCashReceiptDetail.LoadByOtherCashReceiptIDAndOtherCashReceiptSequenceNumber(DbContext, OtherCashReceipt.ID, OtherCashReceipt.SequenceNumber).ToList

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.CR_OTHER SET [STATUS] = 'D' WHERE REC_ID={0} AND SEQ_NBR={1}", OtherCashReceipt.ID, OtherCashReceipt.SequenceNumber))

            OtherCashReceipt.SequenceNumber = -1
            OtherCashReceipt.CheckAmount = -OtherCashReceipt.CheckAmount
            OtherCashReceipt.Status = "D"

            If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, PostPeriodCode, DbContext.UserCode,
                                                                    GLDescription, GLSourceCode, BatchDate) = False Then

                Throw New Exception("Failed trying to save data to General Ledger.")

            End If

            OtherCashReceipt.GLTransaction = GeneralLedger.Transaction

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GeneralLedger.Transaction, OtherCashReceipt.GLACode,
                                                                          OtherCashReceipt.CheckAmount, Remark, GLSourceCode) = False Then

                Throw New Exception("Problem inserting General Ledger Detail.")

            Else

                OtherCashReceipt.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

            End If

            If AdvantageFramework.Database.Procedures.OtherCashReceipt.Insert(DbContext, OtherCashReceipt) = False Then

                Throw New Exception("Problem inserting other cash receipt.")

            End If

            For Each OtherCashReceiptDetailReversal In OtherCashReceiptDetailReversalList

                AdvantageFramework.CashReceipts.ReverseOtherCashReceiptDetail(DbContext, OtherCashReceiptDetailReversal, OtherCashReceipt, Remark, GLSourceCode, OtherCashReceipt.GLTransaction, PostPeriodCode)

            Next

            ReverseOtherCashReceipt = GeneralLedger.Transaction

        End Function
        Private Sub ReverseOtherCashReceiptDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal OtherCashReceiptDetailReversal As AdvantageFramework.Database.Entities.OtherCashReceiptDetail,
                                                  ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt,
                                                  ByVal Remark As String,
                                                  ByVal GLSourceCode As String,
                                                  ByVal GLTransaction As Integer,
                                                  PostPeriodCode As String)

            Dim IsInterCompanyTransactionsEnabled As Boolean = False
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing

            IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OtherCashReceiptDetailReversal.GLACode, OtherCashReceiptDetailReversal.Amount, Remark, GLSourceCode) = False Then

                Throw New Exception("Failed trying to save data to General Ledger Detail.")

            End If

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.CR_OTHER_DTL SET MODIFY_DELETE=1 WHERE REC_ID={0} AND SEQ_NBR={1} AND REC_ITEM_ID={2}", OtherCashReceiptDetailReversal.OtherCashReceiptID, OtherCashReceiptDetailReversal.OtherCashReceiptSequenceNumber, OtherCashReceiptDetailReversal.ItemID))

            OtherCashReceiptDetailReversal.DbContext = DbContext
            OtherCashReceiptDetailReversal.OtherCashReceiptSequenceNumber = OtherCashReceipt.SequenceNumber
            OtherCashReceiptDetailReversal.Amount = -OtherCashReceiptDetailReversal.Amount
            OtherCashReceiptDetailReversal.GLTransaction = GLTransaction
            OtherCashReceiptDetailReversal.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber
            OtherCashReceiptDetailReversal.PostPeriodCode = PostPeriodCode
            OtherCashReceiptDetailReversal.ModifyDelete = True

            If AdvantageFramework.Database.Procedures.OtherCashReceiptDetail.Insert(DbContext, OtherCashReceiptDetailReversal) = False Then

                Throw New Exception("Failed trying to reverse other cash receipt detail.")

            End If

            If OtherCashReceiptDetailReversal.GLACodeDueFrom IsNot Nothing Then

                AdvantageFramework.GeneralLedger.ReverseInterCompanyTransaction(DbContext, GLTransaction, OtherCashReceiptDetailReversal.Amount.GetValueOrDefault(0), Remark & " (IC)", GLSourceCode,
                    Nothing, Nothing, Nothing, OtherCashReceiptDetailReversal.GLACodeDueFrom, OtherCashReceiptDetailReversal.GLACodeDueTo,
                    OtherCashReceiptDetailReversal.GLSequenceNumberDueFrom, OtherCashReceiptDetailReversal.GLSequenceNumberDueTo)

            End If

        End Sub
        Public Sub SaveOtherCashReceiptDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt,
                                              ByVal OtherCashReceiptDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail),
                                              ByVal GLSourceCode As String,
                                              ByVal BatchDate As Date)

            Dim GLDescription As String = Nothing
            Dim Remark As String = Nothing
            Dim GLTransaction As Nullable(Of Integer) = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim ItemID As Short = Nothing
            Dim OtherCashReceiptDetailOld As AdvantageFramework.Database.Entities.OtherCashReceiptDetail = Nothing

            SetGeneralLedgerDescriptionRemarkForOtherCashReceipt(DbContext, OtherCashReceipt, CheckState.Modify, GLDescription, Remark)

            For Each OtherCashReceiptDetail In OtherCashReceiptDetailList

                If OtherCashReceiptDetail.OtherCashReceiptDetail.IsEntityBeingAdded() Then

                    If GLTransaction Is Nothing Then

                        If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, OtherCashReceipt.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                            Throw New Exception("Failed trying to save data to General Ledger.")

                        Else

                            GLTransaction = GeneralLedger.Transaction

                        End If

                    End If

                    InsertOtherCashReceiptDetail(DbContext, OtherCashReceipt, OtherCashReceiptDetail, Remark, GLSourceCode, GLTransaction)

                Else

                    ItemID = OtherCashReceiptDetail.OtherCashReceiptDetail.ItemID

                    Try

                        OtherCashReceiptDetailOld = (From Entity In AdvantageFramework.Database.Procedures.OtherCashReceiptDetail.Load(DbContext)
                                                     Where Entity.OtherCashReceiptID = OtherCashReceipt.ID AndAlso
                                                           Entity.OtherCashReceiptSequenceNumber = OtherCashReceipt.SequenceNumber AndAlso
                                                           Entity.ItemID = ItemID
                                                     Select Entity).SingleOrDefault

                    Catch ex As Exception
                        Throw New Exception("Error gathering Other Cash Receipt Detail row.")
                    End Try

                    If OtherCashReceiptDetail.IsDeleted OrElse OtherCashReceiptDetailOld.GLACode <> OtherCashReceiptDetail.GLACode OrElse
                            OtherCashReceiptDetailOld.Amount <> OtherCashReceiptDetail.Amount OrElse
                            OtherCashReceiptDetailOld.PostPeriodCode <> OtherCashReceiptDetail.OtherCashReceiptDetail.PostPeriodCode Then

                        If GLTransaction Is Nothing Then

                            If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, OtherCashReceipt.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                                Throw New Exception("Failed trying to save data to General Ledger.")

                            Else

                                GLTransaction = GeneralLedger.Transaction

                            End If

                        End If

                        AdvantageFramework.CashReceipts.ReverseOtherCashReceiptDetail(DbContext, OtherCashReceiptDetailOld, OtherCashReceipt, Remark, GLSourceCode, GLTransaction, OtherCashReceipt.PostPeriodCode)

                        If Not OtherCashReceiptDetail.IsDeleted Then

                            InsertOtherCashReceiptDetail(DbContext, OtherCashReceipt, OtherCashReceiptDetail, Remark, GLSourceCode, GLTransaction)

                        End If

                    End If

                End If

            Next

        End Sub

#End Region

#End Region

    End Module

End Namespace