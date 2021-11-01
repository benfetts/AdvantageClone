Namespace Database.Procedures.ContractValueAdded

    <HideModuleName()> _
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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractValueAdded)

            Load = From ContractValueAdded In DbContext.GetQuery(Of Database.Entities.ContractValueAdded)
                   Select ContractValueAdded

        End Function
        Public Function LoadByContractID(ByVal DbContext As Database.DbContext, ByVal ContractID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractValueAdded)

            LoadByContractID = From ContractValueAdded In DbContext.GetQuery(Of Database.Entities.ContractValueAdded)
                               Where ContractValueAdded.ContractID = ContractID
                               Select ContractValueAdded

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.ContractValueAdded

            Try

                LoadByID = (From ContractValueAdded In DbContext.GetQuery(Of Database.Entities.ContractValueAdded)
                            Where ContractValueAdded.ID = ID
                            Select ContractValueAdded).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadDocumentsByContractID(ByVal DbContext As Database.DbContext, ByVal ContractID As Integer) As IEnumerable(Of AdvantageFramework.Database.Entities.Document)

            LoadDocumentsByContractID = From ContractValueAdded In DbContext.GetQuery(Of Database.Entities.ContractValueAdded)
                                        Where ContractValueAdded.ContractID = ContractID
                                        Select ContractValueAdded.Document

        End Function
        Public Function LoadDocumentsByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As IEnumerable(Of AdvantageFramework.Database.Entities.Document)

            LoadDocumentsByID = From ContractValueAdded In DbContext.GetQuery(Of Database.Entities.ContractValueAdded)
                                Where ContractValueAdded.ID = ID
                                Select ContractValueAdded.Document

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ContractValueAddeds.Add(ContractValueAdded)

                ErrorText = ContractValueAdded.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ContractValueAdded)

                ErrorText = ContractValueAdded.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Documents As IEnumerable(Of AdvantageFramework.Database.Entities.Document) = Nothing

            Try

                If IsValid Then

                    Documents = LoadDocumentsByID(DbContext, ContractValueAdded.ID)

                    DbContext.DeleteEntityObject(ContractValueAdded)

                    If Documents.Count > 0 Then

                        AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Documents)

                    End If

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
