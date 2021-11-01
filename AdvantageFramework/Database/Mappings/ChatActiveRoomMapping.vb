Namespace Database.Mappings

    Public Class ChatActiveRoomMapping
        Inherits System.Data.Entity.ModelConfiguration.EntityTypeConfiguration(Of Entities.ChatActiveRoom)

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

            ToTable("CHAT_ACTIVE_ROOM", "dbo")
            HasKey(Function(Entity) Entity.ID)
            [Property](Function(Entity) Entity.ID).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
            [Property](Function(Entity) Entity.RoomID).HasColumnName("ROOM_ID")
            [Property](Function(Entity) Entity.Name).HasColumnName("ROOM_NAME")
            [Property](Function(Entity) Entity.Description).HasColumnName("ROOM_DESC")
            [Property](Function(Entity) Entity.StartedByUserCode).HasColumnName("STARTED_BY_USER_CODE")
            [Property](Function(Entity) Entity.CreateDate).HasColumnName("CREATE_DATE")
            [Property](Function(Entity) Entity.IsPrivate).HasColumnName("IS_PRIVATE")

        End Sub

#End Region

    End Class

End Namespace
