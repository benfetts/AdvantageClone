Namespace Database.ComplexTypes

	<System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="JobTeamEmployee")>
	<Serializable()>
	Public Class JobTeamEmployee
		Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

	Public Enum Properties
		TeamTypeID
				EmployeeCode
				Title
				FirstName
				LastName
				MiddleInitial
				BinaryImage
				Nickname
				TaskCount
				TotalHours
				ActualHours
				DisplayName
				EmailGroupCode
				TrafficColumnCode
				ManagerType
			End Enum

#End Region

#Region " Variables "

        Private _TeamTypeID As Nullable(Of Short) = Nothing
		        Private _EmployeeCode As String = Nothing
		        Private _Title As String = Nothing
		        Private _FirstName As String = Nothing
		        Private _LastName As String = Nothing
		        Private _MiddleInitial As String = Nothing
		        Private _BinaryImage As Byte() = Nothing
		        Private _Nickname As String = Nothing
		        Private _TaskCount As Integer = Nothing
		        Private _TotalHours As Decimal = Nothing
		        Private _ActualHours As Decimal = Nothing
		        Private _DisplayName As String = Nothing
		        Private _EmailGroupCode As String = Nothing
		        Private _TrafficColumnCode As String = Nothing
		        Private _ManagerType As Nullable(Of Short) = Nothing
		
#End Region

#Region " Properties "

	<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TeamTypeID() As Nullable(Of Short)
		Get
			TeamTypeID = _TeamTypeID
		End Get
		Set
			_TeamTypeID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
	Public Property Title() As String
		Get
			Title = _Title
		End Get
		Set
			_Title = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property FirstName() As String
		Get
			FirstName = _FirstName
		End Get
		Set
			_FirstName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property LastName() As String
		Get
			LastName = _LastName
		End Get
		Set
			_LastName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property MiddleInitial() As String
		Get
			MiddleInitial = _MiddleInitial
		End Get
		Set
			_MiddleInitial = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property BinaryImage() As Byte()
		Get
			BinaryImage = _BinaryImage
		End Get
		Set
			_BinaryImage = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property Nickname() As String
		Get
			Nickname = _Nickname
		End Get
		Set
			_Nickname = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TaskCount() As Integer
		Get
			TaskCount = _TaskCount
		End Get
		Set
			_TaskCount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TotalHours() As Decimal
		Get
			TotalHours = _TotalHours
		End Get
		Set
			_TotalHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ActualHours() As Decimal
		Get
			ActualHours = _ActualHours
		End Get
		Set
			_ActualHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property DisplayName() As String
		Get
			DisplayName = _DisplayName
		End Get
		Set
			_DisplayName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property EmailGroupCode() As String
		Get
			EmailGroupCode = _EmailGroupCode
		End Get
		Set
			_EmailGroupCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property TrafficColumnCode() As String
		Get
			TrafficColumnCode = _TrafficColumnCode
		End Get
		Set
			_TrafficColumnCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
		End Set
	End Property
			<System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true),
	System.Runtime.Serialization.DataMemberAttribute()>
	Public Property ManagerType() As Nullable(Of Short)
		Get
			ManagerType = _ManagerType
		End Get
		Set
			_ManagerType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
		End Set
	End Property
		
#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.TeamTypeID.ToString

        End Function

#End Region

	End Class

End Namespace
