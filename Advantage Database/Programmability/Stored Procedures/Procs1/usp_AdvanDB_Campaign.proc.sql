

CREATE PROCEDURE [dbo].[usp_AdvanDB_Campaign] 

@Client varchar(6),
@Division varchar(6),
@Product varchar(6)

AS

If @Client = 'ALL' and @Division = 'ALL' and @Product = 'ALL' 
Begin
SELECT  CL_CODE, DIV_CODE, PRD_CODE, CMP_CODE, CMP_NAME, CMP_IDENTIFIER
FROM        CAMPAIGN
WHERE    ((CMP_CLOSED = 0 or CMP_CLOSED = NULL) and CMP_TYPE = 2)
end

If @Client <> 'ALL' and @Division = 'ALL' and @Product = 'ALL' 
Begin
SELECT  CL_CODE, DIV_CODE, PRD_CODE, CMP_CODE, CMP_NAME, CMP_IDENTIFIER
FROM        CAMPAIGN
WHERE    ((CMP_CLOSED = 0 or CMP_CLOSED = NULL) and CMP_TYPE = 2)
and CL_CODE = @Client
end

If @Client <> 'ALL' and @Division <> 'ALL' and @Product = 'ALL' 
Begin
SELECT  CL_CODE, DIV_CODE, PRD_CODE, CMP_CODE, CMP_NAME, CMP_IDENTIFIER
FROM        CAMPAIGN
WHERE    ((CMP_CLOSED = 0 or CMP_CLOSED = NULL) and CMP_TYPE = 2)
and CL_CODE = @Client and DIV_CODE = @Division
end

If @Client <> 'ALL' and @Division <> 'ALL' and @Product <> 'ALL' 
Begin
SELECT  CL_CODE, DIV_CODE, PRD_CODE, CMP_CODE, CMP_NAME, CMP_IDENTIFIER
FROM        CAMPAIGN
WHERE    ((CMP_CLOSED = 0 or CMP_CLOSED = NULL) and CMP_TYPE = 2)
and CL_CODE = @Client and DIV_CODE = @Division and PRD_CODE = @Product
end


