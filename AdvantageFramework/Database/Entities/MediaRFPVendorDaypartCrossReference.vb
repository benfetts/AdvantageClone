Namespace Database.Entities

    <Table("MEDIA_RFP_VENDOR_DAYPART_XREF")>
    Public Class MediaRFPVendorDaypartCrossReference
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            VendorDaypartCode
            DaypartID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_RFP_VENDOR_DAYPART_XREF_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("VN_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VendorCode() As String
        <Column("VN_DAYPART_CODE", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VendorDaypartCode() As String
        <Required>
        <Column("DAY_PART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DaypartID() As Integer

        <ForeignKey("VendorCode")>
        Public Overridable Property Vendor As Database.Entities.Vendor
        <ForeignKey("DaypartID")>
        Public Overridable Property Daypart As Database.Entities.Daypart

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
