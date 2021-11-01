Namespace Controller.Maintenance.Media

    Public Class TimeSeparationSettingSetupController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
        End Property

#End Region

#Region " Methods "


#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            _Session = Session

        End Sub
        Public Function Load(ByVal InvoiceMatchingSettingID As Integer, Source As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource) As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel

            Dim TimeSeparationSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel = Nothing
            Dim MediaBroadcastWorksheetSpotMatchingSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting = Nothing
            Dim MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet = Nothing
            Dim InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting = Nothing

            TimeSeparationSettingViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel
            TimeSeparationSettingViewModel.Source = Source

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If TimeSeparationSettingViewModel.Source = ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource.Default Then

                    TimeSeparationSettingViewModel.SpotMatchingSetting = New AdvantageFramework.DTO.Media.SpotMatchingSetting(AdvantageFramework.Database.Procedures.InvoiceMatchingSetting.LoadByID(DbContext, InvoiceMatchingSettingID))
                    TimeSeparationSettingViewModel.MediaTypeCode = TimeSeparationSettingViewModel.SpotMatchingSetting.MediaTypeCode

                    If String.IsNullOrWhiteSpace(TimeSeparationSettingViewModel.SpotMatchingSetting.ClientCode) = False Then

                        TimeSeparationSettingViewModel.Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, TimeSeparationSettingViewModel.SpotMatchingSetting.ClientCode)

                    End If

                    TimeSeparationSettingViewModel.TimeSeparationSettings = (From Entity In AdvantageFramework.Database.Procedures.TimeSeparationSetting.LoadByInvoiceMatchingSettingID(DbContext, InvoiceMatchingSettingID).ToList
                                                                             Select New AdvantageFramework.DTO.Media.TimeSeparationSetting(Entity)).ToList

                    If TimeSeparationSettingViewModel.TimeSeparationSettings.Count = 1 AndAlso TimeSeparationSettingViewModel.TimeSeparationSettings.First.CrossLengthSeparationEnabled Then

                        TimeSeparationSettingViewModel.CrossLengthSeparationEnabled = TimeSeparationSettingViewModel.TimeSeparationSettings.First.CrossLengthSeparationEnabled
                        TimeSeparationSettingViewModel.CrossLengthSeparationValue = TimeSeparationSettingViewModel.TimeSeparationSettings.First.CrossLengthSeparationValue

                        TimeSeparationSettingViewModel.TimeSeparationSettings = New Generic.List(Of AdvantageFramework.DTO.Media.TimeSeparationSetting)

                    End If

                ElseIf TimeSeparationSettingViewModel.Source = ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource.Worksheet Then

                    MediaBroadcastWorksheet = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheet.LoadByMediaBroadcastWorksheetID(DbContext, InvoiceMatchingSettingID)

                    InvoiceMatchingSetting = (From Entity In AdvantageFramework.Database.Procedures.InvoiceMatchingSetting.Load(DbContext)
                                              Where Entity.ClientCode = MediaBroadcastWorksheet.ClientCode And
                                                    Entity.MediaTypeCode = MediaBroadcastWorksheet.MediaTypeCode
                                              Select Entity).SingleOrDefault

                    If InvoiceMatchingSetting Is Nothing Then

                        InvoiceMatchingSetting = (From Entity In AdvantageFramework.Database.Procedures.InvoiceMatchingSetting.Load(DbContext)
                                                  Where Entity.MediaTypeCode = MediaBroadcastWorksheet.MediaTypeCode AndAlso
                                                        Entity.ClientCode Is Nothing
                                                  Select Entity).SingleOrDefault

                    End If

                    MediaBroadcastWorksheetSpotMatchingSetting = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetSpotMatchingSetting.LoadByMediaBroadcastWorksheetID(DbContext, InvoiceMatchingSettingID)

                    If MediaBroadcastWorksheetSpotMatchingSetting Is Nothing Then

                        If MediaBroadcastWorksheet IsNot Nothing Then

                            If InvoiceMatchingSetting IsNot Nothing Then

                                MediaBroadcastWorksheetSpotMatchingSetting = New AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting
                                MediaBroadcastWorksheetSpotMatchingSetting.DbContext = DbContext
                                MediaBroadcastWorksheetSpotMatchingSetting.MediaBroadcastWorksheetID = MediaBroadcastWorksheet.ID

                                MediaBroadcastWorksheetSpotMatchingSetting.AdjacencyAfter = InvoiceMatchingSetting.AdjacencyAfter
                                MediaBroadcastWorksheetSpotMatchingSetting.AdjacencyBefore = InvoiceMatchingSetting.AdjacencyBefore
                                MediaBroadcastWorksheetSpotMatchingSetting.BookendMaxSeparation = InvoiceMatchingSetting.BookendMaxSeparation
                                MediaBroadcastWorksheetSpotMatchingSetting.VerifyAdNumber = InvoiceMatchingSetting.VerifyAdNumber
                                MediaBroadcastWorksheetSpotMatchingSetting.VerifyDay = InvoiceMatchingSetting.VerifyDay
                                MediaBroadcastWorksheetSpotMatchingSetting.VerifyLength = InvoiceMatchingSetting.VerifyLength
                                MediaBroadcastWorksheetSpotMatchingSetting.VerifyNetwork = InvoiceMatchingSetting.VerifyNetwork
                                MediaBroadcastWorksheetSpotMatchingSetting.VerifyRate = InvoiceMatchingSetting.VerifyRate
                                MediaBroadcastWorksheetSpotMatchingSetting.VerifySchedule = InvoiceMatchingSetting.VerifySchedule
                                MediaBroadcastWorksheetSpotMatchingSetting.VerifyTime = InvoiceMatchingSetting.VerifyTime
                                MediaBroadcastWorksheetSpotMatchingSetting.VerifyTimeSep = InvoiceMatchingSetting.VerifyTimeSep

                                AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetSpotMatchingSetting.Insert(DbContext, MediaBroadcastWorksheetSpotMatchingSetting, Nothing)

                                MediaBroadcastWorksheetSpotMatchingSetting = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetSpotMatchingSetting.LoadByMediaBroadcastWorksheetID(DbContext, MediaBroadcastWorksheet.ID)

                            End If

                        End If

                    End If

                    TimeSeparationSettingViewModel.SpotMatchingSetting = New AdvantageFramework.DTO.Media.SpotMatchingSetting(MediaBroadcastWorksheetSpotMatchingSetting)

                    TimeSeparationSettingViewModel.MediaTypeCode = TimeSeparationSettingViewModel.SpotMatchingSetting.MediaTypeCode

                    TimeSeparationSettingViewModel.TimeSeparationSettings = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetTimeSeparationSetting.LoadByMediaBroadcastWorksheetSpotMatchingSettingID(DbContext, TimeSeparationSettingViewModel.SpotMatchingSetting.ID).ToList
                                                                             Select New AdvantageFramework.DTO.Media.TimeSeparationSetting(Entity)).ToList

                    If TimeSeparationSettingViewModel.TimeSeparationSettings.Count = 1 AndAlso TimeSeparationSettingViewModel.TimeSeparationSettings.First.CrossLengthSeparationEnabled Then

                        TimeSeparationSettingViewModel.CrossLengthSeparationEnabled = TimeSeparationSettingViewModel.TimeSeparationSettings.First.CrossLengthSeparationEnabled
                        TimeSeparationSettingViewModel.CrossLengthSeparationValue = TimeSeparationSettingViewModel.TimeSeparationSettings.First.CrossLengthSeparationValue

                        TimeSeparationSettingViewModel.TimeSeparationSettings = New Generic.List(Of AdvantageFramework.DTO.Media.TimeSeparationSetting)

                    ElseIf TimeSeparationSettingViewModel.TimeSeparationSettings.Count = 0 Then

                        TimeSeparationSettingViewModel.TimeSeparationSettings = (From Entity In AdvantageFramework.Database.Procedures.TimeSeparationSetting.LoadByInvoiceMatchingSettingID(DbContext, InvoiceMatchingSetting.ID).ToList
                                                                                 Select New AdvantageFramework.DTO.Media.TimeSeparationSetting(Entity)).ToList

                    End If

                End If

            End Using

            Load = TimeSeparationSettingViewModel

        End Function
        Public Function Save(TimeSeparationSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel) As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim TimeSeparationSetting As AdvantageFramework.Database.Entities.TimeSeparationSetting = Nothing
            Dim MediaBroadcastWorksheetTimeSeparationSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting = Nothing
            Dim ErrorMessage As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TimeSeparationSettingViewModel.Source = ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource.Default Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.TIME_SEPARATION_SETTING WHERE BRDCAST_DTL_VERIFICATION_SETTING_ID = {0}", TimeSeparationSettingViewModel.SpotMatchingSetting.ID))

                    If TimeSeparationSettingViewModel.CrossLengthSeparationEnabled Then

                        TimeSeparationSetting = New Database.Entities.TimeSeparationSetting
                        TimeSeparationSetting.DbContext = DbContext
                        TimeSeparationSetting.InvoiceMatchingSettingID = TimeSeparationSettingViewModel.SpotMatchingSetting.ID

                        TimeSeparationSetting.CrossLengthSeparationEnabled = TimeSeparationSettingViewModel.CrossLengthSeparationEnabled
                        TimeSeparationSetting.CrossLengthSeparationValue = TimeSeparationSettingViewModel.CrossLengthSeparationValue

                        Saved = AdvantageFramework.Database.Procedures.TimeSeparationSetting.Insert(DbContext, TimeSeparationSetting)

                    ElseIf TimeSeparationSettingViewModel.CrossLengthSeparationEnabled = False Then

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        For Each DTOTimeSeparationSetting In TimeSeparationSettingViewModel.TimeSeparationSettings

                            TimeSeparationSetting = New Database.Entities.TimeSeparationSetting
                            TimeSeparationSetting.DbContext = DbContext
                            TimeSeparationSetting.InvoiceMatchingSettingID = TimeSeparationSettingViewModel.SpotMatchingSetting.ID

                            DTOTimeSeparationSetting.SaveToEntity(TimeSeparationSetting)
                            Saved = AdvantageFramework.Database.Procedures.TimeSeparationSetting.Insert(DbContext, TimeSeparationSetting)

                        Next

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    End If

                ElseIf TimeSeparationSettingViewModel.Source = ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource.Worksheet Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_BROADCAST_WORKSHEET_TIME_SEPARATION_SETTING WHERE MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID = {0}", TimeSeparationSettingViewModel.SpotMatchingSetting.ID))

                    If TimeSeparationSettingViewModel.CrossLengthSeparationEnabled Then

                        MediaBroadcastWorksheetTimeSeparationSetting = New Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting
                        MediaBroadcastWorksheetTimeSeparationSetting.DbContext = DbContext
                        MediaBroadcastWorksheetTimeSeparationSetting.MediaBroadcastWorksheetSpotMatchingSettingID = TimeSeparationSettingViewModel.SpotMatchingSetting.ID

                        MediaBroadcastWorksheetTimeSeparationSetting.CrossLengthSeparationEnabled = TimeSeparationSettingViewModel.CrossLengthSeparationEnabled
                        MediaBroadcastWorksheetTimeSeparationSetting.CrossLengthSeparationValue = TimeSeparationSettingViewModel.CrossLengthSeparationValue

                        Saved = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetTimeSeparationSetting.Insert(DbContext, MediaBroadcastWorksheetTimeSeparationSetting, ErrorMessage)

                    ElseIf TimeSeparationSettingViewModel.CrossLengthSeparationEnabled = False Then

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        For Each DTOTimeSeparationSetting In TimeSeparationSettingViewModel.TimeSeparationSettings

                            MediaBroadcastWorksheetTimeSeparationSetting = New Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting
                            MediaBroadcastWorksheetTimeSeparationSetting.DbContext = DbContext
                            MediaBroadcastWorksheetTimeSeparationSetting.MediaBroadcastWorksheetSpotMatchingSettingID = TimeSeparationSettingViewModel.SpotMatchingSetting.ID

                            DTOTimeSeparationSetting.SaveToEntity(MediaBroadcastWorksheetTimeSeparationSetting)
                            Saved = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetTimeSeparationSetting.Insert(DbContext, MediaBroadcastWorksheetTimeSeparationSetting, ErrorMessage)

                        Next

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    End If

                End If

            End Using

            Save = Saved

        End Function
        Public Sub CancelNewItemRow(TimeSeparationSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel)

            TimeSeparationSettingViewModel.IsNewRow = False
            TimeSeparationSettingViewModel.CancelEnabled = False
            TimeSeparationSettingViewModel.DeleteEnabled = TimeSeparationSettingViewModel.HasASelectedTimeSeparationSetting

        End Sub
        Public Sub InitNewRowEvent(TimeSeparationSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel)

            TimeSeparationSettingViewModel.IsNewRow = True
            TimeSeparationSettingViewModel.CancelEnabled = True
            TimeSeparationSettingViewModel.DeleteEnabled = False

        End Sub
        Public Sub TimeSeparationSettingFocusedRowChanged(TimeSeparationSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel,
                                                          IsNewItemRow As Boolean,
                                                          SelectedTimeSeparationSettings As Generic.List(Of AdvantageFramework.DTO.Media.TimeSeparationSetting))

            TimeSeparationSettingViewModel.SelectedTimeSeparationSettings = SelectedTimeSeparationSettings

            TimeSeparationSettingViewModel.IsNewRow = IsNewItemRow
            TimeSeparationSettingViewModel.CancelEnabled = IsNewItemRow
            TimeSeparationSettingViewModel.DeleteEnabled = Not IsNewItemRow AndAlso TimeSeparationSettingViewModel.HasASelectedTimeSeparationSetting

        End Sub
        Public Sub SetCrossLengthSeparationEnabled(TimeSeparationSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel, Enabled As Boolean)

            TimeSeparationSettingViewModel.IsDirty = True
            TimeSeparationSettingViewModel.CrossLengthSeparationEnabled = Enabled

            If Not Enabled Then

                TimeSeparationSettingViewModel.CrossLengthSeparationValue = 0

            End If

        End Sub
        Public Sub SetCrossLengthSeparationValue(TimeSeparationSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel, Value As Short)

            TimeSeparationSettingViewModel.IsDirty = True
            TimeSeparationSettingViewModel.CrossLengthSeparationValue = Value

        End Sub
        Public Function ValidateEntity(TimeSeparationSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel,
                                       TimeSeparationSetting As AdvantageFramework.DTO.Media.TimeSeparationSetting, ByRef IsValid As Boolean) As String

            Dim ErrorText As String = Nothing

            If (From Entity In TimeSeparationSettingViewModel.TimeSeparationSettings
                Where Entity.Guid <> TimeSeparationSetting.Guid AndAlso
                      Entity.Length = TimeSeparationSetting.Length
                Select Entity).Any Then

                IsValid = False

                ErrorText = "A setting with this length exists."

            End If

            ValidateEntity = ErrorText

        End Function

#End Region

#End Region

    End Class

End Namespace
