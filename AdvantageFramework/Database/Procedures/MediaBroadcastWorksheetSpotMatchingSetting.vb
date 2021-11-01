Namespace Database.Procedures.MediaBroadcastWorksheetSpotMatchingSetting

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

        Public Function LoadByMediaBroadcastWorksheetID(ByVal DbContext As Database.DbContext, MediaBroadcastWorksheetID As Integer) As Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting

            LoadByMediaBroadcastWorksheetID = (From MediaBroadcastWorksheetSpotMatchingSetting In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting)
                                               Where MediaBroadcastWorksheetSpotMatchingSetting.MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
                                               Select MediaBroadcastWorksheetSpotMatchingSetting).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting)

            Load = From MediaBroadcastWorksheetSpotMatchingSetting In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting)
                   Select MediaBroadcastWorksheetSpotMatchingSetting

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaBroadcastWorksheetSpotMatchingSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaBroadcastWorksheetSpotMatchingSettings.Add(MediaBroadcastWorksheetSpotMatchingSetting)

                ErrorText = MediaBroadcastWorksheetSpotMatchingSetting.ValidateEntity(IsValid)

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
        'Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaBroadcastWorksheetSpotMatchingSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting) As Boolean

        '    'objects
        '    Dim Updated As Boolean = False
        '    Dim IsValid As Boolean = True
        '    Dim ErrorText As String = ""

        '    Try

        '        DbContext.UpdateObject(MediaBroadcastWorksheetSpotMatchingSetting)

        '        ErrorText = MediaBroadcastWorksheetSpotMatchingSetting.ValidateEntity(IsValid)

        '        If IsValid Then

        '            DbContext.SaveChanges()

        '            Updated = True

        '        Else

        '            AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

        '        End If

        '    Catch ex As Exception
        '        Updated = False
        '    Finally
        '        Update = Updated
        '    End Try

        'End Function
        'Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaBroadcastWorksheetSpotMatchingSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting) As Boolean

        '    'objects
        '    Dim Deleted As Boolean = False
        '    Dim IsValid As Boolean = True
        '    Dim ErrorText As String = ""

        '    Try

        '        If IsValid Then

        '            DbContext.DeleteEntityObject(MediaBroadcastWorksheetSpotMatchingSetting)

        '            DbContext.SaveChanges()

        '            Deleted = True

        '        End If

        '    Catch ex As Exception
        '        Deleted = False
        '    Finally
        '        Delete = Deleted
        '    End Try

        'End Function

#End Region

    End Module

End Namespace
