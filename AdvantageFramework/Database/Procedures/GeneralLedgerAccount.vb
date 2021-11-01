Namespace Database.Procedures.GeneralLedgerAccount

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

#Region "  Core Entities "

        Public Function LoadCore(ByVal GeneralLedgerAccounts As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)) As IEnumerable(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

            Try

                LoadCore = GeneralLedgerAccounts _
                           .Select(Function(Entity) New With {Entity.Code,
                                                              Entity.Description,
                                                              Entity.Active,
                                                              Entity.Type,
                                                              Entity.DepartmentCode,
                                                              Entity.GeneralLedgerOfficeCrossReferenceCode,
                                                              Entity.BaseCode}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.GeneralLedgerAccount With {.Code = Entity.Code,
                                                                                                                    .Description = Entity.Description,
                                                                                                                    .Active = Entity.Active,
                                                                                                                    .Type = Entity.Type,
                                                                                                                    .DepartmentCode = Entity.DepartmentCode,
                                                                                                                    .GeneralLedgerOfficeCrossReferenceCode = Entity.GeneralLedgerOfficeCrossReferenceCode,
                                                                                                                    .BaseCode = Entity.BaseCode}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        Public Function LoadByGeneralLedgerAccountType(ByVal DbContext As Database.DbContext, ByVal GeneralLedgerAccountType As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            LoadByGeneralLedgerAccountType = From GeneralLedgerAccount In DbContext.GetQuery(Of Database.Entities.GeneralLedgerAccount)
                                             Where GeneralLedgerAccount.Type = GeneralLedgerAccountType
                                             Select GeneralLedgerAccount

        End Function
        Public Function LoadAllActiveByCostOfSaleEntry(ByVal DbContext As Database.DbContext, ByVal ExcludeOfficeAccounts As Boolean, ByVal ExcludeWorkInProgressAccountsOnly As Boolean, ByVal AllowCostOfSaleEntry As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            If AllowCostOfSaleEntry Then

                LoadAllActiveByCostOfSaleEntry = From Entity In LoadAllActive(DbContext, ExcludeOfficeAccounts, ExcludeWorkInProgressAccountsOnly)
                                                 Select Entity

            Else

                LoadAllActiveByCostOfSaleEntry = From Entity In LoadAllActive(DbContext, ExcludeOfficeAccounts, ExcludeWorkInProgressAccountsOnly)
                                                 Where Entity.Type <> "8" AndAlso
                                                       Entity.Type <> "13"
                                                 Select Entity

            End If

        End Function
        Public Function LoadAllActiveByCostOfSaleEntryWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session, ByVal ExcludeOfficeAccounts As Boolean, ByVal ExcludeWorkInProgressAccountsOnly As Boolean, ByVal AllowCostOfSaleEntry As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            LoadAllActiveByCostOfSaleEntryWithOfficeLimits = LoadWithOfficeLimits(LoadAllActiveByCostOfSaleEntry(DbContext, ExcludeOfficeAccounts, ExcludeWorkInProgressAccountsOnly, AllowCostOfSaleEntry), Session.AccessibleGLOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExcludeOfficeAccounts As Boolean, ByVal ExcludeWorkInProgressAccountsOnly As Boolean, Optional ByVal Type As String = "") As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            Dim OfficeGLAccounts() As String = Nothing

            If ExcludeOfficeAccounts Then

                Try

                    If ExcludeWorkInProgressAccountsOnly Then

                        OfficeGLAccounts = ((From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.ProductionWorkInProgressGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.MediaWorkInProgressGLACode
                                             Distinct).ToArray).ToArray

                    Else

                        OfficeGLAccounts = ((From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.ProductionWorkInProgressGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.MediaWorkInProgressGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.AccountsReceivableGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.AccountsPayableGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.AccountsPayableDiscountGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.ProductionDeferredSalesGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.ProductionAccruedCostOfSalesGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.ProductionAccruedAccountsPayableGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.ProductionDeferredCostOfSalesGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.MediaAccruedAccountsPayableGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.MediaAccruedCostOfSalesGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.MediaDeferredCostOfSalesGLACode
                                             Distinct).ToArray).Union(
                                            (From Entity In AdvantageFramework.Database.Procedures.Office.Load(DbContext)
                                             Select Entity.MediaDeferredSalesGLACode
                                             Distinct).ToArray).ToArray

                    End If

                Catch ex As Exception
                    OfficeGLAccounts = Nothing
                End Try

                LoadAllActive = From GeneralLedgerAccount In LoadAllActive(DbContext).Where(BaseClasses.BuildDoesNotContainsExpression(Of Entities.GeneralLedgerAccount, String)(Function(Entity) Entity.Code, OfficeGLAccounts))
                                Where GeneralLedgerAccount.Type = If(String.IsNullOrEmpty(Type), GeneralLedgerAccount.Type, Type)
                                Select GeneralLedgerAccount

            Else

                LoadAllActive = From GeneralLedgerAccount In LoadAllActive(DbContext)
                                Where GeneralLedgerAccount.Type = If(String.IsNullOrEmpty(Type), GeneralLedgerAccount.Type, Type)
                                Select GeneralLedgerAccount

            End If

        End Function
        Public Function LoadAllActiveWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session, ByVal ExcludeOfficeAccounts As Boolean, ByVal ExcludeWorkInProgressAccountsOnly As Boolean, Optional ByVal Type As String = "") As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext, ExcludeOfficeAccounts, ExcludeWorkInProgressAccountsOnly, Type), Session.AccessibleGLOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExcludeBankARCashAPCashAccounts As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            Dim BankARAPGLAccounts() As String = Nothing

            If ExcludeBankARCashAPCashAccounts Then

                BankARAPGLAccounts = ((From Entity In AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext)
                                       Select Entity.ARCashAccount
                                       Distinct).ToArray).Union(
                                      (From Entity In AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext)
                                       Select Entity.APCashAccount
                                       Distinct).ToArray).ToArray

                LoadAllActive = From GeneralLedgerAccount In LoadAllActive(DbContext).Where(BaseClasses.BuildDoesNotContainsExpression(Of Entities.GeneralLedgerAccount, String)(Function(Entity) Entity.Code, BankARAPGLAccounts))
                                Select GeneralLedgerAccount

            Else

                LoadAllActive = From GeneralLedgerAccount In LoadAllActive(DbContext)
                                Select GeneralLedgerAccount

            End If

        End Function
        Public Function LoadAllActiveWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session, ByVal ExcludeBankARCashAPCashAccounts As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext, ExcludeBankARCashAPCashAccounts), Session.AccessibleGLOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            LoadAllActive = From GeneralLedgerAccount In DbContext.GetQuery(Of Database.Entities.GeneralLedgerAccount)
                            Where GeneralLedgerAccount.Active = "A"
                            Select GeneralLedgerAccount

        End Function
        Public Function LoadAllActiveWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext), Session.AccessibleGLOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadByGeneralLedgerOfficeCrossReferenceCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerOfficeCrossReferenceCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            LoadByGeneralLedgerOfficeCrossReferenceCode = From GeneralLedgerAccount In DbContext.GetQuery(Of Database.Entities.GeneralLedgerAccount)
                                                          Where GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReferenceCode
                                                          Select GeneralLedgerAccount

        End Function
        Public Function LoadByGLACode(ByVal DbContext As Database.DbContext, ByVal GLACode As String) As Database.Entities.GeneralLedgerAccount

            Try

                LoadByGLACode = (From GeneralLedgerAccount In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount).Include("GeneralLedgerOfficeCrossReference")
                                 Where GeneralLedgerAccount.Code = GLACode
                                 Select GeneralLedgerAccount).SingleOrDefault

            Catch ex As Exception
                LoadByGLACode = Nothing
            End Try

        End Function
        Public Function LoadAllActiveByOfficeCode(ByVal DbContext As Database.DbContext, ByVal OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            LoadAllActiveByOfficeCode = From GeneralLedgerAccount In LoadByOfficeCode(DbContext, OfficeCode)
                                        Where GeneralLedgerAccount.Active = "A"
                                        Select GeneralLedgerAccount

        End Function
        Public Function LoadByOfficeCode(ByVal DbContext As Database.DbContext, ByVal OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            LoadByOfficeCode = From GeneralLedgerAccount In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount).Include("GeneralLedgerOfficeCrossReference")
                               Where (GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing AndAlso
                                      GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode = OfficeCode) OrElse
                                     GeneralLedgerAccount.GeneralLedgerOfficeCrossReference Is Nothing
                               Select GeneralLedgerAccount

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleGLOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, GLOfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.GeneralLedgerAccounts, GLOfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal GeneralLedgerAccounts As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount), GLOfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            LoadWithOfficeLimits = From GeneralLedgerAccount In GeneralLedgerAccounts
                                   Where HasLimitedOfficeCodes = False OrElse
                                         GLOfficeCodes.Contains(GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode)
                                   Select GeneralLedgerAccount

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerAccount)

            Load = From GeneralLedgerAccount In DbContext.GetQuery(Of Database.Entities.GeneralLedgerAccount)
                   Select GeneralLedgerAccount

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GeneralLedgerAccounts.Add(GeneralLedgerAccount)

                ErrorText = GeneralLedgerAccount.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GeneralLedgerAccount)

                ErrorText = GeneralLedgerAccount.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GLACCOUNT WHERE GLACODE = '{0}'", GeneralLedgerAccount.Code))

                        Deleted = True

                    Catch ex As Exception

                    End Try

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
