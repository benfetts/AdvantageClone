Namespace Database

    Public Class DbContext
        Inherits Database.Base.DbContext

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Overridable Property Agencies() As System.Data.Entity.DbSet(Of Database.Entities.Agency)

#End Region

#Region " Methods "

        Public Sub New()

            MyBase.New("name=DefaultConnection")

        End Sub
        Public Sub New(ConnectionString As String)

            MyBase.New(AdvantageDocumentRepositorySettings.Database.Base.DbContext.CreateEntityConnectionString(ConnectionString))

            MyBase.Database.CommandTimeout = 0
            MyBase.Configuration.LazyLoadingEnabled = True
            MyBase.Configuration.ValidateOnSaveEnabled = False

            _ConnectionString = ConnectionString

            System.Data.Entity.Database.SetInitializer(Of Database.DbContext)(Nothing)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            MyBase.OnModelCreating(modelBuilder)

        End Sub

#End Region

    End Class

End Namespace
