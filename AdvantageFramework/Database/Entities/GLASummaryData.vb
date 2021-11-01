Namespace Database.Entities

	<Table("GLSUMMARY")>
	Public Class GLASummaryData
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			GLACode
			PostPeriodCode
			Debit
			Credit
			Quantity
			Budget1
			Budget2
			Budget3
			[Mod]
			GLSBUD4

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(30)>
        <Column("GLSCODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("GLSPP", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<Required>
		<Column("GLSDEBIT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Debit() As Double
		<Required>
		<Column("GLSCREDIT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Credit() As Double
		<Required>
		<Column("GLSQTY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Quantity() As Double
		<Required>
		<Column("GLSBUDGET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Budget1() As Double
		<Required>
		<Column("GLSBUD2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Budget2() As Double
		<Required>
		<Column("GLSBUD3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Budget3() As Double
		<MaxLength(1)>
		<Column("GLSMOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property [Mod]() As String
		<Required>
		<Column("GLSBUD4")>
		Public Property GLSBUD4() As Double


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.GLACode.ToString

        End Function

#End Region

	End Class

End Namespace
