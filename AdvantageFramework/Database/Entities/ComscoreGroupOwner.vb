Namespace Database.Entities

    <Table("COMSCORE_GROUP_OWNER")>
    Public Class ComscoreGroupOwner
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)>
        <Required>
        <MaxLength(100)>
        <Column("NAME")>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Name

        End Function

#End Region

    End Class

End Namespace
