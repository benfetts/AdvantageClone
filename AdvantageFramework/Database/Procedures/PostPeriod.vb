Namespace Database.Procedures.PostPeriod

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

        Public Function LoadAllActiveNonYearEndPostPeriods(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            LoadAllActiveNonYearEndPostPeriods = From PostPeriod In Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                                 Where PostPeriod.GLStatus Is Nothing OrElse
                                                       PostPeriod.GLStatus = "C"
                                                 Select PostPeriod

        End Function
        Public Function LoadAllActiveAPPostPeriods(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            LoadAllActiveAPPostPeriods = From PostPeriod In Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                         Where PostPeriod.APStatus Is Nothing OrElse
                                               PostPeriod.APStatus <> "X"
                                         Select PostPeriod

        End Function
        Public Function LoadAllActiveARPostPeriods(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            LoadAllActiveARPostPeriods = From PostPeriod In Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                         Where PostPeriod.ARStatus Is Nothing OrElse
                                               PostPeriod.ARStatus <> "X"
                                         Select PostPeriod

        End Function
        Public Function LoadActiveARPostPeriodsFromPostPeriodAndAfter(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FromPostPeriod As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            LoadActiveARPostPeriodsFromPostPeriodAndAfter = From PostPeriod In Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                                            Where (PostPeriod.ARStatus Is Nothing OrElse
                                                                   PostPeriod.ARStatus <> "X") AndAlso
                                                                  PostPeriod.Code >= FromPostPeriod
                                                            Select PostPeriod

        End Function
        Public Function LoadAllPostPeriodsFromPostPeriodToPostPeriod(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FromPostPeriod As String, ByVal ToPostPeriod As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            LoadAllPostPeriodsFromPostPeriodToPostPeriod = From PostPeriod In Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                                           Where PostPeriod.Code >= FromPostPeriod AndAlso PostPeriod.Code <= ToPostPeriod
                                                           Select PostPeriod

        End Function
        Public Function LoadAllActiveGLPostPeriods(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            LoadAllActiveGLPostPeriods = From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                         Where PostPeriod.GLStatus Is Nothing OrElse
                                               PostPeriod.GLStatus <> "X"
                                         Select PostPeriod

        End Function
        Public Function LoadByMonthAndYear(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Month As Short, ByVal Year As String) As AdvantageFramework.Database.Entities.PostPeriod

            Try

                LoadByMonthAndYear = (From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                      Where PostPeriod.Month = Month AndAlso
                                            PostPeriod.Year = Year
                                      Select PostPeriod).SingleOrDefault

            Catch ex As Exception
                LoadByMonthAndYear = Nothing
            End Try

        End Function
        Public Function LoadAllNonYearEndPostPeriodsByPostPeriodYear(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriodYear As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            LoadAllNonYearEndPostPeriodsByPostPeriodYear = From PostPeriod In Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                                           Where PostPeriod.Year = PostPeriodYear
                                                           Select PostPeriod

        End Function
        Public Function LoadAllYearEndPostPeriods(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            LoadAllYearEndPostPeriods = From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                        Where PostPeriod.Month = 99
                                        Select PostPeriod

        End Function
        Public Function LoadAllNonYearEndPostPeriods(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            LoadAllNonYearEndPostPeriods = From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                           Where PostPeriod.Month IsNot Nothing AndAlso
                                                 PostPeriod.Month <> 99
                                           Select PostPeriod

        End Function
        Public Function LoadByPostPeriodCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriodCode As String) As AdvantageFramework.Database.Entities.PostPeriod

            Try

                LoadByPostPeriodCode = (From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                        Where PostPeriod.Code = PostPeriodCode
                                        Select PostPeriod).SingleOrDefault

            Catch ex As Exception
                LoadByPostPeriodCode = Nothing
            End Try

        End Function
        Public Function LoadCurrentPostPeriod(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.PostPeriod

            Try

                LoadCurrentPostPeriod = (From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                         Where PostPeriod.GLStatus = "C"
                                         Select PostPeriod).SingleOrDefault

            Catch ex As Exception
                LoadCurrentPostPeriod = Nothing
            End Try

        End Function
        Public Function LoadCurrentAPPostPeriod(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.PostPeriod

            Try

                LoadCurrentAPPostPeriod = (From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                           Where PostPeriod.APStatus = "C"
                                           Select PostPeriod).SingleOrDefault

            Catch ex As Exception
                LoadCurrentAPPostPeriod = Nothing
            End Try

        End Function
        Public Function LoadCurrentARPostPeriod(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.PostPeriod

            Try

                LoadCurrentARPostPeriod = (From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                           Where PostPeriod.ARStatus = "C"
                                           Select PostPeriod).SingleOrDefault

            Catch ex As Exception
                LoadCurrentARPostPeriod = Nothing
            End Try

        End Function
        Public Function LoadCurrentGLPostPeriod(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.PostPeriod

            Try

                LoadCurrentGLPostPeriod = (From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                           Where PostPeriod.GLStatus = "C"
                                           Select PostPeriod).SingleOrDefault

            Catch ex As Exception
                LoadCurrentGLPostPeriod = Nothing
            End Try

        End Function
        Public Function LoadFirstPeriodByYear(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Year As String) As AdvantageFramework.Database.Entities.PostPeriod

            Try

                LoadFirstPeriodByYear = (From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                         Where PostPeriod.Month = 1 AndAlso
                                            PostPeriod.Year = Year
                                         Select PostPeriod).SingleOrDefault

            Catch ex As Exception
                LoadFirstPeriodByYear = Nothing
            End Try

        End Function
        Public Function LoadAllActiveOrFutureGLPostPeriods(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            Dim Month As Integer = 0
            Dim Year As Integer = 0

            Month = DatePart(DateInterval.Month, Now)
            Year = DatePart(DateInterval.Year, Now)

            LoadAllActiveOrFutureGLPostPeriods = From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                                                 Where (PostPeriod.GLStatus Is Nothing OrElse PostPeriod.GLStatus <> "X") OrElse
                                                       (PostPeriod.Year >= Year AndAlso PostPeriod.Month > Month)
                                                 Select PostPeriod

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PostPeriod)

            Load = From PostPeriod In DbContext.GetQuery(Of Database.Entities.PostPeriod)
                   Select PostPeriod

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriod As AdvantageFramework.Database.Entities.PostPeriod) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.PostPeriods.Add(PostPeriod)

                ErrorText = PostPeriod.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriod As AdvantageFramework.Database.Entities.PostPeriod) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PostPeriod)

                ErrorText = PostPeriod.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriod As AdvantageFramework.Database.Entities.PostPeriod) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(PostPeriod)

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

