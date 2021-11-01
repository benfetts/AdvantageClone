IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[advsp_sec_pwd_load_users]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_sec_pwd_load_users]
GO
CREATE PROCEDURE [dbo].[advsp_sec_pwd_load_users]
AS
/*=========== QUERY ===========*/
BEGIN
   SELECT
        [ID] = S.SEC_USER_ID,
        [UserCode] = S.USER_CODE,
        [EmployeeCode] = S.EMP_CODE,
        [FirstName] = E.EMP_FNAME,
        [MiddleInitial] = E.EMP_MI,
        [LastName] = E.EMP_LNAME,
        [FullName] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
        [Password] = S.[PASSWORD],
		[IsLocked] =	CASE
							WHEN SPL.USER_CODE IS NOT NULL AND SPL.LOCK_DATE IS NOT NULL THEN CAST(1 AS BIT)
							ELSE CAST(0 AS BIT)
						END,
		[LockDate] = SPL.LOCK_DATE,
		[FailedAtttempts] =	CASE
								WHEN SPL.USER_CODE IS NOT NULL AND SPL.LOCK_DATE IS NOT NULL THEN CAST(ISNULL(SPL.ATTEMPTS, 0) AS INT)
								ELSE CAST(0 AS INT)
							END
    FROM
        SEC_USER S WITH(NOLOCK)
        INNER JOIN EMPLOYEE E WITH(NOLOCK) ON S.EMP_CODE = E.EMP_CODE
		LEFT OUTER JOIN SEC_PWD_LOCK SPL WITH(NOLOCK) ON S.USER_CODE = SPL.USER_CODE
	WHERE
		(S.IS_INACTIVE IS NULL OR S.IS_INACTIVE = 0)
		AND E.EMP_TERM_DATE IS NULL
    ORDER BY
        E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME;
END
/*=========== QUERY ===========*/
