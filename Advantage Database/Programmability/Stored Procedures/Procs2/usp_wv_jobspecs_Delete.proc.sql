




CREATE PROCEDURE [dbo].[usp_wv_jobspecs_Delete]
@JobNumber int,
@JobCompNumber int,
@Version int,
@Revision int,
@Quantity bit,
@VersionDelete bit,
@RevisionDelete bit

AS
DECLARE @EstNum Int, @EstComp int, @VerCount int
if @VersionDelete = 1
	Begin
		DELETE FROM [dbo].[JOB_SPECS] 
		WHERE 
			JOB_COMPONENT_NBR = @JobCompNumber 
			AND JOB_NUMBER = @JobNumber
			AND SPEC_VER = @Version

		if @Quantity = 1
			Begin

			DELETE FROM [dbo].[JOB_SPEC_QTY]
			WHERE 
				JOB_COMPONENT_NBR = @JobCompNumber 
				AND JOB_NUMBER = @JobNumber
				AND SPEC_VER = @Version

			End
		SELECT @EstNum = ISNULL(ESTIMATE_NUMBER,0), @EstComp = ISNULL(EST_COMPONENT_NBR,0)
		FROM JOB_COMPONENT
		WHERE JOB_COMPONENT_NBR = @JobCompNumber 
				AND JOB_NUMBER = @JobNumber

		if @EstNum <> 0
		Begin
			SELECT @VerCount = COUNT(*) 
			FROM ESTIMATE_REV 
			WHERE ESTIMATE_NUMBER = @EstNum AND EST_COMPONENT_NBR = @EstComp AND SPEC_VER = @Version

			if @VerCount > 0
			Begin
				UPDATE [dbo].[ESTIMATE_REV]
				SET SPEC_VER = NULL, SPEC_REV = NULL
				WHERE ESTIMATE_NUMBER = @EstNum AND EST_COMPONENT_NBR = @EstComp AND SPEC_VER = @Version
			End
		End

	End

if @RevisionDelete = 1
	Begin
		DELETE FROM [dbo].[JOB_SPECS] 
		WHERE 
			JOB_COMPONENT_NBR = @JobCompNumber 
			AND JOB_NUMBER = @JobNumber
			AND SPEC_VER = @Version
			AND SPEC_REV = @Revision

		if @Quantity = 1
			Begin

			DELETE FROM [dbo].[JOB_SPEC_QTY]
			WHERE 
				JOB_COMPONENT_NBR = @JobCompNumber 
				AND JOB_NUMBER = @JobNumber
				AND SPEC_VER = @Version
				AND SPEC_REV = @Revision

			End
	End






















