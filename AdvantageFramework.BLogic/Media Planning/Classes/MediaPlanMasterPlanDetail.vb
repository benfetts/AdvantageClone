Namespace MediaPlanning.Classes

    <Serializable()>
    Public Class MediaPlanMasterPlanDetail
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaPlanMasterPlanDetailID
            MediaPlanID
			Description
			StartDate
			EndDate
			ClientCode
			ClientName
			DivisionCode
			DivisionName
			ProductCode
			ProductName
			IsApproved
        End Enum

#End Region

#Region " Variables "

        Private _MediaPlanMasterPlanDetailID As Integer = Nothing
        Private _MediaPlanID As Integer = Nothing
		Private _Description As String = Nothing
		Private _StartDate As Date = Nothing
		Private _EndDate As Date = Nothing
		Private _ClientCode As String = ""
		Private _ClientName As String = ""
		Private _DivisionCode As String = ""
		Private _DivisionName As String = ""
		Private _ProductCode As String = ""
		Private _ProductName As String = ""
		Private _IsApproved As Boolean = Nothing
        Private _SyncDetailSettings As Boolean = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MediaPlanMasterPlanDetailID() As Integer
            Get
                MediaPlanMasterPlanDetailID = _MediaPlanMasterPlanDetailID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MediaPlanID() As Integer
            Get
                MediaPlanID = _MediaPlanID
            End Get
        End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
		Public ReadOnly Property Description() As String
			Get
				Description = _Description
			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
		Public ReadOnly Property StartDate() As Date
			Get
				StartDate = _StartDate
			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
		Public ReadOnly Property EndDate() As Date
			Get
				EndDate = _EndDate
			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public ReadOnly Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
		Public ReadOnly Property ClientName() As String
			Get
				ClientName = _ClientName
			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public ReadOnly Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public ReadOnly Property DivisionName() As String
			Get
				DivisionName = _DivisionName
			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public ReadOnly Property ProductCode() As String
			Get
				ProductCode = _ProductCode
			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public ReadOnly Property ProductName() As String
			Get
				ProductName = _ProductName
			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public ReadOnly Property IsApproved() As Boolean
            Get
                IsApproved = _IsApproved
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public ReadOnly Property SyncDetailSettings() As Boolean
            Get
                SyncDetailSettings = _SyncDetailSettings
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail, ByVal MediaPlan As AdvantageFramework.Database.Entities.MediaPlan)

            _MediaPlanMasterPlanDetailID = MediaPlanMasterPlanDetail.ID
            _MediaPlanID = MediaPlan.ID
			_Description = MediaPlan.Description
			_StartDate = CDate(MediaPlan.StartDate.ToShortDateString)
			_EndDate = CDate(MediaPlan.EndDate.ToShortDateString)
			_ClientCode = MediaPlan.ClientCode
			_ClientName = MediaPlan.Client.Name
			_DivisionCode = MediaPlan.DivisionCode
			_DivisionName = MediaPlan.Division.Name
			_ProductCode = MediaPlan.ProductCode
			_ProductName = MediaPlan.Product.Name
			_IsApproved = MediaPlan.MediaPlanDetails.Where(Function(Detail) Detail.IsApproved = False).Any = False
            _SyncDetailSettings = MediaPlan.SyncDetailSettings

        End Sub
        Public Sub New(ByVal MediaPlan As AdvantageFramework.Database.Entities.MediaPlan)

            _MediaPlanMasterPlanDetailID = 0
            _MediaPlanID = MediaPlan.ID
			_Description = MediaPlan.Description
			_StartDate = CDate(MediaPlan.StartDate.ToShortDateString)
			_EndDate = CDate(MediaPlan.EndDate.ToShortDateString)
			_ClientCode = MediaPlan.ClientCode
			_ClientName = MediaPlan.Client.Name
			_DivisionCode = MediaPlan.DivisionCode
			_DivisionName = MediaPlan.Division.Name
			_ProductCode = MediaPlan.ProductCode
			_ProductName = MediaPlan.Product.Name
			_IsApproved = MediaPlan.MediaPlanDetails.Where(Function(Detail) Detail.IsApproved = False).Any = False
            _SyncDetailSettings = MediaPlan.SyncDetailSettings

        End Sub

#End Region

    End Class

End Namespace