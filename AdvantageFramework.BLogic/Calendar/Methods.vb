Namespace Calendar

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ReminderOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "0 Minutes")>
            [Minutes0]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "5 Minutes")>
            [Minutes5]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "10 Minutes")>
            [Minutes10]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("15", "15 Minutes")>
            [Minutes15]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("30", "30 Minutes")>
            [Minutes30]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("60", "1 Hour")>
            [Hours1]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("300", "5 Hours")>
            [Hours5]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("600", "10 Hours")>
            [Hours10]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1440", "1 Day")>
            [Days1]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2880", "2 Days")>
            [Days2]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4320", "3 Days")>
            [Days3]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5760", "4 Days")>
            [Days4]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10080", "1 Week")>
            [Weeks1]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("20160", "2 Weeks")>
            [Weeks2]
        End Enum

        Public Enum ActivityTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("C", "Call")>
            [Call]
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Meeting")>
            Meeting
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TD", "To Do")>
            ToDo
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("EL", "Email")>
            Email
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("H", "Holiday")>
            Holiday
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("A", "Appointment (Personal)")>
            Appointment
        End Enum

        Public Enum CalendarTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Google")>
            Google
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Outlook.com")>
            Outlook365
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Internal")>
            Outlook
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Sync(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeNonTaskID As Integer, ByVal IsHoliday As Boolean, ByVal IsDeleting As Boolean, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False
            Dim SyncWithOutlook As Boolean = False
            Dim UseOutlookExchangeServer As Boolean = False
            Dim SyncWithGoogleCalendar As Boolean = False
            Dim SyncWithSugarCRM As Boolean = False

            Try

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                        SyncWithOutlook = AdvantageFramework.Calendar.Outlook.IsSyncWithOutlookEnabled(DataContext)

                    End Using

                Catch ex As Exception
                    SyncWithOutlook = False
                Finally

                    If SyncWithOutlook Then

                        Try

                            Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                                UseOutlookExchangeServer = AdvantageFramework.Calendar.Outlook.OutlookExchangeServerEnabled(DataContext)

                            End Using

                        Catch ex As Exception
                            UseOutlookExchangeServer = False
                        End Try

                        If UseOutlookExchangeServer Then

                            Syncd = AdvantageFramework.Calendar.Outlook.SyncEmployeeNonTaskExchangeServer(ConnectionString, UserCode, EmployeeNonTaskID, IsDeleting)

                        Else

                            Syncd = AdvantageFramework.Calendar.Outlook.SyncEmployeeNonTask(ConnectionString, UserCode, EmployeeNonTaskID, IsDeleting)

                        End If

                    End If

                End Try

                If IsHoliday = False Then

                    Try

                        Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                            SyncWithGoogleCalendar = AdvantageFramework.Calendar.GoogleCal.IsSyncWithGoogleCalendarEnabled(DataContext)

                        End Using

                    Catch ex As Exception
                        SyncWithGoogleCalendar = False
                    Finally

                        If SyncWithGoogleCalendar Then

                            Syncd = AdvantageFramework.Calendar.GoogleCal.SyncEmployeeNonTask(ConnectionString, UserCode, EmployeeNonTaskID, IsDeleting, IsWebvantage, UseWindowsAuthentication)

                        End If

                    End Try

                    Try

                        Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                            SyncWithSugarCRM = AdvantageFramework.Calendar.SugarCRM.IsSyncWithSugarCRMEnabled(DataContext)

                        End Using

                    Catch ex As Exception
                        SyncWithSugarCRM = False
                    Finally

                        If SyncWithSugarCRM Then

                            Syncd = AdvantageFramework.Calendar.SugarCRM.SyncEmployeeNonTask(ConnectionString, UserCode, EmployeeNonTaskID, IsDeleting)

                        End If

                    End Try

                End If

            Catch ex As Exception
                Syncd = False
            Finally
                Sync = Syncd
            End Try

        End Function
        Public Function Sync(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask, ByVal IsHoliday As Boolean, ByVal IsDeleting As Boolean, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False
            Dim SyncWithOutlook As Boolean = False
            Dim UseOutlookExchangeServer As Boolean = False
            Dim SyncWithGoogleCalendar As Boolean = False
            Dim SyncWithSugarCRM As Boolean = False

            Try

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                        SyncWithOutlook = AdvantageFramework.Calendar.Outlook.IsSyncWithOutlookEnabled(DataContext)

                    End Using

                Catch ex As Exception
                    SyncWithOutlook = False
                Finally

                    If SyncWithOutlook Then

                        Try

                            Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                                UseOutlookExchangeServer = AdvantageFramework.Calendar.Outlook.OutlookExchangeServerEnabled(DataContext)

                            End Using

                        Catch ex As Exception
                            UseOutlookExchangeServer = False
                        End Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                                If UseOutlookExchangeServer Then

                                    Syncd = AdvantageFramework.Calendar.Outlook.SyncEmployeeNonTaskExchangeServer(DbContext, SecurityDbContext, UserCode, EmployeeNonTask, IsDeleting)

                                Else

                                    Syncd = AdvantageFramework.Calendar.Outlook.SyncEmployeeNonTask(DbContext, SecurityDbContext, UserCode, EmployeeNonTask, IsDeleting)

                                End If

                            End Using

                        End Using

                    End If

                End Try

                If IsHoliday = False Then

                    Try

                        Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                            SyncWithGoogleCalendar = AdvantageFramework.Calendar.GoogleCal.IsSyncWithGoogleCalendarEnabled(DataContext)

                        End Using

                    Catch ex As Exception
                        SyncWithGoogleCalendar = False
                    Finally

                        If SyncWithGoogleCalendar Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                                    Syncd = AdvantageFramework.Calendar.GoogleCal.SyncEmployeeNonTask(DbContext, SecurityDbContext, UserCode, EmployeeNonTask, IsDeleting, IsWebvantage, UseWindowsAuthentication)

                                End Using

                            End Using

                        End If

                    End Try

                    Try

                        Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                            SyncWithSugarCRM = AdvantageFramework.Calendar.SugarCRM.IsSyncWithSugarCRMEnabled(DataContext)

                        End Using

                    Catch ex As Exception
                        SyncWithSugarCRM = False
                    Finally

                        If SyncWithSugarCRM Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                                Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                                    Syncd = AdvantageFramework.Calendar.SugarCRM.SyncEmployeeNonTask(DbContext, DataContext, UserCode, EmployeeNonTask, IsDeleting)

                                End Using

                            End Using

                        End If

                    End Try

                End If

            Catch ex As Exception
                Syncd = False
            Finally
                Sync = Syncd
            End Try

        End Function
        Public Sub GetDefaultStartAndEndTimes(ByRef StartDate As Date, ByRef EndDate As Date)


            StartDate = Now
            EndDate = Convert.ToDateTime("07:00:00 AM")

            If Now < Convert.ToDateTime("07:00:00 AM") Then

                StartDate = CDate(Now.ToShortDateString & " 07:00:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 07:30:00 AM")

            End If

            If Now >= Convert.ToDateTime("07:00:00 AM") And Now < Convert.ToDateTime("07:30:00 AM") Then

                StartDate = CDate(Now.ToShortDateString & " 07:00:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 07:30:00 AM")

            End If

            If Now >= Convert.ToDateTime("07:30:00 AM") And Now < Convert.ToDateTime("08:00:00 AM") Then

                StartDate = CDate(Now.ToShortDateString & " 07:30:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 08:00:00 AM")

            End If

            If Now >= Convert.ToDateTime("08:00:00 AM") And Now < Convert.ToDateTime("08:30:00 AM") Then

                StartDate = CDate(Now.ToShortDateString & " 08:00:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 08:30:00 AM")

            End If

            If Now >= Convert.ToDateTime("08:30:00 AM") And Now < Convert.ToDateTime("09:00:00 AM") Then

                StartDate = CDate(Now.ToShortDateString & " 08:30:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 09:00:00 AM")

            End If

            If Now >= Convert.ToDateTime("09:00:00 AM") And Now < Convert.ToDateTime("09:30:00 AM") Then

                StartDate = CDate(Now.ToShortDateString & " 09:00:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 09:30:00 AM")

            End If

            If Now >= Convert.ToDateTime("09:30:00 AM") And Now < Convert.ToDateTime("10:00:00 AM") Then

                StartDate = CDate(Now.ToShortDateString & " 09:30:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 10:00:00 AM")

            End If

            If Now >= Convert.ToDateTime("10:00:00 AM") And Now < Convert.ToDateTime("10:30:00 AM") Then

                StartDate = CDate(Now.ToShortDateString & " 10:00:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 10:30:00 AM")

            End If

            If Now >= Convert.ToDateTime("10:30:00 AM") And Now < Convert.ToDateTime("11:00:00 AM") Then

                StartDate = CDate(Now.ToShortDateString & " 10:30:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 11:00:00 AM")

            End If

            If Now >= Convert.ToDateTime("11:00:00 AM") And Now < Convert.ToDateTime("11:30:00 AM") Then

                StartDate = CDate(Now.ToShortDateString & " 11:00:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 11:30:00 AM")

            End If

            If Now >= Convert.ToDateTime("11:30:00 AM") And Now < Convert.ToDateTime("12:00:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 11:30:00 AM")
                EndDate = CDate(Now.ToShortDateString & " 12:00:00 PM")

            End If

            If Now >= Convert.ToDateTime("12:00:00 PM") And Now < Convert.ToDateTime("12:30:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 12:00:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 12:30:00 PM")

            End If

            If Now >= Convert.ToDateTime("12:30:00 PM") And Now < Convert.ToDateTime("01:00:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 12:30:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 01:00:00 PM")

            End If

            If Now >= Convert.ToDateTime("01:00:00 PM") And Now < Convert.ToDateTime("01:30:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 01:00:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 01:30:00 PM")

            End If

            If Now >= Convert.ToDateTime("01:30:00 PM") And Now < Convert.ToDateTime("02:00:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 01:30:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 02:00:00 PM")

            End If

            If Now >= Convert.ToDateTime("02:00:00 PM") And Now < Convert.ToDateTime("02:30:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 02:00:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 02:30:00 PM")

            End If

            If Now >= Convert.ToDateTime("02:30:00 PM") And Now < Convert.ToDateTime("03:00:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 02:30:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 03:00:00 PM")

            End If

            If Now >= Convert.ToDateTime("03:00:00 PM") And Now < Convert.ToDateTime("03:30:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 03:00:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 03:30:00 PM")

            End If

            If Now >= Convert.ToDateTime("03:30:00 PM") And Now < Convert.ToDateTime("04:00:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 03:30:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 04:00:00 PM")

            End If

            If Now >= Convert.ToDateTime("04:00:00 PM") And Now < Convert.ToDateTime("04:30:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 04:00:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 04:30:00 PM")

            End If

            If Now >= Convert.ToDateTime("04:30:00 PM") And Now < Convert.ToDateTime("05:00:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 04:30:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 05:00:00 PM")

            End If

            If Now >= Convert.ToDateTime("05:00:00 PM") And Now < Convert.ToDateTime("05:30:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 05:00:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 05:30:00 PM")

            End If

            If Now >= Convert.ToDateTime("05:30:00 PM") And Now < Convert.ToDateTime("06:00:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 05:30:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 06:00:00 PM")

            End If

            If Now >= Convert.ToDateTime("06:00:00 PM") And Now < Convert.ToDateTime("06:30:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 06:00:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 06:30:00 PM")

            End If

            If Now >= Convert.ToDateTime("06:30:00 PM") Then

                StartDate = CDate(Now.ToShortDateString & " 06:30:00 PM")
                EndDate = CDate(Now.ToShortDateString & " 06:30:00 PM")

            End If

        End Sub

#End Region

    End Module

End Namespace
