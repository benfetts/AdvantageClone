Public Class NielsenWindowsService

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Timer As System.Threading.Timer = Nothing
    Private _TV_Spot_Path As String = Nothing
    Private _TV_National_Path As String = Nothing
    Private _Radio_Spot_Path As String = Nothing
    'Private _NDS_Client_Bin_Path As String = Nothing
    Private _SQL_Connection_String As String = Nothing
    'Private _PFX_Path As String = Nothing
    Private _TIMER_MINUTES As String = Nothing
    Private _NCC_DATA_PATH As String = Nothing
    Private _Eastlan_Path As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Protected Overrides Sub OnStart(ByVal args() As String)

        'objects
        Dim TimeSpan As TimeSpan = Nothing

        TimeSpan = TimeSpan.FromMinutes(1)

        _TV_Spot_Path = My.Settings.Item("TV_SPOT_PATH")
        _TV_National_Path = My.Settings.Item("TV_NATIONAL_PATH")
        _Radio_Spot_Path = My.Settings.Item("RADIO_SPOT_PATH")
        '_NDS_Client_Bin_Path = My.Settings.Item("NDS_CLIENT_BIN_PATH")
        _SQL_Connection_String = My.Settings.Item("SQL_CONNECTION")
        '_PFX_Path = My.Settings.Item("PFX_PATH")
        _TIMER_MINUTES = My.Settings.Item("TIMER_MINUTES")
        _NCC_DATA_PATH = My.Settings.Item("NCC_DATA_PATH")
        _Eastlan_Path = My.Settings.Item("EASTLAN_PATH")

        'Not System.IO.Directory.Exists(_NDS_Client_Bin_Path) OrElse Not System.IO.Directory.Exists(_PFX_Path) 
        If Not System.IO.Directory.Exists(_TV_Spot_Path) OrElse Not System.IO.Directory.Exists(_TV_National_Path) OrElse Not System.IO.Directory.Exists(_Radio_Spot_Path) OrElse
                Not System.IO.Directory.Exists(_NCC_DATA_PATH) Then

            Throw New Exception("One or more of the configured directories could not be found!")

        ElseIf Not IsNumeric(_TIMER_MINUTES) OrElse _TIMER_MINUTES <= 0 Then

            Throw New Exception("TIMER_MINUTES parameter must be numeric and greater than zero!")

        ElseIf NielsenFramework.Service.CanSqlConnect(_SQL_Connection_String) Then

            NielsenFramework.Service.Start(_SQL_Connection_String)
            NielsenFramework.Service.LogEvent(_SQL_Connection_String, "Started")

            NielsenFramework.Service.SaveSettings(_SQL_Connection_String, _TV_Spot_Path, _TV_National_Path, _Radio_Spot_Path, _TIMER_MINUTES, _NCC_DATA_PATH)

            _Timer = New System.Threading.Timer(New System.Threading.TimerCallback(AddressOf TimerTick), Nothing, CLng(TimeSpan.TotalMilliseconds), CLng(_TIMER_MINUTES * 60 * 1000))

        End If

    End Sub
    Protected Overrides Sub OnStop()

        NielsenFramework.Service.LogEvent(_SQL_Connection_String, "Stopped")

    End Sub
    Private Sub TimerTick()

        NielsenFramework.Service.SyncFilesFromNielsen(_TV_Spot_Path, _TV_National_Path, _Radio_Spot_Path, _SQL_Connection_String, _NCC_DATA_PATH, _Eastlan_Path)

    End Sub

#End Region

End Class
