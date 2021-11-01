Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioCountyStation

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Year
            CallLetters
            Band
            CityLicense
            CountyLicense
            StateLicense
            Affiliation
            OtherAffiliations
            Frequency
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CallLetters() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Band() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityLicense() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyLicense() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateLicense() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Affiliation() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OtherAffiliations() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Frequency() As String

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(NielsenRadioCountyStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyStation)

            Me.ID = NielsenRadioCountyStation.ID
            Me.Year = NielsenRadioCountyStation.Year
            Me.CallLetters = NielsenRadioCountyStation.CallLetters
            Me.Band = NielsenRadioCountyStation.Band
            Me.CityLicense = NielsenRadioCountyStation.CityLicense
            Me.CountyLicense = NielsenRadioCountyStation.CountyLicense
            Me.StateLicense = NielsenRadioCountyStation.StateLicense
            Me.Affiliation = NielsenRadioCountyStation.Affiliation
            Me.OtherAffiliations = NielsenRadioCountyStation.OtherAffiliations
            Me.Frequency = NielsenRadioCountyStation.Frequency

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
