Namespace Database.Entities

	<Table("ATB_HDR")>
	Public Class MediaATB
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Number
			ClientCode
			DivisionCode
			ProductCode
			IsInactive
			Client
			Division
			Product
			MediaATBRevisions

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ATB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Number() As Integer
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<Required>
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<Required>
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsInactive() As Nullable(Of Short)

        Public Overridable Property Client As Database.Entities.Client
        <ForeignKey("ClientCode, DivisionCode")>
        Public Overridable Property Division As Database.Entities.Division
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property MediaATBRevisions As ICollection(Of Database.Entities.MediaATBRevision)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Number.ToString

        End Function

#End Region

	End Class

End Namespace
