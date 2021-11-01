Namespace ViewModels.Document

	Public Class UploadViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property IsValid As Boolean
		Public Property DocumentHasExpired As Boolean
		Public Property UploadedSucessfully As Boolean
		Public Property DocumentLevelSettingASPString As String
		Public Property ConnectionString As String
		Public Property UserCode As String
		Public Property Labels As Generic.List(Of AdvantageFramework.Database.Entities.Label)
		Public Property DocumentTypes As Generic.List(Of AdvantageFramework.Database.Entities.DataContextDocumentType)
		Public Property DocumentLevel As String
		Public Property DocumentSubLevel As String
		Public Property DocumentLevelProperties As String
		Public Property FileSizeMessage As String
		Public Property FileLinkMessage As String
		Public Property MaxFileSize As Long

#Region "  Form Entry"

		<Required>
		<System.ComponentModel.DisplayName("I want to upload a")>
		Public Property FileOrLink As String
		Public Property LinkName As String
		Public Property LinkURL As String
		<Required>
		<System.ComponentModel.DisplayName("File Type")>
		Public Property DocumentTypeID As Long
		<System.ComponentModel.DisplayName("Private")>
		Public Property IsPrivate As Boolean
		Public Property Description As String
		Public Property Keywords As String
		Public Property SelectedLabelIDs As Generic.List(Of Long)

#End Region

#End Region

#Region " Methods "

		Public Sub New()

			Labels = New Generic.List(Of AdvantageFramework.Database.Entities.Label)
			DocumentTypes = New Generic.List(Of AdvantageFramework.Database.Entities.DataContextDocumentType)
			SelectedLabelIDs = New Generic.List(Of Long)

		End Sub

#End Region

	End Class

End Namespace
