﻿CREATE VIEW [dbo].[V_PRODUCT]
WITH SCHEMABINDING
AS

	SELECT 
		dbo.PRODUCT.CL_CODE,  
		dbo.CLIENT.CL_NAME, 
		dbo.PRODUCT.DIV_CODE,
		dbo.DIVISION.DIV_NAME, 
		dbo.PRODUCT.PRD_CODE, 
		dbo.PRODUCT.PRD_DESCRIPTION, 
		dbo.PRODUCT.OFFICE_CODE, 
		dbo.OFFICE.OFFICE_NAME, 
		[CL_ACTIVE_FLAG] = dbo.CLIENT.ACTIVE_FLAG,
		[DIV_ACTIVE_FLAG] = CASE WHEN ISNULL(CLIENT.ACTIVE_FLAG, 0) = 1 THEN DIVISION.ACTIVE_FLAG END,
		[ACTIVE_FLAG] = CASE WHEN ISNULL(CLIENT.ACTIVE_FLAG, 0) = 1 AND ISNULL(DIVISION.ACTIVE_FLAG, 0) = 1 THEN PRODUCT.ACTIVE_FLAG END
	FROM 
		dbo.PRODUCT INNER JOIN
		dbo.DIVISION ON dbo.PRODUCT.DIV_CODE = dbo.DIVISION.DIV_CODE AND dbo.PRODUCT.CL_CODE = dbo.DIVISION.CL_CODE INNER JOIN
		dbo.CLIENT ON dbo.PRODUCT.CL_CODE = dbo.CLIENT.CL_CODE INNER JOIN
		dbo.OFFICE ON dbo.PRODUCT.OFFICE_CODE = dbo.OFFICE.OFFICE_CODE
	 
GO