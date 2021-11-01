Namespace DTO.GeneralLedger.JournalEntry

    Public Class RecurringJournalEntryLog
        Inherits AdvantageFramework.DTO.BaseClass


#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ControlNumber
            UserCode
            PostPeriodCode
            EnteredDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ControlNumber() As Integer
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property UserCode() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PostPeriodCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EnteredDate() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ControlNumber.ToString

        End Function

#End Region

    End Class

End Namespace
