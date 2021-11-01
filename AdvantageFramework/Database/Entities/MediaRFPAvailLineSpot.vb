Namespace Database.Entities

    <Table("MEDIA_RFP_AVAILABLE_LINE_SPOT")>
    Public Class MediaRFPAvailLineSpot
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaRFPAvailLineID
            WeekDate
            Quantity
            Rate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_RFP_AVAILABLE_LINE_SPOT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_RFP_AVAILABLE_LINE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaRFPAvailLineID() As Integer
        <Required>
        <Column("WEEK_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property WeekDate() As Date
        <Required>
        <Column("QUANTITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Quantity() As Integer
        <Required>
        <Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Rate() As Decimal

        <ForeignKey("MediaRFPAvailLineID")>
        Public Overridable Property MediaRFPAvailLine As Database.Entities.MediaRFPAvailLine

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
