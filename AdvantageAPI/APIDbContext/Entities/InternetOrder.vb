<Table("INTERNET_HEADER")>
Public Class InternetOrder

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <Key>
    <Required>
    <Column("ORDER_NBR")>
    Public Property OrderNumber() As Integer
    <MaxLength(40)>
    <Column("ORDER_DESC", TypeName:="varchar")>
    Public Property Description() As String
    <Required>
    <MaxLength(6)>
    <Column("CL_CODE", TypeName:="varchar")>
    Public Property ClientCode() As String
    <Required>
    <MaxLength(6)>
    <Column("DIV_CODE", TypeName:="varchar")>
    Public Property DivisionCode() As String
    <Required>
    <MaxLength(6)>
    <Column("PRD_CODE", TypeName:="varchar")>
    Public Property ProductCode() As String
    <MaxLength(4)>
    <Column("OFFICE_CODE", TypeName:="varchar")>
    Public Property OfficeCode() As String
    <MaxLength(6)>
    <Column("CMP_CODE", TypeName:="varchar")>
    Public Property CampaignCode() As String
    <MaxLength(6)>
    <Column("MEDIA_TYPE", TypeName:="varchar")>
    Public Property MediaTypeCode() As String
    <MaxLength(6)>
    <Column("VN_CODE", TypeName:="varchar")>
    Public Property VendorCode() As String
    <MaxLength(4)>
    <Column("VR_CODE", TypeName:="varchar")>
    Public Property VendorRepCode1() As String
    <MaxLength(4)>
    <Column("VR_CODE2", TypeName:="varchar")>
    Public Property VendorRepCode2() As String
    <MaxLength(25)>
    <Column("CLIENT_PO", TypeName:="varchar")>
    Public Property ClientPO() As String
    <MaxLength(60)>
    <Column("CLIENT_REF", TypeName:="varchar")>
    Public Property ClientReference() As String
    <MaxLength(3)>
    <Column("STATUS", TypeName:="varchar")>
    Public Property Status() As String
    <Column("ORDER_DATE")>
    Public Property OrderDate() As Nullable(Of Date)
    <MaxLength(40)>
    <Column("BUYER", TypeName:="varchar")>
    Public Property Buyer() As String
    <Column("ORDER_COMMENT", TypeName:="varchar(MAX)")>
    Public Property OrderComment() As String
    <Column("HOUSE_COMMENT")>
    Public Property HouseComment() As String
    <Column("PUB")>
    Public Property MailToVender() As Nullable(Of Short)
    <Column("REP1")>
    Public Property MailToVenderRep1() As Nullable(Of Short)
    <Column("REP2")>
    Public Property MailToVenderRep2() As Nullable(Of Short)
    <MaxLength(6)>
    <Column("BILL_COOP_CODE", TypeName:="varchar")>
    Public Property BillingCoopCode() As String
    <Column("ORD_PROCESS_CONTRL")>
    Public Property OrderProcessControl() As Nullable(Of Short)
    <MaxLength(10)>
    <Column("MARKET_CODE", TypeName:="varchar")>
    Public Property MarketCode() As String
    <MaxLength(2)>
    <Column("UNITS", TypeName:="varchar")>
    Public Property Units() As String
    <Column("NET_GROSS")>
    Public Property NetGross() As Nullable(Of Short)
    <Column("CREATE_DATE")>
    Public Property CreatedDate() As Nullable(Of Date)
    <MaxLength(100)>
    <Column("USER_ID", TypeName:="varchar")>
    Public Property CreatedByUserCode() As String
    <Column("CANCELLED")>
    Public Property Cancelled() As Nullable(Of Short)
    <MaxLength(100)>
    <Column("CANCELLED_BY", TypeName:="varchar")>
    Public Property CancelledByUserCode() As String
    <Column("CANCELLED_DATE")>
    Public Property CancelledDate() As Nullable(Of Date)
    <MaxLength(100)>
    <Column("MODIFIED_BY", TypeName:="varchar")>
    Public Property ModifiedByUserCode() As String
    <Column("MODIFIED_DATE")>
    Public Property ModifiedDate() As Nullable(Of Date)
    <Column("MODIFIED_COMMENTS")>
    Public Property ModifiedComment() As String
    <Column("REVISED_FLAG")>
    Public Property Revised() As Nullable(Of Short)
    <Column("LINK_ID")>
    Public Property LinkID() As Nullable(Of Integer)
    <Column("RECONCILE_FLAG")>
    Public Property Reconile() As Nullable(Of Short)
    <Column("CMP_IDENTIFIER")>
    Public Property CampaignID() As Nullable(Of Integer)
    <Column("PRINTED")>
    Public Property Printed() As Nullable(Of Short)
    <Column("START_DATE")>
    Public Property StartDate() As Nullable(Of Date)
    <Column("END_DATE")>
    Public Property EndDate() As Nullable(Of Date)
    <Column("ORDER_ACCEPTED")>
    Public Property OrderAccepted() As Nullable(Of Short)
    <MaxLength(6)>
    <Column("FISCAL_PERIOD_CODE", TypeName:="varchar")>
    Public Property PostPeriodCode() As String
    <MaxLength(1)>
    <Column("LOCKED", TypeName:="varchar")>
    Public Property IsLocked() As String
    <MaxLength(100)>
    <Column("LOCKED_BY", TypeName:="varchar")>
    Public Property LockedByUserCode() As String
    <Column("BCC_ID")>
    Public Property BCCUserID() As Nullable(Of Integer)
    <Column("BUYER_EMP_CODE", TypeName:="varchar")>
    <MaxLength(6)>
    Public Property BuyerEmployeeCode() As String

#End Region

#Region " Methods "

    Public Overrides Function ToString() As String

        ToString = Me.OrderNumber

    End Function

#End Region

End Class

