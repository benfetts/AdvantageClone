Namespace DTO.Media.National

    Public Class Universe
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Year
            IsHispanic
            MarketBreakID
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

        Public Property Year() As Integer
        Public Property IsHispanic() As Boolean
        Public Property MarketBreakID() As Integer
        Public Property Household As Integer
        Public Property Females2to5 As Integer
        Public Property Females6to8 As Integer
        Public Property Females9to11 As Integer
        Public Property Females12to14 As Integer
        Public Property Females15to17 As Integer
        Public Property Females18to20 As Integer
        Public Property Females21to24 As Integer
        Public Property Females25to29 As Integer
        Public Property Females30to34 As Integer
        Public Property Females35to39 As Integer
        Public Property Females40to44 As Integer
        Public Property Females45to49 As Integer
        Public Property Females50to54 As Integer
        Public Property Females55to64 As Integer
        Public Property Females65Plus As Integer
        Public Property Males2to5 As Integer
        Public Property Males6to8 As Integer
        Public Property Males9to11 As Integer
        Public Property Males12to14 As Integer
        Public Property Males15to17 As Integer
        Public Property Males18to20 As Integer
        Public Property Males21to24 As Integer
        Public Property Males25to29 As Integer
        Public Property Males30to34 As Integer
        Public Property Males35to39 As Integer
        Public Property Males40to44 As Integer
        Public Property Males45to49 As Integer
        Public Property Males50to54 As Integer
        Public Property Males55to64 As Integer
        Public Property Males65Plus As Integer
        Public Property WorkingWomen18to20 As Integer
        Public Property WorkingWomen21to24 As Integer
        Public Property WorkingWomen25to34 As Integer
        Public Property WorkingWomen35to44 As Integer
        Public Property WorkingWomen45to49 As Integer
        Public Property WorkingWomen50to54 As Integer
        Public Property WorkingWomen55Plus As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NationalUniverse As AdvantageFramework.Database.Entities.NationalUniverse)

            Me.Year = NationalUniverse.Year
            Me.IsHispanic = NationalUniverse.IsHispanic
            Me.MarketBreakID = NationalUniverse.MarketBreakID
            Me.Household = NationalUniverse.Household
            Me.Females2to5 = NationalUniverse.Females2to5
            Me.Females6to8 = NationalUniverse.Females6to8
            Me.Females9to11 = NationalUniverse.Females9to11
            Me.Females12to14 = NationalUniverse.Females12to14
            Me.Females15to17 = NationalUniverse.Females15to17
            Me.Females18to20 = NationalUniverse.Females18to20
            Me.Females21to24 = NationalUniverse.Females21to24
            Me.Females25to29 = NationalUniverse.Females25to29
            Me.Females30to34 = NationalUniverse.Females30to34
            Me.Females35to39 = NationalUniverse.Females35to39
            Me.Females40to44 = NationalUniverse.Females40to44
            Me.Females45to49 = NationalUniverse.Females45to49
            Me.Females50to54 = NationalUniverse.Females50to54
            Me.Females55to64 = NationalUniverse.Females55to64
            Me.Females65Plus = NationalUniverse.Females65Plus
            Me.Males2to5 = NationalUniverse.Males2to5
            Me.Males6to8 = NationalUniverse.Males6to8
            Me.Males9to11 = NationalUniverse.Males9to11
            Me.Males12to14 = NationalUniverse.Males12to14
            Me.Males15to17 = NationalUniverse.Males15to17
            Me.Males18to20 = NationalUniverse.Males18to20
            Me.Males21to24 = NationalUniverse.Males21to24
            Me.Males25to29 = NationalUniverse.Males25to29
            Me.Males30to34 = NationalUniverse.Males30to34
            Me.Males35to39 = NationalUniverse.Males35to39
            Me.Males40to44 = NationalUniverse.Males40to44
            Me.Males45to49 = NationalUniverse.Males45to49
            Me.Males50to54 = NationalUniverse.Males50to54
            Me.Males55to64 = NationalUniverse.Males55to64
            Me.Males65Plus = NationalUniverse.Males65Plus
            Me.WorkingWomen18to20 = NationalUniverse.WorkingWomen18to20
            Me.WorkingWomen21to24 = NationalUniverse.WorkingWomen21to24
            Me.WorkingWomen25to34 = NationalUniverse.WorkingWomen25to34
            Me.WorkingWomen35to44 = NationalUniverse.WorkingWomen35to44
            Me.WorkingWomen45to49 = NationalUniverse.WorkingWomen45to49
            Me.WorkingWomen50to54 = NationalUniverse.WorkingWomen50to54
            Me.WorkingWomen55Plus = NationalUniverse.WorkingWomen55Plus

        End Sub
        Public Sub New(NationalUniverse As AdvantageFramework.National.Database.Entities.NationalUniverse)

            Me.Year = NationalUniverse.Year
            Me.IsHispanic = NationalUniverse.IsHispanic
            Me.MarketBreakID = NationalUniverse.MarketBreakID
            Me.Household = NationalUniverse.Household
            Me.Females2to5 = NationalUniverse.Females2to5
            Me.Females6to8 = NationalUniverse.Females6to8
            Me.Females9to11 = NationalUniverse.Females9to11
            Me.Females12to14 = NationalUniverse.Females12to14
            Me.Females15to17 = NationalUniverse.Females15to17
            Me.Females18to20 = NationalUniverse.Females18to20
            Me.Females21to24 = NationalUniverse.Females21to24
            Me.Females25to29 = NationalUniverse.Females25to29
            Me.Females30to34 = NationalUniverse.Females30to34
            Me.Females35to39 = NationalUniverse.Females35to39
            Me.Females40to44 = NationalUniverse.Females40to44
            Me.Females45to49 = NationalUniverse.Females45to49
            Me.Females50to54 = NationalUniverse.Females50to54
            Me.Females55to64 = NationalUniverse.Females55to64
            Me.Females65Plus = NationalUniverse.Females65Plus
            Me.Males2to5 = NationalUniverse.Males2to5
            Me.Males6to8 = NationalUniverse.Males6to8
            Me.Males9to11 = NationalUniverse.Males9to11
            Me.Males12to14 = NationalUniverse.Males12to14
            Me.Males15to17 = NationalUniverse.Males15to17
            Me.Males18to20 = NationalUniverse.Males18to20
            Me.Males21to24 = NationalUniverse.Males21to24
            Me.Males25to29 = NationalUniverse.Males25to29
            Me.Males30to34 = NationalUniverse.Males30to34
            Me.Males35to39 = NationalUniverse.Males35to39
            Me.Males40to44 = NationalUniverse.Males40to44
            Me.Males45to49 = NationalUniverse.Males45to49
            Me.Males50to54 = NationalUniverse.Males50to54
            Me.Males55to64 = NationalUniverse.Males55to64
            Me.Males65Plus = NationalUniverse.Males65Plus
            Me.WorkingWomen18to20 = NationalUniverse.WorkingWomen18to20
            Me.WorkingWomen21to24 = NationalUniverse.WorkingWomen21to24
            Me.WorkingWomen25to34 = NationalUniverse.WorkingWomen25to34
            Me.WorkingWomen35to44 = NationalUniverse.WorkingWomen35to44
            Me.WorkingWomen45to49 = NationalUniverse.WorkingWomen45to49
            Me.WorkingWomen50to54 = NationalUniverse.WorkingWomen50to54
            Me.WorkingWomen55Plus = NationalUniverse.WorkingWomen55Plus

        End Sub

#End Region

    End Class

End Namespace
