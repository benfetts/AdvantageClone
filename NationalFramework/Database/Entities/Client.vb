Namespace Database.Entities

    <Table("CLIENT")>
    Public Class Client
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Name
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("CLIENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Code() As String
        <Required>
        <MaxLength(40)>
        <Column("CLIENT_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Name() As String
        <Required>
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Boolean

        Public Overridable Property ClientOrders As ICollection(Of Database.Entities.ClientOrder)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
