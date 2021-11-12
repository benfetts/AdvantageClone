Namespace Database.Entities

	<Table("CHECK_REGISTER")>
	Public Class CheckRegister
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			BankCode
			CheckNumber
			CheckSequenceNumber
			CheckDate
			CheckAmount
			PayToVender
			IsVoid
			IsCleared
			PostPeriodCode
			VoidedByUserCode
			VoidDate
			VoidPostPeriodCode
			PayToVenderCode
			EmailDate
			ExportDate
			EFileDate
			GLTransaction
			CheckClearedDate
            CheckRunID
			PostPeriod
			VoidPostPeriod
			Bank
			AccountPayablePayments
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(4)>
        <Column("BK_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BankCode() As String
		<Key>
		<Required>
        <Column("CHECK_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckNumber() As Integer
		<Required>
		<Column("CHK_SEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckSequenceNumber() As Short
		<Required>
		<Column("CHECK_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("CHECK_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckAmount() As Nullable(Of Decimal)
		<MaxLength(40)>
		<Column("PAY_TO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToVender() As String
		<Column("VOID_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsVoid() As Nullable(Of Short)
		<Column("CLEARED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsCleared() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<MaxLength(100)>
		<Column("VOIDED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VoidedByUserCode() As String
		<Column("VOID_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VoidDate() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("VOID_POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VoidPostPeriodCode() As String
		<MaxLength(6)>
		<Column("PAY_TO_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PayToVenderCode() As String
		<Column("EMAIL_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailDate() As Nullable(Of Date)
		<Column("EXPORT_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExportDate() As Nullable(Of Date)
		<Column("EFILE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EFileDate() As Nullable(Of Date)
		<Column("GLEXACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Nullable(Of Integer)
		<Column("CHECK_CLEARED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckClearedDate() As Nullable(Of Date)
        <MaxLength(50)>
        <Column("CHECK_RUN_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckRunID() As String

        <ForeignKey("PostPeriodCode")>
        Public Overridable Property PostPeriod As Database.Entities.PostPeriod
        <ForeignKey("VoidPostPeriodCode")>
        Public Overridable Property VoidPostPeriod As Database.Entities.PostPeriod
        Public Overridable Property Bank As Database.Entities.Bank
        Public Overridable Property AccountPayablePayments As ICollection(Of Database.Entities.AccountPayablePayment)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.BankCode

        End Function

#End Region

	End Class

End Namespace
