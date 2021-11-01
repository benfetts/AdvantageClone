Namespace Database

    Public Class NielsenDbContext
        Inherits BaseClasses.DbContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Clients
            ClientCountyOrders
            ClientCountyOrderStates
            ClientOrders
            ClientOrderMarkets
            DownloadFiles
            EventLogs
            NielsenMarkets
            ServiceSettings
            ServiceStatuses
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Overridable Property Clients() As System.Data.Entity.DbSet(Of Database.Entities.Client)
        Public Overridable Property ClientOrders() As System.Data.Entity.DbSet(Of Database.Entities.ClientOrder)
        Public Overridable Property ClientOrderMarkets() As System.Data.Entity.DbSet(Of Database.Entities.ClientOrderMarket)
        Public Overridable Property ClientOrderStates() As System.Data.Entity.DbSet(Of Database.Entities.ClientOrderState)
        Public Overridable Property DownloadFiles() As System.Data.Entity.DbSet(Of Database.Entities.DownloadFile)
        Public Overridable Property EventLogs() As System.Data.Entity.DbSet(Of Database.Entities.EventLog)
        Public Overridable Property NielsenMarkets() As System.Data.Entity.DbSet(Of Database.Entities.NielsenMarket)
        Public Overridable Property ServiceSettings() As System.Data.Entity.DbSet(Of Database.Entities.ServiceSetting)
        Public Overridable Property ServiceStatuses() As System.Data.Entity.DbSet(Of Database.Entities.ServiceStatus)

#End Region

        Public Sub New()
            MyBase.New("NielsenDbContext")
        End Sub
        Public Sub New(ConnectionString As String)

            MyBase.New(ConnectionString)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            MyBase.OnModelCreating(modelBuilder)

        End Sub

    End Class

End Namespace