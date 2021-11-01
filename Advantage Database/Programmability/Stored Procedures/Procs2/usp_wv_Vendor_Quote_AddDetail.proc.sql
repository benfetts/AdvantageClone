﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Vendor_Quote_AddDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Vendor_Quote_AddDetail]
GO

CREATE PROCEDURE [dbo].[usp_wv_Vendor_Quote_AddDetail]
(
	@ESTIMATE_NUMBER INT,
	@EST_COMPONENT_NBR SMALLINT,
	@VENDOR_QTE_NBR INT,
	@EST_QUOTE_NBR INT,
	@EST_REV_NBR INT,
	@EST_FNC_CODE VARCHAR(6),
	@VN_CODE VARCHAR(6),
	@CREATED_BY VARCHAR(100),
	@CREATE_DATE SMALLDATETIME,
	@REPLY_RATE decimal(9, 4),
	@REPLY_AMT decimal(15, 2),
	@REPLY_NOTES TEXT,
	@APPROVED_FLAG SMALLINT,
	@APPROVAL_NOTES TEXT,
	@APPROVED_BY VARCHAR(100),
	@APPROVED_DATE SMALLDATETIME,
	@QTY INT
)
AS
BEGIN
	SET NOCOUNT OFF
	
	DECLARE 
	@ERR INT--,
	--@NEXT_EST_NBR INT
	
    --SELECT @NEXT_EST_NBR = ISNULL(MAX(ESTIMATE_NUMBER),-1) + 1 FROM ESTIMATE_LOG 

	INSERT INTO [VENDOR_QTE_DTL]
		(
			[ESTIMATE_NUMBER],
			[EST_COMPONENT_NBR],
			[VENDOR_QTE_NBR],
			[EST_QUOTE_NBR],
			[EST_REV_NBR],
			[EST_FNC_CODE],
			[VN_CODE],
			[CREATED_BY],
			[CREATE_DATE],
			[REPLY_RATE],
			[REPLY_AMT],
			[REPLY_NOTES],
			[APPROVED_FLAG],
			[APPROVAL_NOTES],
			[APPROVED_BY],
			[APPROVED_DATE],
			[QTY]
		)
		VALUES
		(
			@ESTIMATE_NUMBER,
			@EST_COMPONENT_NBR,
			@VENDOR_QTE_NBR,
			@EST_QUOTE_NBR,
			@EST_REV_NBR,
			@EST_FNC_CODE,
			@VN_CODE,
			@CREATED_BY,
			@CREATE_DATE,
			@REPLY_RATE,
			@REPLY_AMT,
			@REPLY_NOTES,
			@APPROVED_FLAG,
			@APPROVAL_NOTES,
			@APPROVED_BY,
			@APPROVED_DATE,
			@QTY
		)

	
	SET @ERR = @@Error

	--RETURN @ERR
END




