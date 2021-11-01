Namespace Database.Entities

	<Table("TRAFFIC_FNC")>
	Public Class Task
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Description
			ProcessOrderNumber
			DaysToComplete
			HoursAllowed
			IsInactive
			FunctionCode
			IsMilestone
			StatusCode
			RoleCode
			[Function]
			Role
			JobComponentTasks
			ParentJobComponentTasks
			ClientContacts
			ResourceTasks
			EmployeeTimeDetails

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(10)>
		<Column("TRF_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(40)>
		<Column("TRF_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Column("TRF_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProcessOrderNumber() As Nullable(Of Short)
		<Column("TRF_DAYS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DaysToComplete() As Nullable(Of Short)
		<Column("TRF_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 2)>
        Public Property HoursAllowed() As Nullable(Of Decimal)
		<Column("TRF_INACTIVE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Default Function")>
		Public Property FunctionCode() As String
		<Required>
		<Column("MILESTONE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsMilestone() As Short
		<MaxLength(10)>
		<Column("DEF_STATUS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Default Status")>
		Public Property StatusCode() As String
		<MaxLength(6)>
		<Column("DEF_TRF_ROLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property RoleCode() As String

        Public Overridable Property [Function] As Database.Entities.Function
        Public Overridable Property Role As Database.Entities.Role
        Public Overridable Property ClientContacts As ICollection(Of Database.Entities.ClientContact)
        Public Overridable Property ResourceTasks As ICollection(Of Database.Entities.ResourceTask)
        Public Overridable Property EmployeeTimeDetails As ICollection(Of Database.Entities.EmployeeTimeDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Task.Properties.Code.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a task code."

                    End If

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Tasks
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique task code."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.Task.Properties.Description.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a task description."

                    End If

                Case AdvantageFramework.Database.Entities.Task.Properties.FunctionCode.ToString

                    If Value IsNot Nothing AndAlso Value.Trim = "" Then

                        Value = Nothing

                    End If

                Case AdvantageFramework.Database.Entities.Task.Properties.RoleCode.ToString

                    If Value IsNot Nothing AndAlso Value.Trim = "" Then

                        Value = Nothing

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
