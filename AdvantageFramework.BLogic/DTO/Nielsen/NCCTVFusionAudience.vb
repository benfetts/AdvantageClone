Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVFusionAudience

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NCCTVFusionUniverseID
            StationCode
            AudienceDatetime
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
        Public Property StationCode() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AudienceDatetime() As Date
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
        Public Sub New(NCCTVFusionAudience As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionAudience)

            Me.ID = NCCTVFusionAudience.ID
            Me.NCCTVFusionUniverseID = NCCTVFusionAudience.NCCTVFusionUniverseID
            Me.StationCode = NCCTVFusionAudience.StationCode
            Me.AudienceDatetime = NCCTVFusionAudience.AudienceDatetime
            Me.Household = NCCTVFusionAudience.Household
            Me.Children2to5 = NCCTVFusionAudience.Children2to5
            Me.Children6to11 = NCCTVFusionAudience.Children6to11
            Me.Males12to17 = NCCTVFusionAudience.Males12to17
            Me.Males18to20 = NCCTVFusionAudience.Males18to20
            Me.Males21to24 = NCCTVFusionAudience.Males21to24
            Me.Males25to34 = NCCTVFusionAudience.Males25to34
            Me.Males35to49 = NCCTVFusionAudience.Males35to49
            Me.Males50to54 = NCCTVFusionAudience.Males50to54
            Me.Males55to64 = NCCTVFusionAudience.Males55to64
            Me.Males65Plus = NCCTVFusionAudience.Males65Plus
            Me.Females12to17 = NCCTVFusionAudience.Females12to17
            Me.Females18to20 = NCCTVFusionAudience.Females18to20
            Me.Females21to24 = NCCTVFusionAudience.Females21to24
            Me.Females25to34 = NCCTVFusionAudience.Females25to34
            Me.Females35to49 = NCCTVFusionAudience.Females35to49
            Me.Females50to54 = NCCTVFusionAudience.Females50to54
            Me.Females55to64 = NCCTVFusionAudience.Females55to64
            Me.Females65Plus = NCCTVFusionAudience.Females65Plus

        End Sub

#End Region

    End Class

End Namespace
