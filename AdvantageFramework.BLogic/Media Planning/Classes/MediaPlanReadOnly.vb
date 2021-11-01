Namespace MediaPlanning.Classes

    <Serializable()>
    Public Class MediaPlanReadOnly

        Public Event MediaPlanChangedEvent()
        Public Event SavedMediaPlanEvent()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MasterPlanID
			Description
			StartDate
			EndDate
			ClientCode
			ClientName
			DivisionCode
			DivisionName
			ProductCode
			ProductName
			MasterPlan
            IsApproved
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _MasterPlanID As Integer = 0
		Private _Description As String = ""
		Private _StartDate As Date = Nothing
		Private _EndDate As Date = Nothing
		Private _ClientCode As String = ""
		Private _ClientName As String = ""
		Private _DivisionCode As String = ""
		Private _DivisionName As String = ""
		Private _ProductCode As String = ""
		Private _ProductName As String = ""
		Private _MasterPlan As String = ""
        Private _IsApproved As Boolean = False
        Private _IsInactive As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Plan ID")>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MasterPlanID() As Integer
            Get
                MasterPlanID = _MasterPlanID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Description() As String
            Get
                Description = _Description
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property IsTemplate() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property StartDate() As Date
            Get
                StartDate = _StartDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public ReadOnly Property EndDate() As Date
			Get
				EndDate = _EndDate
			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity()>
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
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property MasterPlan() As String
            Get
                MasterPlan = _MasterPlan
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public ReadOnly Property IsApproved() As Boolean
            Get
                IsApproved = _IsApproved
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
            Set(value As Boolean)
                _IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(MediaPlan As AdvantageFramework.Database.Entities.MediaPlan)

			'objects
			Dim MasterPlanCount As Integer = 0
			Dim MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing
			Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            _ID = MediaPlan.ID

            Me.IsTemplate = MediaPlan.IsTemplate

            MasterPlanCount = MediaPlan.MediaPlanMasterPlanDetails.Select(Function(Entity) Entity.MediaPlanMasterPlanID).Distinct.Count

			If MasterPlanCount = 0 Then

				_MasterPlan = ""

			ElseIf MasterPlanCount = 1 Then

				Try

					MediaPlanMasterPlan = MediaPlan.MediaPlanMasterPlanDetails.Select(Function(Entity) Entity.MediaPlanMasterPlan).FirstOrDefault

				Catch ex As Exception
					MediaPlanMasterPlan = Nothing
				End Try

				If MediaPlanMasterPlan IsNot Nothing Then

					_MasterPlanID = MediaPlanMasterPlan.ID
					_MasterPlan = MediaPlanMasterPlan.Description

				End If

			Else

				_MasterPlan = "*Multiple*"

			End If

			_Description = MediaPlan.Description
			_StartDate = CDate(MediaPlan.StartDate.ToShortDateString)
			_EndDate = CDate(MediaPlan.EndDate.ToShortDateString)
			_ClientCode = MediaPlan.ClientCode
			_ClientName = MediaPlan.Client.Name
			_DivisionCode = MediaPlan.DivisionCode
			_DivisionName = MediaPlan.Division.Name
			_ProductCode = MediaPlan.ProductCode
			_ProductName = MediaPlan.Product.Name

			If MediaPlan.MediaPlanDetails.Any Then

				_IsApproved = MediaPlan.MediaPlanDetails.Where(Function(Detail) Detail.IsApproved = False).Any = False

			Else

				_IsApproved = False

			End If

			_IsInactive = MediaPlan.IsInactive

		End Sub

#End Region

	End Class

End Namespace

