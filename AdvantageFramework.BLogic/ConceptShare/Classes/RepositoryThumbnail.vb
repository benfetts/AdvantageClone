Namespace ConceptShare.Classes

	<Serializable()>
	Public Class RepositoryThumbnail

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property DocumentID As Integer
		Public Property Filename As String
		Public Property MimeType As String
		Public Property RepositoryFilename As String
		Public Property FileBytes As Byte()
		Private Property _Base64ImageURL As String
		Public Property Base64ImageURL() As String
			Get

				If FileBytes IsNot Nothing AndAlso FileBytes.Length > 0 Then

					_Base64ImageURL = String.Format("data:{0};base64,{1}", MimeType.ToLower, Convert.ToBase64String(FileBytes))

				Else

					_Base64ImageURL = String.Empty

				End If

				Return _Base64ImageURL

			End Get
			Set(value As String)

				_Base64ImageURL = value

			End Set
		End Property
        Public Property IsImage As Boolean
        Public Property Thumbnail As Byte()
        Public Property HasThumbnail As Boolean

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
