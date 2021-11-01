
CREATE PROCEDURE [dbo].[proc_WV_PO_GetRequiredAmt_flg](@funct as integer) AS
 declare @flg as smallint
   select @flg =  PO_AMT_REQ from AGENCY
  return @flg

