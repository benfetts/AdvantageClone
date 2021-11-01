Namespace DTO.GeneralLedger.JournalEntry

    Public Class RecurringJournalEntryItem
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ControlNumber
            Description
            Cycle
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ControlNumber() As Integer
        <Required>
        <MaxLength(45)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Cycle() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ControlNumber = 0
            Me.Description = String.Empty
            Me.Cycle = Nothing
            Me.IsInactive = False

        End Sub
        Public Sub New(GeneralLedgerRecurringEntry As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntry)

            Me.ControlNumber = GeneralLedgerRecurringEntry.ControlNumber
            Me.Description = GeneralLedgerRecurringEntry.Description
            Me.Cycle = GeneralLedgerRecurringEntry.Cycle.Name
            Me.IsInactive = If(GeneralLedgerRecurringEntry.IsInactive.GetValueOrDefault(0) = 1, True, False)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ControlNumber.ToString

        End Function

#End Region

    End Class

End Namespace