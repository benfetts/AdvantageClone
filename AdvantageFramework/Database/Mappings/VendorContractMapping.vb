Namespace Database.Mappings

    Public Class VendorContractMapping
        Inherits System.Data.Entity.ModelConfiguration.EntityTypeConfiguration(Of Entities.VendorContract)

        Public Sub New()

            ToTable("VENDOR_CONTRACT", "dbo")
            HasKey(Function(Entity) Entity.ID)
            [Property](Function(Entity) Entity.ID).HasColumnName("VENDOR_CONTRACT_ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
            [Property](Function(Entity) Entity.Code).HasColumnName("VENDOR_CONTRACT_CODE")
            [Property](Function(Entity) Entity.VendorCode).HasColumnName("VN_CODE")
            [Property](Function(Entity) Entity.Description).HasColumnName("DESCRIPTION")
            [Property](Function(Entity) Entity.Comments).HasColumnName("COMMENTS")
            [Property](Function(Entity) Entity.StartDate).HasColumnName("START_DATE")
            [Property](Function(Entity) Entity.EndDate).HasColumnName("END_DATE")
            [Property](Function(Entity) Entity.IsInactive).HasColumnName("INACTIVE_FLAG")
            [Property](Function(Entity) Entity.CreatedByUserCode).HasColumnName("CREATED_BY")
            [Property](Function(Entity) Entity.CreateDate).HasColumnName("CREATE_DATE")
            [Property](Function(Entity) Entity.ModifiedByUserCode).HasColumnName("MODIFIED_BY")
            [Property](Function(Entity) Entity.ModifiedDate).HasColumnName("MODIFIED_DATE")
            [Property](Function(Entity) Entity.RenewalAlertSentDate).HasColumnName("RENEWAL_ALERT_SENT_DATE")

        End Sub

    End Class

End Namespace

