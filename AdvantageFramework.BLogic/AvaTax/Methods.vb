Namespace AvaTax

    <HideModuleName()>
    Public Module Methods

        Public Event AvaTaxProgressUpdateEvent(ByVal ProgressValue As Integer)
        Public Event SetupAvaTaxProgressEvent(ByVal MinValue As Integer, ByVal MaxValue As Integer, ByVal Value As Integer)

#Region " Constants "

        Private Const CLIENT As String = "Advantage"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function PingTest(ByVal TaxService As AdvantageFramework.AvaTax.API.TaxService, ByRef Result As String) As Boolean

            Dim GeoTaxResult As AdvantageFramework.AvaTax.API.GeoTaxResult = Nothing
            Dim PingSuccess As Boolean = False

            GeoTaxResult = TaxService.Ping()

            If GeoTaxResult IsNot Nothing Then

                Result = GeoTaxResult.ResultCode.ToString()

                If Not GeoTaxResult.ResultCode.Equals(AdvantageFramework.AvaTax.API.SeverityLevel.Success) Then

                    For Each Message As AdvantageFramework.AvaTax.API.Message In GeoTaxResult.Messages

                        Result += vbCrLf & Message.Summary

                    Next

                Else

                    PingSuccess = True

                End If

            Else

                Result = AdvantageFramework.AvaTax.API.SeverityLevel.Error.ToString

            End If

            PingTest = PingSuccess

        End Function
        Public Function PingTest(ByVal AccountNumber As String, ByVal LicenseKey As String, ByVal ServiceURL As String, ByRef Result As String) As Boolean

            Dim TaxService As AdvantageFramework.AvaTax.API.TaxService = Nothing
            Dim PingSuccess As Boolean = False

            If AccountNumber Is Nothing OrElse LicenseKey Is Nothing OrElse ServiceURL Is Nothing Then

                Result = "AvaTax is not configured properly."

            Else

                TaxService = New AdvantageFramework.AvaTax.API.TaxService(AccountNumber, LicenseKey, ServiceURL)

                PingSuccess = PingTest(TaxService, Result)

            End If

            PingTest = PingSuccess

        End Function
        Public Function ValidateAddress(ByVal Session As AdvantageFramework.Security.Session, ByVal Address As AdvantageFramework.AvaTax.API.Address,
                                        ByRef ValidatedAddress As AdvantageFramework.AvaTax.API.Address, ByRef MessageString As String) As Boolean

            Dim AddressService As AdvantageFramework.AvaTax.API.AddressService = Nothing
            Dim ValidateResult As AdvantageFramework.AvaTax.API.ValidateResult = Nothing
            Dim IsValid As Boolean = False

            AddressService = New AdvantageFramework.AvaTax.API.AddressService(Session)

            ValidateResult = AddressService.Validate(Address)

            If Not ValidateResult.ResultCode.Equals(AdvantageFramework.AvaTax.API.SeverityLevel.Success) Then

                For Each Message As AdvantageFramework.AvaTax.API.Message In ValidateResult.Messages

                    MessageString += vbCrLf & Message.Summary & ": " & Message.Details

                Next

            Else

                IsValid = True

                ValidatedAddress = ValidateResult.Address

                MessageString += vbCrLf & "Address 1: " & ValidateResult.Address.Line1 &
                                 vbCrLf & "Address 2: " & ValidateResult.Address.Line2 &
                                 vbCrLf & "City: " & ValidateResult.Address.City &
                                 vbCrLf & "County: " & ValidateResult.Address.County &
                                 vbCrLf & "State: " & ValidateResult.Address.Region &
                                 vbCrLf & "Zip: " & ValidateResult.Address.PostalCode &
                                 vbCrLf & "Country: " & ValidateResult.Address.Country

            End If

            ValidateAddress = IsValid

        End Function
        Private Sub GetAvaTaxInvoiceList(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingUserCode As String,
                                         ByRef AvaTaxInvoiceList As Generic.List(Of AdvantageFramework.AvaTax.Classes.AvaTaxInvoice),
                                         ByRef InvoiceDate As Date, ByVal Post As Boolean, ByVal ArInvoiceNumbers As String)

            Dim BillingCommandCenterInvoiceDatePostPeriod As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod = Nothing
            Dim Functions As IEnumerable(Of String) = Nothing

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                BillingCommandCenterInvoiceDatePostPeriod = AdvantageFramework.BillingCommandCenter.GetBillingCommandCenterInvoiceDatePostPeriod(BCCDbContext, BillingUserCode)

            End Using

            If BillingCommandCenterInvoiceDatePostPeriod Is Nothing Then

                Throw New Exception("Cannot find invoice date for billing selection.")

            Else

                InvoiceDate = BillingCommandCenterInvoiceDatePostPeriod.InvoiceDate.Value

            End If

            AvaTaxInvoiceList = DbContext.Database.SqlQuery(Of AdvantageFramework.AvaTax.Classes.AvaTaxInvoice)(String.Format("exec advsp_bcc_process_avatax '{0}', {1}, {2}",
                                                                                                                                  BillingUserCode, If(Post, 1, 0), If(ArInvoiceNumbers Is Nothing, "NULL", "'" & ArInvoiceNumbers & "'"))).ToList

            If AvaTaxInvoiceList.Where(Function(ATI) String.IsNullOrWhiteSpace(ATI.AvaTaxCompanyCode) = True).Any Then

                Throw New Exception("One or more office(s) with empty AvaTax company code.")

            End If

            If AvaTaxInvoiceList.Where(Function(ATI) ATI.AvaTaxCode Is Nothing).Any Then

                Functions = AvaTaxInvoiceList.Where(Function(ATI) ATI.AvaTaxCode Is Nothing).Select(Function(ATI) ATI.FunctionCode).Distinct.ToList()

                Throw New Exception("One or more functions not mapped in Avalara Product Mapping." & vbCrLf & vbCrLf & "(" & String.Join(", ", Functions) & ")")

            End If

        End Sub
        Public Sub CalculateAvaTax(ByVal ConnectionString As String, ByVal UserCode As String, ByVal BillingUserCode As String)

            Dim TaxService As AdvantageFramework.AvaTax.API.TaxService = Nothing
            Dim AvaTaxInvoiceList As Generic.List(Of AdvantageFramework.AvaTax.Classes.AvaTaxInvoice) = Nothing
            Dim InvoiceDate As Date = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim InvoiceNumbers As IEnumerable(Of String) = Nothing
            Dim ProgressValue As Integer = 0

            Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                TaxService = New AdvantageFramework.AvaTax.API.TaxService(DbContext)

                GetAvaTaxInvoiceList(DbContext, BillingUserCode, AvaTaxInvoiceList, InvoiceDate, False, Nothing)

                ' only send those rows that need to be calculated
                AvaTaxInvoiceList = AvaTaxInvoiceList.Where(Function(WAR) WAR.IsAvaTaxCalculated = False).ToList

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                InvoiceNumbers = (From ATI In AvaTaxInvoiceList
                                  Select ATI.InvoiceNumber).Distinct.ToList

                RaiseEvent SetupAvaTaxProgressEvent(0, If(InvoiceNumbers.Count <= 1, 1, InvoiceNumbers.Count - 1), 0)

                For Each InvoiceNumber In InvoiceNumbers

                    RaiseEvent AvaTaxProgressUpdateEvent(ProgressValue)

                    CalculatePostAvaTax(DbContext, TaxService,
                                        AvaTaxInvoiceList.Where(Function(ATI) ATI.InvoiceNumber = InvoiceNumber).ToList,
                                        InvoiceDate, Agency, False)

                    ProgressValue += 1

                Next

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.W_AR_FUNCTION SET TOTAL_BILL = ( COALESCE( EMP_TIME_AMT, 0.00 ) + COALESCE( INC_ONLY_AMT, 0.00 ) + COALESCE( COMMISSION_AMT, 0.00 ) + COALESCE( COST_AMT, 0.00 ) + COALESCE( AB_COST_AMT, 0.00 ) + COALESCE( AB_INC_AMT, 0.00 ) + COALESCE( AB_COMMISSION_AMT, 0.00 ) + COALESCE( AB_SALE_AMT, 0.00 ) + COALESCE( STATE_TAX_AMT, 0.00 ) + COALESCE( CNTY_TAX_AMT, 0.00 ) + COALESCE( CITY_TAX_AMT, 0.00 ) + COALESCE( NON_RESALE_AMT, 0.00 ) + COALESCE( AB_NONRESALE_AMT, 0.00 )) WHERE BILLING_USER = '{0}' AND FNC_TYPE IS NOT NULL", BillingUserCode))

            End Using

        End Sub
        Private Function CalculatePostAvaTax(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal TaxService As AdvantageFramework.AvaTax.API.TaxService,
                                             ByVal AvaTaxInvoiceList As Generic.List(Of AdvantageFramework.AvaTax.Classes.AvaTaxInvoice),
                                             ByVal InvoiceDate As Date,
                                             ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                             ByVal Post As Boolean) As Boolean

            Dim GetTaxRequest As AdvantageFramework.AvaTax.API.GetTaxRequest = Nothing
            Dim OriginAddress As AdvantageFramework.AvaTax.API.Address = Nothing
            Dim DestinationAddress As AdvantageFramework.AvaTax.API.Address = Nothing
            Dim LineList As Generic.List(Of AdvantageFramework.AvaTax.API.Line) = Nothing
            Dim Line As AdvantageFramework.AvaTax.API.Line = Nothing
            Dim LineCounter As Integer = 0
            Dim GetTaxResult As AdvantageFramework.AvaTax.API.GetTaxResult = Nothing
            Dim StateAmount As Decimal = 0
            Dim StatePercent As Decimal = 0
            Dim CountyAmount As Decimal = 0
            Dim CountyPercent As Decimal = 0
            Dim CityAmount As Decimal = 0
            Dim CityPercent As Decimal = 0
            Dim ErrorMessage As String = ""
            Dim CalculatePost As Boolean = False
            Dim BillingAddress As String = Nothing

            GetTaxRequest = New AdvantageFramework.AvaTax.API.GetTaxRequest()

            ' Document Level Elements
            ' Required Request Parameters
            GetTaxRequest.CustomerCode = AvaTaxInvoiceList.FirstOrDefault.ClientCode
            GetTaxRequest.DocDate = InvoiceDate.ToString("yyyy-MM-dd")

            ' Best Practice Request Parameters
            GetTaxRequest.CompanyCode = AvaTaxInvoiceList.FirstOrDefault.AvaTaxCompanyCode

            GetTaxRequest.Client = CLIENT
            GetTaxRequest.DetailLevel = AdvantageFramework.AvaTax.API.DetailLevel.Tax

            If Not Post Then

                GetTaxRequest.DocType = AdvantageFramework.AvaTax.API.DocType.SalesOrder    ' SalesOrder will not create an admin record, DocType.SalesInvoice will
                GetTaxRequest.Commit = False

            Else

                GetTaxRequest.DocType = AdvantageFramework.AvaTax.API.DocType.SalesInvoice     ' SalesOrder will not create an admin record, DocType.SalesInvoice will
                GetTaxRequest.Commit = True
                GetTaxRequest.DocCode = AvaTaxInvoiceList.FirstOrDefault.InvoiceNumber

            End If

            If AvaTaxInvoiceList.FirstOrDefault.TaxExempt Then

                GetTaxRequest.ExemptionNo = "EX"

            End If

            ' Origin Address Data
            OriginAddress = New AdvantageFramework.AvaTax.API.Address
            OriginAddress.AddressCode = "orig"
            OriginAddress.Line1 = Agency.Address
            OriginAddress.City = Agency.City
            OriginAddress.Region = Agency.State
            OriginAddress.PostalCode = Agency.Zip

            DestinationAddress = New AdvantageFramework.AvaTax.API.Address
            DestinationAddress.AddressCode = "dest"
            DestinationAddress.Line1 = AvaTaxInvoiceList.FirstOrDefault.BillingAddress
            DestinationAddress.City = AvaTaxInvoiceList.FirstOrDefault.BillingCity
            DestinationAddress.Region = AvaTaxInvoiceList.FirstOrDefault.BillingState
            DestinationAddress.PostalCode = AvaTaxInvoiceList.FirstOrDefault.BillingZip
            DestinationAddress.Country = AvaTaxInvoiceList.FirstOrDefault.BillingCountry

            BillingAddress = Replace(AvaTaxInvoiceList.FirstOrDefault.BillingAddress & "|" & AvaTaxInvoiceList.FirstOrDefault.BillingCity & "|" & AvaTaxInvoiceList.FirstOrDefault.BillingState & "|" & AvaTaxInvoiceList.FirstOrDefault.BillingZip, "'", "")

            GetTaxRequest.Addresses = {OriginAddress, DestinationAddress}

            LineList = New Generic.List(Of AdvantageFramework.AvaTax.API.Line)

            For Each AvaTaxInvoice In AvaTaxInvoiceList

                LineCounter += 1

                Line = New AdvantageFramework.AvaTax.API.Line

                If Not Post Then

                    Line.LineNo = AvaTaxInvoice.ID

                Else

                    Line.LineNo = LineCounter

                End If

                Line.DestinationCode = "dest"
                Line.OriginCode = "orig"
                Line.TaxCode = AvaTaxInvoice.AvaTaxCode
                Line.ItemCode = AvaTaxInvoice.FunctionCode
                Line.Description = AvaTaxInvoice.FunctionDescription
                Line.Qty = AvaTaxInvoice.HoursQuantity
                Line.Amount = AvaTaxInvoice.Amount

                LineList.Add(Line)

            Next

            GetTaxRequest.Lines = LineList.ToArray

            GetTaxResult = TaxService.GetTax(GetTaxRequest)

            If GetTaxResult.ResultCode.Equals(AdvantageFramework.AvaTax.API.SeverityLevel.Success) Then

                For Each TaxLine In If(GetTaxResult.TaxLines, Enumerable.Empty(Of AdvantageFramework.AvaTax.API.TaxLine)())

                    If Not Post Then

                        StateAmount = 0
                        StatePercent = 0
                        CountyAmount = 0
                        CountyPercent = 0
                        CityAmount = 0
                        CityPercent = 0

                        For Each TaxDetail In If(TaxLine.TaxDetails, Enumerable.Empty(Of AdvantageFramework.AvaTax.API.TaxDetail)())

                            Select Case TaxDetail.JurisType

                                Case "State"

                                    StateAmount += If(GetTaxRequest.ExemptionNo = "EX", 0, TaxDetail.Tax)
                                    StatePercent = If(GetTaxRequest.ExemptionNo = "EX" OrElse TaxDetail.Tax = 0, 0, TaxDetail.Rate * 100)

                                Case "County"

                                    CountyAmount += If(GetTaxRequest.ExemptionNo = "EX", 0, TaxDetail.Tax)
                                    CountyPercent = If(GetTaxRequest.ExemptionNo = "EX" OrElse TaxDetail.Tax = 0, 0, TaxDetail.Rate * 100)

                                Case Else 'City and various 'Special' taxes all go to City bucket

                                    CityAmount += If(GetTaxRequest.ExemptionNo = "EX", 0, TaxDetail.Tax)
                                    CityPercent = If(GetTaxRequest.ExemptionNo = "EX" OrElse TaxDetail.Tax = 0, 0, TaxDetail.Rate * 100)

                            End Select

                        Next

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.W_AR_FUNCTION SET AVATAX_CALCULATED = 1, CITY_TAX_AMT = {1}, TAX_CITY_PCT = {2}, CNTY_TAX_AMT = {3}, TAX_COUNTY_PCT = {4}, STATE_TAX_AMT = {5}, TAX_STATE_PCT = {6}, BILLING_ADDRESS = '{7}' WHERE AR_FUNCTION_ID = {0}", TaxLine.LineNo, CityAmount, CityPercent, CountyAmount, CountyPercent, StateAmount, StatePercent, BillingAddress))

                    Else

                        If GetTaxRequest.DocCode.Contains("-") Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AR_SUMMARY SET AVATAX_POSTED = 1 WHERE AR_INV_NBR = {0} AND AR_INV_SEQ = {1}", Mid(GetTaxRequest.DocCode, 1, InStr(GetTaxRequest.DocCode, "-") - 1), Mid(GetTaxRequest.DocCode, InStr(GetTaxRequest.DocCode, "-") + 1)))

                        Else

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AR_SUMMARY SET AVATAX_POSTED = 1 WHERE AR_INV_NBR = {0}", GetTaxRequest.DocCode))

                        End If

                    End If

                Next

                CalculatePost = True

            ElseIf Not Post Then

                For Each Message As AdvantageFramework.AvaTax.API.Message In GetTaxResult.Messages

                    ErrorMessage += Message.Summary

                Next

                ErrorMessage += vbCrLf & "Client: " & AvaTaxInvoiceList.FirstOrDefault.ClientCode & " Division: " & AvaTaxInvoiceList.FirstOrDefault.DivisionCode & " Product: " & AvaTaxInvoiceList.FirstOrDefault.ProductCode & " ID: " & AvaTaxInvoiceList.FirstOrDefault.ID

                Throw New Exception(ErrorMessage)

            End If

            CalculatePostAvaTax = CalculatePost

        End Function
        'Public Function DeleteInvoice(ByVal TaxService As AdvantageFramework.AvaTax.API.TaxService, ByVal CompanyCode As String, ByVal DocCode As String) As Boolean

        '    Dim Result As String = Nothing
        '    Dim CancelTaxRequest As AdvantageFramework.AvaTax.API.CancelTaxRequest = Nothing
        '    Dim CancelTaxResult As AdvantageFramework.AvaTax.API.CancelTaxResult = Nothing
        '    Dim Deleted As Boolean = True

        '    CancelTaxRequest = New AdvantageFramework.AvaTax.API.CancelTaxRequest

        '    CancelTaxRequest.CompanyCode = CompanyCode
        '    CancelTaxRequest.DocCode = DocCode
        '    CancelTaxRequest.DocType = API.DocType.SalesInvoice

        '    CancelTaxRequest.CancelCode = AdvantageFramework.AvaTax.API.CancelCode.DocDeleted

        '    CancelTaxResult = TaxService.CancelTax(CancelTaxRequest)

        '    If Not CancelTaxResult.ResultCode.Equals(AdvantageFramework.AvaTax.API.SeverityLevel.Success) Then

        '        Deleted = False

        '        For Each Message As AdvantageFramework.AvaTax.API.Message In CancelTaxResult.Messages

        '            If Message.Summary = "The tax document could not be found." Then

        '                Deleted = True

        '            End If

        '        Next

        '    End If

        '    DeleteInvoice = Deleted

        'End Function
        Public Function PostAvaTax(ByVal ConnectionString As String, ByVal UserCode As String, ByVal BillingUserCode As String, ByRef ErrorMessage As String) As Short

            Dim TaxService As AdvantageFramework.AvaTax.API.TaxService = Nothing
            Dim AvaTaxInvoiceList As Generic.List(Of AdvantageFramework.AvaTax.Classes.AvaTaxInvoice) = Nothing
            Dim InvoiceDate As Date = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AssignInvoices As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.AssignInvoices) = Nothing
            Dim ARInvoiceNumbers As String = Nothing
            Dim InvoiceNumbers As IEnumerable(Of String) = Nothing
            Dim ProgressValue As Integer = 0
            Dim ReturnValue As Integer = -20
            Dim FailedOnce As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                TaxService = New AdvantageFramework.AvaTax.API.TaxService(DbContext)

                GetAvaTaxInvoiceList(DbContext, BillingUserCode, AvaTaxInvoiceList, InvoiceDate, False, Nothing)

                If AvaTaxInvoiceList.Where(Function(WAR) WAR.IsAvaTaxCalculated = False).Any Then

                    Throw New Exception("One or more invoices needs AvaTax calculated before posting.")

                End If

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(ConnectionString, UserCode)

                    AssignInvoices = AdvantageFramework.BillingCommandCenter.AssignInvoices(BCCDbContext, BillingUserCode)

                End Using

                If AssignInvoices IsNot Nothing AndAlso AssignInvoices.FirstOrDefault.ReturnValue = 0 Then

                    ReturnValue = 0

                    Try

                        ARInvoiceNumbers = String.Join(",", AssignInvoices.Select(Function(AI) CStr(AI.ARInvoiceNumber)).ToArray())

                        GetAvaTaxInvoiceList(DbContext, BillingUserCode, AvaTaxInvoiceList, InvoiceDate, True, ARInvoiceNumbers)

                        InvoiceNumbers = (From ATI In AvaTaxInvoiceList
                                          Select ATI.InvoiceNumber).Distinct.ToList

                        RaiseEvent SetupAvaTaxProgressEvent(0, If(InvoiceNumbers.Count <= 1, 1, InvoiceNumbers.Count - 1), 0)

                        For Each InvoiceNumber In InvoiceNumbers

                            RaiseEvent AvaTaxProgressUpdateEvent(ProgressValue)

                            If CalculatePostAvaTax(DbContext, TaxService,
                                                   AvaTaxInvoiceList.Where(Function(ATI) ATI.InvoiceNumber = InvoiceNumber).ToList,
                                                   InvoiceDate, Agency, True) = False Then

                                FailedOnce = True

                            End If

                            ProgressValue += 1

                        Next

                        If FailedOnce Then

                            ErrorMessage = "  "

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                ElseIf AssignInvoices IsNot Nothing Then

                    ReturnValue = AssignInvoices.FirstOrDefault.ReturnValue

                End If

            End Using

            PostAvaTax = ReturnValue

        End Function
        Public Function VoidInvoice(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InvoiceNumber As Integer) As Boolean

            Dim TaxService As AdvantageFramework.AvaTax.API.TaxService = Nothing
            Dim CancelTaxRequest As AdvantageFramework.AvaTax.API.CancelTaxRequest = Nothing
            Dim CancelTaxResult As AdvantageFramework.AvaTax.API.CancelTaxResult = Nothing
            Dim Voided As Boolean = True
            Dim CompanyCode As String = Nothing

            Try

                TaxService = New AdvantageFramework.AvaTax.API.TaxService(DbContext)

                For Each ARSummary In (From ARS In AdvantageFramework.Database.Procedures.AccountReceivableSummary.Load(DbContext)
                                       Where ARS.ARInvoiceNumber = InvoiceNumber AndAlso
                                             ARS.ARInvoiceSequence <> 99
                                       Select ARS.ARInvoiceNumber, ARS.ARInvoiceSequence, ARS.OfficeCode).Distinct.ToList

                    Try

                        CompanyCode = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, ARSummary.OfficeCode).AvaTaxCompanyCode

                    Catch ex As Exception
                        CompanyCode = Nothing
                    End Try

                    If CompanyCode IsNot Nothing Then

                        CancelTaxRequest = New AdvantageFramework.AvaTax.API.CancelTaxRequest

                        CancelTaxRequest.CompanyCode = CompanyCode

                        If ARSummary.ARInvoiceSequence.Value = 0 Then

                            CancelTaxRequest.DocCode = ARSummary.ARInvoiceNumber.Value.ToString

                        Else

                            CancelTaxRequest.DocCode = ARSummary.ARInvoiceNumber.Value.ToString & "-" & ARSummary.ARInvoiceSequence.Value.ToString

                        End If

                        CancelTaxRequest.DocType = API.DocType.SalesInvoice

                        CancelTaxRequest.CancelCode = AdvantageFramework.AvaTax.API.CancelCode.DocVoided

                        CancelTaxResult = TaxService.CancelTax(CancelTaxRequest)

                        If Not CancelTaxResult.ResultCode.Equals(AdvantageFramework.AvaTax.API.SeverityLevel.Success) Then

                            Voided = False

                        End If

                    Else

                        Voided = False

                    End If

                Next

            Catch ex As Exception
                Voided = False
            End Try

            VoidInvoice = Voided

        End Function
        Public Function PostFailedARSummaryToAvaTax(ByVal Session As AdvantageFramework.Security.Session,
                                                    ByVal AvaTaxInvoiceList As Generic.List(Of AdvantageFramework.AvaTax.Classes.AvaTaxInvoice)) As Boolean

            Dim TaxService As AdvantageFramework.AvaTax.API.TaxService = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim ARInvoiceNumbers As String = Nothing
            Dim InvoiceNumbers As IEnumerable(Of String) = Nothing
            Dim ProgressValue As Integer = 0
            Dim FailedOnce As Boolean = False
            Dim InvoiceDate As Date = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                TaxService = New AdvantageFramework.AvaTax.API.TaxService(DbContext)

                If AvaTaxInvoiceList.Where(Function(WAR) WAR.IsAvaTaxCalculated = False).Any Then

                    Throw New Exception("One or more invoices needs AvaTax calculated before posting.")

                End If

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                Try

                    InvoiceNumbers = (From ATI In AvaTaxInvoiceList
                                      Select ATI.InvoiceNumber).Distinct.ToList

                    RaiseEvent SetupAvaTaxProgressEvent(0, If(InvoiceNumbers.Count <= 1, 1, InvoiceNumbers.Count - 1), 0)

                    For Each InvoiceNumber In InvoiceNumbers

                        'RaiseEvent AvaTaxProgressUpdateEvent(ProgressValue)

                        InvoiceDate = AvaTaxInvoiceList.Where(Function(ATI) ATI.InvoiceNumber = InvoiceNumber).FirstOrDefault.InvoiceDate

                        If CalculatePostAvaTax(DbContext, TaxService,
                                               AvaTaxInvoiceList.Where(Function(ATI) ATI.InvoiceNumber = InvoiceNumber).ToList,
                                               InvoiceDate, Agency, True) = False Then

                            FailedOnce = True

                        End If

                        ProgressValue += 1

                    Next

                Catch ex As Exception
                    FailedOnce = True
                End Try

            End Using

            PostFailedARSummaryToAvaTax = Not FailedOnce

        End Function

#End Region

    End Module

End Namespace
