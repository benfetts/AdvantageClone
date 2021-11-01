Namespace National.Database

    Public Class DbContext
        Inherits BaseClasses.DbContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MarketBreaks
            NationalAudiences
            NationalAudienceCorrections
            NationalDatas
            NationalHutputs
            NationalHutputCorrections
            NationalNetworks
            NationalUniverses
            NationalYears
            ProgramTypes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Overridable Property MarketBreaks As System.Data.Entity.DbSet(Of National.Database.Entities.MarketBreak)
        Public Overridable Property NationalAudiences As System.Data.Entity.DbSet(Of National.Database.Entities.NationalAudience)
        Public Overridable Property NationalAudienceCorrections As System.Data.Entity.DbSet(Of National.Database.Entities.NationalAudienceCorrection)
        Public Overridable Property NationalDatas As System.Data.Entity.DbSet(Of National.Database.Entities.NationalData)
        Public Overridable Property NationalHutputs As System.Data.Entity.DbSet(Of National.Database.Entities.NationalHutput)
        Public Overridable Property NationalHutputCorrections As System.Data.Entity.DbSet(Of National.Database.Entities.NationalHutputCorrection)
        Public Overridable Property NationalNetworks As System.Data.Entity.DbSet(Of National.Database.Entities.NationalNetwork)
        Public Overridable Property NationalUniverses As System.Data.Entity.DbSet(Of National.Database.Entities.NationalUniverse)
        Public Overridable Property NationalYears As System.Data.Entity.DbSet(Of National.Database.Entities.NationalYear)
        Public Overridable Property ProgramTypes As System.Data.Entity.DbSet(Of National.Database.Entities.ProgramType)

#End Region

        <System.Obsolete>
        Public Sub New()

            MyBase.New("Data Source=TASC-CODE\TFS;Initial Catalog=ADV67000;Persist Security Info=True;User ID=SYSADM;Password=sysadm;MultipleActiveResultSets=True;APP=EntityFramework")

        End Sub
        <System.Obsolete>
        Public Sub New(ConnectionString As String)

            MyBase.New(ConnectionString)

        End Sub
        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode, AdvantageFramework.Database.Methods.DatabaseTypes.National)

            System.Data.Entity.Database.SetInitializer(Of AdvantageFramework.Security.Database.DbContext)(Nothing)

        End Sub
        Public Sub New(ByVal SqlConnection As SqlClient.SqlConnection)

            MyBase.New(SqlConnection.ConnectionString, Nothing, AdvantageFramework.Database.Methods.DatabaseTypes.National)

            System.Data.Entity.Database.SetInitializer(Of AdvantageFramework.Security.Database.DbContext)(Nothing)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            MyBase.OnModelCreating(modelBuilder)

        End Sub

    End Class

End Namespace