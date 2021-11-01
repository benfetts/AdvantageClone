IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_ar_address_table_prod]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_ar_address_table_prod]
GO

CREATE PROCEDURE [dbo].[advsp_ar_address_table_prod] 
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
-- =====================================================================
-- V_AR_ADDRESS_TABLE_PROD
-- PJH 05/05/21 - Changed to call new function
-- =====================================================================

--SELECT * FROM V_MEDIA_INV_DEF

SELECT * FROM [dbo].[advtf_ar_address_table_prod](@user_id)	
GO

GRANT EXECUTE ON [advsp_ar_address_table_prod] TO PUBLIC
EXEC usp_grant_execute_on_sp_to_public