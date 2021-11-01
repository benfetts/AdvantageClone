Namespace Database.Entities

    <Table("CLIENT_ORDER_STATE")>
    Public Class ClientOrderState
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCountyOrderID
            State
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("CLIENT_ORDER_STATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ID() As Integer

        <Required>
        <Column("CLIENT_ORDER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientOrderID() As Integer

        <Required>
        <Column("STATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property State() As String

        <ForeignKey("ClientOrderID")>
        Public Overridable Property ClientOrder As Database.Entities.ClientOrder

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
