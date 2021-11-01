Namespace Database.Procedures.AccountSetupForm

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AccountSetupForm)

            Load = DbContext.GetQuery(Of Database.Entities.AccountSetupForm)

        End Function

        Public Function LoadByJobandComponent(ByVal dbcontext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AccountSetupForm)

            LoadByJobandComponent = dbcontext.Set(Of AdvantageFramework.Database.Entities.AccountSetupForm)().Where(Function(Entity) Entity.JobNumber = JobNumber And Entity.JobComponentNumber = JobComponentNumber)

        End Function

        'Public Function LoadByID(ByVal dbcontext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AccountSetupForm)

        '    LoadByID = dbcontext.Set(Of AdvantageFramework.Database.Entities.AccountSetupForm)().Where(Function(Entity) Entity.ID = ID)

        'End Function

        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.AccountSetupForm

            Try

                LoadByID = (From AccountSetupForm In DbContext.GetQuery(Of Database.Entities.AccountSetupForm)
                            Where AccountSetupForm.ID = ID
                            Select AccountSetupForm).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountSetupForm As AdvantageFramework.Database.Entities.AccountSetupForm, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.AccountSetupForms.Add(AccountSetupForm)

                ErrorMessage = AccountSetupForm.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountSetupForm As AdvantageFramework.Database.Entities.AccountSetupForm, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(AccountSetupForm).State = Entity.EntityState.Modified

                ErrorMessage = AccountSetupForm.ValidateEntity(IsValid)

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

        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountSetupForm As AdvantageFramework.Database.Entities.AccountSetupForm) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(AccountSetupForm).State = Entity.EntityState.Deleted

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
