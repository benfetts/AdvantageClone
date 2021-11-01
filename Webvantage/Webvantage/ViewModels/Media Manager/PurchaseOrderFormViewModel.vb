Namespace ViewModels.MediaManager

    Public Class PurchaseOrderFormViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property IsValid As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property InDifferentOrderState As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property HasBeenSubmitted As Boolean

        '<System.ComponentModel.DataAnnotations.Editable(False)>
        'Public Property HasRelatedDocuments As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property QueryString As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property ConnectionString As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property UserCode As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property MediaManagerGeneratedPOReportID As Integer

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property ContactName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property ContactNumber As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("PO Number"),
         System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:000000}")>
        Public Property PONumber As Integer

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Vendor Code")>
        Public Property VendorCode As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Vendor Name")>
        Public Property VendorName As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Description")>
        Public Property PODescription As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Issue Date"),
         System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:d}")>
        Public Property IssueDate As Date

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Due Date"),
         System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:d}")>
        Public Property DueDate As Nullable(Of Date)

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Originator")>
        Public Property Originator As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.Currency),
         System.ComponentModel.DisplayName("PO Total")>
        Public Property POTotal As Decimal

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:000}"),
         System.ComponentModel.DisplayName("Revision Number")>
        Public Property RevisionNumber As Short?

        <System.ComponentModel.DataAnnotations.Required(),
        System.ComponentModel.DisplayName("Cost Authorized By"),
        System.ComponentModel.DataAnnotations.MaxLength(100)>
        Public Property AuthorizedBy As String

        <System.ComponentModel.DisplayName("I agree to Terms of Agreement")>
        Public Property AcceptTermsOfAgreement As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.MultilineText),
        System.ComponentModel.DisplayName("Terms Of Agreement")>
        Public Property TermsOfAgreement As String

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
        Public Property AgencyName As String

        Public Property PurchaseOrderFormDetails As Generic.List(Of PurchaseOrderFormDetailViewModel)

#End Region

#Region " Methods "

        Public Sub New()

            PurchaseOrderFormDetails = New Generic.List(Of PurchaseOrderFormDetailViewModel)

        End Sub

#End Region

    End Class

End Namespace
