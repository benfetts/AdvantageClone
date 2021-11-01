using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Navigation
{
    public static class Methods
    {
        public static event ShowMessageEventEventHandler ShowMessageEvent;

        public delegate void ShowMessageEventEventHandler(string Message);

        public static event ShowMessageBoxEventEventHandler ShowMessageBoxEvent;

        public delegate void ShowMessageBoxEventEventHandler(string Message, AdvantageFramework.Core.WinForm.MessageBox.Methods.MessageBoxButtons MessageBoxButtons, string Title, ref AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults DialogResult);

        //public static event ShowLoginEventEventHandler ShowLoginEvent;

        //public delegate void ShowLoginEventEventHandler(AdvantageFramework.Security.Application Application, ref AdvantageFramework.Database.DbContext DbContext, ref AdvantageFramework.Security.Session Session, string ServerName, string DatabaseName, bool UseWindowsAuthentication, string UserName, bool UpperCaseDatabaseAndUserName, ref AdvantageFramework.WinForm.MessageBox.DialogResults DialogResult);

        public static event ShowChangePasswordEventEventHandler ShowChangePasswordEvent;

        public delegate void ShowChangePasswordEventEventHandler(string ConnectionString, string UserName, ref string Password, ref AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults DialogResult);

        public static event ShowChangePasswordWithMessageEventEventHandler ShowChangePasswordWithMessageEvent;

        public delegate void ShowChangePasswordWithMessageEventEventHandler(string ConnectionString, string UserName, ref string Password, string Message, ref AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults DialogResult);

        public static event ClearNotificationAlertEventEventHandler ClearNotificationAlertEvent;

        public delegate void ClearNotificationAlertEventEventHandler();

        //public static event ShowReportViewerEventEventHandler ShowReportViewerEvent;

        //public delegate void ShowReportViewerEventEventHandler(AdvantageFramework.Security.Session Session, AdvantageFramework.Reporting.ReportTypes Report, Generic.Dictionary<string, object> ParameterDictionary, int Criteria, string FilterString, DateTime From, DateTime To, ref AdvantageFramework.WinForm.MessageBox.DialogResults DialogResult);

        public static event ShowErrorEventEventHandler ShowErrorEvent;

        public delegate void ShowErrorEventEventHandler(Exception Exception, ref AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults DialogResult);

        public enum Menus
        {
            NavigationWindow = 1,
            QuickAccessToolbar = 2,
            BubbleBar = 3
        }




        public static void ClearNotificationAlert()
        {
            ClearNotificationAlertEvent?.Invoke();
        }
        public static void ShowMessage(string Message)
        {
            ShowMessageEvent?.Invoke(Message);
        }
        public static AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults ShowMessageBox(string Message, AdvantageFramework.Core.WinForm.MessageBox.Methods.MessageBoxButtons MessageBoxButtons = AdvantageFramework.Core.WinForm.MessageBox.Methods.MessageBoxButtons.OK, string Title = "")
        {

            // objects
            AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults DialogResult = AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults.OK;

            ShowMessageBoxEvent?.Invoke(Message, MessageBoxButtons, Title, ref DialogResult);

            return DialogResult;
        }
        //public static AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults ShowLogin(AdvantageFramework.Security.Application Application, ref AdvantageFramework.Database.DbContext DbContext, ref AdvantageFramework.Security.Session Session, string ServerName, string DatabaseName, bool UseWindowsAuthentication, string UserName, bool UpperCaseDatabaseAndUserName)
        //{

        //    // objects
        //    AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults DialogResult = AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults.OK;

        //    ShowLoginEvent?.Invoke(Application, ref DbContext, ref Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, UpperCaseDatabaseAndUserName, ref DialogResult);

        //    return DialogResult;
        //}
        public static AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults ShowChangePassword(string ConnectionString, string UserName, ref string Password)
        {

            // objects
            AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults DialogResult = AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults.OK;

            ShowChangePasswordEvent?.Invoke(ConnectionString, UserName, ref Password, ref DialogResult);

            return DialogResult;
        }
        public static AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults ShowChangePasswordWithMessage(string ConnectionString, string UserName, ref string Password, string Message)
        {

            // objects
            AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults DialogResult = AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults.OK;

            ShowChangePasswordWithMessageEvent?.Invoke(ConnectionString, UserName, ref Password, Message, ref DialogResult);

            return DialogResult;
        }
        //public static AdvantageFramework.WinForm.MessageBox.DialogResults ShowReportViewer(AdvantageFramework.Security.Session Session, AdvantageFramework.Reporting.ReportTypes Report, Generic.Dictionary<string, object> ParameterDictionary, int Criteria, string FilterString, DateTime From, DateTime To)
        //{

        //    // objects
        //    AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults DialogResult = AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults.OK;

        //    ShowReportViewerEvent?.Invoke(Session, Report, ParameterDictionary, Criteria, FilterString, From, To, ref DialogResult);

        //    return DialogResult;
        //}
        public static AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults ShowError(Exception Exception)
        {

            // objects
            AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults DialogResult = AdvantageFramework.Core.WinForm.MessageBox.Methods.DialogResults.OK;

            ShowErrorEvent?.Invoke(Exception, ref DialogResult);

            return DialogResult;
        }
    }
}
