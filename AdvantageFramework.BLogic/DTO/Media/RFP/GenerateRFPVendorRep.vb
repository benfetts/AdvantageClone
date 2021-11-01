Namespace DTO.Media.RFP

    <Serializable()>
    Public Class GenerateRFPVendorRep

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaRFPHeaderID
            Process
            DefaultCorrespondenceMethod
            Vendor
            VendorRep
            VendorRepEmail
            ContactType
            VendorRepFrom
            VendorCode
            VendorRepCode
            CommentToVendor
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaRFPHeaderID As Integer
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Process")>
        Public Property Process() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Print/Email")>
        Public Property DefaultCorrespondenceMethod() As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor")>
        Public Property Vendor() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Rep")>
        Public Property VendorRep() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Rep Email")>
        Public Property VendorRepEmail() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Contact" & vbCrLf & "Type", PropertyType:=BaseClasses.PropertyTypes.ContactTypeID)>
        Public Property ContactType() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Rep From")>
        Public Property VendorRepFrom() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorRepCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CommentToVendor() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AlertRecipientEmployeeCodes() As Generic.List(Of String)

#End Region

#Region " Methods "

        Public Sub New(VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative, GenerateRFP As AdvantageFramework.DTO.Media.RFP.GenerateRFP)

            If VendorRepresentative IsNot Nothing Then

                Me.MediaRFPHeaderID = GenerateRFP.MediaRFPHeaderID
                Me.Process = True
                Me.DefaultCorrespondenceMethod = GenerateRFP.DefaultCorrespondenceMethod
                Me.Vendor = GenerateRFP.VendorName
                Me.VendorRep = VendorRepresentative.ToString
                Me.VendorRepEmail = VendorRepresentative.EmailAddress
                Me.VendorCode = VendorRepresentative.VendorCode
                Me.VendorRepCode = VendorRepresentative.Code
                Me.ContactType = VendorRepresentative.ContactTypeID
                Me.VendorRepFrom = "Vendor"
                Me.CommentToVendor = GenerateRFP.CommentToVendor
                Me.AlertRecipientEmployeeCodes = GenerateRFP.AlertRecipientEmployeeCodes

            End If

        End Sub

#End Region

    End Class

End Namespace