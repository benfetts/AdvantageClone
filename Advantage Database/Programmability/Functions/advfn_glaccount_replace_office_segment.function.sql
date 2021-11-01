CREATE FUNCTION [dbo].[advfn_glaccount_replace_office_segment] ( @glacode varchar(30), @glaoffice varchar(20))
RETURNS varchar(30)	AS
BEGIN
	DECLARE @newglacode varchar(30),
			@glabase varchar(20),
			@gladept varchar(5),
			@glaother varchar(20)
	
	IF EXISTS (SELECT 1 FROM dbo.GLCONFIG
			WHERE (SEGMENT1_FORMAT IS NOT NULL AND SEGMENT1_TYPE = 2)
			OR (SEGMENT2_FORMAT IS NOT NULL AND SEGMENT2_TYPE = 2)
			OR (SEGMENT3_FORMAT IS NOT NULL AND SEGMENT3_TYPE = 2) 
			OR (SEGMENT4_FORMAT IS NOT NULL AND SEGMENT4_TYPE = 2))
	BEGIN
	
		SELECT @glabase = GLABASE, @gladept = GLADEPT, @glaother = GLAOTHER
		FROM dbo.GLACCOUNT
		WHERE GLACODE = @glacode 
		
		SELECT @newglacode = GLACODE
		FROM dbo.GLACCOUNT
		WHERE GLABASE = @glabase
		AND GLAOFFICE = @glaoffice 
		AND	(GLADEPT IS NULL OR GLADEPT = @gladept)
		AND (GLAOTHER IS NULL OR GLAOTHER = @glaother)
		
	END
	
	RETURN COALESCE(@newglacode, @glacode) 
END 
GO
