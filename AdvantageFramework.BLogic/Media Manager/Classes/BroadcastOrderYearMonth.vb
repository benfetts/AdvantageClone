Namespace MediaManager.Classes

    <Serializable()>
    Public Class BroadcastOrderYearMonth

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            YearMonth
            MonthYear
            Spots
            TotalNet
            TotalNetWhenGrossOrder
            ShowTotalNetWhenGrossOrder
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property YearMonth() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MonthYear() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Spots() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalNet() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BroadcastMonthAbbrev() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BroadcastYear() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalNetWhenGrossOrder() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowTotalNetWhenGrossOrder() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
