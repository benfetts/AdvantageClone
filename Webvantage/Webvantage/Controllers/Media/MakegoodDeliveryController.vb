Imports Kendo.Mvc.Extensions
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports System.Linq
Imports System.Linq.Expressions
Imports System

Namespace Controllers.Media

    <System.Web.Mvc.AllowAnonymous>
    Public Class MakegoodDeliveryController
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

        Private Sub SetMaxRevisionNumber(DbContext As AdvantageFramework.Database.DbContext, ByRef MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel)

            Dim OrderNumber As Integer = 0
            Dim WorksheetMarketID As Integer = 0

            OrderNumber = MakegoodDeliveryViewModel.OrderNumber

            WorksheetMarketID = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetails")
                                 Where Entity.OrderNumber = OrderNumber
                                 Select Entity.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID).FirstOrDefault

            MakegoodDeliveryViewModel.MaxRevisionNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.Load(DbContext)
                                                           Where Entity.MediaBroadcastWorksheetMarketID = WorksheetMarketID
                                                           Select Entity.RevisionNumber).Max

        End Sub
        Private Function IsOrderModified(DbContext As AdvantageFramework.Database.DbContext, MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel) As Boolean

            SetMaxRevisionNumber(DbContext, MakegoodDeliveryViewModel)

            If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetails")
                Where Entity.OrderNumber = MakegoodDeliveryViewModel.OrderNumber AndAlso
                          Entity.MediaBroadcastWorksheetMarketDetail.RevisionNumber = MakegoodDeliveryViewModel.MaxRevisionNumber
                Select Entity.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID).Any = False Then

                IsOrderModified = True

            ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetails")
                    Where Entity.OrderNumber = MakegoodDeliveryViewModel.OrderNumber AndAlso
                          Entity.MediaBroadcastWorksheetMarketDetail.RevisionNumber = MakegoodDeliveryViewModel.MaxRevisionNumber AndAlso
                          Entity.MediaBroadcastWorksheetOrderStatusID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified
                    Select Entity.MediaBroadcastWorksheetMarketDetailID).Any Then

                IsOrderModified = True

            ElseIf DbContext.Database.SqlQuery(Of Boolean)(String.Format("exec dbo.advsp_media_manager_generated_report_matches_order_active_revision {0}, '{1}'", MakegoodDeliveryViewModel.OrderNumber, MakegoodDeliveryViewModel.MediaType)).First = False Then

                IsOrderModified = True

            Else

                IsOrderModified = False

            End If

        End Function
        'Private Function GetRegistryKey(ByVal RegPath As String) As Microsoft.Win32.RegistryKey

        '    Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

        '    If System.Environment.Is64BitOperatingSystem AndAlso System.Environment.Is64BitProcess Then

        '        RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage\" & RegPath, False)

        '    Else

        '        RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Advantage\" & RegPath, False)

        '    End If

        '    GetRegistryKey = RegistryKey

        'End Function
        Private Function GetSqlConnectionStringBuilder(DatabaseName As String) As System.Data.SqlClient.SqlConnectionStringBuilder

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

            GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

            SqlConnectionStringBuilder.InitialCatalog = DatabaseName

            GetSqlConnectionStringBuilder = SqlConnectionStringBuilder

        End Function
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
        Private Function Load(Url() As String) As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim OrderNumber As Integer = 0
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim RevisedByName As String = Nothing
            Dim Dayparts As Generic.List(Of Object) = Nothing
            'Dim CableNetworks As Generic.List(Of Object) = Nothing
            Dim MediaManagerGeneratedReportSentInfo As AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo = Nothing
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing

            MakegoodDeliveryViewModel = New AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel
            MakegoodDeliveryViewModel.IsValid = True

            Try

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "OrderNumber"

                            OrderNumber = CInt(VariableValues(1).ToString)

                        Case "Email"

                            Email = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                MakegoodDeliveryViewModel.IsValid = False
            End Try

            If MakegoodDeliveryViewModel.IsValid Then

                ViewData("Title") = "Order/Makegood Form " & OrderNumber.ToString

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                If String.IsNullOrWhiteSpace(DatabaseName) = False Then

                    SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                End If

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                        String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                    Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, 0, SqlConnectionStringBuilder.ConnectionString)

                    MakegoodDeliveryController = New AdvantageFramework.Controller.Media.MakegoodDeliveryController(Session)

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            DbContext.Database.Connection.Open()

                            Dayparts = New Generic.List(Of Object)

                            'CableNetworks = New Generic.List(Of Object)

                            Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                DataContext.Connection.Open()

                                MakegoodDeliveryViewModel.OrderNumber = OrderNumber

                                MakegoodDeliveryViewModel.MediaType = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext)
                                                                       Where Entity.OrderNumber = OrderNumber
                                                                       Select Entity).First.MediaFrom.Substring(0, 1)

                                MakegoodDeliveryViewModel.LineNumbers = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT DISTINCT b.LINE_NBR 
                                                                                                                             FROM dbo.MEDIA_MGR_GENERATED_REPORT a
	                                                                                                                            INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL b ON a.MEDIA_MGR_GENERATED_REPORT_ID = b.MEDIA_MGR_GENERATED_REPORT_ID 
                                                                                                                             WHERE a.ORDER_NBR = {0}", OrderNumber)).ToArray

                                MakegoodDeliveryController.GetOrderInfo(DbContext, OrderNumber, MakegoodDeliveryViewModel.MediaType, MakegoodDeliveryViewModel)

                                MakegoodDeliveryViewModel.TermsOfAgreement = AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.VEN_COST_COL_TERMS)

                                If MakegoodDeliveryViewModel.InDifferentOrderState = False AndAlso Not IsOrderModified(DbContext, MakegoodDeliveryViewModel) Then

                                    MakegoodDeliveryController.CreateWSDataTable(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                                    MakegoodDeliveryController.PopulateWSDataTableForWebvantageEdit(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                                    MediaManagerGeneratedReportSentInfo = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportSentInfo.Load(DbContext)
                                                                           Where Entity.MediaManagerGeneratedReport.OrderNumber = OrderNumber AndAlso
                                                                                 Entity.Email.ToUpper = Email.ToUpper
                                                                           Select Entity).FirstOrDefault

                                    If MediaManagerGeneratedReportSentInfo IsNot Nothing Then

                                        VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, MediaManagerGeneratedReportSentInfo.VendorRepresentativeCode, MediaManagerGeneratedReportSentInfo.VendorCode)

                                        If VendorRepresentative IsNot Nothing Then

                                            MakegoodDeliveryViewModel.SalesRep = VendorRepresentative.ToString
                                            MakegoodDeliveryViewModel.SalesRepPhone = VendorRepresentative.Telephone

                                            If MakegoodDeliveryViewModel.IsOriginalOrderMode Then

                                                AdvantageFramework.MediaManager.AddUpdateOrderStatus(MakegoodDeliveryViewModel.MediaType, OrderNumber, SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, MakegoodDeliveryViewModel.SalesRep, AdvantageFramework.Database.Entities.OrderStatusType.OrderRecieved)

                                            End If

                                        End If

                                    End If

                                    MakegoodDeliveryViewModel.OrderStatus = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT dbo.[advfn_makegood_get_order_status]({0}, '{1}')",
                                            MakegoodDeliveryViewModel.OrderNumber, MakegoodDeliveryViewModel.MediaType)).FirstOrDefault

                                    If MakegoodDeliveryViewModel.MediaType = "T" Then

                                        Dayparts.AddRange((From Entity In AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV)
                                                           Select Entity.ID, Entity.Description).ToList)

                                    ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                                        Dayparts.AddRange((From Entity In AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio)
                                                           Select Entity.ID, Entity.Description).ToList)

                                    End If

                                    ViewBag.Dayparts = Dayparts

                                    'CableNetworks.AddRange((From Entity In AdvantageFramework.Database.Procedures.CableNetworkStation.Load(DbContext)
                                    '                        Select Entity.Code, Entity.Description).OrderBy(Function(Entity) Entity.Description).ToList)

                                    'ViewBag.CableNetworks = CableNetworks

                                    ViewBag.CableNetworks = MakegoodDeliveryViewModel.CableNetworks

                                    MakegoodDeliveryViewModel.SalesRepEmail = Email

                                    MakegoodDeliveryViewModel.QueryString = "|" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & DatabaseName & "&OrderNumber=" & OrderNumber & "&Email=" & Email) & "|"
                                    MakegoodDeliveryViewModel.DatabaseName = SqlConnectionStringBuilder.InitialCatalog

                                Else

                                    MakegoodDeliveryViewModel.InDifferentOrderState = True

                                End If

                            End Using

                        End Using

                    Catch ex As Exception
                        MakegoodDeliveryViewModel.IsValid = False
                    End Try

                Else

                    MakegoodDeliveryViewModel.IsValid = False

                End If

            End If

            Load = MakegoodDeliveryViewModel

        End Function
        Private Function LoadMakegoodOutstandingForm(Url() As String) As AdvantageFramework.ViewModels.Media.MakegoodOutstandingViewModel

            'objects
            Dim MakegoodOutstandingViewModel As AdvantageFramework.ViewModels.Media.MakegoodOutstandingViewModel = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim MediaManagerGeneratedReportSentInfo As AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim WebvantageURL As String = Nothing
            Dim BroadcastOrdersForVendorRepList As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep) = Nothing

            MakegoodOutstandingViewModel = New AdvantageFramework.ViewModels.Media.MakegoodOutstandingViewModel
            MakegoodOutstandingViewModel.IsValid = True

            Try

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            MakegoodOutstandingViewModel.DatabaseName = VariableValues(1).ToString

                        Case "VendorCode"

                            MakegoodOutstandingViewModel.VendorCode = VariableValues(1).ToString

                        Case "VendorRepCode"

                            MakegoodOutstandingViewModel.VendorRepCode = VariableValues(1).ToString

                        Case "OrderNumber"

                            MakegoodOutstandingViewModel.OrderNumber = CInt(VariableValues(1).ToString)

                        Case "Email"

                            MakegoodOutstandingViewModel.Email = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                MakegoodOutstandingViewModel.IsValid = False
            End Try

            If MakegoodOutstandingViewModel.IsValid Then

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(MakegoodOutstandingViewModel.DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                If String.IsNullOrWhiteSpace(MakegoodOutstandingViewModel.DatabaseName) = False Then

                    SqlConnectionStringBuilder.InitialCatalog = MakegoodOutstandingViewModel.DatabaseName

                End If

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                        String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        DbContext.Database.Connection.Open()

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

                        MakegoodOutstandingViewModel.AgencyName = Agency.Name

                        ViewData("Title") = Agency.Name & " Order Dashboard"

                        Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            DataContext.Connection.Open()

                            If Not String.IsNullOrWhiteSpace(MakegoodOutstandingViewModel.VendorCode) AndAlso Not String.IsNullOrWhiteSpace(MakegoodOutstandingViewModel.VendorRepCode) Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, MakegoodOutstandingViewModel.VendorRepCode, MakegoodOutstandingViewModel.VendorCode)

                            ElseIf Not String.IsNullOrWhiteSpace(MakegoodOutstandingViewModel.Email) AndAlso MakegoodOutstandingViewModel.OrderNumber > 0 Then

                                MediaManagerGeneratedReportSentInfo = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportSentInfo.Load(DbContext)
                                                                       Where Entity.MediaManagerGeneratedReport.OrderNumber = MakegoodOutstandingViewModel.OrderNumber AndAlso
                                                                             Entity.Email.ToUpper = MakegoodOutstandingViewModel.Email.ToUpper
                                                                       Select Entity).FirstOrDefault

                                If MediaManagerGeneratedReportSentInfo IsNot Nothing Then

                                    MakegoodOutstandingViewModel.VendorRepCode = MediaManagerGeneratedReportSentInfo.VendorRepresentativeCode

                                    MakegoodOutstandingViewModel.VendorCode = MediaManagerGeneratedReportSentInfo.VendorCode

                                    VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, MakegoodOutstandingViewModel.VendorRepCode, MakegoodOutstandingViewModel.VendorCode)

                                End If

                            End If

                            If VendorRepresentative IsNot Nothing Then

                                MakegoodOutstandingViewModel.SalesRepEmail = VendorRepresentative.EmailAddress

                            Else

                                MakegoodOutstandingViewModel.IsValid = False

                            End If

                            BroadcastOrdersForVendorRepList = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep)(String.Format("exec advsp_broadcast_orders_for_vendor_rep '{0}', '{1}', 1", MakegoodOutstandingViewModel.VendorCode, MakegoodOutstandingViewModel.VendorRepCode)).ToList

                            For Each BroadcastOrdersForVendorRep In BroadcastOrdersForVendorRepList

                                If DateAdd(DateInterval.Day, BroadcastOrdersForVendorRep.DropAfterDays, BroadcastOrdersForVendorRep.FlightEndDate) > Now AndAlso {6, 12}.Contains(BroadcastOrdersForVendorRep.OrderProcessControl) = False Then

                                    BroadcastOrdersForVendorRep.Link = "<a href=""" & WebvantageURL & "Media/MakegoodDelivery/MakegoodOrderForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & MakegoodOutstandingViewModel.DatabaseName & "&OrderNumber=" & BroadcastOrdersForVendorRep.OrderNumber & "&Email=" & BroadcastOrdersForVendorRep.VendorRepEmail) & "%7C"" ><u><strong> View</strong></u></a>"

                                    MakegoodOutstandingViewModel.BroadcastOrdersForVendorRepList.Add(BroadcastOrdersForVendorRep)

                                End If

                            Next

                        End Using

                    End Using

                Else

                    MakegoodOutstandingViewModel.IsValid = False

                End If

            End If

            LoadMakegoodOutstandingForm = MakegoodOutstandingViewModel

        End Function
        Private Sub AddAlertComment(DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext,
                                    OrderNumber As Integer, MediaType As String, SalesRepEmail As String, Comment As String, ByRef VendorCode As String, ByRef VendorRepCode As String)

            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim AlertID As Integer = 0
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

            If MediaType = "R" Then

                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If RadioOrder IsNot Nothing Then

                    VendorCode = RadioOrder.VendorCode
                    AlertID = RadioOrder.AlertID

                End If

            ElseIf MediaType = "T" Then

                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If TVOrder IsNot Nothing Then

                    VendorCode = TVOrder.VendorCode
                    AlertID = TVOrder.AlertID

                End If

            End If

            If AlertID <> 0 Then

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                VendorRepresentative = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, VendorCode)
                                        Where Entity.EmailAddress.ToUpper = SalesRepEmail.ToUpper
                                        Select Entity).FirstOrDefault

                If VendorRepresentative IsNot Nothing AndAlso Alert IsNot Nothing Then

                    VendorRepCode = VendorRepresentative.Code

                    AlertComment = New AdvantageFramework.Database.Entities.AlertComment

                    AlertComment.DbContext = DbContext
                    AlertComment.AlertID = AlertID
                    AlertComment.VendorRepresentativeCode = VendorRepresentative.Code
                    AlertComment.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                    AlertComment.Comment = Comment

                    If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) Then

                        For Each AlertRecipient In AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, AlertID).ToList

                            AlertRecipient.HasBeenRead = Nothing
                            AlertRecipient.ProcessedDate = Nothing

                            AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, AlertRecipient)

                        Next

                        For Each AlertRecipientDismissed In AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, AlertID).ToList

                            AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                            AlertRecipient.DbContext = DbContext

                            AlertRecipient.AlertID = AlertRecipientDismissed.AlertID
                            AlertRecipient.ID = AlertRecipientDismissed.ID
                            AlertRecipient.EmployeeCode = AlertRecipientDismissed.EmployeeCode
                            AlertRecipient.EmployeeEmail = AlertRecipientDismissed.EmployeeEmail
                            AlertRecipient.ProcessedDate = Nothing
                            AlertRecipient.IsNewAlert = AlertRecipientDismissed.IsNewAlert
                            AlertRecipient.HasBeenRead = Nothing

                            If AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Delete(DbContext, AlertRecipientDismissed) Then

                                AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                            End If

                        Next

                        AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, "[Alert Updated]", IncludeOriginator:=True)

                    End If

                End If

            End If

        End Sub
        Private Function ValidateMakegoodDeliveryDetailViewModel(MakegoodDeliveryDetailViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryDetailViewModel, ByRef IsValid As Boolean) As String

            'objects
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim ErrorText As String = String.Empty

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(MakegoodDeliveryDetailViewModel.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                If PropertyDescriptor.Name.StartsWith("Spot") Then

                    If CInt(PropertyDescriptor.GetValue(MakegoodDeliveryDetailViewModel)) Mod 2 <> 0 Then

                        ErrorText = "All spots for a bookend must be even."
                        IsValid = False
                        Exit For

                    End If

                End If

            Next

            ValidateMakegoodDeliveryDetailViewModel = ErrorText

        End Function
        Private Function GetXMLDocument(QueryString As String, AsNew As Boolean) As System.Web.Mvc.FileContentResult

            'objects
            Dim Url() As String = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim OrderNumber As Integer = 0
            Dim IsValid As Boolean = True
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim VendorReps As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep) = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim MediaFrom As String = Nothing
            Dim ClientName As String = Nothing
            Dim VendorName As String = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                Url = QueryString.Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "OrderNumber"

                            OrderNumber = CInt(VariableValues(1).ToString)

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

                If String.IsNullOrWhiteSpace(DatabaseName) = False Then

                    SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                End If

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                        String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        'AdvantageFramework.Security.Application.Advantage is necessary so we can connect to Nielsen for XML file data!
                        Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                        Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            VendorReps = New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep)

                            For Each VR In (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportSentInfo.LoadByOrderNumber(DbContext, OrderNumber)
                                            Select Entity.VendorCode, Entity.VendorRepresentativeCode).Distinct.ToList

                                VendorReps.Add(New AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep(VR.VendorCode, VR.VendorRepresentativeCode))

                            Next

                            MediaFrom = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext)
                                         Where Entity.OrderNumber = OrderNumber
                                         Select Entity).First.MediaFrom

                            If MediaFrom = "TV" Then

                                Vendor = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail.Vendor")
                                          Where Entity.OrderNumber = OrderNumber
                                          Select Entity).FirstOrDefault.MediaBroadcastWorksheetMarketDetail.Vendor

                                If Vendor IsNot Nothing AndAlso Vendor.IsCableSystem And Vendor.NCCTVSyscodeID.HasValue Then

                                    MemoryStream = AdvantageFramework.Media.BuildXMLFile(Session, DbContext, DataContext, OrderNumber, VendorReps, Vendor.Code)

                                    FileContentResult = New System.Web.Mvc.FileContentResult(MemoryStream.ToArray, AdvantageFramework.FileSystem.GetMIMETypeByExtension("XML"))

                                    If AdvantageFramework.MediaManager.GetOrderClientAndVendor(DbContext, MediaFrom.Substring(0, 1), OrderNumber, ClientName, VendorName) Then

                                        FileContentResult.FileDownloadName = "Order_" & ClientName & "_" & VendorName & "_" & OrderNumber & ".SCX"

                                    Else

                                        FileContentResult.FileDownloadName = "Order.SCX"

                                    End If

                                Else

                                    MemoryStream = AdvantageFramework.Media.BuildBroadcastXMLFile(Session, DbContext, DataContext, OrderNumber, MediaFrom, VendorReps, AsNew:=AsNew)

                                    FileContentResult = New System.Web.Mvc.FileContentResult(MemoryStream.ToArray, AdvantageFramework.FileSystem.GetMIMETypeByExtension("XML"))

                                    If AdvantageFramework.MediaManager.GetOrderClientAndVendor(DbContext, MediaFrom.Substring(0, 1), OrderNumber, ClientName, VendorName) Then

                                        FileContentResult.FileDownloadName = "Order_" & ClientName & "_" & VendorName & "_" & OrderNumber & ".XML"

                                    Else

                                        FileContentResult.FileDownloadName = "Order.XML"

                                    End If

                                End If

                            ElseIf MediaFrom = "Radio" Then

                                MemoryStream = AdvantageFramework.Media.BuildRadioBroadcastXMLFile(Session, DbContext, DataContext, OrderNumber, MediaFrom, VendorReps, AsNew:=AsNew)

                                FileContentResult = New System.Web.Mvc.FileContentResult(MemoryStream.ToArray, AdvantageFramework.FileSystem.GetMIMETypeByExtension("XML"))

                                If AdvantageFramework.MediaManager.GetOrderClientAndVendor(DbContext, MediaFrom.Substring(0, 1), OrderNumber, ClientName, VendorName) Then

                                    FileContentResult.FileDownloadName = "Order_" & ClientName & "_" & VendorName & "_" & OrderNumber & ".XML"

                                Else

                                    FileContentResult.FileDownloadName = "Order.XML"

                                End If

                            End If

                        End Using

                    End Using

                End If

            End If

            GetXMLDocument = FileContentResult

        End Function
        Private Function IsUsing3rdPartyData(DbContext As AdvantageFramework.Database.DbContext, MediaType As String, MakegoodDeliveryDetailViewModelID As Integer) As Boolean

            Dim Is3rdParty As Boolean = False
            Dim MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing

            MediaBroadcastWorksheetMarketStagingDetail = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.LoadByID(DbContext, MakegoodDeliveryDetailViewModelID)

            If MediaBroadcastWorksheetMarketStagingDetail IsNot Nothing Then

                MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketID)

                If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaType = "T" AndAlso MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue Then

                    Is3rdParty = True

                ElseIf MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaType = "R" AndAlso MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1.HasValue Then

                    Is3rdParty = True

                End If

            End If

            IsUsing3rdPartyData = Is3rdParty

        End Function
        Private Function GetProposalXMLDocument(QueryString As String) As System.Web.Mvc.FileContentResult

            'objects
            Dim Url() As String = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim OrderNumber As Integer = 0
            Dim IsValid As Boolean = True
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim VendorReps As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep) = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim MediaFrom As String = Nothing
            Dim ClientName As String = Nothing
            Dim VendorName As String = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim MediaBroadcastWorksheetMarketID As Integer = 0

            Try

                Url = QueryString.Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "OrderNumber"

                            OrderNumber = CInt(VariableValues(1).ToString)

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

                If String.IsNullOrWhiteSpace(DatabaseName) = False Then

                    SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                End If

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                        String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                    'AdvantageFramework.Security.Application.Advantage is necessary so we can connect to Nielsen for XML file data!
                    Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, 0, SqlConnectionStringBuilder.ConnectionString)

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            VendorReps = New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep)

                            For Each VR In (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportSentInfo.LoadByOrderNumber(DbContext, OrderNumber)
                                            Select Entity.VendorCode, Entity.VendorRepresentativeCode).Distinct.ToList

                                VendorReps.Add(New AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep(VR.VendorCode, VR.VendorRepresentativeCode))

                            Next

                            MediaFrom = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext)
                                         Where Entity.OrderNumber = OrderNumber
                                         Select Entity).First.MediaFrom

                            If MediaFrom = "Radio" AndAlso VendorReps.Count > 0 Then

                                MediaBroadcastWorksheetMarketID = DbContext.Database.SqlQuery(Of Integer)(String.Format("Select Top 1 MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID From [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD " &
                                                            "INNER Join [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                                                            "WHERE ORDER_NBR = {0}", OrderNumber)).FirstOrDefault

                                MemoryStream = AdvantageFramework.Media.BuildXMLProposalFile(Session, DbContext, MediaBroadcastWorksheetMarketID, False, VendorReps(0).VendorCode, Nothing)

                                FileContentResult = New System.Web.Mvc.FileContentResult(MemoryStream.ToArray, AdvantageFramework.FileSystem.GetMIMETypeByExtension("XML"))

                                If AdvantageFramework.MediaManager.GetOrderClientAndVendor(DbContext, MediaFrom.Substring(0, 1), OrderNumber, ClientName, VendorName) Then

                                    FileContentResult.FileDownloadName = "Proposal_" & ClientName & "_" & VendorName & "_" & OrderNumber & ".XML"

                                Else

                                    FileContentResult.FileDownloadName = "Proposal.XML"

                                End If


                                'MemoryStream = AdvantageFramework.Media.BuildRadioBroadcastXMLFile(Session, DbContext, DataContext, OrderNumber, MediaFrom, VendorReps, AsNew:=AsNew)

                                'FileContentResult = New System.Web.Mvc.FileContentResult(MemoryStream.ToArray, AdvantageFramework.FileSystem.GetMIMETypeByExtension("XML"))

                                'If AdvantageFramework.MediaManager.GetOrderClientAndVendor(DbContext, MediaFrom.Substring(0, 1), OrderNumber, ClientName, VendorName) Then

                                '    FileContentResult.FileDownloadName = "Order_" & ClientName & "_" & VendorName & "_" & OrderNumber & ".XML"

                                'Else

                                '    FileContentResult.FileDownloadName = "Order.XML"

                                'End If

                            End If

                        End Using

                    End Using

                End If

            End If

            GetProposalXMLDocument = FileContentResult

        End Function

#Region " Views "

        <System.Web.Mvc.AllowAnonymous()>
        Public Function MakegoodOrderForm() As System.Web.Mvc.ActionResult

            'objects
            Dim Url() As String = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing

            Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

            MakegoodDeliveryViewModel = Load(Url)

            MakegoodOrderForm = View(MakegoodDeliveryViewModel)

        End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function UpdateMakegoodDeliveryDetail(MediaType As String, DatabaseName As String, MakegoodDeliveryDetailViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryDetailViewModel,
                                                     OrderNumber As Integer) As String

            'objects
            Dim MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail = Nothing
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
            Dim DaysAndTime As AdvantageFramework.DTO.DaysAndTime = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = Nothing
            Dim DateCounter As Integer = 0
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim Dayparts As Generic.List(Of AdvantageFramework.Database.Entities.Daypart) = Nothing
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim CableNetworkStations As Generic.List(Of AdvantageFramework.Database.Entities.CableNetworkStation) = Nothing
            Dim CableNetworkStation As AdvantageFramework.Database.Entities.CableNetworkStation = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim UpdateDateRates As Boolean = False

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(MakegoodDeliveryDetailViewModel).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            MakegoodDeliveryViewModel = New AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel
            MakegoodDeliveryViewModel.IsOriginalOrderMode = False
            MakegoodDeliveryViewModel.MediaType = MediaType
            MakegoodDeliveryViewModel.OrderNumber = OrderNumber

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

            Using DbContext As New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                MakegoodDeliveryController = New AdvantageFramework.Controller.Media.MakegoodDeliveryController(Session)

                DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Session)

                DaysAndTime = New AdvantageFramework.DTO.DaysAndTime(If(MediaType = "T", DaysAndTime.BroadcastTypes.TV, DaysAndTime.BroadcastTypes.Radio))

                If MediaType = "T" Then

                    Dayparts = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV).ToList

                ElseIf MediaType = "R" Then

                    Dayparts = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio).ToList

                End If

                CableNetworkStations = AdvantageFramework.Database.Procedures.CableNetworkStation.Load(DbContext).ToList

                Using DataContext = New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                    MediaBroadcastWorksheetMarketStagingDetail = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.LoadByID(DbContext, MakegoodDeliveryDetailViewModel.ID)

                    If MediaBroadcastWorksheetMarketStagingDetail IsNot Nothing Then

                        DaysAndTime.IsUsing3rdPartyData = IsUsing3rdPartyData(DbContext, MediaType, MakegoodDeliveryDetailViewModel.ID)

                        DaysAndTimeController.ParseDays(DaysAndTime, MakegoodDeliveryDetailViewModel.Days, IsValid)

                        If IsValid Then

                            DaysAndTimeController.ParseTime(DaysAndTime, True, MakegoodDeliveryDetailViewModel.StartTime, IsValid)

                            If IsValid Then

                                DaysAndTimeController.ParseTime(DaysAndTime, False, MakegoodDeliveryDetailViewModel.EndTime, IsValid)

                                If IsValid Then

                                    ErrorMessage = DaysAndTimeController.ValidateEntity(DbContext, DataContext, DaysAndTime, IsValid)

                                    If Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                                        IsValid = False

                                    End If

                                End If

                            End If

                        End If

                        If IsValid Then

                            DaysAndTime.SaveToEntity(MediaBroadcastWorksheetMarketStagingDetail)

                            CableNetworkStation = CableNetworkStations.Where(Function(CN) CN.Code = MakegoodDeliveryDetailViewModel.CableNetwork).FirstOrDefault

                            If CableNetworkStation IsNot Nothing Then

                                MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode = CableNetworkStation.NielsenTVStationCode

                            End If

                            MediaBroadcastWorksheetMarketStagingDetail.CableNetworkStationCode = If(String.IsNullOrWhiteSpace(MakegoodDeliveryDetailViewModel.CableNetwork), "", MakegoodDeliveryDetailViewModel.CableNetwork)

                            MediaBroadcastWorksheetMarketStagingDetail.Program = If(String.IsNullOrWhiteSpace(MakegoodDeliveryDetailViewModel.Program), "", MakegoodDeliveryDetailViewModel.Program)
                            MediaBroadcastWorksheetMarketStagingDetail.Length = MakegoodDeliveryDetailViewModel.Length

                            If Dayparts.Where(Function(DP) DP.Description = MakegoodDeliveryDetailViewModel.DaypartDescription).Count > 0 Then

                                MediaBroadcastWorksheetMarketStagingDetail.DaypartID = Dayparts.Where(Function(DP) DP.Description = MakegoodDeliveryDetailViewModel.DaypartDescription).FirstOrDefault.ID

                            End If

                            MediaBroadcastWorksheetMarketStagingDetail.Bookend = MakegoodDeliveryDetailViewModel.Bookend
                            MediaBroadcastWorksheetMarketStagingDetail.ValueAdded = MakegoodDeliveryDetailViewModel.AddedValue
                            MediaBroadcastWorksheetMarketStagingDetail.Comments = If(String.IsNullOrWhiteSpace(MakegoodDeliveryDetailViewModel.Comments), "", MakegoodDeliveryDetailViewModel.Comments)

                            If MediaBroadcastWorksheetMarketStagingDetail.DefaultRate <> MakegoodDeliveryDetailViewModel.DefaultRate Then

                                UpdateDateRates = True

                            End If

                            MediaBroadcastWorksheetMarketStagingDetail.DefaultRate = MakegoodDeliveryDetailViewModel.DefaultRate

                            MediaBroadcastWorksheetMarketStagingDetail.PrimaryRating = MakegoodDeliveryDetailViewModel.PrimaryRating
                            MediaBroadcastWorksheetMarketStagingDetail.SecondaryRating = MakegoodDeliveryDetailViewModel.SecondaryRating

                            MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions = MakegoodDeliveryDetailViewModel.PrimaryImpressions

                            MediaBroadcastWorksheetMarketStagingDetail.ModifiedByUserCode = DbContext.UserCode
                            MediaBroadcastWorksheetMarketStagingDetail.ModifiedDate = Now

                        End If

                        DbContext.Entry(MediaBroadcastWorksheetMarketStagingDetail).State = Entity.EntityState.Modified

                        If IsValid Then

                            For Each MediaBroadcastWorksheetMarketStagingDetailDate In MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketStagingDetailDates.OrderBy(Function(D) D.Date)

                                PropertyDescriptor = PropertyDescriptors.Where(Function(PD) PD.Name = "Spot" & DateCounter).FirstOrDefault

                                If PropertyDescriptor IsNot Nothing Then

                                    MediaBroadcastWorksheetMarketStagingDetailDate.Spots = PropertyDescriptor.GetValue(MakegoodDeliveryDetailViewModel)

                                End If

                                If UpdateDateRates Then

                                    MediaBroadcastWorksheetMarketStagingDetailDate.Rate = MakegoodDeliveryDetailViewModel.DefaultRate

                                Else

                                    PropertyDescriptor = PropertyDescriptors.Where(Function(PD) PD.Name = "Rate" & DateCounter).FirstOrDefault

                                    If PropertyDescriptor IsNot Nothing Then

                                        MediaBroadcastWorksheetMarketStagingDetailDate.Rate = PropertyDescriptor.GetValue(MakegoodDeliveryDetailViewModel)

                                    End If

                                End If

                                DbContext.Entry(MediaBroadcastWorksheetMarketStagingDetailDate).State = Entity.EntityState.Modified

                                DateCounter += 1

                            Next

                            If IsOrderModified(DbContext, MakegoodDeliveryViewModel) Then

                                MakegoodDeliveryViewModel.InDifferentOrderState = True

                            Else

                                DbContext.SaveChanges()

                                MakegoodDeliveryViewModel.LineNumbers = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT DISTINCT b.LINE_NBR 
                                                                                                                             FROM dbo.MEDIA_MGR_GENERATED_REPORT a
	                                                                                                                            INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL b ON a.MEDIA_MGR_GENERATED_REPORT_ID = b.MEDIA_MGR_GENERATED_REPORT_ID 
                                                                                                                             WHERE a.ORDER_NBR = {0}", OrderNumber)).ToArray

                                MakegoodDeliveryController.CreateWSDataTable(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                                MakegoodDeliveryController.PopulateWSDataTableForWebvantageEdit(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                            End If

                        End If

                    End If

                End Using

            End Using

            If MakegoodDeliveryViewModel.InDifferentOrderState Then

                Return Newtonsoft.Json.JsonConvert.SerializeObject(False)

            Else

                Return Newtonsoft.Json.JsonConvert.SerializeObject(MakegoodDeliveryViewModel.MakegoodDataTable)

            End If

        End Function
        Public Function GetDayparts(dbname As String) As JsonResult

            'objects
            Dim Dayparts As Generic.List(Of Object) = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(dbname)

            Dayparts = New Generic.List(Of Object)

            Using DbContext As New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                Dayparts.AddRange((From Entity In AdvantageFramework.Database.Procedures.Daypart.LoadAllActive(DbContext)
                                   Select Entity.ID, Entity.Description).ToList)

            End Using

            Return Json(Dayparts, JsonRequestBehavior.AllowGet)

        End Function
        Public Function ValidateDaysAndTime(DBName As String, MediaType As String, MakegoodDeliveryDetailViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryDetailViewModel) As ActionResult

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
            Dim DaysAndTime As AdvantageFramework.DTO.DaysAndTime = Nothing
            Dim IsValid As Boolean = True
            Dim ReturnObject As Object = Nothing
            Dim ErrorText As String = String.Empty
            Dim Errors As String() = Nothing

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DBName)

            Using DbContext As New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                Using DataContext As New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                    Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                    DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Session)

                    DaysAndTime = New AdvantageFramework.DTO.DaysAndTime(If(MediaType = "T", DaysAndTime.BroadcastTypes.TV, DaysAndTime.BroadcastTypes.Radio))
                    DaysAndTime.StartTime = MakegoodDeliveryDetailViewModel.StartTime
                    DaysAndTime.EndTime = MakegoodDeliveryDetailViewModel.EndTime
                    DaysAndTime.Days = MakegoodDeliveryDetailViewModel.Days
                    DaysAndTime.IsUsing3rdPartyData = IsUsing3rdPartyData(DbContext, MediaType, MakegoodDeliveryDetailViewModel.ID)

                    DaysAndTimeController.ParseTime(DaysAndTime, True, MakegoodDeliveryDetailViewModel.StartTime, IsValid)

                    If Not IsValid Then

                        ErrorText += "Invalid Start Time" & Environment.NewLine

                    End If

                    DaysAndTimeController.ParseTime(DaysAndTime, False, MakegoodDeliveryDetailViewModel.EndTime, IsValid)

                    If Not IsValid Then

                        ErrorText += "Invalid End Time" & Environment.NewLine

                    End If

                    ErrorText += DaysAndTimeController.ValidateDTO(DbContext, DataContext, DaysAndTime, IsValid)

                    If MakegoodDeliveryDetailViewModel.Bookend Then

                        ErrorText += Me.ValidateMakegoodDeliveryDetailViewModel(MakegoodDeliveryDetailViewModel, IsValid)

                    End If

                    Errors = ErrorText.Replace(vbCrLf, "|").Split("|")

                    ErrorText = String.Empty

                    For Each ErrorX In Errors

                        If ErrorX <> "Invalid Time Entry" Then

                            ErrorText += ErrorX & Environment.NewLine

                        End If

                    Next

                End Using

            End Using

            ReturnObject = New With {.IsValid = IsValid,
                                     .ErrorText = ErrorText}

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function AcceptRejectOrder(MediaType As String, OrderNumber As Integer, DatabaseName As String, SalesRep As String,
                                          SalesRepEmail As String, Command As Integer, Comment As String, AlertID As Integer?) As System.Web.Mvc.ActionResult

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim VendorCode As String = Nothing
            Dim VendorRepCode As String = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim DocumentID As Integer = 0
            Dim RedirectToString As String = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
            Dim AcceptRejectComment As String = Nothing

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

            Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                MakegoodDeliveryViewModel = New AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel
                MakegoodDeliveryViewModel.IsOriginalOrderMode = True
                MakegoodDeliveryViewModel.MediaType = MediaType
                MakegoodDeliveryViewModel.OrderNumber = OrderNumber

                If IsOrderModified(DbContext, MakegoodDeliveryViewModel) Then

                    MakegoodDeliveryViewModel.InDifferentOrderState = True

                    RedirectToString = Request.UrlReferrer.OriginalString

                Else

                    If Command = 1 Then

                        Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                        MakegoodDeliveryController = New AdvantageFramework.Controller.Media.MakegoodDeliveryController(Session)

                        MakegoodDeliveryController.DeleteStagingTables(OrderNumber)

                        AdvantageFramework.MediaManager.AddUpdateOrderStatus(MediaType, OrderNumber, SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, SalesRep, AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted)

                        AcceptRejectComment = "Order accepted.  " & Comment

                    ElseIf Command = 2 Then

                        AdvantageFramework.MediaManager.AddUpdateOrderStatus(MediaType, OrderNumber, SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, SalesRep, AdvantageFramework.Database.Entities.OrderStatusType.OrderRejected)

                        AcceptRejectComment = "Order rejected.  " & Comment

                    End If

                    MediaManagerGeneratedReport = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext)
                                                   Where Entity.OrderNumber = OrderNumber
                                                   Select Entity).OrderByDescending(Function(Entity) Entity.LastGeneratedDate).FirstOrDefault

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, MediaManagerGeneratedReport.CreatedByUserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, MediaManagerGeneratedReport.CreatedByUserCode)

                            Using DbContextAlert = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, MediaManagerGeneratedReport.CreatedByUserCode)

                                AddAlertComment(DbContextAlert, SecurityDbContext, DataContext, OrderNumber, MediaType, SalesRepEmail, AcceptRejectComment, VendorCode, VendorRepCode)

                            End Using

                            If Command = 1 AndAlso MediaManagerGeneratedReport IsNot Nothing Then

                                User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, MediaManagerGeneratedReport.CreatedByUserCode)

                                If User IsNot Nothing Then

                                    If AdvantageFramework.MediaManager.LoadDefaultUploadAndSignDocumentWhenSubmitted(SecurityDbContext, User.ID) Then

                                        Report = AdvantageFramework.Reporting.Reports.GetOrderReportForMakegoods(DbContext, OrderNumber, MediaManagerGeneratedReport.MediaFrom, MediaManagerGeneratedReport.CreatedByUserCode)

                                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                        If Report IsNot Nothing AndAlso Agency IsNot Nothing Then

                                            If AdvantageFramework.Reporting.Reports.SendToDocumentManager(DbContext, Report, Agency, VendorCode, OrderNumber, MediaType, "Media Order", DocumentID) Then

                                                Using DbContextSignDocument = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, User.UserCode)

                                                    AdvantageFramework.DocumentManager.SignDocument(DbContextSignDocument, DataContext, SecurityDbContext, User.ID, Agency, SalesRep, DocumentID, MediaType, SalesRepEmail, Request.PhysicalApplicationPath,
                                                        OrderNumber, AlertID, VendorCode, VendorRepCode)

                                                End Using

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        End Using

                    End Using

                    RedirectToString = Replace(Request.UrlReferrer.OriginalString, "MakegoodOrderForm", "MakegoodOutstandingForm")

                End If

            End Using

            Return Json(RedirectToString, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function CancelAcceptRejectOrder() As System.Web.Mvc.ActionResult

            'objects
            Dim RedirectToString As String = Nothing

            RedirectToString = Replace(Request.UrlReferrer.OriginalString, "MakegoodOrderForm", "MakegoodOutstandingForm")

            Return Json(RedirectToString, JsonRequestBehavior.AllowGet)

        End Function
        '<AcceptVerbs("GET", "POST"),
        'System.Web.Mvc.AllowAnonymous()>
        'Public Function Makegood(DatabaseName As String, SpotDates As Dictionary(Of String, Integer), MediaBroadcastWorksheetMarketStagingDetailID As Integer, MakegoodSpots As Integer,
        '                         ColumnName As String, OrderNumber As Integer, MediaType As String) As JsonResult

        '    'objects
        '    Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
        '    Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
        '    Dim IntegerDateValue As Integer = 0
        '    Dim DetailDate As Date = Nothing
        '    Dim Session As AdvantageFramework.Security.Session = Nothing
        '    Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
        '    Dim ReturnObject As Object = Nothing

        '    MakegoodDeliveryViewModel = New AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel
        '    MakegoodDeliveryViewModel.IsOriginalOrderMode = False
        '    MakegoodDeliveryViewModel.MediaType = MediaType
        '    MakegoodDeliveryViewModel.OrderNumber = OrderNumber

        '    SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

        '    IntegerDateValue = SpotDates.Item(ColumnName)

        '    DetailDate = DateSerial(Mid(IntegerDateValue, 1, 4), Mid(IntegerDateValue, 5, 2), Mid(IntegerDateValue, 7, 2))

        '    Using DbContext As New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

        '        If IsOrderModified(DbContext, MakegoodDeliveryViewModel) Then

        '            MakegoodDeliveryViewModel.InDifferentOrderState = True

        '            ReturnObject = New With {.success = False,
        '                                     .data = Request.UrlReferrer.OriginalString}

        '        Else

        '            Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

        '            MakegoodDeliveryController = New AdvantageFramework.Controller.Media.MakegoodDeliveryController(Session)

        '            DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_makegood_staging_add_makegood {0}, '{1}', {2}", MediaBroadcastWorksheetMarketStagingDetailID, DetailDate.ToShortDateString, MakegoodSpots))

        '            MakegoodDeliveryViewModel.LineNumbers = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT DISTINCT b.LINE_NBR 
        '                                                                                                         FROM dbo.MEDIA_MGR_GENERATED_REPORT a
        '                                                                                                         INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL b ON a.MEDIA_MGR_GENERATED_REPORT_ID = b.MEDIA_MGR_GENERATED_REPORT_ID 
        '                                                                                                         WHERE a.ORDER_NBR = {0}", OrderNumber)).ToArray

        '            MakegoodDeliveryController.CreateWSDataTable(DbContext, OrderNumber, MakegoodDeliveryViewModel)

        '            MakegoodDeliveryController.PopulateWSDataTable(DbContext, OrderNumber, MakegoodDeliveryViewModel)

        '            ReturnObject = New With {.success = True,
        '                                     .data = Newtonsoft.Json.JsonConvert.SerializeObject(MakegoodDeliveryViewModel.MakegoodDataTable)}

        '        End If

        '    End Using

        '    Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        '    'Return Newtonsoft.Json.JsonConvert.SerializeObject(MakegoodDeliveryViewModel.MakegoodDataTable)

        'End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function DeleteMakegood(DatabaseName As String, MediaBroadcastWorksheetMarketStagingDetailID As Integer, OrderNumber As Integer, MediaType As String) As JsonResult

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim ReturnObject As Object = Nothing

            MakegoodDeliveryViewModel = New AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel
            MakegoodDeliveryViewModel.IsOriginalOrderMode = False
            MakegoodDeliveryViewModel.MediaType = MediaType
            MakegoodDeliveryViewModel.OrderNumber = OrderNumber

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

            Using DbContext As New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                If IsOrderModified(DbContext, MakegoodDeliveryViewModel) Then

                    MakegoodDeliveryViewModel.InDifferentOrderState = True

                    ReturnObject = New With {.success = False,
                                             .data = Request.UrlReferrer.OriginalString}

                Else

                    Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                    MakegoodDeliveryController = New AdvantageFramework.Controller.Media.MakegoodDeliveryController(Session)

                    DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_makegood_staging_delete_makegood {0}", MediaBroadcastWorksheetMarketStagingDetailID))

                    MakegoodDeliveryViewModel.LineNumbers = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT DISTINCT b.LINE_NBR 
                                                                                                                 FROM dbo.MEDIA_MGR_GENERATED_REPORT a
	                                                                                                                INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL b ON a.MEDIA_MGR_GENERATED_REPORT_ID = b.MEDIA_MGR_GENERATED_REPORT_ID 
                                                                                                                 WHERE a.ORDER_NBR = {0}", OrderNumber)).ToArray

                    MakegoodDeliveryController.CreateWSDataTable(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                    MakegoodDeliveryController.PopulateWSDataTableForWebvantageEdit(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                    ReturnObject = New With {.success = True,
                                             .data = Newtonsoft.Json.JsonConvert.SerializeObject(MakegoodDeliveryViewModel.MakegoodDataTable)}

                End If

            End Using

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

            'Return Newtonsoft.Json.JsonConvert.SerializeObject(MakegoodDeliveryViewModel.MakegoodDataTable)

        End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function DiscardMakegood(OrderNumber As Integer, DatabaseName As String) As System.Web.Mvc.ActionResult

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim RedirectToString As String = Nothing

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

            Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_makegood_staging_delete_by_order {0}", OrderNumber))

            End Using

            RedirectToString = Request.UrlReferrer.OriginalString

            Return Redirect(RedirectToString)

        End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function SubmitMakegood(MediaType As String, OrderNumber As Integer, DatabaseName As String, SalesRep As String, SalesRepEmail As String, Comment As String) As System.Web.Mvc.ActionResult

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim RedirectToString As String = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
            Dim SubmitComment As String = Nothing
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim UnSubmittedWorksheetLineNumbers As IEnumerable(Of Integer) = Nothing
            Dim SubmittedWorksheetLineNumbers As IEnumerable(Of Integer) = Nothing
            Dim OrderLineNumbers As IEnumerable(Of Integer) = Nothing

            MakegoodDeliveryViewModel = New AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel
            MakegoodDeliveryViewModel.IsOriginalOrderMode = False
            MakegoodDeliveryViewModel.MediaType = MediaType
            MakegoodDeliveryViewModel.OrderNumber = OrderNumber

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

            Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                If IsOrderModified(DbContext, MakegoodDeliveryViewModel) Then

                    RedirectToString = Request.UrlReferrer.OriginalString

                Else

                    MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                              Where Entity.OrderNumber = OrderNumber
                                                              Select Entity.MediaBroadcastWorksheetMarketDetailID).Distinct.ToArray

                    UnSubmittedWorksheetLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail")
                                                       Where Entity.IsSubmitted = False AndAlso
                                                             Entity.IsOriginal = False AndAlso
                                                             MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                                       Select Entity.MediaBroadcastWorksheetMarketDetail.LineNumber).Distinct.ToArray

                    DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_makegood_staging_submit {0}", OrderNumber))

                    SubmittedWorksheetLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail")
                                                     Where Entity.IsSubmitted = True AndAlso
                                                           Entity.IsOriginal = False AndAlso
                                                           MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                                     Select Entity.MediaBroadcastWorksheetMarketDetail.LineNumber).Distinct.ToArray

                    SubmittedWorksheetLineNumbers = (From SubmittedWorksheetLineNumber In SubmittedWorksheetLineNumbers
                                                     Where UnSubmittedWorksheetLineNumbers.Contains(SubmittedWorksheetLineNumber)
                                                     Select SubmittedWorksheetLineNumber).Distinct.ToArray

                    If MediaType = "T" Then

                        OrderLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber)
                                            Where SubmittedWorksheetLineNumbers.Contains(Entity.LinkLineNumber)
                                            Select CInt(Entity.LineNumber)).Distinct.ToArray

                    ElseIf MediaType = "R" Then

                        OrderLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber)
                                            Where SubmittedWorksheetLineNumbers.Contains(Entity.LinkLineNumber)
                                            Select CInt(Entity.LineNumber)).Distinct.ToArray

                    End If

                    AdvantageFramework.MediaManager.AddUpdateOrderStatus(MediaType, OrderNumber, SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, SalesRep,
                                                                         AdvantageFramework.Database.Entities.OrderStatusType.MakegoodOfferSubmitted, OrderLineNumbers)

                    MediaManagerGeneratedReport = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext)
                                                   Where Entity.OrderNumber = OrderNumber
                                                   Select Entity).OrderByDescending(Function(Entity) Entity.LastGeneratedDate).FirstOrDefault

                    SubmitComment = "Makegood offer submitted.  " & Comment

                    Using DbContextAlert = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, MediaManagerGeneratedReport.CreatedByUserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, MediaManagerGeneratedReport.CreatedByUserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, MediaManagerGeneratedReport.CreatedByUserCode)

                                AddAlertComment(DbContextAlert, SecurityDbContext, DataContext, OrderNumber, MediaType, SalesRepEmail, SubmitComment, Nothing, Nothing)

                            End Using

                        End Using

                    End Using

                    RedirectToString = Replace(Request.UrlReferrer.OriginalString, "MakegoodOrderForm", "MakegoodOutstandingForm")

                End If

            End Using

            Return Json(RedirectToString, JsonRequestBehavior.AllowGet)

        End Function
        <System.Web.Mvc.AllowAnonymous()>
        Public Function DownloadOrderDocument(QueryString As String) As System.Web.Mvc.FileContentResult

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
            Dim ClientName As String = Nothing
            Dim VendorName As String = Nothing
            Dim OrderNumber As Integer = 0
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing

            Try

                Url = QueryString.Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "OrderNumber"

                            OrderNumber = CInt(VariableValues(1).ToString)

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

                If String.IsNullOrWhiteSpace(DatabaseName) = False Then

                    SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                End If

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        MediaManagerGeneratedReport = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext)
                                                       Where Entity.OrderNumber = OrderNumber
                                                       Select Entity).OrderByDescending(Function(Entity) Entity.LastGeneratedDate).FirstOrDefault

                        Report = AdvantageFramework.Reporting.Reports.GetOrderReportForMakegoods(DbContext, MediaManagerGeneratedReport.OrderNumber, MediaManagerGeneratedReport.MediaFrom, MediaManagerGeneratedReport.CreatedByUserCode)

                        If Report IsNot Nothing Then

                            MemoryStream = New System.IO.MemoryStream

                            Report.ExportToPdf(MemoryStream)

                            FileContentResult = New System.Web.Mvc.FileContentResult(MemoryStream.ToArray, AdvantageFramework.FileSystem.GetMIMETypeByExtension("PDF"))

                            If AdvantageFramework.MediaManager.GetOrderClientAndVendor(DbContext, MediaManagerGeneratedReport.MediaFrom.Substring(0, 1), OrderNumber, ClientName, VendorName) Then

                                FileContentResult.FileDownloadName = "Order Report " & ClientName & "_" & VendorName & "_" & OrderNumber & ".pdf"

                            Else

                                FileContentResult.FileDownloadName = "Order Report " & "_" & OrderNumber & ".pdf"

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    FileContentResult = Nothing
                End Try

            End If

            DownloadOrderDocument = FileContentResult

        End Function
        <System.Web.Mvc.AllowAnonymous()>
        Public Function DownloadXMLDocument(QueryString As String) As System.Web.Mvc.FileContentResult

            DownloadXMLDocument = GetXMLDocument(QueryString, False)

        End Function
        <System.Web.Mvc.AllowAnonymous()>
        Public Function DownloadXMLDocumentAsNew(QueryString As String) As System.Web.Mvc.FileContentResult

            DownloadXMLDocumentAsNew = GetXMLDocument(QueryString, True)

        End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function NewComment(MediaType As String, OrderNumber As Integer, DatabaseName As String, SalesRepEmail As String, Comment As String) As System.Web.Mvc.ActionResult

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim RedirectToString As String = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim VendorCode As String = Nothing
            Dim AlertID As Integer = 0
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

            Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                    Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        If MediaType = "R" Then

                            RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                            If RadioOrder IsNot Nothing Then

                                VendorCode = RadioOrder.VendorCode
                                AlertID = RadioOrder.AlertID

                            End If

                        ElseIf MediaType.ToUpper.StartsWith("T") Then

                            TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                            If TVOrder IsNot Nothing Then

                                VendorCode = TVOrder.VendorCode
                                AlertID = TVOrder.AlertID

                            End If

                        End If

                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                        VendorRepresentative = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, VendorCode)
                                                Where Entity.EmailAddress.ToUpper = SalesRepEmail.ToUpper
                                                Select Entity).FirstOrDefault

                        If VendorRepresentative IsNot Nothing AndAlso Alert IsNot Nothing Then

                            AlertComment = New AdvantageFramework.Database.Entities.AlertComment

                            AlertComment.DbContext = DbContext
                            AlertComment.AlertID = AlertID
                            AlertComment.VendorRepresentativeCode = VendorRepresentative.Code
                            AlertComment.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                            AlertComment.Comment = Comment

                            If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) Then

                                For Each AlertRecipient In AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, AlertID).ToList

                                    AlertRecipient.HasBeenRead = Nothing
                                    AlertRecipient.ProcessedDate = Nothing

                                    AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, AlertRecipient)

                                Next

                                For Each AlertRecipientDismissed In AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, AlertID).ToList

                                    AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                                    AlertRecipient.DbContext = DbContext

                                    AlertRecipient.AlertID = AlertRecipientDismissed.AlertID
                                    AlertRecipient.ID = AlertRecipientDismissed.ID
                                    AlertRecipient.EmployeeCode = AlertRecipientDismissed.EmployeeCode
                                    AlertRecipient.EmployeeEmail = AlertRecipientDismissed.EmployeeEmail
                                    AlertRecipient.ProcessedDate = Nothing
                                    AlertRecipient.IsNewAlert = AlertRecipientDismissed.IsNewAlert
                                    AlertRecipient.HasBeenRead = Nothing

                                    If AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Delete(DbContext, AlertRecipientDismissed) Then

                                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                                    End If

                                Next

                                AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, "[Alert Updated]", IncludeOriginator:=True)

                            End If

                        End If

                    End Using

                End Using

            End Using

        End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function GetResponses(DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest, DatabaseName As String, AlertID As Integer, VendorTime As Object) As JsonResult

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

            Return Json(DataSourceResult, JsonRequestBehavior.AllowGet)

        End Function
        <System.Web.Mvc.AllowAnonymous()>
        Public Function DownloadProposalXML(QueryString As String) As System.Web.Mvc.FileContentResult

            DownloadProposalXML = GetProposalXMLDocument(QueryString)

        End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function Makegood2(MediaType As String, DatabaseName As String, MediaBroadcastWorksheetMarketStagingDetailID As Integer,
                                  MakegoodDeliveryDetailViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryDetailViewModel, OrderNumber As Integer) As JsonResult

            'objects
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim ReturnObject As Object = Nothing
            Dim DateCounter As Integer = 0
            Dim NewMediaBroadcastWorksheetMarketStagingDetailID As Integer = 0
            Dim MediaBroadcastWorksheetMarketStagingDetailDate As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(MakegoodDeliveryDetailViewModel).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            MakegoodDeliveryViewModel = New AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel
            MakegoodDeliveryViewModel.IsOriginalOrderMode = False
            MakegoodDeliveryViewModel.MediaType = MediaType
            MakegoodDeliveryViewModel.OrderNumber = OrderNumber

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

            Using DbContext As New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                If IsOrderModified(DbContext, MakegoodDeliveryViewModel) Then

                    MakegoodDeliveryViewModel.InDifferentOrderState = True

                    ReturnObject = New With {.success = False,
                                             .data = Request.UrlReferrer.OriginalString}

                Else

                    NewMediaBroadcastWorksheetMarketStagingDetailID = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec dbo.advsp_makegood_staging_add_makegood {0}", MediaBroadcastWorksheetMarketStagingDetailID)).FirstOrDefault

                    For Each NewMBWMSDD In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.LoadByMediaBroadcastWorksheetMarketStagingDetailID(DbContext, NewMediaBroadcastWorksheetMarketStagingDetailID).OrderBy(Function(D) D.Date)

                        PropertyDescriptor = PropertyDescriptors.Where(Function(PD) PD.Name = "Spot" & DateCounter).FirstOrDefault

                        If PropertyDescriptor IsNot Nothing AndAlso PropertyDescriptor.GetValue(MakegoodDeliveryDetailViewModel) > 0 Then

                            MediaBroadcastWorksheetMarketStagingDetailDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.LoadByMediaBroadcastWorksheetMarketStagingDetailID(DbContext, MediaBroadcastWorksheetMarketStagingDetailID)
                                                                              Where Entity.Date = NewMBWMSDD.Date
                                                                              Select Entity).SingleOrDefault

                            If MediaBroadcastWorksheetMarketStagingDetailDate IsNot Nothing Then

                                If MediaBroadcastWorksheetMarketStagingDetailDate.Spots < PropertyDescriptor.GetValue(MakegoodDeliveryDetailViewModel) Then

                                    NewMBWMSDD.Spots = MediaBroadcastWorksheetMarketStagingDetailDate.Spots
                                    NewMBWMSDD.MakegoodSpots = MediaBroadcastWorksheetMarketStagingDetailDate.Spots

                                Else

                                    NewMBWMSDD.Spots = PropertyDescriptor.GetValue(MakegoodDeliveryDetailViewModel)
                                    NewMBWMSDD.MakegoodSpots = PropertyDescriptor.GetValue(MakegoodDeliveryDetailViewModel)

                                End If

                                MediaBroadcastWorksheetMarketStagingDetailDate.Spots -= NewMBWMSDD.Spots

                                DbContext.Entry(MediaBroadcastWorksheetMarketStagingDetailDate).State = Entity.EntityState.Modified

                                DbContext.Entry(NewMBWMSDD).State = Entity.EntityState.Modified

                            End If

                        End If

                        DateCounter += 1

                    Next

                    DbContext.SaveChanges()

                    MakegoodDeliveryViewModel.LineNumbers = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT DISTINCT b.LINE_NBR 
                                                                                                                 FROM dbo.MEDIA_MGR_GENERATED_REPORT a
                                                                                                                 INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL b ON a.MEDIA_MGR_GENERATED_REPORT_ID = b.MEDIA_MGR_GENERATED_REPORT_ID 
                                                                                                                 WHERE a.ORDER_NBR = {0}", OrderNumber)).ToArray

                    Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                    MakegoodDeliveryController = New AdvantageFramework.Controller.Media.MakegoodDeliveryController(Session)

                    MakegoodDeliveryController.CreateWSDataTable(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                    MakegoodDeliveryController.PopulateWSDataTableForWebvantageEdit(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                    ReturnObject = New With {.success = True,
                                             .data = Newtonsoft.Json.JsonConvert.SerializeObject(MakegoodDeliveryViewModel.MakegoodDataTable)}

                End If

            End Using

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function AddReplacement(MediaType As String, DatabaseName As String, MediaBroadcastWorksheetMarketStagingDetailID As Integer, OrderNumber As Integer) As JsonResult

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim ReturnObject As Object = Nothing
            Dim NewMediaBroadcastWorksheetMarketStagingDetailID As Integer = 0

            MakegoodDeliveryViewModel = New AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel
            MakegoodDeliveryViewModel.IsOriginalOrderMode = False
            MakegoodDeliveryViewModel.MediaType = MediaType
            MakegoodDeliveryViewModel.OrderNumber = OrderNumber

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

            Using DbContext As New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                If IsOrderModified(DbContext, MakegoodDeliveryViewModel) Then

                    MakegoodDeliveryViewModel.InDifferentOrderState = True

                    ReturnObject = New With {.success = False,
                                             .data = Request.UrlReferrer.OriginalString}

                Else

                    NewMediaBroadcastWorksheetMarketStagingDetailID = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec dbo.advsp_makegood_staging_add_makegood {0}", MediaBroadcastWorksheetMarketStagingDetailID)).FirstOrDefault

                    MakegoodDeliveryViewModel.LineNumbers = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT DISTINCT b.LINE_NBR 
                                                                                                                 FROM dbo.MEDIA_MGR_GENERATED_REPORT a
                                                                                                                 INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL b ON a.MEDIA_MGR_GENERATED_REPORT_ID = b.MEDIA_MGR_GENERATED_REPORT_ID 
                                                                                                                 WHERE a.ORDER_NBR = {0}", OrderNumber)).ToArray

                    Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                    MakegoodDeliveryController = New AdvantageFramework.Controller.Media.MakegoodDeliveryController(Session)

                    MakegoodDeliveryController.CreateWSDataTable(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                    MakegoodDeliveryController.PopulateWSDataTableForWebvantageEdit(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                    ReturnObject = New With {.success = True,
                                             .data = Newtonsoft.Json.JsonConvert.SerializeObject(MakegoodDeliveryViewModel.MakegoodDataTable)}

                End If

            End Using

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function ViewMakegoodDetails(MediaType As String, DatabaseName As String, MediaBroadcastWorksheetMarketStagingDetailID As Integer, OrderNumber As Integer) As JsonResult

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim ReturnObject As Object = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail = Nothing

            MakegoodDeliveryViewModel = New AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel
            MakegoodDeliveryViewModel.IsOriginalOrderMode = False
            MakegoodDeliveryViewModel.MediaType = MediaType
            MakegoodDeliveryViewModel.OrderNumber = OrderNumber

            SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

            Using DbContext As New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                MediaBroadcastWorksheetMarketStagingDetail = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.LoadByID(DbContext, MediaBroadcastWorksheetMarketStagingDetailID)

                MakegoodDeliveryViewModel.LineNumbers = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT DISTINCT b.LINE_NBR 
                                                                                                                 FROM dbo.MEDIA_MGR_GENERATED_REPORT a
                                                                                                                 INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL b ON a.MEDIA_MGR_GENERATED_REPORT_ID = b.MEDIA_MGR_GENERATED_REPORT_ID 
                                                                                                                 WHERE a.ORDER_NBR = {0}", OrderNumber)).ToArray

                MakegoodDeliveryController = New AdvantageFramework.Controller.Media.MakegoodDeliveryController(Session)

                MakegoodDeliveryController.CreateWSDataTable(DbContext, OrderNumber, MakegoodDeliveryViewModel)

                MakegoodDeliveryController.PopulateWSDataTableLoadForWebvantageReview(DbContext, OrderNumber, MakegoodDeliveryViewModel, MediaBroadcastWorksheetMarketStagingDetail.LineNumber)

                ReturnObject = New With {.success = True,
                                         .data = Newtonsoft.Json.JsonConvert.SerializeObject(MakegoodDeliveryViewModel.MakegoodDataTable)}

            End Using

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        End Function
        '<AcceptVerbs("GET", "POST"),
        'System.Web.Mvc.AllowAnonymous()>
        'Public Function ViewMakegoodDetails(MediaType As String, DatabaseName As String, MediaBroadcastWorksheetMarketStagingDetailID As Integer, OrderNumber As Integer) As JsonResult

        '    'objects
        '    Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
        '    Dim Session As AdvantageFramework.Security.Session = Nothing
        '    Dim MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail = Nothing
        '    Dim MediaBroadcastWorksheetController As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        '    Dim MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
        '    Dim MediaBroadcastWorksheetMarketDetailsMakegoodDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsMakegoodDetailsViewModel = Nothing
        '    Dim ReturnObject As Object = Nothing

        '    SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

        '    Using DbContext As New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

        '        Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

        '        MediaBroadcastWorksheetMarketStagingDetail = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.LoadByID(DbContext, MediaBroadcastWorksheetMarketStagingDetailID)

        '        If MediaBroadcastWorksheetMarketStagingDetail IsNot Nothing Then

        '            MediaBroadcastWorksheetController = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Session)

        '            MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetController.MarketDetails_Load(MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID)

        '            MediaBroadcastWorksheetMarketDetailsMakegoodDetailsViewModel = MediaBroadcastWorksheetController.MarketDetailsMakegoodDetails_Load(MediaBroadcastWorksheetMarketDetailsViewModel, MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetail.VendorCode, MediaBroadcastWorksheetMarketStagingDetail.LineNumber)

        '            ReturnObject = New With {.success = True,
        '                                     .data = Newtonsoft.Json.JsonConvert.SerializeObject(MediaBroadcastWorksheetMarketDetailsMakegoodDetailsViewModel.DataTable)}

        '        End If

        '    End Using

        '    Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        'End Function

#Region " MakegoodOutstandingForm "

        <System.Web.Mvc.AllowAnonymous()>
        Public Function MakegoodOutstandingForm() As System.Web.Mvc.ActionResult

            'objects
            Dim Url() As String = Nothing
            Dim MakegoodOutstandingViewModel As AdvantageFramework.ViewModels.Media.MakegoodOutstandingViewModel = Nothing

            Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

            MakegoodOutstandingViewModel = LoadMakegoodOutstandingForm(Url)

            MakegoodOutstandingForm = View(MakegoodOutstandingViewModel)

        End Function
        '<System.Web.Mvc.AllowAnonymous()>
        'Public Function MakegoodOutstanding_Read(DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest, DatabaseName As String, VendorCode As String, VendorRepCode As String) As JsonResult

        '    'objects
        '    Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing
        '    Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
        '    Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        '    Dim WebvantageURL As String = Nothing
        '    Dim BroadcastOrdersForVendorRepList As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep) = Nothing
        '    Dim ReturnBroadcastOrdersForVendorRepList As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep) = Nothing

        '    ReturnBroadcastOrdersForVendorRepList = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep)

        '    SqlConnectionStringBuilder = GetSqlConnectionStringBuilder(DatabaseName)

        '    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

        '        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

        '        WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

        '        Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

        '            BroadcastOrdersForVendorRepList = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep)(String.Format("exec advsp_broadcast_orders_for_vendor_rep '{0}', '{1}', 1", VendorCode, VendorRepCode)).ToList

        '            For Each BroadcastOrdersForVendorRep In BroadcastOrdersForVendorRepList

        '                If DateAdd(DateInterval.Day, BroadcastOrdersForVendorRep.DropAfterDays, BroadcastOrdersForVendorRep.FlightEndDate) > Now AndAlso {6, 12}.Contains(BroadcastOrdersForVendorRep.OrderProcessControl) = False Then

        '                    BroadcastOrdersForVendorRep.Link = "<a href=""" & WebvantageURL & "Media/MakegoodDelivery/MakegoodOrderForm?|" & AdvantageFramework.Security.LicenseKey.Encrypt("Database=" & DatabaseName & "&OrderNumber=" & BroadcastOrdersForVendorRep.OrderNumber & "&Email=" & BroadcastOrdersForVendorRep.VendorRepEmail) & "|"" > View</a>"

        '                    ReturnBroadcastOrdersForVendorRepList.Add(BroadcastOrdersForVendorRep)

        '                End If

        '            Next

        '        End Using

        '        DataSourceResult = ReturnBroadcastOrdersForVendorRepList.ToDataSourceResult(DataSourceRequest)

        '    End Using

        '    Return Json(DataSourceResult, JsonRequestBehavior.AllowGet)

        'End Function

#End Region

#End Region

#End Region

    End Class

End Namespace

