/****** Gets the max rev/seq for a given order/line - 05/15/2015 16:07:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_med_calc_comm_mu]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_med_calc_comm_mu]
GO

/****** Object:  UserDefinedFunction [dbo].[advtf_med_calc_comm_mu]    Script Date: 05/15/2015 16:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* 
SELECT * FROM advtf_med_calc_comm_mu( 1, 15) --GROSS
SELECT * FROM advtf_med_calc_comm_mu( 0, 17.647) --NET
*/			

CREATE FUNCTION [dbo].[advtf_med_calc_comm_mu] (
		@net_gross			smallint,				--Gross = 1 = Commission
		@comm_mu_pct 	decimal (7, 3)		--Commission or Markup depending on Net/Gross
		)
	RETURNS @med_temp TABLE ( 
		[COMM_PCT] [decimal](7, 3)  NULL,
		[MARKUP_PCT] [decimal](7, 3)  NULL
		)
AS
BEGIN

	DECLARE 		
		@net_w decimal (10, 3),
		@comm_w decimal (10, 3),
		@comm_mu_pct_w	decimal (7, 3),
		@comm_pct_w	decimal (7, 3),
		@markup_pct_w decimal (7, 3)

	BEGIN
		/*...med_set_def_tax_info is previous to this*/
		
		IF @net_gross = 1 --Gross
			BEGIN
				SET @comm_pct_w = @comm_mu_pct
				SET @net_w = COALESCE(100 - @comm_pct_w, 0)
				IF (@net_w = NULL OR @net_w = 0)	
					SET @markup_pct_w = 0
				ELSE	
					SET @markup_pct_w = ROUND(((@comm_pct_w/@net_w) * 100), 3)
			END
		ELSE --Net
			BEGIN
				SET @markup_pct_w = @comm_mu_pct
				SET @net_w = COALESCE(100 + (@markup_pct_w), 0)
				IF (@net_w = NULL OR @net_w = 0)	
					SET @comm_pct_w = 0
				ELSE	
					SET @comm_pct_w = @markup_pct_w / @net_w * 100
					SET @comm_pct_w = ROUND(@comm_pct_w, 3) 
			END			
			
		SET @comm_mu_pct_w = COALESCE(@comm_mu_pct_w, 0)
		SET @markup_pct_w = COALESCE(@markup_pct_w, 0)	
	END

	INSERT INTO @med_temp VALUES (@comm_pct_w, @markup_pct_w)

	RETURN
END

GO