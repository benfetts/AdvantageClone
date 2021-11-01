Public Class APIDbContext
	Inherits System.Data.Entity.DbContext

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Overridable Property BillingCoops() As System.Data.Entity.DbSet(Of BillingCoop)
    Public Overridable Property Employees() As System.Data.Entity.DbSet(Of Employee)
	Public Overridable Property Jobs() As System.Data.Entity.DbSet(Of Job)
	Public Overridable Property JobComponents() As System.Data.Entity.DbSet(Of JobComponent)
	Public Overridable Property DepartmentTeams() As System.Data.Entity.DbSet(Of DepartmentTeam)
	Public Overridable Property Functions() As System.Data.Entity.DbSet(Of [Function])
	Public Overridable Property IndirectCategories() As System.Data.Entity.DbSet(Of IndirectCategory)
	Public Overridable Property Users() As System.Data.Entity.DbSet(Of User)
	Public Overridable Property PostPeriods() As System.Data.Entity.DbSet(Of PostPeriod)
	Public Overridable Property UserSettings() As System.Data.Entity.DbSet(Of UserSetting)
	Public Overridable Property EmployeeDepartmentTeams() As System.Data.Entity.DbSet(Of EmployeeDepartmentTeam)
	Public Overridable Property VendorContacts() As System.Data.Entity.DbSet(Of VendorContact)
	Public Overridable Property Products() As System.Data.Entity.DbSet(Of Product)
    Public Overridable Property Divisions() As System.Data.Entity.DbSet(Of Division)
    Public Overridable Property ClientDiscounts() As System.Data.Entity.DbSet(Of ClientDiscount)
    Public Overridable Property Clients() As System.Data.Entity.DbSet(Of Client)
	Public Overridable Property VendorRepresentatives() As System.Data.Entity.DbSet(Of VendorRepresentative)
	Public Overridable Property Vendors() As System.Data.Entity.DbSet(Of Vendor)
	Public Overridable Property Banks() As System.Data.Entity.DbSet(Of Bank)
	Public Overridable Property ContactTypes() As System.Data.Entity.DbSet(Of ContactType)
	Public Overridable Property Markets() As System.Data.Entity.DbSet(Of Market)
	Public Overridable Property Campaigns() As System.Data.Entity.DbSet(Of Campaign)
	Public Overridable Property VendorTerms() As System.Data.Entity.DbSet(Of VendorTerm)
	Public Overridable Property Tasks() As System.Data.Entity.DbSet(Of Task)
	Public Overridable Property AccountExecutives() As System.Data.Entity.DbSet(Of AccountExecutive)
	Public Overridable Property AlertGroups() As System.Data.Entity.DbSet(Of AlertGroup)
	Public Overridable Property JobTypes() As System.Data.Entity.DbSet(Of JobType)
	Public Overridable Property SalesClasses() As System.Data.Entity.DbSet(Of SalesClass)
    Public Overridable Property ScheduleStatuses() As System.Data.Entity.DbSet(Of ScheduleStatus)
    Public Overridable Property AdNumbers() As System.Data.Entity.DbSet(Of AdNumber)
    Public Overridable Property AdSizes() As System.Data.Entity.DbSet(Of AdSize)
    Public Overridable Property InternetTypes() As System.Data.Entity.DbSet(Of InternetType)
    Public Overridable Property MediaOrderViews() As System.Data.Entity.DbSet(Of MediaOrderView)
    Public Overridable Property InternetOrders() As System.Data.Entity.DbSet(Of InternetOrder)
    Public Overridable Property InternetOrderDetails() As System.Data.Entity.DbSet(Of InternetOrderDetail)
    Public Overridable Property InternetOrderDetailComments() As System.Data.Entity.DbSet(Of InternetOrderDetailComment)
    Public Overridable Property FiscalPeriods() As System.Data.Entity.DbSet(Of FiscalPeriod)

#End Region

#Region " Methods "

    <Obsolete>
	Public Sub New()

		MyBase.New("name=APIDbContext")

	End Sub
    Public Sub New(ConnectionString As String, UserCode As String)

        'MyBase.New(CreateEntityConnectionString(ConnectionString, "res://*/AdvantageAPI.APIDbContext.csdl|res://*/AdvantageAPI.APIDbContext.ssdl|res://*/AdvantageAPI.APIDbContext.msl"))

        MyBase.New(ConnectionString)

        System.Data.Entity.Database.SetInitializer(Of APIDbContext)(Nothing)

        CType(Me, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.CommandTimeout = 0

    End Sub
    Public Function GetQuery(Of TEntity As Class)() As System.Data.Entity.Infrastructure.DbQuery(Of TEntity)

        GetQuery = Me.Set(Of TEntity).AsNoTracking

    End Function
    Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

		modelBuilder.Conventions.Add(New AdvantageFramework.BaseClasses.Conventions.DecimalPrecisionAttributeConvention())

		MyBase.OnModelCreating(modelBuilder)

	End Sub
	Public Overridable Function LoadEmployeeTime(emp_code As String, startDate As Nullable(Of Date), endDate As Nullable(Of Date), sortColumn As String, uSER_CODE As String) As System.Collections.Generic.List(Of EmployeeTimeComplex)

        'Dim emp_codeParameter As System.Data.SqlClient.SqlParameter = If(emp_code IsNot Nothing, New System.Data.SqlClient.SqlParameter("@emp_code", emp_code), New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar))

        Dim emp_codeParameter As System.Data.SqlClient.SqlParameter = If(emp_code IsNot Nothing, New System.Data.SqlClient.SqlParameter("@emp_code", emp_code), New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar))

        Dim startDateParameter As System.Data.SqlClient.SqlParameter = If(startDate.HasValue, New System.Data.SqlClient.SqlParameter("@StartDate", startDate), New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.DateTime))

		Dim endDateParameter As System.Data.SqlClient.SqlParameter = If(endDate.HasValue, New System.Data.SqlClient.SqlParameter("@EndDate", endDate), New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.DateTime))

		Dim sortColumnParameter As System.Data.SqlClient.SqlParameter = If(sortColumn IsNot Nothing, New System.Data.SqlClient.SqlParameter("@SortColumn", sortColumn), New System.Data.SqlClient.SqlParameter("@SortColumn", SqlDbType.VarChar))

		Dim uSER_CODEParameter As System.Data.SqlClient.SqlParameter = If(uSER_CODE IsNot Nothing, New System.Data.SqlClient.SqlParameter("@USER_CODE", uSER_CODE), New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar))

        Dim AAA As Generic.List(Of EmployeeTimeComplex) = Nothing

        'usp_wv_ts_GetTimeSheet
        AAA = Me.Database.SqlQuery(Of EmployeeTimeComplex)("EXEC [dbo].[usp_wv_ts_GetTimeSheet] @emp_code, @StartDate, @EndDate, @SortColumn, @USER_CODE",
                                                            emp_codeParameter, startDateParameter, endDateParameter, sortColumnParameter, uSER_CODEParameter).ToList

        Return AAA

    End Function
    Public Overridable Function LoadMediaOrders(order_status As String, start_date As Nullable(Of Date), start_month As Nullable(Of Integer), start_year As Nullable(Of Integer), end_date As Nullable(Of Date), end_month As Nullable(Of Integer), end_year As Nullable(Of Integer),
                                                include_internet As Nullable(Of Boolean), include_magazine As Nullable(Of Boolean), include_newspaper As Nullable(Of Boolean), include_outofhome As Nullable(Of Boolean), include_radio As Nullable(Of Boolean),
                                                include_television As Nullable(Of Boolean), order_numbers As String) As System.Collections.Generic.List(Of MediaOrder)

        Dim order_statusParameter As System.Data.SqlClient.SqlParameter = If(order_status IsNot Nothing, New System.Data.SqlClient.SqlParameter("@order_status", order_status), New System.Data.SqlClient.SqlParameter("@order_status", SqlDbType.VarChar))

        Dim start_dateParameter As System.Data.SqlClient.SqlParameter = If(start_date.HasValue, New System.Data.SqlClient.SqlParameter("@start_date", start_date), New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.DateTime))

        Dim start_monthParameter As System.Data.SqlClient.SqlParameter = If(start_month.HasValue, New System.Data.SqlClient.SqlParameter("@start_month", start_month), New System.Data.SqlClient.SqlParameter("@start_month", SqlDbType.Int))

        Dim start_yearParameter As System.Data.SqlClient.SqlParameter = If(start_year.HasValue, New System.Data.SqlClient.SqlParameter("@start_year", start_year), New System.Data.SqlClient.SqlParameter("@start_year", SqlDbType.Int))

        Dim end_dateParameter As System.Data.SqlClient.SqlParameter = If(end_date.HasValue, New System.Data.SqlClient.SqlParameter("@end_date", end_date), New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.DateTime))

        Dim end_monthParameter As System.Data.SqlClient.SqlParameter = If(end_month.HasValue, New System.Data.SqlClient.SqlParameter("@end_month", end_month), New System.Data.SqlClient.SqlParameter("@end_month", SqlDbType.Int))

        Dim end_yearParameter As System.Data.SqlClient.SqlParameter = If(end_year.HasValue, New System.Data.SqlClient.SqlParameter("@end_year", end_year), New System.Data.SqlClient.SqlParameter("@end_year", SqlDbType.Int))

        Dim include_internetParameter As System.Data.SqlClient.SqlParameter = If(include_internet.HasValue, New System.Data.SqlClient.SqlParameter("@include_internet", include_internet), New System.Data.SqlClient.SqlParameter("@include_internet", SqlDbType.Bit))

        Dim include_magazineParameter As System.Data.SqlClient.SqlParameter = If(include_magazine.HasValue, New System.Data.SqlClient.SqlParameter("@include_magazine", include_magazine), New System.Data.SqlClient.SqlParameter("@include_magazine", SqlDbType.Bit))

        Dim include_newspaperParameter As System.Data.SqlClient.SqlParameter = If(include_newspaper.HasValue, New System.Data.SqlClient.SqlParameter("@include_newspaper", include_newspaper), New System.Data.SqlClient.SqlParameter("@include_newspaper", SqlDbType.Bit))

        Dim include_outofhomeParameter As System.Data.SqlClient.SqlParameter = If(include_outofhome.HasValue, New System.Data.SqlClient.SqlParameter("@include_outofhome", include_outofhome), New System.Data.SqlClient.SqlParameter("@include_outofhome", SqlDbType.Bit))

        Dim include_radioParameter As System.Data.SqlClient.SqlParameter = If(include_radio.HasValue, New System.Data.SqlClient.SqlParameter("@include_radio", include_radio), New System.Data.SqlClient.SqlParameter("@include_radio", SqlDbType.Bit))

        Dim include_televisionParameter As System.Data.SqlClient.SqlParameter = If(include_television.HasValue, New System.Data.SqlClient.SqlParameter("@include_television", include_television), New System.Data.SqlClient.SqlParameter("@include_television", SqlDbType.Bit))

        Dim OfficeCodeListParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@OfficeCodeList", "")
        Dim ClientCodeListParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ClientCodeList", "")
        Dim ClientDivisionCodeList As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ClientDivisionCodeList", "")
        Dim ClientDivisionProductCodeList As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ClientDivisionProductCodeList", "")

        Dim broadcast_datesParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@broadcast_dates", 0)

        Dim order_numbersParameter As System.Data.SqlClient.SqlParameter = If(order_numbers IsNot Nothing, New System.Data.SqlClient.SqlParameter("@order_numbers", order_numbers), New System.Data.SqlClient.SqlParameter("@order_numbers", ""))

        Dim AAA As Generic.List(Of MediaOrder) = Nothing

        AAA = Me.Database.SqlQuery(Of MediaOrder)("EXEC [dbo].[advsp_media1_media_current_status1_sum] @order_status, @start_date, @start_month, @start_year, @end_date, @end_month, @end_year, 
                @include_internet, @include_magazine, @include_newspaper, @include_outofhome, @include_radio, @include_television, 
                @OfficeCodeList, @ClientCodeList, @ClientDivisionCodeList, @ClientDivisionProductCodeList, @broadcast_dates, @order_numbers",
                order_statusParameter, start_dateParameter, start_monthParameter, start_yearParameter, end_dateParameter, end_monthParameter, end_yearParameter,
                include_internetParameter, include_magazineParameter, include_newspaperParameter, include_outofhomeParameter, include_radioParameter, include_televisionParameter,
                OfficeCodeListParameter, ClientCodeListParameter, ClientDivisionCodeList, ClientDivisionProductCodeList, broadcast_datesParameter, order_numbersParameter).ToList

        Return AAA
    End Function

    Public Overridable Function LoadClientTypes(client_type_id As Integer, show_inactive As Boolean) As System.Collections.Generic.List(Of ClientTypes)

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing


        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
        SqlParameterReturnValue.Direction = ParameterDirection.Output
        SqlParameterReturnValue.Value = ReturnValue

        SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
        SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
        SqlParameterReturnValueMessage.Size = 4096
        SqlParameterReturnValueMessage.Value = ReturnValueMessage


        Dim client_type_idParameter = New System.Data.SqlClient.SqlParameter("@client_type_id", SqlDbType.Int)
        client_type_idParameter.Value = client_type_id

        Dim show_inactiveParameter = New System.Data.SqlClient.SqlParameter("@show_inactive", SqlDbType.Bit)
        show_inactiveParameter.Value = show_inactive

        'Dim client_type_idParameter As System.Data.SqlClient.SqlParameter = If(client_type_id IsNot Nothing, New System.Data.SqlClient.SqlParameter("@client_type_id", client_type_id), New System.Data.SqlClient.SqlParameter("@client_type_id", SqlDbType.VarChar))

        'Dim show_inactiveParameter As System.Data.SqlClient.SqlParameter = If(show_inactive.HasValue, New System.Data.SqlClient.SqlParameter("@show_inactive", show_inactive), New System.Data.SqlClient.SqlParameter("@show_inactive", SqlDbType.DateTime))

        Dim AAA As Generic.List(Of ClientTypes) = Nothing

        AAA = Me.Database.SqlQuery(Of ClientTypes)("EXEC [dbo].[advsp_client_type_get_api] @client_type_id, @show_inactive,@ret_val OUTPUT,@ret_val_s OUTPUT",
                client_type_idParameter, show_inactiveParameter, SqlParameterReturnValue, SqlParameterReturnValueMessage).ToList

        Return AAA
    End Function

    Public Overridable Function LoadJobLogUserDefinedValues(udv_id As Integer, show_inactive As Boolean) As System.Collections.Generic.List(Of JobLogUserDefinedValues)

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing


        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
        SqlParameterReturnValue.Direction = ParameterDirection.Output
        SqlParameterReturnValue.Value = ReturnValue

        SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
        SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
        SqlParameterReturnValueMessage.Size = 4096
        SqlParameterReturnValueMessage.Value = ReturnValueMessage

        Dim udv_idParameter = New System.Data.SqlClient.SqlParameter("@udv_id", SqlDbType.Int)
        udv_idParameter.Value = udv_id

        Dim show_inactiveParameter = New System.Data.SqlClient.SqlParameter("@show_inactive", SqlDbType.Bit)
        show_inactiveParameter.Value = show_inactive

        Dim AAA As Generic.List(Of JobLogUserDefinedValues) = Nothing

        AAA = Me.Database.SqlQuery(Of JobLogUserDefinedValues)("EXEC [dbo].[advsp_job_log_udf_get_api] @udv_id, @show_inactive, @ret_val OUTPUT,@ret_val_s OUTPUT",
                udv_idParameter, show_inactiveParameter, SqlParameterReturnValue, SqlParameterReturnValueMessage).ToList

        Return AAA
    End Function

    Public Overridable Function LoadAPInvoices(VendorCode As String, StartDate As Date, EndDate As Date, PaymentStatus As Integer) As System.Collections.Generic.List(Of APInvoices)

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        'Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
        'Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)

        Dim SqlParameterVendorCode = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar)
        Dim SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.Date)
        Dim SqlParameterEndtDate = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.Date)
        Dim SqlParameterPaymentStatus = New System.Data.SqlClient.SqlParameter("@pmt_status", SqlDbType.SmallInt)

        Dim PaymentStatusShort As Short = 0

        PaymentStatusShort = PaymentStatus

        'SqlParameterVendorCode = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar)
        SqlParameterVendorCode.Value = VendorCode

        'SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.Date)
        SqlParameterStartDate.Value = StartDate

        'SqlParameterEndtDate = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.Date)
        SqlParameterEndtDate.Value = EndDate

        'SqlParameterPaymentStatus = New System.Data.SqlClient.SqlParameter("@pmt_status", SqlDbType.Int)
        SqlParameterPaymentStatus.Value = PaymentStatusShort

        'SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
        SqlParameterReturnValue.Direction = ParameterDirection.Output
        SqlParameterReturnValue.Value = ReturnValue

        'SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
        SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
        SqlParameterReturnValueMessage.Size = 4096
        SqlParameterReturnValueMessage.Value = ReturnValueMessage

        Dim AAA As Generic.List(Of APInvoices) = Nothing

        AAA = Me.Database.SqlQuery(Of APInvoices)("EXEC [dbo].[advsp_ap_invoice_get_api] @vn_code, @start_date,@end_date,@pmt_status,@ret_val OUTPUT,@ret_val_s OUTPUT",
                SqlParameterVendorCode, SqlParameterStartDate, SqlParameterEndtDate, SqlParameterPaymentStatus, SqlParameterReturnValue, SqlParameterReturnValueMessage).ToList

        Return AAA
    End Function
    Public Overridable Function LoadAPInvoiceDetails(ApId As Integer) As System.Collections.Generic.List(Of APInvoiceDetails)

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterApId = New System.Data.SqlClient.SqlParameter("@ap_id", SqlDbType.Int)
        SqlParameterApId.Value = ApId

        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
        SqlParameterReturnValue.Direction = ParameterDirection.Output
        SqlParameterReturnValue.Value = ReturnValue

        SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
        SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
        SqlParameterReturnValueMessage.Size = 4096
        SqlParameterReturnValueMessage.Value = ReturnValueMessage

        Dim AAA As Generic.List(Of APInvoiceDetails) = Nothing

        AAA = Me.Database.SqlQuery(Of APInvoiceDetails)("EXEC [dbo].[advsp_ap_invoice_detail_get_api] @ap_id,@ret_val OUTPUT,@ret_val_s OUTPUT",
                SqlParameterApId, SqlParameterReturnValue, SqlParameterReturnValueMessage).ToList

        Return AAA
    End Function

    Public Overridable Function LoadARInvoices(JobNumber As Integer, JobComponentNumber As Integer, InvoiceNumber As Integer, InvoiceSequence As Integer) As System.Collections.Generic.List(Of ARInvoices)

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterInvoiceNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterInvoiceSequence As System.Data.SqlClient.SqlParameter = Nothing

        SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
        SqlParameterJobNumber.Value = JobNumber

        SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component", SqlDbType.Int)
        SqlParameterJobComponentNumber.Value = JobComponentNumber

        SqlParameterInvoiceNumber = New System.Data.SqlClient.SqlParameter("@ar_inv_nbr", SqlDbType.Int)
        SqlParameterInvoiceNumber.Value = InvoiceNumber

        SqlParameterInvoiceSequence = New System.Data.SqlClient.SqlParameter("@ar_inv_seq", SqlDbType.Int)
        SqlParameterInvoiceSequence.Value = InvoiceSequence

        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
        SqlParameterReturnValue.Direction = ParameterDirection.Output
        SqlParameterReturnValue.Value = ReturnValue

        SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
        SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
        SqlParameterReturnValueMessage.Size = 4096
        SqlParameterReturnValueMessage.Value = ReturnValueMessage

        Dim AAA As Generic.List(Of ARInvoices) = Nothing

        AAA = Me.Database.SqlQuery(Of ARInvoices)("EXEC [dbo].[advsp_ar_invoice_get_api] @job_number,@job_component,@ar_inv_nbr,@ar_inv_seq,@ret_val OUTPUT,@ret_val_s OUTPUT",
                SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterInvoiceNumber, SqlParameterInvoiceSequence, SqlParameterReturnValue, SqlParameterReturnValueMessage).ToList

        Return AAA
    End Function
    Public Overridable Function LoadOffices(LoadInactive As Boolean) As System.Collections.Generic.List(Of Offices)

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterLoadInactive As System.Data.SqlClient.SqlParameter = Nothing

        SqlParameterLoadInactive = New System.Data.SqlClient.SqlParameter("@load_inactive", SqlDbType.Bit)
        SqlParameterLoadInactive.Value = LoadInactive

        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
        SqlParameterReturnValue.Direction = ParameterDirection.Output
        SqlParameterReturnValue.Value = ReturnValue

        SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
        SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
        SqlParameterReturnValueMessage.Size = 4096
        SqlParameterReturnValueMessage.Value = ReturnValueMessage

        Dim AAA As Generic.List(Of Offices) = Nothing

        AAA = Me.Database.SqlQuery(Of Offices)("EXEC [dbo].[advsp_load_office_list] @load_inactive,@ret_val OUTPUT,@ret_val_s OUTPUT",
                SqlParameterLoadInactive, SqlParameterReturnValue, SqlParameterReturnValueMessage).ToList

        Return AAA
    End Function
    Public Overridable Function LoadIndirectTime(StartDate As Date, EndDate As Date, EmployeeCode As String, ByRef ErrorMessage As String) As System.Collections.Generic.List(Of IndirectTime)

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        Dim SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
        Dim SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)

        Dim SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar)
        Dim SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.Date)
        Dim SqlParameterEndtDate = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.Date)

        SqlParameterEmployeeCode.Value = EmployeeCode

        SqlParameterStartDate.Value = StartDate

        SqlParameterEndtDate.Value = EndDate

        SqlParameterReturnValue.Direction = ParameterDirection.Output
        SqlParameterReturnValue.Value = ReturnValue

        SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
        SqlParameterReturnValueMessage.Size = 4096
        SqlParameterReturnValueMessage.Value = ReturnValueMessage

        Dim AAA As Generic.List(Of IndirectTime) = Nothing

        AAA = Me.Database.SqlQuery(Of IndirectTime)("EXEC [dbo].[advsp_indirect_time_get_api] @start_date,@end_date,@emp_code,@ret_val OUTPUT,@ret_val_s OUTPUT",
                SqlParameterStartDate, SqlParameterEndtDate, SqlParameterEmployeeCode, SqlParameterReturnValue, SqlParameterReturnValueMessage).ToList

        If AAA.Count = 0 Then
            ReturnValueMessage = SqlParameterReturnValueMessage.Value

            If (ReturnValueMessage) > "" Then
                ErrorMessage = ReturnValueMessage
            End If
        End If

        Return AAA

    End Function

    Public Overridable Function LoadSecClients(UserCode As String, ByRef ErrorMessage As String) As System.Collections.Generic.List(Of SecClient)

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing


        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
        SqlParameterReturnValue.Direction = ParameterDirection.Output
        SqlParameterReturnValue.Value = ReturnValue

        SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
        SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
        SqlParameterReturnValueMessage.Size = 4096
        SqlParameterReturnValueMessage.Value = ReturnValueMessage


        Dim UserCodeParameter = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
        UserCodeParameter.Value = UserCode

        Dim AAA As Generic.List(Of SecClient) = Nothing

        AAA = Me.Database.SqlQuery(Of SecClient)("EXEC [dbo].[advsp_sec_client_get_api] @user_code,@ret_val OUTPUT,@ret_val_s OUTPUT",
                UserCodeParameter, SqlParameterReturnValue, SqlParameterReturnValueMessage).ToList

        ErrorMessage = SqlParameterReturnValueMessage.Value.ToString()

        Return AAA
    End Function
    Public Overridable Function LoadMediaBroadcastDetails(MediaType As String, ByRef ErrorMessage As String) As System.Collections.Generic.List(Of MediaBroadcastDetails)

        Dim MediaTypeParameter = New System.Data.SqlClient.SqlParameter("@media_type", SqlDbType.VarChar)
        MediaTypeParameter.Value = If(String.IsNullOrWhiteSpace(MediaType), DBNull.Value, MediaType)

        Dim AAA As Generic.List(Of MediaBroadcastDetails) = Nothing

        AAA = Me.Database.SqlQuery(Of MediaBroadcastDetails)("EXEC [dbo].[advsp_api_load_media_broadcast_details] @media_type",
                MediaTypeParameter).ToList

        If AAA.Count = 0 Then
            ErrorMessage = ""
        End If

        Return AAA
    End Function

#End Region

End Class
