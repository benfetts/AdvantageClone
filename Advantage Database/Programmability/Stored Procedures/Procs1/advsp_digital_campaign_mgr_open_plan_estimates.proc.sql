CREATE PROCEDURE [dbo].[advsp_digital_campaign_mgr_open_plan_estimates]
    @UserCode varchar(100),
    @SC_TYPES varchar(max)
AS

DECLARE @EmployeeCode varchar(6),
		@HasCDPLimits bit,
		@HasOfficeLimits bit

SET @HasCDPLimits = 0

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserCode)) > 0
	SET @HasCDPLimits = 1
    
SELECT @EmployeeCode = EMP_CODE
FROM dbo.SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserCode)

IF (SELECT COUNT(1) FROM dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode) > 0
	SET @HasOfficeLimits = 1
ELSE
	SET @HasOfficeLimits = 0

SELECT
	ClientName = C.CL_NAME,
	EstimateCampaign = EC.CMP_NAME,
	MediaPlanDetailID = MPD.MEDIA_PLAN_DTL_ID,
    MediaPlanID = MP.MEDIA_PLAN_ID,
	EstimateName = MPD.[NAME],
	EstimateBuyer = dbo.advfn_get_emp_name(MPD.BUYER_EMP_CODE, 'FML'),
	PlanDescription = MP.[DESCRIPTION],
	PlanStartDate = MP.[START_DATE],
	PlanEndDate = MP.END_DATE,
	PlanCampaign = PC.CMP_NAME,
    ClientCode = MP.CL_CODE,
    DivisionCode = MP.DIV_CODE,
    DivisionName = D.DIV_NAME,
    ProductCode = MP.PRD_CODE,
    ProductName = P.PRD_DESCRIPTION
FROM dbo.MEDIA_PLAN_DTL MPD
	INNER JOIN dbo.MEDIA_PLAN MP ON MP.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID 
	INNER JOIN dbo.CLIENT C ON MP.CL_CODE = C.CL_CODE
    INNER JOIN dbo.DIVISION D ON MP.CL_CODE = D.CL_CODE AND MP.DIV_CODE = D.DIV_CODE
    INNER JOIN dbo.PRODUCT P ON MP.CL_CODE = P.CL_CODE AND MP.DIV_CODE = P.DIV_CODE AND MP.PRD_CODE = P.PRD_CODE
	LEFT OUTER JOIN dbo.CAMPAIGN EC ON EC.CMP_IDENTIFIER = MPD.CMP_IDENTIFIER 
	LEFT OUTER JOIN dbo.CAMPAIGN PC ON PC.CMP_IDENTIFIER = MP.CMP_IDENTIFIER 
WHERE
	MPD.SC_TYPE IN (SELECT items FROM dbo.udf_split_list(@SC_TYPES, ','))
AND MP.IS_TEMPLATE = 0
AND MP.IS_INACTIVE = 0
AND EXISTS(SELECT 1 FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE WHERE MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID)
AND	(
        ( @HasCDPLimits = 1 AND EXISTS (
										SELECT 1
										FROM dbo.SEC_CLIENT sc
										WHERE UPPER(sc.[USER_ID]) = UPPER(@UserCode)
										AND sc.CL_CODE = MP.CL_CODE
										AND sc.DIV_CODE = MP.DIV_CODE
										AND sc.PRD_CODE = MP.PRD_CODE)
										AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										)
	OR
		( @HasCDPLimits = 0 AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
	)
AND
	(
		( @HasOfficeLimits = 1 AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits(@EmployeeCode)))
	OR
		( @HasOfficeLimits = 0 )
	)
ORDER BY MPD.MEDIA_PLAN_DTL_ID
GO