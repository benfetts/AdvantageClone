Namespace Controller.FinanceAndAccounting

    Public Class ClientLatePaymentFeeController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function Insert(AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable, BatchDate As Date, ClientLateFeeInvoice As AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice) As Boolean

            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim IsBalanced As Integer = 0
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetails As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail) = Nothing
            Dim Remark As String = Nothing
            Dim ClientLateFee As AdvantageFramework.Database.Entities.ClientLateFee = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    AccountReceivable.DbContext = DbContext

                    AdvantageFramework.AccountReceivable.CreateARGeneralLedgerEntries(DbContext, "MI", AccountReceivable, BatchDate, False)

                    If AdvantageFramework.Database.Procedures.AccountReceivable.Insert(DbContext, AccountReceivable) = False Then

                        Throw New Exception("Insert to ACCT REC failed.")

                    End If

                    GeneralLedger = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.GeneralLedger).Where(Function(GL) GL.Transaction = AccountReceivable.GLTransaction).SingleOrDefault

                    Remark = "Office:" & AccountReceivable.OfficeCode & " " & IIf(AccountReceivable.RecordType = "P", "Prod", "Media") & " Manual Inv:" &
                        AccountReceivable.InvoiceNumber & " - " & AccountReceivable.Description & "  Client:" & AccountReceivable.ClientCode & "-" & AccountReceivable.DivisionCode & "-" & AccountReceivable.ProductCode

                    GeneralLedger.Description = Mid(Remark, 1, 100)

                    DbContext.UpdateObject(GeneralLedger)

                    GeneralLedgerDetails = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail).Where(Function(GLD) GLD.GLTransaction = AccountReceivable.GLTransaction).ToList

                    For Each GeneralLedgerDetail In GeneralLedgerDetails

                        GeneralLedgerDetail.Remark = Mid(Remark, 1, 150)

                        DbContext.UpdateObject(GeneralLedgerDetail)

                    Next

                    DbContext.SaveChanges()

                    IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_ar_invoice_balanced] {0},{1},'{2}',{3}", AccountReceivable.InvoiceNumber, AccountReceivable.SequenceNumber, AccountReceivable.Type, AccountReceivable.GLTransaction)).FirstOrDefault

                    If IsBalanced = 1 Then

                        ClientLateFee = New AdvantageFramework.Database.Entities.ClientLateFee
                        ClientLateFee.DbContext = DbContext

                        ClientLateFee.OfficeCode = ClientLateFeeInvoice.OfficeCode
                        ClientLateFee.ClientCode = ClientLateFeeInvoice.ClientCode
                        ClientLateFee.DivisionCode = ClientLateFeeInvoice.DivisionCode
                        ClientLateFee.ProductCode = ClientLateFeeInvoice.ProductCode
                        ClientLateFee.PostPeriodCode = AccountReceivable.PostPeriodCode
                        ClientLateFee.ARInvoiceNumber = AccountReceivable.InvoiceNumber
                        ClientLateFee.UserCreated = Session.UserCode
                        ClientLateFee.EmployeeCode = Session.User.EmployeeCode

                        If AdvantageFramework.Database.Procedures.ClientLateFee.Insert(DbContext, ClientLateFee, Nothing) = False Then

                            Throw New Exception("Insert to Client Late Fee failed.")

                        End If

                        DbTransaction.Commit()
                        Inserted = True

                        'AdvantageFramework.WinForm.MessageBox.Show("Invoice '" & AccountReceivable.InvoiceNumber & "' has been added.")

                    Else

                        Throw New Exception("Cannot save.  AR out of balance.")

                    End If

                Catch ex As Exception

                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database.  Please contact software support."
                    ErrorMessage += vbCrLf & ex.Message

                    Inserted = False
                    'Throw ex

                Finally

                    If DbContext.Database.Connection.State = ConnectionState.Open Then

                        DbContext.Database.Connection.Close()

                    End If

                End Try

            End Using

            Insert = Inserted

        End Function

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Sub CalculateLateFees(ByRef ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.ClientLatePaymentFeeViewModel)

            Dim SqlParameterUserID As SqlClient.SqlParameter = Nothing
            Dim SqlParameterPeriodCutoff As SqlClient.SqlParameter = Nothing
            Dim SqlParameterAgingDate As SqlClient.SqlParameter = Nothing
            Dim SqlParameterInvoicePostPeriod As SqlClient.SqlParameter = Nothing

            SqlParameterUserID = New SqlClient.SqlParameter("@UserID", SqlDbType.VarChar)
            SqlParameterPeriodCutoff = New SqlClient.SqlParameter("@PeriodCutoff", SqlDbType.VarChar)
            SqlParameterAgingDate = New SqlClient.SqlParameter("@AgingDate", SqlDbType.SmallDateTime)
            SqlParameterInvoicePostPeriod = New SqlClient.SqlParameter("@InvoicePostPeriod", SqlDbType.VarChar)

            SqlParameterUserID.Value = Session.UserCode
            SqlParameterPeriodCutoff.Value = ViewModel.PostPeriodCode
            SqlParameterAgingDate.Value = ViewModel.AgingDate.ToShortDateString
            SqlParameterInvoicePostPeriod.Value = ViewModel.FeePostPeriodCode

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    ViewModel.ClientLateFeeInvoices = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice)("exec dbo.advsp_client_late_fee_calculate @UserID, @PeriodCutoff, @AgingDate, @InvoicePostPeriod",
                                                    SqlParameterUserID, SqlParameterPeriodCutoff, SqlParameterAgingDate, SqlParameterInvoicePostPeriod).ToList

                    For Each ClientLateFeeInvoice In ViewModel.ClientLateFeeInvoices

                        SetRequiredFields(ClientLateFeeInvoice)

                        Me.ValidateDTO(DbContext, DataContext, ClientLateFeeInvoice, True)

                    Next

                End Using

            End Using

        End Sub
        Public Function IsDateOutsidePostPeriod(ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.ClientLatePaymentFeeViewModel) As Boolean

            Dim IsOutsidePostPeriod As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If AdvantageFramework.AccountPayable.IsDateOutsidePostPeriod(DbContext, ViewModel.FeeInvoiceDate, ViewModel.PostPeriodCode) Then

                    IsOutsidePostPeriod = True

                End If

            End Using

            IsDateOutsidePostPeriod = IsOutsidePostPeriod

        End Function
        Public Function Load() As AdvantageFramework.ViewModels.FinanceAndAccounting.ClientLatePaymentFeeViewModel

            'objects
            Dim ClientLatePaymentFeeViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.ClientLatePaymentFeeViewModel = Nothing

            ClientLatePaymentFeeViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.ClientLatePaymentFeeViewModel

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                'ClientLatePaymentFeeViewModel.AllPostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(PP) PP.Code).ToList

                ClientLatePaymentFeeViewModel.OpenARPostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext).ToList

                ClientLatePaymentFeeViewModel.CurrentARPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentARPostPeriod(DbContext)

            End Using

            Load = ClientLatePaymentFeeViewModel

        End Function
        Public Function Post(ClientLateFeeInvoices As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice),
                             ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.ClientLatePaymentFeeViewModel,
                             BatchDate As Date) As Boolean

            Dim Posted As Boolean = True
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing
            Dim ErrorMessage As String = Nothing
            Dim IsValid As Boolean = True
            Dim Offices As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Offices = DbContext.Offices.ToList

                For Each ClientLateFeeInvoice In ClientLateFeeInvoices

                    AccountReceivable = New AdvantageFramework.Database.Entities.AccountReceivable

                    AccountReceivable.Type = "IN"

                    AccountReceivable.ClientCode = ClientLateFeeInvoice.ClientCode
                    AccountReceivable.DivisionCode = ClientLateFeeInvoice.DivisionCode
                    AccountReceivable.ProductCode = ClientLateFeeInvoice.ProductCode
                    AccountReceivable.OfficeCode = ClientLateFeeInvoice.OfficeCode

                    AccountReceivable.Description = "Late Fee"

                    'AccountReceivable.SalesClassCode = SearchableComboBoxForm_SalesClass.GetSelectedValue
                    AccountReceivable.PostPeriodCode = ViewModel.FeePostPeriodCode
                    AccountReceivable.RecordType = "P"
                    AccountReceivable.InvoiceDate = ViewModel.FeeInvoiceDate
                    AccountReceivable.InvoiceAmount = ClientLateFeeInvoice.LateFee

                    AccountReceivable.GLACodeAR = Offices.Where(Function(Office) Office.Code = ClientLateFeeInvoice.OfficeCode).First.AccountsReceivableGLACode
                    AccountReceivable.GLACodeSales = ClientLateFeeInvoice.LateFeeGLAccount
                    'AccountReceivable.CostOfSalesGLACode = SearchableComboBoxGroup_COSGLACode.GetSelectedValue
                    'AccountReceivable.GLACodeOffset = SearchableComboBoxGroup_OffsetGLACode.GetSelectedValue
                    'AccountReceivable.GLACodeState = SearchableComboBoxGroup_StateTaxGLACode.GetSelectedValue
                    'AccountReceivable.GLACodeCounty = SearchableComboBoxGroup_CountyTaxGLACode.GetSelectedValue
                    'AccountReceivable.GLACodeCity = SearchableComboBoxGroup_CityTaxGLACode.GetSelectedValue

                    AccountReceivable.SaleAmount = ClientLateFeeInvoice.LateFee
                    AccountReceivable.CostOfSalesAmount = 0
                    AccountReceivable.OffsetAmount = 0
                    AccountReceivable.StateAmount = 0
                    AccountReceivable.CountyAmount = 0
                    AccountReceivable.CityAmount = 0
                    AccountReceivable.CommissionAmount = 0

                    AccountReceivable.EmployeeTime = 0
                    AccountReceivable.IOAmount = 0
                    AccountReceivable.IsManualInvoice = 1
                    AccountReceivable.UserCode = Me.Session.UserCode
                    AccountReceivable.CreateDate = Now.ToShortDateString
                    AccountReceivable.AdvanceAmount = 0

                    If AccountReceivable.RecordType = "P" Then

                        AccountReceivable.InvoiceType = 1

                    Else

                        AccountReceivable.InvoiceType = 2

                    End If

                    ErrorMessage = AccountReceivable.ValidateEntity(IsValid)

                    If IsValid Then

                        If Not Insert(AccountReceivable, BatchDate, ClientLateFeeInvoice) Then

                            Posted = False

                        End If

                    Else

                        Posted = False

                    End If

                Next

            End Using

            Post = Posted

        End Function
        Public Overrides Sub SetRequiredFields(ByRef DTO As AdvantageFramework.DTO.BaseClass)

            'objects
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(DTO).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            If DTO.GetType.Equals(GetType(AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice)) Then

                For Each PropertyDescriptor In PropertyDescriptors

                    Select Case PropertyDescriptor.Name

                        Case AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice.Properties.DivisionCode.ToString

                            DTO.SetRequired(PropertyDescriptor, DirectCast(DTO, AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice).LateFeeLevel = "P")

                        Case AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice.Properties.ProductCode.ToString

                            DTO.SetRequired(PropertyDescriptor, DirectCast(DTO, AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice).LateFeeLevel = "P")

                    End Select

                Next

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext, ByRef DTO As DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim ClientLateFeeInvoice As AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice = Nothing

            If PropertyName = AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice.Properties.LateFeeGLAccount.ToString Then

                ClientLateFeeInvoice = DTO

                PropertyValue = Value

                If String.IsNullOrWhiteSpace(PropertyValue) Then

                    ErrorText = "Please setup client late payment fees GL in office maintenance."
                    IsValid = False

                End If

            ElseIf PropertyName = AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice.Properties.PostPeriod.ToString Then

                ClientLateFeeInvoice = DTO

                PropertyValue = Value

                If (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext)
                    Where Entity.Code = DirectCast(PropertyValue, String)
                    Select Entity).Any = False Then

                    ErrorText = "Cannot post to a closed period."
                    IsValid = False

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function

#End Region

#End Region

    End Class

End Namespace
