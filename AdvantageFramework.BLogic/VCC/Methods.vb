Namespace VCC

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enums "

        Public Enum VCCProviders As Short
            EFS = 1
            CSI = 2
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadVCCProvider(ByVal DataContext As AdvantageFramework.Database.DataContext) As Short

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim VCCProvider As Short = 0

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCC_PROVIDER.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                If IsNothing(Setting.Value) AndAlso IsNothing(Setting.DefaultValue) = False Then

                    VCCProvider = Setting.DefaultValue

                ElseIf IsNothing(Setting.Value) = False Then

                    VCCProvider = Setting.Value

                End If

            End If

            LoadVCCProvider = VCCProvider

        End Function
        Private Function LoadVCCUseSystemWideAccount(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim UseSystemWideAccount As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCC_USE_SA.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                If IsNothing(Setting.Value) Then

                    UseSystemWideAccount = Setting.DefaultValue

                Else

                    UseSystemWideAccount = Setting.Value

                End If

            End If

            LoadVCCUseSystemWideAccount = UseSystemWideAccount

        End Function
        Private Function LoadVCCAPIUrl(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim VCCAPIUrl As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCC_API_URL.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                'If Debugger.IsAttached Then

                '    VCCAPIUrl = Setting.DefaultValue

                'Else

                VCCAPIUrl = Setting.Value

                'End If

            End If

            LoadVCCAPIUrl = VCCAPIUrl

        End Function
        Private Function LoadSystemWideVCCUserName(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim VCCUserName As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCC_SA_USERNAME.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                VCCUserName = Setting.Value

            End If

            LoadSystemWideVCCUserName = VCCUserName

        End Function
        Private Function LoadSystemWideVCCPassword(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim VCCPassword As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCC_SA_PASSWORD.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                VCCPassword = Setting.Value

            End If

            LoadSystemWideVCCPassword = VCCPassword

        End Function
        Private Function LoadAccountID(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim AccountID As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCC_ACCOUNT_ID.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                AccountID = Setting.Value

            End If

            LoadAccountID = AccountID

        End Function
        Private Function LoadOutsourceID(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim OutsourceID As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCC_OUTSOURCE_ID.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                OutsourceID = Setting.Value

            End If

            LoadOutsourceID = OutsourceID

        End Function
        Private Function LoadCompanyID(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim CompanyID As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCC_COMPANY_ID.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                CompanyID = Setting.Value

            End If

            LoadCompanyID = CompanyID

        End Function
        Public Function IsVCCServiceSetup(Session As AdvantageFramework.Security.Session, Optional ByRef ErrorMessage As String = Nothing) As Boolean

            'objects
            Dim ServiceIsSetup As Boolean = False

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                ServiceIsSetup = IsVCCServiceSetup(Session, DataContext, ErrorMessage)

            End Using

            IsVCCServiceSetup = ServiceIsSetup

        End Function
        Private Function IsVCCServiceSetup(Session As AdvantageFramework.Security.Session, DataContext As AdvantageFramework.Database.DataContext,
                                           Optional ByRef ErrorMessage As String = Nothing) As Boolean

            'objects
            Dim VCCProvider As Short = Nothing
            Dim ServiceIsSetup As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim RTMCServiceClient As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing

            If DataContext IsNot Nothing Then

                Try

                    VCCProvider = LoadVCCProvider(DataContext)

                    If VCCProvider <> 0 Then

                        If LoadVCCUseSystemWideAccount(DataContext) Then

                            If String.IsNullOrWhiteSpace(LoadSystemWideVCCUserName(DataContext)) = False AndAlso String.IsNullOrWhiteSpace(LoadSystemWideVCCPassword(DataContext)) = False Then

                                ServiceIsSetup = True

                            End If

                        Else

                            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                            End Using

                            If Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.VCCUserName) = False AndAlso String.IsNullOrWhiteSpace(Employee.VCCPassword) = False Then

                                ServiceIsSetup = True

                            End If

                        End If

                    End If

                Catch ex As Exception
                    ErrorMessage = "IsVCCServiceSetup " & System.Environment.NewLine & ex.Message
                End Try

                If ServiceIsSetup Then

                    If VCCProvider = AdvantageFramework.VCC.VCCProviders.EFS Then

                        Try

                            RTMCServiceClient = CreateRTMCService(Session, DataContext)

                        Catch ex As Exception
                            ErrorMessage += "IsVCCServiceSetup:CreateRTMService " & System.Environment.NewLine & ex.Message
                        End Try

                        If RTMCServiceClient IsNot Nothing Then

                            Try

                                ServiceIsSetup = TestServiceConnection(RTMCServiceClient, ErrorMessage)

                            Catch ex As Exception
                                ErrorMessage += "IsVCCServiceSetup:TestServiceConnection " & System.Environment.NewLine & ex.Message
                                ServiceIsSetup = False
                            End Try

                        End If

                    ElseIf VCCProvider = AdvantageFramework.VCC.VCCProviders.CSI Then

                        Try

                            ServiceIsSetup = TestServiceConnection(Session, DataContext, "")

                        Catch ex As Exception
                            ErrorMessage += "IsVCCServiceSetup:TestServiceConnection " & System.Environment.NewLine & ex.Message
                            ServiceIsSetup = False
                        End Try

                    End If

                End If

            End If

            IsVCCServiceSetup = ServiceIsSetup

        End Function
        Private Function CreateRTMCService(Session As AdvantageFramework.Security.Session, DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.RTMCService.RTMCServiceClient

            'objects
            Dim RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing
            Dim WSHttpBinding As System.ServiceModel.WSHttpBinding = Nothing
            Dim EndpointAddress As System.ServiceModel.EndpointAddress = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            WSHttpBinding = New System.ServiceModel.WSHttpBinding

            WSHttpBinding.Security.Mode = ServiceModel.SecurityMode.TransportWithMessageCredential
            WSHttpBinding.Security.Transport.ClientCredentialType = ServiceModel.HttpClientCredentialType.None
            WSHttpBinding.Security.Message.ClientCredentialType = ServiceModel.MessageCredentialType.UserName
            WSHttpBinding.Security.Message.EstablishSecurityContext = False
            WSHttpBinding.MaxReceivedMessageSize = 2147483647
            WSHttpBinding.MaxBufferPoolSize = 2147483647
            WSHttpBinding.ReaderQuotas.MaxDepth = 2147483647
            WSHttpBinding.ReaderQuotas.MaxStringContentLength = 2147483647
            WSHttpBinding.ReaderQuotas.MaxArrayLength = 2147483647
            WSHttpBinding.ReaderQuotas.MaxBytesPerRead = 2147483647
            WSHttpBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647

            EndpointAddress = New System.ServiceModel.EndpointAddress(LoadVCCAPIUrl(DataContext))

            RTMCServicev2 = New AdvantageFramework.RTMCService.RTMCServiceClient(WSHttpBinding, EndpointAddress)

            If LoadVCCUseSystemWideAccount(DataContext) Then

                RTMCServicev2.ClientCredentials.UserName.UserName = LoadSystemWideVCCUserName(DataContext)
                RTMCServicev2.ClientCredentials.UserName.Password = LoadSystemWideVCCPassword(DataContext)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                End Using

                If Employee IsNot Nothing Then

                    RTMCServicev2.ClientCredentials.UserName.UserName = Employee.VCCUserName
                    RTMCServicev2.ClientCredentials.UserName.Password = Employee.VCCPassword

                End If

            End If

            CreateRTMCService = RTMCServicev2

        End Function
        Public Function CreateVCCCreditCard(Session As AdvantageFramework.Security.Session, MediaManagerGeneratePurchaseOrderVendorContacts As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact),
                                            NumberOfUses As Integer) As Boolean

            Dim VCCCardsCreated As Boolean = False
            Dim VCCProviderID As Short = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                VCCProviderID = AdvantageFramework.VCC.LoadVCCProvider(DataContext)

            End Using

            If VCCProviderID = AdvantageFramework.VCC.VCCProviders.EFS Then

                VCCCardsCreated = CreateVCCCreditCardEFS(Session, MediaManagerGeneratePurchaseOrderVendorContacts, NumberOfUses)

                'ElseIf VCCProviderID = AdvantageFramework.VCC.VCCProviders.CSI Then

                '    VCCCardsCreated = CreateVCCCreditCardCSI(Session, GenerateOrders, NumberOfUses)

            End If

            CreateVCCCreditCard = VCCCardsCreated

        End Function
        Public Function CreateVCCCreditCard(Session As AdvantageFramework.Security.Session, GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder),
                                            NumberOfUses As Integer) As Boolean

            Dim VCCCardsCreated As Boolean = False
            Dim VCCProviderID As Short = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                VCCProviderID = AdvantageFramework.VCC.LoadVCCProvider(DataContext)

            End Using

            If VCCProviderID = AdvantageFramework.VCC.VCCProviders.EFS Then

                VCCCardsCreated = CreateVCCCreditCardEFS(Session, GenerateOrders, NumberOfUses)

            ElseIf VCCProviderID = AdvantageFramework.VCC.VCCProviders.CSI Then

                VCCCardsCreated = CreateVCCCreditCardCSI(Session, GenerateOrders, NumberOfUses)

            End If

            CreateVCCCreditCard = VCCCardsCreated

        End Function
        Private Function CreateVCCCreditCardEFS(Session As AdvantageFramework.Security.Session, GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder),
                                                NumberOfUses As Integer) As Boolean

            'objects
            Dim RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing
            Dim VirtualCardCreateRequestTransactionEntity As AdvantageFramework.RTMCService.VirtualCardCreateRequestTransactionEntity = Nothing
            Dim VirtualCardCreateRequestTransactionEntities As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardCreateRequestTransactionEntity) = Nothing
            Dim VCCCardsCreated As Boolean = False
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing
            Dim VirtualCardCreateResponseTransactionEntities As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardCreateResponseTransactionEntity) = Nothing
            Dim CardAmount As Decimal = 0
            Dim ErrorMessage As String = ""
            Dim GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder = Nothing
            Dim TotalPages As Integer = 0
            Dim PageIndex As Integer = 0
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim CompanyID As String = ""
            Dim VCCCardDetail As AdvantageFramework.Database.Entities.VCCCardDetail = Nothing

            If IsVCCServiceSetup(Session) Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    RTMCServicev2 = CreateRTMCService(Session, DataContext)
                    AccountID = LoadAccountID(DataContext)
                    OutsourceID = LoadOutsourceID(DataContext)

                    VirtualCardCreateResponseTransactionEntities = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardCreateResponseTransactionEntity)

                    Try

                        TotalPages = Math.Ceiling(GenerateOrders.Count / 10)

                    Catch ex As Exception
                        TotalPages = 1
                    End Try

                    For PageIndex = 0 To TotalPages Step 1

                        VirtualCardCreateRequestTransactionEntities = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardCreateRequestTransactionEntity)

                        For Each GenerateOrder In GenerateOrders.Skip(PageIndex * 10).Take(10)

                            Try

                                CardAmount = 0

                                If GenerateOrder.TotalCostPayableToVendor.GetValueOrDefault(0) > 0 Then

                                    CardAmount = GenerateOrder.TotalCostPayableToVendor.GetValueOrDefault(0)

                                ElseIf GenerateOrder.VCCLimit.GetValueOrDefault(0) > 0 Then

                                    CardAmount = GenerateOrder.VCCLimit.GetValueOrDefault(0)

                                End If

                                If CardAmount > 0 Then

                                    VirtualCardCreateRequestTransactionEntity = New AdvantageFramework.RTMCService.VirtualCardCreateRequestTransactionEntity
                                    VirtualCardCreateRequestTransactionEntity.accountNumberField = AccountID
                                    VirtualCardCreateRequestTransactionEntity.outsourceIDField = OutsourceID
                                    VirtualCardCreateRequestTransactionEntity.transactionIDField = AdvantageFramework.StringUtilities.PadWithCharacter(GenerateOrder.OrderNumber, 15, "0", True, True) & AdvantageFramework.StringUtilities.PadWithCharacter(GenerateOrder.LineNumber, 4, "0", True, True)
                                    VirtualCardCreateRequestTransactionEntity.dollarAmountField = CardAmount
                                    VirtualCardCreateRequestTransactionEntity.virtualCardMCMGField = New RTMCService.VirtualCardMCMGFields() {}
                                    VirtualCardCreateRequestTransactionEntity.numberOfUsesField = NumberOfUses
                                    VirtualCardCreateRequestTransactionEntity.regionField = "NAM"
                                    VirtualCardCreateRequestTransactionEntity.validThroughDateField = Now.AddDays(179).ToString("yyyyMMdd")
                                    VirtualCardCreateRequestTransactionEntity.virtualCardOptionalFieldsField = New RTMCService.VirtualCardOptionalFields
                                    VirtualCardCreateRequestTransactionEntity.virtualCardOptionalFieldsField.customField1Field = GenerateOrder.VendorCode
                                    VirtualCardCreateRequestTransactionEntity.virtualCardOptionalFieldsField.customField2Field = GenerateOrder.OrderNumber
                                    VirtualCardCreateRequestTransactionEntity.virtualCardOptionalFieldsField.customField3Field = GenerateOrder.LineNumber
                                    VirtualCardCreateRequestTransactionEntity.virtualCardOptionalFieldsField.pONumberField = GenerateOrder.OrderNumber.ToString & "/" & GenerateOrder.LineNumber.ToString

                                    VirtualCardCreateRequestTransactionEntities.Add(VirtualCardCreateRequestTransactionEntity)

                                End If

                            Catch ex As Exception

                                GenerateOrder.Status = False
                                GenerateOrder.OrderMessage = "Failed to connect to VCC for card creation."

                            End Try

                        Next

                        If VirtualCardCreateRequestTransactionEntities.Count > 0 Then

                            VirtualCardCreateResponseTransactionEntities.AddRange(RTMCServicev2.VirtualCardCreate(VirtualCardCreateRequestTransactionEntities.ToArray))

                        End If

                    Next

                End Using

                If VirtualCardCreateResponseTransactionEntities IsNot Nothing AndAlso VirtualCardCreateResponseTransactionEntities.Count > 0 Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            For Each VirtualCardCreateResponseTransactionEntity In VirtualCardCreateResponseTransactionEntities

                                Try

                                    GenerateOrder = GenerateOrders.SingleOrDefault(Function(Entity) AdvantageFramework.StringUtilities.PadWithCharacter(Entity.OrderNumber, 15, "0", True, True) & AdvantageFramework.StringUtilities.PadWithCharacter(Entity.LineNumber, 4, "0", True, True) = VirtualCardCreateResponseTransactionEntity.transactionIDField)

                                Catch ex As Exception
                                    GenerateOrder = Nothing
                                End Try

                                If GenerateOrder IsNot Nothing Then

                                    If VirtualCardCreateResponseTransactionEntity.messageSetField IsNot Nothing AndAlso
                                            VirtualCardCreateResponseTransactionEntity.messageSetField.Any(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg) = False Then

                                        CardAmount = 0

                                        If GenerateOrder.TotalCostPayableToVendor.GetValueOrDefault(0) > 0 Then

                                            CardAmount = GenerateOrder.TotalCostPayableToVendor.GetValueOrDefault(0)

                                        ElseIf GenerateOrder.VCCLimit.GetValueOrDefault(0) > 0 Then

                                            CardAmount = GenerateOrder.VCCLimit.GetValueOrDefault(0)

                                        End If

                                        VCCCard = New AdvantageFramework.Database.Entities.VCCCard

                                        VCCCard.VCCProviderID = VCCProviders.EFS
                                        VCCCard.CardNumber = AdvantageFramework.Security.Encryption.ASCIIEncoding(VirtualCardCreateResponseTransactionEntity.virtualMasterCardNumberField)
                                        VCCCard.CVCCode = AdvantageFramework.Security.Encryption.ASCIIEncoding(VirtualCardCreateResponseTransactionEntity.cVCField.ToString.PadLeft(3, "0"))
                                        VCCCard.CardAmount = CardAmount
                                        VCCCard.NumberOfUses = NumberOfUses
                                        VCCCard.ExpirationDate = CDate(Now.AddDays(179).ToShortDateString)  'VirtualCardCreateResponseTransactionEntity.expirationDateField.Substring(0, 2) & "/" & My.Application.Culture.Calendar.GetDaysInMonth(VirtualCardCreateResponseTransactionEntity.expirationDateField.Substring(3, 2), VirtualCardCreateResponseTransactionEntity.expirationDateField.Substring(0, 2)) & "/" & VirtualCardCreateResponseTransactionEntity.expirationDateField.Substring(3, 2)
                                        VCCCard.OrderNumber = GenerateOrder.OrderNumber
                                        VCCCard.LineNumber = GenerateOrder.LineNumber
                                        VCCCard.Status = "A"
                                        VCCCard.CreatedByUserCode = Session.UserCode
                                        VCCCard.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                        VCCCard.CardCTS = VirtualCardCreateResponseTransactionEntity.vcCardCTSField

                                        AdvantageFramework.Database.Procedures.VCCCard.Insert(DbContext, VCCCard, Nothing)

                                        GenerateOrder.SetVCCCard(VCCCard)

                                        VCCCardDetail = New AdvantageFramework.Database.Entities.VCCCardDetail
                                        VCCCardDetail.DbContext = DbContext

                                        VCCCardDetail.ID = VCCCard.ID
                                        VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.CreditCardRequest
                                        VCCCardDetail.Amount = VCCCard.CardAmount
                                        VCCCardDetail.CreatedByUserCode = Session.UserCode
                                        VCCCardDetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                        VCCCardDetail.ProcessDateTime = VCCCardDetail.CreatedDate

                                        AdvantageFramework.Database.Procedures.VCCCardDetail.Insert(DbContext, VCCCardDetail, Nothing)

                                    Else

                                        Try

                                            ErrorMessage = VirtualCardCreateResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                                        Catch ex As Exception

                                        End Try

                                        GenerateOrder.Status = False
                                        GenerateOrder.OrderMessage = "Failed to generate VCC from provider."

                                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                            GenerateOrder.OrderMessage &= System.Environment.NewLine & System.Environment.NewLine & ErrorMessage

                                        End If

                                    End If

                                End If

                            Next

                        End Using

                        VCCCardsCreated = True

                    Catch ex As Exception

                        VCCCardsCreated = False

                        For Each GenerateOrder In GenerateOrders

                            GenerateOrder.Status = False
                            GenerateOrder.OrderMessage = "Failed to saving data from VCC to Advantage."

                        Next

                    End Try

                End If

            Else

                For Each GenerateOrder In GenerateOrders

                    GenerateOrder.Status = False
                    GenerateOrder.OrderMessage = "VCC setting are not configured correctly."

                Next

            End If

            CreateVCCCreditCardEFS = VCCCardsCreated

        End Function
        Private Function CreateVCCCreditCardEFS(Session As AdvantageFramework.Security.Session, MediaManagerGeneratePurchaseOrderVendorContacts As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact),
                                                NumberOfUses As Integer) As Boolean

            'objects
            Dim RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing
            Dim VirtualCardCreateRequestTransactionEntity As AdvantageFramework.RTMCService.VirtualCardCreateRequestTransactionEntity = Nothing
            Dim VirtualCardCreateRequestTransactionEntities As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardCreateRequestTransactionEntity) = Nothing
            Dim VCCCardsCreated As Boolean = False
            Dim VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO = Nothing
            Dim VirtualCardCreateResponseTransactionEntities As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardCreateResponseTransactionEntity) = Nothing
            Dim CardAmount As Decimal = 0
            Dim ErrorMessage As String = ""
            Dim MediaManagerGeneratePurchaseOrderVendorContact As AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact = Nothing
            Dim TotalPages As Integer = 0
            Dim PageIndex As Integer = 0
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim CompanyID As String = ""
            Dim VCCCardPODetail As AdvantageFramework.Database.Entities.VCCCardPODetail = Nothing

            If IsVCCServiceSetup(Session) Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    RTMCServicev2 = CreateRTMCService(Session, DataContext)
                    AccountID = LoadAccountID(DataContext)
                    OutsourceID = LoadOutsourceID(DataContext)

                    VirtualCardCreateResponseTransactionEntities = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardCreateResponseTransactionEntity)

                    Try

                        TotalPages = Math.Ceiling(MediaManagerGeneratePurchaseOrderVendorContacts.Count / 10)

                    Catch ex As Exception
                        TotalPages = 1
                    End Try

                    For PageIndex = 0 To TotalPages Step 1

                        VirtualCardCreateRequestTransactionEntities = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardCreateRequestTransactionEntity)

                        For Each MediaManagerGeneratePurchaseOrderVendorContact In MediaManagerGeneratePurchaseOrderVendorContacts.Skip(PageIndex * 10).Take(10)

                            Try

                                CardAmount = MediaManagerGeneratePurchaseOrderVendorContact.POAmount

                                If CardAmount > 0 Then

                                    VirtualCardCreateRequestTransactionEntity = New AdvantageFramework.RTMCService.VirtualCardCreateRequestTransactionEntity
                                    VirtualCardCreateRequestTransactionEntity.accountNumberField = AccountID
                                    VirtualCardCreateRequestTransactionEntity.outsourceIDField = OutsourceID
                                    VirtualCardCreateRequestTransactionEntity.transactionIDField = AdvantageFramework.StringUtilities.PadWithCharacter(MediaManagerGeneratePurchaseOrderVendorContact.PONumber, 19, "0", True, True)
                                    VirtualCardCreateRequestTransactionEntity.dollarAmountField = CardAmount
                                    VirtualCardCreateRequestTransactionEntity.virtualCardMCMGField = New RTMCService.VirtualCardMCMGFields() {}
                                    VirtualCardCreateRequestTransactionEntity.numberOfUsesField = NumberOfUses
                                    VirtualCardCreateRequestTransactionEntity.regionField = "NAM"
                                    VirtualCardCreateRequestTransactionEntity.validThroughDateField = Now.AddDays(179).ToString("yyyyMMdd")
                                    VirtualCardCreateRequestTransactionEntity.virtualCardOptionalFieldsField = New RTMCService.VirtualCardOptionalFields
                                    VirtualCardCreateRequestTransactionEntity.virtualCardOptionalFieldsField.customField1Field = MediaManagerGeneratePurchaseOrderVendorContact.VendorCode
                                    VirtualCardCreateRequestTransactionEntity.virtualCardOptionalFieldsField.pONumberField = MediaManagerGeneratePurchaseOrderVendorContact.PONumber.ToString

                                    VirtualCardCreateRequestTransactionEntities.Add(VirtualCardCreateRequestTransactionEntity)

                                End If

                            Catch ex As Exception

                                MediaManagerGeneratePurchaseOrderVendorContact.OrderMessage = "Failed to connect to VCC for card creation."

                            End Try

                        Next

                        If VirtualCardCreateRequestTransactionEntities.Count > 0 Then

                            VirtualCardCreateResponseTransactionEntities.AddRange(RTMCServicev2.VirtualCardCreate(VirtualCardCreateRequestTransactionEntities.ToArray))

                        End If

                    Next

                End Using

                If VirtualCardCreateResponseTransactionEntities IsNot Nothing AndAlso VirtualCardCreateResponseTransactionEntities.Count > 0 Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            For Each VirtualCardCreateResponseTransactionEntity In VirtualCardCreateResponseTransactionEntities

                                Try

                                    MediaManagerGeneratePurchaseOrderVendorContact = MediaManagerGeneratePurchaseOrderVendorContacts.SingleOrDefault(Function(Entity) AdvantageFramework.StringUtilities.PadWithCharacter(Entity.PONumber, 19, "0", True, True) = VirtualCardCreateResponseTransactionEntity.transactionIDField)

                                Catch ex As Exception
                                    MediaManagerGeneratePurchaseOrderVendorContact = Nothing
                                End Try

                                If MediaManagerGeneratePurchaseOrderVendorContact IsNot Nothing Then

                                    If VirtualCardCreateResponseTransactionEntity.messageSetField IsNot Nothing AndAlso
                                            VirtualCardCreateResponseTransactionEntity.messageSetField.Any(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg) = False Then

                                        CardAmount = MediaManagerGeneratePurchaseOrderVendorContact.POAmount

                                        VCCCardPO = New AdvantageFramework.Database.Entities.VCCCardPO

                                        VCCCardPO.VCCProviderID = VCCProviders.EFS
                                        VCCCardPO.CardNumber = AdvantageFramework.Security.Encryption.ASCIIEncoding(VirtualCardCreateResponseTransactionEntity.virtualMasterCardNumberField)
                                        VCCCardPO.CVCCode = AdvantageFramework.Security.Encryption.ASCIIEncoding(VirtualCardCreateResponseTransactionEntity.cVCField.ToString.PadLeft(3, "0"))
                                        VCCCardPO.CardAmount = CardAmount
                                        VCCCardPO.NumberOfUses = NumberOfUses
                                        VCCCardPO.ExpirationDate = CDate(Now.AddDays(179).ToShortDateString)  ' VirtualCardCreateResponseTransactionEntity.expirationDateField.Substring(0, 2) & "/" & My.Application.Culture.Calendar.GetDaysInMonth(VirtualCardCreateResponseTransactionEntity.expirationDateField.Substring(3, 2), VirtualCardCreateResponseTransactionEntity.expirationDateField.Substring(0, 2)) & "/" & VirtualCardCreateResponseTransactionEntity.expirationDateField.Substring(3, 2)
                                        VCCCardPO.PONumber = MediaManagerGeneratePurchaseOrderVendorContact.PONumber
                                        VCCCardPO.Status = "A"
                                        VCCCardPO.CreatedByUserCode = Session.UserCode
                                        VCCCardPO.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                        VCCCardPO.CardCTS = VirtualCardCreateResponseTransactionEntity.vcCardCTSField

                                        AdvantageFramework.Database.Procedures.VCCCardPO.Insert(DbContext, VCCCardPO, Nothing)

                                        'MediaManagerGeneratePurchaseOrderVendorContact.SetVCCCard(VCCCard)

                                        VCCCardPODetail = New AdvantageFramework.Database.Entities.VCCCardPODetail
                                        VCCCardPODetail.DbContext = DbContext

                                        VCCCardPODetail.VCCCardPOID = VCCCardPO.ID
                                        VCCCardPODetail.Action = AdvantageFramework.Database.Entities.VCCAction.CreditCardRequest
                                        VCCCardPODetail.Amount = VCCCardPO.CardAmount
                                        VCCCardPODetail.CreatedByUserCode = Session.UserCode
                                        VCCCardPODetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                        VCCCardPODetail.ProcessDateTime = VCCCardPODetail.CreatedDate

                                        AdvantageFramework.Database.Procedures.VCCCardPODetail.Insert(DbContext, VCCCardPODetail, Nothing)

                                    Else

                                        Try

                                            ErrorMessage = VirtualCardCreateResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                                        Catch ex As Exception

                                        End Try

                                        MediaManagerGeneratePurchaseOrderVendorContact.OrderMessage = "Failed to generate VCC from provider."

                                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                            MediaManagerGeneratePurchaseOrderVendorContact.OrderMessage &= System.Environment.NewLine & System.Environment.NewLine & ErrorMessage

                                        End If

                                    End If

                                End If

                            Next

                        End Using

                        VCCCardsCreated = True

                    Catch ex As Exception

                        VCCCardsCreated = False

                        For Each MediaManagerGeneratePurchaseOrderVendorContact In MediaManagerGeneratePurchaseOrderVendorContacts

                            MediaManagerGeneratePurchaseOrderVendorContact.OrderMessage = "Failed to saving data from VCC to Advantage."

                        Next

                    End Try

                End If

            Else

                For Each MediaManagerGeneratePurchaseOrderVendorContact In MediaManagerGeneratePurchaseOrderVendorContacts

                    MediaManagerGeneratePurchaseOrderVendorContact.OrderMessage = "VCC setting are not configured correctly."

                Next

            End If

            CreateVCCCreditCardEFS = VCCCardsCreated

        End Function
        Private Sub GetVCCInquiryData(RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient, DataContext As AdvantageFramework.Database.DataContext,
                                      VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder))

            'objects
            Dim Requests As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardInquireRequestTransactionEntity) = Nothing
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim VirtualCardInquireRequestTransactionEntity As AdvantageFramework.RTMCService.VirtualCardInquireRequestTransactionEntity = Nothing
            Dim VirtualCardInquireResponseTransactionEntities As Generic.List(Of RTMCService.VirtualCardInquireResponseTransactionEntity) = Nothing
            Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing
            Dim TotalPages As Integer = 0
            Dim PageIndex As Integer = 0

            If RTMCServicev2 IsNot Nothing AndAlso DataContext IsNot Nothing AndAlso VCCOrders IsNot Nothing AndAlso VCCOrders.Count > 0 Then

                AccountID = LoadAccountID(DataContext)
                OutsourceID = LoadOutsourceID(DataContext)

                Try

                    VirtualCardInquireResponseTransactionEntities = New Generic.List(Of RTMCService.VirtualCardInquireResponseTransactionEntity)

                    Try

                        TotalPages = Math.Ceiling(VCCOrders.Count / 10)

                    Catch ex As Exception
                        TotalPages = 1
                    End Try

                    For PageIndex = 0 To TotalPages Step 1

                        Requests = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardInquireRequestTransactionEntity)

                        For Each VCCOrder In VCCOrders.Skip(PageIndex * 10).Take(10)

                            VirtualCardInquireRequestTransactionEntity = New AdvantageFramework.RTMCService.VirtualCardInquireRequestTransactionEntity

                            VirtualCardInquireRequestTransactionEntity.accountNumberField = AccountID
                            VirtualCardInquireRequestTransactionEntity.outsourceIDField = OutsourceID
                            VirtualCardInquireRequestTransactionEntity.transactionIDField = VCCOrder.TransactionIDField
                            VirtualCardInquireRequestTransactionEntity.virtualMasterCardNumberField = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCOrder.GetVCCCardEntity.CardNumber)

                            Requests.Add(VirtualCardInquireRequestTransactionEntity)

                        Next

                        If Requests.Count > 0 Then

                            VirtualCardInquireResponseTransactionEntities.AddRange(RTMCServicev2.VirtualCardInquire(Requests.ToArray))

                            'Dim mySerializer = New System.Xml.Serialization.XmlSerializer(Requests.GetType)
                            'Dim myWriter = New System.IO.StreamWriter("C:\EFS_cardinquire_request.xml")
                            'mySerializer.Serialize(myWriter, Requests)
                            'myWriter.Close()

                        End If

                    Next

                    If VirtualCardInquireResponseTransactionEntities IsNot Nothing AndAlso VirtualCardInquireResponseTransactionEntities.Count > 0 Then

                        'Dim mySerializer As New System.Xml.Serialization.XmlSerializer(VirtualCardInquireResponseTransactionEntities.GetType)
                        'Dim myWriter As System.IO.StreamWriter = New System.IO.StreamWriter("C:\EFS_cardinquire_response.xml")
                        'mySerializer.Serialize(myWriter, VirtualCardInquireResponseTransactionEntities)
                        'myWriter.Close()

                        For Each VirtualCardInquireResponseTransactionEntity In VirtualCardInquireResponseTransactionEntities

                            Try

                                VCCOrder = VCCOrders.SingleOrDefault(Function(Entity) Entity.TransactionIDField = VirtualCardInquireResponseTransactionEntity.transactionIDField)

                            Catch ex As Exception
                                VCCOrder = Nothing
                            End Try

                            If VCCOrder IsNot Nothing Then

                                If VirtualCardInquireResponseTransactionEntity.responseCodeField = 0 AndAlso VirtualCardInquireResponseTransactionEntity.messageSetField IsNot Nothing Then

                                    For Each SetField In VirtualCardInquireResponseTransactionEntity.messageSetField

                                        VCCOrder.GetVCCCardEntity.Status = VirtualCardInquireResponseTransactionEntity.statusField
                                        VCCOrder.GetVCCCardEntity.CardAmount = VirtualCardInquireResponseTransactionEntity.dollarAmountField

                                    Next

                                Else

                                    Try

                                        VCCOrder.EFSMessage = VirtualCardInquireResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                                    Catch ex As Exception
                                        VCCOrder.EFSMessage = "Error retrieving card inquery."
                                    End Try

                                End If

                            End If

                        Next

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        'Private Sub GetVCCData(Session As AdvantageFramework.Security.Session, VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder))

        '    'objects
        '    Dim RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing

        '    If IsVCCServiceSetup(Session) Then

        '        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

        '            RTMCServicev2 = CreateRTMCService(Session, DataContext)

        '            GetVCCInquiryData(RTMCServicev2, Session, DataContext, VCCOrders)
        '            GetVCCActivityData(RTMCServicev2, Session, DataContext, VCCOrders)

        '        End Using

        '    End If

        'End Sub
        'Private Sub GetVCCActivityData(RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient, Session As AdvantageFramework.Security.Session,
        '                               DataContext As AdvantageFramework.Database.DataContext, VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder))

        '    'objects
        '    Dim Requests As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardActivityRequestTransactionEntity) = Nothing
        '    Dim VirtualCardActivityRequestTransactionEntity As AdvantageFramework.RTMCService.VirtualCardActivityRequestTransactionEntity = Nothing
        '    Dim VirtualCardActivityResponseTransactionEntity As RTMCService.VirtualCardActivityResponseTransactionEntity = Nothing
        '    Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing
        '    Dim Count As Integer = 0

        '    Try

        '        Requests = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardActivityRequestTransactionEntity)

        '        For Each VCCOrder In VCCOrders

        '            VirtualCardActivityRequestTransactionEntity = New AdvantageFramework.RTMCService.VirtualCardActivityRequestTransactionEntity

        '            VirtualCardActivityRequestTransactionEntity.accountNumberField = LoadAccountID(DataContext)
        '            VirtualCardActivityRequestTransactionEntity.outsourceIDField = LoadOutsourceID(DataContext)
        '            VirtualCardActivityRequestTransactionEntity.transactionIDField = AdvantageFramework.StringUtilities.PadWithCharacter(VCCOrder.GetVCCCardEntity.ID, 19, "0", True, True)
        '            VirtualCardActivityRequestTransactionEntity.virtualMasterCardNumberField = AdvantageFramework.StringUtilities.Decrypt(VCCOrder.GetVCCCardEntity.CardNumber)

        '            Requests.Add(VirtualCardActivityRequestTransactionEntity)

        '        Next

        '        For Each VirtualCardActivityResponseTransactionEntity In RTMCServicev2.VirtualCardActivity(Requests.ToArray)

        '            Try

        '                VCCOrder = VCCOrders.SingleOrDefault(Function(Entity) Entity.GetVCCCardEntity.ID = VirtualCardActivityResponseTransactionEntity.transactionIDField)

        '            Catch ex As Exception
        '                VCCOrder = Nothing
        '            End Try

        '            If VCCOrder IsNot Nothing Then

        '                ' VCCOrder.AddVCCActivity(VirtualCardActivityResponseTransactionEntity)

        '            End If

        '        Next

        '    Catch ex As Exception

        '    End Try

        'End Sub
        Private Function TestServiceConnection(RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim TestWasSuccesful As Boolean = False
            Dim RTMCVersion As String = ""

            Try

                If RTMCServicev2 IsNot Nothing Then

                    If System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.SystemDefault OrElse
                            System.Net.ServicePointManager.SecurityProtocol = (Net.SecurityProtocolType.Ssl3 Or Net.SecurityProtocolType.Tls) Then

                        System.Net.ServicePointManager.SecurityProtocol = (Net.SecurityProtocolType.Ssl3 Or Net.SecurityProtocolType.Tls Or Net.SecurityProtocolType.Tls11 Or Net.SecurityProtocolType.Tls12)

                    End If

                    RTMCVersion = RTMCServicev2.GetVersion()

                    If String.IsNullOrWhiteSpace(RTMCVersion) = False Then

                        TestWasSuccesful = True

                    Else

                        ErrorMessage = "Service failed to send any info back."

                    End If

                Else

                    ErrorMessage = "Service failed to create."

                End If

            Catch ex As Exception
                TestWasSuccesful = False
                ErrorMessage = "TestServiceConnection:" & System.Environment.NewLine & ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            End Try

            TestServiceConnection = TestWasSuccesful

        End Function
        Public Function RefreshVCCData(Session As AdvantageFramework.Security.Session, VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder),
                                       ByRef ErrorMessage As String) As Boolean

            'objects
            Dim RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing
            Dim UpdatedVCCCards As Boolean = False
            Dim UpdateDate As Date = Date.MinValue
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Token As String = Nothing
            Dim URL As String = Nothing
            'Dim CSTTimeZoneInfo As TimeZoneInfo = Nothing
            Dim CentralDateTime As Date = Nothing
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing
            Dim CSTHoursOffset As Decimal = 0
            Dim SQLHoursOffset As Decimal = 0
            Dim OffSetHours As Decimal = 0
            Dim VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO = Nothing
            Dim ProcessVCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing

            Try

                CSTHoursOffset = AdvantageFramework.Database.Procedures.Generic.GetOffsetFromSystemTimeZone("Central Standard Time")

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SQLHoursOffset = AdvantageFramework.Database.Procedures.Generic.LoadSQLHoursOffset(DbContext)

                End Using

                OffSetHours = (CSTHoursOffset - SQLHoursOffset) * -1

            Catch ex As Exception
                ErrorMessage = ex.Message
            End Try

            If String.IsNullOrWhiteSpace(ErrorMessage) AndAlso IsVCCServiceSetup(Session, ErrorMessage) Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    UpdateDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DataContext)

                    If AdvantageFramework.VCC.LoadVCCProvider(DataContext) = AdvantageFramework.VCC.VCCProviders.EFS Then

                        RTMCServicev2 = CreateRTMCService(Session, DataContext)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Try

                                GetVCCInquiryData(RTMCServicev2, DataContext, VCCOrders)

                                ProcessVCCOrders = VCCOrders.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.EFSMessage)).ToList

                                CentralDateTime = AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(OffSetHours * -1, UpdateDate)

                                GetPendingTransactionsData(RTMCServicev2, DataContext, ProcessVCCOrders, CentralDateTime, DbContext, Session.EmployeeName, OffSetHours)
                                GetRejectedTransactionsData(RTMCServicev2, DataContext, ProcessVCCOrders, CentralDateTime, DbContext, OffSetHours)
                                GetClearedTransactionsData(RTMCServicev2, DataContext, ProcessVCCOrders, CentralDateTime, DbContext, OffSetHours)

                                For Each VCCOrder In ProcessVCCOrders

                                    If VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder Then

                                        VCCCard = DbContext.VCCCards.Find(VCCOrder.GetVCCCardEntity.ID)

                                        VCCCard.LastRefreshedDate = UpdateDate

                                        DbContext.Entry(VCCCard).State = Entity.EntityState.Modified

                                    Else

                                        VCCCardPO = DbContext.VCCCardPOs.Find(VCCOrder.GetVCCCardEntity.ID)

                                        VCCCardPO.LastRefreshedDate = UpdateDate

                                        DbContext.Entry(VCCCardPO).State = Entity.EntityState.Modified

                                    End If

                                Next

                                DbContext.SaveChanges()

                                UpdatedVCCCards = True

                                For Each VCCOrder In VCCOrders.Where(Function(Entity) Not String.IsNullOrWhiteSpace(Entity.EFSMessage))

                                    ErrorMessage += VCCOrder.CardNumberCVCCode & Space(1) & VCCOrder.EFSMessage & vbCrLf

                                Next

                            Catch ex As Exception
                                ErrorMessage = ex.Message & vbCrLf & ex.InnerException.ToString
                                UpdatedVCCCards = False
                            End Try

                        End Using

                    ElseIf AdvantageFramework.VCC.LoadVCCProvider(DataContext) = AdvantageFramework.VCC.VCCProviders.CSI Then

                        If CreateToken(Session, DataContext, Token, URL) Then

                            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                For Each VCCOrder In VCCOrders

                                    GetCardActivity(DbContext, URL, Token, VCCOrder.GetVCCCardEntity)

                                Next

                            End Using

                            DeleteToken(URL, Token)

                            UpdatedVCCCards = True

                        End If

                    End If

                End Using

            Else

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    ErrorMessage = "Failed trying to connect to VCC service.  Please check all your VCC settings."

                Else

                    ErrorMessage = "Failed trying to connect to VCC service.  Please check all your VCC settings." & System.Environment.NewLine & ErrorMessage

                End If

            End If

            RefreshVCCData = UpdatedVCCCards

        End Function
        Private Function GetClearedTransactionsData(RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient, DataContext As AdvantageFramework.Database.DataContext,
                                                    VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder),
                                                    TransactionEndDate As Date, DbContext As AdvantageFramework.Database.DbContext,
                                                    OffSetHours As Decimal) As Boolean

            'objects
            Dim Requests As Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity) = Nothing
            Dim TransactionDeliveryClearedRequestTransactionEntity As AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity = Nothing
            Dim TransactionDeliveryClearedResponseTransactionEntities As Generic.List(Of RTMCService.TransactionDeliveryClearedResponseTransactionEntity) = Nothing
            Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing
            Dim Count As Integer = 0
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim CompanyID As String = ""
            Dim DataWasRetrieved As Boolean = True
            Dim VCCCardDetail As AdvantageFramework.Database.Entities.VCCCardDetail = Nothing
            Dim ProcessDateTime As Date = Nothing
            Dim ErrorMessage As String = ""
            Dim TotalPages As Integer = 0
            Dim PageIndex As Integer = 0
            Dim TransactionStartDate As Date = Nothing
            Dim VCCCardPODetail As AdvantageFramework.Database.Entities.VCCCardPODetail = Nothing

            If RTMCServicev2 IsNot Nothing AndAlso DataContext IsNot Nothing AndAlso VCCOrders IsNot Nothing AndAlso VCCOrders.Count > 0 Then

                Try

                    AccountID = LoadAccountID(DataContext)
                    OutsourceID = LoadOutsourceID(DataContext)
                    CompanyID = LoadCompanyID(DataContext)

                    TransactionDeliveryClearedResponseTransactionEntities = New Generic.List(Of RTMCService.TransactionDeliveryClearedResponseTransactionEntity)

                    Try

                        TotalPages = Math.Ceiling(VCCOrders.Count / 10)

                    Catch ex As Exception
                        TotalPages = 1
                    End Try

                    For PageIndex = 0 To TotalPages Step 1

                        Requests = New Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity)

                        For Each VCCOrder In VCCOrders.Skip(PageIndex * 10).Take(10)

                            TransactionDeliveryClearedRequestTransactionEntity = New AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity

                            TransactionDeliveryClearedRequestTransactionEntity.accountNumberField = AccountID
                            TransactionDeliveryClearedRequestTransactionEntity.cardGroupField = -1
                            TransactionDeliveryClearedRequestTransactionEntity.companyNumberField = CompanyID
                            TransactionDeliveryClearedRequestTransactionEntity.outsourceIDField = OutsourceID
                            TransactionDeliveryClearedRequestTransactionEntity.transactionIDField = VCCOrder.TransactionIDField

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField = New RTMCService.TransactionDeliveryKeyFields
                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.cardNumberField = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCOrder.GetVCCCardEntity.CardNumber)

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.lastReceivedField = New RTMCService.TransactionDeliveryLastReceived

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.numberOfTransactionsRequestedField = 1000

                            If VCCOrder.GetVCCCardEntity.LastRefreshedDate IsNot Nothing Then

                                TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionEndDateField = TransactionEndDate.ToString("yyyyMMdd")
                                TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionEndTimeField = TransactionEndDate.ToString("HHmmssff")

                                TransactionStartDate = AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(OffSetHours * -1, VCCOrder.GetVCCCardEntity.LastRefreshedDate.Value.AddDays(-7))

                                TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionStartDateField = TransactionStartDate.ToString("yyyyMMdd")
                                TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionStartTimeField = TransactionStartDate.ToString("HHmmssff")

                            Else

                                TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionEndDateField = TransactionEndDate.ToString("yyyyMMdd")
                                TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionEndTimeField = TransactionEndDate.ToString("HHmmssff")

                                TransactionStartDate = AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(OffSetHours * -1, VCCOrder.GetVCCCardEntity.CreatedDate)

                                TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionStartDateField = TransactionStartDate.ToString("yyyyMMdd")
                                TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionStartTimeField = -1

                            End If

                            'Dim mySerializer = New System.Xml.Serialization.XmlSerializer(GetType(RTMCService.TransactionDeliveryClearedRequestTransactionEntity))
                            'Dim myWriter = New System.IO.StreamWriter("C:\EFS_cardclearedrequest_request.xml")
                            'mySerializer.Serialize(myWriter, TransactionDeliveryClearedRequestTransactionEntity)
                            'myWriter.Close()

                            Requests.Add(TransactionDeliveryClearedRequestTransactionEntity)

                        Next

                        If Requests.Count > 0 Then

                            TransactionDeliveryClearedResponseTransactionEntities.AddRange(RTMCServicev2.TransactionDeliveryCleared(Requests.ToArray))

                        End If

                    Next

                    If TransactionDeliveryClearedResponseTransactionEntities IsNot Nothing AndAlso TransactionDeliveryClearedResponseTransactionEntities.Count > 0 Then

                        For Each TransactionDeliveryClearedResponseTransactionEntity In TransactionDeliveryClearedResponseTransactionEntities

                            'Dim mySerializer As New System.Xml.Serialization.XmlSerializer(GetType(RTMCService.TransactionDeliveryClearedResponseTransactionEntity))
                            'Dim myWriter As System.IO.StreamWriter = New System.IO.StreamWriter("C:\EFS_cardclearedresponse_response.xml")
                            'mySerializer.Serialize(myWriter, TransactionDeliveryClearedResponseTransactionEntity)
                            'myWriter.Close()

                            Try

                                VCCOrder = VCCOrders.SingleOrDefault(Function(Entity) Entity.TransactionIDField = TransactionDeliveryClearedResponseTransactionEntity.transactionIDField)

                            Catch ex As Exception
                                VCCOrder = Nothing
                            End Try

                            If VCCOrder IsNot Nothing Then

                                If TransactionDeliveryClearedResponseTransactionEntity.responseCodeField = 0 AndAlso TransactionDeliveryClearedResponseTransactionEntity.clearedSetField IsNot Nothing Then

                                    For Each SetField In TransactionDeliveryClearedResponseTransactionEntity.clearedSetField

                                        Try

                                            ProcessDateTime = DateTime.ParseExact(SetField.processDateField & " " & SetField.processTimeField, "yyyyMMdd HHmmssff", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None)

                                            If OffSetHours <> 0 Then

                                                ProcessDateTime = AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(OffSetHours, ProcessDateTime)

                                            End If

                                            If VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder Then

                                                VCCCardDetail = (From Entity In AdvantageFramework.Database.Procedures.VCCCardDetail.LoadByID(DbContext, VCCOrder.GetVCCCardEntity.ID)
                                                                 Where Entity.Action = AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction AndAlso
                                                                       Entity.ReferenceNumber = SetField.clearingReferenceNumberField
                                                                 Select Entity).FirstOrDefault

                                                If VCCCardDetail Is Nothing Then

                                                    VCCCardDetail = New AdvantageFramework.Database.Entities.VCCCardDetail
                                                    VCCCardDetail.DbContext = DbContext
                                                    VCCCardDetail.ID = VCCOrder.GetVCCCardEntity.ID
                                                    VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction
                                                    VCCCardDetail.CreatedByUserCode = DbContext.UserCode
                                                    VCCCardDetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DataContext)
                                                    VCCCardDetail.MerchantName = SetField.merchantNameField

                                                    VCCCardDetail.ProcessDateTime = ProcessDateTime
                                                    VCCCardDetail.ReferenceNumber = SetField.clearingReferenceNumberField
                                                    VCCCardDetail.Amount = SetField.transactionAmountField

                                                    If AdvantageFramework.Database.Procedures.VCCCardDetail.Insert(DbContext, VCCCardDetail, ErrorMessage) = False Then

                                                        Throw New Exception(ErrorMessage)

                                                    End If

                                                End If

                                            ElseIf VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.PurchaseOrder Then

                                                VCCCardPODetail = (From Entity In AdvantageFramework.Database.Procedures.VCCCardPODetail.LoadByVCCCardPOID(DbContext, VCCOrder.GetVCCCardEntity.ID)
                                                                   Where Entity.ProcessDateTime = ProcessDateTime
                                                                   Select Entity).SingleOrDefault

                                                If VCCCardPODetail Is Nothing Then

                                                    VCCCardPODetail = New AdvantageFramework.Database.Entities.VCCCardPODetail
                                                    VCCCardPODetail.DbContext = DbContext
                                                    VCCCardPODetail.VCCCardPOID = VCCOrder.GetVCCCardEntity.ID
                                                    VCCCardPODetail.Action = AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction
                                                    VCCCardPODetail.CreatedByUserCode = DbContext.UserCode
                                                    VCCCardPODetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DataContext)
                                                    VCCCardPODetail.MerchantName = SetField.merchantNameField

                                                    VCCCardPODetail.ProcessDateTime = ProcessDateTime
                                                    VCCCardPODetail.ReferenceNumber = SetField.clearingReferenceNumberField
                                                    VCCCardPODetail.Amount = SetField.transactionAmountField

                                                    If AdvantageFramework.Database.Procedures.VCCCardPODetail.Insert(DbContext, VCCCardPODetail, ErrorMessage) = False Then

                                                        Throw New Exception(ErrorMessage)

                                                    End If

                                                End If

                                            End If

                                        Catch ex As Exception
                                            ProcessDateTime = Date.MinValue
                                        End Try

                                    Next

                                Else

                                    Try

                                        ErrorMessage += TransactionDeliveryClearedResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                                    Catch ex As Exception
                                        ErrorMessage = "Error retrieving cleared transactions."
                                    End Try

                                    If ErrorMessage <> "" Then

                                        Throw New Exception(ErrorMessage)

                                    End If

                                End If

                            End If

                        Next

                    End If

                Catch ex As Exception
                    DataWasRetrieved = False
                End Try

            Else

                DataWasRetrieved = False

            End If

            GetClearedTransactionsData = DataWasRetrieved

        End Function
        Private Function GetRejectedTransactionsData(RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient, DataContext As AdvantageFramework.Database.DataContext,
                                                     VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder),
                                                     TransactionEndDate As Date, DbContext As AdvantageFramework.Database.DbContext,
                                                     OffSetHours As Decimal) As Boolean

            'objects
            Dim Requests As Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryRejectRequestTransactionEntity) = Nothing
            Dim TransactionDeliveryRejectRequestTransactionEntity As AdvantageFramework.RTMCService.TransactionDeliveryRejectRequestTransactionEntity = Nothing
            Dim TransactionDeliveryRejectResponseTransactionEntities As Generic.List(Of RTMCService.TransactionDeliveryRejectResponseTransactionEntity) = Nothing
            Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing
            Dim Count As Integer = 0
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim CompanyID As String = ""
            Dim DataWasRetrieved As Boolean = True
            Dim VCCCardDetail As AdvantageFramework.Database.Entities.VCCCardDetail = Nothing
            Dim ProcessDateTime As Date = Nothing
            Dim ErrorMessage As String = ""
            Dim TotalPages As Integer = 0
            Dim PageIndex As Integer = 0
            Dim TransactionStartDate As Date = Nothing
            Dim VCCCardPODetail As AdvantageFramework.Database.Entities.VCCCardPODetail = Nothing

            If RTMCServicev2 IsNot Nothing AndAlso DataContext IsNot Nothing AndAlso VCCOrders IsNot Nothing AndAlso VCCOrders.Count > 0 Then

                Try

                    AccountID = LoadAccountID(DataContext)
                    OutsourceID = LoadOutsourceID(DataContext)
                    CompanyID = LoadCompanyID(DataContext)

                    TransactionDeliveryRejectResponseTransactionEntities = New Generic.List(Of RTMCService.TransactionDeliveryRejectResponseTransactionEntity)

                    Try

                        TotalPages = Math.Ceiling(VCCOrders.Count / 10)

                    Catch ex As Exception
                        TotalPages = 1
                    End Try

                    For PageIndex = 0 To TotalPages Step 1

                        Requests = New Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryRejectRequestTransactionEntity)

                        For Each VCCOrder In VCCOrders.Skip(PageIndex * 10).Take(10)

                            TransactionDeliveryRejectRequestTransactionEntity = New AdvantageFramework.RTMCService.TransactionDeliveryRejectRequestTransactionEntity

                            TransactionDeliveryRejectRequestTransactionEntity.accountNumberField = AccountID
                            TransactionDeliveryRejectRequestTransactionEntity.cardGroupField = -1
                            TransactionDeliveryRejectRequestTransactionEntity.companyNumberField = CompanyID
                            TransactionDeliveryRejectRequestTransactionEntity.outsourceIDField = OutsourceID
                            TransactionDeliveryRejectRequestTransactionEntity.transactionIDField = VCCOrder.TransactionIDField

                            TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField = New RTMCService.TransactionDeliveryKeyFields
                            TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.cardNumberField = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCOrder.GetVCCCardEntity.CardNumber)

                            TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.lastReceivedField = New RTMCService.TransactionDeliveryLastReceived

                            TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.numberOfTransactionsRequestedField = 1000

                            If VCCOrder.GetVCCCardEntity.LastRefreshedDate IsNot Nothing Then

                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionEndDateField = TransactionEndDate.ToString("yyyyMMdd")
                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionEndTimeField = TransactionEndDate.ToString("HHmmssff")

                                TransactionStartDate = AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(OffSetHours * -1, VCCOrder.GetVCCCardEntity.LastRefreshedDate.Value.AddDays(-7))

                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionStartDateField = TransactionStartDate.ToString("yyyyMMdd")
                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionStartTimeField = TransactionStartDate.ToString("HHmmssff")

                            Else

                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionEndDateField = TransactionEndDate.ToString("yyyyMMdd")
                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionEndTimeField = TransactionEndDate.ToString("HHmmssff")

                                TransactionStartDate = AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(OffSetHours * -1, VCCOrder.GetVCCCardEntity.CreatedDate)

                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionStartDateField = TransactionStartDate.ToString("yyyyMMdd")
                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionStartTimeField = -1

                            End If

                            Requests.Add(TransactionDeliveryRejectRequestTransactionEntity)

                        Next

                        If Requests.Count > 0 Then

                            TransactionDeliveryRejectResponseTransactionEntities.AddRange(RTMCServicev2.TransactionDeliveryReject(Requests.ToArray))

                        End If

                    Next

                    If TransactionDeliveryRejectResponseTransactionEntities IsNot Nothing AndAlso TransactionDeliveryRejectResponseTransactionEntities.Count > 0 Then

                        For Each TransactionDeliveryRejectResponseTransactionEntity In TransactionDeliveryRejectResponseTransactionEntities

                            Try

                                VCCOrder = VCCOrders.SingleOrDefault(Function(Entity) Entity.TransactionIDField = TransactionDeliveryRejectResponseTransactionEntity.transactionIDField)

                            Catch ex As Exception
                                VCCOrder = Nothing
                            End Try

                            If VCCOrder IsNot Nothing Then

                                If TransactionDeliveryRejectResponseTransactionEntity.responseCodeField = 0 AndAlso TransactionDeliveryRejectResponseTransactionEntity.rejectsSetField IsNot Nothing Then

                                    For Each SetField In TransactionDeliveryRejectResponseTransactionEntity.rejectsSetField

                                        Try

                                            ProcessDateTime = DateTime.ParseExact(SetField.processDateField & " " & SetField.processTimeField.PadLeft(8, "0"), "yyyyMMdd HHmmssff", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None)

                                            If OffSetHours <> 0 Then

                                                ProcessDateTime = AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(OffSetHours, ProcessDateTime)

                                            End If

                                            If VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder Then

                                                VCCCardDetail = (From Entity In AdvantageFramework.Database.Procedures.VCCCardDetail.LoadByID(DbContext, VCCOrder.GetVCCCardEntity.ID)
                                                                 Where Entity.ProcessDateTime = ProcessDateTime
                                                                 Select Entity).SingleOrDefault

                                                If VCCCardDetail Is Nothing Then

                                                    VCCCardDetail = New AdvantageFramework.Database.Entities.VCCCardDetail
                                                    VCCCardDetail.DbContext = DbContext
                                                    VCCCardDetail.ID = VCCOrder.GetVCCCardEntity.ID
                                                    VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction
                                                    VCCCardDetail.CreatedByUserCode = DbContext.UserCode
                                                    VCCCardDetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DataContext)
                                                    VCCCardDetail.MerchantName = SetField.merchantNameField

                                                    VCCCardDetail.ProcessDateTime = ProcessDateTime
                                                    VCCCardDetail.RejectMessage = SetField.rejectMessageField
                                                    VCCCardDetail.Amount = SetField.transactionAmountMerchantCurrencyField

                                                    If AdvantageFramework.Database.Procedures.VCCCardDetail.Insert(DbContext, VCCCardDetail, ErrorMessage) = False Then

                                                        Throw New Exception(ErrorMessage)

                                                    End If

                                                End If

                                            ElseIf VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.PurchaseOrder Then

                                                VCCCardPODetail = (From Entity In AdvantageFramework.Database.Procedures.VCCCardPODetail.LoadByVCCCardPOID(DbContext, VCCOrder.GetVCCCardEntity.ID)
                                                                   Where Entity.ProcessDateTime = ProcessDateTime
                                                                   Select Entity).SingleOrDefault

                                                If VCCCardPODetail Is Nothing Then

                                                    VCCCardPODetail = New AdvantageFramework.Database.Entities.VCCCardPODetail
                                                    VCCCardPODetail.DbContext = DbContext
                                                    VCCCardPODetail.VCCCardPOID = VCCOrder.GetVCCCardEntity.ID
                                                    VCCCardPODetail.Action = AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction
                                                    VCCCardPODetail.CreatedByUserCode = DbContext.UserCode
                                                    VCCCardPODetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DataContext)
                                                    VCCCardPODetail.MerchantName = SetField.merchantNameField

                                                    VCCCardPODetail.ProcessDateTime = ProcessDateTime
                                                    VCCCardPODetail.RejectMessage = SetField.rejectMessageField
                                                    VCCCardPODetail.Amount = SetField.transactionAmountMerchantCurrencyField

                                                    If AdvantageFramework.Database.Procedures.VCCCardPODetail.Insert(DbContext, VCCCardPODetail, ErrorMessage) = False Then

                                                        Throw New Exception(ErrorMessage)

                                                    End If

                                                End If

                                            End If

                                        Catch ex As Exception
                                            ProcessDateTime = Date.MinValue
                                        End Try

                                    Next

                                Else

                                    Try

                                        ErrorMessage += TransactionDeliveryRejectResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                                    Catch ex As Exception
                                        ErrorMessage = "Error retrieving rejected transactions."
                                    End Try

                                    If ErrorMessage <> "" Then

                                        Throw New Exception(ErrorMessage)

                                    End If

                                End If

                            End If

                        Next

                    End If

                Catch ex As Exception
                    DataWasRetrieved = False
                End Try

            Else

                DataWasRetrieved = False

            End If

            GetRejectedTransactionsData = DataWasRetrieved

        End Function
        Private Function GetPendingTransactionsData(RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient, DataContext As AdvantageFramework.Database.DataContext,
                                                    VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder),
                                                    TransactionEndDate As Date, DbContext As AdvantageFramework.Database.DbContext,
                                                    AuthorizedByName As String,
                                                    OffSetHours As Decimal) As Boolean

            'objects
            Dim Requests As Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryMemoRequestTransactionEntity) = Nothing
            Dim TransactionDeliveryMemoRequestTransactionEntity As AdvantageFramework.RTMCService.TransactionDeliveryMemoRequestTransactionEntity = Nothing
            Dim TransactionDeliveryMemoResponseTransactionEntities As Generic.List(Of RTMCService.TransactionDeliveryMemoResponseTransactionEntity) = Nothing
            Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing
            Dim Count As Integer = 0
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim CompanyID As String = ""
            Dim DataWasRetrieved As Boolean = True
            Dim VCCCardDetail As AdvantageFramework.Database.Entities.VCCCardDetail = Nothing
            Dim ProcessDateTime As Date = Nothing
            Dim ErrorMessage As String = ""
            Dim TotalPages As Integer = 0
            Dim PageIndex As Integer = 0
            Dim TransactionStartDate As Date = Nothing
            Dim VCCCardPODetail As AdvantageFramework.Database.Entities.VCCCardPODetail = Nothing

            If RTMCServicev2 IsNot Nothing AndAlso DataContext IsNot Nothing AndAlso VCCOrders IsNot Nothing AndAlso VCCOrders.Count > 0 Then

                Try

                    AccountID = LoadAccountID(DataContext)
                    OutsourceID = LoadOutsourceID(DataContext)
                    CompanyID = LoadCompanyID(DataContext)

                    TransactionDeliveryMemoResponseTransactionEntities = New Generic.List(Of RTMCService.TransactionDeliveryMemoResponseTransactionEntity)

                    Try

                        TotalPages = Math.Ceiling(VCCOrders.Count / 10)

                    Catch ex As Exception
                        TotalPages = 1
                    End Try

                    For PageIndex = 0 To TotalPages Step 1

                        Requests = New Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryMemoRequestTransactionEntity)

                        For Each VCCOrder In VCCOrders.Skip(PageIndex * 10).Take(10)

                            TransactionDeliveryMemoRequestTransactionEntity = New AdvantageFramework.RTMCService.TransactionDeliveryMemoRequestTransactionEntity

                            TransactionDeliveryMemoRequestTransactionEntity.accountNumberField = AccountID
                            TransactionDeliveryMemoRequestTransactionEntity.cardGroupField = -1
                            TransactionDeliveryMemoRequestTransactionEntity.companyNumberField = CompanyID
                            TransactionDeliveryMemoRequestTransactionEntity.outsourceIDField = OutsourceID
                            TransactionDeliveryMemoRequestTransactionEntity.transactionIDField = VCCOrder.TransactionIDField

                            TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField = New RTMCService.TransactionDeliveryKeyFields
                            TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.cardNumberField = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCOrder.GetVCCCardEntity.CardNumber)

                            TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.lastReceivedField = New RTMCService.TransactionDeliveryLastReceived

                            TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.numberOfTransactionsRequestedField = 1000

                            If VCCOrder.GetVCCCardEntity.LastRefreshedDate IsNot Nothing Then

                                TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionEndDateField = TransactionEndDate.ToString("yyyyMMdd")
                                TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionEndTimeField = TransactionEndDate.ToString("HHmmssff")

                                TransactionStartDate = AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(OffSetHours * -1, VCCOrder.GetVCCCardEntity.LastRefreshedDate.Value.AddDays(-7))

                                TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionStartDateField = TransactionStartDate.ToString("yyyyMMdd")
                                TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionStartTimeField = TransactionStartDate.ToString("HHmmssff")

                            Else

                                TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionEndDateField = TransactionEndDate.ToString("yyyyMMdd")
                                TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionEndTimeField = TransactionEndDate.ToString("HHmmssff")

                                TransactionStartDate = AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(OffSetHours * -1, VCCOrder.GetVCCCardEntity.CreatedDate)

                                TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionStartDateField = TransactionStartDate.ToString("yyyyMMdd")
                                TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionStartTimeField = -1

                            End If

                            Requests.Add(TransactionDeliveryMemoRequestTransactionEntity)

                        Next

                        If Requests.Count > 0 Then

                            TransactionDeliveryMemoResponseTransactionEntities.AddRange(RTMCServicev2.TransactionDeliveryMemo(Requests.ToArray))

                        End If

                    Next

                    If TransactionDeliveryMemoResponseTransactionEntities IsNot Nothing AndAlso TransactionDeliveryMemoResponseTransactionEntities.Count > 0 Then

                        For Each TransactionDeliveryMemoResponseTransactionEntity In TransactionDeliveryMemoResponseTransactionEntities

                            Try

                                VCCOrder = VCCOrders.SingleOrDefault(Function(Entity) Entity.TransactionIDField = TransactionDeliveryMemoResponseTransactionEntity.transactionIDField)

                            Catch ex As Exception
                                VCCOrder = Nothing
                            End Try

                            If VCCOrder IsNot Nothing Then

                                If TransactionDeliveryMemoResponseTransactionEntity.responseCodeField = 0 AndAlso TransactionDeliveryMemoResponseTransactionEntity.memoSetField IsNot Nothing Then

                                    For Each SetField In TransactionDeliveryMemoResponseTransactionEntity.memoSetField

                                        Try

                                            ProcessDateTime = DateTime.ParseExact(SetField.processDateField & " " & SetField.processTimeField, "yyyyMMdd HHmmssff", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None)

                                            If OffSetHours <> 0 Then

                                                ProcessDateTime = AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(OffSetHours, ProcessDateTime)

                                            End If

                                            If VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder Then

                                                VCCCardDetail = (From Entity In AdvantageFramework.Database.Procedures.VCCCardDetail.LoadByID(DbContext, VCCOrder.GetVCCCardEntity.ID)
                                                                 Where Entity.ProcessDateTime = ProcessDateTime
                                                                 Select Entity).SingleOrDefault

                                                If VCCCardDetail Is Nothing Then

                                                    VCCCardDetail = New AdvantageFramework.Database.Entities.VCCCardDetail
                                                    VCCCardDetail.DbContext = DbContext
                                                    VCCCardDetail.ID = VCCOrder.GetVCCCardEntity.ID
                                                    VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.PendingTransaction
                                                    VCCCardDetail.CreatedByUserCode = DbContext.UserCode
                                                    VCCCardDetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DataContext)
                                                    VCCCardDetail.MerchantName = SetField.merchantNameField

                                                    VCCCardDetail.ProcessDateTime = ProcessDateTime
                                                    VCCCardDetail.ReferenceNumber = SetField.clearingReferenceNumberField
                                                    VCCCardDetail.Amount = SetField.transactionAmountUSField

                                                    If AdvantageFramework.Database.Procedures.VCCCardDetail.Insert(DbContext, VCCCardDetail, ErrorMessage) = False Then

                                                        Throw New Exception(ErrorMessage)

                                                    End If

                                                    InsertCollectedCostInformation(DbContext, VCCOrder, VCCCardDetail.Amount, SetField.merchantNameField, VCCCardDetail.CreatedDate, AuthorizedByName)

                                                End If

                                            ElseIf VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.PurchaseOrder Then

                                                VCCCardPODetail = (From Entity In AdvantageFramework.Database.Procedures.VCCCardPODetail.LoadByVCCCardPOID(DbContext, VCCOrder.GetVCCCardEntity.ID)
                                                                   Where Entity.ProcessDateTime = ProcessDateTime
                                                                   Select Entity).SingleOrDefault

                                                If VCCCardPODetail Is Nothing Then

                                                    VCCCardPODetail = New AdvantageFramework.Database.Entities.VCCCardPODetail
                                                    VCCCardPODetail.DbContext = DbContext
                                                    VCCCardPODetail.VCCCardPOID = VCCOrder.GetVCCCardEntity.ID
                                                    VCCCardPODetail.Action = AdvantageFramework.Database.Entities.VCCAction.PendingTransaction
                                                    VCCCardPODetail.CreatedByUserCode = DbContext.UserCode
                                                    VCCCardPODetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DataContext)
                                                    VCCCardPODetail.MerchantName = SetField.merchantNameField

                                                    VCCCardPODetail.ProcessDateTime = ProcessDateTime
                                                    VCCCardPODetail.ReferenceNumber = SetField.clearingReferenceNumberField
                                                    VCCCardPODetail.Amount = SetField.transactionAmountUSField

                                                    If AdvantageFramework.Database.Procedures.VCCCardPODetail.Insert(DbContext, VCCCardPODetail, ErrorMessage) = False Then

                                                        Throw New Exception(ErrorMessage)

                                                    End If

                                                End If

                                            End If

                                        Catch ex As Exception
                                            ProcessDateTime = Date.MinValue
                                        End Try

                                    Next

                                Else

                                    Try

                                        ErrorMessage += TransactionDeliveryMemoResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                                    Catch ex As Exception
                                        ErrorMessage = "Error retrieving pending transactions."
                                    End Try

                                    If ErrorMessage <> "" Then

                                        Throw New Exception(ErrorMessage)

                                    End If

                                End If

                            End If

                        Next

                    End If

                Catch ex As Exception
                    DataWasRetrieved = False
                End Try

            Else

                DataWasRetrieved = False

            End If

            GetPendingTransactionsData = DataWasRetrieved

        End Function
        Public Function UpdateVCCCreditCard(Session As AdvantageFramework.Security.Session, VCCCardPOList As Generic.List(Of AdvantageFramework.Database.Entities.VCCCardPO),
                                            ByRef ErrorMessage As String) As Boolean

            Dim VCCCardsUpdated As Boolean = False
            Dim VCCProviderID As Short = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                VCCProviderID = AdvantageFramework.VCC.LoadVCCProvider(DataContext)

            End Using

            If VCCProviderID = AdvantageFramework.VCC.VCCProviders.EFS Then

                VCCCardsUpdated = UpdateVCCCreditCardEFS(Session, VCCCardPOList, ErrorMessage)

                'ElseIf VCCProviderID = AdvantageFramework.VCC.VCCProviders.CSI Then

                '    VCCCardsUpdated = UpdateVCCCreditCardCSI(Session, VCCCardList, ErrorMessage)

            End If

            UpdateVCCCreditCard = VCCCardsUpdated

        End Function
        Public Function UpdateVCCCreditCard(Session As AdvantageFramework.Security.Session, VCCCardList As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard),
                                            ByRef ErrorMessage As String) As Boolean

            Dim VCCCardsUpdated As Boolean = False
            Dim VCCProviderID As Short = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                VCCProviderID = AdvantageFramework.VCC.LoadVCCProvider(DataContext)

            End Using

            If VCCProviderID = AdvantageFramework.VCC.VCCProviders.EFS Then

                VCCCardsUpdated = UpdateVCCCreditCardEFS(Session, VCCCardList, ErrorMessage)

            ElseIf VCCProviderID = AdvantageFramework.VCC.VCCProviders.CSI Then

                VCCCardsUpdated = UpdateVCCCreditCardCSI(Session, VCCCardList, ErrorMessage)

            End If

            UpdateVCCCreditCard = VCCCardsUpdated

        End Function
        Private Function UpdateVCCCreditCardEFS(Session As AdvantageFramework.Security.Session, VCCCardList As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard),
                                                ByRef ErrorMessage As String) As Boolean

            'objects
            Dim VCCCardsUpdated As Boolean = False
            Dim AtLeastOneCardFailed As Boolean = False
            Dim RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing
            Dim VirtualCardUpdateRequestTransactionEntity As AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity = Nothing
            Dim VirtualCardUpdateRequestTransactionEntities As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity) = Nothing
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing
            Dim VirtualCardUpdateResponseTransactionEntities As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateResponseTransactionEntity) = Nothing
            Dim TotalPages As Integer = 0
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim TempErrorMessage As String = ""
            Dim VCCCardDetail As AdvantageFramework.Database.Entities.VCCCardDetail = Nothing

            If IsVCCServiceSetup(Session, ErrorMessage) Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    RTMCServicev2 = CreateRTMCService(Session, DataContext)
                    AccountID = LoadAccountID(DataContext)
                    OutsourceID = LoadOutsourceID(DataContext)

                    VirtualCardUpdateResponseTransactionEntities = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateResponseTransactionEntity)

                    Try

                        TotalPages = Math.Ceiling(VCCCardList.Count / 10)

                    Catch ex As Exception
                        TotalPages = 1
                    End Try

                    For PageIndex = 0 To TotalPages Step 1

                        VirtualCardUpdateRequestTransactionEntities = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity)

                        For Each VCCCard In VCCCardList.Skip(PageIndex * 10).Take(10)

                            Try

                                VirtualCardUpdateRequestTransactionEntity = New AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity()
                                VirtualCardUpdateRequestTransactionEntity.accountNumberField = AccountID
                                VirtualCardUpdateRequestTransactionEntity.outsourceIDField = OutsourceID
                                VirtualCardUpdateRequestTransactionEntity.transactionIDField = AdvantageFramework.StringUtilities.PadWithCharacter(VCCCard.OrderNumber, 15, "0", True, True) & AdvantageFramework.StringUtilities.PadWithCharacter(VCCCard.LineNumber, 4, "0", True, True)
                                VirtualCardUpdateRequestTransactionEntity.cardGroupField = -1

                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField = New AdvantageFramework.RTMCService.VirtualCardUpdateFields
                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.cardGroupField = -1
                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.cardStatusField = VCCCard.Status
                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.dollarAmountField = VCCCard.CardAmount

                                VirtualCardUpdateRequestTransactionEntity.virtualCardMCMGField = New RTMCService.VirtualCardMCMGFields() {New RTMCService.VirtualCardMCMGFields With {.mCMGField = "000"}}

                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.numberOfUsesField = VCCCard.NumberOfUses

                                VirtualCardUpdateRequestTransactionEntity.virtualMasterCardNumberField = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCCard.CardNumber)

                                VirtualCardUpdateRequestTransactionEntities.Add(VirtualCardUpdateRequestTransactionEntity)

                            Catch ex As Exception
                                ErrorMessage = "Failed to connect to VCC for card update."
                            End Try

                        Next

                        If VirtualCardUpdateRequestTransactionEntities.Count > 0 Then

                            VirtualCardUpdateResponseTransactionEntities.AddRange(RTMCServicev2.VirtualCardUpdate(VirtualCardUpdateRequestTransactionEntities.ToArray))

                        End If

                    Next

                End Using

                If VirtualCardUpdateResponseTransactionEntities IsNot Nothing AndAlso VirtualCardUpdateResponseTransactionEntities.Count > 0 Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            For Each VirtualCardUpdateResponseTransactionEntity In VirtualCardUpdateResponseTransactionEntities

                                Try

                                    VCCCard = VCCCardList.SingleOrDefault(Function(Entity) AdvantageFramework.StringUtilities.PadWithCharacter(Entity.OrderNumber, 15, "0", True, True) & AdvantageFramework.StringUtilities.PadWithCharacter(Entity.LineNumber, 4, "0", True, True) = VirtualCardUpdateResponseTransactionEntity.transactionIDField)

                                Catch ex As Exception
                                    VCCCard = Nothing
                                End Try

                                If VCCCard IsNot Nothing Then

                                    If VirtualCardUpdateResponseTransactionEntity.messageSetField IsNot Nothing AndAlso
                                                        VirtualCardUpdateResponseTransactionEntity.messageSetField.Any(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg) = False Then

                                        Using DbTransaction = DbContext.Database.BeginTransaction

                                            VCCCard = VCCCard

                                            VCCCard.DbContext = DbContext
                                            VCCCard.ModifiedByUserCode = Session.UserCode
                                            VCCCard.ModifiedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                            If AdvantageFramework.Database.Procedures.VCCCard.Update(DbContext, VCCCard, TempErrorMessage) = False Then

                                                ErrorMessage += TempErrorMessage

                                                AtLeastOneCardFailed = True

                                                DbTransaction.Rollback()

                                            Else

                                                VCCCardDetail = New AdvantageFramework.Database.Entities.VCCCardDetail
                                                VCCCardDetail.DbContext = DbContext

                                                VCCCardDetail.ID = VCCCard.ID
                                                VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.CreditCardUpdate
                                                VCCCardDetail.Amount = VCCCard.CardAmount
                                                VCCCardDetail.CreatedByUserCode = Session.UserCode
                                                VCCCardDetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                                VCCCardDetail.ProcessDateTime = VCCCardDetail.CreatedDate

                                                If AdvantageFramework.Database.Procedures.VCCCardDetail.Insert(DbContext, VCCCardDetail, TempErrorMessage) Then

                                                    DbTransaction.Commit()

                                                Else

                                                    ErrorMessage += TempErrorMessage

                                                    AtLeastOneCardFailed = True

                                                    DbTransaction.Rollback()

                                                End If

                                            End If

                                        End Using

                                    Else

                                        AtLeastOneCardFailed = True

                                        Try

                                            ErrorMessage += VirtualCardUpdateResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                                        Catch ex As Exception

                                        End Try

                                        ErrorMessage = "Failed to connect to VCC for card update."

                                    End If

                                End If

                            Next

                        End Using

                        VCCCardsUpdated = Not AtLeastOneCardFailed

                    Catch ex As Exception

                        VCCCardsUpdated = False

                        ErrorMessage = "Failed to save data from VCC to Advantage."

                    End Try

                End If

            End If

            UpdateVCCCreditCardEFS = VCCCardsUpdated

        End Function
        Private Function UpdateVCCCreditCardEFS(Session As AdvantageFramework.Security.Session, VCCCardPOList As Generic.List(Of AdvantageFramework.Database.Entities.VCCCardPO),
                                                ByRef ErrorMessage As String) As Boolean

            'objects
            Dim VCCCardsUpdated As Boolean = False
            Dim AtLeastOneCardFailed As Boolean = False
            Dim RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing
            Dim VirtualCardUpdateRequestTransactionEntity As AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity = Nothing
            Dim VirtualCardUpdateRequestTransactionEntities As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity) = Nothing
            Dim VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO = Nothing
            Dim VirtualCardUpdateResponseTransactionEntities As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateResponseTransactionEntity) = Nothing
            Dim TotalPages As Integer = 0
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim TempErrorMessage As String = ""
            Dim VCCCardPODetail As AdvantageFramework.Database.Entities.VCCCardPODetail = Nothing

            If IsVCCServiceSetup(Session, ErrorMessage) Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    RTMCServicev2 = CreateRTMCService(Session, DataContext)
                    AccountID = LoadAccountID(DataContext)
                    OutsourceID = LoadOutsourceID(DataContext)

                    VirtualCardUpdateResponseTransactionEntities = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateResponseTransactionEntity)

                    Try

                        TotalPages = Math.Ceiling(VCCCardPOList.Count / 10)

                    Catch ex As Exception
                        TotalPages = 1
                    End Try

                    For PageIndex = 0 To TotalPages Step 1

                        VirtualCardUpdateRequestTransactionEntities = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity)

                        For Each VCCCardPO In VCCCardPOList.Skip(PageIndex * 10).Take(10)

                            Try

                                VirtualCardUpdateRequestTransactionEntity = New AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity()
                                VirtualCardUpdateRequestTransactionEntity.accountNumberField = AccountID
                                VirtualCardUpdateRequestTransactionEntity.outsourceIDField = OutsourceID
                                VirtualCardUpdateRequestTransactionEntity.transactionIDField = AdvantageFramework.StringUtilities.PadWithCharacter(VCCCardPO.PONumber, 19, "0", True, True)
                                VirtualCardUpdateRequestTransactionEntity.cardGroupField = -1

                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField = New AdvantageFramework.RTMCService.VirtualCardUpdateFields
                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.cardGroupField = -1
                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.cardStatusField = VCCCardPO.Status
                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.dollarAmountField = VCCCardPO.CardAmount

                                VirtualCardUpdateRequestTransactionEntity.virtualCardMCMGField = New RTMCService.VirtualCardMCMGFields() {New RTMCService.VirtualCardMCMGFields With {.mCMGField = "000"}}

                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.numberOfUsesField = VCCCardPO.NumberOfUses

                                VirtualCardUpdateRequestTransactionEntity.virtualMasterCardNumberField = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCCardPO.CardNumber)

                                VirtualCardUpdateRequestTransactionEntities.Add(VirtualCardUpdateRequestTransactionEntity)

                            Catch ex As Exception
                                ErrorMessage = "Failed to connect to VCC for card update."
                            End Try

                        Next

                        If VirtualCardUpdateRequestTransactionEntities.Count > 0 Then

                            VirtualCardUpdateResponseTransactionEntities.AddRange(RTMCServicev2.VirtualCardUpdate(VirtualCardUpdateRequestTransactionEntities.ToArray))

                        End If

                    Next

                End Using

                If VirtualCardUpdateResponseTransactionEntities IsNot Nothing AndAlso VirtualCardUpdateResponseTransactionEntities.Count > 0 Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            For Each VirtualCardUpdateResponseTransactionEntity In VirtualCardUpdateResponseTransactionEntities

                                Try

                                    VCCCardPO = VCCCardPOList.SingleOrDefault(Function(Entity) AdvantageFramework.StringUtilities.PadWithCharacter(Entity.PONumber, 19, "0", True, True) = VirtualCardUpdateResponseTransactionEntity.transactionIDField)

                                Catch ex As Exception
                                    VCCCardPO = Nothing
                                End Try

                                If VCCCardPO IsNot Nothing Then

                                    If VirtualCardUpdateResponseTransactionEntity.messageSetField IsNot Nothing AndAlso
                                                        VirtualCardUpdateResponseTransactionEntity.messageSetField.Any(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg) = False Then

                                        Using DbTransaction = DbContext.Database.BeginTransaction

                                            VCCCardPO.DbContext = DbContext
                                            VCCCardPO.ModifiedByUserCode = Session.UserCode
                                            VCCCardPO.ModifiedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                            If AdvantageFramework.Database.Procedures.VCCCardPO.Update(DbContext, VCCCardPO, TempErrorMessage) = False Then

                                                ErrorMessage += TempErrorMessage

                                                AtLeastOneCardFailed = True

                                                DbTransaction.Rollback()

                                            Else

                                                VCCCardPODetail = New AdvantageFramework.Database.Entities.VCCCardPODetail
                                                VCCCardPODetail.DbContext = DbContext

                                                VCCCardPODetail.VCCCardPOID = VCCCardPO.ID
                                                VCCCardPODetail.Action = AdvantageFramework.Database.Entities.VCCAction.CreditCardUpdate
                                                VCCCardPODetail.Amount = VCCCardPO.CardAmount
                                                VCCCardPODetail.CreatedByUserCode = Session.UserCode
                                                VCCCardPODetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                                VCCCardPODetail.ProcessDateTime = VCCCardPODetail.CreatedDate

                                                If AdvantageFramework.Database.Procedures.VCCCardPODetail.Insert(DbContext, VCCCardPODetail, TempErrorMessage) Then

                                                    DbTransaction.Commit()

                                                Else

                                                    ErrorMessage += TempErrorMessage

                                                    AtLeastOneCardFailed = True

                                                    DbTransaction.Rollback()

                                                End If

                                            End If

                                        End Using

                                    Else

                                        AtLeastOneCardFailed = True

                                        Try

                                            ErrorMessage += VirtualCardUpdateResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                                        Catch ex As Exception

                                        End Try

                                        ErrorMessage = "Failed to connect to VCC for card update."

                                    End If

                                End If

                            Next

                        End Using

                        VCCCardsUpdated = Not AtLeastOneCardFailed

                    Catch ex As Exception

                        VCCCardsUpdated = False

                        ErrorMessage = "Failed to save data from VCC to Advantage."

                    End Try

                End If

            End If

            UpdateVCCCreditCardEFS = VCCCardsUpdated

        End Function
        Public Function UpdateVCCCreditCard(Session As AdvantageFramework.Security.Session, VCCOrderList As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder),
                                            ByRef ErrorMessage As String) As Boolean

            Dim VCCCardsUpdated As Boolean = False
            Dim VCCProviderID As Short = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                VCCProviderID = AdvantageFramework.VCC.LoadVCCProvider(DataContext)

            End Using

            If VCCProviderID = AdvantageFramework.VCC.VCCProviders.EFS Then

                VCCCardsUpdated = UpdateVCCCreditCardEFS(Session, VCCOrderList, ErrorMessage)

            ElseIf VCCProviderID = AdvantageFramework.VCC.VCCProviders.CSI Then

                VCCCardsUpdated = UpdateVCCCreditCardCSI(Session, VCCOrderList, ErrorMessage)

            End If

            UpdateVCCCreditCard = VCCCardsUpdated

        End Function
        Private Function UpdateVCCCreditCardEFS(Session As AdvantageFramework.Security.Session, VCCOrderList As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder),
                                                ByRef ErrorMessage As String) As Boolean

            'objects
            Dim VCCCardsUpdated As Boolean = False
            Dim AtLeastOneCardFailed As Boolean = False
            Dim RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing
            Dim VirtualCardUpdateRequestTransactionEntity As AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity = Nothing
            Dim VirtualCardUpdateRequestTransactionEntities As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity) = Nothing
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing
            Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing
            Dim VirtualCardUpdateResponseTransactionEntities As Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateResponseTransactionEntity) = Nothing
            Dim TotalPages As Integer = 0
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim TempErrorMessage As String = ""
            Dim VCCCardDetail As AdvantageFramework.Database.Entities.VCCCardDetail = Nothing
            Dim VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO = Nothing
            Dim VCCCardPODetail As AdvantageFramework.Database.Entities.VCCCardPODetail = Nothing

            If IsVCCServiceSetup(Session) Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    RTMCServicev2 = CreateRTMCService(Session, DataContext)
                    AccountID = LoadAccountID(DataContext)
                    OutsourceID = LoadOutsourceID(DataContext)

                    VirtualCardUpdateResponseTransactionEntities = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateResponseTransactionEntity)

                    Try

                        TotalPages = Math.Ceiling(VCCOrderList.Count / 10)

                    Catch ex As Exception
                        TotalPages = 1
                    End Try

                    For PageIndex = 0 To TotalPages Step 1

                        VirtualCardUpdateRequestTransactionEntities = New Generic.List(Of AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity)

                        For Each VCCOrder In VCCOrderList.Skip(PageIndex * 10).Take(10)

                            Try

                                VirtualCardUpdateRequestTransactionEntity = New AdvantageFramework.RTMCService.VirtualCardUpdateRequestTransactionEntity()
                                VirtualCardUpdateRequestTransactionEntity.accountNumberField = AccountID
                                VirtualCardUpdateRequestTransactionEntity.outsourceIDField = OutsourceID
                                VirtualCardUpdateRequestTransactionEntity.transactionIDField = VCCOrder.TransactionIDField
                                VirtualCardUpdateRequestTransactionEntity.cardGroupField = -1

                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField = New AdvantageFramework.RTMCService.VirtualCardUpdateFields
                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.cardGroupField = -1
                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.cardStatusField = VCCOrder.GetVCCCardEntity.Status
                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.dollarAmountField = VCCOrder.GetVCCCardEntity.CardAmount

                                VirtualCardUpdateRequestTransactionEntity.virtualCardMCMGField = New RTMCService.VirtualCardMCMGFields() {New RTMCService.VirtualCardMCMGFields With {.mCMGField = "000"}}

                                VirtualCardUpdateRequestTransactionEntity.virtualCardUpdateFieldsField.numberOfUsesField = VCCOrder.GetVCCCardEntity.NumberOfUses

                                VirtualCardUpdateRequestTransactionEntity.virtualMasterCardNumberField = AdvantageFramework.Security.Encryption.ASCIIDecoding(VCCOrder.GetVCCCardEntity.CardNumber)

                                VirtualCardUpdateRequestTransactionEntities.Add(VirtualCardUpdateRequestTransactionEntity)

                            Catch ex As Exception

                                VCCOrder.VCCUpdateMessage = "Failed to connect to VCC for card update."

                            End Try

                        Next

                        If VirtualCardUpdateRequestTransactionEntities.Count > 0 Then

                            VirtualCardUpdateResponseTransactionEntities.AddRange(RTMCServicev2.VirtualCardUpdate(VirtualCardUpdateRequestTransactionEntities.ToArray))

                        End If

                    Next

                End Using

                If VirtualCardUpdateResponseTransactionEntities IsNot Nothing AndAlso VirtualCardUpdateResponseTransactionEntities.Count > 0 Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            For Each VirtualCardUpdateResponseTransactionEntity In VirtualCardUpdateResponseTransactionEntities

                                Try

                                    VCCOrder = VCCOrderList.SingleOrDefault(Function(Entity) Entity.TransactionIDField = VirtualCardUpdateResponseTransactionEntity.transactionIDField)

                                Catch ex As Exception
                                    VCCOrder = Nothing
                                End Try

                                If VCCOrder IsNot Nothing Then

                                    If VirtualCardUpdateResponseTransactionEntity.messageSetField IsNot Nothing AndAlso
                                                VirtualCardUpdateResponseTransactionEntity.messageSetField.Any(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg) = False Then

                                        Using DbTransaction = DbContext.Database.BeginTransaction

                                            If VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder Then

                                                VCCCard = VCCOrder.GetVCCCardEntity

                                                VCCCard.DbContext = DbContext
                                                VCCCard.ModifiedByUserCode = Session.UserCode
                                                VCCCard.ModifiedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                                If AdvantageFramework.Database.Procedures.VCCCard.Update(DbContext, VCCCard, TempErrorMessage) = False Then

                                                    ErrorMessage += TempErrorMessage

                                                    AtLeastOneCardFailed = True

                                                    DbTransaction.Rollback()

                                                Else

                                                    VCCCardDetail = New AdvantageFramework.Database.Entities.VCCCardDetail
                                                    VCCCardDetail.DbContext = DbContext

                                                    VCCCardDetail.ID = VCCCard.ID
                                                    VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.CreditCardUpdate
                                                    VCCCardDetail.Amount = VCCCard.CardAmount
                                                    VCCCardDetail.CreatedByUserCode = Session.UserCode
                                                    VCCCardDetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                                    VCCCardDetail.ProcessDateTime = VCCCardDetail.CreatedDate

                                                    If AdvantageFramework.Database.Procedures.VCCCardDetail.Insert(DbContext, VCCCardDetail, TempErrorMessage) Then

                                                        DbTransaction.Commit()

                                                    Else

                                                        ErrorMessage += TempErrorMessage

                                                        AtLeastOneCardFailed = True

                                                        DbTransaction.Rollback()

                                                    End If

                                                End If

                                            ElseIf VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.PurchaseOrder Then

                                                VCCCardPO = VCCOrder.GetVCCCardEntity

                                                VCCCardPO.DbContext = DbContext
                                                VCCCardPO.ModifiedByUserCode = Session.UserCode
                                                VCCCardPO.ModifiedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                                If AdvantageFramework.Database.Procedures.VCCCardPO.Update(DbContext, VCCCardPO, TempErrorMessage) = False Then

                                                    ErrorMessage += TempErrorMessage

                                                    AtLeastOneCardFailed = True

                                                    DbTransaction.Rollback()

                                                Else

                                                    VCCCardPODetail = New AdvantageFramework.Database.Entities.VCCCardPODetail
                                                    VCCCardPODetail.DbContext = DbContext

                                                    VCCCardPODetail.VCCCardPOID = VCCCardPO.ID
                                                    VCCCardPODetail.Action = AdvantageFramework.Database.Entities.VCCAction.CreditCardUpdate
                                                    VCCCardPODetail.Amount = VCCCardPO.CardAmount
                                                    VCCCardPODetail.CreatedByUserCode = Session.UserCode
                                                    VCCCardPODetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                                    VCCCardPODetail.ProcessDateTime = VCCCardPODetail.CreatedDate

                                                    If AdvantageFramework.Database.Procedures.VCCCardPODetail.Insert(DbContext, VCCCardPODetail, TempErrorMessage) Then

                                                        DbTransaction.Commit()

                                                    Else

                                                        ErrorMessage += TempErrorMessage

                                                        AtLeastOneCardFailed = True

                                                        DbTransaction.Rollback()

                                                    End If

                                                End If

                                            End If

                                        End Using

                                    Else

                                        AtLeastOneCardFailed = True

                                        Try

                                            ErrorMessage += VirtualCardUpdateResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                                        Catch ex As Exception

                                        End Try

                                        VCCOrder.VCCUpdateMessage = "Failed to connect to VCC for card update."

                                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                            VCCOrder.VCCUpdateMessage &= System.Environment.NewLine & System.Environment.NewLine & ErrorMessage

                                        End If

                                    End If

                                End If

                            Next

                        End Using

                        VCCCardsUpdated = Not AtLeastOneCardFailed

                    Catch ex As Exception

                        For Each VCCOrder In VCCOrderList

                            VCCOrder.VCCUpdateMessage = "Failed saving data from VCC to Advantage."

                        Next

                    End Try

                End If

            Else

                For Each VCCOrder In VCCOrderList

                    VCCOrder.VCCUpdateMessage = "Failed to connect to VCC for card update."

                Next

            End If

            UpdateVCCCreditCardEFS = VCCCardsUpdated

        End Function
        Private Sub InsertCollectedCostInformation(DbContext As AdvantageFramework.Database.DbContext, VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder,
                                                   TransactionAmount As Decimal, MerchantName As String, TransactionDate As Date, AuthorizedByName As String)

            Dim CollectedCostInformation As AdvantageFramework.Database.Entities.CollectedCostInformation = Nothing
            Dim ErrorMessage As String = Nothing

            CollectedCostInformation = (From Entity In AdvantageFramework.Database.Procedures.CollectedCostInformation.Load(DbContext)
                                        Where Entity.OrderNumber = VCCOrder.OrderNumber.Value AndAlso
                                              Entity.LineNumber = VCCOrder.LineNumber.Value AndAlso
                                              Entity.RevisionNumber = VCCOrder.RevisionNumber.Value AndAlso
                                              Entity.IsQuote = VCCOrder.Quote).SingleOrDefault

            If CollectedCostInformation Is Nothing Then

                CollectedCostInformation = New AdvantageFramework.Database.Entities.CollectedCostInformation
                CollectedCostInformation.DbContext = DbContext

                CollectedCostInformation.OrderNumber = VCCOrder.OrderNumber.Value
                CollectedCostInformation.LineNumber = VCCOrder.LineNumber.Value
                CollectedCostInformation.RevisionNumber = VCCOrder.RevisionNumber.Value
                CollectedCostInformation.GrossAmount = 0
                CollectedCostInformation.CommissionPercentage = 0
                CollectedCostInformation.NetAmount = TransactionAmount
                CollectedCostInformation.Notes = "Collected via VCC Transaction"
                CollectedCostInformation.AuthorizedBy = MerchantName
                CollectedCostInformation.CreatedDate = TransactionDate
                CollectedCostInformation.AuthorizedByName = AuthorizedByName
                CollectedCostInformation.IsQuote = VCCOrder.Quote

                If AdvantageFramework.Database.Procedures.CollectedCostInformation.Insert(DbContext, CollectedCostInformation, ErrorMessage) = False Then

                    Throw New Exception(ErrorMessage)

                End If

            End If

        End Sub
        Public Function GetClearedTransactionsDataForClearedCheckImport(Session As AdvantageFramework.Security.Session, TransactionStartDate As Date, TransactionEndDate As Date) As IEnumerable(Of RTMCService.TransactionDeliveryClearedResponseTransactionEntity)

            'objects
            Dim RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing
            Dim TransactionID As String = Nothing
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim CompanyID As String = ""
            Dim Requests As Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity) = Nothing
            Dim TransactionDeliveryClearedRequestTransactionEntity As AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity = Nothing
            Dim TransactionDeliveryClearedResponseTransactionEntities As IEnumerable(Of RTMCService.TransactionDeliveryClearedResponseTransactionEntity) = Nothing
            Dim RequestDate As Date = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                RTMCServicev2 = CreateRTMCService(Session, DataContext)

                If RTMCServicev2 IsNot Nothing Then

                    Try

                        AccountID = LoadAccountID(DataContext)
                        OutsourceID = LoadOutsourceID(DataContext)
                        CompanyID = LoadCompanyID(DataContext)

                        Requests = New Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity)

                        RequestDate = TransactionStartDate

                        While RequestDate <= TransactionEndDate

                            TransactionID = Format(RequestDate, "yyyyMMddHHmmssff")

                            TransactionDeliveryClearedRequestTransactionEntity = New AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity

                            TransactionDeliveryClearedRequestTransactionEntity.accountNumberField = AccountID
                            TransactionDeliveryClearedRequestTransactionEntity.cardGroupField = -1
                            TransactionDeliveryClearedRequestTransactionEntity.companyNumberField = CompanyID
                            TransactionDeliveryClearedRequestTransactionEntity.outsourceIDField = OutsourceID
                            TransactionDeliveryClearedRequestTransactionEntity.transactionIDField = AdvantageFramework.StringUtilities.PadWithCharacter(TransactionID, 19, "0", True, True)

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField = New RTMCService.TransactionDeliveryKeyFields
                            'TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.cardNumberField = ""

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.lastReceivedField = New RTMCService.TransactionDeliveryLastReceived
                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.numberOfTransactionsRequestedField = 1000

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionStartDateField = RequestDate.ToString("yyyyMMdd")
                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionStartTimeField = "00000001" 'TransactionStartDate.ToString("HHmmssff")

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionEndDateField = RequestDate.ToString("yyyyMMdd")
                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionEndTimeField = "23595999" 'TransactionEndDate.ToString("HHmmssff")

                            Requests.Add(TransactionDeliveryClearedRequestTransactionEntity)

                            RequestDate = DateAdd(DateInterval.Day, 1, RequestDate)

                        End While

                        TransactionDeliveryClearedResponseTransactionEntities = RTMCServicev2.TransactionDeliveryCleared(Requests.ToArray)

                    Catch ex As Exception
                        Throw ex
                    End Try

                End If

            End Using

            GetClearedTransactionsDataForClearedCheckImport = TransactionDeliveryClearedResponseTransactionEntities

        End Function
        Private Function PopulateVirtualCreditCardTransactionEFSDetail(TransactionDeliveryClearedResponseTransactionEntities As IEnumerable(Of RTMCService.TransactionDeliveryClearedResponseTransactionEntity),
                                                                       ByRef VirtualCreditCardTransactionEFSDetails As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail),
                                                                       ByRef ErrorMessage As String,
                                                                       OffSetHours As Decimal) As Boolean

            Dim VirtualCreditCardTransactionEFSDetail As AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail = Nothing
            Dim Successful As Boolean = True
            Dim ProcessDateTime As Date = Nothing

            For Each TransactionDeliveryClearedResponseTransactionEntity In TransactionDeliveryClearedResponseTransactionEntities

                If TransactionDeliveryClearedResponseTransactionEntity.responseCodeField = 0 AndAlso TransactionDeliveryClearedResponseTransactionEntity.clearedSetField IsNot Nothing Then

                    For Each SetField In TransactionDeliveryClearedResponseTransactionEntity.clearedSetField

                        VirtualCreditCardTransactionEFSDetail = New AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail

                        VirtualCreditCardTransactionEFSDetail.CardCTS = SetField.cardCTSField
                        VirtualCreditCardTransactionEFSDetail.MerchantName = SetField.merchantNameField
                        VirtualCreditCardTransactionEFSDetail.Action = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.VCCAction), AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction)
                        VirtualCreditCardTransactionEFSDetail.Amount = SetField.transactionAmountField
                        VirtualCreditCardTransactionEFSDetail.Reference = SetField.clearingReferenceNumberField

                        Try

                            ProcessDateTime = DateTime.ParseExact(SetField.processDateField & " " & SetField.processTimeField.PadLeft(8, "0"), "yyyyMMdd HHmmssff", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None)

                        Catch ex As Exception
                            ProcessDateTime = Date.MinValue
                        End Try

                        If OffSetHours <> 0 Then

                            ProcessDateTime = DateAdd(DateInterval.Hour, OffSetHours, ProcessDateTime)

                        End If

                        VirtualCreditCardTransactionEFSDetail.ProcessedDateTime = ProcessDateTime

                        VirtualCreditCardTransactionEFSDetails.Add(VirtualCreditCardTransactionEFSDetail)

                    Next

                Else

                    Try

                        ErrorMessage += TransactionDeliveryClearedResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                    Catch ex As Exception
                        ErrorMessage = "Error retrieving cleared transactions."
                    End Try

                    Successful = False

                End If

            Next

            PopulateVirtualCreditCardTransactionEFSDetail = Successful

        End Function
        Private Function PopulateVirtualCreditCardTransactionEFSDetail(TransactionDeliveryRejectResponseTransactionEntities As IEnumerable(Of RTMCService.TransactionDeliveryRejectResponseTransactionEntity),
                                                                       ByRef VirtualCreditCardTransactionEFSDetails As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail),
                                                                       ByRef ErrorMessage As String,
                                                                       OffSetHours As Decimal) As Boolean

            Dim VirtualCreditCardTransactionEFSDetail As AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail = Nothing
            Dim Successful As Boolean = True
            Dim ProcessDateTime As Date = Nothing

            For Each TransactionDeliveryRejectResponseTransactionEntity In TransactionDeliveryRejectResponseTransactionEntities

                If TransactionDeliveryRejectResponseTransactionEntity.responseCodeField = 0 AndAlso TransactionDeliveryRejectResponseTransactionEntity.rejectsSetField IsNot Nothing Then

                    For Each SetField In TransactionDeliveryRejectResponseTransactionEntity.rejectsSetField

                        VirtualCreditCardTransactionEFSDetail = New AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail

                        VirtualCreditCardTransactionEFSDetail.CardCTS = SetField.cardCTSField
                        VirtualCreditCardTransactionEFSDetail.MerchantName = SetField.merchantNameField
                        VirtualCreditCardTransactionEFSDetail.Action = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.VCCAction), AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction)
                        VirtualCreditCardTransactionEFSDetail.Amount = SetField.transactionAmountUSField
                        VirtualCreditCardTransactionEFSDetail.Reference = SetField.rejectMessageField

                        Try

                            ProcessDateTime = DateTime.ParseExact(SetField.processDateField & " " & SetField.processTimeField.PadLeft(8, "0"), "yyyyMMdd HHmmssff", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None)

                        Catch ex As Exception
                            ProcessDateTime = Date.MinValue
                        End Try

                        If OffSetHours <> 0 Then

                            ProcessDateTime = DateAdd(DateInterval.Hour, OffSetHours, ProcessDateTime)

                        End If

                        VirtualCreditCardTransactionEFSDetail.ProcessedDateTime = ProcessDateTime

                        VirtualCreditCardTransactionEFSDetails.Add(VirtualCreditCardTransactionEFSDetail)

                    Next

                Else

                    Try

                        ErrorMessage += TransactionDeliveryRejectResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                    Catch ex As Exception
                        ErrorMessage = "Error retrieving rejected transactions."
                    End Try

                    Successful = False

                End If

            Next

            PopulateVirtualCreditCardTransactionEFSDetail = Successful

        End Function
        Private Function PopulateVirtualCreditCardTransactionEFSDetail(TransactionDeliveryMemoResponseTransactionEntities As IEnumerable(Of RTMCService.TransactionDeliveryMemoResponseTransactionEntity),
                                                                       ByRef VirtualCreditCardTransactionEFSDetails As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail),
                                                                       ByRef ErrorMessage As String,
                                                                       OffSetHours As Decimal) As Boolean

            Dim VirtualCreditCardTransactionEFSDetail As AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail = Nothing
            Dim Successful As Boolean = True
            Dim ProcessDateTime As Date = Nothing

            For Each TransactionDeliveryMemoResponseTransactionEntity In TransactionDeliveryMemoResponseTransactionEntities

                If TransactionDeliveryMemoResponseTransactionEntity.responseCodeField = 0 AndAlso TransactionDeliveryMemoResponseTransactionEntity.memoSetField IsNot Nothing Then

                    For Each SetField In TransactionDeliveryMemoResponseTransactionEntity.memoSetField

                        VirtualCreditCardTransactionEFSDetail = New AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail

                        VirtualCreditCardTransactionEFSDetail.CardCTS = SetField.cardCTSField
                        VirtualCreditCardTransactionEFSDetail.MerchantName = SetField.merchantNameField
                        VirtualCreditCardTransactionEFSDetail.Action = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.VCCAction), AdvantageFramework.Database.Entities.VCCAction.PendingTransaction)
                        VirtualCreditCardTransactionEFSDetail.Amount = SetField.transactionAmountUSField
                        VirtualCreditCardTransactionEFSDetail.Reference = SetField.clearingReferenceNumberField

                        Try

                            ProcessDateTime = DateTime.ParseExact(SetField.processDateField & " " & SetField.processTimeField.PadLeft(8, "0"), "yyyyMMdd HHmmssff", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None)

                        Catch ex As Exception
                            ProcessDateTime = Date.MinValue
                        End Try

                        If OffSetHours <> 0 Then

                            ProcessDateTime = DateAdd(DateInterval.Hour, OffSetHours, ProcessDateTime)

                        End If

                        VirtualCreditCardTransactionEFSDetail.ProcessedDateTime = ProcessDateTime

                        VirtualCreditCardTransactionEFSDetails.Add(VirtualCreditCardTransactionEFSDetail)

                    Next

                Else

                    Try

                        ErrorMessage += TransactionDeliveryMemoResponseTransactionEntity.messageSetField.FirstOrDefault(Function(Message) Message.typeField = RTMCService.MessageType.ErrorMsg).messageTextField

                    Catch ex As Exception
                        ErrorMessage = "Error retrieving pending transactions."
                    End Try

                    Successful = False

                End If

            Next

            PopulateVirtualCreditCardTransactionEFSDetail = Successful

        End Function
        Public Function GetTransactionsForDataset(Session As AdvantageFramework.Security.Session, TransactionStartDate As Date, TransactionEndDate As Date,
                                                  ByRef VirtualCreditCardTransactionEFSDetails As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim RTMCServicev2 As AdvantageFramework.RTMCService.RTMCServiceClient = Nothing
            Dim TransactionID As String = Nothing
            Dim AccountID As String = ""
            Dim OutsourceID As String = ""
            Dim CompanyID As String = ""
            Dim ClearedRequests As Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity) = Nothing
            Dim RejectRequests As Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryRejectRequestTransactionEntity) = Nothing
            'Dim MemoRequests As Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryMemoRequestTransactionEntity) = Nothing
            Dim TransactionDeliveryClearedRequestTransactionEntity As AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity = Nothing
            Dim TransactionDeliveryRejectRequestTransactionEntity As AdvantageFramework.RTMCService.TransactionDeliveryRejectRequestTransactionEntity = Nothing
            'Dim TransactionDeliveryMemoRequestTransactionEntity As AdvantageFramework.RTMCService.TransactionDeliveryMemoRequestTransactionEntity = Nothing
            Dim RequestDate As Date = Nothing
            'Dim CSTTimeZoneInfo As TimeZoneInfo = Nothing
            Dim CSTHoursOffset As Decimal = 0
            Dim SQLHoursOffset As Decimal = 0
            Dim OffSetHours As Decimal = 0
            Dim TransactionDeliveryClearedResponseTransactionEntities As Generic.List(Of RTMCService.TransactionDeliveryClearedResponseTransactionEntity) = Nothing
            Dim TransactionDeliveryRejectResponseTransactionEntities As Generic.List(Of RTMCService.TransactionDeliveryRejectResponseTransactionEntity) = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                RTMCServicev2 = CreateRTMCService(Session, DataContext)

                Try

                    CSTHoursOffset = AdvantageFramework.Database.Procedures.Generic.GetOffsetFromSystemTimeZone("Central Standard Time")

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        SQLHoursOffset = AdvantageFramework.Database.Procedures.Generic.LoadSQLHoursOffset(DbContext)

                    End Using

                    OffSetHours = (CSTHoursOffset - SQLHoursOffset) * -1

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

                If RTMCServicev2 IsNot Nothing Then

                    Try

                        AccountID = LoadAccountID(DataContext)
                        OutsourceID = LoadOutsourceID(DataContext)
                        CompanyID = LoadCompanyID(DataContext)

                        TransactionDeliveryClearedResponseTransactionEntities = New Generic.List(Of RTMCService.TransactionDeliveryClearedResponseTransactionEntity)

                        ClearedRequests = New Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity)

                        RequestDate = TransactionStartDate

                        While RequestDate <= TransactionEndDate

                            TransactionID = Format(RequestDate, "yyyyMMddHHmmssff")

                            TransactionDeliveryClearedRequestTransactionEntity = New AdvantageFramework.RTMCService.TransactionDeliveryClearedRequestTransactionEntity

                            TransactionDeliveryClearedRequestTransactionEntity.accountNumberField = AccountID
                            TransactionDeliveryClearedRequestTransactionEntity.cardGroupField = -1
                            TransactionDeliveryClearedRequestTransactionEntity.companyNumberField = CompanyID
                            TransactionDeliveryClearedRequestTransactionEntity.outsourceIDField = OutsourceID
                            TransactionDeliveryClearedRequestTransactionEntity.transactionIDField = AdvantageFramework.StringUtilities.PadWithCharacter(TransactionID, 19, "0", True, True)

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField = New RTMCService.TransactionDeliveryKeyFields
                            'TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.cardNumberField = ""

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.lastReceivedField = New RTMCService.TransactionDeliveryLastReceived
                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.numberOfTransactionsRequestedField = 1000

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionStartDateField = RequestDate.ToString("yyyyMMdd")
                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionStartTimeField = "00000001" 'TransactionStartDate.ToString("HHmmssff")

                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionEndDateField = RequestDate.ToString("yyyyMMdd")
                            TransactionDeliveryClearedRequestTransactionEntity.keyFieldsField.transactionEndTimeField = "23595999" 'TransactionEndDate.ToString("HHmmssff")

                            ClearedRequests.Add(TransactionDeliveryClearedRequestTransactionEntity)

                            RequestDate = DateAdd(DateInterval.Day, 1, RequestDate)

                        End While

                        If ClearedRequests.Count > 0 Then

                            TransactionDeliveryClearedResponseTransactionEntities.AddRange(RTMCServicev2.TransactionDeliveryCleared(ClearedRequests.ToArray))

                        End If

                        If PopulateVirtualCreditCardTransactionEFSDetail(TransactionDeliveryClearedResponseTransactionEntities, VirtualCreditCardTransactionEFSDetails, ErrorMessage, OffSetHours) Then

                            RejectRequests = New Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryRejectRequestTransactionEntity)

                            TransactionDeliveryRejectResponseTransactionEntities = New Generic.List(Of RTMCService.TransactionDeliveryRejectResponseTransactionEntity)

                            RequestDate = TransactionStartDate

                            While RequestDate <= TransactionEndDate

                                TransactionID = Format(RequestDate, "yyyyMMddHHmmssff")

                                TransactionDeliveryRejectRequestTransactionEntity = New AdvantageFramework.RTMCService.TransactionDeliveryRejectRequestTransactionEntity

                                TransactionDeliveryRejectRequestTransactionEntity.accountNumberField = AccountID
                                TransactionDeliveryRejectRequestTransactionEntity.cardGroupField = -1
                                TransactionDeliveryRejectRequestTransactionEntity.companyNumberField = CompanyID
                                TransactionDeliveryRejectRequestTransactionEntity.outsourceIDField = OutsourceID
                                TransactionDeliveryRejectRequestTransactionEntity.transactionIDField = AdvantageFramework.StringUtilities.PadWithCharacter(TransactionID, 19, "0", True, True)

                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField = New RTMCService.TransactionDeliveryKeyFields
                                'TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.cardNumberField = ""

                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.lastReceivedField = New RTMCService.TransactionDeliveryLastReceived
                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.numberOfTransactionsRequestedField = 1000

                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionStartDateField = RequestDate.ToString("yyyyMMdd")
                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionStartTimeField = "00000001" 'TransactionStartDate.ToString("HHmmssff")

                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionEndDateField = RequestDate.ToString("yyyyMMdd")
                                TransactionDeliveryRejectRequestTransactionEntity.keyFieldsField.transactionEndTimeField = "23595999" 'TransactionEndDate.ToString("HHmmssff")

                                RejectRequests.Add(TransactionDeliveryRejectRequestTransactionEntity)

                                RequestDate = DateAdd(DateInterval.Day, 1, RequestDate)

                            End While

                            If RejectRequests.Count > 0 Then

                                TransactionDeliveryRejectResponseTransactionEntities.AddRange(RTMCServicev2.TransactionDeliveryReject(RejectRequests.ToArray))

                            End If

                            If PopulateVirtualCreditCardTransactionEFSDetail(TransactionDeliveryRejectResponseTransactionEntities, VirtualCreditCardTransactionEFSDetails, ErrorMessage, OffSetHours) Then

                                'MemoRequests = New Generic.List(Of AdvantageFramework.RTMCService.TransactionDeliveryMemoRequestTransactionEntity)

                                'RequestDate = TransactionStartDate

                                'While RequestDate <= TransactionEndDate

                                '    TransactionID = Format(RequestDate, "yyyyMMddHHmmssff")

                                '    TransactionDeliveryMemoRequestTransactionEntity = New AdvantageFramework.RTMCService.TransactionDeliveryMemoRequestTransactionEntity

                                '    TransactionDeliveryMemoRequestTransactionEntity.accountNumberField = AccountID
                                '    TransactionDeliveryMemoRequestTransactionEntity.cardGroupField = -1
                                '    TransactionDeliveryMemoRequestTransactionEntity.companyNumberField = CompanyID
                                '    TransactionDeliveryMemoRequestTransactionEntity.outsourceIDField = OutsourceID
                                '    TransactionDeliveryMemoRequestTransactionEntity.transactionIDField = AdvantageFramework.StringUtilities.PadWithCharacter(TransactionID, 19, "0", True, True)

                                '    TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField = New RTMCService.TransactionDeliveryKeyFields
                                '    'TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.cardNumberField = ""

                                '    TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.lastReceivedField = New RTMCService.TransactionDeliveryLastReceived
                                '    TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.numberOfTransactionsRequestedField = 1000

                                '    TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionStartDateField = RequestDate.ToString("yyyyMMdd")
                                '    TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionStartTimeField = "00000001" 'TransactionStartDate.ToString("HHmmssff")

                                '    TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionEndDateField = RequestDate.ToString("yyyyMMdd")
                                '    TransactionDeliveryMemoRequestTransactionEntity.keyFieldsField.transactionEndTimeField = "23595999" 'TransactionEndDate.ToString("HHmmssff")

                                '    MemoRequests.Add(TransactionDeliveryMemoRequestTransactionEntity)

                                '    RequestDate = DateAdd(DateInterval.Day, 1, RequestDate)

                                'End While

                                'PopulateVirtualCreditCardTransactionEFSDetail(RTMCServicev2.TransactionDeliveryMemo(MemoRequests.ToArray), VirtualCreditCardTransactionEFSDetails, ErrorMessage)

                            End If

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                End If

            End Using

            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                GetTransactionsForDataset = True

            Else

                GetTransactionsForDataset = False

            End If

        End Function
        Public Function GetTimezoneOffset(DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.VCC.Classes.TimezoneOffset

            Dim TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing

            TimezoneOffset = New AdvantageFramework.VCC.Classes.TimezoneOffset

            TimezoneOffset.AgencyOffset = AdvantageFramework.Database.Procedures.Generic.LoadAgencyHoursOffset(DbContext)
            TimezoneOffset.DatabaseOffset = AdvantageFramework.Database.Procedures.Generic.LoadSQLHoursOffset(DbContext)

            GetTimezoneOffset = TimezoneOffset

        End Function

#Region " Send Reminders "

        Public Function LoadDefaultCCSender(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim CCSender As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCCREM_CCSENDER.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                CCSender = Setting.Value

            End If

            LoadDefaultCCSender = CCSender

        End Function
        Public Function LoadDefaultEmailBody(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim EmailBody As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCCREM_EMAILBODY.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                EmailBody = Setting.Value

            End If

            LoadDefaultEmailBody = EmailBody

        End Function
        Public Function LoadDefaultEmailSubject(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim EmailSubject As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCCREM_EMAILSUBJECT.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                EmailSubject = Setting.Value

            End If

            LoadDefaultEmailSubject = EmailSubject

        End Function
        Public Function SaveDefaultCCSender(ByVal DataContext As AdvantageFramework.Database.DataContext, CCSender As Boolean) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCCREM_CCSENDER.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = CCSender

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.VCCREM_CCSENDER.ToString
                Setting.Value = CCSender
                Setting.OrderNumber = 2
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultCCSender = Saved

        End Function
        Public Function SaveDefaultEmailBody(ByVal DataContext As AdvantageFramework.Database.DataContext, EmailBody As String) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCCREM_EMAILBODY.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = EmailBody

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.VCCREM_EMAILBODY.ToString
                Setting.Value = EmailBody
                Setting.OrderNumber = 1
                Setting.SettingDatabaseTypeID = 11

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultEmailBody = Saved

        End Function
        Public Function SaveDefaultEmailSubject(ByVal DataContext As AdvantageFramework.Database.DataContext, EmailSubject As String) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCCREM_EMAILSUBJECT.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = EmailSubject

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.VCCREM_EMAILSUBJECT.ToString
                Setting.Value = EmailSubject
                Setting.OrderNumber = 0
                Setting.SettingDatabaseTypeID = 9

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultEmailSubject = Saved

        End Function

#End Region

#Region " CSI globalVCard "

        Private Function CreateVCCCreditCardCSI(Session As AdvantageFramework.Security.Session, GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder),
                                                NumberOfUses As Integer) As Boolean

            'objects
            Dim Token As String = Nothing
            Dim URL As String = Nothing
            Dim CardAmount As Decimal = 0
            Dim VCCCardsCreated As Boolean = False

            If IsVCCServiceSetup(Session) Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    If CreateToken(Session, DataContext, Token, URL) Then

                        URL = LoadVCCAPIUrl(DataContext)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            For Each GenerateOrder In GenerateOrders

                                CardAmount = 0

                                If GenerateOrder.TotalCostPayableToVendor.GetValueOrDefault(0) > 0 Then

                                    CardAmount = GenerateOrder.TotalCostPayableToVendor.GetValueOrDefault(0)

                                ElseIf GenerateOrder.VCCLimit.GetValueOrDefault(0) > 0 Then

                                    CardAmount = GenerateOrder.VCCLimit.GetValueOrDefault(0)

                                End If

                                If CardAmount > 0 Then

                                    CreateVirtualCreditCard(DbContext, URL, Token, CardAmount, Now.AddDays(179).Month, Now.AddDays(179).Year, NumberOfUses, GenerateOrder, Session, DataContext)

                                End If

                            Next

                        End Using

                        VCCCardsCreated = True

                        DeleteToken(URL, Token)

                    End If

                End Using

            Else

                For Each GenerateOrder In GenerateOrders

                    GenerateOrder.Status = False
                    GenerateOrder.OrderMessage = "VCC setting are not configured correctly."

                Next

            End If

            CreateVCCCreditCardCSI = VCCCardsCreated

        End Function
        Private Sub GetUserNamePassword(ByVal Session As AdvantageFramework.Security.Session, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                        ByRef UserName As String, ByRef Password As String)

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If LoadVCCUseSystemWideAccount(DataContext) Then

                UserName = LoadSystemWideVCCUserName(DataContext)
                Password = LoadSystemWideVCCPassword(DataContext)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                End Using

                If Employee IsNot Nothing Then

                    UserName = Employee.VCCUserName
                    Password = Employee.VCCPassword

                End If

            End If

        End Sub
        Private Function TestServiceConnection(Session As AdvantageFramework.Security.Session, DataContext As AdvantageFramework.Database.DataContext, ByRef ErrorMessage As String) As Boolean

            Dim Token As String = Nothing
            Dim URL As String = Nothing
            Dim Connected As Boolean = False

            Try

                If CreateToken(Session, DataContext, Token, URL) Then

                    Connected = True

                    DeleteToken(URL, Token)

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message
            End Try

            TestServiceConnection = Connected

        End Function
        Private Function CreateToken(Session As AdvantageFramework.Security.Session, DataContext As AdvantageFramework.Database.DataContext,
                                     ByRef Token As String, ByRef URL As String) As Boolean

            Dim UserName As String = Nothing
            Dim Password As String = Nothing
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim JsonDeserializer As RestSharp.Deserializers.JsonDeserializer = Nothing
            Dim Dictionary As Dictionary(Of String, String) = Nothing
            Dim TokenCreated As Boolean = False

            GetUserNamePassword(Session, DataContext, UserName, Password)
            URL = LoadVCCAPIUrl(DataContext)

            Try

                RestClient = New RestSharp.RestClient(URL)

                RestRequest = New RestSharp.RestRequest("v2/tokens", RestSharp.Method.POST)

                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestRequest.AddHeader("Accept", "application/json")
                RestRequest.AddHeader("Content-Type", "application/json")

                RestRequest.AddBody(New With {.username = UserName, .password = Password})

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    JsonDeserializer = New RestSharp.Deserializers.JsonDeserializer
                    Dictionary = JsonDeserializer.Deserialize(Of Dictionary(Of String, String))(RestResponse)

                    Token = Dictionary.Item("token")

                    TokenCreated = True

                End If

            Catch ex As Exception
                TokenCreated = False
            Finally
                CreateToken = TokenCreated
            End Try

        End Function
        Private Function DeleteToken(URL As String, Token As String) As Boolean

            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim JsonDeserializer As RestSharp.Deserializers.JsonDeserializer = Nothing
            Dim Dictionary As Dictionary(Of String, String) = Nothing
            Dim Deleted As Boolean = False

            Try

                RestClient = New RestSharp.RestClient(URL)

                RestRequest = New RestSharp.RestRequest("v2/tokens", RestSharp.Method.DELETE)

                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestRequest.AddHeader("Accept", "application/json")
                RestRequest.AddHeader("Content-Type", "application/json")
                RestRequest.AddHeader("AUTH", Token)

                RestResponse = RestClient.Execute(RestRequest)

                JsonDeserializer = New RestSharp.Deserializers.JsonDeserializer
                Dictionary = JsonDeserializer.Deserialize(Of Dictionary(Of String, String))(RestResponse)

                If Dictionary.Item("success") = "True" Then

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteToken = Deleted
            End Try

        End Function
        Private Sub CreateVirtualCreditCard(DbContext As AdvantageFramework.Database.DbContext, URL As String, Token As String,
                                            Amount As Decimal, ExpirationMonth As Short, ExpirationYear As Short,
                                            NumberOfTransactions As Integer, GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder,
                                            Session As AdvantageFramework.Security.Session, DataContext As AdvantageFramework.Database.DataContext)

            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim JsonDeserializer As RestSharp.Deserializers.JsonDeserializer = Nothing
            Dim Dictionary As Dictionary(Of String, String) = Nothing
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing

            Try

                RestClient = New RestSharp.RestClient(URL)

                RestRequest = New RestSharp.RestRequest("v2/virtualCards", RestSharp.Method.POST)

                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestRequest.AddHeader("Accept", "application/json")
                RestRequest.AddHeader("Content-Type", "application/json")
                RestRequest.AddHeader("AUTH", Token)

                RestRequest.AddBody(New With {.amount = Amount, .exactAmount = "false", .numberOfTransactions = NumberOfTransactions, .firstName = "Virtual", .lastName = "Card",
                                        .expirationMonth = ExpirationMonth, .expirationYear = ExpirationYear})

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then 'no error

                    JsonDeserializer = New RestSharp.Deserializers.JsonDeserializer
                    Dictionary = JsonDeserializer.Deserialize(Of Dictionary(Of String, String))(RestResponse)

                    VCCCard = New AdvantageFramework.Database.Entities.VCCCard

                    VCCCard.VCCProviderID = VCCProviders.CSI
                    VCCCard.CardNumber = AdvantageFramework.Security.Encryption.ASCIIEncoding(Dictionary.Item("cardNumber"))
                    VCCCard.CVCCode = AdvantageFramework.Security.Encryption.ASCIIEncoding(Dictionary.Item("cvc2"))
                    VCCCard.CardAmount = Dictionary.Item("amount")
                    VCCCard.NumberOfUses = Dictionary.Item("numberOfTransactions")
                    VCCCard.ExpirationDate = DateSerial(Dictionary.Item("expirationMMYY").ToString.Substring(2, 2), Dictionary.Item("expirationMMYY").ToString.Substring(0, 2), 1)
                    VCCCard.OrderNumber = GenerateOrder.OrderNumber
                    VCCCard.LineNumber = GenerateOrder.LineNumber
                    VCCCard.Status = "A"
                    VCCCard.CreatedByUserCode = DbContext.UserCode
                    VCCCard.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                    VCCCard.CardCTS = Dictionary.Item("id")

                    AdvantageFramework.Database.Procedures.VCCCard.Insert(DbContext, VCCCard, Nothing)

                    GenerateOrder.SetVCCCard(VCCCard)

                    GetCardActivity(DbContext, URL, Token, VCCCard)

                Else

                    GenerateOrder.Status = False
                    GenerateOrder.OrderMessage = "Failed to generate VCC from provider."

                End If

            Catch ex As Exception
                GenerateOrder.Status = False
                GenerateOrder.OrderMessage = "Failed to generate VCC from provider."
            End Try

        End Sub
        Private Function GetCardActivity(DbContext As AdvantageFramework.Database.DbContext, URL As String, Token As String,
                                         VCCCard As AdvantageFramework.Database.Entities.VCCCard) As Boolean

            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim JsonDeserializer As RestSharp.Deserializers.JsonDeserializer = Nothing
            Dim Dictionary As Dictionary(Of String, String) = Nothing
            Dim ActivityUpdated As Boolean = False
            Dim CSICardActivityList As Generic.List(Of AdvantageFramework.VCC.Classes.CSICardActivity) = Nothing
            Dim VCCCardDetail As AdvantageFramework.Database.Entities.VCCCardDetail = Nothing

            Try

                RestClient = New RestSharp.RestClient(URL)

                RestRequest = New RestSharp.RestRequest("v2/virtualCards/{id}/activity", RestSharp.Method.GET)

                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestRequest.AddHeader("Accept", "application/json")
                RestRequest.AddHeader("Content-Type", "application/json")
                RestRequest.AddHeader("Auth", Token)
                RestRequest.AddUrlSegment("id", VCCCard.CardCTS)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    CSICardActivityList = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.VCC.Classes.CSICardActivity))(RestResponse.Content)

                    For Each CSICardActivity In CSICardActivityList

                        VCCCardDetail = AdvantageFramework.Database.Procedures.VCCCardDetail.LoadByIDAndReferenceNumber(DbContext, VCCCard.ID, CSICardActivity.id)

                        If VCCCardDetail Is Nothing Then

                            VCCCardDetail = New AdvantageFramework.Database.Entities.VCCCardDetail

                            VCCCardDetail.ID = VCCCard.ID
                            VCCCardDetail.ReferenceNumber = CSICardActivity.id
                            VCCCardDetail.CreatedByUserCode = DbContext.UserCode
                            VCCCardDetail.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                            VCCCardDetail.MerchantName = CSICardActivity.merchantName

                            Select Case CSICardActivity.transactionStatus

                                Case "Cleared", "Posted"

                                    VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction
                                    VCCCardDetail.Amount = CSICardActivity.postedAmount
                                    VCCCardDetail.ProcessDateTime = CSICardActivity.transactionDate

                                Case "Created"

                                    VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.CreditCardRequest
                                    VCCCardDetail.Amount = CSICardActivity.preAuthAmount
                                    VCCCardDetail.ProcessDateTime = CSICardActivity.transactionDate

                                Case "Declined"

                                    VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction
                                    VCCCardDetail.Amount = CSICardActivity.preAuthAmount
                                    VCCCardDetail.ProcessDateTime = CSICardActivity.transactionDate

                                Case "Authorized"

                                    VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.PendingTransaction
                                    VCCCardDetail.Amount = CSICardActivity.preAuthAmount
                                    VCCCardDetail.ProcessDateTime = CSICardActivity.transactionDate

                            End Select

                            AdvantageFramework.Database.Procedures.VCCCardDetail.Insert(DbContext, VCCCardDetail, Nothing)

                        End If

                    Next

                    ActivityUpdated = True

                End If

            Catch ex As Exception
                ActivityUpdated = False
            Finally
                GetCardActivity = ActivityUpdated
            End Try

        End Function
        Private Function UpdateVCCCreditCardCSI(Session As AdvantageFramework.Security.Session, VCCOrderList As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder),
                                                ByRef ErrorMessage As String) As Boolean

            Dim VCCCardsUpdated As Boolean = False
            Dim URL As String = Nothing
            Dim Token As String = Nothing
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing
            Dim AmountFailure As Boolean = False
            Dim StatusFailure As Boolean = False

            If IsVCCServiceSetup(Session) Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    If CreateToken(Session, DataContext, Token, URL) Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            For Each VCCOrder In VCCOrderList

                                VCCCard = VCCOrder.GetVCCCardEntity()

                                If VCCOrder.CardAmount <> VCCOrder.OriginalCardAmount Then

                                    If Not UpdateCard(URL, Token, VCCCard, DbContext) Then

                                        AmountFailure = True

                                    End If

                                End If

                                If VCCOrder.CardStatus <> VCCOrder.OriginalStatus Then

                                    If VCCOrder.CardStatus <> "A" Then

                                        If Not BlockCard(URL, Token, VCCCard, DbContext) Then

                                            StatusFailure = True

                                        End If

                                    Else

                                        If Not UnblockCard(URL, Token, VCCCard, DbContext) Then

                                            StatusFailure = True

                                        End If

                                    End If

                                End If

                            Next

                        End Using

                        If Not StatusFailure AndAlso Not AmountFailure Then

                            VCCCardsUpdated = True

                        Else

                            ErrorMessage = "One or more cards failed to update."

                        End If

                        DeleteToken(URL, Token)

                    End If

                End Using

            Else

                For Each VCCOrder In VCCOrderList

                    VCCOrder.VCCUpdateMessage = "Failed to connect to VCC for card update."

                Next

            End If

            UpdateVCCCreditCardCSI = VCCCardsUpdated

        End Function
        Private Function UpdateVCCCreditCardCSI(Session As AdvantageFramework.Security.Session, VCCCardList As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard),
                                                ByRef ErrorMessage As String) As Boolean

            Dim VCCCardsUpdated As Boolean = False
            Dim URL As String = Nothing
            Dim Token As String = Nothing
            Dim AmountFailure As Boolean = False

            If IsVCCServiceSetup(Session) Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    If CreateToken(Session, DataContext, Token, URL) Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            For Each VCCCard In VCCCardList

                                If Not UpdateCard(URL, Token, VCCCard, DbContext) Then

                                    AmountFailure = True

                                End If

                            Next

                        End Using

                        If Not AmountFailure Then

                            VCCCardsUpdated = True

                        Else

                            ErrorMessage = "One or more cards failed to update."

                        End If

                        DeleteToken(URL, Token)

                    End If

                End Using

            Else

                ErrorMessage = "Failed to saving data from VCC to Advantage."

            End If

            UpdateVCCCreditCardCSI = VCCCardsUpdated

        End Function
        Private Function BlockCard(URL As String, Token As String, VCCCard As AdvantageFramework.Database.Entities.VCCCard,
                                   DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim Blocked As Boolean = False

            Try

                RestClient = New RestSharp.RestClient(URL)

                RestRequest = New RestSharp.RestRequest("v2/virtualCards/{id}/block", RestSharp.Method.PUT)

                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestRequest.AddHeader("Accept", "application/json")
                RestRequest.AddHeader("Content-Type", "application/json")
                RestRequest.AddHeader("Auth", Token)
                RestRequest.AddUrlSegment("id", VCCCard.CardCTS)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.VCC_CARD SET [STATUS] = '{1}' WHERE VCC_CARD_ID = {0}", VCCCard.ID, VCCCard.Status))

                    Blocked = True

                End If

            Catch ex As Exception
                Blocked = False
            Finally
                BlockCard = Blocked
            End Try

        End Function
        Private Function UnblockCard(URL As String, Token As String, VCCCard As AdvantageFramework.Database.Entities.VCCCard,
                                     DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim Unblocked As Boolean = False

            Try

                RestClient = New RestSharp.RestClient(URL)

                RestRequest = New RestSharp.RestRequest("v2/virtualCards/{id}/unblock", RestSharp.Method.PUT)

                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestRequest.AddHeader("Accept", "application/json")
                RestRequest.AddHeader("Content-Type", "application/json")
                RestRequest.AddHeader("Auth", Token)
                RestRequest.AddUrlSegment("id", VCCCard.CardCTS)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.VCC_CARD SET [STATUS] = 'A' WHERE VCC_CARD_ID = {0}", VCCCard.ID))

                    Unblocked = True

                End If

            Catch ex As Exception
                Unblocked = False
            Finally
                UnblockCard = Unblocked
            End Try

        End Function
        Private Function UpdateCard(URL As String, Token As String, VCCCard As AdvantageFramework.Database.Entities.VCCCard,
                                    DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim Updated As Boolean = False

            Try

                RestClient = New RestSharp.RestClient(URL)

                RestRequest = New RestSharp.RestRequest("v2/virtualCards/{id}", RestSharp.Method.PUT)

                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestRequest.AddHeader("Accept", "application/json")
                RestRequest.AddHeader("Content-Type", "application/json")
                RestRequest.AddHeader("Auth", Token)
                RestRequest.AddUrlSegment("id", VCCCard.CardCTS)

                RestRequest.AddBody(New With {.amount = VCCCard.CardAmount})

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.VCC_CARD SET CARD_AMOUNT = {1} WHERE VCC_CARD_ID = {0}", VCCCard.ID, VCCCard.CardAmount))

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateCard = Updated
            End Try

        End Function

#End Region

#End Region

    End Module

End Namespace
