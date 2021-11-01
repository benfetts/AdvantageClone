Namespace Database.ComplexTypes

	<System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="JobStatus")>
	<Serializable()>
	Public Class JobStatus
		Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

	Public Enum Properties
		JobNumber
				JobDescription
				JobComponentNumber
				JobComponentDescription
				ScheduleStatusCode
				ScheduleStatusDescription
				ScheduleComments
				EstimateApprovalStatusClient
				EstimateApprovalStatusClientDate
				EstimateApprovalStatusInternal
				EstimateApprovalStatusInternalDate
				QuotedHours
				ActualHours
				RemainingHours
				QuotedDollars
				ActualDollars
				RemainingDollars
				PercentComplete
				ProjectedHours
				TotalTaskHours
				TaskActualHours
				ActualEmployeeTaskHours
				LastAlertID
				LastAlertSubject
				LastAlertDate
				OpenAlertCount
				TotalAlertCount
				OpenTasksCount
				TotalTasksCount
				TaskMinStartDate
				TaskMaxDueDate
				PercentCompleteScheduleHours
				PercentCompleteAlerts
				PercentCompleteTasks
				AccountExecutiveEmployeeCode
				AccountExecutiveFullName
				ScheduleManagerEmployeeCode
				ScheduleManagerFullName
				Assignment1EmployeeCode
				Assignment1FullName
				Assignment2EmployeeCode
				Assignment2FullName
				Assignment3EmployeeCode
				Assignment3FullName
				Assignment4EmployeeCode
				Assignment4FullName
				Assignment5EmployeeCode
				Assignment5FullName
				ScheduleStartDate
				ScheduleDueDate
				ScheduleEndDate
				ScheduleCompletedDate
				Duration
				Office
				Client
				Division
				Product
				Assignment1Label
				Assignment2Label
				Assignment3Label
				Assignment4Label
				Assignment5Label
				ScheduleGutPercentComplete
				JobProcessControlID
				JobProcessControl
				JobIsBillable
				ApprovedEstimateRequired
				LastAssignmentID
				LastAssignmentSubject
				LastAssignmentDate
				OpenAssignmentCount
				TotalAssignmentCount
				EstimateApprovalStatusClientComment
				EstimateApprovalStatusInternalComment
				TaskHoursUnassigned
				BatchText
				BatchID
				BatchDescription
				BatchCreatedByUser
				BatchDate
				BillingUser
				ABFlag
				ABFlagText
			End Enum

#End Region

#Region " Variables "

        Private _JobNumber As Nullable(Of Integer) = Nothing
		        Private _JobDescription As String = Nothing
		        Private _JobComponentNumber As Nullable(Of Integer) = Nothing
		        Private _JobComponentDescription As String = Nothing
		        Private _ScheduleStatusCode As String = Nothing
		        Private _ScheduleStatusDescription As String = Nothing
		        Private _ScheduleComments As String = Nothing
		        Private _EstimateApprovalStatusClient As String = Nothing
		        Private _EstimateApprovalStatusClientDate As Nullable(Of Date) = Nothing
		        Private _EstimateApprovalStatusInternal As String = Nothing
		        Private _EstimateApprovalStatusInternalDate As Nullable(Of Date) = Nothing
		        Private _QuotedHours As Nullable(Of Decimal) = Nothing
		        Private _ActualHours As Nullable(Of Decimal) = Nothing
		        Private _RemainingHours As Nullable(Of Decimal) = Nothing
		        Private _QuotedDollars As Nullable(Of Decimal) = Nothing
		        Private _ActualDollars As Nullable(Of Decimal) = Nothing
		        Private _RemainingDollars As Nullable(Of Decimal) = Nothing
		        Private _PercentComplete As Nullable(Of Decimal) = Nothing
		        Private _ProjectedHours As Nullable(Of Decimal) = Nothing
		        Private _TotalTaskHours As Nullable(Of Decimal) = Nothing
		        Private _TaskActualHours As Nullable(Of Decimal) = Nothing
		        Private _ActualEmployeeTaskHours As Nullable(Of Decimal) = Nothing
		        Private _LastAlertID As Nullable(Of Integer) = Nothing
		        Private _LastAlertSubject As String = Nothing
		        Private _LastAlertDate As Nullable(Of Date) = Nothing
		        Private _OpenAlertCount As Nullable(Of Decimal) = Nothing
		        Private _TotalAlertCount As Nullable(Of Decimal) = Nothing
		        Private _OpenTasksCount As Nullable(Of Decimal) = Nothing
		        Private _TotalTasksCount As Nullable(Of Decimal) = Nothing
		        Private _TaskMinStartDate As Nullable(Of Date) = Nothing
		        Private _TaskMaxDueDate As Nullable(Of Date) = Nothing
		        Private _PercentCompleteScheduleHours As Nullable(Of Decimal) = Nothing
		        Private _PercentCompleteAlerts As Nullable(Of Decimal) = Nothing
		        Private _PercentCompleteTasks As Nullable(Of Decimal) = Nothing
		        Private _AccountExecutiveEmployeeCode As String = Nothing
		        Private _AccountExecutiveFullName As String = Nothing
		        Private _ScheduleManagerEmployeeCode As String = Nothing
		        Private _ScheduleManagerFullName As String = Nothing
		        Private _Assignment1EmployeeCode As String = Nothing
		        Private _Assignment1FullName As String = Nothing
		        Private _Assignment2EmployeeCode As String = Nothing
		        Private _Assignment2FullName As String = Nothing
		        Private _Assignment3EmployeeCode As String = Nothing
		        Private _Assignment3FullName As String = Nothing
		        Private _Assignment4EmployeeCode As String = Nothing
		        Private _Assignment4FullName As String = Nothing
		        Private _Assignment5EmployeeCode As String = Nothing
		        Private _Assignment5FullName As String = Nothing
		        Private _ScheduleStartDate As Nullable(Of Date) = Nothing
		        Private _ScheduleDueDate As Nullable(Of Date) = Nothing
		        Private _ScheduleEndDate As Nullable(Of Date) = Nothing
		        Private _ScheduleCompletedDate As Nullable(Of Date) = Nothing
		        Private _Duration As Nullable(Of Decimal) = Nothing
		        Private _Office As String = Nothing
		        Private _Client As String = Nothing
		        Private _Division As String = Nothing
		        Private _Product As String = Nothing
		        Private _Assignment1Label As String = Nothing
		        Private _Assignment2Label As String = Nothing
		        Private _Assignment3Label As String = Nothing
		        Private _Assignment4Label As String = Nothing
		        Private _Assignment5Label As String = Nothing
		        Private _ScheduleGutPercentComplete As Nullable(Of Decimal) = Nothing
		        Private _JobProcessControlID As Nullable(Of Short) = Nothing
		        Private _JobProcessControl As String = Nothing
		        Private _JobIsBillable As Nullable(Of Boolean) = Nothing
		        Private _ApprovedEstimateRequired As Nullable(Of Boolean) = Nothing
		        Private _LastAssignmentID As Nullable(Of Integer) = Nothing
		        Private _LastAssignmentSubject As String = Nothing
		        Private _LastAssignmentDate As Nullable(Of Date) = Nothing
		        Private _OpenAssignmentCount As Nullable(Of Decimal) = Nothing
		        Private _TotalAssignmentCount As Nullable(Of Decimal) = Nothing
		        Private _EstimateApprovalStatusClientComment As String = Nothing
		        Private _EstimateApprovalStatusInternalComment As String = Nothing
		        Private _TaskHoursUnassigned As Nullable(Of Decimal) = Nothing
		        Private _BatchText As String = Nothing
		        Private _BatchID As Nullable(Of Integer) = Nothing
		        Private _BatchDescription As String = Nothing
		        Private _BatchCreatedByUser As String = Nothing
		        Private _BatchDate As Nullable(Of Date) = Nothing
		        Private _BillingUser As String = Nothing
		        Private _ABFlag As Nullable(Of Short) = Nothing
		        Private _ABFlagText As String = Nothing
		
#End Region

#Region " Properties "

	<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property JobNumber() As Nullable(Of Integer)
		Get
			JobNumber = _JobNumber
		End Get
		Set
			_JobNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property JobDescription() As String
		Get
			JobDescription = _JobDescription
		End Get
		Set
			_JobDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property JobComponentNumber() As Nullable(Of Integer)
		Get
			JobComponentNumber = _JobComponentNumber
		End Get
		Set
			_JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property JobComponentDescription() As String
		Get
			JobComponentDescription = _JobComponentDescription
		End Get
		Set
			_JobComponentDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ScheduleStatusCode() As String
		Get
			ScheduleStatusCode = _ScheduleStatusCode
		End Get
		Set
			_ScheduleStatusCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ScheduleStatusDescription() As String
		Get
			ScheduleStatusDescription = _ScheduleStatusDescription
		End Get
		Set
			_ScheduleStatusDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ScheduleComments() As String
		Get
			ScheduleComments = _ScheduleComments
		End Get
		Set
			_ScheduleComments = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property EstimateApprovalStatusClient() As String
		Get
			EstimateApprovalStatusClient = _EstimateApprovalStatusClient
		End Get
		Set
			_EstimateApprovalStatusClient = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property EstimateApprovalStatusClientDate() As Nullable(Of Date)
		Get
			EstimateApprovalStatusClientDate = _EstimateApprovalStatusClientDate
		End Get
		Set
			_EstimateApprovalStatusClientDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property EstimateApprovalStatusInternal() As String
		Get
			EstimateApprovalStatusInternal = _EstimateApprovalStatusInternal
		End Get
		Set
			_EstimateApprovalStatusInternal = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property EstimateApprovalStatusInternalDate() As Nullable(Of Date)
		Get
			EstimateApprovalStatusInternalDate = _EstimateApprovalStatusInternalDate
		End Get
		Set
			_EstimateApprovalStatusInternalDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property QuotedHours() As Nullable(Of Decimal)
		Get
			QuotedHours = _QuotedHours
		End Get
		Set
			_QuotedHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ActualHours() As Nullable(Of Decimal)
		Get
			ActualHours = _ActualHours
		End Get
		Set
			_ActualHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property RemainingHours() As Nullable(Of Decimal)
		Get
			RemainingHours = _RemainingHours
		End Get
		Set
			_RemainingHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property QuotedDollars() As Nullable(Of Decimal)
		Get
			QuotedDollars = _QuotedDollars
		End Get
		Set
			_QuotedDollars = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ActualDollars() As Nullable(Of Decimal)
		Get
			ActualDollars = _ActualDollars
		End Get
		Set
			_ActualDollars = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property RemainingDollars() As Nullable(Of Decimal)
		Get
			RemainingDollars = _RemainingDollars
		End Get
		Set
			_RemainingDollars = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property PercentComplete() As Nullable(Of Decimal)
		Get
			PercentComplete = _PercentComplete
		End Get
		Set
			_PercentComplete = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ProjectedHours() As Nullable(Of Decimal)
		Get
			ProjectedHours = _ProjectedHours
		End Get
		Set
			_ProjectedHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TotalTaskHours() As Nullable(Of Decimal)
		Get
			TotalTaskHours = _TotalTaskHours
		End Get
		Set
			_TotalTaskHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TaskActualHours() As Nullable(Of Decimal)
		Get
			TaskActualHours = _TaskActualHours
		End Get
		Set
			_TaskActualHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ActualEmployeeTaskHours() As Nullable(Of Decimal)
		Get
			ActualEmployeeTaskHours = _ActualEmployeeTaskHours
		End Get
		Set
			_ActualEmployeeTaskHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property LastAlertID() As Nullable(Of Integer)
		Get
			LastAlertID = _LastAlertID
		End Get
		Set
			_LastAlertID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property LastAlertSubject() As String
		Get
			LastAlertSubject = _LastAlertSubject
		End Get
		Set
			_LastAlertSubject = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property LastAlertDate() As Nullable(Of Date)
		Get
			LastAlertDate = _LastAlertDate
		End Get
		Set
			_LastAlertDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property OpenAlertCount() As Nullable(Of Decimal)
		Get
			OpenAlertCount = _OpenAlertCount
		End Get
		Set
			_OpenAlertCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TotalAlertCount() As Nullable(Of Decimal)
		Get
			TotalAlertCount = _TotalAlertCount
		End Get
		Set
			_TotalAlertCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property OpenTasksCount() As Nullable(Of Decimal)
		Get
			OpenTasksCount = _OpenTasksCount
		End Get
		Set
			_OpenTasksCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TotalTasksCount() As Nullable(Of Decimal)
		Get
			TotalTasksCount = _TotalTasksCount
		End Get
		Set
			_TotalTasksCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TaskMinStartDate() As Nullable(Of Date)
		Get
			TaskMinStartDate = _TaskMinStartDate
		End Get
		Set
			_TaskMinStartDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TaskMaxDueDate() As Nullable(Of Date)
		Get
			TaskMaxDueDate = _TaskMaxDueDate
		End Get
		Set
			_TaskMaxDueDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property PercentCompleteScheduleHours() As Nullable(Of Decimal)
		Get
			PercentCompleteScheduleHours = _PercentCompleteScheduleHours
		End Get
		Set
			_PercentCompleteScheduleHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property PercentCompleteAlerts() As Nullable(Of Decimal)
		Get
			PercentCompleteAlerts = _PercentCompleteAlerts
		End Get
		Set
			_PercentCompleteAlerts = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property PercentCompleteTasks() As Nullable(Of Decimal)
		Get
			PercentCompleteTasks = _PercentCompleteTasks
		End Get
		Set
			_PercentCompleteTasks = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property AccountExecutiveEmployeeCode() As String
		Get
			AccountExecutiveEmployeeCode = _AccountExecutiveEmployeeCode
		End Get
		Set
			_AccountExecutiveEmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property AccountExecutiveFullName() As String
		Get
			AccountExecutiveFullName = _AccountExecutiveFullName
		End Get
		Set
			_AccountExecutiveFullName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ScheduleManagerEmployeeCode() As String
		Get
			ScheduleManagerEmployeeCode = _ScheduleManagerEmployeeCode
		End Get
		Set
			_ScheduleManagerEmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ScheduleManagerFullName() As String
		Get
			ScheduleManagerFullName = _ScheduleManagerFullName
		End Get
		Set
			_ScheduleManagerFullName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment1EmployeeCode() As String
		Get
			Assignment1EmployeeCode = _Assignment1EmployeeCode
		End Get
		Set
			_Assignment1EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment1FullName() As String
		Get
			Assignment1FullName = _Assignment1FullName
		End Get
		Set
			_Assignment1FullName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment2EmployeeCode() As String
		Get
			Assignment2EmployeeCode = _Assignment2EmployeeCode
		End Get
		Set
			_Assignment2EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment2FullName() As String
		Get
			Assignment2FullName = _Assignment2FullName
		End Get
		Set
			_Assignment2FullName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment3EmployeeCode() As String
		Get
			Assignment3EmployeeCode = _Assignment3EmployeeCode
		End Get
		Set
			_Assignment3EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment3FullName() As String
		Get
			Assignment3FullName = _Assignment3FullName
		End Get
		Set
			_Assignment3FullName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment4EmployeeCode() As String
		Get
			Assignment4EmployeeCode = _Assignment4EmployeeCode
		End Get
		Set
			_Assignment4EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment4FullName() As String
		Get
			Assignment4FullName = _Assignment4FullName
		End Get
		Set
			_Assignment4FullName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment5EmployeeCode() As String
		Get
			Assignment5EmployeeCode = _Assignment5EmployeeCode
		End Get
		Set
			_Assignment5EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment5FullName() As String
		Get
			Assignment5FullName = _Assignment5FullName
		End Get
		Set
			_Assignment5FullName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ScheduleStartDate() As Nullable(Of Date)
		Get
			ScheduleStartDate = _ScheduleStartDate
		End Get
		Set
			_ScheduleStartDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ScheduleDueDate() As Nullable(Of Date)
		Get
			ScheduleDueDate = _ScheduleDueDate
		End Get
		Set
			_ScheduleDueDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ScheduleEndDate() As Nullable(Of Date)
		Get
			ScheduleEndDate = _ScheduleEndDate
		End Get
		Set
			_ScheduleEndDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ScheduleCompletedDate() As Nullable(Of Date)
		Get
			ScheduleCompletedDate = _ScheduleCompletedDate
		End Get
		Set
			_ScheduleCompletedDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Duration() As Nullable(Of Decimal)
		Get
			Duration = _Duration
		End Get
		Set
			_Duration = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Office() As String
		Get
			Office = _Office
		End Get
		Set
			_Office = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Client() As String
		Get
			Client = _Client
		End Get
		Set
			_Client = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Division() As String
		Get
			Division = _Division
		End Get
		Set
			_Division = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Product() As String
		Get
			Product = _Product
		End Get
		Set
			_Product = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment1Label() As String
		Get
			Assignment1Label = _Assignment1Label
		End Get
		Set
			_Assignment1Label = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment2Label() As String
		Get
			Assignment2Label = _Assignment2Label
		End Get
		Set
			_Assignment2Label = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment3Label() As String
		Get
			Assignment3Label = _Assignment3Label
		End Get
		Set
			_Assignment3Label = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment4Label() As String
		Get
			Assignment4Label = _Assignment4Label
		End Get
		Set
			_Assignment4Label = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Assignment5Label() As String
		Get
			Assignment5Label = _Assignment5Label
		End Get
		Set
			_Assignment5Label = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ScheduleGutPercentComplete() As Nullable(Of Decimal)
		Get
			ScheduleGutPercentComplete = _ScheduleGutPercentComplete
		End Get
		Set
			_ScheduleGutPercentComplete = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property JobProcessControlID() As Nullable(Of Short)
		Get
			JobProcessControlID = _JobProcessControlID
		End Get
		Set
			_JobProcessControlID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property JobProcessControl() As String
		Get
			JobProcessControl = _JobProcessControl
		End Get
		Set
			_JobProcessControl = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property JobIsBillable() As Nullable(Of Boolean)
		Get
			JobIsBillable = _JobIsBillable
		End Get
		Set
			_JobIsBillable = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ApprovedEstimateRequired() As Nullable(Of Boolean)
		Get
			ApprovedEstimateRequired = _ApprovedEstimateRequired
		End Get
		Set
			_ApprovedEstimateRequired = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property LastAssignmentID() As Nullable(Of Integer)
		Get
			LastAssignmentID = _LastAssignmentID
		End Get
		Set
			_LastAssignmentID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property LastAssignmentSubject() As String
		Get
			LastAssignmentSubject = _LastAssignmentSubject
		End Get
		Set
			_LastAssignmentSubject = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property LastAssignmentDate() As Nullable(Of Date)
		Get
			LastAssignmentDate = _LastAssignmentDate
		End Get
		Set
			_LastAssignmentDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property OpenAssignmentCount() As Nullable(Of Decimal)
		Get
			OpenAssignmentCount = _OpenAssignmentCount
		End Get
		Set
			_OpenAssignmentCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TotalAssignmentCount() As Nullable(Of Decimal)
		Get
			TotalAssignmentCount = _TotalAssignmentCount
		End Get
		Set
			_TotalAssignmentCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property EstimateApprovalStatusClientComment() As String
		Get
			EstimateApprovalStatusClientComment = _EstimateApprovalStatusClientComment
		End Get
		Set
			_EstimateApprovalStatusClientComment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property EstimateApprovalStatusInternalComment() As String
		Get
			EstimateApprovalStatusInternalComment = _EstimateApprovalStatusInternalComment
		End Get
		Set
			_EstimateApprovalStatusInternalComment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TaskHoursUnassigned() As Nullable(Of Decimal)
		Get
			TaskHoursUnassigned = _TaskHoursUnassigned
		End Get
		Set
			_TaskHoursUnassigned = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property BatchText() As String
		Get
			BatchText = _BatchText
		End Get
		Set
			_BatchText = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property BatchID() As Nullable(Of Integer)
		Get
			BatchID = _BatchID
		End Get
		Set
			_BatchID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property BatchDescription() As String
		Get
			BatchDescription = _BatchDescription
		End Get
		Set
			_BatchDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property BatchCreatedByUser() As String
		Get
			BatchCreatedByUser = _BatchCreatedByUser
		End Get
		Set
			_BatchCreatedByUser = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property BatchDate() As Nullable(Of Date)
		Get
			BatchDate = _BatchDate
		End Get
		Set
			_BatchDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property BillingUser() As String
		Get
			BillingUser = _BillingUser
		End Get
		Set
			_BillingUser = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ABFlag() As Nullable(Of Short)
		Get
			ABFlag = _ABFlag
		End Get
		Set
			_ABFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ABFlagText() As String
		Get
			ABFlagText = _ABFlagText
		End Get
		Set
			_ABFlagText = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
		
#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber.ToString

        End Function

#End Region

	End Class

End Namespace
