
'Copyright (c) 2015, ARPDev Pty. Ltd. (arpdev.com)
'All rights reserved.

Imports Aspose
Imports iCal

Namespace CalendarImportServices
    Public Enum CalendarResult
        Failure = 0
        Success = 1
    End Enum

    Public Enum CalendarPollState
        Expired = 0
        Changed = 1
    End Enum

    Class BasicHeaderBuilder
        Dim oWH As New System.Net.WebHeaderCollection

        Public Sub AddEntry(ByVal sEntryName As String, ByVal HeaderValue As String, Optional ByVal bClear As Boolean = False)
            Try
                If bClear Then
                    oWH.Clear()
                End If
                oWH.Add(sEntryName, HeaderValue)
            Catch ex As Exception

            End Try
        End Sub

        Public Function Serialise() As System.Net.WebHeaderCollection
            Return oWH
        End Function
    End Class

    Public Class CalendarURI


        Public StatusCode As Integer
        Public LastError As Integer
        Public QueryString As String
        Public Path As String
        Public Protocol As String
        Public Host As String
        Public Port As String

        Public Function IsSet() As Boolean
            Return Not String.IsNullOrEmpty(Path)
        End Function
        Sub New()
            'Empty Constructor implementation
        End Sub
        Public Sub Clone(ByRef Source As CalendarURI)
            Me.Path = Source.Path
            Me.Host = Source.Host
            Me.Port = Source.Port
            Me.Protocol = Source.Protocol
        End Sub

        Function Parse(uriString As String) As CalendarURI
            Dim uriResult As New CalendarURI
            If String.IsNullOrEmpty(uriString) Then
                Return uriResult
            End If

            'Source: https://tools.ietf.org/html/rfc3986#appendix-B

            Dim m As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(uriString, "^(([^:/?#]+):)?(//([^/?#]*))?([^?#]*)(\?([^#]*))?(#(.*))?", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            If m.Success Then
                '
                ' Lets get the parts of the URL
                '
                Protocol = m.Groups(2).Value
                Dim arrHost() As String = m.Groups(4).Value.Split(":")
                If Protocol.ToLower() = "https" Then
                    If Port = "" Then
                        Port = "443"
                    End If
                Else
                    Port = "80"
                End If

                If arrHost.Length() = 2 Then
                    Host = arrHost(0)
                    Port = arrHost(1)
                Else
                    Host = m.Groups(4).Value
                End If

                Path = m.Groups(5).Value
            End If
            Return uriResult
        End Function
        Function GetURL() As String
            Dim sURL As String
            If (Not String.IsNullOrEmpty(Protocol)) Then
                sURL = Protocol + "://" + Host + ":" + Port + Path
            Else
                sURL = Path
            End If
            Return sURL
        End Function

        Sub New(uriString As String)
            Parse(uriString)
        End Sub
    End Class

    Public Class CalendarFreeBusyResponse
        Public Property Response As String
        Public Property StatusString As String
    End Class

    Public Class CalendarHTTPRequest


        Public URI As CalendarURI
        Public Headers As New System.Net.WebHeaderCollection
        Public Body As String
        Public Verb As String

        Sub New(ByRef _CalendarConnection As CalendarConnection, ByVal _Verb As String, ByVal _URI As CalendarURI, ByRef _Headers As System.Net.WebHeaderCollection, ByVal _Body As String)
            URI = _URI
            Verb = _Verb
            If Not _Headers Is Nothing Then
                Headers = _Headers
            End If
            Body = _Body
        End Sub

    End Class

    Public Class CalendarHTTPResponse

        Public Result As CalendarResult
        Public Body As String
        Public StatusCode As Integer
        Public LastError As Integer
        Public Headers As New System.Net.WebHeaderCollection

    End Class


    Public Class CalendarItem

        Public Data As String
        Public ChangeTag As String
        Public URI As New CalendarURI
        Public ItemId As String
        Public ContentType As String

        Sub New()

        End Sub

        Sub New(ByRef ParentURI As CalendarURI, ByVal sItemID As String)
            URI = ParentURI
            ItemId = sItemID
        End Sub

        Sub New(ByRef ParentURI As CalendarURI, ByVal sItemID As String, ByVal sData As String, ByVal sContentType As String)
            URI = ParentURI
            ItemId = sItemID
            Data = sData
            ContentType = sContentType
        End Sub

    End Class


    Public Enum CalendarContainerType
        Undefined = 0
        Contacts = 1
        Calendar = 2
        Tasks = 3
        Directory = 4
        Folder = 5
    End Enum


    Public Class CalendarContainer

        Public bIsHomeSet As Boolean
        Public URI As CalendarURI
        Public DisplayName As String
        Public ChangeTag As String
        Public CurrentUserPrincipal As CalendarURI
        Public PrincipalURL As CalendarURI
        Public AddressBookHomeSet As CalendarURI
        Public CalendarHomeSet As CalendarURI
        Public GatewayDirectory As CalendarURI
        Public ScheduleDefaultCalendarURL As CalendarURI
        Public ScheduleOutboxURL As CalendarURI
        Public CalendarFolderType As CalendarContainerType
        Public bIsCollection As Boolean
        Public bSupportsTasks As Boolean
        Public bSupportsEvents As Boolean
        Public Items As New List(Of CalendarItem)

        Sub New()
            bIsHomeSet = False
        End Sub

        Sub New(_FolderURL As String)
            bIsHomeSet = False
            bSupportsEvents = False
            bSupportsTasks = False
            Try
                URI = New CalendarURI(_FolderURL)
            Catch ex As Exception
                'an unparsable url eas issued
                Throw ex
            End Try
        End Sub

        Function GetHomeSetURIByType(CalendarFolderType As CalendarContainerType) As CalendarURI
            Select Case (CalendarFolderType)
                Case CalendarContainerType.Contacts
                    GetHomeSetURIByType = AddressBookHomeSet
                Case CalendarContainerType.Directory
                    GetHomeSetURIByType = AddressBookHomeSet
                Case CalendarContainerType.Calendar
                    GetHomeSetURIByType = CalendarHomeSet
                Case CalendarContainerType.Tasks
                    GetHomeSetURIByType = CalendarHomeSet
                Case Else
                    GetHomeSetURIByType = CalendarHomeSet
            End Select
        End Function
    End Class


    Public Class FeatureSupport

        Private Features As New List(Of KeyValuePair(Of String, String))

        Public Function AddFeature(FeatureId As String, Value As String) As Integer
            AddFeature = 1
            Try
                Features.Add(New KeyValuePair(Of String, String)(FeatureId, Value))
            Catch ex As Exception
                AddFeature = 0
                Debug.Assert(False)
            End Try
        End Function
        Public Function HasFeature(FeatureId As String) As Boolean
            HasFeature = False
            For Each pair As KeyValuePair(Of String, String) In Features
                If pair.Key.ToUpper = FeatureId.ToUpper Then
                    HasFeature = True
                    Exit For
                End If
            Next
        End Function

    End Class

    Public Class CalendarConnection

        Public Property Host As String
        Public UserName As String
        Public Password As String
        Public Port As Integer
        Public isSSL As Boolean
        Public ProxyUserName As String
        Public ProxyPassword As String
        Public ServerCapability As New FeatureSupport
        Public LogString As String
        Public bLog As Boolean

        Sub New(_Host As String, _IsSSL As Boolean, _UserName As String, _Password As String)
            'Parses the host string to determine if a port has been passed (and uses it accordingly)
            Dim sHost As String = _Host
            Dim iPort As Integer = IIf(_IsSSL, 443, 80)
            If _Host.Contains(":") Then
                Dim arrHost() As String = _Host.Split(":")
                sHost = arrHost(0)
                iPort = CInt(arrHost(1))
            End If
            Me.SetConnection(sHost, iPort, _IsSSL, _UserName, _Password)
        End Sub

        Sub New(_Host As String, _Port As Integer, _IsSSL As Boolean, _UserName As String, _Password As String)
            Me.SetConnection(_Host, _Port, _IsSSL, _UserName, _Password)
        End Sub

        Sub New()

        End Sub

        Sub SetConnection(_Host As String, _Port As Integer, _IsSSL As Boolean, _UserName As String, _Password As String)
            Me.Host = _Host
            Me.Port = _Port
            Me.isSSL = _IsSSL
            Me.UserName = _UserName
            Me.Password = _Password
            Me.bLog = False
        End Sub

        Public Enum RequestRedirections
            AllowRedirections = 0
            NoRedirections = 1
            ResubmitAuthenticatedRedirections = 2
        End Enum

        Public Function IssueRequest(ByRef davRequest As CalendarHTTPRequest, Optional ByVal RedirectionBehavior As RequestRedirections = RequestRedirections.AllowRedirections, Optional ByVal MaximumRedirects As Integer = 5) As CalendarHTTPResponse
            Dim _CalendarResponse As New CalendarHTTPResponse
            Try
                Dim _HTTPCalendarRequest As System.Net.HttpWebRequest = Nothing
                Dim webResponse As System.Net.HttpWebResponse = Nothing

                If Not String.IsNullOrEmpty(Me.ProxyUserName) Then
                    'Set Proxy settings if we were passed them
                    _HTTPCalendarRequest.Proxy.Credentials = New System.Net.NetworkCredential(Me.ProxyUserName, Me.ProxyPassword)
                End If

                Dim bReIssueRequest As Boolean
                Dim NumAttempts As Integer = 0
                Do
                    NumAttempts += 1
                    bReIssueRequest = False

                    If String.IsNullOrEmpty(davRequest.URI.Protocol) Then
                        'We need to copy the settings from the connection (since we presumably only have a Path supplied in the URI)
                        davRequest.URI.Host = Me.Host
                        If (Me.isSSL) Then
                            davRequest.URI.Protocol = "https"
                        Else
                            davRequest.URI.Protocol = "http"
                        End If
                        davRequest.URI.Port = Me.Port.ToString
                    Else
                        If (String.IsNullOrEmpty(davRequest.URI.Port)) Then
                            davRequest.URI.Port = Me.Port.ToString
                        End If
                    End If

                    Dim sURI As String = davRequest.URI.GetURL()
                    _HTTPCalendarRequest = System.Net.WebRequest.Create(sURI)

                    If Not String.IsNullOrEmpty(Me.UserName) Then
                        _HTTPCalendarRequest.Credentials = New System.Net.NetworkCredential(Me.UserName, Me.Password)
                    End If

                    _HTTPCalendarRequest.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested
                    _HTTPCalendarRequest.Method = davRequest.Verb

                    _HTTPCalendarRequest.ContentType = "text/xml"
                    'Apply the headers to the request - yes, this is ugly to regenerate the headers (but it is the only simple way)
                    If Not davRequest.Headers Is Nothing Then
                        For iHeader = 0 To davRequest.Headers.Count - 1
                            Try
                                If davRequest.Headers.Keys(iHeader).ToLower() = "content-type" Then
                                    _HTTPCalendarRequest.ContentType = davRequest.Headers.Item(iHeader)
                                Else
                                    _HTTPCalendarRequest.Headers.Add(davRequest.Headers.Keys(iHeader), davRequest.Headers.Item(iHeader))
                                End If
                            Catch ex As Exception
                                Debug.Assert(False, ex.Message)
                            End Try
                        Next
                    End If

                    If Not String.IsNullOrEmpty(davRequest.Body) Then
                        ' Get Requests should not send bodies
                        Using RequestStream As New System.IO.StreamWriter(_HTTPCalendarRequest.GetRequestStream())
                            RequestStream.Write(davRequest.Body)
                        End Using
                    End If

                    Select Case RedirectionBehavior
                        Case RequestRedirections.AllowRedirections
                            _HTTPCalendarRequest.AllowAutoRedirect = True
                            _HTTPCalendarRequest.MaximumAutomaticRedirections = MaximumRedirects
                            webResponse = _HTTPCalendarRequest.GetResponse()

                        Case RequestRedirections.NoRedirections
                            _HTTPCalendarRequest.AllowAutoRedirect = False
                            webResponse = _HTTPCalendarRequest.GetResponse()

                        Case RequestRedirections.ResubmitAuthenticatedRedirections
                            'If we get a 302, then we will re-issue the request
                            _HTTPCalendarRequest.AllowAutoRedirect = False
                            webResponse = _HTTPCalendarRequest.GetResponse()
                            If webResponse.StatusCode = Net.HttpStatusCode.Moved Or webResponse.StatusCode = Net.HttpStatusCode.MovedPermanently Then
                                'Set the location and give it another go
                                davRequest.URI.Parse(webResponse.GetResponseHeader("Location"))
                                bReIssueRequest = True
                            End If
                    End Select
                Loop While bReIssueRequest = True And NumAttempts <= MaximumRedirects

                If Not webResponse Is Nothing Then
                    Using stream As System.IO.Stream = webResponse.GetResponseStream()
                        Dim reader As New System.IO.StreamReader(stream, System.Text.Encoding.UTF8)
                        _CalendarResponse.Body = reader.ReadToEnd()
                    End Using
                    _CalendarResponse.StatusCode = webResponse.StatusCode

                End If
                _CalendarResponse.Result = CalendarResult.Success
            Catch ex As Exception
                _CalendarResponse.Result = CalendarResult.Failure
            End Try
            Return _CalendarResponse
        End Function

    End Class

    Public Class CalendarFolder
        Inherits CalendarContainer

        Private Connection As CalendarClient

        Public Sub New(ByRef dc As CalendarClient)
            Connection = dc
        End Sub

        Public Function CreateItem(ByRef vci As VCard) As CalendarItem
            CreateItem = Nothing
            Dim di As New CalendarItem(Me.URI, vci.GetItemId(), vci.Serialise(), "text/vcard")
            If (Connection.addCalendarItem(di, False)) Then
                CreateItem = di
            End If
        End Function

        Public Function CreateItem(ByRef vci As VCalendar) As CalendarItem
            CreateItem = Nothing
            Dim di As New CalendarItem(Me.URI, vci.GetItemId(), vci.Serialise(), "text/calendar")
            If (Connection.addCalendarItem(di, False)) Then
                CreateItem = di
            End If
        End Function

        Function ListItems() As CalendarResult
            Return Connection.getItems(Me)
        End Function

        Public Function UpdateItem(ByVal ItemId As String, ByRef vci As VCalendar) As Boolean
            Return Connection.updateCalendarItem(New CalendarItem(Me.URI, ItemId, vci.Serialise(), "text/calendar")) = CalendarResult.Success
        End Function

        Public Function UpdateItem(ByVal ItemId As String, ByRef vci As VCard) As Boolean
            Return Connection.updateCalendarItem(New CalendarItem(Me.URI, ItemId, vci.Serialise(), "text/vcard")) = CalendarResult.Success
        End Function

        Public Function DeleteItem(ByVal ItemId As String) As Boolean
            Return Connection.deleteCalendarItem(New CalendarItem(Me.URI, ItemId)) = CalendarResult.Success
        End Function

    End Class

    Public Class CalendarClient
        Inherits CalendarConnection

        Function GetContainerTypeByName(ByVal sFolderKey As String) As CalendarContainerType
            If sFolderKey.ToLower.Contains("calendar") Then
                Return CalendarContainerType.Calendar
            ElseIf sFolderKey.ToLower.Contains("tasks") Then
                Return CalendarContainerType.Tasks
            ElseIf sFolderKey.ToLower.Contains("contacts") Then
                Return CalendarContainerType.Contacts
            ElseIf sFolderKey.ToLower.Contains("$gal") Then
                Return CalendarContainerType.Directory
            Else
                Return CalendarContainerType.Folder
            End If
        End Function

        Function GetFolder(ByVal sFolderKey As String, Optional ByVal bAllowDiscovery As Boolean = True, Optional ByVal FolderType As CalendarContainerType = CalendarContainerType.Undefined) As CalendarFolder
            Dim ResolvedFolder As CalendarContainer = Nothing
            GetFolder = Nothing
            For Each fi As KeyValuePair(Of String, CalendarFolder) In FolderItems
                If fi.Key = sFolderKey Then
                    ResolvedFolder = fi.Value
                    Exit For
                End If
            Next
            '
            ' If we were passed an Undefined value
            '
            If FolderType = CalendarContainerType.Undefined Then
                FolderType = GetContainerTypeByName(sFolderKey)
            End If

            If ResolvedFolder Is Nothing And bAllowDiscovery Then
                'We should attempt to locate the folder using it's type (and possibly name)
                ResolvedFolder = New CalendarFolder(Me)
                If FolderType = CalendarContainerType.Folder Then
                    'Lets try to get it
                    If getObjectRequest(New CalendarURI(sFolderKey), FolderType, ResolvedFolder) = CalendarResult.Success Then
                        FolderItems.Add(New KeyValuePair(Of String, CalendarFolder)(sFolderKey, ResolvedFolder))
                    Else
                        ResolvedFolder = Nothing
                    End If
                Else
                    ' Locate the desired resource by ContainerType (in this case Calendar Folder)
                    If discoverResource(ResolvedFolder, FolderType) = CalendarResult.Success Then
                        FolderItems.Add(New KeyValuePair(Of String, CalendarFolder)(sFolderKey, ResolvedFolder))
                    Else
                        ResolvedFolder = Nothing
                    End If
                End If
            End If
            Return ResolvedFolder
        End Function

        Public Sub FetchFolders(Optional ByVal bReload As Boolean = False)
            If bReload Then
                Me.FolderItems.Clear()
            End If
            If Me.FolderItems.Count = 0 Then
                Me.GetFolder("Contacts", True, CalendarContainerType.Contacts)
                Me.GetFolder("Calendar", True, CalendarContainerType.Calendar)
                Me.GetFolder("Tasks", True, CalendarContainerType.Tasks)
                Me.GetFolder("$GAL", True, CalendarContainerType.Directory)
            End If
        End Sub

        Public FolderItems As New List(Of KeyValuePair(Of String, CalendarFolder))

        Private Const Feature_Calendar_Report_MultiGet = "report/calendar-multiget"
        Private Const Feature_Calendar_Report_SyncCollection = "report/calendar-sync-collection"

        Sub New()
        End Sub

        Sub New(_Host As String, _Port As Integer, _IsSSL As Boolean, _UserName As String, _Password As String)
            MyBase.New(_Host, _Port, _IsSSL, _UserName, _Password)
        End Sub

        Sub New(_Host As String, _IsSSL As Boolean, _UserName As String, _Password As String)
            MyBase.New(_Host, _IsSSL, _UserName, _Password)
        End Sub

        Function GetXMLNodeString(ByRef pNode As System.Xml.XmlNode, ByRef TargetBuffer As String) As Boolean
            GetXMLNodeString = True
            Try
                If Not pNode Is Nothing Then
                    TargetBuffer = pNode.InnerText()
                Else
                    TargetBuffer = String.Empty
                End If
            Catch ex As Exception
                TargetBuffer = String.Empty
                GetXMLNodeString = False
            End Try
        End Function

        Sub GetXMLNodeURI(ByRef pNode As System.Xml.XmlNode, ByRef TargetURI As CalendarURI)
            Dim sURL As String = ""
            GetXMLNodeString(pNode, sURL)
            TargetURI = New CalendarURI(sURL)
        End Sub

        Function parseObjectProperties(ByRef oXMLDoc As System.Xml.XmlDocument, ByRef CalendarObject As CalendarContainer) As CalendarResult

            parseObjectProperties = CalendarResult.Success

            Dim nsm As New System.Xml.XmlNamespaceManager(oXMLDoc.NameTable)
            nsm.AddNamespace("C", "urn:ietf:params:xml:ns:caldav")
            nsm.AddNamespace("D", "DAV:")
            nsm.AddNamespace("A", "urn:ietf:params:xml:ns:carddav")

            GetXMLNodeURI(oXMLDoc.SelectSingleNode("//D:response/D:href", nsm), CalendarObject.URI)
            GetXMLNodeURI(oXMLDoc.SelectSingleNode("//D:current-user-principal/D:href", nsm), CalendarObject.CurrentUserPrincipal)
            GetXMLNodeURI(oXMLDoc.SelectSingleNode("//D:current-user-principal/D:href", nsm), CalendarObject.PrincipalURL)
            GetXMLNodeURI(oXMLDoc.SelectSingleNode("//A:addressbook-home-set/D:href", nsm), CalendarObject.AddressBookHomeSet)
            GetXMLNodeURI(oXMLDoc.SelectSingleNode("//C:calendar-home-set/D:href", nsm), CalendarObject.CalendarHomeSet)
            GetXMLNodeURI(oXMLDoc.SelectSingleNode("//C:schedule-outbox-URL/D:href", nsm), CalendarObject.ScheduleOutboxURL)
            GetXMLNodeURI(oXMLDoc.SelectSingleNode("//A:directory-gateway/D:href", nsm), CalendarObject.GatewayDirectory)
            GetXMLNodeURI(oXMLDoc.SelectSingleNode("//C:schedule-default-calendar-URL/D:href", nsm), CalendarObject.ScheduleDefaultCalendarURL)
            'check if it is a task capable folder
            CalendarObject.bSupportsTasks = Not oXMLDoc.SelectSingleNode("//C:supported-calendar-component-set/C:comp[name='VTODO']", nsm) Is Nothing
            CalendarObject.bSupportsEvents = Not oXMLDoc.SelectSingleNode("//C:supported-calendar-component-set/C:comp[name='VEVENT']", nsm) Is Nothing

            'check the version of vcard supported

            CalendarObject.bIsCollection = False
            If (Not oXMLDoc.SelectSingleNode("//D:resourcetype/D:collection", nsm) Is Nothing) Then
                CalendarObject.bIsCollection = True
            End If
            CalendarObject.CalendarFolderType = CalendarContainerType.Calendar ' Initial value

            If (Not oXMLDoc.SelectSingleNode("//D:resourcetype/C:calendar", nsm) Is Nothing) Then
                CalendarObject.CalendarFolderType = CalendarContainerType.Calendar ' Initial value
            End If

            If (Not oXMLDoc.SelectSingleNode("//D:resourcetype/A:addressbook", nsm) Is Nothing) Then
                CalendarObject.CalendarFolderType = CalendarContainerType.Contacts
            End If

            If (Not oXMLDoc.SelectSingleNode("//D:resourcetype/A:directory", nsm) Is Nothing) Then
                CalendarObject.CalendarFolderType = CalendarContainerType.Directory
            End If

            If (Not oXMLDoc.SelectSingleNode("//D:supported-report-set/D:supported-report/D:report/D:sync-collection", nsm) Is Nothing) Then
                Me.ServerCapability.AddFeature(Feature_Calendar_Report_SyncCollection, "")
            End If
            If (Not oXMLDoc.SelectSingleNode("//D:supported-report-set/D:supported-report/D:report/C:calendar-multiget", nsm) Is Nothing) Then
                Me.ServerCapability.AddFeature(Feature_Calendar_Report_MultiGet, "")
            End If

        End Function

        Function parseObjectResponse(ByRef davResponse As CalendarHTTPResponse, ByRef CalendarObject As CalendarContainer) As CalendarResult

            parseObjectResponse = CalendarResult.Failure
            If Not String.IsNullOrEmpty(davResponse.Body) Then
                'We want to load the XML and then call parse object properties

                Try
                    Dim oXMLDoc As New System.Xml.XmlDocument()
                    oXMLDoc.LoadXml(davResponse.Body)
                    parseObjectResponse = parseObjectProperties(oXMLDoc, CalendarObject)
                Catch ex As Exception
                    parseObjectResponse = CalendarResult.Failure
                End Try
            End If
        End Function

        Public Function searchForObject(ByRef oXMLDoc As System.Xml.XmlDocument, ByRef CalendarObject As CalendarContainer, FolderType As CalendarContainerType) As CalendarResult
            Dim Result As CalendarResult = CalendarResult.Failure ' we will iterate until success anyway

            Dim nsm As New System.Xml.XmlNamespaceManager(oXMLDoc.NameTable)
            nsm.AddNamespace("C", "urn:ietf:params:xml:ns:caldav")
            nsm.AddNamespace("D", "DAV:")
            nsm.AddNamespace("A", "urn:ietf:params:xml:ns:carddav")

            Dim pNodelist As System.Xml.XmlNodeList = oXMLDoc.SelectNodes("//D:response", nsm)
            For Each pResponseNode As System.Xml.XmlNode In pNodelist
                Try

                    Select Case (FolderType)
                        Case CalendarContainerType.Contacts
                            Dim bIsAddressBook As Boolean = (Not pResponseNode.SelectSingleNode("D:propstat/D:prop/D:resourcetype/A:addressbook", nsm) Is Nothing)
                            If (bIsAddressBook) Then
                                GetXMLNodeURI(pResponseNode.SelectSingleNode("D:href", nsm), CalendarObject.URI)
                                Result = CalendarResult.Success
                            End If
                        Case CalendarContainerType.Tasks

                            Dim bIsCalendar As Boolean = (Not pResponseNode.SelectSingleNode("D:propstat/D:prop/D:resourcetype/C:calendar", nsm) Is Nothing)
                            If (bIsCalendar) Then
                                CalendarObject.bSupportsTasks = Not (pResponseNode.SelectSingleNode("D:propstat/D:prop/C:supported-calendar-component-set/C:comp[@name='VTODO']", nsm) Is Nothing)
                                If (CalendarObject.bSupportsTasks) Then
                                    Dim sURI As String = ""
                                    GetXMLNodeString(pResponseNode.SelectSingleNode("D:href", nsm), sURI)
                                    CalendarObject.URI = New CalendarURI(sURI)
                                    Result = CalendarResult.Success
                                End If
                            End If
                        Case CalendarContainerType.Directory
                            Dim bIsAddressBook As Boolean = Not (pResponseNode.SelectSingleNode("D:propstat/D:prop/D:resourcetype/A:directory", nsm) Is Nothing)
                            If (bIsAddressBook) Then
                                GetXMLNodeURI(pResponseNode.SelectSingleNode("D:href", nsm), CalendarObject.URI)
                                Result = CalendarResult.Success
                            End If
                        Case Else 'CalendarContainerType.Calendar
                            Dim bIsCalendar As Boolean = (Not pResponseNode.SelectSingleNode("D:propstat/D:prop/D:resourcetype/C:calendar", nsm) Is Nothing)
                            If (bIsCalendar) Then
                                CalendarObject.bSupportsEvents = Not pResponseNode.SelectSingleNode("D:propstat/D:prop/C:supported-calendar-component-set/C:comp[@name='VEVENT']", nsm) Is Nothing
                                If Not CalendarObject.bSupportsEvents Then
                                    '
                                    ' If the server does not return the supported-calendar-component-set property then we would be best to assume that they do support VEVENT. 
                                    '
                                    If (pResponseNode.SelectSingleNode("D:propstat/D:prop/C:supported-calendar-component-set/C:comp", nsm) Is Nothing) Then
                                        CalendarObject.bSupportsEvents = True
                                    End If
                                End If


                                If (CalendarObject.bSupportsEvents) Then
                                    GetXMLNodeURI(pResponseNode.SelectSingleNode("D:href", nsm), CalendarObject.URI)
                                    Result = CalendarResult.Success
                                End If
                            End If
                    End Select
                    If (Result = CalendarResult.Success) Then

                        Exit For
                    End If

                Catch ex As Exception
                    Debug.Assert(False)
                End Try


            Next
            Return Result

        End Function

        Public Function resolveObjectRequest(ByRef HomeSetURL As CalendarURI, ByRef CalendarObject As CalendarContainer, Optional FolderType As CalendarContainerType = CalendarContainerType.Calendar) As CalendarResult
            Dim Result As CalendarResult
            Result = CalendarResult.Success
            Try
                Dim sRequest As String = "<A:propfind xmlns:A=""DAV:"">"
                sRequest += "<A:prop>"
                sRequest += "<A:current-user-principal/>"
                sRequest += "<A:principal-URL/>"
                sRequest += "<A:resourcetype/>"
                If ((FolderType = CalendarContainerType.Calendar) Or (FolderType = CalendarContainerType.Tasks)) Then
                    sRequest += "<C:supported-calendar-component-set xmlns:C=""urn:ietf:params:xml:ns:caldav""/>"
                End If
                sRequest += "</A:prop>"
                sRequest += "</A:propfind>"

                Dim Headers As New BasicHeaderBuilder
                Headers.AddEntry("Content-Type", "text/xml")
                Headers.AddEntry("Depth", "1")
                Dim davRequest As New CalendarHTTPRequest(Me, "PROPFIND", HomeSetURL, Headers.Serialise(), sRequest)
                Dim davResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest)

                Result = davResponse.Result
                If (Result = CalendarResult.Success) Then
                    Result = parseResolveObjectRequest(davResponse, CalendarObject, FolderType)
                    If Me.bLog Then
                        Me.LogString += "Attempted to locate collection at: " + HomeSetURL.GetURL + ". Status=" + davResponse.StatusCode
                    End If
                End If
                If (Result = CalendarResult.Success) Then
                    ' lets set the homeset server details, since it is possible that the homeset url is differnet to the refering server (as is the case for apple and large installs)
                    If (Not CalendarObject.URI.IsSet()) Then
                        CalendarObject.URI = HomeSetURL
                    End If
                Else
                    If (Me.bLog) Then
                        If (davResponse.LastError = 0) Then
                            Me.LogString += ", Collectioon could not be found "
                        End If
                        Me.LogString += "." & vbCrLf
                    End If
                End If

            Catch ex As Exception
                Result = CalendarResult.Failure

            End Try
            Return Result
        End Function

        Function parseResolveObjectRequest(ByRef davResponse As CalendarHTTPResponse, ByRef CalendarObject As CalendarContainer, FolderType As CalendarContainerType) As CalendarResult
            parseResolveObjectRequest = CalendarResult.Success
            If Not String.IsNullOrEmpty(davResponse.Body) Then
                Try
                    ' Load the XML and then call parse object properties
                    Dim oXMLDoc As New System.Xml.XmlDocument()
                    oXMLDoc.LoadXml(davResponse.Body)

                    parseResolveObjectRequest = parseObjectProperties(oXMLDoc, CalendarObject)
                    parseResolveObjectRequest = searchForObject(oXMLDoc, CalendarObject, FolderType)

                Catch ex As Exception
                    parseResolveObjectRequest = CalendarResult.Failure
                End Try
            End If
        End Function

        Public Function parseObjectState(ByRef davResponse As CalendarHTTPResponse, ByRef CalendarContainerProps As CalendarContainer, ByVal _CalendarFolderType As CalendarContainerType)
            parseObjectState = CalendarResult.Success
            If Not String.IsNullOrEmpty(davResponse.Body) Then
                Try
                    ' Load the XML and then call parse object properties
                    Dim oXMLDoc As New System.Xml.XmlDocument()
                    oXMLDoc.LoadXml(davResponse.Body)
                    Dim nsm As New System.Xml.XmlNamespaceManager(oXMLDoc.NameTable)
                    nsm.AddNamespace("C", "urn:ietf:params:xml:ns:caldav")
                    nsm.AddNamespace("D", "DAV:")
                    nsm.AddNamespace("A", "urn:ietf:params:xml:ns:carddav")
                    nsm.AddNamespace("CS", "http://calendarserver.org/ns/")
                    GetXMLNodeString(oXMLDoc.SelectSingleNode("//D:prop/D:displayname", nsm), CalendarContainerProps.DisplayName)
                    CalendarContainerProps.ChangeTag = String.Empty
                    If _CalendarFolderType = CalendarContainerType.Calendar Or _CalendarFolderType = CalendarContainerType.Tasks Then
                        GetXMLNodeString(oXMLDoc.SelectSingleNode("//D:prop/CS:getctag", nsm), CalendarContainerProps.ChangeTag)
                    End If
                    If String.IsNullOrEmpty(CalendarContainerProps.ChangeTag) Then
                        'try the e-tag:getetag (in the case of addressbook item - or anything other than a scheduling item)
                        GetXMLNodeString(oXMLDoc.SelectSingleNode("//D:prop/D:getetag"), CalendarContainerProps.ChangeTag)
                    End If
                Catch ex As Exception
                    parseObjectState = CalendarResult.Failure
                End Try
            Else
                parseObjectState = CalendarResult.Failure
            End If

        End Function

        Public Function getObjectState(ByRef CalendarContainerProps As CalendarContainer, ByVal _CalendarFolderType As CalendarContainerType) As CalendarResult
            'Returns the properties of an object (to allowing subscriber to determine if it changed)
            getObjectState = CalendarResult.Success
            Dim sRequest As String = "<d:propfind xmlns:d=""DAV:"""
            If _CalendarFolderType = CalendarContainerType.Calendar Or _CalendarFolderType = CalendarContainerType.Tasks Then
                sRequest += " xmlns:cs=""http://calendarserver.org/ns/"">"
            End If
            sRequest += ">"
            sRequest += "<d:prop>"
            sRequest += "<d:displayname/>"

            If _CalendarFolderType = CalendarContainerType.Calendar Or _CalendarFolderType = CalendarContainerType.Tasks Then
                sRequest += "<cs:getctag/>"
            End If

            sRequest += "<d:getetag/>"
            sRequest += "</d:prop>"
            sRequest += "</d:propfind>"

            Dim Headers As New System.Net.WebHeaderCollection()
            Headers.Add("Content-Type", "text/xml")

            Dim davRequest As New CalendarHTTPRequest(Me, "PROPFIND", CalendarContainerProps.URI, Headers, sRequest)
            Dim davResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest)

            getObjectState = davResponse.Result
            If _CalendarFolderType = CalendarContainerType.Calendar Then
                parseObjectState(davResponse, CalendarContainerProps, _CalendarFolderType)
            Else
                parseObjectState(davResponse, CalendarContainerProps, _CalendarFolderType)
            End If
        End Function

        Public Function getObjectRequest(ServiceURL As CalendarURI, ByVal _CalendarFolderType As CalendarContainerType, ByRef CalendarObject As CalendarContainer) As CalendarResult
            Dim Result As CalendarResult = CalendarResult.Success

            Dim sRequest As String = "<D:propfind xmlns:D=""DAV:"">"
            sRequest += "<D:prop>"
            sRequest += "<D:current-user-principal/>"
            sRequest += "<D:principal-URL/>"
            sRequest += "<D:resourcetype/>"

            If ((_CalendarFolderType = CalendarContainerType.Calendar) Or (_CalendarFolderType = CalendarContainerType.Tasks)) Then
                sRequest += "<C:schedule-outbox-URL xmlns:C=""urn:ietf:params:xml:ns:caldav""/>"
                sRequest += "<C:calendar-home-set xmlns:C=""urn:ietf:params:xml:ns:caldav""/>"
                sRequest += "<C:supported-calendar-data xmlns:C=""urn:ietf:params:xml:ns:caldav""/>"
                sRequest += "<D:supported-report-set/>"
            End If

            If ((_CalendarFolderType = CalendarContainerType.Contacts) Or (_CalendarFolderType = CalendarContainerType.Directory)) Then
                sRequest += "<V:addressbook-home-set xmlns:V=""urn:ietf:params:xml:ns:carddav""/>"
                sRequest += "<V:directory-gateway xmlns:V=""urn:ietf:params:xml:ns:carddav""/>"
                sRequest += "<C:supported-address-data xmlns:C=""urn:ietf:params:xml:ns:carddav""/>"
                sRequest += "<D:supported-report-set/>"
            End If

            sRequest += "</D:prop>"
            sRequest += "</D:propfind>"

            Dim Headers As New System.Net.WebHeaderCollection()
            Headers.Add("Content-Type", "text/xml")

            Dim davRequest As New CalendarHTTPRequest(Me, "PROPFIND", ServiceURL, Headers, sRequest)
            Dim davResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest, RequestRedirections.ResubmitAuthenticatedRedirections)

            Result = davResponse.Result

            If Me.bLog Then
                Me.LogString += "Attempted to locate resource at: " + ServiceURL.ToString() + ". Status=" + davResponse.StatusCode
                If (davResponse.LastError <> 0) Then
                    Me.LogString += ", Error =" + davResponse.LastError
                End If
                Me.LogString += "." & vbCrLf
            End If

            If Result = CalendarResult.Success Then
                If (Not CalendarObject.bIsHomeSet) Then
                    Result = parseObjectResponse(davResponse, CalendarObject)
                    If Result = CalendarResult.Success Then
                        'lets get some of the details used to fetch the result
                        CalendarObject.URI = davRequest.URI
                    End If
                End If
            Else
                ServiceURL.LastError = davResponse.LastError
                ServiceURL.StatusCode = davResponse.StatusCode
            End If
            getObjectRequest = Result
        End Function

        Public Function discoverResource(ByRef CalendarFolder As CalendarContainer, Optional CalendarFolderType As CalendarContainerType = CalendarContainerType.Calendar, Optional WellKnownHint As String = Nothing) As CalendarResult
            Dim CurrentUserPrincipalQuery As New CalendarContainer
            Dim Result As CalendarResult = CalendarResult.Success

            If String.IsNullOrEmpty(WellKnownHint) Then
                'We want to set it accoridng to the ContainerType
                If CalendarFolderType = CalendarContainerType.Calendar Or CalendarFolderType = CalendarContainerType.Tasks Then
                    WellKnownHint = "/.well-known/caldav"
                ElseIf CalendarFolderType = CalendarContainerType.Contacts Or CalendarFolderType = CalendarContainerType.Directory Then
                    WellKnownHint = "/.well-known/carddav"
                Else
                    WellKnownHint = Nothing 'Skip it and resolve with other qualifiers 
                End If
            End If

            If Not String.IsNullOrEmpty(WellKnownHint) Then
                Result = getObjectRequest(New CalendarURI(WellKnownHint), CalendarFolderType, CurrentUserPrincipalQuery)
            End If


            If ((CurrentUserPrincipalQuery.CurrentUserPrincipal Is Nothing) OrElse Not CurrentUserPrincipalQuery.CurrentUserPrincipal.IsSet()) Then
                getObjectRequest(New CalendarURI("/"), CalendarFolderType, CurrentUserPrincipalQuery)
            End If

            If ((CurrentUserPrincipalQuery.CurrentUserPrincipal Is Nothing) OrElse Not CurrentUserPrincipalQuery.CurrentUserPrincipal.IsSet()) Then
                getObjectRequest(New CalendarURI("/WebDAV"), CalendarFolderType, CurrentUserPrincipalQuery)
            End If

            If ((CurrentUserPrincipalQuery.CurrentUserPrincipal Is Nothing) OrElse Not CurrentUserPrincipalQuery.CurrentUserPrincipal.IsSet()) Then
                getObjectRequest(New CalendarURI("/dav"), CalendarFolderType, CurrentUserPrincipalQuery)
            End If

            Dim HomeSetQuery As New CalendarContainer

            If ((Not CurrentUserPrincipalQuery.CurrentUserPrincipal Is Nothing) AndAlso CurrentUserPrincipalQuery.CurrentUserPrincipal.IsSet()) Then


                If (CalendarFolderType = CalendarContainerType.Directory) Then

                    'See: https://tools.ietf.org/html/draft-daboo-carddav-directory-gateway-02 
                    ' (yes, it has been in draft form for many years, although many have adopted it)
                    ' Not withstanding, lets get the gateway URL, if it existed, otherwise, we will look for it

                    If ((Not CurrentUserPrincipalQuery.GatewayDirectory Is Nothing) And CurrentUserPrincipalQuery.GatewayDirectory.IsSet()) Then
                        CalendarFolder.URI = CurrentUserPrincipalQuery.GatewayDirectory
                        CalendarFolder.GatewayDirectory = CurrentUserPrincipalQuery.GatewayDirectory
                        CalendarFolder.CurrentUserPrincipal = CurrentUserPrincipalQuery.CurrentUserPrincipal
                        CalendarFolder.CalendarHomeSet = CurrentUserPrincipalQuery.CalendarHomeSet
                        CalendarFolder.AddressBookHomeSet = CurrentUserPrincipalQuery.AddressBookHomeSet
                        CalendarFolder.CalendarFolderType = CalendarContainerType.Directory
                        Result = CalendarResult.Success
                    Else
                        Result = resolveObjectRequest(CurrentUserPrincipalQuery.URI, CalendarFolder, CalendarFolderType)
                    End If
                ElseIf (CalendarFolderType = CalendarContainerType.Folder) Then
                    Debug.Assert(False, "We are looking for a folder, but it does not really make sense doing discovery on a folder (ie: trying to find it by its type).")
                    Result = CalendarResult.Failure
                Else
                    Result = getObjectRequest(CurrentUserPrincipalQuery.CurrentUserPrincipal, CalendarFolderType, HomeSetQuery)
                    ' lets finally attempt to resolve the main collection
                    Dim HomeSetURI As CalendarURI = HomeSetQuery.GetHomeSetURIByType(CalendarFolderType)
                    If ((HomeSetURI Is Nothing) OrElse Not HomeSetURI.IsSet()) Then
                        Result = resolveObjectRequest(CurrentUserPrincipalQuery.URI, CalendarFolder, CalendarFolderType)
                    Else
                        Result = resolveObjectRequest(HomeSetURI, CalendarFolder, CalendarFolderType)
                    End If
                    If ((CalendarFolder.ScheduleOutboxURL Is Nothing) OrElse Not CalendarFolder.ScheduleOutboxURL.IsSet()) Then
                        CalendarFolder.ScheduleOutboxURL = HomeSetQuery.ScheduleOutboxURL
                    End If

                    If (Not Result = CalendarResult.Success) Then
                        If ((HomeSetURI Is Nothing) OrElse HomeSetURI.IsSet()) Then
                            If ((Not HomeSetQuery.GatewayDirectory Is Nothing) And HomeSetQuery.CalendarHomeSet.IsSet()) Then
                                CalendarFolder.CalendarHomeSet = HomeSetURI
                            End If
                        End If
                        If (CalendarFolderType <> CalendarContainerType.Tasks) Then
                            Debug.Assert(False, "there does not seem to be any support for this folder (we will assert if it is not supported unless it is a common one, like GAL or Task, etc")
                        End If
                    End If

                End If

            Else
                If (Me.bLog) Then
                    Me.LogString += "Unable to locate DAV Service [Current User Principal resource] at: "
                    Me.LogString += IIf(Me.isSSL, "https://", "http://") + Me.Host & ":" & Me.Port
                    If (CurrentUserPrincipalQuery.URI.LastError > 0) Then
                        Me.LogString += ", HTTP Error: " + CurrentUserPrincipalQuery.URI.LastError
                    End If
                    Me.LogString += ". Please review the server settings (and verify the configuration of any firewalls)." & vbCrLf
                End If
                Debug.Assert(False, "unable to work out current user principal, something is very wrong")
                Result = CalendarResult.Failure
            End If
            Return Result
        End Function

        Function NormaliseCrLf(ByRef sData As String) As Long
            If Not sData.Contains(vbCrLf) Then
                'We need to reformat it
                sData.Replace(vbCr, "")
                sData.Replace(vbLf, vbCrLf)
                NormaliseCrLf = 1
            Else
                NormaliseCrLf = 2
            End If
        End Function

        Function parseCalendarItemList(ByRef davResponse As CalendarHTTPResponse, ByRef Items As List(Of CalendarItem), Optional CalendarFolderType As CalendarContainerType = CalendarContainerType.Calendar) As CalendarResult
            ' load xml dom pointer, compile into message list, with IDs
            Dim Result As CalendarResult = CalendarResult.Success
            Items.Clear()
            Dim bIsContainer As Boolean = False
            If (Not String.IsNullOrEmpty(davResponse.Body)) Then
                'Load it and parse it
                Dim oXMLDoc As New System.Xml.XmlDocument()
                Try
                    oXMLDoc.LoadXml(davResponse.Body)

                    Dim nsm As New System.Xml.XmlNamespaceManager(oXMLDoc.NameTable)
                    nsm.AddNamespace("C", "urn:ietf:params:xml:ns:caldav")
                    nsm.AddNamespace("D", "DAV:")
                    nsm.AddNamespace("A", "urn:ietf:params:xml:ns:carddav")

                    Dim pNodelist As System.Xml.XmlNodeList = oXMLDoc.SelectNodes("//D:response", nsm)
                    For Each pResponseNode As System.Xml.XmlNode In pNodelist
                        Dim CurrentItem As New CalendarItem
                        GetXMLNodeString(pResponseNode.SelectSingleNode("D:href", nsm), CurrentItem.URI.Path)
                        Dim sItemURL As String = System.Web.HttpUtility.UrlDecode(CurrentItem.URI.Path)

                        Dim arrURL() As String = sItemURL.Split("/")
                        If (arrURL.Length > 0) Then
                            CurrentItem.ItemId = arrURL.Last()
                        End If
                        bIsContainer = (sItemURL.Last = "/")
                        If (bIsContainer) Then
                            CurrentItem.ItemId += "/"
                        End If
                        If String.IsNullOrEmpty(CurrentItem.ItemId) Then
                            CurrentItem.ItemId = sItemURL
                        End If

                        Dim Props As System.Xml.XmlNode = pResponseNode.SelectSingleNode("D:propstat/D:prop", nsm)
                        If Not Props Is Nothing Then
                            bIsContainer = Not (Props.SelectSingleNode("D:resourcetype/D:collection", nsm) Is Nothing)

                            Select Case CalendarFolderType
                                Case CalendarContainerType.Contacts
                                    GetXMLNodeString(Props.SelectSingleNode("A:address-data", nsm), CurrentItem.Data)
                                    NormaliseCrLf(CurrentItem.Data)
                                Case CalendarContainerType.Directory
                                    GetXMLNodeString(Props.SelectSingleNode("A:address-data", nsm), CurrentItem.Data)
                                    NormaliseCrLf(CurrentItem.Data)
                                Case Else
                                    GetXMLNodeString(Props.SelectSingleNode("C:calendar-data", nsm), CurrentItem.Data)
                                    NormaliseCrLf(CurrentItem.Data)
                            End Select
                        End If
                        GetXMLNodeString(Props.SelectSingleNode("D:getetag", nsm), CurrentItem.ChangeTag)
                        GetXMLNodeString(Props.SelectSingleNode("D:getcontenttype", nsm), CurrentItem.ContentType)

                        ' Some servers do not return the ContenType even though we ask for it. So we will deduce it from the content

                        If CurrentItem.Data.StartsWith("BEGIN:VCARD", StringComparison.OrdinalIgnoreCase) Then
                            CurrentItem.ContentType = "text/x-vcard"
                        ElseIf CurrentItem.Data.StartsWith("BEGIN:VCALENDAR", StringComparison.OrdinalIgnoreCase) Then
                            CurrentItem.ContentType = "text/calendar"
                        End If

                        Dim bMeetsCriteria As Boolean = (CalendarFolderType = CalendarContainerType.Calendar And CurrentItem.ContentType.ToLower().Contains("text/calendar")) _
                    Or (CalendarFolderType = CalendarContainerType.Contacts And (CurrentItem.ContentType.ToLower().Contains("text/vcard") Or CurrentItem.ContentType.ToLower().Contains("text/x-vcard")))

                        If ((Not bIsContainer) And bMeetsCriteria) Then
                            Items.Add(CurrentItem)
                        End If
                    Next
                Catch ex As Exception
                    Result = CalendarResult.Failure
                    Debug.Assert(False, "Server Error: The XML returned was not parsable. Error Code: " + ex.Message)
                End Try

            Else
                Result = CalendarResult.Failure
                Debug.Assert(False, "Server Error: The XML returned blank.")
            End If
            Return Result
        End Function

        Public Function getCalendarItems(ByRef CalendarFolder As CalendarContainer, ByVal StartDate As DateTime, ByVal EndDate As DateTime, Optional ByRef ItemList As List(Of String) = Nothing, Optional ByVal bGetData As Boolean = False) As CalendarResult
            Dim Result As CalendarResult
            Dim sVerb As String = "REPORT"

            Dim Headers As New BasicHeaderBuilder
            Headers.AddEntry("Content-Type", "text/xml;charset=""utf-8""", True)

            Dim sRequest As String = ""
            If (bGetData = False) Then
                sVerb = "PROPFIND"
                ' We need to get a list of items and iterate them
                sRequest += "<A:propfind xmlns:A=""DAV:"">"
                sRequest += "<A:prop>"
                sRequest += "<A:getetag/>"
                sRequest += "<A:getcontenttype/>"
                sRequest += "<A:resourcetype/>"
                sRequest += "</A:prop>"
                sRequest += "</A:propfind>"
                Headers.AddEntry("Depth", "1")
            Else
                If ((Not ItemList Is Nothing) AndAlso ItemList.Count > 0) Then
                    Headers.AddEntry("Depth", "0")
                    ' We need to get a list of items and iterate them
                    sRequest += "<C:calendar-multiget xmlns:D=""DAV:"" xmlns:C=""urn:ietf:params:xml:ns:caldav"">"
                    sRequest += "<D:prop>"
                    sRequest += "<D:getetag/>"
                    sRequest += "<C:calendar-data/>"
                    sRequest += "<D:getcontenttype/>"
                    sRequest += "</D:prop>"
                    For Each sItem As String In ItemList
                        'Dim sURL As String = System.Web.HttpUtility.HtmlEncode(CalendarFolder.URI.Path, sItem)
                        Dim sURL As String = CalendarFolder.URI.Path
                        If Not CalendarFolder.URI.Path.EndsWith("/") Then
                            sURL += "/"
                        End If
                        sURL += sItem
                        sRequest += "<A:href xmlns:A=""DAV:"">" + sURL + "</A:href>"
                    Next
                    sRequest += "</C:calendar-multiget>"
                Else

                    Dim sd As String = StartDate.Year.ToString
                    Dim ed As String = EndDate.Year.ToString
                    If StartDate.Month.ToString.Count > 1 Then
                        sd &= StartDate.Month.ToString
                    Else
                        sd &= "0" & StartDate.Month.ToString
                    End If
                    If StartDate.Day.ToString.Count > 1 Then
                        sd &= StartDate.Day.ToString
                    Else
                        sd &= "0" & StartDate.Day.ToString
                    End If
                    sd &= "T000000Z"

                    'If StartDate.Date = EndDate.Date Then
                    '    EndDate.AddDays(1)
                    'End If

                    If EndDate.Month.ToString.Count > 1 Then
                        ed &= EndDate.Month.ToString
                    Else
                        ed &= "0" & EndDate.Month.ToString
                    End If
                    If EndDate.Day.ToString.Count > 1 Then
                        ed &= EndDate.Day.ToString
                    Else
                        ed &= "0" & EndDate.Day.ToString
                    End If
                    ed &= "T000000Z"


                    Headers.AddEntry("Depth", "1") 'this and rfc indicate to supply depth 1: http://sabre.io/dav/building-a-carddav-client/
                    sRequest += "<c:calendar-query xmlns:d=""DAV:"" xmlns:c=""urn:ietf:params:xml:ns:caldav"">"
                    sRequest += "<d:prop>"
                    sRequest += "<d:getetag/>"
                    If (bGetData) Then
                        sRequest += "<c:calendar-data>"

                        'sRequest += "<c:expand start=""" & sd & """ End=""" & ed & """/>"
                        'sRequest += "<c:limit-recurrence-set start=""" & sd & """ End=""" & ed & """/>"
                        'sRequest += "<c:limit-recurrence-set start=""20170901T000000Z"" End=""20170930T000000Z""/>"
                        sRequest += "</c:calendar-data>"
                    End If
                    sRequest += "<d:getcontenttype/>"
                    sRequest += "</d:prop>"
                    sRequest += "<c:filter>"
                    sRequest += "<c:comp-filter name=""VCALENDAR"">"
                    sRequest += "<c:comp-filter name=""VEVENT"">"
                    sRequest += "<c:time-range start=""" & sd & """ end=""" & ed & """/>"
                    'sRequest += "<c:time-range start=""20170901T000000Z"" end=""20170930T000000Z""/>"
                    sRequest += "</c:comp-filter>"
                    sRequest += "</c:comp-filter>"
                    sRequest += "</c:filter>"
                    sRequest += "</c:calendar-query>"
                End If
            End If
            Dim davRequest As New CalendarHTTPRequest(Me, sVerb, CalendarFolder.URI, Headers.Serialise(), sRequest)
            davRequest.Headers = Headers.Serialise()
            Dim davResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest)
            Result = davResponse.Result

            If Result = CalendarResult.Success Then
                Result = parseCalendarItemList(davResponse, CalendarFolder.Items)
            End If
            Return Result

        End Function

        Function getItems(ByRef CalendarFolder As CalendarContainer) As CalendarResult
            Dim Result As CalendarResult
            Dim sVerb As String = "PROPFIND"

            Dim Headers As New BasicHeaderBuilder
            Headers.AddEntry("Content-Type", "text/xml;charset=""utf-8""", True)
            Dim sRequest As String = ""
            ' We need to get a list of items and iterate them
            sRequest += "<A:propfind xmlns:A=""DAV:"">"
            sRequest += "<A:prop>"
            sRequest += "<A:getetag/>"
            sRequest += "<A:getcontenttype/>"
            sRequest += "<A:resourcetype/>"
            sRequest += "</A:prop>"
            sRequest += "</A:propfind>"
            Headers.AddEntry("Depth", "1")
            Dim davRequest As New CalendarHTTPRequest(Me, sVerb, CalendarFolder.URI, Headers.Serialise(), sRequest)
            davRequest.Headers = Headers.Serialise()
            Dim davResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest)
            Result = davResponse.Result

            If Result = CalendarResult.Success Then
                Result = parseCalendarItemList(davResponse, CalendarFolder.Items, CalendarContainerType.Contacts)
            End If
            Return Result
        End Function

        Public Function getContactItems(ByRef CalendarFolder As CalendarContainer, Optional ByRef ItemList As List(Of String) = Nothing, Optional ByVal bGetData As Boolean = False) As CalendarResult
            Dim Result As CalendarResult
            Dim sVerb As String = "REPORT"

            Dim Headers As New BasicHeaderBuilder
            Headers.AddEntry("Content-Type", "text/xml;charset=""utf-8""", True)

            Dim sRequest As String = ""
            If (bGetData = False) Then
                sVerb = "PROPFIND"
                ' We need to get a list of items and iterate them
                sRequest += "<A:propfind xmlns:A=""DAV:"">"
                sRequest += "<A:prop>"
                sRequest += "<A:getetag/>"
                sRequest += "<A:getcontenttype/>"
                sRequest += "<A:resourcetype/>"
                sRequest += "</A:prop>"
                sRequest += "</A:propfind>"
                Headers.AddEntry("Depth", "1")
            Else
                'note: at the time of writhing - yahoo appears to require the Depth header for report even though RFC says this:
                '      As a result, the "Depth" header MUST be ignored by the server and SHOULD NOT besent by the client.
                If ((Not ItemList Is Nothing) AndAlso ItemList.Count > 0) Then
                    Headers.AddEntry("Depth", "0")
                    ' We need to get a list of items and iterate them
                    sRequest += "<A:addressbook-multiget xmlns:D=""DAV:"" xmlns:A=""urn:ietf:params:xml:ns:carddav"">"
                    sRequest += "<D:prop>"
                    sRequest += "<D:getetag/>"
                    sRequest += "<A:address-data/>"
                    sRequest += "<D:getcontenttype/>"
                    sRequest += "</D:prop>"
                    For Each sItem As String In ItemList
                        'Dim sURL As String = System.Web.HttpUtility.HtmlEncode(CalendarFolder.URI.Path, sItem)
                        Dim sURL As String = CalendarFolder.URI.Path
                        If Not CalendarFolder.URI.Path.EndsWith("/") Then
                            sURL += "/"
                        End If
                        sURL += sItem
                        sRequest += "<A:href xmlns:A=""DAV:"">" + sURL + "</A:href>"
                    Next

                    sRequest += "</A:addressbook-multiget>"
                Else
                    Headers.AddEntry("Depth", "1") ' Seems to require depth: 1 http://sabre.io/dav/building-a-carddav-client/
                    sRequest += "<A:addressbook-query xmlns:D=""DAV:"" xmlns:A=""urn:ietf:params:xml:ns:carddav"">"
                    sRequest += "<D:prop>"
                    sRequest += "<D:getetag/>"
                    If (bGetData) Then
                        sRequest += "<V:address-data xmlns:V=""urn:ietf:params:xml:ns:carddav""/>"
                    End If
                    sRequest += "<D:getcontenttype/>"

                    sRequest += "</D:prop>"
                    sRequest += "</A:addressbook-query>"
                End If
            End If
            Dim davRequest As New CalendarHTTPRequest(Me, sVerb, CalendarFolder.URI, Headers.Serialise(), sRequest)
            davRequest.Headers = Headers.Serialise()
            Dim davResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest)
            Result = davResponse.Result

            If Result = CalendarResult.Success Then
                Result = parseCalendarItemList(davResponse, CalendarFolder.Items, CalendarContainerType.Contacts)
            End If
            Return Result
        End Function

        Function getCalendarItem(ByRef targetItem As CalendarItem) As CalendarResult
            Dim Result As CalendarResult
            Dim Headers As New BasicHeaderBuilder
            If Not String.IsNullOrEmpty(targetItem.ContentType) Then
                Headers.AddEntry("Content-Type", targetItem.ContentType)
            End If

            Dim ObjectURI As New CalendarURI(targetItem.URI.Path & "/" & targetItem.ItemId)

            Dim davRequest As New CalendarHTTPRequest(Me, "GET", ObjectURI, Headers.Serialise(), targetItem.Data)
            davRequest.Headers = Headers.Serialise()
            Dim davResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest)
            Result = davResponse.Result

            If Result = CalendarResult.Success Then
                ' Attempt to get the e-tag from the response header, so we do not second grab the item unneccessarily after the add
                Dim sETag As String = davResponse.Headers.Get("ETag")
                If Not String.IsNullOrEmpty(sETag) Then
                    targetItem.ChangeTag = sETag
                End If
                Dim sContentType As String = davResponse.Headers.Get("Content-Type")
                If Not String.IsNullOrEmpty(sContentType) Then
                    targetItem.ContentType = sContentType
                End If
                targetItem.Data = davResponse.Body
            Else
                targetItem.URI.LastError = davResponse.LastError
                targetItem.URI.StatusCode = davResponse.StatusCode
                Debug.Assert(False)
            End If
            Return Result
        End Function

        Function addCalendarItem(ByRef NewItem As CalendarItem, Optional ByVal bIsUpdate As Boolean = False) As CalendarResult
            Dim Result As CalendarResult
            Dim Headers As New BasicHeaderBuilder
            If Not String.IsNullOrEmpty(NewItem.ContentType) Then
                Headers.AddEntry("Content-Type", NewItem.ContentType)
            End If
            If Not String.IsNullOrEmpty(NewItem.ChangeTag) Then
                Headers.AddEntry("ETag", NewItem.ChangeTag)
            End If
            If (Not bIsUpdate) Then
                'we want to do this if it is an add (for Zimbra in particular)
                Headers.AddEntry("If-None-Match", "*")
            End If

            Dim TargetURI As New CalendarURI
            TargetURI.Clone(NewItem.URI)
            If bIsUpdate Then
                ' The item id needs to be appended to the URI because it is an edit
                If Not String.IsNullOrEmpty(NewItem.ItemId) Then
                    'Lets also make sure that the URI does not already end with the items id
                    If Not TargetURI.Path.EndsWith("/" & NewItem.ItemId) Then
                        If Not TargetURI.Path.EndsWith("/") Then
                            TargetURI.Path += "/"
                        End If
                        TargetURI.Path += NewItem.ItemId
                    End If
                End If
            End If

            Dim davRequest As New CalendarHTTPRequest(Me, "PUT", TargetURI, Headers.Serialise(), NewItem.Data)
            davRequest.Headers = Headers.Serialise()
            Dim davResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest)
            Result = davResponse.Result

            If Result = CalendarResult.Success Then
                ' Attempt to get the e-tag from the response header, so we do not second grab the item unneccessarily after the add
                Dim sETag As String = davResponse.Headers.Get("ETag")
                If Not String.IsNullOrEmpty(sETag) Then
                    NewItem.ChangeTag = sETag
                End If
            Else
                NewItem.URI.LastError = davResponse.LastError
                NewItem.URI.StatusCode = davResponse.StatusCode
                Debug.Assert(False)
            End If
            Return Result
        End Function

        Function deleteCalendarItem(ByRef targetItem As CalendarItem) As CalendarResult
            Dim Result As CalendarResult

            Dim TargetURI As New CalendarURI
            TargetURI.Clone(targetItem.URI)
            If Not String.IsNullOrEmpty(targetItem.ItemId) Then
                If Not TargetURI.Path.EndsWith("/") Then
                    TargetURI.Path += "/"
                End If
                TargetURI.Path += targetItem.ItemId
            End If
            Dim davRequest As New CalendarHTTPRequest(Me, "DELETE", TargetURI, Nothing, String.Empty)
            Dim davResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest)
            Result = davResponse.Result
            'Since we copied the details from the target item, we will need to set the status back (in case the caller needs them)
            targetItem.URI.StatusCode = TargetURI.StatusCode
            targetItem.URI.LastError = TargetURI.LastError

            Debug.Assert(Result = CalendarResult.Success)
            deleteCalendarItem = Result
        End Function

        Function updateCalendarItem(ByRef NewItem As CalendarItem) As CalendarResult
            Dim Result As CalendarResult
            Result = addCalendarItem(NewItem, True)
            Debug.Assert(Result = CalendarResult.Success)
            updateCalendarItem = Result
        End Function

        Public Function PollFolderForChanges(ByRef CalendarFolder As CalendarContainer, ByRef bKeepListening As Boolean, _CalendarFolderType As CalendarContainerType, intervalInMilliSeconds As Integer, expirationInSeconds As Integer) As CalendarPollState
            Dim CurrentProps As New CalendarContainer(CalendarFolder.URI.Path)
            CurrentProps.URI.Host = CalendarFolder.URI.Host
            CurrentProps.URI.Port = CalendarFolder.URI.Port
            CurrentProps.URI.Protocol = CalendarFolder.URI.Protocol
            Dim Result As CalendarPollState = CalendarPollState.Expired
            Dim bChangesFound As Boolean = False
            Dim bExpired As Boolean = False
            Dim PollTimer As New Stopwatch
            PollTimer.Start()
            Dim CalendarState As Integer = 0

            While ((Not bExpired) And (Not bChangesFound))

                Dim StateResult As CalendarResult = getObjectState(CurrentProps, _CalendarFolderType)
                If StateResult = CalendarResult.Success Then
                    ' let's check if the calendar has changed
                    bChangesFound = CalendarFolder.ChangeTag <> CurrentProps.ChangeTag
                    If (bChangesFound) Then
                        Result = CalendarPollState.Changed
                        CalendarFolder.ChangeTag = CurrentProps.ChangeTag
                    Else
                        If (bKeepListening) Then
                            If PollTimer.ElapsedMilliseconds >= intervalInMilliSeconds Then
                                bExpired = True
                            Else
                                Threading.Thread.Sleep(intervalInMilliSeconds) ' //sleep for a second anyway (in case Polling returns obscure result)
                            End If
                        End If
                    End If
                Else
                    bExpired = True
                End If

            End While
            Return Result
        End Function

        Function parseFreeBusyRequest(ByRef davResponse As CalendarHTTPResponse, ByRef FreeBusyResponse As CalendarFreeBusyResponse) As CalendarResult

            ' load xml dom pointer, compile into message list, with IDs
            Dim Result As CalendarResult = CalendarResult.Failure

            Dim bIsContainer As Boolean = False
            If (Not String.IsNullOrEmpty(davResponse.Body)) Then
                'Load it and parse it

                Dim oXMLDoc As New System.Xml.XmlDocument()
                Try
                    oXMLDoc.LoadXml(davResponse.Body)
                    Dim nsm As New System.Xml.XmlNamespaceManager(oXMLDoc.NameTable)
                    nsm.AddNamespace("C", "urn:ietf:params:xml:ns:caldav")
                    nsm.AddNamespace("D", "DAV:")
                    Dim pNodelist As System.Xml.XmlNodeList = oXMLDoc.SelectNodes("//C:response", nsm)
                    If Not pNodelist Is Nothing Then
                        For Each pResponseNode As System.Xml.XmlNode In pNodelist
                            GetXMLNodeString(pResponseNode.SelectSingleNode("C:calendar-data", nsm), FreeBusyResponse.Response)
                            GetXMLNodeString(pResponseNode.SelectSingleNode("C:request-status", nsm), FreeBusyResponse.StatusString)
                            Result = CalendarResult.Success
                            Exit For 'just get the first (it is seemlingly undefined as to the implications of processing multiples and how we might render them)
                        Next
                    Else
                        Debug.Assert(False, "The server responded, just with no response block")
                        Result = CalendarResult.Success
                    End If
                Catch ex As Exception
                    Result = CalendarResult.Failure
                End Try
            Else
                Result = CalendarResult.Failure
            End If
            Return Result
        End Function

        Function getCalendarFreeBusy(ByRef FreeBusyResponse As CalendarFreeBusyResponse, ByVal sUserAddress As String, ByVal RangeStart As DateTime, ByVal RangeEnd As DateTime, ByVal SchedulingURL As CalendarURI) As CalendarResult
            Dim Result As CalendarResult
            Dim sRequest As String = ""
            sRequest += "BEGIN:VCALENDAR" & vbCrLf
            sRequest += "VERSION:2.0" & vbCrLf
            sRequest += "PRODID:-//ARPDEV Pty. Ltd.//DAV Client//EN" & vbCrLf
            sRequest += "METHOD:REQUEST" & vbCrLf
            sRequest += "BEGIN:VFREEBUSY" & vbCrLf
            sRequest += "DTSTAMP:" & Now.ToString("yyyyMMddTHHMMss") & "Z" & vbCrLf
            sRequest += "ORGANIZER:mailto:" & sUserAddress & vbCrLf
            sRequest += "DTSTART:" & RangeStart.ToString("yyyyMMddTHHMMss") & "Z" & vbCrLf
            sRequest += "DTEND:" & RangeEnd.ToString("yyyyMMddTHHMMss") & "Z" & vbCrLf
            sRequest += "UID:" & sUserAddress & vbCrLf
            sRequest += "ATTENDEE:mailto:" & sUserAddress & vbCrLf
            sRequest += "END:VFREEBUSY" & vbCrLf
            sRequest += "END:VCALENDAR" & vbCrLf

            Dim Headers As New BasicHeaderBuilder
            Headers.AddEntry("Content-Type", "text/calendar")
            Headers.AddEntry("Originator", "mailto:" + sUserAddress)
            Headers.AddEntry("Recipient", "mailto:" + sUserAddress)

            Dim davRequest As New CalendarHTTPRequest(Me, "POST", SchedulingURL, Headers.Serialise(), sRequest)
            davRequest.Headers = Headers.Serialise()
            Dim davResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest)
            Result = davResponse.Result

            If Result = CalendarResult.Success Then
                Result = parseFreeBusyRequest(davResponse, FreeBusyResponse)
                Debug.Assert(Result = CalendarResult.Success) 'not implemented? Does not seem to be implemented
            Else
                'seemingly not supported, we need to try https://tools.ietf.org/html/rfc4791#page-68
                Dim sQueryRequest As String = ""

                sQueryRequest += "<?xml version=""1.0"" encoding=""utf-8"" ?>"
                sQueryRequest += "<C:free-busy-query xmlns:D=""DAV:"" xmlns:C=""urn:ietf:params:xml:ns:caldav"">"
                sQueryRequest += "<C:time-range start=""" + RangeStart.ToString("yyyyMMddTHHMMss") + "Z"" end=""" + RangeEnd.ToString("yyyyMMddTHHMMss") + "Z""/>"
                sQueryRequest += "</C:free-busy-query>"
                Dim QueryHeaders As New BasicHeaderBuilder
                QueryHeaders.AddEntry("Content-Type", "text/xml")
                QueryHeaders.AddEntry("Depth", "1")

                Dim davQueryRequest As New CalendarHTTPRequest(Me, "REPORT", SchedulingURL, QueryHeaders.Serialise(), sQueryRequest)
                davQueryRequest.Headers = QueryHeaders.Serialise()
                Dim davQueryResponse As CalendarHTTPResponse = Me.IssueRequest(davRequest)
                Result = davQueryResponse.Result
                Debug.Assert(Result = CalendarResult.Success) 'not implemented? Does not seem to be implemented
            End If
            Return Result
        End Function
    End Class


End Namespace