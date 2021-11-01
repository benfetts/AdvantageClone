Namespace Database.Entities

    <Table("BOARD_SWIM_LANE")>
    Public Class BoardSwimLane
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            Name
            Description

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <Required>
        <MaxLength(50)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name As String

        <Column("DESCRIPTION", TypeName:="varchar(MAX)")>
        Public Property Description As String


#End Region

#Region " Methods "

        Sub New()

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
