Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVFusionHutput

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NCCTVFusionUniverseID
            HutputDatetime
            Household
            Children2to5
            Children6to11
            Males12to17
            Males18to20
            Males21to24
            Males25to34
            Males35to49
            Males50to54
            Males55to64
            Males65Plus
            Females12to17
            Females18to20
            Females21to24
            Females25to34
            Females35to49
            Females50to54
            Females55to64
            Females65Plus
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NCCTVFusionUniverseID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HutputDatetime() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Household() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Children2to5() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Children6to11() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males12to17() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males18to20() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males21to24() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males25to34() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males35to49() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males50to54() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males55to64() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males65Plus() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females12to17() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females18to20() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females21to24() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females25to34() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females35to49() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females50to54() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females55to64() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females65Plus() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVFusionHutput As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionHutput)

            Me.ID = NCCTVFusionHutput.ID
            Me.NCCTVFusionUniverseID = NCCTVFusionHutput.NCCTVFusionUniverseID
            Me.HutputDatetime = NCCTVFusionHutput.HutputDatetime
            Me.Household = NCCTVFusionHutput.Household
            Me.Children2to5 = NCCTVFusionHutput.Children2to5
            Me.Children6to11 = NCCTVFusionHutput.Children6to11
            Me.Males12to17 = NCCTVFusionHutput.Males12to17
            Me.Males18to20 = NCCTVFusionHutput.Males18to20
            Me.Males21to24 = NCCTVFusionHutput.Males21to24
            Me.Males25to34 = NCCTVFusionHutput.Males25to34
            Me.Males35to49 = NCCTVFusionHutput.Males35to49
            Me.Males50to54 = NCCTVFusionHutput.Males50to54
            Me.Males55to64 = NCCTVFusionHutput.Males55to64
            Me.Males65Plus = NCCTVFusionHutput.Males65Plus
            Me.Females12to17 = NCCTVFusionHutput.Females12to17
            Me.Females18to20 = NCCTVFusionHutput.Females18to20
            Me.Females21to24 = NCCTVFusionHutput.Females21to24
            Me.Females25to34 = NCCTVFusionHutput.Females25to34
            Me.Females35to49 = NCCTVFusionHutput.Females35to49
            Me.Females50to54 = NCCTVFusionHutput.Females50to54
            Me.Females55to64 = NCCTVFusionHutput.Females55to64
            Me.Females65Plus = NCCTVFusionHutput.Females65Plus

        End Sub

#End Region

    End Class

End Namespace
