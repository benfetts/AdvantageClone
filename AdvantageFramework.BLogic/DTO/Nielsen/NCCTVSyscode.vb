Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVSyscode

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Syscode
            NCCTVMVPDID
            NielsenMarketNumber
            SystemName
            SystemType
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Syscode() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NCCTVMVPDID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SystemName() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SystemType() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVSyscode As AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode)

            Me.ID = NCCTVSyscode.ID
            Me.Syscode = NCCTVSyscode.Syscode
            Me.NCCTVMVPDID = NCCTVSyscode.NCCTVMVPDID
            Me.NielsenMarketNumber = NCCTVSyscode.NielsenMarketNumber
            Me.SystemName = NCCTVSyscode.SystemName
            Me.SystemType = NCCTVSyscode.SystemType

        End Sub

#End Region

    End Class

End Namespace
