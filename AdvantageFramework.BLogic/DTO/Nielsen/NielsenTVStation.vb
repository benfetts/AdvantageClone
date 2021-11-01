Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVStation

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            StationCode
            CallLetters
            SourceType
            ParentPlusIndicator
            IsParent
            IsSatellite
            Affiliation
            CableName
            ChannelNum
            DistributorGroup
            StationType
            ReportabilityStatus
            HomeMarketNumber
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
        Public Property SourceType() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ParentPlusIndicator() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsParent() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsSatellite() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Affiliation() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CableName() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ChannelNum() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DistributorGroup() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StationType() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReportabilityStatus() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HomeMarketNumber() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenTVStation As AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)

            Me.ID = NielsenTVStation.ID
            Me.NielsenMarketNumber = NielsenTVStation.NielsenMarketNumber
            Me.StationCode = NielsenTVStation.StationCode
            Me.CallLetters = NielsenTVStation.CallLetters
            Me.SourceType = NielsenTVStation.SourceType
            Me.ParentPlusIndicator = NielsenTVStation.ParentPlusIndicator
            Me.IsParent = NielsenTVStation.IsParent
            Me.IsSatellite = NielsenTVStation.IsSatellite
            Me.Affiliation = NielsenTVStation.Affiliation
            Me.CableName = NielsenTVStation.CableName
            Me.ChannelNum = NielsenTVStation.ChannelNum
            Me.DistributorGroup = NielsenTVStation.DistributorGroup
            Me.StationType = NielsenTVStation.StationType
            Me.ReportabilityStatus = NielsenTVStation.ReportabilityStatus
            Me.HomeMarketNumber = NielsenTVStation.HomeMarketNumber

        End Sub

#End Region

    End Class

End Namespace
