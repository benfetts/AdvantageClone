﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_GetDivisions_All]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_GetDivisions_All]
GO


CREATE PROCEDURE [dbo].[usp_wv_dd_GetDivisions_All] 
@UserID VarChar(100) , 
@ClientCode VarChar(6)
AS
Declare @Rescrictions Int

Set NoCount On

	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE @OfficeCount AS INTEGER

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

Select @Rescrictions = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)

IF @ClientCode <> ''
BEGIN
	If @Rescrictions > 0
		If @OfficeCount = 0
			Begin
				SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + isnull(DIVISION.DIV_NAME, '') + ' | ' + ISNULL(CLIENT.CL_CODE,'')  AS Description
				FROM         CLIENT INNER JOIN
								  DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
								  SEC_CLIENT ON DIVISION.CL_CODE = SEC_CLIENT.CL_CODE AND DIVISION.DIV_CODE = SEC_CLIENT.DIV_CODE
				WHERE     (CLIENT.CL_CODE = @ClientCode) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
				--ORDER BY  DIVISION.DIV_CODE,  DIVISION.DIV_NAME
			End
			Else
			Begin
				SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + isnull(DIVISION.DIV_NAME, '') + ' | ' + ISNULL(CLIENT.CL_CODE,'')  AS Description
				FROM         CLIENT INNER JOIN
								  DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
							   PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN 
							   EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE INNER JOIN
								  SEC_CLIENT ON DIVISION.CL_CODE = SEC_CLIENT.CL_CODE AND DIVISION.DIV_CODE = SEC_CLIENT.DIV_CODE
				WHERE     (CLIENT.CL_CODE = @ClientCode) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
				--ORDER BY  DIVISION.DIV_CODE,  DIVISION.DIV_NAME
			End		
	ELSE
		If @OfficeCount = 0
			Begin
				SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + isnull(DIVISION.DIV_NAME, '') + ' | ' + ISNULL(CLIENT.CL_CODE,'') AS Description
				FROM         CLIENT INNER JOIN
									  DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE
				WHERE     (CLIENT.CL_CODE = @ClientCode)
				--ORDER BY  DIVISION.DIV_CODE,  DIVISION.DIV_NAME
			End
			Else
			Begin
				SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + isnull(DIVISION.DIV_NAME, '') + ' | ' + ISNULL(CLIENT.CL_CODE,'') AS Description
				FROM         CLIENT INNER JOIN
									  DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
							   PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN 
							   EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
				WHERE     (CLIENT.CL_CODE = @ClientCode)
				--ORDER BY  DIVISION.DIV_CODE,  DIVISION.DIV_NAME
			End
		
END
IF @ClientCode = ''
BEGIN
	If @Rescrictions > 0
		If @OfficeCount = 0
			Begin
				SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + isnull(DIVISION.DIV_NAME, '') + ' | ' + ISNULL(CLIENT.CL_CODE,'') AS Description
				FROM         CLIENT INNER JOIN
								  DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
								  SEC_CLIENT ON DIVISION.CL_CODE = SEC_CLIENT.CL_CODE AND DIVISION.DIV_CODE = SEC_CLIENT.DIV_CODE
				WHERE     (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
				--ORDER BY  DIVISION.DIV_CODE,  DIVISION.DIV_NAME
			End
			Else
			Begin
				SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + isnull(DIVISION.DIV_NAME, '') + ' | ' + ISNULL(CLIENT.CL_CODE,'') AS Description
				FROM         CLIENT INNER JOIN
								  DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
							   PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN 
							   EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE INNER JOIN
								  SEC_CLIENT ON DIVISION.CL_CODE = SEC_CLIENT.CL_CODE AND DIVISION.DIV_CODE = SEC_CLIENT.DIV_CODE
				WHERE     (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
				--ORDER BY  DIVISION.DIV_CODE,  DIVISION.DIV_NAME
			End		
	ELSE
		If @OfficeCount = 0
			Begin
				SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + isnull(DIVISION.DIV_NAME, '') + ' | ' + ISNULL(CLIENT.CL_CODE,'') AS Description
				FROM         CLIENT INNER JOIN
									  DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE
				--ORDER BY  DIVISION.DIV_CODE,  DIVISION.DIV_NAME
			End
			Else
			Begin
				SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + isnull(DIVISION.DIV_NAME, '') + ' | ' + ISNULL(CLIENT.CL_CODE,'') AS Description
				FROM         CLIENT INNER JOIN
									  DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
							   PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN 
							   EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
				--ORDER BY  DIVISION.DIV_CODE,  DIVISION.DIV_NAME		
			End
		
END

