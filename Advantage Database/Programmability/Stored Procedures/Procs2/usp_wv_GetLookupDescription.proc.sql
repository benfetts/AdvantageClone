--DROP PROCEDURE [dbo].[usp_wv_GetLookupDescription]
CREATE PROCEDURE [dbo].[usp_wv_GetLookupDescription]
@Level VARCHAR(3),
@OfficeCode VARCHAR(6),
@ClientCode VARCHAR(6),
@DivisionCode VARCHAR(6),
@ProductCode VARCHAR(6),
@CampaignCode VARCHAR(6),
@JobNumber INT,
@JobCompNumber INT,
@Vendor VARCHAR(6),
@APInvoice VARCHAR(20),
@AdNumber VARCHAR(30),
@ExpInv INT,
@EMP_CODE VARCHAR (6)
AS

IF @Level = 'OF'
BEGIN
	SELECT OFFICE_CODE+' - '+OFFICE_NAME FROM OFFICE WHERE OFFICE_CODE = @OfficeCode;
END

IF @Level = 'CL'
BEGIN
	SELECT CL_CODE+' - '+CL_NAME FROM CLIENT WHERE CL_CODE = @ClientCode;
END

IF @Level = 'DI'
BEGIN
	SELECT DIV_CODE+' - '+DIV_NAME FROM DIVISION WHERE CL_CODE = @ClientCode AND DIV_CODE = @DivisionCode;
END

IF @Level = 'PR'
BEGIN
	SELECT PRD_CODE+' - '+PRD_DESCRIPTION FROM PRODUCT WHERE CL_CODE = @ClientCode AND DIV_CODE = @DivisionCode AND PRD_CODE = @ProductCode;
END

IF @Level = 'CM'
BEGIN
	SELECT CMP_CODE+' - '+CMP_NAME FROM CAMPAIGN WHERE CL_CODE = @ClientCode AND (DIV_CODE = @DivisionCode OR DIV_CODE IS NULL) AND (PRD_CODE = @ProductCode OR PRD_CODE IS NULL) AND CMP_CODE = @CampaignCode;
END

IF @Level = 'JO'
BEGIN
	SELECT STR(JOB_NUMBER)+' - '+JOB_DESC FROM JOB_LOG WHERE JOB_NUMBER = @JobNumber;
END

IF @Level = 'JC'
BEGIN
	SELECT STR(JOB_NUMBER)+'/'+STR(JOB_COMPONENT_NBR)+' - '+JOB_COMP_DESC FROM JOB_COMPONENT WHERE JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobCompNumber;
END

IF @Level = 'VN'
BEGIN
	SELECT AP_HEADER.VN_FRL_EMP_CODE+' - '+VENDOR.VN_NAME+'/'+AP_HEADER.AP_INV_VCHR+' - '+ISNULL(AP_HEADER.AP_DESC, '') FROM AP_HEADER INNER JOIN VENDOR ON dbo.AP_HEADER.VN_FRL_EMP_CODE = VENDOR.VN_CODE WHERE VENDOR.VN_CODE = @Vendor AND AP_HEADER.AP_INV_VCHR = @APInvoice;
END

IF @Level = 'VN2'
BEGIN
	SELECT V.VN_CODE + ' - ' + V.VN_NAME FROM VENDOR V WITH(NOLOCK) WHERE V.VN_CODE = @Vendor;
END	

IF @Level = 'AN'
BEGIN
	SELECT AD_NBR+' - '+AD_NBR_DESC FROM AD_NUMBER WHERE AD_NBR = @AdNumber;
END

IF @Level = 'EX'
BEGIN
	SELECT CAST(INV_NBR AS VARCHAR)+' - '+EXP_DESC + ' - ' + CONVERT(VARCHAR(10), INV_DATE, 111) FROM EXPENSE_HEADER WHERE INV_NBR = @ExpInv;
END

IF @Level = 'EM'
BEGIN
	SELECT COALESCE((RTRIM(EMP_FNAME) + ' '),'') + COALESCE((EMP_MI + '. '),'') + COALESCE(EMP_LNAME,'') AS EMP_NAME FROM EMPLOYEE WHERE EMP_CODE = @EMP_CODE;
END

