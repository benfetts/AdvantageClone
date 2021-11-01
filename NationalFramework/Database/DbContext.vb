Namespace Database

    Public Class DbContext
        Inherits BaseClasses.DbContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Clients
            ClientOrders
            ClientOrderDetails
            DownloadFiles
            EventLogs
            ServiceSettings
            ServiceStatuses
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Overridable Property Clients() As System.Data.Entity.DbSet(Of Database.Entities.Client)
        Public Overridable Property ClientOrders() As System.Data.Entity.DbSet(Of Database.Entities.ClientOrder)
        Public Overridable Property ClientOrderDetails() As System.Data.Entity.DbSet(Of Database.Entities.ClientOrderDetail)
        Public Overridable Property DownloadFiles() As System.Data.Entity.DbSet(Of Database.Entities.DownloadFile)
        Public Overridable Property EventLogs() As System.Data.Entity.DbSet(Of Database.Entities.EventLog)
        Public Overridable Property ServiceSettings() As System.Data.Entity.DbSet(Of Database.Entities.ServiceSetting)
        Public Overridable Property ServiceStatuses() As System.Data.Entity.DbSet(Of Database.Entities.ServiceStatus)

#End Region

        Public Sub New()
            MyBase.New("DbContext")
        End Sub
        Public Sub New(ConnectionString As String)

            MyBase.New(ConnectionString)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            MyBase.OnModelCreating(modelBuilder)

        End Sub

    End Class

End Namespace