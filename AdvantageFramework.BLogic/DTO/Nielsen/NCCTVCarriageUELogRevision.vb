Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVCarriageUELogRevision

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OldNCCTVCarriageUELogID
            NewNCCTVCarriageUELogID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OldNCCTVCarriageUELogID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewNCCTVCarriageUELogID() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVCarriageUELogRevision As AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUELogRevision)

            Me.ID = NCCTVCarriageUELogRevision.ID
            Me.OldNCCTVCarriageUELogID = NCCTVCarriageUELogRevision.OldNCCTVCarriageUELogID
            Me.NewNCCTVCarriageUELogID = NCCTVCarriageUELogRevision.NewNCCTVCarriageUELogID

        End Sub

#End Region

    End Class

End Namespace
