<DataContract>
Public Class PurchaseOrder

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property PurchaseOrderNumber As Integer
    <DataMember>
    Public Property PurchaseOrderDescription As String
    <DataMember>
    Public Property PurchaseOrderDate As Nullable(Of Date)
    <DataMember>
    Public Property LineNumber As Nullable(Of Integer)
    <DataMember>
    Public Property LineDescription As String
    <DataMember>
    Public Property JobNumber As Nullable(Of Integer)
    <DataMember>
    Public Property JobComponentNumber As Nullable(Of Int16)
    <DataMember>
    Public Property FunctionCode As String
    <DataMember>
    Public Property GLAccountCode As String
    <DataMember>
    Public Property LineExtendedAmount As Nullable(Of Decimal)

#End Region

#Region " Methods "

#End Region

End Class
