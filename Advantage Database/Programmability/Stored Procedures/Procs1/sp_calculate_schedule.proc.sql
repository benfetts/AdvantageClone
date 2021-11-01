

CREATE PROCEDURE [dbo].[sp_calculate_schedule] 
	@job_number integer, @job_component_nbr smallint, @ret_val integer OUTPUT
AS

EXECUTE dbo.advsp_calculate_schedule @job_number, @job_component_nbr, 0, @ret_val = @ret_val OUTPUT
