Namespace Database.Procedures.EstimateTemplateDetail

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

        Public Function LoadByEstimateTemplateDetailID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EstimateTemplateDetailID As Integer) As Database.Entities.EstimateTemplateDetail

            Try

                LoadByEstimateTemplateDetailID = (From EstimateTemplateDetail In DataContext.EstimateTemplateDetails _
                                                  Where EstimateTemplateDetail.ID = EstimateTemplateDetailID _
                                                  Select EstimateTemplateDetail).SingleOrDefault

            Catch ex As Exception
                LoadByEstimateTemplateDetailID = Nothing
            End Try

        End Function
        Public Function LoadByEstimateTemplateCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EstimateTemplateCode As String) As IQueryable(Of Database.Entities.EstimateTemplateDetail)

            LoadByEstimateTemplateCode = From EstimateTemplateDetail In DataContext.EstimateTemplateDetails
                                         Where EstimateTemplateDetail.EstimateTemplateCode = EstimateTemplateCode
                                         Select EstimateTemplateDetail

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of Database.Entities.EstimateTemplateDetail)

            Load = From EstimateTemplateDetail In DataContext.EstimateTemplateDetails
                   Select EstimateTemplateDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EstimateTemplateCode As String, _
                               ByVal FunctionCode As String, ByVal SuppliedBy As String, ByVal Hours As Decimal, _
                               ByRef EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EstimateTemplateDetail = New AdvantageFramework.Database.Entities.EstimateTemplateDetail

                EstimateTemplateDetail.EstimateTemplateCode = EstimateTemplateCode
                EstimateTemplateDetail.FunctionCode = FunctionCode
                EstimateTemplateDetail.SuppliedBy = SuppliedBy
                EstimateTemplateDetail.Hours = Hours

                Inserted = Insert(DbContext, DataContext, EstimateTemplateDetail)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                EstimateTemplateDetail.DbContext = DbContext
                EstimateTemplateDetail.DataContext = DataContext

                EstimateTemplateDetail.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.EstimateTemplateDetails.InsertOnSubmit(EstimateTemplateDetail)

                ErrorText = EstimateTemplateDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                EstimateTemplateDetail.DbContext = DbContext
                EstimateTemplateDetail.DataContext = DataContext

                EstimateTemplateDetail.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = EstimateTemplateDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DataContext.EstimateTemplateDetails.Where(Function(EstTempDet) EstTempDet.EstimateTemplateCode = EstimateTemplateDetail.EstimateTemplateCode).Count = 1 Then

                    ErrorText = "Estimate Template's must have at least one Estimate Template Detail."
                    IsValid = False

                End If

                If IsValid Then

                    DataContext.EstimateTemplateDetails.DeleteOnSubmit(EstimateTemplateDetail)

                    DataContext.SubmitChanges()

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
        Public Function DeleteByEstimateTemplateCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EstimateTemplateCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.PRESET_FUNC WHERE PRESET_CODE = '" & EstimateTemplateCode & "'")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByEstimateTemplateCode = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
