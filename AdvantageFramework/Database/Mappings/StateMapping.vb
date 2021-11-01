Namespace Database.Mappings

    Public Class StateMapping
        Inherits System.Data.Entity.ModelConfiguration.EntityTypeConfiguration(Of Entities.State)

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

            ToTable("STATES_LIST", "dbo")
            HasKey(Function(Entity) Entity.ID)
            [Property](Function(Entity) Entity.ID).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)

            [Property](Function(Entity) Entity.StateName).HasColumnName("STATE_NAME")
            [Property](Function(Entity) Entity.StateCode).HasColumnName("STATE_CODE")
            [Property](Function(Entity) Entity.Country).HasColumnName("COUNTRY")
            [Property](Function(Entity) Entity.CountryID).HasColumnName("COUNTRY_ID")

        End Sub

#End Region

    End Class

End Namespace
