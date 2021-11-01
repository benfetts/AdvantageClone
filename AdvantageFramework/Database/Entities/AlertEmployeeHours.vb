Namespace Database.Entities

    <Table("ALERT_EMP_HOURS")>
    Public Class AlertEmployeeHour
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            AlertID
            EmployeeCode
            PercentComplete
            CompletedDate
            HoursAllowed
            AlertStateID
            AlertTemplateID

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        Public Property ID() As Integer

        <Required>
        <Column("ALERT_ID")>
        Public Property AlertID() As Integer

        <Required>
        <MaxLength(6)>
        <Column("EMP_CODE")>
        Public Property EmployeeCode() As String

        <Column("PERC_COMPLETE")>
        Public Property PercentComplete() As Nullable(Of Short)

        <Column("COMPLETED_DATE")>
        Public Property CompletedDate() As Nullable(Of Date)

        <Column("HOURS_ALLOWED")>
        Public Property HoursAllowed() As Nullable(Of Decimal)

        <Column("ALERT_STATE_ID")>
        Public Property AlertStateID() As Nullable(Of Integer)

        <Column("ALRT_NOTIFY_HDR_ID")>
        Public Property AlertTemplateID() As Nullable(Of Integer)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

