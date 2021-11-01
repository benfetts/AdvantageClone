Namespace Database.Classes

    <Serializable()>
    Public Class POBudgetComparison

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLAccount
            Budget
            POUsed
            Balance
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property GLAccount() As String

        Public Property Budget() As Nullable(Of Decimal)

        Public Property POUsed() As Nullable(Of Decimal)

        Public Property Balance() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.GLAccount.ToString

        End Function

#End Region

    End Class

End Namespace
