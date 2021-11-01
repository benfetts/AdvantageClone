Namespace Database.Entities

    <Table("IMP_JE_DETAIL")>
    Public Class ImportJournalEntryDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ImportID
            IDSeq
            GLAccount
            Amount
            Remark
            ClientCode
            DivisionCode
            ProductCode
            ExternalID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Column("ID")>
        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        Public Property ID() As Integer

        <Column("IMPORT_ID")>
        <Required>
        Public Property ImportID() As Integer

        <Column("IDSEQ", TypeName:="varchar")>
        <MaxLength(20)>
        Public Property IDSeq() As String

        <Column("GLACODE", TypeName:="varchar")>
        <MaxLength(100)>
        Public Property GLAccount() As String

        <Column("AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        Public Property Amount() As Nullable(Of Decimal)

        <Column("REMARK", TypeName:="varchar")>
        <MaxLength(150)>
        Public Property Remark() As String

        <Column("CL_CODE", TypeName:="varchar")>
        <MaxLength(100)>
        Public Property ClientCode() As String

        <Column("DIV_CODE", TypeName:="varchar")>
        <MaxLength(100)>
        Public Property DivisionCode() As String

        <Column("PRD_CODE", TypeName:="varchar")>
        <MaxLength(100)>
        Public Property ProductCode() As String

        <Column("EXTERNAL_ID")>
        Public Property ExternalID() As Nullable(Of Integer)

        <ForeignKey("ImportID")>
        Public Overridable Property ImportJournalEntry As Database.Entities.ImportJournalEntry

#End Region

#Region " Methods "

        Public Sub ClearBlankValues()

            If String.IsNullOrWhiteSpace(Me.GLAccount) Then

                Me.GLAccount = Nothing

            End If

            If String.IsNullOrWhiteSpace(Me.Remark) Then

                Me.Remark = Nothing

            End If

            If String.IsNullOrWhiteSpace(Me.ClientCode) Then

                Me.ClientCode = Nothing

            End If

            If String.IsNullOrWhiteSpace(Me.DivisionCode) Then

                Me.DivisionCode = Nothing

            End If

            If String.IsNullOrWhiteSpace(Me.ProductCode) Then

                Me.ProductCode = Nothing

            End If

        End Sub

#End Region

    End Class

End Namespace
