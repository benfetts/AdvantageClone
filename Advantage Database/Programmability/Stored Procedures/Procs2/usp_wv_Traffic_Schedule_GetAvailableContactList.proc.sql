

CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetAvailableContactList]
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR INT,
@SEQ SMALLINT,
@Client VARCHAR(6),
@Division VARCHAR(6),
@Product VARCHAR(6)
AS

IF @Division = ''
BEGIN
	SET @Division = NULL
END
IF @Product = ''
BEGIN
	SET @Product = NULL
END

IF @JOB_NUMBER > 0 AND @JOB_COMPONENT_NBR > 0 AND @SEQ > -1  --If has job/comp/seq, then restrict to only show contacts not already assigned to task
	BEGIN
		        SELECT     
                DISTINCT A.CDP_CONTACT_ID,
                A.CONT_CODE, 
                A.CONT_FML,
                A.CL_CODE,
                --A.DIV_CODE, 
                --A.PRD_CODE
                 A.code, 
                A.description,
   			CAST(A.CDP_CONTACT_ID AS VARCHAR)+ '|' + A.CONT_CODE AS splitPK
				FROM         
					(SELECT 
						DISTINCT CDP_CONTACT_HDR.CDP_CONTACT_ID AS CDP_CONTACT_ID,
						CDP_CONTACT_HDR.CONT_CODE AS code, 
						CDP_CONTACT_HDR.CONT_CODE + ' - ' + CDP_CONTACT_HDR.CONT_FML AS description, 
						CDP_CONTACT_HDR.CONT_CODE, 
						CDP_CONTACT_HDR.CONT_FML, 
						CDP_CONTACT_HDR.CL_CODE, 
						CDP_CONTACT_DTL.DIV_CODE, 
						CDP_CONTACT_DTL.PRD_CODE, 
						CDP_CONTACT_HDR.INACTIVE_FLAG,
						CDP_CONTACT_HDR.SCHEDULE_USER
					FROM          
						CDP_CONTACT_HDR LEFT OUTER JOIN
						 CDP_CONTACT_DTL ON CDP_CONTACT_HDR.CDP_CONTACT_ID = CDP_CONTACT_DTL.CDP_CONTACT_ID
					WHERE      ((CDP_CONTACT_HDR.CL_CODE = @Client) AND (CDP_CONTACT_DTL.DIV_CODE = @Division) AND 
									  (CDP_CONTACT_DTL.PRD_CODE = @Product)) OR
									  ((CDP_CONTACT_HDR.CL_CODE = @Client) AND (CDP_CONTACT_DTL.DIV_CODE = @Division) AND (CDP_CONTACT_DTL.PRD_CODE IS NULL)) OR	
									  ((CDP_CONTACT_HDR.CL_CODE = @Client) AND (CDP_CONTACT_DTL.DIV_CODE IS NULL) AND (CDP_CONTACT_DTL.PRD_CODE IS NULL))
					 ) AS A
				WHERE     
					((A.INACTIVE_FLAG = 0) OR (A.INACTIVE_FLAG IS NULL)) AND (A.SCHEDULE_USER = 1) AND A.CDP_CONTACT_ID NOT IN (
					                SELECT     
					                    JOB_TRAFFIC_DET_CNTS.CDP_CONTACT_ID
					                FROM         
					                    JOB_TRAFFIC_DET_CNTS 
					                WHERE     
					                     ((JOB_TRAFFIC_DET_CNTS.JOB_NUMBER = @JOB_NUMBER) 
					                    AND (JOB_TRAFFIC_DET_CNTS.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR) 
					                    AND (JOB_TRAFFIC_DET_CNTS.SEQ_NBR = @SEQ))                    
					                )
				ORDER BY 
					A.CONT_FML
			
	END
ELSE IF (NOT (@Client IS NULL)) AND @Division IS NULL AND @Product IS NULL
	BEGIN
				SELECT     
                DISTINCT A.CDP_CONTACT_ID,
                A.code AS code2, 
                A.description,
                A.CL_CODE,
                --A.DIV_CODE, 
                --A.PRD_CODE
    			CAST(A.CDP_CONTACT_ID AS VARCHAR)+ '|' + A.code AS code
				FROM         
					(SELECT 
						DISTINCT CDP_CONTACT_HDR.CDP_CONTACT_ID AS CDP_CONTACT_ID,
						CDP_CONTACT_HDR.CONT_CODE AS code, 
						CDP_CONTACT_HDR.CONT_CODE + ' - ' + CDP_CONTACT_HDR.CONT_FML AS description, 
						CDP_CONTACT_HDR.CL_CODE, 
						CDP_CONTACT_DTL.DIV_CODE, 
						CDP_CONTACT_DTL.PRD_CODE, 
						CDP_CONTACT_HDR.INACTIVE_FLAG,
						CDP_CONTACT_HDR.SCHEDULE_USER
					FROM          
						CDP_CONTACT_HDR LEFT OUTER JOIN
						 CDP_CONTACT_DTL ON CDP_CONTACT_HDR.CDP_CONTACT_ID = CDP_CONTACT_DTL.CDP_CONTACT_ID
					WHERE      
						CDP_CONTACT_HDR.CL_CODE = @Client
					 ) AS A
				WHERE     
					((A.INACTIVE_FLAG = 0) OR (A.INACTIVE_FLAG IS NULL)) AND (A.SCHEDULE_USER = 1)
				ORDER BY 
					A.code
	END	
ELSE --no job/comp/seq = no contacts for this task, show all contacts; no need to remove contacts already assigned
	BEGIN
				SELECT     
                DISTINCT A.CDP_CONTACT_ID,
                A.code AS code2, 
                A.description,
                A.CL_CODE,
                --A.DIV_CODE, 
                --A.PRD_CODE
    			CAST(A.CDP_CONTACT_ID AS VARCHAR)+ '|' + A.code AS code
				FROM         
					(SELECT 
						DISTINCT CDP_CONTACT_HDR.CDP_CONTACT_ID AS CDP_CONTACT_ID,
						CDP_CONTACT_HDR.CONT_CODE AS code, 
						CDP_CONTACT_HDR.CONT_CODE + ' - ' + CDP_CONTACT_HDR.CONT_FML AS description, 
						CDP_CONTACT_HDR.CL_CODE, 
						CDP_CONTACT_DTL.DIV_CODE, 
						CDP_CONTACT_DTL.PRD_CODE, 
						CDP_CONTACT_HDR.INACTIVE_FLAG,
						CDP_CONTACT_HDR.SCHEDULE_USER
					FROM          
						CDP_CONTACT_HDR LEFT OUTER JOIN
						 CDP_CONTACT_DTL ON CDP_CONTACT_HDR.CDP_CONTACT_ID = CDP_CONTACT_DTL.CDP_CONTACT_ID
					WHERE      ((CDP_CONTACT_HDR.CL_CODE = @Client) AND (CDP_CONTACT_DTL.DIV_CODE = @Division) AND 
									  (CDP_CONTACT_DTL.PRD_CODE = @Product)) OR
									  ((CDP_CONTACT_HDR.CL_CODE = @Client) AND (CDP_CONTACT_DTL.DIV_CODE = @Division) AND (CDP_CONTACT_DTL.PRD_CODE IS NULL)) OR	
									  ((CDP_CONTACT_HDR.CL_CODE = @Client) AND (CDP_CONTACT_DTL.DIV_CODE IS NULL) AND (CDP_CONTACT_DTL.PRD_CODE IS NULL))
					 ) AS A
				WHERE     
					((A.INACTIVE_FLAG = 0) OR (A.INACTIVE_FLAG IS NULL)) AND (A.SCHEDULE_USER = 1)
				ORDER BY 
					A.code
			
	END


