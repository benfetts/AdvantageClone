

CREATE PROCEDURE [dbo].[usp_wv_email_get_groups] 
    @DefaultGroup VARCHAR(50),
    @JOB_NUMBER INT,
    @JOB_COMPONENT_NBR SMALLINT,
    @AUTO_GROUP SMALLINT
AS

 
    IF @JOB_NUMBER IS NULL
    BEGIN
	    SET @JOB_NUMBER = 0
    END
    IF @JOB_COMPONENT_NBR IS NULL
    BEGIN
	    SET @JOB_COMPONENT_NBR = 0
    END
    IF @AUTO_GROUP IS NULL
    BEGIN
	    SET @AUTO_GROUP = 0
    END

    DECLARE
    @ListAll INT

    DECLARE @EMAIL_GRPS TABLE (GroupCode VARCHAR(255), 
								    EmpCode VARCHAR(150), 
								    AlertEmail INT,
								    EmpName VARCHAR(255),
								    Email VARCHAR(2000),
								    REC_ORDER INT)
    								
    IF @JOB_NUMBER > 0 AND @JOB_COMPONENT_NBR > 0 AND @AUTO_GROUP = 1
    BEGIN
    --------------------
	    INSERT INTO @EMAIL_GRPS(GroupCode,EmpCode,AlertEmail,EmpName,Email,REC_ORDER)
	    SELECT A.GroupCode,A.EmpCode,A.AlertEmail,A.EmpName,A.Email,0
	    FROM
	    (
		    SELECT 'Assigned Employees' AS GroupCode,
			       JOB_TRAFFIC.ASSIGN_1 AS EmpCode,
			       EMPLOYEE.ALERT_EMAIL AS AlertEmail,
			       ISNULL(EMPLOYEE.EMP_LNAME + ', ', '') + ISNULL(EMPLOYEE.EMP_FNAME + ' ', ' ') 
			       +
			       ISNULL(EMPLOYEE.EMP_MI + '. ', '') AS EmpName,
			       ISNULL(EMPLOYEE.EMP_EMAIL,'') AS Email
		    FROM   JOB_TRAFFIC WITH(NOLOCK)
			       INNER JOIN EMPLOYEE WITH(NOLOCK)
					    ON  JOB_TRAFFIC.ASSIGN_1 = EMPLOYEE.EMP_CODE
		    WHERE  (JOB_TRAFFIC.JOB_NUMBER = @JOB_NUMBER)
			       AND (JOB_TRAFFIC.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
			       AND (NOT (JOB_TRAFFIC.ASSIGN_1 IS NULL))
		    UNION
		    --2.
		    SELECT 'Assigned Employees' AS GroupCode,
			       JOB_TRAFFIC.ASSIGN_2 AS EmpCode,
			       EMPLOYEE.ALERT_EMAIL AS AlertEmail,
			       ISNULL(EMPLOYEE.EMP_LNAME + ', ', '') + ISNULL(EMPLOYEE.EMP_FNAME + ' ', ' ') 
			       +
			       ISNULL(EMPLOYEE.EMP_MI + '. ', '') AS EmpName,
			       ISNULL(EMPLOYEE.EMP_EMAIL,'') AS Email
		    FROM   JOB_TRAFFIC WITH(NOLOCK)
			       INNER JOIN EMPLOYEE WITH(NOLOCK)
					    ON  JOB_TRAFFIC.ASSIGN_2 = EMPLOYEE.EMP_CODE
		    WHERE  (JOB_TRAFFIC.JOB_NUMBER = @JOB_NUMBER)
			       AND (JOB_TRAFFIC.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
			       AND (NOT (JOB_TRAFFIC.ASSIGN_2 IS NULL))
		    UNION
		    --3.
		    SELECT 'Assigned Employees' AS GroupCode,
			       JOB_TRAFFIC.ASSIGN_3 AS EmpCode,
			       EMPLOYEE.ALERT_EMAIL AS AlertEmail,
			       ISNULL(EMPLOYEE.EMP_LNAME + ', ', '') + ISNULL(EMPLOYEE.EMP_FNAME + ' ', ' ') 
			       +
			       ISNULL(EMPLOYEE.EMP_MI + '. ', '') AS EmpName,
			       ISNULL(EMPLOYEE.EMP_EMAIL,'') AS Email
		    FROM   JOB_TRAFFIC WITH(NOLOCK)
			       INNER JOIN EMPLOYEE WITH(NOLOCK)
					    ON  JOB_TRAFFIC.ASSIGN_3 = EMPLOYEE.EMP_CODE
		    WHERE  (JOB_TRAFFIC.JOB_NUMBER = @JOB_NUMBER)
			       AND (JOB_TRAFFIC.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
			       AND (NOT (JOB_TRAFFIC.ASSIGN_3 IS NULL))
		    UNION
		    --4.
		    SELECT 'Assigned Employees' AS GroupCode,
			       JOB_TRAFFIC.ASSIGN_4 AS EmpCode,
			       EMPLOYEE.ALERT_EMAIL AS AlertEmail,
			       ISNULL(EMPLOYEE.EMP_LNAME + ', ', '') + ISNULL(EMPLOYEE.EMP_FNAME + ' ', ' ') 
			       +
			       ISNULL(EMPLOYEE.EMP_MI + '. ', '') AS EmpName,
			       ISNULL(EMPLOYEE.EMP_EMAIL,'') AS Email
		    FROM   JOB_TRAFFIC WITH(NOLOCK)
			       INNER JOIN EMPLOYEE WITH(NOLOCK)
					    ON  JOB_TRAFFIC.ASSIGN_4 = EMPLOYEE.EMP_CODE
		    WHERE  (JOB_TRAFFIC.JOB_NUMBER = @JOB_NUMBER)
			       AND (JOB_TRAFFIC.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
			       AND (NOT (JOB_TRAFFIC.ASSIGN_4 IS NULL))
		    UNION
		    --5.
		    SELECT 'Assigned Employees' AS GroupCode,
			       JOB_TRAFFIC.ASSIGN_5 AS EmpCode,
			       EMPLOYEE.ALERT_EMAIL AS AlertEmail,
			       ISNULL(EMPLOYEE.EMP_LNAME + ', ', '') + ISNULL(EMPLOYEE.EMP_FNAME + ' ', ' ') 
			       +
			       ISNULL(EMPLOYEE.EMP_MI + '. ', '') AS EmpName,
			       ISNULL(EMPLOYEE.EMP_EMAIL,'') AS Email
		    FROM   JOB_TRAFFIC WITH(NOLOCK)
			       INNER JOIN EMPLOYEE WITH(NOLOCK)
					    ON  JOB_TRAFFIC.ASSIGN_5 = EMPLOYEE.EMP_CODE
		    WHERE  (JOB_TRAFFIC.JOB_NUMBER = @JOB_NUMBER)
			       AND (JOB_TRAFFIC.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
			       AND (NOT (JOB_TRAFFIC.ASSIGN_5 IS NULL))
		    UNION

	    --GET THE COMP'S AE:
		    SELECT 'Assigned Employees' AS GroupCode,
			       JOB_COMPONENT.EMP_CODE AS EmpCode,
			       EMPLOYEE.ALERT_EMAIL AS AlertEmail,
			       ISNULL(EMPLOYEE.EMP_LNAME + ', ', '') + ISNULL(EMPLOYEE.EMP_FNAME + ' ', ' ') 
			       +
			       ISNULL(EMPLOYEE.EMP_MI + '. ', '') AS EmpName,
			       ISNULL(EMPLOYEE.EMP_EMAIL,'') AS Email
		    FROM   JOB_COMPONENT WITH(NOLOCK)
			       INNER JOIN EMPLOYEE WITH(NOLOCK)
					    ON  JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE
		    WHERE  (JOB_COMPONENT.JOB_NUMBER = @JOB_NUMBER)
			       AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)

		    UNION
	    --GET THE SCHEDULE'S EMPLOYEES	
		    SELECT 'Assigned Employees' AS GroupCode,
			       JOB_TRAFFIC_DET_EMPS.EMP_CODE AS EmpCode,
			       EMPLOYEE.ALERT_EMAIL AS AlertEmail,	
			       ISNULL(EMPLOYEE.EMP_LNAME + ', ', '') + ISNULL(EMPLOYEE.EMP_FNAME + ' ', ' ') 
			       +
			       ISNULL(EMPLOYEE.EMP_MI + '. ', '') AS EmpName,
			       ISNULL(EMPLOYEE.EMP_EMAIL,'') AS Email
		    FROM   JOB_TRAFFIC_DET_EMPS WITH(NOLOCK)
			       INNER JOIN EMPLOYEE WITH(NOLOCK)
					    ON  JOB_TRAFFIC_DET_EMPS.EMP_CODE = EMPLOYEE.EMP_CODE
		    WHERE  (JOB_TRAFFIC_DET_EMPS.JOB_NUMBER = @JOB_NUMBER)
			       AND (
					       JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
				       )

	    )AS A

    -------------------	
    END

    								
    SELECT @ListAll = ISNULL(EMP_ON_ALERT_LIST,0) FROM AGENCY WITH(NOLOCK);

    IF @ListAll = 1
	    BEGIN
		    INSERT INTO @EMAIL_GRPS(GroupCode,EmpCode,AlertEmail,EmpName,Email,REC_ORDER)
		    SELECT 
			    ISNULL(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(EMAIL_GROUP.EMAIL_GR_CODE,'\','-'),'/','-'),'&','and'),'''',''),',',''),'') AS GroupCode, 
			    ISNULL(EMAIL_GROUP.EMP_CODE,'') AS EmpCode, 
			    ISNULL(EMPLOYEE.ALERT_EMAIL,'0') AS AlertEmail, 
		        ISNULL(EMPLOYEE.EMP_LNAME + ', ', '') + ISNULL(EMPLOYEE.EMP_FNAME + ' ', ' ') 
		        +
		        ISNULL(EMPLOYEE.EMP_MI + '. ', '') AS EmpName,
			    ISNULL(EMPLOYEE.EMP_EMAIL,'') AS Email, 1
		    FROM 
			    EMAIL_GROUP WITH(NOLOCK) LEFT OUTER JOIN EMPLOYEE ON
			    EMAIL_GROUP.EMP_CODE = EMPLOYEE.EMP_CODE
	    END
    ELSE --try to show only the default
	    BEGIN
	        IF @DefaultGroup <> ''
		    INSERT INTO @EMAIL_GRPS(GroupCode,EmpCode,AlertEmail,EmpName,Email,REC_ORDER)
		        SELECT 
			        ISNULL(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(EMAIL_GROUP.EMAIL_GR_CODE,'\','-'),'/','-'),'&','and'),'''',''),',',''),'') AS GroupCode, 
			        ISNULL(EMAIL_GROUP.EMP_CODE,'') AS EmpCode, 
			        ISNULL(EMPLOYEE.ALERT_EMAIL,'0') AS AlertEmail, 
				    ISNULL(EMPLOYEE.EMP_LNAME + ', ', '') + ISNULL(EMPLOYEE.EMP_FNAME + ' ', ' ') 
				    +
				    ISNULL(EMPLOYEE.EMP_MI + '. ', '') AS EmpName,
			        ISNULL(EMPLOYEE.EMP_EMAIL,'') AS Email, 1
		        FROM 
			        EMAIL_GROUP WITH(NOLOCK) LEFT OUTER JOIN EMPLOYEE ON
			        EMAIL_GROUP.EMP_CODE = EMPLOYEE.EMP_CODE
		        WHERE
			        EMAIL_GROUP.EMAIL_GR_CODE = @DefaultGroup
	        ELSE
		    INSERT INTO @EMAIL_GRPS(GroupCode,EmpCode,AlertEmail,EmpName,Email,REC_ORDER)
		        SELECT 
			        ISNULL(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(EMAIL_GROUP.EMAIL_GR_CODE,'\','-'),'/','-'),'&','and'),'''',''),',',''),'') AS GroupCode, 
			        ISNULL(EMAIL_GROUP.EMP_CODE,'') AS EmpCode, 
			        ISNULL(EMPLOYEE.ALERT_EMAIL,'0') AS AlertEmail, 
				    ISNULL(EMPLOYEE.EMP_LNAME + ', ', '') + ISNULL(EMPLOYEE.EMP_FNAME + ' ', ' ') 
				    +
				    ISNULL(EMPLOYEE.EMP_MI + '. ', '') AS EmpName,
			        ISNULL(EMPLOYEE.EMP_EMAIL,'') AS Email, 1
		        FROM 
			        EMAIL_GROUP WITH(NOLOCK) LEFT OUTER JOIN EMPLOYEE ON
			        EMAIL_GROUP.EMP_CODE = EMPLOYEE.EMP_CODE
	    END



    SELECT 
    ISNULL(GroupCode,'') AS GroupCode,
    ISNULL(EmpCode,'') AS EmpCode, 
    ISNULL(AlertEmail,0) AS AlertEmail,
    ISNULL(EmpName,'') AS EmpName,
    ISNULL(Email,'') AS Email,
    ISNULL(REC_ORDER,999) AS REC_ORDER
    FROM @EMAIL_GRPS 
    ORDER BY REC_ORDER, GroupCode, EmpName;









