Namespace Database.Procedures.CampaignView

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

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Collections.Generic.List(Of Database.Views.CampaignView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Collections.Generic.List(Of Database.Views.CampaignView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, DbContext.CampaignViews.ToList, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CampaignViews As System.Collections.Generic.List(Of AdvantageFramework.Database.Views.CampaignView), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Collections.Generic.List(Of Database.Views.CampaignView)

            LoadWithOfficeLimits = (From CampaignView In CampaignViews
                                    Group Join Product In AdvantageFramework.Database.Procedures.Product.LoadWithOfficeLimits(DbContext, OfficeCodes, HasLimitedOfficeCodes) On CampaignView.ClientCode Equals Product.ClientCode Into Prd = Group
                                    From Product In Prd.DefaultIfEmpty()
                                    Where Product IsNot Nothing AndAlso
                                          ((HasLimitedOfficeCodes = False OrElse
                                           (CampaignView.OfficeCode <> "" AndAlso OfficeCodes.Contains(CampaignView.OfficeCode)) OrElse
                                           (CampaignView.OfficeCode Is Nothing AndAlso OfficeCodes.Contains(Product.OfficeCode)))) AndAlso
                                          ((CampaignView.DivisionCode = Product.DivisionCode AndAlso CampaignView.ProductCode = Product.Code) OrElse
                                           (CampaignView.DivisionCode = Product.DivisionCode AndAlso CampaignView.ProductCode Is Nothing) OrElse
                                           (CampaignView.DivisionCode Is Nothing AndAlso CampaignView.ProductCode Is Nothing))
                                    Group By CampaignView Into CmpGrp = Group
                                    Select CmpGrp.FirstOrDefault.CampaignView).ToList

        End Function
        Public Function LoadByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Collections.Generic.List(Of AdvantageFramework.Database.Views.CampaignView)

            LoadByUserCodeWithOfficeLimits = LoadWithOfficeLimits(DbContext, LoadByUserCode(DbContext, SecurityDbContext, UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.CampaignView)

            Load = From CampaignView In DbContext.GetQuery(Of Database.Views.CampaignView)
                   Select CampaignView

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Collections.Generic.List(Of AdvantageFramework.Database.Views.CampaignView)

            'Dim UserClientDivisionProductAccess As IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim Campaigns As System.Collections.Generic.List(Of AdvantageFramework.Database.Views.CampaignView) = Nothing
            'Dim UniqueClients As String() = Nothing
            'Dim UniqueDivisions As String() = Nothing
            'Dim UniqueProducts As String() = Nothing

            Try

                Campaigns = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Views.CampaignView)(String.Format("EXEC [dbo].[advsp_campaign_load_by_usercode] '{0}'", UserCode)).ToList

                'UserClientDivisionProductAccess = (From Entity In SecurityDbContext.UserClientDivisionProductAccesses.ToList
                '                                   Where Entity.UserCode.ToUpper = UserCode.ToUpper
                '                                   Select Entity).ToList

                'If UserClientDivisionProductAccess.Count > 0 Then

                '    UniqueClients = UserClientDivisionProductAccess.Select(Function(item) item.ClientCode).Distinct().ToArray
                '    UniqueDivisions = UserClientDivisionProductAccess.Select(Function(item) item.ClientCode & "|" & item.DivisionCode).Distinct().ToArray
                '    UniqueProducts = UserClientDivisionProductAccess.Select(Function(item) item.ClientCode & "|" & item.DivisionCode & "|" & item.ProductCode).ToArray

                '    LoadByUserCode = From CampaignView In DbContext.CampaignViews
                '                     Let CDCode = CampaignView.ClientCode & "|" & CampaignView.DivisionCode, CDPCode = CDCode & "|" & CampaignView.ProductCode
                '                     Where (CampaignView.ClientCode <> "" AndAlso
                '                           CampaignView.DivisionCode <> "" AndAlso
                '                           CampaignView.ProductCode <> "" AndAlso
                '                           UniqueProducts.Contains(CDPCode)) OrElse
                '                          (CampaignView.ClientCode <> "" AndAlso
                '                           CampaignView.DivisionCode <> "" AndAlso
                '                           CampaignView.ProductCode Is Nothing AndAlso
                '                           UniqueDivisions.Contains(CDCode)) OrElse
                '                          (CampaignView.ClientCode <> "" AndAlso
                '                           CampaignView.DivisionCode Is Nothing AndAlso
                '                           CampaignView.ProductCode Is Nothing AndAlso
                '                           UniqueClients.Contains(CampaignView.ClientCode))
                '                     Select CampaignView

                'Else

                '    LoadByUserCode = From CampaignView In DbContext.CampaignViews
                '                     Select CampaignView

                'End If

            Catch ex As Exception
                Campaigns = Nothing
            End Try

            LoadByUserCode = Campaigns

        End Function

#End Region

    End Module

End Namespace
