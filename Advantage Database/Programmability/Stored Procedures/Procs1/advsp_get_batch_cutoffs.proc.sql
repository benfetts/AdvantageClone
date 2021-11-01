
CREATE PROCEDURE [dbo].[advsp_get_batch_cutoffs] @ba_batch_id_in integer, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

SELECT @ret_val = 0

SELECT DATE_CUTOFF, PERIOD_CUTOFF, SEL_OPTION
  FROM dbo.BILL_APPR_BATCH
 WHERE BA_BATCH_ID = @ba_batch_id_in
