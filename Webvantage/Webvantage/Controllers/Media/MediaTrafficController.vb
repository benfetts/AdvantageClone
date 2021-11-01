Imports Kendo.Mvc.Extensions

Namespace Controllers.Media

    <System.Web.Mvc.AllowAnonymous>
    Public Class MediaTrafficController
        Inherits MVCControllerBase

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Private Methods "

        'Private Function GetRegistryKey(ByVal RegPath As String) As Microsoft.Win32.RegistryKey

        '    Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

        '    If System.Environment.Is64BitOperatingSystem AndAlso System.Environment.Is64BitProcess Then

        '        RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage\" & RegPath, False)

        '    Else

        '        RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Advantage\" & RegPath, False)

        '    End If

        '    GetRegistryKey = RegistryKey

        'End Function
        Private Sub GetServerName(ByVal DatabaseName As String, ByRef ServerName As String, ByRef UserName As String, ByRef Password As String)

            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

            ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

            If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                For Each CDP In ConnectionDatabaseProfiles

                    If CDP.DatabaseName = DatabaseName Then

                        ConnectionDatabaseProfile = CDP
                        Exit For

                    End If

                Next

            End If

            If ConnectionDatabaseProfile IsNot Nothing Then

                ServerName = ConnectionDatabaseProfile.ServerName.Replace("#", "\")
                UserName = ConnectionDatabaseProfile.UserName
                Password = ConnectionDatabaseProfile.GetDecryptPassword()

            End If

        End Sub
        'Private Sub GetServerName(ByVal DatabaseName As String, ByRef ServerName As String, ByRef UserName As String, ByRef Password As String)

        '    Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        '    Dim RegistryAttribute As AdvantageFramework.Registry.Attributes.RegistryAttribute = Nothing
        '    Dim ServerFound As Boolean = False

        '    RegistryKey = GetRegistryKey("Servers")

        '    If RegistryKey IsNot Nothing Then

        '        For Each ServerSubKeyName In RegistryKey.GetSubKeyNames

        '            RegistryKey = GetRegistryKey("Servers\" & ServerSubKeyName)

        '            If RegistryKey IsNot Nothing Then

        '                For Each SubKeyNameDB In RegistryKey.GetSubKeyNames

        '                    If SubKeyNameDB.ToUpper = DatabaseName.ToUpper Then

        '                        ServerName = ServerSubKeyName.Replace("#", "\")

        '                        ServerFound = True

        '                        RegistryKey = GetRegistryKey("Servers\" & ServerSubKeyName & "\" & SubKeyNameDB)

        '                        If RegistryKey IsNot Nothing Then

        '                            UserName = RegistryKey.GetValue("CPUsername")

        '                            Password = AdvantageFramework.Security.Encryption.Decrypt(RegistryKey.GetValue("CPPassword"))

        '                        End If

        '                        Exit For

        '                    End If

        '                Next

        '                If ServerFound Then

        '                    Exit For

        '                End If

        '            End If

        '        Next

        '    End If

        'End Sub
        Private Function DecrpytQueryString(QueryString As String, ByRef DatabaseName As String, ByRef MediaManagerGeneratedReportID As Integer, ByRef Email As String) As Boolean

            'objects
            Dim Url() As String = Nothing
            Dim Decrpyted As Boolean = False
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing

            Try

                Url = QueryString.Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "MediaManagerGeneratedReportID"

                            MediaManagerGeneratedReportID = CInt(VariableValues(1).ToString)

                        Case "Email"

                            Email = VariableValues(1).ToString

                    End Select

                Next

                Decrpyted = True

            Catch ex As Exception
                Decrpyted = False
            End Try

            DecrpytQueryString = Decrpyted

        End Function
        Private Function GetSqlConnectionStringBuilder(DatabaseName As String) As System.Data.SqlClient.SqlConnectionStringBuilder

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

            GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

            SqlConnectionStringBuilder.InitialCatalog = DatabaseName

            GetSqlConnectionStringBuilder = SqlConnectionStringBuilder

        End Function

#End Region

        <System.Web.Mvc.AllowAnonymous()>
        Public Function DownloadDetailDocument(QueryString As String) As System.Web.Mvc.FileContentResult

            'objects
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim DocumentID As Integer = Nothing
            Dim IsValid As Boolean = True
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader
            Dim ByteFile() As Byte = Nothing
            Dim FileSystemFile As String = Nothing
            Dim FileExtension As String = ""

            Try

                Url = QueryString.Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "DocumentID"

                            DocumentID = CInt(VariableValues(1).ToString)

                    End Select

                Next

            Catch ex As Exception
                IsValid = False
            End Try

            If IsValid Then

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                        If Document IsNot Nothing Then

                            AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                            FileSystemFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & Document.FileSystemFileName

                            If System.IO.File.Exists(FileSystemFile) Then

                                FileStream = New System.IO.FileStream(FileSystemFile, IO.FileMode.OpenOrCreate)
                                BinaryReader = New System.IO.BinaryReader(FileStream)
                                ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FileSystemFile).Length)

                                FileStream.Read(ByteFile, 0, FileStream.Length)
                                FileStream.Close()

                                FileExtension = New System.IO.FileInfo(Document.FileName).Extension

                                FileContentResult = New System.Web.Mvc.FileContentResult(ByteFile.ToArray, FileExtension)

                                FileContentResult.FileDownloadName = AdvantageFramework.FileSystem.CreateValidFileName(Document.FileName)

                            End If

                            AdvantageFramework.Security.Impersonate.EndImpersonation()

                        End If

                    End Using

                Catch ex As Exception
                    FileContentResult = Nothing
                End Try

            End If

            DownloadDetailDocument = FileContentResult

        End Function
        <System.Web.Mvc.AllowAnonymous()>
        Public Function DownloadInstructionDocument(QueryString As String) As System.Web.Mvc.FileContentResult

            'objects
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim IsValid As Boolean = True
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim MediaTrafficID As Integer = -1
            Dim VendorCode As String = Nothing
            Dim RevisionNumber As Integer = -1
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim Vendor As AdvantageFramework.DTO.Media.Traffic.Vendor = Nothing
            Dim MediaBroadcastWorksheetMarketTraffic As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketTraffic = Nothing
            Dim MediaTrafficVendorStatus As AdvantageFramework.Database.Entities.MediaTrafficVendorStatus = Nothing
            Dim MediaTrafficPrintSetting As AdvantageFramework.Database.Entities.MediaTrafficPrintSetting = Nothing
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim TrafficGuidelines As String = Nothing

            Try

                Url = QueryString.Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "MediaTrafficID"

                            MediaTrafficID = CInt(VariableValues(1).ToString)

                        Case "VendorCode"

                            VendorCode = VariableValues(1).ToString

                        Case "RevisionNumber"

                            RevisionNumber = CInt(VariableValues(1).ToString)

                        Case "Email"

                            Email = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                IsValid = False
            End Try

            If IsValid Then

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        Using DataContext As New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            MediaTrafficVendor = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendor.Load(DbContext).Include("MediaTrafficRevision")
                                                  Where Entity.MediaTrafficRevision.MediaTrafficID = MediaTrafficID AndAlso
                                                        Entity.VendorCode = VendorCode AndAlso
                                                        Entity.MediaTrafficRevision.RevisionNumber = RevisionNumber
                                                  Select Entity).SingleOrDefault

                            Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                            MediaTrafficVendorStatus = MediaTrafficVendor.MediaTrafficVendorStatuses.Where(Function(MTVS) MTVS.MediaTrafficStatusID = AdvantageFramework.Database.Entities.Methods.MediaTrafficStatusID.Generated).FirstOrDefault

                            MediaBroadcastWorksheetMarketTraffic = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketTraffic.Load(DbContext)
                                                                    Where Entity.MediaTrafficID = MediaTrafficVendor.MediaTrafficRevision.MediaTrafficID
                                                                    Select Entity).FirstOrDefault

                            If MediaTrafficVendorStatus IsNot Nothing Then

                                MediaTrafficPrintSetting = AdvantageFramework.Database.Procedures.MediaTrafficPrintSetting.LoadByUserCodeAndMediaType(DbContext, MediaTrafficVendorStatus.UserCreated, MediaBroadcastWorksheetMarketTraffic.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode)

                                If MediaTrafficPrintSetting IsNot Nothing Then

                                    If String.IsNullOrWhiteSpace(MediaTrafficPrintSetting.LocationID) = False Then

                                        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, MediaTrafficPrintSetting.LocationID)

                                    End If

                                    If MediaTrafficPrintSetting.IncludeGuidelines Then

                                        If MediaBroadcastWorksheetMarketTraffic IsNot Nothing Then

                                            TrafficGuidelines = MediaBroadcastWorksheetMarketTraffic.MediaBroadcastWorksheetMarket.TrafficGuidelines

                                        End If

                                    End If

                                End If

                            End If

                            Report = AdvantageFramework.Reporting.Reports.CreateMediaTrafficReport(Session, MediaTrafficVendor.ID, Location, TrafficGuidelines)

                            If Report IsNot Nothing Then

                                MemoryStream = New System.IO.MemoryStream

                                Report.ExportToPdf(MemoryStream)

                                FileContentResult = New System.Web.Mvc.FileContentResult(MemoryStream.ToArray, AdvantageFramework.FileSystem.GetMIMETypeByExtension("PDF"))

                                Vendor = New AdvantageFramework.DTO.Media.Traffic.Vendor(MediaTrafficVendor)

                                If MediaBroadcastWorksheetMarketTraffic IsNot Nothing Then

                                    FileContentResult.FileDownloadName = AdvantageFramework.FileSystem.CreateValidFileName(MediaBroadcastWorksheetMarketTraffic.MediaBroadcastWorksheetMarket.ID.ToString & "_" &
                                        MediaBroadcastWorksheetMarketTraffic.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Name & "_" & Vendor.MediaTrafficRevisionDescription & "_" &
                                        Vendor.MediaTrafficRevisionID & "_" & Vendor.VendorName & ".PDF")

                                Else

                                    FileContentResult.FileDownloadName = AdvantageFramework.FileSystem.CreateValidFileName(Vendor.MediaTrafficRevisionDescription & "_" &
                                        Vendor.MediaTrafficRevisionID & "_" & Vendor.VendorName & ".PDF")

                                End If

                            End If

                        End Using

                    End Using

                Catch ex As Exception
                    FileContentResult = Nothing
                End Try

            End If

            DownloadInstructionDocument = FileContentResult

        End Function
        <System.Web.Mvc.AllowAnonymous()>
        Public Function TrafficInstructionForm() As System.Web.Mvc.ActionResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim MediaTrafficID As Integer = -1
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim TrafficInstructionFormViewModel As ViewModels.MediaManager.TrafficInstructionFormViewModel = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim MediaTrafficVendorStatus As AdvantageFramework.Database.Entities.MediaTrafficVendorStatus = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim ReceivedBy As String = Nothing
            Dim UserName As String = Nothing
            Dim WebvantageURL As String = Nothing
            Dim MaxRevisionNumber As Integer = -1
            Dim VendorCode As String = Nothing
            Dim RevNbr As Integer = -1

            Try

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "MediaTrafficID"

                            MediaTrafficID = CInt(VariableValues(1).ToString)

                        Case "VendorCode"

                            VendorCode = VariableValues(1).ToString

                        Case "RevisionNumber"

                            RevNbr = CInt(VariableValues(1).ToString)

                        Case "Email"

                            Email = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                DecodedFailed = True
            End Try

            TrafficInstructionFormViewModel = New ViewModels.MediaManager.TrafficInstructionFormViewModel
            TrafficInstructionFormViewModel.IsValid = True

            If DecodedFailed = False Then

                TrafficInstructionFormViewModel.DatabaseName = DatabaseName
                TrafficInstructionFormViewModel.Email = Email

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                        String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                MediaTrafficVendor = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendor.Load(DbContext).Include("MediaTrafficRevision")
                                                      Where Entity.MediaTrafficRevision.MediaTrafficID = MediaTrafficID AndAlso
                                                            Entity.VendorCode = VendorCode AndAlso
                                                            Entity.MediaTrafficRevision.RevisionNumber = RevNbr
                                                      Select Entity).SingleOrDefault

                                TrafficInstructionFormViewModel.MediaTrafficVendorID = MediaTrafficVendor.ID

                                MaxRevisionNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficRevision.Load(DbContext)
                                                     Where Entity.MediaTrafficID = MediaTrafficVendor.MediaTrafficRevision.MediaTrafficID
                                                     Select Entity.RevisionNumber).Max

                                If MediaTrafficVendor.MediaTrafficRevision.RevisionNumber <> MaxRevisionNumber Then

                                    TrafficInstructionFormViewModel.InDifferentOrderState = True

                                End If

                                If TrafficInstructionFormViewModel.InDifferentOrderState = False Then

                                    WebvantageURL = AdvantageFramework.Database.Procedures.Agency.Load(DbContext).WebvantageURL

                                    WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(WebvantageURL, "/")

                                    TrafficInstructionFormViewModel.DetailDocuments = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Traffic.DetailDocument)(String.Format("exec dbo.advsp_media_traffic_detail_documents {0}", MediaTrafficVendor.ID)).ToList

                                    For Each DetailDocument In TrafficInstructionFormViewModel.DetailDocuments.Where(Function(DD) DD.IsURL = False AndAlso DD.DocumentID.HasValue)

                                        DetailDocument.Link = "<a href=""" & WebvantageURL & "Media/MediaTraffic/DownloadDetailDocument?QueryString=%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & DatabaseName & "&DocumentID=" & DetailDocument.DocumentID) & "%7C"" ><u><strong> Download</strong></u></a>"

                                    Next

                                    If MediaTrafficVendor IsNot Nothing AndAlso MediaTrafficVendor.AlertID.HasValue Then

                                        Alert = DbContext.Alerts.Find(MediaTrafficVendor.AlertID.Value)

                                        If Alert IsNot Nothing Then

                                            TrafficInstructionFormViewModel.AlertID = Alert.ID
                                            TrafficInstructionFormViewModel.Subject = Alert.Subject
                                            TrafficInstructionFormViewModel.Body = Alert.EmailBody

                                            MediaTrafficVendorStatus = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, MediaTrafficVendor.ID)
                                                                        Where Entity.MediaTrafficStatus.ID = AdvantageFramework.Database.Entities.MediaTrafficStatusID.Accepted).SingleOrDefault

                                            If MediaTrafficVendorStatus IsNot Nothing Then

                                                TrafficInstructionFormViewModel.HasBeenAccepted = True

                                                UserName = DbContext.Database.SqlQuery(Of String)(String.Format("select [dbo].[advfn_get_user_name]('{0}')", MediaTrafficVendorStatus.UserCreated)).FirstOrDefault

                                                TrafficInstructionFormViewModel.AcceptedByAt = "Accepted by " & UserName & " on " & MediaTrafficVendorStatus.CreatedDate.ToLongDateString

                                            End If

                                            TrafficInstructionFormViewModel.QueryString = "|" & Url(1).ToString & "|"
                                            TrafficInstructionFormViewModel.ConnectionString = SqlConnectionStringBuilder.ConnectionString
                                            TrafficInstructionFormViewModel.UserCode = SqlConnectionStringBuilder.UserID
                                            TrafficInstructionFormViewModel.AgencyName = AdvantageFramework.Database.Procedures.Agency.LoadName(DbContext)

                                            VendorRepresentative = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, MediaTrafficVendor.VendorCode)
                                                                    Where Entity.EmailAddress.ToUpper = Email.ToUpper
                                                                    Select Entity).FirstOrDefault

                                            If VendorRepresentative IsNot Nothing Then

                                                ReceivedBy = VendorRepresentative.ToString

                                            Else

                                                VendorContact = (From Entity In AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorCode(DbContext, MediaTrafficVendor.VendorCode)
                                                                 Where Entity.Email.ToUpper = Email.ToUpper AndAlso
                                                                   (Entity.IsInactive Is Nothing OrElse
                                                                    Entity.IsInactive = 0)
                                                                 Select Entity).FirstOrDefault

                                                If VendorContact IsNot Nothing Then

                                                    ReceivedBy = VendorContact.ToString

                                                End If

                                            End If

                                            If Not String.IsNullOrWhiteSpace(ReceivedBy) AndAlso (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, MediaTrafficVendor.ID)
                                                                                                  Where Entity.MediaTrafficStatus.ID = AdvantageFramework.Database.Entities.MediaTrafficStatusID.Received).Any = False Then

                                                MediaTrafficVendorStatus = New AdvantageFramework.Database.Entities.MediaTrafficVendorStatus
                                                MediaTrafficVendorStatus.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                                MediaTrafficVendorStatus.UserCreated = ReceivedBy
                                                MediaTrafficVendorStatus.MediaTrafficVendorID = MediaTrafficVendor.ID
                                                MediaTrafficVendorStatus.MediaTrafficStatusID = AdvantageFramework.Database.Entities.MediaTrafficStatusID.Received

                                                DbContext.MediaTrafficVendorStatuses.Add(MediaTrafficVendorStatus)
                                                DbContext.SaveChanges()

                                            End If

                                        Else

                                            TrafficInstructionFormViewModel.IsValid = False

                                        End If

                                    Else

                                        TrafficInstructionFormViewModel.IsValid = False

                                    End If

                                End If

                            End Using

                        End Using

                    Catch ex As Exception
                        TrafficInstructionFormViewModel.IsValid = False
                    End Try

                Else

                    TrafficInstructionFormViewModel.IsValid = False

                End If

            Else

                TrafficInstructionFormViewModel.IsValid = False

            End If

            TrafficInstructionForm = View(TrafficInstructionFormViewModel)

        End Function
        <System.Web.Mvc.AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function AcceptInstruction(DatabaseName As String, Comment As String, MediaTrafficVendorID As Integer, Email As String, Command As Integer) As System.Web.Mvc.ActionResult

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim ResponseBy As String = Nothing
            Dim MediaTrafficVendorStatus As AdvantageFramework.Database.Entities.MediaTrafficVendorStatus = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

            GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

            SqlConnectionStringBuilder.InitialCatalog = DatabaseName

            If ModelState.IsValid Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                    Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            MediaTrafficVendor = DbContext.MediaTrafficVendors.Find(MediaTrafficVendorID)

                            If MediaTrafficVendor IsNot Nothing AndAlso MediaTrafficVendor.AlertID.HasValue Then

                                Alert = DbContext.Alerts.Find(MediaTrafficVendor.AlertID.Value)

                                VendorRepresentative = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, MediaTrafficVendor.VendorCode)
                                                        Where Entity.EmailAddress.ToUpper = Email.ToUpper
                                                        Select Entity).FirstOrDefault

                                If VendorRepresentative IsNot Nothing Then

                                    ResponseBy = VendorRepresentative.ToString

                                Else

                                    VendorContact = (From Entity In AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorCode(DbContext, MediaTrafficVendor.VendorCode)
                                                     Where Entity.Email.ToUpper = Email.ToUpper AndAlso
                                                               (Entity.IsInactive Is Nothing OrElse
                                                                Entity.IsInactive = 0)
                                                     Select Entity).FirstOrDefault

                                    If VendorContact IsNot Nothing Then

                                        ResponseBy = VendorContact.ToString

                                    End If

                                End If

                                If Not String.IsNullOrWhiteSpace(ResponseBy) And Command = 1 Then

                                    MediaTrafficVendorStatus = New AdvantageFramework.Database.Entities.MediaTrafficVendorStatus
                                    MediaTrafficVendorStatus.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    MediaTrafficVendorStatus.UserCreated = ResponseBy
                                    MediaTrafficVendorStatus.MediaTrafficVendorID = MediaTrafficVendorID
                                    MediaTrafficVendorStatus.MediaTrafficStatusID = AdvantageFramework.Database.Entities.MediaTrafficStatusID.Accepted

                                    DbContext.MediaTrafficVendorStatuses.Add(MediaTrafficVendorStatus)
                                    DbContext.SaveChanges()

                                End If

                                AlertComment = New AdvantageFramework.Database.Entities.AlertComment
                                AlertComment.DbContext = DbContext

                                AlertComment.AlertID = MediaTrafficVendor.AlertID.Value
                                AlertComment.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                If Command = 1 Then

                                    AlertComment.Comment = "Instruction accepted.  " & Comment

                                Else

                                    AlertComment.Comment = Comment

                                End If

                                AlertComment.HasEmailBeenSent = False

                                If VendorContact IsNot Nothing Then

                                    AlertComment.VendorContactCode = VendorContact.Code

                                ElseIf VendorRepresentative IsNot Nothing Then

                                    AlertComment.VendorRepresentativeCode = VendorRepresentative.Code

                                End If

                                If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) Then

                                    AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, Alert.Subject, IncludeOriginator:=True)

                                Else

                                    IsValid = False
                                    ErrorMessage = "Cannot insert alert comment. Please contact software support."

                                End If

                            Else

                                IsValid = False
                                ErrorMessage = "Cannot find media traffic vendor record. Please contact software support."

                            End If

                        End Using

                    End Using

                End Using

            End If

            If Not IsValid Then

                ModelState.AddModelError("", ErrorMessage)

            End If

            Return Json(Request.UrlReferrer.OriginalString, System.Web.Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <System.Web.Mvc.AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function GetResponses(DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest, DatabaseName As String, AlertID As Integer, VendorTime As Object) As System.Web.Mvc.JsonResult

            'objects
            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim BroadcastOrdersAlertCommentList As Generic.List(Of AdvantageFramework.DTO.Media.OrderAlertComment) = Nothing
            Dim SQLHoursOffset As Decimal = 0

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

            BroadcastOrdersAlertCommentList = New Generic.List(Of AdvantageFramework.DTO.Media.OrderAlertComment)

            Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                BroadcastOrdersAlertCommentList.AddRange(DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.OrderAlertComment)("exec advsp_media_broadcast_worksheet_order_alert_comments_by_alertid {0}", AlertID).ToList)

                SQLHoursOffset = AdvantageFramework.Database.Procedures.Generic.LoadSQLHoursOffset(DbContext)

            End Using

            For Each BroadcastOrdersAlertComment In BroadcastOrdersAlertCommentList

                If SQLHoursOffset <> 0 Then
                    'set to UTC time
                    BroadcastOrdersAlertComment.CommentDate = DateAdd(DateInterval.Hour, -SQLHoursOffset, CType(BroadcastOrdersAlertComment.CommentDate, DateTime))

                End If
                'set as string due to browser adding/substracting additional time !
                BroadcastOrdersAlertComment.CommentDateString = BroadcastOrdersAlertComment.CommentDate.Value.AddMinutes(-CInt(VendorTime(0))).ToString("MM/dd/yyyy hh:mm tt")

            Next

            DataSourceResult = BroadcastOrdersAlertCommentList.ToDataSourceResult(DataSourceRequest)

            Return Json(DataSourceResult, System.Web.Mvc.JsonRequestBehavior.AllowGet)

        End Function

#End Region

    End Class

End Namespace
