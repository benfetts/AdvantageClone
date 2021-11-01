Namespace Database.Procedures.MediaRFPHeader

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaRFPHeader

            If (From MediaRFPHeader In DbContext.GetQuery(Of Database.Entities.MediaRFPHeader)
                Where MediaRFPHeader.ID = ID
                Select MediaRFPHeader).Count = 1 Then

                LoadByID = (From MediaRFPHeader In DbContext.GetQuery(Of Database.Entities.MediaRFPHeader)
                            Where MediaRFPHeader.ID = ID
                            Select MediaRFPHeader).Single

            Else

                LoadByID = Nothing

            End If

        End Function
        Public Function LoadByMediaBroadcastWorksheetMarketID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPHeader)

            LoadByMediaBroadcastWorksheetMarketID = From MediaRFPHeader In DbContext.GetQuery(Of Database.Entities.MediaRFPHeader)
                                                    Where MediaRFPHeader.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
                                                    Select MediaRFPHeader

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPHeader)

            Load = From MediaRFPHeader In DbContext.GetQuery(Of Database.Entities.MediaRFPHeader)
                   Select MediaRFPHeader

        End Function

#End Region

    End Module

End Namespace
