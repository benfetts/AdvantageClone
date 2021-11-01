﻿CREATE FUNCTION [dbo].[fn_AdvanUser]()
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