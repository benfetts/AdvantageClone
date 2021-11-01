Namespace MediaPlanning.Classes

    <Serializable()>
    Public Class MediaPlanDetailLevelLineDataOrderDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaPlanDetailLevelLineDataID
            OrderID
            OrderLineID
            OrderLineNumber
            OrderNumber
        End Enum

#End Region

#Region " Variables "

        Private _MediaPlanDetailLevelLineDataID As Integer = Nothing
        Private _OrderID As Integer? = Nothing
        Private _OrderLineID As Integer? = Nothing
        Private _OrderLineNumber As Integer? = Nothing
        Private _OrderNumber As Integer? = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaPlanDetailLevelLineDataID() As Integer
            Get
                MediaPlanDetailLevelLineDataID = _MediaPlanDetailLevelLineDataID
            End Get
            Set(ByVal value As Integer)
                _MediaPlanDetailLevelLineDataID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderID() As Integer?
            Get
                OrderID = _OrderID
            End Get
            Set(ByVal value As Integer?)
                _OrderID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderLineID() As Integer?
            Get
                OrderLineID = _OrderLineID
            End Get
            Set(ByVal value As Integer?)
                _OrderLineID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderLineNumber() As Integer?
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(ByVal value As Integer?)
                _OrderLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderNumber() As Integer?
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As Integer?)
                _OrderNumber = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            _MediaPlanDetailLevelLineDataID = MediaPlanDetailLevelLineData.ID
            _OrderID = MediaPlanDetailLevelLineData.OrderID
            _OrderLineID = MediaPlanDetailLevelLineData.OrderLineID
            _OrderLineNumber = MediaPlanDetailLevelLineData.OrderLineNumber
            _OrderNumber = MediaPlanDetailLevelLineData.OrderNumber

        End Sub

#End Region

    End Class

End Namespace