IF EXISTS ( SELECT * FROM sysobjects WHERE id = OBJECT_ID( N'[dbo].[advfn_get_vn_pay_to_code]' ) AND xtype IN ( N'FN', N'IF', N'TF' ))
BEGIN
	DROP FUNCTION [dbo].[advfn_get_vn_pay_to_code]
END
GO

CREATE FUNCTION [dbo].[advfn_get_vn_pay_to_code] ( @vn_code varchar(6) )  		  	
RETURNS VARCHAR(6) AS  	

BEGIN  

DECLARE @parent_id varchar(6);
SET @parent_id  = @vn_code;

WITH ALLPRARENTS AS (
    SELECT VN_CODE, VN_NAME, VN_CODE [ROOTID],VN_NAME [ROOTNAME], 1 AS LVL, VN_PAY_TO_CODE
    FROM VENDOR WITH (NOLOCK)
    WHERE VN_CODE = @parent_id
    UNION ALL
    SELECT A1.VN_CODE,A1.VN_NAME,A2.[ROOTID],A2.[ROOTNAME], LVL+1, A1.VN_PAY_TO_CODE
    FROM VENDOR A1 WITH (NOLOCK)
    JOIN ALLPRARENTS A2 ON A2.VN_PAY_TO_CODE = A1.VN_CODE AND A1.VN_CODE <> A1.VN_PAY_TO_CODE AND A1.VN_PAY_TO_CODE <> @parent_id 
)   

SELECT TOP 1 @vn_code = B.VN_CODE FROM ALLPRARENTS A WITH (NOLOCK) JOIN VENDOR B WITH (NOLOCK) ON B.VN_CODE = A.VN_PAY_TO_CODE
ORDER BY LVL DESC;

IF @vn_code = '' SET @vn_code = NULL

RETURN @vn_code
	
END
GO
