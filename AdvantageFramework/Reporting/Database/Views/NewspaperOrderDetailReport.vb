Namespace Reporting.Database.Views

    <Serializable>
    <Table("V_DRPT_NEWSPAPER_SHIPPING_LIST")>
    Public Class NewspaperOrderDetailReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            VendorName
            Address1
            Address2
            City
            County
            State
            Country
            ZipCode
            Phone
            PhoneExt
            Fax
            FaxExt
            ShippingName
            ShippingAddress1
            ShippingAddress2
            ShippingAddress3
            ShippingCity
            ShippingCounty
            ShippingCountry
            ShippingState
            ShippingZip
            ShippingPhone
            ShippingPhoneExt
            VendorDefaultRep1
            VendorDefaultRepName1
            VendorDefaultRep2
            VendorDefaultRepName2
            OveragePct
            Fold
            CampaignClient
            CampaignClientDescription
            CampaignDivision
            CampaignDivisionDescription
            CampaignProduct
            CampaignProductDescription
            CampaignCode
            CampaignID
            CampaignName
            CampaignBeginDate
            CampaignEndDate
            CampaignClosed
            CampaignBillingBudget
            CampaignIncomeBudget
            CampaignComments
            CampaignAdNumber
            CampaignAdNumberExp
            CampaignMarket
            CampaignMarketDescription
            CampaignJobNumber
            CampaignJobDescription
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            OrderNumber
            OrderDescription
            MediaType
            ClientPO
            OrderDate
            Buyer
            OrderComment
            HouseComment
            OrderMarketCode
            OrderMarketDescription
            OrderRep1
            OrderRepName1
            OrderRep2
            OrderRepName2
            Size
            OrderAdNumber
            OrderAdNumberDescription
            Headline
            Material
            EditionIssue
            Section
            JobNumber
            ComponentNumber
            StartDate
            EndDate
            CloseDate
            MatlCloseDate
            ExtCloseDate
            ExtMatlDate
            NpCirculation
            ProductionQty
            Qty
            CostType
            NetRate
            GrossRate
            ExtNetAmount
            ExtGrossAmount
            CommAmount
            RebateAmount
            DiscountAmount
            StateAmount
            CountyAmount
            CityAmount
            NonResaleAmount
            AddlCharge
            ProdCharge
            ColorCharge
            OrderTotal
            BillingAmount
            Instructions
            OrderCopy
            MatlNotes
            PositionInfo
            CloseInfo
            RateInfo
            MiscInfo
            InHouseComments

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
        <Column("VendorCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
        <MaxLength(40)>
        <Column("VendorName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
        <MaxLength(40)>
        <Column("Address1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address1() As String
        <MaxLength(40)>
        <Column("Address2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address2() As String
        <MaxLength(25)>
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
        <Column("ZipCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ZipCode() As String
        <MaxLength(13)>
        <Column("Phone", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Phone() As String
        <MaxLength(4)>
        <Column("PhoneExt", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PhoneExt() As String
        <MaxLength(13)>
        <Column("Fax", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Fax() As String
        <MaxLength(4)>
        <Column("FaxExt", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FaxExt() As String
        <MaxLength(40)>
        <Column("ShippingName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingName() As String
        <MaxLength(40)>
        <Column("ShippingAddress1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingAddress1() As String
        <MaxLength(40)>
        <Column("ShippingAddress2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingAddress2() As String
        <MaxLength(40)>
        <Column("ShippingAddress3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingAddress3() As String
        <MaxLength(25)>
        <Column("ShippingCity", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingCity() As String
        <MaxLength(20)>
        <Column("ShippingCounty", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingCounty() As String
        <MaxLength(20)>
        <Column("ShippingCountry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingCountry() As String
        <MaxLength(10)>
        <Column("ShippingState", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingState() As String
        <MaxLength(10)>
        <Column("ShippingZip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingZip() As String
        <MaxLength(13)>
        <Column("ShippingPhone", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingPhone() As String
        <MaxLength(4)>
        <Column("ShippingPhoneExt", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShippingPhoneExt() As String
        <MaxLength(4)>
        <Column("VendorDefaultRep1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorDefaultRep1() As String
        <MaxLength(64)>
        <Column("VendorDefaultRepName1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorDefaultRepName1() As String
        <MaxLength(4)>
        <Column("VendorDefaultRep2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorDefaultRep2() As String
        <MaxLength(64)>
        <Column("VendorDefaultRepName2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorDefaultRepName2() As String
        <Column("OveragePct")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OveragePct() As Nullable(Of Decimal)
        <Required>
        <MaxLength(3)>
        <Column("Fold", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Fold() As String
        <MaxLength(6)>
        <Column("CampaignClient", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignClient() As String
        <MaxLength(40)>
        <Column("CampaignClientDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignClientDescription() As String
        <MaxLength(6)>
        <Column("CampaignDivision", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignDivision() As String
        <MaxLength(40)>
        <Column("CampaignDivisionDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignDivisionDescription() As String
        <MaxLength(6)>
        <Column("CampaignProduct", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignProduct() As String
        <MaxLength(40)>
        <Column("CampaignProductDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignProductDescription() As String
        <MaxLength(6)>
        <Column("CampaignCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode() As String
        <Column("CampaignID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Integer)
        <MaxLength(60)>
        <Column("CampaignName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
        <Column("CampaignBeginDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignBeginDate() As Nullable(Of Date)
        <Column("CampaignEndDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignEndDate() As Nullable(Of Date)
        <Column("CampaignClosed")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignClosed() As Nullable(Of Short)
        <Column("CampaignBillingBudget")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignBillingBudget() As Nullable(Of Decimal)
        <Column("CampaignIncomeBudget")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignIncomeBudget() As Nullable(Of Decimal)
		<Column("CampaignComments")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignComments() As String
		<MaxLength(30)>
		<Column("CampaignAdNumber", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignAdNumber() As String
		<Column("CampaignAdNumberExp")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignAdNumberExp() As Nullable(Of Date)
		<MaxLength(10)>
		<Column("CampaignMarket", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignMarket() As String
		<MaxLength(40)>
		<Column("CampaignMarketDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignMarketDescription() As String
		<Column("CampaignJobNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property CampaignJobNumber() As Nullable(Of Integer)
		<MaxLength(60)>
		<Column("CampaignJobDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignJobDescription() As String
		<Required>
		<MaxLength(6)>
		<Column("ClientCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(40)>
		<Column("ClientDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientDescription() As String
		<Required>
		<MaxLength(6)>
		<Column("DivisionCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<MaxLength(40)>
		<Column("DivisionDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionDescription() As String
		<Required>
		<MaxLength(6)>
		<Column("ProductCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<MaxLength(40)>
		<Column("ProductDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductDescription() As String
		<Required>
		<Column("OrderNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property OrderNumber() As Integer
		<MaxLength(40)>
		<Column("OrderDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderDescription() As String
		<MaxLength(6)>
		<Column("MediaType", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaType() As String
		<MaxLength(25)>
		<Column("ClientPO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientPO() As String
		<Column("OrderDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderDate() As Nullable(Of Date)
		<MaxLength(40)>
		<Column("Buyer", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Buyer() As String
		<Column("OrderComment")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderComment() As String
		<Column("HouseComment")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HouseComment() As String
		<MaxLength(10)>
		<Column("OrderMarketCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderMarketCode() As String
		<MaxLength(40)>
		<Column("OrderMarketDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderMarketDescription() As String
		<MaxLength(4)>
		<Column("OrderRep1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderRep1() As String
		<MaxLength(64)>
		<Column("OrderRepName1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderRepName1() As String
		<MaxLength(4)>
		<Column("OrderRep2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderRep2() As String
		<MaxLength(64)>
		<Column("OrderRepName2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderRepName2() As String
		<MaxLength(30)>
		<Column("Size", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Size() As String
		<MaxLength(30)>
		<Column("OrderAdNumber", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderAdNumber() As String
		<MaxLength(60)>
		<Column("OrderAdNumberDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderAdNumberDescription() As String
		<MaxLength(60)>
		<Column("Headline", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Headline() As String
		<MaxLength(60)>
		<Column("Material", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Material() As String
		<MaxLength(30)>
		<Column("EditionIssue", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EditionIssue() As String
		<MaxLength(30)>
		<Column("Section", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Section() As String
		<Column("JobNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("ComponentNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ComponentNumber() As Nullable(Of Short)
		<Column("StartDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StartDate() As Nullable(Of Date)
		<Column("EndDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EndDate() As Nullable(Of Date)
		<Column("CloseDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CloseDate() As Nullable(Of Date)
		<Column("MatlCloseDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MatlCloseDate() As Nullable(Of Date)
		<Column("ExtCloseDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExtCloseDate() As Nullable(Of Date)
		<Column("ExtMatlDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExtMatlDate() As Nullable(Of Date)
		<Column("NpCirculation")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NpCirculation() As Nullable(Of Decimal)
		<Column("ProductionQty")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionQty() As Nullable(Of Decimal)
		<Column("Qty")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Qty() As Nullable(Of Decimal)
		<MaxLength(3)>
		<Column("CostType", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CostType() As String
		<Column("NetRate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetRate() As Nullable(Of Decimal)
		<Column("GrossRate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GrossRate() As Nullable(Of Decimal)
		<Column("ExtNetAmount")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExtNetAmount() As Nullable(Of Decimal)
		<Column("ExtGrossAmount")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExtGrossAmount() As Nullable(Of Decimal)
		<Column("CommAmount")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CommAmount() As Nullable(Of Decimal)
		<Column("RebateAmount")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RebateAmount() As Nullable(Of Decimal)
		<Column("DiscountAmount")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DiscountAmount() As Nullable(Of Decimal)
		<Column("StateAmount")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StateAmount() As Nullable(Of Decimal)
		<Column("CountyAmount")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CountyAmount() As Nullable(Of Decimal)
		<Column("CityAmount")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CityAmount() As Nullable(Of Decimal)
		<Column("NonResaleAmount")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NonResaleAmount() As Nullable(Of Decimal)
		<Column("AddlCharge")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AddlCharge() As Nullable(Of Decimal)
		<Column("ProdCharge")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProdCharge() As Nullable(Of Decimal)
		<Column("ColorCharge")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ColorCharge() As Nullable(Of Decimal)
		<Column("OrderTotal")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderTotal() As Nullable(Of Decimal)
		<Column("BillingAmount")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingAmount() As Nullable(Of Decimal)
		<Column("Instructions")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Instructions() As String
		<Column("OrderCopy")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderCopy() As String
		<Column("MatlNotes")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MatlNotes() As String
		<Column("PositionInfo")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PositionInfo() As String
		<Column("CloseInfo")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CloseInfo() As String
		<Column("RateInfo")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RateInfo() As String
		<Column("MiscInfo")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MiscInfo() As String
		<Column("InHouseComments")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InHouseComments() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
