Namespace ViewModels.MediaManager

    Public Class OrderFormDetailViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property HasBeenSubmitted As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property HasRelatedDocuments As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property InDifferentOrderState As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property IsNetAmount As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:000000}")>
        Public Property OrderNumber As Integer

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:0000}")>
        Public Property LineNumber As Short

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:000}"),
         System.ComponentModel.DisplayName("Revision Number")>
        Public Property RevisionNumber As Short

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Cancellation Y/N")>
        Public Property IsCancellation As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.Text),
         System.ComponentModel.DisplayName("Gross Amount")>
        Public Property GrossAmount As Nullable(Of Decimal)

        <System.ComponentModel.DataAnnotations.Required(),
         System.ComponentModel.DisplayName("Agency Commission"),
        System.ComponentModel.DataAnnotations.DisplayFormat(ApplyFormatInEditMode:=True, DataFormatString:="{0:P2}", ConvertEmptyStringToNull:=False)>
        Public Property CommissionPercentage() As Double

        <System.ComponentModel.DataAnnotations.Required(),
         System.ComponentModel.DisplayName("Net Cost"),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.Text)>
        Public Property NetAmount As Decimal

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Run Dates")>
        Public Property RunDates As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Charge To")>
        Public Property ChargeToName As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Charge To Address")>
        Public Property ChargeToAddress As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Charge To Address 2")>
        Public Property ChargeToAddress2 As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Charge To City")>
        Public Property ChargeToCity As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Charge To State")>
        Public Property ChargeToState As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Charge To Zip")>
        Public Property ChargeToZip As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Card Number"),
         System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:####-####-####-####}")>
        Public Property CardNumber As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Expiration Date"),
         System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:d}")>
        Public Property CardExpirationDate As Date

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("CVC")>
        Public Property CardCVCCode As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property CurrencyCode As String

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.Text)>
        Public Property CurrencySymbol As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
