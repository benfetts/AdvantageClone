if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Update_PrintDef]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Update_PrintDef]
GO

CREATE PROCEDURE [dbo].[usp_wv_Estimating_Update_PrintDef]
(
	@UserID varchar(100),
	@SELECT_BY varchar(2),
	@DATE_TO_PRINT smallint,
	@TAX_SEPARATE smallint,
	@TAX_INDICATOR smallint,
	@COMM_MU_SEPARATE smallint,
	@COMM_MU_INDICATOR smallint,
	@FUNCTION_OPTION varchar(2),
	@GROUP_OPTION varchar(2),
	@SORT_OPTION varchar(2),
	@INSIDE_CHG_DESC varchar(30),
	@OUTSIDE_CHG_DESC varchar(30),
	@EST_COMMENT smallint,
	@EST_COMP_COMMENT smallint,
	@QTE_COMMENT smallint,
	@REV_COMMENT smallint,
	@FUNC_COMMENT smallint,
	@DEF_FOOTER_COMMENT smallint,
	@CLI_REF smallint,
	@AE_NAME smallint,
	@PRT_SALES_CLASS smallint,
	@SPECS smallint,
	@JOB_QTY smallint,
	@CONTINGENCY smallint,
	@SUPPRESS_ZERO smallint,
	@LOCATION_ID varchar(6),
	@LOGO_PATH varchar(254),
	@REPORT_FORMAT varchar(50),
	@PRT_NONBILL smallint,
	@PRT_DIV_NAME smallint,
	@PRT_PRD_NAME smallint,
	@QTY_HRS smallint,
	@CONSOL_OVERRIDE smallint,
	@SUBTOT_ONLY smallint,
	@PRT_CPU smallint,
	@PRT_CPM smallint,
	@RPT_TITLE varchar(30),
	@SUP_BY_NOTES smallint,
	@CONT_SEPARATE smallint,
	@SIGNATURE smallint,
	@HIDE_COMP_DESC smallint,
	@HIDE_REVISION smallint,
	@JOB_DUE_DATE smallint,
	@USE_EMP_SIG smallint,
	@EXCL_EMP_TIME smallint,
	@EXCL_VENDOR smallint,
	@EXCL_IO smallint,
	@EXCL_SIGNATURE smallint,
	@CMP_SUMMARY smallint,
	@VENDOR_DESC smallint,
	@EXCL_NONBILL smallint
)
AS
SET NOCOUNT OFF
IF EXISTS(SELECT [USER_ID] from ESTIMATE_PRINT_DEF where (UPPER(USER_ID) = UPPER(@UserID)))
Begin
			UPDATE [ESTIMATE_PRINT_DEF] WITH(ROWLOCK)
	            SET
					--[SELECT_BY] = @SELECT_BY,
		            [DATE_TO_PRINT] = @DATE_TO_PRINT,
					[TAX_SEPARATE] = @TAX_SEPARATE,
					[TAX_INDICATOR] = @TAX_INDICATOR,
					[COMM_MU_SEPARATE] = @COMM_MU_SEPARATE,
					[COMM_MU_INDICATOR] = @COMM_MU_INDICATOR,
					[FUNCTION_OPTION] = @FUNCTION_OPTION,
		            [GROUP_OPTION] = @GROUP_OPTION,
					[SORT_OPTION] = @SORT_OPTION,
					[INSIDE_CHG_DESC] = @INSIDE_CHG_DESC,
					[OUTSIDE_CHG_DESC] = @OUTSIDE_CHG_DESC,
					[EST_COMMENT] = @EST_COMMENT,
					[EST_COMP_COMMENT] = @EST_COMP_COMMENT,
		            [QTE_COMMENT] = @QTE_COMMENT,
					[REV_COMMENT] = @REV_COMMENT,
					[FUNC_COMMENT] = @FUNC_COMMENT,
					[DEF_FOOTER_COMMENT] = @DEF_FOOTER_COMMENT,
					[CLI_REF] = @CLI_REF,
					[AE_NAME] = @AE_NAME,
		            [PRT_SALES_CLASS] = @PRT_SALES_CLASS,
					[SPECS] = @SPECS,
					[JOB_QTY] = @JOB_QTY,
					[CONTINGENCY] = @CONTINGENCY,
					[SUPPRESS_ZERO] = @SUPPRESS_ZERO,
					[LOCATION_ID] = @LOCATION_ID,
		            [LOGO_PATH] = @LOGO_PATH,
					[REPORT_FORMAT] = @REPORT_FORMAT,
					[PRT_NONBILL] = @PRT_NONBILL,
					[PRT_DIV_NAME] = @PRT_DIV_NAME,
					[PRT_PRD_NAME] = @PRT_PRD_NAME,
					[QTY_HRS] = @QTY_HRS,
					[CONSOL_OVERRIDE] = @CONSOL_OVERRIDE,
					[SUBTOT_ONLY] = @SUBTOT_ONLY,
					[PRT_CPU] = @PRT_CPU,
					[PRT_CPM] = @PRT_CPM,
					[RPT_TITLE] = @RPT_TITLE,
					[SUP_BY_NOTES] = @SUP_BY_NOTES,
	                [CONT_SEPARATE] = @CONT_SEPARATE,
	                [SIGNATURE] = @SIGNATURE,
	                [HIDE_COMP_DESC] = @HIDE_COMP_DESC,
	                [HIDE_REVISION] = @HIDE_REVISION,
	                [JOB_DUE_DATE] = @JOB_DUE_DATE,
	                [USE_EMP_SIG] = @USE_EMP_SIG,
	                [EXCL_EMP_TIME] = @EXCL_EMP_TIME,
	                [EXCL_VENDOR] = @EXCL_VENDOR,
	                [EXCL_IO] = @EXCL_IO,
					[EXCL_SIGNATURES] = @EXCL_SIGNATURE,
					[CMP_SUMMARY] = @CMP_SUMMARY,
					[VENDOR_DESC] = @VENDOR_DESC,
					[EXCL_NONBILL] = @EXCL_NONBILL
	           WHERE
		            (UPPER(USER_ID) = UPPER(@UserID))	    
			
End
Else
Begin

-- insert new record for user if it does not exist...
 EXEC usp_wv_Estimating_Save_PrintDef @UserID, @SELECT_BY, @DATE_TO_PRINT, @TAX_SEPARATE, @TAX_INDICATOR,
					@COMM_MU_SEPARATE, @COMM_MU_INDICATOR, @FUNCTION_OPTION, @GROUP_OPTION, @SORT_OPTION,
					@INSIDE_CHG_DESC, @OUTSIDE_CHG_DESC, @EST_COMMENT, @EST_COMP_COMMENT, @QTE_COMMENT,
					@REV_COMMENT, @FUNC_COMMENT, @DEF_FOOTER_COMMENT, @CLI_REF, @AE_NAME, @PRT_SALES_CLASS,
					@SPECS, @JOB_QTY, @CONTINGENCY, @SUPPRESS_ZERO, @LOCATION_ID, @LOGO_PATH, @REPORT_FORMAT,
					@PRT_NONBILL, @PRT_DIV_NAME, @PRT_PRD_NAME, @QTY_HRS, @CONSOL_OVERRIDE, @SUBTOT_ONLY, @PRT_CPU,
					@PRT_CPM, @RPT_TITLE, @SUP_BY_NOTES, @CONT_SEPARATE, @SIGNATURE, @HIDE_COMP_DESC, @HIDE_REVISION, @JOB_DUE_DATE, @USE_EMP_SIG,
					@EXCL_EMP_TIME,	@EXCL_VENDOR, @EXCL_IO, @EXCL_SIGNATURE,@CMP_SUMMARY,@VENDOR_DESC,@EXCL_NONBILL

End
			

	






