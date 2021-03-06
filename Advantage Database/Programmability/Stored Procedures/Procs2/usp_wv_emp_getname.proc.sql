SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_emp_getname]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_emp_getname]
GO

CREATE PROCEDURE [dbo].[usp_wv_emp_getname] 
@USER_CODE VARCHAR(100),
@EmpCode AS VARCHAR(6),
@EmpName AS VARCHAR(100) OUTPUT
AS
/*=========== QUERY ===========*/
	DECLARE @RESTRICTED                   INT,
			@RESTRICTED_TO_OWN_TIMESHEET  VARCHAR(1)

	--SELECT @RESTRICTED = COUNT(1)
	--FROM   SEC_EMP WITH(NOLOCK)
	--WHERE  UPPER(SEC_EMP.[USER_ID]) = UPPER(@USER_CODE);
	--SET @RESTRICTED = ISNULL(@RESTRICTED, 0);

	--SELECT @RESTRICTED_TO_OWN_TIMESHEET = ISNULL(SI_DO_OWN_TS, 'N')
	--FROM   SEC_USER WITH(NOLOCK)
	--WHERE  (UPPER(USER_CODE) = UPPER(@USER_CODE));

	--IF UPPER(@RESTRICTED_TO_OWN_TIMESHEET) = 'Y'
	--BEGIN
	--	SET @EmpCode = NULL;
	--END

	--IF @RESTRICTED = 0
	--BEGIN
		SELECT @EmpName = ISNULL(EMP_FNAME, '') + ISNULL(' ' + EMP_MI + '. ', ' ') + ISNULL(EMP_LNAME, '')
		FROM   EMPLOYEE WITH(NOLOCK)
		WHERE  (EMP_CODE = @EmpCode);
	--END
	--ELSE
	--BEGIN
	--	SELECT @EmpName = ISNULL(EMP_FNAME, '') + ISNULL(' ' + EMP_MI + '. ', ' ') + ISNULL(EMP_LNAME, '')
	--	FROM   EMPLOYEE WITH (NOLOCK)
	--		   INNER JOIN SEC_EMP WITH (NOLOCK)
	--				ON  EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE
	--	WHERE  (EMPLOYEE.EMP_CODE = @EmpCode)
	--		   AND SEC_EMP.[USER_ID] = @USER_CODE;
	--END
	
	SET @EmpName = ISNULL(@EmpName, '');

	--SELECT @EmpName;
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

