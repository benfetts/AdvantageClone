





















CREATE PROCEDURE [dbo].[usp_wv_dto_GetInvoiceComment]
@InvoiceNum int,  
@InvoiceSeq int
AS

     
SELECT COLLECT_NOTES 
FROM AR_COLL_NOTES 
WHERE (AR_INV_NBR = @InvoiceNum) AND (AR_INV_SEQ = @InvoiceSeq)              
   
 





















