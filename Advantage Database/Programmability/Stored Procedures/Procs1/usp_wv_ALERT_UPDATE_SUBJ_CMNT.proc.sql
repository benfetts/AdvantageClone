CREATE PROCEDURE [dbo].[usp_wv_ALERT_UPDATE_SUBJ_CMNT] 
@USER_CODE        VARCHAR(100),
@ALERT_ID         INT,
@SUBJECT          VARCHAR(254),
@BODY             TEXT,	
@BODY_HTML        TEXT,
@SUBJECT_CHANGED  SMALLINT,
@BODY_CHANGED     SMALLINT
AS
/*=========== QUERY ===========*/
    DECLARE @HAS_CHANGE       SMALLINT
    DECLARE @NEW_COMMENT	  VARCHAR(4000)

    IF @SUBJECT_CHANGED = 0 AND @BODY_CHANGED = 0
	    BEGIN
		    SET @HAS_CHANGE = 0;
		    SET @NEW_COMMENT = '';
	    END
    ELSE
	    BEGIN
		    SET @HAS_CHANGE = 1;
	    END
    	
    IF @HAS_CHANGE = 1
    BEGIN
    	DECLARE @NEW_COMMENT_ID INT
    	
	    IF @SUBJECT_CHANGED = 1 AND @BODY_CHANGED = 0
		    BEGIN
			    SET @NEW_COMMENT = 'Subject changed.';
		    END
    		
	    IF @SUBJECT_CHANGED = 0 AND @BODY_CHANGED = 1
		    BEGIN
			    SET @NEW_COMMENT = 'Description changed.';
		    END
	    IF @SUBJECT_CHANGED = 1 AND @BODY_CHANGED = 1
		    BEGIN
			    SET @NEW_COMMENT = 'Subject and Description changed.';
		    END

	    SET @NEW_COMMENT = 'Subject/Description changed.';

    	
        UPDATE ALERT WITH(ROWLOCK)
        SET    [SUBJECT] = @SUBJECT,
               BODY = @BODY,
               BODY_HTML = @BODY_HTML
        WHERE  ALERT_ID = @ALERT_ID;
        
 		IF NOT @NEW_COMMENT IS NULL
		BEGIN
		   INSERT INTO ALERT_COMMENT WITH(ROWLOCK)
			  (
				ALERT_ID,
				USER_CODE,
				GENERATED_DATE,
				COMMENT,
				EMAILSENT
			  )
			VALUES
			  (
				@ALERT_ID,
				@USER_CODE,
				GETDATE(),
				@NEW_COMMENT,
				0
			  );
		END
    SELECT @NEW_COMMENT_ID = SCOPE_IDENTITY();      
    END
/*=========== QUERY ===========*/
