Namespace Reporting.Database.Classes

    <Serializable>
    Public Class DeferredSalesVsOpenAR

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            ARInvoiceAmount
            DeferredSales
            ClientReceiptsTotal
            ARBalance

        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "


        <MaxLength(4)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        Public Property OfficeName() As String
        <MaxLength(6)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        Public Property ClientName() As String
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        Public Property DivisionName() As String
        <MaxLength(6)>
        Public Property ProductCode As String
        <MaxLength(40)>
        Public Property ProductName As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARInvoiceAmount As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DeferredSales As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientReceiptsTotal As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARBalance As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OfficeCode.ToString

        End Function

#End Region

    End Class

End Namespace
