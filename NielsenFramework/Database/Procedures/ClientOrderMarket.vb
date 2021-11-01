Namespace Database.Procedures.ClientOrderMarket

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

        Public Function LoadByClientOrderID(DbContext As Database.NielsenDbContext, ClientOrderID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientOrderMarket)

            LoadByClientOrderID = From ClientOrderMarket In DbContext.GetQuery(Of Database.Entities.ClientOrderMarket)
                                  Where ClientOrderMarket.ClientOrderID = ClientOrderID
                                  Select ClientOrderMarket

        End Function
        Public Function Load(DbContext As Database.NielsenDbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientOrderMarket)

            Load = From ClientOrderMarket In DbContext.GetQuery(Of Database.Entities.ClientOrderMarket)
                   Select ClientOrderMarket

        End Function

#End Region

    End Module

End Namespace
