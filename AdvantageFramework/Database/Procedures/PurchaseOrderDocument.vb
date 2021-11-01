Namespace Database.Procedures.PurchaseOrderDocument

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

        Public Function LoadByDocumentID(DbContext As Database.DbContext, DocumentID As Integer) As Database.Entities.PurchaseOrderDocument

            LoadByDocumentID = (From PurchaseOrderDocument In DbContext.GetQuery(Of Database.Entities.PurchaseOrderDocument)
                                Where PurchaseOrderDocument.DocumentID = DocumentID
                                Select PurchaseOrderDocument).SingleOrDefault

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderDocument)

            Load = From PurchaseOrderDocument In DbContext.GetQuery(Of Database.Entities.PurchaseOrderDocument)
                   Select PurchaseOrderDocument

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, PurchaseOrderDocument As AdvantageFramework.Database.Entities.PurchaseOrderDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.PurchaseOrderDocuments.Add(PurchaseOrderDocument)

                ErrorText = PurchaseOrderDocument.ValidateEntity(IsValid)

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, PurchaseOrderDocument As AdvantageFramework.Database.Entities.PurchaseOrderDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PurchaseOrderDocument)

                ErrorText = PurchaseOrderDocument.ValidateEntity(IsValid)

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, PurchaseOrderDocument As AdvantageFramework.Database.Entities.PurchaseOrderDocument) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(PurchaseOrderDocument)

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As Boolean

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
