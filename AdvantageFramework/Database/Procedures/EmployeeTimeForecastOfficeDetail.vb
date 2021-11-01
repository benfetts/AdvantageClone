Namespace Database.Procedures.EmployeeTimeForecastOfficeDetail

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

        Public Function LoadByEmployeeTimeForecastIDAndOfficeCodeAndAssignedToEmployeeCodeAndRevisionNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal OfficeCode As String, ByVal AssignedToEmployeeCode As String, ByVal RevisionNumber As Integer) As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail

            Try

                LoadByEmployeeTimeForecastIDAndOfficeCodeAndAssignedToEmployeeCodeAndRevisionNumber = (From EmployeeTimeForecastOfficeDetail In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetail)
                                                                                                       Where EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID = EmployeeTimeForecastID AndAlso
                                                                                                             EmployeeTimeForecastOfficeDetail.OfficeCode = OfficeCode AndAlso
                                                                                                             EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode = AssignedToEmployeeCode AndAlso
                                                                                                             EmployeeTimeForecastOfficeDetail.RevisionNumber = RevisionNumber
                                                                                                       Select EmployeeTimeForecastOfficeDetail).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeForecastIDAndOfficeCodeAndAssignedToEmployeeCodeAndRevisionNumber = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeForecastID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)

            LoadByEmployeeTimeForecastID = From EmployeeTimeForecastOfficeDetail In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetail)
                                           Where EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID = EmployeeTimeForecastID
                                           Select EmployeeTimeForecastOfficeDetail

        End Function
        Public Function LoadByOfficeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)

            LoadByOfficeCode = From EmployeeTimeForecastOfficeDetail In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetail)
                               Where EmployeeTimeForecastOfficeDetail.OfficeCode = OfficeCode
                               Select EmployeeTimeForecastOfficeDetail

        End Function
        Public Function LoadByPostPeriodCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriodCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)

            LoadByPostPeriodCode = From EmployeeTimeForecastOfficeDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecast")
                                   Where EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode = PostPeriodCode
                                   Select EmployeeTimeForecastOfficeDetail

        End Function
        Public Function LoadByPostPeriodCodeRange(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FromPostPeriodCode As String, ByVal ToPostPeriodCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)

            LoadByPostPeriodCodeRange = From EmployeeTimeForecastOfficeDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecast")
                                        Where EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode >= FromPostPeriodCode AndAlso
                                              EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode <= ToPostPeriodCode
                                        Select EmployeeTimeForecastOfficeDetail

        End Function
        Public Function LoadByAssignedToEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AssignedToEmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)

            LoadByAssignedToEmployeeCode = From EmployeeTimeForecastOfficeDetail In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetail)
                                           Where EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode = AssignedToEmployeeCode
                                           Select EmployeeTimeForecastOfficeDetail

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail

            Try

                LoadByEmployeeTimeForecastOfficeDetailID = (From EmployeeTimeForecastOfficeDetail In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetail)
                                                            Where EmployeeTimeForecastOfficeDetail.ID = EmployeeTimeForecastOfficeDetailID
                                                            Select EmployeeTimeForecastOfficeDetail).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeForecastOfficeDetailID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)

            Load = From EmployeeTimeForecastOfficeDetail In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetail)
                   Select EmployeeTimeForecastOfficeDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastID As Integer, _
                               ByVal RevisionNumber As Integer, ByVal CreatedByUserCode As String, _
                               ByVal CreatedDate As Date, ByVal OfficeCode As String, _
                               ByVal IsApproved As Boolean, ByVal Comment As String, ByVal AssignedToEmployeeCode As String, _
                               ByRef EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeTimeForecastOfficeDetail = New AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail

                EmployeeTimeForecastOfficeDetail.DbContext = DbContext
                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID = EmployeeTimeForecastID
                EmployeeTimeForecastOfficeDetail.RevisionNumber = RevisionNumber
                EmployeeTimeForecastOfficeDetail.CreatedByUserCode = CreatedByUserCode
                EmployeeTimeForecastOfficeDetail.CreatedDate = CreatedDate
                EmployeeTimeForecastOfficeDetail.OfficeCode = OfficeCode
                EmployeeTimeForecastOfficeDetail.IsApproved = IsApproved
                EmployeeTimeForecastOfficeDetail.Comment = Comment
                EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode = AssignedToEmployeeCode

                Inserted = Insert(DbContext, EmployeeTimeForecastOfficeDetail)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeForecastOfficeDetails.Add(EmployeeTimeForecastOfficeDetail)

                ErrorText = EmployeeTimeForecastOfficeDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeForecastOfficeDetail)

                ErrorText = EmployeeTimeForecastOfficeDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeForecastOfficeDetail)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTL WHERE ETF_OFFDTL_ID = {0}", EmployeeTimeForecastOfficeDetailID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace

