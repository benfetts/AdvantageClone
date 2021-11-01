Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class ClientNielsenRadioPeriod

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            NielsenRadioPeriodID
            NielsenRadioMarketNumber
            Year
            Month
            Source
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioPeriodID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Month() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Source() As AdvantageFramework.Nielsen.Database.Entities.RadioSource

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod)

            Me.NielsenRadioPeriodID = NielsenRadioPeriod.ID
            Me.NielsenRadioMarketNumber = NielsenRadioPeriod.NielsenRadioMarketNumber
            Me.Year = Mid(NielsenRadioPeriod.ShortName, 3, 4)
            Me.Month = Mid(NielsenRadioPeriod.ShortName, 1, 2)
            Me.Source = NielsenRadioPeriod.Source

        End Sub

#End Region

    End Class

End Namespace

