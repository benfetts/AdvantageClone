/****** Object:  StoredProcedure [dbo].[usp_wv_Estimating_Quote_Revise]    Script Date: 10/2/2017 1:48:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_wv_Estimating_Quote_Revise]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_wv_Estimating_Quote_Revise]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_wv_Estimating_Quote_Revise] 
@EstNo Int,
@EstCompNo Int,
@QuoteNo Int,
@NewQuoteRev Int
AS

INSERT INTO [dbo].[ESTIMATE_REV_DET]
           ([ESTIMATE_NUMBER]
           ,[EST_COMPONENT_NBR]
           ,[EST_QUOTE_NBR]
           ,[EST_REV_NBR]
           ,[SEQ_NBR]
           ,[FNC_CODE]
           ,[EST_REV_COMM_PCT]
           ,[EST_REV_CONT_PCT]
           ,[EST_REV_QUANTITY]
           ,[EST_REV_RATE]
           ,[EST_REV_SUP_BY_CDE]
           ,[EST_REV_SUP_BY_NTE]
           ,[EST_REV_EXT_AMT]
           ,[TAX_CODE]
           ,[EST_FNC_COMMENT]
           ,[TAX_STATE_PCT]
           ,[TAX_COUNTY_PCT]
           ,[TAX_CITY_PCT]
           ,[TAX_COMM]
           ,[TAX_COMM_ONLY]
           ,[TAX_RESALE]
           ,[EXT_MARKUP_AMT]
           ,[EXT_NONRESALE_TAX]
           ,[EXT_STATE_RESALE]
           ,[EXT_COUNTY_RESALE]
           ,[EXT_CITY_RESALE]
           ,[EXT_CONTINGENCY]
           ,[EXT_MU_CONT]
           ,[EXT_STATE_CONT]
           ,[EXT_COUNTY_CONT]
           ,[EXT_CITY_CONT]
           ,[EXT_NR_CONT]
           ,[LINE_TOTAL_CONT]
           ,[LINE_TOTAL]
           ,[EST_CPM_FLAG]
           ,[EST_FNC_TYPE]
           ,[EST_COMM_FLAG]
           ,[EST_TAX_FLAG]
           ,[EST_NONBILL_FLAG]
           ,[INCL_CPU]
           ,[FEE_TIME]
           ,[EMPLOYEE_TITLE_ID]
           ,[EST_PHASE_ID]
           ,[EST_PHASE_DESC]
           ,[EST_FNC_COMMENT_HTML]
           ,[EST_REV_SUP_BY_HTML])
SELECT [ESTIMATE_NUMBER]
           ,[EST_COMPONENT_NBR]
           ,[EST_QUOTE_NBR]
           ,@NewQuoteRev
           ,[SEQ_NBR]
           ,[FNC_CODE]
           ,[EST_REV_COMM_PCT]
           ,[EST_REV_CONT_PCT]
           ,[EST_REV_QUANTITY]
           ,[EST_REV_RATE]
           ,[EST_REV_SUP_BY_CDE]
           ,[EST_REV_SUP_BY_NTE]
           ,[EST_REV_EXT_AMT]
           ,[TAX_CODE]
           ,[EST_FNC_COMMENT]
           ,[TAX_STATE_PCT]
           ,[TAX_COUNTY_PCT]
           ,[TAX_CITY_PCT]
           ,[TAX_COMM]
           ,[TAX_COMM_ONLY]
           ,[TAX_RESALE]
           ,[EXT_MARKUP_AMT]
           ,[EXT_NONRESALE_TAX]
           ,[EXT_STATE_RESALE]
           ,[EXT_COUNTY_RESALE]
           ,[EXT_CITY_RESALE]
           ,[EXT_CONTINGENCY]
           ,[EXT_MU_CONT]
           ,[EXT_STATE_CONT]
           ,[EXT_COUNTY_CONT]
           ,[EXT_CITY_CONT]
           ,[EXT_NR_CONT]
           ,[LINE_TOTAL_CONT]
           ,[LINE_TOTAL]
           ,[EST_CPM_FLAG]
           ,[EST_FNC_TYPE]
           ,[EST_COMM_FLAG]
           ,[EST_TAX_FLAG]
           ,[EST_NONBILL_FLAG]
           ,[INCL_CPU]
           ,[FEE_TIME]
           ,[EMPLOYEE_TITLE_ID]
           ,[EST_PHASE_ID]
           ,[EST_PHASE_DESC]
           ,[EST_FNC_COMMENT_HTML]
           ,[EST_REV_SUP_BY_HTML]
		   FROM [dbo].[ESTIMATE_REV_DET]
		   WHERE (ESTIMATE_NUMBER = @EstNo) 
			   AND (EST_COMPONENT_NBR = @EstCompNo) 
			   AND (EST_QUOTE_NBR = @QuoteNo)
			   AND [EST_REV_NBR] = @NewQuoteRev - 1
GO


