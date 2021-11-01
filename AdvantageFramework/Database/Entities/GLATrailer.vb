Namespace Database.Entities

	<Table("GLALTRAILER")>
	Public Class GLATrailer
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			GLAllocationID
			GLAltCode
			GLAltValue
			GLAltAllocation
			GLAltAmount
			ClientCode
			DivisionCode
			ProductCode
			ID

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("GLALTXACT", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property GLAllocationID() As Integer
		<Key>
		<Required>
		<MaxLength(30)>
        <Column("GLALTCODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Account")>
		Public Property GLAltCode() As String
		<Column("GLALTVALUE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f5", CustomColumnCaption:="Percent")>
        Public Property GLAltValue() As Nullable(Of Double)
        <Column("GLALTALLOCATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f5")>
        Public Property GLAltAllocation() As Nullable(Of Double)
        <Column("GLALTAMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLAltAmount() As Nullable(Of Double)
        <MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROWID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.GLAllocationID.ToString

        End Function

#End Region

	End Class

End Namespace
