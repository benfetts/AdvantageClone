

















CREATE PROCEDURE [dbo].[usp_wv_job_HideNonBillable] 

AS



Select ISNULL( NOBILL_FLAG_H,0)
FROM AGENCY

















