Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVFusionUniverseRevision

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OldNCCTVFusionUniverseID
            NewNCCTVFusionUniverseID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OldNCCTVFusionUniverseID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewNCCTVFusionUniverseID() As Int64

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVFusionUniverseRevision As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionUniverseRevision)

            Me.ID = NCCTVFusionUniverseRevision.ID
            Me.OldNCCTVFusionUniverseID = NCCTVFusionUniverseRevision.OldNCCTVFusionUniverseID
            Me.NewNCCTVFusionUniverseID = NCCTVFusionUniverseRevision.NewNCCTVFusionUniverseID

        End Sub

#End Region

    End Class

End Namespace
