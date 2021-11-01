using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.Database.Procedures
{
    public class Document
    {
        #region  Constants 



        #endregion

        #region  Enum 



        #endregion

        #region  Variables 



        #endregion

        #region  Properties 



        #endregion

        #region  Methods 

        //public static IQueryable<Database.Entities.Document> LoadCurrentAPDocuments(AdvantageFramework.Core.Database.DbContext DbContext, long AccountPayableID)
        //{
        //    IQueryable<Database.Entities.Document> LoadCurrentAPDocumentsRet = default;

        //    // objects
        //    int[] DocumentIDs = null;
        //    try
        //    {
        //        DocumentIDs = DbContext.Database.SqlQuery<int>(string.Format("EXEC [advsp_get_current_ap_document_ids] {0} ", AccountPayableID)).ToArray;
        //        LoadCurrentAPDocumentsRet = from Document in DbContext.Documents.AsQueryable()
        //                                    where DocumentIDs.Contains(Document.ID)
        //                                    select Document;
        //    }
        //    catch (Exception)
        //    {
        //        LoadCurrentAPDocumentsRet = default;
        //    }

        //    return LoadCurrentAPDocumentsRet;
        //}

        //public static IQueryable<Database.Entities.Document> LoadCurrentJobComponentDocuments(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber, short JobComponentNumber)
        //{
        //    IQueryable<Database.Entities.Document> LoadCurrentJobComponentDocumentsRet = default;

        //    // objects
        //    int[] DocumentIDs = null;
        //    try
        //    {
        //        DocumentIDs = DbContext.Database.SqlQuery<int>(string.Format("EXEC [advsp_get_current_job_comp_document_ids] {0}, {1} ", JobNumber, JobComponentNumber)).ToArray;
        //        LoadCurrentJobComponentDocumentsRet = from Document in DbContext.Documents.AsQueryable()
        //                                              where DocumentIDs.Contains(Document.ID)
        //                                              select Document;
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadCurrentJobComponentDocumentsRet = default;
        //    }

        //    return LoadCurrentJobComponentDocumentsRet;
        //}

        //public static IQueryable<Database.Entities.Document> LoadCurrentJobDocuments(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber)
        //{
        //    IQueryable<Database.Entities.Document> LoadCurrentJobDocumentsRet = default;

        //    // objects
        //    int[] DocumentIDs = null;
        //    try
        //    {
        //        DocumentIDs = DbContext.Database.SqlQuery<int>(string.Format("EXEC [advsp_get_current_job_document_ids] {0} ", JobNumber)).ToArray;
        //        LoadCurrentJobDocumentsRet = from Document in DbContext.Documents.AsQueryable()
        //                                     where DocumentIDs.Contains(Document.DocumentId)
        //                                     select Document;
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadCurrentJobDocumentsRet = default;
        //    }

        //    return LoadCurrentJobDocumentsRet;
        //}

        //public static IQueryable<Database.Entities.Document> LoadCurrentLabelDocuments(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.DataContext DataContext, int LabelID)
        //{
        //    IQueryable<Database.Entities.Document> LoadCurrentLabelDocumentsRet = default;

        //    // objects
        //    long[] DocumentIDs = null;
        //    try
        //    {
        //        DocumentIDs = (from Entity in AdvantageFramework.Core.Database.Procedures.LabelDocument.LoadByLabelID(DataContext, LabelID)
        //                       select Entity.DocumentID).ToArray();
        //        LoadCurrentLabelDocumentsRet = from Document in DbContext.Documents.AsQueryable()
        //                                       where DocumentIDs.Contains(Document.ID)
        //                                       select Document;
        //    }
        //    catch (Exception)
        //    {
        //        LoadCurrentLabelDocumentsRet = default;
        //    }

        //    return LoadCurrentLabelDocumentsRet;
        //}

        public static AdvantageFramework.Core.Database.Entities.Document LoadByDocumentID(AdvantageFramework.Core.Database.DbContext DbContext, long DocumentID)
        {
            AdvantageFramework.Core.Database.Entities.Document LoadByDocumentIDRet = default;
            try
            {
                LoadByDocumentIDRet = (from Document in DbContext.Documents.AsQueryable()
                                       where Document.DocumentId == DocumentID
                                       select Document).SingleOrDefault();
            }
            catch (Exception)
            {
                LoadByDocumentIDRet = default;
            }

            return LoadByDocumentIDRet;
        }

        public static IQueryable<Database.Entities.Document> Load(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            IQueryable<Database.Entities.Document> LoadRet = default;
            LoadRet = from Document in DbContext.Documents.AsQueryable()
                      select Document;
            return LoadRet;
        }

        public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Document Document)
        {
            bool InsertRet = default;

            // objects
            bool Inserted = false;
            bool IsValid = true;
            string ErrorText = "";
            try
            {
                DbContext.Documents.Add(Document);
                //ErrorText = Document.ValidateEntity(IsValid);
                if (IsValid)
                {
                    DbContext.SaveChanges();
                    Inserted = true;
                }
                else
                {
                    //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
                }
            }
            catch (Exception)
            {
                Inserted = false;
            }
            finally
            {
                InsertRet = Inserted;
            }

            return InsertRet;
        }

        //public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Document Document)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        DbContext.UpdateObject(Document);
        //        ErrorText = Document.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DbContext.SaveChanges();
        //            Updated = true;
        //        }
        //        else
        //        {
        //            //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
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

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Document Document)
        //{
        //    bool DeleteRet = default;

        //    // objects
        //    bool Deleted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    AdvantageFramework.Core.Database.Entities.Agency Agency = default;
        //    try
        //    {
        //        if (IsValid)
        //        {
        //            DbContext.DeleteEntityObject(Document);
        //            Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
        //            if (Agency is object)
        //            {
        //                try
        //                {

        //                    // When deleting main doc record, make sure doc is not being used as an attachment
        //                    // For Each DocumentAlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, Document.ID)

        //                    // AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

        //                    // Next
        //                    DbContext.Database.ExecuteSqlCommand(string.Format("DELETE FROM ALERT_ATTACHMENT WITH(ROWLOCK) WHERE DOCUMENT_ID = {0};", Document.ID));
        //                }
        //                catch (Exception ex)
        //                {
        //                }

        //                AdvantageFramework.Core.FileSystem.Delete(Agency, Document.FileSystemFileName);
        //            }

        //            DbContext.SaveChanges();
        //            Deleted = true;
        //        }
        //        else
        //        {
        //            //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Deleted = false;
        //    }
        //    finally
        //    {
        //        DeleteRet = Deleted;
        //    }

        //    return DeleteRet;
        //}

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, IEnumerable<AdvantageFramework.Core.Database.Entities.Document> Documents)
        //{
        //    bool DeleteRet = default;

        //    // objects
        //    bool Deleted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    AdvantageFramework.Core.Database.Entities.Agency Agency = default;
        //    try
        //    {
        //        if (IsValid)
        //        {
        //            Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
        //            foreach (var Document in Documents)
        //            {
        //                try
        //                {
        //                    DbContext.DeleteEntityObject(Document);
        //                    if (Agency is object)
        //                    {
        //                        AdvantageFramework.Core.FileSystem.Delete(Agency, Document.FileSystemFileName);
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }

        //            DbContext.SaveChanges();
        //            Deleted = true;
        //        }
        //        else
        //        {
        //            //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Deleted = false;
        //    }
        //    finally
        //    {
        //        DeleteRet = Deleted;
        //    }

        //    return DeleteRet;
        //}

        #endregion
    }
}
