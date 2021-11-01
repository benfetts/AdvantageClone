IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ts_Check_Edit_Status]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ts_Check_Edit_Status]
GO

CREATE PROCEDURE [dbo].[usp_wv_ts_Check_Edit_Status]
@ETID AS INT,
@ETDTLID AS INT
AS
BEGIN
	-- Init
	BEGIN
		DECLARE 
			@Edit AS INT
		SET @Edit = 0;
	END
	-- Determine if rows have been billed
	BEGIN
		SELECT @Edit = 1
		 WHERE EXISTS (SELECT etd.AR_INV_NBR  
					   FROM EMP_TIME_DTL etd WITH (NOLOCK)
					   WHERE etd.ET_ID = @ETID
							AND etd.ET_DTL_ID = @ETDTLID
							AND etd.AR_INV_NBR IS NOT NULL
							AND (etd.EDIT_FLAG = 0 OR etd.EDIT_FLAG IS NULL))
	END
	-- CHECK IF SUMMARIZED
	BEGIN
		DECLARE
			@SEQ_NBR SMALLINT,
			@SUMMARIZED_REC_COUNT INT
		SELECT @SUMMARIZED_REC_COUNT = COUNT(1)
		FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
		WHERE  etd.ET_ID = @ETID
				AND etd.ET_DTL_ID = @ETDTLID;
		IF @SUMMARIZED_REC_COUNT > 1
		BEGIN
			SELECT @SEQ_NBR = MAX(SEQ_NBR) 
			FROM EMP_TIME_DTL WITH(NOLOCK) 
			WHERE ET_ID = @ETID 
				AND ET_DTL_ID = @ETDTLID 
				AND (EDIT_FLAG = 0 OR EDIT_FLAG IS NULL);
			IF @SEQ_NBR IS NULL --HAS NO EDITABLE SUMMARY RECORD
			BEGIN
				SELECT @Edit = 2;
			END
		END
	END
	-- Determine if item is a restricted AB flag
	BEGIN
		SELECT @Edit = 3
		 WHERE  EXISTS (SELECT AB_FLAG
						FROM EMP_TIME_DTL etd WITH (NOLOCK)
						WHERE etd.ET_ID = @ETID
							AND etd.ET_DTL_ID = @ETDTLID
							AND etd.AB_FLAG IN (1,3))
	END
	-- Determine if item is selected for billing
	BEGIN
		SELECT @Edit = 4
		WHERE EXISTS (SELECT BILLING_USER
					  FROM EMP_TIME_DTL etd WITH (NOLOCK)
					  WHERE etd.ET_ID = @ETID
							AND etd.ET_DTL_ID = @ETDTLID
							AND BILLING_USER IS NOT NULL)
	END
	-- BJL - 11/23/03
	-- Check if row has been approved
	BEGIN
		SELECT @Edit = 6
		WHERE EXISTS (SELECT ET_ID
		  			   FROM EMP_TIME et WITH (NOLOCK)
		 			   WHERE et.ET_ID = @ETID
		   					AND APPR_FLAG = 1)
		   AND EXISTS ( SELECT * FROM AGENCY WHERE TIME_APPR_ACTIVE = 1)
	END
	-- BJL - 11/23/03
	-- Check if row is pending approval
	BEGIN
		SELECT @Edit = 5
		WHERE  EXISTS (SELECT ET_ID
		  			   FROM EMP_TIME et WITH (NOLOCK)
		 			   WHERE et.ET_ID = @ETID
		   					AND APPR_PENDING = 1 )
		   AND EXISTS (SELECT * FROM AGENCY WHERE TIME_APPR_ACTIVE = 1)
	END   
	-- JTG - 9/17/2009
	-- Check if row is denied approval
	BEGIN
		SELECT @Edit = 7
		WHERE  EXISTS (SELECT ET_ID
		  			   FROM EMP_TIME et WITH (NOLOCK)
		 			   WHERE et.ET_ID = @ETID
		   				   AND APPR_PENDING = 2 )
		   AND EXISTS (SELECT * FROM AGENCY WHERE TIME_APPR_ACTIVE = 1)
	END
	SELECT ISNULL(@Edit, 0) AS EditValue;
END