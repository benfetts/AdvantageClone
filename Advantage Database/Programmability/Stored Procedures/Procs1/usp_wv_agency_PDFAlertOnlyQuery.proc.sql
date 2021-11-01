


















CREATE PROCEDURE [dbo].[usp_wv_agency_PDFAlertOnlyQuery] 
@PDFAlertOnly Integer OUTPUT
AS

SELECT @PDFAlertOnly = PDF_ALERT_ONLY FROM AGENCY


















