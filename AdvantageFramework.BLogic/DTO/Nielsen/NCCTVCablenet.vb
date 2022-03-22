Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVCablenet

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NetworkCode
            NetworkName
            StationCode
            ComscoreStationCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetworkCode() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetworkName() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StationCode() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComscoreStationCode() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVCablenet As AdvantageFramework.Nielsen.Database.Entities.NCCTVCablenet)

            Me.ID = NCCTVCablenet.ID
            Me.NetworkCode = NCCTVCablenet.NetworkCode
            Me.NetworkName = NCCTVCablenet.NetworkName
            Me.StationCode = NCCTVCablenet.StationCode
            Me.ComscoreStationCode = NCCTVCablenet.ComscoreStationCode

        End Sub

#End Region

    End Class

End Namespace
