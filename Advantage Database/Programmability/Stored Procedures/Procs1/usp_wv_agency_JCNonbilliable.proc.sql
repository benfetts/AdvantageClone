


















CREATE PROCEDURE [dbo].[usp_wv_agency_JCNonbilliable] 
@NonBilliable Integer OUTPUT
AS

SELECT @NonBilliable = NOBILL_FLAG_H FROM AGENCY


















