Namespace Database.Mappings

    Public Class VendorContractContactMapping
        Inherits System.Data.Entity.ModelConfiguration.EntityTypeConfiguration(Of Entities.VendorContractContact)

        Public Sub New()

            ToTable("VENDOR_CONTRACT_CONTACTS", "dbo")
            HasKey(Function(Entity) Entity.ID)
            [Property](Function(Entity) Entity.ID).HasColumnName("VENDOR_CONTRACT_CONTACT_ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
            [Property](Function(Entity) Entity.ContractID).HasColumnName("VENDOR_CONTRACT_ID")
            [Property](Function(Entity) Entity.EmployeeCode).HasColumnName("EMP_CODE")
            [Property](Function(Entity) Entity.IncludeInAlert).HasColumnName("INCLUDE_IN_ALERT")

        End Sub

    End Class

End Namespace

