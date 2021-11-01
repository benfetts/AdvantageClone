IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_revise_order_brdcast_units_by_order]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_revise_order_brdcast_units_by_order]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_revise_order_brdcast_units_by_order] (
	@user_id varchar(100),
--	@media_type varchar(6),
	@order_nbr int,
	@line_nbr int = NULL,
	@error_msg_w varchar(1024) OUTPUT
)

AS
--ORDER_NBR, LINE_NBR, MAX(REV_NBR), 0, @media_type, NULL, NULL
DECLARE @detail_rows TABLE (
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [smallint] NOT NULL,
	[REV_NBR] [smallint] NOT NULL,
	[SEQ_NBR] [smallint] NOT NULL,
--	[MEDIA_TYPE] [varchar](6) NOT NULL,
	[UNIT_REV_NBR] [smallint] NULL,
	[UNIT_SEQ_NBR] [smallint] NULL
	
	UNIQUE 
	(	[ORDER_NBR],
		[LINE_NBR],
		[REV_NBR]
	)
)

DECLARE @unit_rows TABLE (
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [smallint] NOT NULL,
	[REV_NBR] [smallint] NOT NULL
--	[MEDIA_TYPE] [varchar](6) NOT NULL,
	
	UNIQUE 
	(	[ORDER_NBR],
		[LINE_NBR],
		[REV_NBR]
	)
)

DECLARE @tv_detail_units_revisions TABLE (
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [smallint] NOT NULL,
	[REV_NBR] [smallint] NOT NULL,
	[SEQ_NBR] [smallint] NOT NULL,
	[UNIT_NBR] [smallint] NOT NULL,
	[PRD_CODE] [varchar](6) NOT NULL,
	[UNIT_DATE] [smalldatetime] NOT NULL,
	[LINK_UNITID] [int] NULL,
	[UNITS] [int] NOT NULL, 
	UNIQUE 
	(	[ORDER_NBR] ASC,
		[LINE_NBR] ASC,
		[REV_NBR] ASC,
		[SEQ_NBR] ASC,
		[UNIT_NBR] ASC
	)
)

DECLARE @tv_detail_units_revisions_prior TABLE (
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [smallint] NOT NULL,
	[REV_NBR] [smallint] NOT NULL,
	[SEQ_NBR] [smallint] NOT NULL,
	[UNIT_NBR] [smallint] NOT NULL,
	[PRD_CODE] [varchar](6) NOT NULL,
	[UNIT_DATE] [smalldatetime] NOT NULL,
	[LINK_UNITID] [int] NULL,
	[UNITS] [int] NOT NULL, 
	UNIQUE 
	(	[ORDER_NBR] ASC,
		[LINE_NBR] ASC,
		[REV_NBR] ASC,
		[SEQ_NBR] ASC,
		[UNIT_NBR] ASC
	)
)

DECLARE @tv_detail_units TABLE (
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [smallint] NOT NULL,
	[REV_NBR] [smallint] NOT NULL,
	[SEQ_NBR] [smallint] NOT NULL,
	[UNIT_NBR] [smallint] NOT NULL,
	[PRD_CODE] [varchar](6) NOT NULL,
	[UNIT_DATE] [smalldatetime] NOT NULL,
	[LINK_ID] [int] NULL,
	[LINK_UNITID] [int] NULL,
	[UNITS] [int] NOT NULL, 
	UNIQUE 
	(	[ORDER_NBR] ASC,
		[LINE_NBR] ASC,
		[REV_NBR] ASC,
		[SEQ_NBR] ASC,
		[UNIT_NBR] ASC
	)
)

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int

BEGIN TRY

/* TV_DETAIL - Get max revision per line */
INSERT INTO @detail_rows
SELECT ORDER_NBR, LINE_NBR, MAX(REV_NBR), 0, NULL, NULL
FROM TV_DETAIL WHERE ORDER_NBR = @order_nbr AND ACTIVE_REV = 1 AND (LINE_NBR = @line_nbr or @line_nbr IS NULL)
GROUP BY ORDER_NBR, LINE_NBR

/* Current TV_DETAIL REV_NBR */
UPDATE TD
SET SEQ_NBR = (UD.SEQ_NBR)
FROM @detail_rows TD
INNER JOIN (SELECT (ORDER_NBR) ORDER_NBR, (LINE_NBR) LINE_NBR, (REV_NBR) REV_NBR, MAX(SEQ_NBR) SEQ_NBR FROM TV_DETAIL GROUP BY ORDER_NBR, LINE_NBR, REV_NBR) UD 
			ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR AND TD.REV_NBR = UD.REV_NBR

/* TV_DETAIL_UNITS - Get max revision per line */
INSERT INTO @unit_rows
SELECT ORDER_NBR, LINE_NBR, MAX(REV_NBR)
FROM TV_DETAIL_UNITS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr or @line_nbr IS NULL)
GROUP BY ORDER_NBR, LINE_NBR

IF @@ROWCOUNT = 0 BEGIN
	SET @error_msg_w = 'No matching unit rows.'
	RETURN
END



--SELECT '@detail_rows', '@detail_rows', * FROM @detail_rows
--SELECT '@unit_rows' '@unit_rows', * FROM @unit_rows



/* Delete the ones that exisit in both */
DELETE TD
FROM @detail_rows TD
INNER JOIN @unit_rows UD ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR AND TD.REV_NBR = UD.REV_NBR

/* Delete the ones that don't exist in unit detail */
DELETE TD
FROM @detail_rows TD
LEFT JOIN @unit_rows UD ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR 
WHERE UD.LINE_NBR IS NULL

/* Get the max revision for the associated unit rows */
UPDATE TD
SET UNIT_REV_NBR = UD.REV_NBR
FROM @detail_rows TD
INNER JOIN @unit_rows UD ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR

/* Use previous REV_NBR to get Max Seq */
UPDATE TD
SET UNIT_SEQ_NBR = (UD.SEQ_NBR)
FROM @detail_rows TD
INNER JOIN (SELECT (ORDER_NBR) ORDER_NBR, (LINE_NBR) LINE_NBR, (REV_NBR) REV_NBR, MAX(SEQ_NBR) SEQ_NBR FROM TV_DETAIL GROUP BY ORDER_NBR, LINE_NBR, REV_NBR) UD 
			ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR AND TD.UNIT_REV_NBR = UD.REV_NBR

/* Reverse current REV units */

INSERT INTO @tv_detail_units 
	(ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, UNIT_NBR, PRD_CODE, UNIT_DATE, LINK_ID, LINK_UNITID, UNITS)
SELECT UD.ORDER_NBR
    ,UD.LINE_NBR
    ,UD.REV_NBR
    ,TD.UNIT_SEQ_NBR
    ,UNIT_NBR
    ,UD.PRD_CODE
    ,UNIT_DATE
	,LINK_ID
    ,LINK_UNITID
    ,UD.UNITS * -1 AS UNITS	--REVERSAL
FROM TV_DETAIL_UNITS UD
JOIN TV_HDR H ON UD.ORDER_NBR = H.ORDER_NBR
JOIN @detail_rows TD ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR AND UD.REV_NBR = TD.UNIT_REV_NBR
UNION
/* Insert copy of current REV to TV_DETAIL Max(REV_NBR) */
SELECT UD.ORDER_NBR
    ,UD.LINE_NBR
    ,TD.REV_NBR /* TV_DETAIL Max(REV_NBR) */
    ,TD.SEQ_NBR
    ,UNIT_NBR
    ,UD.PRD_CODE
    ,UNIT_DATE
	,LINK_ID
    ,LINK_UNITID
    ,UD.UNITS				--NEW
FROM TV_DETAIL_UNITS UD
JOIN TV_HDR H ON UD.ORDER_NBR = H.ORDER_NBR
JOIN @detail_rows TD ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR AND UD.REV_NBR = TD.UNIT_REV_NBR

SELECT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, UNIT_NBR, PRD_CODE, UNIT_DATE, LINK_UNITID, UNITS --LINK_ID
FROM @tv_detail_units

INSERT INTO TV_DETAIL_UNITS (ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, UNIT_NBR, PRD_CODE, UNIT_DATE, LINK_UNITID, UNITS)
SELECT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, UNIT_NBR, PRD_CODE, UNIT_DATE, LINK_UNITID, UNITS
FROM @tv_detail_units

GOTO ENDIT
  
           
/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();

	IF @ErMessage IS NOT NULL BEGIN
		--SET @ret_val = 1
		SET @error_msg_w = @ErMessage
	END

END CATCH
	
GO

GRANT EXECUTE ON [advsp_revise_order_brdcast_units_by_order] TO PUBLIC
GO