using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AdvantageFramework.Core.Security.Database.Procedures
{
    public static class User
    {
        //public static string LoadEmailAddressByUserCode(Database.DbContext DbContext, string UserCode)
        //{
        //    string EmailAddress = string.Empty;
        //    try
        //    {
        //        string SQL = string.Empty;
        //        SQL = @" SELECT TOP 1 
	       //                 E.EMP_EMAIL
        //                FROM 
	       //                 EMPLOYEE E WITH(NOLOCK) 
	       //                 INNER JOIN SEC_USER S WITH(NOLOCK) ON E.EMP_CODE = S.EMP_CODE 
        //                WHERE 
	       //                 S.USER_CODE = '{0}' 
        //                ORDER BY 
	       //                 S.SEC_USER_ID DESC;";
        //        EmailAddress = DbContext.Database.SqlQuery<string>(string.Format(SQL, UserCode)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        EmailAddress = string.Empty;
        //    }

        //    return EmailAddress;
        //}

        public static System.Linq.IQueryable<Security.Database.Entities.User> LoadByUserIDs(Security.Database.DbContext DbContext, int[] UserIDs)
        {
            System.Linq.IQueryable<Security.Database.Entities.User> LoadByUserIDsRet = default;
            LoadByUserIDsRet = from User in DbContext.Users.AsQueryable()
                               where UserIDs.Contains(User.SecUserId)
                               select User;
            return LoadByUserIDsRet;
        }

        //public static void ChangeUserAdAssistPassword(Database.DbContext DbContext, bool IsInserting, int UserID, string Password, ref int ReturnValue)
        //{

        //    // objects
        //    Microsoft.Data.SqlClient.SqlParameter SqlParameterUserID = null;
        //    Microsoft.Data.SqlClient.SqlParameter SqlParameterPassword = null;
        //    Microsoft.Data.SqlClient.SqlParameter SqlParameterReturnValue = null;
        //    SqlParameterUserID = new Microsoft.Data.SqlClient.SqlParameter("@sec_user_id", SqlDbType.Int);
        //    SqlParameterPassword = new Microsoft.Data.SqlClient.SqlParameter("@pwd_d", SqlDbType.VarChar);
        //    SqlParameterReturnValue = new Microsoft.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int);
        //    SqlParameterReturnValue.Direction = ParameterDirection.Output;
        //    try
        //    {
        //        SqlParameterUserID.Value = UserID;
        //        SqlParameterPassword.Value = Password;
        //        SqlParameterReturnValue.Value = 0;
        //        if (IsInserting)
        //        {
        //            DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_INSERT_SEC_USER_AUTH @sec_user_id, @pwd_d, @ret_val OUTPUT", SqlParameterUserID, SqlParameterPassword, SqlParameterReturnValue);
        //        }
        //        else
        //        {
        //            DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_UPDATE_SEC_USER_AUTH @sec_user_id, @pwd_d, @ret_val OUTPUT", SqlParameterUserID, SqlParameterPassword, SqlParameterReturnValue);
        //        }

        //        ReturnValue = int.Parse(SqlParameterReturnValue.Value.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        ReturnValue = -2;
        //    }
        //}

        public static Security.Database.Entities.User LoadByUserID(Security.Database.DbContext DbContext, int UserID)
        {
            Security.Database.Entities.User LoadByUserIDRet = default;
            try
            {
                LoadByUserIDRet = (from User in DbContext.Users.AsQueryable()
                                   where User.SecUserId == UserID
                                   select User).SingleOrDefault();
            }
            catch (Exception ex)
            {
                LoadByUserIDRet = default;
            }

            return LoadByUserIDRet;
        }

        public static Security.Database.Entities.User LoadByUserName(Security.Database.DbContext DbContext, string UserName)
        {
            Security.Database.Entities.User LoadByUserNameRet = default;
            try
            {
                LoadByUserNameRet = (from User in DbContext.Users.AsQueryable()
                                     where User.UserName == UserName
                                     select User).SingleOrDefault();
            }
            catch (Exception ex)
            {
                LoadByUserNameRet = default;
            }

            return LoadByUserNameRet;
        }

        public static Security.Database.Entities.User LoadByUserCode(Security.Database.DbContext DbContext, string UserCode)
        {
            Security.Database.Entities.User LoadByUserCodeRet = default;
            try
            {
                LoadByUserCodeRet = (from User in DbContext.Users.AsQueryable()
                                     where User.UserCode.ToUpper() == UserCode.ToUpper()
                                     select User).SingleOrDefault();
            }
            catch (Exception ex)
            {
                LoadByUserCodeRet = default;
            }

            return LoadByUserCodeRet;
        }

        public static System.Linq.IQueryable<Security.Database.Entities.User> LoadByEmployeeCode(Security.Database.DbContext DbContext, string EmployeeCode)
        {
            System.Linq.IQueryable<Security.Database.Entities.User> LoadByEmployeeCodeRet = default;
            LoadByEmployeeCodeRet = from User in DbContext.Users.AsQueryable()
                                    where User.EmpCode == EmployeeCode
                                    select User;
            return LoadByEmployeeCodeRet;
        }

        public static Security.Database.Entities.User LoadFirstUserByEmployeeCode(Security.Database.DbContext DbContext, string EmployeeCode)
        {
            Security.Database.Entities.User LoadFirstUserByEmployeeCodeRet = default;
            try
            {
                LoadFirstUserByEmployeeCodeRet = (from User in DbContext.Users.AsQueryable()
                                                  where User.EmpCode == EmployeeCode
                                                  select User).FirstOrDefault();
            }
            catch (Exception ex)
            {
                LoadFirstUserByEmployeeCodeRet = default;
            }

            return LoadFirstUserByEmployeeCodeRet;
        }

        public static Security.Database.Entities.User LoadByUserCodeWithAllOptions(Security.Database.DbContext DbContext, string UserCode)
        {
            Security.Database.Entities.User LoadByUserCodeWithAllOptionsRet = default;
            try
            {
                LoadByUserCodeWithAllOptionsRet = (from User in DbContext.Users.Include("GroupUsers").Include("GroupUsers.Group").Include("GroupUsers.Group.GroupApplicationAccesses").Include("UserApplicationAccesses")
                                                   where User.UserCode.ToUpper() == UserCode.ToUpper()
                                                   select User).SingleOrDefault();
            }
            catch (Exception ex)
            {
                LoadByUserCodeWithAllOptionsRet = default;
            }

            return LoadByUserCodeWithAllOptionsRet;
        }

        public static System.Linq.IQueryable<Security.Database.Entities.User> LoadWithAllOptions(Security.Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Security.Database.Entities.User> LoadWithAllOptionsRet = default;
            LoadWithAllOptionsRet = from User in DbContext.Users.Include("GroupUsers").Include("GroupUsers.Group").Include("GroupUsers.Group.GroupApplicationAccesses").Include("UserApplicationAccesses")
                                    select User;
            return LoadWithAllOptionsRet;
        }

        public static System.Linq.IQueryable<Security.Database.Entities.User> Load(Security.Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Security.Database.Entities.User> LoadRet = default;
            LoadRet = from User in DbContext.Users.AsQueryable()
                      select User;
            return LoadRet;
        }

        //public static bool Insert(Security.Database.DbContext DbContext, string UserCode, string EmployeeCode, string UserName, bool CheckForUserAccess, string SID, ref Security.Database.Entities.User User)
        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    try
        //    {
        //        User = new AdvantageFramework.Core.Security.Database.Entities.User();
        //        //User.DbContext = DbContext;
        //        User.UserCode = UserCode;
        //        User.EmpCode = EmployeeCode;
        //        User.UserName = UserName;
        //        User.CheckUserAccess = CheckForUserAccess;
        //        User.Password = string.Empty;
        //        User.Sid = SID;
        //        Inserted = Insert(DbContext, User);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inserted = false;
        //    }
        //    finally
        //    {
        //        InsertRet = Inserted;
        //    }

        //    return InsertRet;
        //}

        //public static bool Insert(AdvantageFramework.Core.Security.Database.DbContext DbContext, AdvantageFramework.Core.Security.Database.Entities.User User)
        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    AdvantageFramework.Core.Security.Database.Entities.Module Module = default;
        //    AdvantageFramework.Core.Security.Attributes.SecuritySettingAttribute SecuritySettingAttribute = default;
        //    try
        //    {
        //        DbContext.Users.Add(User);
        //        ErrorText = User.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DbContext.SaveChanges();

        //            // Try

        //            // If DbContext.Database.SqlQuery(Of String)(String.Format("SELECT USER_CODE FROM dbo.U_APP_SECURITY WHERE USER_CODE = '{0}'", User.UserCode)).Any = False Then

        //            // IsValid = DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[U_APP_SECURITY]([USER_CODE], [EMP_CODE], [USER_NAME]) " & _
        //            // "VALUES ('{0}', '{1}', '{2}')", User.UserCode, User.EmployeeCode, User.Employee.ToString)) > 0

        //            // Else

        //            // IsValid = True

        //            // End If

        //            // Catch ex As Exception
        //            // IsValid = False
        //            // End Try

        //            if (IsValid)
        //            {
        //                Inserted = true;
        //                foreach (AdvantageFramework.Core.Security.Database.Entities.Application Application in AdvantageFramework.Core.Security.Database.Procedures.Application.Load(DbContext).ToList)
        //                    AdvantageFramework.Core.Security.Database.Procedures.UserApplicationAccess.Insert(DbContext, User.ID, Application.ID, false, true, true, true, false, false, default);
        //                DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.SEC_USER_MODACCESS([SEC_MODULE_ID], [SEC_USER_ID], [IS_BLOCKED], [CAN_ADD], [CAN_PRINT], [CAN_UPDATE], [CUSTOM1], [CUSTOM2]) " + "SELECT [SEC_MODULE_ID], " + User.ID + ", 0, 1, 1, 1, 0, 0 FROM dbo.SEC_MODULE");
        //                foreach (var Setting in AdvantageFramework.EnumUtilities.GetEnumNameList(typeof(AdvantageFramework.Security.UserSettings), false))
        //                {
        //                    try
        //                    {
        //                        SecuritySettingAttribute = Attribute.GetCustomAttribute(typeof(AdvantageFramework.Core.Security.UserSettings).GetField(Conversions.ToString(Setting)), typeof(AdvantageFramework.Security.Attributes.SecuritySettingAttribute));
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        SecuritySettingAttribute = default;
        //                    }

        //                    if (SecuritySettingAttribute is object)
        //                    {
        //                        if (SecuritySettingAttribute.ValueType == SettingsValueType.NumericValue)
        //                        {
        //                            AdvantageFramework.Security.Core.Database.Procedures.UserSetting.Insert(DbContext, User.ID, Setting, default, SecuritySettingAttribute.DefaultValue, default, default);
        //                        }
        //                        else if (SecuritySettingAttribute.ValueType == SettingsValueType.DateValue)
        //                        {
        //                            AdvantageFramework.Core.Security.Database.Procedures.UserSetting.Insert(DbContext, User.ID, Setting, default, default, SecuritySettingAttribute.DefaultValue, default);
        //                        }
        //                        else
        //                        {
        //                            AdvantageFramework.Core.Security.Database.Procedures.UserSetting.Insert(DbContext, User.ID, Setting, SecuritySettingAttribute.DefaultValue, default, default, default);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        AdvantageFramework.Core.Security.Database.Procedures.UserSetting.Insert(DbContext, User.ID, Setting, default, default, default, default);
        //                    }
        //                }

        //                // AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.CreateDatabaseSQLUser(DbContext, User.UserName, IsAdvantageAdmin, False)

        //                try
        //                {
        //                    DbContext.Database.ExecuteSqlCommand(string.Format("INSERT INTO [dbo].[SEC_USER_UDRACCESS]([SEC_USER_ID], [USER_DEF_REPORT_ID], [IS_BLOCKED]) " + "SELECT {0}, [USER_DEF_REPORT_ID], 1 FROM [dbo].[USER_DEF_REPORT]", User.ID));
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }
        //            else
        //            {
        //                ErrorText = "Failed to create user in legacy security.";
        //                try
        //                {
        //                    DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_USER WHERE SEC_USER_ID = " + User.ID);
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }
        //        }

        //        if (Inserted == false)
        //        {
        //            AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Inserted = false;
        //    }
        //    finally
        //    {
        //        InsertRet = Inserted;
        //    }

        //    return InsertRet;
        //}

        //public static bool Update(AdvantageFramework.Core.Security.Database.DbContext DbContext, AdvantageFramework.Core.Security.Database.Entities.User User)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        DbContext.UpdateObject(User);
        //        ErrorText = User.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DbContext.SaveChanges();
        //            Updated = true;
        //        }
        //        else
        //        {
        //            AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }
        //    finally
        //    {
        //        UpdateRet = Updated;
        //    }

        //    return UpdateRet;
        //}

        //public static bool Delete(AdvantageFramework.Core.Security.Database.DbContext DbContext, AdvantageFramework.Core.Security.Database.Entities.User User)
        //{
        //    bool DeleteRet = default;

        //    // objects
        //    bool Deleted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    AdvantageFramework.Core.Security.Database.Entities.UserApplicationAccess UserApplicationAccess = default;
        //    AdvantageFramework.Core.Security.Database.Entities.UserModuleAccess UserModuleAccess = default;
        //    AdvantageFramework.Core.Security.Database.Entities.UserSetting UserSetting = default;
        //    try
        //    {
        //        if (IsValid)
        //        {
        //            if (AdvantageFramework.Security.Database.Procedures.GroupUser.DeleteByUserID(DbContext, User.ID))
        //            {
        //                if (AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.DeleteByUserID(DbContext, User.ID))
        //                {
        //                    if (AdvantageFramework.Security.Database.Procedures.UserModuleAccess.DeleteByUserID(DbContext, User.ID))
        //                    {
        //                        if (AdvantageFramework.Security.Database.Procedures.UserSetting.DeleteByUserID(DbContext, User.ID))
        //                        {
        //                            DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_DELETE_SEC_USER_AUTH " + User.ID + ", 0");
        //                            if (AdvantageFramework.Security.Database.Procedures.UserWorkspace.DeleteByUserCode(DbContext, User.UserCode))
        //                            {
        //                                if (AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.DeleteByUserID(DbContext, User.ID))
        //                                {
        //                                    AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.DeleteByUserCode(DbContext, User.UserCode);
        //                                    AdvantageFramework.Security.Database.Procedures.UserMenu.DeleteByUserID(DbContext, User.ID);
        //                                    AdvantageFramework.Security.Database.Procedures.UserMenuTab.DeleteByUserID(DbContext, User.ID);
        //                                    try
        //                                    {
        //                                        DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_CLIENT WHERE [USER_ID] = '" + User.UserCode + "'");
        //                                    }
        //                                    catch (Exception ex)
        //                                    {
        //                                    }

        //                                    try
        //                                    {
        //                                        DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_REPORTS WHERE [USER_ID] = '" + User.UserCode + "'");
        //                                    }
        //                                    catch (Exception ex)
        //                                    {
        //                                    }

        //                                    try
        //                                    {
        //                                        DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_PWD_LOCK WHERE [USER_CODE] = '" + User.UserCode + "'");
        //                                    }
        //                                    catch (Exception ex)
        //                                    {
        //                                    }
        //                                    // If DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.U_APP_SECURITY WHERE USER_CODE = '" & User.UserCode & "'") > 0 Then

        //                                    // AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.DeleteDatabaseSQLUser(DbContext, User.UserName)

        //                                    DbContext.DeleteEntityObject(User);
        //                                    DbContext.SaveChanges();
        //                                    Deleted = true;

        //                                    // End If

        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Deleted = false;
        //    }
        //    finally
        //    {
        //        DeleteRet = Deleted;
        //    }

        //    return DeleteRet;
        //}
    }
}
