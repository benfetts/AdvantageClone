Namespace MediaPlanning.Classes

    <Serializable()>
    Public Class MediaPlanEstimateChangeLog
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaPlanID
            MediaPlanDetailID
            MediaPlanDetailChangeLogID
            Estimate
            ChangeLogNumber
            UserCode
            [Date]
            Comment
        End Enum

#End Region

#Region " Variables "

        Private _MediaPlanID As Integer = Nothing
        Private _MediaPlanDetailID As Integer = Nothing
        Private _MediaPlanDetailChangeLogID As Integer = Nothing
        Private _Estimate As String = Nothing
        Private _ChangeLogNumber As Integer = Nothing
        Private _UserCode As String = Nothing
        Private _Date As Date = Nothing
        Private _Comment As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MediaPlanID() As Integer
            Get
                MediaPlanID = _MediaPlanID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MediaPlanDetailID() As Integer
            Get
                MediaPlanDetailID = _MediaPlanDetailID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MediaPlanDetailChangeLogID() As Integer
            Get
                MediaPlanDetailChangeLogID = _MediaPlanDetailChangeLogID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public ReadOnly Property Estimate() As String
            Get
                Estimate = _Estimate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Number")>
        Public ReadOnly Property ChangeLogNumber() As Integer
            Get
                ChangeLogNumber = _ChangeLogNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public ReadOnly Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property [Date]() As Date
            Get
                [Date] = _Date
            End Get
            Set(ByVal value As Date)
                _Date = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, ByVal MediaPlanDetailChangeLog As AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog)

            _MediaPlanID = MediaPlan.ID
            _MediaPlanDetailID = MediaPlanEstimate.ID
            _MediaPlanDetailChangeLogID = MediaPlanDetailChangeLog.ID
            _Estimate = MediaPlanEstimate.Name
            _ChangeLogNumber = MediaPlanDetailChangeLog.ChangeLogNumber
            _UserCode = MediaPlanDetailChangeLog.CreatedByUserCode
            _Date = MediaPlanDetailChangeLog.CreatedDate
            _Comment = MediaPlanDetailChangeLog.Comment

        End Sub

#End Region

    End Class

End Namespace