Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioSegmentParent

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioPeriodID
            GeoIndicator
            NielsenRadioQualitativeID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioPeriodID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GeoIndicator() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenRadioQualitativeID() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioSegmentParent As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent)

            Me.ID = NielsenRadioSegmentParent.ID
            Me.NielsenRadioPeriodID = NielsenRadioSegmentParent.NielsenRadioPeriodID
            Me.GeoIndicator = NielsenRadioSegmentParent.GeoIndicator
            Me.NielsenRadioQualitativeID = NielsenRadioSegmentParent.NielsenRadioQualitativeID

        End Sub

#End Region

    End Class

End Namespace
