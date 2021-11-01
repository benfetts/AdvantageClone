Namespace Database.Mappings

    Public Class OrderProcessLogMapping
        Inherits System.Data.Entity.ModelConfiguration.EntityTypeConfiguration(Of Entities.OrderProcessLog)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            ToTable("ORD_PROCESS_LOG", "dbo")
            HasKey(Function(Entity) Entity.ID)
            [Property](Function(Entity) Entity.ID).HasColumnName("ORDER_PROCESS_LOG_ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
            [Property](Function(Entity) Entity.OrderNumber).HasColumnName("ORDER_NBR")
            [Property](Function(Entity) Entity.OriginalProcessControl).HasColumnName("ORIG_PROCESS_CNTRL")
            [Property](Function(Entity) Entity.NewProcessControl).HasColumnName("NEW_PROCESS_CNTRL")
            [Property](Function(Entity) Entity.ProcessedDate).HasColumnName("PROCESS_DATE")
            [Property](Function(Entity) Entity.ProcessedByUserCode).HasColumnName("PROCESS_USER")
            [Property](Function(Entity) Entity.Comments).HasColumnName("PROCESS_COMMENT")

        End Sub

#End Region

    End Class

End Namespace
