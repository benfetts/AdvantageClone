﻿Namespace Database.Procedures.ImportAccountPayableMedia

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

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.ImportAccountPayableMedia

            Try

                LoadByID = (From ImportAccountPayableMedia In DbContext.GetQuery(Of Database.Entities.ImportAccountPayableMedia)
                            Where ImportAccountPayableMedia.ID = ID
                            Select ImportAccountPayableMedia).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportAccountPayableMedia)

            Load = From ImportAccountPayableMedia In DbContext.GetQuery(Of Database.Entities.ImportAccountPayableMedia)
                   Select ImportAccountPayableMedia

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ImportAccountPayableMedias.Add(ImportAccountPayableMedia)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ImportAccountPayableMedia)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ImportAccountPayableMedia)

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
