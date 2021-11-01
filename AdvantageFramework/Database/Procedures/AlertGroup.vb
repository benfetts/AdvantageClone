Namespace Database.Procedures.AlertGroup

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

        Public Function LoadByEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertGroup)

            LoadByEmployeeCode = From AlertGroup In DbContext.GetQuery(Of Database.Entities.AlertGroup)
                                 Where AlertGroup.EmployeeCode = EmployeeCode
                                 Select AlertGroup

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertGroup)

            LoadAllActive = From AlertGroup In DbContext.GetQuery(Of Database.Entities.AlertGroup)
                            Where AlertGroup.IsInactive Is Nothing OrElse
                                  AlertGroup.IsInactive = 0
                            Select AlertGroup

        End Function
        Public Function LoadByAlertGroupCodeAndEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertGroupCode As String, ByVal EmployeeCode As String) As AdvantageFramework.Database.Entities.AlertGroup

            Try

                LoadByAlertGroupCodeAndEmployeeCode = (From AlertGroup In DbContext.GetQuery(Of Database.Entities.AlertGroup)
                                                       Where AlertGroup.Code = AlertGroupCode AndAlso
                                                              AlertGroup.EmployeeCode = EmployeeCode
                                                       Select AlertGroup).SingleOrDefault

            Catch ex As Exception
                LoadByAlertGroupCodeAndEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByAlertGroupCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertGroupCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertGroup)

            LoadByAlertGroupCode = From AlertGroup In DbContext.GetQuery(Of Database.Entities.AlertGroup)
                                   Where AlertGroup.Code = AlertGroupCode
                                   Select AlertGroup

        End Function
        Public Function LoadAllActiveDistinctAlertGroups(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertGroup)

            LoadAllActiveDistinctAlertGroups = From AlertGroup In LoadAllActive(DbContext)
                                               Group AlertGroup By Key = AlertGroup.Code Into Group
                                               Select Group.FirstOrDefault

        End Function
        Public Function LoadDistinctAlertGroups(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertGroup)

            LoadDistinctAlertGroups = From AlertGroup In DbContext.GetQuery(Of Database.Entities.AlertGroup)
                                      Group AlertGroup By Key = AlertGroup.Code Into Group
                                      Select Group.FirstOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertGroup)

            Load = From AlertGroup In DbContext.GetQuery(Of Database.Entities.AlertGroup)
                   Select AlertGroup

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertGroup As AdvantageFramework.Database.Entities.AlertGroup) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AlertGroups.Add(AlertGroup)

                ErrorText = AlertGroup.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertGroup As AdvantageFramework.Database.Entities.AlertGroup) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AlertGroup)

                ErrorText = AlertGroup.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertGroup As AdvantageFramework.Database.Entities.AlertGroup) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                IsValid = (AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, AlertGroup.Code).Count > 1)

                If IsValid Then

                    DbContext.DeleteEntityObject(AlertGroup)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("You must have at least one employee in group.")

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function DeleteAll(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertGroupCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim AlertGroupCategory As AdvantageFramework.Database.Entities.AlertGroupCategory = Nothing

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.JOB_COMPONENT WHERE EMAIL_GR_CODE = '{0}'", AlertGroupCode.Replace("'", "''"))).FirstOrDefault > 0 OrElse _
                        DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.CAMPAIGN WHERE ALERT_GROUP = '{0}'", AlertGroupCode.Replace("'", "''"))).FirstOrDefault > 0 OrElse _
                        DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.PRODUCT WHERE EMAIL_GR_CODE = '{0}'", AlertGroupCode.Replace("'", "''"))).FirstOrDefault > 0 Then

                    AdvantageFramework.Navigation.ShowMessageBox("The alert group is in use and cannot be deleted.")

                Else

                    For Each AlertGroupCategory In AdvantageFramework.Database.Procedures.AlertGroupCategory.LoadByAlertGroupCode(DbContext, AlertGroupCode)

                        DbContext.DeleteEntityObject(AlertGroupCategory)

                    Next

                    For Each AlertGroup In AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, AlertGroupCode)

                        DbContext.DeleteEntityObject(AlertGroup)

                    Next

                    DbContext.SaveChanges()

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteAll = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
