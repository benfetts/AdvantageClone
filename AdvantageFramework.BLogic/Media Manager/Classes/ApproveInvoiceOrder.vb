Namespace MediaManager.Classes

    <Serializable()>
    Public Class ApproveInvoiceOrder
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaType
            ClientCode
            DivisionCode
            ProductCode
            VendorCode
            VendorName
            Vendor
            OrderNumber
            OrderDescription
            OrderQtySpots
            GrossOrderAmount
            NetOrderAmount
            InvoiceQtySpots
            GrossInvoiceAmount
            NetInvoiceAmount
            GrossBalance
            NetBalance
            QtySpotVariance
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Media" & vbCrLf & "Type")>
        Public Property MediaType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client" & vbCrLf & "Code")>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division" & vbCrLf & "Code")>
        Public Property DivisionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product" & vbCrLf & "Code")>
        Public Property ProductCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property Vendor() As String
            Get
                Vendor = Me.VendorCode & " - " & Me.VendorName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public Property OrderNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order" & vbCrLf & "Description")>
        Public Property OrderDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0", CustomColumnCaption:="Order" & vbCrLf & "Qty/Spots")>
        Public Property OrderQtySpots As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Gross Order" & vbCrLf & "Amount")>
        Public Property GrossOrderAmount As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Net Order" & vbCrLf & "Amount")>
        Public Property NetOrderAmount As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0", CustomColumnCaption:="Invoice" & vbCrLf & "Qty/Spots")>
        Public Property InvoiceQtySpots As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Gross Invoice" & vbCrLf & "Amount")>
        Public Property GrossInvoiceAmount As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Net Invoice" & vbCrLf & "Amount")>
        Public Property NetInvoiceAmount As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Gross" & vbCrLf & "Balance")>
        Public ReadOnly Property GrossBalance As Decimal
            Get
                GrossBalance = Me.GrossOrderAmount - Me.GrossInvoiceAmount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Net" & vbCrLf & "Balance")>
        Public ReadOnly Property NetBalance As Decimal
            Get
                NetBalance = Me.NetOrderAmount - Me.NetInvoiceAmount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0", CustomColumnCaption:="Qty/Spot" & vbCrLf & "Variance")>
        Public ReadOnly Property QtySpotVariance As Integer
            Get
                QtySpotVariance = Me.InvoiceQtySpots.GetValueOrDefault(0) - Me.OrderQtySpots.GetValueOrDefault(0)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace