Namespace Database.Entities

	<Table("JF_JOB")>
	Public Class JobForecastJob
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ID
			JobForecastRevisionID
			JobForecastID
			JobNumber
			JobComponentNumber
			Comment
			IncomeAmount
			Color
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
			ModifiedDate
			JobForecast
			JobForecastRevision
			JobForecastJobDetails

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("JF_JOB_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("JF_REV_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobForecastRevisionID() As Integer
		<Required>
		<Column("JF_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobForecastID() As Integer
		<Required>
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Integer
		<Required>
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Short
		<MaxLength(100)>
		<Column("JF_JOB_COMMENT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("INCOME_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncomeAmount() As Nullable(Of Decimal)
		<Column("COLOR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Color() As Nullable(Of Integer)
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<MaxLength(100)>
		<Column("USER_MODIFIED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)

        Public Property JobForecast As JobForecast
        Public Property JobForecastRevision As JobForecastRevision
        Public Property JobForecastJobDetails As ICollection(Of JobForecastJobDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
