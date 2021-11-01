Namespace Database.Entities

	<Table("RPT_RUNTIME_SPECS")>
	Public Class ReportRuntimeSpec
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ID
			AccessConnectionString
			UserCode
			ReportType
			LinkID
			SelectedDate
			SQLPrintedDate
			PrintedDate
			MemoOption
			AddressOption
			NameOverrideOption
			FunctionOption
			PrintOption
			IsDraft
			IsOneTime
			AccessReportPath
			AccessReportTemporaryPath
			EmailFrom
			EmailSubject
			EmailBody
			EmailCC

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("RRS_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(255)>
		<Column("ADVAN_DSN", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccessConnectionString() As String
		<Required>
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Required>
		<MaxLength(2)>
		<Column("APP_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReportType() As String
		<Column("LINK_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LinkID() As Byte
		<Column("SEL_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SelectedDate() As Nullable(Of Date)
		<Column("DATE_SQL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SQLPrintedDate() As Nullable(Of Date)
		<Column("PRINT_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintedDate() As Nullable(Of Date)
		<Column("MEMO_OPT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MemoOption() As Nullable(Of Byte)
        <Column("ADDRESS_OPT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AddressOption() As Nullable(Of Byte)
        <Column("NAME_OVERIDE_OPT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NameOverrideOption() As Nullable(Of Byte)
        <Column("FUNCTION_OPT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionOption() As Nullable(Of Byte)
        <Required>
		<Column("PREVIEW")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintOption() As Byte
		<Required>
		<Column("DRAFT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsDraft() As Byte
		<Required>
		<Column("ONE_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsOneTime() As Byte
		<MaxLength(255)>
		<Column("USER_FORMS_PATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccessReportPath() As String
		<MaxLength(255)>
		<Column("ACCESS_TMP_PATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccessReportTemporaryPath() As String
		<MaxLength(255)>
		<Column("FROM", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailFrom() As String
		<MaxLength(255)>
		<Column("SUBJECT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailSubject() As String
		<Column("BODY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailBody() As String
		<Column("CC_ME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmailCC() As Nullable(Of Byte)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
