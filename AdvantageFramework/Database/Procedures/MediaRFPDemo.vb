Namespace Database.Procedures.MediaRFPDemo

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

        Public Function LoadByMediaRFPDetailLineID(DbContext As Database.DbContext, MediaRFPAvailLineID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPDemo)

            LoadByMediaRFPDetailLineID = From MediaRFPDemo In DbContext.GetQuery(Of Database.Entities.MediaRFPDemo)
                                         Where MediaRFPDemo.MediaRFPAvailLineID = MediaRFPAvailLineID
                                         Select MediaRFPDemo

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPDemo)

            Load = From MediaRFPDemo In DbContext.GetQuery(Of Database.Entities.MediaRFPDemo)
                   Select MediaRFPDemo

        End Function

#End Region

    End Module

End Namespace
