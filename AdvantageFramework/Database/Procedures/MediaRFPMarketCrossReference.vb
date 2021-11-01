Namespace Database.Procedures.MediaRFPMarketCrossReference

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

        '
        Public Function LoadByMediaRFPMarketCrossReferenceID(DbContext As Database.DbContext, MediaRFPMarketCrossReferenceID As Integer) As Database.Entities.MediaRFPMarketCrossReference

            LoadByMediaRFPMarketCrossReferenceID = (From MediaRFPMarketCrossReference In DbContext.GetQuery(Of Database.Entities.MediaRFPMarketCrossReference)
                                                    Where MediaRFPMarketCrossReference.ID = MediaRFPMarketCrossReferenceID
                                                    Select MediaRFPMarketCrossReference).SingleOrDefault

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPMarketCrossReference)

            Load = From MediaRFPMarketCrossReference In DbContext.GetQuery(Of Database.Entities.MediaRFPMarketCrossReference)
                   Select MediaRFPMarketCrossReference

        End Function

#End Region

    End Module

End Namespace
