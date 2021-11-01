using AdvantageFramework.Core.Database.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static class AlertComments
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
        public static IEnumerable<Classes.AlertComment> GetAlertComments(AdvantageFramework.Core.Database.DbContext dbContext, int documentID, int alertID,string EmployeeCode)
        {
            List<Classes.AlertComment> rv = null;

            try
            {
                var parameters = new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = alertID },
                    new Microsoft.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = documentID},
                    new Microsoft.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = EmployeeCode},
                    new Microsoft.Data.SqlClient.SqlParameter("@OFFSET", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 0},
                    new Microsoft.Data.SqlClient.SqlParameter("@HIDE_SYTEM_COMMENTS", SqlDbType.Bit) { Direction = ParameterDirection.Input, Value = 1}
                };


                rv = (from comment in dbContext.Comments.FromSqlRaw("EXEC [dbo].[advsp_alert_load_comments] @ALERT_ID, @DOCUMENT_ID, @EMP_CODE, @OFFSET, @HIDE_SYTEM_COMMENTS", parameters).AsEnumerable() where comment.ParentID == 0
                             select new Classes.AlertComment() { AlertId = comment.AlertID, CommentId = comment.CommentID ?? 0, DocumentId = comment.MarkupDocumentID ?? 0,
                                 AlertStateId = comment.AlertStateID,Comment = comment.LongComment, MarkupId = comment.MarkupID, EmployeeFullName = comment.EmployeeFullName, CustodyEnd = comment.CustodyEndDate,
                                 CustodyStart = comment.CustodyStartDate, GeneratedDate = comment.GeneratedDate, ParentId = comment.ParentID, UserCode = comment.UserCode, ProofingXReviwerId = comment.ProofingXReviwerId
                             }).OrderByDescending(foo => foo.GeneratedDate).ToList();


                var proofingMarkups = from ProofingMarkup in dbContext.ProofingMarkups.AsQueryable()
                                      where ProofingMarkup.DocumentId == documentID
                                      select ProofingMarkup;

                foreach (Classes.AlertComment alertComment in rv)
                {
                    var foo = from proofingMarkup in proofingMarkups where proofingMarkup.CommentId == alertComment.CommentId select new { proofingMarkup.Id, proofingMarkup.SeqNbr };
                    int? id = null;
                    short? seqNbr = null;
                    if (foo.Any())
                    {
                        //we are just going to use the info from the first markup for our refrence and sort out the rest on the other side.
                        id = foo.First().Id;
                        seqNbr = foo.First().SeqNbr;
                    }
                    alertComment.MarkupId = id;
                    alertComment.MarkupSeqNumber = seqNbr;
                    alertComment.Replies = LoadReplies(dbContext, alertComment, documentID, alertID, EmployeeCode);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }

            return rv;
        }

        private static List<Classes.AlertComment> LoadReplies(AdvantageFramework.Core.Database.DbContext dbContext, Classes.AlertComment comments, int documentID, int alertID, string EmployeeCode)
        {
            List<Classes.AlertComment> rc = null;

            var parameters = new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = alertID },
                    new Microsoft.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = documentID},
                    new Microsoft.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = EmployeeCode},
                    new Microsoft.Data.SqlClient.SqlParameter("@OFFSET", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 0},
                    new Microsoft.Data.SqlClient.SqlParameter("@HIDE_SYTEM_COMMENTS", SqlDbType.Bit) { Direction = ParameterDirection.Input, Value = 1}
                };

            rc = (from comment in dbContext.Comments.FromSqlRaw("EXEC [dbo].[advsp_alert_load_comments] @ALERT_ID, @DOCUMENT_ID, @EMP_CODE, @OFFSET, @HIDE_SYTEM_COMMENTS", parameters).AsEnumerable()
                  where comment.ParentID == comments.CommentId
                  select new Classes.AlertComment()
                  {
                      AlertId = comment.AlertID,
                      CommentId = comment.CommentID ?? 0,
                      DocumentId = comment.MarkupDocumentID ?? 0,
                      AlertStateId = comment.AlertStateID,
                      Comment = comment.LongComment,
                      MarkupId = comment.MarkupID,
                      EmployeeFullName = comment.EmployeeFullName,
                      CustodyEnd = comment.CustodyEndDate,
                      CustodyStart = comment.CustodyStartDate,
                      GeneratedDate = comment.GeneratedDate,
                      ParentId = comment.ParentID,
                      UserCode = comment.UserCode,
                      ProofingXReviwerId = comment.ProofingXReviwerId
                  }).ToList();

            //rc = (from AlertComment in dbContext.AlertComments.AsQueryable()
            //      join SecUser in dbContext.SecurityUsers on AlertComment.UserCode.ToLower() equals SecUser.UserCode.ToLower() into SecUserGrouping
            //      from SecUser in SecUserGrouping.DefaultIfEmpty()
            //      join EmployeeCloak in dbContext.EmployeeCloaks on SecUser.EmpCode.ToLower() equals EmployeeCloak.EmpCode.ToLower() into EmpGrouping
            //      from EmployeeCloak in EmpGrouping.DefaultIfEmpty()
            //      where AlertComment.ParentId == comments.CommentId
            //      orderby AlertComment.GeneratedDate, AlertComment.CommentId
            //      select new Classes.AlertComment()
            //      {
            //          CommentId = AlertComment.CommentId,
            //          AlertId = AlertComment.AlertId,
            //          UserCode = AlertComment.UserCode,
            //          GeneratedDate = AlertComment.GeneratedDate,
            //          Comment = AlertComment.Comment,
            //          Emailsent = AlertComment.Emailsent,
            //          UserCodeCp = AlertComment.UserCodeCp,
            //          DocumentList = AlertComment.DocumentList,
            //          AssignedEmpCode = AlertComment.AssignedEmpCode,
            //          AlrtNotifyHdrId = AlertComment.AlrtNotifyHdrId,
            //          AlertStateId = AlertComment.AlertStateId,
            //          CsProjectId = AlertComment.CsProjectId,
            //          CsReviewId = AlertComment.CsReviewId,
            //          CsCommentId = AlertComment.CsCommentId,
            //          CsReplyId = AlertComment.CsReplyId,
            //          ParentId = AlertComment.ParentId,
            //          CsMarkupImage = AlertComment.CsMarkupImage,
            //          IsDraft = AlertComment.IsDraft,
            //          CustodyStart = AlertComment.CustodyStart,
            //          CustodyEnd = AlertComment.CustodyEnd,
            //          BoardId = AlertComment.BoardId,
            //          BoardHdrId = AlertComment.BoardHdrId,
            //          BoardColId = AlertComment.BoardColId,
            //          BoardDtlId = AlertComment.BoardDtlId,
            //          IsSystem = AlertComment.IsSystem,
            //          VrCode = AlertComment.VrCode,
            //          VcCode = AlertComment.VcCode,
            //          DocumentId = AlertComment.DocumentId,
            //          Alert = AlertComment.Alert,
            //          ProofingXReviwerId = AlertComment.ProofingXReviwerId,
            //          EmployeeFullName = EmployeeCloak.EmpFname + (EmployeeCloak.EmpMi != null ? " " + EmployeeCloak.EmpMi + ". " : " ") + EmployeeCloak.EmpLname
            //      }).ToList();

            foreach (Classes.AlertComment alertComment in rc)
            {
                alertComment.Replies = LoadReplies(dbContext, alertComment, documentID, alertID, EmployeeCode);
            }

            return rc;
        }

        public static AlertComment CreateComment(DbContext dbContext, AlertComment alertComment)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AlertComment> rc = dbContext.AlertComments.Add(alertComment);

            dbContext.SaveChanges();

            return rc.Entity;

        }

        public static bool Insert(DbContext dbContext, AlertComment alertComment)
        {
            bool rc = true;

            try
            {
                dbContext.AlertComments.Add(alertComment);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                rc = false;
            }

            return rc;

        }

        public static AlertComment UpdateComment(DbContext dbContext, int alertID, int documentID, AlertComment alertComment)
        {
            AlertComment rc = dbContext.AlertComments.FirstOrDefault(item => item.CommentId == alertComment.CommentId);

            if (rc != null)
            {
                rc.Comment = alertComment.Comment;

                dbContext.SaveChanges();
            }

            return rc;

        }

        static public System.Linq.IQueryable<Database.Entities.AlertComment> Load(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Database.Entities.AlertComment> LoadRet = default;
            LoadRet = from AlertComment in DbContext.AlertComments.AsQueryable()
                      orderby AlertComment.GeneratedDate descending
                      select AlertComment;
            return LoadRet;
        }

        static public System.Linq.IQueryable<Database.Entities.AlertComment> LoadByAlertID(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID)
        {
            System.Linq.IQueryable<Database.Entities.AlertComment> LoadByAlertIDRet = default;
            LoadByAlertIDRet = from AlertComment in DbContext.AlertComments.AsQueryable()
                               where AlertComment.AlertId == AlertID
                               orderby AlertComment.GeneratedDate descending
                               select AlertComment;
            return LoadByAlertIDRet;
        }


        #endregion
    }
}
