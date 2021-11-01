Namespace DTO.Media.Traffic

    <Serializable()>
    Public Class GenerateVendorRep

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaTrafficVendorID
            MediaTrafficRevisionID
            Process
            DefaultCorrespondenceMethod
            Vendor
            VendorRep
            VendorRepEmail
            ContactType
            VendorRepFrom
            VendorCode
            VendorRepCode
            'CommentToVendor
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTrafficVendorID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTrafficRevisionIDs As Generic.List(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Process")>
        Public Property Process() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Print/Email")>
        Public Property DefaultCorrespondenceMethod() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor")>
        Public Property Vendor() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Rep")>
        Public Property VendorRep() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Rep Email")>
        Public Property VendorRepEmail() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Contact" & vbCrLf & "Type", PropertyType:=BaseClasses.PropertyTypes.ContactTypeID)>
        Public Property ContactType() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Rep From")>
        Public Property VendorRepFrom() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorRepCode() As String
        '<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        'Public Property CommentToVendor() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AlertRecipientEmployeeCodes() As Generic.List(Of String)

#End Region

#Region " Methods "

        Public Sub New(VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative, Generate As AdvantageFramework.DTO.Media.Traffic.Generate)

            If VendorRepresentative IsNot Nothing Then

                MediaTrafficRevisionIDs = New Generic.List(Of Integer)

                Me.MediaTrafficRevisionIDs.Add(Generate.MediaTrafficRevisionID)

                Me.MediaTrafficVendorID = Generate.MediaTrafficVendorID
                Me.Process = True
                Me.DefaultCorrespondenceMethod = Generate.DefaultCorrespondenceMethod
                Me.Vendor = Generate.VendorName
                Me.VendorRep = VendorRepresentative.ToString
                Me.VendorRepEmail = VendorRepresentative.EmailAddress
                Me.VendorCode = VendorRepresentative.VendorCode
                Me.VendorRepCode = VendorRepresentative.Code
                Me.ContactType = VendorRepresentative.ContactTypeID
                Me.VendorRepFrom = "Vendor"
                'Me.CommentToVendor = Generate.CommentToVendor
                Me.AlertRecipientEmployeeCodes = Generate.AlertRecipientEmployeeCodes

            End If

        End Sub

#End Region

    End Class

End Namespace