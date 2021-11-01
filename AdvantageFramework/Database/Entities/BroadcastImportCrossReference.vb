Namespace Database.Entities

	<Table("BRD_IMPORT_XREF")>
	Public Class BroadcastImportCrossReference
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ImportOrderNumber
			OrderNumber
			ImportLineNumber
			LineNumber
			MediaType
			ImportedFrom
			LastRevisedDate
			LastUserCode
			IsConvertedImportLine
			IsRewrite

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("IMPORT_ORDER_NBR", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportOrderNumber() As Integer
		<Key>
		<Required>
        <Column("ORDER_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Integer
		<Key>
		<Required>
        <Column("IMPORT_LINE_NBR", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportLineNumber() As Integer
		<Key>
		<Required>
        <Column("LINE_NBR", Order:=3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineNumber() As Short
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("MEDIA_TYPE", Order:=4, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaType() As String
		<Key>
		<Required>
		<MaxLength(2)>
        <Column("IMPORTED_FROM", Order:=5, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportedFrom() As String
		<Column("LAST_DATE_REVISED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastRevisedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("LAST_USERID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastUserCode() As String
		<Column("CNVT_IMPRT_LINE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsConvertedImportLine() As Nullable(Of Short)
		<Column("REWRITE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsRewrite() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ImportOrderNumber.ToString

        End Function

#End Region

	End Class

End Namespace
