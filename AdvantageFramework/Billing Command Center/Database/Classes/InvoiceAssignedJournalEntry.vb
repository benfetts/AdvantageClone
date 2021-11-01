Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class InvoiceAssignedJournalEntry

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLTransaction
            GLSequenceNumber
            GLACode
            GLDescription
            PostPeriodCode
            Amount
            Remark
            ClientCode
            DivisionCode
            ProductCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property GLTransaction() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="GL SEQ")>
        Public Property GLSequenceNumber() As Short

        Public Property GLACode() As String

        Public Property GLDescription() As String

        Public Property PostPeriodCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount() As Double

        Public Property Remark() As String

        Public Property ClientCode() As String

        Public Property DivisionCode() As String

        Public Property ProductCode() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.GLTransaction.ToString

        End Function

#End Region

    End Class

End Namespace
