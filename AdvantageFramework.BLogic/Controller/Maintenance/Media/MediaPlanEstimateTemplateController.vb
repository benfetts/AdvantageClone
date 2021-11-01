Namespace Controller.Maintenance.Media

    Public Class MediaPlanEstimateTemplateController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum DataTableColumns
            MediaTemplateTypeVendorID
            VendorName
            MediaTemplateTypeTacticID
            TotalPercent
            MediaTemplateTypeMarketID
            MediaTemplateTypeDaypartID
            MediaTemplateTypeSpotLengthID
            MediaTemplateTypeDemographicID
            MediaTemplateTypeQuarterID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub LoadPlanEstimateTemplates(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            ViewModel.PlanEstimateTemplates.Clear()
            ViewModel.PlanEstimateTemplates.AddRange(From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanEstimateTemplate).OrderByDescending(Function(RT) RT.IsSystem).ThenBy(Function(RT) RT.ID).ToList
                                                     Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate(Entity))

            SetIsMissingMappings(DbContext, ViewModel)

        End Sub
        Private Sub LoadTactics(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            ViewModel.Tactics.Clear()

            If ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                ViewModel.Tactics = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Tactic)(String.Format("exec advsp_media_plan_estimate_template_tactics {0}", ViewModel.SelectedPlanEstimateTemplate.ID)).ToList

            End If

        End Sub
        Private Sub LoadVendors(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            ViewModel.Vendors.Clear()

            If ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                ViewModel.Vendors = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor)(String.Format("exec advsp_media_plan_estimate_template_vendors {0}, '{1}'", ViewModel.SelectedPlanEstimateTemplate.ID, ViewModel.SelectedPlanEstimateTemplate.Type)).ToList

            End If

        End Sub
        Private Sub LoadMarkets(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            ViewModel.Markets.Clear()

            If ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                ViewModel.Markets = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Market)(String.Format("exec advsp_media_plan_estimate_template_markets {0}", ViewModel.SelectedPlanEstimateTemplate.ID)).ToList

            End If

        End Sub
        Private Sub LoadDayparts(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            ViewModel.Dayparts.Clear()

            If ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                ViewModel.Dayparts = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart)(String.Format("exec advsp_media_plan_estimate_template_dayparts {0}, '{1}'", ViewModel.SelectedPlanEstimateTemplate.ID, ViewModel.SelectedPlanEstimateTemplate.Type)).ToList

            End If

        End Sub
        Private Sub LoadSpotLengths(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Dim MediaPlanEstimateTemplateID As Integer = 0

            ViewModel.SpotLengths.Clear()

            If ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                MediaPlanEstimateTemplateID = ViewModel.SelectedPlanEstimateTemplate.ID

                ViewModel.SpotLengths.AddRange(From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanEstimateTemplateSpotLength).Where(Function(Entity) Entity.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateID).ToList
                                               Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength(Entity))

            End If

        End Sub
        Private Sub LoadDemographics(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            ViewModel.Demographics.Clear()

            If ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                ViewModel.Demographics = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Demographic)(String.Format("exec advsp_media_plan_estimate_template_demographics {0}, '{1}'", ViewModel.SelectedPlanEstimateTemplate.ID, ViewModel.SelectedPlanEstimateTemplate.Type)).ToList

            End If

        End Sub
        Private Sub LoadQuarters(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            ViewModel.Quarters.Clear()

            If ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                ViewModel.Quarters = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Quarter)(String.Format("exec advsp_media_plan_estimate_template_quarters {0}", ViewModel.SelectedPlanEstimateTemplate.ID)).ToList

            End If

        End Sub
        Private Sub LoadOutOfHomeTypes(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            ViewModel.OutdoorTypes.Clear()

            If ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                ViewModel.OutdoorTypes = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.OutdoorType)(String.Format("exec advsp_media_plan_estimate_template_outdoor_types {0}", ViewModel.SelectedPlanEstimateTemplate.ID)).ToList

            End If

        End Sub
        Private Sub LoadAdSizes(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            ViewModel.AdSizes.Clear()

            If ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                ViewModel.AdSizes = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.AdSize)(String.Format("exec advsp_media_plan_estimate_template_ad_sizes {0}, '{1}'", ViewModel.SelectedPlanEstimateTemplate.ID, ViewModel.SelectedPlanEstimateTemplate.Type)).ToList

            End If

        End Sub
        Private Sub LoadRateTypes(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            ViewModel.RateTypes.Clear()

            If ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                ViewModel.RateTypes = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.RateType)(String.Format("exec advsp_media_plan_estimate_template_rate_types {0}", ViewModel.SelectedPlanEstimateTemplate.ID)).ToList

            End If

        End Sub
        Private Sub SaveSelectedVendor(DbContext As AdvantageFramework.Database.DbContext, Checked As Boolean, MediaPlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate, VendorCode As String)

            Dim MediaPlanEstimateTemplateVendor As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateVendor = Nothing

            MediaPlanEstimateTemplateVendor = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateVendor).Where(Function(T) T.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID AndAlso
                                                                                                                                                            T.VendorCode = VendorCode).SingleOrDefault

            If Checked Then

                If MediaPlanEstimateTemplateVendor Is Nothing Then

                    MediaPlanEstimateTemplateVendor = New Database.Entities.MediaPlanEstimateTemplateVendor
                    MediaPlanEstimateTemplateVendor.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID
                    MediaPlanEstimateTemplateVendor.VendorCode = VendorCode

                    DbContext.MediaPlanEstimateTemplateVendors.Add(MediaPlanEstimateTemplateVendor)
                    DbContext.SaveChanges()

                End If

            Else

                If MediaPlanEstimateTemplateVendor IsNot Nothing AndAlso {"M", "N", "O"}.Contains(MediaPlanEstimateTemplate.Type) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR_ID = {1}", MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplateVendor.ID))

                ElseIf MediaPlanEstimateTemplateVendor IsNot Nothing AndAlso MediaPlanEstimateTemplate.Type = "I" Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR_ID = {1} AND INTERNET_TYPE_CODE IS NOT NULL", MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplateVendor.ID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND INTERNET_TYPE_CODE IS NULL", MediaPlanEstimateTemplate.ID))

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND VN_CODE = '{1}'", MediaPlanEstimateTemplate.ID, VendorCode))

            End If

        End Sub
        Private Sub SaveSelectedTactic(DbContext As AdvantageFramework.Database.DbContext, Checked As Boolean, MediaPlanEstimateTemplateID As Integer, MediaTacticID As Integer)

            Dim MediaPlanEstimateTemplateTactic As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateTactic = Nothing

            If Checked Then

                MediaPlanEstimateTemplateTactic = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateTactic).Where(Function(T) T.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateID AndAlso
                                                                                                                                                                T.MediaTacticID = MediaTacticID).SingleOrDefault

                If MediaPlanEstimateTemplateTactic Is Nothing Then

                    MediaPlanEstimateTemplateTactic = New Database.Entities.MediaPlanEstimateTemplateTactic
                    MediaPlanEstimateTemplateTactic.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateID
                    MediaPlanEstimateTemplateTactic.MediaTacticID = MediaTacticID

                    DbContext.MediaPlanEstimateTemplateTactics.Add(MediaPlanEstimateTemplateTactic)
                    DbContext.SaveChanges()

                End If

            Else

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplateID))

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_TACTIC_ID = {1}", MediaPlanEstimateTemplateID, MediaTacticID))

            End If

        End Sub
        Private Sub SaveSelectedMarket(DbContext As AdvantageFramework.Database.DbContext, Checked As Boolean, MediaPlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate, MarketCode As String)

            Dim MediaPlanEstimateTemplateMarket As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateMarket = Nothing

            MediaPlanEstimateTemplateMarket = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateMarket).Where(Function(T) T.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID AndAlso
                                                                                                                                                            T.MarketCode = MarketCode).SingleOrDefault

            If Checked Then

                If MediaPlanEstimateTemplateMarket Is Nothing Then

                    MediaPlanEstimateTemplateMarket = New Database.Entities.MediaPlanEstimateTemplateMarket
                    MediaPlanEstimateTemplateMarket.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID
                    MediaPlanEstimateTemplateMarket.MarketCode = MarketCode

                    DbContext.MediaPlanEstimateTemplateMarkets.Add(MediaPlanEstimateTemplateMarket)
                    DbContext.SaveChanges()

                End If

            Else

                If MediaPlanEstimateTemplateMarket IsNot Nothing AndAlso {"R", "T"}.Contains(MediaPlanEstimateTemplate.Type) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_ID = {1}", MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplateMarket.ID))

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MARKET_CODE = '{1}'", MediaPlanEstimateTemplate.ID, MarketCode))

            End If

        End Sub
        Private Sub SaveSelectedDemographic(DbContext As AdvantageFramework.Database.DbContext, Checked As Boolean, MediaPlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate, MediaDemoID As Integer)

            Dim MediaPlanEstimateTemplateDemographic As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDemographic = Nothing

            MediaPlanEstimateTemplateDemographic = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDemographic).Where(Function(T) T.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID AndAlso
                                                                                                                                                                      T.MediaDemoID = MediaDemoID).SingleOrDefault

            If Checked Then

                If MediaPlanEstimateTemplateDemographic Is Nothing Then

                    MediaPlanEstimateTemplateDemographic = New Database.Entities.MediaPlanEstimateTemplateDemographic
                    MediaPlanEstimateTemplateDemographic.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID
                    MediaPlanEstimateTemplateDemographic.MediaDemoID = MediaDemoID

                    DbContext.MediaPlanEstimateTemplateDemographics.Add(MediaPlanEstimateTemplateDemographic)
                    DbContext.SaveChanges()

                End If

            Else

                If MediaPlanEstimateTemplateDemographic IsNot Nothing AndAlso {"R", "T"}.Contains(MediaPlanEstimateTemplate.Type) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC_ID = {1}", MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplateDemographic.ID))

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_DEMO_ID = {1}", MediaPlanEstimateTemplate.ID, MediaDemoID))

            End If

        End Sub
        Private Sub SaveSelectedOutdoorType(DbContext As AdvantageFramework.Database.DbContext, Checked As Boolean, MediaPlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate, OutOfHomeTypeCode As String)

            Dim MediaPlanEstimateTemplateOutdoorType As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateOutdoorType = Nothing

            MediaPlanEstimateTemplateOutdoorType = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateOutdoorType).Where(Function(T) T.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID AndAlso
                                                                                                                                                                      T.OutOfHomeTypeCode = OutOfHomeTypeCode).SingleOrDefault

            If Checked Then

                If MediaPlanEstimateTemplateOutdoorType Is Nothing Then

                    MediaPlanEstimateTemplateOutdoorType = New Database.Entities.MediaPlanEstimateTemplateOutdoorType
                    MediaPlanEstimateTemplateOutdoorType.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID
                    MediaPlanEstimateTemplateOutdoorType.OutOfHomeTypeCode = OutOfHomeTypeCode

                    DbContext.MediaPlanEstimateTemplateOutdoorTypes.Add(MediaPlanEstimateTemplateOutdoorType)
                    DbContext.SaveChanges()

                End If

            Else

                If MediaPlanEstimateTemplateOutdoorType IsNot Nothing AndAlso {"M", "N", "O"}.Contains(MediaPlanEstimateTemplate.Type) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE_ID = {1}", MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplateOutdoorType.ID))

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND OD_CODE = '{1}'", MediaPlanEstimateTemplate.ID, OutOfHomeTypeCode))

            End If

        End Sub
        Private Sub SaveSelectedAdSize(DbContext As AdvantageFramework.Database.DbContext, Checked As Boolean, MediaPlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate, AdSizeCode As String)

            Dim MediaPlanEstimateTemplateAdSize As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateAdSize = Nothing

            MediaPlanEstimateTemplateAdSize = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateAdSize).Where(Function(T) T.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID AndAlso
                                                                                                                                                            T.AdSizeCode = AdSizeCode).SingleOrDefault

            If Checked Then

                If MediaPlanEstimateTemplateAdSize Is Nothing Then

                    MediaPlanEstimateTemplateAdSize = New Database.Entities.MediaPlanEstimateTemplateAdSize
                    MediaPlanEstimateTemplateAdSize.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID
                    MediaPlanEstimateTemplateAdSize.AdSizeCode = AdSizeCode

                    DbContext.MediaPlanEstimateTemplateAdSizes.Add(MediaPlanEstimateTemplateAdSize)
                    DbContext.SaveChanges()

                End If

            Else

                If MediaPlanEstimateTemplateAdSize IsNot Nothing AndAlso {"M", "N", "O"}.Contains(MediaPlanEstimateTemplate.Type) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE_ID = {1}", MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplateAdSize.ID))

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND SIZE_CODE = '{1}'", MediaPlanEstimateTemplate.ID, AdSizeCode))

            End If

        End Sub
        Private Sub SaveSelectedRateType(DbContext As AdvantageFramework.Database.DbContext, Checked As Boolean, MediaPlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate, RateType As Short)

            Dim MediaPlanEstimateTemplateRateType As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateRateType = Nothing

            MediaPlanEstimateTemplateRateType = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateRateType).Where(Function(T) T.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID AndAlso
                                                                                                                                                                T.RateType = RateType).SingleOrDefault

            If Checked Then

                If MediaPlanEstimateTemplateRateType Is Nothing Then

                    MediaPlanEstimateTemplateRateType = New Database.Entities.MediaPlanEstimateTemplateRateType
                    MediaPlanEstimateTemplateRateType.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID
                    MediaPlanEstimateTemplateRateType.RateType = RateType

                    DbContext.MediaPlanEstimateTemplateRateTypes.Add(MediaPlanEstimateTemplateRateType)
                    DbContext.SaveChanges()

                End If

            Else

                If MediaPlanEstimateTemplateRateType IsNot Nothing AndAlso {"M", "N", "O"}.Contains(MediaPlanEstimateTemplate.Type) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE_ID = {1}", MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplateRateType.ID))

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND RATE_TYPE = {1}", MediaPlanEstimateTemplate.ID, RateType))

            End If

        End Sub
        Private Sub SaveSelectedQuarter(DbContext As AdvantageFramework.Database.DbContext, Checked As Boolean, MediaPlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate, Quarter As Short)

            Dim MediaPlanEstimateTemplateQuarter As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateQuarter = Nothing

            MediaPlanEstimateTemplateQuarter = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateQuarter).Where(Function(T) T.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID AndAlso
                                                                                                                                                              T.Quarter = Quarter).SingleOrDefault

            If Checked Then

                If MediaPlanEstimateTemplateQuarter Is Nothing Then

                    MediaPlanEstimateTemplateQuarter = New Database.Entities.MediaPlanEstimateTemplateQuarter
                    MediaPlanEstimateTemplateQuarter.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID
                    MediaPlanEstimateTemplateQuarter.Quarter = Quarter

                    DbContext.MediaPlanEstimateTemplateQuarters.Add(MediaPlanEstimateTemplateQuarter)
                    DbContext.SaveChanges()

                End If

            Else

                If MediaPlanEstimateTemplateQuarter IsNot Nothing AndAlso {"M", "N", "O", "R", "T"}.Contains(MediaPlanEstimateTemplate.Type) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER_ID = {1}", MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplateQuarter.ID))

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND QUARTER = {1}", MediaPlanEstimateTemplate.ID, Quarter))

            End If

        End Sub
        Private Sub SaveSelectedDaypart(DbContext As AdvantageFramework.Database.DbContext, Checked As Boolean, MediaPlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate, DaypartID As Integer)

            Dim MediaPlanEstimateTemplateDaypart As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypart = Nothing
            Dim MediaPlanEstimateTemplateDaypartIDs As IEnumerable(Of Integer) = Nothing

            MediaPlanEstimateTemplateDaypart = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypart).Where(Function(T) T.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID AndAlso
                                                                                                                                                              T.DaypartID = DaypartID).SingleOrDefault

            If Checked Then

                If MediaPlanEstimateTemplateDaypart Is Nothing Then

                    MediaPlanEstimateTemplateDaypart = New Database.Entities.MediaPlanEstimateTemplateDaypart
                    MediaPlanEstimateTemplateDaypart.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID
                    MediaPlanEstimateTemplateDaypart.DaypartID = DaypartID

                    DbContext.MediaPlanEstimateTemplateDayparts.Add(MediaPlanEstimateTemplateDaypart)
                    DbContext.SaveChanges()

                End If

            Else

                If MediaPlanEstimateTemplateDaypart IsNot Nothing AndAlso {"R", "T"}.Contains(MediaPlanEstimateTemplate.Type) Then

                    MediaPlanEstimateTemplateDaypartIDs = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypart)
                                                           Where Entity.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID
                                                           Select Entity.ID).ToArray

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_ID = {1}", MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplateDaypart.ID))

                    If MediaPlanEstimateTemplateDaypartIDs IsNot Nothing AndAlso MediaPlanEstimateTemplateDaypartIDs.Count > 0 Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_PERCENT WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_ID IN ({0})", String.Join(",", MediaPlanEstimateTemplateDaypartIDs.ToArray)))

                    End If

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND DAY_PART_ID = {1}", MediaPlanEstimateTemplate.ID, DaypartID))

            End If

        End Sub
        Private Sub SetIsMissingMappings(DbContext As AdvantageFramework.Database.DbContext,
                                         ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            For Each PlanEstimateTemplate In PlanEstimateTemplateViewModel.PlanEstimateTemplates.Where(Function(PET) PET.IsSystem)

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND VN_CODE IS NULL", PlanEstimateTemplate.ID)).First > 0 OrElse
                            DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_TACTIC_ID IS NULL", PlanEstimateTemplate.ID)).First > 0 Then

                    PlanEstimateTemplate.IsMissingMappings = True

                Else

                    PlanEstimateTemplate.IsMissingMappings = False

                End If

            Next

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function AddPlanEstimateTemplate(ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel,
                                                PlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate) As Boolean

            'objects
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaPlanEstimateTemplate = New AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate

                PlanEstimateTemplate.SaveToEntity(MediaPlanEstimateTemplate)

                DbContext.MediaPlanEstimateTemplates.Add(MediaPlanEstimateTemplate)
                DbContext.SaveChanges()

                PlanEstimateTemplate.ID = MediaPlanEstimateTemplate.ID

                ViewModel.SelectedPlanEstimateTemplate = PlanEstimateTemplate

            End Using

            AddPlanEstimateTemplate = Added

        End Function
        Public Function AddSpotLength(SpotLength As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim MediaPlanEstimateTemplateSpotLength As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateSpotLength = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaPlanEstimateTemplateSpotLength = New AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateSpotLength

                MediaPlanEstimateTemplateSpotLength.DbContext = DbContext

                SpotLength.SaveToEntity(MediaPlanEstimateTemplateSpotLength)

                DbContext.MediaPlanEstimateTemplateSpotLengths.Add(MediaPlanEstimateTemplateSpotLength)

                Try

                    DbContext.SaveChanges()

                    Added = True

                    SpotLength.ID = MediaPlanEstimateTemplateSpotLength.ID

                Catch ex As SqlClient.SqlException
                    Added = False
                    ErrorMessage = ex.Message
                End Try

            End Using

            AddSpotLength = Added

        End Function
        Public Function DeleteSelectedPlanEstimateTemplate(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel) As Boolean

            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim Deleted As Boolean = True
            Dim MediaPlanEstimateTemplateDaypartIDs As IEnumerable(Of Integer) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate.ID)

                If MediaPlanEstimateTemplate IsNot Nothing Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))

                        MediaPlanEstimateTemplateDaypartIDs = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypart)
                                                               Where Entity.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID
                                                               Select Entity.ID).ToArray

                        If MediaPlanEstimateTemplateDaypartIDs IsNot Nothing AndAlso MediaPlanEstimateTemplateDaypartIDs.Count > 0 Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_PERCENT WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_ID IN ({0})", String.Join(",", MediaPlanEstimateTemplateDaypartIDs.ToArray)))

                        End If

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_PIVOT_FIELD WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0}", MediaPlanEstimateTemplate.ID))

                        DbContext.Entry(MediaPlanEstimateTemplate).State = Entity.EntityState.Deleted
                        DbContext.SaveChanges()

                        PlanEstimateTemplateViewModel.PlanEstimateTemplates.Remove(PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate)

                    Catch ex As Exception
                        Deleted = False
                    End Try

                End If

            End Using

            DeleteSelectedPlanEstimateTemplate = Deleted

        End Function
        Public Sub DeleteSelectedSpotLengths(SpotLengths As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength),
                                             ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each SpotLength In SpotLengths

                    PlanEstimateTemplateViewModel.SpotLengths.Remove(SpotLength)

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH_ID = {1}", PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate.ID, SpotLength.ID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH_ID = {0}", SpotLength.ID))

                Next

            End Using

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel

            Dim PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel = Nothing

            PlanEstimateTemplateViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadPlanEstimateTemplates(DbContext, PlanEstimateTemplateViewModel)

                PlanEstimateTemplateViewModel.RepositoryMediaTypes.AddRange(AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AccountPayableImportMediaType)))

            End Using

            Load = PlanEstimateTemplateViewModel

        End Function
        Public Sub LoadTactics(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadTactics(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Sub LoadVendors(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadVendors(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Sub LoadMarkets(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadMarkets(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Sub LoadDayparts(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadMarkets(DbContext, PlanEstimateTemplateViewModel)

                LoadDayparts(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Sub LoadSpotLengths(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadSpotLengths(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Sub LoadDemographics(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadDemographics(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Sub LoadQuarters(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadQuarters(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Sub LoadOutOfHomeTypes(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadOutOfHomeTypes(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Sub LoadAdSizes(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadAdSizes(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Sub LoadRateTypes(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadRateTypes(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Sub SetHasDatasFlag(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                PlanEstimateTemplateViewModel.HasPercentsDefined = False

                If PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate.ID)

                    If MediaPlanEstimateTemplate IsNot Nothing Then

                        PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate.HasDatas = (MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDatas.Count > 0)

                        If PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate.Type = "I" Then

                            Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplate.ID)).ToList

                            PlanEstimateTemplateViewModel.HasPercentsDefined = Datas.Any(Function(D) D.ID.HasValue)

                        ElseIf {"R", "T"}.Contains(PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate.Type) Then

                            If (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypart)
                                Where Entity.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID AndAlso
                                      Entity.MediaPlanEstimateTemplateDaypartPercents.Count > 0).Any Then

                                PlanEstimateTemplateViewModel.HasPercentsDefined = True

                            Else

                                PlanEstimateTemplateViewModel.HasPercentsDefined = False

                            End If

                        End If

                    End If

                End If

            End Using

        End Sub
        Public Sub SetDataEntryFlag(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim RateEntryEnabled As Boolean = False
            Dim PercentEntryEnabled As Boolean = False
            Dim TabCount As Integer = 0
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing

            If PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate.ID)

                    If MediaPlanEstimateTemplate IsNot Nothing Then

                        If MediaPlanEstimateTemplate.Type = "I" Then

                            If MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Count > 0 OrElse MediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics.Count > 0 Then

                                PercentEntryEnabled = True

                            End If

                            If MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Count > 0 AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.All(Function(V) String.IsNullOrWhiteSpace(V.VendorCode) = False) Then

                                RateEntryEnabled = True

                            End If

                        ElseIf MediaPlanEstimateTemplate.Type = "O" Then

                            If MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Count > 0 OrElse MediaPlanEstimateTemplate.MediaPlanEstimateTemplateOutdoorTypes.Count > 0 Then

                                RateEntryEnabled = True

                            End If

                        ElseIf {"M", "N"}.Contains(MediaPlanEstimateTemplate.Type) Then

                            If MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Count > 0 OrElse MediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes.Count > 0 Then

                                RateEntryEnabled = True

                            End If

                        ElseIf {"R", "T"}.Contains(MediaPlanEstimateTemplate.Type) Then

                            If MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts.Count > 0 Then

                                PercentEntryEnabled = True

                            End If

                            If MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDemographics.Count > 0 Then

                                TabCount += 1

                            End If

                            If MediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets.Count > 0 Then

                                TabCount += 1

                            End If

                            If MediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths.Count > 0 Then

                                TabCount += 1

                            End If

                            If TabCount > 0 AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts.Count > 0 Then

                                RateEntryEnabled = True

                            End If

                        End If

                    End If

                End Using

            End If

            PlanEstimateTemplateViewModel.RateEntryEnabled = RateEntryEnabled
            PlanEstimateTemplateViewModel.PercentEntryEnabled = PercentEntryEnabled

        End Sub
        Public Sub SaveTemplateTypes(ByRef PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim ErrorText As String = Nothing
            Dim PlanEstimateTemplateID As Integer = 0

            PlanEstimateTemplateID = PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate.ID

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each PlanEstimateTemplate In PlanEstimateTemplateViewModel.PlanEstimateTemplates

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(PlanEstimateTemplate.ID)

                    If MediaPlanEstimateTemplate IsNot Nothing Then

                        PlanEstimateTemplate.SaveToEntity(MediaPlanEstimateTemplate)

                        DbContext.Entry(MediaPlanEstimateTemplate).State = Entity.EntityState.Modified

                    End If

                Next

                DbContext.SaveChanges()

                LoadPlanEstimateTemplates(DbContext, PlanEstimateTemplateViewModel)

                PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate = PlanEstimateTemplateViewModel.PlanEstimateTemplates.Where(Function(PET) PET.ID = PlanEstimateTemplateID).FirstOrDefault

                If PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                    PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate = PlanEstimateTemplateViewModel.PlanEstimateTemplates.FirstOrDefault

                End If

            End Using

        End Sub
        Public Sub SaveSpotLengths(ByVal PlanEstimateTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Dim MediaPlanEstimateTemplateSpotLengths As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateSpotLength) = Nothing
            Dim MediaPlanEstimateTemplateSpotLength As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateSpotLength = Nothing
            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaPlanEstimateTemplateSpotLengths = (From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanEstimateTemplateSpotLength)
                                                        Where Entity.MediaPlanEstimateTemplateID = PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate.ID
                                                        Select Entity).ToList

                For Each MediaPlanEstimateTemplateSpotLength In MediaPlanEstimateTemplateSpotLengths

                    If PlanEstimateTemplateViewModel.SpotLengths.Select(Function(V) V.ID).ToArray.Contains(MediaPlanEstimateTemplateSpotLength.ID) = False Then

                        DbContext.Entry(MediaPlanEstimateTemplateSpotLength).State = Entity.EntityState.Deleted

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH_ID = {1}", PlanEstimateTemplateViewModel.SelectedPlanEstimateTemplate.ID, MediaPlanEstimateTemplateSpotLength.ID))

                    End If

                Next

                For Each SpotLength In PlanEstimateTemplateViewModel.SpotLengths

                    If SpotLength.ID = 0 Then

                        MediaPlanEstimateTemplateSpotLength = New Database.Entities.MediaPlanEstimateTemplateSpotLength

                        SpotLength.SaveToEntity(MediaPlanEstimateTemplateSpotLength)

                        DbContext.Entry(MediaPlanEstimateTemplateSpotLength).State = Entity.EntityState.Added

                    Else

                        MediaPlanEstimateTemplateSpotLength = DbContext.MediaPlanEstimateTemplateSpotLengths.Find(SpotLength.ID)

                        If MediaPlanEstimateTemplateSpotLength IsNot Nothing Then

                            SpotLength.SaveToEntity(MediaPlanEstimateTemplateSpotLength)

                            DbContext.Entry(MediaPlanEstimateTemplateSpotLength).State = Entity.EntityState.Modified

                        End If

                    End If

                Next

                DbContext.SaveChanges()

                LoadSpotLengths(DbContext, PlanEstimateTemplateViewModel)

            End Using

        End Sub
        Public Function ValidateEntity(DTO As AdvantageFramework.DTO.BaseClass, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, DTO, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext, ByRef DTO As DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim PlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate = Nothing
            Dim TemplateDetail As AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail = Nothing

            If DTO.GetType.Equals(GetType(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)) Then

                PlanEstimateTemplate = DTO

                PropertyValue = Value

                If PropertyName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Description.ToString Then

                    If String.IsNullOrWhiteSpace(PropertyValue) = False AndAlso (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate)
                                                                                 Where Entity.ID <> PlanEstimateTemplate.ID AndAlso
                                                                                       Entity.Type = PlanEstimateTemplate.Type AndAlso
                                                                                       Entity.Description.ToUpper = CStr(PropertyValue).ToUpper).Any Then

                        IsValid = False
                        ErrorText = "Description must be unique."

                    End If

                End If

            ElseIf DTO.GetType.Equals(GetType(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail)) Then

                TemplateDetail = DTO

                PropertyValue = Value

                If PropertyName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.PeriodType.ToString Then

                    If TemplateDetail.MediaType = "O" AndAlso PropertyValue = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                        IsValid = False
                        ErrorText = "Invalid period type."

                    ElseIf {"I", "M", "N", "R", "T"}.Contains(TemplateDetail.MediaType) AndAlso (PropertyValue = AdvantageFramework.MediaPlanning.PeriodTypes.None OrElse PropertyValue = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week) Then

                        IsValid = False
                        ErrorText = "Invalid period type."

                    End If

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function
        Public Function ValidateProperty(DTO As AdvantageFramework.DTO.BaseClass, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyValue As Object = Nothing
            Dim PlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate = Nothing
            Dim TemplateDetail As AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail = Nothing

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(DTO.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    ErrorText = Me.ValidateDTOProperty(DbContext, DataContext, DTO, PropertyDescriptor, IsValid, Value)

                    If DTO.GetType.Equals(GetType(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)) Then

                        PlanEstimateTemplate = DTO

                        PropertyValue = Value

                        If FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Description.ToString Then

                            If String.IsNullOrWhiteSpace(PropertyValue) = False AndAlso (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate)
                                                                                         Where Entity.Type = PlanEstimateTemplate.Type AndAlso
                                                                                               Entity.Description.ToUpper = CStr(PropertyValue).ToUpper).Any Then

                                IsValid = False
                                ErrorText = "Description must be unique."

                            End If

                        End If

                    ElseIf DTO.GetType.Equals(GetType(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail)) Then

                        TemplateDetail = DTO

                        PropertyValue = Value

                        If FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.PeriodType.ToString Then

                            If TemplateDetail.MediaType = "O" AndAlso PropertyValue = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                                IsValid = False
                                ErrorText = "Invalid period type."

                            ElseIf {"I", "M", "N", "R", "T"}.Contains(TemplateDetail.MediaType) AndAlso (PropertyValue = AdvantageFramework.MediaPlanning.PeriodTypes.None OrElse PropertyValue = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week) Then

                                IsValid = False
                                ErrorText = "Invalid period type."

                            End If

                        End If

                    End If

                End Using

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Sub SaveSelectedVendor(Checked As Boolean, Vendor As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor,
                                      ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Me.SaveSelectedVendor(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, Vendor.VendorCode)

            End Using

        End Sub
        Public Sub SaveAllVendors(Checked As Boolean, Vendors As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor),
                                  ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each Vendor In Vendors

                    Me.SaveSelectedVendor(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, Vendor.VendorCode)

                Next

                LoadVendors(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub SaveSelectedTactic(Checked As Boolean, Tactic As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Tactic,
                                      ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Me.SaveSelectedTactic(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate.ID, Tactic.MediaTacticID)

            End Using

        End Sub
        Public Sub SaveAllTactics(Checked As Boolean, Tactics As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Tactic),
                                  ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each Tactic In Tactics

                    Me.SaveSelectedTactic(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate.ID, Tactic.MediaTacticID)

                Next

                LoadTactics(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub SaveSelectedMarket(Checked As Boolean, Market As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Market,
                                      ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Me.SaveSelectedMarket(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, Market.MarketCode)

            End Using

        End Sub
        Public Sub SaveAllMarkets(Checked As Boolean, Markets As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Market),
                                  ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each Market In Markets

                    Me.SaveSelectedMarket(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, Market.MarketCode)

                Next

                LoadMarkets(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub SaveSelectedDemographic(Checked As Boolean, Demographic As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Demographic,
                                           ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Me.SaveSelectedDemographic(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, Demographic.MediaDemoID)

            End Using

        End Sub
        Public Sub SaveAllDemographics(Checked As Boolean, Demographics As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Demographic),
                                       ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each Demographic In Demographics

                    Me.SaveSelectedDemographic(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, Demographic.MediaDemoID)

                Next

                LoadDemographics(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub SaveSelectedOutdoorType(Checked As Boolean, OutdoorType As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.OutdoorType,
                                           ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Me.SaveSelectedOutdoorType(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, OutdoorType.OutOfHomeTypeCode)

            End Using

        End Sub
        Public Sub SaveAllOutdoorTypes(Checked As Boolean, OutdoorTypes As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.OutdoorType),
                                       ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each OutdoorType In OutdoorTypes

                    Me.SaveSelectedOutdoorType(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, OutdoorType.OutOfHomeTypeCode)

                Next

                LoadOutOfHomeTypes(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub SaveSelectedAdSize(Checked As Boolean, AdSize As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.AdSize,
                                      ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Me.SaveSelectedAdSize(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, AdSize.AdSizeCode)

            End Using

        End Sub
        Public Sub SaveAllAdSizes(Checked As Boolean, AdSizes As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.AdSize),
                                  ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each AdSize In AdSizes

                    Me.SaveSelectedAdSize(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, AdSize.AdSizeCode)

                Next

                LoadAdSizes(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub SaveSelectedRateType(Checked As Boolean, RateType As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.RateType,
                                        ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Me.SaveSelectedRateType(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, RateType.RateType)

            End Using

        End Sub
        Public Sub SaveAllRateTypes(Checked As Boolean, RateTypes As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.RateType),
                                    ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each RateType In RateTypes

                    Me.SaveSelectedRateType(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, RateType.RateType)

                Next

                LoadRateTypes(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub SaveSelectedQuarter(Checked As Boolean, Quarter As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Quarter,
                                        ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Me.SaveSelectedQuarter(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, Quarter.QuarterNumber)

            End Using

        End Sub
        Public Sub SaveAllQuarters(Checked As Boolean, Quarters As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Quarter),
                                    ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each Quarter In Quarters

                    Me.SaveSelectedQuarter(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, Quarter.QuarterNumber)

                Next

                LoadQuarters(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub SaveSelectedDaypart(Checked As Boolean, Daypart As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart,
                                       ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Me.SaveSelectedDaypart(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, Daypart.DaypartID)

            End Using

        End Sub
        Public Sub SaveAllDayparts(Checked As Boolean, Dayparts As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart),
                                   ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each Daypart In Dayparts

                    Me.SaveSelectedDaypart(DbContext, Checked, ViewModel.SelectedPlanEstimateTemplate, Daypart.DaypartID)

                Next

                LoadDayparts(DbContext, ViewModel)

            End Using

        End Sub
        Public Function CopyMediaPlanEstimateTemplate(ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim ID As Integer = 0
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim NewMediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim NewMediaPlanEstimateTemplateAdSize As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateAdSize = Nothing
            Dim NewMediaPlanEstimateTemplateData As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateData = Nothing
            Dim NewMediaPlanEstimateTemplateDaypart As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypart = Nothing
            Dim NewMediaPlanEstimateTemplateDaypartPercent As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypartPercent = Nothing
            Dim NewMediaPlanEstimateTemplateDemographic As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDemographic = Nothing
            Dim NewMediaPlanEstimateTemplateMarket As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateMarket = Nothing
            Dim NewMediaPlanEstimateTemplateOutdoorType As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateOutdoorType = Nothing
            Dim NewMediaPlanEstimateTemplateQuarter As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateQuarter = Nothing
            Dim NewMediaPlanEstimateTemplateRateType As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateRateType = Nothing
            Dim NewMediaPlanEstimateTemplateSpotLength As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateSpotLength = Nothing
            Dim NewMediaPlanEstimateTemplateTactic As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateTactic = Nothing
            Dim NewMediaPlanEstimateTemplateVendor As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateVendor = Nothing
            Dim CopyDescription As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                ID = ViewModel.SelectedPlanEstimateTemplate.ID

                MediaPlanEstimateTemplate = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate).Where(Function(Entity) Entity.ID = ID).SingleOrDefault

                If MediaPlanEstimateTemplate IsNot Nothing Then

                    If MediaPlanEstimateTemplate.Description.Length > 93 Then

                        CopyDescription = MediaPlanEstimateTemplate.Description.Substring(0, 93) & " (copy)"

                    Else

                        CopyDescription = MediaPlanEstimateTemplate.Description & " (copy)"

                    End If

                    If (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate)
                        Where Entity.Description.ToUpper = CopyDescription.ToUpper).Any Then

                        ErrorMessage = "A plan estimate template with the name: " & CopyDescription & " already exists!"

                    Else

                        DbTransaction = DbContext.Database.BeginTransaction

                        Try

                            NewMediaPlanEstimateTemplate = MediaPlanEstimateTemplate.DuplicateEntity
                            NewMediaPlanEstimateTemplate.IsSystem = False
                            NewMediaPlanEstimateTemplate.Description = CopyDescription

                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateAdSize)
                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateDatas = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateData)
                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypart)
                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateDemographics = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDemographic)
                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateMarket)
                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateOutdoorTypes = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateOutdoorType)
                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateQuarters = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateQuarter)
                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateRateTypes = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateRateType)
                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateSpotLength)
                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateTactic)
                            NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateVendor)

                            For Each MediaPlanEstimateTemplateAdSize In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes

                                NewMediaPlanEstimateTemplateAdSize = MediaPlanEstimateTemplateAdSize.DuplicateEntity

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes.Add(NewMediaPlanEstimateTemplateAdSize)

                            Next

                            For Each MediaPlanEstimateTemplateDaypart In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts

                                NewMediaPlanEstimateTemplateDaypart = MediaPlanEstimateTemplateDaypart.DuplicateEntity

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts.Add(NewMediaPlanEstimateTemplateDaypart)

                                NewMediaPlanEstimateTemplateDaypart.MediaPlanEstimateTemplateDaypartPercents = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypartPercent)

                                For Each MediaPlanEstimateTemplateDaypartPercent In MediaPlanEstimateTemplateDaypart.MediaPlanEstimateTemplateDaypartPercents

                                    NewMediaPlanEstimateTemplateDaypartPercent = MediaPlanEstimateTemplateDaypartPercent.DuplicateEntity

                                    NewMediaPlanEstimateTemplateDaypart.MediaPlanEstimateTemplateDaypartPercents.Add(NewMediaPlanEstimateTemplateDaypartPercent)

                                Next

                            Next

                            For Each MediaPlanEstimateTemplateDemographic In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDemographics

                                NewMediaPlanEstimateTemplateDemographic = MediaPlanEstimateTemplateDemographic.DuplicateEntity

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateDemographics.Add(NewMediaPlanEstimateTemplateDemographic)

                            Next

                            For Each MediaPlanEstimateTemplateMarket In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets

                                NewMediaPlanEstimateTemplateMarket = MediaPlanEstimateTemplateMarket.DuplicateEntity

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets.Add(NewMediaPlanEstimateTemplateMarket)

                            Next

                            For Each MediaPlanEstimateTemplateOutdoorType In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateOutdoorTypes

                                NewMediaPlanEstimateTemplateOutdoorType = MediaPlanEstimateTemplateOutdoorType.DuplicateEntity

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateOutdoorTypes.Add(NewMediaPlanEstimateTemplateOutdoorType)

                            Next

                            For Each MediaPlanEstimateTemplateQuarter In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateQuarters

                                NewMediaPlanEstimateTemplateQuarter = MediaPlanEstimateTemplateQuarter.DuplicateEntity

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateQuarters.Add(NewMediaPlanEstimateTemplateQuarter)

                            Next

                            For Each MediaPlanEstimateTemplateRateType In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateRateTypes

                                NewMediaPlanEstimateTemplateRateType = MediaPlanEstimateTemplateRateType.DuplicateEntity

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateRateTypes.Add(NewMediaPlanEstimateTemplateRateType)

                            Next

                            For Each MediaPlanEstimateTemplateSpotLength In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths

                                NewMediaPlanEstimateTemplateSpotLength = MediaPlanEstimateTemplateSpotLength.DuplicateEntity

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths.Add(NewMediaPlanEstimateTemplateSpotLength)

                            Next

                            For Each MediaPlanEstimateTemplateTactic In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics

                                NewMediaPlanEstimateTemplateTactic = MediaPlanEstimateTemplateTactic.DuplicateEntity

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics.Add(NewMediaPlanEstimateTemplateTactic)

                            Next

                            For Each MediaPlanEstimateTemplateVendor In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors

                                NewMediaPlanEstimateTemplateVendor = MediaPlanEstimateTemplateVendor.DuplicateEntity

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Add(NewMediaPlanEstimateTemplateVendor)

                            Next

                            DbContext.MediaPlanEstimateTemplates.Add(NewMediaPlanEstimateTemplate)

                            DbContext.SaveChanges()

                            For Each MediaPlanEstimateTemplateData In MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDatas

                                NewMediaPlanEstimateTemplateData = MediaPlanEstimateTemplateData.DuplicateEntity

                                If MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateAdSizeID.HasValue Then

                                    NewMediaPlanEstimateTemplateData.MediaPlanEstimateTemplateAdSizeID = NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes.Where(Function(T) T.AdSizeCode = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateAdSize.AdSizeCode).Select(Function(T) T.ID).First

                                End If

                                If MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateDaypartID.HasValue Then

                                    NewMediaPlanEstimateTemplateData.MediaPlanEstimateTemplateDaypartID = NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts.Where(Function(T) T.DaypartID = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateDaypart.DaypartID).Select(Function(T) T.ID).First

                                End If

                                If MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateDemographicID.HasValue Then

                                    NewMediaPlanEstimateTemplateData.MediaPlanEstimateTemplateDemographicID = NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateDemographics.Where(Function(T) T.MediaDemoID = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateDemographic.MediaDemoID).Select(Function(T) T.ID).First

                                End If

                                If MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateMarketID.HasValue Then

                                    NewMediaPlanEstimateTemplateData.MediaPlanEstimateTemplateMarketID = NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets.Where(Function(T) T.MarketCode = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateMarket.MarketCode).Select(Function(T) T.ID).First

                                End If

                                If MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateOutdoorTypeID.HasValue Then

                                    NewMediaPlanEstimateTemplateData.MediaPlanEstimateTemplateOutdoorTypeID = NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateOutdoorTypes.Where(Function(T) T.OutOfHomeTypeCode = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateOutdoorType.OutOfHomeTypeCode).Select(Function(T) T.ID).First

                                End If

                                If MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateQuarterID.HasValue Then

                                    NewMediaPlanEstimateTemplateData.MediaPlanEstimateTemplateQuarterID = NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateQuarters.Where(Function(T) T.Quarter = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateQuarter.Quarter).Select(Function(T) T.ID).First

                                End If

                                If MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateRateTypeID.HasValue Then

                                    NewMediaPlanEstimateTemplateData.MediaPlanEstimateTemplateRateTypeID = NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateRateTypes.Where(Function(T) T.RateType = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateRateType.RateType).Select(Function(T) T.ID).First

                                End If

                                If MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateSpotLengthID.HasValue Then

                                    NewMediaPlanEstimateTemplateData.MediaPlanEstimateTemplateSpotLengthID = NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths.Where(Function(T) T.SpotLength = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateSpotLength.SpotLength).Select(Function(T) T.ID).First

                                End If

                                If MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateTacticID.HasValue Then

                                    NewMediaPlanEstimateTemplateData.MediaPlanEstimateTemplateTacticID = NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics.Where(Function(T) T.MediaTacticID = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateTactic.MediaTacticID).Select(Function(T) T.ID).First

                                End If

                                If MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateVendorID.HasValue Then

                                    NewMediaPlanEstimateTemplateData.MediaPlanEstimateTemplateVendorID = NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Where(Function(T) T.VendorCode = MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateVendor.VendorCode).Select(Function(T) T.ID).First

                                End If

                                NewMediaPlanEstimateTemplate.MediaPlanEstimateTemplateDatas.Add(NewMediaPlanEstimateTemplateData)

                            Next

                            DbContext.SaveChanges()

                            Copied = True

                        Catch ex As Exception
                            ErrorMessage = ex.Message
                        End Try

                        If Copied Then

                            DbTransaction.Commit()

                            LoadPlanEstimateTemplates(DbContext, ViewModel)

                        Else

                            DbTransaction.Rollback()

                        End If

                    End If

                    DbContext.Database.Connection.Close()

                End If

            End Using

            CopyMediaPlanEstimateTemplate = Copied

        End Function
        Public Sub RefreshIsMissingMappings(ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SetIsMissingMappings(DbContext, ViewModel)

            End Using

        End Sub

#Region " DataEntry "

        Private Function GetTypeDescription(Type As String) As String

            Dim Description As String = String.Empty

            If Type = "I" Then

                Description = "Internet"

            ElseIf Type = "M" Then

                Description = "Magazine"

            ElseIf Type = "N" Then

                Description = "Newspaper"

            ElseIf Type = "O" Then

                Description = "Out of Home"

            ElseIf Type = "R" Then

                Description = "Radio"

            ElseIf Type = "T" Then

                Description = "Television"

            End If

            GetTypeDescription = Description

        End Function
        Private Sub SetDaypartsFlags(DbContext As AdvantageFramework.Database.DbContext, MediaPlanEstimateTemplateID As Integer,
                                     ByRef MediaPlanEstimateTemplateDataEntryViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateDataEntryViewModel)

            MediaPlanEstimateTemplateDataEntryViewModel.DaypartsSetupByMarket = False
            MediaPlanEstimateTemplateDataEntryViewModel.DaypartsSetup = False

            If {"R", "T"}.Contains(MediaPlanEstimateTemplateDataEntryViewModel.PlanEstimateTemplate.Type) Then

                MediaPlanEstimateTemplateDataEntryViewModel.IncludeMarket = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypartPercent)
                                                                             Where Entity.MediaPlanEstimateTemplateDaypart.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateID AndAlso
                                                                                   Entity.MarketCode IsNot Nothing).Any

                If (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypartPercent)
                    Where Entity.MediaPlanEstimateTemplateDaypart.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateID AndAlso
                          Entity.MarketCode IsNot Nothing AndAlso
                          Entity.Percentage <> 0).Any Then

                    MediaPlanEstimateTemplateDataEntryViewModel.DaypartsSetupByMarket = True

                ElseIf (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypartPercent)
                        Where Entity.MediaPlanEstimateTemplateDaypart.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateID AndAlso
                              Entity.MarketCode Is Nothing).Any Then

                    MediaPlanEstimateTemplateDataEntryViewModel.DaypartsSetup = True

                End If

            End If

        End Sub
        Public Function DataEntry_Load(MediaPlanEstimateTemplateID As Integer) As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateDataEntryViewModel

            'objects
            Dim MediaPlanEstimateTemplateDataEntryViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateDataEntryViewModel = Nothing
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing

            MediaPlanEstimateTemplateDataEntryViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateDataEntryViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanEstimateTemplateID)

                If MediaPlanEstimateTemplate IsNot Nothing Then

                    MediaPlanEstimateTemplateDataEntryViewModel.IsSystemTemplate = MediaPlanEstimateTemplate.IsSystem

                    MediaPlanEstimateTemplateDataEntryViewModel.PlanEstimateTemplate = New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate(MediaPlanEstimateTemplate)

                    MediaPlanEstimateTemplateDataEntryViewModel.TemplateTypeName = GetTypeDescription(MediaPlanEstimateTemplate.Type) & " - " & MediaPlanEstimateTemplate.Description

                    SetDaypartsFlags(DbContext, MediaPlanEstimateTemplateID, MediaPlanEstimateTemplateDataEntryViewModel)

                End If

            End Using

            DataEntry_Load = MediaPlanEstimateTemplateDataEntryViewModel

        End Function
        Public Function DataEntry_Save(ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateDataEntryViewModel, ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim MediaPlanEstimateTemplateData As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateData = Nothing
            Dim MediaPlanEstimateTemplatePivotField As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplatePivotField = Nothing
            Dim MediaPlanEstimateTemplateDaypartPercent As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypartPercent = Nothing
            Dim MediaPlanEstimateTemplateDaypartIDs As IEnumerable(Of Integer) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    For Each PivotField In ViewModel.PivotFields

                        MediaPlanEstimateTemplatePivotField = Nothing

                        If PivotField.ID <> 0 Then

                            MediaPlanEstimateTemplatePivotField = DbContext.MediaPlanEstimateTemplatePivotFields.Find(PivotField.ID)

                        End If

                        If MediaPlanEstimateTemplatePivotField IsNot Nothing Then

                            MediaPlanEstimateTemplatePivotField.Area = PivotField.Area
                            MediaPlanEstimateTemplatePivotField.AreaIndex = PivotField.AreaIndex
                            MediaPlanEstimateTemplatePivotField.Width = PivotField.Width

                            DbContext.Entry(MediaPlanEstimateTemplatePivotField).State = Entity.EntityState.Modified

                        Else

                            MediaPlanEstimateTemplatePivotField = New AdvantageFramework.Database.Entities.MediaPlanEstimateTemplatePivotField

                            PivotField.SaveToEntity(MediaPlanEstimateTemplatePivotField)

                            DbContext.MediaPlanEstimateTemplatePivotFields.Add(MediaPlanEstimateTemplatePivotField)
                            DbContext.SaveChanges()

                            PivotField.ID = MediaPlanEstimateTemplatePivotField.ID

                        End If

                    Next

                    If {"R", "T"}.Contains(ViewModel.PlanEstimateTemplate.Type) AndAlso ViewModel.ShowPercents Then

                        MediaPlanEstimateTemplateDaypartIDs = ViewModel.Datas.Where(Function(D) D.MediaPlanEstimateTemplateDaypartID.HasValue).Select(Function(D) D.MediaPlanEstimateTemplateDaypartID.Value).Distinct.ToArray

                        If MediaPlanEstimateTemplateDaypartIDs IsNot Nothing AndAlso MediaPlanEstimateTemplateDaypartIDs.Count > 0 Then

                            If ViewModel.Datas.Any(Function(D) D.MarketCode Is Nothing) Then

                                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_PERCENT WHERE MARKET_CODE IS NOT NULL AND MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_ID IN ({0})", String.Join(",", MediaPlanEstimateTemplateDaypartIDs.ToArray)))

                            ElseIf ViewModel.Datas.Any(Function(D) D.MarketCode IsNot Nothing) Then

                                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_PERCENT WHERE MARKET_CODE IS NULL AND MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_ID IN ({0})", String.Join(",", MediaPlanEstimateTemplateDaypartIDs.ToArray)))

                            End If

                        End If

                    End If

                    For Each DataDTO In ViewModel.Datas

                        If {"R", "T"}.Contains(ViewModel.PlanEstimateTemplate.Type) AndAlso ViewModel.ShowPercents Then

                            MediaPlanEstimateTemplateDaypartPercent = Nothing

                            If DataDTO.ID.HasValue Then

                                MediaPlanEstimateTemplateDaypartPercent = DbContext.MediaPlanEstimateTemplateDaypartPercents.Find(DataDTO.ID.Value)

                            End If

                            If MediaPlanEstimateTemplateDaypartPercent IsNot Nothing Then

                                MediaPlanEstimateTemplateDaypartPercent.Percentage = DataDTO.PercentageOrRate

                                DbContext.Entry(MediaPlanEstimateTemplateDaypartPercent).State = Entity.EntityState.Modified

                            Else

                                MediaPlanEstimateTemplateDaypartPercent = New AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateDaypartPercent
                                MediaPlanEstimateTemplateDaypartPercent.MediaPlanEstimateTemplateDaypartID = DataDTO.MediaPlanEstimateTemplateDaypartID
                                MediaPlanEstimateTemplateDaypartPercent.Percentage = DataDTO.PercentageOrRate
                                MediaPlanEstimateTemplateDaypartPercent.MarketCode = DataDTO.MarketCode

                                DbContext.MediaPlanEstimateTemplateDaypartPercents.Add(MediaPlanEstimateTemplateDaypartPercent)

                            End If

                        Else

                            MediaPlanEstimateTemplateData = Nothing

                            If DataDTO.ID.HasValue Then

                                MediaPlanEstimateTemplateData = DbContext.MediaPlanEstimateTemplateDatas.Find(DataDTO.ID.Value)

                            End If

                            If MediaPlanEstimateTemplateData IsNot Nothing Then

                                If ViewModel.PlanEstimateTemplate.Type = "I" AndAlso ViewModel.ShowPercents Then

                                    MediaPlanEstimateTemplateData.Percentage = DataDTO.PercentageOrRate

                                Else

                                    MediaPlanEstimateTemplateData.Rate = DataDTO.PercentageOrRate

                                End If

                                DbContext.Entry(MediaPlanEstimateTemplateData).State = Entity.EntityState.Modified

                            Else

                                MediaPlanEstimateTemplateData = New AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateData
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateID = ViewModel.PlanEstimateTemplate.ID
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateVendorID = DataDTO.MediaPlanEstimateTemplateVendorID
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateTacticID = DataDTO.MediaPlanEstimateTemplateMediaTacticID
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateMarketID = DataDTO.MediaPlanEstimateTemplateMarketID
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateDaypartID = DataDTO.MediaPlanEstimateTemplateDaypartID
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateSpotLengthID = DataDTO.MediaPlanEstimateTemplateSpotLengthID
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateDemographicID = DataDTO.MediaPlanEstimateTemplateDemographicID
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateQuarterID = DataDTO.MediaPlanEstimateTemplateQuarterID
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateOutdoorTypeID = DataDTO.MediaPlanEstimateTemplateOutdoorTypeID
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateAdSizeID = DataDTO.MediaPlanEstimateTemplateAdSizeID
                                MediaPlanEstimateTemplateData.MediaPlanEstimateTemplateRateTypeID = DataDTO.MediaPlanEstimateTemplateRateTypeID
                                MediaPlanEstimateTemplateData.InternetTypeCode = DataDTO.InternetTypeCode

                                If ViewModel.PlanEstimateTemplate.Type = "I" AndAlso ViewModel.ShowPercents Then

                                    MediaPlanEstimateTemplateData.Percentage = DataDTO.PercentageOrRate

                                Else

                                    MediaPlanEstimateTemplateData.Rate = DataDTO.PercentageOrRate

                                End If

                                DbContext.MediaPlanEstimateTemplateDatas.Add(MediaPlanEstimateTemplateData)

                            End If

                        End If

                        DbContext.SaveChanges()

                    Next

                    SetDaypartsFlags(DbContext, ViewModel.PlanEstimateTemplate.ID, ViewModel)

                End Using

                Saved = True

            Catch ex As Exception
                ErrorMessage = ex.Message
            End Try

            DataEntry_Save = Saved

        End Function
        Public Sub DataEntry_GetPivotData(ShowInternetRates As Boolean, ShowPercents As Boolean, IncludeMarket As Boolean,
                                          ByRef ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateDataEntryViewModel)

            Dim MediaPlanEstimateTemplateID As Integer = ViewModel.PlanEstimateTemplate.ID

            ViewModel.ShowInternetRates = ShowInternetRates
            ViewModel.ShowPercents = ShowPercents
            ViewModel.IncludeMarket = IncludeMarket

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If ShowInternetRates Then

                    ViewModel.Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}, 1", MediaPlanEstimateTemplateID)).ToList

                ElseIf {"R", "T"}.Contains(ViewModel.PlanEstimateTemplate.Type) AndAlso ShowPercents Then

                    ViewModel.Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_daypart_percents {0}, {1}", MediaPlanEstimateTemplateID, IncludeMarket)).ToList

                Else

                    ViewModel.Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                End If

                ViewModel.PivotFields.AddRange(From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanEstimateTemplatePivotField).Where(Function(Entity) Entity.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateID).ToList
                                               Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PivotField(Entity))

            End Using

        End Sub

#End Region

#Region " MediaPlanTemplate "

        Public Function MediaPlanTemplate_Load(MediaPlanTemplateHeaderID As Nullable(Of Integer)) As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel

            'objects
            Dim MediaPlanTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel = Nothing
            Dim MediaPlanTemplateHeader As AdvantageFramework.Database.Entities.MediaPlanTemplateHeader = Nothing

            MediaPlanTemplateViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaPlanTemplateViewModel.RepositoryPlanEstimateTemplates = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate)
                                                                              Select Entity).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate(Entity)).ToList

                MediaPlanTemplateViewModel.RepositorySalesClasses.AddRange(From SalesClass In AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext).ToList
                                                                           Select New AdvantageFramework.DTO.SalesClass(SalesClass))

                MediaPlanTemplateViewModel.RepositoryPeriodTypes.AddRange(AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)))

                If MediaPlanTemplateHeaderID.HasValue Then

                    MediaPlanTemplateHeader = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanTemplateHeader).Include("MediaPlanTemplateDetails").SingleOrDefault(Function(Entity) Entity.ID = MediaPlanTemplateHeaderID.Value)

                    If MediaPlanTemplateHeader IsNot Nothing Then

                        MediaPlanTemplateViewModel.PlanTemplate = New AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate(MediaPlanTemplateHeader)

                        For Each MediaPlanTemplateDetail In MediaPlanTemplateHeader.MediaPlanTemplateDetails

                            MediaPlanTemplateViewModel.TemplateDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail(MediaPlanTemplateDetail))

                        Next

                        MediaPlanTemplateViewModel.UpdateEnabled = True

                    End If

                Else

                    MediaPlanTemplateViewModel.PlanTemplate = New AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate()
                    MediaPlanTemplateViewModel.TemplateDetails = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail)
                    MediaPlanTemplateViewModel.AddEnabled = True

                End If

            End Using

            MediaPlanTemplate_Load = MediaPlanTemplateViewModel

        End Function
        Public Function MediaPlanTemplate_Add(ByRef MediaPlanTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MediaPlanTemplateHeader As AdvantageFramework.Database.Entities.MediaPlanTemplateHeader = Nothing
            Dim MediaPlanTemplateDetail As AdvantageFramework.Database.Entities.MediaPlanTemplateDetail = Nothing
            Dim Description As String = Nothing
            Dim ID As Integer = 0

            Description = MediaPlanTemplateViewModel.PlanTemplate.Description
            ID = MediaPlanTemplateViewModel.PlanTemplate.ID

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                If (From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanTemplateHeader)
                    Where Entity.Description.ToUpper = Description.ToUpper AndAlso
                          Entity.ID <> ID).Any Then

                    ErrorMessage = "A template with this description already exists!"

                ElseIf MediaPlanTemplateViewModel.TemplateDetails.Sum(Function(Entity) Entity.Percentage) <> 100 AndAlso MediaPlanTemplateViewModel.TemplateDetails.Sum(Function(Entity) Entity.Percentage) <> 0 Then

                    ErrorMessage = "Total must equal zero or 100%."

                Else

                    If ID <> 0 Then

                        MediaPlanTemplateHeader = DbContext.MediaPlanTemplateHeaders.Find(ID)
                        DbContext.Entry(MediaPlanTemplateHeader).State = Entity.EntityState.Modified

                    Else

                        MediaPlanTemplateHeader = New AdvantageFramework.Database.Entities.MediaPlanTemplateHeader
                        DbContext.MediaPlanTemplateHeaders.Add(MediaPlanTemplateHeader)

                    End If

                    MediaPlanTemplateHeader.Description = Description
                    MediaPlanTemplateHeader.IsInactive = False

                    For Each TemplateDetail In MediaPlanTemplateViewModel.TemplateDetails

                        MediaPlanTemplateDetail = New AdvantageFramework.Database.Entities.MediaPlanTemplateDetail

                        TemplateDetail.SaveToEntity(MediaPlanTemplateDetail)

                        MediaPlanTemplateDetail.MediaPlanEstimateTemplateID = TemplateDetail.MediaPlanEstimateTemplateID

                        DbContext.MediaPlanTemplateDetails.Add(MediaPlanTemplateDetail)

                    Next

                    Added = (DbContext.SaveChanges() > 0)

                End If

            End Using

            MediaPlanTemplate_Add = Added

        End Function
        Public Function MediaPlanTemplate_Save(ByRef MediaPlanTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim MediaPlanTemplateHeader As AdvantageFramework.Database.Entities.MediaPlanTemplateHeader = Nothing
            Dim MediaPlanTemplateDetail As AdvantageFramework.Database.Entities.MediaPlanTemplateDetail = Nothing
            Dim MediaPlanEstimateTemplateIDs As Generic.List(Of Integer) = Nothing

            If MediaPlanTemplateViewModel.TemplateDetails.Sum(Function(Entity) Entity.Percentage) <> 100 AndAlso MediaPlanTemplateViewModel.TemplateDetails.Sum(Function(Entity) Entity.Percentage) <> 0 Then

                ErrorMessage = "Total must equal zero or 100%."

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    MediaPlanTemplateHeader = DbContext.MediaPlanTemplateHeaders.Find(MediaPlanTemplateViewModel.PlanTemplate.ID)

                    DbContext.Entry(MediaPlanTemplateHeader).Collection(Function(Entity) Entity.MediaPlanTemplateDetails).Load()

                    MediaPlanTemplateViewModel.PlanTemplate.SaveToEntity(MediaPlanTemplateHeader)

                    MediaPlanEstimateTemplateIDs = New Generic.List(Of Integer)

                    For Each TemplateDetail In MediaPlanTemplateViewModel.TemplateDetails

                        MediaPlanTemplateDetail = MediaPlanTemplateHeader.MediaPlanTemplateDetails.SingleOrDefault(Function(Entity) Entity.MediaPlanEstimateTemplateID = TemplateDetail.MediaPlanEstimateTemplateID)

                        If MediaPlanTemplateDetail Is Nothing Then

                            MediaPlanTemplateDetail = New AdvantageFramework.Database.Entities.MediaPlanTemplateDetail

                            DbContext.MediaPlanTemplateDetails.Add(MediaPlanTemplateDetail)

                        End If

                        TemplateDetail.SaveToEntity(MediaPlanTemplateDetail)

                        MediaPlanEstimateTemplateIDs.Add(MediaPlanTemplateDetail.MediaPlanEstimateTemplateID)

                    Next

                    For Each MediaPlanTemplateDetail In MediaPlanTemplateHeader.MediaPlanTemplateDetails.ToList.Where(Function(Entity) MediaPlanEstimateTemplateIDs.Contains(Entity.MediaPlanEstimateTemplateID) = False)

                        DbContext.MediaPlanTemplateDetails.Remove(MediaPlanTemplateDetail)

                    Next

                    DbContext.SaveChanges()

                    Saved = True

                End Using

            End If

            MediaPlanTemplate_Save = Saved

        End Function
        Public Function MediaPlanTemplate_Delete(ByRef MediaPlanTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaPlanTemplateHeader As AdvantageFramework.Database.Entities.MediaPlanTemplateHeader = Nothing
            Dim MediaPlanTemplateDetail As AdvantageFramework.Database.Entities.MediaPlanTemplateDetail = Nothing
            Dim Deleted As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaPlanTemplateHeader = DbContext.MediaPlanTemplateHeaders.Find(MediaPlanTemplateViewModel.PlanTemplate.ID)

                If MediaPlanTemplateHeader IsNot Nothing Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_TEMPLATE_DETAIL WHERE MEDIA_PLAN_TEMPLATE_HEADER_ID = {0}", MediaPlanTemplateHeader.ID))

                    DbContext.MediaPlanTemplateHeaders.Remove(MediaPlanTemplateHeader)

                    DbContext.SaveChanges()

                    Deleted = True

                End If

            End Using

            MediaPlanTemplate_Delete = Deleted

        End Function
        Public Function MediaPlanTemplate_GetRepositoryPlanEstimateTemplates(MediaPlanTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel) As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)

            'objects
            Dim PlanEstimateTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate) = Nothing
            Dim MediaPlanEstimateTemplateIDs As IEnumerable(Of Integer) = Nothing
            'Dim SelectedMediaTypes As IEnumerable(Of String) = Nothing

            MediaPlanEstimateTemplateIDs = MediaPlanTemplateViewModel.TemplateDetails.Where(Function(TD) TD.MediaPlanEstimateTemplateID.HasValue).Select(Function(TD) TD.MediaPlanEstimateTemplateID.Value).ToArray
            'SelectedMediaTypes = MediaPlanTemplateViewModel.TemplateDetails.Select(Function(TD) TD.MediaType).ToArray

            PlanEstimateTemplates = (From Entity In MediaPlanTemplateViewModel.RepositoryPlanEstimateTemplates
                                     Where Entity.IsInactive = False AndAlso
                                           MediaPlanEstimateTemplateIDs.Contains(Entity.ID) = False
                                     Select Entity).ToList

            MediaPlanTemplate_GetRepositoryPlanEstimateTemplates = PlanEstimateTemplates

        End Function
        Public Sub MediaPlanTemplate_SetMediaType(MediaPlanEstimateTemplateID As Nullable(Of Integer), TemplateDetail As AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail)

            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim MediaTypeDescription As String = String.Empty

            If MediaPlanEstimateTemplateID.HasValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanEstimateTemplateID.Value)

                    If MediaPlanEstimateTemplate IsNot Nothing Then

                        TemplateDetail.MediaType = MediaPlanEstimateTemplate.Type

                        Select Case MediaPlanEstimateTemplate.Type
                            Case "I"
                                TemplateDetail.MediaTypeDescription = "Internet"
                            Case "M"
                                TemplateDetail.MediaTypeDescription = "Magazine"
                            Case "N"
                                TemplateDetail.MediaTypeDescription = "Newspaper"
                            Case "O"
                                TemplateDetail.MediaTypeDescription = "Out of Home"
                            Case "R"
                                TemplateDetail.MediaTypeDescription = "Radio"
                            Case "T"
                                TemplateDetail.MediaTypeDescription = "Television"
                        End Select

                    End If

                End Using

            Else

                TemplateDetail.MediaType = String.Empty
                TemplateDetail.MediaTypeDescription = String.Empty

            End If

            TemplateDetail.Percentage = 0
            TemplateDetail.SalesClassCode = Nothing
            TemplateDetail.PeriodType = Nothing

        End Sub
        Public Sub MediaPlanTemplate_SelectedTemplateDetailsChanged(ByRef MediaPlanTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel,
                                                                   IsNewItemRow As Boolean,
                                                                   TemplateDetails As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail))

            MediaPlanTemplateViewModel.SelectedTemplateDetails = TemplateDetails

            MediaPlanTemplateViewModel.PlanEstimateTemplates_IsNewRow = IsNewItemRow
            MediaPlanTemplateViewModel.PlanEstimateTemplates_CancelEnabled = IsNewItemRow
            MediaPlanTemplateViewModel.PlanEstimateTemplates_DeleteEnabled = (Not IsNewItemRow AndAlso MediaPlanTemplateViewModel.HasASelectedPlanEstimateTemplate)

        End Sub
        Public Sub MediaPlanTemplate_InitNewRowEvent(ByRef MediaPlanTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel)

            MediaPlanTemplateViewModel.PlanEstimateTemplates_IsNewRow = True
            MediaPlanTemplateViewModel.PlanEstimateTemplates_CancelEnabled = True
            MediaPlanTemplateViewModel.PlanEstimateTemplates_DeleteEnabled = False

        End Sub
        Public Sub MediaPlanTemplate_CancelNewItemRow(ByRef MediaPlanTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel)

            MediaPlanTemplateViewModel.PlanEstimateTemplates_IsNewRow = False
            MediaPlanTemplateViewModel.PlanEstimateTemplates_CancelEnabled = False
            MediaPlanTemplateViewModel.PlanEstimateTemplates_DeleteEnabled = MediaPlanTemplateViewModel.HasASelectedPlanEstimateTemplate

        End Sub
        Public Sub MediaPlanTemplate_Delete(ByRef MediaPlanTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel)

            If MediaPlanTemplateViewModel.HasASelectedPlanEstimateTemplate Then

                For Each TemplateDetail In MediaPlanTemplateViewModel.SelectedTemplateDetails

                    MediaPlanTemplateViewModel.TemplateDetails.Remove(TemplateDetail)

                Next

            End If

        End Sub
        Public Function MediaPlanTemplate_GetSalesClassesByMediaType(MediaType As String) As Generic.List(Of AdvantageFramework.DTO.SalesClass)

            Dim SalesClasses As Generic.List(Of AdvantageFramework.DTO.SalesClass) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SalesClasses = (From SalesClass In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActiveBySalesClassTypeCode(DbContext, MediaType).ToList
                                Select New AdvantageFramework.DTO.SalesClass(SalesClass)).ToList

            End Using

            MediaPlanTemplate_GetSalesClassesByMediaType = SalesClasses

        End Function
        Public Function MediaPlanTemplate_GetPeriodTypesByMediaType(MediaType As String) As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

            Dim PeriodTypes As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If MediaType = "O" Then

                    PeriodTypes = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "0").ToList

                Else

                    PeriodTypes = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "0" AndAlso Entity.Code <> "4").ToList

                End If

            End Using

            MediaPlanTemplate_GetPeriodTypesByMediaType = PeriodTypes

        End Function

#End Region

#Region " ProductTemplate "

        Private Sub ProductTemplate_LoadEstimateTemplates(DbContext As AdvantageFramework.Database.DbContext, ByRef ProductTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel)

            'objects
            Dim CDPs As IEnumerable(Of String) = Nothing
            Dim ProductPlanEstimateTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product) = Nothing
            'Dim ProductTemplateIDs As IEnumerable(Of Integer) = Nothing

            CDPs = ProductTemplateViewModel.SelectedProducts.Select(Function(P) P.ClientCode & "|" & P.DivisionCode & "|" & P.ProductCode).ToArray

            ProductPlanEstimateTemplates = (From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanEstimateTemplateProduct).Where(Function(Entity) CDPs.Contains(Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode)).ToList
                                            Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product(Entity)).ToList

            ProductTemplateViewModel.ProductPlanEstimateTemplates = ProductPlanEstimateTemplates

            'ProductTemplateIDs = ProductPlanEstimateTemplates.Select(Function(CTT) CTT.MediaPlanEstimateTemplateID).ToArray

            'ProductTemplateViewModel.PlanEstimateTemplates.Clear()

            'If CDPs.Count = 1 Then

            '    ProductTemplateViewModel.PlanEstimateTemplates.AddRange(From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanEstimateTemplate).Where(Function(Entity) ProductTemplateIDs.Contains(Entity.ID) = False).ToList
            '                                                            Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate(Entity))

            'Else

            'ProductTemplateViewModel.PlanEstimateTemplates.AddRange(From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanEstimateTemplate).ToList
            '                                                        Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate(Entity))

            'End If

        End Sub
        Private Sub ProductTemplate_LoadPlanTemplates(DbContext As AdvantageFramework.Database.DbContext, ByRef ProductTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel)

            'objects
            Dim CDPs As IEnumerable(Of String) = Nothing
            Dim ProductPlanTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product) = Nothing
            'Dim ProductTemplateIDs As IEnumerable(Of Integer) = Nothing

            CDPs = ProductTemplateViewModel.SelectedProducts.Select(Function(P) P.ClientCode & "|" & P.DivisionCode & "|" & P.ProductCode).ToArray

            ProductPlanTemplates = (From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanTemplateProduct).Where(Function(Entity) CDPs.Contains(Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode)).ToList
                                    Select New AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product(Entity)).ToList

            ProductTemplateViewModel.ProductPlanTemplates = ProductPlanTemplates

            'ProductTemplateIDs = ProductPlanTemplates.Select(Function(CTT) CTT.MediaPlanTemplateHeaderID).ToArray

            'ProductTemplateViewModel.PlanTemplates.Clear()

            'If CDPs.Count = 1 Then

            '    ProductTemplateViewModel.PlanTemplates.AddRange(From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanTemplateHeader).Where(Function(Entity) ProductTemplateIDs.Contains(Entity.ID) = False).ToList
            '                                                    Select New AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate(Entity))

            'Else

            'ProductTemplateViewModel.PlanTemplates.AddRange(From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanTemplateHeader).ToList
            '                                                Select New AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate(Entity))

            'End If

        End Sub
        Public Function ProductTemplate_Load(TemplateLevel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel) As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel

            'objects
            Dim ProductTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel = Nothing

            ProductTemplateViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel(TemplateLevel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                ProductTemplateViewModel.Products.AddRange(From Entity In DbContext.GetQuery(Of Database.Entities.Product).Include("Client").Include("Division").ToList
                                                           Select New AdvantageFramework.DTO.Product(Entity))

                ProductTemplateViewModel.PlanEstimateTemplates.AddRange(From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanEstimateTemplate).ToList
                                                                        Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate(Entity))

                ProductTemplateViewModel.PlanTemplates.AddRange(From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanTemplateHeader).ToList
                                                                Select New AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate(Entity))

            End Using

            ProductTemplate_Load = ProductTemplateViewModel

        End Function
        Public Sub ProductTemplate_LoadTemplates(ByRef ProductTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                If ProductTemplateViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate Then

                    ProductTemplate_LoadEstimateTemplates(DbContext, ProductTemplateViewModel)

                ElseIf ProductTemplateViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan Then

                    ProductTemplate_LoadPlanTemplates(DbContext, ProductTemplateViewModel)

                End If

            End Using

        End Sub
        Public Sub ClientTemplate_AddSelectedTemplate(ByRef ProductTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel)

            'objects
            Dim MediaPlanEstimateTemplateProduct As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateProduct = Nothing
            Dim AllMediaPlanEstimateTemplateProducts As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateProduct) = Nothing
            Dim MediaPlanTemplateProduct As AdvantageFramework.Database.Entities.MediaPlanTemplateProduct = Nothing
            Dim AllMediaPlanTemplateProducts As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanTemplateProduct) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                If ProductTemplateViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate Then

                    AllMediaPlanEstimateTemplateProducts = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateProduct).ToList

                    For Each PlanEstimateTemplate In ProductTemplateViewModel.SelectedPlanEstimateTemplates

                        For Each Product In ProductTemplateViewModel.SelectedProducts

                            If AllMediaPlanEstimateTemplateProducts.Where(Function(All) All.CDP = Product.CDP AndAlso All.MediaPlanEstimateTemplateID = PlanEstimateTemplate.ID).Any = False Then

                                MediaPlanEstimateTemplateProduct = New AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateProduct
                                MediaPlanEstimateTemplateProduct.ClientCode = Product.ClientCode
                                MediaPlanEstimateTemplateProduct.DivisionCode = Product.DivisionCode
                                MediaPlanEstimateTemplateProduct.ProductCode = Product.ProductCode
                                MediaPlanEstimateTemplateProduct.MediaPlanEstimateTemplateID = PlanEstimateTemplate.ID
                                MediaPlanEstimateTemplateProduct.IsDefault = False

                                DbContext.MediaPlanEstimateTemplateProducts.Add(MediaPlanEstimateTemplateProduct)

                            End If

                        Next

                    Next

                    DbContext.SaveChanges()

                    ProductTemplate_LoadEstimateTemplates(DbContext, ProductTemplateViewModel)

                ElseIf ProductTemplateViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan Then

                    AllMediaPlanTemplateProducts = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanTemplateProduct).ToList

                    For Each PlanTemplate In ProductTemplateViewModel.SelectedPlanTemplates

                        For Each Product In ProductTemplateViewModel.SelectedProducts

                            If AllMediaPlanTemplateProducts.Where(Function(All) All.CDP = Product.CDP AndAlso All.MediaPlanTemplateHeaderID = PlanTemplate.ID).Any = False Then

                                MediaPlanTemplateProduct = New AdvantageFramework.Database.Entities.MediaPlanTemplateProduct
                                MediaPlanTemplateProduct.ClientCode = Product.ClientCode
                                MediaPlanTemplateProduct.DivisionCode = Product.DivisionCode
                                MediaPlanTemplateProduct.ProductCode = Product.ProductCode
                                MediaPlanTemplateProduct.MediaPlanTemplateHeaderID = PlanTemplate.ID
                                MediaPlanTemplateProduct.IsDefault = False

                                DbContext.MediaPlanTemplateProducts.Add(MediaPlanTemplateProduct)

                            End If

                        Next

                    Next

                    DbContext.SaveChanges()

                    ProductTemplate_LoadPlanTemplates(DbContext, ProductTemplateViewModel)

                End If

            End Using

        End Sub
        Public Sub ClientTemplate_RemoveSelectedTemplate(ByRef ProductTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                If ProductTemplateViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate Then

                    For Each ClientPlanEstimateTemplate In ProductTemplateViewModel.SelectedProductPlanEstimateTemplates

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT_ID = {0}", ClientPlanEstimateTemplate.ID))

                    Next

                    ProductTemplate_LoadEstimateTemplates(DbContext, ProductTemplateViewModel)

                ElseIf ProductTemplateViewModel.Level = ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan Then

                    For Each ClientPlanTemplate In ProductTemplateViewModel.SelectedProductPlanTemplates

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_TEMPLATE_PRODUCT WHERE MEDIA_PLAN_TEMPLATE_PRODUCT_ID = {0}", ClientPlanTemplate.ID))

                    Next

                    ProductTemplate_LoadPlanTemplates(DbContext, ProductTemplateViewModel)

                End If

            End Using

        End Sub
        Public Function ProductTemplate_SetDefaultProductPlanEstimateTemplate(Product As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product,
                                                                              IsDefault As Boolean, ByRef ProductTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel) As Boolean

            'objects
            Dim DefaultSet As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If IsDefault Then

                    If (From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanEstimateTemplateProduct)
                        Where Entity.ClientCode = Product.ClientCode AndAlso
                              Entity.DivisionCode = Product.DivisionCode AndAlso
                              Entity.ProductCode = Product.ProductCode AndAlso
                              Entity.MediaPlanEstimateTemplate.Type = Product.MediaType.Substring(0, 1) AndAlso
                              Entity.IsDefault = True).Any = False Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT SET IS_DEFAULT = 1 WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT_ID = {0}", Product.ID))

                    Else

                        DefaultSet = False

                    End If

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT SET IS_DEFAULT = 0 WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT_ID = {0}", Product.ID))

                End If

            End Using

            ProductTemplate_SetDefaultProductPlanEstimateTemplate = DefaultSet

        End Function
        Public Function ProductTemplate_SetDefaultProductPlanTemplate(Product As AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product,
                                                                      IsDefault As Boolean, ByRef ProductTemplateViewModel As AdvantageFramework.ViewModels.Maintenance.Media.ProductTemplateViewModel) As Boolean

            'objects
            Dim DefaultSet As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If IsDefault Then

                    If (From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanTemplateProduct)
                        Where Entity.ClientCode = Product.ClientCode AndAlso
                              Entity.DivisionCode = Product.DivisionCode AndAlso
                              Entity.ProductCode = Product.ProductCode AndAlso
                              Entity.IsDefault = True).Any = False Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_TEMPLATE_PRODUCT SET IS_DEFAULT = 1 WHERE MEDIA_PLAN_TEMPLATE_PRODUCT_ID = {0}", Product.ID))

                    Else

                        DefaultSet = False

                    End If

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_TEMPLATE_PRODUCT SET IS_DEFAULT = 0 WHERE MEDIA_PLAN_TEMPLATE_PRODUCT_ID = {0}", Product.ID))

                End If

            End Using

            ProductTemplate_SetDefaultProductPlanTemplate = DefaultSet

        End Function
        Public Function ProductTemplate_SetDefaultProductPlanEstimateTemplate(ByRef Products As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product),
                                                                              IsDefault As Boolean) As Boolean

            'objects
            Dim DefaultSet As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each Product In Products

                    If IsDefault Then

                        If (From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanEstimateTemplateProduct)
                            Where Entity.ClientCode = Product.ClientCode AndAlso
                                  Entity.DivisionCode = Product.DivisionCode AndAlso
                                  Entity.ProductCode = Product.ProductCode AndAlso
                                  Entity.IsDefault = True).Any = False Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT SET IS_DEFAULT = 1 WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT_ID = {0}", Product.ID))

                            Product.IsDefault = True

                        Else

                            DefaultSet = False

                        End If

                    Else

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT SET IS_DEFAULT = 0 WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_PRODUCT_ID = {0}", Product.ID))

                        Product.IsDefault = False

                    End If

                Next

            End Using

            ProductTemplate_SetDefaultProductPlanEstimateTemplate = DefaultSet

        End Function
        Public Function ProductTemplate_SetDefaultProductPlanTemplate(ByRef Products As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product),
                                                                      IsDefault As Boolean) As Boolean

            'objects
            Dim DefaultSet As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each Product In Products

                    If IsDefault Then

                        If (From Entity In DbContext.GetQuery(Of Database.Entities.MediaPlanTemplateProduct)
                            Where Entity.ClientCode = Product.ClientCode AndAlso
                                  Entity.DivisionCode = Product.DivisionCode AndAlso
                                  Entity.ProductCode = Product.ProductCode AndAlso
                                  Entity.IsDefault = True).Any = False Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_TEMPLATE_PRODUCT SET IS_DEFAULT = 1 WHERE MEDIA_PLAN_TEMPLATE_PRODUCT_ID = {0}", Product.ID))

                            Product.IsDefault = True

                        Else

                            DefaultSet = False

                        End If

                    Else

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_TEMPLATE_PRODUCT SET IS_DEFAULT = 0 WHERE MEDIA_PLAN_TEMPLATE_PRODUCT_ID = {0}", Product.ID))

                        Product.IsDefault = False

                    End If

                Next

            End Using

            ProductTemplate_SetDefaultProductPlanTemplate = DefaultSet

        End Function

#End Region

#Region " TemplateMapping "

        Public Function TemplateMapping_Load() As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateMappingViewModel

            'objects
            Dim MediaPlanEstimateTemplateMappingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateMappingViewModel = Nothing

            MediaPlanEstimateTemplateMappingViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateMappingViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaPlanEstimateTemplateMappingViewModel.RepositoryVendors.AddRange(From Entity In AdvantageFramework.Database.Procedures.Vendor.LoadActiveByCategory(DbContext, "I").ToList
                                                                                     Select New AdvantageFramework.DTO.Vendor(Entity))

                MediaPlanEstimateTemplateMappingViewModel.VendorMappings.AddRange(From Entity In (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateVendor)
                                                                                                  Where Entity.Name IsNot Nothing 'AndAlso Entity.VendorCode Is Nothing
                                                                                                  Select Entity.VendorCode, Entity.Name).Distinct.ToList
                                                                                  Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.VendorMapping(Entity.VendorCode, Entity.Name))

                MediaPlanEstimateTemplateMappingViewModel.RepositoryMediaTactics.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaTactic.LoadAllActive(DbContext).ToList
                                                                                          Select New AdvantageFramework.DTO.MediaTactic(Entity))

                MediaPlanEstimateTemplateMappingViewModel.TacticMappings.AddRange(From Entity In (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateTactic)
                                                                                                  Where Entity.Description IsNot Nothing 'AndAlso Entity.MediaTacticID Is Nothing
                                                                                                  Select Entity.MediaTacticID, Entity.Description).Distinct.ToList
                                                                                  Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.TacticMapping(Entity.MediaTacticID, Entity.Description))

            End Using

            TemplateMapping_Load = MediaPlanEstimateTemplateMappingViewModel

        End Function
        Public Sub TemplateMapping_CreateMapTactics(TacticMappings As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.TacticMapping),
                                                    ByRef MediaPlanEstimateTemplateMappingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateMappingViewModel)

            Dim MediaTactic As AdvantageFramework.Database.Entities.MediaTactic = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each TacticMapping In TacticMappings

                    MediaTactic = (From Entity In AdvantageFramework.Database.Procedures.MediaTactic.Load(DbContext)
                                   Where Entity.Description.ToUpper = TacticMapping.SuggestedTactic.ToUpper
                                   Select Entity).FirstOrDefault

                    If MediaTactic Is Nothing Then

                        MediaTactic = New AdvantageFramework.Database.Entities.MediaTactic
                        MediaTactic.Description = TacticMapping.SuggestedTactic
                        MediaTactic.IsInactive = False

                        DbContext.MediaTactics.Add(MediaTactic)
                        DbContext.SaveChanges()

                    End If

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC SET MEDIA_TACTIC_ID = {0} WHERE DESCRIPTION = '{1}'", MediaTactic.ID, TacticMapping.SuggestedTactic))
                    TacticMapping.MediaTacticID = MediaTactic.ID

                Next

                MediaPlanEstimateTemplateMappingViewModel.RepositoryMediaTactics.Clear()
                MediaPlanEstimateTemplateMappingViewModel.RepositoryMediaTactics.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaTactic.LoadAllActive(DbContext).ToList
                                                                                          Select New AdvantageFramework.DTO.MediaTactic(Entity))

            End Using

        End Sub
        Public Function TemplateMapping_Save(ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateMappingViewModel,
                                             ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    For Each VendorMapping In ViewModel.VendorMappings

                        If String.IsNullOrWhiteSpace(VendorMapping.VendorCode) = False Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR SET VN_CODE = '{0}' WHERE NAME = '{1}'", VendorMapping.VendorCode, VendorMapping.SuggestedVendorName))

                        Else

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR SET VN_CODE = NULL WHERE NAME = '{0}'", VendorMapping.SuggestedVendorName))

                        End If

                    Next

                    For Each TacticMapping In ViewModel.TacticMappings

                        If TacticMapping.HasError = False Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC SET MEDIA_TACTIC_ID = {0} WHERE DESCRIPTION = '{1}'", TacticMapping.MediaTacticID, TacticMapping.SuggestedTactic))

                        Else

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC SET MEDIA_TACTIC_ID = NULL WHERE DESCRIPTION = '{0}'", TacticMapping.SuggestedTactic))

                        End If

                    Next

                Catch ex As Exception
                    Saved = False
                    ErrorMessage = ex.Message
                End Try

            End Using

            TemplateMapping_Save = Saved

        End Function

#End Region

#End Region

#End Region

    End Class

End Namespace
