Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class ClientNielsenRadioCountyPeriod

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            NielsenRadioCountyPeriodID
            State
            Year
            NielsenRadioMarketNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioCountyPeriodID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property State() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioMarketNumber() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioCountyPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyPeriod)

            Me.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriod.ID
            Me.State = NielsenRadioCountyPeriod.State
            Me.Year = NielsenRadioCountyPeriod.Year
            Me.NielsenRadioMarketNumber = NielsenRadioCountyPeriod.NielsenRadioMarketNumber

        End Sub

#End Region

    End Class

End Namespace

