Namespace Currency

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function GetAPIKey(DbContext As AdvantageFramework.Database.DbContext) As String

            Dim Key As String = Nothing

            Key = AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.CURRENCY_API_KEY)

            GetAPIKey = Key

        End Function
        Public Function IsCurrencyServiceSetup(DbContext As AdvantageFramework.Database.DbContext, Optional ByRef ErrorMessage As String = Nothing) As Boolean

            'objects
            Dim ServiceIsSetup As Boolean = False

            ServiceIsSetup = TestConnection(GetAPIKey(DbContext), ErrorMessage)

            IsCurrencyServiceSetup = ServiceIsSetup

        End Function
        Public Function TestConnection(ByVal APIKey As String, ByRef ErrorMessage As String) As Boolean

            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim JsonDeserializer As RestSharp.Deserializers.JsonDeserializer = Nothing
            Dim Dictionary As Dictionary(Of String, String) = Nothing
            Dim Success As Boolean = False
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing

            Try

                RestClient = New RestSharp.RestClient("https://apilayer.net/api/")

                RestRequest = New RestSharp.RestRequest("live")

                RestRequest.AddParameter("access_key", APIKey, RestSharp.ParameterType.QueryString)
                RestRequest.AddParameter("source", "USD", RestSharp.ParameterType.QueryString)
                RestRequest.AddParameter("currencies", "CAD", RestSharp.ParameterType.QueryString)

                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                JsonDeserializer = New RestSharp.Deserializers.JsonDeserializer
                Dictionary = JsonDeserializer.Deserialize(Of Dictionary(Of String, String))(RestResponse)

                If Dictionary.Item("success") = "True" Then

                    Success = True

                Else

                    JObject = Newtonsoft.Json.Linq.JObject.Parse(Dictionary.Item("error"))

                    ErrorMessage = JObject.SelectToken("info").ToString()

                End If

            Catch ex As Exception

            Finally
                TestConnection = Success
            End Try

        End Function
        'Public Function GetHistoricalRates(ByVal Session As AdvantageFramework.Security.Session) As Boolean

        '    Dim RestClient As RestSharp.RestClient = Nothing
        '    Dim RestRequest As RestSharp.RestRequest = Nothing
        '    Dim RestResponse As RestSharp.IRestResponse = Nothing
        '    Dim JsonDeserializer As RestSharp.Deserializers.JsonDeserializer = Nothing
        '    Dim Dictionary As Dictionary(Of String, String) = Nothing
        '    Dim Success As Boolean = True

        '    Try

        '        RestClient = New RestSharp.RestClient("https://apilayer.net/api/")

        '        RestRequest = New RestSharp.RestRequest("historical")

        '        RestRequest.AddParameter("access_key", GetAPIKey(Session), RestSharp.ParameterType.QueryString)
        '        RestRequest.AddParameter("date", "2010-03-18", RestSharp.ParameterType.QueryString)
        '        RestRequest.AddParameter("source", "USD", RestSharp.ParameterType.QueryString)
        '        'RestRequest.AddParameter("currencies", "CAD")

        '        RestRequest.RequestFormat = RestSharp.DataFormat.Json

        '        RestResponse = RestClient.Execute(RestRequest)

        '        JsonDeserializer = New RestSharp.Deserializers.JsonDeserializer
        '        Dictionary = JsonDeserializer.Deserialize(Of Dictionary(Of String, String))(RestResponse)

        '        If Dictionary.Item("success") = "True" Then

        '            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing

        '            JObject = Newtonsoft.Json.Linq.JObject.Parse(Dictionary.Item("quotes"))

        '            Dim rate As Decimal = JObject.SelectToken("USDCAD").SingleOrDefault

        '        End If

        '    Catch ex As Exception
        '        Success = False
        '    Finally
        '        GetHistoricalRates = Success
        '    End Try

        'End Function
        Public Function GetRealtimeRates(DbContext As AdvantageFramework.Database.DbContext, CurrencyCodeList As IEnumerable(Of String), CurrencyCodeHome As String, ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = True
            Dim LocalError As String = Nothing

            For Each CurrencyCode In CurrencyCodeList.Where(Function(CCL) CCL <> CurrencyCodeHome).ToList

                If Not AdvantageFramework.Currency.GetRealtimeRates(DbContext, CurrencyCodeHome, CurrencyCode, ErrorMessage) Then

                    Success = False
                    ErrorMessage += LocalError & System.Environment.NewLine

                End If

            Next

            GetRealtimeRates = Success

        End Function
        Private Function GetRealtimeRates(DbContext As AdvantageFramework.Database.DbContext, HomeCurrencyCode As String, CurrencyCode As String, ByRef ErrorMessage As String) As Boolean

            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim JsonDeserializer As RestSharp.Deserializers.JsonDeserializer = Nothing
            Dim Dictionary As Dictionary(Of String, String) = Nothing
            Dim Success As Boolean = False
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim Rate As String = Nothing
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing
            Dim ExchangeDate As Date = Nothing
            Dim ExistingCurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing

            Try

                RestClient = New RestSharp.RestClient("https://apilayer.net/api/")

                RestRequest = New RestSharp.RestRequest("live")

                RestRequest.AddParameter("access_key", GetAPIKey(DbContext), RestSharp.ParameterType.QueryString)
                RestRequest.AddParameter("source", CurrencyCode, RestSharp.ParameterType.QueryString)
                RestRequest.AddParameter("currencies", HomeCurrencyCode, RestSharp.ParameterType.QueryString)

                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                JsonDeserializer = New RestSharp.Deserializers.JsonDeserializer
                Dictionary = JsonDeserializer.Deserialize(Of Dictionary(Of String, String))(RestResponse)

                If Dictionary.Item("success") = "True" Then

                    ExchangeDate = Now.ToString("G")

                    JObject = Newtonsoft.Json.Linq.JObject.Parse(Dictionary.Item("quotes"))

                    Try

                        Rate = JObject.SelectToken(CurrencyCode & HomeCurrencyCode).ToString()

                    Catch ex As Exception
                        Rate = Nothing
                    End Try

                    If Rate IsNot Nothing Then

                        ExistingCurrencyDetail = AdvantageFramework.Database.Procedures.CurrencyDetail.LoadLatestByCurrencyCodeAndCurrencyCodeComparison(DbContext, CurrencyCode, HomeCurrencyCode)

                        If ExistingCurrencyDetail Is Nothing OrElse ExistingCurrencyDetail.ExchangeRate <> Rate Then

                            CurrencyDetail = New AdvantageFramework.Database.Entities.CurrencyDetail
                            CurrencyDetail.DbContext = DbContext

                            CurrencyDetail.CurrencyCode = CurrencyCode
                            CurrencyDetail.ExchangeRate = Rate
                            CurrencyDetail.ExchangeDate = ExchangeDate
                            CurrencyDetail.CurrencyCodeComparison = HomeCurrencyCode

                            CurrencyDetail.ReciprocalExchangeRate = FormatNumber(1 / CurrencyDetail.ExchangeRate, 6)

                            If AdvantageFramework.Database.Procedures.CurrencyDetail.Insert(DbContext, CurrencyDetail) Then

                                Success = True

                            End If

                        ElseIf ExistingCurrencyDetail IsNot Nothing Then

                            ExistingCurrencyDetail.ExchangeDate = ExchangeDate

                            If AdvantageFramework.Database.Procedures.CurrencyDetail.Update(DbContext, ExistingCurrencyDetail) Then

                                Success = True

                            End If

                        End If

                    End If

                Else

                    JObject = Newtonsoft.Json.Linq.JObject.Parse(Dictionary.Item("error"))

                    If JObject.SelectToken("code").ToString() = "201" Then

                        ErrorMessage = "Currency code '" & CurrencyCode & "' not supported."

                    Else

                        ErrorMessage = JObject.SelectToken("info").ToString()

                    End If

                End If

            Catch ex As Exception

            Finally
                GetRealtimeRates = Success
            End Try

        End Function
        Public Function GetCurrencySymbolByCurrencyCode(CurrencyCode As String) As String

            Dim RegionInfo As System.Globalization.RegionInfo = Nothing
            Dim CultureInfo As System.Globalization.CultureInfo = Nothing
            Dim CultureTypes As System.Globalization.CultureTypes = Nothing
            Dim CurrencySymbol As String = Nothing
            Dim AllCultures() As System.Globalization.CultureInfo
            Dim ACulture As System.Globalization.CultureInfo

            CultureTypes = System.Globalization.CultureTypes.SpecificCultures

            AllCultures = System.Globalization.CultureInfo.GetCultures(CultureTypes)

            For Each ACulture In AllCultures

                RegionInfo = New System.Globalization.RegionInfo(ACulture.LCID)

                If RegionInfo.ISOCurrencySymbol = CurrencyCode Then

                    CurrencySymbol = RegionInfo.CurrencySymbol
                    Exit For

                End If

            Next

            GetCurrencySymbolByCurrencyCode = CurrencySymbol

            '= = = = = Sample code block to set currency symbol by Currency Code (e.g. USD, EUR, etc.) = = = = =
            'AdvantageFramework.Currency.GetBankCurrencyCodeByBankCode(DbContext, AccountPayablePayment.BankCode, CurrencyCode, CurrencySymbol)
            'System.Threading.Thread.CurrentThread.CurrentCulture = NewCulture
            'CurrencySymbol = AdvantageFramework.Currency.GetCurrencySymbolByCurrencyCode(CurrencyCode)
            'NewCulture.NumberFormat.CurrencySymbol = CurrencySymbol

        End Function
        Public Sub GetBankCurrencyCodeByBankCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BankCode As String, ByRef CurrencyCode As String, ByRef CurrencySymbol As String)

            'objects
            Dim SqlParameterBankCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCurrencyCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCurrencySymbol As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBankCode = New System.Data.SqlClient.SqlParameter("@bk_code", SqlDbType.VarChar)
            SqlParameterCurrencyCode = New System.Data.SqlClient.SqlParameter("@currency_code", SqlDbType.VarChar)
            SqlParameterCurrencySymbol = New System.Data.SqlClient.SqlParameter("@currency_symbol", SqlDbType.NVarChar)
            SqlParameterCurrencyCode.Direction = ParameterDirection.Output
            SqlParameterCurrencySymbol.Direction = ParameterDirection.Output
            SqlParameterCurrencyCode.Size = 6
            SqlParameterCurrencySymbol.Size = 6
            SqlParameterBankCode.Value = BankCode
            SqlParameterCurrencyCode.Value = ""
            SqlParameterCurrencySymbol.Value = ""

            DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_get_currency_info @bk_code, @currency_code OUTPUT, @currency_symbol OUTPUT",
                    SqlParameterBankCode, SqlParameterCurrencyCode, SqlParameterCurrencySymbol)

            CurrencyCode = SqlParameterCurrencyCode.Value
            CurrencySymbol = SqlParameterCurrencySymbol.Value

        End Sub
        'Private Function GetCultureInfosByCurrencySymbol(CurrencySymbol As String) As IEnumerable(Of System.Globalization.CultureInfo)

        '    Dim CultureInfos As IEnumerable(Of System.Globalization.CultureInfo) = Nothing

        '    If CurrencySymbol Is Nothing Then
        '        Throw New ArgumentNullException("currencySymbol")
        '    End If

        '    CultureInfos = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures).Where(Function(x) New System.Globalization.RegionInfo(x.LCID).ISOCurrencySymbol = CurrencySymbol)

        '    GetCultureInfosByCurrencySymbol = CultureInfos

        'End Function

#End Region

    End Module

End Namespace

