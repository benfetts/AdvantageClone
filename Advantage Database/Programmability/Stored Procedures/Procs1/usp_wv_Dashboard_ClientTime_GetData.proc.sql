if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_ClientTime_GetData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_ClientTime_GetData]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_ClientTime_GetData]
(
	@Start int,
	@End int
)
AS
BEGIN
	SET NOCOUNT OFF
	
	DECLARE 
	@ERR INT, @PPStart int, @PPEnd int, @startdate datetime, @enddate datetime

	--SET @startdate = '1/1/' + @Start
	--SET @enddate = '12/31/' + @End

	SELECT @PPStart = PPPERIOD, @startdate = PPSRTDATE 
	FROM POSTPERIOD
	WHERE PPGLMONTH = 1 AND PPGLYEAR  = @Start

	if @startdate IS NULL
	Begin
		SELECT @PPStart = PPPERIOD, @startdate = PPSRTDATE 
		FROM POSTPERIOD
		WHERE PPGLMONTH = 1 AND PPGLYEAR  = @End
	End

	SELECT @PPEnd = PPPERIOD, @enddate = PPENDDATE 
	FROM POSTPERIOD
	WHERE PPGLMONTH = 12 AND PPGLYEAR  = @End

	DELETE FROM DASH_DATA_PROJ_DTL

	INSERT INTO [dbo].[DASH_DATA_PROJ_DTL]
           ([REC_SOURCE]
           ,[JOB_NUMBER]
           ,[JOB_COMPONENT_NBR]
           ,[FNC_TYPE]
           ,[FNC_CODE]
           ,[FNC_DESC]
		   ,[ITEM_ID]
		   ,[ITEM_SEQ]
           ,[DATE]
           ,[POST_PERIOD]
		   ,[ITEM_CODE]
           ,[ITEM_DESC]
           ,[DETAIL_COMMENT]
		   ,[ITEM_EXTRA1]
		   ,[ITEM_DEPT]
           ,[FEE_TIME]
           ,[HOURS_QTY]
		   ,[TOTAL_BILL]	
           ,[BILL_AMT]
           ,[EXT_MARKUP_AMT]
           ,[NONRESALE_TAX]
           ,[RESALE_TAX]
           ,[TOTAL]
           ,[NET_COST]
           ,[AR_POST_PERIOD]
           ,[AR_INV_NBR]
           ,[AR_TYPE]
           ,[AB_FLAG]
           ,[NB_FLAG]
		   ,[GLEXACT_BILL]	
           ,[EST_HOURS_QTY]
           ,[EST_TOTAL]
		   ,[EST_CONT_AMT]	
           ,[EST_NONRESALE_TAX]
           ,[EST_RESALE_TAX]
           ,[EST_MARKUP_AMT]
           ,[EST_NET_COST]
           ,[EST_NB_FLAG]
           ,[EST_FEE_TIME]
           ,[APPR_HOURS_QTY]
           ,[APPR_NET_COST]
           ,[APPR_COMMISSION]
           ,[APPR_TOTAL]
		   ,[PO_NUMBER]	
           ,[OPEN_PO_AMT]
           ,[OPEN_PO_GROSS_AMT]
		   ,[BILLED_AMT]
		   ,[BILLED_AMT_RESALE]
		   ,[BILLED_HRS_QTY]
		   ,[FEE_TIME_AMT]
		   ,[FEE_TIME_HRS]
		   ,[UNBILLED_AMT]
		   ,[UNBILLED_AMT_RESALE]
		   ,[UNBILLED_HRS_QTY]
		   ,[NB_AMT]
		   ,[NB_QTY]
		   ,[NEW_BIZ]
		   ,[AGENCY]
		   )
	EXEC advsp_job_amounts_prod 0,1,0,0,0,1,0,@startdate,@enddate,0

	--UPDATE DASH_DATA_EMP_TIME SET DATA_UPDATE = GETDATE()
    
	SET @ERR = @@Error

	--RETURN @ERR
END



