Namespace Database.Entities

    <Table("IMP_JE_HEADER")>
    Public Class ImportJournalEntry
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            IsOnHold
            ImportTemplateID
            UniqueID
            Description
            CreateDate
            PostPeriodCode
            GLSource
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("IMPORT_ID")>
        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        Public Property ID() As Integer

        <Column("BATCH_NAME", TypeName:="varchar")>
        <Required>
        <MaxLength(50)>
        Public Property BatchName() As String

        <Column("ON_HOLD")>
        <Required>
        Public Property IsOnHold() As Boolean

        <Column("TEMPLATE_ID")>
        <Required>
        Public Property ImportTemplateID() As Integer

        <Column("UNIQUE_ID", TypeName:="varchar")>
        <MaxLength(20)>
        Public Property TransactionID() As String

        <Column("DESCRIPTION", TypeName:="varchar")>
        <MaxLength(100)>
        Public Property Description() As String

        <Column("CREATE_DATE")>
        Public Property TransactionDate() As System.Nullable(Of Date)

        <Column("POSTPERIOD_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        Public Property PostPeriodCode() As String

        <Column("GL_SOURCE", TypeName:="varchar")>
        <MaxLength(2)>
        Public Property GLSource() As String

        Public Overridable Property ImportJournalEntryDetails As ICollection(Of Database.Entities.ImportJournalEntryDetail)

#End Region

#Region " Methods "

        Public Sub New()

            Me.ImportJournalEntryDetails = New HashSet(Of AdvantageFramework.Database.Entities.ImportJournalEntryDetail)

        End Sub

#End Region

    End Class

End Namespace
