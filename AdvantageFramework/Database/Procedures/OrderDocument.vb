Namespace Database.Procedures.OrderDocument

	<HideModuleName()>
	Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Public Function LoadCurrentByOrderNumbers(DbContext As AdvantageFramework.Database.DbContext,
												  OrderNumbers As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.OrderDocument)

			'objects
			Dim DocumentIDs() As Integer = Nothing

			If OrderNumbers IsNot Nothing AndAlso OrderNumbers.Count > 0 Then

				DocumentIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT DOCUMENT_ID FROM dbo.V_ORDER_DOCUMENT WHERE ORDER_NBR IN (" & String.Join(",", OrderNumbers.ToArray) & ")").ToArray

			Else

				DocumentIDs = New Integer() {(0)}

			End If

			LoadCurrentByOrderNumbers = From OrderDocument In DbContext.GetQuery(Of Database.Views.OrderDocument)
										Where DocumentIDs.Any(Function(DocumentID) DocumentID = OrderDocument.DocumentID)
										Select OrderDocument

		End Function
		Public Function LoadByOrderNumber(DbContext As Database.DbContext, OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.OrderDocument)

			LoadByOrderNumber = From OrderDocument In DbContext.GetQuery(Of Database.Views.OrderDocument)
								Where OrderDocument.OrderNumber = OrderNumber
								Select OrderDocument

		End Function
		Public Function LoadByDocumentID(DbContext As Database.DbContext, DocumentID As Integer) As Database.Views.OrderDocument

			Try

				LoadByDocumentID = (From OrderDocument In DbContext.GetQuery(Of Database.Views.OrderDocument)
									Where OrderDocument.DocumentID = DocumentID
									Select OrderDocument).SingleOrDefault

			Catch ex As Exception
				LoadByDocumentID = Nothing
			End Try

		End Function
		Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.OrderDocument)

			Load = From OrderDocument In DbContext.GetQuery(Of Database.Views.OrderDocument)
				   Select OrderDocument

		End Function
		Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

			'objects
			Dim Deleted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""
			Dim OrderDocument As AdvantageFramework.Database.Views.OrderDocument = Nothing

			Try

				OrderDocument = LoadByDocumentID(DbContext, DocumentID)

				If OrderDocument IsNot Nothing Then

					If OrderDocument.MediaType = "M" Then

						Deleted = AdvantageFramework.Database.Procedures.MagazineDocument.Delete(DbContext, DocumentID)

					ElseIf OrderDocument.MediaType = "N" Then

						Deleted = AdvantageFramework.Database.Procedures.NewspaperDocument.Delete(DbContext, DocumentID)

					ElseIf OrderDocument.MediaType = "I" Then

						Deleted = AdvantageFramework.Database.Procedures.InternetDocument.Delete(DbContext, DocumentID)

					ElseIf OrderDocument.MediaType = "O" Then

						Deleted = AdvantageFramework.Database.Procedures.OutOfHomeDocument.Delete(DbContext, DocumentID)

					ElseIf OrderDocument.MediaType = "R" Then

						Deleted = AdvantageFramework.Database.Procedures.RadioDocument.Delete(DbContext, DocumentID)

					ElseIf OrderDocument.MediaType = "T" Then

						Deleted = AdvantageFramework.Database.Procedures.TVDocument.Delete(DbContext, DocumentID)

					End If

				End If

			Catch ex As Exception
				Deleted = False
			Finally
				Delete = Deleted
			End Try

		End Function

#End Region

	End Module

End Namespace
