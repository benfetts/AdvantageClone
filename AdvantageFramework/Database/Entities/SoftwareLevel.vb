Namespace Database.Entities

    <Table("SOFTWARE_LEVEL")>
    Public Class SoftwareLevel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            JobNumber
            JobComponentNumber
            ProductID
            VersionID

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("LEVEL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer

        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Nullable(Of Integer)

        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Nullable(Of Integer)

        <Column("PRODUCT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductID() As Nullable(Of Integer)

        <Column("VERSION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VersionID() As Nullable(Of Integer)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
