Namespace Database.Entities

	<Table("ACCT_NUMBER")>
	Public Class Account
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Number
			Description
			IsInactive
			Classification
			JobComponents

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(30)>
		<Column("ACCT_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Number() As String
		<Required>
		<MaxLength(40)>
		<Column("ACCT_NBR_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Description() As String
		<Column("ACTIVE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<MaxLength(10)>
		<Column("CLASS", TypeName:="varchar")>
		Public Property Classification() As String

        Public Overridable Property JobComponents As ICollection(Of Database.Entities.JobComponent)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Number

        End Function

#End Region

    End Class

End Namespace
