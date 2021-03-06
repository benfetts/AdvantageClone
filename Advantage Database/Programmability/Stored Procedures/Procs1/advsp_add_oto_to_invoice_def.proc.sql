IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_add_oto_to_invoice_def]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_add_oto_to_invoice_def]
GO

CREATE PROCEDURE [dbo].[advsp_add_oto_to_invoice_def]
AS
SET NOCOUNT ON

-- ============================================================================
-- advsp_add_oto_to_invoice_def
-- adds a record to PROD_INV_DEF and MEDIA_INV_DEF if no CLIENT_OR_DEF = 0 record exists
-- #00 03/08/14 - initial
-- ============================================================================

DECLARE @oto_record_exists	tinyint

--Inserts record into PROD_INV_DEF
SET @oto_record_exists = (SELECT CLIENT_OR_DEF FROM dbo.PROD_INV_DEF WHERE CLIENT_OR_DEF = 0)
--SELECT @oto_record_exists
IF @oto_record_exists IS NULL
BEGIN
	INSERT INTO dbo.PROD_INV_DEF (CLIENT_OR_DEF)
	SELECT 0
END	

--Inserts record into MEDIA_INV_DEF
SET @oto_record_exists = (SELECT CLIENT_OR_DEF FROM dbo.MEDIA_INV_DEF WHERE CLIENT_OR_DEF = 0)
--SELECT @oto_record_exists
IF @oto_record_exists IS NULL
BEGIN
	INSERT INTO dbo.MEDIA_INV_DEF (CLIENT_OR_DEF)
	SELECT 0
END	

GO


