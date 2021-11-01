Namespace Database.Entities

	<Table("PRD_SRT_KEY")>
	Public Class ProductSortKey
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ClientCode
			DivisionCode
			ProductCode
			SortKey
			Product

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
        <Column("CL_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("DIV_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("PRD_CODE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<Key>
		<Required>
		<MaxLength(20)>
        <Column("PRD_SRT_KEY", Order:=3, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Sort Option")>
		Public Property SortKey() As String

        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode

        End Function

#End Region

	End Class

End Namespace
