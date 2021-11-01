Namespace DTO.GeneralLedger.JournalEntry

    Public Class RecurringJournalEntryPost
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ControlNumber
            Description
            ControlAmount
            NumberOfPostings
            NumberRemaining
            UnlimitedPostings
            CreateJournalEntry
            JournalEntryCreatedForPostPeriod
            DateCreated
            CreatedByUserCode
            StartingPostPeriodCode
            Show
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ControlNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2")>
        Public Property ControlAmount() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property NumberOfPostings() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property NumberRemaining() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property UnlimitedPostings() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Create J/E")>
        Public Property CreateJournalEntry() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="J/E Created for Post Period", IsReadOnlyColumn:=True)>
        Public Property JournalEntryCreatedForPostPeriod() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property DateCreated() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Created By", IsReadOnlyColumn:=True)>
        Public Property CreatedByUserCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property StartingPostPeriodCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property Show() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ControlNumber = 0
            Me.Description = String.Empty
            Me.ControlAmount = 0
            Me.NumberOfPostings = Nothing
            Me.NumberRemaining = 0
            Me.UnlimitedPostings = False
            Me.CreateJournalEntry = False
            Me.JournalEntryCreatedForPostPeriod = False
            Me.DateCreated = Nothing
            Me.CreatedByUserCode = String.Empty
            Me.StartingPostPeriodCode = String.Empty
            Me.Show = False

        End Sub
        Public Sub New(GeneralLedgerRecurringEntry As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntry, DbContext As AdvantageFramework.Database.DbContext, PostPeriod As AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)

            Dim CurrentNumberOfPostings As Integer = 0
            Dim LastPostedDate As Date = Date.MinValue
            Dim SelectedPostPeriodDate As Date = Date.MinValue

            Me.ControlNumber = GeneralLedgerRecurringEntry.ControlNumber
            Me.Description = GeneralLedgerRecurringEntry.Description & " - RJ:" & StringUtilities.PadWithCharacter(Me.ControlNumber, 6, "0", True)
            Me.ControlAmount = If(GeneralLedgerRecurringEntry.GeneralLedgerRecurringEntryDetails IsNot Nothing, GeneralLedgerRecurringEntry.GeneralLedgerRecurringEntryDetails.Where(Function(Entity) Entity.Amount > 0).Sum(Function(Entity) Entity.Amount.GetValueOrDefault(0)), 0)
            Me.NumberOfPostings = GeneralLedgerRecurringEntry.NumberOfPostings
            Me.UnlimitedPostings = GeneralLedgerRecurringEntry.UnlimitedPostings

            If GeneralLedgerRecurringEntry.LegacyEntry Then

                Me.NumberRemaining = Integer.MaxValue

            Else

                If Me.UnlimitedPostings Then

                    Me.NumberRemaining = Integer.MaxValue

                Else

                    CurrentNumberOfPostings = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.GLRJELOG WHERE GLRLCNTRL = {0}", ControlNumber)).First

                    Me.NumberRemaining = Me.NumberOfPostings.GetValueOrDefault(0) - CurrentNumberOfPostings

                End If

            End If

            Me.JournalEntryCreatedForPostPeriod = (DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.GLRJELOG WHERE GLRLCNTRL = {0} AND GLRLPP = '{1}'", ControlNumber, PostPeriod.Code)).First > 0)

            If Me.JournalEntryCreatedForPostPeriod Then

                Me.CreateJournalEntry = False

            Else

                Me.CreateJournalEntry = True

            End If

            Me.DateCreated = GeneralLedgerRecurringEntry.LastPostingDate

            If GeneralLedgerRecurringEntry.Cycle IsNot Nothing Then

                If GeneralLedgerRecurringEntry.LastPostPeriod IsNot Nothing Then

                    LastPostedDate = New Date(GeneralLedgerRecurringEntry.LastPostPeriod.Year, GeneralLedgerRecurringEntry.LastPostPeriod.Month.GetValueOrDefault(1), 1)
                    SelectedPostPeriodDate = New Date(PostPeriod.Year, PostPeriod.Month.GetValueOrDefault(1), 1)

                    If GeneralLedgerRecurringEntry.Cycle.Type = "A" Then

                        If DateDiff(DateInterval.Month, LastPostedDate, SelectedPostPeriodDate) >= 12 Then

                            Me.Show = True

                        Else

                            Me.Show = False

                        End If

                    ElseIf GeneralLedgerRecurringEntry.Cycle.Type = "Q" Then

                        If DateDiff(DateInterval.Month, LastPostedDate, SelectedPostPeriodDate) >= 3 Then

                            Me.Show = True

                        Else

                            Me.Show = False

                        End If

                    Else

                        Me.Show = True

                    End If

                Else

                    Me.Show = True

                End If

            Else

                Me.Show = True

            End If

            Me.CreatedByUserCode = GeneralLedgerRecurringEntry.LastPostingUserCode

            If GeneralLedgerRecurringEntry.LegacyEntry Then

                Me.StartingPostPeriodCode = PostPeriod.Code

            Else

                Me.StartingPostPeriodCode = GeneralLedgerRecurringEntry.StartingPostPeriodCode

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ControlNumber.ToString

        End Function

#End Region

    End Class

End Namespace