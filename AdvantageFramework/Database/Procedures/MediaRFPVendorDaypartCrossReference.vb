Namespace Database.Procedures.MediaRFPVendorDaypartCrossReference

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

        Public Function LoadByMediaRFPVendorDaypartCrossReferenceID(DbContext As Database.DbContext, MediaRFPVendorDaypartCrossReferenceID As Integer) As Database.Entities.MediaRFPVendorDaypartCrossReference

            LoadByMediaRFPVendorDaypartCrossReferenceID = (From MediaRFPVendorDaypartCrossReference In DbContext.GetQuery(Of Database.Entities.MediaRFPVendorDaypartCrossReference)
                                                           Where MediaRFPVendorDaypartCrossReference.ID = MediaRFPVendorDaypartCrossReferenceID
                                                           Select MediaRFPVendorDaypartCrossReference).SingleOrDefault

        End Function
        Public Function LoadByVendorCode(DbContext As Database.DbContext, VendorCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPVendorDaypartCrossReference)

            LoadByVendorCode = From MediaRFPVendorDaypartCrossReference In DbContext.GetQuery(Of Database.Entities.MediaRFPVendorDaypartCrossReference)
                               Where MediaRFPVendorDaypartCrossReference.VendorCode = VendorCode
                               Select MediaRFPVendorDaypartCrossReference

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaRFPVendorDaypartCrossReference)

            Load = From MediaRFPVendorDaypartCrossReference In DbContext.GetQuery(Of Database.Entities.MediaRFPVendorDaypartCrossReference)
                   Select MediaRFPVendorDaypartCrossReference

        End Function

#End Region

    End Module

End Namespace
