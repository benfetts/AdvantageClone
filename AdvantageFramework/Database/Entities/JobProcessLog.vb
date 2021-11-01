Namespace Database.Entities

	<Table("JOB_PROCESS_LOG")>
	Public Class JobProcessLog
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			JobNumber
			JobComponentNumber
			OriginalProcessControl
			NewProcessControl
			ProcessedDate
			ProcessedByUserCode
			Comments
			BCCFlag
			ID

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Integer
		<Required>
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Short
		<Column("ORIG_PROCESS_CNTRL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OriginalProcessControl() As Nullable(Of Short)
		<Column("NEW_PROCESS_CNTRL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewProcessControl() As Nullable(Of Short)
		<Column("PROCESS_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProcessedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("PROCESS_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProcessedByUserCode() As String
		<Column("PROCESS_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comments() As String
		<Column("BCC_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BCCFlag() As Nullable(Of Short)
		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("JOB_PROCESS_LOG_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber.ToString

        End Function

#End Region

	End Class

End Namespace
