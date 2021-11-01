Namespace Security.Database.Views

    <Table("V_DATABASE_SQLUSER")>
    Public Class DatabaseSQLUser
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Name
            ID
            Type
            TypeDescription
            DefaultSchemaName
            CreatedDate
            ModifiedDate
            OwnerID
            SID
            IsFixedRole

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(128)>
        <Column("name")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Name() As String
        <Key>
        <Required>
        <Column("principal_id")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(1)>
        <Column("type")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type() As String
        <MaxLength(60)>
        <Column("type_desc")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TypeDescription() As String
        <MaxLength(128)>
        <Column("default_schema_name")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultSchemaName() As String
        <Required>
        <Column("create_date")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <Required>
        <Column("modify_date")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Date
        <Column("owning_principal_id")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OwnerID() As Nullable(Of Integer)
        <Column("sid")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SID() As Byte()
        <Required>
        <Column("is_fixed_role")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsFixedRole() As Boolean


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Name

        End Function

#End Region

    End Class

End Namespace
