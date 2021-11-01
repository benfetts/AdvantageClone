Namespace Database.Procedures.BroadcastOrderDetailView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.BroadcastOrderDetailView)

            Load = From BroadcastOrderDetailView In DbContext.GetQuery(Of Database.Views.BroadcastOrderDetailView)
                   Select BroadcastOrderDetailView

        End Function
        Public Function LoadRadio(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.BroadcastOrderDetailView)

            LoadRadio = From BroadcastOrderDetailView In DbContext.GetQuery(Of Database.Views.BroadcastOrderDetailView)
                        Where BroadcastOrderDetailView.MediaType = "Radio"
                        Select BroadcastOrderDetailView

        End Function
        Public Function LoadTV(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.BroadcastOrderDetailView)

            LoadTV = From BroadcastOrderDetailView In DbContext.GetQuery(Of Database.Views.BroadcastOrderDetailView)
                     Where BroadcastOrderDetailView.MediaType = "TV"
                     Select BroadcastOrderDetailView

        End Function
        Public Function LoadRadioByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.BroadcastOrderDetailView)

            LoadRadioByAccountPayableID = From BroadcastOrderDetailView In LoadRadio(DbContext)
                                          Where BroadcastOrderDetailView.AccountPayableID = AccountPayableID
                                          Select BroadcastOrderDetailView

        End Function
        Public Function LoadTVByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.BroadcastOrderDetailView)

            LoadTVByAccountPayableID = From BroadcastOrderDetailView In LoadTV(DbContext)
                                       Where BroadcastOrderDetailView.AccountPayableID = AccountPayableID
                                       Select BroadcastOrderDetailView

        End Function

#End Region

    End Module

End Namespace
