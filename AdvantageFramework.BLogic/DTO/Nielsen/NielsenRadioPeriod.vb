Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioPeriod

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioReportTypeCode
            NielsenPeriodID
            NielsenRadioMarketNumber
            ShortName
            Name
            StartDate
            EndDate
            StandardCondensedIndicator
            Validated
            Copyright
            Source
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioReportTypeCode() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenPeriodID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShortName() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StandardCondensedIndicator() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Validated() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Copyright() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Source() As AdvantageFramework.Nielsen.Database.Entities.RadioSource

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod)

            Me.ID = NielsenRadioPeriod.ID
            Me.NielsenRadioReportTypeCode = NielsenRadioPeriod.NielsenRadioReportTypeCode
            Me.NielsenPeriodID = NielsenRadioPeriod.NielsenPeriodID
            Me.NielsenRadioMarketNumber = NielsenRadioPeriod.NielsenRadioMarketNumber
            Me.ShortName = NielsenRadioPeriod.ShortName
            Me.Name = NielsenRadioPeriod.Name
            Me.StartDate = NielsenRadioPeriod.StartDate
            Me.EndDate = NielsenRadioPeriod.EndDate
            Me.StandardCondensedIndicator = NielsenRadioPeriod.StandardCondensedIndicator
            Me.Validated = False
            Me.Copyright = NielsenRadioPeriod.Copyright
            Me.Source = NielsenRadioPeriod.Source

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
