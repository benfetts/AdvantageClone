Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioStationHistory

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioMarketNumber
            ComboID
            Name
            CallLetters
            Band
            Frequency
            ComboType
            IsSpillin
            NielsenRadioFormatCode
            Source
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComboID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CallLetters() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Band() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Frequency() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComboType() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsSpillin() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioFormatCode() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Source() As AdvantageFramework.Nielsen.Database.Entities.RadioSource

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioStationHistory As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStationHistory)

            Me.ID = NielsenRadioStationHistory.ID
            Me.NielsenRadioMarketNumber = NielsenRadioStationHistory.NielsenRadioMarketNumber
            Me.ComboID = NielsenRadioStationHistory.ComboID
            Me.Name = NielsenRadioStationHistory.Name
            Me.CallLetters = NielsenRadioStationHistory.CallLetters
            Me.Band = NielsenRadioStationHistory.Band
            Me.Frequency = NielsenRadioStationHistory.Frequency
            Me.ComboType = NielsenRadioStationHistory.ComboType
            Me.IsSpillin = NielsenRadioStationHistory.IsSpillin
            Me.NielsenRadioFormatCode = NielsenRadioStationHistory.NielsenRadioFormatCode
            Me.Source = NielsenRadioStationHistory.Source

        End Sub

#End Region

    End Class

End Namespace
