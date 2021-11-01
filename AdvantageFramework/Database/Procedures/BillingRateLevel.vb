Namespace Database.Procedures.BillingRateLevel

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

        Public Function LoadByBillingRateLevelID(ByVal DbContext As Database.DbContext, ByVal BillingRateLevelID As Short) As Database.Entities.BillingRateLevel

            Try

                LoadByBillingRateLevelID = (From BillingRateLevel In DbContext.GetQuery(Of Database.Entities.BillingRateLevel)
                                            Where BillingRateLevel.ID = BillingRateLevelID
                                            Select BillingRateLevel).SingleOrDefault

            Catch ex As Exception
                LoadByBillingRateLevelID = Nothing
            End Try

        End Function
        Public Function LoadEmployeeOnlyBillingRateLevel(ByVal DbContext As Database.DbContext) As Database.Entities.BillingRateLevel

            Try

                LoadEmployeeOnlyBillingRateLevel = (From BillingRateLevel In LoadAllActive(DbContext)
                                                    Where BillingRateLevel.Description = "Employee" AndAlso
                                                        BillingRateLevel.IsEmployeeIncluded = 1
                                                    Select BillingRateLevel).SingleOrDefault

            Catch ex As Exception
                LoadEmployeeOnlyBillingRateLevel = Nothing
            End Try

        End Function
        Public Function LoadEmployeeTitleOnlyBillingRateLevel(ByVal DbContext As Database.DbContext) As Database.Entities.BillingRateLevel

            Try

                LoadEmployeeTitleOnlyBillingRateLevel = (From BillingRateLevel In LoadAllActive(DbContext)
                                                         Where BillingRateLevel.Description = "Employee Title" AndAlso
                                                               BillingRateLevel.IsEmployeeTitleIncluded = 1
                                                         Select BillingRateLevel).SingleOrDefault

            Catch ex As Exception
                LoadEmployeeTitleOnlyBillingRateLevel = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BillingRateLevel)

            LoadAllActive = From BillingRateLevel In DbContext.GetQuery(Of Database.Entities.BillingRateLevel)
                            Where BillingRateLevel.IsInactive Is Nothing OrElse
                                  BillingRateLevel.IsInactive = 0
                            Select BillingRateLevel

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BillingRateLevel)

            Load = From BillingRateLevel In DbContext.GetQuery(Of Database.Entities.BillingRateLevel)
                   Select BillingRateLevel

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                BillingRateLevel.ID = (From Entity In DbContext.GetQuery(Of Database.Entities.BillingRateLevel)
                                       Select Entity.ID).Max + 1

                DbContext.BillingRateLevels.Add(BillingRateLevel)

                ErrorText = BillingRateLevel.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(BillingRateLevel)

                ErrorText = BillingRateLevel.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.BILLING_RATE WHERE BILL_RATE_PREC_ID = {0}", BillingRateLevel.ID))

                    DbContext.DeleteEntityObject(BillingRateLevel)

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
