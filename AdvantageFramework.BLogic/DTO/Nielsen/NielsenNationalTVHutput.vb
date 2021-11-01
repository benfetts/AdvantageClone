Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenNationalTVHutput

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaMarketBreakID
            TimeType
            Stream
            HutputDate
            HutputTime
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
        Public Property TimeType() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Stream() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HutputDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HutputTime() As Short
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
        Public Sub New(NielsenNationalTVHutput As AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput)

            Me.ID = NielsenNationalTVHutput.ID
            Me.MediaMarketBreakID = NielsenNationalTVHutput.MediaMarketBreakID
            Me.TimeType = NielsenNationalTVHutput.TimeType
            Me.Stream = NielsenNationalTVHutput.Stream
            Me.HutputDate = NielsenNationalTVHutput.HutputDate
            Me.HutputTime = NielsenNationalTVHutput.HutputTime
            Me.IsCorrection = NielsenNationalTVHutput.IsCorrection
            Me.Household = NielsenNationalTVHutput.Household
            Me.Females2to5 = NielsenNationalTVHutput.Females2to5
            Me.Females6to8 = NielsenNationalTVHutput.Females6to8
            Me.Females9to11 = NielsenNationalTVHutput.Females9to11
            Me.Females12to14 = NielsenNationalTVHutput.Females12to14
            Me.Females15to17 = NielsenNationalTVHutput.Females15to17
            Me.Females18to20 = NielsenNationalTVHutput.Females18to20
            Me.Females21to24 = NielsenNationalTVHutput.Females21to24
            Me.Females25to29 = NielsenNationalTVHutput.Females25to29
            Me.Females30to34 = NielsenNationalTVHutput.Females30to34
            Me.Females35to39 = NielsenNationalTVHutput.Females35to39
            Me.Females40to44 = NielsenNationalTVHutput.Females40to44
            Me.Females45to49 = NielsenNationalTVHutput.Females45to49
            Me.Females50to54 = NielsenNationalTVHutput.Females50to54
            Me.Females55to64 = NielsenNationalTVHutput.Females55to64
            Me.Females65Plus = NielsenNationalTVHutput.Females65Plus
            Me.Males2to5 = NielsenNationalTVHutput.Males2to5
            Me.Males6to8 = NielsenNationalTVHutput.Males6to8
            Me.Males9to11 = NielsenNationalTVHutput.Males9to11
            Me.Males12to14 = NielsenNationalTVHutput.Males12to14
            Me.Males15to17 = NielsenNationalTVHutput.Males15to17
            Me.Males18to20 = NielsenNationalTVHutput.Males18to20
            Me.Males21to24 = NielsenNationalTVHutput.Males21to24
            Me.Males25to29 = NielsenNationalTVHutput.Males25to29
            Me.Males30to34 = NielsenNationalTVHutput.Males30to34
            Me.Males35to39 = NielsenNationalTVHutput.Males35to39
            Me.Males40to44 = NielsenNationalTVHutput.Males40to44
            Me.Males45to49 = NielsenNationalTVHutput.Males45to49
            Me.Males50to54 = NielsenNationalTVHutput.Males50to54
            Me.Males55to64 = NielsenNationalTVHutput.Males55to64
            Me.Males65Plus = NielsenNationalTVHutput.Males65Plus
            Me.WorkingWomen18to20 = NielsenNationalTVHutput.WorkingWomen18to20
            Me.WorkingWomen21to24 = NielsenNationalTVHutput.WorkingWomen21to24
            Me.WorkingWomen25to34 = NielsenNationalTVHutput.WorkingWomen25to34
            Me.WorkingWomen35to44 = NielsenNationalTVHutput.WorkingWomen35to44
            Me.WorkingWomen45to49 = NielsenNationalTVHutput.WorkingWomen45to49
            Me.WorkingWomen50to54 = NielsenNationalTVHutput.WorkingWomen50to54
            Me.WorkingWomen55Plus = NielsenNationalTVHutput.WorkingWomen55Plus

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
