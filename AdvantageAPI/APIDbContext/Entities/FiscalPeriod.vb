<Table("FISCAL_PERIOD")>
Public Class FiscalPeriod

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
    <Column("FISCAL_PERIOD_CODE", TypeName:="varchar")>
    Public Property Code() As String
    <MaxLength(30)>
    <Column("FISCAL_PERIOD_DESC", TypeName:="varchar")>
    Public Property Description() As String
    <Column("INACTIVE_FLAG")>
    Public Property IsInactive() As Nullable(Of Short)

#End Region

#Region " Methods "

    Public Overrides Function ToString() As String

        ToString = Me.Code

    End Function

#End Region

End Class
