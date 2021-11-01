IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_sprint_reorder_by_due_date]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_sprint_reorder_by_due_date]
GO

CREATE PROCEDURE [dbo].[advsp_agile_sprint_reorder_by_due_date]
@SPRINT_ID INT,
@USER_CODE VARCHAR(100),
@REORDER_BACKLOG BIT,
@REORDER_BOARD BIT
AS
/*=========== QUERY ===========*/
BEGIN
    DECLARE @CARDS TABLE
						(
							SprintHeaderID        INT,
							SprintDetailID        INT,
							TaskSequenceNumber    SMALLINT,
							AlertID               INT,
							SequenceNumber        SMALLINT,
							JobNumber             INT,
							JobComponentNumber    SMALLINT,
							[Priority]            SMALLINT,
							EmployeeCode          VARCHAR(6),
							Title                 VARCHAR(MAX),
							BoardColumnID         INT,
							BoardColumnStateCount INT,
							CompleteDate          SMALLDATETIME,
							CreateDate            SMALLDATETIME,
							LastMovedDate         SMALLDATETIME,
							FullName              VARCHAR(500),
							AssignedEmployeeCode  VARCHAR(6),
							AlertTemplateID       INT,
							AlertStateID          INT,
							AlertStateName        VARCHAR(100),
							IsWorkItem            BIT,
							IsBoardBacklog        BIT,
							ClientName            VARCHAR(40),
							JobName               VARCHAR(500),
							StartDate             SMALLDATETIME,
							DueDate               SMALLDATETIME,
							CardQueryID           INT,
							HoursAllowed          DECIMAL(7, 2),
							BoardStateID          INT,
							BoardStateName        VARCHAR(100),
							IsTask                BIT,
							Indicator             VARCHAR(1),
							AlertCategoryID       INT,
							AlertCategoryName     VARCHAR(40),
							TimeDue               VARCHAR(10),
							LastModifiedDate      SMALLDATETIME,
							DueDateIsNull         BIT,
							TaskGridOrderIsNull   BIT,
							TaskGridOrder         INT,
							LastModifiedBy	      VARCHAR(75),
							MyTask				  BIT,
							MyTaskCompleted		  BIT,
							AssignNumber	      INT,
							IsRead				  BIT,
							ShowChecklists		  BIT,
							ChecklistComplete		  INT,
							ChecklistTotal INT,
							ShowHours			  BIT,
							HoursAllocated		  DECIMAL(7, 2),
							HoursTotal			  DECIMAL(7, 2)
						);
    SET @REORDER_BACKLOG = ISNULL(@REORDER_BACKLOG, 0);
    SET @REORDER_BOARD = ISNULL(@REORDER_BOARD, 0);
    INSERT INTO @CARDS
    EXEC [dbo].[advsp_agile_get_sprint_details]
         @SPRINT_ID,
         @USER_CODE,
         1,
		 0;
    IF @REORDER_BACKLOG = 0
        BEGIN
            DELETE FROM @CARDS
            WHERE SprintDetailID = -1;
        END;
    IF @REORDER_BOARD = 0
        BEGIN
            DELETE FROM @CARDS
            WHERE SprintDetailID > 0;
        END;
    IF @REORDER_BACKLOG = 1
       OR @REORDER_BOARD = 1
        BEGIN

            --SELECT A.ALERT_ID, A.BACKLOG_SEQ_NBR
            UPDATE ALERT
              SET
                  BACKLOG_SEQ_NBR = NULL
            FROM ALERT A
                 INNER JOIN @CARDS C ON A.ALERT_ID = C.AlertID;
		
            --SELECT SD.ALERT_ID, SD.SEQ_NBR
            UPDATE SPRINT_DTL
              SET
                  SEQ_NBR = NULL
            FROM SPRINT_DTL SD
                 INNER JOIN SPRINT_HDR SH ON SD.SPRINT_HDR_ID = SH.ID
                 INNER JOIN @CARDS C ON SD.ALERT_ID = C.AlertID
            WHERE SH.ID = @SPRINT_ID;
        END;
	-- ALLOW "NATURAL SORT" TO TAKE OVER, DON'T DO BELOW
    ----IF @REORDER_BACKLOG = 1
    ----    BEGIN

    ----        --SELECT Z.*
    ----        UPDATE ALERT
    ----          SET
    ----              BACKLOG_SEQ_NBR = Z.NewSeq
    ----        FROM
    ----        (
    ----            SELECT ROW_NUMBER() OVER(ORDER BY DueDateIsNull,
    ----                                              DueDate,
    ----                                              TaskGridOrderIsNull,
    ----                                              TaskGridOrder,
    ----                                              Priority,
				----								  LastModifiedDate,
    ----                                              CreateDate) AS NewSeq,
    ----                   C.DueDate,
    ----                   C.AlertID
    ----            FROM @CARDS C
    ----                 INNER JOIN ALERT A ON C.AlertID = A.ALERT_ID
    ----            WHERE C.SprintDetailID = -1
    ----        ) AS Z
    ----        INNER JOIN ALERT AA ON Z.AlertID = AA.ALERT_ID;
    ----    END;
    ----IF @REORDER_BOARD = 1
    ----    BEGIN

    ----        --SELECT Z.*
    ----        UPDATE SPRINT_DTL
    ----          SET
    ----              SEQ_NBR = Z.NewSeq
    ----        FROM
    ----        (
    ----            SELECT ROW_NUMBER() OVER(ORDER BY DueDateIsNull,
    ----                                              DueDate,
    ----                                              TaskGridOrderIsNull,
    ----                                              TaskGridOrder,
    ----                                              Priority,
				----								  LastModifiedDate,
    ----                                              CreateDate) AS NewSeq,
    ----                   C.DueDate,
    ----                   C.AlertID
    ----            FROM @CARDS C
    ----                 INNER JOIN SPRINT_DTL SD ON C.SprintDetailID = SD.ID
    ----            WHERE C.SprintDetailID > 0
    ----        ) AS Z
    ----        INNER JOIN SPRINT_DTL SD ON Z.AlertID = SD.ALERT_ID;
    ----    END;

END;
/*=========== QUERY ===========*/