Namespace DTO.Media.MediaManager

    <Serializable()>
    Public Class MediaManagerGeneratePurchaseOrder
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Shadows Enum Properties
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
            DisplayPONumber
            NeedsApproval
        End Enum

#End Region

#Region " Variables "

        Private _VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO = Nothing
        Private _Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Print/Email")>
        Public Property DefaultCorrespondenceMethod() As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Issued By" & vbCrLf & "Code")>
        Public Property IssuedByCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Issued" & vbCrLf & "By")>
        Public Property IssuedBy() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="PO" & vbCrLf & "Number")>
        Public Property PONumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="PO" & vbCrLf & "Description")>
        Public Property PODescription() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="PO" & vbCrLf & "Revision")>
        Public Property Revision() As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Issued" & vbCrLf & "to Code")>
        Public Property VendorCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Issued" & vbCrLf & "to Name")>
        Public Property VendorName() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="PO" & vbCrLf & "Date")>
        Public Property PODate() As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="PO" & vbCrLf & "Amount", DisplayFormat:="n2")>
        Public Property POAmount() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorContactCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Contact")>
        Public Property VendorContactName() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Contact Email")>
        Public Property VendorContactEmail() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="PO" & vbCrLf & "Status")>
        Public Property POStatus() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Payment" & vbCrLf & "Method")>
        Public Property PaymentMethod() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order" & vbCrLf & "Accepted")>
        Public Property OrderAccepted() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="g")>
        Public Property CreatedDate() As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Last Generated" & vbCrLf & "Date", DisplayFormat:="g")>
        Public Property LastGeneratedDate() As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DisplayPONumber() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NeedsApproval() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, MediaManagerPODetail As AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail, Vendor As AdvantageFramework.Database.Entities.Vendor, VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO)

            'objects
            Dim MediaManagerGeneratedPOReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport = Nothing

            Me.IssuedByCode = MediaManagerPODetail.IssuedByCode
            Me.IssuedBy = MediaManagerPODetail.IssuedBy
            Me.PONumber = MediaManagerPODetail.PONumber
            Me.PODescription = MediaManagerPODetail.PODescription
            Me.Revision = MediaManagerPODetail.Revision
            Me.VendorCode = MediaManagerPODetail.VendorCode
            Me.VendorName = MediaManagerPODetail.VendorName
            Me.PODate = MediaManagerPODetail.PODate
            Me.POAmount = MediaManagerPODetail.POAmount
            Me.VendorContactCode = MediaManagerPODetail.VendorContactCode
            Me.VendorContactName = MediaManagerPODetail.VendorContactName
            Me.VendorContactEmail = MediaManagerPODetail.VendorContactEmail
            Me.POStatus = MediaManagerPODetail.POStatus
            Me.PaymentMethod = MediaManagerPODetail.PaymentMethod
            Me.OrderAccepted = MediaManagerPODetail.OrderAccepted
            Me.DisplayPONumber = MediaManagerPODetail.DisplayPONumber
            Me.NeedsApproval = MediaManagerPODetail.NeedsApproval

            _VCCCardPO = VCCCardPO
            _Vendor = Vendor

            If Vendor IsNot Nothing Then

                Select Case Vendor.DefaultCorrespondenceMethod.GetValueOrDefault(1)

                    Case AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email

                        Me.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email

                    Case AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print

                        Me.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print

                End Select

            End If

            MediaManagerGeneratedPOReport = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedPOReport.LoadByPONumber(DbContext, Me.PONumber).ToList
                                             Where Entity.PORevision.GetValueOrDefault(0) = Me.Revision.GetValueOrDefault(0)
                                             Select Entity).SingleOrDefault

            If MediaManagerGeneratedPOReport IsNot Nothing Then

                Me.CreatedDate = MediaManagerGeneratedPOReport.CreatedDate
                Me.LastGeneratedDate = MediaManagerGeneratedPOReport.LastGeneratedDate

            End If

        End Sub

#End Region

    End Class

End Namespace