Namespace Database.Entities

    <Table("AP_TV_BROADCAST_DTL")>
    Public Class AccountPayableTVBroadcastDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            AccountPayableID
            AccountPayableSequenceNumber
            OrderNumber
            LineNumber
            RunDate
            DayOfWeek
            TimeOfDay
            Length
            AdNumber
            NetRate
            GrossRate
            Piggyback
            ProgramName
            NetworkID
            PackageCode
            IsApproved
            ApprovedBy
            ApprovedDate
            Comment

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("DTL_ID")>
        Public Property ID() As Integer
        <Required>
        <Column("AP_ID")>
        Public Property AccountPayableID() As Integer
        <Required>
        <Column("AP_SEQ")>
        Public Property AccountPayableSequenceNumber() As Short
        <Required>
        <Column("ORDER_NBR")>
        Public Property OrderNumber() As Integer
        <Column("ORDER_LINE_NBR")>
        Public Property OrderLineNumber() As Short?
        <Required>
        <Column("RUN_DATE")>
        Public Property RunDate() As Date
        <Column("DAY_OF_WEEK")>
        Public Property DayOfWeek() As Short?
        <Required>
        <Column("TIME_OF_DAY")>
        Public Property TimeOfDay() As TimeSpan
        <Column("LENGTH")>
        Public Property Length() As Short
        <MaxLength(30)>
        <Column("AD_NUMBER", TypeName:="varchar")>
        Public Property AdNumber() As String
        <Column("NET_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property NetRate() As Decimal
        <Column("GROSS_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property GrossRate() As Decimal
        <Column("PIGGYBACK")>
        Public Property Piggyback() As Integer?
        <MaxLength(40)>
        <Column("PROGRAM_NAME", TypeName:="varchar")>
        Public Property ProgramName() As String
        <MaxLength(10)>
        <Column("NETWORK_ID", TypeName:="varchar")>
        Public Property NetworkID() As String
        <Column("PACKAGE_CODE")>
        Public Property PackageCode() As Integer?
        <Column("APPROVED")>
        Public Property IsApproved() As Short?
        <MaxLength(6)>
        <Column("APPROVED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ApprovedBy() As String
        <Column("APPROVED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ApprovedDate() As Date?
        <MaxLength(254)>
        <Column("COMMENT", TypeName:="varchar")>
        Public Property Comment() As String

        <NotMapped>
        Public ReadOnly Property HourMinute As Integer
            Get
                If Me.TimeOfDay.Hours < 3 Then
                    HourMinute = (Me.TimeOfDay.Hours + 24) * 100 + Me.TimeOfDay.Minutes
                Else
                    HourMinute = Me.TimeOfDay.Hours * 100 + Me.TimeOfDay.Minutes
                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
