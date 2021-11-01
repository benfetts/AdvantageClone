Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVStationHistory

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            StationCode
            CallLetters
            ChangedOn
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StationCode() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CallLetters() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ChangedOn() As Date

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenTVStationHistory As AdvantageFramework.Nielsen.Database.Entities.NielsenTVStationHistory)

            Me.ID = NielsenTVStationHistory.ID
            Me.NielsenMarketNumber = NielsenTVStationHistory.NielsenMarketNumber
            Me.StationCode = NielsenTVStationHistory.StationCode
            Me.CallLetters = NielsenTVStationHistory.CallLetters
            Me.ChangedOn = NielsenTVStationHistory.ChangedOn

        End Sub

#End Region

    End Class

End Namespace
