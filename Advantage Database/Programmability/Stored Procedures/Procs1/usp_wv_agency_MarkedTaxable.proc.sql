


















CREATE PROCEDURE [dbo].[usp_wv_agency_MarkedTaxable] 
@Taxable Integer OUTPUT
AS

SELECT @Taxable = FLAG_TAX_JOBS FROM AGENCY


















