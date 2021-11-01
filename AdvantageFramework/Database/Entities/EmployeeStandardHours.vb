Namespace Database.Entities

	<Table("W_EMP_STD_HOURS")>
	Public Class EmployeeStandardHours
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			UserCode
			CreatedDate
			StartDate
			EndDate

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(100)>
		<Column("USERID", TypeName:="varchar")>
		Public Property UserCode() As String
		<Required>
		<Column("QUERY_DATE")>
		Public Property CreatedDate() As Date
		<Required>
		<Column("START_DATE")>
		Public Property StartDate() As Date
		<Required>
		<Column("END_DATE")>
		Public Property EndDate() As Date


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode

        End Function

#End Region

	End Class

End Namespace
