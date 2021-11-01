if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Job_Template_UpdateFields_By_Mapping]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Job_Template_UpdateFields_By_Mapping]
GO

CREATE PROCEDURE [dbo].[usp_wv_Job_Template_UpdateFields_By_Mapping] 
@JobVersionHeaderID AS int,
@FromApp AS varchar(10)
AS

BEGIN

DECLARE @JobVersionValue varchar(MAX), @JobVersionMapping varchar(32), @JobNumber int, @JobComponentNumber int, @NumberRecords int, @RowCount int

CREATE TABLE #jobversions(
	RowID int IDENTITY(1, 1), 
	JobVersionID int,
	JobNumber int,
	JobComponentNumber int,
	JobVersionDetailID int,
	JobVersionValue varchar(MAX),
	JobVersionMappingField varchar(32))

INSERT INTO #jobversions 
SELECT JOB_VER_HDR.JOB_VER_HDR_ID, JOB_VER_HDR.JOB_NUMBER, JOB_VER_HDR.JOB_COMPONENT_NBR, dbo.JOB_VER_DTL.JV_TMPLT_DTL_ID, 
       CAST(JOB_VER_DTL.JOB_VER_VALUE AS VARCHAR(MAX)), JOB_VER_TMPLT_DTL.JV_JT_MAPPING
FROM   JOB_VER_HDR INNER JOIN
       JOB_VER_DTL ON JOB_VER_HDR.JOB_VER_HDR_ID = JOB_VER_DTL.JOB_VER_HDR_ID INNER JOIN
       JOB_VER_TMPLT_DTL ON JOB_VER_DTL.JV_TMPLT_DTL_ID = JOB_VER_TMPLT_DTL.JV_TMPLT_DTL_ID
WHERE (dbo.JOB_VER_HDR.JOB_VER_HDR_ID = @JobVersionHeaderID) 


SELECT @NumberRecords = COUNT(*) FROM #jobversions
SET @RowCount = 1

WHILE @RowCount <= @NumberRecords
BEGIN
  SELECT @JobNumber = JobNumber, @JobComponentNumber = JobComponentNumber, @JobVersionValue = JobVersionValue, @JobVersionMapping = JobVersionMappingField
  FROM #jobversions
  WHERE RowID = @RowCount
  
  --SELECT @JobNumber, @JobComponentNumber, @JobVersionValue, @JobVersionMapping
  
  if (CHARINDEX('JOB_LOG',@JobVersionMapping) > 0 OR CHARINDEX('JOB_CLIENT_REF',@JobVersionMapping) > 0) AND @FromApp = 'job'
  Begin
	if CHARINDEX('BILL_COOP_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET BILL_COOP_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('CMP_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET CMP_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('COMPLEX_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET COMPLEX_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('FORMAT_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET FORMAT_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('JOB_BILL_COMMENT',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET JOB_BILL_COMMENT = LEFT(@JobVersionValue, 254)
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('JOB_COMMENTS',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET JOB_COMMENTS = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('JOB_DESC',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET JOB_DESC = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('JOB_ESTIMATE_REQ',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET JOB_ESTIMATE_REQ = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('JOB_RUSH_CHARGES',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET JOB_RUSH_CHARGES = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('PROMO_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET PROMO_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('UDV1_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET UDV1_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('UDV2_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET UDV2_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('UDV3_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET UDV3_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('UDV4_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET UDV4_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End
	if CHARINDEX('UDV5_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET UDV5_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber
    End	
	if CHARINDEX('JOB_CLI_REF',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_LOG]
		SET JOB_CLI_REF = LEFT(@JobVersionValue, 30)
		WHERE [JOB_NUMBER] = @JobNumber
    End	
  End
  
  if CHARINDEX('JOB_COMPONENT',@JobVersionMapping) > 0
  Begin	
	if CHARINDEX('ACCT_NBR',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET ACCT_NBR = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('AD_NBR',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET AD_NBR = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('ALRT_NOTIFY_HDR_ID',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET ALRT_NOTIFY_HDR_ID = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('BLACKPLT_VER_DESC',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET BLACKPLT_VER_DESC = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('BLACKPLT_VER2_DESC',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET BLACKPLT_VER2_DESC = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('CREATIVE_INSTR',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET CREATIVE_INSTR = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('DP_TM_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET DP_TM_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('EMAIL_GR_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET EMAIL_GR_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('EMP_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET EMP_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('FISCAL_PERIOD_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET FISCAL_PERIOD_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_AD_SIZE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_AD_SIZE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_CL_PO_NBR',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_CL_PO_NBR = LEFT(@JobVersionValue, 40)
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_COMP_BUDGET_AM',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_COMP_BUDGET_AM = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_COMP_COMMENTS',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_COMP_COMMENTS = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_COMP_DATE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_COMP_DATE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_COMP_DESC',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_COMP_DESC = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_DEL_INSTRUCT',@JobVersionMapping) > 0
    Begin		
		UPDATE [JOB_COMPONENT]
		SET JOB_DEL_INSTRUCT = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_FIRST_USE_DATE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_FIRST_USE_DATE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_LAYOUT_COMP',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_LAYOUT_COMP = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_LAYOUT_NONE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_LAYOUT_NONE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_LAYOUT_ROUGH',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_LAYOUT_ROUGH = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_LAYOUT_SPC_EXP',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_LAYOUT_SPC_EXP = LEFT(@JobVersionValue, 60)
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_LAYOUT_SPECIAL',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_LAYOUT_SPECIAL = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_LAYOUT_THUMB',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_LAYOUT_THUMB = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_MARKUP_PCT',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_MARKUP_PCT = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_PROCESS_CONTRL',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_PROCESS_CONTRL = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JOB_QTY',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JOB_QTY = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('JT_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET JT_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('MARKET_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET MARKET_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('MEDIA_BILL_DATE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET MEDIA_BILL_DATE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('NOBILL_FLAG',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET NOBILL_FLAG = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('PRD_CONT_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET CDP_CONTACT_ID = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('SERVICE_FEE_FLAG',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET SERVICE_FEE_FLAG = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('START_DATE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET START_DATE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('TAX_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET TAX_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('TAX_FLAG',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET TAX_FLAG = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('TRF_SCHEDULE_REQ',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET TRF_SCHEDULE_REQ = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('UDV1_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET UDV1_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('UDV2_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET UDV2_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('UDV3_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET UDV3_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('UDV4_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET UDV4_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('UDV5_CODE',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET UDV5_CODE = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
	if CHARINDEX('SERVICE_FEE_TYPE_ID',@JobVersionMapping) > 0
    Begin
		UPDATE [JOB_COMPONENT]
		SET SERVICE_FEE_TYPE_ID = @JobVersionValue
		WHERE [JOB_NUMBER] = @JobNumber AND [JOB_COMPONENT_NBR] = @JobComponentNumber	
    End
  End
  
  --if CHARINDEX('JOB_CLIENT_REF',@JobVersionMapping) > 0
  --Begin
	
  --End

  SET @RowCount = @RowCount + 1	
END	

	
END