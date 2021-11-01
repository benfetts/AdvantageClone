using AdvantageFramework.Core.Database.Entities;
using AdvantageFramework.Core.Web;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.BLogic.Proofing
{
    public enum ProofingStatusID
    {
        Approved = 1,
        Reject,
        Defer
    }

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
        static public string GetExternalReviewerHeaderText(string ConnectionString, int ProofingExternalReviewerID, int AlertID, int DocumentID)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            using (var DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
            {
                AdvantageFramework.Core.Database.Entities.ProofingExternal reviewer = null;
                AdvantageFramework.Core.Database.Entities.Alert alert = null;
                AdvantageFramework.Core.Database.Entities.Document document = null;
                AdvantageFramework.Core.Database.Entities.JobComponent jobComponent = null;
                string helpURL = "";
                reviewer = AdvantageFramework.Core.Database.Procedures.ProofingExternal.LoadByProofingExternalReviewerID(DbContext, ProofingExternalReviewerID);
                if (reviewer == null)
                {
                    alert = AdvantageFramework.Core.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID);
                    if (alert != null)
                    {
                        document = AdvantageFramework.Core.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID);
                        if (document != null)
                        {
                            jobComponent = AdvantageFramework.Core.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, (int)alert.JobNumber, (short)alert.JobComponentNbr);
                            if (jobComponent != null)
                            {
                                sb.AppendFormat("Hello {0},", reviewer.Name);
                                sb.Append("<br/>");
                                sb.Append("<br/>");
                                sb.Append("Your feedback would be greatly appreciated for:");
                                sb.Append("<br/>");
                                sb.AppendFormat("Document:  {0}", document.Filename);
                                sb.Append("<br/>");
                                sb.AppendFormat("For job:  {0}", jobComponent.JobCompDesc);
                                sb.Append("<br/>");
                                sb.Append("<br/>");
                                sb.AppendFormat("If you need help, try this <a href='{0}' target='_blank'>link</a>.", helpURL);
                                sb.Append("<br/>");
                                sb.Append("<br/>");
                                sb.Append("<br/>");
                                sb.Append("Thank you!");
                            }
                        }
                    }
                }
            }
            return sb.ToString();
        }
        static public string GetProofingURL(AdvantageFramework.Core.Web.QueryString qs, int AlertID, int DocumentID, ref string ErrorMessage)
        {
            string URL;

            AdvantageFramework.Core.Web.QueryString QueryString = new AdvantageFramework.Core.Web.QueryString(qs.ConnectionString, qs.UserCode, "");

            QueryString.Page = "Proofing";
            QueryString.AlertID = AlertID;
            QueryString.DocumentID = DocumentID;

            URL = QueryString.ToString();

            return URL;
        }
        static public List<Approval> GetApprovalsList(string ConnectionString, int AlertId,int? DocumentId )
        {
            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
                {
                    return GetApprovalsListAsync(DbContext,AlertId, DocumentId).Result.ToList();
                }
            }

            return null;
        }
        static public async System.Threading.Tasks.Task<List<Approval>> GetApprovalsListAsync(
            AdvantageFramework.Core.Database.DbContext DbContext, int AlertId, int? DocumentId)
        {
            var parameters = new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = AlertId },
                    new Microsoft.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = System.DBNull.Value}
            };

            try
            {

                return await DbContext.Approvals.FromSqlRaw(
                    "EXEC [dbo].[advsp_proofing_get_approvals_list] @ALERT_ID, @DOCUMENT_ID;",
                    parameters).AsAsyncEnumerable().ToListAsync();

            }catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                return null;
            }


        }
        static public async System.Threading.Tasks.Task<Database.Entities.CompleteAssignmentResult> CompleteAssignment(
            string ConnectionString, int AlertId, string EmployeeCode, string UserCode, int DocumentID,ProofingStatusID? ProofingStatusID)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
                {
                    return await CompleteAssignment(DbContext, AlertId, EmployeeCode, UserCode, DocumentID, ProofingStatusID);
                }
            }

            return null;
        }
        static public async System.Threading.Tasks.Task<Database.Entities.CompleteAssignmentResult> CompleteAssignment(
            AdvantageFramework.Core.Database.DbContext DbContext, int AlertId,
            string EmployeeCode, string UserCode,int DocumentID, ProofingStatusID? ProofingStatusID)
        {
            AdvantageFramework.Core.Database.Entities.CompleteAssignmentResult Result = default;
            bool Completed = false;
            string ErrorMessage = string.Empty;
            try
            {
                var parameters = new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = AlertId },
                    new Microsoft.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar,100) { Direction = ParameterDirection.Input, Value = UserCode },
                    new Microsoft.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6) { Direction = ParameterDirection.Input, Value = EmployeeCode },
                    new Microsoft.Data.SqlClient.SqlParameter("@PROOFING_STATUS_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = ProofingStatusID},
                    new Microsoft.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DocumentID}
                };

                Result = await DbContext.CompleteAssignmentResult.FromSqlRaw(
                    "EXEC [dbo].[advsp_alert_complete_assignment] @ALERT_ID, @USER_CODE, @EMP_CODE, @PROOFING_STATUS_ID, @DOCUMENT_ID;",
                    parameters).AsAsyncEnumerable().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ErrorMessage, System.Diagnostics.EventLogEntryType.Error);
                Completed = false;
            }

            if (Result is null)
            {
                Result = new AdvantageFramework.Core.Database.Entities.CompleteAssignmentResult();
                Result.Success = Completed;
                Result.Message = ErrorMessage;
            }

            return Result;
        }
        static public bool ExternalUserCompleteAssignment(
            string ConnectionString, int AlertId, int ProofingStatusExternalReviewerID, int DocumentID, ProofingStatusID? ProofingStatusID)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
                {
                    return ExternalUserCompleteAssignment(DbContext, AlertId, ProofingStatusExternalReviewerID, DocumentID, ProofingStatusID);
                }
            }

            return false;
        }
        static public bool ExternalUserCompleteAssignment(
            AdvantageFramework.Core.Database.DbContext DbContext, int AlertId,
            int ProofingStatusExternalReviewerID, int DocumentID, ProofingStatusID? ProofingStatusID)
        {
            bool Completed = false;
            string ErrorMessage = string.Empty;
            try
            {
                DbContext.ExecuteNonQuery( string.Format("EXEC [dbo].[advsp_proofing_external_reviewer_set_status] {0}, {1}, {2}, {3};",
                    AlertId, ProofingStatusExternalReviewerID, (int)ProofingStatusID, DocumentID));

                Completed = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                Completed = false;
            }

            return Completed;
        }
        static public bool GetDocument(AdvantageFramework.Core.Web.QueryString QueryString, ref byte[] ByteFile,ref string FileName ,ref string ErrorMessage)
        {
            int DocumentID = QueryString.DocumentID;

            return GetDocument(QueryString, DocumentID, ref ByteFile, ref FileName, ref ErrorMessage);
        }
        static public bool GetDocument(AdvantageFramework.Core.Web.QueryString queryString,int DocumentID, ref byte[] ByteFile, ref string FileName, ref string ErrorMessage)
        {
            bool Success = false;
            string ConnectionString = queryString.ConnectionString;
            AdvantageFramework.Core.Database.Entities.Document Document = null;
            AdvantageFramework.Core.Database.Entities.Agency Agency = null;
            bool FileExists = false;

            ByteFile = null;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(queryString.ConnectionString))
                {
                    
                    Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
                    Document = AdvantageFramework.Core.Database.Procedures.Documents.LoadByDocumentID(DbContext, DocumentID);

                    if (Agency != null && Document != null)
                    {
                        FileName = Document.Filename;

                        if (AdvantageFramework.Core.FileSystem.Methods.Download(Agency, Document, ref ByteFile, ref FileExists))
                        {
                            if (ByteFile != null)
                                Success = true;
                        }
                    }
                }
            }

            return Success;
        }
        public static AlertComment CreateComment(QueryString qs, AlertComment alertComment)
        {
            int DocumentID = qs.DocumentID;
            int AlertID = qs.AlertID;
            string ConnectionString = qs.ConnectionString;
            AdvantageFramework.Core.Database.Entities.AlertComment rv = null;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString))
                {
                    //if (alertComment.ParentId != null) {
                    //    var parent = (from comment in DbContext.AlertComments.AsQueryable() where comment.CommentId == alertComment.ParentId select comment).SingleOrDefault();

                    //    if(parent.DocumentId == null)
                    //    {
                    //        alertComment.DocumentId = null;
                    //    }
                    //}


                    rv = AdvantageFramework.Core.AlertSystem.Methods.AddAlertComment(DbContext, AlertID, alertComment.ParentId, alertComment.Comment, null, "", alertComment.UserCode, alertComment.DocumentId, alertComment.ProofingXReviwerId);

                    //rv = AdvantageFramework.Core.Database.Procedures.AlertComments.CreateComment(DbContext, alertComment);
                }
            }

            return rv;
        }
        public static AlertComment UpdateComment(QueryString qs, AlertComment alertComment)
        {
            int DocumentID = qs.DocumentID;
            int AlertID = qs.AlertID;
            string ConnectionString = qs.ConnectionString;
            AdvantageFramework.Core.Database.Entities.AlertComment rv = null;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString))
                {
                    rv = AdvantageFramework.Core.Database.Procedures.AlertComments.UpdateComment(DbContext, AlertID, DocumentID, alertComment);
                }
            }

            return rv;
        }
        static public bool GetDocumentName(AdvantageFramework.Core.Web.QueryString QueryString, ref string FileName, ref string ErrorMessage)
        {
            return GetDocumentName(QueryString, QueryString.DocumentID, ref FileName, ref ErrorMessage);
        }
        public static int GetDocumentVersion(QueryString qs, int DocumentID)
        {
            int version = -1;

            if (string.IsNullOrWhiteSpace(qs.ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString))
                {

                    version = DbContext.SqlQueryInt(@"select COUNT(DOCUMENTS.DOCUMENT_ID) from DOCUMENTS 
                                JOIN ALERT_ATTACHMENT on ALERT_ATTACHMENT.DOCUMENT_ID = DOCUMENTS.DOCUMENT_ID
                                 WHERE FILENAME = (select FILENAME from DOCUMENTS WHERE DOCUMENT_ID = " + DocumentID + @") 
                                        AND UPLOADED_DATE <= (select UPLOADED_DATE from DOCUMENTS WHERE DOCUMENT_ID = " + DocumentID + @") 
                                        AND ALERT_ID = (select ALERT_ID from ALERT_ATTACHMENT WHERE DOCUMENT_ID = " + DocumentID + @")
                                ");
                }
            }

            return version;

        }
        static public bool GetDocumentName(AdvantageFramework.Core.Web.QueryString QueryString,int DocumentID, ref string FileName, ref string ErrorMessage)
        {
            bool Success = false;
            string ConnectionString = QueryString.ConnectionString;
            AdvantageFramework.Core.Database.Entities.Document Document = null;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                {
                    Document = AdvantageFramework.Core.Database.Procedures.Documents.LoadByDocumentID(DbContext, DocumentID);

                    if (Document != null)
                    {
                        Success = true;
                        FileName = Document.Filename;
                    }
                }
            }

            return Success;
        }
        public static ProofingMarkup[] GetAnnotations(QueryString qs, int id)
        {
            Database.Entities.ProofingMarkup[] xfdfData = null;
            int DocumentID = id;
            int AlertID = qs.AlertID;
            string ConnectionString = qs.ConnectionString;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString))
                {
                    IQueryable<Database.Entities.ProofingMarkup> pm = Database.Procedures.ProofingMarkup.LoadMarkup(DbContext, AlertID, DocumentID);

                    xfdfData = pm.ToArray();
                }
            }

            return xfdfData;
        }
        static public Database.Entities.ProofingMarkup [] GetAnnotations(AdvantageFramework.Core.Web.QueryString QueryString)
        {
            int DocumentID = QueryString.DocumentID;

            return GetAnnotations(QueryString, DocumentID);
        }
        public static AdvantageFramework.Core.Database.Entities.ProofingMarkup[] CreateAnnotations(QueryString QueryString, AdvantageFramework.Core.Database.Entities.ProofingMarkup [] annotations)
        {
            List<AdvantageFramework.Core.Database.Entities.ProofingMarkup> newMarkups = new List<ProofingMarkup>();

            if (string.IsNullOrWhiteSpace(QueryString.ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                {
                    //create the comment for all of the markups
                    AdvantageFramework.Core.Database.Entities.AlertComment comment = DbContext.AlertComments.Add(
                        new AdvantageFramework.Core.Database.Entities.AlertComment() {
                            Comment = annotations[0].Markup,
                            AlertId = QueryString.AlertID,
                            UserCode = QueryString.ProofingStatusExternalReviewerID <= 0 ? QueryString.UserCode : null,
                            GeneratedDate = annotations[0].Generated,
                            DocumentId = annotations[0].DocumentId,
                            ProofingXReviwerId = QueryString.ProofingStatusExternalReviewerID <= 0 ? (int?)null : QueryString.ProofingStatusExternalReviewerID
                        }).Entity;
                    DbContext.SaveChanges();

                    //give all the markups the same seqnbr
                    short SeqNbr = DbContext.ProofingMarkups.AsQueryable().Where(m => m.DocumentId == annotations[0].DocumentId).Select(m => m.SeqNbr).Max() ?? 0;
                    SeqNbr += 1;
                    foreach (AdvantageFramework.Core.Database.Entities.ProofingMarkup value in annotations)
                    {
                        value.CommentId = comment.CommentId;
                        value.SeqNbr = SeqNbr;
                        var newAnnot = AdvantageFramework.Core.Database.Procedures.ProofingMarkup.CreateMarkup(DbContext, QueryString.AlertID, value);
                        newMarkups.Add(newAnnot);
                    }
                }
            }

            return newMarkups.ToArray();
        }
        public static AdvantageFramework.Core.Database.Entities.AlertComment CreateAlertComment(QueryString QueryString, string comment)
        {
            return CreateAlertComment(QueryString, comment, QueryString.DocumentID);
        }
        public static AdvantageFramework.Core.Database.Entities.AlertComment CreateAlertComment(QueryString QueryString, string comment,int DocumentId)
        {
            if (string.IsNullOrWhiteSpace(QueryString.ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                {
                    AdvantageFramework.Core.Database.Entities.AlertComment _comment = DbContext.AlertComments.Add(
                        new AdvantageFramework.Core.Database.Entities.AlertComment()
                        {
                            Comment = comment,
                            AlertId = QueryString.AlertID,
                            UserCode = QueryString.ProofingStatusExternalReviewerID <= 0 ? QueryString.UserCode : null,
                            GeneratedDate = DateTime.Now,
                            DocumentId = DocumentId,
                            ProofingXReviwerId = QueryString.ProofingStatusExternalReviewerID <= 0 ? (int?)null : QueryString.ProofingStatusExternalReviewerID
                        }).Entity;
                    DbContext.SaveChanges();

                    return _comment;

                }
            }

            return null;
        }
        //public static AdvantageFramework.Core.Database.Entities.ProofingMarkup CreateAnnotation(QueryString QueryString, AdvantageFramework.Core.Database.Entities.ProofingMarkup value)
        //{
        //    int AlertID = QueryString.AlertID;
        //    string ConnectionString = QueryString.ConnectionString;
        //    AdvantageFramework.Core.Database.Entities.ProofingMarkup rv = null;
        //    System.Diagnostics.Debug.Write(QueryString.UserCode);
        //    value.EmpCode = QueryString.EmployeeCode;

        //    if (string.IsNullOrWhiteSpace(ConnectionString) == false)
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
        //        {
        //            rv = AdvantageFramework.Core.Database.Procedures.ProofingMarkup.CreateMarkup(DbContext, AlertID, value);
        //        }
        //    }

        //    return rv;
        //}
        public static AdvantageFramework.Core.Database.Entities.ProofingMarkup UpdateAnnotation(QueryString QueryString,int id,AdvantageFramework.Core.Database.Entities.ProofingMarkup value)
        {
            string ConnectionString = QueryString.ConnectionString;
            AdvantageFramework.Core.Database.Entities.ProofingMarkup rv = null;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                {
                    rv = AdvantageFramework.Core.Database.Procedures.ProofingMarkup.UpdateMarkup(DbContext, id, QueryString.AlertID, value);
                }
            }

            return rv;
        }
        public static void DeleteAnnotation(QueryString QueryString, int id)
        {
            string ConnectionString = QueryString.ConnectionString;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                {
                    AdvantageFramework.Core.Database.Procedures.ProofingMarkup.DeleteMarkup(DbContext, id);
                }
            }
        }
        public static IEnumerable<Document> GetDocumentHistory(QueryString QueryString)
        {
            return GetDocumentHistory(QueryString, QueryString.DocumentID);
        }
        public static IEnumerable<Document> GetDocumentHistory(QueryString QueryString, int DocumentID)
        {
            IEnumerable<Document> rv = null;
            string ConnectionString = QueryString.ConnectionString;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                {
                    rv = AdvantageFramework.Core.Database.Procedures.Documents.GetHistory(DbContext, DocumentID, QueryString.AlertID);
                }

                foreach (Document doc in rv)
                {
                    if (doc.Thumbnail == null)
                    {
                        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                        {
                            doc.Thumbnail = AdvantageFramework.Core.Database.Procedures.Documents.GetDocumentThumbnail(DbContext, doc.DocumentId);
                        }
                    }
                }
            }

            return rv;
        }
        public static IEnumerable<Document> GetAlertDocuments(QueryString QueryString)
        {
            IEnumerable<Document> rv = null;
            string ConnectionString = QueryString.ConnectionString;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                {
                    rv = AdvantageFramework.Core.Database.Procedures.Documents.GetAlertDocuments(DbContext, QueryString.AlertID);
                }

                foreach (Document doc in rv)
                {
                    if (doc.Thumbnail == null)
                    {
                        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                        {
                            doc.Thumbnail = AdvantageFramework.Core.Database.Procedures.Documents.GetDocumentThumbnail(DbContext, doc.DocumentId);
                        }
                    }
                }
            }

            return rv;
        }
        public static Document getDocumentInfo(QueryString QueryString)
        {
            Document document = null;

            return getDocumentInfo(QueryString, QueryString.DocumentID);
        }

        public static Document getDocumentInfo(QueryString QueryString,int DocumentID)
        {
            Document document = null;

            if (string.IsNullOrWhiteSpace(QueryString.ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                {
                    document = AdvantageFramework.Core.Database.Procedures.Documents.LoadByDocumentID(DbContext, DocumentID);
                }

                if (document != null)
                {
                    if (document.Thumbnail == null)
                    {
                        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(QueryString.ConnectionString))
                        {
                            document.Thumbnail = AdvantageFramework.Core.Database.Procedures.Documents.GetDocumentThumbnail(DbContext, document.DocumentId);
                        }
                    }
                }
            }

            if (document == null)
            {
                document = new Document();
                document.Description = "Error getting document";
                document.Filename = "Error getting document";
                document.DocumentId = -1;
            }

            return document;
        }
        public static AdvantageFramework.Core.Database.Classes.AlertComment[] GetAlertComents(QueryString qs, int id)
        {
            AdvantageFramework.Core.Database.Classes.AlertComment[] rv = null;
            string ConnectionString = qs.ConnectionString;

            if (string.IsNullOrWhiteSpace(ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
                {
                    rv = AdvantageFramework.Core.Database.Procedures.AlertComments.GetAlertComments(DbContext, id, qs.AlertID,qs.EmployeeCode).ToArray();
                }
            }

            return rv;
        }
        public static AdvantageFramework.Core.Database.Classes.AlertComment[] GetAlertComents(QueryString qs)
        {
            return GetAlertComents(qs, qs.DocumentID);
        }
        public static Database.Classes.AssetInfo GetAssetInfo(QueryString qs)
        {
            return GetAssetInfo(qs, qs.DocumentID);
        }        

        //  GENERIC FUNCTION TEST...Don't do this.  Need to get the generic one working!!!
        public static Database.Classes.AssetInfo GetAssetInfo(QueryString qs, int DocumentId)   
        {
            Database.Classes.AssetInfo assetInfo = null;
            List<Database.Classes.AssetInfo> versions = new List<Database.Classes.AssetInfo>();
            try
            {
                using (SqlConnection con = new SqlConnection(qs.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(String.Format("EXEC [dbo].[advsp_proofing_get_asset_info]  {0}, NULL;", qs.AlertID), con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                try
                                {
                                    versions.Add(new Database.Classes.AssetInfo
                                    {
                                        DocumentId = Convert.ToInt32(sdr["DocumentId"]),
                                        FileName = sdr["FileName"].ToString(),
                                        Description = sdr["Description"] != System.DBNull.Value ? sdr["Description"].ToString() : String.Empty,
                                        Version = sdr["Version"] != System.DBNull.Value ? Convert.ToInt32(sdr["Version"]) : 1,
                                        UploadDate = Convert.ToDateTime(sdr["UploadDate"]),
                                        UserCode = sdr["UserCode"] != System.DBNull.Value ? sdr["UserCode"].ToString() : String.Empty,
                                        UserFullName = sdr["UserFullName"] != System.DBNull.Value ? sdr["UserFullName"].ToString() : String.Empty,
                                        MimeType = sdr["MimeType"] != System.DBNull.Value ? sdr["MimeType"].ToString() : String.Empty,
                                        FileSize = sdr["FileSize"] != System.DBNull.Value ? Convert.ToInt32(sdr["FileSize"]) : 0,
                                        Thumbnail = sdr["Thumbnail"] != System.DBNull.Value ? Encoding.ASCII.GetBytes(sdr["Thumbnail"].ToString()) : null,
                                        IsLatestDocument = sdr["IsLatestDocument"] != System.DBNull.Value ? Convert.ToBoolean(sdr["IsLatestDocument"]) : false,
                                        TotalApproves = sdr["TotalApproves"] != System.DBNull.Value ? Convert.ToInt32(sdr["TotalApproves"]) : 0,
                                        TotalRejects = sdr["TotalRejects"] != System.DBNull.Value ? Convert.ToInt32(sdr["TotalRejects"]) : 0,
                                        TotalDefers = sdr["TotalDefers"] != System.DBNull.Value ? Convert.ToInt32(sdr["TotalDefers"]) : 0,
                                        TotalMarkups = sdr["TotalMarkups"] != System.DBNull.Value ? Convert.ToInt32(sdr["TotalMarkups"]) : 0,
                                        TotalVersions = sdr["TotalVersions"] != System.DBNull.Value ? Convert.ToInt32(sdr["TotalVersions"]) : 1,
                                        TotalVersionsForAlertID = sdr["TotalVersionsForAlertID"] != System.DBNull.Value ? Convert.ToInt32(sdr["TotalVersionsForAlertID"]) : 1,
                                        LatestMarkupFullName = sdr["LatestMarkupFullName"] != System.DBNull.Value ? sdr["LatestMarkupFullName"].ToString() : String.Empty,
                                        LatestMarkupDate = sdr["LatestMarkupDate"] != System.DBNull.Value ? Convert.ToDateTime(sdr["LatestMarkupDate"]) : null
                                    });
                                } catch (Exception ex)
                                {
                                    AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                versions = null;
            }
            if (versions != null)
            {
                assetInfo = (from Entity in versions
                                where Entity.DocumentId == DocumentId
                                select Entity).SingleOrDefault();
            }
            if (assetInfo != null)
            {
                assetInfo.Versions = (from Entity in versions
                                        where Entity.FileName == assetInfo.FileName
                                        select Entity).AsEnumerable().ToList();
            }
            return assetInfo;
        }

        ////  GENERIC FUNCTION TEST (NOT WORKING!)
        //public static Database.Classes.AssetInfo GetAssetInfo(QueryString qs, int DocumentId)
        //{
        //    Database.Classes.AssetInfo assetInfo = null;
        //    List<Database.Classes.AssetInfo> versions = null;

        //    try
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString))
        //        {

        //            versions = DbContext.ExecuteObject<Database.Classes.AssetInfo>(String.Format("EXEC [dbo].[advsp_proofing_get_asset_info]  {0}, {1};", qs.AlertID, DocumentId), false).ToArray().ToList();

        //            if (versions != null)
        //            {
        //                assetInfo = (from Entity in versions
        //                             where Entity.DocumentId == DocumentId
        //                             select Entity).SingleOrDefault();
        //            }

        //            if (assetInfo != null)
        //            {
        //                assetInfo.Versions = (from Entity in versions
        //                                      where Entity.FileName == assetInfo.FileName
        //                                      select Entity).AsEnumerable().ToList();
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
        //    }

        //    return assetInfo;

        //}

        ////  ORIGINAL (USING ENTITIES)
        //public static Database.Classes.AssetInfo GetAssetInfo(QueryString qs, int DocumentID)
        //{
        //    Database.Classes.AssetInfo rv = null;

        //    if (string.IsNullOrWhiteSpace(qs.ConnectionString) == false)
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString))
        //        {
        //            rv = (from Document in DbContext.Documents.AsQueryable()
        //                  where Document.DocumentId == DocumentID
        //                  select new Database.Classes.AssetInfo()
        //                  {
        //                      Description = Document.Description,
        //                      DocumentId = Document.DocumentId,
        //                      UploadDate = Document.UploadedDate,
        //                      UserCode = Document.UserCode,
        //                      FileName = Document.Filename,
        //                      FileSize = Document.FileSize,
        //                      MimeType = Document.MimeType,
        //                      Version = 1,
        //                      Thumbnail = Document.Thumbnail,
        //                      Tags = !string.IsNullOrEmpty(Document.Keywords) ? Document.Keywords.Split(' ', StringSplitOptions.None).ToList() : null
        //                  }
        //                  ).FirstOrDefault();

        //            rv.Versions = (from Document in DbContext.Documents.AsQueryable()
        //                           join a in DbContext.AlertAttachments on new { ID = Document.DocumentId, AlertId = qs.AlertID } equals new { ID = a.DocumentId, AlertId = a.AlertId }
        //                           where Document.Filename == rv.FileName
        //                           orderby Document.UploadedDate
        //                           select new Database.Classes.AssetInfo()
        //                           {
        //                               Description = Document.Description,
        //                               DocumentId = Document.DocumentId,
        //                               UploadDate = Document.UploadedDate,
        //                               UserCode = Document.UserCode,
        //                               FileName = Document.Filename,
        //                               FileSize = Document.FileSize,
        //                               MimeType = Document.MimeType,
        //                               Thumbnail = Document.Thumbnail
        //                               //    Tags = !string.IsNullOrEmpty(Document.Keywords) ? Document.Keywords.Split(' ', StringSplitOptions.None).ToList() : null
        //                           }).ToList();

        //            for (int i = 0; i < rv.Versions.Count; i++)
        //            {
        //                rv.Versions[i].Version = i + 1;

        //                if (rv.Versions[i].UploadDate == rv.UploadDate)
        //                {
        //                    rv.Version = rv.Versions[i].Version;
        //                }

        //                if (rv.Versions[i].Thumbnail == null)
        //                {
        //                    rv.Versions[i].Thumbnail = Database.Procedures.Documents.GetDocumentThumbnail(DbContext, rv.Versions[i].DocumentId);
        //                }
        //            }
        //        }
        //    }

        //    return rv;

        //}
        public static bool IsCurrentVersion(QueryString qs, int DocumentId)
        {
            using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString))
            {
                return IsCurrentVersion(DbContext, qs.AlertID, DocumentId);
            }
        }
        public static bool IsCurrentVersion(AdvantageFramework.Core.Database.DbContext DbContext,int AlertId, int DocumentId)
        {
            IEnumerable<Document> versions = AdvantageFramework.Core.Database.Procedures.Documents.GetHistory(DbContext, DocumentId,AlertId);

            if (versions.Count() > 0)
            {
                return versions.Last().DocumentId == DocumentId;
            }

            return false;
        }
        public static Document GetCurrentVersion(QueryString qs, int AlertId, int DocumentId)
        {
            using (var DbContext = new AdvantageFramework.Core.Database.DbContext(qs.ConnectionString))
            {
                return GetCurrentVersion(DbContext, qs.AlertID, DocumentId);
            }
        }
        public static Document GetCurrentVersion(AdvantageFramework.Core.Database.DbContext DbContext, int AlertId, int DocumentId)
        {

            return AdvantageFramework.Core.Database.Procedures.Documents.GetLatestVersion(DbContext, DocumentId, AlertId);
        }

        #endregion

    }
}
