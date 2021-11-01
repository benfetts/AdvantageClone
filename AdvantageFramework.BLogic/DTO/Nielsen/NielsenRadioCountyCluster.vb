Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioCountyCluster

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioCountyPeriodID
            CountyCodeWithinCluster
            Name
            Pop12Plus
            State
            ClusterMeasurementType
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioCountyPeriodID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyCodeWithinCluster() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Pop12Plus() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property State() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClusterMeasurementType() As String

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(NielsenRadioCountyCluster As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyCluster)

            Me.ID = NielsenRadioCountyCluster.ID
            Me.NielsenRadioCountyPeriodID = NielsenRadioCountyCluster.NielsenRadioCountyPeriodID
            Me.CountyCodeWithinCluster = NielsenRadioCountyCluster.CountyCodeWithinCluster
            Me.Name = NielsenRadioCountyCluster.Name
            Me.Pop12Plus = NielsenRadioCountyCluster.Pop12Plus
            Me.State = NielsenRadioCountyCluster.State
            Me.ClusterMeasurementType = NielsenRadioCountyCluster.ClusterMeasurementType

        End Sub

#End Region

    End Class

End Namespace
