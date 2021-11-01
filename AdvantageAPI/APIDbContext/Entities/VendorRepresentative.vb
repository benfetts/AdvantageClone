<Table("VEN_REP")>
Public Class VendorRepresentative

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

#End Region

#Region " Properties "

    <Key>
    <Column("VN_CODE", Order:=0, TypeName:="varchar")>
    <MaxLength(6)>
    Public Property VendorCode() As String
    <Key>
    <Column("VR_CODE", Order:=1, TypeName:="varchar")>
    <MaxLength(4)>
    Public Property Code() As String
    <Column("VR_FNAME", TypeName:="varchar")>
    <MaxLength(30)>
    Public Property FirstName() As String
    <Column("VR_LNAME", TypeName:="varchar")>
    <MaxLength(30)>
    Public Property LastName() As String
    <Column("VR_MI", TypeName:="varchar")>
    <MaxLength(1)>
    Public Property MiddleInitial() As String
    <Column("VR_FIRM_NAME", TypeName:="varchar")>
    <MaxLength(40)>
    Public Property FirmName() As String
    <Column("VR_ADDRESS1", TypeName:="varchar")>
    <MaxLength(40)>
    Public Property Address1() As String
    <Column("VR_ADDRESS2", TypeName:="varchar")>
    <MaxLength(40)>
    Public Property Address2() As String
    <Column("VR_CITY", TypeName:="varchar")>
    <MaxLength(20)>
    Public Property City() As String
    <Column("VR_COUNTY", TypeName:="varchar")>
    <MaxLength(20)>
    Public Property County() As String
    <Column("VR_STATE", TypeName:="varchar")>
    <MaxLength(10)>
    Public Property State() As String
    <Column("VR_COUNTRY", TypeName:="varchar")>
    <MaxLength(20)>
    Public Property Country() As String
    <Column("VR_ZIP", TypeName:="varchar")>
    <MaxLength(10)>
    Public Property Zip() As String
    <Column("VR_TELEPHONE", TypeName:="varchar")>
    <MaxLength(13)>
    Public Property Telephone() As String
    <Column("VR_EXTENTION", TypeName:="varchar")>
    <MaxLength(4)>
    Public Property TelephoneExtension() As String
    <Column("VR_FAX", TypeName:="varchar")>
    <MaxLength(13)>
    Public Property Fax() As String
    <Column("VR_FAX_EXTENTION", TypeName:="varchar")>
    <MaxLength(4)>
    Public Property FaxExtension() As String
    <Column("EMAIL_ADDRESS", TypeName:="varchar")>
    <MaxLength(50)>
    Public Property EmailAddress() As String
    <Column("VR_INACTIVE_FLAG")>
    Public Property IsInactive() As System.Nullable(Of Int16)
    <Column("VR_PHONE_CELL", TypeName:="varchar")>
    <MaxLength(13)>
    Public Property CellPhone() As String
    <Column("CONTACT_TYPE_ID")>
    Public Property ContactTypeID() As System.Nullable(Of Integer)
    <NotMapped>
    Public Property VendorName As String
        Get
            VendorName = Vendor.Name
        End Get
        Set(value As String)

        End Set
    End Property

    <ForeignKey("VendorCode")>
    <System.Xml.Serialization.XmlIgnoreAttribute>
    Public Overridable Property Vendor As AdvantageAPI.Vendor

#End Region

#Region " Methods "



#End Region

End Class

