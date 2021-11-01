Namespace Database.Entities

    <Table("PURCHASE_ORDER_DOCUMENT")>
    Public Class PurchaseOrderDocument
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentID
            Number
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
        <Column("DOCUMENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DocumentID() As Integer
        <Required>
        <Column("PO_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Number() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.DocumentID.ToString & " - " & Me.Number.ToString

        End Function

#End Region

    End Class

End Namespace
