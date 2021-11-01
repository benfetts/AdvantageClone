




















/*
ST, 20060613
Found only proc control 6 and 12 in query, added the others
added order by
*/





CREATE PROCEDURE [dbo].[usp_wv_dd_GetJobComp_withClosed] 
@UserID VARCHAR(100),
@ClientCode VARCHAR(6), 
@DivisionCode VARCHAR(6), 
@ProductCode VARCHAR(6), 
@Job INT
AS
DECLARE 
@Restrictions INT

SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)

IF @Restrictions > 0 
    BEGIN
        IF @Job = 0
            BEGIN
                SELECT     
                    JOB_COMPONENT.JOB_COMPONENT_NBR AS Code,  STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
                FROM         
                    JOB_LOG INNER JOIN
                    JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
                    SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
                    JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
                WHERE     
                    (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,9,10,13)) 
	            AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%') 
	            AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%') 
	            AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%')
	                AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
                ORDER BY 
                    JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
            END
        ELSE
            BEGIN
                SELECT     
                    JOB_COMPONENT.JOB_COMPONENT_NBR AS Code,  STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
                FROM         
                    JOB_LOG INNER JOIN
                    JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
                    SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
                    JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
                WHERE     
                    (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,9,10,13)) 
	            AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%') 
	            AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%') 
	            AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%')
	                AND (JOB_COMPONENT.JOB_NUMBER = @Job)
	                AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
                ORDER BY 
                    JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
            END
        END
    
    
    
    
ELSE





    BEGIN
    IF @Job = 0
        BEGIN
            SELECT     
                JOB_COMPONENT.JOB_COMPONENT_NBR AS Code,  STR(JOB_LOG.JOB_NUMBER)+'-'+STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ' | ' + JOB_COMPONENT.JOB_COMP_DESC 
                +' | '+ @ClientCode+' - '+@DivisionCode+' - '+@ProductCode AS Description
            FROM         
                JOB_LOG INNER JOIN
                JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
            WHERE     
                (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,9,10,13)) 
	            AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%') 
	            AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%') 
	            AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%')
            ORDER BY 
                JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR DESC
        END
    ELSE
        BEGIN
            SELECT     
                JOB_COMPONENT.JOB_COMPONENT_NBR AS Code,  STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
            FROM         
                JOB_LOG INNER JOIN
                JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
            WHERE     
                (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,9,10,13)) 
	            AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%') 
	            AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%') 
	            AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%')
	            AND (JOB_COMPONENT.JOB_NUMBER = @Job)
            ORDER BY 
                JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR DESC
        END
            SELECT     
                JOB_COMPONENT.JOB_COMPONENT_NBR AS Code,  STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS Description
            FROM         
                JOB_LOG INNER JOIN
                JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
            WHERE     
                (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,9,10,13)) 
	            AND (JOB_LOG.CL_CODE LIKE @ClientCode + '%') 
	            AND (JOB_LOG.DIV_CODE LIKE @DivisionCode + '%') 
	            AND (JOB_LOG.PRD_CODE LIKE @ProductCode + '%')
	            AND (JOB_COMPONENT.JOB_NUMBER = @Job)
            ORDER BY 
                JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR DESC
    END



















