Namespace Database.Entities

	<Table("CHKWRITING_SEL")>
	Public Class CheckWritingSelection
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			UserCode
			Code
			Type

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(100)>
        <Column("USER_ID", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Key>
		<Required>
		<MaxLength(30)>
        <Column("CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Code() As String
		<Key>
		<Required>
		<MaxLength(1)>
        <Column("TYPE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Type() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode.ToString

        End Function

#End Region

	End Class

End Namespace
