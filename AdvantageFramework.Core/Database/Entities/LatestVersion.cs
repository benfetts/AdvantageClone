using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdvantageFramework.Core.Database.Entities
{
    public partial class LatestVersion
    {
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public string Filename { get; set; }
        public byte[] Thumbnail { get; set; }
        public int? VersionNumber { get; set; }
        public string Version
        {
            get
            {
                if (VersionNumber != null && VersionNumber > 0)
                    return "v." + VersionNumber.ToString().PadLeft(2, '0');
                else
                    return "v.01";
            }
        }
    }
}
