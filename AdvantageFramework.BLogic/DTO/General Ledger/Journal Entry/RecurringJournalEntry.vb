Namespace DTO.GeneralLedger.JournalEntry

    Public Class RecurringJournalEntry
        Inherits AdvantageFramework.DTO.BaseClass

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
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ControlNumber() As Integer
        <Required>
        <MaxLength(45)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property EnteredDate() As Nullable(Of Date)
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CycleCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ReverseFlag() As Boolean
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property UserCode() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LastPostPeriodCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LastPostingDate() As Nullable(Of Date)
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LastPostingUserCode() As String
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ModifiedFlag() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ModifiedDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsVoided() As Boolean
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property StartingPostPeriodCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property NumberOfPostings() As Nullable(Of Integer)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property UnlimitedPostings() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property LegacyEntry() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ControlNumber = 0
            Me.Description = String.Empty
            Me.EnteredDate = Now
            Me.CycleCode = Nothing
            Me.ReverseFlag = False
            Me.UserCode = Nothing
            Me.LastPostPeriodCode = Nothing
            Me.LastPostingDate = Nothing
            Me.LastPostingUserCode = Nothing
            Me.ModifiedFlag = False
            Me.ModifiedDate = Nothing
            Me.IsInactive = False
            Me.IsVoided = False
            Me.StartingPostPeriodCode = Nothing
            Me.NumberOfPostings = Nothing
            Me.UnlimitedPostings = True
            Me.LegacyEntry = False

        End Sub
        Public Sub New(GeneralLedgerRecurringEntry As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntry)

            Me.ControlNumber = GeneralLedgerRecurringEntry.ControlNumber
            Me.Description = GeneralLedgerRecurringEntry.Description
            Me.EnteredDate = GeneralLedgerRecurringEntry.EnteredDate
            Me.CycleCode = GeneralLedgerRecurringEntry.CycleCode
            Me.ReverseFlag = If(GeneralLedgerRecurringEntry.ReverseFlag = "1", True, False)
            Me.UserCode = GeneralLedgerRecurringEntry.UserCode
            Me.LastPostPeriodCode = GeneralLedgerRecurringEntry.LastPostPeriodCode
            Me.LastPostingDate = GeneralLedgerRecurringEntry.LastPostingDate
            Me.LastPostingUserCode = GeneralLedgerRecurringEntry.LastPostingUserCode
            Me.ModifiedFlag = If(GeneralLedgerRecurringEntry.ModifiedFlag = "1", True, False)
            Me.ModifiedDate = GeneralLedgerRecurringEntry.ModifiedDate
            Me.IsInactive = If(GeneralLedgerRecurringEntry.IsInactive.GetValueOrDefault(0) = 1, True, False)
            Me.IsVoided = If(GeneralLedgerRecurringEntry.IsVoided.GetValueOrDefault(0) = 1, True, False)
            Me.StartingPostPeriodCode = GeneralLedgerRecurringEntry.StartingPostPeriodCode
            Me.NumberOfPostings = GeneralLedgerRecurringEntry.NumberOfPostings
            Me.UnlimitedPostings = GeneralLedgerRecurringEntry.UnlimitedPostings
            Me.LegacyEntry = GeneralLedgerRecurringEntry.LegacyEntry

        End Sub
        Public Sub SaveToEntity(ByRef GeneralLedgerRecurringEntry As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntry)

            'GeneralLedgerRecurringEntry.ControlNumber = Me.ControlNumber
            GeneralLedgerRecurringEntry.Description = Me.Description
            GeneralLedgerRecurringEntry.EnteredDate = Me.EnteredDate
            GeneralLedgerRecurringEntry.CycleCode = Me.CycleCode
            GeneralLedgerRecurringEntry.ReverseFlag = If(Me.ReverseFlag, "1", Nothing)
            GeneralLedgerRecurringEntry.UserCode = Me.UserCode
            GeneralLedgerRecurringEntry.LastPostPeriodCode = Me.LastPostPeriodCode
            GeneralLedgerRecurringEntry.LastPostingDate = Me.LastPostingDate
            GeneralLedgerRecurringEntry.LastPostingUserCode = Me.LastPostingUserCode
            GeneralLedgerRecurringEntry.ModifiedFlag = If(Me.ModifiedFlag, "1", Nothing)
            GeneralLedgerRecurringEntry.ModifiedDate = Me.ModifiedDate
            GeneralLedgerRecurringEntry.IsInactive = If(Me.IsInactive, 1, 0)
            GeneralLedgerRecurringEntry.IsVoided = If(Me.IsVoided, 1, Nothing)
            GeneralLedgerRecurringEntry.StartingPostPeriodCode = Me.StartingPostPeriodCode
            GeneralLedgerRecurringEntry.NumberOfPostings = Me.NumberOfPostings
            GeneralLedgerRecurringEntry.UnlimitedPostings = Me.UnlimitedPostings
            GeneralLedgerRecurringEntry.LegacyEntry = Me.LegacyEntry

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ControlNumber.ToString

        End Function

#End Region

    End Class

End Namespace