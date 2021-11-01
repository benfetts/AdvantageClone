CREATE PROCEDURE [dbo].[usp_wv_dd_GetClients_Name] 
@UserID VarChar(100) 
AS
Declare @Rescrictions Int
Set NoCount on

Select @Rescrictions = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)

If @Rescrictions > 0
	SELECT     DISTINCT CLIENT.CL_CODE AS Code, isnull(CLIENT.CL_NAME, '') AS Description
	FROM         CLIENT INNER JOIN
                      SEC_CLIENT ON CLIENT.CL_CODE = SEC_CLIENT.CL_CODE
	WHERE     (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	ORDER BY  CLIENT.CL_CODE
ELSE
	SELECT     DISTINCT CL_CODE AS Code, isnull(CL_NAME, '') AS Description
	FROM         CLIENT
	ORDER BY  CLIENT.CL_CODE

























