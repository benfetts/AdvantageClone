SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_Filter_Products_Active]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_Filter_Products_Active]
GO

CREATE PROCEDURE [dbo].[usp_wv_dd_Filter_Products_Active] 
@UserID VARCHAR(100) , 
@OfficeCode VARCHAR(6),
@ClientCode VARCHAR(6), 
@DivisionCode VARCHAR(6),
@Direction VARCHAR(10)
AS

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @OfficeCount AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

DECLARE @Rescrictions INT,@sql nvarchar(4000),@paramlist nvarchar(4000)

SELECT @Rescrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER(SEC_CLIENT.USER_ID) LIKE UPPER(@UserID+'%')

IF @Direction = 'Forward' 
    BEGIN
		SELECT @sql = 'SELECT     
                        DISTINCT PRODUCT.OFFICE_CODE + ''|'' + PRODUCT.CL_CODE + ''|'' + PRODUCT.DIV_CODE + ''|'' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + '' - '' + ISNULL(PRODUCT.PRD_DESCRIPTION, '''') + '' | '' + PRODUCT.OFFICE_CODE + '' - '' + PRODUCT.CL_CODE + '' - '' + PRODUCT.DIV_CODE + '' - '' + PRODUCT.PRD_CODE AS Description
						FROM PRODUCT INNER JOIN
                                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE'
		IF @Rescrictions > 0
			BEGIN
				SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE'
			END
		IF @OfficeCount > 0
			BEGIN
				SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
			END
			SELECT @sql = @sql + ' WHERE (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)'
		IF @Rescrictions > 0
			BEGIN
				SELECT @sql = @sql + '  AND UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
			END	
		IF @OfficeCode <> ''
			BEGIN
				SELECT @sql = @sql + '  AND (PRODUCT.OFFICE_CODE = @OfficeCode)'
			END	
		IF @ClientCode <> ''
			BEGIN
				SELECT @sql = @sql + '  AND (PRODUCT.CL_CODE = @ClientCode)'
			END	
		IF @DivisionCode <> ''
			BEGIN
				SELECT @sql = @sql + '  AND (PRODUCT.DIV_CODE = @DivisionCode)'
			END

		SELECT @paramlist = '@UserID varchar(100), @OfficeCode varchar(6), @ClientCode varchar(6), @DivisionCode varchar(6), @EMP_CODE varchar(6)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @UserID, @OfficeCode, @ClientCode, @DivisionCode, @EMP_CODE
     --   IF @Rescrictions > 0
     --       BEGIN
     --       IF @OfficeCode = ''
     --           BEGIN
     --                   SELECT     
     --                   DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
     --               FROM         SEC_CLIENT INNER JOIN
     --                                     PRODUCT ON SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND 
     --                                     SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
     --                                     DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
     --                                     CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE                    
     --                 WHERE     
     --                   UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND (PRODUCT.CL_CODE = @ClientCode) AND (PRODUCT.DIV_CODE = @DivisionCode) 
     --                   AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
					--ORDER BY Code
     --       END
     --       ELSE
     --           BEGIN
     --               SELECT     
     --                   DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
     --               FROM         SEC_CLIENT INNER JOIN
     --                                     PRODUCT ON SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND 
     --                                     SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
     --                                     DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
     --                                     CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE                    
     --               WHERE     
     --                   UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND (PRODUCT.CL_CODE = @ClientCode) AND (PRODUCT.DIV_CODE = @DivisionCode) AND (PRODUCT.OFFICE_CODE = @OfficeCode)
     --                   AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
					--ORDER BY Code
     --         END
     --       END
     --   ELSE
     --       BEGIN
     --       IF @OfficeCode = ''
     --           BEGIN
     --                SELECT     
     --                   DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
     --           FROM         PRODUCT INNER JOIN
     --                                 DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
     --                                 CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
     --               WHERE  (PRODUCT.CL_CODE = @ClientCode) AND (PRODUCT.DIV_CODE = @DivisionCode) 
     --                   AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
					--ORDER BY Code
     --           END
     --       ELSE
     --           BEGIN
     --               SELECT     
     --                   DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
     --           FROM         PRODUCT INNER JOIN
     --                                 DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
     --                                 CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
     --               WHERE  (PRODUCT.CL_CODE = @ClientCode) AND (PRODUCT.DIV_CODE = @DivisionCode) AND (PRODUCT.OFFICE_CODE = @OfficeCode)
     --                   AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
					--ORDER BY Code
     --           END
            


     --       END
    END
ELSE --Filter backwards
    BEGIN
		SELECT @sql = 'SELECT     
                    DISTINCT PRODUCT.OFFICE_CODE + ''|'' + PRODUCT.CL_CODE + ''|'' + PRODUCT.DIV_CODE + ''|'' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + '' - '' + ISNULL(PRODUCT.PRD_DESCRIPTION, '''') + '' | '' + PRODUCT.OFFICE_CODE + '' - '' + PRODUCT.CL_CODE + '' - '' + PRODUCT.DIV_CODE + '' - '' + PRODUCT.PRD_CODE AS Description
                    FROM         PRODUCT INNER JOIN
                                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE'
		IF @Rescrictions > 0
			BEGIN
				SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE'
			END
		IF @OfficeCount > 0
			BEGIN
				SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
			END
			SELECT @sql = @sql + ' WHERE (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)'
		IF @Rescrictions > 0
			BEGIN
				SELECT @sql = @sql + '  AND UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
			END	
		IF @OfficeCode <> ''
			BEGIN
				SELECT @sql = @sql + '  AND (PRODUCT.OFFICE_CODE = @OfficeCode)'
			END			

		SELECT @paramlist = '@UserID varchar(100), @OfficeCode varchar(6), @EMP_CODE varchar(6)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @UserID, @OfficeCode, @EMP_CODE
     --   IF @Rescrictions > 0
     --       BEGIN
     --       IF @OfficeCode = ''
     --           BEGIN
     --               SELECT     
     --               DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
     --               FROM         SEC_CLIENT INNER JOIN
     --                                     PRODUCT ON SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND 
     --                                     SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
     --                                     DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
     --                                     CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE                    
     --               WHERE     
     --                   UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
     --                        AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
					--ORDER BY Code
     --           END
     --       ELSE
     --           BEGIN
     --               SELECT     
     --               DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
     --               FROM         SEC_CLIENT INNER JOIN
     --                                     PRODUCT ON SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND 
     --                                     SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
     --                                     DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
     --                                     CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE                    
     --               WHERE     
     --                   UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
     --                        AND (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1) AND (PRODUCT.OFFICE_CODE = @OfficeCode)
					--ORDER BY Code
     --           END
                
     --      END
     --   ELSE
     --       BEGIN
     --       IF @OfficeCode = ''
     --           BEGIN
     --               SELECT     
     --               DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
     --               FROM         PRODUCT INNER JOIN
     --                                 DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
     --                                 CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
     --                    WHERE  (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
					--ORDER BY Code
     --           END
     --       ELSE
     --           BEGIN
     --               SELECT     
     --               DISTINCT PRODUCT.OFFICE_CODE + '|' + PRODUCT.CL_CODE + '|' + PRODUCT.DIV_CODE + '|' + PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + PRODUCT.OFFICE_CODE + ' - ' + PRODUCT.CL_CODE + ' - ' + PRODUCT.DIV_CODE + ' - ' + PRODUCT.PRD_CODE AS Description
     --               FROM         PRODUCT INNER JOIN
     --                                 DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
     --                                 CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
     --                    WHERE  (PRODUCT.ACTIVE_FLAG = 1) AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1) AND (PRODUCT.OFFICE_CODE = @OfficeCode)
					--ORDER BY Code
     --           END
                
     --      END
    END
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO  