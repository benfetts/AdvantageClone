Namespace Database.Entities

    <Table("BROADCAST_TYPE")>
    Public Class BroadcastType
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("BROADCAST_TYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As Integer
        <Required>
        <MaxLength(20)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.id

        End Function

#End Region

    End Class

End Namespace
