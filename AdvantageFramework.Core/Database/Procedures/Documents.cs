using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;


namespace AdvantageFramework.Core.Database.Procedures
{
    public class Documents
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

        public static Microsoft.EntityFrameworkCore.DbSet<AdvantageFramework.Core.Database.Entities.Document> LoadCurrentAPDocuments(AdvantageFramework.Core.Database.DataContext DbContext, long AccountPayableID)
        {

            // objects
            int[] DocumentIDs = null;
            Microsoft.EntityFrameworkCore.DbSet<AdvantageFramework.Core.Database.Entities.Document> rv;

            try
            {
                //DocumentIDs = DbContext.Database.SqlQuery<int>(string.Format("EXEC [advsp_get_current_ap_document_ids] {0} ", AccountPayableID)).ToArray;

                rv = (Microsoft.EntityFrameworkCore.DbSet<Entities.Document>)(from Document in DbContext.Documents.AsQueryable()
                                                                              where DocumentIDs.Contains(Document.DocumentId)
                                                                              select Document);
            }
            catch (Exception ex)
            {
                rv = null;
            }

            return rv;
        }
        public static Microsoft.EntityFrameworkCore.DbSet<AdvantageFramework.Core.Database.Entities.Document> LoadCurrentJobComponentDocuments(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber, short JobComponentNumber)
        {

            // objects
            int[] DocumentIDs = null;

            try
            {
                //DocumentIDs = DbContext.Database.SqlQuery<int>(string.Format("EXEC [advsp_get_current_job_comp_document_ids] {0}, {1} ", JobNumber, JobComponentNumber)).ToArray;

                return (Microsoft.EntityFrameworkCore.DbSet<AdvantageFramework.Core.Database.Entities.Document>)(from Document in DbContext.Documents.AsQueryable()
                                                                                                                 where DocumentIDs.Contains(Document.DocumentId)
                                                                                                                 select Document);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Microsoft.EntityFrameworkCore.DbSet<AdvantageFramework.Core.Database.Entities.Document> LoadCurrentJobDocuments(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber)
        {

            // objects
            int[] DocumentIDs = null;

            try
            {
                //DocumentIDs = DbContext.Database.SqlQuery<int>(string.Format("EXEC [advsp_get_current_job_document_ids] {0} ", JobNumber)).ToArray;

                return (Microsoft.EntityFrameworkCore.DbSet<AdvantageFramework.Core.Database.Entities.Document>)(from Document in DbContext.Documents.AsQueryable()
                                                                                                                 where DocumentIDs.Contains(Document.DocumentId)
                                                                                                                 select Document);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Microsoft.EntityFrameworkCore.DbSet<AdvantageFramework.Core.Database.Entities.Document> LoadCurrentLabelDocuments(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.DataContext DataContext, int LabelID)
        {

            // objects
            long[] DocumentIDs = null;

            try
            {
                return (Microsoft.EntityFrameworkCore.DbSet<AdvantageFramework.Core.Database.Entities.Document>)(from Document in DbContext.Documents.AsQueryable()
                                                                                                                 where DocumentIDs.Contains(Document.DocumentId)
                                                                                                                 select Document);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static AdvantageFramework.Core.Database.Entities.Document LoadByDocumentID(AdvantageFramework.Core.Database.DbContext DbContext, long DocumentID)
        {
            try
            {
                return (from Document in DbContext.Documents.AsQueryable()
                        where Document.DocumentId == DocumentID
                        select Document).SingleOrDefault();
            }
            catch (Exception ex)
            {
                AdvantageFramework.Core.Security.Methods.AddToProofingEventLog(ex.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }
        public static Microsoft.EntityFrameworkCore.DbSet<AdvantageFramework.Core.Database.Entities.Document> Load(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            return DbContext.Documents;
        }
        public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Document Document)
        {

            // objects
            bool Inserted = false;
            //bool IsValid = true;
            //string ErrorText = "";

            try
            {
                DbContext.Documents.Add(Document);

                //ErrorText = Document.ValidateEntity(IsValid);

                //if (IsValid)
                //{
                DbContext.SaveChanges();

                Inserted = true;
                //}
                //else
                //    AdvantageFramework.Core.Navigation.Methods.ShowMessageBox(ErrorText);
            }
            catch (Exception ex)
            {
                Inserted = false;
            }

            return Inserted;
        }
        public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Document Document)
        {

            // objects
            bool Updated;

            try
            {
                DbContext.Documents.Update(Document);

                DbContext.SaveChanges();

                Updated = true;
            }
            catch (Exception)
            {
                Updated = false;
            }
            return Updated;
        }

        public static IEnumerable<Entities.Document> GetHistory(DbContext dbContext, int DocumentID, int AlertID)
        {
            Entities.Document document = (from Document in dbContext.Documents.AsQueryable()
                                          where Document.DocumentId == DocumentID
                                          select Document).First();

            IEnumerable<Entities.Document> docs = (from doc in dbContext.Documents.AsQueryable()
                                                   join a in dbContext.AlertAttachments on new { ID = doc.DocumentId, AlertId = AlertID } equals new { ID = a.DocumentId, AlertId = a.AlertId }
                                                   where doc.Filename == document.Filename
                                                   select doc);
            return docs.ToArray();
        }

        public static Entities.Document GetLatestVersion(DbContext dbContext, int DocumentID, int AlertID)
        {
            IEnumerable<Entities.Document> docs = GetHistory(dbContext, DocumentID, AlertID);

            return docs.Where(x => x.DocumentId == docs.Max(xx => xx.DocumentId)).First();
        }

        public static IEnumerable<Entities.Document> GetAlertDocuments(DbContext dbContext, int AlertID)
        {
            var groups = from Document in dbContext.Documents.AsQueryable()
            join a in dbContext.AlertAttachments on Document.DocumentId equals a.DocumentId
            where a.AlertId == AlertID
            group Document by Document.Filename into g select g;

            groups = from g in groups.AsQueryable() orderby g.Min(x => x.UploadedDate) select g;


            List<int> documentIds = (from g in groups.AsQueryable() select g.Max(x => x.DocumentId)).ToList();


            var docs = (from Document in dbContext.Documents.AsQueryable()
                                                   where documentIds.Contains(Document.DocumentId)
                                                   select Document);

            var foodocs = docs.AsEnumerable().OrderBy(d => documentIds.IndexOf(d.DocumentId));

            return foodocs.ToArray();
        }

        public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Document Document)
        {

            // objects
            bool Deleted = false;
            bool IsValid = true;
            string ErrorText = "";
            AdvantageFramework.Core.Database.Entities.Agency Agency = null;

            try
            {
                if (IsValid)
                {
                    DbContext.Documents.Remove(Document);

                    Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);

                    if (Agency != null)
                    {
                        try
                        {

                            // When deleting main doc record, make sure doc is not being used as an attachment
                            // For Each DocumentAlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, Document.ID)

                            // AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

                            // Next
                            //TODO Fix this
                            //DbContext.Database.ExecuteSqlCommand(string.Format("DELETE FROM ALERT_ATTACHMENT WITH(ROWLOCK) WHERE DOCUMENT_ID = {0};", Document.DocumentId));
                        }
                        catch (Exception ex)
                        {
                        }

                        AdvantageFramework.Core.FileSystem.Methods.Delete(Agency, Document.RepositoryFilename);
                    }

                    DbContext.SaveChanges();

                    Deleted = true;
                }
                else
                    AdvantageFramework.Core.Navigation.Methods.ShowMessageBox(ErrorText);
            }
            catch (Exception ex)
            {
                Deleted = false;
            }

            return Deleted;
        }
        public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, IEnumerable<AdvantageFramework.Core.Database.Entities.Document> Documents)
        {

            // objects
            bool Deleted = false;
            bool IsValid = true;
            string ErrorText = "";
            AdvantageFramework.Core.Database.Entities.Agency Agency = null;
            AdvantageFramework.Core.Database.Entities.Document Document = null;

            try
            {
                if (IsValid)
                {
                    Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);

                    foreach (var Doc in Documents)
                    {
                        try
                        {
                            DbContext.Documents.Remove(Doc);

                            if (Agency != null)
                                AdvantageFramework.Core.FileSystem.Methods.Delete(Agency, Document.RepositoryFilename);
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    DbContext.SaveChanges();

                    Deleted = true;
                }
                else
                    AdvantageFramework.Core.Navigation.Methods.ShowMessageBox(ErrorText);
            }
            catch (Exception ex)
            {
                Deleted = false;
            }

            return Deleted;
        }

        public static byte[] GetDocumentThumbnail(DbContext dbContext, int DocumentID)
        {
            byte[] rv = null;

            Entities.Document document = LoadByDocumentID(dbContext, DocumentID);

            if (document != null && document.Thumbnail != null)
            {
                rv = document.Thumbnail;
            }
            else if (document != null)
            {
                rv = GetDocumentThumbnail(dbContext, document);
            }

            return rv;
        }

        public static byte[] GetDocumentThumbnail(DbContext dbContext, Entities.Document document)
        {
            byte[] byteFile = null;
            bool FileExists = false;
            byte[] rv = null;

            if (document.MimeType.Contains("image"))
            {
                var Agency = Procedures.Agency.Load(dbContext);
                if (Agency != null && document != null)
                {

                    if (AdvantageFramework.Core.FileSystem.Methods.Download(Agency, document, ref byteFile, ref FileExists))
                    {
                        if (byteFile != null)
                        {
                            System.Drawing.Image img = null;
                            using (var ms = new MemoryStream(byteFile))
                            {
                                img = System.Drawing.Image.FromStream(ms);

                            }

                            float height = 132;
                            float width = 132;

                            if (img.Height > img.Width)
                            {
                                width = (int)((height / img.Height) * (float)img.Width);
                            }
                            else if (img.Height < img.Width)
                            {
                                float factor = (width / img.Width);
                                height = (int)(factor * img.Height);
                            }

                            System.Drawing.Image thumbNail = img.GetThumbnailImage((int)width, (int)height, () => false, IntPtr.Zero);
                            using (var ms = new MemoryStream())
                            {
                                thumbNail.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                document.Thumbnail = ms.ToArray();
                                dbContext.SaveChanges();
                            }

                            rv = document.Thumbnail;
                        }
                    }
                }

            }

            return rv;
        }

        #endregion

    }
}
