Namespace Database.Entities

	<Table("EMP_DP_TM")>
	Public Class EmployeeDepartment
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			EmployeeCode
			DepartmentTeamCode
			DepartmentName
			DepartmentTeam
			Employee

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
        <Column("EMP_CODE", Order:=0, TypeName:="varchar")>
        Public Property EmployeeCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("DP_TM_CODE", Order:=1, TypeName:="varchar")>
        Public Property DepartmentTeamCode() As String
		<MaxLength(30)>
		<Column("DP_TM_DESC", TypeName:="varchar")>
		Public Property DepartmentName() As String

        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam
        Public Overridable Property Employee As Database.Views.Employee

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeCode

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.EmployeeDepartment.Properties.DepartmentTeamCode.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).EmployeeDepartments
                            Where Entity.DepartmentTeamCode.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                     Entity.EmployeeCode.ToUpper = Me.EmployeeCode.ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique department / team code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
