SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advfn_period_to_month_year]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[advfn_period_to_month_year]
GO


CREATE FUNCTION [dbo].[advfn_period_to_month_year] ( @period varchar(6) )
RETURNS varchar(8)
AS
BEGIN

-- =================================================
-- RETURNS THE MONTH AND YEAR FOR A SPECIFIED PERIOD
-- =================================================

	DECLARE @month_number	varchar(2)
	DECLARE @year			varchar(4)
	DECLARE @month_year		varchar(8)
	
	SET @month_number = RIGHT(@period,2)
	SET @year = LEFT(@period,4)

	SELECT @month_year =
		CASE @month_number
			WHEN '01' THEN 'Jan'
			WHEN '02' THEN 'Feb'
			WHEN '03' THEN 'Mar'
			WHEN '04' THEN 'Apr'
			WHEN '05' THEN 'May'
			WHEN '06' THEN 'Jun'
			WHEN '07' THEN 'Jul'
			WHEN '08' THEN 'Aug'
			WHEN '09' THEN 'Sep'
			WHEN '10' THEN 'Oct'
			WHEN '11' THEN 'Nov'
			WHEN '12' THEN 'Dec'
		END
		+ ' ' + @year	
		
	RETURN @month_year		
		
END
GO

GRANT ALL ON advfn_period_to_month_year TO PUBLIC AS dbo
GO

--INSERT INTO dbo.DB_UPDATE( VERSION_ID, PATCH, DESCRIPTION, FUNCTION_NAME )
--     VALUES( 'v5.81.0', 'Create_advfn_period_to_month_year.sql', 
--		'Adds advfn_period_to_month_year', 'Create_advfn_period_to_month_year_011218' )
GO	
