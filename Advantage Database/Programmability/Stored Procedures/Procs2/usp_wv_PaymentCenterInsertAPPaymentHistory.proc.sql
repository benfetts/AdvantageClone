IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterInsertAPPaymentHistory]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterInsertAPPaymentHistory] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterInsertAPPaymentHistory]

@AP_ID AS INTEGER,
@AP_SEQ AS INTEGER,
@BK_CODE AS VARCHAR(4),
@AP_CHK_NBR AS INTEGER,
@CHK_SEQ AS INTEGER,
@AP_CHK_DATE AS DATE,
@AP_CHK_AMT AS DECIMAL(14,2),
@AP_DISC_AMT AS DECIMAL(14,2),
@GLACODE_CASH AS VARCHAR(30),
@GLACODE_AP AS VARCHAR(30),
@GLEXACT AS INTEGER,
@GLESEQ_CASH AS INTEGER,
@GLESEQ_AP AS INTEGER,
@POST_PERIOD AS VARCHAR(6),
@CREATE_DATE AS DATE,
@USERID AS VARCHAR(100),
@VENDOR_TAXABLE_AMOUNT AS DECIMAL(14,2),
@VENDOR_SERVICE_TAX AS DECIMAL(14,2)

AS

BEGIN

INSERT INTO AP_PMT_HIST WITH (ROWLOCK)
            (AP_ID, 
             AP_SEQ, 
             BK_CODE, 
             AP_CHK_NBR, 
             CHK_SEQ, 
             AP_CHK_DATE, 
             AP_CHK_AMT, 
             AP_DISC_AMT, 
             GLACODE_CASH, 
             GLACODE_AP, 
             GLEXACT, 
             GLESEQ_CASH, 
             GLESEQ_AP, 
             POST_PERIOD, 
             CREATE_DATE, 
             USERID, 
             VENDOR_TAXABLE_AMOUNT, 
             VENDOR_SERVICE_TAX) 
VALUES      ( @AP_ID, 
              @AP_SEQ, 
              @BK_CODE, 
              @AP_CHK_NBR, 
              @CHK_SEQ, 
              @AP_CHK_DATE, 
              @AP_CHK_AMT, 
              @AP_DISC_AMT, 
              @GLACODE_CASH, 
              @GLACODE_AP, 
              @GLEXACT, 
              @GLESEQ_CASH, 
              @GLESEQ_AP, 
              @POST_PERIOD, 
              @CREATE_DATE, 
              @USERID, 
              @VENDOR_TAXABLE_AMOUNT, 
              @VENDOR_SERVICE_TAX) 

END

GO
