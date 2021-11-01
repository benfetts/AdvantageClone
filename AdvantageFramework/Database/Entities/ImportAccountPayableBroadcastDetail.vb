Namespace Database.Entities

    <Table("IMP_AP_BROADCAST_DTL")>
    Public Class ImportAccountPayableBroadcastDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ImportAccountPayableMediaID
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
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("ID")>
        Public Property ID() As Integer
        <Required>
        <Column("IMP_AP_MEDIA_ID")>
        Public Property ImportAccountPayableMediaID() As Integer
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

        <ForeignKey("ImportAccountPayableMediaID")>
        Public Overridable Property ImportAccountPayableMedia As Database.Entities.ImportAccountPayableMedia

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
