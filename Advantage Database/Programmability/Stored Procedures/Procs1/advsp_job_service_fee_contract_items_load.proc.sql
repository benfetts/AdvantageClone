CREATE PROCEDURE [dbo].[advsp_job_service_fee_contract_items_load]
	@JOB_SERVICE_FEE_ID INT,
	@GENERATE_MISSING BIT
AS
BEGIN

	DECLARE @REQUIRED_DATES TABLE(REQUIRED_DATE DATETIME)
	DECLARE @FREQUENCY SMALLINT
	DECLARE @START_DATE DATETIME
	DECLARE @END_DATE DATETIME
	DECLARE @NUMBER_OF_DAYS SMALLINT
	DECLARE @NUMBER_OF_FEES INT
	DECLARE @FEE_AMOUNT DECIMAL(14,2)
	DECLARE @FEE_COUNTER INT
	DECLARE @JOB_NUMBER INT
	DECLARE @JOB_COMPONENT_NBR INT
	DECLARE @REFERENCE_PREFIX VARCHAR(18)
	DECLARE @FEE_DESCRIPTION VARCHAR(100)

	IF @GENERATE_MISSING = 1
	BEGIN
	
		SELECT 
			@FEE_DESCRIPTION = JOB_SERVICE_FEE.FEE_DESCRIPTION,
			@FREQUENCY = JOB_SERVICE_FEE.FREQUENCY,
			@START_DATE = JOB_SERVICE_FEE.FEE_START_DATE,
			@END_DATE = JOB_SERVICE_FEE.FEE_END_DATE,
			@JOB_NUMBER = JOB_SERVICE_FEE.JOB_NUMBER,
			@JOB_COMPONENT_NBR = JOB_SERVICE_FEE.JOB_COMPONENT_NBR,
			@FEE_AMOUNT = JOB_SERVICE_FEE.FEE_AMT
		FROM 
			dbo.JOB_SERVICE_FEE 
		WHERE 
			JOB_SERVICE_FEE_ID = @JOB_SERVICE_FEE_ID
			
		--SET @REFERENCE_PREFIX = REPLACE(STR(@JOB_SERVICE_FEE_ID, 6), SPACE(1), '0') + '-' + REPLACE(STR(@JOB_NUMBER, 6), SPACE(1), '0') + '-' + REPLACE(STR(@JOB_COMPONENT_NBR, 3), SPACE(1), '0') + '-'
		SET @REFERENCE_PREFIX = REPLACE(STR(@JOB_NUMBER, 6), SPACE(1), '0') + '-' + REPLACE(STR(@JOB_COMPONENT_NBR, 3), SPACE(1), '0') + '-'

		IF @FREQUENCY = 1 -- Weekly
			SET @NUMBER_OF_DAYS = 7

		IF @FREQUENCY = 2 -- Monthly
			SET @NUMBER_OF_DAYS = 30

		IF @FREQUENCY = 3 -- Yearly
			SET @NUMBER_OF_DAYS = 365

		IF @NUMBER_OF_DAYS > 0
			SET @NUMBER_OF_FEES = CONVERT(INT, ROUND(CONVERT(DECIMAL(10,2), DATEDIFF(DAY, @START_DATE, @END_DATE)) / @NUMBER_OF_DAYS, 0))
		
		SET @FEE_COUNTER = 0

		WHILE @FEE_COUNTER < @NUMBER_OF_FEES
		BEGIN

			IF @FREQUENCY = 1 -- Weekly
				INSERT INTO @REQUIRED_DATES VALUES (DATEADD(WEEK, @FEE_COUNTER, @START_DATE))

			IF @FREQUENCY = 2 -- Monthly
				INSERT INTO @REQUIRED_DATES VALUES (DATEADD(MONTH, @FEE_COUNTER, @START_DATE))

			IF @FREQUENCY = 3 -- Yearly
				INSERT INTO @REQUIRED_DATES VALUES (DATEADD(YEAR, @FEE_COUNTER, @START_DATE))

			SET @FEE_COUNTER = @FEE_COUNTER + 1

		END

		SELECT 
			[JobServiceFeeContractID] = @JOB_SERVICE_FEE_ID,
			[IncomeOnlyReference] = CASE WHEN IO_EXISTS.IO_INV_NBR IS NOT NULL THEN IO_EXISTS.IO_INV_NBR ELSE @REFERENCE_PREFIX + CONVERT(VARCHAR(8), REQUIRED_DATES.REQUIRED_DATE, 112) END,
			[InvoiceDate] = CASE WHEN REQUIRED_DATES.REQUIRED_DATE IS NOT NULL THEN REQUIRED_DATES.REQUIRED_DATE ELSE IO_EXISTS.IO_INV_DATE END,
			[Amount] = CASE WHEN IO_EXISTS.IO_AMOUNT IS NOT NULL THEN IO_EXISTS.IO_AMOUNT ELSE @FEE_AMOUNT END,
			[Description] = CASE WHEN IO_EXISTS.IO_DESC IS NOT NULL THEN IO_EXISTS.IO_DESC ELSE @FEE_DESCRIPTION END,
			[IncomeOnlyID] = IO_EXISTS.IO_ID,
			[IncomeOnlySequenceNumber] = IO_EXISTS.SEQ_NBR,
			[Created] = CONVERT(BIT, CASE WHEN IO_EXISTS.IO_ID IS NOT NULL THEN 1 ELSE 0 END)
		FROM
			@REQUIRED_DATES REQUIRED_DATES FULL OUTER JOIN
			(SELECT
	 			INCOME_ONLY.IO_ID,
	 			INCOME_ONLY.SEQ_NBR,
	 			INCOME_ONLY.IO_INV_NBR,
	 			INCOME_ONLY.IO_DESC,
	 			INCOME_ONLY.IO_AMOUNT,
				INCOME_ONLY.IO_INV_DATE
			 FROM
	 			dbo.INCOME_ONLY JOIN
	 			(SELECT
	 				[IO_ID] = INCOME_ONLY.IO_ID,
	 				[SEQ_NBR] = MAX(INCOME_ONLY.SEQ_NBR)
	 			 FROM
	 				dbo.INCOME_ONLY
	 			 GROUP BY 
	 				IO_ID) IOMAX ON INCOME_ONLY.IO_ID = IOMAX.IO_ID AND
	 								INCOME_ONLY.SEQ_NBR = IOMAX.SEQ_NBR
			 WHERE
	 			INCOME_ONLY.JOB_SERVICE_FEE_ID = @JOB_SERVICE_FEE_ID AND
	 			INCOME_ONLY.FEE_INVOICE = 1 AND
				ISNULL(INCOME_ONLY.DELETE_FLAG, 0) = 0) IO_EXISTS ON REQUIRED_DATES.REQUIRED_DATE = IO_EXISTS.IO_INV_DATE
		ORDER BY
			[Created] ASC,
			[InvoiceDate] ASC

	END
	ELSE
	BEGIN

		SELECT 
			[JobServiceFeeContractID] = @JOB_SERVICE_FEE_ID, 
			[IncomeOnlyReference] = INCOME_ONLY.IO_INV_NBR,
			[InvoiceDate] = INCOME_ONLY.IO_INV_DATE,
			[Amount] = INCOME_ONLY.IO_AMOUNT,
			[Description] = INCOME_ONLY.IO_DESC,
			[IncomeOnlyID] = INCOME_ONLY.IO_ID,
			[IncomeOnlySequenceNumber] = INCOME_ONLY.SEQ_NBR,
			[Created] = CONVERT(BIT, 1)
		FROM
			dbo.INCOME_ONLY JOIN
			(SELECT 
				[IO_ID] = INCOME_ONLY.IO_ID,
				[SEQ_NBR] = MAX(INCOME_ONLY.SEQ_NBR)
			 FROM 
				dbo.INCOME_ONLY 
			 GROUP BY 
				INCOME_ONLY.IO_ID) IOMAX ON INCOME_ONLY.IO_ID = IOMAX.IO_ID AND
											INCOME_ONLY.SEQ_NBR = IOMAX.SEQ_NBR
		WHERE
			INCOME_ONLY.JOB_SERVICE_FEE_ID = @JOB_SERVICE_FEE_ID AND
			ISNULL(INCOME_ONLY.DELETE_FLAG, 0) = 0
		ORDER BY
			[Created] ASC,
			[InvoiceDate] ASC

	END

END