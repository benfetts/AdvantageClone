Namespace Database.Procedures.MediaRFPAvailLineSpot

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

        Public Function LoadByMediaRFPAvailLineID(DbContext As Database.DbContext, MediaRFPAvailLineID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPAvailLineSpot)

            LoadByMediaRFPAvailLineID = From MediaRFPAvailLineSpot In DbContext.GetQuery(Of Database.Entities.MediaRFPAvailLineSpot)
                                        Where MediaRFPAvailLineSpot.MediaRFPAvailLineID = MediaRFPAvailLineID
                                        Select MediaRFPAvailLineSpot

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPAvailLineSpot)

            Load = From MediaRFPAvailLineSpot In DbContext.GetQuery(Of Database.Entities.MediaRFPAvailLineSpot)
                   Select MediaRFPAvailLineSpot

        End Function

#End Region

    End Module

End Namespace
