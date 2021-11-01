Namespace Database.Procedures.MediaBroadcastWorksheetTimeSeparationSetting

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByMediaBroadcastWorksheetSpotMatchingSettingID(ByVal DbContext As Database.DbContext, MediaBroadcastWorksheetSpotMatchingSettingID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting)

            LoadByMediaBroadcastWorksheetSpotMatchingSettingID = From MediaBroadcastWorksheetTimeSeparationSetting In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting)
                                                                 Where MediaBroadcastWorksheetTimeSeparationSetting.MediaBroadcastWorksheetSpotMatchingSettingID = MediaBroadcastWorksheetSpotMatchingSettingID
                                                                 Select MediaBroadcastWorksheetTimeSeparationSetting

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting)

            Load = From MediaBroadcastWorksheetTimeSeparationSetting In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting)
                   Select MediaBroadcastWorksheetTimeSeparationSetting

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaBroadcastWorksheetTimeSeparationSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaBroadcastWorksheetTimeSeparationSettings.Add(MediaBroadcastWorksheetTimeSeparationSetting)

                ErrorText = MediaBroadcastWorksheetTimeSeparationSetting.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                ErrorText = ex.Message
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function

#End Region

    End Module

End Namespace
