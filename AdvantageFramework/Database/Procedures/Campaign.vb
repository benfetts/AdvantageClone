Namespace Database.Procedures.Campaign

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

        Public Function LoadCore(ByVal Campaigns As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Campaign)) As IEnumerable(Of AdvantageFramework.Database.Core.Campaign)

            Try

                LoadCore = Campaigns _
                           .Select(Function(Entity) New With {Entity.ID,
                                                              Entity.Code,
                                                              Entity.OfficeCode,
                                                              Entity.ClientCode,
                                                              Entity.DivisionCode,
                                                              Entity.ProductCode,
                                                              Entity.Name,
                                                              Entity.IsClosed}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.Campaign With {.ID = Entity.ID,
                                                                                                        .Code = Entity.Code,
                                                                                                        .OfficeCode = Entity.OfficeCode,
                                                                                                        .ClientCode = Entity.ClientCode,
                                                                                                        .DivisionCode = Entity.DivisionCode,
                                                                                                        .ProductCode = Entity.ProductCode,
                                                                                                        .Name = Entity.Name,
                                                                                                        .IsClosed = Entity.IsClosed}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.Campaign)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        Public Function LoadAllByClientDivisionAndProduct(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Campaign)

            If String.IsNullOrWhiteSpace(DivisionCode) Then

                DivisionCode = Nothing

            End If

            If String.IsNullOrWhiteSpace(ProductCode) Then

                ProductCode = Nothing

            End If

            LoadAllByClientDivisionAndProduct = From Entity In DbContext.GetQuery(Of Database.Entities.Campaign)
                                                Where Entity.ClientCode = ClientCode AndAlso
                                                      (Entity.DivisionCode = Nothing OrElse
                                                       Entity.DivisionCode = If(DivisionCode Is Nothing, Entity.DivisionCode, DivisionCode)) AndAlso
                                                      (Entity.ProductCode = Nothing OrElse
                                                       Entity.ProductCode = If(ProductCode Is Nothing, Entity.ProductCode, ProductCode))
                                                Select Entity

        End Function
        Public Function LoadByCampaignID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CampaignID As Integer) As AdvantageFramework.Database.Entities.Campaign

            Try

                LoadByCampaignID = (From Campaign In DbContext.GetQuery(Of Database.Entities.Campaign).Include("Client").Include("Division").Include("Product").Include("CampaignDetails")
                                    Where Campaign.ID = CampaignID
                                    Select Campaign).SingleOrDefault

            Catch ex As Exception
                LoadByCampaignID = Nothing
            End Try

        End Function
        Public Function LoadByCampaignCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CampaignCode As String) As AdvantageFramework.Database.Entities.Campaign

            Try

                LoadByCampaignCode = (From Campaign In DbContext.GetQuery(Of Database.Entities.Campaign)
                                      Where Campaign.Code = CampaignCode
                                      Select Campaign).SingleOrDefault

            Catch ex As Exception
                LoadByCampaignCode = Nothing
            End Try

        End Function
        Public Function LoadByCampaignCodeFirstRecord(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CampaignCode As String) As AdvantageFramework.Database.Entities.Campaign

            Try

                LoadByCampaignCodeFirstRecord = (From Campaign In DbContext.GetQuery(Of Database.Entities.Campaign)
                                                 Where Campaign.Code = CampaignCode
                                                 Select Campaign).FirstOrDefault

            Catch ex As Exception
                LoadByCampaignCodeFirstRecord = Nothing
            End Try

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Campaign)

            LoadByClientCode = From Campaign In DbContext.GetQuery(Of Database.Entities.Campaign)
                               Where Campaign.ClientCode = ClientCode
                               Select Campaign

        End Function
        Public Function LoadByClientCodeActive(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Campaign)

            LoadByClientCodeActive = From Campaign In DbContext.GetQuery(Of Database.Entities.Campaign)
                                     Where Campaign.ClientCode = ClientCode AndAlso
                                           Campaign.IsClosed = 0
                                     Select Campaign

        End Function
        Public Function LoadByClientCodeAndDivisionCodeAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Campaign)

            LoadByClientCodeAndDivisionCodeAndProductCode = From Campaign In DbContext.GetQuery(Of Database.Entities.Campaign)
                                                            Where Campaign.ClientCode = ClientCode AndAlso
                                                                  Campaign.DivisionCode = DivisionCode AndAlso
                                                                  Campaign.ProductCode = ProductCode
                                                            Select Campaign

        End Function
		Public Function LoadAllActiveCampaigns(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Campaign)

			LoadAllActiveCampaigns = From Campaign In DbContext.GetQuery(Of Database.Entities.Campaign)
									 Where Campaign.IsClosed = 0
									 Select Campaign

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Campaign)

            Load = From Campaign In DbContext.GetQuery(Of Database.Entities.Campaign)
                   Select Campaign

        End Function
        Public Function IsCampaignInUse(ByVal DbContext As Database.DbContext, ByVal CampaignID As Integer, ByVal CampaignCode As String, ByVal CheckCodeOnly As Boolean) As Boolean

            'objects
            Dim CampaignIsInUse As Boolean = True

            Try

                If DbContext.Database.Connection.State <> ConnectionState.Open Then

                    DbContext.Database.Connection.Open()

                End If

            Catch ex As Exception

            End Try

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.PRINT_ORDER WHERE CAMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.ACCT_REC WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.ALERT WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.BILL_COMMENT WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                'If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.BRDCAST_IMPORT WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.CMP_SLS_TEAM WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.CR_ON_ACCT WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.DASH_DATA_PROJ_HDR WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.EMP_TIME_INFO WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.ESTIMATE_LOG WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.IMP_ACCT_REC WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.INTERNET_HEADER WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.JOB_LOG WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.MAG_HEADER WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.MAGAZINE_HEADER WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.MEDIA_ORDER_HEADER WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.MISC_HEADER WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.NEWS_HEADER WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.NEWSPAPER_HEADER WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.OUTDOOR_HEADER WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.PARTNER_ALLOC_HDR WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.PRINT_EST_DTL WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.RADIO_HDR WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.TV_HDR WHERE CMP_CODE = '{0}'", CampaignCode)).FirstOrDefault = 0 Then

                                                                                                            CampaignIsInUse = False

                                                                                                        End If

                                                                                                    End If

                                                                                                End If

                                                                                            End If

                                                                                        End If

                                                                                    End If

                                                                                End If

                                                                            End If

                                                                        End If

                                                                    End If

                                                                End If

                                                            End If

                                                        End If

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

                'End If

                If CampaignIsInUse = False AndAlso CheckCodeOnly = False Then

                    CampaignIsInUse = True

                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.ALERT WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.AR_COOP_EST_SPLITS WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.AR_COOP_EST_TMP WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.AR_COOP_TMP WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.AR_SUMMARY WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.BILL_APPR_BATCH_CMP WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.CAMPAIGN_DOCUMENTS WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.DASH_DATA_PROJ_HDR WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.ESTIMATE_LOG WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.INTERNET_HEADER WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.JOB_LOG WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.MAG_HEADER WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.MAGAZINE_HEADER WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.MEDIA_PLAN_DTL WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.NEWS_HEADER WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.NEWSPAPER_HEADER WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.OUTDOOR_HEADER WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.PARTNER_ALLOC_HDR WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.PRINT_EST_DTL WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.PV_CMP WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.RADIO_HDR WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.RADIO_HEADER WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                                            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.TV_HDR WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.TV_HEADER WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                                                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.W_AR_FUNCTION WHERE CMP_IDENTIFIER = {0}", CampaignID)).FirstOrDefault = 0 Then

                                                                                                                        CampaignIsInUse = False

                                                                                                                    End If

                                                                                                                End If

                                                                                                            End If

                                                                                                        End If

                                                                                                    End If

                                                                                                End If

                                                                                            End If

                                                                                        End If

                                                                                    End If

                                                                                End If

                                                                            End If

                                                                        End If

                                                                    End If

                                                                End If

                                                            End If

                                                        End If

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                CampaignIsInUse = True
            End Try

            Try

                DbContext.Database.Connection.Close()

            Catch ex As Exception

            End Try

            IsCampaignInUse = CampaignIsInUse

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Campaign As AdvantageFramework.Database.Entities.Campaign) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Campaigns.Add(Campaign)

                ErrorText = Campaign.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.Campaigns.Count = 0 Then

                        Campaign.ID = 1

                    Else

                        Campaign.ID = (From Entity In DbContext.GetQuery(Of Database.Entities.Campaign)
                                       Select Entity.ID).Max + 1

                    End If

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Campaign As AdvantageFramework.Database.Entities.Campaign, Optional ByRef ErrorMessage As String = "") As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Campaign)

                ErrorText = Campaign.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)
                    ErrorMessage = ErrorText

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Campaign As AdvantageFramework.Database.Entities.Campaign) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    If IsCampaignInUse(DbContext, Campaign.ID, Campaign.Code, False) = False Then

                        If AdvantageFramework.Database.Procedures.CampaignDetail.DeleteByCampaignID(DbContext, Campaign.ID) Then

                            DbContext.DeleteEntityObject(Campaign)

                            DbContext.SaveChanges()

                            Deleted = True

                        End If

                    End If

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
