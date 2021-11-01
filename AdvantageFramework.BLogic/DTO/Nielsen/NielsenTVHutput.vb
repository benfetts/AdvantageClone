Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVHutput

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenTVBookID
            HutputDatetime
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
        Public Property HutputDatetime() As Date
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
        Public Sub New(NielsenTVHutput As AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput)

            Me.ID = NielsenTVHutput.ID

            Me.NielsenTVBookID = NielsenTVHutput.NielsenTVBookID
            Me.HutputDatetime = NielsenTVHutput.HutputDatetime
            Me.MetroAHousehold = NielsenTVHutput.MetroAHousehold
            Me.MetroBHousehold = NielsenTVHutput.MetroBHousehold
            Me.Household = NielsenTVHutput.Household
            Me.Children2to5 = NielsenTVHutput.Children2to5
            Me.Children6to11 = NielsenTVHutput.Children6to11
            Me.Males12to14 = NielsenTVHutput.Males12to14
            Me.Males15to17 = NielsenTVHutput.Males15to17
            Me.Males18to20 = NielsenTVHutput.Males18to20
            Me.Males21to24 = NielsenTVHutput.Males21to24
            Me.Males25to34 = NielsenTVHutput.Males25to34
            Me.Males35to49 = NielsenTVHutput.Males35to49
            Me.Males50to54 = NielsenTVHutput.Males50to54
            Me.Males55to64 = NielsenTVHutput.Males55to64
            Me.Males65Plus = NielsenTVHutput.Males65Plus
            Me.Females12to14 = NielsenTVHutput.Females12to14
            Me.Females15to17 = NielsenTVHutput.Females15to17
            Me.Females18to20 = NielsenTVHutput.Females18to20
            Me.Females21to24 = NielsenTVHutput.Females21to24
            Me.Females25to34 = NielsenTVHutput.Females25to34
            Me.Females35to49 = NielsenTVHutput.Females35to49
            Me.Females50to54 = NielsenTVHutput.Females50to54
            Me.Females55to64 = NielsenTVHutput.Females55to64
            Me.Females65Plus = NielsenTVHutput.Females65Plus
            Me.WorkingWomen = NielsenTVHutput.WorkingWomen

        End Sub

#End Region

    End Class

End Namespace
