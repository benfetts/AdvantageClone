Namespace Service

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Private Const BLANK_QUALITATIVE_CODE As String = "All"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub Start(ConnectionString As String)

            Using DbContext As New NationalFramework.Database.DbContext(ConnectionString)

                DbContext.Database.ExecuteSqlCommand("DELETE dbo.SERVICE_STATUS")

            End Using

        End Sub
        Public Sub LogEvent(ConnectionString As String, EventMessage As String)

            'objects
            Dim EventLog As NationalFramework.Database.Entities.EventLog = Nothing

            Using DbContext As New NationalFramework.Database.DbContext(ConnectionString)

                EventLog = New NationalFramework.Database.Entities.EventLog
                EventLog.EventDateTime = Now
                EventLog.EventMessage = EventMessage

                DbContext.EventLogs.Add(EventLog)
                DbContext.SaveChanges()

            End Using

        End Sub
        Public Sub SaveSettings(ConnectionString As String, TVSpotPath As String, TVNationalPath As String, RadioSpotPath As String, TimerMinutes As Integer, NCCDataPath As String)

            'objects
            Dim ServiceSetting As NationalFramework.Database.Entities.ServiceSetting = Nothing

            Using DbContext As New NationalFramework.Database.DbContext(ConnectionString)

                ServiceSetting = NationalFramework.Database.Procedures.ServiceSetting.LoadSingleRecord(DbContext)

                If ServiceSetting Is Nothing Then

                    ServiceSetting = New NationalFramework.Database.Entities.ServiceSetting

                    ServiceSetting.ID = 1
                    ServiceSetting.NationalPath = TVNationalPath
                    ServiceSetting.TimerMinutes = TimerMinutes

                    DbContext.ServiceSettings.Add(ServiceSetting)

                Else

                    ServiceSetting.NationalPath = TVNationalPath
                    ServiceSetting.TimerMinutes = TimerMinutes

                    DbContext.Entry(ServiceSetting).State = Entity.EntityState.Modified

                End If

                DbContext.SaveChanges()

            End Using

        End Sub
        Public Function CanSqlConnect(ConnectionString As String) As Boolean

            'objects
            Dim CanConnect As Boolean = False
            Dim _SqlConnection As SqlClient.SqlConnection = Nothing

            Try

                _SqlConnection = New SqlClient.SqlConnection(ConnectionString)
                _SqlConnection.Open()

                CanConnect = True

            Catch ex As Exception

            End Try

            CanSqlConnect = CanConnect

        End Function
        Public Function SetServiceToRun(ConnectionString As String) As Boolean

            'objects
            Dim ServiceStatus As NationalFramework.Database.Entities.ServiceStatus = Nothing
            Dim ServiceSet As Boolean = False

            Using DbContext As New Database.DbContext(ConnectionString)

                ServiceStatus = NationalFramework.Database.Procedures.ServiceStatus.LoadSingleRecord(DbContext)

                If ServiceStatus IsNot Nothing AndAlso Not ServiceStatus.IsRunning Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.SERVICE_STATUS SET LAST_RAN = DATEADD(d, -1, cast(getdate() as date)) WHERE IS_RUNNING = 0")

                    ServiceSet = True

                End If

            End Using

            SetServiceToRun = ServiceSet

        End Function
        Public Sub SyncFilesFromNielsen(National_Path As String, ConnectionString As String)

            'objects
            Dim ServiceStatus As NationalFramework.Database.Entities.ServiceStatus = Nothing
            Dim RunService As Boolean = False
            Dim ErrorMessage As String = Nothing

            Using DbContext As New Database.DbContext(ConnectionString)

                Try

                    ServiceStatus = NationalFramework.Database.Procedures.ServiceStatus.LoadSingleRecord(DbContext)

                    If ServiceStatus Is Nothing Then

                        ServiceStatus = New NationalFramework.Database.Entities.ServiceStatus
                        ServiceStatus.ID = 1
                        ServiceStatus.LastRan = Now
                        ServiceStatus.IsRunning = True

                        If NationalFramework.Database.Procedures.ServiceStatus.Insert(DbContext, ServiceStatus, ErrorMessage) = False Then

                            Throw New Exception(ErrorMessage)

                        End If

                        RunService = True

                    ElseIf ServiceStatus.IsRunning = False AndAlso DateDiff(DateInterval.Hour, ServiceStatus.LastRan, Now) >= 24 Then

                        ServiceStatus.LastRan = Now
                        ServiceStatus.IsRunning = True

                        If NationalFramework.Database.Procedures.ServiceStatus.Update(DbContext, ServiceStatus, ErrorMessage) = False Then

                            Throw New Exception(ErrorMessage)

                        End If

                        RunService = True

                    End If

                    If RunService Then

                        LogEvent(ConnectionString, "Unzipping national tv files")
                        UnzipNationalTVFiles(National_Path)

                        LogEvent(ConnectionString, "Saving national tv files to DOWNLOAD_FILE table")
                        SaveNationalFiles(DbContext, National_Path)

                        LogEvent(ConnectionString, "Calling ProcessFiles")
                        ProcessFiles(DbContext, ConnectionString, National_Path)

                        LogEvent(ConnectionString, "ProcessFiles complete")

                    End If

                Catch ex As Exception

                    LogEvent(ConnectionString, ex.Message & If(ex.InnerException IsNot Nothing, " Inner Exception:" & ex.InnerException.Message, ""))

                Finally

                    If RunService Then

                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.SERVICE_STATUS SET IS_RUNNING = 0")

                    End If

                End Try

            End Using

        End Sub
        Private Sub SaveNationalFiles(DbContext As Database.DbContext, TV_National_Path As String)

            'objects
            Dim DownloadFile As Database.Entities.DownloadFile = Nothing

            For Each Filename In System.IO.Directory.GetFiles(TV_National_Path)

                If Filename.ToLower.EndsWith(".mit") Then

                    Filename = System.IO.Path.GetFileName(Filename)

                    DownloadFile = NationalFramework.Database.Procedures.DownloadFile.LoadByFileName(DbContext, Filename)

                    If DownloadFile Is Nothing Then

                        DownloadFile = New Database.Entities.DownloadFile
                        DownloadFile.DbContext = DbContext

                        DownloadFile.FileName = System.IO.Path.GetFileName(Filename)

                        DbContext.DownloadFiles.Add(DownloadFile)

                    End If

                End If

            Next

            DbContext.SaveChanges()

        End Sub
        Private Sub ProcessFiles(DbContext As Database.DbContext, ConnectionString As String, National_Path As String)

            'objects
            Dim DownloadFiles As Generic.List(Of Database.Entities.DownloadFile) = Nothing

            DownloadFiles = (From Entity In NationalFramework.Database.Procedures.DownloadFile.LoadUnprocessed(DbContext)
                             Select Entity).OrderBy(Function(Entity) Entity.ID).ToList

            If DownloadFiles.Count > 0 Then

                For Each DownloadFile In DownloadFiles

                    If ProcessNationalFile(ConnectionString, System.IO.Path.Combine(National_Path, DownloadFile.FileName), DownloadFile.ID, DbContext) Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.DOWNLOAD_FILE SET PROCESSED_TIME = getdate() WHERE DOWNLOAD_FILE_ID = {0}", DownloadFile.ID))

                    End If

                Next

            End If

        End Sub
        <System.Runtime.CompilerServices.Extension>
        Private Function ToDataTable(Of T)(EntityList As IList(Of T)) As System.Data.DataTable

            Dim PropertyDescriptorCollection As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(GetType(T))

            For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                DataTable.Columns.Add(Prop.Name, If(Nullable.GetUnderlyingType(Prop.PropertyType), Prop.PropertyType))

            Next

            For Each Entity As T In EntityList

                DataRow = DataTable.NewRow()

                For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                    DataRow(Prop.Name) = If(Prop.GetValue(Entity), DBNull.Value)

                Next

                DataTable.Rows.Add(DataRow)

            Next

            Return DataTable

        End Function

#Region " National Data "

        Private Function GetLastSundayInAugust(DateToConvert As Date) As Date

            Dim LastSundayYear As Integer = 0
            Dim Found As Boolean = False
            Dim LastSundayInAugust As Date = Nothing
            Dim Day As Integer = 31

            If DateToConvert.Month <= 8 Then

                LastSundayYear = DateToConvert.Year

            Else

                LastSundayYear = DateToConvert.Year + 1

            End If

            While Not Found

                If DateSerial(LastSundayYear, 8, Day).DayOfWeek = DayOfWeek.Sunday Then

                    LastSundayInAugust = DateSerial(LastSundayYear, 8, Day)
                    Found = True

                Else

                    Day = Day - 1

                End If

            End While

            If DateToConvert > LastSundayInAugust Then

                LastSundayInAugust = GetLastSundayInAugust(LastSundayInAugust)

            End If

            GetLastSundayInAugust = LastSundayInAugust

        End Function
        Private Function GetDecimalValue(InputString As String) As Decimal

            Dim DecValue As Decimal = 0

            If IsNumeric(InputString) Then

                DecValue = CDec(InputString)

            End If

            GetDecimalValue = DecValue

        End Function
        Private Sub AddNationalNetwork(Code As String, Venue As String, DbContext As AdvantageFramework.National.Database.DbContext, ByRef NationalNetworks As Generic.List(Of AdvantageFramework.National.Database.Entities.NationalNetwork))

            Dim NationalNetwork As AdvantageFramework.National.Database.Entities.NationalNetwork = Nothing

            NationalNetwork = New AdvantageFramework.National.Database.Entities.NationalNetwork
            NationalNetwork.DbContext = DbContext

            NationalNetwork.Code = Code
            NationalNetwork.Name = Code
            NationalNetwork.VenueCode = Venue

            If AdvantageFramework.National.Database.Procedures.NationalNetwork.Insert(DbContext, NationalNetwork) Then

                NationalNetworks.Add(NationalNetwork)

            Else

                Throw New Exception("Could not add new National Network.")

            End If

        End Sub
        Private Function CreateNielsenNationalTVAudience(NationalDataID As Integer, TextLine As String, FilePrefix As String,
                                                         DbContext As AdvantageFramework.National.Database.DbContext,
                                                         ByRef NationalNetworks As Generic.List(Of AdvantageFramework.National.Database.Entities.NationalNetwork)) As AdvantageFramework.National.Database.Entities.NationalAudience

            'objects
            Dim Network As String = Nothing
            Dim SyndicatorInfo As String = Nothing
            Dim AudienceDateTime As Date = Nothing
            Dim NationalAudience As AdvantageFramework.National.Database.Entities.NationalAudience = Nothing

            NationalAudience = New AdvantageFramework.National.Database.Entities.NationalAudience

            If FilePrefix = "NSS" Then

                Network = Mid(TextLine, 250, 4).Trim
                SyndicatorInfo = Trim(Mid(TextLine, 41, 1))

                If NationalNetworks.Where(Function(NN) NN.Code = Network AndAlso NN.VenueCode = "S").Any = False Then

                    AddNationalNetwork(Network, "S", DbContext, NationalNetworks)

                End If

                NationalAudience.VenueCode = "S"

            End If

            If FilePrefix = "NTI" Then

                Network = Mid(TextLine, 15, 6).Trim
                SyndicatorInfo = ""

                If NationalNetworks.Where(Function(NN) NN.Code = Network AndAlso NN.VenueCode = "N").Any = False Then

                    AddNationalNetwork(Network, "N", DbContext, NationalNetworks)

                End If

                NationalAudience.VenueCode = "N"

            End If

            If FilePrefix = "NHI" Then

                Network = Mid(TextLine, 15, 6).Trim
                SyndicatorInfo = ""

                If NationalNetworks.Where(Function(NN) NN.Code = Network AndAlso NN.VenueCode = "C").Any = False Then

                    AddNationalNetwork(Network, "C", DbContext, NationalNetworks)

                End If

                NationalAudience.VenueCode = "C"

            End If

            AudienceDateTime = DateSerial(2000 + CInt(Mid(TextLine, 45, 2)), CInt(Mid(TextLine, 47, 2)), CInt(Mid(TextLine, 49, 2)))
            AudienceDateTime = DateAdd(DateInterval.Hour, CInt(Mid(TextLine, 86, 2)), AudienceDateTime)
            AudienceDateTime = DateAdd(DateInterval.Minute, CInt(Mid(TextLine, 88, 2)), AudienceDateTime)

            NationalAudience.NationalDataID = NationalDataID
            NationalAudience.Network = Network
            NationalAudience.AudienceDateTime = AudienceDateTime

            If IsNumeric(Mid(TextLine, 263, 6)) Then

                NationalAudience.CommercialProgramDuration = CInt(Mid(TextLine, 263, 6))

            Else

                NationalAudience.CommercialProgramDuration = 0

            End If

            NationalAudience.EventDuration = CInt(Mid(TextLine, 278, 4))
            NationalAudience.ProgramTotalDuration = CInt(Mid(TextLine, 331, 6))
            NationalAudience.ProgramName = Mid(TextLine, 115, 25)
            NationalAudience.TrackageName = Mid(TextLine, 140, 25)
            NationalAudience.EpisodeName = Mid(TextLine, 180, 32)
            NationalAudience.ProgramCode = CDec(Mid(TextLine, 21, 10))
            NationalAudience.TrackageCode = If(IsNumeric(Mid(TextLine, 31, 3)), CShort(Mid(TextLine, 31, 3)), 0)
            NationalAudience.NielsenDaypart = Mid(TextLine, 276, 2)
            NationalAudience.ProgramType = If(Mid(TextLine, 216, 2).Trim <> "", Mid(TextLine, 216, 2), "U")
            NationalAudience.IsCorrection = GetBooleanValue(Mid(TextLine, 11, 1))
            NationalAudience.IsBreakout = GetBooleanValue(Mid(TextLine, 35, 1))
            NationalAudience.IsSpecial = GetBooleanValue(Mid(TextLine, 36, 1))
            NationalAudience.IsRepeat = GetBooleanValue(Mid(TextLine, 230, 1))
            NationalAudience.IsPremiere = GetBooleanValue(Mid(TextLine, 238, 1))
            NationalAudience.IsDNA = GetBooleanValue(Mid(TextLine, 98, 1))
            NationalAudience.IsMulticast = GetBooleanValue(Mid(TextLine, 229, 1))
            NationalAudience.IsComplex = GetBooleanValue(Mid(TextLine, 231, 1))
            NationalAudience.IsShortDuration = GetBooleanValue(Mid(TextLine, 232, 1))
            NationalAudience.IsVariousMetadata = GetBooleanValue(Mid(TextLine, 237, 1))
            NationalAudience.IsVariousTimes = GetBooleanValue(Mid(TextLine, 319, 1))
            NationalAudience.IsGapped = CBool(If(Mid(TextLine, 42, 1) = "01", 1, 0))
            NationalAudience.IsWeeklyAverage = GetBooleanValue(Mid(TextLine, 239, 1))
            NationalAudience.SyndicatorInfo = SyndicatorInfo
            NationalAudience.TelecastNumber = CDec(Mid(TextLine, 58, 10))
            NationalAudience.CoverageSampleIdentification = CInt(Mid(TextLine, 71, 6))
            NationalAudience.TotalProgramIndicator = Mid(TextLine, 81, 2)
            NationalAudience.DaysOfWeekIndicator = Mid(TextLine, 282, 7)
            NationalAudience.StationCount = CInt(Mid(TextLine, 305, 5))
            NationalAudience.HeadendCount = CInt(Mid(TextLine, 310, 5))
            NationalAudience.CoveragePercent = CShort(Mid(TextLine, 315, 2))
            NationalAudience.ProgramHUT = GetDecimalValue(Mid(TextLine, 354, 9))
            NationalAudience.HouseholdAudience = GetDecimalValue(Mid(TextLine, 337, 9))

            CreateNielsenNationalTVAudience = NationalAudience

        End Function
        Private Function GetBooleanValue(InputString As String) As Boolean

            If InputString = "1" OrElse InputString.ToUpper = "Y" Then

                GetBooleanValue = True

            Else

                GetBooleanValue = False

            End If

        End Function
        Private Sub UpdateNielsenNationalAudienceFrom010(ByRef NationalAudience As AdvantageFramework.National.Database.Entities.NationalAudience, TextLine As String)

            NationalAudience.Females2to5Audience = GetDecimalValue(Mid(TextLine, 116, 9))
            NationalAudience.Females6to8Audience = GetDecimalValue(Mid(TextLine, 125, 9))
            NationalAudience.Females9to11Audience = GetDecimalValue(Mid(TextLine, 134, 9))
            NationalAudience.Females12to14Audience = GetDecimalValue(Mid(TextLine, 143, 9))
            NationalAudience.Females15to17Audience = GetDecimalValue(Mid(TextLine, 152, 9))
            NationalAudience.Females18to20Audience = GetDecimalValue(Mid(TextLine, 161, 9))
            NationalAudience.Females21to24Audience = GetDecimalValue(Mid(TextLine, 170, 9))
            NationalAudience.Females25to29Audience = GetDecimalValue(Mid(TextLine, 179, 9))
            NationalAudience.Females30to34Audience = GetDecimalValue(Mid(TextLine, 188, 9))
            NationalAudience.Females35to39Audience = GetDecimalValue(Mid(TextLine, 197, 9))
            NationalAudience.Females40to44Audience = GetDecimalValue(Mid(TextLine, 206, 9))
            NationalAudience.Females45to49Audience = GetDecimalValue(Mid(TextLine, 215, 9))
            NationalAudience.Females50to54Audience = GetDecimalValue(Mid(TextLine, 224, 9))
            NationalAudience.Females55to64Audience = GetDecimalValue(Mid(TextLine, 233, 9))
            NationalAudience.Females65PlusAudience = GetDecimalValue(Mid(TextLine, 242, 9))
            NationalAudience.Males2to5Audience = GetDecimalValue(Mid(TextLine, 251, 9))
            NationalAudience.Males6to8Audience = GetDecimalValue(Mid(TextLine, 260, 9))
            NationalAudience.Males9to11Audience = GetDecimalValue(Mid(TextLine, 269, 9))
            NationalAudience.Males12to14Audience = GetDecimalValue(Mid(TextLine, 278, 9))
            NationalAudience.Males15to17Audience = GetDecimalValue(Mid(TextLine, 287, 9))

        End Sub
        Private Sub UpdateNielsenNationalAudienceFrom210(ByRef NationalAudience As AdvantageFramework.National.Database.Entities.NationalAudience, TextLine As String)

            NationalAudience.Males18to20Audience = GetDecimalValue(Mid(TextLine, 116, 9))
            NationalAudience.Males21to24Audience = GetDecimalValue(Mid(TextLine, 125, 9))
            NationalAudience.Males25to29Audience = GetDecimalValue(Mid(TextLine, 134, 9))
            NationalAudience.Males30to34Audience = GetDecimalValue(Mid(TextLine, 143, 9))
            NationalAudience.Males35to39Audience = GetDecimalValue(Mid(TextLine, 152, 9))
            NationalAudience.Males40to44Audience = GetDecimalValue(Mid(TextLine, 161, 9))
            NationalAudience.Males45to49Audience = GetDecimalValue(Mid(TextLine, 170, 9))
            NationalAudience.Males50to54Audience = GetDecimalValue(Mid(TextLine, 179, 9))
            NationalAudience.Males55to64Audience = GetDecimalValue(Mid(TextLine, 188, 9))
            NationalAudience.Males65PlusAudience = GetDecimalValue(Mid(TextLine, 197, 9))
            NationalAudience.WorkingWomen18to20Audience = GetDecimalValue(Mid(TextLine, 224, 9))
            NationalAudience.WorkingWomen21to24Audience = GetDecimalValue(Mid(TextLine, 233, 9))
            NationalAudience.WorkingWomen25to34Audience = GetDecimalValue(Mid(TextLine, 242, 9))
            NationalAudience.WorkingWomen35to44Audience = GetDecimalValue(Mid(TextLine, 251, 9))
            NationalAudience.WorkingWomen45to49Audience = GetDecimalValue(Mid(TextLine, 260, 9))
            NationalAudience.WorkingWomen50to54Audience = GetDecimalValue(Mid(TextLine, 269, 9))
            NationalAudience.WorkingWomen55PlusAudience = GetDecimalValue(Mid(TextLine, 278, 9))

        End Sub
        Private Sub UpdateNielsenNationalAudienceFrom011(ByRef NationalAudience As AdvantageFramework.National.Database.Entities.NationalAudience, TextLine As String)

            NationalAudience.Females2to5PUT = GetDecimalValue(Mid(TextLine, 116, 9))
            NationalAudience.Females6to8PUT = GetDecimalValue(Mid(TextLine, 125, 9))
            NationalAudience.Females9to11PUT = GetDecimalValue(Mid(TextLine, 134, 9))
            NationalAudience.Females12to14PUT = GetDecimalValue(Mid(TextLine, 143, 9))
            NationalAudience.Females15to17PUT = GetDecimalValue(Mid(TextLine, 152, 9))
            NationalAudience.Females18to20PUT = GetDecimalValue(Mid(TextLine, 161, 9))
            NationalAudience.Females21to24PUT = GetDecimalValue(Mid(TextLine, 170, 9))
            NationalAudience.Females25to29PUT = GetDecimalValue(Mid(TextLine, 179, 9))
            NationalAudience.Females30to34PUT = GetDecimalValue(Mid(TextLine, 188, 9))
            NationalAudience.Females35to39PUT = GetDecimalValue(Mid(TextLine, 197, 9))
            NationalAudience.Females40to44PUT = GetDecimalValue(Mid(TextLine, 206, 9))
            NationalAudience.Females45to49PUT = GetDecimalValue(Mid(TextLine, 215, 9))
            NationalAudience.Females50to54PUT = GetDecimalValue(Mid(TextLine, 224, 9))
            NationalAudience.Females55to64PUT = GetDecimalValue(Mid(TextLine, 233, 9))
            NationalAudience.Females65PlusPUT = GetDecimalValue(Mid(TextLine, 242, 9))
            NationalAudience.Males2to5PUT = GetDecimalValue(Mid(TextLine, 251, 9))
            NationalAudience.Males6to8PUT = GetDecimalValue(Mid(TextLine, 260, 9))
            NationalAudience.Males9to11PUT = GetDecimalValue(Mid(TextLine, 269, 9))
            NationalAudience.Males12to14PUT = GetDecimalValue(Mid(TextLine, 278, 9))
            NationalAudience.Males15to17PUT = GetDecimalValue(Mid(TextLine, 287, 9))

        End Sub
        Private Sub UpdateNielsenNationalAudienceFrom211(ByRef NationalAudience As AdvantageFramework.National.Database.Entities.NationalAudience, TextLine As String)

            NationalAudience.Males18to20PUT = GetDecimalValue(Mid(TextLine, 116, 9))
            NationalAudience.Males21to24PUT = GetDecimalValue(Mid(TextLine, 125, 9))
            NationalAudience.Males25to29PUT = GetDecimalValue(Mid(TextLine, 134, 9))
            NationalAudience.Males30to34PUT = GetDecimalValue(Mid(TextLine, 143, 9))
            NationalAudience.Males35to39PUT = GetDecimalValue(Mid(TextLine, 152, 9))
            NationalAudience.Males40to44PUT = GetDecimalValue(Mid(TextLine, 161, 9))
            NationalAudience.Males45to49PUT = GetDecimalValue(Mid(TextLine, 170, 9))
            NationalAudience.Males50to54PUT = GetDecimalValue(Mid(TextLine, 179, 9))
            NationalAudience.Males55to64PUT = GetDecimalValue(Mid(TextLine, 188, 9))
            NationalAudience.Males65PlusPUT = GetDecimalValue(Mid(TextLine, 197, 9))
            NationalAudience.WorkingWomen18to20PUT = GetDecimalValue(Mid(TextLine, 224, 9))
            NationalAudience.WorkingWomen21to24PUT = GetDecimalValue(Mid(TextLine, 233, 9))
            NationalAudience.WorkingWomen25to34PUT = GetDecimalValue(Mid(TextLine, 242, 9))
            NationalAudience.WorkingWomen35to44PUT = GetDecimalValue(Mid(TextLine, 251, 9))
            NationalAudience.WorkingWomen45to49PUT = GetDecimalValue(Mid(TextLine, 260, 9))
            NationalAudience.WorkingWomen50to54PUT = GetDecimalValue(Mid(TextLine, 269, 9))
            NationalAudience.WorkingWomen55PlusPUT = GetDecimalValue(Mid(TextLine, 278, 9))

        End Sub
        Private Sub BulkInsertNationalAudienceList(DbContext As AdvantageFramework.National.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                   NationalAudiences As List(Of AdvantageFramework.National.Database.Entities.NationalAudience))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NationalAudiences.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("NationalDataID", "NATIONAL_DATA_ID")
                    .ColumnMappings.Add("TimeType", "TIME_TYPE")
                    .ColumnMappings.Add("Network", "NETWORK")
                    .ColumnMappings.Add("VenueCode", "VENUE_CODE")
                    .ColumnMappings.Add("AudienceDateTime", "AUDIENCE_DATETIME")
                    .ColumnMappings.Add("CommercialProgramDuration", "COMMERCIAL_PROGRAM_DURATION")
                    .ColumnMappings.Add("EventDuration", "EVENT_DURATION")
                    .ColumnMappings.Add("ProgramTotalDuration", "PROGRAM_TOTAL_DURATION")
                    .ColumnMappings.Add("ProgramName", "PROGRAM_NAME")
                    .ColumnMappings.Add("TrackageName", "TRACKAGE_NAME")
                    .ColumnMappings.Add("EpisodeName", "EPISODE_NAME")
                    .ColumnMappings.Add("ProgramCode", "PROGRAM_CODE")
                    .ColumnMappings.Add("TrackageCode", "TRACKAGE_CODE")
                    .ColumnMappings.Add("NielsenDaypart", "NIELSEN_DAYPART")
                    .ColumnMappings.Add("ProgramType", "PROGRAM_TYPE")
                    .ColumnMappings.Add("IsCorrection", "IS_CORRECTION")
                    .ColumnMappings.Add("IsBreakout", "IS_BREAKOUT")
                    .ColumnMappings.Add("IsSpecial", "IS_SPECIAL")
                    .ColumnMappings.Add("IsRepeat", "IS_REPEAT")
                    .ColumnMappings.Add("IsPremiere", "IS_PREMIERE")
                    .ColumnMappings.Add("IsDNA", "IS_DNA")
                    .ColumnMappings.Add("IsMulticast", "IS_MULTICAST")
                    .ColumnMappings.Add("IsComplex", "IS_COMPLEX")
                    .ColumnMappings.Add("IsShortDuration", "IS_SHORT_DURATION")
                    .ColumnMappings.Add("IsVariousMetadata", "IS_VARIOUS_METADATA")
                    .ColumnMappings.Add("IsVariousTimes", "IS_VARIOUS_TIMES")
                    .ColumnMappings.Add("IsGapped", "IS_GAPPED")
                    .ColumnMappings.Add("IsWeeklyAverage", "IS_WEEKLY_AVERAGE")
                    .ColumnMappings.Add("SyndicatorInfo", "SYNDICATOR_INFO")
                    .ColumnMappings.Add("TelecastNumber", "TELECAST_NUMBER")
                    .ColumnMappings.Add("CoverageSampleIdentification", "COVERAGE_SAMPLE_IDENTIFICATION")
                    .ColumnMappings.Add("TotalProgramIndicator", "TOTAL_PROGRAM_INDICATOR")
                    .ColumnMappings.Add("DaysOfWeekIndicator", "DAYS_OF_WEEK_INDICATOR")
                    .ColumnMappings.Add("StationCount", "STATION_COUNT")
                    .ColumnMappings.Add("HeadendCount", "HEADEND_COUNT")
                    .ColumnMappings.Add("CoveragePercent", "COVERAGE_PERCENT")
                    .ColumnMappings.Add("ProgramHUT", "PROGRAM_HUT")
                    .ColumnMappings.Add("HouseholdAudience", "HOUSEHOLD_AUD")
                    .ColumnMappings.Add("Females2to5Audience", "FEMALES_2TO5_AUD")
                    .ColumnMappings.Add("Females6to8Audience", "FEMALES_6TO8_AUD")
                    .ColumnMappings.Add("Females9to11Audience", "FEMALES_9TO11_AUD")
                    .ColumnMappings.Add("Females12to14Audience", "FEMALES_12TO14_AUD")
                    .ColumnMappings.Add("Females15to17Audience", "FEMALES_15TO17_AUD")
                    .ColumnMappings.Add("Females18to20Audience", "FEMALES_18TO20_AUD")
                    .ColumnMappings.Add("Females21to24Audience", "FEMALES_21TO24_AUD")
                    .ColumnMappings.Add("Females25to29Audience", "FEMALES_25TO29_AUD")
                    .ColumnMappings.Add("Females30to34Audience", "FEMALES_30TO34_AUD")
                    .ColumnMappings.Add("Females35to39Audience", "FEMALES_35TO39_AUD")
                    .ColumnMappings.Add("Females40to44Audience", "FEMALES_40TO44_AUD")
                    .ColumnMappings.Add("Females45to49Audience", "FEMALES_45TO49_AUD")
                    .ColumnMappings.Add("Females50to54Audience", "FEMALES_50TO54_AUD")
                    .ColumnMappings.Add("Females55to64Audience", "FEMALES_55TO64_AUD")
                    .ColumnMappings.Add("Females65PlusAudience", "FEMALES_65PLUS_AUD")
                    .ColumnMappings.Add("Males2to5Audience", "MALES_2TO5_AUD")
                    .ColumnMappings.Add("Males6to8Audience", "MALES_6TO8_AUD")
                    .ColumnMappings.Add("Males9to11Audience", "MALES_9TO11_AUD")
                    .ColumnMappings.Add("Males12to14Audience", "MALES_12TO14_AUD")
                    .ColumnMappings.Add("Males15to17Audience", "MALES_15TO17_AUD")
                    .ColumnMappings.Add("Males18to20Audience", "MALES_18TO20_AUD")
                    .ColumnMappings.Add("Males21to24Audience", "MALES_21TO24_AUD")
                    .ColumnMappings.Add("Males25to29Audience", "MALES_25TO29_AUD")
                    .ColumnMappings.Add("Males30to34Audience", "MALES_30TO34_AUD")
                    .ColumnMappings.Add("Males35to39Audience", "MALES_35TO39_AUD")
                    .ColumnMappings.Add("Males40to44Audience", "MALES_40TO44_AUD")
                    .ColumnMappings.Add("Males45to49Audience", "MALES_45TO49_AUD")
                    .ColumnMappings.Add("Males50to54Audience", "MALES_50TO54_AUD")
                    .ColumnMappings.Add("Males55to64Audience", "MALES_55TO64_AUD")
                    .ColumnMappings.Add("Males65PlusAudience", "MALES_65PLUS_AUD")
                    .ColumnMappings.Add("WorkingWomen18to20Audience", "WORKING_WOMEN_18TO20_AUD")
                    .ColumnMappings.Add("WorkingWomen21to24Audience", "WORKING_WOMEN_21TO24_AUD")
                    .ColumnMappings.Add("WorkingWomen25to34Audience", "WORKING_WOMEN_25TO34_AUD")
                    .ColumnMappings.Add("WorkingWomen35to44Audience", "WORKING_WOMEN_35TO44_AUD")
                    .ColumnMappings.Add("WorkingWomen45to49Audience", "WORKING_WOMEN_45TO49_AUD")
                    .ColumnMappings.Add("WorkingWomen50to54Audience", "WORKING_WOMEN_50TO54_AUD")
                    .ColumnMappings.Add("WorkingWomen55PlusAudience", "WORKING_WOMEN_55PLUS_AUD")
                    .ColumnMappings.Add("Females2to5PUT", "FEMALES_2TO5_PUT")
                    .ColumnMappings.Add("Females6to8PUT", "FEMALES_6TO8_PUT")
                    .ColumnMappings.Add("Females9to11PUT", "FEMALES_9TO11_PUT")
                    .ColumnMappings.Add("Females12to14PUT", "FEMALES_12TO14_PUT")
                    .ColumnMappings.Add("Females15to17PUT", "FEMALES_15TO17_PUT")
                    .ColumnMappings.Add("Females18to20PUT", "FEMALES_18TO20_PUT")
                    .ColumnMappings.Add("Females21to24PUT", "FEMALES_21TO24_PUT")
                    .ColumnMappings.Add("Females25to29PUT", "FEMALES_25TO29_PUT")
                    .ColumnMappings.Add("Females30to34PUT", "FEMALES_30TO34_PUT")
                    .ColumnMappings.Add("Females35to39PUT", "FEMALES_35TO39_PUT")
                    .ColumnMappings.Add("Females40to44PUT", "FEMALES_40TO44_PUT")
                    .ColumnMappings.Add("Females45to49PUT", "FEMALES_45TO49_PUT")
                    .ColumnMappings.Add("Females50to54PUT", "FEMALES_50TO54_PUT")
                    .ColumnMappings.Add("Females55to64PUT", "FEMALES_55TO64_PUT")
                    .ColumnMappings.Add("Females65PlusPUT", "FEMALES_65PLUS_PUT")
                    .ColumnMappings.Add("Males2to5PUT", "MALES_2TO5_PUT")
                    .ColumnMappings.Add("Males6to8PUT", "MALES_6TO8_PUT")
                    .ColumnMappings.Add("Males9to11PUT", "MALES_9TO11_PUT")
                    .ColumnMappings.Add("Males12to14PUT", "MALES_12TO14_PUT")
                    .ColumnMappings.Add("Males15to17PUT", "MALES_15TO17_PUT")
                    .ColumnMappings.Add("Males18to20PUT", "MALES_18TO20_PUT")
                    .ColumnMappings.Add("Males21to24PUT", "MALES_21TO24_PUT")
                    .ColumnMappings.Add("Males25to29PUT", "MALES_25TO29_PUT")
                    .ColumnMappings.Add("Males30to34PUT", "MALES_30TO34_PUT")
                    .ColumnMappings.Add("Males35to39PUT", "MALES_35TO39_PUT")
                    .ColumnMappings.Add("Males40to44PUT", "MALES_40TO44_PUT")
                    .ColumnMappings.Add("Males45to49PUT", "MALES_45TO49_PUT")
                    .ColumnMappings.Add("Males50to54PUT", "MALES_50TO54_PUT")
                    .ColumnMappings.Add("Males55to64PUT", "MALES_55TO64_PUT")
                    .ColumnMappings.Add("Males65PlusPUT", "MALES_65PLUS_PUT")
                    .ColumnMappings.Add("WorkingWomen18to20PUT", "WORKING_WOMEN_18TO20_PUT")
                    .ColumnMappings.Add("WorkingWomen21to24PUT", "WORKING_WOMEN_21TO24_PUT")
                    .ColumnMappings.Add("WorkingWomen25to34PUT", "WORKING_WOMEN_25TO34_PUT")
                    .ColumnMappings.Add("WorkingWomen35to44PUT", "WORKING_WOMEN_35TO44_PUT")
                    .ColumnMappings.Add("WorkingWomen45to49PUT", "WORKING_WOMEN_45TO49_PUT")
                    .ColumnMappings.Add("WorkingWomen50to54PUT", "WORKING_WOMEN_50TO54_PUT")
                    .ColumnMappings.Add("WorkingWomen55PlusPUT", "WORKING_WOMEN_55PLUS_PUT")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NATIONAL_AUDIENCE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNationalAudienceCorrectionList(DbContext As AdvantageFramework.National.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                             NationalAudienceCorrections As List(Of AdvantageFramework.National.Database.Entities.NationalAudienceCorrection))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NationalAudienceCorrections.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("MarketBreakID", "MARKET_BREAK_ID")
                    .ColumnMappings.Add("DataType", "DATA_TYPE")
                    .ColumnMappings.Add("Stream", "STREAM")
                    .ColumnMappings.Add("TimeType", "TIME_TYPE")
                    .ColumnMappings.Add("Network", "NETWORK")
                    .ColumnMappings.Add("VenueCode", "VENUE_CODE")
                    .ColumnMappings.Add("AudienceDateTime", "AUDIENCE_DATETIME")
                    .ColumnMappings.Add("ProgramCode", "PROGRAM_CODE")
                    .ColumnMappings.Add("TrackageCode", "TRACKAGE_CODE")
                    .ColumnMappings.Add("StartDate", "START_DATE")

                    .ColumnMappings.Add("CommercialProgramDuration", "COMMERCIAL_PROGRAM_DURATION")
                    .ColumnMappings.Add("EventDuration", "EVENT_DURATION")
                    .ColumnMappings.Add("ProgramTotalDuration", "PROGRAM_TOTAL_DURATION")
                    .ColumnMappings.Add("ProgramName", "PROGRAM_NAME")
                    .ColumnMappings.Add("TrackageName", "TRACKAGE_NAME")
                    .ColumnMappings.Add("EpisodeName", "EPISODE_NAME")
                    .ColumnMappings.Add("NielsenDaypart", "NIELSEN_DAYPART")
                    .ColumnMappings.Add("ProgramType", "PROGRAM_TYPE")
                    .ColumnMappings.Add("IsCorrection", "IS_CORRECTION")
                    .ColumnMappings.Add("IsBreakout", "IS_BREAKOUT")
                    .ColumnMappings.Add("IsSpecial", "IS_SPECIAL")
                    .ColumnMappings.Add("IsRepeat", "IS_REPEAT")
                    .ColumnMappings.Add("IsPremiere", "IS_PREMIERE")
                    .ColumnMappings.Add("IsDNA", "IS_DNA")
                    .ColumnMappings.Add("IsMulticast", "IS_MULTICAST")
                    .ColumnMappings.Add("IsComplex", "IS_COMPLEX")
                    .ColumnMappings.Add("IsShortDuration", "IS_SHORT_DURATION")
                    .ColumnMappings.Add("IsVariousMetadata", "IS_VARIOUS_METADATA")
                    .ColumnMappings.Add("IsVariousTimes", "IS_VARIOUS_TIMES")
                    .ColumnMappings.Add("IsGapped", "IS_GAPPED")
                    .ColumnMappings.Add("IsWeeklyAverage", "IS_WEEKLY_AVERAGE")
                    .ColumnMappings.Add("SyndicatorInfo", "SYNDICATOR_INFO")
                    .ColumnMappings.Add("TelecastNumber", "TELECAST_NUMBER")
                    .ColumnMappings.Add("CoverageSampleIdentification", "COVERAGE_SAMPLE_IDENTIFICATION")
                    .ColumnMappings.Add("TotalProgramIndicator", "TOTAL_PROGRAM_INDICATOR")
                    .ColumnMappings.Add("DaysOfWeekIndicator", "DAYS_OF_WEEK_INDICATOR")
                    .ColumnMappings.Add("StationCount", "STATION_COUNT")
                    .ColumnMappings.Add("HeadendCount", "HEADEND_COUNT")
                    .ColumnMappings.Add("CoveragePercent", "COVERAGE_PERCENT")
                    .ColumnMappings.Add("ProgramHUT", "PROGRAM_HUT")
                    .ColumnMappings.Add("HouseholdAudience", "HOUSEHOLD_AUD")
                    .ColumnMappings.Add("Females2to5Audience", "FEMALES_2TO5_AUD")
                    .ColumnMappings.Add("Females6to8Audience", "FEMALES_6TO8_AUD")
                    .ColumnMappings.Add("Females9to11Audience", "FEMALES_9TO11_AUD")
                    .ColumnMappings.Add("Females12to14Audience", "FEMALES_12TO14_AUD")
                    .ColumnMappings.Add("Females15to17Audience", "FEMALES_15TO17_AUD")
                    .ColumnMappings.Add("Females18to20Audience", "FEMALES_18TO20_AUD")
                    .ColumnMappings.Add("Females21to24Audience", "FEMALES_21TO24_AUD")
                    .ColumnMappings.Add("Females25to29Audience", "FEMALES_25TO29_AUD")
                    .ColumnMappings.Add("Females30to34Audience", "FEMALES_30TO34_AUD")
                    .ColumnMappings.Add("Females35to39Audience", "FEMALES_35TO39_AUD")
                    .ColumnMappings.Add("Females40to44Audience", "FEMALES_40TO44_AUD")
                    .ColumnMappings.Add("Females45to49Audience", "FEMALES_45TO49_AUD")
                    .ColumnMappings.Add("Females50to54Audience", "FEMALES_50TO54_AUD")
                    .ColumnMappings.Add("Females55to64Audience", "FEMALES_55TO64_AUD")
                    .ColumnMappings.Add("Females65PlusAudience", "FEMALES_65PLUS_AUD")
                    .ColumnMappings.Add("Males2to5Audience", "MALES_2TO5_AUD")
                    .ColumnMappings.Add("Males6to8Audience", "MALES_6TO8_AUD")
                    .ColumnMappings.Add("Males9to11Audience", "MALES_9TO11_AUD")
                    .ColumnMappings.Add("Males12to14Audience", "MALES_12TO14_AUD")
                    .ColumnMappings.Add("Males15to17Audience", "MALES_15TO17_AUD")
                    .ColumnMappings.Add("Males18to20Audience", "MALES_18TO20_AUD")
                    .ColumnMappings.Add("Males21to24Audience", "MALES_21TO24_AUD")
                    .ColumnMappings.Add("Males25to29Audience", "MALES_25TO29_AUD")
                    .ColumnMappings.Add("Males30to34Audience", "MALES_30TO34_AUD")
                    .ColumnMappings.Add("Males35to39Audience", "MALES_35TO39_AUD")
                    .ColumnMappings.Add("Males40to44Audience", "MALES_40TO44_AUD")
                    .ColumnMappings.Add("Males45to49Audience", "MALES_45TO49_AUD")
                    .ColumnMappings.Add("Males50to54Audience", "MALES_50TO54_AUD")
                    .ColumnMappings.Add("Males55to64Audience", "MALES_55TO64_AUD")
                    .ColumnMappings.Add("Males65PlusAudience", "MALES_65PLUS_AUD")
                    .ColumnMappings.Add("WorkingWomen18to20Audience", "WORKING_WOMEN_18TO20_AUD")
                    .ColumnMappings.Add("WorkingWomen21to24Audience", "WORKING_WOMEN_21TO24_AUD")
                    .ColumnMappings.Add("WorkingWomen25to34Audience", "WORKING_WOMEN_25TO34_AUD")
                    .ColumnMappings.Add("WorkingWomen35to44Audience", "WORKING_WOMEN_35TO44_AUD")
                    .ColumnMappings.Add("WorkingWomen45to49Audience", "WORKING_WOMEN_45TO49_AUD")
                    .ColumnMappings.Add("WorkingWomen50to54Audience", "WORKING_WOMEN_50TO54_AUD")
                    .ColumnMappings.Add("WorkingWomen55PlusAudience", "WORKING_WOMEN_55PLUS_AUD")
                    .ColumnMappings.Add("Females2to5PUT", "FEMALES_2TO5_PUT")
                    .ColumnMappings.Add("Females6to8PUT", "FEMALES_6TO8_PUT")
                    .ColumnMappings.Add("Females9to11PUT", "FEMALES_9TO11_PUT")
                    .ColumnMappings.Add("Females12to14PUT", "FEMALES_12TO14_PUT")
                    .ColumnMappings.Add("Females15to17PUT", "FEMALES_15TO17_PUT")
                    .ColumnMappings.Add("Females18to20PUT", "FEMALES_18TO20_PUT")
                    .ColumnMappings.Add("Females21to24PUT", "FEMALES_21TO24_PUT")
                    .ColumnMappings.Add("Females25to29PUT", "FEMALES_25TO29_PUT")
                    .ColumnMappings.Add("Females30to34PUT", "FEMALES_30TO34_PUT")
                    .ColumnMappings.Add("Females35to39PUT", "FEMALES_35TO39_PUT")
                    .ColumnMappings.Add("Females40to44PUT", "FEMALES_40TO44_PUT")
                    .ColumnMappings.Add("Females45to49PUT", "FEMALES_45TO49_PUT")
                    .ColumnMappings.Add("Females50to54PUT", "FEMALES_50TO54_PUT")
                    .ColumnMappings.Add("Females55to64PUT", "FEMALES_55TO64_PUT")
                    .ColumnMappings.Add("Females65PlusPUT", "FEMALES_65PLUS_PUT")
                    .ColumnMappings.Add("Males2to5PUT", "MALES_2TO5_PUT")
                    .ColumnMappings.Add("Males6to8PUT", "MALES_6TO8_PUT")
                    .ColumnMappings.Add("Males9to11PUT", "MALES_9TO11_PUT")
                    .ColumnMappings.Add("Males12to14PUT", "MALES_12TO14_PUT")
                    .ColumnMappings.Add("Males15to17PUT", "MALES_15TO17_PUT")
                    .ColumnMappings.Add("Males18to20PUT", "MALES_18TO20_PUT")
                    .ColumnMappings.Add("Males21to24PUT", "MALES_21TO24_PUT")
                    .ColumnMappings.Add("Males25to29PUT", "MALES_25TO29_PUT")
                    .ColumnMappings.Add("Males30to34PUT", "MALES_30TO34_PUT")
                    .ColumnMappings.Add("Males35to39PUT", "MALES_35TO39_PUT")
                    .ColumnMappings.Add("Males40to44PUT", "MALES_40TO44_PUT")
                    .ColumnMappings.Add("Males45to49PUT", "MALES_45TO49_PUT")
                    .ColumnMappings.Add("Males50to54PUT", "MALES_50TO54_PUT")
                    .ColumnMappings.Add("Males55to64PUT", "MALES_55TO64_PUT")
                    .ColumnMappings.Add("Males65PlusPUT", "MALES_65PLUS_PUT")
                    .ColumnMappings.Add("WorkingWomen18to20PUT", "WORKING_WOMEN_18TO20_PUT")
                    .ColumnMappings.Add("WorkingWomen21to24PUT", "WORKING_WOMEN_21TO24_PUT")
                    .ColumnMappings.Add("WorkingWomen25to34PUT", "WORKING_WOMEN_25TO34_PUT")
                    .ColumnMappings.Add("WorkingWomen35to44PUT", "WORKING_WOMEN_35TO44_PUT")
                    .ColumnMappings.Add("WorkingWomen45to49PUT", "WORKING_WOMEN_45TO49_PUT")
                    .ColumnMappings.Add("WorkingWomen50to54PUT", "WORKING_WOMEN_50TO54_PUT")
                    .ColumnMappings.Add("WorkingWomen55PlusPUT", "WORKING_WOMEN_55PLUS_PUT")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NATIONAL_AUDIENCE_CORRECTION"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNationalHUTPUTCorrectionList(DbContext As AdvantageFramework.National.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                           NationalHutputCorrections As List(Of AdvantageFramework.National.Database.Entities.NationalHutputCorrection))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NationalHutputCorrections.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("MarketBreakID", "MARKET_BREAK_ID")
                    .ColumnMappings.Add("DataType", "DATA_TYPE")
                    .ColumnMappings.Add("Stream", "STREAM")
                    .ColumnMappings.Add("HutputDatetime", "HUTPUT_DATETIME")
                    .ColumnMappings.Add("FeedPattern", "FEED_PATTERN")
                    .ColumnMappings.Add("StartDate", "START_DATE")

                    .ColumnMappings.Add("Household", "HOUSEHOLD_HUT")
                    .ColumnMappings.Add("Females2to5", "FEMALES_2TO5_PUT")
                    .ColumnMappings.Add("Females6to8", "FEMALES_6TO8_PUT")
                    .ColumnMappings.Add("Females9to11", "FEMALES_9TO11_PUT")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_PUT")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_PUT")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_PUT")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_PUT")
                    .ColumnMappings.Add("Females25to29", "FEMALES_25TO29_PUT")
                    .ColumnMappings.Add("Females30to34", "FEMALES_30TO34_PUT")
                    .ColumnMappings.Add("Females35to39", "FEMALES_35TO39_PUT")
                    .ColumnMappings.Add("Females40to44", "FEMALES_40TO44_PUT")
                    .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_PUT")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_PUT")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_PUT")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_PUT")
                    .ColumnMappings.Add("Males2to5", "MALES_2TO5_PUT")
                    .ColumnMappings.Add("Males6to8", "MALES_6TO8_PUT")
                    .ColumnMappings.Add("Males9to11", "MALES_9TO11_PUT")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_PUT")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_PUT")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_PUT")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_PUT")
                    .ColumnMappings.Add("Males25to29", "MALES_25TO29_PUT")
                    .ColumnMappings.Add("Males30to34", "MALES_30TO34_PUT")
                    .ColumnMappings.Add("Males35to39", "MALES_35TO39_PUT")
                    .ColumnMappings.Add("Males40to44", "MALES_40TO44_PUT")
                    .ColumnMappings.Add("Males45to49", "MALES_45TO49_PUT")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_PUT")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_PUT")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_PUT")
                    .ColumnMappings.Add("WorkingWomen18to20", "WORKING_WOMEN_18TO20_PUT")
                    .ColumnMappings.Add("WorkingWomen21to24", "WORKING_WOMEN_21TO24_PUT")
                    .ColumnMappings.Add("WorkingWomen25to34", "WORKING_WOMEN_25TO34_PUT")
                    .ColumnMappings.Add("WorkingWomen35to44", "WORKING_WOMEN_35TO44_PUT")
                    .ColumnMappings.Add("WorkingWomen45to49", "WORKING_WOMEN_45TO49_PUT")
                    .ColumnMappings.Add("WorkingWomen50to54", "WORKING_WOMEN_50TO54_PUT")
                    .ColumnMappings.Add("WorkingWomen55Plus", "WORKING_WOMEN_55PLUS_PUT")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NATIONAL_HUTPUT_CORRECTION"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub AddNielsenNationalTVHutput(DbContext As AdvantageFramework.National.Database.DbContext, NationalDataID As Integer, TextLine As String, TextLine2 As String, TextLine3 As String,
                                               ByRef NationalHutputs As List(Of AdvantageFramework.National.Database.Entities.NationalHutput))

            'objects
            Dim NationalHutput As AdvantageFramework.National.Database.Entities.NationalHutput = Nothing
            Dim HutputDateTime As Date = Nothing

            HutputDateTime = DateSerial(2000 + CInt(Mid(TextLine, 45, 2)), CInt(Mid(TextLine, 47, 2)), CInt(Mid(TextLine, 49, 2)))
            HutputDateTime = DateAdd(DateInterval.Hour, CInt(Mid(TextLine, 86, 2)), HutputDateTime)
            HutputDateTime = DateAdd(DateInterval.Minute, CInt(Mid(TextLine, 88, 2)), HutputDateTime)

            If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.National.Database.Entities.NationalHutput)
                    Where Entity.NationalDataID = NationalDataID AndAlso
                          Entity.HutputDatetime = HutputDateTime
                    Select Entity).Any Then

                NationalHutput = New AdvantageFramework.National.Database.Entities.NationalHutput

                NationalHutput.NationalDataID = NationalDataID
                NationalHutput.HutputDatetime = HutputDateTime

                NationalHutput.FeedPattern = Mid(TextLine, 34, 1)
                NationalHutput.Household = CInt(Mid(TextLine, 180, 9))

                NationalHutput.Females2to5 = CInt(Mid(TextLine2, 116, 9))
                NationalHutput.Females6to8 = CInt(Mid(TextLine2, 125, 9))
                NationalHutput.Females9to11 = CInt(Mid(TextLine2, 134, 9))
                NationalHutput.Females12to14 = CInt(Mid(TextLine2, 143, 9))
                NationalHutput.Females15to17 = CInt(Mid(TextLine2, 152, 9))
                NationalHutput.Females18to20 = CInt(Mid(TextLine2, 161, 9))
                NationalHutput.Females21to24 = CInt(Mid(TextLine2, 170, 9))
                NationalHutput.Females25to29 = CInt(Mid(TextLine2, 179, 9))
                NationalHutput.Females30to34 = CInt(Mid(TextLine2, 188, 9))
                NationalHutput.Females35to39 = CInt(Mid(TextLine2, 197, 9))
                NationalHutput.Females40to44 = CInt(Mid(TextLine2, 206, 9))
                NationalHutput.Females45to49 = CInt(Mid(TextLine2, 215, 9))
                NationalHutput.Females50to54 = CInt(Mid(TextLine2, 224, 9))
                NationalHutput.Females55to64 = CInt(Mid(TextLine2, 233, 9))
                NationalHutput.Females65Plus = CInt(Mid(TextLine2, 242, 9))
                NationalHutput.Males2to5 = CInt(Mid(TextLine2, 251, 9))
                NationalHutput.Males6to8 = CInt(Mid(TextLine2, 260, 9))
                NationalHutput.Males9to11 = CInt(Mid(TextLine2, 269, 9))
                NationalHutput.Males12to14 = CInt(Mid(TextLine2, 278, 9))
                NationalHutput.Males15to17 = CInt(Mid(TextLine2, 287, 9))

                NationalHutput.Males18to20 = CInt(Mid(TextLine3, 116, 9))
                NationalHutput.Males21to24 = CInt(Mid(TextLine3, 125, 9))
                NationalHutput.Males25to29 = CInt(Mid(TextLine3, 134, 9))
                NationalHutput.Males30to34 = CInt(Mid(TextLine3, 143, 9))
                NationalHutput.Males35to39 = CInt(Mid(TextLine3, 152, 9))
                NationalHutput.Males40to44 = CInt(Mid(TextLine3, 161, 9))
                NationalHutput.Males45to49 = CInt(Mid(TextLine3, 170, 9))
                NationalHutput.Males50to54 = CInt(Mid(TextLine3, 179, 9))
                NationalHutput.Males55to64 = CInt(Mid(TextLine3, 188, 9))
                NationalHutput.Males65Plus = CInt(Mid(TextLine3, 197, 9))
                NationalHutput.WorkingWomen18to20 = CInt(Mid(TextLine3, 224, 9))
                NationalHutput.WorkingWomen21to24 = CInt(Mid(TextLine3, 233, 9))
                NationalHutput.WorkingWomen25to34 = CInt(Mid(TextLine3, 242, 9))
                NationalHutput.WorkingWomen35to44 = CInt(Mid(TextLine3, 251, 9))
                NationalHutput.WorkingWomen45to49 = CInt(Mid(TextLine3, 260, 9))
                NationalHutput.WorkingWomen50to54 = CInt(Mid(TextLine3, 269, 9))
                NationalHutput.WorkingWomen55Plus = CInt(Mid(TextLine3, 278, 9))

                NationalHutputs.Add(NationalHutput)

            End If

        End Sub
        Private Sub BulkInsertNationalHutputList(DbContext As AdvantageFramework.National.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                 NationalHutputs As List(Of AdvantageFramework.National.Database.Entities.NationalHutput))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NationalHutputs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("NationalDataID", "NATIONAL_DATA_ID")
                    .ColumnMappings.Add("HutputDatetime", "HUTPUT_DATETIME")
                    .ColumnMappings.Add("FeedPattern", "FEED_PATTERN")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_HUT")
                    .ColumnMappings.Add("Females2to5", "FEMALES_2TO5_PUT")
                    .ColumnMappings.Add("Females6to8", "FEMALES_6TO8_PUT")
                    .ColumnMappings.Add("Females9to11", "FEMALES_9TO11_PUT")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_PUT")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_PUT")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_PUT")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_PUT")
                    .ColumnMappings.Add("Females25to29", "FEMALES_25TO29_PUT")
                    .ColumnMappings.Add("Females30to34", "FEMALES_30TO34_PUT")
                    .ColumnMappings.Add("Females35to39", "FEMALES_35TO39_PUT")
                    .ColumnMappings.Add("Females40to44", "FEMALES_40TO44_PUT")
                    .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_PUT")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_PUT")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_PUT")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_PUT")
                    .ColumnMappings.Add("Males2to5", "MALES_2TO5_PUT")
                    .ColumnMappings.Add("Males6to8", "MALES_6TO8_PUT")
                    .ColumnMappings.Add("Males9to11", "MALES_9TO11_PUT")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_PUT")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_PUT")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_PUT")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_PUT")
                    .ColumnMappings.Add("Males25to29", "MALES_25TO29_PUT")
                    .ColumnMappings.Add("Males30to34", "MALES_30TO34_PUT")
                    .ColumnMappings.Add("Males35to39", "MALES_35TO39_PUT")
                    .ColumnMappings.Add("Males40to44", "MALES_40TO44_PUT")
                    .ColumnMappings.Add("Males45to49", "MALES_45TO49_PUT")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_PUT")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_PUT")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_PUT")
                    .ColumnMappings.Add("WorkingWomen18to20", "WORKING_WOMEN_18TO20_PUT")
                    .ColumnMappings.Add("WorkingWomen21to24", "WORKING_WOMEN_21TO24_PUT")
                    .ColumnMappings.Add("WorkingWomen25to34", "WORKING_WOMEN_25TO34_PUT")
                    .ColumnMappings.Add("WorkingWomen35to44", "WORKING_WOMEN_35TO44_PUT")
                    .ColumnMappings.Add("WorkingWomen45to49", "WORKING_WOMEN_45TO49_PUT")
                    .ColumnMappings.Add("WorkingWomen50to54", "WORKING_WOMEN_50TO54_PUT")
                    .ColumnMappings.Add("WorkingWomen55Plus", "WORKING_WOMEN_55PLUS_PUT")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NATIONAL_HUTPUT"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub AddNielsenNationalTVUniverse(DbContext As AdvantageFramework.National.Database.DbContext, IsHispanic As Boolean, MarketBreakID As Integer,
                                                 TextLine As String, TextLine2 As String, TextLine3 As String,
                                                 ByRef NationalUniverses As List(Of AdvantageFramework.National.Database.Entities.NationalUniverse))

            'objects
            Dim NationalUniverse As AdvantageFramework.National.Database.Entities.NationalUniverse = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim NationalYear As AdvantageFramework.National.Database.Entities.NationalYear = Nothing

            If Mid(TextLine, 85, 1) <> "H" Then

                Throw New Exception("Record 01 - Record Type does not equal H.")

            ElseIf Mid(TextLine, 92, 3) <> "000" Then

                Throw New Exception("Record 01 - Demo Group does not equal 000.")

            ElseIf Mid(TextLine2, 85, 1) <> "P" Then

                Throw New Exception("Record 01 - Record Type does not equal P.")

            ElseIf Mid(TextLine2, 92, 3) <> "001" Then

                Throw New Exception("Record 01 - Demo Group does not equal 001.")

            ElseIf Mid(TextLine3, 85, 1) <> "P" Then

                Throw New Exception("Record 01 - Record Type does not equal P.")

            ElseIf Mid(TextLine3, 92, 3) <> "021" Then

                Throw New Exception("Record 01 - Demo Group does not equal 021.")

            End If

            StartDate = DateSerial(Mid(TextLine, 45, 2), Mid(TextLine, 47, 2), Mid(TextLine, 49, 2))
            EndDate = DateSerial(Mid(TextLine, 52, 2), Mid(TextLine, 54, 2), Mid(TextLine, 56, 2))

            NationalYear = (From Entity In DbContext.GetQuery(Of AdvantageFramework.National.Database.Entities.NationalYear)
                            Where Entity.StartDate = StartDate AndAlso
                                  Entity.EndDate = EndDate
                            Select Entity).SingleOrDefault

            If NationalYear Is Nothing Then

                Throw New Exception("Cannot find national year for universe record.")

            End If

            If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.National.Database.Entities.NationalUniverse)
                    Where Entity.Year = NationalYear.Year AndAlso
                          Entity.IsHispanic = IsHispanic AndAlso
                          Entity.MarketBreakID = MarketBreakID
                    Select Entity).Any Then

                NationalUniverse = New AdvantageFramework.National.Database.Entities.NationalUniverse

                NationalUniverse.Year = NationalYear.Year
                NationalUniverse.IsHispanic = IsHispanic
                NationalUniverse.MarketBreakID = MarketBreakID
                NationalUniverse.Household = CInt(Mid(TextLine, 180, 9)) * 1000
                NationalUniverse.Females2to5 = CInt(Mid(TextLine2, 116, 9)) * 1000
                NationalUniverse.Females6to8 = CInt(Mid(TextLine2, 125, 9)) * 1000
                NationalUniverse.Females9to11 = CInt(Mid(TextLine2, 134, 9)) * 1000
                NationalUniverse.Females12to14 = CInt(Mid(TextLine2, 143, 9)) * 1000
                NationalUniverse.Females15to17 = CInt(Mid(TextLine2, 152, 9)) * 1000
                NationalUniverse.Females18to20 = CInt(Mid(TextLine2, 161, 9)) * 1000
                NationalUniverse.Females21to24 = CInt(Mid(TextLine2, 170, 9)) * 1000
                NationalUniverse.Females25to29 = CInt(Mid(TextLine2, 179, 9)) * 1000
                NationalUniverse.Females30to34 = CInt(Mid(TextLine2, 188, 9)) * 1000
                NationalUniverse.Females35to39 = CInt(Mid(TextLine2, 197, 9)) * 1000
                NationalUniverse.Females40to44 = CInt(Mid(TextLine2, 206, 9)) * 1000
                NationalUniverse.Females45to49 = CInt(Mid(TextLine2, 215, 9)) * 1000
                NationalUniverse.Females50to54 = CInt(Mid(TextLine2, 224, 9)) * 1000
                NationalUniverse.Females55to64 = CInt(Mid(TextLine2, 233, 9)) * 1000
                NationalUniverse.Females65Plus = CInt(Mid(TextLine2, 242, 9)) * 1000
                NationalUniverse.Males2to5 = CInt(Mid(TextLine2, 251, 9)) * 1000
                NationalUniverse.Males6to8 = CInt(Mid(TextLine2, 260, 9)) * 1000
                NationalUniverse.Males9to11 = CInt(Mid(TextLine2, 269, 9)) * 1000
                NationalUniverse.Males12to14 = CInt(Mid(TextLine2, 278, 9)) * 1000
                NationalUniverse.Males15to17 = CInt(Mid(TextLine2, 287, 9)) * 1000
                NationalUniverse.Males18to20 = CInt(Mid(TextLine3, 116, 9)) * 1000
                NationalUniverse.Males21to24 = CInt(Mid(TextLine3, 125, 9)) * 1000
                NationalUniverse.Males25to29 = CInt(Mid(TextLine3, 134, 9)) * 1000
                NationalUniverse.Males30to34 = CInt(Mid(TextLine3, 143, 9)) * 1000
                NationalUniverse.Males35to39 = CInt(Mid(TextLine3, 152, 9)) * 1000
                NationalUniverse.Males40to44 = CInt(Mid(TextLine3, 161, 9)) * 1000
                NationalUniverse.Males45to49 = CInt(Mid(TextLine3, 170, 9)) * 1000
                NationalUniverse.Males50to54 = CInt(Mid(TextLine3, 179, 9)) * 1000
                NationalUniverse.Males55to64 = CInt(Mid(TextLine3, 188, 9)) * 1000
                NationalUniverse.Males65Plus = CInt(Mid(TextLine3, 197, 9)) * 1000
                NationalUniverse.WorkingWomen18to20 = CInt(Mid(TextLine3, 224, 9)) * 1000
                NationalUniverse.WorkingWomen21to24 = CInt(Mid(TextLine3, 233, 9)) * 1000
                NationalUniverse.WorkingWomen25to34 = CInt(Mid(TextLine3, 242, 9)) * 1000
                NationalUniverse.WorkingWomen35to44 = CInt(Mid(TextLine3, 251, 9)) * 1000
                NationalUniverse.WorkingWomen45to49 = CInt(Mid(TextLine3, 260, 9)) * 1000
                NationalUniverse.WorkingWomen50to54 = CInt(Mid(TextLine3, 269, 9)) * 1000
                NationalUniverse.WorkingWomen55Plus = CInt(Mid(TextLine3, 278, 9)) * 1000

                NationalUniverses.Add(NationalUniverse)

            End If

        End Sub
        Private Sub BulkInsertNationalUniverseList(DbContext As AdvantageFramework.National.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                                   NationalUniverses As List(Of AdvantageFramework.National.Database.Entities.NationalUniverse))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NationalUniverses.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("IsHispanic", "IS_HISPANIC")
                    .ColumnMappings.Add("MarketBreakID", "MARKET_BREAK_ID")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_UE")
                    .ColumnMappings.Add("Females2to5", "FEMALES_2TO5_UE")
                    .ColumnMappings.Add("Females6to8", "FEMALES_6TO8_UE")
                    .ColumnMappings.Add("Females9to11", "FEMALES_9TO11_UE")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_UE")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_UE")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_UE")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_UE")
                    .ColumnMappings.Add("Females25to29", "FEMALES_25TO29_UE")
                    .ColumnMappings.Add("Females30to34", "FEMALES_30TO34_UE")
                    .ColumnMappings.Add("Females35to39", "FEMALES_35TO39_UE")
                    .ColumnMappings.Add("Females40to44", "FEMALES_40TO44_UE")
                    .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_UE")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_UE")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_UE")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_UE")
                    .ColumnMappings.Add("Males2to5", "MALES_2TO5_UE")
                    .ColumnMappings.Add("Males6to8", "MALES_6TO8_UE")
                    .ColumnMappings.Add("Males9to11", "MALES_9TO11_UE")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_UE")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_UE")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_UE")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_UE")
                    .ColumnMappings.Add("Males25to29", "MALES_25TO29_UE")
                    .ColumnMappings.Add("Males30to34", "MALES_30TO34_UE")
                    .ColumnMappings.Add("Males35to39", "MALES_35TO39_UE")
                    .ColumnMappings.Add("Males40to44", "MALES_40TO44_UE")
                    .ColumnMappings.Add("Males45to49", "MALES_45TO49_UE")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_UE")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_UE")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_UE")
                    .ColumnMappings.Add("WorkingWomen18to20", "WORKING_WOMEN_18TO20_UE")
                    .ColumnMappings.Add("WorkingWomen21to24", "WORKING_WOMEN_21TO24_UE")
                    .ColumnMappings.Add("WorkingWomen25to34", "WORKING_WOMEN_25TO34_UE")
                    .ColumnMappings.Add("WorkingWomen35to44", "WORKING_WOMEN_35TO44_UE")
                    .ColumnMappings.Add("WorkingWomen45to49", "WORKING_WOMEN_45TO49_UE")
                    .ColumnMappings.Add("WorkingWomen50to54", "WORKING_WOMEN_50TO54_UE")
                    .ColumnMappings.Add("WorkingWomen55Plus", "WORKING_WOMEN_55PLUS_UE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NATIONAL_UNIVERSE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Function ProcessNationalFile(ConnectionString As String, ByVal PathFile As String, DownloadFileID As Integer, DownloadFileDbContext As Database.DbContext) As Boolean

            'objects
            Dim Processed As Boolean = False
            Dim Path As String = Nothing
            Dim File As String = Nothing
            Dim NationalData As AdvantageFramework.National.Database.Entities.NationalData = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FilenameFields() As String = Nothing
            Dim FilePrefix As String = Nothing
            Dim Stream As String = Nothing
            Dim TextLine As String = Nothing
            Dim TextLine2 As String = Nothing
            Dim TextLine3 As String = Nothing
            Dim TextTemp As String = Nothing
            Dim RecordSeqCode As String = Nothing
            Dim RecordType As String = Nothing
            Dim ViewingTypes As IEnumerable(Of String) = Nothing
            Dim NationalNetworks As Generic.List(Of AdvantageFramework.National.Database.Entities.NationalNetwork) = Nothing
            Dim MarketBreak As AdvantageFramework.National.Database.Entities.MarketBreak = Nothing
            Dim NationalYear As AdvantageFramework.National.Database.Entities.NationalYear = Nothing
            Dim NationalUniverses As List(Of AdvantageFramework.National.Database.Entities.NationalUniverse) = Nothing
            Dim NationalHutputs As List(Of AdvantageFramework.National.Database.Entities.NationalHutput) = Nothing
            Dim NationalAudiences As List(Of AdvantageFramework.National.Database.Entities.NationalAudience) = Nothing
            Dim NationalAudience As AdvantageFramework.National.Database.Entities.NationalAudience = Nothing
            Dim NationalAudienceCorrections As List(Of AdvantageFramework.National.Database.Entities.NationalAudienceCorrection) = Nothing
            Dim NationalHutputCorrections As List(Of AdvantageFramework.National.Database.Entities.NationalHutputCorrection) = Nothing
            Dim SkipRead As Boolean = False
            Dim IsHispanic As Boolean = False
            Dim IsPBSNSS As Boolean = False
            Dim Has010 As Boolean = False
            Dim Has011 As Boolean = False
            Dim Has210 As Boolean = False
            Dim Has211 As Boolean = False
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim IsPreliminary As Boolean = False
            Dim DownloadFile As NationalFramework.Database.Entities.DownloadFile = Nothing
            Dim PrelimaryFileName As String = Nothing
            Dim IsNewFile As Boolean = False
            Dim PFound As Boolean = False

            ViewingTypes = {" ", "2", "4", "6", "8", "A"}

            Path = System.IO.Path.GetDirectoryName(PathFile)
            File = System.IO.Path.GetFileName(PathFile)

            If System.IO.File.Exists(PathFile) Then

                Using DbContext As New AdvantageFramework.National.Database.DbContext(ConnectionString, Nothing)

                    NationalNetworks = AdvantageFramework.National.Database.Procedures.NationalNetwork.Load(DbContext).ToList

                    Using tran = DbContext.Database.BeginTransaction()

                        Try

                            If (File.ToUpper.StartsWith("NHI_AGENCY") OrElse File.ToUpper.StartsWith("NSS_AGSTD") OrElse
                                    File.ToUpper.StartsWith("NTI_AGFUL") OrElse File.ToUpper.StartsWith("NHI_CPAGENCY") OrElse
                                    File.ToUpper.StartsWith("NSS_CPAGSTD") OrElse File.ToUpper.StartsWith("NTI_CPAGFUL") OrElse
                                    File.ToUpper.StartsWith("NHIH_AGENCY") OrElse File.ToUpper.StartsWith("NSSH_AGSTD") OrElse
                                    File.ToUpper.StartsWith("NTIH_AGFUL") OrElse File.ToUpper.StartsWith("NHIH_CPAGENCY") OrElse
                                    File.ToUpper.StartsWith("NSSH_CPAGSTD") OrElse File.ToUpper.StartsWith("NTIH_CPAGFUL")) = False Then

                                Throw New Exception("SKIPFILE")

                            End If

                            StreamReader = New System.IO.StreamReader(PathFile)

                            FilenameFields = Mid(File.ToUpper, 1, InStr(File, ".") - 1).Split("_")

                            FilePrefix = Mid(FilenameFields(0), InStrRev(FilenameFields(0), "\") + 1)

                            Stream = Mid(File.ToUpper, InStrRev(File, ".") - 2, 2)

                            NationalUniverses = New List(Of AdvantageFramework.National.Database.Entities.NationalUniverse)
                            NationalHutputs = New List(Of AdvantageFramework.National.Database.Entities.NationalHutput)
                            NationalAudiences = New List(Of AdvantageFramework.National.Database.Entities.NationalAudience)

                            Do While StreamReader.Peek() <> -1

                                If SkipRead = False Then

                                    TextLine = StreamReader.ReadLine()

                                Else

                                    SkipRead = False

                                End If

                                If String.IsNullOrWhiteSpace(TextLine) = False Then

                                    RecordSeqCode = Mid(TextLine, 1, 2)

                                End If

                                Select Case RecordSeqCode

                                    Case "00"

                                        MarketBreak = (From Entity In DbContext.GetQuery(Of AdvantageFramework.National.Database.Entities.MarketBreak)
                                                       Where Entity.NtiID = CInt(Mid(TextLine, 78, 3))
                                                       Select Entity).SingleOrDefault

                                        If MarketBreak Is Nothing Then

                                            Throw New Exception("Cannot find record in Market Break table for: " & Mid(TextLine, 78, 3))

                                        End If

                                        If FilePrefix.ToUpper = "NTIH" OrElse FilePrefix.ToUpper = "NSSH" OrElse FilePrefix.ToUpper = "NHIH" Then

                                            IsHispanic = True

                                        Else

                                            IsHispanic = False

                                        End If

                                        If Mid(TextLine, 115, 7).ToUpper = "NSS PBS" OrElse Mid(TextLine, 115, 7).ToUpper = "NSS PBN" Then

                                            IsPBSNSS = True

                                        Else

                                            IsPBSNSS = False

                                        End If

                                        StartDate = DateSerial(Mid(TextLine, 45, 2), Mid(TextLine, 47, 2), Mid(TextLine, 49, 2))
                                        EndDate = DateSerial(Mid(TextLine, 52, 2), Mid(TextLine, 54, 2), Mid(TextLine, 56, 2))

                                        IsNewFile = False

                                        If File.ToUpper.Contains("PRL") Then

                                            IsPreliminary = True

                                            DownloadFile = NationalFramework.Database.Procedures.DownloadFile.LoadByFileName(DownloadFileDbContext, File.ToUpper.Replace("PRL", ""))

                                            If DownloadFile IsNot Nothing Then

                                                Throw New Exception("SKIPFILE")

                                            Else

                                                IsNewFile = True

                                            End If

                                        Else

                                            IsPreliminary = False

                                            If File.ToUpper.EndsWith("_L3.MIT") Then

                                                PrelimaryFileName = File.ToUpper.Replace("_L3.MIT", "_PRLL3.MIT")

                                            ElseIf File.ToUpper.EndsWith("_L7.MIT") Then

                                                PrelimaryFileName = File.ToUpper.Replace("_L7.MIT", "_PRLL7.MIT")

                                            ElseIf File.ToUpper.EndsWith("_LS.MIT") Then

                                                PrelimaryFileName = File.ToUpper.Replace("_LS.MIT", "_PRLLS.MIT")

                                            ElseIf File.ToUpper.EndsWith("_LV.MIT") Then

                                                PrelimaryFileName = File.ToUpper.Replace("_LV.MIT", "_PRLLV.MIT")

                                            End If

                                            If (From Entity In AdvantageFramework.National.Database.Procedures.NationalData.Load(DbContext)
                                                Where Entity.FileName.ToUpper = PrelimaryFileName.ToUpper AndAlso
                                                      Entity.IsPreliminary = True
                                                Select Entity).Any Then

                                                NationalData = (From Entity In AdvantageFramework.National.Database.Procedures.NationalData.Load(DbContext)
                                                                Where Entity.FileName.ToUpper = PrelimaryFileName.ToUpper AndAlso
                                                                      Entity.IsPreliminary = True
                                                                Select Entity).Single

                                                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NATIONAL_AUDIENCE WHERE NATIONAL_DATA_ID = {0}", NationalData.ID))
                                                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NATIONAL_HUTPUT WHERE NATIONAL_DATA_ID = {0}", NationalData.ID))

                                            Else

                                                IsNewFile = True

                                            End If

                                        End If

                                        If IsNewFile Then

                                            If (From Entity In AdvantageFramework.National.Database.Procedures.NationalData.Load(DbContext)
                                                Where Entity.FileName.ToUpper = File.ToUpper
                                                Select Entity).Any Then

                                                Throw New Exception("Cannot import data to National Data - unique key violation.")

                                            End If

                                            NationalData = New AdvantageFramework.National.Database.Entities.NationalData
                                            NationalData.DbContext = DbContext

                                            NationalData.FileName = File
                                            NationalData.DataType = FilePrefix
                                            NationalData.Stream = Stream
                                            NationalData.IsHispanic = IsHispanic
                                            NationalData.IsPreliminary = IsPreliminary
                                            NationalData.StartDate = StartDate
                                            NationalData.EndDate = EndDate
                                            NationalData.IsPBSNSS = IsPBSNSS

                                            NationalYear = (From Entity In DbContext.GetQuery(Of AdvantageFramework.National.Database.Entities.NationalYear)
                                                            Where Entity.StartDate <= NationalData.StartDate AndAlso
                                                                  Entity.EndDate >= NationalData.EndDate
                                                            Select Entity).SingleOrDefault

                                            If NationalYear Is Nothing Then

                                                Throw New Exception("Cannot find record in National Year table for: " & Mid(TextLine, 78, 3))

                                            End If

                                            NationalData.Year = NationalYear.Year
                                            NationalData.MarketBreakID = MarketBreak.ID
                                            NationalData.IsCorrection = False

                                            DbContext.NationalDatas.Add(NationalData)
                                            DbContext.SaveChanges()

                                        Else

                                            NationalData.FileName = File
                                            NationalData.IsPreliminary = False

                                            DbContext.Entry(NationalData).State = Entity.EntityState.Modified
                                            DbContext.SaveChanges()

                                        End If

                                    Case "01"

                                        If File.ToUpper.StartsWith("NTI_AGFUL") OrElse File.ToUpper.StartsWith("NTIH_AGFUL") Then

                                            TextLine2 = StreamReader.ReadLine()
                                            TextLine3 = StreamReader.ReadLine()

                                            AddNielsenNationalTVUniverse(DbContext, NationalData.IsHispanic, MarketBreak.ID, TextLine, TextLine2, TextLine3, NationalUniverses)

                                        End If

                                    Case "03"

                                        If File.ToUpper.StartsWith("NTI_AGFUL") OrElse File.ToUpper.StartsWith("NTIH_AGFUL") Then

                                            If Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 83, 2) = "  " AndAlso Mid(TextLine, 85, 1) = "H" AndAlso ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 92, 3) = "000" Then

                                                TextLine2 = Nothing
                                                TextLine3 = Nothing

                                                Do

                                                    TextTemp = StreamReader.ReadLine()

                                                    RecordSeqCode = Mid(TextTemp, 1, 2)

                                                    If RecordSeqCode = "03" AndAlso Mid(TextTemp, 42, 2) = "00" AndAlso IsNumeric(Mid(TextTemp, 83, 2)) AndAlso CInt(Mid(TextTemp, 83, 2)) > 0 AndAlso CInt(Mid(TextTemp, 83, 2)) < 97 AndAlso Mid(TextTemp, 85, 1) = "P" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 3) = "001" Then

                                                        TextLine2 = TextTemp

                                                    End If

                                                    If RecordSeqCode = "03" AndAlso Mid(TextTemp, 42, 2) = "00" AndAlso IsNumeric(Mid(TextTemp, 83, 2)) AndAlso CInt(Mid(TextTemp, 83, 2)) > 0 AndAlso CInt(Mid(TextTemp, 83, 2)) < 97 AndAlso Mid(TextTemp, 85, 1) = "P" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 3) = "021" Then

                                                        TextLine3 = TextTemp

                                                    End If

                                                Loop Until (TextLine2 IsNot Nothing AndAlso TextLine3 IsNot Nothing) OrElse StreamReader.Peek() = -1 OrElse RecordSeqCode <> "03"

                                                If TextLine IsNot Nothing AndAlso TextLine2 IsNot Nothing AndAlso TextLine3 IsNot Nothing Then

                                                    AddNielsenNationalTVHutput(DbContext, NationalData.ID, TextLine, TextLine2, TextLine3, NationalHutputs)

                                                Else

                                                    'skipping for now
                                                    Throw New Exception("Could not find complete sequence of record type 03.")

                                                End If

                                            End If

                                        End If

                                    Case "04"

                                        If File.ToUpper.StartsWith("NHI_AGENCY") OrElse File.ToUpper.StartsWith("NHIH_AGENCY") OrElse
                                                File.ToUpper.StartsWith("NSS_AGSTD") OrElse File.ToUpper.StartsWith("NSSH_AGSTD") OrElse
                                                File.ToUpper.StartsWith("NTI_AGFUL") OrElse File.ToUpper.StartsWith("NTIH_AGFUL") Then

                                            If Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "D" AndAlso ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 11, 1) <> "2" Then

                                                PFound = False

                                                If NationalAudience IsNot Nothing Then

                                                    NationalAudiences.Add(NationalAudience)

                                                    NationalAudience = Nothing

                                                End If

                                                NationalAudience = CreateNielsenNationalTVAudience(NationalData.ID, TextLine, FilePrefix, DbContext, NationalNetworks)
                                                NationalAudience.TimeType = "P"

                                                Do

                                                    TextTemp = StreamReader.ReadLine()

                                                    RecordSeqCode = Mid(TextTemp, 1, 2)

                                                    If Mid(TextTemp, 83, 3) = "  P" Then

                                                        PFound = True

                                                    End If

                                                    If RecordSeqCode = "04" AndAlso Mid(TextTemp, 42, 2) = "00" AndAlso Mid(TextTemp, 83, 3) = "  P" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 4) = "0010" AndAlso
                                                        Has010 = False Then

                                                        UpdateNielsenNationalAudienceFrom010(NationalAudience, TextTemp)
                                                        Has010 = True

                                                    End If

                                                    If RecordSeqCode = "04" AndAlso Mid(TextTemp, 42, 2) = "00" AndAlso Mid(TextTemp, 83, 3) = "  P" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 4) = "0011" AndAlso
                                                        Has011 = False Then

                                                        UpdateNielsenNationalAudienceFrom011(NationalAudience, TextTemp)
                                                        Has011 = True

                                                    End If

                                                    If RecordSeqCode = "04" AndAlso Mid(TextTemp, 42, 2) = "00" AndAlso Mid(TextTemp, 83, 3) = "  P" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 4) = "0210" AndAlso
                                                        Has210 = False Then

                                                        UpdateNielsenNationalAudienceFrom210(NationalAudience, TextTemp)
                                                        Has210 = True

                                                    End If

                                                    If RecordSeqCode = "04" AndAlso Mid(TextTemp, 42, 2) = "00" AndAlso Mid(TextTemp, 83, 3) = "  P" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 4) = "0211" AndAlso
                                                        Has211 = False Then

                                                        UpdateNielsenNationalAudienceFrom211(NationalAudience, TextTemp)
                                                        Has211 = True

                                                    End If

                                                Loop Until StreamReader.Peek() = -1 OrElse RecordSeqCode <> "04" OrElse (Mid(TextTemp, 85, 1) = "D" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso PFound = True)

                                                SkipRead = True
                                                TextLine = TextTemp
                                                Has010 = False
                                                Has011 = False
                                                Has210 = False
                                                Has211 = False
                                                PFound = False

                                            End If

                                        End If

                                    Case "06"

                                        If File.ToUpper.StartsWith("NHI_CPAGENCY") OrElse File.ToUpper.StartsWith("NHIH_CPAGENCY") OrElse
                                                File.ToUpper.StartsWith("NSS_CPAGSTD") OrElse File.ToUpper.StartsWith("NSSH_CPAGSTD") OrElse
                                                File.ToUpper.StartsWith("NTI_CPAGFUL") OrElse File.ToUpper.StartsWith("NTIH_CPAGFUL") Then

                                            If Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "C" AndAlso ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 11, 1) <> "2" Then

                                                'PFound = False

                                                If NationalAudience IsNot Nothing Then

                                                    NationalAudiences.Add(NationalAudience)

                                                    NationalAudience = Nothing

                                                End If

                                                NationalAudience = CreateNielsenNationalTVAudience(NationalData.ID, TextLine, FilePrefix, DbContext, NationalNetworks)
                                                NationalAudience.TimeType = "C"

                                                Do

                                                    TextTemp = StreamReader.ReadLine()

                                                    RecordSeqCode = Mid(TextTemp, 1, 2)

                                                    'If Mid(TextTemp, 85, 1) = "P" Then

                                                    '    PFound = True

                                                    'End If

                                                    If RecordSeqCode = "06" AndAlso Mid(TextTemp, 42, 2) = "00" AndAlso Mid(TextTemp, 85, 1) = "P" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 4) = "0010" AndAlso
                                                        Has010 = False Then

                                                        UpdateNielsenNationalAudienceFrom010(NationalAudience, TextTemp)
                                                        Has010 = True

                                                    End If

                                                    If RecordSeqCode = "06" AndAlso Mid(TextTemp, 42, 2) = "00" AndAlso Mid(TextTemp, 85, 1) = "P" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 4) = "0011" AndAlso
                                                        Has011 = False Then

                                                        UpdateNielsenNationalAudienceFrom011(NationalAudience, TextTemp)
                                                        Has011 = True

                                                    End If

                                                    If RecordSeqCode = "06" AndAlso Mid(TextTemp, 42, 2) = "00" AndAlso Mid(TextTemp, 85, 1) = "P" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 4) = "0210" AndAlso
                                                        Has210 = False Then

                                                        UpdateNielsenNationalAudienceFrom210(NationalAudience, TextTemp)
                                                        Has210 = True

                                                    End If

                                                    If RecordSeqCode = "06" AndAlso Mid(TextTemp, 42, 2) = "00" AndAlso Mid(TextTemp, 85, 1) = "P" AndAlso ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 4) = "0211" AndAlso
                                                        Has211 = False Then

                                                        UpdateNielsenNationalAudienceFrom211(NationalAudience, TextTemp)
                                                        Has211 = True

                                                    End If

                                                Loop Until StreamReader.Peek() = -1 OrElse RecordSeqCode <> "06" OrElse Mid(TextTemp, 85, 1) = "C" 'AndAlso PFound = True

                                                SkipRead = True
                                                TextLine = TextTemp
                                                Has010 = False
                                                Has011 = False
                                                Has210 = False
                                                Has211 = False
                                                'PFound = False

                                            End If

                                        End If

                                End Select

                            Loop

                            BulkInsertNationalUniverseList(DbContext, tran, NationalUniverses)

                            NationalHutputCorrections = (From Entity In NationalHutputs
                                                         Where Entity.NationalDataID = NationalData.ID AndAlso
                                                               Entity.HutputDatetime < NationalData.StartDate
                                                         Select New AdvantageFramework.National.Database.Entities.NationalHutputCorrection With {
                                                                .MarketBreakID = NationalData.MarketBreakID,
                                                                .DataType = NationalData.DataType,
                                                                .Stream = NationalData.Stream,
                                                                .HutputDatetime = Entity.HutputDatetime,
                                                                .FeedPattern = Entity.FeedPattern,
                                                                .StartDate = NationalData.StartDate,
                                                                .Household = Entity.Household,
                                                                .Females2to5 = Entity.Females2to5,
                                                                .Females6to8 = Entity.Females6to8,
                                                                .Females9to11 = Entity.Females9to11,
                                                                .Females12to14 = Entity.Females12to14,
                                                                .Females15to17 = Entity.Females15to17,
                                                                .Females18to20 = Entity.Females18to20,
                                                                .Females21to24 = Entity.Females21to24,
                                                                .Females25to29 = Entity.Females25to29,
                                                                .Females30to34 = Entity.Females30to34,
                                                                .Females35to39 = Entity.Females35to39,
                                                                .Females40to44 = Entity.Females40to44,
                                                                .Females45to49 = Entity.Females45to49,
                                                                .Females50to54 = Entity.Females50to54,
                                                                .Females55to64 = Entity.Females55to64,
                                                                .Females65Plus = Entity.Females65Plus,
                                                                .Males2to5 = Entity.Males2to5,
                                                                .Males6to8 = Entity.Males6to8,
                                                                .Males9to11 = Entity.Males9to11,
                                                                .Males12to14 = Entity.Males12to14,
                                                                .Males15to17 = Entity.Males15to17,
                                                                .Males18to20 = Entity.Males18to20,
                                                                .Males21to24 = Entity.Males21to24,
                                                                .Males25to29 = Entity.Males25to29,
                                                                .Males30to34 = Entity.Males30to34,
                                                                .Males35to39 = Entity.Males35to39,
                                                                .Males40to44 = Entity.Males40to44,
                                                                .Males45to49 = Entity.Males45to49,
                                                                .Males50to54 = Entity.Males50to54,
                                                                .Males55to64 = Entity.Males55to64,
                                                                .Males65Plus = Entity.Males65Plus,
                                                                .WorkingWomen18to20 = Entity.WorkingWomen18to20,
                                                                .WorkingWomen21to24 = Entity.WorkingWomen21to24,
                                                                .WorkingWomen25to34 = Entity.WorkingWomen25to34,
                                                                .WorkingWomen35to44 = Entity.WorkingWomen35to44,
                                                                .WorkingWomen45to49 = Entity.WorkingWomen45to49,
                                                                .WorkingWomen50to54 = Entity.WorkingWomen50to54,
                                                                .WorkingWomen55Plus = Entity.WorkingWomen55Plus}).ToList


                            NationalHutputs = NationalHutputs.Where(Function(Entity) Entity.HutputDatetime >= NationalData.StartDate).ToList

                            BulkInsertNationalHutputList(DbContext, tran, NationalHutputs)
                            BulkInsertNationalHUTPUTCorrectionList(DbContext, tran, NationalHutputCorrections)

                            DbContext.Database.ExecuteSqlCommand("exec dbo.advsp_update_national_hutput_with_corrections")

                            NationalAudiences = NationalAudiences.Where(Function(Entity) Entity.TotalProgramIndicator <> "PP").ToList

                            NationalAudienceCorrections = (From Entity In NationalAudiences
                                                           Where Entity.NationalDataID = NationalData.ID AndAlso
                                                                 Entity.AudienceDateTime < NationalData.StartDate
                                                           Select New AdvantageFramework.National.Database.Entities.NationalAudienceCorrection With {
                                                                .MarketBreakID = NationalData.MarketBreakID,
                                                                .DataType = NationalData.DataType,
                                                                .Stream = NationalData.Stream,
                                                                .TimeType = Entity.TimeType,
                                                                .Network = Entity.Network,
                                                                .VenueCode = Entity.VenueCode,
                                                                .AudienceDateTime = Entity.AudienceDateTime,
                                                                .ProgramCode = Entity.ProgramCode,
                                                                .TrackageCode = Entity.TrackageCode,
                                                                .StartDate = NationalData.StartDate,
                                                                .CommercialProgramDuration = Entity.CommercialProgramDuration,
                                                                .EventDuration = Entity.EventDuration,
                                                                .ProgramTotalDuration = Entity.ProgramTotalDuration,
                                                                .ProgramName = Entity.ProgramName,
                                                                .TrackageName = Entity.TrackageName,
                                                                .EpisodeName = Entity.EpisodeName,
                                                                .NielsenDaypart = Entity.NielsenDaypart,
                                                                .ProgramType = Entity.ProgramType,
                                                                .IsCorrection = Entity.IsCorrection,
                                                                .IsBreakout = Entity.IsBreakout,
                                                                .IsSpecial = Entity.IsSpecial,
                                                                .IsRepeat = Entity.IsRepeat,
                                                                .IsPremiere = Entity.IsPremiere,
                                                                .IsDNA = Entity.IsDNA,
                                                                .IsMulticast = Entity.IsMulticast,
                                                                .IsComplex = Entity.IsComplex,
                                                                .IsShortDuration = Entity.IsShortDuration,
                                                                .IsVariousMetadata = Entity.IsVariousMetadata,
                                                                .IsVariousTimes = Entity.IsVariousTimes,
                                                                .IsGapped = Entity.IsGapped,
                                                                .IsWeeklyAverage = Entity.IsWeeklyAverage,
                                                                .SyndicatorInfo = Entity.SyndicatorInfo,
                                                                .TelecastNumber = Entity.TelecastNumber,
                                                                .CoverageSampleIdentification = Entity.CoverageSampleIdentification,
                                                                .TotalProgramIndicator = Entity.TotalProgramIndicator,
                                                                .DaysOfWeekIndicator = Entity.DaysOfWeekIndicator,
                                                                .StationCount = Entity.StationCount,
                                                                .HeadendCount = Entity.HeadendCount,
                                                                .CoveragePercent = Entity.CoveragePercent,
                                                                .ProgramHUT = Entity.ProgramHUT,
                                                                .HouseholdAudience = Entity.HouseholdAudience,
                                                                .Females2to5Audience = Entity.Females2to5Audience,
                                                                .Females6to8Audience = Entity.Females6to8Audience,
                                                                .Females9to11Audience = Entity.Females9to11Audience,
                                                                .Females12to14Audience = Entity.Females12to14Audience,
                                                                .Females15to17Audience = Entity.Females15to17Audience,
                                                                .Females18to20Audience = Entity.Females18to20Audience,
                                                                .Females21to24Audience = Entity.Females21to24Audience,
                                                                .Females25to29Audience = Entity.Females25to29Audience,
                                                                .Females30to34Audience = Entity.Females30to34Audience,
                                                                .Females35to39Audience = Entity.Females35to39Audience,
                                                                .Females40to44Audience = Entity.Females40to44Audience,
                                                                .Females45to49Audience = Entity.Females45to49Audience,
                                                                .Females50to54Audience = Entity.Females50to54Audience,
                                                                .Females55to64Audience = Entity.Females55to64Audience,
                                                                .Females65PlusAudience = Entity.Females65PlusAudience,
                                                                .Males2to5Audience = Entity.Males2to5Audience,
                                                                .Males6to8Audience = Entity.Males6to8Audience,
                                                                .Males9to11Audience = Entity.Males9to11Audience,
                                                                .Males12to14Audience = Entity.Males12to14Audience,
                                                                .Males15to17Audience = Entity.Males15to17Audience,
                                                                .Males18to20Audience = Entity.Males18to20Audience,
                                                                .Males21to24Audience = Entity.Males21to24Audience,
                                                                .Males25to29Audience = Entity.Males25to29Audience,
                                                                .Males30to34Audience = Entity.Males30to34Audience,
                                                                .Males35to39Audience = Entity.Males35to39Audience,
                                                                .Males40to44Audience = Entity.Males40to44Audience,
                                                                .Males45to49Audience = Entity.Males45to49Audience,
                                                                .Males50to54Audience = Entity.Males50to54Audience,
                                                                .Males55to64Audience = Entity.Males55to64Audience,
                                                                .Males65PlusAudience = Entity.Males65PlusAudience,
                                                                .WorkingWomen18to20Audience = Entity.WorkingWomen18to20Audience,
                                                                .WorkingWomen21to24Audience = Entity.WorkingWomen21to24Audience,
                                                                .WorkingWomen25to34Audience = Entity.WorkingWomen25to34Audience,
                                                                .WorkingWomen35to44Audience = Entity.WorkingWomen35to44Audience,
                                                                .WorkingWomen45to49Audience = Entity.WorkingWomen45to49Audience,
                                                                .WorkingWomen50to54Audience = Entity.WorkingWomen50to54Audience,
                                                                .WorkingWomen55PlusAudience = Entity.WorkingWomen55PlusAudience,
                                                                .Females2to5PUT = Entity.Females2to5PUT,
                                                                .Females6to8PUT = Entity.Females6to8PUT,
                                                                .Females9to11PUT = Entity.Females9to11PUT,
                                                                .Females12to14PUT = Entity.Females12to14PUT,
                                                                .Females15to17PUT = Entity.Females15to17PUT,
                                                                .Females18to20PUT = Entity.Females18to20PUT,
                                                                .Females21to24PUT = Entity.Females21to24PUT,
                                                                .Females25to29PUT = Entity.Females25to29PUT,
                                                                .Females30to34PUT = Entity.Females30to34PUT,
                                                                .Females35to39PUT = Entity.Females35to39PUT,
                                                                .Females40to44PUT = Entity.Females40to44PUT,
                                                                .Females45to49PUT = Entity.Females45to49PUT,
                                                                .Females50to54PUT = Entity.Females50to54PUT,
                                                                .Females55to64PUT = Entity.Females55to64PUT,
                                                                .Females65PlusPUT = Entity.Females65PlusPUT,
                                                                .Males2to5PUT = Entity.Males2to5PUT,
                                                                .Males6to8PUT = Entity.Males6to8PUT,
                                                                .Males9to11PUT = Entity.Males9to11PUT,
                                                                .Males12to14PUT = Entity.Males12to14PUT,
                                                                .Males15to17PUT = Entity.Males15to17PUT,
                                                                .Males18to20PUT = Entity.Males18to20PUT,
                                                                .Males21to24PUT = Entity.Males21to24PUT,
                                                                .Males25to29PUT = Entity.Males25to29PUT,
                                                                .Males30to34PUT = Entity.Males30to34PUT,
                                                                .Males35to39PUT = Entity.Males35to39PUT,
                                                                .Males40to44PUT = Entity.Males40to44PUT,
                                                                .Males45to49PUT = Entity.Males45to49PUT,
                                                                .Males50to54PUT = Entity.Males50to54PUT,
                                                                .Males55to64PUT = Entity.Males55to64PUT,
                                                                .Males65PlusPUT = Entity.Males65PlusPUT,
                                                                .WorkingWomen18to20PUT = Entity.WorkingWomen18to20PUT,
                                                                .WorkingWomen21to24PUT = Entity.WorkingWomen21to24PUT,
                                                                .WorkingWomen25to34PUT = Entity.WorkingWomen25to34PUT,
                                                                .WorkingWomen35to44PUT = Entity.WorkingWomen35to44PUT,
                                                                .WorkingWomen45to49PUT = Entity.WorkingWomen45to49PUT,
                                                                .WorkingWomen50to54PUT = Entity.WorkingWomen50to54PUT,
                                                                .WorkingWomen55PlusPUT = Entity.WorkingWomen55PlusAudience}).ToList

                            NationalAudiences = NationalAudiences.Where(Function(Entity) Entity.AudienceDateTime >= NationalData.StartDate).ToList

                            BulkInsertNationalAudienceList(DbContext, tran, NationalAudiences)
                            BulkInsertNationalAudienceCorrectionList(DbContext, tran, NationalAudienceCorrections)

                            DbContext.Database.ExecuteSqlCommand("exec dbo.advsp_update_national_audience_with_corrections")

                            tran.Commit()

                            Processed = True

                        Catch ex As Exception

                            If ex.Message = "SKIPFILE" Then

                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.DOWNLOAD_FILE SET PROCESSED_TIME = getdate(), SKIPPED = 1 WHERE DOWNLOAD_FILE_ID = {0}", DownloadFileID))

                                tran.Commit()

                            Else

                                tran.Rollback()

                                LogEvent(ConnectionString, "Downloadfile ID:" & DownloadFileID.ToString & ": " & ex.Message)

                            End If

                        Finally

                            If StreamReader IsNot Nothing Then

                                StreamReader.Close()

                            End If

                        End Try

                    End Using

                End Using

            End If

            ProcessNationalFile = Processed

        End Function
        Private Sub UnzipNationalTVFiles(National_Path As String)

            'objects
            Dim FileInfo As System.IO.FileInfo = Nothing

            For Each Filename In System.IO.Directory.GetFiles(National_Path)

                If Filename.ToLower.EndsWith(".gz") Then

                    Try

                        FileInfo = New IO.FileInfo(Filename)

                        Decompress(FileInfo)

                        System.IO.File.Delete(System.IO.Path.Combine(National_Path, Filename))

                    Catch ex As Exception
                        Throw ex
                    End Try

                End If

            Next

        End Sub
        Private Sub Decompress(ByVal FileToDecompress As System.IO.FileInfo)

            Dim CurrentFileName As String = Nothing
            Dim NewFileName As String = Nothing

            Using originalFileStream As System.IO.FileStream = FileToDecompress.OpenRead()

                CurrentFileName = FileToDecompress.FullName
                NewFileName = CurrentFileName.Remove(CurrentFileName.Length - FileToDecompress.Extension.Length)

                Using DecompressedFileStream As System.IO.FileStream = System.IO.File.Create(NewFileName)

                    Using DecompressionStream As System.IO.Compression.GZipStream = New System.IO.Compression.GZipStream(originalFileStream, System.IO.Compression.CompressionMode.Decompress)

                        DecompressionStream.CopyTo(DecompressedFileStream)

                    End Using

                End Using

            End Using

        End Sub

#End Region

#End Region

    End Module

End Namespace
