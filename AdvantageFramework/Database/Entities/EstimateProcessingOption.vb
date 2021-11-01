Namespace Database.Entities

	<Table("EST_REQ_OPT")>
	Public Class EstimateProcessingOption
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			OptionID
			Description
			AllowProcessing
			ExceedOption
			DisplayMessage

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("EST_REQ_OPT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property OptionID() As Short
		<Required>
		<MaxLength(32)>
		<Column("EST_REQ_OPT_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property Description() As String
		<Column("ALLOW_PROCESSING")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Allow without an Approved Estimate", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property AllowProcessing() As Nullable(Of Short)
		<Column("EXCEED_OPTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ExceedOption() As Nullable(Of Short)
		<MaxLength(150)>
		<Column("DISPLAY_MSG", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Display Message (maximum 150 characters)")>
		Public Property DisplayMessage() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OptionID

        End Function

#End Region

	End Class

End Namespace
