Namespace Database.Procedures.MediaSpecsHeader

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpecsHeader)

            Load = From MediaSpecsHeader In DbContext.GetQuery(Of Database.Entities.MediaSpecsHeader)
                   Select MediaSpecsHeader

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaSpecsHeader As AdvantageFramework.Database.Entities.MediaSpecsHeader) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    MediaSpecsHeader.ID = (From Entity In DbContext.GetQuery(Of Database.Entities.MediaSpecsHeader)
                                           Select Entity.ID).Max + 1

                Catch ex As Exception
                    MediaSpecsHeader.ID = 1
                End Try

                DbContext.MediaSpecsHeaders.Add(MediaSpecsHeader)

                ErrorText = MediaSpecsHeader.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaSpecsHeader As AdvantageFramework.Database.Entities.MediaSpecsHeader) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaSpecsHeader)

                ErrorText = MediaSpecsHeader.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaSpecsHeader As AdvantageFramework.Database.Entities.MediaSpecsHeader) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each EntityClass In AdvantageFramework.Database.Procedures.MediaSpecsDetail.LoadBySpecID(DbContext, MediaSpecsHeader.ID).ToList

                        DbContext.DeleteEntityObject(EntityClass)

                    Next

                    DbContext.DeleteEntityObject(MediaSpecsHeader)

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
