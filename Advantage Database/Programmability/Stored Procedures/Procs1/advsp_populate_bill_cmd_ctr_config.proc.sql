
CREATE PROCEDURE [dbo].[advsp_populate_bill_cmd_ctr_config]
	@bill_user_in varchar(100), @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

		 SELECT bcccon.SEQ_NBR, 
				bcccol.BCCC_ID, 
				bcccon.TAB_ORDER, 
				bcccol.DEF_TAB_ORDER, 
				bcccon.COL_WIDTH, 
				bcccol.DEF_COL_WIDTH,
				bcccol.BCCC_DESC, 
				bcccol.BCCC_DW_COL, 
				bccg.BCCG_ID,
				bccg.BCCG_DESC, 
				bcccol.[REQUIRED],
				cc_include = CASE WHEN bcccon.SEQ_NBR > 0  
								THEN 1
								ELSE 0
							 END	   
		   FROM dbo.BILL_CMD_CTR_COL bcccol
LEFT OUTER JOIN dbo.BILL_CMD_CTR_CONFIG bcccon 
			 ON ( bcccol.BCCC_ID = bcccon.BCCC_ID )
			AND ( bcccon.BILLING_USER = @bill_user_in )		   
LEFT OUTER JOIN dbo.BILL_CMD_CTR_GRP bccg ON bcccol.BCCG_ID = bccg.BCCG_ID 
	   ORDER BY bcccon.SEQ_NBR, bcccon.TAB_ORDER, bcccol.BCCC_ID 		  
	  
