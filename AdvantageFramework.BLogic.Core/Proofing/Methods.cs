using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.BLogic.Proofing
{
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
        //static public string GetProofingURL(AdvantageFramework.Core.Security.Session SecuritySession, int AlertID, int DocumentID, ref string ErrorMessage)
        //{
        //    string URL;
        //    AdvantageFramework.Core.Web.QueryString QueryString = new AdvantageFramework.Core.Web.QueryString(SecuritySession);

        //    QueryString.Page = "Proofing"; // Fake, can name it whatever is appropriate for the ng/c# app
        //    QueryString.AlertID = AlertID;
        //    QueryString.DocumentID = DocumentID;

        //    URL = QueryString.ToString();

        //    return URL;
        //}
        static public bool GetDocument(AdvantageFramework.Core.Web.QueryString QueryString, ref byte[] ByteFile, ref string ErrorMessage)
        {
            bool Success = false;
            string ConnectionString = QueryString.ConnectionString;
            string UserCode = QueryString.UserCode;
            int AlertID = QueryString.AlertID;
            int DocumentID = QueryString.DocumentID;
            AdvantageFramework.Core.Database.Entities.Documents Document = null;
            AdvantageFramework.Core.Database.Entities.Agency Agency = null;
            bool FileExists = false;

            ByteFile = null;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                {
                    Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                    Document = AdvantageFramework.Core.Database.Procedures.Documents.LoadByDocumentID(DbContext, DocumentID);

                    if (Agency != null && Document != null)
                    {
                        if (AdvantageFramework.Core.FileSystem.Methods.Download(Agency, Document,ref ByteFile, ref FileExists))
                        {
                            if (ByteFile != null)
                                Success = true;
                        }
                    }
                }
            }

            return Success;
        }
        #endregion

    }
}
