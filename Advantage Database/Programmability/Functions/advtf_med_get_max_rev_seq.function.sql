/****** Gets the max rev/seq for a given order/line - 05/15/2015 16:07:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_med_get_max_rev_seq]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_med_get_max_rev_seq]
GO

/****** Object:  UserDefinedFunction [dbo].[advtf_med_get_max_rev_seq]    Script Date: 05/15/2015 16:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[advtf_med_get_max_rev_seq] (
		@order_nbr int, 
		@line_nbr int,
		@order_type varchar (2))
	RETURNS @med_max_rev_seq TABLE ( 
		MAX_REV_NBR		INT NOT NULL,
		MAX_SEQ_NBR		INT NOT NULL,
		OFFSET_REV_NBR	INT NOT NULL,
		OFFSET_SEQ_NBR	INT NOT NULL,
		ONSET_REV_NBR	INT NOT NULL,
		ONSET_SEQ_NBR	INT NOT NULL,
		ORDER_TYPE VARCHAR(2) NOT NULL 
		)
AS
BEGIN
	/*** Get the MAX REV & SEQ for a given ORDER/LINE ***/
	DECLARE @max_rev_nbr int, @max_seq_nbr int
	DECLARE @offset_rev_nbr int, @offset_seq_nbr int
	DECLARE @onset_rev_nbr int, @onset_seq_nbr int	
	
	IF @order_type = 'NP' BEGIN	
		SELECT @max_rev_nbr = MAX(MAX_REV_NBR), @max_seq_nbr = MAX(SEQ_NBR) FROM NEWSPAPER_DETAIL A 
		JOIN (
			SELECT [ORDER_NBR], [LINE_NBR], MAX([REV_NBR]) MAX_REV_NBR
			FROM [dbo].[NEWSPAPER_DETAIL] A
			WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
			GROUP BY A.[ORDER_NBR], A.[LINE_NBR]  ) B
		ON 	A.[ORDER_NBR] = B.[ORDER_NBR] AND A.[LINE_NBR] = B.[LINE_NBR]
		WHERE [REV_NBR] = MAX_REV_NBR	
	END
	ELSE 	IF @order_type = 'MA' BEGIN	
		SELECT @max_rev_nbr = MAX(MAX_REV_NBR), @max_seq_nbr = MAX(SEQ_NBR) FROM MAGAZINE_DETAIL A 
		JOIN (
			SELECT [ORDER_NBR], [LINE_NBR], MAX([REV_NBR]) MAX_REV_NBR
			FROM [dbo].[MAGAZINE_DETAIL] A
			WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
			GROUP BY A.[ORDER_NBR], A.[LINE_NBR]  ) B
		ON 	A.[ORDER_NBR] = B.[ORDER_NBR] AND A.[LINE_NBR] = B.[LINE_NBR]
		WHERE [REV_NBR] = MAX_REV_NBR	
	END
	ELSE 	IF @order_type = 'IN' BEGIN	
		SELECT @max_rev_nbr = MAX(MAX_REV_NBR), @max_seq_nbr = MAX(SEQ_NBR) FROM INTERNET_DETAIL A 
		JOIN (
			SELECT [ORDER_NBR], [LINE_NBR], MAX([REV_NBR]) MAX_REV_NBR
			FROM [dbo].[INTERNET_DETAIL] A
			WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
			GROUP BY A.[ORDER_NBR], A.[LINE_NBR]  ) B
		ON 	A.[ORDER_NBR] = B.[ORDER_NBR] AND A.[LINE_NBR] = B.[LINE_NBR]
		WHERE [REV_NBR] = MAX_REV_NBR	
	END
	ELSE 	IF @order_type = 'OD' BEGIN	
		SELECT @max_rev_nbr = MAX(MAX_REV_NBR), @max_seq_nbr = MAX(SEQ_NBR) FROM OUTDOOR_DETAIL A 
		JOIN (
			SELECT [ORDER_NBR], [LINE_NBR], MAX([REV_NBR]) MAX_REV_NBR
			FROM [dbo].[OUTDOOR_DETAIL] A
			WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
			GROUP BY A.[ORDER_NBR], A.[LINE_NBR]  ) B
		ON 	A.[ORDER_NBR] = B.[ORDER_NBR] AND A.[LINE_NBR] = B.[LINE_NBR]
		WHERE [REV_NBR] = MAX_REV_NBR	
	END
	ELSE 	IF @order_type = 'RA' BEGIN	
		SELECT @max_rev_nbr = MAX(MAX_REV_NBR), @max_seq_nbr = MAX(SEQ_NBR) FROM RADIO_DETAIL A 
		JOIN (
			SELECT [ORDER_NBR], [LINE_NBR], MAX([REV_NBR]) MAX_REV_NBR
			FROM [dbo].[RADIO_DETAIL] A
			WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
			GROUP BY A.[ORDER_NBR], A.[LINE_NBR]  ) B
		ON 	A.[ORDER_NBR] = B.[ORDER_NBR] AND A.[LINE_NBR] = B.[LINE_NBR]
		WHERE [REV_NBR] = MAX_REV_NBR	
	END
	ELSE 	IF @order_type = 'TV' BEGIN	
		SELECT @max_rev_nbr = MAX(MAX_REV_NBR), @max_seq_nbr = MAX(SEQ_NBR) FROM TV_DETAIL A 
		JOIN (
			SELECT [ORDER_NBR], [LINE_NBR], MAX([REV_NBR]) MAX_REV_NBR
			FROM [dbo].[TV_DETAIL] A
			WHERE [ORDER_NBR] =  @order_nbr AND [LINE_NBR] = @line_nbr
			GROUP BY A.[ORDER_NBR], A.[LINE_NBR]  ) B
		ON 	A.[ORDER_NBR] = B.[ORDER_NBR] AND A.[LINE_NBR] = B.[LINE_NBR]
		WHERE [REV_NBR] = MAX_REV_NBR	
	END			
	
	SELECT @max_rev_nbr = COALESCE(@max_rev_nbr, 0)
	SELECT @max_seq_nbr = COALESCE(@max_seq_nbr, 0)
	
	SELECT @offset_rev_nbr = @max_rev_nbr, @offset_seq_nbr = @max_seq_nbr + 1
	SELECT @onset_rev_nbr = @max_rev_nbr + 1, @onset_seq_nbr = 0
		
	INSERT INTO @med_max_rev_seq
	VALUES (@max_rev_nbr, @max_seq_nbr, @offset_rev_nbr, @offset_seq_nbr, @onset_rev_nbr, @onset_seq_nbr, @order_type)

RETURN
END

GO


