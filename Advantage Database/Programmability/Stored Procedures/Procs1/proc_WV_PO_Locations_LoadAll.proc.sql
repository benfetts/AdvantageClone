

CREATE PROCEDURE [dbo].[proc_WV_PO_Locations_LoadAll](@funct as integer, @userid varchar(100)) AS 

  -- locations where Purchase Orders can be generated / printed. UserID passed for future use if user/locations linked.

  -- exec proc_WV_PO_Locations_LoadAll 1, 'SYSADM'

   if @funct=1
     begin
       select [ID] as LOCATION_ID, isnull([ID],'') + ' - ' +   isnull([NAME],'') as LOC_NAME  from LOCATIONS  order by [ID]
     end


