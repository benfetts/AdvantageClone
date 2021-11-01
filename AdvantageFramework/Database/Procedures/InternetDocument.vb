Namespace Database.Procedures.InternetDocument

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

		Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As Database.Entities.InternetDocument

			Try

				LoadByDocumentID = (From InternetDocument In DbContext.GetQuery(Of Database.Entities.InternetDocument)
									Where InternetDocument.DocumentID = DocumentID
									Select InternetDocument).SingleOrDefault

			Catch ex As Exception
				LoadByDocumentID = Nothing
			End Try

		End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetDocument)

            Load = From InternetDocument In DbContext.GetQuery(Of Database.Entities.InternetDocument)
                   Select InternetDocument

        End Function

        Public Function LoadByOrderID(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InternetDocument)

            Try

                LoadByOrderID = From InternetDocument In DbContext.GetQuery(Of Database.Entities.InternetDocument)
                                Where InternetDocument.OrderNumber = OrderNumber
                                Select InternetDocument

            Catch ex As Exception
                LoadByOrderID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InternetDocument As AdvantageFramework.Database.Entities.InternetDocument) As Boolean

			'objects
			Dim Inserted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				DbContext.InternetDocuments.Add(InternetDocument)

				ErrorText = InternetDocument.ValidateEntity(IsValid)

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
		Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InternetDocument As AdvantageFramework.Database.Entities.InternetDocument) As Boolean

			'objects
			Dim Updated As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				DbContext.UpdateObject(InternetDocument)

				ErrorText = InternetDocument.ValidateEntity(IsValid)

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
		Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InternetDocument As AdvantageFramework.Database.Entities.InternetDocument) As Boolean

			'objects
			Dim Deleted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				If IsValid Then

					DbContext.DeleteEntityObject(InternetDocument)

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
