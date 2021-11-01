SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_GetJobCompNewAlert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_GetJobCompNewAlert]
GO


CREATE PROCEDURE [dbo].[usp_wv_dd_GetJobCompNewAlert] 
@UserID VARCHAR(100),
@ClientCode VARCHAR(6), 
@DivisionCode VARCHAR(6), 
@ProductCode VARCHAR(6), 
@Job INT,
@OfficeCode VARCHAR(4),
@SalesClass VARCHAR(6),
@CP as int,
@CPID as int
AS
DECLARE 
@Restrictions INT, @RestrictionsCP Int

SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)

Select @RestrictionsCP = Count(*) 
FROM CP_SEC_CLIENT
Where CDP_CONTACT_ID = @CPID

IF @CP = 1
BEGIN
IF @RestrictionsCP > 0 
    BEGIN
        IF @Job <> 0
            BEGIN
                SELECT     
                    JOB_COMPONENT.JOB_COMPONENT_NBR AS Code,  STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
                FROM         
                    JOB_LOG INNER JOIN
                    JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
                    CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND 
                    JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
                WHERE     
                    (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
	                AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%' ) 
	                AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%' ) 
	                AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%' )
	                AND (JOB_LOG.OFFICE_CODE LIKE @OfficeCode + '%' )
	                AND (JOB_LOG.SC_CODE LIKE @SalesClass + '%' )
	                AND (JOB_COMPONENT.JOB_NUMBER = @Job)
	                AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)
                ORDER BY 
                    JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
            END
        ELSE
            BEGIN
                SELECT     
                   STR(JOB_LOG.JOB_NUMBER) + '-' + ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code,  STR(JOB_LOG.JOB_NUMBER) + '-' + ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' | ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
                FROM         
                    JOB_LOG INNER JOIN
                    JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
                    CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND 
                    JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
                WHERE     
                    (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
	                AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%' ) 
	                AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%' ) 
	                AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%' )
	                AND (JOB_LOG.OFFICE_CODE LIKE @OfficeCode + '%' )
	                AND (JOB_LOG.SC_CODE LIKE @SalesClass + '%' )
	                --AND (JOB_COMPONENT.JOB_NUMBER = @Job)
	                AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)
                ORDER BY 
                    JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC           
            END
        
    END
ELSE
    BEGIN
        IF @Job <> 0
            BEGIN
                SELECT     
                    JOB_COMPONENT.JOB_COMPONENT_NBR AS Code,  STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
                FROM         
                    JOB_LOG INNER JOIN
                    JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
                WHERE     
                    (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
	                AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%' ) 
	                AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%' ) 
	                AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%' )
	                AND (JOB_LOG.OFFICE_CODE LIKE @OfficeCode + '%' )
	                AND (JOB_LOG.SC_CODE LIKE @SalesClass + '%' )
	                AND (JOB_COMPONENT.JOB_NUMBER = @Job)
                ORDER BY 
                    JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
            END
        ELSE
            BEGIN
                SELECT     
                    STR(JOB_LOG.JOB_NUMBER) + '-' + ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code,  STR(JOB_LOG.JOB_NUMBER) + '-' + ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' | ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
                FROM         
                    JOB_LOG INNER JOIN
                    JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
                WHERE     
                    (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
	                AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%' ) 
	                AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%' ) 
	                AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%' )
	                AND (JOB_LOG.OFFICE_CODE LIKE @OfficeCode + '%' )
	                AND (JOB_LOG.SC_CODE LIKE @SalesClass + '%'  )
	                --AND (JOB_COMPONENT.JOB_NUMBER = @Job)
                ORDER BY 
                    JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC            
            END
        
    END
END
ELSE
BEGIN
IF @Restrictions > 0 
    BEGIN
        IF @Job <> 0
            BEGIN
                SELECT     
                    JOB_COMPONENT.JOB_COMPONENT_NBR AS Code,  STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
                FROM         
                    JOB_LOG INNER JOIN
                    JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
                    SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
                    JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
                WHERE     
                    (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
	                AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%' ) 
	                AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%' ) 
	                AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%' )
	                AND (JOB_LOG.OFFICE_CODE LIKE @OfficeCode + '%' )
	                AND (JOB_LOG.SC_CODE LIKE @SalesClass + '%' )
	                AND (JOB_COMPONENT.JOB_NUMBER = @Job)
	                AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
                ORDER BY 
                    JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
            END
        ELSE
            BEGIN
                SELECT     
                   STR(JOB_LOG.JOB_NUMBER) + '-' + ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code,  STR(JOB_LOG.JOB_NUMBER) + '-' + ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' | ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
                FROM         
                    JOB_LOG INNER JOIN
                    JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
                    SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
                    JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
                WHERE     
                    (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
	                AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%' ) 
	                AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%' ) 
	                AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%' )
	                AND (JOB_LOG.OFFICE_CODE LIKE @OfficeCode + '%' )
	                AND (JOB_LOG.SC_CODE LIKE @SalesClass + '%' )
	                --AND (JOB_COMPONENT.JOB_NUMBER = @Job)
	                AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
                ORDER BY 
                    JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC           
            END
        
    END
ELSE
    BEGIN
        IF @Job <> 0
            BEGIN
                SELECT     
                    JOB_COMPONENT.JOB_COMPONENT_NBR AS Code,  STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
                FROM         
                    JOB_LOG INNER JOIN
                    JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
                WHERE     
                    (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
	                AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%' ) 
	                AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%' ) 
	                AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%' )
	                AND (JOB_LOG.OFFICE_CODE LIKE @OfficeCode + '%' )
	                AND (JOB_LOG.SC_CODE LIKE @SalesClass + '%' )
	                AND (JOB_COMPONENT.JOB_NUMBER = @Job)
                ORDER BY 
                    JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
            END
        ELSE
            BEGIN
                SELECT     
                    STR(JOB_LOG.JOB_NUMBER) + '-' + ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code,  STR(JOB_LOG.JOB_NUMBER) + '-' + ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + ' | ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
                FROM         
                    JOB_LOG INNER JOIN
                    JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
                WHERE     
                    (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
	                AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%' ) 
	                AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%' ) 
	                AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%' )
	                AND (JOB_LOG.OFFICE_CODE LIKE @OfficeCode + '%' )
	                AND (JOB_LOG.SC_CODE LIKE @SalesClass + '%'  )
	                --AND (JOB_COMPONENT.JOB_NUMBER = @Job)
                ORDER BY 
                    JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC            
            END
        
    END
END







GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

