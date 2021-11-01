
/*****************************************************************
Webvantage
This Stored Procedure gets all Email Groups
******************************************************************/
CREATE PROCEDURE [dbo].[usp_Get_Alert_EmailGroups] 

@Group varchar(150)

AS

declare @intcounter as int

set @intcounter = 1

declare @T_EmailGroup table (EMPGROUP varchar(255), EMPCODE varchar(150), DESCRIPTION Varchar(2000), Expand bit, icon varchar(25))

--Check to see if there is a default group
insert into @T_EmailGroup (EMPGROUP, EMPCODE, DESCRIPTION, Expand, icon)
select A.EMPGROUP, A.EMPCODE, A.DESCRIPTION, 0, '' from
(SELECT  'Root' as EMPGROUP, SUBSTRING(EMAIL_GROUP.EMAIL_GR_CODE, 1, 3) as  EMPCODE, '<input type=''checkbox'' CHECKED class=''chk''  id=''chk_' + SUBSTRING(EMAIL_GROUP.EMAIL_GR_CODE, 1, 3) + ''' onclick=''ob_t2c(this)''>' + EMAIL_GROUP.EMAIL_GR_CODE as DESCRIPTION
from EMAIL_GROUP 
where EMAIL_GROUP.EMAIL_GR_CODE = @Group
Group by EMAIL_GROUP.EMAIL_GR_CODE) A

insert into @T_EmailGroup (EMPGROUP, EMPCODE, DESCRIPTION, Expand, icon)
select A.EMPGROUP, A.EMPCODE, A.DESCRIPTION, 0, '' from
(SELECT  'Root' as EMPGROUP, SUBSTRING(EMAIL_GROUP.EMAIL_GR_CODE, 1, 3) as  EMPCODE, '<input type=''checkbox'' class=''chk'' id=''chk_' + SUBSTRING(EMAIL_GROUP.EMAIL_GR_CODE, 1, 3) + ''' onclick=''ob_t2c(this)''>' + EMAIL_GROUP.EMAIL_GR_CODE as DESCRIPTION
from EMAIL_GROUP 
where EMAIL_GROUP.EMAIL_GR_CODE <> @Group
Group by EMAIL_GROUP.EMAIL_GR_CODE) A

--Check to see if there is a default group
insert into @T_EmailGroup (EMPGROUP, EMPCODE, DESCRIPTION, Expand, icon)
select A.EMPGROUP, A.EMPCODE, A.DESCRIPTION, 0, '' from
(SELECT  substring(EMAIL_GROUP.EMAIL_GR_CODE, 1, 3) as EMPGROUP, EMAIL_GROUP.EMP_CODE as EMPCODE, '<input type=''checkbox'' CHECKED  id=''chk_' + EMAIL_GROUP.EMP_CODE + ''' class=''chk'' onclick=''ob_t2c(this)''>' + isnull(EMPLOYEE.EMP_LNAME, '') + ', ' + isnull(EMPLOYEE.EMP_FNAME, '') + ' ' + isnull(EMPLOYEE.EMP_MI, '') as DESCRIPTION
from EMAIL_GROUP left outer join EMPLOYEE on
EMAIL_GROUP.EMP_CODE = EMPLOYEE.EMP_CODE
where EMAIL_GROUP.EMAIL_GR_CODE = @Group and ALERT_EMAIL <> 0) A

--Check to see if user flagged not to receive emails.
insert into @T_EmailGroup (EMPGROUP, EMPCODE, DESCRIPTION, Expand, icon)
select A.EMPGROUP, A.EMPCODE, A.DESCRIPTION, 0, '' from
(SELECT  substring(EMAIL_GROUP.EMAIL_GR_CODE, 1, 3) as EMPGROUP, EMAIL_GROUP.EMP_CODE as EMPCODE, '<font color="#ff4500">' + isnull(EMPLOYEE.EMP_LNAME, '') + ', ' + isnull(EMPLOYEE.EMP_FNAME, '') + ' ' + isnull(EMPLOYEE.EMP_MI, '') + '</font>' as DESCRIPTION
from EMAIL_GROUP left outer join EMPLOYEE on
EMAIL_GROUP.EMP_CODE = EMPLOYEE.EMP_CODE
where EMAIL_GROUP.EMAIL_GR_CODE = @Group and ALERT_EMAIL = 0) A

insert into @T_EmailGroup (EMPGROUP, EMPCODE, DESCRIPTION, Expand, icon)
select A.EMPGROUP, A.EMPCODE, A.DESCRIPTION, 0, '' from
(SELECT  substring(EMAIL_GROUP.EMAIL_GR_CODE, 1, 3) as EMPGROUP, EMAIL_GROUP.EMP_CODE as EMPCODE, '<input type=''checkbox''  id=''chk_' + EMAIL_GROUP.EMP_CODE + ''' class=''chk'' onclick=''ob_t2c(this)''>' + isnull(EMPLOYEE.EMP_LNAME, '') + ', ' + isnull(EMPLOYEE.EMP_FNAME, '') + ' ' + isnull(EMPLOYEE.EMP_MI, '') as DESCRIPTION
from EMAIL_GROUP left outer join EMPLOYEE on
EMAIL_GROUP.EMP_CODE = EMPLOYEE.EMP_CODE
where EMAIL_GROUP.EMAIL_GR_CODE <> @Group and ALERT_EMAIL <> 0) A

--Check to see if the user flagged not to receive emails.
insert into @T_EmailGroup (EMPGROUP, EMPCODE, DESCRIPTION, Expand, icon)
select A.EMPGROUP, A.EMPCODE, A.DESCRIPTION, 0, '' from
(SELECT  substring(EMAIL_GROUP.EMAIL_GR_CODE, 1, 3) as EMPGROUP, EMAIL_GROUP.EMP_CODE as EMPCODE, '<font color="#ff4500">' + isnull(EMPLOYEE.EMP_LNAME, '') + ', ' + isnull(EMPLOYEE.EMP_FNAME, '') + ' ' + isnull(EMPLOYEE.EMP_MI, '') + '</font>' as DESCRIPTION
from EMAIL_GROUP left outer join EMPLOYEE on
EMAIL_GROUP.EMP_CODE = EMPLOYEE.EMP_CODE
where EMAIL_GROUP.EMAIL_GR_CODE <> @Group and ALERT_EMAIL = 0) A


Select * from @T_EmailGroup
