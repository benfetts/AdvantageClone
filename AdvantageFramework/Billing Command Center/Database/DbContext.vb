Namespace BillingCommandCenter.Database

    Public Class DbContext
        Inherits BaseClasses.DbContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BillingApprovalBatches
            BillingCommandCenters
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property BillingApprovalBatches As System.Data.Entity.DbSet(Of Database.Entities.BillingApprovalBatch)
        Public Property BillingCommandCenters As System.Data.Entity.DbSet(Of Database.Entities.BillingCommandCenter)

#End Region

#Region " Methods "

        <System.Obsolete>
        Public Sub New()

            MyBase.New("Data Source=TASC-CODE\TFS;Initial Catalog=ADV67000;Persist Security Info=True;User ID=SYSADM;Password=sysadm;MultipleActiveResultSets=True;APP=EntityFramework")

        End Sub
        <System.Obsolete>
        Public Sub New(ConnectionString As String)

            MyBase.New(ConnectionString)

        End Sub
        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode, AdvantageFramework.Database.Methods.DatabaseTypes.BillingCommandCenter)

            System.Data.Entity.Database.SetInitializer(Of AdvantageFramework.BillingCommandCenter.Database.DbContext)(Nothing)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            'modelBuilder.RegisterEntityType(GetType(Database.Entities.BillingApprovalBatch))
            'modelBuilder.RegisterEntityType(GetType(Database.Entities.BillingCommandCenter))

            'modelBuilder.Properties.Having(Function(Prop) Prop.GetCustomAttributes(False).OfType(Of AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute).FirstOrDefault).
            '                        Configure(Function(Prop, Attribute) Prop.HasPrecision(Attribute.Precision, Attribute.Scale))

            MyBase.OnModelCreating(modelBuilder)

        End Sub

#End Region

    End Class

End Namespace