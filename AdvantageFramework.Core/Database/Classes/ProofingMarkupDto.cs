using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database.Classes
{
    public class ProofingMarkupDto
    {
        public int Id { get; set; }
        public string MarkupXml { get; set; }
        public string Markup { get; set; }
        public string EmpCode { get; set; }
        public DateTime Generated { get; set; }
        public int MarkupTypeId { get; set; }
        public int? CommentId { get; set; }
        public byte[] Thumbnail { get; set; }
        public int? DocumentId { get; set; }
        public string[] Mentions { get; set; }
        public short? SeqNbr { get; set; }
        public int? ProofingXReviwerId { get; set; }
        public int? AlertId { get; set; }
    }
}
