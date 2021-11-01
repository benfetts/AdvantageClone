


CREATE PROCEDURE [dbo].[proc_WV_PO_PrintDef_LocationName](@locid varchar(6)) AS


select NAME
from LOCATIONS
WHERE ID = @locid



