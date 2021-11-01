Namespace Services

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Private Const _ConstFilePathx86 As String = "C:\Program Files (x86)\Advantage Software\Advantage Services\"
        Private Const _ConstFilePath As String = "C:\Program Files\Advantage Software\Advantage Services\"

#End Region

#Region " Enum "

        Public Enum Service
            AdvantageWindowsService
            AdvantageExportWindowsService
            AdvantageQvAAlertWindowsService
            AdvantageTaskWindowsService
            AdvantageMissingTimeWindowsService
            AdvantageCalendarWindowsService
            AdvantageCoreMediaCheckExportWindowsService
            AdvantagePaidTimeOffAccrualsWindowsService
            AdvantageContractWindowsService
            AdvantageMediaOceanImportWindowsService
            AdvantageCSIPreferredPartnerWindowsService
            AdvantageJobCompUDFImportWindowsService
            AdvantageImportTemplateWindowsService
            AdvantageExportTemplateWindowsService
            AdvantageVendorContractWindowsService
            AdvantageCurrencyExchangeWindowsService
            AdvantageVCCWindowsService
            AdvantageNielsenWindowsService
            AdvantageCalendarTimeSheetImportService
            AdvantageScheduledReportsService
            AdvantageComScoreWindowsService
            AdvantageInOutWindowService
            AdvantageAutomatedAssignmentsService
            AdvantageDocumentRepositoryCapacityWarningWindowsService
        End Enum

        Public Enum ServiceStartupType
            Automatic
            Manual
            Disabled
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Start() As Boolean

            'objects
            Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            Dim Started As Boolean = False

            Try

                ServiceController = AdvantageFramework.Services.Load()

                If ServiceController Is Nothing Then

                    If AdvantageFramework.Services.Install() Then

                        ServiceController = AdvantageFramework.Services.Load()

                    End If

                End If

                If ServiceController IsNot Nothing Then

                    If ServiceController.Status <> ServiceProcess.ServiceControllerStatus.Stopped Then

                        ServiceController.Stop()

                        Do While ServiceController.Status <> ServiceProcess.ServiceControllerStatus.Stopped

                            System.Threading.Thread.Sleep(1000)

                            ServiceController.Refresh()

                        Loop

                    End If

                    ServiceController.Start()

                    Started = True

                End If

            Catch ex As Exception
                Started = False
            Finally
                Start = Started
            End Try

        End Function
        Public Sub [Stop]()

            'objects
            Dim ServiceController As System.ServiceProcess.ServiceController = Nothing

            Try

                ServiceController = AdvantageFramework.Services.Load()

                If ServiceController IsNot Nothing Then

                    ServiceController.Stop()

                    Do Until ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped

                        System.Threading.Thread.Sleep(1000)

                        ServiceController.Refresh()

                    Loop

                End If

            Catch ex As Exception

            Finally

            End Try

        End Sub
        Public Function LoadDatabaseProfiles() As Generic.List(Of AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim AddDatabaseProfile As Boolean = False
            Dim DatabaseProfiles As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

            DatabaseProfiles = New Generic.List(Of AdvantageFramework.Database.DatabaseProfile)

            Try

                For Each DatabaseProfile In AdvantageFramework.Database.LoadDatabaseProfiles

                    AddDatabaseProfile = False

                    If DatabaseProfile.EnableServices Then

                        Try

                            Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                                DataContext.AdvantageServices.ToList()

                            End Using

                            AddDatabaseProfile = True

                        Catch ex As Exception
                            AddDatabaseProfile = False
                        End Try

                    End If

                    If AddDatabaseProfile Then

                        DatabaseProfiles.Add(DatabaseProfile)

                    End If

                Next

            Catch ex As Exception

            End Try

            LoadDatabaseProfiles = DatabaseProfiles

        End Function
        Public Function LoadAdvantageService(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Service As AdvantageFramework.Services.Service) As AdvantageFramework.Database.Entities.AdvantageService

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            Try

                AdvantageService = (From Entity In DataContext.AdvantageServices
                                    Where Entity.Code = Service.ToString
                                    Select Entity).SingleOrDefault

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal ServiceSettingCode As String) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = (From Entity In DataContext.AdvantageServiceSettings
                                           Where Entity.AdvantageServiceID = AdvantageServiceID AndAlso
                                                 Entity.Code = ServiceSettingCode
                                           Select Entity).SingleOrDefault

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingList(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceSettingID As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceSettingList)

            'objects
            Dim AdvantageServiceSettingLists As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceSettingList) = Nothing

            Try

                AdvantageServiceSettingLists = (From Entity In DataContext.AdvantageServiceSettingLists
                                                Where Entity.AdvantageServiceSettingID = AdvantageServiceSettingID
                                                Select Entity).ToList

            Catch ex As Exception
                AdvantageServiceSettingLists = Nothing
            End Try

            LoadAdvantageServiceSettingList = AdvantageServiceSettingLists

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal ServiceSettingCode As String) As Object

            'objects
            Dim SettingValue As Object = Nothing
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = (From Entity In DataContext.AdvantageServiceSettings
                                           Where Entity.AdvantageServiceID = AdvantageServiceID AndAlso
                                                 Entity.Code = ServiceSettingCode
                                           Select Entity).SingleOrDefault

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            If AdvantageServiceSetting IsNot Nothing Then

                If IsNothing(AdvantageServiceSetting.Value) Then

                    SettingValue = AdvantageServiceSetting.DefaultValue

                Else

                    SettingValue = AdvantageServiceSetting.Value

                End If

            End If

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal ServiceSettingCode As String, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = (From Entity In DataContext.AdvantageServiceSettings
                                           Where Entity.AdvantageServiceID = AdvantageServiceID AndAlso
                                                 Entity.Code = ServiceSettingCode
                                           Select Entity).SingleOrDefault

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            If AdvantageServiceSetting IsNot Nothing Then

                Try

                    AdvantageServiceSetting.Value = SettingValue

                    Saved = AdvantageFramework.Database.Procedures.AdvantageServiceSetting.Update(DataContext, AdvantageServiceSetting)

                Catch ex As Exception
                    Saved = False
                End Try

            End If

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Function LoadLogEntries(ByVal EventLog As System.Diagnostics.EventLog) As String

            'objects
            Dim Log As String = ""

            If EventLog IsNot Nothing Then

                For Each Entry In EventLog.Entries.OfType(Of System.Diagnostics.EventLogEntry).ToList.OrderByDescending(Function(EventLogEntry) EventLogEntry.TimeGenerated)

                    Log &= vbCrLf & Entry.TimeGenerated & " - " & Entry.Message & "...."

                Next

            End If

            LoadLogEntries = Log

        End Function
        Public Function IsServiceInstalled(ByVal MachineName As String) As Boolean

            'objects
            Dim ServiceIsInstalled As Boolean = False
            Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            Dim ServiceControllerStatus As System.ServiceProcess.ServiceControllerStatus = ServiceProcess.ServiceControllerStatus.Stopped

            Try

                ServiceController = New System.ServiceProcess.ServiceController(AdvantageFramework.Services.Service.AdvantageWindowsService.ToString, MachineName)

                ServiceControllerStatus = ServiceController.Status

                ServiceIsInstalled = True

            Catch ex As Exception
                ServiceIsInstalled = False
            Finally
                IsServiceInstalled = ServiceIsInstalled
            End Try

        End Function
        Public Function StatusOfService(ByVal MachineName As String) As String

            'objects
            Dim Status As String = ""
            Dim ServiceController As System.ServiceProcess.ServiceController = Nothing

            Try

                Status = "Not Installed"

                If IsServiceInstalled(MachineName) Then

                    ServiceController = New System.ServiceProcess.ServiceController(AdvantageFramework.Services.Service.AdvantageWindowsService.ToString, MachineName)

                    Status = ServiceController.Status

                End If

            Catch ex As Exception
                Status = "Not Installed"
            Finally
                StatusOfService = Status
            End Try

        End Function
        Public Function Load() As System.ServiceProcess.ServiceController

            'objects
            Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            Dim ServiceName As String = ""

            Try

                ServiceName = AdvantageFramework.Services.Service.AdvantageWindowsService.ToString

                For Each RunningServiceController In System.ServiceProcess.ServiceController.GetServices

                    If RunningServiceController.ServiceName = ServiceName Then

                        ServiceController = RunningServiceController
                        Exit For

                    End If

                Next

            Catch ex As Exception
                ServiceController = Nothing
            Finally
                Load = ServiceController
            End Try

        End Function
        Public Function Install() As Boolean

            'objects
            Dim ServiceInstalled As Boolean = False
            Dim AssemblyInstaller As System.Configuration.Install.AssemblyInstaller = Nothing
            Dim FilePath As String = ""
            Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            Dim ServiceName As String = ""

            Try

                ServiceName = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageWindowsService.ToString) & ".exe"

                If My.Computer.FileSystem.FileExists(_ConstFilePathx86 & ServiceName) Then

                    FilePath = _ConstFilePathx86 & ServiceName

                ElseIf My.Computer.FileSystem.FileExists(_ConstFilePath & ServiceName) Then

                    FilePath = _ConstFilePath & ServiceName

                End If

                If FilePath <> "" Then

                    AssemblyInstaller = New System.Configuration.Install.AssemblyInstaller(FilePath, Nothing)

                    AssemblyInstaller.UseNewContext = True
                    AssemblyInstaller.Install(Nothing)
                    AssemblyInstaller.Commit(Nothing)

                    ServiceController = AdvantageFramework.Services.Load()

                    If ServiceController IsNot Nothing Then

                        ServiceInstalled = True

                    End If

                End If

            Catch ex As Exception
                ServiceInstalled = False
            Finally
                Install = ServiceInstalled
            End Try

        End Function
        Public Function Uninstall() As Boolean

            'objects
            Dim ServiceUninstalled As Boolean = False
            Dim AssemblyInstaller As System.Configuration.Install.AssemblyInstaller = Nothing
            Dim FilePath As String = ""
            Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            Dim ServiceName As String = ""

            Try

                ServiceName = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageWindowsService.ToString) & ".exe"

                If ServiceName.Contains("Qv A") Then

                    ServiceName = ServiceName.Replace("Qv A", "QvA")

                End If

                If My.Computer.FileSystem.FileExists(_ConstFilePathx86 & ServiceName) Then

                    FilePath = _ConstFilePathx86 & ServiceName

                ElseIf My.Computer.FileSystem.FileExists(_ConstFilePath & ServiceName) Then

                    FilePath = _ConstFilePath & ServiceName

                End If

                If FilePath <> "" Then

                    AssemblyInstaller = New System.Configuration.Install.AssemblyInstaller(FilePath, Nothing)

                    AssemblyInstaller.UseNewContext = True
                    AssemblyInstaller.Uninstall(Nothing)

                    ServiceController = AdvantageFramework.Services.Load()

                    If ServiceController Is Nothing Then

                        ServiceUninstalled = True

                    End If

                Else

                    ServiceUninstalled = True

                End If

            Catch ex As Exception
                ServiceUninstalled = False
            Finally
                Uninstall = ServiceUninstalled
            End Try

        End Function
        Public Function GetStartupType() As ServiceStartupType

            'objects
            Dim StartupType As ServiceStartupType = Nothing
            Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            Dim ServicePath As String = ""
            Dim ManagementObject As System.Management.ManagementObject = Nothing
            Dim StartupTypeString As String = ""

            Try

                ServiceController = AdvantageFramework.Services.Load()

                ServicePath = "Win32_Service.Name='" + ServiceController.ServiceName + "'"

                ManagementObject = New System.Management.ManagementObject(ServicePath)

                StartupTypeString = ManagementObject("StartMode").ToString()

                Select Case StartupTypeString

                    Case ServiceStartupType.Automatic.ToString()

                        StartupType = ServiceStartupType.Automatic

                    Case ServiceStartupType.Manual.ToString()

                        StartupType = ServiceStartupType.Manual

                    Case ServiceStartupType.Disabled.ToString()

                        StartupType = ServiceStartupType.Disabled

                End Select

            Catch ex As Exception
                StartupType = Nothing
            End Try

            GetStartupType = StartupType

        End Function
        Public Function SetStartupType(ByVal StartupType As ServiceStartupType) As Boolean

            'objects
            Dim StartupTypeSet As Boolean = True
            Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            Dim ServicePath As String = ""
            Dim ManagementObject As System.Management.ManagementObject = Nothing
            Dim MethodParameters() As Object = Nothing

            Try

                ServiceController = AdvantageFramework.Services.Load()

                ServicePath = "Win32_Service.Name='" + ServiceController.ServiceName + "'"

                ManagementObject = New System.Management.ManagementObject(ServicePath)

                MethodParameters = New Object() {StartupType.ToString()}

                ManagementObject.InvokeMethod("ChangeStartMode", MethodParameters)

            Catch ex As Exception
                StartupTypeSet = False
            End Try

            SetStartupType = StartupTypeSet

        End Function

#End Region

    End Module

End Namespace
