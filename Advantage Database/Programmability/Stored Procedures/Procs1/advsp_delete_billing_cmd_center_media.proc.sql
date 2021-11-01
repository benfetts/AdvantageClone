
CREATE PROCEDURE [dbo].[advsp_delete_billing_cmd_center_media] @bill_user_in varchar(100), @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @bcc_id integer

SELECT @bcc_id = ( SELECT BCC_ID FROM dbo.BILLING_CMD_CENTER WHERE BILLING_USER = @bill_user_in )

UPDATE dbo.NEWSPAPER_HEADER
   SET BCC_ID = NULL
 WHERE BCC_ID = @bcc_id    

UPDATE dbo.MAGAZINE_HEADER
   SET BCC_ID = NULL
 WHERE BCC_ID = @bcc_id   
 
UPDATE dbo.RADIO_HEADER
   SET BCC_ID = NULL
 WHERE BCC_ID = @bcc_id
 
UPDATE dbo.TV_HEADER
   SET BCC_ID = NULL
 WHERE BCC_ID = @bcc_id    

UPDATE dbo.RADIO_HDR
   SET BCC_ID = NULL
 WHERE BCC_ID = @bcc_id
 
UPDATE dbo.TV_HDR
   SET BCC_ID = NULL
 WHERE BCC_ID = @bcc_id    

UPDATE dbo.INTERNET_HEADER
   SET BCC_ID = NULL
 WHERE BCC_ID = @bcc_id
 
UPDATE dbo.OUTDOOR_HEADER
   SET BCC_ID = NULL
 WHERE BCC_ID = @bcc_id    

DELETE FROM dbo.BCC_ORDER_LINE
 WHERE BCC_ID = @bcc_id

DELETE FROM dbo.BCC_ORDER_BRDCAST
 WHERE BCC_ID = @bcc_id     

