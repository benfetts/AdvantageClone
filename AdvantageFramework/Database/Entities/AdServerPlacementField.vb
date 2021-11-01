Namespace Database.Entities

    <Table("AD_SERVER_PLACEMENT_FIELD")>
    Public Class AdServerPlacementField
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FieldOrder
            FieldCode
            FieldName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)>
        <Required>
        <Column("FIELD_ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property FieldOrder() As Integer
        <Required>
        <MaxLength(30)>
        <Column("FIELD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property FieldCode() As String
        <Required>
        <MaxLength(30)>
        <Column("FIELD_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property FieldName() As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
