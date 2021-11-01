Namespace Database.Procedures.MediaRFPVendorMarketCrossReference

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

        Public Function LoadByMediaRFPVendorMarketCrossReferenceID(DbContext As Database.DbContext, MediaRFPVendorMarketCrossReferenceID As Integer) As Database.Entities.MediaRFPVendorMarketCrossReference

            LoadByMediaRFPVendorMarketCrossReferenceID = (From MediaRFPVendorMarketCrossReference In DbContext.GetQuery(Of Database.Entities.MediaRFPVendorMarketCrossReference)
                                                          Where MediaRFPVendorMarketCrossReference.ID = MediaRFPVendorMarketCrossReferenceID
                                                          Select MediaRFPVendorMarketCrossReference).SingleOrDefault

        End Function
        Public Function LoadByVendorCode(DbContext As Database.DbContext, VendorCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPVendorMarketCrossReference)

            LoadByVendorCode = From MediaRFPVendorMarketCrossReference In DbContext.GetQuery(Of Database.Entities.MediaRFPVendorMarketCrossReference)
                               Where MediaRFPVendorMarketCrossReference.VendorCode = VendorCode
                               Select MediaRFPVendorMarketCrossReference

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPVendorMarketCrossReference)

            Load = From MediaRFPVendorMarketCrossReference In DbContext.GetQuery(Of Database.Entities.MediaRFPVendorMarketCrossReference)
                   Select MediaRFPVendorMarketCrossReference

        End Function

#End Region

    End Module

End Namespace
