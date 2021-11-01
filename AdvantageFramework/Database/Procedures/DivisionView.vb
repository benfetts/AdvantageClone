Namespace Database.Procedures.DivisionView

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

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.DivisionView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.DivisionView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, DbContext.DivisionViews, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Divisions As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.DivisionView), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.DivisionView)

            LoadWithOfficeLimits = From Division In Divisions
                                   Join Product In AdvantageFramework.Database.Procedures.Product.LoadWithOfficeLimits(DbContext, OfficeCodes, HasLimitedOfficeCodes) On Division.ClientCode Equals Product.ClientCode And Division.DivisionCode Equals Product.DivisionCode
                                   Where HasLimitedOfficeCodes = False OrElse
                                         OfficeCodes.Contains(Product.OfficeCode)
                                   Select Division Distinct

        End Function
        Public Function LoadAllActiveByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.DivisionView)

            LoadAllActiveByUserCodeWithOfficeLimits = LoadWithOfficeLimits(DbContext, LoadAllActiveByUserCode(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.DivisionView)

            LoadByUserCodeWithOfficeLimits = LoadWithOfficeLimits(DbContext, LoadByUserCode(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.DivisionView)

            LoadAllActiveByUserCode = From Division In LoadByUserCode(DbContext, SecurityDbContext, UserCode)
                                      Where Division.IsActive = 1
                                      Select Division

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.DivisionView)

            Load = From DivisionView In DbContext.GetQuery(Of Database.Views.DivisionView)
                   Select DivisionView

        End Function
        Public Function LoadByClientCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.DivisionView)

            LoadByClientCode = From Division In DbContext.GetQuery(Of Database.Views.DivisionView)
                               Where Division.ClientCode = ClientCode
                               Select Division

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.DivisionView)

            Dim UserClientDivisionProductAccess As IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim UniqueKeyValues As String() = Nothing

            Try

                UserClientDivisionProductAccess = (From Entity In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess).ToList
                                                   Where Entity.UserCode.ToUpper = UserCode.ToUpper
                                                   Select Entity).ToList

                If UserClientDivisionProductAccess.Count > 0 Then

                    UniqueKeyValues = (From Entity In UserClientDivisionProductAccess
                                       Select Entity.ClientCode & "|" & Entity.DivisionCode).ToArray

                    LoadByUserCode = From Division In DbContext.GetQuery(Of Database.Views.DivisionView)
                                     Where UniqueKeyValues.Contains(Division.ClientCode & "|" & Division.DivisionCode)
                                     Select Division

                Else

                    LoadByUserCode = From Division In DbContext.GetQuery(Of Database.Views.DivisionView)
                                     Select Division

                End If

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
