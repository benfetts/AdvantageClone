Namespace Database.Entities

	<Table("JOB_VER_TMPLT_DTL")>
	Public Class JobVersionTemplateDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			JobVersionTemplateCode
			DatabaseTypeID
			Label
			OrderNumber
			IsRequired
			IsInactive
            Instructions
            JobTemplateMapping
            JobVersionDatabaseType
			JobVersionTemplate

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("JV_TMPLT_DTL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("JV_TMPLT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property JobVersionTemplateCode() As String
		<Required>
		<Column("JV_DTYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Database Type", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobVersionDatabaseType)>
		Public Property DatabaseTypeID() As Integer
		<Required>
		<MaxLength(25)>
		<Column("JV_TMPLT_LABEL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Label() As String
		<Required>
		<Column("JV_TMPLT_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property OrderNumber() As Short
		<Required>
		<Column("JV_TMPLT_REQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsRequired() As Short
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="On", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<MaxLength(255)>
        <Column("JV_TMPLT_DTL_INSTR", TypeName:="varchar")>
        Public Property Instructions() As String
        <MaxLength(32)>
        <Column("JV_JT_MAPPING", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobTemplateMapping)>
        Public Property JobTemplateMapping() As String

        <ForeignKey("DatabaseTypeID")>
        Public Overridable Property JobVersionDatabaseType As Database.Entities.JobVersionDatabaseType
        Public Overridable Property JobVersionTemplate As Database.Entities.JobVersionTemplate

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        'Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

        '    'objects
        '    Dim ErrorText As String = ""
        '    Dim PropertyValue As Object = Nothing

        '    Select Case PropertyName

        '        Case AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.Label.ToString

        '            If Value Is Nothing OrElse Value.Trim = "" Then

        '                IsValid = False
        '                ErrorText = "Please enter a job version template detail label."

        '            End If

        '    End Select

        '    ValidateCustomProperties = ErrorText

        'End Function

#End Region

	End Class

End Namespace
