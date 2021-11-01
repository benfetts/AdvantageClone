Namespace Database.Procedures.MediaPlanFlowChartOptions

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

        Public Function LoadByMediaPlanFlowChartOptionsID(DbContext As AdvantageFramework.Database.DbContext, MediaPlanFlowChartOptionsID As Integer) As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions

            Try

                LoadByMediaPlanFlowChartOptionsID = (From MediaPlanFlowChartOptions In DbContext.GetQuery(Of Database.Entities.MediaPlanFlowChartOptions)
                                                     Where MediaPlanFlowChartOptions.ID = MediaPlanFlowChartOptionsID
                                                     Select MediaPlanFlowChartOptions).SingleOrDefault

            Catch ex As Exception
                LoadByMediaPlanFlowChartOptionsID = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(DbContext As AdvantageFramework.Database.DbContext, UserCode As String) As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions

            Try

                LoadByUserCode = (From MediaPlanFlowChartOptions In DbContext.GetQuery(Of Database.Entities.MediaPlanFlowChartOptions)
                                  Where MediaPlanFlowChartOptions.UserCode = UserCode
                                  Select MediaPlanFlowChartOptions).SingleOrDefault

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaPlanFlowChartOptions)

            Load = From MediaPlanFlowChartOptions In DbContext.GetQuery(Of Database.Entities.MediaPlanFlowChartOptions)
                   Select MediaPlanFlowChartOptions

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, MediaPlanFlowChartOptions As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaPlanFlowChartOptions.Add(MediaPlanFlowChartOptions)

                ErrorText = MediaPlanFlowChartOptions.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.MediaPlanFlowChartOptions.Add(MediaPlanFlowChartOptions)

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, MediaPlanFlowChartOptions As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaPlanFlowChartOptions)

                ErrorText = MediaPlanFlowChartOptions.ValidateEntity(IsValid)

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, MediaPlanFlowChartOptions As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaPlanFlowChartOptions)

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
