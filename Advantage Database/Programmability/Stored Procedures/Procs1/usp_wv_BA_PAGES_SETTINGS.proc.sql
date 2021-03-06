
CREATE PROCEDURE [dbo].[usp_wv_BA_PAGES_SETTINGS] 
	@PAGE AS SMALLINT
AS

	IF @PAGE = 0 --Batch Approval Entry/Edit
	BEGIN
		SELECT     
			AGY_SETTINGS_CODE, 
			CONVERT(BIT,COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF)) AS AGY_SETTINGS_VALUE, 
			AGY_SETTINGS_DESC
		FROM         
			AGY_SETTINGS WITH (NOLOCK)
		WHERE 
			AGY_SETTINGS.AGY_SETTINGS_CODE = 'BA_JOB_LIST_SECT';	
	END
	IF @PAGE = 1 --Billing Approval Entry/Edit
	BEGIN
		SELECT     
			AGY_SETTINGS_CODE, 
			CONVERT(BIT,COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF)) AS AGY_SETTINGS_VALUE, 
			AGY_SETTINGS_DESC
		FROM         
			AGY_SETTINGS WITH (NOLOCK)
		WHERE 
			AGY_SETTINGS.AGY_SETTINGS_CODE IN ('BA_DESC_CL_NAME','BA_OPT_INFO_SECT');	
	END
	IF @PAGE = 2 --Billing Approval by Job Component
	BEGIN
		SELECT     
			AGY_SETTINGS_CODE, 
			CONVERT(BIT,COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF)) AS AGY_SETTINGS_VALUE, 
			AGY_SETTINGS_DESC
		FROM         
			AGY_SETTINGS WITH (NOLOCK)
		WHERE 
			AGY_SETTINGS.AGY_SETTINGS_CODE IN ('BA_RATE_DETAILS','BA_APPR_INFO_SECT','BA_CMNT_SECT','BA_DTLS_SECT','BA_DTLS_OPT','BA_CMNT_OPT');	
	END
	IF @PAGE = 3 --Unbilled Function Detail
	BEGIN
		SELECT     
			AGY_SETTINGS_CODE, 
			CONVERT(BIT,COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF)) AS AGY_SETTINGS_VALUE, 
			AGY_SETTINGS_DESC
		FROM         
			AGY_SETTINGS WITH (NOLOCK)
		WHERE 
			AGY_SETTINGS.AGY_SETTINGS_CODE IN ('BA_VER_INFO');
	END
		
		
