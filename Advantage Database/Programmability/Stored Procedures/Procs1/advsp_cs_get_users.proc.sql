IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_cs_get_users]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_cs_get_users]
GO
CREATE PROCEDURE [dbo].[advsp_cs_get_users] 
AS
BEGIN

	DECLARE @CONCEPTSHARE_USERS TABLE (
				ID INT IDENTITY,
				EmployeeCode VARCHAR(6),			
				UserCode VARCHAR(100),
				FullName VARCHAR(500),
				ConceptShareUserID INT,
				IsClientContact BIT,
				ClientContactID INT);

	INSERT INTO @CONCEPTSHARE_USERS (EmployeeCode, UserCode, FullName, ConceptShareUserID, IsClientContact)	
	SELECT
		E.EMP_CODE,
		S.USER_CODE,
		ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
		E.CS_USERID,
		0
	FROM
		EMPLOYEE E
		INNER JOIN SEC_USER S ON E.EMP_CODE = S.EMP_CODE
	WHERE
		NOT E.CS_USERID IS NULL;
	INSERT INTO @CONCEPTSHARE_USERS (FullName, ConceptShareUserID, IsClientContact, ClientContactID)
	SELECT
		CU.FULL_NAME,
		CU.CS_USERID,
		1,
		CU.CDP_CONTACT_ID
	FROM
		CP_USER CU
	WHERE
		NOT CU.CS_USERID IS NULL;

	SELECT
		EmployeeCode,
		UserCode,
		FullName,
		ConceptShareUserID,
		IsClientContact, 
		ClientContactID
	FROM
		@CONCEPTSHARE_USERS
	ORDER BY
		FullName,
		ID DESC;

END
