Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVIntab

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenTVBookID
            IntabDate
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
        Public Property IntabDate() As Date
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
        Public Sub New(NielsenTVIntab As AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab)

            Me.ID = NielsenTVIntab.ID
            Me.NielsenTVBookID = NielsenTVIntab.NielsenTVBookID
            Me.IntabDate = NielsenTVIntab.IntabDate
            Me.MetroAHousehold = NielsenTVIntab.MetroAHousehold
            Me.MetroBHousehold = NielsenTVIntab.MetroBHousehold
            Me.Household = NielsenTVIntab.Household
            Me.Children2to5 = NielsenTVIntab.Children2to5
            Me.Children6to11 = NielsenTVIntab.Children6to11
            Me.Males12to14 = NielsenTVIntab.Males12to14
            Me.Males15to17 = NielsenTVIntab.Males15to17
            Me.Males18to20 = NielsenTVIntab.Males18to20
            Me.Males21to24 = NielsenTVIntab.Males21to24
            Me.Males25to34 = NielsenTVIntab.Males25to34
            Me.Males35to49 = NielsenTVIntab.Males35to49
            Me.Males50to54 = NielsenTVIntab.Males50to54
            Me.Males55to64 = NielsenTVIntab.Males55to64
            Me.Males65Plus = NielsenTVIntab.Males65Plus
            Me.Females12to14 = NielsenTVIntab.Females12to14
            Me.Females15to17 = NielsenTVIntab.Females15to17
            Me.Females18to20 = NielsenTVIntab.Females18to20
            Me.Females21to24 = NielsenTVIntab.Females21to24
            Me.Females25to34 = NielsenTVIntab.Females25to34
            Me.Females35to49 = NielsenTVIntab.Females35to49
            Me.Females50to54 = NielsenTVIntab.Females50to54
            Me.Females55to64 = NielsenTVIntab.Females55to64
            Me.Females65Plus = NielsenTVIntab.Females65Plus
            Me.WorkingWomen = NielsenTVIntab.WorkingWomen

        End Sub

#End Region

    End Class

End Namespace
