Namespace Database.Procedures.MediaRFPHeaderStatus

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

        Public Function LoadByMediaRFPHeaderID(DbContext As Database.DbContext, MediaRFPHeaderID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPHeaderStatus)

            LoadByMediaRFPHeaderID = From MediaRFPHeaderStatus In DbContext.GetQuery(Of Database.Entities.MediaRFPHeaderStatus)
                                     Where MediaRFPHeaderStatus.MediaRFPHeaderID = MediaRFPHeaderID
                                     Select MediaRFPHeaderStatus

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPHeaderStatus)

            Load = From MediaRFPHeaderStatus In DbContext.GetQuery(Of Database.Entities.MediaRFPHeaderStatus)
                   Select MediaRFPHeaderStatus

        End Function

#End Region

    End Module

End Namespace
