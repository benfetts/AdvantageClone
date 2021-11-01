Namespace Database.Procedures.ClientOrder

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

        Public Function LoadByClientIDandOrderType(DbContext As Database.NielsenDbContext, ClientID As Integer, OrderType As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientOrder)

            LoadByClientIDandOrderType = From ClientOrder In DbContext.GetQuery(Of Database.Entities.ClientOrder)
                                         Where ClientOrder.ClientID = ClientID AndAlso
                                               ClientOrder.OrderType = OrderType
                                         Select ClientOrder

        End Function
        Public Function LoadByID(DbContext As Database.NielsenDbContext, ID As Integer) As Database.Entities.ClientOrder

            LoadByID = (From ClientOrder In DbContext.GetQuery(Of Database.Entities.ClientOrder)
                        Where ClientOrder.ID = ID
                        Select ClientOrder).SingleOrDefault

        End Function
        Public Function Load(DbContext As Database.NielsenDbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientOrder)

            Load = From ClientOrder In DbContext.GetQuery(Of Database.Entities.ClientOrder)
                   Select ClientOrder

        End Function
        Public Function Delete(DbContext As Database.NielsenDbContext, ClientOrderID As Integer, ByRef ErrorText As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CLIENT_ORDER_MARKET WHERE CLIENT_ORDER_ID = {0}", ClientOrderID))
                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CLIENT_ORDER_STATE WHERE CLIENT_ORDER_ID = {0}", ClientOrderID))
                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CLIENT_ORDER WHERE CLIENT_ORDER_ID = {0}", ClientOrderID))

                Deleted = True

            Catch ex As Exception
                ErrorText = ex.Message
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
