Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioStation

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
        Public Sub New(NielsenRadioStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)

            Me.ID = NielsenRadioStation.ID
            Me.NielsenRadioMarketNumber = NielsenRadioStation.NielsenRadioMarketNumber
            Me.ComboID = NielsenRadioStation.ComboID
            Me.Name = NielsenRadioStation.Name
            Me.CallLetters = NielsenRadioStation.CallLetters
            Me.Band = NielsenRadioStation.Band
            Me.Frequency = NielsenRadioStation.Frequency
            Me.ComboType = NielsenRadioStation.ComboType
            Me.IsSpillin = NielsenRadioStation.IsSpillin
            Me.NielsenRadioFormatCode = NielsenRadioStation.NielsenRadioFormatCode
            Me.Source = NielsenRadioStation.Source

        End Sub

#End Region

    End Class

End Namespace
