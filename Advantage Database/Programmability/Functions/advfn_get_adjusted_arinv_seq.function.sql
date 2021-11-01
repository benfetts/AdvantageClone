CREATE FUNCTION [dbo].[advfn_get_adjusted_arinv_seq] 
	( @actual_seq integer, @coop_master_seq integer ) RETURNS integer
AS
-- BJL 01/30/2013 - The only purpose of this function is to ensure that the sequence number used in coop billing
--					for the master record is not used for the splits.
BEGIN
	DECLARE @adjusted_seq integer
	
	IF ( @coop_master_seq < 0 )
		SET @adjusted_seq = @actual_seq
	ELSE
	BEGIN
		IF ( @actual_seq >= @coop_master_seq )
			SET @adjusted_seq = @actual_seq + 1
		ELSE	
			SET @adjusted_seq = @actual_seq
	END
	
	RETURN @adjusted_seq
END
GO	
