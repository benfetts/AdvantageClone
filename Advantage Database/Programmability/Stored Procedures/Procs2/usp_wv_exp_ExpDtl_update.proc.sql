--DROP PROCEDURE [dbo].[usp_wv_exp_ExpDtl_update]
CREATE PROCEDURE [dbo].[usp_wv_exp_ExpDtl_update] @EXPDETAILID  INT,
                                                  @APComment    VARCHAR(100),
                                                  @CCAMT        DECIMAL(14, 2),
                                                  @CCFlag       BIT,
                                                  @ClientCode   VARCHAR(6),
                                                  @DivCode      VARCHAR(6),
                                                  @FNCCode      VARCHAR(6),
                                                  @ItemAMT      DECIMAL(14, 2),
                                                  @ItemDate     DATETIME,
                                                  @ItemDesc     VARCHAR(200),
                                                  @JobCompNBR   SMALLINT,
                                                  @JobNBR       INT,
                                                  @ModifyDate   DATETIME,
                                                  @ModifyUserID VARCHAR(100),
                                                  @PrdCode      VARCHAR(6),
                                                  @QTY          INT,
                                                  @Rate         DECIMAL(6, 2)
AS
     UPDATE EXPENSE_DETAIL
       SET
           AP_COMMENT = @APComment,
           CC_AMT = @CCAMT,
           CC_FLAG = @CCFlag,
           CL_CODE = @ClientCode,
           DIV_CODE = @DivCode,
           FNC_CODE = @FNCCode,
           AMOUNT = @ItemAMT,
           ITEM_DATE = @ItemDate,
           ITEM_DESC = @ItemDesc,
           JOB_COMP_NBR = @JobCompNBR,
           JOB_NBR = @JobNBR,
           MOD_DATE = @ModifyDate,
           MOD_USER_ID = @ModifyUserID,
           PRD_CODE = @PrdCode,
           QTY = @QTY,
           RATE = @Rate
     WHERE EXPDETAILID = @EXPDETAILID;