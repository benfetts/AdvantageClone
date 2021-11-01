Namespace Database.Procedures.ProductView

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

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ProductView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ProductView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.ProductViews, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal Products As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.ProductView), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ProductView)

            LoadWithOfficeLimits = From Product In Products
                                   Where HasLimitedOfficeCodes = False OrElse
                                         OfficeCodes.Contains(Product.OfficeCode)
                                   Select Product

        End Function
        Public Function LoadWithOfficeLimits(ByVal Products As System.Collections.Generic.List(Of AdvantageFramework.Database.Views.ProductView), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Collections.Generic.List(Of Database.Views.ProductView)

            LoadWithOfficeLimits = (From Product In Products
                                    Where HasLimitedOfficeCodes = False OrElse
                                          OfficeCodes.Contains(Product.OfficeCode)
                                    Select Product).ToList

        End Function
        Public Function LoadAllActiveByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.ProductView)

            LoadAllActiveByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadAllActiveByUserCode(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext, Optional ByVal ActiveOnly As Boolean = False) As System.Collections.Generic.List(Of AdvantageFramework.Database.Views.ProductView)

            LoadByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadByUserCode(DbContext, SecurityDbContext, Session.UserCode, ActiveOnly), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes).ToList

        End Function
        Public Function LoadByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.ProductView)

            LoadByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadByUserCode(DbContext, SecurityDbContext, Session.UserCode, False), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.ProductView)

            LoadAllActiveByUserCode = LoadByUserCode(DbContext, SecurityDbContext, UserCode, True)

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                               ByVal UserCode As String, Optional ByVal ActiveOnly As Boolean = False) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.ProductView)

            'Dim UserClientDivisionProductAccess As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            'Dim Products As String() = Nothing

            Try

                'UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode).ToList

                If AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode).Count > 0 Then

                    'Products = UserClientDivisionProductAccess.Select(Function(ucdpa) ucdpa.ClientCode & "|" & ucdpa.DivisionCode & "|" & ucdpa.ProductCode).ToArray

                    LoadByUserCode = From ProductView In DbContext.GetQuery(Of AdvantageFramework.Database.Views.ProductView)
                                     Let CDCode = ProductView.ClientCode & "|" & ProductView.DivisionCode, CDPCode = CDCode & "|" & ProductView.ProductCode
                                     Where (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.UserClientDivisionProductAccess)
                                            Where Entity.UserCode.ToUpper = UserCode.ToUpper
                                            Select Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode).Contains(CDPCode)
                                     Select ProductView

                Else

                    LoadByUserCode = From ProductView In DbContext.GetQuery(Of Database.Views.ProductView)
                                     Select ProductView

                End If

                If ActiveOnly Then

                    LoadByUserCode = LoadByUserCode.Where(Function(Product) Product.IsActive = 1)

                End If

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ProductView)

            Load = From ProductView In DbContext.GetQuery(Of Database.Views.ProductView)
                   Select ProductView

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.ProductView)

            LoadAllActive = From ProductView In DbContext.GetQuery(Of Database.Views.ProductView)
                            Where ProductView.IsActive = 1
                            Select ProductView

        End Function
        Public Function LoadByClientAndDivisionCode(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.ProductView)

            LoadByClientAndDivisionCode = From ProductView In DbContext.GetQuery(Of Database.Views.ProductView)
                                          Where ProductView.ClientCode = ClientCode AndAlso
                                                ProductView.DivisionCode = DivisionCode
                                          Select ProductView

        End Function


#End Region

    End Module

End Namespace
