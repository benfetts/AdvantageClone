Namespace Database.Procedures.ClientOrderState

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

        Public Function LoadByClientOrderID(DbContext As Database.NielsenDbContext, ClientOrderID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientOrderState)

            LoadByClientOrderID = From ClientOrderState In DbContext.GetQuery(Of Database.Entities.ClientOrderState)
                                  Where ClientOrderState.ClientOrderID = ClientOrderID
                                  Select ClientOrderState

        End Function
        Public Function Load(DbContext As Database.NielsenDbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientOrderState)

            Load = From ClientOrderState In DbContext.GetQuery(Of Database.Entities.ClientOrderState)
                   Select ClientOrderState

        End Function

#End Region

    End Module

End Namespace
