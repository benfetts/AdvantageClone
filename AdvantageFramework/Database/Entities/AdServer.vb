Namespace Database.Entities

    <Table("AD_SERVER")>
    Public Class AdServer
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("AD_SERVER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As AdvantageFramework.Database.Entities.AdServerID
        <Required>
        <MaxLength(20)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
