using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.Database.Procedures
{
    public class AlertAttachment
    {
        public static Entities.AlertAttachment LoadByAlertIDAndDocumentID(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, int DocumentID)
        {
            AdvantageFramework.Core.Database.Entities.AlertAttachment rv;
            try
            {
                rv = (from AlertAttachment in DbContext.AlertAttachments.AsQueryable()
                      where AlertAttachment.AlertId == AlertID && AlertAttachment.DocumentId == DocumentID
                      select AlertAttachment).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }
            return rv;
        }
        public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, 
            AdvantageFramework.Core.Database.Entities.AlertAttachment alertAttachment)
        {
            bool UpdateRet = default;

            // objects
            bool Updated = false;
            bool IsValid = true;
            string ErrorText = "";
            try
            {
                DbContext.Update(alertAttachment);
                //ErrorText = alertAttachment.ValidateEntity(IsValid);
                if (IsValid)
                {
                    DbContext.SaveChanges();
                    Updated = true;
                }
                else
                {
                    //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
                }
            }
            catch (Exception ex)
            {
                Updated = false;
            }
            finally
            {
                UpdateRet = Updated;
            }

            return UpdateRet;
        }
    }

}
