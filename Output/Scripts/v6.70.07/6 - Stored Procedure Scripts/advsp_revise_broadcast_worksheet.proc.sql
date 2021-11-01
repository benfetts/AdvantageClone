IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_revise_broadcast_worksheet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_revise_broadcast_worksheet]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_revise_broadcast_worksheet] 
	@user_id varchar(100), 
	@action varchar(10), 

	@order_nbr int,
	@line_nbr smallint,

	@order_type varchar(1),

	@default_rate decimal (16, 4),
	@programming varchar (50),
	@remarks varchar (254),
	@daypart_id int,
	@length int,

	@netcharge decimal (15, 2),
	@addl_charge decimal (15, 2),

	@date1 smalldatetime,
	@date2 smalldatetime,
	@date3 smalldatetime,
	@date4 smalldatetime,
	@date5 smalldatetime,
	@date6 smalldatetime,
	@date7 smalldatetime,

	@spots1 int,
	@spots2 int,
	@spots3 int,
	@spots4 int,
	@spots5 int,
	@spots6 int,
	@spots7 int,
	
	@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

/*
PJH 09/12/17 - Created [advsp_revise_broadcast_worksheet]


*/

SET NOCOUNT ON

DECLARE @error_msg_w varchar(200)
DECLARE @date_time_w smalldatetime

DECLARE @DEBUG int
DECLARE @RC int, @RC_MSG varchar(max)

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int

BEGIN TRY

	IF @action = 'DEBUG'
		SET @DEBUG = 1
	ELSE
		SET @DEBUG = 0

	SELECT @date_time_w=GETDATE()

	SET @ret_val = 0

	/** Update Worksheet **/
	/* PJH 10/17/17 - Do not update the detail level data - It relates to multiple Order/Lines in orders */

	--UPDATE A 
	--	SET A.DEFAULT_RATE = @default_rate,
	--	PROGRAM = @programming, 
	--	COMMENTS = @remarks, 
	--	DAY_PART_ID = @daypart_id, 
	--	[LENGTH] = @length
	--FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL A
	--JOIN (
	--		SELECT DISTINCT MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
	--		FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE
	--		WHERE ORDER_NBR = @order_nbr AND ORDER_LINE_NBR = @line_nbr
	--		) B
	--ON A.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = B.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID

	IF (@date1) IS NOT NULL
		UPDATE A 
		SET A.SPOTS = COALESCE(@spots1, 0)
		FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A
		WHERE ORDER_NBR = @order_nbr AND ORDER_LINE_NBR = @line_nbr AND [DATE] = @date1
	IF (@date2) IS NOT NULL
		UPDATE A 
		SET A.SPOTS = COALESCE(@spots2, 0)
		FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A
		WHERE ORDER_NBR = @order_nbr AND ORDER_LINE_NBR = @line_nbr AND [DATE] = @date2
	IF (@date3) IS NOT NULL
		UPDATE A 
		SET A.SPOTS = COALESCE(@spots3, 0)
		FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A
		WHERE ORDER_NBR = @order_nbr AND ORDER_LINE_NBR = @line_nbr AND [DATE] = @date3
	IF (@date4) IS NOT NULL
		UPDATE A 
		SET A.SPOTS = COALESCE(@spots4, 0)
		FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A
		WHERE ORDER_NBR = @order_nbr AND ORDER_LINE_NBR = @line_nbr AND [DATE] = @date4
	IF (@date5) IS NOT NULL
		UPDATE A 
		SET A.SPOTS = COALESCE(@spots5, 0)
		FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A
		WHERE ORDER_NBR = @order_nbr AND ORDER_LINE_NBR = @line_nbr AND [DATE] = @date5
	IF (@date6) IS NOT NULL
		UPDATE A 
		SET A.SPOTS = COALESCE(@spots6, 0)
		FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A
		WHERE ORDER_NBR = @order_nbr AND ORDER_LINE_NBR = @line_nbr AND [DATE] = @date6
	IF (@date7) IS NOT NULL
		UPDATE A 
		SET A.SPOTS = COALESCE(@spots7, 0)
		FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE A
		WHERE ORDER_NBR = @order_nbr AND ORDER_LINE_NBR = @line_nbr AND [DATE] = @date7

	IF @@TRANCOUNT > 0
		IF @DEBUG = 1 BEGIN
			SELECT 'DEBUG'  'DESC', @order_nbr '@order_nbr', @line_nbr '@line_nbr', @user_id '@user_id', @date_time_w '@date_time_w'

			SELECT DEFAULT_RATE, PROGRAM, COMMENTS, DAY_PART_ID, [LENGTH], * 
			FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL A
			JOIN (
					SELECT DISTINCT MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
					FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE
					WHERE ORDER_NBR = @order_nbr AND ORDER_LINE_NBR = @line_nbr
					) B
			ON A.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = B.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID

			SELECT '-' '-', * FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE
					WHERE ORDER_NBR = @order_nbr AND ORDER_LINE_NBR = @line_nbr
			
			IF @order_type = 'T'
				SELECT * FROM TV_DETAIL 
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr
			ELSE
				SELECT * FROM RADIO_DETAIL 
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr

			SET @error_msg_w = 'DEBUG - ROLLBACK'
			GOTO ERROR_MSG
		END

	GOTO ENDIT		   
           
	/**************************** ERROR PROCESSING ***************************/	
	ERROR_MSG:
		BEGIN

			SET @ret_val = -1
			
			RAISERROR (@error_msg_w,
				16,
				1 )    
			
		END

	ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH

	IF @@TRANCOUNT > 0 BEGIN
		SELECT 'PROCESS ERROR ROLLBACK', @@TRANCOUNT '@@TRANCOUNT'  /* DEBUG */	
	END
	
	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();
	
	SELECT 	@ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'  /* DEBUG */	
	
	IF @ret_val IS NULL BEGIN
		SET @ret_val = @ErState
		SET @ret_val_s = @ErMessage
	END	

END CATCH

RETURN

           
/*
advsp_revise_broadcast_worksheet(
	user_id, 
	action, 
	order_nbr, 
	line_nbr, 
	order_type, 
	default_rate, 
	programming, 
	remarks, 
	daypart_id, 
	length, 
	net_charge,  
	addl_charge, 
	date1, date2, date3, date4, 
	date5, date6, date7, 
	date1, spots2, spots3, spots4, 
	spots5, spots6, spots7, 
	ret_val, ret_val_s
)
*/