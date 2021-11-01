Public Class AdvantageDatabaseUpdateForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If My.Application.CommandLineArgs.Count = 0 Then

            _UseSecurityLogin = True

        Else

            _UseSecurityLogin = False

        End If

        _Application = AdvantageFramework.Security.Application.Advantage_Database_Update

    End Sub
    'Private Sub RunBatchMode()

    '    'objects
    '    Dim DirectoryInfoList As Generic.List(Of System.IO.DirectoryInfo) = Nothing
    '    Dim DatabaseVersion As String = ""
    '    Dim UnappliedDatabaseChangesList As Generic.List(Of System.IO.FileInfo) = Nothing
    '    Dim FileInfoList As Generic.List(Of System.IO.FileInfo) = Nothing
    '    Dim LogText As String = ""
    '    Dim ScriptText As String = ""
    '    Dim ScriptLine As String = ""
    '    Dim StreamReader As System.IO.StreamReader = Nothing
    '    Dim ReadWholeFileCorrectly As Boolean = False
    '    Dim AllScriptsRanCorrectly As Boolean = True
    '    Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
    '    Dim FirstExecution As Boolean = True
    '    Dim StringReader As System.IO.StringReader = Nothing

    '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

    '        Try

    '            DatabaseVersion = SecurityDbContext.ExecuteStoreQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

    '        Catch ex As Exception
    '            DatabaseVersion = ""
    '        End Try

    '    End Using

    '    If DatabaseVersion <> "" Then

    '        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Scripts") Then

    '            DirectoryInfoList = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath & "\Scripts").GetDirectories.ToList

    '            FileInfoList = New Generic.List(Of System.IO.FileInfo)

    '            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

    '                For Each DirectoryInfo In DirectoryInfoList

    '                    If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DirectoryInfo.Name) >= AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DatabaseVersion) Then

    '                        UnappliedDatabaseChangesList = New Generic.List(Of System.IO.FileInfo)

    '                        AdvantageFramework.Security.LoadDirectoryScripts(UnappliedDatabaseChangesList, DirectoryInfo, DbContext)

    '                        For Each FileInfo In UnappliedDatabaseChangesList

    '                            FileInfoList.Add(FileInfo)

    '                        Next

    '                    End If

    '                Next

    '            End Using

    '            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

    '                LogText = "Closing connections and restricting user access..." & vbNewLine & LogText

    '                SecurityDbContext.ExecuteStoreCommand(String.Format("ALTER DATABASE {0} SET RESTRICTED_USER WITH ROLLBACK IMMEDIATE", _Session.DatabaseName))

    '                LogText = "Clear version info..." & vbNewLine & LogText

    '                SecurityDbContext.ExecuteStoreCommand("UPDATE dbo.ADVAN_UPDATE SET VERSION_ID = NULL")

    '                For Each FileInfo In FileInfoList

    '                    LogText = "***********************************************************************************" & LogText
    '                    LogText = "Parsing script " & FileInfo.Name.Replace(".advenc", "").Replace(".sql", "") & "..." & vbNewLine & LogText

    '                    ScriptLine = ""
    '                    ScriptText = ""
    '                    ReadWholeFileCorrectly = False
    '                    FirstExecution = True

    '                    SecurityDbContext.Connection.Open()

    '                    DbTransaction = SecurityDbContext.Connection.BeginTransaction

    '                    Try

    '                        If FileInfo.Extension.ToUpper = ".ADVENC" Then

    '                            StringReader = New System.IO.StringReader(AdvantageFramework.Security.LicenseKey.Decrypt(My.Computer.FileSystem.ReadAllText(FileInfo.FullName)))

    '                            ScriptText = StringReader.ReadLine() & vbCrLf

    '                            Do While StringReader.Peek <> -1

    '                                ScriptLine = ""

    '                                ScriptLine = StringReader.ReadLine()

    '                                If ScriptLine.Trim = "GO" Then

    '                                    ExecuteText(SecurityDbContext, ScriptText, FirstExecution, FileInfo.Name.Replace(".advenc", "").Replace(".sql", ""))

    '                                    ScriptText = ""

    '                                Else

    '                                    ScriptText &= ScriptLine & vbNewLine

    '                                End If

    '                            Loop

    '                        Else

    '                            StreamReader = FileInfo.OpenText

    '                            ScriptText = StreamReader.ReadLine() & vbCrLf

    '                            Do Until StreamReader.EndOfStream

    '                                ScriptLine = ""

    '                                ScriptLine = StreamReader.ReadLine()

    '                                If ScriptLine.Trim = "GO" Then

    '                                    ExecuteText(SecurityDbContext, ScriptText, FirstExecution, FileInfo.Name.Replace(".advenc", "").Replace(".sql", ""))

    '                                    ScriptText = ""

    '                                Else

    '                                    ScriptText &= ScriptLine & vbNewLine

    '                                End If

    '                            Loop

    '                        End If

    '                        ScriptText = ScriptText.Trim

    '                        If ScriptText <> "" AndAlso ScriptText <> "GO" Then

    '                            ExecuteText(SecurityDbContext, ScriptText, FirstExecution, Node.Text)

    '                        End If

    '                        ReadWholeFileCorrectly = True

    '                    Catch ex As Exception
    '                        LogText = "Execution failed --> " & ex.Message & vbNewLine & LogText
    '                        ReadWholeFileCorrectly = False
    '                    Finally

    '                        If StreamReader IsNot Nothing Then

    '                            StreamReader.Close()
    '                            StreamReader.Dispose()
    '                            StreamReader = Nothing

    '                        End If

    '                    End Try

    '                    If ReadWholeFileCorrectly Then

    '                        DbTransaction.Commit()

    '                        LogText = "Updating database update table..." & vbNewLine & LogText

    '                        If SecurityDbContext.ExecuteStoreQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.DB_UPDATE WHERE FUNCTION_NAME = '{0}'", FileInfo.Name.Replace(".advenc", "").Replace(".sql", "") & "_" & FileInfo.LastWriteTime.ToString("yyyyMMddHHmmss"))).FirstOrDefault = 0 Then

    '                            SecurityDbContext.ExecuteStoreCommand(String.Format("INSERT INTO dbo.DB_UPDATE([VERSION_ID], [PATCH], [DESCRIPTION], [DATE_APPLIED], [FUNCTION_NAME])" & _
    '                                                                                    "VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", Node.Parent.Text, FileInfo.Name, FileInfo.Name.Replace(".advenc", "").Replace(".sql", ""), Now.ToShortDateString, FileInfo.Name.Replace(".advenc", "").Replace(".sql", "") & "_" & FileInfo.LastWriteTime.ToString("yyyyMMddHHmmss")))

    '                        End If

    '                        LogText = "Database update table updated..." & vbNewLine & LogText
    '                        LogText = "***********************************************************************************" & LogText

    '                    Else

    '                        DbTransaction.Rollback()

    '                        AllScriptsRanCorrectly = False

    '                    End If

    '                    SecurityDbContext.Connection.Close()

    '                    If AllScriptsRanCorrectly = False Then

    '                        Exit For

    '                    End If

    '                Next

    '                If AllScriptsRanCorrectly Then

    '                    ScriptText = ""

    '                End If

    '            End Using

    '        End If

    '    End If

    'End Sub
    Private Function GetFileHashUpdate() As String

        GetFileHashUpdate = " UPDATE dbo.DB_UPDATE SET FILE_HASH = '00d95e4deac6118297c812a59f378431' WHERE PATCH = 'advsp_cleanup_temp_bill_hold.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c288664dcb134515d8130a39c211ebbb' WHERE PATCH = 'New Application.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7cd47705a8ccf40f78755ca030eb6ac5' WHERE PATCH = 'NewApplicationAlertSetting.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '8e990645f1318820622ec4c07e11a26f' WHERE PATCH = 'Update AGY_SETTINGS_b.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'aa7056b8bf216b8da3191ce5a7e58ab3' WHERE PATCH = 'usp_wv_Dashboard_GetAvgHourlyRateByClient.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c787f5ed98353dde3ebf24fc1783c93e' WHERE PATCH = 'usp_wv_Dashboard_GetAvgHourlyRateByProduct.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6bd28c85ec820f74d9f9b0d436b502cf' WHERE PATCH = 'usp_wv_Dashboard_GetBilledHoursWithBillable.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '501fd98b76ec3146584a5a51ca934a41' WHERE PATCH = 'usp_wv_Dashboard_GetBilledHoursWithGoal.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f571ac572101a40010bb11306175936d' WHERE PATCH = 'usp_wv_Dashboard_GetCliDetail.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7953f4b652eb9f977424433682d4de0f' WHERE PATCH = 'usp_wv_Dashboard_GetClientDetail.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'be67e6dfcc19cb435ae61e423389cd6f' WHERE PATCH = 'usp_wv_Dashboard_GetClientTimeByJob.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cea32727566bc39c7dc9618db616d7da' WHERE PATCH = 'usp_wv_Dashboard_GetClientTotals.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd327628cf4a99f040c5650e13840a898' WHERE PATCH = 'usp_wv_Dashboard_GetDirectHoursWithBilled.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '75640b81f9e987ea344e3ab6cef6ae9c' WHERE PATCH = 'usp_wv_Dashboard_GetJobTimeByEmp.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '2a711005c8d256e141f220015e2ae5eb' WHERE PATCH = 'usp_wv_Dashboard_GetRealizationData.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a6532ae1694a8b3409becca88528476d' WHERE PATCH = 'Menu Update.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd0be1d45334e82097ece7eb9f6d7c5cc' WHERE PATCH = 'DRPT_DIRECT_INDIRECT_TIME.table.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a0438780ca0fcf5bfaf24d54fa94846c' WHERE PATCH = 'DRPT_DIRECT_TIME.table.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e343f80e6a87c07c4716a6d2a65f0a8a' WHERE PATCH = 'advsp_collect_actuals.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '648d2f30a8e6522208529f04782110d7' WHERE PATCH = 'advsp_collect_project_schedule_cost.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '30d1b073383f0e1dea0fbc06f022ddd5' WHERE PATCH = 'advsp_load_drpt_direct_indirect_time.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7e789860fabb0d645f016d41c222a30d' WHERE PATCH = 'advsp_load_drpt_direct_time.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '3fbf36ec9f87131d7e8d94f2e106fffb' WHERE PATCH = 'usp_wv_get_smtp_by_cpuser.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '320add546fa4908a47adfe8dff898a6a' WHERE PATCH = 'usp_wv_get_smtp_by_user.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '62095939ad96ded688ba6905cf398d57' WHERE PATCH = 'V_DRPT_DIRECT_INDIRECT_TIME.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a7a26e50f7158975fde69e77611308d7' WHERE PATCH = 'V_DRPT_DIRECT_INDIRECT_TIME_LIVE.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '3b26ad20812f6ecdfc322cf9d0b2c92a' WHERE PATCH = 'V_DRPT_DIRECT_TIME.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'df4f2ea56a555e633ef93d64e97d5067' WHERE PATCH = 'V_DRPT_DIRECT_TIME_LIVE.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f578bd2c7c5d0bfbb88e052e2a310adf' WHERE PATCH = 'AddColumns_WV_Favorites.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5a701bab7c2e9216cd54cea7cf2dd7fb' WHERE PATCH = 'usp_wv_Traffic_Schedule_JobCopy.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4a0bceee5c3ded9d245b1796d07d2047' WHERE PATCH = 'usp_wv_UseFavoritesGet.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a52f47a9901f7aaffa3e868872d3505e' WHERE PATCH = 'WebvantageScript.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c0ab3b5fdc1ba48512170a633e17f777' WHERE PATCH = 'z - advtf_get_billing_rate.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5d801a78636da377d2d15f4187624aac' WHERE PATCH = 'zz - advsp_collect_project_schedule_cost.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '93bffc8c11bae9fb5f975cf90b0ae90f' WHERE PATCH = 'zzz - advsp_collect_actuals.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd8554d0b000b35bfaa37bce8afb5aecc' WHERE PATCH = 'V_DRPT_JOB_DETAILS_ITEM.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '11f3158329a840cc5a608ea5fc01d771' WHERE PATCH = 'V_DRPT_JOB_DETAILS_ITEM_LIVE.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e343f80e6a87c07c4716a6d2a65f0a8a' WHERE PATCH = 'advsp_collect_actuals.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '648d2f30a8e6522208529f04782110d7' WHERE PATCH = 'advsp_collect_project_schedule_cost.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9445bbcdd5f65b3ec776af7e5d317415' WHERE PATCH = 'usp_wv_reports_ar_statements_client_004.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cd4024671765bdb7bf62b4d10dfad073' WHERE PATCH = 'usp_wv_reports_ar_statements_product_001.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '56981cbc339867c13854b0e594707c8e' WHERE PATCH = 'usp_wv_reports_ar_statements_product_003.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7c6f6024a9b3ef287730ef40bcd2127f' WHERE PATCH = 'usp_wv_reports_ar_statements_product_004.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4a0bceee5c3ded9d245b1796d07d2047' WHERE PATCH = 'usp_wv_UseFavoritesGet.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '171ba6d8c8a78fa26c79c5557281f403' WHERE PATCH = 'V_DRPT_JOB_DETAILS.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '83483f7a042da34cfd7ea0a877d8274a' WHERE PATCH = 'V_DRPT_JOB_DETAILS_BILL_MONTH.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5098fd07e15ec35e872d2038c868142b' WHERE PATCH = 'V_DRPT_JOB_DETAILS_BILL_MONTH_LIVE.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '51236f8d41acfaf9bc142851b162ff11' WHERE PATCH = 'V_DRPT_JOB_DETAILS_FUNCTION.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4d988643df9f0bd25724731fc5861b71' WHERE PATCH = 'V_DRPT_JOB_DETAILS_FUNCTION_LIVE.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'dbb0246e0a1a14aae441694df517dcaf' WHERE PATCH = 'V_DRPT_JOB_DETAILS_LIVE.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c0ab3b5fdc1ba48512170a633e17f777' WHERE PATCH = 'z - advtf_get_billing_rate.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5d801a78636da377d2d15f4187624aac' WHERE PATCH = 'zz - advsp_collect_project_schedule_cost.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '93bffc8c11bae9fb5f975cf90b0ae90f' WHERE PATCH = 'zzz - advsp_collect_actuals.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c34b1f95ebf84dd4c8c98a73a9c30aa4' WHERE PATCH = 'sp_get_billing_rates.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4071f7fd774ad4e6ca8df9db7ba81271' WHERE PATCH = 'sp_get_billing_rates_rs.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd949bf64dd3775b5abd6d069f446d90d' WHERE PATCH = 'usp_cp_calendar_GetMediaData.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1f3b42fc008d216fa39ce79b9178109d' WHERE PATCH = 'usp_wv_ALERT_GET.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '164e828fda66bf4d52cc49fa96c0ecf5' WHERE PATCH = 'usp_wv_dd_GetEmpCodes.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0797664609f798a0dcec50140b4fd9e9' WHERE PATCH = 'usp_wv_dd_GetEmpCodesByRole.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c9b29993bafb8b5ba64a5b0f09733485' WHERE PATCH = 'usp_wv_dd_GetEmpCodesBySup.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6fe046cb46f787390e4db81b3634cf7e' WHERE PATCH = 'usp_wv_dd_GetEmpsByFML.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '8e4377bf8b8351f157e72838a3133a61' WHERE PATCH = 'usp_wv_dto_tasks_new.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c0ab3b5fdc1ba48512170a633e17f777' WHERE PATCH = 'z - advtf_get_billing_rate.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '03d81dc514f45b2630969d01aa1b6218' WHERE PATCH = 'advsp_job_comp_header_info.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '41c25ebe04fb20be397e07c9b3423dac' WHERE PATCH = 'usp_wv_calendar_GetMediaData.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f35537ba2f8287fcaa91c2e4917bf62d' WHERE PATCH = 'usp_wv_job_comp_get.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'b9451bd7ea044b3447fcdf60f0e7ffe8' WHERE PATCH = 'usp_wv_Project_Status_Data.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '768884df53a0e3d207883d1964444478' WHERE PATCH = 'AlterCP_ALERT_RCPT.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6d66f00b3ef7131070b62c976e05b38a' WHERE PATCH = 'usp_wv_ALERT_DISMISS.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1f3b42fc008d216fa39ce79b9178109d' WHERE PATCH = 'usp_wv_ALERT_GET.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7dc352515b6eb48cc4e059d72e1a8f51' WHERE PATCH = 'usp_wv_ALERT_GET_RECIPIENTS.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '97a651060a14ebb3c702caa70efee3d1' WHERE PATCH = 'usp_wv_ALERT_UNDISMISS.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c8814488b52a0e4ff5080d47888d9342' WHERE PATCH = 'usp_wv_empcode_validate.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '8e92539516d9eb4118bec7c294ecf25f' WHERE PATCH = 'usp_wv_IsEmpTerminated.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '82aba58622a2f5056f1f3b4ee2013e1e' WHERE PATCH = 'usp_wv_reports_ar_statements_client_001.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '943d544f7b7160e0957b01bb0ca6f3ff' WHERE PATCH = 'usp_wv_reports_ar_statements_client_003.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9445bbcdd5f65b3ec776af7e5d317415' WHERE PATCH = 'usp_wv_reports_ar_statements_client_004.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cd4024671765bdb7bf62b4d10dfad073' WHERE PATCH = 'usp_wv_reports_ar_statements_product_001.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '56981cbc339867c13854b0e594707c8e' WHERE PATCH = 'usp_wv_reports_ar_statements_product_003.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7c6f6024a9b3ef287730ef40bcd2127f' WHERE PATCH = 'usp_wv_reports_ar_statements_product_004.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a51339b80efef8d9da8358b9f57d04d2' WHERE PATCH = 'Menu Update.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a51339b80efef8d9da8358b9f57d04d2' WHERE PATCH = 'Menu Update.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '001e32e5fcab7a25a4a033fc80e8adac' WHERE PATCH = 'WebvantageScript.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c728b90b68e3bc1038a0e12b4a04bcba' WHERE PATCH = 'ALTER CAMPAIGN TABLE.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f2abe19309b71a3d05b611030475e30b' WHERE PATCH = 'City Update.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'ec3cc337bf0e65cecbb791c7f02575ea' WHERE PATCH = 'advsp_notify_tasks.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '38b87cf1d2953c7a7279462e8bb9b356' WHERE PATCH = 'advsp_populate_missing_time_table.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a8f28e59ecebd46c681dc1dd87f4fedb' WHERE PATCH = 'ALTER MISSING_TIME_DTL TABLE.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a51339b80efef8d9da8358b9f57d04d2' WHERE PATCH = 'Menu Update.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5e5d10e3d6dec75b90f076af813f1068' WHERE PATCH = 'usp_wv_ALERT_GET.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '058169c983c19c844d0a927ee02151da' WHERE PATCH = 'usp_wv_ALERT_GET_COMMENTS.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cce97fbdbf2da1a5e88378c02ff80122' WHERE PATCH = 'usp_wv_DesktopObject_GetMyProjectsSort.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c288664dcb134515d8130a39c211ebbb' WHERE PATCH = 'New Application.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cfc369892522ce80ab6c965599cf6647' WHERE PATCH = 'usp_wv_Job_Template_GetTemplate_ByJobAndComp.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd1b85ac8f11c269b6e7b8bbde64edfd2' WHERE PATCH = 'advsp_collect_actuals.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'ec3cc337bf0e65cecbb791c7f02575ea' WHERE PATCH = 'advsp_notify_tasks.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '38b87cf1d2953c7a7279462e8bb9b356' WHERE PATCH = 'advsp_populate_missing_time_table.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c728b90b68e3bc1038a0e12b4a04bcba' WHERE PATCH = 'ALTER CAMPAIGN TABLE.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f2abe19309b71a3d05b611030475e30b' WHERE PATCH = 'City Update.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f039020c92862bc7e49f0c973961f412' WHERE PATCH = 'DOCUMENT COMMENT - Add Columns.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '443068273fe7fbdccfe5a7a1f9ddce57' WHERE PATCH = 'FixAlertPriority.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5e5d10e3d6dec75b90f076af813f1068' WHERE PATCH = 'usp_wv_ALERT_GET.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f66667236167da471438f039d47dbc1f' WHERE PATCH = 'usp_wv_calendar_workload_employee.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '203769014a09a5abfc216751be2c2ab1' WHERE PATCH = 'usp_wv_dd_Batch_GetClientsByBatchID.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cce97fbdbf2da1a5e88378c02ff80122' WHERE PATCH = 'usp_wv_DesktopObject_GetMyProjectsSort.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9b6d18c61eb6bbcba001a97b0bfff434' WHERE PATCH = 'usp_wv_get_agency_goals.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '240d72081610ae2e666914ae59328840' WHERE PATCH = 'usp_wv_get_emp_np_time_all.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'aa4dda21eaf10a416bb5cde919bfe3ee' WHERE PATCH = 'usp_wv_get_emp_np_time_data.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c474c14080cdb8748edc8fe1538edb8e' WHERE PATCH = 'usp_wv_job_comp_get.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c23b7369c087bd7e7c175d898b00d8db' WHERE PATCH = 'usp_wv_job_get_by_jobno.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5c4126645cebedcc0dc013a753c4b738' WHERE PATCH = 'V_CORE_MEDIA_CHECK_EXPORT.view.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '001e32e5fcab7a25a4a033fc80e8adac' WHERE PATCH = 'WebvantageScript.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'bdfd0f7a2c4ffa7b49b1d181ba543dad' WHERE PATCH = 'usp_wv_calendar_workload_details.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'b6f36e34035636d630b6a0ed88a282db' WHERE PATCH = 'Workflow_Tables.sql' AND VERSION_ID = 'v6.50.07' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '09ea226f1bbd7dd0689000ce392940f8' WHERE PATCH = 'CP_ALERT_RCPT_DISMISSED.table.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9843d4f27571de26393f3395059c5e3b' WHERE PATCH = 'InsertGenDescsforDashYears.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'ffbc8ace67f7963fbaac891bc60a4b4a' WHERE PATCH = 'usp_wv_ALERT_DISMISS_CP.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '885298d3a7132f177c4bd451e82e54bc' WHERE PATCH = 'usp_wv_ALERT_UNDISMISS_CP.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'dfd5ff82c021bfcd618f8ee25ba272e1' WHERE PATCH = 'usp_wv_Dashboard_GetYearDescriptions.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cfc369892522ce80ab6c965599cf6647' WHERE PATCH = 'usp_wv_Job_Template_GetTemplate_ByJobAndComp.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd1b85ac8f11c269b6e7b8bbde64edfd2' WHERE PATCH = 'advsp_collect_actuals.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '84d5cb445d9011f2a1daf5e38418e097' WHERE PATCH = 'advsp_collect_project_schedule_cost_by_ppd.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '2a711005c8d256e141f220015e2ae5eb' WHERE PATCH = 'usp_wv_Dashboard_GetRealizationData.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f1e026142d88e80e970b9047a3f40dea' WHERE PATCH = 'usp_wv_reports_ar_statements_client_001.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '3412b3b37c4fbd804da6c2fe127ad8af' WHERE PATCH = 'usp_wv_reports_ar_statements_client_002.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '19c513bcd8fa33ae2581361335e74796' WHERE PATCH = 'usp_wv_reports_ar_statements_client_003.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '003813807c6d92635b18501b2eb37145' WHERE PATCH = 'usp_wv_reports_ar_statements_client_004.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7319decabd54379b6631cfdf10989047' WHERE PATCH = 'usp_wv_reports_ar_statements_product_001.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0db3c7e7d6d1c30ba773993231357fc3' WHERE PATCH = 'usp_wv_reports_ar_statements_product_002.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5a0154a7cdd2461e1b0cb097ef74963c' WHERE PATCH = 'usp_wv_reports_ar_statements_product_003.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '298b160beef7ceec7cab91546758ee1b' WHERE PATCH = 'usp_wv_reports_ar_statements_product_004.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '509dd49e5c4d70f813e99fb15aaea712' WHERE PATCH = 'usp_wv_reports_traffic_schedule_byday.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0c497803e04ea2bdc2dd69b68e404cb6' WHERE PATCH = 'advtf_prod_bill_amts_by_line.sql' AND VERSION_ID = 'v6.50.07' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4ac3dd25a1fc884cd48158bd6ccfbfa1' WHERE PATCH = 'DRPT_ALERTS.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '11dbeb8d768ac07db428f012f67aa235' WHERE PATCH = 'DRPT_ALERTS_COMMENT.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c1169e0ca29213f8edd4d89d279b9e7c' WHERE PATCH = 'DRPT_ALERTS_RECIPIENTS.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e77a35113f7a2b8faad1f6c1f45f2994' WHERE PATCH = 'DRPT_CLIENT_CONTACT.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7f90a9c64059c2f36b854a238f2a14b8' WHERE PATCH = 'DRPT_DIRECT_INDIRECT_TIME.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '076eebaf6cd4e2a5e182751e86cb4328' WHERE PATCH = 'DRPT_DIRECT_TIME.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0964019668d76a27cc7eadc57dab0e7f' WHERE PATCH = 'DRPT_JOB_DETAILS.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '61a09668605d26aa88f34daf6b4c0edc' WHERE PATCH = 'DRPT_JOB_DETAILS_BILL_MONTH.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c58c508416d1488e2b7884e3584dd541' WHERE PATCH = 'DRPT_JOB_DETAILS_FUNCTION.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a5478fb7b83f4a23415355c9cd0e5921' WHERE PATCH = 'DRPT_JOB_DETAILS_ITEM.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '49a3f3fdc3afa724914946a0dcaf6fcf' WHERE PATCH = 'DRPT_JOB_PROJECT_SCHEDULE_SUMMARY.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '84304a5c672c27e57cda10daa430cde4' WHERE PATCH = 'DRPT_JOB_SUMMARY.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0e06b7091d69c13d71fb17208e69791e' WHERE PATCH = 'DRPT_PROJECT_HOURS_USED.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5b41150c7293de44f8c3b58f98182c17' WHERE PATCH = 'DRPT_PROJECT_SCHEDULE.table.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '2dd847d75a2e1c38710d1fa5033c44e8' WHERE PATCH = 'V_DRPT_JOB_SUMMARY.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '33d5e21aa77c5c1493970d2fd6f40607' WHERE PATCH = 'V_DRPT_JOB_SUMMARY_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0c4553f174d5349307acc9d7e2c60524' WHERE PATCH = 'V_DRPT_JOB_DETAILS_ITEM.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f4bb44312e3458f847c591f8e50ff928' WHERE PATCH = 'V_DRPT_JOB_DETAILS_ITEM_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7cf26d10772c2b157a2cb63e3d940a1e' WHERE PATCH = 'V_DRPT_ALERTS.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '05f1c73f0bb453dde432ba6e1926c001' WHERE PATCH = 'V_DRPT_ALERTS_COMMENT.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'fd679ddb7ae7155d70977a94a34c99d9' WHERE PATCH = 'V_DRPT_ALERTS_COMMENT_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cd8b55e204047be20b60b1ab176dd9b6' WHERE PATCH = 'V_DRPT_ALERTS_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4e9a9b98b422810598ed4c8ec313df55' WHERE PATCH = 'V_DRPT_ALERTS_RECIPIENTS.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '56ea60571d81daccb6639e1f73ca5000' WHERE PATCH = 'V_DRPT_ALERTS_RECIPIENTS_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e9ac43a41dede793b045bda136269c83' WHERE PATCH = 'V_DRPT_CLIENT_CONTACT.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'b2fe5c7698265c4283d0f52ca468b35f' WHERE PATCH = 'V_DRPT_CLIENT_CONTACT_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '40ade96d69dd687886cb438ca4e32111' WHERE PATCH = 'V_DRPT_DIRECT_INDIRECT_TIME.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '232d8c8f26dd25752f38fdb3663492c8' WHERE PATCH = 'V_DRPT_DIRECT_INDIRECT_TIME_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '306208c4d27a15ea9423a00c44307fb2' WHERE PATCH = 'V_DRPT_DIRECT_TIME.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6497519ce024e2cc2cad457921efdbdd' WHERE PATCH = 'V_DRPT_DIRECT_TIME_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c8a928327718e65e86495995d5a7248f' WHERE PATCH = 'V_DRPT_JOB_DETAILS.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0e0392152439665150feafa70aea28a3' WHERE PATCH = 'V_DRPT_JOB_DETAILS_BILL_MONTH.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '33fc4efb6d4b15e8afd42ff80ba63897' WHERE PATCH = 'V_DRPT_JOB_DETAILS_BILL_MONTH_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'ffa85255abb9e0b01b2bb02f4cf1af06' WHERE PATCH = 'V_DRPT_JOB_DETAILS_FUNCTION.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9891d68ff3f728f7d49bc2cf381a1df3' WHERE PATCH = 'V_DRPT_JOB_DETAILS_FUNCTION_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6770a127dbeb9cdc132679eb76643018' WHERE PATCH = 'V_DRPT_JOB_DETAILS_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'ad7a8e7ec543bf3b0627bf60d25f2e24' WHERE PATCH = 'V_DRPT_JOB_PROJECT_SCHEDULE_SUMMARY.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'dcf45f9e956a0067181d8071c040d516' WHERE PATCH = 'V_DRPT_JOB_PROJECT_SCHEDULE_SUMMARY_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e1fe26207988a8f4e7436dcb1a0f389b' WHERE PATCH = 'V_DRPT_PROJECT_HOURS_USED.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9ea8cf439aaab2f9c71be4a979b3da23' WHERE PATCH = 'V_DRPT_PROJECT_HOURS_USED_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1cf588581def32478de2a0d9c5cfa3ab' WHERE PATCH = 'V_DRPT_PROJECT_SCHEDULE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a653ad5ef96f392221099947005ba680' WHERE PATCH = 'V_DRPT_PROJECT_SCHEDULE_LIVE.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'fd8fe101cac3557c976f2a3065d9f022' WHERE PATCH = 'advsp_load_drpt_alerts.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '432026066f25258c88de805236f0cdf2' WHERE PATCH = 'advsp_load_drpt_alerts_comment.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'fb97e0d3dc6081c71b179e65d84ff7be' WHERE PATCH = 'advsp_load_drpt_alerts_recipients.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a370d3fb5b9bba2782d1b892973aa1b0' WHERE PATCH = 'advsp_load_drpt_client_contact.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'eab3f9111f83274a607fa7dcb2bc49cf' WHERE PATCH = 'advsp_load_drpt_direct_indirect_time.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd66a2caddac1b32c76fc4b493fd5ddcf' WHERE PATCH = 'advsp_load_drpt_direct_time.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '3da0c61ac81585aa9cf52b1542617fd7' WHERE PATCH = 'advsp_load_drpt_job_details.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9646528ce0ada3015269ee7de4f2e8fb' WHERE PATCH = 'advsp_load_drpt_job_details_bill_month.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '28a26dad19b912961a40c3705d5a4ad7' WHERE PATCH = 'advsp_load_drpt_job_details_function.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1ccfd8cba5ff09b520a53230f62bfbf2' WHERE PATCH = 'advsp_load_drpt_job_details_item.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'fc7b44cd4d764feb5c896402b9573e51' WHERE PATCH = 'advsp_load_drpt_job_project_schedule_summary.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '46fb39906fd3bd60c5b81c361801278c' WHERE PATCH = 'advsp_load_drpt_job_summary.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '91bf9fc8827a4a351ccd2bbe466ed3bc' WHERE PATCH = 'advsp_load_drpt_project_hours_used.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd1ced65a53c3072d1bfb6ea00b64fe82' WHERE PATCH = 'advsp_load_drpt_project_schedule.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '78271030a32f244ffc8cf04845f6044a' WHERE PATCH = 'usp_wv_Project_Status_Data_Week.proc.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6791d2f082155ce1d9375e0d023b0095' WHERE PATCH = 'V_RPT_SEC_PERMISSION.view.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '8499023f90de8254b4594fac2b35aed6' WHERE PATCH = 'WebvantageScript.sql' AND VERSION_ID = 'v6.50.01' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd5cc79ae854fc3a04d1a048a60f7b8f8' WHERE PATCH = 'advsp_sec_module_create.proc.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'abde261d9dec819ab3d2a6444436c260' WHERE PATCH = 'SEC_CPUSER_APPACCESS.table.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd6a9b102719da07b9bf95da92849e753' WHERE PATCH = 'SEC_CPUSER_MODACCESS.table.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4725bf29475571762851a2165455d2f2' WHERE PATCH = 'zzzSEC_CPUSER FK.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4e9763dfe43b848307bf5162b3331162' WHERE PATCH = '4 - Default Application Inserts.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '992d35de9d44862d83f4f4a07664981e' WHERE PATCH = '5 - Default Module Access.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1183115786820bb8ae5ab1e183b7fee0' WHERE PATCH = '6 - Add Application Modules And Access.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '930ec79ca900325517bb41fbd32138ba' WHERE PATCH = 'New module inserts.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5ed7758888c3ae3e956188626736e1e2' WHERE PATCH = 'Paid Time Off Menu Update.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '605d2cd9930dab5cfc2c6c909e97c83d' WHERE PATCH = 'advsp_populate_missing_time_table.proc.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5b591f4724a3c52a6e46b0ee221d6bc5' WHERE PATCH = 'advsp_update_billing_cmd_center_media.proc.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e30b29c7cb9e6d24ef0aa61ffdcdcfd6' WHERE PATCH = 'advtf_prod_unbilled_amts_by_item.function.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1cb01460279639e91488a7b9665cd001' WHERE PATCH = 'usp_wv_Estimating_Print_Details_Report3.proc.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '248216d1dd224a9c4f3cb78f3f7105a2' WHERE PATCH = 'usp_wv_get_missing_time_employee_ct_hours.proc.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'db47c29abeacb849985f27b6462091e7' WHERE PATCH = 'usp_wv_Project_Status_Data.proc.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7be9c9abd820b8304b5c42e8b9bb4d9a' WHERE PATCH = 'usp_wv_RESOURCES_EMP_AVAILABILITY.proc.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '8fee6dc354fe9f576cfaaf7a7bb32f1f' WHERE PATCH = 'WebvantageScript.sql' AND VERSION_ID = 'v6.50.02' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4cdd9d990479e5138c8ae19d6ad78a20' WHERE PATCH = 'EXEC_DESKTOP_DOCUMENTS EMP_CODE Column.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f9d6fdbc16955fbfc28a68fa3b67d0da' WHERE PATCH = 'advsp_aged_ar.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'fef8adc2441b75971cedc128e74923e7' WHERE PATCH = 'advsp_media1_med_acc.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '2071eff65994ea8e128e10737c728430' WHERE PATCH = 'sp_media_med_acc.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '930b31b3796ed9c4b497c8ac005ab48f' WHERE PATCH = 'add_col_to_BRD_IMPORT_BUY.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '932f588198c552cafe2dee92cf1d84ee' WHERE PATCH = 'advsp_collect_actuals.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '360eee2b92b0103ce5f3b7305f603c26' WHERE PATCH = 'advsp_notify_tasks.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1b246bbeec3c7f188f649cfcf27054e0' WHERE PATCH = 'advsp_populate_missing_time_table.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'ba0347b4eb8c4e594b389165da6e8ba5' WHERE PATCH = 'Alter table BRDCAST_IMPORT_INV.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd48f6422830d27c87a3381329e9ef160' WHERE PATCH = 'alter_BRDCAST_IMPORT.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c7df24978fcaca3244f95dce9528c46a' WHERE PATCH = 'alter_RADIO_DETAIL.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c3ddcd50d55160a827b3837f8025911d' WHERE PATCH = 'alter_TV_DETAIL.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6ae837d636edee1203cb60e34edefe08' WHERE PATCH = 'FixAlertPriorityToCorrectXPriority.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7685b829c1cfb36a510eb69bfda2782c' WHERE PATCH = 'Menu Update.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1ac40739bf971d59c51b9ab1c2943b76' WHERE PATCH = 'proc_EXEC_DESKTOP_DOCUMENTSInsert.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'acf363d1e7bf3af3ec9c9cfbb5588e46' WHERE PATCH = 'proc_EXEC_DESKTOP_DOCUMENTSLoadAll.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7c47866c58d24b3a95917db161096c77' WHERE PATCH = 'proc_EXEC_DESKTOP_DOCUMENTSLoadByPrimaryKey.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '8d636d826840aab429ef9f21f17c568e' WHERE PATCH = 'proc_EXEC_DESKTOP_DOCUMENTSUpdate.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e48aba98e405ff41710c3e703fa8ccb9' WHERE PATCH = 'Service Fee Type Code Column Insert.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f6111e3fc047483c4612cb12ffc7d89c' WHERE PATCH = 'SERVICE_FEE_TYPE.table.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '246ebc249e02528e4858700c506a4804' WHERE PATCH = 'usp_cp_calendar_task_month.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e6704e150bc0f2e59462b24a6e315095' WHERE PATCH = 'usp_cp_dd_GetJobCompJJ.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c787a891f12209f40e89856bcd61c4ba' WHERE PATCH = 'usp_cp_dd_GetJobCompJJ_withClosed.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '03e57cc9b8597a40622182b850d803f6' WHERE PATCH = 'usp_cp_GetAlertGroup.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'ef4401184ad2c70dfae7319a14e7f006' WHERE PATCH = 'usp_cp_GetAlertRecipients.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'dd003d419aea830b0b76f15148bef04d' WHERE PATCH = 'usp_wv_ALERT_GET.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '48273d789a61239a3c4a1e00235f1024' WHERE PATCH = 'usp_wv_calendar_task_month_rpt.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '56d08be2b40a06312efe3e5515870e85' WHERE PATCH = 'usp_wv_DayPilot_GetMonth.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '28921bb13bb592495c24de38eb257f5d' WHERE PATCH = 'usp_wv_dd_GetJobCompNewAlert.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '59b556f6f9fd8e87fc94bcd189f1c1a7' WHERE PATCH = 'usp_wv_dd_GetJob_JobJacket.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '753751f38dcf23cbac480d0c305f350a' WHERE PATCH = 'usp_wv_dd_GetJob_JobJacket_withClosed.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd1de628710216b90ec33c3f82fb32c8d' WHERE PATCH = 'usp_wv_dto_GetExecutiveLinks.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cfc369892522ce80ab6c965599cf6647' WHERE PATCH = 'usp_wv_Job_Template_GetTemplate_ByJobAndComp.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c669de3d2cc6e8f1d8e2dca3bef90ef6' WHERE PATCH = 'usp_wv_reports_ar_statements_client_001.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cba9b9a08cc75b2201af01400c5184b0' WHERE PATCH = 'usp_wv_ts_SaveTimeSheetDay.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c6fe1d2c4afe81ca56945b2ff8656a84' WHERE PATCH = 'usp_WV_WORKSPACE_TMPLT_APPLY_TO_USER.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '750382e9739375c5bef2b5a0765fa7f3' WHERE PATCH = 'usp_WV_WORKSPACE_TMPLT_INSERT.proc.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '11c3477a7448e190fc8a5491589cb935' WHERE PATCH = 'V_CORE_MEDIA_CHECK_EXPORT.view.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0471be2f9df5422c6ca6b14488162966' WHERE PATCH = 'WebvantageScript.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '38873002d3654c028bd3448b6952be15' WHERE PATCH = 'WV_CURRENT_EXEC_DESKTOP_DOCUMENTS.view.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f0238b384702eddc00b0592dda1813bd' WHERE PATCH = 'WV_EXEC_DESKTOP_DOCUMENTS.view.sql' AND VERSION_ID = 'v6.50.03' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '316e6e312cd1fa13acf884fc9d276e3f' WHERE PATCH = 'AlterWVWPTemplateHdrTable.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7d89ca44dafa37c84c35d2ef9f072d7d' WHERE PATCH = 'CP_BINARY_IMAGES.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0c105468f6ccec22113c069d1a08f681' WHERE PATCH = 'CP_USER_WORKSPACE.table.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '949b2eb5927cd0fce8ab3277fad3aa29' WHERE PATCH = 'CP_WORKSPACE_OBJECT.table.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a83cafaac23e43a1217176c5154bbc7c' WHERE PATCH = 'advsp_aged_ar.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '194ba93cb368ee027715bb591e52ec55' WHERE PATCH = 'advsp_ar_ap_comment_limited.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'b3cd9a66267e9c4ef86e59eac3c2713b' WHERE PATCH = 'advsp_ar_billing_table_with_seq.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f5265a2d0026cf4cddeb71a98282190a' WHERE PATCH = 'advsp_ar_billing_table_with_seq_draft.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '2fbeb3e47f1e6b23f0004d7d3048837f' WHERE PATCH = 'advsp_media1_med_acc.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '73b64fc353cff3205e2444e6ae3cd5ce' WHERE PATCH = 'advsp_media1_order_print_detail.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f7f9f23662d29bdf0bdc4947f9e2c635' WHERE PATCH = 'DRPT_JOB_DETAILS.table.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f51f038f2843f326c9b059346d1aaddf' WHERE PATCH = 'DRPT_JOB_DETAILS_BILL_MONTH.table.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6eff5df6626a71cdaf79de8edf92fb0b' WHERE PATCH = 'DRPT_JOB_DETAILS_FUNCTION.table.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '81cdb8ab8c58c54c8cf07d67bdd3a158' WHERE PATCH = 'DRPT_JOB_DETAILS_ITEM.table.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '620b99ae66a033be10150421dc62acdd' WHERE PATCH = 'advsp_load_drpt_job_details.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '20f9c7c5460de62f4d5e11d402d2ca47' WHERE PATCH = 'advsp_load_drpt_job_details_bill_month.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '684a704528325b4f1b95d0faecd28750' WHERE PATCH = 'advsp_load_drpt_job_details_function.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6489ebb152a247aae82a4b5510e77832' WHERE PATCH = 'advsp_load_drpt_job_details_item.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a62db40e415b5ffdd60cc991484e62c6' WHERE PATCH = 'V_DRPT_JOB_DETAILS_ITEM.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '476020d9da949adf958827aa84bd8aef' WHERE PATCH = 'V_DRPT_JOB_DETAILS_ITEM_LIVE.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '25c01ea1611e7a850f27eb73d5a3c95e' WHERE PATCH = 'V_DRPT_JOB_DETAILS.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5e4e78c94c1aecbe4658a37bee76890a' WHERE PATCH = 'V_DRPT_JOB_DETAILS_BILL_MONTH.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5545b04d52ee6174ce6cb196db426d86' WHERE PATCH = 'V_DRPT_JOB_DETAILS_BILL_MONTH_LIVE.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'add02a3ba24028fb3d5a24d6e6f1f28f' WHERE PATCH = 'V_DRPT_JOB_DETAILS_FUNCTION.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '859c44369120d12a3d9319a37e8c83c2' WHERE PATCH = 'V_DRPT_JOB_DETAILS_FUNCTION_LIVE.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'b222d42234f2e4cf94eee0c4c9ec98f2' WHERE PATCH = 'V_DRPT_JOB_DETAILS_LIVE.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'ee831cfa968ea2b553f0c78aa04ce3d5' WHERE PATCH = 'Add required flags for service fee type to AGENCY and CLIENT.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '423d532a45d7f4c658832d632e1ef915' WHERE PATCH = 'Add SERVICE_FEE_TYPE to JOB_COMPONENT.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '01862beb5430f905aaaead5029e19c6e' WHERE PATCH = 'Add SERVICE_FEE_TYPE to JOB_TMPLT_ITEMS.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e0127e41bde9589de52610169f73a20a' WHERE PATCH = 'advsp_bill_select_mark_items.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '664a01cb212250176b1f69d44db72cf9' WHERE PATCH = 'advsp_csv_table_dump.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c8336fda3b25a71ffb260044ccea9e50' WHERE PATCH = 'Alter AGENCY LICENSE_KEY Column.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a2a272fcbcd3011c61716f5f3e16172e' WHERE PATCH = 'Alter MEDIA_PRINT_DEF.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1f9ded642d8db22eb71a746fd17e4fc2' WHERE PATCH = 'Alter PRINT_EST_DEF.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e3ab064e20fc51e80da7d299c058ea47' WHERE PATCH = 'AULU.table.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '385ff3f337aa1351b8681fe8f746fc07' WHERE PATCH = 'CP Add Application Modules.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9288a2ee4d265a197fe8fa824f8cd6c8' WHERE PATCH = 'fn_idsa.function.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a6532ae1694a8b3409becca88528476d' WHERE PATCH = 'Menu Update.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '27a9365f60f0f37c10b9b01f5af6b155' WHERE PATCH = 'Modify BILLING_RATE.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'eb0f039bbd256b29cd64876404d15905' WHERE PATCH = 'New License Key Setting.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e2f409677e4bdab226221d35d73043d2' WHERE PATCH = 'proc_WV_PO_Detail_LoadReportInfo_Ops.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5b6713bbdddfe6d06a8da38bc5cb9158' WHERE PATCH = 'proc_WV_PO_GetCustomPickList.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4167297e91f4d098fdd2c362c62e65c2' WHERE PATCH = 'sp_get_billing_rates.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'd34c906ca5eb80a2723071cee62690fb' WHERE PATCH = 'sp_get_billing_rates_rs.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '41fd941b4c60bfc06939ede3cccdc299' WHERE PATCH = 'Update AGY_SETTINGS.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f4ddb90fb892d6a94411013d06781e16' WHERE PATCH = 'Update JOB_TMPLT_ITEMS.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9d75e126292e1dfe12a92d3521edd66f' WHERE PATCH = 'advsp_bcc_other_user_media.proc.sql' AND VERSION_ID = 'v6.50.07' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '34c9017eba6825ba5bca98caa99b721c' WHERE PATCH = 'Menu Update.sql' AND VERSION_ID = 'v6.50.07' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7ebf39a1b98b3938d1fdbbb6fbcda1aa' WHERE PATCH = 'usp_wv_ALERT_NOTIFY_GET_STATES.proc.sql' AND VERSION_ID = 'v6.50.07' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'bb1dbb36ec7b00bc251dbff66e6166ee' WHERE PATCH = 'usp_wv_WORKFLOW_ALERT_STATE_GET.proc.sql' AND VERSION_ID = 'v6.50.07' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4ecdb995f60b90a6dcc82b749402c4c9' WHERE PATCH = 'usp_wv_WORKFLOW_CHANGE_ASSIGNMENT_STATE.proc.sql' AND VERSION_ID = 'v6.50.07' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '334fee65a3240df1293bb423d103c69b' WHERE PATCH = 'WebvantageScript.sql' AND VERSION_ID = 'v6.50.07' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '24d21897dd17242039da546b9c49e09f' WHERE PATCH = 'usp_wv_get_smtp_by_cpuser.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e769eefd55d9d00d217eab643b3de813' WHERE PATCH = 'usp_wv_get_smtp_by_user.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '56803bd3e741a3a759d8072f1e786ae1' WHERE PATCH = 'usp_wv_calendar_task_month_rpt.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '27f99e00365efa0edf78324f838b6cff' WHERE PATCH = 'City Update.sql' AND VERSION_ID = 'v6.50.07' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a937452995a1b82858761d11e878a10a' WHERE PATCH = 'usp_cp_calendar_task_month.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5688c3d24a9b4b4c1910ad64a6146de9' WHERE PATCH = 'usp_cp_dd_GetAllDivisions_withclient.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'fa6eaf83f6851726e0eb3573dc8d86ec' WHERE PATCH = 'usp_cp_dd_GetAllProducts_withCnD.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '2beaa37c4217be660637bca0cbc2214d' WHERE PATCH = 'usp_cp_dto_JobStatistics.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '82965ac4f5af7dadd4868bb0ea94371e' WHERE PATCH = 'usp_CP_WORKSPACE_TMPLT_APPLY_TO_USER.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'b50524afb24124591ba5738a93c0968d' WHERE PATCH = 'usp_CP_WORKSPACE_TMPLT_INSERT.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '2f801ed7dbd89a16005d1ca17fdde7b9' WHERE PATCH = 'usp_OpenJobsRpt.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '61706cea51ff94aaf4594856fe8c89c2' WHERE PATCH = 'usp_wv_ALERT_DISMISS.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5e5d10e3d6dec75b90f076af813f1068' WHERE PATCH = 'usp_wv_ALERT_GET.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'b5ec9d71812b4e1a70c678bf170f55c5' WHERE PATCH = 'usp_wv_ALERT_GET_RECIPIENTS.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '4ced28e9c00737918fd52ac7a1288793' WHERE PATCH = 'usp_wv_ALERT_UNDISMISS.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '68eed07f71eaa7a1fa8ea33638073fc7' WHERE PATCH = 'usp_wv_calendar_task_month.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '29458d851a170f53bf61fc15d34634e7' WHERE PATCH = 'usp_wv_calendar_workload.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'dea09a8528697b0c3b2ef5acbda6586a' WHERE PATCH = 'usp_wv_calendar_workload_details.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'dd5a5e1a93b210f2bdf21e21eac43b0c' WHERE PATCH = 'usp_wv_calendar_workload_employee.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '69fb85918a110df0d1304346aa8dfed4' WHERE PATCH = 'usp_wv_Dashboard_GetProductivityData.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1ab084b81b431c31a502d5b4e22f0ca3' WHERE PATCH = 'usp_wv_DayPilot_GetMonth.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '69a7f15f9f59b7a286c2c8b811f9c716' WHERE PATCH = 'usp_wv_DesktopObject_GetMyProjectsSort.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '8b03aff7504e5005eb863f4315b80572' WHERE PATCH = 'usp_wv_dto_inoutboard.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9353e5593094d2c7fde2a97a86410881' WHERE PATCH = 'usp_wv_dto_tasks.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7d0032925fd6a2189d4a4a57261cb0c2' WHERE PATCH = 'usp_wv_ESTIMATE_REV_DET_INSERT_DFLT.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6052609baeec9cf8632f01a1e2fd0ad0' WHERE PATCH = 'usp_wv_GetCPImageSettings.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'dc04429ef8eca7ecaefbece1a37d03bb' WHERE PATCH = 'usp_wv_GetCPProfileData.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '716484d126d418d50ea5b5e077823372' WHERE PATCH = 'usp_wv_GetEmpProfileData.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c1187615d20db6add38764fa9341c35d' WHERE PATCH = 'usp_wv_GetJobSpecs_ByJobandComp.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'e5f67e3d1d28a1a3555e2bc9867f7b56' WHERE PATCH = 'usp_wv_jobspecs_GetJobSpecs_ByJobandComp.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '52f72ad329a82c63a63dc065f97fe246' WHERE PATCH = 'usp_wv_Job_Template_GetTemplatesAll.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cfc369892522ce80ab6c965599cf6647' WHERE PATCH = 'usp_wv_Job_Template_GetTemplate_ByJobAndComp.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f1e026142d88e80e970b9047a3f40dea' WHERE PATCH = 'usp_wv_reports_ar_statements_client_001.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '3412b3b37c4fbd804da6c2fe127ad8af' WHERE PATCH = 'usp_wv_reports_ar_statements_client_002.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '19c513bcd8fa33ae2581361335e74796' WHERE PATCH = 'usp_wv_reports_ar_statements_client_003.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '003813807c6d92635b18501b2eb37145' WHERE PATCH = 'usp_wv_reports_ar_statements_client_004.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7319decabd54379b6631cfdf10989047' WHERE PATCH = 'usp_wv_reports_ar_statements_product_001.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0db3c7e7d6d1c30ba773993231357fc3' WHERE PATCH = 'usp_wv_reports_ar_statements_product_002.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5a0154a7cdd2461e1b0cb097ef74963c' WHERE PATCH = 'usp_wv_reports_ar_statements_product_003.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '298b160beef7ceec7cab91546758ee1b' WHERE PATCH = 'usp_wv_reports_ar_statements_product_004.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '3038d7471b3cf5f73e8b3a715cd16ec4' WHERE PATCH = 'usp_wv_RESOURCES_EMP_AVAILABILITY.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6ee0f8c33b521b73bffbd2d9f6b8e97b' WHERE PATCH = 'usp_wv_RESOURCES_EMP_FINDER.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'bde67c08e941efcd2ec1436b394ca027' WHERE PATCH = 'usp_wv_SaveCPImageSettings.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c8acc86672f7ddfd2290eb329e0839ba' WHERE PATCH = 'usp_wv_sum_rep_by_client.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '42eb60cf8a39fc8ff56e66bbca3078b1' WHERE PATCH = 'usp_wv_Traffic_Schedule_GetEstimateTasks.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cba9b9a08cc75b2201af01400c5184b0' WHERE PATCH = 'usp_wv_ts_SaveTimeSheetDay.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '38f0f35f137541bae45e5549ca7dd6b2' WHERE PATCH = 'usp_WV_WORKSPACE_TMPLT_DELETE.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '44897e03aaef6743437666c26c7d66fe' WHERE PATCH = 'V_RPT_SEC_PERMISSION.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'eb2e90e5c15ce27a7dfb0a91aa6fa059' WHERE PATCH = 'V_SEC_MODULES.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'a84bf90981c900f1a6bfb05dcf30d3b6' WHERE PATCH = 'V_SERVICE_FEE_INCOME_ONLY.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '25072340fa74df26fde7e01a27c1c783' WHERE PATCH = 'V_SERVICE_FEE_MEDIA_COMM.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1fc1c9611516511041ddc4881200ff79' WHERE PATCH = 'V_SERVICE_FEE_PRODUCTION_COMM.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '6f9c05f6de8587cc02fcf1cef9e70301' WHERE PATCH = 'V_SERVICE_FEE_RECON.view.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '7939c1eaf9d7f60876cd40ca0e0e581d' WHERE PATCH = 'WebvantageScript.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '59f9487a89b99c4dd5c476a2bf0bda4e' WHERE PATCH = 'usp_wv_RESOURCES_EMP_IS_BOOKED.proc.sql' AND VERSION_ID = 'v6.50.04' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c34b1f95ebf84dd4c8c98a73a9c30aa4' WHERE PATCH = 'sp_get_billing_rates.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '61adae9f174bd64de149efe3f9b83a59' WHERE PATCH = 'usp_wv_dto_tasks.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '8e4377bf8b8351f157e72838a3133a61' WHERE PATCH = 'usp_wv_dto_tasks_new.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '82aba58622a2f5056f1f3b4ee2013e1e' WHERE PATCH = 'usp_wv_reports_ar_statements_client_001.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '943d544f7b7160e0957b01bb0ca6f3ff' WHERE PATCH = 'usp_wv_reports_ar_statements_client_003.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '8a150307f75eed73633cbfda611dfae6' WHERE PATCH = 'advsp_import_vendor_from_staging.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '2710d9cfdbf3348b36a67fddf8d6c94b' WHERE PATCH = 'DOCUMENT COMMENT - Add X Y Position Columns.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '1bab51c59469786538a5fa77a283ea82' WHERE PATCH = 'DROP_and_CREATE_V_MAG_HEADER.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '40f5028a2795e550167f0b3841e024b1' WHERE PATCH = 'DROP_and_CREATE_V_NEWS_HEADER.view.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0382b7c66e0eb02daa5b8c748aa6b349' WHERE PATCH = 'IMP_VENDOR_STAGING.table.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'bd45775a0b093d3e2e384eea6a1cf4ba' WHERE PATCH = 'Menu Update.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '41c25ebe04fb20be397e07c9b3423dac' WHERE PATCH = 'usp_wv_calendar_GetMediaData.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'b9451bd7ea044b3447fcdf60f0e7ffe8' WHERE PATCH = 'usp_wv_Project_Status_Data.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f50ac41873860e9a8b77b0db613f526d' WHERE PATCH = 'usp_wv_Project_Status_Data_Week.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c0ab3b5fdc1ba48512170a633e17f777' WHERE PATCH = 'z - advtf_get_billing_rate.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5d801a78636da377d2d15f4187624aac' WHERE PATCH = 'zz - advsp_collect_project_schedule_cost.proc.sql' AND VERSION_ID = 'v6.50.05' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5e5d10e3d6dec75b90f076af813f1068' WHERE PATCH = 'usp_wv_ALERT_GET.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f66667236167da471438f039d47dbc1f' WHERE PATCH = 'usp_wv_calendar_workload_employee.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '0be296df305a10e71323e1c332bcca4a' WHERE PATCH = 'usp_wv_DayPilot_GetMonth.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c1bef8866747df6775741a0b2e59ea3b' WHERE PATCH = 'usp_wv_EmpListFromString.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c1bef8866747df6775741a0b2e59ea3b' WHERE PATCH = 'usp_wv_EmpListFromString.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9b6d18c61eb6bbcba001a97b0bfff434' WHERE PATCH = 'usp_wv_get_agency_goals.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5ec4951755afc914b1a86c72be9c223a' WHERE PATCH = 'usp_wv_get_emp_np_time.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '240d72081610ae2e666914ae59328840' WHERE PATCH = 'usp_wv_get_emp_np_time_all.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'aa4dda21eaf10a416bb5cde919bfe3ee' WHERE PATCH = 'usp_wv_get_emp_np_time_data.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c23b7369c087bd7e7c175d898b00d8db' WHERE PATCH = 'usp_wv_job_get_by_jobno.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'ec3cc337bf0e65cecbb791c7f02575ea' WHERE PATCH = 'advsp_notify_tasks.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '38b87cf1d2953c7a7279462e8bb9b356' WHERE PATCH = 'advsp_populate_missing_time_table.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c728b90b68e3bc1038a0e12b4a04bcba' WHERE PATCH = 'ALTER CAMPAIGN TABLE.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f2abe19309b71a3d05b611030475e30b' WHERE PATCH = 'City Update.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '443068273fe7fbdccfe5a7a1f9ddce57' WHERE PATCH = 'FixAlertPriority.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5e5d10e3d6dec75b90f076af813f1068' WHERE PATCH = 'usp_wv_ALERT_GET.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'f66667236167da471438f039d47dbc1f' WHERE PATCH = 'usp_wv_calendar_workload_employee.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '203769014a09a5abfc216751be2c2ab1' WHERE PATCH = 'usp_wv_dd_Batch_GetClientsByBatchID.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'cce97fbdbf2da1a5e88378c02ff80122' WHERE PATCH = 'usp_wv_DesktopObject_GetMyProjectsSort.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9b6d18c61eb6bbcba001a97b0bfff434' WHERE PATCH = 'usp_wv_get_agency_goals.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '240d72081610ae2e666914ae59328840' WHERE PATCH = 'usp_wv_get_emp_np_time_all.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'aa4dda21eaf10a416bb5cde919bfe3ee' WHERE PATCH = 'usp_wv_get_emp_np_time_data.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c474c14080cdb8748edc8fe1538edb8e' WHERE PATCH = 'usp_wv_job_comp_get.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = 'c23b7369c087bd7e7c175d898b00d8db' WHERE PATCH = 'usp_wv_job_get_by_jobno.proc.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '5c4126645cebedcc0dc013a753c4b738' WHERE PATCH = 'V_CORE_MEDIA_CHECK_EXPORT.view.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '001e32e5fcab7a25a4a033fc80e8adac' WHERE PATCH = 'WebvantageScript.sql' AND VERSION_ID = 'v6.50.06' " &
                            " UPDATE dbo.DB_UPDATE SET FILE_HASH = '9d75e126292e1dfe12a92d3521edd66f' WHERE PATCH = 'advsp_bcc_other_user_media.proc.sql' AND VERSION_ID = 'v6.50.07' "

    End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageDatabaseUpdateForm_CloseProgressBarEvent() Handles Me.CloseProgressBarEvent

        ProgressBarItemStatusBar_ProgressBar.Visible = False

        Me.Refresh()

    End Sub
    Private Sub AdvantageDatabaseUpdateForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        TabStripForm_MDIChildren.Visible = False
        TabStripForm_MDIChildren.MdiTabbedDocuments = False

        If _UseSecurityLogin = False Then

            LoadStartUpInformation(My.Application.CommandLineArgs)

        End If

    End Sub
    Private Sub AdvantageDatabaseUpdateForm_SetProgressBarValueEvent(CurrentValue As Integer) Handles Me.SetProgressBarValueEvent

        ProgressBarItemStatusBar_ProgressBar.Value = CurrentValue

        ProgressBarItemStatusBar_ProgressBar.Refresh()

    End Sub
    Private Sub AdvantageDatabaseUpdateForm_SetupProgressBarEvent(MinimumValue As Integer, MaximumValue As Integer, StartValue As Integer) Handles Me.SetupProgressBarEvent

        ProgressBarItemStatusBar_ProgressBar.Minimum = MinimumValue
        ProgressBarItemStatusBar_ProgressBar.Maximum = MaximumValue
        ProgressBarItemStatusBar_ProgressBar.Value = StartValue

        ProgressBarItemStatusBar_ProgressBar.Visible = True

        Me.Refresh()

    End Sub
    Private Sub AdvantageDatabaseUpdateForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        'objects
        Dim ShowDatabaseUpdateForm As Boolean = True
        Dim LicenseKeyFilesList As Generic.List(Of System.IO.FileInfo) = Nothing
        Dim ErrorMessage As String = ""
        Dim CompatibilityLevel As Integer = 0
        Dim Assembly As System.Reflection.Assembly = Nothing
        Dim StreamReader As System.IO.StreamReader = Nothing
        Dim VCCCardIDs As Generic.List(Of Integer) = Nothing
        Dim CardNumber As String = ""
        Dim CVCCode As String = ""

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            DbContext.Database.Connection.Open()

            If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AGENCY' AND COLUMN_NAME = 'COUNTY'").FirstOrDefault = 0 Then

                Try

                    DbContext.Database.ExecuteSqlCommand("ALTER TABLE [dbo].[AGENCY] ADD [COUNTY] varchar(20) NULL")

                Catch ex As Exception

                End Try

            End If

            If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AGENCY' AND COLUMN_NAME = 'COS_ENTRY_FLAG'").FirstOrDefault = 0 Then

                Try

                    DbContext.Database.ExecuteSqlCommand("ALTER TABLE [dbo].[AGENCY] ADD [COS_ENTRY_FLAG] [smallint] NOT NULL DEFAULT(0)")

                Catch ex As Exception

                End Try

            End If

            If AdvantageFramework.Security.LicenseKey.CheckForValidLicenseKey(DbContext, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, ErrorMessage) = False Then

                DbContext.Database.ExecuteSqlCommand("IF EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AGENCY' AND COLUMN_NAME = 'LICENSE_KEY' ) " & vbCrLf &
                                                     "     ALTER TABLE [dbo].[AGENCY] ALTER COLUMN [LICENSE_KEY] varchar(8000) NULL")

                LicenseKeyFilesList = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).Parent.GetFiles.Where(Function(FileInfo) FileInfo.Extension.ToUpper = ".ADVLIC").ToList

                If LicenseKeyFilesList.Count = 1 Then

                    If AdvantageFramework.Security.LicenseKey.ImportLicenseKey(_Session, LicenseKeyFilesList.FirstOrDefault.FullName, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Failed to import the new Advantage license key.  Please contact Advantage support to get your new license key.")
                        ShowDatabaseUpdateForm = False

                    End If

                Else

                    If AdvantageFramework.Security.LicenseKey.ImportLicenseKey(_Session, AdvantageFramework.WinForm.Presentation.SelectFileToOpen(My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).Parent.FullName, AdvantageFramework.FileSystem.LoadFileFilterString(AdvantageFramework.FileSystem.FileFilters.ADVLIC), "Select License Key..."), ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Failed to import the new Advantage license key.  Please contact Advantage support to get your new license key.")
                        ShowDatabaseUpdateForm = False

                    End If

                End If

            End If

            If ShowDatabaseUpdateForm Then

                If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DB_UPDATE' AND COLUMN_NAME = 'FILE_HASH'").FirstOrDefault = 0 Then

                    Try

                        DbContext.Database.ExecuteSqlCommand("ALTER TABLE [dbo].[DB_UPDATE] ADD [FILE_HASH] [varchar](MAX) NULL")

                    Catch ex As Exception
                        ShowDatabaseUpdateForm = False
                    End Try

                    If ShowDatabaseUpdateForm Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(GetFileHashUpdate)

                        Catch ex As Exception
                            ShowDatabaseUpdateForm = False
                        End Try

                    End If

                    If ShowDatabaseUpdateForm = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Failed cleaning up database update.  Please contact technical support.")
                        ShowDatabaseUpdateForm = False

                    End If

                End If

            End If

            If ShowDatabaseUpdateForm Then

                If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DB_UPDATE' AND COLUMN_NAME = 'SQL_USER'").FirstOrDefault = 0 Then

                    Try

                        DbContext.Database.ExecuteSqlCommand("ALTER TABLE [dbo].[DB_UPDATE] ADD [SQL_USER] [varchar](MAX) NULL")

                    Catch ex As Exception
                        ShowDatabaseUpdateForm = False
                    End Try

                    If ShowDatabaseUpdateForm = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Failed cleaning up database update.  Please contact technical support.")
                        ShowDatabaseUpdateForm = False

                    End If

                End If

            End If

            If ShowDatabaseUpdateForm Then

                Try

                    CompatibilityLevel = DbContext.Database.SqlQuery(Of Byte)(String.Format("SELECT [compatibility_level] FROM sys.databases WHERE name = '{0}'", _Session.DatabaseName)).FirstOrDefault

                Catch ex As Exception
					CompatibilityLevel = 100
				End Try

				If CompatibilityLevel < 100 Then

					AdvantageFramework.WinForm.MessageBox.Show("Compatibility Level for the database has to be 2008 and above.  Please contact technical support.")
					ShowDatabaseUpdateForm = False

				End If

			End If

            If ShowDatabaseUpdateForm Then

                If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SEC_USER' AND COLUMN_NAME = 'IS_INACTIVE'").FirstOrDefault = 0 Then

                    Try

                        DbContext.Database.ExecuteSqlCommand("ALTER TABLE [dbo].[SEC_USER] ADD [IS_INACTIVE] [bit] NOT NULL DEFAULT(0)")

                    Catch ex As Exception
                        ShowDatabaseUpdateForm = False
                    End Try

                End If

            End If

        End Using

        If ShowDatabaseUpdateForm Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DbContext.Database.Connection.Open()

                    If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'VCC_CARD'").FirstOrDefault = 1 Then

                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.DB_UPDATE WHERE PATCH = '{0}' AND VERSION_ID = '{1}'", "VCC Encrypt", "v6.70.00")).FirstOrDefault = 0 Then

                            If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'VCC_CARD' AND COLUMN_NAME = 'CVC_CODE'").FirstOrDefault = 1 Then

                                VCCCardIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT VCC_CARD_ID FROM dbo.VCC_CARD").ToList

                                For Each VCCCardID In VCCCardIDs

                                    CardNumber = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CARD_NUMBER FROM dbo.VCC_CARD WHERE VCC_CARD_ID = {0}", VCCCardID)).FirstOrDefault
                                    CVCCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CVC_CODE FROM dbo.VCC_CARD WHERE VCC_CARD_ID = {0}", VCCCardID)).FirstOrDefault

                                    CardNumber = AdvantageFramework.Security.Encryption.ASCIIEncoding(CardNumber)
                                    CVCCode = AdvantageFramework.Security.Encryption.ASCIIEncoding(CVCCode)

                                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.VCC_CARD SET CARD_NUMBER = '{0}', CVC_CODE = '{1}' WHERE VCC_CARD_ID = {2}", CardNumber, CVCCode, VCCCardID))

                                Next

                            Else

                                VCCCardIDs = DbContext.Database.SqlQuery(Of Integer)("SELECT VCC_CARD_ID FROM dbo.VCC_CARD").ToList

                                For Each VCCCardID In VCCCardIDs

                                    CardNumber = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CARD_NUMBER FROM dbo.VCC_CARD WHERE VCC_CARD_ID = {0}", VCCCardID)).FirstOrDefault
                                    CVCCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CVS_CODE FROM dbo.VCC_CARD WHERE VCC_CARD_ID = {0}", VCCCardID)).FirstOrDefault

                                    CardNumber = AdvantageFramework.Security.Encryption.ASCIIEncoding(CardNumber)
                                    CVCCode = AdvantageFramework.Security.Encryption.ASCIIEncoding(CVCCode)

                                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.VCC_CARD SET CARD_NUMBER = '{0}', CVS_CODE = '{1}' WHERE VCC_CARD_ID = {2}", CardNumber, CVCCode, VCCCardID))

                                Next

                            End If

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.DB_UPDATE([VERSION_ID], [PATCH], [DESCRIPTION], [DATE_APPLIED], [FUNCTION_NAME])" &
                                                                               "VALUES('{0}', '{1}', '{2}', GETDATE(), '{3}')", "v6.70.00", "VCC Encrypt", "VCC Encrypt", "VCC Encrypt"))

                        End If

                    End If

                End Using

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show("Error encyrpting VCC cards. Please contact software support.")
                ShowDatabaseUpdateForm = False
            End Try

        End If

        If ShowDatabaseUpdateForm Then

            Try

                Assembly = System.Reflection.Assembly.GetExecutingAssembly

                StreamReader = New System.IO.StreamReader(Assembly.GetManifestResourceStream("Advantage_Database_Update.StopUpdate.xml"))

            Catch ex As Exception

            End Try

            AdvantageFramework.Database.Presentation.DatabaseUpdateForm.ShowForm(_InternalOnlyMode, _BatchMode, StreamReader)

        Else

            Me.Close()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class
