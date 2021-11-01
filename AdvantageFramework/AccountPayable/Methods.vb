Namespace AccountPayable

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum MediaType
            Print = 0
            Internet = 1
            OutOfHome = 2
            Radio = 3
            TV = 4
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub AddNonClient(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal GLTransaction As Integer, ByVal GLACode As String, ByVal CreditAmount As Double, _
                                ByVal Remark As String, ByVal GLSourceCode As String, ByVal PODetailLineNumber As Nullable(Of Short), ByVal PONumber As Nullable(Of Integer), _
                                ByVal UserCode As String, ByVal AccountPayableGLDistributionOfficeCode As String, ByVal Comment As String, _
                                ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable)

            Dim AccountPayableGLDistribution As AdvantageFramework.Database.Entities.AccountPayableGLDistribution = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing

            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, GLACode, CreditAmount, Remark, GLSourceCode) = False Then

                Throw New Exception("Problem inserting into General Ledger Detail.")

            End If

            AccountPayableGLDistribution = New AdvantageFramework.Database.Entities.AccountPayableGLDistribution
            AccountPayableGLDistribution.ObjectContext = ObjectContext
            AccountPayableGLDistribution.AccountPayableID = AccountPayable.ID
            AccountPayableGLDistribution.AccountPayableSequenceNumber = 0
            AccountPayableGLDistribution.GLACode = GLACode
            AccountPayableGLDistribution.Amount = CreditAmount
            AccountPayableGLDistribution.PODetailLineNumber = PODetailLineNumber
            AccountPayableGLDistribution.GLTransaction = GLTransaction
            AccountPayableGLDistribution.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber
            AccountPayableGLDistribution.PostPeriodCode = AccountPayable.PostPeriodCode
            AccountPayableGLDistribution.PONumber = PONumber
            AccountPayableGLDistribution.Comment = Comment
            AccountPayableGLDistribution.OfficeCode = AccountPayableGLDistributionOfficeCode
            AccountPayableGLDistribution.CreateDate = Now.ToString
            AccountPayableGLDistribution.CreatedBy = UserCode

            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(ObjectContext) Then

                If AccountPayable.OfficeCode IsNot Nothing AndAlso AccountPayable.OfficeCode <> AccountPayableGLDistributionOfficeCode Then

                    Try

                        OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(ObjectContext, AccountPayable.OfficeCode)
                                              Where Entity.Code = AccountPayableGLDistributionOfficeCode
                                              Select Entity).SingleOrDefault

                    Catch ex As Exception
                        Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                    End Try

                    If OfficeInterCompany IsNot Nothing Then

                        AccountPayableGLDistribution.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                        AccountPayableGLDistribution.GLACodeDueTo = OfficeInterCompany.DueToGLACode

                        'Detail DueFrom
                        If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueFromGLACode, CreditAmount, Remark, GLSourceCode) = False Then

                            Throw New Exception("Problem inserting into General Ledger Detail.")

                        End If

                        AccountPayableGLDistribution.GLSequenceNumberDueFrom = GeneralLedgerDetail.SequenceNumber

                        'Detail DueTo
                        If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueToGLACode, CreditAmount * -1, Remark, GLSourceCode) = False Then

                            Throw New Exception("Problem inserting into General Ledger Detail.")

                        End If

                        AccountPayableGLDistribution.GLSequenceNumberDueTo = GeneralLedgerDetail.SequenceNumber

                    End If

                End If

            End If

            If AdvantageFramework.Database.Procedures.AccountPayableGLDistribution.Insert(ObjectContext, AccountPayableGLDistribution) = False Then

                Throw New Exception("Problem inserting into AP General Ledger Distribution.")

            End If

        End Sub
        Public Function GetAllAccountPayableList(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext) As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable)

            Dim AccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable) = Nothing

            If AdvantageFramework.Database.Procedures.Agency.APViewDeletedInvoices(ObjectContext) Then

                AccountPayableList = (From AccountPayable In AdvantageFramework.Database.Procedures.AccountPayable.Load(ObjectContext) _
                                      Where AccountPayable.Deleted = 1
                                      Group AccountPayable By AccountPayable.ID Into Group _
                                      Select New With {.ID = ID, _
                                                       .SequenceNumber = Group.Max(Function(AccountPayable) AccountPayable.SequenceNumber) - 1}).SelectMany(Function(AEntity) From AccountPayable In ObjectContext.AccountPayables _
                                                                                                                                                                              Where AccountPayable.ID = AEntity.ID AndAlso _
                                                                                                                                                                                    AccountPayable.SequenceNumber = AEntity.SequenceNumber _
                                                                                                                                                                              Select AccountPayable).ToList

            Else

                AccountPayableList = New Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable)

            End If

            AccountPayableList.AddRange(From AccountPayable In AdvantageFramework.Database.Procedures.AccountPayable.Load(ObjectContext) _
                                        Where (AccountPayable.IsArchived Is Nothing OrElse _
                                                AccountPayable.IsArchived = 0) AndAlso _
                                                AccountPayable.Modified Is Nothing AndAlso _
                                                AccountPayable.Deleted Is Nothing
                                        Select AccountPayable)

            GetAllAccountPayableList = AccountPayableList

        End Function
        Public Function GetAllAccountPayableListByVendor(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal VendorCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable)

            Dim AccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable) = Nothing

            If AdvantageFramework.Database.Procedures.Agency.APViewDeletedInvoices(ObjectContext) Then

                AccountPayableList = (From AccountPayable In AdvantageFramework.Database.Procedures.AccountPayable.LoadByVendor(ObjectContext, VendorCode) _
                                      Where AccountPayable.Deleted = 1
                                      Group AccountPayable By AccountPayable.ID Into Group _
                                      Select New With {.ID = ID, _
                                                       .SequenceNumber = Group.Max(Function(AccountPayable) AccountPayable.SequenceNumber) - 1}).SelectMany(Function(AEntity) From AccountPayable In ObjectContext.AccountPayables _
                                                                                                                                                                              Where AccountPayable.ID = AEntity.ID AndAlso _
                                                                                                                                                                                    AccountPayable.SequenceNumber = AEntity.SequenceNumber _
                                                                                                                                                                              Select AccountPayable).ToList

            Else

                AccountPayableList = New Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable)

            End If

            AccountPayableList.AddRange(From AccountPayable In AdvantageFramework.Database.Procedures.AccountPayable.LoadByVendor(ObjectContext, VendorCode) _
                                        Where (AccountPayable.IsArchived Is Nothing OrElse _
                                                AccountPayable.IsArchived = 0) AndAlso _
                                                AccountPayable.Modified Is Nothing AndAlso _
                                                AccountPayable.Deleted Is Nothing
                                        Select AccountPayable)

            GetAllAccountPayableListByVendor = AccountPayableList

        End Function
        Public Function GetNonClientGLAccountBindingSource(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal AccountPayableOfficeCode As String, ByVal NonClientOfficeCode As String) As System.Windows.Forms.BindingSource

            Dim AllowCostOfSaleEntry As Boolean = False
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim GLAOfficeXREFCode As String = Nothing

            AllowCostOfSaleEntry = AdvantageFramework.Database.Procedures.Agency.AllowCostOfSaleEntry(ObjectContext)

            If AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(ObjectContext) Then

                GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(ObjectContext, AccountPayableOfficeCode)

                BindingSource = New System.Windows.Forms.BindingSource

                If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                    GLAOfficeXREFCode = GeneralLedgerOfficeCrossReference.Code

                    BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntry(ObjectContext, True, False, AllowCostOfSaleEntry) _
                                                Where Entity.GeneralLedgerOfficeCrossReferenceCode = GLAOfficeXREFCode 
                                                Select Entity.Code, _
                                                       Entity.Description).ToList

                Else

                    BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntry(ObjectContext, True, False, AllowCostOfSaleEntry) _
                                                Select Entity.Code, _
                                                       Entity.Description).ToList

                End If

            ElseIf AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(ObjectContext) Then

                If NonClientOfficeCode IsNot Nothing AndAlso NonClientOfficeCode <> "" Then

                    Try

                        GLAOfficeXREFCode = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(ObjectContext, NonClientOfficeCode).Code

                    Catch ex As Exception
                        GLAOfficeXREFCode = Nothing
                    End Try

                    If GLAOfficeXREFCode IsNot Nothing Then

                        BindingSource = New System.Windows.Forms.BindingSource
                        BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntry(ObjectContext, True, False, AllowCostOfSaleEntry) _
                                                    Where Entity.GeneralLedgerOfficeCrossReferenceCode = GLAOfficeXREFCode 
                                                    Select Entity.Code, _
                                                           Entity.Description).ToList

                    Else

                        BindingSource = New System.Windows.Forms.BindingSource
                        BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntry(ObjectContext, True, False, AllowCostOfSaleEntry) _
                                                    Select Entity.Code, _
                                                           Entity.Description).ToList

                    End If

                Else

                    BindingSource = New System.Windows.Forms.BindingSource
                    BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntry(ObjectContext, True, False, AllowCostOfSaleEntry) _
                                                Select Entity.Code, _
                                                       Entity.Description).ToList

                End If

            Else

                BindingSource = New System.Windows.Forms.BindingSource
                BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntry(ObjectContext, True, False, AllowCostOfSaleEntry) _
                                            Select Entity.Code, _
                                                   Entity.Description).ToList

            End If

            GetNonClientGLAccountBindingSource = BindingSource

        End Function
        Public Function GrossToNet(ByVal GrossValue As Decimal, ByVal CommissionPercent As Decimal) As Decimal

            Dim NewValue As Decimal = 0

            If GrossValue = 0 Then

                NewValue = 0

            Else

                NewValue = GrossValue - (GrossValue * CommissionPercent / 100)

            End If

            GrossToNet = Format(NewValue, "#0.00")

        End Function
        Public Sub CalculateNetAndCommission(ByVal GrossValue As Decimal, ByVal CommissionPercent As Decimal, ByRef NetAmount As Decimal, ByRef CommissionAmount As Decimal)

            If GrossValue = 0 Then

                CommissionAmount = 0

                NetAmount = 0

            Else

                CommissionAmount = Format(GrossValue * CommissionPercent / 100, "#0.00")

                NetAmount = Format(GrossValue - CommissionAmount, "#0.00")

            End If

        End Sub
        Public Sub CalculateGrossAndCommission(ByVal NetValue As Decimal, ByVal Discount As Decimal, ByVal MarkupPercent As Decimal, ByRef GrossAmount As Decimal, ByRef CommissionAmount As Decimal)

            If NetValue = 0 Then

                CommissionAmount = 0

                GrossAmount = 0

            Else

                CommissionAmount = Format(NetValue * MarkupPercent / 100, "#0.00")

                GrossAmount = Format(NetValue + CommissionAmount, "#0.00")

            End If

        End Sub
        Public Function NetToGross(ByVal NetValue As Decimal, ByVal CommissionPercent As Decimal) As Decimal

            Dim NewValue As Decimal = 0

            If NetValue = 0 Then

                NewValue = 0

            Else

                NewValue = (NetValue / (CDec(1) - CommissionPercent / 100))

            End If

            NetToGross = Format(NewValue, "#0.00")

        End Function
        Public Function InsertGeneralLedger(ByRef GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger, ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal PostPeriodCode As String, _
                                            ByVal UserCode As String, ByVal Description As String, ByVal GLSourceCode As String, ByVal BatchDate As Nullable(Of Date)) As Boolean

            'objects
            Dim GeneralLedgerInserted As Boolean = False

            Try

                GeneralLedger = New AdvantageFramework.Database.Entities.GeneralLedger
                GeneralLedger.ObjectContext = ObjectContext
                GeneralLedger.EnteredDate = Now.ToShortDateString
                GeneralLedger.ModifiedDate = Now.ToShortDateString
                GeneralLedger.PostPeriodCode = PostPeriodCode
                GeneralLedger.UserCode = UserCode
                GeneralLedger.Description = Description
                GeneralLedger.GLSourceCode = GLSourceCode
                GeneralLedger.BatchDate = BatchDate
                GeneralLedgerInserted = AdvantageFramework.Database.Procedures.GeneralLedger.Insert(ObjectContext, GeneralLedger)

            Catch ex As Exception
                GeneralLedgerInserted = False
            Finally
                InsertGeneralLedger = GeneralLedgerInserted
            End Try

        End Function
        Public Function InsertGeneralLedgerDetail(ByRef GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail, ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, _
                                                  ByVal GLTransaction As Integer, ByVal GLACode As String, ByVal CreditAmount As Double, ByVal Remark As String, ByVal GLSourceCode As String, _
                                                  Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing) As Boolean

            'objects
            Dim GeneralLedgerDetailInserted As Boolean = False

            Try

                GeneralLedgerDetail = New AdvantageFramework.Database.Entities.GeneralLedgerDetail
                GeneralLedgerDetail.ObjectContext = ObjectContext
                GeneralLedgerDetail.GLTransaction = GLTransaction
                GeneralLedgerDetail.GLACode = GLACode
                GeneralLedgerDetail.CreditAmount = CreditAmount
                GeneralLedgerDetail.DebitAmount = CreditAmount
                GeneralLedgerDetail.Remark = Remark
                GeneralLedgerDetail.GLSourceCode = GLSourceCode
                GeneralLedgerDetail.ClientCode = ClientCode
                GeneralLedgerDetail.DivisionCode = DivisionCode
                GeneralLedgerDetail.ProductCode = ProductCode
                GeneralLedgerDetailInserted = AdvantageFramework.Database.Procedures.GeneralLedgerDetail.Insert(ObjectContext, GeneralLedgerDetail)

            Catch ex As Exception
                GeneralLedgerDetailInserted = False
            Finally
                InsertGeneralLedgerDetail = GeneralLedgerDetailInserted
            End Try

        End Function
        Public Function SaveMediaApproval(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal AccountPayableID As Integer, ByVal OrderNumber As Integer, _
                                          ByVal LineNumber As Short, ByVal Source As String, ByVal Status As Nullable(Of Short), ByVal UserCode As String, ByVal Comments As String) As Boolean

            Dim Saved As Boolean = False
            Dim AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval = Nothing

            Try

                ObjectContext.ExecuteStoreCommand(String.Format("UPDATE dbo.AP_MEDIA_APPROVAL SET ACTIVE_REV=NULL WHERE AP_ID={0} AND ORDER_NBR={1} AND LINE_NBR={2}", AccountPayableID, OrderNumber, LineNumber))

                AccountPayableMediaApproval = New AdvantageFramework.Database.Entities.AccountPayableMediaApproval

                AccountPayableMediaApproval.AccountPayableID = AccountPayableID
                AccountPayableMediaApproval.OrderNumber = OrderNumber
                AccountPayableMediaApproval.LineNumber = LineNumber
                AccountPayableMediaApproval.Source = Source
                AccountPayableMediaApproval.Status = Status
                AccountPayableMediaApproval.IsActiveRevision = 1
                AccountPayableMediaApproval.UserCode = UserCode
                AccountPayableMediaApproval.RevisionDate = Now
                AccountPayableMediaApproval.Comments = Comments
                AccountPayableMediaApproval.ApplicationSource = "AP"

                Saved = AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.Insert(ObjectContext, AccountPayableMediaApproval)

            Catch ex As Exception
                Saved = False
            Finally
                SaveMediaApproval = Saved
            End Try

        End Function
        Private Function CreateAccountPayable(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, _
                                              ByVal ImportAccountPayable As AdvantageFramework.Database.Classes.ImportAccountPayable,
                                              ByVal PostPeriodCode As String) As AdvantageFramework.Database.Entities.AccountPayable

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorTerm As AdvantageFramework.Database.Entities.VendorTerm = Nothing

            Try

                AccountPayable = New AdvantageFramework.Database.Entities.AccountPayable
                AccountPayable.ObjectContext = ObjectContext

                AccountPayable.Type = "V"

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(ObjectContext, ImportAccountPayable.VendorCode)

                AccountPayable.VendorCode = ImportAccountPayable.VendorCode
                AccountPayable.InvoiceNumber = ImportAccountPayable.InvoiceNumber
                AccountPayable.CreatedDate = Now

                AccountPayable.Is1099Invoice = Vendor.Vendor1099Flag.GetValueOrDefault(0)

                AccountPayable.IsOnHold = 0

                AccountPayable.InvoiceDescription = If(ImportAccountPayable.InvoiceDescription Is Nothing, "", ImportAccountPayable.InvoiceDescription)

                AccountPayable.OfficeCode = ImportAccountPayable.OfficeCode

                AccountPayable.VendorTermCode = Vendor.VendorTermCode

                AccountPayable.GLACode = ImportAccountPayable.GLAccount

                AccountPayable.PostPeriodCode = PostPeriodCode

                AccountPayable.InvoiceDate = ImportAccountPayable.InvoiceDate

                If Vendor.VendorTermCode IsNot Nothing Then

                    VendorTerm = AdvantageFramework.Database.Procedures.VendorTerm.LoadByVendorTermCode(ObjectContext, Vendor.VendorTermCode)

                    AccountPayable.PaidDate = DateAdd(DateInterval.Day, CDbl(VendorTerm.DaysToPay), AccountPayable.InvoiceDate)

                End If

                AccountPayable.CreatedByUserCode = ObjectContext.UserCode

                AccountPayable.InvoiceAmount = ImportAccountPayable.InvoiceTotalNet.GetValueOrDefault(0)
                AccountPayable.ShippingAmount = 0
                AccountPayable.SalesTaxAmount = ImportAccountPayable.InvoiceTotalTax.GetValueOrDefault(0)
                AccountPayable.DiscountPercentage = 0

            Catch ex As Exception
                AccountPayable = Nothing
            Finally
                CreateAccountPayable = AccountPayable
            End Try

        End Function
        Private Sub InsertInternet(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String, _
                                   ByVal AccountPayableInternetDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableInternetDistributionDetail), ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Collection = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Collection
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableInternetDistributionDetail In AccountPayableInternetDistributionDetailList

                AddInternet(ObjectContext, AccountPayableInternetDistributionDetail, AccountPayableInternetDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode, False)

            Next

        End Sub
        Private Sub InsertMagazine(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String, _
                                   ByVal AccountPayableMagazineDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableMagazineDistributionDetail), ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Collection = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Collection
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableMagazineDistributionDetail In AccountPayableMagazineDistributionDetailList

                AddMagazine(ObjectContext, AccountPayableMagazineDistributionDetail, AccountPayableMagazineDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode)

            Next

        End Sub
        Private Sub InsertNewspaper(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String, _
                                    ByVal AccountPayableNewspaperDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableNewspaperDistributionDetail), ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Collection = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Collection
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableNewspaperDistributionDetail In AccountPayableNewspaperDistributionDetailList

                AddNewspaper(ObjectContext, AccountPayableNewspaperDistributionDetail, AccountPayableNewspaperDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode)

            Next

        End Sub
        Private Sub InsertNonClient(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String, _
                                    ByVal AccountPayableGLDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableGLDistributionDetail), ByVal GLSourceCode As String, _
                                    ByVal UpdatePurchaseOrderStatus As Boolean)

            Dim Remark As String = Nothing

            For Each AccountPayableGLDistributionDetail In AccountPayableGLDistributionDetailList

                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayableGLDistributionDetail.Comment
                AdvantageFramework.AccountPayable.AddNonClient(ObjectContext, GLTransaction, AccountPayableGLDistributionDetail.GLACode, AccountPayableGLDistributionDetail.Amount, Remark, GLSourceCode, AccountPayableGLDistributionDetail.PODetailLineNumber, AccountPayableGLDistributionDetail.PONumber, ObjectContext.UserCode, AccountPayableGLDistributionDetail.OfficeCode, AccountPayableGLDistributionDetail.Comment, AccountPayable)

                If UpdatePurchaseOrderStatus AndAlso AccountPayableGLDistributionDetail.PONumber IsNot Nothing AndAlso AccountPayableGLDistributionDetail.PODetailLineNumber IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.UpdateIsCompleteAndParentPO(ObjectContext, AccountPayableGLDistributionDetail.PONumber, AccountPayableGLDistributionDetail.PODetailLineNumber, AccountPayableGLDistributionDetail.POComplete.GetValueOrDefault(0)) = False Then

                        Throw New Exception("Failed to update purchase order.")

                    End If

                End If

            Next

        End Sub
        Private Sub InsertOutOfHome(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String, _
                                    ByVal AccountPayableOutOfHomeDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableOutOfHomeDistributionDetail), ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Collection = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Collection
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableOutOfHomeDistributionDetail In AccountPayableOutOfHomeDistributionDetailList

                AddOutOfHome(ObjectContext, AccountPayableOutOfHomeDistributionDetail, AccountPayableOutOfHomeDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode)

            Next

        End Sub
        Private Sub InsertProduction(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String, _
                                     ByVal AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableProductionDistributionDetail), ByVal GLSourceCode As String, _
                                     ByVal UpdatePurchaseOrderStatus As Boolean)

            Dim AccountPayableProductionComment As AdvantageFramework.Database.Entities.AccountPayableProductionComment = Nothing
            Dim JobComponent As Collection = Nothing
            Dim OfficeCodeList As Collection = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing
            Dim Remark As String = Nothing
            Dim AgencyInvoiceTaxFlag As Boolean = False

            JobComponent = New Collection
            OfficeCodeList = New Collection
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            AgencyInvoiceTaxFlag = AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(ObjectContext)

            For Each AccountPayableProductionDistributionDetail In AccountPayableProductionDistributionDetailList

                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayable.InvoiceDescription & ", Job: " & AccountPayableProductionDistributionDetail.JobNumber.ToString.PadLeft(6, "0") & "-" & AccountPayableProductionDistributionDetail.JobComponentNumber.ToString.PadLeft(3, "0") & " [PR]"
                AddProduction(ObjectContext, AccountPayableProductionDistributionDetail, AccountPayableProductionDistributionDetailList, AccountPayableProductionDistributionDetail.AccountPayableProduction, GLTransaction, Remark, AccountPayable, _
                              JobComponent, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, False, AgencyInvoiceTaxFlag, GLSourceCode)

                If AccountPayableProductionDistributionDetail.Comment IsNot Nothing AndAlso AccountPayableProductionDistributionDetail.Comment <> "" Then

                    AccountPayableProductionComment = New AdvantageFramework.Database.Entities.AccountPayableProductionComment
                    AccountPayableProductionComment.ObjectContext = ObjectContext
                    AccountPayableProductionComment.AccountPayableID = AccountPayable.ID
                    AccountPayableProductionComment.LineNumber = AccountPayableProductionDistributionDetail.AccountPayableProduction.LineNumber
                    AccountPayableProductionComment.JobNumber = AccountPayableProductionDistributionDetail.AccountPayableProduction.JobNumber
                    AccountPayableProductionComment.JobComponentNumber = AccountPayableProductionDistributionDetail.AccountPayableProduction.JobComponentNumber
                    AccountPayableProductionComment.FunctionCode = AccountPayableProductionDistributionDetail.AccountPayableProduction.FunctionCode
                    AccountPayableProductionComment.Comment = AccountPayableProductionDistributionDetail.Comment
                    If AdvantageFramework.Database.Procedures.AccountPayableProductionComment.Insert(ObjectContext, AccountPayableProductionComment) = False Then

                        Throw New Exception("Failed to insert AP Production Comment.")

                    End If

                End If

                If UpdatePurchaseOrderStatus AndAlso AccountPayableProductionDistributionDetail.PONumber IsNot Nothing AndAlso AccountPayableProductionDistributionDetail.PODetailLineNumber IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.UpdateIsCompleteAndParentPO(ObjectContext, AccountPayableProductionDistributionDetail.PONumber, AccountPayableProductionDistributionDetail.PODetailLineNumber, AccountPayableProductionDistributionDetail.POComplete.GetValueOrDefault(0)) = False Then

                        Throw New Exception("Failed to update purchase order.")

                    End If

                End If

            Next

        End Sub
        Private Sub InsertRadio(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String, _
                                ByVal AccountPayableRadioDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableRadioDistributionDetail), ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Collection = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Collection
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableRadioDistributionDetail In AccountPayableRadioDistributionDetailList

                AddRadio(ObjectContext, AccountPayableRadioDistributionDetail, AccountPayableRadioDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode)

            Next

        End Sub
        Private Sub InsertTV(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String, _
                             ByVal AccountPayableTVDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableTVDistributionDetail), ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Collection = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Collection
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableTVDistributionDetail In AccountPayableTVDistributionDetailList

                AddTV(ObjectContext, AccountPayableTVDistributionDetail, AccountPayableTVDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode)

            Next

        End Sub
        Public Function CreateAccountPayable(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, _
                                             ByVal AccountPayableGLDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableGLDistributionDetail), _
                                             ByVal AccountPayableInternetDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableInternetDistributionDetail), _
                                             ByVal AccountPayableMagazineDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableMagazineDistributionDetail), _
                                             ByVal AccountPayableNewspaperDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableNewspaperDistributionDetail), _
                                             ByVal AccountPayableOutOfHomeDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableOutOfHomeDistributionDetail), _
                                             ByVal AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableProductionDistributionDetail), _
                                             ByVal AccountPayableRadioDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableRadioDistributionDetail), _
                                             ByVal AccountPayableTVDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableTVDistributionDetail), _
                                             ByVal GLSourceCode As String, ByVal BatchDate As Date, ByRef VendorCode As String, ByRef AccountPayableID As Integer, ByRef SequenceNumber As Short, _
                                             ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim VendorName As String = Nothing
            Dim GLDescription As String = Nothing
            Dim CreditAmount As Decimal = Nothing
            Dim Remark As String = Nothing
            Dim DbTransaction As System.Data.Common.DbTransaction = Nothing
            Dim IsBalanced As Integer = -1

            If AccountPayable IsNot Nothing Then

                VendorName = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(ObjectContext, AccountPayable.VendorCode).Name

                Try

                    ObjectContext.Connection.Open()

                    DbTransaction = ObjectContext.Connection.BeginTransaction

                    AccountPayable.ObjectContext = ObjectContext

                    GLDescription = "VN:" & AccountPayable.VendorCode & "-" & VendorName & ",Inv:" & AccountPayable.InvoiceNumber
                    If AdvantageFramework.AccountPayable.InsertGeneralLedger(GeneralLedger, ObjectContext, AccountPayable.PostPeriodCode, ObjectContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                        Throw New Exception("Failed trying to save data to General Ledger.")

                    End If

                    CreditAmount = (AccountPayable.InvoiceAmount + AccountPayable.ShippingAmount + AccountPayable.SalesTaxAmount) * -1
                    Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayable.InvoiceDescription
                    If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GeneralLedger.Transaction, AccountPayable.GLACode, CreditAmount, Remark, GLSourceCode) = False Then

                        Throw New Exception("Failed trying to save data to General Ledger Detail.")

                    End If

                    AccountPayable.GLTransaction = GeneralLedger.Transaction
                    AccountPayable.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

                    If AdvantageFramework.Database.Procedures.AccountPayable.Insert(ObjectContext, AccountPayable) = False Then

                        Throw New Exception("Insert to AP Header failed.")

                    End If

                    InsertNonClient(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableGLDistributionDetailList, GLSourceCode, True)

                    InsertProduction(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableProductionDistributionDetailList, GLSourceCode, True)

                    InsertMagazine(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableMagazineDistributionDetailList, GLSourceCode)

                    InsertNewspaper(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableNewspaperDistributionDetailList, GLSourceCode)

                    InsertInternet(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableInternetDistributionDetailList, GLSourceCode)

                    InsertOutOfHome(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableOutOfHomeDistributionDetailList, GLSourceCode)

                    InsertRadio(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableRadioDistributionDetailList, GLSourceCode)

                    InsertTV(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableTVDistributionDetailList, GLSourceCode)

                    IsBalanced = ObjectContext.ExecuteStoreQuery(Of Integer)(String.Format("exec [advsp_ap_invoice_balanced] {0}, {1}", AccountPayable.ID, GeneralLedger.Transaction)).FirstOrDefault

                    If IsBalanced = 1 Then

                        DbTransaction.Commit()

                    Else

                        Throw New Exception("Cannot save.  Invoice out of balance.")

                    End If

                    VendorCode = AccountPayable.VendorCode
                    AccountPayableID = AccountPayable.ID
                    SequenceNumber = AccountPayable.SequenceNumber

                    Created = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += vbCrLf & ex.Message
                    'ErrorMessage += vbCrLf & vbCrLf & ex.StackTrace
                Finally

                    If ObjectContext.Connection.State = ConnectionState.Open Then

                        ObjectContext.Connection.Close()

                    End If

                End Try

            End If

            CreateAccountPayable = Created

        End Function
        Public Sub AddInternet(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal AccountPayableInternetDistributionDetail As AdvantageFramework.Database.Classes.AccountPayableInternetDistributionDetail, _
                               ByVal AccountPayableInternetDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableInternetDistributionDetail), _
                               ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, _
                               ByRef Orders As Collection, ByRef OfficeCodeList As Collection, ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection, _
                               ByVal VendorName As String, ByVal GLSourceCode As String, ByVal PostPeriodChanged As Boolean)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableInternet As AdvantageFramework.Database.Entities.AccountPayableInternet = Nothing
            Dim Remark As String = Nothing

            If AccountPayableInternetDistributionDetail.NewApprovalComments IsNot Nothing AndAlso AccountPayableInternetDistributionDetail.NewApprovalComments.Trim <> "" Then

                If AccountPayableInternetDistributionDetail.NewApprovalStatus = -2 Then

                    AccountPayableInternetDistributionDetail.NewApprovalStatus = Nothing

                End If

                If AdvantageFramework.AccountPayable.SaveMediaApproval(ObjectContext, AccountPayable.ID, AccountPayableInternetDistributionDetail.InternetOrderNumber, _
                                                                       AccountPayableInternetDistributionDetail.InternetDetailLineNumber, "I", AccountPayableInternetDistributionDetail.NewApprovalStatus, _
                                                                       ObjectContext.UserCode, AccountPayableInternetDistributionDetail.NewApprovalComments) = False Then

                    Throw New Exception("Failed to insert AP Media Approval.")

                End If

            End If

            If AccountPayableInternetDistributionDetail.AccountPayableInternet.EntityKey Is Nothing Then

                AccountPayableInternet = AccountPayableInternetDistributionDetail.AccountPayableInternet

            Else

                AccountPayableInternet = AccountPayableInternetDistributionDetail.AccountPayableInternet.Copy()

            End If

            If Orders.Contains(AccountPayableInternetDistributionDetail.InternetOrderNumber) = False Then

                Amount = AccountPayableInternetDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso _
                                                                                             Entity.InternetOrderNumber = AccountPayableInternetDistributionDetail.InternetOrderNumber) _
                                                                     .Sum(Function(Entity) Entity.DisbursedAmount)

                If Not PostPeriodChanged Then

                    Try

                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableInternet.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID) _
                                        .Where(Function(Entity) Entity.InternetOrderNumber = AccountPayableInternetDistributionDetail.InternetOrderNumber) _
                                        .Sum(Function(Entity) Entity.NetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax)

                    Catch ex As Exception
                        OldAmount = 0
                    End Try

                    Amount = Amount - OldAmount

                End If

                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayable.InvoiceDescription & ", Order: " & AccountPayableInternetDistributionDetail.InternetOrderNumber.ToString.PadLeft(6, "0") & " [IN]"

                If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, AccountPayableInternetDistributionDetail.AccountPayableInternet.GLACode, _
                       Amount, Remark, GLSourceCode, AccountPayableInternetDistributionDetail.ClientCode, AccountPayableInternetDistributionDetail.DivisionCode, _
                       AccountPayableInternetDistributionDetail.ProductCode) = False Then

                    Throw New Exception("Problem inserting General Ledger Detail.")

                End If

                Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableInternetDistributionDetail.InternetOrderNumber)

            End If

            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(ObjectContext) Then

                If AccountPayableInternetDistributionDetail.OfficeCode IsNot Nothing AndAlso AccountPayableInternetDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                    OfficeInterCompanyCode = AccountPayableInternetDistributionDetail.OfficeCode

                    Try

                        OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(ObjectContext, AccountPayable.OfficeCode)
                                              Where Entity.Code = OfficeInterCompanyCode
                                              Select Entity).SingleOrDefault

                    Catch ex As Exception
                        Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                    End Try

                    If OfficeInterCompany IsNot Nothing Then

                        If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                            OfficeCodeList.Add(OfficeInterCompany, OfficeInterCompanyCode)

                            Amount = AccountPayableInternetDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount)

                            If Not PostPeriodChanged Then

                                Try

                                    OldAmount = AdvantageFramework.Database.Procedures.AccountPayableInternet.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID). _
                                                    Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode).Sum(Function(Entity) Entity.NetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax)

                                Catch ex As Exception
                                    OldAmount = 0
                                End Try

                                Amount = Amount - OldAmount

                            End If

                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueFromGLACode, _
                                    Amount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableInternet.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableInternet.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueToGLACode, _
                                    Amount * -1, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableInternet.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableInternet.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        Else

                            AccountPayableInternet.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableInternet.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            AccountPayableInternet.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableInternet.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        End If

                    End If

                End If

            End If

            AccountPayableInternet.ObjectContext = ObjectContext
            AccountPayableInternet.AccountPayableID = AccountPayable.ID
            AccountPayableInternet.AccountPayableSequenceNumber = 0
            AccountPayableInternet.GLTransaction = GLTransaction
            AccountPayableInternet.GLSequenceNumber = Orders.Item(AccountPayableInternetDistributionDetail.InternetOrderNumber.ToString)
            AccountPayableInternet.PostPeriodCode = AccountPayable.PostPeriodCode
            AccountPayableInternet.CreateDate = Now.ToString
            AccountPayableInternet.CreatedBy = ObjectContext.UserCode

            AccountPayableInternet.InternetOrderNumber = AccountPayableInternetDistributionDetail.InternetOrderNumber
            AccountPayableInternet.InternetDetailLineNumber = AccountPayableInternetDistributionDetail.InternetDetailLineNumber

            AccountPayableInternet.DiscountAmount = Math.Abs(AccountPayableInternet.DiscountAmount.GetValueOrDefault(0)) * -1

            If AdvantageFramework.Database.Procedures.AccountPayableInternet.Insert(ObjectContext, AccountPayableInternet) = False Then

                Throw New Exception("Failed to insert AP Internet.")

            End If

        End Sub
        Public Sub AddMagazine(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal AccountPayableMagazineDistributionDetail As AdvantageFramework.Database.Classes.AccountPayableMagazineDistributionDetail, _
                               ByVal AccountPayableMagazineDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableMagazineDistributionDetail), _
                               ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, _
                               ByRef Orders As Collection, ByRef OfficeCodeList As Collection, ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection, _
                               ByVal VendorName As String, ByVal GLSourceCode As String, Optional ByVal PostPeriodChanged As Boolean = False)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableMagazine As AdvantageFramework.Database.Entities.AccountPayableMagazine = Nothing
            Dim Remark As String = Nothing

            If AccountPayableMagazineDistributionDetail.NewApprovalComments IsNot Nothing AndAlso AccountPayableMagazineDistributionDetail.NewApprovalComments.Trim <> "" Then

                If AccountPayableMagazineDistributionDetail.NewApprovalStatus = -2 Then

                    AccountPayableMagazineDistributionDetail.NewApprovalStatus = Nothing

                End If

                If AdvantageFramework.AccountPayable.SaveMediaApproval(ObjectContext, AccountPayable.ID, AccountPayableMagazineDistributionDetail.OrderNumber, _
                                                                       AccountPayableMagazineDistributionDetail.OrderLineNumber, "M", AccountPayableMagazineDistributionDetail.NewApprovalStatus, _
                                                                       ObjectContext.UserCode, AccountPayableMagazineDistributionDetail.NewApprovalComments) = False Then

                    Throw New Exception("Failed to insert AP Media Approval.")

                End If

            End If

            If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.EntityKey Is Nothing Then

                AccountPayableMagazine = AccountPayableMagazineDistributionDetail.AccountPayableMagazine

            Else

                AccountPayableMagazine = AccountPayableMagazineDistributionDetail.AccountPayableMagazine.Copy()

            End If

            If Orders.Contains(AccountPayableMagazineDistributionDetail.OrderNumber) = False Then

                Amount = AccountPayableMagazineDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso _
                                                                            Entity.OrderNumber = AccountPayableMagazineDistributionDetail.OrderNumber).Sum(Function(Entity) Entity.DisbursedAmount)

                If Not PostPeriodChanged Then

                    Try

                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableMagazine.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID) _
                                        .Where(Function(Entity) Entity.OrderNumber = AccountPayableMagazineDistributionDetail.OrderNumber) _
                                        .Sum(Function(Entity) Entity.DisbursedAmount)

                    Catch ex As Exception
                        OldAmount = 0
                    End Try

                    Amount = Amount - OldAmount

                End If

                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayable.InvoiceDescription & ", Order: " & AccountPayableMagazineDistributionDetail.OrderNumber.ToString.PadLeft(6, "0") & " [MA]"

                If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, AccountPayableMagazineDistributionDetail.AccountPayableMagazine.GLACode, _
                       Amount, Remark, GLSourceCode, AccountPayableMagazineDistributionDetail.ClientCode, AccountPayableMagazineDistributionDetail.DivisionCode, _
                       AccountPayableMagazineDistributionDetail.ProductCode) = False Then

                    Throw New Exception("Problem inserting General Ledger Detail.")

                End If

                Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableMagazineDistributionDetail.OrderNumber)

            End If

            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(ObjectContext) Then

                If AccountPayableMagazineDistributionDetail.OfficeCode IsNot Nothing AndAlso AccountPayableMagazineDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                    OfficeInterCompanyCode = AccountPayableMagazineDistributionDetail.OfficeCode

                    Try

                        OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(ObjectContext, AccountPayable.OfficeCode)
                                              Where Entity.Code = OfficeInterCompanyCode
                                              Select Entity).SingleOrDefault

                    Catch ex As Exception
                        Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                    End Try

                    If OfficeInterCompany IsNot Nothing Then

                        If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                            OfficeCodeList.Add(OfficeInterCompany, OfficeInterCompanyCode)

                            Amount = AccountPayableMagazineDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount)

                            If Not PostPeriodChanged Then

                                Try

                                    OldAmount = AdvantageFramework.Database.Procedures.AccountPayableMagazine.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID).Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode).Sum(Function(Entity) Entity.DisbursedAmount)

                                Catch ex As Exception
                                    OldAmount = 0
                                End Try

                                Amount = Amount - OldAmount

                            End If

                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueFromGLACode, _
                                    Amount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableMagazine.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableMagazine.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueToGLACode, _
                                    Amount * -1, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableMagazine.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableMagazine.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        Else

                            AccountPayableMagazine.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableMagazine.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            AccountPayableMagazine.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableMagazine.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        End If

                    End If

                End If

            End If

            AccountPayableMagazine.ObjectContext = ObjectContext
            AccountPayableMagazine.AccountPayableID = AccountPayable.ID
            AccountPayableMagazine.AccountPayableSequenceNumber = 0
            AccountPayableMagazine.GLTransaction = GLTransaction
            AccountPayableMagazine.GLSequenceNumber = Orders.Item(AccountPayableMagazineDistributionDetail.OrderNumber.ToString)
            AccountPayableMagazine.PostPeriodCode = AccountPayable.PostPeriodCode

            AccountPayableMagazine.OrderNumber = AccountPayableMagazineDistributionDetail.OrderNumber
            AccountPayableMagazine.OrderLineNumber = AccountPayableMagazineDistributionDetail.OrderLineNumber

            AccountPayableMagazine.CreateDate = Now.ToString
            AccountPayableMagazine.CreatedBy = ObjectContext.UserCode

            AccountPayableMagazine.DiscountLN = Math.Abs(AccountPayableMagazine.DiscountLN.GetValueOrDefault(0)) * -1

            If AdvantageFramework.Database.Procedures.AccountPayableMagazine.Insert(ObjectContext, AccountPayableMagazine) = False Then

                Throw New Exception("Failed to insert AP Magazine.")

            End If

        End Sub
        Public Sub AddNewspaper(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal AccountPayableNewspaperDistributionDetail As AdvantageFramework.Database.Classes.AccountPayableNewspaperDistributionDetail, _
                                ByVal AccountPayableNewspaperDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableNewspaperDistributionDetail), _
                                ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, _
                                ByRef Orders As Collection, ByRef OfficeCodeList As Collection, ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection, _
                                ByVal VendorName As String, ByVal GLSourceCode As String, Optional ByVal PostPeriodChanged As Boolean = False)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableNewspaper As AdvantageFramework.Database.Entities.AccountPayableNewspaper = Nothing
            Dim Remark As String = Nothing

            If AccountPayableNewspaperDistributionDetail.NewApprovalComments IsNot Nothing AndAlso AccountPayableNewspaperDistributionDetail.NewApprovalComments.Trim <> "" Then

                If AccountPayableNewspaperDistributionDetail.NewApprovalStatus = -2 Then

                    AccountPayableNewspaperDistributionDetail.NewApprovalStatus = Nothing

                End If

                If AdvantageFramework.AccountPayable.SaveMediaApproval(ObjectContext, AccountPayable.ID, AccountPayableNewspaperDistributionDetail.OrderNumber, _
                                                                       AccountPayableNewspaperDistributionDetail.OrderLineNumber, "N", AccountPayableNewspaperDistributionDetail.NewApprovalStatus, _
                                                                       ObjectContext.UserCode, AccountPayableNewspaperDistributionDetail.NewApprovalComments) = False Then

                    Throw New Exception("Failed to insert AP Media Approval.")

                End If

            End If

            If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.EntityKey Is Nothing Then

                AccountPayableNewspaper = AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper

            Else

                AccountPayableNewspaper = AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.Copy()

            End If

            If Orders.Contains(AccountPayableNewspaperDistributionDetail.OrderNumber) = False Then

                Amount = AccountPayableNewspaperDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso _
                                                                                              Entity.OrderNumber = AccountPayableNewspaperDistributionDetail.OrderNumber).Sum(Function(Entity) Entity.DisbursedAmount)

                If Not PostPeriodChanged Then

                    Try

                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableNewspaper.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID) _
                                        .Where(Function(Entity) Entity.OrderNumber = AccountPayableNewspaperDistributionDetail.OrderNumber) _
                                        .Sum(Function(Entity) Entity.DisbursedAmount)

                    Catch ex As Exception
                        OldAmount = 0
                    End Try

                    Amount = Amount - OldAmount

                End If

                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayable.InvoiceDescription & ", Order: " & AccountPayableNewspaperDistributionDetail.OrderNumber.ToString.PadLeft(6, "0") & " [NP]"

                If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.GLACode, _
                       Amount, Remark, GLSourceCode, AccountPayableNewspaperDistributionDetail.ClientCode, AccountPayableNewspaperDistributionDetail.DivisionCode, _
                       AccountPayableNewspaperDistributionDetail.ProductCode) = False Then

                    Throw New Exception("Problem inserting General Ledger Detail.")

                End If

                Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableNewspaperDistributionDetail.OrderNumber)

            End If

            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(ObjectContext) Then

                If AccountPayableNewspaperDistributionDetail.OfficeCode IsNot Nothing AndAlso AccountPayableNewspaperDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                    OfficeInterCompanyCode = AccountPayableNewspaperDistributionDetail.OfficeCode

                    Try

                        OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(ObjectContext, AccountPayable.OfficeCode)
                                              Where Entity.Code = OfficeInterCompanyCode
                                              Select Entity).SingleOrDefault

                    Catch ex As Exception
                        Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                    End Try

                    If OfficeInterCompany IsNot Nothing Then

                        If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                            OfficeCodeList.Add(OfficeInterCompany, OfficeInterCompanyCode)

                            Amount = AccountPayableNewspaperDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount)

                            If Not PostPeriodChanged Then

                                Try

                                    OldAmount = AdvantageFramework.Database.Procedures.AccountPayableNewspaper.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID).Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode).Sum(Function(Entity) Entity.DisbursedAmount)

                                Catch ex As Exception
                                    OldAmount = 0
                                End Try

                                Amount = Amount - OldAmount

                            End If

                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueFromGLACode, _
                                    Amount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableNewspaper.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableNewspaper.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueToGLACode, _
                                    Amount * -1, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableNewspaper.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableNewspaper.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        Else

                            AccountPayableNewspaper.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableNewspaper.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            AccountPayableNewspaper.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableNewspaper.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        End If

                    End If

                End If

            End If

            AccountPayableNewspaper.ObjectContext = ObjectContext
            AccountPayableNewspaper.AccountPayableID = AccountPayable.ID
            AccountPayableNewspaper.AccountPayableSequenceNumber = 0
            AccountPayableNewspaper.GLTransaction = GLTransaction
            AccountPayableNewspaper.GLSequenceNumber = Orders.Item(AccountPayableNewspaperDistributionDetail.OrderNumber.ToString)
            AccountPayableNewspaper.PostPeriodCode = AccountPayable.PostPeriodCode
            AccountPayableNewspaper.CreateDate = Now.ToString
            AccountPayableNewspaper.CreatedBy = ObjectContext.UserCode

            AccountPayableNewspaper.OrderNumber = AccountPayableNewspaperDistributionDetail.OrderNumber
            AccountPayableNewspaper.OrderLineNumber = AccountPayableNewspaperDistributionDetail.OrderLineNumber

            AccountPayableNewspaper.DiscountLN = Math.Abs(AccountPayableNewspaper.DiscountLN.GetValueOrDefault(0)) * -1
            AccountPayableNewspaper.PrintLines = If(AccountPayableNewspaper.PrintLines Is Nothing, 0, AccountPayableNewspaper.PrintLines)
            AccountPayableNewspaper.Rate = If(AccountPayableNewspaper.Rate Is Nothing, 0, AccountPayableNewspaper.Rate)

            If AdvantageFramework.Database.Procedures.AccountPayableNewspaper.Insert(ObjectContext, AccountPayableNewspaper) = False Then

                Throw New Exception("Failed to insert AP Newspaper.")

            End If

        End Sub
        Public Sub AddOutOfHome(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal AccountPayableOutOfHomeDistributionDetail As AdvantageFramework.Database.Classes.AccountPayableOutOfHomeDistributionDetail, _
                                ByVal AccountPayableOutOfHomeDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableOutOfHomeDistributionDetail), _
                                ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, _
                                ByRef Orders As Collection, ByRef OfficeCodeList As Collection, ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection, _
                                ByVal VendorName As String, ByVal GLSourceCode As String, Optional ByVal PostPeriodChanged As Boolean = False)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableOutOfHome As AdvantageFramework.Database.Entities.AccountPayableOutOfHome = Nothing
            Dim Remark As String = Nothing

            If AccountPayableOutOfHomeDistributionDetail.NewApprovalComments IsNot Nothing AndAlso AccountPayableOutOfHomeDistributionDetail.NewApprovalComments.Trim <> "" Then

                If AccountPayableOutOfHomeDistributionDetail.NewApprovalStatus = -2 Then

                    AccountPayableOutOfHomeDistributionDetail.NewApprovalStatus = Nothing

                End If

                If AdvantageFramework.AccountPayable.SaveMediaApproval(ObjectContext, AccountPayable.ID, AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber, _
                                                                       AccountPayableOutOfHomeDistributionDetail.OutdoorDetailLineNumber, "O", AccountPayableOutOfHomeDistributionDetail.NewApprovalStatus, _
                                                                       ObjectContext.UserCode, AccountPayableOutOfHomeDistributionDetail.NewApprovalComments) = False Then

                    Throw New Exception("Failed to insert AP Media Approval.")

                End If

            End If

            If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.EntityKey Is Nothing Then

                AccountPayableOutOfHome = AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome

            Else

                AccountPayableOutOfHome = AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.Copy()

            End If

            If Orders.Contains(AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber) = False Then

                Amount = AccountPayableOutOfHomeDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso _
                                                                                              Entity.OutdoorOrderNumber = AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber) _
                                                                      .Sum(Function(Entity) Entity.DisbursedAmount)

                If Not PostPeriodChanged Then

                    Try

                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID) _
                                        .Where(Function(Entity) Entity.OutdoorOrderNumber = AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber) _
                                        .Sum(Function(Entity) Entity.NetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax)

                    Catch ex As Exception
                        OldAmount = 0
                    End Try

                    Amount = Amount - OldAmount

                End If

                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayable.InvoiceDescription & ", Order: " & AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber.ToString.PadLeft(6, "0") & " [OD]"

                If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.GLACode, _
                       Amount, Remark, GLSourceCode, AccountPayableOutOfHomeDistributionDetail.ClientCode, AccountPayableOutOfHomeDistributionDetail.DivisionCode, _
                       AccountPayableOutOfHomeDistributionDetail.ProductCode) = False Then

                    Throw New Exception("Problem inserting General Ledger Detail.")

                End If

                Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber)

            End If

            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(ObjectContext) Then

                If AccountPayableOutOfHomeDistributionDetail.OfficeCode IsNot Nothing AndAlso AccountPayableOutOfHomeDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                    OfficeInterCompanyCode = AccountPayableOutOfHomeDistributionDetail.OfficeCode

                    Try

                        OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(ObjectContext, AccountPayable.OfficeCode)
                                              Where Entity.Code = OfficeInterCompanyCode
                                              Select Entity).SingleOrDefault

                    Catch ex As Exception
                        Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                    End Try

                    If OfficeInterCompany IsNot Nothing Then

                        If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                            OfficeCodeList.Add(OfficeInterCompany, OfficeInterCompanyCode)

                            Amount = AccountPayableOutOfHomeDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount)

                            If Not PostPeriodChanged Then

                                Try

                                    OldAmount = AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID). _
                                                    Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode).Sum(Function(Entity) Entity.NetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax)

                                Catch ex As Exception
                                    OldAmount = 0
                                End Try

                                Amount = Amount - OldAmount

                            End If

                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueFromGLACode, _
                                    Amount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableOutOfHome.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableOutOfHome.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueToGLACode, _
                                    Amount * -1, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableOutOfHome.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableOutOfHome.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        Else

                            AccountPayableOutOfHome.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableOutOfHome.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            AccountPayableOutOfHome.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableOutOfHome.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        End If

                    End If

                End If

            End If

            AccountPayableOutOfHome.ObjectContext = ObjectContext
            AccountPayableOutOfHome.AccountPayableID = AccountPayable.ID
            AccountPayableOutOfHome.AccountPayableSequenceNumber = 0
            AccountPayableOutOfHome.GLTransaction = GLTransaction
            AccountPayableOutOfHome.GLSequenceNumber = Orders.Item(AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber.ToString)
            AccountPayableOutOfHome.PostPeriodCode = AccountPayable.PostPeriodCode
            AccountPayableOutOfHome.CreateDate = Now.ToString
            AccountPayableOutOfHome.CreatedBy = ObjectContext.UserCode

            AccountPayableOutOfHome.OutdoorOrderNumber = AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber
            AccountPayableOutOfHome.OutdoorDetailLineNumber = AccountPayableOutOfHomeDistributionDetail.OutdoorDetailLineNumber

            AccountPayableOutOfHome.DiscountAmount = Math.Abs(AccountPayableOutOfHome.DiscountAmount.GetValueOrDefault(0)) * -1

            If AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.Insert(ObjectContext, AccountPayableOutOfHome) = False Then

                Throw New Exception("Failed to insert AP Outdoor.")

            End If

        End Sub
        Public Sub AddProduction(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal AccountPayableProductionDistributionDetail As AdvantageFramework.Database.Classes.AccountPayableProductionDistributionDetail, _
                                 ByVal AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableProductionDistributionDetail), _
                                 ByRef AccountPayableProductionNew As AdvantageFramework.Database.Entities.AccountPayableProduction, _
                                 ByVal GLTransaction As Integer, ByVal Remark As String, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, _
                                 ByRef JobComponent As Collection, ByRef OfficeCodeList As Collection, ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection, _
                                 ByVal VendorName As String, ByVal PostPeriodChanged As Boolean, ByVal AgencyInvoiceTaxFlag As Boolean, ByVal GLSourceCode As String)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            If JobComponent.Contains(AccountPayableProductionDistributionDetail.JobNumber & "|" & AccountPayableProductionDistributionDetail.JobComponentNumber & "|" & _
                                     AccountPayableProductionDistributionDetail.GLACode) = False Then

                Amount = AccountPayableProductionDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso _
                                                                                               Entity.JobNumber = AccountPayableProductionDistributionDetail.JobNumber AndAlso _
                                                                                               Entity.JobComponentNumber = AccountPayableProductionDistributionDetail.JobComponentNumber AndAlso _
                                                                                               Entity.GLACode = AccountPayableProductionDistributionDetail.GLACode).Sum(Function(Entity) Entity.Disbursed)

                If Not PostPeriodChanged Then

                    Try

                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID) _
                                        .Where(Function(Entity) Entity.JobNumber = AccountPayableProductionDistributionDetail.JobNumber AndAlso _
                                                                Entity.JobComponentNumber = AccountPayableProductionDistributionDetail.JobComponentNumber AndAlso _
                                                                Entity.GLACode = AccountPayableProductionDistributionDetail.GLACode) _
                                        .Sum(Function(Entity) Entity.ExtendedAmount + Entity.ExtendedNonResaleTax)

                    Catch ex As Exception
                        OldAmount = 0
                    End Try

                    Amount = Amount - OldAmount

                End If

                If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, AccountPayableProductionDistributionDetail.GLACode, _
                       Amount, Remark, GLSourceCode, AccountPayableProductionDistributionDetail.ClientCode, AccountPayableProductionDistributionDetail.DivisionCode, _
                       AccountPayableProductionDistributionDetail.ProductCode) = False Then

                    Throw New Exception("Problem inserting General Ledger Detail.")

                End If

                JobComponent.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableProductionDistributionDetail.JobNumber & "|" & AccountPayableProductionDistributionDetail.JobComponentNumber & "|" & _
                                 AccountPayableProductionDistributionDetail.GLACode)

            End If

            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(ObjectContext) Then

                If AccountPayableProductionDistributionDetail.OfficeCode IsNot Nothing AndAlso AccountPayableProductionDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                    OfficeInterCompanyCode = AccountPayableProductionDistributionDetail.OfficeCode

                    Try

                        OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(ObjectContext, AccountPayable.OfficeCode)
                                              Where Entity.Code = OfficeInterCompanyCode
                                              Select Entity).SingleOrDefault

                    Catch ex As Exception
                        Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                    End Try

                    If OfficeInterCompany IsNot Nothing Then

                        If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                            OfficeCodeList.Add(OfficeInterCompany, OfficeInterCompanyCode)

                            Amount = AccountPayableProductionDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.Disbursed)

                            If Not PostPeriodChanged Then

                                Try

                                    OldAmount = AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID). _
                                                    Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode).Sum(Function(Entity) Entity.ExtendedAmount + Entity.ExtendedNonResaleTax)

                                Catch ex As Exception
                                    OldAmount = 0
                                End Try

                                Amount = Amount - OldAmount

                            End If

                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueFromGLACode, _
                                    Amount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableProductionNew.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableProductionNew.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueToGLACode, _
                                    Amount * -1, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableProductionNew.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableProductionNew.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        Else

                            AccountPayableProductionNew.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableProductionNew.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            AccountPayableProductionNew.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableProductionNew.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        End If

                    End If

                End If

            End If

            AccountPayableProductionNew.ObjectContext = ObjectContext
            AccountPayableProductionNew.AccountPayableID = AccountPayable.ID
            AccountPayableProductionNew.AccountPayableSequenceNumber = 0
            AccountPayableProductionNew.GLTransaction = GLTransaction
            AccountPayableProductionNew.GLSequenceNumber = JobComponent.Item(AccountPayableProductionDistributionDetail.JobNumber & "|" & AccountPayableProductionDistributionDetail.JobComponentNumber & "|" & _
                                                                             AccountPayableProductionDistributionDetail.GLACode)
            AccountPayableProductionNew.PostPeriodCode = AccountPayable.PostPeriodCode
            AccountPayableProductionNew.JobNumber = AccountPayableProductionDistributionDetail.JobNumber
            AccountPayableProductionNew.JobComponentNumber = AccountPayableProductionDistributionDetail.JobComponentNumber
            AccountPayableProductionNew.CreateDate = Now.ToString
            AccountPayableProductionNew.CreatedBy = ObjectContext.UserCode

            If AgencyInvoiceTaxFlag Then

                SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(ObjectContext, AccountPayableProductionNew.SalesTaxCode)

                If SalesTax IsNot Nothing AndAlso SalesTax.Resale.GetValueOrDefault(0) = 1 Then

                    AccountPayableProductionNew.SalesTaxCode = Nothing

                    AccountPayableProductionNew.LineTotal = AccountPayableProductionNew.LineTotal - _
                                                            AccountPayableProductionNew.ExtendedStateResale.GetValueOrDefault(0) - _
                                                            AccountPayableProductionNew.ExtendedCountyResale.GetValueOrDefault(0) - _
                                                            AccountPayableProductionNew.ExtendedCityResale.GetValueOrDefault(0)

                    AccountPayableProductionNew.IsResaleTax = 0
                    AccountPayableProductionNew.ExtendedStateResale = 0
                    AccountPayableProductionNew.ExtendedCountyResale = 0
                    AccountPayableProductionNew.ExtendedCityResale = 0

                    AccountPayableProductionNew.CityTaxPercent = 0
                    AccountPayableProductionNew.CountyTaxPercent = 0
                    AccountPayableProductionNew.StateTaxPercent = 0

                End If

            End If

            AccountPayableProductionNew.AccountReceivableInvoiceNumber = Nothing
            AccountPayableProductionNew.AccountReceivableInvoiceSequenceNumber = Nothing
            AccountPayableProductionNew.AccountReceivableType = Nothing
            AccountPayableProductionNew.GLTransactionBill = Nothing
            AccountPayableProductionNew.GLSequenceNumberSales = Nothing
            AccountPayableProductionNew.GLSequenceNumberCOS = Nothing
            AccountPayableProductionNew.GLSequenceNumberState = Nothing
            AccountPayableProductionNew.GLSequenceNumberCounty = Nothing
            AccountPayableProductionNew.GLSequenceNumberCity = Nothing
            AccountPayableProductionNew.GLSequenceNumberWIP = Nothing
            AccountPayableProductionNew.GLACodeSales = Nothing
            AccountPayableProductionNew.GLACodeCOS = Nothing
            AccountPayableProductionNew.GLACodeState = Nothing
            AccountPayableProductionNew.GLACodeCounty = Nothing
            AccountPayableProductionNew.GLACodeCity = Nothing

            AccountPayableProductionNew.BillingUserCode = Nothing

            If AdvantageFramework.Database.Procedures.AccountPayableProduction.Insert(ObjectContext, AccountPayableProductionNew) = False Then

                Throw New Exception("Failed to insert AP Production.")

            End If

        End Sub
        Public Sub AddRadio(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal AccountPayableRadioDistributionDetail As AdvantageFramework.Database.Classes.AccountPayableRadioDistributionDetail, _
                            ByVal AccountPayableRadioDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableRadioDistributionDetail), _
                            ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, _
                            ByRef Orders As Collection, ByRef OfficeCodeList As Collection, ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection, _
                            ByVal VendorName As String, ByVal GLSourceCode As String, Optional ByVal PostPeriodChanged As Boolean = False)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableRadio As AdvantageFramework.Database.Entities.AccountPayableRadio = Nothing
            Dim Remark As String = Nothing

            If AccountPayableRadioDistributionDetail.NewApprovalComments IsNot Nothing AndAlso AccountPayableRadioDistributionDetail.NewApprovalComments.Trim <> "" Then

                If AccountPayableRadioDistributionDetail.NewApprovalStatus = -2 Then

                    AccountPayableRadioDistributionDetail.NewApprovalStatus = Nothing

                End If

                If AdvantageFramework.AccountPayable.SaveMediaApproval(ObjectContext, AccountPayable.ID, AccountPayableRadioDistributionDetail.OrderNumber, _
                                                                       AccountPayableRadioDistributionDetail.OrderLineNumber, "R", AccountPayableRadioDistributionDetail.NewApprovalStatus, _
                                                                       ObjectContext.UserCode, AccountPayableRadioDistributionDetail.NewApprovalComments) = False Then

                    Throw New Exception("Failed to insert AP Media Approval.")

                End If

            End If

            If AccountPayableRadioDistributionDetail.AccountPayableRadio.EntityKey Is Nothing Then

                AccountPayableRadio = AccountPayableRadioDistributionDetail.AccountPayableRadio

            Else

                AccountPayableRadio = AccountPayableRadioDistributionDetail.AccountPayableRadio.Copy()

            End If

            If Orders.Contains(AccountPayableRadioDistributionDetail.OrderNumber) = False Then

                Amount = AccountPayableRadioDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso _
                                                                                          Entity.OrderNumber = AccountPayableRadioDistributionDetail.OrderNumber).Sum(Function(Entity) Entity.DisbursedAmount)

                If Not PostPeriodChanged Then

                    Try

                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableRadio.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID) _
                                        .Where(Function(Entity) Entity.OrderNumber = AccountPayableRadioDistributionDetail.OrderNumber) _
                                        .Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax)

                    Catch ex As Exception
                        OldAmount = 0
                    End Try

                    Amount = Amount - OldAmount

                End If

                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayable.InvoiceDescription & ", Order: " & AccountPayableRadioDistributionDetail.OrderNumber.ToString.PadLeft(6, "0") & " [RA]"

                If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, AccountPayableRadioDistributionDetail.AccountPayableRadio.GLACode, _
                       Amount, Remark, GLSourceCode, AccountPayableRadioDistributionDetail.ClientCode, AccountPayableRadioDistributionDetail.DivisionCode, _
                       AccountPayableRadioDistributionDetail.ProductCode) = False Then

                    Throw New Exception("Problem inserting General Ledger Detail.")

                End If

                Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableRadioDistributionDetail.OrderNumber)

            End If

            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(ObjectContext) Then

                If AccountPayableRadioDistributionDetail.OfficeCode IsNot Nothing AndAlso AccountPayableRadioDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                    OfficeInterCompanyCode = AccountPayableRadioDistributionDetail.OfficeCode

                    Try

                        OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(ObjectContext, AccountPayable.OfficeCode)
                                              Where Entity.Code = OfficeInterCompanyCode
                                              Select Entity).SingleOrDefault

                    Catch ex As Exception
                        Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                    End Try

                    If OfficeInterCompany IsNot Nothing Then

                        If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                            OfficeCodeList.Add(OfficeInterCompany, OfficeInterCompanyCode)

                            Amount = AccountPayableRadioDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount)

                            If Not PostPeriodChanged Then

                                Try

                                    OldAmount = AdvantageFramework.Database.Procedures.AccountPayableRadio.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID). _
                                                    Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode).Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax)

                                Catch ex As Exception
                                    OldAmount = 0
                                End Try

                                Amount = Amount - OldAmount

                            End If

                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueFromGLACode, _
                                    Amount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableRadio.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableRadio.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueToGLACode, _
                                    Amount * -1, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableRadio.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableRadio.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        Else

                            AccountPayableRadio.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableRadio.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            AccountPayableRadio.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableRadio.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        End If

                    End If

                End If

            End If

            AccountPayableRadio.ObjectContext = ObjectContext
            AccountPayableRadio.AccountPayableID = AccountPayable.ID
            AccountPayableRadio.AccountPayableSequenceNumber = 0
            AccountPayableRadio.GLTransaction = GLTransaction
            AccountPayableRadio.GLSequenceNumber = Orders.Item(AccountPayableRadioDistributionDetail.OrderNumber.ToString)
            AccountPayableRadio.PostPeriodCode = AccountPayable.PostPeriodCode
            AccountPayableRadio.CreateDate = Now.ToString
            AccountPayableRadio.CreatedBy = ObjectContext.UserCode

            If AccountPayableRadio.RewriteFlag = 0 Then

                AccountPayableRadio.TotalSpots = 0

            End If

            AccountPayableRadio.OrderNumber = AccountPayableRadioDistributionDetail.OrderNumber

            AccountPayableRadio.DiscountAmount = Math.Abs(AccountPayableRadio.DiscountAmount.GetValueOrDefault(0)) * -1

            If AdvantageFramework.Database.Procedures.AccountPayableRadio.Insert(ObjectContext, AccountPayableRadio) = False Then

                Throw New Exception("Failed to insert AP Radio.")

            End If

        End Sub
        Public Sub AddTV(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal AccountPayableTVDistributionDetail As AdvantageFramework.Database.Classes.AccountPayableTVDistributionDetail, _
                         ByVal AccountPayableTVDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableTVDistributionDetail), _
                         ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, _
                         ByRef Orders As Collection, ByRef OfficeCodeList As Collection, ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection, _
                         ByVal VendorName As String, ByVal GLSourceCode As String, Optional ByVal PostPeriodChanged As Boolean = False)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableTV As AdvantageFramework.Database.Entities.AccountPayableTV = Nothing
            Dim Remark As String = Nothing

            If AccountPayableTVDistributionDetail.NewApprovalComments IsNot Nothing AndAlso AccountPayableTVDistributionDetail.NewApprovalComments.Trim <> "" Then

                If AccountPayableTVDistributionDetail.NewApprovalStatus = -2 Then

                    AccountPayableTVDistributionDetail.NewApprovalStatus = Nothing

                End If

                If AdvantageFramework.AccountPayable.SaveMediaApproval(ObjectContext, AccountPayable.ID, AccountPayableTVDistributionDetail.OrderNumber, _
                                                                       AccountPayableTVDistributionDetail.OrderLineNumber, "T", AccountPayableTVDistributionDetail.NewApprovalStatus, _
                                                                       ObjectContext.UserCode, AccountPayableTVDistributionDetail.NewApprovalComments) = False Then

                    Throw New Exception("Failed to insert AP Media Approval.")

                End If

            End If

            If AccountPayableTVDistributionDetail.AccountPayableTV.EntityKey Is Nothing Then

                AccountPayableTV = AccountPayableTVDistributionDetail.AccountPayableTV

            Else

                AccountPayableTV = AccountPayableTVDistributionDetail.AccountPayableTV.Copy()

            End If

            If Orders.Contains(AccountPayableTVDistributionDetail.OrderNumber) = False Then

                Amount = AccountPayableTVDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso _
                                                                                       Entity.OrderNumber = AccountPayableTVDistributionDetail.OrderNumber).Sum(Function(Entity) Entity.DisbursedAmount)

                If Not PostPeriodChanged Then

                    Try

                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableTV.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID) _
                                        .Where(Function(Entity) Entity.OrderNumber = AccountPayableTVDistributionDetail.OrderNumber) _
                                        .Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax)

                    Catch ex As Exception
                        OldAmount = 0
                    End Try

                    Amount = Amount - OldAmount

                End If

                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayable.InvoiceDescription & ", Order: " & AccountPayableTVDistributionDetail.OrderNumber.ToString.PadLeft(6, "0") & " [TV]"

                If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, AccountPayableTVDistributionDetail.AccountPayableTV.GLACode, _
                       Amount, Remark, GLSourceCode, AccountPayableTVDistributionDetail.ClientCode, AccountPayableTVDistributionDetail.DivisionCode, _
                       AccountPayableTVDistributionDetail.ProductCode) = False Then

                    Throw New Exception("Problem inserting General Ledger Detail.")

                End If

                Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableTVDistributionDetail.OrderNumber)

            End If

            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(ObjectContext) Then

                If AccountPayableTVDistributionDetail.OfficeCode IsNot Nothing AndAlso AccountPayableTVDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                    OfficeInterCompanyCode = AccountPayableTVDistributionDetail.OfficeCode

                    Try

                        OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(ObjectContext, AccountPayable.OfficeCode)
                                              Where Entity.Code = OfficeInterCompanyCode
                                              Select Entity).SingleOrDefault

                    Catch ex As Exception
                        Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                    End Try

                    If OfficeInterCompany IsNot Nothing Then

                        If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                            OfficeCodeList.Add(OfficeInterCompany, OfficeInterCompanyCode)

                            Amount = AccountPayableTVDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount)

                            If Not PostPeriodChanged Then

                                Try

                                    OldAmount = AdvantageFramework.Database.Procedures.AccountPayableTV.LoadActiveByAccountPayableID(ObjectContext, AccountPayable.ID). _
                                                    Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode).Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax)

                                Catch ex As Exception
                                    OldAmount = 0
                                End Try

                                Amount = Amount - OldAmount

                            End If

                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueFromGLACode, _
                                    Amount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableTV.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableTV.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GLTransaction, OfficeInterCompany.DueToGLACode, _
                                    Amount * -1, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting General Ledger Detail.")

                            End If

                            DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                            AccountPayableTV.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableTV.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        Else

                            AccountPayableTV.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableTV.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                            AccountPayableTV.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                            AccountPayableTV.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                        End If

                    End If

                End If

            End If

            AccountPayableTV.ObjectContext = ObjectContext
            AccountPayableTV.AccountPayableID = AccountPayable.ID
            AccountPayableTV.AccountPayableSequenceNumber = 0
            AccountPayableTV.GLTransaction = GLTransaction
            AccountPayableTV.GLSequenceNumber = Orders.Item(AccountPayableTVDistributionDetail.OrderNumber.ToString)
            AccountPayableTV.PostPeriodCode = AccountPayable.PostPeriodCode
            AccountPayableTV.CreateDate = Now.ToString
            AccountPayableTV.CreatedBy = ObjectContext.UserCode

            If AccountPayableTV.RewriteFlag = 0 Then

                AccountPayableTV.TotalSpots = 0

            End If

            AccountPayableTV.OrderNumber = AccountPayableTVDistributionDetail.OrderNumber

            AccountPayableTV.DiscountAmount = Math.Abs(AccountPayableTV.DiscountAmount.GetValueOrDefault(0)) * -1

            If AdvantageFramework.Database.Procedures.AccountPayableTV.Insert(ObjectContext, AccountPayableTV) = False Then

                Throw New Exception("Failed to insert AP TV.")

            End If

        End Sub
        Public Function CreateInvoicesFromImport(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, _
                                                 ByVal ImportAccountPayables As Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayable), _
                                                 ByVal PostPeriodCode As String, _
                                                 ByVal Session As AdvantageFramework.Security.Session) As Boolean

            Dim Imported As Boolean = True
            Dim ImportIDs As Generic.List(Of Integer) = Nothing
            Dim ImportID As Integer = Nothing
            Dim ImportAccountPayable As AdvantageFramework.Database.Classes.ImportAccountPayable = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim VendorName As String = Nothing
            Dim GLDescription As String = Nothing
            Dim CreditAmount As Decimal = Nothing
            Dim Remark As String = Nothing
            Dim DbTransaction As System.Data.Common.DbTransaction = Nothing
            Dim ErrorMessage As String = Nothing
            Dim IsBalanced As Integer = -1
            Dim GLSourceCode As String = "IA"
            Dim BatchDate As Date = Now
            Dim ImportAccountPayableEntity As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayable) = Nothing
            Dim ImportAccountPayableGL As AdvantageFramework.Database.Entities.ImportAccountPayableGL = Nothing
            Dim ImportAccountPayableJob As AdvantageFramework.Database.Entities.ImportAccountPayableJob = Nothing
            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
            Dim AccountPayableGLDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableGLDistributionDetail) = Nothing
            Dim AccountPayableInternetDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableInternetDistributionDetail) = Nothing
            Dim AccountPayableMagazineDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableMagazineDistributionDetail) = Nothing
            Dim AccountPayableNewspaperDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableNewspaperDistributionDetail) = Nothing
            Dim AccountPayableOutOfHomeDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableOutOfHomeDistributionDetail) = Nothing
            Dim AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableProductionDistributionDetail) = Nothing
            Dim AccountPayableRadioDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableRadioDistributionDetail) = Nothing
            Dim AccountPayableTVDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableTVDistributionDetail) = Nothing

            Try

                ImportIDs = ImportAccountPayables.Select(Function(IAP) IAP.ID).Distinct.ToList()

                For Each ImportID In ImportIDs

                    AccountPayableGLDistributionDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableGLDistributionDetail)
                    AccountPayableInternetDistributionDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableInternetDistributionDetail)
                    AccountPayableMagazineDistributionDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableMagazineDistributionDetail)
                    AccountPayableNewspaperDistributionDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableNewspaperDistributionDetail)
                    AccountPayableOutOfHomeDistributionDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableOutOfHomeDistributionDetail)
                    AccountPayableProductionDistributionDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableProductionDistributionDetail)
                    AccountPayableRadioDistributionDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableRadioDistributionDetail)
                    AccountPayableTVDistributionDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableTVDistributionDetail)

                    ImportAccountPayable = ImportAccountPayables.Where(Function(IAP) IAP.ID = ImportID).FirstOrDefault

                    AccountPayable = CreateAccountPayable(ObjectContext, ImportAccountPayable, PostPeriodCode)

                    If AccountPayable IsNot Nothing Then

                        ImportAccountPayableList = ImportAccountPayables.Where(Function(IAP) IAP.ID = ImportID).ToList

                        For Each ImportAccountPayable In ImportAccountPayableList

                            If TypeOf (ImportAccountPayable.GetDetail) Is AdvantageFramework.Database.Entities.ImportAccountPayableGL Then

                                ImportAccountPayableGL = CType(ImportAccountPayable.GetDetail, AdvantageFramework.Database.Entities.ImportAccountPayableGL)
                                AccountPayableGLDistributionDetailList.Add(New AdvantageFramework.Database.Classes.AccountPayableGLDistributionDetail(ImportAccountPayableGL))

                            ElseIf TypeOf (ImportAccountPayable.GetDetail) Is AdvantageFramework.Database.Entities.ImportAccountPayableJob Then

                                ImportAccountPayableJob = CType(ImportAccountPayable.GetDetail, AdvantageFramework.Database.Entities.ImportAccountPayableJob)
                                AccountPayableProductionDistributionDetailList.Add(New AdvantageFramework.Database.Classes.AccountPayableProductionDistributionDetail(ObjectContext, ImportAccountPayableJob, Session))

                            ElseIf TypeOf (ImportAccountPayable.GetDetail) Is AdvantageFramework.Database.Entities.ImportAccountPayableMedia Then

                                ImportAccountPayableMedia = CType(ImportAccountPayable.GetDetail, AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

                                Select Case ImportAccountPayableMedia.MediaType

                                    Case "I"

                                        AccountPayableInternetDistributionDetailList.Add(New AdvantageFramework.Database.Classes.AccountPayableInternetDistributionDetail(ObjectContext, ImportAccountPayableMedia))

                                    Case "M"

                                        AccountPayableMagazineDistributionDetailList.Add(New AdvantageFramework.Database.Classes.AccountPayableMagazineDistributionDetail(ObjectContext, ImportAccountPayableMedia))

                                    Case "N"

                                        AccountPayableNewspaperDistributionDetailList.Add(New AdvantageFramework.Database.Classes.AccountPayableNewspaperDistributionDetail(ObjectContext, ImportAccountPayableMedia))

                                    Case "O"

                                        AccountPayableOutOfHomeDistributionDetailList.Add(New AdvantageFramework.Database.Classes.AccountPayableOutOfHomeDistributionDetail(ObjectContext, ImportAccountPayableMedia))

                                    Case "R"

                                        AccountPayableRadioDistributionDetailList.Add(New AdvantageFramework.Database.Classes.AccountPayableRadioDistributionDetail(ObjectContext, ImportAccountPayableMedia))

                                    Case "T"

                                        AccountPayableTVDistributionDetailList.Add(New AdvantageFramework.Database.Classes.AccountPayableTVDistributionDetail(ObjectContext, ImportAccountPayableMedia))

                                End Select

                            End If

                        Next

                        VendorName = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(ObjectContext, AccountPayable.VendorCode).Name

                        Try

                            ObjectContext.Connection.Open()

                            DbTransaction = ObjectContext.Connection.BeginTransaction

                            AccountPayable.ObjectContext = ObjectContext

                            GLDescription = "VN:" & AccountPayable.VendorCode & "-" & VendorName & ",Inv:" & AccountPayable.InvoiceNumber
                            If AdvantageFramework.AccountPayable.InsertGeneralLedger(GeneralLedger, ObjectContext, AccountPayable.PostPeriodCode, ObjectContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                                Throw New Exception("Failed trying to save data to General Ledger.")

                            End If

                            CreditAmount = (AccountPayable.InvoiceAmount + AccountPayable.ShippingAmount + AccountPayable.SalesTaxAmount) * -1
                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayable.InvoiceDescription
                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GeneralLedger.Transaction, AccountPayable.GLACode, CreditAmount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Failed trying to save data to General Ledger Detail.")

                            End If

                            AccountPayable.GLTransaction = GeneralLedger.Transaction
                            AccountPayable.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

                            If AdvantageFramework.Database.Procedures.AccountPayable.Insert(ObjectContext, AccountPayable) = False Then

                                Throw New Exception("Insert to AP Header failed.")

                            End If

                            InsertNonClient(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableGLDistributionDetailList, GLSourceCode, False)

                            InsertProduction(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableProductionDistributionDetailList, GLSourceCode, False)

                            InsertMagazine(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableMagazineDistributionDetailList, GLSourceCode)

                            InsertNewspaper(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableNewspaperDistributionDetailList, GLSourceCode)

                            InsertInternet(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableInternetDistributionDetailList, GLSourceCode)

                            InsertOutOfHome(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableOutOfHomeDistributionDetailList, GLSourceCode)

                            InsertRadio(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableRadioDistributionDetailList, GLSourceCode)

                            InsertTV(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableTVDistributionDetailList, GLSourceCode)

                            IsBalanced = ObjectContext.ExecuteStoreQuery(Of Integer)(String.Format("exec [advsp_ap_invoice_balanced] {0}, {1}", AccountPayable.ID, GeneralLedger.Transaction)).FirstOrDefault

                            If IsBalanced = 1 Then

                                ImportAccountPayableEntity = AdvantageFramework.Database.Procedures.ImportAccountPayable.LoadByID(ObjectContext, ImportAccountPayable.ID)

                                AdvantageFramework.Database.Procedures.ImportAccountPayable.Delete(ObjectContext, ImportAccountPayableEntity)

                                DbTransaction.Commit()

                            Else

                                Throw New Exception("Cannot save.  Invoice out of balance.")

                            End If

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            Imported = False
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                            ErrorMessage += vbCrLf & ex.Message
                            'ErrorMessage += vbCrLf & vbCrLf & ex.StackTrace
                        Finally

                            If ObjectContext.Connection.State = ConnectionState.Open Then

                                ObjectContext.Connection.Close()

                            End If

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
            Finally
                CreateInvoicesFromImport = Imported
            End Try

        End Function
        Public Function CreateInvoicesFromExpenseReportImport(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, _
                                                              ByVal AccountPayableExpenseReportItems As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableExpenseReportItem), _
                                                              ByVal PostPeriodCode As String, _
                                                              ByVal Session As AdvantageFramework.Security.Session) As Boolean

            Dim Imported As Boolean = True
            Dim InvoiceNumbers As Generic.List(Of Integer) = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim VendorName As String = Nothing
            Dim GLDescription As String = Nothing
            Dim CreditAmount As Decimal = Nothing
            Dim Remark As String = Nothing
            Dim DbTransaction As System.Data.Common.DbTransaction = Nothing
            Dim ErrorMessage As String = Nothing
            Dim IsBalanced As Integer = -1
            Dim GLSourceCode As String = "AP"
            Dim BatchDate As Date = Now
            Dim AccountPayableExpenseReportItem As AdvantageFramework.Database.Classes.AccountPayableExpenseReportItem = Nothing
            Dim AccountPayableGLDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableGLDistributionDetail) = Nothing
            Dim AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableProductionDistributionDetail) = Nothing
            Dim AccountPayableExpenseReportItemList As Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableExpenseReportItem) = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            Try

                InvoiceNumbers = AccountPayableExpenseReportItems.Select(Function(Entity) Entity.InvoiceNumber).Distinct.ToList()

                For Each InvoiceNumber In InvoiceNumbers

                    AccountPayableGLDistributionDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableGLDistributionDetail)
                    AccountPayableProductionDistributionDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountPayableProductionDistributionDetail)

                    AccountPayableExpenseReportItem = AccountPayableExpenseReportItems.Where(Function(Entity) Entity.InvoiceNumber = InvoiceNumber).FirstOrDefault

                    AccountPayable = CreateAccountPayable(ObjectContext, AccountPayableExpenseReportItem, PostPeriodCode)

                    If AccountPayable IsNot Nothing Then

                        AccountPayableExpenseReportItemList = AccountPayableExpenseReportItems.Where(Function(Entity) Entity.InvoiceNumber = InvoiceNumber).ToList

                        For Each AccountPayableExpenseReportItem In AccountPayableExpenseReportItemList

                            If AccountPayableExpenseReportItem.JobNumber.GetValueOrDefault(0) <> 0 Then

                                AccountPayableProductionDistributionDetailList.Add(New AdvantageFramework.Database.Classes.AccountPayableProductionDistributionDetail(ObjectContext, AccountPayableExpenseReportItem, Session))

                            Else

                                AccountPayableGLDistributionDetailList.Add(New AdvantageFramework.Database.Classes.AccountPayableGLDistributionDetail(AccountPayableExpenseReportItem))

                            End If

                        Next

                        VendorName = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(ObjectContext, AccountPayable.VendorCode).Name

                        Try

                            ObjectContext.Connection.Open()

                            DbTransaction = ObjectContext.Connection.BeginTransaction

                            AccountPayable.ObjectContext = ObjectContext

                            GLDescription = "VN:" & AccountPayable.VendorCode & "-" & VendorName & ",Inv:" & AccountPayable.InvoiceNumber
                            If AdvantageFramework.AccountPayable.InsertGeneralLedger(GeneralLedger, ObjectContext, AccountPayable.PostPeriodCode, ObjectContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                                Throw New Exception("Failed trying to save data to General Ledger.")

                            End If

                            CreditAmount = (AccountPayable.InvoiceAmount + AccountPayable.ShippingAmount + AccountPayable.SalesTaxAmount) * -1
                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & "-" & AccountPayable.InvoiceDescription
                            If AdvantageFramework.AccountPayable.InsertGeneralLedgerDetail(GeneralLedgerDetail, ObjectContext, GeneralLedger.Transaction, AccountPayable.GLACode, CreditAmount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Failed trying to save data to General Ledger Detail.")

                            End If

                            AccountPayable.GLTransaction = GeneralLedger.Transaction
                            AccountPayable.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

                            If AdvantageFramework.Database.Procedures.AccountPayable.Insert(ObjectContext, AccountPayable) = False Then

                                Throw New Exception("Insert to AP Header failed.")

                            End If

                            InsertNonClient(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableGLDistributionDetailList, GLSourceCode, False)

                            InsertProduction(ObjectContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableProductionDistributionDetailList, GLSourceCode, False)

                            IsBalanced = ObjectContext.ExecuteStoreQuery(Of Integer)(String.Format("exec [advsp_ap_invoice_balanced] {0}, {1}", AccountPayable.ID, GeneralLedger.Transaction)).FirstOrDefault

                            If IsBalanced = 1 Then

                                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(ObjectContext, InvoiceNumber)

                                If ExpenseReport IsNot Nothing AndAlso ExpenseReport.Status <> 4 Then

                                    Throw New Exception("Invoice Number " & InvoiceNumber & " has been altered by another user.")

                                ElseIf ExpenseReport IsNot Nothing Then

                                    ExpenseReport.Status = 2
                                    ObjectContext.UpdateObject(ExpenseReport)
                                    ObjectContext.SaveChanges()

                                ElseIf ExpenseReport Is Nothing Then

                                    Throw New Exception("Invoice Number " & InvoiceNumber & " not found in database.")

                                End If

                                DbTransaction.Commit()

                            Else

                                Throw New Exception("Cannot save.  Invoice out of balance.")

                            End If

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            Imported = False
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                            ErrorMessage += vbCrLf & ex.Message
                            'ErrorMessage += vbCrLf & vbCrLf & ex.StackTrace
                        Finally

                            If ObjectContext.Connection.State = ConnectionState.Open Then

                                ObjectContext.Connection.Close()

                            End If

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
            Finally
                CreateInvoicesFromExpenseReportImport = Imported
            End Try

        End Function
        Private Function CreateAccountPayable(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, _
                                              ByVal AccountPayableExpenseReportItem As AdvantageFramework.Database.Classes.AccountPayableExpenseReportItem,
                                              ByVal PostPeriodCode As String) As AdvantageFramework.Database.Entities.AccountPayable

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorTerm As AdvantageFramework.Database.Entities.VendorTerm = Nothing

            Try

                AccountPayable = New AdvantageFramework.Database.Entities.AccountPayable
                AccountPayable.ObjectContext = ObjectContext

                AccountPayable.Type = "V"

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(ObjectContext, AccountPayableExpenseReportItem.VendorCode)

                AccountPayable.VendorCode = AccountPayableExpenseReportItem.VendorCode
                AccountPayable.InvoiceNumber = AccountPayableExpenseReportItem.InvoiceNumber
                AccountPayable.CreatedDate = Now

                AccountPayable.Is1099Invoice = Vendor.Vendor1099Flag.GetValueOrDefault(0)

                AccountPayable.IsOnHold = 0

                AccountPayable.InvoiceDescription = If(AccountPayableExpenseReportItem.InvoiceDescription Is Nothing, "", AccountPayableExpenseReportItem.InvoiceDescription)

                AccountPayable.OfficeCode = AccountPayableExpenseReportItem.OfficeCode

                AccountPayable.VendorTermCode = Vendor.VendorTermCode

                'If String.IsNullOrEmpty(ImportAccountPayable.OfficeCode) Then

                AccountPayable.GLACode = Vendor.DefaultAPAccount

                'Else

                '    AccountPayable.GLACode = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(ObjectContext, ImportAccountPayable.OfficeCode).AccountsPayableGLACode

                'End If

                AccountPayable.PostPeriodCode = PostPeriodCode

                AccountPayable.InvoiceDate = AccountPayableExpenseReportItem.InvoiceDate

                If Vendor.VendorTermCode IsNot Nothing Then

                    VendorTerm = AdvantageFramework.Database.Procedures.VendorTerm.LoadByVendorTermCode(ObjectContext, Vendor.VendorTermCode)

                    AccountPayable.PaidDate = DateAdd(DateInterval.Day, CDbl(VendorTerm.DaysToPay), AccountPayable.InvoiceDate)

                End If

                AccountPayable.CreatedByUserCode = ObjectContext.UserCode

                AccountPayable.InvoiceAmount = AccountPayableExpenseReportItem.InvoiceTotalNet
                AccountPayable.ShippingAmount = 0
                AccountPayable.SalesTaxAmount = 0
                AccountPayable.DiscountPercentage = 0

            Catch ex As Exception
                AccountPayable = Nothing
            Finally
                CreateAccountPayable = AccountPayable
            End Try

        End Function

#End Region

    End Module

End Namespace