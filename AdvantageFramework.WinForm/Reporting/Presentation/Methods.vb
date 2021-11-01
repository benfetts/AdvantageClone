Namespace Reporting.Presentation

    <HideModuleName()> _
    Public Module Methods

        Friend Event UpdateCustomReportImportProgressEvent(ByVal StatusMessage As String, ByVal OverallProgress As Integer, ByVal CurrentActionProgress As Integer)
        Friend Event ResetCustomReportImportOverallProgressValuesEvent(ByVal Minimum As Integer, ByVal Maximum As Integer, ByVal StartValue As Integer)
        Friend Event ResetCustomReportImportCurrentActionProgressValuesEvent(ByVal Minimum As Integer, ByVal Maximum As Integer, ByVal StartValue As Integer)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function ScrubData(ByVal FileData As String) As String

            FileData = FileData.Trim

            FileData = FileData.Replace("~", ",")

            If FileData.StartsWith("""") Then

                FileData = FileData.Substring(1)

            End If

            If FileData.EndsWith("""") Then

                FileData = FileData.Substring(0, FileData.Length - 2)

            End If

            ScrubData = FileData

        End Function
        Public Sub LegacyCustomReportUpdate(ByVal Session As AdvantageFramework.Security.Session, ByVal File As String)

            'objects
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FileLines() As String = Nothing
            Dim FileLineData() As String = Nothing
            Dim FileLineCounter As Integer = 0
            Dim CustomReportsList As Generic.List(Of AdvantageFramework.Database.Entities.CustomReport) = Nothing
            Dim ImportedCustomReportsList As Generic.List(Of AdvantageFramework.Database.Entities.CustomReport) = Nothing
            Dim NewCustomReportsList As Generic.List(Of AdvantageFramework.Database.Entities.CustomReport) = Nothing
            Dim UpdatingCustomReportsList As Generic.List(Of AdvantageFramework.Database.Entities.CustomReport) = Nothing
            Dim CustomReport As AdvantageFramework.Database.Entities.CustomReport = Nothing
            Dim ImportedCustomReport As AdvantageFramework.Database.Entities.CustomReport = Nothing
            Dim UpdateReport As Boolean = False
            Dim LoadingCustomReportStatusMessage As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If My.Computer.FileSystem.FileExists(File) Then

                    RaiseEvent ResetCustomReportImportOverallProgressValuesEvent(0, 6, 0)

                    RaiseEvent UpdateCustomReportImportProgressEvent("Loading custom reports data from the system...", 0, 0)

                    CustomReportsList = AdvantageFramework.Database.Procedures.CustomReport.Load(DbContext).ToList

                    RaiseEvent UpdateCustomReportImportProgressEvent("Completed loading custom reports data from the system ...", 1, 0)

                    Try

                        StreamReader = New System.IO.StreamReader(File)

                    Catch ex As Exception
                        StreamReader = Nothing
                    Finally

                        If StreamReader IsNot Nothing Then

                            FileLines = StreamReader.ReadToEnd.Split(vbCrLf)

                            StreamReader.Close()
                            StreamReader.Dispose()

                        End If

                    End Try

                    If FileLines IsNot Nothing AndAlso FileLines.Count > 0 Then

                        RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, FileLines.Count, 0)
                        RaiseEvent UpdateCustomReportImportProgressEvent("Loading custom reports data from the file ...", 1, 0)

                        ImportedCustomReportsList = New Generic.List(Of AdvantageFramework.Database.Entities.CustomReport)

                        For Each FileLine In FileLines

                            FileLineData = FileLine.Split(",")

                            If FileLineCounter <> 0 AndAlso FileLineData.Count = 6 Then

                                Try

                                    FileLineData(0) = ScrubData(FileLineData(0))
                                    FileLineData(1) = ScrubData(FileLineData(1))
                                    FileLineData(2) = ScrubData(FileLineData(2))
                                    FileLineData(3) = ScrubData(FileLineData(3))
                                    FileLineData(4) = ScrubData(FileLineData(4))
                                    FileLineData(5) = ScrubData(FileLineData(5))

                                    CustomReport = New AdvantageFramework.Database.Entities.CustomReport

                                    CustomReport.DbContext = DbContext
                                    CustomReport.Name = FileLineData(0)
                                    CustomReport.Description = FileLineData(1)
                                    CustomReport.LegacyModuleCode = FileLineData(2)
                                    CustomReport.IsCustom = FileLineData(3)
                                    CustomReport.ReportCode = FileLineData(4)
                                    CustomReport.IsInactive = FileLineData(5)

                                    ImportedCustomReportsList.Add(CustomReport)

                                Catch ex As Exception
                                    CustomReport = Nothing
                                End Try

                            Else

                                CustomReport = Nothing

                            End If

                            FileLineCounter += 1

                            If CustomReport IsNot Nothing Then

                                LoadingCustomReportStatusMessage = "Loading custom report data from the file --> " & CustomReport.Name & vbNewLine & LoadingCustomReportStatusMessage

                            End If

                        Next

                        RaiseEvent UpdateCustomReportImportProgressEvent(LoadingCustomReportStatusMessage, 1, FileLineCounter)

                        RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 0, 0)

                    End If

                    If ImportedCustomReportsList IsNot Nothing Then

                        RaiseEvent UpdateCustomReportImportProgressEvent("Deleting custom reports...", 2, 0)

                        AdvantageFramework.Database.Procedures.CustomReport.DeleteByCustomReportNames(DbContext, CustomReportsList.Where(Function(CustomRpt) ImportedCustomReportsList.Any(Function(ImportedCustomRpt) ImportedCustomRpt.Name = CustomRpt.Name) = False).Select(Function(CustomRpt) CustomRpt.Name).ToArray)

                        RaiseEvent UpdateCustomReportImportProgressEvent("Inserting custom reports...", 3, 0)

                        NewCustomReportsList = ImportedCustomReportsList.Where(Function(ImportedCustomRpt) CustomReportsList.Any(Function(CustomRpt) CustomRpt.Name = ImportedCustomRpt.Name) = False).ToList

                        RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, NewCustomReportsList.Count, 0)

                        For Each CustomReport In NewCustomReportsList

                            RaiseEvent UpdateCustomReportImportProgressEvent("Inserting custom report --> " & CustomReport.Name, 3, NewCustomReportsList.IndexOf(CustomReport))

                            If AdvantageFramework.Database.Procedures.CustomReport.Insert(DbContext, CustomReport) = False Then

                                RaiseEvent UpdateCustomReportImportProgressEvent("Insert failed of custom report --> " & CustomReport.Name, 3, NewCustomReportsList.IndexOf(CustomReport))

                                Try

                                    DbContext.CustomReports.Remove(CustomReport)
                                    DbContext.Detach(CustomReport)

                                Catch ex As Exception

                                End Try

                            Else

                                RaiseEvent UpdateCustomReportImportProgressEvent("Insert successful of custom report --> " & CustomReport.Name, 3, NewCustomReportsList.IndexOf(CustomReport))

                            End If

                        Next

                        RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 0, 0)

                        RaiseEvent UpdateCustomReportImportProgressEvent("Updating custom reports...", 4, 0)

                        UpdatingCustomReportsList = ImportedCustomReportsList.Where(Function(ImportedCustomRpt) CustomReportsList.Any(Function(CustomRpt) CustomRpt.Name = ImportedCustomRpt.Name) = True).ToList

                        RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, UpdatingCustomReportsList.Count, 0)

                        For Each ImportedCustomReport In UpdatingCustomReportsList

                            UpdateReport = False

                            Try

                                CustomReport = CustomReportsList.SingleOrDefault(Function(CustomRpt) CustomRpt.Name = ImportedCustomReport.Name)

                            Catch ex As Exception
                                CustomReport = Nothing
                            End Try

                            If CustomReport IsNot Nothing Then

                                If CustomReport.Description <> ImportedCustomReport.Description Then

                                    CustomReport.Description = ImportedCustomReport.Description
                                    UpdateReport = True

                                End If

                                If CustomReport.LegacyModuleCode <> ImportedCustomReport.LegacyModuleCode Then

                                    CustomReport.LegacyModuleCode = ImportedCustomReport.LegacyModuleCode
                                    UpdateReport = True

                                End If

                                If CustomReport.IsCustom <> ImportedCustomReport.IsCustom Then

                                    CustomReport.IsCustom = ImportedCustomReport.IsCustom
                                    UpdateReport = True

                                End If

                                If CustomReport.ReportCode <> ImportedCustomReport.ReportCode Then

                                    CustomReport.ReportCode = ImportedCustomReport.ReportCode
                                    UpdateReport = True

                                End If

                                If UpdateReport Then

                                    RaiseEvent UpdateCustomReportImportProgressEvent("Updating custom report --> " & CustomReport.Name, 4, UpdatingCustomReportsList.IndexOf(ImportedCustomReport))

                                    DbContext.UpdateObject(CustomReport)

                                End If

                            End If

                        Next

                        Try

                            DbContext.SaveChanges()

                            RaiseEvent UpdateCustomReportImportProgressEvent("Update successful!", 5, 0)

                        Catch ex As Exception
                            RaiseEvent UpdateCustomReportImportProgressEvent("Update failed!", 5, 0)
                        End Try

                    End If

                    RaiseEvent UpdateCustomReportImportProgressEvent("Finished updating custom reports...", 6, 0)

                End If

            End Using

        End Sub
        Public Sub CustomReportImport(ByVal Session As AdvantageFramework.Security.Session, ByVal File As String)

            'objects
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim HasREPXFile As Boolean = False
            Dim HasSQLFile As Boolean = False
            Dim REPXMemoryStream As System.IO.Stream = Nothing
            Dim SQLMemoryStream As System.IO.Stream = Nothing
            Dim ZipEntryIndex As Integer = 0
            Dim ZipEntry As Ionic.Zip.ZipEntry = Nothing
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim ReportDefinition As String = ""
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim SQLText As String = ""
            Dim SQLTextRan As Boolean = False
            Dim StringReader As System.IO.StringReader = Nothing
            Dim ScriptText As String = ""
            Dim ScriptLine As String = ""

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If My.Computer.FileSystem.FileExists(File) Then

                    RaiseEvent ResetCustomReportImportOverallProgressValuesEvent(0, 3, 0)
                    RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 1, 0)
                    RaiseEvent UpdateCustomReportImportProgressEvent("Loading zip file into memory...", 0, 0)

                    Try

                        ZipFile = Ionic.Zip.ZipFile.Read(File)

                        RaiseEvent UpdateCustomReportImportProgressEvent("Checking zip file items...", 1, 1)
                        RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, ZipFile.Count, 0)

                        For Each ZipEntry In ZipFile

                            If ZipEntry.FileName.ToUpper.EndsWith(".REPX") Then

                                REPXMemoryStream = New System.IO.MemoryStream

                                ZipEntry.Extract(REPXMemoryStream)

                                If REPXMemoryStream IsNot Nothing AndAlso REPXMemoryStream.Length > 0 Then

                                    HasREPXFile = True

                                End If

                            ElseIf ZipEntry.FileName.ToUpper.EndsWith(".SQL") Then

                                SQLMemoryStream = New System.IO.MemoryStream

                                ZipEntry.Extract(SQLMemoryStream)

                                If SQLMemoryStream IsNot Nothing AndAlso SQLMemoryStream.Length > 0 Then

                                    HasSQLFile = True

                                End If

                            End If

                            If HasREPXFile AndAlso HasSQLFile Then

                                Exit For

                            End If

                        Next

                    Finally

                        If ZipFile IsNot Nothing Then

                            RaiseEvent UpdateCustomReportImportProgressEvent("All zip file items loaded...", 2, ZipFile.Count)

                            ZipFile.Dispose()
                            ZipFile = Nothing

                        End If

                    End Try

                    RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 2, 0)

                    If HasREPXFile AndAlso HasSQLFile Then

                        RaiseEvent UpdateCustomReportImportProgressEvent("Installing Report File...", 2, 0)

                        XtraReport = New DevExpress.XtraReports.UI.XtraReport

                        XtraReport.LoadLayout(REPXMemoryStream)

                        DirectCast(XtraReport.DataAdapter, System.Data.SqlClient.SqlDataAdapter).SelectCommand.Connection.ConnectionString = Session.ConnectionString

                        Try

                            If REPXMemoryStream IsNot Nothing Then

                                REPXMemoryStream.Close()
                                REPXMemoryStream.Dispose()

                                REPXMemoryStream = Nothing

                            End If

                        Catch ex As Exception
                            REPXMemoryStream = Nothing
                        End Try

                        REPXMemoryStream = New System.IO.MemoryStream

                        XtraReport.SaveLayout(REPXMemoryStream)

                        REPXMemoryStream.Position = 0

                        Using StreamReader = New System.IO.StreamReader(REPXMemoryStream)

                            ReportDefinition = StreamReader.ReadToEnd

                        End Using

                        Try

                            If REPXMemoryStream IsNot Nothing Then

                                REPXMemoryStream.Close()
                                REPXMemoryStream.Dispose()

                                REPXMemoryStream = Nothing

                            End If

                        Catch ex As Exception
                            REPXMemoryStream = Nothing
                        End Try

                        UserDefinedReport = New AdvantageFramework.Reporting.Database.Entities.UserDefinedReport

                        UserDefinedReport.DbContext = ReportingDbContext

                        UserDefinedReport.Description = XtraReport.DisplayName
                        UserDefinedReport.ReportDefinition = ReportDefinition
                        UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.Custom
                        UserDefinedReport.CreatedByUserCode = Session.UserCode
                        UserDefinedReport.CreatedDate = Now
                        UserDefinedReport.UpdatedByUserCode = Session.UserCode
                        UserDefinedReport.UpdatedDate = Now

                        If AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Insert(ReportingDbContext, UserDefinedReport) Then

                            RaiseEvent UpdateCustomReportImportProgressEvent("Installing SQL File...", 2, 1)

                            SQLMemoryStream.Position = 0

                            Using StreamReader = New System.IO.StreamReader(SQLMemoryStream)

                                SQLText = StreamReader.ReadToEnd

                            End Using

                            Try

                                If SQLMemoryStream IsNot Nothing Then

                                    SQLMemoryStream.Close()
                                    SQLMemoryStream.Dispose()

                                    SQLMemoryStream = Nothing

                                End If

                            Catch ex As Exception
                                SQLMemoryStream = Nothing
                            End Try

                            Try

                                StringReader = New System.IO.StringReader(SQLText)

                                ScriptText = StringReader.ReadLine() & vbCrLf

                                Do While StringReader.Peek <> -1

                                    ScriptLine = ""

                                    ScriptLine = StringReader.ReadLine()

                                    If ScriptLine.Trim = "GO" Then

                                        ReportingDbContext.Database.ExecuteSqlCommand(ScriptText)

                                        ScriptText = ""

                                    Else

                                        ScriptText &= ScriptLine & vbNewLine

                                    End If

                                Loop

                                ScriptText = ScriptText.Trim

                                If ScriptText <> "" AndAlso ScriptText <> "GO" Then

                                    ReportingDbContext.Database.ExecuteSqlCommand(ScriptText)

                                End If

                                SQLTextRan = True

                            Catch ex As Exception
                                SQLTextRan = False
                            End Try

                            If SQLTextRan Then

                                RaiseEvent UpdateCustomReportImportProgressEvent("Custom Report Installed Successfully!...", 3, 2)

                            Else

                                RaiseEvent UpdateCustomReportImportProgressEvent("Failed updating database...", 3, 0)

                            End If

                        Else

                            RaiseEvent UpdateCustomReportImportProgressEvent("Failed inserting report into database...", 3, 0)

                        End If

                    Else

                        RaiseEvent UpdateCustomReportImportProgressEvent("Zip file doesnt contain all items for custom report import...", 3, 0)

                    End If

                Else

                    RaiseEvent UpdateCustomReportImportProgressEvent("Error loading zip file into memory...", 3, 0)

                End If

            End Using

        End Sub
        Public Sub ReportImport(ByVal Session As AdvantageFramework.Security.Session, ByVal File As String)

            'objects
            Dim IsValid As Boolean = False
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim ReportDefinition As String = ""
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RaiseEvent ResetCustomReportImportOverallProgressValuesEvent(0, 3, 0)
                RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 1, 0)
                RaiseEvent UpdateCustomReportImportProgressEvent("Validating report file...", 0, 0)

                Try

                    If My.Computer.FileSystem.FileExists(File) Then

                        If File.ToUpper.EndsWith(".REPX") Then

                            IsValid = True

                        End If

                    End If

                Catch ex As Exception
                    IsValid = False
                End Try

                If IsValid Then

                    RaiseEvent UpdateCustomReportImportProgressEvent("Report file valid...", 1, 1)

                    RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 1, 0)

                    RaiseEvent UpdateCustomReportImportProgressEvent("Checking Advantage Report integrity...", 1, 0)

                    Try

                        XtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile(File, True)

                        If TypeOf XtraReport Is AdvantageFramework.Reporting.Reports.IUserDefinedReport Then

                            Using MemoryStream = New System.IO.MemoryStream

                                XtraReport.SaveLayout(MemoryStream)

                                MemoryStream.Position = 0

                                Using StreamReader = New System.IO.StreamReader(MemoryStream)

                                    ReportDefinition = StreamReader.ReadToEnd

                                End Using

                            End Using

                        ElseIf TypeOf XtraReport Is AdvantageFramework.Reporting.Reports.ICustomInvoice Then

                            Using MemoryStream = New System.IO.MemoryStream

                                XtraReport.SaveLayout(MemoryStream)

                                MemoryStream.Position = 0

                                Using StreamReader = New System.IO.StreamReader(MemoryStream)

                                    ReportDefinition = StreamReader.ReadToEnd

                                End Using

                            End Using

                        Else

                            Throw New Exception("")

                        End If

                    Catch ex As Exception
                        IsValid = False
                    End Try

                    If IsValid Then

                        RaiseEvent UpdateCustomReportImportProgressEvent("Installing report...", 2, 1)

                        RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 1, 0)

                        If TypeOf XtraReport Is AdvantageFramework.Reporting.Reports.IUserDefinedReport Then

                            Try

                                UserDefinedReport = New AdvantageFramework.Reporting.Database.Entities.UserDefinedReport

                                UserDefinedReport.DbContext = ReportingDbContext

                                UserDefinedReport.Description = XtraReport.DisplayName
                                UserDefinedReport.ReportDefinition = ReportDefinition
                                UserDefinedReport.AdvancedReportWriterType = DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport
                                UserDefinedReport.CreatedByUserCode = Session.UserCode
                                UserDefinedReport.CreatedDate = Now
                                UserDefinedReport.UpdatedByUserCode = Session.UserCode
                                UserDefinedReport.UpdatedDate = Now

                                IsValid = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Insert(ReportingDbContext, UserDefinedReport)

                            Catch ex As Exception
                                IsValid = False
                            End Try

                        ElseIf TypeOf XtraReport Is AdvantageFramework.Reporting.Reports.ICustomInvoice Then

                            Try

                                CustomInvoice = New AdvantageFramework.Reporting.Database.Entities.CustomInvoice

                                CustomInvoice.DbContext = ReportingDbContext

                                CustomInvoice.Description = XtraReport.DisplayName
                                CustomInvoice.ReportDefinition = ReportDefinition
                                CustomInvoice.Type = DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.ICustomInvoice).InvoiceType
                                CustomInvoice.CreatedByUserCode = Session.UserCode
                                CustomInvoice.CreatedDate = Now
                                CustomInvoice.UpdatedByUserCode = Session.UserCode
                                CustomInvoice.UpdatedDate = Now

                                IsValid = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.Insert(ReportingDbContext, CustomInvoice)

                            Catch ex As Exception
                                IsValid = False
                            End Try

                        End If

                        If IsValid Then

                            RaiseEvent UpdateCustomReportImportProgressEvent("Report Installed Successfully!...", 3, 1)

                        Else

                            RaiseEvent UpdateCustomReportImportProgressEvent("Failed inserting report into database...", 0, 0)

                        End If

                    Else

                        RaiseEvent UpdateCustomReportImportProgressEvent("Report file is not for Advantage...", 0, 0)

                    End If

                Else

                    RaiseEvent UpdateCustomReportImportProgressEvent("Report file is invalid...", 0, 0)

                End If

            End Using

        End Sub
        Public Sub DynamicReportImport(ByVal Session As AdvantageFramework.Security.Session, ByVal File As String)

            'objects
            Dim IsValid As Boolean = False
			Dim XMLString As String = ""
			Dim DynamicReportXML As AdvantageFramework.Reporting.Database.Classes.DynamicReportXML = Nothing
			Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RaiseEvent ResetCustomReportImportOverallProgressValuesEvent(0, 3, 0)
                RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 1, 0)
                RaiseEvent UpdateCustomReportImportProgressEvent("Validating dynamic report file...", 0, 0)

                Try

                    If My.Computer.FileSystem.FileExists(File) Then

                        If File.ToUpper.EndsWith(".XML") Then

                            XMLString = My.Computer.FileSystem.ReadAllText(File)

                            IsValid = True

                        End If

                    End If

                Catch ex As Exception
                    IsValid = False
                End Try

                If IsValid Then

                    RaiseEvent UpdateCustomReportImportProgressEvent("Dynamic report file valid...", 1, 1)

                    RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 1, 0)

                    RaiseEvent UpdateCustomReportImportProgressEvent("Checking Advantage Report integrity...", 1, 0)

                    Try

						DynamicReportXML = ImportFromXML(XMLString, GetType(AdvantageFramework.Reporting.Database.Classes.DynamicReportXML), GetType(AdvantageFramework.Reporting.Database.Classes.DynamicReportColumnXML),
														 GetType(AdvantageFramework.Reporting.Database.Classes.DynamicReportSummaryItemXML), GetType(AdvantageFramework.Reporting.Database.Classes.DynamicReportUnboundColumnXML))

						If DynamicReportXML Is Nothing Then

							Throw New Exception("")

						Else

							DynamicReport = DynamicReportXML.CreateEntity

						End If

					Catch ex As Exception
                        IsValid = False
                    End Try

                    If IsValid Then

                        RaiseEvent UpdateCustomReportImportProgressEvent("Installing report...", 2, 1)

                        RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 1, 0)

                        Try

                            DynamicReport.DbContext = ReportingDbContext

                            DynamicReport.ID = 0
                            DynamicReport.CreatedByUserCode = Session.UserCode
                            DynamicReport.CreatedDate = Now
                            DynamicReport.UpdatedByUserCode = Session.UserCode
                            DynamicReport.UpdatedDate = Now
                            DynamicReport.TemplateCode = Nothing
                            DynamicReport.UserDefinedReportCategoryID = Nothing

                            For Each DynamicReportColumn In DynamicReport.DynamicReportColumns

                                DynamicReportColumn.ID = 0
                                DynamicReportColumn.DynamicReportID = 0
                                DynamicReportColumn.TemplateDetailID = Nothing
                                DynamicReportColumn.DynamicReport = DynamicReport

                            Next

                            For Each DynamicReportSummaryItem In DynamicReport.DynamicReportSummaryItems

                                DynamicReportSummaryItem.ID = 0
                                DynamicReportSummaryItem.DynamicReportID = 0
                                DynamicReportSummaryItem.DynamicReport = DynamicReport

                            Next

                            For Each DynamicReportUnboundColumn In DynamicReport.DynamicReportUnboundColumns

                                DynamicReportUnboundColumn.ID = 0
                                DynamicReportUnboundColumn.DynamicReportID = 0
                                DynamicReportUnboundColumn.DynamicReport = DynamicReport

                            Next

                            ReportingDbContext.DynamicReports.Add(DynamicReport)

                            ReportingDbContext.SaveChanges()

                        Catch ex As Exception
                            IsValid = False
                        End Try

                        If IsValid Then

                            RaiseEvent UpdateCustomReportImportProgressEvent("Report Installed Successfully!...", 3, 1)

                        Else

                            RaiseEvent UpdateCustomReportImportProgressEvent("Failed inserting report into database...", 0, 0)

                        End If

                    Else

                        RaiseEvent UpdateCustomReportImportProgressEvent("Report file is not for Advantage...", 0, 0)

                    End If

                Else

                    RaiseEvent UpdateCustomReportImportProgressEvent("Report file is invalid...", 0, 0)

                End If

            End Using

        End Sub
        Public Sub GLReportTemplateImport(ByVal Session As AdvantageFramework.Security.Session, ByVal GLReportTemplateFile As String, ByVal GLReportUserDefinedReportFile As String)

            'objects
            Dim IsValid As Boolean = False
            Dim XMLString As String = ""
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim ReportDefinition As String = ""
            Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing
            Dim NewGLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing
            Dim NewGLReportTemplateDepartmentTeamPreset As AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset = Nothing
            Dim NewGLReportTemplateOfficePreset As AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset = Nothing
            Dim NewGLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport = Nothing
			Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
			Dim GLReportTemplateXML As AdvantageFramework.Database.Classes.GLReportTemplateXML = Nothing

			Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RaiseEvent ResetCustomReportImportOverallProgressValuesEvent(0, 3, 0)
                RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 1, 0)
                RaiseEvent UpdateCustomReportImportProgressEvent("Validating GL report template files...", 0, 0)

                Try

                    If My.Computer.FileSystem.FileExists(GLReportTemplateFile) Then

                        If GLReportTemplateFile.ToUpper.EndsWith(".XML") Then

                            XMLString = My.Computer.FileSystem.ReadAllText(GLReportTemplateFile)

                            IsValid = True

                        End If

                    End If

                    If IsValid Then

                        Try

                            If String.IsNullOrEmpty(GLReportUserDefinedReportFile) = False Then

                                If My.Computer.FileSystem.FileExists(GLReportUserDefinedReportFile) Then

                                    If GLReportUserDefinedReportFile.ToUpper.EndsWith(".REPX") Then

                                        IsValid = True

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                            IsValid = False
                        End Try

                    End If

                Catch ex As Exception
                    IsValid = False
                End Try

                If IsValid Then

                    RaiseEvent UpdateCustomReportImportProgressEvent("GL report file valid...", 1, 1)

                    RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 1, 0)

                    RaiseEvent UpdateCustomReportImportProgressEvent("Checking Advantage Report integrity...", 1, 0)

                    Try

						GLReportTemplateXML = ImportFromXML(XMLString, GetType(AdvantageFramework.Database.Classes.GLReportTemplateXML), GetType(AdvantageFramework.Database.Classes.GLReportTemplateColumnXML),
															GetType(AdvantageFramework.Database.Classes.GLReportTemplateRowXML), GetType(AdvantageFramework.Database.Classes.GLReportTemplateRowRelationXML),
															GetType(AdvantageFramework.Database.Classes.GLReportTemplateDepartmentTeamPresetXML), GetType(AdvantageFramework.Database.Classes.GLReportTemplateOfficePresetXML),
															GetType(AdvantageFramework.Database.Classes.GLReportTemplatePctOfRowColumnRelationXML))

						If GLReportTemplateXML Is Nothing Then

							Throw New Exception("")

						Else

							GLReportTemplate = GLReportTemplateXML.CreateEntity

						End If

					Catch ex As Exception
                        IsValid = False
                    End Try

                    If IsValid Then

                        Try

                            If String.IsNullOrEmpty(GLReportUserDefinedReportFile) = False Then

                                XtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile(GLReportUserDefinedReportFile, True)

                                If TypeOf XtraReport Is AdvantageFramework.Reporting.Reports.GeneralLedger.ReportWriter.BaseGLReportTemplateReport Then

                                    Using MemoryStream = New System.IO.MemoryStream

                                        XtraReport.SaveLayout(MemoryStream)

                                        MemoryStream.Position = 0

                                        Using StreamReader = New System.IO.StreamReader(MemoryStream)

                                            ReportDefinition = StreamReader.ReadToEnd

                                        End Using

                                    End Using

                                Else

                                    Throw New Exception("")

                                End If

                            End If

                        Catch ex As Exception
                            IsValid = False
                        End Try

                    End If

                    If IsValid Then

                        RaiseEvent UpdateCustomReportImportProgressEvent("Installing report...", 2, 1)

                        RaiseEvent ResetCustomReportImportCurrentActionProgressValuesEvent(0, 1, 0)

                        DbContext.Database.Connection.Open()

                        DbTransaction = DbContext.Database.BeginTransaction

                        Try

                            NewGLReportTemplate = New AdvantageFramework.Database.Entities.GLReportTemplate

                            NewGLReportTemplate.DbContext = DbContext

                            NewGLReportTemplate.Description = GLReportTemplate.Description
                            NewGLReportTemplate.DashboardLayout = GLReportTemplate.DashboardLayout
                            NewGLReportTemplate.PostPeriodCode = GLReportTemplate.PostPeriodCode
                            NewGLReportTemplate.ReportType = GLReportTemplate.ReportType
                            NewGLReportTemplate.PrintColumnHeadingsOnEveryPage = GLReportTemplate.PrintColumnHeadingsOnEveryPage
                            NewGLReportTemplate.SortRowsBy = GLReportTemplate.SortRowsBy

                            If AdvantageFramework.Database.Procedures.GLReportTemplate.Insert(DbContext, NewGLReportTemplate) Then

                                IsValid = True
                                '
                                '======================================================
                                '
                                '======================================================
                                '
                                For Each GLReportTemplateColumn In GLReportTemplate.GLReportTemplateColumns

                                    If CopyGLReportTemplateColumn(DbContext, NewGLReportTemplate.ID, GLReportTemplate, GLReportTemplateColumn) = False Then

                                        IsValid = False
                                        Exit For

                                    End If

                                Next
                                '
                                '======================================================
                                '
                                '======================================================
                                '
                                If IsValid Then

                                    For Each GLReportTemplateRow In GLReportTemplate.GLReportTemplateRows

                                        If CopyGLReportTemplateRow(DbContext, NewGLReportTemplate.ID, GLReportTemplate, GLReportTemplateRow) = False Then

                                            IsValid = False
                                            Exit For

                                        End If

                                    Next

                                End If
                                '
                                '======================================================
                                '
                                '======================================================
                                '
                                If IsValid Then

                                    For Each GLReportTemplateDepartmentTeamPreset In GLReportTemplate.GLReportTemplateDepartmentTeamPresets

                                        NewGLReportTemplateDepartmentTeamPreset = New AdvantageFramework.Database.Entities.GLReportTemplateDepartmentTeamPreset

                                        NewGLReportTemplateDepartmentTeamPreset.GLReportTemplateID = NewGLReportTemplate.ID
                                        NewGLReportTemplateDepartmentTeamPreset.DepartmentTeamCode = GLReportTemplateDepartmentTeamPreset.DepartmentTeamCode

                                        If AdvantageFramework.Database.Procedures.GLReportTemplateDepartmentTeamPreset.Insert(DbContext, NewGLReportTemplateDepartmentTeamPreset) = False Then

                                            IsValid = False
                                            Exit For

                                        End If

                                    Next

                                End If
                                '
                                '======================================================
                                '
                                '======================================================
                                '
                                If IsValid Then

                                    For Each GLReportTemplateOfficePreset In GLReportTemplate.GLReportTemplateOfficePresets

                                        NewGLReportTemplateOfficePreset = New AdvantageFramework.Database.Entities.GLReportTemplateOfficePreset

                                        NewGLReportTemplateOfficePreset.GLReportTemplateID = NewGLReportTemplate.ID
                                        NewGLReportTemplateOfficePreset.OfficeCode = GLReportTemplateOfficePreset.OfficeCode

                                        If AdvantageFramework.Database.Procedures.GLReportTemplateOfficePreset.Insert(DbContext, NewGLReportTemplateOfficePreset) = False Then

                                            IsValid = False
                                            Exit For

                                        End If

                                    Next

                                End If

                                If IsValid Then

                                    If String.IsNullOrEmpty(ReportDefinition) = False AndAlso XtraReport IsNot Nothing Then

                                        NewGLReportUserDefReport = New AdvantageFramework.Database.Entities.GLReportUserDefReport

                                        NewGLReportUserDefReport.DbContext = DbContext

                                        NewGLReportUserDefReport.Description = XtraReport.DisplayName
                                        NewGLReportUserDefReport.ReportDefinition = ReportDefinition
                                        NewGLReportUserDefReport.CreatedByUserCode = Session.UserCode
                                        NewGLReportUserDefReport.CreatedDate = Now
                                        NewGLReportUserDefReport.ModifiedByUserCode = Nothing
                                        NewGLReportUserDefReport.ModifiedDate = Nothing

                                        IsValid = AdvantageFramework.Database.Procedures.GLReportUserDefReport.Insert(DbContext, NewGLReportUserDefReport)

                                        If IsValid Then

                                            NewGLReportTemplate.GLReportUserDefReportID = NewGLReportUserDefReport.ID

                                            AdvantageFramework.Database.Procedures.GLReportTemplate.Update(DbContext, NewGLReportTemplate)

                                        End If

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                            IsValid = False
                        End Try

                        If IsValid Then

                            Try

                                DbTransaction.Commit()

                            Catch ex As Exception
                                IsValid = False
                            End Try

                        Else

                            DbTransaction.Rollback()

                        End If

                        DbContext.Database.Connection.Close()

                        If IsValid Then

                            RaiseEvent UpdateCustomReportImportProgressEvent("Report Installed Successfully!...", 3, 1)

                        Else

                            RaiseEvent UpdateCustomReportImportProgressEvent("Failed inserting report into database...", 0, 0)

                        End If

                    Else

                        RaiseEvent UpdateCustomReportImportProgressEvent("Report file is not for Advantage...", 0, 0)

                    End If

                Else

                    RaiseEvent UpdateCustomReportImportProgressEvent("Report file is invalid...", 0, 0)

                End If

            End Using

        End Sub
        Private Function CopyGLReportTemplateColumn(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer,
                                                    ByVal GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate,
                                                    ByVal GLReportTemplateColumn As AdvantageFramework.Database.Entities.GLReportTemplateColumn) As Boolean

            'objects
            Dim Copied As Boolean = True
            Dim NewGLReportTemplateColumn As AdvantageFramework.Database.Entities.GLReportTemplateColumn = Nothing
            Dim NewGLReportTemplatePctOfRowColumnRelation As AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation = Nothing

            NewGLReportTemplateColumn = New AdvantageFramework.Database.Entities.GLReportTemplateColumn

            NewGLReportTemplateColumn.GLReportTemplateID = GLReportTemplateID
            NewGLReportTemplateColumn.Description = GLReportTemplateColumn.Description
            NewGLReportTemplateColumn.Name = GLReportTemplateColumn.Name
            NewGLReportTemplateColumn.ColumnIndex = GLReportTemplateColumn.ColumnIndex
            NewGLReportTemplateColumn.Type = GLReportTemplateColumn.Type
            NewGLReportTemplateColumn.DataType = GLReportTemplateColumn.DataType
            NewGLReportTemplateColumn.PreviousYears = GLReportTemplateColumn.PreviousYears
            NewGLReportTemplateColumn.PeriodOption = GLReportTemplateColumn.PeriodOption
            NewGLReportTemplateColumn.IsVisible = GLReportTemplateColumn.IsVisible
            NewGLReportTemplateColumn.Expression = GLReportTemplateColumn.Expression
            NewGLReportTemplateColumn.UnderlineColumnHeaders = GLReportTemplateColumn.UnderlineColumnHeaders
            NewGLReportTemplateColumn.UseCurrencyFormat = GLReportTemplateColumn.UseCurrencyFormat
            NewGLReportTemplateColumn.NumberOfDecimalPlaces = GLReportTemplateColumn.NumberOfDecimalPlaces
            NewGLReportTemplateColumn.Column1Name = GLReportTemplateColumn.Column1Name
            NewGLReportTemplateColumn.Column2Name = GLReportTemplateColumn.Column2Name
            NewGLReportTemplateColumn.PctOfRowColumnName = GLReportTemplateColumn.PctOfRowColumnName
            NewGLReportTemplateColumn.OfficeCode = GLReportTemplateColumn.OfficeCode
            NewGLReportTemplateColumn.OverrideDataOptions = GLReportTemplateColumn.OverrideDataOptions
            NewGLReportTemplateColumn.DataOption = GLReportTemplateColumn.DataOption
            NewGLReportTemplateColumn.DataCalculation = GLReportTemplateColumn.DataCalculation

            If AdvantageFramework.Database.Procedures.GLReportTemplateColumn.Insert(DbContext, NewGLReportTemplateColumn) Then

                For Each GLReportTemplatePctOfRowColumnRelation In GLReportTemplate.GLReportTemplatePctOfRowColumnRelations.Where(Function(Entity) Entity.GLReportTemplateColumnID = GLReportTemplateColumn.ID).ToList

                    NewGLReportTemplatePctOfRowColumnRelation = New AdvantageFramework.Database.Entities.GLReportTemplatePctOfRowColumnRelation

                    NewGLReportTemplatePctOfRowColumnRelation.GLReportTemplateID = GLReportTemplateID
                    NewGLReportTemplatePctOfRowColumnRelation.GLReportTemplateColumnID = NewGLReportTemplateColumn.ID
                    NewGLReportTemplatePctOfRowColumnRelation.RowIndex = GLReportTemplatePctOfRowColumnRelation.RowIndex
                    NewGLReportTemplatePctOfRowColumnRelation.PctOfRowIndex = GLReportTemplatePctOfRowColumnRelation.PctOfRowIndex

                    If AdvantageFramework.Database.Procedures.GLReportTemplatePctOfRowColumnRelation.Insert(DbContext, NewGLReportTemplatePctOfRowColumnRelation) = False Then

                        Copied = False
                        Exit For

                    End If

                Next

            Else

                Copied = False

            End If

            CopyGLReportTemplateColumn = Copied

        End Function
        Private Function CopyGLReportTemplateRow(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportTemplateID As Integer,
                                                 ByVal GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate,
                                                 ByVal GLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow) As Boolean

            'objects
            Dim Copied As Boolean = True
            Dim NewGLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow = Nothing
            Dim NewGLReportTemplateRowRelation As AdvantageFramework.Database.Entities.GLReportTemplateRowRelation = Nothing

            NewGLReportTemplateRow = New AdvantageFramework.Database.Entities.GLReportTemplateRow

            NewGLReportTemplateRow.GLReportTemplateID = GLReportTemplateID
            NewGLReportTemplateRow.Description = GLReportTemplateRow.Description
            NewGLReportTemplateRow.BalanceType = GLReportTemplateRow.BalanceType
            NewGLReportTemplateRow.DisplayType = GLReportTemplateRow.DisplayType
            NewGLReportTemplateRow.LinkType = GLReportTemplateRow.LinkType
            NewGLReportTemplateRow.AccountType = GLReportTemplateRow.AccountType
            NewGLReportTemplateRow.GLACode = GLReportTemplateRow.GLACode
            NewGLReportTemplateRow.GLACodeRangeStart = GLReportTemplateRow.GLACodeRangeStart
            NewGLReportTemplateRow.GLACodeRangeTo = GLReportTemplateRow.GLACodeRangeTo
            NewGLReportTemplateRow.Wildcard = GLReportTemplateRow.Wildcard
            NewGLReportTemplateRow.AccountGroupCode = GLReportTemplateRow.AccountGroupCode
            NewGLReportTemplateRow.RowIndex = GLReportTemplateRow.RowIndex
            NewGLReportTemplateRow.Type = GLReportTemplateRow.Type
            NewGLReportTemplateRow.TotalType = GLReportTemplateRow.TotalType
            NewGLReportTemplateRow.UseBaseAccountCodes = GLReportTemplateRow.UseBaseAccountCodes
            NewGLReportTemplateRow.IndentSpaces = GLReportTemplateRow.IndentSpaces
            NewGLReportTemplateRow.UnderlineAmount = GLReportTemplateRow.UnderlineAmount
            NewGLReportTemplateRow.DoubleUnderlineAmount = GLReportTemplateRow.DoubleUnderlineAmount
            NewGLReportTemplateRow.IsBold = GLReportTemplateRow.IsBold
            NewGLReportTemplateRow.UseCurrencyFormat = GLReportTemplateRow.UseCurrencyFormat
            NewGLReportTemplateRow.SuppressIfAllZeros = GLReportTemplateRow.SuppressIfAllZeros
            NewGLReportTemplateRow.NumberOfDecimalPlaces = GLReportTemplateRow.NumberOfDecimalPlaces
            NewGLReportTemplateRow.RollUp = GLReportTemplateRow.RollUp
            NewGLReportTemplateRow.DataOption = GLReportTemplateRow.DataOption
            NewGLReportTemplateRow.DataCalculation = GLReportTemplateRow.DataCalculation
			NewGLReportTemplateRow.IsVisible = GLReportTemplateRow.IsVisible

			If AdvantageFramework.Database.Procedures.GLReportTemplateRow.Insert(DbContext, NewGLReportTemplateRow) Then

                For Each GLReportTemplateRowRelation In GLReportTemplate.GLReportTemplateRowRelations.Where(Function(Entity) Entity.GLReportTemplateRowID = GLReportTemplateRow.ID).ToList

                    NewGLReportTemplateRowRelation = New AdvantageFramework.Database.Entities.GLReportTemplateRowRelation

                    NewGLReportTemplateRowRelation.GLReportTemplateID = GLReportTemplateID
                    NewGLReportTemplateRowRelation.GLReportTemplateRowID = NewGLReportTemplateRow.ID
                    NewGLReportTemplateRowRelation.RelatedRowIndex = GLReportTemplateRowRelation.RelatedRowIndex

                    If AdvantageFramework.Database.Procedures.GLReportTemplateRowRelation.Insert(DbContext, NewGLReportTemplateRowRelation) = False Then

                        Copied = False
                        Exit For

                    End If

                Next

            Else

                Copied = False

            End If

            CopyGLReportTemplateRow = Copied

        End Function
        Private Function ImportFromXML(ByVal XML As String, ByVal AFObjectType As System.Type, ParamArray ExtraTypes() As System.Type) As Object

            'objects
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim StringReader As System.IO.StringReader = Nothing
            Dim AFObject As Object = Nothing
            Dim XmlAttributeOverrides As System.Xml.Serialization.XmlAttributeOverrides = Nothing
            Dim XmlAttributes As System.Xml.Serialization.XmlAttributes = Nothing
            Dim XmlElementAttribute As System.Xml.Serialization.XmlElementAttribute = Nothing

            XmlAttributeOverrides = New System.Xml.Serialization.XmlAttributeOverrides

            For Each ExtraType In ExtraTypes

                XmlAttributes = New System.Xml.Serialization.XmlAttributes

                XmlElementAttribute = New System.Xml.Serialization.XmlElementAttribute

                XmlElementAttribute.ElementName = ExtraType.Name & "s"
                XmlElementAttribute.Type = ExtraType

                XmlAttributes.XmlElements.Add(XmlElementAttribute)

                XmlAttributeOverrides.Add(AFObjectType, XmlElementAttribute.ElementName, XmlAttributes)

            Next

            Try

                XmlSerializer = New System.Xml.Serialization.XmlSerializer(AFObjectType, XmlAttributeOverrides)
                StringReader = New System.IO.StringReader(XML)

                AFObject = XmlSerializer.Deserialize(StringReader)

            Catch ex As Exception
                AFObject = Nothing
            Finally
                ImportFromXML = AFObject
            End Try

        End Function

#End Region

    End Module

End Namespace

