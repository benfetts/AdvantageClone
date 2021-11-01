Namespace Database.Procedures.MediaOrderView

    <HideModuleName()> _
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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.MediaOrder)

            Load = From MediaOrder In DbContext.GetQuery(Of Database.Views.MediaOrder)
                   Select MediaOrder

        End Function
        Public Function LoadByCampaignID(ByVal DbContext As Database.DbContext, ByVal CampaignID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.MediaOrder)

            LoadByCampaignID = From MediaOrder In DbContext.GetQuery(Of Database.Views.MediaOrder)
                               Where MediaOrder.CampaignID = CampaignID
                               Select MediaOrder

        End Function
        Public Function LoadByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Database.Views.MediaOrder

            Try

                LoadByOrderNumber = (From MediaOrder In DbContext.GetQuery(Of Database.Views.MediaOrder)
                                     Where MediaOrder.OrderNumber = OrderNumber
                                     Select MediaOrder).SingleOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace