Module Timer

#Region " Constants "



#End Region

#Region " Enums "



#End Region

#Region " Variables "

    Private _Timer As System.Threading.Timer = Nothing
    Private _ServicesRunning As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Sub Main(args() As String)

        Dim TimeSpan As TimeSpan = Nothing

        AdvantageFramework.Services.EmailListener.LoadLog(False)
        AdvantageFramework.Services.QvAAlert.LoadLog(False)
        AdvantageFramework.Services.MediaExport.LoadLog(False)
        AdvantageFramework.Services.Task.LoadLog(False)
        AdvantageFramework.Services.MissingTime.LoadLog(False)
        AdvantageFramework.Services.PaidTimeOffAccruals.LoadLog(False)
        AdvantageFramework.Services.Calendar.LoadLog(False)
        AdvantageFramework.Services.CoreMediaCheckExport.LoadLog(False)
        AdvantageFramework.Services.Contract.LoadLog(False)
        AdvantageFramework.Services.MediaOceanImport.LoadLog(False)
        AdvantageFramework.Services.CSIPreferredPartner.LoadLog(False)
        AdvantageFramework.Services.JobCompUDFImport.LoadLog(False)
        AdvantageFramework.Services.Imports.LoadLog(False)
        AdvantageFramework.Services.Exports.LoadLog(False)
        AdvantageFramework.Services.VendorContract.LoadLog(False)
        AdvantageFramework.Services.CurrencyExchange.LoadLog(False)
        AdvantageFramework.Services.VCC.LoadLog(False)
        AdvantageFramework.Services.Nielsen.LoadLog(False)
        AdvantageFramework.Services.CalendarTimeSheetImport.LoadLog(False)
        AdvantageFramework.Services.ScheduledReports.LoadLog(False)
        AdvantageFramework.Services.ComScore.LoadLog(False)
        AdvantageFramework.Services.InOutBoard.LoadLog(False)
        AdvantageFramework.Services.AutomatedAssignments.LoadLog(False)
        AdvantageFramework.Services.DocumentRepositoryCapacityWarning.LoadLog(False)
        AdvantageFramework.Services.NielsenPuertoRico.LoadLog(False)

        TimeSpan = TimeSpan.FromSeconds(60)

        _Timer = New System.Threading.Timer(New System.Threading.TimerCallback(AddressOf TimerTick), Nothing, CInt(TimeSpan.TotalMilliseconds), CInt(TimeSpan.TotalMilliseconds))

        AdvantageFramework.Services.EmailListener.WriteToEventLog("Started")
        AdvantageFramework.Services.QvAAlert.WriteToEventLog("Started")
        AdvantageFramework.Services.MediaExport.WriteToEventLog("Started")
        AdvantageFramework.Services.Task.WriteToEventLog("Started")
        AdvantageFramework.Services.MissingTime.WriteToEventLog("Started")
        AdvantageFramework.Services.PaidTimeOffAccruals.WriteToEventLog("Started")
        AdvantageFramework.Services.Calendar.WriteToEventLog("Started")
        AdvantageFramework.Services.CoreMediaCheckExport.WriteToEventLog("Started")
        AdvantageFramework.Services.Contract.WriteToEventLog("Started")
        AdvantageFramework.Services.MediaOceanImport.WriteToEventLog("Started")
        AdvantageFramework.Services.CSIPreferredPartner.WriteToEventLog("Started")
        AdvantageFramework.Services.JobCompUDFImport.WriteToEventLog("Started")
        AdvantageFramework.Services.Imports.WriteToEventLog("Started")
        AdvantageFramework.Services.Exports.WriteToEventLog("Started")
        AdvantageFramework.Services.VendorContract.WriteToEventLog("Started")
        AdvantageFramework.Services.CurrencyExchange.WriteToEventLog("Started")
        AdvantageFramework.Services.VCC.WriteToEventLog("Started")
        AdvantageFramework.Services.Nielsen.WriteToEventLog("Started")
        AdvantageFramework.Services.CalendarTimeSheetImport.WriteToEventLog("Started")
        AdvantageFramework.Services.ScheduledReports.WriteToEventLog("Started")
        AdvantageFramework.Services.ComScore.WriteToEventLog("Started")
        AdvantageFramework.Services.InOutBoard.WriteToEventLog("Started")
        AdvantageFramework.Services.AutomatedAssignments.WriteToEventLog("Started")
        AdvantageFramework.Services.DocumentRepositoryCapacityWarning.WriteToEventLog("Started")
        AdvantageFramework.Services.NielsenPuertoRico.WriteToEventLog("Started")

        Console.ReadKey()

    End Sub
    Private Sub TimerTick()

        If _ServicesRunning = False Then

            _ServicesRunning = True

            AdvantageFramework.Services.Run()

            _ServicesRunning = False

        End If

    End Sub

#End Region

End Module

