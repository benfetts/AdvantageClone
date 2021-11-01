Namespace Database.Procedures.JobVersionTemplateDetailListValue

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

        Public Function LoadByJobVersionTemplateDetailListValueID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobVersionTemplateDetailListValueID As Long) As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue

            Try

                LoadByJobVersionTemplateDetailListValueID = (From JobVersionTemplateDetailListValue In DataContext.JobVersionTemplateDetailListValues _
                                                             Where JobVersionTemplateDetailListValue.ID = JobVersionTemplateDetailListValueID _
                                                             Select JobVersionTemplateDetailListValue).SingleOrDefault

            Catch ex As Exception
                LoadByJobVersionTemplateDetailListValueID = Nothing
            End Try

        End Function
        Public Function LoadByJobVersionTemplateDetailID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobVersionTemplateDetailID As Long) As IQueryable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue)

            LoadByJobVersionTemplateDetailID = From JobVersionTemplateDetailListValue In DataContext.JobVersionTemplateDetailListValues
                                               Where JobVersionTemplateDetailListValue.JobVersionTemplateDetailID = JobVersionTemplateDetailID
                                               Select JobVersionTemplateDetailListValue

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue)

            Load = From JobVersionTemplateDetailListValue In DataContext.JobVersionTemplateDetailListValues
                   Select JobVersionTemplateDetailListValue

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobVersionTemplateDetailListValue As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                JobVersionTemplateDetailListValue.DataContext = DataContext

                JobVersionTemplateDetailListValue.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.JobVersionTemplateDetailListValues.InsertOnSubmit(JobVersionTemplateDetailListValue)

                ErrorText = JobVersionTemplateDetailListValue.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobVersionTemplateDetailListValue As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                JobVersionTemplateDetailListValue.DataContext = DataContext

                JobVersionTemplateDetailListValue.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = JobVersionTemplateDetailListValue.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobVersionTemplateDetailListValue As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.JobVersionTemplateDetailListValues.DeleteOnSubmit(JobVersionTemplateDetailListValue)

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

#End Region

    End Module

End Namespace

