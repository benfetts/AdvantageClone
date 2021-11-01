Namespace Database.Mappings

    Public Class VendorContractDocumentMapping
        Inherits System.Data.Entity.ModelConfiguration.EntityTypeConfiguration(Of Entities.VendorContractDocument)

        Public Sub New()

            ToTable("VENDOR_CONTRACT_DOCUMENTS", "dbo")
            HasKey(Function(Entity) Entity.ID)
            [Property](Function(Entity) Entity.ID).HasColumnName("VENDOR_CONTRACT_DOCUMENTS_ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
            [Property](Function(Entity) Entity.ContractID).HasColumnName("VENDOR_CONTRACT_ID")
            [Property](Function(Entity) Entity.DocumentID).HasColumnName("DOCUMENT_ID")

        End Sub

    End Class

End Namespace

