Namespace ViewModels.MediaManager

    Public Class OrderFormViewModel

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

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property HasRelatedDocuments As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property QueryString As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property ConnectionString As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property UserCode As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property MediaManagerGeneratedReportID As Integer

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property ContactName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property ContactNumber As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property MediaType As String

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:000000}")>
        Public Property OrderNumber As Integer

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Quote")>
        Public Property IsQuote As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property IsNetAmount As Boolean

		<System.ComponentModel.DataAnnotations.Required(),
		System.ComponentModel.DisplayName("Cost Authorized By"),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property AuthorizedBy As String

        <System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.MultilineText)>
        Public Property Notes As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Client Name")>
        Public Property ClientName As String

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.MultilineText),
         System.ComponentModel.DisplayName("Order Comments")>
        Public Property OrderComments As String

        <System.ComponentModel.DisplayName("I agree to Terms of Agreement")>
        Public Property AcceptTermsOfAgreement As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.MultilineText),
        System.ComponentModel.DisplayName("Terms Of Agreement")>
        Public Property TermsOfAgreement As String

        Public Property OrderFormDetails As Generic.List(Of OrderFormDetailViewModel)

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property AgencyName As String

#End Region

#Region " Methods "

        Public Sub New()

            OrderFormDetails = New Generic.List(Of OrderFormDetailViewModel)

        End Sub

#End Region

    End Class

End Namespace
