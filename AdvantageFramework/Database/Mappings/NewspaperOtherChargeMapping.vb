Namespace Database.Mappings

    Public Class NewspaperOtherChargeMapping
        Inherits System.Data.Entity.ModelConfiguration.EntityTypeConfiguration(Of Entities.NewspaperOtherCharge)

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

            ToTable("NEWSPAPER_OTH_CHGS", "dbo")
            HasKey(Function(Entity) Entity.ID)
            [Property](Function(Entity) Entity.ID).HasColumnName("REC_ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)

            [Property](Function(Entity) Entity.OrderNumber).HasColumnName("ORDER_NBR")
            [Property](Function(Entity) Entity.LineNumber).HasColumnName("LINE_NBR")
            [Property](Function(Entity) Entity.ChargeType).HasColumnName("CHG_TYPE")
            [Property](Function(Entity) Entity.ChargeDescription).HasColumnName("CHG_DESC")
            [Property](Function(Entity) Entity.Quantity).HasColumnName("QUANTITY").HasPrecision(11, 2)
            [Property](Function(Entity) Entity.Rate).HasColumnName("RATE").HasPrecision(15, 4)
            [Property](Function(Entity) Entity.Amount).HasColumnName("AMOUNT").HasPrecision(15, 2)
            [Property](Function(Entity) Entity.RateType).HasColumnName("RATE_TYPE")
            [Property](Function(Entity) Entity.RevisedDate).HasColumnName("REVISED_DATE")
            [Property](Function(Entity) Entity.RevisedByUserCode).HasColumnName("REVISED_BY")

        End Sub

#End Region

    End Class

End Namespace
