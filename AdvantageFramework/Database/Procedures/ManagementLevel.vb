Namespace Database.Procedures.ManagementLevel

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ManagementLevel)

            Load = From ManagementLevel In DbContext.GetQuery(Of Database.Entities.ManagementLevel)
                   Select ManagementLevel

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ManagementLevel)

            LoadAllActive = From ManagementLevel In DbContext.GetQuery(Of Database.Entities.ManagementLevel)
                            Where ManagementLevel.IsInactive = False
                            Select ManagementLevel

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.ManagementLevel

            Try

                LoadByID = (From ManagementLevel In DbContext.GetQuery(Of Database.Entities.ManagementLevel)
                            Where ManagementLevel.ID = ID
                            Select ManagementLevel).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByDescription(ByVal DbContext As Database.DbContext, ByVal Description As String) As Database.Entities.ManagementLevel

            Try

                LoadByDescription = (From ManagementLevel In DbContext.GetQuery(Of Database.Entities.ManagementLevel)
                                     Where ManagementLevel.Description = Description
                                     Select ManagementLevel).SingleOrDefault

            Catch ex As Exception
                LoadByDescription = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ManagementLevel As AdvantageFramework.Database.Entities.ManagementLevel) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ManagementLevels.Add(ManagementLevel)

                ErrorText = ManagementLevel.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ManagementLevel As AdvantageFramework.Database.Entities.ManagementLevel) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ManagementLevel)

                ErrorText = ManagementLevel.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ManagementLevel As AdvantageFramework.Database.Entities.ManagementLevel) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ManagementLevel)

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
