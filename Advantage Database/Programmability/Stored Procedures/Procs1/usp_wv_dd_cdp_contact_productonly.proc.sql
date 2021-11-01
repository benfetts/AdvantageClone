IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dd_cdp_contact_productonly]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_dd_cdp_contact_productonly]
GO





CREATE PROCEDURE [dbo].[usp_wv_dd_cdp_contact_productonly] 
@Client VARCHAR(6), 
@Division VARCHAR(6),
@Product VARCHAR(6),
@FromForm VARCHAR(15)  --Just in case need to differentiate
AS


DECLARE
@DetailCount INT


SELECT 
	@DetailCount = COUNT(1)
FROM
	CDP_CONTACT_DTL
WHERE
	(
	((DIV_CODE = @Division) AND (PRD_CODE = @Product)) 
	OR
        ((DIV_CODE = @Division) AND (PRD_CODE IS NULL))
	OR
        ((DIV_CODE = @Division))
	)

IF @DetailCount > 0
    BEGIN
        SELECT     
                 A.CDP_CONTACT_ID, 
                A.SplitPK, 
                A.code, 
                A.description,
                A.CL_CODE,
                --A.DIV_CODE, 
                --A.PRD_CODE 
			A.CONT_TELEPHONE, A.CELL_PHONE,
			A.CONT_FAX, A.EMAIL_ADDRESS, A.CONT_EXTENTION, A.CONT_FAX_EXTENTION
        FROM         
            (SELECT 
                 CDP_CONTACT_HDR.CDP_CONTACT_ID AS CDP_CONTACT_ID, 
                CAST(CDP_CONTACT_HDR.CDP_CONTACT_ID AS VARCHAR)+ '|' + CDP_CONTACT_HDR.CONT_CODE AS SplitPK, 
                CDP_CONTACT_HDR.CONT_CODE AS code, 
                CDP_CONTACT_HDR.CONT_CODE + ' - ' + CDP_CONTACT_HDR.CONT_FML AS description, 
                CDP_CONTACT_HDR.CL_CODE, 
                CDP_CONTACT_DTL.DIV_CODE, 
                CDP_CONTACT_DTL.PRD_CODE, 
                CDP_CONTACT_HDR.INACTIVE_FLAG, CDP_CONTACT_HDR.CONT_TELEPHONE, CDP_CONTACT_HDR.CELL_PHONE,
			CDP_CONTACT_HDR.CONT_FAX, CDP_CONTACT_HDR.EMAIL_ADDRESS, CDP_CONTACT_HDR.CONT_EXTENTION, CDP_CONTACT_HDR.CONT_FAX_EXTENTION, ISNULL(CONT_COMMENT, '') AS CONT_COMMENT, CONT_TITLE
            FROM          
                CDP_CONTACT_HDR LEFT OUTER JOIN
                 CDP_CONTACT_DTL ON CDP_CONTACT_HDR.CDP_CONTACT_ID = CDP_CONTACT_DTL.CDP_CONTACT_ID
            WHERE      ((CDP_CONTACT_HDR.CL_CODE = @Client) AND (CDP_CONTACT_DTL.DIV_CODE = @Division) AND 
                              (CDP_CONTACT_DTL.PRD_CODE = @Product)) OR
                              ((CDP_CONTACT_DTL.DIV_CODE = @Division) AND (CDP_CONTACT_DTL.PRD_CODE IS NULL)) OR	
                              ((CDP_CONTACT_DTL.DIV_CODE IS NULL) AND (CDP_CONTACT_DTL.PRD_CODE IS NULL))
             ) AS A
        WHERE     
            (A.CL_CODE = @Client) AND A.DIV_CODE = @Division AND A.PRD_CODE = @Product
            AND ((A.INACTIVE_FLAG = 0) OR (A.INACTIVE_FLAG IS NULL))
        ORDER BY 
            A.code
	END
--ELSE
	--BEGIN
--		SELECT 
--			DISTINCT CDP_CONTACT_HDR.CDP_CONTACT_ID AS CDP_CONTACT_ID, 
--			CAST(CDP_CONTACT_HDR.CDP_CONTACT_ID AS VARCHAR) + '|' + CDP_CONTACT_HDR.CONT_CODE AS SplitPK, 
--			CDP_CONTACT_HDR.CONT_CODE AS code, 
--			CDP_CONTACT_HDR.CONT_CODE + ' - ' + CDP_CONTACT_HDR.CONT_FML AS description, CDP_CONTACT_HDR.CONT_TELEPHONE, CDP_CONTACT_HDR.CELL_PHONE,
--			CDP_CONTACT_HDR.CONT_FAX, CDP_CONTACT_HDR.EMAIL_ADDRESS
--		FROM         
--			CDP_CONTACT_HDR
--		WHERE   
--			CDP_CONTACT_HDR.CL_CODE = @Client
--			AND ((CDP_CONTACT_HDR.INACTIVE_FLAG = 0) OR (CDP_CONTACT_HDR.INACTIVE_FLAG IS NULL))
--	    ORDER BY 
--	        CDP_CONTACT_HDR.CONT_CODE
	--END




