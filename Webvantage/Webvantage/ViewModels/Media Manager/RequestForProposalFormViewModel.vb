Namespace ViewModels.MediaManager

    Public Class RequestForProposalFormViewModel

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
        Public Property QueryString As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property ConnectionString As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property UserCode As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property Subject As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        <System.Web.Mvc.AllowHtml>
        Public Property Body As String

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DisplayName("Comment to Vendor")>
        Public Property CommentToVendor As String

        <System.ComponentModel.DataAnnotations.Required(),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.MultilineText),
        System.ComponentModel.DisplayName("Add Comment")>
        Public Property Comment As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property FilesUploaded As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property AgencyName As String

#End Region

#Region " Methods "

        Public Sub New()

            'PurchaseOrderFormDetails = New Generic.List(Of PurchaseOrderFormDetailViewModel)

        End Sub

#End Region

    End Class

End Namespace
