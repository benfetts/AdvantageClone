Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVCumeDaypartImpression

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Ethnicity
            StationCode
            NielsenTVCumeBookID
            NielsenTVDaypartID
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
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Ethnicity() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StationCode() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenTVCumeBookID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenTVDaypartID() As Integer
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
        Public Sub New(NielsenTVCumeDaypartImpression As AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeDaypartImpression)

            Me.ID = NielsenTVCumeDaypartImpression.ID

            Me.Ethnicity = NielsenTVCumeDaypartImpression.Ethnicity
            Me.StationCode = NielsenTVCumeDaypartImpression.StationCode
            Me.NielsenTVCumeBookID = NielsenTVCumeDaypartImpression.NielsenTVCumeBookID
            Me.NielsenTVDaypartID = NielsenTVCumeDaypartImpression.NielsenTVDaypartID
            Me.MetroAHousehold = NielsenTVCumeDaypartImpression.MetroAHousehold
            Me.MetroBHousehold = NielsenTVCumeDaypartImpression.MetroBHousehold
            Me.Household = NielsenTVCumeDaypartImpression.Household
            Me.Children2to5 = NielsenTVCumeDaypartImpression.Children2to5
            Me.Children6to11 = NielsenTVCumeDaypartImpression.Children6to11
            Me.Males12to14 = NielsenTVCumeDaypartImpression.Males12to14
            Me.Males15to17 = NielsenTVCumeDaypartImpression.Males15to17
            Me.Males18to20 = NielsenTVCumeDaypartImpression.Males18to20
            Me.Males21to24 = NielsenTVCumeDaypartImpression.Males21to24
            Me.Males25to34 = NielsenTVCumeDaypartImpression.Males25to34
            Me.Males35to49 = NielsenTVCumeDaypartImpression.Males35to49
            Me.Males50to54 = NielsenTVCumeDaypartImpression.Males50to54
            Me.Males55to64 = NielsenTVCumeDaypartImpression.Males55to64
            Me.Males65Plus = NielsenTVCumeDaypartImpression.Males65Plus
            Me.Females12to14 = NielsenTVCumeDaypartImpression.Females12to14
            Me.Females15to17 = NielsenTVCumeDaypartImpression.Females15to17
            Me.Females18to20 = NielsenTVCumeDaypartImpression.Females18to20
            Me.Females21to24 = NielsenTVCumeDaypartImpression.Females21to24
            Me.Females25to34 = NielsenTVCumeDaypartImpression.Females25to34
            Me.Females35to49 = NielsenTVCumeDaypartImpression.Females35to49
            Me.Females50to54 = NielsenTVCumeDaypartImpression.Females50to54
            Me.Females55to64 = NielsenTVCumeDaypartImpression.Females55to64
            Me.Females65Plus = NielsenTVCumeDaypartImpression.Females65Plus
            Me.WorkingWomen = NielsenTVCumeDaypartImpression.WorkingWomen

        End Sub

#End Region

    End Class

End Namespace
