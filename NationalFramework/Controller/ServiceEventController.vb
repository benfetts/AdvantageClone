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
        Public Function LoadEventLogs() As NationalFramework.ViewModels.ServiceEventViewModel

            'objects
            Dim ServiceEventViewModel As NationalFramework.ViewModels.ServiceEventViewModel = Nothing

            ServiceEventViewModel = New NationalFramework.ViewModels.ServiceEventViewModel

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                ServiceEventViewModel.EventLogs = New Generic.List(Of NationalFramework.DTO.EventLog)

                ServiceEventViewModel.EventLogs.AddRange(From Entity In NationalFramework.Database.Procedures.EventLog.Load(DbContext).OrderByDescending(Function(Entity) Entity.EventDateTime).ToList
                                                         Select New NationalFramework.DTO.EventLog(Entity))

            End Using

            LoadEventLogs = ServiceEventViewModel

        End Function
        Public Function LoadDownloadFiles() As NationalFramework.ViewModels.ServiceEventViewModel

            'objects
            Dim ServiceEventViewModel As NationalFramework.ViewModels.ServiceEventViewModel = Nothing

            ServiceEventViewModel = New NationalFramework.ViewModels.ServiceEventViewModel

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                ServiceEventViewModel.DownloadFiles = New Generic.List(Of NationalFramework.DTO.DownloadFile)

                ServiceEventViewModel.DownloadFiles.AddRange(From Entity In NationalFramework.Database.Procedures.DownloadFile.Load(DbContext).OrderByDescending(Function(Entity) Entity.ID).ToList
                                                             Select New NationalFramework.DTO.DownloadFile(Entity))

            End Using

            LoadDownloadFiles = ServiceEventViewModel

        End Function
        Public Function LoadNationalDatas() As NationalFramework.ViewModels.ServiceEventViewModel

            'objects
            Dim ServiceEventViewModel As NationalFramework.ViewModels.ServiceEventViewModel = Nothing

            ServiceEventViewModel = New NationalFramework.ViewModels.ServiceEventViewModel

            Using DbContext = New AdvantageFramework.National.Database.DbContext(_ConnectionString, "")

                ServiceEventViewModel.NationalDatas = New Generic.List(Of NationalFramework.DTO.NationalData)

                ServiceEventViewModel.NationalDatas.AddRange(From Entity In AdvantageFramework.National.Database.Procedures.NationalData.Load(DbContext).OrderByDescending(Function(Entity) Entity.ID).ToList
                                                             Select New NationalFramework.DTO.NationalData(Entity))

            End Using

            LoadNationalDatas = ServiceEventViewModel

        End Function
        Public Function LoadNielsenServiceStatus() As NationalFramework.ViewModels.ServiceEventViewModel

            'objects
            Dim ServiceEventViewModel As NationalFramework.ViewModels.ServiceEventViewModel = Nothing
            Dim ServiceStatus As NationalFramework.Database.Entities.ServiceStatus = Nothing

            ServiceEventViewModel = New NationalFramework.ViewModels.ServiceEventViewModel

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                ServiceStatus = NationalFramework.Database.Procedures.ServiceStatus.LoadSingleRecord(DbContext)

                ServiceEventViewModel.ServiceStatus = New Generic.List(Of NationalFramework.DTO.ServiceStatus)

                If ServiceStatus IsNot Nothing Then

                    ServiceEventViewModel.ServiceStatus.Add(New DTO.ServiceStatus(ServiceStatus))

                End If

            End Using

            LoadNielsenServiceStatus = ServiceEventViewModel

        End Function

#End Region

#End Region

    End Class

End Namespace
