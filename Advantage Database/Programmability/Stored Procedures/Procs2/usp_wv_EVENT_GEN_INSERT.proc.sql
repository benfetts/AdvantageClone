
CREATE PROCEDURE [dbo].[usp_wv_EVENT_GEN_INSERT] 
		@EVENT_GEN_LABEL VARCHAR(50),
		@EVENT_GEN_DESC_LONG TEXT,
		@TYPE VARCHAR(6),
		@START_DATE SMALLDATETIME,
		@END_DATE SMALLDATETIME,
		@START_TIME SMALLDATETIME,
		@END_TIME SMALLDATETIME,
		@OCCUR INT,
		@DAY_INCREMENT INT,
		@DAYS VARCHAR(50),
		@QTY_HOURS DECIMAL(9,2),
		@ALL_DAY BIT,
		@JOB_NUMBER INT,
		@JOB_COMPONENT_NBR SMALLINT,
		@EST_NUMBER INT,
		@EST_COMPONENT_NBR SMALLINT,
		@EST_QUOTE_NUMBER SMALLINT,
		@FNC_CODE VARCHAR(6),
		@AD_NUMBER VARCHAR(30),
		@CREATE_DATE SMALLDATETIME,
		@CREATE_USER VARCHAR(100),
		@GENERATE_DATE SMALLDATETIME,
		@GENERATE_USER VARCHAR(100),
		@ADD_ADDITIONAL INT,
		@EST_REV_NUMBER INT,
		@EVENT_GEN_ID INT,
		@QTY_TYPE SMALLINT,
		@EVENT_TYPE_ID SMALLINT


AS

        DECLARE
		        @ERR INT,
		        @THIS_EVENT_GEN_ID INT,
		        @EMP_CODE VARCHAR(6)

        SET @THIS_EVENT_GEN_ID = 0;
        SET @EMP_CODE = NULL;
        
        IF @EVENT_GEN_ID <= 0
            BEGIN
 		        INSERT INTO EVENT_GEN WITH(ROWLOCK)
		        (
				        EVENT_GEN_LABEL,
				        EVENT_GEN_DESC_LONG,
				        TYPE,
				        START_DATE,
				        END_DATE,
				        START_TIME,
				        END_TIME,
				        OCCUR,
				        DAY_INCREMENT,
				        DAYS,
				        QTY_HOURS,
				        QTY_TYPE,
				        ALL_DAY,
				        JOB_NUMBER,
				        JOB_COMPONENT_NBR,
				        EST_NUMBER,
				        EST_COMPONENT_NBR,
				        EST_QUOTE_NUMBER,
				        FNC_CODE,
				        AD_NUMBER,
				        CREATE_DATE,
				        CREATE_USER,
				        GENERATE_DATE,
				        GENERATE_USER,
						EVENT_TYPE_ID
		        )
		        VALUES
		        (
				        @EVENT_GEN_LABEL,
				        @EVENT_GEN_DESC_LONG,
				        @TYPE,
				        @START_DATE,
				        @END_DATE,
				        @START_TIME,
				        @END_TIME,
				        @OCCUR,
				        @DAY_INCREMENT,
				        @DAYS,
				        @QTY_HOURS,
				        @QTY_TYPE,
				        @ALL_DAY,
				        @JOB_NUMBER,
				        @JOB_COMPONENT_NBR,
				        @EST_NUMBER,
				        @EST_COMPONENT_NBR,
				        @EST_QUOTE_NUMBER,
				        @FNC_CODE,
				        @AD_NUMBER,
				        @CREATE_DATE,
				        @CREATE_USER,
				        @GENERATE_DATE,
				        @GENERATE_USER,
						@EVENT_TYPE_ID
		        );
        		
                SET @ERR = @@ERROR;
                SET @THIS_EVENT_GEN_ID = SCOPE_IDENTITY();
           END
        ELSE
            BEGIN
                SET @THIS_EVENT_GEN_ID = @EVENT_GEN_ID;
            END
        
        --ADD ESTIMATE FUNCTION TOO
        --IF @ADD_ADDITIONAL = 1 AND @THIS_EVENT_GEN_ID > 0 AND @EST_NUMBER > 0 AND @EST_COMPONENT_NBR > 0 AND  @EST_QUOTE_NUMBER > 0 AND @EST_REV_NUMBER > -1
        --BEGIN
        --    EXEC usp_wv_ESTIMATE_REV_DET_INSERT_DFLT @EST_NUMBER,@EST_COMPONENT_NBR,@EST_QUOTE_NUMBER,@EST_REV_NUMBER,@FNC_CODE,@ADD_ADDITIONAL,@CREATE_USER,@THIS_EVENT_GEN_ID,@EMP_CODE,@QTY_HOURS;
        --END
        
        

        SELECT @THIS_EVENT_GEN_ID;

