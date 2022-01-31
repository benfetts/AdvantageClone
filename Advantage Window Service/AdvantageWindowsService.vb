Public Class AdvantageWindowsService

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Timer As System.Threading.Timer = Nothing
    Private _ServicesRunning As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Protected Overrides Sub OnStart(ByVal args() As String)

        'objects
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

        TimeSpan = TimeSpan.FromMinutes(1)

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

        AddHandler System.AppDomain.CurrentDomain.AssemblyResolve, AddressOf AssemblyResolve

    End Sub
    Protected Function AssemblyResolve(sender As Object, args As System.ResolveEventArgs) As System.Reflection.Assembly

        'objects
        Dim Assembly As System.Reflection.Assembly = Nothing
        Dim AssemblyFileName As String = String.Empty

        If args.Name.Contains("Newtonsoft.Json") Then

            AssemblyFileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) & "\\Newtonsoft.Json.dll"
            Assembly = System.Reflection.Assembly.LoadFrom(AssemblyFileName)

        End If

        AssemblyResolve = Assembly

    End Function
    Protected Overrides Sub OnStop()

        AdvantageFramework.Services.EmailListener.WriteToEventLog("Stopped")
        AdvantageFramework.Services.QvAAlert.WriteToEventLog("Stopped")
        AdvantageFramework.Services.MediaExport.WriteToEventLog("Stopped")
        AdvantageFramework.Services.Task.WriteToEventLog("Stopped")
        AdvantageFramework.Services.MissingTime.WriteToEventLog("Stopped")
        AdvantageFramework.Services.PaidTimeOffAccruals.WriteToEventLog("Stopped")
        AdvantageFramework.Services.Calendar.WriteToEventLog("Stopped")
        AdvantageFramework.Services.CoreMediaCheckExport.WriteToEventLog("Stopped")
        AdvantageFramework.Services.Contract.WriteToEventLog("Stopped")
        AdvantageFramework.Services.MediaOceanImport.WriteToEventLog("Stopped")
        AdvantageFramework.Services.CSIPreferredPartner.WriteToEventLog("Stopped")
        AdvantageFramework.Services.JobCompUDFImport.WriteToEventLog("Stopped")
        AdvantageFramework.Services.Imports.WriteToEventLog("Stopped")
        AdvantageFramework.Services.Exports.WriteToEventLog("Stopped")
        AdvantageFramework.Services.VendorContract.WriteToEventLog("Stopped")
        AdvantageFramework.Services.CurrencyExchange.WriteToEventLog("Stopped")
        AdvantageFramework.Services.VCC.WriteToEventLog("Stopped")
        AdvantageFramework.Services.Nielsen.WriteToEventLog("Stopped")
        AdvantageFramework.Services.CalendarTimeSheetImport.WriteToEventLog("Stopped")
        AdvantageFramework.Services.ScheduledReports.WriteToEventLog("Stopped")
        AdvantageFramework.Services.ComScore.WriteToEventLog("Stopped")
        AdvantageFramework.Services.InOutBoard.WriteToEventLog("Stopped")
        AdvantageFramework.Services.AutomatedAssignments.WriteToEventLog("Stopped")
        AdvantageFramework.Services.DocumentRepositoryCapacityWarning.WriteToEventLog("Stopped")
        AdvantageFramework.Services.NielsenPuertoRico.WriteToEventLog("Stopped")

    End Sub
    Private Sub TimerTick()

        If _ServicesRunning = False Then

            _ServicesRunning = True

            AdvantageFramework.Services.Run()

            _ServicesRunning = False

        End If

    End Sub

#End Region

End Class
