IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_tv_worksheet_rating_cable]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_tv_worksheet_rating_cable]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_ncc_tv_fusion_hutput]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_ncc_tv_fusion_hutput]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_nielsen_spot_tv_research_results]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_nielsen_spot_tv_research_results]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_tv_worksheet_rating]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_tv_worksheet_rating]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_hutput_spot_tv_research]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_nielsen_hutput_spot_tv_research]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_nielsen_radio_audience_metrics]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_nielsen_radio_audience_metrics]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_radio_worksheet_rating]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_radio_worksheet_rating]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_intab_spot_tv_research]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_nielsen_intab_spot_tv_research]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_radio_audience_get_cume]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_nielsen_radio_audience_get_cume]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_tv_cume_impressions]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_nielsen_tv_cume_impressions]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_tv_worksheet_rating_program_drilldown]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_tv_worksheet_rating_program_drilldown]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_tv_worksheet_rating_cable_program_drilldown]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_tv_worksheet_rating_cable_program_drilldown]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_ncc_tv_fusion_audience]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_ncc_tv_fusion_audience]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_audience_spot_tv_research]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_nielsen_audience_spot_tv_research]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_radio_audience_get_aqh]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_nielsen_radio_audience_get_aqh]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_ncc_tv_fusion_audience_book_weeks]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_ncc_tv_fusion_audience_book_weeks]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_ncc_tv_fusion_hutput_book_weeks]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_ncc_tv_fusion_hutput_book_weeks]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_audience_tv_book_weeks]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_nielsen_audience_tv_book_weeks]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_hutput_tv_book_weeks]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_nielsen_hutput_tv_book_weeks]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_intab_tv_book_weeks]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[advtf_nielsen_intab_tv_book_weeks]
GO