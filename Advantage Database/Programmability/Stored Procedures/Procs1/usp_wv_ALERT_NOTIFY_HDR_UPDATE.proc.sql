
CREATE PROCEDURE [dbo].[usp_wv_ALERT_NOTIFY_HDR_UPDATE] /*WITH ENCRYPTION*/
@ALRT_NOTIFY_HDR_ID INT,
@ALERT_NOTIFY_NAME VARCHAR(100),
@ACTIVE_FLAG BIT,
@TYPE SMALLINT,
@AUTO_NXT_STATE BIT
AS
/*=========== QUERY ===========*/
BEGIN
	UPDATE ALERT_NOTIFY_HDR WITH(ROWLOCK)
	SET    ALERT_NOTIFY_NAME = @ALERT_NOTIFY_NAME,
		   ACTIVE_FLAG = @ACTIVE_FLAG,
		   [TYPE] = @TYPE,
		   AUTO_NXT_STATE = @AUTO_NXT_STATE
	WHERE  ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID;
END
/*=========== QUERY ===========*/
