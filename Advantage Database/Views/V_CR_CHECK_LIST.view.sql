CREATE VIEW [dbo].[V_CR_CHECK_LIST]

--insert the next (3) statements at the top of the script while testing
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[V_CR_CHECK_LIST]') and OBJECTPROPERTY(id, N'IsView') = 1)
--drop view [dbo].[V_CR_CHECK_LIST]
--GO

-- #00 12/18/12 - initial version
-- #01 01/12/13 - added check date
-- #02 08/04/16 - omit reversed checks (735-1-2374 - In AR Open Aged data set, CR Check numbers are being limited to 6 characters)
WITH SCHEMABINDING
AS

SELECT a.AR_INV_NBR,
   STUFF( (SELECT ', ' + CAST(c.CR_CHECK_NBR AS varchar(15)) + ' (' + CONVERT(varchar, c.CR_CHECK_DATE,1) + ')'			
           FROM dbo.V_CR_CHECK_NBRS AS c
           WHERE a.AR_INV_NBR = c.AR_INV_NBR
           ORDER BY c.CR_CHECK_NBR
           FOR XML PATH('')),1 ,2 ,'')
   AS CHECK_NBR_LIST
FROM dbo.V_CR_CHECK_NBRS AS a

GROUP BY a.AR_INV_NBR;


GO


