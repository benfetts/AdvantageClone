--DROP PROCEDURE [dbo].[usp_wv_BA_BILL_APPR_DTL_UPDATE] 
CREATE PROCEDURE [dbo].[usp_wv_BA_BILL_APPR_DTL_UPDATE] 
@BA_DTL_ID AS INTEGER,
@QTY_HRS AS DECIMAL (15,3),
@BILLING_RATE AS DECIMAL (9,2),
@FNC_DESC AS VARCHAR(30),
@APPROVED_AMT AS DECIMAL (15,3),
@FNC_COMMENTS AS TEXT,
@CLIENT_COMMENTS AS TEXT,
@ROW_TYPE AS TINYINT,
@APPR_NET AS DECIMAL(14,2),

@APPR_MARKUP_PCT DECIMAL(6, 3),
@APPR_MARKUP_AMT DECIMAL(14, 2),
@APPR_TAX_CODE VARCHAR(4),
@APPR_TAX_COMM SMALLINT,
@APPR_TAX_COMM_ONLY SMALLINT,
@APPR_TAX_RESALE SMALLINT,
@APPR_RESALE_TAX DECIMAL(14, 2),
@APPR_VENDOR_TAX DECIMAL(14, 2),
@APPR_TAX_STATE_PCT DECIMAL(8, 4),
@APPR_TAX_COUNTY_PCT DECIMAL(8, 4),
@APPR_TAX_CITY_PCT DECIMAL(8, 4) 
AS
	
	UPDATE BILL_APPR_DTL WITH(ROWLOCK)
	SET
		QTY_HRS = @QTY_HRS,
		FNC_DESC = @FNC_DESC,
		BILLING_RATE = @BILLING_RATE,
		APPROVED_AMT = @APPROVED_AMT,
		FNC_COMMENTS = @FNC_COMMENTS,
		CLIENT_COMMENTS = @CLIENT_COMMENTS,
		ROW_TYPE = @ROW_TYPE,
		APPR_NET = @APPR_NET,
		APPR_MARKUP_PCT = @APPR_MARKUP_PCT,
		APPR_MARKUP_AMT = @APPR_MARKUP_AMT,
		APPR_TAX_CODE = @APPR_TAX_CODE,
		APPR_TAX_COMM = @APPR_TAX_COMM,
		APPR_TAX_COMM_ONLY = @APPR_TAX_COMM_ONLY,
		APPR_TAX_RESALE = @APPR_TAX_RESALE,
		APPR_RESALE_TAX = @APPR_RESALE_TAX,
		APPR_VENDOR_TAX = @APPR_VENDOR_TAX,
		APPR_TAX_STATE_PCT = @APPR_TAX_STATE_PCT,
		APPR_TAX_COUNTY_PCT = @APPR_TAX_COUNTY_PCT,
		APPR_TAX_CITY_PCT = @APPR_TAX_CITY_PCT 

	WHERE
		BA_DTL_ID = @BA_DTL_ID;

	EXEC advsp_billing_approval_detail_calculate_amounts @BA_DTL_ID;

	SELECT @BA_DTL_ID;