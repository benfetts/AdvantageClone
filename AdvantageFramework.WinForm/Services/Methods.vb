Namespace Services

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _AdvantageServices As Hashtable = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Async Sub Run()

            Dim DatabaseProfiles As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing
            Dim Task As System.Threading.Tasks.Task = Nothing
            Dim ServiceDatabaseProfile As Hashtable = Nothing

            DatabaseProfiles = AdvantageFramework.Services.LoadDatabaseProfiles

            'If _AdvantageServices Is Nothing Then

            '    _AdvantageServices = New Hashtable

            '    ServiceDatabaseProfile = New Hashtable

            '    For Each DatabaseProfile In DatabaseProfiles

            '        ServiceDatabaseProfile.Add(DatabaseProfile.ToString, False)

            '    Next

            '    For Each AdvantageService In AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.Services.Service), False)

            '        _AdvantageServices(AdvantageService) = ServiceDatabaseProfile.Clone

            '    Next

            'Else

            '    For Each AdvantageService In _AdvantageServices.Keys

            '        For Each DatabaseProfile In DatabaseProfiles

            '            If CType(_AdvantageServices(AdvantageService), Hashtable).Contains(DatabaseProfile.ToString) = False Then

            '                CType(_AdvantageServices(AdvantageService), Hashtable).Add(DatabaseProfile.ToString, False)

            '            End If

            '        Next

            '    Next

            'End If

            'Await System.Threading.Tasks.Task.WhenAll(DatabaseProfiles.Select(Async Function(DatabaseProfile)

            '                                                                      Await AdvantageFramework.Services.EmailListener.Run(DatabaseProfile)

            '              

            'Await System.Threading.Tasks.Task.Run(Sub()

            System.Threading.Tasks.Parallel.ForEach(DatabaseProfiles, Sub(DatabaseProfile As Database.DatabaseProfile)

                                                                          AdvantageFramework.Services.EmailListener.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.QvAAlert.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.MediaExport.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.Task.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.MissingTime.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.PaidTimeOffAccruals.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.Calendar.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.CoreMediaCheckExport.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.Contract.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.MediaOceanImport.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.CSIPreferredPartner.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.JobCompUDFImport.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.Imports.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.Exports.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.VendorContract.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.CurrencyExchange.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.VCC.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.Nielsen.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.CalendarTimeSheetImport.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.ScheduledReports.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.ComScore.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.InOutBoard.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.AutomatedAssignments.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.DocumentRepositoryCapacityWarning.Run(DatabaseProfile)

                                                                          AdvantageFramework.Services.NielsenPuertoRico.Run(DatabaseProfile)

                                                                      End Sub)

            'End Sub)

            'For Each DatabaseProfile In DatabaseProfiles

            '    For Each AdvantageService In _AdvantageServices.Keys

            '        If AdvantageService = AdvantageFramework.Services.Service.AdvantageWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.EmailListener.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.QvAAlert.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageExportWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageExportWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageExportWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.MediaExport.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageExportWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageTaskWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageTaskWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageTaskWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.Task.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageTaskWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.MissingTime.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageCalendarWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCalendarWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCalendarWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.Calendar.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCalendarWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.CoreMediaCheckExport.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantagePaidTimeOffAccrualsWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantagePaidTimeOffAccrualsWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantagePaidTimeOffAccrualsWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.PaidTimeOffAccruals.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantagePaidTimeOffAccrualsWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageContractWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageContractWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageContractWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.Contract.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageContractWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.MediaOceanImport.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageCSIPreferredPartnerWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCSIPreferredPartnerWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCSIPreferredPartnerWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.CSIPreferredPartner.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCSIPreferredPartnerWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageJobCompUDFImportWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageJobCompUDFImportWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageJobCompUDFImportWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.JobCompUDFImport.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageJobCompUDFImportWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageImportTemplateWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageImportTemplateWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageImportTemplateWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.Imports.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageImportTemplateWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageExportTemplateWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageExportTemplateWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageExportTemplateWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.Exports.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageExportTemplateWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageVendorContractWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageVendorContractWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageVendorContractWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.VendorContract.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageVendorContractWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageCurrencyExchangeWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCurrencyExchangeWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCurrencyExchangeWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.CurrencyExchange.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCurrencyExchangeWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageVCCWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageVCCWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageVCCWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.VCC.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageVCCWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageNielsenWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageNielsenWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageNielsenWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.Nielsen.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageNielsenWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageCalendarTimeSheetImportService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCalendarTimeSheetImportService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCalendarTimeSheetImportService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.CalendarTimeSheetImport.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageCalendarTimeSheetImportService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageScheduledReportsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageScheduledReportsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageScheduledReportsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.ScheduledReports.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageScheduledReportsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageComScoreWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageComScoreWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageComScoreWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.ComScore.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageComScoreWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageInOutWindowService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageInOutWindowService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageInOutWindowService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.InOutBoard.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageInOutWindowService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageAutomatedAssignmentsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageAutomatedAssignmentsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageAutomatedAssignmentsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.AutomatedAssignments.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageAutomatedAssignmentsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        ElseIf AdvantageService = AdvantageFramework.Services.Service.AdvantageDocumentRepositoryCapacityWarningWindowsService.ToString Then

            '            If CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageDocumentRepositoryCapacityWarningWindowsService.ToString), Hashtable)(DatabaseProfile.ToString) = False Then

            '                System.Threading.Tasks.Task.Factory.StartNew(Sub(DBProfile As Database.DatabaseProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageDocumentRepositoryCapacityWarningWindowsService.ToString), Hashtable)(DBProfile.ToString) = True

            '                                                                 AdvantageFramework.Services.DocumentRepositoryCapacityWarning.Run(DBProfile)

            '                                                                 CType(_AdvantageServices(AdvantageFramework.Services.Service.AdvantageDocumentRepositoryCapacityWarningWindowsService.ToString), Hashtable)(DBProfile.ToString) = False

            '                                                             End Sub, DatabaseProfile)

            '            End If

            '        End If

            '    Next

            'Next

        End Sub

#End Region

    End Module

End Namespace

