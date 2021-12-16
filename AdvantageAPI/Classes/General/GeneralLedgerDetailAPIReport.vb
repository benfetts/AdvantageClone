<DataContract>
Public Class GeneralLedgerDetailAPIReport

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

    'Force Update
    <DataMember>
    Public Property TransactionID As Nullable(Of Integer)
    <DataMember>
    Public Property TransSeq As Nullable(Of Short)
    <DataMember>
    Public Property AccountCode As String
    <DataMember>
    Public Property AccountDescription As String
    <DataMember>
    Public Property Amount As Nullable(Of Double)
    <DataMember>
    Public Property AbsoluteAmount As Nullable(Of Double)
    <DataMember>
    Public Property DebitOrCredit As String
    <DataMember>
    Public Property Remark As String
    <DataMember>
    Public Property PostPeriodCode As String
    <DataMember>
    Public Property PostingPeriodEndingDate As Nullable(Of Date)
    <DataMember>
    Public Property PostingPeriodEndingDateStr As String
    <DataMember>
    Public Property EntryDate As Nullable(Of Date)
    <DataMember>
    Public Property EntryDateStr As String
    <DataMember>
    Public Property PostedToSummary As Nullable(Of Date)
    <DataMember>
    Public Property PostedToSummaryStr As String
    <DataMember>
    Public Property ClientCode As String
    <DataMember>
    Public Property ClientName As String
    <DataMember>
    Public Property DivisionCode As String
    <DataMember>
    Public Property DivisionName As String
    <DataMember>
    Public Property ProductCode As String
    <DataMember>
    Public Property ProductName As String
    <DataMember>
    Public Property Source As String
    <DataMember>
    Public Property OfficeSegment As String
    <DataMember>
    Public Property BaseAccount As String
    <DataMember>
    Public Property DepartmentSegment As String
    <DataMember>
    Public Property OtherSegment As String
    <DataMember>
    Public Property MappedAccount As String
    <DataMember>
    Public Property TargetAccount As String
    <DataMember>
    Public Property UserID As String
    <DataMember>
    Public Property ProductUserDefinedField1 As String
    <DataMember>
    Public Property ProductUserDefinedField2 As String
    <DataMember>
    Public Property ProductUserDefinedField3 As String
    <DataMember>
    Public Property ProductUserDefinedField4 As String

#End Region

#Region " Methods "

    Public Sub New()



    End Sub
    Public Overrides Function ToString() As String

        ToString = Me.TransactionID.ToString

    End Function

#End Region

End Class


