IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_billing_approval_are_all_jobs_approved_for_batch]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_billing_approval_are_all_jobs_approved_for_batch]
GO

CREATE PROCEDURE [dbo].[advsp_billing_approval_are_all_jobs_approved_for_batch] 
@BA_BATCH_ID INT
AS
BEGIN
/*============= QUERY =============*/
	DECLARE 
		@JOB_COUNT INT,
		@APPROVED_JOB_COUNT INT,
		@ALL_JOBS_APPROVED BIT


	SELECT
		@JOB_COUNT = COUNT(1)
	FROM
		JOB_COMPONENT JC WITH(NOLOCK)
	WHERE
		JC.BA_BATCH_ID = @BA_BATCH_ID;

	SELECT 
		@APPROVED_JOB_COUNT = COUNT(1)
	FROM 
		BILL_APPR_BATCH BAB WITH(NOLOCK)
		INNER JOIN BILL_APPR BA WITH(NOLOCK) ON BAB.BA_BATCH_ID = BA.BA_BATCH_ID
		INNER JOIN BILL_APPR_HDR BAH WITH(NOLOCK) ON BA.BA_ID = BAH.BA_ID
	WHERE 
		BAB.BA_BATCH_ID = @BA_BATCH_ID
		AND BAH.APPR_STATUS IS NULL;

	IF @APPROVED_JOB_COUNT >= @JOB_COUNT
	BEGIN
		SET @ALL_JOBS_APPROVED = 1;
	END
	ELSE
	BEGIN
		SET @ALL_JOBS_APPROVED = 0;
	END

	SELECT @ALL_JOBS_APPROVED AS AllJobsAreApproved;
/*============= QUERY =============*/
END