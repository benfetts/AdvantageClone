USE [msdb]
GO

/****** Object:  Job [Update Hosted NCC Tables from Data Store]    Script Date: 10/19/2017 8:37:16 AM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 10/19/2017 8:37:16 AM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'Update Hosted NCC Tables from Data Store', 
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
/****** Object:  Step [Delete AI UE Reissues]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete AI UE Reissues', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec advsp_hosted_ncc_tv_ai_ue_log_delete_reissues', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete CARRIAGE UE Reissues]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete CARRIAGE UE Reissues', 
		@step_id=2, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec advsp_hosted_ncc_tv_carriage_ue_log_delete_reissues', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete FUSION UE Reissues]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete FUSION UE Reissues', 
		@step_id=3, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'advsp_hosted_ncc_tv_fusion_ue_delete_reissues', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [MVPD]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'MVPD', 
		@step_id=4, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\NCC TV MVPD.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [SYSCODE]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'SYSCODE', 
		@step_id=5, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec advsp_hosted_sync_NCC_TV_SYSCODE', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [LPM MARKET]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'LPM MARKET', 
		@step_id=6, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec advsp_hosted_sync_NCC_TV_LPM_MARKET', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [CABLENET]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'CABLENET', 
		@step_id=7, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec advsp_hosted_sync_NCC_TV_CABLENET', 
		@database_name=N'NIELSENHOSTED', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [AI UE LOG]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'AI UE LOG', 
		@step_id=8, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\NCC TV AI UE LOG.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [AI UE]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'AI UE', 
		@step_id=9, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\NCC TV AI UE.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [CARRIAGE UE LOG]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'CARRIAGE UE LOG', 
		@step_id=10, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\NCC TV CARRIAGE UE LOG.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [CARRIAGE UE]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'CARRIAGE UE', 
		@step_id=11, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\NCC TV CARRIAGE UE.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [FUSION UE]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'FUSION UE', 
		@step_id=12, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\NCC TV FUSION UE.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [FUSION AUDIENCE]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'FUSION AUDIENCE', 
		@step_id=13, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\NCC TV FUSION AUDIENCE.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [FUSION HUTPUT]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'FUSION HUTPUT', 
		@step_id=14, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'SSIS', 
		@command=N'/FILE "\"C:\NielsenData\SSIS Packages\NCC TV FUSION HUTPUT.dtsx\"" /DECRYPT MRqtgqWm1B /CONNECTION DestinationConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENHOSTED;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CONNECTION SourceConnectionOLEDB;"\"Data Source=TASC-SQL2014;User ID=SYSADM;Initial Catalog=NIELSENDATASTORE;Provider=SQLNCLI11;Auto Translate=false;Password=sysadm;\"" /CHECKPOINTING OFF /REPORTING E', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Validate NCC Data]    Script Date: 10/19/2017 8:37:16 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Validate NCC Data', 
		@step_id=15, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'exec advsp_hosted_validate_ncc_data', 
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
		@active_start_date=20171019, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, 
		@schedule_uid=N'a7b8dd78-d805-4203-b0e5-e6a9090d79ee'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO

