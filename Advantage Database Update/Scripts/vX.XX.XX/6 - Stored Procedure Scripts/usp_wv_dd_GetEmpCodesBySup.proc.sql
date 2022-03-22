IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dd_GetEmpCodesBySup]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[usp_wv_dd_GetEmpCodesBySup]
GO
CREATE PROCEDURE [dbo].[usp_wv_dd_GetEmpCodesBySup] 
@UserID VARCHAR(100), 
@SuperCode VARCHAR(6),
@FromApp VARCHAR(10)
AS
/*=========== QUERY ===========*/
BEGIN
	DECLARE 
		@OfficeRestrictions AS INT = 0,
		@EMP_CODE AS VARCHAR(6),
		@TIME_APPR_ACTIVE SMALLINT = 0,
		@DATA_LOADED BIT = 0
	;
	-- The "top 1" handles a very old issue that appears ONLY in our internal test db's.  No need to "do it right" that would add complexity.
	SELECT @EMP_CODE = (SELECT TOP 1 EMP_CODE FROM [dbo].[SEC_USER] SU WITH(NOLOCK) WHERE UPPER(SU.[USER_CODE]) = UPPER(@UserID) ORDER BY SU.USER_CODE DESC);
	IF @FromApp = 'exp'
	BEGIN
		SELECT    
			[Code] = E.EMP_CODE, 
			[Description] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
		FROM         
			EMPLOYEE E WITH(NOLOCK)
		WHERE 
			(E.EMP_TERM_DATE IS NULL OR E.EMP_TERM_DATE > GETDATE())
			AND  (E.SUPERVISOR_CODE = @SuperCode AND E.EXP_RPT_APPROVER IS NULL) OR (E.EXP_RPT_APPROVER = @SuperCode)
			AND ISNULL(E.EXP_APPR_REQ, 0) = 1
		ORDER BY 
			E.EMP_CODE
		;
		SET @DATA_LOADED = 1;
	END
	IF @FromApp = 'ts_appr'
	BEGIN
		SELECT @TIME_APPR_ACTIVE = ISNULL(TIME_APPR_ACTIVE,0) FROM AGENCY WITH(NOLOCK);	
		SET @TIME_APPR_ACTIVE = ISNULL(@TIME_APPR_ACTIVE,0);
		IF @TIME_APPR_ACTIVE = 1
		BEGIN
			SELECT    
				[Code] = E.EMP_CODE, 
				[Description] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
			FROM         
				EMPLOYEE E WITH(NOLOCK)
			WHERE 
				(E.EMP_TERM_DATE IS NULL OR E.EMP_TERM_DATE > GETDATE())
				AND  E.SUPERVISOR_CODE = @SuperCode
				AND (E.TS_APPR_FLAG = 0 OR E.TS_APPR_FLAG IS NULL) --*SEE EXPLANATION
			ORDER BY 
				E.EMP_CODE
			;
			/*
				 EMPLOYEE.TS_APPR_FLAG = 1 are emps that are exceptions to the rule.
				 Meaning IF the agency flag is true, the emps that have the flag as true are exempt from approval
				 And the emps that have the flag as not true (not 1) ARE still required for approval
			*/
			SET @DATA_LOADED = 1;
		END
		IF @TIME_APPR_ACTIVE = 0
		BEGIN
			SELECT    
				[Code] = E.EMP_CODE, 
				[Description] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
			FROM         
				EMPLOYEE E WITH(NOLOCK)
			WHERE 
				(E.EMP_TERM_DATE IS NULL OR E.EMP_TERM_DATE > GETDATE())
				AND  E.SUPERVISOR_CODE = @SuperCode
			ORDER BY 
				E.EMP_CODE
			;
			SET @DATA_LOADED = 1;
		END
	END
	IF @FromApp = '' OR @FromApp IS NULL OR @DATA_LOADED = 0
	BEGIN
		SELECT @OfficeRestrictions = COUNT(1) FROM EMP_OFFICE EO WITH(NOLOCK) WHERE EO.EMP_CODE = @EMP_CODE
		IF @OfficeRestrictions > 0 
		BEGIN
			SELECT    
				[Code] = E.EMP_CODE, 
				[Description] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
			FROM         
				EMPLOYEE E WITH(NOLOCK) 
				INNER JOIN EMP_OFFICE EO WITH(NOLOCK) ON E.OFFICE_CODE = EO.OFFICE_CODE AND EO.EMP_CODE = @EMP_CODE
			WHERE 
				(E.EMP_TERM_DATE IS NULL OR E.EMP_TERM_DATE > GETDATE())
				AND  E.SUPERVISOR_CODE = @SuperCode
			ORDER BY 
				E.EMP_CODE
			;
		END
		ELSE
		BEGIN
			SELECT    
				[Code] = E.EMP_CODE, 
				[Description] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
			FROM         
				EMPLOYEE E WITH(NOLOCK)
			WHERE 
				(E.EMP_TERM_DATE IS NULL OR E.EMP_TERM_DATE > GETDATE())
				AND  E.SUPERVISOR_CODE = @SuperCode
			ORDER BY 
				E.EMP_CODE
			;
		END
	END
END
/*=========== QUERY ===========*/