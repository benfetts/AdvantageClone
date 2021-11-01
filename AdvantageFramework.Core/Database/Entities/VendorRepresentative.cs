using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("VEN_REP")]
    public partial class VendorRepresentative
    {
        [Key]
        [Column("VN_CODE")]
        [StringLength(6)]
        public string VnCode { get; set; }
        [Key]
        [Column("VR_CODE")]
        [StringLength(4)]
        public string VrCode { get; set; }
        [Column("VR_FNAME")]
        [StringLength(30)]
        public string VrFname { get; set; }
        [Column("VR_LNAME")]
        [StringLength(30)]
        public string VrLname { get; set; }
        [Column("VR_MI")]
        [StringLength(1)]
        public string VrMi { get; set; }
        [Column("VR_FIRM_NAME")]
        [StringLength(40)]
        public string VrFirmName { get; set; }
        [Column("VR_ADDRESS1")]
        [StringLength(40)]
        public string VrAddress1 { get; set; }
        [Column("VR_ADDRESS2")]
        [StringLength(40)]
        public string VrAddress2 { get; set; }
        [Column("VR_CITY")]
        [StringLength(20)]
        public string VrCity { get; set; }
        [Column("VR_COUNTY")]
        [StringLength(20)]
        public string VrCounty { get; set; }
        [Column("VR_STATE")]
        [StringLength(10)]
        public string VrState { get; set; }
        [Column("VR_COUNTRY")]
        [StringLength(20)]
        public string VrCountry { get; set; }
        [Column("VR_ZIP")]
        [StringLength(10)]
        public string VrZip { get; set; }
        [Column("VR_TELEPHONE")]
        [StringLength(13)]
        public string VrTelephone { get; set; }
        [Column("VR_EXTENTION")]
        [StringLength(4)]
        public string VrExtention { get; set; }
        [Column("VR_FAX")]
        [StringLength(13)]
        public string VrFax { get; set; }
        [Column("VR_FAX_EXTENTION")]
        [StringLength(4)]
        public string VrFaxExtention { get; set; }
        [Column("EMAIL_ADDRESS")]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Column("VR_INACTIVE_FLAG")]
        public short? VrInactiveFlag { get; set; }
        [Column("VR_LABEL")]
        [StringLength(20)]
        public string VrLabel { get; set; }
        [Column("VR_PHONE_CELL")]
        [StringLength(13)]
        public string VrPhoneCell { get; set; }
        [Column("CONTACT_TYPE_ID")]
        public int? ContactTypeId { get; set; }
    }
}
