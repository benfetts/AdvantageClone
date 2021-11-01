﻿CREATE PROCEDURE advsp_hosted_spotradio_delete_reissues

AS
BEGIN

	DECLARE @NIELSEN_RADIO_PERIOD_ID int,
			@ROWCOUNT int,
			@ROW_ID int

	DECLARE @PERIOD_DELETE TABLE (
		ID						int IDENTITY (1, 1) NOT NULL,
		NIELSEN_RADIO_PERIOD_ID int NOT NULL
	)

	INSERT INTO @PERIOD_DELETE (NIELSEN_RADIO_PERIOD_ID)
	SELECT OLD_NIELSEN_RADIO_PERIOD_ID 
	FROM NIELSENDATASTORE.dbo.NIELSEN_RADIO_PERIOD_REVISION 

	SELECT @ROWCOUNT = COUNT(1) FROM @PERIOD_DELETE 
	SELECT @ROW_ID = MIN(ID) FROM @PERIOD_DELETE 

	IF @ROWCOUNT > 0 BEGIN

		WHILE @ROW_ID <= @ROWCOUNT
		BEGIN

			SELECT @NIELSEN_RADIO_PERIOD_ID = NIELSEN_RADIO_PERIOD_ID
			FROM @PERIOD_DELETE 
			WHERE ID = @ROW_ID 

			EXEC NIELSENHOSTED.dbo.advsp_neilsen_radio_period_delete @NIELSEN_RADIO_PERIOD_ID

			SET @ROW_ID = @ROW_ID + 1

		END

	END
END
GO

GRANT EXEC ON advsp_hosted_spotradio_delete_reissues TO PUBLIC
GO