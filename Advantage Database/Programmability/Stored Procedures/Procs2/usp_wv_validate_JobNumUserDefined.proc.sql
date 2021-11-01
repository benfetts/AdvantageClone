


















CREATE PROCEDURE [dbo].[usp_wv_validate_JobNumUserDefined]
@JobNum varchar(10),
@UserField varchar(50)

AS

if @UserField = 'JOB_LOG.UDV1_CODE'
	Begin
		SELECT
			COUNT(*)
		FROM
			JOB_LOG_UDV1 WITH (NOLOCK)
		WHERE
			UDV_CODE = @JobNum
	End
if @UserField = 'JOB_LOG.UDV2_CODE'
	Begin
		SELECT
			COUNT(*)
		FROM
			JOB_LOG_UDV2 WITH (NOLOCK)
		WHERE
			UDV_CODE = @JobNum
	End
if @UserField = 'JOB_LOG.UDV3_CODE'
	Begin
		SELECT
			COUNT(*)
		FROM
			JOB_LOG_UDV3 WITH (NOLOCK)
		WHERE
			UDV_CODE = @JobNum
	End
if @UserField = 'JOB_LOG.UDV4_CODE'
	Begin
		SELECT
			COUNT(*)
		FROM
			JOB_LOG_UDV4 WITH (NOLOCK)
		WHERE
			UDV_CODE = @JobNum
	End
if @UserField = 'JOB_LOG.UDV5_CODE'
	Begin
		SELECT
			COUNT(*)
		FROM
			JOB_LOG_UDV5 WITH (NOLOCK)
		WHERE
			UDV_CODE = @JobNum
	End











