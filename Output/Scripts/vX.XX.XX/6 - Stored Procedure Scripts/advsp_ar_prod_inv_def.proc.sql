IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_ar_prod_inv_def]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_ar_prod_inv_def]
GO

CREATE PROCEDURE [dbo].[advsp_ar_prod_inv_def] 
	@user_id varchar(100)
AS

/* NOT USED IN .Net AT THIS POINT */

IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END
--SELECT @user_id

-- =====================================================================
-- V_PROD_INV_DEF - was a view
-- #00 02/28/13 - initial version
-- #01 03/04/13 - returns table of Agency Def, Client Def or OTO values based on RPT_RUNTIME_SPEC
-- #02 03/14/13 - various modifications to date
-- #03 08/28/13 - fixed WHERE to o.CLIENT_OR_DEF from AND to OR
-- #04 08/29/13 - changed #03 fix back to the way it was before
-- #05 04/02/14 - set PRT_LOC_PG_FTR_DEF to NULL when PRT_LOC_PG_FTR = 1
-- #06 04/29/14 - fixed #05, was incorrectly setting PRT_LOC_PG_FTR_DEF to Null
-- #07 04/30/14 - fixed CUSTOM_FORMAT to be the same as media

-- RPT_RUNTIME_SPECS.ONE_TIME - 0 = Use Agency/Client Default, 1 = Use One Time Only
-- PROD_INV_DEF.CLIENT_OR_DEF - 0 =One Time Only, 1 = Agency Default, 2 = Client Default Overide
-- =====================================================================


SELECT * FROM [dbo].[advtf_ar_prod_inv_def](@user_id)	

GO


GRANT EXECUTE ON [advsp_ar_prod_inv_def] TO PUBLIC
EXEC usp_grant_execute_on_sp_to_public