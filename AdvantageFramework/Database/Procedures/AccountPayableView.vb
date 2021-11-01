Namespace Database.Procedures.AccountPayableView

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

        Public Function LoadDistinctWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountPayableView)

            LoadDistinctWithOfficeLimits = LoadWithOfficeLimits(DbContext, LoadDistinct(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountPayableView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountPayableView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, DbContext.AccountPayableViews, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableViews As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.AccountPayableView), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountPayableView)

            LoadWithOfficeLimits = From AccountPayableView In AccountPayableViews
                                   Join Vendor In Database.Procedures.Vendor.Load(DbContext) On AccountPayableView.VendorCode Equals Vendor.Code
                                   Where HasLimitedOfficeCodes = False OrElse
                                         (OfficeCodes.Contains(AccountPayableView.OfficeCode) AndAlso
                                         OfficeCodes.Contains(Vendor.OfficeCode))
                                   Select AccountPayableView

        End Function
        Public Function LoadDistinct(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountPayableView)

            LoadDistinct = From AccountPayableView In DbContext.AccountPayableViews
                           Group AccountPayableView By Key = AccountPayableView.ID Into Group
                           Select Group.FirstOrDefault

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AccountPayableView)

            Load = From AccountPayableView In DbContext.GetQuery(Of Database.Views.AccountPayableView)
                   Select AccountPayableView

        End Function

#End Region

    End Module

End Namespace
