Namespace Database.Mappings

    Public Class ChatActiveUserMapping
        Inherits System.Data.Entity.ModelConfiguration.EntityTypeConfiguration(Of Entities.ChatActiveUser)

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

            ToTable("CHAT_ACTIVE_USER", "dbo")
            HasKey(Function(Entity) Entity.ID)
            [Property](Function(Entity) Entity.ID).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
            [Property](Function(Entity) Entity.ContextUserIdentityName).HasColumnName("CONTEXT_USER_IDENTITY_NAME")
            [Property](Function(Entity) Entity.ConnectionId).HasColumnName("CONNECTION_ID")
            [Property](Function(Entity) Entity.GUID).HasColumnName("GUID")
            [Property](Function(Entity) Entity.UserCode).HasColumnName("USER_CODE")
            [Property](Function(Entity) Entity.EmployeeCode).HasColumnName("EMP_CODE")
            [Property](Function(Entity) Entity.EmployeeFullName).HasColumnName("EMP_FML")
            [Property](Function(Entity) Entity.ConnectionString).HasColumnName("CONNECTION_STRING")
            [Property](Function(Entity) Entity.EmployeePicture).HasColumnName("EMPLOYEE_PICTURE")
            [Property](Function(Entity) Entity.IsTempSaved).HasColumnName("IS_TEMP_SAVED")
            [Property](Function(Entity) Entity.DoNotDisturb).HasColumnName("DO_NOT_DISTURB")

        End Sub

#End Region

    End Class

End Namespace
