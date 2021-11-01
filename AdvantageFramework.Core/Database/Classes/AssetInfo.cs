using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database.Classes
{
    public class AssetInfo
    {
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public DateTime UploadDate { get; set; }
        public string UserCode { get; set; }
        public string UserFullName { get; set; }
        public List<string> Tags { get; set; }
        public string MimeType { get; set; }
        public int FileSize { get; set; }
        public List<AssetInfo> Versions { get; set; }
        public byte[] Thumbnail { get; set; }
        public bool? IsLatestDocument { get; set; }
        public int? TotalApproves { get; set; }
        public int? TotalRejects { get; set; }
        public int? TotalDefers { get; set; }
        public int? TotalMarkups { get; set; }
        public int? TotalVersions { get; set; }
        public int? TotalVersionsForAlertID { get; set; }
        public string LatestMarkupFullName { get; set; }
        public DateTime? LatestMarkupDate { get; set; }
        public AssetInfo()
        {
        }
    }
}
