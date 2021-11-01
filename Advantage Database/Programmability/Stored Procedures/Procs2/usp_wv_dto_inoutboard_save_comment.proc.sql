if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_inoutboard_save_comment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_inoutboard_save_comment]
GO

CREATE PROCEDURE [dbo].[usp_wv_dto_inoutboard_save_comment] 
@EMP_CODE VARCHAR(6),
@Comment varchar(50),
@Reference int
AS
	
BEGIN

	UPDATE EMP_INOUTBOARD
	SET COMMENT = @Comment
	WHERE INOUT_REF = @Reference

END
	