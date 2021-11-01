using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.BLogic.AlertSystem
{
    class Methods
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

        public static System.Collections.Generic.List<AdvantageFramework.Core.AlertSystem.Classes.AlertComment> LoadAlertComments(string ConnectionString,
            int AlertID, 
            string EmployeeCode,
            bool HideSystemComments, 
            double Offset = 0, 
            bool IsClientPortal = false)
        {

            System.Collections.Generic.List<AdvantageFramework.Core.AlertSystem.Classes.AlertComment> AllComments = null;
            System.Collections.Generic.List<AdvantageFramework.Core.AlertSystem.Classes.AlertComment> AlertComments = null;
            System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
            System.Data.SqlClient.SqlParameter EmployeeCodeSqlParameter = null;
            System.Data.SqlClient.SqlParameter OffsetSqlParameter = null;
            System.Data.SqlClient.SqlParameter HideSystemCommentsSqlParameter = null;

            AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("AlertID", AlertID);
            HideSystemCommentsSqlParameter = new System.Data.SqlClient.SqlParameter("HideSystemComments", HideSystemComments);

            using (var DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
            {
                if (IsClientPortal == true)
                {
                    EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("EmployeeCode", "");
                    Offset = AdvantageFramework.Core.Database.Procedures.EmployeeCultureAndTimezone.LoadTimeZoneOffsetForEmployee(DbContext, string.Empty);
                }
                else
                {
                    EmployeeCodeSqlParameter = new System.Data.SqlClient.SqlParameter("EmployeeCode", EmployeeCode);
                    Offset = AdvantageFramework.Core.Database.Procedures.EmployeeCultureAndTimezone.LoadTimeZoneOffsetForEmployee(DbContext, EmployeeCode);
                }
                try
                {

                    OffsetSqlParameter = new System.Data.SqlClient.SqlParameter("Offset", Offset);

                    AllComments = DbContext.ComplexAlertComments
                                    .FromSqlRaw("EXEC [dbo].[advsp_alert_load_comments] @AlertID, @EmployeeCode, @Offset, @HideSystemComments;", 
                                                AlertIDSqlParameter, 
                                                EmployeeCodeSqlParameter, 
                                                OffsetSqlParameter, 
                                                HideSystemCommentsSqlParameter)
                                    .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    AllComments = null;
                }
            }
            if (AllComments != null)
            {
                AlertComments = (from Entity in AllComments
                                 where Entity.ParentID == 0
                                 select Entity).ToList();

                if (AlertComments != null)
                {
                    ////  TODO:
                    //foreach (AdvantageFramework.Core.AlertSystem.Classes.AlertComment Comment in AlertComments)
                    //    HasChildren = FindAndAddChildren(ref Comment, AllComments);
                }
            }
            return AlertComments;
        }
        private bool FindAndAddChildren(ref AdvantageFramework.Core.AlertSystem.Classes.AlertComment Parent, 
            System.Collections.Generic.List<AdvantageFramework.Core.AlertSystem.Classes.AlertComment> AllComments)
        {
            bool HasChildren = false;
            int CommentID = Parent.CommentID;

            System.Collections.Generic.List<AdvantageFramework.Core.AlertSystem.Classes.AlertComment> Children = null;

            try
            {
                Children = (from Entity in AllComments
                            where Entity.ParentID == CommentID
                            select Entity).ToList();

                if (Children != null && Children.Count > 0)
                {
                    HasChildren = true;

                    if (Parent.Replies == null)
                        Parent.Replies = new List<AdvantageFramework.Core.AlertSystem.Classes.AlertComment>();
                    foreach (AdvantageFramework.Core.AlertSystem.Classes.AlertComment Child in Children)
                    {
                        Parent.Replies.Add(Child);
                        //// TODO:
                        //FindAndAddChildren(ref Child, AllComments);
                    }
                }
            }
            catch (Exception)
            {
                HasChildren = false;
            }

            return HasChildren;
        }

        static public List<AdvantageFramework.Core.Database.Classes.AlertRecipient> LoadAlertRecipients(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        {

            // objects
            List<AdvantageFramework.Core.Database.Classes.AlertRecipient> AlertRecipients = null;
            System.Data.SqlClient.SqlParameter AlertIDSqlParameter = null;
            AlertIDSqlParameter = new System.Data.SqlClient.SqlParameter("AlertID", AlertID);
            try
            {
                //again we need to fix the parameters
                AlertRecipients = DbContext.AlertRecipient.FromSqlRaw("EXEC [dbo].[advsp_alert_recipient_get] " + AlertID).ToList(); ;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }

            return AlertRecipients;
        }


        #endregion

        #region Classes



        #endregion
    }
}
