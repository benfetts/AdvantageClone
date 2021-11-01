Namespace Database.Procedures.GLATrailer

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

        Public Function LoadByGLAllocationIDAndGLACode(ByVal DbContext As Database.DbContext, ByVal GLAllocationID As Integer, ByVal GLACode As String) As Database.Entities.GLATrailer

            Try

                LoadByGLAllocationIDAndGLACode = (From GLATrailer In DbContext.GetQuery(Of Database.Entities.GLATrailer)
                                                  Where GLATrailer.GLAllocationID = GLAllocationID AndAlso
                                                        GLATrailer.GLAltCode = GLACode
                                                  Select GLATrailer).SingleOrDefault

            Catch ex As Exception
                LoadByGLAllocationIDAndGLACode = Nothing
            End Try

        End Function
        Public Function LoadByGLAllocationID(ByVal DbContext As Database.DbContext, ByVal GLAllocationID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLATrailer)

            LoadByGLAllocationID = From GLATrailer In DbContext.GetQuery(Of Database.Entities.GLATrailer)
                                   Where GLATrailer.GLAllocationID = GLAllocationID
                                   Select GLATrailer

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLATrailer)

            Load = From GLATrailer In DbContext.GetQuery(Of Database.Entities.GLATrailer)
                   Select GLATrailer

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLATrailer As AdvantageFramework.Database.Entities.GLATrailer) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GLATrailers.Add(GLATrailer)

                ErrorText = GLATrailer.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLATrailer As AdvantageFramework.Database.Entities.GLATrailer) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GLATrailer)

                ErrorText = GLATrailer.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLATrailer As AdvantageFramework.Database.Entities.GLATrailer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GLATrailer)

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
