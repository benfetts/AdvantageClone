






















CREATE PROCEDURE [dbo].[usp_wv_jobspecs_JobCopy]
	@JobNum INT,
	@JobCompNum INT,
	@JOB_NUM INT,
	@JOB_COMP INT
AS
	DECLARE @Restrictions   INT,
	        @NumberRecords  INT,
	        @RowCount       INT,
	        @JNum           INT,
	        @JCNum          INT,
	        @SpecVersion    INT,
	        @SpecRevision   INT,
	        @Qty            INT,
	        @Vendor         INT	
	
	CREATE TABLE #js
	(
		RowID      INT IDENTITY(1, 1),
		JobNo      INT,
		JobCompNo  INT,
		SpecVer    INT,
		SpecRev    INT
	);
	
	INSERT INTO #js
	SELECT JOB_NUMBER,
	       JOB_COMPONENT_NBR,
	       SPEC_VER,
	       MAX(SPEC_REV)
	FROM   JOB_SPECS
	WHERE  (JOB_NUMBER = @JobNum)
	       AND (JOB_COMPONENT_NBR = @JobCompNum)
	GROUP BY
	       JOB_NUMBER,
	       JOB_COMPONENT_NBR,
	       SPEC_VER;
	
	
	
	SET @NumberRecords = @@ROWCOUNT;
	SET @RowCount = 1;
	
	
	WHILE @RowCount <= @NumberRecords
	BEGIN
	    SELECT @JNum = JobNo,
	           @JCNum = JobCompNo,
	           @SpecVersion = SpecVer,
	           @SpecRevision = SpecRev
	    FROM   #js
	    WHERE  RowID = @RowCount
	    
	    SELECT @Qty = JOB_SPEC_TYPE.USE_QTY,
	           @Vendor = JOB_SPEC_TYPE.USE_VENDOR_TAB
	    FROM   JOB_SPECS
	           INNER JOIN JOB_SPEC_TYPE
	                ON  JOB_SPECS.SPEC_TYPE_CODE = JOB_SPEC_TYPE.SPEC_TYPE_CODE
	    WHERE  JOB_NUMBER = @JNum
	           AND JOB_COMPONENT_NBR = @JCNum
	           AND SPEC_VER = @SpecVersion
	           AND SPEC_REV = @SpecRevision 
	    

		INSERT INTO JOB_SPECS
		(
			JOB_NUMBER,
			JOB_COMPONENT_NBR,
			SPEC_VER,
			SPEC_REV,
			SPEC_REV_REASON,
			SPEC_REV_AUTH,
			SPEC_REV_USER_ID,
			SPEC_REV_USER_DATE,
			SPEC_TYPE_CODE,
			SPEC_VER_DESC,
			QTY1,
			QTY2,
			QTY3,
			QTY4,
			QTY5,
			CHAR1_1,
			CHAR1_2,
			CHAR1_3,
			CHAR1_4,
			CHAR1_5,
			CHAR10_1,
			CHAR10_2,
			CHAR10_3,
			CHAR10_4,
			CHAR10_5,
			CHAR50_1,
			CHAR50_2,
			CHAR50_3,
			CHAR50_4,
			CHAR50_5,
			CHAR50_6,
			CHAR50_7,
			CHAR254_1,
			CHAR254_2,
			CHAR254_3,
			CHAR254_4,
			SMALLINT_1,
			SMALLINT_2,
			SMALLINT_3,
			SMALLINT_4,
			SMALLINT_5,
			SMALLINT_6,
			SMALLINT_7,
			SMALLINT_8,
			INT_1,
			INT_2,
			INT_3,
			INT_4,
			INT_5,
			INT_6,
			INT_7,
			INT_8,
			INT_9,
			INT_10,
			TEXT_1,
			TEXT_2,
			TEXT_3,
			TEXT_4,
			TEXT_5,
			TEXT_6,
			TEXT_7,
			TEXT_8,
			CHAR1_6,
			CHAR1_7,
			CHAR1_8,
			CHAR1_9,
			CHAR1_10,
			CHAR1_11,
			CHAR1_12,
			CHAR1_13,
			CHAR1_14,
			CHAR1_15,
			CHAR1_16,
			CHAR1_17,
			CHAR1_18,
			CHAR1_19,
			CHAR1_20,
			CHAR10_6,
			CHAR10_7,
			CHAR10_8,
			CHAR10_9,
			CHAR10_10,
			CHAR10_11,
			CHAR10_12,
			CHAR10_13,
			CHAR10_14,
			CHAR10_15,
			CHAR10_16,
			CHAR10_17,
			CHAR10_18,
			CHAR10_19,
			CHAR10_20,
			CHAR50_8,
			CHAR50_9,
			CHAR50_10,
			CHAR50_11,
			CHAR50_12,
			CHAR50_13,
			CHAR50_14,
			CHAR50_15,
			CHAR50_16,
			CHAR50_17,
			CHAR50_18,
			CHAR50_19,
			CHAR50_20,
			CHAR254_5,
			CHAR254_6,
			CHAR254_7,
			CHAR254_8,
			CHAR254_9,
			CHAR254_10,
			SMALLINT_9,
			SMALLINT_10,
			SMALLINT_11,
			SMALLINT_12,
			SMALLINT_13,
			SMALLINT_14,
			SMALLINT_15,
			SMALLINT_16,
			SMALLINT_17,
			SMALLINT_18,
			SMALLINT_19,
			SMALLINT_20,
			INT_11,
			INT_12,
			INT_13,
			INT_14,
			INT_15,
			INT_16,
			INT_17,
			INT_18,
			INT_19,
			INT_20,
			TEXT_9,
			TEXT_10,
			TEXT_11,
			TEXT_12,
			TEXT_13,
			TEXT_14,
			TEXT_15,
			TEXT_16,
			TEXT_17,
			TEXT_18,
			TEXT_19,
			TEXT_20
		)
	    SELECT @JOB_NUM,
	           @JOB_COMP,
	           JOB_SPECS.SPEC_VER,
	           0,
	           JOB_SPECS.SPEC_REV_REASON,
	           JOB_SPECS.SPEC_REV_AUTH,
	           JOB_SPECS.SPEC_REV_USER_ID,
	           JOB_SPECS.SPEC_REV_USER_DATE,
	           JOB_SPECS.SPEC_TYPE_CODE,
	           JOB_SPECS.SPEC_VER_DESC, --10
	           JOB_SPECS.QTY1,
	           JOB_SPECS.QTY2,
	           JOB_SPECS.QTY3,
	           JOB_SPECS.QTY4,
	           JOB_SPECS.QTY5,
	           JOB_SPECS.CHAR1_1,
	           JOB_SPECS.CHAR1_2,
	           JOB_SPECS.CHAR1_3,
	           JOB_SPECS.CHAR1_4,
	           JOB_SPECS.CHAR1_5,
	           JOB_SPECS.CHAR10_1,
	           JOB_SPECS.CHAR10_2,
	           JOB_SPECS.CHAR10_3,
	           JOB_SPECS.CHAR10_4,
	           JOB_SPECS.CHAR10_5,
	           JOB_SPECS.CHAR50_1,
	           JOB_SPECS.CHAR50_2,
	           JOB_SPECS.CHAR50_3,
	           JOB_SPECS.CHAR50_4,
	           JOB_SPECS.CHAR50_5,
	           JOB_SPECS.CHAR50_6,
	           JOB_SPECS.CHAR50_7,
	           JOB_SPECS.CHAR254_1,
	           JOB_SPECS.CHAR254_2,
	           JOB_SPECS.CHAR254_3,
	           JOB_SPECS.CHAR254_4,
	           JOB_SPECS.SMALLINT_1,
	           JOB_SPECS.SMALLINT_2,
	           JOB_SPECS.SMALLINT_3,
	           JOB_SPECS.SMALLINT_4,
	           JOB_SPECS.SMALLINT_5,
	           JOB_SPECS.SMALLINT_6,
	           JOB_SPECS.SMALLINT_7,
	           JOB_SPECS.SMALLINT_8,
	           JOB_SPECS.INT_1,
	           JOB_SPECS.INT_2,
	           JOB_SPECS.INT_3,
	           JOB_SPECS.INT_4,
	           JOB_SPECS.INT_5,
	           JOB_SPECS.INT_6,
	           JOB_SPECS.INT_7,
	           JOB_SPECS.INT_8,
	           JOB_SPECS.INT_9,
	           JOB_SPECS.INT_10,
	           JOB_SPECS.TEXT_1,
	           JOB_SPECS.TEXT_2,
	           JOB_SPECS.TEXT_3,
	           JOB_SPECS.TEXT_4,
	           JOB_SPECS.TEXT_5,
	           JOB_SPECS.TEXT_6,
	           JOB_SPECS.TEXT_7,
	           JOB_SPECS.TEXT_8,
	           JOB_SPECS.CHAR1_6,
	           JOB_SPECS.CHAR1_7,
	           JOB_SPECS.CHAR1_8,
	           JOB_SPECS.CHAR1_9,
	           JOB_SPECS.CHAR1_10,
	           JOB_SPECS.CHAR1_11,
	           JOB_SPECS.CHAR1_12,
	           JOB_SPECS.CHAR1_13,
	           JOB_SPECS.CHAR1_14,
	           JOB_SPECS.CHAR1_15,
	           JOB_SPECS.CHAR1_16,
	           JOB_SPECS.CHAR1_17,
	           JOB_SPECS.CHAR1_18,
	           JOB_SPECS.CHAR1_19,
	           JOB_SPECS.CHAR1_20,
	           JOB_SPECS.CHAR10_6,
	           JOB_SPECS.CHAR10_7,
	           JOB_SPECS.CHAR10_8,
	           JOB_SPECS.CHAR10_9,
	           JOB_SPECS.CHAR10_10,
	           JOB_SPECS.CHAR10_11,
	           JOB_SPECS.CHAR10_12,
	           JOB_SPECS.CHAR10_13,
	           JOB_SPECS.CHAR10_14,
	           JOB_SPECS.CHAR10_15,
	           JOB_SPECS.CHAR10_16,
	           JOB_SPECS.CHAR10_17,
	           JOB_SPECS.CHAR10_18,
	           JOB_SPECS.CHAR10_19,
	           JOB_SPECS.CHAR10_20,
	           JOB_SPECS.CHAR50_8,
	           JOB_SPECS.CHAR50_9,
	           JOB_SPECS.CHAR50_10,
	           JOB_SPECS.CHAR50_11,
	           JOB_SPECS.CHAR50_12,
	           JOB_SPECS.CHAR50_13,
	           JOB_SPECS.CHAR50_14,
	           JOB_SPECS.CHAR50_15,
	           JOB_SPECS.CHAR50_16,
	           JOB_SPECS.CHAR50_17,
	           JOB_SPECS.CHAR50_18,
	           JOB_SPECS.CHAR50_19,
	           JOB_SPECS.CHAR50_20,
	           JOB_SPECS.CHAR254_5,
	           JOB_SPECS.CHAR254_6,
	           JOB_SPECS.CHAR254_7,
	           JOB_SPECS.CHAR254_8,
	           JOB_SPECS.CHAR254_9,
	           JOB_SPECS.CHAR254_10,
	           JOB_SPECS.SMALLINT_9,
	           JOB_SPECS.SMALLINT_10,
	           JOB_SPECS.SMALLINT_11,
	           JOB_SPECS.SMALLINT_12,
	           JOB_SPECS.SMALLINT_13,
	           JOB_SPECS.SMALLINT_14,
	           JOB_SPECS.SMALLINT_15,
	           JOB_SPECS.SMALLINT_16,
	           JOB_SPECS.SMALLINT_17,
	           JOB_SPECS.SMALLINT_18,
	           JOB_SPECS.SMALLINT_19,
	           JOB_SPECS.SMALLINT_20,
	           JOB_SPECS.INT_11,
	           JOB_SPECS.INT_12,
	           JOB_SPECS.INT_13,
	           JOB_SPECS.INT_14,
	           JOB_SPECS.INT_15,
	           JOB_SPECS.INT_16,
	           JOB_SPECS.INT_17,
	           JOB_SPECS.INT_18,
	           JOB_SPECS.INT_19,
	           JOB_SPECS.INT_20,
	           JOB_SPECS.TEXT_9,
	           JOB_SPECS.TEXT_10,
	           JOB_SPECS.TEXT_11,
	           JOB_SPECS.TEXT_12,
	           JOB_SPECS.TEXT_13,
	           JOB_SPECS.TEXT_14,
	           JOB_SPECS.TEXT_15,
	           JOB_SPECS.TEXT_16,
	           JOB_SPECS.TEXT_17,
	           JOB_SPECS.TEXT_18,
	           JOB_SPECS.TEXT_19,
	           JOB_SPECS.TEXT_20
	    FROM   JOB_SPECS
	    WHERE  JOB_NUMBER = @JNum
	           AND JOB_COMPONENT_NBR = @JCNum
	           AND SPEC_VER = @SpecVersion
	           AND SPEC_REV = @SpecRevision 
	    
	    IF @Qty = 1
	    BEGIN
	        INSERT INTO JOB_SPEC_QTY
	        SELECT @JOB_NUM,
	               @JOB_COMP,
	               SPEC_VER,
	               0,
	               SEQ_NBR,
	               JOB_QTY
	        FROM   JOB_SPEC_QTY
	        WHERE  JOB_NUMBER = @JobNum
	               AND JOB_COMPONENT_NBR = @JobCompNum
	               AND SPEC_VER = @SpecVersion
	               AND SPEC_REV = @SpecRevision
	    END
	    
	    
	    SET @RowCount = @RowCount + 1
	END
	
	
	IF @Vendor = 1
	BEGIN
	    INSERT INTO JOB_PUB_VENDOR
	    SELECT @JOB_NUM,
	           @JOB_COMP,
	           SPEC_ID,
	           VN_CODE,
	           JOB_PUB_BLEED_SIZE,
	           JOB_PUB_CLOSE_DATE,
	           JOB_PUB_COLOR,
	           JOB_PUB_EXT_DATE,
	           JOB_PUB_LIVE_AREA,
	           JOB_PUB_RUN_DATE,
	           JOB_PUB_SCREEN,
	           JOB_PUB_TRIM_SIZE,
	           JOB_PUB_DENSITY,
	           JOB_PUB_FILM,
	           JOB_PUB_SHIP_COMM,
	           JOB_PUB_SPCL_INST,
	           STATUS_CODE,
	           REGION_CODE,
	           NULL
	    FROM   JOB_PUB_VENDOR
	    WHERE  JOB_NUMBER = @JobNum
	           AND JOB_COMPONENT_NBR = @JobCompNum
	END
	
	IF @Vendor = 2
	BEGIN
	    INSERT INTO JOB_OUTDOOR_VENDOR
	    SELECT @JOB_NUM,
	           @JOB_COMP,
	           SPEC_ID,
	           VN_CODE,
	           JOB_OUT_COPY_AREA,
	           JOB_OUT_LOCATION,
	           JOB_OUT_OVR_SIZE,
	           NULL
	    FROM   JOB_OUTDOOR_VENDOR
	    WHERE  JOB_NUMBER = @JobNum
	           AND JOB_COMPONENT_NBR = @JobCompNum
	END 
	
	DROP TABLE #js
