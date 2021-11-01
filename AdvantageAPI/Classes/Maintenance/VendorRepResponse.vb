<DataContract>
Public Class VendorRepResponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

#End Region

#Region " Properties "

    <DataMember>
    Public Property VendorCode As String
    <DataMember>
    Public Property Code As String
    <DataMember>
    Public Property FirstName As String
    <DataMember>
    Public Property LastName As String
    <DataMember>
    Public Property MiddleInitial As String
    <DataMember>
    Public Property FirmName As String
    <DataMember>
    Public Property Address1 As String
    <DataMember>
    Public Property Address2 As String
    <DataMember>
    Public Property City As String
    <DataMember>
    Public Property County As String
    <DataMember>
    Public Property State As String
    <DataMember>
    Public Property Country As String
    <DataMember>
    Public Property Zip As String
    <DataMember>
    Public Property Telephone As String
    <DataMember>
    Public Property TelephoneExtension As String
    <DataMember>
    Public Property Fax As String
    <DataMember>
    Public Property FaxExtension As String
    <DataMember>
    Public Property EmailAddress As String
    <DataMember>
    Public Property IsInactive As System.Nullable(Of Int16)
    <DataMember>
    Public Property CellPhone As String
    <DataMember>
    Public Property ContactTypeID As System.Nullable(Of Integer)
    <DataMember>
    Public Property VendorName As String

#End Region

#Region " Methods "

    Public Sub New(VendorRepresentative As VendorRepresentative)

        Me.VendorCode = VendorRepresentative.VendorCode
        Me.Code = VendorRepresentative.Code
        Me.FirstName = VendorRepresentative.FirstName
        Me.LastName = VendorRepresentative.LastName
        Me.MiddleInitial = VendorRepresentative.MiddleInitial
        Me.FirmName = VendorRepresentative.FirmName
        Me.Address1 = VendorRepresentative.Address1
        Me.Address2 = VendorRepresentative.Address2
        Me.City = VendorRepresentative.City
        Me.County = VendorRepresentative.County
        Me.State = VendorRepresentative.State
        Me.Country = VendorRepresentative.Country
        Me.Zip = VendorRepresentative.Zip
        Me.Telephone = VendorRepresentative.Telephone
        Me.TelephoneExtension = VendorRepresentative.TelephoneExtension
        Me.Fax = VendorRepresentative.Fax
        Me.FaxExtension = VendorRepresentative.FaxExtension
        Me.EmailAddress = VendorRepresentative.EmailAddress
        Me.IsInactive = VendorRepresentative.IsInactive
        Me.CellPhone = VendorRepresentative.CellPhone
        Me.ContactTypeID = VendorRepresentative.ContactTypeID
        Me.VendorName = VendorRepresentative.Vendor.Name

    End Sub

#End Region

End Class

