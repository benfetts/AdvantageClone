Namespace Database.Procedures.IndirectCategory

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

        Public Function LoadByIndirectCategoryCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IndirectCategoryCode As String) As AdvantageFramework.Database.Entities.IndirectCategory

            Try

                LoadByIndirectCategoryCode = (From IndirectCategory In DbContext.GetQuery(Of Database.Entities.IndirectCategory)
                                              Where IndirectCategory.Code = IndirectCategoryCode
                                              Select IndirectCategory).SingleOrDefault

            Catch ex As Exception
                LoadByIndirectCategoryCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.IndirectCategory)

            LoadAllActive = From IndirectCategory In DbContext.GetQuery(Of Database.Entities.IndirectCategory)
                            Where IndirectCategory.IsInactive = 0 OrElse
                                  IndirectCategory.IsInactive Is Nothing
                            Select IndirectCategory

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.IndirectCategory)

            Load = From IndirectCategory In DbContext.GetQuery(Of Database.Entities.IndirectCategory)
                   Select IndirectCategory

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.IndirectCategories.Add(IndirectCategory)

                ErrorText = IndirectCategory.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(IndirectCategory)

                ErrorText = IndirectCategory.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                IsValid = (DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.EMP_TIME_NP WHERE CATEGORY = '" & IndirectCategory.Code & "'").FirstOrDefault = 0)

                If IsValid Then

                    DbContext.DeleteEntityObject(IndirectCategory)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("The code is in use and cannot be deleted.")

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
