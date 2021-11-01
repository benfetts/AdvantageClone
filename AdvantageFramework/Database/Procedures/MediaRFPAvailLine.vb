Namespace Database.Procedures.MediaRFPAvailLine

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaRFPAvailLine

            LoadByID = (From MediaRFPAvailLine In DbContext.GetQuery(Of Database.Entities.MediaRFPAvailLine)
                        Where MediaRFPAvailLine.ID = ID
                        Select MediaRFPAvailLine).SingleOrDefault

        End Function
        Public Function LoadByMediaRFPHeaderID(DbContext As Database.DbContext, MediaRFPHeaderID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPAvailLine)

            LoadByMediaRFPHeaderID = From MediaRFPAvailLine In DbContext.GetQuery(Of Database.Entities.MediaRFPAvailLine).Include("MediaRFPHeader")
                                     Where MediaRFPAvailLine.MediaRFPHeaderID = MediaRFPHeaderID
                                     Select MediaRFPAvailLine

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPAvailLine)

            Load = From MediaRFPAvailLine In DbContext.GetQuery(Of Database.Entities.MediaRFPAvailLine)
                   Select MediaRFPAvailLine

        End Function

#End Region

    End Module

End Namespace
