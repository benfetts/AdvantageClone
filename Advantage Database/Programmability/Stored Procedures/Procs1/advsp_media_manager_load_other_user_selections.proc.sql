CREATE PROCEDURE [dbo].[advsp_media_manager_load_other_user_selections]
	@user_id varchar(100)
AS

SET NOCOUNT ON

UPDATE
	dbo.INTERNET_HEADER
SET 
	LOCKED_BY = NULL
FROM
	dbo.INTERNET_HEADER H LEFT OUTER JOIN
	dbo.SEC_USER SU ON UPPER(SU.USER_CODE) = UPPER(H.LOCKED_BY)
WHERE
	SU.USER_CODE IS NULL

UPDATE
	dbo.MAGAZINE_HEADER
SET 
	LOCKED_BY = NULL
FROM
	dbo.MAGAZINE_HEADER H LEFT OUTER JOIN
	dbo.SEC_USER SU ON UPPER(SU.USER_CODE) = UPPER(H.LOCKED_BY)
WHERE
	SU.USER_CODE IS NULL

UPDATE
	dbo.NEWSPAPER_HEADER
SET 
	LOCKED_BY = NULL
FROM
	dbo.NEWSPAPER_HEADER H LEFT OUTER JOIN
	dbo.SEC_USER SU ON UPPER(SU.USER_CODE) = UPPER(H.LOCKED_BY)
WHERE
	SU.USER_CODE IS NULL

UPDATE
	dbo.OUTDOOR_HEADER
SET 
	LOCKED_BY = NULL
FROM
	dbo.OUTDOOR_HEADER H LEFT OUTER JOIN
	dbo.SEC_USER SU ON UPPER(SU.USER_CODE) = UPPER(H.LOCKED_BY)
WHERE
	SU.USER_CODE IS NULL

UPDATE
	dbo.RADIO_HDR
SET 
	LOCKED_BY = NULL
FROM
	dbo.RADIO_HDR H LEFT OUTER JOIN
	dbo.SEC_USER SU ON UPPER(SU.USER_CODE) = UPPER(H.LOCKED_BY)
WHERE
	SU.USER_CODE IS NULL

UPDATE
	dbo.TV_HDR
SET 
	LOCKED_BY = NULL
FROM
	dbo.TV_HDR H LEFT OUTER JOIN
	dbo.SEC_USER SU ON UPPER(SU.USER_CODE) = UPPER(H.LOCKED_BY)
WHERE
	SU.USER_CODE IS NULL

SELECT
	[EmployeeName] = dbo.advfn_get_emp_name( su.EMP_CODE, 'FML' ),
	[OrderNumber] = h.ORDER_NBR,
	[ClientCode] = h.CL_CODE,
	[DivisionCode] = h.DIV_CODE,
	[ProductCode] = h.PRD_CODE,
	[UserID] = su.SEC_USER_ID
FROM dbo.INTERNET_HEADER h
	LEFT OUTER JOIN dbo.SEC_USER su ON UPPER(h.LOCKED_BY) = UPPER(su.USER_CODE) 
WHERE LOCKED_BY <> @user_id 
UNION
SELECT
	[EmployeeName] = dbo.advfn_get_emp_name( su.EMP_CODE, 'FML' ),
	[OrderNumber] = h.ORDER_NBR,
	[ClientCode] = h.CL_CODE,
	[DivisionCode] = h.DIV_CODE,
	[ProductCode] = h.PRD_CODE,
	[UserID] = su.SEC_USER_ID
FROM dbo.MAGAZINE_HEADER h
	LEFT OUTER JOIN dbo.SEC_USER su ON UPPER(h.LOCKED_BY) = UPPER(su.USER_CODE) 
WHERE LOCKED_BY <> @user_id 
UNION
SELECT
	[EmployeeName] = dbo.advfn_get_emp_name( su.EMP_CODE, 'FML' ),
	[OrderNumber] = h.ORDER_NBR,
	[ClientCode] = h.CL_CODE,
	[DivisionCode] = h.DIV_CODE,
	[ProductCode] = h.PRD_CODE,
	[UserID] = su.SEC_USER_ID
FROM dbo.NEWSPAPER_HEADER h
	LEFT OUTER JOIN dbo.SEC_USER su ON UPPER(h.LOCKED_BY) = UPPER(su.USER_CODE) 
WHERE LOCKED_BY <> @user_id 
UNION
SELECT
	[EmployeeName] = dbo.advfn_get_emp_name( su.EMP_CODE, 'FML' ),
	[OrderNumber] = h.ORDER_NBR,
	[ClientCode] = h.CL_CODE,
	[DivisionCode] = h.DIV_CODE,
	[ProductCode] = h.PRD_CODE,
	[UserID] = su.SEC_USER_ID
FROM dbo.OUTDOOR_HEADER h
	LEFT OUTER JOIN dbo.SEC_USER su ON UPPER(h.LOCKED_BY) = UPPER(su.USER_CODE)
WHERE LOCKED_BY <> @user_id 
UNION
SELECT
	[EmployeeName] = dbo.advfn_get_emp_name( su.EMP_CODE, 'FML' ),
	[OrderNumber] = h.ORDER_NBR,
	[ClientCode] = h.CL_CODE,
	[DivisionCode] = h.DIV_CODE,
	[ProductCode] = h.PRD_CODE,
	[UserID] = su.SEC_USER_ID
FROM dbo.RADIO_HDR h
	LEFT OUTER JOIN dbo.SEC_USER su ON UPPER(h.LOCKED_BY) = UPPER(su.USER_CODE)
WHERE LOCKED_BY <> @user_id 
UNION
SELECT
	[EmployeeName] = dbo.advfn_get_emp_name( su.EMP_CODE, 'FML' ),
	[OrderNumber] = h.ORDER_NBR,
	[ClientCode] = h.CL_CODE,
	[DivisionCode] = h.DIV_CODE,
	[ProductCode] = h.PRD_CODE,
	[UserID] = su.SEC_USER_ID
FROM dbo.TV_HDR h
	LEFT OUTER JOIN dbo.SEC_USER su ON UPPER(h.LOCKED_BY) = UPPER(su.USER_CODE) 
WHERE LOCKED_BY <> @user_id 
ORDER BY 1, ORDER_NBR DESC


GO