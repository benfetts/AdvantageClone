


















CREATE PROCEDURE [dbo].[usp_AdvanDB_Division]

@Client varchar(6)

AS

If @Client = 'ALL' begin
SELECT  CL_CODE, DIV_CODE, DIV_NAME
FROM        DIVISION
WHERE   ACTIVE_FLAG = 1
end

If @Client <> 'ALL' begin
SELECT  CL_CODE, DIV_CODE, DIV_NAME
FROM        DIVISION
WHERE   ACTIVE_FLAG = 1
and CL_CODE = @Client
end
















