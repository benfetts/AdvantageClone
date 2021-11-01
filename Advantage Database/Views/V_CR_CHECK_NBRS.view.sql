CREATE VIEW [dbo].[V_CR_CHECK_NBRS]

--insert the next (3) statements at the top of the script while debugging
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[V_CR_CHECK_NBRS]') and OBJECTPROPERTY(id, N'IsView') = 1)
--drop view [dbo].[V_CR_CHECK_NBRS]
--GO

-- creates a list of distinct invoice and rec_id's for use in V_CR_CHECK_LIST
-- #00 12/18/12 - initial version
-- #01 01/12/13 - added check date
-- #02 08/04/16 - omit reversed checks (735-1-2374 - In AR Open Aged data set, CR Check numbers are being limited to 6 characters)
WITH SCHEMABINDING
AS

	SELECT DISTINCT 
		d.AR_INV_NBR,
		c.CR_CHECK_NBR,
		c.CR_CHECK_DATE
	FROM dbo.CR_CLIENT_DTL AS d
	JOIN dbo.CR_CLIENT AS c
		ON d.REC_ID = c.REC_ID AND c.[STATUS] IS NULL


GO


