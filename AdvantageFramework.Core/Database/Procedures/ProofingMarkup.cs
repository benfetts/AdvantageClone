using AdvantageFramework.Core.Database.Classes;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.Database.Procedures
{
    public class ProofingMarkup
    {
        public static IQueryable<ProofingMarkupDto> LoadMarkup(AdvantageFramework.Core.Database.DbContext DbContext,
            int AlertId, int DocumentId)
        {
            IQueryable<ProofingMarkupDto> rv;

            try
            {
                rv = (from ProofingMarkup in DbContext.ProofingMarkups.AsQueryable()
                      join AlertComment in DbContext.AlertComments
                      on ProofingMarkup.CommentId equals AlertComment.CommentId
                      where AlertComment.AlertId == AlertId &&
                   ProofingMarkup.DocumentId == DocumentId
                      select new ProofingMarkupDto()
                      {
                          Id = ProofingMarkup.Id,
                          MarkupXml = ProofingMarkup.MarkupXml,
                          Markup = AlertComment.Comment, //PROOFING_MARKUP.MARKUP should be dropped. Redundant.
                          EmpCode = ProofingMarkup.EmpCode,
                          DocumentId = DocumentId,
                          Generated = ProofingMarkup.Generated,
                          MarkupTypeId = ProofingMarkup.MarkupTypeId,
                          CommentId = ProofingMarkup.CommentId,
                          Thumbnail = ProofingMarkup.Thumbnail,
                          SeqNbr = ProofingMarkup.SeqNbr,
                          ProofingXReviwerId = ProofingMarkup.ProofingXReviwerId,
                          AlertId = AlertId,
                      });

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }

            return rv;
        }

        public static AdvantageFramework.Core.Database.Entities.ProofingMarkup CreateMarkup(DbContext dbContext, int alertID, AdvantageFramework.Core.Database.Entities.ProofingMarkup value)
        {
            try
            {
                value.MarkupXml = ConvertUtf8ToUtf16(value.MarkupXml);
                dbContext.ProofingMarkups.Add(value);

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            return value;
        }
        public static AdvantageFramework.Core.Database.Entities.ProofingMarkup UpdateMarkup(DbContext dbContext, int Id, int alertID, Database.Entities.ProofingMarkup value)
        {
            try
            {
                var rv = (from ProofingMarkup in dbContext.ProofingMarkups
                          join AlertComment in dbContext.AlertComments.AsQueryable()
                          on ProofingMarkup.CommentId equals AlertComment.CommentId
                          where ProofingMarkup.Id == Id
                          select new { ProofingMarkup, AlertComment }).FirstOrDefault();

                if (rv != null)
                {
                    rv.ProofingMarkup.Markup = value.Markup;
                    rv.AlertComment.Comment = value.Markup;
                    if (value.MarkupXml.StartsWith("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>"))
                    {
                        rv.ProofingMarkup.MarkupXml = ConvertUtf8ToUtf16(value.MarkupXml);
                    }

                    dbContext.Update(rv.ProofingMarkup);
                    dbContext.Update(rv.AlertComment);

                    dbContext.SaveChanges();

                    return rv.ProofingMarkup;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return null;
            }
        }
        static private string ConvertUtf8ToUtf16(string utf8Xml)
        {
            System.IO.MemoryStream ms = new MemoryStream();
            System.Xml.XmlWriterSettings xws = new System.Xml.XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;
            System.Xml.Linq.XDocument xDoc = System.Xml.Linq.XDocument.Parse(utf8Xml);
            xDoc.Declaration.Encoding = "utf-16";
            using (System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(ms, xws))
            {

                xDoc.WriteTo(xw);
            }
            System.Text.Encoding ut8 = System.Text.Encoding.UTF8;
            System.Text.Encoding ut116 = System.Text.Encoding.Unicode;
            byte[] utf16XmlArray = System.Text.Encoding.Convert(ut8, ut116, ms.ToArray());
            var utf16Xml = System.Text.Encoding.Unicode.GetString(utf16XmlArray);

            return utf16Xml;
        }

        public static void DeleteMarkup(DbContext dbContext, int id)
        {
            AdvantageFramework.Core.Database.Entities.ProofingMarkup rv = null;
            try
            {

                rv = (from ProofingMarkup in dbContext.ProofingMarkups.AsQueryable()
                      where ProofingMarkup.Id == id
                      select ProofingMarkup).FirstOrDefault();


                dbContext.Remove(rv);

                dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
        }
    }
}
