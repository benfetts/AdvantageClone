Namespace DTO.Media.MediaManager

    <Serializable()>
    Public Class MediaManagerGeneratePurchaseOrderVendorContact
        Inherits AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder

#Region " Constants "



#End Region

#Region " Enum "

        Public Shadows Enum Properties
            Process
            DefaultCorrespondenceMethod
            IssuedByCode
            IssuedBy
            PONumber
            PODescription
            Revision
            VendorCode
            VendorName
            PODate
            POAmount
            VendorContactCode
            VendorContactName
            VendorContactEmail
            POStatus
            PaymentMethod
            OrderAccepted
            VCCCardID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Process() As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order" & vbCrLf & "Message")>
        Public Property OrderMessage() As String

#End Region

#Region " Methods "

        Public Sub New(MediaManagerGeneratePurchaseOrder As AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder)

            MyBase.New()

            Me.Process = True

            Me.DefaultCorrespondenceMethod = MediaManagerGeneratePurchaseOrder.DefaultCorrespondenceMethod
            Me.IssuedByCode = MediaManagerGeneratePurchaseOrder.IssuedByCode
            Me.IssuedBy = MediaManagerGeneratePurchaseOrder.IssuedBy
            Me.PONumber = MediaManagerGeneratePurchaseOrder.PONumber
            Me.PODescription = MediaManagerGeneratePurchaseOrder.PODescription
            Me.Revision = MediaManagerGeneratePurchaseOrder.Revision
            Me.VendorCode = MediaManagerGeneratePurchaseOrder.VendorCode
            Me.VendorName = MediaManagerGeneratePurchaseOrder.VendorName
            Me.PODate = MediaManagerGeneratePurchaseOrder.PODate
            Me.POAmount = MediaManagerGeneratePurchaseOrder.POAmount
            Me.VendorContactCode = MediaManagerGeneratePurchaseOrder.VendorContactCode
            Me.VendorContactName = MediaManagerGeneratePurchaseOrder.VendorContactName
            Me.VendorContactEmail = MediaManagerGeneratePurchaseOrder.VendorContactEmail
            Me.POStatus = MediaManagerGeneratePurchaseOrder.POStatus
            Me.PaymentMethod = MediaManagerGeneratePurchaseOrder.PaymentMethod
            Me.OrderAccepted = MediaManagerGeneratePurchaseOrder.OrderAccepted

        End Sub

#End Region

    End Class

End Namespace