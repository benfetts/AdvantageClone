﻿
CREATE PROCEDURE [dbo].[usp_wv_Restricted_GetProducts]
@UserID VARCHAR(100), @CL_CODE VARCHAR(6),@DIV_CODE VARCHAR(6)
AS
DECLARE @Restricted INT

SELECT @Restricted = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)
IF @Restricted > 0
    BEGIN
		SELECT     
			DISTINCT PRODUCT.PRD_CODE+' - '+ISNULL(PRODUCT.PRD_DESCRIPTION,'') AS Text,
			CLIENT.CL_CODE+','+DIVISION.DIV_CODE+','+PRODUCT.PRD_CODE AS Value,
			'PR' AS Level,
			'Product:  '+PRODUCT.PRD_CODE+' - '+ISNULL(PRODUCT.PRD_DESCRIPTION,'') AS Crumb,
			PRODUCT.PRD_CODE AS FK,
			PRODUCT.PRD_CODE+' - '+ISNULL(PRODUCT.PRD_DESCRIPTION,'') AS ToolTip,
			'Images/product.png' AS ImageURL,
			'Images/product.png' AS ImageExpandedUrl
		FROM         
			OFFICE INNER JOIN
			PRODUCT ON OFFICE.OFFICE_CODE = PRODUCT.OFFICE_CODE INNER JOIN
			DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
			CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN
			SEC_CLIENT ON PRODUCT.CL_CODE = SEC_CLIENT.CL_CODE AND PRODUCT.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
			PRODUCT.PRD_CODE = SEC_CLIENT.PRD_CODE
		WHERE     
			(UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
			AND (CLIENT.CL_CODE = @CL_CODE)
			AND (DIVISION.DIV_CODE = @DIV_CODE)
    END
ELSE
    BEGIN
		SELECT     
			DISTINCT PRODUCT.PRD_CODE+' - '+ISNULL(PRODUCT.PRD_DESCRIPTION,'') AS Text,
			CLIENT.CL_CODE+','+DIVISION.DIV_CODE+','+PRODUCT.PRD_CODE AS Value,
			'PR' AS Level,
			'Product:  '+PRODUCT.PRD_CODE+' - '+ISNULL(PRODUCT.PRD_DESCRIPTION,'') AS Crumb,
			PRODUCT.PRD_CODE AS FK,
			PRODUCT.PRD_CODE+' - '+ISNULL(PRODUCT.PRD_DESCRIPTION,'') AS ToolTip,
			'Images/product.png' AS ImageURL,
			'Images/product.png' AS ImageExpandedUrl
		FROM         
			OFFICE INNER JOIN
			PRODUCT ON OFFICE.OFFICE_CODE = PRODUCT.OFFICE_CODE INNER JOIN
			DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
			CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
		WHERE
			(CLIENT.CL_CODE = @CL_CODE)
			AND (DIVISION.DIV_CODE = @DIV_CODE)
	END

