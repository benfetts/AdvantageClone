Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVAudience

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenTVBookID
            StationCode
            AudienceDatetime
            IsExcluded
            MetroAHousehold
            MetroBHousehold
            Household
            Children2to5
            Children6to11
            Males12to14
            Males15to17
            Males18to20
            Males21to24
            Males25to34
            Males35to49
            Males50to54
            Males55to64
            Males65Plus
            Females12to14
            Females15to17
            Females18to20
            Females21to24
            Females25to34
            Females35to49
            Females50to54
            Females55to64
            Females65Plus
            WorkingWomen
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenTVBookID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StationCode() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AudienceDatetime() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsExcluded() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MetroAHousehold() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MetroBHousehold() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Household() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Children2to5() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Children6to11() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males12to14() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males15to17() As Integer
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
        Public Property Females12to14() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females15to17() As Integer
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
        Public Property WorkingWomen() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenTVAudience As AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience)

            Me.ID = NielsenTVAudience.ID
            Me.NielsenTVBookID = NielsenTVAudience.NielsenTVBookID
            Me.StationCode = NielsenTVAudience.StationCode
            Me.AudienceDatetime = NielsenTVAudience.AudienceDatetime
            Me.IsExcluded = NielsenTVAudience.IsExcluded
            Me.MetroAHousehold = NielsenTVAudience.MetroAHousehold
            Me.MetroBHousehold = NielsenTVAudience.MetroBHousehold
            Me.Household = NielsenTVAudience.Household
            Me.Children2to5 = NielsenTVAudience.Children2to5
            Me.Children6to11 = NielsenTVAudience.Children6to11
            Me.Males12to14 = NielsenTVAudience.Males12to14
            Me.Males15to17 = NielsenTVAudience.Males15to17
            Me.Males18to20 = NielsenTVAudience.Males18to20
            Me.Males21to24 = NielsenTVAudience.Males21to24
            Me.Males25to34 = NielsenTVAudience.Males25to34
            Me.Males35to49 = NielsenTVAudience.Males35to49
            Me.Males50to54 = NielsenTVAudience.Males50to54
            Me.Males55to64 = NielsenTVAudience.Males55to64
            Me.Males65Plus = NielsenTVAudience.Males65Plus
            Me.Females12to14 = NielsenTVAudience.Females12to14
            Me.Females15to17 = NielsenTVAudience.Females15to17
            Me.Females18to20 = NielsenTVAudience.Females18to20
            Me.Females21to24 = NielsenTVAudience.Females21to24
            Me.Females25to34 = NielsenTVAudience.Females25to34
            Me.Females35to49 = NielsenTVAudience.Females35to49
            Me.Females50to54 = NielsenTVAudience.Females50to54
            Me.Females55to64 = NielsenTVAudience.Females55to64
            Me.Females65Plus = NielsenTVAudience.Females65Plus
            Me.WorkingWomen = NielsenTVAudience.WorkingWomen

        End Sub

#End Region

    End Class

End Namespace
