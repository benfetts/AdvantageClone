Namespace Database.Base

    <System.ComponentModel.DataAnnotations.Schema.NotMapped>
    Public MustInherit Class DbContext
        Inherits System.Data.Entity.DbContext

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _UserCode As String = ""
        Protected _ConnectionString As String = ""
        Protected _IsDisposed As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property ConnectionString As String
            Get
                ConnectionString = _ConnectionString
            End Get
        End Property
        Public ReadOnly Property IsDisposed As Boolean
            Get
                IsDisposed = _IsDisposed
            End Get
        End Property
        Public ReadOnly Property ObjectContext As System.Data.Entity.Core.Objects.ObjectContext
            Get
                ObjectContext = CType(Me, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext
            End Get
        End Property

#End Region

#Region " Methods "

        Public Function GetQuery(Of TEntity As Class)() As System.Data.Entity.Infrastructure.DbQuery(Of TEntity)

            GetQuery = Me.Set(Of TEntity).AsNoTracking

        End Function
        Public Sub New()

            MyBase.New("name=DefaultConnection")

        End Sub
        Public Sub New(ConnectionString As String)

            MyBase.New(ConnectionString)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            modelBuilder.Conventions.Add(New Conventions.DecimalPrecisionAttributeConvention())

            MyBase.OnModelCreating(modelBuilder)

        End Sub
        Public Shared Function CreateEntityConnectionString(ConnectionString As String) As String

            'objects
            Dim EntityConnectionStringBuilder As System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder = Nothing
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)
            SqlConnectionStringBuilder.MultipleActiveResultSets = True

            EntityConnectionStringBuilder = New System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder

            EntityConnectionStringBuilder.Provider = "System.Data.SqlClient"
            EntityConnectionStringBuilder.ProviderConnectionString = SqlConnectionStringBuilder.ToString

            EntityConnectionStringBuilder.Metadata = "res://*/Database.DbContext.csdl|res://*/Database.DbContext.ssdl|res://*/Database.DbContext.msl"
            'EntityConnectionStringBuilder.Metadata = "res://*/;"

            CreateEntityConnectionString = EntityConnectionStringBuilder.ToString

        End Function
        Public Shared Function CreateConnectionString(ConnectionString As String) As String

            'objects
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)
            SqlConnectionStringBuilder.MultipleActiveResultSets = True

            CreateConnectionString = SqlConnectionStringBuilder.ToString

        End Function
        Protected Overrides Sub Dispose(disposing As Boolean)

            MyBase.Dispose(disposing)

            _IsDisposed = True

        End Sub
        Public Function CreateCommand() As System.Data.SqlClient.SqlCommand

            'objects
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing

            If TypeOf Me.Database.Connection Is System.Data.SqlClient.SqlConnection Then

                SqlCommand = DirectCast(Me.Database.Connection, System.Data.SqlClient.SqlConnection).CreateCommand

            End If

            CreateCommand = SqlCommand

        End Function

#End Region

    End Class

End Namespace
