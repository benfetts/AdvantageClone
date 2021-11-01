Namespace DTO.Media.RFP

    Public Class MediaRFPVendorDaypartCrossReference
        Inherits AdvantageFramework.DTO.BaseClass

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

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        <MaxLength(6)>
        Public Property VendorCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <MaxLength(20)>
        Public Property VendorDaypartCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.DaypartID)>
        Public Property DaypartID As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(MediaRFPVendorDaypartCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorDaypartCrossReference)

            Me.ID = MediaRFPVendorDaypartCrossReference.ID
            Me.VendorCode = MediaRFPVendorDaypartCrossReference.VendorCode
            Me.VendorDaypartCode = MediaRFPVendorDaypartCrossReference.VendorDaypartCode.ToUpper
            Me.DaypartID = MediaRFPVendorDaypartCrossReference.DaypartID

        End Sub
        Public Sub SaveToEntity(ByRef MediaRFPVendorDaypartCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorDaypartCrossReference)

            MediaRFPVendorDaypartCrossReference.ID = Me.ID
            MediaRFPVendorDaypartCrossReference.VendorCode = Me.VendorCode
            MediaRFPVendorDaypartCrossReference.VendorDaypartCode = Me.VendorDaypartCode.Trim.ToUpper
            MediaRFPVendorDaypartCrossReference.DaypartID = Me.DaypartID

        End Sub

#End Region

    End Class

End Namespace
