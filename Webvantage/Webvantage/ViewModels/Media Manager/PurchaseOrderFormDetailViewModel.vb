Namespace ViewModels.MediaManager

    Public Class PurchaseOrderFormDetailViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property HasBeenSubmitted As Boolean

        '<System.ComponentModel.DataAnnotations.Editable(False)>
        'Public Property HasRelatedDocuments As Boolean

        '<System.ComponentModel.DataAnnotations.Editable(False)>
        'Public Property InDifferentOrderState As Boolean

        '<System.ComponentModel.DataAnnotations.Editable(False),
        'System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:0000}")>
        'Public Property LineNumber As Short

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Description")>
        Public Property Description As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Client Name")>
        Public Property ClientName As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Job Number")>
        Public Property JobNumber As Integer?

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Job Component Number")>
        Public Property JobComponentNumber As Short?

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Quantity")>
        Public Property Quantity As Integer?

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.Currency),
         System.ComponentModel.DisplayName("Rate")>
        Public Property Rate As Nullable(Of Decimal)

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.Currency),
         System.ComponentModel.DisplayName("Amount")>
        Public Property Amount As Nullable(Of Decimal)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
