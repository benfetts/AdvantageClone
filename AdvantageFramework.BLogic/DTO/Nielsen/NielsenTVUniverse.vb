Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVUniverse

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            Year
            Month
            IsMeteredMarket
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
            SurveyStartDate
            SurveyEndDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Month() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsMeteredMarket() As Boolean
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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SurveyStartDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SurveyEndDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReportingService() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Exclusion() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Ethnicity() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenTVUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse)

            Me.ID = NielsenTVUniverse.ID
            Me.NielsenMarketNumber = NielsenTVUniverse.NielsenMarketNumber
            Me.Year = NielsenTVUniverse.Year
            Me.Month = NielsenTVUniverse.Month
            Me.IsMeteredMarket = NielsenTVUniverse.IsMeteredMarket
            Me.MetroAHousehold = NielsenTVUniverse.MetroAHousehold
            Me.MetroBHousehold = NielsenTVUniverse.MetroBHousehold
            Me.Household = NielsenTVUniverse.Household
            Me.Children2to5 = NielsenTVUniverse.Children2to5
            Me.Children6to11 = NielsenTVUniverse.Children6to11
            Me.Males12to14 = NielsenTVUniverse.Males12to14
            Me.Males15to17 = NielsenTVUniverse.Males15to17
            Me.Males18to20 = NielsenTVUniverse.Males18to20
            Me.Males21to24 = NielsenTVUniverse.Males21to24
            Me.Males25to34 = NielsenTVUniverse.Males25to34
            Me.Males35to49 = NielsenTVUniverse.Males35to49
            Me.Males50to54 = NielsenTVUniverse.Males50to54
            Me.Males55to64 = NielsenTVUniverse.Males55to64
            Me.Males65Plus = NielsenTVUniverse.Males65Plus
            Me.Females12to14 = NielsenTVUniverse.Females12to14
            Me.Females15to17 = NielsenTVUniverse.Females15to17
            Me.Females18to20 = NielsenTVUniverse.Females18to20
            Me.Females21to24 = NielsenTVUniverse.Females21to24
            Me.Females25to34 = NielsenTVUniverse.Females25to34
            Me.Females35to49 = NielsenTVUniverse.Females35to49
            Me.Females50to54 = NielsenTVUniverse.Females50to54
            Me.Females55to64 = NielsenTVUniverse.Females55to64
            Me.Females65Plus = NielsenTVUniverse.Females65Plus
            Me.WorkingWomen = NielsenTVUniverse.WorkingWomen
            Me.SurveyStartDate = NielsenTVUniverse.SurveyStartDate
            Me.SurveyEndDate = NielsenTVUniverse.SurveyEndDate
            Me.ReportingService = NielsenTVUniverse.ReportingService
            Me.Exclusion = NielsenTVUniverse.Exclusion
            Me.Ethnicity = NielsenTVUniverse.Ethnicity

        End Sub
        Public Sub SaveToEntity(NielsenTVUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse)

            Me.ID = NielsenTVUniverse.ID
            Me.NielsenMarketNumber = NielsenTVUniverse.NielsenMarketNumber
            Me.Year = NielsenTVUniverse.Year
            Me.Month = NielsenTVUniverse.Month
            Me.IsMeteredMarket = NielsenTVUniverse.IsMeteredMarket
            Me.MetroAHousehold = NielsenTVUniverse.MetroAHousehold
            Me.MetroBHousehold = NielsenTVUniverse.MetroBHousehold
            Me.Household = NielsenTVUniverse.Household
            Me.Children2to5 = NielsenTVUniverse.Children2to5
            Me.Children6to11 = NielsenTVUniverse.Children6to11
            Me.Males12to14 = NielsenTVUniverse.Males12to14
            Me.Males15to17 = NielsenTVUniverse.Males15to17
            Me.Males18to20 = NielsenTVUniverse.Males18to20
            Me.Males21to24 = NielsenTVUniverse.Males21to24
            Me.Males25to34 = NielsenTVUniverse.Males25to34
            Me.Males35to49 = NielsenTVUniverse.Males35to49
            Me.Males50to54 = NielsenTVUniverse.Males50to54
            Me.Males55to64 = NielsenTVUniverse.Males55to64
            Me.Males65Plus = NielsenTVUniverse.Males65Plus
            Me.Females12to14 = NielsenTVUniverse.Females12to14
            Me.Females15to17 = NielsenTVUniverse.Females15to17
            Me.Females18to20 = NielsenTVUniverse.Females18to20
            Me.Females21to24 = NielsenTVUniverse.Females21to24
            Me.Females25to34 = NielsenTVUniverse.Females25to34
            Me.Females35to49 = NielsenTVUniverse.Females35to49
            Me.Females50to54 = NielsenTVUniverse.Females50to54
            Me.Females55to64 = NielsenTVUniverse.Females55to64
            Me.Females65Plus = NielsenTVUniverse.Females65Plus
            Me.WorkingWomen = NielsenTVUniverse.WorkingWomen
            Me.SurveyStartDate = NielsenTVUniverse.SurveyStartDate
            Me.SurveyEndDate = NielsenTVUniverse.SurveyEndDate
            Me.ReportingService = NielsenTVUniverse.ReportingService
            Me.Exclusion = NielsenTVUniverse.Exclusion
            Me.Ethnicity = NielsenTVUniverse.Ethnicity

        End Sub

#End Region

    End Class

End Namespace
