Namespace Security.LicenseKey

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Types
            All = 0
            PowerUser = 1
            WebvantageOnly = 2
            ClientPortalUser = 3
        End Enum

#End Region

#Region " Variables "

        'Private _Rfc2898DeriveBytes As System.Security.Cryptography.Rfc2898DeriveBytes = Nothing
        'Private _32Bytes As Byte() = Nothing
        'Private _16Bytes As Byte() = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "
        Public Function ImportLicenseKey(ByVal Session As AdvantageFramework.Security.Session, ByVal File As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim LicenseKeyImported As Boolean = False
            Dim LicenseKey As String = ""
            Dim EncryptedLicenseKey As String = ""
            Dim ReadFile As Boolean = False
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim DatabaseDetail As AdvantageFramework.Database.MasterDatabase.Entities.DatabaseDetail = Nothing
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim EnableProofingTool As Boolean = False
            Dim AgencyName As String = ""
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim LicenseKeyFileExpireDate As Date = Nothing
            Dim ServerDate As Date = Nothing
            Dim VerifiedPowerUsersAmount As Integer = 0
            Dim VerifiedWVOnlyUsersAmount As Integer = 0
            Dim VerifiedMediaToolsUsersAmount As Integer = 0
            Dim VerifiedAPIUsersAmount As Integer = 0
            Dim VerifiedClientPortalUsersAmount As Integer = 0
            Dim VerifiedUsersChecked As Boolean = True

            Try

                FileInfo = My.Computer.FileSystem.GetFileInfo(File)

            Catch ex As Exception
                FileInfo = Nothing
            End Try

            If FileInfo IsNot Nothing Then

                Try

                    EncryptedLicenseKey = FileInfo.OpenText.ReadToEnd

                    ReadFile = True

                Catch ex As Exception
                    ReadFile = False
                End Try

                If ReadFile Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Using MasterDataContext = New AdvantageFramework.Database.MasterDatabase.DataContext(Session.ConnectionString, Session.UserCode)

                            LicenseKey = AdvantageFramework.Security.LicenseKey.Read(EncryptedLicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires,
                                                                                     PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity,
                                                                                     AgencyName, 0, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage)

                            LicenseKeyFileExpireDate = LicenseKeyDate.AddDays(DaysUntilFileExpires)

                            Try

                                ServerDate = DbContext.Database.SqlQuery(Of Date)("SELECT GETDATE()").FirstOrDefault

                            Catch ex As Exception
                                ServerDate = Now
                            End Try

                            If DateDiff(DateInterval.Day, ServerDate, LicenseKeyFileExpireDate) >= 0 Then

                                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                    If PowerUsersQuantity > -1 OrElse WVOnlyUsersQuantity > -1 Then

                                        AdvantageFramework.Security.LicenseKey.CalculateAvailableUserQuantities(Session, PowerUsersQuantity, WVOnlyUsersQuantity,
                                                                                                                VerifiedPowerUsersAmount, VerifiedWVOnlyUsersAmount)

                                        If PowerUsersQuantity > -1 Then

                                            If VerifiedPowerUsersAmount > PowerUsersQuantity Then

                                                ErrorMessage = "Need to adjust your Power users. Your new license key has " & PowerUsersQuantity & " Power users and currently have " & VerifiedPowerUsersAmount & " Power users.  Please adjust this and try again."
                                                VerifiedUsersChecked = False

                                            End If

                                        End If

                                        If WVOnlyUsersQuantity > -1 Then

                                            If VerifiedWVOnlyUsersAmount > WVOnlyUsersQuantity Then

                                                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                                    ErrorMessage = "Need to adjust your standard users. Your new license key has " & WVOnlyUsersQuantity & " standard users and currently have " & VerifiedWVOnlyUsersAmount & " standard users.  Please adjust this and try again."

                                                Else

                                                    ErrorMessage &= Environment.NewLine & "Need to adjust your standard users. Your new license key has " & WVOnlyUsersQuantity & " standard users and currently have " & VerifiedWVOnlyUsersAmount & " standard users.  Please adjust this and try again."

                                                End If

                                                VerifiedUsersChecked = False

                                            End If

                                        End If

                                    End If

                                End If

                                If MediaToolsUsersQuantity > -1 Then

                                    If CheckForVerifiedMediaToolsUsers(Session, MediaToolsUsersQuantity, VerifiedMediaToolsUsersAmount) = False Then

                                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                            ErrorMessage = "Need to adjust your Media Tools users. Your new license key has " & MediaToolsUsersQuantity & " Media Tool users and currently have " & VerifiedMediaToolsUsersAmount & " Media Tools users.  Please adjust this and try again."

                                        Else

                                            ErrorMessage &= Environment.NewLine & "Need to adjust your Media Tools users. Your new license key has " & MediaToolsUsersQuantity & " Media Tool users and currently have " & VerifiedMediaToolsUsersAmount & " Media Tools users.  Please adjust this and try again."

                                        End If

                                        VerifiedUsersChecked = False

                                    End If

                                End If

                                If APIUsersQuantity > -1 Then

                                    If CheckForVerifiedAPIUsers(Session, APIUsersQuantity, VerifiedAPIUsersAmount) = False Then

                                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                            ErrorMessage = "Need to adjust your API users. Your new license key has " & APIUsersQuantity & " API users and currently have " & VerifiedAPIUsersAmount & " API users.  Please adjust this and try again."

                                        Else

                                            ErrorMessage &= Environment.NewLine & "Need to adjust your API users. Your new license key has " & APIUsersQuantity & " API users and currently have " & VerifiedAPIUsersAmount & " API users.  Please adjust this and try again."

                                        End If

                                        VerifiedUsersChecked = False

                                    End If

                                End If

                                If ClientPortalUsersQuantity > -1 Then

                                    If CheckForVerifiedClientPortalUsers(Session, ClientPortalUsersQuantity, VerifiedClientPortalUsersAmount) = False Then

                                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                            ErrorMessage = "Need to adjust your Client Portal users. Your new license key has " & ClientPortalUsersQuantity & " Client Portal users and currently have " & VerifiedClientPortalUsersAmount & " Client Portal users.  Please adjust this and try again."

                                        Else

                                            ErrorMessage &= Environment.NewLine & "Need to adjust your Client Portal users. Your new license key has " & ClientPortalUsersQuantity & " Client Portal users and currently have " & VerifiedClientPortalUsersAmount & " Client Portal users.  Please adjust this and try again."

                                        End If

                                        VerifiedUsersChecked = False

                                    End If

                                End If

                                If VerifiedUsersChecked Then

                                    Try

                                        DatabaseDetail = MasterDataContext.DatabaseDetails.Where(Function(DBDetail) DBDetail.Name = MasterDataContext.Connection.Database).SingleOrDefault

                                    Catch ex As Exception
                                        DatabaseDetail = Nothing
                                    End Try

                                    If DatabaseDetail IsNot Nothing Then

                                        EncryptedLicenseKey = AdvantageFramework.Security.LicenseKey.Create(DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity,
                                                                                                            WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName,
                                                                                                            DatabaseDetail.ID, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool)

                                        If DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AGENCY SET NAME = '{0}', LICENSE_KEY = '{1}'", AgencyName.Replace("'", "''"), EncryptedLicenseKey)) > 0 Then

                                            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString)

                                                If Setting IsNot Nothing Then

                                                    If Setting.Value <> 1 Then

                                                        Setting.Value = 1

                                                        AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                                                    End If

                                                Else

                                                    Setting = New AdvantageFramework.Database.Entities.Setting

                                                    Setting.Code = AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString
                                                    Setting.Description = "New License Key Setting"
                                                    Setting.Value = 1
                                                    Setting.DefaultValue = 0
                                                    Setting.MinimumValue = 0
                                                    Setting.MaximumValue = 1
                                                    Setting.SettingModuleID = Nothing
                                                    Setting.SettingModuleTabID = Nothing
                                                    Setting.SettingModuleGroupID = Nothing
                                                    Setting.OrderNumber = Nothing
                                                    Setting.SettingDatabaseTypeID = 16

                                                    AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

                                                End If

                                            End Using

                                            ErrorMessage = "License key imported successfully."
                                            LicenseKeyImported = True

                                        Else

                                            ErrorMessage = "Failed to update license key."

                                        End If

                                    Else

                                        ErrorMessage = "Failed loading database information.  Please contact Advantage support."

                                    End If

                                End If
                                
                            Else

                                ErrorMessage = "Invalid license key file. The file has exceeded its expiration date."

                            End If

                        End Using

                    End Using

                Else

                    ErrorMessage = "Failed when reading from file."

                End If

            Else

                ErrorMessage = "Failed to load file information."

            End If

            ImportLicenseKey = LicenseKeyImported

        End Function
        Private Function CheckForVerifiedMediaToolsUsers(ByVal Session As AdvantageFramework.Security.Session, ByVal MediaToolsUsersQuantity As Integer, ByRef VerifiedMediaToolsUsersAmount As Integer) As Boolean

            'objects
            Dim ValidAmountOfMediaToolsUsers As Boolean = False
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim UserSettings As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting) = Nothing
            Dim Users As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        UserSettings = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadBySettingCode(SecurityDbContext, AdvantageFramework.Security.UserSettings.IsMediaToolsUser.ToString).ToList

                    Catch ex As Exception
                        UserSettings = Nothing
                    End Try

                    Try

                        Users = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).ToList

                    Catch ex As Exception
                        Users = Nothing
                    End Try

                    If UserSettings IsNot Nothing AndAlso Users IsNot Nothing Then

                        For Each User In Users

                            Try

                                UserSetting = UserSettings.SingleOrDefault(Function(Entity) Entity.UserID = User.ID)

                            Catch ex As Exception
                                UserSetting = Nothing
                            End Try

                            If UserSetting IsNot Nothing Then

                                If IsMediaToolUser(User.UserCode, UserSetting.StringValue) Then

                                    VerifiedMediaToolsUsersAmount += 1

                                End If

                            End If

                        Next

                    End If

                End Using

            Catch ex As Exception
                VerifiedMediaToolsUsersAmount = 0
            End Try

            If VerifiedMediaToolsUsersAmount <= MediaToolsUsersQuantity Then

                ValidAmountOfMediaToolsUsers = True

            End If

            CheckForVerifiedMediaToolsUsers = ValidAmountOfMediaToolsUsers

        End Function
        Private Function CheckForVerifiedAPIUsers(ByVal Session As AdvantageFramework.Security.Session, ByVal APIUsersQuantity As Integer, ByRef VerifiedAPIUsersAmount As Integer) As Boolean

            'objects
            Dim ValidAmountOfAPIUsers As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    For Each Employee In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

                        If AdvantageFramework.Security.IsAPIUser(Employee.Code, Employee.IsAPIUser) Then

                            VerifiedAPIUsersAmount += 1

                        End If

                    Next

                End Using

            Catch ex As Exception
                VerifiedAPIUsersAmount = 0
            End Try

            If VerifiedAPIUsersAmount <= APIUsersQuantity Then

                ValidAmountOfAPIUsers = True

            End If

            CheckForVerifiedAPIUsers = ValidAmountOfAPIUsers

        End Function
        Private Function CheckForVerifiedClientPortalUsers(ByVal Session As AdvantageFramework.Security.Session, ByVal ClientPortalUsersQuantity As Integer, ByRef VerifiedClientPortalUsersAmount As Integer) As Boolean

            'objects
            Dim ValidAmountOfClientPortalUsers As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    VerifiedClientPortalUsersAmount = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Load(SecurityDbContext).Count

                End Using

            Catch ex As Exception
                VerifiedClientPortalUsersAmount = 0
            End Try

            If VerifiedClientPortalUsersAmount <= ClientPortalUsersQuantity Then

                ValidAmountOfClientPortalUsers = True

            End If

            CheckForVerifiedClientPortalUsers = ValidAmountOfClientPortalUsers

        End Function
        Public Function CheckForValidLicenseKey(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef LicenseKey As String,
                                               ByRef LicenseKeyDate As Date, ByRef DaysUntilFileExpires As Integer, ByRef DaysUntilKeyExpires As Integer,
                                               ByRef PowerUsersQuantity As Integer, ByRef WVOnlyUsersQuantity As Integer,
                                               ByRef ClientPortalUsersQuantity As Integer, ByRef AgencyName As String,
                                               ByRef DatabaseID As Integer, ByRef MediaToolsUsersQuantity As Integer, ByRef APIUsersQuantity As Integer,
                                               ByRef EnableProofingTool As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValidLicenseKey As Boolean = False
            Dim LicenseKeyExpireDate As Date = Nothing
            Dim ServerDate As Date = Nothing
            Dim SavedLicenseKey As String = ""

            SavedLicenseKey = AdvantageFramework.Database.Procedures.Agency.LoadLicenseKey(DbContext)

            If SavedLicenseKey <> "" Then

                LicenseKey = AdvantageFramework.Security.LicenseKey.Read(SavedLicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires,
                                                                         PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName,
                                                                         DatabaseID, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage)

                If LicenseKey <> "" Then

                    LicenseKeyExpireDate = LicenseKeyDate.AddDays(DaysUntilKeyExpires)

                    Try

                        ServerDate = DbContext.Database.SqlQuery(Of Date)("SELECT GETDATE()").FirstOrDefault

                    Catch ex As Exception
                        ServerDate = Now
                    End Try

                    If DateDiff(DateInterval.Day, CDate(ServerDate.ToShortDateString), LicenseKeyExpireDate) >= 0 Then

                        IsValidLicenseKey = True

                    Else

                        ErrorMessage = "Error 999: Software key mismatch. Please ask your administrator to contact Advantage support for assistance with this error."

                    End If

                Else

                    ErrorMessage = "Invalid license key. Please contact Advantage support.  " & ErrorMessage

                End If

            Else

                ErrorMessage = "Failed to load license key information. Please contact Advantage support."

            End If

            CheckForValidLicenseKey = IsValidLicenseKey

        End Function
        Public Function CheckToNotifyUserOfLicenseKey(ByVal Session As AdvantageFramework.Security.Session, ByRef MessageText As String) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim AgencyLicenseKey As String = ""
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim EnableProofingTool As Boolean = False
            Dim AgencyName As String = ""
            Dim LicenseKey As String = ""
            Dim DatabaseID As Integer = 0
            Dim LicenseKeyExpireDate As Date = Nothing
            Dim NotifyUserOfLicenseKey As Boolean = False
            Dim ServerDate As Date = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    AgencyLicenseKey = DbContext.Database.SqlQuery(Of String)("SELECT LICENSE_KEY FROM dbo.AGENCY").FirstOrDefault

                Catch ex As Exception
                    AgencyLicenseKey = ""
                End Try

                If AgencyLicenseKey <> "" Then

                    LicenseKey = AdvantageFramework.Security.LicenseKey.Read(AgencyLicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires,
                                                                             PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName,
                                                                             DatabaseID, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, MessageText)

                    If LicenseKey <> "" Then

                        LicenseKeyExpireDate = LicenseKeyDate.AddDays(DaysUntilKeyExpires)

                        Try

                            ServerDate = DbContext.Database.SqlQuery(Of Date)("SELECT GETDATE()").FirstOrDefault

                        Catch ex As Exception
                            ServerDate = Now
                        End Try

						If DateDiff(DateInterval.Day, CDate(ServerDate.ToShortDateString), LicenseKeyExpireDate) < 15 Then

							Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

								Try

									UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.RemindUserOfLicenseKeyRenewal.ToString)

								Catch ex As Exception
									UserSetting = Nothing
								End Try

								If UserSetting IsNot Nothing Then

									If UserSetting.StringValue = "Y" Then

										If DateDiff(DateInterval.Day, CDate(ServerDate.ToShortDateString), CDate(UserSetting.DateValue.GetValueOrDefault(Now).ToShortDateString)) <= 0 Then

											NotifyUserOfLicenseKey = True

										End If

									End If

								Else

									NotifyUserOfLicenseKey = True

								End If

								If NotifyUserOfLicenseKey Then

									MessageText = String.Format("Your Advantage license key is due for renewal in {0} days. Please notify your system administrator to contact Advantage support to obtain an updated key.", DateDiff(DateInterval.Day, CDate(ServerDate.ToShortDateString), LicenseKeyExpireDate))

								End If

							End Using

						End If

					End If

                End If

            End Using

            CheckToNotifyUserOfLicenseKey = NotifyUserOfLicenseKey

        End Function
        Public Function LoadConnectedUsers(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal LicenseKeyType As AdvantageFramework.Security.LicenseKey.Types) As Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser)

            'objects
            Dim ConnectedUsersList As Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser) = Nothing
            Dim AdvantageUserLicenseInUseList As Generic.List(Of AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse) = Nothing
            Dim UsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
            Dim ClientContactsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.ClientContact) = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact = Nothing
            Dim UserID As Integer = 0
            Dim ApplicationID As Integer = 0
            Dim CreatedDate As Date = Nothing
            Dim MACAddressOrSessionID As String = ""
            Dim SPID As Integer = 0
            Dim WorkstationName As String = ""

            ConnectedUsersList = New Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser)

            If LicenseKeyType = Types.PowerUser Then

                AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.PowerUser).ToList

                UsersList = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee").ToList

            ElseIf LicenseKeyType = Types.WebvantageOnly Then

                AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.WebvantageOnly).ToList

                UsersList = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee").ToList

            ElseIf LicenseKeyType = Types.ClientPortalUser Then

                AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.ClientPortalUser).ToList

                ClientContactsList = AdvantageFramework.Security.Database.Procedures.ClientContact.Load(SecurityDbContext).ToList

            End If

            For Each AdvantageUserLicenseInUse In AdvantageUserLicenseInUseList

                UserID = 0
                ApplicationID = 0
                CreatedDate = Nothing
                MACAddressOrSessionID = ""
                SPID = 0
                WorkstationName = ""

                If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                    If LicenseKeyType = Types.PowerUser OrElse LicenseKeyType = Types.WebvantageOnly Then

                        Try

                            User = UsersList.SingleOrDefault(Function(Entity) Entity.ID = UserID)

                        Catch ex As Exception
                            User = Nothing
                        End Try

                        If User IsNot Nothing Then

                            If ConnectedUsersList.Any(Function(ConnectedUser) ConnectedUser.UserID = User.ID) = False Then

                                ConnectedUsersList.Add(New AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser(User, ApplicationID, CreatedDate))

                            End If

                        End If

                    Else

                        Try

                            ClientContact = ClientContactsList.SingleOrDefault(Function(Entity) Entity.ContactID = UserID)

                        Catch ex As Exception
                            ClientContact = Nothing
                        End Try

                        If ClientContact IsNot Nothing Then

                            If ConnectedUsersList.Any(Function(ConnectedUser) ConnectedUser.UserID = ClientContact.ContactID) = False Then

                                ConnectedUsersList.Add(New AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser(ClientContact, ApplicationID, CreatedDate))

                            End If

                        End If

                    End If

                End If

            Next

            LoadConnectedUsers = ConnectedUsersList

        End Function
        Public Function LoadConnectedUsers(ByVal Session As AdvantageFramework.Security.Session, ByVal LicenseKeyType As AdvantageFramework.Security.LicenseKey.Types) As Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser)

            'objects
            Dim ConnectedUsersList As Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser) = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ConnectedUsersList = LoadConnectedUsers(SecurityDbContext, LicenseKeyType)

            End Using

            LoadConnectedUsers = ConnectedUsersList

        End Function
        Public Function LoadAllConnectedUsers(ByVal Session As AdvantageFramework.Security.Session, ByVal LicenseKeyType As AdvantageFramework.Security.LicenseKey.Types) As Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser)

            'objects
            Dim ConnectedUsersList As Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser) = Nothing
            Dim AdvantageUserLicenseInUseList As Generic.List(Of AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse) = Nothing
            Dim UsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
            Dim ClientContactsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.ClientContact) = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact = Nothing
            Dim UserID As Integer = 0
            Dim ApplicationID As Integer = 0
            Dim CreatedDate As Date = Nothing
            Dim MACAddressOrSessionID As String = ""
            Dim SPID As Integer = 0
            Dim WorkstationName As String = ""

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ConnectedUsersList = New Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser)

                If LicenseKeyType = Types.PowerUser Then

                    AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.PowerUser).ToList

                    UsersList = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee").ToList

                ElseIf LicenseKeyType = Types.WebvantageOnly Then

                    AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.WebvantageOnly).ToList

                    UsersList = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee").ToList

                ElseIf LicenseKeyType = Types.ClientPortalUser Then

                    AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.ClientPortalUser).ToList

                    ClientContactsList = AdvantageFramework.Security.Database.Procedures.ClientContact.Load(SecurityDbContext).ToList

                End If

                For Each AdvantageUserLicenseInUse In AdvantageUserLicenseInUseList

                    UserID = 0
                    ApplicationID = 0
                    CreatedDate = Nothing
                    MACAddressOrSessionID = ""
                    SPID = 0
                    WorkstationName = ""

                    If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                        If LicenseKeyType = Types.PowerUser OrElse LicenseKeyType = Types.WebvantageOnly Then

                            Try

                                User = UsersList.SingleOrDefault(Function(Entity) Entity.ID = UserID)

                            Catch ex As Exception
                                User = Nothing
                            End Try

                            If User IsNot Nothing Then

                                ConnectedUsersList.Add(New AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser(User, ApplicationID, CreatedDate))

                            End If

                        Else

                            Try

                                ClientContact = ClientContactsList.SingleOrDefault(Function(Entity) Entity.ContactID = UserID)

                            Catch ex As Exception
                                ClientContact = Nothing
                            End Try

                            If ClientContact IsNot Nothing Then

                                ConnectedUsersList.Add(New AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser(ClientContact, ApplicationID, CreatedDate))

                            End If


                        End If

                    End If

                Next

            End Using

            LoadAllConnectedUsers = ConnectedUsersList

        End Function
        Public Function ClearUser(ByVal Session As AdvantageFramework.Security.Session, ByVal UserID As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Cleared As Boolean = False
            Dim AdvantageUserLicenseInUseList As Generic.List(Of AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse) = Nothing
            Dim LicenseUserID As Integer = 0
            Dim ApplicationID As Integer = 0
            Dim CreatedDate As Date = Nothing
            Dim MACAddressOrSessionID As String = ""
            Dim SPID As Integer = 0
            Dim WorkstationName As String = ""
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString)

                    If Setting IsNot Nothing Then

                        If Setting.Value = 1 Then

                            AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Load(SecurityDbContext).ToList

                            For Each AdvantageUserLicenseInUse In AdvantageUserLicenseInUseList

                                LicenseUserID = 0
                                ApplicationID = 0
                                CreatedDate = Nothing
                                MACAddressOrSessionID = ""
                                SPID = 0
                                WorkstationName = ""

                                If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, LicenseUserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                                    If LicenseUserID = UserID Then

                                        Cleared = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete(SecurityDbContext, AdvantageUserLicenseInUse)
                                        If Cleared = True Then
                                            AdvantageFramework.Security.AddWebvantageEventLog("AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete called from " & _
                                                                                              "AdvantageFramework.Security.LicenseKey.ClearUser.  " & _
                                                                                              UserID & ", " & ApplicationID & ", " & MACAddressOrSessionID)
                                        End If

                                    End If

                                End If

                            Next

                        Else

                            Cleared = True

                        End If

                    Else

                        Cleared = True

                    End If

                End Using

            End Using

            ClearUser = Cleared

        End Function
        Public Function ClearAllUsers(Session As AdvantageFramework.Security.Session, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Cleared As Boolean = False
            Dim AdvantageUserLicenseInUseList As Generic.List(Of AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse) = Nothing
            Dim LicenseUserID As Integer = 0
            Dim ApplicationID As Integer = 0
            Dim CreatedDate As Date = Nothing
            Dim MACAddressOrSessionID As String = ""
            Dim SPID As Integer = 0
            Dim WorkstationName As String = ""
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim WebvantageEventLogMessages As Generic.List(Of String) = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SecurityDbContext.Database.Connection.Open()
                SecurityDbContext.Configuration.AutoDetectChangesEnabled = False

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString)

                    If Setting IsNot Nothing Then

                        If Setting.Value = 1 Then

                            WebvantageEventLogMessages = New Generic.List(Of String)
                            AdvantageUserLicenseInUseList = SecurityDbContext.AdvantageUserLicenseInUses.ToList

                            For Each AdvantageUserLicenseInUse In AdvantageUserLicenseInUseList

                                LicenseUserID = 0
                                ApplicationID = 0
                                CreatedDate = Nothing
                                MACAddressOrSessionID = ""
                                SPID = 0
                                WorkstationName = ""

                                If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, LicenseUserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                                    SecurityDbContext.AdvantageUserLicenseInUses.Remove(AdvantageUserLicenseInUse)

                                    'Cleared = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete(SecurityDbContext, AdvantageUserLicenseInUse)

                                    'If Cleared = True Then

                                    WebvantageEventLogMessages.Add("AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete called from " &
                                                                   "AdvantageFramework.Security.LicenseKey.ClearAllUsers.  " &
                                                                   LicenseUserID & ", " & ApplicationID & ", " & MACAddressOrSessionID)

                                    'AdvantageFramework.Security.AddWebvantageEventLog()
                                    'End If

                                End If

                            Next

                            Try

                                SecurityDbContext.Configuration.AutoDetectChangesEnabled = True

                                SecurityDbContext.SaveChanges()

                                Cleared = True

                            Catch ex As Exception

                            End Try

                            If Cleared Then

                                For Each WebvantageEventLogMessage In WebvantageEventLogMessages

                                    AdvantageFramework.Security.AddWebvantageEventLog(WebvantageEventLogMessage)

                                Next

                            End If

                        Else

                            Cleared = True

                        End If

                    Else

                        Cleared = True

                    End If

                End Using

            End Using

            ClearAllUsers = Cleared

        End Function
        Public Function CheckForValidUserLicenseKey(ByVal ConnectionString As String, ByVal UserCode As String, ByVal UserID As Integer, ByVal Application As AdvantageFramework.Security.Application, ByVal AdvantageUserLicenseInUseID As Integer, ByVal MACAddress As String, ByVal SessionID As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = False
            Dim AdvantageUserLicenseInUse As AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse = Nothing
            Dim ApplicationID As Integer = 0
            Dim CreatedDate As Date = Nothing
            Dim MACAddressOrSessionID As String = ""
            Dim SPID As Integer = 0
            Dim WorkstationName As String = ""

            If Application = Security.Application.Advantage OrElse Application = Security.Application.Webvantage Then

                If AdvantageUserLicenseInUseID <> 0 Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                        AdvantageUserLicenseInUse = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByAdvantageUserLicenseInUseID(SecurityDbContext, AdvantageUserLicenseInUseID)

                        If AdvantageUserLicenseInUse IsNot Nothing Then

                            If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                                If UserID = UserID AndAlso Application = ApplicationID Then

                                    If Application = Application.Advantage Then

                                        If MACAddressOrSessionID.Trim = MACAddress Then

                                            IsValid = True

                                        End If

                                    ElseIf Application = Application.Webvantage Then

                                        If MACAddressOrSessionID.Trim = SessionID Then

                                            IsValid = True

                                        End If

                                    ElseIf Application = Application.Client_Portal Then

                                        If MACAddressOrSessionID.Trim = SessionID Then

                                            IsValid = True

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End Using

                End If

            Else

                IsValid = True

            End If

            CheckForValidUserLicenseKey = IsValid

        End Function
        Public Function CheckForValidUserLicenseKey(ByVal Session As AdvantageFramework.Security.Session, ByVal MACAddress As String, ByVal SessionID As String, ByRef ErrorMessage As String) As Boolean

            CheckForValidUserLicenseKey = CheckForValidUserLicenseKey(Session.ConnectionString, Session.UserCode, Session.User.ID, Session.Application, Session.AdvantageUserLicenseInUseID, MACAddress, SessionID, ErrorMessage)

        End Function
        Public Function Clear(ByVal Session As AdvantageFramework.Security.Session, ByVal MACAddress As String, ByVal SessionID As String, ByRef ErrorMessage As String) As Boolean

            Return Clear(Session, MACAddress, SessionID, False, ErrorMessage)

        End Function
        Public Function Clear(ByVal Session As AdvantageFramework.Security.Session, ByVal MACAddress As String, ByVal SessionID As String, ByVal LoopAllUsers As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Cleared As Boolean = False
            Dim AdvantageUserLicenseInUseList As Generic.List(Of AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse) = Nothing
            Dim UserID As Integer = 0
            Dim ApplicationID As Integer = 0
            Dim CreatedDate As Date = Nothing
            Dim MACAddressOrSessionID As String = ""
            Dim SPID As Integer = 0
            Dim WorkstationName As String = ""
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString)

                        If Setting IsNot Nothing Then

                            If Setting.Value = 1 Then

                                If Session.Application = Application.Client_Portal Then

                                    AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.ClientPortalUser).ToList

                                Else

                                    If Session.IsTimeEntryOnly Then

                                        AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.WebvantageOnly).ToList

                                    Else

                                        AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.PowerUser).ToList

                                    End If

                                End If

                                For Each AdvantageUserLicenseInUse In AdvantageUserLicenseInUseList

                                    UserID = 0
                                    ApplicationID = 0
                                    CreatedDate = Nothing
                                    MACAddressOrSessionID = ""
                                    SPID = 0
                                    WorkstationName = ""

                                    If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                                        If (Session.Application = Application.Client_Portal AndAlso UserID = Session.ClientPortalUser.ClientContactID AndAlso Session.Application = ApplicationID) OrElse
                                                (UserID = Session.User.ID AndAlso Session.Application = ApplicationID) Then

                                            If Session.Application = Application.Advantage Then

                                                If MACAddressOrSessionID.Trim = MACAddress Then

                                                    Cleared = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete(SecurityDbContext, AdvantageUserLicenseInUse)

                                                    If LoopAllUsers = False Then Exit For

                                                End If

                                            ElseIf Session.Application = Application.Webvantage Then

                                                If MACAddressOrSessionID.Trim = SessionID OrElse UserID = Session.User.ID Then

                                                    Cleared = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete(SecurityDbContext, AdvantageUserLicenseInUse)

                                                    If LoopAllUsers = False Then Exit For

                                                End If

                                            ElseIf Session.Application = Application.Client_Portal Then

                                                If MACAddressOrSessionID.Trim = SessionID OrElse UserID = Session.ClientPortalUser.ClientContactID Then

                                                    Cleared = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete(SecurityDbContext, AdvantageUserLicenseInUse)

                                                    If LoopAllUsers = False Then Exit For

                                                End If

                                            End If

                                        End If

                                    End If

                                Next

                                If Cleared = True Then

                                    AdvantageFramework.Security.AddWebvantageEventLog("AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete called from " &
                                                                                      "AdvantageFramework.Security.LicenseKey.Clear.  " &
                                                                                      UserID & ", " & ApplicationID & ", " & MACAddressOrSessionID)

                                End If

                            Else

                                Cleared = True

                            End If

                        Else

                            Cleared = True

                        End If

                    End Using

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Cleared = False
            End Try

            Clear = Cleared

        End Function
        Public Function Validate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                 ByVal User As AdvantageFramework.Security.Classes.User,
                                 ByVal ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser,
                                 ByVal Application As AdvantageFramework.Security.Application, ByVal MACAddress As String,
                                 ByVal SessionID As String, ByRef ErrorMessage As String,
                                 ByRef AdvantageUserLicenseInUseID As Integer) As Boolean

            'objects
            Dim IsValid As Boolean = False
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim EnableProofingTool As Boolean = False
            Dim AgencyName As String = ""
            Dim LicenseKey As String = ""
            Dim DatabaseID As Integer = 0
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim IsTimeEntryOnly As Boolean = False
            Dim AdvantageUserLicenseInUseList As Generic.List(Of AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse) = Nothing
            Dim UserID As Integer = 0
            Dim ApplicationID As Integer = 0
            Dim CreatedDate As Date = Nothing
            Dim MACAddressOrSessionID As String = ""
            Dim SPID As Integer = 0
            Dim WorkstationName As String = ""
            Dim FoundExistingSession As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim AdvantageUserLicenseInUse As AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse = Nothing

            If CheckForValidLicenseKey(DbContext, LicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, DatabaseID, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage) Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DbContext.Database.Connection.ConnectionString, DbContext.UserCode)

                    SecurityDbContext.Database.Connection.Open()

                    Select Case Application
                        Case Security.Application.Webvantage, Security.Application.Client_Portal

                        Case Else 'this will run from Global.asax at session end in web apps to speed up sign in

                            For Each AdvantageUserLicenseInUse In AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Load(SecurityDbContext).ToList

                                UserID = 0
                                ApplicationID = 0
                                CreatedDate = Nothing
                                MACAddressOrSessionID = ""
                                SPID = 0
                                WorkstationName = ""

                                If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                                    If DateDiff(DateInterval.Hour, CreatedDate, Now.ToUniversalTime) >= 24 Then

                                        Try

                                            SecurityDbContext.DeleteEntityObject(AdvantageUserLicenseInUse)

                                        Catch ex As Exception

                                        End Try

                                        AdvantageFramework.Security.AddWebvantageEventLog("AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete called due to > 24.  " & UserID & ", " & ApplicationID & ", " & MACAddressOrSessionID)

                                    End If

                                End If

                            Next

                            Try

                                SecurityDbContext.SaveChanges()

                            Catch ex As Exception

                            End Try

                    End Select

                    If Application = Security.Application.Client_Portal Then

                        AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.ClientPortalUser).ToList

                        For Each AdvantageUserLicenseInUse In AdvantageUserLicenseInUseList.ToList

                            UserID = 0
                            ApplicationID = 0
                            CreatedDate = Nothing
                            MACAddressOrSessionID = ""
                            SPID = 0
                            WorkstationName = ""

                            If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                                If UserID = ClientPortalUser.ClientContactID Then

                                    If ApplicationID = Application Then

                                        AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete(SecurityDbContext, AdvantageUserLicenseInUse)

                                        Exit For

                                    End If

                                End If

                            End If

                        Next

                        AdvantageUserLicenseInUse = Nothing

                        If FoundExistingSession = False Then

                            If ClientPortalUsersQuantity > -1 Then

                                If AdvantageUserLicenseInUseList.Count + 1 <= ClientPortalUsersQuantity Then

                                    If AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Insert(SecurityDbContext, Types.ClientPortalUser, AdvantageFramework.Security.LicenseKey.CreateUserLicenseKey(ClientPortalUser.ClientContactID, Application, SessionID, 0, My.Computer.Name), AdvantageUserLicenseInUse) Then

                                        AdvantageUserLicenseInUseID = AdvantageUserLicenseInUse.ID
                                        IsValid = True

                                    Else

                                        ErrorMessage = "Failed creating user license. Please try logging in again."

                                    End If

                                Else

                                    ErrorMessage = "All Client Portal User licenses are in use."

                                End If

                            Else

                                If AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Insert(SecurityDbContext, Types.ClientPortalUser, AdvantageFramework.Security.LicenseKey.CreateUserLicenseKey(ClientPortalUser.ClientContactID, Application, SessionID, 0, My.Computer.Name), AdvantageUserLicenseInUse) Then

                                    AdvantageUserLicenseInUseID = AdvantageUserLicenseInUse.ID
                                    IsValid = True

                                Else

                                    ErrorMessage = "Failed creating user license. Please try logging in again."

                                End If

                            End If

                        End If

                    Else

                        Try

                            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, User.ID, AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString)

                        Catch ex As Exception
                            UserSetting = Nothing
                        End Try

                        If UserSetting IsNot Nothing Then

                            If UserSetting.StringValue = "Y" Then

                                IsTimeEntryOnly = True

                            End If

                        End If

                        If IsTimeEntryOnly Then

                            AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.WebvantageOnly).ToList

                        Else

                            AdvantageUserLicenseInUseList = AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.LoadByType(SecurityDbContext, AdvantageFramework.Security.LicenseKey.Types.PowerUser).ToList

                        End If

                        If Application = Security.Application.Advantage Then

                            If IsTimeEntryOnly Then

                                For Each AdvantageUserLicenseInUse In AdvantageUserLicenseInUseList.ToList

                                    UserID = 0
                                    ApplicationID = 0
                                    CreatedDate = Nothing
                                    MACAddressOrSessionID = ""
                                    SPID = 0
                                    WorkstationName = ""

                                    If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                                        If UserID = User.ID Then

                                            If ApplicationID = Application Then

                                                AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete(SecurityDbContext, AdvantageUserLicenseInUse)
                                                AdvantageFramework.Security.AddWebvantageEventLog("AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete called from " &
                                                          "AdvantageFramework.Security.LicenseKey.Validate.  " &
                                                          UserID & ", " & ApplicationID & ", " & MACAddressOrSessionID)

                                                AdvantageUserLicenseInUseList.Remove(AdvantageUserLicenseInUse)

                                                Exit For

                                            Else

                                                AdvantageUserLicenseInUseList.Remove(AdvantageUserLicenseInUse)

                                            End If

                                        End If

                                    End If

                                Next

                                AdvantageUserLicenseInUse = Nothing

                                If FoundExistingSession = False Then

                                    If WVOnlyUsersQuantity > -1 Then

                                        If AdvantageUserLicenseInUseList.Count + 1 <= WVOnlyUsersQuantity Then

                                            If AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Insert(SecurityDbContext, Types.WebvantageOnly, AdvantageFramework.Security.LicenseKey.CreateUserLicenseKey(User.ID, Application, MACAddress, 0, My.Computer.Name), AdvantageUserLicenseInUse) Then

                                                AdvantageUserLicenseInUseID = AdvantageUserLicenseInUse.ID
                                                IsValid = True

                                            Else

                                                ErrorMessage = "Failed creating user license. Please try logging in again."

                                            End If

                                        Else

                                            ErrorMessage = "All Webvantage Only licenses are in use."

                                        End If

                                    Else

                                        If AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Insert(SecurityDbContext, Types.WebvantageOnly, AdvantageFramework.Security.LicenseKey.CreateUserLicenseKey(User.ID, Application, MACAddress, 0, My.Computer.Name), AdvantageUserLicenseInUse) Then

                                            AdvantageUserLicenseInUseID = AdvantageUserLicenseInUse.ID
                                            IsValid = True

                                        Else

                                            ErrorMessage = "Failed creating user license. Please try logging in again."

                                        End If

                                    End If

                                End If

                            Else

                                For Each AdvantageUserLicenseInUse In AdvantageUserLicenseInUseList.ToList

                                    UserID = 0
                                    ApplicationID = 0
                                    CreatedDate = Nothing
                                    MACAddressOrSessionID = ""
                                    SPID = 0
                                    WorkstationName = ""

                                    If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                                        If UserID = User.ID Then

                                            If ApplicationID = Application Then

                                                AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete(SecurityDbContext, AdvantageUserLicenseInUse)
                                                AdvantageUserLicenseInUseList.Remove(AdvantageUserLicenseInUse)

                                                Exit For

                                            Else

                                                AdvantageUserLicenseInUseList.Remove(AdvantageUserLicenseInUse)

                                            End If

                                        End If

                                    End If

                                Next

                                AdvantageUserLicenseInUse = Nothing

                                If FoundExistingSession = False Then

                                    If PowerUsersQuantity > -1 Then

                                        If LoadConnectedUsers(SecurityDbContext, Types.PowerUser).Where(Function(ConnectedUser) ConnectedUser.UserID <> User.ID).Count + 1 <= PowerUsersQuantity Then

                                            If AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Insert(SecurityDbContext, Types.PowerUser, AdvantageFramework.Security.LicenseKey.CreateUserLicenseKey(User.ID, Application, MACAddress, 0, My.Computer.Name), AdvantageUserLicenseInUse) Then

                                                AdvantageUserLicenseInUseID = AdvantageUserLicenseInUse.ID
                                                IsValid = True

                                            Else

                                                ErrorMessage = "Failed creating user license. Please try logging in again."

                                            End If

                                        Else

                                            ErrorMessage = "All Power User licenses are in use."

                                        End If

                                    Else

                                        If AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Insert(SecurityDbContext, Types.PowerUser, AdvantageFramework.Security.LicenseKey.CreateUserLicenseKey(User.ID, Application, MACAddress, 0, My.Computer.Name), AdvantageUserLicenseInUse) Then

                                            AdvantageUserLicenseInUseID = AdvantageUserLicenseInUse.ID
                                            IsValid = True

                                        Else

                                            ErrorMessage = "Failed creating user license. Please try logging in again."

                                        End If

                                    End If

                                End If

                            End If

                        ElseIf Application = Security.Application.Webvantage Then

                            If IsTimeEntryOnly Then

                                For Each AdvantageUserLicenseInUse In AdvantageUserLicenseInUseList.ToList

                                    UserID = 0
                                    ApplicationID = 0
                                    CreatedDate = Nothing
                                    MACAddressOrSessionID = ""
                                    SPID = 0
                                    WorkstationName = ""

                                    If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                                        If UserID = User.ID Then

                                            If ApplicationID = Application Then

                                                'AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete(SecurityDbContext, AdvantageUserLicenseInUse)
                                                'Exit For
                                                Try

                                                    SecurityDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM AULU WHERE AULU_ASSIGN = '{0}';", AdvantageUserLicenseInUse.Assigned))
                                                    AdvantageUserLicenseInUseList.RemoveAll(Function(e) e.Assigned = AdvantageUserLicenseInUse.Assigned)
                                                    Exit For

                                                Catch ex As Exception
                                                End Try

                                            Else

                                                AdvantageUserLicenseInUseList.Remove(AdvantageUserLicenseInUse)

                                            End If

                                        End If

                                    End If

                                Next

                                AdvantageUserLicenseInUse = Nothing

                                If FoundExistingSession = False Then

                                    If WVOnlyUsersQuantity > -1 Then

                                        If AdvantageUserLicenseInUseList.Count + 1 <= WVOnlyUsersQuantity Then

                                            If AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Insert(SecurityDbContext, Types.WebvantageOnly, AdvantageFramework.Security.LicenseKey.CreateUserLicenseKey(User.ID, Application, SessionID, 0, My.Computer.Name), AdvantageUserLicenseInUse) Then

                                                AdvantageUserLicenseInUseID = AdvantageUserLicenseInUse.ID
                                                IsValid = True

                                            Else

                                                ErrorMessage = "Failed creating user license. Please try logging in again."

                                            End If

                                        Else

                                            ErrorMessage = "All Webvantage Only licenses are in use."

                                        End If

                                    Else

                                        If AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Insert(SecurityDbContext, Types.WebvantageOnly, AdvantageFramework.Security.LicenseKey.CreateUserLicenseKey(User.ID, Application, SessionID, 0, My.Computer.Name), AdvantageUserLicenseInUse) Then

                                            AdvantageUserLicenseInUseID = AdvantageUserLicenseInUse.ID
                                            IsValid = True

                                        Else

                                            ErrorMessage = "Failed creating user license. Please try logging in again."

                                        End If

                                    End If

                                End If

                            Else

                                For Each AdvantageUserLicenseInUse In AdvantageUserLicenseInUseList.ToList

                                    UserID = 0
                                    ApplicationID = 0
                                    CreatedDate = Nothing
                                    MACAddressOrSessionID = ""
                                    SPID = 0
                                    WorkstationName = ""

                                    If ReadUserLicenseKey(AdvantageUserLicenseInUse.Assigned, UserID, ApplicationID, CreatedDate, MACAddressOrSessionID, SPID, WorkstationName) <> "" Then

                                        If UserID = User.ID Then

                                            If ApplicationID = Application Then

                                                'AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Delete(SecurityDbContext, AdvantageUserLicenseInUse)
                                                'Exit For
                                                Try

                                                    SecurityDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM AULU WHERE AULU_ASSIGN = '{0}';", AdvantageUserLicenseInUse.Assigned))
                                                    AdvantageUserLicenseInUseList.RemoveAll(Function(e) e.Assigned = AdvantageUserLicenseInUse.Assigned)
                                                    Exit For

                                                Catch ex As Exception
                                                End Try

                                            Else

                                                AdvantageUserLicenseInUseList.Remove(AdvantageUserLicenseInUse)

                                            End If

                                        End If

                                    End If

                                Next

                                AdvantageUserLicenseInUse = Nothing

                                If FoundExistingSession = False Then

                                    If PowerUsersQuantity > -1 Then

                                        If LoadConnectedUsers(SecurityDbContext, Types.PowerUser).Where(Function(ConnectedUser) ConnectedUser.UserID <> User.ID).Count + 1 <= PowerUsersQuantity Then

                                            If AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Insert(SecurityDbContext, Types.PowerUser, AdvantageFramework.Security.LicenseKey.CreateUserLicenseKey(User.ID, Application, SessionID, 0, My.Computer.Name), AdvantageUserLicenseInUse) Then

                                                AdvantageUserLicenseInUseID = AdvantageUserLicenseInUse.ID
                                                IsValid = True

                                            Else

                                                ErrorMessage = "Failed creating user license. Please try logging in again."

                                            End If

                                        Else

                                            ErrorMessage = "All Power User licenses are in use."

                                        End If

                                    Else

                                        If AdvantageFramework.Security.Database.Procedures.AdvantageUserLicenseInUse.Insert(SecurityDbContext, Types.PowerUser, AdvantageFramework.Security.LicenseKey.CreateUserLicenseKey(User.ID, Application, SessionID, 0, My.Computer.Name), AdvantageUserLicenseInUse) Then

                                            AdvantageUserLicenseInUseID = AdvantageUserLicenseInUse.ID
                                            IsValid = True

                                        Else

                                            ErrorMessage = "Failed creating user license. Please try logging in again."

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                End Using

            End If

            Validate = IsValid

        End Function
        Public Function ReadUserLicenseKey(ByVal EncryptedLicenseKey As String, ByRef UserID As Integer, ByRef ApplicationID As Integer, _
                                            ByRef CreatedDate As Date, ByRef MACAddressOrSessionID As String, _
                                            ByRef SPID As Integer, ByRef WorkstationName As String) As String

            'objects
            Dim UserLicenseKey As String = ""
            Dim Year As Integer = 0
            Dim Month As Integer = 0
            Dim Day As Integer = 0
            Dim Hour As Integer = 0
            Dim Minute As Integer = 0
            Dim Second As Integer = 0

            Try

                UserLicenseKey = AdvantageFramework.Security.Encryption.DecryptLicenseKey(EncryptedLicenseKey)

                UserID = UserLicenseKey.Substring(0, 4)
                ApplicationID = UserLicenseKey.Substring(4, 2)

                Try

                    Month = UserLicenseKey.Substring(6, 2)
                    Day = UserLicenseKey.Substring(8, 2)
                    Year = UserLicenseKey.Substring(10, 4)
                    Hour = UserLicenseKey.Substring(14, 3)
                    Minute = UserLicenseKey.Substring(18, 2)
                    Second = UserLicenseKey.Substring(21, 2)

                    CreatedDate = New Date(Year, Month, Day, Hour, Minute, Second)

                Catch ex As Exception
                    CreatedDate = Nothing
                End Try

                ' CreatedDate = CDate(AdvantageFramework.DateUtilities.ConvertStringToShortDateString(UserLicenseKey.Substring(6, 8)) & " " & UserLicenseKey.Substring(14, 12))
                MACAddressOrSessionID = UserLicenseKey.Substring(26, 30)
                SPID = UserLicenseKey.Substring(56, 6)
                WorkstationName = UserLicenseKey.Substring(62, 50)

            Catch ex As Exception
                UserLicenseKey = ""
            End Try

            ReadUserLicenseKey = UserLicenseKey

        End Function
        Private Function CreateUserLicenseKey(ByVal UserID As Integer, ByVal ApplicationID As Integer, _
                                                ByVal MACAddressOrSessionID As String, ByVal SPID As Integer, _
                                                ByVal WorkstationName As String) As String

            'objects
            Dim UserLicenseKey As String = ""
            Dim EncryptedLicenseKey As String = ""

            UserLicenseKey = Format(UserID, "0000")
            UserLicenseKey &= Format(ApplicationID, "00")
            UserLicenseKey &= Now.ToUniversalTime.ToString("MMddyyyy hh:mm:ss   ", My.Application.Culture)
            UserLicenseKey &= AdvantageFramework.StringUtilities.PadWithCharacter(MACAddressOrSessionID, 30)
            UserLicenseKey &= Format(SPID, "000000")
            UserLicenseKey &= AdvantageFramework.StringUtilities.PadWithCharacter(WorkstationName, 50)

            EncryptedLicenseKey = AdvantageFramework.Security.Encryption.EncryptLicenseKey(UserLicenseKey)

            CreateUserLicenseKey = EncryptedLicenseKey

        End Function
        Public Function Create(ByVal DaysUntilFileExpires As Integer, ByVal DaysUntilKeyExpires As Integer, ByVal PowerUsersQuantity As Integer,
                               ByVal WVOnlyUsersQuantity As Integer, ByVal ClientPortalUsersQuantity As Integer, ByVal AgencyName As String,
                               ByVal DatabaseID As Integer, ByVal MediaToolsUsersQuantity As Integer, ByVal APIUsersQuantity As Integer,
                               ByVal EnableProofingTool As Boolean) As String

            'objects
            Dim LicenseKey As String = ""
            Dim PowerUsersQuantityValue As String = ""
            Dim WVOnlyUsersQuantityValue As String = ""
            Dim ClientPortalUsersQuantityValue As String = ""
            Dim MediaToolsUsersQuantityValue As String = ""
            Dim APIUsersQuantityValue As String = ""
            Dim EnableProofingToolQuantityValue As String = ""
            Dim EncryptedLicenseKey As String = ""

            LicenseKey = Now.ToString("yyMMdd")
            LicenseKey &= Format(DaysUntilFileExpires, "0000")
            LicenseKey &= Format(DaysUntilKeyExpires, "0000")

            If PowerUsersQuantity <> -1 Then

                PowerUsersQuantityValue = Format(PowerUsersQuantity, "00000")

            Else

                PowerUsersQuantityValue = "#####"

            End If

            If WVOnlyUsersQuantity <> -1 Then

                WVOnlyUsersQuantityValue = Format(WVOnlyUsersQuantity, "00000")

            Else

                WVOnlyUsersQuantityValue = "#####"

            End If

            If ClientPortalUsersQuantity <> -1 Then

                ClientPortalUsersQuantityValue = Format(ClientPortalUsersQuantity, "00000")

            Else

                ClientPortalUsersQuantityValue = "#####"

            End If

            If MediaToolsUsersQuantity <> -1 Then

                MediaToolsUsersQuantityValue = Format(MediaToolsUsersQuantity, "00000")

            Else

                MediaToolsUsersQuantityValue = "#####"

            End If

            If APIUsersQuantity <> -1 Then

                APIUsersQuantityValue = Format(APIUsersQuantity, "00000")

            Else

                APIUsersQuantityValue = "#####"

            End If

            If EnableProofingTool = True Then

                EnableProofingToolQuantityValue = "00001"

            Else

                EnableProofingToolQuantityValue = "#####"

            End If

            LicenseKey &= PowerUsersQuantityValue
            LicenseKey &= WVOnlyUsersQuantityValue
            LicenseKey &= ClientPortalUsersQuantityValue

            LicenseKey &= AdvantageFramework.StringUtilities.PadWithCharacter(AgencyName.Replace("&", ",amp,"), 40)

            LicenseKey &= Format(DatabaseID, "0000")
            LicenseKey &= MediaToolsUsersQuantityValue
            LicenseKey &= APIUsersQuantityValue
            LicenseKey &= EnableProofingToolQuantityValue


            EncryptedLicenseKey = AdvantageFramework.Security.Encryption.EncryptLicenseKey(LicenseKey)

            Create = EncryptedLicenseKey

        End Function
        'Public Function Create(ByVal DaysUntilFileExpires As Integer, ByVal DaysUntilKeyExpires As Integer, ByVal PowerUsersQuantity As Integer, _
        '                       ByVal WVOnlyUsersQuantity As Integer, ByVal ClientPortalUsersQuantity As Integer, ByVal AgencyName As String, _
        '                       ByVal DatabaseID As Integer, ByVal MediaToolsUsersQuantity As Integer) As String

        '    'objects
        '    Dim LicenseKey As String = ""
        '    Dim EncryptedLicenseKey As String = ""

        '    LicenseKey = Create(DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, DatabaseID, MediaToolsUsersQuantity)

        '    LicenseKey &= Format(DatabaseID, "0000")

        '    EncryptedLicenseKey = AdvantageFramework.Security.LicenseKey.Encrypt(LicenseKey)

        '    Create = EncryptedLicenseKey

        'End Function
        Public Function Read(ByVal EncryptedLicenseKey As String, ByRef LicenseKeyDate As Date, ByRef DaysUntilFileExpires As Integer,
                             ByRef DaysUntilKeyExpires As Integer, ByRef PowerUsersQuantity As Integer, ByRef WVOnlyUsersQuantity As Integer,
                             ByRef ClientPortalUsersQuantity As Integer, ByRef AgencyName As String, ByRef DatabaseID As Integer,
                             ByRef MediaToolsUsersQuantity As Integer, ByRef APIUsersQuantity As Integer, ByRef EnableProofingTool As Boolean,
                             ByRef ErrorMessage As String) As String

            'objects
            Dim LicenseKey As String = ""

            Try

                LicenseKey = AdvantageFramework.Security.Encryption.DecryptLicenseKey(EncryptedLicenseKey)

                LicenseKeyDate = CDate(AdvantageFramework.DateUtilities.ConvertStringToShortDateString(LicenseKey.Substring(2, 4) & "20" & LicenseKey.Substring(0, 2), AdvantageFramework.DateUtilities.DateFormat.MDY.ToString))
                DaysUntilFileExpires = CInt(LicenseKey.Substring(6, 4))
                DaysUntilKeyExpires = CInt(LicenseKey.Substring(10, 4))

                Try

                    If IsNumeric(LicenseKey.Substring(14, 5)) Then

                        PowerUsersQuantity = CInt(LicenseKey.Substring(14, 5))

                    Else

                        PowerUsersQuantity = -1

                    End If

                Catch ex As Exception
                    PowerUsersQuantity = -1
                End Try

                Try

                    If IsNumeric(LicenseKey.Substring(19, 5)) Then

                        WVOnlyUsersQuantity = CInt(LicenseKey.Substring(19, 5))

                    Else

                        WVOnlyUsersQuantity = -1

                    End If

                Catch ex As Exception
                    WVOnlyUsersQuantity = -1
                End Try

                Try

                    If IsNumeric(LicenseKey.Substring(24, 5)) Then

                        ClientPortalUsersQuantity = CInt(LicenseKey.Substring(24, 5))

                    Else

                        ClientPortalUsersQuantity = -1

                    End If

                Catch ex As Exception
                    ClientPortalUsersQuantity = -1
                End Try

                AgencyName = LicenseKey.Substring(29, 40).Replace(",amp,", "&")

                If LicenseKey.Length > 69 Then

                    Try

                        If IsNumeric(LicenseKey.Substring(69, 4)) Then

                            DatabaseID = CInt(LicenseKey.Substring(69, 4))

                        Else

                            DatabaseID = 0

                        End If

                    Catch ex As Exception
                        DatabaseID = 0
                    End Try

                    If LicenseKey.Length > 73 Then

                        Try

                            If IsNumeric(LicenseKey.Substring(73, 5)) Then

                                MediaToolsUsersQuantity = CInt(LicenseKey.Substring(73, 5))

                            Else

                                MediaToolsUsersQuantity = -1

                            End If

                        Catch ex As Exception
                            MediaToolsUsersQuantity = -1
                        End Try

                    End If

                    If LicenseKey.Length > 78 Then

                        Try

                            If IsNumeric(LicenseKey.Substring(78, 5)) Then

                                APIUsersQuantity = CInt(LicenseKey.Substring(78, 5))

                            Else

                                APIUsersQuantity = -1

                            End If

                        Catch ex As Exception
                            APIUsersQuantity = -1
                        End Try

                    End If

                    If LicenseKey.Length > 83 Then

                        Try

                            If IsNumeric(LicenseKey.Substring(83, 5)) AndAlso CInt(LicenseKey.Substring(83, 5)) = 1 Then

                                EnableProofingTool = True

                            Else

                                EnableProofingTool = False

                            End If

                        Catch ex As Exception
                            EnableProofingTool = False
                        End Try

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                LicenseKey = ""
            Finally
                Read = LicenseKey
            End Try

        End Function
        Public Function ComscoreCreate(AgencyName As String, ComscoreClientID As String) As String

            'objects
            Dim LicenseKey As String = ""
            Dim EncryptedLicenseKey As String = ""

            LicenseKey = AdvantageFramework.StringUtilities.PadWithCharacter(AgencyName.Replace("&", ",amp,"), 40)

            LicenseKey &= ComscoreClientID

            EncryptedLicenseKey = AdvantageFramework.Security.Encryption.EncryptLicenseKey(LicenseKey)

            ComscoreCreate = EncryptedLicenseKey

        End Function
        Public Function ComscoreRead(EncryptedLicenseKey As String, ByRef AgencyName As String, ByRef ComscoreClientID As String) As String

            'objects
            Dim LicenseKey As String = ""

            Try

                LicenseKey = AdvantageFramework.Security.Encryption.DecryptLicenseKey(EncryptedLicenseKey)

                AgencyName = Trim(LicenseKey.Substring(0, 40).Replace(",amp,", "&"))

                ComscoreClientID = LicenseKey.Substring(40)

            Catch ex As Exception
                LicenseKey = ""
            Finally
                ComscoreRead = LicenseKey
            End Try

        End Function
        Public Function ImportComscoreLicenseKey(ByVal Session As AdvantageFramework.Security.Session, ByVal File As String, ByRef ErrorMessage As String, ByRef Remove As Boolean) As Boolean

            'objects
            Dim LicenseKeyImported As Boolean = False
            Dim LicenseKey As String = ""
            Dim EncryptedLicenseKey As String = ""
            Dim ReadFile As Boolean = False
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim DatabaseDetail As AdvantageFramework.Database.MasterDatabase.Entities.DatabaseDetail = Nothing
            Dim AgencyName As String = ""
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim ComscoreClientID As String = Nothing

            Try

                FileInfo = My.Computer.FileSystem.GetFileInfo(File)

            Catch ex As Exception
                FileInfo = Nothing
            End Try

            If FileInfo IsNot Nothing Then

                Try

                    EncryptedLicenseKey = FileInfo.OpenText.ReadToEnd

                    ReadFile = True

                Catch ex As Exception
                    ReadFile = False
                End Try

                If ReadFile Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Using MasterDataContext = New AdvantageFramework.Database.MasterDatabase.DataContext(Session.ConnectionString, Session.UserCode)

                            LicenseKey = AdvantageFramework.Security.LicenseKey.ComscoreRead(EncryptedLicenseKey, AgencyName, ComscoreClientID)

                            Try

                                DatabaseDetail = MasterDataContext.DatabaseDetails.Where(Function(DBDetail) DBDetail.Name = MasterDataContext.Connection.Database).SingleOrDefault

                            Catch ex As Exception
                                DatabaseDetail = Nothing
                            End Try

                            If DatabaseDetail IsNot Nothing Then

                                EncryptedLicenseKey = AdvantageFramework.Security.LicenseKey.ComscoreCreate(AgencyName, ComscoreClientID)

                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.AGENCY WHERE NAME = '{0}'", AgencyName.Replace("'", "''"))).FirstOrDefault > 0 Then

                                    If ComscoreClientID.ToUpper = "REMOVE" Then

                                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = NULL WHERE AGY_SETTINGS_CODE = 'CSCORE_CLIENT_ID'")
                                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = NULL WHERE AGY_SETTINGS_CODE = 'CSCORE_CLIENT_SECRET'")
                                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = NULL WHERE AGY_SETTINGS_CODE = 'CSCORE_AS_CLIENT_ID'")

                                        ErrorMessage = "License key imported successfully."
                                        LicenseKeyImported = True

                                        Remove = True

                                    Else

                                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSCORE_AS_CLIENT_ID.ToString)

                                            If Setting IsNot Nothing Then

                                                Setting.Value = AdvantageFramework.Security.Encryption.Encrypt(ComscoreClientID)

                                                If AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting) Then

                                                    ErrorMessage = "License key imported successfully."
                                                    LicenseKeyImported = True

                                                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = 'awXBXOmkJsxr6wYyA9L45qp2bK5/QvqqujG/2Pgeky5ovAdh8MHT3GggsVIi88DwXJatF1G0vx3xKu27/MsG50Q1YeJBSQbxJntbVnhYlhk=' WHERE AGY_SETTINGS_CODE = 'CSCORE_CLIENT_ID'")
                                                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = 'YolEC7hd2iq193uzFy2WSl48AFOM5HDlKyOlJo+pdpdgpgxuVScFfNlC1yczGX6GCMWXTxkbl4WHTWy4xXj9JD+MSxhocCPWSi1I5j8I4X8=' WHERE AGY_SETTINGS_CODE = 'CSCORE_CLIENT_SECRET'")

                                                    Remove = False

                                                End If

                                            Else

                                                ErrorMessage = "Failed to save Comscore license key."

                                            End If

                                        End Using

                                    End If

                                Else

                                    ErrorMessage = "Failed to update Comscore license key."

                                End If

                            Else

                                ErrorMessage = "Failed loading database information.  Please contact Advantage support."

                            End If

                        End Using

                    End Using

                Else

                    ErrorMessage = "Failed when reading from file."

                End If

            Else

                ErrorMessage = "Failed to load file information."

            End If

            ImportComscoreLicenseKey = LicenseKeyImported

        End Function
        Public Sub CalculateAvailableUserQuantities(Session As AdvantageFramework.Security.Session, PowerUsersQuantity As Integer, WVOnlyUsersQuantity As Integer,
                                                    ByRef AvailablePowerUsers As Integer, ByRef AvailableWVOnlyUsers As Integer)

            Dim LicenseKeyUsers As Generic.List(Of AdvantageFramework.Security.Classes.LicenseKeyUser) = Nothing
            Dim PowerUsersAmount As Integer = 0
            Dim WVOnlyUsersAmount As Integer = 0

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    LicenseKeyUsers = SecurityDbContext.Database.SqlQuery(Of AdvantageFramework.Security.Classes.LicenseKeyUser)("SELECT 
	                                                                                                                                    [ID] = SU.SEC_USER_ID,
	                                                                                                                                    [UserCode] = SU.USER_CODE,
	                                                                                                                                    [IsInactive] = SU.IS_INACTIVE,
	                                                                                                                                    [IsPowerUser] = CAST(CASE WHEN ISNULL(SUS.STRING_VALUE, 'N') = 'N' THEN 1 ELSE 0 END AS bit)
                                                                                                                                    FROM
	                                                                                                                                    dbo.SEC_USER AS SU 
	                                                                                                                                    LEFT OUTER JOIN dbo.SEC_USER_SETTING AS SUS ON SUS.SEC_USER_ID = SU.SEC_USER_ID 
												                                                                                                                                       AND SUS.SETTING_CODE = 'TIME_ENTRY_ONLY'").ToList

                End Using

            Catch ex As Exception
                LicenseKeyUsers = Nothing
            End Try

            If LicenseKeyUsers IsNot Nothing Then

                If PowerUsersQuantity > 0 Then

                    PowerUsersAmount = LicenseKeyUsers.Where(Function(Entity) Entity.IsPowerUser = True AndAlso Entity.IsInactive = False).Count()

                    If PowerUsersAmount = PowerUsersQuantity Then

                        AvailablePowerUsers = 0

                    Else

                        AvailablePowerUsers = PowerUsersQuantity - PowerUsersAmount

                    End If

                ElseIf PowerUsersQuantity = 0 Then

                    AvailablePowerUsers = 0

                Else

                    AvailablePowerUsers = Integer.MaxValue

                End If

                If WVOnlyUsersQuantity > 0 Then

                    WVOnlyUsersAmount = LicenseKeyUsers.Where(Function(Entity) Entity.IsPowerUser = False AndAlso Entity.IsInactive = False).Count()

                    If WVOnlyUsersAmount = WVOnlyUsersQuantity Then

                        AvailableWVOnlyUsers = 0

                    Else

                        AvailableWVOnlyUsers = WVOnlyUsersQuantity - WVOnlyUsersAmount

                    End If

                ElseIf WVOnlyUsersQuantity = 0 Then

                    AvailableWVOnlyUsers = 0

                Else

                    AvailableWVOnlyUsers = Integer.MaxValue

                End If

            Else

                AvailablePowerUsers = 0
                AvailableWVOnlyUsers = 0

            End If

        End Sub
        Public Function CheckAvailableUsers(Session As AdvantageFramework.Security.Session, UserType As AdvantageFramework.Security.LicenseKey.Types, PowerUsersQuantity As Integer, WVOnlyUsersQuantity As Integer) As Boolean

            'objects
            Dim HasAvailableUsers As Boolean = False
            Dim AvailablePowerUsers As Integer = 0
            Dim AvailableWVOnlyUsers As Integer = 0

            AdvantageFramework.Security.LicenseKey.CalculateAvailableUserQuantities(Session, PowerUsersQuantity, WVOnlyUsersQuantity, AvailablePowerUsers, AvailableWVOnlyUsers)

            If UserType = AdvantageFramework.Security.LicenseKey.Types.All Then

                If (AvailablePowerUsers + AvailableWVOnlyUsers) > 0 Then

                    HasAvailableUsers = True

                End If

            ElseIf UserType = AdvantageFramework.Security.LicenseKey.Types.PowerUser Then

                If AvailablePowerUsers > 0 Then

                    HasAvailableUsers = True

                End If

            ElseIf UserType = AdvantageFramework.Security.LicenseKey.Types.WebvantageOnly Then

                If AvailableWVOnlyUsers > 0 Then

                    HasAvailableUsers = True

                End If

            End If

            CheckAvailableUsers = HasAvailableUsers

        End Function

#End Region

    End Module

End Namespace

