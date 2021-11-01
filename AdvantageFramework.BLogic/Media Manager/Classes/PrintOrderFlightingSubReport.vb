Namespace MediaManager.Classes

    <Serializable()>
    Public Class InternetOrderFlightingSubReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            StartDate
            EndDate
            Units
            Rate
            Cost
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDate As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndDate As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Units As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Rate As Decimal
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Cost As Decimal

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
