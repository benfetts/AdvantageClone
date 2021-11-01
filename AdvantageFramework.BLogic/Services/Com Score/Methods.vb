Namespace Services.ComScore

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\ComScore\", "RunAt", "01/01/2001 01:00 AM")>
            RunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\ComScore\", "EmployeeCode", "")>
            EmployeeCode
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _EventLog As System.Diagnostics.EventLog = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub _EventLog_EntryWritten(ByVal sender As Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles _EventLog.EntryWritten

            RaiseEvent EntryLogWrittenEvent(e.Entry)

        End Sub
        Private Sub SendFailureEmail(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, EmployeeIsValid As Boolean, EmployeeCode As String)

            If EmployeeIsValid Then

                AdvantageFramework.AlertSystem.CreateAlertForComscoreImport(DatabaseProfile, EmployeeCode)

            End If

        End Sub
        Private Sub GetDemographics(DbContext As AdvantageFramework.Database.DbContext, ClientID As String, ClientSecret As String, EndpointPath As String, UseNewURL As Boolean)

            'objects
            Dim Demographic As Services.ComScore.Classes.Demographic = Nothing
            Dim JSONString As String = Nothing
            Dim Api As Services.ComScore.Classes.Api = Nothing
            Dim Request As Services.ComScore.Classes.Request = Nothing
            Dim Response As Services.ComScore.Classes.Response = Nothing
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim JArrayColumns As Newtonsoft.Json.Linq.JArray = Nothing
            Dim Columns As List(Of String) = Nothing
            Dim JArray As Newtonsoft.Json.Linq.JArray = Nothing
            Dim DemographicResponseList As Generic.List(Of Services.ComScore.Classes.DemographicResponse) = Nothing
            Dim DemographicResponse As Services.ComScore.Classes.DemographicResponse = Nothing
            Dim JsonPropertyAttribute As Newtonsoft.Json.JsonPropertyAttribute = Nothing
            Dim UnderlyingType As System.Type = Nothing
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing
            Dim ComscoreGroupOwnerNameList As Generic.List(Of String) = Nothing

            Demographic = New Services.ComScore.Classes.Demographic
            Demographic.EndpointPath = EndpointPath & "metadata/demographics"
            Demographic.Request = "{}"

            JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(Demographic)

            If UseNewURL Then

                Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.COMSCORE_URL), ClientID, ClientSecret, 0)

            Else

                Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.OLD_COMSCORE_URL), ClientID, ClientSecret, 0)

            End If

            Request = New Services.ComScore.Classes.Request(JSONString)

            Do While Request IsNot Nothing

                Response = Api.RetrievePage(Request)

                If Response IsNot Nothing AndAlso Response.Status = "success" Then

                    JObject = Newtonsoft.Json.Linq.JObject.Parse(Response.RawResponse)

                    JArrayColumns = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_columns").ToString)

                    Columns = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(JArrayColumns.ToString)

                    JArray = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_rows").ToString)

                    DemographicResponseList = New Generic.List(Of Services.ComScore.Classes.DemographicResponse)

                    For i As Integer = 0 To JArray.Count - 1

                        DemographicResponse = New Services.ComScore.Classes.DemographicResponse

                        For Each Column In Columns

                            For Each PropertyInfo In DemographicResponse.GetType.GetProperties

                                JsonPropertyAttribute = (From A In PropertyInfo.GetCustomAttributes(False).OfType(Of Newtonsoft.Json.JsonPropertyAttribute)
                                                         Where A.PropertyName = Column).SingleOrDefault

                                If JsonPropertyAttribute IsNot Nothing Then

                                    UnderlyingType = AdvantageFramework.ClassUtilities.GetUnderlyingType(PropertyInfo.PropertyType)

                                    If UnderlyingType Is GetType(String) Then

                                        PropertyInfo.SetValue(DemographicResponse, JArray(i).Item(Columns.IndexOf(Column)).ToString)
                                        Exit For

                                    ElseIf UnderlyingType Is GetType(Decimal) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(DemographicResponse, CDec(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(Integer) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(DemographicResponse, CInt(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(Boolean) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(DemographicResponse, CBool(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(Date) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(DemographicResponse, CDate(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    End If

                                End If

                            Next

                        Next

                        DemographicResponseList.Add(DemographicResponse)

                    Next

                    Request = Api.NextPageRequest(Response)

                Else

                    Request = Nothing

                End If

            Loop

            If DemographicResponseList IsNot Nothing AndAlso DemographicResponseList.Count > 0 Then

                ComscoreGroupOwnerNameList = (From Entity In AdvantageFramework.Database.Procedures.ComscoreGroupOwner.Load(DbContext)
                                              Select Entity.Name.ToUpper).ToList

                For Each DemographicResponse In DemographicResponseList

                    MediaDemographic = DbContext.MediaDemographics.Where(Function(CS) CS.ComscoreDemoNumber = DemographicResponse.DemoNumber).SingleOrDefault

                    If MediaDemographic IsNot Nothing Then

                        If MediaDemographic.DbContext Is Nothing Then

                            DbContext.TryAttach(MediaDemographic)

                        End If

                        MediaDemographic.Code = "CS" & DemographicResponse.DemoNumber
                        MediaDemographic.Description = DemographicResponse.DemoName
                        MediaDemographic.IsSystem = True
                        MediaDemographic.Type = "T"

                        MediaDemographic.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Comscore
                        MediaDemographic.ComscoreDemoNumber = DemographicResponse.DemoNumber
                        MediaDemographic.IsComscoreTierA = DemographicResponse.IsDemoTierA
                        MediaDemographic.IsComscoreTierB = DemographicResponse.IsDemoTierB
                        MediaDemographic.IsComscoreTierC = DemographicResponse.IsDemoTierC
                        MediaDemographic.IsComscoreTierD = DemographicResponse.IsDemoTierD
                        MediaDemographic.IsComscoreNational = DemographicResponse.IsDemoNational
                        MediaDemographic.ComscoreGroupNumber = DemographicResponse.DemoGroupNumber
                        MediaDemographic.ComscoreSortOrder = DemographicResponse.DemoSortOrder
                        MediaDemographic.ComscoreGroupName = DemographicResponse.DemoGroupName
                        MediaDemographic.ComscoreGroupSortOrder = DemographicResponse.DemoGroupSortOrder
                        MediaDemographic.ComscoreGroupOwnerNumber = DemographicResponse.DemoGroupOwnerNumber
                        MediaDemographic.ComscoreGroupOwnerName = DemographicResponse.DemoGroupOwnerName

                        If Not ComscoreGroupOwnerNameList.Contains(MediaDemographic.ComscoreGroupOwnerName.ToUpper) Then

                            MediaDemographic.IsInactive = True

                        Else

                            MediaDemographic.IsInactive = False

                        End If

                        DbContext.Entry(MediaDemographic).State = Entity.EntityState.Modified

                    Else

                        MediaDemographic = New AdvantageFramework.Database.Entities.MediaDemographic

                        MediaDemographic.Code = "CS" & DemographicResponse.DemoNumber
                        MediaDemographic.Description = DemographicResponse.DemoName
                        MediaDemographic.IsSystem = True
                        MediaDemographic.Type = "T"

                        MediaDemographic.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Comscore
                        MediaDemographic.ComscoreDemoNumber = DemographicResponse.DemoNumber
                        MediaDemographic.IsComscoreTierA = DemographicResponse.IsDemoTierA
                        MediaDemographic.IsComscoreTierB = DemographicResponse.IsDemoTierB
                        MediaDemographic.IsComscoreTierC = DemographicResponse.IsDemoTierC
                        MediaDemographic.IsComscoreTierD = DemographicResponse.IsDemoTierD
                        MediaDemographic.IsComscoreNational = DemographicResponse.IsDemoNational
                        MediaDemographic.ComscoreGroupNumber = DemographicResponse.DemoGroupNumber
                        MediaDemographic.ComscoreSortOrder = DemographicResponse.DemoSortOrder
                        MediaDemographic.ComscoreGroupName = DemographicResponse.DemoGroupName
                        MediaDemographic.ComscoreGroupSortOrder = DemographicResponse.DemoGroupSortOrder
                        MediaDemographic.ComscoreGroupOwnerNumber = DemographicResponse.DemoGroupOwnerNumber
                        MediaDemographic.ComscoreGroupOwnerName = DemographicResponse.DemoGroupOwnerName

                        If Not ComscoreGroupOwnerNameList.Contains(MediaDemographic.ComscoreGroupOwnerName.ToUpper) Then

                            MediaDemographic.IsInactive = True

                        Else

                            MediaDemographic.IsInactive = False

                        End If

                        DbContext.MediaDemographics.Add(MediaDemographic)

                    End If

                Next

                DbContext.SaveChanges()

            End If

        End Sub
        Private Sub GetNetworks(DbContext As AdvantageFramework.Database.DbContext, ClientID As String, ClientSecret As String, EndpointPath As String, UseNewURL As Boolean)

            'objects
            Dim Network As Services.ComScore.Classes.Network = Nothing
            Dim JSONString As String = Nothing
            Dim Api As Services.ComScore.Classes.Api = Nothing
            Dim Request As Services.ComScore.Classes.Request = Nothing
            Dim Response As Services.ComScore.Classes.Response = Nothing
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim JArrayColumns As Newtonsoft.Json.Linq.JArray = Nothing
            Dim Columns As List(Of String) = Nothing
            Dim JArray As Newtonsoft.Json.Linq.JArray = Nothing
            Dim NetworkResponseList As Generic.List(Of Services.ComScore.Classes.NetworkResponse) = Nothing
            Dim NetworkResponse As Services.ComScore.Classes.NetworkResponse = Nothing
            Dim JsonPropertyAttribute As Newtonsoft.Json.JsonPropertyAttribute = Nothing
            Dim UnderlyingType As System.Type = Nothing
            Dim ComscoreNetwork As AdvantageFramework.Database.Entities.ComscoreNetwork = Nothing

            Network = New Services.ComScore.Classes.Network
            Network.EndpointPath = EndpointPath & "metadata/networks"
            Network.Request = "{}"

            JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(Network)

            If UseNewURL Then

                Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.COMSCORE_URL), ClientID, ClientSecret, 0)

            Else

                Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.OLD_COMSCORE_URL), ClientID, ClientSecret, 0)

            End If

            Request = New Services.ComScore.Classes.Request(JSONString)

            Do While Request IsNot Nothing

                Response = Api.RetrievePage(Request)

                If Response IsNot Nothing AndAlso Response.Status = "success" Then

                    JObject = Newtonsoft.Json.Linq.JObject.Parse(Response.RawResponse)

                    JArrayColumns = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_columns").ToString)

                    Columns = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(JArrayColumns.ToString)

                    JArray = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_rows").ToString)

                    NetworkResponseList = New Generic.List(Of Services.ComScore.Classes.NetworkResponse)

                    For i As Integer = 0 To JArray.Count - 1

                        NetworkResponse = New Services.ComScore.Classes.NetworkResponse

                        For Each Column In Columns

                            For Each PropertyInfo In NetworkResponse.GetType.GetProperties

                                JsonPropertyAttribute = (From A In PropertyInfo.GetCustomAttributes(False).OfType(Of Newtonsoft.Json.JsonPropertyAttribute)
                                                         Where A.PropertyName = Column).SingleOrDefault

                                If JsonPropertyAttribute IsNot Nothing Then

                                    UnderlyingType = AdvantageFramework.ClassUtilities.GetUnderlyingType(PropertyInfo.PropertyType)

                                    If UnderlyingType Is GetType(String) Then

                                        PropertyInfo.SetValue(NetworkResponse, JArray(i).Item(Columns.IndexOf(Column)).ToString)
                                        Exit For

                                    ElseIf UnderlyingType Is GetType(Integer) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(NetworkResponse, CInt(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    End If

                                End If

                            Next

                        Next

                        NetworkResponseList.Add(NetworkResponse)

                    Next

                    Request = Api.NextPageRequest(Response)

                Else

                    Request = Nothing

                End If

            Loop

            If NetworkResponseList IsNot Nothing AndAlso NetworkResponseList.Count > 0 Then

                For Each NetworkResponse In NetworkResponseList

                    ComscoreNetwork = DbContext.ComscoreNetworks.Where(Function(CS) CS.Number = NetworkResponse.NetworkNumber).SingleOrDefault

                    If ComscoreNetwork IsNot Nothing Then

                        If ComscoreNetwork.DbContext Is Nothing Then

                            DbContext.TryAttach(ComscoreNetwork)

                        End If

                        If ComscoreNetwork.Name <> NetworkResponse.NetworkName OrElse ComscoreNetwork.Type <> NetworkResponse.NetworkType Then

                            ComscoreNetwork.Name = NetworkResponse.NetworkName
                            ComscoreNetwork.Type = NetworkResponse.NetworkType

                            DbContext.Entry(ComscoreNetwork).State = Entity.EntityState.Modified

                        End If

                    Else

                        ComscoreNetwork = New AdvantageFramework.Database.Entities.ComscoreNetwork

                        ComscoreNetwork.Number = NetworkResponse.NetworkNumber
                        ComscoreNetwork.Name = NetworkResponse.NetworkName
                        ComscoreNetwork.Type = NetworkResponse.NetworkType

                        DbContext.ComscoreNetworks.Add(ComscoreNetwork)

                    End If

                Next

                DbContext.SaveChanges()

            End If

        End Sub
        Private Sub GetStations(DbContext As AdvantageFramework.Database.DbContext, ClientID As String, ClientSecret As String, EndpointPath As String, UseNewURL As Boolean)

            'objects
            Dim Station As Services.ComScore.Classes.Station = Nothing
            Dim JSONString As String = Nothing
            Dim Api As Services.ComScore.Classes.Api = Nothing
            Dim Request As Services.ComScore.Classes.Request = Nothing
            Dim Response As Services.ComScore.Classes.Response = Nothing
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim JArrayColumns As Newtonsoft.Json.Linq.JArray = Nothing
            Dim Columns As List(Of String) = Nothing
            Dim JArray As Newtonsoft.Json.Linq.JArray = Nothing
            Dim StationResponseList As Generic.List(Of Services.ComScore.Classes.StationResponse) = Nothing
            Dim StationResponse As Services.ComScore.Classes.StationResponse = Nothing
            Dim JsonPropertyAttribute As Newtonsoft.Json.JsonPropertyAttribute = Nothing
            Dim UnderlyingType As System.Type = Nothing
            Dim ComscoreTVStation As AdvantageFramework.Database.Entities.ComscoreTVStation = Nothing

            Station = New Services.ComScore.Classes.Station
            Station.EndpointPath = EndpointPath & "metadata/stations"
            Station.Request = "{}"

            JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(Station)

            If UseNewURL Then

                Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.COMSCORE_URL), ClientID, ClientSecret, 0)

            Else

                Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.OLD_COMSCORE_URL), ClientID, ClientSecret, 0)

            End If

            Request = New Services.ComScore.Classes.Request(JSONString)

            Do While Request IsNot Nothing

                Response = Api.RetrievePage(Request)

                If Response IsNot Nothing AndAlso Response.Status = "success" Then

                    JObject = Newtonsoft.Json.Linq.JObject.Parse(Response.RawResponse)

                    JArrayColumns = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_columns").ToString)

                    Columns = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(JArrayColumns.ToString)

                    JArray = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_rows").ToString)

                    StationResponseList = New Generic.List(Of Services.ComScore.Classes.StationResponse)

                    For i As Integer = 0 To JArray.Count - 1

                        StationResponse = New Services.ComScore.Classes.StationResponse

                        For Each Column In Columns

                            For Each PropertyInfo In StationResponse.GetType.GetProperties

                                JsonPropertyAttribute = (From A In PropertyInfo.GetCustomAttributes(False).OfType(Of Newtonsoft.Json.JsonPropertyAttribute)
                                                         Where A.PropertyName = Column).SingleOrDefault

                                If JsonPropertyAttribute IsNot Nothing Then

                                    UnderlyingType = AdvantageFramework.ClassUtilities.GetUnderlyingType(PropertyInfo.PropertyType)

                                    If UnderlyingType Is GetType(String) Then

                                        PropertyInfo.SetValue(StationResponse, JArray(i).Item(Columns.IndexOf(Column)).ToString)
                                        Exit For

                                    ElseIf UnderlyingType Is GetType(Integer) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(StationResponse, CInt(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    End If

                                End If

                            Next

                        Next

                        StationResponseList.Add(StationResponse)

                    Next

                    Request = Api.NextPageRequest(Response)

                Else

                    Request = Nothing

                End If

            Loop

            If StationResponseList IsNot Nothing AndAlso StationResponseList.Count > 0 Then

                For Each StationResponse In StationResponseList

                    ComscoreTVStation = DbContext.ComscoreTVStations.Where(Function(CS) CS.Number = StationResponse.StationNumber).SingleOrDefault

                    If ComscoreTVStation IsNot Nothing Then

                        If ComscoreTVStation.DbContext Is Nothing Then

                            DbContext.TryAttach(ComscoreTVStation)

                        End If

                        If ComscoreTVStation.CallLetters <> StationResponse.StationCallSign OrElse ComscoreTVStation.Name <> StationResponse.StationName OrElse
                                ComscoreTVStation.PrimaryMarketNumber <> StationResponse.StationPrimaryMarketNumber OrElse ComscoreTVStation.NetworkNumber <> StationResponse.StationAffiliatedNetworkNumber Then

                            ComscoreTVStation.CallLetters = StationResponse.StationCallSign
                            ComscoreTVStation.Name = StationResponse.StationName
                            ComscoreTVStation.PrimaryMarketNumber = StationResponse.StationPrimaryMarketNumber
                            ComscoreTVStation.NetworkNumber = StationResponse.StationAffiliatedNetworkNumber

                            DbContext.Entry(ComscoreTVStation).State = Entity.EntityState.Modified

                        End If

                    Else

                        ComscoreTVStation = New AdvantageFramework.Database.Entities.ComscoreTVStation

                        ComscoreTVStation.Number = StationResponse.StationNumber
                        ComscoreTVStation.CallLetters = StationResponse.StationCallSign
                        ComscoreTVStation.Name = StationResponse.StationName
                        ComscoreTVStation.PrimaryMarketNumber = StationResponse.StationPrimaryMarketNumber
                        ComscoreTVStation.NetworkNumber = StationResponse.StationAffiliatedNetworkNumber

                        DbContext.ComscoreTVStations.Add(ComscoreTVStation)

                    End If

                Next

                DbContext.SaveChanges()

            End If

        End Sub
        Public Sub ProcessDatabase(ByRef DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim EmployeeCode As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeIsValid As Boolean = True
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Timeout As Integer = 120000
            Dim ClientID As String = Nothing
            Dim ClientSecret As String = Nothing
            Dim AsClientID As String = Nothing
            Dim OldEndpointPath As String = Nothing
            Dim NewEndpointPath As String = Nothing
            Dim NewURLDate As Nullable(Of Date) = Nothing
            Dim UseNewURL As Boolean = True

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("ComScore connecting to database --> " & DatabaseProfile.DatabaseName)

                    Session = New AdvantageFramework.Security.Session(Security.Application.Advantage, DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName, 0, DatabaseProfile.ConnectionString)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            WriteToEventLog("ComScore load service settings --> " & DatabaseProfile.DatabaseName)

                            AdvantageFramework.Services.ComScore.LoadSettings(DataContext, Nothing, EmployeeCode)

                            WriteToEventLog("Validating Employee/User...")

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                            If Employee Is Nothing OrElse Employee.TerminationDate IsNot Nothing OrElse String.IsNullOrWhiteSpace(Employee.Email) Then

                                WriteToEventLog("Employee does not exist, or has been terminated or does not have email address.  EmployeeCode (" & EmployeeCode & ")")
                                EmployeeIsValid = False

                            End If

                            GetClientCredentials(DataContext, ClientID, ClientSecret, AsClientID, OldEndpointPath, NewEndpointPath, NewURLDate)

                            WriteToEventLog("ComScore GetData")

                            GetDemographics(DbContext, ClientID, ClientSecret, NewEndpointPath, UseNewURL)

                            GetNetworks(DbContext, ClientID, ClientSecret, NewEndpointPath, UseNewURL)

                            GetStations(DbContext, ClientID, ClientSecret, NewEndpointPath, UseNewURL)

                            WriteToEventLog("ComScore GetData complete")

                        End Using

                    End Using

                End If

            Catch ex As Exception

                SendFailureEmail(DatabaseProfile, EmployeeIsValid, EmployeeCode)

                If String.IsNullOrWhiteSpace(ex.Message) Then

                    WriteToEventLog("ComScore Error Processing - TIMEOUT --> " & DatabaseProfile.DatabaseName)

                Else

                    WriteToEventLog("ComScore Error Processing - " & ex.Message & " --> " & DatabaseProfile.DatabaseName)

                End If

            End Try

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim RunAt As Date = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.ComScore.RegistrySetting.RunAt), RunAt)

                                If RunAt = CDate("01/01/2001 01:00 AM") Then

                                    RunAt = Now.ToShortDateString & " " & RunAt.ToShortTimeString

                                End If

                                If DateDiff(DateInterval.Minute, RunAt, Now) >= 0 Then

                                    RunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.ComScore.RegistrySetting.RunAt, RunAt)

                                    ServiceIsReadyToRun = True

                                End If

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    ServiceIsReadyToRun = False
                End Try

            End If

            IsServiceReadyToRun = ServiceIsReadyToRun

        End Function
        Public Sub Run(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            If DatabaseProfile IsNot Nothing Then

                Try

                    If IsServiceReadyToRun(DatabaseProfile) Then

                        ProcessDatabase(DatabaseProfile)

                    End If

                Catch ex As Exception
                    WriteToEventLog("Error -->" & ex.Message)
                End Try

                WriteToEventLog("Running")

            End If

        End Sub
        Public Function LoadLogEntries() As String

            'objects
            Dim Log As String = ""

            Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

            LoadLogEntries = Log

        End Function
        Public Function LoadLog(ByVal LoadEntries As Boolean, Optional ByRef LastEntryMessage As String = "") As String

            'objects
            Dim Log As String = ""
            Dim Entry As System.Diagnostics.EventLogEntry = Nothing

            If System.Diagnostics.EventLog.SourceExists("ComScore Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("ComScore Source", "ComScore Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("ComScore Log", My.Computer.Name, "ComScore Source")

            _EventLog.ModifyOverflowPolicy(System.Diagnostics.OverflowAction.OverwriteAsNeeded, _EventLog.MinimumRetentionDays)

            _EventLog.EnableRaisingEvents = True

            If LoadEntries Then

                Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

                Try

                    Entry = _EventLog.Entries.OfType(Of System.Diagnostics.EventLogEntry).OrderByDescending(Function(EventLogEntry) EventLogEntry.TimeGenerated).FirstOrDefault

                Catch ex As Exception
                    Entry = Nothing
                End Try

                If Entry IsNot Nothing Then

                    LastEntryMessage = Entry.Message & "...."

                End If

            End If

            LoadLog = Log

        End Function
        Public Function LoadAdvantageService(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.AdvantageService

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            Try

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageComScoreWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.ComScore.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.ComScore.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.ComScore.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAt As Date, ByRef EmployeeCode As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.ComScore.RegistrySetting.RunAt), RunAt)

                EmployeeCode = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.ComScore.RegistrySetting.EmployeeCode)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAt As DateTime, EmployeeCode As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.ComScore.RegistrySetting.RunAt, RunAt)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.ComScore.RegistrySetting.EmployeeCode, EmployeeCode)

            End If

        End Sub
        Public Sub WriteToEventLog(Message As String)

            Try

                SyncLock _EventLog

                    _EventLog.WriteEntry(Message)

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub
        Public Sub ClearLog()

            Try

                SyncLock _EventLog

                    _EventLog.Clear()

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub
        Public Function LoadEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Employees = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                         Where Employee.Email IsNot Nothing AndAlso
                               Employee.Email <> ""
                         Select Employee).ToList

            LoadEmployees = Employees

        End Function
        Public Sub GetClientCredentials(DataContext As AdvantageFramework.Database.DataContext, ByRef ClientID As String, ByRef ClientSecret As String, ByRef AsClientID As String,
                                        ByRef OldEndpointPath As String, ByRef NewEndpointPath As String, ByRef NewURLDate As Nullable(Of Date))

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSCORE_CLIENT_ID.ToString)

            If Setting IsNot Nothing Then

                ClientID = AdvantageFramework.Security.Encryption.Decrypt(Setting.Value)

            End If

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSCORE_CLIENT_SECRET.ToString)

            If Setting IsNot Nothing Then

                ClientSecret = AdvantageFramework.Security.Encryption.Decrypt(Setting.Value)

            End If

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSCORE_AS_CLIENT_ID.ToString)

            If Setting IsNot Nothing Then

                AsClientID = AdvantageFramework.Security.Encryption.Decrypt(Setting.Value)

            End If

            OldEndpointPath = "/tv/v4/"

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSCORE_USE_NEW_URL.ToString)

            If Setting IsNot Nothing Then

                If (TypeOf Setting.Value Is Date AndAlso Setting.Value IsNot Nothing) Then

                    NewEndpointPath = "/mrtv/v7/"
                    NewURLDate = Setting.Value

                Else

                    NewEndpointPath = OldEndpointPath

                End If

            End If

        End Sub

#End Region

    End Module

End Namespace

