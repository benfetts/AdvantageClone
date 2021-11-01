Namespace Database.Entities

    <Table("GLSOURCE")>
    Public Class GeneralLedgerSource
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            IsDrillDown
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("GLSRCODE", TypeName:="varchar")>
        <Key>
        <Required>
        <MaxLength(2)>
        Public Property Code() As String

        <Column("GLSRDESC", TypeName:="varchar")>
        <Required>
        <MaxLength(40)>
        Public Property Description() As String

        <Column("GLSRDRILL")>
        Public Property IsDrillDown() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString

        End Function

#End Region

    End Class

End Namespace
