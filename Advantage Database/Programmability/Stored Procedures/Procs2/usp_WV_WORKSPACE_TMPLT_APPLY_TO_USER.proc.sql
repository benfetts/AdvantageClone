-- =============================================
-- Script Template 
-- =============================================
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_WV_WORKSPACE_TMPLT_APPLY_TO_USER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_WV_WORKSPACE_TMPLT_APPLY_TO_USER]
GO

CREATE PROCEDURE [dbo].[usp_WV_WORKSPACE_TMPLT_APPLY_TO_USER] /*WITH ENCRYPTION*/
@SEC_USER_ID            INT,
@WORKSPACE_TEMPLATE_ID  INT
AS
/*=========== QUERY ===========*/
IF EXISTS (SELECT * FROM WV_WORKSPACE_TMPLT_HDR WITH(NOLOCK) WHERE TEMPLATE_ID = @WORKSPACE_TEMPLATE_ID)
BEGIN
	DECLARE @USER_CODE VARCHAR(100);
	
	SELECT @USER_CODE = USER_CODE
	FROM   SEC_USER WITH(NOLOCK)
	WHERE  SEC_USER_ID = @SEC_USER_ID;	
  
	DELETE 
	FROM   WV_WORKSPACE_OBJECT WITH(ROWLOCK)
	WHERE  WORKSPACE_ID IN (SELECT WV_USER_WORKSPACE.WORKSPACE_ID
							FROM   WV_USER_WORKSPACE WITH(NOLOCK)
							WHERE  UPPER(WV_USER_WORKSPACE.USER_CODE) = UPPER(@USER_CODE));
     
	DELETE 
	FROM   WV_USER_WORKSPACE WITH(ROWLOCK)
	WHERE  UPPER(WV_USER_WORKSPACE.USER_CODE) = UPPER(@USER_CODE);

	DECLARE @CURR_WORKSPACE_TMPLT_DTL_WORKSPACE_ID  AS INT;
 
	DECLARE MY_ROWS                                 CURSOR  
	FOR
		SELECT WORKSPACE_ID
		FROM   WV_WORKSPACE_TMPLT_DTL WITH(NOLOCK)
		WHERE  TEMPLATE_ID = @WORKSPACE_TEMPLATE_ID
	;
		OPEN MY_ROWS;
			FETCH NEXT FROM MY_ROWS INTO @CURR_WORKSPACE_TMPLT_DTL_WORKSPACE_ID;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @CURR_WORKSPACE_TMPLT_DTL_NAME        VARCHAR(50),
				@CURR_WORKSPACE_TMPLT_DTL_DESC        VARCHAR(100),
				@CURR_WORKSPACE_TMPLT_DTL_SORT_ORDER  INT,
				@CURR_WORKSPACE_TMPLT_DTL_ID          INT,
				@NEW_WORKSPACE_ID                     INT
    
		SELECT @CURR_WORKSPACE_TMPLT_DTL_ID = WORKSPACE_ID,
			   @CURR_WORKSPACE_TMPLT_DTL_NAME = NAME,
			   @CURR_WORKSPACE_TMPLT_DTL_DESC = [DESCRIPTION],
			   @CURR_WORKSPACE_TMPLT_DTL_SORT_ORDER = SORT_ORDER
		FROM   WV_WORKSPACE_TMPLT_DTL WITH(NOLOCK)
		WHERE  WORKSPACE_ID = @CURR_WORKSPACE_TMPLT_DTL_WORKSPACE_ID;
    
		INSERT INTO WV_USER_WORKSPACE WITH
		  (
			ROWLOCK
		  )(USER_CODE, NAME, [DESCRIPTION], SORT_ORDER)
		VALUES
		  (
			@USER_CODE,
			@CURR_WORKSPACE_TMPLT_DTL_NAME,
			@CURR_WORKSPACE_TMPLT_DTL_DESC,
			@CURR_WORKSPACE_TMPLT_DTL_SORT_ORDER
		  );
		SELECT @NEW_WORKSPACE_ID = SCOPE_IDENTITY();
		SELECT @NEW_WORKSPACE_ID = ISNULL(@NEW_WORKSPACE_ID, 0);
		IF @NEW_WORKSPACE_ID > 0
		BEGIN
			INSERT INTO WV_WORKSPACE_OBJECT WITH
			  (
				ROWLOCK
			  )(
				   WORKSPACE_ID,
				   DESKTOP_OBJECT_ID,
				   ZONE_ID,
				   HEIGHT,
				   WIDTH,
				   TOP_COORD,
				   LEFT_COORD,
				   SORT_ORDER
			   )
			SELECT @NEW_WORKSPACE_ID,
				   DESKTOP_OBJECT_ID,
				   ZONE_ID,
				   HEIGHT,
				   WIDTH,
				   TOP_COORD,
				   LEFT_COORD,
				   SORT_ORDER
			FROM   WV_WORKSPACE_TMPLT_ITEM WITH(NOLOCK)
			WHERE  WORKSPACE_ID = @CURR_WORKSPACE_TMPLT_DTL_WORKSPACE_ID;
		END
		--MOVE TO NEXT
		FETCH NEXT FROM MY_ROWS INTO @CURR_WORKSPACE_TMPLT_DTL_WORKSPACE_ID;
	END
		CLOSE MY_ROWS;
		DEALLOCATE MY_ROWS;
	
	DECLARE @FIRST_WORKSPACE INT;

END
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
