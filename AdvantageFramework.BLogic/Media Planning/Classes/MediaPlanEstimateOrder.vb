Namespace MediaPlanning.Classes

    <Serializable()>
    Public Class MediaPlanEstimateOrder

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Estimate
            CreatedBy
            CreatedDate
            ModifiedBy
            ModifiedDate
            FullOrdered
            PartialOrdered
            Ordered
            DollarsAmount
            BillableAmount
            LastChangedByUser
            LastChangedDate
            OrderNumber
        End Enum

#End Region

#Region " Variables "

        Private _ID As Decimal = 0
        Private _Estimate As String = ""
        Private _CreatedBy As String = ""
        Private _CreatedDate As String = ""
        Private _ModifiedBy As String = ""
        Private _ModifiedDate As String = ""
        Private _FullOrdered As Boolean = False
        Private _PartialOrdered As Boolean = False
        Private _Ordered As Integer = False
        Private _DollarsAmount As Decimal = 0
        Private _BillableAmount As Decimal = 0
        Private _LastChangedByUser As String = ""
        Private _LastChangedDate As String = ""

        Private _MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Estimate() As String
            Get
                Estimate = _Estimate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property CreatedBy() As String
            Get
                CreatedBy = _CreatedBy
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property CreatedDate() As String
            Get
                CreatedDate = _CreatedDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ModifiedBy() As String
            Get
                ModifiedBy = _ModifiedBy
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ModifiedDate() As String
            Get
                ModifiedDate = _ModifiedDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property FullOrdered() As Boolean
            Get
                FullOrdered = _FullOrdered
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property PartialOrdered() As Boolean
            Get
                PartialOrdered = _PartialOrdered
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Ordered() As Integer
            Get
                Ordered = _Ordered
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DollarsAmount() As Decimal
            Get
                DollarsAmount = _DollarsAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property BillableAmount() As Decimal
            Get
                BillableAmount = _BillableAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property LastChangedByUser() As String
            Get
                LastChangedByUser = _LastChangedByUser
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property LastChangedDate() As String
            Get
                LastChangedDate = _LastChangedDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _MediaPlanEstimate.OrderNumber
            End Get
            Set(value As Integer)
                _MediaPlanEstimate.SetOrderNumber(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            _ID = MediaPlanEstimate.ID
            _Estimate = MediaPlanEstimate.Name
            _CreatedBy = MediaPlanEstimate.GetEntity.CreatedByUserCode
            _CreatedDate = MediaPlanEstimate.GetEntity.CreatedDate.ToShortDateString
            _ModifiedBy = MediaPlanEstimate.GetEntity.ModifiedByUserCode
            _ModifiedDate = If(MediaPlanEstimate.GetEntity.ModifiedDate.HasValue, MediaPlanEstimate.GetEntity.ModifiedDate.Value.ToShortDateString, "")
            _FullOrdered = (MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.OrderID IsNot Nothing AndAlso Entity.OrderLineID IsNot Nothing AndAlso (Entity.OrderNumber IsNot Nothing OrElse Entity.OrderLineNumber IsNot Nothing)).Count = MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Count) AndAlso MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Count > 0
            _PartialOrdered = MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.OrderID IsNot Nothing AndAlso Entity.OrderLineID IsNot Nothing AndAlso (Entity.OrderNumber IsNot Nothing OrElse Entity.OrderLineNumber IsNot Nothing)).Any
            _Ordered = If(_FullOrdered, 0, (If(_PartialOrdered, 1, 2)))
            _DollarsAmount = MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum
            _BillableAmount = MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum
            _LastChangedByUser = If(MediaPlanEstimate.MediaPlanDetailChangeLogs.OrderByDescending(Function(Entity) Entity.CreatedDate).LastOrDefault IsNot Nothing, MediaPlanEstimate.MediaPlanDetailChangeLogs.OrderByDescending(Function(Entity) Entity.CreatedDate).Last.CreatedByUserCode, "")
            _LastChangedDate = If(MediaPlanEstimate.MediaPlanDetailChangeLogs.OrderByDescending(Function(Entity) Entity.CreatedDate).LastOrDefault IsNot Nothing, MediaPlanEstimate.MediaPlanDetailChangeLogs.OrderByDescending(Function(Entity) Entity.CreatedDate).Last.CreatedDate.ToShortDateString, "")

            _MediaPlanEstimate = MediaPlanEstimate

        End Sub
        Public Function GetMediaPlanEstimate() As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate

            GetMediaPlanEstimate = _MediaPlanEstimate

        End Function

#End Region

    End Class

End Namespace