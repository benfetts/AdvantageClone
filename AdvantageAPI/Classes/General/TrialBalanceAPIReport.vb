<DataContract>
Public Class TrialBalanceAPIReport


#Region " Constants "



#End Region

#Region " Enum "

#End Region

#Region " Variables "



#End Region

#Region " Properties "

    '<DataMember>
    'Public Property ID As Nullable(Of System.Guid)
    <DataMember>
    Public Property AccountCode As String
    <DataMember>
    Public Property AccountDescription As String
    <DataMember>
    Public Property AccountType As String
    <DataMember>
    Public Property BalanceCarryforward As Nullable(Of Decimal)
    <DataMember>
    Public Property AccountBeginningBalance As Nullable(Of Decimal)
    <DataMember>
    Public Property DebitCurrentMonth As Nullable(Of Decimal)
    <DataMember>
    Public Property CreditCurrentMonth As Nullable(Of Decimal)
    <DataMember>
    Public Property AccumulatedDebitAmount As Nullable(Of Decimal)
    <DataMember>
    Public Property AccumulatedCreditAmount As Nullable(Of Decimal)
    <DataMember>
    Public Property EndingDebitBalance As Nullable(Of Decimal)
    <DataMember>
    Public Property EndingCreditBalance As Nullable(Of Decimal)
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

#End Region

#Region " Methods "

    Public Overrides Function ToString() As String

        ToString = Me.AccountCode.ToString 'Me.ID.ToString

    End Function

#End Region

    End Class


