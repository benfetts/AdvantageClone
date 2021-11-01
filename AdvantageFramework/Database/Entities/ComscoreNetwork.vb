Namespace Database.Entities

    <Table("COMSCORE_NETWORK")>
    Public Class ComscoreNetwork
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Number
            Name
            Type
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("COMSCORE_NETWORK_ID")>
        Public Property ID() As Integer
        <Required>
        <Column("NUMBER")>
        Public Property Number() As Integer
        <Required>
        <MaxLength(50)>
        <Column("NAME", TypeName:="varchar")>
        Public Property Name() As String
        <Required>
        <MaxLength(50)>
        <Column("TYPE", TypeName:="varchar")>
        Public Property Type() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
