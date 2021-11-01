Namespace Database.Procedures.EstimateTemplate

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

        Public Function LoadByEstimateTemplateCode(ByVal DbContext As Database.DbContext, ByVal EstimateTemplateCode As String) As Database.Entities.EstimateTemplate

            Try

                LoadByEstimateTemplateCode = (From EstimateTemplate In DbContext.GetQuery(Of Database.Entities.EstimateTemplate)
                                              Where EstimateTemplate.Code = EstimateTemplateCode
                                              Select EstimateTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByEstimateTemplateCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EstimateTemplate)

            LoadAllActive = From EstimateTemplate In DbContext.GetQuery(Of Database.Entities.EstimateTemplate)
                            Where EstimateTemplate.IsInactive Is Nothing OrElse
                                  EstimateTemplate.IsInactive = 0
                            Select EstimateTemplate

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EstimateTemplate)

            Load = From EstimateTemplate In DbContext.GetQuery(Of Database.Entities.EstimateTemplate)
                   Select EstimateTemplate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Code As String, _
                               ByVal Description As String, ByVal IsInactive As Boolean, _
                               ByRef EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EstimateTemplate = New AdvantageFramework.Database.Entities.EstimateTemplate

                EstimateTemplate.DbContext = DbContext
                EstimateTemplate.Description = Description
                EstimateTemplate.Code = Code
                EstimateTemplate.IsInactive = IIf(IsInactive, 1, 0)

                Inserted = Insert(DbContext, EstimateTemplate)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EstimateTemplates.Add(EstimateTemplate)

                ErrorText = EstimateTemplate.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EstimateTemplate)

                ErrorText = EstimateTemplate.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                IsValid = AdvantageFramework.Database.Procedures.EstimateTemplateDetail.DeleteByEstimateTemplateCode(DbContext, EstimateTemplate.Code)

                If IsValid Then

                    DbContext.DeleteEntityObject(EstimateTemplate)

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
