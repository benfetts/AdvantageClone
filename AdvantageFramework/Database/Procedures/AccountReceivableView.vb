Namespace Database.Procedures.AccountReceivableView

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

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As Security.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountReceivableView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, SecurityDbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As Security.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountReceivableView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, SecurityDbContext, DbContext.AccountReceivableViews, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As Security.Database.DbContext, ByVal AccountReceivableViews As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.AccountReceivableView), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountReceivableView)

            LoadWithOfficeLimits = From AccountReceivableView In AccountReceivableViews
                                   Join Product In Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(DbContext, SecurityDbContext, DbContext.UserCode, False, False, OfficeCodes, HasLimitedOfficeCodes) On AccountReceivableView.ClientCode Equals Product.ClientCode And
                                                                                                                                                                                                                                 AccountReceivableView.DivisionCode Equals Product.DivisionCode And
                                                                                                                                                                                                                                 AccountReceivableView.ProductCode Equals Product.Code
                                   Where HasLimitedOfficeCodes = False OrElse
                                         OfficeCodes.Contains(AccountReceivableView.OfficeCode) AndAlso
                                         OfficeCodes.Contains(Product.OfficeCode)
                                   Select AccountReceivableView

        End Function
        Public Function LoadWithOfficeLimitsAR(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As Security.Database.DbContext, ByVal AccountReceivableViews As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.AccountReceivableView), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountReceivableView)

            LoadWithOfficeLimitsAR = From AccountReceivableView In AccountReceivableViews
                                     Group Join Product In AdvantageFramework.Database.Procedures.Product.LoadWithOfficeLimits(DbContext, OfficeCodes, HasLimitedOfficeCodes) On AccountReceivableView.ClientCode Equals Product.ClientCode Into Prd = Group
                                     From Product In Prd.DefaultIfEmpty()
                                     Where ((HasLimitedOfficeCodes = False OrElse
                                          (AccountReceivableView.OfficeCode <> "" AndAlso OfficeCodes.Contains(AccountReceivableView.OfficeCode)) OrElse
                                          (AccountReceivableView.OfficeCode Is Nothing AndAlso OfficeCodes.Contains(Product.OfficeCode)))) AndAlso
                                        ((AccountReceivableView.DivisionCode = Product.DivisionCode AndAlso AccountReceivableView.ProductCode = Product.Code) OrElse
                                         (AccountReceivableView.DivisionCode = Product.DivisionCode AndAlso AccountReceivableView.ProductCode Is Nothing) OrElse
                                         (AccountReceivableView.DivisionCode Is Nothing AndAlso AccountReceivableView.ProductCode Is Nothing))
                                     Group By AccountReceivableView Into CmpGrp = Group
                                     Select CmpGrp.FirstOrDefault.AccountReceivableView

        End Function

        Public Function LoadNonVoidedInvoicesWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As Security.Database.DbContext, ByVal Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountReceivableView)

            LoadNonVoidedInvoicesWithOfficeLimits = LoadWithOfficeLimits(DbContext, SecurityDbContext, LoadNonVoidedInvoices(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadNonVoidedInvoicesWithOfficeLimitsAR(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As Security.Database.DbContext, ByVal Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountReceivableView)

            LoadNonVoidedInvoicesWithOfficeLimitsAR = LoadWithOfficeLimitsAR(DbContext, SecurityDbContext, LoadNonVoidedInvoices(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadNonVoidedInvoices(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountReceivableView)

            LoadNonVoidedInvoices = From AccountReceivableView In DbContext.AccountReceivableViews
                                    Where (AccountReceivableView.IsVoided Is Nothing OrElse
                                           AccountReceivableView.IsVoided = 0) AndAlso
                                          AccountReceivableView.SequenceNumber <> 99
                                    Select AccountReceivableView

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountReceivableView)

            Load = From AccountReceivableView In DbContext.GetQuery(Of Database.Views.AccountReceivableView)
                   Select AccountReceivableView

        End Function

#End Region

    End Module

End Namespace
