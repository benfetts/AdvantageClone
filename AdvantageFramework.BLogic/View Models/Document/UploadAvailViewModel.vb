Namespace ViewModels.Document

    Public Class UploadAvailViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DocumentDescription As String
        Public Property IsValid As Boolean
        Public Property DocumentHasExpired As Boolean
        Public Property UploadedSucessfully As Boolean
        Public Property ConnectionString As String
        Public Property UserCode As String

#Region "  Form Entry"



#End Region

#End Region

#Region " Methods "

        Public Sub New()

            DocumentDescription = "Avail Files"

        End Sub

#End Region

    End Class

End Namespace
