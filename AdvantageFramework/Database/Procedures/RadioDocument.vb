Namespace Database.Procedures.RadioDocument

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

		Public Function LoadByDocumentID(ByVal DbContext As Database.DbContext, ByVal DocumentID As Integer) As Database.Entities.RadioDocument

			Try

				LoadByDocumentID = (From RadioDocument In DbContext.GetQuery(Of Database.Entities.RadioDocument)
									Where RadioDocument.DocumentID = DocumentID
									Select RadioDocument).SingleOrDefault

			Catch ex As Exception
				LoadByDocumentID = Nothing
			End Try

		End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioDocument)

            Load = From RadioDocument In DbContext.GetQuery(Of Database.Entities.RadioDocument)
                   Select RadioDocument

        End Function

        Public Function LoadByOrderID(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RadioDocument)

            Try

                LoadByOrderID = From RadioDocument In DbContext.GetQuery(Of Database.Entities.RadioDocument)
                                Where RadioDocument.OrderNumber = OrderNumber
                                Select RadioDocument

            Catch ex As Exception
                LoadByOrderID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RadioDocument As AdvantageFramework.Database.Entities.RadioDocument) As Boolean

			'objects
			Dim Inserted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				DbContext.RadioDocuments.Add(RadioDocument)

				ErrorText = RadioDocument.ValidateEntity(IsValid)

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
		Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RadioDocument As AdvantageFramework.Database.Entities.RadioDocument) As Boolean

			'objects
			Dim Updated As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				DbContext.UpdateObject(RadioDocument)

				ErrorText = RadioDocument.ValidateEntity(IsValid)

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
		Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RadioDocument As AdvantageFramework.Database.Entities.RadioDocument) As Boolean

			'objects
			Dim Deleted As Boolean = False
			Dim IsValid As Boolean = True
			Dim ErrorText As String = ""

			Try

				If IsValid Then

					DbContext.DeleteEntityObject(RadioDocument)

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
