--DROP PROCEDURE [dbo].[usp_wv_exp_InsertEXPENSE_DETAIL]
CREATE PROCEDURE [dbo].[usp_wv_exp_InsertEXPENSE_DETAIL] @INV_NBR        VARCHAR(25),
                                                         @ITEM_DATE      DATETIME,
                                                         @ITEM_DESC      VARCHAR(200),
                                                         @CC_FLAG        BIT,
                                                         @CL_CODE        VARCHAR(6),
                                                         @DIV_CODE       VARCHAR(6),
                                                         @PRD_CODE       VARCHAR(6),
                                                         @JOB_NBR        INT,
                                                         @JOB_COMP_NBR   SMALLINT,
                                                         @FNC_CODE       VARCHAR(6),
                                                         @QTY            INT,
                                                         @RATE           DECIMAL(9, 3),
                                                         @CC_AMT         DECIMAL(14, 2),
                                                         @AMOUNT         DECIMAL(14, 2),
                                                         @AP_COMMENT     VARCHAR(100),
                                                         @CREATE_USER_ID VARCHAR(100),
                                                         @MOD_USER_ID    VARCHAR(100),
                                                         @MOD_DATE       DATETIME
AS
     DECLARE @LineNumber AS INT;
     IF EXISTS
     (
         SELECT LINE_NBR
         FROM EXPENSE_DETAIL
         WHERE INV_NBR = @INV_NBR
     )
         BEGIN
             SELECT @LineNumber = MAX(LINE_NBR) + 1
             FROM EXPENSE_DETAIL
             WHERE INV_NBR = @INV_NBR;
         END;
     ELSE
         BEGIN
             SET @LineNumber = 1;
         END;
     INSERT INTO [dbo].[EXPENSE_DETAIL]
     ([INV_NBR],
      [LINE_NBR],
      [ITEM_DATE],
      [ITEM_DESC],
      [CC_FLAG],
      [CL_CODE],
      [DIV_CODE],
      [PRD_CODE],
      [JOB_NBR],
      [JOB_COMP_NBR],
      [FNC_CODE],
      [QTY],
      [RATE],
      [CC_AMT],
      [AMOUNT],
      [AP_COMMENT],
      [CREATE_USER_ID],
      [MOD_USER_ID],
      [MOD_DATE]
     )
     VALUES
     (@INV_NBR,
      @LineNumber,
      @ITEM_DATE,
      @ITEM_DESC,
      @CC_FLAG,
      @CL_CODE,
      @DIV_CODE,
      @PRD_CODE,
      @JOB_NBR,
      @JOB_COMP_NBR,
      @FNC_CODE,
      @QTY,
      @RATE,
      @CC_AMT,
      @AMOUNT,
      @AP_COMMENT,
      @CREATE_USER_ID,
      NULL,
      NULL
     );
     SELECT SCOPE_IDENTITY();