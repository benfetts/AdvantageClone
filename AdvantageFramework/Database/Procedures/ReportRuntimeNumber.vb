Namespace Database.Procedures.ReportRuntimeNumber

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.ReportRuntimeNumber)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.ReportRuntimeNumber)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ReportRuntimeNumber As AdvantageFramework.Database.Entities.ReportRuntimeNumber) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ReportRuntimeNumbers.Add(ReportRuntimeNumber)

                ErrorText = ReportRuntimeNumber.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ReportRuntimeNumber As AdvantageFramework.Database.Entities.ReportRuntimeNumber) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Entry(ReportRuntimeNumber).State = Entity.EntityState.Modified

                ErrorText = ReportRuntimeNumber.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ReportRuntimeNumber As AdvantageFramework.Database.Entities.ReportRuntimeNumber) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(ReportRuntimeNumber).State = Entity.EntityState.Deleted

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
        Public Function DeleteByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.RPT_SEL_NBRS WHERE USER_ID = '{0}'", UserCode))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByUserCode = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
