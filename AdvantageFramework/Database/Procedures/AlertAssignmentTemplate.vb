Namespace Database.Procedures.AlertAssignmentTemplate

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

        Public Function IsAutoRoute(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal AlertAssignmentTemplateID As Integer) As Boolean

            Dim TemplateIsAutoRoute As Boolean = False

            Try

                TemplateIsAutoRoute = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(ANH.AUTO_NXT_STATE, 0) AS BIT) FROM ALERT_NOTIFY_HDR ANH WITH(NOLOCK) WHERE ANH.ALRT_NOTIFY_HDR_ID = {0};", AlertAssignmentTemplateID)).SingleOrDefault

            Catch ex As Exception
                TemplateIsAutoRoute = False
            End Try

            Return TemplateIsAutoRoute

        End Function

        Public Function LoadMultiRouteAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)

            LoadMultiRouteAllActive = From AlertAssignmentTemplate In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplate)
                                      Where (AlertAssignmentTemplate.IsActive Is Nothing OrElse AlertAssignmentTemplate.IsActive = True) AndAlso
                                          (AlertAssignmentTemplate.TemplateType IsNot Nothing AndAlso AlertAssignmentTemplate.TemplateType = 1)
                                      Order By AlertAssignmentTemplate.Name
                                      Select AlertAssignmentTemplate

        End Function
        Public Function LoadDigitalAssetsAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)

            LoadDigitalAssetsAllActive = From AlertAssignmentTemplate In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplate)
                                         Where AlertAssignmentTemplate.IsActive Is Nothing OrElse AlertAssignmentTemplate.IsActive = True AndAlso AlertAssignmentTemplate.IsDigitalAsset = True
                                         Order By AlertAssignmentTemplate.Name
                                         Select AlertAssignmentTemplate

        End Function
        Public Function LoadBasicBoardTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.AlertAssignmentTemplate

            Try

                LoadBasicBoardTemplate = (From AlertAssignmentTemplate In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplate)
                                          Where AlertAssignmentTemplate.Name = "Basic Board"
                                          Select AlertAssignmentTemplate).SingleOrDefault

            Catch ex As Exception
                LoadBasicBoardTemplate = Nothing
            End Try

        End Function
        Public Function LoadByAlertAssignmentTemplateID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAssignmentTemplateID As Integer) As AdvantageFramework.Database.Entities.AlertAssignmentTemplate

            Try

                LoadByAlertAssignmentTemplateID = (From AlertAssignmentTemplate In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplate)
                                                   Where AlertAssignmentTemplate.ID = AlertAssignmentTemplateID
                                                   Select AlertAssignmentTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByAlertAssignmentTemplateID = Nothing
            End Try

        End Function
        Public Function LoadAllActiveConceptShare(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)

            LoadAllActiveConceptShare = From Entity In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplate)
                                        Where (Entity.IsActive Is Nothing OrElse Entity.IsActive = True) And
                                            Entity.Name <> "Basic Board" And
                                            Entity.TemplateType = Entities.AlertAssignmentTemplate.Type.ConceptShareReview
                                        Order By Entity.Name
                                        Select Entity

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)

            LoadAllActive = From AlertAssignmentTemplate In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplate)
                            Where (AlertAssignmentTemplate.IsActive Is Nothing OrElse AlertAssignmentTemplate.IsActive = True) And AlertAssignmentTemplate.Name <> "Basic Board"
                            Order By AlertAssignmentTemplate.Name
                            Select AlertAssignmentTemplate

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)

            Load = From AlertAssignmentTemplate In DbContext.GetQuery(Of Database.Entities.AlertAssignmentTemplate)
                   Where AlertAssignmentTemplate.Name <> "Basic Board"
                   Order By AlertAssignmentTemplate.Name
                   Select AlertAssignmentTemplate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAssignmentTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AlertAssignmentTemplates.Add(AlertAssignmentTemplate)

                ErrorText = AlertAssignmentTemplate.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAssignmentTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AlertAssignmentTemplate)

                ErrorText = AlertAssignmentTemplate.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAssignmentTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AlertAssignmentTemplate)

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
