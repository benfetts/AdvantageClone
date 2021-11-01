Namespace Reporting.Database.Procedures.BillingInvoice

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ParameterDictionary As Dictionary(Of String, Object)
        Public Property Session As AdvantageFramework.Security.Session

#End Region

#Region " Methods "

        Public Function LoadBillingInvoiceDetail(
            ByVal DbContext As Database.DbContext _
            , ByVal AP_ID As Integer _
            , ByVal Worksheets As List(Of Integer) _
            , ByVal Invoices As List(Of Integer) _
            , ByVal LocationName As String _
            , ByVal EntryStart As Date _
            , ByVal EntryEnd As Date _
            , ByVal InvoiceStart As Date _
            , ByVal InvoiceEnd As Date _
            , ByVal Clients As List(Of String) _
            , ByVal Divisions As List(Of String) _
            , ByVal Products As List(Of String) _
            , ByVal Markets As List(Of String) _
            , ByVal Vendors As List(Of String)) _
            As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.BillingInvoiceDetail)

            Dim SqlParameterAPID As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterAPID = New System.Data.SqlClient.SqlParameter("@AP_ID", SqlDbType.Int) With {
                .Value = AP_ID
            }

            Dim SqlParameterWorksheets As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterWorksheets = IntegerListToSqlParameter("@Worksheets", Worksheets)

            Dim SqlParameterInvoices As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterInvoices = IntegerListToSqlParameter("@Invoices", Invoices)

            Dim SqlParameterLocation As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterLocation = New System.Data.SqlClient.SqlParameter("@LOCATION_NAME", SqlDbType.VarChar) With {
                .Value = LocationName
            }

            Dim SqlParameterEntryStart As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterEntryStart = New System.Data.SqlClient.SqlParameter("@EntryStart", SqlDbType.Date) With {
                .Value = EntryStart
            }

            Dim SqlParameterEntryEnd As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterEntryEnd = New System.Data.SqlClient.SqlParameter("@EntryEnd", SqlDbType.Date) With {
                .Value = EntryEnd
            }

            Dim SqlParameterInvoiceStart As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterInvoiceStart = New System.Data.SqlClient.SqlParameter("@InvoiceStart", SqlDbType.Date) With {
                .Value = InvoiceStart
            }

            Dim SqlParameterInvoiceEnd As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterInvoiceEnd = New System.Data.SqlClient.SqlParameter("@InvoiceEnd", SqlDbType.Date) With {
                .Value = InvoiceEnd
            }

            Dim SqlParameterClients As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterInvoices = StringListToSqlParameter("@Clients", Clients)

            Dim SqlParameterDivisions As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterDivisions = StringListToSqlParameter("@Divisions", Divisions)

            Dim SqlParameterProducts As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterProducts = StringListToSqlParameter("@Products", Products)

            Dim SqlParameterMarkets As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterMarkets = StringListToSqlParameter("@Markets", Markets)

            Dim SqlParameterVendors As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterVendors = StringListToSqlParameter("@vendors", Vendors)

            Try
                LoadBillingInvoiceDetail = DbContext.Database.SqlQuery(Of Database.Classes.BillingInvoiceDetail) _
                    ("EXEC advsp_broadcast_invoice_detail @AP_ID, @Worksheets, @Invoices, @Location, @EntryStart, @EntryEnd, @InvoiceStart, @InvoiceEnd, @Clients, @Divisions, @Products, @Markets, @Vendors" _
                     , SqlParameterAPID, SqlParameterWorksheets, SqlParameterInvoices, SqlParameterLocation _
                     , SqlParameterEntryStart, SqlParameterEntryEnd, SqlParameterInvoiceStart, SqlParameterInvoiceEnd _
                     , SqlParameterClients, SqlParameterDivisions, SqlParameterProducts, SqlParameterMarkets, SqlParameterVendors)
            Catch ex As Exception
                LoadBillingInvoiceDetail = Nothing
            End Try

        End Function

        Public Function LoadBillingInvoiceSummary(ByVal DbContext As Database.DbContext _
            , ByVal AP_ID As Integer _
            , ByVal Worksheets As List(Of Integer) _
            , ByVal Invoices As List(Of Integer) _
            , ByVal LocationName As String _
            , ByVal EntryStart As Date _
            , ByVal EntryEnd As Date _
            , ByVal InvoiceStart As Date _
            , ByVal InvoiceEnd As Date _
            , ByVal Clients As List(Of String) _
            , ByVal Divisions As List(Of String) _
            , ByVal Products As List(Of String) _
            , ByVal Markets As List(Of String) _
            , ByVal Vendors As List(Of String)) _
            As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.BillingInvoiceSummary)

            Dim SqlParameterAPID As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterAPID = New System.Data.SqlClient.SqlParameter("@AP_ID", SqlDbType.Int) With {
                .Value = AP_ID
            }

            Dim SqlParameterWorksheets As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterWorksheets = IntegerListToSqlParameter("@Worksheets", Worksheets)

            Dim SqlParameterInvoices As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterInvoices = IntegerListToSqlParameter("@Invoices", Invoices)

            Dim SqlParameterLocation As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterLocation = New System.Data.SqlClient.SqlParameter("@LOCATION_NAME", SqlDbType.VarChar) With {
                .Value = LocationName
            }

            Dim SqlParameterEntryStart As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterEntryStart = New System.Data.SqlClient.SqlParameter("@EntryStart", SqlDbType.Date) With {
                .Value = EntryStart
            }

            Dim SqlParameterEntryEnd As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterEntryEnd = New System.Data.SqlClient.SqlParameter("@EntryEnd", SqlDbType.Date) With {
                .Value = EntryEnd
            }

            Dim SqlParameterInvoiceStart As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterInvoiceStart = New System.Data.SqlClient.SqlParameter("@InvoiceStart", SqlDbType.Date) With {
                .Value = InvoiceStart
            }

            Dim SqlParameterInvoiceEnd As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterInvoiceEnd = New System.Data.SqlClient.SqlParameter("@InvoiceEnd", SqlDbType.Date) With {
                .Value = InvoiceEnd
            }

            Dim SqlParameterClients As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterInvoices = StringListToSqlParameter("@Clients", Clients)

            Dim SqlParameterDivisions As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterDivisions = StringListToSqlParameter("@Divisions", Divisions)

            Dim SqlParameterProducts As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterProducts = StringListToSqlParameter("@Products", Products)

            Dim SqlParameterMarkets As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterMarkets = StringListToSqlParameter("@Markets", Markets)

            Dim SqlParameterVendors As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterVendors = StringListToSqlParameter("@vendors", Vendors)

            Try
                LoadBillingInvoiceSummary = DbContext.Database.SqlQuery(Of Database.Classes.BillingInvoiceSummary) _
                    ("EXEC dbo.advsp_media_broadcast_schedule_report_detail @AP_ID, @Worksheets, @Invoices, @Location, @EntryStart, @EntryEnd, @InvoiceStart, @InvoiceEnd, @Clients, @Divisions, @Products, @Markets, @Vendors" _
                     , SqlParameterAPID, SqlParameterWorksheets, SqlParameterInvoices, SqlParameterLocation _
                     , SqlParameterEntryStart, SqlParameterEntryEnd, SqlParameterInvoiceStart, SqlParameterInvoiceEnd _
                     , SqlParameterClients, SqlParameterDivisions, SqlParameterProducts, SqlParameterMarkets, SqlParameterVendors)
            Catch ex As Exception
                LoadBillingInvoiceSummary = Nothing
            End Try

        End Function

        Private Function StringListToSqlParameter(ByVal ParamName As String, StringListElements As Generic.List(Of String)) As System.Data.SqlClient.SqlParameter

            Dim StringSqlParameter As System.Data.SqlClient.SqlParameter

            StringSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (StringListElements Is Nothing) Then

                StringSqlParameter.Value = System.DBNull.Value

            ElseIf (StringListElements.Count = 0) Then

                StringSqlParameter.Value = System.DBNull.Value

            Else

                StringSqlParameter.Value = Join(StringListElements.ToArray, ",")

            End If

            Return StringSqlParameter

        End Function
        Private Function IntegerListToSqlParameter(ByVal ParamName As String, IntegerListElements As Generic.List(Of Integer)) As System.Data.SqlClient.SqlParameter

            Dim IntegerSqlParameter As System.Data.SqlClient.SqlParameter

            IntegerSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (IntegerListElements Is Nothing) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            ElseIf (IntegerListElements.Count = 0) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            Else
                Dim SqlParamIntegerList As Generic.List(Of String) = New List(Of String)

                For Each IntegerElement In IntegerListElements
                    SqlParamIntegerList.Add(IntegerElement)
                Next

                IntegerSqlParameter.Value = Join(SqlParamIntegerList.ToArray, ",")
            End If
            Return IntegerSqlParameter

        End Function

        Private Function NullableIntegerListToSqlParameter(ByVal ParamName As String, IntegerListElements As Generic.List(Of Nullable(Of Integer))) As System.Data.SqlClient.SqlParameter

            Dim IntegerSqlParameter As System.Data.SqlClient.SqlParameter

            IntegerSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (IntegerListElements Is Nothing) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            ElseIf (IntegerListElements.Count = 0) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            Else
                Dim SqlParamIntegerList As Generic.List(Of String) = New List(Of String)

                For Each IntegerElement In IntegerListElements
                    If (IntegerElement.HasValue) Then
                        SqlParamIntegerList.Add(IntegerElement.Value)
                    Else
                        SqlParamIntegerList.Add("")
                    End If
                Next

                IntegerSqlParameter.Value = Join(SqlParamIntegerList.ToArray, ",")
            End If
            Return IntegerSqlParameter

        End Function

        Private Function NullableIntegerListToOneSqlParameter(ByVal ParamName As String, IntegerListElements As Generic.List(Of Nullable(Of Integer))) As System.Data.SqlClient.SqlParameter

            Dim IntegerSqlParameter As System.Data.SqlClient.SqlParameter

            IntegerSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (IntegerListElements Is Nothing) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            ElseIf (IntegerListElements.Count = 0) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            Else
                IntegerSqlParameter.Value = IntegerListElements.First.ToString
            End If
            Return IntegerSqlParameter

        End Function

        Private Function BooleanListToSqlParameter(ByVal ParamName As String, BooleanListElements As Generic.List(Of Boolean)) As System.Data.SqlClient.SqlParameter

            Dim BooleanSqlParameter As System.Data.SqlClient.SqlParameter

            BooleanSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (BooleanListElements Is Nothing) Then
                BooleanSqlParameter.Value = System.DBNull.Value
            ElseIf (BooleanListElements.Count = 0) Then
                BooleanSqlParameter.Value = System.DBNull.Value
            Else
                Dim SqlParamBooleanList As Generic.List(Of String) = New List(Of String)

                For Each BooleanElement In BooleanListElements
                    If (BooleanElement = True) Then
                        SqlParamBooleanList.Add("1")
                    Else
                        SqlParamBooleanList.Add("0")
                    End If

                Next

                BooleanSqlParameter.Value = Join(SqlParamBooleanList.ToArray, ",")
            End If
            Return BooleanSqlParameter

        End Function

        Private Function BooleanListToOneSqlParameter(ByVal ParamName As String, BooleanListElements As Generic.List(Of Boolean)) As System.Data.SqlClient.SqlParameter

            Dim BooleanSqlParameter As System.Data.SqlClient.SqlParameter

            BooleanSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (BooleanListElements Is Nothing) Then
                BooleanSqlParameter.Value = System.DBNull.Value
            ElseIf (BooleanListElements.Count = 0) Then
                BooleanSqlParameter.Value = System.DBNull.Value
            Else
                BooleanSqlParameter.Value = IIf(BooleanListElements.First = True, "1", "0")
            End If
            Return BooleanSqlParameter

        End Function
#End Region

    End Module

End Namespace
