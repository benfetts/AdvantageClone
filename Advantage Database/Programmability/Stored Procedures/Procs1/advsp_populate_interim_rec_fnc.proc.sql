
CREATE PROCEDURE [dbo].[advsp_populate_interim_rec_fnc] @job_number integer, @job_component_nbr smallint, @ret_val integer OUTPUT
AS

SET NOCOUNT ON

CREATE TABLE #interim_rec_dtl ( 
	FNC_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	FNC_TYPE			varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	FNC_DESCRIPTION		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ITEM_ID				integer NOT NULL,
	LINE_NUMBER			smallint NULL,
	AP_SEQ				smallint NULL,
	EXT_AMOUNT			decimal(15,2) NULL,
	EXT_MARKUP_AMT		decimal(15,2) NULL,
	EXT_STATE_RESALE	decimal(15,2) NULL,
	EXT_COUNTY_RESALE	decimal(15,2) NULL,
	EXT_CITY_RESALE		decimal(15,2) NULL,
	EXT_NONRESALE_TAX	decimal(15,2) NULL,
	LINE_TOTAL			decimal(15,2) NULL,
	BA_ID				integer NULL,
	WIP_AMOUNT			decimal(15,2) NULL,
	AMOUNT				decimal(15,2) NULL,
	AB_FLAG				integer NULL,
	AR_INV_NBR			integer NULL,
	TAX_CODE			varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	GLACODE_STATE		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	GLACODE_CNTY		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	GLACODE_CITY		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PREV_REC			decimal(15,2) NULL,
	REC_FLAG			smallint NULL )	

CREATE TABLE #interim_rec_fnc ( 
	FNC_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	FNC_TYPE			varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	FNC_DESCRIPTION		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ACTUAL_AMOUNT		decimal(15,2) NULL,
	PREV_REC			decimal(15,2) NULL,
	RECONCILE_AMT		decimal(15,2) NULL,
	RECONCILE_BAL		decimal(15,2) NULL,	
	REC_FLAG			smallint NULL )	

INSERT INTO #interim_rec_dtl ( FNC_CODE, FNC_TYPE, FNC_DESCRIPTION, ITEM_ID, LINE_NUMBER, AP_SEQ, 
		EXT_AMOUNT, EXT_MARKUP_AMT, EXT_STATE_RESALE, EXT_COUNTY_RESALE, EXT_CITY_RESALE, EXT_NONRESALE_TAX, 
		LINE_TOTAL, BA_ID, WIP_AMOUNT, AMOUNT, AB_FLAG, AR_INV_NBR, TAX_CODE, GLACODE_STATE, GLACODE_CNTY, 
		GLACODE_CITY, PREV_REC, REC_FLAG )
EXECUTE dbo.advsp_billing_interim_rec_dtl @job_number = @job_number, @job_component_nbr = @job_component_nbr, @ret_val = @ret_val OUTPUT	

INSERT INTO #interim_rec_fnc ( FNC_CODE, FNC_TYPE, FNC_DESCRIPTION, REC_FLAG, ACTUAL_AMOUNT, PREV_REC, RECONCILE_BAL )
	 SELECT ird.FNC_CODE, ird.FNC_TYPE, ird.FNC_DESCRIPTION, 0,
			SUM( COALESCE( ird.AMOUNT, 0.00 )),
			SUM( COALESCE( ird.PREV_REC, 0.00 )),
			COALESCE( SUM( COALESCE( ird.AMOUNT, 0.00 )) - SUM( COALESCE( ird.PREV_REC, 0.00 )), 0.00 )
	   FROM #interim_rec_dtl ird
   GROUP BY ird.FNC_CODE, ird.FNC_TYPE, ird.FNC_DESCRIPTION
   
 UPDATE #interim_rec_fnc
    SET REC_FLAG = 1
  WHERE EXISTS ( SELECT * 
                   FROM #interim_rec_dtl 
                  WHERE #interim_rec_dtl.FNC_CODE = #interim_rec_fnc.FNC_CODE
                    AND #interim_rec_dtl.FNC_TYPE = #interim_rec_fnc.FNC_TYPE
                    AND #interim_rec_dtl.REC_FLAG = 1 )     

SELECT irf.FNC_CODE, irf.FNC_TYPE, irf.FNC_DESCRIPTION, irf.ACTUAL_AMOUNT,
       irf.PREV_REC, irf.RECONCILE_AMT, irf.RECONCILE_BAL, irf.REC_FLAG
  FROM #interim_rec_fnc irf
  
DROP TABLE #interim_rec_dtl
DROP TABLE #interim_rec_fnc
  
