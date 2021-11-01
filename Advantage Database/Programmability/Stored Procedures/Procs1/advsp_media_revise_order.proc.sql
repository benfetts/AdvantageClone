
/** COMMENT FOR STAND_ALONE TESTING **/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advsp_media_revise_order]' ) AND OBJECTPROPERTY( id, N'IsProcedure' ) = 1 )
	DROP PROCEDURE [dbo].[advsp_media_revise_order]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_media_revise_order] @table varchar(20), @order_nbr integer, @ret_val integer OUTPUT
AS
/** COMMENT FOR STAND_ALONE TESTING - End **/

	/** COMMENT FOR SP **/
	--DECLARE @table varchar(20), @order_nbr integer, @ret_val integer
	--SELECT @table = 'TV', @order_nbr = 269433
	/** COMMENT FOR SP - End **/

	--PJH 03/10/19 - Do not update TV_DETAIL_UNITS here
	--PJH 04/18/19 - Only TV - Update TV_DETAIL_UNITS to latest REV/SEQ

	DECLARE @ll_cnt int, @ll_max_rev int, @ll_max_seq int, @ll_invalid_rev_cnt int
	DECLARE @ROW_ID int, @ROW_COUNT int, @ll_line_nbr int, @active_tran int

	DECLARE @act_rev_select_lines TABLE([RowID] [int] IDENTITY(1,1), 
						 [ORDER_NBR] int NOT NULL,
						 [LINE_NBR] int NOT NULL )
						 
	--SELECT @ll_invalid_rev_cnt = COUNT(CNT) FROM (
	--	SELECT 1 CNT FROM TV_DETAIL 
	--	WHERE ORDER_NBR = @order_nbr 
	--	GROUP BY LINE_NBR
	--	HAVING COUNT(ACTIVE_REV) <> 1) T
		
	SET @ret_val = 0
						 
	--IF @ll_invalid_rev_cnt = 0 GOTO ENDIT

	IF @table = 'NEWSPAPER' BEGIN
		INSERT INTO @act_rev_select_lines
		SELECT DISTINCT ORDER_NBR, LINE_NBR FROM NEWSPAPER_DETAIL A WHERE ORDER_NBR = @order_nbr END
	ELSE IF @table = 'MAGAZINE' BEGIN
		INSERT INTO @act_rev_select_lines
		SELECT DISTINCT ORDER_NBR, LINE_NBR FROM MAGAZINE_DETAIL A WHERE ORDER_NBR = @order_nbr END
	ELSE IF @table = 'OUTDOOR' BEGIN
		INSERT INTO @act_rev_select_lines
		SELECT DISTINCT ORDER_NBR, LINE_NBR FROM OUTDOOR_DETAIL A WHERE ORDER_NBR = @order_nbr END
	ELSE IF @table = 'INTERNET' BEGIN
		INSERT INTO @act_rev_select_lines
		SELECT DISTINCT ORDER_NBR, LINE_NBR FROM INTERNET_DETAIL A WHERE ORDER_NBR = @order_nbr END
	ELSE IF @table = 'RADIO' BEGIN
		INSERT INTO @act_rev_select_lines
		SELECT DISTINCT ORDER_NBR, LINE_NBR FROM RADIO_DETAIL A WHERE ORDER_NBR = @order_nbr END
	ELSE IF @table = 'TV' BEGIN
		INSERT INTO @act_rev_select_lines
		SELECT DISTINCT ORDER_NBR, LINE_NBR FROM TV_DETAIL A WHERE ORDER_NBR = @order_nbr END
	ELSE BEGIN
		SET @ret_val = -1
		GOTO ERRMSG
	END 	

	SET @ROW_COUNT = @@ROWCOUNT
	
	--SELECT @ROW_COUNT

	SET @ROW_ID = 1

	SET NOCOUNT ON 
	  
	WHILE @ROW_ID <= @ROW_COUNT 
	BEGIN

		BEGIN TRAN T1	
		SET @active_tran = 1
		
		SELECT @ll_line_nbr = LINE_NBR
		FROM @act_rev_select_lines
		WHERE RowID = @ROW_ID
			
		--SELECT @order_nbr, @ll_line_nbr,	@ll_max_rev, 	@ll_max_seq

		IF @table = 'NEWSPAPER' BEGIN

				SELECT @ll_max_rev =  REV_NBR, @ll_max_seq = SEQ_NBR 
				FROM NEWSPAPER_DETAIL A 	
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
				AND REV_NBR = ( 
					SELECT MAX(REV_NBR) FROM NEWSPAPER_DETAIL B 
					WHERE A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR) 
				AND SEQ_NBR = ( 
					SELECT MAX(SEQ_NBR) FROM NEWSPAPER_DETAIL C 
					WHERE A.ORDER_NBR = C.ORDER_NBR AND A.LINE_NBR = C.LINE_NBR 
					AND REV_NBR = ( 
						SELECT MAX(REV_NBR) FROM NEWSPAPER_DETAIL D 
						WHERE A.ORDER_NBR = D.ORDER_NBR AND A.LINE_NBR = D.LINE_NBR)) ;						
			
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
								
				UPDATE NEWSPAPER_DETAIL 
				SET ACTIVE_REV = NULL
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR <> @ll_max_rev OR SEQ_NBR <> @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
				
				UPDATE NEWSPAPER_DETAIL 
				SET ACTIVE_REV = 1
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR = @ll_max_rev AND SEQ_NBR = @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 	
		 END
		ELSE IF @table = 'MAGAZINE' BEGIN

				SELECT @ll_max_rev =  REV_NBR, @ll_max_seq = SEQ_NBR 
				FROM MAGAZINE_DETAIL A 	
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
				AND REV_NBR = ( 
					SELECT MAX(REV_NBR) FROM MAGAZINE_DETAIL B 
					WHERE A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR) 
				AND SEQ_NBR = ( 
					SELECT MAX(SEQ_NBR) FROM MAGAZINE_DETAIL C 
					WHERE A.ORDER_NBR = C.ORDER_NBR AND A.LINE_NBR = C.LINE_NBR 
					AND REV_NBR = ( 
						SELECT MAX(REV_NBR) FROM MAGAZINE_DETAIL D 
						WHERE A.ORDER_NBR = D.ORDER_NBR AND A.LINE_NBR = D.LINE_NBR)) ;						
			
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
								
				UPDATE MAGAZINE_DETAIL 
				SET ACTIVE_REV = NULL
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR <> @ll_max_rev OR SEQ_NBR <> @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
				
				UPDATE MAGAZINE_DETAIL 
				SET ACTIVE_REV = 1
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR = @ll_max_rev AND SEQ_NBR = @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
		 END
		ELSE IF @table = 'OUTDOOR' BEGIN

				SELECT @ll_max_rev =  REV_NBR, @ll_max_seq = SEQ_NBR 
				FROM OUTDOOR_DETAIL A 	
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
				AND REV_NBR = ( 
					SELECT MAX(REV_NBR) FROM OUTDOOR_DETAIL B 
					WHERE A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR) 
				AND SEQ_NBR = ( 
					SELECT MAX(SEQ_NBR) FROM OUTDOOR_DETAIL C 
					WHERE A.ORDER_NBR = C.ORDER_NBR AND A.LINE_NBR = C.LINE_NBR 
					AND REV_NBR = ( 
						SELECT MAX(REV_NBR) FROM OUTDOOR_DETAIL D 
						WHERE A.ORDER_NBR = D.ORDER_NBR AND A.LINE_NBR = D.LINE_NBR)) ;						
			
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
								
				UPDATE OUTDOOR_DETAIL 
				SET ACTIVE_REV = NULL
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR <> @ll_max_rev OR SEQ_NBR <> @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
				
				UPDATE OUTDOOR_DETAIL 
				SET ACTIVE_REV = 1
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR = @ll_max_rev AND SEQ_NBR = @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
		 END
		ELSE IF @table = 'INTERNET' BEGIN

				SELECT @ll_max_rev =  REV_NBR, @ll_max_seq = SEQ_NBR 
				FROM INTERNET_DETAIL A 	
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
				AND REV_NBR = ( 
					SELECT MAX(REV_NBR) FROM INTERNET_DETAIL B 
					WHERE A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR) 
				AND SEQ_NBR = ( 
					SELECT MAX(SEQ_NBR) FROM INTERNET_DETAIL C 
					WHERE A.ORDER_NBR = C.ORDER_NBR AND A.LINE_NBR = C.LINE_NBR 
					AND REV_NBR = ( 
						SELECT MAX(REV_NBR) FROM INTERNET_DETAIL D 
						WHERE A.ORDER_NBR = D.ORDER_NBR AND A.LINE_NBR = D.LINE_NBR)) ;						
			
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
								
				UPDATE INTERNET_DETAIL 
				SET ACTIVE_REV = NULL
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR <> @ll_max_rev OR SEQ_NBR <> @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
				
				UPDATE INTERNET_DETAIL 
				SET ACTIVE_REV = 1
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR = @ll_max_rev AND SEQ_NBR = @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 	
		 END
		ELSE IF @table = 'RADIO' BEGIN 

				SELECT @ll_max_rev =  REV_NBR, @ll_max_seq = SEQ_NBR 
				FROM RADIO_DETAIL A 	
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
				AND REV_NBR = ( 
					SELECT MAX(REV_NBR) FROM RADIO_DETAIL B 
					WHERE A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR) 
				AND SEQ_NBR = ( 
					SELECT MAX(SEQ_NBR) FROM RADIO_DETAIL C 
					WHERE A.ORDER_NBR = C.ORDER_NBR AND A.LINE_NBR = C.LINE_NBR 
					AND REV_NBR = ( 
						SELECT MAX(REV_NBR) FROM RADIO_DETAIL D 
						WHERE A.ORDER_NBR = D.ORDER_NBR AND A.LINE_NBR = D.LINE_NBR)) ;						
			
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
								
				UPDATE RADIO_DETAIL 
				SET ACTIVE_REV = NULL
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR <> @ll_max_rev OR SEQ_NBR <> @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
				
				UPDATE RADIO_DETAIL 
				SET ACTIVE_REV = 1
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR = @ll_max_rev AND SEQ_NBR = @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 		
		 END
		ELSE IF @table = 'TV' BEGIN 

				SELECT @ll_max_rev =  REV_NBR, @ll_max_seq = SEQ_NBR 
				FROM TV_DETAIL A 	
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
				AND REV_NBR = ( 
					SELECT MAX(REV_NBR) FROM TV_DETAIL B 
					WHERE A.ORDER_NBR = B.ORDER_NBR AND A.LINE_NBR = B.LINE_NBR) 
				AND SEQ_NBR = ( 
					SELECT MAX(SEQ_NBR) FROM TV_DETAIL C 
					WHERE A.ORDER_NBR = C.ORDER_NBR AND A.LINE_NBR = C.LINE_NBR 
					AND REV_NBR = ( 
						SELECT MAX(REV_NBR) FROM TV_DETAIL D 
						WHERE A.ORDER_NBR = D.ORDER_NBR AND A.LINE_NBR = D.LINE_NBR)) ;		
						
				--SELECT @order_nbr, @ll_line_nbr,	@ll_max_rev, 	@ll_max_seq
			
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
								
				UPDATE TV_DETAIL 
				SET ACTIVE_REV = NULL
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR <> @ll_max_rev OR SEQ_NBR <> @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
				
				UPDATE TV_DETAIL 
				SET ACTIVE_REV = 1
				WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr
					AND (REV_NBR = @ll_max_rev AND SEQ_NBR = @ll_max_seq);
					
				IF @@ERROR <> 0 BEGIN 
					SET @ret_val = @@ERROR
					GOTO ERRMSG
				END 
				
				--PJH 03/10/19 - Do not update TV_DETAIL_UNITS here
				--PJH 07/24/14 - Verify/Update Units			
				--UPDATE TV_DETAIL_UNITS with current max REV & SEQ (Line updates but no Unit updates)
				--UPDATE TV_DETAIL_UNITS
				--SET REV_NBR = @ll_max_rev, SEQ_NBR = @ll_max_seq
				--WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @ll_line_nbr;	
				
				--IF @@ERROR <> 0 BEGIN 
				--	SET @ret_val = @@ERROR
				--	GOTO ERRMSG
				--END
		 END
		ELSE BEGIN
			GOTO ERRMSG
		END
		SET @ROW_ID = @ROW_ID + 1
		COMMIT TRAN T1 	
		SET @active_tran = 0
	END	

	DECLARE @error_msg_u varchar(200), @user_id varchar(100)

	/* PJH 04/18/19 - Only TV - Update TV_DETAIL_UNITS to latest REV/SEQ */
	IF @table = 'TV' BEGIN
		/* Update legacy TV units */
		EXEC [advsp_revise_order_brdcast_units_by_order]
			@user_id ,
			@order_nbr ,
			NULL,
			@error_msg_u OUTPUT

		IF COALESCE(@error_msg_u, '') > '' BEGIN
			GOTO ERRMSG
		END
	END

GOTO ENDIT

ERRMSG:
	IF @active_tran = 1 ROLLBACK TRAN T1
	
ENDIT:

--IF @ll_invalid_rev_cnt > 0 SELECT @ll_invalid_rev_cnt 'LINES PROCESSED'
--ELSE SELECT 'NO LINES TO FIX' 'RESULT'

/** END SP **/

GO

GRANT EXECUTE ON [advsp_media_revise_order] TO PUBLIC
GO
