Namespace Database.Procedures.MagazineDocument

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

        Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As Database.Entities.MagazineDocument

            Try

                LoadByDocumentID = (From MagazineDocument In DbContext.GetQuery(Of Database.Entities.MagazineDocument)
                                    Where MagazineDocument.DocumentID = DocumentID
                                    Select MagazineDocument).SingleOrDefault

            Catch ex As Exception
                LoadByDocumentID = Nothing
            End Try

        End Function

        Public Function LoadByOrderID(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MagazineDocument)

            Try

                LoadByOrderID = From MagazineDocument In DbContext.GetQuery(Of Database.Entities.MagazineDocument)
                                Where MagazineDocument.OrderNumber = OrderNumber
                                Select MagazineDocument

            Catch ex As Exception
                LoadByOrderID = Nothing
            End Try

        End Function

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MagazineDocument)

			Load = From MagazineDocument In DbContext.GetQuery(Of Database.Entities.MagazineDocument)
				   Select MagazineDocument

		End Function
		Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MagazineDocument As AdvantageFramework.Database.Entities.MagazineDocument) As Boolean

			'objects
			Dim Inserted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				DbContext.MagazineDocuments.Add(MagazineDocument)

				ErrorText = MagazineDocument.ValidateEntity(IsValid)

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
		Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MagazineDocument As AdvantageFramework.Database.Entities.MagazineDocument) As Boolean

			'objects
			Dim Updated As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				DbContext.UpdateObject(MagazineDocument)

				ErrorText = MagazineDocument.ValidateEntity(IsValid)

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
		Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MagazineDocument As AdvantageFramework.Database.Entities.MagazineDocument) As Boolean

			'objects
			Dim Deleted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				If IsValid Then

					DbContext.DeleteEntityObject(MagazineDocument)

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
