






/*****************************************************************
Gets Depts for Drop Downs
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_CPUsersData] 
@CDPCode as int
AS

Set NoCount On

SELECT     CP_USER.FULL_NAME, CP_USER.USER_NAME, CP_USER.PASSWORD_HASH, CP_USER.EMAIL_ADDRESS, 
                      CP_USER.CDP_CONTACT_ID, CP_USER.DESKTOP_TEMPLATE, CP_USER.THEME, CP_USER.ADMIN_USER, CP_USER.CL_CODE, 
                      ISNULL(CP_USER.ALERT_GROUP_CODE, '') AS ALERT_GROUP_CODE, ISNULL(CP_USER.AGENCY_CONTACT_CODE, '') AS AGENCY_CONTACT_CODE, CLIENT.CL_NAME, CDP_CONTACT_HDR.CONT_CODE, CP_USER.IS_LOCKED,
					  dbo.udf_get_empl_name(AGENCY_CONTACT_CODE, 'FML' ) AS CONTACT_NAME
FROM         CP_USER INNER JOIN
                      CLIENT ON CP_USER.CL_CODE = CLIENT.CL_CODE INNER JOIN
                      CDP_CONTACT_HDR ON CP_USER.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
WHERE     (CP_USER.CDP_CONTACT_ID = @CDPCode)

























