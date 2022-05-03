Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports Kendo.Mvc.Extensions
Imports Newtonsoft.Json
Imports Webvantage.ViewModels

Namespace Controllers.Utilities

    <System.Web.Mvc.AllowAnonymous>
    Public Class DocumentController
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
        Private Function LoadConnectionString(DatabaseName As String) As String

            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
            Dim ConnectionString As String = String.Empty

            ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

            If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

                For Each ConnectionDatabaseProfile In ConnectionDatabaseProfiles

                    If ConnectionDatabaseProfile.DatabaseName = DatabaseName Then

                        ConnectionString = AdvantageFramework.Database.CreateConnectionString(ConnectionDatabaseProfile.ServerName,
                                                                                              ConnectionDatabaseProfile.DatabaseName, False,
                                                                                              ConnectionDatabaseProfile.UserName,
                                                                                              ConnectionDatabaseProfile.GetDecryptPassword(),
                                                                                              AdvantageFramework.Security.Application.Webvantage.ToString)
                        Exit For

                    End If

                Next

            End If

            LoadConnectionString = ConnectionString

        End Function
        Private Function DecrpytQueryString(QueryString As String, ByRef DatabaseName As String, ByRef DownloadedDate As Date, ByRef Email As String,
                                            ByRef FileName As String, ByRef DocumentIDsString As String) As Boolean

            'objects
            Dim Url() As String = Nothing
            Dim Decrpyted As Boolean = False
            Dim DecodedQueryString As String = String.Empty
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DocumentIDs As String = String.Empty

            Try

                Url = QueryString.Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "FileName"

                            FileName = VariableValues(1).ToString

                        Case "DocumentIDs"

                            DocumentIDsString = VariableValues(1).ToString

                        Case "Date"

                            Try

                                DownloadedDate = CDate(VariableValues(1).ToString)

                            Catch ex As Exception
                                DownloadedDate = Now.AddHours(-1)
                            End Try

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
        Private Function DecrpytEncryptedID(EncryptedID As String, ByRef DatabaseName As String, ByRef FileName As String, ByRef DownloadedDate As Date, ByRef Email As String, ByRef DocumentIDString As String) As Boolean

            'objects
            Dim Url() As String = Nothing
            Dim Decrpyted As Boolean = False
            Dim DecodedQueryString As String = String.Empty
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing

            Try

                Url = EncryptedID.Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(EncryptedID)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "FileName"

                            FileName = VariableValues(1).ToString

                        Case "Date"

                            Try

                                DownloadedDate = CDate(VariableValues(1).ToString)

                            Catch ex As Exception
                                DownloadedDate = Now.AddHours(-1)
                            End Try

                        Case "Email"

                            Email = VariableValues(1).ToString

                        Case "DocumentID"

                            DocumentIDString = VariableValues(1).ToString

                    End Select

                Next

                Decrpyted = True

            Catch ex As Exception
                Decrpyted = False
            End Try

            If String.IsNullOrWhiteSpace(FileName) = False Then

                FileName = FileName.Replace("<>", "&")

            End If

            DecrpytEncryptedID = Decrpyted

        End Function
        Private Function ParseDocumentIDsString(DocumentIDsString As String) As Integer()

            'objects
            Dim DocumentIDs As Generic.List(Of Integer) = Nothing
            Dim IDs() As String = Nothing
            Dim DocumentID As Integer = 0

            DocumentIDs = New Generic.List(Of Integer)

            If String.IsNullOrWhiteSpace(DocumentIDsString) = False Then

                IDs = DocumentIDsString.Split(",")

                For Each ID In IDs

                    DocumentID = 0

                    If Integer.TryParse(ID, DocumentID) Then

                        If DocumentID > 0 Then

                            DocumentIDs.Add(DocumentID)

                        End If

                    End If

                Next

            End If

            ParseDocumentIDsString = DocumentIDs.ToArray

        End Function
        Private Function CreateDocumentDetail(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, Document As AdvantageFramework.Database.Entities.Document) As Webvantage.ViewModels.Document.DocumentDownloadDetailModel

            'objects
            Dim DocumentDownloadDetailModel As Webvantage.ViewModels.Document.DocumentDownloadDetailModel = Nothing
            Dim Level As String = ""
            Dim LevelDetails As String = ""
            Dim LevelDetailsHeader As String = ""
            Dim ClientDocument As AdvantageFramework.Database.Entities.ClientDocument = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim DivisionDocument As AdvantageFramework.Database.Entities.DivisionDocument = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim ProductDocument As AdvantageFramework.Database.Entities.ProductDocument = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim CampaignDocument As AdvantageFramework.Database.Entities.CampaignDocument = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim JobDocument As AdvantageFramework.Database.Entities.JobDocument = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponentDocument As AdvantageFramework.Database.Entities.JobComponentDocument = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim AccountPayableDocument As AdvantageFramework.Database.Entities.AccountPayableDocument = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
            Dim ExpenseDetailDocument As AdvantageFramework.Database.Entities.ExpenseDetailDocument = Nothing
            Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim EmployeeDocument As AdvantageFramework.Database.Entities.EmployeeDocument = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim VendorDocument As AdvantageFramework.Database.Entities.VendorDocument = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim ContractReportDocument As AdvantageFramework.Database.Entities.ContractReportDocument = Nothing
            Dim ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing
            Dim AgencyDesktopDocument As AdvantageFramework.Database.Entities.AgencyDesktopDocument = Nothing
            Dim ExecutiveDesktopDocument As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument = Nothing
            Dim OrderDocument As AdvantageFramework.Database.Views.OrderDocument = Nothing
            Dim Order As AdvantageFramework.Database.Views.Order = Nothing

            If DbContext IsNot Nothing AndAlso DataContext IsNot Nothing AndAlso DbContext IsNot Nothing AndAlso Document IsNot Nothing Then

                If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.OfficeDocument).Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.Office).Description

                    LevelDetailsHeader = Level

                    Try

                        LevelDetails = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.OfficeDocument).Include("Office").SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID).Office.Name

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DataContext.ClientDocuments.Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.Client).Description

                    LevelDetailsHeader = Level

                    Try

                        ClientDocument = DataContext.ClientDocuments.SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If ClientDocument IsNot Nothing Then

                            Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientDocument.ClientCode)

                            If Client IsNot Nothing Then

                                LevelDetails = Client.Name

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DataContext.DivisionDocuments.Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.Division).Description

                    LevelDetailsHeader = Level

                    Try

                        DivisionDocument = DataContext.DivisionDocuments.SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If DivisionDocument IsNot Nothing Then

                            Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, DivisionDocument.ClientCode, DivisionDocument.DivisionCode)

                            If Division IsNot Nothing Then

                                LevelDetails = Division.Name

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DataContext.ProductDocuments.Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.Product).Description

                    LevelDetailsHeader = Level

                    Try

                        ProductDocument = DataContext.ProductDocuments.SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If ProductDocument IsNot Nothing Then

                            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ProductDocument.ClientCode, ProductDocument.DivisionCode, ProductDocument.ProductCode)

                            If Product IsNot Nothing Then

                                LevelDetails = Product.Name

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DataContext.CampaignDocuments.Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.Campaign).Description

                    LevelDetailsHeader = Level

                    Try

                        CampaignDocument = DataContext.CampaignDocuments.SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If CampaignDocument IsNot Nothing Then

                            Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, CampaignDocument.CampaignID)

                            If Campaign IsNot Nothing Then

                                LevelDetails = Campaign.Name

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DataContext.JobDocuments.Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.Job).Description

                    LevelDetailsHeader = Level

                    Try

                        JobDocument = DataContext.JobDocuments.SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If JobDocument IsNot Nothing Then

                            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobDocument.JobNumber)

                            If Job IsNot Nothing Then

                                LevelDetails = Job.ToString(True)

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DataContext.JobComponentDocuments.Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent).Description

                    LevelDetailsHeader = Level

                    Try

                        JobComponentDocument = DataContext.JobComponentDocuments.SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If JobComponentDocument IsNot Nothing Then

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobComponentDocument.JobNumber, JobComponentDocument.JobComponentNumber)

                            If JobComponent IsNot Nothing Then

                                LevelDetails = JobComponent.ToString(True, False)

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DataContext.AccountPayableDocuments.Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice).Description

                    LevelDetailsHeader = Level

                    Try

                        AccountPayableDocument = DataContext.AccountPayableDocuments.SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If AccountPayableDocument IsNot Nothing Then

                            AccountPayable = AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableDocument.AccountPayableID).FirstOrDefault

                            If AccountPayable IsNot Nothing Then

                                LevelDetails = AccountPayable.InvoiceNumber & " - " & AccountPayable.InvoiceDescription

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Ad).Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.AdNumber).Description

                    LevelDetailsHeader = Level

                    Try

                        Ad = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Ad).SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If Ad IsNot Nothing Then

                            LevelDetails = Ad.Description

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ExpenseDetailDocument).Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts).Description & " - Details"

                    LevelDetailsHeader = Level

                    Try

                        ExpenseDetailDocument = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ExpenseDetailDocument).SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If ExpenseDetailDocument IsNot Nothing Then

                            ExpenseReportDetail = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByID(DbContext, ExpenseDetailDocument.ExpenseDetailID)

                            If ExpenseReportDetail IsNot Nothing Then

                                LevelDetails = ExpenseReportDetail.Description

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ExpenseReportDocument).Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts).Description

                    LevelDetailsHeader = Level

                    Try

                        ExpenseReportDocument = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ExpenseReportDocument).SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If ExpenseReportDocument IsNot Nothing Then

                            ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, ExpenseReportDocument.InvoiceNumber)

                            If ExpenseReport IsNot Nothing Then

                                LevelDetails = ExpenseReport.Description

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DataContext.EmployeeDocuments.Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.Employee).Description

                    LevelDetailsHeader = Level

                    Try

                        EmployeeDocument = DataContext.EmployeeDocuments.SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If EmployeeDocument IsNot Nothing Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeDocument.EmployeeCode)

                            If Employee IsNot Nothing Then

                                LevelDetails = Employee.ToString

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DataContext.VendorDocuments.Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.Vendor).Description

                    LevelDetailsHeader = Level

                    Try

                        VendorDocument = DataContext.VendorDocuments.SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If VendorDocument IsNot Nothing Then

                            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorDocument.VendorCode)

                            If Vendor IsNot Nothing Then

                                LevelDetails = Vendor.Name

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ContractDocument).Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.Contract).Description

                    LevelDetailsHeader = Level

                    Try

                        LevelDetails = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ContractDocument).Include("Contract").SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID).Contract.Description

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DataContext.ContractReportDocuments.Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.ContractReport).Description

                    LevelDetailsHeader = Level

                    Try

                        ContractReportDocument = DataContext.ContractReportDocuments.SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If ContractReportDocument IsNot Nothing Then

                            ContractReport = AdvantageFramework.Database.Procedures.ContractReport.LoadByID(DbContext, ContractReportDocument.ContractReportID)

                            If ContractReport IsNot Nothing Then

                                LevelDetails = ContractReport.Description

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AccountReceivableDocument).Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice).Description

                    LevelDetailsHeader = Level

                    Try

                        LevelDetails = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AccountReceivableDocument).Include("AccountReceivable").SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID).AccountReceivable.Description

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument).Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.AgencyDesktop).Description

                    LevelDetailsHeader = Level

                    Try

                        AgencyDesktopDocument = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument).Include("DepartmentTeam").Include("Office").SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If AgencyDesktopDocument IsNot Nothing Then

                            If AgencyDesktopDocument.Office IsNot Nothing AndAlso AgencyDesktopDocument.DepartmentTeam IsNot Nothing Then

                                LevelDetailsHeader &= " - Office, Dept/Team"

                                LevelDetails = AgencyDesktopDocument.Office.Name & ", " & AgencyDesktopDocument.DepartmentTeam.Description

                            ElseIf AgencyDesktopDocument.Office IsNot Nothing AndAlso AgencyDesktopDocument.DepartmentTeam Is Nothing Then

                                LevelDetailsHeader &= " - Office"

                                LevelDetails = AgencyDesktopDocument.Office.Name

                            ElseIf AgencyDesktopDocument.Office Is Nothing AndAlso AgencyDesktopDocument.DepartmentTeam IsNot Nothing Then

                                LevelDetailsHeader &= " - Dept/Team"

                                LevelDetails = AgencyDesktopDocument.DepartmentTeam.Description

                            ElseIf AgencyDesktopDocument.Office Is Nothing AndAlso AgencyDesktopDocument.DepartmentTeam Is Nothing Then

                                LevelDetails = LevelDetailsHeader

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument).Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.ExecutiveDesktop).Description

                    LevelDetailsHeader = Level

                    Try

                        ExecutiveDesktopDocument = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument).Include("Office").SingleOrDefault(Function(Entity) Entity.DocumentID = Document.ID)

                        If ExecutiveDesktopDocument IsNot Nothing Then

                            If ExecutiveDesktopDocument.Office IsNot Nothing AndAlso DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).SingleOrDefault(Function(Entity) Entity.Code = ExecutiveDesktopDocument.EmployeeCode) IsNot Nothing Then

                                LevelDetailsHeader &= " - Office, Employee"

                                LevelDetails = ExecutiveDesktopDocument.Office.Name & ", " & DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).SingleOrDefault(Function(Entity) Entity.Code = ExecutiveDesktopDocument.EmployeeCode).ToString

                            ElseIf ExecutiveDesktopDocument.Office IsNot Nothing AndAlso DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).SingleOrDefault(Function(Entity) Entity.Code = ExecutiveDesktopDocument.EmployeeCode) Is Nothing Then

                                LevelDetailsHeader &= " - Office"

                                LevelDetails = ExecutiveDesktopDocument.Office.Name

                            ElseIf ExecutiveDesktopDocument.Office Is Nothing AndAlso DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).SingleOrDefault(Function(Entity) Entity.Code = ExecutiveDesktopDocument.EmployeeCode) IsNot Nothing Then

                                LevelDetailsHeader &= " - Employee"

                                LevelDetails = DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).SingleOrDefault(Function(Entity) Entity.Code = ExecutiveDesktopDocument.EmployeeCode).ToString

                            ElseIf ExecutiveDesktopDocument.Office Is Nothing AndAlso DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).SingleOrDefault(Function(Entity) Entity.Code = ExecutiveDesktopDocument.EmployeeCode) Is Nothing Then

                                LevelDetails = LevelDetailsHeader

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                ElseIf DbContext.GetQuery(Of AdvantageFramework.Database.Entities.VendorContractDocument).Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.VendorContract).Description

                    LevelDetailsHeader = Level

                ElseIf DbContext.GetQuery(Of AdvantageFramework.Database.Views.OrderDocument).Any(Function(Entity) Entity.DocumentID = Document.ID) Then

                    Level = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder).Description

                    LevelDetailsHeader = Level

                    Try

                        OrderDocument = AdvantageFramework.Database.Procedures.OrderDocument.LoadByDocumentID(DbContext, Document.ID)

                        If OrderDocument IsNot Nothing Then

                            Order = AdvantageFramework.Database.Procedures.Order.Load(DbContext).FirstOrDefault(Function(Entity) Entity.OrderNumber = OrderDocument.OrderNumber)

                            If Order IsNot Nothing Then

                                LevelDetails = Order.OrderDescription

                            End If

                        End If

                    Catch ex As Exception
                        LevelDetails = ""
                    End Try

                End If

                DocumentDownloadDetailModel = New Webvantage.ViewModels.Document.DocumentDownloadDetailModel

                DocumentDownloadDetailModel.Level = Level
                DocumentDownloadDetailModel.LevelDetailsHeader = LevelDetailsHeader
                DocumentDownloadDetailModel.LevelDetails = LevelDetails
                DocumentDownloadDetailModel.DocumentID = Document.ID
                DocumentDownloadDetailModel.FileName = Document.FileName
                DocumentDownloadDetailModel.MIMEType = Document.MIMEType
                DocumentDownloadDetailModel.Description = Document.Description
                DocumentDownloadDetailModel.Keywords = Document.Keywords

            End If

            CreateDocumentDetail = DocumentDownloadDetailModel

        End Function
        Private Function IsEmailValidEmployeeEmail(DbContext As AdvantageFramework.Database.DbContext, Email As String) As Boolean

            'objects
            Dim IsValid As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If String.IsNullOrWhiteSpace(Email) = False Then

                Employee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                            Where Entity.Email IsNot Nothing AndAlso
                                  Entity.Email.ToUpper = Email.ToUpper AndAlso
                                  Entity.TerminationDate Is Nothing
                            Select Entity).FirstOrDefault

                If Employee IsNot Nothing Then

                    'If Employee.TerminationDate.HasValue = False Then

                    IsValid = True

                    'End If

                End If

            End If

            IsEmailValidEmployeeEmail = IsValid

        End Function
        Private Function GetFinalLevelDescription(DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As String

            'objects
            Dim FinalLevelDescription As String = ""

            Try

                If DocumentLevelSetting IsNot Nothing Then

                    Select Case DocumentLevelSetting.DocumentLevel

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & " : " & DocumentLevelSetting.AccountPayableID

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AdNumber

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.AdNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Campaign

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.CampaignID

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Client

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.ClientCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.ClientCode & "," & DocumentLevelSetting.DivisionCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.ExpenseReportInvoiceNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Job

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.JobNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.JobComponent

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.JobNumber & "," & DocumentLevelSetting.JobComponentNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Office

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.OfficeCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.ClientCode & "," & DocumentLevelSetting.DivisionCode & "," & DocumentLevelSetting.ProductCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Employee

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.EmployeeCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Vendor

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.VendorCode

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.AccountReceivableInvoiceNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.OrderNumber

                        Case AdvantageFramework.Database.Entities.DocumentLevel.MediaTrafficDetail

                            FinalLevelDescription = DocumentLevelSetting.DocumentLevel.ToString & ":" & DocumentLevelSetting.MediaTrafficDetailID

                    End Select

                End If

            Catch ex As Exception
                FinalLevelDescription = ""
            Finally
                GetFinalLevelDescription = FinalLevelDescription
            End Try

        End Function
        Private Function UploadLink(DbContext As AdvantageFramework.Database.DbContext,
                                    UploadViewModel As AdvantageFramework.ViewModels.Document.UploadViewModel,
                                    User As AdvantageFramework.Security.Classes.User,
                                    ByRef Document As AdvantageFramework.Database.Entities.Document,
                                    ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Uploaded As Boolean = False

            Try

                Document = New AdvantageFramework.Database.Entities.Document

                Document.DbContext = DbContext
                Document.FileName = UploadViewModel.LinkName
                Document.FileSystemFileName = UploadViewModel.LinkURL
                Document.MIMEType = "URL"
                Document.Description = UploadViewModel.Description
                Document.Keywords = UploadViewModel.Keywords
                Document.UserCode = User.UserCode
                Document.FileSize = 0
                Document.UploadedDate = System.DateTime.Now
                Document.DocumentTypeID = CInt(UploadViewModel.DocumentTypeID)
                Document.IsPrivate = CInt(UploadViewModel.IsPrivate)

                Uploaded = AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document)

                If Uploaded = False Then

                    ErrorMessage = "Failed saving to the database. Please contact software support."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed saving to the database.  -->" & ex.Message & If(ex.InnerException IsNot Nothing, ex.InnerException.Message, String.Empty)
                Uploaded = False
            Finally
                UploadLink = Uploaded
            End Try

        End Function
        Private Function UploadDocument(DbContext As AdvantageFramework.Database.DbContext,
                                        Agency As AdvantageFramework.Database.Entities.Agency,
                                        UploadViewModel As AdvantageFramework.ViewModels.Document.UploadViewModel,
                                        UploadFile As HttpPostedFileBase,
                                        User As AdvantageFramework.Security.Classes.User,
                                        DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting,
                                        ByRef Document As AdvantageFramework.Database.Entities.Document,
                                        ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim FileName As String = String.Empty
            Dim FileSystemFile As String = String.Empty
            Dim FileSystemFileName As String = String.Empty
            Dim FileSize As Integer = 0
            Dim MimeType As String = String.Empty
            Dim FinalLevelDescription As String = String.Empty
            Dim FinalLevel As String = String.Empty
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim FileBytes() As Byte = Nothing
            Dim TotalBytesCopied As Integer = 0

            Try

                FileName = UploadFile.FileName
                MimeType = UploadFile.ContentType
                FileSize = UploadFile.ContentLength
                FinalLevelDescription = GetFinalLevelDescription(DocumentLevelSetting)
                FinalLevel = DocumentLevelSetting.DocumentLevel.ToString

                If User IsNot Nothing Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, User.EmployeeCode)

                End If

                UploadFile.InputStream.Position = 0
                FileBytes = New Byte(UploadFile.InputStream.Length - 1) {}

                Do While TotalBytesCopied < UploadFile.InputStream.Length

                    TotalBytesCopied += UploadFile.InputStream.Read(FileBytes, TotalBytesCopied, Convert.ToInt32(UploadFile.InputStream.Length) - TotalBytesCopied)

                Loop

                If AdvantageFramework.FileSystem.Add(Agency, UploadFile.FileName, UploadViewModel.Description, UploadViewModel.Keywords,
                                                     If(Employee IsNot Nothing, Employee.ToString, User.UserCode), FinalLevel, FinalLevelDescription,
                                                     AdvantageFramework.FileSystem.DocumentSource.DocumentUpload, FileSystemFile, FileBytes, FileSystemFileName) Then

                    Document = New AdvantageFramework.Database.Entities.Document

                    Document.DbContext = DbContext
                    Document.FileName = FileName
                    Document.FileSystemFileName = FileSystemFileName
                    Document.MIMEType = MimeType
                    Document.Description = UploadViewModel.Description
                    Document.Keywords = UploadViewModel.Keywords
                    Document.UploadedDate = System.DateTime.Now
                    Document.UserCode = User.UserCode
                    Document.FileSize = FileSize
                    Document.DocumentTypeID = CInt(UploadViewModel.DocumentTypeID)
                    Document.IsPrivate = CInt(UploadViewModel.IsPrivate)

                    Uploaded = AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document)

                    If Uploaded = False Then

                        ErrorMessage = "Failed saving to the database. Please contact software support."

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = "Failed saving to the database.  -->" & ex.Message & If(ex.InnerException IsNot Nothing, ex.InnerException.Message, String.Empty)
                Uploaded = False
            Finally
                UploadDocument = Uploaded
            End Try

        End Function
        Private Function AddLevelDocument(DbContext As AdvantageFramework.Database.DbContext,
                                          DataContext As AdvantageFramework.Database.DataContext,
                                          UploadViewModel As AdvantageFramework.ViewModels.Document.UploadViewModel,
                                          DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting,
                                          Document As AdvantageFramework.Database.Entities.Document) As Boolean

            'objects
            Dim Added As Boolean = False

            Select Case DocumentLevelSetting.DocumentLevel

                Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                    Added = AddLevelDocument_AccountPayableInvoice(DataContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.AdNumber

                    Added = AddLevelDocument_AdNumber(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Campaign

                    Added = AddLevelDocument_Campaign(DataContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Client

                    Added = AddLevelDocument_Client(DataContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                    Added = AddLevelDocument_Division(DataContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts

                    Added = AddLevelDocument_ExpenseReceipts(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Job

                    Added = AddLevelDocument_Job(DataContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.JobComponent

                    Added = AddLevelDocument_JobComponent(DataContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Office

                    Added = AddLevelDocument_Office(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                    Added = AddLevelDocument_Product(DataContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Employee

                    Added = AddLevelDocument_Employee(DataContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Vendor

                    Added = AddLevelDocument_Vendor(DataContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.Contract

                    Added = AddLevelDocument_Contract(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.ContractValueAdded

                    Added = AddLevelDocument_ContractValueAdded(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.ContractReport

                    Added = AddLevelDocument_ContractReport(DataContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                    Added = AddLevelDocument_AccountReceivableInvoice(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.VendorContract

                    Added = AddLevelDocument_VendorContract(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.AgencyDesktop

                    Added = AddLevelDocument_AgencyDesktop(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.ExecutiveDesktop

                    Added = AddLevelDocument_ExecutiveDesktop(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder

                    Added = AddLevelDocument_MediaOrder(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.MediaTrafficDetail

                    Added = AddLevelDocument_MediaTrafficDetail(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.JournalEntry

                    Added = AddLevelDocument_JournalEntry(DbContext, Document.ID, DocumentLevelSetting)

                Case AdvantageFramework.Database.Entities.DocumentLevel.MediaPlan

                    Added = AddLevelDocument_MediaPlan(DbContext, Document.ID, DocumentLevelSetting)

            End Select

            AddLevelDocument = Added

        End Function
        Private Sub CheckRepositoryConstraints(DbContext As AdvantageFramework.Database.DbContext, TotalBytes As Long, ByRef IsValid As Boolean, ByRef ErrorMessage As String)

            'objects
            Dim MaxFileSize As Long = 0
            Dim DocumentRepositoryLimit As Long = -1

            Try

                MaxFileSize = AdvantageFramework.FileSystem.GetDocumentRepositoryFileSizeLimit(DbContext)
                DocumentRepositoryLimit = AdvantageFramework.FileSystem.GetDocumentRepositoryLimit(DbContext)

                If (DocumentRepositoryLimit > 0) AndAlso
                        (AdvantageFramework.FileSystem.GetDocumentRepositorySize(DbContext) + TotalBytes > DocumentRepositoryLimit) Then

                    ErrorMessage = "The file size exceeds the space left in the repository. File will not be uploaded! Please contact an administrator."
                    IsValid = False

                ElseIf MaxFileSize = 0 Then

                    ErrorMessage = "*Upload file size is set to 0 MB. File will not be uploaded! Please contact an administrator."
                    IsValid = False

                ElseIf (MaxFileSize > 0) AndAlso (TotalBytes > MaxFileSize) Then

                    ErrorMessage = "The file size exceeds the max file size limit. File will not be uploaded! Please contact an administrator."
                    IsValid = False

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub PopulateUploadViewModel(UploadViewModel As AdvantageFramework.ViewModels.Document.UploadViewModel)

            'objects
            Dim ConnectionString As String = String.Empty
            Dim UserCode As String = String.Empty

            Try

                ConnectionString = AdvantageFramework.Security.Encryption.Decrypt(UploadViewModel.ConnectionString)
                UserCode = AdvantageFramework.Security.Encryption.Decrypt(UploadViewModel.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                        UploadViewModel.DocumentTypes = (From DocumentType In AdvantageFramework.Database.Procedures.DocumentType.Load(DataContext).ToList
                                                         Where DocumentType.IsInactive.GetValueOrDefault(False) = False
                                                         Select DocumentType).ToList

                        UploadViewModel.Labels = AdvantageFramework.Database.Procedures.Label.LoadActive(DataContext).ToList

                    End Using

                End Using

            Catch ex As Exception

            End Try

        End Sub

#Region " Document Level Functions"

#Region "  Vendor Contract "

        Private Function AddLevelDocument_VendorContract(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim VendorContractDocument As AdvantageFramework.Database.Entities.VendorContractDocument = Nothing

            Try

                VendorContractDocument = New AdvantageFramework.Database.Entities.VendorContractDocument

                VendorContractDocument.DocumentID = DocumentID
                VendorContractDocument.ContractID = DocumentLevelSetting.VendorContractID

                Added = AdvantageFramework.Database.Procedures.VendorContractDocument.Insert(DbContext, VendorContractDocument, "")

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_VendorContract = Added
            End Try

        End Function

#End Region

#Region "  Agency Desktop "

        Private Function AddLevelDocument_AgencyDesktop(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim AgencyDesktopDocument As AdvantageFramework.Database.Entities.AgencyDesktopDocument = Nothing

            Try

                AgencyDesktopDocument = New AdvantageFramework.Database.Entities.AgencyDesktopDocument

                AgencyDesktopDocument.DocumentID = DocumentID
                AgencyDesktopDocument.OfficeCode = DocumentLevelSetting.OfficeCode
                AgencyDesktopDocument.DepartmentTeamCode = DocumentLevelSetting.DepartmentCode

                Added = AdvantageFramework.Database.Procedures.AgencyDesktopDocument.Insert(DbContext, AgencyDesktopDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_AgencyDesktop = Added
            End Try

        End Function

#End Region

#Region "  Executive Desktop "

        Private Function AddLevelDocument_ExecutiveDesktop(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ExecutiveDesktopDocument As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument = Nothing

            Try

                ExecutiveDesktopDocument = New AdvantageFramework.Database.Entities.ExecutiveDesktopDocument

                ExecutiveDesktopDocument.DocumentID = DocumentID
                ExecutiveDesktopDocument.OfficeCode = DocumentLevelSetting.OfficeCode
                ExecutiveDesktopDocument.EmployeeCode = DocumentLevelSetting.EmployeeCode

                Added = AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.Insert(DbContext, ExecutiveDesktopDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_ExecutiveDesktop = Added
            End Try

        End Function

#End Region

#Region "  Account Payable Invoice "

        Private Function AddLevelDocument_AccountPayableInvoice(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim AccountPayableDocument As AdvantageFramework.Database.Entities.AccountPayableDocument = Nothing

            Try

                AccountPayableDocument = New AdvantageFramework.Database.Entities.AccountPayableDocument

                AccountPayableDocument.DocumentID = DocumentID
                AccountPayableDocument.AccountPayableID = DocumentLevelSetting.AccountPayableID

                Added = AdvantageFramework.Database.Procedures.AccountPayableDocument.Insert(DataContext, AccountPayableDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_AccountPayableInvoice = Added
            End Try

        End Function

#End Region

#Region "  Ad Number "

        Private Function AddLevelDocument_AdNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing

            Try

                Ad = AdvantageFramework.Database.Procedures.Ad.LoadByAdNumber(DbContext, DocumentLevelSetting.AdNumber)

                If Ad IsNot Nothing Then

                    Ad.DocumentID = DocumentID
                    Added = AdvantageFramework.Database.Procedures.Ad.Update(DbContext, Ad)

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_AdNumber = Added
            End Try

        End Function

#End Region

#Region "  Campaign "

        Private Function AddLevelDocument_Campaign(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim CampaignDocument As AdvantageFramework.Database.Entities.CampaignDocument = Nothing

            Try

                CampaignDocument = New AdvantageFramework.Database.Entities.CampaignDocument

                CampaignDocument.DocumentID = DocumentID
                CampaignDocument.CampaignID = DocumentLevelSetting.CampaignID

                Added = AdvantageFramework.Database.Procedures.CampaignDocument.Insert(DataContext, CampaignDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Campaign = Added
            End Try

        End Function

#End Region

#Region "  Client "

        Private Function AddLevelDocument_Client(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ClientDocument As AdvantageFramework.Database.Entities.ClientDocument = Nothing

            Try

                ClientDocument = New AdvantageFramework.Database.Entities.ClientDocument

                ClientDocument.DocumentID = DocumentID
                ClientDocument.ClientCode = DocumentLevelSetting.ClientCode

                Added = AdvantageFramework.Database.Procedures.ClientDocument.Insert(DataContext, ClientDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Client = Added
            End Try

        End Function

#End Region

#Region "  Division "

        Private Function AddLevelDocument_Division(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim DivisionDocument As AdvantageFramework.Database.Entities.DivisionDocument = Nothing

            Try

                DivisionDocument = New AdvantageFramework.Database.Entities.DivisionDocument

                DivisionDocument.DocumentID = DocumentID
                DivisionDocument.ClientCode = DocumentLevelSetting.ClientCode
                DivisionDocument.DivisionCode = DocumentLevelSetting.DivisionCode

                Added = AdvantageFramework.Database.Procedures.DivisionDocument.Insert(DataContext, DivisionDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Division = Added
            End Try

        End Function

#End Region

#Region "  Expense Receipts "

        Private Function AddLevelDocument_ExpenseReceipts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument = Nothing
            Dim ExpenseDetailDocument As AdvantageFramework.Database.Entities.ExpenseDetailDocument = Nothing

            Try

                ExpenseReportDocument = New AdvantageFramework.Database.Entities.ExpenseReportDocument

                ExpenseReportDocument.DocumentID = DocumentID
                ExpenseReportDocument.InvoiceNumber = DocumentLevelSetting.ExpenseReportInvoiceNumber

                Added = AdvantageFramework.Database.Procedures.ExpenseReportDocument.Insert(DbContext, ExpenseReportDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_ExpenseReceipts = Added
            End Try

        End Function

#End Region

#Region "  Job "

        Private Function AddLevelDocument_Job(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim JobDocument As AdvantageFramework.Database.Entities.JobDocument = Nothing

            Try

                JobDocument = New AdvantageFramework.Database.Entities.JobDocument

                JobDocument.DocumentID = DocumentID
                JobDocument.JobNumber = DocumentLevelSetting.JobNumber

                Added = AdvantageFramework.Database.Procedures.JobDocument.Insert(DataContext, JobDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Job = Added
            End Try

        End Function

#End Region

#Region "  Job Component "

        Private Function AddLevelDocument_JobComponent(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim JobComponentDocument As AdvantageFramework.Database.Entities.JobComponentDocument = Nothing

            Try

                JobComponentDocument = New AdvantageFramework.Database.Entities.JobComponentDocument

                JobComponentDocument.DocumentID = DocumentID
                JobComponentDocument.JobNumber = DocumentLevelSetting.JobNumber
                JobComponentDocument.JobComponentNumber = DocumentLevelSetting.JobComponentNumber

                Added = AdvantageFramework.Database.Procedures.JobComponentDocument.Insert(DataContext, JobComponentDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_JobComponent = Added
            End Try

        End Function

#End Region

#Region "  Office "

        Private Function AddLevelDocument_Office(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim OfficeDocument As AdvantageFramework.Database.Entities.OfficeDocument = Nothing

            Try

                OfficeDocument = New AdvantageFramework.Database.Entities.OfficeDocument

                OfficeDocument.DocumentID = DocumentID
                OfficeDocument.OfficeCode = DocumentLevelSetting.OfficeCode

                Added = AdvantageFramework.Database.Procedures.OfficeDocument.Insert(DbContext, OfficeDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Office = Added
            End Try

        End Function

#End Region

#Region "  Product "

        Private Function AddLevelDocument_Product(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ProductDocument As AdvantageFramework.Database.Entities.ProductDocument = Nothing

            Try

                ProductDocument = New AdvantageFramework.Database.Entities.ProductDocument

                ProductDocument.DocumentID = DocumentID
                ProductDocument.ClientCode = DocumentLevelSetting.ClientCode
                ProductDocument.DivisionCode = DocumentLevelSetting.DivisionCode
                ProductDocument.ProductCode = DocumentLevelSetting.ProductCode

                Added = AdvantageFramework.Database.Procedures.ProductDocument.Insert(DataContext, ProductDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Product = Added
            End Try

        End Function

#End Region

#Region "  Employee "

        Private Function AddLevelDocument_Employee(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim EmployeeDocument As AdvantageFramework.Database.Entities.EmployeeDocument = Nothing

            Try

                EmployeeDocument = New AdvantageFramework.Database.Entities.EmployeeDocument

                EmployeeDocument.DocumentID = DocumentID
                EmployeeDocument.EmployeeCode = DocumentLevelSetting.EmployeeCode

                Added = AdvantageFramework.Database.Procedures.EmployeeDocument.Insert(DataContext, EmployeeDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Employee = Added
            End Try

        End Function

#End Region

#Region "  Vendor "

        Private Function AddLevelDocument_Vendor(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim VendorDocument As AdvantageFramework.Database.Entities.VendorDocument = Nothing

            Try

                VendorDocument = New AdvantageFramework.Database.Entities.VendorDocument

                VendorDocument.DocumentID = DocumentID
                VendorDocument.VendorCode = DocumentLevelSetting.VendorCode

                Added = AdvantageFramework.Database.Procedures.VendorDocument.Insert(DataContext, VendorDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Vendor = Added
            End Try

        End Function

#End Region

#Region "  Contract "

        Private Function AddLevelDocument_Contract(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ContractDocument As AdvantageFramework.Database.Entities.ContractDocument = Nothing

            Try

                ContractDocument = New AdvantageFramework.Database.Entities.ContractDocument

                ContractDocument.DocumentID = DocumentID
                ContractDocument.ContractID = DocumentLevelSetting.ContractID

                Added = AdvantageFramework.Database.Procedures.ContractDocument.Insert(DbContext, ContractDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_Contract = Added
            End Try

        End Function

#End Region

#Region "  Contract Value Added "

        Private Function AddLevelDocument_ContractValueAdded(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing

            Try

                ContractValueAdded = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, DocumentLevelSetting.ValueAddedID)

                If ContractValueAdded IsNot Nothing Then

                    ContractValueAdded.DocumentID = DocumentID
                    Added = AdvantageFramework.Database.Procedures.ContractValueAdded.Update(DbContext, ContractValueAdded)

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_ContractValueAdded = Added
            End Try

        End Function

#End Region

#Region "  Contract Report "

        Private Function AddLevelDocument_ContractReport(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ContractReportDocument As AdvantageFramework.Database.Entities.ContractReportDocument = Nothing

            Try

                ContractReportDocument = New AdvantageFramework.Database.Entities.ContractReportDocument

                ContractReportDocument.DocumentID = DocumentID
                ContractReportDocument.ContractReportID = DocumentLevelSetting.ContractReportID

                Added = AdvantageFramework.Database.Procedures.ContractReportDocument.Insert(DataContext, ContractReportDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_ContractReport = Added
            End Try

        End Function

#End Region

#Region "  Account Receivable Invoice "

        Private Function AddLevelDocument_AccountReceivableInvoice(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim AccountReceivableDocument As AdvantageFramework.Database.Entities.AccountReceivableDocument = Nothing

            Try

                AccountReceivableDocument = New AdvantageFramework.Database.Entities.AccountReceivableDocument

                AccountReceivableDocument.DocumentID = DocumentID
                AccountReceivableDocument.InvoiceNumber = DocumentLevelSetting.AccountReceivableInvoiceNumber
                AccountReceivableDocument.SequenceNumber = DocumentLevelSetting.AccountReceivableSequenceNumber
                AccountReceivableDocument.Type = DocumentLevelSetting.AccountReceivableType

                Added = AdvantageFramework.Database.Procedures.AccountReceivableDocument.Insert(DbContext, AccountReceivableDocument)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_AccountReceivableInvoice = Added
            End Try

        End Function

#End Region

#Region "  Media Order "

        Private Function AddLevelDocument_MediaOrder(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MagazineDocument As AdvantageFramework.Database.Entities.MagazineDocument = Nothing
            Dim NewspaperDocument As AdvantageFramework.Database.Entities.NewspaperDocument = Nothing
            Dim InternetDocument As AdvantageFramework.Database.Entities.InternetDocument = Nothing
            Dim OutOfHomeDocument As AdvantageFramework.Database.Entities.OutOfHomeDocument = Nothing
            Dim RadioDocument As AdvantageFramework.Database.Entities.RadioDocument = Nothing
            Dim TVDocument As AdvantageFramework.Database.Entities.TVDocument = Nothing

            Try

                If DocumentLevelSetting.MediaType = "M" Then

                    MagazineDocument = New AdvantageFramework.Database.Entities.MagazineDocument

                    MagazineDocument.DocumentID = DocumentID
                    MagazineDocument.OrderNumber = DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.MagazineDocument.Insert(DbContext, MagazineDocument)

                ElseIf DocumentLevelSetting.MediaType = "N" Then

                    NewspaperDocument = New AdvantageFramework.Database.Entities.NewspaperDocument

                    NewspaperDocument.DocumentID = DocumentID
                    NewspaperDocument.OrderNumber = DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.NewspaperDocument.Insert(DbContext, NewspaperDocument)

                ElseIf DocumentLevelSetting.MediaType = "I" Then

                    InternetDocument = New AdvantageFramework.Database.Entities.InternetDocument

                    InternetDocument.DocumentID = DocumentID
                    InternetDocument.OrderNumber = DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.InternetDocument.Insert(DbContext, InternetDocument)

                ElseIf DocumentLevelSetting.MediaType = "O" Then

                    OutOfHomeDocument = New AdvantageFramework.Database.Entities.OutOfHomeDocument

                    OutOfHomeDocument.DocumentID = DocumentID
                    OutOfHomeDocument.OrderNumber = DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.OutOfHomeDocument.Insert(DbContext, OutOfHomeDocument)

                ElseIf DocumentLevelSetting.MediaType = "R" Then

                    RadioDocument = New AdvantageFramework.Database.Entities.RadioDocument

                    RadioDocument.DocumentID = DocumentID
                    RadioDocument.OrderNumber = DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.RadioDocument.Insert(DbContext, RadioDocument)

                ElseIf DocumentLevelSetting.MediaType = "T" Then

                    TVDocument = New AdvantageFramework.Database.Entities.TVDocument

                    TVDocument.DocumentID = DocumentID
                    TVDocument.OrderNumber = DocumentLevelSetting.OrderNumber

                    Added = AdvantageFramework.Database.Procedures.TVDocument.Insert(DbContext, TVDocument)

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_MediaOrder = Added
            End Try

        End Function

#End Region

#Region "  Media Traffic Detail "

        Private Function AddLevelDocument_MediaTrafficDetail(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MediaTrafficDetailDocument As AdvantageFramework.Database.Entities.MediaTrafficDetailDocument = Nothing
            Dim ErrorText As String = Nothing

            Try

                If IsNumeric(DocumentLevelSetting.MediaTrafficDetailID) Then

                    MediaTrafficDetailDocument = New AdvantageFramework.Database.Entities.MediaTrafficDetailDocument

                    MediaTrafficDetailDocument.DocumentID = DocumentID
                    MediaTrafficDetailDocument.MediaTrafficDetailID = DocumentLevelSetting.MediaTrafficDetailID

                    If AdvantageFramework.Database.Procedures.MediaTrafficDetailDocument.Insert(DbContext, MediaTrafficDetailDocument, ErrorText) Then

                        Added = True

                    Else

                        Throw New Exception(ErrorText)

                    End If

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_MediaTrafficDetail = Added
            End Try

        End Function

#End Region

#Region "  Journal Entry "

        Private Function AddLevelDocument_JournalEntry(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim GeneralLedgerDocument As AdvantageFramework.Database.Entities.GeneralLedgerDocument = Nothing

            Try

                GeneralLedgerDocument = New AdvantageFramework.Database.Entities.GeneralLedgerDocument

                GeneralLedgerDocument.DocumentID = DocumentID
                GeneralLedgerDocument.GLTransaction = DocumentLevelSetting.GLTransaction

                Added = AdvantageFramework.Database.Procedures.GeneralLedgerDocument.Insert(DbContext, GeneralLedgerDocument, String.Empty)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_JournalEntry = Added
            End Try

        End Function

#End Region

#Region "  Media Plan "

        Private Function AddLevelDocument_MediaPlan(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MediaPlanDocument As AdvantageFramework.Database.Entities.MediaPlanDocument = Nothing

            Try

                MediaPlanDocument = New AdvantageFramework.Database.Entities.MediaPlanDocument

                MediaPlanDocument.DocumentID = DocumentID
                MediaPlanDocument.MediaPlanID = DocumentLevelSetting.MediaPlanID

                Added = AdvantageFramework.Database.Procedures.MediaPlanDocument.Insert(DbContext, MediaPlanDocument, String.Empty)

            Catch ex As Exception
                Added = False
            Finally
                AddLevelDocument_MediaPlan = Added
            End Try

        End Function

#End Region

#End Region

#End Region

        <AcceptVerbs("POST")>
        Public Function DownloadImageSourceAsBase64(ByVal DocumentID As Integer) As JsonResult

            Dim ReturnObject As Object = Nothing
            Dim Filename As String = String.Empty
            Dim ImageString As String = String.Empty

            If DocumentID > 0 Then

                Try

                    Dim Document As New Document(Me.SecuritySession.ConnectionString)

                    If Document.LoadByPrimaryKey(DocumentID) = True Then

                        Dim DocumentRepository As New DocumentRepository(Me.SecuritySession.ConnectionString)
                        Dim Base64String As String = String.Empty
                        Dim Type As String = String.Empty

                        If Document.s_MIME_TYPE.ToLower.Contains("image") Then

                            Filename = Document.FILENAME
                            Type = Document.s_MIME_TYPE

                            Dim FileBytes() As Byte = DocumentRepository.GetDocument(DocumentID)

                            Base64String = Convert.ToBase64String(FileBytes)
                            ImageString = String.Format("data:image/{0};base64,{1}", Type, Base64String)

                        End If

                    End If

                Catch ex As Exception
                    Filename = String.Empty
                    ImageString = String.Empty
                End Try

            End If

            ReturnObject = New With {.Filename = Filename,
                                     .ImageString = ImageString}

            Return ReturnObject

        End Function
        Public Function DownloadAllDocuments(QueryString As String) As System.Web.Mvc.ActionResult

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileStreamResult As System.Web.Mvc.FileStreamResult = Nothing
            Dim DatabaseName As String = String.Empty
            Dim FileName As String = String.Empty
            Dim Email As String = String.Empty
            Dim DownloadedDate As Date = Date.MinValue
            Dim DocumentIDsString As String = String.Empty
            Dim DocumentIDs() As Integer = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim ByteFile() As Byte = Nothing
            Dim FileExists As Boolean = False

            If DecrpytQueryString(QueryString, DatabaseName, DownloadedDate, Email, FileName, DocumentIDsString) Then

                If DateDiff(DateInterval.Day, DownloadedDate, Now) < 1 Then

                    SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                    GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                    SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing Then

                            If IsEmailValidEmployeeEmail(DbContext, Email) Then

                                AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                                ZipFile = New Ionic.Zip.ZipFile

                                DocumentIDs = ParseDocumentIDsString(DocumentIDsString)

                                For Each DocumentID In DocumentIDs

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                                    If Document IsNot Nothing Then

                                        If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile, FileExists) Then

                                            ZipFile.AddEntry(Document.FileName, ByteFile)

                                        End If

                                    End If

                                Next

                                AdvantageFramework.Security.Impersonate.EndImpersonation()

                                MemoryStream = New System.IO.MemoryStream

                                ZipFile.Save(MemoryStream)

                                MemoryStream.Position = 0

                                FileStreamResult = Me.File(MemoryStream, "application/zip", "AllDocuments.zip")

                            End If

                        End If

                    End Using

                End If

            End If

            DownloadAllDocuments = FileStreamResult

        End Function
        Public Function DownloadDocument(EncryptedID As String) As System.Web.Mvc.ActionResult

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim DatabaseName As String = String.Empty
            Dim FileName As String = String.Empty
            Dim DocumentIDString As String = String.Empty
            Dim ByteFile() As Byte = Nothing
            Dim FileExists As Boolean = False
            Dim DocumentID As Integer = 0
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim DownloadedDate As Date = Date.MinValue
            Dim Email As String = String.Empty

            If DecrpytEncryptedID(EncryptedID, DatabaseName, FileName, DownloadedDate, Email, DocumentIDString) Then

                Try

                    DocumentID = Convert.ToInt32(DocumentIDString)

                Catch ex As Exception
                    DocumentID = 0
                End Try

                If DocumentID > 0 Then

                    If DateDiff(DateInterval.Day, DownloadedDate, Now) < 1 Then

                        SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                        GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                        SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                        Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                            If Agency IsNot Nothing AndAlso Document IsNot Nothing Then

                                If IsEmailValidEmployeeEmail(DbContext, Email) Then

                                    If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile, FileExists) Then

                                        FileContentResult = Me.File(ByteFile, Document.MIMEType)

                                        FileContentResult.FileDownloadName = Document.FileName

                                    End If

                                End If

                            End If

                        End Using

                    End If

                End If

            End If

            DownloadDocument = FileContentResult

        End Function
        <MvcCodeRouting.CustomRoute(“~/Document/DocumentDownload”)>
        Public Function DocumentDownload() As System.Web.Mvc.ActionResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = String.Empty
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = String.Empty
            Dim FileName As String = String.Empty
            Dim Email As String = String.Empty
            Dim DownloadedDate As Date = Date.MinValue
            Dim DocumentIDsString As String = String.Empty
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim DocumentDownloadModel As Webvantage.ViewModels.Document.DocumentDownloadModel = Nothing
            Dim DocumentIDs() As Integer = Nothing
            Dim DocumentDownloadDetailModel As Webvantage.ViewModels.Document.DocumentDownloadDetailModel = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

            Try

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "FileName"

                            FileName = VariableValues(1).ToString

                        Case "Date"

                            Try

                                DownloadedDate = CDate(VariableValues(1).ToString)

                            Catch ex As Exception
                                DownloadedDate = Now.AddHours(-1)
                            End Try

                        Case "Email"

                            Email = VariableValues(1).ToString

                        Case "DocumentIDs"

                            DocumentIDsString = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                DecodedFailed = True
            End Try

            DocumentDownloadModel = New Webvantage.ViewModels.Document.DocumentDownloadModel
            DocumentDownloadModel.IsValid = True
            DocumentDownloadModel.DocumentHasExpired = False
            DocumentDownloadModel.InvalidEmployee = False

            If DecodedFailed = False Then

                FileName = FileName.Replace("<>", "&")

                If DateDiff(DateInterval.Day, DownloadedDate, Now) < 1 Then

                    SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                    GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                    SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                    If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                            String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                    If IsEmailValidEmployeeEmail(DbContext, Email) Then

                                        DataContext.Connection.Open()
                                        DbContext.Database.Connection.Open()

                                        DocumentDownloadModel.QueryString = "|" & Url(1).ToString & "|"
                                        DocumentDownloadModel.FileName = FileName

                                        DocumentIDs = ParseDocumentIDsString(DocumentIDsString)

                                        For Each DocumentID In DocumentIDs

                                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                                            If Document IsNot Nothing Then

                                                DocumentDownloadDetailModel = CreateDocumentDetail(DbContext, DataContext, Document)

                                                If DocumentDownloadDetailModel IsNot Nothing Then

                                                    DocumentDownloadDetailModel.EncryptedID = AdvantageFramework.Security.Encryption.Encrypt("Database=" & DatabaseName &
                                                                                                                                             "&FileName=" & Document.FileName &
                                                                                                                                             "&DocumentID=" & Document.ID &
                                                                                                                                             "&Date=" & DownloadedDate.ToString("MM/dd/yyyy hh:mm:ss tt") &
                                                                                                                                             "&Email=" & Email)

                                                    DocumentDownloadModel.DocumentDownloadDetailModels.Add(DocumentDownloadDetailModel)

                                                End If

                                            End If

                                        Next

                                        DbContext.Database.Connection.Close()
                                        DataContext.Connection.Close()

                                    Else

                                        DocumentDownloadModel.IsValid = False
                                        DocumentDownloadModel.InvalidEmployee = True

                                    End If

                                End Using

                            End Using

                        Catch ex As Exception
                            DocumentDownloadModel.IsValid = False
                        End Try

                    Else

                        DocumentDownloadModel.IsValid = False

                    End If

                Else

                    DocumentDownloadModel.IsValid = False
                    DocumentDownloadModel.DocumentHasExpired = True

                End If

            Else

                DocumentDownloadModel.IsValid = False

            End If

            DocumentDownload = View(DocumentDownloadModel)

        End Function
        <MvcCodeRouting.CustomRoute(“~/Document/ReportDownload”)>
        Public Function ReportDownload() As System.Web.Mvc.FileContentResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Downloaded As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = String.Empty
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim File As String = String.Empty
            Dim ByteFile() As Byte = Nothing
            Dim FileExists As Boolean = False
            Dim DownloadedDate As Date = Date.MinValue
            Dim MIMEType As String = String.Empty
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader = Nothing
            Dim DatabaseName As String = String.Empty
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Try

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "File"

                            File = VariableValues(1).ToString

                        Case "Date"

                            DownloadedDate = CDate(VariableValues(1).ToString)

                        Case "MIMEType"

                            MIMEType = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                DecodedFailed = True
                File = String.Empty
                DownloadedDate = Date.MinValue
            End Try

            If DecodedFailed = False Then

                If String.IsNullOrWhiteSpace(File) Then

                    DecodedFailed = True

                End If

            End If

            If DecodedFailed = False Then

                If String.IsNullOrWhiteSpace(MIMEType) Then

                    DecodedFailed = True

                End If

            End If

            If DecodedFailed = False Then

                If DownloadedDate = Date.MinValue Then

                    DecodedFailed = True

                End If

            End If

            If DecodedFailed = False Then

                If String.IsNullOrWhiteSpace(DatabaseName) Then

                    DecodedFailed = True

                End If

            End If

            If DecodedFailed = False Then

                File = File.Replace("<>", "&")

                If DateDiff(DateInterval.Day, DownloadedDate, Now) < 3 Then

                    SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                    GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                    SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                    If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                            String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                If Agency IsNot Nothing Then

                                    Try

                                        AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                                        Try

                                            FileStream = New System.IO.FileStream(File, IO.FileMode.OpenOrCreate)
                                            BinaryReader = New System.IO.BinaryReader(FileStream)
                                            ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(File).Length)

                                            FileStream.Close()
                                            BinaryReader.Close()

                                            Downloaded = True

                                        Catch ex As Exception
                                            Downloaded = False
                                        End Try

                                        If Downloaded AndAlso Agency.IsASP = 1 AndAlso AdvantageFramework.Agency.LoadSendFilesAsOneTimeLink(DataContext) Then

                                            Try

                                                System.IO.File.Delete(File)

                                            Catch ex As Exception
                                                AdvantageFramework.Security.AddWebvantageEventLog("Document delete after download " & System.Environment.NewLine & System.Environment.NewLine & AdvantageFramework.StringUtilities.FullErrorMessage(ex))
                                            End Try

                                        End If

                                        AdvantageFramework.Security.Impersonate.EndImpersonation()

                                    Catch ex As Exception
                                        Downloaded = False
                                    End Try

                                End If

                            End Using

                        End Using

                    End If

                End If

            End If

            If Downloaded Then

                FileContentResult = Me.File(ByteFile, MIMEType)

                FileContentResult.FileDownloadName = AdvantageFramework.FileSystem.GetFileName(File)

            End If

            ReportDownload = FileContentResult

        End Function
        <MvcCodeRouting.CustomRoute(“~/Document/Upload”)>
        Public Function Upload() As System.Web.Mvc.ActionResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = String.Empty
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = String.Empty
            Dim UserCode As String = String.Empty
            Dim ConnectionString As String = String.Empty
            Dim DocumentLevelSettingASPString As String = String.Empty
            Dim ExpirationDate As Date = Date.MinValue
            Dim UploadViewModel As AdvantageFramework.ViewModels.Document.UploadViewModel = Nothing
            Dim PropertyDescriptorCollection As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
            Dim DocumentLevel As Nullable(Of AdvantageFramework.Database.Entities.DocumentLevel) = Nothing
            Dim DocumentSubLevel As Nullable(Of AdvantageFramework.Database.Entities.DocumentSubLevel) = Nothing
            Dim FoundDocumentLevels As Boolean = False
            Dim EnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
            Dim DefaultDocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType = Nothing
            Dim MaxFileSize As Long = 0

            Try

                PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Classes.DocumentLevelSetting))

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Date"

                            Try

                                ExpirationDate = CDate(VariableValues(1).ToString)

                            Catch ex As Exception
                                ExpirationDate = Now.AddHours(-1)
                            End Try

                        Case "DatabaseName"

                            DatabaseName = VariableValues(1).ToString

                        Case "UserCode"

                            UserCode = VariableValues(1).ToString

                        Case "DocumentLevel"

                            DocumentLevel = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.DocumentLevel), VariableValues(1).ToString)

                        Case "DocumentSubLevel"

                            DocumentSubLevel = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.DocumentSubLevel), VariableValues(1).ToString)

                    End Select

                Next

                If String.IsNullOrWhiteSpace(DatabaseName) = False Then

                    ConnectionString = LoadConnectionString(DatabaseName)

                End If

                If DocumentLevel.HasValue AndAlso DocumentSubLevel.HasValue AndAlso String.IsNullOrWhiteSpace(ConnectionString) = False Then

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(DocumentLevel.Value, DocumentSubLevel.Value)

                    For Each QueryItem In QueryItems

                        VariableValues = QueryItem.Split("=")

                        Select Case VariableValues(0)

                            Case "Date", "DatabaseName", "UserCode", "DocumentLevel", "DocumentSubLevel"

                                'do nothing

                            Case Else

                                PropertyDescriptor = PropertyDescriptorCollection.Find(VariableValues(0), False)

                                If PropertyDescriptor IsNot Nothing Then

                                    If String.IsNullOrWhiteSpace(VariableValues(1).ToString) Then

                                        PropertyDescriptor.SetValue(DocumentLevelSetting, Nothing)

                                    Else

                                        If PropertyDescriptor.Name = AdvantageFramework.Database.Classes.DocumentLevelSetting.Properties.AccountReceivableInvoiceNumber.ToString Then

                                            If IsNumeric(VariableValues(1)) Then

                                                PropertyDescriptor.SetValue(DocumentLevelSetting, CInt(VariableValues(1)))

                                            Else

                                                PropertyDescriptor.SetValue(DocumentLevelSetting, Nothing)

                                            End If

                                        ElseIf PropertyDescriptor.Name = AdvantageFramework.Database.Classes.DocumentLevelSetting.Properties.AccountReceivableSequenceNumber.ToString Then

                                            If IsNumeric(VariableValues(1)) Then

                                                PropertyDescriptor.SetValue(DocumentLevelSetting, CShort(VariableValues(1)))

                                            Else

                                                PropertyDescriptor.SetValue(DocumentLevelSetting, Nothing)

                                            End If

                                        Else

                                            PropertyDescriptor.SetValue(DocumentLevelSetting, VariableValues(1).ToString)

                                        End If

                                    End If

                                End If

                        End Select

                    Next

                End If

            Catch ex As Exception
                DecodedFailed = True
            End Try

            UploadViewModel = New AdvantageFramework.ViewModels.Document.UploadViewModel
            UploadViewModel.IsValid = True
            UploadViewModel.DocumentHasExpired = False
            UploadViewModel.UploadedSucessfully = False

            If DecodedFailed = False Then

                If DateDiff(DateInterval.Day, ExpirationDate, Now) < 1 Then

                    If String.IsNullOrWhiteSpace(ConnectionString) = False AndAlso String.IsNullOrWhiteSpace(UserCode) = False AndAlso
                            DocumentLevel.HasValue AndAlso DocumentSubLevel.HasValue AndAlso DocumentLevelSetting IsNot Nothing Then

                        If DocumentLevelSetting.ValidateDocumentLevelProperties Then

                            UploadViewModel.ConnectionString = AdvantageFramework.Security.Encryption.Encrypt(ConnectionString)
                            UploadViewModel.UserCode = AdvantageFramework.Security.Encryption.Encrypt(UserCode)
                            UploadViewModel.FileOrLink = "File"
                            UploadViewModel.DocumentLevelSettingASPString = AdvantageFramework.Security.Encryption.Encrypt(DocumentLevelSetting.LoadDocumentLevelSettingASPString)

                            EnumObject = AdvantageFramework.EnumUtilities.LoadEnumObject(DocumentLevel)

                            If EnumObject IsNot Nothing Then

                                UploadViewModel.DocumentLevel = "Document Level - " & EnumObject.Description

                            Else

                                UploadViewModel.DocumentLevel = "Document Level - " & DocumentLevel.Value.ToString

                            End If

                            If DocumentSubLevel <> AdvantageFramework.Database.Entities.DocumentSubLevel.Default Then

                                UploadViewModel.DocumentSubLevel = "Document Sub Level - " & AdvantageFramework.StringUtilities.GetNameAsWords(DocumentLevel.Value.ToString)

                            End If

                            Try

                                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                                    Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                                        MaxFileSize = AdvantageFramework.FileSystem.GetDocumentRepositoryFileSizeLimit(DbContext)

                                        If MaxFileSize >= 0 Then

                                            UploadViewModel.MaxFileSize = MaxFileSize
                                            UploadViewModel.FileSizeMessage = "Files larger than " & Math.Round((MaxFileSize / 1024) / 1024, 0).ToString & "MB will automatically be excluded."

                                        Else

                                            UploadViewModel.FileSizeMessage = ""

                                        End If

                                        UploadViewModel.FileLinkMessage = "Copy and Paste a URL here to create a link."

                                        DefaultDocumentType = (From DocumentType In AdvantageFramework.Database.Procedures.DocumentType.Load(DataContext).ToList
                                                               Where DocumentType.IsInactive.GetValueOrDefault(False) = False AndAlso
                                                                     DocumentType.IsDefault = True
                                                               Select DocumentType).FirstOrDefault

                                        If DefaultDocumentType IsNot Nothing Then

                                            UploadViewModel.DocumentTypeID = DefaultDocumentType.ID

                                        Else

                                            UploadViewModel.DocumentTypeID = 1

                                        End If

                                        UploadViewModel.DocumentLevelProperties = DocumentLevelSetting.LoadDocumentLevelSettingASPDescriptionString(DbContext)

                                    End Using

                                End Using

                                PopulateUploadViewModel(UploadViewModel)

                            Catch ex As Exception
                                UploadViewModel.IsValid = False
                            End Try

                        Else

                            UploadViewModel.IsValid = False

                        End If

                    Else

                        UploadViewModel.IsValid = False

                    End If

                Else

                    UploadViewModel.IsValid = False
                    UploadViewModel.DocumentHasExpired = True

                End If

            Else

                UploadViewModel.IsValid = False

            End If

            Upload = View(UploadViewModel)

        End Function
        <System.Web.Mvc.HttpPost(),
        System.Web.Mvc.AllowAnonymous(),
        System.Web.Mvc.ValidateAntiForgeryToken()>
        Public Function Upload(UploadViewModel As AdvantageFramework.ViewModels.Document.UploadViewModel, UploadFiles As IEnumerable(Of HttpPostedFileBase)) As System.Web.Mvc.ActionResult

            'objects
            Dim DocumentUploadType As AdvantageFramework.Database.Entities.DocumentUploadType = AdvantageFramework.Database.Entities.DocumentUploadType.Link
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim ConnectionString As String = String.Empty
            Dim UserCode As String = String.Empty
            Dim TotalBytes As Long = 0
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim User As AdvantageFramework.Security.Classes.User = Nothing
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
            Dim DocumentLevel As Nullable(Of AdvantageFramework.Database.Entities.DocumentLevel) = Nothing
            Dim DocumentSubLevel As Nullable(Of AdvantageFramework.Database.Entities.DocumentSubLevel) = Nothing
            Dim DecodedQueryString As String = String.Empty
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim PropertyDescriptorCollection As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If ModelState.IsValid Then

                If (UploadViewModel.FileOrLink = "File" AndAlso UploadFiles IsNot Nothing AndAlso UploadFiles.Count > 0) OrElse UploadViewModel.FileOrLink <> "File" Then

                    PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Classes.DocumentLevelSetting))

                    DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(UploadViewModel.DocumentLevelSettingASPString)

                    QueryItems = DecodedQueryString.Split("&")

                    For Each QueryItem In QueryItems

                        VariableValues = QueryItem.Split("=")

                        Select Case VariableValues(0)

                            Case "DocumentLevel"

                                DocumentLevel = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.DocumentLevel), VariableValues(1).ToString)

                            Case "DocumentSubLevel"

                                DocumentSubLevel = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.DocumentSubLevel), VariableValues(1).ToString)

                        End Select

                    Next

                    If DocumentLevel.HasValue AndAlso DocumentSubLevel.HasValue Then

                        DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(DocumentLevel.Value, DocumentSubLevel.Value)

                        For Each QueryItem In QueryItems

                            VariableValues = QueryItem.Split("=")

                            Select Case VariableValues(0)

                                Case "Date", "ServerName", "DatabaseName", "UserName",
                                     "Password", "UserCode", "DocumentLevel", "DocumentSubLevel"

                                    'do nothing

                                Case Else

                                    PropertyDescriptor = PropertyDescriptorCollection.Find(VariableValues(0), False)

                                    If PropertyDescriptor IsNot Nothing Then

                                        If String.IsNullOrWhiteSpace(VariableValues(1).ToString) Then

                                            PropertyDescriptor.SetValue(DocumentLevelSetting, Nothing)

                                        Else

                                            If PropertyDescriptor.Name = AdvantageFramework.Database.Classes.DocumentLevelSetting.Properties.AccountReceivableInvoiceNumber.ToString Then

                                                If IsNumeric(VariableValues(1)) Then

                                                    PropertyDescriptor.SetValue(DocumentLevelSetting, CInt(VariableValues(1)))

                                                Else

                                                    PropertyDescriptor.SetValue(DocumentLevelSetting, Nothing)

                                                End If

                                            ElseIf PropertyDescriptor.Name = AdvantageFramework.Database.Classes.DocumentLevelSetting.Properties.AccountReceivableSequenceNumber.ToString Then

                                                If IsNumeric(VariableValues(1)) Then

                                                    PropertyDescriptor.SetValue(DocumentLevelSetting, CShort(VariableValues(1)))

                                                Else

                                                    PropertyDescriptor.SetValue(DocumentLevelSetting, Nothing)

                                                End If

                                            Else

                                                PropertyDescriptor.SetValue(DocumentLevelSetting, VariableValues(1).ToString)

                                            End If

                                        End If

                                    End If

                            End Select

                        Next

                    End If

                    If DocumentLevelSetting IsNot Nothing Then

                        ConnectionString = AdvantageFramework.Security.Encryption.Decrypt(UploadViewModel.ConnectionString)
                        UserCode = AdvantageFramework.Security.Encryption.Decrypt(UploadViewModel.UserCode)

                        If AdvantageFramework.Database.TestConnectionString(ConnectionString) Then

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                                User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode))

                            End Using

                            If User IsNot Nothing Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                                    Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                                        If UploadViewModel.FileOrLink = "Link" Then

                                            DocumentUploadType = AdvantageFramework.Database.Entities.DocumentUploadType.Link

                                        Else

                                            DocumentUploadType = AdvantageFramework.Database.Entities.DocumentUploadType.Document

                                            For Each UploadFile In UploadFiles

                                                TotalBytes += UploadFile.ContentLength

                                            Next

                                            CheckRepositoryConstraints(DbContext, TotalBytes, IsValid, ErrorMessage)

                                        End If

                                        If IsValid Then

                                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                            If Agency IsNot Nothing Then

                                                Select Case DocumentUploadType

                                                    Case AdvantageFramework.Database.Entities.DocumentUploadType.Document

                                                        For Each UploadFile In UploadFiles

                                                            If UploadDocument(DbContext, Agency, UploadViewModel, UploadFile, User, DocumentLevelSetting, Document, ErrorMessage) = False Then

                                                                IsValid = False
                                                                Exit For

                                                            Else

                                                                If AddLevelDocument(DbContext, DataContext, UploadViewModel, DocumentLevelSetting, Document) = False Then

                                                                    ErrorMessage = "Failed adding document to document level. Please contact software support."
                                                                    IsValid = False
                                                                    Exit For

                                                                End If

                                                            End If

                                                        Next

                                                    Case AdvantageFramework.Database.Entities.DocumentUploadType.Link

                                                        IsValid = UploadLink(DbContext, UploadViewModel, User, Document, ErrorMessage)

                                                        If IsValid Then

                                                            If AddLevelDocument(DbContext, DataContext, UploadViewModel, DocumentLevelSetting, Document) = False Then

                                                                ErrorMessage = "Failed adding document to document level. Please contact software support."
                                                                IsValid = False

                                                            End If

                                                        End If

                                                End Select

                                            Else

                                                IsValid = False
                                                ErrorMessage = "Cannot find agency settings. Please contact software support."

                                            End If

                                        End If

                                    End Using

                                End Using

                            Else

                                IsValid = False
                                ErrorMessage = "Invalid usercode on link."

                            End If

                        Else

                            IsValid = False
                            ErrorMessage = "Invalid connection string on link."

                        End If

                    Else

                        IsValid = False
                        ErrorMessage = "Invalid document level settings on link."

                    End If

                Else

                    IsValid = False
                    ErrorMessage = "Please select at least one file to upload."

                End If

                If IsValid Then

                    UploadViewModel.UploadedSucessfully = True

                Else

                    ModelState.AddModelError("", ErrorMessage)

                End If

            End If

            PopulateUploadViewModel(UploadViewModel)

            Upload = View(UploadViewModel)

        End Function
        <MvcCodeRouting.CustomRoute(“~/Document/UploadAvail”)>
        Public Function UploadAvail() As System.Web.Mvc.ActionResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = String.Empty
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = String.Empty
            Dim UserCode As String = String.Empty
            Dim ConnectionString As String = String.Empty
            Dim ExpirationDate As Date = Date.MinValue
            Dim UploadAvailViewModel As AdvantageFramework.ViewModels.Document.UploadAvailViewModel = Nothing

            Try

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Date"

                            Try

                                ExpirationDate = CDate(VariableValues(1).ToString)

                            Catch ex As Exception
                                ExpirationDate = Now.AddHours(-1)
                            End Try

                        Case "DatabaseName"

                            DatabaseName = VariableValues(1).ToString

                        Case "UserCode"

                            UserCode = VariableValues(1).ToString

                    End Select

                Next

                If String.IsNullOrWhiteSpace(DatabaseName) = False Then

                    ConnectionString = LoadConnectionString(DatabaseName)

                End If

            Catch ex As Exception
                DecodedFailed = True
            End Try

            UploadAvailViewModel = New AdvantageFramework.ViewModels.Document.UploadAvailViewModel
            UploadAvailViewModel.IsValid = True
            UploadAvailViewModel.DocumentHasExpired = False
            UploadAvailViewModel.UploadedSucessfully = False

            If DecodedFailed = False Then

                If DateDiff(DateInterval.Day, ExpirationDate, Now) < 1 Then

                    If String.IsNullOrWhiteSpace(ConnectionString) = False AndAlso String.IsNullOrWhiteSpace(UserCode) = False Then

                        UploadAvailViewModel.ConnectionString = AdvantageFramework.Security.Encryption.Encrypt(ConnectionString)
                        UploadAvailViewModel.UserCode = AdvantageFramework.Security.Encryption.Encrypt(UserCode)

                    Else

                        UploadAvailViewModel.IsValid = False

                    End If

                Else

                    UploadAvailViewModel.IsValid = False
                    UploadAvailViewModel.DocumentHasExpired = True

                End If

            Else

                UploadAvailViewModel.IsValid = False

            End If

            UploadAvail = View(UploadAvailViewModel)

        End Function
        <System.Web.Mvc.HttpPost(),
        System.Web.Mvc.AllowAnonymous(),
        System.Web.Mvc.ValidateAntiForgeryToken()>
        Public Function UploadAvail(UploadAvailViewModel As AdvantageFramework.ViewModels.Document.UploadAvailViewModel, UploadFiles As IEnumerable(Of HttpPostedFileBase)) As System.Web.Mvc.ActionResult

            'objects
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim ConnectionString As String = String.Empty
            Dim UserCode As String = String.Empty
            Dim FilePath As String = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim File As String = Nothing

            If ModelState.IsValid Then

                If UploadFiles.Count > 0 Then

                    ConnectionString = AdvantageFramework.Security.Encryption.Decrypt(UploadAvailViewModel.ConnectionString)
                    UserCode = AdvantageFramework.Security.Encryption.Decrypt(UploadAvailViewModel.UserCode)

                    If AdvantageFramework.Database.TestConnectionString(ConnectionString) Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                                If IsValid Then

                                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                    If Agency IsNot Nothing Then

                                        Try

                                            AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                                            FilePath = System.IO.Path.Combine(System.IO.Path.Combine(Agency.ImportPath, "Avails"), UserCode)

                                            If My.Computer.FileSystem.DirectoryExists(FilePath) = False Then

                                                My.Computer.FileSystem.CreateDirectory(FilePath)

                                            End If

                                            For Each UploadFile In UploadFiles

                                                File = System.IO.Path.Combine(FilePath, UploadFile.FileName)

                                                UploadFile.SaveAs(File)

                                            Next

                                            AdvantageFramework.Security.Impersonate.EndImpersonation()

                                        Catch ex As Exception

                                            While ex.InnerException IsNot Nothing

                                                ex = ex.InnerException

                                            End While

                                            IsValid = False
                                            ErrorMessage = ex.Message

                                        End Try

                                    Else

                                        IsValid = False
                                        ErrorMessage = "Cannot find agency settings. Please contact software support."

                                    End If

                                End If

                            End Using

                        End Using

                    Else

                        IsValid = False
                        ErrorMessage = "Invalid connection string on link."

                    End If

                Else

                    IsValid = False
                    ErrorMessage = "Please select at least one file to upload."

                End If

                If IsValid Then

                    UploadAvailViewModel.UploadedSucessfully = True

                Else

                    ModelState.AddModelError("", ErrorMessage)

                End If

            End If

            UploadAvail = View(UploadAvailViewModel)

        End Function

        Public Function CheckUserGroupSetting(ByVal GroupSetting As AdvantageFramework.Security.GroupSettings) As Integer
            Dim SessionKey As String = "CheckUserGroupSetting" & GroupSetting.ToString()
            Dim i As Integer = 0
            If Session(SessionKey) Is Nothing Then
                Try
                    i = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(SecuritySession, GroupSetting).Any(Function(SettingValue) SettingValue = True))
                Catch ex As Exception
                    i = 0
                End Try
            Else
                i = CType(Session(SessionKey), Integer)
            End If
            Return i
        End Function

        <HttpGet>
        Function LoadTaskDocuments(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As JsonResult
            Dim DocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim AttachmentDocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim JobComponentTaskDocuments As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskDocument) = Nothing
            Dim AlertAttachments As Generic.List(Of AdvantageFramework.Database.Entities.AlertAttachment) = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Files As IEnumerable = Nothing
            Dim AccessPrivate As Boolean = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments) = 1

            If JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso SequenceNumber >= 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext, JobNumber, JobComponentNumber, SequenceNumber)

                    Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        Try

                            JobComponentTaskDocuments = AdvantageFramework.Database.Procedures.JobComponentTaskDocument.LoadCurrentByJobComponentTask(DataContext, JobNumber, JobComponentNumber, SequenceNumber).ToList
                            AlertAttachments = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertID(DbContext, Alert.ID).ToList

                            If AccessPrivate = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                                Where JobComponentTaskDocuments.Where(Function(JobComponentTaskDocument) JobComponentTaskDocument.DocumentID = Document.ID).Any AndAlso
                                                  CBool(Document.IsPrivate.GetValueOrDefault(0)) = False
                                                Select Document).ToList.Union(From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                                                              Where AlertAttachments.Where(Function(AlertAttachment) AlertAttachment.DocumentID = Document.ID).Any AndAlso
                                                            CBool(Document.IsPrivate.GetValueOrDefault(0)) = False
                                                                              Select Document).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                                Where JobComponentTaskDocuments.Where(Function(JobComponentTaskDocument) JobComponentTaskDocument.DocumentID = Document.ID).Any
                                                Select Document).ToList.Union(From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                                                              Where AlertAttachments.Where(Function(AlertAttachment) AlertAttachment.DocumentID = Document.ID).Any
                                                                              Select Document).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.Database.Entities.Document)
                        End Try

                        Files = (From Document In DocumentList
                                 Select New With {Document.ID,
                                                                           Key Document.FileName,
                                                                           Document.Description,
                                                                           .DocumentTypeDescription = Document.DocumentType.Description,
                                                                           Document.FileSize,
                                                                           Document.UserCode,
                                                                           Document.UploadedDate,
                                                                           Document.IsPrivate,
                                                                           Document.MIMEType,
                                                                           Document.FileSystemFileName,
                                                                           Document.Thumbnail}).ToList

                    End Using

                End Using

            End If

            Return MaxJson(Files, JsonRequestBehavior.AllowGet)

        End Function

        Public Function DownloadFile(ByVal id As Integer) As FileResult
            If id > 0 Then
                Dim AccessPrivate As Boolean = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments) = 1
                Dim Document As New Document(SecuritySession.ConnectionString)
                Document.LoadByPrimaryKey(id)
                Dim DocumentRepository As New DocumentRepository(SecuritySession.ConnectionString)
                Dim RealFilename As String = Document.FILENAME  ' Filename

                If AccessPrivate = False And Document.PRIVATE_FLAG = 1 Then

                    Return Nothing

                End If

                Dim MimeType As String = ""
                Try

                    MimeType = Document.MIME_TYPE

                Catch ex As Exception

                    MimeType = String.Empty

                End Try

                If RealFilename.ToLower().EndsWith(".docx") = True Then MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                If RealFilename.ToLower().EndsWith(".xlsx") = True Then MimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                If RealFilename.ToLower().EndsWith(".pptx") = True Then MimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation"



                With Response

                    Try

                        Dim FileBytes() As Byte = DocumentRepository.GetDocument(id)
                        .Buffer = True
                        .AddHeader("Content-Disposition", "attachment;filename=""" & RealFilename & """")
                        .AddHeader("Content-Length", Document.s_FILE_SIZE)
                        .ContentType = MimeType
                        .BinaryWrite(FileBytes)
                        '.End()
                        '.Flush()
                        '.Clear()

                    Catch ex As Exception

                        .End()
                        .Clear()

                    End Try

                End With

            End If

        End Function
#End Region

    End Class

End Namespace

