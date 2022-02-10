using AdvantageFramework.Core.Database.Entities;
using AdvantageFramework.Core.Web;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AdvantageFramework.Core.BLogic.EmployeeMention{


    public class Methods
    {
        #region Constants



        #endregion

        #region Enum



        #endregion

        #region Variables



        #endregion

        #region  Properties



        #endregion
        #region Methods

        static public List<AdvantageFramework.Core.Database.Classes.EmployeeMention> GetEmployeesForMention(QueryString qs)
        {
            List<AdvantageFramework.Core.Database.Entities.AlertRecipientLookup> rv;
            List<AdvantageFramework.Core.Database.Classes.EmployeeMention> employeeMentions = new List<Database.Classes.EmployeeMention>();

            string ConnectionString = qs.ConnectionString;

            var parameters = new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar, 6) { Direction = ParameterDirection.Input, Value = qs.ClientCode },
                    new Microsoft.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6) { Direction = ParameterDirection.Input, Value = qs.DivisionCode },
                    new Microsoft.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6) { Direction = ParameterDirection.Input, Value = qs.ProductCode },
                    new Microsoft.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = qs.JobNumber},
                    new Microsoft.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt) { Direction = ParameterDirection.Input, Value = qs.JobComponentNumber},
                    new Microsoft.Data.SqlClient.SqlParameter("@CMP_IDENTIFIER", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = qs.CampaignIdentifier},
                    new Microsoft.Data.SqlClient.SqlParameter("@CLIENT_PORTAL_USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 0},
                    new Microsoft.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 0},
                    new Microsoft.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Input, Value = qs.UserCode },
                    new Microsoft.Data.SqlClient.SqlParameter("@IS_REVIEWERS", SqlDbType.Bit) { Direction = ParameterDirection.Input, Value = qs.ProofingStatusExternalReviewerID},
                    new Microsoft.Data.SqlClient.SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Input, Value = qs.EmailGroup }
            };

            try
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
                {
                    rv = (from alertRecipientLookup in DbContext.AlertRecipientLookup.FromSqlRaw("EXEC [dbo].[usp_wv_AutoCompleteRecipientsLoad] @CL_CODE, @DIV_CODE, @PRD_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @CMP_IDENTIFIER, @CLIENT_PORTAL_USER_ID, @ALERT_ID, @USER_CODE, @IS_REVIEWERS, @EMAIL_GR_CODE;", parameters).AsEnumerable()
                          select new AdvantageFramework.Core.Database.Entities.AlertRecipientLookup()
                          {
                              Code = alertRecipientLookup.Code,
                              FullName = alertRecipientLookup.FullName,
                              IsEmployee = alertRecipientLookup.IsEmployee,
                              IsClientContact = alertRecipientLookup.IsClientContact,
                              InAlertGroup = alertRecipientLookup.InAlertGroup,
                              ConceptShareUserID = alertRecipientLookup.ConceptShareUserID,
                              IsConceptShareUser = alertRecipientLookup.IsConceptShareUser,
                              Picture = alertRecipientLookup.Picture

                          }).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }


            if (rv.Count > 0)
            {
                foreach (AdvantageFramework.Core.Database.Entities.AlertRecipientLookup recipient in rv)
                {
                    employeeMentions.Add(new Database.Classes.EmployeeMention
                    {
                        EmployeeCode = recipient.Code,
                        EmployeeName = recipient.FullName
                    });
                }
            }


            return employeeMentions;
        }

        /*
         * Comment out below to get rid of build warning:
         *      Warning	CS1998	This async method lacks 'await' operators and will run synchronously. 
         *      Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.	
         *      Just uncomment when completed!
         */

        //static public async System.Threading.Tasks.Task<Boolean> AddEmployeeMentions(
        //                                AdvantageFramework.Core.Database.DbContext DbContext, string dl)
        //{            
        //    //var parameters = new[] {
        //    //        new Microsoft.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 0 },
        //    //        new Microsoft.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 0}
        //    //};

        //    //await DbContext.EmployeeMentions.FromSqlRaw(
        //    //    "EXEC [dbo].[advsp_proofing_get_approvals_list] @ALERT_ID, @DOCUMENT_ID;",
        //    //    parameters).AsAsyncEnumerable().ToListAsync();

        //    return true;
        //}

        //static public async System.Threading.Tasks.Task<Boolean> DeleteEmployeeMentions(
        //                        AdvantageFramework.Core.Database.DbContext DbContext, string dl)
        //{            
        //    //var parameters = new[] {
        //    //        new Microsoft.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 0 },
        //    //        new Microsoft.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 0}
        //    //};

        //    //await DbContext.EmployeeMentions.FromSqlRaw(
        //    //    "EXEC [dbo].[advsp_proofing_get_approvals_list] @ALERT_ID, @DOCUMENT_ID;",
        //    //    parameters).AsAsyncEnumerable().ToListAsync();

        //    return true;
        //}

        #endregion

    }
}
