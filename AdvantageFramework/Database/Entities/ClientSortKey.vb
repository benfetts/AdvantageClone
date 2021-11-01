Namespace Database.Entities

    <Serializable()>
    <Table("CL_SRT_KEY")>
    Public Class ClientSortKey
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            SortKey
            Client

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(6)>
        <Column("CL_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        <Key>
        <Required>
        <MaxLength(20)>
        <Column("CL_SRT_KEY", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Sort Option")>
        Public Property SortKey() As String

        Public Overridable Property Client As Database.Entities.Client

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode

        End Function

#End Region

    End Class

End Namespace
