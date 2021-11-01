Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioSegmentChild

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioDaypartID
            ListeningLocation
            StationComboType
            NielsenRadioStationComboID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioDaypartID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ListeningLocation() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StationComboType() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioStationComboID() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioSegmentChild As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentChild)

            Me.ID = NielsenRadioSegmentChild.ID
            Me.NielsenRadioDaypartID = NielsenRadioSegmentChild.NielsenRadioDaypartID
            Me.ListeningLocation = NielsenRadioSegmentChild.ListeningLocation
            Me.StationComboType = NielsenRadioSegmentChild.StationComboType
            Me.NielsenRadioStationComboID = NielsenRadioSegmentChild.NielsenRadioStationComboID

        End Sub

#End Region

    End Class

End Namespace
