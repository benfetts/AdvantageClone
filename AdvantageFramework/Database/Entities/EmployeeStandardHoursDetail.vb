Namespace Database.Entities

	<Table("W_EMP_STD_HOURS_DTL")>
	Public Class EmployeeStandardHoursDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			UserCode
			EmployeeCode
			WorkDate
			AverageHours
			StandardHours

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(100)>
        <Column("USERID", Order:=0, TypeName:="varchar")>
        Public Property UserCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("EMP_CODE", Order:=1, TypeName:="varchar")>
        Public Property EmployeeCode() As String
		<Key>
		<Required>
        <Column("WORK_DATE", Order:=2)>
        Public Property WorkDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
        <Column("AVG_HRS")>
        Public Property AverageHours() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        <Column("STD_HRS")>
		Public Property StandardHours() As Nullable(Of Decimal)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode

        End Function

#End Region

	End Class

End Namespace
