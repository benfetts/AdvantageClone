Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_FORMAT")>
    Public Class NielsenRadioFormat
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(4)>
        <Column("CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Code() As String
        <Required>
        <MaxLength(40)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString

        End Function

#End Region

    End Class

End Namespace
