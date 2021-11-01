




CREATE PROCEDURE [dbo].[usp_cp_GetAlertGroup] 
@Group varchar(50)
AS

declare @T_EmailGroup table (EMPGROUP varchar(255), 
								EMPCODE varchar(150), 
								DESCRIPTION Varchar(2000),
								Checked bit)

  insert into @T_EmailGroup (EMPGROUP, EMPCODE, DESCRIPTION, Checked)
		    select A.EMPGROUP, A.EMPCODE, A.DESCRIPTION, A.Checked from
		    (SELECT  'Root' as EMPGROUP, EMAIL_GROUP.EMAIL_GR_CODE + ':Root' as  EMPCODE, EMAIL_GROUP.EMAIL_GR_CODE as DESCRIPTION, 1 as Checked
		    from EMAIL_GROUP 
		    where EMAIL_GROUP.EMAIL_GR_CODE = @Group AND ((EMAIL_GROUP.INACTIVE_FLAG = 0) OR (EMAIL_GROUP.INACTIVE_FLAG IS NULL))
		    Group by EMAIL_GROUP.EMAIL_GR_CODE) A
    		
		    insert into @T_EmailGroup (EMPGROUP, EMPCODE, DESCRIPTION, Checked)
		    select A.EMPGROUP, A.EMPCODE, A.DESCRIPTION, A.Checked from
		    (SELECT  EMAIL_GROUP.EMAIL_GR_CODE as EMPGROUP, EMAIL_GROUP.EMP_CODE as EMPCODE,  isnull(EMPLOYEE.EMP_LNAME, '') + ', ' + isnull(EMPLOYEE.EMP_FNAME, '') + ' ' + isnull(EMPLOYEE.EMP_MI, '') as DESCRIPTION, 1 as Checked
		    from EMAIL_GROUP left outer join EMPLOYEE on
		    EMAIL_GROUP.EMP_CODE = EMPLOYEE.EMP_CODE
		    where EMAIL_GROUP.EMAIL_GR_CODE = @Group and ALERT_EMAIL <> 0  AND ((EMAIL_GROUP.INACTIVE_FLAG = 0) OR (EMAIL_GROUP.INACTIVE_FLAG IS NULL))
				) A ORDER BY A.DESCRIPTION		
 




Select * from @T_EmailGroup













