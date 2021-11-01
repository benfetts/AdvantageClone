Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVFusionUniverse

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            Year
            Month
            Geo
            Stream
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
            Validated
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property ID() As Long
		<System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Month() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Geo() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Stream() As String
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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Validated() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVFusionUniverse As AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionUniverse)

            Me.ID = NCCTVFusionUniverse.ID
            Me.NielsenMarketNumber = NCCTVFusionUniverse.NielsenMarketNumber
            Me.Year = NCCTVFusionUniverse.Year
            Me.Month = NCCTVFusionUniverse.Month
            Me.Geo = NCCTVFusionUniverse.Geo
            Me.Stream = NCCTVFusionUniverse.Stream
            Me.Household = NCCTVFusionUniverse.Household
            Me.Children2to5 = NCCTVFusionUniverse.Children2to5
            Me.Children6to11 = NCCTVFusionUniverse.Children6to11
            Me.Males12to17 = NCCTVFusionUniverse.Males12to17
            Me.Males18to20 = NCCTVFusionUniverse.Males18to20
            Me.Males21to24 = NCCTVFusionUniverse.Males21to24
            Me.Males25to34 = NCCTVFusionUniverse.Males25to34
            Me.Males35to49 = NCCTVFusionUniverse.Males35to49
            Me.Males50to54 = NCCTVFusionUniverse.Males50to54
            Me.Males55to64 = NCCTVFusionUniverse.Males55to64
            Me.Males65Plus = NCCTVFusionUniverse.Males65Plus
            Me.Females12to17 = NCCTVFusionUniverse.Females12to17
            Me.Females18to20 = NCCTVFusionUniverse.Females18to20
            Me.Females21to24 = NCCTVFusionUniverse.Females21to24
            Me.Females25to34 = NCCTVFusionUniverse.Females25to34
            Me.Females35to49 = NCCTVFusionUniverse.Females35to49
            Me.Females50to54 = NCCTVFusionUniverse.Females50to54
            Me.Females55to64 = NCCTVFusionUniverse.Females55to64
            Me.Females65Plus = NCCTVFusionUniverse.Females65Plus
            Me.Validated = False

        End Sub

#End Region

    End Class

End Namespace
