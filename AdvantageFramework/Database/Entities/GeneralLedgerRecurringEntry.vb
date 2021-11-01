Namespace Database.Entities

    <Table("GLRJEHDR")>
    Public Class GeneralLedgerRecurringEntry
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ControlNumber
            Description
            EnteredDate
            CycleCode
            ReverseFlag
            UserCode
            LastPostPeriodCode
            LastPostingDate
            LastPostingUserCode
            ModifiedFlag
            ModifiedDate
            IsInactive
            IsVoided
            StartingPostPeriodCode
            NumberOfPostings
            UnlimitedPostings
            LegacyEntry
            LastPostPeriod
            StartingPostPeriod
            Cycle
            GeneralLedgerRecurringEntryDetails
            GeneralLedgerRecurringEntryLogs
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)>
        <Required>
        <Column("GLRHCNTRL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ControlNumber() As Integer
        <Required>
        <MaxLength(45)>
        <Column("GLRHDESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description() As String
        <Required>
        <Column("GLRHENTDATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EnteredDate() As Nullable(Of Date)
        <Required>
        <MaxLength(6)>
        <Column("GLRHCYCLE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CycleCode() As String
        <MaxLength(1)>
        <Column("GLRHREVFLAG", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ReverseFlag() As String
        <MaxLength(100)>
        <Column("GLRHUSER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property UserCode() As String
        <MaxLength(6)>
        <Column("GLRHLASTPP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LastPostPeriodCode() As String
        <Column("GLRHLASTDATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LastPostingDate() As Nullable(Of Date)
        <MaxLength(100)>
        <Column("GLRHLASTBY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LastPostingUserCode() As String
        <MaxLength(1)>
        <Column("GLRHMOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ModifiedFlag() As String
        <Column("GLRHMODDATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ModifiedDate() As Nullable(Of Date)
        <Column("GLRHINACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Nullable(Of Short)
        <Column("GLRJEVOID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsVoided() As Nullable(Of Short)
        <MaxLength(6)>
        <Column("STARTING_PPPERIOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartingPostPeriodCode() As String
        <Column("NUMBER_OF_POSTINGS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NumberOfPostings() As Nullable(Of Integer)
        <Required>
        <Column("UNLIMITED_POSTINGS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property UnlimitedPostings() As Boolean
        <Required>
        <Column("LEGACY_ENTRY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property LegacyEntry() As Boolean

        <ForeignKey("LastPostPeriodCode")>
        Public Overridable Property LastPostPeriod As Database.Entities.PostPeriod
        <ForeignKey("StartingPostPeriodCode")>
        Public Overridable Property StartingPostPeriod As Database.Entities.PostPeriod
        Public Overridable Property Cycle As Database.Entities.Cycle
        Public Overridable Property GeneralLedgerRecurringEntryDetails As ICollection(Of Database.Entities.GeneralLedgerRecurringEntryDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ControlNumber.ToString

        End Function

#End Region

    End Class

End Namespace
