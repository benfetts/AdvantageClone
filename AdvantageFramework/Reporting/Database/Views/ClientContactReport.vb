Namespace Reporting.Database.Views

    <Serializable>
    <Table("V_DRPT_CLIENT_CONTACT_LIVE")>
    Public Class ClientContactReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            Client
            Address
            Address2
            City
            County
            State
            Country
            Zip
            Attention
            BillingAddress
            BillingAddress2
            BillingCity
            BillingCounty
            BillingState
            BillingCountry
            BillingZip
            StreetAddress
            StreetAddress2
            StreetCity
            StreetCounty
            StreetState
            StreetCountry
            StreetZip
            Footer
            MediaAttention
            MediaFooter
            IsActive
            IsNewBusiness
            ClientContactID
            ClientContactCode
            ContactType
            ClientContactClientCode
            ClientContactEmail
            ClientContactFirstName
            ClientContactLastName
            ClientContactMiddleInitial
            ClientContactTitle
            ClientContactAddress
            ClientContactAddress2
            ClientContactCity
            ClientContactCounty
            ClientContactState
            ClientContactCountry
            ClientContactZip
            ClientContactPhoneNumber
            ClientContactExtention
            ClientContactFaxNumber
            ClientContactFaxExtention
            ScheduleUser
            CPUser
            ReceivesAlerts
            ReceivesEmails
            IsClientContactInactive
            Name
            FullName
            ClientContactCellPhoneNumber
            Comment
            DivisionCode
            ProductCode

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Guid
        <Required>
        <MaxLength(6)>
        <Column("ClientCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
        <MaxLength(40)>
        <Column("Client", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Client() As String
        <MaxLength(40)>
        <Column("Address", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address() As String
        <MaxLength(40)>
        <Column("Address2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address2() As String
        <MaxLength(30)>
        <Column("City", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property City() As String
        <MaxLength(20)>
        <Column("County", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property County() As String
        <MaxLength(10)>
        <Column("State", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property State() As String
        <MaxLength(20)>
        <Column("Country", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Country() As String
        <MaxLength(10)>
        <Column("Zip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Zip() As String
        <MaxLength(40)>
        <Column("Attention", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Attention() As String
        <MaxLength(40)>
        <Column("BillingAddress", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingAddress() As String
        <MaxLength(40)>
        <Column("BillingAddress2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingAddress2() As String
        <MaxLength(30)>
        <Column("BillingCity", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCity() As String
        <MaxLength(20)>
        <Column("BillingCounty", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCounty() As String
        <MaxLength(10)>
        <Column("BillingState", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingState() As String
        <MaxLength(20)>
        <Column("BillingCountry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCountry() As String
        <MaxLength(10)>
        <Column("BillingZip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingZip() As String
        <MaxLength(40)>
        <Column("StreetAddress", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddress() As String
        <MaxLength(40)>
        <Column("StreetAddress2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetAddress2() As String
        <MaxLength(30)>
        <Column("StreetCity", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetCity() As String
        <MaxLength(20)>
        <Column("StreetCounty", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetCounty() As String
        <MaxLength(10)>
        <Column("StreetState", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetState() As String
        <MaxLength(20)>
        <Column("StreetCountry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetCountry() As String
        <MaxLength(10)>
        <Column("StreetZip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StreetZip() As String
        <MaxLength(60)>
        <Column("Footer", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Footer() As String
        <MaxLength(40)>
        <Column("MediaAttention", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaAttention() As String
        <MaxLength(60)>
        <Column("MediaFooter", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaFooter() As String
        <Required>
        <MaxLength(3)>
        <Column("IsActive", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActive() As String
        <Required>
        <MaxLength(3)>
        <Column("IsNewBusiness", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsNewBusiness() As String
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Column("ClientContactID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property ClientContactID() As Nullable(Of Integer)
        <MaxLength(6)>
        <Column("ClientContactCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactCode() As String
        <MaxLength(100)>
        <Column("ContactType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContactType() As String
        <MaxLength(6)>
        <Column("ClientContactClientCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactClientCode() As String
        <MaxLength(50)>
        <Column("ClientContactEmail", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactEmail() As String
        <MaxLength(30)>
        <Column("ClientContactFirstName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactFirstName() As String
        <MaxLength(30)>
        <Column("ClientContactLastName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactLastName() As String
        <MaxLength(1)>
        <Column("ClientContactMiddleInitial", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactMiddleInitial() As String
        <MaxLength(40)>
        <Column("ClientContactTitle", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactTitle() As String
        <MaxLength(40)>
        <Column("ClientContactAddress", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactAddress() As String
        <MaxLength(40)>
        <Column("ClientContactAddress2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactAddress2() As String
        <MaxLength(30)>
        <Column("ClientContactCity", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactCity() As String
        <MaxLength(20)>
        <Column("ClientContactCounty", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactCounty() As String
        <MaxLength(10)>
        <Column("ClientContactState", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactState() As String
        <MaxLength(20)>
        <Column("ClientContactCountry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactCountry() As String
        <MaxLength(10)>
        <Column("ClientContactZip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactZip() As String
        <MaxLength(13)>
        <Column("ClientContactPhoneNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactPhoneNumber() As String
        <MaxLength(5)>
        <Column("ClientContactExtention", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Contact Extension")>
        Public Property ClientContactExtention() As String
        <MaxLength(13)>
        <Column("ClientContactFaxNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactFaxNumber() As String
        <MaxLength(5)>
        <Column("ClientContactFaxExtention", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Contact Fax Extension")>
        Public Property ClientContactFaxExtention() As String
        <Required>
        <MaxLength(3)>
        <Column("ScheduleUser", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ScheduleUser() As String
        <Required>
        <MaxLength(3)>
        <Column("CPUser", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CPUser() As String
        <Required>
        <MaxLength(3)>
        <Column("ReceivesAlerts", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReceivesAlerts() As String
        <Required>
        <MaxLength(3)>
        <Column("ReceivesEmails", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReceivesEmails() As String
        <Required>
        <MaxLength(3)>
        <Column("IsClientContactInactive", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsClientContactInactive() As String
        <MaxLength(62)>
        <Column("Name", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Name() As String
        <MaxLength(64)>
        <Column("FullName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FullName() As String
        <MaxLength(13)>
        <Column("ClientContactCellPhoneNumber", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientContactCellPhoneNumber() As String
		<Column("Comment")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
        <MaxLength(6)>
        <Column("DivisionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
        <MaxLength(6)>
        <Column("ProductCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
