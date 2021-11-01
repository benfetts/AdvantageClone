Namespace Controller

    Public Class ServiceEventController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ConnectionString As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "


#Region " Public "

        Public Sub New(ConnectionString As String)

            _ConnectionString = ConnectionString

        End Sub
        Public Function LoadEventLogs() As NielsenFramework.ViewModels.ServiceEventViewModel

            'objects
            Dim ServiceEventViewModel As NielsenFramework.ViewModels.ServiceEventViewModel = Nothing

            ServiceEventViewModel = New NielsenFramework.ViewModels.ServiceEventViewModel

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                ServiceEventViewModel.EventLogs = New Generic.List(Of NielsenFramework.DTO.EventLog)

                ServiceEventViewModel.EventLogs.AddRange(From Entity In NielsenFramework.Database.Procedures.EventLog.Load(NielsenDbContext).OrderByDescending(Function(Entity) Entity.EventDateTime).ToList
                                                         Select New NielsenFramework.DTO.EventLog(Entity))

            End Using

            LoadEventLogs = ServiceEventViewModel

        End Function
        Public Function LoadDownloadFiles() As NielsenFramework.ViewModels.ServiceEventViewModel

            'objects
            Dim ServiceEventViewModel As NielsenFramework.ViewModels.ServiceEventViewModel = Nothing

            ServiceEventViewModel = New NielsenFramework.ViewModels.ServiceEventViewModel

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                ServiceEventViewModel.DownloadFiles = New Generic.List(Of NielsenFramework.DTO.DownloadFile)

                ServiceEventViewModel.DownloadFiles.AddRange(From Entity In NielsenFramework.Database.Procedures.DownloadFile.Load(NielsenDbContext).OrderByDescending(Function(Entity) Entity.ID).ToList
                                                             Select New NielsenFramework.DTO.DownloadFile(Entity))

            End Using

            LoadDownloadFiles = ServiceEventViewModel

        End Function
        Public Function LoadNielsenTVBooks() As NielsenFramework.ViewModels.ServiceEventViewModel

            'objects
            Dim ServiceEventViewModel As NielsenFramework.ViewModels.ServiceEventViewModel = Nothing
            Dim NielsenMarketList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenMarket) = Nothing

            ServiceEventViewModel = New NielsenFramework.ViewModels.ServiceEventViewModel

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_ConnectionString, "")

                NielsenMarketList = AdvantageFramework.Nielsen.Database.Procedures.NielsenMarket.LoadTVMarkets(NielsenDbContext).ToList

                ServiceEventViewModel.NielsenTVBooks = New Generic.List(Of NielsenFramework.DTO.NielsenTVBook)

                ServiceEventViewModel.NielsenTVBooks.AddRange(From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.Load(NielsenDbContext).OrderByDescending(Function(Entity) Entity.ID).ToList
                                                              Select New NielsenFramework.DTO.NielsenTVBook(Entity, NielsenMarketList))

            End Using

            LoadNielsenTVBooks = ServiceEventViewModel

        End Function
        Public Function LoadNielsenTVCUMEBooks() As NielsenFramework.ViewModels.ServiceEventViewModel

            'objects
            Dim ServiceEventViewModel As NielsenFramework.ViewModels.ServiceEventViewModel = Nothing
            Dim NielsenMarketList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenMarket) = Nothing

            ServiceEventViewModel = New NielsenFramework.ViewModels.ServiceEventViewModel

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_ConnectionString, "")

                NielsenMarketList = AdvantageFramework.Nielsen.Database.Procedures.NielsenMarket.LoadTVMarkets(NielsenDbContext).ToList

                ServiceEventViewModel.NielsenTVCUMEBooks = New Generic.List(Of NielsenFramework.DTO.NielsenTVBook)

                ServiceEventViewModel.NielsenTVCUMEBooks.AddRange(From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVCumeBook.Load(NielsenDbContext).OrderByDescending(Function(Entity) Entity.ID).ToList
                                                                  Select New NielsenFramework.DTO.NielsenTVBook(Entity, NielsenMarketList))

            End Using

            LoadNielsenTVCUMEBooks = ServiceEventViewModel

        End Function
        'Public Function LoadTVDirectoryFiles() As NielsenFramework.ViewModels.ServiceEventViewModel

        '    'objects
        '    Dim ServiceEventViewModel As NielsenFramework.ViewModels.ServiceEventViewModel = Nothing
        '    Dim ServiceSetting As NielsenFramework.Database.Entities.ServiceSetting = Nothing

        '    ServiceEventViewModel = New NielsenFramework.ViewModels.ServiceEventViewModel

        '    ServiceEventViewModel.TVDirectoryFiles = New Generic.List(Of DTO.File)

        '    Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

        '        ServiceSetting = NielsenFramework.Database.Procedures.ServiceSetting.LoadSingleRecord(NielsenDbContext)

        '        If ServiceSetting IsNot Nothing Then

        '            For Each Filename In System.IO.Directory.GetFiles(ServiceSetting.TVSpotPath, "NSI*.txt")

        '                ServiceEventViewModel.TVDirectoryFiles.Add(New DTO.File(System.IO.Path.GetFileName(Filename), System.IO.File.GetLastWriteTime(Filename)))

        '            Next

        '        End If

        '    End Using

        '    LoadTVDirectoryFiles = ServiceEventViewModel

        'End Function
        Public Function LoadNielsenRadioPeriods() As NielsenFramework.ViewModels.ServiceEventViewModel

            'objects
            Dim ServiceEventViewModel As NielsenFramework.ViewModels.ServiceEventViewModel = Nothing
            Dim NielsenRadioMarketList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket) = Nothing

            ServiceEventViewModel = New NielsenFramework.ViewModels.ServiceEventViewModel

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_ConnectionString, "")

                NielsenRadioMarketList = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioMarket.Load(NielsenDbContext).ToList

                ServiceEventViewModel.NielsenRadioPeriods = New Generic.List(Of NielsenFramework.DTO.NielsenRadioPeriod)

                ServiceEventViewModel.NielsenRadioPeriods.AddRange(From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.Load(NielsenDbContext).OrderByDescending(Function(Entity) Entity.ID).ToList
                                                                   Select New NielsenFramework.DTO.NielsenRadioPeriod(Entity, NielsenRadioMarketList))

            End Using

            LoadNielsenRadioPeriods = ServiceEventViewModel

        End Function
        Public Function LoadNielsenServiceStatus() As NielsenFramework.ViewModels.ServiceEventViewModel

            'objects
            Dim ServiceEventViewModel As NielsenFramework.ViewModels.ServiceEventViewModel = Nothing
            Dim ServiceStatus As NielsenFramework.Database.Entities.ServiceStatus = Nothing

            ServiceEventViewModel = New NielsenFramework.ViewModels.ServiceEventViewModel

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                ServiceStatus = NielsenFramework.Database.Procedures.ServiceStatus.LoadSingleRecord(NielsenDbContext)

                ServiceEventViewModel.ServiceStatus = New Generic.List(Of NielsenFramework.DTO.ServiceStatus)

                If ServiceStatus IsNot Nothing Then

                    ServiceEventViewModel.ServiceStatus.Add(New DTO.ServiceStatus(ServiceStatus))

                End If

            End Using

            LoadNielsenServiceStatus = ServiceEventViewModel

        End Function
        Public Function ReIssueTVFile(DownloadFileID As Integer, ByRef ErrorText As String) As Boolean

            'objects
            Dim DownloadFile As NielsenFramework.Database.Entities.DownloadFile = Nothing
            Dim ReIssued As Boolean = False
            Dim FilenameFields() As String = Nothing
            Dim MarketNumber As Integer = 0
            Dim Year As Short = 0
            Dim Month As Short = 0

            Using NielsenDbContext = New NielsenFramework.Database.NielsenDbContext(_ConnectionString)

                DownloadFile = NielsenFramework.Database.Procedures.DownloadFile.LoadByID(NielsenDbContext, DownloadFileID)

                If DownloadFile IsNot Nothing Then

                    Using tran = NielsenDbContext.Database.BeginTransaction()

                        Try

                            If DownloadFile.FileName.Contains("PGNAM") Then

                                FilenameFields = Mid(DownloadFile.FileName.ToUpper, 1, InStr(DownloadFile.FileName, ".") - 1).Split("_")

                                MarketNumber = FilenameFields(1)
                                Year = FilenameFields(3)
                                Month = FilenameFields(4)

                                NielsenDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.NIELSEN_TV_PROGRAM WHERE NIELSEN_MARKET_NUM = {0} AND [YEAR] = {1} AND [MONTH] = {2}", MarketNumber, Year, Month))

                            End If

                            If NielsenFramework.Database.Procedures.DownloadFile.Delete(NielsenDbContext, DownloadFileID, ErrorText) Then

                                tran.Commit()

                                ReIssued = True

                            End If

                        Catch ex As Exception
                            tran.Rollback()
                        End Try

                    End Using

                End If

            End Using

            ReIssueTVFile = ReIssued

        End Function

#End Region

#End Region

    End Class

End Namespace
