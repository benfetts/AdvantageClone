Namespace Database.Procedures.MediaBroadcastWorksheetMarketTraffic

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

        Public Function LoadByMediaBroadcastWorksheetMarketID(ByVal DbContext As Database.DbContext, MediaBroadcastWorksheetMarketID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketTraffic)

            LoadByMediaBroadcastWorksheetMarketID = From MediaBroadcastWorksheetMarketTraffic In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketTraffic)
                                                    Where MediaBroadcastWorksheetMarketTraffic.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
                                                    Select MediaBroadcastWorksheetMarketTraffic

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketTraffic)

            Load = From MediaBroadcastWorksheetMarketTraffic In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketTraffic)
                   Select MediaBroadcastWorksheetMarketTraffic

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaBroadcastWorksheetMarketTraffic As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketTraffic,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaBroadcastWorksheetMarketTraffics.Add(MediaBroadcastWorksheetMarketTraffic)

                ErrorText = MediaBroadcastWorksheetMarketTraffic.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                Inserted = False
                ErrorText = ex.Message
            Finally
                Insert = Inserted
            End Try

        End Function

#End Region

    End Module

End Namespace
