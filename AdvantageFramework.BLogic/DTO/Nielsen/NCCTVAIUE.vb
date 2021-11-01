Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVAIUE

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Syscode
            NCCTVAIUELogID
            StationCode
            SampleType
            HHAIUE
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Syscode() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NCCTVAIUELogID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StationCode() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SampleType() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HHAIUE() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVAIUE As AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUE)

            Me.ID = NCCTVAIUE.ID
            Me.Syscode = NCCTVAIUE.Syscode
            Me.NCCTVAIUELogID = NCCTVAIUE.NCCTVAIUELogID
            Me.StationCode = NCCTVAIUE.StationCode
            Me.SampleType = NCCTVAIUE.SampleType
            Me.HHAIUE = NCCTVAIUE.HHAIUE

        End Sub

#End Region

    End Class

End Namespace
