Namespace Database.Entities

	<Table("JOB_SERVICE_FEE")>
	Public Class JobServiceFee
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			JobNumber
			JobComponentNumber
			FeeSetupDate
			FeeStartDate
			FeeEndDate
			Frequency
			NumberOfFees
			FeeType
			Media
			Production
			EmployeeTime
			FunctionCode
			FeeAmount
			MaxAmount
			ContractInfo
			ClientComment
			CreateDate
			CreatedBy
			ModifiedDate
			ModifiedBy
			Description
			Quantity
			Rate
			[Function]
			IncomeOnlys
			JobComponent

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("JOB_SERVICE_FEE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property JobNumber() As Integer
		<Required>
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property JobComponentNumber() As Short
		<Column("FEE_SETUP_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FeeSetupDate() As Nullable(Of Date)
		<Column("FEE_START_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property FeeStartDate() As Nullable(Of Date)
		<Column("FEE_END_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property FeeEndDate() As Nullable(Of Date)
		<Column("FREQUENCY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Frequency() As Nullable(Of Short)
		<Column("NUMBER_OF_FEES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NumberOfFees() As Nullable(Of Integer)
		<Column("FEE_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FeeType() As Nullable(Of Short)
		<Column("MEDIA")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Media() As Nullable(Of Short)
		<Column("PRODUCTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Production() As Nullable(Of Short)
		<Column("EMP_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeTime() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property FunctionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("FEE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property FeeAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("MAX_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property MaxAmount() As Nullable(Of Decimal)
		<Column("CONTACT_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ContractInfo() As String
		<Column("CLIENT_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientComment() As String
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreateDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("CREATED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedBy() As String
		<Column("MODIFY_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("MODIFIED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedBy() As String
		<MaxLength(100)>
		<Column("FEE_DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("FEE_QTY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quantity() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 4)>
        <Column("FEE_RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
		Public Property Rate() As Nullable(Of Decimal)

        Public Overridable Property [Function] As Database.Entities.Function
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property IncomeOnlys As ICollection(Of Database.Entities.IncomeOnly)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
