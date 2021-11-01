USE [msdb]
GO

/****** Object:  Job [Update Hosted Nielsen Radio Tables from Data Store]    Script Date: 10/20/2017 7:40:01 AM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 10/20/2017 7:40:01 AM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'Update Hosted Nielsen Radio Tables from Data Store', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'No description available.', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'SYSADM', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Old Periods]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Old Periods', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'DELETE NIELSENHOSTED.dbo.NIELSEN_RADIO_PERIOD
WHERE NIELSEN_RADIO_PERIOD_ID NOT IN
	(
	SELECT NIELSEN_RADIO_PERIOD_ID
	FROM NIELSENDATASTORE.dbo.NIELSEN_RADIO_PERIOD
	)', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Period]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Period', 
		@step_id=2, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Period.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Segment Child]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Segment Child', 
		@step_id=3, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Segment Child.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Segment Parent]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Segment Parent', 
		@step_id=4, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Segment Parent.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Audience]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Audience', 
		@step_id=5, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Audience.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Demographic]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Demographic', 
		@step_id=6, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Demographic.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Intab]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Intab', 
		@step_id=7, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Intab.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Market]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Market', 
		@step_id=8, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Market.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [PUR]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'PUR', 
		@step_id=9, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio PUR.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Qualitative]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Qualitative', 
		@step_id=10, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Qualitative.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Station]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Station', 
		@step_id=11, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Station.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Station History]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Station History', 
		@step_id=12, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Station History.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Universe]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Universe', 
		@step_id=13, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen Radio Universe.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Validate Radio Periods]    Script Date: 10/20/2017 7:40:01 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Validate Radio Periods', 
		@step_id=14, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec [advsp_hosted_validate_radio_periods]', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'Daily at midnight', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20170810, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, 
		@schedule_uid=N'7c8446aa-d4f3-4bc1-b062-ea6cb7f4cb37'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO

