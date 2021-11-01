Namespace Services.MediaExport

    <HideModuleName()> _
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Export\", "ExportRunAt", "01/01/2001 01:00 AM")> _
            ExportRunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Export\", "ExportPath", "C:\")> _
            ExportPath
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Export\", "ExportData", "AllDataSelected")> _
            ExportData
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Export\", "Campaigns", "")> _
            Campaigns
        End Enum

        Public Enum CustomCommand As Integer
            LoadSettings = 128
        End Enum

        Public Enum SelectedData
            AllDataSelected
            TodaysDataSelected
            RangeDataSelected
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
        Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim ReturnedData As Generic.List(Of Database.Classes.ExportData) = Nothing
            Dim StoredProcedureValue As Integer = 0
            Dim RunAtTime As Date = Nothing
            Dim ExportDataEnum As AdvantageFramework.Services.MediaExport.SelectedData = AdvantageFramework.Services.MediaExport.SelectedData.AllDataSelected
            Dim DataStartDate As Date = Nothing
            Dim DataEndDate As Date = Nothing
            Dim Folder As String = ""
            Dim ClientCampaigns As List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing
            Dim ClientCodeAndName As String = ""
            Dim DashIndex As Integer = 0
            Dim ClientCode As String = ""
            Dim VendorCodes As String = ""
            Dim ClientCodes As String = ""
            Dim CampaignCodes As String = ""
            Dim Subdirectory As String = ""
            Dim FullPathDirectory As String = ""
            Dim RowCount As Integer = 0
            Dim NewFilename As String = ""
            Dim CSVRowData As String = ""
            Dim Filename As String = ""
            Dim FullPath As String = ""
            Dim FileStream As System.IO.FileStream = Nothing
            Dim ByteArray() As Byte = Nothing

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Export Started --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            WriteToEventLog("Loading Selected Campaigns --> " & DatabaseProfile.DatabaseName)

                            ClientCampaigns = AdvantageFramework.Services.MediaExport.LoadClientCampaigns(DataContext)

                            WriteToEventLog("Creating Client and Campaign Lists --> " & DatabaseProfile.DatabaseName)

                            For Each ClientCampaign In ClientCampaigns

                                ClientCodeAndName = ClientCampaign.CampaignClient.ToString()

                                DashIndex = ClientCodeAndName.IndexOf(" - ")

                                If DashIndex = -1 Then

                                    DashIndex = ClientCodeAndName.Length

                                End If

                                ClientCode = ClientCodeAndName.Substring(0, DashIndex)

                                If ClientCampaign.ID <> -1 Then

                                    If CampaignCodes.Length > 0 Then

                                        CampaignCodes += ","

                                    End If

                                    CampaignCodes += ClientCampaign.ID.ToString()

                                Else

                                    If Not ClientCodes.Contains(ClientCode) Then

                                        If ClientCodes.Length > 0 Then

                                            ClientCodes += ","

                                        End If

                                        ClientCodes += ClientCode

                                    End If

                                End If

                            Next

                            WriteToEventLog("Loading Folder and Data settings --> " & DatabaseProfile.DatabaseName)

                            AdvantageFramework.Services.MediaExport.LoadSettings(DataContext, RunAtTime, Folder, ExportDataEnum, DataStartDate, DataEndDate)

                            WriteToEventLog("Export Folder <" + Folder + "> --> " & DatabaseProfile.DatabaseName)

                            Select Case ExportDataEnum

                                Case AdvantageFramework.Services.MediaExport.SelectedData.AllDataSelected

                                    DataStartDate = DateTime.Parse("01/01/1900 12:00 AM")
                                    DataEndDate = DateTime.Parse("01/01/1900 12:00 AM")

                                Case AdvantageFramework.Services.MediaExport.SelectedData.TodaysDataSelected

                                    DataStartDate = DateTime.Today
                                    DataEndDate = DateTime.Today

                            End Select

                            WriteToEventLog("Executing Stored Procedure --> " & DatabaseProfile.DatabaseName)

                            ReturnedData = Database.Procedures.ExportDataComplexType.Load(DbContext,
                                                                                            True, True, True, True, True, True, True, True, True, True, True,
                                                                                            VendorCodes, ClientCodes, CampaignCodes,
                                                                                            DataStartDate, DataEndDate,
                                                                                            DataStartDate, DataEndDate,
                                                                                            True,
                                                                                            StoredProcedureValue).ToList

                            WriteToEventLog("Return Value (" + StoredProcedureValue.ToString() + ") from Stored Procedure --> " & DatabaseProfile.DatabaseName)

                            If StoredProcedureValue = 0 Then

                                Subdirectory = DatabaseProfile.DatabaseName + DateTime.Now.ToString(" - (MM_dd_yyyy HH_mm_ss)")

                                WriteToEventLog("Creating Sub-directory <" + Subdirectory + "> --> " & DatabaseProfile.DatabaseName)

                                FullPathDirectory = System.IO.Path.Combine(Folder, Subdirectory)

                                System.IO.Directory.CreateDirectory(FullPathDirectory)

                                For Each ExportData In ReturnedData

                                    NewFilename = ExportData.TableName + ".txt"
                                    CSVRowData = ExportData.CSVRowData

                                    CSVRowData = CSVRowData.Replace(vbNewLine, "\char(13) + char(10)\")
                                    CSVRowData = CSVRowData.Replace(vbCr, "\char(13)\")
                                    CSVRowData = CSVRowData.Replace(vbLf, "\char(10)\")

                                    If Filename <> NewFilename Then

                                        If FileStream IsNot Nothing Then

                                            WriteToEventLog("Closing File <" + Filename + "> - " + RowCount.ToString() + " Lines Written --> " & DatabaseProfile.DatabaseName)

                                            FileStream.Close()

                                            RowCount = 0

                                        End If

                                        Filename = NewFilename

                                        FullPath = System.IO.Path.Combine(FullPathDirectory, Filename)

                                        WriteToEventLog("Creating File <" + Filename + "> --> " & DatabaseProfile.DatabaseName)

                                        FileStream = System.IO.File.Create(FullPath)

                                    End If

                                    ByteArray = System.Text.Encoding.UTF8.GetBytes(CSVRowData + vbCrLf)

                                    FileStream.Write(ByteArray, 0, ByteArray.Length)

                                    RowCount += 1

                                Next

                                If FileStream IsNot Nothing Then

                                    WriteToEventLog("Closing File <" + Filename + "> - " + RowCount.ToString() + " Lines Written --> " & DatabaseProfile.DatabaseName)

                                    FileStream.Close()

                                End If

                            End If

                        End Using

                    End Using

                    WriteToEventLog("Export Finished --> " & DatabaseProfile.DatabaseName)

                End If

            Catch ex As Exception
                WriteToEventLog(ex.Message)
            End Try

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim ExportRunAt As Date = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportRunAt), ExportRunAt)

                                If ExportRunAt = CDate("01/01/2001 01:00 AM") Then

                                    ExportRunAt = Now.ToShortDateString & " " & ExportRunAt.ToShortTimeString

                                End If

                                If DateDiff(DateInterval.Minute, ExportRunAt, Now) >= 0 Then

                                    ExportRunAt = Now.AddDays(1).ToShortDateString & " " & ExportRunAt.ToShortTimeString

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportRunAt, ExportRunAt)

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

            If System.Diagnostics.EventLog.SourceExists("Export Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Export Source", "Export Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Export Log", My.Computer.Name, "Export Source")

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
        Public Function LoadClientCampaigns(ByVal DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of AdvantageFramework.Database.Classes.Campaign)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing
            Dim AdvantageServiceSettingLists As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceSettingList) = Nothing
            Dim ClientCampaign As AdvantageFramework.Database.Classes.Campaign = Nothing
            Dim ClientCampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

            If DataContext IsNot Nothing Then

                AdvantageService = LoadAdvantageService(DataContext)

                If AdvantageService IsNot Nothing Then

                    AdvantageServiceSetting = LoadAdvantageServiceSetting(DataContext, AdvantageService.ID, RegistrySetting.Campaigns)

                    If AdvantageServiceSetting IsNot Nothing Then

                        ClientCampaignList = New Generic.List(Of AdvantageFramework.Database.Classes.Campaign)

                        AdvantageServiceSettingLists = LoadAdvantageServiceSettingList(DataContext, AdvantageServiceSetting.ID)

                        For Each AdvantageServiceSettingList In AdvantageServiceSettingLists

                            If IsNothing(AdvantageServiceSettingList.Value) = False Then

                                Try

                                    ClientCampaign = AdvantageFramework.BaseClasses.ImportFromXML(AdvantageServiceSettingList.Value, GetType(AdvantageFramework.Database.Classes.Campaign))

                                Catch ex As Exception
                                    ClientCampaign = Nothing
                                End Try

                                If ClientCampaign IsNot Nothing Then

                                    ClientCampaignList.Add(ClientCampaign)

                                End If

                            End If

                        Next

                    End If

                End If

            End If

            LoadClientCampaigns = ClientCampaignList

        End Function
        Public Function InsertClientCampaign(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientCampaign As AdvantageFramework.Database.Classes.Campaign) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing
            Dim AdvantageServiceSettingList As AdvantageFramework.Database.Entities.AdvantageServiceSettingList = Nothing

            If DataContext IsNot Nothing Then

                AdvantageService = LoadAdvantageService(DataContext)

                If AdvantageService IsNot Nothing Then

                    AdvantageServiceSetting = LoadAdvantageServiceSetting(DataContext, AdvantageService.ID, RegistrySetting.Campaigns)

                    If AdvantageServiceSetting IsNot Nothing Then

                        AdvantageServiceSettingList = New AdvantageFramework.Database.Entities.AdvantageServiceSettingList

                        AdvantageServiceSettingList.AdvantageServiceSettingID = AdvantageServiceSetting.ID
                        AdvantageServiceSettingList.Value = AdvantageFramework.BaseClasses.CreateXML(ClientCampaign)

                        Inserted = AdvantageFramework.Database.Procedures.AdvantageServiceSettingList.Insert(DataContext, AdvantageServiceSettingList)

                    End If

                End If

            End If

            InsertClientCampaign = Inserted

        End Function
        Public Function DeleteClientCampaigns(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            If DataContext IsNot Nothing Then

                AdvantageService = LoadAdvantageService(DataContext)

                If AdvantageService IsNot Nothing Then

                    AdvantageServiceSetting = LoadAdvantageServiceSetting(DataContext, AdvantageService.ID, RegistrySetting.Campaigns)

                    If AdvantageServiceSetting IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.AdvantageServiceSettingList.DeleteByAdvantageServiceSettingID(DataContext, AdvantageServiceSetting.ID)

                    End If

                End If

            End If

            DeleteClientCampaigns = Deleted

        End Function
        Public Function DeleteClientCampaign(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientCampaign As AdvantageFramework.Database.Classes.Campaign) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing
            Dim AdvantageServiceSettingList As AdvantageFramework.Database.Entities.AdvantageServiceSettingList = Nothing
            Dim Campaign As AdvantageFramework.Database.Classes.Campaign = Nothing

            If DataContext IsNot Nothing Then

                AdvantageService = LoadAdvantageService(DataContext)

                If AdvantageService IsNot Nothing Then

                    AdvantageServiceSetting = LoadAdvantageServiceSetting(DataContext, AdvantageService.ID, RegistrySetting.Campaigns)

                    If AdvantageServiceSetting IsNot Nothing Then

                        For Each AdvantageServiceSettingList In LoadAdvantageServiceSettingList(DataContext, AdvantageServiceSetting.ID)

                            If IsNothing(AdvantageServiceSettingList.Value) = False Then

                                Try

                                    Campaign = AdvantageFramework.BaseClasses.ImportFromXML(AdvantageServiceSettingList.Value, GetType(AdvantageFramework.Database.Classes.Campaign))

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    If Campaign.ID = ClientCampaign.ID AndAlso Campaign.CampaignClient = ClientCampaign.CampaignClient Then

                                        Deleted = AdvantageFramework.Database.Procedures.AdvantageServiceSettingList.Delete(DataContext, AdvantageServiceSettingList)
                                        Exit For

                                    End If

                                End If

                            End If

                        Next

                    End If

                End If

            End If

            DeleteClientCampaign = Deleted

        End Function
        Public Function LoadAdvantageService(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.AdvantageService

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            Try

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageExportWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.MediaExport.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.MediaExport.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.MediaExport.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef ExportTime As DateTime, ByRef ExportPath As String, ByRef ExportDataEnum As SelectedData, ByRef StartDate As Date, ByRef EndDate As Date)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim ExportDataString As String = ""
            Dim DateArray() As String = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportRunAt), ExportTime)

                ExportPath = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportPath)

                ExportDataString = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportData)

                Select Case ExportDataString

                    Case SelectedData.AllDataSelected.ToString()

                        ExportDataEnum = SelectedData.AllDataSelected

                    Case SelectedData.TodaysDataSelected.ToString()

                        ExportDataEnum = SelectedData.TodaysDataSelected

                    Case Else

                        ExportDataEnum = SelectedData.RangeDataSelected

                        DateArray = ExportDataString.Split(",")

                        DateTime.TryParse(DateArray(0), StartDate)

                        If DateArray.Length > 1 Then

                            DateTime.TryParse(DateArray(1), EndDate)

                        Else

                            EndDate = Now

                        End If

                        If StartDate = System.DateTime.MinValue Then

                            StartDate = Now

                        End If

                        If EndDate = System.DateTime.MinValue Then

                            EndDate = Now

                        End If

                End Select

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ExportRunAt As DateTime, ByVal ExportPath As String, ByVal ExportData As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            'Dim PreviousExportRunAt As DateTime
            'Dim PreviousExportPath As String = ""
            'Dim PreviousExportData As String = ""
            'Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            'Dim ServiceReloadSettings As Boolean = False

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportRunAt, ExportRunAt)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportPath, ExportPath)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportData, ExportData)

            End If

            'DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportRunAt), PreviousExportRunAt)

            'If PreviousExportRunAt <> ExportRunAt Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportRunAt, ExportRunAt)
            '    ServiceReloadSettings = True

            'End If

            'PreviousExportPath = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportPath)

            'If PreviousExportPath <> ExportPath Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportPath, ExportPath)
            '    ServiceReloadSettings = True

            'End If

            'PreviousExportData = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportData)

            'If PreviousExportData <> ExportData Then

            '    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaExport.RegistrySetting.ExportData, ExportData)
            '    ServiceReloadSettings = True

            'End If

            'If ServiceReloadSettings Then

            '    ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageExportWindowsService)

            '    If ServiceController IsNot Nothing AndAlso ServiceController.Status = ServiceProcess.ServiceControllerStatus.Running Then

            '        ServiceController.ExecuteCommand(AdvantageFramework.Services.MediaExport.CustomCommand.LoadSettings)

            '    End If

            'End If

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

#End Region

    End Module

End Namespace

