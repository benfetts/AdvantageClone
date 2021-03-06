
CREATE PROCEDURE [dbo].[usp_wv_BA_APPROVAL_INSERT] 
	@BA_BATCH_ID AS INT,
	@CREATE_USER AS VARCHAR(100),
	--@CREATE_DATE AS SMALLDATETIME,
	@CL_CODE AS VARCHAR(6),
	@BA_CL_DESC AS VARCHAR(50),
	@BA_CL_DATE AS SMALLDATETIME,
	@SENT_DATE AS SMALLDATETIME,
	@APPR_DATE AS SMALLDATETIME,
	@CLIENT_PO AS VARCHAR(40),
	@CDP_CONTACT_ID AS INT

AS

		DECLARE
			@THIS_BA_ID INT
			
		SELECT 
			@THIS_BA_ID = MAX(ISNULL(BA_ID,0))+1	
		FROM 
			BILL_APPR WITH(NOLOCK);
			
		IF @THIS_BA_ID IS NULL
		BEGIN
			SET @THIS_BA_ID = 1;
		END
		
		--IF (@BA_CL_DESC IS NULL) OR (DATALENGTH(@BA_CL_DESC) = 0)
		--BEGIN
		--    SELECT @BA_CL_DESC = CL_NAME FROM CLIENT WHERE CL_CODE = @CL_CODE;
		--END
	
				
		INSERT INTO BILL_APPR WITH(ROWLOCK)
			(
				BA_ID,
				BA_BATCH_ID,
				CREATE_USER,
				CREATE_DATE
			)
		VALUES
			(
				@THIS_BA_ID, 
				@BA_BATCH_ID,
				@CREATE_USER,
				GETDATE()
			);
			
		INSERT INTO BILL_APPR_CL WITH(ROWLOCK)
			(
				BA_ID,
				CL_CODE,
				BA_CL_DESC,
				BA_CL_DATE,
				SENT_DATE,
				APPR_DATE,
				CLIENT_PO,
				CREATE_USER,
				CDP_CONTACT_ID
			)
		VALUES	
			(
				@THIS_BA_ID,
				@CL_CODE,
				@BA_CL_DESC,
				@BA_CL_DATE,
				@SENT_DATE,
				@APPR_DATE,
				@CLIENT_PO,
				@CREATE_USER,
				@CDP_CONTACT_ID
			);
			
		SELECT @THIS_BA_ID;	

