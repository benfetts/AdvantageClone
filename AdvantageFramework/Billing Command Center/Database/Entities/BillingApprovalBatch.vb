Namespace BillingCommandCenter.Database.Entities

    <Table("BILL_APPR_BATCH")>
    Public Class BillingApprovalBatch
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            BatchDate
            CreatedBy
            CreatedDate
            ModifiedBy
            ModifiedDate
            DateCutoff
            CutoffPostPeriodCode
            EmployeeCode
            IncludeNoDTL
            IncludeNB
            IncludeFee
            IncludeInternet
            IncludeNewspaper
            IncludeMagazine
            IncludeOutOfHome
            IncludeRadio
            IncludeTV
            IsApproved
            IsFinished
            ApprovalMethod
            SelectionOption
            ManagerType
            BillingApprovalExists
            BillingApprovalBilledAny
            BillingApprovalBilledAll
            BillingCommandCenters

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("BA_BATCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <MaxLength(50)>
		<Column("BA_BATCH_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Column("BATCH_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BatchDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("CREATE_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedBy() As String
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("MODIFY_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedBy() As String
		<Column("MODIFY_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<Column("DATE_CUTOFF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateCutoff() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("PERIOD_CUTOFF", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CutoffPostPeriodCode() As String
		<Required>
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String
        <Required>
        <Column("INCL_NO_DTL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeNoDTL() As Boolean
        <Required>
        <Column("INCL_NB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeNB() As Boolean
        <Required>
        <Column("INCL_FEE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeFee() As Boolean
        <Required>
        <Column("INCL_INT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeInternet() As Boolean
        <Required>
        <Column("INCL_NP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeNewspaper() As Boolean
        <Required>
        <Column("INCL_MAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeMagazine() As Boolean
        <Required>
        <Column("INCL_OD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeOutOfHome() As Boolean
        <Required>
        <Column("INCL_RA")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeRadio() As Boolean
        <Required>
        <Column("INCL_TV")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeTV() As Boolean
        <Required>
        <Column("APPROVED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsApproved() As Boolean
        <Required>
        <Column("FINISHED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsFinished() As Boolean
        <Required>
        <Column("APPR_METHOD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalMethod() As Byte
        <Column("SEL_OPTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SelectionOption() As Nullable(Of Short)
        <Column("MANAGER_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ManagerType() As Nullable(Of Short)
        <Column("BA_EXISTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalExists() As Nullable(Of Boolean)
        <Column("BILLED_ANY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalBilledAny() As Nullable(Of Boolean)
        <Column("BILLED_ALL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalBilledAll() As Nullable(Of Boolean)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
