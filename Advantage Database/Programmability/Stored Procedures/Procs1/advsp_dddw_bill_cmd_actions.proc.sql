
CREATE PROCEDURE [dbo].[advsp_dddw_bill_cmd_actions] 
AS
SET NOCOUNT ON

CREATE TABLE #bill_cmd_acts(
	ACTION_TYPE 					smallint,
	ACTION_ID						smallint,
	ACTION_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS )

INSERT INTO #bill_cmd_acts( ACTION_TYPE, ACTION_ID, ACTION_DESC )
     VALUES ( 0, 0, 'No Change' )

INSERT INTO #bill_cmd_acts
	 SELECT 1, JOB_PROCESS_CONTRL, JOB_PROCESS_DESC
	   FROM dbo.JOB_PROC_CONTROLS

INSERT INTO #bill_cmd_acts( ACTION_TYPE, ACTION_ID, ACTION_DESC )
     VALUES ( 2, 1, 'Hold Job' )

INSERT INTO #bill_cmd_acts( ACTION_TYPE, ACTION_ID, ACTION_DESC )
     VALUES ( 3, 0, 'Interim Reconcile' )

INSERT INTO #bill_cmd_acts( ACTION_TYPE, ACTION_ID, ACTION_DESC )
     VALUES ( 3, 1, 'Final Reconcile To Actual & Bill' )

INSERT INTO #bill_cmd_acts( ACTION_TYPE, ACTION_ID, ACTION_DESC )
     VALUES ( 3, 2, 'Final Reconcile To Quote & Bill' )

INSERT INTO #bill_cmd_acts( ACTION_TYPE, ACTION_ID, ACTION_DESC )
     VALUES ( 3, 3, 'Final Reconcile To Billed' )

INSERT INTO #bill_cmd_acts( ACTION_TYPE, ACTION_ID, ACTION_DESC )
     VALUES ( 4, 1, 'Recognize Income' )

SELECT * FROM #bill_cmd_acts ORDER BY 1, 2

DROP TABLE #bill_cmd_acts
