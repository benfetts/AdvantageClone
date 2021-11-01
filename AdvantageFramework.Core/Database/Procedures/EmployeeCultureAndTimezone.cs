using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static class EmployeeCultureAndTimezone
    {
        #region Constants



        #endregion

        #region Enum



        #endregion

        #region Variables



        #endregion

        #region Properties



        #endregion

        #region Methods

        public static string LoadEmployeeCultureCode(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        {
            string CultureCode = "en-US";

            try
            {
                using (var command = DbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("SELECT ISNULL(CULTURE_CODE, 'en-US') FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '{0}';", EmployeeCode);
                    command.CommandType = CommandType.Text;

                    DbContext.Database.OpenConnection();

                    CultureCode = command.ExecuteScalar().ToString();

                }
            }
            catch (Exception)
            {
                CultureCode = "en-US";
            }

            return CultureCode;
        }
        public static string LoadAgencyCultureCode(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            string CultureCode = "en-US";

            try
            {
                using (var command = DbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("SELECT ISNULL(CULTURE_CODE, 'en-US') FROM AGENCY WITH(NOLOCK);");
                    command.CommandType = CommandType.Text;

                    DbContext.Database.OpenConnection();

                    CultureCode = command.ExecuteScalar().ToString();

                }
            }
            catch (Exception)
            {
                CultureCode = "en-US";
            }

            return CultureCode;
        }
        public static string LoadDatabaseCultureCode(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            string CultureCode = "en-US";

            try
            {
                using (var command = DbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("SELECT ISNULL(DB_CULTURE_CODE, 'en-US') FROM AGENCY WITH(NOLOCK);");
                    command.CommandType = CommandType.Text;

                    DbContext.Database.OpenConnection();

                    CultureCode = command.ExecuteScalar().ToString();

                }
            }
            catch (Exception)
            {
                CultureCode = "en-US";
            }

            return CultureCode;
        }
        public static bool SaveEmployeeCultureCode(AdvantageFramework.Core.Database.DbContext DbContext, string CultureCode, string EmployeeCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CultureCode) == true)
                    CultureCode = "en-US";

                DbContext.Database.ExecuteSqlRawAsync(string.Format("UPDATE EMPLOYEE SET CULTURE_CODE = '{0}' WHERE EMP_CODE = '{1}';", CultureCode, EmployeeCode));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool SaveAgencyCultureCode(AdvantageFramework.Core.Database.DbContext DbContext, string CultureCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CultureCode) == true)
                    CultureCode = "en-US";

                DbContext.Database.ExecuteSqlRawAsync(string.Format("UPDATE AGENCY SET CULTURE_CODE = '{0}';", CultureCode));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool SaveDatabaseCultureCode(AdvantageFramework.Core.Database.DbContext DbContext, string CultureCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CultureCode) == true)
                    CultureCode = "en-US";

                DbContext.Database.ExecuteSqlRawAsync(string.Format("UPDATE AGENCY SET DB_CULTURE_CODE = '{0}';", CultureCode));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Nullable<DateTime> GetOffsetDateTime(double Offset, Nullable<DateTime> Date)
        {

            // objects
            Nullable<DateTime> OffsetDateTime = default(DateTime?);

            if (Date.HasValue && Offset != 0)
                OffsetDateTime = GetOffsetDateTime(Offset, Date.Value);
            else
                OffsetDateTime = Date;

            return OffsetDateTime;
        }
        public static DateTime GetOffsetDateTime(double Offset, DateTime Date)
        {

            // objects
            DateTime OffsetDateTime = DateTime.MinValue;

            if (Offset != 0)
                OffsetDateTime = System.Convert.ToDateTime(Date).AddMinutes((System.Convert.ToDouble(Offset) * 60) + ((Offset - System.Convert.ToDouble(Offset)) * 60));
            else
                OffsetDateTime = Date;

            return OffsetDateTime;
        }
        public static DateTime LoadDatabaseTime(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            DateTime DatabaseTime = new DateTime();
            try
            {
                using (var command = DbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("SELECT GETDATE();");
                    command.CommandType = CommandType.Text;

                    DbContext.Database.OpenConnection();

                    DatabaseTime = Convert.ToDateTime(command.ExecuteScalar());

                }
            }
            catch (Exception)
            {
               // DatabaseTime = null;
            }
            return DatabaseTime;
        }
        public static DateTime TimeZoneTodayForEmployee(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        {
            double Offset = System.Convert.ToDouble(0);

            Offset = LoadTimeZoneOffsetForEmployee(DbContext, EmployeeCode);

            if (Offset != 0)
                return System.Convert.ToDateTime(DateTime.Now).AddHours(System.Convert.ToDouble(Offset));
            else
                return System.Convert.ToDateTime(DateTime.Now);
        }
        public static DateTime TimeZoneTodayForClientPortalUser(AdvantageFramework.Core.Database.DbContext DbContext, int ClientPortalUserID)
        {
            double Offset = System.Convert.ToDouble(0);

            Offset = LoadTimeZoneOffsetForClientPortalUser(DbContext, ClientPortalUserID);

            if (Offset != 0)
                return System.Convert.ToDateTime(DateTime.Now).AddHours(System.Convert.ToDouble(Offset));
            else
                return DateTime.Now.Date;
        }
        public static string LoadTimeZoneIDForEmployee(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        {
            string TimeZoneID = string.Empty;
            string DatabaseTimeZoneID = string.Empty;
            string AgencyTimeZoneID = string.Empty;
            string EmployeeTimeZoneID = string.Empty;

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DbContext);

            if (string.IsNullOrWhiteSpace(DatabaseTimeZoneID) == false)
            {
                TimeZoneID = DatabaseTimeZoneID;
                AgencyTimeZoneID = LoadAgencyTimeZoneID(DbContext);
                EmployeeTimeZoneID = LoadEmployeeTimeZoneID(DbContext, EmployeeCode);

                if (string.IsNullOrWhiteSpace(AgencyTimeZoneID) == false)
                    TimeZoneID = AgencyTimeZoneID;
                if (string.IsNullOrWhiteSpace(EmployeeTimeZoneID) == false)
                    TimeZoneID = EmployeeTimeZoneID;
            }

            return TimeZoneID;
        }
        public static string LoadTimeZoneIDForClientPortalUser(AdvantageFramework.Core.Database.DbContext DbContext, int ClientPortalUserID)
        {
            string TimeZoneID = string.Empty;
            string DatabaseTimeZoneID = string.Empty;
            string AgencyTimeZoneID = string.Empty;
            string ClientPortalUserTimeZoneID = string.Empty;

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DbContext);

            if (string.IsNullOrWhiteSpace(DatabaseTimeZoneID) == false)
            {
                TimeZoneID = DatabaseTimeZoneID;
                AgencyTimeZoneID = LoadAgencyTimeZoneID(DbContext);
                ClientPortalUserTimeZoneID = LoadClientPortalUserTimeZoneID(DbContext, ClientPortalUserID);

                if (string.IsNullOrWhiteSpace(AgencyTimeZoneID) == false)
                    TimeZoneID = AgencyTimeZoneID;
                if (string.IsNullOrWhiteSpace(ClientPortalUserTimeZoneID) == false)
                    TimeZoneID = ClientPortalUserTimeZoneID;
            }

            return TimeZoneID;
        }
        public static double LoadTimeZoneOffsetForEmployee(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        {
            double Offset = System.Convert.ToDouble(0);
            double DatabaseOffset = System.Convert.ToDouble(0);
            double AgencyOffset = System.Convert.ToDouble(0);
            double EmployeeOffset = System.Convert.ToDouble(0);

            try
            {
                DatabaseOffset = LoadSQLHoursOffset(DbContext);
            }
            catch (Exception)
            {
                DatabaseOffset = 0;
            }

            if (DatabaseOffset != 0)
            {
                try
                {
                    AgencyOffset = LoadAgencyHoursOffset(DbContext);
                }
                catch (Exception)
                {
                    AgencyOffset = 0;
                }
                try
                {
                    if (string.IsNullOrWhiteSpace(EmployeeCode) == false)
                        EmployeeOffset = LoadEmployeeHoursOffset(DbContext, EmployeeCode);
                }
                catch (Exception)
                {
                    EmployeeOffset = 0;
                }
                if (EmployeeOffset == 0)
                    Offset = AgencyOffset - DatabaseOffset;
                else
                    Offset = EmployeeOffset - DatabaseOffset;
            }

            return Offset;
        }
        public static double LoadTimeZoneOffsetForEmployeeForceUtcZero(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        {
            double Offset = System.Convert.ToDouble(0);
            double DatabaseOffset = System.Convert.ToDouble(0);
            double AgencyOffset = System.Convert.ToDouble(0);
            double EmployeeOffset = System.Convert.ToDouble(0);

            try
            {
                if (string.IsNullOrWhiteSpace(EmployeeCode) == false)
                    EmployeeOffset = LoadEmployeeHoursOffset(DbContext, EmployeeCode);

                Offset = EmployeeOffset;
            }
            catch (Exception)
            {
                EmployeeOffset = 0;
            }

            if (Offset == 0)
            {
                try
                {
                    AgencyOffset = LoadAgencyHoursOffset(DbContext);
                }
                catch (Exception)
                {
                    AgencyOffset = 0;
                }

                Offset = AgencyOffset;
            }

            if (Offset == 0)
            {
                try
                {
                    DatabaseOffset = LoadSQLHoursOffset(DbContext);
                }
                catch (Exception)
                {
                    DatabaseOffset = 0;
                }

                Offset = DatabaseOffset;
            }

            return Offset;
        }
        public static double LoadTimeZoneOffsetForClientPortalUser(AdvantageFramework.Core.Database.DbContext DbContext, int ClientPortalUserID)
        {
            double Offset = System.Convert.ToDouble(0);
            double DatabaseOffset = System.Convert.ToDouble(0);
            double AgencyOffset = System.Convert.ToDouble(0);
            double ClientPortalUserOffset = System.Convert.ToDouble(0);

            try
            {
                DatabaseOffset = LoadSQLHoursOffset(DbContext);
            }
            catch (Exception)
            {
                DatabaseOffset = 0;
            }

            if (DatabaseOffset != 0)
            {
                try
                {
                    AgencyOffset = LoadAgencyHoursOffset(DbContext);
                }
                catch (Exception)
                {
                    AgencyOffset = 0;
                }
                try
                {
                    if (ClientPortalUserID > 0)
                        ClientPortalUserOffset = LoadClientPortalUserHoursOffset(DbContext, ClientPortalUserID);

                    Offset = ClientPortalUserOffset;
                }
                catch (Exception)
                {
                    ClientPortalUserOffset = 0;
                }
                if (ClientPortalUserOffset == 0)
                    Offset = AgencyOffset - DatabaseOffset;
                else
                    Offset = ClientPortalUserOffset - DatabaseOffset;
            }

            return Offset;
        }
        public static double LoadTimeZoneOffsetForClientPortalUserForceUtcZero(AdvantageFramework.Core.Database.DbContext DbContext, int ClientPortalUserID)
        {
            double Offset = System.Convert.ToDouble(0);
            double DatabaseOffset = System.Convert.ToDouble(0);
            double AgencyOffset = System.Convert.ToDouble(0);
            double ClientPortalUserOffset = System.Convert.ToDouble(0);

            try
            {
                if (ClientPortalUserID > 0)
                    ClientPortalUserOffset = LoadClientPortalUserHoursOffset(DbContext, ClientPortalUserID);

                Offset = ClientPortalUserOffset;
            }
            catch (Exception)
            {
                ClientPortalUserOffset = 0;
            }

            if (Offset == 0)
            {
                try
                {
                    AgencyOffset = LoadAgencyHoursOffset(DbContext);
                }
                catch (Exception)
                {
                    AgencyOffset = 0;
                }

                Offset = AgencyOffset;
            }

            if (Offset == 0)
            {
                try
                {
                    DatabaseOffset = LoadSQLHoursOffset(DbContext);
                }
                catch (Exception)
                {
                    DatabaseOffset = 0;
                }

                Offset = DatabaseOffset;
            }

            return Offset;
        }
        public static string LoadDatabaseTimeZoneID(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            string DatabaseTimeZoneID = string.Empty;
            try
            {
                using (var command = DbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("SELECT ISNULL(DB_TIMEZONE_ID, '') FROM dbo.AGENCY WITH(NOLOCK);");
                    command.CommandType = CommandType.Text;

                    DbContext.Database.OpenConnection();

                    DatabaseTimeZoneID = command.ExecuteScalar().ToString();

                }
            }
            catch (Exception)
            {
                DatabaseTimeZoneID = string.Empty;
            }
            return DatabaseTimeZoneID;
        }
        public static string LoadAgencyTimeZoneID(AdvantageFramework.Core.Database.DbContext DbContext)
        {

            // objects
            string AgencyTimeZoneID = string.Empty;

            try
            {
                using (var command = DbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("SELECT ISNULL(TIMEZONE_ID, '') FROM AGENCY WITH(NOLOCK);");
                    command.CommandType = CommandType.Text;

                    DbContext.Database.OpenConnection();

                    AgencyTimeZoneID = command.ExecuteScalar().ToString();

                }
            }
            catch (Exception)
            {
                AgencyTimeZoneID = string.Empty;
            }

            return AgencyTimeZoneID;
        }
        public static string LoadEmployeeTimeZoneID(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        {

            // objects
            string EmployeeTimeZoneID = string.Empty;

            try
            {
                using (var command = DbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("SELECT ISNULL(TIME_ZONE_ID, '') FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '{0}';", EmployeeCode);
                    command.CommandType = CommandType.Text;

                    DbContext.Database.OpenConnection();

                    EmployeeTimeZoneID = command.ExecuteScalar().ToString();

                }
            }
            catch (Exception)
            {
                EmployeeTimeZoneID = string.Empty;
            }

            return EmployeeTimeZoneID;
        }
        public static string LoadClientPortalUserTimeZoneID(AdvantageFramework.Core.Database.DbContext DbContext, int ClientPortalUserID)
        {

            // objects
            string ClientPortalUserTimeZoneID = string.Empty;

            try
            {                
                using(var command = DbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = string.Format("SELECT ISNULL(TIME_ZONE_ID, '') FROM CP_USER WITH(NOLOCK) WHERE CDP_CONTACT_ID = {0};", ClientPortalUserID);
                    command.CommandType = CommandType.Text;

                    DbContext.Database.OpenConnection();

                    ClientPortalUserTimeZoneID = command.ExecuteScalar().ToString();
                        
                }
            }
            catch (Exception)
            {
                ClientPortalUserTimeZoneID = string.Empty;
            }
            return ClientPortalUserTimeZoneID;
        }
        public static double LoadSQLHoursOffset(AdvantageFramework.Core.Database.DbContext DbContext)
        {

            // objects
            double SQLHoursOffset = 0;
            string DatabaseTimeZoneID = string.Empty;

            DatabaseTimeZoneID = LoadDatabaseTimeZoneID(DbContext);

            SQLHoursOffset = GetOffsetFromSystemTimeZone(DatabaseTimeZoneID);

            return SQLHoursOffset;
        }
        public static double LoadAgencyHoursOffset(AdvantageFramework.Core.Database.DbContext DbContext)
        {

            // objects
            double AgencyHoursOffset = 0;
            string AgencyTimeZoneID = string.Empty;

            AgencyTimeZoneID = LoadAgencyTimeZoneID(DbContext);

            AgencyHoursOffset = GetOffsetFromSystemTimeZone(AgencyTimeZoneID);

            return AgencyHoursOffset;
        }
        public static double LoadEmployeeHoursOffset(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        {

            // objects
            double EmployeeHoursOffset = 0;
            string EmployeeTimeZoneID = string.Empty;

            EmployeeTimeZoneID = LoadEmployeeTimeZoneID(DbContext, EmployeeCode);

            EmployeeHoursOffset = GetOffsetFromSystemTimeZone(EmployeeTimeZoneID);

            return EmployeeHoursOffset;
        }
        public static double LoadClientPortalUserHoursOffset(AdvantageFramework.Core.Database.DbContext DbContext, int ClientPortalUserID)
        {

            // objects
            double ClientPortalUserHoursOffset = 0;
            string ClientPortalUserTimeZoneID = string.Empty;

            ClientPortalUserTimeZoneID = LoadClientPortalUserTimeZoneID(DbContext, ClientPortalUserID);

            ClientPortalUserHoursOffset = GetOffsetFromSystemTimeZone(ClientPortalUserTimeZoneID);

            return ClientPortalUserHoursOffset;
        }
        public static double GetOffsetFromSystemTimeZone(string TimeZoneID)
        {
            double Offset = 0;
            TimeZoneInfo TimeZone = null;

            if (string.IsNullOrWhiteSpace(TimeZoneID) == false)
            {
                try
                {
                    TimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneID);

                    if (TimeZone != null)
                    {
                        Offset = System.Convert.ToDouble(TimeZone.BaseUtcOffset.Hours + (TimeZone.BaseUtcOffset.Minutes / (double)60));

                        if (TimeZone.IsDaylightSavingTime(DateTime.Now.Date) == true)
                            Offset += 1;
                    }
                }
                catch (Exception)
                {
                    Offset = 0;
                }
            }

            return Offset;
        }

        #endregion

        #region Classes



        #endregion
    }
    }
