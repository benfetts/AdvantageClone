if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_cs_load_all_reviewers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_cs_load_all_reviewers]
GO

CREATE PROCEDURE [dbo].[advsp_cs_load_all_reviewers] /*WITH ENCRYPTION*/
AS
BEGIN

	DECLARE @REVIEWERS TABLE (EmployeeCode VARCHAR (10),
							  FullName VARCHAR(500),
							  ConceptShareUserID INT,
							  Picture IMAGE,
							  IsEmployee BIT)
	
	INSERT INTO @REVIEWERS (EmployeeCode, FullName, ConceptShareUserID, Picture, IsEmployee)
	SELECT
		E.EMP_CODE AS EmployeeCode,
		ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '') AS FullName,
		E.CS_USERID AS ConceptShareUserID,
		EP.EMP_IMAGE AS Picture,
		CAST(1 AS BIT)
	FROM 
		EMPLOYEE E 
		LEFT OUTER JOIN EMPLOYEE_PICTURE EP ON E.EMP_CODE = EP.EMP_CODE
	WHERE
		(E.EMP_TERM_DATE IS NULL OR E.EMP_TERM_DATE > GETDATE())
		AND (NOT E.CS_USERID IS NULL AND NOT E.CS_PASSWORD IS NULL)
	ORDER BY
		E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME;

	INSERT INTO @REVIEWERS (EmployeeCode, FullName, ConceptShareUserID, Picture, IsEmployee)
	SELECT 
		CAST(CCH.CDP_CONTACT_ID AS VARCHAR) AS EmployeeCode,
		CCH.CONT_FML + ' (CC)' AS FullName,
		CU.CS_USERID AS ConceptShareUserID,
		NULL AS Picture,
		CAST(0 AS BIT)
	FROM 
		CDP_CONTACT_HDR CCH
		INNER JOIN CP_USER CU ON CCH.CDP_CONTACT_ID = CU.CDP_CONTACT_ID
	WHERE
		(CCH.CP_USER IS NULL OR CCH.CP_USER = 1)
		AND (NOT CU.CS_USERID IS NULL AND NOT CU.CS_PASSWORD IS NULL)
	ORDER BY
		CCH.CONT_FML;
	
	SELECT * FROM @REVIEWERS;			

END