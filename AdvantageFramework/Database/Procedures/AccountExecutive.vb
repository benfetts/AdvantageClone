Namespace Database.Procedures.AccountExecutive

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

        Public Function LoadByClientAndDivisionAndProductAndEmployeeCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal EmployeeCode As String) As Database.Entities.AccountExecutive

            LoadByClientAndDivisionAndProductAndEmployeeCode = (From AccountExecutive In DbContext.GetQuery(Of Database.Entities.AccountExecutive)
                                                                Where AccountExecutive.ClientCode = ClientCode AndAlso
                                                                      AccountExecutive.DivisionCode = DivisionCode AndAlso
                                                                      AccountExecutive.ProductCode = ProductCode AndAlso
                                                                      AccountExecutive.EmployeeCode = EmployeeCode
                                                                Select AccountExecutive).SingleOrDefault

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountExecutive)

            LoadByClientAndDivisionAndProductCode = From AccountExecutive In DbContext.GetQuery(Of Database.Entities.AccountExecutive)
                                                    Where AccountExecutive.ClientCode = ClientCode AndAlso
                                                          AccountExecutive.DivisionCode = DivisionCode AndAlso
                                                          AccountExecutive.ProductCode = ProductCode
                                                    Select AccountExecutive

        End Function
        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountExecutive)

            LoadByEmployeeCode = From AccountExecutive In DbContext.GetQuery(Of Database.Entities.AccountExecutive)
                                 Where AccountExecutive.EmployeeCode = EmployeeCode
                                 Select AccountExecutive

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountExecutive)

            Load = From AccountExecutive In DbContext.GetQuery(Of Database.Entities.AccountExecutive)
                   Select AccountExecutive

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, _
                               ByVal IsDefault As Short, ByVal IsInactive As Short, _
                               ByRef AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                AccountExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                AccountExecutive.DbContext = DbContext
                AccountExecutive.ClientCode = ClientCode
                AccountExecutive.DivisionCode = DivisionCode
                AccountExecutive.ProductCode = ProductCode
                AccountExecutive.IsInactive = IsInactive

                Inserted = Insert(DbContext, AccountExecutive)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountExecutives.Add(AccountExecutive)

                ErrorText = AccountExecutive.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.AccountExecutives.Any(Function(AcctExe) AcctExe.ProductCode = AccountExecutive.ProductCode AndAlso _
                                                                             AcctExe.DivisionCode = AccountExecutive.DivisionCode AndAlso _
                                                                             AcctExe.ClientCode = AccountExecutive.ClientCode AndAlso _
                                                                             AcctExe.EmployeeCode = AccountExecutive.EmployeeCode) = False Then

                        If AccountExecutive.ManagementLevelID < 1 Then

                            AccountExecutive.ManagementLevelID = 1

                        End If

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter a unique account executive.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountExecutive)

                ErrorText = AccountExecutive.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                IsValid = (AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionAndProductCode(DbContext, AccountExecutive.ClientCode, AccountExecutive.DivisionCode, AccountExecutive.ProductCode).Include("JobComponents").SelectMany(Function(Job) Job.JobComponents).Any(Function(JobComponent) JobComponent.AccountExecutiveEmployeeCode = AccountExecutive.EmployeeCode) = False)

                If IsValid Then

                    DbContext.DeleteEntityObject(AccountExecutive)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Account Executive (" & AccountExecutive.EmployeeCode & ") is in use.")

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
