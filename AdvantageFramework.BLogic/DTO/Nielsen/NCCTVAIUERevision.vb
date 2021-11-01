Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVAIUELogRevision

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OldNCCTVAIUELogID
            NewNCCTVAIUELogID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OldNCCTVAIUELogID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewNCCTVAIUELogID() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVAIUELogRevision As AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUELogRevision)

            Me.ID = NCCTVAIUELogRevision.ID
            Me.OldNCCTVAIUELogID = NCCTVAIUELogRevision.OldNCCTVAIUELogID
            Me.NewNCCTVAIUELogID = NCCTVAIUELogRevision.NewNCCTVAIUELogID

        End Sub

#End Region

    End Class

End Namespace
