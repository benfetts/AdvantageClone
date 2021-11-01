


















CREATE PROCEDURE [dbo].[usp_AdvanDB_Product] 

@Client varchar(6),
@Division varchar(6)

AS

if @Client = 'ALL' and @Division = 'ALL' Begin
SELECT  CL_CODE, DIV_CODE, PRD_CODE, PRD_DESCRIPTION
FROM        PRODUCT
WHERE   ACTIVE_FLAG = 1
end

if @Client <> 'ALL' and @Division = 'ALL' Begin
SELECT  CL_CODE, DIV_CODE, PRD_CODE, PRD_DESCRIPTION
FROM        PRODUCT
WHERE   ACTIVE_FLAG = 1
and CL_CODE = @Client
end

if @Client <> 'ALL' and @Division <> 'ALL' Begin
SELECT  CL_CODE, DIV_CODE, PRD_CODE, PRD_DESCRIPTION
FROM        PRODUCT
WHERE   ACTIVE_FLAG = 1
and CL_CODE = @Client and DIV_CODE = @Division
end

















