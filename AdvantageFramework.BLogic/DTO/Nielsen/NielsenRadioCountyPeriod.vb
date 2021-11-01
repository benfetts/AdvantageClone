Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioCountyPeriod

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioMarketNumber
            CountyCode
            Year
            StartDate
            EndDate
            IsCluster
            Name
            State
            WeightingFlag
            MeasurementType
            Copyright
            Validated
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyCode() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsCluster() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property State() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WeightingFlag() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MeasurementType() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Copyright() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Validated() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(NielsenRadioCountyPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyPeriod)

            Me.ID = NielsenRadioCountyPeriod.ID
            Me.NielsenRadioMarketNumber = NielsenRadioCountyPeriod.NielsenRadioMarketNumber
            Me.CountyCode = NielsenRadioCountyPeriod.CountyCode
            Me.Year = NielsenRadioCountyPeriod.Year
            Me.StartDate = NielsenRadioCountyPeriod.StartDate
            Me.EndDate = NielsenRadioCountyPeriod.EndDate
            Me.IsCluster = NielsenRadioCountyPeriod.IsCluster
            Me.Name = NielsenRadioCountyPeriod.Name
            Me.State = NielsenRadioCountyPeriod.State
            Me.WeightingFlag = NielsenRadioCountyPeriod.WeightingFlag
            Me.MeasurementType = NielsenRadioCountyPeriod.MeasurementType
            Me.Copyright = NielsenRadioCountyPeriod.Copyright
            Me.Validated = False

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
