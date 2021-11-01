Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVCarriageUE

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            NCCTVCarriageUELogID
            StationCode
            HHCarriageUE
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NCCTVCarriageUELogID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StationCode() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HHCarriageUE() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVCarriageUE As AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUE)

            Me.ID = NCCTVCarriageUE.ID
            Me.NielsenMarketNumber = NCCTVCarriageUE.NielsenMarketNumber
            Me.NCCTVCarriageUELogID = NCCTVCarriageUE.NCCTVCarriageUELogID
            Me.StationCode = NCCTVCarriageUE.StationCode
            Me.HHCarriageUE = NCCTVCarriageUE.HHCarriageUE

        End Sub

#End Region

    End Class

End Namespace
