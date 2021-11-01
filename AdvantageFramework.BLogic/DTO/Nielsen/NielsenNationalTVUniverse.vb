Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenNationalTVUniverse

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaMarketBreakID
            StartDate
            EndDate
            IsCorrection
            Household
            Females2to5
            Females6to8
            Females9to11
            Females12to14
            Females15to17
            Females18to20
            Females21to24
            Females25to29
            Females30to34
            Females35to39
            Females40to44
            Females45to49
            Females50to54
            Females55to64
            Females65Plus
            Males2to5
            Males6to8
            Males9to11
            Males12to14
            Males15to17
            Males18to20
            Males21to24
            Males25to29
            Males30to34
            Males35to39
            Males40to44
            Males45to49
            Males50to54
            Males55to64
            Males65Plus
            WorkingWomen18to20
            WorkingWomen21to24
            WorkingWomen25to34
            WorkingWomen35to44
            WorkingWomen45to49
            WorkingWomen50to54
            WorkingWomen55Plus
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaMarketBreakID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsCorrection() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Household() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females2to5() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females6to8() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females9to11() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females12to14() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females15to17() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females18to20() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females21to24() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females25to29() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females30to34() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females35to39() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females40to44() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females45to49() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females50to54() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females55to64() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females65Plus() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males2to5() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males6to8() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males9to11() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males12to14() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males15to17() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males18to20() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males21to24() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males25to29() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males30to34() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males35to39() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males40to44() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males45to49() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males50to54() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males55to64() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males65Plus() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen18to20() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen21to24() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen25to34() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen35to44() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen45to49() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen50to54() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen55Plus() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenNationalTVUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse)

            Me.ID = NielsenNationalTVUniverse.ID
            Me.MediaMarketBreakID = NielsenNationalTVUniverse.MediaMarketBreakID
            Me.StartDate = NielsenNationalTVUniverse.StartDate
            Me.EndDate = NielsenNationalTVUniverse.EndDate
            Me.IsCorrection = NielsenNationalTVUniverse.IsCorrection
            Me.Household = NielsenNationalTVUniverse.Household
            Me.Females2to5 = NielsenNationalTVUniverse.Females2to5
            Me.Females6to8 = NielsenNationalTVUniverse.Females6to8
            Me.Females9to11 = NielsenNationalTVUniverse.Females9to11
            Me.Females12to14 = NielsenNationalTVUniverse.Females12to14
            Me.Females15to17 = NielsenNationalTVUniverse.Females15to17
            Me.Females18to20 = NielsenNationalTVUniverse.Females18to20
            Me.Females21to24 = NielsenNationalTVUniverse.Females21to24
            Me.Females25to29 = NielsenNationalTVUniverse.Females25to29
            Me.Females30to34 = NielsenNationalTVUniverse.Females30to34
            Me.Females35to39 = NielsenNationalTVUniverse.Females35to39
            Me.Females40to44 = NielsenNationalTVUniverse.Females40to44
            Me.Females45to49 = NielsenNationalTVUniverse.Females45to49
            Me.Females50to54 = NielsenNationalTVUniverse.Females50to54
            Me.Females55to64 = NielsenNationalTVUniverse.Females55to64
            Me.Females65Plus = NielsenNationalTVUniverse.Females65Plus
            Me.Males2to5 = NielsenNationalTVUniverse.Males2to5
            Me.Males6to8 = NielsenNationalTVUniverse.Males6to8
            Me.Males9to11 = NielsenNationalTVUniverse.Males9to11
            Me.Males12to14 = NielsenNationalTVUniverse.Males12to14
            Me.Males15to17 = NielsenNationalTVUniverse.Males15to17
            Me.Males18to20 = NielsenNationalTVUniverse.Males18to20
            Me.Males21to24 = NielsenNationalTVUniverse.Males21to24
            Me.Males25to29 = NielsenNationalTVUniverse.Males25to29
            Me.Males30to34 = NielsenNationalTVUniverse.Males30to34
            Me.Males35to39 = NielsenNationalTVUniverse.Males35to39
            Me.Males40to44 = NielsenNationalTVUniverse.Males40to44
            Me.Males45to49 = NielsenNationalTVUniverse.Males45to49
            Me.Males50to54 = NielsenNationalTVUniverse.Males50to54
            Me.Males55to64 = NielsenNationalTVUniverse.Males55to64
            Me.Males65Plus = NielsenNationalTVUniverse.Males65Plus
            Me.WorkingWomen18to20 = NielsenNationalTVUniverse.WorkingWomen18to20
            Me.WorkingWomen21to24 = NielsenNationalTVUniverse.WorkingWomen21to24
            Me.WorkingWomen25to34 = NielsenNationalTVUniverse.WorkingWomen25to34
            Me.WorkingWomen35to44 = NielsenNationalTVUniverse.WorkingWomen35to44
            Me.WorkingWomen45to49 = NielsenNationalTVUniverse.WorkingWomen45to49
            Me.WorkingWomen50to54 = NielsenNationalTVUniverse.WorkingWomen50to54
            Me.WorkingWomen55Plus = NielsenNationalTVUniverse.WorkingWomen55Plus

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
