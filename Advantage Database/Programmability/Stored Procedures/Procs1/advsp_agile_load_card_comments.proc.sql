IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_load_card_comments]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_load_card_comments]
GO


CREATE PROCEDURE [dbo].[advsp_agile_load_card_comments] /*WITH ENCRYPTION*/
@ALERT_ID INT
AS
/*=========== QUERY ===========*/
BEGIN

    DECLARE @CARD_COMMENTS TABLE (CommentID INT,
						    Comment VARCHAR(MAX),
						    CommentDate SMALLDATETIME,
						    UserCode VARCHAR(100),
						    CommentDateString VARCHAR(100),
						    FullName VARCHAR(1000),
						    EmployeePicture IMAGE,
						    EmployeePictureURL VARCHAR(MAX)
						    )
						
    INSERT INTO @CARD_COMMENTS (CommentID, Comment, CommentDate, UserCode, FullName, EmployeePicture)
    SELECT
	   AC.COMMENT_ID, AC.COMMENT, AC.GENERATED_DATE, AC.USER_CODE, ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''), EP.EMP_IMAGE
    FROM 
	   ALERT_COMMENT AC
	   INNER JOIN SEC_USER SU ON AC.USER_CODE = SU.USER_CODE
	   INNER JOIN EMPLOYEE E ON SU.EMP_CODE = E.EMP_CODE
	   LEFT OUTER JOIN EMPLOYEE_PICTURE EP ON SU.EMP_CODE = EP.EMP_CODE
    WHERE 
	   AC.ALERT_ID = @ALERT_ID;

    SELECT * FROM @CARD_COMMENTS;

END
/*=========== QUERY ===========*/