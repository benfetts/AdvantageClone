/****** Object:  StoredProcedure [dbo].[usp_wv_dd_Filter_Clients_All]    Script Date: 3/25/2019 4:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_wv_dd_Filter_Clients_All] 
@UserID VARCHAR(100),
@OfficeCode VARCHAR(6)
AS
DECLARE 
@Rescrictions INT,
@ThisOfficeCode VARCHAR(6)

--See if user is restricted:
Select @Rescrictions = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)
--See if the office code is valid, if it is the select should return the same value, if it isn't valid, it should set the var to a blank
SELECT @ThisOfficeCode = ISNULL(OFFICE_CODE,'') FROM OFFICE WHERE OFFICE_CODE = @OfficeCode

IF @ThisOfficeCode = ''
        BEGIN
                IF @Rescrictions > 0
	                SELECT     DISTINCT CLIENT.CL_CODE AS Code, CLIENT.CL_CODE + ' - ' + ISNULL(CLIENT.CL_NAME, '') AS Description, CLIENT.CL_CODE AS ClientCode, CLIENT.CL_NAME AS ClientName
								,ACTIVE_FLAG as IsActive
	                FROM         CLIENT INNER JOIN
                                      SEC_CLIENT ON CLIENT.CL_CODE = SEC_CLIENT.CL_CODE
	                WHERE    (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) 
	                ORDER BY  CLIENT.CL_CODE
                ELSE
	                SELECT     DISTINCT CLIENT.CL_CODE AS Code, CLIENT.CL_CODE + ' - ' + ISNULL(CLIENT.CL_NAME, '') AS Description, CLIENT.CL_CODE AS ClientCode, CLIENT.CL_NAME AS ClientName
								,ACTIVE_FLAG as IsActive
	                FROM         CLIENT
	                ORDER BY  CLIENT.CL_CODE
        END
ELSE
        BEGIN
                IF @Rescrictions > 0
                        SELECT     DISTINCT CLIENT.CL_CODE AS Code, CLIENT.CL_CODE + ' - ' + ISNULL(CLIENT.CL_NAME, '') AS Description, CLIENT.CL_CODE AS ClientCode, CLIENT.CL_NAME AS ClientName
								,CLIENT.ACTIVE_FLAG as IsActive
                        FROM         CLIENT INNER JOIN
                                              DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
                                              PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
                                              OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE INNER JOIN
                                              SEC_CLIENT ON PRODUCT.CL_CODE = SEC_CLIENT.CL_CODE AND PRODUCT.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
                                              PRODUCT.PRD_CODE = SEC_CLIENT.PRD_CODE
                        WHERE     (OFFICE.OFFICE_CODE = @ThisOfficeCode) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) 
                ELSE
                        SELECT     DISTINCT CLIENT.CL_CODE AS Code, CLIENT.CL_CODE + ' - ' + ISNULL(CLIENT.CL_NAME, '') AS Description, CLIENT.CL_CODE AS ClientCode, CLIENT.CL_NAME AS ClientName
								,CLIENT.ACTIVE_FLAG as IsActive
                        FROM         CLIENT INNER JOIN
                                              DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
                                              PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
                                              OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE
                        WHERE OFFICE.OFFICE_CODE = @ThisOfficeCode 
        END
GO