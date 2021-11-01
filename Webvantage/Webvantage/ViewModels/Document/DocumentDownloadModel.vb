Namespace ViewModels.Document

    Public Class DocumentDownloadModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property InvalidEmployee As Boolean
        Public Property DocumentHasExpired As Boolean
        Public Property IsValid As Boolean
        Public Property FileName As String
        Public Property QueryString As String

        Public Property DocumentDownloadDetailModels As Generic.List(Of DocumentDownloadDetailModel)

#End Region

#Region " Methods "

        Public Sub New()

            DocumentDownloadDetailModels = New Generic.List(Of DocumentDownloadDetailModel)

        End Sub

#End Region

    End Class

End Namespace
