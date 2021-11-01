Namespace Database.Procedures.TVDocument

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

		Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As Database.Entities.TVDocument

			Try

				LoadByDocumentID = (From TVDocument In DbContext.GetQuery(Of Database.Entities.TVDocument)
									Where TVDocument.DocumentID = DocumentID
									Select TVDocument).SingleOrDefault

			Catch ex As Exception
				LoadByDocumentID = Nothing
			End Try

		End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVDocument)

            Load = From TVDocument In DbContext.GetQuery(Of Database.Entities.TVDocument)
                   Select TVDocument

        End Function

        Public Function LoadByOrderID(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVDocument)

            Try

                LoadByOrderID = From TVDocument In DbContext.GetQuery(Of Database.Entities.TVDocument)
                                Where TVDocument.OrderNumber = OrderNumber
                                Select TVDocument

            Catch ex As Exception
                LoadByOrderID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TVDocument As AdvantageFramework.Database.Entities.TVDocument) As Boolean

			'objects
			Dim Inserted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				DbContext.TVDocuments.Add(TVDocument)

				ErrorText = TVDocument.ValidateEntity(IsValid)

				If IsValid Then

					DbContext.SaveChanges()

					Inserted = True

				Else

					AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

				End If

			Catch ex As Exception
				Inserted = False
			Finally
				Insert = Inserted
			End Try

		End Function
		Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TVDocument As AdvantageFramework.Database.Entities.TVDocument) As Boolean

			'objects
			Dim Updated As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				DbContext.UpdateObject(TVDocument)

				ErrorText = TVDocument.ValidateEntity(IsValid)

				If IsValid Then

					DbContext.SaveChanges()

					Updated = True

				Else

					AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

				End If

			Catch ex As Exception
				Updated = False
			Finally
				Update = Updated
			End Try

		End Function
		Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TVDocument As AdvantageFramework.Database.Entities.TVDocument) As Boolean

			'objects
			Dim Deleted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				If IsValid Then

					DbContext.DeleteEntityObject(TVDocument)

					DbContext.SaveChanges()

					Deleted = True

				Else

					AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

				End If

			Catch ex As Exception
				Deleted = False
			Finally
				Delete = Deleted
			End Try

		End Function
		Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

			'objects
			Dim Deleted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				If IsValid Then

					DbContext.DeleteEntityObject(LoadByDocumentID(DbContext, DocumentID))

					DbContext.SaveChanges()

					Deleted = True

				Else

					AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

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
