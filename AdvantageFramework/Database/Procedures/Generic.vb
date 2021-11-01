Namespace Database.Procedures.Generic

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        'Not sure storing in DB is needed for all 3 levels....
        Public Function LoadEmployeeCultureCode(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EmployeeCode As String) As String

            Dim CultureCode As String = "en-US"

            Try

                CultureCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(CULTURE_CODE, 'en-US') FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '{0}';", EmployeeCode)).SingleOrDefault

            Catch ex As Exception
                CultureCode = "en-US"
            End Try

            LoadEmployeeCultureCode = CultureCode

        End Function
        Public Function LoadAgencyCultureCode(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext) As String

            Dim CultureCode As String = "en-US"

            Try

                CultureCode = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(CULTURE_CODE, 'en-US') FROM AGENCY WITH(NOLOCK);").SingleOrDefault

            Catch ex As Exception
                CultureCode = "en-US"
            End Try

            LoadAgencyCultureCode = CultureCode

        End Function
        Public Function LoadDatabaseCultureCode(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext) As String

            Dim CultureCode As String = "en-US"

            Try

                CultureCode = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(DB_CULTURE_CODE, 'en-US') FROM AGENCY WITH(NOLOCK);").SingleOrDefault

            Catch ex As Exception
                CultureCode = "en-US"
            End Try

            LoadDatabaseCultureCode = CultureCode

        End Function
        Public Function SaveEmployeeCultureCode(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal CultureCode As String, ByVal EmployeeCode As String) As Boolean

            Try

                If String.IsNullOrWhiteSpace(CultureCode) = True Then CultureCode = "en-US"

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE EMPLOYEE SET CULTURE_CODE = '{0}' WHERE EMP_CODE = '{1}';", CultureCode, EmployeeCode))
                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function SaveAgencyCultureCode(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal CultureCode As String) As Boolean

            Try

                If String.IsNullOrWhiteSpace(CultureCode) = True Then CultureCode = "en-US"

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE AGENCY SET CULTURE_CODE = '{0}';", CultureCode))
                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function SaveDatabaseCultureCode(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal CultureCode As String) As Boolean

            Try

                If String.IsNullOrWhiteSpace(CultureCode) = True Then CultureCode = "en-US"

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE AGENCY SET DB_CULTURE_CODE = '{0}';", CultureCode))
                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function

        Public Function GetOffsetDateTime(Offset As Decimal, [Date] As Nullable(Of Date)) As Nullable(Of Date)

            'objects
            Dim OffsetDateTime As Nullable(Of Date) = Nothing

            If [Date].HasValue AndAlso Offset <> 0 Then

                OffsetDateTime = GetOffsetDateTime(Offset, [Date].Value)

            Else

                OffsetDateTime = [Date]

            End If

            GetOffsetDateTime = OffsetDateTime

        End Function
        Public Function GetOffsetDateTime(Offset As Decimal, [Date] As Date) As Date

            'objects
            Dim OffsetDateTime As Date = Date.MinValue

            If Offset <> 0 Then

                OffsetDateTime = DateAdd(DateInterval.Minute, (CType(Offset, Integer) * 60) + ((Offset - CType(Offset, Integer)) * 60), [Date])

            Else

                OffsetDateTime = [Date]

            End If

            GetOffsetDateTime = OffsetDateTime

        End Function
        Public Function LoadDatabaseTimeMilliseconds(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext) As String

            Dim DateString As String = Nothing

            LoadDatabaseTimeMilliseconds = DbContext.Database.SqlQuery(Of DateTime)("SELECT GETDATE()", "").SingleOrDefault.ToString("yyyy-MM-dd HH:mm:ss:fff")

        End Function
        Public Function LoadDatabaseTime(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext) As DateTime

            LoadDatabaseTime = DbContext.Database.SqlQuery(Of DateTime)("SELECT GETDATE()", "").SingleOrDefault

        End Function
        Public Function LoadDatabaseTime(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext) As DateTime

            LoadDatabaseTime = DataContext.ExecuteQuery(Of DateTime)("SELECT GETDATE()", "").SingleOrDefault

        End Function

        Public Function GetTimezoneOffset(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.VCC.Classes.TimezoneOffset

            Dim TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing

            TimezoneOffset = New AdvantageFramework.VCC.Classes.TimezoneOffset

            TimezoneOffset.AgencyOffset = AdvantageFramework.Database.Procedures.Generic.LoadAgencyHoursOffset(DbContext)
            TimezoneOffset.DatabaseOffset = AdvantageFramework.Database.Procedures.Generic.LoadSQLHoursOffset(DbContext)

            GetTimezoneOffset = TimezoneOffset

        End Function

        Public Function TimeZoneTodayForEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As DateTime

            Dim Offset As Decimal = CType(0.0, Decimal)

            Offset = LoadTimeZoneOffsetForEmployee(DbContext, EmployeeCode)

            If Offset <> 0 Then

                Return DateAdd(DateInterval.Hour, Offset, CType(Now, DateTime))

            Else

                Return CType(Now, DateTime)

            End If

        End Function
        Public Function TimeZoneTodayForClientPortalUser(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalUserID As Integer) As DateTime

            Dim Offset As Decimal = CType(0.0, Decimal)

            Offset = LoadTimeZoneOffsetForClientPortalUser(DbContext, ClientPortalUserID)

            If Offset <> 0 Then

                Return DateAdd(DateInterval.Hour, Offset, CType(Now, DateTime))

            Else

                Return Now.Date

            End If

        End Function

        Public Function LoadTimeZoneIDForEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As String

            Dim TimeZoneID As String = String.Empty
            Dim DatabaseTimeZoneID As String = String.Empty
            Dim AgencyTimeZoneID As String = String.Empty
            Dim EmployeeTimeZoneID As String = String.Empty

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DbContext)

            If String.IsNullOrWhiteSpace(DatabaseTimeZoneID) = False Then

                TimeZoneID = DatabaseTimeZoneID
                AgencyTimeZoneID = LoadAgencyTimeZoneID(DbContext)
                EmployeeTimeZoneID = LoadEmployeeTimeZoneID(DbContext, EmployeeCode)

                If String.IsNullOrWhiteSpace(AgencyTimeZoneID) = False Then

                    TimeZoneID = AgencyTimeZoneID

                End If
                If String.IsNullOrWhiteSpace(EmployeeTimeZoneID) = False Then

                    TimeZoneID = EmployeeTimeZoneID

                End If

            End If

            LoadTimeZoneIDForEmployee = TimeZoneID

        End Function
        Public Function LoadTimeZoneIDForEmployee(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeCode As String) As String

            Dim TimeZoneID As String = String.Empty
            Dim DatabaseTimeZoneID As String = String.Empty
            Dim AgencyTimeZoneID As String = String.Empty
            Dim EmployeeTimeZoneID As String = String.Empty

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DataContext)

            If String.IsNullOrWhiteSpace(DatabaseTimeZoneID) = False Then

                TimeZoneID = DatabaseTimeZoneID
                AgencyTimeZoneID = LoadAgencyTimeZoneID(DataContext)
                EmployeeTimeZoneID = LoadEmployeeTimeZoneID(DataContext, EmployeeCode)

                If String.IsNullOrWhiteSpace(AgencyTimeZoneID) = False Then

                    TimeZoneID = AgencyTimeZoneID

                End If
                If String.IsNullOrWhiteSpace(EmployeeTimeZoneID) = False Then

                    TimeZoneID = EmployeeTimeZoneID

                End If

            End If

            LoadTimeZoneIDForEmployee = TimeZoneID

        End Function

        Public Function LoadTimeZoneIDForClientPortalUser(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalUserID As Integer) As String

            Dim TimeZoneID As String = String.Empty
            Dim DatabaseTimeZoneID As String = String.Empty
            Dim AgencyTimeZoneID As String = String.Empty
            Dim ClientPortalUserTimeZoneID As String = String.Empty

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DbContext)

            If String.IsNullOrWhiteSpace(DatabaseTimeZoneID) = False Then

                TimeZoneID = DatabaseTimeZoneID
                AgencyTimeZoneID = LoadAgencyTimeZoneID(DbContext)
                ClientPortalUserTimeZoneID = LoadClientPortalUserTimeZoneID(DbContext, ClientPortalUserID)

                If String.IsNullOrWhiteSpace(AgencyTimeZoneID) = False Then

                    TimeZoneID = AgencyTimeZoneID

                End If
                If String.IsNullOrWhiteSpace(ClientPortalUserTimeZoneID) = False Then

                    TimeZoneID = ClientPortalUserTimeZoneID

                End If

            End If

            LoadTimeZoneIDForClientPortalUser = TimeZoneID

        End Function
        Public Function LoadTimeZoneIDForClientPortalUser(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientPortalUserID As Integer) As String

            Dim TimeZoneID As String = String.Empty
            Dim DatabaseTimeZoneID As String = String.Empty
            Dim AgencyTimeZoneID As String = String.Empty
            Dim ClientPortalUserTimeZoneID As String = String.Empty

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DataContext)

            If String.IsNullOrWhiteSpace(DatabaseTimeZoneID) = False Then

                TimeZoneID = DatabaseTimeZoneID
                AgencyTimeZoneID = LoadAgencyTimeZoneID(DataContext)
                ClientPortalUserTimeZoneID = LoadClientPortalUserTimeZoneID(DataContext, ClientPortalUserID)

                If String.IsNullOrWhiteSpace(AgencyTimeZoneID) = False Then

                    TimeZoneID = AgencyTimeZoneID

                End If
                If String.IsNullOrWhiteSpace(ClientPortalUserTimeZoneID) = False Then

                    TimeZoneID = ClientPortalUserTimeZoneID

                End If

            End If

            LoadTimeZoneIDForClientPortalUser = TimeZoneID

        End Function

        Public Function LoadTimeZoneOffsetForEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As Decimal

            Dim Offset As Decimal = CType(0.0, Decimal)
            Dim DatabaseOffset As Decimal = CType(0.0, Decimal)
            Dim AgencyOffset As Decimal = CType(0.0, Decimal)
            Dim EmployeeOffset As Decimal = CType(0.0, Decimal)

            Try

                DatabaseOffset = LoadSQLHoursOffset(DbContext)

            Catch ex As Exception
                DatabaseOffset = 0
            End Try

            If DatabaseOffset <> 0 Then 'if not using UTC zero then must have a database setting to act as anchor for the offset!

                Try

                    AgencyOffset = LoadAgencyHoursOffset(DbContext)

                Catch ex As Exception
                    AgencyOffset = 0.0
                End Try
                Try

                    If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                        EmployeeOffset = LoadEmployeeHoursOffset(DbContext, EmployeeCode)

                    End If

                Catch ex As Exception
                    EmployeeOffset = 0.0
                End Try
                If EmployeeOffset = 0 Then

                    Offset = AgencyOffset - DatabaseOffset

                Else

                    Offset = EmployeeOffset - DatabaseOffset

                End If

            End If

            LoadTimeZoneOffsetForEmployee = Offset

        End Function
        Public Function LoadTimeZoneOffsetForEmployeeForceUtcZero(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As Decimal

            Dim Offset As Decimal = CType(0.0, Decimal)
            Dim DatabaseOffset As Decimal = CType(0.0, Decimal)
            Dim AgencyOffset As Decimal = CType(0.0, Decimal)
            Dim EmployeeOffset As Decimal = CType(0.0, Decimal)

            Try

                If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                    EmployeeOffset = LoadEmployeeHoursOffset(DbContext, EmployeeCode)

                End If

                Offset = EmployeeOffset

            Catch ex As Exception
                EmployeeOffset = 0.0
            End Try

            If Offset = 0 Then

                Try

                    AgencyOffset = LoadAgencyHoursOffset(DbContext)

                Catch ex As Exception
                    AgencyOffset = 0.0
                End Try

                Offset = AgencyOffset

            End If

            If Offset = 0 Then

                Try

                    DatabaseOffset = LoadSQLHoursOffset(DbContext)

                Catch ex As Exception
                    DatabaseOffset = 0
                End Try

                Offset = DatabaseOffset

            End If

            LoadTimeZoneOffsetForEmployeeForceUtcZero = Offset

        End Function

        Public Function LoadTimeZoneOffsetForClientPortalUser(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalUserID As Integer) As Decimal

            Dim Offset As Decimal = CType(0.0, Decimal)
            Dim DatabaseOffset As Decimal = CType(0.0, Decimal)
            Dim AgencyOffset As Decimal = CType(0.0, Decimal)
            Dim ClientPortalUserOffset As Decimal = CType(0.0, Decimal)

            Try

                DatabaseOffset = LoadSQLHoursOffset(DbContext)

            Catch ex As Exception
                DatabaseOffset = 0
            End Try

            If DatabaseOffset <> 0 Then 'if not using UTC zero then must have a database setting to act as anchor for the offset!

                Try

                    AgencyOffset = LoadAgencyHoursOffset(DbContext)

                Catch ex As Exception
                    AgencyOffset = 0.0
                End Try
                Try

                    If ClientPortalUserID > 0 Then

                        ClientPortalUserOffset = LoadClientPortalUserHoursOffset(DbContext, ClientPortalUserID)

                    End If

                    Offset = ClientPortalUserOffset

                Catch ex As Exception
                    ClientPortalUserOffset = 0.0
                End Try
                If ClientPortalUserOffset = 0 Then

                    Offset = AgencyOffset - DatabaseOffset

                Else

                    Offset = ClientPortalUserOffset - DatabaseOffset

                End If

            End If

            LoadTimeZoneOffsetForClientPortalUser = Offset

        End Function
        Public Function LoadTimeZoneOffsetForClientPortalUserForceUtcZero(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalUserID As Integer) As Decimal

            Dim Offset As Decimal = CType(0.0, Decimal)
            Dim DatabaseOffset As Decimal = CType(0.0, Decimal)
            Dim AgencyOffset As Decimal = CType(0.0, Decimal)
            Dim ClientPortalUserOffset As Decimal = CType(0.0, Decimal)

            Try

                If ClientPortalUserID > 0 Then

                    ClientPortalUserOffset = LoadClientPortalUserHoursOffset(DbContext, ClientPortalUserID)

                End If

                Offset = ClientPortalUserOffset

            Catch ex As Exception
                ClientPortalUserOffset = 0.0
            End Try

            If Offset = 0 Then

                Try

                    AgencyOffset = LoadAgencyHoursOffset(DbContext)

                Catch ex As Exception
                    AgencyOffset = 0.0
                End Try

                Offset = AgencyOffset

            End If

            If Offset = 0 Then

                Try

                    DatabaseOffset = LoadSQLHoursOffset(DbContext)

                Catch ex As Exception
                    DatabaseOffset = 0
                End Try

                Offset = DatabaseOffset

            End If

            LoadTimeZoneOffsetForClientPortalUserForceUtcZero = Offset

        End Function

        Public Function LoadDatabaseTimeZoneID(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            'objects
            Dim DatabaseTimeZoneID As String = String.Empty

            Try

                DatabaseTimeZoneID = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(DB_TIMEZONE_ID, '') FROM dbo.AGENCY WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                DatabaseTimeZoneID = String.Empty
            End Try

            LoadDatabaseTimeZoneID = DatabaseTimeZoneID

        End Function
        Public Function LoadDatabaseTimeZoneID(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim DatabaseTimeZoneID As String = String.Empty

            Try

                DatabaseTimeZoneID = DataContext.ExecuteQuery(Of String)("SELECT ISNULL(DB_TIMEZONE_ID, '') FROM dbo.AGENCY WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                DatabaseTimeZoneID = String.Empty
            End Try

            LoadDatabaseTimeZoneID = DatabaseTimeZoneID

        End Function
        Public Function LoadAgencyTimeZoneID(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            'objects
            Dim AgencyTimeZoneID As String = String.Empty

            Try

                AgencyTimeZoneID = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(TIMEZONE_ID, '') FROM dbo.AGENCY WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                AgencyTimeZoneID = String.Empty
            End Try

            LoadAgencyTimeZoneID = AgencyTimeZoneID

        End Function
        Public Function LoadAgencyTimeZoneID(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim AgencyTimeZoneID As String = String.Empty

            Try

                AgencyTimeZoneID = DataContext.ExecuteQuery(Of String)("SELECT ISNULL(TIMEZONE_ID, '') FROM dbo.AGENCY WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                AgencyTimeZoneID = String.Empty
            End Try

            LoadAgencyTimeZoneID = AgencyTimeZoneID

        End Function
        Public Function LoadEmployeeTimeZoneID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As String

            'objects
            Dim EmployeeTimeZoneID As String = String.Empty

            Try

                EmployeeTimeZoneID = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(TIME_ZONE_ID, '') FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '{0}';", EmployeeCode)).FirstOrDefault

            Catch ex As Exception
                EmployeeTimeZoneID = String.Empty
            End Try

            LoadEmployeeTimeZoneID = EmployeeTimeZoneID

        End Function
        Public Function LoadEmployeeTimeZoneID(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal EmployeeCode As String) As String

            'objects
            Dim EmployeeTimeZoneID As String = String.Empty

            Try

                EmployeeTimeZoneID = DataContext.ExecuteQuery(Of String)(String.Format("SELECT ISNULL(TIME_ZONE_ID, '') FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '{0}';", EmployeeCode)).FirstOrDefault

            Catch ex As Exception
                EmployeeTimeZoneID = String.Empty
            End Try

            LoadEmployeeTimeZoneID = EmployeeTimeZoneID

        End Function
        Public Function LoadClientPortalUserTimeZoneID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalUserID As Integer) As String

            'objects
            Dim ClientPortalUserTimeZoneID As String = String.Empty

            Try

                ClientPortalUserTimeZoneID = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(TIME_ZONE_ID, '') FROM CP_USER WITH(NOLOCK) WHERE CDP_CONTACT_ID = {0};", ClientPortalUserID)).FirstOrDefault

            Catch ex As Exception
                ClientPortalUserTimeZoneID = String.Empty
            End Try

            LoadClientPortalUserTimeZoneID = ClientPortalUserTimeZoneID

        End Function
        Public Function LoadClientPortalUserTimeZoneID(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal ClientPortalUserID As Integer) As String

            'objects
            Dim ClientPortalUserTimeZoneID As String = String.Empty

            Try

                ClientPortalUserTimeZoneID = DataContext.ExecuteQuery(Of String)(String.Format("SELECT ISNULL(TIME_ZONE_ID, '') FROM CP_USER WITH(NOLOCK) WHERE CDP_CONTACT_ID = {0};", ClientPortalUserID)).FirstOrDefault

            Catch ex As Exception
                ClientPortalUserTimeZoneID = String.Empty
            End Try

            LoadClientPortalUserTimeZoneID = ClientPortalUserTimeZoneID

        End Function

        Public Function LoadSQLHoursOffset(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext) As Decimal

            'objects
            Dim SQLHoursOffset As Decimal = 0.0
            Dim DatabaseTimeZoneID As String = String.Empty

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DataContext)

            SQLHoursOffset = GetOffsetFromSystemTimeZone(DatabaseTimeZoneID)

            LoadSQLHoursOffset = SQLHoursOffset

        End Function
        Public Function LoadSQLHoursOffset(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext) As Decimal

            'objects
            Dim SQLHoursOffset As Decimal = 0.0
            Dim DatabaseTimeZoneID As String = String.Empty

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DbContext)

            SQLHoursOffset = GetOffsetFromSystemTimeZone(DatabaseTimeZoneID)

            LoadSQLHoursOffset = SQLHoursOffset

        End Function
        Public Function LoadAgencyHoursOffset(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext) As Decimal

            'objects
            Dim AgencyHoursOffset As Decimal = 0.0
            Dim AgencyTimeZoneID As String = String.Empty

            AgencyTimeZoneID = LoadAgencyTimeZoneID(DataContext)

            AgencyHoursOffset = GetOffsetFromSystemTimeZone(AgencyTimeZoneID)

            LoadAgencyHoursOffset = AgencyHoursOffset

        End Function
        Public Function LoadAgencyHoursOffset(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext) As Decimal

            'objects
            Dim AgencyHoursOffset As Decimal = 0.0
            Dim AgencyTimeZoneID As String = String.Empty

            AgencyTimeZoneID = LoadAgencyTimeZoneID(DbContext)

            AgencyHoursOffset = GetOffsetFromSystemTimeZone(AgencyTimeZoneID)

            LoadAgencyHoursOffset = AgencyHoursOffset

        End Function
        Public Function LoadEmployeeHoursOffset(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal EmployeeCode As String) As Decimal

            'objects
            Dim EmployeeHoursOffset As Decimal = 0.0
            Dim EmployeeTimeZoneID As String = String.Empty

            EmployeeTimeZoneID = LoadEmployeeTimeZoneID(DataContext, EmployeeCode)

            EmployeeHoursOffset = GetOffsetFromSystemTimeZone(EmployeeTimeZoneID)

            LoadEmployeeHoursOffset = EmployeeHoursOffset

        End Function
        Public Function LoadEmployeeHoursOffset(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EmployeeCode As String) As Decimal

            'objects
            Dim EmployeeHoursOffset As Decimal = 0.0
            Dim EmployeeTimeZoneID As String = String.Empty

            EmployeeTimeZoneID = LoadEmployeeTimeZoneID(DbContext, EmployeeCode)

            EmployeeHoursOffset = GetOffsetFromSystemTimeZone(EmployeeTimeZoneID)

            LoadEmployeeHoursOffset = EmployeeHoursOffset

        End Function
        Public Function LoadClientPortalUserHoursOffset(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal ClientPortalUserID As Integer) As Decimal

            'objects
            Dim ClientPortalUserHoursOffset As Decimal = 0.0
            Dim ClientPortalUserTimeZoneID As String = String.Empty

            ClientPortalUserTimeZoneID = LoadClientPortalUserTimeZoneID(DataContext, ClientPortalUserID)

            ClientPortalUserHoursOffset = GetOffsetFromSystemTimeZone(ClientPortalUserTimeZoneID)

            LoadClientPortalUserHoursOffset = ClientPortalUserHoursOffset

        End Function
        Public Function LoadClientPortalUserHoursOffset(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal ClientPortalUserID As Integer) As Decimal

            'objects
            Dim ClientPortalUserHoursOffset As Decimal = 0.0
            Dim ClientPortalUserTimeZoneID As String = String.Empty

            ClientPortalUserTimeZoneID = LoadClientPortalUserTimeZoneID(DbContext, ClientPortalUserID)

            ClientPortalUserHoursOffset = GetOffsetFromSystemTimeZone(ClientPortalUserTimeZoneID)

            LoadClientPortalUserHoursOffset = ClientPortalUserHoursOffset

        End Function

        Public Function GetOffsetFromSystemTimeZone(ByVal TimeZoneID As String) As Decimal

            Dim Offset As Decimal = 0.0
            Dim TimeZone As TimeZoneInfo = Nothing

            If String.IsNullOrWhiteSpace(TimeZoneID) = False Then

                Try

                    TimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneID)

                    If TimeZone IsNot Nothing Then

                        Offset = CType(TimeZone.BaseUtcOffset.Hours + (TimeZone.BaseUtcOffset.Minutes / 60), Decimal)

                        If TimeZone.IsDaylightSavingTime(Now.Date) = True Then

                            Offset += 1

                        End If

                    End If

                Catch ex As Exception
                    Offset = 0.0
                End Try

            End If

            GetOffsetFromSystemTimeZone = Offset

        End Function

#End Region

    End Module

End Namespace
