Namespace Database.Procedures.GLAllocation

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

        Public Function LoadByGLAccountCode(ByVal DbContext As Database.DbContext, ByVal GLAccountCode As String) As Database.Entities.GLAllocation

            Try

                LoadByGLAccountCode = (From GLAllocation In DbContext.GetQuery(Of Database.Entities.GLAllocation)
                                       Where GLAllocation.GLAccountCode = GLAccountCode
                                       Select GLAllocation).SingleOrDefault

            Catch ex As Exception
                LoadByGLAccountCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLAllocation)

            Load = From GLAllocation In DbContext.GetQuery(Of Database.Entities.GLAllocation)
                   Select GLAllocation

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLAllocation As AdvantageFramework.Database.Entities.GLAllocation) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GLAllocations.Add(GLAllocation)

                ErrorText = GLAllocation.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        If AdvantageFramework.Database.Procedures.GLAllocation.Load(DbContext).Any Then

                            GLAllocation.ID = (From Entity In AdvantageFramework.Database.Procedures.GLAllocation.Load(DbContext) _
                                               Select Entity.ID).Max + 1

                        Else

                            GLAllocation.ID = 1

                        End If

                    Catch ex As Exception
                        GLAllocation.ID = 1
                    End Try

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLAllocation As AdvantageFramework.Database.Entities.GLAllocation) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GLAllocation)

                ErrorText = GLAllocation.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLAllocation As AdvantageFramework.Database.Entities.GLAllocation) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GLAllocation)

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
