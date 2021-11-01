IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_revise_order_brdcast_units_by_order_void]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_revise_order_brdcast_units_by_order_void]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_revise_order_brdcast_units_by_order_void] (
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
	[TOTAL_SPOTS] [int] NOT NULL,
	[UNIT_FACTOR] [int],
	[UNIT_SEQ] [int]
	
	UNIQUE 
	(	[ORDER_NBR],
		[LINE_NBR],
		[REV_NBR],
		[SEQ_NBR]
	)
)

DECLARE @unit_rows TABLE (
	[ORDER_NBR] [int] NOT NULL,
	[LINE_NBR] [smallint] NOT NULL,
	[REV_NBR] [smallint] NOT NULL,
	[SEQ_NBR] [smallint] NOT NULL,
	[UNIT_NBR] [int] NOT NULL,
	[PRD_CODE] varchar(6) NOT NULL,
	[UNIT_DATE] smalldatetime NOT NULL,
	[LINK_UNITID] int NULL,
	[UNITS] [int] NOT NULL
	
	UNIQUE 
	(	[ORDER_NBR],
		[LINE_NBR],
		[REV_NBR],
		[SEQ_NBR],
		[UNIT_NBR],
		[UNITS]
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
		[UNIT_NBR] ASC,
		[PRD_CODE] ASC
	)
)

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int

BEGIN TRY

/* TV_DETAIL - Get all revisions per line */
INSERT INTO @detail_rows
SELECT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, COALESCE(TOTAL_SPOTS,0), NULL, NULL
FROM TV_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr or @line_nbr IS NULL) -- AND ACTIVE_REV = 1

/* Current TV_DETAIL UNIT_FACTOR (+/-) */
UPDATE TD
SET UNIT_FACTOR = CASE WHEN TOTAL_SPOTS < 0 THEN -1 ELSE 1 END
FROM @detail_rows TD

--SELECT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, UNIT_NBR, UNITS
--FROM TV_DETAIL_UNITS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr or @line_nbr IS NULL)

/* TV_DETAIL_UNITS - Get all revisions per line */
INSERT INTO @unit_rows
SELECT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, UNIT_NBR, PRD_CODE, UNIT_DATE, LINK_UNITID, UNITS
FROM TV_DETAIL_UNITS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr or @line_nbr IS NULL)

/* Current Unit max SEQ_NBR per line/rev */
UPDATE TD
SET UNIT_SEQ = (UD.SEQ_NBR)
FROM @detail_rows TD
INNER JOIN (SELECT (ORDER_NBR) ORDER_NBR, (LINE_NBR) LINE_NBR, (REV_NBR) REV_NBR, MAX(SEQ_NBR) SEQ_NBR FROM @unit_rows
			GROUP BY ORDER_NBR, LINE_NBR, REV_NBR) UD 
			ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR AND TD.REV_NBR = UD.REV_NBR

--IF @@ROWCOUNT = 0 BEGIN
--	SET @error_msg_w = 'No matching unit rows.'
--	RETURN
--END

/* Delete the ones that exisit in both */
DELETE TD
FROM @detail_rows TD
INNER JOIN @unit_rows UD ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR AND TD.REV_NBR = UD.REV_NBR			 AND TD.SEQ_NBR = UD.SEQ_NBR

/* Delete the detail rows that don't exist in unit detail - No unit split for the given line */
DELETE TD
FROM @detail_rows TD
LEFT JOIN @unit_rows UD ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR
WHERE UD.LINE_NBR IS NULL

--SELECT '@detail_rows' '@detail_rows', * FROM @detail_rows
--SELECT '@unit_rows' '@unit_rows', * FROM @unit_rows

/* Reverse current REV units */
INSERT INTO @tv_detail_units 
	(ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, UNIT_NBR, PRD_CODE, UNIT_DATE, LINK_ID, LINK_UNITID, UNITS)
SELECT TD.ORDER_NBR
    ,TD.LINE_NBR
    ,TD.REV_NBR
    ,TD.SEQ_NBR
    ,UD.UNIT_NBR
    ,UD.PRD_CODE
    ,UD.UNIT_DATE
	,H.LINK_ID
    ,UD.LINK_UNITID
    ,ABS(UD.UNITS) * TD.UNIT_FACTOR AS UNITS	--ALL VOIDED REVERSALS AND NEW
FROM @unit_rows UD
JOIN TV_HDR H ON UD.ORDER_NBR = H.ORDER_NBR
JOIN @detail_rows TD ON TD.ORDER_NBR = UD.ORDER_NBR AND TD.LINE_NBR = UD.LINE_NBR AND TD.REV_NBR = UD.REV_NBR AND TD.UNIT_SEQ = UD.SEQ_NBR

--SELECT '@tv_detail_units' 'SRC', *
--FROM @tv_detail_units

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

GRANT EXECUTE ON [advsp_revise_order_brdcast_units_by_order_void] TO PUBLIC
GO