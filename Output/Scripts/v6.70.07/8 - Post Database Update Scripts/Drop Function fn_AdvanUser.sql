IF EXISTS ( SELECT * FROM sysobjects WHERE id = OBJECT_ID( N'[dbo].[fn_AdvanUser]' ) AND xtype IN ( N'FN', N'IF', N'TF' )) BEGIN

	DROP FUNCTION [dbo].[fn_AdvanUser]

END
GO

CREATE FUNCTION [dbo].[fn_AdvanUser]()
RETURNS varchar(100)
AS
BEGIN

	DECLARE @advan_user varchar(100)

	SET @advan_user = (SELECT SUBSTRING(UPPER(SYSTEM_USER), CHARINDEX('', SYSTEM_USER) + 1, LEN(SYSTEM_USER)))
	
	IF CHARINDEX('\', @advan_user) > 0 BEGIN

		SET @advan_user = (SELECT SUBSTRING(UPPER(@advan_user), CHARINDEX('\', @advan_user) + 1, LEN(@advan_user)))

	END

	RETURN @advan_user

END
GO