Namespace Database.ComplexTypes

	<System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="EmployeeTaskComplex")>
	<Serializable()>
	Public Class EmployeeTaskComplex
		Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

	Public Enum Properties
		ClientDivisionProductCodes
				JobData
				TaskDescription
				FunctionComments
				StartDate
				DueDate
				DueTime
				JobNumber
				JobComponentNumber
				HoursAllowed
				SequenceNumber
				TempCompleteDate
				EmployeeCode
				IsEvent
				EventTaskID
				TaskStatus
				JobDescription
				JobComponentDescription
				JobNumberAndComponentNumber
			End Enum

#End Region

#Region " Variables "

        Private _ClientDivisionProductCodes As String = Nothing
		        Private _JobData As String = Nothing
		        Private _TaskDescription As String = Nothing
		        Private _FunctionComments As String = Nothing
		        Private _StartDate As Nullable(Of Date) = Nothing
		        Private _DueDate As Nullable(Of Date) = Nothing
		        Private _DueTime As String = Nothing
		        Private _JobNumber As Nullable(Of Integer) = Nothing
		        Private _JobComponentNumber As Nullable(Of Short) = Nothing
		        Private _HoursAllowed As Nullable(Of Decimal) = Nothing
		        Private _SequenceNumber As Nullable(Of Integer) = Nothing
		        Private _TempCompleteDate As Nullable(Of Date) = Nothing
		        Private _EmployeeCode As String = Nothing
		        Private _IsEvent As Nullable(Of Integer) = Nothing
		        Private _EventTaskID As Nullable(Of Integer) = Nothing
		        Private _TaskStatus As String = Nothing
		        Private _JobDescription As String = Nothing
		        Private _JobComponentDescription As String = Nothing
		        Private _JobNumberAndComponentNumber As String = Nothing
		
#End Region

#Region " Properties "

	<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ClientDivisionProductCodes() As String
		Get
			ClientDivisionProductCodes = _ClientDivisionProductCodes
		End Get
		Set
			_ClientDivisionProductCodes = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property JobData() As String
		Get
			JobData = _JobData
		End Get
		Set
			_JobData = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TaskDescription() As String
		Get
			TaskDescription = _TaskDescription
		End Get
		Set
			_TaskDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property FunctionComments() As String
		Get
			FunctionComments = _FunctionComments
		End Get
		Set
			_FunctionComments = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property StartDate() As Nullable(Of Date)
		Get
			StartDate = _StartDate
		End Get
		Set
			_StartDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property DueDate() As Nullable(Of Date)
		Get
			DueDate = _DueDate
		End Get
		Set
			_DueDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property DueTime() As String
		Get
			DueTime = _DueTime
		End Get
		Set
			_DueTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
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
	Public Property JobComponentNumber() As Nullable(Of Short)
		Get
			JobComponentNumber = _JobComponentNumber
		End Get
		Set
			_JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property HoursAllowed() As Nullable(Of Decimal)
		Get
			HoursAllowed = _HoursAllowed
		End Get
		Set
			_HoursAllowed = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property SequenceNumber() As Nullable(Of Integer)
		Get
			SequenceNumber = _SequenceNumber
		End Get
		Set
			_SequenceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TempCompleteDate() As Nullable(Of Date)
		Get
			TempCompleteDate = _TempCompleteDate
		End Get
		Set
			_TempCompleteDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property EmployeeCode() As String
		Get
			EmployeeCode = _EmployeeCode
		End Get
		Set
			_EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property IsEvent() As Nullable(Of Integer)
		Get
			IsEvent = _IsEvent
		End Get
		Set
			_IsEvent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property EventTaskID() As Nullable(Of Integer)
		Get
			EventTaskID = _EventTaskID
		End Get
		Set
			_EventTaskID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TaskStatus() As String
		Get
			TaskStatus = _TaskStatus
		End Get
		Set
			_TaskStatus = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
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
	Public Property JobNumberAndComponentNumber() As String
		Get
			JobNumberAndComponentNumber = _JobNumberAndComponentNumber
		End Get
		Set
			_JobNumberAndComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
		
#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientDivisionProductCodes.ToString

        End Function

#End Region

	End Class

End Namespace
