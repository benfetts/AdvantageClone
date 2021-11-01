Namespace Database.Entities

	<Table("GLENTHDR")>
	Public Class GeneralLedger
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Transaction
			PostedDate
			EnteredDate
			ModifiedDate
			PostPeriodCode
			UserCode
			Description
			GLSourceCode
			RowID
			BatchDate
            IsVoided
            ReverseFlag
            CreateDate
            IsReversalEntry
            ReversalTransaction
            PostPeriod
			AccountPayableProductions
			AccountPayables
			AccountPayableGLDistributions
			AccountPayableInternets
			AccountPayableMagazines
			AccountPayableNewspapers
			AccountPayableOutOfHomes
			AccountPayableTVs
			AccountPayableRadios
            GeneralLedgerDocuments
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("GLEHXACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Transaction() As Integer
		<Column("GLEHPOSTSUM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostedDate() As Nullable(Of Date)
		<Required>
		<Column("GLEHENTDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EnteredDate() As Date
		<Required>
		<Column("GLEHMODDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Date
		<MaxLength(6)>
		<Column("GLEHPP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<MaxLength(100)>
		<Column("GLEHUSER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<MaxLength(100)>
		<Column("GLEHDESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(2)>
		<Column("GLEHSOURCE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSourceCode() As String
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROWID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RowID() As Integer
		<Column("BATCH_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BatchDate() As Nullable(Of Date)
		<Column("GLEHVOID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsVoided() As Nullable(Of Short)
        <MaxLength(1)>
        <Column("GLEHREVFLG", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReverseFlag() As String
        <Required>
        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateDate() As Date
        <Column("GLEHREVENTRY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsReversalEntry() As Nullable(Of Short)
        <Column("GLEHREVXACT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReversalTransaction() As Nullable(Of Integer)

        Public Overridable Property PostPeriod As Database.Entities.PostPeriod
        Public Overridable Property AccountPayableProductions As ICollection(Of Database.Entities.AccountPayableProduction)
        Public Overridable Property AccountPayables As ICollection(Of Database.Entities.AccountPayable)
        Public Overridable Property AccountPayableGLDistributions As ICollection(Of Database.Entities.AccountPayableGLDistribution)
        Public Overridable Property AccountPayableInternets As ICollection(Of Database.Entities.AccountPayableInternet)
        Public Overridable Property AccountPayableMagazines As ICollection(Of Database.Entities.AccountPayableMagazine)
        Public Overridable Property AccountPayableNewspapers As ICollection(Of Database.Entities.AccountPayableNewspaper)
        Public Overridable Property AccountPayableOutOfHomes As ICollection(Of Database.Entities.AccountPayableOutOfHome)
        Public Overridable Property AccountPayableTVs As ICollection(Of Database.Entities.AccountPayableTV)
        Public Overridable Property AccountPayableRadios As ICollection(Of Database.Entities.AccountPayableRadio)
        Public Overridable Property GeneralLedgerDocuments As ICollection(Of Database.Entities.GeneralLedgerDocument)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Transaction.ToString

        End Function

#End Region

	End Class

End Namespace
