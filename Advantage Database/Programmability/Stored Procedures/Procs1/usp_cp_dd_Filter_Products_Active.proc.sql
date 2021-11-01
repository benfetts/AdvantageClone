﻿
CREATE PROCEDURE [dbo].[usp_cp_dd_Filter_Products_Active] 
@CDPID int , 
@OfficeCode VARCHAR(6),
@ClientCode VARCHAR(6), 
@DivisionCode VARCHAR(6),
@Direction VARCHAR(10)
AS

DECLARE @Rescrictions INT

SELECT @Rescrictions = COUNT(*) FROM CP_SEC_CLIENT WHERE CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID

IF @Direction = 'Forward' 
    BEGIN
        IF @Rescrictions > 0
            BEGIN
            IF @OfficeCode = ''
                BEGIN
                        SELECT     
                        DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
                    FROM         CP_SEC_CLIENT INNER JOIN
                                          PRODUCT ON CP_SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND CP_SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND 
                                          CP_SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
                                          DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                                          CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE                    
                      WHERE     
                        CP_SEC_CLIENT.CDP_CONTACT_ID = UPPER(@CDPID) AND (PRODUCT.CL_CODE = @ClientCode) AND (PRODUCT.DIV_CODE = @DivisionCode) 
                        AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
            END
            ELSE
                BEGIN
                    SELECT     
                        DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
                    FROM         CP_SEC_CLIENT INNER JOIN
                                          PRODUCT ON CP_SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND CP_SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND 
                                          CP_SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
                                          DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                                          CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE                    
                    WHERE     
                        CP_SEC_CLIENT.CDP_CONTACT_ID = UPPER(@CDPID) AND (PRODUCT.CL_CODE = @ClientCode) AND (PRODUCT.DIV_CODE = @DivisionCode) AND (PRODUCT.OFFICE_CODE = @OfficeCode)
                        AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
              END
            END
        ELSE
            BEGIN
            IF @OfficeCode = ''
                BEGIN
                     SELECT     
                        DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
                FROM         PRODUCT INNER JOIN
                                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
                    WHERE  (PRODUCT.CL_CODE = @ClientCode) AND (PRODUCT.DIV_CODE = @DivisionCode) 
                        AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
                END
            ELSE
                BEGIN
                    SELECT     
                        DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
                FROM         PRODUCT INNER JOIN
                                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
                    WHERE  (PRODUCT.CL_CODE = @ClientCode) AND (PRODUCT.DIV_CODE = @DivisionCode) AND (PRODUCT.OFFICE_CODE = @OfficeCode)
                        AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
                END
            


            END
    END
ELSE --Filter backwards
    BEGIN
        IF @Rescrictions > 0
            BEGIN
                SELECT     
                    DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
                    FROM         CP_SEC_CLIENT INNER JOIN
                                          PRODUCT ON CP_SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND CP_SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND 
                                          CP_SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
                                          DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                                          CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE                    
                WHERE     
                    CP_SEC_CLIENT.CDP_CONTACT_ID = UPPER(@CDPID)
                         AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
           END
        ELSE
            BEGIN
                SELECT     
                    DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
                FROM         PRODUCT INNER JOIN
                                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
                         WHERE  (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
           END
    END
