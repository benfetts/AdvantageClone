Namespace Database.Procedures.ClientOrderDetail

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

        Public Function LoadByClientOrderID(DbContext As Database.DbContext, ClientOrderID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientOrderDetail)

            LoadByClientOrderID = From ClientOrderDetail In DbContext.GetQuery(Of Database.Entities.ClientOrderDetail)
                                  Where ClientOrderDetail.ClientOrderID = ClientOrderID
                                  Select ClientOrderDetail

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientOrderDetail)

            Load = From ClientOrderDetail In DbContext.GetQuery(Of Database.Entities.ClientOrderDetail)
                   Select ClientOrderDetail

        End Function

#End Region

    End Module

End Namespace
