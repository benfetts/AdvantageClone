Namespace Database.Entities

	<Table("MEDIA_SPECS_DTL")>
	Public Class MediaSpecsDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			SpecID
			LabelID
			MediaType
			SpecData
			MediaSpecsHeader

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("SPEC_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SpecID() As Integer
		<Key>
		<Required>
		<MaxLength(10)>
        <Column("LABEL_ID", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LabelID() As String
		<MaxLength(1)>
		<Column("MEDIA_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaType() As String
		<MaxLength(100)>
		<Column("SPEC_DATA", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SpecData() As String

        <ForeignKey("SpecID")>
        Public Overridable Property MediaSpecsHeader As Database.Entities.MediaSpecsHeader

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.SpecID.ToString

        End Function

#End Region

	End Class

End Namespace
