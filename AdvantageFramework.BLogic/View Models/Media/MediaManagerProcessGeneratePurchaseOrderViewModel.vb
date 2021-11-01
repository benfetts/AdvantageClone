Namespace ViewModels.Media

    Public Class MediaManagerProcessGeneratePurchaseOrderViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaManagerGeneratePurchaseOrderVendorContacts As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact)

        Public Property DefaultEmailSubject As String

        Public Property DefaultEmailBody As String

        Public Property DefaultCCSender As Boolean

        Public Property DefaultUploadDocumentManager As Boolean

        Public Property DefaultUploadAndSignDocumentWhenSubmitted As Boolean

        Public Property DefaultEmailExecutedCopyToVendor As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            MediaManagerGeneratePurchaseOrderVendorContacts = New Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact)

        End Sub

#End Region

    End Class

End Namespace