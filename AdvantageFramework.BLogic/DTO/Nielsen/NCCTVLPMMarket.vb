Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVLPMMarket

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            NielsenMarketNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenMarketNumber() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVLPMMarket As AdvantageFramework.Nielsen.Database.Entities.NCCTVLPMMarket)

            Me.NielsenMarketNumber = NCCTVLPMMarket.NielsenMarketNumber

        End Sub

#End Region

    End Class

End Namespace
