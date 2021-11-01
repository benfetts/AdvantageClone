Namespace Controllers.Media

    <System.Web.Mvc.AllowAnonymous>
    Public Class MediaManagerController
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
        Private Sub GetOrderInfo(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MediaFrom As String, ByRef OrderForm As ViewModels.MediaManager.OrderFormViewModel)

            'objects
            Dim MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder = Nothing
            Dim NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder = Nothing
            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim ClientCode As String = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            If OrderForm Is Nothing Then

                OrderForm = New ViewModels.MediaManager.OrderFormViewModel

                OrderForm.InDifferentOrderState = False

            End If

            If MediaFrom.ToUpper.StartsWith("M") Then

                MagazineOrder = AdvantageFramework.Database.Procedures.MagazineOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If MagazineOrder IsNot Nothing Then

                    OrderForm.MediaType = "M"

                    If MagazineOrder.OrderProcessControl.GetValueOrDefault(1) <> 1 Then

                        OrderForm.InDifferentOrderState = True

                    End If

                    OrderForm.IsNetAmount = If(MagazineOrder.NetGross = 0, True, False)

                    OrderForm.IsQuote = If(MagazineOrder.Status = "1", True, False)

                    If String.IsNullOrWhiteSpace(MagazineOrder.BuyerEmployeeCode) = False Then

                        Employee = DbContext.Employees.Find(MagazineOrder.BuyerEmployeeCode)

                        If Employee IsNot Nothing Then

                            OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                            OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                        ElseIf String.IsNullOrWhiteSpace(MagazineOrder.Buyer) = False Then

                            Try

                                Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.FirstName & " " & Entity.LastName = MagazineOrder.Buyer)

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                            If Employee IsNot Nothing Then

                                OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                                OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                            Else

                                OrderForm.ContactName = MagazineOrder.Buyer
                                OrderForm.ContactNumber = ""

                            End If

                        End If

                    End If

                    OrderForm.OrderComments = MagazineOrder.OrderComment

                    ClientCode = MagazineOrder.ClientCode

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("N") Then

                NewspaperOrder = AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If NewspaperOrder IsNot Nothing Then

                    OrderForm.MediaType = "N"

                    If NewspaperOrder.OrderProcessControl.GetValueOrDefault(1) <> 1 Then

                        OrderForm.InDifferentOrderState = True

                    End If

                    OrderForm.IsNetAmount = If(NewspaperOrder.NetGross = 0, True, False)

                    OrderForm.IsQuote = If(NewspaperOrder.Status = "1", True, False)

                    If String.IsNullOrWhiteSpace(NewspaperOrder.BuyerEmployeeCode) = False Then

                        Employee = DbContext.Employees.Find(NewspaperOrder.BuyerEmployeeCode)

                        If Employee IsNot Nothing Then

                            OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                            OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                        ElseIf String.IsNullOrWhiteSpace(NewspaperOrder.Buyer) = False Then

                            Try

                                Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.FirstName & " " & Entity.LastName = NewspaperOrder.Buyer)

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                            If Employee IsNot Nothing Then

                                OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                                OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                            Else

                                OrderForm.ContactName = NewspaperOrder.Buyer
                                OrderForm.ContactNumber = ""

                            End If

                        End If

                    End If

                    OrderForm.OrderComments = NewspaperOrder.OrderComment

                    ClientCode = NewspaperOrder.ClientCode

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("I") Then

                InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If InternetOrder IsNot Nothing Then

                    OrderForm.MediaType = "I"

                    If InternetOrder.OrderProcessControl.GetValueOrDefault(1) <> 1 Then

                        OrderForm.InDifferentOrderState = True

                    End If

                    OrderForm.IsNetAmount = If(InternetOrder.NetGross = 0, True, False)

                    OrderForm.IsQuote = If(InternetOrder.Status = "1", True, False)

                    If String.IsNullOrWhiteSpace(InternetOrder.BuyerEmployeeCode) = False Then

                        Employee = DbContext.Employees.Find(InternetOrder.BuyerEmployeeCode)

                        If Employee IsNot Nothing Then

                            OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                            OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                        ElseIf String.IsNullOrWhiteSpace(InternetOrder.Buyer) = False Then

                            Try

                                Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.FirstName & " " & Entity.LastName = InternetOrder.Buyer)

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                            If Employee IsNot Nothing Then

                                OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                                OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                            Else

                                OrderForm.ContactName = InternetOrder.Buyer
                                OrderForm.ContactNumber = ""

                            End If

                        End If

                    End If

                    OrderForm.OrderComments = InternetOrder.OrderComment

                    ClientCode = InternetOrder.ClientCode

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("O") Then

                OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If OutOfHomeOrder IsNot Nothing Then

                    OrderForm.MediaType = "O"

                    If OutOfHomeOrder.OrderProcessControl.GetValueOrDefault(1) <> 1 Then

                        OrderForm.InDifferentOrderState = True

                    End If

                    OrderForm.IsNetAmount = If(OutOfHomeOrder.NetGross = 0, True, False)

                    OrderForm.IsQuote = If(OutOfHomeOrder.Status = "1", True, False)

                    If String.IsNullOrWhiteSpace(OutOfHomeOrder.BuyerEmployeeCode) = False Then

                        Employee = DbContext.Employees.Find(OutOfHomeOrder.BuyerEmployeeCode)

                        If Employee IsNot Nothing Then

                            OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                            OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                        ElseIf String.IsNullOrWhiteSpace(OutOfHomeOrder.Buyer) = False Then

                            Try

                                Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.FirstName & " " & Entity.LastName = OutOfHomeOrder.Buyer)

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                            If Employee IsNot Nothing Then

                                OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                                OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                            Else

                                OrderForm.ContactName = OutOfHomeOrder.Buyer
                                OrderForm.ContactNumber = ""

                            End If

                        End If

                    End If

                    OrderForm.OrderComments = OutOfHomeOrder.OrderComment

                    ClientCode = OutOfHomeOrder.ClientCode

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("R") Then

                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If RadioOrder IsNot Nothing Then

                    OrderForm.MediaType = "R"

                    If RadioOrder.OrderProcessControl.GetValueOrDefault(1) <> 1 Then

                        OrderForm.InDifferentOrderState = True

                    End If

                    OrderForm.IsNetAmount = If(RadioOrder.NetGross = 0, True, False)

                    OrderForm.IsQuote = If(RadioOrder.Status = "1", True, False)

                    If String.IsNullOrWhiteSpace(RadioOrder.BuyerEmployeeCode) = False Then

                        Employee = DbContext.Employees.Find(RadioOrder.BuyerEmployeeCode)

                        If Employee IsNot Nothing Then

                            OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                            OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                        ElseIf String.IsNullOrWhiteSpace(RadioOrder.Buyer) = False Then

                            Try

                                Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.FirstName & " " & Entity.LastName = RadioOrder.Buyer)

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                            If Employee IsNot Nothing Then

                                OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                                OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                            Else

                                OrderForm.ContactName = RadioOrder.Buyer
                                OrderForm.ContactNumber = ""

                            End If

                        End If

                    End If

                    OrderForm.OrderComments = RadioOrder.OrderComment

                    ClientCode = RadioOrder.ClientCode

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("T") Then

                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If TVOrder IsNot Nothing Then

                    OrderForm.MediaType = "T"

                    If TVOrder.OrderProcessControl.GetValueOrDefault(1) <> 1 Then

                        OrderForm.InDifferentOrderState = True

                    End If

                    OrderForm.IsNetAmount = If(TVOrder.NetGross = 0, True, False)

                    OrderForm.IsQuote = If(TVOrder.Status = "1", True, False)

                    If String.IsNullOrWhiteSpace(TVOrder.BuyerEmployeeCode) = False Then

                        Employee = DbContext.Employees.Find(TVOrder.BuyerEmployeeCode)

                        If Employee IsNot Nothing Then

                            OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                            OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                        ElseIf String.IsNullOrWhiteSpace(TVOrder.Buyer) = False Then

                            Try

                                Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.FirstName & " " & Entity.LastName = TVOrder.Buyer)

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                            If Employee IsNot Nothing Then

                                OrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                                OrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                            Else

                                OrderForm.ContactName = TVOrder.Buyer
                                OrderForm.ContactNumber = ""

                            End If

                        End If

                    End If

                    OrderForm.OrderComments = TVOrder.OrderComment

                    ClientCode = TVOrder.ClientCode

                End If

            End If

            If String.IsNullOrWhiteSpace(ClientCode) = False Then

                Try

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode)

                Catch ex As Exception
                    Client = Nothing
                End Try

                If Client IsNot Nothing Then

                    OrderForm.ClientName = Client.Name

                End If

            End If

            If String.IsNullOrWhiteSpace(OrderForm.ContactName) Then

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    OrderForm.ContactName = Agency.Name
                    OrderForm.ContactNumber = Agency.Phone

                End If

            End If

        End Sub
        Private Sub GetMediaOrderInfo(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                      UserID As Integer, ByRef OrderFormDetail As ViewModels.MediaManager.OrderFormDetailViewModel, OrderNumber As Integer,
                                      LineNumber As Integer, MediaFrom As String, CreatedByUserCode As String, SetAmounts As Boolean)

            'objects
            Dim MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder = Nothing
            Dim NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder = Nothing
            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim MagazineOrderDetail As AdvantageFramework.Database.Entities.MagazineOrderDetail = Nothing
            Dim NewspaperOrderDetail As AdvantageFramework.Database.Entities.NewspaperOrderDetail = Nothing
            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing
            Dim OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail = Nothing
            Dim RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail = Nothing
            Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim VendorCode As String = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim AllowPrivateAccess As Boolean = False
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing
            Dim DocumentTypes As String = Nothing
            Dim DocumentTypeIDs As Generic.List(Of String) = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim IsNetAmount As Boolean = False
            Dim ExchangeRate As Decimal = 1

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, CreatedByUserCode, 0, DbContext.ConnectionString)

            Try

                AllowPrivateAccess = AdvantageFramework.Security.LoadUserGroupSetting(DbContext.ConnectionString, CreatedByUserCode, AdvantageFramework.Security.Application.Webvantage, AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Where(Function(Setting) Setting = True).Any

            Catch ex As Exception
                AllowPrivateAccess = False
            End Try

            Try

                DocumentTypes = AdvantageFramework.MediaManager.LoadDocumentTypes(SecurityDbContext, UserID)

                If String.IsNullOrWhiteSpace(DocumentTypes) = False Then

                    DocumentTypeIDs = Split(DocumentTypes, ",").ToList

                End If

            Catch ex As Exception
                DocumentTypeIDs = Nothing
            Finally

                If DocumentTypeIDs Is Nothing Then

                    DocumentTypeIDs = New Generic.List(Of String)

                End If

            End Try

            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

            If OrderFormDetail Is Nothing Then

                OrderFormDetail = New ViewModels.MediaManager.OrderFormDetailViewModel

            End If

            If MediaFrom.ToUpper.StartsWith("M") Then

                MagazineOrder = AdvantageFramework.Database.Procedures.MagazineOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If MagazineOrder IsNot Nothing Then

                    VendorCode = MagazineOrder.VendorCode

                    IsNetAmount = If(MagazineOrder.NetGross = 0, True, False)

                    Try

                        MagazineOrderDetail = AdvantageFramework.Database.Procedures.MagazineOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.MagazineOrderNumber = OrderNumber AndAlso Entity.LineNumber = LineNumber AndAlso Entity.IsActiveRevision = 1)

                    Catch ex As Exception
                        MagazineOrderDetail = Nothing
                    End Try

                    If MagazineOrderDetail IsNot Nothing Then

                        If SetAmounts Then

                            If Agency.UseMultipleCurrencies.GetValueOrDefault(0) = 1 AndAlso Not String.IsNullOrWhiteSpace(MagazineOrder.Vendor.CurrencyCode) AndAlso MagazineOrder.Vendor.CurrencyCode <> Agency.HomeCurrency Then

                                ExchangeRate = GetExchangeRate(DbContext, MagazineOrder.Vendor.CurrencyCode, Agency.HomeCurrency)

                                OrderFormDetail.CurrencyCode = MagazineOrder.Vendor.CurrencyCode
                                OrderFormDetail.GrossAmount = MagazineOrderDetail.ExtendedGrossAmount * ExchangeRate
                                OrderFormDetail.NetAmount = MagazineOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) * ExchangeRate

                            Else

                                OrderFormDetail.GrossAmount = MagazineOrderDetail.ExtendedGrossAmount
                                OrderFormDetail.NetAmount = MagazineOrderDetail.ExtendedNetAmount.GetValueOrDefault(0)

                            End If

                        End If

                        OrderFormDetail.IsCancellation = If(MagazineOrderDetail.IsLineCancelled = 1, True, False)

                        If MagazineOrderDetail.StartDate.HasValue AndAlso MagazineOrderDetail.EndDate.HasValue Then

                            OrderFormDetail.RunDates = MagazineOrderDetail.StartDate.Value.ToShortDateString & " to " & MagazineOrderDetail.EndDate.Value.ToShortDateString

                        ElseIf MagazineOrderDetail.StartDate.HasValue Then

                            OrderFormDetail.RunDates = MagazineOrderDetail.StartDate.Value.ToShortDateString

                        End If

                        If MagazineOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso MagazineOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = MagazineOrderDetail.JobNumber.Value,
                                                                                                                                                                                          .JobComponentNumber = MagazineOrderDetail.JobComponentNumber.Value})

                            For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                        If OrderFormDetail.HasRelatedDocuments = False Then
                            'MEDIA ORDER DOCUMENTS
                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder) With {.OrderNumber = MagazineOrderDetail.MagazineOrderNumber,
                                                                                                                                                                                        .MediaType = MediaFrom.ToUpper.Substring(0, 1)})

                            For Each Document In AdvantageFramework.DocumentManager.LoadMediaOrderDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                    Else

                        OrderFormDetail.HasRelatedDocuments = False

                    End If

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("N") Then

                NewspaperOrder = AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If NewspaperOrder IsNot Nothing Then

                    VendorCode = NewspaperOrder.VendorCode

                    IsNetAmount = If(NewspaperOrder.NetGross = 0, True, False)

                    Try

                        NewspaperOrderDetail = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.NewspaperOrderOrderNumber = OrderNumber AndAlso Entity.LineNumber = LineNumber AndAlso Entity.IsActiveRevision = 1)

                    Catch ex As Exception
                        NewspaperOrderDetail = Nothing
                    End Try

                    If NewspaperOrderDetail IsNot Nothing Then

                        If SetAmounts Then

                            If Agency.UseMultipleCurrencies.GetValueOrDefault(0) = 1 AndAlso Not String.IsNullOrWhiteSpace(NewspaperOrder.Vendor.CurrencyCode) AndAlso NewspaperOrder.Vendor.CurrencyCode <> Agency.HomeCurrency Then

                                ExchangeRate = GetExchangeRate(DbContext, NewspaperOrder.Vendor.CurrencyCode, Agency.HomeCurrency)

                                OrderFormDetail.CurrencyCode = NewspaperOrder.Vendor.CurrencyCode
                                OrderFormDetail.GrossAmount = NewspaperOrderDetail.ExtendedGrossAmount * ExchangeRate
                                OrderFormDetail.NetAmount = NewspaperOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) * ExchangeRate

                            Else

                                OrderFormDetail.GrossAmount = NewspaperOrderDetail.ExtendedGrossAmount
                                OrderFormDetail.NetAmount = NewspaperOrderDetail.ExtendedNetAmount.GetValueOrDefault(0)

                            End If

                        End If

                        OrderFormDetail.IsCancellation = If(NewspaperOrderDetail.IsLineCancelled = 1, True, False)

                        If NewspaperOrderDetail.StartDate.HasValue AndAlso NewspaperOrderDetail.EndDate.HasValue Then

                            OrderFormDetail.RunDates = NewspaperOrderDetail.StartDate.Value.ToShortDateString & " to " & NewspaperOrderDetail.EndDate.Value.ToShortDateString

                        ElseIf NewspaperOrderDetail.StartDate.HasValue Then

                            OrderFormDetail.RunDates = NewspaperOrderDetail.StartDate.Value.ToShortDateString

                        End If

                        If NewspaperOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso NewspaperOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = NewspaperOrderDetail.JobNumber.Value,
                                                                                                                                                                                          .JobComponentNumber = NewspaperOrderDetail.JobComponentNumber.Value})

                            For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                        If OrderFormDetail.HasRelatedDocuments = False Then
                            'MEDIA ORDER DOCUMENTS
                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder) With {.OrderNumber = NewspaperOrderDetail.NewspaperOrderOrderNumber,
                                                                                                                                                                                        .MediaType = MediaFrom.ToUpper.Substring(0, 1)})

                            For Each Document In AdvantageFramework.DocumentManager.LoadMediaOrderDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                    Else

                        OrderFormDetail.HasRelatedDocuments = False

                    End If

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("I") Then

                InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If InternetOrder IsNot Nothing Then

                    VendorCode = InternetOrder.VendorCode

                    IsNetAmount = If(InternetOrder.NetGross = 0, True, False)

                    Try

                        InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.InternetOrderOrderNumber = OrderNumber AndAlso Entity.LineNumber = LineNumber AndAlso Entity.IsActiveRevision = 1)

                    Catch ex As Exception
                        InternetOrderDetail = Nothing
                    End Try

                    If InternetOrderDetail IsNot Nothing Then

                        If SetAmounts Then

                            If Agency.UseMultipleCurrencies.GetValueOrDefault(0) = 1 AndAlso Not String.IsNullOrWhiteSpace(InternetOrder.Vendor.CurrencyCode) AndAlso InternetOrder.Vendor.CurrencyCode <> Agency.HomeCurrency Then

                                ExchangeRate = GetExchangeRate(DbContext, InternetOrder.Vendor.CurrencyCode, Agency.HomeCurrency)

                                OrderFormDetail.CurrencyCode = InternetOrder.Vendor.CurrencyCode
                                OrderFormDetail.GrossAmount = InternetOrderDetail.ExtendedGrossAmount * ExchangeRate
                                OrderFormDetail.NetAmount = InternetOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) * ExchangeRate

                            Else

                                OrderFormDetail.GrossAmount = InternetOrderDetail.ExtendedGrossAmount
                                OrderFormDetail.NetAmount = InternetOrderDetail.ExtendedNetAmount.GetValueOrDefault(0)

                            End If

                        End If

                        OrderFormDetail.IsCancellation = If(InternetOrderDetail.IsLineCancelled = 1, True, False)

                        If InternetOrderDetail.StartDate.HasValue AndAlso InternetOrderDetail.EndDate.HasValue Then

                            OrderFormDetail.RunDates = InternetOrderDetail.StartDate.Value.ToShortDateString & " to " & InternetOrderDetail.EndDate.Value.ToShortDateString

                        ElseIf InternetOrderDetail.StartDate.HasValue Then

                            OrderFormDetail.RunDates = InternetOrderDetail.StartDate.Value.ToShortDateString

                        End If

                        If InternetOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso InternetOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = InternetOrderDetail.JobNumber.Value,
                                                                                                                                                                                          .JobComponentNumber = InternetOrderDetail.JobComponentNumber.Value})

                            For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                        If OrderFormDetail.HasRelatedDocuments = False Then
                            'MEDIA ORDER DOCUMENTS
                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder) With {.OrderNumber = InternetOrderDetail.InternetOrderOrderNumber,
                                                                                                                                                                                        .MediaType = MediaFrom.ToUpper.Substring(0, 1)})

                            For Each Document In AdvantageFramework.DocumentManager.LoadMediaOrderDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                    Else

                        OrderFormDetail.HasRelatedDocuments = False

                    End If

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("O") Then

                OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If OutOfHomeOrder IsNot Nothing Then

                    VendorCode = OutOfHomeOrder.VenderCode

                    IsNetAmount = If(OutOfHomeOrder.NetGross = 0, True, False)

                    Try

                        OutOfHomeOrderDetail = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.OutofHomeOrderNumber = OrderNumber AndAlso Entity.LineNumber = LineNumber AndAlso Entity.IsActiveRevision = 1)

                    Catch ex As Exception
                        OutOfHomeOrderDetail = Nothing
                    End Try

                    If OutOfHomeOrderDetail IsNot Nothing Then

                        If SetAmounts Then

                            If Agency.UseMultipleCurrencies.GetValueOrDefault(0) = 1 AndAlso Not String.IsNullOrWhiteSpace(OutOfHomeOrder.Vendor.CurrencyCode) AndAlso OutOfHomeOrder.Vendor.CurrencyCode <> Agency.HomeCurrency Then

                                ExchangeRate = GetExchangeRate(DbContext, OutOfHomeOrder.Vendor.CurrencyCode, Agency.HomeCurrency)

                                OrderFormDetail.CurrencyCode = OutOfHomeOrder.Vendor.CurrencyCode
                                OrderFormDetail.GrossAmount = OutOfHomeOrderDetail.ExtendedGrossAmount * ExchangeRate
                                OrderFormDetail.NetAmount = OutOfHomeOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) * ExchangeRate

                            Else

                                OrderFormDetail.GrossAmount = OutOfHomeOrderDetail.ExtendedGrossAmount
                                OrderFormDetail.NetAmount = OutOfHomeOrderDetail.ExtendedNetAmount.GetValueOrDefault(0)

                            End If

                        End If

                        OrderFormDetail.IsCancellation = If(OutOfHomeOrderDetail.IsLineCancelled = 1, True, False)

                        If OutOfHomeOrderDetail.PostDate.HasValue AndAlso OutOfHomeOrderDetail.EndDate.HasValue Then

                            OrderFormDetail.RunDates = OutOfHomeOrderDetail.PostDate.Value.ToShortDateString & " to " & OutOfHomeOrderDetail.EndDate.Value.ToShortDateString

                        ElseIf OutOfHomeOrderDetail.PostDate.HasValue Then

                            OrderFormDetail.RunDates = OutOfHomeOrderDetail.PostDate.Value.ToShortDateString

                        End If

                        If OutOfHomeOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso OutOfHomeOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = OutOfHomeOrderDetail.JobNumber.Value,
                                                                                                                                                                                          .JobComponentNumber = OutOfHomeOrderDetail.JobComponentNumber.Value})

                            For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                        If OrderFormDetail.HasRelatedDocuments = False Then
                            'MEDIA ORDER DOCUMENTS
                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder) With {.OrderNumber = OutOfHomeOrderDetail.OutofHomeOrderNumber,
                                                                                                                                                                                        .MediaType = MediaFrom.ToUpper.Substring(0, 1)})

                            For Each Document In AdvantageFramework.DocumentManager.LoadMediaOrderDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                    Else

                        OrderFormDetail.HasRelatedDocuments = False

                    End If

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("R") Then

                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If RadioOrder IsNot Nothing Then

                    VendorCode = RadioOrder.VendorCode

                    IsNetAmount = If(RadioOrder.NetGross = 0, True, False)

                    Try

                        RadioOrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.RadioOrderNumber = OrderNumber AndAlso Entity.LineNumber = LineNumber AndAlso Entity.IsActiveRevision = 1)

                    Catch ex As Exception
                        RadioOrderDetail = Nothing
                    End Try

                    If RadioOrderDetail IsNot Nothing Then

                        If SetAmounts Then

                            If Agency.UseMultipleCurrencies.GetValueOrDefault(0) = 1 AndAlso Not String.IsNullOrWhiteSpace(RadioOrder.Vendor.CurrencyCode) AndAlso RadioOrder.Vendor.CurrencyCode <> Agency.HomeCurrency Then

                                ExchangeRate = GetExchangeRate(DbContext, RadioOrder.Vendor.CurrencyCode, Agency.HomeCurrency)

                                OrderFormDetail.CurrencyCode = RadioOrder.Vendor.CurrencyCode
                                OrderFormDetail.GrossAmount = RadioOrderDetail.ExtendedGrossAmount * ExchangeRate
                                OrderFormDetail.NetAmount = RadioOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) * ExchangeRate

                            Else

                                OrderFormDetail.GrossAmount = RadioOrderDetail.ExtendedGrossAmount
                                OrderFormDetail.NetAmount = RadioOrderDetail.ExtendedNetAmount.GetValueOrDefault(0)

                            End If

                        End If

                        OrderFormDetail.IsCancellation = If(RadioOrderDetail.IsLineCancelled = 1, True, False)

                        If RadioOrderDetail.StartDate.HasValue AndAlso RadioOrderDetail.EndDate.HasValue Then

                            OrderFormDetail.RunDates = RadioOrderDetail.StartDate.Value.ToString("MM/yyyy") & " to " & RadioOrderDetail.EndDate.Value.ToString("MM/yyyy")

                        ElseIf RadioOrderDetail.StartDate.HasValue Then

                            OrderFormDetail.RunDates = RadioOrderDetail.StartDate.Value.ToString("MM/yyyy")

                        End If

                        If RadioOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso RadioOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = RadioOrderDetail.JobNumber.Value,
                                                                                                                                                                                          .JobComponentNumber = RadioOrderDetail.JobComponentNumber.Value})

                            For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                        If OrderFormDetail.HasRelatedDocuments = False Then
                            'MEDIA ORDER DOCUMENTS
                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder) With {.OrderNumber = RadioOrderDetail.RadioOrderNumber,
                                                                                                                                                                                        .MediaType = MediaFrom.ToUpper.Substring(0, 1)})

                            For Each Document In AdvantageFramework.DocumentManager.LoadMediaOrderDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                    Else

                        OrderFormDetail.HasRelatedDocuments = False

                    End If

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("T") Then

                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If TVOrder IsNot Nothing Then

                    VendorCode = TVOrder.VendorCode

                    IsNetAmount = If(TVOrder.NetGross = 0, True, False)

                    Try

                        TVOrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.TVOrderNumber = OrderNumber AndAlso Entity.LineNumber = LineNumber AndAlso Entity.IsActiveRevision = 1)

                    Catch ex As Exception
                        TVOrderDetail = Nothing
                    End Try

                    If TVOrderDetail IsNot Nothing Then

                        If SetAmounts Then

                            If Agency.UseMultipleCurrencies.GetValueOrDefault(0) = 1 AndAlso Not String.IsNullOrWhiteSpace(TVOrder.Vendor.CurrencyCode) AndAlso TVOrder.Vendor.CurrencyCode <> Agency.HomeCurrency Then

                                ExchangeRate = GetExchangeRate(DbContext, TVOrder.Vendor.CurrencyCode, Agency.HomeCurrency)

                                OrderFormDetail.CurrencyCode = TVOrder.Vendor.CurrencyCode
                                OrderFormDetail.GrossAmount = TVOrderDetail.ExtendedGrossAmount * ExchangeRate
                                OrderFormDetail.NetAmount = TVOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) * ExchangeRate

                            Else

                                OrderFormDetail.GrossAmount = TVOrderDetail.ExtendedGrossAmount
                                OrderFormDetail.NetAmount = TVOrderDetail.ExtendedNetAmount.GetValueOrDefault(0)

                            End If

                        End If

                        OrderFormDetail.IsCancellation = If(TVOrderDetail.IsLineCancelled = 1, True, False)

                        If TVOrderDetail.StartDate.HasValue AndAlso TVOrderDetail.EndDate.HasValue Then

                            OrderFormDetail.RunDates = TVOrderDetail.StartDate.Value.ToString("MM/yyyy") & " to " & TVOrderDetail.EndDate.Value.ToString("MM/yyyy")

                        ElseIf TVOrderDetail.StartDate.HasValue Then

                            OrderFormDetail.RunDates = TVOrderDetail.StartDate.Value.ToString("MM/yyyy")

                        End If

                        If TVOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso TVOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = TVOrderDetail.JobNumber.Value,
                                                                                                                                                                                          .JobComponentNumber = TVOrderDetail.JobComponentNumber.Value})

                            For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                        If OrderFormDetail.HasRelatedDocuments = False Then
                            'MEDIA ORDER DOCUMENTS
                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder) With {.OrderNumber = TVOrderDetail.TVOrderNumber,
                                                                                                                                                                                        .MediaType = MediaFrom.ToUpper.Substring(0, 1)})

                            For Each Document In AdvantageFramework.DocumentManager.LoadMediaOrderDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                    OrderFormDetail.HasRelatedDocuments = True
                                    Exit For

                                End If

                            Next

                        End If

                    Else

                        OrderFormDetail.HasRelatedDocuments = False

                    End If

                End If

            End If

            OrderFormDetail.IsNetAmount = IsNetAmount

            OrderFormDetail.CurrencySymbol = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CURRENCY_SYMBOL FROM dbo.CURRENCY_CODES WHERE CURRENCY_CODE = '{0}'", OrderFormDetail.CurrencyCode)).FirstOrDefault

            If SetAmounts Then

                If String.IsNullOrWhiteSpace(VendorCode) = False AndAlso IsNetAmount = False Then

                    Try

                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode)

                    Catch ex As Exception
                        Vendor = Nothing
                    End Try

                    If Vendor IsNot Nothing Then

                        If Vendor.Commission.HasValue Then

                            OrderFormDetail.CommissionPercentage = Vendor.Commission.Value

                        Else

                            OrderFormDetail.CommissionPercentage = 15

                        End If

                    Else

                        OrderFormDetail.CommissionPercentage = 15

                    End If

                Else

                    OrderFormDetail.CommissionPercentage = 15

                End If

            End If

        End Sub
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
        Private Function GetOrderReport(DbContext As AdvantageFramework.Database.DbContext, MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport) As DevExpress.XtraReports.UI.XtraReport

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim LineNumbers As Generic.List(Of Integer) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MagazineOrderDetail As AdvantageFramework.Database.Entities.MagazineOrderDetail = Nothing
            Dim NewspaperOrderDetail As AdvantageFramework.Database.Entities.NewspaperOrderDetail = Nothing
            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing
            Dim OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail = Nothing
            Dim RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail = Nothing
            Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing
            Dim IsDaily As Boolean = False
            Dim ReportFormat As String = String.Empty

            Try

                If MediaManagerGeneratedReport IsNot Nothing Then

                    Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, MediaManagerGeneratedReport.CreatedByUserCode, 0, DbContext.ConnectionString)

                    LineNumbers = New Generic.List(Of Integer)

                    For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReport.ID).ToList

                        LineNumbers.Add(CInt(MediaManagerGeneratedReportDetail.LineNumber))

                    Next

                    If MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("M") Then

                        MagazineOrderDetail = AdvantageFramework.Database.Procedures.MagazineOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                        If MagazineOrderDetail IsNot Nothing Then

                            If MagazineOrderDetail.StartDate.HasValue AndAlso MagazineOrderDetail.EndDate.HasValue AndAlso MagazineOrderDetail.StartDate = MagazineOrderDetail.EndDate Then

                                IsDaily = True

                            End If

                        End If

                    ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("N") Then

                        NewspaperOrderDetail = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.LoadActiveRevisionByOrderNumberAndLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                        If NewspaperOrderDetail IsNot Nothing Then

                            If NewspaperOrderDetail.StartDate.HasValue AndAlso NewspaperOrderDetail.EndDate.HasValue AndAlso NewspaperOrderDetail.StartDate = NewspaperOrderDetail.EndDate Then

                                IsDaily = True

                            End If

                        End If

                    ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("I") Then

                        InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                        If InternetOrderDetail IsNot Nothing Then

                            If InternetOrderDetail.StartDate.HasValue AndAlso InternetOrderDetail.EndDate.HasValue AndAlso InternetOrderDetail.StartDate = InternetOrderDetail.EndDate Then

                                IsDaily = True

                            End If

                        End If

                    ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("O") Then

                        OutOfHomeOrderDetail = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                        If OutOfHomeOrderDetail IsNot Nothing Then

                            If OutOfHomeOrderDetail.PostDate.HasValue AndAlso OutOfHomeOrderDetail.EndDate.HasValue AndAlso OutOfHomeOrderDetail.PostDate = OutOfHomeOrderDetail.EndDate Then

                                IsDaily = True

                            End If

                        End If

                    ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("R") Then

                        RadioOrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                        If RadioOrderDetail IsNot Nothing Then

                            If RadioOrderDetail.StartDate.HasValue AndAlso RadioOrderDetail.EndDate.HasValue AndAlso RadioOrderDetail.StartDate = RadioOrderDetail.EndDate Then

                                IsDaily = True

                            End If

                        End If

                    ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("T") Then

                        TVOrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                        If TVOrderDetail IsNot Nothing Then

                            If TVOrderDetail.StartDate.HasValue AndAlso TVOrderDetail.EndDate.HasValue AndAlso TVOrderDetail.StartDate = TVOrderDetail.EndDate Then

                                IsDaily = True

                            End If

                        End If

                    End If

                    If MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("R") OrElse MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("T") Then

                        If IsDaily Then

                            ReportFormat = "5"

                        Else

                            ReportFormat = "4"

                        End If

                    Else

                        ReportFormat = "1"

                    End If

                    Report = AdvantageFramework.Reporting.Reports.CreateOrder(Session, MediaManagerGeneratedReport.OrderNumber, LineNumbers, MediaManagerGeneratedReport.MediaFrom, CInt(ReportFormat))

                End If

            Catch ex As Exception
                Report = Nothing
            End Try

            GetOrderReport = Report

        End Function
        Private Function GetPurchaseOrderReport(DbContext As AdvantageFramework.Database.DbContext, MediaManagerGeneratedPOReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport) As DevExpress.XtraReports.UI.XtraReport

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

            If MediaManagerGeneratedPOReport IsNot Nothing Then

                Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, MediaManagerGeneratedPOReport.CreatedByUserCode, 0, DbContext.ConnectionString)

                ParameterDictionary = AdvantageFramework.Reporting.Reports.GetPurchaseOrderReportParameterDictionary(Session, MediaManagerGeneratedPOReport.PONumber)

                Report = AdvantageFramework.Reporting.Reports.CreateReport(Session, AdvantageFramework.Reporting.ReportTypes.PurchaseOrderReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

            End If

            GetPurchaseOrderReport = Report

        End Function
        Private Function SendToDocumentManager(DbContext As AdvantageFramework.Database.DbContext, Report As DevExpress.XtraReports.UI.XtraReport,
                                               Agency As AdvantageFramework.Database.Entities.Agency, VendorCode As String, PONumber As Integer,
                                               Description As String, ByRef DocumentID As Integer) As Boolean

            'objects
            Dim SentToDocumentManager As Boolean = False
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileName As String = String.Empty
            Dim FileSystemFile As String = String.Empty
            Dim FileSystemFileName As String = String.Empty
            Dim FileSize As Integer = Integer.MinValue
            Dim MimeType As String = String.Empty
            Dim FinalLevelDescription As String = String.Empty
            Dim FinalLevel As String = String.Empty
            Dim Keywords As String = String.Empty
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim PurchaseOrderDocument As AdvantageFramework.Database.Entities.PurchaseOrderDocument = Nothing

            IsValid = AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage)

            If IsValid Then

                MemoryStream = New System.IO.MemoryStream
                Report.ExportToPdf(MemoryStream)

                MimeType = AdvantageFramework.FileSystem.GetMIMETypeByExtension(".pdf")
                FileSize = MemoryStream.Length
                FinalLevelDescription = AdvantageFramework.Database.Entities.DocumentLevel.PurchaseOrder.ToString & ":" & PONumber
                FinalLevel = AdvantageFramework.Database.Entities.DocumentLevel.PurchaseOrder.ToString
                Description = Description.Trim
                Keywords = Description
                FileName = Description & " SIGNED - " & VendorCode & " - " & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & "_" & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#") & ".pdf"

                If AdvantageFramework.FileSystem.Add(DbContext, Agency, MemoryStream, FileName, Description, Keywords, DbContext.UserCode, FinalLevel,
                                                     FinalLevelDescription, AdvantageFramework.FileSystem.DocumentSource.DocumentUpload, FileSystemFile, FileSystemFileName, False) Then

                    Document = New AdvantageFramework.Database.Entities.Document

                    Document.DbContext = DbContext
                    Document.FileName = FileName
                    Document.FileSystemFileName = FileSystemFileName
                    Document.MIMEType = MimeType
                    Document.Description = Description
                    Document.Keywords = Keywords
                    Document.UploadedDate = System.DateTime.Now
                    Document.UserCode = DbContext.UserCode
                    Document.FileSize = FileSize
                    Document.DocumentTypeID = 1
                    Document.IsPrivate = False

                    If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                        PurchaseOrderDocument = New AdvantageFramework.Database.Entities.PurchaseOrderDocument

                        PurchaseOrderDocument.DocumentID = Document.ID
                        PurchaseOrderDocument.Number = PONumber

                        SentToDocumentManager = AdvantageFramework.Database.Procedures.PurchaseOrderDocument.Insert(DbContext, PurchaseOrderDocument)

                    End If

                End If

            End If

            If SentToDocumentManager AndAlso Document IsNot Nothing Then

                DocumentID = Document.ID

            End If

            SendToDocumentManager = SentToDocumentManager

        End Function
        Private Sub GetPurchaseOrderInfo(DbContext As AdvantageFramework.Database.DbContext, PONumber As Integer, ByRef PurchaseOrderForm As ViewModels.MediaManager.PurchaseOrderFormViewModel)

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If PurchaseOrderForm Is Nothing Then

                PurchaseOrderForm = New ViewModels.MediaManager.PurchaseOrderFormViewModel

                PurchaseOrderForm.InDifferentOrderState = False

            End If

            PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, PONumber)

            If PurchaseOrder IsNot Nothing Then

                If PurchaseOrder.IsVoid.GetValueOrDefault(0) = 1 OrElse PurchaseOrder.IsComplete.GetValueOrDefault(0) = 1 Then

                    PurchaseOrderForm.InDifferentOrderState = True

                End If

                If String.IsNullOrWhiteSpace(PurchaseOrder.EmployeeCode) = False Then

                    Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.Code = PurchaseOrder.EmployeeCode)

                    If Employee IsNot Nothing Then

                        PurchaseOrderForm.ContactName = Employee.FirstName & " " & Employee.LastName
                        PurchaseOrderForm.ContactNumber = Employee.WorkPhoneNumber & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")

                        PurchaseOrderForm.Originator = Employee.FirstName & " " & Employee.LastName

                    End If

                End If

                PurchaseOrderForm.VendorCode = PurchaseOrder.VendorCode
                PurchaseOrderForm.VendorName = PurchaseOrder.Vendor.Name
                PurchaseOrderForm.PODescription = PurchaseOrder.Description
                PurchaseOrderForm.IssueDate = PurchaseOrder.Date
                PurchaseOrderForm.DueDate = PurchaseOrder.DueDate
                PurchaseOrderForm.POTotal = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, PurchaseOrder.Number).Sum(Function(POD) POD.ExtendedAmount).GetValueOrDefault(0)

                PurchaseOrderForm.RevisionNumber = PurchaseOrder.Revision

            End If

        End Sub
        Private Function GetExchangeRate(DbContext As AdvantageFramework.Database.DbContext, CurrencyCode As String, HomeCurrencyCode As String) As Decimal

            'objects
            Dim ExchangeRate As Decimal = 1
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing

            CurrencyDetail = AdvantageFramework.Database.Procedures.CurrencyDetail.LoadLatestByCurrencyCodeAndCurrencyCodeComparison(DbContext, CurrencyCode, HomeCurrencyCode)

            If CurrencyDetail IsNot Nothing Then

                ExchangeRate = CurrencyDetail.ReciprocalExchangeRate

            End If

            GetExchangeRate = ExchangeRate

        End Function

#End Region

        <System.Web.Mvc.HttpPost(),
        System.Web.Mvc.AllowAnonymous(),
        System.Web.Mvc.ValidateAntiForgeryToken()>
        Public Function OrderForm(OrderFormViewModel As ViewModels.MediaManager.OrderFormViewModel, QueryString As String) As System.Web.Mvc.ActionResult

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim DatabaseName As String = String.Empty
            Dim MediaManagerGeneratedReportID As Integer = 0
            Dim Email As String = String.Empty
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim LineNumber As Integer = 0
            Dim RevisionNumber As Short = 0
            Dim OrderFormDetail As ViewModels.MediaManager.OrderFormDetailViewModel = Nothing
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing
            Dim VCCCards As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard) = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim CollectedCostInformation As AdvantageFramework.Database.Entities.CollectedCostInformation = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim VendorCode As String = String.Empty
            Dim ReportDescription As String = String.Empty
            Dim DocumentID As Integer = 0
            Dim UserID As Integer = 0
            Dim SignDocumentUserCode As String = Nothing

            OrderFormViewModel.HasBeenSubmitted = False

            For Each OrderFormDetail In OrderFormViewModel.OrderFormDetails

                OrderFormDetail.HasBeenSubmitted = False

            Next

            If DecrpytQueryString(QueryString, DatabaseName, MediaManagerGeneratedReportID, Email) Then

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                    Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        MediaManagerGeneratedReport = DbContext.MediaManagerGeneratedReports.Find(MediaManagerGeneratedReportID)

                        If MediaManagerGeneratedReport IsNot Nothing Then

                            DbContext.Entry(MediaManagerGeneratedReport).Collection(Function(Entity) Entity.MediaManagerGeneratedReportDetails).Load()
                            DbContext.Entry(MediaManagerGeneratedReport).Collection(Function(Entity) Entity.MediaManagerGeneratedReportSentInfos).Load()

                        End If

                    End Using

                End Using

                If OrderFormViewModel.AcceptTermsOfAgreement = False Then

                    ModelState.AddModelError("AcceptTermsOfAgreement", "You must accept terms of the agreement.")

                End If

                If ModelState.IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    End Using

                    If MediaManagerGeneratedReport IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            VCCCards = New Generic.List(Of AdvantageFramework.Database.Entities.VCCCard)

                            For Each OrderFormDetail In OrderFormViewModel.OrderFormDetails

                                Try

                                    VCCCard = AdvantageFramework.Database.Procedures.VCCCard.Load(DbContext).SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderFormViewModel.OrderNumber AndAlso Entity.LineNumber = OrderFormDetail.LineNumber)

                                Catch ex As Exception
                                    VCCCard = Nothing
                                End Try

                                If VCCCard IsNot Nothing Then

                                    If OrderFormDetail.IsCancellation = False Then

                                        OrderFormDetail.CardNumber = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCCard.CardNumber)
                                        OrderFormDetail.CardCVCCode = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCCard.CVCCode)
                                        OrderFormDetail.CardExpirationDate = VCCCard.ExpirationDate

                                        OrderFormDetail.ChargeToName = Agency.Name
                                        OrderFormDetail.ChargeToAddress = Agency.Address
                                        OrderFormDetail.ChargeToAddress2 = Agency.Address2
                                        OrderFormDetail.ChargeToCity = Agency.City
                                        OrderFormDetail.ChargeToState = Agency.State
                                        OrderFormDetail.ChargeToZip = Agency.Zip

                                        VCCCard.CardAmount = OrderFormDetail.NetAmount

                                        VCCCards.Add(VCCCard)

                                    End If

                                End If

                            Next

                        End Using

                        If VCCCards IsNot Nothing AndAlso VCCCards.Count > 0 Then

                            Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, 0, SqlConnectionStringBuilder.ConnectionString)

                            AdvantageFramework.VCC.UpdateVCCCreditCard(Session, VCCCards, "")

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            For Each OrderFormDetail In OrderFormViewModel.OrderFormDetails

                                If AdvantageFramework.Database.Procedures.CollectedCostInformation.Load(DbContext).Any(Function(Entity) Entity.OrderNumber = OrderFormDetail.OrderNumber AndAlso Entity.LineNumber = OrderFormDetail.LineNumber AndAlso Entity.RevisionNumber = OrderFormDetail.RevisionNumber AndAlso Entity.IsQuote = OrderFormViewModel.IsQuote) = False Then

                                    CollectedCostInformation = New AdvantageFramework.Database.Entities.CollectedCostInformation

                                    CollectedCostInformation.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                    CollectedCostInformation.LineNumber = OrderFormDetail.LineNumber
                                    CollectedCostInformation.RevisionNumber = OrderFormDetail.RevisionNumber
                                    CollectedCostInformation.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                    DbContext.CollectedCostInformations.Add(CollectedCostInformation)

                                Else

                                    Try

                                        CollectedCostInformation = AdvantageFramework.Database.Procedures.CollectedCostInformation.Load(DbContext).SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderFormDetail.OrderNumber AndAlso Entity.LineNumber = OrderFormDetail.LineNumber AndAlso Entity.RevisionNumber = OrderFormDetail.RevisionNumber AndAlso Entity.IsQuote = OrderFormViewModel.IsQuote)

                                    Catch ex As Exception
                                        CollectedCostInformation = Nothing
                                    End Try

                                    If CollectedCostInformation IsNot Nothing Then

                                        CollectedCostInformation.ModifiedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.Entry(CollectedCostInformation).State = Entity.EntityState.Modified

                                    End If

                                End If

                                If CollectedCostInformation IsNot Nothing Then

                                    CollectedCostInformation.RevisionNumber = OrderFormDetail.RevisionNumber

                                    If OrderFormViewModel.IsNetAmount Then

                                        CollectedCostInformation.GrossAmount = 0
                                        CollectedCostInformation.CommissionPercentage = 0

                                    Else

                                        CollectedCostInformation.GrossAmount = OrderFormDetail.GrossAmount.GetValueOrDefault(0)
                                        CollectedCostInformation.CommissionPercentage = OrderFormDetail.CommissionPercentage

                                    End If

                                    CollectedCostInformation.NetAmount = OrderFormDetail.NetAmount
                                    CollectedCostInformation.Notes = OrderFormViewModel.Notes
                                    CollectedCostInformation.AuthorizedByName = OrderFormViewModel.AuthorizedBy
                                    CollectedCostInformation.IsQuote = OrderFormViewModel.IsQuote

                                End If

                            Next

                            DbContext.SaveChanges()

                        End Using

                        For Each OrderFormDetail In OrderFormViewModel.OrderFormDetails

                            OrderFormDetail.HasBeenSubmitted = True
                            AdvantageFramework.MediaManager.SetOrderStatusAccepted(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, MediaManagerGeneratedReportID, OrderFormViewModel.IsQuote, OrderFormDetail.IsCancellation, OrderFormViewModel.AuthorizedBy)

                        Next

                        Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, MediaManagerGeneratedReport.CreatedByUserCode)

                                    If User IsNot Nothing Then

                                        UserID = User.ID
                                        SignDocumentUserCode = User.UserCode

                                    Else

                                        SignDocumentUserCode = SqlConnectionStringBuilder.UserID

                                    End If

                                    For Each MediaManagerGeneratedReportSentInfo In MediaManagerGeneratedReport.MediaManagerGeneratedReportSentInfos.ToList

                                        If MediaManagerGeneratedReportSentInfo.Email = Email Then

                                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, MediaManagerGeneratedReportSentInfo.VendorRepresentativeCode, MediaManagerGeneratedReportSentInfo.VendorCode)

                                            If VendorRepresentative IsNot Nothing Then

                                                VendorCode = VendorRepresentative.VendorCode
                                                Exit For

                                            End If

                                        End If

                                    Next

                                    Report = AdvantageFramework.Reporting.Reports.GetOrderReport(DbContext, MediaManagerGeneratedReport)

                                    If Report IsNot Nothing Then

                                        If MediaManagerGeneratedReport.IsQuote Then

                                            ReportDescription = "Quote Request "

                                        ElseIf MediaManagerGeneratedReport.MediaManagerGeneratedReportDetails.All(Function(Entity) Entity.IsCancelled = True) Then

                                            ReportDescription = "Media Order Cancellation "

                                        ElseIf MediaManagerGeneratedReport.MediaManagerGeneratedReportDetails.Any(Function(Entity) Entity.IsCancelled = True) Then

                                            ReportDescription = "Media Order Revision "

                                        Else

                                            ReportDescription = "Media Order "

                                        End If

                                        If AdvantageFramework.MediaManager.LoadDefaultUploadAndSignDocumentWhenSubmitted(SecurityDbContext, UserID) Then

                                            If AdvantageFramework.Reporting.Reports.SendToDocumentManager(DbContext, Report, Agency, VendorCode, MediaManagerGeneratedReport.OrderNumber, MediaManagerGeneratedReport.MediaFrom, ReportDescription, DocumentID) Then

                                                Using DbContextSignDocument = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SignDocumentUserCode)

                                                    AdvantageFramework.DocumentManager.SignDocument(DbContextSignDocument, DataContext, SecurityDbContext, UserID, Agency, OrderFormViewModel.AuthorizedBy, DocumentID, MediaManagerGeneratedReport.MediaFrom, Email, Request.PhysicalApplicationPath)

                                                End Using

                                            End If

                                        End If

                                    End If

                                End Using

                            End Using

                        End Using

                        OrderFormViewModel.HasBeenSubmitted = True

                    End If

                End If

            End If

            OrderForm = View(OrderFormViewModel)

        End Function
        <System.Web.Mvc.AllowAnonymous()>
        Public Function DownloadOrderRelatedDocuments(QueryString As String) As System.Web.Mvc.FileContentResult

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim MediaManagerGeneratedReportDetail As AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim DatabaseName As String = Nothing
            Dim MediaManagerGeneratedReportID As Integer = 0
            Dim MagazineOrderDetail As AdvantageFramework.Database.Entities.MagazineOrderDetail = Nothing
            Dim NewspaperOrderDetail As AdvantageFramework.Database.Entities.NewspaperOrderDetail = Nothing
            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing
            Dim OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail = Nothing
            Dim RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail = Nothing
            Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AllowPrivateAccess As Boolean = False
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing
            Dim DocumentTypes As String = Nothing
            Dim DocumentTypeIDs As Generic.List(Of String) = Nothing
            Dim DocumentFileName As String = ""
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UserID As Integer = 0

            If DecrpytQueryString(QueryString, DatabaseName, MediaManagerGeneratedReportID, "") Then

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                MediaManagerGeneratedReport = AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID)

                                If MediaManagerGeneratedReport IsNot Nothing Then

                                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, MediaManagerGeneratedReport.CreatedByUserCode)

                                    If User IsNot Nothing Then

                                        UserID = User.ID

                                    End If

                                End If

                                Try

                                    DocumentTypes = AdvantageFramework.MediaManager.LoadDocumentTypes(SecurityDbContext, UserID)

                                    If String.IsNullOrWhiteSpace(DocumentTypes) = False Then

                                        DocumentTypeIDs = Split(DocumentTypes, ",").ToList

                                    End If

                                Catch ex As Exception
                                    DocumentTypeIDs = Nothing
                                Finally

                                    If DocumentTypeIDs Is Nothing Then

                                        DocumentTypeIDs = New Generic.List(Of String)

                                    End If

                                End Try

                                Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, 0, SqlConnectionStringBuilder.ConnectionString)

                                If MediaManagerGeneratedReport IsNot Nothing Then

                                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                    Try

                                        AllowPrivateAccess = AdvantageFramework.Security.LoadUserGroupSetting(DbContext.ConnectionString, MediaManagerGeneratedReport.CreatedByUserCode, AdvantageFramework.Security.Application.Webvantage, AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Where(Function(Setting) Setting = True).Any

                                    Catch ex As Exception
                                        AllowPrivateAccess = False
                                    End Try

                                    Documents = New Generic.List(Of AdvantageFramework.Database.Entities.Document)

                                    DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                                    For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                        If MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("M") Then

                                            Try

                                                MagazineOrderDetail = AdvantageFramework.Database.Procedures.MagazineOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.MagazineOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.IsActiveRevision = 1)

                                            Catch ex As Exception
                                                MagazineOrderDetail = Nothing
                                            End Try

                                            If MagazineOrderDetail IsNot Nothing Then

                                                If MagazineOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso MagazineOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = MagazineOrderDetail.JobNumber.Value,
                                                                                                                                                                                                                  .JobComponentNumber = MagazineOrderDetail.JobComponentNumber.Value})

                                                    For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                                        If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                                            Documents.Add(Document.GetDocumentEntity)

                                                        End If

                                                    Next

                                                End If

                                            End If

                                        ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("N") Then

                                            Try

                                                NewspaperOrderDetail = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.NewspaperOrderOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.IsActiveRevision = 1)

                                            Catch ex As Exception
                                                NewspaperOrderDetail = Nothing
                                            End Try

                                            If NewspaperOrderDetail IsNot Nothing Then

                                                If NewspaperOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso NewspaperOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = NewspaperOrderDetail.JobNumber.Value,
                                                                                                                                                                                                                  .JobComponentNumber = NewspaperOrderDetail.JobComponentNumber.Value})

                                                    For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                                        If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                                            Documents.Add(Document.GetDocumentEntity)

                                                        End If

                                                    Next

                                                End If

                                            End If

                                        ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("I") Then

                                            Try

                                                InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.InternetOrderOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.IsActiveRevision = 1)

                                            Catch ex As Exception
                                                InternetOrderDetail = Nothing
                                            End Try

                                            If InternetOrderDetail IsNot Nothing Then

                                                If InternetOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso InternetOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = InternetOrderDetail.JobNumber.Value,
                                                                                                                                                                                                                  .JobComponentNumber = InternetOrderDetail.JobComponentNumber.Value})

                                                    For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                                        If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                                            Documents.Add(Document.GetDocumentEntity)

                                                        End If

                                                    Next

                                                End If

                                            End If

                                        ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("O") Then

                                            Try

                                                OutOfHomeOrderDetail = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.OutofHomeOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.IsActiveRevision = 1)

                                            Catch ex As Exception
                                                OutOfHomeOrderDetail = Nothing
                                            End Try

                                            If OutOfHomeOrderDetail IsNot Nothing Then

                                                If OutOfHomeOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso OutOfHomeOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = OutOfHomeOrderDetail.JobNumber.Value,
                                                                                                                                                                                                                  .JobComponentNumber = OutOfHomeOrderDetail.JobComponentNumber.Value})

                                                    For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                                        If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                                            Documents.Add(Document.GetDocumentEntity)

                                                        End If

                                                    Next

                                                End If

                                            End If

                                        ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("R") Then

                                            Try

                                                RadioOrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.RadioOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.IsActiveRevision = 1)

                                            Catch ex As Exception
                                                RadioOrderDetail = Nothing
                                            End Try

                                            If RadioOrderDetail IsNot Nothing Then

                                                If RadioOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso RadioOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = RadioOrderDetail.JobNumber.Value,
                                                                                                                                                                                                                  .JobComponentNumber = RadioOrderDetail.JobComponentNumber.Value})

                                                    For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                                        If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                                            Documents.Add(Document.GetDocumentEntity)

                                                        End If

                                                    Next

                                                End If

                                            End If

                                        ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("T") Then

                                            Try

                                                TVOrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.Load(DbContext).SingleOrDefault(Function(Entity) Entity.TVOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.IsActiveRevision = 1)

                                            Catch ex As Exception
                                                TVOrderDetail = Nothing
                                            End Try

                                            If TVOrderDetail IsNot Nothing Then

                                                If TVOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso TVOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = TVOrderDetail.JobNumber.Value,
                                                                                                                                                                                                                  .JobComponentNumber = TVOrderDetail.JobComponentNumber.Value})

                                                    For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                                        If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                                            Documents.Add(Document.GetDocumentEntity)

                                                        End If

                                                    Next

                                                End If

                                            End If

                                        End If

                                    Next
                                    'MEDIA ORDER DOCUMENTS
                                    DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder) With {.OrderNumber = MediaManagerGeneratedReport.OrderNumber,
                                                                                                                                                                                                .MediaType = MediaManagerGeneratedReport.MediaFrom.ToUpper.Substring(0, 1)})

                                    For Each Document In AdvantageFramework.DocumentManager.LoadMediaOrderDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                        If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                            Documents.Add(Document.GetDocumentEntity)

                                        End If

                                    Next

                                    If Documents.Count > 0 Then

                                        ZipFile = New Ionic.Zip.ZipFile

                                        AdvantageFramework.DocumentManager.CreateZipPackage(Agency, Documents, ZipFile)

                                        MemoryStream = New System.IO.MemoryStream

                                        ZipFile.Save(MemoryStream)

                                        FileContentResult = New System.Web.Mvc.FileContentResult(MemoryStream.ToArray, AdvantageFramework.FileSystem.GetMIMETypeByExtension("ZIP"))
                                        FileContentResult.FileDownloadName = "Order " & MediaManagerGeneratedReport.OrderNumber & " Related Documents.zip"

                                    End If

                                End If

                            End Using

                        End Using

                    End Using

                Catch ex As Exception
                    FileContentResult = Nothing
                End Try

            End If

            DownloadOrderRelatedDocuments = FileContentResult

        End Function
        <System.Web.Mvc.AllowAnonymous()>
        Public Function DownloadOrderDocument(QueryString As String) As System.Web.Mvc.FileContentResult

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim LineNumbers As Generic.List(Of Integer) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim DatabaseName As String = Nothing
            Dim MediaManagerGeneratedReportID As Integer = 0
            Dim ClientName As String = Nothing
            Dim VendorName As String = Nothing
            Dim MagazineOrderDetail As AdvantageFramework.Database.Entities.MagazineOrderDetail = Nothing
            Dim NewspaperOrderDetail As AdvantageFramework.Database.Entities.NewspaperOrderDetail = Nothing
            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing
            Dim OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail = Nothing
            Dim RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail = Nothing
            Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing
            Dim IsDaily As Boolean = False
            Dim ReportFormat As String = String.Empty

            If DecrpytQueryString(QueryString, DatabaseName, MediaManagerGeneratedReportID, "") Then

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        MediaManagerGeneratedReport = AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID)

                        If MediaManagerGeneratedReport IsNot Nothing Then

                            Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, SqlConnectionStringBuilder.ConnectionString, MediaManagerGeneratedReport.CreatedByUserCode, 0, SqlConnectionStringBuilder.ConnectionString)

                            LineNumbers = New Generic.List(Of Integer)

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                LineNumbers.Add(CInt(MediaManagerGeneratedReportDetail.LineNumber))

                            Next

                            If MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("M") Then

                                MagazineOrderDetail = AdvantageFramework.Database.Procedures.MagazineOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                                If MagazineOrderDetail IsNot Nothing Then

                                    If MagazineOrderDetail.StartDate.HasValue AndAlso MagazineOrderDetail.EndDate.HasValue AndAlso MagazineOrderDetail.StartDate = MagazineOrderDetail.EndDate Then

                                        IsDaily = True

                                    End If

                                End If

                            ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("N") Then

                                NewspaperOrderDetail = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.LoadActiveRevisionByOrderNumberAndLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                                If NewspaperOrderDetail IsNot Nothing Then

                                    If NewspaperOrderDetail.StartDate.HasValue AndAlso NewspaperOrderDetail.EndDate.HasValue AndAlso NewspaperOrderDetail.StartDate = NewspaperOrderDetail.EndDate Then

                                        IsDaily = True

                                    End If

                                End If

                            ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("I") Then

                                InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                                If InternetOrderDetail IsNot Nothing Then

                                    If InternetOrderDetail.StartDate.HasValue AndAlso InternetOrderDetail.EndDate.HasValue AndAlso InternetOrderDetail.StartDate = InternetOrderDetail.EndDate Then

                                        IsDaily = True

                                    End If

                                End If

                            ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("O") Then

                                OutOfHomeOrderDetail = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                                If OutOfHomeOrderDetail IsNot Nothing Then

                                    If OutOfHomeOrderDetail.PostDate.HasValue AndAlso OutOfHomeOrderDetail.EndDate.HasValue AndAlso OutOfHomeOrderDetail.PostDate = OutOfHomeOrderDetail.EndDate Then

                                        IsDaily = True

                                    End If

                                End If

                            ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("R") Then

                                RadioOrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                                If RadioOrderDetail IsNot Nothing Then

                                    If RadioOrderDetail.StartDate.HasValue AndAlso RadioOrderDetail.EndDate.HasValue AndAlso RadioOrderDetail.StartDate = RadioOrderDetail.EndDate Then

                                        IsDaily = True

                                    End If

                                End If

                            ElseIf MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("T") Then

                                TVOrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerGeneratedReport.OrderNumber, CShort(LineNumbers(0)))

                                If TVOrderDetail IsNot Nothing Then

                                    If TVOrderDetail.StartDate.HasValue AndAlso TVOrderDetail.EndDate.HasValue AndAlso TVOrderDetail.StartDate = TVOrderDetail.EndDate Then

                                        IsDaily = True

                                    End If

                                End If

                            End If

                            If MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("R") OrElse MediaManagerGeneratedReport.MediaFrom.ToUpper.StartsWith("T") Then

                                If IsDaily Then

                                    ReportFormat = "5"

                                Else

                                    ReportFormat = "4"

                                End If

                            Else

                                ReportFormat = "1"

                            End If

                            Report = AdvantageFramework.Reporting.Reports.CreateOrder(Session, MediaManagerGeneratedReport.OrderNumber, LineNumbers, MediaManagerGeneratedReport.MediaFrom, CInt(ReportFormat), UseImpersonation:=True)

                            If Report IsNot Nothing Then

                                MemoryStream = New System.IO.MemoryStream

                                Report.ExportToPdf(MemoryStream)

                                FileContentResult = New System.Web.Mvc.FileContentResult(MemoryStream.ToArray, AdvantageFramework.FileSystem.GetMIMETypeByExtension("PDF"))

                                If AdvantageFramework.MediaManager.GetOrderClientAndVendor(DbContext, MediaManagerGeneratedReport.MediaFrom.Substring(0, 1), MediaManagerGeneratedReport.OrderNumber, ClientName, VendorName) Then

                                    FileContentResult.FileDownloadName = "Order Report " & ClientName & "_" & VendorName & "_" & MediaManagerGeneratedReport.OrderNumber & ".pdf"

                                Else

                                    FileContentResult.FileDownloadName = "Order Report " & "_" & MediaManagerGeneratedReport.OrderNumber & ".pdf"

                                End If

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    FileContentResult = Nothing
                End Try

            End If

            DownloadOrderDocument = FileContentResult

        End Function
        <MvcCodeRouting.CustomRoute(“~/MediaManager/OrderForm”)>
        <System.Web.Mvc.AllowAnonymous()>
        Public Function OrderForm() As System.Web.Mvc.ActionResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim MediaManagerGeneratedReportID As Integer = 0
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim MediaManagerGeneratedReportDetail As AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim OrderFormModel As ViewModels.MediaManager.OrderFormViewModel = Nothing
            Dim OrderFormDetail As ViewModels.MediaManager.OrderFormDetailViewModel = Nothing
            Dim RevisedByName As String = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UserID As Integer = 0

            Try

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

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

            Catch ex As Exception
                DecodedFailed = True
            End Try

            OrderFormModel = New ViewModels.MediaManager.OrderFormViewModel
            OrderFormModel.IsValid = True

            If DecodedFailed = False Then

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                        String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                    MediaManagerGeneratedReport = DbContext.MediaManagerGeneratedReports.Find(MediaManagerGeneratedReportID)

                                    If MediaManagerGeneratedReport IsNot Nothing Then

                                        User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, MediaManagerGeneratedReport.CreatedByUserCode)

                                        If User IsNot Nothing Then

                                            UserID = User.ID

                                        End If

                                        GetOrderInfo(DbContext, MediaManagerGeneratedReport.OrderNumber, MediaManagerGeneratedReport.MediaFrom, OrderFormModel)

                                        If OrderFormModel IsNot Nothing AndAlso OrderFormModel.InDifferentOrderState = False Then

                                            DbContext.Entry(MediaManagerGeneratedReport).Collection(Function(Entity) Entity.MediaManagerGeneratedReportDetails).Load()
                                            DbContext.Entry(MediaManagerGeneratedReport).Collection(Function(Entity) Entity.MediaManagerGeneratedReportSentInfos).Load()

                                            For Each MediaManagerGeneratedReportSentInfo In MediaManagerGeneratedReport.MediaManagerGeneratedReportSentInfos.ToList

                                                If MediaManagerGeneratedReportSentInfo.Email = Email Then

                                                    VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, MediaManagerGeneratedReportSentInfo.VendorRepresentativeCode, MediaManagerGeneratedReportSentInfo.VendorCode)

                                                    If VendorRepresentative IsNot Nothing Then

                                                        RevisedByName = VendorRepresentative.ToString
                                                        Exit For

                                                    End If

                                                End If

                                            Next

                                            OrderFormModel.AuthorizedBy = RevisedByName

                                            OrderFormModel.HasBeenSubmitted = False
                                            OrderFormModel.QueryString = "|" & Url(1).ToString & "|"
                                            OrderFormModel.ConnectionString = SqlConnectionStringBuilder.ConnectionString
                                            OrderFormModel.UserCode = SqlConnectionStringBuilder.UserID
                                            OrderFormModel.MediaManagerGeneratedReportID = MediaManagerGeneratedReportID
                                            OrderFormModel.OrderNumber = MediaManagerGeneratedReport.OrderNumber

                                            OrderFormModel.TermsOfAgreement = AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.VEN_COST_COL_TERMS)

                                            OrderFormModel.AgencyName = AdvantageFramework.Database.Procedures.Agency.LoadName(DbContext)

                                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                                OrderFormDetail = Nothing

                                                GetMediaOrderInfo(DbContext, DataContext, SecurityDbContext, UserID, OrderFormDetail, MediaManagerGeneratedReport.OrderNumber, MediaManagerGeneratedReportDetail.LineNumber, MediaManagerGeneratedReport.MediaFrom, MediaManagerGeneratedReport.CreatedByUserCode, True)

                                                If OrderFormDetail IsNot Nothing Then

                                                    OrderFormDetail.HasBeenSubmitted = False
                                                    OrderFormDetail.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                                    OrderFormDetail.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                                    OrderFormDetail.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber

                                                    OrderFormDetail.InDifferentOrderState = False

                                                    If OrderFormDetail.IsCancellation Then

                                                        OrderFormDetail.GrossAmount = 0
                                                        OrderFormDetail.NetAmount = 0

                                                    End If

                                                    If OrderFormModel.HasRelatedDocuments = False Then

                                                        OrderFormModel.HasRelatedDocuments = OrderFormDetail.HasRelatedDocuments

                                                    End If

                                                    If MediaManagerGeneratedReportDetail.IsCancelled <> OrderFormDetail.IsCancellation Then

                                                        OrderFormDetail.InDifferentOrderState = True

                                                    ElseIf MediaManagerGeneratedReport.IsQuote <> OrderFormModel.IsQuote Then

                                                        OrderFormDetail.InDifferentOrderState = True

                                                    End If

                                                End If

                                                OrderFormModel.OrderFormDetails.Add(OrderFormDetail)

                                                If OrderFormDetail.InDifferentOrderState = False Then

                                                    AdvantageFramework.MediaManager.SetOrderStatusReceived(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, MediaManagerGeneratedReportID, OrderFormModel.IsQuote, OrderFormDetail.IsCancellation, RevisedByName)

                                                End If

                                            Next

                                            OrderFormModel.InDifferentOrderState = OrderFormModel.OrderFormDetails.Any(Function(Entity) Entity.InDifferentOrderState = True)

                                        End If

                                    End If

                                End Using

                            End Using

                        End Using

                    Catch ex As Exception
                        OrderFormModel.IsValid = False
                    End Try

                Else

                    OrderFormModel.IsValid = False

                End If

            Else

                OrderFormModel.IsValid = False

            End If

            OrderForm = View(OrderFormModel)

        End Function
        <MvcCodeRouting.CustomRoute(“~/MediaManager/PurchaseOrderForm”)>
        <System.Web.Mvc.AllowAnonymous()>
        Public Function PurchaseOrderForm() As System.Web.Mvc.ActionResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim MediaManagerGeneratedPOReportID As Integer = 0
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MediaManagerGeneratedPOReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport = Nothing
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim PurchaseOrderFormModel As ViewModels.MediaManager.PurchaseOrderFormViewModel = Nothing
            Dim PurchaseOrderFormDetail As ViewModels.MediaManager.PurchaseOrderFormDetailViewModel = Nothing
            Dim RevisedByName As String = Nothing

            Try

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "MediaManagerGeneratedPOReportID"

                            MediaManagerGeneratedPOReportID = CInt(VariableValues(1).ToString)

                        Case "Email"

                            Email = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                DecodedFailed = True
            End Try

            PurchaseOrderFormModel = New ViewModels.MediaManager.PurchaseOrderFormViewModel
            PurchaseOrderFormModel.IsValid = True

            If DecodedFailed = False Then

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                        String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                MediaManagerGeneratedPOReport = DbContext.MediaManagerGeneratedPOReports.Find(MediaManagerGeneratedPOReportID)

                                If MediaManagerGeneratedPOReport IsNot Nothing Then

                                    GetPurchaseOrderInfo(DbContext, MediaManagerGeneratedPOReport.PONumber, PurchaseOrderFormModel)

                                    If PurchaseOrderFormModel IsNot Nothing AndAlso PurchaseOrderFormModel.InDifferentOrderState = False Then

                                        If MediaManagerGeneratedPOReport.Email = Email Then

                                            VendorContact = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorAndVendorContactCode(DbContext, PurchaseOrderFormModel.VendorCode, MediaManagerGeneratedPOReport.VendorContactCode)

                                            If VendorContact IsNot Nothing Then

                                                RevisedByName = VendorContact.FirstName & " " & VendorContact.LastName

                                            End If

                                        End If

                                        PurchaseOrderFormModel.AuthorizedBy = RevisedByName

                                        PurchaseOrderFormModel.HasBeenSubmitted = False
                                        PurchaseOrderFormModel.QueryString = "|" & Url(1).ToString & "|"
                                        PurchaseOrderFormModel.ConnectionString = SqlConnectionStringBuilder.ConnectionString
                                        PurchaseOrderFormModel.UserCode = SqlConnectionStringBuilder.UserID
                                        PurchaseOrderFormModel.MediaManagerGeneratedPOReportID = MediaManagerGeneratedPOReportID
                                        PurchaseOrderFormModel.PONumber = MediaManagerGeneratedPOReport.PONumber

                                        PurchaseOrderFormModel.TermsOfAgreement = AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.VEN_COST_COL_TERMS)

                                        PurchaseOrderFormModel.AgencyName = AdvantageFramework.Database.Procedures.Agency.LoadName(DbContext)

                                        For Each PurchaseOrderDetail In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, MediaManagerGeneratedPOReport.PONumber).ToList

                                            PurchaseOrderFormDetail = New ViewModels.MediaManager.PurchaseOrderFormDetailViewModel

                                            PurchaseOrderFormDetail.Description = PurchaseOrderDetail.LineDescription
                                            PurchaseOrderFormDetail.ClientName = PurchaseOrderDetail.Job.Client.Name
                                            PurchaseOrderFormDetail.Description = PurchaseOrderDetail.LineDescription
                                            PurchaseOrderFormDetail.JobNumber = PurchaseOrderDetail.JobNumber
                                            PurchaseOrderFormDetail.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber
                                            PurchaseOrderFormDetail.Quantity = PurchaseOrderDetail.Quantity
                                            PurchaseOrderFormDetail.Rate = PurchaseOrderDetail.Rate
                                            PurchaseOrderFormDetail.Amount = PurchaseOrderDetail.ExtendedAmount

                                            PurchaseOrderFormModel.PurchaseOrderFormDetails.Add(PurchaseOrderFormDetail)

                                            'If PurchaseOrderFormDetail.InDifferentOrderState = False Then
                                            AdvantageFramework.MediaManager.SetPurchaseOrderStatusOrderRecieved(DbContext, MediaManagerGeneratedPOReport.PONumber, MediaManagerGeneratedPOReport.PORevision.GetValueOrDefault(0), PurchaseOrderFormModel.UserCode)
                                            'End If

                                        Next

                                        'PurchaseOrderFormModel.InDifferentOrderState = PurchaseOrderFormDetails.Any(Function(Entity) Entity.InDifferentOrderState = True)

                                    End If

                                End If

                            End Using

                        End Using

                    Catch ex As Exception
                        PurchaseOrderFormModel.IsValid = False
                    End Try

                Else

                    PurchaseOrderFormModel.IsValid = False

                End If

            Else

                PurchaseOrderFormModel.IsValid = False

            End If

            PurchaseOrderForm = View(PurchaseOrderFormModel)

        End Function
        <System.Web.Mvc.HttpPost(),
        System.Web.Mvc.AllowAnonymous(),
        System.Web.Mvc.ValidateAntiForgeryToken()>
        Public Function PurchaseOrderForm(PurchaseOrderFormViewModel As ViewModels.MediaManager.PurchaseOrderFormViewModel, QueryString As String) As System.Web.Mvc.ActionResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim MediaManagerGeneratedPOReportID As Integer = 0
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MediaManagerGeneratedPOReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport = Nothing
            Dim PurchaseOrderFormDetail As ViewModels.MediaManager.PurchaseOrderFormDetailViewModel = Nothing
            Dim VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim ReportDescription As String = String.Empty
            Dim DocumentID As Integer = 0
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UserID As Integer = 0

            Try

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "MediaManagerGeneratedPOReportID"

                            MediaManagerGeneratedPOReportID = CInt(VariableValues(1).ToString)

                        Case "Email"

                            Email = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                DecodedFailed = True
            End Try

            If Not DecodedFailed Then

                PurchaseOrderFormViewModel.HasBeenSubmitted = False

                For Each PurchaseOrderFormDetail In PurchaseOrderFormViewModel.PurchaseOrderFormDetails

                    PurchaseOrderFormDetail.HasBeenSubmitted = False

                Next

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                If PurchaseOrderFormViewModel.AcceptTermsOfAgreement = False Then

                    ModelState.AddModelError("AcceptTermsOfAgreement", "You must accept terms of the agreement.")

                End If

                If ModelState.IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                MediaManagerGeneratedPOReport = DbContext.MediaManagerGeneratedPOReports.Find(MediaManagerGeneratedPOReportID)

                                User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, MediaManagerGeneratedPOReport.CreatedByUserCode)

                                If User IsNot Nothing Then

                                    UserID = User.ID

                                End If

                                If MediaManagerGeneratedPOReport IsNot Nothing Then

                                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                    VCCCardPO = (From Entity In AdvantageFramework.Database.Procedures.VCCCardPO.Load(DbContext)
                                                 Where Entity.PONumber = PurchaseOrderFormViewModel.PONumber
                                                 Select Entity).SingleOrDefault

                                    If VCCCardPO IsNot Nothing Then

                                        PurchaseOrderFormViewModel.CardNumber = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCCardPO.CardNumber)
                                        PurchaseOrderFormViewModel.CardCVCCode = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCCardPO.CVCCode)
                                        PurchaseOrderFormViewModel.CardExpirationDate = VCCCardPO.ExpirationDate

                                        PurchaseOrderFormViewModel.ChargeToName = Agency.Name
                                        PurchaseOrderFormViewModel.ChargeToAddress = Agency.Address
                                        PurchaseOrderFormViewModel.ChargeToAddress2 = Agency.Address2
                                        PurchaseOrderFormViewModel.ChargeToCity = Agency.City
                                        PurchaseOrderFormViewModel.ChargeToState = Agency.State
                                        PurchaseOrderFormViewModel.ChargeToZip = Agency.Zip

                                    End If

                                    AdvantageFramework.MediaManager.SetPurchaseOrderStatusOrderAccepted(DbContext, MediaManagerGeneratedPOReport.PONumber, MediaManagerGeneratedPOReport.PORevision.GetValueOrDefault(0), PurchaseOrderFormViewModel.AuthorizedBy)

                                    Report = GetPurchaseOrderReport(DbContext, MediaManagerGeneratedPOReport)

                                    If Report IsNot Nothing Then

                                        ReportDescription = "Purchase Order "

                                        If AdvantageFramework.MediaManager.LoadDefaultUploadAndSignDocumentWhenSubmitted(SecurityDbContext, UserID) Then

                                            If SendToDocumentManager(DbContext, Report, Agency, PurchaseOrderFormViewModel.VendorCode, MediaManagerGeneratedPOReport.PONumber, ReportDescription, DocumentID) Then

                                                AdvantageFramework.DocumentManager.SignDocument(DbContext, DataContext, SecurityDbContext, UserID, Agency, PurchaseOrderFormViewModel.AuthorizedBy, DocumentID, "PO", MediaManagerGeneratedPOReport.Email, Request.PhysicalApplicationPath)

                                            End If

                                        End If

                                    End If

                                End If

                            End Using

                        End Using

                    End Using

                    PurchaseOrderFormViewModel.HasBeenSubmitted = True

                End If

            End If

            PurchaseOrderForm = View(PurchaseOrderFormViewModel)

        End Function
        <System.Web.Mvc.AllowAnonymous()>
        Public Function DownloadPurchaseOrderDocument(QueryString As String) As System.Web.Mvc.FileContentResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim MediaManagerGeneratedPOReportID As Integer = 0
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MediaManagerGeneratedPOReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing

            Try

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "MediaManagerGeneratedPOReportID"

                            MediaManagerGeneratedPOReportID = CInt(VariableValues(1).ToString)

                        Case "Email"

                            Email = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                DecodedFailed = True
            End Try

            If Not DecodedFailed Then

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        MediaManagerGeneratedPOReport = DbContext.MediaManagerGeneratedPOReports.Find(MediaManagerGeneratedPOReportID)

                        If MediaManagerGeneratedPOReport IsNot Nothing Then

                            Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, SqlConnectionStringBuilder.ConnectionString, MediaManagerGeneratedPOReport.CreatedByUserCode, 0, SqlConnectionStringBuilder.ConnectionString)

                            Report = AdvantageFramework.Reporting.Reports.CreateReport(Session, AdvantageFramework.Reporting.ReportTypes.PurchaseOrderReport, AdvantageFramework.Reporting.Reports.GetPurchaseOrderReportParameterDictionary(Session, MediaManagerGeneratedPOReport.PONumber), Nothing, Nothing, Nothing, Nothing)

                            If Report IsNot Nothing Then

                                MemoryStream = New System.IO.MemoryStream

                                Report.ExportToPdf(MemoryStream)

                                FileContentResult = New System.Web.Mvc.FileContentResult(MemoryStream.ToArray, AdvantageFramework.FileSystem.GetMIMETypeByExtension("PDF"))
                                FileContentResult.FileDownloadName = "Purchase Order Report.pdf"

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    FileContentResult = Nothing
                End Try

            End If

            DownloadPurchaseOrderDocument = FileContentResult

        End Function

#Region " Request for Proposal "

        <MvcCodeRouting.CustomRoute(“~/MediaManager/RequestForProposalForm”)>
        <System.Web.Mvc.AllowAnonymous()>
        Public Function RequestForProposalForm() As System.Web.Mvc.ActionResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim MediaRFPHeaderID As Integer = 0
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim RequestForProposalFormViewModel As ViewModels.MediaManager.RequestForProposalFormViewModel = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim MediaRFPHeaderStatus As AdvantageFramework.Database.Entities.MediaRFPHeaderStatus = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim ReceivedBy As String = Nothing

            Try

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "MediaRFPHeaderID"

                            MediaRFPHeaderID = CInt(VariableValues(1).ToString)

                        Case "Email"

                            Email = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                DecodedFailed = True
            End Try

            RequestForProposalFormViewModel = New ViewModels.MediaManager.RequestForProposalFormViewModel
            RequestForProposalFormViewModel.IsValid = True

            If DecodedFailed = False Then

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                        String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                MediaRFPHeader = DbContext.MediaRFPHeaders.Find(MediaRFPHeaderID)

                                If MediaRFPHeader IsNot Nothing AndAlso MediaRFPHeader.AlertID.HasValue Then

                                    Alert = DbContext.Alerts.Find(MediaRFPHeader.AlertID.Value)

                                    If Alert IsNot Nothing Then

                                        RequestForProposalFormViewModel.Subject = Alert.Subject
                                        RequestForProposalFormViewModel.Body = Alert.EmailBody
                                        RequestForProposalFormViewModel.CommentToVendor = MediaRFPHeader.CommentToVendor
                                        RequestForProposalFormViewModel.HasBeenSubmitted = False
                                        RequestForProposalFormViewModel.QueryString = "|" & Url(1).ToString & "|"
                                        RequestForProposalFormViewModel.ConnectionString = SqlConnectionStringBuilder.ConnectionString
                                        RequestForProposalFormViewModel.UserCode = SqlConnectionStringBuilder.UserID
                                        RequestForProposalFormViewModel.AgencyName = AdvantageFramework.Database.Procedures.Agency.LoadName(DbContext)

                                        VendorRepresentative = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, MediaRFPHeader.VendorCode)
                                                                Where Entity.EmailAddress.ToUpper = Email.ToUpper
                                                                Select Entity).FirstOrDefault

                                        If VendorRepresentative IsNot Nothing Then

                                            ReceivedBy = VendorRepresentative.ToString

                                        Else

                                            VendorContact = (From Entity In AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorCode(DbContext, MediaRFPHeader.VendorCode)
                                                             Where Entity.Email.ToUpper = Email.ToUpper AndAlso
                                                                   (Entity.IsInactive Is Nothing OrElse
                                                                    Entity.IsInactive = 0)
                                                             Select Entity).FirstOrDefault

                                            If VendorContact IsNot Nothing Then

                                                ReceivedBy = VendorContact.ToString

                                            End If

                                        End If

                                        If Not String.IsNullOrWhiteSpace(ReceivedBy) Then

                                            If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeaderStatus.LoadByMediaRFPHeaderID(DbContext, MediaRFPHeaderID)
                                                Where Entity.MediaRFPStatusID = AdvantageFramework.Database.Entities.MediaRFPStatusID.Received).Any = False Then

                                                MediaRFPHeaderStatus = New AdvantageFramework.Database.Entities.MediaRFPHeaderStatus
                                                MediaRFPHeaderStatus.CreatedDate = Now
                                                MediaRFPHeaderStatus.CreatedByUserCode = ReceivedBy
                                                MediaRFPHeaderStatus.MediaRFPHeaderID = MediaRFPHeaderID
                                                MediaRFPHeaderStatus.MediaRFPStatusID = AdvantageFramework.Database.Entities.MediaRFPStatusID.Received

                                                DbContext.MediaRFPHeaderStatuses.Add(MediaRFPHeaderStatus)

                                                DbContext.SaveChanges()

                                            Else

                                                MediaRFPHeaderStatus = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeaderStatus.LoadByMediaRFPHeaderID(DbContext, MediaRFPHeaderID)
                                                                        Where Entity.MediaRFPStatusID = AdvantageFramework.Database.Entities.MediaRFPStatusID.Received).SingleOrDefault

                                                MediaRFPHeaderStatus.CreatedDate = Now
                                                MediaRFPHeaderStatus.CreatedByUserCode = ReceivedBy

                                                DbContext.Entry(MediaRFPHeaderStatus).State = Entity.EntityState.Modified

                                                DbContext.SaveChanges()

                                            End If

                                        End If

                                    Else

                                        RequestForProposalFormViewModel.IsValid = False

                                    End If

                                Else

                                    RequestForProposalFormViewModel.IsValid = False

                                End If

                            End Using

                        End Using

                    Catch ex As Exception
                        RequestForProposalFormViewModel.IsValid = False
                    End Try

                Else

                    RequestForProposalFormViewModel.IsValid = False

                End If

            Else

                RequestForProposalFormViewModel.IsValid = False

            End If

            RequestForProposalForm = View(RequestForProposalFormViewModel)

        End Function
        <System.Web.Mvc.HttpPost(),
        System.Web.Mvc.AllowAnonymous(),
        System.Web.Mvc.ValidateAntiForgeryToken()>
        Public Function RequestForProposalForm(RequestForProposalFormViewModel As ViewModels.MediaManager.RequestForProposalFormViewModel, QueryString As String,
                                               UploadFiles As System.Collections.Generic.IEnumerable(Of System.Web.HttpPostedFileBase)) As System.Web.Mvc.ActionResult

            'objects
            Dim DecodedFailed As Boolean = False
            Dim Url() As String = Nothing
            Dim DecodedQueryString As String = Nothing
            Dim QueryItems() As String = Nothing
            Dim VariableValues() As String = Nothing
            Dim DatabaseName As String = Nothing
            Dim Email As String = Nothing
            Dim MediaRFPHeaderID As Integer = 0
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim FilePath As String = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim DocumentID As Integer = 0
            Dim File As String = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim ResponseBy As String = Nothing
            Dim MediaRFPHeaderStatus As AdvantageFramework.Database.Entities.MediaRFPHeaderStatus = Nothing

            Try

                Url = HttpUtility.UrlDecode(Request.Url.OriginalString).Split("|")

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Url(1).ToString)

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "MediaRFPHeaderID"

                            MediaRFPHeaderID = CInt(VariableValues(1).ToString)

                        Case "Email"

                            Email = VariableValues(1).ToString

                    End Select

                Next

            Catch ex As Exception
                DecodedFailed = True
            End Try

            If Not DecodedFailed Then

                RequestForProposalFormViewModel.HasBeenSubmitted = False

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                'If RequestForProposalFormViewModel.AcceptTermsOfAgreement = False Then

                '    ModelState.AddModelError("AcceptTermsOfAgreement", "You must accept terms of the agreement.")

                'End If

                If ModelState.IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                        Using DataContext = New AdvantageFramework.Database.DataContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID)

                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                MediaRFPHeader = DbContext.MediaRFPHeaders.Find(MediaRFPHeaderID)

                                If MediaRFPHeader IsNot Nothing AndAlso MediaRFPHeader.AlertID.HasValue Then

                                    VendorRepresentative = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, MediaRFPHeader.VendorCode)
                                                            Where Entity.EmailAddress.ToUpper = Email.ToUpper
                                                            Select Entity).FirstOrDefault

                                    If VendorRepresentative IsNot Nothing Then

                                        ResponseBy = VendorRepresentative.ToString

                                    Else

                                        VendorContact = (From Entity In AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorCode(DbContext, MediaRFPHeader.VendorCode)
                                                         Where Entity.Email.ToUpper = Email.ToUpper AndAlso
                                                               (Entity.IsInactive Is Nothing OrElse
                                                                Entity.IsInactive = 0)
                                                         Select Entity).FirstOrDefault

                                        If VendorContact IsNot Nothing Then

                                            ResponseBy = VendorContact.ToString

                                        End If

                                    End If

                                    If Not String.IsNullOrWhiteSpace(ResponseBy) Then

                                        MediaRFPHeaderStatus = New AdvantageFramework.Database.Entities.MediaRFPHeaderStatus
                                        MediaRFPHeaderStatus.CreatedDate = Now
                                        MediaRFPHeaderStatus.CreatedByUserCode = ResponseBy
                                        MediaRFPHeaderStatus.MediaRFPHeaderID = MediaRFPHeaderID
                                        MediaRFPHeaderStatus.MediaRFPStatusID = AdvantageFramework.Database.Entities.MediaRFPStatusID.Response

                                        DbContext.MediaRFPHeaderStatuses.Add(MediaRFPHeaderStatus)
                                        DbContext.SaveChanges()

                                        If UploadFiles IsNot Nothing AndAlso UploadFiles.Count > 0 Then

                                            If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) Then

                                                For Each UploadFile In UploadFiles

                                                    MemoryStream = New System.IO.MemoryStream()

                                                    UploadFile.InputStream.CopyTo(MemoryStream)

                                                    If AdvantageFramework.FileSystem.Add(DbContext, Agency, MemoryStream, UploadFile.FileName, MediaRFPHeader.Vendor.Name, "", ResponseBy, AddToDocumentRepository:=True, DocumentID:=DocumentID) Then

                                                        AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment

                                                        AlertAttachment.DbContext = DbContext
                                                        AlertAttachment.DocumentID = DocumentID
                                                        AlertAttachment.AlertID = MediaRFPHeader.AlertID
                                                        AlertAttachment.GeneratedDate = Now
                                                        AlertAttachment.UserCode = ResponseBy
                                                        AlertAttachment.HasEmailBeenSent = 0

                                                        AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

                                                    End If

                                                Next

                                                RequestForProposalFormViewModel.FilesUploaded = True

                                            End If

                                        End If

                                        AlertComment = New AdvantageFramework.Database.Entities.AlertComment
                                        AlertComment.DbContext = DbContext

                                        AlertComment.AlertID = MediaRFPHeader.AlertID.Value
                                        AlertComment.GeneratedDate = Now
                                        AlertComment.Comment = RequestForProposalFormViewModel.Comment
                                        AlertComment.HasEmailBeenSent = False

                                        If VendorContact IsNot Nothing Then

                                            AlertComment.VendorContactCode = VendorContact.Code

                                        ElseIf VendorRepresentative IsNot Nothing Then

                                            AlertComment.VendorRepresentativeCode = VendorRepresentative.Code

                                        End If

                                        If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) Then

                                            AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(SecurityDbContext, DbContext, MediaRFPHeader.Alert, MediaRFPHeader.Alert.Subject, IncludeOriginator:=True)

                                            RequestForProposalFormViewModel.HasBeenSubmitted = True

                                        Else

                                            IsValid = False
                                            ErrorMessage = "Cannot insert alert comment. Please contact software support."

                                        End If

                                    End If

                                Else

                                    IsValid = False
                                    ErrorMessage = "Cannot find media RFP header. Please contact software support."

                                End If

                            End Using

                        End Using

                    End Using

                End If

            Else

                IsValid = False
                ErrorMessage = "Cannot connect to database. Please contact software support."

            End If

            If Not IsValid Then

                ModelState.AddModelError("", ErrorMessage)

            End If

            RequestForProposalForm = View(RequestForProposalFormViewModel)

        End Function

#End Region

#End Region

    End Class

End Namespace
