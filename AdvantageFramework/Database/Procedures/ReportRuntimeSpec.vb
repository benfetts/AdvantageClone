Namespace Database.Procedures.ReportRuntimeSpec

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

        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.ReportRuntimeSpec)

            LoadByUserCode = DbContext.Set(Of AdvantageFramework.Database.Entities.ReportRuntimeSpec)().Where(Function(Entity) Entity.UserCode = UserCode)

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.ReportRuntimeSpec)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.ReportRuntimeSpec)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ReportRuntimeSpec As AdvantageFramework.Database.Entities.ReportRuntimeSpec) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ReportRuntimeSpecs.Add(ReportRuntimeSpec)

                ErrorText = ReportRuntimeSpec.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ReportRuntimeSpec As AdvantageFramework.Database.Entities.ReportRuntimeSpec) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Entry(ReportRuntimeSpec).State = Entity.EntityState.Modified

                ErrorText = ReportRuntimeSpec.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ReportRuntimeSpec As AdvantageFramework.Database.Entities.ReportRuntimeSpec) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(ReportRuntimeSpec).State = Entity.EntityState.Deleted

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
