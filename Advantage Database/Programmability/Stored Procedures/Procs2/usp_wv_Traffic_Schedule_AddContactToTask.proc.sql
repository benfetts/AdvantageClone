

CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_AddContactToTask]
	@JobNum int,
	@JobCompNum int,
	@SeqNum smallint,
	@CDPID int
AS

INSERT INTO [dbo].[JOB_TRAFFIC_DET_CNTS] (
	[JOB_NUMBER],
	[JOB_COMPONENT_NBR],
	[SEQ_NBR],
	[CDP_CONTACT_ID]
) 
VALUES (
	@JobNum,
	@JobCompNum,
	@SeqNum,
	@CDPID
)


