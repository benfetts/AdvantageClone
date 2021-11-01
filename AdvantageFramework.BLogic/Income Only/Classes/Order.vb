Namespace IncomeOnly.Classes

    <Serializable()>
    Public Class Order

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaType
            VendorCode
            ClientCode
            DivisionCode
            ProductCode
            OrderNumber
            LineNumber
            Description
            LinkID
            ClientPO
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Type")>
        Public Property MediaType As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor")>
        Public Property VendorCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client")>
        Public Property ClientCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division")>
        Public Property DivisionCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product")>
        Public Property ProductCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order")>
        Public Property OrderNumber As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Line")>
        Public Property LineNumber As Nullable(Of Short)
        Public Property Description As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Link ID")>
        Public Property LinkID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client PO")>
        Public Property ClientPO As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
