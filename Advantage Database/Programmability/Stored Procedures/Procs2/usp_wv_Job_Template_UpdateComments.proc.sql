

CREATE PROCEDURE [dbo].[usp_wv_Job_Template_UpdateComments] 
@JOB_NUMBER AS int,
@JOB_COMPONENT_NBR AS int,
@Type as varchar(50),
@Comment Text,
@CommentHtml Text


AS

BEGIN
	SET NOCOUNT OFF
	if @Type = 'jobcomments'
		Begin
			UPDATE [JOB_LOG] WITH(ROWLOCK)
			SET
			  [JOB_COMMENTS] = @Comment,
			  [JOB_COMMENTS_HTML] = @commentHtml
			WHERE
			  [JOB_NUMBER] = @JOB_NUMBER
		End
	if @Type = 'jobcompcomments'
		Begin
			UPDATE [JOB_COMPONENT] WITH(ROWLOCK)
			SET
			  [JOB_COMP_COMMENTS] = @Comment,
			  [JC_COMMENTS_HTML] = @commentHtml
			WHERE
			  [JOB_NUMBER] = @JOB_NUMBER AND 
			  [JOB_COMPONENT_NBR] = @JOB_COMPONENT_NBR
		End
	if @Type = 'creativeinstr'
		Begin
			UPDATE [JOB_COMPONENT] WITH(ROWLOCK)
			SET
			  [CREATIVE_INSTR] = @Comment,
			  [CREATIVE_INSTR_HTML] = @commentHtml
			WHERE
			  [JOB_NUMBER] = @JOB_NUMBER AND 
			  [JOB_COMPONENT_NBR] = @JOB_COMPONENT_NBR
		End
	if @Type = 'jobdelinstruct'
		Begin
			UPDATE [JOB_COMPONENT] WITH(ROWLOCK)
			SET
			  [JOB_DEL_INSTRUCT] = @Comment,
			  [JOB_DEL_INSTR_HTML] = @commentHtml
			WHERE
			  [JOB_NUMBER] = @JOB_NUMBER AND 
			  [JOB_COMPONENT_NBR] = @JOB_COMPONENT_NBR
		End
	    
			

	
END


