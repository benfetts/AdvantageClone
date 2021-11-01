Namespace Database.Entities

	<Table("RESOURCE_TASKS")>
	Public Class ResourceTask
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ResourceCode
			TaskCode
			HoursAllowed
			SetHours
			BeforeAfter
			Condition
			Resource
			Task

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("RESOURCE_TASKS_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("RESOURCE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property ResourceCode() As String
		<MaxLength(10)>
		<Column("TASK_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.TaskCode)>
		Public Property TaskCode() As String
		<Column("HOURS_ALLOWED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="#0.#0")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 2)>
        Public Property HoursAllowed() As Nullable(Of Decimal)
		<Column("SET_HOURS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="#0.#0")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 2)>
        Public Property SetHours() As Nullable(Of Decimal)
		<Column("BEFORE_AFTER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Before / After")>
		Public Property BeforeAfter() As Nullable(Of Short)
		<Column("CONDITION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Condition() As Nullable(Of Short)

        Public Overridable Property Resource As Database.Entities.Resource
        Public Overridable Property Task As Database.Entities.Task

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ResourceTask.Properties.TaskCode.ToString

                    If IsValid Then

                        PropertyValue = Value

                        If Not (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Tasks _
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper _
                                Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a valid task code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
