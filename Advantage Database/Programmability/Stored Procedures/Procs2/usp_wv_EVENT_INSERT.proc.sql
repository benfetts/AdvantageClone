
CREATE PROCEDURE [dbo].[usp_wv_EVENT_INSERT] 
	@EVENT_LABEL AS VARCHAR(50),
	@EVENT_DESC_LONG AS TEXT,
	@TYPE AS VARCHAR(6),
	@EVENT_DATE AS SMALLDATETIME,
	@ALL_DAY AS BIT,
	@QTY_HRS AS DECIMAL(15,2),
	@START_TIME AS SMALLDATETIME,
	@END_TIME AS SMALLDATETIME,
	@RESOURCE_CODE AS VARCHAR(6),
	@JOB_NUMBER AS INT,
	@JOB_COMPONENT_NBR AS SMALLINT,
	@FNC_CODE AS VARCHAR(6),
	@AD_NUMBER AS VARCHAR(30),
	@EVENT_COMMENT AS TEXT,
	@INCOME_ONLY_ID AS INT,
	@EVENT_GEN_ID AS INT,
	@CREATE_DATE AS SMALLDATETIME,
	@CREATE_USER AS VARCHAR(100),
	@QTY_TYPE SMALLINT,
	@EVENT_TYPE_ID SMALLINT
AS

    DECLARE
        @THIS_EVENT_ID INT
        
    SET @THIS_EVENT_ID = 0;  
      
    INSERT INTO [EVENT] WITH(ROWLOCK)
    (
	    EVENT_LABEL,
	    EVENT_DESC_LONG,
	    [TYPE],
	    EVENT_DATE,
	    ALL_DAY,
	    QTY_HRS,
	    QTY_TYPE,
	    START_TIME,
	    END_TIME,
	    RESOURCE_CODE,
	    JOB_NUMBER,
	    JOB_COMPONENT_NBR,
	    FNC_CODE,
	    AD_NUMBER,
	    EVENT_COMMENT,
	    INCOME_ONLY_ID,
	    EVENT_GEN_ID,
	    CREATE_DATE,
	    CREATE_USER,
		EVENT_TYPE_ID
    )
    VALUES
    (
	    @EVENT_LABEL,
	    @EVENT_DESC_LONG,
	    @TYPE,
	    @EVENT_DATE,
	    @ALL_DAY,
	    @QTY_HRS,
	    @QTY_TYPE,
	    @START_TIME,
	    @END_TIME,
	    @RESOURCE_CODE,
	    @JOB_NUMBER,
	    @JOB_COMPONENT_NBR,
	    @FNC_CODE,
	    @AD_NUMBER,
	    @EVENT_COMMENT,
	    @INCOME_ONLY_ID,
	    @EVENT_GEN_ID,
	    @CREATE_DATE,
	    @CREATE_USER,
		@EVENT_TYPE_ID
    );

    SET @THIS_EVENT_ID = SCOPE_IDENTITY();
    
    SELECT @THIS_EVENT_ID;

