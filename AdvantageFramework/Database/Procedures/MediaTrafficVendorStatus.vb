Namespace Database.Procedures.MediaTrafficVendorStatus

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

        Public Function LoadByMediaTrafficVendorIDs(ByVal DbContext As Database.DbContext, MediaTrafficVendorIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficVendorStatus)

            LoadByMediaTrafficVendorIDs = From MediaTrafficVendorStatus In DbContext.GetQuery(Of Database.Entities.MediaTrafficVendorStatus)
                                          Where MediaTrafficVendorIDs.Contains(MediaTrafficVendorStatus.MediaTrafficVendorID)
                                          Select MediaTrafficVendorStatus

        End Function
        Public Function LoadByMediaTrafficVendorID(ByVal DbContext As Database.DbContext, MediaTrafficVendorID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficVendorStatus)

            LoadByMediaTrafficVendorID = From MediaTrafficVendorStatus In DbContext.GetQuery(Of Database.Entities.MediaTrafficVendorStatus)
                                         Where MediaTrafficVendorStatus.MediaTrafficVendorID = MediaTrafficVendorID
                                         Select MediaTrafficVendorStatus

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficVendorStatus)

            Load = From MediaTrafficVendorStatus In DbContext.GetQuery(Of Database.Entities.MediaTrafficVendorStatus)
                   Select MediaTrafficVendorStatus

        End Function

#End Region

    End Module

End Namespace
