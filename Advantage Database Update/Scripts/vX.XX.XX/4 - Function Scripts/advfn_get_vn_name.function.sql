IF EXISTS ( SELECT * FROM sysobjects WHERE id = OBJECT_ID( N'[dbo].[advfn_get_vn_name]' ) AND xtype IN ( N'FN', N'IF', N'TF' ))
BEGIN
	DROP FUNCTION [dbo].[advfn_get_vn_name]
END
GO

CREATE FUNCTION [dbo].[advfn_get_vn_name] ( @vn_code varchar(6) )  		  	
RETURNS VARCHAR(40) AS  	

BEGIN  

DECLARE @vn_name varchar(40)

IF @vn_code IS NOT NULL BEGIN
	SELECT @vn_name = VN_NAME FROM VENDOR WITH (NOLOCK) WHERE VN_CODE = @vn_code

	IF @vn_name = '' SET @vn_name = NULL
END

RETURN @vn_name
	
END
GO