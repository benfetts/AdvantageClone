USE [msdb]
GO

/****** Object:  Job [Update Hosted Nielsen TV Tables from Data Store]    Script Date: 10/20/2017 8:34:47 AM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 10/20/2017 8:34:47 AM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'Update Hosted Nielsen TV Tables from Data Store', 
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
/****** Object:  Step [Delete Reissued TV Books]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Reissued TV Books', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec [dbo].[advsp_hosted_spottv_delete_reissues]', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Reissued TV CUME Books]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Reissued TV CUME Books', 
		@step_id=2, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec [dbo].[advsp_hosted_spottv_delete_cume_reissues]', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Reissued TV Program Books]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Reissued TV Program Books', 
		@step_id=3, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec advsp_hosted_spottv_delete_program_reissues', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Book]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Book', 
		@step_id=4, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV Book.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Audience]    Script Date: 10/20/2017 8:34:47 AM ******/
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
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV Audience.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [HUTPUT]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'HUTPUT', 
		@step_id=6, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV HUTPUT.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Intab]    Script Date: 10/20/2017 8:34:47 AM ******/
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
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV Intab.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Program Book]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Program Book', 
		@step_id=8, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV Program Book.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Program]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Program', 
		@step_id=9, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV Program.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Station]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Station', 
		@step_id=10, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV Station.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Station History]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Station History', 
		@step_id=11, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV Station History.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Universe]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Universe', 
		@step_id=12, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV Universe.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Daypart]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Daypart', 
		@step_id=13, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV Daypart.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [CUME Book]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'CUME Book', 
		@step_id=14, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV Cume Book.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [CUME Daypart Impression]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'CUME Daypart Impression', 
		@step_id=15, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\Nielsen TV CUME Daypart Impression.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Validate TV CUME Books]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Validate TV CUME Books', 
		@step_id=16, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec [advsp_hosted_validate_tv_cume_books]', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Validate TV Program Books]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Validate TV Program Books', 
		@step_id=17, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec [advsp_hosted_validate_tv_program_books]', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Validate TV Books]    Script Date: 10/20/2017 8:34:47 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Validate TV Books', 
		@step_id=18, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec [advsp_hosted_validate_tv_books]', 
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
		@schedule_uid=N'fbb838e6-dc6c-472a-bd32-b49a3f2ca50d'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO

