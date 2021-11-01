<Table("BILLING_COOP")>
Public Class BillingCoop

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <Key>
    <Required>
    <MaxLength(6)>
    <Column("BILL_COOP_CODE", TypeName:="varchar")>
    Public Property Code() As String
    <MaxLength(30)>
    <Column("BILL_COOP_DESC", TypeName:="varchar")>
    Public Property Description() As String

#End Region

#Region " Methods "



#End Region

End Class
