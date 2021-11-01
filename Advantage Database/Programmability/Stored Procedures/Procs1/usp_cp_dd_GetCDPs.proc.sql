

/*****************************************************************
Gets Clients for Drop Down s
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_dd_GetCDPs] 
@Client VarChar(6),
@Division VarChar(6),
@Product VarChar(6)

AS
--Declare @Rescrictions Int

Set NoCount on

if @Division = '%' AND @Product = '%'
	SELECT      CL_CODE, DIV_CODE, PRD_CODE
	FROM         PRODUCT
	WHERE     (ACTIVE_FLAG = 1) AND (CL_CODE) = @Client
	ORDER BY  CL_CODE
if @Product = '%'
	SELECT      CL_CODE, DIV_CODE, PRD_CODE
	FROM         PRODUCT
	WHERE     (ACTIVE_FLAG = 1) AND (CL_CODE = @Client) AND (DIV_CODE = @Division)
	ORDER BY  CL_CODE
--if @Division <> '%' and Product = '%'
--	SELECT      CL_CODE, DIV_CODE, PRD_CODE
--	FROM         PRODUCT
--	WHERE     (ACTIVE_FLAG = 1) AND (CL_CODE = @Client) AND (DIV_CODE = @Division) AND (PRD_CODE = @Product)
--	ORDER BY  CL_CODE


--Select @Rescrictions = Count(*) 
--FROM SEC_CLIENT
--WHERE UPPER(USER_ID) = UPPER(@UserID)

--If @Rescrictions > 0
--	SELECT     DISTINCT CLIENT.CL_CODE AS Code, CLIENT.CL_CODE + ' - ' + isnull(CLIENT.CL_NAME, '') AS Description
--	FROM         CLIENT INNER JOIN
--                      SEC_CLIENT ON CLIENT.CL_CODE = SEC_CLIENT.CL_CODE
--	WHERE     (CLIENT.ACTIVE_FLAG = 1) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID))
--	ORDER BY  CLIENT.CL_CODE
--ELSE
	
























