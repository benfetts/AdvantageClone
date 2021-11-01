Namespace Database.Procedures.AlertCategory

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

        Public Function LoadByAlertTypeIDAndAlertCategoryDescription(ByVal DbContext As Database.DbContext, ByVal AlertTypeID As String, ByVal AlertCategoryDescription As String) As Database.Entities.AlertCategory

            Try

                LoadByAlertTypeIDAndAlertCategoryDescription = (From AlertCategory In DbContext.AlertCategories
                                                                Where AlertCategory.Description = AlertCategoryDescription AndAlso
                                                                      AlertCategory.AlertTypeID = AlertTypeID
                                                                Select AlertCategory).SingleOrDefault

            Catch ex As Exception
                LoadByAlertTypeIDAndAlertCategoryDescription = Nothing
            End Try

        End Function
        Public Function LoadByAlertTypeID(ByVal DbContext As Database.DbContext, ByVal AlertTypeID As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AlertCategory)

            LoadByAlertTypeID = From AlertCategory In DbContext.AlertCategories
                                Where AlertCategory.AlertTypeID = AlertTypeID
                                Select AlertCategory

        End Function
        Public Function LoadUserDefined(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.AlertCategory)

            LoadUserDefined = (From AlertCategory In DbContext.AlertCategories
                               Where AlertCategory.IsUserDefined = True
                               Order By AlertCategory.Description
                               Select AlertCategory)


        End Function
        Public Function LoadUserDefinedActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.AlertCategory)

            LoadUserDefinedActive = (From AlertCategory In DbContext.AlertCategories
                                     Where AlertCategory.IsUserDefined = True AndAlso (AlertCategory.IsInactive Is Nothing OrElse AlertCategory.IsInactive = 0)
                                     Order By AlertCategory.Description
                                     Select AlertCategory)


        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal AlertCategoryID As Integer) As Database.Entities.AlertCategory

            Try

                LoadByID = (From AlertCategory In DbContext.AlertCategories
                            Where AlertCategory.ID = AlertCategoryID
                            Select AlertCategory).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AlertCategory)

            Load = From AlertCategory In DbContext.AlertCategories
                   Select AlertCategory

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertCategory As AdvantageFramework.Database.Entities.AlertCategory, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim NextID As Integer = 0

            Try

                Try

                    NextID = CType(DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(MAX(ALERT_CAT_ID), 0) + 1 FROM ALERT_CATEGORY WITH(NOLOCK);").FirstOrDefault, Integer)

                Catch ex As Exception
                    NextID = 0
                End Try

                If NextID > 0 Then

                    AlertCategory.ID = NextID

                    DbContext.AlertCategories.Add(AlertCategory)

                    ErrorMessage = AlertCategory.ValidateEntity(IsValid)

                    If IsValid Then

                        DbContext.SaveChanges()

                        Inserted = True

                    End If

                End If
            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= ex.InnerException.Message.ToString()

                End If

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertCategory As AdvantageFramework.Database.Entities.AlertCategory, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(AlertCategory).State = Entity.EntityState.Modified

                ErrorMessage = AlertCategory.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertCategory As AdvantageFramework.Database.Entities.AlertCategory) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(AlertCategory).State = Entity.EntityState.Deleted

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
